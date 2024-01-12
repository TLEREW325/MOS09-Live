<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatabaseUtilities
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExit = New System.Windows.Forms.Button
        Me.gpxARInvoiceBatch = New System.Windows.Forms.GroupBox
        Me.cmdViewARInvoiceBatch = New System.Windows.Forms.Button
        Me.cmdUpdateARInvoiceBatch = New System.Windows.Forms.Button
        Me.gpxUpdateAPInvoiceBatch = New System.Windows.Forms.GroupBox
        Me.cmdShowAPInvoiceBatch = New System.Windows.Forms.Button
        Me.cmdUpdateAPInvoiceBatch = New System.Windows.Forms.Button
        Me.gpxAPPaymentBatch = New System.Windows.Forms.GroupBox
        Me.cmdShowAPPaymentBatch = New System.Windows.Forms.Button
        Me.cmdUpdateAPPaymentBatch = New System.Windows.Forms.Button
        Me.gpxARPaymentBatch = New System.Windows.Forms.GroupBox
        Me.cmdShowARPaymentBatch = New System.Windows.Forms.Button
        Me.cmdUpdateARPaymentBatch = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdViewInvoiceCOS = New System.Windows.Forms.Button
        Me.cmdUpdateInvoiceCOS = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdViewReceivers = New System.Windows.Forms.Button
        Me.cmdUpdateReceivers = New System.Windows.Forms.Button
        Me.cmdDeleteTestData = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdViewErrorLog = New System.Windows.Forms.Button
        Me.cmdClearLog = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdViewInvoiceShipments = New System.Windows.Forms.Button
        Me.cmdUpdateShipmentInvoices = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.cmdViewSO = New System.Windows.Forms.Button
        Me.cmdUpdateSO = New System.Windows.Forms.Button
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.cmdViewShipments = New System.Windows.Forms.Button
        Me.cmdUpdateShipments = New System.Windows.Forms.Button
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.cmdViewCOSalesOrders = New System.Windows.Forms.Button
        Me.cmdUpdateCOSSalesOrders = New System.Windows.Forms.Button
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.cmdViewCOSFromShipment = New System.Windows.Forms.Button
        Me.cmdUpdateCOSFromShipment = New System.Windows.Forms.Button
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.cmdViewVoucherlines = New System.Windows.Forms.Button
        Me.cmdUpdateVoucherLines = New System.Windows.Forms.Button
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.cmdViewLot = New System.Windows.Forms.Button
        Me.cmdUpdateLot = New System.Windows.Forms.Button
        Me.cmdClearLocks = New System.Windows.Forms.Button
        Me.tabUtilities = New System.Windows.Forms.TabControl
        Me.tabU1 = New System.Windows.Forms.TabPage
        Me.GroupBox38 = New System.Windows.Forms.GroupBox
        Me.cmdViewSerialLog = New System.Windows.Forms.Button
        Me.cmdUpdateSerialLog = New System.Windows.Forms.Button
        Me.GroupBox37 = New System.Windows.Forms.GroupBox
        Me.cmdViewUPS = New System.Windows.Forms.Button
        Me.cmdDeleteUPS = New System.Windows.Forms.Button
        Me.GroupBox29 = New System.Windows.Forms.GroupBox
        Me.cmdViewDropShipSO = New System.Windows.Forms.Button
        Me.cmdUpdateDropShipSO = New System.Windows.Forms.Button
        Me.GroupBox20 = New System.Windows.Forms.GroupBox
        Me.cmdUpdateReturnCOS = New System.Windows.Forms.Button
        Me.cmdViewReturnHeader = New System.Windows.Forms.Button
        Me.tabU2 = New System.Windows.Forms.TabPage
        Me.GroupBox42 = New System.Windows.Forms.GroupBox
        Me.cmdCloseReceiversForAP = New System.Windows.Forms.Button
        Me.cmdUpdateReceiversForAP = New System.Windows.Forms.Button
        Me.GroupBox40 = New System.Windows.Forms.GroupBox
        Me.cmdViewLotFromFox = New System.Windows.Forms.Button
        Me.cmdUpdateLotFromFox = New System.Windows.Forms.Button
        Me.GroupBox39 = New System.Windows.Forms.GroupBox
        Me.cmdViewOpenPO = New System.Windows.Forms.Button
        Me.cmdCloseOpenPOs = New System.Windows.Forms.Button
        Me.GroupBox28 = New System.Windows.Forms.GroupBox
        Me.cmdViewPOHeadersAddress = New System.Windows.Forms.Button
        Me.cmdUpdatePOAddress = New System.Windows.Forms.Button
        Me.GroupBox27 = New System.Windows.Forms.GroupBox
        Me.cmdViewPOLineStatus = New System.Windows.Forms.Button
        Me.cmdUpdatePOLineStatus = New System.Windows.Forms.Button
        Me.tabU4 = New System.Windows.Forms.TabPage
        Me.GroupBox35 = New System.Windows.Forms.GroupBox
        Me.cmdViewBuildTiers = New System.Windows.Forms.Button
        Me.cmdUpdateBuildTiers = New System.Windows.Forms.Button
        Me.GroupBox34 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox33 = New System.Windows.Forms.GroupBox
        Me.cmdViewSteelUsage = New System.Windows.Forms.Button
        Me.cmdUpdateSteelUsage = New System.Windows.Forms.Button
        Me.GroupBox32 = New System.Windows.Forms.GroupBox
        Me.cmdViewWireYard = New System.Windows.Forms.Button
        Me.cmdUpdateWireYard = New System.Windows.Forms.Button
        Me.GroupBox30 = New System.Windows.Forms.GroupBox
        Me.cmdViewItemListTWD = New System.Windows.Forms.Button
        Me.cmdUpdateItemListTWD = New System.Windows.Forms.Button
        Me.GroupBox26 = New System.Windows.Forms.GroupBox
        Me.cmdViewReceiverTiers = New System.Windows.Forms.Button
        Me.cmdUpdateReceiverTiers = New System.Windows.Forms.Button
        Me.GroupBox25 = New System.Windows.Forms.GroupBox
        Me.cmdViewVendorReturns = New System.Windows.Forms.Button
        Me.cmdUpdateVendorReturnsTiers = New System.Windows.Forms.Button
        Me.GroupBox19 = New System.Windows.Forms.GroupBox
        Me.cmdViewAdjustmentTiers = New System.Windows.Forms.Button
        Me.cmdUpdateAdjustmentTiers = New System.Windows.Forms.Button
        Me.GroupBox17 = New System.Windows.Forms.GroupBox
        Me.cmdViewCostTierReturns = New System.Windows.Forms.Button
        Me.cmdUpdateCostTierReturns = New System.Windows.Forms.Button
        Me.GroupBox14 = New System.Windows.Forms.GroupBox
        Me.cmdViewAssemblyLineCost = New System.Windows.Forms.Button
        Me.cmdUpdateAssemblyLineCost = New System.Windows.Forms.Button
        Me.GroupBox13 = New System.Windows.Forms.GroupBox
        Me.cmdViewAssemblyLineNumbers = New System.Windows.Forms.Button
        Me.cmdUpdateAssemblyLineNumbers = New System.Windows.Forms.Button
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.cmdViewAssembly = New System.Windows.Forms.Button
        Me.cmdUpdateAssemblyCost = New System.Windows.Forms.Button
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.cmdViewItemList = New System.Windows.Forms.Button
        Me.cmdUpdateItemList = New System.Windows.Forms.Button
        Me.GroupBox23 = New System.Windows.Forms.GroupBox
        Me.cmdUpdateLots = New System.Windows.Forms.Button
        Me.cmdViewLots = New System.Windows.Forms.Button
        Me.GroupBox22 = New System.Windows.Forms.GroupBox
        Me.cmdUpdatePullTests = New System.Windows.Forms.Button
        Me.cmdViewPullTests = New System.Windows.Forms.Button
        Me.tabU5 = New System.Windows.Forms.TabPage
        Me.GroupBox31 = New System.Windows.Forms.GroupBox
        Me.cmdUpdateARPaymentCompare = New System.Windows.Forms.Button
        Me.cmdViewARPaymentCompare = New System.Windows.Forms.Button
        Me.GroupBox21 = New System.Windows.Forms.GroupBox
        Me.cmdUpdateInvoicePayments = New System.Windows.Forms.Button
        Me.cmdViewOpenInvoices = New System.Windows.Forms.Button
        Me.tabU6 = New System.Windows.Forms.TabPage
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.GroupBox16 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtCostTierDivision = New System.Windows.Forms.TextBox
        Me.txtCostTierPartNumber = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmdViewCostTiers = New System.Windows.Forms.Button
        Me.cmdUpdateCostTiers = New System.Windows.Forms.Button
        Me.llUmpostedInvoiceLines = New System.Windows.Forms.LinkLabel
        Me.tabU3 = New System.Windows.Forms.TabPage
        Me.tabU7 = New System.Windows.Forms.TabPage
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.cmdViewHeatFiles = New System.Windows.Forms.Button
        Me.cmdUpdateHeatFileInPullTest = New System.Windows.Forms.Button
        Me.GroupBox36 = New System.Windows.Forms.GroupBox
        Me.cmdViewSteelCostTier = New System.Windows.Forms.Button
        Me.cmdUpdateSteelCostTier = New System.Windows.Forms.Button
        Me.tabDatagrids = New System.Windows.Forms.TabControl
        Me.SOHeader = New System.Windows.Forms.TabPage
        Me.dgvLotNumberTest = New System.Windows.Forms.DataGridView
        Me.LotNumberColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxWeightColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletWeightColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxCountColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletCountColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletPiecesColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxTypeColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NominalDiameterColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NominalLengthColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemPieceWeightColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemBoxCountColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemPalletCountColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemNominalDiameterColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemNominalLengthColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemBoxWeightColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemClassColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXRawMaterialWeightColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXScrapWeightColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXFinishedWeightColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotRawMaterialWeightColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotScrapWeightColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotFinishedWeightColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberTestBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.dgvSerialLog = New System.Windows.Forms.DataGridView
        Me.AssemblyPartNumber77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SerialNumber77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionID77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCost77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Comment77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildDate77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BuildNumber77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerID77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BatchNumber77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumber77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentNumber77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentDate77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumber77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceDate77Column = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblySerialLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvSteelCostingTable = New System.Windows.Forms.DataGridView
        Me.RMIDColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostingDateColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostPerPoundColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostingQuantityColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceNumberColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceLineColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostingTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvTWDItemList = New System.Windows.Forms.DataGridView
        Me.ItemIDColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShortDescriptionColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LongDescriptionColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PieceWeightColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxCountColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PalletCountColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxTypeColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NominalDiameterColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NominalLengthColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SafetyDataSheetColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BoxWeightColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvPurchaseLines = New System.Windows.Forms.DataGridView
        Me.PurchaseOrderHeaderKeyColumn88 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderLineNumberColumn88 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn88 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn88 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderQuantityColumn88 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQuantityReceivedColumn88 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivedQtyPendingColumn88 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POQuantityOpenColumn88 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn88 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn88 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn88 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn88 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderQuantityStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvReceivingHeaders = New System.Windows.Forms.DataGridView
        Me.ReceivingHeaderKeyColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvReturnHeader = New System.Windows.Forms.DataGridView
        Me.ReturnNumberColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnProductHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvInvoiceShipment = New System.Windows.Forms.DataGridView
        Me.ShipmentNumberColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceProductTotalColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BilledFreightColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax2Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTax3Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceTotalColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceShipmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvInvoiceCompare = New System.Windows.Forms.DataGridView
        Me.InvoiceNumberColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceCOSColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SUMExtendedCOSColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceCompareBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvInvoiceShipCOS = New System.Windows.Forms.DataGridView
        Me.SONumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SOLineNumberColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstExtendedCOSColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceShipmentCOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvShipmentHeaderTable = New System.Windows.Forms.DataGridView
        Me.STShipmentNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.STDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipmentHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvSOTable = New System.Windows.Forms.DataGridView
        Me.SOSalesOrderKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SODivisionKeyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.POHeader = New System.Windows.Forms.TabPage
        Me.dgvTFPErrorLog = New System.Windows.Forms.DataGridView
        Me.ErrorDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ErrorDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ErrorReferenceNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ErrorUserIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ErrorCommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ErrorDivisionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TFPErrorLogBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabPurchases = New System.Windows.Forms.TabPage
        Me.dgvReceiverLineQuery = New System.Windows.Forms.DataGridView
        Me.ReceivingHeaderKeyColumn96 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn96 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityReceivedColumn96 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalQuantityVouchedColumn96 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn96 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDataColumn96 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelectForInvoiceColumn96 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceivingLineQueryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvOpenPOTable = New System.Windows.Forms.DataGridView
        Me.PurchaseOrderHeaderKeyColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvARPaymentCompare = New System.Windows.Forms.DataGridView
        Me.ARTransactionKeyColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentDateColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentAmountColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentIDColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaymentLineNumberColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CheckNumberColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PLPaymentIDColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PLPaymentLineNumberColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PLInvoiceNumberColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PLPaymentAmountColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PLPaymentDateColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PLDivisionIDColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceNumberColumn77 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARPaymentCompareBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvPOHeaders = New System.Windows.Forms.DataGridView
        Me.PurchaseOrderHeaderKeyColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODropShipCustomerIDColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POAdditionalShipToColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DropShipSalesOrderNumberColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipNameColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress1Column66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipAddress2Column66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCityColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipStateColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipZipCodeColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipCountryColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvAPPaymentBatch = New System.Windows.Forms.DataGridView
        Me.BatchNumberColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.APProcessPaymentBatchBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvAPInvoiceBatch = New System.Windows.Forms.DataGridView
        Me.BatchNumberColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReceiptOfInvoiceBatchHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvInvoiceHeaderTable = New System.Windows.Forms.DataGridView
        Me.InvoiceNumberColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvARPaymentBatch = New System.Windows.Forms.DataGridView
        Me.BatchNumberColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ARProcessPaymentBatchBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvARInvoiceBatch = New System.Windows.Forms.DataGridView
        Me.BatchNumberColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InvoiceProcessingBatchHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabCostTiers = New System.Windows.Forms.TabPage
        Me.dgvSteelUsage = New System.Windows.Forms.DataGridView
        Me.SteelUsageKeyColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsageDateColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsageWeightColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelCostColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedCostColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelUsageTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvWireYard = New System.Windows.Forms.DataGridView
        Me.SteelReturnKeyColumn99 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnDateColumn99 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnWeightColumn99 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDColumn99 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelYardEntryTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvInventoryCostingEdit = New System.Windows.Forms.DataGridView
        Me.PartNumberColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostingDateColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemCostColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostQuantityColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LowerLimitColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpperLimitColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceNumberColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReferenceLineColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventoryCostingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvAssemblyLines = New System.Windows.Forms.DataGridView
        Me.AssemblyPartNumberColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentPartNumberColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentPartDescriptionColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComponentLineNumberColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvAssemblyTable = New System.Windows.Forms.DataGridView
        Me.AssemblyPartNumberColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalCostColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AssemblyHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvItemList = New System.Windows.Forms.DataGridView
        Me.CostItemIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostItemClassColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostStandardCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostStandardPriceColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvPullTestData = New System.Windows.Forms.DataGridView
        Me.FOXNumberColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TestNumberColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PullTestDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvLotNumberRMID = New System.Windows.Forms.DataGridView
        Me.LotNumberColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberIDColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNumberBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.dgvCostTiers = New System.Windows.Forms.DataGridView
        Me.CTPartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTDivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTCostingDateColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTItemCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTCostQuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTLowerLimitColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTUpperLimitColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTTransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTReferenceNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTReferenceLineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tabUPS = New System.Windows.Forms.TabPage
        Me.dgvUPSShippingData = New System.Windows.Forms.DataGridView
        Me.PickTicketNumberColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuotedFreightChargeColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalWeightColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TrackingNumberColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoidIndicatorColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TransactionNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UPSShippingDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tabSteel = New System.Windows.Forms.TabPage
        Me.dgvSteelInPullTests = New System.Windows.Forms.DataGridView
        Me.TestNumberColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FOXNumberColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarbonColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SteelSizeColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RMIDDColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatNumberColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatSteelTypeColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatSteelSizeColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatFileNumberColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HeatFileFromHeatColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PullTestCheckiSteelToHeatBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPage8 = New System.Windows.Forms.TabPage
        Me.TabPage9 = New System.Windows.Forms.TabPage
        Me.TabPage10 = New System.Windows.Forms.TabPage
        Me.TabPage11 = New System.Windows.Forms.TabPage
        Me.TabPage12 = New System.Windows.Forms.TabPage
        Me.TabPage13 = New System.Windows.Forms.TabPage
        Me.TabPage14 = New System.Windows.Forms.TabPage
        Me.TabPage15 = New System.Windows.Forms.TabPage
        Me.TabPage16 = New System.Windows.Forms.TabPage
        Me.TabPage17 = New System.Windows.Forms.TabPage
        Me.TabPage18 = New System.Windows.Forms.TabPage
        Me.TabPage19 = New System.Windows.Forms.TabPage
        Me.TabPage20 = New System.Windows.Forms.TabPage
        Me.TabPage21 = New System.Windows.Forms.TabPage
        Me.TabPage22 = New System.Windows.Forms.TabPage
        Me.TabPage23 = New System.Windows.Forms.TabPage
        Me.TabPage24 = New System.Windows.Forms.TabPage
        Me.TabPage25 = New System.Windows.Forms.TabPage
        Me.TabPage26 = New System.Windows.Forms.TabPage
        Me.TabPage27 = New System.Windows.Forms.TabPage
        Me.TabPage28 = New System.Windows.Forms.TabPage
        Me.TabPage29 = New System.Windows.Forms.TabPage
        Me.TabPage30 = New System.Windows.Forms.TabPage
        Me.TabPage31 = New System.Windows.Forms.TabPage
        Me.TabPage32 = New System.Windows.Forms.TabPage
        Me.TabPage33 = New System.Windows.Forms.TabPage
        Me.TabPage34 = New System.Windows.Forms.TabPage
        Me.TabPage35 = New System.Windows.Forms.TabPage
        Me.cmdTimeSlipRoster = New System.Windows.Forms.Button
        Me.SalesOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
        Me.ShipmentHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
        Me.InvoiceShipmentCOSTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceShipmentCOSTableAdapter
        Me.InvoiceCompareTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceCompareTableAdapter
        Me.InvoiceShipmentTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceShipmentTableAdapter
        Me.ReturnProductHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductHeaderTableTableAdapter
        Me.ReceivingHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
        Me.TFPErrorLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TFPErrorLogTableAdapter
        Me.InvoiceProcessingBatchHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceProcessingBatchHeaderTableAdapter
        Me.ARProcessPaymentBatchTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARProcessPaymentBatchTableAdapter
        Me.InvoiceHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
        Me.LotNumberTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
        Me.PullTestDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PullTestDataTableAdapter
        Me.ReceiptOfInvoiceBatchHeaderTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchHeaderTableAdapter
        Me.APProcessPaymentBatchTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APProcessPaymentBatchTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.AssemblyHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyHeaderTableTableAdapter
        Me.AssemblyLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyLineTableTableAdapter
        Me.InventoryCostingTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryCostingTableAdapter
        Me.PurchaseOrderQuantityStatusTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderQuantityStatusTableAdapter
        Me.PurchaseOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
        Me.ARPaymentCompareTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARPaymentCompareTableAdapter
        Me.SteelYardEntryTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelYardEntryTableTableAdapter
        Me.SteelUsageTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelUsageTableTableAdapter
        Me.SteelCostingTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelCostingTableTableAdapter
        Me.UPSShippingDataTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.UPSShippingDataTableAdapter
        Me.AssemblySerialLogTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialLogTableAdapter
        Me.LotNumberTestTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTestTableAdapter
        Me.ReceivingLineQueryTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineQueryTableAdapter
        Me.PullTestCheckiSteelToHeatTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PullTestCheckiSteelToHeatTableAdapter
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.gpxARInvoiceBatch.SuspendLayout()
        Me.gpxUpdateAPInvoiceBatch.SuspendLayout()
        Me.gpxAPPaymentBatch.SuspendLayout()
        Me.gpxARPaymentBatch.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.tabUtilities.SuspendLayout()
        Me.tabU1.SuspendLayout()
        Me.GroupBox38.SuspendLayout()
        Me.GroupBox37.SuspendLayout()
        Me.GroupBox29.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.tabU2.SuspendLayout()
        Me.GroupBox42.SuspendLayout()
        Me.GroupBox40.SuspendLayout()
        Me.GroupBox39.SuspendLayout()
        Me.GroupBox28.SuspendLayout()
        Me.GroupBox27.SuspendLayout()
        Me.tabU4.SuspendLayout()
        Me.GroupBox35.SuspendLayout()
        Me.GroupBox34.SuspendLayout()
        Me.GroupBox33.SuspendLayout()
        Me.GroupBox32.SuspendLayout()
        Me.GroupBox30.SuspendLayout()
        Me.GroupBox26.SuspendLayout()
        Me.GroupBox25.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox23.SuspendLayout()
        Me.GroupBox22.SuspendLayout()
        Me.tabU5.SuspendLayout()
        Me.GroupBox31.SuspendLayout()
        Me.GroupBox21.SuspendLayout()
        Me.tabU6.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.tabU7.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox36.SuspendLayout()
        Me.tabDatagrids.SuspendLayout()
        Me.SOHeader.SuspendLayout()
        CType(Me.dgvLotNumberTest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotNumberTestBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSerialLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblySerialLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSteelCostingTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelCostingTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTWDItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPurchaseLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReceivingHeaders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReturnHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReturnProductHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvoiceShipment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceShipmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvoiceCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceCompareBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvoiceShipCOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceShipmentCOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShipmentHeaderTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSOTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.POHeader.SuspendLayout()
        CType(Me.dgvTFPErrorLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TFPErrorLogBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPurchases.SuspendLayout()
        CType(Me.dgvReceiverLineQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceivingLineQueryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOpenPOTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvARPaymentCompare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARPaymentCompareBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPOHeaders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAPPaymentBatch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APProcessPaymentBatchBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAPInvoiceBatch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReceiptOfInvoiceBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvoiceHeaderTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvARPaymentBatch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ARProcessPaymentBatchBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvARInvoiceBatch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceProcessingBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCostTiers.SuspendLayout()
        CType(Me.dgvSteelUsage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelUsageTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWireYard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SteelYardEntryTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInventoryCostingEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventoryCostingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAssemblyLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblyLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAssemblyTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssemblyHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPullTestData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PullTestDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLotNumberRMID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvCostTiers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabUPS.SuspendLayout()
        CType(Me.dgvUPSShippingData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UPSShippingDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSteel.SuspendLayout()
        CType(Me.dgvSteelInPullTests, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PullTestCheckiSteelToHeatBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
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
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Location = New System.Drawing.Point(959, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 22
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'gpxARInvoiceBatch
        '
        Me.gpxARInvoiceBatch.Controls.Add(Me.cmdViewARInvoiceBatch)
        Me.gpxARInvoiceBatch.Controls.Add(Me.cmdUpdateARInvoiceBatch)
        Me.gpxARInvoiceBatch.Location = New System.Drawing.Point(6, 18)
        Me.gpxARInvoiceBatch.Name = "gpxARInvoiceBatch"
        Me.gpxARInvoiceBatch.Size = New System.Drawing.Size(182, 80)
        Me.gpxARInvoiceBatch.TabIndex = 0
        Me.gpxARInvoiceBatch.TabStop = False
        Me.gpxARInvoiceBatch.Text = "Update AR Invoicing Batch"
        '
        'cmdViewARInvoiceBatch
        '
        Me.cmdViewARInvoiceBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewARInvoiceBatch.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewARInvoiceBatch.Name = "cmdViewARInvoiceBatch"
        Me.cmdViewARInvoiceBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewARInvoiceBatch.TabIndex = 1
        Me.cmdViewARInvoiceBatch.Text = "View"
        Me.cmdViewARInvoiceBatch.UseVisualStyleBackColor = True
        '
        'cmdUpdateARInvoiceBatch
        '
        Me.cmdUpdateARInvoiceBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateARInvoiceBatch.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateARInvoiceBatch.Name = "cmdUpdateARInvoiceBatch"
        Me.cmdUpdateARInvoiceBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateARInvoiceBatch.TabIndex = 2
        Me.cmdUpdateARInvoiceBatch.Text = "Update"
        Me.cmdUpdateARInvoiceBatch.UseVisualStyleBackColor = True
        '
        'gpxUpdateAPInvoiceBatch
        '
        Me.gpxUpdateAPInvoiceBatch.Controls.Add(Me.cmdShowAPInvoiceBatch)
        Me.gpxUpdateAPInvoiceBatch.Controls.Add(Me.cmdUpdateAPInvoiceBatch)
        Me.gpxUpdateAPInvoiceBatch.Location = New System.Drawing.Point(6, 414)
        Me.gpxUpdateAPInvoiceBatch.Name = "gpxUpdateAPInvoiceBatch"
        Me.gpxUpdateAPInvoiceBatch.Size = New System.Drawing.Size(182, 80)
        Me.gpxUpdateAPInvoiceBatch.TabIndex = 6
        Me.gpxUpdateAPInvoiceBatch.TabStop = False
        Me.gpxUpdateAPInvoiceBatch.Text = "Update AP Invoicing Batch"
        '
        'cmdShowAPInvoiceBatch
        '
        Me.cmdShowAPInvoiceBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdShowAPInvoiceBatch.Location = New System.Drawing.Point(18, 24)
        Me.cmdShowAPInvoiceBatch.Name = "cmdShowAPInvoiceBatch"
        Me.cmdShowAPInvoiceBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdShowAPInvoiceBatch.TabIndex = 7
        Me.cmdShowAPInvoiceBatch.Text = "View"
        Me.cmdShowAPInvoiceBatch.UseVisualStyleBackColor = True
        '
        'cmdUpdateAPInvoiceBatch
        '
        Me.cmdUpdateAPInvoiceBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateAPInvoiceBatch.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateAPInvoiceBatch.Name = "cmdUpdateAPInvoiceBatch"
        Me.cmdUpdateAPInvoiceBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateAPInvoiceBatch.TabIndex = 8
        Me.cmdUpdateAPInvoiceBatch.Text = "Update"
        Me.cmdUpdateAPInvoiceBatch.UseVisualStyleBackColor = True
        '
        'gpxAPPaymentBatch
        '
        Me.gpxAPPaymentBatch.Controls.Add(Me.cmdShowAPPaymentBatch)
        Me.gpxAPPaymentBatch.Controls.Add(Me.cmdUpdateAPPaymentBatch)
        Me.gpxAPPaymentBatch.Location = New System.Drawing.Point(6, 513)
        Me.gpxAPPaymentBatch.Name = "gpxAPPaymentBatch"
        Me.gpxAPPaymentBatch.Size = New System.Drawing.Size(182, 80)
        Me.gpxAPPaymentBatch.TabIndex = 9
        Me.gpxAPPaymentBatch.TabStop = False
        Me.gpxAPPaymentBatch.Text = "Update AP Payment Batch"
        '
        'cmdShowAPPaymentBatch
        '
        Me.cmdShowAPPaymentBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdShowAPPaymentBatch.Location = New System.Drawing.Point(18, 24)
        Me.cmdShowAPPaymentBatch.Name = "cmdShowAPPaymentBatch"
        Me.cmdShowAPPaymentBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdShowAPPaymentBatch.TabIndex = 10
        Me.cmdShowAPPaymentBatch.Text = "View"
        Me.cmdShowAPPaymentBatch.UseVisualStyleBackColor = True
        '
        'cmdUpdateAPPaymentBatch
        '
        Me.cmdUpdateAPPaymentBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateAPPaymentBatch.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateAPPaymentBatch.Name = "cmdUpdateAPPaymentBatch"
        Me.cmdUpdateAPPaymentBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateAPPaymentBatch.TabIndex = 11
        Me.cmdUpdateAPPaymentBatch.Text = "Update"
        Me.cmdUpdateAPPaymentBatch.UseVisualStyleBackColor = True
        '
        'gpxARPaymentBatch
        '
        Me.gpxARPaymentBatch.Controls.Add(Me.cmdShowARPaymentBatch)
        Me.gpxARPaymentBatch.Controls.Add(Me.cmdUpdateARPaymentBatch)
        Me.gpxARPaymentBatch.Location = New System.Drawing.Point(6, 117)
        Me.gpxARPaymentBatch.Name = "gpxARPaymentBatch"
        Me.gpxARPaymentBatch.Size = New System.Drawing.Size(182, 80)
        Me.gpxARPaymentBatch.TabIndex = 3
        Me.gpxARPaymentBatch.TabStop = False
        Me.gpxARPaymentBatch.Text = "Update AR Payment Batch"
        '
        'cmdShowARPaymentBatch
        '
        Me.cmdShowARPaymentBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdShowARPaymentBatch.Location = New System.Drawing.Point(14, 24)
        Me.cmdShowARPaymentBatch.Name = "cmdShowARPaymentBatch"
        Me.cmdShowARPaymentBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdShowARPaymentBatch.TabIndex = 4
        Me.cmdShowARPaymentBatch.Text = "View"
        Me.cmdShowARPaymentBatch.UseVisualStyleBackColor = True
        '
        'cmdUpdateARPaymentBatch
        '
        Me.cmdUpdateARPaymentBatch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateARPaymentBatch.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateARPaymentBatch.Name = "cmdUpdateARPaymentBatch"
        Me.cmdUpdateARPaymentBatch.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateARPaymentBatch.TabIndex = 5
        Me.cmdUpdateARPaymentBatch.Text = "Update"
        Me.cmdUpdateARPaymentBatch.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdViewInvoiceCOS)
        Me.GroupBox1.Controls.Add(Me.cmdUpdateInvoiceCOS)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 414)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Update Invoice COS"
        '
        'cmdViewInvoiceCOS
        '
        Me.cmdViewInvoiceCOS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewInvoiceCOS.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewInvoiceCOS.Name = "cmdViewInvoiceCOS"
        Me.cmdViewInvoiceCOS.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewInvoiceCOS.TabIndex = 10
        Me.cmdViewInvoiceCOS.Text = "View"
        Me.cmdViewInvoiceCOS.UseVisualStyleBackColor = True
        '
        'cmdUpdateInvoiceCOS
        '
        Me.cmdUpdateInvoiceCOS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateInvoiceCOS.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateInvoiceCOS.Name = "cmdUpdateInvoiceCOS"
        Me.cmdUpdateInvoiceCOS.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateInvoiceCOS.TabIndex = 11
        Me.cmdUpdateInvoiceCOS.Text = "Update"
        Me.cmdUpdateInvoiceCOS.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdViewReceivers)
        Me.GroupBox2.Controls.Add(Me.cmdUpdateReceivers)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 18)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Check and Close Receivers"
        '
        'cmdViewReceivers
        '
        Me.cmdViewReceivers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewReceivers.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewReceivers.Name = "cmdViewReceivers"
        Me.cmdViewReceivers.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewReceivers.TabIndex = 10
        Me.cmdViewReceivers.Text = "View"
        Me.cmdViewReceivers.UseVisualStyleBackColor = True
        '
        'cmdUpdateReceivers
        '
        Me.cmdUpdateReceivers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateReceivers.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateReceivers.Name = "cmdUpdateReceivers"
        Me.cmdUpdateReceivers.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateReceivers.TabIndex = 11
        Me.cmdUpdateReceivers.Text = "Update"
        Me.cmdUpdateReceivers.UseVisualStyleBackColor = True
        '
        'cmdDeleteTestData
        '
        Me.cmdDeleteTestData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteTestData.ForeColor = System.Drawing.Color.Black
        Me.cmdDeleteTestData.Location = New System.Drawing.Point(805, 771)
        Me.cmdDeleteTestData.Name = "cmdDeleteTestData"
        Me.cmdDeleteTestData.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteTestData.TabIndex = 35
        Me.cmdDeleteTestData.Text = "Delete TST Data"
        Me.cmdDeleteTestData.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdViewErrorLog)
        Me.GroupBox3.Controls.Add(Me.cmdClearLog)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox3.TabIndex = 36
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Show Error Log"
        '
        'cmdViewErrorLog
        '
        Me.cmdViewErrorLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewErrorLog.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewErrorLog.Name = "cmdViewErrorLog"
        Me.cmdViewErrorLog.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewErrorLog.TabIndex = 12
        Me.cmdViewErrorLog.Text = "View"
        Me.cmdViewErrorLog.UseVisualStyleBackColor = True
        '
        'cmdClearLog
        '
        Me.cmdClearLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearLog.Location = New System.Drawing.Point(95, 24)
        Me.cmdClearLog.Name = "cmdClearLog"
        Me.cmdClearLog.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearLog.TabIndex = 13
        Me.cmdClearLog.Text = "Clear Log"
        Me.cmdClearLog.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdViewInvoiceShipments)
        Me.GroupBox4.Controls.Add(Me.cmdUpdateShipmentInvoices)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 513)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox4.TabIndex = 38
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "View Invoice And Shipments"
        '
        'cmdViewInvoiceShipments
        '
        Me.cmdViewInvoiceShipments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewInvoiceShipments.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewInvoiceShipments.Name = "cmdViewInvoiceShipments"
        Me.cmdViewInvoiceShipments.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewInvoiceShipments.TabIndex = 10
        Me.cmdViewInvoiceShipments.Text = "View"
        Me.cmdViewInvoiceShipments.UseVisualStyleBackColor = True
        '
        'cmdUpdateShipmentInvoices
        '
        Me.cmdUpdateShipmentInvoices.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateShipmentInvoices.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateShipmentInvoices.Name = "cmdUpdateShipmentInvoices"
        Me.cmdUpdateShipmentInvoices.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateShipmentInvoices.TabIndex = 11
        Me.cmdUpdateShipmentInvoices.Text = "Update"
        Me.cmdUpdateShipmentInvoices.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmdViewSO)
        Me.GroupBox5.Controls.Add(Me.cmdUpdateSO)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 18)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox5.TabIndex = 40
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "View Sales Orders"
        '
        'cmdViewSO
        '
        Me.cmdViewSO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewSO.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewSO.Name = "cmdViewSO"
        Me.cmdViewSO.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewSO.TabIndex = 10
        Me.cmdViewSO.Text = "View"
        Me.cmdViewSO.UseVisualStyleBackColor = True
        '
        'cmdUpdateSO
        '
        Me.cmdUpdateSO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateSO.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateSO.Name = "cmdUpdateSO"
        Me.cmdUpdateSO.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateSO.TabIndex = 11
        Me.cmdUpdateSO.Text = "Update"
        Me.cmdUpdateSO.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cmdViewShipments)
        Me.GroupBox6.Controls.Add(Me.cmdUpdateShipments)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 117)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox6.TabIndex = 42
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "View Shipments"
        '
        'cmdViewShipments
        '
        Me.cmdViewShipments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewShipments.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewShipments.Name = "cmdViewShipments"
        Me.cmdViewShipments.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewShipments.TabIndex = 10
        Me.cmdViewShipments.Text = "View"
        Me.cmdViewShipments.UseVisualStyleBackColor = True
        '
        'cmdUpdateShipments
        '
        Me.cmdUpdateShipments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateShipments.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateShipments.Name = "cmdUpdateShipments"
        Me.cmdUpdateShipments.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateShipments.TabIndex = 11
        Me.cmdUpdateShipments.Text = "Update"
        Me.cmdUpdateShipments.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cmdViewCOSalesOrders)
        Me.GroupBox7.Controls.Add(Me.cmdUpdateCOSSalesOrders)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 216)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox7.TabIndex = 44
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Update COS Sales Orders"
        '
        'cmdViewCOSalesOrders
        '
        Me.cmdViewCOSalesOrders.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewCOSalesOrders.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewCOSalesOrders.Name = "cmdViewCOSalesOrders"
        Me.cmdViewCOSalesOrders.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewCOSalesOrders.TabIndex = 10
        Me.cmdViewCOSalesOrders.Text = "View"
        Me.cmdViewCOSalesOrders.UseVisualStyleBackColor = True
        '
        'cmdUpdateCOSSalesOrders
        '
        Me.cmdUpdateCOSSalesOrders.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateCOSSalesOrders.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateCOSSalesOrders.Name = "cmdUpdateCOSSalesOrders"
        Me.cmdUpdateCOSSalesOrders.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateCOSSalesOrders.TabIndex = 11
        Me.cmdUpdateCOSSalesOrders.Text = "Update"
        Me.cmdUpdateCOSSalesOrders.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.cmdViewCOSFromShipment)
        Me.GroupBox8.Controls.Add(Me.cmdUpdateCOSFromShipment)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 315)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox8.TabIndex = 45
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Update SO COS From Shipment"
        '
        'cmdViewCOSFromShipment
        '
        Me.cmdViewCOSFromShipment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewCOSFromShipment.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewCOSFromShipment.Name = "cmdViewCOSFromShipment"
        Me.cmdViewCOSFromShipment.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewCOSFromShipment.TabIndex = 10
        Me.cmdViewCOSFromShipment.Text = "View"
        Me.cmdViewCOSFromShipment.UseVisualStyleBackColor = True
        '
        'cmdUpdateCOSFromShipment
        '
        Me.cmdUpdateCOSFromShipment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateCOSFromShipment.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateCOSFromShipment.Name = "cmdUpdateCOSFromShipment"
        Me.cmdUpdateCOSFromShipment.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateCOSFromShipment.TabIndex = 11
        Me.cmdUpdateCOSFromShipment.Text = "Update"
        Me.cmdUpdateCOSFromShipment.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.cmdViewVoucherlines)
        Me.GroupBox11.Controls.Add(Me.cmdUpdateVoucherLines)
        Me.GroupBox11.Location = New System.Drawing.Point(6, 612)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox11.TabIndex = 52
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Update Voucher Line Division"
        '
        'cmdViewVoucherlines
        '
        Me.cmdViewVoucherlines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewVoucherlines.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewVoucherlines.Name = "cmdViewVoucherlines"
        Me.cmdViewVoucherlines.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewVoucherlines.TabIndex = 10
        Me.cmdViewVoucherlines.Text = "View"
        Me.cmdViewVoucherlines.UseVisualStyleBackColor = True
        '
        'cmdUpdateVoucherLines
        '
        Me.cmdUpdateVoucherLines.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateVoucherLines.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateVoucherLines.Name = "cmdUpdateVoucherLines"
        Me.cmdUpdateVoucherLines.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateVoucherLines.TabIndex = 11
        Me.cmdUpdateVoucherLines.Text = "Update"
        Me.cmdUpdateVoucherLines.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.cmdViewLot)
        Me.GroupBox12.Controls.Add(Me.cmdUpdateLot)
        Me.GroupBox12.Location = New System.Drawing.Point(6, 190)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox12.TabIndex = 53
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Update Lot Number Table"
        '
        'cmdViewLot
        '
        Me.cmdViewLot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewLot.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewLot.Name = "cmdViewLot"
        Me.cmdViewLot.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewLot.TabIndex = 10
        Me.cmdViewLot.Text = "View"
        Me.cmdViewLot.UseVisualStyleBackColor = True
        '
        'cmdUpdateLot
        '
        Me.cmdUpdateLot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateLot.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateLot.Name = "cmdUpdateLot"
        Me.cmdUpdateLot.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateLot.TabIndex = 11
        Me.cmdUpdateLot.Text = "Update"
        Me.cmdUpdateLot.UseVisualStyleBackColor = True
        '
        'cmdClearLocks
        '
        Me.cmdClearLocks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearLocks.ForeColor = System.Drawing.Color.Black
        Me.cmdClearLocks.Location = New System.Drawing.Point(882, 771)
        Me.cmdClearLocks.Name = "cmdClearLocks"
        Me.cmdClearLocks.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearLocks.TabIndex = 54
        Me.cmdClearLocks.Text = "Clear All Locks"
        Me.cmdClearLocks.UseVisualStyleBackColor = True
        '
        'tabUtilities
        '
        Me.tabUtilities.Controls.Add(Me.tabU1)
        Me.tabUtilities.Controls.Add(Me.tabU2)
        Me.tabUtilities.Controls.Add(Me.tabU4)
        Me.tabUtilities.Controls.Add(Me.tabU5)
        Me.tabUtilities.Controls.Add(Me.tabU6)
        Me.tabUtilities.Controls.Add(Me.tabU3)
        Me.tabUtilities.Controls.Add(Me.tabU7)
        Me.tabUtilities.Location = New System.Drawing.Point(12, 39)
        Me.tabUtilities.Name = "tabUtilities"
        Me.tabUtilities.SelectedIndex = 0
        Me.tabUtilities.Size = New System.Drawing.Size(386, 722)
        Me.tabUtilities.TabIndex = 65
        '
        'tabU1
        '
        Me.tabU1.Controls.Add(Me.GroupBox38)
        Me.tabU1.Controls.Add(Me.GroupBox37)
        Me.tabU1.Controls.Add(Me.GroupBox29)
        Me.tabU1.Controls.Add(Me.GroupBox20)
        Me.tabU1.Controls.Add(Me.GroupBox1)
        Me.tabU1.Controls.Add(Me.GroupBox4)
        Me.tabU1.Controls.Add(Me.GroupBox8)
        Me.tabU1.Controls.Add(Me.GroupBox7)
        Me.tabU1.Controls.Add(Me.GroupBox6)
        Me.tabU1.Controls.Add(Me.GroupBox5)
        Me.tabU1.Location = New System.Drawing.Point(4, 22)
        Me.tabU1.Name = "tabU1"
        Me.tabU1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabU1.Size = New System.Drawing.Size(378, 696)
        Me.tabU1.TabIndex = 0
        Me.tabU1.Text = "Sales"
        Me.tabU1.UseVisualStyleBackColor = True
        '
        'GroupBox38
        '
        Me.GroupBox38.Controls.Add(Me.cmdViewSerialLog)
        Me.GroupBox38.Controls.Add(Me.cmdUpdateSerialLog)
        Me.GroupBox38.Location = New System.Drawing.Point(194, 217)
        Me.GroupBox38.Name = "GroupBox38"
        Me.GroupBox38.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox38.TabIndex = 68
        Me.GroupBox38.TabStop = False
        Me.GroupBox38.Text = "View Serial Log Data"
        '
        'cmdViewSerialLog
        '
        Me.cmdViewSerialLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewSerialLog.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewSerialLog.Name = "cmdViewSerialLog"
        Me.cmdViewSerialLog.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewSerialLog.TabIndex = 10
        Me.cmdViewSerialLog.Text = "View"
        Me.cmdViewSerialLog.UseVisualStyleBackColor = True
        '
        'cmdUpdateSerialLog
        '
        Me.cmdUpdateSerialLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateSerialLog.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateSerialLog.Name = "cmdUpdateSerialLog"
        Me.cmdUpdateSerialLog.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateSerialLog.TabIndex = 11
        Me.cmdUpdateSerialLog.Text = "Update"
        Me.cmdUpdateSerialLog.UseVisualStyleBackColor = True
        '
        'GroupBox37
        '
        Me.GroupBox37.Controls.Add(Me.cmdViewUPS)
        Me.GroupBox37.Controls.Add(Me.cmdDeleteUPS)
        Me.GroupBox37.Location = New System.Drawing.Point(196, 117)
        Me.GroupBox37.Name = "GroupBox37"
        Me.GroupBox37.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox37.TabIndex = 67
        Me.GroupBox37.TabStop = False
        Me.GroupBox37.Text = "View UPS Exported Data"
        '
        'cmdViewUPS
        '
        Me.cmdViewUPS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewUPS.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewUPS.Name = "cmdViewUPS"
        Me.cmdViewUPS.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewUPS.TabIndex = 10
        Me.cmdViewUPS.Text = "View"
        Me.cmdViewUPS.UseVisualStyleBackColor = True
        '
        'cmdDeleteUPS
        '
        Me.cmdDeleteUPS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDeleteUPS.Location = New System.Drawing.Point(95, 24)
        Me.cmdDeleteUPS.Name = "cmdDeleteUPS"
        Me.cmdDeleteUPS.Size = New System.Drawing.Size(71, 40)
        Me.cmdDeleteUPS.TabIndex = 11
        Me.cmdDeleteUPS.Text = "Delete"
        Me.cmdDeleteUPS.UseVisualStyleBackColor = True
        '
        'GroupBox29
        '
        Me.GroupBox29.Controls.Add(Me.cmdViewDropShipSO)
        Me.GroupBox29.Controls.Add(Me.cmdUpdateDropShipSO)
        Me.GroupBox29.Location = New System.Drawing.Point(196, 18)
        Me.GroupBox29.Name = "GroupBox29"
        Me.GroupBox29.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox29.TabIndex = 66
        Me.GroupBox29.TabStop = False
        Me.GroupBox29.Text = "View Drop Ship SO"
        '
        'cmdViewDropShipSO
        '
        Me.cmdViewDropShipSO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewDropShipSO.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewDropShipSO.Name = "cmdViewDropShipSO"
        Me.cmdViewDropShipSO.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewDropShipSO.TabIndex = 10
        Me.cmdViewDropShipSO.Text = "View"
        Me.cmdViewDropShipSO.UseVisualStyleBackColor = True
        '
        'cmdUpdateDropShipSO
        '
        Me.cmdUpdateDropShipSO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateDropShipSO.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateDropShipSO.Name = "cmdUpdateDropShipSO"
        Me.cmdUpdateDropShipSO.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateDropShipSO.TabIndex = 11
        Me.cmdUpdateDropShipSO.Text = "Update"
        Me.cmdUpdateDropShipSO.UseVisualStyleBackColor = True
        '
        'GroupBox20
        '
        Me.GroupBox20.Controls.Add(Me.cmdUpdateReturnCOS)
        Me.GroupBox20.Controls.Add(Me.cmdViewReturnHeader)
        Me.GroupBox20.Location = New System.Drawing.Point(6, 616)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox20.TabIndex = 65
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Update Total COS on Returns"
        '
        'cmdUpdateReturnCOS
        '
        Me.cmdUpdateReturnCOS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateReturnCOS.ForeColor = System.Drawing.Color.Black
        Me.cmdUpdateReturnCOS.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateReturnCOS.Name = "cmdUpdateReturnCOS"
        Me.cmdUpdateReturnCOS.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateReturnCOS.TabIndex = 51
        Me.cmdUpdateReturnCOS.Text = "Update"
        Me.cmdUpdateReturnCOS.UseVisualStyleBackColor = True
        '
        'cmdViewReturnHeader
        '
        Me.cmdViewReturnHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewReturnHeader.ForeColor = System.Drawing.Color.Black
        Me.cmdViewReturnHeader.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewReturnHeader.Name = "cmdViewReturnHeader"
        Me.cmdViewReturnHeader.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewReturnHeader.TabIndex = 55
        Me.cmdViewReturnHeader.Text = "View"
        Me.cmdViewReturnHeader.UseVisualStyleBackColor = True
        '
        'tabU2
        '
        Me.tabU2.Controls.Add(Me.GroupBox42)
        Me.tabU2.Controls.Add(Me.GroupBox40)
        Me.tabU2.Controls.Add(Me.GroupBox39)
        Me.tabU2.Controls.Add(Me.GroupBox28)
        Me.tabU2.Controls.Add(Me.GroupBox27)
        Me.tabU2.Controls.Add(Me.GroupBox2)
        Me.tabU2.Location = New System.Drawing.Point(4, 22)
        Me.tabU2.Name = "tabU2"
        Me.tabU2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabU2.Size = New System.Drawing.Size(378, 696)
        Me.tabU2.TabIndex = 1
        Me.tabU2.Text = "Purchase"
        Me.tabU2.UseVisualStyleBackColor = True
        '
        'GroupBox42
        '
        Me.GroupBox42.Controls.Add(Me.cmdCloseReceiversForAP)
        Me.GroupBox42.Controls.Add(Me.cmdUpdateReceiversForAP)
        Me.GroupBox42.Location = New System.Drawing.Point(6, 380)
        Me.GroupBox42.Name = "GroupBox42"
        Me.GroupBox42.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox42.TabIndex = 38
        Me.GroupBox42.TabStop = False
        Me.GroupBox42.Text = "Close Receivers for A/P"
        '
        'cmdCloseReceiversForAP
        '
        Me.cmdCloseReceiversForAP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCloseReceiversForAP.Location = New System.Drawing.Point(18, 24)
        Me.cmdCloseReceiversForAP.Name = "cmdCloseReceiversForAP"
        Me.cmdCloseReceiversForAP.Size = New System.Drawing.Size(71, 40)
        Me.cmdCloseReceiversForAP.TabIndex = 10
        Me.cmdCloseReceiversForAP.Text = "View"
        Me.cmdCloseReceiversForAP.UseVisualStyleBackColor = True
        '
        'cmdUpdateReceiversForAP
        '
        Me.cmdUpdateReceiversForAP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateReceiversForAP.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateReceiversForAP.Name = "cmdUpdateReceiversForAP"
        Me.cmdUpdateReceiversForAP.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateReceiversForAP.TabIndex = 11
        Me.cmdUpdateReceiversForAP.Text = "Update"
        Me.cmdUpdateReceiversForAP.UseVisualStyleBackColor = True
        '
        'GroupBox40
        '
        Me.GroupBox40.Controls.Add(Me.cmdViewLotFromFox)
        Me.GroupBox40.Controls.Add(Me.cmdUpdateLotFromFox)
        Me.GroupBox40.Location = New System.Drawing.Point(194, 18)
        Me.GroupBox40.Name = "GroupBox40"
        Me.GroupBox40.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox40.TabIndex = 37
        Me.GroupBox40.TabStop = False
        Me.GroupBox40.Text = "Update Lot From FOX"
        '
        'cmdViewLotFromFox
        '
        Me.cmdViewLotFromFox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewLotFromFox.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewLotFromFox.Name = "cmdViewLotFromFox"
        Me.cmdViewLotFromFox.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewLotFromFox.TabIndex = 10
        Me.cmdViewLotFromFox.Text = "View"
        Me.cmdViewLotFromFox.UseVisualStyleBackColor = True
        '
        'cmdUpdateLotFromFox
        '
        Me.cmdUpdateLotFromFox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateLotFromFox.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdateLotFromFox.Name = "cmdUpdateLotFromFox"
        Me.cmdUpdateLotFromFox.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateLotFromFox.TabIndex = 11
        Me.cmdUpdateLotFromFox.Text = "Update"
        Me.cmdUpdateLotFromFox.UseVisualStyleBackColor = True
        '
        'GroupBox39
        '
        Me.GroupBox39.Controls.Add(Me.cmdViewOpenPO)
        Me.GroupBox39.Controls.Add(Me.cmdCloseOpenPOs)
        Me.GroupBox39.Location = New System.Drawing.Point(6, 287)
        Me.GroupBox39.Name = "GroupBox39"
        Me.GroupBox39.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox39.TabIndex = 36
        Me.GroupBox39.TabStop = False
        Me.GroupBox39.Text = "Update PO Status"
        '
        'cmdViewOpenPO
        '
        Me.cmdViewOpenPO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewOpenPO.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewOpenPO.Name = "cmdViewOpenPO"
        Me.cmdViewOpenPO.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewOpenPO.TabIndex = 10
        Me.cmdViewOpenPO.Text = "View"
        Me.cmdViewOpenPO.UseVisualStyleBackColor = True
        '
        'cmdCloseOpenPOs
        '
        Me.cmdCloseOpenPOs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCloseOpenPOs.Location = New System.Drawing.Point(95, 24)
        Me.cmdCloseOpenPOs.Name = "cmdCloseOpenPOs"
        Me.cmdCloseOpenPOs.Size = New System.Drawing.Size(71, 40)
        Me.cmdCloseOpenPOs.TabIndex = 11
        Me.cmdCloseOpenPOs.Text = "Update"
        Me.cmdCloseOpenPOs.UseVisualStyleBackColor = True
        '
        'GroupBox28
        '
        Me.GroupBox28.Controls.Add(Me.cmdViewPOHeadersAddress)
        Me.GroupBox28.Controls.Add(Me.cmdUpdatePOAddress)
        Me.GroupBox28.Location = New System.Drawing.Point(6, 190)
        Me.GroupBox28.Name = "GroupBox28"
        Me.GroupBox28.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox28.TabIndex = 35
        Me.GroupBox28.TabStop = False
        Me.GroupBox28.Text = "Update Ship Address in PO"
        '
        'cmdViewPOHeadersAddress
        '
        Me.cmdViewPOHeadersAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPOHeadersAddress.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewPOHeadersAddress.Name = "cmdViewPOHeadersAddress"
        Me.cmdViewPOHeadersAddress.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPOHeadersAddress.TabIndex = 10
        Me.cmdViewPOHeadersAddress.Text = "View"
        Me.cmdViewPOHeadersAddress.UseVisualStyleBackColor = True
        '
        'cmdUpdatePOAddress
        '
        Me.cmdUpdatePOAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdatePOAddress.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdatePOAddress.Name = "cmdUpdatePOAddress"
        Me.cmdUpdatePOAddress.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdatePOAddress.TabIndex = 11
        Me.cmdUpdatePOAddress.Text = "Update"
        Me.cmdUpdatePOAddress.UseVisualStyleBackColor = True
        '
        'GroupBox27
        '
        Me.GroupBox27.Controls.Add(Me.cmdViewPOLineStatus)
        Me.GroupBox27.Controls.Add(Me.cmdUpdatePOLineStatus)
        Me.GroupBox27.Location = New System.Drawing.Point(6, 104)
        Me.GroupBox27.Name = "GroupBox27"
        Me.GroupBox27.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox27.TabIndex = 34
        Me.GroupBox27.TabStop = False
        Me.GroupBox27.Text = "Update PO Line Status"
        '
        'cmdViewPOLineStatus
        '
        Me.cmdViewPOLineStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPOLineStatus.Location = New System.Drawing.Point(18, 24)
        Me.cmdViewPOLineStatus.Name = "cmdViewPOLineStatus"
        Me.cmdViewPOLineStatus.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPOLineStatus.TabIndex = 10
        Me.cmdViewPOLineStatus.Text = "View"
        Me.cmdViewPOLineStatus.UseVisualStyleBackColor = True
        '
        'cmdUpdatePOLineStatus
        '
        Me.cmdUpdatePOLineStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdatePOLineStatus.Location = New System.Drawing.Point(95, 24)
        Me.cmdUpdatePOLineStatus.Name = "cmdUpdatePOLineStatus"
        Me.cmdUpdatePOLineStatus.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdatePOLineStatus.TabIndex = 11
        Me.cmdUpdatePOLineStatus.Text = "Update"
        Me.cmdUpdatePOLineStatus.UseVisualStyleBackColor = True
        '
        'tabU4
        '
        Me.tabU4.Controls.Add(Me.GroupBox35)
        Me.tabU4.Controls.Add(Me.GroupBox34)
        Me.tabU4.Controls.Add(Me.GroupBox33)
        Me.tabU4.Controls.Add(Me.GroupBox32)
        Me.tabU4.Controls.Add(Me.GroupBox30)
        Me.tabU4.Controls.Add(Me.GroupBox26)
        Me.tabU4.Controls.Add(Me.GroupBox25)
        Me.tabU4.Controls.Add(Me.GroupBox19)
        Me.tabU4.Controls.Add(Me.GroupBox17)
        Me.tabU4.Controls.Add(Me.GroupBox14)
        Me.tabU4.Controls.Add(Me.GroupBox13)
        Me.tabU4.Controls.Add(Me.GroupBox10)
        Me.tabU4.Controls.Add(Me.GroupBox9)
        Me.tabU4.Controls.Add(Me.GroupBox23)
        Me.tabU4.Controls.Add(Me.GroupBox12)
        Me.tabU4.Controls.Add(Me.GroupBox22)
        Me.tabU4.Location = New System.Drawing.Point(4, 22)
        Me.tabU4.Name = "tabU4"
        Me.tabU4.Size = New System.Drawing.Size(378, 696)
        Me.tabU4.TabIndex = 3
        Me.tabU4.Text = "Inventory"
        Me.tabU4.UseVisualStyleBackColor = True
        '
        'GroupBox35
        '
        Me.GroupBox35.Controls.Add(Me.cmdViewBuildTiers)
        Me.GroupBox35.Controls.Add(Me.cmdUpdateBuildTiers)
        Me.GroupBox35.Location = New System.Drawing.Point(194, 616)
        Me.GroupBox35.Name = "GroupBox35"
        Me.GroupBox35.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox35.TabIndex = 81
        Me.GroupBox35.TabStop = False
        Me.GroupBox35.Text = "Update Build  # in Cost Tiers"
        '
        'cmdViewBuildTiers
        '
        Me.cmdViewBuildTiers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewBuildTiers.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewBuildTiers.Name = "cmdViewBuildTiers"
        Me.cmdViewBuildTiers.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewBuildTiers.TabIndex = 10
        Me.cmdViewBuildTiers.Text = "View"
        Me.cmdViewBuildTiers.UseVisualStyleBackColor = True
        '
        'cmdUpdateBuildTiers
        '
        Me.cmdUpdateBuildTiers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateBuildTiers.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateBuildTiers.Name = "cmdUpdateBuildTiers"
        Me.cmdUpdateBuildTiers.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateBuildTiers.TabIndex = 11
        Me.cmdUpdateBuildTiers.Text = "Update"
        Me.cmdUpdateBuildTiers.UseVisualStyleBackColor = True
        '
        'GroupBox34
        '
        Me.GroupBox34.Controls.Add(Me.Button1)
        Me.GroupBox34.Controls.Add(Me.Button2)
        Me.GroupBox34.Location = New System.Drawing.Point(193, 534)
        Me.GroupBox34.Name = "GroupBox34"
        Me.GroupBox34.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox34.TabIndex = 80
        Me.GroupBox34.TabStop = False
        Me.GroupBox34.Text = "Update Steel Cost Usage"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(14, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 40)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "View"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(91, 24)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 40)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Update"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox33
        '
        Me.GroupBox33.Controls.Add(Me.cmdViewSteelUsage)
        Me.GroupBox33.Controls.Add(Me.cmdUpdateSteelUsage)
        Me.GroupBox33.Location = New System.Drawing.Point(193, 448)
        Me.GroupBox33.Name = "GroupBox33"
        Me.GroupBox33.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox33.TabIndex = 79
        Me.GroupBox33.TabStop = False
        Me.GroupBox33.Text = "Update Steel Cost Usage"
        '
        'cmdViewSteelUsage
        '
        Me.cmdViewSteelUsage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewSteelUsage.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewSteelUsage.Name = "cmdViewSteelUsage"
        Me.cmdViewSteelUsage.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewSteelUsage.TabIndex = 10
        Me.cmdViewSteelUsage.Text = "View"
        Me.cmdViewSteelUsage.UseVisualStyleBackColor = True
        '
        'cmdUpdateSteelUsage
        '
        Me.cmdUpdateSteelUsage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateSteelUsage.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateSteelUsage.Name = "cmdUpdateSteelUsage"
        Me.cmdUpdateSteelUsage.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateSteelUsage.TabIndex = 11
        Me.cmdUpdateSteelUsage.Text = "Update"
        Me.cmdUpdateSteelUsage.UseVisualStyleBackColor = True
        '
        'GroupBox32
        '
        Me.GroupBox32.Controls.Add(Me.cmdViewWireYard)
        Me.GroupBox32.Controls.Add(Me.cmdUpdateWireYard)
        Me.GroupBox32.Location = New System.Drawing.Point(193, 362)
        Me.GroupBox32.Name = "GroupBox32"
        Me.GroupBox32.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox32.TabIndex = 78
        Me.GroupBox32.TabStop = False
        Me.GroupBox32.Text = "Update Steel Cost Wire Yard"
        '
        'cmdViewWireYard
        '
        Me.cmdViewWireYard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewWireYard.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewWireYard.Name = "cmdViewWireYard"
        Me.cmdViewWireYard.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewWireYard.TabIndex = 10
        Me.cmdViewWireYard.Text = "View"
        Me.cmdViewWireYard.UseVisualStyleBackColor = True
        '
        'cmdUpdateWireYard
        '
        Me.cmdUpdateWireYard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateWireYard.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateWireYard.Name = "cmdUpdateWireYard"
        Me.cmdUpdateWireYard.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateWireYard.TabIndex = 11
        Me.cmdUpdateWireYard.Text = "Update"
        Me.cmdUpdateWireYard.UseVisualStyleBackColor = True
        '
        'GroupBox30
        '
        Me.GroupBox30.Controls.Add(Me.cmdViewItemListTWD)
        Me.GroupBox30.Controls.Add(Me.cmdUpdateItemListTWD)
        Me.GroupBox30.Location = New System.Drawing.Point(6, 620)
        Me.GroupBox30.Name = "GroupBox30"
        Me.GroupBox30.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox30.TabIndex = 77
        Me.GroupBox30.TabStop = False
        Me.GroupBox30.Text = "Update Item List to TWD"
        '
        'cmdViewItemListTWD
        '
        Me.cmdViewItemListTWD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewItemListTWD.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewItemListTWD.Name = "cmdViewItemListTWD"
        Me.cmdViewItemListTWD.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewItemListTWD.TabIndex = 10
        Me.cmdViewItemListTWD.Text = "View"
        Me.cmdViewItemListTWD.UseVisualStyleBackColor = True
        '
        'cmdUpdateItemListTWD
        '
        Me.cmdUpdateItemListTWD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateItemListTWD.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateItemListTWD.Name = "cmdUpdateItemListTWD"
        Me.cmdUpdateItemListTWD.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateItemListTWD.TabIndex = 11
        Me.cmdUpdateItemListTWD.Text = "Update"
        Me.cmdUpdateItemListTWD.UseVisualStyleBackColor = True
        '
        'GroupBox26
        '
        Me.GroupBox26.Controls.Add(Me.cmdViewReceiverTiers)
        Me.GroupBox26.Controls.Add(Me.cmdUpdateReceiverTiers)
        Me.GroupBox26.Location = New System.Drawing.Point(194, 276)
        Me.GroupBox26.Name = "GroupBox26"
        Me.GroupBox26.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox26.TabIndex = 76
        Me.GroupBox26.TabStop = False
        Me.GroupBox26.Text = "Update Rec.  # in Cost Tiers"
        '
        'cmdViewReceiverTiers
        '
        Me.cmdViewReceiverTiers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewReceiverTiers.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewReceiverTiers.Name = "cmdViewReceiverTiers"
        Me.cmdViewReceiverTiers.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewReceiverTiers.TabIndex = 10
        Me.cmdViewReceiverTiers.Text = "View"
        Me.cmdViewReceiverTiers.UseVisualStyleBackColor = True
        '
        'cmdUpdateReceiverTiers
        '
        Me.cmdUpdateReceiverTiers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateReceiverTiers.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateReceiverTiers.Name = "cmdUpdateReceiverTiers"
        Me.cmdUpdateReceiverTiers.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateReceiverTiers.TabIndex = 11
        Me.cmdUpdateReceiverTiers.Text = "Update"
        Me.cmdUpdateReceiverTiers.UseVisualStyleBackColor = True
        '
        'GroupBox25
        '
        Me.GroupBox25.Controls.Add(Me.cmdViewVendorReturns)
        Me.GroupBox25.Controls.Add(Me.cmdUpdateVendorReturnsTiers)
        Me.GroupBox25.Location = New System.Drawing.Point(193, 190)
        Me.GroupBox25.Name = "GroupBox25"
        Me.GroupBox25.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox25.TabIndex = 75
        Me.GroupBox25.TabStop = False
        Me.GroupBox25.Text = "Update Vendor Ret.  # in Cost Tiers"
        '
        'cmdViewVendorReturns
        '
        Me.cmdViewVendorReturns.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewVendorReturns.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewVendorReturns.Name = "cmdViewVendorReturns"
        Me.cmdViewVendorReturns.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewVendorReturns.TabIndex = 10
        Me.cmdViewVendorReturns.Text = "View"
        Me.cmdViewVendorReturns.UseVisualStyleBackColor = True
        '
        'cmdUpdateVendorReturnsTiers
        '
        Me.cmdUpdateVendorReturnsTiers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateVendorReturnsTiers.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateVendorReturnsTiers.Name = "cmdUpdateVendorReturnsTiers"
        Me.cmdUpdateVendorReturnsTiers.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateVendorReturnsTiers.TabIndex = 11
        Me.cmdUpdateVendorReturnsTiers.Text = "Update"
        Me.cmdUpdateVendorReturnsTiers.UseVisualStyleBackColor = True
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.cmdViewAdjustmentTiers)
        Me.GroupBox19.Controls.Add(Me.cmdUpdateAdjustmentTiers)
        Me.GroupBox19.Location = New System.Drawing.Point(194, 104)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox19.TabIndex = 74
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Update Adl.  # in Cost Tiers"
        '
        'cmdViewAdjustmentTiers
        '
        Me.cmdViewAdjustmentTiers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewAdjustmentTiers.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewAdjustmentTiers.Name = "cmdViewAdjustmentTiers"
        Me.cmdViewAdjustmentTiers.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewAdjustmentTiers.TabIndex = 10
        Me.cmdViewAdjustmentTiers.Text = "View"
        Me.cmdViewAdjustmentTiers.UseVisualStyleBackColor = True
        '
        'cmdUpdateAdjustmentTiers
        '
        Me.cmdUpdateAdjustmentTiers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateAdjustmentTiers.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateAdjustmentTiers.Name = "cmdUpdateAdjustmentTiers"
        Me.cmdUpdateAdjustmentTiers.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateAdjustmentTiers.TabIndex = 11
        Me.cmdUpdateAdjustmentTiers.Text = "Update"
        Me.cmdUpdateAdjustmentTiers.UseVisualStyleBackColor = True
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.cmdViewCostTierReturns)
        Me.GroupBox17.Controls.Add(Me.cmdUpdateCostTierReturns)
        Me.GroupBox17.Location = New System.Drawing.Point(194, 18)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox17.TabIndex = 73
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "Update Return # in Cost Tiers"
        '
        'cmdViewCostTierReturns
        '
        Me.cmdViewCostTierReturns.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewCostTierReturns.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewCostTierReturns.Name = "cmdViewCostTierReturns"
        Me.cmdViewCostTierReturns.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewCostTierReturns.TabIndex = 10
        Me.cmdViewCostTierReturns.Text = "View"
        Me.cmdViewCostTierReturns.UseVisualStyleBackColor = True
        '
        'cmdUpdateCostTierReturns
        '
        Me.cmdUpdateCostTierReturns.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateCostTierReturns.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateCostTierReturns.Name = "cmdUpdateCostTierReturns"
        Me.cmdUpdateCostTierReturns.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateCostTierReturns.TabIndex = 11
        Me.cmdUpdateCostTierReturns.Text = "Update"
        Me.cmdUpdateCostTierReturns.UseVisualStyleBackColor = True
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.cmdViewAssemblyLineCost)
        Me.GroupBox14.Controls.Add(Me.cmdUpdateAssemblyLineCost)
        Me.GroupBox14.Location = New System.Drawing.Point(6, 534)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox14.TabIndex = 72
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Update Assembly Line Cost"
        '
        'cmdViewAssemblyLineCost
        '
        Me.cmdViewAssemblyLineCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewAssemblyLineCost.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewAssemblyLineCost.Name = "cmdViewAssemblyLineCost"
        Me.cmdViewAssemblyLineCost.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewAssemblyLineCost.TabIndex = 10
        Me.cmdViewAssemblyLineCost.Text = "View"
        Me.cmdViewAssemblyLineCost.UseVisualStyleBackColor = True
        '
        'cmdUpdateAssemblyLineCost
        '
        Me.cmdUpdateAssemblyLineCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateAssemblyLineCost.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateAssemblyLineCost.Name = "cmdUpdateAssemblyLineCost"
        Me.cmdUpdateAssemblyLineCost.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateAssemblyLineCost.TabIndex = 11
        Me.cmdUpdateAssemblyLineCost.Text = "Update"
        Me.cmdUpdateAssemblyLineCost.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.cmdViewAssemblyLineNumbers)
        Me.GroupBox13.Controls.Add(Me.cmdUpdateAssemblyLineNumbers)
        Me.GroupBox13.Location = New System.Drawing.Point(6, 448)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox13.TabIndex = 71
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Update Assembly Line #'s"
        '
        'cmdViewAssemblyLineNumbers
        '
        Me.cmdViewAssemblyLineNumbers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewAssemblyLineNumbers.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewAssemblyLineNumbers.Name = "cmdViewAssemblyLineNumbers"
        Me.cmdViewAssemblyLineNumbers.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewAssemblyLineNumbers.TabIndex = 10
        Me.cmdViewAssemblyLineNumbers.Text = "View"
        Me.cmdViewAssemblyLineNumbers.UseVisualStyleBackColor = True
        '
        'cmdUpdateAssemblyLineNumbers
        '
        Me.cmdUpdateAssemblyLineNumbers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateAssemblyLineNumbers.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateAssemblyLineNumbers.Name = "cmdUpdateAssemblyLineNumbers"
        Me.cmdUpdateAssemblyLineNumbers.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateAssemblyLineNumbers.TabIndex = 11
        Me.cmdUpdateAssemblyLineNumbers.Text = "Update"
        Me.cmdUpdateAssemblyLineNumbers.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.cmdViewAssembly)
        Me.GroupBox10.Controls.Add(Me.cmdUpdateAssemblyCost)
        Me.GroupBox10.Location = New System.Drawing.Point(6, 362)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox10.TabIndex = 70
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Update Assembly Cost"
        '
        'cmdViewAssembly
        '
        Me.cmdViewAssembly.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewAssembly.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewAssembly.Name = "cmdViewAssembly"
        Me.cmdViewAssembly.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewAssembly.TabIndex = 10
        Me.cmdViewAssembly.Text = "View"
        Me.cmdViewAssembly.UseVisualStyleBackColor = True
        '
        'cmdUpdateAssemblyCost
        '
        Me.cmdUpdateAssemblyCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateAssemblyCost.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateAssemblyCost.Name = "cmdUpdateAssemblyCost"
        Me.cmdUpdateAssemblyCost.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateAssemblyCost.TabIndex = 11
        Me.cmdUpdateAssemblyCost.Text = "Update"
        Me.cmdUpdateAssemblyCost.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.cmdViewItemList)
        Me.GroupBox9.Controls.Add(Me.cmdUpdateItemList)
        Me.GroupBox9.Location = New System.Drawing.Point(6, 276)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox9.TabIndex = 69
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Update Standard Cost"
        '
        'cmdViewItemList
        '
        Me.cmdViewItemList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewItemList.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewItemList.Name = "cmdViewItemList"
        Me.cmdViewItemList.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewItemList.TabIndex = 10
        Me.cmdViewItemList.Text = "View"
        Me.cmdViewItemList.UseVisualStyleBackColor = True
        '
        'cmdUpdateItemList
        '
        Me.cmdUpdateItemList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateItemList.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateItemList.Name = "cmdUpdateItemList"
        Me.cmdUpdateItemList.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateItemList.TabIndex = 11
        Me.cmdUpdateItemList.Text = "Update"
        Me.cmdUpdateItemList.UseVisualStyleBackColor = True
        '
        'GroupBox23
        '
        Me.GroupBox23.Controls.Add(Me.cmdUpdateLots)
        Me.GroupBox23.Controls.Add(Me.cmdViewLots)
        Me.GroupBox23.Location = New System.Drawing.Point(6, 18)
        Me.GroupBox23.Name = "GroupBox23"
        Me.GroupBox23.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox23.TabIndex = 68
        Me.GroupBox23.TabStop = False
        Me.GroupBox23.Text = "Update RMID in Lot #"
        '
        'cmdUpdateLots
        '
        Me.cmdUpdateLots.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateLots.ForeColor = System.Drawing.Color.Black
        Me.cmdUpdateLots.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateLots.Name = "cmdUpdateLots"
        Me.cmdUpdateLots.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateLots.TabIndex = 51
        Me.cmdUpdateLots.Text = "Update"
        Me.cmdUpdateLots.UseVisualStyleBackColor = True
        '
        'cmdViewLots
        '
        Me.cmdViewLots.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewLots.ForeColor = System.Drawing.Color.Black
        Me.cmdViewLots.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewLots.Name = "cmdViewLots"
        Me.cmdViewLots.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewLots.TabIndex = 55
        Me.cmdViewLots.Text = "View"
        Me.cmdViewLots.UseVisualStyleBackColor = True
        '
        'GroupBox22
        '
        Me.GroupBox22.Controls.Add(Me.cmdUpdatePullTests)
        Me.GroupBox22.Controls.Add(Me.cmdViewPullTests)
        Me.GroupBox22.Location = New System.Drawing.Point(6, 104)
        Me.GroupBox22.Name = "GroupBox22"
        Me.GroupBox22.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox22.TabIndex = 67
        Me.GroupBox22.TabStop = False
        Me.GroupBox22.Text = "Update RMID in Pull Tests"
        '
        'cmdUpdatePullTests
        '
        Me.cmdUpdatePullTests.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdatePullTests.ForeColor = System.Drawing.Color.Black
        Me.cmdUpdatePullTests.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdatePullTests.Name = "cmdUpdatePullTests"
        Me.cmdUpdatePullTests.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdatePullTests.TabIndex = 51
        Me.cmdUpdatePullTests.Text = "Update"
        Me.cmdUpdatePullTests.UseVisualStyleBackColor = True
        '
        'cmdViewPullTests
        '
        Me.cmdViewPullTests.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewPullTests.ForeColor = System.Drawing.Color.Black
        Me.cmdViewPullTests.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewPullTests.Name = "cmdViewPullTests"
        Me.cmdViewPullTests.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewPullTests.TabIndex = 55
        Me.cmdViewPullTests.Text = "View"
        Me.cmdViewPullTests.UseVisualStyleBackColor = True
        '
        'tabU5
        '
        Me.tabU5.Controls.Add(Me.GroupBox31)
        Me.tabU5.Controls.Add(Me.gpxAPPaymentBatch)
        Me.tabU5.Controls.Add(Me.gpxARInvoiceBatch)
        Me.tabU5.Controls.Add(Me.GroupBox11)
        Me.tabU5.Controls.Add(Me.GroupBox21)
        Me.tabU5.Controls.Add(Me.gpxUpdateAPInvoiceBatch)
        Me.tabU5.Controls.Add(Me.gpxARPaymentBatch)
        Me.tabU5.Location = New System.Drawing.Point(4, 22)
        Me.tabU5.Name = "tabU5"
        Me.tabU5.Size = New System.Drawing.Size(378, 696)
        Me.tabU5.TabIndex = 4
        Me.tabU5.Text = "AP/AR"
        Me.tabU5.UseVisualStyleBackColor = True
        '
        'GroupBox31
        '
        Me.GroupBox31.Controls.Add(Me.cmdUpdateARPaymentCompare)
        Me.GroupBox31.Controls.Add(Me.cmdViewARPaymentCompare)
        Me.GroupBox31.Location = New System.Drawing.Point(193, 18)
        Me.GroupBox31.Name = "GroupBox31"
        Me.GroupBox31.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox31.TabIndex = 67
        Me.GroupBox31.TabStop = False
        Me.GroupBox31.Text = "Update Payment Log / Lines"
        '
        'cmdUpdateARPaymentCompare
        '
        Me.cmdUpdateARPaymentCompare.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateARPaymentCompare.ForeColor = System.Drawing.Color.Black
        Me.cmdUpdateARPaymentCompare.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateARPaymentCompare.Name = "cmdUpdateARPaymentCompare"
        Me.cmdUpdateARPaymentCompare.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateARPaymentCompare.TabIndex = 51
        Me.cmdUpdateARPaymentCompare.Text = "Update"
        Me.cmdUpdateARPaymentCompare.UseVisualStyleBackColor = True
        '
        'cmdViewARPaymentCompare
        '
        Me.cmdViewARPaymentCompare.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewARPaymentCompare.ForeColor = System.Drawing.Color.Black
        Me.cmdViewARPaymentCompare.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewARPaymentCompare.Name = "cmdViewARPaymentCompare"
        Me.cmdViewARPaymentCompare.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewARPaymentCompare.TabIndex = 55
        Me.cmdViewARPaymentCompare.Text = "View"
        Me.cmdViewARPaymentCompare.UseVisualStyleBackColor = True
        '
        'GroupBox21
        '
        Me.GroupBox21.Controls.Add(Me.cmdUpdateInvoicePayments)
        Me.GroupBox21.Controls.Add(Me.cmdViewOpenInvoices)
        Me.GroupBox21.Location = New System.Drawing.Point(6, 216)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox21.TabIndex = 66
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "Update Payments in Invoices"
        '
        'cmdUpdateInvoicePayments
        '
        Me.cmdUpdateInvoicePayments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateInvoicePayments.ForeColor = System.Drawing.Color.Black
        Me.cmdUpdateInvoicePayments.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateInvoicePayments.Name = "cmdUpdateInvoicePayments"
        Me.cmdUpdateInvoicePayments.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateInvoicePayments.TabIndex = 51
        Me.cmdUpdateInvoicePayments.Text = "Update"
        Me.cmdUpdateInvoicePayments.UseVisualStyleBackColor = True
        '
        'cmdViewOpenInvoices
        '
        Me.cmdViewOpenInvoices.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewOpenInvoices.ForeColor = System.Drawing.Color.Black
        Me.cmdViewOpenInvoices.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewOpenInvoices.Name = "cmdViewOpenInvoices"
        Me.cmdViewOpenInvoices.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewOpenInvoices.TabIndex = 55
        Me.cmdViewOpenInvoices.Text = "View"
        Me.cmdViewOpenInvoices.UseVisualStyleBackColor = True
        '
        'tabU6
        '
        Me.tabU6.Controls.Add(Me.LinkLabel1)
        Me.tabU6.Controls.Add(Me.GroupBox16)
        Me.tabU6.Controls.Add(Me.GroupBox3)
        Me.tabU6.Controls.Add(Me.llUmpostedInvoiceLines)
        Me.tabU6.Location = New System.Drawing.Point(4, 22)
        Me.tabU6.Name = "tabU6"
        Me.tabU6.Size = New System.Drawing.Size(378, 696)
        Me.tabU6.TabIndex = 5
        Me.tabU6.Text = "G/L"
        Me.tabU6.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(8, 647)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(104, 13)
        Me.LinkLabel1.TabIndex = 83
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Run Five Year Sales"
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.Label17)
        Me.GroupBox16.Controls.Add(Me.txtCostTierDivision)
        Me.GroupBox16.Controls.Add(Me.txtCostTierPartNumber)
        Me.GroupBox16.Controls.Add(Me.Label16)
        Me.GroupBox16.Controls.Add(Me.cmdViewCostTiers)
        Me.GroupBox16.Controls.Add(Me.cmdUpdateCostTiers)
        Me.GroupBox16.Location = New System.Drawing.Point(6, 103)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(372, 119)
        Me.GroupBox16.TabIndex = 73
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Repair Cost Tier for Specific Part"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(17, 46)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 23)
        Me.Label17.TabIndex = 64
        Me.Label17.Text = "Division"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCostTierDivision
        '
        Me.txtCostTierDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCostTierDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCostTierDivision.Location = New System.Drawing.Point(94, 49)
        Me.txtCostTierDivision.Name = "txtCostTierDivision"
        Me.txtCostTierDivision.Size = New System.Drawing.Size(106, 20)
        Me.txtCostTierDivision.TabIndex = 63
        '
        'txtCostTierPartNumber
        '
        Me.txtCostTierPartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCostTierPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCostTierPartNumber.Location = New System.Drawing.Point(94, 23)
        Me.txtCostTierPartNumber.Name = "txtCostTierPartNumber"
        Me.txtCostTierPartNumber.Size = New System.Drawing.Size(263, 20)
        Me.txtCostTierPartNumber.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(17, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 23)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Part #"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdViewCostTiers
        '
        Me.cmdViewCostTiers.Location = New System.Drawing.Point(209, 77)
        Me.cmdViewCostTiers.Name = "cmdViewCostTiers"
        Me.cmdViewCostTiers.Size = New System.Drawing.Size(71, 30)
        Me.cmdViewCostTiers.TabIndex = 10
        Me.cmdViewCostTiers.Text = "View"
        Me.cmdViewCostTiers.UseVisualStyleBackColor = True
        '
        'cmdUpdateCostTiers
        '
        Me.cmdUpdateCostTiers.Location = New System.Drawing.Point(286, 77)
        Me.cmdUpdateCostTiers.Name = "cmdUpdateCostTiers"
        Me.cmdUpdateCostTiers.Size = New System.Drawing.Size(71, 30)
        Me.cmdUpdateCostTiers.TabIndex = 11
        Me.cmdUpdateCostTiers.Text = "Update"
        Me.cmdUpdateCostTiers.UseVisualStyleBackColor = True
        '
        'llUmpostedInvoiceLines
        '
        Me.llUmpostedInvoiceLines.AutoSize = True
        Me.llUmpostedInvoiceLines.Location = New System.Drawing.Point(8, 619)
        Me.llUmpostedInvoiceLines.Name = "llUmpostedInvoiceLines"
        Me.llUmpostedInvoiceLines.Size = New System.Drawing.Size(149, 13)
        Me.llUmpostedInvoiceLines.TabIndex = 0
        Me.llUmpostedInvoiceLines.TabStop = True
        Me.llUmpostedInvoiceLines.Text = "View Un-Posted Invoice Lines"
        '
        'tabU3
        '
        Me.tabU3.Location = New System.Drawing.Point(4, 22)
        Me.tabU3.Name = "tabU3"
        Me.tabU3.Size = New System.Drawing.Size(378, 696)
        Me.tabU3.TabIndex = 2
        Me.tabU3.Text = "Special"
        Me.tabU3.UseVisualStyleBackColor = True
        '
        'tabU7
        '
        Me.tabU7.Controls.Add(Me.TextBox5)
        Me.tabU7.Controls.Add(Me.TextBox4)
        Me.tabU7.Controls.Add(Me.TextBox3)
        Me.tabU7.Controls.Add(Me.TextBox2)
        Me.tabU7.Controls.Add(Me.TextBox1)
        Me.tabU7.Controls.Add(Me.GroupBox15)
        Me.tabU7.Controls.Add(Me.GroupBox36)
        Me.tabU7.Location = New System.Drawing.Point(4, 22)
        Me.tabU7.Name = "tabU7"
        Me.tabU7.Size = New System.Drawing.Size(378, 696)
        Me.tabU7.TabIndex = 6
        Me.tabU7.Text = "Steel"
        Me.tabU7.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.cmdViewHeatFiles)
        Me.GroupBox15.Controls.Add(Me.cmdUpdateHeatFileInPullTest)
        Me.GroupBox15.Location = New System.Drawing.Point(13, 115)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox15.TabIndex = 84
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Update Heat File in Pull Tests"
        '
        'cmdViewHeatFiles
        '
        Me.cmdViewHeatFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewHeatFiles.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewHeatFiles.Name = "cmdViewHeatFiles"
        Me.cmdViewHeatFiles.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewHeatFiles.TabIndex = 10
        Me.cmdViewHeatFiles.Text = "View"
        Me.cmdViewHeatFiles.UseVisualStyleBackColor = True
        '
        'cmdUpdateHeatFileInPullTest
        '
        Me.cmdUpdateHeatFileInPullTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateHeatFileInPullTest.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateHeatFileInPullTest.Name = "cmdUpdateHeatFileInPullTest"
        Me.cmdUpdateHeatFileInPullTest.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateHeatFileInPullTest.TabIndex = 11
        Me.cmdUpdateHeatFileInPullTest.Text = "Update"
        Me.cmdUpdateHeatFileInPullTest.UseVisualStyleBackColor = True
        '
        'GroupBox36
        '
        Me.GroupBox36.Controls.Add(Me.cmdViewSteelCostTier)
        Me.GroupBox36.Controls.Add(Me.cmdUpdateSteelCostTier)
        Me.GroupBox36.Location = New System.Drawing.Point(13, 20)
        Me.GroupBox36.Name = "GroupBox36"
        Me.GroupBox36.Size = New System.Drawing.Size(182, 80)
        Me.GroupBox36.TabIndex = 82
        Me.GroupBox36.TabStop = False
        Me.GroupBox36.Text = "Update Cost in Steel Cost Tier"
        '
        'cmdViewSteelCostTier
        '
        Me.cmdViewSteelCostTier.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdViewSteelCostTier.Location = New System.Drawing.Point(14, 24)
        Me.cmdViewSteelCostTier.Name = "cmdViewSteelCostTier"
        Me.cmdViewSteelCostTier.Size = New System.Drawing.Size(71, 40)
        Me.cmdViewSteelCostTier.TabIndex = 10
        Me.cmdViewSteelCostTier.Text = "View"
        Me.cmdViewSteelCostTier.UseVisualStyleBackColor = True
        '
        'cmdUpdateSteelCostTier
        '
        Me.cmdUpdateSteelCostTier.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateSteelCostTier.Location = New System.Drawing.Point(91, 24)
        Me.cmdUpdateSteelCostTier.Name = "cmdUpdateSteelCostTier"
        Me.cmdUpdateSteelCostTier.Size = New System.Drawing.Size(71, 40)
        Me.cmdUpdateSteelCostTier.TabIndex = 11
        Me.cmdUpdateSteelCostTier.Text = "Update"
        Me.cmdUpdateSteelCostTier.UseVisualStyleBackColor = True
        '
        'tabDatagrids
        '
        Me.tabDatagrids.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabDatagrids.Controls.Add(Me.SOHeader)
        Me.tabDatagrids.Controls.Add(Me.POHeader)
        Me.tabDatagrids.Controls.Add(Me.tabPurchases)
        Me.tabDatagrids.Controls.Add(Me.TabCostTiers)
        Me.tabDatagrids.Controls.Add(Me.TabPage5)
        Me.tabDatagrids.Controls.Add(Me.tabUPS)
        Me.tabDatagrids.Controls.Add(Me.tabSteel)
        Me.tabDatagrids.Controls.Add(Me.TabPage8)
        Me.tabDatagrids.Controls.Add(Me.TabPage9)
        Me.tabDatagrids.Controls.Add(Me.TabPage10)
        Me.tabDatagrids.Controls.Add(Me.TabPage11)
        Me.tabDatagrids.Controls.Add(Me.TabPage12)
        Me.tabDatagrids.Controls.Add(Me.TabPage13)
        Me.tabDatagrids.Controls.Add(Me.TabPage14)
        Me.tabDatagrids.Controls.Add(Me.TabPage15)
        Me.tabDatagrids.Controls.Add(Me.TabPage16)
        Me.tabDatagrids.Controls.Add(Me.TabPage17)
        Me.tabDatagrids.Controls.Add(Me.TabPage18)
        Me.tabDatagrids.Controls.Add(Me.TabPage19)
        Me.tabDatagrids.Controls.Add(Me.TabPage20)
        Me.tabDatagrids.Controls.Add(Me.TabPage21)
        Me.tabDatagrids.Controls.Add(Me.TabPage22)
        Me.tabDatagrids.Controls.Add(Me.TabPage23)
        Me.tabDatagrids.Controls.Add(Me.TabPage24)
        Me.tabDatagrids.Controls.Add(Me.TabPage25)
        Me.tabDatagrids.Controls.Add(Me.TabPage26)
        Me.tabDatagrids.Controls.Add(Me.TabPage27)
        Me.tabDatagrids.Controls.Add(Me.TabPage28)
        Me.tabDatagrids.Controls.Add(Me.TabPage29)
        Me.tabDatagrids.Controls.Add(Me.TabPage30)
        Me.tabDatagrids.Controls.Add(Me.TabPage31)
        Me.tabDatagrids.Controls.Add(Me.TabPage32)
        Me.tabDatagrids.Controls.Add(Me.TabPage33)
        Me.tabDatagrids.Controls.Add(Me.TabPage34)
        Me.tabDatagrids.Controls.Add(Me.TabPage35)
        Me.tabDatagrids.Location = New System.Drawing.Point(417, 39)
        Me.tabDatagrids.Name = "tabDatagrids"
        Me.tabDatagrids.SelectedIndex = 0
        Me.tabDatagrids.Size = New System.Drawing.Size(613, 708)
        Me.tabDatagrids.TabIndex = 66
        '
        'SOHeader
        '
        Me.SOHeader.Controls.Add(Me.dgvLotNumberTest)
        Me.SOHeader.Controls.Add(Me.dgvSerialLog)
        Me.SOHeader.Controls.Add(Me.dgvSteelCostingTable)
        Me.SOHeader.Controls.Add(Me.dgvTWDItemList)
        Me.SOHeader.Controls.Add(Me.dgvPurchaseLines)
        Me.SOHeader.Controls.Add(Me.dgvReceivingHeaders)
        Me.SOHeader.Controls.Add(Me.dgvReturnHeader)
        Me.SOHeader.Controls.Add(Me.dgvInvoiceShipment)
        Me.SOHeader.Controls.Add(Me.dgvInvoiceCompare)
        Me.SOHeader.Controls.Add(Me.dgvInvoiceShipCOS)
        Me.SOHeader.Controls.Add(Me.dgvShipmentHeaderTable)
        Me.SOHeader.Controls.Add(Me.dgvSOTable)
        Me.SOHeader.Location = New System.Drawing.Point(4, 22)
        Me.SOHeader.Name = "SOHeader"
        Me.SOHeader.Padding = New System.Windows.Forms.Padding(3)
        Me.SOHeader.Size = New System.Drawing.Size(605, 682)
        Me.SOHeader.TabIndex = 0
        Me.SOHeader.Text = "Sales"
        Me.SOHeader.UseVisualStyleBackColor = True
        '
        'dgvLotNumberTest
        '
        Me.dgvLotNumberTest.AllowUserToAddRows = False
        Me.dgvLotNumberTest.AutoGenerateColumns = False
        Me.dgvLotNumberTest.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvLotNumberTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLotNumberTest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LotNumberColumn5, Me.PartNumberColumn5, Me.PieceWeightColumn5, Me.BoxWeightColumn5, Me.PalletWeightColumn5, Me.BoxCountColumn5, Me.PalletCountColumn5, Me.PalletPiecesColumn5, Me.BoxTypeColumn5, Me.NominalDiameterColumn5, Me.NominalLengthColumn5, Me.ShortDescriptionColumn5, Me.ItemPieceWeightColumn5, Me.ItemBoxCountColumn5, Me.ItemPalletCountColumn5, Me.ItemNominalDiameterColumn5, Me.ItemNominalLengthColumn5, Me.ItemBoxWeightColumn5, Me.ItemClassColumn5, Me.FOXRawMaterialWeightColumn5, Me.FOXScrapWeightColumn5, Me.FOXFinishedWeightColumn5, Me.LotRawMaterialWeightColumn5, Me.LotScrapWeightColumn5, Me.LotFinishedWeightColumn5})
        Me.dgvLotNumberTest.DataSource = Me.LotNumberTestBindingSource
        Me.dgvLotNumberTest.Location = New System.Drawing.Point(306, 229)
        Me.dgvLotNumberTest.Name = "dgvLotNumberTest"
        Me.dgvLotNumberTest.Size = New System.Drawing.Size(299, 68)
        Me.dgvLotNumberTest.TabIndex = 11
        '
        'LotNumberColumn5
        '
        Me.LotNumberColumn5.DataPropertyName = "LotNumber"
        Me.LotNumberColumn5.HeaderText = "LotNumber"
        Me.LotNumberColumn5.Name = "LotNumberColumn5"
        '
        'PartNumberColumn5
        '
        Me.PartNumberColumn5.DataPropertyName = "PartNumber"
        Me.PartNumberColumn5.HeaderText = "PartNumber"
        Me.PartNumberColumn5.Name = "PartNumberColumn5"
        '
        'PieceWeightColumn5
        '
        Me.PieceWeightColumn5.DataPropertyName = "PieceWeight"
        Me.PieceWeightColumn5.HeaderText = "PieceWeight"
        Me.PieceWeightColumn5.Name = "PieceWeightColumn5"
        '
        'BoxWeightColumn5
        '
        Me.BoxWeightColumn5.DataPropertyName = "BoxWeight"
        Me.BoxWeightColumn5.HeaderText = "BoxWeight"
        Me.BoxWeightColumn5.Name = "BoxWeightColumn5"
        '
        'PalletWeightColumn5
        '
        Me.PalletWeightColumn5.DataPropertyName = "PalletWeight"
        Me.PalletWeightColumn5.HeaderText = "PalletWeight"
        Me.PalletWeightColumn5.Name = "PalletWeightColumn5"
        '
        'BoxCountColumn5
        '
        Me.BoxCountColumn5.DataPropertyName = "BoxCount"
        Me.BoxCountColumn5.HeaderText = "BoxCount"
        Me.BoxCountColumn5.Name = "BoxCountColumn5"
        '
        'PalletCountColumn5
        '
        Me.PalletCountColumn5.DataPropertyName = "PalletCount"
        Me.PalletCountColumn5.HeaderText = "PalletCount"
        Me.PalletCountColumn5.Name = "PalletCountColumn5"
        '
        'PalletPiecesColumn5
        '
        Me.PalletPiecesColumn5.DataPropertyName = "PalletPieces"
        Me.PalletPiecesColumn5.HeaderText = "PalletPieces"
        Me.PalletPiecesColumn5.Name = "PalletPiecesColumn5"
        '
        'BoxTypeColumn5
        '
        Me.BoxTypeColumn5.DataPropertyName = "BoxType"
        Me.BoxTypeColumn5.HeaderText = "BoxType"
        Me.BoxTypeColumn5.Name = "BoxTypeColumn5"
        '
        'NominalDiameterColumn5
        '
        Me.NominalDiameterColumn5.DataPropertyName = "NominalDiameter"
        Me.NominalDiameterColumn5.HeaderText = "NominalDiameter"
        Me.NominalDiameterColumn5.Name = "NominalDiameterColumn5"
        '
        'NominalLengthColumn5
        '
        Me.NominalLengthColumn5.DataPropertyName = "NominalLength"
        Me.NominalLengthColumn5.HeaderText = "NominalLength"
        Me.NominalLengthColumn5.Name = "NominalLengthColumn5"
        '
        'ShortDescriptionColumn5
        '
        Me.ShortDescriptionColumn5.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn5.HeaderText = "ShortDescription"
        Me.ShortDescriptionColumn5.Name = "ShortDescriptionColumn5"
        '
        'ItemPieceWeightColumn5
        '
        Me.ItemPieceWeightColumn5.DataPropertyName = "ItemPieceWeight"
        Me.ItemPieceWeightColumn5.HeaderText = "ItemPieceWeight"
        Me.ItemPieceWeightColumn5.Name = "ItemPieceWeightColumn5"
        '
        'ItemBoxCountColumn5
        '
        Me.ItemBoxCountColumn5.DataPropertyName = "ItemBoxCount"
        Me.ItemBoxCountColumn5.HeaderText = "ItemBoxCount"
        Me.ItemBoxCountColumn5.Name = "ItemBoxCountColumn5"
        '
        'ItemPalletCountColumn5
        '
        Me.ItemPalletCountColumn5.DataPropertyName = "ItemPalletCount"
        Me.ItemPalletCountColumn5.HeaderText = "ItemPalletCount"
        Me.ItemPalletCountColumn5.Name = "ItemPalletCountColumn5"
        '
        'ItemNominalDiameterColumn5
        '
        Me.ItemNominalDiameterColumn5.DataPropertyName = "ItemNominalDiameter"
        Me.ItemNominalDiameterColumn5.HeaderText = "ItemNominalDiameter"
        Me.ItemNominalDiameterColumn5.Name = "ItemNominalDiameterColumn5"
        '
        'ItemNominalLengthColumn5
        '
        Me.ItemNominalLengthColumn5.DataPropertyName = "ItemNominalLength"
        Me.ItemNominalLengthColumn5.HeaderText = "ItemNominalLength"
        Me.ItemNominalLengthColumn5.Name = "ItemNominalLengthColumn5"
        '
        'ItemBoxWeightColumn5
        '
        Me.ItemBoxWeightColumn5.DataPropertyName = "ItemBoxWeight"
        Me.ItemBoxWeightColumn5.HeaderText = "ItemBoxWeight"
        Me.ItemBoxWeightColumn5.Name = "ItemBoxWeightColumn5"
        '
        'ItemClassColumn5
        '
        Me.ItemClassColumn5.DataPropertyName = "ItemClass"
        Me.ItemClassColumn5.HeaderText = "ItemClass"
        Me.ItemClassColumn5.Name = "ItemClassColumn5"
        '
        'FOXRawMaterialWeightColumn5
        '
        Me.FOXRawMaterialWeightColumn5.DataPropertyName = "FOXRawMaterialWeight"
        Me.FOXRawMaterialWeightColumn5.HeaderText = "FOXRawMaterialWeight"
        Me.FOXRawMaterialWeightColumn5.Name = "FOXRawMaterialWeightColumn5"
        '
        'FOXScrapWeightColumn5
        '
        Me.FOXScrapWeightColumn5.DataPropertyName = "FOXScrapWeight"
        Me.FOXScrapWeightColumn5.HeaderText = "FOXScrapWeight"
        Me.FOXScrapWeightColumn5.Name = "FOXScrapWeightColumn5"
        '
        'FOXFinishedWeightColumn5
        '
        Me.FOXFinishedWeightColumn5.DataPropertyName = "FOXFinishedWeight"
        Me.FOXFinishedWeightColumn5.HeaderText = "FOXFinishedWeight"
        Me.FOXFinishedWeightColumn5.Name = "FOXFinishedWeightColumn5"
        '
        'LotRawMaterialWeightColumn5
        '
        Me.LotRawMaterialWeightColumn5.DataPropertyName = "LotRawMaterialWeight"
        Me.LotRawMaterialWeightColumn5.HeaderText = "LotRawMaterialWeight"
        Me.LotRawMaterialWeightColumn5.Name = "LotRawMaterialWeightColumn5"
        '
        'LotScrapWeightColumn5
        '
        Me.LotScrapWeightColumn5.DataPropertyName = "LotScrapWeight"
        Me.LotScrapWeightColumn5.HeaderText = "LotScrapWeight"
        Me.LotScrapWeightColumn5.Name = "LotScrapWeightColumn5"
        '
        'LotFinishedWeightColumn5
        '
        Me.LotFinishedWeightColumn5.DataPropertyName = "LotFinishedWeight"
        Me.LotFinishedWeightColumn5.HeaderText = "LotFinishedWeight"
        Me.LotFinishedWeightColumn5.Name = "LotFinishedWeightColumn5"
        '
        'LotNumberTestBindingSource
        '
        Me.LotNumberTestBindingSource.DataMember = "LotNumberTest"
        Me.LotNumberTestBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgvSerialLog
        '
        Me.dgvSerialLog.AllowUserToAddRows = False
        Me.dgvSerialLog.AllowUserToDeleteRows = False
        Me.dgvSerialLog.AutoGenerateColumns = False
        Me.dgvSerialLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSerialLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSerialLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumber77Column, Me.SerialNumber77Column, Me.DivisionID77Column, Me.TotalCost77Column, Me.Comment77Column, Me.BuildDate77Column, Me.Status77Column, Me.BuildNumber77Column, Me.CustomerID77Column, Me.BatchNumber77Column, Me.TransactionNumber77Column, Me.ShipmentNumber77Column, Me.ShipmentDate77Column, Me.InvoiceNumber77Column, Me.InvoiceDate77Column})
        Me.dgvSerialLog.DataSource = Me.AssemblySerialLogBindingSource
        Me.dgvSerialLog.Location = New System.Drawing.Point(306, 152)
        Me.dgvSerialLog.Name = "dgvSerialLog"
        Me.dgvSerialLog.ReadOnly = True
        Me.dgvSerialLog.Size = New System.Drawing.Size(300, 70)
        Me.dgvSerialLog.TabIndex = 10
        '
        'AssemblyPartNumber77Column
        '
        Me.AssemblyPartNumber77Column.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumber77Column.HeaderText = "AssemblyPartNumber"
        Me.AssemblyPartNumber77Column.Name = "AssemblyPartNumber77Column"
        Me.AssemblyPartNumber77Column.ReadOnly = True
        '
        'SerialNumber77Column
        '
        Me.SerialNumber77Column.DataPropertyName = "SerialNumber"
        Me.SerialNumber77Column.HeaderText = "SerialNumber"
        Me.SerialNumber77Column.Name = "SerialNumber77Column"
        Me.SerialNumber77Column.ReadOnly = True
        '
        'DivisionID77Column
        '
        Me.DivisionID77Column.DataPropertyName = "DivisionID"
        Me.DivisionID77Column.HeaderText = "DivisionID"
        Me.DivisionID77Column.Name = "DivisionID77Column"
        Me.DivisionID77Column.ReadOnly = True
        '
        'TotalCost77Column
        '
        Me.TotalCost77Column.DataPropertyName = "TotalCost"
        Me.TotalCost77Column.HeaderText = "TotalCost"
        Me.TotalCost77Column.Name = "TotalCost77Column"
        Me.TotalCost77Column.ReadOnly = True
        '
        'Comment77Column
        '
        Me.Comment77Column.DataPropertyName = "Comment"
        Me.Comment77Column.HeaderText = "Comment"
        Me.Comment77Column.Name = "Comment77Column"
        Me.Comment77Column.ReadOnly = True
        '
        'BuildDate77Column
        '
        Me.BuildDate77Column.DataPropertyName = "BuildDate"
        Me.BuildDate77Column.HeaderText = "BuildDate"
        Me.BuildDate77Column.Name = "BuildDate77Column"
        Me.BuildDate77Column.ReadOnly = True
        '
        'Status77Column
        '
        Me.Status77Column.DataPropertyName = "Status"
        Me.Status77Column.HeaderText = "Status"
        Me.Status77Column.Name = "Status77Column"
        Me.Status77Column.ReadOnly = True
        '
        'BuildNumber77Column
        '
        Me.BuildNumber77Column.DataPropertyName = "BuildNumber"
        Me.BuildNumber77Column.HeaderText = "BuildNumber"
        Me.BuildNumber77Column.Name = "BuildNumber77Column"
        Me.BuildNumber77Column.ReadOnly = True
        '
        'CustomerID77Column
        '
        Me.CustomerID77Column.DataPropertyName = "CustomerID"
        Me.CustomerID77Column.HeaderText = "CustomerID"
        Me.CustomerID77Column.Name = "CustomerID77Column"
        Me.CustomerID77Column.ReadOnly = True
        '
        'BatchNumber77Column
        '
        Me.BatchNumber77Column.DataPropertyName = "BatchNumber"
        Me.BatchNumber77Column.HeaderText = "BatchNumber"
        Me.BatchNumber77Column.Name = "BatchNumber77Column"
        Me.BatchNumber77Column.ReadOnly = True
        '
        'TransactionNumber77Column
        '
        Me.TransactionNumber77Column.DataPropertyName = "TransactionNumber"
        Me.TransactionNumber77Column.HeaderText = "TransactionNumber"
        Me.TransactionNumber77Column.Name = "TransactionNumber77Column"
        Me.TransactionNumber77Column.ReadOnly = True
        '
        'ShipmentNumber77Column
        '
        Me.ShipmentNumber77Column.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumber77Column.HeaderText = "ShipmentNumber"
        Me.ShipmentNumber77Column.Name = "ShipmentNumber77Column"
        Me.ShipmentNumber77Column.ReadOnly = True
        '
        'ShipmentDate77Column
        '
        Me.ShipmentDate77Column.DataPropertyName = "ShipmentDate"
        Me.ShipmentDate77Column.HeaderText = "ShipmentDate"
        Me.ShipmentDate77Column.Name = "ShipmentDate77Column"
        Me.ShipmentDate77Column.ReadOnly = True
        '
        'InvoiceNumber77Column
        '
        Me.InvoiceNumber77Column.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumber77Column.HeaderText = "InvoiceNumber"
        Me.InvoiceNumber77Column.Name = "InvoiceNumber77Column"
        Me.InvoiceNumber77Column.ReadOnly = True
        '
        'InvoiceDate77Column
        '
        Me.InvoiceDate77Column.DataPropertyName = "InvoiceDate"
        Me.InvoiceDate77Column.HeaderText = "InvoiceDate"
        Me.InvoiceDate77Column.Name = "InvoiceDate77Column"
        Me.InvoiceDate77Column.ReadOnly = True
        '
        'AssemblySerialLogBindingSource
        '
        Me.AssemblySerialLogBindingSource.DataMember = "AssemblySerialLog"
        Me.AssemblySerialLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvSteelCostingTable
        '
        Me.dgvSteelCostingTable.AllowUserToAddRows = False
        Me.dgvSteelCostingTable.AllowUserToDeleteRows = False
        Me.dgvSteelCostingTable.AutoGenerateColumns = False
        Me.dgvSteelCostingTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelCostingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelCostingTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RMIDColumn66, Me.CostingDateColumn66, Me.SteelCostPerPoundColumn66, Me.CostingQuantityColumn66, Me.TransactionNumberColumn66, Me.ReferenceNumberColumn66, Me.ReferenceLineColumn66})
        Me.dgvSteelCostingTable.DataSource = Me.SteelCostingTableBindingSource
        Me.dgvSteelCostingTable.Location = New System.Drawing.Point(305, 76)
        Me.dgvSteelCostingTable.Name = "dgvSteelCostingTable"
        Me.dgvSteelCostingTable.ReadOnly = True
        Me.dgvSteelCostingTable.Size = New System.Drawing.Size(300, 70)
        Me.dgvSteelCostingTable.TabIndex = 9
        '
        'RMIDColumn66
        '
        Me.RMIDColumn66.DataPropertyName = "RMID"
        Me.RMIDColumn66.HeaderText = "RMID"
        Me.RMIDColumn66.Name = "RMIDColumn66"
        Me.RMIDColumn66.ReadOnly = True
        '
        'CostingDateColumn66
        '
        Me.CostingDateColumn66.DataPropertyName = "CostingDate"
        Me.CostingDateColumn66.HeaderText = "CostingDate"
        Me.CostingDateColumn66.Name = "CostingDateColumn66"
        Me.CostingDateColumn66.ReadOnly = True
        '
        'SteelCostPerPoundColumn66
        '
        Me.SteelCostPerPoundColumn66.DataPropertyName = "SteelCostPerPound"
        Me.SteelCostPerPoundColumn66.HeaderText = "SteelCostPerPound"
        Me.SteelCostPerPoundColumn66.Name = "SteelCostPerPoundColumn66"
        Me.SteelCostPerPoundColumn66.ReadOnly = True
        '
        'CostingQuantityColumn66
        '
        Me.CostingQuantityColumn66.DataPropertyName = "CostingQuantity"
        Me.CostingQuantityColumn66.HeaderText = "CostingQuantity"
        Me.CostingQuantityColumn66.Name = "CostingQuantityColumn66"
        Me.CostingQuantityColumn66.ReadOnly = True
        '
        'TransactionNumberColumn66
        '
        Me.TransactionNumberColumn66.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn66.HeaderText = "TransactionNumber"
        Me.TransactionNumberColumn66.Name = "TransactionNumberColumn66"
        Me.TransactionNumberColumn66.ReadOnly = True
        '
        'ReferenceNumberColumn66
        '
        Me.ReferenceNumberColumn66.DataPropertyName = "ReferenceNumber"
        Me.ReferenceNumberColumn66.HeaderText = "ReferenceNumber"
        Me.ReferenceNumberColumn66.Name = "ReferenceNumberColumn66"
        Me.ReferenceNumberColumn66.ReadOnly = True
        '
        'ReferenceLineColumn66
        '
        Me.ReferenceLineColumn66.DataPropertyName = "ReferenceLine"
        Me.ReferenceLineColumn66.HeaderText = "ReferenceLine"
        Me.ReferenceLineColumn66.Name = "ReferenceLineColumn66"
        Me.ReferenceLineColumn66.ReadOnly = True
        '
        'SteelCostingTableBindingSource
        '
        Me.SteelCostingTableBindingSource.DataMember = "SteelCostingTable"
        Me.SteelCostingTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvTWDItemList
        '
        Me.dgvTWDItemList.AllowUserToAddRows = False
        Me.dgvTWDItemList.AllowUserToDeleteRows = False
        Me.dgvTWDItemList.AutoGenerateColumns = False
        Me.dgvTWDItemList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTWDItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTWDItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemIDColumn26, Me.DivisionIDColumn26, Me.ShortDescriptionColumn26, Me.LongDescriptionColumn26, Me.PieceWeightColumn26, Me.BoxCountColumn26, Me.PalletCountColumn26, Me.FOXNumberColumn26, Me.BoxTypeColumn26, Me.NominalDiameterColumn26, Me.NominalLengthColumn26, Me.SafetyDataSheetColumn26, Me.BoxWeightColumn26})
        Me.dgvTWDItemList.DataSource = Me.ItemListBindingSource
        Me.dgvTWDItemList.Location = New System.Drawing.Point(306, 0)
        Me.dgvTWDItemList.Name = "dgvTWDItemList"
        Me.dgvTWDItemList.ReadOnly = True
        Me.dgvTWDItemList.Size = New System.Drawing.Size(299, 70)
        Me.dgvTWDItemList.TabIndex = 8
        '
        'ItemIDColumn26
        '
        Me.ItemIDColumn26.DataPropertyName = "ItemID"
        Me.ItemIDColumn26.HeaderText = "ItemID"
        Me.ItemIDColumn26.Name = "ItemIDColumn26"
        Me.ItemIDColumn26.ReadOnly = True
        '
        'DivisionIDColumn26
        '
        Me.DivisionIDColumn26.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn26.HeaderText = "DivisionID"
        Me.DivisionIDColumn26.Name = "DivisionIDColumn26"
        Me.DivisionIDColumn26.ReadOnly = True
        '
        'ShortDescriptionColumn26
        '
        Me.ShortDescriptionColumn26.DataPropertyName = "ShortDescription"
        Me.ShortDescriptionColumn26.HeaderText = "ShortDescription"
        Me.ShortDescriptionColumn26.Name = "ShortDescriptionColumn26"
        Me.ShortDescriptionColumn26.ReadOnly = True
        '
        'LongDescriptionColumn26
        '
        Me.LongDescriptionColumn26.DataPropertyName = "LongDescription"
        Me.LongDescriptionColumn26.HeaderText = "LongDescription"
        Me.LongDescriptionColumn26.Name = "LongDescriptionColumn26"
        Me.LongDescriptionColumn26.ReadOnly = True
        '
        'PieceWeightColumn26
        '
        Me.PieceWeightColumn26.DataPropertyName = "PieceWeight"
        Me.PieceWeightColumn26.HeaderText = "PieceWeight"
        Me.PieceWeightColumn26.Name = "PieceWeightColumn26"
        Me.PieceWeightColumn26.ReadOnly = True
        '
        'BoxCountColumn26
        '
        Me.BoxCountColumn26.DataPropertyName = "BoxCount"
        Me.BoxCountColumn26.HeaderText = "BoxCount"
        Me.BoxCountColumn26.Name = "BoxCountColumn26"
        Me.BoxCountColumn26.ReadOnly = True
        '
        'PalletCountColumn26
        '
        Me.PalletCountColumn26.DataPropertyName = "PalletCount"
        Me.PalletCountColumn26.HeaderText = "PalletCount"
        Me.PalletCountColumn26.Name = "PalletCountColumn26"
        Me.PalletCountColumn26.ReadOnly = True
        '
        'FOXNumberColumn26
        '
        Me.FOXNumberColumn26.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn26.HeaderText = "FOXNumber"
        Me.FOXNumberColumn26.Name = "FOXNumberColumn26"
        Me.FOXNumberColumn26.ReadOnly = True
        '
        'BoxTypeColumn26
        '
        Me.BoxTypeColumn26.DataPropertyName = "BoxType"
        Me.BoxTypeColumn26.HeaderText = "BoxType"
        Me.BoxTypeColumn26.Name = "BoxTypeColumn26"
        Me.BoxTypeColumn26.ReadOnly = True
        '
        'NominalDiameterColumn26
        '
        Me.NominalDiameterColumn26.DataPropertyName = "NominalDiameter"
        Me.NominalDiameterColumn26.HeaderText = "NominalDiameter"
        Me.NominalDiameterColumn26.Name = "NominalDiameterColumn26"
        Me.NominalDiameterColumn26.ReadOnly = True
        '
        'NominalLengthColumn26
        '
        Me.NominalLengthColumn26.DataPropertyName = "NominalLength"
        Me.NominalLengthColumn26.HeaderText = "NominalLength"
        Me.NominalLengthColumn26.Name = "NominalLengthColumn26"
        Me.NominalLengthColumn26.ReadOnly = True
        '
        'SafetyDataSheetColumn26
        '
        Me.SafetyDataSheetColumn26.DataPropertyName = "SafetyDataSheet"
        Me.SafetyDataSheetColumn26.HeaderText = "SafetyDataSheet"
        Me.SafetyDataSheetColumn26.Name = "SafetyDataSheetColumn26"
        Me.SafetyDataSheetColumn26.ReadOnly = True
        '
        'BoxWeightColumn26
        '
        Me.BoxWeightColumn26.DataPropertyName = "BoxWeight"
        Me.BoxWeightColumn26.HeaderText = "BoxWeight"
        Me.BoxWeightColumn26.Name = "BoxWeightColumn26"
        Me.BoxWeightColumn26.ReadOnly = True
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvPurchaseLines
        '
        Me.dgvPurchaseLines.AllowUserToAddRows = False
        Me.dgvPurchaseLines.AllowUserToDeleteRows = False
        Me.dgvPurchaseLines.AutoGenerateColumns = False
        Me.dgvPurchaseLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPurchaseLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPurchaseLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PurchaseOrderHeaderKeyColumn88, Me.PurchaseOrderLineNumberColumn88, Me.PartNumberColumn88, Me.PartDescriptionColumn88, Me.OrderQuantityColumn88, Me.POQuantityReceivedColumn88, Me.ReceivedQtyPendingColumn88, Me.POQuantityOpenColumn88, Me.DivisionIDColumn88, Me.StatusColumn88, Me.LineStatusColumn88, Me.SelectForInvoiceColumn88})
        Me.dgvPurchaseLines.DataSource = Me.PurchaseOrderQuantityStatusBindingSource
        Me.dgvPurchaseLines.GridColor = System.Drawing.Color.Yellow
        Me.dgvPurchaseLines.Location = New System.Drawing.Point(0, 556)
        Me.dgvPurchaseLines.Name = "dgvPurchaseLines"
        Me.dgvPurchaseLines.ReadOnly = True
        Me.dgvPurchaseLines.Size = New System.Drawing.Size(300, 70)
        Me.dgvPurchaseLines.TabIndex = 7
        '
        'PurchaseOrderHeaderKeyColumn88
        '
        Me.PurchaseOrderHeaderKeyColumn88.DataPropertyName = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn88.HeaderText = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn88.Name = "PurchaseOrderHeaderKeyColumn88"
        Me.PurchaseOrderHeaderKeyColumn88.ReadOnly = True
        '
        'PurchaseOrderLineNumberColumn88
        '
        Me.PurchaseOrderLineNumberColumn88.DataPropertyName = "PurchaseOrderLineNumber"
        Me.PurchaseOrderLineNumberColumn88.HeaderText = "PurchaseOrderLineNumber"
        Me.PurchaseOrderLineNumberColumn88.Name = "PurchaseOrderLineNumberColumn88"
        Me.PurchaseOrderLineNumberColumn88.ReadOnly = True
        '
        'PartNumberColumn88
        '
        Me.PartNumberColumn88.DataPropertyName = "PartNumber"
        Me.PartNumberColumn88.HeaderText = "PartNumber"
        Me.PartNumberColumn88.Name = "PartNumberColumn88"
        Me.PartNumberColumn88.ReadOnly = True
        '
        'PartDescriptionColumn88
        '
        Me.PartDescriptionColumn88.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn88.HeaderText = "PartDescription"
        Me.PartDescriptionColumn88.Name = "PartDescriptionColumn88"
        Me.PartDescriptionColumn88.ReadOnly = True
        '
        'OrderQuantityColumn88
        '
        Me.OrderQuantityColumn88.DataPropertyName = "OrderQuantity"
        Me.OrderQuantityColumn88.HeaderText = "OrderQuantity"
        Me.OrderQuantityColumn88.Name = "OrderQuantityColumn88"
        Me.OrderQuantityColumn88.ReadOnly = True
        '
        'POQuantityReceivedColumn88
        '
        Me.POQuantityReceivedColumn88.DataPropertyName = "POQuantityReceived"
        Me.POQuantityReceivedColumn88.HeaderText = "POQuantityReceived"
        Me.POQuantityReceivedColumn88.Name = "POQuantityReceivedColumn88"
        Me.POQuantityReceivedColumn88.ReadOnly = True
        '
        'ReceivedQtyPendingColumn88
        '
        Me.ReceivedQtyPendingColumn88.DataPropertyName = "ReceivedQtyPending"
        Me.ReceivedQtyPendingColumn88.HeaderText = "ReceivedQtyPending"
        Me.ReceivedQtyPendingColumn88.Name = "ReceivedQtyPendingColumn88"
        Me.ReceivedQtyPendingColumn88.ReadOnly = True
        '
        'POQuantityOpenColumn88
        '
        Me.POQuantityOpenColumn88.DataPropertyName = "POQuantityOpen"
        Me.POQuantityOpenColumn88.HeaderText = "POQuantityOpen"
        Me.POQuantityOpenColumn88.Name = "POQuantityOpenColumn88"
        Me.POQuantityOpenColumn88.ReadOnly = True
        '
        'DivisionIDColumn88
        '
        Me.DivisionIDColumn88.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn88.HeaderText = "DivisionID"
        Me.DivisionIDColumn88.Name = "DivisionIDColumn88"
        Me.DivisionIDColumn88.ReadOnly = True
        '
        'StatusColumn88
        '
        Me.StatusColumn88.DataPropertyName = "Status"
        Me.StatusColumn88.HeaderText = "Status"
        Me.StatusColumn88.Name = "StatusColumn88"
        Me.StatusColumn88.ReadOnly = True
        '
        'LineStatusColumn88
        '
        Me.LineStatusColumn88.DataPropertyName = "LineStatus"
        Me.LineStatusColumn88.HeaderText = "LineStatus"
        Me.LineStatusColumn88.Name = "LineStatusColumn88"
        Me.LineStatusColumn88.ReadOnly = True
        '
        'SelectForInvoiceColumn88
        '
        Me.SelectForInvoiceColumn88.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn88.HeaderText = "SelectForInvoice"
        Me.SelectForInvoiceColumn88.Name = "SelectForInvoiceColumn88"
        Me.SelectForInvoiceColumn88.ReadOnly = True
        '
        'PurchaseOrderQuantityStatusBindingSource
        '
        Me.PurchaseOrderQuantityStatusBindingSource.DataMember = "PurchaseOrderQuantityStatus"
        Me.PurchaseOrderQuantityStatusBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvReceivingHeaders
        '
        Me.dgvReceivingHeaders.AllowUserToAddRows = False
        Me.dgvReceivingHeaders.AllowUserToDeleteRows = False
        Me.dgvReceivingHeaders.AutoGenerateColumns = False
        Me.dgvReceivingHeaders.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReceivingHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceivingHeaders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReceivingHeaderKeyColumn7, Me.DivisionIDColumn7})
        Me.dgvReceivingHeaders.DataSource = Me.ReceivingHeaderTableBindingSource
        Me.dgvReceivingHeaders.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvReceivingHeaders.Location = New System.Drawing.Point(0, 471)
        Me.dgvReceivingHeaders.Name = "dgvReceivingHeaders"
        Me.dgvReceivingHeaders.ReadOnly = True
        Me.dgvReceivingHeaders.Size = New System.Drawing.Size(300, 70)
        Me.dgvReceivingHeaders.TabIndex = 6
        '
        'ReceivingHeaderKeyColumn7
        '
        Me.ReceivingHeaderKeyColumn7.DataPropertyName = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyColumn7.HeaderText = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyColumn7.Name = "ReceivingHeaderKeyColumn7"
        Me.ReceivingHeaderKeyColumn7.ReadOnly = True
        '
        'DivisionIDColumn7
        '
        Me.DivisionIDColumn7.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn7.HeaderText = "DivisionID"
        Me.DivisionIDColumn7.Name = "DivisionIDColumn7"
        Me.DivisionIDColumn7.ReadOnly = True
        '
        'ReceivingHeaderTableBindingSource
        '
        Me.ReceivingHeaderTableBindingSource.DataMember = "ReceivingHeaderTable"
        Me.ReceivingHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvReturnHeader
        '
        Me.dgvReturnHeader.AllowUserToAddRows = False
        Me.dgvReturnHeader.AllowUserToDeleteRows = False
        Me.dgvReturnHeader.AutoGenerateColumns = False
        Me.dgvReturnHeader.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReturnHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReturnHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReturnNumberColumn6, Me.DivisionIDColumn6})
        Me.dgvReturnHeader.DataSource = Me.ReturnProductHeaderTableBindingSource
        Me.dgvReturnHeader.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvReturnHeader.Location = New System.Drawing.Point(0, 390)
        Me.dgvReturnHeader.Name = "dgvReturnHeader"
        Me.dgvReturnHeader.ReadOnly = True
        Me.dgvReturnHeader.Size = New System.Drawing.Size(300, 70)
        Me.dgvReturnHeader.TabIndex = 5
        '
        'ReturnNumberColumn6
        '
        Me.ReturnNumberColumn6.DataPropertyName = "ReturnNumber"
        Me.ReturnNumberColumn6.HeaderText = "ReturnNumber"
        Me.ReturnNumberColumn6.Name = "ReturnNumberColumn6"
        Me.ReturnNumberColumn6.ReadOnly = True
        '
        'DivisionIDColumn6
        '
        Me.DivisionIDColumn6.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn6.HeaderText = "DivisionID"
        Me.DivisionIDColumn6.Name = "DivisionIDColumn6"
        Me.DivisionIDColumn6.ReadOnly = True
        '
        'ReturnProductHeaderTableBindingSource
        '
        Me.ReturnProductHeaderTableBindingSource.DataMember = "ReturnProductHeaderTable"
        Me.ReturnProductHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvInvoiceShipment
        '
        Me.dgvInvoiceShipment.AllowUserToAddRows = False
        Me.dgvInvoiceShipment.AllowUserToDeleteRows = False
        Me.dgvInvoiceShipment.AutoGenerateColumns = False
        Me.dgvInvoiceShipment.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceShipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceShipment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShipmentNumberColumn5, Me.InvoiceProductTotalColumn5, Me.BilledFreightColumn5, Me.SalesTaxColumn5, Me.SalesTax2Column5, Me.SalesTax3Column5, Me.InvoiceTotalColumn5})
        Me.dgvInvoiceShipment.DataSource = Me.InvoiceShipmentBindingSource
        Me.dgvInvoiceShipment.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvInvoiceShipment.Location = New System.Drawing.Point(0, 309)
        Me.dgvInvoiceShipment.Name = "dgvInvoiceShipment"
        Me.dgvInvoiceShipment.ReadOnly = True
        Me.dgvInvoiceShipment.Size = New System.Drawing.Size(300, 70)
        Me.dgvInvoiceShipment.TabIndex = 4
        '
        'ShipmentNumberColumn5
        '
        Me.ShipmentNumberColumn5.DataPropertyName = "ShipmentNumber"
        Me.ShipmentNumberColumn5.HeaderText = "ShipmentNumber"
        Me.ShipmentNumberColumn5.Name = "ShipmentNumberColumn5"
        Me.ShipmentNumberColumn5.ReadOnly = True
        '
        'InvoiceProductTotalColumn5
        '
        Me.InvoiceProductTotalColumn5.DataPropertyName = "InvoiceProductTotal"
        Me.InvoiceProductTotalColumn5.HeaderText = "InvoiceProductTotal"
        Me.InvoiceProductTotalColumn5.Name = "InvoiceProductTotalColumn5"
        Me.InvoiceProductTotalColumn5.ReadOnly = True
        '
        'BilledFreightColumn5
        '
        Me.BilledFreightColumn5.DataPropertyName = "BilledFreight"
        Me.BilledFreightColumn5.HeaderText = "BilledFreight"
        Me.BilledFreightColumn5.Name = "BilledFreightColumn5"
        Me.BilledFreightColumn5.ReadOnly = True
        '
        'SalesTaxColumn5
        '
        Me.SalesTaxColumn5.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn5.HeaderText = "SalesTax"
        Me.SalesTaxColumn5.Name = "SalesTaxColumn5"
        Me.SalesTaxColumn5.ReadOnly = True
        '
        'SalesTax2Column5
        '
        Me.SalesTax2Column5.DataPropertyName = "SalesTax2"
        Me.SalesTax2Column5.HeaderText = "SalesTax2"
        Me.SalesTax2Column5.Name = "SalesTax2Column5"
        Me.SalesTax2Column5.ReadOnly = True
        '
        'SalesTax3Column5
        '
        Me.SalesTax3Column5.DataPropertyName = "SalesTax3"
        Me.SalesTax3Column5.HeaderText = "SalesTax3"
        Me.SalesTax3Column5.Name = "SalesTax3Column5"
        Me.SalesTax3Column5.ReadOnly = True
        '
        'InvoiceTotalColumn5
        '
        Me.InvoiceTotalColumn5.DataPropertyName = "InvoiceTotal"
        Me.InvoiceTotalColumn5.HeaderText = "InvoiceTotal"
        Me.InvoiceTotalColumn5.Name = "InvoiceTotalColumn5"
        Me.InvoiceTotalColumn5.ReadOnly = True
        '
        'InvoiceShipmentBindingSource
        '
        Me.InvoiceShipmentBindingSource.DataMember = "InvoiceShipment"
        Me.InvoiceShipmentBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvInvoiceCompare
        '
        Me.dgvInvoiceCompare.AllowUserToAddRows = False
        Me.dgvInvoiceCompare.AllowUserToDeleteRows = False
        Me.dgvInvoiceCompare.AutoGenerateColumns = False
        Me.dgvInvoiceCompare.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceCompare.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberColumn3, Me.InvoiceCOSColumn3, Me.SUMExtendedCOSColumn3})
        Me.dgvInvoiceCompare.DataSource = Me.InvoiceCompareBindingSource
        Me.dgvInvoiceCompare.GridColor = System.Drawing.Color.Lime
        Me.dgvInvoiceCompare.Location = New System.Drawing.Point(0, 227)
        Me.dgvInvoiceCompare.Name = "dgvInvoiceCompare"
        Me.dgvInvoiceCompare.ReadOnly = True
        Me.dgvInvoiceCompare.Size = New System.Drawing.Size(300, 70)
        Me.dgvInvoiceCompare.TabIndex = 3
        '
        'InvoiceNumberColumn3
        '
        Me.InvoiceNumberColumn3.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn3.HeaderText = "InvoiceNumber"
        Me.InvoiceNumberColumn3.Name = "InvoiceNumberColumn3"
        Me.InvoiceNumberColumn3.ReadOnly = True
        '
        'InvoiceCOSColumn3
        '
        Me.InvoiceCOSColumn3.DataPropertyName = "InvoiceCOS"
        Me.InvoiceCOSColumn3.HeaderText = "InvoiceCOS"
        Me.InvoiceCOSColumn3.Name = "InvoiceCOSColumn3"
        Me.InvoiceCOSColumn3.ReadOnly = True
        '
        'SUMExtendedCOSColumn3
        '
        Me.SUMExtendedCOSColumn3.DataPropertyName = "SUMExtendedCOS"
        Me.SUMExtendedCOSColumn3.HeaderText = "SUMExtendedCOS"
        Me.SUMExtendedCOSColumn3.Name = "SUMExtendedCOSColumn3"
        Me.SUMExtendedCOSColumn3.ReadOnly = True
        '
        'InvoiceCompareBindingSource
        '
        Me.InvoiceCompareBindingSource.DataMember = "InvoiceCompare"
        Me.InvoiceCompareBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvInvoiceShipCOS
        '
        Me.dgvInvoiceShipCOS.AllowUserToAddRows = False
        Me.dgvInvoiceShipCOS.AllowUserToDeleteRows = False
        Me.dgvInvoiceShipCOS.AutoGenerateColumns = False
        Me.dgvInvoiceShipCOS.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceShipCOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceShipCOS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SONumberColumn2, Me.SOLineNumberColumn2, Me.QuantityColumn2, Me.UnitCostColumn2, Me.EstExtendedCOSColumn2})
        Me.dgvInvoiceShipCOS.DataSource = Me.InvoiceShipmentCOSBindingSource
        Me.dgvInvoiceShipCOS.GridColor = System.Drawing.Color.Fuchsia
        Me.dgvInvoiceShipCOS.Location = New System.Drawing.Point(0, 151)
        Me.dgvInvoiceShipCOS.Name = "dgvInvoiceShipCOS"
        Me.dgvInvoiceShipCOS.ReadOnly = True
        Me.dgvInvoiceShipCOS.Size = New System.Drawing.Size(300, 70)
        Me.dgvInvoiceShipCOS.TabIndex = 2
        '
        'SONumberColumn2
        '
        Me.SONumberColumn2.DataPropertyName = "SONumber"
        Me.SONumberColumn2.HeaderText = "SONumber"
        Me.SONumberColumn2.Name = "SONumberColumn2"
        Me.SONumberColumn2.ReadOnly = True
        '
        'SOLineNumberColumn2
        '
        Me.SOLineNumberColumn2.DataPropertyName = "SOLineNumber"
        Me.SOLineNumberColumn2.HeaderText = "SOLineNumber"
        Me.SOLineNumberColumn2.Name = "SOLineNumberColumn2"
        Me.SOLineNumberColumn2.ReadOnly = True
        '
        'QuantityColumn2
        '
        Me.QuantityColumn2.DataPropertyName = "Quantity"
        Me.QuantityColumn2.HeaderText = "Quantity"
        Me.QuantityColumn2.Name = "QuantityColumn2"
        Me.QuantityColumn2.ReadOnly = True
        '
        'UnitCostColumn2
        '
        Me.UnitCostColumn2.DataPropertyName = "UnitCost"
        Me.UnitCostColumn2.HeaderText = "UnitCost"
        Me.UnitCostColumn2.Name = "UnitCostColumn2"
        Me.UnitCostColumn2.ReadOnly = True
        '
        'EstExtendedCOSColumn2
        '
        Me.EstExtendedCOSColumn2.DataPropertyName = "EstExtendedCOS"
        Me.EstExtendedCOSColumn2.HeaderText = "EstExtendedCOS"
        Me.EstExtendedCOSColumn2.Name = "EstExtendedCOSColumn2"
        Me.EstExtendedCOSColumn2.ReadOnly = True
        '
        'InvoiceShipmentCOSBindingSource
        '
        Me.InvoiceShipmentCOSBindingSource.DataMember = "InvoiceShipmentCOS"
        Me.InvoiceShipmentCOSBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvShipmentHeaderTable
        '
        Me.dgvShipmentHeaderTable.AllowUserToAddRows = False
        Me.dgvShipmentHeaderTable.AllowUserToDeleteRows = False
        Me.dgvShipmentHeaderTable.AutoGenerateColumns = False
        Me.dgvShipmentHeaderTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvShipmentHeaderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShipmentHeaderTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.STShipmentNumberColumn, Me.STDivisionIDColumn})
        Me.dgvShipmentHeaderTable.DataSource = Me.ShipmentHeaderTableBindingSource
        Me.dgvShipmentHeaderTable.Location = New System.Drawing.Point(0, 75)
        Me.dgvShipmentHeaderTable.Name = "dgvShipmentHeaderTable"
        Me.dgvShipmentHeaderTable.ReadOnly = True
        Me.dgvShipmentHeaderTable.Size = New System.Drawing.Size(300, 70)
        Me.dgvShipmentHeaderTable.TabIndex = 1
        '
        'STShipmentNumberColumn
        '
        Me.STShipmentNumberColumn.DataPropertyName = "ShipmentNumber"
        Me.STShipmentNumberColumn.HeaderText = "Ship #"
        Me.STShipmentNumberColumn.Name = "STShipmentNumberColumn"
        Me.STShipmentNumberColumn.ReadOnly = True
        '
        'STDivisionIDColumn
        '
        Me.STDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.STDivisionIDColumn.HeaderText = "Division"
        Me.STDivisionIDColumn.Name = "STDivisionIDColumn"
        Me.STDivisionIDColumn.ReadOnly = True
        '
        'ShipmentHeaderTableBindingSource
        '
        Me.ShipmentHeaderTableBindingSource.DataMember = "ShipmentHeaderTable"
        Me.ShipmentHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvSOTable
        '
        Me.dgvSOTable.AllowUserToAddRows = False
        Me.dgvSOTable.AllowUserToDeleteRows = False
        Me.dgvSOTable.AutoGenerateColumns = False
        Me.dgvSOTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSOTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSOTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SOSalesOrderKeyColumn, Me.SODivisionKeyColumn})
        Me.dgvSOTable.DataSource = Me.SalesOrderHeaderTableBindingSource
        Me.dgvSOTable.Location = New System.Drawing.Point(0, 0)
        Me.dgvSOTable.Name = "dgvSOTable"
        Me.dgvSOTable.ReadOnly = True
        Me.dgvSOTable.Size = New System.Drawing.Size(300, 70)
        Me.dgvSOTable.TabIndex = 0
        '
        'SOSalesOrderKeyColumn
        '
        Me.SOSalesOrderKeyColumn.DataPropertyName = "SalesOrderKey"
        Me.SOSalesOrderKeyColumn.HeaderText = "SO #"
        Me.SOSalesOrderKeyColumn.Name = "SOSalesOrderKeyColumn"
        Me.SOSalesOrderKeyColumn.ReadOnly = True
        '
        'SODivisionKeyColumn
        '
        Me.SODivisionKeyColumn.DataPropertyName = "DivisionKey"
        Me.SODivisionKeyColumn.HeaderText = "Division"
        Me.SODivisionKeyColumn.Name = "SODivisionKeyColumn"
        Me.SODivisionKeyColumn.ReadOnly = True
        '
        'SalesOrderHeaderTableBindingSource
        '
        Me.SalesOrderHeaderTableBindingSource.DataMember = "SalesOrderHeaderTable"
        Me.SalesOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'POHeader
        '
        Me.POHeader.Controls.Add(Me.dgvTFPErrorLog)
        Me.POHeader.Location = New System.Drawing.Point(4, 22)
        Me.POHeader.Name = "POHeader"
        Me.POHeader.Padding = New System.Windows.Forms.Padding(3)
        Me.POHeader.Size = New System.Drawing.Size(605, 682)
        Me.POHeader.TabIndex = 1
        Me.POHeader.Text = "Error Log"
        Me.POHeader.UseVisualStyleBackColor = True
        '
        'dgvTFPErrorLog
        '
        Me.dgvTFPErrorLog.AllowUserToAddRows = False
        Me.dgvTFPErrorLog.AllowUserToDeleteRows = False
        Me.dgvTFPErrorLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTFPErrorLog.AutoGenerateColumns = False
        Me.dgvTFPErrorLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvTFPErrorLog.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTFPErrorLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTFPErrorLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ErrorDateDataGridViewTextBoxColumn, Me.ErrorDescriptionDataGridViewTextBoxColumn, Me.ErrorReferenceNumberDataGridViewTextBoxColumn, Me.ErrorUserIDDataGridViewTextBoxColumn, Me.ErrorCommentDataGridViewTextBoxColumn, Me.ErrorDivisionDataGridViewTextBoxColumn})
        Me.dgvTFPErrorLog.DataSource = Me.TFPErrorLogBindingSource
        Me.dgvTFPErrorLog.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgvTFPErrorLog.Location = New System.Drawing.Point(3, 0)
        Me.dgvTFPErrorLog.Name = "dgvTFPErrorLog"
        Me.dgvTFPErrorLog.ReadOnly = True
        Me.dgvTFPErrorLog.Size = New System.Drawing.Size(596, 626)
        Me.dgvTFPErrorLog.TabIndex = 0
        '
        'ErrorDateDataGridViewTextBoxColumn
        '
        Me.ErrorDateDataGridViewTextBoxColumn.DataPropertyName = "ErrorDate"
        Me.ErrorDateDataGridViewTextBoxColumn.HeaderText = "ErrorDate"
        Me.ErrorDateDataGridViewTextBoxColumn.Name = "ErrorDateDataGridViewTextBoxColumn"
        Me.ErrorDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ErrorDescriptionDataGridViewTextBoxColumn
        '
        Me.ErrorDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ErrorDescription"
        Me.ErrorDescriptionDataGridViewTextBoxColumn.HeaderText = "ErrorDescription"
        Me.ErrorDescriptionDataGridViewTextBoxColumn.Name = "ErrorDescriptionDataGridViewTextBoxColumn"
        Me.ErrorDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ErrorReferenceNumberDataGridViewTextBoxColumn
        '
        Me.ErrorReferenceNumberDataGridViewTextBoxColumn.DataPropertyName = "ErrorReferenceNumber"
        Me.ErrorReferenceNumberDataGridViewTextBoxColumn.HeaderText = "ErrorReferenceNumber"
        Me.ErrorReferenceNumberDataGridViewTextBoxColumn.Name = "ErrorReferenceNumberDataGridViewTextBoxColumn"
        Me.ErrorReferenceNumberDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ErrorUserIDDataGridViewTextBoxColumn
        '
        Me.ErrorUserIDDataGridViewTextBoxColumn.DataPropertyName = "ErrorUserID"
        Me.ErrorUserIDDataGridViewTextBoxColumn.HeaderText = "ErrorUserID"
        Me.ErrorUserIDDataGridViewTextBoxColumn.Name = "ErrorUserIDDataGridViewTextBoxColumn"
        Me.ErrorUserIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ErrorCommentDataGridViewTextBoxColumn
        '
        Me.ErrorCommentDataGridViewTextBoxColumn.DataPropertyName = "ErrorComment"
        Me.ErrorCommentDataGridViewTextBoxColumn.HeaderText = "ErrorComment"
        Me.ErrorCommentDataGridViewTextBoxColumn.Name = "ErrorCommentDataGridViewTextBoxColumn"
        Me.ErrorCommentDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ErrorDivisionDataGridViewTextBoxColumn
        '
        Me.ErrorDivisionDataGridViewTextBoxColumn.DataPropertyName = "ErrorDivision"
        Me.ErrorDivisionDataGridViewTextBoxColumn.HeaderText = "ErrorDivision"
        Me.ErrorDivisionDataGridViewTextBoxColumn.Name = "ErrorDivisionDataGridViewTextBoxColumn"
        Me.ErrorDivisionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TFPErrorLogBindingSource
        '
        Me.TFPErrorLogBindingSource.DataMember = "TFPErrorLog"
        Me.TFPErrorLogBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'tabPurchases
        '
        Me.tabPurchases.Controls.Add(Me.dgvReceiverLineQuery)
        Me.tabPurchases.Controls.Add(Me.dgvOpenPOTable)
        Me.tabPurchases.Controls.Add(Me.dgvARPaymentCompare)
        Me.tabPurchases.Controls.Add(Me.dgvPOHeaders)
        Me.tabPurchases.Controls.Add(Me.dgvAPPaymentBatch)
        Me.tabPurchases.Controls.Add(Me.dgvAPInvoiceBatch)
        Me.tabPurchases.Controls.Add(Me.dgvInvoiceHeaderTable)
        Me.tabPurchases.Controls.Add(Me.dgvARPaymentBatch)
        Me.tabPurchases.Controls.Add(Me.dgvARInvoiceBatch)
        Me.tabPurchases.Location = New System.Drawing.Point(4, 22)
        Me.tabPurchases.Name = "tabPurchases"
        Me.tabPurchases.Size = New System.Drawing.Size(605, 682)
        Me.tabPurchases.TabIndex = 2
        Me.tabPurchases.Text = "Purchases"
        Me.tabPurchases.UseVisualStyleBackColor = True
        '
        'dgvReceiverLineQuery
        '
        Me.dgvReceiverLineQuery.AllowUserToAddRows = False
        Me.dgvReceiverLineQuery.AllowUserToDeleteRows = False
        Me.dgvReceiverLineQuery.AutoGenerateColumns = False
        Me.dgvReceiverLineQuery.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvReceiverLineQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceiverLineQuery.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReceivingHeaderKeyColumn96, Me.DivisionIDColumn96, Me.QuantityReceivedColumn96, Me.TotalQuantityVouchedColumn96, Me.LineStatusColumn96, Me.StatusDataColumn96, Me.SelectForInvoiceColumn96})
        Me.dgvReceiverLineQuery.DataSource = Me.ReceivingLineQueryBindingSource
        Me.dgvReceiverLineQuery.Location = New System.Drawing.Point(309, 2)
        Me.dgvReceiverLineQuery.Name = "dgvReceiverLineQuery"
        Me.dgvReceiverLineQuery.Size = New System.Drawing.Size(300, 70)
        Me.dgvReceiverLineQuery.TabIndex = 12
        '
        'ReceivingHeaderKeyColumn96
        '
        Me.ReceivingHeaderKeyColumn96.DataPropertyName = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyColumn96.HeaderText = "ReceivingHeaderKey"
        Me.ReceivingHeaderKeyColumn96.Name = "ReceivingHeaderKeyColumn96"
        '
        'DivisionIDColumn96
        '
        Me.DivisionIDColumn96.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn96.HeaderText = "DivisionID"
        Me.DivisionIDColumn96.Name = "DivisionIDColumn96"
        '
        'QuantityReceivedColumn96
        '
        Me.QuantityReceivedColumn96.DataPropertyName = "QuantityReceived"
        Me.QuantityReceivedColumn96.HeaderText = "QuantityReceived"
        Me.QuantityReceivedColumn96.Name = "QuantityReceivedColumn96"
        '
        'TotalQuantityVouchedColumn96
        '
        Me.TotalQuantityVouchedColumn96.DataPropertyName = "TotalQuantityVouched"
        Me.TotalQuantityVouchedColumn96.HeaderText = "TotalQuantityVouched"
        Me.TotalQuantityVouchedColumn96.Name = "TotalQuantityVouchedColumn96"
        Me.TotalQuantityVouchedColumn96.ReadOnly = True
        '
        'LineStatusColumn96
        '
        Me.LineStatusColumn96.DataPropertyName = "LineStatus"
        Me.LineStatusColumn96.HeaderText = "LineStatus"
        Me.LineStatusColumn96.Name = "LineStatusColumn96"
        '
        'StatusDataColumn96
        '
        Me.StatusDataColumn96.DataPropertyName = "Status"
        Me.StatusDataColumn96.HeaderText = "Status"
        Me.StatusDataColumn96.Name = "StatusDataColumn96"
        '
        'SelectForInvoiceColumn96
        '
        Me.SelectForInvoiceColumn96.DataPropertyName = "SelectForInvoice"
        Me.SelectForInvoiceColumn96.HeaderText = "SelectForInvoice"
        Me.SelectForInvoiceColumn96.Name = "SelectForInvoiceColumn96"
        '
        'ReceivingLineQueryBindingSource
        '
        Me.ReceivingLineQueryBindingSource.DataMember = "ReceivingLineQuery"
        Me.ReceivingLineQueryBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvOpenPOTable
        '
        Me.dgvOpenPOTable.AllowUserToAddRows = False
        Me.dgvOpenPOTable.AllowUserToDeleteRows = False
        Me.dgvOpenPOTable.AutoGenerateColumns = False
        Me.dgvOpenPOTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvOpenPOTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOpenPOTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PurchaseOrderHeaderKeyColumn22, Me.StatusColumn22, Me.DivisionIDColumn22})
        Me.dgvOpenPOTable.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.dgvOpenPOTable.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvOpenPOTable.Location = New System.Drawing.Point(0, 562)
        Me.dgvOpenPOTable.Name = "dgvOpenPOTable"
        Me.dgvOpenPOTable.Size = New System.Drawing.Size(300, 72)
        Me.dgvOpenPOTable.TabIndex = 6
        '
        'PurchaseOrderHeaderKeyColumn22
        '
        Me.PurchaseOrderHeaderKeyColumn22.DataPropertyName = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn22.HeaderText = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn22.Name = "PurchaseOrderHeaderKeyColumn22"
        '
        'StatusColumn22
        '
        Me.StatusColumn22.DataPropertyName = "Status"
        Me.StatusColumn22.HeaderText = "Status"
        Me.StatusColumn22.Name = "StatusColumn22"
        '
        'DivisionIDColumn22
        '
        Me.DivisionIDColumn22.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn22.HeaderText = "DivisionID"
        Me.DivisionIDColumn22.Name = "DivisionIDColumn22"
        '
        'PurchaseOrderHeaderTableBindingSource
        '
        Me.PurchaseOrderHeaderTableBindingSource.DataMember = "PurchaseOrderHeaderTable"
        Me.PurchaseOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvARPaymentCompare
        '
        Me.dgvARPaymentCompare.AllowUserToAddRows = False
        Me.dgvARPaymentCompare.AllowUserToDeleteRows = False
        Me.dgvARPaymentCompare.AutoGenerateColumns = False
        Me.dgvARPaymentCompare.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvARPaymentCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvARPaymentCompare.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ARTransactionKeyColumn77, Me.DivisionIDColumn77, Me.CustomerIDColumn77, Me.PaymentDateColumn77, Me.PaymentAmountColumn77, Me.PaymentIDColumn77, Me.PaymentLineNumberColumn77, Me.CheckNumberColumn77, Me.PLPaymentIDColumn77, Me.PLPaymentLineNumberColumn77, Me.PLInvoiceNumberColumn77, Me.PLPaymentAmountColumn77, Me.PLPaymentDateColumn77, Me.PLDivisionIDColumn77, Me.InvoiceNumberColumn77})
        Me.dgvARPaymentCompare.DataSource = Me.ARPaymentCompareBindingSource
        Me.dgvARPaymentCompare.GridColor = System.Drawing.Color.Fuchsia
        Me.dgvARPaymentCompare.Location = New System.Drawing.Point(0, 486)
        Me.dgvARPaymentCompare.Name = "dgvARPaymentCompare"
        Me.dgvARPaymentCompare.ReadOnly = True
        Me.dgvARPaymentCompare.Size = New System.Drawing.Size(300, 70)
        Me.dgvARPaymentCompare.TabIndex = 5
        '
        'ARTransactionKeyColumn77
        '
        Me.ARTransactionKeyColumn77.DataPropertyName = "ARTransactionKey"
        Me.ARTransactionKeyColumn77.HeaderText = "ARTransactionKey"
        Me.ARTransactionKeyColumn77.Name = "ARTransactionKeyColumn77"
        Me.ARTransactionKeyColumn77.ReadOnly = True
        '
        'DivisionIDColumn77
        '
        Me.DivisionIDColumn77.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn77.HeaderText = "DivisionID"
        Me.DivisionIDColumn77.Name = "DivisionIDColumn77"
        Me.DivisionIDColumn77.ReadOnly = True
        '
        'CustomerIDColumn77
        '
        Me.CustomerIDColumn77.DataPropertyName = "CustomerID"
        Me.CustomerIDColumn77.HeaderText = "CustomerID"
        Me.CustomerIDColumn77.Name = "CustomerIDColumn77"
        Me.CustomerIDColumn77.ReadOnly = True
        '
        'PaymentDateColumn77
        '
        Me.PaymentDateColumn77.DataPropertyName = "PaymentDate"
        Me.PaymentDateColumn77.HeaderText = "PaymentDate"
        Me.PaymentDateColumn77.Name = "PaymentDateColumn77"
        Me.PaymentDateColumn77.ReadOnly = True
        '
        'PaymentAmountColumn77
        '
        Me.PaymentAmountColumn77.DataPropertyName = "PaymentAmount"
        Me.PaymentAmountColumn77.HeaderText = "PaymentAmount"
        Me.PaymentAmountColumn77.Name = "PaymentAmountColumn77"
        Me.PaymentAmountColumn77.ReadOnly = True
        '
        'PaymentIDColumn77
        '
        Me.PaymentIDColumn77.DataPropertyName = "PaymentID"
        Me.PaymentIDColumn77.HeaderText = "PaymentID"
        Me.PaymentIDColumn77.Name = "PaymentIDColumn77"
        Me.PaymentIDColumn77.ReadOnly = True
        '
        'PaymentLineNumberColumn77
        '
        Me.PaymentLineNumberColumn77.DataPropertyName = "PaymentLineNumber"
        Me.PaymentLineNumberColumn77.HeaderText = "PaymentLineNumber"
        Me.PaymentLineNumberColumn77.Name = "PaymentLineNumberColumn77"
        Me.PaymentLineNumberColumn77.ReadOnly = True
        '
        'CheckNumberColumn77
        '
        Me.CheckNumberColumn77.DataPropertyName = "CheckNumber"
        Me.CheckNumberColumn77.HeaderText = "CheckNumber"
        Me.CheckNumberColumn77.Name = "CheckNumberColumn77"
        Me.CheckNumberColumn77.ReadOnly = True
        '
        'PLPaymentIDColumn77
        '
        Me.PLPaymentIDColumn77.DataPropertyName = "PLPaymentID"
        Me.PLPaymentIDColumn77.HeaderText = "PLPaymentID"
        Me.PLPaymentIDColumn77.Name = "PLPaymentIDColumn77"
        Me.PLPaymentIDColumn77.ReadOnly = True
        '
        'PLPaymentLineNumberColumn77
        '
        Me.PLPaymentLineNumberColumn77.DataPropertyName = "PLPaymentLineNumber"
        Me.PLPaymentLineNumberColumn77.HeaderText = "PLPaymentLineNumber"
        Me.PLPaymentLineNumberColumn77.Name = "PLPaymentLineNumberColumn77"
        Me.PLPaymentLineNumberColumn77.ReadOnly = True
        '
        'PLInvoiceNumberColumn77
        '
        Me.PLInvoiceNumberColumn77.DataPropertyName = "PLInvoiceNumber"
        Me.PLInvoiceNumberColumn77.HeaderText = "PLInvoiceNumber"
        Me.PLInvoiceNumberColumn77.Name = "PLInvoiceNumberColumn77"
        Me.PLInvoiceNumberColumn77.ReadOnly = True
        '
        'PLPaymentAmountColumn77
        '
        Me.PLPaymentAmountColumn77.DataPropertyName = "PLPaymentAmount"
        Me.PLPaymentAmountColumn77.HeaderText = "PLPaymentAmount"
        Me.PLPaymentAmountColumn77.Name = "PLPaymentAmountColumn77"
        Me.PLPaymentAmountColumn77.ReadOnly = True
        '
        'PLPaymentDateColumn77
        '
        Me.PLPaymentDateColumn77.DataPropertyName = "PLPaymentDate"
        Me.PLPaymentDateColumn77.HeaderText = "PLPaymentDate"
        Me.PLPaymentDateColumn77.Name = "PLPaymentDateColumn77"
        Me.PLPaymentDateColumn77.ReadOnly = True
        '
        'PLDivisionIDColumn77
        '
        Me.PLDivisionIDColumn77.DataPropertyName = "PLDivisionID"
        Me.PLDivisionIDColumn77.HeaderText = "PLDivisionID"
        Me.PLDivisionIDColumn77.Name = "PLDivisionIDColumn77"
        Me.PLDivisionIDColumn77.ReadOnly = True
        '
        'InvoiceNumberColumn77
        '
        Me.InvoiceNumberColumn77.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn77.HeaderText = "InvoiceNumber"
        Me.InvoiceNumberColumn77.Name = "InvoiceNumberColumn77"
        Me.InvoiceNumberColumn77.ReadOnly = True
        '
        'ARPaymentCompareBindingSource
        '
        Me.ARPaymentCompareBindingSource.DataMember = "ARPaymentCompare"
        Me.ARPaymentCompareBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvPOHeaders
        '
        Me.dgvPOHeaders.AllowUserToAddRows = False
        Me.dgvPOHeaders.AllowUserToDeleteRows = False
        Me.dgvPOHeaders.AutoGenerateColumns = False
        Me.dgvPOHeaders.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPOHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPOHeaders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PurchaseOrderHeaderKeyColumn66, Me.PODropShipCustomerIDColumn66, Me.POAdditionalShipToColumn66, Me.DivisionIDColumn66, Me.DropShipSalesOrderNumberColumn66, Me.ShipNameColumn66, Me.ShipAddress1Column66, Me.ShipAddress2Column66, Me.ShipCityColumn66, Me.ShipStateColumn66, Me.ShipZipCodeColumn66, Me.ShipCountryColumn66})
        Me.dgvPOHeaders.DataSource = Me.PurchaseOrderHeaderTableBindingSource
        Me.dgvPOHeaders.GridColor = System.Drawing.Color.Lime
        Me.dgvPOHeaders.Location = New System.Drawing.Point(3, 405)
        Me.dgvPOHeaders.Name = "dgvPOHeaders"
        Me.dgvPOHeaders.ReadOnly = True
        Me.dgvPOHeaders.Size = New System.Drawing.Size(300, 70)
        Me.dgvPOHeaders.TabIndex = 4
        '
        'PurchaseOrderHeaderKeyColumn66
        '
        Me.PurchaseOrderHeaderKeyColumn66.DataPropertyName = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn66.HeaderText = "PurchaseOrderHeaderKey"
        Me.PurchaseOrderHeaderKeyColumn66.Name = "PurchaseOrderHeaderKeyColumn66"
        Me.PurchaseOrderHeaderKeyColumn66.ReadOnly = True
        '
        'PODropShipCustomerIDColumn66
        '
        Me.PODropShipCustomerIDColumn66.DataPropertyName = "PODropShipCustomerID"
        Me.PODropShipCustomerIDColumn66.HeaderText = "PODropShipCustomerID"
        Me.PODropShipCustomerIDColumn66.Name = "PODropShipCustomerIDColumn66"
        Me.PODropShipCustomerIDColumn66.ReadOnly = True
        '
        'POAdditionalShipToColumn66
        '
        Me.POAdditionalShipToColumn66.DataPropertyName = "POAdditionalShipTo"
        Me.POAdditionalShipToColumn66.HeaderText = "POAdditionalShipTo"
        Me.POAdditionalShipToColumn66.Name = "POAdditionalShipToColumn66"
        Me.POAdditionalShipToColumn66.ReadOnly = True
        '
        'DivisionIDColumn66
        '
        Me.DivisionIDColumn66.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn66.HeaderText = "DivisionID"
        Me.DivisionIDColumn66.Name = "DivisionIDColumn66"
        Me.DivisionIDColumn66.ReadOnly = True
        '
        'DropShipSalesOrderNumberColumn66
        '
        Me.DropShipSalesOrderNumberColumn66.DataPropertyName = "DropShipSalesOrderNumber"
        Me.DropShipSalesOrderNumberColumn66.HeaderText = "DropShipSalesOrderNumber"
        Me.DropShipSalesOrderNumberColumn66.Name = "DropShipSalesOrderNumberColumn66"
        Me.DropShipSalesOrderNumberColumn66.ReadOnly = True
        '
        'ShipNameColumn66
        '
        Me.ShipNameColumn66.DataPropertyName = "ShipName"
        Me.ShipNameColumn66.HeaderText = "ShipName"
        Me.ShipNameColumn66.Name = "ShipNameColumn66"
        Me.ShipNameColumn66.ReadOnly = True
        '
        'ShipAddress1Column66
        '
        Me.ShipAddress1Column66.DataPropertyName = "ShipAddress1"
        Me.ShipAddress1Column66.HeaderText = "ShipAddress1"
        Me.ShipAddress1Column66.Name = "ShipAddress1Column66"
        Me.ShipAddress1Column66.ReadOnly = True
        '
        'ShipAddress2Column66
        '
        Me.ShipAddress2Column66.DataPropertyName = "ShipAddress2"
        Me.ShipAddress2Column66.HeaderText = "ShipAddress2"
        Me.ShipAddress2Column66.Name = "ShipAddress2Column66"
        Me.ShipAddress2Column66.ReadOnly = True
        '
        'ShipCityColumn66
        '
        Me.ShipCityColumn66.DataPropertyName = "ShipCity"
        Me.ShipCityColumn66.HeaderText = "ShipCity"
        Me.ShipCityColumn66.Name = "ShipCityColumn66"
        Me.ShipCityColumn66.ReadOnly = True
        '
        'ShipStateColumn66
        '
        Me.ShipStateColumn66.DataPropertyName = "ShipState"
        Me.ShipStateColumn66.HeaderText = "ShipState"
        Me.ShipStateColumn66.Name = "ShipStateColumn66"
        Me.ShipStateColumn66.ReadOnly = True
        '
        'ShipZipCodeColumn66
        '
        Me.ShipZipCodeColumn66.DataPropertyName = "ShipZipCode"
        Me.ShipZipCodeColumn66.HeaderText = "ShipZipCode"
        Me.ShipZipCodeColumn66.Name = "ShipZipCodeColumn66"
        Me.ShipZipCodeColumn66.ReadOnly = True
        '
        'ShipCountryColumn66
        '
        Me.ShipCountryColumn66.DataPropertyName = "ShipCountry"
        Me.ShipCountryColumn66.HeaderText = "ShipCountry"
        Me.ShipCountryColumn66.Name = "ShipCountryColumn66"
        Me.ShipCountryColumn66.ReadOnly = True
        '
        'dgvAPPaymentBatch
        '
        Me.dgvAPPaymentBatch.AllowUserToAddRows = False
        Me.dgvAPPaymentBatch.AllowUserToDeleteRows = False
        Me.dgvAPPaymentBatch.AutoGenerateColumns = False
        Me.dgvAPPaymentBatch.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAPPaymentBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAPPaymentBatch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BatchNumberColumn13, Me.DivisionIDColumn13})
        Me.dgvAPPaymentBatch.DataSource = Me.APProcessPaymentBatchBindingSource
        Me.dgvAPPaymentBatch.Location = New System.Drawing.Point(3, 243)
        Me.dgvAPPaymentBatch.Name = "dgvAPPaymentBatch"
        Me.dgvAPPaymentBatch.ReadOnly = True
        Me.dgvAPPaymentBatch.Size = New System.Drawing.Size(300, 70)
        Me.dgvAPPaymentBatch.TabIndex = 3
        '
        'BatchNumberColumn13
        '
        Me.BatchNumberColumn13.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn13.HeaderText = "BatchNumber"
        Me.BatchNumberColumn13.Name = "BatchNumberColumn13"
        Me.BatchNumberColumn13.ReadOnly = True
        '
        'DivisionIDColumn13
        '
        Me.DivisionIDColumn13.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn13.HeaderText = "DivisionID"
        Me.DivisionIDColumn13.Name = "DivisionIDColumn13"
        Me.DivisionIDColumn13.ReadOnly = True
        '
        'APProcessPaymentBatchBindingSource
        '
        Me.APProcessPaymentBatchBindingSource.DataMember = "APProcessPaymentBatch"
        Me.APProcessPaymentBatchBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvAPInvoiceBatch
        '
        Me.dgvAPInvoiceBatch.AllowUserToAddRows = False
        Me.dgvAPInvoiceBatch.AllowUserToDeleteRows = False
        Me.dgvAPInvoiceBatch.AutoGenerateColumns = False
        Me.dgvAPInvoiceBatch.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAPInvoiceBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAPInvoiceBatch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BatchNumberColumn12, Me.DivisionIDColumn12})
        Me.dgvAPInvoiceBatch.DataSource = Me.ReceiptOfInvoiceBatchHeaderBindingSource
        Me.dgvAPInvoiceBatch.Location = New System.Drawing.Point(3, 324)
        Me.dgvAPInvoiceBatch.Name = "dgvAPInvoiceBatch"
        Me.dgvAPInvoiceBatch.ReadOnly = True
        Me.dgvAPInvoiceBatch.Size = New System.Drawing.Size(300, 70)
        Me.dgvAPInvoiceBatch.TabIndex = 2
        '
        'BatchNumberColumn12
        '
        Me.BatchNumberColumn12.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn12.HeaderText = "BatchNumber"
        Me.BatchNumberColumn12.Name = "BatchNumberColumn12"
        Me.BatchNumberColumn12.ReadOnly = True
        '
        'DivisionIDColumn12
        '
        Me.DivisionIDColumn12.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn12.HeaderText = "DivisionID"
        Me.DivisionIDColumn12.Name = "DivisionIDColumn12"
        Me.DivisionIDColumn12.ReadOnly = True
        '
        'ReceiptOfInvoiceBatchHeaderBindingSource
        '
        Me.ReceiptOfInvoiceBatchHeaderBindingSource.DataMember = "ReceiptOfInvoiceBatchHeader"
        Me.ReceiptOfInvoiceBatchHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvInvoiceHeaderTable
        '
        Me.dgvInvoiceHeaderTable.AllowUserToAddRows = False
        Me.dgvInvoiceHeaderTable.AllowUserToDeleteRows = False
        Me.dgvInvoiceHeaderTable.AutoGenerateColumns = False
        Me.dgvInvoiceHeaderTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInvoiceHeaderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoiceHeaderTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvoiceNumberColumn10, Me.DivisionIDColumn10})
        Me.dgvInvoiceHeaderTable.DataSource = Me.InvoiceHeaderTableBindingSource
        Me.dgvInvoiceHeaderTable.GridColor = System.Drawing.Color.Green
        Me.dgvInvoiceHeaderTable.Location = New System.Drawing.Point(3, 162)
        Me.dgvInvoiceHeaderTable.Name = "dgvInvoiceHeaderTable"
        Me.dgvInvoiceHeaderTable.ReadOnly = True
        Me.dgvInvoiceHeaderTable.Size = New System.Drawing.Size(300, 70)
        Me.dgvInvoiceHeaderTable.TabIndex = 2
        '
        'InvoiceNumberColumn10
        '
        Me.InvoiceNumberColumn10.DataPropertyName = "InvoiceNumber"
        Me.InvoiceNumberColumn10.HeaderText = "InvoiceNumber"
        Me.InvoiceNumberColumn10.Name = "InvoiceNumberColumn10"
        Me.InvoiceNumberColumn10.ReadOnly = True
        '
        'DivisionIDColumn10
        '
        Me.DivisionIDColumn10.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn10.HeaderText = "DivisionID"
        Me.DivisionIDColumn10.Name = "DivisionIDColumn10"
        Me.DivisionIDColumn10.ReadOnly = True
        '
        'InvoiceHeaderTableBindingSource
        '
        Me.InvoiceHeaderTableBindingSource.DataMember = "InvoiceHeaderTable"
        Me.InvoiceHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvARPaymentBatch
        '
        Me.dgvARPaymentBatch.AllowUserToAddRows = False
        Me.dgvARPaymentBatch.AllowUserToDeleteRows = False
        Me.dgvARPaymentBatch.AutoGenerateColumns = False
        Me.dgvARPaymentBatch.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvARPaymentBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvARPaymentBatch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BatchNumberColumn9, Me.DivisionIDColumn9})
        Me.dgvARPaymentBatch.DataSource = Me.ARProcessPaymentBatchBindingSource
        Me.dgvARPaymentBatch.GridColor = System.Drawing.Color.Navy
        Me.dgvARPaymentBatch.Location = New System.Drawing.Point(3, 81)
        Me.dgvARPaymentBatch.Name = "dgvARPaymentBatch"
        Me.dgvARPaymentBatch.ReadOnly = True
        Me.dgvARPaymentBatch.Size = New System.Drawing.Size(300, 70)
        Me.dgvARPaymentBatch.TabIndex = 1
        '
        'BatchNumberColumn9
        '
        Me.BatchNumberColumn9.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn9.HeaderText = "BatchNumber"
        Me.BatchNumberColumn9.Name = "BatchNumberColumn9"
        Me.BatchNumberColumn9.ReadOnly = True
        '
        'DivisionIDColumn9
        '
        Me.DivisionIDColumn9.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn9.HeaderText = "DivisionID"
        Me.DivisionIDColumn9.Name = "DivisionIDColumn9"
        Me.DivisionIDColumn9.ReadOnly = True
        '
        'ARProcessPaymentBatchBindingSource
        '
        Me.ARProcessPaymentBatchBindingSource.DataMember = "ARProcessPaymentBatch"
        Me.ARProcessPaymentBatchBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvARInvoiceBatch
        '
        Me.dgvARInvoiceBatch.AllowUserToAddRows = False
        Me.dgvARInvoiceBatch.AllowUserToDeleteRows = False
        Me.dgvARInvoiceBatch.AutoGenerateColumns = False
        Me.dgvARInvoiceBatch.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvARInvoiceBatch.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvARInvoiceBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvARInvoiceBatch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BatchNumberColumn8, Me.DivisionIDColumn8})
        Me.dgvARInvoiceBatch.DataSource = Me.InvoiceProcessingBatchHeaderBindingSource
        Me.dgvARInvoiceBatch.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvARInvoiceBatch.Location = New System.Drawing.Point(3, 2)
        Me.dgvARInvoiceBatch.Name = "dgvARInvoiceBatch"
        Me.dgvARInvoiceBatch.ReadOnly = True
        Me.dgvARInvoiceBatch.Size = New System.Drawing.Size(300, 70)
        Me.dgvARInvoiceBatch.TabIndex = 0
        '
        'BatchNumberColumn8
        '
        Me.BatchNumberColumn8.DataPropertyName = "BatchNumber"
        Me.BatchNumberColumn8.HeaderText = "BatchNumber"
        Me.BatchNumberColumn8.Name = "BatchNumberColumn8"
        Me.BatchNumberColumn8.ReadOnly = True
        '
        'DivisionIDColumn8
        '
        Me.DivisionIDColumn8.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn8.HeaderText = "DivisionID"
        Me.DivisionIDColumn8.Name = "DivisionIDColumn8"
        Me.DivisionIDColumn8.ReadOnly = True
        '
        'InvoiceProcessingBatchHeaderBindingSource
        '
        Me.InvoiceProcessingBatchHeaderBindingSource.DataMember = "InvoiceProcessingBatchHeader"
        Me.InvoiceProcessingBatchHeaderBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'TabCostTiers
        '
        Me.TabCostTiers.Controls.Add(Me.dgvSteelUsage)
        Me.TabCostTiers.Controls.Add(Me.dgvWireYard)
        Me.TabCostTiers.Controls.Add(Me.dgvInventoryCostingEdit)
        Me.TabCostTiers.Controls.Add(Me.dgvAssemblyLines)
        Me.TabCostTiers.Controls.Add(Me.dgvAssemblyTable)
        Me.TabCostTiers.Controls.Add(Me.dgvItemList)
        Me.TabCostTiers.Controls.Add(Me.dgvPullTestData)
        Me.TabCostTiers.Controls.Add(Me.dgvLotNumberRMID)
        Me.TabCostTiers.Location = New System.Drawing.Point(4, 22)
        Me.TabCostTiers.Name = "TabCostTiers"
        Me.TabCostTiers.Size = New System.Drawing.Size(605, 682)
        Me.TabCostTiers.TabIndex = 3
        Me.TabCostTiers.Text = "TabPage4"
        Me.TabCostTiers.UseVisualStyleBackColor = True
        '
        'dgvSteelUsage
        '
        Me.dgvSteelUsage.AllowUserToAddRows = False
        Me.dgvSteelUsage.AllowUserToDeleteRows = False
        Me.dgvSteelUsage.AutoGenerateColumns = False
        Me.dgvSteelUsage.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelUsage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelUsage.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelUsageKeyColumn33, Me.UsageDateColumn33, Me.UsageWeightColumn33, Me.RMIDColumn33, Me.SteelCostColumn33, Me.ExtendedCostColumn33})
        Me.dgvSteelUsage.DataSource = Me.SteelUsageTableBindingSource
        Me.dgvSteelUsage.Location = New System.Drawing.Point(309, 506)
        Me.dgvSteelUsage.Name = "dgvSteelUsage"
        Me.dgvSteelUsage.ReadOnly = True
        Me.dgvSteelUsage.Size = New System.Drawing.Size(296, 79)
        Me.dgvSteelUsage.TabIndex = 10
        '
        'SteelUsageKeyColumn33
        '
        Me.SteelUsageKeyColumn33.DataPropertyName = "SteelUsageKey"
        Me.SteelUsageKeyColumn33.HeaderText = "SteelUsageKey"
        Me.SteelUsageKeyColumn33.Name = "SteelUsageKeyColumn33"
        Me.SteelUsageKeyColumn33.ReadOnly = True
        '
        'UsageDateColumn33
        '
        Me.UsageDateColumn33.DataPropertyName = "UsageDate"
        Me.UsageDateColumn33.HeaderText = "UsageDate"
        Me.UsageDateColumn33.Name = "UsageDateColumn33"
        Me.UsageDateColumn33.ReadOnly = True
        '
        'UsageWeightColumn33
        '
        Me.UsageWeightColumn33.DataPropertyName = "UsageWeight"
        Me.UsageWeightColumn33.HeaderText = "UsageWeight"
        Me.UsageWeightColumn33.Name = "UsageWeightColumn33"
        Me.UsageWeightColumn33.ReadOnly = True
        '
        'RMIDColumn33
        '
        Me.RMIDColumn33.DataPropertyName = "RMID"
        Me.RMIDColumn33.HeaderText = "RMID"
        Me.RMIDColumn33.Name = "RMIDColumn33"
        Me.RMIDColumn33.ReadOnly = True
        '
        'SteelCostColumn33
        '
        Me.SteelCostColumn33.DataPropertyName = "SteelCost"
        Me.SteelCostColumn33.HeaderText = "SteelCost"
        Me.SteelCostColumn33.Name = "SteelCostColumn33"
        Me.SteelCostColumn33.ReadOnly = True
        '
        'ExtendedCostColumn33
        '
        Me.ExtendedCostColumn33.DataPropertyName = "ExtendedCost"
        Me.ExtendedCostColumn33.HeaderText = "ExtendedCost"
        Me.ExtendedCostColumn33.Name = "ExtendedCostColumn33"
        Me.ExtendedCostColumn33.ReadOnly = True
        '
        'SteelUsageTableBindingSource
        '
        Me.SteelUsageTableBindingSource.DataMember = "SteelUsageTable"
        Me.SteelUsageTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvWireYard
        '
        Me.dgvWireYard.AllowUserToAddRows = False
        Me.dgvWireYard.AllowUserToDeleteRows = False
        Me.dgvWireYard.AutoGenerateColumns = False
        Me.dgvWireYard.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvWireYard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWireYard.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SteelReturnKeyColumn99, Me.ReturnDateColumn99, Me.ReturnWeightColumn99, Me.RMIDColumn99})
        Me.dgvWireYard.DataSource = Me.SteelYardEntryTableBindingSource
        Me.dgvWireYard.Location = New System.Drawing.Point(0, 506)
        Me.dgvWireYard.Name = "dgvWireYard"
        Me.dgvWireYard.Size = New System.Drawing.Size(300, 79)
        Me.dgvWireYard.TabIndex = 9
        '
        'SteelReturnKeyColumn99
        '
        Me.SteelReturnKeyColumn99.DataPropertyName = "SteelReturnKey"
        Me.SteelReturnKeyColumn99.HeaderText = "SteelReturnKey"
        Me.SteelReturnKeyColumn99.Name = "SteelReturnKeyColumn99"
        '
        'ReturnDateColumn99
        '
        Me.ReturnDateColumn99.DataPropertyName = "ReturnDate"
        Me.ReturnDateColumn99.HeaderText = "ReturnDate"
        Me.ReturnDateColumn99.Name = "ReturnDateColumn99"
        '
        'ReturnWeightColumn99
        '
        Me.ReturnWeightColumn99.DataPropertyName = "ReturnWeight"
        Me.ReturnWeightColumn99.HeaderText = "ReturnWeight"
        Me.ReturnWeightColumn99.Name = "ReturnWeightColumn99"
        '
        'RMIDColumn99
        '
        Me.RMIDColumn99.DataPropertyName = "RMID"
        Me.RMIDColumn99.HeaderText = "RMID"
        Me.RMIDColumn99.Name = "RMIDColumn99"
        '
        'SteelYardEntryTableBindingSource
        '
        Me.SteelYardEntryTableBindingSource.DataMember = "SteelYardEntryTable"
        Me.SteelYardEntryTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvInventoryCostingEdit
        '
        Me.dgvInventoryCostingEdit.AllowUserToAddRows = False
        Me.dgvInventoryCostingEdit.AllowUserToDeleteRows = False
        Me.dgvInventoryCostingEdit.AutoGenerateColumns = False
        Me.dgvInventoryCostingEdit.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvInventoryCostingEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventoryCostingEdit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PartNumberColumn55, Me.DivisionIDColumn55, Me.CostingDateColumn55, Me.ItemCostColumn55, Me.CostQuantityColumn55, Me.LowerLimitColumn55, Me.UpperLimitColumn55, Me.StatusColumn55, Me.TransactionNumberColumn55, Me.ReferenceNumberColumn55, Me.ReferenceLineColumn55})
        Me.dgvInventoryCostingEdit.DataSource = Me.InventoryCostingBindingSource
        Me.dgvInventoryCostingEdit.GridColor = System.Drawing.Color.Blue
        Me.dgvInventoryCostingEdit.Location = New System.Drawing.Point(0, 407)
        Me.dgvInventoryCostingEdit.Name = "dgvInventoryCostingEdit"
        Me.dgvInventoryCostingEdit.ReadOnly = True
        Me.dgvInventoryCostingEdit.Size = New System.Drawing.Size(300, 79)
        Me.dgvInventoryCostingEdit.TabIndex = 8
        '
        'PartNumberColumn55
        '
        Me.PartNumberColumn55.DataPropertyName = "PartNumber"
        Me.PartNumberColumn55.HeaderText = "PartNumber"
        Me.PartNumberColumn55.Name = "PartNumberColumn55"
        Me.PartNumberColumn55.ReadOnly = True
        '
        'DivisionIDColumn55
        '
        Me.DivisionIDColumn55.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn55.HeaderText = "DivisionID"
        Me.DivisionIDColumn55.Name = "DivisionIDColumn55"
        Me.DivisionIDColumn55.ReadOnly = True
        '
        'CostingDateColumn55
        '
        Me.CostingDateColumn55.DataPropertyName = "CostingDate"
        Me.CostingDateColumn55.HeaderText = "CostingDate"
        Me.CostingDateColumn55.Name = "CostingDateColumn55"
        Me.CostingDateColumn55.ReadOnly = True
        '
        'ItemCostColumn55
        '
        Me.ItemCostColumn55.DataPropertyName = "ItemCost"
        Me.ItemCostColumn55.HeaderText = "ItemCost"
        Me.ItemCostColumn55.Name = "ItemCostColumn55"
        Me.ItemCostColumn55.ReadOnly = True
        '
        'CostQuantityColumn55
        '
        Me.CostQuantityColumn55.DataPropertyName = "CostQuantity"
        Me.CostQuantityColumn55.HeaderText = "CostQuantity"
        Me.CostQuantityColumn55.Name = "CostQuantityColumn55"
        Me.CostQuantityColumn55.ReadOnly = True
        '
        'LowerLimitColumn55
        '
        Me.LowerLimitColumn55.DataPropertyName = "LowerLimit"
        Me.LowerLimitColumn55.HeaderText = "LowerLimit"
        Me.LowerLimitColumn55.Name = "LowerLimitColumn55"
        Me.LowerLimitColumn55.ReadOnly = True
        '
        'UpperLimitColumn55
        '
        Me.UpperLimitColumn55.DataPropertyName = "UpperLimit"
        Me.UpperLimitColumn55.HeaderText = "UpperLimit"
        Me.UpperLimitColumn55.Name = "UpperLimitColumn55"
        Me.UpperLimitColumn55.ReadOnly = True
        '
        'StatusColumn55
        '
        Me.StatusColumn55.DataPropertyName = "Status"
        Me.StatusColumn55.HeaderText = "Status"
        Me.StatusColumn55.Name = "StatusColumn55"
        Me.StatusColumn55.ReadOnly = True
        '
        'TransactionNumberColumn55
        '
        Me.TransactionNumberColumn55.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn55.HeaderText = "TransactionNumber"
        Me.TransactionNumberColumn55.Name = "TransactionNumberColumn55"
        Me.TransactionNumberColumn55.ReadOnly = True
        '
        'ReferenceNumberColumn55
        '
        Me.ReferenceNumberColumn55.DataPropertyName = "ReferenceNumber"
        Me.ReferenceNumberColumn55.HeaderText = "ReferenceNumber"
        Me.ReferenceNumberColumn55.Name = "ReferenceNumberColumn55"
        Me.ReferenceNumberColumn55.ReadOnly = True
        '
        'ReferenceLineColumn55
        '
        Me.ReferenceLineColumn55.DataPropertyName = "ReferenceLine"
        Me.ReferenceLineColumn55.HeaderText = "ReferenceLine"
        Me.ReferenceLineColumn55.Name = "ReferenceLineColumn55"
        Me.ReferenceLineColumn55.ReadOnly = True
        '
        'InventoryCostingBindingSource
        '
        Me.InventoryCostingBindingSource.DataMember = "InventoryCosting"
        Me.InventoryCostingBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvAssemblyLines
        '
        Me.dgvAssemblyLines.AllowUserToAddRows = False
        Me.dgvAssemblyLines.AllowUserToDeleteRows = False
        Me.dgvAssemblyLines.AutoGenerateColumns = False
        Me.dgvAssemblyLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAssemblyLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAssemblyLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssemblyLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumberColumn14, Me.ComponentPartNumberColumn14, Me.ComponentPartDescriptionColumn14, Me.DivisionIDColumn14, Me.ComponentLineNumberColumn14, Me.UnitCostColumn14})
        Me.dgvAssemblyLines.DataSource = Me.AssemblyLineTableBindingSource
        Me.dgvAssemblyLines.GridColor = System.Drawing.Color.Red
        Me.dgvAssemblyLines.Location = New System.Drawing.Point(0, 310)
        Me.dgvAssemblyLines.Name = "dgvAssemblyLines"
        Me.dgvAssemblyLines.ReadOnly = True
        Me.dgvAssemblyLines.Size = New System.Drawing.Size(300, 79)
        Me.dgvAssemblyLines.TabIndex = 7
        '
        'AssemblyPartNumberColumn14
        '
        Me.AssemblyPartNumberColumn14.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn14.HeaderText = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn14.Name = "AssemblyPartNumberColumn14"
        Me.AssemblyPartNumberColumn14.ReadOnly = True
        '
        'ComponentPartNumberColumn14
        '
        Me.ComponentPartNumberColumn14.DataPropertyName = "ComponentPartNumber"
        Me.ComponentPartNumberColumn14.HeaderText = "ComponentPartNumber"
        Me.ComponentPartNumberColumn14.Name = "ComponentPartNumberColumn14"
        Me.ComponentPartNumberColumn14.ReadOnly = True
        '
        'ComponentPartDescriptionColumn14
        '
        Me.ComponentPartDescriptionColumn14.DataPropertyName = "ComponentPartDescription"
        Me.ComponentPartDescriptionColumn14.HeaderText = "ComponentPartDescription"
        Me.ComponentPartDescriptionColumn14.Name = "ComponentPartDescriptionColumn14"
        Me.ComponentPartDescriptionColumn14.ReadOnly = True
        '
        'DivisionIDColumn14
        '
        Me.DivisionIDColumn14.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn14.HeaderText = "DivisionID"
        Me.DivisionIDColumn14.Name = "DivisionIDColumn14"
        Me.DivisionIDColumn14.ReadOnly = True
        '
        'ComponentLineNumberColumn14
        '
        Me.ComponentLineNumberColumn14.DataPropertyName = "ComponentLineNumber"
        Me.ComponentLineNumberColumn14.HeaderText = "ComponentLineNumber"
        Me.ComponentLineNumberColumn14.Name = "ComponentLineNumberColumn14"
        Me.ComponentLineNumberColumn14.ReadOnly = True
        '
        'UnitCostColumn14
        '
        Me.UnitCostColumn14.DataPropertyName = "UnitCost"
        Me.UnitCostColumn14.HeaderText = "UnitCost"
        Me.UnitCostColumn14.Name = "UnitCostColumn14"
        Me.UnitCostColumn14.ReadOnly = True
        '
        'AssemblyLineTableBindingSource
        '
        Me.AssemblyLineTableBindingSource.DataMember = "AssemblyLineTable"
        Me.AssemblyLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvAssemblyTable
        '
        Me.dgvAssemblyTable.AllowUserToAddRows = False
        Me.dgvAssemblyTable.AllowUserToDeleteRows = False
        Me.dgvAssemblyTable.AutoGenerateColumns = False
        Me.dgvAssemblyTable.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvAssemblyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssemblyTable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AssemblyPartNumberColumn11, Me.DivisionIDColumn11, Me.TotalCostColumn11})
        Me.dgvAssemblyTable.DataSource = Me.AssemblyHeaderTableBindingSource
        Me.dgvAssemblyTable.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvAssemblyTable.Location = New System.Drawing.Point(0, 234)
        Me.dgvAssemblyTable.Name = "dgvAssemblyTable"
        Me.dgvAssemblyTable.ReadOnly = True
        Me.dgvAssemblyTable.Size = New System.Drawing.Size(300, 70)
        Me.dgvAssemblyTable.TabIndex = 3
        '
        'AssemblyPartNumberColumn11
        '
        Me.AssemblyPartNumberColumn11.DataPropertyName = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn11.HeaderText = "AssemblyPartNumber"
        Me.AssemblyPartNumberColumn11.Name = "AssemblyPartNumberColumn11"
        Me.AssemblyPartNumberColumn11.ReadOnly = True
        '
        'DivisionIDColumn11
        '
        Me.DivisionIDColumn11.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn11.HeaderText = "DivisionID"
        Me.DivisionIDColumn11.Name = "DivisionIDColumn11"
        Me.DivisionIDColumn11.ReadOnly = True
        '
        'TotalCostColumn11
        '
        Me.TotalCostColumn11.DataPropertyName = "TotalCost"
        Me.TotalCostColumn11.HeaderText = "TotalCost"
        Me.TotalCostColumn11.Name = "TotalCostColumn11"
        Me.TotalCostColumn11.ReadOnly = True
        '
        'AssemblyHeaderTableBindingSource
        '
        Me.AssemblyHeaderTableBindingSource.DataMember = "AssemblyHeaderTable"
        Me.AssemblyHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvItemList
        '
        Me.dgvItemList.AllowUserToAddRows = False
        Me.dgvItemList.AllowUserToDeleteRows = False
        Me.dgvItemList.AutoGenerateColumns = False
        Me.dgvItemList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItemList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CostItemIDColumn, Me.CostDivisionIDColumn, Me.CostItemClassColumn, Me.CostStandardCostColumn, Me.CostStandardPriceColumn})
        Me.dgvItemList.DataSource = Me.ItemListBindingSource
        Me.dgvItemList.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvItemList.Location = New System.Drawing.Point(0, 156)
        Me.dgvItemList.Name = "dgvItemList"
        Me.dgvItemList.ReadOnly = True
        Me.dgvItemList.Size = New System.Drawing.Size(300, 70)
        Me.dgvItemList.TabIndex = 2
        '
        'CostItemIDColumn
        '
        Me.CostItemIDColumn.DataPropertyName = "ItemID"
        Me.CostItemIDColumn.HeaderText = "ItemID"
        Me.CostItemIDColumn.Name = "CostItemIDColumn"
        Me.CostItemIDColumn.ReadOnly = True
        '
        'CostDivisionIDColumn
        '
        Me.CostDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.CostDivisionIDColumn.HeaderText = "DivisionID"
        Me.CostDivisionIDColumn.Name = "CostDivisionIDColumn"
        Me.CostDivisionIDColumn.ReadOnly = True
        '
        'CostItemClassColumn
        '
        Me.CostItemClassColumn.DataPropertyName = "ItemClass"
        Me.CostItemClassColumn.HeaderText = "ItemClass"
        Me.CostItemClassColumn.Name = "CostItemClassColumn"
        Me.CostItemClassColumn.ReadOnly = True
        '
        'CostStandardCostColumn
        '
        Me.CostStandardCostColumn.DataPropertyName = "StandardCost"
        Me.CostStandardCostColumn.HeaderText = "StandardCost"
        Me.CostStandardCostColumn.Name = "CostStandardCostColumn"
        Me.CostStandardCostColumn.ReadOnly = True
        '
        'CostStandardPriceColumn
        '
        Me.CostStandardPriceColumn.DataPropertyName = "StandardPrice"
        Me.CostStandardPriceColumn.HeaderText = "StandardPrice"
        Me.CostStandardPriceColumn.Name = "CostStandardPriceColumn"
        Me.CostStandardPriceColumn.ReadOnly = True
        '
        'dgvPullTestData
        '
        Me.dgvPullTestData.AllowUserToAddRows = False
        Me.dgvPullTestData.AllowUserToDeleteRows = False
        Me.dgvPullTestData.AutoGenerateColumns = False
        Me.dgvPullTestData.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvPullTestData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPullTestData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FOXNumberColumn11, Me.TestNumberColumn11})
        Me.dgvPullTestData.DataSource = Me.PullTestDataBindingSource
        Me.dgvPullTestData.Location = New System.Drawing.Point(0, 78)
        Me.dgvPullTestData.Name = "dgvPullTestData"
        Me.dgvPullTestData.ReadOnly = True
        Me.dgvPullTestData.Size = New System.Drawing.Size(300, 70)
        Me.dgvPullTestData.TabIndex = 1
        '
        'FOXNumberColumn11
        '
        Me.FOXNumberColumn11.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn11.HeaderText = "FOXNumber"
        Me.FOXNumberColumn11.Name = "FOXNumberColumn11"
        Me.FOXNumberColumn11.ReadOnly = True
        '
        'TestNumberColumn11
        '
        Me.TestNumberColumn11.DataPropertyName = "TestNumber"
        Me.TestNumberColumn11.HeaderText = "TestNumber"
        Me.TestNumberColumn11.Name = "TestNumberColumn11"
        Me.TestNumberColumn11.ReadOnly = True
        '
        'PullTestDataBindingSource
        '
        Me.PullTestDataBindingSource.DataMember = "PullTestData"
        Me.PullTestDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'dgvLotNumberRMID
        '
        Me.dgvLotNumberRMID.AllowUserToAddRows = False
        Me.dgvLotNumberRMID.AllowUserToDeleteRows = False
        Me.dgvLotNumberRMID.AutoGenerateColumns = False
        Me.dgvLotNumberRMID.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvLotNumberRMID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLotNumberRMID.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LotNumberColumn9, Me.PartNumberColumn9, Me.HeatNumberIDColumn9, Me.HeatNumberColumn9})
        Me.dgvLotNumberRMID.DataSource = Me.LotNumberBindingSource
        Me.dgvLotNumberRMID.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvLotNumberRMID.Location = New System.Drawing.Point(0, 0)
        Me.dgvLotNumberRMID.Name = "dgvLotNumberRMID"
        Me.dgvLotNumberRMID.ReadOnly = True
        Me.dgvLotNumberRMID.Size = New System.Drawing.Size(300, 70)
        Me.dgvLotNumberRMID.TabIndex = 0
        '
        'LotNumberColumn9
        '
        Me.LotNumberColumn9.DataPropertyName = "LotNumber"
        Me.LotNumberColumn9.HeaderText = "LotNumber"
        Me.LotNumberColumn9.Name = "LotNumberColumn9"
        Me.LotNumberColumn9.ReadOnly = True
        '
        'PartNumberColumn9
        '
        Me.PartNumberColumn9.DataPropertyName = "PartNumber"
        Me.PartNumberColumn9.HeaderText = "PartNumber"
        Me.PartNumberColumn9.Name = "PartNumberColumn9"
        Me.PartNumberColumn9.ReadOnly = True
        '
        'HeatNumberIDColumn9
        '
        Me.HeatNumberIDColumn9.DataPropertyName = "HeatNumberID"
        Me.HeatNumberIDColumn9.HeaderText = "HeatNumberID"
        Me.HeatNumberIDColumn9.Name = "HeatNumberIDColumn9"
        Me.HeatNumberIDColumn9.ReadOnly = True
        '
        'HeatNumberColumn9
        '
        Me.HeatNumberColumn9.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn9.HeaderText = "HeatNumber"
        Me.HeatNumberColumn9.Name = "HeatNumberColumn9"
        Me.HeatNumberColumn9.ReadOnly = True
        '
        'LotNumberBindingSource
        '
        Me.LotNumberBindingSource.DataMember = "LotNumber"
        Me.LotNumberBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.dgvCostTiers)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(605, 682)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Cost Tiers"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgvCostTiers
        '
        Me.dgvCostTiers.AllowUserToAddRows = False
        Me.dgvCostTiers.AllowUserToDeleteRows = False
        Me.dgvCostTiers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCostTiers.AutoGenerateColumns = False
        Me.dgvCostTiers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvCostTiers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCostTiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCostTiers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CTPartNumberColumn, Me.CTDivisionIDColumn, Me.CTCostingDateColumn, Me.CTItemCostColumn, Me.CTCostQuantityColumn, Me.CTLowerLimitColumn, Me.CTUpperLimitColumn, Me.CTStatusColumn, Me.CTTransactionNumberColumn, Me.CTReferenceNumberColumn, Me.CTReferenceLineColumn})
        Me.dgvCostTiers.DataSource = Me.InventoryCostingBindingSource
        Me.dgvCostTiers.GridColor = System.Drawing.Color.Red
        Me.dgvCostTiers.Location = New System.Drawing.Point(0, 0)
        Me.dgvCostTiers.Name = "dgvCostTiers"
        Me.dgvCostTiers.ReadOnly = True
        Me.dgvCostTiers.Size = New System.Drawing.Size(602, 629)
        Me.dgvCostTiers.TabIndex = 0
        '
        'CTPartNumberColumn
        '
        Me.CTPartNumberColumn.DataPropertyName = "PartNumber"
        Me.CTPartNumberColumn.HeaderText = "PartNumber"
        Me.CTPartNumberColumn.Name = "CTPartNumberColumn"
        Me.CTPartNumberColumn.ReadOnly = True
        '
        'CTDivisionIDColumn
        '
        Me.CTDivisionIDColumn.DataPropertyName = "DivisionID"
        Me.CTDivisionIDColumn.HeaderText = "DivisionID"
        Me.CTDivisionIDColumn.Name = "CTDivisionIDColumn"
        Me.CTDivisionIDColumn.ReadOnly = True
        '
        'CTCostingDateColumn
        '
        Me.CTCostingDateColumn.DataPropertyName = "CostingDate"
        Me.CTCostingDateColumn.HeaderText = "CostingDate"
        Me.CTCostingDateColumn.Name = "CTCostingDateColumn"
        Me.CTCostingDateColumn.ReadOnly = True
        '
        'CTItemCostColumn
        '
        Me.CTItemCostColumn.DataPropertyName = "ItemCost"
        Me.CTItemCostColumn.HeaderText = "ItemCost"
        Me.CTItemCostColumn.Name = "CTItemCostColumn"
        Me.CTItemCostColumn.ReadOnly = True
        '
        'CTCostQuantityColumn
        '
        Me.CTCostQuantityColumn.DataPropertyName = "CostQuantity"
        Me.CTCostQuantityColumn.HeaderText = "CostQuantity"
        Me.CTCostQuantityColumn.Name = "CTCostQuantityColumn"
        Me.CTCostQuantityColumn.ReadOnly = True
        '
        'CTLowerLimitColumn
        '
        Me.CTLowerLimitColumn.DataPropertyName = "LowerLimit"
        Me.CTLowerLimitColumn.HeaderText = "LowerLimit"
        Me.CTLowerLimitColumn.Name = "CTLowerLimitColumn"
        Me.CTLowerLimitColumn.ReadOnly = True
        '
        'CTUpperLimitColumn
        '
        Me.CTUpperLimitColumn.DataPropertyName = "UpperLimit"
        Me.CTUpperLimitColumn.HeaderText = "UpperLimit"
        Me.CTUpperLimitColumn.Name = "CTUpperLimitColumn"
        Me.CTUpperLimitColumn.ReadOnly = True
        '
        'CTStatusColumn
        '
        Me.CTStatusColumn.DataPropertyName = "Status"
        Me.CTStatusColumn.HeaderText = "Status"
        Me.CTStatusColumn.Name = "CTStatusColumn"
        Me.CTStatusColumn.ReadOnly = True
        '
        'CTTransactionNumberColumn
        '
        Me.CTTransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.CTTransactionNumberColumn.HeaderText = "TransactionNumber"
        Me.CTTransactionNumberColumn.Name = "CTTransactionNumberColumn"
        Me.CTTransactionNumberColumn.ReadOnly = True
        '
        'CTReferenceNumberColumn
        '
        Me.CTReferenceNumberColumn.DataPropertyName = "ReferenceNumber"
        Me.CTReferenceNumberColumn.HeaderText = "ReferenceNumber"
        Me.CTReferenceNumberColumn.Name = "CTReferenceNumberColumn"
        Me.CTReferenceNumberColumn.ReadOnly = True
        '
        'CTReferenceLineColumn
        '
        Me.CTReferenceLineColumn.DataPropertyName = "ReferenceLine"
        Me.CTReferenceLineColumn.HeaderText = "ReferenceLine"
        Me.CTReferenceLineColumn.Name = "CTReferenceLineColumn"
        Me.CTReferenceLineColumn.ReadOnly = True
        '
        'tabUPS
        '
        Me.tabUPS.Controls.Add(Me.dgvUPSShippingData)
        Me.tabUPS.Location = New System.Drawing.Point(4, 22)
        Me.tabUPS.Name = "tabUPS"
        Me.tabUPS.Size = New System.Drawing.Size(605, 682)
        Me.tabUPS.TabIndex = 5
        Me.tabUPS.Text = "UPS Export"
        Me.tabUPS.UseVisualStyleBackColor = True
        '
        'dgvUPSShippingData
        '
        Me.dgvUPSShippingData.AllowUserToAddRows = False
        Me.dgvUPSShippingData.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvUPSShippingData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvUPSShippingData.AutoGenerateColumns = False
        Me.dgvUPSShippingData.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvUPSShippingData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvUPSShippingData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUPSShippingData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PickTicketNumberColumn33, Me.QuotedFreightChargeColumn33, Me.TotalWeightColumn33, Me.TrackingNumberColumn33, Me.VoidIndicatorColumn33, Me.TransactionNumberColumn})
        Me.dgvUPSShippingData.DataSource = Me.UPSShippingDataBindingSource
        Me.dgvUPSShippingData.Location = New System.Drawing.Point(3, 3)
        Me.dgvUPSShippingData.Name = "dgvUPSShippingData"
        Me.dgvUPSShippingData.ReadOnly = True
        Me.dgvUPSShippingData.Size = New System.Drawing.Size(599, 621)
        Me.dgvUPSShippingData.TabIndex = 0
        '
        'PickTicketNumberColumn33
        '
        Me.PickTicketNumberColumn33.DataPropertyName = "PickTicketNumber"
        Me.PickTicketNumberColumn33.HeaderText = "Pick Ticket #"
        Me.PickTicketNumberColumn33.Name = "PickTicketNumberColumn33"
        Me.PickTicketNumberColumn33.ReadOnly = True
        Me.PickTicketNumberColumn33.Width = 110
        '
        'QuotedFreightChargeColumn33
        '
        Me.QuotedFreightChargeColumn33.DataPropertyName = "QuotedFreightCharge"
        Me.QuotedFreightChargeColumn33.HeaderText = "Freight Charge"
        Me.QuotedFreightChargeColumn33.Name = "QuotedFreightChargeColumn33"
        Me.QuotedFreightChargeColumn33.ReadOnly = True
        '
        'TotalWeightColumn33
        '
        Me.TotalWeightColumn33.DataPropertyName = "TotalWeight"
        Me.TotalWeightColumn33.HeaderText = "Total Weight"
        Me.TotalWeightColumn33.Name = "TotalWeightColumn33"
        Me.TotalWeightColumn33.ReadOnly = True
        '
        'TrackingNumberColumn33
        '
        Me.TrackingNumberColumn33.DataPropertyName = "TrackingNumber"
        Me.TrackingNumberColumn33.HeaderText = "Tracking Number"
        Me.TrackingNumberColumn33.Name = "TrackingNumberColumn33"
        Me.TrackingNumberColumn33.ReadOnly = True
        Me.TrackingNumberColumn33.Width = 130
        '
        'VoidIndicatorColumn33
        '
        Me.VoidIndicatorColumn33.DataPropertyName = "VoidIndicator"
        Me.VoidIndicatorColumn33.HeaderText = "Deleted?"
        Me.VoidIndicatorColumn33.Name = "VoidIndicatorColumn33"
        Me.VoidIndicatorColumn33.ReadOnly = True
        '
        'TransactionNumberColumn
        '
        Me.TransactionNumberColumn.DataPropertyName = "TransactionNumber"
        Me.TransactionNumberColumn.HeaderText = "Trans. #"
        Me.TransactionNumberColumn.Name = "TransactionNumberColumn"
        Me.TransactionNumberColumn.ReadOnly = True
        '
        'UPSShippingDataBindingSource
        '
        Me.UPSShippingDataBindingSource.DataMember = "UPSShippingData"
        Me.UPSShippingDataBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'tabSteel
        '
        Me.tabSteel.Controls.Add(Me.dgvSteelInPullTests)
        Me.tabSteel.Location = New System.Drawing.Point(4, 22)
        Me.tabSteel.Name = "tabSteel"
        Me.tabSteel.Size = New System.Drawing.Size(605, 682)
        Me.tabSteel.TabIndex = 6
        Me.tabSteel.Text = "Steel Tables"
        Me.tabSteel.UseVisualStyleBackColor = True
        '
        'dgvSteelInPullTests
        '
        Me.dgvSteelInPullTests.AllowUserToAddRows = False
        Me.dgvSteelInPullTests.AllowUserToDeleteRows = False
        Me.dgvSteelInPullTests.AutoGenerateColumns = False
        Me.dgvSteelInPullTests.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvSteelInPullTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSteelInPullTests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TestNumberColumn12, Me.FOXNumberColumn12, Me.PartNumberColumn12, Me.CarbonColumn12, Me.SteelSizeColumn12, Me.RMIDDColumn12, Me.HeatNumberColumn12, Me.HeatSteelTypeColumn12, Me.HeatSteelSizeColumn12, Me.HeatFileNumberColumn12, Me.HeatFileFromHeatColumn12})
        Me.dgvSteelInPullTests.DataSource = Me.PullTestCheckiSteelToHeatBindingSource
        Me.dgvSteelInPullTests.Location = New System.Drawing.Point(0, 0)
        Me.dgvSteelInPullTests.Name = "dgvSteelInPullTests"
        Me.dgvSteelInPullTests.ReadOnly = True
        Me.dgvSteelInPullTests.Size = New System.Drawing.Size(300, 70)
        Me.dgvSteelInPullTests.TabIndex = 0
        '
        'TestNumberColumn12
        '
        Me.TestNumberColumn12.DataPropertyName = "TestNumber"
        Me.TestNumberColumn12.HeaderText = "TestNumber"
        Me.TestNumberColumn12.Name = "TestNumberColumn12"
        Me.TestNumberColumn12.ReadOnly = True
        '
        'FOXNumberColumn12
        '
        Me.FOXNumberColumn12.DataPropertyName = "FOXNumber"
        Me.FOXNumberColumn12.HeaderText = "FOXNumber"
        Me.FOXNumberColumn12.Name = "FOXNumberColumn12"
        Me.FOXNumberColumn12.ReadOnly = True
        '
        'PartNumberColumn12
        '
        Me.PartNumberColumn12.DataPropertyName = "PartNumber"
        Me.PartNumberColumn12.HeaderText = "PartNumber"
        Me.PartNumberColumn12.Name = "PartNumberColumn12"
        Me.PartNumberColumn12.ReadOnly = True
        '
        'CarbonColumn12
        '
        Me.CarbonColumn12.DataPropertyName = "Carbon"
        Me.CarbonColumn12.HeaderText = "Carbon"
        Me.CarbonColumn12.Name = "CarbonColumn12"
        Me.CarbonColumn12.ReadOnly = True
        '
        'SteelSizeColumn12
        '
        Me.SteelSizeColumn12.DataPropertyName = "SteelSize"
        Me.SteelSizeColumn12.HeaderText = "SteelSize"
        Me.SteelSizeColumn12.Name = "SteelSizeColumn12"
        Me.SteelSizeColumn12.ReadOnly = True
        '
        'RMIDDColumn12
        '
        Me.RMIDDColumn12.DataPropertyName = "RMID"
        Me.RMIDDColumn12.HeaderText = "RMID"
        Me.RMIDDColumn12.Name = "RMIDDColumn12"
        Me.RMIDDColumn12.ReadOnly = True
        '
        'HeatNumberColumn12
        '
        Me.HeatNumberColumn12.DataPropertyName = "HeatNumber"
        Me.HeatNumberColumn12.HeaderText = "HeatNumber"
        Me.HeatNumberColumn12.Name = "HeatNumberColumn12"
        Me.HeatNumberColumn12.ReadOnly = True
        '
        'HeatSteelTypeColumn12
        '
        Me.HeatSteelTypeColumn12.DataPropertyName = "HeatSteelType"
        Me.HeatSteelTypeColumn12.HeaderText = "HeatSteelType"
        Me.HeatSteelTypeColumn12.Name = "HeatSteelTypeColumn12"
        Me.HeatSteelTypeColumn12.ReadOnly = True
        '
        'HeatSteelSizeColumn12
        '
        Me.HeatSteelSizeColumn12.DataPropertyName = "HeatSteelSize"
        Me.HeatSteelSizeColumn12.HeaderText = "HeatSteelSize"
        Me.HeatSteelSizeColumn12.Name = "HeatSteelSizeColumn12"
        Me.HeatSteelSizeColumn12.ReadOnly = True
        '
        'HeatFileNumberColumn12
        '
        Me.HeatFileNumberColumn12.DataPropertyName = "HeatFileNumber"
        Me.HeatFileNumberColumn12.HeaderText = "HeatFileNumber"
        Me.HeatFileNumberColumn12.Name = "HeatFileNumberColumn12"
        Me.HeatFileNumberColumn12.ReadOnly = True
        '
        'HeatFileFromHeatColumn12
        '
        Me.HeatFileFromHeatColumn12.DataPropertyName = "HeatFileFromHeat"
        Me.HeatFileFromHeatColumn12.HeaderText = "HeatFileFromHeat"
        Me.HeatFileFromHeatColumn12.Name = "HeatFileFromHeatColumn12"
        Me.HeatFileFromHeatColumn12.ReadOnly = True
        '
        'PullTestCheckiSteelToHeatBindingSource
        '
        Me.PullTestCheckiSteelToHeatBindingSource.DataMember = "PullTestCheckiSteelToHeat"
        Me.PullTestCheckiSteelToHeatBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'TabPage8
        '
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(605, 682)
        Me.TabPage8.TabIndex = 7
        Me.TabPage8.Text = "TabPage8"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'TabPage9
        '
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Size = New System.Drawing.Size(605, 682)
        Me.TabPage9.TabIndex = 8
        Me.TabPage9.Text = "TabPage9"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'TabPage10
        '
        Me.TabPage10.Location = New System.Drawing.Point(4, 22)
        Me.TabPage10.Name = "TabPage10"
        Me.TabPage10.Size = New System.Drawing.Size(605, 682)
        Me.TabPage10.TabIndex = 9
        Me.TabPage10.Text = "TabPage10"
        Me.TabPage10.UseVisualStyleBackColor = True
        '
        'TabPage11
        '
        Me.TabPage11.Location = New System.Drawing.Point(4, 22)
        Me.TabPage11.Name = "TabPage11"
        Me.TabPage11.Size = New System.Drawing.Size(605, 682)
        Me.TabPage11.TabIndex = 10
        Me.TabPage11.Text = "TabPage11"
        Me.TabPage11.UseVisualStyleBackColor = True
        '
        'TabPage12
        '
        Me.TabPage12.Location = New System.Drawing.Point(4, 22)
        Me.TabPage12.Name = "TabPage12"
        Me.TabPage12.Size = New System.Drawing.Size(605, 682)
        Me.TabPage12.TabIndex = 11
        Me.TabPage12.Text = "TabPage12"
        Me.TabPage12.UseVisualStyleBackColor = True
        '
        'TabPage13
        '
        Me.TabPage13.Location = New System.Drawing.Point(4, 22)
        Me.TabPage13.Name = "TabPage13"
        Me.TabPage13.Size = New System.Drawing.Size(605, 682)
        Me.TabPage13.TabIndex = 12
        Me.TabPage13.Text = "TabPage13"
        Me.TabPage13.UseVisualStyleBackColor = True
        '
        'TabPage14
        '
        Me.TabPage14.Location = New System.Drawing.Point(4, 22)
        Me.TabPage14.Name = "TabPage14"
        Me.TabPage14.Size = New System.Drawing.Size(605, 682)
        Me.TabPage14.TabIndex = 13
        Me.TabPage14.Text = "TabPage14"
        Me.TabPage14.UseVisualStyleBackColor = True
        '
        'TabPage15
        '
        Me.TabPage15.Location = New System.Drawing.Point(4, 22)
        Me.TabPage15.Name = "TabPage15"
        Me.TabPage15.Size = New System.Drawing.Size(605, 682)
        Me.TabPage15.TabIndex = 14
        Me.TabPage15.Text = "TabPage15"
        Me.TabPage15.UseVisualStyleBackColor = True
        '
        'TabPage16
        '
        Me.TabPage16.Location = New System.Drawing.Point(4, 22)
        Me.TabPage16.Name = "TabPage16"
        Me.TabPage16.Size = New System.Drawing.Size(605, 682)
        Me.TabPage16.TabIndex = 15
        Me.TabPage16.Text = "TabPage16"
        Me.TabPage16.UseVisualStyleBackColor = True
        '
        'TabPage17
        '
        Me.TabPage17.Location = New System.Drawing.Point(4, 22)
        Me.TabPage17.Name = "TabPage17"
        Me.TabPage17.Size = New System.Drawing.Size(605, 682)
        Me.TabPage17.TabIndex = 16
        Me.TabPage17.Text = "TabPage17"
        Me.TabPage17.UseVisualStyleBackColor = True
        '
        'TabPage18
        '
        Me.TabPage18.Location = New System.Drawing.Point(4, 22)
        Me.TabPage18.Name = "TabPage18"
        Me.TabPage18.Size = New System.Drawing.Size(605, 682)
        Me.TabPage18.TabIndex = 17
        Me.TabPage18.Text = "TabPage18"
        Me.TabPage18.UseVisualStyleBackColor = True
        '
        'TabPage19
        '
        Me.TabPage19.Location = New System.Drawing.Point(4, 22)
        Me.TabPage19.Name = "TabPage19"
        Me.TabPage19.Size = New System.Drawing.Size(605, 682)
        Me.TabPage19.TabIndex = 18
        Me.TabPage19.Text = "TabPage19"
        Me.TabPage19.UseVisualStyleBackColor = True
        '
        'TabPage20
        '
        Me.TabPage20.Location = New System.Drawing.Point(4, 22)
        Me.TabPage20.Name = "TabPage20"
        Me.TabPage20.Size = New System.Drawing.Size(605, 682)
        Me.TabPage20.TabIndex = 19
        Me.TabPage20.Text = "TabPage20"
        Me.TabPage20.UseVisualStyleBackColor = True
        '
        'TabPage21
        '
        Me.TabPage21.Location = New System.Drawing.Point(4, 22)
        Me.TabPage21.Name = "TabPage21"
        Me.TabPage21.Size = New System.Drawing.Size(605, 682)
        Me.TabPage21.TabIndex = 20
        Me.TabPage21.Text = "TabPage21"
        Me.TabPage21.UseVisualStyleBackColor = True
        '
        'TabPage22
        '
        Me.TabPage22.Location = New System.Drawing.Point(4, 22)
        Me.TabPage22.Name = "TabPage22"
        Me.TabPage22.Size = New System.Drawing.Size(605, 682)
        Me.TabPage22.TabIndex = 21
        Me.TabPage22.Text = "TabPage22"
        Me.TabPage22.UseVisualStyleBackColor = True
        '
        'TabPage23
        '
        Me.TabPage23.Location = New System.Drawing.Point(4, 22)
        Me.TabPage23.Name = "TabPage23"
        Me.TabPage23.Size = New System.Drawing.Size(605, 682)
        Me.TabPage23.TabIndex = 22
        Me.TabPage23.Text = "TabPage23"
        Me.TabPage23.UseVisualStyleBackColor = True
        '
        'TabPage24
        '
        Me.TabPage24.Location = New System.Drawing.Point(4, 22)
        Me.TabPage24.Name = "TabPage24"
        Me.TabPage24.Size = New System.Drawing.Size(605, 682)
        Me.TabPage24.TabIndex = 23
        Me.TabPage24.Text = "TabPage24"
        Me.TabPage24.UseVisualStyleBackColor = True
        '
        'TabPage25
        '
        Me.TabPage25.Location = New System.Drawing.Point(4, 22)
        Me.TabPage25.Name = "TabPage25"
        Me.TabPage25.Size = New System.Drawing.Size(605, 682)
        Me.TabPage25.TabIndex = 24
        Me.TabPage25.Text = "TabPage25"
        Me.TabPage25.UseVisualStyleBackColor = True
        '
        'TabPage26
        '
        Me.TabPage26.Location = New System.Drawing.Point(4, 22)
        Me.TabPage26.Name = "TabPage26"
        Me.TabPage26.Size = New System.Drawing.Size(605, 682)
        Me.TabPage26.TabIndex = 25
        Me.TabPage26.Text = "TabPage26"
        Me.TabPage26.UseVisualStyleBackColor = True
        '
        'TabPage27
        '
        Me.TabPage27.Location = New System.Drawing.Point(4, 22)
        Me.TabPage27.Name = "TabPage27"
        Me.TabPage27.Size = New System.Drawing.Size(605, 682)
        Me.TabPage27.TabIndex = 26
        Me.TabPage27.Text = "TabPage27"
        Me.TabPage27.UseVisualStyleBackColor = True
        '
        'TabPage28
        '
        Me.TabPage28.Location = New System.Drawing.Point(4, 22)
        Me.TabPage28.Name = "TabPage28"
        Me.TabPage28.Size = New System.Drawing.Size(605, 682)
        Me.TabPage28.TabIndex = 27
        Me.TabPage28.Text = "TabPage28"
        Me.TabPage28.UseVisualStyleBackColor = True
        '
        'TabPage29
        '
        Me.TabPage29.Location = New System.Drawing.Point(4, 22)
        Me.TabPage29.Name = "TabPage29"
        Me.TabPage29.Size = New System.Drawing.Size(605, 682)
        Me.TabPage29.TabIndex = 28
        Me.TabPage29.Text = "TabPage29"
        Me.TabPage29.UseVisualStyleBackColor = True
        '
        'TabPage30
        '
        Me.TabPage30.Location = New System.Drawing.Point(4, 22)
        Me.TabPage30.Name = "TabPage30"
        Me.TabPage30.Size = New System.Drawing.Size(605, 682)
        Me.TabPage30.TabIndex = 29
        Me.TabPage30.Text = "TabPage30"
        Me.TabPage30.UseVisualStyleBackColor = True
        '
        'TabPage31
        '
        Me.TabPage31.Location = New System.Drawing.Point(4, 22)
        Me.TabPage31.Name = "TabPage31"
        Me.TabPage31.Size = New System.Drawing.Size(605, 682)
        Me.TabPage31.TabIndex = 30
        Me.TabPage31.Text = "TabPage31"
        Me.TabPage31.UseVisualStyleBackColor = True
        '
        'TabPage32
        '
        Me.TabPage32.Location = New System.Drawing.Point(4, 22)
        Me.TabPage32.Name = "TabPage32"
        Me.TabPage32.Size = New System.Drawing.Size(605, 682)
        Me.TabPage32.TabIndex = 31
        Me.TabPage32.Text = "TabPage32"
        Me.TabPage32.UseVisualStyleBackColor = True
        '
        'TabPage33
        '
        Me.TabPage33.Location = New System.Drawing.Point(4, 22)
        Me.TabPage33.Name = "TabPage33"
        Me.TabPage33.Size = New System.Drawing.Size(605, 682)
        Me.TabPage33.TabIndex = 32
        Me.TabPage33.Text = "TabPage33"
        Me.TabPage33.UseVisualStyleBackColor = True
        '
        'TabPage34
        '
        Me.TabPage34.Location = New System.Drawing.Point(4, 22)
        Me.TabPage34.Name = "TabPage34"
        Me.TabPage34.Size = New System.Drawing.Size(605, 682)
        Me.TabPage34.TabIndex = 33
        Me.TabPage34.Text = "TabPage34"
        Me.TabPage34.UseVisualStyleBackColor = True
        '
        'TabPage35
        '
        Me.TabPage35.Location = New System.Drawing.Point(4, 22)
        Me.TabPage35.Name = "TabPage35"
        Me.TabPage35.Size = New System.Drawing.Size(605, 682)
        Me.TabPage35.TabIndex = 34
        Me.TabPage35.Text = "TabPage35"
        Me.TabPage35.UseVisualStyleBackColor = True
        '
        'cmdTimeSlipRoster
        '
        Me.cmdTimeSlipRoster.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdTimeSlipRoster.ForeColor = System.Drawing.Color.Black
        Me.cmdTimeSlipRoster.Location = New System.Drawing.Point(728, 771)
        Me.cmdTimeSlipRoster.Name = "cmdTimeSlipRoster"
        Me.cmdTimeSlipRoster.Size = New System.Drawing.Size(71, 40)
        Me.cmdTimeSlipRoster.TabIndex = 69
        Me.cmdTimeSlipRoster.Text = "Time Slip Roster"
        Me.cmdTimeSlipRoster.UseVisualStyleBackColor = True
        '
        'SalesOrderHeaderTableTableAdapter
        '
        Me.SalesOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ShipmentHeaderTableTableAdapter
        '
        Me.ShipmentHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'InvoiceShipmentCOSTableAdapter
        '
        Me.InvoiceShipmentCOSTableAdapter.ClearBeforeFill = True
        '
        'InvoiceCompareTableAdapter
        '
        Me.InvoiceCompareTableAdapter.ClearBeforeFill = True
        '
        'InvoiceShipmentTableAdapter
        '
        Me.InvoiceShipmentTableAdapter.ClearBeforeFill = True
        '
        'ReturnProductHeaderTableTableAdapter
        '
        Me.ReturnProductHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ReceivingHeaderTableTableAdapter
        '
        Me.ReceivingHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'TFPErrorLogTableAdapter
        '
        Me.TFPErrorLogTableAdapter.ClearBeforeFill = True
        '
        'InvoiceProcessingBatchHeaderTableAdapter
        '
        Me.InvoiceProcessingBatchHeaderTableAdapter.ClearBeforeFill = True
        '
        'ARProcessPaymentBatchTableAdapter
        '
        Me.ARProcessPaymentBatchTableAdapter.ClearBeforeFill = True
        '
        'InvoiceHeaderTableTableAdapter
        '
        Me.InvoiceHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'LotNumberTableAdapter
        '
        Me.LotNumberTableAdapter.ClearBeforeFill = True
        '
        'PullTestDataTableAdapter
        '
        Me.PullTestDataTableAdapter.ClearBeforeFill = True
        '
        'ReceiptOfInvoiceBatchHeaderTableAdapter
        '
        Me.ReceiptOfInvoiceBatchHeaderTableAdapter.ClearBeforeFill = True
        '
        'APProcessPaymentBatchTableAdapter
        '
        Me.APProcessPaymentBatchTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'AssemblyHeaderTableTableAdapter
        '
        Me.AssemblyHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'AssemblyLineTableTableAdapter
        '
        Me.AssemblyLineTableTableAdapter.ClearBeforeFill = True
        '
        'InventoryCostingTableAdapter
        '
        Me.InventoryCostingTableAdapter.ClearBeforeFill = True
        '
        'PurchaseOrderQuantityStatusTableAdapter
        '
        Me.PurchaseOrderQuantityStatusTableAdapter.ClearBeforeFill = True
        '
        'PurchaseOrderHeaderTableTableAdapter
        '
        Me.PurchaseOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'ARPaymentCompareTableAdapter
        '
        Me.ARPaymentCompareTableAdapter.ClearBeforeFill = True
        '
        'SteelYardEntryTableTableAdapter
        '
        Me.SteelYardEntryTableTableAdapter.ClearBeforeFill = True
        '
        'SteelUsageTableTableAdapter
        '
        Me.SteelUsageTableTableAdapter.ClearBeforeFill = True
        '
        'SteelCostingTableTableAdapter
        '
        Me.SteelCostingTableTableAdapter.ClearBeforeFill = True
        '
        'UPSShippingDataTableAdapter
        '
        Me.UPSShippingDataTableAdapter.ClearBeforeFill = True
        '
        'AssemblySerialLogTableAdapter
        '
        Me.AssemblySerialLogTableAdapter.ClearBeforeFill = True
        '
        'LotNumberTestTableAdapter
        '
        Me.LotNumberTestTableAdapter.ClearBeforeFill = True
        '
        'ReceivingLineQueryTableAdapter
        '
        Me.ReceivingLineQueryTableAdapter.ClearBeforeFill = True
        '
        'PullTestCheckiSteelToHeatTableAdapter
        '
        Me.PullTestCheckiSteelToHeatTableAdapter.ClearBeforeFill = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(63, 260)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(190, 20)
        Me.TextBox1.TabIndex = 85
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(63, 286)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(190, 20)
        Me.TextBox2.TabIndex = 86
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(63, 326)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(190, 20)
        Me.TextBox3.TabIndex = 87
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(63, 359)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(190, 20)
        Me.TextBox4.TabIndex = 88
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(63, 406)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(190, 20)
        Me.TextBox5.TabIndex = 89
        '
        'DatabaseUtilities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 823)
        Me.Controls.Add(Me.cmdTimeSlipRoster)
        Me.Controls.Add(Me.tabDatagrids)
        Me.Controls.Add(Me.tabUtilities)
        Me.Controls.Add(Me.cmdClearLocks)
        Me.Controls.Add(Me.cmdDeleteTestData)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "DatabaseUtilities"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Database Utilities"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gpxARInvoiceBatch.ResumeLayout(False)
        Me.gpxUpdateAPInvoiceBatch.ResumeLayout(False)
        Me.gpxAPPaymentBatch.ResumeLayout(False)
        Me.gpxARPaymentBatch.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.tabUtilities.ResumeLayout(False)
        Me.tabU1.ResumeLayout(False)
        Me.GroupBox38.ResumeLayout(False)
        Me.GroupBox37.ResumeLayout(False)
        Me.GroupBox29.ResumeLayout(False)
        Me.GroupBox20.ResumeLayout(False)
        Me.tabU2.ResumeLayout(False)
        Me.GroupBox42.ResumeLayout(False)
        Me.GroupBox40.ResumeLayout(False)
        Me.GroupBox39.ResumeLayout(False)
        Me.GroupBox28.ResumeLayout(False)
        Me.GroupBox27.ResumeLayout(False)
        Me.tabU4.ResumeLayout(False)
        Me.GroupBox35.ResumeLayout(False)
        Me.GroupBox34.ResumeLayout(False)
        Me.GroupBox33.ResumeLayout(False)
        Me.GroupBox32.ResumeLayout(False)
        Me.GroupBox30.ResumeLayout(False)
        Me.GroupBox26.ResumeLayout(False)
        Me.GroupBox25.ResumeLayout(False)
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox23.ResumeLayout(False)
        Me.GroupBox22.ResumeLayout(False)
        Me.tabU5.ResumeLayout(False)
        Me.GroupBox31.ResumeLayout(False)
        Me.GroupBox21.ResumeLayout(False)
        Me.tabU6.ResumeLayout(False)
        Me.tabU6.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.tabU7.ResumeLayout(False)
        Me.tabU7.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox36.ResumeLayout(False)
        Me.tabDatagrids.ResumeLayout(False)
        Me.SOHeader.ResumeLayout(False)
        CType(Me.dgvLotNumberTest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotNumberTestBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSerialLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblySerialLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSteelCostingTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelCostingTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTWDItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPurchaseLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderQuantityStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReceivingHeaders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceivingHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReturnHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReturnProductHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvoiceShipment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceShipmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvoiceCompare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceCompareBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvoiceShipCOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceShipmentCOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShipmentHeaderTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipmentHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSOTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.POHeader.ResumeLayout(False)
        CType(Me.dgvTFPErrorLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TFPErrorLogBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPurchases.ResumeLayout(False)
        CType(Me.dgvReceiverLineQuery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceivingLineQueryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOpenPOTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvARPaymentCompare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARPaymentCompareBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPOHeaders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAPPaymentBatch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APProcessPaymentBatchBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAPInvoiceBatch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReceiptOfInvoiceBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvoiceHeaderTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvARPaymentBatch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ARProcessPaymentBatchBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvARInvoiceBatch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceProcessingBatchHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCostTiers.ResumeLayout(False)
        CType(Me.dgvSteelUsage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelUsageTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWireYard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SteelYardEntryTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInventoryCostingEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventoryCostingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAssemblyLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblyLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAssemblyTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssemblyHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPullTestData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PullTestDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLotNumberRMID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LotNumberBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvCostTiers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabUPS.ResumeLayout(False)
        CType(Me.dgvUPSShippingData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UPSShippingDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSteel.ResumeLayout(False)
        CType(Me.dgvSteelInPullTests, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PullTestCheckiSteelToHeatBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents gpxARInvoiceBatch As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpdateARInvoiceBatch As System.Windows.Forms.Button
    Friend WithEvents cmdViewARInvoiceBatch As System.Windows.Forms.Button
    Friend WithEvents gpxUpdateAPInvoiceBatch As System.Windows.Forms.GroupBox
    Friend WithEvents cmdShowAPInvoiceBatch As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateAPInvoiceBatch As System.Windows.Forms.Button
    Friend WithEvents gpxAPPaymentBatch As System.Windows.Forms.GroupBox
    Friend WithEvents cmdShowAPPaymentBatch As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateAPPaymentBatch As System.Windows.Forms.Button
    Friend WithEvents gpxARPaymentBatch As System.Windows.Forms.GroupBox
    Friend WithEvents cmdShowARPaymentBatch As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateARPaymentBatch As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewInvoiceCOS As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateInvoiceCOS As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewReceivers As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateReceivers As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteTestData As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewErrorLog As System.Windows.Forms.Button
    Friend WithEvents cmdClearLog As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewInvoiceShipments As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateShipmentInvoices As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewSO As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateSO As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewShipments As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateShipments As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewCOSalesOrders As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateCOSSalesOrders As System.Windows.Forms.Button
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewCOSFromShipment As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateCOSFromShipment As System.Windows.Forms.Button
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewVoucherlines As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateVoucherLines As System.Windows.Forms.Button
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewLot As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateLot As System.Windows.Forms.Button
    Friend WithEvents cmdClearLocks As System.Windows.Forms.Button
    Friend WithEvents tabUtilities As System.Windows.Forms.TabControl
    Friend WithEvents tabU1 As System.Windows.Forms.TabPage
    Friend WithEvents tabU2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpdateReturnCOS As System.Windows.Forms.Button
    Friend WithEvents cmdViewReturnHeader As System.Windows.Forms.Button
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpdateInvoicePayments As System.Windows.Forms.Button
    Friend WithEvents cmdViewOpenInvoices As System.Windows.Forms.Button
    Friend WithEvents GroupBox22 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpdatePullTests As System.Windows.Forms.Button
    Friend WithEvents cmdViewPullTests As System.Windows.Forms.Button
    Friend WithEvents tabU3 As System.Windows.Forms.TabPage
    Friend WithEvents llUmpostedInvoiceLines As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox23 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpdateLots As System.Windows.Forms.Button
    Friend WithEvents cmdViewLots As System.Windows.Forms.Button
    Friend WithEvents tabU4 As System.Windows.Forms.TabPage
    Friend WithEvents tabU5 As System.Windows.Forms.TabPage
    Friend WithEvents tabU6 As System.Windows.Forms.TabPage
    Friend WithEvents tabU7 As System.Windows.Forms.TabPage
    Friend WithEvents tabDatagrids As System.Windows.Forms.TabControl
    Friend WithEvents SOHeader As System.Windows.Forms.TabPage
    Friend WithEvents POHeader As System.Windows.Forms.TabPage
    Friend WithEvents tabPurchases As System.Windows.Forms.TabPage
    Friend WithEvents TabCostTiers As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents tabUPS As System.Windows.Forms.TabPage
    Friend WithEvents tabSteel As System.Windows.Forms.TabPage
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage10 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage11 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage12 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage13 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage14 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage15 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage16 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage17 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage18 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage19 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage20 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage21 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage22 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage23 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage24 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage25 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage26 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage27 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage28 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage29 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage30 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage31 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage32 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage33 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage34 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage35 As System.Windows.Forms.TabPage
    Friend WithEvents dgvSOTable As System.Windows.Forms.DataGridView
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents SalesOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SalesOrderHeaderTableTableAdapter
    Friend WithEvents SOSalesOrderKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SODivisionKeyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvShipmentHeaderTable As System.Windows.Forms.DataGridView
    Friend WithEvents ShipmentHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipmentHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipmentHeaderTableTableAdapter
    Friend WithEvents STShipmentNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvInvoiceShipCOS As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceShipmentCOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceShipmentCOSTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceShipmentCOSTableAdapter
    Friend WithEvents SONumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLineNumberColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstExtendedCOSColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvInvoiceCompare As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceCompareBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceCompareTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceCompareTableAdapter
    Friend WithEvents InvoiceNumberColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceCOSColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SUMExtendedCOSColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvInvoiceShipment As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceShipmentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceShipmentTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceShipmentTableAdapter
    Friend WithEvents ShipmentNumberColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceProductTotalColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BilledFreightColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax2Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTax3Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceTotalColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvReturnHeader As System.Windows.Forms.DataGridView
    Friend WithEvents ReturnProductHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReturnProductHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReturnProductHeaderTableTableAdapter
    Friend WithEvents ReturnNumberColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvReceivingHeaders As System.Windows.Forms.DataGridView
    Friend WithEvents ReceivingHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingHeaderTableTableAdapter
    Friend WithEvents ReceivingHeaderKeyColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvTFPErrorLog As System.Windows.Forms.DataGridView
    Friend WithEvents TFPErrorLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TFPErrorLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.TFPErrorLogTableAdapter
    Friend WithEvents ErrorDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorDescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorReferenceNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorUserIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorCommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorDivisionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvARInvoiceBatch As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceProcessingBatchHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceProcessingBatchHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceProcessingBatchHeaderTableAdapter
    Friend WithEvents BatchNumberColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvARPaymentBatch As System.Windows.Forms.DataGridView
    Friend WithEvents ARProcessPaymentBatchBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARProcessPaymentBatchTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARProcessPaymentBatchTableAdapter
    Friend WithEvents BatchNumberColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvInvoiceHeaderTable As System.Windows.Forms.DataGridView
    Friend WithEvents InvoiceHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InvoiceHeaderTableTableAdapter
    Friend WithEvents InvoiceNumberColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvLotNumberRMID As System.Windows.Forms.DataGridView
    Friend WithEvents LotNumberBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTableAdapter
    Friend WithEvents dgvPullTestData As System.Windows.Forms.DataGridView
    Friend WithEvents PullTestDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PullTestDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PullTestDataTableAdapter
    Friend WithEvents FOXNumberColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestNumberColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvAPInvoiceBatch As System.Windows.Forms.DataGridView
    Friend WithEvents ReceiptOfInvoiceBatchHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceiptOfInvoiceBatchHeaderTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceiptOfInvoiceBatchHeaderTableAdapter
    Friend WithEvents BatchNumberColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvAPPaymentBatch As System.Windows.Forms.DataGridView
    Friend WithEvents APProcessPaymentBatchBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents APProcessPaymentBatchTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.APProcessPaymentBatchTableAdapter
    Friend WithEvents BatchNumberColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewItemList As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateItemList As System.Windows.Forms.Button
    Friend WithEvents dgvItemList As System.Windows.Forms.DataGridView
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents CostItemIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostItemClassColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostStandardCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostStandardPriceColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewAssembly As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateAssemblyCost As System.Windows.Forms.Button
    Friend WithEvents dgvAssemblyTable As System.Windows.Forms.DataGridView
    Friend WithEvents AssemblyHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblyHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyHeaderTableTableAdapter
    Friend WithEvents AssemblyPartNumberColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCostColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewAssemblyLineNumbers As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateAssemblyLineNumbers As System.Windows.Forms.Button
    Friend WithEvents dgvAssemblyLines As System.Windows.Forms.DataGridView
    Friend WithEvents AssemblyLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblyLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblyLineTableTableAdapter
    Friend WithEvents AssemblyPartNumberColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentPartNumberColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentPartDescriptionColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentLineNumberColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewAssemblyLineCost As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateAssemblyLineCost As System.Windows.Forms.Button
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCostTierDivision As System.Windows.Forms.TextBox
    Friend WithEvents txtCostTierPartNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdViewCostTiers As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateCostTiers As System.Windows.Forms.Button
    Friend WithEvents dgvCostTiers As System.Windows.Forms.DataGridView
    Friend WithEvents InventoryCostingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InventoryCostingTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.InventoryCostingTableAdapter
    Friend WithEvents CTPartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTDivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTCostingDateColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTItemCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTCostQuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTLowerLimitColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTUpperLimitColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTTransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTReferenceNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTReferenceLineColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewCostTierReturns As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateCostTierReturns As System.Windows.Forms.Button
    Friend WithEvents dgvInventoryCostingEdit As System.Windows.Forms.DataGridView
    Friend WithEvents PartNumberColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostingDateColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemCostColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostQuantityColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LowerLimitColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpperLimitColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceNumberColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceLineColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewAdjustmentTiers As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateAdjustmentTiers As System.Windows.Forms.Button
    Friend WithEvents GroupBox25 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewVendorReturns As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateVendorReturnsTiers As System.Windows.Forms.Button
    Friend WithEvents GroupBox26 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewReceiverTiers As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateReceiverTiers As System.Windows.Forms.Button
    Friend WithEvents GroupBox27 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewPOLineStatus As System.Windows.Forms.Button
    Friend WithEvents cmdUpdatePOLineStatus As System.Windows.Forms.Button
    Friend WithEvents PurchaseOrderQuantityStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderQuantityStatusTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderQuantityStatusTableAdapter
    Friend WithEvents dgvPurchaseLines As System.Windows.Forms.DataGridView
    Friend WithEvents PurchaseOrderHeaderKeyColumn88 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderLineNumberColumn88 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn88 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn88 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderQuantityColumn88 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityReceivedColumn88 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedQtyPendingColumn88 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POQuantityOpenColumn88 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn88 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn88 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn88 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn88 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox28 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewPOHeadersAddress As System.Windows.Forms.Button
    Friend WithEvents cmdUpdatePOAddress As System.Windows.Forms.Button
    Friend WithEvents dgvPOHeaders As System.Windows.Forms.DataGridView
    Friend WithEvents PurchaseOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PurchaseOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PurchaseOrderHeaderTableTableAdapter
    Friend WithEvents PurchaseOrderHeaderKeyColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODropShipCustomerIDColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POAdditionalShipToColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DropShipSalesOrderNumberColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipNameColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress1Column66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipAddress2Column66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCityColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipStateColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipZipCodeColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipCountryColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox29 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewDropShipSO As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateDropShipSO As System.Windows.Forms.Button
    Friend WithEvents GroupBox30 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewItemListTWD As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateItemListTWD As System.Windows.Forms.Button
    Friend WithEvents dgvTWDItemList As System.Windows.Forms.DataGridView
    Friend WithEvents ItemIDColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongDescriptionColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxCountColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletCountColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxTypeColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NominalDiameterColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NominalLengthColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SafetyDataSheetColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxWeightColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox31 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpdateARPaymentCompare As System.Windows.Forms.Button
    Friend WithEvents cmdViewARPaymentCompare As System.Windows.Forms.Button
    Friend WithEvents dgvARPaymentCompare As System.Windows.Forms.DataGridView
    Friend WithEvents ARPaymentCompareBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ARPaymentCompareTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ARPaymentCompareTableAdapter
    Friend WithEvents ARTransactionKeyColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentDateColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmountColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentIDColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentLineNumberColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckNumberColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLPaymentIDColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLPaymentLineNumberColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLInvoiceNumberColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLPaymentAmountColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLPaymentDateColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLDivisionIDColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumberColumn77 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox32 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewWireYard As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateWireYard As System.Windows.Forms.Button
    Friend WithEvents dgvWireYard As System.Windows.Forms.DataGridView
    Friend WithEvents SteelYardEntryTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelYardEntryTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelYardEntryTableTableAdapter
    Friend WithEvents SteelReturnKeyColumn99 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnDateColumn99 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnWeightColumn99 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn99 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox33 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewSteelUsage As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateSteelUsage As System.Windows.Forms.Button
    Friend WithEvents dgvSteelUsage As System.Windows.Forms.DataGridView
    Friend WithEvents SteelUsageTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelUsageTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelUsageTableTableAdapter
    Friend WithEvents SteelUsageKeyColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsageDateColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsageWeightColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedCostColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox34 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents LotNumberColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberIDColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox35 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewBuildTiers As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateBuildTiers As System.Windows.Forms.Button
    Friend WithEvents GroupBox36 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewSteelCostTier As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateSteelCostTier As System.Windows.Forms.Button
    Friend WithEvents dgvSteelCostingTable As System.Windows.Forms.DataGridView
    Friend WithEvents SteelCostingTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SteelCostingTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.SteelCostingTableTableAdapter
    Friend WithEvents RMIDColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostingDateColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelCostPerPoundColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostingQuantityColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceNumberColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceLineColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvUPSShippingData As System.Windows.Forms.DataGridView
    Friend WithEvents UPSShippingDataBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UPSShippingDataTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.UPSShippingDataTableAdapter
    Friend WithEvents GroupBox37 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewUPS As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteUPS As System.Windows.Forms.Button
    Friend WithEvents PickTicketNumberColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuotedFreightChargeColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalWeightColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TrackingNumberColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoidIndicatorColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox38 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewSerialLog As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateSerialLog As System.Windows.Forms.Button
    Friend WithEvents dgvSerialLog As System.Windows.Forms.DataGridView
    Friend WithEvents AssemblySerialLogBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AssemblySerialLogTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AssemblySerialLogTableAdapter
    Friend WithEvents AssemblyPartNumber77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerialNumber77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionID77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCost77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildDate77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuildNumber77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerID77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BatchNumber77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TransactionNumber77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentNumber77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipmentDate77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceNumber77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceDate77Column As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox39 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewOpenPO As System.Windows.Forms.Button
    Friend WithEvents cmdCloseOpenPOs As System.Windows.Forms.Button
    Friend WithEvents dgvOpenPOTable As System.Windows.Forms.DataGridView
    Friend WithEvents PurchaseOrderHeaderKeyColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox40 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewLotFromFox As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateLotFromFox As System.Windows.Forms.Button
    Friend WithEvents dgvLotNumberTest As System.Windows.Forms.DataGridView
    Friend WithEvents LotNumberTestBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LotNumberTestTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.LotNumberTestTableAdapter
    Friend WithEvents LotNumberColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PieceWeightColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxWeightColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletWeightColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxCountColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletCountColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PalletPiecesColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxTypeColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NominalDiameterColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NominalLengthColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShortDescriptionColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemPieceWeightColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemBoxCountColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemPalletCountColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemNominalDiameterColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemNominalLengthColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemBoxWeightColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemClassColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXRawMaterialWeightColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXScrapWeightColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXFinishedWeightColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotRawMaterialWeightColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotScrapWeightColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotFinishedWeightColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdTimeSlipRoster As System.Windows.Forms.Button
    Friend WithEvents GroupBox42 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCloseReceiversForAP As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateReceiversForAP As System.Windows.Forms.Button
    Friend WithEvents dgvReceiverLineQuery As System.Windows.Forms.DataGridView
    Friend WithEvents ReceivingLineQueryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReceivingLineQueryTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ReceivingLineQueryTableAdapter
    Friend WithEvents ReceivingHeaderKeyColumn96 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn96 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityReceivedColumn96 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalQuantityVouchedColumn96 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn96 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataColumn96 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelectForInvoiceColumn96 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdViewHeatFiles As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateHeatFileInPullTest As System.Windows.Forms.Button
    Friend WithEvents dgvSteelInPullTests As System.Windows.Forms.DataGridView
    Friend WithEvents PullTestCheckiSteelToHeatBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PullTestCheckiSteelToHeatTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.PullTestCheckiSteelToHeatTableAdapter
    Friend WithEvents TestNumberColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOXNumberColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarbonColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SteelSizeColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RMIDDColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatNumberColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatSteelTypeColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatSteelSizeColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatFileNumberColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HeatFileFromHeatColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
