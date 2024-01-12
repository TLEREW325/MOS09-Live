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
Public Class ItemLookup
    Inherits System.Windows.Forms.Form

    Dim Vendor, LongDescription, ItemClass As String
    Dim OpenSOQuantity, MTDQuantity, YTDQuantity, OpenPOQuantity, StandardCost, StandardPrice, QuantityPending, BoxWeight, PalletWeight, PieceWeight, LastSalesPrice, LastPurchaseCost, QuantityOnHand, TORQOH, TFJQOH, TFTQOH, TWEQOH, ALBQOH, ATLQOH, HOUQOH, TFFQOH, TWDQOH, TFPQOH, CHTQOH, SLCQOH, CBSQOH, CGOQOH, DENQOH As Double
    Dim TFJCommitted, ALBCommitted, TORCommitted, TFTCommitted, TWECommitted, ATLCommitted, HOUCommitted, TFFCommitted, TWDCommitted, TFPCommitted, CHTCommitted, SLCCommitted, CBSCommitted, CGOCommitted, DENCommitted As Double
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
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    Private Class productionInfo
        Public machineClass As String
        Public piecesProduced As Integer
        ''have to specify the blank default constructor
        Public Sub New()
            machineClass = ""
            piecesProduced = 0
        End Sub

        ''constructor for custom object class
        Public Sub New(ByVal mach As String, ByVal piece As Integer)
            machineClass = mach
            piecesProduced = piece
        End Sub
    End Class

    Public Sub LoadLabelToolTip()
        LabelToolTip.SetToolTip(lblUpdatedPrice, "The last sales price has been adjusted.")
        LabelToolTip.ToolTipTitle = "Adjusted Price"
        LabelToolTip.IsBalloon = False
        LabelToolTip.ToolTipIcon = ToolTipIcon.Info
        LabelToolTip.UseAnimation = False
    End Sub

    Private Sub ItemLookup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearVariables()
        ClearData()
        GlobalPartNumberLookup = ""
    End Sub

    Private Sub ItemLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        LoadCustomerID()
        LoadCustomerName()
        LoadPartNumber()
        LoadPartDescription()
        LoadLabelToolTip()

        If GlobalPartNumberLookup = "" Then
            ClearVariables()
            ClearData()
        Else
            cboPartNumber.Text = GlobalPartNumberLookup
        End If

        If EmployeeCompanyCode.Equals("TWD") Or EmployeeCompanyCode.Equals("TFP") Then
            lblBlanks.Visible = True
            lblBlankLabel.Visible = True
            llLastPurchaseCostPopup.Text = "Manufactured Cost"
        Else
            lblBlanks.Visible = False
            lblBlankLabel.Visible = False
            llLastPurchaseCostPopup.Text = "Last Purchase Cost"
        End If

        If EmployeeCompanyCode.Equals("TFF") Or EmployeeCompanyCode.Equals("TOR") Or EmployeeCompanyCode.Equals("ALB") Then
            lblVendorLabel.Visible = True
            lblVendor.Visible = True
        Else
            lblVendor.Visible = False
            lblVendorLabel.Visible = False
        End If

        cboPartNumber.Focus()
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

    Public Sub ClearVariables()
        LongDescription = ""
        Vendor = ""
        ItemClass = ""
        BoxWeight = 0
        PalletWeight = 0
        PieceWeight = 0
        LastSalesPrice = 0
        LastPurchaseCost = 0
        MaxDate = 0
        QuantityOnHand = 0
        PalletPieces = 0
        BoxCount = 0
        PalletCount = 0
        StandardCost = 0
        StandardPrice = 0
        QuantityPending = 0
        OpenPOQuantity = 0
        MTDQuantity = 0
        YTDQuantity = 0
        OpenSOQuantity = 0
        TFTQOH = 0
        TWEQOH = 0
        ATLQOH = 0
        ALBQOH = 0
        HOUQOH = 0
        TFFQOH = 0
        TWDQOH = 0
        TFPQOH = 0
        CHTQOH = 0
        SLCQOH = 0
        CBSQOH = 0
        CGOQOH = 0
        TORQOH = 0
        DENQOH = 0
        TFJQOH = 0
        TFTCommitted = 0
        TWECommitted = 0
        ATLCommitted = 0
        ALBCommitted = 0
        HOUCommitted = 0
        TFFCommitted = 0
        TWDCommitted = 0
        TFPCommitted = 0
        CHTCommitted = 0
        SLCCommitted = 0
        CBSCommitted = 0
        CGOCommitted = 0
        TORCommitted = 0
        DENCommitted = 0
        TFJCommitted = 0
        GlobalPartNumberLookup = ""
    End Sub

    Public Sub ClearData()
        cboPartNumber.Text = ""
        cboPartDescription.Text = ""
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""

        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1

        txtBoxCount.Clear()
        txtBoxWeight.Clear()
        txtLastPurchaseCost.Clear()
        txtLastSalePrice.Clear()
        txtLongDescription.Clear()
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
        txtOpenSOQuamtity.Clear()

        lblAtlantInventory.Text = ""
        lblChicagoInventory.Text = ""
        lblHoustonQOH.Text = ""
        lblLasVegasInventory.Text = ""
        lblSaltLakeInventory.Text = ""
        lblTexasInventory.Text = ""
        lblTrufitQOH.Text = ""
        lblTruweldInventory.Text = ""
        lblTWEInventory.Text = ""
        lblVancouverInventory.Text = ""
        lblJerseyQOH.Text = ""
        lblWeldingCeramicsInventory.Text = ""
        lblBought.Text = ""
        lblTorontoQOH.Text = ""
        lblBlanks.Text = ""
        lblVendor.Text = ""
        lblDenverQOH.Text = ""
        lblAlbertaQOH.Text = ""
        lblPricingReview.Text = ""
        lblATLCommitted.Text = ""
        lblCBSCommitted.Text = ""
        lblCGOCommitted.Text = ""
        lblCHTCommitted.Text = ""
        lblDENCommitted.Text = ""
        lblHOUCommitted.Text = ""
        lblSLCCommitted.Text = ""
        lblTFFCommitted.Text = ""
        lblTFPCommitted.Text = ""
        lblTFTCommitted.Text = ""
        lblTORCommitted.Text = ""
        lblTWDCommitted.Text = ""
        lblTWECommitted.Text = ""
        lblALBCommitted.Text = ""
        lblJerseyCommitted.Text = ""

        lblPaymentTerms.Text = ""
        lblAccountingHoldStatus.Text = ""
        lblOnHoldStatus.Text = ""

        lblUpdatedPrice.Visible = False

        cboPartNumber.Focus()
    End Sub

    Public Sub LoadPartData()
        'Get Data from Item List Table
        Dim GetPartDataStatement As String = "SELECT * FROM ItemListQuery WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GetPartDataCommand As New SqlCommand(GetPartDataStatement, con)
        GetPartDataCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        GetPartDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetPartDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LongDescription")) Then
                LongDescription = ""
            Else
                LongDescription = reader.Item("LongDescription")
            End If
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
            If IsDBNull(reader.Item("BoxWeight")) Then
                BoxWeight = 0
            Else
                BoxWeight = reader.Item("BoxWeight")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                PalletCount = 0
            Else
                PalletCount = reader.Item("PalletCount")
            End If
            If IsDBNull(reader.Item("PalletWeight")) Then
                PalletWeight = 0
            Else
                PalletWeight = reader.Item("PalletWeight")
            End If
            If IsDBNull(reader.Item("PalletPieces")) Then
                PalletPieces = 0
            Else
                PalletPieces = reader.Item("PalletPieces")
            End If
            If IsDBNull(reader.Item("StandardCost")) Then
                StandardCost = 0
            Else
                StandardCost = reader.Item("StandardCost")
            End If
            If IsDBNull(reader.Item("StandardPrice")) Then
                StandardPrice = 0
            Else
                StandardPrice = reader.Item("StandardPrice")
            End If
            If IsDBNull(reader.Item("PreferredVendor")) Then
                Vendor = ""
            Else
                Vendor = reader.Item("PreferredVendor")
            End If
            If IsDBNull(reader.Item("ItemClass")) Then
                ItemClass = ""
            Else
                ItemClass = reader.Item("ItemClass")
            End If
        Else
            LongDescription = ""
            PieceWeight = 0
            BoxCount = 0
            BoxWeight = 0
            PalletCount = 0
            PalletWeight = 0
            PalletPieces = 0
            StandardCost = 0
            StandardPrice = 0
            Vendor = ""
            ItemClass = ""
        End If
        reader.Close()
        con.Close()

        txtLongDescription.Text = LongDescription
        txtPieceWeight.Text = PieceWeight
        txtBoxCount.Text = FormatNumber(BoxCount, 0)
        txtBoxWeight.Text = FormatNumber(BoxWeight, 1)
        txtPalletCount.Text = FormatNumber(PalletCount, 0)
        txtPalletPieces.Text = FormatNumber(PalletPieces, 0)
        txtPalletWeight.Text = FormatNumber(PalletWeight, 2)
        txtPieceWeight.Text = FormatNumber(PieceWeight, 4)
        txtStdCost.Text = FormatCurrency(StandardCost, 4)
        txtStdPrice.Text = FormatCurrency(StandardPrice, 4)
        lblVendor.Text = Vendor
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
            lblAccountingHoldStatus.Text = "Customer is on Accounting Hold"
        Else
            lblAccountingHoldStatus.Text = ""
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

    Public Sub LoadDivisionQOH()
        Dim HOUQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim HOUQOHCommand As New SqlCommand(HOUQOHString, con)
        HOUQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        HOUQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"

        Dim TWDQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TWDQOHCommand As New SqlCommand(TWDQOHString, con)
        TWDQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TWDQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        Dim CGOQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CGOQOHCommand As New SqlCommand(CGOQOHString, con)
        CGOQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CGOQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"

        Dim TFFQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TFFQOHCommand As New SqlCommand(TFFQOHString, con)
        TFFQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TFFQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"

        Dim TFPQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TFPQOHCommand As New SqlCommand(TFPQOHString, con)
        TFPQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TFPQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        Dim TFTQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TFTQOHCommand As New SqlCommand(TFTQOHString, con)
        TFTQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TFTQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"

        Dim CBSQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CBSQOHCommand As New SqlCommand(CBSQOHString, con)
        CBSQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CBSQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"

        Dim SLCQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim SLCQOHCommand As New SqlCommand(SLCQOHString, con)
        SLCQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        SLCQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

        Dim CHTQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CHTQOHCommand As New SqlCommand(CHTQOHString, con)
        CHTQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CHTQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"

        Dim TWEQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TWEQOHCommand As New SqlCommand(TWEQOHString, con)
        TWEQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TWEQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        Dim ATLQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ATLQOHCommand As New SqlCommand(ATLQOHString, con)
        ATLQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        ATLQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"

        Dim TORQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TORQOHCommand As New SqlCommand(TORQOHString, con)
        TORQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TORQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"

        Dim DENQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim DENQOHCommand As New SqlCommand(DENQOHString, con)
        DENQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        DENQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"

        Dim ALBQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ALBQOHCommand As New SqlCommand(ALBQOHString, con)
        ALBQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        ALBQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"

        Dim TFJQOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TFJQOHCommand As New SqlCommand(TFJQOHString, con)
        TFJQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TFJQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            HOUQOH = CDbl(HOUQOHCommand.ExecuteScalar)
            HOUQOH = Math.Round(HOUQOH, 0)
        Catch ex As Exception
            HOUQOH = 0
        End Try
        Try
            TWDQOH = CDbl(TWDQOHCommand.ExecuteScalar)
            TWDQOH = Math.Round(TWDQOH, 0)
        Catch ex As Exception
            TWDQOH = 0
        End Try
        Try
            CGOQOH = CDbl(CGOQOHCommand.ExecuteScalar)
            CGOQOH = Math.Round(CGOQOH, 0)
        Catch ex As Exception
            CGOQOH = 0
        End Try
        Try
            TFFQOH = CDbl(TFFQOHCommand.ExecuteScalar)
            TFFQOH = Math.Round(TFFQOH, 0)
        Catch ex As Exception
            TFFQOH = 0
        End Try
        Try
            TFPQOH = CDbl(TFPQOHCommand.ExecuteScalar)
            TFPQOH = Math.Round(TFPQOH, 0)
        Catch ex As Exception
            TFPQOH = 0
        End Try
        Try
            TFTQOH = CDbl(TFTQOHCommand.ExecuteScalar)
            TFTQOH = Math.Round(TFTQOH, 0)
        Catch ex As Exception
            TFTQOH = 0
        End Try
        Try
            CBSQOH = CDbl(CBSQOHCommand.ExecuteScalar)
            CBSQOH = Math.Round(CBSQOH, 0)
        Catch ex As Exception
            CBSQOH = 0
        End Try
        Try
            SLCQOH = CDbl(SLCQOHCommand.ExecuteScalar)
            SLCQOH = Math.Round(SLCQOH, 0)
        Catch ex As Exception
            SLCQOH = 0
        End Try
        Try
            CHTQOH = CDbl(CHTQOHCommand.ExecuteScalar)
            CHTQOH = Math.Round(CHTQOH, 0)
        Catch ex As Exception
            CHTQOH = 0
        End Try
        Try
            TWEQOH = CDbl(TWEQOHCommand.ExecuteScalar)
            TWEQOH = Math.Round(TWEQOH, 0)
        Catch ex As Exception
            TWEQOH = 0
        End Try
        Try
            ATLQOH = CDbl(ATLQOHCommand.ExecuteScalar)
            ATLQOH = Math.Round(ATLQOH, 0)
        Catch ex As Exception
            ATLQOH = 0
        End Try
        Try
            TORQOH = CDbl(TORQOHCommand.ExecuteScalar)
            TORQOH = Math.Round(TORQOH, 0)
        Catch ex As Exception
            TORQOH = 0
        End Try
        Try
            DENQOH = CDbl(DENQOHCommand.ExecuteScalar)
            DENQOH = Math.Round(DENQOH, 0)
        Catch ex As Exception
            DENQOH = 0
        End Try
        Try
            ALBQOH = CDbl(ALBQOHCommand.ExecuteScalar)
            ALBQOH = Math.Round(ALBQOH, 0)
        Catch ex As Exception
            ALBQOH = 0
        End Try
        Try
            TFJQOH = CDbl(TFJQOHCommand.ExecuteScalar)
            TFJQOH = Math.Round(TFJQOH, 0)
        Catch ex As Exception
            TFJQOH = 0
        End Try
        con.Close()

        lblAtlantInventory.Text = ATLQOH
        lblTexasInventory.Text = TFTQOH
        lblChicagoInventory.Text = CGOQOH
        lblHoustonQOH.Text = HOUQOH
        lblLasVegasInventory.Text = CBSQOH
        lblSaltLakeInventory.Text = SLCQOH
        lblTruweldInventory.Text = TWDQOH
        lblTWEInventory.Text = TWEQOH
        lblTrufitQOH.Text = TFPQOH
        lblWeldingCeramicsInventory.Text = CHTQOH
        lblVancouverInventory.Text = TFFQOH
        lblTorontoQOH.Text = TORQOH
        lblDenverQOH.Text = DENQOH
        lblAlbertaQOH.Text = ALBQOH
        lblJerseyQOH.Text = TFJQOH
    End Sub

    Public Sub LoadDivisionCommitted()
        Dim HOUCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim HOUCommittedCommand As New SqlCommand(HOUCommittedString, con)
        HOUCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        HOUCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"

        Dim TWDCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TWDCommittedCommand As New SqlCommand(TWDCommittedString, con)
        TWDCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TWDCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

        Dim CGOCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CGOCommittedCommand As New SqlCommand(CGOCommittedString, con)
        CGOCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CGOCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"

        Dim TFFCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TFFCommittedCommand As New SqlCommand(TFFCommittedString, con)
        TFFCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TFFCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"

        Dim TFPCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TFPCommittedCommand As New SqlCommand(TFPCommittedString, con)
        TFPCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TFPCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        Dim TFTCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TFTCommittedCommand As New SqlCommand(TFTCommittedString, con)
        TFTCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TFTCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"

        Dim CBSCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CBSCommittedCommand As New SqlCommand(CBSCommittedString, con)
        CBSCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CBSCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"

        Dim SLCCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim SLCCommittedCommand As New SqlCommand(SLCCommittedString, con)
        SLCCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        SLCCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

        Dim CHTCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CHTCommittedCommand As New SqlCommand(CHTCommittedString, con)
        CHTCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        CHTCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"

        Dim TWECommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TWECommittedCommand As New SqlCommand(TWECommittedString, con)
        TWECommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TWECommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        Dim ATLCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ATLCommittedCommand As New SqlCommand(ATLCommittedString, con)
        ATLCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        ATLCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"

        Dim TORCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TORCommittedCommand As New SqlCommand(TORCommittedString, con)
        TORCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TORCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"

        Dim DENCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim DENCommittedCommand As New SqlCommand(DENCommittedString, con)
        DENCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        DENCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"

        Dim ALBCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ALBCommittedCommand As New SqlCommand(ALBCommittedString, con)
        ALBCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        ALBCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"

        Dim TFJCommittedString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim TFJCommittedCommand As New SqlCommand(TFJCommittedString, con)
        TFJCommittedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        TFJCommittedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            HOUCommitted = CDbl(HOUCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            HOUCommitted = 0
        End Try
        Try
            TWDCommitted = CDbl(TWDCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            TWDCommitted = 0
        End Try
        Try
            CGOCommitted = CDbl(CGOCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            CGOCommitted = 0
        End Try
        Try
            TFFCommitted = CDbl(TFFCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            TFFCommitted = 0
        End Try
        Try
            TFPCommitted = CDbl(TFPCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            TFPCommitted = 0
        End Try
        Try
            TFTCommitted = CDbl(TFTCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            TFTCommitted = 0
        End Try
        Try
            CBSCommitted = CDbl(CBSCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            CBSCommitted = 0
        End Try
        Try
            SLCCommitted = CDbl(SLCCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            SLCCommitted = 0
        End Try
        Try
            CHTCommitted = CDbl(CHTCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            CHTCommitted = 0
        End Try
        Try
            TWECommitted = CDbl(TWECommittedCommand.ExecuteScalar)
        Catch ex As Exception
            TWECommitted = 0
        End Try
        Try
            ATLCommitted = CDbl(ATLCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            ATLCommitted = 0
        End Try
        Try
            TORCommitted = CDbl(TORCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            TORCommitted = 0
        End Try
        Try
            DENCommitted = CDbl(DENCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            DENCommitted = 0
        End Try
        Try
            ALBCommitted = CDbl(ALBCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            ALBCommitted = 0
        End Try
        Try
            TFJCommitted = CDbl(TFJCommittedCommand.ExecuteScalar)
        Catch ex As Exception
            TFJCommitted = 0
        End Try
        con.Close()

        lblATLCommitted.Text = ATLCommitted
        lblTFTCommitted.Text = TFTCommitted
        lblCGOCommitted.Text = CGOCommitted
        lblHOUCommitted.Text = HOUCommitted
        lblCBSCommitted.Text = CBSCommitted
        lblSLCCommitted.Text = SLCCommitted
        lblTWDCommitted.Text = TWDCommitted
        lblTWECommitted.Text = TWECommitted
        lblTFPCommitted.Text = TFPCommitted
        lblCHTCommitted.Text = CHTCommitted
        lblTFFCommitted.Text = TFFCommitted
        lblTORCommitted.Text = TORCommitted
        lblDENCommitted.Text = DENCommitted
        lblALBCommitted.Text = ALBCommitted
        lblJerseyCommitted.Text = TFJCommitted
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

        Dim OpenSOQuantityString As String = "SELECT OpenSOQuantity FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim OpenSOQuantityCommand As New SqlCommand(OpenSOQuantityString, con)
        OpenSOQuantityCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        OpenSOQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            QuantityOnHand = CDbl(CurrentQOHCommand.ExecuteScalar)
            QuantityOnHand = Math.Round(QuantityOnHand, 2)
        Catch ex As Exception
            QuantityOnHand = 0
        End Try
        Try
            QuantityPending = CDbl(QuantityPendingCommand.ExecuteScalar)
            QuantityPending = Math.Round(QuantityPending, 2)
        Catch ex As Exception
            QuantityPending = 0
        End Try
        Try
            OpenSOQuantity = CDbl(OpenSOQuantityCommand.ExecuteScalar)
            OpenSOQuantity = Math.Round(OpenSOQuantity, 2)
        Catch ex As Exception
            OpenSOQuantity = 0
        End Try
        con.Close()

        txtQuantityOnHand.Text = QuantityOnHand
        txtQtyPending.Text = QuantityPending
        txtOpenSOQuamtity.Text = OpenSOQuantity
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
        Dim CheckItemClass As String = ItemClass
        Dim PriceIncreaseItem As String = ""

        Select Case CheckItemClass
            Case "TW CA", "TW SC", "TW DB", "TW DS", "TW TT", "TW TP", "TW CD", "TW NT", "TW CS", "TW PS", "TW CH", "TW IT", "TW SK", "TW SH", "TW TR", "TW TF", "TW RA", "TW KO"
                PriceIncreaseItem = "5PERCENT"
            Case "WASHERS", "U BOLTS", "TURNBUCKLES", "THREADED ROD", "TC BOLTS", "SOCKET SCREW", "SES", "SCREWS", "RIVET", "PUNCHES", "PINS", "MISC BOLTS", "METRIC", "LOCK NUTS", "LAG BOLTS", "JAM NUTS", "HEX NUTS", "HEX BOLTS", "EYE BOLTS", "EXP ANCHOR", "EPOXY", "DIES", "DES", "CUTTERS", "CPG NUTS", "CLEVIS", "CARR BOLTS", "BITS", "ANCHOR BOLTS"
                PriceIncreaseItem = "12PERCENT"
            Case "WC FERRULES", "WC WELD TILES"
                PriceIncreaseItem = "7PERCENT"
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
        ElseIf GetYearPricingDate < GlobalCHTPriceChangeDate And EmployeeCompanyCode = "CHT" And PriceIncreaseItem = "7PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierCHT
            lblUpdatedPrice.Visible = True
        ElseIf GetYearPricingDate < GlobalTWEPriceChangeDate And EmployeeCompanyCode = "TWE" And PriceIncreaseItem = "5PERCENT" Then
            UpdatedLastSalesPrice = LastSalesPrice * GlobalPriceChangeMultiplierTWE
            lblUpdatedPrice.Visible = True
        Else
            UpdatedLastSalesPrice = LastSalesPrice
            lblUpdatedPrice.Visible = False
        End If

        txtLastSalePrice.Text = FormatCurrency(UpdatedLastSalesPrice, 4)
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
                txtLastSalePrice.Text = LastSalesPrice
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
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
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
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
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
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
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
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
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
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
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
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case Else
                        'Pricing is current
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
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
                txtLastSalePrice.Text = LastSalesPrice
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
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
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
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
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
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
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
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
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
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
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
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                    Case Else
                        'Pricing is current
                        AdjustedLastSalesPrice = Math.Round(AdjustedLastSalesPrice, 4)
                        txtLastSalePrice.Text = AdjustedLastSalesPrice
                        txtLastSalePrice.Text = FormatCurrency(AdjustedLastSalesPrice, 4)
                        lblUpdatedPrice.Visible = True
                        Exit Sub
                End Select
            End If
        End If
    End Sub

    Public Sub LoadLastSalePriceForCustomer()
        'Determine if Item Class is subject to price increase
        Dim CheckItemClass As String = ItemClass
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

        txtLastSalePrice.Text = FormatCurrency(UpdatedLastSalesPrice, 4)
    End Sub

    Public Sub LoadPOQuantityOpen()
        Dim OpenPOQuantityStatement As String = "SELECT SUM(POQuantityOpen) FROM PurchaseOrderQuantityStatus WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
        Dim OpenPOQuantityCommand As New SqlCommand(OpenPOQuantityStatement, con)
        OpenPOQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        OpenPOQuantityCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OpenPOQuantity = CDbl(OpenPOQuantityCommand.ExecuteScalar)
            OpenPOQuantity = Math.Round(OpenPOQuantity, 0)
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

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalPartNumberLookup = ""

        ClearData()
        ClearVariables()

        Me.Dispose()
        Me.Close()
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

    Private Sub cmdClearData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearData.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
        LoadMTDSales()
        LoadYTDSales()
        LoadPartData()

        If EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            LoadBlanks()
            LoadManufacturedCost()
        Else
            LoadLastPurchaseCost()
        End If

        LoadPOQuantityOpen()
        LoadQuantityOnHand()
        LoadDivisionQOH()
        LoadDivisionCommitted()

        If EmployeeCompanyCode = "TWD" Then
            LoadLastSalesPriceTWDRevised()
        Else
            If cboCustomerID.Text = "" Then
                LoadLastSalePrice()
            Else
                LoadLastSalePriceForCustomer()
                lblBought.Text = ""
            End If
        End If
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        If cboPartNumber.Text = "" Then
            'Do not load anything without a part #
        Else
            If EmployeeCompanyCode = "TWD" Then
                If cboCustomerID.Text = "" Then
                    txtLastSalePrice.Clear()
                    LoadLastSalesPriceTWDRevised()
                Else
                    lblBought.Text = ""
                    LoadPricingReview()
                    txtLastSalePrice.Clear()
                    LoadLastSalesPriceTWDRevised()
                End If
            Else
                If cboCustomerID.Text = "" Then
                    txtLastSalePrice.Clear()
                    LoadLastSalePrice()
                Else
                    lblBought.Text = ""
                    LoadPricingReview()
                    txtLastSalePrice.Clear()
                    LoadLastSalePriceForCustomer()
                End If
            End If
        End If

        LoadCustomerNameByID()
        LoadCustomerData()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub LoadBlanks()
        ds5 = New DataSet()
        createFinalTable()
        cmd = New SqlCommand("DECLARE @FOXNumber as int = (SELECT TOP 1 isnull(FOXNumber, 0) FROM ItemList WHERE ItemID = @PartNumber AND( DivisionID ='TWD' OR DivisionID = 'TFP')); SELECT case when isnull(SUM(PiecesProduced), 0) < 0 then 0 else isnull(SUM(PiecesProduced), 0) end as TotalBlanks FROM (SELECT TimeSlipCombinedData.TimeSlipKey, TimeslipCombinedData.FOXNumber, case when ProcessAddFG = 'ADDINVENTORY' then 0 else PiecesProduced end as PiecesProduced, FOXStep, ProcessAddFG FROM TimeSlipCombinedData LEFT OUTER JOIN (SELECT ProcessAddFG, ProcessStep FROM FoxSched WHERE ProcessStep = 1 and FOXNumber = @FOXNumber) as FOXSched ON TimeSlipCombinedData.FOXStep = FoxSched.ProcessStep WHERE TimeSlipCombinedData.FOXNumber = @FOXNumber and FOXStep = 1 AND InventoryPieces = 0 GROUP BY TimeSlipCombinedData.TimeSlipKey,TimeSlipCombinedData.FOXNumber, FOXStep, ProcessAddFG, PiecesProduced UNION ALL (SELECT TimeSlipCombinedData.TimeSlipKey, TimeslipCombinedData.FOXNumber, (-1 * PiecesProduced) as PiecesProduced, FOXStep, ProcessAddFG FROM TimeSlipCombinedData LEFT OUTER JOIN (SELECT ProcessAddFG, ProcessStep FROM FoxSched WHERE ProcessStep = 2 and FOXNumber = @FOXNumber) as FOXSched ON TimeSlipCombinedData.FOXStep = FoxSched.ProcessStep WHERE TimeSlipCombinedData.FOXNumber = @FOXNumber and FOXStep = 2 GROUP BY TimeSlipCombinedData.TimeSlipKey,TimeSlipCombinedData.FOXNumber, FOXStep, ProcessAddFG, PiecesProduced)) as Steps", con)
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim obj As Object = cmd.ExecuteScalar()
        con.Close()
        If IsDBNull(obj) Then
            lblBlanks.Text = "0"
        Else
            lblBlanks.Text = Convert.ToInt32(obj).ToString()
        End If
    End Sub

    Private Sub combineClassTotals(ByRef info As List(Of productionInfo))
        For i As Integer = 0 To ds5.Tables("Pieces").Rows.Count - 1
            Dim notFound As Boolean = True
            ''goes through to see if the class is already in the list
            For j As Integer = 0 To info.Count - 1 And notFound
                If ds5.Tables("Pieces").Rows(i).Item("MachineClass").ToString.Equals(info(j).machineClass) Then
                    notFound = False
                    info(j).piecesProduced += ds5.Tables("Pieces").Rows(i).Item("PiecesProduced")
                End If
            Next

            ''if the specified 
            If notFound Then
                ''goes through to make sure that the given class is one of the classes needed
                For j As Integer = 0 To ds5.Tables("Process").Rows().Count - 1 And notFound
                    If ds5.Tables("Process").Rows(j).Item("MachineClass").ToString.Equals(ds5.Tables("Pieces").Rows(i).Item("MachineClass")) Then
                        notFound = False
                        info.Add(New productionInfo(ds5.Tables("Pieces").Rows(i).Item("MachineClass"), ds5.Tables("Pieces").Rows(i).Item("PiecesProduced")))
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub createFinalTable()
        ds5.Tables.Add("Complete")
        ds5.Tables("Complete").Columns.Add("ItemID")
        ds5.Tables("Complete").Columns.Add("ShortDescription")
        ds5.Tables("Complete").Columns.Add("QuantityOnHand")
        ds5.Tables("Complete").Columns.Add("TotalShipQuantityPending")
        ds5.Tables("Complete").Columns.Add("LastYearShippedToDate")
        ds5.Tables("Complete").Columns.Add("TotalQuantityShipped")
        ds5.Tables("Complete").Columns.Add("StandardCost")
        ds5.Tables("Complete").Columns.Add("StandardPrice")
        ds5.Tables("Complete").Columns.Add("MinimumStock")
        ds5.Tables("Complete").Columns.Add("MaximumStock")
        ds5.Tables("Complete").Columns.Add("OpenSOQuantity")
        ds5.Tables("Complete").Columns.Add("OpenPOQuantity")
        ds5.Tables("Complete").Columns.Add("AssemblyBuildQuantity")
    End Sub

    Private Sub chkLoadDivisionQOH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLoadDivisionQOH.CheckedChanged
        If chkLoadDivisionQOH.Checked = True Then
            'LoadDivisionQOH()
        Else
            'lblAtlantInventory.Text = ""
            'lblTexasInventory.Text = ""
            'lblChicagoInventory.Text = ""
            'lblHoustonQOH.Text = ""
            'lblLasVegasInventory.Text = ""
            'lblSaltLakeInventory.Text = ""
            'lblTruweldInventory.Text = ""
            'lblTWEInventory.Text = ""
            'lblTrufitQOH.Text = ""
            'lblWeldingCeramicsInventory.Text = ""
            'lblVancouverInventory.Text = ""
            'lblTorontoQOH.Text = ""
            'lblDenverQOH.Text = ""
        End If
    End Sub

    Private Sub llLastPurchaseCostPopup_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLastPurchaseCostPopup.LinkClicked
        GlobalDivisionCode = EmployeeCompanyCode
        GlobalPOPartNumber = cboPartNumber.Text

        If EmployeeCompanyCode = "TWD" Or EmployeeCompanyCode = "TFP" Then
            Using NewSOManufacturedCostPopup As New SOManufacturedCostPopup
                Dim Result = NewSOManufacturedCostPopup.ShowDialog()
            End Using
        Else
            Using NewSOPurchaseCostPopup As New SOPurchaseCostPopup
                Dim Result = NewSOPurchaseCostPopup.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub lblCGOCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCGOCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblALBCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblALBCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblATLCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblATLCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblCBSCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCBSCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblCHTCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCHTCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblDENCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDENCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblHOUCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblHOUCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblJerseyCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblJerseyCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblSLCCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblSLCCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblTFFCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTFFCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblTFPCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTFPCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblTFTCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTFTCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblTORCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTORCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblTWDCommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTWDCommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub lblTWECommitted_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTWECommitted.DoubleClick
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewItemMaintenanceOpenOrders As New ItemMaintenanceOpenOrders
            Dim Result = NewItemMaintenanceOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub llLastSalesPrice_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLastSalesPrice.LinkClicked
 
        GlobalDivisionCode = EmployeeCompanyCode
        GlobalSOCustomerID = cboCustomerID.Text
        GlobalSOPartNumber = cboPartNumber.Text

        Using NewSOSalesPricePopup As New SOSalesPricePopup
            Dim Result = NewSOSalesPricePopup.ShowDialog()
        End Using
    End Sub
End Class