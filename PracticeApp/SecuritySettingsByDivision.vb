Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Printing
Module SecuritySettingsByDivision

    Dim CurrentDivisionCode As String = ""

    Public Function SecurityPreferencesADM()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = True
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = True
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = True
        MainInterface.cmdRawMaterialsMenu.Enabled = True
        MainInterface.cmdTruFitModule.Enabled = True
        MainInterface.cmdQualityControlMenu.Enabled = True
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = True
        MainInterface.llViewFOXListingGI.Enabled = True
        MainInterface.llViewSteelListGI.Enabled = True
        MainInterface.llViewHeatNumbersGI.Enabled = True
        MainInterface.llConsignmentShippingGI.Enabled = True
        MainInterface.llConsignmentBillingGI.Enabled = True
        MainInterface.llConsignmentAdjustmentsGI.Enabled = True
        MainInterface.llConsignmentReturnsGI.Enabled = True

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = True
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = True
        MainInterface.llDiscrepancyReportRP.Enabled = True

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = True
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = True
        MainInterface.llViewConsignmentInventoryIV.Enabled = True
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = True
        MainInterface.llConsignmentAdjustmentIV.Enabled = True
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = True
        MainInterface.llInventoryRackingIV.Enabled = True
        MainInterface.llViewRackActivityIV.Enabled = True
        MainInterface.llViewRackingReportIV.Enabled = True
        MainInterface.llDiscreptancyReportIV.Enabled = True
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = True
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = True
        MainInterface.llMaintenanceRackingIV.Enabled = True

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = True
        MainInterface.llViewConsignmentBillingSO.Enabled = True
        MainInterface.llViewConsignmentReturnsSO.Enabled = True
        MainInterface.llViewConsignmentShippingSO.Enabled = True
        MainInterface.llConsignmentStockStatusSO.Enabled = True
        MainInterface.llConsignmentTotalsSO.Enabled = True
        MainInterface.llCanamSalesReportSO.Enabled = True

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = True
        MainInterface.llViewSteelPOsPO.Enabled = True

        '***************************************************************************
        'Lock links in Production Menu

        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = True
        MainInterface.llViewFOXListingPM.Enabled = True
        MainInterface.llTimeSlipMenuPM.Enabled = True
        MainInterface.llTimeSlipPostingPM.Enabled = True
        MainInterface.llViewTimeSlipPostingsPM.Enabled = True
        MainInterface.llMaintainMachineDataPM.Enabled = True
        MainInterface.llProductionSchedulingPM.Enabled = True
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = True
        MainInterface.llViewLeadTimesPM.Enabled = True
        MainInterface.llViewSteelListPM.Enabled = True
        MainInterface.llViewSteelCoilsPM.Enabled = True
        MainInterface.llSteelConsumptionPM.Enabled = True
        MainInterface.llProductionTotalsPM.Enabled = True
        MainInterface.llProductionGraphingPM.Enabled = True

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = True
        MainInterface.llViewAssemblyListingPM.Enabled = True
        MainInterface.llViewSerializedLogPM.Enabled = True
        MainInterface.llViewBuildListingPM.Enabled = True
        MainInterface.llViewFOXWIPPM.Enabled = True
        MainInterface.llViewFOXStepCostingPM.Enabled = True
        MainInterface.llHeaderSetupSheetPM.Enabled = True
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = True
        MainInterface.llViewBlueprintsPM.Enabled = True
        MainInterface.llViewTimeSlipRosterPM.Enabled = True
        MainInterface.llViewAllTimeSlipsPM.Enabled = True

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = True
        MainInterface.llWIPCoilInventoryPM.Enabled = True
        MainInterface.llProductionInventoryTubsPM.Enabled = True

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = True
        MainInterface.llShippingPartialPalletRackingSH.Enabled = True
        MainInterface.llRackingUtilitySH.Enabled = True
        MainInterface.llViewConsignmentShippingSH.Enabled = True
        MainInterface.llViewReleaseScheduleSH.Enabled = True
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = True
        MainInterface.llViewSteelBOLsSH.Enabled = True
        MainInterface.llViewEditTrufitCertsSH.Enabled = True
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = True
        MainInterface.llViewRackActivitySH.Enabled = True
        MainInterface.llViewPickRackingSH.Enabled = True
        MainInterface.llCertErrorLogSH.Enabled = True
        MainInterface.llViewSDSSH.Enabled = True

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = True
        MainInterface.llPaymentReversalAR.Enabled = True
        MainInterface.llViewEditCustomerPaymentAR.Enabled = True
        MainInterface.llBankTransactionsAR.Enabled = True
        MainInterface.llViewCashReceiptsAR.Enabled = True
        MainInterface.llViewCustomerPaymentsAR.Enabled = True

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesALB()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = False
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = False
        MainInterface.llConsignmentBillingGI.Enabled = False
        MainInterface.llConsignmentAdjustmentsGI.Enabled = False
        MainInterface.llConsignmentReturnsGI.Enabled = False

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = False
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = False
        MainInterface.llConsignmentAdjustmentIV.Enabled = False
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = False
        MainInterface.llViewConsignmentBillingSO.Enabled = False
        MainInterface.llViewConsignmentReturnsSO.Enabled = False
        MainInterface.llViewConsignmentShippingSO.Enabled = False
        MainInterface.llConsignmentStockStatusSO.Enabled = False
        MainInterface.llConsignmentTotalsSO.Enabled = False
        MainInterface.llCanamSalesReportSO.Enabled = False

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = False
        MainInterface.llViewSteelPOsPO.Enabled = False

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = False
        MainInterface.llViewFOXListingPM.Enabled = False
        MainInterface.llTimeSlipMenuPM.Enabled = False
        MainInterface.llTimeSlipPostingPM.Enabled = False
        MainInterface.llViewTimeSlipPostingsPM.Enabled = False
        MainInterface.llMaintainMachineDataPM.Enabled = False
        MainInterface.llProductionSchedulingPM.Enabled = False
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = False
        MainInterface.llViewLeadTimesPM.Enabled = False
        MainInterface.llViewSteelListPM.Enabled = False
        MainInterface.llViewSteelCoilsPM.Enabled = False
        MainInterface.llSteelConsumptionPM.Enabled = False
        MainInterface.llProductionTotalsPM.Enabled = False
        MainInterface.llProductionGraphingPM.Enabled = False

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = False
        MainInterface.llViewAssemblyListingPM.Enabled = False
        MainInterface.llViewSerializedLogPM.Enabled = False
        MainInterface.llViewBuildListingPM.Enabled = False
        MainInterface.llViewFOXWIPPM.Enabled = False
        MainInterface.llViewFOXStepCostingPM.Enabled = False
        MainInterface.llHeaderSetupSheetPM.Enabled = False
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = False
        MainInterface.llViewBlueprintsPM.Enabled = False
        MainInterface.llViewTimeSlipRosterPM.Enabled = False
        MainInterface.llViewAllTimeSlipsPM.Enabled = False

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = False
        MainInterface.llWIPCoilInventoryPM.Enabled = False
        MainInterface.llProductionInventoryTubsPM.Enabled = False

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = False
        MainInterface.llShippingPartialPalletRackingSH.Enabled = False
        MainInterface.llRackingUtilitySH.Enabled = False
        MainInterface.llViewConsignmentShippingSH.Enabled = False
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = False
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = False
        MainInterface.llViewRackActivitySH.Enabled = False
        MainInterface.llViewPickRackingSH.Enabled = False
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesATL()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = False
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = False
        MainInterface.llConsignmentBillingGI.Enabled = False
        MainInterface.llConsignmentAdjustmentsGI.Enabled = False
        MainInterface.llConsignmentReturnsGI.Enabled = False

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = False
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = False
        MainInterface.llConsignmentAdjustmentIV.Enabled = False
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = False
        MainInterface.llViewConsignmentBillingSO.Enabled = False
        MainInterface.llViewConsignmentReturnsSO.Enabled = False
        MainInterface.llViewConsignmentShippingSO.Enabled = False
        MainInterface.llConsignmentStockStatusSO.Enabled = False
        MainInterface.llConsignmentTotalsSO.Enabled = False
        MainInterface.llCanamSalesReportSO.Enabled = False

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = False
        MainInterface.llViewSteelPOsPO.Enabled = False

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = False
        MainInterface.llViewFOXListingPM.Enabled = False
        MainInterface.llTimeSlipMenuPM.Enabled = False
        MainInterface.llTimeSlipPostingPM.Enabled = False
        MainInterface.llViewTimeSlipPostingsPM.Enabled = False
        MainInterface.llMaintainMachineDataPM.Enabled = False
        MainInterface.llProductionSchedulingPM.Enabled = False
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = False
        MainInterface.llViewLeadTimesPM.Enabled = False
        MainInterface.llViewSteelListPM.Enabled = False
        MainInterface.llViewSteelCoilsPM.Enabled = False
        MainInterface.llSteelConsumptionPM.Enabled = False
        MainInterface.llProductionTotalsPM.Enabled = False
        MainInterface.llProductionGraphingPM.Enabled = False

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = False
        MainInterface.llViewAssemblyListingPM.Enabled = False
        MainInterface.llViewSerializedLogPM.Enabled = False
        MainInterface.llViewBuildListingPM.Enabled = False
        MainInterface.llViewFOXWIPPM.Enabled = False
        MainInterface.llViewFOXStepCostingPM.Enabled = False
        MainInterface.llHeaderSetupSheetPM.Enabled = False
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = False
        MainInterface.llViewBlueprintsPM.Enabled = False
        MainInterface.llViewTimeSlipRosterPM.Enabled = False
        MainInterface.llViewAllTimeSlipsPM.Enabled = False

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = False
        MainInterface.llWIPCoilInventoryPM.Enabled = False
        MainInterface.llProductionInventoryTubsPM.Enabled = False

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = False
        MainInterface.llShippingPartialPalletRackingSH.Enabled = False
        MainInterface.llRackingUtilitySH.Enabled = False
        MainInterface.llViewConsignmentShippingSH.Enabled = False
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = False
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = False
        MainInterface.llViewRackActivitySH.Enabled = False
        MainInterface.llViewPickRackingSH.Enabled = False
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesCBS()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = False
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = False
        MainInterface.llConsignmentBillingGI.Enabled = False
        MainInterface.llConsignmentAdjustmentsGI.Enabled = False
        MainInterface.llConsignmentReturnsGI.Enabled = False

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = False
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = False
        MainInterface.llConsignmentAdjustmentIV.Enabled = False
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = False
        MainInterface.llViewConsignmentBillingSO.Enabled = False
        MainInterface.llViewConsignmentReturnsSO.Enabled = False
        MainInterface.llViewConsignmentShippingSO.Enabled = False
        MainInterface.llConsignmentStockStatusSO.Enabled = False
        MainInterface.llConsignmentTotalsSO.Enabled = False
        MainInterface.llCanamSalesReportSO.Enabled = False

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = False
        MainInterface.llViewSteelPOsPO.Enabled = False

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = False
        MainInterface.llViewFOXListingPM.Enabled = False
        MainInterface.llTimeSlipMenuPM.Enabled = False
        MainInterface.llTimeSlipPostingPM.Enabled = False
        MainInterface.llViewTimeSlipPostingsPM.Enabled = False
        MainInterface.llMaintainMachineDataPM.Enabled = False
        MainInterface.llProductionSchedulingPM.Enabled = False
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = False
        MainInterface.llViewLeadTimesPM.Enabled = False
        MainInterface.llViewSteelListPM.Enabled = False
        MainInterface.llViewSteelCoilsPM.Enabled = False
        MainInterface.llSteelConsumptionPM.Enabled = False
        MainInterface.llProductionTotalsPM.Enabled = False
        MainInterface.llProductionGraphingPM.Enabled = False

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = False
        MainInterface.llViewAssemblyListingPM.Enabled = False
        MainInterface.llViewSerializedLogPM.Enabled = False
        MainInterface.llViewBuildListingPM.Enabled = False
        MainInterface.llViewFOXWIPPM.Enabled = False
        MainInterface.llViewFOXStepCostingPM.Enabled = False
        MainInterface.llHeaderSetupSheetPM.Enabled = False
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = False
        MainInterface.llViewBlueprintsPM.Enabled = False
        MainInterface.llViewTimeSlipRosterPM.Enabled = False
        MainInterface.llViewAllTimeSlipsPM.Enabled = False

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = False
        MainInterface.llWIPCoilInventoryPM.Enabled = False
        MainInterface.llProductionInventoryTubsPM.Enabled = False

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = False
        MainInterface.llShippingPartialPalletRackingSH.Enabled = False
        MainInterface.llRackingUtilitySH.Enabled = False
        MainInterface.llViewConsignmentShippingSH.Enabled = False
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = False
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = False
        MainInterface.llViewRackActivitySH.Enabled = False
        MainInterface.llViewPickRackingSH.Enabled = False
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesCGO()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = False
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = False
        MainInterface.llConsignmentBillingGI.Enabled = False
        MainInterface.llConsignmentAdjustmentsGI.Enabled = False
        MainInterface.llConsignmentReturnsGI.Enabled = False

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = False
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = False
        MainInterface.llConsignmentAdjustmentIV.Enabled = False
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = False
        MainInterface.llViewConsignmentBillingSO.Enabled = False
        MainInterface.llViewConsignmentReturnsSO.Enabled = False
        MainInterface.llViewConsignmentShippingSO.Enabled = False
        MainInterface.llConsignmentStockStatusSO.Enabled = False
        MainInterface.llConsignmentTotalsSO.Enabled = False
        MainInterface.llCanamSalesReportSO.Enabled = False

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = False
        MainInterface.llViewSteelPOsPO.Enabled = False

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = False
        MainInterface.llViewFOXListingPM.Enabled = False
        MainInterface.llTimeSlipMenuPM.Enabled = False
        MainInterface.llTimeSlipPostingPM.Enabled = False
        MainInterface.llViewTimeSlipPostingsPM.Enabled = False
        MainInterface.llMaintainMachineDataPM.Enabled = False
        MainInterface.llProductionSchedulingPM.Enabled = False
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = False
        MainInterface.llViewLeadTimesPM.Enabled = False
        MainInterface.llViewSteelListPM.Enabled = False
        MainInterface.llViewSteelCoilsPM.Enabled = False
        MainInterface.llSteelConsumptionPM.Enabled = False
        MainInterface.llProductionTotalsPM.Enabled = False
        MainInterface.llProductionGraphingPM.Enabled = False

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = False
        MainInterface.llViewAssemblyListingPM.Enabled = False
        MainInterface.llViewSerializedLogPM.Enabled = False
        MainInterface.llViewBuildListingPM.Enabled = False
        MainInterface.llViewFOXWIPPM.Enabled = False
        MainInterface.llViewFOXStepCostingPM.Enabled = False
        MainInterface.llHeaderSetupSheetPM.Enabled = False
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = False
        MainInterface.llViewBlueprintsPM.Enabled = False
        MainInterface.llViewTimeSlipRosterPM.Enabled = False
        MainInterface.llViewAllTimeSlipsPM.Enabled = False

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = False
        MainInterface.llWIPCoilInventoryPM.Enabled = False
        MainInterface.llProductionInventoryTubsPM.Enabled = False

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = False
        MainInterface.llShippingPartialPalletRackingSH.Enabled = False
        MainInterface.llRackingUtilitySH.Enabled = False
        MainInterface.llViewConsignmentShippingSH.Enabled = False
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = False
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = False
        MainInterface.llViewRackActivitySH.Enabled = False
        MainInterface.llViewPickRackingSH.Enabled = False
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesCHT()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = True
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = False
        MainInterface.llConsignmentBillingGI.Enabled = False
        MainInterface.llConsignmentAdjustmentsGI.Enabled = False
        MainInterface.llConsignmentReturnsGI.Enabled = False

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = False
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = False
        MainInterface.llConsignmentAdjustmentIV.Enabled = False
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = False
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = False
        MainInterface.llViewAssemblySerialLogIV.Enabled = False
        MainInterface.llViewAssemblyHeadersIV.Enabled = False
        MainInterface.llViewAssemblyLinesIV.Enabled = False
        MainInterface.llViewAssemblyBuildListingIV.Enabled = False
        MainInterface.llViewBuildLinesIV.Enabled = False
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = True
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = False
        MainInterface.llViewConsignmentBillingSO.Enabled = False
        MainInterface.llViewConsignmentReturnsSO.Enabled = False
        MainInterface.llViewConsignmentShippingSO.Enabled = False
        MainInterface.llConsignmentStockStatusSO.Enabled = False
        MainInterface.llConsignmentTotalsSO.Enabled = False
        MainInterface.llCanamSalesReportSO.Enabled = False

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = False
        MainInterface.llViewSteelPOsPO.Enabled = False

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = False
        MainInterface.llViewFOXListingPM.Enabled = False
        MainInterface.llTimeSlipMenuPM.Enabled = False
        MainInterface.llTimeSlipPostingPM.Enabled = False
        MainInterface.llViewTimeSlipPostingsPM.Enabled = False
        MainInterface.llMaintainMachineDataPM.Enabled = False
        MainInterface.llProductionSchedulingPM.Enabled = False
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = False
        MainInterface.llViewLeadTimesPM.Enabled = False
        MainInterface.llViewSteelListPM.Enabled = False
        MainInterface.llViewSteelCoilsPM.Enabled = False
        MainInterface.llSteelConsumptionPM.Enabled = False
        MainInterface.llProductionTotalsPM.Enabled = False
        MainInterface.llProductionGraphingPM.Enabled = False

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = True
        MainInterface.llViewWCProductionPM.Enabled = True
        MainInterface.llFerruleProductionSchedulingPM.Enabled = True
        MainInterface.llAssemblyProgramPM.Enabled = False
        MainInterface.llViewAssemblyListingPM.Enabled = False
        MainInterface.llViewSerializedLogPM.Enabled = False
        MainInterface.llViewBuildListingPM.Enabled = False
        MainInterface.llViewFOXWIPPM.Enabled = False
        MainInterface.llViewFOXStepCostingPM.Enabled = False
        MainInterface.llHeaderSetupSheetPM.Enabled = False
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = False
        MainInterface.llViewBlueprintsPM.Enabled = False
        MainInterface.llViewTimeSlipRosterPM.Enabled = False
        MainInterface.llViewAllTimeSlipsPM.Enabled = False

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = True
        MainInterface.llWIPCoilInventoryPM.Enabled = False
        MainInterface.llProductionInventoryTubsPM.Enabled = False
      
        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = False
        MainInterface.llShippingPartialPalletRackingSH.Enabled = False
        MainInterface.llRackingUtilitySH.Enabled = False
        MainInterface.llViewConsignmentShippingSH.Enabled = False
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = False
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = False
        MainInterface.llViewRackActivitySH.Enabled = False
        MainInterface.llViewPickRackingSH.Enabled = False
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesDEN()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = False
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = False
        MainInterface.llConsignmentBillingGI.Enabled = False
        MainInterface.llConsignmentAdjustmentsGI.Enabled = False
        MainInterface.llConsignmentReturnsGI.Enabled = False

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = False
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = False
        MainInterface.llConsignmentAdjustmentIV.Enabled = False
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = False
        MainInterface.llViewConsignmentBillingSO.Enabled = False
        MainInterface.llViewConsignmentReturnsSO.Enabled = False
        MainInterface.llViewConsignmentShippingSO.Enabled = False
        MainInterface.llConsignmentStockStatusSO.Enabled = False
        MainInterface.llConsignmentTotalsSO.Enabled = False
        MainInterface.llCanamSalesReportSO.Enabled = False

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = False
        MainInterface.llViewSteelPOsPO.Enabled = False

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = False
        MainInterface.llViewFOXListingPM.Enabled = False
        MainInterface.llTimeSlipMenuPM.Enabled = False
        MainInterface.llTimeSlipPostingPM.Enabled = False
        MainInterface.llViewTimeSlipPostingsPM.Enabled = False
        MainInterface.llMaintainMachineDataPM.Enabled = False
        MainInterface.llProductionSchedulingPM.Enabled = False
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = False
        MainInterface.llViewLeadTimesPM.Enabled = False
        MainInterface.llViewSteelListPM.Enabled = False
        MainInterface.llViewSteelCoilsPM.Enabled = False
        MainInterface.llSteelConsumptionPM.Enabled = False
        MainInterface.llProductionTotalsPM.Enabled = False
        MainInterface.llProductionGraphingPM.Enabled = False

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = False
        MainInterface.llViewAssemblyListingPM.Enabled = False
        MainInterface.llViewSerializedLogPM.Enabled = False
        MainInterface.llViewBuildListingPM.Enabled = False
        MainInterface.llViewFOXWIPPM.Enabled = False
        MainInterface.llViewFOXStepCostingPM.Enabled = False
        MainInterface.llHeaderSetupSheetPM.Enabled = False
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = False
        MainInterface.llViewBlueprintsPM.Enabled = False
        MainInterface.llViewTimeSlipRosterPM.Enabled = False
        MainInterface.llViewAllTimeSlipsPM.Enabled = False

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = False
        MainInterface.llWIPCoilInventoryPM.Enabled = False
        MainInterface.llProductionInventoryTubsPM.Enabled = False

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = False
        MainInterface.llShippingPartialPalletRackingSH.Enabled = False
        MainInterface.llRackingUtilitySH.Enabled = False
        MainInterface.llViewConsignmentShippingSH.Enabled = False
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = False
        MainInterface.llViewRackActivitySH.Enabled = False
        MainInterface.llViewPickRackingSH.Enabled = False
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesHOU()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = False
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = False
        MainInterface.llConsignmentBillingGI.Enabled = False
        MainInterface.llConsignmentAdjustmentsGI.Enabled = False
        MainInterface.llConsignmentReturnsGI.Enabled = False

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = False
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = False
        MainInterface.llConsignmentAdjustmentIV.Enabled = False
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = False
        MainInterface.llViewConsignmentBillingSO.Enabled = False
        MainInterface.llViewConsignmentReturnsSO.Enabled = False
        MainInterface.llViewConsignmentShippingSO.Enabled = False
        MainInterface.llConsignmentStockStatusSO.Enabled = False
        MainInterface.llConsignmentTotalsSO.Enabled = False
        MainInterface.llCanamSalesReportSO.Enabled = False

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = False
        MainInterface.llViewSteelPOsPO.Enabled = False

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = False
        MainInterface.llViewFOXListingPM.Enabled = False
        MainInterface.llTimeSlipMenuPM.Enabled = False
        MainInterface.llTimeSlipPostingPM.Enabled = False
        MainInterface.llViewTimeSlipPostingsPM.Enabled = False
        MainInterface.llMaintainMachineDataPM.Enabled = False
        MainInterface.llProductionSchedulingPM.Enabled = False
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = False
        MainInterface.llViewLeadTimesPM.Enabled = False
        MainInterface.llViewSteelListPM.Enabled = False
        MainInterface.llViewSteelCoilsPM.Enabled = False
        MainInterface.llSteelConsumptionPM.Enabled = False
        MainInterface.llProductionTotalsPM.Enabled = False
        MainInterface.llProductionGraphingPM.Enabled = False

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = False
        MainInterface.llViewAssemblyListingPM.Enabled = False
        MainInterface.llViewSerializedLogPM.Enabled = False
        MainInterface.llViewBuildListingPM.Enabled = False
        MainInterface.llViewFOXWIPPM.Enabled = False
        MainInterface.llViewFOXStepCostingPM.Enabled = False
        MainInterface.llHeaderSetupSheetPM.Enabled = False
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = False
        MainInterface.llViewBlueprintsPM.Enabled = False
        MainInterface.llViewTimeSlipRosterPM.Enabled = False
        MainInterface.llViewAllTimeSlipsPM.Enabled = False

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = False
        MainInterface.llWIPCoilInventoryPM.Enabled = False
        MainInterface.llProductionInventoryTubsPM.Enabled = False

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = False
        MainInterface.llShippingPartialPalletRackingSH.Enabled = False
        MainInterface.llRackingUtilitySH.Enabled = False
        MainInterface.llViewConsignmentShippingSH.Enabled = False
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = False
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = False
        MainInterface.llViewRackActivitySH.Enabled = False
        MainInterface.llViewPickRackingSH.Enabled = False
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesSLC()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = False
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = False
        MainInterface.llConsignmentBillingGI.Enabled = False
        MainInterface.llConsignmentAdjustmentsGI.Enabled = False
        MainInterface.llConsignmentReturnsGI.Enabled = False

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = False
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = False
        MainInterface.llConsignmentAdjustmentIV.Enabled = False
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = True
        MainInterface.llInventoryRackingIV.Enabled = True
        MainInterface.llViewRackActivityIV.Enabled = True
        MainInterface.llViewRackingReportIV.Enabled = True
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = True
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = True
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = True
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = False
        MainInterface.llViewConsignmentBillingSO.Enabled = False
        MainInterface.llViewConsignmentReturnsSO.Enabled = False
        MainInterface.llViewConsignmentShippingSO.Enabled = False
        MainInterface.llConsignmentStockStatusSO.Enabled = False
        MainInterface.llConsignmentTotalsSO.Enabled = False
        MainInterface.llCanamSalesReportSO.Enabled = False

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = False
        MainInterface.llViewSteelPOsPO.Enabled = False

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = False
        MainInterface.llViewFOXListingPM.Enabled = False
        MainInterface.llTimeSlipMenuPM.Enabled = False
        MainInterface.llTimeSlipPostingPM.Enabled = False
        MainInterface.llViewTimeSlipPostingsPM.Enabled = False
        MainInterface.llMaintainMachineDataPM.Enabled = False
        MainInterface.llProductionSchedulingPM.Enabled = False
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = False
        MainInterface.llViewLeadTimesPM.Enabled = False
        MainInterface.llViewSteelListPM.Enabled = False
        MainInterface.llViewSteelCoilsPM.Enabled = False
        MainInterface.llSteelConsumptionPM.Enabled = False
        MainInterface.llProductionTotalsPM.Enabled = False
        MainInterface.llProductionGraphingPM.Enabled = False

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = False
        MainInterface.llViewAssemblyListingPM.Enabled = False
        MainInterface.llViewSerializedLogPM.Enabled = False
        MainInterface.llViewBuildListingPM.Enabled = False
        MainInterface.llViewFOXWIPPM.Enabled = False
        MainInterface.llViewFOXStepCostingPM.Enabled = False
        MainInterface.llHeaderSetupSheetPM.Enabled = False
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = False
        MainInterface.llViewBlueprintsPM.Enabled = False
        MainInterface.llViewTimeSlipRosterPM.Enabled = False
        MainInterface.llViewAllTimeSlipsPM.Enabled = False

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = False
        MainInterface.llWIPCoilInventoryPM.Enabled = False
        MainInterface.llProductionInventoryTubsPM.Enabled = False

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = True
        MainInterface.llShippingPartialPalletRackingSH.Enabled = True
        MainInterface.llRackingUtilitySH.Enabled = True
        MainInterface.llViewConsignmentShippingSH.Enabled = False
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = True
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = True
        MainInterface.llRackingTabletSH.Enabled = True
        MainInterface.llViewRackActivitySH.Enabled = True
        MainInterface.llViewPickRackingSH.Enabled = True
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesTFF()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = False
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = True
        MainInterface.llConsignmentBillingGI.Enabled = True
        MainInterface.llConsignmentAdjustmentsGI.Enabled = True
        MainInterface.llConsignmentReturnsGI.Enabled = True

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = True
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = True
        MainInterface.llConsignmentAdjustmentIV.Enabled = True
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = True
        MainInterface.llViewConsignmentBillingSO.Enabled = True
        MainInterface.llViewConsignmentReturnsSO.Enabled = True
        MainInterface.llViewConsignmentShippingSO.Enabled = True
        MainInterface.llConsignmentStockStatusSO.Enabled = True
        MainInterface.llConsignmentTotalsSO.Enabled = True
        MainInterface.llCanamSalesReportSO.Enabled = False

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = False
        MainInterface.llViewSteelPOsPO.Enabled = False

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = False
        MainInterface.llViewFOXListingPM.Enabled = False
        MainInterface.llTimeSlipMenuPM.Enabled = False
        MainInterface.llTimeSlipPostingPM.Enabled = False
        MainInterface.llViewTimeSlipPostingsPM.Enabled = False
        MainInterface.llMaintainMachineDataPM.Enabled = False
        MainInterface.llProductionSchedulingPM.Enabled = False
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = False
        MainInterface.llViewLeadTimesPM.Enabled = False
        MainInterface.llViewSteelListPM.Enabled = False
        MainInterface.llViewSteelCoilsPM.Enabled = False
        MainInterface.llSteelConsumptionPM.Enabled = False
        MainInterface.llProductionTotalsPM.Enabled = False
        MainInterface.llProductionGraphingPM.Enabled = False

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = False
        MainInterface.llViewAssemblyListingPM.Enabled = False
        MainInterface.llViewSerializedLogPM.Enabled = False
        MainInterface.llViewBuildListingPM.Enabled = False
        MainInterface.llViewFOXWIPPM.Enabled = False
        MainInterface.llViewFOXStepCostingPM.Enabled = False
        MainInterface.llHeaderSetupSheetPM.Enabled = False
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = False
        MainInterface.llViewBlueprintsPM.Enabled = False
        MainInterface.llViewTimeSlipRosterPM.Enabled = False
        MainInterface.llViewAllTimeSlipsPM.Enabled = False

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = False
        MainInterface.llWIPCoilInventoryPM.Enabled = False
        MainInterface.llProductionInventoryTubsPM.Enabled = False

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = False
        MainInterface.llShippingPartialPalletRackingSH.Enabled = False
        MainInterface.llRackingUtilitySH.Enabled = False
        MainInterface.llViewConsignmentShippingSH.Enabled = False
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = False
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = False
        MainInterface.llViewRackActivitySH.Enabled = False
        MainInterface.llViewPickRackingSH.Enabled = False
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu

        'A/P is locked for all divisions except TWD

        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesTFJ()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = False
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = False
        MainInterface.llConsignmentBillingGI.Enabled = False
        MainInterface.llConsignmentAdjustmentsGI.Enabled = False
        MainInterface.llConsignmentReturnsGI.Enabled = False

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = False
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = False
        MainInterface.llConsignmentAdjustmentIV.Enabled = False
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = False
        MainInterface.llViewConsignmentBillingSO.Enabled = False
        MainInterface.llViewConsignmentReturnsSO.Enabled = False
        MainInterface.llViewConsignmentShippingSO.Enabled = False
        MainInterface.llConsignmentStockStatusSO.Enabled = False
        MainInterface.llConsignmentTotalsSO.Enabled = False
        MainInterface.llCanamSalesReportSO.Enabled = False

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = False
        MainInterface.llViewSteelPOsPO.Enabled = False

        '***************************************************************************
        'Lock links in Production Menu

        'Production is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = False
        MainInterface.llShippingPartialPalletRackingSH.Enabled = False
        MainInterface.llRackingUtilitySH.Enabled = False
        MainInterface.llViewConsignmentShippingSH.Enabled = False
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = False
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = False
        MainInterface.llViewRackActivitySH.Enabled = False
        MainInterface.llViewPickRackingSH.Enabled = False
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesTFP()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = True
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = True
        MainInterface.cmdRawMaterialsMenu.Enabled = True
        MainInterface.cmdTruFitModule.Enabled = True
        MainInterface.cmdQualityControlMenu.Enabled = True
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = True
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = True
        MainInterface.llViewFOXListingGI.Enabled = True
        MainInterface.llViewSteelListGI.Enabled = True
        MainInterface.llViewHeatNumbersGI.Enabled = True
        MainInterface.llConsignmentShippingGI.Enabled = True
        MainInterface.llConsignmentBillingGI.Enabled = True
        MainInterface.llConsignmentAdjustmentsGI.Enabled = True
        MainInterface.llConsignmentReturnsGI.Enabled = True

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = True
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = True
        MainInterface.llDiscrepancyReportRP.Enabled = True

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = True
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = True
        MainInterface.llViewConsignmentInventoryIV.Enabled = True
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = True
        MainInterface.llConsignmentAdjustmentIV.Enabled = True
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = True
        MainInterface.llInventoryRackingIV.Enabled = True
        MainInterface.llViewRackActivityIV.Enabled = True
        MainInterface.llViewRackingReportIV.Enabled = True
        MainInterface.llDiscreptancyReportIV.Enabled = True
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = True
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = True
        MainInterface.llMaintenanceRackingIV.Enabled = True

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = True
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = True
        MainInterface.llViewConsignmentBillingSO.Enabled = True
        MainInterface.llViewConsignmentReturnsSO.Enabled = True
        MainInterface.llViewConsignmentShippingSO.Enabled = True
        MainInterface.llConsignmentStockStatusSO.Enabled = True
        MainInterface.llConsignmentTotalsSO.Enabled = True
        MainInterface.llCanamSalesReportSO.Enabled = True

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = True
        MainInterface.llViewSteelPOsPO.Enabled = True

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = True
        MainInterface.llViewFOXListingPM.Enabled = True
        MainInterface.llTimeSlipMenuPM.Enabled = True
        MainInterface.llTimeSlipPostingPM.Enabled = True
        MainInterface.llViewTimeSlipPostingsPM.Enabled = True
        MainInterface.llMaintainMachineDataPM.Enabled = True
        MainInterface.llProductionSchedulingPM.Enabled = True
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = True
        MainInterface.llViewLeadTimesPM.Enabled = True
        MainInterface.llViewSteelListPM.Enabled = True
        MainInterface.llViewSteelCoilsPM.Enabled = True
        MainInterface.llSteelConsumptionPM.Enabled = True
        MainInterface.llProductionTotalsPM.Enabled = True
        MainInterface.llProductionGraphingPM.Enabled = True

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = True
        MainInterface.llViewAssemblyListingPM.Enabled = True
        MainInterface.llViewSerializedLogPM.Enabled = True
        MainInterface.llViewBuildListingPM.Enabled = True
        MainInterface.llViewFOXWIPPM.Enabled = True
        MainInterface.llViewFOXStepCostingPM.Enabled = True
        MainInterface.llHeaderSetupSheetPM.Enabled = True
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = True
        MainInterface.llViewBlueprintsPM.Enabled = True
        MainInterface.llViewTimeSlipRosterPM.Enabled = True
        MainInterface.llViewAllTimeSlipsPM.Enabled = True

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = True
        MainInterface.llWIPCoilInventoryPM.Enabled = True
        MainInterface.llProductionInventoryTubsPM.Enabled = True

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = True
        MainInterface.llShippingPartialPalletRackingSH.Enabled = True
        MainInterface.llRackingUtilitySH.Enabled = True
        MainInterface.llViewConsignmentShippingSH.Enabled = True
        MainInterface.llViewReleaseScheduleSH.Enabled = True
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = True
        MainInterface.llViewSteelBOLsSH.Enabled = True
        MainInterface.llViewEditTrufitCertsSH.Enabled = True
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = True
        MainInterface.llViewRackActivitySH.Enabled = True
        MainInterface.llViewPickRackingSH.Enabled = True
        MainInterface.llCertErrorLogSH.Enabled = True
        MainInterface.llViewSDSSH.Enabled = True

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesTFT()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = False
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = False
        MainInterface.llConsignmentBillingGI.Enabled = False
        MainInterface.llConsignmentAdjustmentsGI.Enabled = False
        MainInterface.llConsignmentReturnsGI.Enabled = False

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = False
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = False
        MainInterface.llConsignmentAdjustmentIV.Enabled = False
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = False
        MainInterface.llViewConsignmentBillingSO.Enabled = False
        MainInterface.llViewConsignmentReturnsSO.Enabled = False
        MainInterface.llViewConsignmentShippingSO.Enabled = False
        MainInterface.llConsignmentStockStatusSO.Enabled = False
        MainInterface.llConsignmentTotalsSO.Enabled = False
        MainInterface.llCanamSalesReportSO.Enabled = False

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = False
        MainInterface.llViewSteelPOsPO.Enabled = False

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = False
        MainInterface.llViewFOXListingPM.Enabled = False
        MainInterface.llTimeSlipMenuPM.Enabled = False
        MainInterface.llTimeSlipPostingPM.Enabled = False
        MainInterface.llViewTimeSlipPostingsPM.Enabled = False
        MainInterface.llMaintainMachineDataPM.Enabled = False
        MainInterface.llProductionSchedulingPM.Enabled = False
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = False
        MainInterface.llViewLeadTimesPM.Enabled = False
        MainInterface.llViewSteelListPM.Enabled = False
        MainInterface.llViewSteelCoilsPM.Enabled = False
        MainInterface.llSteelConsumptionPM.Enabled = False
        MainInterface.llProductionTotalsPM.Enabled = False
        MainInterface.llProductionGraphingPM.Enabled = False

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = False
        MainInterface.llViewAssemblyListingPM.Enabled = False
        MainInterface.llViewSerializedLogPM.Enabled = False
        MainInterface.llViewBuildListingPM.Enabled = False
        MainInterface.llViewFOXWIPPM.Enabled = False
        MainInterface.llViewFOXStepCostingPM.Enabled = False
        MainInterface.llHeaderSetupSheetPM.Enabled = False
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = False
        MainInterface.llViewBlueprintsPM.Enabled = False
        MainInterface.llViewTimeSlipRosterPM.Enabled = False
        MainInterface.llViewAllTimeSlipsPM.Enabled = False

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = False
        MainInterface.llWIPCoilInventoryPM.Enabled = False
        MainInterface.llProductionInventoryTubsPM.Enabled = False

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = False
        MainInterface.llShippingPartialPalletRackingSH.Enabled = False
        MainInterface.llRackingUtilitySH.Enabled = False
        MainInterface.llViewConsignmentShippingSH.Enabled = False
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = False
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = False
        MainInterface.llViewRackActivitySH.Enabled = False
        MainInterface.llViewPickRackingSH.Enabled = False
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesTOR()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = False
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = False
        MainInterface.llConsignmentBillingGI.Enabled = False
        MainInterface.llConsignmentAdjustmentsGI.Enabled = False
        MainInterface.llConsignmentReturnsGI.Enabled = False

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = False
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = False
        MainInterface.llConsignmentAdjustmentIV.Enabled = False
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = False
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = False
        MainInterface.llViewConsignmentBillingSO.Enabled = False
        MainInterface.llViewConsignmentReturnsSO.Enabled = False
        MainInterface.llViewConsignmentShippingSO.Enabled = False
        MainInterface.llConsignmentStockStatusSO.Enabled = False
        MainInterface.llConsignmentTotalsSO.Enabled = False
        MainInterface.llCanamSalesReportSO.Enabled = True

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = False
        MainInterface.llViewSteelPOsPO.Enabled = False

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = False
        MainInterface.llViewFOXListingPM.Enabled = False
        MainInterface.llTimeSlipMenuPM.Enabled = False
        MainInterface.llTimeSlipPostingPM.Enabled = False
        MainInterface.llViewTimeSlipPostingsPM.Enabled = False
        MainInterface.llMaintainMachineDataPM.Enabled = False
        MainInterface.llProductionSchedulingPM.Enabled = False
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = False
        MainInterface.llViewLeadTimesPM.Enabled = False
        MainInterface.llViewSteelListPM.Enabled = False
        MainInterface.llViewSteelCoilsPM.Enabled = False
        MainInterface.llSteelConsumptionPM.Enabled = False
        MainInterface.llProductionTotalsPM.Enabled = False
        MainInterface.llProductionGraphingPM.Enabled = False

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = False
        MainInterface.llViewAssemblyListingPM.Enabled = False
        MainInterface.llViewSerializedLogPM.Enabled = False
        MainInterface.llViewBuildListingPM.Enabled = False
        MainInterface.llViewFOXWIPPM.Enabled = False
        MainInterface.llViewFOXStepCostingPM.Enabled = False
        MainInterface.llHeaderSetupSheetPM.Enabled = False
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = False
        MainInterface.llViewBlueprintsPM.Enabled = False
        MainInterface.llViewTimeSlipRosterPM.Enabled = False
        MainInterface.llViewAllTimeSlipsPM.Enabled = False

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = False
        MainInterface.llWIPCoilInventoryPM.Enabled = False
        MainInterface.llProductionInventoryTubsPM.Enabled = False

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = False
        MainInterface.llShippingPartialPalletRackingSH.Enabled = False
        MainInterface.llRackingUtilitySH.Enabled = False
        MainInterface.llViewConsignmentShippingSH.Enabled = False
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = False
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = False
        MainInterface.llViewRackActivitySH.Enabled = False
        MainInterface.llViewPickRackingSH.Enabled = False
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesTST()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = True
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = True
        MainInterface.cmdRawMaterialsMenu.Enabled = True
        MainInterface.cmdTruFitModule.Enabled = True
        MainInterface.cmdQualityControlMenu.Enabled = True
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = True
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = True
        MainInterface.llViewFOXListingGI.Enabled = True
        MainInterface.llViewSteelListGI.Enabled = True
        MainInterface.llViewHeatNumbersGI.Enabled = True
        MainInterface.llConsignmentShippingGI.Enabled = True
        MainInterface.llConsignmentBillingGI.Enabled = True
        MainInterface.llConsignmentAdjustmentsGI.Enabled = True
        MainInterface.llConsignmentReturnsGI.Enabled = True

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = False
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = False
        MainInterface.llConsignmentAdjustmentIV.Enabled = False
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = False
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = True

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = True
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = True
        MainInterface.llViewConsignmentBillingSO.Enabled = True
        MainInterface.llViewConsignmentReturnsSO.Enabled = True
        MainInterface.llViewConsignmentShippingSO.Enabled = True
        MainInterface.llConsignmentStockStatusSO.Enabled = True
        MainInterface.llConsignmentTotalsSO.Enabled = True
        MainInterface.llCanamSalesReportSO.Enabled = True

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = True
        MainInterface.llViewSteelPOsPO.Enabled = True

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = True
        MainInterface.llViewFOXListingPM.Enabled = True
        MainInterface.llTimeSlipMenuPM.Enabled = True
        MainInterface.llTimeSlipPostingPM.Enabled = True
        MainInterface.llViewTimeSlipPostingsPM.Enabled = True
        MainInterface.llMaintainMachineDataPM.Enabled = True
        MainInterface.llProductionSchedulingPM.Enabled = True
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = True
        MainInterface.llViewLeadTimesPM.Enabled = True
        MainInterface.llViewSteelListPM.Enabled = True
        MainInterface.llViewSteelCoilsPM.Enabled = True
        MainInterface.llSteelConsumptionPM.Enabled = True
        MainInterface.llProductionTotalsPM.Enabled = True
        MainInterface.llProductionGraphingPM.Enabled = True

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = True
        MainInterface.llViewAssemblyListingPM.Enabled = True
        MainInterface.llViewSerializedLogPM.Enabled = True
        MainInterface.llViewBuildListingPM.Enabled = True
        MainInterface.llViewFOXWIPPM.Enabled = True
        MainInterface.llViewFOXStepCostingPM.Enabled = True
        MainInterface.llHeaderSetupSheetPM.Enabled = True
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = True
        MainInterface.llViewBlueprintsPM.Enabled = True
        MainInterface.llViewTimeSlipRosterPM.Enabled = True
        MainInterface.llViewAllTimeSlipsPM.Enabled = True

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = True
        MainInterface.llWIPCoilInventoryPM.Enabled = True
        MainInterface.llProductionInventoryTubsPM.Enabled = True

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = True
        MainInterface.llShippingPartialPalletRackingSH.Enabled = True
        MainInterface.llRackingUtilitySH.Enabled = True
        MainInterface.llViewConsignmentShippingSH.Enabled = True
        MainInterface.llViewReleaseScheduleSH.Enabled = True
        MainInterface.llViewSteelBOLsSH.Enabled = True
        MainInterface.llViewEditTrufitCertsSH.Enabled = True
        MainInterface.llSLCRackingSH.Enabled = True
        MainInterface.llRackingTabletSH.Enabled = True
        MainInterface.llViewRackActivitySH.Enabled = True
        MainInterface.llViewPickRackingSH.Enabled = True
        MainInterface.llCertErrorLogSH.Enabled = True
        MainInterface.llViewSDSSH.Enabled = True

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesTWD()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = True
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = True
        MainInterface.cmdRawMaterialsMenu.Enabled = True
        MainInterface.cmdTruFitModule.Enabled = True
        MainInterface.cmdQualityControlMenu.Enabled = True
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = True
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = True
        MainInterface.llViewFOXListingGI.Enabled = True
        MainInterface.llViewSteelListGI.Enabled = True
        MainInterface.llViewHeatNumbersGI.Enabled = True
        MainInterface.llConsignmentShippingGI.Enabled = True
        MainInterface.llConsignmentBillingGI.Enabled = True
        MainInterface.llConsignmentAdjustmentsGI.Enabled = True
        MainInterface.llConsignmentReturnsGI.Enabled = True

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = True
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = True
        MainInterface.llDiscrepancyReportRP.Enabled = True

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = True
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = True
        MainInterface.llViewConsignmentInventoryIV.Enabled = True
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = True
        MainInterface.llConsignmentAdjustmentIV.Enabled = True
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = True
        MainInterface.llInventoryRackingIV.Enabled = True
        MainInterface.llViewRackActivityIV.Enabled = True
        MainInterface.llViewRackingReportIV.Enabled = True
        MainInterface.llDiscreptancyReportIV.Enabled = True
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = False
        MainInterface.llBinPreferencesIV.Enabled = True
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = True
        MainInterface.llMaintenanceRackingIV.Enabled = True

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = True
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = True
        MainInterface.llViewConsignmentBillingSO.Enabled = True
        MainInterface.llViewConsignmentReturnsSO.Enabled = True
        MainInterface.llViewConsignmentShippingSO.Enabled = True
        MainInterface.llConsignmentStockStatusSO.Enabled = True
        MainInterface.llConsignmentTotalsSO.Enabled = True
        MainInterface.llCanamSalesReportSO.Enabled = True

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = True
        MainInterface.llViewSteelPOsPO.Enabled = True

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = True
        MainInterface.llViewFOXListingPM.Enabled = True
        MainInterface.llTimeSlipMenuPM.Enabled = True
        MainInterface.llTimeSlipPostingPM.Enabled = True
        MainInterface.llViewTimeSlipPostingsPM.Enabled = True
        MainInterface.llMaintainMachineDataPM.Enabled = True
        MainInterface.llProductionSchedulingPM.Enabled = True
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = True
        MainInterface.llViewLeadTimesPM.Enabled = True
        MainInterface.llViewSteelListPM.Enabled = True
        MainInterface.llViewSteelCoilsPM.Enabled = True
        MainInterface.llSteelConsumptionPM.Enabled = True
        MainInterface.llProductionTotalsPM.Enabled = True
        MainInterface.llProductionGraphingPM.Enabled = True

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = True
        MainInterface.llViewAssemblyListingPM.Enabled = True
        MainInterface.llViewSerializedLogPM.Enabled = True
        MainInterface.llViewBuildListingPM.Enabled = True
        MainInterface.llViewFOXWIPPM.Enabled = True
        MainInterface.llViewFOXStepCostingPM.Enabled = True
        MainInterface.llHeaderSetupSheetPM.Enabled = True
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = True
        MainInterface.llViewBlueprintsPM.Enabled = True
        MainInterface.llViewTimeSlipRosterPM.Enabled = True
        MainInterface.llViewAllTimeSlipsPM.Enabled = True

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = True
        MainInterface.llWIPCoilInventoryPM.Enabled = True
        MainInterface.llProductionInventoryTubsPM.Enabled = True

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = True
        MainInterface.llShippingPartialPalletRackingSH.Enabled = True
        MainInterface.llRackingUtilitySH.Enabled = True
        MainInterface.llViewConsignmentShippingSH.Enabled = True
        MainInterface.llViewReleaseScheduleSH.Enabled = True
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = True
        MainInterface.llViewSteelBOLsSH.Enabled = True
        MainInterface.llViewEditTrufitCertsSH.Enabled = True
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = True
        MainInterface.llViewRackActivitySH.Enabled = True
        MainInterface.llViewPickRackingSH.Enabled = True
        MainInterface.llCertErrorLogSH.Enabled = True
        MainInterface.llViewSDSSH.Enabled = True

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = True
        MainInterface.llPaymentReversalAR.Enabled = True
        MainInterface.llViewEditCustomerPaymentAR.Enabled = True
        MainInterface.llBankTransactionsAR.Enabled = True
        MainInterface.llViewCashReceiptsAR.Enabled = True
        MainInterface.llViewCustomerPaymentsAR.Enabled = True
        MainInterface.llViewTFCertsAR.Enabled = True

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

    Public Function SecurityPreferencesTWE()
        'Lock Category Buttons for each module
        MainInterface.cmdAPMenu.Enabled = False
        MainInterface.cmdARMenu.Enabled = True
        MainInterface.cmdComputerToolsMenu.Enabled = False
        MainInterface.cmdFactoryOrderMenu.Enabled = False
        MainInterface.cmdGeneralInfo.Enabled = True
        MainInterface.cmdInventoryMenu.Enabled = True
        MainInterface.cmdProductionMenu.Enabled = False
        MainInterface.cmdRawMaterialsMenu.Enabled = False
        MainInterface.cmdTruFitModule.Enabled = False
        MainInterface.cmdQualityControlMenu.Enabled = False
        MainInterface.cmdShippingMenu.Enabled = True
        MainInterface.cmdPurchaseOrderMenu.Enabled = True
        MainInterface.cmdSalesOrderMenu.Enabled = True
        MainInterface.cmdTFPReports.Enabled = True
        MainInterface.cmdToolRoom.Enabled = False
        MainInterface.cmdChangeCompany.Enabled = True
        MainInterface.cmdExitProgram.Enabled = True

        '***************************************************************************
        'Lock links in General Information

        MainInterface.llCurrentAnnouncementsGI.Enabled = False
        MainInterface.llViewFOXListingGI.Enabled = False
        MainInterface.llViewSteelListGI.Enabled = False
        MainInterface.llViewHeatNumbersGI.Enabled = False
        MainInterface.llConsignmentShippingGI.Enabled = True
        MainInterface.llConsignmentBillingGI.Enabled = True
        MainInterface.llConsignmentAdjustmentsGI.Enabled = True
        MainInterface.llConsignmentReturnsGI.Enabled = True

        '***************************************************************************
        'Lock links in Accounting Menu

        'Accounting Menu is locked for all divisions
        'unlocked for specific security codes (1001, 1002)

        '***************************************************************************
        'Lock links in Raw Materials

        'Raw Materials is locked for all divisions except TWD, TWE, TFP, CHT

        '***************************************************************************
        'Lock links in Trufit Programs

        'Trufit Module is locked for all divisions except TWD, TFP

        '***************************************************************************
        'Lock links in TFP Reports

        MainInterface.pnlProductionReports.Enabled = False
        MainInterface.pnlGLReports.Enabled = False
        MainInterface.pnlQCReports.Enabled = False
        MainInterface.llDiscrepancyReportRP.Enabled = False

        '***************************************************************************
        'Lock links in Quality Control

        'QC is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Factory Order

        'FOX Menu is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
        'Lock links in Inventory Menu

        'First Column
        MainInterface.llItemMaintenanceFormIV.Enabled = True
        MainInterface.llMaintainNonInventoryItemsIV.Enabled = True
        MainInterface.llEditItemClassesIV.Enabled = False
        MainInterface.llFOXMaintenanceIV.Enabled = False
        MainInterface.llMaintainPriceSheetsIV.Enabled = True
        MainInterface.llMaintainPriceLevelsIV.Enabled = True
        MainInterface.llViewPriceBracketsIV.Enabled = True
        MainInterface.llMaintainMinMaxDataIV.Enabled = True
        MainInterface.llInventoryAdjustmentsIV.Enabled = True
        MainInterface.llViewInventoryAdjustmentsIV.Enabled = True
        MainInterface.llInventoryCostTiersIV.Enabled = True
        MainInterface.llViewInventoryTransactionsIV.Enabled = True
        MainInterface.llItemCostingReportIV.Enabled = True
        MainInterface.llViewLotNumberListingIV.Enabled = True

        'Second Column
        MainInterface.llViewItemListingIV.Enabled = True
        MainInterface.llViewStockStatusIV.Enabled = True
        MainInterface.llTFPStockStatusIV.Enabled = False
        MainInterface.llViewConsignmentInventoryIV.Enabled = True
        MainInterface.llConsignmentItemMaintenanceIV.Enabled = True
        MainInterface.llConsignmentAdjustmentIV.Enabled = True
        MainInterface.llCreateStudweldingCertIV.Enabled = True
        MainInterface.llSerialNumberQOHIV.Enabled = True
        MainInterface.llPartialPalletRackingIV.Enabled = False
        MainInterface.llInventoryRackingIV.Enabled = False
        MainInterface.llViewRackActivityIV.Enabled = False
        MainInterface.llViewRackingReportIV.Enabled = False
        MainInterface.llDiscreptancyReportIV.Enabled = False
        MainInterface.llViewInventoryValueByFilterIV.Enabled = True

        'Third Column
        MainInterface.llCreateAssembliesIV.Enabled = True
        MainInterface.llViewAssemblySerialLogIV.Enabled = True
        MainInterface.llViewAssemblyHeadersIV.Enabled = True
        MainInterface.llViewAssemblyLinesIV.Enabled = True
        MainInterface.llViewAssemblyBuildListingIV.Enabled = True
        MainInterface.llViewBuildLinesIV.Enabled = True
        MainInterface.llSLCRackingIV.Enabled = False
        MainInterface.llFerruleToolingIV.Enabled = False
        MainInterface.llEquipmentProductionIV.Enabled = True
        MainInterface.llBinPreferencesIV.Enabled = False
        MainInterface.llPrintPriceSheetsIV.Enabled = True
        MainInterface.llTabletRackingIV.Enabled = False
        MainInterface.llMaintenanceRackingIV.Enabled = False

        '***************************************************************************
        'Lock links in Sales Order Menu

        MainInterface.llViewCompanyTotalsSO.Enabled = True
        MainInterface.llViewConsignmentAdjustmentsSO.Enabled = True
        MainInterface.llViewConsignmentBillingSO.Enabled = True
        MainInterface.llViewConsignmentReturnsSO.Enabled = True
        MainInterface.llViewConsignmentShippingSO.Enabled = True
        MainInterface.llConsignmentStockStatusSO.Enabled = True
        MainInterface.llConsignmentTotalsSO.Enabled = True
        MainInterface.llCanamSalesReportSO.Enabled = True

        '***************************************************************************
        'Lock links in Purchase Order Menu

        MainInterface.llViewSteelSpecialOrdersPO.Enabled = True
        MainInterface.llViewSteelPOsPO.Enabled = True

        '***************************************************************************
        'Lock links in Production Menu

        'First Column Link Labels
        MainInterface.llFOXMenuPM.Enabled = False
        MainInterface.llViewFOXListingPM.Enabled = False
        MainInterface.llTimeSlipMenuPM.Enabled = False
        MainInterface.llTimeSlipPostingPM.Enabled = False
        MainInterface.llViewTimeSlipPostingsPM.Enabled = False
        MainInterface.llMaintainMachineDataPM.Enabled = False
        MainInterface.llProductionSchedulingPM.Enabled = False
        MainInterface.llViewFOXReleaseSchedulePM.Enabled = False
        MainInterface.llViewLeadTimesPM.Enabled = False
        MainInterface.llViewSteelListPM.Enabled = False
        MainInterface.llViewSteelCoilsPM.Enabled = False
        MainInterface.llSteelConsumptionPM.Enabled = False
        MainInterface.llProductionTotalsPM.Enabled = False
        MainInterface.llProductionGraphingPM.Enabled = False

        'Second Column Link Labels
        MainInterface.llEnterDailyProductionPM.Enabled = False
        MainInterface.llViewWCProductionPM.Enabled = False
        MainInterface.llFerruleProductionSchedulingPM.Enabled = False
        MainInterface.llAssemblyProgramPM.Enabled = True
        MainInterface.llViewAssemblyListingPM.Enabled = True
        MainInterface.llViewSerializedLogPM.Enabled = True
        MainInterface.llViewBuildListingPM.Enabled = True
        MainInterface.llViewFOXWIPPM.Enabled = False
        MainInterface.llViewFOXStepCostingPM.Enabled = False
        MainInterface.llHeaderSetupSheetPM.Enabled = False
        MainInterface.llViewHeaderSetupSheetsPM.Enabled = False
        MainInterface.llViewBlueprintsPM.Enabled = False
        MainInterface.llViewTimeSlipRosterPM.Enabled = False
        MainInterface.llViewAllTimeSlipsPM.Enabled = False

        'Third Column Link Labels
        MainInterface.llLabelProgramPM.Enabled = True
        MainInterface.llWIPCoilInventoryPM.Enabled = False
        MainInterface.llProductionInventoryTubsPM.Enabled = False

        '***************************************************************************
        'Lock links in Shipping Menu

        MainInterface.llInventoryRackingSH.Enabled = False
        MainInterface.llShippingPartialPalletRackingSH.Enabled = False
        MainInterface.llRackingUtilitySH.Enabled = False
        MainInterface.llViewConsignmentShippingSH.Enabled = True
        MainInterface.llViewReleaseScheduleSH.Enabled = False
        MainInterface.llViewPulledLinesOnPickListSH.Enabled = False
        MainInterface.llViewSteelBOLsSH.Enabled = False
        MainInterface.llViewEditTrufitCertsSH.Enabled = False
        MainInterface.llSLCRackingSH.Enabled = False
        MainInterface.llRackingTabletSH.Enabled = False
        MainInterface.llViewRackActivitySH.Enabled = False
        MainInterface.llViewPickRackingSH.Enabled = False
        MainInterface.llCertErrorLogSH.Enabled = False
        MainInterface.llViewSDSSH.Enabled = False

        '***************************************************************************
        'Lock links in A/R Menu

        MainInterface.llProcessCashReceiptsAR.Enabled = False
        MainInterface.llPaymentReversalAR.Enabled = False
        MainInterface.llViewEditCustomerPaymentAR.Enabled = False
        MainInterface.llBankTransactionsAR.Enabled = False
        MainInterface.llViewCashReceiptsAR.Enabled = False
        MainInterface.llViewCustomerPaymentsAR.Enabled = False
        MainInterface.llViewTFCertsAR.Enabled = False

        '***************************************************************************
        'Lock links in A/P Menu




        '***************************************************************************
        'Lock links in Tool Room

        'Tool Room is locked for all divisions except TFP, TWE, TWD

        '***************************************************************************
    End Function

End Module
