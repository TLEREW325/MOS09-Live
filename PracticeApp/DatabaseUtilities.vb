Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class DatabaseUtilities
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim DatagridDivision As String = ""
    Dim DatagridCustomer As String = ""
    Dim DatagridAddShipTo As String = ""
    Dim DatagridSONumber As Integer = 0
    Dim ShipName, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZipCode, ShipCountry As String
    Dim GetOldCarbon, GetOldSteelSize As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12, myAdapter13, myAdapter14, myAdapter15, myAdapter16, myAdapter17, myAdapter18, myAdapter19, myAdapter20, myAdapter21, myAdapter22, myAdapter23, myAdapter24, myAdapter25, myAdapter26, myAdapter27, myAdapter28, myAdapter29, myAdapter30, myAdapter31, myadapter32, myadapter33, myadapter34, myadapter35, myadapter36, myadapter37, myadapter38, myadapter39, myadapter40 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12, ds13, ds14, ds15, ds16, ds17, ds18, ds19, ds20, ds21, ds22, ds23, ds24, ds25, ds26, ds27, ds28, ds29, ds30, ds31, ds32, ds33, ds34, ds35, ds36, ds37, ds38, ds39, ds40 As DataSet
    Dim dt As DataTable

    Private Sub DatabaseUtilities_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Public Sub ShowARInvoiceBatch()
        cmd = New SqlCommand("SELECT * FROM InvoiceProcessingBatchHeader", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceProcessingBatchHeader")
        dgvARInvoiceBatch.DataSource = ds.Tables("InvoiceProcessingBatchHeader")
        con.Close()
    End Sub

    Public Sub ShowAPInvoiceBatch()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchHeader", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ReceiptOfInvoiceBatchHeader")
        dgvAPInvoiceBatch.DataSource = ds1.Tables("ReceiptOfInvoiceBatchHeader")
        con.Close()
    End Sub

    Public Sub ShowAPPaymentBatch()
        cmd = New SqlCommand("SELECT * FROM APProcessPaymentBatch", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "APProcessPaymentBatch")
        dgvAPPaymentBatch.DataSource = ds2.Tables("APProcessPaymentBatch")
        con.Close()
    End Sub

    Public Sub ShowARPaymentBatch()
        cmd = New SqlCommand("SELECT * FROM ARProcessPaymentBatch", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ARProcessPaymentBatch")
        dgvARPaymentBatch.DataSource = ds3.Tables("ARProcessPaymentBatch")
        con.Close()
    End Sub

    Public Sub ShowInvoiceCOS()
        cmd = New SqlCommand("SELECT * FROM InvoiceCompare WHERE InvoiceCOS <> SUMExtendedCOS", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "InvoiceCompare")
        dgvInvoiceCompare.DataSource = ds4.Tables("InvoiceCompare")
        con.Close()
    End Sub

    Public Sub ShowReceivers()
        cmd = New SqlCommand("SELECT * FROM ReceivingHeaderTable", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ReceivingHeaderTable")
        dgvReceivingHeaders.DataSource = ds5.Tables("ReceivingHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowErrorLog()
        cmd = New SqlCommand("SELECT * FROM TFPErrorLog", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "TFPErrorLog")
        dgvTFPErrorLog.DataSource = ds6.Tables("TFPErrorLog")
        con.Close()
    End Sub

    Public Sub ShowShipmentInvoice()
        cmd = New SqlCommand("SELECT * FROM InvoiceShipment WHERE InvoiceTotal <> ShipmentTotal", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "InvoiceShipment")
        dgvInvoiceShipment.DataSource = ds7.Tables("InvoiceShipment")
        con.Close()
    End Sub

    Public Sub ShowSalesOrders()
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE TotalEstCOS = '0'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "SalesOrderHeaderTable")
        dgvSOTable.DataSource = ds8.Tables("SalesOrderHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowShipments()
        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE ShipToName =''", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd
        myAdapter9.Fill(ds9, "ShipmentHeaderTable")
        dgvShipmentHeaderTable.DataSource = ds9.Tables("ShipmentHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowInvoiceShipmentCOS()
        cmd = New SqlCommand("SELECT * FROM InvoiceShipmentCOS WHERE EstExtendedCOS = @EstExtendedCOS ORDER BY SONumber", con)
        cmd.Parameters.Add("@EstExtendedCOS", SqlDbType.VarChar).Value = 0
        If con.State = ConnectionState.Closed Then con.Open()
        ds10 = New DataSet()
        myAdapter10.SelectCommand = cmd
        myAdapter10.Fill(ds10, "InvoiceShipmentCOS")
        dgvInvoiceShipCOS.DataSource = ds10.Tables("InvoiceShipmentCOS")
        con.Close()
    End Sub

    Public Sub ShowItemListStandard()
        cmd = New SqlCommand("SELECT * FROM ItemList WHERE StandardCost = @StandardCost AND DivisionID = @DivisionID AND ItemClass NOT LIKE @ItemClass", con)
        cmd.Parameters.Add("@StandardCost", SqlDbType.VarChar).Value = 0
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "SUPPLY%"
        If con.State = ConnectionState.Closed Then con.Open()
        ds11 = New DataSet()
        myAdapter11.SelectCommand = cmd
        myAdapter11.Fill(ds11, "ItemList")
        dgvItemList.DataSource = ds11.Tables("ItemList")
        con.Close()
    End Sub

    Public Sub ShowAssemblyCost()
        cmd = New SqlCommand("SELECT * FROM AssemblyHeaderTable", con)
        cmd.Parameters.Add("@TotalCost", SqlDbType.VarChar).Value = 0
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds12 = New DataSet()
        myAdapter12.SelectCommand = cmd
        myAdapter12.Fill(ds12, "AssemblyHeaderTable")
        dgvAssemblyTable.DataSource = ds12.Tables("AssemblyHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowAssemblyLines()
        cmd = New SqlCommand("SELECT * FROM AssemblyLineTable WHERE UnitCost = @UnitCost ORDER BY DivisionID, AssemblyPartNumber", con)
        cmd.Parameters.Add("@UnitCost", SqlDbType.VarChar).Value = 0
        If con.State = ConnectionState.Closed Then con.Open()
        ds13 = New DataSet()
        myAdapter13.SelectCommand = cmd
        myAdapter13.Fill(ds13, "AssemblyLineTable")
        dgvAssemblyLines.DataSource = ds13.Tables("AssemblyLineTable")
        con.Close()
    End Sub

    Public Sub ShowLotNumbers()
        cmd = New SqlCommand("SELECT * FROM LotNumber WHERE DivisionID = @DivisionID AND ShortDescription = @ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
        cmd.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = ""
        If con.State = ConnectionState.Closed Then con.Open()
        ds14 = New DataSet()
        myAdapter14.SelectCommand = cmd
        myAdapter14.Fill(ds14, "LotNumber")
        dgvLotNumberRMID.DataSource = ds14.Tables("LotNumber")
        con.Close()
    End Sub

    Public Sub ShowReturnHeaders()
        cmd = New SqlCommand("SELECT * FROM ReturnProductHeaderTable", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds17 = New DataSet()
        myAdapter17.SelectCommand = cmd
        myAdapter17.Fill(ds17, "ReturnProductHeaderTable")
        dgvReturnHeader.DataSource = ds17.Tables("ReturnProductHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowInvoiceHeaders()
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceStatus = @InvoiceStatus ", con)
        cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds18 = New DataSet()
        myAdapter18.SelectCommand = cmd
        myAdapter18.Fill(ds18, "InvoiceHeaderTable")
        dgvInvoiceHeaderTable.DataSource = ds18.Tables("InvoiceHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowPullTests()
        cmd = New SqlCommand("SELECT * FROM PullTestData", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds19 = New DataSet()
        myAdapter19.SelectCommand = cmd
        myAdapter19.Fill(ds19, "PullTestData")
        dgvPullTestData.DataSource = ds19.Tables("PullTestData")
        con.Close()
    End Sub

    Public Sub ShowLotsWORMID()
        cmd = New SqlCommand("SELECT * FROM LotNumber WHERE DivisionID = @DivisionID AND RMID = @RMID AND HeatNumberID <> @HeatNumberID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = ""
        cmd.Parameters.Add("@HeatNumberID", SqlDbType.VarChar).Value = 0
        If con.State = ConnectionState.Closed Then con.Open()
        ds20 = New DataSet()
        myAdapter20.SelectCommand = cmd
        myAdapter20.Fill(ds20, "LotNumber")
        dgvLotNumberRMID.DataSource = ds20.Tables("LotNumber")
        con.Close()
    End Sub

    Public Sub ShowCostTiers()
        cmd = New SqlCommand("SELECT * FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID ORDER BY CostingDate, TransactionNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCostTierDivision.Text
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = txtCostTierPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds21 = New DataSet()
        myAdapter21.SelectCommand = cmd
        myAdapter21.Fill(ds21, "InventoryCosting")
        dgvCostTiers.DataSource = ds21.Tables("InventoryCosting")
        con.Close()
    End Sub

    Public Sub ShowCostTiersForReturns()
        cmd = New SqlCommand("SELECT * FROM InventoryCosting WHERE Status = @Status AND ReferenceNumber = @ReferenceNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "Customer Return"
        cmd.Parameters.Add("@ReferenceNumber", SqlDbType.VarChar).Value = 0
        If con.State = ConnectionState.Closed Then con.Open()
        ds22 = New DataSet()
        myAdapter22.SelectCommand = cmd
        myAdapter22.Fill(ds22, "InventoryCosting")
        dgvInventoryCostingEdit.DataSource = ds22.Tables("InventoryCosting")
        con.Close()
    End Sub

    Public Sub ShowCostTiersForAdjustments()
        cmd = New SqlCommand("SELECT * FROM InventoryCosting WHERE Status = @Status AND ReferenceNumber = @ReferenceNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "INVENTORY ADJUSTMENT"
        cmd.Parameters.Add("@ReferenceNumber", SqlDbType.VarChar).Value = 0
        If con.State = ConnectionState.Closed Then con.Open()
        ds22 = New DataSet()
        myAdapter22.SelectCommand = cmd
        myAdapter22.Fill(ds22, "InventoryCosting")
        dgvInventoryCostingEdit.DataSource = ds22.Tables("InventoryCosting")
        con.Close()
    End Sub

    Public Sub ShowCostTiersForBuilds()
        cmd = New SqlCommand("SELECT * FROM InventoryCosting WHERE Status = @Status AND ReferenceNumber = @ReferenceNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "BUILD ASSEMBLY"
        cmd.Parameters.Add("@ReferenceNumber", SqlDbType.VarChar).Value = 0
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds22 = New DataSet()
        myAdapter22.SelectCommand = cmd
        myAdapter22.Fill(ds22, "InventoryCosting")
        dgvInventoryCostingEdit.DataSource = ds22.Tables("InventoryCosting")
        con.Close()
    End Sub

    Public Sub ShowCostTiersForVendorReturns()
        cmd = New SqlCommand("SELECT * FROM InventoryCosting WHERE Status = @Status AND ReferenceNumber = @ReferenceNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "Vendor Return"
        cmd.Parameters.Add("@ReferenceNumber", SqlDbType.VarChar).Value = 0
        If con.State = ConnectionState.Closed Then con.Open()
        ds22 = New DataSet()
        myAdapter22.SelectCommand = cmd
        myAdapter22.Fill(ds22, "InventoryCosting")
        dgvInventoryCostingEdit.DataSource = ds22.Tables("InventoryCosting")
        con.Close()
    End Sub

    Public Sub ShowCostTiersForReceivers()
        cmd = New SqlCommand("SELECT * FROM InventoryCosting WHERE Status = @Status AND ReferenceNumber = @ReferenceNumber", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "PO RECEIVING"
        cmd.Parameters.Add("@ReferenceNumber", SqlDbType.VarChar).Value = 0
        If con.State = ConnectionState.Closed Then con.Open()
        ds22 = New DataSet()
        myAdapter22.SelectCommand = cmd
        myAdapter22.Fill(ds22, "InventoryCosting")
        dgvInventoryCostingEdit.DataSource = ds22.Tables("InventoryCosting")
        con.Close()
    End Sub

    Public Sub ShowPurchaseLines()
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderQuantityStatus WHERE LineStatus = @LineStatus AND Status = @Status", con)
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds23 = New DataSet()
        myAdapter23.SelectCommand = cmd
        myAdapter23.Fill(ds23, "PurchaseOrderQuantityStatus")
        dgvPurchaseLines.DataSource = ds23.Tables("PurchaseOrderQuantityStatus")
        con.Close()
    End Sub

    Public Sub ShowPOHeaders()
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderHeaderTable WHERE ShipName = @ShipName", con)
        cmd.Parameters.Add("@ShipName", SqlDbType.VarChar).Value = ""
        'cmd.Parameters.Add("@ShipAddress1", SqlDbType.VarChar).Value = ""
        'cmd.Parameters.Add("@ShipCity", SqlDbType.VarChar).Value = ""
        If con.State = ConnectionState.Closed Then con.Open()
        ds24 = New DataSet()
        myAdapter24.SelectCommand = cmd
        myAdapter24.Fill(ds24, "PurchaseOrderHeaderTable")
        dgvPOHeaders.DataSource = ds24.Tables("PurchaseOrderHeaderTable")
        con.Close()
        ' AND ShipAddress1 = @ShipAddress1 AND ShipCity = @ShipCity
    End Sub

    Public Sub ShowSalesOrdersForDropShips()
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DropShipPONumber = @DropShipPONumber", con)
        cmd.Parameters.Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
        If con.State = ConnectionState.Closed Then con.Open()
        ds25 = New DataSet()
        myAdapter25.SelectCommand = cmd
        myAdapter25.Fill(ds25, "SalesOrderHeaderTable")
        dgvSOTable.DataSource = ds25.Tables("SalesOrderHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowTWDItemList()
        cmd = New SqlCommand("SELECT * FROM ItemList WHERE ItemClass = @ItemClass AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "TW NT"
        If con.State = ConnectionState.Closed Then con.Open()
        ds26 = New DataSet()
        myAdapter26.SelectCommand = cmd
        myAdapter26.Fill(ds26, "ItemList")
        dgvTWDItemList.DataSource = ds26.Tables("ItemList")
        con.Close()
    End Sub

    Public Sub ShowARPaymentCompare()
        cmd = New SqlCommand("SELECT * FROM ARPaymentCompare WHERE LogDivision = 'ADM'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds27 = New DataSet()
        myAdapter27.SelectCommand = cmd
        myAdapter27.Fill(ds27, "ARPaymentCompare")
        dgvARPaymentCompare.DataSource = ds27.Tables("ARPaymentCompare")
        con.Close()
    End Sub

    Public Sub ShowWireYard()
        cmd = New SqlCommand("SELECT * FROM SteelYardEntryTable WHERE SteelCost = 0", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds28 = New DataSet()
        myAdapter28.SelectCommand = cmd
        myAdapter28.Fill(ds28, "SteelYardEntryTable")
        dgvWireYard.DataSource = ds28.Tables("SteelYardEntryTable")
        con.Close()
    End Sub

    Public Sub ShowSteelUsage()
        cmd = New SqlCommand("SELECT * FROM SteelUsageTable WHERE SteelCost = 0", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds29 = New DataSet()
        myAdapter29.SelectCommand = cmd
        myAdapter29.Fill(ds29, "SteelUsageTable")
        dgvSteelUsage.DataSource = ds29.Tables("SteelUsageTable")
        con.Close()
    End Sub

    Public Sub ShowSteelCostTiers()
        cmd = New SqlCommand("SELECT * FROM SteelCostingTable WHERE SteelCostPerPound = @SteelCostPerPound", con)
        cmd.Parameters.Add("@SteelCostPerPound", SqlDbType.VarChar).Value = 50
        If con.State = ConnectionState.Closed Then con.Open()
        ds29 = New DataSet()
        myAdapter29.SelectCommand = cmd
        myAdapter29.Fill(ds29, "SteelCostingTable")
        dgvSteelCostingTable.DataSource = ds29.Tables("SteelCostingTable")
        con.Close()
    End Sub

    Public Sub ShowUPSData()
        cmd = New SqlCommand("SELECT * FROM UPSShippingData", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds30 = New DataSet()
        myAdapter30.SelectCommand = cmd
        myAdapter30.Fill(ds30, "UPSShippingData")
        dgvUPSShippingData.DataSource = ds30.Tables("UPSShippingData")
        con.Close()
    End Sub

    Public Sub ShowSerialLog()
        cmd = New SqlCommand("SELECT * FROM AssemblySerialLog WHERE Status <> @Status", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "AVAILABLE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds32 = New DataSet()
        myadapter32.SelectCommand = cmd
        myadapter32.Fill(ds32, "AssemblySerialLog")
        dgvSerialLog.DataSource = ds32.Tables("AssemblySerialLog")
        con.Close()
    End Sub

    Public Sub ShowOpenPOs()
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderHeaderTable WHERE Status = @Status", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds33 = New DataSet()
        myadapter33.SelectCommand = cmd
        myadapter33.Fill(ds33, "PurchaseOrderHeaderTable")
        dgvOpenPOTable.DataSource = ds33.Tables("PurchaseOrderHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowLotFoxData()
        cmd = New SqlCommand("SELECT * FROM LotNumberTest WHERE LotFinishedWeight <> LotRawMaterialWeight - LotScrapWeight", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds34 = New DataSet()
        myadapter34.SelectCommand = cmd
        myadapter34.Fill(ds34, "LotNumberTest")
        dgvLotNumberTest.DataSource = ds34.Tables("LotNumberTest")
        con.Close()
    End Sub

    Public Sub ShowReceiversForAP()
        cmd = New SqlCommand("SELECT * FROM ReceivingLineQuery WHERE SelectForInvoice = @SelectForInvoice AND Status = @Status AND TotalQuantityVouched >= QuantityReceived", con)
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
        cmd.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "CLOSED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds35 = New DataSet()
        myadapter35.SelectCommand = cmd
        myadapter35.Fill(ds35, "ReceivingLineQuery")
        dgvReceiverLineQuery.DataSource = ds35.Tables("ReceivingLineQuery")
        con.Close()
    End Sub

    Public Sub ShowHeatFilesInPullTests()
        cmd = New SqlCommand("SELECT * FROM PullTestCheckiSteelToHeat WHERE HeatFileNumber IS NULL", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds36 = New DataSet()
        myadapter36.SelectCommand = cmd
        myadapter36.Fill(ds36, "PullTestCheckiSteelToHeat")
        dgvSteelInPullTests.DataSource = ds36.Tables("PullTestCheckiSteelToHeat")
        con.Close()
    End Sub

    Private Sub cmdViewCOSalesOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewCOSalesOrders.Click
        ShowSalesOrders()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateCOSSalesOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateCOSSalesOrders.Click
        Dim SONumber As Integer
        Dim SumEstCOS As Double
        Dim DivisionKey As String

        For Each row As DataGridViewRow In dgvSOTable.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                SONumber = row.Cells("SOSalesOrderKeyColumn").Value
            Catch ex As Exception
                SONumber = 0
            End Try
            Try
                DivisionKey = row.Cells("SODivisionKeyColumn").Value
            Catch ex As Exception
                DivisionKey = 0
            End Try

            Dim SumSOLinesStatement As String = "SELECT SUM(EstExtendedCOS) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
            Dim SumSOLinesCommand As New SqlCommand(SumSOLinesStatement, con)
            SumSOLinesCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
            SumSOLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionKey

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumEstCOS = CDbl(SumSOLinesCommand.ExecuteScalar)
            Catch ex As Exception
                SumEstCOS = 0
            End Try
            con.Close()

            SumEstCOS = Math.Round(SumEstCOS, 2)

            Try
                'UPDATE SO
                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET TotalEstCOS = @TotalEstCOS WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                    .Add("@DivisionKey", SqlDbType.VarChar).Value = DivisionKey
                    .Add("@TotalEstCOS", SqlDbType.VarChar).Value = SumEstCOS
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue without updating batch
            End Try
        Next

        MsgBox("Sales Orders updated", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewShipments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewShipments.Click
        ShowShipments()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateShipments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateShipments.Click
        Dim ShipmentNumber As Integer = 0
        Dim SumExtendedAmount As Double = 0
        Dim DivisionID As String = ""

        For Each row As DataGridViewRow In dgvShipmentHeaderTable.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                ShipmentNumber = row.Cells("STShipmentNumberColumn").Value
            Catch ex As Exception
                ShipmentNumber = 0
            End Try
            Try
                DivisionID = row.Cells("STDivisionIDColumn").Value
            Catch ex As Exception
                DivisionID = ""
            End Try

            Dim SumShipLinesStatement As String = "SELECT SUM(ExtendedAmount) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim SumShipLinesCommand As New SqlCommand(SumShipLinesStatement, con)
            SumShipLinesCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
            SumShipLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumExtendedAmount = CDbl(SumShipLinesCommand.ExecuteScalar)
            Catch ex As Exception
                SumExtendedAmount = 0
            End Try
            con.Close()

            SumExtendedAmount = Math.Round(SumExtendedAmount, 2)

            Try
                'UPDATE SO
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ProductTotal = @ProductTotal WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedAmount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue without updating batch
            End Try

            Try
                'UPDATE SO
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue without updating batch
            End Try
        Next

        MsgBox("Shipments updated", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewSO.Click
        ShowSalesOrders()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateSO.Click
        Dim SONumber As Integer
        Dim SumExtendedAmount As Double
        Dim DivisionKey As String

        For Each row As DataGridViewRow In dgvSOTable.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                SONumber = row.Cells("SOSalesOrderKeyColumn").Value
            Catch ex As Exception
                SONumber = 0
            End Try
            Try
                DivisionKey = row.Cells("SODivisionKeyColumn").Value
            Catch ex As Exception
                DivisionKey = 0
            End Try

            Dim SumSOLinesStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey"
            Dim SumSOLinesCommand As New SqlCommand(SumSOLinesStatement, con)
            SumSOLinesCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumExtendedAmount = CDbl(SumSOLinesCommand.ExecuteScalar)
            Catch ex As Exception
                SumExtendedAmount = 0
            End Try
            con.Close()

            SumExtendedAmount = Math.Round(SumExtendedAmount, 2)

            Try
                'UPDATE SO
                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET ProductTotal = @ProductTotal WHERE SalesOrderKey = @SalesOrderKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedAmount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue without updating batch
            End Try
        Next

        Try
            'UPDATE SO
            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOTotal = ProductTotal + FreightCharge + TotalSalesTax + TotalSalesTax2 + TotalSalesTax3", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedAmount
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Continue without updating batch
        End Try

        MsgBox("Sales Orders updated", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewInvoiceShipments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewInvoiceShipments.Click
        ShowShipmentInvoice()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateShipmentInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateShipmentInvoices.Click
        ShowShipmentInvoice()

        Dim ShipmentNumber As Integer
        Dim InvoiceProductTotal, InvoiceTotal, SalesTax, SalesTax2, SalesTax3, BilledFreight As Double

        For Each row As DataGridViewRow In dgvInvoiceShipment.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                ShipmentNumber = row.Cells("ShipmentNumberColumn5").Value
            Catch ex As Exception
                ShipmentNumber = 0
            End Try
            Try
                InvoiceProductTotal = row.Cells("InvoiceProductTotalColumn5").Value
            Catch ex As Exception
                InvoiceProductTotal = 0
            End Try
            Try
                SalesTax = row.Cells("SalesTaxColumn5").Value
            Catch ex As Exception
                SalesTax = 0
            End Try
            Try
                SalesTax2 = row.Cells("SalesTax2Column5").Value
            Catch ex As Exception
                SalesTax2 = 0
            End Try
            Try
                SalesTax3 = row.Cells("SalesTax3Column5").Value
            Catch ex As Exception
                SalesTax3 = 0
            End Try
            Try
                BilledFreight = row.Cells("BilledFreightColumn5").Value
            Catch ex As Exception
                BilledFreight = 0
            End Try
            Try
                InvoiceTotal = row.Cells("InvoiceTotalColumn5").Value
            Catch ex As Exception
                InvoiceTotal = 0
            End Try

            Try
                'UPDATE the Invoice Batch
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ProductTotal = @ProductTotal, TaxTotal = @TaxTotal, Tax2Total = @Tax2Total, Tax3Total = @Tax3Total, ShipmentTotal = @ShipmentTotal, FreightActualAmount = @FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = InvoiceProductTotal
                    .Add("@TaxTotal", SqlDbType.VarChar).Value = SalesTax
                    .Add("@Tax2Total", SqlDbType.VarChar).Value = SalesTax2
                    .Add("@Tax3Total", SqlDbType.VarChar).Value = SalesTax3
                    .Add("@ShipmentTotal", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@FreightActualAmount", SqlDbType.VarChar).Value = BilledFreight
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue without updating batch
            End Try
        Next

        MsgBox("Shipments have been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewARInvoiceBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewARInvoiceBatch.Click
        ShowARInvoiceBatch()
        tabDatagrids.SelectedIndex = 2
    End Sub

    Private Sub cmdUpdateARInvoiceBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateARInvoiceBatch.Click
        ShowARInvoiceBatch()

        For Each row As DataGridViewRow In dgvARInvoiceBatch.Rows
            Dim ARBatchNumber As Integer
            Dim SUMARInvoices As Double
            Dim ARDivisionID As String

            'Extract row data from the datagrid - one row at a time
            Try
                ARBatchNumber = row.Cells("BatchNumberColumn8").Value
            Catch ex As Exception
                ARBatchNumber = 0
            End Try
            Try
                ARDivisionID = row.Cells("DivisionIDColumn8").Value
            Catch ex As Exception
                ARDivisionID = "NONE"
            End Try

            'Find the sum of the ARInvoices
            Dim SUMARInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim SUMARInvoicesCommand As New SqlCommand(SUMARInvoicesStatement, con)
            SUMARInvoicesCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = ARBatchNumber
            SUMARInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ARDivisionID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMARInvoices = CDbl(SUMARInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SUMARInvoices = 0
            End Try
            con.Close()

            If ARDivisionID = "NONE" Or ARBatchNumber = 0 Then
                'Skip specific batch and go to next - do not update
            Else
                Try
                    'UPDATE the Invoice Batch
                    cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = ARBatchNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = ARDivisionID
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = SUMARInvoices
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Continue without updating batch
                End Try
            End If
        Next

        MsgBox("Invoice Batch has been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdShowAPInvoiceBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowAPInvoiceBatch.Click
        ShowAPInvoiceBatch()
        tabDatagrids.SelectedIndex = 2
    End Sub

    Private Sub cmdUpdateAPInvoiceBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateAPInvoiceBatch.Click
        ShowAPInvoiceBatch()

        For Each row As DataGridViewRow In dgvAPInvoiceBatch.Rows
            Dim APBatchNumber As Integer
            Dim SUMAPInvoices As Double
            Dim APDivisionID As String

            'Extract row data from the datagrid - one row at a time
            Try
                APBatchNumber = row.Cells("BatchNumberColumn12").Value
            Catch ex As Exception
                APBatchNumber = 0
            End Try
            Try
                APDivisionID = row.Cells("DivisionIDColumn12").Value
            Catch ex As Exception
                APDivisionID = "NONE"
            End Try

            'Find the sum of the AP Invoices
            Dim SUMAPInvoicesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
            Dim SUMAPInvoicesCommand As New SqlCommand(SUMAPInvoicesStatement, con)
            SUMAPInvoicesCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = APBatchNumber
            SUMAPInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = APDivisionID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMAPInvoices = CDbl(SUMAPInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SUMAPInvoices = 0
            End Try
            con.Close()

            If APDivisionID = "NONE" Or APBatchNumber = 0 Then
                'Skip specific batch and go to next - do not update
            Else
                Try
                    'UPDATE the Invoice Batch
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = APBatchNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = APDivisionID
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = SUMAPInvoices
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Continue without updating batch
                End Try
            End If
        Next

        MsgBox("Invoice Batch has been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdShowARPaymentBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowARPaymentBatch.Click
        ShowARPaymentBatch()
        tabDatagrids.SelectedIndex = 2
    End Sub

    Private Sub cmdUpdateARPaymentBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateARPaymentBatch.Click
        ShowARPaymentBatch()

        Dim ARPayBatchNumber As Integer = 0
        Dim SUMARPayments As Double = 0

        For Each row As DataGridViewRow In dgvARPaymentBatch.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                ARPayBatchNumber = row.Cells("BatchNumberColumn9").Value
            Catch ex As Exception
                ARPayBatchNumber = 0
            End Try

            'Find the sum of the AR Payments
            Dim SUMARPaymentsStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE BatchNumber = @BatchNumber"
            Dim SUMARPaymentsCommand As New SqlCommand(SUMARPaymentsStatement, con)
            SUMARPaymentsCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = ARPayBatchNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMARPayments = CDbl(SUMARPaymentsCommand.ExecuteScalar)
            Catch ex As Exception
                SUMARPayments = 0
            End Try
            con.Close()

            Try
                'UPDATE the Payment Batch
                cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = ARPayBatchNumber
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = SUMARPayments
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue without updating batch
            End Try
        Next

        MsgBox("Payment Batch has been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdShowAPPaymentBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowAPPaymentBatch.Click
        ShowAPPaymentBatch()
        tabDatagrids.SelectedIndex = 2
    End Sub

    Private Sub cmdUpdateAPPaymentBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateAPPaymentBatch.Click
        ShowAPPaymentBatch()

        For Each row As DataGridViewRow In dgvAPPaymentBatch.Rows
            Dim APPayBatchNumber As Integer
            Dim SUMAPPayments As Double
            Dim APPayDivisionID As String

            'Extract row data from the datagrid - one row at a time
            Try
                APPayBatchNumber = row.Cells("BatchNumberColumn13").Value
            Catch ex As Exception
                APPayBatchNumber = 0
            End Try
            Try
                APPayDivisionID = row.Cells("DivisionIDColumn13").Value
            Catch ex As Exception
                APPayDivisionID = "NONE"
            End Try

            'Find the sum of the AP Payments
            Dim SUMAPInvoicesStatement As String = "SELECT SUM(CheckAmount) FROM APcheckLog WHERE APBatchNumber = @APBatchNumber AND DivisionID = @DivisionID"
            Dim SUMAPInvoicesCommand As New SqlCommand(SUMAPInvoicesStatement, con)
            SUMAPInvoicesCommand.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = APPayBatchNumber
            SUMAPInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = APPayDivisionID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMAPPayments = CDbl(SUMAPInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                SUMAPPayments = 0
            End Try
            con.Close()

            If APPayDivisionID = "NONE" Or APPayBatchNumber = 0 Then
                'Skip specific batch and go to next - do not update
            Else
                Try
                    'UPDATE the Payment Batch
                    cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = APPayBatchNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = APPayDivisionID
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = SUMAPPayments
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Continue without updating batch
                End Try
            End If
        Next

        MsgBox("Payment Batch has been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewInvoiceCOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewInvoiceCOS.Click
        ShowInvoiceCOS()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateInvoiceCOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateInvoiceCOS.Click
        ShowInvoiceCOS()

        For Each row As DataGridViewRow In dgvInvoiceCompare.Rows
            Dim ICInvoiceNumber As Integer
            Dim ICInvoiceCOS As Double
            Dim ICSUMExtendedCOS As Double

            'Extract row data from the datagrid - one row at a time
            Try
                ICInvoiceNumber = row.Cells("InvoiceNumberColumn3").Value
            Catch ex As Exception
                ICInvoiceNumber = 0
            End Try
            Try
                ICInvoiceCOS = row.Cells("InvoiceCOSColumn3").Value
            Catch ex As Exception
                ICInvoiceCOS = 0
            End Try
            Try
                ICSUMExtendedCOS = row.Cells("SUMExtendedCOSColumn3").Value
            Catch ex As Exception
                ICSUMExtendedCOS = 0
            End Try

            ICSUMExtendedCOS = Math.Round(ICSUMExtendedCOS, 2)

            If ICInvoiceCOS = ICSUMExtendedCOS Then
                'Skip specific batch and go to next - do not update
            Else
                Try
                    'UPDATE the Payment Batch
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceCOS = @InvoiceCOS WHERE InvoiceNumber = @InvoiceNumber", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = ICInvoiceNumber
                        .Add("@InvoiceCOS", SqlDbType.VarChar).Value = ICSUMExtendedCOS
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Continue without updating batch
                End Try
            End If
        Next

        MsgBox("Invoice COS has been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewReceivers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewReceivers.Click
        ShowReceivers()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateReceivers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateReceivers.Click
        ShowReceivers()

        For Each row As DataGridViewRow In dgvReceivingHeaders.Rows
            Dim ReceiverNumber As Integer = 0
            Dim ReceiverDivision As String

            'Extract row data from the datagrid - one row at a time
            Try
                ReceiverNumber = row.Cells("ReceivingHeaderKeyColumn7").Value
            Catch ex As Exception
                ReceiverNumber = 0
            End Try
            Try
                ReceiverDivision = row.Cells("DivisionIDColumn7").Value
            Catch ex As Exception
                ReceiverDivision = ""
            End Try

            'Check Status of the receiver and close if necessary
            Dim CountOpenLines As Integer = 0

            'Get number of open lines
            Dim CountOpenLinesStatement As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingLineTable WHERE SelectForInvoice = @SelectForInvoice AND ReceivingHeaderKey = @ReceivingHeaderKey"
            Dim CountOpenLinesCommand As New SqlCommand(CountOpenLinesStatement, con)
            CountOpenLinesCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
            CountOpenLinesCommand.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountOpenLines = CInt(CountOpenLinesCommand.ExecuteScalar)
            Catch ex As Exception
                CountOpenLines = 0
            End Try
            con.Close()

            If CountOpenLines = 0 Then
                'UPDATE the Status of the Receiver
                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = ReceiverDivision
                    .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                'UPDATE the Status of the Receiver
                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = ReceiverDivision
                    .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next

        MsgBox("Receivers have been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewCOSFromShipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewCOSFromShipment.Click
        ShowInvoiceShipmentCOS()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateCOSFromShipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateCOSFromShipment.Click
        For Each row As DataGridViewRow In dgvInvoiceShipCOS.Rows
            Dim LineSONumber, LineSOLine As Integer
            Dim LineOrderQuantity, LineUnitCost, LineExtendedCOS, NewLineExtendedCOS As Double

            'Extract row data from the datagrid - one row at a time
            Try
                LineSONumber = row.Cells("SONumberColumn2").Value
            Catch ex As Exception
                LineSONumber = 0
            End Try
            Try
                LineSOLine = row.Cells("SOLineNumberColumn2").Value
            Catch ex As Exception
                LineSOLine = 0
            End Try
            Try
                LineOrderQuantity = row.Cells("QuantityColumn2").Value
            Catch ex As Exception
                LineOrderQuantity = 0
            End Try
            Try
                LineUnitCost = row.Cells("UnitCostColumn2").Value
            Catch ex As Exception
                LineUnitCost = 0
            End Try
            Try
                LineExtendedCOS = row.Cells("EstExtendedCOSColumn2").Value
            Catch ex As Exception
                LineExtendedCOS = 0
            End Try

            If LineExtendedCOS = 0 Then
                NewLineExtendedCOS = LineOrderQuantity * LineUnitCost
                NewLineExtendedCOS = Math.Round(NewLineExtendedCOS, 2)

                Try
                    'UPDATE the Status of the Receiver
                    cmd = New SqlCommand("UPDATE SalesOrderLineTable SET EstExtendedCOS = @EstExtendedCOS WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = LineSONumber
                        .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = LineSOLine
                        .Add("@EstExtendedCOS", SqlDbType.VarChar).Value = NewLineExtendedCOS
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip Update
                End Try
            Else
                'Skip Line
            End If
        Next

        MsgBox("Sales Order Lines have been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewLot.Click
        ShowLotNumbers()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateLot.Click
        Dim RowLotNumber, RowPartNumber, ShortDescription, LongDescription As String
        'Dim HeatFileNumber As Integer = 0

        For Each row As DataGridViewRow In dgvLotNumberRMID.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                RowLotNumber = row.Cells("LotNumberColumn9").Value
            Catch ex As Exception
                RowLotNumber = ""
            End Try
            Try
                RowPartNumber = row.Cells("PartNumberColumn9").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try

            If RowPartNumber = "" Then
                'Skip
            Else
                'Get Short/Long Description from Item Maintenance
                Dim GetShortDStatement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetShortDCommand As New SqlCommand(GetShortDStatement, con)
                GetShortDCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
                GetShortDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

                Dim GetLongDStatement As String = "SELECT LongDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetLongDCommand As New SqlCommand(GetLongDStatement, con)
                GetLongDCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
                GetLongDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ShortDescription = CStr(GetShortDCommand.ExecuteScalar)
                Catch ex As Exception
                    ShortDescription = ""
                End Try
                Try
                    LongDescription = CStr(GetLongDCommand.ExecuteScalar)
                Catch ex As Exception
                    LongDescription = ""
                End Try
                con.Close()

                Try
                    'UPDATE the Status of the Lot Number
                    cmd = New SqlCommand("UPDATE LotNumber SET ShortDescription = @ShortDescription, LongDescription = @LongDescription WHERE LotNumber = @LotNumber", con)

                    With cmd.Parameters
                        .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                        .Add("@ShortDescription", SqlDbType.VarChar).Value = ShortDescription
                        .Add("@LongDescription", SqlDbType.VarChar).Value = LongDescription
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip Update
                End Try
            End If
        Next

        MsgBox("Lot Numbers have been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewErrorLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewErrorLog.Click
        ShowErrorLog()
        tabDatagrids.SelectedIndex = 1
    End Sub

    Private Sub cmdClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLog.Click
        'Clear Log 
        Dim button As DialogResult = MessageBox.Show("Do you wish to clear the entire error log", "CLEAR ERROR LOG", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            cmd = New SqlCommand("Delete FROM TFPErrorLog", con)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowErrorLog()
        ElseIf button = DialogResult.No Then
            cmdClearLog.Focus()
        End If
    End Sub

    Private Sub cmdDeleteTestData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteTestData.Click
        'Delete TST Receiver
        cmd = New SqlCommand("Delete FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST PO
        cmd = New SqlCommand("Delete FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST Invoice
        cmd = New SqlCommand("Delete FROM InvoiceProcessingBatchHeader WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST Shipment
        cmd = New SqlCommand("Delete FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST Pick
        cmd = New SqlCommand("Delete FROM PickListHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST SO
        cmd = New SqlCommand("Delete FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST GL Transactions
        cmd = New SqlCommand("Delete FROM GLTransactionMasterList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST Inventory Transactions
        cmd = New SqlCommand("Delete FROM InventoryTransactionTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST Inventory Costing
        cmd = New SqlCommand("Delete FROM InventoryCosting WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST Inventory Adjustments
        cmd = New SqlCommand("Delete FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST AP Data
        cmd = New SqlCommand("Delete FROM APVoucherTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST AP Data
        cmd = New SqlCommand("Delete FROM APCheckLog WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST AR Data
        cmd = New SqlCommand("Delete FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST AR Data
        cmd = New SqlCommand("Delete FROM ARPaymentLog WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST Vendor Return
        cmd = New SqlCommand("Delete FROM VendorReturn WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST Customer Return
        cmd = New SqlCommand("Delete FROM ReturnProductHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST Customer Return
        cmd = New SqlCommand("Delete FROM ReceiptOfInvoiceBatchHeader WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST Consignment Shipping
        cmd = New SqlCommand("Delete FROM ConsignmentShippingTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST Consignment Billing
        cmd = New SqlCommand("Delete FROM ConsignmentBillingTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete TST Consignment Adjustment
        cmd = New SqlCommand("Delete FROM ConsignmentAdjustmentTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete Assembly Build Header
        cmd = New SqlCommand("Delete FROM AssemblyBuildHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete Ferrule Postings
        cmd = New SqlCommand("Delete FROM FerruleProductionHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete Ferrule Postings
        cmd = New SqlCommand("Delete FROM TimeSlipHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        MsgBox("All Test Data has been deleted.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClearLocks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLocks.Click
        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE FOXTable SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE ItemList SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE VendorReturn SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE InventoryAdjustmentBatchNumbers SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear locks on all forms
        cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET Locked = @Locked", con)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = ""

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        MsgBox("All locks on all forms are now removed.", MsgBoxStyle.OkOnly)
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length > 400 Then
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdViewReturnHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewReturnHeader.Click
        ShowReturnHeaders()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateReturnCOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateReturnCOS.Click
        For Each row As DataGridViewRow In dgvReturnHeader.Rows
            Dim ReturnNumber As Integer = 0
            Dim Division As String = ""
            Dim TotalCOS As Double = 0

            'Extract row data from the datagrid - one row at a time
            Try
                ReturnNumber = row.Cells("ReturnNumberColumn6").Value
            Catch ex As Exception
                ReturnNumber = 0
            End Try
            Try
                Division = row.Cells("DivisionIDColumn6").Value
            Catch ex As Exception
                Division = ""
            End Try

            If Division = "" Or ReturnNumber = 0 Then
                'Skip Line
            Else
                'Get Total COS
                Dim GetCOSStatement As String = "SELECT SUM(ExtendedCOS) FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
                Dim GetCOSCommand As New SqlCommand(GetCOSStatement, con)
                GetCOSCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                GetCOSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = Division

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalCOS = CDbl(GetCOSCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalCOS = 0
                End Try
                con.Close()

                Try
                    'UPDATE SO Shipping Address
                    cmd = New SqlCommand("UPDATE ReturnProductHeaderTable SET TotalCOS = @TotalCOS WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ReturnNumber", SqlDbType.VarChar).Value = ReturnNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = Division
                        .Add("@TotalCOS", SqlDbType.VarChar).Value = TotalCOS
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip Update
                End Try
            End If

            ReturnNumber = 0
            TotalCOS = 0
            Division = ""
        Next

        MsgBox("Return Header has been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewOpenInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewOpenInvoices.Click
        ShowInvoiceHeaders()
        tabDatagrids.SelectedIndex = 2
    End Sub

    Private Sub cmdUpdateInvoicePayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateInvoicePayments.Click
        For Each row As DataGridViewRow In dgvInvoiceHeaderTable.Rows
            Dim InvoiceNumber As Integer = 0
            Dim Division As String = ""
            Dim TotalPayments As Double = 0

            'Extract row data from the datagrid - one row at a time
            Try
                InvoiceNumber = row.Cells("InvoiceNumberColumn10").Value
            Catch ex As Exception
                InvoiceNumber = 0
            End Try
            Try
                Division = row.Cells("DivisionIDColumn10").Value
            Catch ex As Exception
                Division = ""
            End Try

            If Division = "" Or InvoiceNumber = 0 Then
                'Skip Line
            Else
                'Get Total Payments
                Dim GetPaymentsStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID AND Status = @Status"
                Dim GetPaymentsCommand As New SqlCommand(GetPaymentsStatement, con)
                GetPaymentsCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                GetPaymentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = Division
                GetPaymentsCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalPayments = CDbl(GetPaymentsCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalPayments = 0
                End Try
                con.Close()

                TotalPayments = Math.Round(TotalPayments, 2)

                Try
                    'UPDATE Invoice Payments
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET PaymentsApplied = @PaymentsApplied WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = Division
                        .Add("@PaymentsApplied", SqlDbType.VarChar).Value = TotalPayments
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'UPDATE Invoice Status
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceStatus = @InvoiceStatus WHERE InvoiceTotal = PaymentsApplied", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = Division
                        .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip Update
                End Try
            End If

            InvoiceNumber = 0
            TotalPayments = 0
            Division = ""
        Next

        MsgBox("Invoice Payments have been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewPullTests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPullTests.Click
        ShowPullTests()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdatePullTests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdatePullTests.Click
        For Each row As DataGridViewRow In dgvPullTestData.Rows
            Dim TestNumber As String = ""
            Dim FOXNumber As Integer = 0
            Dim RMID As String = ""

            'Extract row data from the datagrid - one row at a time
            Try
                TestNumber = row.Cells("TestNumberColumn11").Value
            Catch ex As Exception
                TestNumber = 0
            End Try
            Try
                FOXNumber = row.Cells("FOXNumberColumn11").Value
            Catch ex As Exception
                FOXNumber = ""
            End Try

            If FOXNumber = 0 Then
                'Skip Line
            Else
                'Get Total Payments
                Dim GetRMIDStatement As String = "SELECT RMID FROM FOXTable WHERE FOXNumber = @FOXNumber"
                Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
                GetRMIDCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    RMID = CStr(GetRMIDCommand.ExecuteScalar)
                Catch ex As Exception
                    RMID = ""
                End Try
                con.Close()

                If RMID = "" Then
                    'Skip Line
                Else
                    Try
                        'UPDATE Invoice Payments
                        cmd = New SqlCommand("UPDATE PullTestData SET RMID = @RMID WHERE TestNumber = @TestNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@TestNumber", SqlDbType.VarChar).Value = TestNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                            .Add("@RMID", SqlDbType.VarChar).Value = RMID
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip Update
                    End Try
                End If
            End If

            TestNumber = ""
            FOXNumber = 0
            RMID = ""
        Next

        MsgBox("Pull Tests have been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub llUmpostedInvoiceLines_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llUmpostedInvoiceLines.LinkClicked
        Dim NewViewInvoiceLedgerPostings As New ViewInvoiceLedgerPostings
        NewViewInvoiceLedgerPostings.Show()
    End Sub

    Private Sub cmdViewLots_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewLots.Click
        ShowLotsWORMID()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateLots_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateLots.Click

        For Each row As DataGridViewRow In dgvLotNumberRMID.Rows
            Dim LotNumber As String = ""
            Dim HeatFileNumber As Integer = 0
            Dim SteelType As String = ""
            Dim SteelSize As String = ""
            Dim RMID As String = ""
            Dim SteelDescription As String = ""
            Dim HeatNumber As String = ""

            'Extract row data from the datagrid - one row at a time
            Try
                LotNumber = row.Cells("LotNumberColumn9").Value
            Catch ex As Exception
                LotNumber = 0
            End Try
            Try
                HeatFileNumber = row.Cells("HeatNumberIDColumn9").Value
            Catch ex As Exception
                HeatFileNumber = 0
            End Try

            'RMID for selected Heat File #
            Dim GetSteelSizeStatement As String = "SELECT SteelSize FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber"
            Dim GetSteelSizeCommand As New SqlCommand(GetSteelSizeStatement, con)
            GetSteelSizeCommand.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = HeatFileNumber

            Dim GetSteelTypeStatement As String = "SELECT SteelType FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber"
            Dim GetSteelTypeCommand As New SqlCommand(GetSteelTypeStatement, con)
            GetSteelTypeCommand.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = HeatFileNumber

            Dim GetHeatNumberStatement As String = "SELECT HeatNumber FROM HeatNumberLog WHERE HeatFileNumber = @HeatFileNumber"
            Dim GetHeatNumberCommand As New SqlCommand(GetHeatNumberStatement, con)
            GetHeatNumberCommand.Parameters.Add("@HeatFileNumber", SqlDbType.VarChar).Value = HeatFileNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SteelSize = CStr(GetSteelSizeCommand.ExecuteScalar)
            Catch ex As Exception
                SteelSize = ""
            End Try
            Try
                SteelType = CStr(GetSteelTypeCommand.ExecuteScalar)
            Catch ex As Exception
                SteelType = ""
            End Try
            Try
                HeatNumber = CStr(GetHeatNumberCommand.ExecuteScalar)
            Catch ex As Exception
                HeatNumber = ""
            End Try
            con.Close()

            'Get RMID based on Heat Number Data
            Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
            Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
            GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize
            GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = SteelType

            Dim GetDescriptionStatement As String = "SELECT Description FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
            Dim GetDescriptionCommand As New SqlCommand(GetDescriptionStatement, con)
            GetDescriptionCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize
            GetDescriptionCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = SteelType

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                RMID = CStr(GetRMIDCommand.ExecuteScalar)
            Catch ex As Exception
                RMID = ""
            End Try
            Try
                SteelDescription = CStr(GetDescriptionCommand.ExecuteScalar)
            Catch ex As Exception
                SteelDescription = ""
            End Try
            con.Close()

            If RMID = "" Then
                'Skip specific batch and go to next - do not update
            Else
                Try
                    'UPDATE the Payment Batch
                    cmd = New SqlCommand("UPDATE LotNumber SET RMID = @RMID, HeatNumber = @HeatNumber, SteelDescription = @SteelDescription  WHERE LotNumber = @LotNumber", con)

                    With cmd.Parameters
                        .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                        .Add("@RMID", SqlDbType.VarChar).Value = RMID
                        .Add("@HeatNumber", SqlDbType.VarChar).Value = HeatNumber
                        .Add("@SteelDescription", SqlDbType.VarChar).Value = SteelDescription
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Continue without updating batch
                End Try
            End If
        Next

        MsgBox("Lot Number has been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewItemList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewItemList.Click
        ShowItemListStandard()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateItemList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateItemList.Click
        For Each row As DataGridViewRow In dgvItemList.Rows
            Dim PartNumber As String = ""
            Dim Division As String = ""

            'Extract row data from the datagrid - one row at a time
            Try
                PartNumber = row.Cells("CostItemIDColumn").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                Division = row.Cells("CostDivisionIDColumn").Value
            Catch ex As Exception
                Division = ""
            End Try

            If Division = "" Or PartNumber = "" Then
                'Skip Line
            Else
                'Get Last Transaction Cost
                Dim TransactionCost As Double = 0
                Dim Maxdate2 As Integer = 0

                Dim MAXDate2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                Dim MAXDate2Command As New SqlCommand(MAXDate2Statement, con)
                MAXDate2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                MAXDate2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    Maxdate2 = CInt(MAXDate2Command.ExecuteScalar)
                Catch ex As Exception
                    Maxdate2 = 0
                End Try
                con.Close()

                Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
                Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Maxdate2

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                Catch ex As Exception
                    TransactionCost = 0
                End Try
                con.Close()

                If TransactionCost <> 0 Then
                    Try
                        'UPDATE Standard Cost
                        cmd = New SqlCommand("UPDATE ItemList SET StandardCost = @StandardCost WHERE ItemID = @ItemID AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = Division
                            .Add("@StandardCost", SqlDbType.VarChar).Value = TransactionCost
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip Update
                    End Try
                Else
                    'Skip Line
                End If

                TransactionCost = 0
            End If

            PartNumber = ""
            Division = ""
        Next

        MsgBox("Standard Cost has been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewAssembly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAssembly.Click
        ShowAssemblyCost()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateAssemblyCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateAssemblyCost.Click
        For Each row As DataGridViewRow In dgvAssemblyTable.Rows
            Dim PartNumber As String = ""
            Dim Division As String = ""

            'Extract row data from the datagrid - one row at a time
            Try
                PartNumber = row.Cells("AssemblyPartNumberColumn11").Value
            Catch ex As Exception
                PartNumber = ""
            End Try
            Try
                Division = row.Cells("DivisionIDColumn11").Value
            Catch ex As Exception
                Division = ""
            End Try

            If Division = "" Or PartNumber = "" Then
                'Skip Line
            Else
                'Get sum of the lines
                Dim SumCost As Double = 0
                Dim TransactionCost As Double = 0
                Dim Maxdate2 As Integer = 0

                Dim SumCostStatement As String = "SELECT SUM(ExtendedCost) FROM AssemblyLineTable WHERE DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber"
                Dim SumCostCommand As New SqlCommand(SumCostStatement, con)
                SumCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = Division
                SumCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumCost = CDbl(SumCostCommand.ExecuteScalar)
                Catch ex As Exception
                    SumCost = 0
                End Try
                con.Close()
                '************************************************************************************************
                If SumCost = 0 Then
                    Dim MAXDate2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                    Dim MAXDate2Command As New SqlCommand(MAXDate2Statement, con)
                    MAXDate2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = Division
                    MAXDate2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        Maxdate2 = CInt(MAXDate2Command.ExecuteScalar)
                    Catch ex As Exception
                        Maxdate2 = 0
                    End Try
                    con.Close()

                    Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
                    Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
                    TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = Division
                    TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Maxdate2

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        TransactionCost = 0
                    End Try
                    con.Close()

                    TransactionCost = Math.Round(TransactionCost, 2)
                Else
                    SumCost = Math.Round(SumCost, 2)
                    TransactionCost = SumCost
                End If
                '**************************************************************************************************************
                If TransactionCost <> 0 Then
                    Try
                        'UPDATE Standard Cost
                        cmd = New SqlCommand("UPDATE AssemblyHeaderTable SET TotalCost = @TotalCost WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = Division
                            .Add("@TotalCost", SqlDbType.VarChar).Value = TransactionCost
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip Update
                    End Try
                Else
                    'Skip Line
                End If

                TransactionCost = 0
            End If

            PartNumber = ""
            Division = ""
        Next

        MsgBox("Assembly Cost has been updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewAssemblyLineNumbers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAssemblyLineNumbers.Click
        ShowAssemblyLines()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateAssemblyLineNumbers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateAssemblyLineNumbers.Click
        Dim AssemblyPartNumber As String = ""
        Dim ComponentPartNumber As String = ""
        Dim Division As String = ""
        Dim ComparePartNumber As String = ""
        Dim LineCounter As Integer = 1
        Dim ComponentLineNumber As Integer = 0
        Dim CompareDivision As String = ""

        For Each row As DataGridViewRow In dgvAssemblyLines.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                AssemblyPartNumber = row.Cells("AssemblyPartNumberColumn14").Value
            Catch ex As Exception
                AssemblyPartNumber = ""
            End Try
            Try
                ComponentPartNumber = row.Cells("ComponentPartNumberColumn14").Value
            Catch ex As Exception
                ComponentPartNumber = ""
            End Try
            Try
                Division = row.Cells("DivisionIDColumn14").Value
            Catch ex As Exception
                Division = ""
            End Try
            Try
                ComponentLineNumber = row.Cells("ComponentLineNumberColumn14").Value
            Catch ex As Exception
                ComponentLineNumber = 0
            End Try

            If AssemblyPartNumber = ComparePartNumber And Division = CompareDivision Then
                LineCounter = LineCounter + 1
            Else
                LineCounter = 1
            End If

            'Update Line Number
            Try
                cmd = New SqlCommand("UPDATE AssemblyLineTable SET ComponentLineNumber = @ComponentLineNumber WHERE AssemblyPartNumber = @AssemblyPartNumber AND ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentLineNumber = @ComponentLineNumber2", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = AssemblyPartNumber
                    .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = Division
                    .Add("@ComponentLineNumber", SqlDbType.VarChar).Value = LineCounter
                    .Add("@ComponentLineNumber2", SqlDbType.VarChar).Value = ComponentLineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip Update
            End Try

            CompareDivision = Division
            ComparePartNumber = AssemblyPartNumber
            AssemblyPartNumber = ""
            Division = ""
        Next

        MsgBox("Assembly Lines Updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewAssemblyLineCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAssemblyLineCost.Click
        ShowAssemblyLines()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateAssemblyLineCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateAssemblyLineCost.Click
        Dim AssemblyPartNumber As String = ""
        Dim ComponentPartNumber As String = ""
        Dim ComponentLineNumber As Integer = 0
        Dim Division As String = ""
        Dim LastCost As Double = 0
        Dim StandardCost As Double = 0
        Dim UnitCost As Double = 0

        For Each row As DataGridViewRow In dgvAssemblyLines.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                AssemblyPartNumber = row.Cells("AssemblyPartNumberColumn14").Value
            Catch ex As Exception
                AssemblyPartNumber = ""
            End Try
            Try
                ComponentPartNumber = row.Cells("ComponentPartNumberColumn14").Value
            Catch ex As Exception
                ComponentPartNumber = ""
            End Try
            Try
                Division = row.Cells("DivisionIDColumn14").Value
            Catch ex As Exception
                Division = ""
            End Try
            Try
                ComponentLineNumber = row.Cells("ComponentLineNumberColumn14").Value
            Catch ex As Exception
                ComponentLineNumber = 0
            End Try

            'Get Last Cost
            Dim MAXDate2 As Integer = 0

            Dim MAXDate2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
            Dim MAXDate2Command As New SqlCommand(MAXDate2Statement, con)
            MAXDate2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = Division
            MAXDate2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                Maxdate2 = CInt(MAXDate2Command.ExecuteScalar)
            Catch ex As Exception
                Maxdate2 = 0
            End Try
            con.Close()

            Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
            Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
            TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = Division
            TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
            TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Maxdate2

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastCost = CDbl(TransactionCostCommand.ExecuteScalar)
            Catch ex As Exception
                LastCost = 0
            End Try
            con.Close()

            If LastCost = 0 Then
                'get Standard Cost
                Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
                Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = Division
                StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ComponentPartNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                Catch ex As Exception
                    StandardCost = 0
                End Try
                con.Close()

                UnitCost = StandardCost
            Else
                UnitCost = LastCost
            End If

            If UnitCost = 0 Then
                'Skip
            Else
                'Update Line Number
                Try
                    cmd = New SqlCommand("UPDATE AssemblyLineTable SET UnitCost = @UnitCost WHERE AssemblyPartNumber = @AssemblyPartNumber AND ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentLineNumber = @ComponentLineNumber", con)

                    With cmd.Parameters
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = AssemblyPartNumber
                        .Add("@ComponentPartNumber", SqlDbType.VarChar).Value = ComponentPartNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = Division
                        .Add("@ComponentLineNumber", SqlDbType.VarChar).Value = ComponentLineNumber
                        .Add("@UnitCost", SqlDbType.VarChar).Value = UnitCost
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip Update
                End Try
            End If

            AssemblyPartNumber = ""
            Division = ""
            UnitCost = 0
            ComponentLineNumber = 0
            ComponentPartNumber = ""
        Next

        MsgBox("Assembly Lines Updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewCostTiers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewCostTiers.Click
        ShowCostTiers()
        tabDatagrids.SelectedIndex = 4
    End Sub

    Private Sub cmdUpdateCostTiers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateCostTiers.Click
        Dim TransactionNumber As Integer = 0
        Dim CostQuantity As Double = 0
        Dim LowerLimit As Double = 0
        Dim UpperLimit As Double = 0
        Dim LastUpperLimit As Double = 0
        Dim CostingPartNumber As String = ""

        Dim Counter As Integer = 1

        For Each row As DataGridViewRow In dgvCostTiers.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                TransactionNumber = row.Cells("CTTransactionNumberColumn").Value
            Catch ex As Exception
                TransactionNumber = 0
            End Try
            Try
                CostQuantity = row.Cells("CTCostQuantityColumn").Value
            Catch ex As Exception
                CostQuantity = 0
            End Try
            Try
                LowerLimit = row.Cells("CTLowerLimitColumn").Value
            Catch ex As Exception
                LowerLimit = 0
            End Try
            Try
                UpperLimit = row.Cells("CTUpperLimitColumn").Value
            Catch ex As Exception
                UpperLimit = 0
            End Try
            Try
                CostingPartNumber = row.Cells("CTPartNumberColumn").Value
            Catch ex As Exception
                CostingPartNumber = ""
            End Try
            '*************************************************************************
            'If first repetition then Lower Limit starts as one
            If Counter = 1 Then
                LowerLimit = 1
                UpperLimit = CostQuantity
            Else
                If CostQuantity > 0 Then
                    LowerLimit = LastUpperLimit + 1
                    UpperLimit = LastUpperLimit + CostQuantity
                Else
                    LowerLimit = LastUpperLimit
                    UpperLimit = LastUpperLimit + CostQuantity
                End If
            End If

            'Update Line Number
            Try
                cmd = New SqlCommand("UPDATE InventoryCosting SET LowerLimit = @LowerLimit, UpperLimit = @UpperLimit WHERE PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = txtCostTierPartNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = txtCostTierDivision.Text
                    .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimit
                    .Add("@UpperLimit", SqlDbType.VarChar).Value = UpperLimit
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip Update
            End Try

            'Advance Counter
            Counter = Counter + 1

            'Clear Variables
            LastUpperLimit = UpperLimit
            UpperLimit = 0
            LowerLimit = 0
            CostQuantity = 0
            TransactionNumber = 0
        Next

        MsgBox("Cost Tiers Repaired.", MsgBoxStyle.OkOnly)

        ShowCostTiers()
    End Sub

    Private Sub cmdViewCostTierReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewCostTierReturns.Click
        ShowCostTiersForReturns()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateCostTierReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateCostTierReturns.Click
        Dim TransactionNumber As Integer = 0
        Dim CostQuantity As Double = 0
        Dim CostingDate As String = ""
        Dim DivisionID As String = ""
        Dim GetReferenceNumber As Integer = 0
        Dim GetReferenceLine As Integer = 0
        Dim CostingPartNumber As String = ""

        For Each row As DataGridViewRow In dgvInventoryCostingEdit.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                TransactionNumber = row.Cells("TransactionNumberColumn55").Value
            Catch ex As Exception
                TransactionNumber = 0
            End Try
            Try
                CostQuantity = row.Cells("CostQuantityColumn55").Value
            Catch ex As Exception
                CostQuantity = 0
            End Try
            Try
                CostingDate = row.Cells("CostingDateColumn55").Value
            Catch ex As Exception
                CostingDate = ""
            End Try
            Try
                DivisionID = row.Cells("DivisionIDColumn55").Value
            Catch ex As Exception
                DivisionID = ""
            End Try
            Try
                CostingPartNumber = row.Cells("PartNumberColumn55").Value
            Catch ex As Exception
                CostingPartNumber = ""
            End Try
            '*************************************************************************
            'Get data from inventory transactions if possible - if not, skip
            Dim GetReferenceNumberStatement As String = "SELECT ReturnNumber FROM ReturnProductLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND Quantity = @Quantity AND ReturnDate = @ReturnDate"
            Dim GetReferenceNumberCommand As New SqlCommand(GetReferenceNumberStatement, con)
            GetReferenceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            GetReferenceNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CostingPartNumber
            GetReferenceNumberCommand.Parameters.Add("@ReturnDate", SqlDbType.VarChar).Value = CostingDate
            GetReferenceNumberCommand.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = CostQuantity

            Dim GetReferenceLineStatement As String = "SELECT ReturnLineNumber FROM ReturnProductLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND Quantity = @Quantity AND ReturnDate = @ReturnDate"
            Dim GetReferenceLineCommand As New SqlCommand(GetReferenceLineStatement, con)
            GetReferenceLineCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            GetReferenceLineCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CostingPartNumber
            GetReferenceLineCommand.Parameters.Add("@ReturnDate", SqlDbType.VarChar).Value = CostingDate
            GetReferenceLineCommand.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = CostQuantity

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetReferenceNumber = CInt(GetReferenceNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetReferenceNumber = 0
            End Try
            Try
                GetReferenceLine = CInt(GetReferenceLineCommand.ExecuteScalar)
            Catch ex As Exception
                GetReferenceLine = 0
            End Try
            con.Close()

            If GetReferenceNumber = 0 Then
                'Skip
            Else
                'Update Reference Numbers
                Try
                    cmd = New SqlCommand("UPDATE InventoryCosting SET ReferenceNumber = @ReferenceNumber, ReferenceLine = @ReferenceLine WHERE PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PartNumber", SqlDbType.VarChar).Value = CostingPartNumber
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = GetReferenceNumber
                        .Add("@ReferenceLine", SqlDbType.VarChar).Value = GetReferenceLine
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip Update
                End Try
            End If
 
            GetReferenceLine = 0
            GetReferenceNumber = 0
            CostingPartNumber = ""
            CostingDate = ""
            DivisionID = ""
            CostQuantity = 0
            TransactionNumber = 0
        Next

        MsgBox("Cost Tiers Repaired.", MsgBoxStyle.OkOnly)
        ShowCostTiersForReturns()
    End Sub

    Private Sub cmdViewAdjustmentTiers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAdjustmentTiers.Click
        ShowCostTiersForAdjustments()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateAdjustmentTiers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateAdjustmentTiers.Click
        Dim TransactionNumber As Integer = 0
        Dim CostQuantity As Double = 0
        Dim CostingDate As String = ""
        Dim DivisionID As String = ""
        Dim GetReferenceNumber As Integer = 0
        Dim GetReferenceLine As Integer = 0
        Dim CostingPartNumber As String = ""

        For Each row As DataGridViewRow In dgvInventoryCostingEdit.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                TransactionNumber = row.Cells("TransactionNumberColumn55").Value
            Catch ex As Exception
                TransactionNumber = 0
            End Try
            Try
                CostQuantity = row.Cells("CostQuantityColumn55").Value
            Catch ex As Exception
                CostQuantity = 0
            End Try
            Try
                CostingDate = row.Cells("CostingDateColumn55").Value
            Catch ex As Exception
                CostingDate = ""
            End Try
            Try
                DivisionID = row.Cells("DivisionIDColumn55").Value
            Catch ex As Exception
                DivisionID = ""
            End Try
            Try
                CostingPartNumber = row.Cells("PartNumberColumn55").Value
            Catch ex As Exception
                CostingPartNumber = ""
            End Try
            '*************************************************************************
            'Get data from inventory transactions if possible - if not, skip
            Dim GetReferenceNumberStatement As String = "SELECT AdjustmentNumber FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND Quantity = @Quantity AND AdjustmentDate = @AdjustmentDate"
            Dim GetReferenceNumberCommand As New SqlCommand(GetReferenceNumberStatement, con)
            GetReferenceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            GetReferenceNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CostingPartNumber
            GetReferenceNumberCommand.Parameters.Add("@AdjustmentDate", SqlDbType.VarChar).Value = CostingDate
            GetReferenceNumberCommand.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = CostQuantity

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetReferenceNumber = CInt(GetReferenceNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetReferenceNumber = 0
            End Try
            con.Close()

            If GetReferenceNumber = 0 Then
                'Skip
            Else
                'Update Reference Numbers
                Try
                    cmd = New SqlCommand("UPDATE InventoryCosting SET ReferenceNumber = @ReferenceNumber, ReferenceLine = @ReferenceLine WHERE PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PartNumber", SqlDbType.VarChar).Value = CostingPartNumber
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = GetReferenceNumber
                        .Add("@ReferenceLine", SqlDbType.VarChar).Value = 1
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip Update
                End Try
            End If

            GetReferenceLine = 0
            GetReferenceNumber = 0
            CostingPartNumber = ""
            CostingDate = ""
            DivisionID = ""
            CostQuantity = 0
            TransactionNumber = 0
        Next

        MsgBox("Cost Tiers Repaired.", MsgBoxStyle.OkOnly)
        ShowCostTiersForAdjustments()
    End Sub

    Private Sub cmdViewVendorReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewVendorReturns.Click
        ShowCostTiersForVendorReturns()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateVendorReturnsTiers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateVendorReturnsTiers.Click
        Dim TransactionNumber As Integer = 0
        Dim CostQuantity As Double = 0
        Dim CostingDate As String = ""
        Dim DivisionID As String = ""
        Dim GetReferenceNumber As Integer = 0
        Dim GetReferenceLine As Integer = 0
        Dim CostingPartNumber As String = ""

        For Each row As DataGridViewRow In dgvInventoryCostingEdit.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                TransactionNumber = row.Cells("TransactionNumberColumn55").Value
            Catch ex As Exception
                TransactionNumber = 0
            End Try
            Try
                CostQuantity = row.Cells("CostQuantityColumn55").Value
            Catch ex As Exception
                CostQuantity = 0
            End Try
            Try
                CostingDate = row.Cells("CostingDateColumn55").Value
            Catch ex As Exception
                CostingDate = ""
            End Try
            Try
                DivisionID = row.Cells("DivisionIDColumn55").Value
            Catch ex As Exception
                DivisionID = ""
            End Try
            Try
                CostingPartNumber = row.Cells("PartNumberColumn55").Value
            Catch ex As Exception
                CostingPartNumber = ""
            End Try

            CostQuantity = CostQuantity * -1
            '*************************************************************************
            'Get data from inventory transactions if possible - if not, skip
            Dim GetReferenceNumberStatement As String = "SELECT ReturnNumber FROM VendorReturnLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND Quantity = @Quantity AND ReturnDate = @ReturnDate"
            Dim GetReferenceNumberCommand As New SqlCommand(GetReferenceNumberStatement, con)
            GetReferenceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            GetReferenceNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CostingPartNumber
            GetReferenceNumberCommand.Parameters.Add("@ReturnDate", SqlDbType.VarChar).Value = CostingDate
            GetReferenceNumberCommand.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = CostQuantity

            Dim GetReferenceLineNumberStatement As String = "SELECT ReturnLineNumber FROM VendorReturnLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND Quantity = @Quantity AND ReturnDate = @ReturnDate"
            Dim GetReferenceLineNumberCommand As New SqlCommand(GetReferenceLineNumberStatement, con)
            GetReferenceLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            GetReferenceLineNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CostingPartNumber
            GetReferenceLineNumberCommand.Parameters.Add("@ReturnDate", SqlDbType.VarChar).Value = CostingDate
            GetReferenceLineNumberCommand.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = CostQuantity

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetReferenceNumber = CInt(GetReferenceNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetReferenceNumber = 0
            End Try
            Try
                GetReferenceLine = CInt(GetReferenceLineNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetReferenceLine = 0
            End Try
            con.Close()

            If GetReferenceNumber = 0 Then
                'Skip
            Else
                'Update Reference Numbers
                Try
                    cmd = New SqlCommand("UPDATE InventoryCosting SET ReferenceNumber = @ReferenceNumber, ReferenceLine = @ReferenceLine WHERE PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PartNumber", SqlDbType.VarChar).Value = CostingPartNumber
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = GetReferenceNumber
                        .Add("@ReferenceLine", SqlDbType.VarChar).Value = GetReferenceLine
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip Update
                End Try
            End If

            GetReferenceLine = 0
            GetReferenceNumber = 0
            CostingPartNumber = ""
            CostingDate = ""
            DivisionID = ""
            CostQuantity = 0
            TransactionNumber = 0
        Next

        MsgBox("Cost Tiers Repaired.", MsgBoxStyle.OkOnly)
        ShowCostTiersForVendorReturns()
    End Sub

    Private Sub cmdViewReceiverTiers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewReceiverTiers.Click
        ShowCostTiersForReceivers()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateReceiverTiers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateReceiverTiers.Click
        Dim TransactionNumber As Integer = 0
        Dim CostQuantity As Double = 0
        Dim CostingDate As String = ""
        Dim DivisionID As String = ""
        Dim GetReferenceNumber As Integer = 0
        Dim GetReferenceLine As Integer = 0
        Dim CostingPartNumber As String = ""

        For Each row As DataGridViewRow In dgvInventoryCostingEdit.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                TransactionNumber = row.Cells("TransactionNumberColumn55").Value
            Catch ex As Exception
                TransactionNumber = 0
            End Try
            Try
                CostQuantity = row.Cells("CostQuantityColumn55").Value
            Catch ex As Exception
                CostQuantity = 0
            End Try
            Try
                CostingDate = row.Cells("CostingDateColumn55").Value
            Catch ex As Exception
                CostingDate = ""
            End Try
            Try
                DivisionID = row.Cells("DivisionIDColumn55").Value
            Catch ex As Exception
                DivisionID = ""
            End Try
            Try
                CostingPartNumber = row.Cells("PartNumberColumn55").Value
            Catch ex As Exception
                CostingPartNumber = ""
            End Try
            '*************************************************************************
            'Get data from inventory transactions if possible - if not, skip
            Dim GetReferenceNumberStatement As String = "SELECT ReceivingHeaderKey FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND QuantityReceived = @QuantityReceived AND ReceivingDate = @ReceivingDate"
            Dim GetReferenceNumberCommand As New SqlCommand(GetReferenceNumberStatement, con)
            GetReferenceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            GetReferenceNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CostingPartNumber
            GetReferenceNumberCommand.Parameters.Add("@ReceivingDate", SqlDbType.VarChar).Value = CostingDate
            GetReferenceNumberCommand.Parameters.Add("@QuantityReceived", SqlDbType.VarChar).Value = CostQuantity

            Dim GetReferenceLineNumberStatement As String = "SELECT ReceivingLineKey FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND QuantityReceived = @QuantityReceived AND ReceivingDate = @ReceivingDate"
            Dim GetReferenceLineNumberCommand As New SqlCommand(GetReferenceLineNumberStatement, con)
            GetReferenceLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            GetReferenceLineNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = CostingPartNumber
            GetReferenceLineNumberCommand.Parameters.Add("@ReceivingDate", SqlDbType.VarChar).Value = CostingDate
            GetReferenceLineNumberCommand.Parameters.Add("@QuantityReceived", SqlDbType.VarChar).Value = CostQuantity

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetReferenceNumber = CInt(GetReferenceNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetReferenceNumber = 0
            End Try
            Try
                GetReferenceLine = CInt(GetReferenceLineNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetReferenceLine = 0
            End Try
            con.Close()

            If GetReferenceNumber = 0 Then
                'Skip
            Else
                'Update Reference Numbers
                Try
                    cmd = New SqlCommand("UPDATE InventoryCosting SET ReferenceNumber = @ReferenceNumber, ReferenceLine = @ReferenceLine WHERE PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PartNumber", SqlDbType.VarChar).Value = CostingPartNumber
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = GetReferenceNumber
                        .Add("@ReferenceLine", SqlDbType.VarChar).Value = GetReferenceLine
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip Update
                End Try
            End If

            GetReferenceLine = 0
            GetReferenceNumber = 0
            CostingPartNumber = ""
            CostingDate = ""
            DivisionID = ""
            CostQuantity = 0
            TransactionNumber = 0
        Next

        MsgBox("Cost Tiers Repaired.", MsgBoxStyle.OkOnly)
        ShowCostTiersForReceivers()
    End Sub

    Private Sub cmdViewPOLineStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPOLineStatus.Click
        ShowPurchaseLines()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdatePOLineStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdatePOLineStatus.Click
        Dim PurchaseOrderNumber As Integer = 0
        Dim PurchaseOrderLine As Integer = 0
        Dim LineStatus As String = ""
        Dim POStatus As String = ""
        Dim OrderQuantity As Double = 0
        Dim ReceivedQuantity As Double = 0
        Dim OpenQuantity As Double = 0
        Dim DivisionID As String = ""

        For Each row As DataGridViewRow In dgvPurchaseLines.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                PurchaseOrderNumber = row.Cells("PurchaseOrderHeaderKeyColumn88").Value
            Catch ex As Exception
                PurchaseOrderNumber = 0
            End Try
            Try
                PurchaseOrderLine = row.Cells("PurchaseOrderLineNumberColumn88").Value
            Catch ex As Exception
                PurchaseOrderLine = 0
            End Try
            Try
                LineStatus = row.Cells("LineStatusColumn88").Value
            Catch ex As Exception
                LineStatus = ""
            End Try
            Try
                POStatus = row.Cells("StatusColumn88").Value
            Catch ex As Exception
                POStatus = ""
            End Try
            Try
                DivisionID = row.Cells("DivisionIDColumn88").Value
            Catch ex As Exception
                DivisionID = ""
            End Try
            Try
                OrderQuantity = row.Cells("OrderQuantityColumn88").Value
            Catch ex As Exception
                OrderQuantity = 0
            End Try
            Try
                ReceivedQuantity = row.Cells("POQuantityReceivedColumn88").Value
            Catch ex As Exception
                ReceivedQuantity = 0
            End Try
            Try
                OpenQuantity = row.Cells("POQuantityOpenColumn88").Value
            Catch ex As Exception
                OpenQuantity = 0
            End Try
            '*************************************************************************
            If PurchaseOrderNumber = 0 Then
                'Skip
            Else
                If POStatus = "CLOSED" Then
                    'Update PO Lines
                    If ReceivedQuantity >= OrderQuantity Then
                        LineStatus = "CLOSED"
                    Else
                        LineStatus = "OPEN"
                    End If

                    Try
                        cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = PurchaseOrderNumber
                            .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = PurchaseOrderLine
                            .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                            .Add("@LineStatus", SqlDbType.VarChar).Value = LineStatus
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip Update
                    End Try
                End If
            End If
            '*************************************************************************

            PurchaseOrderNumber = 0
            PurchaseOrderLine = 0
            DivisionID = ""
            POStatus = ""
            LineStatus = ""
            OrderQuantity = 0
            ReceivedQuantity = 0
            OpenQuantity = 0
        Next

        MsgBox("Purchase Order Lines Updated.", MsgBoxStyle.OkOnly)
        ShowPurchaseLines()
    End Sub

    Private Sub cmdViewPOHeadersAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPOHeadersAddress.Click
        ShowPOHeaders()
        tabDatagrids.SelectedIndex = 2
    End Sub

    Public Sub GetShipAddressFromSO()
        Dim GetDefaultShippingStatement As String = "SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SalesOrderKey = @SalesOrderKey"
        Dim GetDefaultShippingCommand As New SqlCommand(GetDefaultShippingStatement, con)
        GetDefaultShippingCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = DatagridDivision
        GetDefaultShippingCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = DatagridSONumber

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetDefaultShippingCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ShipToName")) Then
                ShipName = ""
            Else
                ShipName = reader.Item("ShipToName")
            End If
            If IsDBNull(reader.Item("ShipToAddress1")) Then
                ShipAddress1 = ""
            Else
                ShipAddress1 = reader.Item("ShipToAddress1")
            End If
            If IsDBNull(reader.Item("ShipToAddress2")) Then
                ShipAddress2 = ""
            Else
                ShipAddress2 = reader.Item("ShipToAddress2")
            End If
            If IsDBNull(reader.Item("ShipToCity")) Then
                ShipCity = ""
            Else
                ShipCity = reader.Item("ShipToCity")
            End If
            If IsDBNull(reader.Item("ShipToState")) Then
                ShipState = ""
            Else
                ShipState = reader.Item("ShipToState")
            End If
            If IsDBNull(reader.Item("ShipToZip")) Then
                ShipZipCode = ""
            Else
                ShipZipCode = reader.Item("ShipToZip")
            End If
            If IsDBNull(reader.Item("ShipToCountry")) Then
                ShipCountry = ""
            Else
                ShipCountry = reader.Item("ShipToCountry")
            End If
        Else
            ShipState = ""
            ShipCountry = ""
            ShipZipCode = ""
            ShipCity = ""
            ShipAddress1 = ""
            ShipAddress2 = ""
            ShipName = ""
        End If
        reader.Close()
        con.Close()
    End Sub

    Public Sub GetShipAddressFromAddShipTo()
        Dim GetDefaultShippingStatement As String = "SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND ShipToID = @ShipToID"
        Dim GetDefaultShippingCommand As New SqlCommand(GetDefaultShippingStatement, con)
        GetDefaultShippingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DatagridDivision
        GetDefaultShippingCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = DatagridCustomer
        GetDefaultShippingCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = DatagridAddShipTo

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetDefaultShippingCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Name")) Then
                ShipName = ""
            Else
                ShipName = reader.Item("Name")
            End If
            If IsDBNull(reader.Item("Address1")) Then
                ShipAddress1 = ""
            Else
                ShipAddress1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                ShipAddress2 = ""
            Else
                ShipAddress2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                ShipCity = ""
            Else
                ShipCity = reader.Item("City")
            End If
            If IsDBNull(reader.Item("State")) Then
                ShipState = ""
            Else
                ShipState = reader.Item("State")
            End If
            If IsDBNull(reader.Item("Zip")) Then
                ShipZipCode = ""
            Else
                ShipZipCode = reader.Item("Zip")
            End If
            If IsDBNull(reader.Item("Country")) Then
                ShipCountry = ""
            Else
                ShipCountry = reader.Item("Country")
            End If
        Else
            ShipState = ""
            ShipCountry = ""
            ShipZipCode = ""
            ShipCity = ""
            ShipAddress1 = ""
            ShipAddress2 = ""
            ShipName = ""
        End If
        reader.Close()
        con.Close()

    End Sub

    Public Sub GetShipAddressFromCustomer()
        Dim GetDefaultShippingStatement As String = "SELECT * FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
        Dim GetDefaultShippingCommand As New SqlCommand(GetDefaultShippingStatement, con)
        GetDefaultShippingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DatagridDivision
        GetDefaultShippingCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = DatagridCustomer

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetDefaultShippingCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CustomerName")) Then
                ShipName = ""
            Else
                ShipName = reader.Item("CustomerName")
            End If
            If IsDBNull(reader.Item("ShipToAddress1")) Then
                ShipAddress1 = ""
            Else
                ShipAddress1 = reader.Item("ShipToAddress1")
            End If
            If IsDBNull(reader.Item("ShipToAddress2")) Then
                ShipAddress2 = ""
            Else
                ShipAddress2 = reader.Item("ShipToAddress2")
            End If
            If IsDBNull(reader.Item("ShipToCity")) Then
                ShipCity = ""
            Else
                ShipCity = reader.Item("ShipToCity")
            End If
            If IsDBNull(reader.Item("ShipToState")) Then
                ShipState = ""
            Else
                ShipState = reader.Item("ShipToState")
            End If
            If IsDBNull(reader.Item("ShipToZip")) Then
                ShipZipCode = ""
            Else
                ShipZipCode = reader.Item("ShipToZip")
            End If
            If IsDBNull(reader.Item("ShipToCountry")) Then
                ShipCountry = ""
            Else
                ShipCountry = reader.Item("ShipToCountry")
            End If
        Else
            ShipState = ""
            ShipCountry = ""
            ShipZipCode = ""
            ShipCity = ""
            ShipAddress1 = ""
            ShipAddress2 = ""
            ShipName = ""
        End If
        reader.Close()
        con.Close()
    End Sub

    Public Sub GetShipAddressFromDivision()
        Dim GetDefaultShippingStatement As String = "SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim GetDefaultShippingCommand As New SqlCommand(GetDefaultShippingStatement, con)
        GetDefaultShippingCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = DatagridDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetDefaultShippingCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CompanyName")) Then
                ShipName = ""
            Else
                ShipName = reader.Item("CompanyName")
            End If
            If IsDBNull(reader.Item("Address1")) Then
                ShipAddress1 = ""
            Else
                ShipAddress1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                ShipAddress2 = ""
            Else
                ShipAddress2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                ShipCity = ""
            Else
                ShipCity = reader.Item("City")
            End If
            If IsDBNull(reader.Item("State")) Then
                ShipState = ""
            Else
                ShipState = reader.Item("State")
            End If
            If IsDBNull(reader.Item("ZipCode")) Then
                ShipZipCode = ""
            Else
                ShipZipCode = reader.Item("ZipCode")
            End If
            If IsDBNull(reader.Item("Country")) Then
                ShipCountry = ""
            Else
                ShipCountry = reader.Item("Country")
            End If
        Else
            ShipState = ""
            ShipCountry = ""
            ShipZipCode = ""
            ShipCity = ""
            ShipAddress1 = ""
            ShipAddress2 = ""
            ShipName = ""
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub cmdUpdatePOAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdatePOAddress.Click
        Dim PurchaseOrderNumber As Integer = 0
        Dim POCustomer As String = ""
        Dim POSalesOrder As Integer = 0
        Dim POShipTo As String = ""
        Dim DivisionID As String = ""

        For Each row As DataGridViewRow In dgvPOHeaders.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                PurchaseOrderNumber = row.Cells("PurchaseOrderHeaderKeyColumn66").Value
            Catch ex As Exception
                PurchaseOrderNumber = 0
            End Try
            Try
                POCustomer = row.Cells("PODropShipCustomerIDColumn66").Value
            Catch ex As Exception
                POCustomer = ""
            End Try
            Try
                POSalesOrder = row.Cells("DropShipSalesOrderNumberColumn66").Value
            Catch ex As Exception
                POSalesOrder = 0
            End Try
            Try
                POShipTo = row.Cells("POAdditionalShipToColumn66").Value
            Catch ex As Exception
                POShipTo = ""
            End Try
            Try
                DivisionID = row.Cells("DivisionIDColumn66").Value
            Catch ex As Exception
                DivisionID = ""
            End Try

            DatagridAddShipTo = POShipTo
            DatagridCustomer = POCustomer
            DatagridDivision = DivisionID
            DatagridSONumber = POSalesOrder
            '*************************************************************************
            If PurchaseOrderNumber = 0 Then
                'Skip
            Else
                If POSalesOrder > 0 Then
                    GetShipAddressFromSO()
                Else
                    If POCustomer = "" And POShipTo = "" Then
                        GetShipAddressFromDivision()
                    ElseIf POCustomer <> "" And POShipTo <> "" Then
                        GetShipAddressFromAddShipTo()
                    ElseIf POCustomer <> "" And POShipTo = "" Then
                        GetShipAddressFromCustomer()
                    Else
                        GetShipAddressFromDivision()
                    End If
                End If

                Try
                    cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET ShipName = @ShipName, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZipCode = @ShipZipCode, ShipCountry = @ShipCountry WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = PurchaseOrderNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                        .Add("@ShipName", SqlDbType.VarChar).Value = ShipName
                        .Add("@ShipAddress1", SqlDbType.VarChar).Value = ShipAddress1
                        .Add("@ShipAddress2", SqlDbType.VarChar).Value = ShipAddress2
                        .Add("@ShipCity", SqlDbType.VarChar).Value = ShipCity
                        .Add("@ShipState", SqlDbType.VarChar).Value = ShipState
                        .Add("@ShipZipCode", SqlDbType.VarChar).Value = ShipZipCode
                        .Add("@ShipCountry", SqlDbType.VarChar).Value = ShipCountry
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip
                End Try
            End If
            '*************************************************************************

            PurchaseOrderNumber = 0
            POCustomer = ""
            DivisionID = ""
            POSalesOrder = 0
            POShipTo = ""
            DivisionID = ""
        Next

        MsgBox("Purchase Order Headers Updated.", MsgBoxStyle.OkOnly)
        ShowPOHeaders()
    End Sub

    Private Sub cmdViewDropShipSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewDropShipSO.Click
        ShowSalesOrdersForDropShips()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateDropShipSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateDropShipSO.Click
        Dim SONumber As Integer = 0
        Dim GetPONumber As Integer = 0
        Dim DivisionKey As String = ""

        For Each row As DataGridViewRow In dgvSOTable.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                SONumber = row.Cells("SOSalesOrderKeyColumn").Value
            Catch ex As Exception
                SONumber = 0
            End Try
            Try
                DivisionKey = row.Cells("SODivisionKeyColumn").Value
            Catch ex As Exception
                DivisionKey = ""
            End Try

            Dim GetPONumberStatement As String = "SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DropShipSalesOrderNumber = @DropShipSalesOrderNumber AND DivisionID = @DivisionID"
            Dim GetPONumberCommand As New SqlCommand(GetPONumberStatement, con)
            GetPONumberCommand.Parameters.Add("@DropShipSalesOrderNumber", SqlDbType.VarChar).Value = SONumber
            GetPONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionKey

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPONumber = CInt(GetPONumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetPONumber = 0
            End Try
            con.Close()

            If GetPONumber <> 0 Then
                Try
                    'UPDATE SO
                    cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET DropShipPONumber = @DropShipPONumber WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = SONumber
                        .Add("@DivisionKey", SqlDbType.VarChar).Value = DivisionKey
                        .Add("@DropShipPONumber", SqlDbType.VarChar).Value = GetPONumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Continue without updating batch
                End Try
            End If

            GetPONumber = 0
            SONumber = 0
            DivisionKey = ""
        Next

        MsgBox("Sales Orders updated", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewItemListTWD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewItemListTWD.Click
        ShowTWDItemList()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateItemListTWD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateItemListTWD.Click
        Dim ItemID As String = ""
        Dim ShortDescription As String = ""
        Dim LongDescription As String = ""
        Dim PieceWeight As Double = 0
        Dim BoxCount As Integer = 0
        Dim PalletCount As Integer = 0
        Dim FOXNumber As Integer = 0
        Dim BoxType As String = ""
        Dim NominalDiameter As Double = 0
        Dim NominalLength As Double = 0
        Dim BoxWeight As Integer = 0
        Dim SafetyDataSheet As String = ""

        For Each row As DataGridViewRow In dgvTWDItemList.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                ItemID = row.Cells("ItemIDColumn26").Value
            Catch ex As Exception
                ItemID = ""
            End Try
            'Try
            'ShortDescription = row.Cells("ShortDescriptionColumn26").Value
            'Catch ex As Exception
            'ShortDescription = ""
            'End Try
            'Try
            'LongDescription = row.Cells("LongDescriptionColumn26").Value
            'Catch ex As Exception
            'LongDescription = ""
            'End Try
            'Try
            'PieceWeight = row.Cells("PieceWeightColumn26").Value
            'Catch ex As Exception
            'PieceWeight = 0
            'End Try
            'Try
            'BoxCount = row.Cells("BoxCountColumn26").Value
            'Catch ex As Exception
            'BoxCount = 0
            'End Try
            'Try
            'PalletCount = row.Cells("PalletCountColumn26").Value
            'Catch ex As Exception
            '    PalletCount = 0
            'End Try
            'Try
            '    FOXNumber = row.Cells("FOXNumberColumn26").Value
            'Catch ex As Exception
            '    FOXNumber = 0
            'End Try
            'Try
            '    BoxType = row.Cells("BoxTypeColumn26").Value
            'Catch ex As Exception
            '    BoxType = ""
            'End Try
            'Try
            'NominalDiameter = row.Cells("NominalDiameterColumn26").Value
            ' Catch ex As Exception
            'NominalDiameter = 0
            'End Try
            'Try
            'NominalLength = row.Cells("NominalLengthColumn26").Value
            ' Catch ex As Exception
            ' NominalLength = 0
            'End Try
            ' Try
            ' BoxWeight = row.Cells("BoxWeightColumn26").Value
            'Catch ex As Exception
            'BoxWeight = 0
            'End Try
            'Try
            'SafetyDataSheet = row.Cells("SafetyDataSheetColumn26").Value
            'Catch ex As Exception
            'SafetyDataSheet = ""
            'End Try

            'Get Item Details from TWD Item List
            Dim GetItemDetailsStatement As String = "SELECT * FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetItemDetailsCommand As New SqlCommand(GetItemDetailsStatement, con)
            GetItemDetailsCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = ItemID
            GetItemDetailsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = GetItemDetailsCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("PieceWeight")) Then
                    PieceWeight = 0
                Else
                    PieceWeight = reader.Item("PieceWeight")
                End If
                If IsDBNull(reader.Item("BoxCount")) Then
                    BoxCount = 0
                Else
                    BoxCount = reader.Item("BoxCount")
                End If
                If IsDBNull(reader.Item("PalletCount")) Then
                    PalletCount = 0
                Else
                    PalletCount = reader.Item("PalletCount")
                End If
                If IsDBNull(reader.Item("FOXNumber")) Then
                    FOXNumber = 0
                Else
                    FOXNumber = reader.Item("FOXNumber")
                End If
                If IsDBNull(reader.Item("NominalDiameter")) Then
                    NominalDiameter = 0
                Else
                    NominalDiameter = reader.Item("NominalDiameter")
                End If
                If IsDBNull(reader.Item("NominalLength")) Then
                    NominalLength = 0
                Else
                    NominalLength = reader.Item("NominalLength")
                End If
                If IsDBNull(reader.Item("SafetyDataSheet")) Then
                    SafetyDataSheet = ""
                Else
                    SafetyDataSheet = reader.Item("SafetyDataSheet")
                End If
                If IsDBNull(reader.Item("BoxWeight")) Then
                    BoxWeight = 0
                Else
                    BoxWeight = reader.Item("BoxWeight")
                End If
                If IsDBNull(reader.Item("BoxType")) Then
                    BoxType = ""
                Else
                    BoxType = reader.Item("BoxType")
                End If
                If IsDBNull(reader.Item("LongDescription")) Then
                    LongDescription = ""
                Else
                    LongDescription = reader.Item("LongDescription")
                End If
            Else
                PieceWeight = 0
                BoxCount = 0
                PalletCount = 0
                FOXNumber = 0
                NominalDiameter = 0
                NominalLength = 0
                SafetyDataSheet = ""
                BoxWeight = 0
                BoxType = ""
                LongDescription = ""
            End If
            reader.Close()
            con.Close()

            If BoxWeight = 0 Then
                BoxWeight = PieceWeight * BoxCount
                BoxWeight = Math.Round(BoxWeight, 0)
            End If

            'If SafetyDataSheet = "" Then
            '    SafetyDataSheet = "Steel Weld Studs"
            'End If

            Try
                'UPDATE Item List
                cmd = New SqlCommand("UPDATE ItemList SET PieceWeight = @PieceWeight, BoxCount = @BoxCount, PalletCount = @PalletCount, FOXNumber = @FOXNumber, BoxType = @BoxType, NominalDiameter = @NominalDiameter, NominalLength = @NominalLength, SafetyDataSheet = @SafetyDataSheet, BoxWeight = @BoxWeight, LongDescription = @LongDescription WHERE ItemID = @ItemID", con)

                With cmd.Parameters
                    .Add("@ItemID", SqlDbType.VarChar).Value = ItemID
                    '.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                    '.Add("@ShortDescription", SqlDbType.VarChar).Value = ShortDescription
                    .Add("@LongDescription", SqlDbType.VarChar).Value = LongDescription
                    .Add("@PieceWeight", SqlDbType.VarChar).Value = PieceWeight
                    .Add("@BoxCount", SqlDbType.VarChar).Value = BoxCount
                    .Add("@PalletCount", SqlDbType.VarChar).Value = PalletCount
                    .Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber
                    .Add("@BoxType", SqlDbType.VarChar).Value = BoxType
                    .Add("@NominalDiameter", SqlDbType.VarChar).Value = NominalDiameter
                    .Add("@NominalLength", SqlDbType.VarChar).Value = NominalLength
                    .Add("@SafetyDataSheet", SqlDbType.VarChar).Value = SafetyDataSheet
                    .Add("@BoxWeight", SqlDbType.VarChar).Value = BoxWeight
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue without updating item list
            End Try

            ItemID = ""
            ShortDescription = ""
            LongDescription = ""
            PieceWeight = 0
            BoxCount = 0
            PalletCount = 0
            FOXNumber = 0
            BoxType = ""
            NominalDiameter = 0
            NominalLength = 0
            SafetyDataSheet = ""
            BoxWeight = 0
        Next

        MsgBox("Item List updated", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewARPaymentCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewARPaymentCompare.Click
        ShowARPaymentCompare()
        tabDatagrids.SelectedIndex = 2
    End Sub

    Private Sub cmdUpdateARPaymentCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateARPaymentCompare.Click
        Dim CustomerID As String = ""
        Dim DivisionID As String = ""
        Dim PaymentID As Integer = 0
        Dim PaymentLineNumber As Integer = 0
        Dim PaymentAmount As Double = 0
        Dim InvoiceNumber As Integer = 0

        For Each row As DataGridViewRow In dgvARPaymentCompare.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                CustomerID = row.Cells("CustomerIDColumn77").Value
            Catch ex As Exception
                CustomerID = ""
            End Try
            Try
                DivisionID = row.Cells("DivisionIDColumn77").Value
            Catch ex As Exception
                DivisionID = ""
            End Try
            Try
                PaymentID = row.Cells("PaymentIDColumn77").Value
            Catch ex As Exception
                PaymentID = 0
            End Try
            Try
                PaymentLineNumber = row.Cells("PaymentLineNumberColumn77").Value
            Catch ex As Exception
                PaymentLineNumber = 0
            End Try
            Try
                PaymentAmount = row.Cells("PaymentAmountColumn77").Value
            Catch ex As Exception
                PaymentAmount = 0
            End Try
            Try
                InvoiceNumber = row.Cells("InvoiceNumberColumn77").Value
            Catch ex As Exception
                InvoiceNumber = 0
            End Try
    
            Try
                'UPDATE Line Table
                cmd = New SqlCommand("UPDATE ARPaymentLines SET ARInvoiceNumber = ARInvoiceNumber, PaymentAmount = @PaymentAmount, DivisionID = @DivisionID WHERE PaymentID = @PaymentID AND LineNumber = @LineNumber", con)

                With cmd.Parameters
                    .Add("@PaymentID", SqlDbType.VarChar).Value = PaymentID
                    .Add("@LineNumber", SqlDbType.VarChar).Value = PaymentLineNumber
                    .Add("@ARInvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                    .Add("@PaymentAmount", SqlDbType.VarChar).Value = PaymentAmount
                    .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue without updating item list
            End Try
            '**********************************************************************************************************
            Dim SumPaymentAmount As Double = 0

            Dim SumPaymentAmountStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLines WHERE PaymentID = @PaymentID"
            Dim SumPaymentAmountCommand As New SqlCommand(SumPaymentAmountStatement, con)
            SumPaymentAmountCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = PaymentID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumPaymentAmount = CDbl(SumPaymentAmountCommand.ExecuteScalar)
            Catch ex As Exception
                SumPaymentAmount = 0
            End Try
            con.Close()

            Try
                'UPDATE Header Table
                cmd = New SqlCommand("UPDATE ARPaymentLog SET PaymentAmount = PaymentAmount, DivisionID = @DivisionID WHERE PaymentID = @PaymentID", con)

                With cmd.Parameters
                    .Add("@PaymentID", SqlDbType.VarChar).Value = PaymentID
                    .Add("@PaymentAmount", SqlDbType.VarChar).Value = SumPaymentAmount
                    .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue without updating item list
            End Try

            SumPaymentAmount = 0
            DivisionID = ""
            CustomerID = ""
            PaymentID = 0
            PaymentLineNumber = 0
            InvoiceNumber = 0
            PaymentAmount = 0
        Next

        MsgBox("AR Payment Line / Log updated", MsgBoxStyle.OkOnly)

    End Sub

    Private Sub cmdViewWireYard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewWireYard.Click
        ShowWireYard()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateWireYard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateWireYard.Click
        Dim SteelReturnKey As Integer = 0
        Dim SteelCost As Double = 0
        Dim SteelReturnDate As String = ""
        Dim SteelRMID As String = ""
        Dim SteelReturnWeight As Double = 0
        Dim SteelExtendedCost As Double = 0

        For Each row As DataGridViewRow In dgvWireYard.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                SteelReturnKey = row.Cells("SteelReturnKeyColumn99").Value
            Catch ex As Exception
                SteelReturnKey = 0
            End Try
            Try
                SteelRMID = row.Cells("RMIDColumn99").Value
            Catch ex As Exception
                SteelRMID = ""
            End Try
            Try
                SteelReturnDate = row.Cells("ReturnDateColumn99").Value
            Catch ex As Exception
                SteelReturnDate = ""
            End Try
            Try
                SteelReturnWeight = row.Cells("ReturnWeightColumn99").Value
            Catch ex As Exception
                SteelReturnWeight = 0
            End Try

            'Get Steel Cost
            Dim GetSteelCost As Double = 0

            Dim GetSteelCostStatement As String = "SELECT MAX(SteelCostPerPound) FROM SteelCostingTable WHERE RMID = @RMID AND CostingDate = @CostingDate"
            Dim GetSteelCostCommand As New SqlCommand(GetSteelCostStatement, con)
            GetSteelCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = SteelRMID
            GetSteelCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = SteelReturnDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetSteelCost = CDbl(GetSteelCostCommand.ExecuteScalar)
            Catch ex As Exception
                GetSteelCost = 0
            End Try
            con.Close()

            If GetSteelCost = 0 Then
                Dim GetSteelCost2Statement As String = "SELECT MAX(SteelCost) FROM SteelTransactionTable WHERE RMID = @RMID AND SteelTransactionDate = @SteelTransactionDate"
                Dim GetSteelCost2Command As New SqlCommand(GetSteelCost2Statement, con)
                GetSteelCost2Command.Parameters.Add("@RMID", SqlDbType.VarChar).Value = SteelRMID
                GetSteelCost2Command.Parameters.Add("@SteelTransactionDate", SqlDbType.VarChar).Value = SteelReturnDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSteelCost = CDbl(GetSteelCost2Command.ExecuteScalar)
                Catch ex As Exception
                    GetSteelCost = 0
                End Try
                con.Close()
            End If

            SteelCost = GetSteelCost
            SteelExtendedCost = SteelCost * SteelReturnWeight
            SteelExtendedCost = Math.Round(SteelExtendedCost, 2)

            'Get Carbon, Steel Size from RMID
            'Dim SteelCarbon, SteelSize As String

            'Dim GetCarbonStatement As String = "SELECT Carbon FROM RawMaterialsTable WHERE RMID = @RMID"
            'Dim GetCarbonCommand As New SqlCommand(GetCarbonStatement, con)
            'GetCarbonCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = SteelRMID

            'Dim GetSteelSizeStatement As String = "SELECT SteelSize FROM RawMaterialsTable WHERE RMID = @RMID"
            'Dim GetSteelSizeCommand As New SqlCommand(GetSteelSizeStatement, con)
            'GetSteelSizeCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = SteelRMID

            'If con.State = ConnectionState.Closed Then con.Open()
            'Try
            '    SteelCarbon = CStr(GetCarbonCommand.ExecuteScalar)
            'Catch ex As Exception
            '    SteelCarbon = ""
            'End Try
            'Try
            '    SteelSize = CStr(GetSteelSizeCommand.ExecuteScalar)
            'Catch ex As Exception
            '    SteelSize = ""
            'End Try
            'con.Close()

            ''Get Coil ID and Heat Number to update Wire Yard Table
            'Dim CoilID, HeatNumber As String

            'Dim GetCoilIDStatement As String = "SELECT CoilID FROM CharterSteelCoilIdentification WHERE Carbon = @Carbon AND SteelSize = @SteelSize AND Weight = @Weight"
            'Dim GetCoilIDCommand As New SqlCommand(GetCoilIDStatement, con)
            'GetCoilIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = SteelCarbon
            'GetCoilIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize
            'GetCoilIDCommand.Parameters.Add("@Weight", SqlDbType.VarChar).Value = SteelReturnWeight

            'Dim GetHeatNumberStatement As String = "SELECT HeatNumber FROM CharterSteelCoilIdentification WHERE Carbon = @Carbon AND SteelSize = @SteelSize AND Weight = @Weight"
            'Dim GetHeatNumberCommand As New SqlCommand(GetHeatNumberStatement, con)
            'GetHeatNumberCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = SteelCarbon
            'GetHeatNumberCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = SteelSize
            'GetHeatNumberCommand.Parameters.Add("@Weight", SqlDbType.VarChar).Value = SteelReturnWeight

            'If con.State = ConnectionState.Closed Then con.Open()
            'Try
            '    CoilID = CStr(GetCoilIDCommand.ExecuteScalar)
            'Catch ex As Exception
            '    CoilID = ""
            'End Try
            'Try
            '    HeatNumber = CStr(GetHeatNumberCommand.ExecuteScalar)
            'Catch ex As Exception
            '    HeatNumber = ""
            'End Try
            'con.Close()


            Try
                'UPDATE Line Table
                cmd = New SqlCommand("UPDATE SteelYardEntryTable SET SteelCost = @SteelCost, ExtendedCost = @ExtendedCost WHERE SteelReturnKey = @SteelReturnKey AND RMID = @RMID", con)

                With cmd.Parameters
                    .Add("@SteelReturnKey", SqlDbType.VarChar).Value = SteelReturnKey
                    .Add("@RMID", SqlDbType.VarChar).Value = SteelRMID
                    .Add("@SteelCost", SqlDbType.VarChar).Value = SteelCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = SteelExtendedCost
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue without updating item list
            End Try


            SteelReturnKey = 0
            SteelRMID = ""
            SteelCost = 0
            SteelExtendedCost = 0
        Next

        MsgBox("Wire Yard Table updated", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewSteelUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewSteelUsage.Click
        ShowSteelUsage()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateSteelUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateSteelUsage.Click
        Dim SteelUsageKey As Integer = 0
        Dim SteelCost As Double = 0
        Dim SteelUsageDate As String = ""
        Dim SteelRMID As String = ""
        Dim SteelUsageWeight As Double = 0
        Dim SteelExtendedCost As Double = 0

        For Each row As DataGridViewRow In dgvSteelUsage.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                SteelUsageKey = row.Cells("SteelUsageKeyColumn33").Value
            Catch ex As Exception
                SteelUsageKey = 0
            End Try
            Try
                SteelRMID = row.Cells("RMIDColumn33").Value
            Catch ex As Exception
                SteelRMID = ""
            End Try
            Try
                SteelUsageDate = row.Cells("UsageDateColumn33").Value
            Catch ex As Exception
                SteelUsageDate = ""
            End Try
            Try
                SteelUsageWeight = row.Cells("UsageWeightColumn33").Value
            Catch ex As Exception
                SteelUsageWeight = 0
            End Try

            'Get Steel Cost
            Dim GetSteelCost As Double = 0

            Dim GetSteelCostStatement As String = "SELECT MAX(SteelCostPerPound) FROM SteelCostingTable WHERE RMID = @RMID AND CostingDate = @CostingDate"
            Dim GetSteelCostCommand As New SqlCommand(GetSteelCostStatement, con)
            GetSteelCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = SteelRMID
            GetSteelCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = SteelUsageDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetSteelCost = CDbl(GetSteelCostCommand.ExecuteScalar)
            Catch ex As Exception
                GetSteelCost = 0
            End Try
            con.Close()

            If GetSteelCost = 0 Then
                Dim GetSteelCost2Statement As String = "SELECT MAX(SteelCost) FROM SteelTransactionTable WHERE RMID = @RMID AND SteelTransactionDate = @SteelTransactionDate"
                Dim GetSteelCost2Command As New SqlCommand(GetSteelCost2Statement, con)
                GetSteelCost2Command.Parameters.Add("@RMID", SqlDbType.VarChar).Value = SteelRMID
                GetSteelCost2Command.Parameters.Add("@SteelTransactionDate", SqlDbType.VarChar).Value = SteelUsageDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSteelCost = CDbl(GetSteelCost2Command.ExecuteScalar)
                Catch ex As Exception
                    GetSteelCost = 0
                End Try
                con.Close()
            End If

            SteelCost = GetSteelCost
            SteelExtendedCost = SteelCost * SteelUsageWeight
            SteelExtendedCost = Math.Round(SteelExtendedCost, 2)

            Try
                'UPDATE Line Table
                cmd = New SqlCommand("UPDATE SteelUsageTable SET SteelCost = @SteelCost, ExtendedCost = @ExtendedCost WHERE SteelUsageKey = @SteelUsageKey AND RMID = @RMID", con)

                With cmd.Parameters
                    .Add("@SteelUsageKey", SqlDbType.VarChar).Value = SteelUsageKey
                    .Add("@RMID", SqlDbType.VarChar).Value = SteelRMID
                    .Add("@SteelCost", SqlDbType.VarChar).Value = SteelCost
                    .Add("@ExtendedCost", SqlDbType.VarChar).Value = SteelExtendedCost
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue without updating item list
            End Try

            SteelUsageKey = 0
            SteelRMID = ""
            SteelCost = 0
            SteelExtendedCost = 0
        Next

        MsgBox("Steel Usage Table updated", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewBuildTiers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewBuildTiers.Click
        ShowCostTiersForBuilds()
        tabDatagrids.SelectedIndex = 3
    End Sub

    Private Sub cmdUpdateBuildTiers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateBuildTiers.Click
        Dim TransactionNumber As Integer = 0
        Dim CostQuantity As Double = 0
        Dim CostingDate As String = ""
        Dim DivisionID As String = ""
        Dim GetReferenceNumber As Integer = 0
        Dim GetReferenceLine As Integer = 0
        Dim CostingPartNumber As String = ""

        For Each row As DataGridViewRow In dgvInventoryCostingEdit.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                TransactionNumber = row.Cells("TransactionNumberColumn55").Value
            Catch ex As Exception
                TransactionNumber = 0
            End Try
            Try
                CostQuantity = row.Cells("CostQuantityColumn55").Value
            Catch ex As Exception
                CostQuantity = 0
            End Try
            Try
                CostingDate = row.Cells("CostingDateColumn55").Value
            Catch ex As Exception
                CostingDate = ""
            End Try
            Try
                DivisionID = row.Cells("DivisionIDColumn55").Value
            Catch ex As Exception
                DivisionID = ""
            End Try
            Try
                CostingPartNumber = row.Cells("PartNumberColumn55").Value
            Catch ex As Exception
                CostingPartNumber = ""
            End Try
            '*************************************************************************
            'Get data from inventory transactions if possible - if not, skip
            Dim GetReferenceNumberStatement As String = "SELECT MIN(BuildTransactionNumber) FROM AssemblyBuildQuery WHERE DivisionID = @DivisionID AND ComponentPartNumber = @ComponentPartNumber AND BuildDate = @BuildDate"
            Dim GetReferenceNumberCommand As New SqlCommand(GetReferenceNumberStatement, con)
            GetReferenceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            GetReferenceNumberCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = CostingPartNumber
            GetReferenceNumberCommand.Parameters.Add("@BuildDate", SqlDbType.VarChar).Value = CostingDate

            Dim GetReferenceLineNumberStatement As String = "SELECT MIN(BuildLineNumber) FROM AssemblyBuildQuery WHERE DivisionID = @DivisionID AND ComponentPartNumber = @ComponentPartNumber AND BuildDate = @BuildDate"
            Dim GetReferenceLineNumberCommand As New SqlCommand(GetReferenceLineNumberStatement, con)
            GetReferenceLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
            GetReferenceLineNumberCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = CostingPartNumber
            GetReferenceLineNumberCommand.Parameters.Add("@BuildDate", SqlDbType.VarChar).Value = CostingDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetReferenceNumber = CInt(GetReferenceNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetReferenceNumber = 0
            End Try
            Try
                GetReferenceLine = CInt(GetReferenceLineNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetReferenceLine = 0
            End Try
            con.Close()

            If GetReferenceNumber = 0 Then
                'Skip
            Else
                'Update Reference Numbers
                Try
                    cmd = New SqlCommand("UPDATE InventoryCosting SET ReferenceNumber = @ReferenceNumber, ReferenceLine = @ReferenceLine WHERE PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PartNumber", SqlDbType.VarChar).Value = CostingPartNumber
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = GetReferenceNumber
                        .Add("@ReferenceLine", SqlDbType.VarChar).Value = GetReferenceLine
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip Update
                End Try
            End If

            GetReferenceLine = 0
            GetReferenceNumber = 0
            CostingPartNumber = ""
            CostingDate = ""
            DivisionID = ""
            CostQuantity = 0
            TransactionNumber = 0
        Next

        MsgBox("Cost Tiers Repaired.", MsgBoxStyle.OkOnly)
        ShowCostTiersForBuilds()
    End Sub

    Private Sub cmdViewSteelCostTier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewSteelCostTier.Click
        ShowSteelCostTiers()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateSteelCostTier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateSteelCostTier.Click
        Dim TransactionNumber As Integer = 0
        Dim CostQuantity As Double = 0
        Dim CostingDate As String = ""
        Dim GetReferenceNumber As Integer = 0
        Dim GetReferenceLine As Integer = 0
        Dim CostingRMID As String = ""
        Dim GetTransactionNumber As Integer = 0

        For Each row As DataGridViewRow In dgvSteelCostingTable.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                TransactionNumber = row.Cells("TransactionNumberColumn66").Value
            Catch ex As Exception
                TransactionNumber = 0
            End Try
            Try
                CostQuantity = row.Cells("CostingQuantityColumn66").Value
            Catch ex As Exception
                CostQuantity = 0
            End Try
            Try
                CostingDate = row.Cells("CostingDateColumn66").Value
            Catch ex As Exception
                CostingDate = ""
            End Try
            Try
                CostingRMID = row.Cells("RMIDColumn66").Value
            Catch ex As Exception
                CostingRMID = ""
            End Try
            '*************************************************************************
            'Get data from inventory transactions if possible - if not, skip
            Dim GetTransactionNumberStatement As String = "SELECT MIN(TransactionNumber) FROM SteelTransactionTable WHERE RMID = @RMID AND Quantity = @Quantity AND SteelTransactionDate = @SteelTransactionDate"
            Dim GetTransactionNumberCommand As New SqlCommand(GetTransactionNumberStatement, con)
            GetTransactionNumberCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CostingRMID
            GetTransactionNumberCommand.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = CostQuantity
            GetTransactionNumberCommand.Parameters.Add("@SteelTransactionDate", SqlDbType.VarChar).Value = CostingDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetTransactionNumber = CInt(GetTransactionNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetTransactionNumber = 0
            End Try
            con.Close()

            Dim TransactionSteelCost As Double = 0

            Dim GetTransactionSteelCostStatement As String = "SELECT SteelCost FROM SteelTransactionTable WHERE RMID = @RMID AND TransactionNumber = @TransactionNumber"
            Dim GetTransactionSteelCostCommand As New SqlCommand(GetTransactionSteelCostStatement, con)
            GetTransactionSteelCostCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = CostingRMID
            GetTransactionSteelCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TransactionSteelCost = CDbl(GetTransactionSteelCostCommand.ExecuteScalar)
            Catch ex As Exception
                TransactionSteelCost = 0
            End Try
            con.Close()

            If TransactionSteelCost = 0 Then
                'Skip
            Else
                'Update Reference Numbers
                Try
                    cmd = New SqlCommand("UPDATE SteelCostingTable SET SteelCostPerPound = @SteelCostPerPound WHERE RMID = @RMID AND TransactionNumber = @TransactionNumber AND SteelCostPerPound = @SteelCostPerPound2", con)

                    With cmd.Parameters
                        .Add("@TransactionNumber", SqlDbType.VarChar).Value = TransactionNumber
                        .Add("@RMID", SqlDbType.VarChar).Value = CostingRMID
                        .Add("@SteelCostPerPound", SqlDbType.VarChar).Value = TransactionSteelCost
                        .Add("@SteelCostPerPound2", SqlDbType.VarChar).Value = 50
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip Update
                End Try
            End If

            TransactionSteelCost = 0
            GetTransactionNumber = 0
            CostingRMID = ""
            CostingDate = ""
            CostQuantity = 0
            TransactionNumber = 0
        Next

        MsgBox("Cost Tiers Repaired.", MsgBoxStyle.OkOnly)
        ShowSteelCostTiers()
    End Sub

    Private Sub cmdViewUPS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewUPS.Click
        ShowUPSData()
        tabDatagrids.SelectedIndex = 5
    End Sub

    Private Sub cmdDeleteUPS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteUPS.Click

        'Get Newest Pick Number that is pending
        Dim OldestPick As Integer = 0

        Dim GetOldestPendingPickStatement As String = "SELECT MIN(PickListHeaderKey) FROM PickListHeaderTable WHERE PLStatus = @PLStatus"
        Dim GetOldestPendingPickCommand As New SqlCommand(GetOldestPendingPickStatement, con)
        GetOldestPendingPickCommand.Parameters.Add("@PLStatus", SqlDbType.VarChar).Value = "PENDING"
   
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OldestPick = CInt(GetOldestPendingPickCommand.ExecuteScalar)
        Catch ex As Exception
            OldestPick = 0
        End Try
        con.Close()

        Try
            cmd = New SqlCommand("DELETE FROM UPSShippingData WHERE PickTicketNumber < @PickTicketNumber", con)

            With cmd.Parameters
                .Add("@PickTicketNumber", SqlDbType.VarChar).Value = OldestPick
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Skip Update
        End Try
    End Sub

    Private Sub cmdViewSerialLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewSerialLog.Click
        ShowSerialLog()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateSerialLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateSerialLog.Click
        Dim AssemblyPartNumber As String = ""
        Dim DivisionID As String = ""
        Dim BuildNumber As Integer = 0
        Dim SerialNumber As String = ""
        Dim ShipmentNumber As Integer = 0
        Dim InvoiceNumber As Integer = 0

        For Each row As DataGridViewRow In dgvSerialLog.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                AssemblyPartNumber = row.Cells("AssemblyPartNumber77Column").Value
            Catch ex As Exception
                AssemblyPartNumber = ""
            End Try
            Try
                DivisionID = row.Cells("DivisionID77Column").Value
            Catch ex As Exception
                DivisionID = ""
            End Try
            Try
                SerialNumber = row.Cells("SerialNumber77Column").Value
            Catch ex As Exception
                SerialNumber = ""
            End Try
            Try
                ShipmentNumber = row.Cells("ShipmentNumber77Column").Value
            Catch ex As Exception
                ShipmentNumber = 0
            End Try
            Try
                InvoiceNumber = row.Cells("InvoiceNumber77Column").Value
            Catch ex As Exception
                InvoiceNumber = 0
            End Try
            '**********************************************************************************************************
            Dim GetShipDate As String = ""
            Dim GetInvoiceDate As String = ""
            Dim GetShipmentNumber As Integer = 0
            Dim GetInvoiceNumber As Integer = 0

            If InvoiceNumber = 0 And ShipmentNumber <> 0 Then
                'Get Ship date only
                Dim GetShipDateStatement As String = "SELECT ShipDate FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
                Dim GetShipDateCommand As New SqlCommand(GetShipDateStatement, con)
                GetShipDateCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
        
                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetShipDate = CStr(GetShipDateCommand.ExecuteScalar)
                Catch ex As Exception
                    GetShipDate = ""
                End Try
                con.Close()

                Dim GetInvoiceNumberStatement As String = "SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
                Dim GetInvoiceNumberCommand As New SqlCommand(GetInvoiceNumberStatement, con)
                GetInvoiceNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetInvoiceNumber = CInt(GetInvoiceNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetInvoiceNumber = 0
                End Try
                con.Close()

                Try
                    'UPDATE Line Table
                    cmd = New SqlCommand("UPDATE AssemblySerialLog SET ShipmentDate = @ShipmentDate, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = AssemblyPartNumber
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                        .Add("@ShipmentDate", SqlDbType.VarChar).Value = GetShipDate
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = GetInvoiceNumber
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = GetShipDate
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Continue without updating item list
                End Try
            ElseIf InvoiceNumber = 0 And ShipmentNumber = 0 Then
                'Skip routine
            ElseIf InvoiceNumber <> 0 And ShipmentNumber = 0 Then
                Dim GetShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                Dim GetShipmentNumberCommand As New SqlCommand(GetShipmentNumberStatement, con)
                GetShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber

                Dim GetInvoiceDateStatement As String = "SELECT InvoiceDate FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                Dim GetInvoiceDateCommand As New SqlCommand(GetInvoiceDateStatement, con)
                GetInvoiceDateCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetShipmentNumber = CInt(GetShipmentNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetShipmentNumber = 0
                End Try
                Try
                    GetInvoiceDate = CStr(GetInvoiceDateCommand.ExecuteScalar)
                Catch ex As Exception
                    GetInvoiceDate = 0
                End Try
                con.Close()

                Dim GetShipDateStatement As String = "SELECT ShipDate FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
                Dim GetShipDateCommand As New SqlCommand(GetShipDateStatement, con)
                GetShipDateCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetShipDate = CStr(GetShipDateCommand.ExecuteScalar)
                Catch ex As Exception
                    GetShipDate = ""
                End Try
                con.Close()

                If GetShipmentNumber = 0 Then
                    'Update Invoice Date
                    Try
                        'UPDATE Line Table
                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET InvoiceDate = @InvoiceDate WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = AssemblyPartNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = GetInvoiceDate
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Continue without updating item list
                    End Try
                Else
                    Try
                        'UPDATE Line Table
                        cmd = New SqlCommand("UPDATE AssemblySerialLog SET ShipmentDate = @ShipmentDate, ShipmentNumber = @ShipmentNumber, InvoiceDate = @InvoiceDate WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = AssemblyPartNumber
                            .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = GetShipmentNumber
                            .Add("@ShipmentDate", SqlDbType.VarChar).Value = GetShipDate
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = GetInvoiceDate
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Continue without updating item list
                    End Try
                End If
            Else
                'Do nothing
            End If

            AssemblyPartNumber = ""
            SerialNumber = ""
            InvoiceNumber = 0
            ShipmentNumber = 0
            DivisionID = ""
            GetInvoiceDate = ""
            GetShipDate = ""
            GetShipmentNumber = 0
        Next

        MsgBox("Serial Log Updated.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim NewInventorySalesHistory As New InventorySalesHistory
        NewInventorySalesHistory.Show()
    End Sub

    Private Sub cmdViewOpenPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewOpenPO.Click
        ShowOpenPOs()
        tabDatagrids.SelectedIndex = 2
    End Sub

    Private Sub cmdCloseOpenPOs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseOpenPOs.Click
        Dim PONumber As Integer = 0
        Dim DivisionKey As String = ""
        Dim CountOpenLines As Integer = 0

        For Each row As DataGridViewRow In dgvOpenPOTable.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                PONumber = row.Cells("PurchaseOrderHeaderKeyColumn22").Value
            Catch ex As Exception
                PONumber = 0
            End Try
            Try
                DivisionKey = row.Cells("DivisionIDColumn22").Value
            Catch ex As Exception
                DivisionKey = 0
            End Try

            Dim CountOpenLinesStatement As String = "SELECT COUNT(PurchaseOrderHeaderKey) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID AND LineStatus = 'OPEN'"
            Dim CountOpenLinesCommand As New SqlCommand(CountOpenLinesStatement, con)
            CountOpenLinesCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = PONumber
            CountOpenLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionKey

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountOpenLines = CInt(CountOpenLinesCommand.ExecuteScalar)
            Catch ex As Exception
                CountOpenLines = 1
            End Try
            con.Close()

            If CountOpenLines > 0 Then
                'Skip
            Else
                Try
                    'UPDATE SO
                    cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = PONumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = DivisionKey
                        .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Continue without updating batch
                End Try
            End If

        Next

        MsgBox("Purchase Orders updated", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewLotFromFox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewLotFromFox.Click
        ShowLotFoxData()
        tabDatagrids.SelectedIndex = 0
    End Sub

    Private Sub cmdUpdateLotFromFox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateLotFromFox.Click
        Dim LotNumber As String = ""
        Dim FOXRawMaterialWeight, FOXScrapWeight, FOXFinishedWeight As Double

        For Each row As DataGridViewRow In dgvLotNumberTest.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                LotNumber = row.Cells("LotNumberColumn5").Value
            Catch ex As Exception
                LotNumber = 0
            End Try
            Try
                FOXRawMaterialWeight = row.Cells("FOXRawMaterialWeightColumn5").Value
            Catch ex As Exception
                FOXRawMaterialWeight = 0
            End Try
            Try
                FOXScrapWeight = row.Cells("FOXScrapWeightColumn5").Value
            Catch ex As Exception
                FOXScrapWeight = 0
            End Try
            Try
                FOXFinishedWeight = row.Cells("FOXFinishedWeightColumn5").Value
            Catch ex As Exception
                FOXFinishedWeight = 0
            End Try

            Try
                'UPDATE SO
                cmd = New SqlCommand("UPDATE LotNumber SET RawMaterialWeight = @RawMaterialWeight, ScrapWeight = @ScrapWeight, FinishedWeight = @FinishedWeight WHERE LotNumber = @LotNumber", con)

                With cmd.Parameters
                    .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                    .Add("@RawMaterialWeight", SqlDbType.VarChar).Value = FOXRawMaterialWeight
                    .Add("@ScrapWeight", SqlDbType.VarChar).Value = FOXScrapWeight
                    .Add("@FinishedWeight", SqlDbType.VarChar).Value = FOXFinishedWeight
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Continue without updating batch
            End Try
        Next

        MsgBox("Lot Numbers updated", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdTimeSlipRoster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimeSlipRoster.Click
        GlobalTimeSlipValidationDate = Today()
        GlobalTimeSlipValidation = ""

        Using NewTimeSlipRoster As New TimeSlipRoster
            Dim Result = NewTimeSlipRoster.ShowDialog()
        End Using
    End Sub

    Private Sub cmdCloseReceiversForAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseReceiversForAP.Click
        ShowReceiversForAP()
        tabDatagrids.SelectedIndex = 2
    End Sub

    Private Sub cmdUpdateReceiversForAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateReceiversForAP.Click
        Dim ReceiverNumber As Integer = 0
        Dim CountOpenLines As Integer = 0

        For Each row As DataGridViewRow In dgvReceiverLineQuery.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                ReceiverNumber = row.Cells("ReceivingHeaderKeyColumn96").Value
            Catch ex As Exception
                ReceiverNumber = 0
            End Try

            Dim CountOpenLinesStatement As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND SelectForInvoice <> 'CLOSED'"
            Dim CountOpenLinesCommand As New SqlCommand(CountOpenLinesStatement, con)
            CountOpenLinesCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountOpenLines = CInt(CountOpenLinesCommand.ExecuteScalar)
            Catch ex As Exception
                CountOpenLines = 0
            End Try
            con.Close()

            If CountOpenLines > 0 Then
                'Skip
            Else
                Try
                    'UPDATE SO
                    cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND Status = 'RECEIVED'", con)

                    With cmd.Parameters
                        .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                        .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Continue without updating batch
                End Try
            End If
        Next

        MsgBox("Receivers updated", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdViewHeatFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewHeatFiles.Click
        ShowHeatFilesInPullTests()
        tabDatagrids.SelectedIndex = 6
    End Sub

    Private Sub cmdUpdateHeatFileInPullTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateHeatFileInPullTest.Click
        If dgvSteelInPullTests.RowCount > 0 Then
            'Continue
        Else
            MsgBox("THere are no records to update", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Declare variables to be used to update table
        Dim RowPullTestNumber As String = ""
        Dim RowSteelTypeFromHeat As String = ""
        Dim RowSteelSizeFromHeat As String = ""
        Dim GetRMIDFromHeat As String = ""
        Dim RowHeatNumber As String = ""
        Dim CountHeatFiles As Integer = 0
        Dim HeatFileNumber As Integer = 0
        Dim FOXSteelType As String = ""
        Dim FOXSteelSize As String = ""

        For Each row As DataGridViewRow In dgvSteelInPullTests.Rows
            'Extract row data from the datagrid - one row at a time
            Try
                RowPullTestNumber = row.Cells("TestNumberColumn12").Value
            Catch ex As Exception
                RowPullTestNumber = ""
            End Try
            Try
                RowSteelTypeFromHeat = row.Cells("HeatSteelTypeColumn12").Value
            Catch ex As Exception
                RowSteelTypeFromHeat = ""
            End Try
            Try
                RowSteelSizeFromHeat = row.Cells("HeatSteelSizeColumn12").Value
            Catch ex As Exception
                RowSteelSizeFromHeat = ""
            End Try
            Try
                FOXSteelType = row.Cells("CarbonColumn12").Value
            Catch ex As Exception
                FOXSteelType = ""
            End Try
            Try
                FOXSteelSize = row.Cells("SteelSizeColumn12").Value
            Catch ex As Exception
                FOXSteelSize = ""
            End Try
            Try
                RowHeatNumber = row.Cells("HeatNumberColumn12").Value
            Catch ex As Exception
                RowHeatNumber = ""
            End Try

            'If the steel from the fox matches the steel from the heat, then write the heat file number to the pull test table
            If RowSteelSizeFromHeat = FOXSteelSize And RowSteelTypeFromHeat = FOXSteelType Then
                'Get Heat File Number
                Dim GetHeatFilesStatement As String = "SELECT HeatFileNumber FROM HeatNumberLog WHERE HeatNumber = @HeatNumber AND SteelType = @SteelType AND SteelSize = @SteelSize"
                Dim GetHeatFilesCommand As New SqlCommand(GetHeatFilesStatement, con)
                GetHeatFilesCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber
                GetHeatFilesCommand.Parameters.Add("@SteelType", SqlDbType.VarChar).Value = RowSteelTypeFromHeat
                GetHeatFilesCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = RowSteelSizeFromHeat

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    HeatFileNumber = CInt(GetHeatFilesCommand.ExecuteScalar)
                Catch ex As Exception
                    HeatFileNumber = 0
                End Try
                con.Close()

                'Update Pull Test Table
                Try
                    'UPDATE Pull Test Table
                    cmd = New SqlCommand("UPDATE PullTestData SET HeatFileNumber = @HeatFileNumber WHERE TestNumber = @TestNumber", con)

                    With cmd.Parameters
                        .Add("@TestNumber", SqlDbType.VarChar).Value = RowPullTestNumber
                        .Add("@HeatFileNumber", SqlDbType.VarChar).Value = HeatFileNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Continue without updating batch
                End Try
            End If

            ''Get RMID based on carbon and size from the heat number table
            'Dim GetRMIDStatement As String = "SELECT RMID FROM RawMaterialsTable WHERE Carbon = @Carbon AND SteelSize = @SteelSize"
            'Dim GetRMIDCommand As New SqlCommand(GetRMIDStatement, con)
            'GetRMIDCommand.Parameters.Add("@Carbon", SqlDbType.VarChar).Value = RowSteelTypeFromHeat
            'GetRMIDCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = RowSteelSizeFromHeat

            'If con.State = ConnectionState.Closed Then con.Open()
            'Try
            '    GetRMIDFromHeat = CStr(GetRMIDCommand.ExecuteScalar)
            'Catch ex As Exception
            '    GetRMIDFromHeat = ""
            'End Try
            'con.Close()

            ''Get Count of heat records for any one heat
            'Dim CountHeatFilesStatement As String = "SELECT COUNT(HeatFileNumber) FROM HeatNumberLog WHERE HeatNumber = @HeatNumber"
            'Dim CountHeatFilesCommand As New SqlCommand(CountHeatFilesStatement, con)
            'CountHeatFilesCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber

            'If con.State = ConnectionState.Closed Then con.Open()
            'Try
            '    CountHeatFiles = CInt(CountHeatFilesCommand.ExecuteScalar)
            'Catch ex As Exception
            '    CountHeatFiles = 0
            'End Try
            'con.Close()

            'If CountHeatFiles = 0 Then
            '    'Skip - cannot find heat number record
            'ElseIf CountHeatFiles = 1 Then
            '    'Get Heat File Number for the lone heat number
            '    Dim GetHeatFilesStatement As String = "SELECT HeatFileNumber FROM HeatNumberLog WHERE HeatNumber = @HeatNumber"
            '    Dim GetHeatFilesCommand As New SqlCommand(GetHeatFilesStatement, con)
            '    GetHeatFilesCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber

            '    If con.State = ConnectionState.Closed Then con.Open()
            '    Try
            '        HeatFileNumber = CInt(GetHeatFilesCommand.ExecuteScalar)
            '    Catch ex As Exception
            '        HeatFileNumber = 0
            '    End Try
            '    con.Close()

            '    'Update Pull Test Table
            '    Try
            '        'UPDATE Pull Test Table
            '        cmd = New SqlCommand("UPDATE PullTestData SET HeatFileNumber = @HeatFileNumber, RMID = @RMID WHERE TestNumber = @TestNumber", con)

            '        With cmd.Parameters
            '            .Add("@TestNumber", SqlDbType.VarChar).Value = RowPullTestNumber
            '            .Add("@HeatFileNumber", SqlDbType.VarChar).Value = HeatFileNumber
            '            .Add("@RMID", SqlDbType.VarChar).Value = GetRMIDFromHeat
            '        End With

            '        If con.State = ConnectionState.Closed Then con.Open()
            '        cmd.ExecuteNonQuery()
            '        con.Close()
            '    Catch ex As Exception
            '        'Continue without updating batch
            '    End Try
            'ElseIf CountHeatFiles > 1 Then
            '    Dim CountSteelSize, CountSteelType As Integer

            '    'If heat number has multiple heat records that are the same, write to Pull Test Table
            '    Dim GetCountHeatFilesStatement As String = "select COUNT(DISTINCT(HeatSteelSize)) as CountSteelSize, COUNT(DISTINCT(HeatSteelType)) as CountSteelType From PullTestCheckiSteelToHeat where HeatNumber = @HeatNumber"
            '    Dim GetCountHeatFilesCommand As New SqlCommand(GetCountHeatFilesStatement, con)
            '    GetCountHeatFilesCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber

            '    If con.State = ConnectionState.Closed Then con.Open()
            '    Dim reader As SqlDataReader = GetCountHeatFilesCommand.ExecuteReader()
            '    If reader.HasRows Then
            '        reader.Read()
            '        If IsDBNull(reader.Item("CountSteelSize")) Then
            '            CountSteelSize = 0
            '        Else
            '            CountSteelSize = reader.Item("CountSteelSize")
            '        End If
            '        If IsDBNull(reader.Item("CountSteelType")) Then
            '            CountSteelType = 0
            '        Else
            '            CountSteelType = reader.Item("CountSteelType")
            '        End If
            '    Else
            '        CountSteelSize = 0
            '        CountSteelType = 0
            '    End If
            '    reader.Close()
            '    con.Close()

            '    If CountSteelSize = 1 And CountSteelType = 1 Then
            '        'Get Heat File Number
            '        Dim GetHeatFilesStatement As String = "SELECT TOP 1 HeatFileNumber FROM HeatNumberLog WHERE HeatNumber = @HeatNumber"
            '        Dim GetHeatFilesCommand As New SqlCommand(GetHeatFilesStatement, con)
            '        GetHeatFilesCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = RowHeatNumber

            '        If con.State = ConnectionState.Closed Then con.Open()
            '        Try
            '            HeatFileNumber = CInt(GetHeatFilesCommand.ExecuteScalar)
            '        Catch ex As Exception
            '            HeatFileNumber = 0
            '        End Try
            '        con.Close()

            '        'Update Pull Test Table
            '        Try
            '            'UPDATE Pull Test Table
            '            cmd = New SqlCommand("UPDATE PullTestData SET HeatFileNumber = @HeatFileNumber, RMID = @RMID WHERE TestNumber = @TestNumber", con)

            '            With cmd.Parameters
            '                .Add("@TestNumber", SqlDbType.VarChar).Value = RowPullTestNumber
            '                .Add("@HeatFileNumber", SqlDbType.VarChar).Value = HeatFileNumber
            '                .Add("@RMID", SqlDbType.VarChar).Value = GetRMIDFromHeat
            '            End With

            '            If con.State = ConnectionState.Closed Then con.Open()
            '            cmd.ExecuteNonQuery()
            '            con.Close()
            '        Catch ex As Exception
            '            'Continue without updating batch
            '        End Try
            '    Else
            '        'Skip - can't make the choice
            '    End If
            'End If
        Next

        MsgBox("Update is finished.", MsgBoxStyle.OkOnly)
    End Sub
End Class