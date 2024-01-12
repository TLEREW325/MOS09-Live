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
Public Class PriceLookup
    Inherits System.Windows.Forms.Form

    Dim Suggest As SuggestDescriptionAPI

    'Price Level 1 = 100 to 199
    Dim P1 As Double = 0
    'Price Level 2 = 200 to 299
    Dim P2 As Double = 0
    'Price Level 3 = 300 to 399
    Dim P3 As Double = 0
    'Price Level 4 = 400 to 499
    Dim P4 As Double = 0
    'Price Level 5 = 500 to 749
    Dim P5 As Double = 0
    'Price Level 6 = 750 to 999
    Dim P6 As Double = 0
    'Price Level 7 = 1000 to 2499
    Dim P7 As Double = 0
    'Price Level 8 = 2500 to 4999
    Dim P8 As Double = 0
    'Price Level 9 = 5000 to 9999
    Dim P9 As Double = 0
    'Price Level 10 = 10000 to 24999
    Dim P10 As Double = 0
    'Price Level 11 = 25000 to 49999
    Dim P11 As Double = 0
    'Price Level 12 = 50000 to 99999
    Dim P12 As Double = 0
    'Price Level 13 = 100000 and higher
    Dim P13 As Double = 0

    Dim Vendor, LongDescription, GetItemClass As String
    Dim MTDQuantity, YTDQuantity, OpenPOQuantity, StandardCost, StandardPrice, QuantityPending, BoxWeight, PalletWeight, PieceWeight, LastSalesPrice, LastPurchaseCost, QuantityOnHand, ALBQOH, TORQOH, TFTQOH, TWEQOH, ATLQOH, HOUQOH, TFFQOH, TWDQOH, TFPQOH, CHTQOH, SLCQOH, CBSQOH, CGOQOH As Double
    Dim MaxDate, PalletPieces, BoxCount, PalletCount As Integer
    Dim LabelToolTip As New ToolTip
    Dim CustomerTerms As String = ""
    Dim CustomerHoldStatus As String = ""
    Dim CustomerACHoldStatus As String = ""

    'Variables to calculate MTD and YTD Sales
    Dim YearDate, MonthDate, BeginDate, EndDate As Date
    Dim YearOfYear, MonthOfYear, Year As Integer
    Dim strMonthOfYear, strYear As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub PriceLookup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalPartNumberLookup = ""
    End Sub

    Private Sub PriceLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblUpdatedPrice.Visible = False

        ClearData()
        ClearVariables()
        ClearLines()

        LoadPartNumber()
        LoadCustomerID()
        LoadCustomerName()
        LoadPartDescription()
        LoadLabelToolTip()

        Suggest = New SuggestDescriptionAPI(cboPartDescription, lstPartDescriptionSuggest, cboPartNumber, ds2.Copy())
        If GlobalPartNumberLookup = "" Then
            'Do nothing
        Else
            cboPartNumber.Text = GlobalPartNumberLookup
        End If
    End Sub

    Public Sub ClearLines()
        dgvSalesHistory.DataSource = Nothing
    End Sub

    Public Sub ShowSalesLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT TOP 15 SalesOrderDate, ItemID, SalesOrderKey, Quantity, Price, CustomerID FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND CustomerID = @CustomerID AND ItemID = @ItemID ORDER BY SalesOrderDate DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = EmployeeCompanyCode
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderLineQuery")
        dgvSalesHistory.DataSource = ds.Tables("SalesOrderLineQuery")
        con.Close()
    End Sub

    Public Sub ShowSalesLinesForAllCustomers()
        cmd = New SqlCommand("SELECT SalesOrderDate, ItemID, SalesOrderKey, Quantity, Price, CustomerID FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID ORDER BY SalesOrderDate DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = EmployeeCompanyCode
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderLineQuery")
        dgvSalesHistory.DataSource = ds.Tables("SalesOrderLineQuery")
        con.Close()
    End Sub

    Public Sub LoadPartNumber()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartDescription.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerID()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        cboCustomerID.DataSource = ds3.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        'Loads part number and description for specific division
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboCustomerName.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerData()
        'Get Data from Customer List Table
        Dim GetCustomerDataStatement As String = "SELECT * FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetCustomerDataCommand As New SqlCommand(GetCustomerDataStatement, con)
        GetCustomerDataCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        GetCustomerDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetCustomerDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PaymentTerms")) Then
                CustomerTerms = ""
            Else
                CustomerTerms = reader.Item("PaymentTerms")
            End If
            If IsDBNull(reader.Item("OnHoldStatus")) Then
                CustomerHoldStatus = ""
            Else
                CustomerHoldStatus = reader.Item("OnHoldStatus")
            End If
            If IsDBNull(reader.Item("AccountingHold")) Then
                CustomerACHoldStatus = ""
            Else
                CustomerACHoldStatus = reader.Item("AccountingHold")
            End If
        Else
            CustomerTerms = ""
            CustomerHoldStatus = ""
            CustomerACHoldStatus = ""
        End If
        reader.Close()
        con.Close()

        If CustomerHoldStatus = "YES" Then
            lblOnHoldStatus.Text = "Customer is on Credit Hold"
        Else
            lblOnHoldStatus.Text = ""
        End If
        If CustomerACHoldStatus = "YES" Then
            lblAccountingHold.Text = "Customer is on Accounting Hold"
        Else
            lblAccountingHold.Text = ""
        End If

        lblPaymentTerms.Text = "Payment Terms - " + CustomerTerms
    End Sub

    Public Sub LoadPricingReview()
        'Load values into Price Review
        Dim PricingLevel As String = ""

        Dim PricingLevelStatement As String = "SELECT PricingLevel FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
        Dim PricingLevelCommand As New SqlCommand(PricingLevelStatement, con)
        PricingLevelCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        PricingLevelCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PricingLevel = CStr(PricingLevelCommand.ExecuteScalar)
        Catch ex As Exception
            PricingLevel = 0
        End Try
        con.Close()

        lblPricingReview.Text = PricingLevel
    End Sub

    Public Sub LoadLabelToolTip()
        LabelToolTip.SetToolTip(lblUpdatedPrice, "The last sales price has been adjusted.")
        LabelToolTip.ToolTipTitle = "Adjusted Price"
        LabelToolTip.IsBalloon = False
        LabelToolTip.ToolTipIcon = ToolTipIcon.Info
        LabelToolTip.UseAnimation = False
    End Sub

    Public Sub ClearVariables()
        Vendor = ""
        LongDescription = ""
        GetItemClass = ""
        MTDQuantity = 0
        YTDQuantity = 0
        OpenPOQuantity = 0
        StandardCost = 0
        StandardPrice = 0
        QuantityPending = 0
        BoxWeight = 0
        PalletWeight = 0
        PieceWeight = 0
        LastSalesPrice = 0
        LastPurchaseCost = 0
        QuantityOnHand = 0
        TORQOH = 0
        TFTQOH = 0
        TWEQOH = 0
        ATLQOH = 0
        HOUQOH = 0
        TFFQOH = 0
        TWDQOH = 0
        TFPQOH = 0
        CHTQOH = 0
        SLCQOH = 0
        CBSQOH = 0
        CGOQOH = 0
        ALBQOH = 0
        MaxDate = 0
        PalletPieces = 0
        BoxCount = 0
        PalletCount = 0
        CustomerTerms = ""
        CustomerHoldStatus = ""
        CustomerACHoldStatus = ""
    End Sub

    Public Sub ClearData()
        txtPrice1.Clear()
        txtPrice2.Clear()
        txtPrice3.Clear()
        txtPrice4.Clear()
        txtPrice5.Clear()
        txtPrice6.Clear()
        txtPrice7.Clear()
        txtPrice8.Clear()
        txtPrice9.Clear()
        txtPrice10.Clear()
        txtPrice11.Clear()
        txtPrice12.Clear()
        txtPrice13.Clear()

        lblPricingReview.Text = ""
        lblAccountingHold.Text = ""
        lblOnHoldStatus.Text = ""
        lblPaymentTerms.Text = ""
        lblUpdatedPrice.Visible = False

        txtBoxCount.Clear()
        txtBoxWeight.Clear()
        txtLastPurchaseCost.Clear()
        txtLastSalesPrice.Clear()
        txtPalletCount.Clear()
        txtPalletPieces.Clear()
        txtPalletWeight.Clear()
        txtPieceWeight.Clear()
        txtQtyPending.Clear()
        txtStdCost.Clear()
        txtStdPrice.Clear()
        txtQuantityOnHand.Clear()
        txtOpenPOQuantity.Clear()
        txtMTDQuantity.Clear()
        txtYTDQuantity.Clear()
    End Sub

    Public Sub LoadPartData()
        StandardCost = 0
        StandardPrice=0

        Dim PieceWeightString As String = "SELECT PieceWeight FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PieceWeightCommand As New SqlCommand(PieceWeightString, con)
        PieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim BoxCountString As String = "SELECT BoxCount FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim BoxCountCommand As New SqlCommand(BoxCountString, con)
        BoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        BoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim BoxWeightString As String = "SELECT BoxWeight FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim BoxWeightCommand As New SqlCommand(BoxWeightString, con)
        BoxWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        BoxWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PalletCountString As String = "SELECT PalletCount FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PalletCountCommand As New SqlCommand(PalletCountString, con)
        PalletCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PalletCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PalletWeightString As String = "SELECT PalletWeight FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PalletWeightCommand As New SqlCommand(PalletWeightString, con)
        PalletWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PalletWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PalletPiecesString As String = "SELECT PalletPieces FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PalletPiecesCommand As New SqlCommand(PalletPiecesString, con)
        PalletPiecesCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PalletPiecesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim StandardCostString As String = "SELECT StandardCost FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim StandardCostCommand As New SqlCommand(StandardCostString, con)
        StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim StandardPriceString As String = "SELECT StandardPrice FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim StandardPriceCommand As New SqlCommand(StandardPriceString, con)
        StandardPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        StandardPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim ItemClassString As String = "SELECT ItemClass FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ItemClassCommand As New SqlCommand(ItemClassString, con)
        ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PieceWeight = CDbl(PieceWeightCommand.ExecuteScalar)
        Catch ex As Exception
            PieceWeight = 0
        End Try
        Try
            BoxCount = CInt(BoxCountCommand.ExecuteScalar)
        Catch ex As Exception
            BoxCount = 0
        End Try
        Try
            BoxWeight = CDbl(BoxWeightCommand.ExecuteScalar)
        Catch ex As Exception
            BoxWeight = 0
        End Try
        Try
            PalletCount = CInt(PalletCountCommand.ExecuteScalar)
        Catch ex As Exception
            PalletCount = 0
        End Try
        Try
            PalletWeight = CDbl(PalletWeightCommand.ExecuteScalar)
        Catch ex As Exception
            PalletWeight = 0
        End Try
        Try
            PalletPieces = CInt(PalletPiecesCommand.ExecuteScalar)
        Catch ex As Exception
            PalletPieces = 0
        End Try
        Try
            StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
        Catch ex As Exception
            StandardCost = 0
        End Try
        Try
            StandardPrice = CDbl(StandardPriceCommand.ExecuteScalar)
        Catch ex As Exception
            StandardPrice = 0
        End Try
        Try
            GetItemClass = CStr(ItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            GetItemClass = ""
        End Try
        con.Close()

        txtPieceWeight.Text = PieceWeight
        txtBoxCount.Text = FormatNumber(BoxCount, 0)
        txtBoxWeight.Text = FormatNumber(BoxWeight, 1)
        txtPalletCount.Text = FormatNumber(PalletCount, 0)
        txtPalletPieces.Text = FormatNumber(PalletPieces, 0)
        txtPalletWeight.Text = FormatNumber(PalletWeight, 2)
        txtPieceWeight.Text = FormatNumber(PieceWeight, 4)

        If cboPartNumber.Text = "" Or cboPartNumber.SelectedIndex = -1 Then
            txtStdCost.Clear()
            txtStdPrice.Clear()
        Else
            txtStdCost.Text = FormatCurrency(StandardCost, 4)
            txtStdPrice.Text = FormatCurrency(StandardPrice, 4)
        End If
    End Sub

    Public Sub LoadQuantityOnHand()
        Dim CurrentQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CurrentQOHCommand As New SqlCommand(CurrentQOHString, con)
        CurrentQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CurrentQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim QuantityPendingString As String = "SELECT TotalShipQuantityPending FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim QuantityPendingCommand As New SqlCommand(QuantityPendingString, con)
        QuantityPendingCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        QuantityPendingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            QuantityOnHand = CDbl(CurrentQOHCommand.ExecuteScalar)
        Catch ex As Exception
            QuantityOnHand = 0
        End Try
        Try
            QuantityPending = CDbl(QuantityPendingCommand.ExecuteScalar)
        Catch ex As Exception
            QuantityPending = 0
        End Try
        con.Close()

        txtQuantityOnHand.Text = QuantityOnHand
        txtQtyPending.Text = QuantityPending
    End Sub

    Public Sub LoadLastPurchaseCost()
        'Load values into Cost Field
        Dim MAXDateStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
        MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxDate = CInt(MAXDateCommand.ExecuteScalar)
        Catch ex As Exception
            MaxDate = 0
        End Try
        con.Close()

        Dim LastPriceStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
        Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
        LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MaxDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
        Catch ex As Exception
            LastPurchaseCost = 0
        End Try
        con.Close()

        txtLastPurchaseCost.Text = FormatCurrency(LastPurchaseCost, 4)
    End Sub

    Public Sub LoadManufacturedCost()
        'Load values into Cost Field
        Dim MAXDateStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
        MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxDate = CInt(MAXDateCommand.ExecuteScalar)
        Catch ex As Exception
            MaxDate = 0
        End Try
        con.Close()

        Dim LastPriceStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionNumber = @TransactionNumber"
        Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
        LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        LastPriceCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
        Catch ex As Exception
            LastPurchaseCost = 0
        End Try
        con.Close()

        txtLastPurchaseCost.Text = FormatCurrency(LastPurchaseCost, 4)
    End Sub

    Public Sub LoadLastSalePrice()
        'Determine if Item Class is subject to price increase
        Dim CheckItemClass As String = GetItemClass
        Dim PriceIncreaseItem As String = ""

        Select Case CheckItemClass
            Case "TW CA", "TW SC", "TW DB", "TW DS", "TW TT", "TW TP", "TW CD", "TW NT", "TW CS", "TW PS", "TW CH", "TW IT", "TW SK", "TW SH", "TW TR", "TW TF", "TW RA", "TW KO"
                PriceIncreaseItem = "5PERCENT"
            Case "WASHERS", "U BOLTS", "TURNBUCKLES", "THREADED ROD", "TC BOLTS", "SOCKET SCREW", "SES", "SCREWS", "RIVET", "PUNCHES", "PINS", "MISC BOLTS", "METRIC", "LOCK NUTS", "LAG BOLTS", "JAM NUTS", "HEX NUTS", "HEX BOLTS", "EYE BOLTS", "EXP ANCHOR", "EPOXY", "DIES", "DES", "CUTTERS", "CPG NUTS", "CLEVIS", "CARR BOLTS", "BITS", "ANCHOR BOLTS"
                PriceIncreaseItem = "12PERCENT"
            Case "TW WELD PROD", "TWE ASSEMBLIES", "TWE STUD EQUIP COMP", "TWE CD COMPONENTS"
                PriceIncreaseItem = "5PERCENT"
            Case Else
                PriceIncreaseItem = "NO"
        End Select

        'Load values into Price Field
        Dim GetYearPricingDate As Date
        Dim UpdatedLastSalesPrice As Double = 0

        If EmployeeCompanyCode = "SLC" Then
            Dim MAXDateStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = EmployeeCompanyCode
            MAXDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim GetYearPricingDateStatement As String = "SELECT SalesOrderDate FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
            GetYearPricingDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = EmployeeCompanyCode
            GetYearPricingDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetYearPricingDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetYearPricingDate = Today()
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = EmployeeCompanyCode
            LastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastSalesPrice = 0
            End Try
            con.Close()
        Else
            Dim MAXDateStatement As String = "SELECT MAX(InvoiceHeaderKey) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim GetYearPricingDateStatement As String = "SELECT InvoiceDate FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceHeaderKey = @InvoiceHeaderKey"
            Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
            GetYearPricingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            GetYearPricingDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetYearPricingDateCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetYearPricingDate = Today()
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT Price FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceHeaderKey = @InvoiceHeaderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastSalesPrice = 0
            End Try
            con.Close()
        End If

        If GetYearPricingDate < GlobalTWDPriceChangeDate And EmployeeCompanyCode = "TWD" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWD
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalTWDPriceChangeDate And EmployeeCompanyCode = "SLC" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWD
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalSLCPriceChangeDate And EmployeeCompanyCode = "SLC" And PriceIncreaseItem = "12PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierSLC
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalTWEPriceChangeDate And EmployeeCompanyCode = "TWE" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWE
            lblUpdatedPrice.Visible = True
        Else
            UpdatedLastSalesPrice = LastSalesPrice
            lblUpdatedPrice.Visible = False
        End If

        txtLastSalesPrice.Text = FormatCurrency(UpdatedLastSalesPrice, 4)
    End Sub

    Public Sub LoadLastSalesPriceTWDRevised()
        'Declare variables
        Dim MaxDate As Integer = 0
        Dim GetItemClass As String = ""
        Dim GetSPL As String = ""
        Dim GetYearPricingDate As Date
        Dim LastSalesPrice As Double = 0
        Dim AdjustedLastSalesPrice As Double = 0
        Dim GetBracketNumber As Integer = 0
        Dim GetPriceAdjustmentPercentage1 As Double = 0
        Dim GetPriceAdjustmentPercentage2 As Double = 0
        Dim GetPriceAdjustmentPercentage3 As Double = 0
        Dim GetPriceAdjustmentPercentage4 As Double = 0
        Dim GetPriceAdjustmentPercentage5 As Double = 0
        Dim GetPriceAdjustmentPercentage6 As Double = 0
        '***************************************************************************************
        'Get Item Class of part (as well as if it is stainless)
        Dim GetItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim GetItemClassCommand As New SqlCommand(GetItemClassStatement, con)
        GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            GetItemClass = ""
        End Try
        con.Close()

        Dim GetSPLStatement As String = "SELECT SalesProdLineID FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim GetSPLCommand As New SqlCommand(GetSPLStatement, con)
        GetSPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        GetSPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSPL = CStr(GetSPLCommand.ExecuteScalar)
        Catch ex As Exception
            GetSPL = ""
        End Try
        con.Close()

        If cboCustomerID.Text = "" Then
            '***************************************************************************************
            'Get last sales date from invoice line table
            Dim MAXDateStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            MAXDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim GetYearPricingDateStatement As String = "SELECT SalesOrderDate FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
            GetYearPricingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            GetYearPricingDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetYearPricingDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetYearPricingDate = Today()
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            LastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastSalesPrice = 0
            End Try
            con.Close()

            'If price date is beyond the bracket, exit routine
            If GetYearPricingDate > "4/30/2022" Then
                'Pricing is current
                LastSalesPrice = Math.Round(LastSalesPrice, 4)
                txtLastSalesPrice.Text = LastSalesPrice
                lblUpdatedPrice.Visible = False

                Exit Sub
            Else
                'Determine the Price Increase Bracket it is in
                Dim GetBracketNumberStatement As String = "SELECT CostTierNumber FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND @PriceDate BETWEEN BeginDate AND EndDate"
                Dim GetBracketNumberCommand As New SqlCommand(GetBracketNumberStatement, con)
                GetBracketNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                GetBracketNumberCommand.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                GetBracketNumberCommand.Parameters.Add("@PriceDate", SqlDbType.VarChar).Value = GetYearPricingDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetBracketNumber = CInt(GetBracketNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetBracketNumber = 0
                End Try
                con.Close()

                Select Case GetBracketNumber
                    Case 1
                        'Increase price for 6 brackets (plus stainless)

                        'Get % for first bracket (Tier 1)
                        Dim GetPercentage1Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage1Command As New SqlCommand(GetPercentage1Statement, con)
                        GetPercentage1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage1Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage1Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 1

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage1 = CDbl(GetPercentage1Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage1 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage1)

                        'Get % for second bracket (Tier 2)
                        Dim GetPercentage2Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage2Command As New SqlCommand(GetPercentage2Statement, con)
                        GetPercentage2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage2Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage2Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 2

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage2 = CDbl(GetPercentage2Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage2 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage2)

                        'Get % for third bracket (Tier 3)
                        Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                        GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage3 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" Then
                            GetPriceAdjustmentPercentage3 = 0.05
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                        'Get % for fourth bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for fifth bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case 2
                        'Increase price for 5 brackets (plus stainless)

                        'Get % for first bracket (Tier 2)
                        Dim GetPercentage2Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage2Command As New SqlCommand(GetPercentage2Statement, con)
                        GetPercentage2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage2Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage2Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 2

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage2 = CDbl(GetPercentage2Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage2 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage2)

                        'Get % for second bracket (Tier 3)
                        Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                        GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage3 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" Then
                            GetPriceAdjustmentPercentage3 = 0.05
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                        'Get % for third bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for fourth bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case 3
                        'Increase price for FOUR brackets (plus stainless)

                        'Get % for first bracket (Tier 3)
                        Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                        GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage3 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" Then
                            GetPriceAdjustmentPercentage3 = 0.05
                        End If

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                        'Get % for second bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for third bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case 4
                        'Increase price for THREE brackets (Tier 4) plus stainless

                        'Get % for first bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for second bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case 5
                        'Increase price for 2 bracketS (Tier 5) plus stainless

                        'Get % for first bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case 6
                        'Increase price for 1 bracket (Tier 6)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case Else
                        'Pricing is current
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                        Exit Sub
                End Select
            End If
            '***************************************************************************************
        Else   'Load last price for specific customer
            '***************************************************************************************
            'Get last sales date from invoice line table
            Dim MAXDateStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND CustomerID = @CustomerID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            MAXDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            MAXDateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim GetYearPricingDateStatement As String = "SELECT SalesOrderDate FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
            GetYearPricingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            GetYearPricingDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetYearPricingDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetYearPricingDate = Today()
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            LastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastSalesPrice = 0
            End Try
            con.Close()

            'If price date is beyond the bracket, exit routine
            If GetYearPricingDate > "4/30/2022" Then
                'Pricing is current
                LastSalesPrice = Math.Round(LastSalesPrice, 4)
                txtLastSalesPrice.Text = LastSalesPrice
                lblUpdatedPrice.Visible = False

                Exit Sub
            Else
                '***************************************************************************************
                'Determine the Price Increase Bracket it is in
                Dim GetBracketNumberStatement As String = "SELECT CostTierNumber FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND @PriceDate BETWEEN BeginDate AND EndDate"
                Dim GetBracketNumberCommand As New SqlCommand(GetBracketNumberStatement, con)
                GetBracketNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                GetBracketNumberCommand.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                GetBracketNumberCommand.Parameters.Add("@PriceDate", SqlDbType.VarChar).Value = GetYearPricingDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetBracketNumber = CInt(GetBracketNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetBracketNumber = 0
                End Try
                con.Close()

                Select Case GetBracketNumber
                    Case 1
                        'Increase price for 6 brackets (plus stainless)

                        'Get % for first bracket (Tier 1)
                        Dim GetPercentage1Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage1Command As New SqlCommand(GetPercentage1Statement, con)
                        GetPercentage1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage1Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage1Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 1

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage1 = CDbl(GetPercentage1Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage1 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage1)

                        'Get % for second bracket (Tier 2)
                        Dim GetPercentage2Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage2Command As New SqlCommand(GetPercentage2Statement, con)
                        GetPercentage2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage2Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage2Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 2

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage2 = CDbl(GetPercentage2Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage2 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage2)

                        'Get % for third bracket (Tier 3)
                        Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                        GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage3 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" Then
                            GetPriceAdjustmentPercentage3 = 0.05
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                        'Get % for fourth bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for fifth bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case 2
                        'Increase price for 5 brackets (plus stainless)

                        'Get % for first bracket (Tier 2)
                        Dim GetPercentage2Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage2Command As New SqlCommand(GetPercentage2Statement, con)
                        GetPercentage2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage2Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage2Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 2

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage2 = CDbl(GetPercentage2Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage2 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage2)

                        'Get % for second bracket (Tier 3)
                        Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                        GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage3 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" Then
                            GetPriceAdjustmentPercentage3 = 0.05
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                        'Get % for third bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for fourth bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case 3
                        'Increase price for FOUR brackets (plus stainless)

                        'Get % for first bracket (Tier 3)
                        Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                        GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage3Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage3Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 3

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage3 = CDbl(GetPercentage3Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage3 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" Then
                            GetPriceAdjustmentPercentage3 = 0.05
                        End If

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage3)

                        'Get % for second bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for third bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case 4
                        'Increase price for THREE brackets (Tier 4) plus stainless

                        'Get % for first bracket (Tier 4)
                        Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                        GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage4Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage4Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 4

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage4 = CDbl(GetPercentage4Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage4 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage4)

                        'Get % for second bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case 5
                        'Increase price for 2 bracketS (Tier 5) plus stainless

                        'Get % for first bracket (Tier 5)
                        Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                        GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage5Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage5Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 5

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage5 = CDbl(GetPercentage5Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage5 = 0
                        End Try
                        con.Close()

                        If GetSPL = "STAINLESS" And (GetItemClass = "TW DB" Or GetItemClass = "TW CA" Or GetItemClass = "TW SC") Then
                            GetPriceAdjustmentPercentage5 = 0.15
                        ElseIf GetSPL = "STAINLESS" And (GetItemClass = "TW TT" Or GetItemClass = "TW NT" Or GetItemClass = "TW TP" Or GetItemClass = "TW CS") Then
                            GetPriceAdjustmentPercentage5 = 0.13
                        Else
                            'Do nothing
                        End If

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage5)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = AdjustedLastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case 6
                        'Increase price for 1 bracket (Tier 6)

                        'Get % for SIXTH bracket (Tier 6)
                        Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                        Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                        GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        GetPercentage6Command.Parameters.Add("@PriceClass", SqlDbType.VarChar).Value = GetItemClass
                        GetPercentage6Command.Parameters.Add("@CostTierNumber", SqlDbType.VarChar).Value = 6

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetPriceAdjustmentPercentage6 = CDbl(GetPercentage6Command.ExecuteScalar)
                        Catch ex As Exception
                            GetPriceAdjustmentPercentage6 = 0
                        End Try
                        con.Close()

                        AdjustedLastSalesPrice = LastSalesPrice * (1 + GetPriceAdjustmentPercentage6)

                        'Pricing is adjusted
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case Else
                        'Pricing is current
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalesPrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                        Exit Sub
                End Select
            End If
        End If
    End Sub

    Public Sub LoadLastSalePriceForCustomer()
        'Determine if Item Class is subject to price increase
        Dim CheckItemClass As String = GetItemClass
        Dim PriceIncreaseItem As String = ""

        Select Case CheckItemClass
            Case "TW CA", "TW SC", "TW DB", "TW DS", "TW TT", "TW TP", "TW CD", "TW NT", "TW CS", "TW PS", "TW CH", "TW IT", "TW SK", "TW SH", "TW TR", "TW TF", "TW RA", "TW KO"
                PriceIncreaseItem = "5PERCENT"
            Case "WASHERS", "U BOLTS", "TURNBUCKLES", "THREADED ROD", "TC BOLTS", "SOCKET SCREW", "SES", "SCREWS", "RIVET", "PUNCHES", "PINS", "MISC BOLTS", "METRIC", "LOCK NUTS", "LAG BOLTS", "JAM NUTS", "HEX NUTS", "HEX BOLTS", "EYE BOLTS", "EXP ANCHOR", "EPOXY", "DIES", "DES", "CUTTERS", "CPG NUTS", "CLEVIS", "CARR BOLTS", "BITS", "ANCHOR BOLTS"
                PriceIncreaseItem = "12PERCENT"
            Case "TW WELD PROD", "TWE ASSEMBLIES", "TWE STUD EQUIP COMP", "TWE CD COMPONENTS"
                PriceIncreaseItem = "5PERCENT"
            Case Else
                PriceIncreaseItem = "NO"
        End Select

        'Load values into Price Field
        Dim GetYearPricingDate As Date
        Dim UpdatedLastSalesPrice As Double = 0

        If EmployeeCompanyCode = "SLC" Then
            Dim MAXDateStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID AND CustomerID = @CustomerID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = EmployeeCompanyCode
            MAXDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            MAXDateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim GetYearPricingDateStatement As String = "SELECT SalesOrderDate FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
            GetYearPricingDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = EmployeeCompanyCode
            GetYearPricingDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetYearPricingDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetYearPricingDate = Today()
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT Price FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = EmployeeCompanyCode
            LastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastSalesPrice = 0
            End Try
            con.Close()
        Else
            Dim MAXDateStatement As String = "SELECT MAX(InvoiceHeaderKey) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND CustomerID = @CustomerID"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            MAXDateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim GetYearPricingDateStatement As String = "SELECT InvoiceDate FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceHeaderKey = @InvoiceHeaderKey"
            Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
            GetYearPricingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            GetYearPricingDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            GetYearPricingDateCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetYearPricingDate = CDate(GetYearPricingDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetYearPricingDate = Today()
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT Price FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceHeaderKey = @InvoiceHeaderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSalesPrice = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastSalesPrice = 0
            End Try
            con.Close()
        End If

        If GetYearPricingDate < GlobalTWDPriceChangeDate And EmployeeCompanyCode = "TWD" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWD
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalTWDPriceChangeDate And EmployeeCompanyCode = "SLC" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWD
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalSLCPriceChangeDate And EmployeeCompanyCode = "SLC" And PriceIncreaseItem = "12PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierSLC
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalTWEPriceChangeDate And EmployeeCompanyCode = "TWE" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWE
            lblUpdatedPrice.Visible = True
        Else
            UpdatedLastSalesPrice = LastSalesPrice
            lblUpdatedPrice.Visible = False
        End If

        txtLastSalesPrice.Text = FormatCurrency(UpdatedLastSalesPrice, 4)
    End Sub

    Public Sub LoadPOQuantityOpen()
        Dim OpenPOQuantityStatement As String = "SELECT SUM(POQuantityOpen) FROM PurchaseOrderQuantityStatus WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim OpenPOQuantityCommand As New SqlCommand(OpenPOQuantityStatement, con)
        OpenPOQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        OpenPOQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OpenPOQuantity = CDbl(OpenPOQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            OpenPOQuantity = 0
        End Try
        con.Close()

        txtOpenPOQuantity.Text = OpenPOQuantity
    End Sub

    Public Sub LoadMTDSales()
        MonthDate = Today()
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = MonthDate

        Dim MTDQuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDQuantityCommand As New SqlCommand(MTDQuantityStatement, con)
        MTDQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        MTDQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        MTDQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDQuantity = CDbl(MTDQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            MTDQuantity = 0
        End Try
        con.Close()

        txtMTDQuantity.Text = MTDQuantity
    End Sub

    Public Sub LoadYTDSales()
        YearDate = Today()
        YearOfYear = YearDate.Year
        strYear = CStr(YearOfYear)
        BeginDate = "01/01/" + strYear
        EndDate = YearDate

        Dim YTDQuantityStatement As String = "SELECT SUM(QuantityBilled) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDQuantityCommand As New SqlCommand(YTDQuantityStatement, con)
        YTDQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        YTDQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        YTDQuantityCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDQuantityCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDQuantity = CDbl(YTDQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            YTDQuantity = 0
        End Try
        con.Close()

        txtYTDQuantity.Text = YTDQuantity
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerID1 = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName1
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadPriceBrackets()
        Dim PriceLevel1Statement As String = "SELECT B100To199 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel1Command As New SqlCommand(PriceLevel1Statement, con)
        PriceLevel1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PriceLevel2Statement As String = "SELECT B200To299 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel2Command As New SqlCommand(PriceLevel2Statement, con)
        PriceLevel2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PriceLevel3Statement As String = "SELECT B300To399 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel3Command As New SqlCommand(PriceLevel3Statement, con)
        PriceLevel3Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PriceLevel4Statement As String = "SELECT B400To499 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel4Command As New SqlCommand(PriceLevel4Statement, con)
        PriceLevel4Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PriceLevel5Statement As String = "SELECT B500To749 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel5Command As New SqlCommand(PriceLevel5Statement, con)
        PriceLevel5Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PriceLevel6Statement As String = "SELECT B750To999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel6Command As New SqlCommand(PriceLevel6Statement, con)
        PriceLevel6Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PriceLevel7Statement As String = "SELECT B1000To2499 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel7Command As New SqlCommand(PriceLevel7Statement, con)
        PriceLevel7Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel7Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PriceLevel8Statement As String = "SELECT B2500To4999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel8Command As New SqlCommand(PriceLevel8Statement, con)
        PriceLevel8Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel8Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PriceLevel9Statement As String = "SELECT B5000To9999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel9Command As New SqlCommand(PriceLevel9Statement, con)
        PriceLevel9Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel9Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PriceLevel10Statement As String = "SELECT B10000To24999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel10Command As New SqlCommand(PriceLevel10Statement, con)
        PriceLevel10Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel10Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PriceLevel11Statement As String = "SELECT B25000To49999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel11Command As New SqlCommand(PriceLevel11Statement, con)
        PriceLevel11Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel11Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PriceLevel12Statement As String = "SELECT B50000To99999 FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel12Command As New SqlCommand(PriceLevel12Statement, con)
        PriceLevel12Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel12Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        Dim PriceLevel13Statement As String = "SELECT B100000AndUp FROM ItemPriceSheet WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim PriceLevel13Command As New SqlCommand(PriceLevel13Statement, con)
        PriceLevel13Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        PriceLevel13Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            P1 = CDbl(PriceLevel1Command.ExecuteScalar)
        Catch ex As Exception
            P1 = 0
        End Try
        Try
            P2 = CDbl(PriceLevel2Command.ExecuteScalar)
        Catch ex As Exception
            P2 = 0
        End Try
        Try
            P3 = CDbl(PriceLevel3Command.ExecuteScalar)
        Catch ex As Exception
            P3 = 0
        End Try
        Try
            P4 = CDbl(PriceLevel4Command.ExecuteScalar)
        Catch ex As Exception
            P4 = 0
        End Try
        Try
            P5 = CDbl(PriceLevel5Command.ExecuteScalar)
        Catch ex As Exception
            P5 = 0
        End Try
        Try
            P6 = CDbl(PriceLevel6Command.ExecuteScalar)
        Catch ex As Exception
            P6 = 0
        End Try
        Try
            P7 = CDbl(PriceLevel7Command.ExecuteScalar)
        Catch ex As Exception
            P7 = 0
        End Try
        Try
            P8 = CDbl(PriceLevel8Command.ExecuteScalar)
        Catch ex As Exception
            P8 = 0
        End Try
        Try
            P9 = CDbl(PriceLevel9Command.ExecuteScalar)
        Catch ex As Exception
            P9 = 0
        End Try
        Try
            P10 = CDbl(PriceLevel10Command.ExecuteScalar)
        Catch ex As Exception
            P10 = 0
        End Try
        Try
            P11 = CDbl(PriceLevel11Command.ExecuteScalar)
        Catch ex As Exception
            P11 = 0
        End Try
        Try
            P12 = CDbl(PriceLevel12Command.ExecuteScalar)
        Catch ex As Exception
            P12 = 0
        End Try
        Try
            P13 = CDbl(PriceLevel13Command.ExecuteScalar)
        Catch ex As Exception
            P13 = 0
        End Try
        con.Close()

        txtPrice1.Text = P1
        txtPrice2.Text = P2
        txtPrice3.Text = P3
        txtPrice4.Text = P4
        txtPrice5.Text = P5
        txtPrice6.Text = P6
        txtPrice7.Text = P7
        txtPrice8.Text = P8
        txtPrice9.Text = P9
        txtPrice10.Text = P10
        txtPrice11.Text = P11
        txtPrice12.Text = P12
        txtPrice13.Text = P13
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        If cboCustomerID.Text = "" Then
            lblPricingReview.Text = ""
            lblAccountingHold.Text = ""
            lblOnHoldStatus.Text = ""
            lblPaymentTerms.Text = ""
            ShowSalesLinesForAllCustomers()
        Else
            ShowSalesLines()
            LoadPricingReview()
            LoadCustomerNameByID()
            LoadCustomerData()
        End If

        If cboPartNumber.Text = "" Then
            'Skip if no part number
            lblUpdatedPrice.Visible = False
        Else
            If EmployeeCompanyCode = "TWD" Then
                LoadDescriptionByPart()
                LoadPriceBrackets()
                LoadLastPurchaseCost()
                LoadLastSalesPriceTWDRevised()
                LoadManufacturedCost()
                LoadMTDSales()
                LoadQuantityOnHand()
                LoadYTDSales()
                LoadPOQuantityOpen()
            Else
                If cboCustomerID.Text = "" Then
                    LoadDescriptionByPart()
                    LoadPriceBrackets()
                    LoadLastPurchaseCost()
                    LoadLastSalePrice()
                    LoadManufacturedCost()
                    LoadMTDSales()
                    LoadQuantityOnHand()
                    LoadYTDSales()
                    LoadPOQuantityOpen()
                Else
                    LoadDescriptionByPart()
                    LoadPriceBrackets()
                    LoadLastPurchaseCost()
                    LoadLastSalePriceForCustomer()
                    LoadManufacturedCost()
                    LoadMTDSales()
                    LoadQuantityOnHand()
                    LoadYTDSales()
                    LoadPOQuantityOpen()
                End If
            End If
        End If
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If cboCustomerID.Text = "" Then
            lblPricingReview.Text = ""
            ShowSalesLinesForAllCustomers()
        Else
            ShowSalesLines()
            LoadPricingReview()
        End If

        If cboPartNumber.Text = "" Then
            'Skip if no part number
            lblUpdatedPrice.Visible = False
        Else
            LoadPartData()

            If EmployeeCompanyCode = "TWD" Then
                LoadDescriptionByPart()
                LoadPriceBrackets()
                LoadLastPurchaseCost()
                LoadLastSalesPriceTWDRevised()
                LoadManufacturedCost()
                LoadMTDSales()
                LoadQuantityOnHand()
                LoadYTDSales()
                LoadPOQuantityOpen()
            Else
                If cboCustomerID.Text = "" Then
                    LoadDescriptionByPart()
                    LoadPriceBrackets()
                    LoadLastPurchaseCost()
                    LoadLastSalePrice()
                    LoadManufacturedCost()
                    LoadMTDSales()
                    LoadQuantityOnHand()
                    LoadYTDSales()

                    LoadPOQuantityOpen()
                Else
                    LoadDescriptionByPart()
                    LoadPriceBrackets()
                    LoadLastPurchaseCost()
                    LoadLastSalePriceForCustomer()
                    LoadManufacturedCost()
                    LoadMTDSales()
                    LoadQuantityOnHand()
                    LoadYTDSales()
                    LoadPOQuantityOpen()
                End If
            End If
        End If
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub
End Class