Module ControlModule
    'Global variables for login form
    Public LoginLast As String
    Public LoginCompany As String
    Public LoginPassword1 As String
    Public LoginPassword2 As String
    Public EmployeeSecurityCode As Single
    Public EmployeeCompanyCode As String
    Public EmployeeLoginName As String
    Public EmployeeSalespersonCode As String
    Public GlobalVerifyCode As String
    Public GlobalSessionID As Integer
    Public GlobalEmployeeName As String

    'Global Variables for price changes
    Public GlobalPriceChangeMultiplierTWD As Double = 1.05
    Public GlobalPriceChangeMultiplierSLC As Double = 1.12
    Public GlobalPriceChangeMultiplierCHT As Double = 1.08
    Public GlobalPriceChangeMultiplierTWE As Double = 1.05

    Public GlobalPriceChangeMultiplierTWD05 As Double = 1.05
    Public GlobalPriceChangeMultiplierTWD08 As Double = 1.08
    Public GlobalPriceChangeMultiplierTWD09 As Double = 1.09
    Public GlobalPriceChangeMultiplierTWD10 As Double = 1.1

    Public GlobalSLCPriceChangeDate As Date = "1/11/2018"
    Public GlobalTWDPriceChangeDate As Date = "2/1/2021"
    Public GlobalCHTPriceChangeDate As Date = "1/1/2021"
    Public GlobalTWEPriceChangeDate As Date = "10/1/2018"

    'Global Variable for Price Bracket Popup
    Public GlobalPriceBracketSource As String

    Public RackingTransactionKeyRunningTotal As Int64
    Public FerruleProductionKey As Int64
    Public PartNumberLookup As String
    Public PartDescriptionLookup As String
    Public CustomerCodeLookup As String
    Public VendorPartLookup As String
    Public VendorNameLookup As String
    Public QuoteNumberListing As Integer
    Public SalesOrderLookup As Integer
    Public PressProductionDate As Date
    Public PickListStyle As String
    Public GlobalSteelCarbon As String

    'Global Variables to autofill forms on load from other forms
    Public GlobalPickListNumber As Integer
    Public GlobalPONumber As Integer
    Public GlobalSONumber As Integer
    Public GlobalCustomerName As String
    Public GlobalShipmentNumber As Integer
    Public GlobalShipmentDate As String
    Public GlobalProductionPartNumber As String
    Public GlobalMaintenancePartNumber As String
    Public GlobalMaintenancePartDescription As String
    Public GlobalCustomerReturnNumber As Integer
    Public GlobalCustomerID As String
    Public GlobalVendorID As String
    Public GlobalItemClass As String
    Public GlobalFOXNumber As Integer
    Public GlobalVendorName As String
    Public GlobalAPBatchNumber As Int64
    Public GlobalARBatchNumber As Int64
    Public GlobalAPDivisionID As String
    Public GlobalVoucherNumber As Integer
    Public GlobalVoucherNumber2 As Integer
    Public GlobalVoucherType As String
    Public GlobalReceiverNumber As Integer
    Public GlobalVendorReturnNumber As Integer
    Public GlobalDiscountDate As Date
    Public GlobalDiscountDays As Integer
    Public GlobalDueDate As Date
    Public GlobalProductionEntry As Integer
    Public GlobalTransferOrderNumber As Integer
    Public GlobalSteelReceivingNumber As Integer
    Public GlobalSteelPONumber As Integer
    Public GlobalShipmentStatus As String
    Public GlobalLotNumber As String
    Public GlobalInvoiceNumber As Integer
    Public GlobalTWQuoteNumber As Integer
    Public GlobalDivisionCode As String
    Public GlobalSteelRMID As String
    Public GlobalSteelBatchNumber As Int64
    Public GlobalTrufitCertNumber As Integer
    Public GlobalHeatTreatFileNumber As Integer
    Public GlobalHeatFileNumber As Integer
    Public GlobalPickBatchNumber As Int64
    Public GlobalSteelAdjustmentNumber As Integer
    Public GlobalARTransactionNumber As Int64
    Public GlobalTFPQuoteNumber As Integer
    Public GlobalTimeSlipNumber As Integer
    Public GlobalRequisitionNumber As Integer
    Public GlobalHeaderTransactionNumber As Integer
    Public GlobalInventoryAdjustmentBatchNumber As Int64
    Public GlobalInventoryAdjustmentNumber As Int64
    Public GlobalARPaymentID As Integer
    Public GlobalPullTestNumber As String
    Public GlobalAnnealLotNumber As Integer
    Public GlobalAPStartingCheckNumber As Int64
    Public GlobalReturnNumber As Integer
    Public GlobalCustomerID2 As String
    Public GlobalBankAccountID As String
    Public GlobalBOLNumber As Integer
    Public GlobalWCProductionNumber As Integer
    Public GlobalSOStatus As String
    Public GlobalGLBatchNumber As Int64
    Public GlobalItemListingPartNumber As String
    Public GlobalAPCheckType As String

    'Variables used in Sales Order Broken Box Charge
    Public GlobalSalesOrderQuantity As Integer
    Public GlobalSalesOrderHigher As Integer
    Public GlobalSalesOrderLower As Integer
    Public GlobalBrokenBoxCharge As String

    'Variables used in Accessory Form
    Public GlobalOrderQuantity As Integer
    Public GlobalNominalDiameter As Double
    Public GlobalNominalLength As Double
    Public GlobalSOUnitPrice As Double

    'Global Datasets for "In-Form" Filtering
    Public GDS, GDS1, GDS2, GDS3, GDS4, GDS5, GDS10 As DataSet

    'Global variable for Sales Order Popup
    Public GlobalGoToSalesOrder As String
    Public GlobalGoToShipment As String

    'GlobalDate
    Public GlobalBeginDate As String
    Public GlobalEndDate As String
    Public GlobalARBatchDate As Date
    Public GlobalValuationDate As String
    Public GlobalSelectDate As String

    'Global QC Data
    Public GlobalQCBPNumber As String
    Public GlobalQCPartNumber As String
    Public GlobalInspectionKey As String

    'Division Code Reloads for specific forms
    Public ReloadAPDivisionCode As String
    Public GlobalARDivisionCode As String

    Public GlobalNewAPBatchNumber As Int64
    Public GlobalNewARBatchNumber As Int64
    Public GlobalAPPONumber As Integer
    Public GlobalSelectLinesReceiverNumber As Integer
    Public GlobalSelectLinesPONumber As Integer
    Public GlobalAssemblyPartNumber As String
    Public GlobalVendorClass As String
    Public GlobalCheckType As String

    'Variables Used for PO QOH Popup
    Public GlobalPOPartNumber, GlobalPOPartDescription As String

    'Variables Used for SO Popup
    Public GlobalSOPartNumber, GlobalSOCustomerID As String

    'Variable used in BOM
    Public GlobalAssemblyTransactionNumber As Int64

    'Variables used to load shipment from sales order
    Public GlobalSOShipmentNumber, GlobalSOPickNumber As Integer

    Public GlobalAPVendorID As String
    Public GlobalAPCheckNumber As Int64

    'Bank variable for print batch form
    Public GlobalBankBatchNumber As Integer

    Public GlobalGLTemplateName As String
    Public GlobalReprintInvoiceBatch As String

    'Variable to print filtered items from Sales Order
    Public GlobalSONumberPickList As Integer
    Public GlobalSONumberPackSlip As Integer
    Public GlobalSONumberInvoice As Integer
    Public GlobalDropShipPONumber As Integer

    'Variables to select Invoice Line Sort Selection
    Public GlobalInvoiceSortField As String

    'Variable to autofill Item Lookup Popup Form
    Public GlobalPartNumberLookup As String
    Public GlobalPartDescriptionLookup As String

    'Reprint Certs from Lot Number
    'And Variables for Auto-Saving Certs in Directory Structure
    Public GlobalReprintPullTestNumber As String
    Public GlobalReprintLotNumber As String
    Public GlobalReprintHeatNumber As String
    Public GlobalCertCustomer As String
    Public GlobalCertHeatNumber As String
    Public GlobalCertPartNumber As String
    Public GlobalCertShipmentNumber As Integer
    Public GlobalCertLotNumber As String

    'Select Grouping Level on Print Shipment Lines
    Public GlobalGroupingShipmentLines As String

    'Select Correct Print Report for Sales Order in TFP
    Public GlobalTFPSOPrintForm As String

    'Create variables to print single TW Cert
    Public CertLotNumber As String
    Public CertHeatNumber As String
    Public CertCustomerID As String
    Public CertPartNumber As String
    Public CertShipmentNumber As Integer
    Public GlobalPrintNoCertPage As String

    'Variables used to Email Invoices and Certs
    Public EmailInvoiceNumber As Integer
    Public EmailSalesOrderNumber As Integer
    Public EmailShipmentNumber As Integer
    Public EmailAddress As String
    Public EmailInvoiceCustomer As String
    Public EmailStringInvoiceNumber As String
    Public EmailCustomerEmailAddress As String
    Public EmailCustomerConfirmations As String
    Public EmailCustomerStatements As String
    Public EmailCustomerCerts As String

    'Variables used for Backorder Report
    Public BackorderCustomer As String
    Public BackorderReportFilter As String

    'Variable used in Price Bracket Look up
    Public GlobalSOPriceBracket As Double
    Public GlobalCompleteShipment As String

    'Variable for use in Print QC Noncon Form
    Public GlobalQCTransactionNumber As Int64

    'Variables for use in Shipment Popup Form for Serial Numbers
    Public GlobalShipmentNumberSerial As Integer
    Public GlobalShipmentLineNumberSerial As Integer
    Public GlobalShipmentPartNumberSerial As String

    Public GlobalVendorType As String
    Public GlobalPickTicketType As String
    Public GlobalPrintPickTickets As String 'To auto-print print tickets

    'Variable for Next Piece Sold Popup
    Public GlobalNextPieceSold As Double

    'Variable used for Serial Assembly Popup
    Public GlobalSerialAssemblyQuantity As Integer
    Public GlobalAssemblyBuildQuantity As Integer
    Public GlobalAssemblyBatchNumber As Int64
    Public GlobalAssemblyInvoiceNumber As Integer
    Public GlobalAssemblyInvoiceLine As Integer
    Public GlobalAssemblyCustomer As String
    Public GlobalSerialValidation As String
    Public GlobalSerialFormLocation As String
    Public GlobalSumSerialCost As Double

    'Variable used for User Preferences for Stock Status
    Public GlobalStockStatusUserPreferences As String

    'Variable used for Invoice Reports
    Public GlobalInvoiceReports As String

    'Variable used to check if print certs form will open
    Public GlobalCheckIfCertsWillPrint As String

    'Variables for Sales By Category Print Form
    Public GlobalGroupByPartNumber As String
    Public GlobalGroupByItemClass As String
    Public GlobalGroupByMonth As String
    Public GlobalGroupByCustomer As String
    Public GlobalGroupBySubtotal As String
    Public GlobalGroupByAll As String

    'Variables for FOX Steel Order Form
    Public GlobalSteelOrderFOXNumber As Integer
    Public GlobalSteelOrderPartNumber As String
    Public GlobalSteelOrderRMID As String
    Public GlobalSteelOrderCarbon As String
    Public GlobalSteelOrderSteelSize As String
    Public GlobalSteelOrderSteelDescription As String
    Public GlobalSteelOrderProcessAgent As String
    Public GlobalSteelOrderSteelRequired As Double
    Public GlobalSteelOrderPartDescription As String

    'Variables for Month Snapshot
    Public GlobalMonthField As String
    Public GlobalYearField As String

    'Variables for NAFTA Form
    Public GlobalNaftaKey As Integer
    Public GlobalNaftaDate As String
    Public GlobalNaftaCustomerID As String
    Public GlobalNaftaPrintType As String
    Public GlobalNAFTAShipDate As String

    'Variables for stud welding certificates
    Public GlobalTraineeName As String
    Public GlobalTraineeCompany As String
    Public GlobalStudweldingBatchPrinting As String
    Public GlobalStudweldingBatchNumber As Integer

    'Variables for Lead Time Report
    Public GlobalLeadTimeReport As String

    'Variable to autoprint receiver for divisions
    Public GlobalAutoPrintReceiver As String

    'Variables for Popup Form from Rack Datagrid
    Public GlobalRackingKey As Integer

    'Variable to determine GL Listing/Archive Report
    Public GlobalLedgerPrintForm As String

    'Variable to display Customer Inactivity Report on Customer Listing Print Form
    Public GlobalCustomerInactivityReport As String

    'Variable used for Print Racking Report (NEW)
    Public GlobalPrintRackingType As String

    'Variable to display Lot Number popup on Shipment Completion
    Public GlobalLotNumberPart As String = ""

    'Variable for Steel Return Print Forms
    Public GlobalSteelVendorReturnNumber As Integer

    'Variable used for Coil Comment
    Public GlobalCoilID As String

    'Variable to print multiple packing lists
    Public GlobalShipmentBatchNumber As Int64
    Public GlobalShipmentPrintType As String
    Public GlobalAutoPrintPackingList As String

    'Variables for Steel Vendor Return
    Public GlobalSteelReturnNumber As Integer
    Public GlobalSteelReturnFormType As String
    Public GlobalSteelReturnPONumber As Integer
    Public GlobalSteelReturnCarbon As String
    Public GlobalSteelReturnSize As String

    'Variable for steel receipt of invoice (BOL)
    Public GlobalAPSteelBOLNumber As String

    'Variable to check rounding on Steel Vendor Returns
    Public GlobalSteelReturnRounding As String

    'Variable for Steel Coil Receiving by Despatch
    Public GlobalSteelDespatchNumber As String

    'Variable for loading Vendor Email Address into AP Voucher Print Form
    Public GlobalVendorRemittanceEmail As String
    Public GlobalVendorIsLoaded As String

    'Variables for Time Slip Posting validation
    Public GlobalTimeSlipValidation As String
    Public GlobalTimeSlipValidationDate As Date

    'Variabnle for TWD Inventory Report
    Public GlobalPrintWithoutCommitted As String

    'Variable for Uploaded Pick Ticket Filename
    Public GlobalUploadedPickTicket As String

    'Variables for Steel Coil Pop Up
    Public GlobalSteelReceiverNumberPopup As Integer
    Public GlobalSteelReceiverLinePopup As Integer
    Public GlobalSteelReceiverRMIDPopup As String

    'Variable to choose check remittance print (auto or pop up)
    Public GlobalNoAutoPrintCheckRemittance As String
    Public GlobalAPRemittanceEmail As String

    'Variable for printing Steel List - Filtered vs Unfiltered
    Public GlobalSteelListFromRM As String

    'Variable to print Inventory Tub Tag
    Public GlobalInventoryTagID As Integer
    Public GlobalInventoryTagPrintMethod As String

    'Variable for choosing between work order and production order
    Public GlobalProductionWorkOrder As String
    Public GlobalProductionOrderAutoprint As String

    'Variable to Load Mechanical Test from viewer
    Public GlobalMechanicalTestNumber As String

    'Variable to select Crystal Report for Purchase Order Lines
    Public GlobalPurchaseLineReport As String

    'Variable to Open SO Open Order Report
    Public GlobalOpenOrderReport As String

    'Variables to create TFP Corp Email
    Public TFPMailCustomer As String
    Public TFPMailFilename As String
    Public TFPMailFilename2 As String
    Public TFPMailFilename3 As String
    Public TFPMailSendAddress As String
    Public TFPMailToAddress As String
    Public TFPMailReplyAddress As String
    Public TFPMailTransactionType As String
    Public TFPMailTransactionNumber As Integer
    Public TFPMailFilePath As String
    Public TFPMailFilePath2 As String
    Public TFPMailFilePath3 As String

    'Variable for Sales Tax Exemption Certificate
    Public GlobalTaxExemptCert As String

    'Variable for Customer Credit App
    Public GlobalCustomerCreditAPP As String

    'Variable to keep check box checked on APP
    Public GlobalAPPFPCheckBox As String

    'Variable for Customer from the Pick Ticket
    Public GlobalPickCustomer As String

    'Global Variable for custom / vendor BOL
    Public GlobalVendorBOLNumber As Integer

    'Global Variable to Print Work Orders
    Public GlobalWorkOrderNumber As Integer
End Module
