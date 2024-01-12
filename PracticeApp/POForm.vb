Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class POForm
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim DropShipSalesOrderNumber, UpperLimit, NextInventoryTransactionNumber, LastInventoryTransactionNumber, GetLineNumber As Integer
    Dim LineDebitGLAccount, LineCreditGLAccount, CheckItemClass As String
    Dim ShipMethod, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, AddAddress1, AddAddress2, AddCity, AddState, AddZip, AddCountry, AddName As String
    Dim LinkStatus, POStatus, VerifyItemID, LongDescription, VendorName, VendorPaymentTerms, VendorID, PaymentCode, POHeaderComment, ShipMethodID, PODropShipCustomerID, POAdditionalShipTo As String
    Dim FreightCharge, SalesTax, ProductTotal, POTotal, UnitCost, ExtendedAmount, LastPurchasePrice, NewExtendedAmount As Double
    Dim PODate, ShipDate As Date
    Dim LineEditOrderQuantity, LineEditExtendedAmount, LineEditUnitCost, NewOrderQuantity, LineOrderQuantity, LineQuantity, CheckOrderQuantity, Quantity, CheckReceiverQuantity, CheckLineQuantity, LineWeight, TotalWeight, PieceWeight, LineUnitCost, LineExtendedAmount, LineCost, LineAmount, LineTax, TotalTax, QuantityOpen, TotalQuantityOpen As Double
    Dim CheckReceiveStatus, CountLineNumber, Counter, LastTransactionNumber, NextTransactionNumber, LastLineNumber, NextLineNumber, ReissueLineNumber, LastPONumber, NextPONumber, LastGLNumber, NextGLNumber As Integer
    Dim CheckPartNumber1, GetSPL, LinePartNumber, LinePartDescription, LineComment, TempItemClass, GLDebitAccount, GLCreditAccount, TempPartNumber, TempPartDescription, PartDescription, NonPartDescription, PartNumber, NonPartNumber, ItemClass, MAXDate As String
    Dim GetReceiverVendor, DSCustomerID, DSADDShipTo, VerifyVendor, TempGLInventoryAccount, TempGLPurchasesAccount, GLSalesAccount, GLReturnsAccount, GLInventoryAccount, GLCOGSAccount, GLPurchasesAccount, GLSalesOffsetAccount, GLAdjustmentAccount, GLIssuesAccount, CheckPartNumber As String
    Dim CheckReceiverVendor, DSSONumber, CheckPOLines, LineNumber As Integer
    Dim SalesPersonID, LineEditPartNumber, LineEditPartDescription As String
    Dim EstTotalWeight, EstTotalBoxes As Double
    Dim ValidateDivision As String = ""
    Dim DivisionMatch As String = ""
    Dim CurrentShippingWeight As Double = 0

    'Variables for Default Address
    Dim DefaultCompanyName, DefaultAddress1, DefaultAddress2, DefaultCity, DefaultState, DefaultZip, DefaultCountry As String
    Dim ShipName, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZipCode, ShipCountry As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim needsSaved As Boolean = False
    Dim lineInfoChanged As Boolean = False
    Dim isLoaded As Boolean = False
    Dim isLoadingPO As Boolean = False
    Dim lastPO As String = ""

    Dim Suggest As SuggestDescriptionAPI
    Dim LineSuggest As SuggestDescriptionAPI

    'Form Operations

    Private Sub POForm_Closing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closing
        If Not String.IsNullOrEmpty(cboPurchaseOrderNumber.Text) Then
            unlockBatch()
        End If

        ClearVariables()
        ClearAllData()
    End Sub

    Private Sub POForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PaymentTerms' table. You can move, or remove it, as needed.
        Me.PaymentTermsTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PaymentTerms)

        LoadCurrentDivision()

        'Initialize Default Data
        Counter = 1

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        If cboDivisionID.Text = "TWD" Then
            cboNewItemClass.Visible = True
            lblItemClassNew.Visible = True
            LoadNewItemClass()
            cboShipVia.Text = "UPSGROUNDCOLLECT-ACCT#472125"
        ElseIf cboDivisionID.Text = "SLC" Then
            cboNewItemClass.Visible = True
            lblItemClassNew.Visible = True
            LoadNewItemClass()
        ElseIf cboDivisionID.Text = "CBS" Then
            cboNewItemClass.Visible = True
            lblItemClassNew.Visible = True
            LoadNewItemClass()
        Else
            cboNewItemClass.Visible = False
            lblItemClassNew.Visible = False
        End If

        isLoaded = True

        'Load Global PO Number
        If GlobalPONumber < 1 Then
            cboPurchaseOrderNumber.SelectedIndex = -1
        Else
            cboDivisionID.Text = GlobalDivisionCode
            cboPurchaseOrderNumber.Text = GlobalPONumber
        End If

        ''creates the call to Suggest API
        Suggest = New SuggestDescriptionAPI(cboPartDescription, lstPartDescriptionSuggest, cboPartNumber, ds8)
        LineSuggest = New SuggestDescriptionAPI(cboLineDescription, lstLinePartDescriptionSuggest, cboLinePartNumber, ds9)

        needsSaved = False
        cmdGeneratePO.Focus()
    End Sub

    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "LLH"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFJ"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFJ'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Private Sub POForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(cboPurchaseOrderNumber.Text) Then
            unlockBatch()
        End If
    End Sub

    Private Sub POForm_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If shouldSwitchStatus(e) Then
            needsSaved = True
        End If
    End Sub

    'Load data into datasets/controls

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderLineQueryQO WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "PurchaseOrderLineQueryQO")
        con.Close()

        dgvPurchaseOrderLines.DataSource = ds.Tables("PurchaseOrderLineQueryQO")
        cboLineNumber.DataSource = ds.Tables("PurchaseOrderLineQueryQO")

        LoadFormatting()
    End Sub

    Public Sub LoadPONumber()
        cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "PurchaseOrderHeaderTable")
        con.Close()

        cboPurchaseOrderNumber.DataSource = ds1.Tables("PurchaseOrderHeaderTable")
        cboPurchaseOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART' ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "ItemList")
        con.Close()

        cboPartNumber.DataSource = ds2.Tables("ItemList")
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorID()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> 'DE-ACTIVATED' ORDER BY VendorCode", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "Vendor")
        con.Close()

        cboVendorCode.DataSource = ds3.Tables("Vendor")
        cboVendorCode.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerList()
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> 'DE-ACTIVATED' ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "CustomerList")
        con.Close()

        cboCustomerDSName.DataSource = ds4.Tables("CustomerList")
        cboCustomerDSName.SelectedIndex = -1
    End Sub

    Public Sub LoadAdditionalShipTo()
        cmd = New SqlCommand("SELECT ShipToID FROM AdditionalShipTo WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID ORDER BY ShipToID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerDSName.Text
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "AdditionalShipTo")
        con.Close()

        cboShipToID.DataSource = ds5.Tables("AdditionalShipTo")
        cboShipToID.SelectedIndex = -1
    End Sub

    Public Sub LoadNewItemClass()
        cmd = New SqlCommand("SELECT ItemClassID FROM ItemClass", con)
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter6.Fill(ds6, "ItemClass")
        con.Close()

        cboNewItemClass.DataSource = ds6.Tables("ItemClass")
        cboNewItemClass.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART' ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter8.Fill(ds8, "ItemList")
        con.Close()

        cboPartDescription.DataSource = ds8.Tables("ItemList")
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadReceiverDatagrid()
        cmd = New SqlCommand("SELECT * FROM ReceivingHeaderTable WHERE PONumber = @PONumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd
        myAdapter9.Fill(ds9, "ReceivingHeaderTable")
        dgvReceiverTable.DataSource = ds9.Tables("ReceivingHeaderTable")
        con.Close()
    End Sub
     
    Public Sub LoadReturnDatagrid()
        cmd = New SqlCommand("SELECT * FROM VendorReturn WHERE PONumber = @PONumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds10 = New DataSet()
        myAdapter10.SelectCommand = cmd
        myAdapter10.Fill(ds10, "VendorReturn")
        dgvReturnTable.DataSource = ds10.Tables("VendorReturn")
        con.Close()
    End Sub

    Public Sub LoadVoucherDatagrid()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE PONumber = @PONumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds11 = New DataSet()
        myAdapter11.SelectCommand = cmd
        myAdapter11.Fill(ds11, "ReceiptOfInvoiceBatchLine")
        dgvROITable.DataSource = ds11.Tables("ReceiptOfInvoiceBatchLine")
        con.Close()
    End Sub

    'Load data subroutines

    Public Sub LoadCustomerData()
        Dim GetCustomerDataStatement As String = "SELECT * FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetCustomerDataCommand As New SqlCommand(GetCustomerDataStatement, con)
        GetCustomerDataCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerDSName.Text
        GetCustomerDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetCustomerDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CustomerName")) Then
                ShipToName = ""
            Else
                ShipToName = reader.Item("CustomerName")
            End If
            If IsDBNull(reader.Item("ShipToAddress1")) Then
                ShipToAddress1 = ""
            Else
                ShipToAddress1 = reader.Item("ShipToAddress1")
            End If
            If IsDBNull(reader.Item("ShipToAddress2")) Then
                ShipToAddress2 = ""
            Else
                ShipToAddress2 = reader.Item("ShipToAddress2")
            End If
            If IsDBNull(reader.Item("ShipToCity")) Then
                ShipToCity = ""
            Else
                ShipToCity = reader.Item("ShipToCity")
            End If
            If IsDBNull(reader.Item("ShipToState")) Then
                ShipToState = ""
            Else
                ShipToState = reader.Item("ShipToState")
            End If
            If IsDBNull(reader.Item("ShipToZip")) Then
                ShipToZip = ""
            Else
                ShipToZip = reader.Item("ShipToZip")
            End If
            If IsDBNull(reader.Item("ShipToCountry")) Then
                ShipToCountry = ""
            Else
                ShipToCountry = reader.Item("ShipToCountry")
            End If
        Else
            ShipToAddress1 = ""
            ShipToAddress2 = ""
            ShipToCity = ""
            ShipToState = ""
            ShipToZip = ""
            ShipToCountry = ""
            ShipToName = ""
        End If
        reader.Close()
        con.Close()

        If cboShipToID.Text <> "" Then
            LoadAdditionalShipToDetails()
        Else
            txtCustomerDSAddress1.Text = ShipToAddress1
            txtCustomerDSAddress2.Text = ShipToAddress2
            txtCustomerDSCity.Text = ShipToCity
            txtCustomerDSZip.Text = ShipToZip
            cboDropShipState.Text = ShipToState
            txtCustomerCountry.Text = ShipToCountry
            txtShippingName.Text = ShipToName
        End If
    End Sub

    Public Sub LoadVendorData()
        Dim VendorNameStatement As String = "SELECT VendorName, PaymentTerms FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID;"
        Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = VendorNameCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("VendorName")) Then
                VendorName = ""
            Else
                VendorName = reader.Item("VendorName")
            End If
            If IsDBNull(reader.Item("PaymentTerms")) Then
                VendorPaymentTerms = ""
            Else
                VendorPaymentTerms = reader.Item("PaymentTerms")
            End If
        Else
            VendorName = ""
            VendorPaymentTerms = ""
        End If
        reader.Close()
        con.Close()

        cboPaymentTerms.Text = VendorPaymentTerms
        txtVendorName.Text = VendorName
    End Sub

    Public Sub LoadShippingAddress()
        Dim GetDefaultShippingStatement As String = "SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim GetDefaultShippingCommand As New SqlCommand(GetDefaultShippingStatement, con)
        GetDefaultShippingCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetDefaultShippingCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CompanyName")) Then
                DefaultCompanyName = ""
            Else
                DefaultCompanyName = reader.Item("CompanyName")
            End If
            If IsDBNull(reader.Item("Address1")) Then
                DefaultAddress1 = ""
            Else
                DefaultAddress1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                DefaultAddress2 = ""
            Else
                DefaultAddress2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                DefaultCity = ""
            Else
                DefaultCity = reader.Item("City")
            End If
            If IsDBNull(reader.Item("State")) Then
                DefaultState = ""
            Else
                DefaultState = reader.Item("State")
            End If
            If IsDBNull(reader.Item("ZipCode")) Then
                DefaultZip = ""
            Else
                DefaultZip = reader.Item("ZipCode")
            End If
            If IsDBNull(reader.Item("Country")) Then
                DefaultCountry = ""
            Else
                DefaultCountry = reader.Item("Country")
            End If
        Else
            DefaultState = ""
            DefaultCountry = ""
            DefaultZip = ""
            DefaultCity = ""
            DefaultAddress1 = ""
            DefaultAddress2 = ""
            DefaultCompanyName = ""
        End If
        reader.Close()
        con.Close()

        txtShippingName.Text = DefaultCompanyName
        txtCustomerCountry.Text = DefaultCountry
        txtCustomerDSAddress1.Text = DefaultAddress1
        txtCustomerDSAddress2.Text = DefaultAddress2
        cboDropShipState.Text = DefaultState
        txtCustomerDSZip.Text = DefaultZip
        txtCustomerDSCity.Text = DefaultCity
    End Sub

    Public Sub LoadAdditionalShipToDetails()
        Dim GetAddDetailsStatement As String = "SELECT * FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipToID = @ShipToID"
        Dim GetAddDetailsCommand As New SqlCommand(GetAddDetailsStatement, con)
        GetAddDetailsCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerDSName.Text
        GetAddDetailsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetAddDetailsCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetAddDetailsCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Address1")) Then
                AddAddress1 = ""
            Else
                AddAddress1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                AddAddress2 = ""
            Else
                AddAddress2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                AddCity = ""
            Else
                AddCity = reader.Item("City")
            End If
            If IsDBNull(reader.Item("State")) Then
                AddState = ""
            Else
                AddState = reader.Item("State")
            End If
            If IsDBNull(reader.Item("Zip")) Then
                AddZip = ""
            Else
                AddZip = reader.Item("Zip")
            End If
            If IsDBNull(reader.Item("Country")) Then
                AddCountry = ""
            Else
                AddCountry = reader.Item("Country")
            End If
            If IsDBNull(reader.Item("Name")) Then
                AddName = ""
            Else
                AddName = reader.Item("Name")
            End If
        Else
            AddAddress1 = ""
            AddAddress2 = ""
            AddCity = ""
            AddState = ""
            AddZip = ""
            AddCountry = ""
            AddName = ""
        End If
        reader.Close()
        con.Close()

        txtCustomerDSAddress1.Text = AddAddress1
        txtCustomerDSAddress2.Text = AddAddress2
        txtCustomerDSCity.Text = AddCity
        txtCustomerDSZip.Text = AddZip
        cboDropShipState.Text = AddState
        txtCustomerCountry.Text = AddCountry
        txtShippingName.Text = AddName
    End Sub

    Public Sub LoadPOData()
        Dim GetPODataStatement As String = "SELECT * FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim GetPODataCommand As New SqlCommand(GetPODataStatement, con)
        GetPODataCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        GetPODataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetPODataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("PODate")) Then
                PODate = Today()
            Else
                PODate = reader.Item("PODate")
            End If
            If IsDBNull(reader.Item("VendorID")) Then
                VendorID = ""
            Else
                VendorID = reader.Item("VendorID")
            End If
            If IsDBNull(reader.Item("PaymentCode")) Then
                PaymentCode = "N30"
            Else
                PaymentCode = reader.Item("PaymentCode")
            End If
            If IsDBNull(reader.Item("POHeaderComment")) Then
                POHeaderComment = ""
            Else
                POHeaderComment = reader.Item("POHeaderComment")
            End If
            If IsDBNull(reader.Item("ShipDate")) Then
                ShipDate = Today()
            Else
                ShipDate = reader.Item("ShipDate")
            End If
            If IsDBNull(reader.Item("ShipMethodID")) Then
                ShipMethodID = "DELIVERY"
            Else
                ShipMethodID = reader.Item("ShipMethodID")
            End If
            If IsDBNull(reader.Item("FreightCharge")) Then
                FreightCharge = 0
            Else
                FreightCharge = reader.Item("FreightCharge")
            End If
            If IsDBNull(reader.Item("SalesTax")) Then
                SalesTax = 0
            Else
                SalesTax = reader.Item("SalesTax")
            End If
            If IsDBNull(reader.Item("ProductTotal")) Then
                ProductTotal = 0
            Else
                ProductTotal = reader.Item("ProductTotal")
            End If
            If IsDBNull(reader.Item("POTotal")) Then
                POTotal = 0
            Else
                POTotal = reader.Item("POTotal")
            End If
            If IsDBNull(reader.Item("PODropShipCustomerID")) Then
                PODropShipCustomerID = ""
            Else
                PODropShipCustomerID = reader.Item("PODropShipCustomerID")
            End If
            If IsDBNull(reader.Item("Status")) Then
                POStatus = "OPEN"
            Else
                POStatus = reader.Item("Status")
            End If
            If IsDBNull(reader.Item("POAdditionalShipTo")) Then
                POAdditionalShipTo = ""
            Else
                POAdditionalShipTo = reader.Item("POAdditionalShipTo")
            End If
            If IsDBNull(reader.Item("DropShipSalesOrderNumber")) Then
                DropShipSalesOrderNumber = 0
            Else
                DropShipSalesOrderNumber = reader.Item("DropShipSalesOrderNumber")
            End If
            If IsDBNull(reader.Item("ShipName")) Then
                ShipName = ""
            Else
                ShipName = reader.Item("ShipName")
            End If
            If IsDBNull(reader.Item("ShipAddress1")) Then
                ShipAddress1 = ""
            Else
                ShipAddress1 = reader.Item("ShipAddress1")
            End If
            If IsDBNull(reader.Item("ShipAddress2")) Then
                ShipAddress2 = ""
            Else
                ShipAddress2 = reader.Item("ShipAddress2")
            End If
            If IsDBNull(reader.Item("ShipCity")) Then
                ShipCity = ""
            Else
                ShipCity = reader.Item("ShipCity")
            End If
            If IsDBNull(reader.Item("ShipState")) Then
                ShipState = ""
            Else
                ShipState = reader.Item("ShipState")
            End If
            If IsDBNull(reader.Item("ShipZipCode")) Then
                ShipZipCode = ""
            Else
                ShipZipCode = reader.Item("ShipZipCode")
            End If
            If IsDBNull(reader.Item("ShipCountry")) Then
                ShipCountry = ""
            Else
                ShipCountry = reader.Item("ShipCountry")
            End If
            If IsDBNull(reader.Item("EstTotalBoxes")) Then
                EstTotalBoxes = 0
            Else
                EstTotalBoxes = reader.Item("EstTotalBoxes")
            End If
            If IsDBNull(reader.Item("EstTotalWeight")) Then
                EstTotalWeight = 0
            Else
                EstTotalWeight = reader.Item("EstTotalWeight")
            End If
            If IsDBNull(reader.Item("ShipMethod")) Then
                ShipMethod = ""
            Else
                ShipMethod = reader.Item("ShipMethod")
            End If
        Else
            PODate = Today()
            VendorID = ""
            PaymentCode = "N30"
            POHeaderComment = ""
            ShipDate = Today()
            ShipMethodID = ""
            FreightCharge = 0
            SalesTax = 0
            ProductTotal = 0
            POTotal = 0
            PODropShipCustomerID = ""
            POStatus = "OPEN"
            POAdditionalShipTo = ""
            DropShipSalesOrderNumber = 0
            ShipName = ""
            ShipAddress1 = ""
            ShipAddress2 = ""
            ShipCity = ""
            ShipState = ""
            ShipZipCode = ""
            ShipCountry = ""
            EstTotalBoxes = 0
            EstTotalWeight = 0
            ShipMethod = ""
        End If
        reader.Close()
        con.Close()

        'Load extracted data into text fields on form
        dtpPurchaseOrderDate.Text = PODate
        cboVendorCode.Text = VendorID
        cboPaymentTerms.Text = PaymentCode
        txtPOComment.Text = POHeaderComment
        dtpShipDatePicker.Text = ShipDate
        cboShipVia.Text = ShipMethodID
        txtFreightCharges.Text = FreightCharge
        txtSalesTax.Text = SalesTax
        txtDSSalesOrderNumber.Text = DropShipSalesOrderNumber
        cboCustomerDSName.Text = PODropShipCustomerID
        txtNumberOfBoxes.Text = EstTotalBoxes
        txtShippingWeight.Text = EstTotalWeight
        cboShipMethod.Text = ShipMethod

        LoadAdditionalShipTo()

        cboShipToID.Text = POAdditionalShipTo

        lblPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
        lblOrderTotal.Text = FormatCurrency(POTotal, 2)
        txtPOStatus.Text = POStatus

        If PODropShipCustomerID <> "" Or POStatus = "DROPSHIP" Or DropShipSalesOrderNumber > 0 Then
            chkDropShip.Checked = True
            cboCustomerDSName.Text = PODropShipCustomerID
            txtDSSalesOrderNumber.Text = DropShipSalesOrderNumber
            cboShipToID.Text = POAdditionalShipTo
        Else
            chkDropShip.Checked = False
            cboCustomerDSName.SelectedIndex = -1
            cboShipToID.SelectedIndex = -1
            txtDSSalesOrderNumber.Clear()
        End If

        'Load Address Details from PO Header Table last
        txtShippingName.Text = ShipName
        txtCustomerDSAddress1.Text = ShipAddress1
        txtCustomerDSAddress2.Text = ShipAddress2
        txtCustomerDSCity.Text = ShipCity
        txtCustomerDSZip.Text = ShipZipCode
        cboDropShipState.Text = ShipState
        txtCustomerCountry.Text = ShipCountry

        'Verify that an address loads
        If cboCustomerDSName.Text = "" And cboShipToID.Text = "" And txtCustomerDSAddress1.Text = "" And txtShippingName.Text = "" Then
            LoadShippingAddress()
        Else
            'do nothing
        End If

        If POStatus = "CLOSED" Then
            cmdAddItem.Enabled = False
            cmdClear.Enabled = False
            cmdDeletePO.Enabled = False
            cmdSavePO.Enabled = False
            cmdDeleteLine.Enabled = False
            cmdSaveLine.Enabled = False
            chkDropShip.Enabled = False
            cmdLoadDefaultAddress.Enabled = False

            Me.dgvPurchaseOrderLines.Columns("PartNumberColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("PartDescriptionColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("OrderQuantityColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("UnitCostColumn").ReadOnly = True
        ElseIf POStatus = "DROPSHIP" Then
            chkDropShip.Checked = True
            cmdAddItem.Enabled = True
            cmdClear.Enabled = True
            cmdDeletePO.Enabled = True
            cmdSavePO.Enabled = True
            cmdDeleteLine.Enabled = True
            cmdSaveLine.Enabled = True
            chkDropShip.Enabled = True
            cmdLoadDefaultAddress.Enabled = False

            Me.dgvPurchaseOrderLines.Columns("PartNumberColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("PartDescriptionColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("OrderQuantityColumn").ReadOnly = False
            Me.dgvPurchaseOrderLines.Columns("UnitCostColumn").ReadOnly = False
        Else
            chkDropShip.Checked = False
            cmdAddItem.Enabled = True
            cmdClear.Enabled = True
            cmdDeletePO.Enabled = True
            cmdSavePO.Enabled = True
            cmdDeleteLine.Enabled = True
            cmdSaveLine.Enabled = True
            chkDropShip.Enabled = True
            cmdLoadDefaultAddress.Enabled = True

            Me.dgvPurchaseOrderLines.Columns("PartNumberColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("PartDescriptionColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("OrderQuantityColumn").ReadOnly = False
            Me.dgvPurchaseOrderLines.Columns("UnitCostColumn").ReadOnly = False
        End If
    End Sub

    Public Sub LoadPOStatus()
        Dim StatusStatement As String = "SELECT Status FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim StatusCommand As New SqlCommand(StatusStatement, con)
        StatusCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        StatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            POStatus = CStr(StatusCommand.ExecuteScalar)
        Catch ex As System.Exception
            POStatus = "OPEN"
        End Try
        con.Close()

        txtPOStatus.Text = POStatus

        If POStatus = "CLOSED" Then
            cmdAddItem.Enabled = False
            cmdClear.Enabled = False
            cmdDeletePO.Enabled = False
            cmdSavePO.Enabled = False
            cmdDeleteLine.Enabled = False
            cmdSaveLine.Enabled = False
            chkDropShip.Enabled = False
            cmdLoadDefaultAddress.Enabled = False

            Me.dgvPurchaseOrderLines.Columns("PartNumberColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("PartDescriptionColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("OrderQuantityColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("UnitCostColumn").ReadOnly = True
        ElseIf POStatus = "DROPSHIP" Then
            chkDropShip.Checked = True
            cmdAddItem.Enabled = True
            cmdClear.Enabled = True
            cmdDeletePO.Enabled = True
            cmdSavePO.Enabled = True
            cmdDeleteLine.Enabled = True
            cmdSaveLine.Enabled = True
            chkDropShip.Enabled = True
            cmdLoadDefaultAddress.Enabled = False

            Me.dgvPurchaseOrderLines.Columns("PartNumberColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("PartDescriptionColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("OrderQuantityColumn").ReadOnly = False
            Me.dgvPurchaseOrderLines.Columns("UnitCostColumn").ReadOnly = False
        Else
            chkDropShip.Checked = False
            cmdAddItem.Enabled = True
            cmdClear.Enabled = True
            cmdDeletePO.Enabled = True
            cmdSavePO.Enabled = True
            cmdDeleteLine.Enabled = True
            cmdSaveLine.Enabled = True
            chkDropShip.Enabled = True
            cmdLoadDefaultAddress.Enabled = True

            Me.dgvPurchaseOrderLines.Columns("PartNumberColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("PartDescriptionColumn").ReadOnly = True
            Me.dgvPurchaseOrderLines.Columns("OrderQuantityColumn").ReadOnly = False
            Me.dgvPurchaseOrderLines.Columns("UnitCostColumn").ReadOnly = False
        End If
    End Sub

    Public Sub LoadReceiverVendor()
        Dim CheckVendorString As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE PONumber = @PONumber AND DivisionID = @DivisionID"
        Dim CheckVendorCommand As New SqlCommand(CheckVendorString, con)
        CheckVendorCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        CheckVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckReceiverVendor = CInt(CheckVendorCommand.ExecuteScalar)
        Catch ex As System.Exception
            CheckReceiverVendor = 0
        End Try
        con.Close()

        If CheckReceiverVendor = 0 Then
            cboVendorCode.Enabled = True
            txtVendorName.Enabled = True
        Else
            cboVendorCode.Enabled = False
            txtVendorName.Enabled = False
        End If
    End Sub

    Public Sub LoadGLAccounts()
        Dim GetGLAccountsStatement As String = "SELECT GLSalesAccount, GLReturnsAccount, GLInventoryAccount, GLCOGSAccount, GLPurchasesAccount, GLSalesOffsetAccount, GLAdjustmentAccount, GLIssuesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID;"
        Dim GetGLAccountsCommand As New SqlCommand(GetGLAccountsStatement, con)
        GetGLAccountsCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetGLAccountsCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("GLSalesAccount")) Then
                GLSalesAccount = ""
            Else
                GLSalesAccount = reader.Item("GLSalesAccount")
            End If
            If IsDBNull(reader.Item("GLReturnsAccount")) Then
                GLReturnsAccount = ""
            Else
                GLReturnsAccount = reader.Item("GLReturnsAccount")
            End If
            If IsDBNull(reader.Item("GLInventoryAccount")) Then
                GLInventoryAccount = ""
            Else
                GLInventoryAccount = reader.Item("GLInventoryAccount")
            End If
            If IsDBNull(reader.Item("GLCOGSAccount")) Then
                GLCOGSAccount = ""
            Else
                GLCOGSAccount = reader.Item("GLCOGSAccount")
            End If
            If IsDBNull(reader.Item("GLPurchasesAccount")) Then
                GLPurchasesAccount = ""
            Else
                GLPurchasesAccount = reader.Item("GLPurchasesAccount")
            End If
            If IsDBNull(reader.Item("GLSalesOffsetAccount")) Then
                GLSalesOffsetAccount = ""
            Else
                GLSalesOffsetAccount = reader.Item("GLSalesOffsetAccount")
            End If
            If IsDBNull(reader.Item("GLAdjustmentAccount")) Then
                GLAdjustmentAccount = ""
            Else
                GLAdjustmentAccount = reader.Item("GLAdjustmentAccount")
            End If
            If IsDBNull(reader.Item("GLIssuesAccount")) Then
                GLIssuesAccount = ""
            Else
                GLIssuesAccount = reader.Item("GLIssuesAccount")
            End If
        Else
            GLSalesAccount = ""
            GLReturnsAccount = ""
            GLInventoryAccount = ""
            GLCOGSAccount = ""
            GLPurchasesAccount = ""
            GLSalesOffsetAccount = ""
            GLAdjustmentAccount = ""
            GLIssuesAccount = ""
        End If
        reader.Close()
        con.Close()

        txtAdjustmentAccount.Text = GLAdjustmentAccount
        txtInventoryAccount.Text = GLInventoryAccount
        txtIssuesAccount.Text = GLIssuesAccount
        txtPurchaseAccount.Text = GLPurchasesAccount
        txtReturnsAccount.Text = GLReturnsAccount
        txtSalesAccount.Text = GLSalesAccount
        txtSalesOffsetAccount.Text = GLSalesOffsetAccount
        txtCOGSAccount.Text = GLCOGSAccount
    End Sub

    Public Sub LoadItemData()
        Dim ItemBoxCount, ItemPalletCount As Integer
        Dim strItemBoxCount, strItemPalletCount As String
        Dim MaxReceiver As Integer = 0

        Dim GetPartDataStatement As String = "SELECT BoxCount, PalletCount, LongDescription, ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID;"
        Dim GetPartDataCommand As New SqlCommand(GetPartDataStatement, con)
        GetPartDataCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        GetPartDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetPartDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("BoxCount")) Then
                ItemBoxCount = 0
            Else
                ItemBoxCount = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                ItemPalletCount = 0
            Else
                ItemPalletCount = reader.Item("PalletCount")
            End If
            If IsDBNull(reader.Item("LongDescription")) Then
                LongDescription = ""
            Else
                LongDescription = reader.Item("LongDescription")
            End If
            If IsDBNull(reader.Item("ItemClass")) Then
                ItemClass = ""
            Else
                ItemClass = reader.Item("ItemClass")
            End If
        Else
            ItemBoxCount = 0
            ItemPalletCount = 0
            LongDescription = ""
            ItemClass = ""
        End If
        reader.Close()
        con.Close()

        cboItemClass.Text = ItemClass
        txtLongDescription.Text = LongDescription
        strItemBoxCount = CStr(ItemBoxCount)
        strItemPalletCount = CStr(ItemPalletCount)

        If ItemBoxCount <> 0 Then
            lblBoxCount.Text = "Box Count -- " + strItemBoxCount
        Else
            lblBoxCount.Text = ""
        End If
        If ItemPalletCount <> 0 Then
            lblPalletCount.Text = "Pallet Count -- " + strItemPalletCount
        Else
            lblPalletCount.Text = ""
        End If

        If cboDivisionID.Text = "SLC" Then
            Dim MaxReceiverString As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND VendorID = @VendorID"
            Dim MaxReceiverCommand As New SqlCommand(MaxReceiverString, con)
            MaxReceiverCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            MaxReceiverCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MaxReceiverCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorCode.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxReceiver = CInt(MaxReceiverCommand.ExecuteScalar)
            Catch ex As System.Exception
                MaxReceiver = 0
            End Try
            con.Close()

            'Get Last Purchase Cost
            Dim LastPurchaseCostString As String = "SELECT MAX(UnitCost) FROM PurchaseOrderLineQuery WHERE PartNumber = @PartNumber AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
            Dim LastPurchaseCostCommand As New SqlCommand(LastPurchaseCostString, con)
            LastPurchaseCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPurchaseCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            LastPurchaseCostCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = MaxReceiver

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastPurchasePrice = CDbl(LastPurchaseCostCommand.ExecuteScalar)
            Catch ex As System.Exception
                LastPurchasePrice = 0
            End Try
            con.Close()
        Else
            Dim MaxReceiverString As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND PurchaseOrderHeaderKey <> @PurchaseOrderHeaderKey"
            Dim MaxReceiverCommand As New SqlCommand(MaxReceiverString, con)
            MaxReceiverCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            MaxReceiverCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MaxReceiverCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxReceiver = CInt(MaxReceiverCommand.ExecuteScalar)
            Catch ex As System.Exception
                MaxReceiver = 0
            End Try
            con.Close()

            'Get Last Purchase Cost
            Dim LastPurchaseCostString As String = "SELECT MAX(UnitCost) FROM PurchaseOrderLineQuery WHERE PartNumber = @PartNumber AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
            Dim LastPurchaseCostCommand As New SqlCommand(LastPurchaseCostString, con)
            LastPurchaseCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPurchaseCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            LastPurchaseCostCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = MaxReceiver

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastPurchasePrice = CDbl(LastPurchaseCostCommand.ExecuteScalar)
            Catch ex As System.Exception
                LastPurchasePrice = 0
            End Try
            con.Close()
        End If

        lblLastPurchaseCost.Text = FormatNumber(LastPurchasePrice, 5)
        txtLineUnitCost.Text = LastPurchasePrice
    End Sub

    Public Sub PopulateSaveTotals()
        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
        SUMExtendedAmountCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            ProductTotal = 0
        End Try
        con.Close()

        SalesTax = Val(txtSalesTax.Text)
        FreightCharge = Val(txtFreightCharges.Text)

        POTotal = ProductTotal + SalesTax + FreightCharge

        'Round Variables
        FreightCharge = Math.Round(FreightCharge, 2)
        SalesTax = Math.Round(SalesTax, 2)
        ProductTotal = Math.Round(ProductTotal, 2)
        POTotal = Math.Round(POTotal, 2)

        lblOrderTotal.Text = FormatCurrency(POTotal, 2)
        lblPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
    End Sub

    Public Sub PopulateFieldTotals()
        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) as TotalExtendedAmount, (SELECT SalesTax FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID) as SalesTax , (SELECT FreightCharge FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID) as FreightCharge FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID;"
        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
        SUMExtendedAmountCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = SUMExtendedAmountCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("TotalExtendedAmount")) Then
                ProductTotal = 0
            Else
                ProductTotal = reader.Item("TotalExtendedAmount")
            End If
            If IsDBNull(reader.Item("SalesTax")) Then
                SalesTax = 0
            Else
                SalesTax = reader.Item("SalesTax")
            End If
            If IsDBNull(reader.Item("FreightCharge")) Then
                FreightCharge = 0
            Else
                FreightCharge = reader.Item("FreightCharge")
            End If
        Else
            ProductTotal = 0
            SalesTax = 0
            FreightCharge = 0
        End If
        reader.Close()
        con.Close()

        POTotal = ProductTotal + SalesTax + FreightCharge

        'Round Variables
        FreightCharge = Math.Round(FreightCharge, 2)
        SalesTax = Math.Round(SalesTax, 2)
        ProductTotal = Math.Round(ProductTotal, 2)
        POTotal = Math.Round(POTotal, 2)

        lblOrderTotal.Text = FormatCurrency(POTotal, 2)
        lblPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
        txtFreightCharges.Text = FreightCharge
        txtSalesTax.Text = SalesTax
    End Sub

    Public Sub LoadTotals()
        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
        SUMExtendedAmountCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        SUMExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
        Catch ex As System.Exception
            ProductTotal = 0
        End Try
        con.Close()

        SalesTax = Val(txtSalesTax.Text)
        FreightCharge = Val(txtFreightCharges.Text)

        POTotal = ProductTotal + SalesTax + FreightCharge

        'Round Variables
        FreightCharge = Math.Round(FreightCharge, 2)
        SalesTax = Math.Round(SalesTax, 2)
        ProductTotal = Math.Round(ProductTotal, 2)
        POTotal = Math.Round(POTotal, 2)

        lblOrderTotal.Text = FormatCurrency(POTotal, 2)
        lblPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
    End Sub

    Public Sub CalculatePOWeight()
        Dim LinePartNumber As String
        Dim LineQuantity As Integer = 0
        Dim LineQuantityOpen As Integer = 0
        TotalWeight = 0
        Dim LineWeightOpen As Double = 0
        Dim TotalWeightOpen As Double = 0
        Dim BoxWeight As Double = 0
        Dim NewBoxCount As Double = 0

        For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
            Try
                LineQuantity = row.Cells("OrderQuantityColumn").Value
            Catch ex As System.Exception
                LineQuantity = 0
            End Try
            Try
                LinePartNumber = row.Cells("PartNumberColumn").Value
            Catch ex As System.Exception
                LinePartNumber = 0
            End Try
            Try
                LineQuantityOpen = row.Cells("POQuantityOpenColumn").Value
            Catch ex As System.Exception
                LineQuantityOpen = 0
            End Try

            Dim PieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim PieceWeightCommand As New SqlCommand(PieceWeightStatement, con)
            PieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = LinePartNumber
            PieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim BoxWeightStatement As String = "SELECT BoxWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim BoxWeightCommand As New SqlCommand(BoxWeightStatement, con)
            BoxWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = LinePartNumber
            BoxWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim NewBoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim NewBoxCountCommand As New SqlCommand(NewBoxCountStatement, con)
            NewBoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = LinePartNumber
            NewBoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                PieceWeight = CDbl(PieceWeightCommand.ExecuteScalar)
            Catch ex As System.Exception
                PieceWeight = 0
            End Try
            Try
                BoxWeight = CDbl(BoxWeightCommand.ExecuteScalar)
            Catch ex As System.Exception
                BoxWeight = 0
            End Try
            Try
                NewBoxCount = CInt(NewBoxCountCommand.ExecuteScalar)
            Catch ex As System.Exception
                NewBoxCount = 0
            End Try
            con.Close()

            If BoxWeight = 0 Or NewBoxCount = 0 Then
                LineWeight = PieceWeight * LineQuantity
                LineWeightOpen = PieceWeight * LineQuantityOpen
                TotalWeight = TotalWeight + LineWeight
                TotalWeightOpen = TotalWeightOpen + LineWeightOpen
            Else
                LineWeight = (LineQuantity / NewBoxCount) * BoxWeight
                LineWeightOpen = (LineQuantityOpen / NewBoxCount) * BoxWeight
                TotalWeight = LineWeight + TotalWeight
                TotalWeightOpen = LineWeightOpen + TotalWeightOpen
            End If
            '***************************************************************************************
            'Reset Line Weight
            LineWeight = 0
        Next

        TotalWeight = Math.Round(TotalWeight, 2)
        lblEstWeight.Text = TotalWeight
        TotalWeightOpen = Math.Round(TotalWeightOpen, 2)
        lblOpenWeight.Text = TotalWeightOpen
        lblOpen.Visible = True
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

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
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadPartByDescription2()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboLineDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboLinePartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart2()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboLinePartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboLineDescription.Text = PartDescription1
    End Sub

    Public Sub LoadEditPartNumber()
        ds7 = ds2.Copy()
        ds9 = ds8.Copy()
        cboLinePartNumber.DataSource = ds7.Tables("ItemList")
        cboLineDescription.DataSource = ds9.Tables("ItemList")
        cboLinePartNumber.SelectedIndex = -1
        cboLineDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadLineDetails()
        Dim CountReceiverLines As Integer = 0

        Dim LineUnitCostStatement As String = "SELECT UnitCost, OrderQuantity, ExtendedAmount, DebitGLAccount, CreditGLAccount, LineComment, PartNumber, PartDescription, (SELECT COUNT(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE PONumber = @PurchaseOrderHeaderKey AND POLineNumber = @PurchaseOrderLineNumber AND DivisionID = @DivisionID) as LineCount FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber"
        Dim LineUnitCostCommand As New SqlCommand(LineUnitCostStatement, con)
        LineUnitCostCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        LineUnitCostCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = Val(cboLineNumber.Text)
        LineUnitCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LineUnitCostCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("UnitCost")) Then
                LineEditUnitCost = 0
            Else
                LineEditUnitCost = reader.Item("UnitCost")
            End If
            If IsDBNull(reader.Item("OrderQuantity")) Then
                LineEditOrderQuantity = 0
            Else
                LineEditOrderQuantity = reader.Item("OrderQuantity")
            End If
            If IsDBNull(reader.Item("ExtendedAmount")) Then
                LineEditExtendedAmount = 0
            Else
                LineEditExtendedAmount = reader.Item("ExtendedAmount")
            End If
            If IsDBNull(reader.Item("DebitGLAccount")) Then
                LineDebitGLAccount = ""
            Else
                LineDebitGLAccount = reader.Item("DebitGLAccount")
            End If
            If IsDBNull(reader.Item("CreditGLAccount")) Then
                LineCreditGLAccount = ""
            Else
                LineCreditGLAccount = reader.Item("CreditGLAccount")
            End If
            If IsDBNull(reader.Item("LineComment")) Then
                LineComment = ""
            Else
                LineComment = reader.Item("LineComment")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                LineEditPartNumber = ""
            Else
                LineEditPartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("PartDescription")) Then
                LineEditPartDescription = ""
            Else
                LineEditPartDescription = reader.Item("PartDescription")
            End If
            If IsDBNull(reader.Item("LineCount")) Then
                CountReceiverLines = 0
            Else
                CountReceiverLines = reader.Item("LineCount")
            End If
        Else
            LineEditUnitCost = 0
            LineEditOrderQuantity = 0
            LineEditExtendedAmount = 0
            LineDebitGLAccount = ""
            LineCreditGLAccount = ""
            LineComment = ""
            LineEditPartNumber = ""
            LineEditPartDescription = ""
            CountReceiverLines = 0
        End If
        reader.Close()
        con.Close()
        isLoaded = False
        txtLineUnitCost.Text = LineEditUnitCost
        txtLineOrderQuantity.Text = LineEditOrderQuantity
        txtLineExtendedCost.Text = FormatCurrency(LineEditExtendedAmount, 2)
        txtLineGLCredit.Text = LineCreditGLAccount
        txtLineGLDebit.Text = LineDebitGLAccount
        txtLineComment2.Text = LineComment
        cboLinePartNumber.Text = LineEditPartNumber
        cboLineDescription.Text = LineEditPartDescription
        isLoaded = True

        If CountReceiverLines = 0 Then
            cboLinePartNumber.Enabled = True
            cboLineDescription.Enabled = True
        Else
            cboLinePartNumber.Enabled = False
            cboLineDescription.Enabled = False
        End If
    End Sub

    Public Sub LoadPODetailTotals()
        Dim NumberOfReceivers, NumberOfReturns, NumberOfVouchers As Integer
        Dim TotalReceivers, TotalReturns, TotalVouchers As Double
        Dim TotalDifference As Double = 0

        Dim NumberOfReceiversStatement As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingHeaderTable WHERE PONumber = @PONumber AND DivisionID = @DivisionID"
        Dim NumberOfReceiversCommand As New SqlCommand(NumberOfReceiversStatement, con)
        NumberOfReceiversCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        NumberOfReceiversCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim NumberOfReturnsStatement As String = "SELECT COUNT(ReturnNumber) FROM VendorReturn WHERE PONumber = @PONumber AND DivisionID = @DivisionID"
        Dim NumberOfReturnsCommand As New SqlCommand(NumberOfReturnsStatement, con)
        NumberOfReturnsCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        NumberOfReturnsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim NumberOfVouchersStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE PONumber = @PONumber AND DivisionID = @DivisionID"
        Dim NumberOfVouchersCommand As New SqlCommand(NumberOfVouchersStatement, con)
        NumberOfVouchersCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        NumberOfVouchersCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            NumberOfReceivers = CInt(NumberOfReceiversCommand.ExecuteScalar)
        Catch ex As Exception
            NumberOfReceivers = 0
        End Try
        Try
            NumberOfReturns = CInt(NumberOfReturnsCommand.ExecuteScalar)
        Catch ex As Exception
            NumberOfReturns = 0
        End Try
        Try
            NumberOfVouchers = CInt(NumberOfVouchersCommand.ExecuteScalar)
        Catch ex As Exception
            NumberOfVouchers = 0
        End Try
        con.Close()

        Dim TotalReceiversStatement As String = "SELECT SUM(POTotal) FROM ReceivingHeaderTable WHERE PONumber = @PONumber AND DivisionID = @DivisionID"
        Dim TotalReceiversCommand As New SqlCommand(TotalReceiversStatement, con)
        TotalReceiversCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        TotalReceiversCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalReturnsStatement As String = "SELECT SUM(ReturnTotal) FROM VendorReturn WHERE PONumber = @PONumber AND DivisionID = @DivisionID"
        Dim TotalReturnsCommand As New SqlCommand(TotalReturnsStatement, con)
        TotalReturnsCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        TotalReturnsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalVouchersStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE PONumber = @PONumber AND DivisionID = @DivisionID"
        Dim TotalVouchersCommand As New SqlCommand(TotalVouchersStatement, con)
        TotalVouchersCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        TotalVouchersCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalReceivers = CInt(TotalReceiversCommand.ExecuteScalar)
        Catch ex As Exception
            TotalReceivers = 0
        End Try
        Try
            TotalReturns = CInt(TotalReturnsCommand.ExecuteScalar)
        Catch ex As Exception
            TotalReturns = 0
        End Try
        Try
            TotalVouchers = CInt(TotalVouchersCommand.ExecuteScalar)
        Catch ex As Exception
            TotalVouchers = 0
        End Try
        con.Close()

        TotalDifference = TotalReceivers - (TotalReturns + TotalVouchers)

        lblNumberReceivers.Text = NumberOfReceivers
        lblNumberReturns.Text = NumberOfReturns
        lblNumberVouchers.Text = NumberOfVouchers
        lblReceiverTotal.Text = FormatCurrency(TotalReceivers, 2)
        lblReturnTotal.Text = FormatCurrency(TotalReturns, 2)
        lblVoucherTotal.Text = FormatCurrency(TotalVouchers, 2)
        lblDifference.Text = FormatCurrency(TotalDifference, 2)
    End Sub

    'Load datagrid view routines

    Private Sub dgvPurchaseOrderLines_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPurchaseOrderLines.CellContentClick
        If Me.dgvPurchaseOrderLines.RowCount <> 0 Then
            Dim LineNumber As Integer = 0

            Dim RowIndex As Integer = Me.dgvPurchaseOrderLines.CurrentCell.RowIndex

            Try
                LineNumber = Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("PurchaseOrderLineNumberColumn").Value
            Catch ex As Exception
                LineNumber = 0
            End Try

            cboLineNumber.Text = LineNumber
        End If
    End Sub

    Private Sub dgvPurchaseOrderLines_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvPurchaseOrderLines.CellFormatting
        If e.RowIndex = -1 Then Exit Sub
        If dgvPurchaseOrderLines.Item("LineStatusColumn", e.RowIndex).Value = "DROPSHIP" Then
            dgvPurchaseOrderLines.Item(e.ColumnIndex, e.RowIndex).ToolTipText = "Drop Ship"
            ''DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
        Else
            dgvPurchaseOrderLines.Item(e.ColumnIndex, e.RowIndex).ToolTipText = String.Empty
            ''DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        End If
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvPurchaseOrderLines.CellValueChanged
        If isSomeoneEditing() Then
            ShowData()
            LoadPOData()
            CalculatePOWeight()
            LoadReceiverVendor()
            Exit Sub
        End If

        LockBatch()

        If Me.dgvPurchaseOrderLines.RowCount = 0 Then
            'Do nothing
        Else
            If txtPOStatus.Text = "CLOSED" Then
                Dim LineExtendedAmount, LineUnitCost As Double
                Dim LineOrderQuantity, LineNumber As Integer
                Dim LineComment As String

                Dim RowIndex As Integer = Me.dgvPurchaseOrderLines.CurrentCell.RowIndex

                Try
                    LineNumber = Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("PurchaseOrderLineNumberColumn").Value
                Catch ex As Exception
                    LineNumber = 0
                End Try
                Try
                    LineOrderQuantity = Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("OrderQuantityColumn").Value
                Catch ex As Exception
                    LineOrderQuantity = 0
                End Try
                Try
                    LineUnitCost = Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("UnitCostColumn").Value
                Catch ex As Exception
                    LineUnitCost = 0
                End Try
                Try
                    LineComment = Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("LineCommentColumn").Value
                Catch ex As Exception
                    LineComment = ""
                End Try

                LineExtendedAmount = LineUnitCost * LineOrderQuantity
                LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

                ''checks to see if there are more than what the database can handle, if so will truncate the line comment if the user wants to truncate
                If LineComment.Length > 500 Then
                    If MessageBox.Show("Line comment entered is more than 500 characters. Do you wish to remove the remaining characters over 500?", "Truncation will occur", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
                        Exit Sub
                    End If
                    LineComment = LineComment.Substring(0, 500)
                End If

                Try
                    'UPDATE Purchase Order Extended Amount based on line changes
                    cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET UnitCost = @UnitCost, ExtendedAmount = @ExtendedAmount, LineComment = @LineComment WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = LineNumber
                        .Add("@UnitCost", SqlDbType.VarChar).Value = LineUnitCost
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Do nothing
                End Try

                'Load totals
                LoadTotals()

                'Save Totals in the Header Table
                Try
                    'UPDATE Purchase Order Extended Amount based on line changes
                    cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET ProductTotal = @ProductTotal, FreightCharge = @FreightCharge, SalesTax = @SalesTax, POTotal = @POTotal WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        .Add("@FreightCharge", SqlDbType.VarChar).Value = FreightCharge
                        .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                        .Add("@POTotal", SqlDbType.VarChar).Value = POTotal
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Do nothing
                End Try
            Else
                Dim LineExtendedAmount, LineUnitCost As Double
                Dim LineOrderQuantity, LineNumber As Double
                Dim LineStatus As String

                Dim RowIndex As Integer = Me.dgvPurchaseOrderLines.CurrentCell.RowIndex

                Try
                    LineUnitCost = Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("UnitCostColumn").Value
                Catch ex As System.Exception
                    LineUnitCost = 0
                End Try
                Try
                    LineOrderQuantity = Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("OrderQuantityColumn").Value
                Catch ex As System.Exception
                    LineOrderQuantity = 0
                End Try
                Try
                    LineNumber = Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("PurchaseOrderLineNumberColumn").Value
                Catch ex As System.Exception
                    LineNumber = 1
                End Try
                Try
                    LineComment = Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("LineCommentColumn").Value
                Catch ex As System.Exception
                    LineComment = ""
                End Try
                Try
                    LinePartNumber = Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("PartNumberColumn").Value
                Catch ex As System.Exception
                    LinePartNumber = ""
                End Try
                Try
                    LinePartDescription = Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("PartDescriptionColumn").Value
                Catch ex As System.Exception
                    LinePartDescription = ""
                End Try
                Try
                    LineStatus = Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("LineStatusColumn").Value
                Catch ex As System.Exception
                    LineStatus = "CLOSED"
                End Try

                LineExtendedAmount = LineUnitCost * LineOrderQuantity
                LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

                Me.dgvPurchaseOrderLines.Rows(RowIndex).Cells("ExtendedAmountColumn").Value = LineExtendedAmount

                'Run check to see if quantity changed is less than quantity received
                Dim CheckReceiverQuantityStatement As String = "SELECT QuantityReceived FROM ReceivingLineQuery1 WHERE PONumber = @PONumber AND POLineNumber = @POLineNumber AND DivisionID = @DivisionID"
                Dim CheckReceiverQuantityCommand As New SqlCommand(CheckReceiverQuantityStatement, con)
                CheckReceiverQuantityCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                CheckReceiverQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CheckReceiverQuantityCommand.Parameters.Add("@POLineNumber", SqlDbType.VarChar).Value = LineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckReceiverQuantity = CInt(CheckReceiverQuantityCommand.ExecuteScalar)
                Catch ex As System.Exception
                    CheckReceiverQuantity = 0
                End Try
                con.Close()

                'Get line status based on if line change is different in grid
                If LineOrderQuantity < CheckReceiverQuantity Then
                    'Do not update line - PO Line cannot be less than amount already received
                    MsgBox("Line Quantity cannot be less than what has been received.", MsgBoxStyle.OkOnly)
                    ShowData()
                    Exit Sub
                ElseIf LineOrderQuantity > CheckReceiverQuantity Then
                    If chkDropShip.Checked = True Then
                        LineStatus = "DROPSHIP"
                    Else
                        LineStatus = "OPEN"
                    End If

                    Try
                        'UPDATE Purchase Order Extended Amount based on line changes
                        cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET PartNumber = @PartNumber, PartDescription = @PartDescription, UnitCost = @UnitCost, OrderQuantity = @OrderQuantity, ExtendedAmount = @ExtendedAmount, LineComment = @LineComment, LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                        With cmd.Parameters
                            .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                            .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = LineNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = LinePartDescription
                            .Add("@UnitCost", SqlDbType.VarChar).Value = LineUnitCost
                            .Add("@OrderQuantity", SqlDbType.VarChar).Value = LineOrderQuantity
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                            .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                            .Add("@LineStatus", SqlDbType.VarChar).Value = LineStatus
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As System.Exception
                        'Do nothing
                    End Try
                ElseIf LineOrderQuantity = CheckReceiverQuantity Then
                    LineStatus = "CLOSED"

                    Try
                        'UPDATE Purchase Order Extended Amount based on line changes
                        cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET PartNumber = @PartNumber, PartDescription = @PartDescription, UnitCost = @UnitCost,OrderQuantity = @OrderQuantity, ExtendedAmount = @ExtendedAmount, LineComment = @LineComment, LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                        With cmd.Parameters
                            .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                            .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = LineNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = LinePartDescription
                            .Add("@UnitCost", SqlDbType.VarChar).Value = LineUnitCost
                            .Add("@OrderQuantity", SqlDbType.VarChar).Value = LineOrderQuantity
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                            .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                            .Add("@LineStatus", SqlDbType.VarChar).Value = LineStatus
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As System.Exception
                        'Do nothing
                    End Try
                End If

                LoadTotals()

                'Load PO Status
                If chkDropShip.Checked = True And POStatus <> "CLOSED" Then
                    POStatus = "DROPSHIP"

                    'Update PO Lines to Drop Ship
                    cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf chkDropShip.Checked = False And POStatus <> "CLOSED" Then
                    POStatus = "OPEN"
                Else
                    POStatus = "CLOSED"
                End If

                'Reload Datagrid
                ShowData()

                'Save Totals in the Header Table
                Try
                    'UPDATE Purchase Order Extended Amount based on line changes
                    cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET ProductTotal = @ProductTotal, FreightCharge = @FreightCharge, SalesTax = @SalesTax, POTotal = @POTotal WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        .Add("@FreightCharge", SqlDbType.VarChar).Value = FreightCharge
                        .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                        .Add("@POTotal", SqlDbType.VarChar).Value = POTotal
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Do nothing
                End Try
            End If
        End If
    End Sub

    Private Sub dgvReceiverTable_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceiverTable.CellDoubleClick
        If dgvReceiverTable.RowCount > 0 Then
            Dim RowReceiverNumber As Integer = 0
            Dim RowIndex As Integer = Me.dgvReceiverTable.CurrentCell.RowIndex

            RowReceiverNumber = Me.dgvReceiverTable.Rows(RowIndex).Cells("ReceivingHeaderKeyColumnRT").Value
            GlobalReceiverNumber = RowReceiverNumber
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintReceiver As New PrintReceiver
                Dim result = NewPrintReceiver.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvReturnTable_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReturnTable.CellDoubleClick
        If dgvReturnTable.RowCount > 0 Then
            Dim RowReturnNumber As Integer = 0
            Dim RowIndex As Integer = Me.dgvReturnTable.CurrentCell.RowIndex

            RowReturnNumber = Me.dgvReturnTable.Rows(RowIndex).Cells("ReturnNumberColumnRTT").Value

            GlobalVendorReturnNumber = RowReturnNumber
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintVendorReturn As New PrintVendorReturn
                Dim result = NewPrintVendorReturn.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvROITable_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvROITable.CellDoubleClick
        If dgvROITable.RowCount > 0 Then
            Dim RowVoucherNumber As Integer = 0
            Dim RowIndex As Integer = Me.dgvROITable.CurrentCell.RowIndex

            RowVoucherNumber = Me.dgvROITable.Rows(RowIndex).Cells("VoucherNumberColumnVT").Value

            GlobalVoucherNumber = RowVoucherNumber
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintVoucher As New PrintVoucher
                Dim result = NewPrintVoucher.ShowDialog()
            End Using
        End If
    End Sub

    'Save / Update / Delete Routines

    Public Sub SaveInsertProcedure()
        'Find the next PO Number to use
        Dim MAXStatement As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderHeaderTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As System.Exception
            LastTransactionNumber = 6200000
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1

        Try
            'Write Data to Purchase Order Header Database Table
            cmd = New SqlCommand("Insert Into PurchaseOrderHeaderTable(PurchaseOrderHeaderKey, PODate, VendorID, PaymentCode, POHeaderComment, ShipDate, ShipMethodID, FreightCharge, SalesTax, Status, ProductTotal, POTotal, PODropShipCustomerID, POAdditionalShipTo, DivisionID, DropShipSalesOrderNumber, PurchaseAgent, Locked, ShipName, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZipCode, ShipCountry, EstTotalWeight, EstTotalBoxes, ShipMethod)Values(@PurchaseOrderHeaderKey, @PODate, @VendorID, @PaymentCode, @POHeaderComment, @ShipDate, @ShipMethodID, @FreightCharge, @SalesTax, @Status, @ProductTotal, @POTotal, @PODropShipCustomerID, @POAdditionalShipTo, @DivisionID, @DropShipSalesOrderNumber, @PurchaseAgent, @Locked, @ShipName, @ShipAddress1, @ShipAddress2, @ShipCity, @ShipState, @ShipZipCode, @ShipCountry, @EstTotalWeight, @EstTotalBoxes, @ShipMethod)", con)

            With cmd.Parameters
                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                .Add("@PODate", SqlDbType.VarChar).Value = PODate
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorCode.Text
                .Add("@PaymentCode", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                .Add("@POHeaderComment", SqlDbType.VarChar).Value = txtPOComment.Text
                .Add("@ShipDate", SqlDbType.VarChar).Value = PODate
                .Add("@ShipMethodID", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharges.Text)
                .Add("@SalesTax", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@POTotal", SqlDbType.VarChar).Value = POTotal
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                .Add("@PODropShipCustomerID", SqlDbType.VarChar).Value = cboCustomerDSName.Text
                .Add("@POAdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@DropShipSalesOrderNumber", SqlDbType.VarChar).Value = Val(txtDSSalesOrderNumber.Text)
                .Add("@PurchaseAgent", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@ShipName", SqlDbType.VarChar).Value = txtShippingName.Text
                .Add("@ShipAddress1", SqlDbType.VarChar).Value = txtCustomerDSAddress1.Text
                .Add("@ShipAddress2", SqlDbType.VarChar).Value = txtCustomerDSAddress2.Text
                .Add("@ShipCity", SqlDbType.VarChar).Value = txtCustomerDSCity.Text
                .Add("@ShipState", SqlDbType.VarChar).Value = cboDropShipState.Text
                .Add("@ShipZipCode", SqlDbType.VarChar).Value = txtCustomerDSZip.Text
                .Add("@ShipCountry", SqlDbType.VarChar).Value = txtCustomerCountry.Text
                .Add("@EstTotalWeight", SqlDbType.VarChar).Value = Val(txtShippingWeight.Text)
                .Add("@EstTotalBoxes", SqlDbType.VarChar).Value = Val(txtNumberOfBoxes.Text)
                .Add("@ShipMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            'If Insert fails, write error message to database
            'Log error on update failure
            Dim TempPONumber As Integer = 0
            Dim strPONumber As String
            TempPONumber = Val(cboPurchaseOrderNumber.Text)
            strPONumber = CStr(TempPONumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Insert Command --- PO Form"
            ErrorReferenceNumber = "PO # " + strPONumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()

            ClearAllData()
            ClearVariables()
            ClearDataInDatagrid()
            cboPurchaseOrderNumber.SelectedIndex = -1
            MsgBox("PO # has been taken. Select a new order #.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Public Sub SaveUpdateProcedure()
        Try
            If txtShippingWeight.Text = "" Then
                CurrentShippingWeight = Val(lblEstWeight.Text)
            Else
                CurrentShippingWeight = Val(txtShippingWeight.Text)
            End If

            'Create command to save data from text boxes
            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET VendorID = @VendorID, PODate = @PODate, PaymentCode = @PaymentCode, POHeaderComment = @POHeaderComment, ShipDate = @ShipDate, ShipMethodID = @ShipMethodID, FreightCharge = @FreightCharge, SalesTax = @SalesTax, ProductTotal = @ProductTotal, POTotal = @POTotal, Status = @Status, PODropShipCustomerID = @PODropShipCustomerID, POAdditionalShipTo = @POAdditionalShipTo, DropShipSalesOrderNumber = @DropShipSalesOrderNumber, ShipName = @ShipName, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZipCode = @ShipZipCode, ShipCountry = @ShipCountry, EstTotalWeight = @EstTotalWeight, EstTotalBoxes = @EstTotalBoxes, ShipMethod = @ShipMethod WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                .Add("@PODate", SqlDbType.VarChar).Value = PODate
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorCode.Text
                .Add("@PaymentCode", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                .Add("@POHeaderComment", SqlDbType.VarChar).Value = txtPOComment.Text
                .Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipDatePicker.Value
                .Add("@ShipMethodID", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharges.Text)
                .Add("@SalesTax", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@POTotal", SqlDbType.VarChar).Value = POTotal
                .Add("@Status", SqlDbType.VarChar).Value = POStatus
                .Add("@PODropShipCustomerID", SqlDbType.VarChar).Value = cboCustomerDSName.Text
                .Add("@POAdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@DropShipSalesOrderNumber", SqlDbType.VarChar).Value = Val(txtDSSalesOrderNumber.Text)
                '.Add("@PurchaseAgent", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                .Add("@ShipName", SqlDbType.VarChar).Value = txtShippingName.Text
                .Add("@ShipAddress1", SqlDbType.VarChar).Value = txtCustomerDSAddress1.Text
                .Add("@ShipAddress2", SqlDbType.VarChar).Value = txtCustomerDSAddress2.Text
                .Add("@ShipCity", SqlDbType.VarChar).Value = txtCustomerDSCity.Text
                .Add("@ShipState", SqlDbType.VarChar).Value = cboDropShipState.Text
                .Add("@ShipZipCode", SqlDbType.VarChar).Value = txtCustomerDSZip.Text
                .Add("@ShipCountry", SqlDbType.VarChar).Value = txtCustomerCountry.Text
                .Add("@EstTotalWeight", SqlDbType.VarChar).Value = CurrentShippingWeight
                .Add("@EstTotalBoxes", SqlDbType.VarChar).Value = Val(txtNumberOfBoxes.Text)
                .Add("@ShipMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            'If Insert fails, write error message to database
            'Log error on update failure
            Dim TempPONumber As Integer = 0
            Dim strPONumber As String
            TempPONumber = Val(cboPurchaseOrderNumber.Text)
            strPONumber = CStr(TempPONumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Update Command --- PO Form"
            ErrorReferenceNumber = "PO # " + strPONumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Public Sub SaveUpdateWOVendorProcedure()
        Try
            'Create command to save data from text boxes
            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET PODate = @PODate, PaymentCode = @PaymentCode, POHeaderComment = @POHeaderComment, ShipDate = @ShipDate, ShipMethodID = @ShipMethodID, FreightCharge = @FreightCharge, SalesTax = @SalesTax, ProductTotal = @ProductTotal, POTotal = @POTotal, Status = @Status, PODropShipCustomerID = @PODropShipCustomerID, POAdditionalShipTo = @POAdditionalShipTo, DropShipSalesOrderNumber = @DropShipSalesOrderNumber, ShipName = @ShipName, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZipCode = @ShipZipCode, ShipCountry = @ShipCountry,  EstTotalWeight = @EstTotalWeight, EstTotalBoxes = @EstTotalBoxes, ShipMethod = @ShipMethod WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                .Add("@PODate", SqlDbType.VarChar).Value = PODate
                '.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorCode.Text
                .Add("@PaymentCode", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                .Add("@POHeaderComment", SqlDbType.VarChar).Value = txtPOComment.Text
                .Add("@ShipDate", SqlDbType.VarChar).Value = ShipDate
                .Add("@ShipMethodID", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharges.Text)
                .Add("@SalesTax", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@POTotal", SqlDbType.VarChar).Value = POTotal
                .Add("@Status", SqlDbType.VarChar).Value = POStatus
                .Add("@PODropShipCustomerID", SqlDbType.VarChar).Value = cboCustomerDSName.Text
                .Add("@POAdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@DropShipSalesOrderNumber", SqlDbType.VarChar).Value = Val(txtDSSalesOrderNumber.Text)
                '.Add("@PurchaseAgent", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                .Add("@ShipName", SqlDbType.VarChar).Value = txtShippingName.Text
                .Add("@ShipAddress1", SqlDbType.VarChar).Value = txtCustomerDSAddress1.Text
                .Add("@ShipAddress2", SqlDbType.VarChar).Value = txtCustomerDSAddress2.Text
                .Add("@ShipCity", SqlDbType.VarChar).Value = txtCustomerDSCity.Text
                .Add("@ShipState", SqlDbType.VarChar).Value = cboDropShipState.Text
                .Add("@ShipZipCode", SqlDbType.VarChar).Value = txtCustomerDSZip.Text
                .Add("@ShipCountry", SqlDbType.VarChar).Value = txtCustomerCountry.Text
                .Add("@EstTotalWeight", SqlDbType.VarChar).Value = Val(txtShippingWeight.Text)
                .Add("@EstTotalBoxes", SqlDbType.VarChar).Value = Val(txtNumberOfBoxes.Text)
                .Add("@ShipMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            'If Insert fails, write error message to database
            'Log error on update failure
            Dim TempPONumber As Integer = 0
            Dim strPONumber As String
            TempPONumber = Val(cboPurchaseOrderNumber.Text)
            strPONumber = CStr(TempPONumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Update Command --- PO Form"
            ErrorReferenceNumber = "PO # " + strPONumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Public Sub CreateNewPartNumber()
        'Create part numnber and fill fields
        Dim PPL, SPL As String

        If cboDivisionID.Text = "TWD" Then
            PPL = "NON-INVENTORY"
            SPL = "SUPPLY"
        ElseIf cboDivisionID.Text = "CBS" Then
            PPL = "SLC-PURCHASEPRODUCTS"
            SPL = "SPL-CBS"
        ElseIf cboDivisionID.Text = "SLC" Then
            PPL = "SLC-PURCHASEPRODUCTS"
            SPL = "SPL-SLC"
        Else
            PPL = ""
            SPL = ""
        End If

        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("Insert Into ItemList(ItemID, DivisionID, ShortDescription, LongDescription, ItemClass, PurchProdLineID, SalesProdLineID, PieceWeight, BoxCount, PalletCount, StandardCost, StandardPrice, OldPartNumber, MinimumStock, MaximumStock, CreationDate, BeginningBalance, FOXNumber, BoxType, NominalDiameter, NominalLength, AddAccessory, PreferredVendor, Locked, SafetyDataSheet, BoxWeight, Comments, LeadTime)Values(@ItemID, @DivisionID, @ShortDescription, @LongDescription, @ItemClass, @PurchProdLineID, @SalesProdLineID, @PieceWeight, @BoxCount, @PalletCount, @StandardCost, @StandardPrice, @OldPartNumber, @MinimumStock, @MaximumStock, @CreationDate, @BeginningBalance, @FOXNumber, @BoxType, @NominalDiameter, @NominalLength, @AddAccessory, @PreferredVendor, @Locked, @SafetyDataSheet, @BoxWeight, @Comments, @LeadTime)", con)

        With cmd.Parameters
            .Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text.ToUpper
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text.ToUpper
            .Add("@LongDescription", SqlDbType.VarChar).Value = cboPartDescription.Text.ToUpper
            .Add("@ItemClass", SqlDbType.VarChar).Value = cboNewItemClass.Text
            .Add("@PurchProdLineID", SqlDbType.VarChar).Value = PPL
            .Add("@SalesProdLineID", SqlDbType.VarChar).Value = SPL
            .Add("@PieceWeight", SqlDbType.VarChar).Value = 0
            .Add("@BoxCount", SqlDbType.VarChar).Value = 0
            .Add("@PalletCount", SqlDbType.VarChar).Value = 0
            .Add("@StandardCost", SqlDbType.VarChar).Value = 0
            .Add("@StandardPrice", SqlDbType.VarChar).Value = 0
            .Add("@OldPartNumber", SqlDbType.VarChar).Value = ""
            .Add("@MinimumStock", SqlDbType.VarChar).Value = 0
            .Add("@MaximumStock", SqlDbType.VarChar).Value = 0
            .Add("@CreationDate", SqlDbType.VarChar).Value = dtpPurchaseOrderDate.Text
            .Add("@BeginningBalance", SqlDbType.VarChar).Value = 0
            .Add("@FOXNumber", SqlDbType.VarChar).Value = 0
            .Add("@BoxType", SqlDbType.VarChar).Value = "BOX-NONSTANDARD"
            .Add("@NominalDiameter", SqlDbType.VarChar).Value = 0
            .Add("@NominalLength", SqlDbType.VarChar).Value = 0
            .Add("@AddAccessory", SqlDbType.VarChar).Value = "NO"
            .Add("@PreferredVendor", SqlDbType.VarChar).Value = ""
            .Add("@Locked", SqlDbType.VarChar).Value = ""
            .Add("@SafetyDataSheet", SqlDbType.VarChar).Value = ""
            .Add("@BoxWeight", SqlDbType.VarChar).Value = 0
            .Add("@Comments", SqlDbType.VarChar).Value = "CREATED FROM PO"
            .Add("@LeadTime", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Validation / Error checking / Clear

    Public Sub LoadFormatting()
        Dim CountIndex As Integer = 0
        Dim LineStatus As String = ""

        For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
            Try
                LineStatus = dgvPurchaseOrderLines.Rows(CountIndex).Cells("LineStatusColumn").Value
            Catch ex As Exception

            End Try

            If LineStatus = "DROPSHIP" Then
                Try
                    dgvPurchaseOrderLines.Rows(CountIndex).Cells("PartNumberColumn").Style.ForeColor = Color.Blue

                Catch ex As Exception
                    'skip
                End Try
            Else
                Try
                    dgvPurchaseOrderLines.Rows(CountIndex).Cells("PartNumberColumn").Style.ForeColor = Color.Black
                Catch ex As Exception
                    'skip
                End Try
            End If

            CountIndex = CountIndex + 1
        Next
    End Sub

    Public Sub ClearOnLoad()
        txtInventoryAccount.Refresh()
        txtIssuesAccount.Refresh()
        txtPurchaseAccount.Refresh()
        txtReturnsAccount.Refresh()
        txtSalesAccount.Refresh()
        txtSalesOffsetAccount.Refresh()
        txtCOGSAccount.Refresh()
        txtAdjustmentAccount.Refresh()
        txtLongDescription.Refresh()
        txtCustomerDSAddress1.Refresh()
        txtCustomerDSAddress2.Refresh()
        txtCustomerDSCity.Refresh()
        txtCustomerDSZip.Refresh()
        txtFreightCharges.Refresh()
        txtPOComment.Refresh()
        txtSalesTax.Refresh()
        txtLineComment2.Refresh()
        txtLineComment.Refresh()
        txtDSSalesOrderNumber.Refresh()
        txtVendorName.Refresh()

        'Clear text boxes on load
        cboPaymentTerms.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboVendorCode.SelectedIndex = -1
        cboDropShipState.SelectedIndex = -1
        cboCustomerDSName.SelectedIndex = -1
        cboPurchaseOrderNumber.SelectedIndex = -1
        cboDropShipState.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboLineDescription.SelectedIndex = -1
        cboLineNumber.SelectedIndex = -1
        cboLinePartNumber.SelectedIndex = -1
        cboShipToID.SelectedIndex = -1
        cboNewItemClass.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1

        txtInventoryAccount.Clear()
        txtIssuesAccount.Clear()
        txtPurchaseAccount.Clear()
        txtReturnsAccount.Clear()
        txtSalesAccount.Clear()
        txtSalesOffsetAccount.Clear()
        txtCOGSAccount.Clear()
        txtAdjustmentAccount.Clear()
        txtLongDescription.Clear()
        txtCustomerDSAddress1.Clear()
        txtCustomerDSAddress2.Clear()
        txtCustomerDSCity.Clear()
        txtCustomerDSZip.Clear()
        txtFreightCharges.Clear()
        txtPOComment.Clear()
        txtSalesTax.Clear()
        txtLineComment2.Clear()
        txtLineComment.Clear()
        txtDSSalesOrderNumber.Clear()
        txtVendorName.Clear()
        txtShippingName.Clear()
        txtDivisionVendor.Clear()

        dtpPurchaseOrderDate.Text = ""
        dtpShipDatePicker.Text = ""

        chkDropShip.Checked = False

        lblAmount.Text = ""
        lblLastPurchaseCost.Text = ""
        lblOrderTotal.Text = ""
        lblPurchaseTotal.Text = ""
        lblPalletCount.Text = ""
        lblBoxCount.Text = ""
        lblNumberReceivers.Text = ""
        lblNumberReturns.Text = ""
        lblNumberVouchers.Text = ""
        lblReceiverTotal.Text = ""
        lblReturnTotal.Text = ""
        lblVoucherTotal.Text = ""
        lblDifference.Text = ""

        cboPurchaseOrderNumber.Focus()
    End Sub

    Public Sub ClearAllData()
        'Clear text boxes on load
        cmdLoadDefaultAddress.Enabled = True

        cboPurchaseOrderNumber.Text = ""
        cboPaymentTerms.Text = ""
        cboPartDescription.Text = ""
        cboPartNumber.Text = ""
        cboShipVia.Text = ""
        cboVendorCode.Text = ""
        cboDropShipState.Text = ""
        cboCustomerDSName.Text = ""
        cboPurchaseOrderNumber.Text = ""
        cboDropShipState.Text = ""
        cboItemClass.Text = ""
        cboLineDescription.Text = ""
        cboLineNumber.Text = ""
        cboShipToID.Text = ""

        cboPaymentTerms.Refresh()
        cboPartDescription.Refresh()
        cboPartNumber.Refresh()
        txtVendorName.Refresh()
        cboShipVia.Refresh()
        cboVendorCode.Refresh()
        cboDropShipState.Refresh()
        cboCustomerDSName.Refresh()
        cboPurchaseOrderNumber.Refresh()
        cboDropShipState.Refresh()
        cboItemClass.Refresh()
        cboLineDescription.Refresh()
        cboLineNumber.Refresh()
        cboLinePartNumber.Refresh()
        cboShipToID.Refresh()

        cboPaymentTerms.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboVendorCode.SelectedIndex = -1
        cboDropShipState.SelectedIndex = -1
        cboCustomerDSName.SelectedIndex = -1
        cboPurchaseOrderNumber.SelectedIndex = -1
        cboDropShipState.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboLineDescription.SelectedIndex = -1
        cboLineNumber.SelectedIndex = -1
        cboShipToID.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1

        If String.IsNullOrEmpty(cboLineNumber.Text) = False Then
            cboLineNumber.Text = ""
        End If

        cboLinePartNumber.SelectedIndex = -1
        cboShipToID.SelectedIndex = -1
        cboNewItemClass.SelectedIndex = -1

        cboDivisionID.Text = EmployeeCompanyCode

        txtLongDescription.Refresh()
        txtCustomerDSAddress1.Refresh()
        txtCustomerDSAddress2.Refresh()
        txtCustomerDSCity.Refresh()
        txtCustomerDSZip.Refresh()
        txtFreightCharges.Refresh()
        txtPOComment.Refresh()
        txtSalesTax.Refresh()
        txtDSSalesOrderNumber.Refresh()

        txtLongDescription.Clear()
        txtCustomerDSAddress1.Clear()
        txtCustomerDSAddress2.Clear()
        txtCustomerDSCity.Clear()
        txtCustomerDSZip.Clear()
        txtFreightCharges.Clear()
        txtPOComment.Clear()
        txtSalesTax.Clear()
        txtInventoryAccount.Clear()
        txtIssuesAccount.Clear()
        txtPurchaseAccount.Clear()
        txtReturnsAccount.Clear()
        txtSalesAccount.Clear()
        txtSalesOffsetAccount.Clear()
        txtCOGSAccount.Clear()
        txtAdjustmentAccount.Clear()
        txtPOStatus.Clear()
        txtLineComment.Clear()
        txtLineComment2.Clear()
        txtLineUnitCost.Clear()
        txtLineGLCredit.Clear()
        txtLineGLDebit.Clear()
        txtLineOrderQuantity.Clear()
        txtDSSalesOrderNumber.Clear()
        txtVendorName.Clear()
        txtShippingName.Clear()
        txtShippingWeight.Clear()
        txtNumberOfBoxes.Clear()
        txtDivisionVendor.Clear()

        dtpPurchaseOrderDate.Text = ""
        dtpShipDatePicker.Text = ""

        chkDropShip.Checked = False
        chkDropShip.Enabled = True

        lblAmount.Text = ""
        lblLastPurchaseCost.Text = ""
        lblOrderTotal.Text = ""
        lblEstWeight.Text = ""
        lblPurchaseTotal.Text = ""
        lblPalletCount.Text = ""
        lblBoxCount.Text = ""
        lblNumberReceivers.Text = ""
        lblNumberReturns.Text = ""
        lblNumberVouchers.Text = ""
        lblReceiverTotal.Text = ""
        lblReturnTotal.Text = ""
        lblVoucherTotal.Text = ""
        lblDifference.Text = ""
        lblOpenWeight.Text = ""
        lblOpen.Visible = False

        If cboDivisionID.Text = "TWD" Then
            cboShipVia.Text = "UPSGROUNDFREIGHTCOLLECT-ACCT#472125"
        End If

        cboPurchaseOrderNumber.Focus()
    End Sub

    Public Sub ClearShippingData()
        txtShippingName.Clear()
        txtCustomerDSAddress1.Clear()
        txtCustomerDSAddress2.Clear()
        txtCustomerCountry.Clear()
        txtCustomerDSCity.Clear()
        txtCustomerDSZip.Clear()
        cboDropShipState.SelectedIndex = -1
    End Sub

    Public Sub ClearVariables()
        cmdLoadDefaultAddress.Enabled = True
        GlobalCompleteShipment = ""

        'GlobalPONumber = 0
        VerifyItemID = ""
        ShipToAddress1 = ""
        ShipToAddress2 = ""
        ShipToCity = ""
        ShipToState = ""
        ShipToZip = ""
        ShipToCountry = ""
        LongDescription = ""
        POStatus = ""
        VendorName = ""
        VendorPaymentTerms = ""
        PODate = Today()
        VendorID = ""
        PaymentCode = ""
        POHeaderComment = ""
        ShipDate = Today()
        ShipMethodID = ""
        PODropShipCustomerID = ""
        FreightCharge = 0
        SalesTax = 0
        ProductTotal = 0
        POTotal = 0
        UnitCost = 0
        ExtendedAmount = 0
        LastPurchasePrice = 0
        LineQuantity = 0
        LineCost = 0
        LineAmount = 0
        LineTax = 0
        LineComment = ""
        TotalTax = 0
        Quantity = 0
        CountLineNumber = 0
        Counter = 0
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        LastLineNumber = 0
        NextLineNumber = 0
        ReissueLineNumber = 0
        LastPONumber = 0
        NextPONumber = 0
        LastGLNumber = 0
        NextGLNumber = 0
        TempItemClass = ""
        GLDebitAccount = ""
        GLCreditAccount = ""
        TempPartNumber = ""
        TempPartDescription = ""
        PartDescription = ""
        NonPartDescription = ""
        PartNumber = ""
        NonPartNumber = ""
        ItemClass = ""
        MAXDate = ""
        TempGLInventoryAccount = ""
        TempGLPurchasesAccount = ""
        GLSalesAccount = ""
        GLReturnsAccount = ""
        GLInventoryAccount = ""
        GLCOGSAccount = ""
        GLPurchasesAccount = ""
        GLSalesOffsetAccount = ""
        GLAdjustmentAccount = ""
        GLIssuesAccount = ""
        UpperLimit = 0
        LastInventoryTransactionNumber = 0
        NextInventoryTransactionNumber = 0
        DropShipSalesOrderNumber = 0
        POStatus = ""
        CheckReceiveStatus = 0
        CheckPOLines = 0
        CheckItemClass = ""
        VerifyVendor = ""
        DSSONumber = 0
        DSCustomerID = ""
        DSADDShipTo = ""
        CheckLineQuantity = 0
        CheckReceiverQuantity = 0
        CheckPartNumber1 = ""
        GetReceiverVendor = ""
        PieceWeight = 0
        TotalWeight = 0
        LineWeight = 0
        LineEditPartDescription = ""
        LineEditPartNumber = ""
        LineEditOrderQuantity = 0
        LineEditExtendedAmount = 0
        LineEditUnitCost = 0
        CheckReceiverVendor = 0
        needsSaved = False
        lastPO = ""
        lineInfoChanged = False
        DefaultCompanyName = ""
        DefaultAddress1 = ""
        DefaultAddress2 = ""
        DefaultCity = ""
        DefaultState = ""
        DefaultZip = ""
        DefaultCountry = ""
        EstTotalWeight = 0
        EstTotalBoxes = 0
        ValidateDivision = ""
        DivisionMatch = ""
        CurrentShippingWeight = 0
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvPurchaseOrderLines.DataSource = Nothing
        dgvReceiverTable.DataSource = Nothing
        dgvReturnTable.DataSource = Nothing
        dgvROITable.DataSource = Nothing
    End Sub

    Public Sub ClearGridTextBoxes()
        txtLineExtendedCost.Clear()
        txtLineGLCredit.Clear()
        txtLineGLDebit.Clear()
        txtLineOrderQuantity.Clear()
        txtLineUnitCost.Clear()
        txtLineComment2.Clear()

        lblLastPurchaseCost.Text = ""
        lblAmount.Text = ""

        cboLineDescription.SelectedIndex = -1
        cboLineNumber.SelectedIndex = -1
        cboLinePartNumber.SelectedIndex = -1
    End Sub

    Public Sub ClearGLAccounts()
        txtAdjustmentAccount.Clear()
        txtCOGSAccount.Clear()
        txtInventoryAccount.Clear()
        txtIssuesAccount.Clear()
        txtPurchaseAccount.Clear()
        txtReturnsAccount.Clear()
        txtSalesAccount.Clear()
        txtSalesOffsetAccount.Clear()
    End Sub

    Public Sub ClearLines()
        'Clear text boxes
        cboPartNumber.Text = ""
        cboPartDescription.Text = ""
        cboNewItemClass.Text = ""
        cboItemClass.Text = ""

        cboPartNumber.Refresh()
        cboPartDescription.Refresh()
        cboNewItemClass.Refresh()
        cboItemClass.Refresh()

        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboNewItemClass.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1

        txtLineComment.Refresh()
        txtOrderQuantity.Refresh()
        txtUnitCost.Refresh()
        txtLongDescription.Refresh()

        txtLineComment.Clear()
        txtOrderQuantity.Clear()
        txtUnitCost.Clear()
        txtLongDescription.Clear()

        lblLastPurchaseCost.Text = ""
        lblAmount.Text = ""
        lblPalletCount.Text = ""
        lblBoxCount.Text = ""
        lineInfoChanged = False
        cboPartNumber.Focus()
    End Sub

    Public Sub ClearEditLines()
        cboLineNumber.SelectedIndex = -1
        cboLinePartNumber.SelectedIndex = -1
        cboLineDescription.SelectedIndex = -1
        txtLineExtendedCost.Clear()
        txtLineGLCredit.Clear()
        txtLineGLDebit.Clear()
        txtLineComment2.Clear()
        txtLineOrderQuantity.Clear()
        txtLineUnitCost.Clear()
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
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

    Public Sub VerifyItemClass()
        Dim CheckItemClassStatement As String = "SELECT ItemClassID FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim CheckItemClassCommand As New SqlCommand(CheckItemClassStatement, con)
        CheckItemClassCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboNewItemClass.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckItemClass = CStr(CheckItemClassCommand.ExecuteScalar)
        Catch ex As System.Exception
            CheckItemClass = "INVALID"
        End Try
        con.Close()
    End Sub

    Public Sub CheckDivision()
        Dim CheckDivisionStatement As String = "SELECT DivisionID FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
        Dim CheckDivisionCommand As New SqlCommand(CheckDivisionStatement, con)
        CheckDivisionCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ValidateDivision = CStr(CheckDivisionCommand.ExecuteScalar)
        Catch ex As System.Exception
            ValidateDivision = ""
        End Try
        con.Close()

        If ValidateDivision = cboDivisionID.Text Then
            DivisionMatch = "YES"
        Else
            DivisionMatch = "NO"
        End If
    End Sub

    Private Function canAddItem() As Boolean
        If String.IsNullOrEmpty(cboPurchaseOrderNumber.Text) Then
            MessageBox.Show("You must enter a Purchase Order Number", "Enter a Purchase Order Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPurchaseOrderNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            ShowData()
            LoadPOData()
            CalculatePOWeight()
            LoadReceiverVendor()
            Return False
        End If
        If String.IsNullOrEmpty(cboVendorCode.Text) Then
            MessageBox.Show("You must enter a Vendor ID", "Enter a Vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorCode.Focus()
            Return False
        End If
        If cboVendorCode.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Vendor ID", "Enter a valid Vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorCode.SelectAll()
            cboVendorCode.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboPartNumber.Text) Then
            MessageBox.Show("You must enter a Part Number", "Enter a Part Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPartNumber.Focus()
            Return False
        End If
        If cboPartNumber.SelectedIndex = -1 Then
            If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "SLC" Or cboDivisionID.Text = "CBS" Then
                VerifyItemID = "DOES NOT EXIST"
                If String.IsNullOrEmpty(cboNewItemClass.Text) Then
                    MessageBox.Show("You must enter an Item Class", "Enter an Item Class", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboNewItemClass.Focus()
                    Return False
                End If
                If cboNewItemClass.SelectedIndex = -1 Then
                    MessageBox.Show("You must enter a valid Item Class", "Enter a valid Item Class", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboNewItemClass.SelectAll()
                    cboNewItemClass.Focus()
                    Return False
                End If
            Else
                MessageBox.Show("You must enter a valid Part Number", "Enter a valid Part Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboPartNumber.SelectAll()
                cboPartNumber.Focus()
                Return False
            End If
        Else
            VerifyItemID = "EXIST"
        End If
        If String.IsNullOrEmpty(txtOrderQuantity.Text) Then
            MessageBox.Show("You must enter an Order Quantity", "Enter an Order Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOrderQuantity.Focus()
            Return False
        End If
        If Not IsNumeric(txtOrderQuantity.Text) Then
            MessageBox.Show("You must enter a number for Order Quantity", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOrderQuantity.SelectAll()
            txtOrderQuantity.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtUnitCost.Text) Then
            MessageBox.Show("You must enter a Unit Cost", "Enter a Unit Cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitCost.Focus()
            Return False
        End If
        If Not IsNumeric(txtUnitCost.Text) Then
            MessageBox.Show("You must enter a number for Unit Cost", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitCost.SelectAll()
            txtUnitCost.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub LockBatch()
        cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Locked = @Locked WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Locked = '' WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND Locked = @Locked", con)
        If batch.Equals("none") Then
            cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        Else
            cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = batch
        End If
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Function canSaveLineChanges() As Boolean
        If String.IsNullOrEmpty(cboPurchaseOrderNumber.Text) Then
            MessageBox.Show("You must enter a Purchase Order number", "Enter a Purchase Order number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPurchaseOrderNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            ShowData()
            LoadPOData()
            CalculatePOWeight()
            LoadReceiverVendor()
            Return False
        End If
        If String.IsNullOrEmpty(cboVendorCode.Text) Then
            MessageBox.Show("You must select a Vendor code", "Select a Vendor code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorCode.Focus()
            Return False
        End If
        If cboVendorCode.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Vendor Code", "Enter a valid Vendor Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorCode.SelectAll()
            cboVendorCode.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboLineNumber.Text) Then
            MessageBox.Show("You must select a line number", "Select a line number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLineNumber.Focus()
            Return False
        End If
        If cboLineNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid line number", "Enter a valid line number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLineNumber.SelectAll()
            cboLineNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboLinePartNumber.Text) Then
            MessageBox.Show("You must select a part number", "Select a part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLinePartNumber.Focus()
            Return False
        End If
        If cboLinePartNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid part number", "Enter a valid part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLinePartNumber.SelectAll()
            cboLineNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboLineDescription.Text) Then
            MessageBox.Show("You must enter a part description", "Enter a part description", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLineDescription.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtLineUnitCost.Text) Then
            MessageBox.Show("You must enter a Unit Cost for this line", "Enter a Unit Cost", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLineUnitCost.SelectAll()
            txtLineUnitCost.Focus()
            Return False
        End If
        If IsNumeric(txtLineUnitCost.Text) = False Then
            MessageBox.Show("You must enter a number for Unit Cost", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitCost.SelectAll()
            txtUnitCost.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtLineOrderQuantity.Text) Then
            MessageBox.Show("You must enter an Order Quantity", "Enter an Order Quanttiy", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLineOrderQuantity.Focus()
            Return False
        End If
        If IsNumeric(txtLineOrderQuantity.Text) = False Then
            MessageBox.Show("You must enter a number for Order Quantity", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLineOrderQuantity.SelectAll()
            txtLineOrderQuantity.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function isSomeoneEditing() As Boolean
        cmd = New SqlCommand("SELECT Locked FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim personEditing As String = "NONE"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("Locked")) Then
                personEditing = reader.Item("Locked")
            End If
        End If
        reader.Close()
        con.Close()

        If Not personEditing.Equals("NONE") And Not String.IsNullOrEmpty(personEditing) Then
            If Not personEditing.Equals(EmployeeLoginName) Then
                MessageBox.Show(personEditing + " is currently editing this Purchase Order. You are unable to make any changes.", "Unable to make changes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        End If
        Return False
    End Function

    Private Function shouldSwitchStatus(ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean
        If e.KeyCode = Keys.Enter Then
            Return False
        End If
        If e.KeyCode = Keys.Tab Then
            Return False
        End If
        If cboPurchaseOrderNumber.Focused Then
            Return False
        End If
        Return True
    End Function

    'Command Buttons

    Private Sub cmdAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddItem.Click
        If canAddItem() Then
            LockBatch()
            '*************************************************************************************
            CheckDivision()
            If DivisionMatch = "NO" Then
                MsgBox("There is an issue with this PO. Contact System Admin.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*************************************************************************************
            If cboPurchaseOrderNumber.Text = "0" Or Val(cboPurchaseOrderNumber.Text) = 0 Or cboPurchaseOrderNumber.Text = "" Then
                MsgBox("You must have a valid PO #.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*************************************************************************************
            'Check for part number, quantity
            If cboPartNumber.Text = "" Or cboPartDescription.Text = "" Or txtOrderQuantity.Text = "" Or Val(txtOrderQuantity.Text) = 0 Then
                MsgBox("You must have a part number / description and valid order quantity.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*************************************************************************************
            'Verify Part Number
            Dim CheckPartNumber As Integer = 0

            Dim CheckPartNumberStatement As String = "SELECT COUNT(ItemID) FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim CheckPartNumberCommand As New SqlCommand(CheckPartNumberStatement, con)
            CheckPartNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            CheckPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckPartNumber = CInt(CheckPartNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                CheckPartNumber = 0
            End Try
            con.Close()
            '***********************************************************
            'Check if part has been de-activated
            Dim CheckIfDeactivated As String = ""

            Dim CheckIfDeactivatedStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim CheckIfDeactivatedCommand As New SqlCommand(CheckIfDeactivatedStatement, con)
            CheckIfDeactivatedCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            CheckIfDeactivatedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckIfDeactivated = CStr(CheckIfDeactivatedCommand.ExecuteScalar)
            Catch ex As System.Exception
                CheckIfDeactivated = ""
            End Try
            con.Close()

            If CheckIfDeactivated = "DEACTIVATED-PART" Then
                MsgBox("This part is de-activated and cannot be used.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Skip
            End If
            '*************************************************************************************
            If CheckPartNumber = 0 Then VerifyItemID = "DOES NOT EXIST"

            If VerifyItemID = "DOES NOT EXIST" And cboDivisionID.Text = "TWD" Then
                Try
                    'Add New Part Number to the division
                    CreateNewPartNumber()
                Catch ex As Exception
                    'If Insert fails, write error message to database
                    'Log error on update failure
                    Dim TempPONumber As Integer = 0
                    Dim strPONumber As String
                    TempPONumber = Val(cboPurchaseOrderNumber.Text)
                    strPONumber = CStr(TempPONumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Insert New Part --- PO Form"
                    ErrorReferenceNumber = "PO # " + strPONumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************
                cboItemClass.Text = cboNewItemClass.Text
                LoadGLAccounts()
                '***********************************************************
                LoadTotals()

                'Calculate PO Totals
                ProductTotal = ProductTotal + LineAmount
                lblPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
                POTotal = SalesTax + FreightCharge + ProductTotal
                lblOrderTotal.Text = FormatCurrency(POTotal, 2)

                'Round Variables
                FreightCharge = Math.Round(FreightCharge, 2)
                SalesTax = Math.Round(SalesTax, 2)
                ProductTotal = Math.Round(ProductTotal, 2)
                POTotal = Math.Round(POTotal, 2)
                '***********************************************************
                'Load PO Status
                If chkDropShip.Checked = True Then
                    POStatus = "DROPSHIP"
                Else
                    POStatus = "OPEN"
                End If

                ShipDate = dtpShipDatePicker.Value
                PODate = dtpPurchaseOrderDate.Value
                '***********************************************************
                'Call Save Procedure
                SaveUpdateProcedure()
                '***********************************************************
                'Reload Item Class for lines
                Dim PartItemClass As String = ""

                Dim PartItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim PartItemClassCommand As New SqlCommand(PartItemClassStatement, con)
                PartItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                PartItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PartItemClass = CStr(PartItemClassCommand.ExecuteScalar)
                Catch ex As System.Exception
                    PartItemClass = ""
                End Try
                con.Close()

                If PartItemClass = "" Then
                    cboItemClass.Text = cboNewItemClass.Text
                Else
                    cboItemClass.Text = PartItemClass
                    LoadGLAccounts()
                End If
                '***********************************************************
                'Verify GL Accounts
                If txtPurchaseAccount.Text = "" Then
                    txtPurchaseAccount.Text = "20999"
                End If
                If txtInventoryAccount.Text = "" Then
                    txtInventoryAccount.Text = "12100"
                End If
                '*************************************************************
                'Write Data to Purchase Order Line Database Table (Line Items)
                Try
                    cmd = New SqlCommand("Insert Into PurchaseOrderLineTable(PurchaseOrderHeaderKey, PurchaseOrderLineNumber, PartNumber, PartDescription, OrderQuantity, UnitCost, ExtendedAmount, LineStatus, DivisionID, DebitGLAccount, CreditGLAccount, SelectForInvoice, LineComment)Values(@PurchaseOrderHeaderKey, (SELECT isnull(MAX(PurchaseOrderLineNumber) + 1, 1) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey), @PartNumber, @PartDescription, @OrderQuantity, @UnitCost, @ExtendedAmount, @LineStatus, @DivisionID, @DebitGLAccount, @CreditGLAccount, @SelectForInvoice, @LineComment)", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text.ToUpper
                        .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text.ToUpper
                        .Add("@OrderQuantity", SqlDbType.VarChar).Value = Val(txtOrderQuantity.Text)
                        .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineAmount
                        .Add("@LineStatus", SqlDbType.VarChar).Value = POStatus
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = txtPurchaseAccount.Text
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = txtInventoryAccount.Text
                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text.ToUpper
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'If Insert fails, write error message to database
                    'Log error on update failure
                    Dim TempPONumber As Integer = 0
                    Dim strPONumber As String
                    TempPONumber = Val(cboPurchaseOrderNumber.Text)
                    strPONumber = CStr(TempPONumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Insert New PO Line --- PO Form"
                    ErrorReferenceNumber = "PO # " + strPONumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***************************************************************************************
                'Call procedure to populate grid on form
                ShowData()
                '***************************************************************************************
                'Show Totals (datagrid tab for line items)

                Me.dgvPurchaseOrderLines.Rows(dgvPurchaseOrderLines.Rows.Count - 1).Selected = True
                Me.dgvPurchaseOrderLines.CurrentCell = Me.dgvPurchaseOrderLines.Rows(Me.dgvPurchaseOrderLines.Rows.Count - 1).Cells(1)

                'Initialize values
                LineAmount = 0

                'Clear Line item text boxes
                ClearLines()
                ClearGLAccounts()
                LoadPartNumber()
                LoadEditPartNumber()
                LoadLineDetails()
                LoadPOStatus()
                CalculatePOWeight()

                'Show Totals
                PopulateSaveTotals()
            ElseIf VerifyItemID = "DOES NOT EXIST" And cboDivisionID.Text = "SLC" Then
                Try
                    'Add New Part Number to the division
                    CreateNewPartNumber()
                Catch ex As Exception
                    'If Insert fails, write error message to database
                    'Log error on update failure
                    Dim TempPONumber As Integer = 0
                    Dim strPONumber As String
                    TempPONumber = Val(cboPurchaseOrderNumber.Text)
                    strPONumber = CStr(TempPONumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Insert New Part --- PO Form"
                    ErrorReferenceNumber = "PO # " + strPONumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************
                cboItemClass.Text = cboNewItemClass.Text
                LoadGLAccounts()
                '***********************************************************
                LoadTotals()

                'Calculate PO Totals
                ProductTotal = ProductTotal + LineAmount
                lblPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
                POTotal = SalesTax + FreightCharge + ProductTotal
                lblOrderTotal.Text = FormatCurrency(POTotal, 2)

                'Round Variables
                FreightCharge = Math.Round(FreightCharge, 2)
                SalesTax = Math.Round(SalesTax, 2)
                ProductTotal = Math.Round(ProductTotal, 2)
                POTotal = Math.Round(POTotal, 2)

                'Load PO Status
                If chkDropShip.Checked = True Then
                    POStatus = "DROPSHIP"
                Else
                    POStatus = "OPEN"
                End If

                ShipDate = dtpShipDatePicker.Value
                PODate = dtpPurchaseOrderDate.Value

                'Call Save Procedure
                SaveUpdateProcedure()
                '***********************************************************
                'Reload Item Class for lines
                Dim PartItemClass As String = ""

                Dim PartItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim PartItemClassCommand As New SqlCommand(PartItemClassStatement, con)
                PartItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                PartItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PartItemClass = CStr(PartItemClassCommand.ExecuteScalar)
                Catch ex As System.Exception
                    PartItemClass = ""
                End Try
                con.Close()

                If PartItemClass = "" Then
                    cboItemClass.Text = cboNewItemClass.Text
                Else
                    cboItemClass.Text = PartItemClass
                    LoadGLAccounts()
                End If
                '***********************************************************
                'Verify GL Accounts
                If txtPurchaseAccount.Text = "" Then
                    txtPurchaseAccount.Text = "20999"
                End If
                If txtInventoryAccount.Text = "" Then
                    txtInventoryAccount.Text = "12175"
                End If
                '*************************************************************
                'Write Data to Purchase Order Line Database Table (Line Items)
                Try
                    cmd = New SqlCommand("Insert Into PurchaseOrderLineTable(PurchaseOrderHeaderKey, PurchaseOrderLineNumber, PartNumber, PartDescription, OrderQuantity, UnitCost, ExtendedAmount, LineStatus, DivisionID, DebitGLAccount, CreditGLAccount, SelectForInvoice, LineComment)Values(@PurchaseOrderHeaderKey, (SELECT isnull(MAX(PurchaseOrderLineNumber) + 1, 1) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey), @PartNumber, @PartDescription, @OrderQuantity, @UnitCost, @ExtendedAmount, @LineStatus, @DivisionID, @DebitGLAccount, @CreditGLAccount, @SelectForInvoice, @LineComment)", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                        .Add("@OrderQuantity", SqlDbType.VarChar).Value = Val(txtOrderQuantity.Text)
                        .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineAmount
                        .Add("@LineStatus", SqlDbType.VarChar).Value = POStatus
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = txtPurchaseAccount.Text
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = txtInventoryAccount.Text
                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'If Insert fails, write error message to database
                    'Log error on update failure
                    Dim TempPONumber As Integer = 0
                    Dim strPONumber As String
                    TempPONumber = Val(cboPurchaseOrderNumber.Text)
                    strPONumber = CStr(TempPONumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Insert New PO Line --- PO Form"
                    ErrorReferenceNumber = "PO # " + strPONumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***************************************************************************************
                'Call procedure to populate grid on form
                ShowData()
                '***************************************************************************************
                'Show Totals (datagrid tab for line items)

                Me.dgvPurchaseOrderLines.Rows(dgvPurchaseOrderLines.Rows.Count - 1).Selected = True
                Me.dgvPurchaseOrderLines.CurrentCell = Me.dgvPurchaseOrderLines.Rows(Me.dgvPurchaseOrderLines.Rows.Count - 1).Cells(1)

                'Initialize values
                LineAmount = 0

                'Clear Line item text boxes
                ClearLines()
                ClearGLAccounts()
                LoadPartNumber()
                LoadEditPartNumber()
                LoadLineDetails()
                LoadPOStatus()
                CalculatePOWeight()

                'Show Totals
                PopulateSaveTotals()
            ElseIf VerifyItemID = "DOES NOT EXIST" And cboDivisionID.Text = "CBS" Then
                Try
                    'Add New Part Number to the division
                    CreateNewPartNumber()
                Catch ex As Exception
                    'If Insert fails, write error message to database
                    'Log error on update failure
                    Dim TempPONumber As Integer = 0
                    Dim strPONumber As String
                    TempPONumber = Val(cboPurchaseOrderNumber.Text)
                    strPONumber = CStr(TempPONumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Insert New Part --- PO Form"
                    ErrorReferenceNumber = "PO # " + strPONumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************
                cboItemClass.Text = cboNewItemClass.Text
                LoadGLAccounts()
                '***********************************************************
                LoadTotals()

                'Calculate PO Totals
                ProductTotal = ProductTotal + LineAmount
                lblPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
                POTotal = SalesTax + FreightCharge + ProductTotal
                lblOrderTotal.Text = FormatCurrency(POTotal, 2)

                'Round Variables
                FreightCharge = Math.Round(FreightCharge, 2)
                SalesTax = Math.Round(SalesTax, 2)
                ProductTotal = Math.Round(ProductTotal, 2)
                POTotal = Math.Round(POTotal, 2)

                'Load PO Status
                If chkDropShip.Checked = True Then
                    POStatus = "DROPSHIP"
                Else
                    POStatus = "OPEN"
                End If

                ShipDate = dtpShipDatePicker.Value
                PODate = dtpPurchaseOrderDate.Value

                'Call Save Procedure
                SaveUpdateProcedure()
                '***********************************************************
                'Reload Item Class for lines
                Dim PartItemClass As String = ""

                Dim PartItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim PartItemClassCommand As New SqlCommand(PartItemClassStatement, con)
                PartItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                PartItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PartItemClass = CStr(PartItemClassCommand.ExecuteScalar)
                Catch ex As System.Exception
                    PartItemClass = ""
                End Try
                con.Close()

                If PartItemClass = "" Then
                    cboItemClass.Text = cboNewItemClass.Text
                Else
                    cboItemClass.Text = PartItemClass
                    LoadGLAccounts()
                End If
                '***********************************************************
                'Verify GL Accounts
                If txtPurchaseAccount.Text = "" Then
                    txtPurchaseAccount.Text = "20999"
                End If
                If txtInventoryAccount.Text = "" Then
                    txtInventoryAccount.Text = "12175"
                End If
                '*************************************************************
                'Write Data to Purchase Order Line Database Table (Line Items)
                Try
                    cmd = New SqlCommand("Insert Into PurchaseOrderLineTable(PurchaseOrderHeaderKey, PurchaseOrderLineNumber, PartNumber, PartDescription, OrderQuantity, UnitCost, ExtendedAmount, LineStatus, DivisionID, DebitGLAccount, CreditGLAccount, SelectForInvoice, LineComment)Values(@PurchaseOrderHeaderKey, (SELECT isnull(MAX(PurchaseOrderLineNumber) + 1, 1) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey), @PartNumber, @PartDescription, @OrderQuantity, @UnitCost, @ExtendedAmount, @LineStatus, @DivisionID, @DebitGLAccount, @CreditGLAccount, @SelectForInvoice, @LineComment)", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                        .Add("@OrderQuantity", SqlDbType.VarChar).Value = Val(txtOrderQuantity.Text)
                        .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineAmount
                        .Add("@LineStatus", SqlDbType.VarChar).Value = POStatus
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = txtPurchaseAccount.Text
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = txtInventoryAccount.Text
                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'If Insert fails, write error message to database
                    'Log error on update failure
                    Dim TempPONumber As Integer = 0
                    Dim strPONumber As String
                    TempPONumber = Val(cboPurchaseOrderNumber.Text)
                    strPONumber = CStr(TempPONumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Insert New PO Line --- PO Form"
                    ErrorReferenceNumber = "PO # " + strPONumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***************************************************************************************
                'Call procedure to populate grid on form
                ShowData()
                '***************************************************************************************
                'Show Totals (datagrid tab for line items)

                Me.dgvPurchaseOrderLines.Rows(dgvPurchaseOrderLines.Rows.Count - 1).Selected = True
                Me.dgvPurchaseOrderLines.CurrentCell = Me.dgvPurchaseOrderLines.Rows(Me.dgvPurchaseOrderLines.Rows.Count - 1).Cells(1)

                'Initialize values
                LineAmount = 0

                'Clear Line item text boxes
                ClearLines()
                ClearGLAccounts()
                LoadPartNumber()
                LoadEditPartNumber()
                LoadLineDetails()
                LoadPOStatus()
                CalculatePOWeight()

                'Show Totals
                PopulateSaveTotals()
            Else
                LoadTotals()

                'Calculate PO Totals
                ProductTotal = ProductTotal + LineAmount
                lblPurchaseTotal.Text = FormatCurrency(ProductTotal, 2)
                POTotal = SalesTax + FreightCharge + ProductTotal
                lblOrderTotal.Text = FormatCurrency(POTotal, 2)

                'Round Variables
                FreightCharge = Math.Round(FreightCharge, 2)
                SalesTax = Math.Round(SalesTax, 2)
                ProductTotal = Math.Round(ProductTotal, 2)
                POTotal = Math.Round(POTotal, 2)

                'Load PO Status
                If chkDropShip.Checked = True Then
                    POStatus = "DROPSHIP"
                Else
                    POStatus = "OPEN"
                End If

                ShipDate = dtpShipDatePicker.Value
                PODate = dtpPurchaseOrderDate.Value

                'Call Save Procedure
                SaveUpdateProcedure()
                '***********************************************************
                'Reload Item Class for lines
                Dim PartItemClass As String = ""

                Dim PartItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim PartItemClassCommand As New SqlCommand(PartItemClassStatement, con)
                PartItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
                PartItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PartItemClass = CStr(PartItemClassCommand.ExecuteScalar)
                Catch ex As System.Exception
                    PartItemClass = ""
                End Try
                con.Close()

                If PartItemClass = "" Then
                    cboItemClass.Text = cboNewItemClass.Text
                Else
                    cboItemClass.Text = PartItemClass
                    LoadGLAccounts()
                End If

                'Verify GL Accounts
                If txtPurchaseAccount.Text = "" Then
                    txtPurchaseAccount.Text = "20999"
                End If
                If txtInventoryAccount.Text = "" Then
                    txtInventoryAccount.Text = "12100"
                End If
                '*************************************************************
                Try
                    'Write Data to Sales Order Line Database Table (Line Items)
                    cmd = New SqlCommand("Insert Into PurchaseOrderLineTable(PurchaseOrderHeaderKey, PurchaseOrderLineNumber, PartNumber, PartDescription, OrderQuantity, UnitCost, ExtendedAmount, LineStatus, DivisionID, DebitGLAccount, CreditGLAccount, SelectForInvoice, LineComment)Values(@PurchaseOrderHeaderKey, (SELECT isnull(MAX(PurchaseOrderLineNumber)+ 1, 1) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey), @PartNumber, @PartDescription, @OrderQuantity, @UnitCost, @ExtendedAmount, @LineStatus, @DivisionID, @DebitGLAccount, @CreditGLAccount, @SelectForInvoice, @LineComment)", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                        .Add("@OrderQuantity", SqlDbType.VarChar).Value = Val(txtOrderQuantity.Text)
                        .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineAmount
                        .Add("@LineStatus", SqlDbType.VarChar).Value = POStatus
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = txtPurchaseAccount.Text
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = txtInventoryAccount.Text
                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'If Insert fails, write error message to database
                    'Log error on update failure
                    Dim TempPONumber As Integer = 0
                    Dim strPONumber As String
                    TempPONumber = Val(cboPurchaseOrderNumber.Text)
                    strPONumber = CStr(TempPONumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Insert New PO Line --- PO Form"
                    ErrorReferenceNumber = "PO # " + strPONumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***************************************************************************************
                'Call procedure to populate grid on form
                ShowData()
                '***************************************************************************************
                'Show Totals (datagrid tab for line items)

                Me.dgvPurchaseOrderLines.Rows(dgvPurchaseOrderLines.Rows.Count - 1).Selected = True
                'Me.dgvSalesOrderLines.CurrentCell = Me.dgvSalesOrderLines.Rows.Cells(0)
                Me.dgvPurchaseOrderLines.CurrentCell = Me.dgvPurchaseOrderLines.Rows(Me.dgvPurchaseOrderLines.Rows.Count - 1).Cells(1)

                'Initialize values
                LineAmount = 0

                'Clear Line item text boxes
                ClearLines()
                ClearGLAccounts()
                LoadPartNumber()
                LoadEditPartNumber()
                LoadLineDetails()
                LoadPOStatus()
                CalculatePOWeight()

                'Show Totals
                PopulateSaveTotals()
            End If
        End If
    End Sub

    Private Sub cmdReissuePO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReissuePO.Click
        'Validate Vendor
        Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
        VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
        VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
        Catch ex As System.Exception
            VerifyVendor = ""
        End Try
        con.Close()

        If cboVendorCode.Text = "" Or VerifyVendor = "" Then
            MsgBox("You must select a valid Vendor first.", MsgBoxStyle.OkOnly)
            cboVendorCode.Focus()
            Exit Sub
        End If
        '*************************************************************************************************
        If cboShipVia.Text = "" Then
            MsgBox("You must select a ship via", MsgBoxStyle.OkOnly)
            cboShipVia.Focus()
            Exit Sub
        End If
        '*************************************************************************************************
        'Get Next Purchase Order Number
        PODate = Today()
        dtpPurchaseOrderDate.Text = PODate

        SaveInsertProcedure()

        'Add lines
        Dim ReissuePOLine As Integer = 1
        Dim ReissueUnitCost, ReissueExtendedAmount As Double
        Dim ReissueOrderQuantity As Integer
        Dim ReissuePartNumber, ReissuePartDescription, ReissueLineComment, ReissueDebitAccount, ReissueCreditAccount As String

        'Get Line Data
        For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
            Try
                ReissueUnitCost = row.Cells("UnitCostColumn").Value
            Catch ex As System.Exception
                ReissueUnitCost = 0
            End Try
            Try
                ReissueOrderQuantity = row.Cells("OrderQuantityColumn").Value
            Catch ex As System.Exception
                ReissueOrderQuantity = 0
            End Try
            Try
                ReissueLineComment = row.Cells("LineCommentColumn").Value
            Catch ex As System.Exception
                ReissueLineComment = ""
            End Try
            Try
                ReissuePartNumber = row.Cells("PartNumberColumn").Value
            Catch ex As System.Exception
                ReissuePartNumber = ""
            End Try
            Try
                ReissuePartDescription = row.Cells("PartDescriptionColumn").Value
            Catch ex As System.Exception
                ReissuePartDescription = ""
            End Try
            Try
                ReissueDebitAccount = row.Cells("DebitGLAccountColumn").Value
            Catch ex As System.Exception
                ReissueDebitAccount = "20999"
            End Try
            Try
                ReissueCreditAccount = row.Cells("CreditGLAccountColumn").Value
            Catch ex As System.Exception
                ReissueCreditAccount = "12100"
            End Try

            ReissueExtendedAmount = ReissueOrderQuantity * ReissueUnitCost
            ReissueExtendedAmount = Math.Round(ReissueExtendedAmount, 2)

            Try
                'Save Data to Prewritten Purchase Order Line Database Table
                cmd = New SqlCommand("INSERT INTO PurchaseOrderLineTable (PurchaseOrderHeaderKey, PurchaseOrderLineNumber, PartNumber, PartDescription, OrderQuantity, UnitCost, ExtendedAmount, LineStatus, DivisionID, DebitGLAccount, CreditGLAccount, SelectForInvoice, LineComment)values(@PurchaseOrderHeaderKey, @PurchaseOrderLineNumber, @PartNumber, @PartDescription, @OrderQuantity, @UnitCost, @ExtendedAmount, @LineStatus, @DivisionID, @DebitGLAccount, @CreditGLAccount, @SelectForInvoice, @LineComment)", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                    .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = ReissuePOLine
                    .Add("@PartNumber", SqlDbType.VarChar).Value = ReissuePartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = ReissuePartDescription
                    .Add("@OrderQuantity", SqlDbType.VarChar).Value = ReissueOrderQuantity
                    .Add("@UnitCost", SqlDbType.VarChar).Value = ReissueUnitCost
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ReissueExtendedAmount
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = ReissueDebitAccount
                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = ReissueCreditAccount
                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@LineComment", SqlDbType.VarChar).Value = ReissueLineComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Check
            End Try

            ReissuePOLine = ReissuePOLine + 1
        Next
        '***********************************************************************************
        'Refresh form with new PO Data
        LoadPONumber()
        cboPurchaseOrderNumber.Text = NextTransactionNumber
        txtPOStatus.Text = "OPEN"

        ShowData()

        'Load PO Totals
        CalculatePOWeight()
        LoadTotals()

        'Update PO Totals
        POStatus = "OPEN"

        SaveUpdateProcedure()

        MsgBox("New PO has been created", MsgBoxStyle.OkOnly)
        unlockBatch()

        isLoaded = True

        cboPurchaseOrderNumber.Focus()
        needsSaved = False
    End Sub

    Private Sub cmdSaveLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLine.Click
        Dim LineStatus As String

        If canSaveLineChanges() Then
            LockBatch()
            'Load PO Status
            If chkDropShip.Checked = True And POStatus <> "CLOSED" Then
                POStatus = "DROPSHIP"
            Else
                POStatus = "OPEN"
            End If

            'Check line to see if has been received
            'Run check to see if quantity changed is less than quantity received
            Dim CheckReceiverQuantityStatement As String = "SELECT QuantityReceived FROM ReceivingLineQuery1 WHERE PONumber = @PONumber AND POLineNumber = @POLineNumber AND DivisionID = @DivisionID"
            Dim CheckReceiverQuantityCommand As New SqlCommand(CheckReceiverQuantityStatement, con)
            CheckReceiverQuantityCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
            CheckReceiverQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            CheckReceiverQuantityCommand.Parameters.Add("@POLineNumber", SqlDbType.VarChar).Value = Val(cboLineNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckReceiverQuantity = CInt(CheckReceiverQuantityCommand.ExecuteScalar)
            Catch ex As System.Exception
                CheckReceiverQuantity = 0
            End Try
            con.Close()

            If Val(txtLineOrderQuantity.Text) < CheckReceiverQuantity Then
                MsgBox("You cannot change Order Quantity to less than has already been received.", MsgBoxStyle.OkOnly)
            ElseIf Val(txtLineOrderQuantity.Text) = CheckReceiverQuantity Then
                LineStatus = "CLOSED"

                'Save PO Line
                cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET PartNumber = @PartNumber, PartDescription = @PartDescription, OrderQuantity = @OrderQuantity, UnitCost = @UnitCost, ExtendedAmount = @ExtendedAmount, LineStatus = @LineStatus, DivisionID = @DivisionID, DebitGLAccount = @DebitGLAccount, CreditGLAccount = @CreditGLAccount, SelectForInvoice = @SelectForInvoice, LineComment = @LineComment  WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = Val(cboLineNumber.Text)
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboLinePartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboLineDescription.Text
                    .Add("@OrderQuantity", SqlDbType.VarChar).Value = Val(txtLineOrderQuantity.Text)
                    .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtLineUnitCost.Text)
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                    .Add("@LineStatus", SqlDbType.VarChar).Value = LineStatus
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = txtLineGLDebit.Text
                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = txtLineGLCredit.Text
                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment2.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Update Totals
                LoadTotals()

                'Update Header Table with Field Totals
                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET FreightCharge = @FreightCharge, SalesTax = @SalesTax, ProductTotal = @ProductTotal, POTotal = @POTotal WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    .Add("@FreightCharge", SqlDbType.VarChar).Value = FreightCharge
                    .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@POTotal", SqlDbType.VarChar).Value = POTotal
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("PO Line has been saved", MsgBoxStyle.OkOnly)
                ShowData()
            Else
                LineStatus = "OPEN"

                'Save PO Line
                cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET PartNumber = @PartNumber, PartDescription = @PartDescription, OrderQuantity = @OrderQuantity, UnitCost = @UnitCost, ExtendedAmount = @ExtendedAmount, LineStatus = @LineStatus, DivisionID = @DivisionID, DebitGLAccount = @DebitGLAccount, CreditGLAccount = @CreditGLAccount, SelectForInvoice = @SelectForInvoice, LineComment = @LineComment  WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = Val(cboLineNumber.Text)
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboLinePartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboLineDescription.Text
                    .Add("@OrderQuantity", SqlDbType.VarChar).Value = Val(txtLineOrderQuantity.Text)
                    .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtLineUnitCost.Text)
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                    .Add("@LineStatus", SqlDbType.VarChar).Value = POStatus
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = txtLineGLDebit.Text
                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = txtLineGLCredit.Text
                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment2.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Update Totals
                LoadTotals()

                'Update Header Table with Field Totals
                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET FreightCharge = @FreightCharge, SalesTax = @SalesTax, ProductTotal = @ProductTotal, POTotal = @POTotal WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    .Add("@FreightCharge", SqlDbType.VarChar).Value = FreightCharge
                    .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@POTotal", SqlDbType.VarChar).Value = POTotal
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("PO Line has been saved", MsgBoxStyle.OkOnly)
                ShowData()
                CalculatePOWeight()
            End If
        End If
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If cboLineNumber.Text = "" Or cboPurchaseOrderNumber.Text = "" Then
            'Verify that the data exists
            MsgBox("You must have a valid PO Number and Line Number selected.", MsgBoxStyle.OkOnly)
        Else
            If isSomeoneEditing() Then
                ShowData()
                LoadPOData()
                CalculatePOWeight()
                LoadReceiverVendor()
                Exit Sub
            End If
            '*************************************************************************************
            CheckDivision()
            If DivisionMatch = "NO" Then
                MsgBox("There is an issue with this PO. Contact System Admin.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*************************************************************************************
            LockBatch()
            '*************************************************************************************
            'Prompt before deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to Delete this Purchase Order Line?", "DELETE LINE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Check so see if product has been received for this line
                Dim CheckReceiveStatusString As String = "SELECT POQuantityReceived FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber AND DivisionID = @DivisionID"
                Dim CheckReceiveStatusCommand As New SqlCommand(CheckReceiveStatusString, con)
                CheckReceiveStatusCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                CheckReceiveStatusCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = Val(cboLineNumber.Text)
                CheckReceiveStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckReceiveStatus = CInt(CheckReceiveStatusCommand.ExecuteScalar)
                Catch ex As System.Exception
                    CheckReceiveStatus = 0
                End Try
                con.Close()

                If CheckReceiveStatus > 0 Then
                    MsgBox("You cannot delete this line - it has a quantity received against it.", MsgBoxStyle.OkOnly)
                Else
                    'Delete Purchase Order Line
                    cmd = New SqlCommand("DELETE FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = Val(cboLineNumber.Text)
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    MsgBox("This Line has been deleted.", MsgBoxStyle.OkOnly)

                    'Update Purchase Order Totals
                    PopulateSaveTotals()

                    'Update PO Header
                    cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET ProductTotal = @ProductTotal, FreightCharge = @FreightCharge, SalesTax = @SalesTax, POTotal = @POTotal WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtFreightCharges.Text)
                        .Add("@SalesTax", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        .Add("@POTotal", SqlDbType.VarChar).Value = POTotal
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    ShowData()

                    Dim CheckLineNumber, CheckLineQuantity, CheckPOQuantityReceived As Integer

                    'UPDATE Line Table on changes in the datagrid and ensure no NULL values
                    For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
                        Try
                            CheckLineNumber = row.Cells("PurchaseOrderLineNumberColumn").Value
                        Catch ex As System.Exception
                            CheckLineNumber = 1
                        End Try
                        Try
                            CheckLineQuantity = row.Cells("OrderQuantityColumn").Value
                        Catch ex As System.Exception
                            CheckLineQuantity = 1
                        End Try

                        Dim CheckPOQuantityReceivedString As String = "SELECT POQuantityReceived FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber AND DivisionID = @DivisionID"
                        Dim CheckPOQuantityReceivedCommand As New SqlCommand(CheckPOQuantityReceivedString, con)
                        CheckPOQuantityReceivedCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        CheckPOQuantityReceivedCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = CheckLineNumber
                        CheckPOQuantityReceivedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CheckPOQuantityReceived = CInt(CheckPOQuantityReceivedCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            CheckPOQuantityReceived = 0
                        End Try
                        con.Close()

                        If CheckLineQuantity = CheckPOQuantityReceived Then
                            'Line is closed
                            cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus  WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = CheckLineNumber
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            'Line is open
                            cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus  WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = CheckLineNumber
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Next

                    'Load updated datagrid
                    ShowData()

                    'Check to see if there any open lines - PO would be open
                    Dim CheckLineStatus As String

                    For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
                        Try
                            CheckLineStatus = row.Cells("LineStatusColumn").Value
                        Catch ex As System.Exception
                            CheckLineStatus = ""
                        End Try

                        If CheckLineStatus = "OPEN" Then
                            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            Exit For 'If one line is open, PO is open
                        ElseIf CheckLineStatus = "DROPSHIP" Then
                            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@Status", SqlDbType.VarChar).Value = "DROPSHIP"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            Exit For 'If one line is open, PO is a DROPSHIP
                        Else
                            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Next

                    'Clear Lines
                    cboLineNumber.SelectedIndex = -1
                    cboLinePartNumber.SelectedIndex = -1
                    cboLineDescription.SelectedIndex = -1
                    txtLineComment2.Clear()
                    txtLineUnitCost.Clear()
                    txtLineOrderQuantity.Clear()
                    txtLineExtendedCost.Clear()
                    txtLineGLCredit.Clear()
                    txtLineGLDebit.Clear()

                    'Load PO Status
                    LoadPOStatus()
                    CalculatePOWeight()
                    lineInfoChanged = False
                End If
            ElseIf button = DialogResult.No Then
                cmdDeleteLine.Focus()
            End If
        End If
    End Sub

    Private Sub cmdPrintPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPO.Click
        If cboPurchaseOrderNumber.Text = "" Or cboVendorCode.Text = "" Then
            MsgBox("You must select a valid Purchase Order Number and Vendor ID before printing", MsgBoxStyle.OkOnly)
        Else
            If POStatus = "CLOSED" Then 'Print without saving
                GlobalPONumber = Val(cboPurchaseOrderNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text

                'Choose the correct Print Form (REMOTE or LOCAL)

                'Get Login Type
                Dim GetLoginType As String = ""

                Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetLoginType = ""
                End Try
                con.Close()

                If GetLoginType = "REMOTE" Then
                    Using NewPrintPurchaseOrderRemote As New PrintPurchaseOrderRemote
                        Dim result = NewPrintPurchaseOrderRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintPurchaseOrder As New PrintPurchaseOrder
                        Dim result = NewPrintPurchaseOrder.ShowDialog()
                    End Using
                End If
            Else
                If Not isSomeoneEditing() Then
                    '*************************************************************************************************
                    If cboShipVia.Text = "" Then
                        MsgBox("You must select a ship via", MsgBoxStyle.OkOnly)
                        cboShipVia.Focus()
                        Exit Sub
                    End If
                    '*************************************************************************************************
                    'Validate Vendoor
                    Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                    Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
                    VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
                    VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        VerifyVendor = ""
                    End Try
                    con.Close()

                    If VerifyVendor = "" Then
                        MsgBox("You must have a valid Vendor selected.", MsgBoxStyle.OkOnly)
                    Else
                        'Recalculate totals in grid in case of changes
                        'Create command to save data from text boxes
                        cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET ExtendedAmount = OrderQuantity * UnitCost WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
                        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Determine PO Status
                        If chkDropShip.Checked = True Then
                            POStatus = "DROPSHIP"

                            'Update PO Lines to Drop Ship
                            cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        ElseIf chkDropShip.Checked = False Then
                            POStatus = "OPEN"
                        End If

                        ShipDate = dtpShipDatePicker.Value
                        PODate = dtpPurchaseOrderDate.Value

                        'Load PO Totals
                        LoadTotals()

                        'See if PO has a receiver - disable ability to change Vendor
                        Dim GetReceiverVendorStatement As String = "SELECT VendorCode FROM ReceivingHeaderTable WHERE PONumber = @PONumber AND DivisionID = @DivisionID"
                        Dim GetReceiverVendorCommand As New SqlCommand(GetReceiverVendorStatement, con)
                        GetReceiverVendorCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        GetReceiverVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetReceiverVendor = CStr(GetReceiverVendorCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            GetReceiverVendor = ""
                        End Try
                        con.Close()

                        If GetReceiverVendor = "" Then
                            SaveUpdateProcedure()
                        Else
                            SaveUpdateWOVendorProcedure()
                        End If
                    End If

                    'Clear Line item text boxes
                    ClearLines()
                    cboPartNumber.Focus()
                    ShowData()
                    CalculatePOWeight()

                    GlobalPONumber = Val(cboPurchaseOrderNumber.Text)
                    GlobalDivisionCode = cboDivisionID.Text

                    'Choose the correct Print Form (REMOTE or LOCAL)

                    'Get Login Type
                    Dim GetLoginType As String = ""

                    Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                    Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                    GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        GetLoginType = ""
                    End Try
                    con.Close()

                    If GetLoginType = "REMOTE" Then
                        Using NewPrintPurchaseOrderRemote As New PrintPurchaseOrderRemote
                            Dim result = NewPrintPurchaseOrderRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintPurchaseOrder As New PrintPurchaseOrder
                            Dim result = NewPrintPurchaseOrder.ShowDialog()
                        End Using
                    End If

                    needsSaved = False
                End If
            End If
        End If
    End Sub

    Private Sub cmdDeletePO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeletePO.Click
        If cboPurchaseOrderNumber.Text = "" Or Val(cboPurchaseOrderNumber.Text) = 0 Then
            MsgBox("You must have a valid Purchase Order selected.", MsgBoxStyle.OkOnly)
        Else
            If isSomeoneEditing() Then
                ShowData()
                LoadPOData()
                CalculatePOWeight()
                LoadReceiverVendor()
                Exit Sub
            End If
            '*******************************************************************************************************
            'Prompt before deleting
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Purchase Order?", "DELETE PURCHASE ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                '*************************************************************************************
                CheckDivision()
                If DivisionMatch = "NO" Then
                    MsgBox("There is an issue with this PO. Contact System Admin.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*************************************************************************************
                Dim CheckForAnyReceivers As Integer

                'Check to see if there is a ny receivers for this PO
                Dim CheckForReceiversString As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingHeaderTable WHERE PONumber = @PONumber AND DivisionID = @DivisionID"
                Dim CheckForReceiversCommand As New SqlCommand(CheckForReceiversString, con)
                CheckForReceiversCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                CheckForReceiversCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckForAnyReceivers = CInt(CheckForReceiversCommand.ExecuteScalar)
                Catch ex As System.Exception
                    CheckForAnyReceivers = 0
                End Try
                con.Close()

                If CheckForAnyReceivers = 0 Then
                    'Create command to save data from text boxes
                    cmd = New SqlCommand("DELETE FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Clear text boxes on delete
                    LoadVendorID()
                    isLoaded = False
                    LoadPONumber()
                    isLoaded = True
                    LoadPartNumber()
                    LoadEditPartNumber()
                    LoadCustomerList()
                    ClearVariables()
                    ClearAllData()
                    ShowData()

                    cboPurchaseOrderNumber.Focus()

                    'Prompt after deletion
                    MsgBox("This Purchase Order has been deleted.", MsgBoxStyle.OkOnly)
                Else
                    MsgBox("You cannot delete this PO - it has Receivers.", MsgBoxStyle.OkOnly)
                End If
            ElseIf button = DialogResult.No Then
                cmdClear.Focus()
            End If
        End If
    End Sub

    Private Sub cmdLinkPOAndSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLinkPOAndSO.Click
        If isSomeoneEditing() Then
            ShowData()
            LoadPOData()
            CalculatePOWeight()
            LoadReceiverVendor()
            Exit Sub
        End If

        LockBatch()

        Dim CountSOLines As Integer = 0
        Dim GetCustomer, GetShipToID, CheckSOStatus, GetSOPartNumber, GetPOPartNumber As String
        Dim SOLineNumber, GetSOQuantity, GetPOQuantity As Integer

        'Check if Sales Order is a drop ship
        Dim CheckSOStatusStatement As String = "SELECT SOStatus FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim CheckSOStatusCommand As New SqlCommand(CheckSOStatusStatement, con)
        CheckSOStatusCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtDSSalesOrderNumber.Text)
        CheckSOStatusCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckSOStatus = CStr(CheckSOStatusCommand.ExecuteScalar)
        Catch ex As System.Exception
            CheckSOStatus = ""
        End Try
        con.Close()

        If CheckSOStatus = "DROPSHIP" Then

            'Check SO Lines to see if they match PO
            Dim CountSOLinesStatement As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
            Dim CountSOLinesCommand As New SqlCommand(CountSOLinesStatement, con)
            CountSOLinesCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtDSSalesOrderNumber.Text)
            CountSOLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountSOLines = CInt(CountSOLinesCommand.ExecuteScalar)
            Catch ex As System.Exception
                CountSOLines = 0
            End Try
            con.Close()

            SOLineNumber = 1

            For i As Integer = 1 To CountSOLines
                Dim GetSOPartNumberStatement As String = "SELECT ItemID FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey AND DivisionID = @DivisionID"
                Dim GetSOPartNumberCommand As New SqlCommand(GetSOPartNumberStatement, con)
                GetSOPartNumberCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtDSSalesOrderNumber.Text)
                GetSOPartNumberCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = SOLineNumber
                GetSOPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim GetSOQuantityStatement As String = "SELECT Quantity FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey AND DivisionID = @DivisionID"
                Dim GetSOQuantityCommand As New SqlCommand(GetSOQuantityStatement, con)
                GetSOQuantityCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtDSSalesOrderNumber.Text)
                GetSOQuantityCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = SOLineNumber
                GetSOQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim GetPOPartNumberStatement As String = "SELECT PartNumber FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber AND DivisionID = @DivisionID"
                Dim GetPOPartNumberCommand As New SqlCommand(GetPOPartNumberStatement, con)
                GetPOPartNumberCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                GetPOPartNumberCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = SOLineNumber
                GetPOPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim GetPOQuantityStatement As String = "SELECT OrderQuantity FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber AND DivisionID = @DivisionID"
                Dim GetPOQuantityCommand As New SqlCommand(GetPOQuantityStatement, con)
                GetPOQuantityCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                GetPOQuantityCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = SOLineNumber
                GetPOQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSOPartNumber = CStr(GetSOPartNumberCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetSOPartNumber = ""
                End Try
                Try
                    GetSOQuantity = CInt(GetSOQuantityCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetSOQuantity = 0
                End Try
                Try
                    GetPOPartNumber = CStr(GetPOPartNumberCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetPOPartNumber = ""
                End Try
                Try
                    GetPOQuantity = CInt(GetPOQuantityCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetPOQuantity = 0
                End Try
                con.Close()

                If GetPOPartNumber = GetSOPartNumber And GetPOQuantity = GetSOQuantity Then
                    'Proceed to next line
                    LinkStatus = "LINKED"
                Else
                    LinkStatus = "NOT LINKED"
                    Exit For
                End If

                SOLineNumber = SOLineNumber + 1
            Next i

            If LinkStatus = "NOT LINKED" Then
                MsgBox("Line part and line quantity does not match. Delete this PO and re-create from the Sales Order.", MsgBoxStyle.OkOnly)
            ElseIf LinkStatus = "LINKED" Then
                'Get Customer ID and Additional Ship To
                Dim GetCustomerStatement As String = "SELECT CustomerID FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                Dim GetCustomerCommand As New SqlCommand(GetCustomerStatement, con)
                GetCustomerCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtDSSalesOrderNumber.Text)
                GetCustomerCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim GetShipToIDStatement As String = "SELECT AdditionalShipTo FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                Dim GetShipToIDCommand As New SqlCommand(GetShipToIDStatement, con)
                GetShipToIDCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtDSSalesOrderNumber.Text)
                GetShipToIDCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetCustomer = CStr(GetCustomerCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetCustomer = ""
                End Try
                Try
                    GetShipToID = CStr(GetShipToIDCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetShipToID = ""
                End Try
                con.Close()

                cboCustomerDSName.Text = GetCustomer

                If GetShipToID = "" Then
                    'Do nothing
                Else
                    cboShipToID.Text = GetShipToID
                End If

                'Save PO Number into Sales Order
                cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET DropShipPONumber = @DropShipPONumber WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtDSSalesOrderNumber.Text)
                    .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@DropShipPONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Save changes in PO
                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status, PODropShipCustomerID = @PODropShipCustomerID, POAdditionalShipTo = @POAdditionalShipTo, DropShipSalesOrderNumber = @DropShipSalesOrderNumber WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Status", SqlDbType.VarChar).Value = "DROPSHIP"
                    .Add("@PODropShipCustomerID", SqlDbType.VarChar).Value = cboCustomerDSName.Text
                    .Add("@POAdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                    .Add("@DropShipSalesOrderNumber", SqlDbType.VarChar).Value = Val(txtDSSalesOrderNumber.Text)
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Update PO Lines to Drop Ship
                cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                LoadPOStatus()

                MsgBox("PO and SO are now linked.", MsgBoxStyle.OkOnly)
            Else
                MsgBox("There was a problem linking the Sales Order. Delete this PO and re-create from the Sales Order.", MsgBoxStyle.OkOnly)
            End If
        Else
            MsgBox("Sales Order selected is not a drop ship or is closed. Cannot proceed.", MsgBoxStyle.OkOnly)
        End If

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If POStatus = "CLOSED" Then
            ClearAllData()
            ClearVariables()
            GlobalPONumber = 0
            GlobalDivisionCode = EmployeeCompanyCode
            ClearDataInDatagrid()
            Me.Dispose()
            Me.Close()
        Else
            If cboPurchaseOrderNumber.Text = "" Then
                ClearAllData()
                ClearVariables()
                GlobalPONumber = 0
                GlobalDivisionCode = EmployeeCompanyCode
                ClearDataInDatagrid()
                Me.Dispose()
                Me.Close()
            Else
                ''if neither boolean is tripped this will just exit without saving
                If needsSaved = False Then
                    ClearAllData()
                    ClearVariables()
                    GlobalPONumber = 0
                    GlobalDivisionCode = EmployeeCompanyCode
                    ClearDataInDatagrid()
                    Me.Dispose()
                    Me.Close()
                    Exit Sub
                End If
                If isSomeoneEditing() Then
                    ClearAllData()
                    ClearVariables()
                    GlobalPONumber = 0
                    GlobalDivisionCode = EmployeeCompanyCode
                    ClearDataInDatagrid()
                    Me.Dispose()
                    Me.Close()
                    Exit Sub
                End If
                'Prompt before Saving
                Dim button As DialogResult = MessageBox.Show("Do you wish to save this Purchase Order?", "SAVE PURCHASE ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    '*************************************************************************************************
                    If cboShipVia.Text = "" Then
                        MsgBox("You must select a ship via", MsgBoxStyle.OkOnly)
                        cboShipVia.Focus()
                        Exit Sub
                    End If
                    '*************************************************************************************************
                    'Validate Vendoor
                    Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                    Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
                    VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
                    VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        VerifyVendor = ""
                    End Try
                    con.Close()

                    If VerifyVendor = "" Then
                        MsgBox("You must have a valid Vendor selected.", MsgBoxStyle.OkOnly)
                    Else
                        'Recalculate totals in grid in case of changes
                        'Create command to save data from text boxes
                        cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET ExtendedAmount = OrderQuantity * UnitCost WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
                        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Determine PO Status
                        If chkDropShip.Checked = True Then
                            POStatus = "DROPSHIP"

                            'Update PO Lines to Drop Ship
                            cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        ElseIf chkDropShip.Checked = False Then
                            POStatus = "OPEN"
                        End If

                        'Load PO Totals
                        LoadTotals()

                        'See if PO has a receiver - disable ability to change Vendor
                        Dim GetReceiverVendorStatement As String = "SELECT VendorCode FROM ReceivingHeaderTable WHERE PONumber = @PONumber AND DivisionID = @DivisionID"
                        Dim GetReceiverVendorCommand As New SqlCommand(GetReceiverVendorStatement, con)
                        GetReceiverVendorCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        GetReceiverVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetReceiverVendor = CStr(GetReceiverVendorCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            GetReceiverVendor = ""
                        End Try
                        con.Close()

                        ShipDate = dtpShipDatePicker.Value
                        PODate = dtpPurchaseOrderDate.Value

                        If GetReceiverVendor = "" Then
                            SaveUpdateProcedure()
                        Else
                            SaveUpdateWOVendorProcedure()
                        End If

                        'Run routine to check if PO Lines are open
                        For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
                            Try
                                LineNumber = row.Cells("PurchaseOrderLineNumberColumn").Value
                            Catch ex As System.Exception
                                LineNumber = 0
                            End Try

                            Dim VerifyOpenAmountStatement As String = "SELECT POQuantityOpen FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber"
                            Dim VerifyOpenAmountCommand As New SqlCommand(VerifyOpenAmountStatement, con)
                            VerifyOpenAmountCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                            VerifyOpenAmountCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = LineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                QuantityOpen = CInt(VerifyOpenAmountCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                QuantityOpen = 0
                            End Try
                            con.Close()

                            TotalQuantityOpen = TotalQuantityOpen + QuantityOpen
                        Next

                        If TotalQuantityOpen = 0 Then
                            'Verify that PO has lines
                            Dim CheckPOLinesStatement As String = "SELECT COUNT(PurchaseOrderHeaderKey) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID AND LineStatus <> @LineStatus"
                            Dim CheckPOLinesCommand As New SqlCommand(CheckPOLinesStatement, con)
                            CheckPOLinesCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                            CheckPOLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            CheckPOLinesCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                CheckPOLines = CInt(CheckPOLinesCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                CheckPOLines = 0
                            End Try
                            con.Close()

                            If CheckPOLines = 0 Then
                                Dim button2 As DialogResult = MessageBox.Show("There are no Open Lines, would you like to close the Purchase Order?", "CLOSE SALES ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                If button2 = DialogResult.Yes Then
                                    POStatus = "CLOSED"

                                    'Update PO
                                    cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                                    With cmd.Parameters
                                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Else
                                    POStatus = txtPOStatus.Text
                                End If
                            Else
                                'Do nothing
                            End If
                        End If

                        'Clear Line item text boxes
                        ClearLines()
                        cboPartNumber.Focus()
                        ShowData()

                        'Clear all data
                        ClearAllData()
                        ClearVariables()
                        GlobalPONumber = 0
                        GlobalDivisionCode = EmployeeCompanyCode
                        ClearDataInDatagrid()
                        Me.Dispose()
                        Me.Close()
                    End If
                ElseIf button = DialogResult.No Then
                    ClearAllData()
                    ClearVariables()
                    GlobalPONumber = 0
                    GlobalDivisionCode = EmployeeCompanyCode
                    ClearDataInDatagrid()
                    Me.Dispose()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub cmdGeneratePO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGeneratePO.Click
        If Not String.IsNullOrEmpty(cboPurchaseOrderNumber.Text) Then
            unlockBatch()
        End If

        ClearAllData()
        ClearVariables()
        ShowData()
        Counter = 1

        ShipDate = dtpShipDatePicker.Value
        PODate = dtpPurchaseOrderDate.Value

        'Get Employee Id to write to database
        Dim SalesPersonIDStatement As String = "SELECT SalesPersonID FROM EmployeeData WHERE LoginName = @LoginName"
        Dim SalesPersonIDCommand As New SqlCommand(SalesPersonIDStatement, con)
        SalesPersonIDCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SalesPersonID = CStr(SalesPersonIDCommand.ExecuteScalar)
        Catch ex As System.Exception
            SalesPersonID = ""
        End Try
        con.Close()

        If SalesPersonID = "" Then
            SalesPersonID = EmployeeSalespersonCode
        End If

        'Save PO Number to database so it cannot be selected again
        'Write to Header Database Table
        SaveInsertProcedure()

        ''makes sure to have it prompt to save
        isLoaded = False
        LoadPONumber()
        isLoaded = True
        cboPurchaseOrderNumber.Text = NextTransactionNumber
        cboPurchaseOrderNumber.Focus()
    End Sub

    Private Sub cmdSavePO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSavePO.Click
        If cboPurchaseOrderNumber.Text = "" Or cboVendorCode.Text = "" Then
            MsgBox("You must select a valid Purchase Order Number and Vendor ID before saving", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************
        If isSomeoneEditing() Then
            ShowData()
            LoadPOData()
            CalculatePOWeight()
            LoadReceiverVendor()
            Exit Sub
        End If
        '*************************************************************************************
        CheckDivision()
        If DivisionMatch = "NO" Then
            MsgBox("There is an issue with this PO. Contact System Admin.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************
        LockBatch()

        If lineInfoChanged Then
            cmdSaveLine_Click(sender, e)
            lineInfoChanged = False
        End If
        '*************************************************************************************************
        'Validate Vendor
        Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
        VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorCode.Text
        VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
        Catch ex As System.Exception
            VerifyVendor = ""
        End Try
        con.Close()

        If VerifyVendor = "" Then
            MsgBox("You must have a valid Vendor selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************************
        'Recalculate totals in grid in case of changes
        cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET ExtendedAmount = OrderQuantity * UnitCost WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '*************************************************************************************************
        If cboShipVia.Text = "" Then
            MsgBox("You must select a ship via", MsgBoxStyle.OkOnly)
            cboShipVia.Focus()
            Exit Sub
        End If
        '*************************************************************************************************
        'Load PO Status
        If chkDropShip.Checked = True Then
            POStatus = "DROPSHIP"

            'Update PO Lines to Drop Ship
            cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        ElseIf chkDropShip.Checked = False Then
            POStatus = "OPEN"
        End If

        'Load PO Totals
        LoadTotals()

        ShipDate = dtpShipDatePicker.Value
        PODate = dtpPurchaseOrderDate.Value
        '*************************************************************************************************
        'Prompt before Saving
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this Purchase Order?", "SAVE PURCHASE ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'See if PO has a receiver - disable ability to change Vendor
            Dim GetReceiverVendorStatement As String = "SELECT VendorCode FROM ReceivingHeaderTable WHERE PONumber = @PONumber AND DivisionID = @DivisionID"
            Dim GetReceiverVendorCommand As New SqlCommand(GetReceiverVendorStatement, con)
            GetReceiverVendorCommand.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
            GetReceiverVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetReceiverVendor = CStr(GetReceiverVendorCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetReceiverVendor = ""
            End Try
            con.Close()

            If GetReceiverVendor = "" Then
                SaveUpdateProcedure()
            Else
                SaveUpdateWOVendorProcedure()
            End If

            'Run routine to check if PO Lines are open
            For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
                Try
                    LineNumber = row.Cells("PurchaseOrderLineNumberColumn").Value
                Catch ex As System.Exception
                    LineNumber = 0
                End Try

                Dim VerifyOpenAmountStatement As String = "SELECT POQuantityOpen FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber"
                Dim VerifyOpenAmountCommand As New SqlCommand(VerifyOpenAmountStatement, con)
                VerifyOpenAmountCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                VerifyOpenAmountCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = LineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    QuantityOpen = CInt(VerifyOpenAmountCommand.ExecuteScalar)
                Catch ex As System.Exception
                    QuantityOpen = 0
                End Try
                con.Close()

                If QuantityOpen > 0 Then
                    'line is open
                    cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = LineNumber
                        .Add("@LineStatus", SqlDbType.VarChar).Value = POStatus
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = LineNumber
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                If QuantityOpen < 0 Then
                    QuantityOpen = 0
                End If

                TotalQuantityOpen = TotalQuantityOpen + QuantityOpen
            Next

            If TotalQuantityOpen = 0 Then
                'Verify that PO has lines
                Dim CheckPOLinesStatement As String = "SELECT COUNT(PurchaseOrderHeaderKey) FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID AND LineStatus <> @LineStatus"
                Dim CheckPOLinesCommand As New SqlCommand(CheckPOLinesStatement, con)
                CheckPOLinesCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                CheckPOLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CheckPOLinesCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckPOLines = CInt(CheckPOLinesCommand.ExecuteScalar)
                Catch ex As System.Exception
                    CheckPOLines = 0
                End Try
                con.Close()

                If CheckPOLines = 0 Then
                    Dim button2 As DialogResult = MessageBox.Show("There are no Open Lines, would you like to close the Purchase Order?", "CLOSE SALES ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If button2 = DialogResult.Yes Then
                        POStatus = "CLOSED"

                        'Update PO
                        cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        POStatus = txtPOStatus.Text
                    End If
                Else
                    'Do nothing
                End If
            End If

            'Clear Line item text boxes
            ClearLines()
            cboPartNumber.Focus()
            ShowData()
            LoadPOStatus()
            CalculatePOWeight()

            ''changes so that doesnt need to be saved again
            needsSaved = False
        ElseIf button = DialogResult.No Then
            cboPurchaseOrderNumber.Focus()
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        If Not String.IsNullOrEmpty(cboPurchaseOrderNumber.Text) Then
            unlockBatch()
        End If

        'Clear all text boxes
        isLoaded = False
        LoadPONumber()
        isLoaded = True

        ClearGLAccounts()
        ClearVariables()
        ClearAllData()
        ClearDataInDatagrid()
        cboPurchaseOrderNumber.Focus()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearLines()
        ClearGLAccounts()
    End Sub

    Private Sub cmdItemForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Loads Item Maintenance Form for Inventory or Non-Inventory Items
        GlobalMaintenancePartNumber = cboPartNumber.Text
        Using NewItemMaintenance As New ItemMaintenance
            Dim result = NewItemMaintenance.ShowDialog()
        End Using
    End Sub

    Private Sub cmdVendorForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVendorForm.Click
        GlobalVendorID = cboVendorCode.Text
        Using NewVendorInformation As New VendorInformation
            Dim result = NewVendorInformation.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPurchaseHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPurchaseHistory.Click
        'Assign part and vendor to global variable before loading PO Purchase History Form
        GlobalVendorID = cboVendorCode.Text
        GlobalMaintenancePartNumber = cboPartNumber.Text
        GlobalMaintenancePartDescription = cboPartDescription.Text

        Dim NewViewVendorPurchaseHistory As New ViewPurchaseLines
        NewViewVendorPurchaseHistory.Show()
    End Sub

    Private Sub cmdLoadDefaultAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadDefaultAddress.Click
        If cboCustomerDSName.Text <> "" Or cboShipToID.Text <> "" Then
            cboCustomerDSName.SelectedIndex = -1
            cboShipToID.SelectedIndex = -1

            LoadShippingAddress()
        Else
        End If
    End Sub

    Private Sub cmdGetDivisionPackList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetDivisionPackList.Click
        Dim TempPONumber As Integer = 0
        Dim strTempPONumber As String = ""
        Dim TempShipmentNumber As Integer = 0
        Dim TempCustomerPONumber As String = ""

        If txtDivisionVendor.Text = "" Then
            MsgBox("You must enter the division of the vendor.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Construct Customer PO Number
        TempPONumber = Val(cboPurchaseOrderNumber.Text)
        strTempPONumber = CStr(TempPONumber)
        TempCustomerPONumber = cboDivisionID.Text + strTempPONumber

        'See if there is a packing list with that Customer PO
        Dim TempShipmentNumberStatement As String = "SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND CustomerPO = @CustomerPO"
        Dim TempShipmentNumberCommand As New SqlCommand(TempShipmentNumberStatement, con)
        TempShipmentNumberCommand.Parameters.Add("@CustomerPO", SqlDbType.VarChar).Value = TempCustomerPONumber
        TempShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionVendor.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TempShipmentNumber = CInt(TempShipmentNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            TempShipmentNumber = 0
        End Try
        con.Close()

        If TempShipmentNumber = 0 Then
            MsgBox("There is no packing list for this PO", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Bring up Packing List Print Form
        GlobalShipmentNumber = TempShipmentNumber
        GlobalDivisionCode = txtDivisionVendor.Text
        GlobalCompleteShipment = "PO FORM"

        Using NewPrintPackList As New PrintPackingList
            Dim Result = NewPrintPackList.ShowDialog()
        End Using
    End Sub

    Private Sub cmdViewQuote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewQuote.Click
        'Create Filename = DivisionID + PO NUmber
        Dim POQuoteFilename As String = ""
        Dim POQuoteFilenameAndPath As String = ""
        Dim strPONumber As String = ""

        strPONumber = CStr(cboPurchaseOrderNumber.Text)

        POQuoteFilename = cboDivisionID.Text + strPONumber + ".pdf"
        POQuoteFilenameAndPath = "\\TFP-FS\TransferData\PO Quotes\" + POQuoteFilename

        If File.Exists(POQuoteFilenameAndPath) Then
            System.Diagnostics.Process.Start(POQuoteFilenameAndPath)
        Else
            MsgBox("File can not be found", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdUploadQuote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadQuote.Click
        'Create Filename = DivisionID + PO NUmber
        Dim POQuoteFilename As String = ""
        Dim POQuoteFilenameAndPath As String = ""
        Dim TempFileName As String = ""
        Dim strPONumber As String = ""

        strPONumber = CStr(cboPurchaseOrderNumber.Text)

        POQuoteFilename = cboDivisionID.Text + strPONumber + ".pdf"
        POQuoteFilenameAndPath = "\\TFP-FS\TransferData\PO Quotes\" + POQuoteFilename

        'Open Dialog Box
        Dim myDocumentsFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        ofdPOQuotes.InitialDirectory = myDocumentsFolder + "\" + "My Paperport Documents\Samples"

        'Open File Dialog Box
        If ofdPOQuotes.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        'Get filename from dialog box
        TempFileName = ofdPOQuotes.FileName

        If TempFileName = "" Then
            Exit Sub
        End If

        'If Filename exists, delete the old file and copy over a new file
        If File.Exists(POQuoteFilenameAndPath) Then
            File.Delete(POQuoteFilenameAndPath)
        Else
            'Continue
        End If
        Try
            'Rename file
            File.Copy(TempFileName, POQuoteFilenameAndPath)
            MsgBox("PO Quote Uploaded", MsgBoxStyle.OkOnly)

            POQuoteFilename = ""
            POQuoteFilenameAndPath = ""
            TempFileName = ""

        Catch ex As Exception
            'Rename file
            MsgBox("Filename already exists.", MsgBoxStyle.OkCancel)
            Exit Sub
        End Try
    End Sub

    'Menu Strip Routines

    Private Sub PrintPurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPurchaseOrderToolStripMenuItem.Click
        cmdPrintPO_Click(sender, e)
    End Sub

    Private Sub ReIssuePurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReIssuePurchaseOrderToolStripMenuItem.Click
        cmdReissuePO_Click(sender, e)
    End Sub

    Private Sub ClosePurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClosePurchaseOrderToolStripMenuItem.Click
        If POStatus = "CLOSED" Then
            ClearVariables()
            ClearAllData()
        Else
            If isSomeoneEditing() Then
                ShowData()
                LoadPOData()
                CalculatePOWeight()
                LoadReceiverVendor()
                Exit Sub
            End If
            LockBatch()
            If cboPurchaseOrderNumber.Text = "" Then
                MsgBox("You must select a valid Purchase Order number.", MsgBoxStyle.OkOnly)
            Else
                'Prompt before Saving
                Dim button As DialogResult = MessageBox.Show("Do you wish to save this Purchase Order?", "SAVE PURCHASE ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then

                    'Change Status on PO Header to Closed
                    cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET  Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Change Status on PO Lines to Closed
                    cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET  LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    unlockBatch()
                    'Clear Line item text boxes
                    ClearVariables()
                    ClearAllData()
                    MsgBox("This Purchase Order is closed.", MsgBoxStyle.OkOnly)
                ElseIf button = DialogResult.No Then
                    'Do nothing
                End If
            End If
        End If
    End Sub

    Private Sub ReOpenPurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReOpenPurchaseOrderToolStripMenuItem.Click
        'Prompt before re-opening
        Dim button As DialogResult = MessageBox.Show("Do you wish to Re-Open this Purchase Order?", "RE-OPEN PURCHASE ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            LoadPOStatus()

            If POStatus = "DROPSHIP" Then
                MsgBox("You do not have to re-open a DROP SHIP PO.", MsgBoxStyle.OkOnly)
            Else
                If isSomeoneEditing() Then
                    ShowData()
                    LoadPOData()
                    CalculatePOWeight()
                    LoadReceiverVendor()
                    Exit Sub
                End If
                LockBatch()
                'Create command to change PO status to OPEN
                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Purchase Order has been re-opened", MsgBoxStyle.OkOnly)
                LoadPOData()
                ShowData()
                CalculatePOWeight()
            End If

        ElseIf button = DialogResult.No Then
            cboPurchaseOrderNumber.Focus()
        End If
    End Sub

    Private Sub DeletePurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletePurchaseOrderToolStripMenuItem.Click
        cmdDeletePO_Click(sender, e)
    End Sub

    Private Sub SavePurchaseOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePurchaseOrderToolStripMenuItem.Click
        cmdSavePO_Click(sender, e)
    End Sub

    Private Sub PrintPOPackListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPOPackListToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        GlobalPONumber = cboPurchaseOrderNumber.Text

        Using NewPrintPOShipper As New PrintPOShipper
            Dim Result = NewPrintPOShipper.ShowDialog()
        End Using
    End Sub

    Private Sub UnLockPurchaseORderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockPurchaseORderToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(cboPurchaseOrderNumber.Text) Then
            If MessageBox.Show("Are you sure you wish to un-lock this Purchase Order?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Locked = '' WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey", con)
                cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Purchase Order is now un-locked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You must enter a Purchase Order number to un-lock", "Enter a Purchase Order number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPurchaseOrderNumber.Focus()
        End If
    End Sub

    Private Sub PrintReceiversToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintReceiversToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        GlobalPONumber = Val(cboPurchaseOrderNumber.Text)

        Using NewPrintReceiverPO As New PrintReceiverPO
            Dim Result = NewPrintReceiverPO.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub ManuallyClosePOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManuallyClosePOToolStripMenuItem.Click
        If cboPurchaseOrderNumber.Text = "" Then
            MsgBox("You must have a valid Purchase Order Number selected.", MsgBoxStyle.OkOnly)
        Else
            If isSomeoneEditing() Then
                ShowData()
                LoadPOData()
                CalculatePOWeight()
                LoadReceiverVendor()
                Exit Sub
            End If
            Try
                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                'PO doesnt exist
            End Try

            Try
                cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                'Do nothing
            End Try

            ShowData()
            unlockBatch()
            LoadPOStatus()
        End If
    End Sub

    Private Sub ManuallyOpenPOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManuallyOpenPOToolStripMenuItem.Click
        'Prompt before re-opening
        Dim button As DialogResult = MessageBox.Show("Do you wish to Re-Open this Purchase Order?", "RE-OPEN PURCHASE ORDER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            LoadPOStatus()

            'Create command to change PO status to OPEN
            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status, Locked = @Locked WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Create command to change PO status to OPEN
            cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ShowData()

            txtPOStatus.Text = "OPEN"

            'Run routine to re-open lines
            For Each row As DataGridViewRow In dgvPurchaseOrderLines.Rows
                Try
                    LineNumber = row.Cells("PurchaseOrderLineNumberColumn").Value
                Catch ex As System.Exception
                    LineNumber = 0
                End Try

                Dim VerifyOpenAmountStatement As String = "SELECT POQuantityOpen FROM PurchaseOrderQuantityStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber"
                Dim VerifyOpenAmountCommand As New SqlCommand(VerifyOpenAmountStatement, con)
                VerifyOpenAmountCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                VerifyOpenAmountCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = LineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    QuantityOpen = CDbl(VerifyOpenAmountCommand.ExecuteScalar)
                Catch ex As System.Exception
                    QuantityOpen = 0
                End Try
                con.Close()

                If QuantityOpen <= 0 Then
                    'Create command to change PO Line status to Received
                    cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = LineNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Create command to change PO Line status to Open
                    cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber", con)

                    With cmd.Parameters
                        .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                        .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = LineNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next

            MsgBox("Purchase Order has been re-opened", MsgBoxStyle.OkOnly)
            LoadPOData()
            ShowData()
        ElseIf button = DialogResult.No Then
            cboPurchaseOrderNumber.Focus()
        End If
    End Sub

    Private Sub ViewQuoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewQuoteToolStripMenuItem.Click
        cmdViewQuote_Click(sender, e)
    End Sub

    Private Sub UploadQuoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadQuoteToolStripMenuItem.Click
        cmdUploadQuote_Click(sender, e)
    End Sub

    'Combo Box Routines

    Private Sub cboPaymentTerms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentTerms.SelectedIndexChanged
        If cboPaymentTerms.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub cboShipVia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipVia.SelectedIndexChanged
        If cboShipVia.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub cboItemClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemClass.SelectedIndexChanged
        LoadGLAccounts()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cboPurchaseOrderNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPurchaseOrderNumber.SelectedIndexChanged
        If isLoaded Then
            isLoadingPO = True

            If Not String.IsNullOrEmpty(lastPO) Then
                unlockBatch(lastPO)
            End If

            lastPO = cboPurchaseOrderNumber.Text

            'Load data into PO Transfer Combo box to link binding source
            ClearEditLines()
            ClearLines()
            ShowData()
            LoadReturnDatagrid()
            LoadReceiverDatagrid()
            LoadVoucherDatagrid()
            LoadPOData()
            CalculatePOWeight()
            LoadReceiverVendor()
            LoadPODetailTotals()
            isLoadingPO = False
        End If
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadItemData()
        LoadGLAccounts()
        LoadDescriptionByPart()
    End Sub

    Private Sub cboVendorCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorCode.SelectedIndexChanged
        GlobalVendorID = cboVendorCode.Text
        LoadVendorData()

        If cboVendorCode.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub cboLineNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLineNumber.SelectedIndexChanged
        LoadLineDetails()
    End Sub

    Private Sub cboShipToID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipToID.SelectedIndexChanged
        ClearShippingData()

        If cboShipToID.Text = "" And cboCustomerDSName.Text <> "" Then
            LoadCustomerData()
        ElseIf cboShipToID.Text <> "" And cboCustomerDSName.Text <> "" Then
            LoadAdditionalShipToDetails()
        Else
            'Do nothing
        End If

        If cboShipToID.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub cboCustomerDSName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerDSName.SelectedIndexChanged
        ClearShippingData()
        LoadAdditionalShipTo()

        If cboShipToID.Text = "" And cboCustomerDSName.Text <> "" Then
            LoadCustomerData()
        ElseIf cboShipToID.Text <> "" And cboCustomerDSName.Text <> "" Then
            LoadAdditionalShipToDetails()
        Else
            'Do nothing
        End If

        If cboCustomerDSName.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If Not String.IsNullOrEmpty(lastPO) And isLoaded Then
            unlockBatch(lastPO)
        End If

        ClearDataInDatagrid()
        LoadVendorID()
        isLoaded = False
        LoadPONumber()
        isLoaded = True
        LoadPartNumber()
        LoadPartDescription()
        LoadEditPartNumber()
        LoadCustomerList()
        ClearOnLoad()
        ShowData()
        LoadShippingAddress()
        cboPurchaseOrderNumber.Focus()
    End Sub

    Private Sub cboLinePartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLinePartNumber.SelectedIndexChanged
        If isLoaded Then
            LoadDescriptionByPart2()
        End If
    End Sub

    Private Sub cboLineDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLineDescription.SelectedIndexChanged
        If isLoaded Then
            LoadPartByDescription2()
        End If
    End Sub

    Private Sub cboNewItemClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNewItemClass.SelectedIndexChanged
        If cboNewItemClass.Text <> "" Then
            cboItemClass.SelectedIndex = -1
            cboItemClass.Text = cboNewItemClass.Text
            LoadGLAccounts()
        End If
    End Sub

    'Text Box Routines

    Private Sub txtFreightCharges_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightCharges.TextChanged
        FreightCharge = Val(txtFreightCharges.Text)
        POTotal = FreightCharge + SalesTax + ProductTotal
        lblOrderTotal.Text = FormatCurrency(POTotal, 2)
    End Sub

    Private Sub txtSalesTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesTax.TextChanged
        SalesTax = Val(txtSalesTax.Text)
        POTotal = FreightCharge + SalesTax + ProductTotal
        lblOrderTotal.Text = FormatCurrency(POTotal, 2)
    End Sub

    Private Sub txtLineUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineUnitCost.TextChanged
        LineUnitCost = Val(txtLineUnitCost.Text)
        LineOrderQuantity = Val(txtLineOrderQuantity.Text)
        LineExtendedAmount = LineUnitCost * LineOrderQuantity
        LineEditExtendedAmount = Math.Round(LineExtendedAmount, 2)
        txtLineExtendedCost.Text = FormatCurrency(LineExtendedAmount, 2)
    End Sub

    Private Sub txtLineOrderQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineOrderQuantity.TextChanged
        LineUnitCost = Val(txtLineUnitCost.Text)
        LineOrderQuantity = Val(txtLineOrderQuantity.Text)
        LineExtendedAmount = LineUnitCost * LineOrderQuantity
        LineEditExtendedAmount = Math.Round(LineExtendedAmount, 2)
        txtLineExtendedCost.Text = FormatCurrency(LineExtendedAmount, 2)
    End Sub

    Private Sub txtOrderQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrderQuantity.TextChanged
        LineQuantity = Val(txtOrderQuantity.Text)
    End Sub

    Private Sub txtUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitCost.TextChanged
        LineCost = Val(txtUnitCost.Text)
        LineAmount = LineCost * LineQuantity
        LineAmount = Math.Round(LineAmount, 2)
        lblAmount.Text = FormatCurrency(LineAmount, 2)
    End Sub

    Private Sub txtFreightCharges_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFreightCharges.KeyUp
        If shouldSwitchStatus(e) Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtSalesTax_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSalesTax.KeyUp
        If shouldSwitchStatus(e) Then
            needsSaved = True
        End If
    End Sub

    Private Sub txtPOComment_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPOComment.KeyUp
        If shouldSwitchStatus(e) Then
            needsSaved = True
        End If
    End Sub

    'Check boxes / link labels / Misc

    Private Sub llLastPurchaseCost_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llLastPurchaseCost.LinkClicked
        GlobalDivisionCode = cboDivisionID.Text
        GlobalPOPartNumber = cboPartNumber.Text

        Using NewSOPurchaseCostPopup As New SOPurchaseCostPopup
            Dim Result = NewSOPurchaseCostPopup.ShowDialog()
        End Using
    End Sub

    Private Sub llVendorInfo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llVendorInfo.LinkClicked
        GlobalVendorID = cboVendorCode.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewVendorInfoPopup As New VendorInfoPopup
            Dim result = NewVendorInfoPopup.ShowDialog()
        End Using
    End Sub

    Private Sub llOrderQuantity_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llOrderQuantity.LinkClicked
        GlobalDivisionCode = cboDivisionID.Text
        GlobalPOPartNumber = cboPartNumber.Text
        GlobalPOPartDescription = cboPartDescription.Text

        Using NewPOQuantityOnHand As New POQuantityOnHand
            Dim Result = NewPOQuantityOnHand.ShowDialog()
        End Using
    End Sub

    Private Sub chkDropShip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDropShip.CheckedChanged
        If Not isLoadingPO Then
            If isSomeoneEditing() Then
                ShowData()
                LoadPOData()
                CalculatePOWeight()
                LoadReceiverVendor()
                Exit Sub
            End If

            LockBatch()
        Else
            Exit Sub
        End If

        If chkDropShip.Checked = True Then
            txtPOStatus.Text = "DROPSHIP"
            cmdLoadDefaultAddress.Enabled = False

            'Get Drop Ship SO Number
            Dim DSSONumberStatement As String = "SELECT SalesOrderKey, CustomerID, AdditionalShipTo FROM SalesOrderHeaderTable WHERE DropShipPONumber = @DropShipPONumber AND DivisionKey = @DivisionKey"
            Dim DSSONumberCommand As New SqlCommand(DSSONumberStatement, con)
            DSSONumberCommand.Parameters.Add("@DropShipPONumber", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
            DSSONumberCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = DSSONumberCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("SalesOrderKey")) Then
                    DSSONumber = 0
                Else
                    DSSONumber = reader.Item("SalesOrderKey")
                End If
                If IsDBNull(reader.Item("CustomerID")) Then
                    DSCustomerID = ""
                Else
                    DSCustomerID = reader.Item("CustomerID")
                End If
                If IsDBNull(reader.Item("AdditionalShipTo")) Then
                    DSADDShipTo = ""
                Else
                    DSADDShipTo = reader.Item("AdditionalShipTo")
                End If
            Else
                DSSONumber = 0
                DSCustomerID = ""
                DSADDShipTo = ""
            End If
            reader.Close()
            con.Close()

            txtDSSalesOrderNumber.Text = DSSONumber

            If DSSONumber = 0 Or txtDSSalesOrderNumber.Text = "" Then
                'MsgBox("A Sales Order cannot be found for this PO. Please create PO from the Sales Order so they are linked.", MsgBoxStyle.OkOnly)
            Else
                txtDSSalesOrderNumber.Text = DSSONumber
                cboCustomerDSName.Text = DSCustomerID
                cboShipToID.Text = DSADDShipTo

                'Change Open Lines in PO to DROPSHIP
                cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus, DebitGLAccount = @DebitGLAccount WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "DROPSHIP"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "20990"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Change PO Status to Drop Ship
                cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status, DropShipSalesOrderNumber = @DropShipSalesOrderNumber WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                    .Add("@Status", SqlDbType.VarChar).Value = "DROPSHIP"
                    .Add("@DropShipSalesOrderNumber", SqlDbType.VarChar).Value = DSSONumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Else
            'Clear customer details
            txtDSSalesOrderNumber.Clear()
            txtPOStatus.Text = "OPEN"
            cmdLoadDefaultAddress.Enabled = True

            'Change DROPSHIP Lines in PO to OPEN
            cmd = New SqlCommand("UPDATE PurchaseOrderLineTable SET LineStatus = @LineStatus, DebitGLAccount = @DebitGLAccount WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "20999"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Change PO Status to Drop Ship
            cmd = New SqlCommand("UPDATE PurchaseOrderHeaderTable SET Status = @Status WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPurchaseOrderNumber.Text)
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If

        If chkDropShip.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub chkInventoryItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInventoryItem.CheckedChanged
        If chkInventoryItem.Checked Then
            'Load Part Number for Inventory Items
            cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND (PurchProdLineID <> 'NON-INVENTORY' OR SalesProdLineID <> 'SUPPLY') ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd

            If con.State = ConnectionState.Closed Then con.Open()
            myAdapter2.Fill(ds2, "ItemList")
            con.Close()

            cboPartNumber.DataSource = ds2.Tables("ItemList")
            cboPartNumber.SelectedIndex = -1

            cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND (PurchProdLineID <> 'NON-INVENTORY' OR SalesProdLineID <> 'SUPPLY') ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
            ds8 = New DataSet()
            myAdapter8.SelectCommand = cmd

            If con.State = ConnectionState.Closed Then con.Open()
            myAdapter8.Fill(ds8, "ItemList")
            con.Close()

            cboPartDescription.DataSource = ds8.Tables("ItemList")
            cboPartDescription.SelectedIndex = -1
        Else
            'Load Part Number for Non-inventory Items
            cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND (PurchProdLineID = 'NON-INVENTORY' OR SalesProdLineID = 'SUPPLY') ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd

            If con.State = ConnectionState.Closed Then con.Open()
            myAdapter2.Fill(ds2, "ItemList")
            con.Close()

            cboPartNumber.DataSource = ds2.Tables("ItemList")
            cboPartNumber.SelectedIndex = -1

            cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass AND (PurchProdLineID = 'NON-INVENTORY' OR SalesProdLineID = 'SUPPLY') ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
            ds8 = New DataSet()
            myAdapter8.SelectCommand = cmd

            If con.State = ConnectionState.Closed Then con.Open()
            myAdapter8.Fill(ds8, "ItemList")
            con.Close()

            cboPartDescription.DataSource = ds8.Tables("ItemList")
            cboPartDescription.SelectedIndex = -1
        End If
    End Sub

    Private Sub dtpPurchaseOrderDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPurchaseOrderDate.ValueChanged
        If dtpPurchaseOrderDate.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub dtpShipDatePicker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpShipDatePicker.ValueChanged
        If dtpShipDatePicker.Focused Then
            needsSaved = True
        End If
    End Sub

    Private Sub tabPODetails_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tabPODetails.KeyUp
        If tabPODetails.SelectedIndex = 1 Then
            If shouldSwitchStatus(e) Then
                needsSaved = True
            End If
        End If
    End Sub

    Private Sub tabPOlineDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tabPOlineDetails.KeyDown
        If tabPOlineDetails.SelectedIndex = 2 Then
            If Not lineInfoChanged Then
                lineInfoChanged = True
            End If
        End If
    End Sub

  
End Class