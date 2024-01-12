Imports System
Imports System.Math
Imports System.Net.Mail
Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Public Class ShipmentCompletion
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Async=True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmdNoCert As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapterNoCert As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, CertDataset, NoCertDataset As DataSet
    Dim dt As DataTable

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer

    Dim FormName As String = "Shipment Completion"
    Dim LoadShipFromPick, MaxDate, CountSOLines, SOLineNumber, NextShippingNumber, ConsignmentShipNumber, BatchNumber, NextLotLineNumber, LastLotLineNumber As Integer
    Dim ShipEmail, ShippingAccount, SerializedPart, ShipMethod, ThirdPartyShipper, SpecialInstructions, SalesmanID, ItemClass, PurchaseProductLineID, LineStatus, GLDebitAccount, CustomerClass, LotPartNumber, Comment, ShipVia, PRONumber, FreightQuoteNumber, CustomerID, ShipToID, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZip, ShipCountry, ShipName, CustomerPO, SOShipmentStatus, SOHeaderStatus As String
    Dim ShipmentNumber, SalesOrderKey, PickTicketNumber, NumberOfPallets, NumberOfDoublePallets, NumberOfPalletsOnFloor, VerifyStatus As Integer
    Dim ReloadLineWeight, StandardCost, Tax2Total, Tax3Total, LastPurchaseCost, ProductTotal2, AddedFreight, ActualFreight, FreightCharges, FreightQuoteAmount, FreightActualAmount, ShippingWeight, ProductTotal, TaxTotal, ShipmentTotal As Double
    Dim PartQOH, GetHSTRate, GetPSTRate, GetGSTRate, SOOrderQuantity, SOQuantityShipped As Double
    Dim ShipDate As Date
    Dim AutoAddFreight As String = ""
    Dim CheckShippingMethod As String = ""
    Dim ShipToName As String = ""
    Dim GetSOShipToName As String = ""
    Dim GetCustomerShipToName As String = ""
    Dim AssemblySerialNumber As String = ""
    Dim AssemblyPartNumber As String = ""
    Dim AssemblyDivisionID As String = ""
    Dim RunningSerialQuantity As Integer = 0

    Dim SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3 As String

    'Variables for GL Posting
    Dim TempShipLine, ShipLine, CountShipLines, NextInventoryTransactionNumber, LastInventoryTransactionNumber As Integer
    Dim TransactionCost, SumLineWeight, SumExtendedAmount, SumSalesTax, TotalEstimatedWeight, TotalPalletWeight, FIFOCost, FIFOExtendedAmount As Double
    Const PalletWeight As Double = 34.0

    'Variables for Grid Changes
    Dim PieceWeight, QuantityShipped As Double
    Dim BoxCount, ShipmentLineNumber As Integer
    Dim LineComment, PartNumber As String

    'Variables for Complete Shipment Routine
    Dim SOLineKey, ItemBoxCount, SOLineBoxes As Integer
    Dim SOQuantityShippedPending, QuantityOrdered, TotalQuantityShipped, ExtendedCOS, SOExtendedAmount, ItemPieceWeight, SOLineWeight, SOSalesTax, SOSalesTaxRate, SalesTaxOrdered, SUMSOSalesTax, SUMSOExtendedAmount, SUMSOLineWeight, HeaderFreightTotal, SOHeaderTotal As Double

    'Variables for Pull Test Data
    Dim PartNominalLength, PartNominalDiameter As Double
    Dim GetVendor, GetVendorClass, PartHeatNumber, LotItemClass, PartItemClass As String
    Dim CheckShipmentQuantity As Double
    Dim CheckPartNumber, LineStockStatus, SerialNumber As String

    'Variable for third party billing
    Dim BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToName As String

    'Variables for creating PO (CHT Only)
    Dim LastPONumber, NextPONumber As Integer
    Dim strPONumber As String = ""

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""
    Dim TodaysDate As Date = Now()

    Dim ttPrintBoxLabel As New ToolTip
    Dim ttViewLotNumbers As New ToolTip

    Dim PTUpload As PickTicketScannerUploadAPI
    Dim CertReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup for barcode
    Dim bc As New BarcodeLabel
    Dim LabelFormat(70), V00, V01, V02, V03, V04, V05, V06, V07, V08, V09, V10, V11, V12, V13, V14, V15, V16, V17, V18, V19, V20, V21, V22, V23, V24, V25, V26, V27, V28, VDATA, VDATA1, VBAR, VBAR1 As String
    Dim LabelLines, BarCodeType, NumberOfLabels As Integer

    'Form Operations

    Private Sub ShipmentCompletion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()

        'Form Login
        FormLoginRoutine()

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)

        'Defaults for scanning
        If My.Computer.Name.StartsWith("TFP") Then
            cmdRemoteScan.Visible = True
            cmdUploadPickTicket.Visible = False
            cmdViewPickTicket.Visible = False
            ReUploadPickTicketToolStripMenuItem.Enabled = False
            AppendUploadedPickTicketToolStripMenuItem.Enabled = False
            UploadPickTicketToolStripMenuItem.Visible = True
        Else
            cmdRemoteScan.Visible = False
            cmdUploadPickTicket.Visible = True
            cmdViewPickTicket.Visible = False
            UploadPickTicketToolStripMenuItem.Visible = False
        End If

        Select Case EmployeeCompanyCode
            Case "TWD", "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                ds10 = New DataSet()
                myAdapter10.SelectCommand = cmd
                myAdapter10.Fill(ds10, "DivisionTable")
                cboDivisionID.DataSource = ds10.Tables("DivisionTable")
                con.Close()

                dgvShipmentLines.Columns("BoxWeightColumn").Visible = True

                cboDivisionID.Enabled = True
                cboDivisionID.Text = EmployeeCompanyCode

                dtpShipmentDate.Format = DateTimePickerFormat.Short

                tabAddSubLines.SelectedIndex = 0

                Me.dgvShipmentLines.Columns("CompleteLineColumn").Visible = True
                cboPickTicketNumber.TabIndex = 0

                Me.SendFedExEmailForDailyShipmentsToolStripMenuItem.Enabled = True

                cmdPrintBoxLabel.Visible = False
            Case "TWE", "TST"
                'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
                Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

                dgvShipmentLines.Columns("BoxWeightColumn").Visible = False

                cboDivisionID.Enabled = False
                cboDivisionID.Text = EmployeeCompanyCode

                dtpShipmentDate.Format = DateTimePickerFormat.Short

                tabAddSubLines.SelectedIndex = 1

                Me.dgvShipmentLines.Columns("CompleteLineColumn").Visible = False
                cboShipmentNumber.TabIndex = 0

                Me.SendFedExEmailForDailyShipmentsToolStripMenuItem.Enabled = False


                cmdPrintBoxLabel.Visible = True
            Case "ADM"
                'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
                Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

                dgvShipmentLines.Columns("BoxWeightColumn").Visible = False

                cboDivisionID.Enabled = True
                cboDivisionID.Text = EmployeeCompanyCode

                dtpShipmentDate.Format = DateTimePickerFormat.Short

                tabAddSubLines.SelectedIndex = 0

                Me.dgvShipmentLines.Columns("CompleteLineColumn").Visible = False
                cboShipmentNumber.TabIndex = 0

                Me.SendFedExEmailForDailyShipmentsToolStripMenuItem.Enabled = True

                cmdPrintBoxLabel.Visible = True
            Case "TFF", "TOR", "ALB"
                'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
                Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

                dgvShipmentLines.Columns("BoxWeightColumn").Visible = False

                cboDivisionID.Enabled = False
                cboDivisionID.Text = EmployeeCompanyCode

                tabShipDetails.SelectedIndex = 1

                tabAddSubLines.SelectedIndex = 0

                Me.dgvShipmentLines.Columns("CompleteLineColumn").Visible = False
                cboShipmentNumber.TabIndex = 0

                Me.SendFedExEmailForDailyShipmentsToolStripMenuItem.Enabled = False

                cmdPrintBoxLabel.Visible = True
            Case Else
                'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
                Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

                dgvShipmentLines.Columns("BoxWeightColumn").Visible = False

                cboDivisionID.Enabled = False
                cboDivisionID.Text = EmployeeCompanyCode

                dtpShipmentDate.Format = DateTimePickerFormat.Short

                tabAddSubLines.SelectedIndex = 0

                Me.dgvShipmentLines.Columns("CompleteLineColumn").Visible = False
                cboShipmentNumber.TabIndex = 0

                Me.SendFedExEmailForDailyShipmentsToolStripMenuItem.Enabled = False

                cmdPrintBoxLabel.Visible = True
        End Select

        If GlobalSOShipmentNumber = 0 Or GlobalSOPickNumber = 0 Then
            cboShipmentNumber.SelectedIndex = -1
            cboPickTicketNumber.SelectedIndex = -1
        Else
            cboShipmentNumber.Text = GlobalSOShipmentNumber
            cboPickTicketNumber.Text = GlobalSOPickNumber
        End If

        If cboShipmentNumber.Text = "" Or Val(cboShipmentNumber.Text) = 0 Then
            ClearVariables()
            ClearAllData()

            cboPickTicketNumber.SelectedIndex = -1
            cboShipmentNumber.SelectedIndex = -1
            cboLinePartNumber.SelectedIndex = -1
            cboLotPartDescription.SelectedIndex = -1
            cboShipmentLineNumber.SelectedIndex = -1
        Else
            'Do nothing
        End If

        'Set Tool Tips
        ttPrintBoxLabel.SetToolTip(cmdPrintBoxLabel, "Print Partial Box Label")
        ttViewLotNumbers.SetToolTip(llViewLotNumbers, "Click to view lot numbers.")

        'Set permission to reset if needed
        If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Or EmployeeLoginName = "KVONDUYKE" Then
            ResetShipmentForCompletionToolStripMenuItem.Enabled = True
        Else
            ResetShipmentForCompletionToolStripMenuItem.Enabled = False
        End If

        PTUpload = New PickTicketScannerUploadAPI(cmdUploadPickTicket, cboShipmentNumber, ReUploadPickTicketToolStripMenuItem, Me, AppendUploadedPickTicketToolStripMenuItem)
    End Sub

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), &HF060, 1)
            Case &HFFFFFFFF
        End Select
    End Sub

    Private Sub ShipmentCompletion_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    'Load Datasets for controls and datagrids

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID AND LineStatus = @LineStatus ORDER BY ShipmentLineNumber ASC", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentLineTable")
        dgvShipmentLines.DataSource = ds.Tables("ShipmentLineTable")
        cboLinePartNumber.DataSource = ds.Tables("ShipmentLineTable")
        cboLotPartDescription.DataSource = ds.Tables("ShipmentLineTable")
        cboShipmentLineNumber.DataSource = ds.Tables("ShipmentLineTable")
        cboShipmentLineNumber2.DataSource = ds.Tables("ShipmentLineTable")
        con.Close()

        If cboShipmentNumber.Text = "" Or Val(cboShipmentNumber.Text) = 0 Then
            cboPickTicketNumber.SelectedIndex = -1
            cboShipmentNumber.SelectedIndex = -1
            cboLinePartNumber.SelectedIndex = -1
            cboLotPartDescription.SelectedIndex = -1
            cboShipmentLineNumber.SelectedIndex = -1
        Else
            'Do nothing
        End If
    End Sub

    Public Sub ClearShipmentLines()
        dgvShipmentLines.DataSource = Nothing
    End Sub

    Public Sub LoadAdditionalShipTo()
        cmd = New SqlCommand("SELECT ShipToID FROM AdditionalShipTo WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "AdditionalShipTo")
        cboAdditionalShipTo.DataSource = ds2.Tables("AdditionalShipTo")
        con.Close()
        cboAdditionalShipTo.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        cmd = New SqlCommand("SELECT ShipmentNumber, PickTicketNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID AND ShipmentStatus = @ShipmentStatus ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ShipmentHeaderTable")
        cboShipmentNumber.DataSource = ds3.Tables("ShipmentHeaderTable")
        cboPickTicketNumber.DataSource = ds3.Tables("ShipmentHeaderTable")
        con.Close()
        cboShipmentNumber.SelectedIndex = -1
        cboPickTicketNumber.SelectedIndex = -1
    End Sub

    Public Sub ShowLotNumbers()
        cmd = New SqlCommand("SELECT * FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ShipmentLineLotNumbers")
        dgvAddedLotNumbers.DataSource = ds5.Tables("ShipmentLineLotNumbers")
        con.Close()
    End Sub

    Public Sub ClearLotNumbers()
        dgvAddedLotNumbers.DataSource = Nothing
    End Sub

    Public Sub ShowOpenOrders()
        cmd = New SqlCommand("SELECT * FROM SalesOrderLineQueryNoQOH WHERE CustomerID = @CustomerID AND DivisionKey = @DivisionKey AND LineStatus = @LineStatus", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "SalesOrderLineQueryNoQOH")
        dgvOpenOrderLines.DataSource = ds6.Tables("SalesOrderLineQueryNoQOH")
        con.Close()

        If dgvOpenOrderLines.RowCount > 0 Then
            tabCustomerOrders.ForeColor = Color.Black
        Else
            tabCustomerOrders.ForeColor = Color.Black
        End If
    End Sub

    Public Sub ClearOpenOrders()
        dgvOpenOrderLines.DataSource = Nothing
    End Sub

    Public Sub ShowSerialNumbers()
        cmd = New SqlCommand("SELECT * FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "ShipmentLineSerialNumbers")
        dgvSerialLog.DataSource = ds7.Tables("ShipmentLineSerialNumbers")
        con.Close()
        Try
            cboShipmentLineNumber2.Text = 1
        Catch ex As Exception
            cboShipmentLineNumber2.SelectedIndex = -1
        End Try
    End Sub

    Public Sub ClearSerialNumbers()
        dgvSerialLog.DataSource = Nothing
    End Sub

    Public Sub LoadShipToCountry()
        cmd = New SqlCommand("SELECT Country FROM CountryCodes", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "CountryCodes")
        cboSTCountryName.DataSource = ds8.Tables("CountryCodes")
        con.Close()
        cboSTCountryName.SelectedIndex = -1
    End Sub

    'Load Data Subroutines

    Public Sub LoadCustomerData()
        Dim GetCustomerAddressStatement As String = "SELECT ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, CustomerClass FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetCustomerAddressCommand As New SqlCommand(GetCustomerAddressStatement, con)
        GetCustomerAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        GetCustomerAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetCustomerAddressCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
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
                ShipZip = ""
            Else
                ShipZip = reader.Item("ShipToZip")
            End If
            If IsDBNull(reader.Item("ShipToCountry")) Then
                ShipCountry = ""
            Else
                ShipCountry = reader.Item("ShipToCountry")
            End If
            If IsDBNull(reader.Item("CustomerClass")) Then
                If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Then
                    CustomerClass = "CANADIAN"
                Else
                    CustomerClass = "STANDARD"
                End If
            Else
                CustomerClass = reader.Item("CustomerClass")
            End If
        Else
            ShipAddress1 = ""
            ShipAddress2 = ""
            ShipCity = ""
            ShipState = ""
            ShipZip = ""
            ShipCountry = ""
            If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Then
                CustomerClass = "CANADIAN"
            Else
                CustomerClass = "STANDARD"
            End If
        End If
        reader.Close()
        con.Close()

        txtShippingAddress1.Text = ShipAddress1
        txtShippingAddress2.Text = ShipAddress2
        txtShippingCity.Text = ShipCity
        txtShippingCountry.Text = ShipCountry
        txtShippingZip.Text = ShipZip
        txtCustomerClass.Text = CustomerClass
        cboShippingState.Text = ShipState
    End Sub

    Public Sub LoadAdditionalShipToData()
        Dim GetAddShipToStatement As String = "SELECT Address1, Address2, City, State, Zip, Country, Name FROM AdditionalShipTo WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID"
        Dim GetAddShipToCommand As New SqlCommand(GetAddShipToStatement, con)
        GetAddShipToCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text
        GetAddShipToCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetAddShipToCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
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
                ShipZip = ""
            Else
                ShipZip = reader.Item("Zip")
            End If
            If IsDBNull(reader.Item("Country")) Then
                ShipCountry = ""
            Else
                ShipCountry = reader.Item("Country")
            End If
            If IsDBNull(reader.Item("Name")) Then
                ShipName = ""
            Else
                ShipName = reader.Item("Name")
            End If
        Else
            ShipAddress1 = ""
            ShipAddress2 = ""
            ShipCity = ""
            ShipState = ""
            ShipZip = ""
            ShipCountry = ""
            ShipName = ""
        End If
        reader.Close()
        con.Close()

        txtShippingAddress1.Text = ShipAddress1
        txtShippingAddress2.Text = ShipAddress2
        txtShippingCity.Text = ShipCity
        txtShippingCountry.Text = ShipCountry
        txtShippingZip.Text = ShipZip
        cboShippingState.Text = ShipState
        txtShipToName.Text = ShipName
    End Sub

    Public Sub LoadShipmentData()
        'Load Shipment Data
        Dim SHShipAddress1, SHShipAddress2, SHShipCity, SHShipState, SHShipZip, SHShipCountry, SHShipToName As String

        Dim GetShipmentDataStatement As String = "SELECT * FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID AND ShipmentStatus = @ShipmentStatus"
        Dim GetShipmentDataCommand As New SqlCommand(GetShipmentDataStatement, con)
        GetShipmentDataCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        GetShipmentDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetShipmentDataCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetShipmentDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("SalesOrderKey")) Then
                SalesOrderKey = 0
            Else
                SalesOrderKey = reader.Item("SalesOrderKey")
            End If
            If IsDBNull(reader.Item("ShipDate")) Then
                ShipDate = ""
            Else
                ShipDate = reader.Item("ShipDate")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                Comment = ""
            Else
                Comment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("PickTicketNumber")) Then
                PickTicketNumber = 0
            Else
                PickTicketNumber = reader.Item("PickTicketNumber")
            End If
            If IsDBNull(reader.Item("ShipVia")) Then
                ShipVia = "DELIVERY"
            Else
                ShipVia = reader.Item("ShipVia")
            End If
            If IsDBNull(reader.Item("PRONumber")) Then
                PRONumber = ""
            Else
                PRONumber = reader.Item("PRONumber")
            End If
            If IsDBNull(reader.Item("FreightQuoteNumber")) Then
                FreightQuoteNumber = ""
            Else
                FreightQuoteNumber = reader.Item("FreightQuoteNumber")
            End If
            If IsDBNull(reader.Item("FreightQuoteAmount")) Then
                FreightQuoteAmount = 0
            Else
                FreightQuoteAmount = reader.Item("FreightQuoteAmount")
            End If
            If IsDBNull(reader.Item("FreightActualAmount")) Then
                FreightActualAmount = 0
            Else
                FreightActualAmount = reader.Item("FreightActualAmount")
            End If
            If IsDBNull(reader.Item("ShippingWeight")) Then
                ShippingWeight = 0
            Else
                ShippingWeight = reader.Item("ShippingWeight")
            End If
            If IsDBNull(reader.Item("NumberOfPallets")) Then
                NumberOfPallets = 0
            Else
                NumberOfPallets = reader.Item("NumberOfPallets")
            End If
            If IsDBNull(reader.Item("DoubleStackedPallets")) Then
                NumberOfDoublePallets = 0
            Else
                NumberOfDoublePallets = reader.Item("DoubleStackedPallets")
            End If
            If IsDBNull(reader.Item("PalletsOnFloor")) Then
                NumberOfPalletsOnFloor = 0
            Else
                NumberOfPalletsOnFloor = reader.Item("PalletsOnFloor")
            End If
            If IsDBNull(reader.Item("CustomerID")) Then
                CustomerID = ""
            Else
                CustomerID = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("ShipToID")) Then
                ShipToID = ""
            Else
                ShipToID = reader.Item("ShipToID")
            End If
            If IsDBNull(reader.Item("ShipAddress1")) Then
                SHShipAddress1 = ""
            Else
                SHShipAddress1 = reader.Item("ShipAddress1")
            End If
            If IsDBNull(reader.Item("ShipAddress2")) Then
                SHShipAddress2 = ""
            Else
                SHShipAddress2 = reader.Item("ShipAddress2")
            End If
            If IsDBNull(reader.Item("ShipCity")) Then
                SHShipCity = ""
            Else
                SHShipCity = reader.Item("ShipCity")
            End If
            If IsDBNull(reader.Item("ShipState")) Then
                SHShipState = ""
            Else
                SHShipState = reader.Item("ShipState")
            End If
            If IsDBNull(reader.Item("ShipZip")) Then
                SHShipZip = ""
            Else
                SHShipZip = reader.Item("ShipZip")
            End If
            If IsDBNull(reader.Item("ShipCountry")) Then
                SHShipCountry = ""
            Else
                SHShipCountry = reader.Item("ShipCountry")
            End If
            If IsDBNull(reader.Item("CustomerPO")) Then
                CustomerPO = ""
            Else
                CustomerPO = reader.Item("CustomerPO")
            End If
            If IsDBNull(reader.Item("ProductTotal")) Then
                ProductTotal = 0
            Else
                ProductTotal = reader.Item("ProductTotal")
            End If
            If IsDBNull(reader.Item("TaxTotal")) Then
                TaxTotal = 0
            Else
                TaxTotal = reader.Item("TaxTotal")
            End If
            If IsDBNull(reader.Item("ShipmentTotal")) Then
                ShipmentTotal = 0
            Else
                ShipmentTotal = reader.Item("ShipmentTotal")
            End If
            If IsDBNull(reader.Item("BatchNumber")) Then
                BatchNumber = 0
            Else
                BatchNumber = reader.Item("BatchNumber")
            End If
            If IsDBNull(reader.Item("SpecialInstructions")) Then
                SpecialInstructions = ""
            Else
                SpecialInstructions = reader.Item("SpecialInstructions")
            End If
            If IsDBNull(reader.Item("SalesmanID")) Then
                SalesmanID = EmployeeSalespersonCode
            Else
                SalesmanID = reader.Item("SalesmanID")
            End If
            If IsDBNull(reader.Item("Tax2Total")) Then
                Tax2Total = 0
            Else
                Tax2Total = reader.Item("Tax2Total")
            End If
            If IsDBNull(reader.Item("Tax3Total")) Then
                Tax3Total = 0
            Else
                Tax3Total = reader.Item("Tax3Total")
            End If
            If IsDBNull(reader.Item("ShippingMethod")) Then
                ShipMethod = ""
            Else
                ShipMethod = reader.Item("ShippingMethod")
            End If
            If IsDBNull(reader.Item("ThirdPartyShipper")) Then
                ThirdPartyShipper = ""
            Else
                ThirdPartyShipper = reader.Item("ThirdPartyShipper")
            End If
            If IsDBNull(reader.Item("ShipToName")) Then
                SHShipToName = ""
            Else
                SHShipToName = reader.Item("ShipToName")
            End If
            If IsDBNull(reader.Item("ShippingAccount")) Then
                ShippingAccount = ""
            Else
                ShippingAccount = reader.Item("ShippingAccount")
            End If
            If IsDBNull(reader.Item("ShipEmail")) Then
                ShipEmail = ""
            Else
                ShipEmail = reader.Item("ShipEmail")
            End If
            If IsDBNull(reader.Item("SpecialLabelLine1")) Then
                SpecialLabelLine1 = ""
            Else
                SpecialLabelLine1 = reader.Item("SpecialLabelLine1")
            End If
            If IsDBNull(reader.Item("SpecialLabelLine2")) Then
                SpecialLabelLine2 = ""
            Else
                SpecialLabelLine2 = reader.Item("SpecialLabelLine2")
            End If
            If IsDBNull(reader.Item("SpecialLabelLine3")) Then
                SpecialLabelLine3 = ""
            Else
                SpecialLabelLine3 = reader.Item("SpecialLabelLine3")
            End If
        Else
            SalesOrderKey = 0
            ShipDate = Today()
            Comment = ""
            cboPickTicketNumber.SelectedIndex = -1
            ShipVia = "DELIVERY"
            PRONumber = ""
            FreightQuoteNumber = ""
            FreightQuoteAmount = 0
            FreightActualAmount = 0
            ShippingWeight = 0
            NumberOfPallets = 1
            NumberOfPalletsOnFloor = 0
            NumberOfDoublePallets = 0
            CustomerID = ""
            ShipToID = ""
            SHShipAddress1 = ""
            SHShipAddress2 = ""
            SHShipCity = ""
            SHShipState = ""
            SHShipZip = ""
            SHShipCountry = ""
            CustomerPO = ""
            ProductTotal = 0
            TaxTotal = 0
            ShipmentTotal = 0
            BatchNumber = 0
            SpecialInstructions = ""
            SalesmanID = EmployeeSalespersonCode
            Tax2Total = 0
            Tax3Total = 0
            ShipMethod = ""
            ThirdPartyShipper = ""
            SHShipToName = ""
            ShippingAccount = ""
            ShipEmail = ""
            SpecialLabelLine1 = ""
            SpecialLabelLine2 = ""
            SpecialLabelLine3 = ""
        End If
        reader.Close()
        con.Close()

        LoadLineWeight()

        cboPickTicketNumber.Text = PickTicketNumber
        txtSalesOrderNumber.Text = SalesOrderKey

        dtpShipmentDate.Text = Today()
        txtComments.Text = SpecialInstructions
        txtHeaderComment.Text = Comment
        txtCustomerID.Text = CustomerID
        cboAdditionalShipTo.Text = ShipToID
        txtShippingAddress1.Text = SHShipAddress1
        txtShippingAddress2.Text = SHShipAddress2
        txtShippingCity.Text = SHShipCity
        txtShippingCountry.Text = SHShipCountry
        txtShippingZip.Text = SHShipZip
        cboShippingState.Text = SHShipState
        txtCustomerPO.Text = CustomerPO
        txtSpecialLabelLine1.Text = SpecialLabelLine1
        txtSpecialLabelLine2.Text = SpecialLabelLine2
        txtSpecialLabelLine3.Text = SpecialLabelLine3
        txtShipToName.Text = SHShipToName
        txtShippingAccount.Text = ShippingAccount

        cboShipMethod.Text = ShipMethod
        cboShipVia.Text = ShipVia
        txtFreightQuoteNumber.Text = FreightQuoteNumber
        txtThirdPartyShipper.Text = ThirdPartyShipper
        txtShipEmail.Text = ShipEmail

        'Load UPS
        If cboShipVia.Text.StartsWith("UPS-") And (cboDivisionID.Text = "TFT" Or cboDivisionID.Text = "SLC" Or cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP") Then
            txtShippingWeight.Clear()
            txtEstimatedWeight.Clear()
            txtPRONumber.Clear()
            txtQuotedFreight.Clear()

            LoadUPSData()
        ElseIf cboShipVia.Text.StartsWith("FDX-") And (cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP") Then
            txtPRONumber.Text = PRONumber

            NumberOfPalletsOnFloor = NumberOfPallets - NumberOfDoublePallets
            txtNumberPallets.Text = NumberOfPallets
            txtDoublePallets.Text = NumberOfDoublePallets
            txtTotalPalletsOnFloor.Text = NumberOfPalletsOnFloor

            txtEstimatedWeight.Text = ShippingWeight
            txtShippingWeight.Text = ShippingWeight
            txtQuotedFreight.Text = FreightQuoteAmount
            txtActualFreight.Text = FreightActualAmount
        Else
            txtPRONumber.Text = PRONumber

            NumberOfPalletsOnFloor = NumberOfPallets - NumberOfDoublePallets
            txtNumberPallets.Text = NumberOfPallets
            txtDoublePallets.Text = NumberOfDoublePallets
            txtTotalPalletsOnFloor.Text = NumberOfPalletsOnFloor

            txtEstimatedWeight.Text = ReloadLineWeight + (Val(txtNumberPallets.Text) * PalletWeight)
            If ShippingWeight = 0 Then
                txtShippingWeight.Text = ReloadLineWeight + (Val(txtNumberPallets.Text) * PalletWeight)
            Else
                txtShippingWeight.Text = ShippingWeight
            End If
            txtQuotedFreight.Text = FreightQuoteAmount
            txtActualFreight.Text = FreightActualAmount
        End If

        'Recalc Freight
        AddShippingCharges()

        If cboShipMethod.Text = "THIRD PARTY" Then
            txtThirdPartyShipper.Enabled = True
        Else
            txtThirdPartyShipper.Enabled = False
            txtThirdPartyShipper.Clear()
        End If

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            cboPickTicketNumber.Focus()
        Else
            cboShipmentNumber.Focus()
        End If
    End Sub

    Public Sub LoadUPSData()
        'Count Number of records to determine if it is odd
        Dim CountUPSPicks As Integer = 0

        Dim CountUPSPicksStatement As String = "SELECT COUNT(PickTicketNumber) FROM UPSShippingData WHERE PickTicketNumber = @PickTicketNumber"
        Dim CountUPSPicksCommand As New SqlCommand(CountUPSPicksStatement, con)
        CountUPSPicksCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = cboPickTicketNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountUPSPicks = CInt(CountUPSPicksCommand.ExecuteScalar)
        Catch ex As Exception
            CountUPSPicks = 0
        End Try
        con.Close()

        'Run Delete rountine
        DeleteUPSRoutine()

        Dim MaxTransactionNumber As String = ""
        Dim UPSQuotedFreightCharge As Double = 0
        Dim UPSTotalWeight As Double = 0
        Dim UPSTrackingNumber As String = ""

        Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM UPSShippingData WHERE PickTicketNumber = @PickTicketNumber AND VoidIndicator = @VoidIndicator"
        Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
        MaxTransactionNumberCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = cboPickTicketNumber.Text
        MaxTransactionNumberCommand.Parameters.Add("@VoidIndicator", SqlDbType.VarChar).Value = "N"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MaxTransactionNumber = CStr(MaxTransactionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            MaxTransactionNumber = ""
        End Try
        con.Close()

        'Get saved data based on Pick Ticket and Transaction Number
        Dim GetUPSDataStatement As String = "SELECT * FROM UPSShippingData WHERE PickTicketNumber = @PickTicketNumber AND TransactionNumber = @TransactionNumber"
        Dim GetUPSDataCommand As New SqlCommand(GetUPSDataStatement, con)
        GetUPSDataCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = cboPickTicketNumber.Text
        GetUPSDataCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetUPSDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("QuotedFreightCharge")) Then
                UPSQuotedFreightCharge = 0
            Else
                UPSQuotedFreightCharge = reader.Item("QuotedFreightCharge")
            End If
            If IsDBNull(reader.Item("TotalWeight")) Then
                UPSTotalWeight = 0
            Else
                UPSTotalWeight = reader.Item("TotalWeight")
            End If
            If IsDBNull(reader.Item("TrackingNumber")) Then
                UPSTrackingNumber = ""
            Else
                UPSTrackingNumber = reader.Item("TrackingNumber")
            End If
        Else
            UPSQuotedFreightCharge = 0
            UPSTotalWeight = 0
            UPSTrackingNumber = ""
        End If
        reader.Close()
        con.Close()

        Try
            'Save to shipment
            cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET FreightQuoteAmount = @FreightQuoteAmount, ShippingWeight = @ShippingWeight, PRONumber = @PRONumber WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = UPSQuotedFreightCharge
            cmd.Parameters.Add("@ShippingWeight", SqlDbType.VarChar).Value = UPSTotalWeight
            cmd.Parameters.Add("@PRONumber", SqlDbType.VarChar).Value = UPSTrackingNumber

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error check
            'Log error on update failure
            Dim TempShipNumber As Integer = 0
            Dim strShipNumber As String
            TempShipNumber = Val(cboShipmentNumber.Text)
            strShipNumber = CStr(TempShipNumber)

            ErrorDate = Today()
            ErrorComment = "Load UPS Data"
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Save shipping from UPS Table to Shipment Header"
            ErrorReferenceNumber = "Shipment # " + strShipNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        txtQuotedFreight.Text = UPSQuotedFreightCharge
        txtShippingWeight.Text = UPSTotalWeight
        txtEstimatedWeight.Text = ReloadLineWeight
        txtPRONumber.Text = UPSTrackingNumber
        txtNumberPallets.Text = 0
        txtDoublePallets.Text = 0
        txtTotalPalletsOnFloor.Text = 0
    End Sub

    Public Sub LoadSerialLineDetails()
        Dim SerialPartNumber As String = ""
        Dim SerialPartDescription As String = ""

        Dim SerialPartNumberStatement As String = "SELECT PartNumber FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
        Dim SerialPartNumberCommand As New SqlCommand(SerialPartNumberStatement, con)
        SerialPartNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        SerialPartNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber2.Text)

        Dim SerialPartDescriptionStatement As String = "SELECT PartDescription FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
        Dim SerialPartDescriptionCommand As New SqlCommand(SerialPartDescriptionStatement, con)
        SerialPartDescriptionCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        SerialPartDescriptionCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber2.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SerialPartNumber = CStr(SerialPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            SerialPartNumber = ""
        End Try
        Try
            SerialPartDescription = CStr(SerialPartDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            SerialPartDescription = ""
        End Try
        con.Close()

        txtLinePartDescription2.Text = SerialPartDescription
        txtLinePartNumber2.Text = SerialPartNumber
    End Sub

    Public Sub LoadShipmentFromPickTicket()
        Dim LoadShipFromPickStatement As String = "SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE PickTicketNumber = @PickTicketNumber AND DivisionID = @DivisionID AND ShipmentStatus = @ShipmentStatus"
        Dim LoadShipFromPickCommand As New SqlCommand(LoadShipFromPickStatement, con)
        LoadShipFromPickCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)
        LoadShipFromPickCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LoadShipFromPickCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadShipFromPick = CInt(LoadShipFromPickCommand.ExecuteScalar)
        Catch ex As Exception
            cboShipmentNumber.SelectedIndex = -1
        End Try
        con.Close()

        cboShipmentNumber.Text = LoadShipFromPick
    End Sub

    Public Sub LoadSTCountryByCountryCode()
        Dim LoadSTCountry As String = ""

        Dim LoadCountryStatement As String = "SELECT Country FROM CountryCodes WHERE CountryCode = @CountryCode"
        Dim LoadCountryCommand As New SqlCommand(LoadCountryStatement, con)
        LoadCountryCommand.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = txtShippingCountry.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadSTCountry = CStr(LoadCountryCommand.ExecuteScalar)
        Catch ex As Exception
            LoadSTCountry = ""
        End Try
        con.Close()

        cboSTCountryName.Text = LoadSTCountry
    End Sub

    Public Sub LoadSTCountryCodeByCountry()
        Dim LoadSTCountryCode As String = ""

        Dim LoadCountryCodeStatement As String = "SELECT CountryCode FROM CountryCodes WHERE Country = @Country"
        Dim LoadCountryCodeCommand As New SqlCommand(LoadCountryCodeStatement, con)
        LoadCountryCodeCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = cboSTCountryName.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadSTCountryCode = CStr(LoadCountryCodeCommand.ExecuteScalar)
        Catch ex As Exception
            LoadSTCountryCode = ""
        End Try
        con.Close()

        txtShippingCountry.Text = LoadSTCountryCode
    End Sub

    Public Sub LoadShipViaAdd()
        Dim AutoAddFreightStatement As String = "SELECT ShipMethodType FROM ShipMethod WHERE ShipMethID = @ShipMethID"
        Dim AutoAddFreightCommand As New SqlCommand(AutoAddFreightStatement, con)
        AutoAddFreightCommand.Parameters.Add("@ShipMethID", SqlDbType.VarChar).Value = cboShipVia.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AutoAddFreight = CStr(AutoAddFreightCommand.ExecuteScalar)
        Catch ex As Exception
            AutoAddFreight = ""
        End Try
        con.Close()
    End Sub

    Public Sub AddShippingCharges()
        LoadShipViaAdd()

        Dim CurrentFreightQuote As Double = 0
        Dim AddedFreightAmount As Double = 0

        'Auto Add Freight Charges for TWD if FedEx or UPS
        If AutoAddFreight = "SP" And cboShipMethod.Text = "PREPAID/ADD" And cboShipVia.Text.StartsWith("UPS-") Then
            CurrentFreightQuote = Val(txtQuotedFreight.Text)

            If CurrentFreightQuote <= 100 Then
                AddedFreightAmount = 10
            Else
                AddedFreightAmount = 0
            End If

            FreightCharges = CurrentFreightQuote + AddedFreightAmount
            FreightCharges = Math.Round(FreightCharges, 2)
            txtActualFreight.Text = FreightCharges
        ElseIf AutoAddFreight = "SP" And cboShipMethod.Text = "PREPAID/ADD" And cboShipVia.Text.StartsWith("FDX-") Then
            CurrentFreightQuote = Val(txtQuotedFreight.Text)

            FreightCharges = CurrentFreightQuote * 1.5
            FreightCharges = Math.Round(FreightCharges, 2)
            txtActualFreight.Text = FreightCharges
        Else
            FreightCharges = Val(txtActualFreight.Text)
        End If

        If cboShipMethod.Text = "COLLECT" Or cboShipMethod.Text = "THIRD PARTY" Or cboShipMethod.Text = "PREPAID/NO ADD" Then
            txtActualFreight.Text = 0
        End If
    End Sub

    Public Sub GetThirdPartyBillingData()
        Dim BillToNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToNameCommand As New SqlCommand(BillToNameStatement, con)
        BillToNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        BillToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress1Statement As String = "SELECT BillToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
        BillToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        BillToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress2Statement As String = "SELECT BillToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress2Command As New SqlCommand(BillToAddress2Statement, con)
        BillToAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        BillToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToCityStatement As String = "SELECT BillToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToCityCommand As New SqlCommand(BillToCityStatement, con)
        BillToCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        BillToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToStateStatement As String = "SELECT BillToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToStateCommand As New SqlCommand(BillToStateStatement, con)
        BillToStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        BillToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToZipStatement As String = "SELECT BillToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToZipCommand As New SqlCommand(BillToZipStatement, con)
        BillToZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        BillToZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BillToName = CStr(BillToNameCommand.ExecuteScalar)
        Catch ex As Exception
            BillToName = ""
        End Try
        Try
            BillToAddress1 = CStr(BillToAddress1Command.ExecuteScalar)
        Catch ex As Exception
            BillToAddress1 = ""
        End Try
        Try
            BillToAddress2 = CStr(BillToAddress2Command.ExecuteScalar)
        Catch ex As Exception
            BillToAddress2 = ""
        End Try
        Try
            BillToCity = CStr(BillToCityCommand.ExecuteScalar)
        Catch ex As Exception
            BillToCity = ""
        End Try
        Try
            BillToState = CStr(BillToStateCommand.ExecuteScalar)
        Catch ex As Exception
            BillToState = ""
        End Try
        Try
            BillToZip = CStr(BillToZipCommand.ExecuteScalar)
        Catch ex As Exception
            BillToZip = ""
        End Try
        con.Close()

        txtThirdPartyShipper.Text = BillToName + Environment.NewLine + BillToAddress1 + Environment.NewLine + BillToAddress2 + Environment.NewLine + BillToCity + ", " + BillToState + "  " + BillToZip
    End Sub

    Public Sub LoadUploadedPickTicket()
        If cboShipmentNumber.Text <> "" Then
            Dim UploadedShipmentNumber As String = ""
            Dim UploadedFileName As String = ""
            Dim UploadedFilenameAndPath As String = ""

            UploadedShipmentNumber = cboShipmentNumber.Text

            UploadedFileName = UploadedShipmentNumber + ".pdf"
            UploadedFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + UploadedFileName

            If My.Computer.Name.StartsWith("TFP") Then
                If File.Exists(UploadedFilenameAndPath) Then
                    cmdViewPickTicket.Visible = True
                    cmdUploadPickTicket.Visible = False
                    cmdRemoteScan.Visible = False
                Else
                    cmdViewPickTicket.Visible = False
                    cmdUploadPickTicket.Visible = False
                    cmdRemoteScan.Visible = True
                End If
            Else
                If File.Exists(UploadedFilenameAndPath) Then
                    cmdViewPickTicket.Visible = True
                    cmdUploadPickTicket.Visible = False
                    cmdRemoteScan.Visible = False
                Else
                    cmdViewPickTicket.Visible = False
                    cmdUploadPickTicket.Visible = True
                    cmdRemoteScan.Visible = False
                End If
            End If
        Else
            'Do nothing
        End If
    End Sub

    'Load Totals

    Public Sub LoadShipmentTotalsCanadian()
        Dim CheckGST, CheckPST, CheckHST, SumShipLineTotal As Double

        Dim CheckGSTStatement As String = "SELECT TaxRate1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim CheckGSTCommand As New SqlCommand(CheckGSTStatement, con)
        CheckGSTCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        CheckGSTCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CheckPSTStatement As String = "SELECT TaxRate2 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim CheckPSTCommand As New SqlCommand(CheckPSTStatement, con)
        CheckPSTCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        CheckPSTCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CheckHSTStatement As String = "SELECT TaxRate3 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim CheckHSTCommand As New SqlCommand(CheckHSTStatement, con)
        CheckHSTCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        CheckHSTCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckGST = CDbl(CheckGSTCommand.ExecuteScalar)
        Catch ex As Exception
            CheckGST = 0
        End Try
        Try
            CheckPST = CDbl(CheckPSTCommand.ExecuteScalar)
        Catch ex As Exception
            CheckPST = 0
        End Try
        Try
            CheckHST = CDbl(CheckHSTCommand.ExecuteScalar)
        Catch ex As Exception
            CheckHST = 0
        End Try
        con.Close()

        'Get product Total from this shipment and recalculate tax
        Dim SumShipLineTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim SumShipLineTotalCommand As New SqlCommand(SumShipLineTotalStatement, con)
        SumShipLineTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        SumShipLineTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumShipLineTotal = CDbl(SumShipLineTotalCommand.ExecuteScalar)
        Catch ex As Exception
            SumShipLineTotal = 0
        End Try
        con.Close()

        SumExtendedAmount = SumShipLineTotal

        FreightCharges = Val(txtActualFreight.Text)

        TaxTotal = CheckGST * (SumShipLineTotal + FreightCharges)
        Tax2Total = CheckPST * (SumShipLineTotal + FreightCharges)
        Tax3Total = CheckHST * (SumShipLineTotal + FreightCharges)

        ShipmentTotal = SumShipLineTotal + TaxTotal + Tax2Total + Tax3Total + FreightCharges
    End Sub

    Public Sub LoadShipmentTotalsEstimatedWeight()
        Dim SumExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim SumExtendedAmountCommand As New SqlCommand(SumExtendedAmountStatement, con)
        SumExtendedAmountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        SumExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SumSalesTaxStatement As String = "SELECT SUM(SalesTax) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim SumSalesTaxCommand As New SqlCommand(SumSalesTaxStatement, con)
        SumSalesTaxCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        SumSalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SumLineWeightStatement As String = "SELECT SUM(LineWeight) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim SumLineWeightCommand As New SqlCommand(SumLineWeightStatement, con)
        SumLineWeightCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        SumLineWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumExtendedAmount = CDbl(SumExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            SumExtendedAmount = 0
        End Try
        Try
            SumSalesTax = CDbl(SumSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            SumSalesTax = 0
        End Try
        Try
            SumLineWeight = CDbl(SumLineWeightCommand.ExecuteScalar)
        Catch ex As Exception
            SumLineWeight = 0
        End Try
        con.Close()

        ShipmentTotal = SumExtendedAmount + SumSalesTax + FreightActualAmount
        txtEstimatedWeight.Text = SumLineWeight + (NumberOfPallets * PalletWeight)
        txtShippingWeight.Text = SumLineWeight + (NumberOfPallets * PalletWeight)
    End Sub

    Public Sub LoadShippingWeight()
        Dim SumLineWeightStatement As String = "SELECT SUM(LineWeight) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim SumLineWeightCommand As New SqlCommand(SumLineWeightStatement, con)
        SumLineWeightCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        SumLineWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumLineWeight = CDbl(SumLineWeightCommand.ExecuteScalar)
        Catch ex As Exception
            SumLineWeight = 0
        End Try
        con.Close()

        NumberOfPallets = Val(txtNumberPallets.Text)

        TotalPalletWeight = NumberOfPallets * PalletWeight
        TotalEstimatedWeight = TotalPalletWeight + SumLineWeight
        txtEstimatedWeight.Text = TotalEstimatedWeight
    End Sub

    Public Sub LoadLineWeight()
        Dim SumLineWeightStatement As String = "SELECT SUM(LineWeight) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim SumLineWeightCommand As New SqlCommand(SumLineWeightStatement, con)
        SumLineWeightCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        SumLineWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ReloadLineWeight = CDbl(SumLineWeightCommand.ExecuteScalar)
        Catch ex As Exception
            ReloadLineWeight = 0
        End Try
        con.Close()
    End Sub

    Public Sub LoadShipmentTotals()
        Dim GetSOTaxRate As Double

        Dim GetSOTaxRateStatement As String = "SELECT TaxRate1 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim GetSOTaxRateCommand As New SqlCommand(GetSOTaxRateStatement, con)
        GetSOTaxRateCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        GetSOTaxRateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSOTaxRate = CDbl(GetSOTaxRateCommand.ExecuteScalar)
        Catch ex As Exception
            GetSOTaxRate = 0
        End Try
        con.Close()

        'Recalculate lines for changes
        cmd = New SqlCommand("UPDATE ShipmentLineTable SET SalesTax = ExtendedAmount * @ShipmentTaxRate WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ShipmentTaxRate", SqlDbType.VarChar).Value = GetSOTaxRate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        Dim SumExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber1 AND DivisionID = @DivisionID1"
        Dim SumExtendedAmountCommand As New SqlCommand(SumExtendedAmountStatement, con)
        SumExtendedAmountCommand.Parameters.Add("@ShipmentNumber1", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        SumExtendedAmountCommand.Parameters.Add("@DivisionID1", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SumSalesTaxStatement As String = "SELECT SUM(SalesTax) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber2 AND DivisionID = @DivisionID2"
        Dim SumSalesTaxCommand As New SqlCommand(SumSalesTaxStatement, con)
        SumSalesTaxCommand.Parameters.Add("@ShipmentNumber2", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        SumSalesTaxCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumExtendedAmount = CDbl(SumExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            SumExtendedAmount = 0
        End Try
        Try
            SumSalesTax = CDbl(SumSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            SumSalesTax = 0
        End Try
        con.Close()

        SumSalesTax = Math.Round(SumSalesTax, 2)
        SumExtendedAmount = Math.Round(SumExtendedAmount, 2)

        TaxTotal = SumSalesTax
        Tax2Total = 0
        Tax3Total = 0
        FreightCharges = Val(txtActualFreight.Text)
        ShipmentTotal = SumExtendedAmount + TaxTotal + FreightCharges
    End Sub

    'Load Validation / Error Checking / Clear Routines

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log   
        If ErrorComment.Length > 399 Then
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

    Public Sub ValidateShippingMethod()
        ShipMethod = cboShipMethod.Text

        Select Case ShipMethod
            Case "COLLECT"
                'Do nothing
            Case "PREPAID"
                'Do nothing
            Case "PREPAID/NOADD"
                'Do nothing
            Case "PREPAID/ADD"
                If Val(txtActualFreight.Text) = 0 Then
                    MsgBox("You must enter billed freight for this order.", MsgBoxStyle.OkOnly)
                    CheckShippingMethod = "EXIT SUB"
                    Exit Sub
                End If
            Case "THIRD PARTY"
                If txtThirdPartyShipper.Text = "" Then
                    MsgBox("You must fill-in third party shipping info", MsgBoxStyle.OkOnly)
                    CheckShippingMethod = "EXIT SUB"
                    txtThirdPartyShipper.Focus()
                    Exit Sub
                End If
            Case "OTHER"
                'Do nothing
            Case Else
                MsgBox("You must select a valid Shipping Method", MsgBoxStyle.OkOnly)
                CheckShippingMethod = "EXIT SUB"
                cboShipMethod.Focus()
                Exit Sub
        End Select
    End Sub

    Public Sub ClearAllData()
        cboAdditionalShipTo.Text = ""
        cboShipmentNumber.Text = ""
        cboShippingState.Text = ""
        cboShipVia.Text = ""
        cboLinePartNumber.Text = ""
        cboLotPartDescription.Text = ""
        cboShipmentLineNumber.Text = ""
        cboPickTicketNumber.Text = ""
        cboShipMethod.Text = ""
        cboShipmentLineNumber2.Text = ""
        cboSTCountryName.Text = ""

        cboAdditionalShipTo.Refresh()
        cboShipmentNumber.Refresh()
        cboShippingState.Refresh()
        cboShipVia.Refresh()
        cboLinePartNumber.Refresh()
        cboLotPartDescription.Refresh()
        cboShipmentLineNumber.Refresh()
        cboPickTicketNumber.Refresh()
        cboShipMethod.Refresh()
        cboShipmentLineNumber2.Refresh()
        cboSTCountryName.Refresh()

        cboAdditionalShipTo.SelectedIndex = -1
        cboShipmentNumber.SelectedIndex = -1
        cboShippingState.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboLinePartNumber.SelectedIndex = -1
        cboLotPartDescription.SelectedIndex = -1
        cboShipmentLineNumber.SelectedIndex = -1
        cboPickTicketNumber.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1
        cboShipmentLineNumber2.SelectedIndex = -1
        cboSTCountryName.SelectedIndex = -1

        txtEstimatedWeight.Refresh()
        txtLotNumber.Refresh()
        txtActualFreight.Refresh()
        txtComments.Refresh()
        txtCustomerPO.Refresh()
        txtFreightQuoteNumber.Refresh()
        txtNumberPallets.Refresh()
        txtDoublePallets.Refresh()
        txtTotalPalletsOnFloor.Refresh()
        txtPRONumber.Refresh()
        txtQuotedFreight.Refresh()
        txtSalesOrderNumber.Refresh()
        txtShippingAddress1.Refresh()
        txtShippingAddress2.Refresh()
        txtShippingCity.Refresh()
        txtShippingCountry.Refresh()
        txtShippingWeight.Refresh()
        txtShippingZip.Refresh()
        txtShipToName.Refresh()
        txtHeatQuantity.Refresh()
        txtThirdPartyShipper.Refresh()
        txtLinePartDescription2.Refresh()
        txtLinePartNumber2.Refresh()
        txtLineSerialNumber2.Refresh()
        txtShippingAccount.Refresh()
        txtShipEmail.Refresh()
        txtSpecialLabelLine1.Refresh()
        txtSpecialLabelLine2.Refresh()
        txtSpecialLabelLine3.Refresh()

        txtCustomerID.Clear()
        txtEstimatedWeight.Clear()
        txtLotNumber.Clear()
        txtActualFreight.Clear()
        txtComments.Clear()
        txtCustomerPO.Clear()
        txtFreightQuoteNumber.Clear()
        txtNumberPallets.Clear()
        txtDoublePallets.Clear()
        txtTotalPalletsOnFloor.Clear()
        txtPRONumber.Clear()
        txtQuotedFreight.Clear()
        txtSalesOrderNumber.Clear()
        txtShippingAddress1.Clear()
        txtShippingAddress2.Clear()
        txtShippingCity.Clear()
        txtShippingCountry.Clear()
        txtShippingWeight.Clear()
        txtShippingZip.Clear()
        txtShipToName.Clear()
        txtHeatQuantity.Clear()
        txtThirdPartyShipper.Clear()
        txtLinePartDescription2.Clear()
        txtLinePartNumber2.Clear()
        txtLineSerialNumber2.Clear()
        txtShippingAccount.Clear()
        txtShipEmail.Clear()
        txtSpecialLabelLine1.Clear()
        txtSpecialLabelLine2.Clear()
        txtSpecialLabelLine3.Clear()

        ClearLotNumbers()
        ClearOpenOrders()
        ClearSerialNumbers()
        ClearShipmentLines()

        'Defaults for scanning
        If My.Computer.Name.StartsWith("TFP") Then
            cmdRemoteScan.Visible = True
            cmdUploadPickTicket.Visible = False
            cmdViewPickTicket.Visible = False
            ReUploadPickTicketToolStripMenuItem.Enabled = False
            AppendUploadedPickTicketToolStripMenuItem.Enabled = False
            UploadPickTicketToolStripMenuItem.Visible = True
        Else
            cmdRemoteScan.Visible = False
            cmdUploadPickTicket.Visible = True
            cmdViewPickTicket.Visible = False
            UploadPickTicketToolStripMenuItem.Visible = False
        End If

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            cboPickTicketNumber.Focus()
        Else
            cboShipmentNumber.Focus()
        End If
    End Sub

    Public Sub ClearVariables()
        ShippingAccount = ""
        ShipEmail = ""
        BillToAddress1 = ""
        BillToAddress2 = ""
        BillToCity = ""
        BillToState = "'"
        BillToZip = ""
        BillToName = ""
        NextShippingNumber = 0
        ConsignmentShipNumber = 0
        BatchNumber = 0
        NextLotLineNumber = 0
        LastLotLineNumber = 0
        GLDebitAccount = ""
        CustomerClass = ""
        LotPartNumber = ""
        Comment = ""
        ShipVia = ""
        PRONumber = ""
        FreightQuoteNumber = ""
        CustomerID = ""
        ShipToID = ""
        ShipAddress1 = ""
        ShipAddress2 = ""
        ShipCity = ""
        ShipState = ""
        ShipZip = ""
        ShipCountry = ""
        ShipName = ""
        CustomerPO = ""
        SOShipmentStatus = ""
        SOHeaderStatus = ""
        ShipmentNumber = 0
        SalesOrderKey = 0
        PickTicketNumber = 0
        NumberOfPallets = 0
        VerifyStatus = 0
        FreightQuoteAmount = 0
        FreightActualAmount = 0
        ShippingWeight = 0
        ProductTotal = 0
        TaxTotal = 0
        Tax2Total = 0
        Tax3Total = 0
        ShipmentTotal = 0
        NextInventoryTransactionNumber = 0
        LastInventoryTransactionNumber = 0
        FIFOCost = 0
        FIFOExtendedAmount = 0
        GlobalSONumber = 0
        GlobalShipmentNumber = 0
        CountShipLines = 0
        ShipLine = 0
        TempShipLine = 0
        ExtendedCOS = 0
        MaxDate = 0
        LastPurchaseCost = 0
        PartQOH = 0
        LineStockStatus = ""
        LoadShipFromPick = 0
        SalesmanID = EmployeeSalespersonCode
        SpecialInstructions = ""
        GetHSTRate = 0
        GetGSTRate = 0
        GetPSTRate = 0
        GetVendor = ""
        GetVendorClass = ""
        StandardCost = 0
        ShipMethod = ""
        ThirdPartyShipper = ""
        AssemblySerialNumber = ""
        PurchaseProductLineID = ""
        SerializedPart = ""
        RunningSerialQuantity = 0
        SpecialLabelLine1 = ""
        SpecialLabelLine2 = ""
        SpecialLabelLine3 = ""
        LastPONumber = 0
        NextPONumber = 0
        strPONumber = ""
        NumberOfDoublePallets = 0
        NumberOfPalletsOnFloor = 0

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            cboPickTicketNumber.Focus()
        Else
            cboShipmentNumber.Focus()
        End If
    End Sub

    Public Sub CheckQOHForLineItems()
        'Check all line items in the datagrid for sufficient QOH
        For Each row As DataGridViewRow In dgvShipmentLines.Rows
            Try
                CheckPartNumber = row.Cells("PartNumberColumn").Value
            Catch ex As Exception
                CheckPartNumber = ""
            End Try
            Try
                CheckShipmentQuantity = row.Cells("QuantityShippedColumn").Value
            Catch ex As Exception
                CheckShipmentQuantity = 0
            End Try

            If CheckPartNumber = "FREIGHT" Or CheckPartNumber = "LABOR" Or CheckPartNumber = "REPAIR" Or CheckPartNumber = "TRIP CHARGE" Or CheckPartNumber = "RENTAL" Or CheckPartNumber = "REPAIR LABOR" Or CheckPartNumber = "REPAIR PER HOUR" Or CheckPartNumber = "MARK FIELD" Or CheckPartNumber = "MARK SHOP" Or CheckPartNumber = "MARK:" Or CheckPartNumber = "MISC TW SALES" Or CheckPartNumber = "WORK" Then
                LineStockStatus = "STOCK"
            Else
                Dim PartQOHStatement As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim PartQOHCommand As New SqlCommand(PartQOHStatement, con)
                PartQOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = CheckPartNumber
                PartQOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PartQOH = CDbl(PartQOHCommand.ExecuteScalar)
                Catch ex As Exception
                    PartQOH = 0
                End Try
                con.Close()

                If PartQOH - CheckShipmentQuantity < 0 Then
                    LineStockStatus = "NOSTOCK"
                    MsgBox("One or more part numbers on this shipment has insufficient quantities on hand. Please check before completing shipment.", MsgBoxStyle.OkOnly)
                    Exit For ' - Exit Loop if any lines have 0 or less QOH
                Else
                    LineStockStatus = "STOCK"
                End If
            End If
        Next
    End Sub

    Public Sub CheckLinesForComplete()
        'Set lines to complete or not complete
        Dim ShipmentLineCheck As Integer = 0
        Dim ShippingQuantity As Double = 0
        Dim OpenQuantity As Double = 0

        For Each row As DataGridViewRow In dgvShipmentLines.Rows
            Try
                ShipmentLineCheck = row.Cells("ShipmentLineNumberColumn").Value
            Catch ex As Exception
                ShipmentLineCheck = 0
            End Try
            Try
                ShippingQuantity = row.Cells("QuantityShippedColumn").Value
            Catch ex As Exception
                ShippingQuantity = 0
            End Try

            'Get Quantity Open
            Dim OpenQuantityString As String = "SELECT Quantity FROM PickListLineTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID AND PickListLineKey = @PickListLineKey"
            Dim OpenQuantityCommand As New SqlCommand(OpenQuantityString, con)
            OpenQuantityCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)
            OpenQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            OpenQuantityCommand.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = ShipmentLineCheck

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                OpenQuantity = CDbl(OpenQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                OpenQuantity = 0
            End Try
            con.Close()

            If ShippingQuantity >= OpenQuantity Then
                cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineComplete = @LineComplete WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineCheck
                    .Add("@LineComplete", SqlDbType.VarChar).Value = "YES"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineComplete = @LineComplete WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineCheck
                    .Add("@LineComplete", SqlDbType.VarChar).Value = "NO"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            'Check if Complete Line Checkbox is checked
            Dim CompleteLinecell As DataGridViewCheckBoxCell = row.Cells("CompleteLineColumn")

            If CompleteLinecell.Value = "SELECTED" Then
                cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineComplete = @LineComplete WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineCheck
                    .Add("@LineComplete", SqlDbType.VarChar).Value = "YES"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                'Skip
            End If

            ShipmentLineCheck = 0
            ShippingQuantity = 0
            OpenQuantity = 0
        Next
    End Sub

    Public Sub AutoPrintPackingSlips()












    End Sub

    Public Sub FormLoginRoutine()
        'Define Variables
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()
        Dim strTodaysTime As String = ""
        strTodaysTime = Todaysdate.ToShortTimeString()

        'Update Database
        cmd = New SqlCommand("INSERT INTO UserFormLogin (UserID, FormName, DivisionID, LoginDate, LoginTime, LogoutDate, LogoutTime) values (@UserID, @FormName, @DivisionID, @LoginDate, @LoginTime, @LogoutDate, @LogoutTime)", con)

        With cmd.Parameters
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@FormName", SqlDbType.VarChar).Value = FormName
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@LoginDate", SqlDbType.VarChar).Value = strTodaysDate
            .Add("@LoginTime", SqlDbType.VarChar).Value = strTodaysTime
            .Add("@LogoutDate", SqlDbType.VarChar).Value = ""
            .Add("@LogoutTime", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub FormLogoutRoutine()
        'Define Variables
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()
        Dim strTodaysTime As String = ""
        strTodaysTime = Todaysdate.ToShortTimeString()

        'Update Database
        cmd = New SqlCommand("INSERT INTO UserFormLogin (UserID, FormName, DivisionID, LoginDate, LoginTime, LogoutDate, LogoutTime) values (@UserID, @FormName, @DivisionID, @LoginDate, @LoginTime, @LogoutDate, @LogoutTime)", con)

        With cmd.Parameters
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@FormName", SqlDbType.VarChar).Value = FormName
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@LoginDate", SqlDbType.VarChar).Value = ""
            .Add("@LoginTime", SqlDbType.VarChar).Value = ""
            .Add("@LogoutDate", SqlDbType.VarChar).Value = strTodaysDate
            .Add("@LogoutTime", SqlDbType.VarChar).Value = strTodaysTime
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Save / Insert / Delete Routines

    Public Sub SaveUpdateShipmentToPending()
        ValidateShippingMethod()

        If txtShipToName.Text = "" Or txtShipToName.Text = "DEFAULT SHIP TO" Then
            'Get Ship To Name from SO
            Dim GetSOShipToNameStatement As String = "SELECT ShipToName FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
            Dim GetSOShipToNameCommand As New SqlCommand(GetSOShipToNameStatement, con)
            GetSOShipToNameCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            GetSOShipToNameCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetSOShipToName = CStr(GetSOShipToNameCommand.ExecuteScalar)
            Catch ex As Exception
                GetSOShipToName = ""
            End Try
            con.Close()

            If GetSOShipToName = "" Then
                Dim GetCustomerShipToNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim GetCustomerShipToNameCommand As New SqlCommand(GetCustomerShipToNameStatement, con)
                GetCustomerShipToNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
                GetCustomerShipToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetCustomerShipToName = CStr(GetCustomerShipToNameCommand.ExecuteScalar)
                Catch ex As Exception
                    GetCustomerShipToName = ""
                End Try
                con.Close()

                ShipToName = GetCustomerShipToName
            Else
                ShipToName = GetSOShipToName
            End If
        Else
            ShipToName = txtShipToName.Text
        End If
        '********************************************************************************************************
        Dim GetShipmentStatus As String

        'Validate that shipment is pending and not shipped
        Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
        GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetShipmentStatus = CStr(GetShipmentStatusCommand.ExecuteScalar)
        Catch ex As Exception
            GetShipmentStatus = ""
        End Try
        con.Close()

        If GetShipmentStatus <> "PENDING" Then
            MsgBox("This shipment has already been processed.", MsgBoxStyle.OkOnly)

            ClearAllData()
            ClearVariables()
            Exit Sub
        End If
        '*******************************************************************************************************************************************
        'Validate number of pallets
        NumberOfPallets = Val(txtNumberPallets.Text)
        NumberOfDoublePallets = Val(txtDoublePallets.Text)
        NumberOfPalletsOnFloor = NumberOfPallets - NumberOfDoublePallets
        txtTotalPalletsOnFloor.Text = NumberOfPalletsOnFloor
        '******************************************************************************************************************************************
        'Save data to Shipment Header Table
        cmd = New SqlCommand("Update ShipmentHeaderTable SET SalesOrderKey = @SalesOrderKey, ShipDate = @ShipDate, Comment = @Comment, ShipVia = @ShipVia, PRONumber = @PRONumber, FreightQuoteNumber = @FreightQuoteNumber, FreightQuoteAmount = @FreightQuoteAmount, FreightActualAmount = @FreightActualAmount, ShippingWeight = @ShippingWeight, NumberOfPallets = @NumberOfPallets, DoubleStackedPallets = @DoubleStackedPallets, PalletsOnFloor = @PalletsOnFloor, CustomerID = @CustomerID, ShipToID = @ShipToID, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZip = @ShipZip, ShipCountry = @ShipCountry, CustomerPO = @CustomerPO, ShipmentStatus = @ShipmentStatus, ProductTotal = @ProductTotal, TaxTotal = @TaxTotal, ShipmentTotal = @ShipmentTotal, BatchNumber = @BatchNumber, SpecialInstructions = @SpecialInstructions, SalesmanID = @SalesmanID, Tax2Total = @Tax2Total, Tax3Total = @Tax3Total, Locked = @Locked, CustomerClass = @CustomerClass, FOB = @FOB, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName, ShipEmail = @ShipEmail, ShippingAccount = @ShippingAccount, SpecialLabelLine1 = @SpecialLabelLine1, SpecialLabelLine2 = @SpecialLabelLine2, SpecialLabelLine3 = @SpecialLabelLine3 WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            .Add("@ShipDate", SqlDbType.VarChar).Value = ShipDate
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtHeaderComment.Text
            .Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)
            .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
            .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
            .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
            .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtQuotedFreight.Text)
            .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtActualFreight.Text)
            .Add("@ShippingWeight", SqlDbType.VarChar).Value = Val(txtShippingWeight.Text)
            .Add("@NumberOfPallets", SqlDbType.VarChar).Value = NumberOfPallets
            .Add("@DoubleStackedPallets", SqlDbType.VarChar).Value = NumberOfDoublePallets
            .Add("@PalletsOnFloor", SqlDbType.VarChar).Value = NumberOfPalletsOnFloor
            .Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
            .Add("@ShipToID", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text
            .Add("@ShipAddress1", SqlDbType.VarChar).Value = txtShippingAddress1.Text
            .Add("@ShipAddress2", SqlDbType.VarChar).Value = txtShippingAddress2.Text
            .Add("@ShipCity", SqlDbType.VarChar).Value = txtShippingCity.Text
            .Add("@ShipState", SqlDbType.VarChar).Value = cboShippingState.Text
            .Add("@ShipZip", SqlDbType.VarChar).Value = txtShippingZip.Text
            .Add("@ShipCountry", SqlDbType.VarChar).Value = txtShippingCountry.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
            .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
            .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedAmount
            .Add("@TaxTotal", SqlDbType.VarChar).Value = TaxTotal
            .Add("@ShipmentTotal", SqlDbType.VarChar).Value = ShipmentTotal
            .Add("@BatchNumber", SqlDbType.VarChar).Value = BatchNumber
            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtComments.Text
            .Add("@SalesmanID", SqlDbType.VarChar).Value = SalesmanID
            .Add("@Tax2Total", SqlDbType.VarChar).Value = Tax2Total
            .Add("@Tax3Total", SqlDbType.VarChar).Value = Tax3Total
            '.Add("@CertsAutoGenerated", SqlDbType.VarChar).Value = ""
            '.Add("@SOLog", SqlDbType.VarChar).Value = ""
            '.Add("@PulledBy", SqlDbType.VarChar).Value = ""
            '.Add("@CertsPulled", SqlDbType.VarChar).Value = ""
            '.Add("@PackingSlip", SqlDbType.VarChar).Value = ""
            .Add("@Locked", SqlDbType.VarChar).Value = ""
            .Add("@CustomerClass", SqlDbType.VarChar).Value = txtCustomerClass.Text
            .Add("@FOB", SqlDbType.VarChar).Value = "Medina"
            .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
            .Add("@ShipToName", SqlDbType.VarChar).Value = ShipToName
            .Add("@ShipEmail", SqlDbType.VarChar).Value = txtShipEmail.Text
            .Add("@ShippingAccount", SqlDbType.VarChar).Value = txtShippingAccount.Text
            .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = txtSpecialLabelLine1.Text
            .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = txtSpecialLabelLine2.Text
            .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = txtSpecialLabelLine3.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub SaveUpdateAdditionalShipTo()
        Try
            'Create new ship to from the text boxes
            cmd = New SqlCommand("Insert Into AdditionalShipTo(ShipToID, CustomerID, DivisionID, Address1, Address2, City, State, Zip, Country, Name) Values (@ShipToID, @CustomerID, @DivisionID, @Address1, @Address2, @City, @State, @Zip, @Country, @Name)", con)

            With cmd.Parameters
                .Add("@ShipToID", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text
                .Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Address1", SqlDbType.VarChar).Value = txtShippingAddress1.Text
                .Add("@Address2", SqlDbType.VarChar).Value = txtShippingAddress2.Text
                .Add("@City", SqlDbType.VarChar).Value = txtShippingCity.Text
                .Add("@State", SqlDbType.VarChar).Value = cboShippingState.Text
                .Add("@Zip", SqlDbType.VarChar).Value = txtShippingZip.Text
                .Add("@Country", SqlDbType.VarChar).Value = txtShippingCountry.Text
                .Add("@Name", SqlDbType.VarChar).Value = txtShipToName.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Command to save changes in the additional ship to from the text boxes
            cmd = New SqlCommand("UPDATE AdditionalShipTo SET Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country, Name = @Name WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ShipToID", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text
                .Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Address1", SqlDbType.VarChar).Value = txtShippingAddress1.Text
                .Add("@Address2", SqlDbType.VarChar).Value = txtShippingAddress2.Text
                .Add("@City", SqlDbType.VarChar).Value = txtShippingCity.Text
                .Add("@State", SqlDbType.VarChar).Value = cboShippingState.Text
                .Add("@Zip", SqlDbType.VarChar).Value = txtShippingZip.Text
                .Add("@Country", SqlDbType.VarChar).Value = txtShippingCountry.Text
                .Add("@Name", SqlDbType.VarChar).Value = txtShipToName.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Try
    End Sub

    Private Sub InsertConsignmentShipmentTable()
        cmd = New SqlCommand("INSERT INTO ConsignmentShippingTable (ConsignmentShipNumber, PartNumber, PartDescription, QuantityShipped, UnitCost, UnitPrice ExtendedCost, ExtendedAmount, DivisionID, ShipDate, ShipmentNumber, CustomerClass) VALUES((SELECT isnull(MAX(ConsignmentShipNumber) + 1, 910001) FROM ConsignmentShippingTable), @PartNumber, @PartDescription, @QuantityShipped, @UnitCost, @UnitPrice, @ExtendedCost, @ExtendedAmount, @DivisionID, @ShipDate, @ShipmentNumber, @CustomerClass)", con)

        With cmd.Parameters
            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescriptionColumn
            .Add("QuantityShipped", SqlDbType.VarChar).Value = QuantityShipped
            .Add("@UnitCost", SqlDbType.VarChar).Value = PartNumber
            .Add("@UnitPrice", SqlDbType.VarChar).Value = PartDescriptionColumn
            .Add("ExtendedCost", SqlDbType.VarChar).Value = QuantityShipped
            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = PartNumber
            .Add("@DivisionID", SqlDbType.VarChar).Value = PartDescriptionColumn
            .Add("ShipDate", SqlDbType.VarChar).Value = QuantityShipped
            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = PartNumber
            .Add("@CustomerClass", SqlDbType.VarChar).Value = PartDescriptionColumn
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub POHeaderInsertProcedure()
        'Find the next PO Number to use
        Dim MAXStatement As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderHeaderTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastPONumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As System.Exception
            LastPONumber = 6200000
        End Try
        con.Close()

        NextPONumber = LastPONumber + 1
        strPONumber = CStr(NextPONumber)

        Try
            'Write Data to Purchase Order Header Database Table
            cmd = New SqlCommand("Insert Into PurchaseOrderHeaderTable(PurchaseOrderHeaderKey, PODate, VendorID, PaymentCode, POHeaderComment, ShipDate, ShipMethodID, FreightCharge, SalesTax, Status, ProductTotal, POTotal, PODropShipCustomerID, POAdditionalShipTo, DivisionID, DropShipSalesOrderNumber, PurchaseAgent, Locked, ShipName, ShipAddress1, ShipAddress2, ShipCity, ShipState, ShipZipCode, ShipCountry, EstTotalWeight, EstTotalBoxes, ShipMethod)Values(@PurchaseOrderHeaderKey, @PODate, @VendorID, @PaymentCode, @POHeaderComment, @ShipDate, @ShipMethodID, @FreightCharge, @SalesTax, @Status, @ProductTotal, @POTotal, @PODropShipCustomerID, @POAdditionalShipTo, @DivisionID, @DropShipSalesOrderNumber, @PurchaseAgent, @Locked, @ShipName, @ShipAddress1, @ShipAddress2, @ShipCity, @ShipState, @ShipZipCode, @ShipCountry, @EstTotalWeight, @EstTotalBoxes, @ShipMethod)", con)

            With cmd.Parameters
                .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = NextPONumber
                .Add("@PODate", SqlDbType.VarChar).Value = Today()
                .Add("@VendorID", SqlDbType.VarChar).Value = "WELDING CERAMICS"
                .Add("@PaymentCode", SqlDbType.VarChar).Value = "N30"
                .Add("@POHeaderComment", SqlDbType.VarChar).Value = "Autogenerated from Shipment #" + cboShipmentNumber.Text
                .Add("@ShipDate", SqlDbType.VarChar).Value = Today()
                .Add("@ShipMethodID", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@FreightCharge", SqlDbType.VarChar).Value = Val(txtActualFreight.Text)
                .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedAmount
                .Add("@POTotal", SqlDbType.VarChar).Value = ShipmentTotal
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                .Add("@PODropShipCustomerID", SqlDbType.VarChar).Value = ""
                .Add("@POAdditionalShipTo", SqlDbType.VarChar).Value = ""
                .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                .Add("@DropShipSalesOrderNumber", SqlDbType.VarChar).Value = 0
                .Add("@PurchaseAgent", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@ShipName", SqlDbType.VarChar).Value = "TFP CORPORATION"
                .Add("@ShipAddress1", SqlDbType.VarChar).Value = "460 LAKE ROAD"
                .Add("@ShipAddress2", SqlDbType.VarChar).Value = ""
                .Add("@ShipCity", SqlDbType.VarChar).Value = "MEDINA"
                .Add("@ShipState", SqlDbType.VarChar).Value = "OH"
                .Add("@ShipZipCode", SqlDbType.VarChar).Value = "44256"
                .Add("@ShipCountry", SqlDbType.VarChar).Value = "USA"
                .Add("@EstTotalWeight", SqlDbType.VarChar).Value = Val(txtShippingWeight.Text)
                .Add("@EstTotalBoxes", SqlDbType.VarChar).Value = 0
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
            TempPONumber = NextPONumber
            strPONumber = CStr(TempPONumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Insert Command --- Create PO in TWD"
            ErrorReferenceNumber = "PO # " + strPONumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Public Sub RunChattanoogaRoutine()
        'Create PO Header
        POHeaderInsertProcedure()
        '*************************************************************************************************
        'Add PO Lines
        Dim ReissuePOLine As Integer = 1
        Dim ReissueUnitCost, ReissueExtendedAmount As Double
        Dim ReissueOrderQuantity As Integer
        Dim ReissuePartNumber, ReissuePartDescription, ReissueLineComment, ReissueDebitAccount, ReissueCreditAccount As String

        'Get Line Data
        For Each row As DataGridViewRow In dgvShipmentLines.Rows
            Try
                ReissueUnitCost = row.Cells("PriceColumn").Value
            Catch ex As System.Exception
                ReissueUnitCost = 0
            End Try
            Try
                ReissueOrderQuantity = row.Cells("QuantityShippedColumn").Value
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
                ReissueDebitAccount = row.Cells("GLDebitAccountColumn").Value
            Catch ex As System.Exception
                ReissueDebitAccount = "20999"
            End Try
            Try
                ReissueCreditAccount = row.Cells("GLCreditAccountColumn").Value
            Catch ex As System.Exception
                ReissueCreditAccount = "12100"
            End Try

            ReissueExtendedAmount = ReissueOrderQuantity * ReissueUnitCost
            ReissueExtendedAmount = Math.Round(ReissueExtendedAmount, 2)

            Try
                'Save Data to Prewritten Purchase Order Line Database Table
                cmd = New SqlCommand("INSERT INTO PurchaseOrderLineTable (PurchaseOrderHeaderKey, PurchaseOrderLineNumber, PartNumber, PartDescription, OrderQuantity, UnitCost, ExtendedAmount, LineStatus, DivisionID, DebitGLAccount, CreditGLAccount, SelectForInvoice, LineComment)values(@PurchaseOrderHeaderKey, @PurchaseOrderLineNumber, @PartNumber, @PartDescription, @OrderQuantity, @UnitCost, @ExtendedAmount, @LineStatus, @DivisionID, @DebitGLAccount, @CreditGLAccount, @SelectForInvoice, @LineComment)", con)

                With cmd.Parameters
                    .Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = NextPONumber
                    .Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = ReissuePOLine
                    .Add("@PartNumber", SqlDbType.VarChar).Value = ReissuePartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = ReissuePartDescription
                    .Add("@OrderQuantity", SqlDbType.VarChar).Value = ReissueOrderQuantity
                    .Add("@UnitCost", SqlDbType.VarChar).Value = ReissueUnitCost
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ReissueExtendedAmount
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = "20999"
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
        '************************************************************************************************************
        'Summation and validation

        'Update Shipment with new PO Number
        cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET CustomerPO = @CustomerPO WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = "TWD" + strPONumber
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Update Pick Ticket with new PO Number
        cmd = New SqlCommand("UPDATE PickListHeaderTable SET CustomerPO = @CustomerPO WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = "TWD" + strPONumber
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Update Sales Order with new PO Number
        cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET CustomerPO = @CustomerPO WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

        With cmd.Parameters
            .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = "TWD" + strPONumber
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '************************************************************************************************************
        'Autoprint PO and new Packing List
        GlobalShipmentNumber = Val(cboShipmentNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text
        GlobalCompleteShipment = "COMPLETE SHIPMENT"
        GlobalAutoPrintPackingList = "YES"

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
            Using NewPrintPackingListRemote As New PrintPackingListRemote
                Dim Result = NewPrintPackingListRemote.ShowDialog()
            End Using
        Else
            Using NewPrintPackingList As New PrintPackingList
                Dim Result = NewPrintPackingList.ShowDialog()
            End Using
        End If
    End Sub

    Public Sub UpdateSerialLog()
        Try
            'Update Serial Log on Complete Shipment with the buyer and seller
            cmd = New SqlCommand("UPDATE AssemblySerialLog SET CustomerID = @CustomerID, DivisionID = @DivisionID, Status = @Status WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID2", con)

            With cmd.Parameters
                .Add("@SerialNumber", SqlDbType.VarChar).Value = AssemblySerialNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@DivisionID2", SqlDbType.VarChar).Value = AssemblyDivisionID
                .Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = AssemblyPartNumber
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempShipNumber As Integer = 0
            Dim strShipNumber As String = ""
            Dim strSerialNumber As String = ""
            TempShipNumber = Val(cboShipmentNumber.Text)
            strShipNumber = CStr(TempShipNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Shipment Completion --- Update Serial Log"
            ErrorReferenceNumber = "Shipment # " + strShipNumber + ", Serial # -- " + strSerialNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Public Sub DeleteUPSRoutine()
        'Load UPS Datagrid
        cmd = New SqlCommand("SELECT * FROM UPSShippingData WHERE PickTicketNumber = @PickTicketNumber AND VoidIndicator = @VoidIndicator", con)
        cmd.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = cboPickTicketNumber.Text
        cmd.Parameters.Add("@VoidIndicator", SqlDbType.VarChar).Value = "Y"
        If con.State = ConnectionState.Closed Then con.Open()
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd
        myAdapter9.Fill(ds9, "UPSShippingData")
        dgvUPSData.DataSource = ds9.Tables("UPSShippingData")
        con.Close()

        'If datagrid has records, delete N/Y records
        If Me.dgvUPSData.RowCount > 0 Then
            Dim UPSTrackingNumber As String = ""
            Dim UPSTransactionNumber As String = ""

            For Each row As DataGridViewRow In dgvUPSData.Rows
                Try
                    UPSTrackingNumber = row.Cells("TrackingNumberColumn5").Value
                Catch ex As Exception
                    UPSTrackingNumber = ""
                End Try
                Try
                    UPSTransactionNumber = row.Cells("TransactionNumberColumn5").Value
                Catch ex As Exception
                    UPSTransactionNumber = ""
                End Try

                Try
                    'Delete N Record
                    cmd = New SqlCommand("DELETE FROM UPSShippingData WHERE PickTicketNumber = @PickTicketNumber AND TrackingNumber = @TrackingNumber AND TransactionNumber = @TransactionNumber AND VoidIndicator = @VoidIndicator", con)
                    cmd.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = cboPickTicketNumber.Text
                    cmd.Parameters.Add("@TrackingNumber", SqlDbType.VarChar).Value = UPSTrackingNumber
                    cmd.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = UPSTransactionNumber
                    cmd.Parameters.Add("@VoidIndicator", SqlDbType.VarChar).Value = "N"

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure

                    ErrorDate = Today()
                    ErrorComment = ex.ToString
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Shipment Completion --- Delete N UPS Data Error"
                    ErrorReferenceNumber = "Pick Ticket # " + cboPickTicketNumber.Text
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                UPSTrackingNumber = ""
                UPSTransactionNumber = ""
            Next

            'Delete all Y Records for this Pick Ticket
            Try
                'Delete Y Record
                cmd = New SqlCommand("DELETE FROM UPSShippingData WHERE PickTicketNumber = @PickTicketNumber AND VoidIndicator = @VoidIndicator", con)
                cmd.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = cboPickTicketNumber.Text
                cmd.Parameters.Add("@VoidIndicator", SqlDbType.VarChar).Value = "Y"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure

                ErrorDate = Today()
                ErrorComment = ex.ToString
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Shipment Completion --- Delete Y UPS Data Error"
                ErrorReferenceNumber = "Pick Ticket # " + cboPickTicketNumber.Text
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            dgvUPSData.DataSource = Nothing
        End If
    End Sub

    'Load Datagridview Events

    Private Sub dgvAddedLotNumbers_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAddedLotNumbers.CellValueChanged
        Dim RowShipmentLineNumber As Integer = 0
        Dim RowLotLineNumber As Integer = 0
        Dim RowHeatQuantity As Double = 0
        Dim RowLotNumber As String = ""
        Dim GetRowHeatNumber As String = ""
        Dim GetRowPartNumber As String = ""

        Try
            If Me.dgvAddedLotNumbers.RowCount <> 0 Then
                Dim GetShipmentStatus As String

                'Validate that shipment is pending and not shipped
                Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
                GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetShipmentStatus = CStr(GetShipmentStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    GetShipmentStatus = ""
                End Try
                con.Close()

                If GetShipmentStatus <> "PENDING" Then
                    MsgBox("This shipment has already been processed.", MsgBoxStyle.OkOnly)

                    ClearAllData()
                    ClearVariables()
                    Exit Sub
                End If

                Dim RowIndex2 As Integer = Me.dgvAddedLotNumbers.CurrentCell.RowIndex

                RowShipmentLineNumber = Me.dgvAddedLotNumbers.Rows(RowIndex2).Cells("ShipmentLineNumberColumn2").Value
                RowLotLineNumber = Me.dgvAddedLotNumbers.Rows(RowIndex2).Cells("LotLineNumberColumn2").Value
                RowHeatQuantity = Me.dgvAddedLotNumbers.Rows(RowIndex2).Cells("HeatQuantityColumn2").Value
                RowLotNumber = Me.dgvAddedLotNumbers.Rows(RowIndex2).Cells("LotNumberColumn2").Value

                'Save data to Shipment Lot Number Table
                cmd = New SqlCommand("UPDATE ShipmentLineLotNumbers SET HeatQuantity = @HeatQuantity WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotLineNumber = @LotLineNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLineNumber
                    .Add("@LotLineNumber", SqlDbType.VarChar).Value = RowLotLineNumber
                    .Add("@HeatQuantity", SqlDbType.VarChar).Value = RowHeatQuantity
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                '**********************************************************************************************************
                'ROUTINE FOR SAVING/UPDATING CERT PDFS
                '**********************************************************************************************************

                'Dim GetRowHeatNumberStatement As String = "SELECT HeatNumber FROM LotNumber WHERE LotNumber = @LotNumber"
                'Dim GetRowHeatNumberCommand As New SqlCommand(GetRowHeatNumberStatement, con)
                'GetRowHeatNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber

                'Dim GetRowPartNumberStatement As String = "SELECT PartNumber FROM LotNumber WHERE LotNumber = @LotNumber"
                'Dim GetRowPartNumberCommand As New SqlCommand(GetRowPartNumberStatement, con)
                'GetRowPartNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber

                'If con.State = ConnectionState.Closed Then con.Open()
                'Try
                'GetRowHeatNumber = CStr(GetRowHeatNumberCommand.ExecuteScalar)
                'Catch ex As Exception
                'GetRowHeatNumber = ""
                'End Try
                'Try
                'GetRowPartNumber = CStr(GetRowPartNumberCommand.ExecuteScalar)
                'Catch ex As Exception
                'GetRowPartNumber = ""
                'End Try
                'con.Close()

                'Auto-save certs into folder structure
                'GlobalCertCustomer = cboCustomerID.Text
                'GlobalCertHeatNumber = GetRowHeatNumber
                'GlobalCertShipmentNumber = Val(cboShipmentNumber.Text)
                'GlobalCertLotNumber = RowLotNumber
                'GlobalDivisionCode = cboDivisionID.Text
                'GlobalCertPartNumber = GetRowPartNumber

                'Using NewPrintTWCert As New PrintTWCert
                'Dim result = NewPrintTWCert.ShowDialog()
                'End Using

                'Delete Cert Batch if it exists
                'Dim NewDeleteString As String = ""
                ' Dim DeleteDivision As String = ""
                'Dim CertShipment As String
                'CertShipment = CStr(GlobalCertShipmentNumber)

                'DeleteDivision = cboDivisionID.Text
                'NewDeleteString = "\\TFP-FS\TransferData\ExportedCerts\" + GlobalDivisionCode + "\" + GlobalCertCustomer + " Shipment #" + CertShipment + ".pdf"

                'Try
                'Delete pdf Cert File in folder for this item
                'My.Computer.FileSystem.DeleteFile(NewDeleteString)
                'Catch ex As Exception
                'Skip - no batch to delete 
                'End Try

                '**********************************************************************************************************
                'ROUTINE FOR SAVING/UPDATING CERT PDFS
                '**********************************************************************************************************
            Else
                'skip
            End If
        Catch ex As Exception
            'Skip update
        End Try
    End Sub

    Private Sub dgvShipmentLines_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentLines.CellClick
        If dgvShipmentLines.RowCount <> 0 Then
            Dim RowShipmentLineNumber As Integer

            Dim RowIndex As Integer = Me.dgvShipmentLines.CurrentCell.RowIndex

            RowShipmentLineNumber = Me.dgvShipmentLines.Rows(RowIndex).Cells("ShipmentLineNumberColumn").Value
            cboShipmentLineNumber2.Text = RowShipmentLineNumber
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub dgvShipmentLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentLines.CellValueChanged
        Dim RowShipmentLine As Integer
        Dim RowBoxWeight, RowTaxRate, OldQuantity, RowQuantity, RowLineBoxes, RowLineWeight, RowPrice, RowExtendedAmount, RowSalesTax As Double
        Dim RowLineComment, RowSerialNumber, RowPartNumber As String

        'Initialize Variables
        RowShipmentLine = 0
        RowExtendedAmount = 0
        RowLineBoxes = 0
        RowLineComment = ""
        RowLineWeight = 0
        RowPrice = 0
        RowQuantity = 0
        RowSalesTax = 0
        RowSerialNumber = ""
        RowTaxRate = 0
        OldQuantity = 0

        If Me.dgvShipmentLines.RowCount <> 0 Then
            Dim GetShipmentStatus As String

            'Validate that shipment is pending and not shipped
            Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
            GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetShipmentStatus = CStr(GetShipmentStatusCommand.ExecuteScalar)
            Catch ex As Exception
                GetShipmentStatus = ""
            End Try
            con.Close()

            If GetShipmentStatus <> "PENDING" Then
                MsgBox("This shipment has already been processed.", MsgBoxStyle.OkOnly)

                ClearAllData()
                ClearVariables()
                Exit Sub
            End If
            '**********************************************************************************
            Dim RowIndex As Integer = Me.dgvShipmentLines.CurrentCell.RowIndex

            Try
                RowShipmentLine = Me.dgvShipmentLines.Rows(RowIndex).Cells("ShipmentLineNumberColumn").Value
            Catch ex As Exception
                RowShipmentLine = 0
            End Try
            Try
                RowQuantity = Me.dgvShipmentLines.Rows(RowIndex).Cells("QuantityShippedColumn").Value
            Catch ex As Exception
                RowQuantity = 0
            End Try
            Try
                RowLineBoxes = Me.dgvShipmentLines.Rows(RowIndex).Cells("LineBoxesColumn").Value
            Catch ex As Exception
                RowLineBoxes = 0
            End Try
            Try
                RowLineWeight = Me.dgvShipmentLines.Rows(RowIndex).Cells("LineWeightColumn").Value
            Catch ex As Exception
                RowLineWeight = 0
            End Try
            Try
                RowLineComment = Me.dgvShipmentLines.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                RowLineComment = ""
            End Try
            Try
                RowSerialNumber = Me.dgvShipmentLines.Rows(RowIndex).Cells("SerialNumberColumn").Value
            Catch ex As Exception
                RowSerialNumber = ""
            End Try
            Try
                RowPartNumber = Me.dgvShipmentLines.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                RowPartNumber = ""
            End Try
            Try
                RowPrice = Me.dgvShipmentLines.Rows(RowIndex).Cells("PriceColumn").Value
            Catch ex As Exception
                RowPrice = 0
            End Try
            Try
                RowSalesTax = Me.dgvShipmentLines.Rows(RowIndex).Cells("SalesTaxColumn").Value
            Catch ex As Exception
                RowSalesTax = 0
            End Try
            Try
                RowBoxWeight = Me.dgvShipmentLines.Rows(RowIndex).Cells("BoxWeightColumn").Value
            Catch ex As Exception
                RowBoxWeight = 0
            End Try

            'Round Line Weight
            RowLineWeight = Math.Round(RowLineWeight, 1)

            'Get Extended Amount and update tax
            If RowPrice <> 0 Then
                RowExtendedAmount = RowQuantity * RowPrice
                RowExtendedAmount = Math.Round(RowExtendedAmount, 2)
            Else
                RowExtendedAmount = 0
            End If

            'Recalculate Line Sales Tax in case of changes
            If RowSalesTax > 0 And RowExtendedAmount <> 0 Then
                RowTaxRate = RowSalesTax / RowExtendedAmount
                RowSalesTax = RowTaxRate * RowQuantity * RowPrice
                RowSalesTax = Math.Round(RowSalesTax, 2)
            Else
                RowTaxRate = 0
                RowSalesTax = 0
            End If

            'Get Old Quantity and check against new quantity
            Dim OldQuantityStatement As String = "SELECT QuantityShipped FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND DivisionID = @DivisionID"
            Dim OldQuantityCommand As New SqlCommand(OldQuantityStatement, con)
            OldQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            OldQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLine
            OldQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                OldQuantity = CDbl(OldQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                OldQuantity = 0
            End Try
            con.Close()

            If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
                Dim OldLineWeight As Double = 0

                'Check to see if current line weight equals saved line weight
                Dim OldLineWeightStatement As String = "SELECT LineWeight FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND DivisionID = @DivisionID"
                Dim OldLineWeightCommand As New SqlCommand(OldLineWeightStatement, con)
                OldLineWeightCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                OldLineWeightCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLine
                OldLineWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    OldLineWeight = CDbl(OldLineWeightCommand.ExecuteScalar)
                Catch ex As Exception
                    OldLineWeight = 0
                End Try
                con.Close()

                'Round Old Line Weight
                OldLineWeight = Math.Round(OldLineWeight, 1)

                If OldLineWeight = RowLineWeight Then
                    If Me.dgvShipmentLines.Rows(RowIndex).Cells("BoxWeightColumn").Value <> 0 Then
                        'Calculate Line Weight by Boxes
                        Dim LinePieceWeight As Double
                        Dim LineBoxCount As Double
                        Dim NumberOfBoxes As Double

                        'Get Old Quantity and check against new quantity
                        Dim LinePieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                        Dim LinePieceWeightCommand As New SqlCommand(LinePieceWeightStatement, con)
                        LinePieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
                        LinePieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim LineBoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                        Dim LineBoxCountCommand As New SqlCommand(LineBoxCountStatement, con)
                        LineBoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
                        LineBoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LinePieceWeight = CDbl(LinePieceWeightCommand.ExecuteScalar)
                        Catch ex As Exception
                            LinePieceWeight = 0
                        End Try
                        Try
                            LineBoxCount = CDbl(LineBoxCountCommand.ExecuteScalar)
                        Catch ex As Exception
                            LineBoxCount = 0
                        End Try
                        con.Close()

                        If LineBoxCount <> 0 Then
                            NumberOfBoxes = RowQuantity / LineBoxCount

                            RowLineWeight = NumberOfBoxes * RowBoxWeight
                            RowLineWeight = Math.Round(RowLineWeight, 2)

                            Me.dgvShipmentLines.Rows(RowIndex).Cells("LineWeightColumn").Value = RowLineWeight
                        Else
                            'skip update
                        End If
                    Else
                        If OldQuantity = RowQuantity Then
                            'Skip auto-calc for Line Boxes and Line weight
                        Else
                            Dim LinePieceWeight As Double
                            Dim LineBoxCount As Integer

                            'Get Old Quantity and check against new quantity
                            Dim LinePieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim LinePieceWeightCommand As New SqlCommand(LinePieceWeightStatement, con)
                            LinePieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
                            LinePieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            Dim LineBoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim LineBoxCountCommand As New SqlCommand(LineBoxCountStatement, con)
                            LineBoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
                            LineBoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                LinePieceWeight = CDbl(LinePieceWeightCommand.ExecuteScalar)
                            Catch ex As Exception
                                LinePieceWeight = 0
                            End Try
                            Try
                                LineBoxCount = CInt(LineBoxCountCommand.ExecuteScalar)
                            Catch ex As Exception
                                LineBoxCount = 0
                            End Try
                            con.Close()

                            RowLineWeight = LinePieceWeight * RowQuantity
                            RowLineWeight = Math.Round(RowLineWeight, 2)

                            If LineBoxCount = 0 Then
                                RowLineBoxes = 0
                            Else
                                RowLineBoxes = RowQuantity / LineBoxCount
                                RowLineBoxes = Math.Round(RowLineBoxes, 0)
                            End If
                        End If
                    End If
                Else
                    'Skip Auto-Calc
                End If
            Else
                If OldQuantity = RowQuantity Then
                    'Skip auto-calc for Line Boxes and Line weight
                Else
                    Dim LinePieceWeight As Double
                    Dim LineBoxCount As Integer

                    'Get Old Quantity and check against new quantity
                    Dim LinePieceWeightStatement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim LinePieceWeightCommand As New SqlCommand(LinePieceWeightStatement, con)
                    LinePieceWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
                    LinePieceWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    Dim LineBoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                    Dim LineBoxCountCommand As New SqlCommand(LineBoxCountStatement, con)
                    LineBoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = RowPartNumber
                    LineBoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LinePieceWeight = CDbl(LinePieceWeightCommand.ExecuteScalar)
                    Catch ex As Exception
                        LinePieceWeight = 0
                    End Try
                    Try
                        LineBoxCount = CInt(LineBoxCountCommand.ExecuteScalar)
                    Catch ex As Exception
                        LineBoxCount = 0
                    End Try
                    con.Close()

                    RowLineWeight = LinePieceWeight * RowQuantity
                    RowLineWeight = Math.Round(RowLineWeight, 2)

                    If LineBoxCount = 0 Then
                        RowLineBoxes = 0
                    Else
                        RowLineBoxes = RowQuantity / LineBoxCount
                        RowLineBoxes = Math.Round(RowLineBoxes, 0)
                    End If

                    Try
                        Me.dgvShipmentLines.Rows(RowIndex).Cells("LineBoxesColumn").Value = RowLineBoxes
                        Me.dgvShipmentLines.Rows(RowIndex).Cells("LineWeightColumn").Value = RowLineWeight
                    Catch ex As Exception
                        'Skip line update
                    End Try
                End If
            End If

            'Check Lines
            CheckLinesForComplete()

            Try
                'UPDATE ShipmentLineTable
                cmd = New SqlCommand("UPDATE ShipmentLineTable SET QuantityShipped = @QuantityShipped, LineComment = @LineComment, LineWeight = @LineWeight, LineBoxes = @LineBoxes, SalesTax = @SalesTax, ExtendedAmount = @ExtendedAmount,  SerialNumber = @SerialNumber, BoxWeight = @BoxWeight WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLine
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@QuantityShipped", SqlDbType.VarChar).Value = RowQuantity
                    .Add("@LineComment", SqlDbType.VarChar).Value = RowLineComment
                    .Add("@LineWeight", SqlDbType.VarChar).Value = RowLineWeight
                    .Add("@LineBoxes", SqlDbType.VarChar).Value = RowLineBoxes
                    .Add("@SalesTax", SqlDbType.VarChar).Value = RowSalesTax
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = RowExtendedAmount
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                    .Add("@BoxWeight", SqlDbType.VarChar).Value = RowBoxWeight
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempShipNumber As Integer = 0
                Dim strShipNumber As String
                TempShipNumber = Val(cboShipmentNumber.Text)
                strShipNumber = CStr(TempShipNumber)

                ErrorDate = Today()
                ErrorComment = "Error uopdating datagrid changes"
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Shipment Completion"
                ErrorReferenceNumber = "Shipment # " + strShipNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*******************************************************************************************************************************************
            If Val(txtActualFreight.Text) > 10000 Then
                MsgBox("Freight billed cannot be greater than $10,000.00. Check number.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*****************************************************************************************************************************************

            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                LoadShipmentTotalsCanadian()

                'Update Totals in Shipment Header
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ProductTotal = @ProductTotal, TaxTotal = @TaxTotal, Tax2Total = @Tax2Total, Tax3Total = @Tax3Total, FreightActualAmount = @FreightActualAmount, ShipmentTotal = @ShipmentTotal WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedAmount
                    .Add("@TaxTotal", SqlDbType.VarChar).Value = TaxTotal
                    .Add("@Tax2Total", SqlDbType.VarChar).Value = Tax2Total
                    .Add("@Tax3Total", SqlDbType.VarChar).Value = Tax3Total
                    .Add("@FreightActualAmount", SqlDbType.VarChar).Value = FreightCharges
                    .Add("@ShipmentTotal", SqlDbType.VarChar).Value = ShipmentTotal
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                LoadShipmentTotals()

                'Update Totals in Shipment Header
                cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ProductTotal = @ProductTotal, TaxTotal = @TaxTotal, Tax2Total = @Tax2Total, Tax3Total = @Tax3Total, FreightActualAmount = @FreightActualAmount, ShipmentTotal = @ShipmentTotal WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedAmount
                    .Add("@TaxTotal", SqlDbType.VarChar).Value = TaxTotal
                    .Add("@Tax2Total", SqlDbType.VarChar).Value = Tax2Total
                    .Add("@Tax3Total", SqlDbType.VarChar).Value = Tax3Total
                    .Add("@FreightActualAmount", SqlDbType.VarChar).Value = FreightCharges
                    .Add("@ShipmentTotal", SqlDbType.VarChar).Value = ShipmentTotal
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            LoadShippingWeight()

            TotalEstimatedWeight = Math.Round(TotalEstimatedWeight, 0)
            txtShippingWeight.Text = TotalEstimatedWeight

            'Initialize Variables
            RowShipmentLine = 0
            RowExtendedAmount = 0
            RowLineBoxes = 0
            RowLineComment = ""
            RowLineWeight = 0
            RowPrice = 0
            RowQuantity = 0
            RowSalesTax = 0
            RowSerialNumber = ""
            RowTaxRate = 0
            OldQuantity = 0
        Else
            'Skip Update
        End If
    End Sub

    Private Sub dgvOpenOrderLines_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOpenOrderLines.CellDoubleClick
        Dim RowSONumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowIndex As Integer = Me.dgvOpenOrderLines.CurrentCell.RowIndex

        RowSONumber = Me.dgvOpenOrderLines.Rows(RowIndex).Cells("OOSalesOrderKeyColumn").Value
        RowDivision = Me.dgvOpenOrderLines.Rows(RowIndex).Cells("OODivisionKeyColumn").Value

        'Choose correct print form
        If cboDivisionID.Text = "TFP" Then
            GlobalSONumber = RowSONumber
            GlobalDivisionCode = cboDivisionID.Text
            Using NewPrintTFAcknowledgement As New PrintTFAcknowledgement
                Dim result = NewPrintTFAcknowledgement.ShowDialog()
            End Using
        ElseIf cboDivisionID.Text = "ADM" Then
            GlobalSONumber = RowSONumber
            GlobalDivisionCode = RowDivision

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
                Using NewPrintSalesOrderRemote As New PrintSalesOrderRemote
                    Dim result = NewPrintSalesOrderRemote.ShowDialog()
                End Using
            Else
                Using NewPrintSalesOrder As New PrintSalesOrder
                    Dim result = NewPrintSalesOrder.ShowDialog()
                End Using
            End If
        Else
            GlobalSONumber = RowSONumber
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
                Using NewPrintSalesOrderRemote As New PrintSalesOrderRemote
                    Dim result = NewPrintSalesOrderRemote.ShowDialog()
                End Using
            Else
                Using NewPrintSalesOrder As New PrintSalesOrder
                    Dim result = NewPrintSalesOrder.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Private Sub dgvShipmentLines_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvShipmentLines.RowHeaderMouseClick
        txtLotNumber.Focus()

        If dgvShipmentLines.RowCount <> 0 Then
            Dim RowShipmentLineNumber As Integer

            Dim RowIndex As Integer = Me.dgvShipmentLines.CurrentCell.RowIndex

            RowShipmentLineNumber = Me.dgvShipmentLines.Rows(RowIndex).Cells("ShipmentLineNumberColumn").Value
            cboShipmentLineNumber2.Text = RowShipmentLineNumber
        Else
            'Do Nothing
        End If
    End Sub

    Private Sub dgvShipmentLines_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentLines.CellContentClick
        If dgvShipmentLines.RowCount <> 0 Then
            Dim RowShipmentLineNumber As Integer

            Dim RowIndex As Integer = Me.dgvShipmentLines.CurrentCell.RowIndex

            RowShipmentLineNumber = Me.dgvShipmentLines.Rows(RowIndex).Cells("ShipmentLineNumberColumn").Value
            cboShipmentLineNumber2.Text = RowShipmentLineNumber
        Else
            'Do Nothing
        End If
    End Sub

    'Command Buttons

    Private Sub cmdAddMultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddMultiple.Click
        If cboShipmentLineNumber2.Text = "" Or txtLinePartNumber2.Text = "" Then
            MsgBox("You must have a valid line # and part #.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If

        '###################################################################################
        'Run save procedure
        '*******************************************************************************************************************************************
        'Convert date if necessary
        ShipDate = dtpShipmentDate.Value
        '*******************************************************************************************************************************************
        'UPDATE Lines in case of changes in datagrid
        cmd = New SqlCommand("Update ShipmentLineTable SET ExtendedAmount = QuantityShipped * Price WHERE DivisionID = @DivisionID AND ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '*******************************************************************************************************************************************
        CheckLinesForComplete()
        '*******************************************************************************************************************************************
        'Calculate totals from the Line Amounts
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LoadShipmentTotalsCanadian()
        Else
            LoadShipmentTotals()
            AddShippingCharges()
        End If

        LoadShippingWeight()

        'Save data to Shipment Header Table
        SaveUpdateShipmentToPending()
        '*******************************************************************************************************************************************
        'Update Sales Order with new Additional Ship To if necessary
        If cboAdditionalShipTo.Text <> "" Then
            'Save additional ship to data
            SaveUpdateAdditionalShipTo()

            cmd = New SqlCommand("Update SalesOrderHeaderTable SET AdditionalShipTo = @AdditionalShipTo WHERE SalesOrderKey = @SalesOrderKey", con)
            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            cmd.Parameters.Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Else
            'Do nothing
        End If
        '*******************************************************************************************************************************************
        'UPDATE Header in case of changes in datagrid
        cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '###################################################################################
        'Declare variables for popup
        GlobalShipmentLineNumberSerial = Val(cboShipmentLineNumber2.Text)
        GlobalShipmentNumberSerial = Val(cboShipmentNumber.Text)
        GlobalShipmentPartNumberSerial = txtLinePartNumber2.Text
        GlobalDivisionCode = cboDivisionID.Text

        GlobalSOShipmentNumber = Val(cboShipmentNumber.Text)
        GlobalSOPickNumber = Val(cboPickTicketNumber.Text)

        Dim NewSelectSNForShipment As New SelectSNForShipment
        NewSelectSNForShipment.Show()

        Me.Dispose()
        Me.Close()
        '###################################################################################
    End Sub

    Private Sub cmdAddSerialNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddSerialNumber.Click
        Dim CheckSerialNumber As Integer = 0
        Dim SumSerialCost As Double = 0

        'Validate Serial Number - Open and for the correct part
        Dim CheckSerialNumberStatement As String = "SELECT COUNT(SerialNumber) FROM AssemblySerialLog WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID AND Status = @Status"
        Dim CheckSerialNumberCommand As New SqlCommand(CheckSerialNumberStatement, con)
        CheckSerialNumberCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtLinePartNumber2.Text
        CheckSerialNumberCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtLineSerialNumber2.Text
        CheckSerialNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CheckSerialNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckSerialNumber = CInt(CheckSerialNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CheckSerialNumber = 0
        End Try
        con.Close()

        If CheckSerialNumber = 0 Then
            MsgBox("Serial # does not exist or is closed.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Proceed
        End If
        '*****************************************************************************************
        'Get Serial Cost
        Dim GetSerialCost As Double = 0

        If cboDivisionID.Text = "TWE" Then
            Dim GetSerialCostStatement As String = "SELECT TotalCost FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber"
            Dim GetSerialCostCommand As New SqlCommand(GetSerialCostStatement, con)
            GetSerialCostCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtLineSerialNumber2.Text
            GetSerialCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetSerialCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtLinePartNumber2.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetSerialCost = CDbl(GetSerialCostCommand.ExecuteScalar)
            Catch ex As Exception
                GetSerialCost = 0
            End Try
            con.Close()
        Else
            Dim GetSerialCostStatement As String = "SELECT ShipmentPrice FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber"
            Dim GetSerialCostCommand As New SqlCommand(GetSerialCostStatement, con)
            GetSerialCostCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtLineSerialNumber2.Text
            GetSerialCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetSerialCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = txtLinePartNumber2.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetSerialCost = CDbl(GetSerialCostCommand.ExecuteScalar)
            Catch ex As Exception
                GetSerialCost = 0
            End Try
            con.Close()
        End If
        '*****************************************************************************************
        'Get Next Serial Line Number for this Shipment Line
        Dim LastSerialLineNumber As Integer = 0
        Dim NextSerialLineNumber As Integer = 0

        Dim LastSerialLineNumberStatement As String = "SELECT MAX(SerialLineNumber) FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
        Dim LastSerialLineNumberCommand As New SqlCommand(LastSerialLineNumberStatement, con)
        LastSerialLineNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        LastSerialLineNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber2.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastSerialLineNumber = CInt(LastSerialLineNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastSerialLineNumber = 0
        End Try
        con.Close()

        NextSerialLineNumber = LastSerialLineNumber + 1

        Try
            'UPDATE Shipment Line Serial Numbers
            cmd = New SqlCommand("INSERT INTO ShipmentLineSerialNumbers (ShipmentNumber, ShipmentLineNumber, SerialLineNumber, SerialNumber, SerialCost, SerialQuantity) Values (@ShipmentNumber, @ShipmentLineNumber, @SerialLineNumber, @SerialNumber, @SerialCost, @SerialQuantity)", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber2.Text)
                .Add("@SerialLineNumber", SqlDbType.VarChar).Value = NextSerialLineNumber
                .Add("@SerialNumber", SqlDbType.VarChar).Value = txtLineSerialNumber2.Text
                .Add("@SerialCost", SqlDbType.VarChar).Value = GetSerialCost
                .Add("@SerialQuantity", SqlDbType.VarChar).Value = 1
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '****************************************************************************************************
            'Update Extended COS for the Shipment Line
            Dim SumSerialCostStatement As String = "SELECT SUM(SerialCost) FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
            Dim SumSerialCostCommand As New SqlCommand(SumSerialCostStatement, con)
            SumSerialCostCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            SumSerialCostCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber2.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumSerialCost = CDbl(SumSerialCostCommand.ExecuteScalar)
            Catch ex As Exception
                SumSerialCost = 0
            End Try
            con.Close()
            '*****************************************************************************************************
            'Update Shipment Line Table with serial cost
            cmd = New SqlCommand("UPDATE ShipmentLineTable SET ExtendedCOS = @ExtendedCOS WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber2.Text)
                .Add("@ExtendedCOS", SqlDbType.VarChar).Value = SumSerialCost
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Load Datagrid
            ShowSerialNumbers()
        Catch ex As Exception
            'Log error on update failure
            Dim TempShipNumber As Integer = 0
            Dim strShipNumber As String = ""
            Dim strSerialNumber As String = ""
            TempShipNumber = Val(cboShipmentNumber.Text)
            strShipNumber = CStr(TempShipNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Shipment Completion --- Add Serial Number"
            ErrorReferenceNumber = "Shipment # " + strShipNumber + ", Serial # -- " + strSerialNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()

            MsgBox("Insert Serial # failed. Verify Serial # and try again.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub cmdDeleteSerialNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSerialNumber.Click
        If dgvSerialLog.RowCount <> 0 Then
            Dim RowShipmentLineNumber As Integer
            Dim RowSerialLineNumber As Integer
            Dim RowSerialNumber As String
            Dim DeleteAssemblyPartNumber As String = ""

            Dim button As DialogResult = MessageBox.Show("Do you wish to delete the selected Serial #?", "DELETE SERIAL NUMBER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Dim RowIndex As Integer = Me.dgvSerialLog.CurrentCell.RowIndex

                RowShipmentLineNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("SLShipmentLineNumberColumn").Value
                RowSerialLineNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("SLSerialLineNumberColumn").Value
                RowSerialNumber = Me.dgvSerialLog.Rows(RowIndex).Cells("SLSerialNumberColumn").Value

                Try
                    'UPDATE Shipment Line Serial Numbers
                    cmd = New SqlCommand("DELETE FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND SerialLineNumber = @SerialLineNumber", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLineNumber
                        .Add("@SerialLineNumber", SqlDbType.VarChar).Value = RowSerialLineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Get Part Number for Serial #
                    'Get Serial Part Number from Shipment Line Table
                    Dim DeleteAssemblyPartNumberString As String = "SELECT PartNumber FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim DeleteAssemblyPartNumberCommand As New SqlCommand(DeleteAssemblyPartNumberString, con)
                    DeleteAssemblyPartNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    DeleteAssemblyPartNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLineNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        DeleteAssemblyPartNumber = CStr(DeleteAssemblyPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        DeleteAssemblyPartNumber = ""
                    End Try
                    con.Close()

                    'Update Status of Serial Number in log to OPEN
                    cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = DeleteAssemblyPartNumber
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Load datagrid
                    ShowSerialNumbers()
                Catch ex As Exception
                    'Log error on delete failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String = ""
                    Dim strSerialNumber As String = ""
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Shipment Completion --- Delete Serial Number"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber + ", Serial # -- " + strSerialNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            ElseIf button = DialogResult.No Then
                cmdDeleteSerialNumber.Focus()
            End If
        Else
            'Skip
        End If
    End Sub

    Private Sub cmdAddLotNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLotNumber.Click
        Dim GetPullTestNumber As String = ""
        Dim GetMinPartNumber As String = ""
        Dim MinTensileFilter As String = ""
        Dim MinYieldFilter As String = ""
        Dim MaxTensileFilter As String = ""
        Dim MaxYieldFilter As String = ""
        Dim ROAPercentFilter As String = ""
        Dim ElongationPercentFilter As String = ""
        Dim strMinTensile As String = ""
        Dim strMinYield As String = ""
        Dim strMaxTensile As String = ""
        Dim strMaxYield As String = ""
        Dim strROAPercent As String = ""
        Dim strElongationPercent As String = ""
        Dim CEVValueFilter As String = ""

        'Verify Lot Number Matches Part Number
        Dim LotNumberStatement As String = "SELECT PartNumber FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim LotNumberCommand As New SqlCommand(LotNumberStatement, con)
        LotNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LotPartNumber = CStr(LotNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LotPartNumber = ""
        End Try
        con.Close()

        If cboLinePartNumber.Text = LotPartNumber Then
            'Check if Heat Quantity is equal to Line Quantity
            Dim HeatQuantity As Double = Val(txtHeatQuantity.Text)
            Dim LineQuantity As Double = 0
            Dim SumHeatQuantity As Double = 0
            Dim LotNominalLength As Double = 0
            Dim LotNominalDiameter As Double = 0
            Dim LotItemClass As String = ""
            Dim PullTestNumber As String = ""
            Dim MinNominalLength As Double = 0
            Dim ShipmentCertType As String = ""
            Dim LotStatus As String = ""
            Dim MinTensile As Double = 0
            Dim MinYield As Double = 0
            Dim MaxTensile As Double = 0
            Dim MaxYield As Double = 0
            Dim ROAPercent As Double = 0
            Dim ElongationPercent As Double = 0

            'Get Lot Number Data
            Dim GetLotDataString As String = "SELECT Status, HeatNumber, NominalDiameter, NominalLength, ItemClass FROM LotNumber WHERE LotNumber = @LotNumber"
            Dim GetLotDataCommand As New SqlCommand(GetLotDataString, con)
            GetLotDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = GetLotDataCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("Status")) Then
                    LotStatus = ""
                Else
                    LotStatus = reader.Item("Status")
                End If
                If IsDBNull(reader.Item("HeatNumber")) Then
                    PartHeatNumber = ""
                Else
                    PartHeatNumber = reader.Item("HeatNumber")
                End If
                If IsDBNull(reader.Item("NominalDiameter")) Then
                    LotNominalDiameter = 0
                Else
                    LotNominalDiameter = reader.Item("NominalDiameter")
                End If
                If IsDBNull(reader.Item("NominalLength")) Then
                    LotNominalLength = 0
                Else
                    LotNominalLength = reader.Item("NominalLength")
                End If
                If IsDBNull(reader.Item("ItemClass")) Then
                    LotItemClass = ""
                Else
                    LotItemClass = reader.Item("ItemClass")
                End If
            Else
                LotStatus = ""
                PartHeatNumber = ""
                LotNominalDiameter = 0
                LotNominalLength = 0
                LotItemClass = ""
            End If
            reader.Close()
            con.Close()
            '****************************************************************************************
            'Get CEV From Heat Number Log
            Dim CEVValue As Double = 0

            Dim CEVValueStatement As String = "SELECT MAX(CEVValue) FROM HeatNumberLog WHERE HeatNumber = @HeatNumber"
            Dim CEVValueCommand As New SqlCommand(CEVValueStatement, con)
            CEVValueCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CEVValue = CDbl(CEVValueCommand.ExecuteScalar)
            Catch ex As Exception
                CEVValue = 0
            End Try
            con.Close()
            '****************************************************************************************
            'Validate Certification Type at the time of entering Lot Numbers
            Dim CheckCertType As String = ""
            Dim GetFOXCertType As String = ""

            Dim CheckCertTypeStatement As String = "SELECT CertificationType FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
            Dim CheckCertTypeCommand As New SqlCommand(CheckCertTypeStatement, con)
            CheckCertTypeCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            CheckCertTypeCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckCertType = CStr(CheckCertTypeCommand.ExecuteScalar)
                ShipmentCertType = CheckCertType
            Catch ex As Exception
                CheckCertType = ""
                ShipmentCertType = CheckCertType
            End Try
            con.Close()

            If CheckCertType = "" Or CheckCertType = "0" Then
                Dim GetFOXCertTypeStatement As String = "SELECT CertificationType FROM FOXTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim GetFOXCertTypeCommand As New SqlCommand(GetFOXCertTypeStatement, con)
                GetFOXCertTypeCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboLinePartNumber.Text
                GetFOXCertTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetFOXCertType = CStr(GetFOXCertTypeCommand.ExecuteScalar)
                    ShipmentCertType = GetFOXCertType
                Catch ex As Exception
                    GetFOXCertType = "0"
                    ShipmentCertType = GetFOXCertType
                End Try
                con.Close()

                If GetFOXCertType = "" Then
                    'If Cert Code is blank, use default
                    Dim NewGetCertCode As String = ""

                    Select Case LotItemClass
                        Case "TW DS"
                            NewGetCertCode = "1"
                        Case "TW CA"
                            NewGetCertCode = "1"
                        Case "TW SC"
                            NewGetCertCode = "1"
                        Case "TW DB"
                            NewGetCertCode = "2"
                        Case "TW TT"
                            NewGetCertCode = "6"
                        Case "TW TP"
                            NewGetCertCode = "6"
                        Case "TW CS"
                            NewGetCertCode = "6"
                        Case "TW NT"
                            NewGetCertCode = "6"
                        Case "TW PS"
                            NewGetCertCode = "1"
                        Case "TW SWR"
                            NewGetCertCode = "17"
                        Case "TW GS"
                            NewGetCertCode = "7"
                        Case "TW HX"
                            NewGetCertCode = "19"
                        Case "TW HSR"
                            NewGetCertCode = "21"
                        Case Else
                            NewGetCertCode = "0"
                    End Select

                    GetFOXCertType = NewGetCertCode
                    ShipmentCertType = GetFOXCertType
                Else
                    'Skip
                End If

                'Save data to Shipment Lot Number Table
                cmd = New SqlCommand("UPDATE ShipmentLineTable SET CertificationType = @CertificationType WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber.Text)
                    .Add("@CertificationType", SqlDbType.VarChar).Value = ShipmentCertType
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
            '****************************************************************************************
            If LotStatus <> "CLOSED" Then
                MsgBox("This Lot # has not been closed. Contact QC.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '****************************************************************************************
            'Get Requirements for the specific cert code
            Dim GetCertDataString As String = "SELECT MinTensile, MinYield, MaxTensile, MaxYield, ROAPercent, ElongationPercent FROM CertificationType WHERE CertificationCode = @CertificationCode"
            Dim GetCertDataCommand As New SqlCommand(GetCertDataString, con)
            GetCertDataCommand.Parameters.Add("@CertificationCode", SqlDbType.VarChar).Value = ShipmentCertType

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader2 As SqlDataReader = GetCertDataCommand.ExecuteReader()
            If reader2.HasRows Then
                reader2.Read()
                If IsDBNull(reader2.Item("MinTensile")) Then
                    MinTensile = 0
                Else
                    MinTensile = reader2.Item("MinTensile")
                End If
                If IsDBNull(reader2.Item("MinYield")) Then
                    MinYield = 0
                Else
                    MinYield = reader2.Item("MinYield")
                End If
                If IsDBNull(reader2.Item("ROAPercent")) Then
                    ROAPercent = 0
                Else
                    ROAPercent = reader2.Item("ROAPercent")
                End If
                If IsDBNull(reader2.Item("ElongationPercent")) Then
                    ElongationPercent = 0
                Else
                    ElongationPercent = reader2.Item("ElongationPercent")
                End If
                If IsDBNull(reader2.Item("MaxTensile")) Then
                    MaxTensile = 0
                Else
                    MaxTensile = reader2.Item("MaxTensile")
                End If
                If IsDBNull(reader2.Item("MaxYield")) Then
                    MaxYield = 0
                Else
                    MaxYield = reader2.Item("MaxYield")
                End If
            Else
                MinTensile = 0
                MinYield = 0
                MaxTensile = 0
                MaxYield = 0
                ROAPercent = 0
                ElongationPercent = 0
            End If
            reader2.Close()
            con.Close()
            '****************************************************************************************
            'Define requirements for cert type
            Select Case ShipmentCertType
                Case "0"
                    MinTensileFilter = ""
                    MinYieldFilter = ""
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "1"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = CStr(ElongationPercent)
                    strROAPercent = CStr(ROAPercent)

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = " AND ReductionPercent >= '" + strROAPercent + "'"
                    ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
                    If CEVValue <= 0.35 Then
                        CEVValueFilter = "PASS"
                    Else
                        CEVValueFilter = "FAIL"
                    End If
                Case "2"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "3"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = CStr(ROAPercent)

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
                    CEVValueFilter = "PASS"
                Case "4"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "5"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = CStr(ElongationPercent)
                    strROAPercent = CStr(ROAPercent)

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = " AND ReductionPercent >= '" + strROAPercent + "'"
                    ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
                    CEVValueFilter = "PASS"
                Case "6"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    If CEVValue <= 0.35 Then
                        CEVValueFilter = "PASS"
                    Else
                        CEVValueFilter = "FAIL"
                    End If
                Case "7"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "8"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = CStr(ElongationPercent)
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
                    CEVValueFilter = "PASS"
                Case "9"
                    strMinTensile = ""
                    strMinYield = ""
                    strElongationPercent = CStr(ElongationPercent)
                    strROAPercent = ""

                    MinTensileFilter = ""
                    MinYieldFilter = ""
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
                    CEVValueFilter = "PASS"
                Case "10"
                    strMinTensile = ""
                    strMinYield = ""
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = ""
                    MinYieldFilter = ""
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "11"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = "PASS"

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "12"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "13"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case "17"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    If CEVValue >= 0.31 And CEVValue < 0.43 Then
                        CEVValueFilter = "PASS"
                    Else
                        CEVValueFilter = "FAIL"
                    End If
                Case "20"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strMaxTensile = CStr(MaxTensile)
                    strMaxYield = CStr(MaxYield)
                    strElongationPercent = CStr(ElongationPercent)
                    strROAPercent = CStr(ROAPercent)

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = " AND UltimateYieldPSI <= '" + strMaxTensile + "'"
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = " AND Elongation2Percent >= '" + strElongationPercent + "'"
                    If CEVValue <= 0.35 Then
                        CEVValueFilter = "PASS"
                    Else
                        CEVValueFilter = "FAIL"
                    End If
                Case "21"
                    strMinTensile = CStr(MinTensile)
                    strMinYield = CStr(MinYield)
                    strElongationPercent = ""
                    strROAPercent = ""

                    MinTensileFilter = " AND UltimateYieldPSI >= '" + strMinTensile + "'"
                    MinYieldFilter = " AND Yield2PercentPSI >= '" + strMinYield + "'"
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    If CEVValue >= 0.31 And CEVValue < 0.43 Then
                        CEVValueFilter = "PASS"
                    Else
                        CEVValueFilter = "FAIL"
                    End If
                Case "CERT REQUIRED"
                    MinTensileFilter = ""
                    MinYieldFilter = ""
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
                Case Else
                    MinTensileFilter = ""
                    MinYieldFilter = ""
                    MaxTensileFilter = ""
                    MaxYieldFilter = ""
                    ROAPercentFilter = ""
                    ElongationPercentFilter = ""
                    CEVValueFilter = "PASS"
            End Select
            '****************************************************************************************
            If LotItemClass = "TW DB" Or LotItemClass = "TW PS" Or LotItemClass = "TW SWR" Then
                'Get Pull Test Number for selected Lot Number Data
                Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestQuery WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
                GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LotPartNumber
                GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()

                'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
                If GetPullTestNumber = "" Then
                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = LotNominalDiameter
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                    GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                    GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                    GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPullTestNumber = ""
                    End Try
                    con.Close()
                Else
                    'Do nothing - exact Pull Test exists
                End If

                'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
                If GetPullTestNumber = "" Then
                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = LotNominalDiameter
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                    GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                    GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                    GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPullTestNumber = ""
                    End Try
                    con.Close()
                Else
                    'Do nothing - exact Pull Test exists
                End If

                'If CEV Value Fails, Pull Test Number is NO CERT
                If CEVValueFilter = "FAIL" Then
                    GetPullTestNumber = ""
                Else
                    'Do nothing
                End If

                'If Cert Code is 17, check min tensile to yield .2% offeset times 1.25
                If ShipmentCertType = "17" And GetPullTestNumber <> "" Then
                    'Get Yield .2% from the pull test
                    Dim Yield2OffsetPSI As Double = 0
                    Dim YieldUltimatePSI As Double = 0

                    Dim Yield2OffsetPSIStatement As String = "SELECT Yield2PercentPSI FROM PullTestQuery WHERE TestNumber = @TestNumber"
                    Dim Yield2OffsetPSICommand As New SqlCommand(Yield2OffsetPSIStatement, con)
                    Yield2OffsetPSICommand.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = GetPullTestNumber

                    Dim YieldUltimatePSIStatement As String = "SELECT UltimateYieldPSI FROM PullTestQuery WHERE TestNumber = @TestNumber"
                    Dim YieldUltimatePSICommand As New SqlCommand(YieldUltimatePSIStatement, con)
                    YieldUltimatePSICommand.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = GetPullTestNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        Yield2OffsetPSI = CDbl(Yield2OffsetPSICommand.ExecuteScalar)
                    Catch ex As Exception
                        Yield2OffsetPSI = 0
                    End Try
                    Try
                        YieldUltimatePSI = CDbl(YieldUltimatePSICommand.ExecuteScalar)
                    Catch ex As Exception
                        YieldUltimatePSI = 0
                    End Try
                    con.Close()

                    If Yield2OffsetPSI * 1.25 > YieldUltimatePSI Then
                        GetPullTestNumber = ""
                    End If
                Else
                    'Skip
                End If

                'Write to error log
                If GetPullTestNumber = "" Then
                    GetPullTestNumber = "NO CERT"

                    Try
                        'Write to error log
                        cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status, UserID) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status, @UserID)", con)

                        With cmd.Parameters
                            .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                            .Add("@Date", SqlDbType.VarChar).Value = Today()
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@PartNumber", SqlDbType.VarChar).Value = cboLinePartNumber.Text
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                            .Add("@Comment", SqlDbType.VarChar).Value = "Shipment Completion"
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip
                    End Try
                End If
            ElseIf LotItemClass = "TW TT" Then
                'Get Pull Test Number for selected Lot Number Data
                Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestQuery WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
                GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LotPartNumber
                GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()

                'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
                If GetPullTestNumber = "" Then
                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = LotNominalDiameter
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                    GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                    GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                    GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPullTestNumber = ""
                    End Try
                    con.Close()
                Else
                    'Do nothing - exact Pull Test exists
                End If

                'Check for Pull Test using Steel Diameter
                If GetPullTestNumber = "" Then
                    Dim GetSteelSize As String = ""

                    Dim GetSteelSizeStatement As String = "SELECT SteelSize FROM LotNumber WHERE LotNumber = @LotNumber"
                    Dim GetSteelSizeCommand As New SqlCommand(GetSteelSizeStatement, con)
                    GetSteelSizeCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetSteelSize = CStr(GetSteelSizeCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetSteelSize = ""
                    End Try
                    con.Close()

                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND SteelSize = @SteelSize AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@SteelSize", SqlDbType.VarChar).Value = GetSteelSize
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                    GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                    GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                    GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPullTestNumber = ""
                    End Try
                    con.Close()
                Else
                    'Skip
                End If

                'If CEV Value Fails, Pull Test Number is NO CERT
                If CEVValueFilter = "FAIL" Then
                    GetPullTestNumber = ""
                Else
                    'Do nothing
                End If

                'Write to error log
                If GetPullTestNumber = "" Then
                    GetPullTestNumber = "NO CERT"

                    Try
                        'Write to error log
                        cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status, UserID) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status, @UserID)", con)

                        With cmd.Parameters
                            .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                            .Add("@Date", SqlDbType.VarChar).Value = Today()
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@PartNumber", SqlDbType.VarChar).Value = cboLinePartNumber.Text
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                            .Add("@Comment", SqlDbType.VarChar).Value = "Shipment Completion"
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip
                    End Try
                End If
            ElseIf LotItemClass = "Trufit Parts" Then
                'Skip printing cert
                'MsgBox("No cert exists for this TFP Part.", MsgBoxStyle.OkOnly)
            Else
                'Get Pull Test Number for selected Lot Number Data
                Dim GetPullTestNumberStatement As String = "SELECT TestNumber FROM PullTestQuery WHERE PartNumber = @PartNumber AND HeatNumber = @HeatNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                Dim GetPullTestNumberCommand As New SqlCommand(GetPullTestNumberStatement, con)
                GetPullTestNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = LotPartNumber
                GetPullTestNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                GetPullTestNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetPullTestNumber = CStr(GetPullTestNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetPullTestNumber = ""
                End Try
                con.Close()

                'If Pull Test for selected part and heat number does not exist, get Test Number for next longer size
                If GetPullTestNumber = "" Then
                    Dim GetMinPartNumberStatement As String = "SELECT MIN(PartNumber)FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND ItemClass = @ItemClass AND NominalDiameter = @NominalDiameter AND NominalLength >= @NominalLength AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetMinPartNumberCommand As New SqlCommand(GetMinPartNumberStatement, con)
                    GetMinPartNumberCommand.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                    GetMinPartNumberCommand.Parameters.Add("@NominalDiameter", SqlDbType.VarChar).Value = LotNominalDiameter
                    GetMinPartNumberCommand.Parameters.Add("@NominalLength", SqlDbType.VarChar).Value = LotNominalLength
                    GetMinPartNumberCommand.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = LotItemClass
                    GetMinPartNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMinPartNumber = CStr(GetMinPartNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetMinPartNumber = ""
                    End Try
                    con.Close()

                    Dim GetPullTestNumber2Statement As String = "SELECT TestNumber FROM PullTestQuery WHERE HeatNumber = @HeatNumber AND PartNumber = @PartNumber AND Status = @Status" + MinTensileFilter + MinYieldFilter + MaxTensileFilter + MaxYieldFilter + ROAPercentFilter + ElongationPercentFilter
                    Dim GetPullTestNumber2Command As New SqlCommand(GetPullTestNumber2Statement, con)
                    GetPullTestNumber2Command.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                    GetPullTestNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GetMinPartNumber
                    GetPullTestNumber2Command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "CLOSED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetPullTestNumber = CStr(GetPullTestNumber2Command.ExecuteScalar)
                    Catch ex As Exception
                        GetPullTestNumber = ""
                    End Try
                    con.Close()
                Else
                    'Do nothing - exact Pull Test exists
                End If

                'If CEV Value Fails, Pull Test Number is NO CERT
                If CEVValueFilter = "FAIL" Then
                    GetPullTestNumber = ""
                Else
                    'Do nothing
                End If

                'Write to error log
                If GetPullTestNumber = "" Then
                    GetPullTestNumber = "NO CERT"

                    Try
                        'Write to error log
                        cmd = New SqlCommand("INSERT INTO CertErrorLog (LotNumber, ShipmentNumber, Date, DivisionID, PartNumber, HeatNumber, Comment, Status, UserID) values (@LotNumber, @ShipmentNumber, @Date, @DivisionID, @PartNumber, @HeatNumber, @Comment, @Status, @UserID)", con)

                        With cmd.Parameters
                            .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                            .Add("@Date", SqlDbType.VarChar).Value = Today()
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@PartNumber", SqlDbType.VarChar).Value = cboLinePartNumber.Text
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                            .Add("@Comment", SqlDbType.VarChar).Value = "Shipment Completion"
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip
                    End Try
                End If
            End If
            '**************************************************************************************************
            'Find the next Shipment Lot Line Number to use
            Dim MAXStatement As String = "SELECT MAX(LotLineNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)
            MAXCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            MAXCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastLotLineNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As Exception
                LastLotLineNumber = 0
            End Try
            con.Close()

            NextLotLineNumber = LastLotLineNumber + 1

            'Save data to Shipment Lot Number Table
            cmd = New SqlCommand("INSERT INTO ShipmentLineLotNumbers (ShipmentNumber, ShipmentLineNumber, LotLineNumber, LotNumber, PullTestNumber, HeatQuantity) values (@ShipmentNumber, @ShipmentLineNumber, @LotLineNumber, @LotNumber, @PullTestNumber, @HeatQuantity)", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber.Text)
                .Add("@LotLineNumber", SqlDbType.VarChar).Value = NextLotLineNumber
                .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                .Add("@PullTestNumber", SqlDbType.VarChar).Value = GetPullTestNumber
                .Add("@HeatQuantity", SqlDbType.VarChar).Value = Val(txtHeatQuantity.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '*************************************************************************************
            ShowLotNumbers()
            '**********************************************************************************************************
            'If Pull Test is "NO CERT", autoprint sheet
            If GetPullTestNumber = "NO CERT" And cboDivisionID.Text = "TWD" Then
                cmd = New SqlCommand("SELECT * FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotLineNumber = @LotLineNumber AND LotNumber = @LotNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber.Text)
                    .Add("@LotLineNumber", SqlDbType.VarChar).Value = NextLotLineNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                NoCertDataset = New DataSet()

                myAdapterNoCert.SelectCommand = cmd
                myAdapterNoCert.Fill(NoCertDataset, "ShipmentLineLotNumbers")

                'Sets up viewer to display data from the loaded dataset
                Dim MyReportNoCert = New CrystalDecisions.CrystalReports.Engine.ReportDocument
                MyReportNoCert = crxnocertDetailPage1
                MyReportNoCert.SetDataSource(NoCertDataset)
                MyReportNoCert.PrintToPrinter(1, True, 1, 999)
            Else
                'Do nothing
            End If
            '********************************************************************************************
            'Clear Lot Number
            txtLotNumber.Clear()
            txtHeatQuantity.Clear()
        Else
            MsgBox("LOT Number does not match Part Number selected - please re-check.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdDeleteLotNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLotNumber.Click
        Dim RowShipmentLineNumber As Integer = 0
        Dim RowLotNumber As String = ""
        Dim RowLotLineNumber As Integer = 0
        Dim RowShipmentLine As Integer = 0
        Dim CountShipLotLines As Integer = 0

        Dim RowIndex As Integer = Me.dgvAddedLotNumbers.CurrentCell.RowIndex

        RowShipmentLineNumber = Me.dgvAddedLotNumbers.Rows(RowIndex).Cells("ShipmentLineNumberColumn2").Value
        RowLotNumber = Me.dgvAddedLotNumbers.Rows(RowIndex).Cells("LotNumberColumn2").Value
        RowLotLineNumber = Me.dgvAddedLotNumbers.Rows(RowIndex).Cells("LotLineNumberColumn2").Value
        RowShipmentLine = Me.dgvAddedLotNumbers.Rows(RowIndex).Cells("ShipmentLineNumberColumn2").Value

        'Prompt before deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete the selected Lot #?", "DELETE LOT NUMBER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            Try
                'Delete selected Lot Number from shipment
                cmd = New SqlCommand("DELETE FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotNumber = @LotNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLineNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Skip 
            End Try

            'Show updated table in datagrid
            ShowLotNumbers()

            'Re-Order Lot Line Numbers
            '*****************************************************************************************************************************************
            'Starting Temp Row Number
            Dim TempShipLotLine As Integer = 10000

            For Each row As DataGridViewRow In dgvAddedLotNumbers.Rows
                Dim cell2 As DataGridViewTextBoxCell = row.Cells("ShipmentLineNumberColumn2")

                If cell2.Value = RowShipmentLineNumber Then
                    Dim TempShipmentLotLineNumber As Integer = row.Cells("LotLineNumberColumn2").Value

                    'Reorder row numbers - assign temp row number
                    cmd = New SqlCommand("UPDATE ShipmentLineLotNumbers SET LotLineNumber = @LotLineNumber WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotLineNumber = @LotLineNumber1", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLineNumber
                        .Add("@LotLineNumber", SqlDbType.VarChar).Value = TempShipLotLine
                        .Add("@LotLineNumber1", SqlDbType.VarChar).Value = TempShipmentLotLineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    TempShipLotLine = TempShipLotLine + 1
                End If
            Next

            'Load datagrid
            ShowLotNumbers()

            'Reset starting number
            TempShipLotLine = 1

            'Re-Number Lot Lines
            For Each row As DataGridViewRow In dgvAddedLotNumbers.Rows
                Dim cell2 As DataGridViewTextBoxCell = row.Cells("ShipmentLineNumberColumn2")

                If cell2.Value = RowShipmentLineNumber Then
                    Dim TempShipmentLotLineNumber As Integer = row.Cells("LotLineNumberColumn2").Value

                    'Reorder row numbers - assign temp row number
                    cmd = New SqlCommand("UPDATE ShipmentLineLotNumbers SET LotLineNumber = @LotLineNumber WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotLineNumber = @LotLineNumber1", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLineNumber
                        .Add("@LotLineNumber", SqlDbType.VarChar).Value = TempShipLotLine
                        .Add("@LotLineNumber1", SqlDbType.VarChar).Value = TempShipmentLotLineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    TempShipLotLine = TempShipLotLine + 1
                End If
            Next

            'Show data with re-ordered lines
            ShowLotNumbers()

            '**********************************************************************************************************
            'ROUTINE FOR SAVING/UPDATING CERT PDFS
            '**********************************************************************************************************

            'Dim CertCustomer As String = ""
            'Dim CertShipment As String = ""
            'Dim CertHeatNumber As String = ""
            'Dim CertPartNumber As String = ""
            'Dim CertShipmentNumber As Integer = 0

            'CertCustomer = cboCustomerID.Text
            'CertShipmentNumber = Val(cboShipmentNumber.Text)
            'CertShipment = CStr(CertShipmentNumber)

            'Get Heat Number and part number
            'Dim GetHeatNumberStatement As String = "SELECT HeatNumber FROM LotNumber WHERE LotNumber = @LotNumber"
            'Dim GetHeatNumberCommand As New SqlCommand(GetHeatNumberStatement, con)
            'GetHeatNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber

            'If con.State = ConnectionState.Closed Then con.Open()
            'Try
            'CertHeatNumber = CStr(GetHeatNumberCommand.ExecuteScalar)
            'Catch ex As Exception
            'CertHeatNumber = ""
            'End Try
            'con.Close()

            'Dim GetPartNumberStatement As String = "SELECT PartNumber FROM ShipmentLineTable WHERE  ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND DivisionID = @DivisionID"
            'Dim GetPartNumberCommand As New SqlCommand(GetPartNumberStatement, con)
            'GetPartNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLineNumber
            'GetPartNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            'GetPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            'If con.State = ConnectionState.Closed Then con.Open()
            'Try
            'CertPartNumber = CStr(GetPartNumberCommand.ExecuteScalar)
            'Catch ex As Exception
            'CertPartNumber = ""
            'End Try
            'con.Close()

            'Dim DeleteString As String = ""
            'DeleteString = "\\TFP4\TFP Data Files\TruweldCerts\" + CertCustomer + "\" + CertShipment + " " + CertHeatNumber + " " + CertPartNumber + ".pdf"

            'Try
            'Delete pdf Cert File in folder for this item
            'My.Computer.FileSystem.DeleteFile(DeleteString)
            'Catch ex As Exception
            'Log error on update failure
            'Dim TempShipNumber As Integer = 0
            'Dim strShipNumber As String
            'TempShipNumber = Val(cboShipmentNumber.Text)
            'strShipNumber = CStr(TempShipNumber)

            'ErrorDate = Today()
            'ErrorComment = ex.ToString()
            'ErrorDivision = cboDivisionID.Text
            'ErrorDescription = "Shipment Completion --- Delete Cert PDF Failure"
            'ErrorReferenceNumber = "Delete path -- " + DeleteString
            'ErrorUser = EmployeeLoginName

            'TFPErrorLogUpdate()
            'End Try

            'Delete Cert Batch if it exists
            'Dim NewDeleteString As String = ""
            'Dim DeleteDivision As String = ""

            'DeleteDivision = cboDivisionID.Text
            'NewDeleteString = "\\TFP-FS\TransferData\ExportedCerts\" + DeleteDivision + "\" + CertCustomer + " Shipment #" + CertShipment + ".pdf"

            'Try
            'Delete pdf Cert File in folder for this item
            'My.Computer.FileSystem.DeleteFile(NewDeleteString)
            'Catch ex As Exception
            'Skip - no batch to delete
            'End Try

            '**********************************************************************************************************
            'ROUTINE FOR SAVING/UPDATING CERT PDFS
            '**********************************************************************************************************

            'Refresh datagrid
            ShowLotNumbers()
        ElseIf button = DialogResult.No Then
            cmdDeleteLotNumber.Focus()
        End If
    End Sub

    Private Sub cmdSalesOrderForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalesOrderForm.Click
        ClearVariables()
        ClearAllData()
        Dim NewSalesOrderForm As New SOForm
        NewSalesOrderForm.Show()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboShipmentNumber.Text = "" Or cboPickTicketNumber.Text = "" Or Val(cboShipmentNumber.Text) = 0 Or Val(cboPickTicketNumber.Text) = 0 Then
            MsgBox("You must have a valid Shipment/Pick Number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*****************************************************************************************************
        Dim GetShipmentStatus As String = ""

        'Validate that shipment is pending and not shipped
        Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
        GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetShipmentStatus = CStr(GetShipmentStatusCommand.ExecuteScalar)
        Catch ex As Exception
            GetShipmentStatus = ""
        End Try
        con.Close()

        If GetShipmentStatus = "PENDING" Then
            '*****************************************************************************************************************************************
            If Val(txtActualFreight.Text) > 10000 Then
                MsgBox("Freight billed cannot be greater than $10,000.00. Check number.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*******************************************************************************************************************************************
            ShipDate = dtpShipmentDate.Value
            '*******************************************************************************************************************************************
            CheckLinesForComplete()
            '*******************************************************************************************************************************************
            'UPDATE Lines in case of changes in datagrid
            cmd = New SqlCommand("Update ShipmentLineTable SET ExtendedAmount = QuantityShipped * Price WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '******************************************************************************************************************************************
            If Val(txtShippingWeight.Text) = 0 Then
                LoadShippingWeight()
                txtShippingWeight.Text = TotalEstimatedWeight
            End If
            '*******************************************************************************************************************************************
            'Calculate totals from the Line Amounts
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                LoadShipmentTotalsCanadian()
            Else
                LoadShipmentTotals()
                AddShippingCharges()
            End If
            '*******************************************************************************************************************************************
            'Save data to Shipment Header Table
            SaveUpdateShipmentToPending()

            If CheckShippingMethod = "EXIT SUB" Then
                CheckShippingMethod = ""
                Exit Sub
            End If
            '*******************************************************************************************************************************************
            'Update Sales Order with new Additional Ship To if necessary
            If cboAdditionalShipTo.Text <> "" Then
                'Create/Save Additional ShipTo Data
                SaveUpdateAdditionalShipTo()

                cmd = New SqlCommand("Update SalesOrderHeaderTable SET AdditionalShipTo = @AdditionalShipTo WHERE SalesOrderKey = @SalesOrderKey", con)
                cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                cmd.Parameters.Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                'Do nothing
            End If
            '*******************************************************************************************************************************************
            'UPDATE Lines in case of changes in datagrid
            cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber", con)
            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '*******************************************************************************************************************************************
            'Reload datagrid
            ShowData()
            ShowLotNumbers()
            '*******************************************************************************************************************************************
            MsgBox("Your data has been saved.", MsgBoxStyle.OkOnly)
        Else
            MsgBox("Shipment has already been processed.", MsgBoxStyle.OkOnly)

            ClearVariables()
            ClearAllData()
        End If
    End Sub

    Private Sub cmdPrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintLabel.Click
        InitializeBarcodeVariables()
        FillBarCodeVariables()
        Dim labels As Integer = getPalletNumber()
        Dim ship As New BarcodeLabel.shippingPallet
        ship.shipTo = V10
        ship.street = V11
        ship.address1 = V12
        ship.address2 = V17
        ship.country = V18
        ship.divisionInfo = V28
        Dim bc As New BarcodeLabel
        bc.shippingPalletLabel(ship, labels)
        bc.PrintBarcodeLine()
    End Sub

    Private Sub cmdPrintShippingLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintShippingLabel.Click
        InitializeBarcodeVariables()
        FillBarCodeVariables()
        Dim labels As Integer = getPalletNumber()
        Dim ship As New BarcodeLabel.shippingPallet
        ship.shipTo = V10
        ship.street = V11
        ship.address1 = V12
        ship.address2 = V17
        ship.country = V18
        ship.divisionInfo = V28
        Dim bc As New BarcodeLabel
        bc.shippingPalletLabel(ship, labels)
        bc.PrintBarcodeLine()
    End Sub

    Private Sub cmdPrintCustomLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintCustomLabel.Click
        If txtSpecialLabelLine1.Text = "" And txtSpecialLabelLine2.Text = "" And txtSpecialLabelLine3.Text = "" Then
            MsgBox("You must have data in at least one line.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim PalletCount As Integer = 0
        PalletCount = Val(txtNumberPallets.Text)
        If PalletCount = 0 Then PalletCount = 1

        Dim lst As New List(Of String)
        lst.Add(txtSpecialLabelLine1.Text)
        lst.Add(txtSpecialLabelLine2.Text)
        lst.Add(txtSpecialLabelLine3.Text)

        bc.blank3LineLabelPrint(lst, PalletCount)
        bc.PrintBarcodeLine("Zebra" + EmployeeCompanyCode)
    End Sub

    Private Sub cmdPrintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintBoxLabel.Click
        'Get box info
        If txtLotNumber.Text <> "" And txtHeatQuantity.Text <> "" Then
            Dim button As DialogResult = MessageBox.Show("Print partial box label using the Heat Quantity?", "PRINT LABEL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Dim GetHeatNumber As String = ""
                Dim GetPartNumber As String = ""
                Dim GetDescription As String = ""
                Dim GetPieceWeight As Double = 0
                Dim GetMaterialOrigin As String = ""
                Dim GetBoxWeight As Double = 0
                Dim GetBoxQuantity As Integer = 0
                Dim GetERSString As String = ""

                Dim GetLotNumberDataStatement As String = "SELECT HeatNumber, PartNumber, ShortDescription, PieceWeight, MaterialOrigin FROM LotNumber WHERE LotNumber = @LotNumber"
                Dim GetLotNumberDataCommand As New SqlCommand(GetLotNumberDataStatement, con)
                GetLotNumberDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = GetLotNumberDataCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("HeatNumber")) Then
                        GetHeatNumber = ""
                    Else
                        GetHeatNumber = reader.Item("HeatNumber")
                    End If
                    If IsDBNull(reader.Item("PartNumber")) Then
                        GetPartNumber = ""
                    Else
                        GetPartNumber = reader.Item("PartNumber")
                    End If
                    If IsDBNull(reader.Item("ShortDescription")) Then
                        GetDescription = ""
                    Else
                        GetDescription = reader.Item("ShortDescription")
                    End If
                    If IsDBNull(reader.Item("PieceWeight")) Then
                        GetPieceWeight = ""
                    Else
                        GetPieceWeight = reader.Item("PieceWeight")
                    End If
                    If IsDBNull(reader.Item("MaterialOrigin")) Then
                        GetMaterialOrigin = ""
                    Else
                        GetMaterialOrigin = reader.Item("MaterialOrigin")
                    End If
                Else
                    GetHeatNumber = ""
                    GetPartNumber = ""
                    GetDescription = ""
                    GetPieceWeight = 0
                    GetMaterialOrigin = ""
                End If
                reader.Close()
                con.Close()

                GetBoxQuantity = Val(txtHeatQuantity.Text)
                GetBoxWeight = GetBoxQuantity * GetPieceWeight
                GetBoxWeight = Math.Round(GetBoxWeight, 0)

                If GetPartNumber.StartsWith("DBA") Then
                    GetERSString = "ESR 2823"
                ElseIf GetPartNumber.StartsWith("CA") Then
                    GetERSString = "ESR 2577"
                ElseIf GetPartNumber.StartsWith("SC") Then
                    GetERSString = "ESR 2577"
                ElseIf GetPartNumber.StartsWith("DSC") Then
                    GetERSString = "ESR 2577"
                ElseIf GetPartNumber.StartsWith("PSR") Then
                    GetERSString = "ESR 2822"
                Else
                    GetERSString = "N/A"
                End If

                InitializeBarcodeVariables()
                'FillBarCodeVariables()

                Dim BoxLabel As New BarcodeLabel.MasterLabel

                setDescription()

                V00 = GetPartNumber
                V01 = GetBoxQuantity.ToString()
                V02 = GetBoxWeight.ToString()
                V03 = txtLotNumber.Text
                V07 = ""
                V16 = GetHeatNumber
                V09 = Today.ToShortDateString
                V03 = txtLotNumber.Text
                V23 = ""

                BoxLabel.partNumber = V00
                BoxLabel.heat = V16
                BoxLabel.dat = V09
                BoxLabel.description1 = V04
                BoxLabel.quantityPerBox = V01
                BoxLabel.weightPerBox = V02
                BoxLabel.serialLotNumber = V03
                BoxLabel.rackLocation = V23
                BoxLabel.esrNumber = GetERSString
                BoxLabel.description2 = V05
                BoxLabel.description3 = V06
                BoxLabel.customerPO = ""
                BoxLabel.country = "USA"
                BoxLabel.shift = ""

                bc.clearFormat()
                bc.masterLabelSetup(BoxLabel, 1)
                bc.PrintBarcodeLine("Zebra" + EmployeeCompanyCode)

            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        Else
            MsgBox("To print a box label, you need a lot number and box quantity.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdCompleteShipment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCompleteShipment.Click
        Dim button5 As DialogResult = MessageBox.Show("Do you wish to complete this shipment?", "COMPLETE SHIPMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button5 = DialogResult.Yes Then
            'Do nothing and continue
        ElseIf button5 = DialogResult.No Then
            Exit Sub
        End If

        'Check for zero weight and load
        If Val(txtShippingWeight.Text) = 0 Then
            LoadShippingWeight()
            txtShippingWeight.Text = TotalEstimatedWeight
        End If
        '************************************************************************************
        Dim GetShipmentStatus, QCSignOffUser As String

        'Validate that shipment is pending and not shipped
        Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus, QCSignOffUser FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
        GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetShipmentStatusCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("ShipmentStatus")) Then
                GetShipmentStatus = reader.Item("ShipmentStatus")
            Else
                GetShipmentStatus = ""
            End If
            If Not IsDBNull(reader.Item("QCSignOffUser")) Then
                QCSignOffUser = reader.Item("QCSignOffUser")
            Else
                QCSignOffUser = ""
            End If
        Else
            GetShipmentStatus = ""
            QCSignOffUser = ""
        End If
        reader.Close()
        con.Close()

        'Reload Lot Numbers
        ShowLotNumbers()
        '********************************************************************************************************************************************
        If cboDivisionID.Text.Equals("TFP") AndAlso String.IsNullOrEmpty(QCSignOffUser) Then
            MessageBox.Show("QC has not signed off on this shipment. You can't complete the shipment until they sign off on it.", "Unable to complete shipment.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If GetShipmentStatus <> "PENDING" Then
            MsgBox("This shipment has already been processed.", MsgBoxStyle.OkOnly)

            ClearAllData()
            ClearVariables()
            Exit Sub
        End If
        '*********************************************************************************************************************************************
        If txtSpecialLabelLine1.Text <> "" Or txtSpecialLabelLine2.Text <> "" Or txtSpecialLabelLine3.Text <> "" Then
            Dim CheckIfLabelWasPrinted As String = ""

            Dim CheckIfLabelWasPrintedStatement As String = "SELECT LabelsPrinted From ShippingAddressLabels WHERE PickTicketNumber = @PickTicketNumber"
            Dim CheckIfLabelWasPrintedCommand As New SqlCommand(CheckIfLabelWasPrintedStatement, con)
            CheckIfLabelWasPrintedCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckIfLabelWasPrinted = CStr(CheckIfLabelWasPrintedCommand.ExecuteScalar)
            Catch ex As Exception
                CheckIfLabelWasPrinted = ""
            End Try
            con.Close()

            If CheckIfLabelWasPrinted = "YES" Then
                'Do nothing
            Else
                MsgBox("Pallet Labels need to be printed for this order.", MsgBoxStyle.OkOnly)
            End If
        End If
        '***********************************************************************************************
        'Check to see if shipment has posted to the GL before posting
        Dim CheckShipmentInGL As Integer = 0

        Dim CheckShipmentInGLStatement As String = "SELECT COUNT(GLTransactionKey) From GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID"
        Dim CheckShipmentInGLCommand As New SqlCommand(CheckShipmentInGLStatement, con)
        CheckShipmentInGLCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        CheckShipmentInGLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckShipmentInGL = CInt(CheckShipmentInGLCommand.ExecuteScalar)
        Catch ex As Exception
            CheckShipmentInGL = 0
        End Try
        con.Close()

        If CheckShipmentInGL <> 0 Then
            MsgBox("This shipment has already been posted and cannot be processed again.", MsgBoxStyle.OkOnly)
            '******************************************************************************************************************************************
            'Log error on update failure
            Dim TempShipNumber As Integer = 0
            Dim strShipNumber As String
            TempShipNumber = Val(cboShipmentNumber.Text)
            strShipNumber = CStr(TempShipNumber)

            ErrorDate = Today()
            ErrorComment = "Shipment is already posted to G/L"
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Shipment Completion --- Shipment Header Autoclose L4510"
            ErrorReferenceNumber = "Shipment # " + strShipNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
            '******************************************************************************************************************************************
            ClearAllData()
            cboShipmentNumber.Refresh()
            LoadShipmentNumber()
            ShowData()
            ShowLotNumbers()
            ClearAllData()

            If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
                cboPickTicketNumber.Focus()
            Else
                cboShipmentNumber.Focus()
            End If

            Exit Sub
        Else
            'Do nothing and continue
        End If
        '*****************************************************************************************************************************************
        If Val(txtActualFreight.Text) > 10000 Then
            MsgBox("Freight billed cannot be greater than $10,000.00. Check number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*****************************************************************************************************************************************
        If Val(txtActualFreight.Text) <> 0 And cboShipMethod.Text = "COLLECT" Then
            MsgBox("You cannot add freight if ship method is COLLECT.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*****************************************************************************************************************************************
        'Check to see if shipment has line items
        Dim CountShipmentLines As Integer = 0

        Dim CountShipmentLinesStatement As String = "SELECT COUNT(ShipmentNumber) From ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim CountShipmentLinesCommand As New SqlCommand(CountShipmentLinesStatement, con)
        CountShipmentLinesCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        CountShipmentLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountShipmentLines = CInt(CountShipmentLinesCommand.ExecuteScalar)
        Catch ex As Exception
            CountShipmentLines = 0
        End Try
        con.Close()

        If CountShipmentLines = 0 Then
            MsgBox("This shipment has no lines and cannot be processed.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Do nothing and continue
        End If
        '******************************************************************************************************************************************
        ''Validate Date
        'Dim CurrentDate, TodaysDate As Date
        'Dim MonthOfYear, YearOfYear, TodaysMonthOfYear, TodaysYearOfYear As Integer

        'TodaysDate = Today()
        'CurrentDate = dtpShipmentDate.Value

        'MonthOfYear = CurrentDate.Month
        'YearOfYear = CurrentDate.Year
        'TodaysMonthOfYear = TodaysDate.Month
        'TodaysYearOfYear = TodaysDate.Year

        'If TodaysYearOfYear - YearOfYear > 1 Then
        '    MsgBox("You cannot post a Shipment to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
        '    Exit Sub
        'ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear < 5 And (TodaysMonthOfYear >= 1 And TodaysMonthOfYear < 5) Then
        '    MsgBox("You cannot post a Shipment to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
        '    Exit Sub
        'ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear > 5 And (TodaysMonthOfYear >= 5 And TodaysMonthOfYear <= 12) Then
        '    MsgBox("You cannot post a Shipment to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
        '    Exit Sub
        'ElseIf TodaysYearOfYear - YearOfYear = 0 And MonthOfYear < 5 And TodaysMonthOfYear >= 5 Then
        '    MsgBox("You cannot post a Shipment to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
        '    Exit Sub
        'ElseIf TodaysYearOfYear - YearOfYear < 0 Then
        '    MsgBox("You cannot post a Shipment to a future period.", MsgBoxStyle.OkOnly)
        '    Exit Sub
        'ElseIf TodaysYearOfYear - YearOfYear = 0 And TodaysMonthOfYear < MonthOfYear Then
        '    MsgBox("You cannot post a Shipment to a future period.", MsgBoxStyle.OkOnly)
        '    Exit Sub
        'Else
        '    'Date is okay --- Continue
        'End If
        ''******************************************************************************************************************************************
        'Check for Shipment and Pick Ticket Number
        If cboShipmentNumber.Text = "" Or cboPickTicketNumber.Text = "" Or Val(cboPickTicketNumber.Text) = 0 Or Val(cboShipmentNumber.Text) = 0 Then
            MsgBox("You must have a valid Shipment/Pick Ticket # selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Numbers are okay - continue
        End If
        '******************************************************************************************************************************************
        'Verify that if line is a concrete anchor, PSR Stud, or DeBar that it has a lot number
        Dim GetItemClass As String = ""
        Dim LotNumberCount As Integer = 0
        Dim LineQuantity As Double = 0

        For Each row2 As DataGridViewRow In dgvShipmentLines.Rows
            Try
                ShipmentLineNumber = row2.Cells("ShipmentLineNumberColumn").Value
            Catch ex As Exception
                ShipmentLineNumber = 1
            End Try
            Try
                PartNumber = row2.Cells("PartNumberColumn").Value
            Catch ex As Exception
                PartNumber = "NO PART"
            End Try
            Try
                LineQuantity = row2.Cells("QuantityShippedColumn").Value
            Catch ex As Exception
                LineQuantity = 0
            End Try

            If LineQuantity = 0 Then
                'Skip
            Else
                'Get Item Class
                Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
                ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetItemClass = CStr(ItemClassCommand.ExecuteScalar)
                Catch ex As Exception
                    GetItemClass = ""
                End Try
                con.Close()

                If LineQuantity = 0 Then
                    GetItemClass = "NONE"
                Else
                    'Skip
                End If

                If GetItemClass = "TW CA" Or GetItemClass = "TW SC" Or GetItemClass = "TW PS" Or GetItemClass = "TW DB" Or GetItemClass = "TW DS" Or GetItemClass = "TW TT" Or GetItemClass = "TW TP" Or GetItemClass = "NT" Or GetItemClass = "TW CS" Or GetItemClass = "TW TR" Or GetItemClass = "TW SWR" Then
                    'See if line has a lot number
                    Dim CountLotNumberStatement As String = "SELECT COUNT(LotNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim CountLotNumberCommand As New SqlCommand(CountLotNumberStatement, con)
                    CountLotNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    CountLotNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LotNumberCount = CInt(CountLotNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        LotNumberCount = 0
                    End Try
                    con.Close()

                    If LotNumberCount >= 1 And LineQuantity > 0 Then
                        'Do nothing
                    Else
                        MsgBox("One or more lines do not have a Lot Number entered for a weld stud.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If

                    LotNumberCount = 0
                    GetItemClass = ""
                    LineQuantity = 0
                Else
                    'Skip all other item classes
                End If
            End If
        Next
        '******************************************************************************************************************************************
        'Check for Shipment Lot Numbers
        Dim CheckForLotNumbers As Integer = 0

        Dim CheckForLotNumbersStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber"
        Dim CheckForLotNumbersCommand As New SqlCommand(CheckForLotNumbersStatement, con)
        CheckForLotNumbersCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckForLotNumbers = CInt(CheckForLotNumbersCommand.ExecuteScalar)
        Catch ex As Exception
            CheckForLotNumbers = 0
        End Try
        con.Close()

        If CheckForLotNumbers = 0 Then
            'Skip - no lot numbers
        Else
            For Each row As DataGridViewRow In dgvAddedLotNumbers.Rows
                Dim TempShipmentLineNumber As Integer = row.Cells("ShipmentLineNumberColumn2").Value

                'Get Shipment Line Quantity
                Dim TempLineQuantity As Double = 0
                Dim TempHeatQuantity As Double = 0

                Dim TempLineQuantityStatement As String = "SELECT QuantityShipped FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                Dim TempLineQuantityCommand As New SqlCommand(TempLineQuantityStatement, con)
                TempLineQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                TempLineQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = TempShipmentLineNumber

                Dim TempHeatQuantityStatement As String = "SELECT SUM(HeatQuantity) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                Dim TempHeatQuantityCommand As New SqlCommand(TempHeatQuantityStatement, con)
                TempHeatQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                TempHeatQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = TempShipmentLineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TempLineQuantity = CDbl(TempLineQuantityCommand.ExecuteScalar)
                Catch ex As Exception
                    TempLineQuantity = 0
                End Try
                Try
                    TempHeatQuantity = CDbl(TempHeatQuantityCommand.ExecuteScalar)
                Catch ex As Exception
                    TempHeatQuantity = 0
                End Try
                con.Close()

                If TempLineQuantity = TempHeatQuantity Then
                    'Skip - go to next line
                Else
                    MsgBox("One of more Heat Quantities do not add up to the Line Quantity. Correct and try again.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Next
        End If
        '******************************************************************************************************************************************
        If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST" Or cboDivisionID.Text = "SLC" Then
            'Check for serial numbers
            Dim TempAssemblyQuantity As Integer = 0
            Dim TempAssemblyPartNumber As String = ""
            Dim SerializedStatus As String = ""
            Dim TotalSerialLineCount As Integer = 0
            RunningSerialQuantity = 0

            For Each row As DataGridViewRow In dgvShipmentLines.Rows
                Try
                    TempAssemblyPartNumber = row.Cells("PartNumberColumn").Value
                Catch ex As Exception
                    TempAssemblyPartNumber = ""
                End Try
                Try
                    TempAssemblyQuantity = row.Cells("QuantityShippedColumn").Value
                Catch ex As Exception
                    TempAssemblyQuantity = 0
                End Try

                Dim GetPPLStatement As String = "SELECT PurchProdLineID FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetPPLCommand As New SqlCommand(GetPPLStatement, con)
                GetPPLCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = TempAssemblyPartNumber
                GetPPLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PurchaseProductLineID = CStr(GetPPLCommand.ExecuteScalar)
                Catch ex As Exception
                    PurchaseProductLineID = ""
                End Try
                con.Close()

                If PurchaseProductLineID = "ASSEMBLY" Then
                    'Get Serialized Status
                    Dim GetSerializedStatusStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                    Dim GetSerializedStatusCommand As New SqlCommand(GetSerializedStatusStatement, con)
                    GetSerializedStatusCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = TempAssemblyPartNumber
                    GetSerializedStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SerializedStatus = CStr(GetSerializedStatusCommand.ExecuteScalar)
                    Catch ex As Exception
                        SerializedStatus = "NO"
                    End Try
                    con.Close()

                    If SerializedStatus = "YES" Then
                        RunningSerialQuantity = RunningSerialQuantity + TempAssemblyQuantity
                    Else
                        'Skip
                    End If
                Else
                    'Skip To Next Line
                End If

                TempAssemblyPartNumber = ""
                TempAssemblyQuantity = 0
            Next

            Dim TotalSerialLineCountStatement As String = "SELECT SUM(SerialQuantity) FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber"
            Dim TotalSerialLineCountCommand As New SqlCommand(TotalSerialLineCountStatement, con)
            TotalSerialLineCountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalSerialLineCount = CInt(TotalSerialLineCountCommand.ExecuteScalar)
            Catch ex As Exception
                TotalSerialLineCount = 0
            End Try
            con.Close()

            If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST" Or cboDivisionID.Text = "SLC" Then
                If RunningSerialQuantity = TotalSerialLineCount Then
                    'Do nothing
                Else
                    MsgBox("Serial quantity does not match the number of S/N's entered.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If
        End If
        '******************************************************************************************************************************************
        Dim CheckStatus As String

        'Check Status of Shipment
        Dim CheckStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim CheckStatusCommand As New SqlCommand(CheckStatusStatement, con)
        CheckStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        CheckStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckStatus = CStr(CheckStatusCommand.ExecuteScalar)
        Catch ex As Exception
            CheckStatus = ""
        End Try
        con.Close()

        If CheckStatus <> "PENDING" Then
            MsgBox("Shipment has already been posted.", MsgBoxStyle.OkOnly)
            ClearAllData()
            cboShipmentNumber.Refresh()
            LoadShipmentNumber()
            ShowData()
            ShowLotNumbers()
            ClearAllData()

            If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
                cboPickTicketNumber.Focus()
            Else
                cboShipmentNumber.Focus()
            End If

            Exit Sub
        Else
            'Continue - status is okay
        End If
        '******************************************************************************************************************************************
        'Check for insufficient Line Quantities and prompt to continue

        CheckQOHForLineItems()

        If LineStockStatus = "NOSTOCK" Then
            Dim button1 As DialogResult = MessageBox.Show("Do you wish to complete this Shipment anyways?", "COMPLETE SHIPMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button1 = DialogResult.Yes Then
                'Continue
            ElseIf button1 = DialogResult.No Then
                Exit Sub
            Else
                'Continue
            End If
        End If

        '******************************************************************************************************************************************
        '******************************************************************************************************************************************

        'End of Validation

        '******************************************************************************************************************************************
        '******************************************************************************************************************************************


        '******************************************************************************************************************************************
        'Check Shipment lines for check mark to complete
        CheckLinesForComplete()
        '*******************************************************************************************************************************************
        ShipDate = dtpShipmentDate.Value
        '******************************************************************************************************************************************
        'Calculate totals from the Line Amounts
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LoadShipmentTotalsCanadian()
        Else
            LoadShipmentTotals()
            AddShippingCharges()
        End If

        LoadShippingWeight()

        If Val(txtShippingWeight.Text) = 0 Then
            txtShippingWeight.Text = TotalEstimatedWeight
        End If
        '******************************************************************************************************************************************
        'Save data to Shipment Header Table
        SaveUpdateShipmentToPending()

        If CheckShippingMethod = "EXIT SUB" Then
            CheckShippingMethod = ""

            Exit Sub
        End If
        '******************************************************************************************************************************************
        If cboAdditionalShipTo.Text <> "" Then
            SaveUpdateAdditionalShipTo()
        Else
            'Do nothing
        End If
        '******************************************************************************************************************************************
        Try
            'Total Shipment Header Table
            cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + TaxTotal + Tax2Total + Tax3Total + FreightActualAmount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempShipNumber As Integer = 0
            Dim strShipNumber As String
            TempShipNumber = Val(cboShipmentNumber.Text)
            strShipNumber = CStr(TempShipNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Shipment Completion --- Shipment Header Update Failure L4940"
            ErrorReferenceNumber = "Shipment # " + strShipNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '******************************************************************************************************************************************
        Try
            'UPDATE Shipment Line Table to show status
            cmd = New SqlCommand("Update ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND LineStatus = 'PENDING'", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                .Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex2 As Exception
            'Log error on update failure
            Dim TempShipNumber As Integer = 0
            Dim strShipNumber As String
            TempShipNumber = Val(cboShipmentNumber.Text)
            strShipNumber = CStr(TempShipNumber)

            ErrorDate = Today()
            ErrorComment = ex2.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Shipment Completion --- Ship Line Update Failure L4969"
            ErrorReferenceNumber = "Shipment # " + strShipNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '******************************************************************************************************************************************
        Try
            cmd = New SqlCommand("Update PickListHeaderTable Set PLStatus = @PLStatus WHERE PickListHeaderKey = @PickListHeaderKey", con)
            cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)
            cmd.Parameters.Add("@PLStatus", SqlDbType.VarChar).Value = "SHIPPED"

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex2 As Exception
            'Log error on update failure
            Dim TempShipNumber As Integer = 0
            Dim strShipNumber As String
            TempShipNumber = Val(cboShipmentNumber.Text)
            strShipNumber = CStr(TempShipNumber)

            ErrorDate = Today()
            ErrorComment = ex2.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Shipment Completion --- Pick List Header Update Failure L4994"
            ErrorReferenceNumber = "Shipment # " + strShipNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '******************************************************************************************************************************************
        'Determine if Customer is Standard or Consignment
        Dim CustomerClassStatement As String = "SELECT CustomerClass FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerClassCommand As New SqlCommand(CustomerClassStatement, con)
        CustomerClassCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        CustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerClass = CStr(CustomerClassCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerClass = "STANDARD"
        End Try
        con.Close()

        ''list of lines that are rentals
        Dim RentalLineList As New List(Of Integer)

        '******************************************************************************************************************************************
        'Write to General Ledger
        '******************************************************************************************************************************************
        'Extract Line data from the datagrid
        For Each row As DataGridViewRow In dgvShipmentLines.Rows
            'Initialize variables
            Dim ShipmentLineNumber As Integer
            Dim PartNumber, GLDebitAccount, GLCreditAccount, PartDescription, LineComment, LineCertType As String
            Dim GetSalesTaxRate As Double = 0
            Dim LineSalesTax As Double = 0
            Dim ExtendedAmount As Double = 0
            Dim Price As Double = 0
            Dim LineBoxes As Double = 0
            Dim QuantityShipped As Double = 0
            Dim LineWeight As Double = 0
            Dim PostDivision As String = ""

            Try
                ShipmentLineNumber = row.Cells("ShipmentLineNumberColumn").Value
            Catch ex As Exception
                ShipmentLineNumber = 1
            End Try
            Try
                PartNumber = row.Cells("PartNumberColumn").Value
            Catch ex As Exception
                PartNumber = "NO PART"
            End Try
            Try
                ExtendedAmount = row.Cells("ExtendedAmountColumn").Value
            Catch ex As Exception
                ExtendedAmount = 0
            End Try
            Try
                GLDebitAccount = row.Cells("GLDebitAccountColumn").Value
            Catch ex As Exception
                GLDebitAccount = "49999"
            End Try
            Try
                GLCreditAccount = row.Cells("GLCreditAccountColumn").Value
            Catch ex As Exception
                GLCreditAccount = "12100"
            End Try
            Try
                QuantityShipped = row.Cells("QuantityShippedColumn").Value
            Catch ex As Exception
                QuantityShipped = 0
            End Try
            Try
                PartDescription = row.Cells("PartDescriptionColumn").Value
            Catch ex As Exception
                PartDescription = ""
            End Try
            Try
                Price = row.Cells("PriceColumn").Value
            Catch ex As Exception
                Price = 0
            End Try
            Try
                LineComment = row.Cells("LineCommentColumn").Value
            Catch ex As Exception
                LineComment = ""
            End Try
            Try
                LineCertType = row.Cells("CertificationTypeColumn").Value
            Catch ex As Exception
                LineCertType = ""
            End Try
            Try
                LineBoxes = row.Cells("LineBoxesColumn").Value
            Catch ex As Exception
                LineBoxes = 0
            End Try
            Try
                LineSalesTax = row.Cells("SalesTaxColumn").Value
            Catch ex As Exception
                LineSalesTax = 0
            End Try
            Try
                LineWeight = row.Cells("LineWeightColumn").Value
            Catch ex As Exception
                LineWeight = 0
            End Try
            '******************************************************************************************************************************************
            'Get sales tax rate if applicable
            If LineSalesTax > 0 And ExtendedAmount <> 0 Then
                GetSalesTaxRate = LineSalesTax / ExtendedAmount
            Else
                GetSalesTaxRate = 0
            End If
            '******************************************************************************************************************************************
            Try
                'UPDATE PickList Line Table
                cmd = New SqlCommand("Update PickListLineTable Set LineStatus = @LineStatus WHERE PickListHeaderKey = @PickListHeaderKey AND PickListLineKey = @PickListLineKey", con)
                cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)
                cmd.Parameters.Add("@PickListLineKey", SqlDbType.VarChar).Value = ShipmentLineNumber
                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex4 As Exception
                'Log error on update failure
                Dim TempShipNumber As Integer = 0
                Dim strShipNumber As String
                TempShipNumber = Val(cboShipmentNumber.Text)
                strShipNumber = CStr(TempShipNumber)

                ErrorDate = Today()
                ErrorComment = ex4.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Shipment Completion --- Pick List Line Update Failure L5128"
                ErrorReferenceNumber = "Shipment # " + strShipNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************************************************
            'If TFP, update releases in FOX
            If cboDivisionID.Text = "TFP" And ShipmentLineNumber = 1 Then
                Try
                    'Update Fox Release Status
                    cmd = New SqlCommand("UPDATE FOXReleaseSchedule SET Status = @Status, ShippedQuantity = @ShippedQuantity, ShipDate = CURRENT_TIMESTAMP WHERE ShipmentNumber = @ShipmentNumber", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@Status", SqlDbType.VarChar).Value = "SHIPPED"
                        .Add("@ShippedQuantity", SqlDbType.VarChar).Value = QuantityShipped
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Shipment Completion --- FOX Release Schedule Update Failure L5160"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Skip - do not update FOX
            End If
            '******************************************************************************************************************************************
            'Pull Item Class for Part
            Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
            ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
            ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ItemClass = CStr(ItemClassCommand.ExecuteScalar)
            Catch ex As Exception
                ItemClass = ""
            End Try
            con.Close()
            '******************************************************************************************************************************************
            'Determine Clearing Account for specific location
            If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST" Then
                Select Case CustomerClass
                    Case "STANDARD"
                        GLDebitAccount = "49999"
                    Case "REMOTE"
                        GLDebitAccount = "12700"
                    Case "HCW"
                        If ItemClass = "TW FER" Then
                            GLDebitAccount = "51900"
                        Else
                            GLDebitAccount = "12620"
                        End If
                    Case "BCW"
                        If ItemClass = "TW FER" Then
                            GLDebitAccount = "51900"
                        Else
                            GLDebitAccount = "12610"
                        End If
                    Case "YCW"
                        If ItemClass = "TW FER" Then
                            GLDebitAccount = "51900"
                        Else
                            GLDebitAccount = "12600"
                        End If
                    Case "DCW"
                        If ItemClass = "TW FER" Then
                            GLDebitAccount = "51900"
                        Else
                            GLDebitAccount = "12630"
                        End If
                    Case "SCW"
                        If ItemClass = "TW FER" Then
                            GLDebitAccount = "51900"
                        Else
                            GLDebitAccount = "12640"
                        End If
                    Case "LCW"
                        If ItemClass = "TW FER" Then
                            GLDebitAccount = "51900"
                        Else
                            GLDebitAccount = "12650"
                        End If
                    Case "PCW"
                        If ItemClass = "TW FER" Then
                            GLDebitAccount = "51900"
                        Else
                            GLDebitAccount = "12660"
                        End If
                    Case "LSCW"
                        If ItemClass = "TW FER" Then
                            GLDebitAccount = "51900"
                        Else
                            GLDebitAccount = "12690"
                        End If
                    Case "RCW"
                        If ItemClass = "TW FER" Then
                            GLDebitAccount = "51900"
                        Else
                            GLDebitAccount = "12680"
                        End If
                    Case Else
                        GLDebitAccount = "49999"
                End Select
            ElseIf cboDivisionID.Text = "TFF" Then
                If CustomerClass = "SRL" Then
                    GLDebitAccount = "12670"
                Else
                    GLDebitAccount = "49999"
                End If
            Else
                GLDebitAccount = "49999"
            End If
            '******************************************************************************************************************************************
            'Check Line Cert Type
            Select Case ItemClass
                Case "TW CA", "TW SC", "TW PS", "TW DS", "TW TT", "TW TP", "TW NT", "TW DB", "TW CS", "TW TR", "TW SWR", "TW GS"
                    If LineCertType = "0" Or LineCertType = "" Then
                        Dim GetCertTypeFromFOX As String = "0"

                        Dim GetCertTypeFromFOXStatement As String = "SELECT CertificationType FROM FOXTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                        Dim GetCertTypeFromFOXCommand As New SqlCommand(GetCertTypeFromFOXStatement, con)
                        GetCertTypeFromFOXCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        GetCertTypeFromFOXCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetCertTypeFromFOX = CStr(GetCertTypeFromFOXCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetCertTypeFromFOX = "0"
                        End Try
                        con.Close()

                        LineCertType = GetCertTypeFromFOX

                        'Update Cert Type
                        Try
                            If LineCertType = "" Then LineCertType = "0"

                            'Update Shipment Line Table
                            cmd = New SqlCommand("UPDATE ShipmentLineTable SET CertificationType = @CertificationType WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

                            With cmd.Parameters
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                                .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber
                                .Add("@CertificationType", SqlDbType.VarChar).Value = LineCertType
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex3 As Exception
                            'Log error on update failure
                            Dim TempShipNumber As Integer = 0
                            Dim strShipNumber As String
                            TempShipNumber = Val(cboShipmentNumber.Text)
                            strShipNumber = CStr(TempShipNumber)

                            ErrorDate = Today()
                            ErrorComment = ex3.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Shipment Completion --- Ship Line Cert Type Failure L5305"
                            ErrorReferenceNumber = "Shipment # " + strShipNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    Else
                        'Skip
                    End If
                Case Else
            End Select
            '******************************************************************************************************************************************
            If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST" Or cboDivisionID.Text = "SLC" Then
                'Sum Line Cost for Serial Numbers
                Dim SerialLineCount As Integer = 0
                Dim SerialLineCost As Double = 0

                Dim SerialLineCountStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                Dim SerialLineCountCommand As New SqlCommand(SerialLineCountStatement, con)
                SerialLineCountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                SerialLineCountCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SerialLineCount = CInt(SerialLineCountCommand.ExecuteScalar)
                Catch ex As Exception
                    SerialLineCount = 0
                End Try
                con.Close()

                If SerialLineCount <> 0 Then
                    'Get Serial Cost (Summation) from Serial Lines
                    Dim SerialLineCostStatement As String = "SELECT SUM(SerialCost) FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                    Dim SerialLineCostCommand As New SqlCommand(SerialLineCostStatement, con)
                    SerialLineCostCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    SerialLineCostCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SerialLineCost = CDbl(SerialLineCostCommand.ExecuteScalar)
                    Catch ex As Exception
                        SerialLineCost = 0
                    End Try
                    con.Close()

                    FIFOExtendedAmount = SerialLineCost
                    FIFOCost = FIFOExtendedAmount / QuantityShipped
                    FIFOCost = Math.Round(FIFOCost, 4)

                    'If no cost exists for the serialized part - go to alternate costing method
                    If FIFOCost = 0 Or FIFOExtendedAmount = 0 Then
                        SerializedPart = "NO" 'This will force it to look at alternate costing
                    Else
                        SerializedPart = "YES"
                    End If
                Else
                    'Skip serial Costing - go with FIFO
                    SerializedPart = "NO"
                End If
            Else
                SerializedPart = "NO"
            End If

            '******************************************************************************************************************************************
            If SerializedPart = "YES" And (cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TST" Or cboDivisionID.Text = "SLC") Then
                'Skip FIFO Costing Method
            Else
                'Get FIFO Cost of Part

                'Define Variables used in FIFO
                Dim GetMaxTransactionNumber As Integer
                Dim GetUpperLimit As Double = 0
                Dim UpperLimit As Double = 0
                Dim QuantityRemaining As Double = 0
                Dim NextUpperLimit As Double = 0
                Dim NextLowerLimit As Double = 0
                '******************************************************************************************************************************************
                'Determine FIFO Cost on Part Number to remove from Inventory
                Dim TotalQuantityShipped As Double = 0
                Dim NoCostTierFound As String = "FALSE"
                FIFOCost = 0
                FIFOExtendedAmount = 0
                '******************************************************************************************************************************************
                'Determine Total Quantity Shipped
                Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> @Dropship AND LineStatus <> @LineStatus"
                Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
                TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                TotalQuantityShippedCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text
                TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"
                TotalQuantityShippedCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalQuantityShipped = 0
                End Try
                con.Close()
                '******************************************************************************************************************************************
                'Add Total Quantity used in assemblies
                Dim GetBuildQuantity As Double = 0

                Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
                Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
                TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = PartNumber
                TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetBuildQuantity = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
                Catch ex As Exception
                    GetBuildQuantity = 0
                End Try
                con.Close()

                GetBuildQuantity = GetBuildQuantity * -1

                TotalQuantityShipped = TotalQuantityShipped + GetBuildQuantity
                '******************************************************************************************************************************************
                'Check to see if Total Quantity Shipped falls within the Cost Tiers
                Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
                Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
                GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetMaxTransactionNumber = CInt(GetMaxTransactionNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetMaxTransactionNumber = 0
                End Try
                con.Close()

                Dim GetUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
                Dim GetUpperLimitCommand As New SqlCommand(GetUpperLimitStatement, con)
                GetUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber
                GetUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
                Catch ex As Exception
                    GetUpperLimit = 0
                End Try
                con.Close()

                If TotalQuantityShipped - QuantityShipped = 0 Then
                    TotalQuantityShipped = 1
                Else
                    TotalQuantityShipped = TotalQuantityShipped - QuantityShipped
                End If

                If TotalQuantityShipped > GetUpperLimit Then
                    'Item is beyond the Cost Tier - skip FIFO
                    FIFOCost = 0
                    FIFOExtendedAmount = 0
                Else
                    '******************************************************************************************************************************************
                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                    'Get Max Transaction Number where 
                    Dim GetMaxTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                    Dim GetMaxTransactionNumber1Command As New SqlCommand(GetMaxTransactionNumber1Statement, con)
                    GetMaxTransactionNumber1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    GetMaxTransactionNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMaxTransactionNumber1Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                    GetMaxTransactionNumber1Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMaxTransactionNumber = CInt(GetMaxTransactionNumber1Command.ExecuteScalar)
                    Catch ex As Exception
                        GetMaxTransactionNumber = 0
                    End Try
                    con.Close()

                    If GetMaxTransactionNumber = 0 Then
                        NoCostTierFound = "TRUE"
                    Else
                        Dim ItemCost2Statement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                        Dim ItemCost2Command As New SqlCommand(ItemCost2Statement, con)
                        ItemCost2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        ItemCost2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        ItemCost2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                        ItemCost2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text
                        ItemCost2Command.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                        Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                        Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                        UpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        UpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                        UpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text
                        UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            FIFOCost = CDbl(ItemCost2Command.ExecuteScalar)
                        Catch ex As Exception
                            FIFOCost = 0
                        End Try
                        Try
                            UpperLimit = CDbl(UpperLimitCommand.ExecuteScalar)
                        Catch ex As Exception
                            UpperLimit = 0
                        End Try
                        con.Close()
                    End If

                    If NoCostTierFound = "TRUE" Then
                        FIFOCost = 0
                        FIFOExtendedAmount = 0
                    Else
                        If TotalQuantityShipped + QuantityShipped > UpperLimit Then
                            'Quantity crosses a cost tier
                            QuantityRemaining = (TotalQuantityShipped + QuantityShipped) - UpperLimit

                            FIFOExtendedAmount = (UpperLimit - TotalQuantityShipped) * FIFOCost

                            'Create loop to calculate remainder of quantity
                            Do While QuantityRemaining > 0
                                Dim TempQuantity As Double = 0

                                'Get Max Transaction Number where 
                                Dim GetMaxTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                Dim GetMaxTransactionNumber2Command As New SqlCommand(GetMaxTransactionNumber2Statement, con)
                                GetMaxTransactionNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                GetMaxTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                GetMaxTransactionNumber2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    GetMaxTransactionNumber = CInt(GetMaxTransactionNumber2Command.ExecuteScalar)
                                Catch ex As Exception
                                    GetMaxTransactionNumber = 0
                                End Try
                                con.Close()

                                If GetMaxTransactionNumber = 0 Then
                                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                    Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                    NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text

                                    Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                    NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text

                                    Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                    NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        FIFOCost = CDbl(NextItemCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        FIFOCost = 0
                                    End Try
                                    Try
                                        NextUpperLimit = CDbl(NextUpperLimitCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        NextUpperLimit = 0
                                    End Try
                                    Try
                                        NextLowerLimit = CDbl(NextLowerLimitCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        NextLowerLimit = 0
                                    End Try
                                    con.Close()
                                Else
                                    'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                                    Dim NextItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                                    NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text
                                    NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                    Dim NextUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextUpperLimitCommand As New SqlCommand(NextUpperLimitStatement, con)
                                    NextUpperLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    NextUpperLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextUpperLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text
                                    NextUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                    Dim NextLowerLimitStatement As String = "SELECT LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                                    Dim NextLowerLimitCommand As New SqlCommand(NextLowerLimitStatement, con)
                                    NextLowerLimitCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                                    NextLowerLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                    NextLowerLimitCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                                    NextLowerLimitCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text
                                    NextLowerLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    Try
                                        FIFOCost = CDbl(NextItemCostCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        FIFOCost = 0
                                    End Try
                                    Try
                                        NextUpperLimit = CDbl(NextUpperLimitCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        NextUpperLimit = 0
                                    End Try
                                    Try
                                        NextLowerLimit = CDbl(NextLowerLimitCommand.ExecuteScalar)
                                    Catch ex As Exception
                                        NextLowerLimit = 0
                                    End Try
                                    con.Close()
                                End If

                                TempQuantity = (NextUpperLimit + 1) - NextLowerLimit

                                If QuantityRemaining > TempQuantity Then
                                    'Add to existing FIFO Extended Amount
                                    FIFOExtendedAmount = FIFOExtendedAmount + (TempQuantity * FIFOCost)

                                    'Redefine Quantity Remaining after the next cost tier
                                    QuantityRemaining = QuantityRemaining - TempQuantity
                                    UpperLimit = NextUpperLimit
                                Else
                                    FIFOExtendedAmount = FIFOExtendedAmount + (QuantityRemaining * FIFOCost)
                                    QuantityRemaining = 0
                                End If
                            Loop
                        Else
                            'Entire quantity falls into one cost tier
                            FIFOExtendedAmount = FIFOCost * QuantityShipped
                        End If
                    End If
                End If
                '****************************************************************************************************************************************
                'Skip alternative costing methods if item class is FERRULE and division is not TWD
                If ItemClass = "FERRULE" And cboDivisionID.Text <> "TWD" And FIFOCost = 0 Then
                    FIFOExtendedAmount = 0
                Else
                    'Run routine if no FIFO Cost is retrieved - Use Transaction Cost, Last Purchase Cost, STD Cost
                    '*****************************************************************************************************************************************
                    If FIFOCost = 0 Then
                        TransactionCost = 0
                        Dim Maxdate2 As Integer = 0

                        Dim MAXDate2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                        Dim MAXDate2Command As New SqlCommand(MAXDate2Statement, con)
                        MAXDate2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
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
                        TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        TransactionCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = Maxdate2

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            TransactionCost = 0
                        End Try
                        con.Close()

                        FIFOCost = TransactionCost
                        FIFOExtendedAmount = FIFOCost * QuantityShipped
                    End If
                    '*****************************************************************************************************************************************
                    If FIFOCost = 0 Then
                        LastPurchaseCost = 0

                        Dim MAXDateStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
                        Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
                        MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            MaxDate = CInt(MAXDateCommand.ExecuteScalar)
                        Catch ex As Exception
                            MaxDate = 0
                        End Try
                        con.Close()

                        Dim LastPriceStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
                        Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
                        LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MaxDate

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
                        Catch ex As Exception
                            LastPurchaseCost = 0
                        End Try
                        con.Close()

                        FIFOCost = LastPurchaseCost
                        FIFOExtendedAmount = FIFOCost * QuantityShipped
                    End If
                    '*****************************************************************************************************************************************
                    'If FIFO Cost = 0, pull Standard Cost from Item List
                    If FIFOCost = 0 Then
                        StandardCost = 0

                        Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
                        Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
                        StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            StandardCost = 0
                        End Try
                        con.Close()

                        FIFOCost = StandardCost
                        FIFOExtendedAmount = FIFOCost * QuantityShipped
                    End If
                End If
            End If

            '*****************************************************************************************************************************************
            'End of Costing Routine
            '*****************************************************************************************************************************************

            Dim InventoryItem As String = ""

            Dim InventoryItemStatement As String = "SELECT InventoryItem FROM ItemClass WHERE ItemClassID = @ItemClassID"
            Dim InventoryItemCommand As New SqlCommand(InventoryItemStatement, con)
            InventoryItemCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                InventoryItem = CStr(InventoryItemCommand.ExecuteScalar)
            Catch ex As Exception
                InventoryItem = "YES"
            End Try
            con.Close()

            If InventoryItem = "NO" Then
                FIFOExtendedAmount = 0
            Else
                'If none, FIFO is correct
            End If

            'Round FIFO Extended Amount
            FIFOExtendedAmount = Math.Round(FIFOExtendedAmount, 2)
            '****************************************************************************************************
            'Update Shipment Line Table with the extended Cost
            Try
                'Update Shipment Line Table
                cmd = New SqlCommand("UPDATE ShipmentLineTable SET ExtendedCOS = @ExtendedCOS WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber
                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = FIFOExtendedAmount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex3 As Exception
                'Log error on update failure
                Dim TempShipNumber As Integer = 0
                Dim strShipNumber As String
                TempShipNumber = Val(cboShipmentNumber.Text)
                strShipNumber = CStr(TempShipNumber)

                ErrorDate = Today()
                ErrorComment = ex3.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Shipment Completion --- Ship Line COS Update Failure L5800"
                ErrorReferenceNumber = "Shipment # " + strShipNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '****************************************************************************************************
            'If Customer is canadian, determine the correct gl accounts
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                'Get Vendor for specific part number to determine GL
                Dim GetVendorStatement As String = "SELECT PreferredVendor FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim GetVendorCommand As New SqlCommand(GetVendorStatement, con)
                GetVendorCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                GetVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetVendor = CStr(GetVendorCommand.ExecuteScalar)
                Catch ex As Exception
                    GetVendor = ""
                End Try
                con.Close()

                If GetVendor = "AMERICAN" Then
                    GetVendorClass = "AMERICAN"
                ElseIf GetVendor = "CANADIAN" Then
                    GetVendorClass = "CANADIAN"
                Else
                    'Get Vendor Class
                    Dim GetVendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                    Dim GetVendorClassCommand As New SqlCommand(GetVendorClassStatement, con)
                    GetVendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GetVendor
                    GetVendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetVendorClass = CStr(GetVendorClassCommand.ExecuteScalar)
                    Catch ex As Exception
                        GetVendorClass = "CANADIAN"
                    End Try
                    con.Close()
                End If

                If GetVendorClass = "AMERICAN" Then
                    'Do nothing - GL Accounts are ok
                ElseIf GetVendorClass = "CANADIAN" Then
                    GLDebitAccount = "C$" & GLDebitAccount
                    GLCreditAccount = "C$" & GLCreditAccount
                Else
                    GLDebitAccount = "C$" & GLDebitAccount
                    GLCreditAccount = "C$" & GLCreditAccount
                End If
            Else
                'Do nothing - gl accounts are correct
            End If
            '******************************************************************************************************************************************
            Try
                'Update Shipment Line Table
                cmd = New SqlCommand("UPDATE ShipmentLineTable SET QuantityShipped = @QuantityShipped, LineBoxes = @LineBoxes, ExtendedAmount = @ExtendedAmount, LineComment = @LineComment, ExtendedCOS = @ExtendedCOS, SalesTax = @SalesTax WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber
                    .Add("@QuantityShipped", SqlDbType.VarChar).Value = QuantityShipped
                    .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeight
                    .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxes
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = QuantityShipped * Price
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = FIFOExtendedAmount
                    .Add("@SalesTax", SqlDbType.VarChar).Value = QuantityShipped * Price * GetSalesTaxRate
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex3 As Exception
                'Log error on update failure
                Dim TempShipNumber As Integer = 0
                Dim strShipNumber As String
                TempShipNumber = Val(cboShipmentNumber.Text)
                strShipNumber = CStr(TempShipNumber)

                ErrorDate = Today()
                ErrorComment = ex3.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Shipment Completion --- Ship Line Update Failure L5885"
                ErrorReferenceNumber = "Shipment # " + strShipNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************************************************
            'If division is TFP, post to TWD, else post to correct division
            If cboDivisionID.Text = "TFP" Then
                PostDivision = "TWD"
            Else
                PostDivision = cboDivisionID.Text
            End If
            '******************************************************************************************************************************************
            Try
                'Command to write Line Amount to GL
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLCreditAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Shipment"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ShipDate
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Order # " & Val(txtSalesOrderNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = BatchNumber
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = ShipmentLineNumber
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                Try
                    'Command to write Line Amount to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLCreditAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Shipment"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ShipDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Order # " & Val(txtSalesOrderNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = BatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = ShipmentLineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex11 As Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex11.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Shipment Completion --- Shipment Line GL Entry L5956"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End Try
            '******************************************************************************************************************************************
            Try
                'Command to write Line Amount to GL
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLDebitAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Shipment"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ShipDate
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Order # " & Val(txtSalesOrderNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = BatchNumber
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = ShipmentLineNumber
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                Try
                    'Command to write Line Amount to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLDebitAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Shipment"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = ShipDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = FIFOExtendedAmount
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Order # " & Val(txtSalesOrderNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = BatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = ShipmentLineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex11 As Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex11.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Shipment Completion --- Shipment Line GL Entry L6021"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End Try
            '******************************************************************************************************************************************
            'Write to the inventory transaction table if it is an inventory item
            If InventoryItem = "NO" Then
                If ItemClass = "RENTAL" Then
                    If QuantityShipped > 0 Then
                        ''adds the line number to the list of the rental line numbers
                        RentalLineList.Add(ShipmentLineNumber)
                    End If
                Else
                    'Skip Inventory Transaction table
                End If
            Else
                'Write Values to Inventory Transaction Table
                If QuantityShipped = 0 Then
                    'Skip entry into Inventory Transaction Table
                Else
                    Try
                        Dim TempUnitCost As Double = 0

                        TempUnitCost = FIFOExtendedAmount / QuantityShipped
                        TempUnitCost = Math.Round(TempUnitCost, 5)

                        'Write Data to the Inventory Transaction Table
                        cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                        With cmd.Parameters
                            '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextInventoryTransactionNumber
                            .Add("@TransactionDate", SqlDbType.VarChar).Value = ShipDate
                            .Add("@TransactionType", SqlDbType.VarChar).Value = "Customer Shipment"
                            .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                            .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@Quantity", SqlDbType.VarChar).Value = QuantityShipped
                            .Add("@ItemCost", SqlDbType.VarChar).Value = TempUnitCost
                            .Add("@ItemPrice", SqlDbType.VarChar).Value = Price
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                            .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@TransactionMath", SqlDbType.VarChar).Value = "SUBTRACT"
                            .Add("@GLAccount", SqlDbType.VarChar).Value = GLCreditAccount
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempShipNumber As Integer = 0
                        Dim strShipNumber As String
                        TempShipNumber = Val(cboShipmentNumber.Text)
                        strShipNumber = CStr(TempShipNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Shipment Completion --- Inventory Transaction Update Failure L6084"
                        ErrorReferenceNumber = "Shipment # " + strShipNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
                '**********************************************************************************************
                'Check to see of Shipment is for a consignment warehouse
                Dim Consignment As String = ""

                If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TST" Then
                    If txtCustomerClass.Text = "STANDARD" Then
                        Consignment = "NO"
                    ElseIf txtCustomerClass.Text = "AMERICAN" Then
                        Consignment = "NO"
                    ElseIf txtCustomerClass.Text = "CANADIAN" Then
                        Consignment = "NO"
                    ElseIf txtCustomerClass.Text = "SRL" Then
                        Consignment = "YES"
                    ElseIf txtCustomerClass.Text = "DCW" Then
                        Consignment = "YES"
                    ElseIf txtCustomerClass.Text = "HCW" Then
                        Consignment = "YES"
                    ElseIf txtCustomerClass.Text = "PCW" Then
                        Consignment = "YES"
                    ElseIf txtCustomerClass.Text = "SCW" Then
                        Consignment = "YES"
                    ElseIf txtCustomerClass.Text = "LCW" Then
                        Consignment = "YES"
                    ElseIf txtCustomerClass.Text = "YCW" Then
                        Consignment = "YES"
                    ElseIf txtCustomerClass.Text = "BCW" Then
                        Consignment = "YES"
                    ElseIf txtCustomerClass.Text = "RCW" Then
                        Consignment = "YES"
                    ElseIf txtCustomerClass.Text = "LSCW" Then
                        Consignment = "YES"
                    Else
                        Consignment = "NO"
                    End If
                Else
                    Consignment = "NO"
                End If

                If Consignment = "YES" Then
                    'Re-Check Unit Cost
                    If QuantityShipped <> 0 Then
                        FIFOCost = FIFOExtendedAmount / QuantityShipped
                        FIFOCost = Math.Round(FIFOCost, 4)
                    End If

                    Try
                        'adds the entry into the consignment shipping table
                        cmd = New SqlCommand("INSERT INTO ConsignmentShippingTable (ConsignmentShipNumber, PartNumber, PartDescription, QuantityShipped, UnitCost, UnitPrice, ExtendedCost, ExtendedAmount, DivisionID, ShipDate, ShipmentNumber, CustomerClass) VALUES((SELECT isnull(MAX(ConsignmentShipNumber) + 1, 910001) FROM ConsignmentShippingTable), @PartNumber, @PartDescription, @QuantityShipped, @UnitCost, @UnitPrice, @ExtendedCost, @ExtendedAmount, @DivisionID, @ShipDate, @ShipmentNumber, @CustomerClass)", con)

                        With cmd.Parameters
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("QuantityShipped", SqlDbType.VarChar).Value = QuantityShipped
                            .Add("@UnitCost", SqlDbType.VarChar).Value = FIFOCost
                            .Add("@UnitPrice", SqlDbType.VarChar).Value = Price
                            .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@ShipDate", SqlDbType.VarChar).Value = ShipDate
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = cboShipmentNumber.Text
                            .Add("@CustomerClass", SqlDbType.VarChar).Value = txtCustomerClass.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempShipNumber As Integer = 0
                        Dim strShipNumber As String
                        TempShipNumber = Val(cboShipmentNumber.Text)
                        strShipNumber = CStr(TempShipNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Shipment Completion --- INSERT Consignment Failure L6167"
                        ErrorReferenceNumber = "Shipment # " + strShipNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '***************************************************************************************************************************
                    Try
                        'Write Data to the Inventory Transaction Table
                        cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber, PartDescription, Quantity, ItemCost, ItemPrice, ExtendedAmount, ExtendedCost, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), @TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ItemPrice, @ExtendedAmount, @ExtendedCost, @DivisionID, @TransactionMath, @GLAccount)", con)

                        With cmd.Parameters
                            '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextITNumber2
                            .Add("@TransactionDate", SqlDbType.VarChar).Value = ShipDate
                            .Add("@TransactionType", SqlDbType.VarChar).Value = "Consignment Shipping"
                            .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                            .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@Quantity", SqlDbType.VarChar).Value = QuantityShipped
                            .Add("@ItemCost", SqlDbType.VarChar).Value = FIFOCost
                            .Add("@ItemPrice", SqlDbType.VarChar).Value = Price
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                            .Add("@ExtendedCost", SqlDbType.VarChar).Value = FIFOExtendedAmount
                            .Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerClass.Text
                            .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                            .Add("@GLAccount", SqlDbType.VarChar).Value = GLCreditAccount
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempShipNumber As Integer = 0
                        Dim strShipNumber As String
                        TempShipNumber = Val(cboShipmentNumber.Text)
                        strShipNumber = CStr(TempShipNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Shipment Completion --- Consignment Inv. Trans. Update Failure L6209"
                        ErrorReferenceNumber = "Shipment # " + strShipNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    'Enter Item ID into Item List
                    Try
                        'Create command to update database and fill with text box enties
                        cmd = New SqlCommand("Insert Into ItemList(ItemID, DivisionID, ShortDescription, LongDescription, ItemClass, PurchProdLineID, SalesProdLineID, PieceWeight, BoxCount, PalletCount, StandardCost, StandardPrice, OldPartNumber, MinimumStock, MaximumStock, CreationDate, BeginningBalance, BoxType, NominalDiameter, NominalLength, AddAccessory, PreferredVendor, Locked, SafetyDataSheet)Values(@ItemID, @DivisionID, @ShortDescription, @LongDescription, @ItemClass, @PurchProdLineID, @SalesProdLineID, @PieceWeight, @BoxCount, @PalletCount, @StandardCost, @StandardPrice, @OldPartNumber, @MinimumStock, @MaximumStock, @CreationDate, @BeginningBalance, @BoxType, @NominalDiameter, @NominalLength, @AddAccessory, @PreferredVendor, @Locked, @SafetyDataSheet)", con)

                        With cmd.Parameters
                            .Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerClass.Text
                            .Add("@ShortDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@LongDescription", SqlDbType.VarChar).Value = PartDescription
                            .Add("@ItemClass", SqlDbType.VarChar).Value = ItemClass
                            .Add("@PurchProdLineID", SqlDbType.VarChar).Value = "TWD-PURCHASEPRODUCTS"
                            .Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SPL-TWD"
                            .Add("@PieceWeight", SqlDbType.VarChar).Value = 0
                            .Add("@BoxCount", SqlDbType.VarChar).Value = 0
                            .Add("@PalletCount", SqlDbType.VarChar).Value = 0
                            .Add("@StandardCost", SqlDbType.VarChar).Value = FIFOCost
                            .Add("@StandardPrice", SqlDbType.VarChar).Value = 0
                            .Add("@OldPartNumber", SqlDbType.VarChar).Value = ""
                            .Add("@MinimumStock", SqlDbType.VarChar).Value = 0
                            .Add("@MaximumStock", SqlDbType.VarChar).Value = 0
                            .Add("@CreationDate", SqlDbType.VarChar).Value = ShipDate
                            .Add("@BeginningBalance", SqlDbType.VarChar).Value = 0
                            .Add("@BoxType", SqlDbType.VarChar).Value = "Z"
                            .Add("@NominalDiameter", SqlDbType.VarChar).Value = 0
                            .Add("@NominalLength", SqlDbType.VarChar).Value = 0
                            .Add("@AddAccessory", SqlDbType.VarChar).Value = "NO"
                            .Add("@PreferredVendor", SqlDbType.VarChar).Value = "TFP CORP"
                            .Add("@Locked", SqlDbType.VarChar).Value = ""
                            .Add("@SafetyDataSheet", SqlDbType.VarChar).Value = ""
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Skip - not a new part
                    End Try

                    'Enter into Cost Tier for Warehouse ID

                    'Extract the Upper and Lower Limit of the Inventory Costing Table
                    Dim NewUpperLimitCosting, LowerLimitCosting, UpperLimitCosting As Double
                    Dim MaxTransactionNumber As Integer

                    Dim MaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                    Dim MaxTransactionNumberCommand As New SqlCommand(MaxTransactionNumberStatement, con)
                    MaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    MaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerClass.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        MaxTransactionNumber = CInt(MaxTransactionNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        MaxTransactionNumber = 0
                    End Try
                    con.Close()

                    Dim UpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
                    Dim UpperLimitCommand As New SqlCommand(UpperLimitStatement, con)
                    UpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = MaxTransactionNumber
                    UpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerClass.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        UpperLimitCosting = CDbl(UpperLimitCommand.ExecuteScalar)
                    Catch ex As Exception
                        UpperLimitCosting = 0
                    End Try
                    con.Close()

                    'Calculate the NEW Lower/Upper Limit for the next post
                    LowerLimitCosting = UpperLimitCosting + 1
                    NewUpperLimitCosting = LowerLimitCosting + QuantityShipped - 1

                    'Get next Transaction Number
                    Dim LastCostingTransactionNumber As Integer = 0
                    Dim NextCostingTransactionNumber As Integer = 0

                    Dim CostingTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting"
                    Dim CostingTransactionNumberCommand As New SqlCommand(CostingTransactionNumberStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastCostingTransactionNumber = CInt(CostingTransactionNumberCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastCostingTransactionNumber = 63600000
                    End Try
                    con.Close()

                    NextCostingTransactionNumber = LastCostingTransactionNumber + 1

                    'Write Values to Inventory Costing Table
                    Try
                        cmd = New SqlCommand("Insert Into InventoryCosting (PartNumber, DivisionID, CostingDate, ItemCost, CostQuantity, Status, LowerLimit, UpperLimit, TransactionNumber, ReferenceNumber, ReferenceLine)values(@PartNumber, @DivisionID, @CostingDate, @ItemCost, @CostQuantity, @Status, @LowerLimit, @UpperLimit, @TransactionNumber, @ReferenceNumber, @ReferenceLine)", con)

                        With cmd.Parameters
                            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = txtCustomerClass.Text
                            .Add("@CostingDate", SqlDbType.VarChar).Value = ShipDate
                            .Add("@ItemCost", SqlDbType.VarChar).Value = FIFOCost
                            .Add("@CostQuantity", SqlDbType.VarChar).Value = QuantityShipped
                            .Add("@Status", SqlDbType.VarChar).Value = "CONSIGNMENT SHIPPING"
                            .Add("@LowerLimit", SqlDbType.VarChar).Value = LowerLimitCosting
                            .Add("@UpperLimit", SqlDbType.VarChar).Value = NewUpperLimitCosting
                            .Add("@TransactionNumber", SqlDbType.VarChar).Value = NextCostingTransactionNumber
                            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                            .Add("@ReferenceLine", SqlDbType.VarChar).Value = ShipmentLineNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Shipment Completion --- Consignment Inventory Costing L6333"
                        ErrorReferenceNumber = "Shipment # " + cboShipmentNumber.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
            End If
        Next

        '******************************************************************************************************************************************
        'End of Ledger Entry
        '******************************************************************************************************************************************

        'Update Serial Number Status in the Serial Log
        If Me.dgvSerialLog.RowCount <> 0 Then
            Dim CustomerType As String = ""
            Dim SerialDivision As String = ""
            Dim SerialStatus As String = ""

            'Check Customer for remote or Consignment
            Dim CustomerTypeStatement As String = "SELECT BillingType FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerTypeCommand As New SqlCommand(CustomerTypeStatement, con)
            CustomerTypeCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
            CustomerTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerType = CStr(CustomerTypeCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerType = "STANDARD"
            End Try
            con.Close()

            If CustomerType = "STANDARD" Then
                SerialDivision = cboDivisionID.Text
                SerialStatus = "CLOSED"
            Else
                SerialDivision = CustomerType
                SerialStatus = "OPEN"
            End If

            For Each row5 As DataGridViewRow In dgvSerialLog.Rows
                Dim RowSerialNumber As String = ""
                Dim RowShipLineNumber As Integer = 0

                Try
                    RowSerialNumber = row5.Cells("SLSerialNumberColumn").Value
                Catch ex As Exception
                    RowSerialNumber = ""
                End Try
                Try
                    RowShipLineNumber = row5.Cells("SLShipmentLineNumberColumn").Value
                Catch ex As Exception
                    RowShipLineNumber = 0
                End Try

                'Get Part Number for specific shipment line
                Dim ShipLinePartNumber As String = ""
                Dim ShipLinePrice As Double = 0

                Dim ShipLinePartNumberStatement As String = "SELECT PartNumber FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                Dim ShipLinePartNumberCommand As New SqlCommand(ShipLinePartNumberStatement, con)
                ShipLinePartNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                ShipLinePartNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipLineNumber

                Dim ShipLinePriceStatement As String = "SELECT Price FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                Dim ShipLinePriceCommand As New SqlCommand(ShipLinePriceStatement, con)
                ShipLinePriceCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                ShipLinePriceCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipLineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ShipLinePartNumber = CStr(ShipLinePartNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    ShipLinePartNumber = ""
                End Try
                Try
                    ShipLinePrice = CDbl(ShipLinePriceCommand.ExecuteScalar)
                Catch ex As Exception
                    ShipLinePrice = 0
                End Try
                con.Close()

                'Update Serial Log with Customer, Division, Status
                cmd = New SqlCommand("Update AssemblySerialLog SET DivisionID = @DivisionID, CustomerID = @CustomerID, Status = @Status, ShipmentNumber = @ShipmentNumber, ShipmentDate = @ShipmentDate, BatchNumber = @BatchNumber, ShipmentPrice = @ShipmentPrice WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID2", con)

                With cmd.Parameters
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = ShipLinePartNumber
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                    .Add("@DivisionID2", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = SerialDivision
                    .Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
                    .Add("@Status", SqlDbType.VarChar).Value = SerialStatus
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentDate", SqlDbType.VarChar).Value = dtpShipmentDate.Text
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = RowShipLineNumber
                    .Add("@ShipmentPrice", SqlDbType.VarChar).Value = ShipLinePrice
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                RowSerialNumber = ""
                RowShipLineNumber = 0
            Next
        End If
        '******************************************************************************************************************************************
        'Update Sales Order Header Table after line updates
        Dim GSTTotal, PSTTotal, HSTTotal As Double

        Dim SUMSOExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim SUMSOExtendedAmountCommand As New SqlCommand(SUMSOExtendedAmountStatement, con)
        SUMSOExtendedAmountCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SUMSOExtendedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SUMSOSalesTaxStatement As String = "SELECT SUM(SalesTax) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim SUMSOSalesTaxCommand As New SqlCommand(SUMSOSalesTaxStatement, con)
        SUMSOSalesTaxCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SUMSOSalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SUMSOLineWeightStatement As String = "SELECT SUM(LineWeight) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID"
        Dim SUMSOLineWeightCommand As New SqlCommand(SUMSOLineWeightStatement, con)
        SUMSOLineWeightCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        SUMSOLineWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim HeaderFreightTotalStatement As String = "SELECT FreightCharge FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim HeaderFreightTotalCommand As New SqlCommand(HeaderFreightTotalStatement, con)
        HeaderFreightTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        HeaderFreightTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim GSTTotalStatement As String = "SELECT TotalSalesTax FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim GSTTotalCommand As New SqlCommand(GSTTotalStatement, con)
        GSTTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        GSTTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PSTTotalStatement As String = "SELECT TotalSalesTax2 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim PSTTotalCommand As New SqlCommand(PSTTotalStatement, con)
        PSTTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        PSTTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim HSTTotalStatement As String = "SELECT TotalSalesTax3 FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim HSTTotalCommand As New SqlCommand(HSTTotalStatement, con)
        HSTTotalCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        HSTTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SUMSOExtendedAmount = CDbl(SUMSOExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            SUMSOExtendedAmount = 0
        End Try
        Try
            SUMSOSalesTax = CDbl(SUMSOSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            SUMSOSalesTax = 0
        End Try
        Try
            SUMSOLineWeight = CDbl(SUMSOLineWeightCommand.ExecuteScalar)
        Catch ex As Exception
            SUMSOLineWeight = 0
        End Try
        Try
            HeaderFreightTotal = CDbl(HeaderFreightTotalCommand.ExecuteScalar)
        Catch ex As Exception
            HeaderFreightTotal = 0
        End Try
        Try
            GSTTotal = CDbl(GSTTotalCommand.ExecuteScalar)
        Catch ex As Exception
            GSTTotal = 0
        End Try
        Try
            PSTTotal = CDbl(PSTTotalCommand.ExecuteScalar)
        Catch ex As Exception
            PSTTotal = 0
        End Try
        Try
            HSTTotal = CDbl(HSTTotalCommand.ExecuteScalar)
        Catch ex As Exception
            HSTTotal = 0
        End Try
        con.Close()

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            SOHeaderTotal = HeaderFreightTotal + GSTTotal + PSTTotal + HSTTotal + SUMSOExtendedAmount
            SumSalesTax = GSTTotal
        Else
            SOHeaderTotal = HeaderFreightTotal + SUMSOSalesTax + SUMSOExtendedAmount
            PSTTotal = 0
            HSTTotal = 0
        End If
        '******************************************************************************************************************************************
        Try
            'UPDATE Totals to Sales Order Header
            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET TotalSalesTax = @TotalSalesTax, TotalSalesTax2 = @TotalSalesTax2, TotalSalesTax3 = @TotalSalesTax3, ProductTotal = @ProductTotal, SOTotal = @SOTotal, ShippingWeight = @ShippingWeight WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@TotalSalesTax", SqlDbType.VarChar).Value = SUMSOSalesTax
                .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = PSTTotal
                .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = HSTTotal
                .Add("@ProductTotal", SqlDbType.VarChar).Value = SUMSOExtendedAmount
                .Add("@SOTotal", SqlDbType.VarChar).Value = SOHeaderTotal
                .Add("@ShippingWeight", SqlDbType.VarChar).Value = SUMSOLineWeight
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempShipNumber As Integer = 0
            Dim strShipNumber As String
            TempShipNumber = Val(cboShipmentNumber.Text)
            strShipNumber = CStr(TempShipNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Shipment Completion --- SO Header Update Failure L6555"
            ErrorReferenceNumber = "Shipment # " + strShipNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '******************************************************************************************************************************************
        'Finish Routine
        '******************************************************************************************************************************************

        'Check Lines
        CheckLinesForComplete()

        '******************************************************************************************************************************************
        'Check line status to update Sales Order Line Table
        '******************************************************************************************************************************************
        For Each row As DataGridViewRow In dgvShipmentLines.Rows
            Dim GridSOLineKey As Integer = 0
            Dim GridShipmentLineKey As Integer = 0

            Try
                GridSOLineKey = row.Cells("SOLineNumberColumn").Value
            Catch ex As Exception
                GridSOLineKey = 0
            End Try
            Try
                GridShipmentLineKey = row.Cells("ShipmentLineNumberColumn").Value
            Catch ex As Exception
                GridShipmentLineKey = 0
            End Try

            Dim OrderQuantityString As String = "SELECT QuantityOrdered FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey AND DivisionKey = @DivisionKey"
            Dim OrderQuantityCommand As New SqlCommand(OrderQuantityString, con)
            OrderQuantityCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            OrderQuantityCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GridSOLineKey
            OrderQuantityCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim QuantityShippedString As String = "SELECT SUM(QuantityShipped) FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey AND DivisionKey = @DivisionKey"
            Dim QuantityShippedCommand As New SqlCommand(QuantityShippedString, con)
            QuantityShippedCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            QuantityShippedCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GridSOLineKey
            QuantityShippedCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim QuantityShippedPendingString As String = "SELECT SUM(PendingShippingQuantity) FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey AND DivisionKey = @DivisionKey"
            Dim QuantityShippedPendingCommand As New SqlCommand(QuantityShippedPendingString, con)
            QuantityShippedPendingCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            QuantityShippedPendingCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GridSOLineKey
            QuantityShippedPendingCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SOOrderQuantity = CDbl(OrderQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                SOOrderQuantity = 0
            End Try
            Try
                SOQuantityShipped = CDbl(QuantityShippedCommand.ExecuteScalar)
            Catch ex As Exception
                SOQuantityShipped = 0
            End Try
            Try
                SOQuantityShippedPending = CDbl(QuantityShippedPendingCommand.ExecuteScalar)
            Catch ex As Exception
                SOQuantityShippedPending = 0
            End Try
            con.Close()

            If (SOQuantityShipped + SOQuantityShippedPending) >= SOOrderQuantity Then
                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GridSOLineKey
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Update Notification Table
                Try
                    cmd = New SqlCommand("UPDATE NotificationTable SET Status = 'COMPLETED' WHERE ReferenceNumber = @SalesOrderKey AND Details LIKE '%' + (SELECT Description FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey) + '%'", con)

                    With cmd.Parameters
                        .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GridSOLineKey
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Shipment Completion --- Notification Complete failure"
                    ErrorReferenceNumber = "Shipment # " + cboShipmentNumber.Text
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GridSOLineKey
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
            '******************************************************************************************************************************************
            Dim CompleteLinecell As DataGridViewCheckBoxCell = row.Cells("CompleteLineColumn")

            If CompleteLinecell.Value = "SELECTED" Then
                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GridSOLineKey
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                'Skip
            End If
        Next
        '******************************************************************************************************************************************
        'Re-check SO Header Table to see if all lines are closed
        Dim AnyOpenLine As Integer

        Dim AnyOpenLineString As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND LineStatus = @LineStatus"
        Dim AnyOpenLineCommand As New SqlCommand(AnyOpenLineString, con)
        AnyOpenLineCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
        AnyOpenLineCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AnyOpenLineCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AnyOpenLine = CInt(AnyOpenLineCommand.ExecuteScalar)
        Catch ex As Exception
            AnyOpenLine = 0
        End Try
        con.Close()

        'If one line is open, then sales order is open
        If AnyOpenLine = 0 Then
            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@SOStatus", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Else
            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
        '******************************************************************************************************************************************
        'Check Sales Order Price for each Shipment Line and see if there are any changes and update if needed
        Dim ShipmentLineSalesTax, ShipmentLineQuantity, ShipmentLinePrice, SOLinePrice, LineExtendedAmount, NewLineSalesTax, LineSalesTaxRate As Double
        Dim ShipmentLineNumber2, ShipmentSOLineNumber As Integer

        For Each row As DataGridViewRow In dgvShipmentLines.Rows
            Try
                ShipmentLineNumber2 = row.Cells("ShipmentLineNumberColumn").Value
            Catch ex As Exception
                ShipmentLineNumber2 = 0
            End Try
            Try
                ShipmentLinePrice = row.Cells("PriceColumn").Value
            Catch ex As Exception
                ShipmentLinePrice = 0
            End Try
            Try
                ShipmentSOLineNumber = row.Cells("SOLineNumberColumn").Value
            Catch ex As Exception
                ShipmentSOLineNumber = 0
            End Try
            Try
                ShipmentLineQuantity = row.Cells("QuantityShippedColumn").Value
            Catch ex As Exception
                ShipmentLineQuantity = 0
            End Try
            Try
                ShipmentLineSalesTax = row.Cells("SalesTaxColumn").Value
            Catch ex As Exception
                ShipmentLineSalesTax = 0
            End Try

            'Get SO Line Price
            Dim SOLinePriceString As String = "SELECT Price FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND SalesOrderLineKey = @SalesOrderLineKey"
            Dim SOLinePriceCommand As New SqlCommand(SOLinePriceString, con)
            SOLinePriceCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
            SOLinePriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SOLinePriceCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = ShipmentSOLineNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SOLinePrice = CDbl(SOLinePriceCommand.ExecuteScalar)
            Catch ex As Exception
                SOLinePrice = 0
            End Try
            con.Close()

            'If Sales Order Price equals shipment price skip line
            If SOLinePrice = ShipmentLinePrice Then
                'Do nothing - skip to next line
            Else
                Try
                    LineExtendedAmount = SOLinePrice * ShipmentLineQuantity
                    LineExtendedAmount = Math.Round(LineExtendedAmount, 2)
                    If ShipmentLineQuantity = 0 Then
                        LineSalesTaxRate = 0
                        NewLineSalesTax = 0
                    Else
                        LineSalesTaxRate = ShipmentLineSalesTax / ShipmentLineQuantity
                        NewLineSalesTax = LineSalesTaxRate * LineExtendedAmount
                        NewLineSalesTax = Math.Round(NewLineSalesTax, 2)
                    End If

                    'Recalculate Shipment Totals
                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET Price = @Price, ExtendedAmount = @ExtendedAmount, SalesTax = @SalesTax WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber2
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Price", SqlDbType.VarChar).Value = SOLinePrice
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@SalesTax", SqlDbType.VarChar).Value = NewLineSalesTax
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Skip
                End Try
            End If
        Next
        '******************************************************************************************************************************************
        'UPDATE Shipment Header Table with changes
        '******************************************************************************************************************************************
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LoadShipmentTotalsCanadian()
        Else
            LoadShipmentTotals()
        End If
        '******************************************************************************************************************************************
        Try
            'Update shipment totals
            cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentTotal = @ShipmentTotal, FreightActualAmount = @FreightActualAmount, ProductTotal = @ProductTotal, TaxTotal = @TaxTotal, Tax2Total = @Tax2Total, Tax3Total = @Tax3Total, ShipmentStatus = @ShipmentStatus, PrintDate = @PrintDate, ShippingWeight =@ShippingWeight, PostedBy = @PostedBy WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ShipmentTotal", SqlDbType.VarChar).Value = ShipmentTotal
                .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtActualFreight.Text)
                .Add("@ProductTotal", SqlDbType.VarChar).Value = SumExtendedAmount
                .Add("@TaxTotal", SqlDbType.VarChar).Value = TaxTotal
                .Add("@Tax2Total", SqlDbType.VarChar).Value = Tax2Total
                .Add("@Tax3Total", SqlDbType.VarChar).Value = Tax3Total
                .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
                .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
                .Add("@ShippingWeight", SqlDbType.VarChar).Value = Val(txtShippingWeight.Text)
                .Add("@PostedBy", SqlDbType.VarChar).Value = EmployeeLoginName
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempShipNumber As Integer = 0
            Dim strShipNumber As String
            TempShipNumber = Val(cboShipmentNumber.Text)
            strShipNumber = CStr(TempShipNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Shipment Completion --- Shipment Header Update Failure L6857"
            ErrorReferenceNumber = "Shipment # " + strShipNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '******************************************************************************************************************************************
        Try
            'Recalculate Shipment Totals
            cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempShipNumber As Integer = 0
            Dim strShipNumber As String
            TempShipNumber = Val(cboShipmentNumber.Text)
            strShipNumber = CStr(TempShipNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Shipment Completion --- Shipment Header Update Failure L6886"
            ErrorReferenceNumber = "Shipment # " + strShipNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
        '*****************************************************************************************************************************************
        'Print all shipping documents
        Dim button As DialogResult = MessageBox.Show("Your shipment has been completed - do you wish to print Shipping Documents?", "PRINT SHIPPING DOCUMENTS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Check to make sure at least one cert will print otherwise do not open Print Form
            Dim CheckForCerts As Integer = 0

            'Get Pull Test Number for selected Lot Number Data
            Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
            CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader2 As SqlDataReader = CheckForCertsCommand.ExecuteReader()
            If reader2.HasRows Then
                reader2.Read()
                If IsDBNull(reader2.Item("CountShipmentNumber")) Then
                    CheckForCerts = 0
                Else
                    CheckForCerts = reader2.Item("CountShipmentNumber")
                End If
            Else
                CheckForCerts = 0
            End If
            reader2.Close()
            con.Close()

            If CheckForCerts = 0 Then
                GlobalCheckIfCertsWillPrint = "NO"
            Else
                GlobalCheckIfCertsWillPrint = "YES"
            End If

            Dim CheckForNoCerts As Integer = 0

            'Check to see if there are any certs that will not print
            Dim CheckForNoCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountNoCerts FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND PullTestNumber = @PullTestNumber"
            Dim CheckForNoCertsCommand As New SqlCommand(CheckForNoCertsStatement, con)
            CheckForNoCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            CheckForNoCertsCommand.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = "NO CERT"

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader3 As SqlDataReader = CheckForNoCertsCommand.ExecuteReader()
            If reader3.HasRows Then
                reader3.Read()
                If IsDBNull(reader3.Item("CountNoCerts")) Then
                    CheckForNoCerts = 0
                Else
                    CheckForNoCerts = reader3.Item("CountNoCerts")
                End If
            Else
                CheckForNoCerts = 0
            End If
            reader3.Close()
            con.Close()

            If CheckForNoCerts = 0 Then
                'Set Global Variable to NO
                GlobalPrintNoCertPage = "NO"
            Else
                'Set Global Variable to YES
                GlobalPrintNoCertPage = "YES"
            End If

            GlobalShipmentNumber = Val(cboShipmentNumber.Text)
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintAllShippingDocs As New PrintAllShippingDocs
                Dim Result = NewPrintAllShippingDocs.ShowDialog()
            End Using
        ElseIf button = DialogResult.No Then
            'continue
        End If

        '******************************************************************************************************************************************

        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        'If any rentals were found this will check to see if there are notifications if not will add them for the remaining quantity (months)
        'IF ALL COMPANIES ARE ABLE THE DIVISION CHECK NEEDS REMOVED
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

        If RentalLineList.Count > 0 And (cboDivisionID.Text.Equals("TWE") Or cboDivisionID.Text.Equals("TST")) Then
            cmd = New SqlCommand("SELECT COUNT(NotificationKey) FROM NotificationTable WHERE NotificationType = 'Recurring Invoice' AND ReferenceNumber = @ReferenceNumber", con)
            cmd.Parameters.Add("@ReferenceNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            ''only wil ladd notifications for sales orders that have no notifications for recurring invoices
            If cmd.ExecuteScalar() = 0 Then
                cmd = New SqlCommand("SELECT SalesOrderLineKey, ItemID, case when (QuantityOrdered - QuantityShipped) < 0 then 0 else (QuantityOrdered - QuantityShipped) END as QuantityRemaining FROM SalesOrderQuantityStatus WHERE DivisionKey = @DivisionID AND SalesOrderKey = @SalesOrderNumber AND SalesOrderLineKey in (SELECT SOLineNumber FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                cmd.Parameters.Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)

                ''iterates through the line numbers and adds them into the query
                For i As Integer = 0 To RentalLineList.Count - 1
                    If i = 0 Then
                        cmd.CommandText += " AND (ShipmentLineNumber = @ShipmentLineNumber" + i.ToString()
                    Else
                        cmd.CommandText += " OR ShipmentLineNumber = @ShipmentLineNumber" + i.ToString()
                    End If
                    cmd.Parameters.Add("@ShipmentLineNumber" + i.ToString(), SqlDbType.VarChar).Value = RentalLineList(i)
                Next
                cmd.CommandText += ")) ORDER BY QuantityRemaining DESC"
                Dim tempds As New DataSet()
                Dim adap As New SqlDataAdapter(cmd)

                If con.State = ConnectionState.Closed Then con.Open()
                adap.Fill(tempds, "SOQuantityStatus")

                ''makes sure there are rows and if so will generate the notifications based on the remaining quantitys
                If tempds.Tables("SOQuantityStatus").Rows.Count > 0 Then
                    ''declares the next new NotificationKey, the next new GroupID and gets the EmployeeID of the person that createed the SO
                    cmd = New SqlCommand("DECLARE @NotificationKey as int = (SELECT isnull(MAX(NotificationKey) +1, 1) FROM NotificationTable), @GroupID as int = (SELECT isnull(MAX(GroupID) + 1, 1) FROM NotificationTable), @EmployeeID as varchar(50) = (SELECT EmployeeID FROM EmployeeData WHERE SalesPersonID = (SELECT SalesPerson FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderNumber AND DivisionKey = @DivisionID));", con)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    cmd.Parameters.Add("@SalesOrderNumber", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    cmd.Parameters.Add("@AddedBy", SqlDbType.VarChar).Value = EmployeeLoginName

                    cmd.CommandText += " INSERT INTO NotificationTable (NotificationKey, DivisionID, EmployeeID, NotificationType, ReferenceNumber, Frequency, NotificationDateTime, Details, Status, AddedBy, GroupID, SnoozeTime) VALUES"
                    ''goes through the quantity remaining for the line item with the most remaining
                    Dim LastDate As New DateTime(Now.Year, Now.Month, Now.Day, 8, 0, 0)

                    Dim NotificationsToAdd As Boolean = False
                    For i As Integer = 0 To tempds.Tables("SOQuantityStatus").Rows(0).Item("QuantityRemaining") - 1
                        NotificationsToAdd = True
                        Dim details As String = "Customer: " + txtCustomerID.Text + Environment.NewLine + "Part Number(s): "
                        If i = 0 Then
                            cmd.CommandText += " (@NotificationKey + " + i.ToString() + ", @DivisionID, @EmployeeID, 'Recurring Invoice', @SalesOrderNumber, 'Recurring', @NotificationDateTime" + i.ToString() + ", @Details" + i.ToString() + ", 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        Else
                            cmd.CommandText += ", (@NotificationKey + " + i.ToString() + ", @DivisionID, @EmployeeID, 'Recurring Invoice', @SalesOrderNumber, 'Recurring', @NotificationDateTime" + i.ToString() + ", @Details" + i.ToString() + ", 'ACTIVE', @AddedBy, @GroupID, @NotificationDateTime" + i.ToString() + ")"
                        End If

                        ''goes through the all the lines and adds the part numbers for each who should be on the notification
                        For j As Integer = 0 To tempds.Tables("SOQuantityStatus").Rows.Count - 1
                            If tempds.Tables("SOQuantityStatus").Rows(j).Item("QuantityRemaining") >= i Then
                                If j = 0 Then
                                    details += tempds.Tables("SOQuantityStatus").Rows(j).Item("ItemID").ToString()
                                Else
                                    details += ", " + tempds.Tables("SOQuantityStatus").Rows(j).Item("ItemID").ToString()
                                End If
                            End If
                        Next
                        cmd.Parameters.Add("@Details" + i.ToString(), SqlDbType.VarChar).Value = details

                        cmd.Parameters.Add("@NotificationDateTime" + i.ToString(), SqlDbType.DateTime).Value = LastDate.AddMonths(i + 1)
                    Next
                    If NotificationsToAdd Then
                        Try
                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                        Catch ex As System.Exception
                            ErrorDate = Today()
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "ShipmentCompletion - cmdCompleteShipment --Error trying to set notifications for rentals. L7047"
                            ErrorReferenceNumber = "Shipment # " + cboShipmentNumber.Text
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try

                        If con.State = ConnectionState.Open Then con.Close()
                    End If

                End If
            End If
        End If
        '***********************************************************************************************************************
        'Auto email packing slip to customers who require it
        Dim PackingListEmail As String = ""
        Dim PackingListFileName As String = ""
        Dim EmailShipmentNumber As Integer = 0
        Dim strShipmentNumber As String = ""

        EmailShipmentNumber = Val(cboShipmentNumber.Text)
        strShipmentNumber = CStr(EmailShipmentNumber)

        PackingListFileName = cboDivisionID.Text + strShipmentNumber + ".pdf"

        Dim PackingListEmailString As String = "SELECT PackingListEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim PackingListEmailCommand As New SqlCommand(PackingListEmailString, con)
        PackingListEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        PackingListEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PackingListEmail = CStr(PackingListEmailCommand.ExecuteScalar)
        Catch ex As Exception
            PackingListEmail = ""
        End Try
        con.Close()

        If PackingListEmail = "" Then
            'Skip
        Else
            'Attach and send email
            '***********************************************************************************************
            'Check if file exists
            If File.Exists("\\TFP-FS\TransferData\TruweldPackList\" + PackingListFileName) Then
                '***********************************************************************************************
                Try
                    'Set up email to be sent
                    Dim MyMailMessage As New MailMessage()
                    MyMailMessage.From = New MailAddress("packinglist@tfpcorp.com")

                    'Add array of email addresses if necessay
                    'Parse email field to determine how many addresses 
                    If PackingListEmail.Contains(";") Then
                        Dim EmailArray As Array
                        Dim ArrayCount As Integer = 0
                        Dim CurrentEmail As String = ""

                        EmailArray = Split(PackingListEmail, ";")
                        ArrayCount = UBound(EmailArray) + 1
                        Dim Counter As Integer = 1

                        For i As Integer = 0 To UBound(EmailArray)
                            CurrentEmail = EmailArray(ArrayCount - Counter)
                            MyMailMessage.To.Add(CurrentEmail)
                            Counter = Counter + 1
                        Next
                    Else
                        MyMailMessage.To.Add(PackingListEmail)
                    End If

                    MyMailMessage.Attachments.Add(New Attachment("\\TFP-FS\TransferData\TruweldPackList\" + PackingListFileName))
                    MyMailMessage.Subject = "Packing List / TFP Corporation"
                    MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
                    MyMailMessage.Body = "Auto-sent Packing List for customer. Do not reply to this email address. Contact truweld@tfpcorp.com"
                    Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                    SMPT.Port = "587"
                    SMPT.EnableSsl = False
                    SMPT.Credentials = New System.Net.NetworkCredential("packinglist@tfpcorp.com", "1422325bogie")
                    SMPT.Send(MyMailMessage)
                Catch ex As Exception
                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    If ErrorComment.Length > 400 Then
                        ErrorComment = ErrorComment.Substring(0, 399)
                    End If
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "ShipmentCompletion - Packing List not emailed. L7134"
                    ErrorReferenceNumber = "Shipment # " + cboShipmentNumber.Text
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Skip
            End If
        End If

        PackingListEmail = ""
        PackingListFileName = ""
        EmailShipmentNumber = 0
        strShipmentNumber = ""
        '***********************************************************************************************************************
        Dim CheckIfNoCerts As Integer = 0

        Dim CheckIfNoCertsString As String = "SELECT COUNT(ShipmentNumber) FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim CheckIfNoCertsCommand As New SqlCommand(CheckIfNoCertsString, con)
        CheckIfNoCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        CheckIfNoCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckIfNoCerts = CInt(CheckIfNoCertsCommand.ExecuteScalar)
        Catch ex As Exception
            CheckIfNoCerts = 0
        End Try
        con.Close()

        If CheckIfNoCerts = 0 Then
            'Skip
        Else
            'Auto email certs to customers who require it
            Dim CertEmail As String = ""
            Dim CertFileName As String = ""
            Dim CertShipmentNumber As Integer = 0
            Dim strCertShipmentNumber As String = ""

            CertShipmentNumber = Val(cboShipmentNumber.Text)
            strCertShipmentNumber = CStr(CertShipmentNumber)

            CertFileName = cboDivisionID.Text + "CERT" + strCertShipmentNumber + ".pdf"

            Dim CertEmailString As String = "SELECT CertEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CertEmailCommand As New SqlCommand(CertEmailString, con)
            CertEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
            CertEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CertEmail = CStr(CertEmailCommand.ExecuteScalar)
            Catch ex As Exception
                CertEmail = ""
            End Try
            con.Close()

            If CertEmail = "" Then
                'Skip
            Else
                'Attach and send email

                'Check for lot numbers for this shipment
                If Me.dgvAddedLotNumbers.RowCount > 0 Then
                    'Continue

                    'Create cert batch
                    'Loads data into dataset for viewing
                    cmd = New SqlCommand("SELECT * from TruweldCertData where ShipmentNumber = @ShipmentNumber AND PullTestNumber <> 'NO CERT'", con)
                    cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

                    cmd1 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                    cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    cmd2 = New SqlCommand("SELECT * FROM DivisionTable", con)

                    cmd3 = New SqlCommand("SELECT * FROM PullTestLineTable WHERE PullTestLineNumber < 3", con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    CertDataset = New DataSet()

                    myAdapter.SelectCommand = cmd
                    myAdapter.Fill(CertDataset, "TruweldCertData")

                    myAdapter1.SelectCommand = cmd1
                    myAdapter1.Fill(CertDataset, "CustomerList")

                    myAdapter2.SelectCommand = cmd2
                    myAdapter2.Fill(CertDataset, "DivisionTable")

                    myAdapter3.SelectCommand = cmd3
                    myAdapter3.Fill(CertDataset, "PullTestLineTable")

                    CertReport = crxtwCert011
                    CertReport.SetDataSource(CertDataset)
                    CertReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" + CertFileName)

                    Try
                        'Set up email to be sent
                        Dim MyMailMessage As New MailMessage()
                        MyMailMessage.From = New MailAddress("packinglist@tfpcorp.com")

                        'Add array of email addresses if necessay
                        'Parse email field to determine how many addresses 
                        If CertEmail.Contains(";") Then
                            Dim EmailArray As Array
                            Dim ArrayCount As Integer = 0
                            Dim CurrentEmail As String = ""

                            EmailArray = Split(CertEmail, ";")
                            ArrayCount = UBound(EmailArray) + 1
                            Dim Counter As Integer = 1

                            For i As Integer = 0 To UBound(EmailArray)
                                CurrentEmail = EmailArray(ArrayCount - Counter)
                                MyMailMessage.To.Add(CurrentEmail)
                                Counter = Counter + 1
                            Next
                        Else
                            MyMailMessage.To.Add(CertEmail)
                        End If

                        MyMailMessage.Attachments.Add(New Attachment("\\TFP-FS\TransferData\TruweldPackList\" + CertFileName))
                        MyMailMessage.Subject = "Certs / TFP Corporation"
                        MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
                        MyMailMessage.Body = "Auto-sent Certs for customer. Do not reply to this email address. Contact truweld@tfpcorp.com"
                        Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                        SMPT.Port = "587"
                        SMPT.EnableSsl = False
                        SMPT.Credentials = New System.Net.NetworkCredential("packinglist@tfpcorp.com", "1422325bogie")
                        SMPT.Send(MyMailMessage)
                    Catch ex As Exception
                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        If ErrorComment.Length > 400 Then
                            ErrorComment = ErrorComment.Substring(0, 399)
                        End If
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "ShipmentCompletion - Cert not emailed. L7255"
                        ErrorReferenceNumber = "Shipment # " + cboShipmentNumber.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                Else
                    'Skip
                End If
            End If

            CertEmail = ""
            CertFileName = ""
            CertShipmentNumber = 0
            strCertShipmentNumber = ""
        End If
        '***********************************************************************************************************************
        'If division = CHT and Customer is TFPCORP, then run PO Routine
        If cboDivisionID.Text = "CHT" And txtCustomerID.Text = "TFP CORP" Then
            RunChattanoogaRoutine()
        Else
            'Skip routine
        End If
        '***********************************************************************************************************************
        ClearAllData()
        cboShipmentNumber.Refresh()
        LoadShipmentNumber()
        ShowData()
        ShowLotNumbers()
        ClearAllData()

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            cboPickTicketNumber.Focus()
        Else
            cboShipmentNumber.Focus()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearAllData()
        ClearShipmentLines()
        ClearSerialNumbers()
        ClearOpenOrders()
        ClearLotNumbers()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboShipmentNumber.Text = "" Then
            MsgBox("You must have a valid Shipment Number selected.", MsgBoxStyle.OkOnly)
        Else
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Shipment?", "DELETE SHIPMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Verify that Shipment has not been posted.
                'Check to see if shipment has posted to the GL before posting
                Dim CheckShipmentInGL As Integer

                Dim CheckShipmentInGLStatement As String = "SELECT COUNT(GLTransactionKey) From GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID"
                Dim CheckShipmentInGLCommand As New SqlCommand(CheckShipmentInGLStatement, con)
                CheckShipmentInGLCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                CheckShipmentInGLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckShipmentInGL = CInt(CheckShipmentInGLCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckShipmentInGL = 0
                End Try
                con.Close()

                If CheckShipmentInGL = 0 Then
                    Try
                        'Reopen Sales Order
                        cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
                        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempShipNumber As Integer = 0
                        Dim TempSONumber As Integer = 0
                        Dim strShipNumber As String = ""
                        Dim strSONumber As String = ""
                        TempShipNumber = Val(cboShipmentNumber.Text)
                        TempSONumber = Val(txtSalesOrderNumber.Text)
                        strShipNumber = CStr(TempShipNumber)
                        strSONumber = CStr(TempSONumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Shipment Completion --- Re-Open Sales Order failure on delete"
                        ErrorReferenceNumber = "Shipment # " + strShipNumber + ", SO # " + strSONumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    If cboDivisionID.Text = "TFP" Then
                        'If TFP, update FOX Releases
                        cmd = New SqlCommand("UPDATE FOXReleaseSchedule SET ShippedQuantity = @ShippedQuantity, ShipDate = @ShipDate, Status = @Status, ShipmentNumber = @ShipmentNumber WHERE ShipmentNumber = @ShipmentNumber1 AND Status = @Status1", con)
                        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                        cmd.Parameters.Add("@ShipmentNumber1", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        cmd.Parameters.Add("@Status1", SqlDbType.VarChar).Value = "PENDING"
                        cmd.Parameters.Add("@ShippedQuantity", SqlDbType.VarChar).Value = 0
                        cmd.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = ""

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        'Do nothing, no link to FOX
                    End If
                    '*************************************************************************************************************
                    'Write to Audit Trail Table
                    Dim AuditComment As String = ""
                    Dim AuditShipmentNumber As Integer = 0
                    Dim strShipmentNumber As String = ""

                    AuditShipmentNumber = Val(cboShipmentNumber.Text)
                    strShipmentNumber = CStr(AuditShipmentNumber)
                    AuditComment = "Shipment #" + strShipmentNumber + " for customer " + txtCustomerID.Text + " was deleted on " + Today()

                    Try
                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "SHIPMENT COMPLETION - DELETION"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = ShipmentTotal
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strShipmentNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try
                    '*************************************************************************************************************
                    'Check if there are any serial numbers and reset
                    Dim CheckSerialCount As Integer = 0

                    Dim CheckSerialCountString As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber"
                    Dim CheckSerialCountCommand As New SqlCommand(CheckSerialCountString, con)
                    CheckSerialCountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckSerialCount = CInt(CheckSerialCountCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckSerialCount = 0
                    End Try
                    con.Close()

                    If CheckSerialCount = 0 Then
                        'Skip - no serial numbers to reset
                    Else
                        Dim DeleteLineSerialNumber As String = ""
                        Dim DeleteShipmentLineNumber As Integer = 0
                        Dim DeleteAssemblyPartNumber As String = ""


                        For Each row As DataGridViewRow In dgvSerialLog.Rows
                            Try
                                DeleteLineSerialNumber = row.Cells("SLSerialNumberColumn").Value
                            Catch ex As Exception
                                DeleteLineSerialNumber = ""
                            End Try
                            Try
                                DeleteShipmentLineNumber = row.Cells("SLShipmentLineNumberColumn").Value
                            Catch ex As Exception
                                DeleteShipmentLineNumber = 0
                            End Try

                            'Get Serial Part Number from Shipment Line Table
                            Dim DeleteAssemblyPartNumberString As String = "SELECT PartNumber FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                            Dim DeleteAssemblyPartNumberCommand As New SqlCommand(DeleteAssemblyPartNumberString, con)
                            DeleteAssemblyPartNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                            DeleteAssemblyPartNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = DeleteShipmentLineNumber

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                DeleteAssemblyPartNumber = CStr(DeleteAssemblyPartNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                DeleteAssemblyPartNumber = ""
                            End Try
                            con.Close()

                            'Update Status of Serial Number in log to OPEN
                            cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status, BatchNumber = @BatchNumber, CustomerID = @CustomerID WHERE SerialNumber = @SerialNumber AND DivisionID = @DivisionID AND AssemblyPartNumber = @AssemblyPartNumber", con)

                            With cmd.Parameters
                                .Add("@SerialNumber", SqlDbType.VarChar).Value = DeleteLineSerialNumber
                                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = DeleteAssemblyPartNumber
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                                .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Next
                    End If

                    'Delete Pick Ticket
                    cmd = New SqlCommand("DELETE FROM PickListHeaderTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Delete Shipment if pending
                    cmd = New SqlCommand("DELETE FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    ClearAllData()
                    LoadShipmentNumber()
                    LoadShipmentData()
                    LoadShippingWeight()
                    ShowData()
                    ShowLotNumbers()
                    ClearAllData()
                Else
                    MsgBox("You cannot delete this shipment. Shipment has already been posted. Shipment will now close.", MsgBoxStyle.OkOnly)

                    'Check Sales Order to close lines and header
                    For Each row As DataGridViewRow In dgvShipmentLines.Rows
                        Dim GridSOLineKey As Integer

                        Try
                            GridSOLineKey = row.Cells("SOLineNumberColumn").Value
                        Catch ex As Exception
                            GridSOLineKey = 0
                        End Try

                        Dim OrderQuantityString As String = "SELECT QuantityOrdered FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey AND DivisionKey = @DivisionKey"
                        Dim OrderQuantityCommand As New SqlCommand(OrderQuantityString, con)
                        OrderQuantityCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        OrderQuantityCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GridSOLineKey
                        OrderQuantityCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim QuantityShippedString As String = "SELECT SUM(QuantityShipped) FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey AND DivisionKey = @DivisionKey"
                        Dim QuantityShippedCommand As New SqlCommand(QuantityShippedString, con)
                        QuantityShippedCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        QuantityShippedCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GridSOLineKey
                        QuantityShippedCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                        Dim QuantityShippedPendingString As String = "SELECT SUM(PendingShippingQuantity) FROM SalesOrderQuantityStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey AND DivisionKey = @DivisionKey"
                        Dim QuantityShippedPendingCommand As New SqlCommand(QuantityShippedPendingString, con)
                        QuantityShippedPendingCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        QuantityShippedPendingCommand.Parameters.Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GridSOLineKey
                        QuantityShippedPendingCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SOOrderQuantity = CDbl(OrderQuantityCommand.ExecuteScalar)
                        Catch ex As Exception
                            SOOrderQuantity = 0
                        End Try
                        Try
                            SOQuantityShipped = CDbl(QuantityShippedCommand.ExecuteScalar)
                        Catch ex As Exception
                            SOQuantityShipped = 0
                        End Try
                        Try
                            SOQuantityShippedPending = CDbl(QuantityShippedPendingCommand.ExecuteScalar)
                        Catch ex As Exception
                            SOQuantityShippedPending = 0
                        End Try
                        con.Close()

                        If (SOQuantityShipped + SOQuantityShippedPending) >= SOOrderQuantity Then
                            cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                            With cmd.Parameters
                                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                                .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GridSOLineKey
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey", con)

                            With cmd.Parameters
                                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                                .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = GridSOLineKey
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Next
                    '******************************************************************************************************************************************
                    'Recheck SO Header Table to see if all lines are closed
                    Dim AnyOpenLine As Integer

                    Dim AnyOpenLineString As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionID = @DivisionID AND LineStatus = @LineStatus"
                    Dim AnyOpenLineCommand As New SqlCommand(AnyOpenLineString, con)
                    AnyOpenLineCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    AnyOpenLineCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    AnyOpenLineCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        AnyOpenLine = CInt(AnyOpenLineCommand.ExecuteScalar)
                    Catch ex As Exception
                        AnyOpenLine = 0
                    End Try
                    con.Close()

                    'If one line is open, then sales order is open
                    If AnyOpenLine = 0 Then
                        cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                        With cmd.Parameters
                            .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                            .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@SOStatus", SqlDbType.VarChar).Value = "CLOSED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

                        With cmd.Parameters
                            .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                            .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                    '******************************************************************************************************************************************
                    'Close shipment

                    'Update Shipment Header to Shipped
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Update Shipment Lines to Shipped
                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '******************************************************************************************************************************************
                    ClearAllData()
                    LoadShipmentNumber()
                    LoadShipmentData()
                    LoadShippingWeight()
                    ShowData()
                    ShowLotNumbers()
                    ClearAllData()
                End If
            ElseIf button = DialogResult.No Then
                cboShipmentNumber.Focus()
            End If
        End If
    End Sub

    Private Sub cmdBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBOL.Click
        If cboShipmentNumber.Text = "" Or cboPickTicketNumber.Text = "" Or Val(cboShipmentNumber.Text) = 0 Or Val(cboPickTicketNumber.Text) = 0 Then
            MsgBox("You must have a Shipment/Pick Number selected.", MsgBoxStyle.OkOnly)
        Else
            Dim GetShipmentStatus As String

            'Validate that shipment is pending and not shipped
            Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
            GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetShipmentStatus = CStr(GetShipmentStatusCommand.ExecuteScalar)
            Catch ex As Exception
                GetShipmentStatus = ""
            End Try
            con.Close()

            'Reload Lot Numbers
            ShowLotNumbers()
            '*******************************************************************************************************************************************
            If GetShipmentStatus = "PENDING" Then
                '*******************************************************************************************************************************************
                If Val(txtActualFreight.Text) > 10000 Then
                    MsgBox("Freight billed cannot be greater than $10,000.00. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************************************************************************
                ShipDate = dtpShipmentDate.Value
                '*******************************************************************************************************************************************
                'UPDATE Lines in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentLineTable SET ExtendedAmount = QuantityShipped * Price WHERE DivisionID = @DivisionID AND ShipmentNumber = @ShipmentNumber", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                CheckLinesForComplete()
                '*******************************************************************************************************************************************
                'Calculate totals from the Line Amounts
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    LoadShipmentTotalsCanadian()
                Else
                    LoadShipmentTotals()
                    AddShippingCharges()
                End If

                If Val(txtShippingWeight.Text) = 0 Then
                    LoadShippingWeight()
                    txtShippingWeight.Text = TotalEstimatedWeight
                End If
                '*******************************************************************************************************************************************
                'Save data to Shipment Header Table
                SaveUpdateShipmentToPending()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    Exit Sub
                End If
                '*******************************************************************************************************************************************
                'Update Sales Order with new Additional Ship To if necessary
                If cboAdditionalShipTo.Text <> "" Then
                    'Save additional ship to data
                    SaveUpdateAdditionalShipTo()

                    cmd = New SqlCommand("Update SalesOrderHeaderTable SET AdditionalShipTo = @AdditionalShipTo WHERE SalesOrderKey = @SalesOrderKey", con)
                    cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    cmd.Parameters.Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Do nothing
                End If
                '*******************************************************************************************************************************************
                'UPDATE Header in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                GlobalShipmentNumber = Val(cboShipmentNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text
                GlobalCompleteShipment = "COMPLETE SHIPMENT"

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
                    Using NewPrintBOLRemote As New PrintBOLRemote
                        Dim result = NewPrintBOLRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintBOL As New PrintBOL
                        Dim result = NewPrintBOL.ShowDialog()
                    End Using
                End If
            Else
                MsgBox("Shipment has already been processed.", MsgBoxStyle.OkOnly)

                ClearVariables()
                ClearAllData()
            End If
        End If
    End Sub

    Private Sub cmdPrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintAll.Click
        If cboShipmentNumber.Text = "" Or cboPickTicketNumber.Text = "" Or Val(cboShipmentNumber.Text) = 0 Or Val(cboPickTicketNumber.Text) = 0 Then
            MsgBox("You must have a valid Shipment/Pick Number selected.", MsgBoxStyle.OkOnly)
        Else
            Dim GetShipmentStatus As String

            'Validate that shipment is pending and not shipped
            Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
            GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetShipmentStatus = CStr(GetShipmentStatusCommand.ExecuteScalar)
            Catch ex As Exception
                GetShipmentStatus = ""
            End Try
            con.Close()
            '*******************************************************************************************************************************************
            If GetShipmentStatus = "PENDING" Then
                '*******************************************************************************************************************************************
                CheckLinesForComplete()
                '*******************************************************************************************************************************************
                If Val(txtActualFreight.Text) > 10000 Then
                    MsgBox("Freight billed cannot be greater than $10,000.00. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************************************************************************
                'Verify that if line is a concrete anchor, PSR Stud, or DBar that it has a lot number
                If cboDivisionID.Text = "TWD" Then
                    Dim GetItemClass As String = ""
                    Dim LotNumberCount As Integer = 0
                    Dim LineQuantity As Double = 0

                    For Each row2 As DataGridViewRow In dgvShipmentLines.Rows
                        Try
                            ShipmentLineNumber = row2.Cells("ShipmentLineNumberColumn").Value
                        Catch ex As Exception
                            ShipmentLineNumber = 1
                        End Try
                        Try
                            PartNumber = row2.Cells("PartNumberColumn").Value
                        Catch ex As Exception
                            PartNumber = "NO PART"
                        End Try
                        Try
                            LineQuantity = row2.Cells("QuantityShippedColumn").Value
                        Catch ex As Exception
                            LineQuantity = 0
                        End Try

                        If LineQuantity = 0 Then
                            'Skip
                        Else
                            'Get Item Class
                            Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                            Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
                            ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                            ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetItemClass = CStr(ItemClassCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetItemClass = ""
                            End Try
                            con.Close()

                            If LineQuantity = 0 Then
                                GetItemClass = "NONE"
                            Else
                                'Skip
                            End If

                            If GetItemClass = "TW CA" Or GetItemClass = "TW SC" Or GetItemClass = "TW PS" Or GetItemClass = "TW DB" Or GetItemClass = "TW DS" Or GetItemClass = "TW SWR" Then
                                'See if line has a lot number
                                Dim CountLotNumberStatement As String = "SELECT COUNT(LotNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                                Dim CountLotNumberCommand As New SqlCommand(CountLotNumberStatement, con)
                                CountLotNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                                CountLotNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    LotNumberCount = CInt(CountLotNumberCommand.ExecuteScalar)
                                Catch ex As Exception
                                    LotNumberCount = 0
                                End Try
                                con.Close()

                                If LotNumberCount >= 1 And LineQuantity > 0 Then
                                    'Do nothing
                                Else
                                    MsgBox("One or more lines do not have a Lot Number entered for a weld stud.", MsgBoxStyle.OkOnly)
                                    Exit Sub
                                End If

                                LotNumberCount = 0
                                GetItemClass = ""
                                LineQuantity = 0
                            Else
                                'Skip all other item classes
                            End If
                        End If
                    Next
                Else
                    'Skip other divisions
                End If
                '********************************************************************************************
                'Check for Shipment Lot Numbers
                ShowLotNumbers()
                Dim CheckForLotNumbers As Integer = 0

                Dim CheckForLotNumbersStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber"
                Dim CheckForLotNumbersCommand As New SqlCommand(CheckForLotNumbersStatement, con)
                CheckForLotNumbersCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckForLotNumbers = CInt(CheckForLotNumbersCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckForLotNumbers = 0
                End Try
                con.Close()

                If CheckForLotNumbers = 0 Then
                    'Skip - no lot numbers
                Else
                    For Each row As DataGridViewRow In dgvAddedLotNumbers.Rows
                        Dim TempShipmentLineNumber As Integer = row.Cells("ShipmentLineNumberColumn2").Value

                        'Get Shipment Line Quantity
                        Dim TempLineQuantity As Double = 0
                        Dim TempHeatQuantity As Double = 0

                        Dim TempLineQuantityStatement As String = "SELECT QuantityShipped FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                        Dim TempLineQuantityCommand As New SqlCommand(TempLineQuantityStatement, con)
                        TempLineQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        TempLineQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = TempShipmentLineNumber

                        Dim TempHeatQuantityStatement As String = "SELECT SUM(HeatQuantity) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                        Dim TempHeatQuantityCommand As New SqlCommand(TempHeatQuantityStatement, con)
                        TempHeatQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        TempHeatQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = TempShipmentLineNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            TempLineQuantity = CDbl(TempLineQuantityCommand.ExecuteScalar)
                        Catch ex As Exception
                            TempLineQuantity = 0
                        End Try
                        Try
                            TempHeatQuantity = CDbl(TempHeatQuantityCommand.ExecuteScalar)
                        Catch ex As Exception
                            TempHeatQuantity = 0
                        End Try
                        con.Close()

                        If TempLineQuantity = TempHeatQuantity Then
                            'Skip - go to next line
                        Else
                            MsgBox("One of more Heat Quantities do not add up to the Line Quantity. Correct and try again.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End If
                    Next
                End If
                '*******************************************************************************************************************************************
                ShipDate = dtpShipmentDate.Value
                '*******************************************************************************************************************************************
                'UPDATE Lines in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentLineTable SET ExtendedAmount = QuantityShipped * Price WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                'Calculate totals from the Line Amounts
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    LoadShipmentTotalsCanadian()
                Else
                    LoadShipmentTotals()
                    AddShippingCharges()
                End If

                If Val(txtShippingWeight.Text) = 0 Then
                    LoadShippingWeight()
                    txtShippingWeight.Text = TotalEstimatedWeight
                End If
                '*******************************************************************************************************************************************
                'Save data to Shipment Header Table
                SaveUpdateShipmentToPending()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    Exit Sub
                End If
                '*******************************************************************************************************************************************
                'Update Sales Order with new Additional Ship To if necessary
                If cboAdditionalShipTo.Text <> "" Then
                    'Save additional ship to data
                    SaveUpdateAdditionalShipTo()

                    cmd = New SqlCommand("Update SalesOrderHeaderTable SET AdditionalShipTo = @AdditionalShipTo WHERE SalesOrderKey = @SalesOrderKey", con)
                    cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    cmd.Parameters.Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Do nothing
                End If
                '*******************************************************************************************************************************************
                'UPDATE Lines in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                'Check to make sure at least one cert will print otherwise do not open Print Form
                Dim CheckForCerts As Integer = 0

                'Get Pull Test Number for selected Lot Number Data
                Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
                CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader2 As SqlDataReader = CheckForCertsCommand.ExecuteReader()
                If reader2.HasRows Then
                    reader2.Read()
                    If IsDBNull(reader2.Item("CountShipmentNumber")) Then
                        CheckForCerts = 0
                    Else
                        CheckForCerts = reader2.Item("CountShipmentNumber")
                    End If
                Else
                    CheckForCerts = 0
                End If
                reader2.Close()
                con.Close()

                If CheckForCerts = 0 Then
                    GlobalCheckIfCertsWillPrint = "NO"
                Else
                    GlobalCheckIfCertsWillPrint = "YES"
                End If

                Dim CheckForNoCerts As Integer = 0

                'Check to see if there are any certs that will not print
                Dim CheckForNoCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountNoCerts FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND PullTestNumber = @PullTestNumber"
                Dim CheckForNoCertsCommand As New SqlCommand(CheckForNoCertsStatement, con)
                CheckForNoCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                CheckForNoCertsCommand.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = "NO CERT"

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader3 As SqlDataReader = CheckForNoCertsCommand.ExecuteReader()
                If reader3.HasRows Then
                    reader3.Read()
                    If IsDBNull(reader3.Item("CountNoCerts")) Then
                        CheckForNoCerts = 0
                    Else
                        CheckForNoCerts = reader3.Item("CountNoCerts")
                    End If
                Else
                    CheckForNoCerts = 0
                End If
                reader2.Close()
                con.Close()

                If CheckForNoCerts = 0 Then
                    'Set Global Variable to NO
                    GlobalPrintNoCertPage = "NO"
                Else
                    'Set Global Variable to YES
                    GlobalPrintNoCertPage = "YES"
                End If

                GlobalShipmentNumber = Val(cboShipmentNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text

                Using NewPrintAllShippingDocs As New PrintAllShippingDocs
                    Dim Result = NewPrintAllShippingDocs.ShowDialog()
                End Using
            Else
                MsgBox("Shipment has already been processed.", MsgBoxStyle.OkOnly)

                ClearVariables()
                ClearAllData()
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Form Logout
        FormLogoutRoutine()

        'Prompt before Exiting
        If cboShipmentNumber.Text = "" Or Val(cboShipmentNumber.Text) = 0 Then
            ClearVariables()
            ClearAllData()
            GlobalSOShipmentNumber = 0
            GlobalSOPickNumber = 0
            Me.Dispose()
            Me.Close()
        Else
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Shipment before exiting?", "SAVE SHIPMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Dim GetShipmentStatus As String

                'Validate that shipment is pending and not shipped
                Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
                GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetShipmentStatus = CStr(GetShipmentStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    GetShipmentStatus = ""
                End Try
                con.Close()
                '*******************************************************************************************************************************************
                If GetShipmentStatus = "PENDING" Then
                    '*******************************************************************************************************************************************
                    CheckLinesForComplete()
                    '*******************************************************************************************************************************************
                    If Val(txtActualFreight.Text) > 10000 Then
                        MsgBox("Freight billed cannot be greater than $10,000.00. Check number.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                    '*****************************************************************************************************************************************
                    ShipDate = dtpShipmentDate.Value
                    '*******************************************************************************************************************************************
                    'UPDATE Lines in case of changes in datagrid
                    cmd = New SqlCommand("Update ShipmentLineTable SET ExtendedAmount = QuantityShipped * Price WHERE ShipmentNumber = @ShipmentNumber", con)
                    cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '*******************************************************************************************************************************************
                    'Calculate totals from the Line Amounts
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        LoadShipmentTotalsCanadian()
                    Else
                        LoadShipmentTotals()
                        AddShippingCharges()
                    End If

                    LoadShippingWeight()
                    '*******************************************************************************************************************************************
                    'Save data to Shipment Header Table
                    SaveUpdateShipmentToPending()
                    If CheckShippingMethod = "EXIT SUB" Then
                        CheckShippingMethod = ""
                        Exit Sub
                    End If
                    '*******************************************************************************************************************************************
                    'Update Sales Order with new Additional Ship To if necessary
                    If cboAdditionalShipTo.Text <> "" Then
                        'Save additional shipto data
                        SaveUpdateAdditionalShipTo()

                        cmd = New SqlCommand("Update SalesOrderHeaderTable SET AdditionalShipTo = @AdditionalShipTo WHERE SalesOrderKey = @SalesOrderKey", con)
                        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                        cmd.Parameters.Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        'Do nothing
                    End If
                    '*******************************************************************************************************************************************
                    'UPDATE Lines in case of changes in datagrid
                    cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber", con)
                    cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '*******************************************************************************************************************************************
                    'Reload datagrid
                    ShowData()
                    ShowLotNumbers()
                    '*******************************************************************************************************************************************
                    'UPDATE Lines in case of changes in datagrid
                    cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber", con)
                    cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '*******************************************************************************************************************************************
                    ClearVariables()
                    ClearAllData()
                    GlobalSOShipmentNumber = 0
                    GlobalSOPickNumber = 0
                    Me.Dispose()
                    Me.Close()
                Else
                    ClearVariables()
                    ClearAllData()
                    GlobalSOShipmentNumber = 0
                    GlobalSOPickNumber = 0
                    Me.Dispose()
                    Me.Close()
                End If
            ElseIf button = DialogResult.No Then
                ClearVariables()
                ClearAllData()
                GlobalSOShipmentNumber = 0
                GlobalSOPickNumber = 0
                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub cmdPrintShipmentConfirmation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintShipmentConfirmation.Click
        If cboShipmentNumber.Text = "" Or cboPickTicketNumber.Text = "" Or Val(cboShipmentNumber.Text) = 0 Or Val(cboPickTicketNumber.Text) = 0 Then
            MsgBox("You must have a valid Shipment/Pick Number selected.", MsgBoxStyle.OkOnly)
        Else
            Dim GetShipmentStatus As String

            'Validate that shipment is pending and not shipped
            Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
            GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetShipmentStatus = CStr(GetShipmentStatusCommand.ExecuteScalar)
            Catch ex As Exception
                GetShipmentStatus = ""
            End Try
            con.Close()

            'Reload Lot Numbers
            ShowLotNumbers()
            '*******************************************************************************************************************************************
            If GetShipmentStatus = "PENDING" Then
                '*******************************************************************************************************************************************
                ShipDate = dtpShipmentDate.Value
                '*****************************************************************************************************************************************
                If Val(txtActualFreight.Text) > 10000 Then
                    MsgBox("Freight billed cannot be greater than $10,000.00. check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************************************************************************
                'UPDATE Lines in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentLineTable SET ExtendedAmount = QuantityShipped * Price WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                CheckLinesForComplete()
                '*******************************************************************************************************************************************
                'Calculate totals from the Line Amounts
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    LoadShipmentTotalsCanadian()
                Else
                    LoadShipmentTotals()
                    AddShippingCharges()
                End If

                If Val(txtShippingWeight.Text) = 0 Then
                    LoadShippingWeight()
                    txtShippingWeight.Text = TotalEstimatedWeight
                End If
                '*******************************************************************************************************************************************
                'Save data to Shipment Header Table
                SaveUpdateShipmentToPending()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    Exit Sub
                End If
                '*******************************************************************************************************************************************
                'Update Sales Order with new Additional Ship To if necessary
                If cboAdditionalShipTo.Text <> "" Then
                    'Save additional ship to data
                    SaveUpdateAdditionalShipTo()

                    cmd = New SqlCommand("Update SalesOrderHeaderTable SET AdditionalShipTo = @AdditionalShipTo WHERE SalesOrderKey = @SalesOrderKey", con)
                    cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    cmd.Parameters.Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Do nothing
                End If
                '*******************************************************************************************************************************************
                'UPDATE Lines in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                GlobalShipmentNumber = Val(cboShipmentNumber.Text)
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
                    Using NewPrintShipmentConfirmationRemote As New PrintShipmentConfirmationRemote
                        Dim result = NewPrintShipmentConfirmationRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintShipmentConfirmation As New PrintShipmentConfirmation
                        Dim result = NewPrintShipmentConfirmation.ShowDialog()
                    End Using
                End If
            Else
                MsgBox("Shipment has already been processed.", MsgBoxStyle.OkOnly)

                ClearVariables()
                ClearAllData()
            End If
        End If
    End Sub

    Private Sub cmdTWCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTWCert.Click
        If cboShipmentNumber.Text = "" Or cboPickTicketNumber.Text = "" Or Val(cboShipmentNumber.Text) = 0 Or Val(cboPickTicketNumber.Text) = 0 Then
            MsgBox("You must have a Shipment/Pick Number selected.", MsgBoxStyle.OkOnly)
        Else
            Dim GetShipmentStatus As String

            'Validate that shipment is pending and not shipped
            Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
            GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetShipmentStatus = CStr(GetShipmentStatusCommand.ExecuteScalar)
            Catch ex As Exception
                GetShipmentStatus = ""
            End Try
            con.Close()
            '*******************************************************************************************************************************************
            If GetShipmentStatus = "PENDING" Then
                '*******************************************************************************************************************************************
                If Val(txtActualFreight.Text) > 10000 Then
                    MsgBox("Freight billed cannot be greater than $10,000.00. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************************************************************************
                CheckLinesForComplete()
                '*******************************************************************************************************************************************
                'Check for Shipment Lot Numbers
                ShowLotNumbers()
                Dim CheckForLotNumbers As Integer = 0

                Dim CheckForLotNumbersStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber"
                Dim CheckForLotNumbersCommand As New SqlCommand(CheckForLotNumbersStatement, con)
                CheckForLotNumbersCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckForLotNumbers = CInt(CheckForLotNumbersCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckForLotNumbers = 0
                End Try
                con.Close()

                If CheckForLotNumbers = 0 Then
                    'Skip - no lot numbers
                Else
                    For Each row As DataGridViewRow In dgvAddedLotNumbers.Rows
                        Dim TempShipmentLineNumber As Integer = row.Cells("ShipmentLineNumberColumn2").Value

                        'Get Shipment Line Quantity
                        Dim TempLineQuantity As Double = 0
                        Dim TempHeatQuantity As Double = 0

                        Dim TempLineQuantityStatement As String = "SELECT QuantityShipped FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                        Dim TempLineQuantityCommand As New SqlCommand(TempLineQuantityStatement, con)
                        TempLineQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        TempLineQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = TempShipmentLineNumber

                        Dim TempHeatQuantityStatement As String = "SELECT SUM(HeatQuantity) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                        Dim TempHeatQuantityCommand As New SqlCommand(TempHeatQuantityStatement, con)
                        TempHeatQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        TempHeatQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = TempShipmentLineNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            TempLineQuantity = CDbl(TempLineQuantityCommand.ExecuteScalar)
                        Catch ex As Exception
                            TempLineQuantity = 0
                        End Try
                        Try
                            TempHeatQuantity = CDbl(TempHeatQuantityCommand.ExecuteScalar)
                        Catch ex As Exception
                            TempHeatQuantity = 0
                        End Try
                        con.Close()

                        If TempLineQuantity = TempHeatQuantity Then
                            'Skip - go to next line
                        Else
                            MsgBox("One of more Heat Quantities do not add up to the Line Quantity. Correct and try again.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End If
                    Next
                End If
                '*******************************************************************************************************************************************
                ShipDate = dtpShipmentDate.Value
                '*******************************************************************************************************************************************
                'UPDATE Lines in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentLineTable SET ExtendedAmount = QuantityShipped * Price WHERE ShipmentNumber = @ShipmentNumber", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                'Calculate totals from the Line Amounts
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    LoadShipmentTotalsCanadian()
                Else
                    LoadShipmentTotals()
                    AddShippingCharges()
                End If

                If Val(txtShippingWeight.Text) = 0 Then
                    LoadShippingWeight()
                    txtShippingWeight.Text = TotalEstimatedWeight
                End If
                '*******************************************************************************************************************************************
                'Save data to Shipment Header Table
                SaveUpdateShipmentToPending()
                '*******************************************************************************************************************************************
                'Update Sales Order with new Additional Ship To if necessary
                If cboAdditionalShipTo.Text <> "" Then
                    'Save additional ship to data
                    SaveUpdateAdditionalShipTo()

                    cmd = New SqlCommand("Update SalesOrderHeaderTable SET AdditionalShipTo = @AdditionalShipTo WHERE SalesOrderKey = @SalesOrderKey", con)
                    cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    cmd.Parameters.Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Do nothing
                End If
                '*******************************************************************************************************************************************
                'UPDATE Lines in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                'Reload datagrid
                'ShowData()
                '*******************************************************************************************************************************************
                'UPDATE Lines in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                'Check to make sure at least one cert will print otherwise do not open Print Form
                Dim CheckForCerts As Integer = 0

                'Get Pull Test Number for selected Lot Number Data
                Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
                CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader2 As SqlDataReader = CheckForCertsCommand.ExecuteReader()
                If reader2.HasRows Then
                    reader2.Read()
                    If IsDBNull(reader2.Item("CountShipmentNumber")) Then
                        CheckForCerts = 0
                    Else
                        CheckForCerts = reader2.Item("CountShipmentNumber")
                    End If
                Else
                    CheckForCerts = 0
                End If
                reader2.Close()
                con.Close()

                If CheckForCerts = 0 Then
                    MsgBox("There are no certs to print. If you entered a Lot #, check the error log.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    Dim CheckForNoCerts As Integer = 0

                    'Check to see if there are any certs that will not print
                    Dim CheckForNoCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountNoCerts FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND PullTestNumber = @PullTestNumber"
                    Dim CheckForNoCertsCommand As New SqlCommand(CheckForNoCertsStatement, con)
                    CheckForNoCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    CheckForNoCertsCommand.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = "NO CERT"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim reader3 As SqlDataReader = CheckForNoCertsCommand.ExecuteReader()
                    If reader3.HasRows Then
                        reader3.Read()
                        If IsDBNull(reader3.Item("CountNoCerts")) Then
                            CheckForNoCerts = 0
                        Else
                            CheckForNoCerts = reader3.Item("CountNoCerts")
                        End If
                    Else
                        CheckForNoCerts = 0
                    End If
                    reader3.Close()
                    con.Close()

                    If CheckForNoCerts = 0 Then
                        'Set Global Variable to NO
                        GlobalPrintNoCertPage = "NO"
                    Else
                        'Set Global Variable to YES
                        GlobalPrintNoCertPage = "YES"
                    End If

                    'Auto-print certs based on the line items
                    GlobalShipmentNumber = Val(cboShipmentNumber.Text)
                    GlobalCertCustomer = txtCustomerID.Text
                    GlobalDivisionCode = cboDivisionID.Text
                    GlobalCompleteShipment = "COMPLETE SHIPMENT"

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
                        Using NewPrintTWCert01Remote As New PrintTWCert01Remote
                            Dim result = NewPrintTWCert01Remote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintTWCert01 As New PrintTWCert01
                            Dim result = NewPrintTWCert01.ShowDialog()
                        End Using
                    End If
                End If
            Else
                MsgBox("Shipment has already been processed.", MsgBoxStyle.OkOnly)

                ClearVariables()
                ClearAllData()
            End If
        End If
    End Sub

    Private Sub cmdPackingList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPackingList.Click
        If cboShipmentNumber.Text = "" Or cboPickTicketNumber.Text = "" Or Val(cboShipmentNumber.Text) = 0 Or Val(cboPickTicketNumber.Text) = 0 Then
            MsgBox("You must have a Shipment Number selected.", MsgBoxStyle.OkOnly)
        Else
            Dim GetShipmentStatus As String

            'Validate that shipment is pending and not shipped
            Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
            GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetShipmentStatus = CStr(GetShipmentStatusCommand.ExecuteScalar)
            Catch ex As Exception
                GetShipmentStatus = ""
            End Try
            con.Close()

            'Reload Lot Numbers
            ShowLotNumbers()
            '*******************************************************************************************************************************************
            If GetShipmentStatus = "PENDING" Then
                '*******************************************************************************************************************************************
                If Val(txtActualFreight.Text) > 10000 Then
                    MsgBox("Freight billed cannot be greater than $10,000.00. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************************************************************************
                ShipDate = dtpShipmentDate.Value
                '*******************************************************************************************************************************************
                'UPDATE Lines in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentLineTable SET ExtendedAmount = QuantityShipped * Price WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                CheckLinesForComplete()
                '*******************************************************************************************************************************************
                'Calculate totals from the Line Amounts
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    LoadShipmentTotalsCanadian()
                Else
                    LoadShipmentTotals()
                    AddShippingCharges()
                End If

                If Val(txtShippingWeight.Text) = 0 Then
                    LoadShippingWeight()
                    txtShippingWeight.Text = TotalEstimatedWeight
                End If
                '*******************************************************************************************************************************************
                'Save data to Shipment Header Table
                SaveUpdateShipmentToPending()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    Exit Sub
                End If
                '*******************************************************************************************************************************************
                'Update Sales Order with new Additional Ship To if necessary
                If cboAdditionalShipTo.Text <> "" Then
                    'Save additional ship to data
                    SaveUpdateAdditionalShipTo()

                    cmd = New SqlCommand("Update SalesOrderHeaderTable SET AdditionalShipTo = @AdditionalShipTo WHERE SalesOrderKey = @SalesOrderKey", con)
                    cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    cmd.Parameters.Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Do nothing
                End If
                '*******************************************************************************************************************************************
                'UPDATE Lines in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                If cboDivisionID.Text = "TWD" Then
                    GlobalShipmentNumber = Val(cboShipmentNumber.Text)
                    GlobalDivisionCode = cboDivisionID.Text
                    GlobalCompleteShipment = "COMPLETE SHIPMENT"

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
                        Using NewPrintPackingListRemote As New PrintPackingListRemote
                            Dim result = NewPrintPackingListRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintPackingList As New PrintPackingList
                            Dim result = NewPrintPackingList.ShowDialog()
                        End Using
                    End If
                Else
                    GlobalShipmentNumber = Val(cboShipmentNumber.Text)
                    GlobalDivisionCode = cboDivisionID.Text
                    GlobalCompleteShipment = "COMPLETE SHIPMENT"
                    GlobalAutoPrintPackingList = "NO"

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
                        Using NewPrintPackingListRemote As New PrintPackingListRemote
                            Dim result = NewPrintPackingListRemote.ShowDialog()
                        End Using
                    Else
                        Using NewPrintPackingList As New PrintPackingList
                            Dim result = NewPrintPackingList.ShowDialog()
                        End Using
                    End If
                End If
            Else
                MsgBox("Shipment has already been processed.", MsgBoxStyle.OkOnly)

                ClearVariables()
                ClearAllData()
            End If
        End If
    End Sub

    Private Sub cmdViewPickTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewPickTicket.Click
        Dim UploadedShipmentNumber As String = ""
        Dim ShipmentFilename As String = ""
        Dim ShipmentFilenameAndPath As String = ""

        If cboShipmentNumber.Text <> "" Then
            GlobalShipmentNumber = Val(cboShipmentNumber.Text)
            UploadedShipmentNumber = CStr(GlobalShipmentNumber)
            ShipmentFilename = UploadedShipmentNumber + ".pdf"
            ShipmentFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + ShipmentFilename

            If File.Exists(ShipmentFilenameAndPath) Then
                System.Diagnostics.Process.Start(ShipmentFilenameAndPath)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        Else
            MsgBox("You must have a valid shipment number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    'Menu Strip Events

    Private Sub PrintEmailShipmentConfirmationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintEmailShipmentConfirmationToolStripMenuItem.Click
        cmdPrintShipmentConfirmation_Click(sender, e)
    End Sub

    Private Sub PrintShipmentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintShipmentToolStripMenuItem1.Click
        If cboShipmentNumber.Text = "" Or cboPickTicketNumber.Text = "" Or Val(cboShipmentNumber.Text) = 0 Or Val(cboPickTicketNumber.Text) = 0 Then
            MsgBox("You must have a valid Shipment/Pick Number selected.", MsgBoxStyle.OkOnly)
        Else
            Dim GetShipmentStatus As String

            'Validate that shipment is pending and not shipped
            Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
            GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetShipmentStatus = CStr(GetShipmentStatusCommand.ExecuteScalar)
            Catch ex As Exception
                GetShipmentStatus = ""
            End Try
            con.Close()
            '*******************************************************************************************************************************************
            If GetShipmentStatus = "PENDING" Then
                '*******************************************************************************************************************************************
                If Val(txtActualFreight.Text) > 10000 Then
                    MsgBox("Freight billed cannot be greater than $10,000.00. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************************************************************************
                ShipDate = dtpShipmentDate.Value
                '*******************************************************************************************************************************************
                'UPDATE Lines in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentLineTable SET ExtendedAmount = QuantityShipped * Price WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                CheckLinesForComplete()
                '*******************************************************************************************************************************************
                'Calculate totals from the Line Amounts
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    LoadShipmentTotalsCanadian()
                Else
                    LoadShipmentTotals()
                    AddShippingCharges()
                End If

                LoadShippingWeight()
                '*******************************************************************************************************************************************
                'Save data to Shipment Header Table
                SaveUpdateShipmentToPending()
                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    Exit Sub
                End If
                '*******************************************************************************************************************************************
                'Update Sales Order with new Additional Ship To if necessary
                If cboAdditionalShipTo.Text <> "" Then
                    'Save additional ship to data
                    SaveUpdateAdditionalShipTo()

                    cmd = New SqlCommand("Update SalesOrderHeaderTable SET AdditionalShipTo = @AdditionalShipTo WHERE SalesOrderKey = @SalesOrderKey", con)
                    cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                    cmd.Parameters.Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboAdditionalShipTo.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Do nothing
                End If
                '*******************************************************************************************************************************************
                'UPDATE Lines in case of changes in datagrid
                cmd = New SqlCommand("Update ShipmentHeaderTable SET ShipmentTotal = ProductTotal + FreightActualAmount + TaxTotal + Tax2Total + Tax3Total WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '*******************************************************************************************************************************************
                GlobalShipmentNumber = Val(cboShipmentNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text

                Using NewPrintShipment As New PrintShipment
                    Dim result = NewPrintShipment.ShowDialog()
                End Using
            Else
                MsgBox("Shipment has already been processed.", MsgBoxStyle.OkOnly)

                ClearVariables()
                ClearAllData()
            End If
        End If
    End Sub

    Private Sub ClearShipmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearShipmentToolStripMenuItem.Click
        ClearVariables()
        ClearAllData()
        ClearShipmentLines()
        ClearSerialNumbers()
        ClearOpenOrders()
        ClearLotNumbers()
    End Sub

    Private Sub SaveShipmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveShipmentToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub DeleteShipmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteShipmentToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub BillOfLadingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillOfLadingToolStripMenuItem.Click
        cmdBOL_Click(sender, e)
    End Sub

    Private Sub TruweldCertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TruweldCertToolStripMenuItem.Click
        cmdTWCert_Click(sender, e)
    End Sub

    Private Sub PrintAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintAllToolStripMenuItem.Click
        cmdPrintAll_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub PackingListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PackingListToolStripMenuItem.Click
        cmdPackingList_Click(sender, e)
    End Sub

    'Combo Box Events

    Private Sub cboShipMethod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboShipMethod.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboShipMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipMethod.SelectedIndexChanged
        If cboShipMethod.Text = "THIRD PARTY" Then
            txtThirdPartyShipper.Enabled = True
            GetThirdPartyBillingData()
        Else
            txtThirdPartyShipper.Enabled = False
            txtThirdPartyShipper.Clear()
        End If
    End Sub

    Private Sub cboShipmentLineNumber2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboShipmentLineNumber2.TextChanged
        LoadSerialLineDetails()
    End Sub

    Private Sub cboLotPartDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLotPartDescription.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboShippingState_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboShippingState.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboSTCountryName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSTCountryName.SelectedIndexChanged
        LoadSTCountryCodeByCountry()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        cboShipmentNumber.Refresh()

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Or cboDivisionID.Text = "TST" Then
            Me.dgvShipmentLines.Columns("CompleteLineColumn").Visible = True
        Else
            Me.dgvShipmentLines.Columns("CompleteLineColumn").Visible = False
        End If

        ClearAllData()
        LoadShipmentNumber()
        LoadShipToCountry()

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            cboPickTicketNumber.Focus()
        Else
            cboShipmentNumber.Focus()
        End If
    End Sub

    Private Sub cboShipmentNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipmentNumber.SelectedIndexChanged
        If cboShipmentNumber.Text = "" Or Val(cboShipmentNumber.Text) = 0 Then
            ClearVariables()
            ClearAllData()
            cboPickTicketNumber.SelectedIndex = -1
            cboShipmentNumber.SelectedIndex = -1
            cboLinePartNumber.SelectedIndex = -1
            cboLotPartDescription.SelectedIndex = -1
            cboShipmentLineNumber.SelectedIndex = -1
        Else
            ShowData()
            LoadShipmentData()
            ShowLotNumbers()
            ShowSerialNumbers()
            LoadUploadedPickTicket()
        End If

        If PTUpload IsNot Nothing Then PTUpload.CheckUploadPickTicket()
    End Sub

    Private Sub cboPickTicketNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPickTicketNumber.SelectedIndexChanged
        LoadShipmentFromPickTicket()

        If cboShipmentNumber.Text = "" Or Val(cboShipmentNumber.Text) = 0 Then
            ClearVariables()
            ClearAllData()
            cboPickTicketNumber.SelectedIndex = -1
            cboShipmentNumber.SelectedIndex = -1
            cboLinePartNumber.SelectedIndex = -1
            cboLotPartDescription.SelectedIndex = -1
            cboShipmentLineNumber.SelectedIndex = -1
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cboAdditionalShipTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAdditionalShipTo.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboAdditionalShipTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAdditionalShipTo.SelectedIndexChanged
        If cboAdditionalShipTo.Text = "" Then
            'Do not load if blank
        Else
            LoadAdditionalShipToData()
        End If
    End Sub

    Private Sub cboShipVia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboShipVia.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboShipVia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipVia.SelectedIndexChanged
        AddShippingCharges()

        If cboShipVia.Text <> "" Then
            Try
                If cboShipVia.Text.Contains("UPS-") = True And (cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Or cboDivisionID.Text = "HOU" Or cboDivisionID.Text = "CBS" Or cboDivisionID.Text = "TFT" Or cboDivisionID.Text = "SLC" Or cboDivisionID.Text = "CHT" Or cboDivisionID.Text = "ATL" Or cboDivisionID.Text = "DEN" Or cboDivisionID.Text = "TFJ" Or cboDivisionID.Text = "TOR") Then
                    LoadUPSData()
                End If
            Catch ex As Exception
                'Less than 4 characters
            End Try
        End If
    End Sub

    Private Sub cboShipmentLineNumber2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipmentLineNumber2.SelectedIndexChanged
        LoadSerialLineDetails()
    End Sub

    Private Sub cboShipmentLineNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipmentLineNumber.SelectedIndexChanged
        Dim HeatQuantity As Double

        If cboShipmentLineNumber.Text <> "" And cboLinePartNumber.Text <> "" Then
            Dim HeatQuantityStatement As String = "SELECT QuantityShipped FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND DivisionID = @DivisionID"
            Dim HeatQuantityCommand As New SqlCommand(HeatQuantityStatement, con)
            HeatQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            HeatQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber.Text)
            HeatQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                HeatQuantity = CDbl(HeatQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                HeatQuantity = 0
            End Try
            con.Close()

            txtHeatQuantity.Text = HeatQuantity
        Else
            txtHeatQuantity.Clear()
        End If
    End Sub

    'Text Box Events

    Private Sub txtQuotedFreight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuotedFreight.TextChanged
        AddShippingCharges()
    End Sub

    Private Sub txtNumberPallets_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumberPallets.TextChanged
        'Refresh Shipping weight on changes
        LoadShippingWeight()

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            TotalEstimatedWeight = Math.Round(TotalEstimatedWeight, 0)
            txtShippingWeight.Text = TotalEstimatedWeight
        End If

        txtTotalPalletsOnFloor.Text = Val(txtNumberPallets.Text) - Val(txtDoublePallets.Text)
    End Sub

    Private Sub txtDoublePallets_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDoublePallets.TextChanged
        txtTotalPalletsOnFloor.Text = Val(txtNumberPallets.Text) - Val(txtDoublePallets.Text)
    End Sub

    Private Sub txtShippingCountry_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShippingCountry.TextChanged
        LoadSTCountryByCountryCode()
    End Sub

    Private Sub txtCustomerID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerID.TextChanged
        If txtCustomerID.Text = "" Then
            'Do not load if blank
        Else
            LoadAdditionalShipTo()
            cboAdditionalShipTo.SelectedIndex = -1
            LoadCustomerData()
            ShowOpenOrders()
        End If
    End Sub

    Private Sub txtLotNumber_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLotNumber.MouseDoubleClick
        txtLotNumber.Text = GlobalLotNumber
    End Sub

    'Miscellaneous Events and Procdeures

    Private Sub InitializeBarcodeVariables()
        Dim I As Integer

        For I = 0 To 69
            LabelFormat(I) = ""
        Next I

        V00 = ""
        V01 = ""
        V02 = ""
        V03 = ""
        V04 = ""
        V05 = ""
        V06 = ""
        V07 = ""
        V08 = ""
        V09 = ""
        V10 = ""
        V11 = ""
        V12 = ""
        V13 = ""
        V14 = ""
        V15 = ""
        V16 = ""
        V17 = ""
        V18 = ""
        V19 = ""
        V20 = ""
        V21 = ""
        V22 = ""
        V23 = ""
        V24 = ""
        V25 = ""
        V26 = ""
        V27 = ""
        V28 = ""

        VDATA = ""
        VDATA1 = ""
        VBAR = ""
        VBAR1 = ""

        LabelLines = 0
        NumberOfLabels = 1
    End Sub

    Private Sub FillBarCodeVariables()
        'V00 = "P" & txtPartNumber.Text
        'V01 = "Q" & txtQuantity.Text
        'V02 = "W" & txtWeight.Text
        'V03 = "S" & txtSerialNumber.Text
        'V04 = txtShortDescription.Text
        'V05 = txtLongDescription.Text
        'V06 = ""
        'V07 = "A" & txtCustomerPO.Text
        'V08 = txtRevisionLevel.Text
        ' V09 = ""

        'special purpose use to truncate string length on lable
        If String.IsNullOrEmpty(txtShipToName.Text) Then
            V00 = getCustomerName()
        Else
            V00 = txtShipToName.Text
        End If

        V01 = txtShippingAddress1.Text
        V02 = txtShippingCity.Text & ", " & cboShippingState.Text & " " & txtShippingZip.Text
        V03 = txtShippingAddress2.Text
        cmd = New SqlCommand("SELECT Country FROM CountryCodes WHERE CountryCode = @CountryCode", con)
        cmd.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = txtShippingCountry.Text

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                V04 = obj.ToString()
            End If
        Catch ex As Exception
            V04 = txtShippingCountry.Text
        Finally
            con.Close()
        End Try

        If V00.Length < 32 Then
            V10 = V00
        Else
            V10 = V00.Substring(0, 32)
        End If

        If V01.Length < 32 Then
            V11 = V01
        Else
            V11 = V01.Substring(0, 32)
        End If

        If V02.Length < 32 Then
            V12 = V02
        Else
            V12 = V02.Substring(0, 32)
        End If

        If V03.Length < 32 Then
            V17 = V03
        Else
            V17 = V03.Substring(0, 32)
        End If

        If V04.Length < 35 Then
            V18 = V04
        Else
            V18 = V04.Substring(0, 32)
        End If

        If cboDivisionID.Text.Equals("CHT") Then
            V28 = "WELDING CERAMICS "
        Else
            V28 = "TFP CORP. "
        End If

        'Select Case cboDivisionID.Text
        '    Case "TFP"
        '        V28 = "TFP CORP. " 'MEDINA, OH. 44256 330-725-7741"
        '    Case "CGO"
        '        V28 = "TFP CORP. " 'GRIFFITH, IN. 46319 219-513-9572"
        '    Case "CHT"
        '        V28 = "WELDING CERAMICS " 'CHATTANOOGA, TN 423-752-5740"
        '    Case "ATL"
        '        V28 = "TFP CORP.  " 'NORCROSS, GA. 678-728-0095"
        '    Case "TFF"
        '        V28 = "TFP CORP.  " 'SURREY, BC.  V4N 3R7  778-298-1094"
        '    Case "CBS"
        '        V28 = "TFP CORP.  " 'LAS VEGAS, NV.  702-737-7940"
        '    Case "SLC"
        '        V28 = "TFP CORP.  " 'WEST JORDAN, UT.  801-280-6611"
        '    Case "TFT"
        '        V28 = "TFP CORP.  " 'IRVING, TX.  972-986-6368"
        '    Case "HOU"
        '        V28 = "TFP CORP.  " ' HOUSTON, TX.  281-598-2330"
        '    Case "TOR"
        '        V28 = "TFP CORP.  " '  Stoney Creek, Ont.  905-643-0969"
        '    Case "TWD"
        '        V28 = "TFP CORP.  "
        '    Case Else
        '        V28 = "TFP CORP.  " ' MEDINA, OH 44256 330-725-7741"
        'End Select

        cmd = New SqlCommand("SELECT City, State, Zipcode, Phone FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            V28 += reader.GetValue(0) + ", " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3)
        Else
            cmd.Parameters("@DivisionKey").Value = "TFP"
            reader = cmd.ExecuteReader()
            reader.Read()
            V28 += reader.GetValue(0) + ", " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3)
        End If
        reader.Close()
        con.Close()

        'V13 = txtSerialNumber.Text
        'V14 = "V" & txtSupplierNumber.Text
        'V15 = txtCountryOfOrigin.Text
        'V16 = "EH" & txtHeatNumber.Text

        'V18 = "3S" & txtSerialNumber.Text
        'V19 = "K" & txtCustomerPO.Text
        ' V20 = "2P" & txtEngineeringChangeLevel.Text
        'V21 = "1T" & txtSerialNumber.Text
        'V22 = "15K" & txtKanBan.Text
        'V23 = ""
        'V24 = "Z"
        'V25 = "HC"
        'V26 = "7Q"
        'V27 = "K"
        'V28 = "T"

        'VDATA = ""
        'VDATA1 = ""
        'VBAR = ""
        'VBAR1 = ""
    End Sub

    Private Function getCustomerName() As String
        cmd = New SqlCommand("Select CustomerName FROM CustomerList WHERE CustomerID = '" + usefulFunctions.checkQuote(txtCustomerID.Text) + "'", con)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Dim nme As String = cmd.ExecuteScalar()
        con.Close()
        Return nme
    End Function

    Private Sub PrintBarcodeLine()
        ' Click event handler for a button - designed to show how to use the
        ' SendBytesToPrinter function to send a string to the printer.

        Dim pd As New PrintDialog()
        Dim i As Integer
        pd.UseEXDialog = True

        pd.PrinterSettings = New PrinterSettings()
        Dim printers(pd.PrinterSettings.InstalledPrinters.Count) As [String]
        pd.PrinterSettings.InstalledPrinters.CopyTo(printers, 0)
        pd.PrinterSettings.PrinterName = ""
        ''checks to see if the designated printer is present
        While i < printers.Count() - 1
            If String.IsNullOrEmpty(printers(i)) = False And printers(i).Contains("Zebra" + EmployeeCompanyCode) Then
                pd.PrinterSettings.PrinterName = printers(i)
            End If
            i += 1
        End While
        ''checks to see if a printer was selected and if not will show the dialog
        If String.IsNullOrEmpty(pd.PrinterSettings.PrinterName) Then
            ' Open the printer dialog box, and then allow the user to select a printer.
            If pd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                sendToPrinter(pd.PrinterSettings.PrinterName)
            End If
        Else
            sendToPrinter(pd.PrinterSettings.PrinterName)
        End If
    End Sub

    Private Sub sendToPrinter(ByVal printerName As String)
        Dim s As String = ""
        For i = 0 To LabelLines
            ' You need a string to send.
            s += LabelFormat(i) + Environment.NewLine
        Next i
        If s <> "" Then
            RawPrinter.SendStringToPrinter(printerName, s)
        End If
    End Sub

    Private Sub AddressLabelSetup(ByVal labels As Integer)
        Dim ship As New BarcodeLabel.shippingPallet
        ship.shipTo = V10
        ship.street = V11
        ship.address1 = V12
        ship.address2 = V17
        ship.country = V18
    End Sub

    Private Function getPalletNumber() As Integer
        Dim pallets As Integer = 1
        If String.IsNullOrEmpty(txtNumberPallets.Text) = False Then
            pallets = Convert.ToInt32(txtNumberPallets.Text)
        End If

        If pallets > 1 Then
            Dim labelNumber As New ShipmentLabelNumber()
            labelNumber.setLabelNumber(pallets)
            labelNumber.ShowDialog()
            If labelNumber.DialogResult = Windows.Forms.DialogResult.OK Then
                pallets = labelNumber.nbrNumberOfLabels.Value
            Else
                pallets = -1
            End If
        End If
        Return pallets
    End Function

    Private Sub setDescription(Optional ByVal cutLength As Integer = 27)
        If cboLotPartDescription.Text.Length > cutLength Then
            Dim offset As Integer = 0
            While cboLotPartDescription.Text(cutLength - offset) <> " "c
                offset += 1
            End While
            Dim firstCut As Integer = (cutLength - offset)
            V04 = cboLotPartDescription.Text.Substring(0, firstCut)
            If cboLotPartDescription.Text.Length > firstCut + cutLength Then
                offset = 0
                While cboLotPartDescription.Text(firstCut + cutLength - offset) <> " "c
                    offset += 1
                End While
                Dim secondCut As Integer = cutLength - offset
                If cboLotPartDescription.Text.Length > firstCut + secondCut + cutLength Then
                    offset = 0
                    While cboLotPartDescription.Text((firstCut + secondCut) + cutLength - offset) <> " "c
                        offset += 1
                    End While
                    Dim thirdCut = cutLength - offset
                    V06 = cboLotPartDescription.Text.Substring(firstCut + secondCut, thirdCut)
                Else
                    V06 = cboLotPartDescription.Text.Substring(firstCut + secondCut, cboLotPartDescription.Text.Length - (firstCut + secondCut))
                End If
                V05 = cboLotPartDescription.Text.Substring(firstCut, secondCut)
            Else
                V05 = cboLotPartDescription.Text.Substring(firstCut, cboLotPartDescription.Text.Length - firstCut)
                V06 = ""
            End If
        Else
            V04 = cboLotPartDescription.Text
            V05 = ""
            V06 = ""
        End If
    End Sub

    Private Sub llViewLotNumbers_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llViewLotNumbers.LinkClicked
        GlobalLotNumberPart = cboLinePartNumber.Text

        Using NewLotNumberPopup As New LotNumberPopup
            Dim result = NewLotNumberPopup.ShowDialog()
        End Using
    End Sub

    Private Sub llPickTicket_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llPickTicket.LinkClicked
        If cboDivisionID.Text = "TFP" Or cboDivisionID.Text = "TWD" Then
            GlobalPickListNumber = Val(cboPickTicketNumber.Text)

            Using NewShippingUpdaterRacking As New ShippingUpdaterRacking
                Dim Result = NewShippingUpdaterRacking.ShowDialog()
            End Using
        End If
    End Sub

    Public Sub AutoEmailPackingListAndCerts()
        'Check Customer File for email address
        Dim GetPackingListEmail As String = ""

        Dim GetPackingListEmailStatement As String = "SELECT PackingListEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetPackingListEmailCommand As New SqlCommand(GetPackingListEmailStatement, con)
        GetPackingListEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text
        GetPackingListEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetPackingListEmail = CStr(GetPackingListEmailCommand.ExecuteScalar)
        Catch ex As Exception
            GetPackingListEmail = 0
        End Try
        con.Close()

        If GetPackingListEmail = "" Then
            'Do nothing
        Else
            '*********************************************************************************************
            'Save packing list as a pdf and attach to auto-sent email
            Dim EmailPackingList As String = ""
            Dim strShipmentNumber As String = ""
            Dim TempShipmentNumber As Integer = Val(cboShipmentNumber.Text)

            strShipmentNumber = CStr(TempShipmentNumber)

            EmailPackingList = cboDivisionID.Text + strShipmentNumber + ".pdf"
            '***********************************************************************************************
            'Check if file exists
            If File.Exists("\\TFP-FS\TransferData\TruweldPackList\" + EmailPackingList) Then
                '***********************************************************************************************
                'Set up email to be sent
                Dim MyMailMessage As New MailMessage()
                MyMailMessage.From = New MailAddress("packinglist@tfpcorp.com")
                MyMailMessage.To.Add(GetPackingListEmail)
                MyMailMessage.To.Add(GetPackingListEmail)
                MyMailMessage.Attachments.Add(New Attachment("\\TFP-FS\TransferData\TruweldPackList\" + EmailPackingList))
                MyMailMessage.Attachments.Add(New Attachment("\\TFP-FS\TransferData\TruweldPackList\" + EmailPackingList))
                MyMailMessage.Subject = "Packing List / TFP Corporation"
                MyMailMessage.ReplyTo = New MailAddress("t.lerew@tfpcorp.com")
                MyMailMessage.Body = "Auto-sent Packing List for customer. Do not reply to this email address."
                Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                SMPT.Port = "587"
                SMPT.EnableSsl = False
                SMPT.Credentials = New System.Net.NetworkCredential("packinglist@tfpcorp.com", "1422325bogie")
                SMPT.Send(MyMailMessage)
            Else
                MsgBox("File does not exists.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub TestAutoEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestAutoEmailToolStripMenuItem.Click
        AutoEmailPackingListAndCerts()
    End Sub

    Private Sub cmdUploadPickTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadPickTicket.Click
        GlobalShipmentNumber = Val(cboShipmentNumber.Text)

        cmdUploadPickTicket.Visible = False
        cmdViewPickTicket.Visible = True

        cboShipmentNumber.Refresh()

        'LoadUploadedPickTicket()
    End Sub

    Private Sub ResetShipmentForCompletionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetShipmentForCompletionToolStripMenuItem.Click
        If cboShipmentNumber.Text = "" Or cboDivisionID.Text = "" Then
            Exit Sub
        Else
            'Continue
        End If
        '*******************************************************************************************************************************************************************************
        Dim button As DialogResult = MessageBox.Show("Do you wish to reset this shipment for posting?", "RESET SHIPMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then

            Dim ResetShipmentNumber As Integer = 0
            Dim ResetDivisionID As String = ""
            Dim ResetShipmentStatus As String = ""

            'Check Shipping Data
            Dim CheckShipDivisionStatement As String = "SELECT DivisionID FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
            Dim CheckShipDivisionCommand As New SqlCommand(CheckShipDivisionStatement, con)
            CheckShipDivisionCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ResetDivisionID = CStr(CheckShipDivisionCommand.ExecuteScalar)
            Catch ex As Exception
                ResetDivisionID = ""
            End Try
            con.Close()

            ResetShipmentNumber = Val(cboShipmentNumber.Text)

            If cboDivisionID.Text = "" Or ResetDivisionID = "" Or cboDivisionID.Text <> ResetDivisionID Then
                MsgBox("Invalid division or does not match shipment.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Check status of the shipment
                Dim CheckShipStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
                Dim CheckShipStatusCommand As New SqlCommand(CheckShipStatusStatement, con)
                CheckShipStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ResetShipmentNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ResetShipmentStatus = CStr(CheckShipStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    ResetShipmentStatus = ""
                End Try
                con.Close()

                If ResetShipmentStatus <> "PENDING" Then
                    MsgBox("Only a pending shipment can be reset.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If

                Try
                    'Delete Inventory Transaction Numbers
                    cmd = New SqlCommand("DELETE FROM InventoryTransactionTable WHERE TransactionTypeNumber = @TransactionTypeNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = ResetShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = ResetDivisionID
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Delete GL Transaction Numbers
                    cmd = New SqlCommand("DELETE FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = ResetShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = ResetDivisionID
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Update Shipment Line Numbers
                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ResetShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = ResetDivisionID
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Write to Audit Trail Table
                    Dim AuditComment As String = ""
                    Dim AuditShipmentNumber As Integer = 0
                    Dim strShipmentNumber As String = ""

                    AuditShipmentNumber = Val(cboShipmentNumber.Text)
                    strShipmentNumber = CStr(AuditShipmentNumber)
                    AuditComment = "Shipment #" + strShipmentNumber + " was reset for posting on " + Today()

                    Try
                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "SHIPMENT RESET"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strShipmentNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex5 As Exception
                        'Skip
                    End Try

                    MsgBox("Shipment has been reset and can be posted again.", MsgBoxStyle.OkOnly)

                    cboDivisionID.SelectedIndex = -1
                    cboShipmentNumber.SelectedIndex = -1

                    cmdClear_Click(sender, e)
                Catch ex As Exception
                    'Error Log
                    Dim TempShipmentNumber As Integer = 0
                    Dim strShipmentNumber As String = ""
                    TempShipmentNumber = Val(cboShipmentNumber.Text)
                    strShipmentNumber = CStr(TempShipmentNumber)

                    ErrorDate = Today()
                    ErrorComment = "Failed to reset shipment"
                    ErrorDivision = ResetDivisionID
                    ErrorDescription = "Database Utilities - Reset Shipment"
                    ErrorReferenceNumber = "Shipment # " + strShipmentNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        ElseIf button = DialogResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub SendFedExEmailForDailyShipmentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendFedExEmailForDailyShipmentsToolStripMenuItem.Click
        'Get Shipment Details to send to Fedex
        Dim NumberOfOrders As Integer = 0
        Dim TotalWeightOfOrders As Double = 0
        Dim NumberOfPalletsOfOrders As Integer = 0
        '********************************************************************************
        Dim NumberOfOrdersStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE ShipDate = @ShipDate AND ShipVia LIKE 'FEDEX %' AND (ShipmentStatus = 'SHIPPED' OR ShipmentStatus = 'INVOICED') AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
        Dim NumberOfOrdersCommand As New SqlCommand(NumberOfOrdersStatement, con)
        NumberOfOrdersCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = Today()

        Dim TotalWeightOfOrdersStatement As String = "SELECT SUM(ShippingWeight) FROM ShipmentHeaderTable WHERE ShipDate = @ShipDate AND ShipVia LIKE 'FEDEX %' AND (ShipmentStatus = 'SHIPPED' OR ShipmentStatus = 'INVOICED') AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
        Dim TotalWeightOfOrdersCommand As New SqlCommand(TotalWeightOfOrdersStatement, con)
        TotalWeightOfOrdersCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = Today()

        Dim NumberOfPalletsOfOrdersStatement As String = "SELECT SUM(NumberOfPallets) FROM ShipmentHeaderTable WHERE ShipDate = @ShipDate AND ShipVia LIKE 'FEDEX %' AND (ShipmentStatus = 'SHIPPED' OR ShipmentStatus = 'INVOICED') AND (DivisionID = 'TWD' OR DivisionID = 'TFP')"
        Dim NumberOfPalletsOfOrdersCommand As New SqlCommand(NumberOfPalletsOfOrdersStatement, con)
        NumberOfPalletsOfOrdersCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = Today()

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            NumberOfOrders = CInt(NumberOfOrdersCommand.ExecuteScalar)
        Catch ex As Exception
            NumberOfOrders = 0
        End Try
        Try
            TotalWeightOfOrders = CDbl(TotalWeightOfOrdersCommand.ExecuteScalar)
        Catch ex As Exception
            TotalWeightOfOrders = 0
        End Try
        Try
            NumberOfPalletsOfOrders = CInt(NumberOfPalletsOfOrdersCommand.ExecuteScalar)
        Catch ex As Exception
            NumberOfPalletsOfOrders = 0
        End Try
        con.Close()

        'Create Email Fields and send email
        Dim SendToEmail As String = ""
        Dim strNumberOfPallets As String = ""
        Dim strTotalWeightOfOrders As String = ""
        Dim strNumberOfOrders As String = ""
        Dim EmailBody As String = ""
        Dim ShippingDate As String = ""
        Dim BodyHeader As String = ""
        Dim BodyFooter As String = ""

        ShippingDate = Today()

        'Creat Body Email
        strNumberOfPallets = CStr(NumberOfPalletsOfOrders)
        strTotalWeightOfOrders = CStr(TotalWeightOfOrders)
        strNumberOfOrders = CStr(NumberOfOrders)

        EmailBody = "TFP Corporation / Truweld / Trufit Products" + Environment.NewLine + "460 Lake Road, Medina Ohio 44256" + Environment.NewLine + "1-330-725-7741 Ext. 265" + Environment.NewLine + "FEDEX Shipping Manifest for " + ShippingDate + Environment.NewLine + Environment.NewLine + "Number of Orders -- " + strNumberOfOrders + Environment.NewLine + "Number of Pallets -- " + strNumberOfPallets + Environment.NewLine + "Total Weight of Orders -- " + strTotalWeightOfOrders + Environment.NewLine + Environment.NewLine + "Please note -- these numbers above are as of 3:00PM EST. These numbers can change as more orders can be added."

        'Send Email
        Try
            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld-shipping@tfpcorp.com")
            MyMailMessage.To.Add("t.lerew@tfpcorp.com")
            MyMailMessage.To.Add("k.vonduyke@tfpcorp.com")
            MyMailMessage.To.Add("ryan.stibi@fedex.com")
            MyMailMessage.To.Add("joseph.steppenbacker@fedex.com")
            MyMailMessage.To.Add("john.duplain@fedex.com")
            MyMailMessage.To.Add("kevin.yelinek@fedex.com")
            MyMailMessage.Subject = "TFP Corporation FEDEX Shipment Log - " + ShippingDate
            MyMailMessage.ReplyTo = New MailAddress("truweld-shipping@tfpcorp.com")
            MyMailMessage.Body = EmailBody
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = "587"
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld-shipping@tfpcorp.com", "VonDuyke@3")
            SMPT.Send(MyMailMessage)

            MsgBox("Email sent.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox("Email not sent.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub txtLotNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLotNumber.KeyPress
        'After Lot Number is entered, set focus back to datagrid to the Row Header
        Dim CurrentLineNumber As Integer = 0
        Dim NextLineNumber As Integer = 0
        Dim TotalRows As Integer = Me.dgvShipmentLines.RowCount
        CurrentLineNumber = Val(cboShipmentLineNumber.Text)
        NextLineNumber = CurrentLineNumber + 1

        If e.KeyChar = Chr(Keys.Enter) Then

            If txtLotNumber.Text = "" Then
                If CurrentLineNumber = TotalRows Then
                    'Do nothing
                Else
                    cboShipmentLineNumber.Text = NextLineNumber

                    txtLotNumber.Focus()
                End If
            Else
                If CurrentLineNumber = TotalRows Then
                    cmdAddLotNumber_Click(sender, e)
                Else
                    cmdAddLotNumber_Click(sender, e)

                    cboShipmentLineNumber.Text = NextLineNumber

                    txtLotNumber.Focus()
                End If
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub txtLineSerialNumber2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLineSerialNumber2.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then

            cmdAddSerialNumber_Click(sender, e)

            e.Handled = True
        End If
    End Sub

    Private Sub cmdRemoteScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoteScan.Click
        Dim PickTicketFilename As String = ""
        Dim PickTicketFilenameAndPath As String = ""
        Dim strPickTicketNumber As String = ""
        Dim PickTicketNumber As Integer = 0

        'Scanning Program
        Dim My_Process As New Process()

        'Verify that they have a PickTicket selected
        If cboShipmentNumber.Text = "" Then
            MsgBox("You must select a valid PickTicket.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            PickTicketNumber = cboShipmentNumber.Text
            strPickTicketNumber = CStr(PickTicketNumber)
        End If

        PickTicketFilename = strPickTicketNumber + ".pdf"
        PickTicketFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + PickTicketFilename

        If File.Exists(PickTicketFilenameAndPath) Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to overwrite this scanned Pick Ticket?", "OVERWRITE EXISTING PICK TICKET?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Delete existing PickTicket before upload
                File.Delete(PickTicketFilenameAndPath)

                Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
                strPickTicketNumber = CStr(cboShipmentNumber.Text)
                PickTicketFilename = strPickTicketNumber + ".pdf"
                PickTicketFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + PickTicketFilename

                Try
                    My_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    My_Process.StartInfo.CreateNoWindow = True
                    My_Process.Start(ApplicationFileAndPath, "-o " & PickTicketFilenameAndPath)
                    My_Process.Close()

                    cboShipmentNumber.Refresh()
                    LoadUploadedPickTicket()
                    cboShipmentNumber.Text = PickTicketNumber
                    cmdRemoteScan.Visible = False
                    cmdUploadPickTicket.Visible = False
                    cmdViewPickTicket.Visible = True
                    MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
                Catch ex As System.Exception
                    '    'Log error on update failure
                    Dim TempPickTicketNumber As Integer = 0
                    Dim strPickTicketNumber1 As String = ""
                    TempPickTicketNumber = Val(cboShipmentNumber.Text)
                    strPickTicketNumber1 = CStr(TempPickTicketNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ApplicationFileAndPath & "" & PickTicketFilenameAndPath
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Shipment Completion --- Scan"
                    ErrorReferenceNumber = "PickTicket # " + strPickTicketNumber1
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MsgBox("Scan failed", MsgBoxStyle.OkOnly)
                End Try
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        Else
            Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"

            strPickTicketNumber = CStr(cboShipmentNumber.Text)
            PickTicketFilename = strPickTicketNumber + ".pdf"
            PickTicketFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + PickTicketFilename

            Try
                My_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                My_Process.StartInfo.CreateNoWindow = True
                My_Process.Start(ApplicationFileAndPath, "-o " & PickTicketFilenameAndPath)
                'My_Process.WaitForExit()
                My_Process.Close()

                cboShipmentNumber.Refresh()
                LoadUploadedPickTicket()
                cboShipmentNumber.Text = PickTicketNumber
                cmdRemoteScan.Visible = False
                cmdUploadPickTicket.Visible = False
                cmdViewPickTicket.Visible = True
                MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                '    'Log error on update failure
                Dim TempPickTicketNumber As Integer = 0
                Dim strPickTicketNumber1 As String = ""
                TempPickTicketNumber = Val(cboShipmentNumber.Text)
                strPickTicketNumber1 = CStr(TempPickTicketNumber)

                ErrorDate = TodaysDate
                ErrorComment = ApplicationFileAndPath & "" & PickTicketFilenameAndPath
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Complete Shipment --- Scan"
                ErrorReferenceNumber = "Pick Ticket # " + strPickTicketNumber1
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Scan failed", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub UploadPickTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadPickTicketToolStripMenuItem.Click
        cmdRemoteScan_Click(sender, e)
    End Sub
End Class