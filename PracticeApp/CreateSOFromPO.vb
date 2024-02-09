Imports System
Imports System.Data
Public Class CreateSOFromPO
    Inherits System.Windows.Forms.Form

    Dim LastLineNumber, NextLineNumber, NextTransactionNumber, LastTransactionNumber As Integer
    Dim SalesProdLineID, ShipEmail, ShippingAccount, ThirdPartyShipper, ShipMethod, CertificationType, ShipDate, POHeaderComment, ShipMethodID, SpecialInstructions, ItemClass, InventoryAccount As String
    Dim TotalWeight, SOTotal, FreightTotal, UpdatedLineBoxCount, BoxCount, SOProductTotal, POProductTotal, PieceWeight, LastCustomerPrice, ExtendedAmount, ExtendedCost, LineWeight, LineBoxes As Double
    Dim VerifyPartNumber As Integer = 0
    Dim FOB As String = ""
    Dim GetDivisionSONumber As Integer = 0
    Dim CountryCodeFromState As String = ""
    Dim StateCode As String = ""
    Dim CurrentSalesOrderKey As Integer = 0

    'Variables for TWD Last Sales Price
    Dim CurrentPartNumber As String = ""
    Dim AdjustedLastSalesPrice As Double = 0

    'Load values into Price Field
    Dim GetYearPricingDate As Date
    Dim UpdatedLastSalesPrice As Double = 0
    Dim MaxDate As Integer = 0

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Variables to load Customer Data
    Dim ShipToName, ShipName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry As String
    Dim CustomerClass As String = ""

    'Line Variables
    Dim PartNumber, PartDescription, LineComment As String
    Dim OrderQuantity, UnitCost As Double

    'Set up variables and database connection
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub CreateSOFromPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()
        LoadDivisionFromPO()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
        End If

        gpxInvalidPart.Visible = False
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

    Public Sub LoadDivisionFromPO()
        cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
        If con.State = ConnectionState.Closed Then con.Open()
        DivisionDataset = New DataSet()
        DivisionAdapter.SelectCommand = cmd
        DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
        cboPODivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
        con.Close()
        cboPODivisionID.SelectedIndex = -1
    End Sub

    Public Sub ShowPurchaseOrderLineData()
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboPODivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PurchaseOrderLineTable")
        dgvPOLines.DataSource = ds.Tables("PurchaseOrderLineTable")
        con.Close()

        'Check all lines after load
        For Each row As DataGridViewRow In dgvPOLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectedColumn")
            cell.Value = "SELECTED"
        Next
    End Sub

    Public Sub LoadPONumber()
        cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboPODivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "PurchaseOrderHeaderTable")
        cboPONumber.DataSource = ds1.Tables("PurchaseOrderHeaderTable")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerList()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerID.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Private Sub LoadCustomerName()
        'Create commands to load Customer List for each division
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "CustomerList")
        con.Close()

        cboCustomerName.DataSource = ds3.Tables("CustomerList")
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1String As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1String, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As System.Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName1
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1String As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1String, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
        Catch ex As System.Exception
            CustomerID1 = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID1
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

    Public Sub LoadDivisionCustomer()
        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TWE" Then
            Dim CustomerDivisionID As String = ""
            CustomerDivisionID = cboPODivisionID.Text

            Select Case CustomerDivisionID
                Case "ATL"
                    cboCustomerID.Text = "TFP ATLANTA"
                    cboCustomerName.Text = "TRU-FIT PRODUCTS OF ATLANTA"
                Case "ALB"
                    cboCustomerID.Text = "TFP ALBERTA"
                    cboCustomerName.Text = "TRU-FIT PRODUCTS OF ALBERTA"
                Case "CBS"
                    cboCustomerID.Text = "TFP NEVADA"
                    cboCustomerName.Text = "TRU-FIT PRODUCTS OF NEVADA"
                Case "CGO"
                    cboCustomerID.Text = "TFP INDIANA"
                    cboCustomerName.Text = "TRU-FIT PRODUCTS OF INDIANA"
                Case "DEN"
                    cboCustomerID.Text = "TFP DENVER"
                    cboCustomerName.Text = "TRU-FIT PRODUCTS OF DENVER"
                Case "HOU"
                    cboCustomerID.Text = "TFP HOUSTON"
                    cboCustomerName.Text = "TRU-FIT PRODUCTS OF HOUSTON"
                Case "TFJ"
                    cboCustomerID.Text = "TFP NEW JERSEY"
                    cboCustomerName.Text = "TRU-FIT PRODUCTS OF NEW JERSEY"
                Case "TFT"
                    cboCustomerID.Text = "TFP IRVING"
                    cboCustomerName.Text = "TRU-FIT PRODUCTS OF TEXAS"
                Case "TFF"
                    cboCustomerID.Text = "TFP VANCOUVER"
                    cboCustomerName.Text = "TRU-FIT FASTENERS & SUPPLY"
                Case "TOR"
                    cboCustomerID.Text = "TFP TORONTO"
                    cboCustomerName.Text = "TRU-FIT PRODUCTS OF TORONTO"
                Case "TWD"
                    cboCustomerID.Text = "TFP CORP"
                    cboCustomerName.Text = "TRU-FIT PRODUCTS CORP"
                Case "TWE"
                    cboCustomerID.Text = "TWE"
                    cboCustomerName.Text = "TRU-WELD EQUIPMENT"
                Case "SLC"
                    cboCustomerID.Text = "TFP UTAH"
                    cboCustomerName.Text = "TRU-FIT PRODUCTS OF UTAH"
                Case Else
                    'Do nothing
            End Select
        End If
    End Sub

    Private Sub cboPODivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPODivisionID.SelectedIndexChanged
        LoadPONumber()
        LoadDivisionCustomer()

        gpxInvalidPart.Visible = False
    End Sub

    Private Sub cmdViewPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPO.Click
        ShowPurchaseOrderLineData()
        gpxInvalidPart.Visible = False
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomerList()
        LoadCustomerName()
        ClearData()
        ClearVariables()
    End Sub

    Public Sub ClearVariables()
        LastLineNumber = 0
        NextLineNumber = 0
        NextTransactionNumber = 0
        LastTransactionNumber = 0
        ShipDate = ""
        POHeaderComment = ""
        ShipMethodID = ""
        SpecialInstructions = ""
        ItemClass = ""
        InventoryAccount = ""
        TotalWeight = 0
        SOTotal = 0
        FreightTotal = 0
        UpdatedLineBoxCount = 0
        BoxCount = 0
        SOProductTotal = 0
        POProductTotal = 0
        PieceWeight = 0
        LastCustomerPrice = 0
        ExtendedAmount = 0
        ExtendedCost = 0
        LineWeight = 0
        LineBoxes = 0
        VerifyPartNumber = 0
        FOB = ""
        ShipName = ""
        ShipToAddress1 = ""
        ShipToAddress2 = ""
        ShipToCity = ""
        ShipToState = ""
        ShipToZip = ""
        ShipToCountry = ""
        CustomerClass = ""
        ShipMethod = ""
        ThirdPartyShipper = ""
        CountryCodeFromState = ""
        StateCode = ""
        ShipEmail = ""
        ShippingAccount = ""

        'Line Variables
        PartNumber = ""
        PartDescription = ""
        LineComment = ""
        OrderQuantity = 0
        UnitCost = 0
    End Sub

    Public Sub ClearData()
        cboPODivisionID.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboPONumber.SelectedIndex = -1

        txtInvalidPart.Clear()

        gpxInvalidPart.Visible = False

        dtpOrderDate.Text = ""

        cboPODivisionID.Focus()
    End Sub

    Public Sub LoadSOTotals()
        Dim ProductTotalString As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalString, con)
        ProductTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber
        ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim LineWeightString As String = "SELECT SUM(LineWeight) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim LineWeightCommand As New SqlCommand(LineWeightString, con)
        LineWeightCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber
        LineWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SOProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            SOProductTotal = 0
        End Try
        Try
            TotalWeight = CDbl(LineWeightCommand.ExecuteScalar)
        Catch ex As Exception
            TotalWeight = 0
        End Try
        con.Close()

        SOTotal = FreightTotal + SOProductTotal
    End Sub

    Public Sub LoadPOData()
        Dim GetPODataStatement As String = "SELECT * FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim GetPODataCommand As New SqlCommand(GetPODataStatement, con)
        GetPODataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboPODivisionID.Text
        GetPODataCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetPODataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ShipDate")) Then
                ShipDate = ""
            Else
                ShipDate = reader.Item("ShipDate")
            End If
            If IsDBNull(reader.Item("POHeaderComment")) Then
                POHeaderComment = ""
            Else
                POHeaderComment = reader.Item("POHeaderComment")
            End If
            If IsDBNull(reader.Item("ProductTotal")) Then
                POProductTotal = 0
            Else
                POProductTotal = reader.Item("ProductTotal")
            End If
            If IsDBNull(reader.Item("ShipMethodID")) Then
                ShipMethodID = ""
            Else
                ShipMethodID = reader.Item("ShipMethodID")
            End If
            If IsDBNull(reader.Item("ShipMethod")) Then
                ShipMethod = ""
            Else
                ShipMethod = reader.Item("ShipMethod")
            End If
            If IsDBNull(reader.Item("DropShipSalesOrderNumber")) Then
                GetDivisionSONumber = 0
            Else
                GetDivisionSONumber = reader.Item("DropShipSalesOrderNumber")
            End If
        Else
            ShipDate = Today()
            POHeaderComment = ""
            POProductTotal = 0
            ShipMethodID = ""
            ShipMethod = ""
            GetDivisionSONumber = 0
        End If
        reader.Close()
        con.Close()
    End Sub

    Public Sub LoadCustomerData()
        Dim SpecialInstructionsString As String = "SELECT ShippingDetails FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim SpecialInstructionsCommand As New SqlCommand(SpecialInstructionsString, con)
        SpecialInstructionsCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        SpecialInstructionsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerClassString As String = "SELECT CustomerClass FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerClassCommand As New SqlCommand(CustomerClassString, con)
        CustomerClassCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SpecialInstructions = CStr(SpecialInstructionsCommand.ExecuteScalar)
        Catch ex As Exception
            SpecialInstructions = ""
        End Try
        Try
            CustomerClass = CStr(CustomerClassCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerClass = ""
        End Try
        con.Close()
    End Sub

    Public Sub LoadLastSalesPriceTWDRevised()
        'Declare variables
        Dim MaxDate As Integer = 0
        Dim GetItemClass As String = ""
        Dim GetSPL As String = ""
        Dim GetYearPricingDate As Date
        Dim LastSalesPrice As Double = 0
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
        GetItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = CurrentPartNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetItemClass = CStr(GetItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            GetItemClass = ""
        End Try
        con.Close()

        Dim GetSPLStatement As String = "SELECT SalesProdLineID FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim GetSPLCommand As New SqlCommand(GetSPLStatement, con)
        GetSPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetSPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = CurrentPartNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSPL = CStr(GetSPLCommand.ExecuteScalar)
        Catch ex As Exception
            GetSPL = ""
        End Try
        con.Close()
        '***************************************************************************************
        'Get last sales date from SO Line table
        Dim MAXDateStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID AND CustomerID = @CustomerID AND SalesOrderKey <> @SalesOrderKey"
        Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
        MAXDateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        MAXDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = CurrentPartNumber
        MAXDateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        MAXDateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = CurrentSalesOrderKey

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxDate = CInt(MAXDateCommand.ExecuteScalar)
        Catch ex As Exception
            MaxDate = 0
        End Try
        con.Close()

        Dim GetYearPricingDateStatement As String = "SELECT SalesOrderDate FROM SalesOrderLineQuery WHERE DivisionID = @DivisionID AND ItemID = @ItemID AND SalesOrderKey = @SalesOrderKey"
        Dim GetYearPricingDateCommand As New SqlCommand(GetYearPricingDateStatement, con)
        GetYearPricingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetYearPricingDateCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = CurrentPartNumber
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
        LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LastPriceCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = CurrentPartNumber
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
            AdjustedLastSalesPrice = LastSalesPrice

            Exit Sub
        Else
            '***************************************************************************************
            'Determine the Price Increase Bracket it is in
            Dim GetBracketNumberStatement As String = "SELECT CostTierNumber FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND @PriceDate BETWEEN BeginDate AND EndDate"
            Dim GetBracketNumberCommand As New SqlCommand(GetBracketNumberStatement, con)
            GetBracketNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                Case 2
                    'Increase price for 5 brackets (plus stainless)

                    'Get % for first bracket (Tier 2)
                    Dim GetPercentage2Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage2Command As New SqlCommand(GetPercentage2Statement, con)
                    GetPercentage2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                Case 3
                    'Increase price for FOUR brackets (plus stainless)

                    'Get % for first bracket (Tier 3)
                    Dim GetPercentage3Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage3Command As New SqlCommand(GetPercentage3Statement, con)
                    GetPercentage3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                Case 4
                    'Increase price for THREE brackets (Tier 4) plus stainless

                    'Get % for first bracket (Tier 4)
                    Dim GetPercentage4Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage4Command As New SqlCommand(GetPercentage4Statement, con)
                    GetPercentage4Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                Case 5
                    'Increase price for 2 bracketS (Tier 5) plus stainless

                    'Get % for first bracket (Tier 5)
                    Dim GetPercentage5Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage5Command As New SqlCommand(GetPercentage5Statement, con)
                    GetPercentage5Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                    GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                Case 6
                    'Increase price for 1 bracket (Tier 6)

                    'Get % for SIXTH bracket (Tier 6)
                    Dim GetPercentage6Statement As String = "SELECT PriceAdjustment FROM ItemPriceChangeTable WHERE DivisionID = @DivisionID AND PriceClass = @PriceClass AND CostTierNumber = @CostTierNumber"
                    Dim GetPercentage6Command As New SqlCommand(GetPercentage6Statement, con)
                    GetPercentage6Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                Case Else
                    'Pricing is current
                    AdjustedLastSalesPrice = LastSalesPrice
                    Exit Sub
            End Select
        End If
    End Sub

    Public Sub LoadDefaultShippingAddress()
        Dim ShipToAddress1String As String = "SELECT ShipAddress1 FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim ShipToAddress1Command As New SqlCommand(ShipToAddress1String, con)
        ShipToAddress1Command.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        ShipToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipToAddress2String As String = "SELECT ShipAddress2 FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim ShipToAddress2Command As New SqlCommand(ShipToAddress2String, con)
        ShipToAddress2Command.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        ShipToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipToCityString As String = "SELECT ShipCity FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim ShipToCityCommand As New SqlCommand(ShipToCityString, con)
        ShipToCityCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        ShipToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipToStateString As String = "SELECT ShipState FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim ShipToStateCommand As New SqlCommand(ShipToStateString, con)
        ShipToStateCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        ShipToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipToZipString As String = "SELECT ShipZipCode FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim ShipToZipCommand As New SqlCommand(ShipToZipString, con)
        ShipToZipCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        ShipToZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipToCountryString As String = "SELECT ShipCountry FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim ShipToCountryCommand As New SqlCommand(ShipToCountryString, con)
        ShipToCountryCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        ShipToCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipNameString As String = "SELECT ShipName FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim ShipNameCommand As New SqlCommand(ShipNameString, con)
        ShipNameCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        ShipNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboPODivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShipToAddress1 = CStr(ShipToAddress1Command.ExecuteScalar)
        Catch ex As Exception
            ShipToAddress1 = ""
        End Try
        Try
            ShipToAddress2 = CStr(ShipToAddress2Command.ExecuteScalar)
        Catch ex As Exception
            ShipToAddress2 = ""
        End Try
        Try
            ShipToCity = CStr(ShipToCityCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToCity = ""
        End Try
        Try
            ShipToState = CStr(ShipToStateCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToState = ""
        End Try
        Try
            ShipToZip = CStr(ShipToZipCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToZip = ""
        End Try
        Try
            ShipToCountry = CStr(ShipToCountryCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToCountry = ""
        End Try
        Try
            ShipToName = CStr(ShipNameCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToName = ""
        End Try
        con.Close()
    End Sub

    Public Sub LoadDivisionSONumber()
        Dim GetDivisionSONumberString As String = "SELECT DropShipSalesOrderNumber FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
        Dim GetDivisionSONumberCommand As New SqlCommand(GetDivisionSONumberString, con)
        GetDivisionSONumberCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
        GetDivisionSONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboPODivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetDivisionSONumber = CInt(GetDivisionSONumberCommand.ExecuteScalar)
        Catch ex As Exception
            GetDivisionSONumber = 0
        End Try
        con.Close()

        Dim ThirdPartyShipperString As String = "SELECT ThirdPartyShipper FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ThirdPartyShipperCommand As New SqlCommand(ThirdPartyShipperString, con)
        ThirdPartyShipperCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetDivisionSONumber
        ThirdPartyShipperCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboPODivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ThirdPartyShipper = CStr(ThirdPartyShipperCommand.ExecuteScalar)
        Catch ex As Exception
            ThirdPartyShipper = ""
        End Try
        con.Close()
    End Sub

    Public Sub LoadCountryCodeFromState()
        Dim GetCountryCodeFromStateString As String = "SELECT CountryCode FROM StateTable WHERE StateCode = @StateCode"
        Dim GetCountryCodeFromStateCommand As New SqlCommand(GetCountryCodeFromStateString, con)
        GetCountryCodeFromStateCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountryCodeFromState = CStr(GetCountryCodeFromStateCommand.ExecuteScalar)
        Catch ex As System.Exception
            CountryCodeFromState = ""
        End Try
        con.Close()
    End Sub

    Public Sub LoadSODataFromDivision()
        Dim ShipToNameString As String = "SELECT ShipToName FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToNameCommand As New SqlCommand(ShipToNameString, con)
        ShipToNameCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetDivisionSONumber
        ShipToNameCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipToAddress1String As String = "SELECT ShipToAddress1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToAddress1Command As New SqlCommand(ShipToAddress1String, con)
        ShipToAddress1Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetDivisionSONumber
        ShipToAddress1Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipToAddress2String As String = "SELECT ShipToAddress2 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToAddress2Command As New SqlCommand(ShipToAddress2String, con)
        ShipToAddress2Command.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetDivisionSONumber
        ShipToAddress2Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipToCityString As String = "SELECT ShipToCity FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToCityCommand As New SqlCommand(ShipToCityString, con)
        ShipToCityCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetDivisionSONumber
        ShipToCityCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipToStateString As String = "SELECT ShipToState FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToStateCommand As New SqlCommand(ShipToStateString, con)
        ShipToStateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetDivisionSONumber
        ShipToStateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipToZipString As String = "SELECT ShipToZip FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToZipCommand As New SqlCommand(ShipToZipString, con)
        ShipToZipCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetDivisionSONumber
        ShipToZipCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipToCountryString As String = "SELECT ShipToCountry FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipToCountryCommand As New SqlCommand(ShipToCountryString, con)
        ShipToCountryCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetDivisionSONumber
        ShipToCountryCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ThirdPartyShipperString As String = "SELECT ThirdPartyShipper FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ThirdPartyShipperCommand As New SqlCommand(ThirdPartyShipperString, con)
        ThirdPartyShipperCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetDivisionSONumber
        ThirdPartyShipperCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShipEmailString As String = "SELECT ShipEmail FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShipEmailCommand As New SqlCommand(ShipEmailString, con)
        ShipEmailCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetDivisionSONumber
        ShipEmailCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboPODivisionID.Text

        Dim ShippingAccountString As String = "SELECT ShippingAccount FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim ShippingAccountCommand As New SqlCommand(ShippingAccountString, con)
        ShippingAccountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetDivisionSONumber
        ShippingAccountCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboPODivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShipToName = CStr(ShipToNameCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToName = ""
        End Try
        Try
            ShipToAddress1 = CStr(ShipToAddress1Command.ExecuteScalar)
        Catch ex As Exception
            ShipToAddress1 = ""
        End Try
        Try
            ShipToAddress2 = CStr(ShipToAddress2Command.ExecuteScalar)
        Catch ex As Exception
            ShipToAddress2 = ""
        End Try
        Try
            ShipToCity = CStr(ShipToCityCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToCity = ""
        End Try
        Try
            ShipToState = CStr(ShipToStateCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToState = ""
        End Try
        Try
            ShipToZip = CStr(ShipToZipCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToZip = ""
        End Try
        Try
            ShipToCountry = CStr(ShipToCountryCommand.ExecuteScalar)
        Catch ex As Exception
            ShipToCountry = ""
        End Try
        Try
            ThirdPartyShipper = CStr(ThirdPartyShipperCommand.ExecuteScalar)
        Catch ex As Exception
            ThirdPartyShipper = ""
        End Try
        Try
            ShipEmail = CStr(ShipEmailCommand.ExecuteScalar)
        Catch ex As Exception
            ShipEmail = ""
        End Try
        Try
            ShippingAccount = CStr(ShippingAccountCommand.ExecuteScalar)
        Catch ex As Exception
            ShippingAccount = ""
        End Try
        con.Close()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cmdCreateOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateOrder.Click
        If Me.dgvPOLines.RowCount = 0 Then
            MsgBox("You must view the PO Lines in the datagrid first.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboCustomerID.Text = "" Or cboPONumber.Text = "" Then
            MsgBox("You must have a valid PO Number and Customer selected.", MsgBoxStyle.OkOnly)
        Else
            'Verify Part Numbers before creating order
            For Each row As DataGridViewRow In dgvPOLines.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectedColumn")
                If cell.Value = "SELECTED" Then
                    Dim VerifyPartNumber As String = ""
                    Dim VerifyPart As Integer = 0

                    Try
                        VerifyPartNumber = row.Cells("PartNumberColumn").Value
                    Catch ex As Exception
                        VerifyPartNumber = ""
                    End Try

                    Dim VerifyPartString As String = "SELECT COUNT(ItemID) FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim VerifyPartCommand As New SqlCommand(VerifyPartString, con)
                    VerifyPartCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = VerifyPartNumber
                    VerifyPartCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        VerifyPart = CInt(VerifyPartCommand.ExecuteScalar)
                    Catch ex As Exception
                        VerifyPart = 0
                    End Try
                    con.Close()
                    '**********************************************************************************
                    If VerifyPart = 0 Then 'Add part number to division
                        MsgBox("This is not a valid Truweld Part Number. Contact division and have them correct the PO.", MsgBoxStyle.OkOnly)

                        txtInvalidPart.Text = VerifyPartNumber
                        gpxInvalidPart.Visible = True
                        Exit Sub
                    Else
                        'Skip - do nothing
                    End If
                Else
                    'Skip entry - row is unchecked.
                End If
            Next
            '**********************************************************************************
            'Load PO Data
            LoadPOData()
            '**********************************************************************************
            'Load Customer Data
            LoadCustomerData()

            If GetDivisionSONumber = 0 Then
                'If no sales order, third party shipper is blank
                ThirdPartyShipper = ""
            Else
                LoadSODataFromDivision()
            End If
            '**********************************************************************************
            'Load SO Data from PO
            LoadDefaultShippingAddress()

            If ShipToCountry = "" Then
                Dim GetShipToCountry As String = ""

                'Get ShipToCountry from the Customer
                Dim GetShipToCountryString As String = "SELECT ShipToCountry FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
                Dim GetShipToCountryCommand As New SqlCommand(GetShipToCountryString, con)
                GetShipToCountryCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GetDivisionSONumber
                GetShipToCountryCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboPODivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetShipToCountry = CStr(GetShipToCountryCommand.ExecuteScalar)
                Catch ex As Exception
                    GetShipToCountry = ""
                End Try
                con.Close()

                ShipToCountry = GetShipToCountry
            End If
            '**********************************************************************************
            'Get PO Data to write to Sales Order
            Dim GetAddShipTo As String = ""

            Dim GetAddShipToString As String = "SELECT POAdditionalShipTo FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID"
            Dim GetAddShipToCommand As New SqlCommand(GetAddShipToString, con)
            GetAddShipToCommand.Parameters.Add("@PurchaseOrderHeaderTable", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
            GetAddShipToCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboPODivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetAddShipTo = CStr(GetAddShipToCommand.ExecuteScalar)
            Catch ex As Exception
                GetAddShipTo = ""
            End Try
            con.Close()
            '************************************************************************************
            If cboDivisionID.Text = "TWD" Then
                FOB = "Medina"
            Else
                FOB = "STANDARD"
            End If
            '**********************************************************************************
            'Verify Country Code exists for the ship to address
            If ShipToCountry = "" And ShipToState <> "" Then
                StateCode = ShipToState
                LoadCountryCodeFromState()

                ShipToCountry = CountryCodeFromState
            End If
            '******************************************************************************************************

            '******************************************************************************************************
            'Create Sales Order Header
            Dim MAXStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderHeaderTable"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As Exception
                LastTransactionNumber = 500000
            End Try
            con.Close()

            NextTransactionNumber = LastTransactionNumber + 1
            GlobalSONumber = NextTransactionNumber
            CurrentSalesOrderKey = NextTransactionNumber
            '**********************************************************************************
            Try
                'Write Data to Sales Order Header Database Table
                cmd = New SqlCommand("Insert Into SalesOrderHeaderTable(SalesOrderKey, SalesOrderDate, CustomerID, CustomerPO, CustomerPOType, SalesPerson, DivisionKey, ShipVia, ShippingDate, HeaderComment, PRONumber, FreightCharge, TotalSalesTax, ProductTotal, SOTotal, SOStatus, AdditionalShipTo, QuoteNumber, QuotedFreight, ShippingWeight, SpecialInstructions, DropShipPONumber, TotalSalesTax2, TotalSalesTax3, TaxOnFreight, TotalEstCOS, TaxRate1, TaxRate2, TaxRate3, Locked, FOB, CustomerClass, ShippingMethod, ThirdPartyShipper, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, ShipEmail, ShippingAccount, SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3, SalesOrderType, WorkOrderNumber)Values(@SalesOrderKey, @SalesOrderDate, @CustomerID, @CustomerPO, @CustomerPOType, @SalesPerson, @DivisionKey, @ShipVia, @ShippingDate, @HeaderComment, @PRONumber, @FreightCharge, @TotalSalesTax, @ProductTotal, @SOTotal, @SOStatus, @AdditionalShipTo, @QuoteNumber, @QuotedFreight, @ShippingWeight, @SpecialInstructions, @DropShipPONumber, @TotalSalesTax2, @TotalSalesTax3, @TaxOnFreight, @TotalEstCOS, @TaxRate1, @TaxRate2, @TaxRate3, @Locked, @FOB, @CustomerClass, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @ShipEmail, @ShippingAccount, @SpecialLabelLine1, @SpecialLabelLine2, @SpecialLabelLine3, @SalesOrderType, @WorkOrderNumber)", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                    .Add("@SalesOrderDate", SqlDbType.VarChar).Value = dtpOrderDate.Text
                    .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                    .Add("@CustomerPO", SqlDbType.VarChar).Value = cboPODivisionID.Text & cboPONumber.Text
                    .Add("@CustomerPOType", SqlDbType.VarChar).Value = ""
                    .Add("@SalesPerson", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                    .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ShipVia", SqlDbType.VarChar).Value = ShipMethodID
                    .Add("@ShippingDate", SqlDbType.VarChar).Value = ShipDate
                    .Add("@HeaderComment", SqlDbType.VarChar).Value = POHeaderComment
                    .Add("@PRONumber", SqlDbType.VarChar).Value = ""
                    .Add("@FreightCharge", SqlDbType.VarChar).Value = 0
                    .Add("@TotalSalesTax", SqlDbType.VarChar).Value = 0
                    .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = 0
                    .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = 0
                    .Add("@TaxOnFreight", SqlDbType.VarChar).Value = 0
                    .Add("@TotalEstCOS", SqlDbType.VarChar).Value = POProductTotal
                    .Add("@TaxRate1", SqlDbType.VarChar).Value = 0
                    .Add("@TaxRate2", SqlDbType.VarChar).Value = 0
                    .Add("@TaxRate3", SqlDbType.VarChar).Value = 0
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                    .Add("@SOTotal", SqlDbType.VarChar).Value = 0
                    .Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = GetAddShipTo
                    .Add("@QuoteNumber", SqlDbType.VarChar).Value = ""
                    .Add("@QuotedFreight", SqlDbType.VarChar).Value = 0
                    .Add("@ShippingWeight", SqlDbType.VarChar).Value = 0
                    .Add("@SpecialInstructions", SqlDbType.VarChar).Value = SpecialInstructions
                    .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                    .Add("@Locked", SqlDbType.VarChar).Value = ""
                    .Add("@FOB", SqlDbType.VarChar).Value = FOB
                    .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                    .Add("@ShippingMethod", SqlDbType.VarChar).Value = ShipMethod
                    .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ThirdPartyShipper
                    .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
                    .Add("@ShipToAddress1", SqlDbType.VarChar).Value = ShipToAddress1
                    .Add("@ShipToAddress2", SqlDbType.VarChar).Value = ShipToAddress2
                    .Add("@ShipToCity", SqlDbType.VarChar).Value = ShipToCity
                    .Add("@ShipToState", SqlDbType.VarChar).Value = ShipToState
                    .Add("@ShipToZip", SqlDbType.VarChar).Value = ShipToZip
                    .Add("@ShipToCountry", SqlDbType.VarChar).Value = ShipToCountry
                    .Add("@ShipEmail", SqlDbType.VarChar).Value = ShipEmail
                    .Add("@ShippingAccount", SqlDbType.VarChar).Value = ShippingAccount
                    .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = ""
                    .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = ""
                    .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = ""
                    .Add("@SalesOrderType", SqlDbType.VarChar).Value = "SO"
                    .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = 0
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempSONumber As Integer = 0
                Dim strSONumber As String
                TempSONumber = NextTransactionNumber
                strSONumber = CStr(TempSONumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Create SO From PO --- Insert Failure"
                ErrorReferenceNumber = "SO # " + strSONumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("You cannot create a Sales Order at this time. Contact system admin.", MsgBoxStyle.OkOnly)
                Exit Sub
            End Try
            '**********************************************************************************
            'Get Sales Order Line data from PO Line Table
            For Each row As DataGridViewRow In dgvPOLines.Rows
                Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectedColumn")
                If cell.Value = "SELECTED" Then
                    Try
                        PartNumber = row.Cells("PartNumberColumn").Value
                    Catch ex As Exception
                        PartNumber = ""
                    End Try
                    Try
                        PartDescription = row.Cells("PartDescriptionColumn").Value
                    Catch ex As Exception
                        PartDescription = ""
                    End Try
                    Try
                        OrderQuantity = row.Cells("OrderQuantityColumn").Value
                    Catch ex As Exception
                        OrderQuantity = 0
                    End Try
                    Try
                        LineComment = row.Cells("LineCommentColumn").Value
                    Catch ex As Exception
                        LineComment = ""
                    End Try
                    Try
                        UnitCost = row.Cells("UnitCostColumn").Value
                    Catch ex As Exception
                        UnitCost = 0
                    End Try
                    '**********************************************************************************
                    'Get Item Data from part number
                    Dim PieceWeightString As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim PieceWeightCommand As New SqlCommand(PieceWeightString, con)
                    PieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    PieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim ItemClassString As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim ItemClassCommand As New SqlCommand(ItemClassString, con)
                    ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim BoxCountString As String = "SELECT BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim BoxCountCommand As New SqlCommand(BoxCountString, con)
                    BoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    BoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim CertificationTypeString As String = "SELECT CertificationType FROM FOXTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                    Dim CertificationTypeCommand As New SqlCommand(CertificationTypeString, con)
                    CertificationTypeCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    CertificationTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        PieceWeight = CDbl(PieceWeightCommand.ExecuteScalar)
                    Catch ex As Exception
                        PieceWeight = 0
                    End Try
                    Try
                        ItemClass = CStr(ItemClassCommand.ExecuteScalar)
                    Catch ex As Exception
                        ItemClass = "TW CA"
                    End Try
                    Try
                        BoxCount = CDbl(BoxCountCommand.ExecuteScalar)
                    Catch ex As Exception
                        BoxCount = 0
                    End Try
                    Try
                        CertificationType = CStr(CertificationTypeCommand.ExecuteScalar)
                    Catch ex As Exception
                        CertificationType = "0"
                    End Try
                    con.Close()

                    If CertificationType = "" Then
                        Select Case ItemClass
                            Case "TW DS"
                                CertificationType = "1"
                            Case "TW CA"
                                CertificationType = "1"
                            Case "TW SC"
                                CertificationType = "1"
                            Case "TW DB"
                                CertificationType = "2"
                            Case "TW TT"
                                CertificationType = "6"
                            Case "TW TP"
                                CertificationType = "6"
                            Case "TW CS"
                                CertificationType = "6"
                            Case "TW NT"
                                CertificationType = "6"
                            Case "TW PS"
                                CertificationType = "1"
                            Case "TW SWR"
                                CertificationType = "17"
                            Case "TW GS"
                                CertificationType = "7"
                            Case "TW HX"
                                CertificationType = "19"
                            Case "TW HSR"
                                CertificationType = "21"
                            Case Else
                                CertificationType = "0"
                        End Select
                    Else
                        'Do nothing
                    End If
                    '**********************************************************************************
                    'Get Inventory Account for Item Class
                    Dim InventoryAccountString As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                    Dim InventoryAccountCommand As New SqlCommand(InventoryAccountString, con)
                    InventoryAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        InventoryAccount = CStr(InventoryAccountCommand.ExecuteScalar)
                    Catch ex As Exception
                        InventoryAccount = "12100"
                    End Try
                    con.Close()
                    '**********************************************************************************
                    If cboDivisionID.Text = "TWD" Then
                        Try
                            'Get actual last price from SO Table
                            CurrentPartNumber = PartNumber

                            LoadLastSalesPriceTWDRevised()

                            UpdatedLastSalesPrice = AdjustedLastSalesPrice
                        Catch ex As Exception
                            UpdatedLastSalesPrice = 0
                        End Try
                    Else
                        'Get last sales price
                        Try
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

                            Dim MAXDateStatement As String = "SELECT MAX(InvoiceHeaderKey) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND CustomerID = @CustomerID"
                            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
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
                            GetYearPricingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            GetYearPricingDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
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
                            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            LastPriceCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = MaxDate

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LastCustomerPrice = CDbl(LastPriceCommand.ExecuteScalar)
                            Catch ex As Exception
                                LastCustomerPrice = 0
                            End Try
                            con.Close()

                            If GetYearPricingDate < GlobalTWDPriceChangeDate And cboDivisionID.Text = "TWD" And PriceIncreaseItem = "5PERCENT" Then
                                UpdatedLastSalesPrice = LastCustomerPrice * GlobalPriceChangeMultiplierTWD
                            ElseIf GetYearPricingDate < GlobalTWDPriceChangeDate And cboDivisionID.Text = "SLC" And PriceIncreaseItem = "5PERCENT" Then
                                UpdatedLastSalesPrice = LastCustomerPrice * GlobalPriceChangeMultiplierTWD
                            ElseIf GetYearPricingDate < GlobalSLCPriceChangeDate And cboDivisionID.Text = "SLC" And PriceIncreaseItem = "12PERCENT" Then
                                UpdatedLastSalesPrice = LastCustomerPrice * GlobalPriceChangeMultiplierSLC
                            ElseIf GetYearPricingDate < GlobalTWEPriceChangeDate And cboDivisionID.Text = "TWE" And PriceIncreaseItem = "5PERCENT" Then
                                UpdatedLastSalesPrice = LastCustomerPrice * GlobalPriceChangeMultiplierTWE
                            Else
                                UpdatedLastSalesPrice = LastCustomerPrice
                            End If
                        Catch ex As Exception
                            UpdatedLastSalesPrice = 0
                        End Try
                    End If
                    '**********************************************************************************
                    'Avoid "Divide by 0 error"
                    If BoxCount = 0 Then
                        LineBoxes = 0
                    Else
                        LineBoxes = OrderQuantity / BoxCount
                    End If

                    'Round Boxes to next highest number
                    UpdatedLineBoxCount = Math.Ceiling(LineBoxes)
                    '**********************************************************************************
                    'Get box weight and box count for line
                    Dim BoxWeight As Double = 0
                    Dim NewBoxCount As Integer = 0

                    Dim BoxWeightStatement As String = "SELECT BoxWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim BoxWeightCommand As New SqlCommand(BoxWeightStatement, con)
                    BoxWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    BoxWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                    Dim NewBoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim NewBoxCountCommand As New SqlCommand(NewBoxCountStatement, con)
                    NewBoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                    NewBoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                    If con.State = ConnectionState.Closed Then con.Open()
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
                        LineWeight = OrderQuantity * PieceWeight
                    Else
                        LineWeight = (OrderQuantity / NewBoxCount) * BoxWeight
                    End If
                    '***************************************************************************************
                    'Calculate Line Totals
                    ExtendedAmount = UpdatedLastSalesPrice * OrderQuantity
                    ExtendedCost = OrderQuantity * UnitCost

                    ExtendedCost = Math.Round(ExtendedCost, 2)
                    UpdatedLastSalesPrice = Math.Round(UpdatedLastSalesPrice, 5)
                    ExtendedAmount = Math.Round(ExtendedAmount, 2)
                    LineWeight = Math.Round(LineWeight, 2)

                    'Get Next Line Number
                    'Commands to Generate new line number for entries
                    Dim MAXLineStatement As String = "SELECT MAX(SalesOrderLineKey) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey"
                    Dim MAXLineCommand As New SqlCommand(MAXLineStatement, con)
                    MAXLineCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = NextTransactionNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastLineNumber = CInt(MAXLineCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastLineNumber = 0
                    End Try
                    con.Close()

                    NextLineNumber = LastLineNumber + 1

                    'Write to SO Line Table
                    Try
                        cmd = New SqlCommand("Insert Into SalesOrderLineTable(SalesOrderKey, SalesOrderLineKey, ItemID, Description, Quantity, Price, LineComment, SalesTax, DivisionID, ExtendedAmount, LineWeight, LineBoxes, LineStatus, DebitGLAccount, CreditGLAccount, LeadTime, CertificationType, EstExtendedCOS, ShippedPrevious)Values(@SalesOrderKey, @SalesOrderLineKey, @ItemID, @Description, @Quantity, @Price, @LineComment, @SalesTax, @DivisionID, @ExtendedAmount, @LineWeight, @LineBoxes, @LineStatus, @DebitGLAccount, @CreditGLAccount, @LeadTime, @CertificationType, @EstExtendedCOS, @ShippedPrevious)", con)

                        With cmd.Parameters
                            .Add("@SalesOrderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = NextLineNumber
                            .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            .Add("@Description", SqlDbType.VarChar).Value = PartDescription
                            .Add("@Quantity", SqlDbType.VarChar).Value = OrderQuantity
                            .Add("@Price", SqlDbType.VarChar).Value = UpdatedLastSalesPrice
                            .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                            .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                            .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeight
                            .Add("@LineBoxes", SqlDbType.VarChar).Value = UpdatedLineBoxCount
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "49999"
                            .Add("@CreditGLAccount", SqlDbType.VarChar).Value = InventoryAccount
                            .Add("@LeadTime", SqlDbType.VarChar).Value = "  /  /"
                            .Add("@CertificationType", SqlDbType.VarChar).Value = CertificationType
                            .Add("@EstExtendedCOS", SqlDbType.VarChar).Value = ExtendedCost
                            .Add("@ShippedPrevious", SqlDbType.VarChar).Value = 0
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip Line
                    End Try

                    UpdatedLastSalesPrice = 0
                    OrderQuantity = 0
                    ExtendedAmount = 0
                    PartNumber = ""
                    PartDescription = ""
                    LineComment = ""
                    LineWeight = 0
                    UpdatedLineBoxCount = 0
                    InventoryAccount = ""
                    CertificationType = ""
                    ExtendedCost = 0
                Else
                    'Skip row - box is unchecked
                End If
            Next

            'Update Sales Order Totals
            LoadSOTotals()

            'UPDATE Header Table based on line amounts
            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET ProductTotal = @ProductTotal, TotalSalesTax = @TotalSalesTax, TotalSalesTax2 = @TotalSalesTax2, TotalSalesTax3 = @TotalSalesTax3, FreightCharge = @FreightCharge, SOTotal = @SOTotal, ShippingWeight = @ShippingWeight, TotalEstCOS = @TotalEstCOS WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber
                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = SOProductTotal
                .Add("@TotalSalesTax", SqlDbType.VarChar).Value = 0
                .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = 0
                .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = 0
                .Add("@FreightCharge", SqlDbType.VarChar).Value = 0
                .Add("@SOTotal", SqlDbType.VarChar).Value = SOTotal
                .Add("@ShippingWeight", SqlDbType.VarChar).Value = TotalWeight
                .Add("@TotalEstCOS", SqlDbType.VarChar).Value = POProductTotal
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Close current form and open Sales Order Form
            Dim NewSOForm As New SOForm
            NewSOForm.Show()

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub cmdPOForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPO.Click
        GlobalDivisionCode = cboPODivisionID.Text
        GlobalPONumber = Val(cboPONumber.Text)

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
                Dim Result = NewPrintPurchaseOrderRemote.ShowDialog()
            End Using
        Else
            Using NewPrintPurchaseOrder As New PrintPurchaseOrder
                Dim Result = NewPrintPurchaseOrder.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClearPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearPO.Click
        cboPONumber.Text = ""
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboPODivisionID.Text = ""

        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboPODivisionID.SelectedIndex = -1
        cboPONumber.SelectedIndex = -1
    End Sub

    Private Sub cboPONumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPONumber.SelectedIndexChanged
        LoadDivisionSONumber()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each row As DataGridViewRow In dgvPOLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectedColumn")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdUnselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnselectAll.Click
        For Each row As DataGridViewRow In dgvPOLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectedColumn")
            cell.Value = "UNSELECTED"
        Next
    End Sub
End Class