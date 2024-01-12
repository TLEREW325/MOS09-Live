Imports System.Data.SqlClient

Public Class SecurityManagement
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim ds As New DataSet
    Dim currentForm As System.Windows.Forms.Form
    Dim isLoaded As Boolean = False
    Dim drSortedEmployeeList As DataRow()

    Public Sub New()
        InitializeComponent()
        LoadForms()
        ShowData()
        isLoaded = True
    End Sub

    Private Sub LoadForms()
        cboForm.Items.Add("AllCompanyTotals")
        cboForm.Items.Add("AnnealingLogForm")
        cboForm.Items.Add("AnnealingLogSplitCoil")
        cboForm.Items.Add("AnnealLotTestResultsEntry")
        cboForm.Items.Add("APAgedPayablesDated")
        cboForm.Items.Add("APCheckNumberInput")
        cboForm.Items.Add("APCheckRegister")
        cboForm.Items.Add("APCheckReversal")
        cboForm.Items.Add("APcreateRecurringVouchers")
        cboForm.Items.Add("APDesignatePayables")
        cboForm.Items.Add("APProcessBatch")
        cboForm.Items.Add("APProcessForPayment")
        cboForm.Items.Add("APProcessReturns")
        cboForm.Items.Add("APProcessSteelReceipts")
        cboForm.Items.Add("APProcessSteelReturns")
        cboForm.Items.Add("APProcessVouchers")
        cboForm.Items.Add("APReceiptOfInvoice")
        cboForm.Items.Add("APViewVoucherLines")
        cboForm.Items.Add("APAgedReceivablesDated")
        cboForm.Items.Add("ARCashReceipts")
        cboForm.Items.Add("ARCustomerAccounts")
        cboForm.Items.Add("AREditCustomerPayments")
        cboForm.Items.Add("ARPaymentReversal")
        cboForm.Items.Add("ARProcessBatch")
        cboForm.Items.Add("ARProcessPaymentBatch")
        cboForm.Items.Add("ARRecurringPayment")
        cboForm.Items.Add("ARSelectDropShipForInvoicing")
        cboForm.Items.Add("AssemblyAddAvailableSerialNumbers")
        cboForm.Items.Add("AssemblyAddNewSerialNumber")
        cboForm.Items.Add("AssemblyBuildForm")
        cboForm.Items.Add("AssemblyBuildSerialized")
        cboForm.Items.Add("AssemblySerialPopup")
        cboForm.Items.Add("BankingReconciliation")
        cboForm.Items.Add("BankTransactionEntry")
        cboForm.Items.Add("Barcode1")
        cboForm.Items.Add("BlueprintJournal")
        cboForm.Items.Add("BlueprintJournalAddEntry")
        cboForm.Items.Add("BlueprintJournalEditEntry")
        cboForm.Items.Add("BlueprintSelection")
        cboForm.Items.Add("CashSheet")
        cboForm.Items.Add("CertificationSpec")
        cboForm.Items.Add("CharterSteelDespatchManualEntry")
        cboForm.Items.Add("CharterSteelDispatchEntry")
        cboForm.Items.Add("CheckShipmentWeight")
        cboForm.Items.Add("CoilWIPInventory")
        cboForm.Items.Add("CommentInputBox")
        cboForm.Items.Add("ConvertSOToPO")
        cboForm.Items.Add("CreateCurrentAnnouncements")
        cboForm.Items.Add("CreateSOFromPO")
        cboForm.Items.Add("CreateStudweldingCert")
        cboForm.Items.Add("CreditAppDisplay")
        cboForm.Items.Add("CurrentAnnouncements")
        cboForm.Items.Add("CustomerData")
        cboForm.Items.Add("CustomerDataViewSalesTotals")
        cboForm.Items.Add("CustomerFoxes")
        cboForm.Items.Add("CustomerInfoPopup")
        cboForm.Items.Add("CustomerNoteCreation")
        cboForm.Items.Add("CustomerNotes")
        cboForm.Items.Add("CustomerOpenOrders")
        cboForm.Items.Add("CustomerSalesHistory")
        cboForm.Items.Add("CustomerSalesRanking")
        cboForm.Items.Add("DailyTotals")
        cboForm.Items.Add("DatabaseMonitoring")
        cboForm.Items.Add("DatabaseUtilities")
        cboForm.Items.Add("DivisionLookupForm")
        cboForm.Items.Add("DrawSteelForm")
        cboForm.Items.Add("EditCompanyInfo")
        cboForm.Items.Add("ElectronicSchedulingBoard")
        cboForm.Items.Add("EmailAllInvoiceDocs")
        cboForm.Items.Add("EmailAllShippingDocs")
        cboForm.Items.Add("EmployeeData")
        cboForm.Items.Add("FerruleProductionEntry")
        cboForm.Items.Add("FinalPieceInspectionSignoff")
        cboForm.Items.Add("FinancialReports")
        cboForm.Items.Add("FOXMenu")
        cboForm.Items.Add("FOXSteelOrderForm")
        cboForm.Items.Add("GLAccountBalances")
        cboForm.Items.Add("GLAccountsByDate")
        cboForm.Items.Add("GLJournalTransactions")
        cboForm.Items.Add("GLTransactionBalanceDetails")
        cboForm.Items.Add("GLTransactionTemplate")
        cboForm.Items.Add("HeaderFOXForm")
        cboForm.Items.Add("HeaderFOXInspectionEntry")
        cboForm.Items.Add("HeaderFOXInspectionEntryViewer")
        cboForm.Items.Add("HeaderSetupSheet")
        cboForm.Items.Add("HeaderSetupSheetSelectFOX")
        cboForm.Items.Add("HeaderSetupSheetSelectSetup")
        cboForm.Items.Add("HeaderTimeSlipVerification")
        cboForm.Items.Add("HeatTreatDataForm")
        cboForm.Items.Add("InputComboBox")
        cboForm.Items.Add("InspectionReport")
        cboForm.Items.Add("InspectionReportFirstInspectionEntry")
        cboForm.Items.Add("InventoryAdjustmentForm")
        cboForm.Items.Add("InventoryCosting")
        cboForm.Items.Add("InventoryPartialPalletRacking")
        cboForm.Items.Add("InventoryPriceLevels")
        cboForm.Items.Add("InventoryRacking")
        cboForm.Items.Add("InventoryRackingAddLot")
        cboForm.Items.Add("InventoryRackingEmptyBins")
        cboForm.Items.Add("InventorySalesHistory")
        cboForm.Items.Add("InventoryStatus")
        cboForm.Items.Add("InventoryTransactionMaintenance")
        cboForm.Items.Add("InventoryTubs")
        cboForm.Items.Add("InventoryValuation")
        cboForm.Items.Add("InvoiceBillOnly")
        cboForm.Items.Add("InvoicingForm")
        cboForm.Items.Add("ItemClassMaintenance")
        cboForm.Items.Add("ItemLookup")
        cboForm.Items.Add("ItemMaintenance")
        cboForm.Items.Add("ItemMaintenanceConsignment")
        cboForm.Items.Add("ItemMaintenanceFoxProcesses")
        cboForm.Items.Add("ItemMaintenanceOpenOrders")
        cboForm.Items.Add("ItemMaintenancePartHistory")
        cboForm.Items.Add("ItemMaintenancePurchaseHistory")
        cboForm.Items.Add("ItemMaintenanceRacking")
        cboForm.Items.Add("ItemMinMaxMaintenance")
        cboForm.Items.Add("ItemPriceSheet")
        cboForm.Items.Add("ItemPriceSheetMaintenance")
        cboForm.Items.Add("LabelCreator")
        cboForm.Items.Add("LiftTruckRacking")
        cboForm.Items.Add("LoadDivisionModule")
        cboForm.Items.Add("Loading")
        cboForm.Items.Add("LoadNextPieceSold")
        cboForm.Items.Add("LoginPage")
        cboForm.Items.Add("LotNumberMaintenance")
        cboForm.Items.Add("LotNumberMaintenanceFOXSchedVerification")
        cboForm.Items.Add("LotNumberPopup")
        cboForm.Items.Add("MainInterface")
        cboForm.Items.Add("MaintainRecurringVouchers")
        cboForm.Items.Add("ManageShipments")
        cboForm.Items.Add("ManufacturingMaintenance")
        cboForm.Items.Add("MillCertForm")
        cboForm.Items.Add("MonthEndReports")
        cboForm.Items.Add("MonthSnapshot")
        cboForm.Items.Add("NonInventoryItems")
        cboForm.Items.Add("NotificationAlert")
        cboForm.Items.Add("NotificationCalendar")
        cboForm.Items.Add("NotificationEdit")
        cboForm.Items.Add("NotificationAdd")
        cboForm.Items.Add("NotificationShow")
        cboForm.Items.Add("PasswordEntry")
        cboForm.Items.Add("PaymentTermsMaintenance")
        cboForm.Items.Add("PickTicketDeleted")
        cboForm.Items.Add("POForm")
        cboForm.Items.Add("POQuantityOnHand")
        cboForm.Items.Add("PriceLookup")
        cboForm.Items.Add("PrintAllInvoiceDocs")
        cboForm.Items.Add("PrintAllShippingDocs")
        cboForm.Items.Add("PrintAnnealingLogFiltered")
        cboForm.Items.Add("PrintAPAging")
        cboForm.Items.Add("PrintAPAgingDated")
        cboForm.Items.Add("PrintAPCheckLog")
        cboForm.Items.Add("PrintAPChecks")
        cboForm.Items.Add("PrintAPPaymentBatch")
        cboForm.Items.Add("PrintAPProcessBatch")
        cboForm.Items.Add("PrintAPVoucherPaidList")
        cboForm.Items.Add("PrintARAging")
        cboForm.Items.Add("PrintARAgingDated")
        cboForm.Items.Add("PrintARAgingFiltered")
        cboForm.Items.Add("PrintARCashReceiptBatch")
        cboForm.Items.Add("PrintARCustomerHolds")
        cboForm.Items.Add("PrintARCustomerPaymentBatch")
        cboForm.Items.Add("PrintARCustomerPaymentByBatch")
        cboForm.Items.Add("PrintARCustomerPaymentListing")
        cboForm.Items.Add("PrintARCustomerStatement")
        cboForm.Items.Add("PrintARCustomerStatmentSingle")
        cboForm.Items.Add("PrintARPaymentLogFiltered")
        cboForm.Items.Add("PrintARPaymentReversal")
        cboForm.Items.Add("PrintARProcessPaymentAuto")
        cboForm.Items.Add("PrintAssemblyBOM")
        cboForm.Items.Add("PrintAssemblyBuildBOM")
        cboForm.Items.Add("PrintAssemblyBuildListingFiltered")
        cboForm.Items.Add("PrintAssemblyLinesFiltered")
        cboForm.Items.Add("PrintAssemblyListingFiltered")
        cboForm.Items.Add("PrintAuditTrail")
        cboForm.Items.Add("PrintBackOrderFiltered")
        cboForm.Items.Add("PrintBalanceSheet")
        cboForm.Items.Add("PrintBankBatch")
        cboForm.Items.Add("PrintBlankGaugeSignout")
        cboForm.Items.Add("PrintBOL")
        cboForm.Items.Add("PrintCanamSales")
        cboForm.Items.Add("PrintCashReceipts")
        cboForm.Items.Add("PrintCertErrorLog")
        cboForm.Items.Add("PrintCertificationSpecifications")
        cboForm.Items.Add("PrintCharterSteelDispatchEntry")
        cboForm.Items.Add("PrintCheckRegister")
        cboForm.Items.Add("PrintCheckRegisterFiltered")
        cboForm.Items.Add("PrintCoilLabel")
        cboForm.Items.Add("PrintCoilListing")
        cboForm.Items.Add("PrintCommissionReport")
        cboForm.Items.Add("PrintConsignmentInventory")
        cboForm.Items.Add("PrintConsignmentBilling")
        cboForm.Items.Add("PrintConsignmentReturns")
        cboForm.Items.Add("PrintConsignmentShipping")
        cboForm.Items.Add("PrintConsignmentTotals")
        cboForm.Items.Add("PrintConsignmentValuation")
        cboForm.Items.Add("PrintCostCenterFile")
        cboForm.Items.Add("PrintCustomer")
        cboForm.Items.Add("PrintCustomerAddressBook")
        cboForm.Items.Add("PrintCustomerARAging")
        cboForm.Items.Add("PrintCustomerARReport")
        cboForm.Items.Add("PrintCustomerListFiltered")
        cboForm.Items.Add("PrintCustomerMTDYTDTotals")
        cboForm.Items.Add("PrintCustomerNotes")
        cboForm.Items.Add("PrintCustomerOrderHistory")
        cboForm.Items.Add("PrintCustomerOrdersFiltered")
        cboForm.Items.Add("PrintCustomerPaymentActivity")
        cboForm.Items.Add("PrintCustomerPaymentActivitySingle")
        cboForm.Items.Add("PrintCustomerPaymentFiltered")
        cboForm.Items.Add("PrintCustomerPaymentRecord")
        cboForm.Items.Add("PrintCustomerReturn")
        cboForm.Items.Add("PrintCustomerReturnLinesFiltered")
        cboForm.Items.Add("PrintCustomerReturnListing")
        cboForm.Items.Add("PrintCustomerSales")
        cboForm.Items.Add("PrintCustomerSalesFiltered")
        cboForm.Items.Add("PrintCustomerSalesList")
        cboForm.Items.Add("PrintCustomerSalesRanking")
        cboForm.Items.Add("PrintCustomerSalesReport")
        cboForm.Items.Add("PrintCustomerSalesReportCAN")
        cboForm.Items.Add("PrintCustomerSatisfactionSurvey")
        cboForm.Items.Add("PrintCustomerStatement")
        cboForm.Items.Add("PrintCustomerStatementDated")
        cboForm.Items.Add("PrintCustomerSummaryReport")
        cboForm.Items.Add("PrintDailyRegister")
        cboForm.Items.Add("PrintDailyShipmentLog")
        cboForm.Items.Add("PrintDropShipListing")
        cboForm.Items.Add("PrintDropShipPackList")
        cboForm.Items.Add("PrintDropShipPOs")
        cboForm.Items.Add("PrintDropShipSalesByState")
        cboForm.Items.Add("PrintDropShipSO")
        cboForm.Items.Add("PrintElectronicSchedulingBoard")
        cboForm.Items.Add("PrintEmailList")
        cboForm.Items.Add("PrintFOX")
        cboForm.Items.Add("PrintFOXByCustomer")
        cboForm.Items.Add("PrintFOXByDate")
        cboForm.Items.Add("PrintFOXListing")
        cboForm.Items.Add("PrintListingFiltered")
        cboForm.Items.Add("PrintFOXPostingReport")
        cboForm.Items.Add("PrintFOXReleaseListing")
        cboForm.Items.Add("PrintFOXReleaseSchedule")
        cboForm.Items.Add("PrintFOXReleaseScheduleCompressed")
        cboForm.Items.Add("PrintGLChartOfAccounts")
        cboForm.Items.Add("PrintGLInvoiceLinesFiltered")
        cboForm.Items.Add("PrintGLJournal")
        cboForm.Items.Add("PrintGLJournalAuto")
        cboForm.Items.Add("PrintGLJournalFiltered")
        cboForm.Items.Add("PrintGLJournalReport")
        cboForm.Items.Add("PrintGLReceivingLinesFiltered")
        cboForm.Items.Add("PrintGLShippingLinesFiltered")
        cboForm.Items.Add("PrintGLTemplate")
        cboForm.Items.Add("PrintGLTransactionByAccount")
        cboForm.Items.Add("PrintGLTransactionDetail")
        cboForm.Items.Add("PrintGLTransactions")
        cboForm.Items.Add("PrintGLTransactionsFiltered")
        cboForm.Items.Add("PrintGLWCProductionLines")
        cboForm.Items.Add("PrintGLWTB")
        cboForm.Items.Add("PrintHeaderFOXReportFiltered")
        cboForm.Items.Add("PrintHeaderSetupSheet")
        cboForm.Items.Add("PrintHeatFileRecord")
        cboForm.Items.Add("PrintHeatNumberLog")
        cboForm.Items.Add("PrintHeatTreatCert")
        cboForm.Items.Add("PrintIncomeStatement")
        cboForm.Items.Add("PrintIncomeStatment2Year")
        cboForm.Items.Add("PrintInventoryActivity")
        cboForm.Items.Add("PrintInventoryAdjustmentBatch")
        cboForm.Items.Add("PrintInventoryAdjustmentJournal")
        cboForm.Items.Add("PrintInventoryAdjustmentsFiltered")
        cboForm.Items.Add("PrintInventoryCostingFiltered")
        cboForm.Items.Add("PrintInvnetoryCountSheet")
        cboForm.Items.Add("PrintInventoryDiscrepancyReport")
        cboForm.Items.Add("PrintInventoryFIFOFiltered")
        cboForm.Items.Add("PrintInventoryFIFOValue")
        cboForm.Items.Add("PrintInventoryPurchaseCost")
        cboForm.Items.Add("PrintInventorySales5Year")
        cboForm.Items.Add("PrintInventorySteelValue")
        cboForm.Items.Add("PrintInventoryStockShippingTotals")
        cboForm.Items.Add("PrintInventoryTransactions")
        cboForm.Items.Add("PrintInventoryTransactionsFiltered")
        cboForm.Items.Add("PrintInventoryTubList")
        cboForm.Items.Add("PrintInventoryTubsSummary")
        cboForm.Items.Add("PrintInventoryTubSummary")
        cboForm.Items.Add("PrintInventoryUsageByMonth")
        cboForm.Items.Add("PrintInventoryValuationByDate")
        cboForm.Items.Add("PrintInventoryValuationByGL")
        cboForm.Items.Add("PrintInventoryValueByFilter")
        cboForm.Items.Add("PrintInventoryValueByItemClass")
        cboForm.Items.Add("PrintInvoiceBatch")
        cboForm.Items.Add("PrintInvoiceBillOnly")
        cboForm.Items.Add("PrintInvoiceCerts")
        cboForm.Items.Add("PrintInvoiceCosting")
        cboForm.Items.Add("PrintInvoiceDailyTotals")
        cboForm.Items.Add("PrintInvoiceDiscrepancyReport")
        cboForm.Items.Add("PrintInvoiceGLAccountDetail")
        cboForm.Items.Add("PrintInvoiceGLPostings")
        cboForm.Items.Add("PrintInvoiceLinesBySortFiltered")
        cboForm.Items.Add("PrintInvoiceLinesFiltered")
        cboForm.Items.Add("PrintInvoiceListDatagrid")
        cboForm.Items.Add("PrintInvoiceRegister")
        cboForm.Items.Add("PrintInvoiceSingle")
        cboForm.Items.Add("PrintInvoiceSO")
        cboForm.Items.Add("PrintItemCostingReport")
        cboForm.Items.Add("PrintItemList")
        cboForm.Items.Add("PrintItemListFiltered")
        cboForm.Items.Add("PrintItemMinMax")
        cboForm.Items.Add("PrintItemPriceSheet")
        cboForm.Items.Add("PrintItemSoldToCustomerCanadian")
        cboForm.Items.Add("PrintItemsPurchasedFromVendor")
        cboForm.Items.Add("PrintItemsSoldFiltered")
        cboForm.Items.Add("PrintItemsSoldToCustomer")
        cboForm.Items.Add("PrintItemStandardCostPriceFiltered")
        cboForm.Items.Add("PrintLeadTimesFiltered")
        cboForm.Items.Add("PrintLetterHead")
        cboForm.Items.Add("PrintLotNumberList")
        cboForm.Items.Add("PrintLotNumberListFiltered")
        cboForm.Items.Add("PrintMachineCostCenterReport")
        cboForm.Items.Add("PrintMachineList")
        cboForm.Items.Add("PrintMonthSnapshot")
        cboForm.Items.Add("PrintNafta")
        cboForm.Items.Add("PrintNegativeInventory")
        cboForm.Items.Add("PrintNonInventoryItems")
        cboForm.Items.Add("PrintOkToProcess")
        cboForm.Items.Add("PrintOkToShip")
        cboForm.Items.Add("PrintOpenDropShips")
        cboForm.Items.Add("PrintOpenOrderReport")
        cboForm.Items.Add("PrintOpenPayables")
        cboForm.Items.Add("PrintOpenPOReport")
        cboForm.Items.Add("PrintOpenSalesOrderLineReport")
        cboForm.Items.Add("PrintOpenSteelPOList")
        cboForm.Items.Add("PrintPackingList")
        cboForm.Items.Add("PrintPackListSO")
        cboForm.Items.Add("PrintPartSalesData")
        cboForm.Items.Add("PrintPaymentTerms")
        cboForm.Items.Add("PrintPendingShipmentsFiltered")
        cboForm.Items.Add("PrintPhoneList")
        cboForm.Items.Add("PrintPickListHeaders")
        cboForm.Items.Add("PrintPickQOHFiltered")
        cboForm.Items.Add("PrintPickTicket")
        cboForm.Items.Add("PrintPickTicketBatch")
        cboForm.Items.Add("PrintPickTicketsAuto")
        cboForm.Items.Add("PrintPickTicketsSO")
        cboForm.Items.Add("PrintPOHeaders")
        cboForm.Items.Add("PrintPOHeadersFiltered")
        cboForm.Items.Add("PrintPOShipper")
        cboForm.Items.Add("PrintProductionSchedulingList2")
        cboForm.Items.Add("PrintPriceSheetIncrease")
        cboForm.Items.Add("PrintProductionWorkOrder")
        cboForm.Items.Add("PrintProductionWorkOrderHeader")
        cboForm.Items.Add("PrintPTCheckAmerican")
        cboForm.Items.Add("PrintPTCheckCanadian")
        cboForm.Items.Add("PrintPullTest")
        cboForm.Items.Add("PrintPullTestListing")
        cboForm.Items.Add("PrintPullTestLog")
        cboForm.Items.Add("PrintPurchaseClearingReport2")
        cboForm.Items.Add("PrintPurchaseLines")
        cboForm.Items.Add("PrintPurchaseLinesFiltered")
        cboForm.Items.Add("PrintPurchaseOrder")
        cboForm.Items.Add("PrintPurchaseOrderListing")
        cboForm.Items.Add("PrintQCFinalPieceSignOffs")
        cboForm.Items.Add("PrintQCHoldListing")
        cboForm.Items.Add("PrintQCInspectionReport")
        cboForm.Items.Add("PrintQCNonconReport")
        cboForm.Items.Add("PrintQCRackLocations")
        cboForm.Items.Add("PrintQuote")
        cboForm.Items.Add("PrintQuoteHeaders")
        cboForm.Items.Add("PrintQuoteHeadersFiltered")
        cboForm.Items.Add("PrintRackContents")
        cboForm.Items.Add("PrintRackingActivityLog")
        cboForm.Items.Add("PrintRackingByFilter")
        cboForm.Items.Add("PrintRackingFromPopup")
        cboForm.Items.Add("PrintRawMaterialListFiltered")
        cboForm.Items.Add("PrintReceiver")
        cboForm.Items.Add("PrintReceiverLinesFiltered")
        cboForm.Items.Add("PrintReceiverPO")
        cboForm.Items.Add("PrintReceivingHeaders")
        cboForm.Items.Add("PrintReceivingHeadersFiltered")
        cboForm.Items.Add("PrintReceivingRegister")
        cboForm.Items.Add("PrintRecurringPayment")
        cboForm.Items.Add("PrintRecurringVoucher")
        cboForm.Items.Add("PrintReorderWorksheet")
        cboForm.Items.Add("PrintRequisition")
        cboForm.Items.Add("PrintSalesByCategory")
        cboForm.Items.Add("PrintSalesByDayOfWeek")
        cboForm.Items.Add("PrintSalesByItemClass")
        cboForm.Items.Add("PrintSalesByMonth")
        cboForm.Items.Add("PrintSalesByState")
        cboForm.Items.Add("PrintSalesConfirmation")
        cboForm.Items.Add("PrintSalesLines")
        cboForm.Items.Add("PrintSalesLinesFiltered")
        cboForm.Items.Add("PrintSalesOrder")
        cboForm.Items.Add("PrintSalesOrderListing")
        cboForm.Items.Add("PrintSalesOrderListingBySalesman")
        cboForm.Items.Add("PrintSalesSummary")
        cboForm.Items.Add("PrintSalesTaxReport")
        cboForm.Items.Add("PrintSalesTaxReportTFF")
        cboForm.Items.Add("PrintSerialLog")
        cboForm.Items.Add("PrintSerialNumberQOH")
        cboForm.Items.Add("PrintShipment")
        cboForm.Items.Add("PrintShipmentConfirmation")
        cboForm.Items.Add("PrintShipmentFreightDetails")
        cboForm.Items.Add("PrintShipmentLines")
        cboForm.Items.Add("PrintShipmentLinesFiltered")
        cboForm.Items.Add("PrintShipmentLogReportFiltered")
        cboForm.Items.Add("PrintShipmentLotNumbersFiltered")
        cboForm.Items.Add("PrintShipmentMargin")
        cboForm.Items.Add("PrintShipmentsForInvoicing")
        cboForm.Items.Add("PrintShipmentStatus")
        cboForm.Items.Add("PrintShipmentStatusFiltered")
        cboForm.Items.Add("PrintShippers")
        cboForm.Items.Add("PrintShippingAddresses")
        cboForm.Items.Add("PrintShippingBOLMultiple")
        cboForm.Items.Add("PrintSingleAPCheck")
        cboForm.Items.Add("PrintSOWorkOrder")
        cboForm.Items.Add("PrintSteelAdjustment")
        cboForm.Items.Add("PrintSteelBalanceDiscreptancyReport")
        cboForm.Items.Add("PrintSteelBalances")
        cboForm.Items.Add("PrintSteelCoilTotals")
        cboForm.Items.Add("PrintSteelCoilTransfer")
        cboForm.Items.Add("PrintSteelConsumption")
        cboForm.Items.Add("PrintSteelCurrentCosting")
        cboForm.Items.Add("PrintSteelInventoryValue")
        cboForm.Items.Add("PrintSteelList")
        cboForm.Items.Add("PrintSteelMonthConsumption")
        cboForm.Items.Add("PrintSteelPurchaseLines")
        cboForm.Items.Add("PrintSteelPurchaseOrder")
        cboForm.Items.Add("PrintSteelReceiptOfGoods")
        cboForm.Items.Add("PrintSteelReceivingCoilLines")
        cboForm.Items.Add("PrintSteelReceivingLines")
        cboForm.Items.Add("PrintSteelReceivingSummary")
        cboForm.Items.Add("PrintSteelReport")
        cboForm.Items.Add("PrintSteelRequirements")
        cboForm.Items.Add("PrintSteelSpecialOrders")
        cboForm.Items.Add("PrintSteelTransactions")
        cboForm.Items.Add("PrintSteelUsage")
        cboForm.Items.Add("PrintSteelUsageLines")
        cboForm.Items.Add("PrintSteelVendorReturn")
        cboForm.Items.Add("PrintSteelVendorReturnLines")
        cboForm.Items.Add("PrintSteelWIPReportNew")
        cboForm.Items.Add("PrintSteelWireYardEntry")
        cboForm.Items.Add("PrintSteelYardEntryFiltered")
        cboForm.Items.Add("PrintStockStatus")
        cboForm.Items.Add("PrintStockStatusUnfiltered")
        cboForm.Items.Add("PrintStockStatusValuation")
        cboForm.Items.Add("PrintStudweldingCertificate")
        cboForm.Items.Add("PrintTFAcknowledgement")
        cboForm.Items.Add("PrintTFPDiscrepancyReport")
        cboForm.Items.Add("PrintTFPInventory")
        cboForm.Items.Add("PrintTFPQuoteList")
        cboForm.Items.Add("PrintTFQuote")
        cboForm.Items.Add("PrintTFQuoteRegister")
        cboForm.Items.Add("PrintTimeSlipPostings")
        cboForm.Items.Add("PrintToolRoomInventory")
        cboForm.Items.Add("PrintTrufitCert")
        cboForm.Items.Add("PrintTrufitCertificationMechanicalTest")
        cboForm.Items.Add("PrintTrufitCertificationTorqueTest")
        cboForm.Items.Add("PrintTWCert")
        cboForm.Items.Add("PrintTWCert01")
        cboForm.Items.Add("PrintTWCertSingle")
        cboForm.Items.Add("PrintTWDStockStatus")
        cboForm.Items.Add("PrintTWFinishedGoods")
        cboForm.Items.Add("PrintTWInventoryValuation")
        cboForm.Items.Add("PrintTWQuoteRegister")
        cboForm.Items.Add("PrintTWSalesByTerritory")
        cboForm.Items.Add("PrintUnpostedInvoices")
        cboForm.Items.Add("PrintUploadedPickTicket")
        cboForm.Items.Add("PrintVendorList")
        cboForm.Items.Add("PrintVendorOnTimeReport")
        cboForm.Items.Add("PrintVendorPaymentHistory")
        cboForm.Items.Add("PrintVendorPurchaseHistory")
        cboForm.Items.Add("PrintVendorPurchaseHistoryFiltered")
        cboForm.Items.Add("PrintVendorPurchases")
        cboForm.Items.Add("PrintVendorPurchaseSummaryFiltered")
        cboForm.Items.Add("PrintVendorReceiptSummary")
        cboForm.Items.Add("PrintVendorReturn")
        cboForm.Items.Add("PrintVendorReturnDate")
        cboForm.Items.Add("PrintVendorReturnLines")
        cboForm.Items.Add("PrintVendorReturnListing")
        cboForm.Items.Add("PrintVendorReturnListingFiltered")
        cboForm.Items.Add("PrintVoucher")
        cboForm.Items.Add("PrintVoucherLinesFiltered")
        cboForm.Items.Add("PrintVoucherListing")
        cboForm.Items.Add("PrintVoucherListingPD")
        cboForm.Items.Add("PrintVoucherPostDate")
        cboForm.Items.Add("PrintVoucherPostingFiltered")
        cboForm.Items.Add("PrintWCProduction")
        cboForm.Items.Add("PrintWCProductionFiltered")
        cboForm.Items.Add("PrintWIP")
        cboForm.Items.Add("PrintWIPTotals")
        cboForm.Items.Add("PrintWIPValue")
        cboForm.Items.Add("PrintProductionGraphing")
        cboForm.Items.Add("ProductionScheduling")
        cboForm.Items.Add("PullTestData")
        cboForm.Items.Add("QCNonConformance")
        cboForm.Items.Add("QCNonConformanceAddLot")
        cboForm.Items.Add("QCNonConformanceRacking")
        cboForm.Items.Add("QCNonConformanceRackingAddToRacking")
        cboForm.Items.Add("QCShipmentSignOff")
        cboForm.Items.Add("QCTools")
        cboForm.Items.Add("QuoteForm")
        cboForm.Items.Add("RackingLocations")
        cboForm.Items.Add("RackingPopup")
        cboForm.Items.Add("RackingUtility")
        cboForm.Items.Add("RackingUtilityAddBinPreference")
        cboForm.Items.Add("RackingUtilityAddBoxPreference")
        cboForm.Items.Add("RackingUtilityAddRacking")
        cboForm.Items.Add("RackingUtilityDeleteBinPreference")
        cboForm.Items.Add("RackingUtilityDeleteRacking")
        cboForm.Items.Add("RawMaterialMaintenanceForm")
        cboForm.Items.Add("ReceiverEditMode")
        cboForm.Items.Add("Receiving")
        cboForm.Items.Add("ReprintCert")
        cboForm.Items.Add("ReprintInvoiceBatch")
        cboForm.Items.Add("ReprintPickList")
        cboForm.Items.Add("ReprintTrufitCert")
        cboForm.Items.Add("RequisitionForm")
        cboForm.Items.Add("ReturnProductForm")
        cboForm.Items.Add("SecurityManagement")
        cboForm.Items.Add("SelectCoilsForReceiving")
        cboForm.Items.Add("SelectCustomerReturnsForCredit")
        cboForm.Items.Add("SelectDropShipLines")
        cboForm.Items.Add("SelectFile")
        cboForm.Items.Add("SelectFOXFromBlueprint")
        cboForm.Items.Add("SelectGLTemplateForm")
        cboForm.Items.Add("SelectInvoicesForPayment")
        cboForm.Items.Add("SelectItemsForCustomerReturn")
        cboForm.Items.Add("SelectMultiplePO")
        cboForm.Items.Add("SelectOpenPayables")
        cboForm.Items.Add("SelectPOLines")
        cboForm.Items.Add("SelectReceiverLines")
        cboForm.Items.Add("SelectReceiverLinesForReturn")
        cboForm.Items.Add("SelectRecurringVoucher")
        cboForm.Items.Add("SelectShipmentsForInvoicing")
        cboForm.Items.Add("SelectShipmentsForNafta")
        cboForm.Items.Add("SelectSNForShipment")
        cboForm.Items.Add("SelectSteelCoilsForReceiving")
        cboForm.Items.Add("SelectSteelCoilsForReturn")
        cboForm.Items.Add("SelectSteelLinesForReceiving")
        cboForm.Items.Add("SelectSteelPOLines")
        cboForm.Items.Add("SelectSteelVendorReturnLines")
        cboForm.Items.Add("selectTrufitCertFile")
        cboForm.Items.Add("SelectVendorReturnLines")
        cboForm.Items.Add("ShipmentBOLForm")
        cboForm.Items.Add("ShipmentCheckFreight")
        cboForm.Items.Add("ShipmentCompletion")
        cboForm.Items.Add("ShipmentLabelNumber")
        cboForm.Items.Add("ShipmentLineComments")
        cboForm.Items.Add("ShipmentNaftaForm")
        cboForm.Items.Add("ShipmentTaskCreation")
        cboForm.Items.Add("ShipperInfo")
        cboForm.Items.Add("ShippingUpdater")
        cboForm.Items.Add("ShippingUpdaterRacking")
        cboForm.Items.Add("SOAccessoriesForm")
        cboForm.Items.Add("SOBrokenBoxForm")
        cboForm.Items.Add("SOForm")
        cboForm.Items.Add("SOFormPopup")
        cboForm.Items.Add("SOManufacturedCostPopup")
        cboForm.Items.Add("SOPriceBracket")
        cboForm.Items.Add("SOPurchaseCostPopup")
        cboForm.Items.Add("SOSalesPricePopup")
        cboForm.Items.Add("SplitCoilForm")
        cboForm.Items.Add("SteelAddNewCoilForm")
        cboForm.Items.Add("SteelAdjustmentForm")
        cboForm.Items.Add("SteelBalanceDiscreptancyReport")
        cboForm.Items.Add("SteelBalances")
        cboForm.Items.Add("SteelChangeCoilAndRMIDAdjustment")
        cboForm.Items.Add("SteelCoilPopup")
        cboForm.Items.Add("SteelCoilReceiving")
        cboForm.Items.Add("SteelCosting")
        cboForm.Items.Add("SteelPurchaseOrder")
        cboForm.Items.Add("SteelReceivingAdditionDataRequired")
        cboForm.Items.Add("SteelReceivingForm")
        cboForm.Items.Add("SteelReceivingFromPO")
        cboForm.Items.Add("SteelTolerances")
        cboForm.Items.Add("SteelVendorReturnForm")
        cboForm.Items.Add("SteelVendorReturnSelectReceiverLines")
        cboForm.Items.Add("SteelWireYardEntry")
        cboForm.Items.Add("SteelWireYardRemoval")
        cboForm.Items.Add("StringNumberInputBox")
        cboForm.Items.Add("TabletInventoryCheck")
        cboForm.Items.Add("TFPQuotationMachineCosting")
        cboForm.Items.Add("TFPQuoteForm")
        cboForm.Items.Add("TFPQuoteSelectNextForm")
        cboForm.Items.Add("TimeSlipForm")
        cboForm.Items.Add("TimeSlipPosting")
        cboForm.Items.Add("TimeSlipRoster")
        cboForm.Items.Add("TimeSlipSelectFOXStep")
        cboForm.Items.Add("ToolRoomInventory")
        cboForm.Items.Add("TrufitCertificationMechanicalTest")
        cboForm.Items.Add("TrufitCertificationTorqueTest")
        cboForm.Items.Add("TrufitMaterialCompliance")
        cboForm.Items.Add("UploadSDS")
        cboForm.Items.Add("VendorCertForm")
        cboForm.Items.Add("VendorClassMaintenance")
        cboForm.Items.Add("VendorInfoPopup")
        cboForm.Items.Add("VendorInformantion")
        cboForm.Items.Add("VendorPurchasePopup")
        cboForm.Items.Add("VendorReturnForm")
        cboForm.Items.Add("ViewActivityLog")
        cboForm.Items.Add("ViewAnnealingLog")
        cboForm.Items.Add("ViewAPAging")
        cboForm.Items.Add("ViewAPCheckLog")
        cboForm.Items.Add("ViewAPVoucherPostings")
        cboForm.Items.Add("ViewAPVoucherPaid")
        cboForm.Items.Add("ViewARAging")
        cboForm.Items.Add("ViewARRecurringPayment")
        cboForm.Items.Add("ViewAssemblyBuildLines")
        cboForm.Items.Add("ViewAssemblyBuildListing")
        cboForm.Items.Add("ViewAssemblyLines")
        cboForm.Items.Add("ViewAssemblyListing")
        cboForm.Items.Add("ViewAssemblySerialLog")
        cboForm.Items.Add("ViewAuditTrail")
        cboForm.Items.Add("ViewBackOrders")
        cboForm.Items.Add("ViewBlueprints")
        cboForm.Items.Add("ViewBlueprintSelectToolingPrint")
        cboForm.Items.Add("ViewBlueprintsLogin")
        cboForm.Items.Add("ViewCashReceipts")
        cboForm.Items.Add("ViewCertErrorLog")
        cboForm.Items.Add("ViewCharterSteelCoils")
        cboForm.Items.Add("ViewConsignmentAdjustments")
        cboForm.Items.Add("ViewConsignmentBilling")
        cboForm.Items.Add("ViewConsignmentInventory")
        cboForm.Items.Add("ViewConsignmentReturns")
        cboForm.Items.Add("ViewConsignmentShipping")
        cboForm.Items.Add("ViewConsignmentTotals")
        cboForm.Items.Add("ViewCustomerListing")
        cboForm.Items.Add("ViewCustomerOrders")
        cboForm.Items.Add("ViewCustomerPaymentActivity")
        cboForm.Items.Add("ViewCustomerReturnListing")
        cboForm.Items.Add("ViewCustomerSalesHistory")
        cboForm.Items.Add("ViewDailyShipmentLog")
        cboForm.Items.Add("ViewEditTrufitCerts")
        cboForm.Items.Add("ViewEFTRemmittance")
        cboForm.Items.Add("ViewEmployeeLogonTable")
        cboForm.Items.Add("ViewDropShipPOs")
        cboForm.Items.Add("ViewDropShipSOs")
        cboForm.Items.Add("ViewEmployeeLogonTable")
        cboForm.Items.Add("ViewFoxInspectionEntries")
        cboForm.Items.Add("ViewFOXListing")
        cboForm.Items.Add("ViewFOXReleaseSchedule")
        cboForm.Items.Add("ViewFOXStepCosting")
        cboForm.Items.Add("ViewGaugeSignouts")
        cboForm.Items.Add("ViewGLChartOfAccounts")
        cboForm.Items.Add("ViewGLLinePostings")
        cboForm.Items.Add("ViewGLTransactionListing")
        cboForm.Items.Add("ViewHeaderFOXPostings")
        cboForm.Items.Add("ViewHeaderSetupSheets")
        cboForm.Items.Add("ViewHeatNumberLog")
        cboForm.Items.Add("ViewHeatTreatInspectionLog")
        cboForm.Items.Add("ViewInspectionReport")
        cboForm.Items.Add("ViewInspectionReportUploadFiles")
        cboForm.Items.Add("ViewInventoryAdjustments")
        cboForm.Items.Add("ViewInventoryCoilWIP")
        cboForm.Items.Add("ViewInventoryPage")
        cboForm.Items.Add("ViewInventoryTransactions")
        cboForm.Items.Add("ViewInventoryValueByFilter")
        cboForm.Items.Add("ViewInvoiceDetails")
        cboForm.Items.Add("ViewInvoiceLedgerPostings")
        cboForm.Items.Add("ViewInvoiceLines")
        cboForm.Items.Add("ViewInvoiceLinesBySort")
        cboForm.Items.Add("ViewInvoiceListing")
        cboForm.Items.Add("ViewItemListing")
        cboForm.Items.Add("ViewLeadTimes")
        cboForm.Items.Add("ViewLotNumbers")
        cboForm.Items.Add("ViewManualBOLs")
        cboForm.Items.Add("ViewOpenPurchaseLines")
        cboForm.Items.Add("ViewOpenSOLines")
        cboForm.Items.Add("ViewOpenSteelPO")
        cboForm.Items.Add("ViewPartNumberSalesTotals")
        cboForm.Items.Add("ViewPendingShipments")
        cboForm.Items.Add("ViewPickQuantityOnHand")
        cboForm.Items.Add("ViewPickTickets")
        cboForm.Items.Add("ViewPitcureFullScreen")
        cboForm.Items.Add("ViewPOHeaders")
        cboForm.Items.Add("ViewMillCertPopup")
        cboForm.Items.Add("ViewPrintMillCertUpload")
        cboForm.Items.Add("ViewPullTestLog")
        cboForm.Items.Add("ViewPullTests")
        cboForm.Items.Add("ViewPurchaseLines")
        cboForm.Items.Add("ViewQCNonConformance")
        cboForm.Items.Add("ViewQuoteListing")
        cboForm.Items.Add("ViewRacking")
        cboForm.Items.Add("ViewRackingActivityLog")
        cboForm.Items.Add("ViewRackingInventory")
        cboForm.Items.Add("ViewReceiverLines")
        cboForm.Items.Add("ViewReceivingHeaders")
        cboForm.Items.Add("ViewReceivingOnTime")
        cboForm.Items.Add("ViewSafetyDataSheets")
        cboForm.Items.Add("ViewSalesByCategory")
        cboForm.Items.Add("ViewSalesLines")
        cboForm.Items.Add("ViewSalesOrderHeaders")
        cboForm.Items.Add("ViewSaltSprayInspection")
        cboForm.Items.Add("ViewSaltSprayInspectionUploadFiles")
        cboForm.Items.Add("ViewShipmentDetails")
        cboForm.Items.Add("ViewShipmentLines")
        cboForm.Items.Add("ViewShipmentLineSerialNumbers")
        cboForm.Items.Add("ViewShipmentLotNumbers")
        cboForm.Items.Add("ViewShipmentsForInvoicing")
        cboForm.Items.Add("ViewShipmentStatus")
        cboForm.Items.Add("ViewShippingFreightDetails")
        cboForm.Items.Add("ViewSteelAdjustments")
        cboForm.Items.Add("ViewSteelCoils")
        cboForm.Items.Add("ViewSteelCoilsCoilComment")
        cboForm.Items.Add("ViewSteelInventoryValue")
        cboForm.Items.Add("ViewSteelList")
        cboForm.Items.Add("ViewSteelPurchaseLines")
        cboForm.Items.Add("ViewSteelReceipts")
        cboForm.Items.Add("ViewSteelReceivingCoilLines")
        cboForm.Items.Add("ViewSteelReceivingInspections")
        cboForm.Items.Add("ViewSteelRequirementDetails")
        cboForm.Items.Add("ViewSteelRequirements")
        cboForm.Items.Add("ViewSteelSpecialOrders")
        cboForm.Items.Add("ViewSteelTransactions")
        cboForm.Items.Add("ViewSteelUsage")
        cboForm.Items.Add("ViewSteelUsageByMonth")
        cboForm.Items.Add("ViewSteelUsageByWeek")
        cboForm.Items.Add("ViewSteelVendorReturns")
        cboForm.Items.Add("ViewSteelWireYardEntry")
        cboForm.Items.Add("ViewStockStatusValuation")
        cboForm.Items.Add("ViewTaxCollected")
        cboForm.Items.Add("ViewTestLog")
        cboForm.Items.Add("ViewTFPInventory")
        cboForm.Items.Add("ViewTFPQuoteListing")
        cboForm.Items.Add("ViewTimeSlipRoster")
        cboForm.Items.Add("ViewTimeSlips")
        cboForm.Items.Add("ViewTimeSlipTotals")
        cboForm.Items.Add("ViewTrufitCertifications")
        cboForm.Items.Add("ViewTubPage")
        cboForm.Items.Add("ViewVendorListing")
        cboForm.Items.Add("ViewVendorReturnLines")
        cboForm.Items.Add("ViewVendorReturns")
        cboForm.Items.Add("ViewVendorSummary")
        cboForm.Items.Add("ViewVoucherLines")
        cboForm.Items.Add("ViewVoucherListing")
        cboForm.Items.Add("ViewWCProductionPostings")
        cboForm.Items.Add("ViewWIP")
        cboForm.Items.Add("ViewWIPPopup")
        cboForm.Items.Add("ViewWIPValue")
        cboForm.Items.Add("WIAScannerSelection")

        For i As Integer = 0 To cboForm.Items.Count - 1
            cboCopyForm.Items.Add(cboForm.Items(i))
        Next
    End Sub

    Private Sub LoadControls()
        currentForm = GetForm()
        AddControls(currentForm)
    End Sub

    Private Sub AddControls(ByVal frm As System.Windows.Forms.Form)
        If frm Is Nothing Then
            Exit Sub
        End If
        For Each ctrl As Control In frm.Controls
            If TypeOf (ctrl) Is MenuStrip Then
                Dim mnu As System.Windows.Forms.MenuStrip = ctrl
                If mnu.Items.Count > 0 Then
                    For Each mnuItem As ToolStripMenuItem In mnu.Items
                        If mnuItem.DropDownItems.Count > 0 Then
                            For Each subMnuItem As ToolStripMenuItem In mnuItem.DropDownItems
                                cboControls.Items.Add(subMnuItem.Name)
                            Next
                        End If
                    Next
                End If
            ElseIf TypeOf (ctrl) Is Control Then
                cboControls.Items.Add(ctrl.Name)
                If ctrl.Controls.Count > 0 Then
                    AddControls(ctrl)
                End If
            End If
        Next
    End Sub

    Private Sub AddControls(ByVal baseCtrl As System.Windows.Forms.Control)
        If baseCtrl Is Nothing Then
            Exit Sub
        End If
        For Each ctrl As Control In baseCtrl.Controls
            If TypeOf (ctrl) Is MenuStrip Then
                Dim mnu As System.Windows.Forms.MenuStrip = ctrl
                If mnu.Items.Count > 0 Then
                    For Each mnuItem As ToolStripMenuItem In mnu.Items
                        If mnuItem.DropDownItems.Count > 0 Then
                            For Each subMnuItem As ToolStripMenuItem In mnuItem.DropDownItems
                                cboControls.Items.Add(subMnuItem.Name)
                            Next
                        End If
                    Next
                End If
            ElseIf TypeOf (ctrl) Is Control Then
                cboControls.Items.Add(ctrl.Name)
                If ctrl.Controls.Count > 0 Then
                    AddControls(ctrl)
                End If
            End If
        Next
    End Sub

    Private Sub cboForm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboForm.SelectedIndexChanged
        If isLoaded Then
            cboControls.Items.Clear()
            LoadControls()
        End If
    End Sub

    Private Sub cboSecurityFor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecurityFor.SelectedIndexChanged
        If isLoaded Then
            Select Case cboSecurityFor.Text
                Case "Security Level"
                    If lblEmployeeID.Visible Then
                        lblEmployeeID.Hide()
                        cboEmployeeID.Hide()
                    End If
                    If lblDivisionID.Visible Then
                        lblDivisionID.Hide()
                        cboDivisionID.Hide()
                    End If
                    lblSecurityID.Show()
                    cboSecurityID.Show()
                    tabCtrlPermissions.SelectTab("tabSecurityPermissions")
                Case "Employee"
                    If lblDivisionID.Visible Then
                        lblDivisionID.Hide()
                        cboDivisionID.Hide()
                    End If
                    If lblSecurityID.Visible Then
                        lblSecurityID.Hide()
                        cboSecurityID.Hide()
                    End If
                    lblEmployeeID.Show()
                    cboEmployeeID.Show()
                    tabCtrlPermissions.SelectTab("tabEmployeePermissions")
                Case "Division"
                    If lblEmployeeID.Visible Then
                        lblEmployeeID.Hide()
                        cboEmployeeID.Hide()
                    End If
                    If lblSecurityID.Visible Then
                        lblSecurityID.Hide()
                        cboSecurityID.Hide()
                    End If
                    lblDivisionID.Show()
                    cboDivisionID.Show()
                    tabCtrlPermissions.SelectTab("tabDivisionPermissions")
            End Select
        End If
    End Sub

    Private Sub cboEmployeeID_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmployeeID.VisibleChanged
        If isLoaded And cboEmployeeID.Visible Then
            cboEmployeeName.Show()
            If cboEmployeeID.Items.Count = 0 Then
                cmd = New SqlCommand("Select EmployeeID, EmployeeFirst + ' ' + EmployeeLast as EmployeeFullName, EmployeeLast FROM EmployeeData ORDER BY EmployeeID", con)

                Dim dt As New Data.DataTable("EmployeeData")
                Dim adap As New SqlDataAdapter(cmd)

                If con.State = ConnectionState.Closed Then con.Open()
                adap.Fill(dt)
                con.Close()

                isLoaded = False
                cboEmployeeID.DisplayMember = "EmployeeID"
                cboEmployeeID.DataSource = dt
                cboEmployeeID.SelectedIndex = -1
                cboEmployeeName.DisplayMember = "EmployeeFullName"
                cboEmployeeName.DataSource = dt
                cboEmployeeName.SelectedIndex = -1
                isLoaded = True

                drSortedEmployeeList = dt.Select("", "EmployeeLast ASC")

            End If
        Else
            cboEmployeeName.Hide()
        End If
    End Sub

    Private Sub cboDivisionID_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.VisibleChanged
        If isLoaded And cboDivisionID.Visible Then
            If cboDivisionID.Items.Count = 0 Then
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        cboDivisionID.Items.Add(reader.Item("DivisionKey"))
                    End While
                End If
                reader.Close()
                con.Close()
            End If
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboSecurityFor.SelectedIndex = -1
        cboDivisionID.Items.Clear()
        cboDivisionID.Text = ""
        cboEmployeeID.DataSource = Nothing
        cboEmployeeID.Text = ""
        If lblEmployeeID.Visible Then
            lblEmployeeID.Hide()
            cboEmployeeID.Hide()
        End If
        If lblDivisionID.Visible Then
            lblDivisionID.Hide()
            cboDivisionID.Hide()
        End If
        If lblSecurityID.Visible Then
            lblSecurityID.Hide()
            cboSecurityID.Hide()
        End If

        cboForm.SelectedIndex = -1
        cboControls.Items.Clear()
        cboControls.Text = ""
        cboProperty.SelectedIndex = -1
        cboValue.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboValue.Text) Then
            cboValue.Text = ""
        End If
    End Sub

    Private Sub cboCopySecurityFor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCopySecurityFor.SelectedIndexChanged
        If isLoaded Then
            Select Case cboCopySecurityFor.Text
                Case "Security Level"
                    If lblFromEmployeeID.Visible Then
                        lblFromEmployeeID.Hide()
                        lblToEmployeeID.Hide()
                        cboFromEmployeeID.Hide()
                        cboToEmployeeID.Hide()
                    End If
                    If lblFromDivisionID.Visible Then
                        lblFromDivisionID.Hide()
                        lblToDivisionID.Hide()
                        cboFromDivisionID.Hide()
                        cboToDivisionID.Hide()
                    End If
                    lblFromSecurityID.Show()
                    lblToSecurityID.Show()
                    cboFromSecurityID.Show()
                    cboToSecurityID.Show()
                    tabCtrlPermissions.SelectTab("tabSecurityPermissions")
                Case "Employee"
                    If lblFromDivisionID.Visible Then
                        lblFromDivisionID.Hide()
                        lblToDivisionID.Hide()
                        cboFromDivisionID.Hide()
                        cboToDivisionID.Hide()
                    End If
                    If lblFromSecurityID.Visible Then
                        lblFromSecurityID.Hide()
                        lblToSecurityID.Hide()
                        cboFromSecurityID.Hide()
                        cboToSecurityID.Hide()
                    End If
                    lblFromEmployeeID.Show()
                    lblToEmployeeID.Show()
                    cboFromEmployeeID.Show()
                    cboToEmployeeID.Show()
                    tabCtrlPermissions.SelectTab("tabEmployeePermissions")
                Case "Division"
                    If lblFromEmployeeID.Visible Then
                        lblFromEmployeeID.Hide()
                        lblToEmployeeID.Hide()
                        cboFromEmployeeID.Hide()
                        cboToEmployeeID.Hide()
                    End If
                    If lblFromSecurityID.Visible Then
                        lblFromSecurityID.Hide()
                        lblToSecurityID.Hide()
                        cboFromSecurityID.Hide()
                        cboToSecurityID.Hide()
                    End If
                    lblFromDivisionID.Show()
                    lblToDivisionID.Show()
                    cboFromDivisionID.Show()
                    cboToDivisionID.Show()
                    tabCtrlPermissions.SelectTab("tabDivisionPermissions")
            End Select
        End If
    End Sub

    Private Sub cboFromEmployeeID_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFromEmployeeID.VisibleChanged
        If isLoaded And cboFromEmployeeID.Visible Then
            If cboFromEmployeeID.Items.Count = 0 Then
                cmd = New SqlCommand("Select EmployeeID FROM EmployeeData", con)

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        cboFromEmployeeID.Items.Add(reader.Item("EmployeeID"))
                        cboToEmployeeID.Items.Add(reader.Item("EmployeeID"))
                    End While
                End If
                reader.Close()
                con.Close()
            End If
        End If
    End Sub

    Private Sub cboFromDivisionID_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFromDivisionID.VisibleChanged
        If isLoaded And cboFromDivisionID.Visible Then
            If cboFromDivisionID.Items.Count = 0 Then
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        cboFromDivisionID.Items.Add(reader.Item("DivisionKey"))
                        cboToDivisionID.Items.Add(reader.Item("DivisionKey"))
                    End While
                End If
                reader.Close()
                con.Close()
            End If
        End If
    End Sub

    Private Sub cboSecurityID_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecurityID.VisibleChanged
        If isLoaded And cboSecurityID.Visible Then
            If cboSecurityID.Items.Count = 0 Then
                cmd = New SqlCommand("SELECT DISTINCT(SecurityGroupID) AS SecurityGroupID FROM EmployeeData", con)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        cboSecurityID.Items.Add(reader.Item("SecurityGroupID"))
                    End While
                End If
                reader.Close()
                con.Close()
            End If
        End If
    End Sub

    Private Sub cboFromSecurityID_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFromSecurityID.VisibleChanged
        If isLoaded And cboFromSecurityID.Visible Then
            If cboFromSecurityID.Items.Count = 0 Then
                cmd = New SqlCommand("SELECT DISTINCT(SecurityGroupID) AS SecurityGroupID FROM EmployeeData", con)
                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        cboFromSecurityID.Items.Add(reader.Item("SecurityGroupID"))
                        cboToSecurityID.Items.Add(reader.Item("SecurityGroupID"))
                    End While
                End If
                reader.Close()
                con.Close()
            End If
        End If
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        If canAdd() Then
            If cboControls.Text.StartsWith("dgv") Then
                If String.IsNullOrEmpty(cboColumn.Text) Then
                    Select Case cboSecurityFor.Text
                        Case "Security Level"
                            cmd = New SqlCommand("IF Exists(SELECT * FROM StandardSecurityPermissions WHERE SecurityGroupID = @SecurityGroupID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty) UPDATE StandardSecurityPermissions SET ControlValue = @ControlValue WHERE SecurityGroupID = @SecurityGroupID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty ELSE INSERT INTO StandardSecurityPermissions (SecurityGroupID, FormName, ControlName, ControlProperty, ControlValue)VALUES(@SecurityGroupID, @FormName, @ControlName, @ControlProperty, @ControlValue)", con)
                            cmd.Parameters.Add("@SecurityGroupID", SqlDbType.VarChar).Value = cboSecurityID.Text
                        Case "Employee"
                            cmd = New SqlCommand("IF Exists(SELECT * FROM SpecialSecurityPermissions WHERE EmployeeID = @EmployeeID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty) UPDATE SpecialSecurityPermissions SET ControlValue = @ControlValue WHERE EmployeeID = @EmployeeID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty ELSE INSERT INTO SpecialSecurityPermissions (EmployeeID, FormName, ControlName, ControlProperty, ControlValue)VALUES(@EmployeeID, @FormName, @ControlName, @ControlProperty, @ControlValue)", con)
                            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
                        Case "Division"
                            cmd = New SqlCommand("IF Exists(SELECT * FROM DivisionSecurityPermissions WHERE DivisionID = @DivisionID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty) UPDATE DivisionSecurityPermissions SET ControlValue = @ControlValue WHERE DivisionID = @DivisionID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty ELSE INSERT INTO DivisionSecurityPermissions (DivisionID, FormName, ControlName, ControlProperty, ControlValue)VALUES(@DivisionID, @FormName, @ControlName, @ControlProperty, @ControlValue)", con)
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End Select
                Else
                    Select Case cboSecurityFor.Text
                        Case "Security Level"
                            cmd = New SqlCommand("IF Exists(SELECT * FROM StandardSecurityPermissions WHERE SecurityGroupID = @SecurityGroupID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty AND ColumnName = @ColumnName) UPDATE StandardSecurityPermissions SET ControlValue = @ControlValue WHERE SecurityGroupID = @SecurityGroupID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty AND ColumnName = @ColumnName ELSE INSERT INTO StandardSecurityPermissions (SecurityGroupID, FormName, ControlName, ControlProperty, ControlValue, ColumnName)VALUES(@SecurityGroupID, @FormName, @ControlName, @ControlProperty, @ControlValue, @ColumnName)", con)
                            cmd.Parameters.Add("@SecurityGroupID", SqlDbType.VarChar).Value = cboSecurityID.Text
                        Case "Employee"
                            cmd = New SqlCommand("IF Exists(SELECT * FROM SpecialSecurityPermissions WHERE EmployeeID = @EmployeeID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty AND ColumnName = @ColumnName) UPDATE SpecialSecurityPermissions SET ControlValue = @ControlValue WHERE EmployeeID = @EmployeeID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty AND ColumnName = @ColumnName ELSE INSERT INTO SpecialSecurityPermissions (EmployeeID, FormName, ControlName, ControlProperty, ControlValue, eColumnName)VALUES(@EmployeeID, @FormName, @ControlName, @ControlProperty, @ControlValue, @ColumnName)", con)
                            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
                        Case "Division"
                            cmd = New SqlCommand("IF Exists(SELECT * FROM DivisionSecurityPermissions WHERE DivisionID = @DivisionID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty AND ColumnName = @ColumnName) UPDATE DivisionSecurityPermissions SET ControlValue = @ControlValue WHERE DivisionID = @DivisionID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty AND ColumnName = @ColumnName ELSE INSERT INTO DivisionSecurityPermissions (DivisionID, FormName, ControlName, ControlProperty, ControlValue, ColumnName)VALUES(@DivisionID, @FormName, @ControlName, @ControlProperty, @ControlValue, @ColumnName)", con)
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End Select

                    cmd.Parameters.Add("@ColumnName", SqlDbType.VarChar).Value = cboColumn.Text
                End If

            Else
                Select Case cboSecurityFor.Text
                    Case "Security Level"
                        cmd = New SqlCommand("IF Exists(SELECT * FROM StandardSecurityPermissions WHERE SecurityGroupID = @SecurityGroupID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty) UPDATE StandardSecurityPermissions SET ControlValue = @ControlValue WHERE SecurityGroupID = @SecurityGroupID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty ELSE INSERT INTO StandardSecurityPermissions (SecurityGroupID, FormName, ControlName, ControlProperty, ControlValue)VALUES(@SecurityGroupID, @FormName, @ControlName, @ControlProperty, @ControlValue)", con)
                        cmd.Parameters.Add("@SecurityGroupID", SqlDbType.VarChar).Value = cboSecurityID.Text
                    Case "Employee"
                        cmd = New SqlCommand("IF Exists(SELECT * FROM SpecialSecurityPermissions WHERE EmployeeID = @EmployeeID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty) UPDATE SpecialSecurityPermissions SET ControlValue = @ControlValue WHERE EmployeeID = @EmployeeID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty ELSE INSERT INTO SpecialSecurityPermissions (EmployeeID, FormName, ControlName, ControlProperty, ControlValue)VALUES(@EmployeeID, @FormName, @ControlName, @ControlProperty, @ControlValue)", con)
                        cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
                    Case "Division"
                        cmd = New SqlCommand("IF Exists(SELECT * FROM DivisionSecurityPermissions WHERE DivisionID = @DivisionID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty) UPDATE DivisionSecurityPermissions SET ControlValue = @ControlValue WHERE DivisionID = @DivisionID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty ELSE INSERT INTO DivisionSecurityPermissions (DivisionID, FormName, ControlName, ControlProperty, ControlValue)VALUES(@DivisionID, @FormName, @ControlName, @ControlProperty, @ControlValue)", con)
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End Select
            End If

            cmd.Parameters.Add("@FormName", SqlDbType.VarChar).Value = cboForm.Text
            cmd.Parameters.Add("@ControlName", SqlDbType.VarChar).Value = cboControls.Text
            cmd.Parameters.Add("@ControlProperty", SqlDbType.VarChar).Value = cboProperty.Text
            cmd.Parameters.Add("@ControlValue", SqlDbType.VarChar).Value = cboValue.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'cboProperty.SelectedIndex = -1
            'cboValue.SelectedIndex = -1
            'If Not String.IsNullOrEmpty(cboValue.Text) Then
            '    cboValue.Text = ""
            'End If
            ShowData()
        End If
    End Sub

    Private Function canAdd() As Boolean
        Select Case cboSecurityFor.Text
            Case "Security Level"
                If String.IsNullOrEmpty(cboSecurityID.Text) Then
                    MessageBox.Show("You must select a security level.", "You must select a security level", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboSecurityID.Focus()
                    Return False
                End If
                'If cboSecurityID.SelectedIndex = -1 Then
                '    MessageBox.Show("You must enter a valid security ID.", "Enter a valid security ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    cboSecurityID.SelectAll()
                '    cboSecurityID.Focus()
                '    Return False
                'End If
            Case "Employee"
                If String.IsNullOrEmpty(cboEmployeeID.Text) Then
                    MessageBox.Show("You must select an employee ID.", "Select an employee ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboEmployeeID.Focus()
                    Return False
                End If
                If cboEmployeeID.SelectedIndex = -1 Then
                    MessageBox.Show("You must enter a valid employee ID", "Enter a valid employee ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboEmployeeID.SelectAll()
                    cboEmployeeID.Focus()
                    Return False
                End If
            Case "Division"
                If String.IsNullOrEmpty(cboDivisionID.Text) Then
                    MessageBox.Show("You must select a division.", "Select a division", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboDivisionID.Focus()
                    Return False
                End If
                If cboDivisionID.SelectedIndex = -1 Then
                    MessageBox.Show("You must enter a valid division.", "Enter a valid division", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboDivisionID.SelectAll()
                    cboDivisionID.Focus()
                    Return False
                End If
            Case Else
                MessageBox.Show("You must select what type of security to add", "Select a type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboSecurityFor.Focus()
                Return False
        End Select
        If String.IsNullOrEmpty(cboForm.Text) Then
            MessageBox.Show("You must enter a form.", "Enter a form", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboForm.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboControls.Text) Then
            MessageBox.Show("You must enter a control.", "Enter a control", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboControls.Focus()
            Return False
        End If
        'If cboControls.Text.StartsWith("dgv") Then
        '    If String.IsNullOrEmpty(cboColumn.Text) Then
        '        MessageBox.Show("You must enter a column name.", "Enter a column name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        cboColumn.Focus()
        '        Return False
        '    End If
        'End If
        If String.IsNullOrEmpty(cboValue.Text) Then
            MessageBox.Show("You must enter a property value", "Enter a property value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboValue.Focus()
            Return False
        End If
        If cboValue.Text.Length > 50 Then
            MessageBox.Show("Value can't exceed 50 characters.", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboValue.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub tabCtrlPermissions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabCtrlPermissions.SelectedIndexChanged
        ShowData()
    End Sub

    Private Sub SetupSecurityDGV()
        dgvSecurityPermissions.Columns("SecurityGroupID").HeaderText = "Security Group ID"
        dgvSecurityPermissions.Columns("SecurityGroupID").ReadOnly = True
        dgvSecurityPermissions.Columns("FormName").HeaderText = "Form Name"
        dgvSecurityPermissions.Columns("FormName").ReadOnly = True
        dgvSecurityPermissions.Columns("ControlName").HeaderText = "Control Name"
        dgvSecurityPermissions.Columns("ControlName").ReadOnly = True
        dgvSecurityPermissions.Columns("ControlProperty").HeaderText = "Control Property"
        dgvSecurityPermissions.Columns("ControlProperty").ReadOnly = True
        dgvSecurityPermissions.Columns("ColumnName").HeaderText = "ColumnName"
        dgvSecurityPermissions.Columns("ColumnName").ReadOnly = True
        dgvSecurityPermissions.Columns("ControlValue").HeaderText = "Control Value"
    End Sub

    Private Sub SetupDivisionDGV()
        dgvDivisionPermissions.Columns("DivisionID").HeaderText = "Division ID"
        dgvDivisionPermissions.Columns("DivisionID").ReadOnly = True
        dgvDivisionPermissions.Columns("FormName").HeaderText = "Form Name"
        dgvDivisionPermissions.Columns("FormName").ReadOnly = True
        dgvDivisionPermissions.Columns("ControlName").HeaderText = "Control Name"
        dgvDivisionPermissions.Columns("ControlName").ReadOnly = True
        dgvDivisionPermissions.Columns("ControlProperty").HeaderText = "Control Property"
        dgvDivisionPermissions.Columns("ControlProperty").ReadOnly = True
        dgvDivisionPermissions.Columns("ColumnName").HeaderText = "Column Name"
        dgvDivisionPermissions.Columns("ColumnName").ReadOnly = True
        dgvDivisionPermissions.Columns("ControlValue").HeaderText = "Control Value"
    End Sub

    Private Sub SetupEmployeeDGV()
        dgvEmployeePermissions.Columns("EmployeeID").HeaderText = "Employee ID"
        dgvEmployeePermissions.Columns("EmployeeID").ReadOnly = True
        dgvEmployeePermissions.Columns("EmployeeFullName").HeaderText = "Employee Name"
        dgvEmployeePermissions.Columns("EmployeeFullName").ReadOnly = True
        dgvEmployeePermissions.Columns("FormName").HeaderText = "Form Name"
        dgvEmployeePermissions.Columns("FormName").ReadOnly = True
        dgvEmployeePermissions.Columns("ControlName").HeaderText = "Control Name"
        dgvEmployeePermissions.Columns("ControlName").ReadOnly = True
        dgvEmployeePermissions.Columns("ControlProperty").HeaderText = "Control Property"
        dgvEmployeePermissions.Columns("ControlProperty").ReadOnly = True
        dgvEmployeePermissions.Columns("ColumnName").HeaderText = "Column Name"
        dgvEmployeePermissions.Columns("ColumnName").ReadOnly = True
        dgvEmployeePermissions.Columns("ControlValue").HeaderText = "Control Value"
    End Sub

    Private Sub ShowData()
        Select Case tabCtrlPermissions.SelectedTab.Name
            Case "tabSecurityPermissions"
                If ds.Tables.Contains("StandardSecurityPermissions") Then
                    ds.Tables("StandardSecurityPermissions").Clear()
                End If
                cmd = New SqlCommand("SELECT SecurityGroupID, FormName, ControlName, ColumnName, ControlProperty, ControlValue FROM StandardSecurityPermissions", con)
                If cboSecurityID.SelectedIndex <> -1 Then
                    cmd.CommandText += " WHERE SecurityGroupID = @SecurityGroupID"
                    cmd.Parameters.Add("@SecurityGroupID", SqlDbType.VarChar).Value = cboSecurityID.Text
                End If
                Dim adap As New SqlDataAdapter(cmd)

                If con.State = ConnectionState.Closed Then con.Open()
                adap.Fill(ds, "StandardSecurityPermissions")
                con.Close()

                dgvSecurityPermissions.DataSource = ds.Tables("StandardSecurityPermissions")
                SetupSecurityDGV()
            Case "tabDivisionPermissions"
                If ds.Tables.Contains("DivisionSecurityPermissions") Then
                    ds.Tables("DivisionSecurityPermissions").Clear()
                End If
                cmd = New SqlCommand("SELECT DivisionID, FormName, ControlName, ColumnName, ControlProperty, ControlValue FROM DivisionSecurityPermissions", con)
                If cboDivisionID.SelectedIndex <> -1 Then
                    cmd.CommandText += " WHERE DivisionID = @DivisionID"
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End If
                Dim adap As New SqlDataAdapter(cmd)

                If con.State = ConnectionState.Closed Then con.Open()
                adap.Fill(ds, "DivisionSecurityPermissions")
                con.Close()

                dgvDivisionPermissions.DataSource = ds.Tables("DivisionSecurityPermissions")
                SetupDivisionDGV()
            Case "tabEmployeePermissions"
                If ds.Tables.Contains("SpecialSecurityPermissions") Then
                    ds.Tables("SpecialSecurityPermissions").Clear()
                End If
                cmd = New SqlCommand("SELECT SpecialSecurityPermissions.EmployeeID, EmployeeData.EmployeeFirst + ' ' + EmployeeData.EmployeeLast as EmployeeFullName, FormName, ControlName, ColumnName, ControlProperty, ControlValue FROM SpecialSecurityPermissions LEFT OUTER JOIN EmployeeData ON SpecialSecurityPermissions.EmployeeID = EmployeeData.EmployeeID", con)
                If cboEmployeeID.SelectedIndex <> -1 Then
                    cmd.CommandText += " WHERE SpecialSecurityPermissions.EmployeeID = @EmployeeID"
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeID.Text
                End If

                Dim adap As New SqlDataAdapter(cmd)

                If con.State = ConnectionState.Closed Then con.Open()
                adap.Fill(ds, "SpecialSecurityPermissions")
                con.Close()
                dgvEmployeePermissions.DataSource = ds.Tables("SpecialSecurityPermissions")
                SetupEmployeeDGV()
        End Select
    End Sub

    Private Sub cmdDeleteSecuritySelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSelected.Click
        If canDeleteSecurity() Then
            Select Case tabCtrlPermissions.SelectedTab.Name
                Case "tabSecurityPermissions"
                    ''delete for Security level
                    If dgvSecurityPermissions.SelectedRows.Count > 0 Then
                        cmd = New SqlCommand("DELETE StandardSecurityPermissions WHERE ", con)
                        For i As Integer = 0 To dgvSecurityPermissions.SelectedRows.Count - 1
                            If i = 0 Then
                                cmd.CommandText += " (SecurityGroupID = @SecurityGroupID" + i.ToString + " AND FormName = @FormName" + i.ToString + " AND ControlName = @ControlName" + i.ToString + " AND ControlProperty = @ControlProperty" + i.ToString + ")"
                            Else
                                cmd.CommandText += " OR (SecurityGroupID = @SecurityGroupID" + i.ToString + " AND FormName = @FormName" + i.ToString + " AND ControlName = @ControlName" + i.ToString + " AND ControlProperty = @ControlProperty" + i.ToString + ")"
                            End If

                            cmd.Parameters.Add("@SecurityGroupID" + i.ToString, SqlDbType.VarChar).Value = dgvSecurityPermissions.SelectedRows(i).Cells("SecurityGroupID").Value
                            cmd.Parameters.Add("@FormName" + i.ToString, SqlDbType.VarChar).Value = dgvSecurityPermissions.SelectedRows(i).Cells("FormName").Value
                            cmd.Parameters.Add("@ControlName" + i.ToString, SqlDbType.VarChar).Value = dgvSecurityPermissions.SelectedRows(i).Cells("ControlName").Value
                            cmd.Parameters.Add("@ControlProperty" + i.ToString, SqlDbType.VarChar).Value = dgvSecurityPermissions.SelectedRows(i).Cells("ControlProperty").Value
                        Next
                    ElseIf dgvSecurityPermissions.SelectedCells.Count > 1 Then
                        cmd = New SqlCommand("DELETE StandardSecurityPermissions WHERE ", con)
                        For i As Integer = 0 To dgvSecurityPermissions.SelectedCells.Count - 1
                            If i = 0 Then
                                cmd.CommandText += " (SecurityGroupID = @SecurityGroupID" + i.ToString + " AND FormName = @FormName" + i.ToString + " AND ControlName = @ControlName" + i.ToString + " AND ControlProperty = @ControlProperty" + i.ToString + ")"
                            Else
                                cmd.CommandText += " OR (SecurityGroupID = @SecurityGroupID" + i.ToString + " AND FormName = @FormName" + i.ToString + " AND ControlName = @ControlName" + i.ToString + " AND ControlProperty = @ControlProperty" + i.ToString + ")"
                            End If

                            cmd.Parameters.Add("@SecurityGroupID" + i.ToString, SqlDbType.VarChar).Value = dgvSecurityPermissions.Rows(dgvSecurityPermissions.SelectedCells(i).RowIndex).Cells("SecurityGroupID").Value
                            cmd.Parameters.Add("@FormName" + i.ToString, SqlDbType.VarChar).Value = dgvSecurityPermissions.Rows(dgvSecurityPermissions.SelectedCells(i).RowIndex).Cells("FormName").Value
                            cmd.Parameters.Add("@ControlName" + i.ToString, SqlDbType.VarChar).Value = dgvSecurityPermissions.Rows(dgvSecurityPermissions.SelectedCells(i).RowIndex).Cells("ControlName").Value
                            cmd.Parameters.Add("@ControlProperty" + i.ToString, SqlDbType.VarChar).Value = dgvSecurityPermissions.Rows(dgvSecurityPermissions.SelectedCells(i).RowIndex).Cells("ControlProperty").Value
                        Next
                    Else
                        If dgvSecurityPermissions.SelectedCells.Count = 1 Then
                            cmd = New SqlCommand("DELETE StandardSecurityPermissions WHERE SecurityGroupID = @SecurityGroupID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty", con)
                            cmd.Parameters.Add("@SecurityGroupID", SqlDbType.VarChar).Value = dgvSecurityPermissions.Rows(dgvSecurityPermissions.SelectedCells(0).RowIndex).Cells("SecurityGroupID").Value
                            cmd.Parameters.Add("@FormName", SqlDbType.VarChar).Value = dgvSecurityPermissions.Rows(dgvSecurityPermissions.SelectedCells(0).RowIndex).Cells("FormName").Value
                            cmd.Parameters.Add("@ControlName", SqlDbType.VarChar).Value = dgvSecurityPermissions.Rows(dgvSecurityPermissions.SelectedCells(0).RowIndex).Cells("ControlName").Value
                            cmd.Parameters.Add("@ControlProperty", SqlDbType.VarChar).Value = dgvSecurityPermissions.Rows(dgvSecurityPermissions.SelectedCells(0).RowIndex).Cells("ControlProperty").Value
                        End If
                    End If
                Case "tabDivisionPermissions"
                    ''delete for division
                    If dgvDivisionPermissions.SelectedRows.Count > 0 Then
                        cmd = New SqlCommand("DELETE DivisionSecurityPermissions WHERE ", con)
                        For i As Integer = 0 To dgvDivisionPermissions.SelectedRows.Count - 1
                            If i = 0 Then
                                cmd.CommandText += " (DivisionID = @DivisionID" + i.ToString + " AND FormName = @FormName" + i.ToString + " AND ControlName = @ControlName" + i.ToString + " AND ControlProperty = @ControlProperty" + i.ToString + ")"
                            Else
                                cmd.CommandText += " OR (DivisionID = @DivisionID" + i.ToString + " AND FormName = @FormName" + i.ToString + " AND ControlName = @ControlName" + i.ToString + " AND ControlProperty = @ControlProperty" + i.ToString + ")"
                            End If

                            cmd.Parameters.Add("@DivisionID" + i.ToString, SqlDbType.VarChar).Value = dgvDivisionPermissions.SelectedRows(i).Cells("DivisionID").Value
                            cmd.Parameters.Add("@FormName" + i.ToString, SqlDbType.VarChar).Value = dgvDivisionPermissions.SelectedRows(i).Cells("FormName").Value
                            cmd.Parameters.Add("@ControlName" + i.ToString, SqlDbType.VarChar).Value = dgvDivisionPermissions.SelectedRows(i).Cells("ControlName").Value
                            cmd.Parameters.Add("@ControlProperty" + i.ToString, SqlDbType.VarChar).Value = dgvDivisionPermissions.SelectedRows(i).Cells("ControlProperty").Value
                        Next
                    ElseIf dgvDivisionPermissions.SelectedCells.Count > 1 Then
                        cmd = New SqlCommand("DELETE DivisionSecurityPermissions WHERE ", con)
                        For i As Integer = 0 To dgvDivisionPermissions.SelectedCells.Count - 1
                            If i = 0 Then
                                cmd.CommandText += " (DivisionID = @DivisionID" + i.ToString + " AND FormName = @FormName" + i.ToString + " AND ControlName = @ControlName" + i.ToString + " AND ControlProperty = @ControlProperty" + i.ToString + ")"
                            Else
                                cmd.CommandText += " OR (DivisionID = @DivisionID" + i.ToString + " AND FormName = @FormName" + i.ToString + " AND ControlName = @ControlName" + i.ToString + " AND ControlProperty = @ControlProperty" + i.ToString + ")"
                            End If

                            cmd.Parameters.Add("@DivisionID" + i.ToString, SqlDbType.VarChar).Value = dgvDivisionPermissions.Rows(dgvDivisionPermissions.SelectedCells(i).RowIndex).Cells("DivisionID").Value
                            cmd.Parameters.Add("@FormName" + i.ToString, SqlDbType.VarChar).Value = dgvDivisionPermissions.Rows(dgvDivisionPermissions.SelectedCells(i).RowIndex).Cells("FormName").Value
                            cmd.Parameters.Add("@ControlName" + i.ToString, SqlDbType.VarChar).Value = dgvDivisionPermissions.Rows(dgvDivisionPermissions.SelectedCells(i).RowIndex).Cells("ControlName").Value
                            cmd.Parameters.Add("@ControlProperty" + i.ToString, SqlDbType.VarChar).Value = dgvDivisionPermissions.Rows(dgvDivisionPermissions.SelectedCells(i).RowIndex).Cells("ControlProperty").Value
                        Next
                    Else
                        If dgvDivisionPermissions.SelectedCells.Count = 1 Then
                            cmd = New SqlCommand("DELETE DivisionSecurityPermissions WHERE DivisionID = @DivisionID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty", con)
                            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = dgvDivisionPermissions.Rows(dgvDivisionPermissions.SelectedCells(0).RowIndex).Cells("DivisionID").Value
                            cmd.Parameters.Add("@FormName", SqlDbType.VarChar).Value = dgvDivisionPermissions.Rows(dgvDivisionPermissions.SelectedCells(0).RowIndex).Cells("FormName").Value
                            cmd.Parameters.Add("@ControlName", SqlDbType.VarChar).Value = dgvDivisionPermissions.Rows(dgvDivisionPermissions.SelectedCells(0).RowIndex).Cells("ControlName").Value
                            cmd.Parameters.Add("@ControlProperty", SqlDbType.VarChar).Value = dgvDivisionPermissions.Rows(dgvDivisionPermissions.SelectedCells(0).RowIndex).Cells("ControlProperty").Value
                        End If
                    End If
                Case "tabEmployeePermissions"
                    ''delete for employee
                    If dgvEmployeePermissions.SelectedRows.Count > 0 Then
                        cmd = New SqlCommand("DELETE SpecialSecurityPermissions WHERE ", con)
                        For i As Integer = 0 To dgvEmployeePermissions.SelectedRows.Count - 1
                            If i = 0 Then
                                cmd.CommandText += " (EmployeeID = @EmployeeID" + i.ToString + " AND FormName = @FormName" + i.ToString + " AND ControlName = @ControlName" + i.ToString + " AND ControlProperty = @ControlProperty" + i.ToString + ")"
                            Else
                                cmd.CommandText += " OR (EmployeeID = @EmployeeID" + i.ToString + " AND FormName = @FormName" + i.ToString + " AND ControlName = @ControlName" + i.ToString + " AND ControlProperty = @ControlProperty" + i.ToString + ")"
                            End If

                            cmd.Parameters.Add("@EmployeeID" + i.ToString, SqlDbType.VarChar).Value = dgvEmployeePermissions.SelectedRows(i).Cells("EmployeeID").Value
                            cmd.Parameters.Add("@FormName" + i.ToString, SqlDbType.VarChar).Value = dgvEmployeePermissions.SelectedRows(i).Cells("FormName").Value
                            cmd.Parameters.Add("@ControlName" + i.ToString, SqlDbType.VarChar).Value = dgvEmployeePermissions.SelectedRows(i).Cells("ControlName").Value
                            cmd.Parameters.Add("@ControlProperty" + i.ToString, SqlDbType.VarChar).Value = dgvEmployeePermissions.SelectedRows(i).Cells("ControlProperty").Value
                        Next
                    ElseIf dgvEmployeePermissions.SelectedCells.Count > 1 Then
                        cmd = New SqlCommand("DELETE SpecialSecurityPermissions WHERE ", con)
                        For i As Integer = 0 To dgvEmployeePermissions.SelectedCells.Count - 1
                            If i = 0 Then
                                cmd.CommandText += " (EmployeeID = @EmployeeID" + i.ToString + " AND FormName = @FormName" + i.ToString + " AND ControlName = @ControlName" + i.ToString + " AND ControlProperty = @ControlProperty" + i.ToString + ")"
                            Else
                                cmd.CommandText += " OR (EmployeeID = @EmployeeID" + i.ToString + " AND FormName = @FormName" + i.ToString + " AND ControlName = @ControlName" + i.ToString + " AND ControlProperty = @ControlProperty" + i.ToString + ")"
                            End If

                            cmd.Parameters.Add("@EmployeeID" + i.ToString, SqlDbType.VarChar).Value = dgvEmployeePermissions.Rows(dgvEmployeePermissions.SelectedCells(i).RowIndex).Cells("EmployeeID").Value
                            cmd.Parameters.Add("@FormName" + i.ToString, SqlDbType.VarChar).Value = dgvEmployeePermissions.Rows(dgvEmployeePermissions.SelectedCells(i).RowIndex).Cells("FormName").Value
                            cmd.Parameters.Add("@ControlName" + i.ToString, SqlDbType.VarChar).Value = dgvEmployeePermissions.Rows(dgvEmployeePermissions.SelectedCells(i).RowIndex).Cells("ControlName").Value
                            cmd.Parameters.Add("@ControlProperty" + i.ToString, SqlDbType.VarChar).Value = dgvEmployeePermissions.Rows(dgvEmployeePermissions.SelectedCells(i).RowIndex).Cells("ControlProperty").Value
                        Next
                    Else
                        If dgvEmployeePermissions.SelectedCells.Count = 1 Then
                            cmd = New SqlCommand("DELETE SpecialSecurityPermissions WHERE EmployeeID = @EmployeeID AND FormName = @FormName AND ControlName = @ControlName AND ControlProperty = @ControlProperty", con)
                            cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = dgvEmployeePermissions.Rows(dgvEmployeePermissions.SelectedCells(0).RowIndex).Cells("EmployeeID").Value
                            cmd.Parameters.Add("@FormName", SqlDbType.VarChar).Value = dgvEmployeePermissions.Rows(dgvEmployeePermissions.SelectedCells(0).RowIndex).Cells("FormName").Value
                            cmd.Parameters.Add("@ControlName", SqlDbType.VarChar).Value = dgvEmployeePermissions.Rows(dgvEmployeePermissions.SelectedCells(0).RowIndex).Cells("ControlName").Value
                            cmd.Parameters.Add("@ControlProperty", SqlDbType.VarChar).Value = dgvEmployeePermissions.Rows(dgvEmployeePermissions.SelectedCells(0).RowIndex).Cells("ControlProperty").Value
                        End If
                    End If
            End Select

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
        ShowData()
    End Sub

    Private Function canDeleteSecurity()
        Select Case tabCtrlPermissions.SelectedTab.Name
            Case "tabSecurityPermissions"
                If dgvSecurityPermissions.SelectedCells.Count = 0 Then
                    MessageBox.Show("There is nothing selected", "Nothing to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                If MessageBox.Show("Are you sure you wish to delete selected entries?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                    Return False
                End If
            Case "tabDivisionPermissions"
                If dgvDivisionPermissions.SelectedCells.Count = 0 Then
                    MessageBox.Show("There is nothing selected", "Nothing to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                If MessageBox.Show("Are you sure you wish to delete selected entries?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                    Return False
                End If
            Case "tabEmployeePermissions"
                If dgvEmployeePermissions.SelectedCells.Count = 0 Then
                    MessageBox.Show("There is nothing selected", "Nothing to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
                If MessageBox.Show("Are you sure you wish to delete selected entries?", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                    Return False
                End If
        End Select
        Return True
    End Function

    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click
        If canCopy() Then
            Select Case cboCopySecurityFor.Text
                Case "Security Level"
                    cmd = New SqlCommand("INSERT INTO StandardSecurityPermissions (SecurityGroupID, FormName, ControlName, ControlProperty, ControlValue, ColumnName) SELECT @NewSecurityGroupID, FormName, ControlName, ControlProperty, ControlValue, ColumnName FROM StandardSecurityPermissions t1 WHERE SecurityGroupID = @SecurityGroupID and FormName = @FormName AND Not Exists(SELECT SecurityGroupID FROM StandardSecurityPermissions t2 WHERE t2.ControlName = t1.ControlName AND t2.ControlProperty = t1.ControlProperty AND t2.SecurityGroupID = @NewSecurityGroupID)", con)
                    cmd.Parameters.Add("@SecurityGroupID", SqlDbType.VarChar).Value = cboFromSecurityID.Text
                    cmd.Parameters.Add("@NewSecurityGroupID", SqlDbType.VarChar).Value = cboToSecurityID.Text
                    cmd.Parameters.Add("@FormName", SqlDbType.VarChar).Value = cboCopyForm.Text
                Case "Employee"
                    cmd = New SqlCommand("INSERT INTO SpecialSecurityPermissions (EmployeeID, FormName, ControlName, ControlProperty, ControlValue, ColumnName) SELECT @NewEmployeeID, FormName, ControlName, ControlProperty, ControlValue, ColumnName FROM SpecialSecurityPermissions t1 WHERE EmployeeID = @EmployeeID and FormName = @FormName AND Not Exists(SELECT EmployeeID FROM SpecialSecurityPermissions t2 WHERE t2.ControlName = t1.ControlName AND t2.ControlProperty = t1.ControlProperty AND t2.EmployeeID = @NewEmployeeID)", con)
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboFromEmployeeID.Text
                    cmd.Parameters.Add("@NewEmployeeID", SqlDbType.VarChar).Value = cboToEmployeeID.Text
                    cmd.Parameters.Add("@FormName", SqlDbType.VarChar).Value = cboCopyForm.Text
                Case "Division"
                    cmd = New SqlCommand("INSERT INTO DivisionSecurityPermissions (DivisionID, FormName, ControlName, ControlProperty, ControlValue, ColumnName) SELECT @NewDivisionID, FormName, ControlName, ControlProperty, ControlValue, ColumnName FROM DivisionSecurityPermissions t1 WHERE DivisionID = @DivisionID and FormName = @FormName AND Not Exists(SELECT DivisionID FROM DivisionSecurityPermissions t2 WHERE t2.ControlName = t1.ControlName AND t2.ControlProperty = t1.ControlProperty AND t2.DivisionID = @NewDivisionID)", con)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboFromDivisionID.Text
                    cmd.Parameters.Add("@NewDivisionID", SqlDbType.VarChar).Value = cboToDivisionID.Text
                    cmd.Parameters.Add("@FormName", SqlDbType.VarChar).Value = cboCopyForm.Text
            End Select
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            ShowData()
            MessageBox.Show("Permissions have been copied.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function canCopy() As Boolean
        If String.IsNullOrEmpty(cboCopySecurityFor.Text) Then
            MessageBox.Show("You must select a Type to copy", "Select a type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCopySecurityFor.Focus()
            Return False
        End If
        If cboCopySecurityFor.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid type.", "Enter a valid type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCopySecurityFor.SelectAll()
            cboCopySecurityFor.Focus()
            Return False
        End If
        Select Case cboCopySecurityFor.Text
            Case "Security Level"
                If String.IsNullOrEmpty(cboFromSecurityID.Text) Then
                    MessageBox.Show("You must select a security ID.", "Select a security ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboFromSecurityID.Focus()
                    Return False
                End If
                If cboFromSecurityID.SelectedIndex = -1 Then
                    MessageBox.Show("You must enter a valid security ID.", "Enter a valid security ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboFromSecurityID.SelectAll()
                    cboFromSecurityID.Focus()
                    Return False
                End If
                If String.IsNullOrEmpty(cboToSecurityID.Text) Then
                    MessageBox.Show("You must select a security ID.", "Select a security ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboToSecurityID.Focus()
                    Return False
                End If
                If cboToSecurityID.SelectedIndex = -1 Then
                    MessageBox.Show("You must enter a valid security ID.", "Enter a valid security ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboToSecurityID.SelectAll()
                    cboToSecurityID.Focus()
                    Return False
                End If
            Case "Employee"
                If String.IsNullOrEmpty(cboFromEmployeeID.Text) Then
                    MessageBox.Show("You must select a Employee ID.", "Select a Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboFromEmployeeID.Focus()
                    Return False
                End If
                If cboFromEmployeeID.SelectedIndex = -1 Then
                    MessageBox.Show("You must enter a valid Employee ID.", "Enter a valid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboFromEmployeeID.SelectAll()
                    cboFromEmployeeID.Focus()
                    Return False
                End If
                If String.IsNullOrEmpty(cboToEmployeeID.Text) Then
                    MessageBox.Show("You must select a Employee ID.", "Select a Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboToEmployeeID.Focus()
                    Return False
                End If
                If cboToEmployeeID.SelectedIndex = -1 Then
                    MessageBox.Show("You must enter a valid Employee ID.", "Enter a valid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboToEmployeeID.SelectAll()
                    cboToEmployeeID.Focus()
                    Return False
                End If
            Case "Division"
                If String.IsNullOrEmpty(cboFromDivisionID.Text) Then
                    MessageBox.Show("You must select a Division ID.", "Select a Division ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboFromDivisionID.Focus()
                    Return False
                End If
                If cboFromDivisionID.SelectedIndex = -1 Then
                    MessageBox.Show("You must enter a valid Division ID.", "Enter a valid Division ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboFromDivisionID.SelectAll()
                    cboFromDivisionID.Focus()
                    Return False
                End If
                If String.IsNullOrEmpty(cboToDivisionID.Text) Then
                    MessageBox.Show("You must select a Division ID.", "Select a Division ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboToDivisionID.Focus()
                    Return False
                End If
                If cboToDivisionID.SelectedIndex = -1 Then
                    MessageBox.Show("You must enter a valid Division ID.", "Enter a valid Division ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboToDivisionID.SelectAll()
                    cboToDivisionID.Focus()
                    Return False
                End If
            Case Else
                MessageBox.Show("You must have a valid type entered", "Invalid type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
        End Select

        If String.IsNullOrEmpty(cboCopyForm.Text) Then
            MessageBox.Show("You must select a form to copy.", "Select a form to copy", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCopyForm.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdCopyClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyClear.Click
        cboCopySecurityFor.SelectedIndex = -1
        cboFromDivisionID.SelectedIndex = -1
        cboFromEmployeeID.SelectedIndex = -1
        cboFromSecurityID.SelectedIndex = -1
        cboToDivisionID.SelectedIndex = -1
        cboToEmployeeID.SelectedIndex = -1
        cboToSecurityID.SelectedIndex = -1
        cboCopyForm.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboCopyForm.Text) Then
            cboCopyForm.Text = ""
        End If
    End Sub

    Private Sub cboControls_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboControls.Leave
        If cboControls.Text.StartsWith("dgv") Then
            lblColumn.Show()
            cboColumn.Show()
            Dim frm As System.Windows.Forms.Form = GetForm()
            ''clears the columns in the combobox if there are any
            If cboColumn.Items.Count > 0 Then
                cboColumn.Items.Clear()
            End If
            ''tries to locate the datagridview control inside the form if the form exists in the case statement
            If frm IsNot Nothing Then
                Dim controlArr As Control() = frm.Controls.Find(cboControls.Text, True)
                If controlArr.Count <> 0 Then
                    Dim dgv As DataGridView = frm.Controls.Find(cboControls.Text, True)(0)
                    ''adds the columns if they exist
                    If dgv.Columns.Count > 0 Then
                        For i As Integer = 0 To dgv.Columns.Count - 1
                            cboColumn.Items.Add(dgv.Columns(i).Name)
                        Next
                    End If
                End If
            End If
        Else
            lblColumn.Hide()
            cboColumn.Text = ""
            cboColumn.Items.Clear()
            cboColumn.Hide()
        End If
    End Sub

    Private Function GetForm() As System.Windows.Forms.Form
        Select Case cboForm.Text
            Case "AllCompanyTotals"
                Return New AllCompanyTotals
            Case "AnnealingLogForm"
                Return New AnnealingLogForm
            Case "AnnealingLogSplitCoil"
                Return New AnnealingLogSplitCoil
            Case "AnnealLotTestResultsEntry"
                Return New AnnealLotTestResultsEntry
            Case "APAgedPayablesDated"
                Return New APAgedPayablesDated
            Case "APCheckNumberInput"
                Return New APCheckNumberInput
            Case "APCheckRegister"
                Return New APCheckRegister
            Case "APCheckReversal"
                Return New APCheckReversal
            Case "APcreateRecurringVouchers"
                Return New APCreateRecurringVouchers
            Case "APDesignatePayables"
                Return New APDesignatePayables
            Case "APProcessBatch"
                Return New APProcessBatch
            Case "APProcessForPayment"
                Return New APProcessForPayment
            Case "APProcessReturns"
                Return New APProcessReturns
            Case "APProcessSteelReceipts"
                Return New APProcessSteelReceipts
            Case "APProcessSteelReturns"
                Return New APProcessSteelReturns
            Case "APProcessVouchers"
                Return New APProcessVouchers
            Case "APReceiptOfInvoice"
                Return New APReceiptOfInvoice
            Case "APViewVoucherLines"
                Return New APViewVoucherLines
            Case "ARAgedReceivablesDated"
                Return New ARAgedReceivablesDated
            Case "ARCashReceipts"
                Return New ARCashReceipts
            Case "ARCustomerAccounts"
                Return New ARCustomerAccounts
            Case "AREditCustomerPayments"
                Return New AREditCustomerPayment
            Case "ARPaymentReversal"
                Return New ARPaymentReversal
            Case "ARProcessBatch"
                Return New ARProcessBatch
            Case "ARProcessPaymentBatch"
                Return New ARProcessPaymentBatch
            Case "ARRecurringPayment"
                Return New ARRecurringPayment
            Case "ARSelectDropShipForInvoicing"
                Return New ARSelectDropShipsForInvoicing
            Case "AssemblyAddAvailableSerialNumbers"
                Return New AssemblyAddAvailableSerialNumbers
            Case "AssemblyAddNewSerialNumber"
                Return New AssemblyAddNewSerialNumber
            Case "AssemblyBuildForm"
                Return New AssemblyBuildForm
            Case "AssemblyBuildSerialized"
                Return New AssemblyBuildSerialized
            Case "AssemblySerialPopup"
                Return New AssemblySerialPopup
            Case "BankingReconciliation"
                Return New BankReconciliation
            Case "BankTransactionEntry"
                Return New BankTransactionEntry
            Case "Barcode1"
                Return New Barcode1
            Case "BlueprintJournal"
                Return New BlueprintJournal
            Case "BlueprintJournalAddEntry"
                Return New BlueprintJournalAddEntry
            Case "BlueprintJournalEditEntry"
                Return New BlueprintJournalEditEntry
                'Case "BlueprintSelection"
                '    Return New BlueprintSelection
            Case "CanadianBankUpload"
                Return New CanadianBankUpload
            Case "CashSheet"
                Return New CashSheet
            Case "CertificationSpec"
                Return New CertificationSpec
            Case "CheckBackOrders"
                Return New CheckBackOrders
            Case "CheckShipmentWeight"
                Return New CheckShipmentWeight
            Case "CoilWIPInventory"
                Return New CoilWIPInventory
            Case "CommentInputBox"
                Return New CommentInputBox
            Case "ComputerUtilities"
                Return New ComputerUtilities
            Case "ConvertSOToPO"
                Return New ConvertSOToPO
            Case "CreateCurrentAnnouncements"
                Return New CreateCurrentAnnouncements
            Case "CreateSOFromPO"
                Return New CreateSOFromPO
            Case "CreateStudweldingCert"
                Return New CreateStudweldingCert
            Case "CreateVendorBOL"
                Return New CreateVendorBOL
            Case "CurrentAnnouncements"
                Return New CurrentAnnouncements
            Case "CustomerAnnouncements"
                Return New CustomerAnnouncements
            Case "CustomerData"
                Return New CustomerData
            Case "CustomerDataViewSalesTotals"
                Return New CustomerDataViewSalesTotals
            Case "CustomerFoxes"
                Return New CustomerFoxes
            Case "CustomerInfoPopup"
                Return New CustomerInfoPopup
            Case "CustomerNoteCreation"
                Return New CustomerNoteCreation
            Case "CustomerNotes"
                Return New CustomerNotes
            Case "CustomerOpenOrders"
                Return New CustomerOpenOrders
            Case "CustomerSalesHistory"
                Return New CustomerSalesHistory
            Case "CustomerSalesRanking"
                Return New CustomerSalesRanking
            Case "DailySalesForYear"
                Return New DailySalesForYear
            Case "DailyTotals"
                Return New DailyTotals
            Case "DatabaseMonitoring"
                Return New DatabaseMonitoring
            Case "DatabaseUtilities"
                Return New DatabaseUtilities
            Case "DivisionLookupForm"
                Return New DivisionLookupForm
            Case "DrawSteelForm"
                Return New DrawSteelForm
            Case "EditCompanyInfo"
                Return New EditCompanyInfo
            Case "ElectronicSchedulingBoard"
                Return New ElectronicSchedulingBoard
            Case "EmailAllInvoiceDocs"
                Return New EmailAllInvoiceDocs
            Case "EmailAllInvoiceDocsRemote"
                Return New EmailAllInvoiceDocsRemote
            Case "EmailAllShippingDocs"
                Return New EmailAllShippingDocs
            Case "EmailAllShippingDocsRemote"
                Return New EmailAllShippingDocsRemote
            Case "EmailPage"
                Return New EmailPage
            Case "EmployeeData"
                Return New EmployeeData
            Case "EquipmentProductionScheduling"
                Return New EquipmentProductionScheduling
            Case "FerruleProductionEntry"
                Return New FerruleProductionEntry
            Case "FerruleProductionScheduling"
                Return New FerruleProductionScheduling
            Case "FinalPieceInspectionSignoff"
                Return New FinalPieceInspectionSignoff
            Case "FinancialReports"
                Return New FinancialReports
            Case "FOXMenu"
                Return New FOXMenu
            Case "FOXSteelOrderForm"
                Return New FOXSteelOrderForm
            Case "GLAccountBalances"
                Return New GLAccountBalances
            Case "GLAccountsByDate"
                Return New GLAccountsByDate
            Case "GLJournalTransactions"
                Return New GLJournalTransactions
            Case "GLTransactionBalanceDetails"
                Return New GLTransactionBalanceDetails
            Case "GLTransactionEntry"
                Return New GLTransactionEntry
            Case "GLTransactionTemplate"
                Return New GLTransactionTemplate
            Case "HeaderFOXInspectionEntry"
                Return New HeaderFOXInspectionEntry
            Case "HeaderFOXInspectionEntryViewer"
                Return New HeaderFOXInspectionEntryViewer
            Case "HeaderSetupSheet"
                Return New HeaderSetupSheet
            Case "HeaderSetupSheetSelectFOX"
                Return New HeaderSetupSheetSelectFOX
            Case "HeaderSetupSheetSelectSetup"
                Return New HeaderSetupSheetSelectSetup
            Case "HeaderTimeSlipVerification"
                Return New HeaderTimeSlipVerification
            Case "HeatTreatDataForm"
                Return New HeatTreatDataForm
            Case "InputComboBox"
                Return New InputComboBox
            Case "InspectionReport"
                Return New InspectionReport
            Case "InspectionReportFirstInspectionEntry"
                Return New InspectionReportFirstInspectionEntry
            Case "IntercompanyEliminations"
                Return New IntercompanyEliminations
            Case "InventoryAdjustmentConsignment"
                Return New InventoryAdjustmentConsignment
            Case "InventoryAdjustmentForm"
                Return New InventoryAdjustmentForm
            Case "InventoryCosting"
                Return New InventoryCosting
            Case "InventoryPartialPalletRacking"
                Return New InventoryPartialPalletRacking
            Case "InventoryPriceLevels"
                Return New InventoryPriceLevels
            Case "InventoryRacking"
                Return New InventoryRacking
            Case "InventoryRackingAddLot"
                Return New InventoryRackingAddLot
            Case "InventoryRackingEmptyBins"
                Return New InventoryRackingEmptyBins
            Case "InventoryRackingWithPreferences"
                Return New InventoryRackingWithPreferences
            Case "InventorySalesHistory"
                Return New InventorySalesHistory
            Case "InventoryStatus"
                Return New InventoryStatus
            Case "InventoryTransactionMaintenance"
                Return New InventoryTransactionMaintenance
            Case "InventoryTubs"
                Return New InventoryTubs
            Case "InventoryValuation"
                Return New InventoryValuation
            Case "InvoiceBillOnly"
                Return New InvoiceBillOnly
            Case "InvoicingForm"
                Return New InvoicingForm
            Case "ItemClassMaintenance"
                Return New ItemClassMaintenance
            Case "ItemLookup"
                Return New ItemLookup
            Case "ItemMaintenance"
                Return New ItemMaintenance
            Case "ItemMaintenanceConsignment"
                Return New ItemMaintenanceConsignment
            Case "ItemMaintenanceFoxProcesses"
                Return New ItemMaintenanceFoxProcesses
            Case "ItemMaintenanceOpenOrders"
                Return New ItemMaintenanceOpenOrders
            Case "ItemMaintenancePartHistory"
                Return New ItemMaintenancePartHistory
            Case "ItemMaintenancePurchaseHistory"
                Return New ItemMaintenancePurchaseHistory
            Case "ItemMaintenanceRacking"
                Return New ItemMaintenanceRacking
            Case "ItemMinMaxMaintenance"
                Return New ItemMinMaxMaintenance
            Case "ItemPriceSheet"
                Return New ItemPriceSheet
            Case "ItemPriceSheetMaintenance"
                Return New ItemPriceSheetMaintenance
            Case "LabelCreator"
                Return New LabelCreator
            Case "LiftTruckRacking"
                Return New LiftTruckRacking
            Case "Loading"
                Return New Loading
            Case "LoadNextPieceSold"
                Return New LoadNextPieceSold
            Case "LoginPage"
                Return New LoginPage
            Case "LotNumberCreateSpecial"
                Return New LotNumberCreateSpecial
            Case "LotNumberMaintenance"
                Return New LotNumberMaintenance
            Case "LotNumberMaintenanceFOXSchedVerification"
                Return New LotNumberMaintenanceFOXSchedVerification
            Case "LotNumberPopup"
                Return New LotNumberPopup
            Case "MachinePopup"
                Return New MachinePopup
            Case "MainInterface"
                Return New MainInterface
            Case "MaintainRecurringVouchers"
                Return New MaintainRecurringVouchers
            Case "ManageShipments"
                Return New ManageShipments
            Case "ManufacturingMaintenance"
                Return New ManufacturingMaintenance
            Case "MillCertForm"
                Return New MillCertForm
            Case "MonthEndReports"
                Return New MonthEndReports
            Case "MonthSnapshot"
                Return New MonthSnapshot
            Case "NonInventoryItems"
                Return New NonInventoryItems
            Case "NotificationAlert"
                Return New NotificationAlert
            Case "NotificationCalendar"
                Return New NotificationCalendar
            Case "NotificationEdit"
                Return New NotificationEdit
            Case "NotificationsAdd"
                Return New NotificationsAdd
            Case "NotificationsShow"
                Return New NotificationsShow
            Case "OrderTracking"
                Return New OrderTracking
            Case "PasswordEntry"
                Return New PasswordEntry
            Case "PaymentTermsMaintenance"
                Return New PaymentTermsMaintenance
            Case "PickTicketDeleted"
                Return New PickTicketDeleted
            Case "POForm"
                Return New POForm
            Case "POQuantityOnHand"
                Return New POQuantityOnHand
            Case "PriceLookup"
                Return New PriceLookup
            Case "Print1096DivForm"
                Return New Print1096DivForm
            Case "Print1096Form"
                Return New Print1096Form
            Case "Print1099DIVForm"
                Return New Print1099DIVForm
            Case "Print1099Form"
                Return New Print1099Form
            Case "PrintAllInvoiceDocs"
                Return New PrintAllInvoiceDocs
            Case "PrintAllShippingDocs"
                Return New PrintAllShippingDocs
            Case "PrintAnnealingLogFiltered"
                Return New PrintAnnealingLogFiltered
            Case "PrintAPAging"
                Return New PrintAPAging
            Case "PrintAPAgingDated"
                Return New PrintAPAgingDated
            Case "PrintAPCheckLog"
                Return New PrintAPCheckLog
            Case "PrintAPCheckRemittance"
                Return New PrintAPCheckRemittance
            Case "PrintAPChecks"
                Return New PrintAPChecks
            Case "PrintAPPaymentBatch"
                Return New PrintAPPaymentBatch
            Case "PrintAPProcessBatch"
                Return New PrintAPProcessBatch
            Case "PrintAPVoucherPaidList"
                Return New PrintAPVoucherPaidList
            Case "PrintARAging"
                Return New PrintARAging
            Case "PrintARAgingDated"
                Return New PrintARAgingDated
            Case "PrintARAgingFiltered"
                Return New PrintARAgingFiltered
            Case "PrintARCashReceiptBatch"
                Return New PrintARCashReceiptBatch
            Case "PrintARCustomerHolds"
                Return New PrintARCustomerHolds
            Case "PrintARCustomerPaymentBatch"
                Return New PrintARCustomerPaymentBatch
            Case "PrintARCustomerPaymentBatchRemote"
                Return New PrintARCustomerPaymentBatchRemote
            Case "PrintARCustomerPaymentListing"
                Return New PrintARCustomerPaymentListing
            Case "PrintARCustomerStatmentSingle"
                Return New PrintARCustomerStatementSingle
            Case "PrintARCustomerStatementSingleRemote"
                Return New PrintARCustomerStatementSingleRemote
            Case "PrintARPaymentLogFiltered"
                Return New PrintARPaymentLogFiltered
            Case "PrintARPaymentReversal"
                Return New PrintARPaymentReversal
            Case "PrintARProcessPaymentAuto"
                Return New PrintARProcessPaymentAuto
            Case "PrintAssemblyBOM"
                Return New PrintAssemblyBOM
            Case "PrintAssemblyBuildBOM"
                Return New PrintAssemblyBuildBOM
            Case "PrintAssemblyBuildListingFiltered"
                Return New PrintAssemblyBuildListingFiltered
            Case "PrintAssemblyLinesFiltered"
                Return New PrintAssemblyLinesFiltered
            Case "PrintAssemblyListingFiltered"
                Return New PrintAssemblyListingFiltered
            Case "PrintAuditTrail"
                Return New PrintAuditTrail
            Case "PrintBackOrderFiltered"
                Return New PrintBackOrdersFiltered
            Case "PrintBackOrdersFilteredRemote"
                Return New PrintBackOrdersFilteredRemote
            Case "PrintBalanceSheet"
                Return New PrintBalanceSheet
            Case "PrintBankBatch"
                Return New PrintBankBatch
            Case "PrintBlankGaugeSignout"
                Return New PrintBlankGaugeSignout
            Case "PrintBOL"
                Return New PrintBOL
            Case "PrintBOLRemote"
                Return New PrintBOLRemote
            Case "PrintCanamSales"
                Return New PrintCanamSales
            Case "PrintCashReceipts"
                Return New PrintCashReceipts
            Case "PrintCertErrorLog"
                Return New PrintCertErrorLog
            Case "PrintCertificationSpecifications"
                Return New PrintCertificationSpecifications
            Case "PrintCharterSteelDispatchEntry"
                Return New PrintCharterSteelDispatchEntry
            Case "PrintCheckRegister"
                Return New PrintCheckRegister
            Case "PrintCheckRegisterFiltered"
                Return New PrintCheckRegisterFiltered
            Case "PrintCoilLabel"
                Return New PrintCoilLabel
            Case "PrintCoilListing"
                Return New PrintCoilListing
            Case "PrintCommissionReport"
                Return New PrintCommissionReport
            Case "PrintConsignmentBilling"
                Return New PrintConsignmentBilling
            Case "PrintConsignmentInventory"
                Return New PrintConsignmentInventory
            Case "PrintConsignmentReturns"
                Return New PrintConsignmentReturns
            Case "PrintConsignmentShipping"
                Return New PrintConsignmentShipping
            Case "PrintConsignmentTotals"
                Return New PrintConsignmentTotals
            Case "PrintConsignmentValuation"
                Return New PrintConsignmentValuation
            Case "PrintCorrectivePreventiceActionReport"
                Return New PrintCorrectivePreventiceActionReport
            Case "PrintCostCenterFile"
                Return New PrintCostCenterFile
            Case "PrintCustomer"
                Return New PrintCustomer
            Case "PrintCustomerAddressBook"
                Return New PrintCustomerAddressBook
            Case "PrintCustomerARAging"
                Return New PrintCustomerARAging
            Case "PrintCustomerARReport"
                Return New PrintCustomerARReport
            Case "PrintCustomerCredit"
                Return New PrintCustomerCredit
            Case "PrintCustomerListFiltered"
                Return New PrintCustomerListFiltered
            Case "PrintCustomerMTDYTDTotals"
                Return New PrintCustomerMTDYTDTotals
            Case "PrintCustomerNotes"
                Return New PrintCustomerNotes
            Case "PrintCustomerOrderHistory"
                Return New PrintCustomerOrderHistory
            Case "PrintCustomerOrdersFiltered"
                Return New PrintCustomerOrdersFiltered
            Case "PrintCustomerPaymentActivity"
                Return New PrintCustomerPaymentActivity
            Case "PrintCustomerPaymentActivitySingle"
                Return New PrintCustomerPaymentActivitySingle
            Case "PrintCustomerPaymentFiltered"
                Return New PrintCustomerPaymentFiltered
            Case "PrintCustomerPaymentRecord"
                Return New PrintCustomerPaymentRecord
            Case "PrintCustomerReturn"
                Return New PrintCustomerReturn
            Case "PrintCustomerReturnAuthorization"
                Return New PrintCustomerReturnAuthorization
            Case "PrintCustomerReturnRemote"
                Return New PrintCustomerReturnRemote
            Case "PrintCustomerReturnLinesFiltered"
                Return New PrintCustomerReturnLinesFiltered
            Case "PrintCustomerSalesFiltered"
                Return New PrintCustomerSalesFiltered
            Case "PrintCustomerSalesList"
                Return New PrintCustomerSalesList
            Case "PrintCustomerSalesRanking"
                Return New PrintCustomerSalesRanking
            Case "PrintCustomerSalesReport"
                Return New PrintCustomerSalesReport
            Case "PrintCustomerSalesReportCAN"
                Return New PrintCustomerSalesReportCAN
            Case "PrintCustomerStatement"
                Return New PrintCustomerStatement
            Case "PrintCustomerStatementDated"
                Return New PrintCustomerStatementDated
            Case "PrintCustomerStatementDatedRemote"
                Return New PrintCustomerStatementDatedRemote
            Case "PrintCustomerSummaryReport"
                Return New PrintCustomerSummaryReport
            Case "PrintDailyRegister"
                Return New PrintDailyRegister
            Case "PrintDailyShipmentLog"
                Return New PrintDailyShipmentLog
            Case "PrintDropShipListing"
                Return New PrintDropShipListing
            Case "PrintDropShipPackList"
                Return New PrintDropShipPackList
            Case "PrintDropShipPackListRemote"
                Return New PrintDropShipPackListRemote
            Case "PrintDropShipPOs"
                Return New PrintDropShipPOs
            Case "PrintDropShipSalesbyState"
                Return New PrintDropShipSalesbyState
            Case "PrintDropShipSO"
                Return New PrintDropShipSO
            Case "PrintElectronicSchedulingBoard"
                Return New PrintElectronicSchedulingBoard
            Case "PrintEmailList"
                Return New PrintEmailList
            Case "PrintEquipmentProduction"
                Return New PrintEquipmentProduction
            Case "PrintFabSouthSales"
                Return New PrintFabSouthSales
            Case "PrintFerruleProductionScheduling"
                Return New PrintFerruleProductionScheduling
            Case "PrintFirstPieceInspection"
                Return New PrintFirstPieceInspection
            Case "PrintFirstPieceInspectionListing"
                Return New PrintFirstPieceInspectionListing
            Case "PrintFOX"
                Return New PrintFOX
            Case "PrintFOXByDate"
                Return New PrintFOXByDate
            Case "PrintFOXListingFiltered"
                Return New PrintFOXListingFiltered
            Case "PrintFOXPostingReport"
                Return New PrintFOXPostingReport
            Case "PrintFOXReleaseListing"
                Return New PrintFOXReleaseListing
            Case "PrintFOXReleaseSchedule"
                Return New PrintFOXReleaseSchedule
                'Case "PrintFOXReleaseScheduleCompressed"
                '    Return New PrintFOXReleaseScheduleCompressed
            Case "PrintGLChartOfAccounts"
                Return New PrintGLChartOfAccounts
            Case "PrintGLInvoiceLinesFiltered"
                Return New PrintGLInvoiceLinesFiltered
            Case "PrintGLJournal"
                Return New PrintGLJournal
            Case "PrintGLJournalAuto"
                Return New PrintGLJournalAuto
            Case "PrintGLJournalFiltered"
                Return New PrintGLJournalFiltered
            Case "PrintGLReceivingLinesFiltered"
                Return New PrintGLReceivingLinesFiltered
            Case "PrintGLShippingLinesFiltered"
                Return New PrintGLShippingLinesFiltered
            Case "PrintGLTemplate"
                Return New PrintGLTemplate
            Case "PrintGLTransactionByAccount"
                Return New PrintGLTransactionByAccount
            Case "PrintGLTransactionDetail"
                Return New PrintGLTransactionDetail
            Case "PrintGLTransactions"
                Return New PrintGLTransactions
            Case "PrintGLTransactionsFiltered"
                Return New PrintGLTransactionsFiltered
            Case "PrintGLWCProductionLines"
                Return New PrintGLWCProductionLines
            Case "PrintGLWTB"
                Return New PrintGLWTB
            Case "PrintHeaderFOXReportFiltered"
                Return New PrintHeaderFOXReportFiltered
            Case "PrintHeaderSetupSheet"
                Return New PrintHeaderSetupSheet
            Case "PrintHeatFileRecord"
                Return New PrintHeatFileRecord
            Case "PrintHeatNumbersFiltered"
                Return New PrintHeatNumbersFiltered
            Case "PrintHeatTreatCert"
                Return New PrintHeatTreatCert
            Case "PrintIncomeStatement"
                Return New PrintIncomeStatement
            Case "PrintIncomeStatment2Year"
                Return New PrintIncomeStatement2Year
            Case "PrintInventoryActivity"
                Return New PrintInventoryActivity
            Case "PrintInventoryAdjustmentBatch"
                Return New PrintInventoryAdjustmentBatch
            Case "PrintInventoryAdjustmentsFiltered"
                Return New PrintInventoryAdjustmentsFiltered
            Case "PrintInventoryCostingFiltered"
                Return New PrintInventoryCostingFiltered
            Case "PrintInvnetoryCountSheet"
                Return New PrintInventoryCountSheet
            Case "PrintInventoryDiscrepancyReport"
                Return New PrintInventoryDiscrepancyReport
            Case "PrintInventoryDiscrepancyReportSLC"
                Return New PrintInventoryDiscrepancyReportSLC
            Case "PrintInventoryFIFOFiltered"
                Return New PrintInventoryFIFOFiltered
            Case "PrintInventoryFIFOValue"
                Return New PrintInventoryFIFOValue
            Case "PrintInventoryPurchaseCost"
                Return New PrintInventoryPurchaseCost
            Case "PrintInventorySales5Year"
                Return New PrintInventorySales5Year
            Case "PrintInventorySteelValue"
                Return New PrintInventorySteelValue
            Case "PrintInventoryStockShippingTotals"
                Return New PrintInventoryStockShippingTotals
            Case "PrintInventoryTransactionsFiltered"
                Return New PrintInventoryTransactionsFiltered
            Case "PrintInventoryTubList"
                Return New PrintInventoryTubList
            Case "PrintInventoryTubTag"
                Return New PrintInventoryTubTag
            Case "PrintInventoryTubWIPReport"
                Return New PrintInventoryTubWIPReport
            Case "PrintInventoryUsageByMonth"
                Return New PrintInventoryUsageByMonth
            Case "PrintInventoryValuationByDate"
                Return New PrintInventoryValuationByDate
            Case "PrintInventoryValuationByGL"
                Return New PrintInventoryValuationByGL
            Case "PrintInventoryValueByFilter"
                Return New PrintInventoryValueByFilter
            Case "PrintInventoryValueByItemClass"
                Return New PrintInventoryValueByItemClass
            Case "PrintInvoiceBatch"
                Return New PrintInvoiceBatch
            Case "PrintInvoiceBatchRemote"
                Return New PrintInvoiceBatchRemote
            Case "PrintInvoiceBillOnly"
                Return New PrintInvoiceBillOnly
            Case "PrintInvoiceBillOnlyRemote"
                Return New PrintInvoiceBillOnlyRemote
            Case "PrintInvoiceCerts"
                Return New PrintInvoiceCerts
            Case "PrintInvoiceCosting"
                Return New PrintInvoiceCosting
            Case "PrintInvoiceDailyTotals"
                Return New PrintInvoiceDailyTotals
            Case "PrintInvoiceDiscrepancyReport"
                Return New PrintInvoiceDiscrepancyReport
            Case "PrintInvoiceGLAccountDetail"
                Return New PrintInvoiceGLAccountDetail
            Case "PrintInvoiceGLPostings"
                Return New PrintInvoiceGLPostings
            Case "PrintInvoiceLinesBySortFiltered"
                Return New PrintInvoiceLinesBySortFiltered
            Case "PrintInvoiceLinesFiltered"
                Return New PrintInvoiceLinesFiltered
            Case "PrintInvoiceListDatagrid"
                Return New PrintInvoiceListDatagrid
            Case "PrintInvoiceRegister"
                Return New PrintInvoiceRegister
            Case "PrintInvoiceSingle"
                Return New PrintInvoiceSingle
            Case "PrintInvoiceSingleRemote"
                Return New PrintInvoiceSingleRemote
            Case "PrintInvoiceSO"
                Return New PrintInvoiceSO
            Case "PrintInvoiceSORemote"
                Return New PrintInvoiceSORemote
            Case "PrintInvoiceTotalNoFerrules"
                Return New PrintInvoiceTotalNoFerrules
            Case "PrintItemListFiltered"
                Return New PrintItemListFiltered
            Case "PrintItemMinMax"
                Return New PrintItemMinMax
            Case "PrintItemPriceSheet"
                Return New PrintItemPriceSheet
            Case "PrintItemPriceSheetFiltered"
                Return New PrintItemPriceSheetFiltered
            Case "PrintItemSoldToCustomerCanadian"
                Return New PrintItemSoldToCustomerCanadian
            Case "PrintItemsPurchasedFromVendor"
                Return New PrintItemsPurchasedFromVendor
            Case "PrintItemsSoldFiltered"
                Return New PrintItemsSoldFiltered
            Case "PrintItemSoldToCustomer"
                Return New PrintItemsSoldToCustomer
            Case "PrintItemStandardCostPriceFiltered"
                Return New PrintItemStandardCostPriceFiltered
            Case "PrintLeadTimesFiltered"
                Return New PrintLeadTimesFiltered
            Case "PrintLetterHead"
                Return New PrintLetterHead
            Case "PrintLotNumberListFiltered"
                Return New PrintLotNumberListFiltered
            Case "PrintMachineCostCenterReport"
                Return New PrintMachineCostCenterReport
            Case "PrintMachineList"
                Return New PrintMachineList
            Case "PrintMonthSnapshot"
                Return New PrintMonthSnapshot
            Case "PrintNafta"
                Return New PrintNafta
            Case "PrintNegativeInventory"
                Return New PrintNegativeInventory
            Case "PrintNonInventoryItems"
                Return New PrintNonInventoryItems
            Case "PrintOkToProcess"
                Return New PrintOkToProcess
            Case "PrintOkToShip"
                Return New PrintOkToShip
            Case "PrintOpenDropShips"
                Return New PrintOpenDropShips
            Case "PrintOpenOrderReport"
                Return New PrintOpenOrderReport
            Case "PrintOpenPayables"
                Return New PrintOpenPayables
            Case "PrintOpenPOReport"
                Return New PrintOpenPOReport
            Case "PrintOpenSalesOrderLineReport"
                Return New PrintOpenSalesOrderLineReport
            Case "PrintOpenSteelPOList"
                Return New PrintOpenSteelPOList
            Case "PrintPackingList"
                Return New PrintPackingList
            Case "PrintPackingListRemote"
                Return New PrintPackingListRemote
            Case "PrintPackListSO"
                Return New PrintPackListSO
            Case "PrintPackListSORemote"
                Return New PrintPackListSORemote
            Case "PrintPartSalesData"
                Return New PrintPartSalesData
            Case "PrintPaymentTerms"
                Return New PrintPaymentTerms
            Case "PrintPendingShipmentsFiltered"
                Return New PrintPendingShipmentsFiltered
            Case "PrintPhoneList"
                Return New PrintPhoneList
            Case "PrintPickListHeaders"
                Return New PrintPickListHeaders
            Case "PrintPickListPulledItems"
                Return New PrintPickListPulledItems
            Case "PrintPickQOHFiltered"
                Return New PrintPickQOHFiltered
            Case "PrintPickTicket"
                Return New PrintPickTicket
            Case "PrintPickTicketBatch"
                Return New PrintPickTicketBatch
            Case "PrintPickTicketBatchRemote"
                Return New PrintPickTicketBatchRemote
            Case "PrintPickTicketRemote"
                Return New PrintPickTicketRemote
            Case "PrintPickTicketsAuto"
                Return New PrintPickTicketsAuto
            Case "PrintPickTicketsSO"
                Return New PrintPickTicketsSO
            Case "PrintPickTicketsSORemote"
                Return New PrintPickTicketsSORemote
            Case "PrintPOHeadersFiltered"
                Return New PrintPOHeadersFiltered
            Case "PrintPOShipper"
                Return New PrintPOShipper
            Case "PrintPriceSheetIncrease"
                Return New PrintPriceSheetIncrease
            Case "PrintPriceSheetIncreaseTWE"
                Return New PrintPriceSheetIncreaseTWE
            Case "PrintProductionOrderNew"
                Return New PrintProductionOrderNew
            Case "PrintProductionSchedulingList2"
                Return New PrintProductionSchedulingList2
            Case "PrintPTCheckAmerican"
                Return New PrintPTCheckAmerican
            Case "PrintPTCheckCanadian"
                Return New PrintPTCheckCanadian
            Case "PrintPullTest"
                Return New PrintPullTest
            Case "PrintPullTestListing"
                Return New PrintPullTestListing
            Case "PrintPullTestLog"
                Return New PrintPullTestLog
            Case "PrintPurchaseClearingReport2"
                Return New PrintPurchaseClearingReport2
            Case "PrintPurchaseLinesFiltered"
                Return New PrintPurchaseLinesFiltered
            Case "PrintPurchaseOrder"
                Return New PrintPurchaseOrder
            Case "PrintPurchaseOrderBarcode"
                Return New PrintPurchaseOrderBarcode
            Case "PrintPurchaseOrderListing"
                Return New PrintPurchaseOrderListing
            Case "PrintPurchaseOrderRemote"
                Return New PrintPurchaseOrderRemote
            Case "PrintQCFinalPieceSignOffs"
                Return New PrintQCFinalPieceSignOffs
            Case "PrintQCHoldListing"
                Return New PrintQCHoldListing
            Case "PrintQCInspectionReport"
                Return New PrintQCInspectionReport
            Case "PrintQCNonconReport"
                Return New PrintQCNonconReport
            Case "PrintQCRackLocations"
                Return New PrintQCRackLocations
            Case "PrintQCShipmentAudit"
                Return New PrintQCShipmentAudit
            Case "PrintQuote"
                Return New PrintQuote
            Case "PrintQuoteHeadersFiltered"
                Return New PrintQuoteHeadersFiltered
            Case "PrintQuoteRemote"
                Return New PrintQuoteRemote
            Case "PrintRackContents"
                Return New PrintRackContents
            Case "PrintRackingActivityLog"
                Return New PrintRackingActivityLog
            Case "PrintRackingByFilter"
                Return New PrintRackingByFilter
            Case "PrintRackingFromPopup"
                Return New PrintRackingFromPopup
            Case "PrintRawMaterialListFiltered"
                Return New PrintRawMaterialListFiltered
            Case "PrintReceiver"
                Return New PrintReceiver
            Case "PrintReceiverLinesFiltered"
                Return New PrintReceiverLinesFiltered
            Case "PrintReceiverPO"
                Return New PrintReceiverPO
            Case "PrintReceivingHeaders"
                Return New PrintReceivingHeaders
            Case "PrintReceivingHeadersFiltered"
                Return New PrintReceivingHeadersFiltered
            Case "PrintRecurringPayment"
                Return New PrintRecurringPayment
            Case "PrintRecurringVoucher"
                Return New PrintRecurringVoucher
            Case "PrintRemiitanceReport"
                Return New PrintRemiitanceReport
            Case "PrintReorderWorksheet"
                Return New PrintReorderWorksheet
            Case "PrintRequisition"
                Return New PrintRequisition
            Case "PrintRMAGrid"
                Return New PrintRMAGrid
            Case "PrintRMAReport"
                Return New PrintRMAReport
            Case "PrintSalesByCategory"
                Return New PrintSalesByCategory
            Case "PrintSalesByDayOfWeek"
                Return New PrintSalesByDayOfWeek
            Case "PrintSalesByItemClass"
                Return New PrintSalesByItemClass
            Case "PrintSalesbyMonth"
                Return New PrintSalesbyMonth
            Case "PrintSalesByState"
                Return New PrintSalesByState
            Case "PrintSalesConfirmation"
                Return New PrintSalesConfirmation
            Case "PrintSalesConfirmationRemote"
                Return New PrintSalesConfirmationRemote
            Case "PrintSalesLinesFiltered"
                Return New PrintSalesLinesFiltered
            Case "PrintSalesOrder"
                Return New PrintSalesOrder
            Case "PrintSalesOrderListing"
                Return New PrintSalesOrderListing
            Case "PrintSalesOrderListingBySalesman"
                Return New PrintSalesOrderListingBySalesman
            Case "PrintSalesOrderRemote"
                Return New PrintSalesOrderRemote
            Case "PrintSalesTaxReport"
                Return New PrintSalesTaxReport
            Case "PrintSalesTaxReportTFF"
                Return New PrintSalesTaxReportTFF
            Case "PrintSerialLog"
                Return New PrintSerialLog
            Case "PrintShipment"
                Return New PrintShipment
            Case "PrintShipmentBarCodes"
                Return New PrintShipmentBarCodes
            Case "PrintShipmentConfirmation"
                Return New PrintShipmentConfirmation
            Case "PrintShipmentConfirmationRemote"
                Return New PrintShipmentConfirmationRemote
            Case "PrintShipmentFreightDetails"
                Return New PrintShipmentFreightDetails
            Case "PrintShipmentLinesFiltered"
                Return New PrintShipmentLinesFiltered
            Case "PrintShipmentLogReportFiltered"
                Return New PrintShipmentLogReportFiltered
            Case "PrintShipmentLotNumbersFiltered"
                Return New PrintShipmentLotNumbersFiltered
            Case "PrintShipmentMargin"
                Return New PrintShipmentMargin
            Case "PrintShipmentsForInvoicing"
                Return New PrintShipmentsForInvoicing
            Case "PrintShipmentStatusFiltered"
                Return New PrintShipmentStatusFiltered
            Case "PrintShipmentStatusFilteredRemote"
                Return New PrintShipmentStatusFilteredRemote
            Case "PrintShippers"
                Return New PrintShippers
            Case "PrintShippingAddresses"
                Return New PrintShippingAddresses
            Case "PrintShippingBOLMultiple"
                Return New PrintShippingBOLMultiple
            Case "PrintShotScreening"
                Return New PrintShotScreening
            Case "PrintSingleAPCheck"
                Return New PrintSingleAPCheck
            Case "PrintSOWorkOrder"
                Return New PrintSOWorkOrder
            Case "PrintSteelAdjustment"
                Return New PrintSteelAdjustment
            Case "PrintSteelBalanceDiscreptancyReport"
                Return New PrintSteelBalanceDiscreptancyReport
            Case "PrintSteelBalances"
                Return New PrintSteelBalances
            Case "PrintSteelCoilTotals"
                Return New PrintSteelCoilTotals
            Case "PrintSteelCoilTransfer"
                Return New PrintSteelCoilTransfer
            Case "PrintSteelConsumption"
                Return New PrintSteelConsumption
            Case "PrintSteelCurrentCosting"
                Return New PrintSteelCurrentCosting
            Case "PrintSteelInventoryValue"
                Return New PrintSteelInventoryValue
            Case "PrintSteelList"
                Return New PrintSteelList
            Case "PrintSteelMonthConsumption"
                Return New PrintSteelMonthConsumption
            Case "PrintSteelPurchaseLines"
                Return New PrintSteelPurchaseLines
            Case "PrintSteelPurchaseOrder"
                Return New PrintSteelPurchaseOrder
            Case "PrintSteelReceiptOfGoods"
                Return New PrintSteelReceiptOfGoods
            Case "PrintSteelReceivingCoilLines"
                Return New PrintSteelReceivingCoilLines
            Case "PrintSteelReceivingLines"
                Return New PrintSteelReceivingLines
            Case "PrintSteelReceivingSummary"
                Return New PrintSteelReceivingSummary
            Case "PrintSteelReport"
                Return New PrintSteelReport
            Case "PrintSteelRequirements"
                Return New PrintSteelRequirements
            Case "PrintSteelSpecialOrders"
                Return New PrintSteelSpecialOrders
            Case "PrintSteelTransactions"
                Return New PrintSteelTransactions
            Case "PrintSteelUsage"
                Return New PrintSteelUsage
            Case "PrintSteelUsageLines"
                Return New PrintSteelUsageLines
            Case "PrintSteelVendorReturn"
                Return New PrintSteelVendorReturn
            Case "PrintSteelVendorReturnLines"
                Return New PrintSteelVendorReturnLines
            Case "PrintSteelWIPReportNew"
                Return New PrintSteelWIPReportNew
            Case "PrintSteelYardEntryFiltered"
                Return New PrintSteelYardEntryFiltered
            Case "PrintStockStatus"
                Return New PrintStockStatus
            Case "PrintStockStatusValuation"
                Return New PrintStockStatusValuation
            Case "PrintStudweldingCerticate"
                Return New PrintStudweldingCerticate
            Case "PrintStudweldingCerticateRemote"
                Return New PrintStudweldingCerticateRemote
            Case "PrintTFAcknowledgement"
                Return New PrintTFAcknowledgement
            Case "PrintTFPDiscrepancyReport"
                Return New PrintTFPDiscrepancyReport
            Case "PrintTFPInventory"
                Return New PrintTFPInventory
            Case "PrintTFPQuoteList"
                Return New PrintTFPQuoteList
            Case "PrintTFQuote"
                Return New PrintTFQuote
            Case "PrintTFQuoteRegister"
                Return New PrintTFQuoteRegister
            Case "PrintTimeSlipPostings"
                Return New PrintTimeSlipPostings
            Case "PrintToolRoomInventory"
                Return New PrintToolRoomInventory
            Case "PrintTrufitCert"
                Return New PrintTrufitCert
            Case "PrintTrufitCertificationMechanicalTest"
                Return New PrintTrufitCertificationMechanicalTest
            Case "PrintTrufitCertificationTorqueTest"
                Return New PrintTrufitCertificationTorqueTest
            Case "PrintTWCert"
                Return New PrintTWCert
            Case "PrintTWCert01"
                Return New PrintTWCert01
            Case "PrintTWCert01Remote"
                Return New PrintTWCert01Remote
            Case "PrintTWCertSingle"
                Return New PrintTWCertSingle
            Case "PrintTWCertSingleRemote"
                Return New PrintTWCertSingleRemote
            Case "PrintTWDStockStatus"
                Return New PrintTWDStockStatus
            Case "PrintTWDStockStatusRemote"
                Return New PrintTWDStockStatusRemote
            Case "PrintTWInventoryValuation"
                Return New PrintTWInventoryValuation
            Case "PrintTWQuoteRegister"
                Return New PrintTWQuoteRegister
            Case "PrintTWSalesByTerritory"
                Return New PrintTWSalesByTerritory
            Case "PrintUnpostedInvoices"
                Return New PrintUnpostedInvoices
            Case "PrintVendorBOL"
                Return New PrintVendorBOL
            Case "PrintVendorList"
                Return New PrintVendorList
            Case "PrintVendorOnTimeReport"
                Return New PrintVendorOnTimeReport
            Case "PrintVendorPaymentHistory"
                Return New PrintVendorPaymentHistory
            Case "PrintVendorPurchaseHistory"
                Return New PrintVendorPurchaseHistory
            Case "PrintVendorPurchaseHistoryFiltered"
                Return New PrintVendorPurchaseHistoryFiltered
            Case "PrintVendorPurchases"
                Return New PrintVendorPurchases
            Case "PrintVendorPurchaseSummaryFiltered"
                Return New PrintVendorPurchaseSummaryFiltered
            Case "PrintVendorReturn"
                Return New PrintVendorReturn
            Case "PrintVendorReturnDate"
                Return New PrintVendorReturnDate
            Case "PrintVendorReturnLines"
                Return New PrintVendorReturnLines
            Case "PrintVendorReturnListing"
                Return New PrintVendorReturnListing
            Case "PrintVendorReturnListingFiltered"
                Return New PrintVendorReturnListingFiltered
            Case "PrintVoucher"
                Return New PrintVoucher
            Case "PrintVoucherLinesFiltered"
                Return New PrintVoucherLinesFiltered
            Case "PrintVoucherListing"
                Return New PrintVoucherListing
            Case "PrintVoucherListingPD"
                Return New PrintVoucherListingPD
            Case "PrintVoucherPostDate"
                Return New PrintVoucherPostDate
            Case "PrintVoucherPostingFiltered"
                Return New PrintVoucherPostingFiltered
            Case "PrintWCProduction"
                Return New PrintWCProduction
            Case "PrintWCProductionFiltered"
                Return New PrintWCProductionFiltered
            Case "PrintWIP"
                Return New PrintWIP
            Case "PrintWIPTotals"
                Return New PrintWIPTotals
            Case "PrintWIPValue"
                Return New PrintWIPValue
            Case "ProductionGraphing"
                Return New ProductionGraphing
            Case "ProductionScheduling"
                Return New ProductionScheduling
            Case "ProductionTotals"
                Return New ProductionTotals
            Case "PullTestData"
                Return New PullTestData
            Case "QCNonConformance"
                Return New QCNonConformance
            Case "QCNonConformanceAddLot"
                Return New QCNonConformanceAddLot
            Case "QCNonConformanceRacking"
                Return New QCNonConformanceRacking
            Case "QCNonConformanceRackingAddToRacking"
                Return New QCNonConformanceRackingAddToRacking
            Case "QCShipmentDockChecks"
                Return New QCShipmentDockChecks
            Case "QCShipmentSignOff"
                Return New QCShipmentSignOff
            Case "QCTools"
                Return New QCTools
            Case "QuoteForm"
                Return New QuoteForm
            Case "RackingPopup"
                Return New RackingPopup
            Case "RackingUtility"
                Return New RackingUtility
            Case "RawMaterialMaintenanceForm"
                Return New RawMaterialMaintenanceForm
            Case "RawMaterialsFOXSteelPopup"
                Return New RawMaterialsFOXSteelPopup
            Case "ReceiverEditMode"
                Return New ReceiverEditMode
            Case "Receiving"
                Return New Receiving
            Case "ReprintCert"
                Return New ReprintCert
            Case "ReprintCertRemote"
                Return New ReprintCertRemote
            Case "ReprintInvoiceBatch"
                Return New ReprintInvoiceBatch
            Case "ReprintInvoiceBatchRemote"
                Return New ReprintInvoiceBatchRemote
            Case "ReprintPickList"
                Return New ReprintPickList
            Case "ReprintPickListRemote"
                Return New ReprintPickListRemote
            Case "ReprintTrufitCert"
                Return New ReprintTrufitCert
            Case "RequisitionForm"
                Return New RequisitionForm
            Case "ReturnProductForm"
                Return New ReturnProductForm
            Case "SaltSprayLogForm"
                Return New SaltSprayLogForm
            Case "SecurityManagement"
                Return New SecurityManagement
            Case "SelectCoilsForReceiving"
                Return New SelectCoilsForReceiving
            Case "SelectCustomerReturnForCredit"
                Return New SelectCustomerReturnsForCredit
            Case "SelectDropShipLines"
                Return New SelectDropShipLines
            Case "SelectFile"
                Return New SelectFile
            Case "SelectFOXFromBlueprint"
                Return New SelectFOXFromBlueprint
            Case "SelectGLTemplateForm"
                Return New SelectGLTemplateForm
            Case "SelectInvoicesForPayment"
                Return New SelectInvoicesForPayment
            Case "SelectItemsForCustomerReturn"
                Return New SelectItemsForCustomerReturn
            Case "SelectMultiplePO"
                Return New SelectMultiplePO
            Case "SelectOpenPayables"
                Return New SelectOpenPayables
            Case "SelectPOLines"
                Return New SelectPOLines
            Case "SelectReceiverLines"
                Return New SelectReceiverLines
            Case "SelectReceiverLinesForReturn"
                Return New SelectReceiverLinesForReturn
            Case "SelectRecurringVoucher"
                Return New SelectRecurringVoucher
            Case "SelectShipmentsForInvoicing"
                Return New SelectShipmentsForInvoicing
            Case "SelectShipmentsForNafta"
                Return New SelectShipmentsForNafta
            Case "SelectSNForShipment"
                Return New SelectSNForShipment
            Case "SelectSteelCoilsForReceiving"
                Return New SelectSteelCoilsForReceiving
            Case "SelectSteelCoilsForReturn"
                Return New SelectSteelCoilsForReturn
            Case "SelectSteelLinesForReceiving"
                Return New SelectSteelLinesForReceiving
            Case "SelectSteelPOLines"
                Return New SelectSteelPOLines
            Case "SelectSteelVendorReturnLines"
                Return New SelectSteelVendorReturnLines
            Case "selectTrufitCertFile"
                Return New selectTrufitCertFile
            Case "SelectVendorReturnLines"
                Return New SelectVendorReturnLines
            Case "SerialNumberInventory"
                Return New SerialNumberInventory
            Case "ShipmentBOLForm"
                Return New ShipmentBOLForm
            Case "ShipmentCheckFreight"
                Return New ShipmentCheckFreight
            Case "ShipmentCompletion"
                Return New ShipmentCompletion
            Case "ShipmentInvoiceDateReset"
                Return New ShipmentInvoiceDateReset
            Case "ShipmentLabelNumber"
                Return New ShipmentLabelNumber
            Case "ShipmentLineComments"
                Return New ShipmentLineComments
            Case "ShipmentNaftaForm"
                Return New ShipmentNaftaForm
            Case "ShipmentTaskCreation"
                Return New ShipmentTaskCreation
            Case "ShipperInfo"
                Return New ShipperInfo
            Case "ShippingUpdater"
                Return New ShippingUpdater
            Case "ShippingUpdaterRacking"
                Return New ShippingUpdaterRacking
            Case "SOAccessoriesForm"
                Return New SOAccessoriesForm
            Case "SOBrokenBoxForm"
                Return New SOBrokenBoxForm
            Case "SOForm"
                Return New SOForm
            Case "SOFormPopup"
                Return New SOFormPopup
            Case "SOManufacturedCostPopup"
                Return New SOManufacturedCostPopup
            Case "SOPriceBracket"
                Return New SOPriceBracket
            Case "SOPurchaseCostPopup"
                Return New SOPurchaseCostPopup
            Case "SOSalesPricePopup"
                Return New SOSalesPricePopup
            Case "SplitCoilForm"
                Return New SplitCoilForm
            Case "SteelAddNewCoilForm"
                Return New SteelAddNewCoilForm
            Case "SteelAdjustmentForm"
                Return New SteelAdjustmentForm
            Case "SteelBalanceDiscreptancyReport"
                Return New SteelBalanceDiscreptancyReport
            Case "SteelBalances"
                Return New SteelBalances
            Case "SteelChangeCoilAndRMIDAdjustment"
                Return New SteelChangeCoilAndRMIDAdjustment
            Case "SteelCoilPopup"
                Return New SteelCoilPopup
            Case "SteelCosting"
                Return New SteelCosting
            Case "SteelPurchaseOrder"
                Return New SteelPurchaseOrder
            Case "SteelReceivingAdditionDataRequired"
                Return New SteelReceivingAdditionalDataRequired
            Case "SteelReceivingByCoil"
                Return New SteelReceivingByCoil
            Case "SteelReceivingCoilsPopup"
                Return New SteelReceivingCoilsPopup
            Case "SteelReceivingForm"
                Return New SteelReceivingForm
            Case "SteelTolerances"
                Return New SteelTolerances
            Case "SteelTransactionEntry"
                Return New SteelTransactionEntry
            Case "SteelVendorReturnForm"
                Return New SteelVendorReturnForm
            Case "SteelVendorReturnSelectReceiverLines"
                Return New SteelVendorReturnSelectReceiverLines
            Case "SteelWireYardEntry"
                Return New SteelWireYardEntry
            Case "SteelWireYardRemoval"
                Return New SteelWireYardRemoval
            Case "StringNumberInputBox"
                Return New StringNumberInputBox
            Case "TFPQuotationMachineCosting"
                Return New TFPQuotationMachineCosting
            Case "TFPQuoteForm"
                Return New TFPQuoteForm
            Case "TFPQuoteSelectNextForm"
                Return New TFPQuoteSelectNextForm
            Case "TimeSlipForm"
                Return New TimeSlipForm
            Case "TimeSlipPosting"
                Return New TimeSlipPosting
            Case "TimeSlipRoster"
                Return New TimeSlipRoster
            Case "TimeSlipSelectFOXStep"
                Return New TimeSlipSelectFOXStep
            Case "ToolRoomInventory"
                Return New ToolRoomInventory
            Case "TrufitCertificationMechanicalTest"
                Return New TrufitCertificationMechanicalTest
            Case "TrufitCertificationTorqueTest"
                Return New TrufitCertificationTorqueTest
            Case "TrufitMaterialCompliance"
                Return New TrufitMaterialCompliance
            Case "UploadMillCertPopup"
                Return New UploadMillCertPopup
            Case "UploadSDS"
                Return New UploadSDS
            Case "VendorClassMaintenance"
                Return New VendorClassMaintenance
            Case "VendorInfoPopup"
                Return New VendorInfoPopup
            Case "VendorInformation"
                Return New VendorInformation
            Case "VendorPurchasePopup"
                Return New VendorPurchasePopup
            Case "VendorReturnForm"
                Return New VendorReturnForm
            Case "ViewActivityLog"
                Return New ViewActivityLog
            Case "ViewAllRMA"
                Return New ViewAllRMA
            Case "ViewAnnealingLog"
                Return New ViewAnnealingLog
            Case "ViewAPAging"
                Return New ViewAPAging
            Case "ViewAPCheckLog"
                Return New ViewAPCheckLog
            Case "ViewAPVoucherPostings"
                Return New ViewAPVoucherPostings
            Case "ViewAPVouchersPaid"
                Return New ViewAPVouchersPaid
            Case "ViewARAging"
                Return New ViewARAging
            Case "ViewARRecurringPayment"
                Return New ViewARRecurringPayment
            Case "ViewAssemblyBuildLines"
                Return New ViewAssemblyBuildLines
            Case "ViewAssemblyBuildListing"
                Return New ViewAssemblyBuildListing
            Case "ViewAssemblyComponents"
                Return New ViewAssemblyComponents
            Case "ViewAssemblyLines"
                Return New ViewAssemblyLines
            Case "ViewAssemblyListing"
                Return New ViewAssemblyListing
            Case "ViewAssemblySerialLog"
                Return New ViewAssemblySerialLog
            Case "ViewAuditTrail"
                Return New ViewAuditTrail
            Case "ViewBackOrders"
                Return New ViewBackOrders
            Case "ViewBinPreferences"
                Return New ViewBinPreferences
            Case "ViewBlueprintJournalActivity"
                Return New ViewBlueprintJournalActivity
            Case "ViewBlueprintPopup"
                Return New ViewBlueprintPopup
            Case "ViewBlueprintSelectToolingPrint"
                Return New ViewBlueprintSelectToolingPrint
            Case "ViewBlueprintsLogin"
                Return New ViewBlueprintsLogin
            Case "ViewCashReceipts"
                Return New ViewCashReceipts
            Case "ViewCertErrorLog"
                Return New ViewCertErrorLog
            Case "ViewCharterSteelCoils"
                Return New ViewCharterSteelCoils
            Case "ViewConsignmentAdjustments"
                Return New ViewConsignmentAdjustments
            Case "ViewConsignmentBilling"
                Return New ViewConsignmentBilling
            Case "ViewConsignmentInventory"
                Return New ViewConsignmentInventory
            Case "ViewConsignmentReturns"
                Return New ViewConsignmentReturns
            Case "ViewConsignmentShipping"
                Return New ViewConsignmentShipping
            Case "ViewConsignmentTotals"
                Return New ViewConsignmentTotals
            Case "ViewCustomerListing"
                Return New ViewCustomerListing
            Case "ViewCustomerOrders"
                Return New ViewCustomerOrders
            Case "ViewCustomerPaymentActivity"
                Return New ViewCustomerPaymentActivity
            Case "ViewCustomerReturnListing"
                Return New ViewCustomerReturnListing
            Case "ViewCustomerSalesHistory"
                Return New ViewCustomerSalesHistory
            Case "ViewDailyShipmentLog"
                Return New ViewDailyShipmentLog
            Case "ViewEditTrufitCerts"
                Return New ViewEditTrufitCerts
            Case "ViewEFTRemmittance"
                Return New ViewEFTRemittance
            Case "ViewEmployeeLogonTable"
                Return New ViewEmployeeLogonTable
            Case "ViewFerruleToolingBlueprints"
                Return New ViewFerruleToolingBlueprints
            Case "ViewFirstPieceInspectionEntries"
                Return New ViewFirstPieceInspectionEntries
            Case "ViewFoxInspectionEntries"
                Return New ViewFOXInspectionEntries
            Case "ViewFOXListing"
                Return New ViewFOXListing
            Case "ViewFOXReleaseSchedule"
                Return New ViewFOXReleaseSchedule
            Case "ViewFOXStepCosting"
                Return New ViewFOXStepCosting
            Case "ViewGaugeSignouts"
                Return New ViewGaugeSignouts
            Case "ViewGLChartOfAccounts"
                Return New ViewGLChartOfAccounts
            Case "ViewGLLinePostings"
                Return New ViewGLLinePostings
            Case "ViewGLTransactionListing"
                Return New ViewGLTransactionListing
            Case "ViewHeaderSetupSheets"
                Return New ViewHeaderSetupSheets
            Case "ViewHeatNumberLog"
                Return New ViewHeatNumberLog
            Case "ViewHeatTreatInspectionLog"
                Return New ViewHeatTreatInspectionLog
            Case "ViewUploadedInspectionReport"
                Return New ViewUploadedInspectionReport
            Case "ViewInspectionReportUploadFiles"
                Return New ViewInspectionReportUploadFiles
            Case "ViewIntercompanyShipments"
                Return New ViewIntercompanyShipments
            Case "ViewInventoryAdjustments"
                Return New ViewInventoryAdjustments
            Case "ViewInventoryCoilWIP"
                Return New ViewInventoryCoilWIP
            Case "ViewInventoryTransactions"
                Return New ViewInventoryTransactions
            Case "ViewInventoryValueByFilter"
                Return New ViewInventoryValueByFilter
            Case "ViewInvoiceDetails"
                Return New ViewInvoiceDetails
            Case "ViewInvoiceLedgerPostings"
                Return New ViewInvoiceLedgerPostings
            Case "ViewInvoiceLines"
                Return New ViewInvoiceLines
            Case "ViewInvoiceLinesBySort"
                Return New ViewInvoiceLinesBySort
            Case "ViewInvoiceListing"
                Return New ViewInvoiceListing
            Case "ViewItemClassPriceChangeTiers"
                Return New ViewItemClassPriceChangeTiers
            Case "ViewItemListing"
                Return New ViewItemListing
            Case "ViewLeadTimes"
                Return New ViewLeadTimes
            Case "ViewLotNumbers"
                Return New ViewLotNumbers
            Case "ViewManualBOLs"
                Return New ViewManualBOLs
            Case "ViewMillCertPopup"
                Return New ViewMillCertPopup
            Case "ViewOpenPurchaseLines"
                Return New ViewOpenPurchaseLines
            Case "ViewOpenSOLines"
                Return New ViewOpenSOLines
            Case "ViewOpenSteelPO"
                Return New ViewOpenSteelPO
            Case "ViewPartNumberSalesTotals"
                Return New ViewPartNumberSalesTotals
            Case "ViewPendingShipments"
                Return New ViewPendingShipments
            Case "ViewPickPulledLines"
                Return New ViewPickPulledLines
            Case "ViewPickQuantityOnHand"
                Return New ViewPickQuantityOnHand
            Case "ViewPickTickets"
                Return New ViewPickTickets
            Case "ViewPOHeaders"
                Return New ViewPOHeaders
            Case "ViewPullTests"
                Return New ViewPullTests
            Case "ViewPurchaseLines"
                Return New ViewPurchaseLines
            Case "ViewQCNonConformance"
                Return New ViewQCNonConformance
            Case "ViewQuoteListing"
                Return New ViewQuoteListing
            Case "ViewRackingActivityLog"
                Return New ViewRackingActivityLog
                'Case "ViewRackingInventory"
                '    Return New ViewRackingInventory
            Case "ViewReceiverLines"
                Return New ViewReceiverLines
            Case "ViewReceivingHeaders"
                Return New ViewReceivingHeaders
            Case "ViewReceivingOnTime"
                Return New ViewReceivingOnTime
            Case "ViewSalesByCategory"
                Return New ViewSalesByCategory
            Case "ViewSalesLines"
                Return New ViewSalesLines
            Case "ViewSalesOrderHeaders"
                Return New ViewSalesOrderHeaders
            Case "ViewShipmentLines"
                Return New ViewShipmentLines
            Case "ViewShipmentLineSerialNumbers"
                Return New ViewShipmentLineSerialNumbers
            Case "ViewShipmentLotNumbers"
                Return New ViewShipmentLotNumbers
            Case "ViewShipmentsForInvoicing"
                Return New ViewShipmentsForInvoicing
            Case "ViewShipmentStatus"
                Return New ViewShipmentStatus
            Case "ViewShippingFreightDetails"
                Return New ViewShippingFreightDetails
            Case "ViewSteelAdjustments"
                Return New ViewSteelAdjustments
            Case "ViewSteelCoils"
                Return New ViewSteelCoils
            Case "ViewSteelCoilsCoilComment"
                Return New ViewSteelCoilsCoilComment
            Case "ViewSteelInventoryValue"
                Return New ViewSteelInventoryValue
            Case "ViewSteelList"
                Return New ViewSteelList
            Case "ViewSteelPurchaseLines"
                Return New ViewSteelPurchaseLines
            Case "ViewSteelReceipts"
                Return New ViewSteelReceipts
            Case "ViewSteelReceivingCoilLines"
                Return New ViewSteelReceivingCoilLines
            Case "ViewSteelReceivingInspections"
                Return New ViewSteelReceivingInspections
            Case "ViewSteelReceivingMonthlySummary"
                Return New ViewSteelReceivingMonthlySummary
            Case "ViewSteelRequirementDetails"
                Return New ViewSteelRequirementDetails
            Case "ViewSteelRequirements"
                Return New ViewSteelRequirements
            Case "ViewSteelSpecialOrders"
                Return New ViewSteelSpecialOrders
            Case "ViewSteelTransactions"
                Return New ViewSteelTransactions
            Case "ViewSteelUsage"
                Return New ViewSteelUsage
            Case "ViewSteelUsageByMonth"
                Return New ViewSteelUsageByMonth
            Case "ViewSteelUsageByWeek"
                Return New ViewSteelUsageByWeek
            Case "ViewSteelVendorReturns"
                Return New ViewSteelVendorReturns
            Case "ViewSteelWireYardEntry"
                Return New ViewSteelWireYardEntry
            Case "ViewStockStatusValuation"
                Return New ViewStockStatusValuation
            Case "ViewTaxCollected"
                Return New ViewTaxCollected
            Case "ViewTestLog"
                Return New ViewTestLog
            Case "ViewTFPInventory"
                Return New ViewTFPInventory
            Case "ViewTFPMechanicalTests"
                Return New ViewTFPMechanicalTests
            Case "ViewTFPQuoteListing"
                Return New ViewTFPQuoteListing
            Case "ViewTimeSlipRoster"
                Return New ViewTimeSlipRoster
            Case "ViewTimeSlips"
                Return New ViewTimeSlips
            Case "ViewTimeSlipTotals"
                Return New ViewTimeSlipTotals
            Case "ViewTrufitCertifications"
                Return New ViewTrufitCertifications
            Case "ViewTrufitCerts"
                Return New ViewTrufitCerts
            Case "ViewTubPage"
                Return New ViewTubPage
            Case "ViewUploadedInspectionReport"
                Return New ViewUploadedInspectionReport
            Case "ViewUploadedInspectionReport"
                Return New ViewUploadedOutsideCerts
            Case "ViewUploadedSafetySheets"
                Return New ViewUploadedSafetySheets
            Case "ViewUploadedSafetySheets"
                Return New ViewUploadedSaltSprayInspections
            Case "ViewUploadedSteelBOL"
                Return New ViewUploadedSteelBOL
            Case "ViewUploadedSteelInspections"
                Return New ViewUploadedSteelInspections
            Case "ViewVendorListing"
                Return New ViewVendorListing
            Case "ViewVendorReturnLines"
                Return New ViewVendorReturnLines
            Case "ViewVendorReturns"
                Return New ViewVendorReturns
            Case "ViewVendorSummary"
                Return New ViewVendorSummary
            Case "ViewVoucherLines"
                Return New ViewVoucherLines
            Case "ViewVoucherListing"
                Return New ViewVoucherListing
            Case "ViewWCProductionPostings"
                Return New ViewWCProductionPostings
            Case "ViewWIP"
                Return New ViewWIP
            Case "ViewWIPPopup"
                Return New ViewWIPPopup
            Case "ViewWorkOrders"
                Return New ViewWIPPopup
            Case "ViewWIPValue"
                Return New ViewWIPValue
            Case "WorkOrder"
                Return New WorkOrder
        End Select
        Return Nothing
    End Function

    Private Sub cboSecurityID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecurityID.SelectedIndexChanged
        If cboSecurityID.SelectedIndex <> -1 and isloaded Then
            ShowData()
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.SelectedIndex <> -1 And isLoaded Then
            ShowData()
        End If
    End Sub

    Private Sub cboEmployeeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmployeeID.SelectedIndexChanged
        If cboEmployeeID.SelectedIndex <> -1 And isLoaded Then
            ShowData()
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        isLoaded = False
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmdShowHideHierarchy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowHideHierarchy.Click
        trvCtrlHierarchy.Nodes.Clear()
        If cboControls.SelectedIndex <> -1 And Not String.IsNullOrEmpty(cboControls.Text) And Not trvCtrlHierarchy.Visible Then
            Dim controlList As List(Of TreeNode) = getNodes(cboControls.Text, New List(Of TreeNode))
            For i As Integer = 0 To controlList.Count - 1
                Select Case i
                    Case 0
                        trvCtrlHierarchy.Nodes.Add(controlList(i))
                    Case 1
                        trvCtrlHierarchy.Nodes(0).Nodes.Add(controlList(i))
                    Case 2
                        trvCtrlHierarchy.Nodes(0).Nodes(0).Nodes.Add(controlList(i))
                    Case 3
                        trvCtrlHierarchy.Nodes(0).Nodes(0).Nodes(0).Nodes.Add(controlList(i))
                    Case 4
                        trvCtrlHierarchy.Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes.Add(controlList(i))
                    Case 5
                        trvCtrlHierarchy.Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes.Add(controlList(i))
                    Case 6
                        trvCtrlHierarchy.Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes.Add(controlList(i))
                    Case 7
                        trvCtrlHierarchy.Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes.Add(controlList(i))
                    Case 8
                        trvCtrlHierarchy.Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes.Add(controlList(i))
                    Case 9
                        trvCtrlHierarchy.Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes.Add(controlList(i))
                    Case 10
                        trvCtrlHierarchy.Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes.Add(controlList(i))
                End Select

            Next
            trvCtrlHierarchy.ExpandAll()
            trvCtrlHierarchy.Show()
            cmdShowHideHierarchy.Text = "Hide Hierarchy"
        Else
            If cboForm.SelectedIndex <> -1 And Not trvCtrlHierarchy.Visible Then
                trvCtrlHierarchy.Nodes.Add(getChildNodes(currentForm))
                If trvCtrlHierarchy.Nodes.Count > 0 Then
                    trvCtrlHierarchy.Nodes(0).Expand()
                End If
                trvCtrlHierarchy.Show()
                cmdShowHideHierarchy.Text = "Hide Hierarchy"
            Else
                If trvCtrlHierarchy.Visible Then
                    trvCtrlHierarchy.Hide()
                    cmdShowHideHierarchy.Text = "Show Hierarchy"
                End If
            End If
        End If
    End Sub

    Private Function getNodes(ByVal ctrlName As String, ByVal nodeList As List(Of System.Windows.Forms.TreeNode)) As List(Of System.Windows.Forms.TreeNode)
        Dim ctrlObj As Control = usefulFunctions.FindControl(ctrlName, currentForm)
        If ctrlObj Is Nothing Then
            Return nodeList
        End If
        If Not ctrlObj.Parent.Name.Equals(currentForm.Name) Then
            getNodes(ctrlObj.Parent.Name, nodeList)
        Else
            nodeList.Add(New TreeNode(currentForm.Name))
        End If
        nodeList.Add(New TreeNode(ctrlName))
        Return nodeList
    End Function

    Private Function getChildNodes(ByVal ctrl As Control) As TreeNode
        Dim nde As New TreeNode(ctrl.Name)
        nde.ToolTipText = ctrl.Text
        If ctrl.Controls.Count > 0 Then
            For i As Integer = 0 To ctrl.Controls.Count - 1
                nde.Nodes.Add(getChildNodes(ctrl.Controls(i)))
            Next
        End If
        Return nde
    End Function

    Private Sub trvCtrlHierarchy_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trvCtrlHierarchy.DoubleClick
        If String.IsNullOrEmpty(cboControls.Text) Then
            cboControls.Text = trvCtrlHierarchy.SelectedNode.Text
            trvCtrlHierarchy.Hide()
            cmdShowHideHierarchy.Text = "Show Hierarchy"
        End If
    End Sub

End Class