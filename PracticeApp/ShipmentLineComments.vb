Imports System
Imports System.Math
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
Imports System.Threading
Public Class ShipmentLineComments
    Inherits System.Windows.Forms.Form

    Dim ShipEmail, ShippingAccount, ShipMethod, ThirdPartyShipper, ShipmentStatus, ShipToName, CustomerName, PRONumber, ShipVia, SpecialInstructions, ShipDate, ShipAddress1, ShipAddress2, ShipCity, ShipCountry, ShipZip, ShipState, CustomerPO, Comment, FreightQuoteNumber, CustomerID, ShipToID As String
    Dim SalesOrderKey, PickTicketNumber, NumberOfBoxes, NumberOfPallets, NumberOfDoubleStackedPallets, NumberOfPalletsOnFloor, ShipmentNumber As Integer
    Dim ProductTotal, TaxTotal, ShipmentTotal, FreightQuoteAmount, ShippingWeight, FreightActualAmount As Double
    Dim PartHeatNumber, PartItemClass, PartNumber, PartDescription, LotNumber, LotPartNumber As String
    Dim PartNominalDiameter, PartNominalLength As Double
    Dim PullTestNumber, LastLotLineNumber, NextLotLineNumber As Integer
    Dim ADDAddress1, ADDAddress2, ADDCity, ADDZip, ADDState, ADDCountry, ADDToName As String
    Dim CheckShippingMethod As String = ""
    Dim RequireSaveRoutine As String = "NO"

    'Variables to update Lot Numbers in Invoice
    Dim GetInvoiceNumber As Integer = 0
    Dim ShipmentLotNumber, ShipmentHeatNumber As String
    Dim ShipmentHeatQuantity As Double

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""
    Dim TodaysDate As Date = Now()

    'Variable for third party billing
    Dim BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToName As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    'barcode variables
    Dim LabelFormat(70), V00, V01, V02, V03, V04, V05, V06, V07, V08, V09, V10, V11, V12, V13, V14, V15, V16, V17, V18, V19, V20, V21, V22, V23, V24, V25, V26, V27, V28, VDATA, VDATA1, VBAR, VBAR1 As String
    Dim LabelLines, BarCodeType, NumberOfLables As Integer

    ''check to make sure the form has loaded
    Dim isLoaded As Boolean = False
    Private Const PickTicketDir As String = "\\TFP-FS\TransferData\UploadedPickTickets"

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0

    'Public Scanning As EventHandler(Of WIA.DeviceEvents
    Dim PTUpload As PickTicketScannerUploadAPI

    Private Sub ShipmentLineComments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)

        LoadCurrentDivision()
        usefulFunctions.LoadSecurity(Me)

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)

        Me.CenterToScreen()

        If My.Computer.Name.StartsWith("TFP") Then
            cmdRemoteScan.Visible = True
            cmdUploadPickTicket.Visible = False
            cmdViewULPicks.Visible = True
            ReUploadPickTicketToolStripMenuItem.Enabled = False
            AppendUploadedPickTicketToolStripMenuItem.Enabled = False
        Else
            cmdRemoteScan.Visible = False
            cmdUploadPickTicket.Visible = True
            cmdViewULPicks.Enabled = False
        End If

        LoadPickNumber()
        LoadShipmentNumber()
        LoadShipToCountry()
        ClearVariables()
        ClearData()

        isLoaded = True

        If GlobalShipmentNumber > 0 Then
            cboShipmentNumber.Text = GlobalShipmentNumber
        Else
            cboShipmentNumber.SelectedIndex = -1
        End If

        ShowData()
        ShowLotNumbers()

        PTUpload = New PickTicketScannerUploadAPI(cmdUploadPickTicket, cboShipmentNumber, ReUploadPickTicketToolStripMenuItem, Me, AppendUploadedPickTicketToolStripMenuItem)
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

    'Load Routines for datasets

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM ShipmentLineTable WHERE DivisionID = @DivisionID AND ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentLineTable")
        dgvShipLines.DataSource = ds.Tables("ShipmentLineTable")
        con.Close()
    End Sub

    Public Sub LoadShipmentNumber()
        cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ShipmentHeaderTable")
        cboShipmentNumber.DataSource = ds1.Tables("ShipmentHeaderTable")
        con.Close()
        cboShipmentNumber.SelectedIndex = -1
    End Sub

    Public Sub ShowLotNumbers()
        cmd = New SqlCommand("SELECT * FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ShipmentLineLotNumbers")
        dgvLotNumbers.DataSource = ds2.Tables("ShipmentLineLotNumbers")
        con.Close()
    End Sub

    Public Sub LoadShipToID()
        cmd = New SqlCommand("SELECT ShipToID FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "AdditionalShipTo")
        cboShipToID.DataSource = ds3.Tables("AdditionalShipTo")
        con.Close()
        cboShipToID.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentLineNumber()
        cmd = New SqlCommand("SELECT ShipmentLineNumber FROM ShipmentLineTable WHERE DivisionID = @DivisionID AND ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ShipmentLineTable")
        cboShipmentLineNumber.DataSource = ds4.Tables("ShipmentLineTable")
        cboSNShipmentLineNumber.DataSource = ds4.Tables("ShipmentLineTable")
        con.Close()
        cboShipmentLineNumber.Text = 1
        cboSNShipmentLineNumber.Text = 1
    End Sub

    Public Sub ShowSerialNumbers()
        cmd = New SqlCommand("SELECT * FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ShipmentLineSerialNumbers")
        dgvShipmentLineSerialNumbers.DataSource = ds5.Tables("ShipmentLineSerialNumbers")
        con.Close()
    End Sub

    Public Sub LoadShipToCountry()
        cmd = New SqlCommand("SELECT Country FROM CountryCodes", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "CountryCodes")
        cboShipToCountryName.DataSource = ds6.Tables("CountryCodes")
        con.Close()
        cboShipToCountryName.SelectedIndex = -1
    End Sub

    Public Sub LoadPickNumber()
        cmd = New SqlCommand("SELECT PickTicketNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID ORDER BY PickTicketNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "ShipmentHeaderTable")
        cboPickTicketNumber.DataSource = ds7.Tables("ShipmentHeaderTable")
        con.Close()
        cboPickTicketNumber.SelectedIndex = -1
    End Sub


    'Load routines for form data

    Public Sub LoadSTCountryByCountryCode()
        Dim LoadSTCountry As String = ""

        Dim LoadCountryStatement As String = "SELECT Country FROM CountryCodes WHERE CountryCode = @CountryCode"
        Dim LoadCountryCommand As New SqlCommand(LoadCountryStatement, con)
        LoadCountryCommand.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = txtCountry.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadSTCountry = CStr(LoadCountryCommand.ExecuteScalar)
        Catch ex As System.Exception
            LoadSTCountry = ""
        End Try
        con.Close()

        cboShipToCountryName.Text = LoadSTCountry
    End Sub

    Public Sub LoadSTCountryCodeByCountry()
        Dim LoadSTCountryCode As String = ""

        Dim LoadCountryCodeStatement As String = "SELECT CountryCode FROM CountryCodes WHERE Country = @Country"
        Dim LoadCountryCodeCommand As New SqlCommand(LoadCountryCodeStatement, con)
        LoadCountryCodeCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = cboShipToCountryName.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadSTCountryCode = CStr(LoadCountryCodeCommand.ExecuteScalar)
        Catch ex As System.Exception
            LoadSTCountryCode = ""
        End Try
        con.Close()

        txtCountry.Text = LoadSTCountryCode
    End Sub

    Public Sub LoadShipmentNumberFromPickNumber()
        Dim LoadShipmentFromPick As Integer = 0

        Dim LoadShipmentFromPickStatement As String = "SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE PickTicketNumber = @PickTicketNumber AND DivisionID = @DivisionID"
        Dim LoadShipmentFromPickCommand As New SqlCommand(LoadShipmentFromPickStatement, con)
        LoadShipmentFromPickCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(cboPickTicketNumber.Text)
        LoadShipmentFromPickCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadShipmentFromPick = CInt(LoadShipmentFromPickCommand.ExecuteScalar)
        Catch ex As System.Exception
            LoadShipmentFromPick = 0
        End Try
        con.Close()

        cboShipmentNumber.Text = LoadShipmentFromPick
    End Sub

    Public Sub LoadPartNumbers()
        Dim PartNumberStatement As String = "SELECT PartNumber, PartDescription FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
        Dim PartNumberCommand As New SqlCommand(PartNumberStatement, con)
        PartNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        PartNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = PartNumberCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            PartNumber = reader.Item("PartNumber")
            PartDescription = reader.Item("PartDescription")
        End If
        reader.Close()
        con.Close()

        lblPartNumber.Text = PartNumber
        lblPartDescription.Text = PartDescription
        lblSNPartNumber.Text = PartNumber
        lblSNPartDescription.Text = PartDescription
    End Sub

    Public Sub LoadShipmentData()
        'Load Shipment Data
        Dim GetShippingDataStatement As String = "SELECT * FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim GetShippingData As New SqlCommand(GetShippingDataStatement, con)
        GetShippingData.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        GetShippingData.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim NumberOfBoxesStatement As String = "SELECT SUM(LineBoxes) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim NumberOfBoxesCommand As New SqlCommand(NumberOfBoxesStatement, con)
        NumberOfBoxesCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        NumberOfBoxesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetShippingData.ExecuteReader()
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
                NumberOfPallets = 1
            Else
                NumberOfPallets = reader.Item("NumberOfPallets")
            End If
            If IsDBNull(reader.Item("DoubleStackedPallets")) Then
                NumberOfDoubleStackedPallets = 0
            Else
                NumberOfDoubleStackedPallets = reader.Item("DoubleStackedPallets")
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
            If IsDBNull(reader.Item("ShipZip")) Then
                ShipZip = ""
            Else
                ShipZip = reader.Item("ShipZip")
            End If
            If IsDBNull(reader.Item("ShipCountry")) Then
                ShipCountry = ""
            Else
                ShipCountry = reader.Item("ShipCountry")
            End If
            If IsDBNull(reader.Item("CustomerPO")) Then
                CustomerPO = ""
            Else
                CustomerPO = reader.Item("CustomerPO")
            End If
            If IsDBNull(reader.Item("ShipmentStatus")) Then
                ShipmentStatus = "SHIPPED"
            Else
                ShipmentStatus = reader.Item("ShipmentStatus")
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
            If IsDBNull(reader.Item("SpecialInstructions")) Then
                SpecialInstructions = ""
            Else
                SpecialInstructions = reader.Item("SpecialInstructions")
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
                ShipToName = ""
            Else
                ShipToName = reader.Item("ShipToName")
            End If
            If IsDBNull(reader.Item("ShipEmail")) Then
                ShipEmail = ""
            Else
                ShipEmail = reader.Item("ShipEmail")
            End If
            If IsDBNull(reader.Item("ShippingAccount")) Then
                ShippingAccount = ""
            Else
                ShippingAccount = reader.Item("ShippingAccount")
            End If
        Else
            SalesOrderKey = 0
            ShipDate = ""
            Comment = ""
            PickTicketNumber = 0
            ShipVia = "DELIVERY"
            PRONumber = ""
            FreightQuoteNumber = ""
            FreightQuoteAmount = 0
            FreightActualAmount = 0
            ShippingWeight = 0
            NumberOfPallets = 1
            NumberOfDoubleStackedPallets = 0
            NumberOfPalletsOnFloor = 0
            CustomerID = ""
            ShipToID = ""
            ShipAddress1 = ""
            ShipAddress2 = ""
            ShipCity = ""
            ShipState = ""
            ShipZip = ""
            ShipCountry = ""
            CustomerPO = ""
            ShipmentStatus = "SHIPPED"
            ProductTotal = 0
            TaxTotal = 0
            ShipmentTotal = 0
            SpecialInstructions = ""
            ShipMethod = ""
            ThirdPartyShipper = ""
            ShipToName = ""
            ShipEmail = ""
            ShippingAccount = ""
        End If
        reader.Close()

        Try
            NumberOfBoxes = CInt(NumberOfBoxesCommand.ExecuteScalar)
        Catch ex As System.Exception
            NumberOfBoxes = 0
        End Try
        con.Close()

        lblSONumber.Text = SalesOrderKey
        lblShipDate.Text = ShipDate
        txtComments.Text = Comment
        cboPickTicketNumber.Text = PickTicketNumber
        txtPRONumber.Text = PRONumber
        txtFreightQuoteNumber.Text = FreightQuoteNumber
        txtFreightQuoteAmount.Text = FreightQuoteAmount
        lblFreight.Text = FormatCurrency(FreightActualAmount, 2)
        txtFreight.Text = FreightActualAmount
        txtShipWeight.Text = ShippingWeight
        txtNumberPallets.Text = NumberOfPallets
        txtDoubleStackedPallets.Text = NumberOfDoubleStackedPallets
        lblPalletsOnFloor.Text = NumberOfPalletsOnFloor
        lblCustomerID.Text = CustomerID
        cboShipVia.Text = ShipVia
        cboShipMethod.Text = ShipMethod
        txtThirdParty.Text = ThirdPartyShipper
        txtShippingAccount.Text = ShippingAccount
        lblShipEmail.Text = ShipEmail

        If cboShipMethod.Text = "THIRD PARTY" Then
            txtThirdParty.Enabled = True
        Else
            txtThirdParty.Enabled = False
        End If

        LoadShipToID()

        If ShipToID = "" Then
            'Do nothing
        Else
            cboShipToID.Text = ShipToID
        End If

        txtAddress1.Text = ShipAddress1
        txtAddress2.Text = ShipAddress2
        txtCity.Text = ShipCity
        txtCountry.Text = ShipCountry
        txtShipToName.Text = ShipToName
        txtZip.Text = ShipZip
        cboState.Text = ShipState

        txtCustomerPO.Text = CustomerPO
        txtSpecialInstructions.Text = SpecialInstructions

        'Get Pull Test Number for selected Lot Number Data
        Dim GetCustomerNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetCustomerNameCommand As New SqlCommand(GetCustomerNameStatement, con)
        GetCustomerNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
        GetCustomerNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName = CStr(GetCustomerNameCommand.ExecuteScalar)
        Catch ex As System.Exception
            CustomerName = ""
        End Try
        con.Close()

        lblNumberBoxes.Text = NumberOfBoxes
        lblCustomerName.Text = CustomerName
        lblProductTotal.Text = FormatCurrency(ProductTotal, 2)
        lblSalesTax.Text = FormatCurrency(TaxTotal, 2)
        lblShipmentTotal.Text = FormatCurrency(ShipmentTotal, 2)
        lblStatus.Text = ShipmentStatus

        If ShipmentStatus = "INVOICED" Then
            txtFreight.Enabled = False
        Else
            txtFreight.Enabled = True
        End If
    End Sub

    Public Sub LoadAdditionalShipTo()
        Dim GetAddressStatement As String = "SELECT Address1, Address2, City, State, Zip, Country, Name FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipToID = @ShipToID"
        Dim GetAddressCommand As New SqlCommand(GetAddressStatement, con)
        GetAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
        GetAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetAddressCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetAddressCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Address1")) Then
                ADDAddress1 = ""
            Else
                ADDAddress1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                ADDAddress2 = ""
            Else
                ADDAddress2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                ADDCity = ""
            Else
                ADDCity = reader.Item("City")
            End If
            If IsDBNull(reader.Item("State")) Then
                ADDState = ""
            Else
                ADDState = reader.Item("State")
            End If
            If IsDBNull(reader.Item("Zip")) Then
                ADDZip = ""
            Else
                ADDZip = reader.Item("Zip")
            End If
            If IsDBNull(reader.Item("Country")) Then
                ADDCountry = ""
            Else
                ADDCountry = reader.Item("Country")
            End If
            If IsDBNull(reader.Item("Name")) Then
                ADDToName = ""
            Else
                ADDToName = reader.Item("Name")
            End If
        Else
            ADDAddress1 = ""
            ADDAddress2 = ""
            ADDCity = ""
            ADDState = ""
            ADDZip = ""
            ADDCountry = ""
            ADDToName = ""
        End If
        reader.Close()
        con.Close()

        txtAddress1.Text = ADDAddress1
        txtAddress2.Text = ADDAddress2
        txtCity.Text = ADDCity
        txtCountry.Text = ADDCountry
        txtZip.Text = ADDZip
        cboState.Text = ADDState
        txtShipToName.Text = ShipToName
    End Sub

    Public Sub LoadStatusAndVerifyData()
        Dim GetShipmentStatus As String = ""

        'Get Pull Test Number for selected Lot Number Data
        Dim GetShipmentStatusStatement As String = "SELECT ShipmentStatus FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim GetShipmentStatusCommand As New SqlCommand(GetShipmentStatusStatement, con)
        GetShipmentStatusCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        GetShipmentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetShipmentStatus = CStr(GetShipmentStatusCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetShipmentStatus = ""
        End Try
        con.Close()

        If GetShipmentStatus = "INVOICED" Then
            txtFreight.Enabled = False
        Else
            txtFreight.Enabled = True
        End If

        If GetShipmentStatus = "INVOICED" And cboShipMethod.Text = "PREPAID/ADD" Then
            cboShipMethod.Enabled = False
        Else
            cboShipMethod.Enabled = True
        End If
    End Sub

    Public Sub LoadUploadedPickTicket()
        If cboShipmentNumber.Text <> "" Then
            Dim UploadedShipmentNumber As String = ""
            Dim UploadedFileName As String = ""
            Dim UploadedFilenameAndPath As String = ""

            UploadedShipmentNumber = cboShipmentNumber.Text

            UploadedFileName = UploadedShipmentNumber + ".pdf"
            UploadedFilenameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets" + "\" + UploadedFileName

            If My.Computer.Name.StartsWith("TFP") Then
                If File.Exists(UploadedFilenameAndPath) Then
                    cmdViewULPicks.Enabled = True
                    cmdViewULPicks.Visible = True
                    cmdUploadPickTicket.Visible = False
                    cmdRemoteScan.Visible = True
                    ReUploadPickTicketToolStripMenuItem.Enabled = False
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = False
                Else
                    cmdViewULPicks.Enabled = False
                    cmdViewULPicks.Visible = True
                    cmdUploadPickTicket.Visible = False
                    cmdRemoteScan.Visible = True
                    ReUploadPickTicketToolStripMenuItem.Enabled = False
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = False
                End If
            Else
                If File.Exists(UploadedFilenameAndPath) Then
                    cmdViewULPicks.Visible = True
                    cmdViewULPicks.Enabled = True
                    cmdUploadPickTicket.Enabled = False
                    cmdRemoteScan.Visible = False
                    ReUploadPickTicketToolStripMenuItem.Enabled = True
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = True
                Else
                    cmdViewULPicks.Enabled = False
                    cmdViewULPicks.Visible = True
                    cmdUploadPickTicket.Enabled = True
                    cmdRemoteScan.Visible = False
                    ReUploadPickTicketToolStripMenuItem.Enabled = False
                    AppendUploadedPickTicketToolStripMenuItem.Enabled = False
                End If
            End If
        Else
            'Do nothing
        End If
    End Sub

    'Insert/Update Commands

    Public Sub UpdateShipmentHeaderTable()
        cmd = New SqlCommand("Update ShipmentHeaderTable SET Comment = @Comment, PRONumber = @PRONumber, FreightQuoteNumber = @FreightQuoteNumber, FreightQuoteAmount = @FreightQuoteAmount, CustomerPO = @CustomerPO, SpecialInstructions = @SpecialInstructions, ShippingWeight = @ShippingWeight, NumberOfPallets = @NumberOfPallets, DoubleStackedPallets = @DoubleStackedPallets, PalletsOnFloor = @PalletsOnFloor, ShipToID = @ShipToID, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZip = @ShipZip, ShipCountry = @ShipCountry, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName, ShippingAccount = @ShippingAccount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComments.Text
            .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
            .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
            .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtFreightQuoteAmount.Text)
            '.Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
            '.Add("@ShipmentTotal", SqlDbType.VarChar).Value = ShipmentTotal
            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
            .Add("@ShippingWeight", SqlDbType.VarChar).Value = Val(txtShipWeight.Text)
            .Add("@NumberOfPallets", SqlDbType.VarChar).Value = Val(txtNumberPallets.Text)
            .Add("@DoubleStackedPallets", SqlDbType.VarChar).Value = Val(txtDoubleStackedPallets.Text)
            .Add("@PalletsOnFloor", SqlDbType.VarChar).Value = Val(lblPalletsOnFloor.Text)
            .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            .Add("@ShipAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
            .Add("@ShipAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
            .Add("@ShipCity", SqlDbType.VarChar).Value = txtCity.Text
            .Add("@ShipState", SqlDbType.VarChar).Value = cboState.Text
            .Add("@ShipZip", SqlDbType.VarChar).Value = txtZip.Text
            .Add("@ShipCountry", SqlDbType.VarChar).Value = txtCountry.Text
            .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
            .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
            .Add("@ShipToName", SqlDbType.VarChar).Value = txtShipToName.Text
            .Add("@ShippingAccount", SqlDbType.VarChar).Value = txtShippingAccount.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub UpdateShipmentHeaderTableWithFreight()
        cmd = New SqlCommand("Update ShipmentHeaderTable SET Comment = @Comment, PRONumber = @PRONumber, FreightQuoteNumber = @FreightQuoteNumber, FreightQuoteAmount = @FreightQuoteAmount, FreightActualAmount = @FreightActualAmount, CustomerPO = @CustomerPO, ShipmentTotal = @ShipmentTotal, SpecialInstructions = @SpecialInstructions, ShippingWeight = @ShippingWeight, NumberOfPallets = @NumberOfPallets, DoubleStackedPallets = @DoubleStackedPallets, PalletsOnFloor = @PalletsOnFloor, ShipToID = @ShipToID, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZip = @ShipZip, ShipCountry = @ShipCountry, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName, ShippingAccount = @ShippingAccount WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComments.Text
            .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
            .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
            .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtFreightQuoteAmount.Text)
            .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
            .Add("@ShipmentTotal", SqlDbType.VarChar).Value = ShipmentTotal
            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
            .Add("@ShippingWeight", SqlDbType.VarChar).Value = Val(txtShipWeight.Text)
            .Add("@NumberOfPallets", SqlDbType.VarChar).Value = Val(txtNumberPallets.Text)
            .Add("@DoubleStackedPallets", SqlDbType.VarChar).Value = Val(txtDoubleStackedPallets.Text)
            .Add("@PalletsOnFloor", SqlDbType.VarChar).Value = Val(lblPalletsOnFloor.Text)
            .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            .Add("@ShipAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
            .Add("@ShipAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
            .Add("@ShipCity", SqlDbType.VarChar).Value = txtCity.Text
            .Add("@ShipState", SqlDbType.VarChar).Value = cboState.Text
            .Add("@ShipZip", SqlDbType.VarChar).Value = txtZip.Text
            .Add("@ShipCountry", SqlDbType.VarChar).Value = txtCountry.Text
            .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
            .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
            .Add("@ShipToName", SqlDbType.VarChar).Value = txtShipToName.Text
            .Add("@ShippingAccount", SqlDbType.VarChar).Value = txtShippingAccount.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Command Buttons

    Private Sub cmdAddLotNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLotNumber.Click
        Dim GetPullTestNumber As String = ""
        Dim GetMinPartNumber As String = ""
        Dim MinTensileFilter As String = ""
        Dim MinYieldFilter As String = ""
        Dim ROAPercentFilter As String = ""
        Dim ElongationPercentFilter As String = ""
        Dim strMinTensile As String = ""
        Dim strMinYield As String = ""
        Dim strROAPercent As String = ""
        Dim strElongationPercent As String = ""
        Dim CEVValueFilter As String = ""
        Dim strMaxTensile As String = ""
        Dim strMaxYield As String = ""
        Dim MaxTensileFilter As String = ""
        Dim MaxYieldFilter As String = ""

        'Verify Lot Number Matches Part Number
        Dim LotNumberStatement As String = "SELECT PartNumber FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim LotNumberCommand As New SqlCommand(LotNumberStatement, con)
        LotNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LotPartNumber = CStr(LotNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            LotPartNumber = ""
        End Try
        con.Close()

        If lblPartNumber.Text = LotPartNumber Then
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
            Catch ex As System.Exception
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
            Catch ex As System.Exception
                CheckCertType = ""
                ShipmentCertType = CheckCertType
            End Try
            con.Close()

            If CheckCertType = "" Or CheckCertType = "0" Then
                Dim GetFOXCertTypeStatement As String = "SELECT CertificationType FROM FOXTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
                Dim GetFOXCertTypeCommand As New SqlCommand(GetFOXCertTypeStatement, con)
                GetFOXCertTypeCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = lblPartNumber.Text
                GetFOXCertTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetFOXCertType = CStr(GetFOXCertTypeCommand.ExecuteScalar)
                    ShipmentCertType = GetFOXCertType
                Catch ex As System.Exception
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
                Catch ex As System.Exception
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
                    Catch ex As System.Exception
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
                    Catch ex As System.Exception
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
                    Catch ex As System.Exception
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
                    Catch ex As System.Exception
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
                    Catch ex As System.Exception
                        Yield2OffsetPSI = 0
                    End Try
                    Try
                        YieldUltimatePSI = CDbl(YieldUltimatePSICommand.ExecuteScalar)
                    Catch ex As System.Exception
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
                            .Add("@PartNumber", SqlDbType.VarChar).Value = lblPartNumber.Text
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                            .Add("@Comment", SqlDbType.VarChar).Value = "View/Edit Shipments"
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As System.Exception
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
                Catch ex As System.Exception
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
                    Catch ex As System.Exception
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
                    Catch ex As System.Exception
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
                    Catch ex As System.Exception
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
                    Catch ex As System.Exception
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
                    Catch ex As System.Exception
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
                            .Add("@PartNumber", SqlDbType.VarChar).Value = lblPartNumber.Text
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                            .Add("@Comment", SqlDbType.VarChar).Value = "View/Edit Shipments"
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As System.Exception
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
                Catch ex As System.Exception
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
                    Catch ex As System.Exception
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
                    Catch ex As System.Exception
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
                            .Add("@PartNumber", SqlDbType.VarChar).Value = lblPartNumber.Text
                            .Add("@HeatNumber", SqlDbType.VarChar).Value = PartHeatNumber
                            .Add("@Comment", SqlDbType.VarChar).Value = "View/Edit Shipments"
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As System.Exception
                        'Skip
                    End Try
                End If
            End If
            '****************************************************************************************************************************
            'Find the next Shipment Lot Line Number to use
            Dim MAXStatement As String = "SELECT MAX(LotLineNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)
            MAXCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            MAXCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboShipmentLineNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastLotLineNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As System.Exception
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

            ShowLotNumbers()

            'Clear Lot Number
            txtLotNumber.Clear()
            txtHeatQuantity.Clear()

            If cboDivisionID.Text = "TWD" Then
                RequireSaveRoutine = "YES"
                cboShipmentNumber.Enabled = False
            Else
                RequireSaveRoutine = "NO"
                cboShipmentNumber.Enabled = True
            End If

            MsgBox("Lot Number Entered.", MsgBoxStyle.OkOnly)
        Else
            MsgBox("Lot Number does not match Part Number selected - please re-check.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdPackList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPackList.Click
        If canSave() Then
            If ShipmentStatus <> "INVOICED" Then
                'Validate Shipping Method
                ValidateShippingMethod()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                Dim ProductTotalStatement As String = "SELECT ProductTotal, TaxTotal FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
                ProductTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = ProductTotalCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
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
                Else
                    ProductTotal = 0
                    TaxTotal = 0
                End If
                reader.Close()
                con.Close()
                '***********************************************************************************
                If Val(txtFreight.Text) > 10000 Then
                    MsgBox("Freight Billed cannot be this high. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                FreightActualAmount = Val(txtFreight.Text)
                ShipmentTotal = ProductTotal + TaxTotal + FreightActualAmount
                lblFreight.Text = FormatCurrency(FreightActualAmount, 2)
                lblShipmentTotal.Text = FormatCurrency(ShipmentTotal, 2)

                'Create Add Ship To
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As System.Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do Nothing
                End If
                '***********************************************************************************
                Try
                    UpdateShipmentHeaderTableWithFreight()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Shipment Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************
                Try
                    'UPDATE Invoice Table with PRO Number
                    cmd = New SqlCommand("Update InvoiceHeaderTable SET PRONumber = @PRONumber, CustomerPO = @CustomerPO, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Invoice Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Validate Shipping Method
                ValidateShippingMethod()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                If Val(txtFreight.Text) > 10000 Then
                    MsgBox("Freight Billed cannot be this high. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                'Create Add Ship To
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As System.Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do Nothing
                End If
                '***********************************************************************************
                Try
                    'Save data if shipment has been invoiced
                    UpdateShipmentHeaderTable()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Shipment Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************
                Try
                    'UPDATE Invoice Table with PRO Number
                    cmd = New SqlCommand("Update InvoiceHeaderTable SET PRONumber = @PRONumber, CustomerPO = @CustomerPO, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Invoice Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        End If

        GlobalShipmentNumber = Val(cboShipmentNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text
        GlobalCertCustomer = lblCustomerID.Text

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

    Private Sub cmdCert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCert.Click
        If canSave() Then
            If ShipmentStatus <> "INVOICED" Then
                'Validate Shipping Method
                ValidateShippingMethod()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                Dim ProductTotalStatement As String = "SELECT ProductTotal, TaxTotal FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
                ProductTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = ProductTotalCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
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
                Else
                    ProductTotal = 0
                    TaxTotal = 0
                End If
                reader.Close()
                con.Close()
                '***********************************************************************************
                If Val(txtFreight.Text) > 10000 Then
                    MsgBox("Freight Billed cannot be this high. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                FreightActualAmount = Val(txtFreight.Text)
                ShipmentTotal = ProductTotal + TaxTotal + FreightActualAmount
                lblFreight.Text = FormatCurrency(FreightActualAmount, 2)
                lblShipmentTotal.Text = FormatCurrency(ShipmentTotal, 2)

                'Create Add Ship To
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As System.Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do Nothing
                End If
                '***********************************************************************************
                Try
                    UpdateShipmentHeaderTableWithFreight()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Invoice Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************
                Try
                    'UPDATE Invoice Table with PRO Number
                    cmd = New SqlCommand("Update InvoiceHeaderTable SET PRONumber = @PRONumber, CustomerPO = @CustomerPO, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Invoice Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Validate Shipping Method
                ValidateShippingMethod()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                If Val(txtFreight.Text) > 10000 Then
                    MsgBox("Freight Billed cannot be this high. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                'Create Add Ship To
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As System.Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do Nothing
                End If
                '***********************************************************************************
                Try
                    'Save data if shipment has been invoiced
                    UpdateShipmentHeaderTable()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Shipment Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************
                Try
                    'UPDATE Invoice Table with PRO Number
                    cmd = New SqlCommand("Update InvoiceHeaderTable SET PRONumber = @PRONumber, CustomerPO = @CustomerPO, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Invoice Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        End If

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

            GlobalShipmentNumber = Val(cboShipmentNumber.Text)
            GlobalDivisionCode = cboDivisionID.Text
            GlobalCertCustomer = lblCustomerID.Text

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
    End Sub

    Private Sub cmdBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBOL.Click
        'Run save Routine
        If canSave() Then
            If ShipmentStatus <> "INVOICED" Then
                'Validate Shipping Method
                ValidateShippingMethod()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                Dim ProductTotalStatement As String = "SELECT ProductTotal, TaxTotal FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
                ProductTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = ProductTotalCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
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
                Else
                    ProductTotal = 0
                    TaxTotal = 0
                End If
                reader.Close()
                con.Close()
                '***********************************************************************************
                If Val(txtFreight.Text) > 10000 Then
                    MsgBox("Freight Billed cannot be this high. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                FreightActualAmount = Val(txtFreight.Text)
                ShipmentTotal = ProductTotal + TaxTotal + FreightActualAmount
                lblFreight.Text = FormatCurrency(FreightActualAmount, 2)
                lblShipmentTotal.Text = FormatCurrency(ShipmentTotal, 2)

                'Create Add Ship To
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As System.Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do Nothing
                End If
                '***********************************************************************************
                Try
                    UpdateShipmentHeaderTableWithFreight()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Shipment Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************
                Try
                    'UPDATE Invoice Table with PRO Number
                    cmd = New SqlCommand("Update InvoiceHeaderTable SET PRONumber = @PRONumber, CustomerPO = @CustomerPO, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Invoice Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Validate Shipping Method
                ValidateShippingMethod()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                If Val(txtFreight.Text) > 10000 Then
                    MsgBox("Freight Billed cannot be this high. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                'Create Add Ship To
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As System.Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do Nothing
                End If
                '***********************************************************************************
                Try
                    'Save data if shipment has been invoiced
                    UpdateShipmentHeaderTable()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Shipment Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************
                Try
                    'UPDATE Invoice Table with PRO Number
                    cmd = New SqlCommand("Update InvoiceHeaderTable SET PRONumber = @PRONumber, CustomerPO = @CustomerPO, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Invoice Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        End If

        GlobalShipmentNumber = Val(cboShipmentNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text
        GlobalCertCustomer = lblCustomerID.Text

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
    End Sub

    Private Sub cmdUpdateInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateInvoice.Click
        Dim RowLineNumber As Integer = 0
        Dim LotLineNumber As Integer = 0

        'Get Invoice Number for Shipment
        Dim GetInvoiceNumberStatement As String = "SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim GetInvoiceNumberCommand As New SqlCommand(GetInvoiceNumberStatement, con)
        GetInvoiceNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        GetInvoiceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetInvoiceNumber = CInt(GetInvoiceNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetInvoiceNumber = 0
        End Try
        con.Close()

        If GetInvoiceNumber = 0 And Me.dgvLotNumbers.RowCount > 0 Then
            MsgBox("No invoice exists for this shipment.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Delete any existing Lot Lines for Invoice
            cmd = New SqlCommand("DELETE FROM InvoiceLotLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = GetInvoiceNumber

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Get each row from shipment lot lines
            For Each row As DataGridViewRow In dgvLotNumbers.Rows
                Try
                    RowLineNumber = row.Cells("ShipmentLineNumberColumn2").Value
                Catch ex As System.Exception
                    RowLineNumber = 0
                End Try
                Try
                    LotLineNumber = row.Cells("LotLineNumberColumn2").Value
                Catch ex As System.Exception
                    LotLineNumber = 0
                End Try
                Try
                    ShipmentLotNumber = row.Cells("LotNumberColumn2").Value
                Catch ex As System.Exception
                    ShipmentLotNumber = ""
                End Try
                Try
                    ShipmentHeatQuantity = row.Cells("HeatQuantityColumn2").Value
                Catch ex As System.Exception
                    ShipmentHeatQuantity = 0
                End Try

                'Get Heat Number for the selected Lot Number
                Dim GetHeatNumberStatement As String = "SELECT HeatNumber FROM LotNumber WHERE LotNumber = @LotNumber"
                Dim GetHeatNumberCommand As New SqlCommand(GetHeatNumberStatement, con)
                GetHeatNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = ShipmentLotNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ShipmentHeatNumber = CStr(GetHeatNumberCommand.ExecuteScalar)
                Catch ex As System.Exception
                    ShipmentHeatNumber = ""
                End Try
                con.Close()

                Try
                    'Write to Invoice Lot Line Table
                    cmd = New SqlCommand("Insert Into InvoiceLotLineTable(InvoiceNumber, InvoiceLineNumber, InvoiceLotLineNumber, InvoiceLotNumber, InvoiceHeatNumber, InvoiceHeatQuantity) Values (@InvoiceNumber, @InvoiceLineNumber, @InvoiceLotLineNumber, @InvoiceLotNumber, @InvoiceHeatNumber, @InvoiceHeatQuantity)", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = GetInvoiceNumber
                        .Add("@InvoiceLineNumber", SqlDbType.VarChar).Value = RowLineNumber
                        .Add("@InvoiceLotLineNumber", SqlDbType.VarChar).Value = LotLineNumber
                        .Add("@InvoiceLotNumber", SqlDbType.VarChar).Value = ShipmentLotNumber
                        .Add("@InvoiceHeatNumber", SqlDbType.VarChar).Value = ShipmentHeatNumber
                        .Add("@InvoiceHeatQuantity", SqlDbType.VarChar).Value = ShipmentHeatQuantity
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Update Invoice Lot #'s"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Next

            MsgBox("Invoice has been updated with lot numbers.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdDeleteLotNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLotNumber.Click
        Dim RowLotNumber As String
        Dim RowLineNumber, RowLotLineNumber As Integer

        If Me.dgvLotNumbers.RowCount <> 0 Then

            Dim RowIndex As Integer = Me.dgvLotNumbers.CurrentCell.RowIndex

            Try
                RowLotNumber = Me.dgvLotNumbers.Rows(RowIndex).Cells("LotNumberColumn2").Value
            Catch ex As System.Exception
                RowLotNumber = ""
            End Try
            Try
                RowLineNumber = Me.dgvLotNumbers.Rows(RowIndex).Cells("ShipmentLineNumberColumn2").Value
            Catch ex As System.Exception
                RowLineNumber = 0
            End Try
            Try
                RowLotLineNumber = Me.dgvLotNumbers.Rows(RowIndex).Cells("LotLineNumberColumn2").Value
            Catch ex As System.Exception
                RowLotLineNumber = 0
            End Try

            Try
                cmd = New SqlCommand("DELETE FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotLineNumber = @LotLineNumber AND LotNumber = @LotNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowLineNumber
                    .Add("@LotLineNumber", SqlDbType.VarChar).Value = RowLotLineNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowLotNumbers()

                If cboDivisionID.Text = "TWD" Then
                    RequireSaveRoutine = "YES"
                    cboShipmentNumber.Enabled = False
                Else
                    RequireSaveRoutine = "NO"
                    cboShipmentNumber.Enabled = True
                End If
            Catch ex As System.Exception
                'Log error on update failure
                Dim TempShipNumber As Integer = 0
                Dim strShipNumber As String
                TempShipNumber = Val(cboShipmentNumber.Text)
                strShipNumber = CStr(TempShipNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "View/Edit Shipments --- Delete Lot Number Failure"
                ErrorReferenceNumber = "Shipment # " + strShipNumber + " - Lot # - " + txtLotNumber.Text
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If RequireSaveRoutine = "YES" Then
            'Check to see if lot quantity matches line quantity
            If cboDivisionID.Text = "TWD" Then













            Else
                'Skip
            End If
            '**********************************************************************************
            'Check to make sure serial quantity matches line quantities
            If cboDivisionID.Text = "TWE" Then
                Dim RowLineNumber As Integer = 0
                Dim RowPartNumber As String = ""
                Dim RowQuantity As Double = 0
                Dim CheckIfSerialized As String = ""
                Dim SumSerialQuantity As Integer = 0

                'Get each row from shipment lot lines
                For Each row As DataGridViewRow In dgvShipLines.Rows
                    Try
                        RowLineNumber = row.Cells("ShipmentLineNumberColumn").Value
                    Catch ex As System.Exception
                        RowLineNumber = 0
                    End Try
                    Try
                        RowPartNumber = row.Cells("PartNumberColumn").Value
                    Catch ex As System.Exception
                        RowPartNumber = ""
                    End Try
                    Try
                        RowQuantity = row.Cells("QuantityShippedColumn").Value
                    Catch ex As System.Exception
                        RowQuantity = 0
                    End Try

                    'Query database to see if it is a serialized assembly
                    Dim CheckIfSerializedStatement As String = "SELECT SerializedStatus FROM AssemblyHeaderTable WHERE AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID"
                    Dim CheckIfSerializedCommand As New SqlCommand(CheckIfSerializedStatement, con)
                    CheckIfSerializedCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    CheckIfSerializedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckIfSerialized = CStr(CheckIfSerializedCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        CheckIfSerialized = "NO"
                    End Try
                    con.Close()

                    If CheckIfSerialized = "YES" Then
                        Dim SumSerialQuantityStatement As String = "SELECT SUM(SerialQuantity) FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
                        Dim SumSerialQuantityCommand As New SqlCommand(SumSerialQuantityStatement, con)
                        SumSerialQuantityCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        SumSerialQuantityCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowLineNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            SumSerialQuantity = CInt(SumSerialQuantityCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            SumSerialQuantity = 0
                        End Try
                        con.Close()

                        If SumSerialQuantity = RowQuantity Then
                            'Skip
                        Else
                            MsgBox("The number of serial #'s must match the line quantity. Check lines before exiting.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End If
                    Else
                        'Skip this part - not serialized
                    End If
                Next
            Else
                'Skip
            End If
            '**********************************************************************************
            ClearVariables()
            ClearData()
            Me.Dispose()
            Me.Close()
        Else
            ClearVariables()
            ClearData()
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If canSave() Then
            If ShipmentStatus = "INVOICED" Then
                'Check Shipping Method
                Dim TempShippingMethod As String = ""

                Dim TempShippingMethodStatement As String = "SELECT ShippingMethod FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim TempShippingMethodCommand As New SqlCommand(TempShippingMethodStatement, con)
                TempShippingMethodCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                TempShippingMethodCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TempShippingMethod = CStr(TempShippingMethodCommand.ExecuteScalar)
                Catch ex As System.Exception
                    TempShippingMethod = ""
                End Try
                con.Close()

                If TempShippingMethod = "PREPAID/ADD" And cboShipMethod.Text <> "PREPAID/ADD" Then
                    MsgBox("You cannot change ship method from Prepaid/Add when it has already been invoiced.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                If TempShippingMethod <> "PREPAID/ADD" And cboShipMethod.Text = "PREPAID/ADD" Then
                    MsgBox("You cannot change ship method to Prepaid/Add when it has already been invoiced.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Else
                'Skip
            End If

            If ShipmentStatus <> "INVOICED" Then
                'Validate Shipping Method
                ValidateShippingMethod()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                If Val(txtFreight.Text) > 10000 Then
                    MsgBox("Freight Billed cannot be this high. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                Dim ProductTotalStatement As String = "SELECT ProductTotal, TaxTotal FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
                ProductTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = ProductTotalCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
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
                Else
                    ProductTotal = 0
                    TaxTotal = 0
                End If
                reader.Close()
                con.Close()

                FreightActualAmount = Val(txtFreight.Text)
                ShipmentTotal = ProductTotal + TaxTotal + FreightActualAmount
                lblFreight.Text = FormatCurrency(FreightActualAmount, 2)
                lblShipmentTotal.Text = FormatCurrency(ShipmentTotal, 2)
                '***********************************************************************************
                'Create Add Ship To
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As System.Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do Nothing
                End If
                '***********************************************************************************
                Try
                    UpdateShipmentHeaderTableWithFreight()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Shipment Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Validate Shipping Method
                ValidateShippingMethod()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method and/or details", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                'Create Add Ship To
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As System.Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do Nothing
                End If
                '***********************************************************************************
                Try
                    'Save data if shipment has been invoiced
                    UpdateShipmentHeaderTable()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Shipment Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************
                Dim ProNumberString As String = ""
                Dim CustomerPOString As String = ""

                If txtPRONumber.Text = "" Then
                    ProNumberString = ""
                Else
                    ProNumberString = ", PRONumber = @PRONumber"
                End If
                If txtCustomerPO.Text = "" Then
                    CustomerPOString = ""
                Else
                    CustomerPOString = ", CustomerPO = @CustomerPO"
                End If

                Try
                    'UPDATE Invoice Table with PRO Number
                    cmd = New SqlCommand("Update InvoiceHeaderTable SET ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper" + ProNumberString + CustomerPOString + " WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Invoice Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
            '***********************************************************************************
            ShowData()
            ShowLotNumbers()
            MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdDeleteSerialNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSerialNumber.Click
        Dim RowSerialNumber As String
        Dim RowLineNumber, RowSerialLineNumber As Integer

        If Me.dgvShipmentLineSerialNumbers.RowCount <> 0 Then

            Dim RowIndex As Integer = Me.dgvShipmentLineSerialNumbers.CurrentCell.RowIndex

            Try
                RowSerialNumber = Me.dgvShipmentLineSerialNumbers.Rows(RowIndex).Cells("SerialNumberColumn3").Value
            Catch ex As System.Exception
                RowSerialNumber = ""
            End Try
            Try
                RowLineNumber = Me.dgvShipmentLineSerialNumbers.Rows(RowIndex).Cells("ShipmentLineNumberColumn3").Value
            Catch ex As System.Exception
                RowLineNumber = 0
            End Try
            Try
                RowSerialLineNumber = Me.dgvShipmentLineSerialNumbers.Rows(RowIndex).Cells("SerialLineNumberColumn3").Value
            Catch ex As System.Exception
                RowSerialLineNumber = 0
            End Try

            'Update serial number back to Open
            Try
                cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status, BatchNumber = @BatchNumber, TransactionNumber = @TransactionNumber, CustomerID = @CustomerID WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@CustomerID", SqlDbType.VarChar).Value = ""
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = 0
                    .Add("@TransactionNumber", SqlDbType.VarChar).Value = 0
                    .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = lblSNPartNumber.Text
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex3 As System.Exception
                'Log error on update failure
                Dim TempShipNumber As Integer = 0
                Dim strShipNumber As String
                TempShipNumber = Val(cboShipmentNumber.Text)
                strShipNumber = CStr(TempShipNumber)

                ErrorDate = Today()
                ErrorComment = ex3.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "View/Edit Shipments --- Delete Serial Number Failure"
                ErrorReferenceNumber = "Shipment # " + strShipNumber + " - Serial # - " + txtSerialNumber.Text
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            Try
                cmd = New SqlCommand("DELETE FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND SerialLineNumber = @SerialLineNumber AND SerialNumber = @SerialNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowLineNumber
                    .Add("@SerialLineNumber", SqlDbType.VarChar).Value = RowSerialLineNumber
                    .Add("@SerialNumber", SqlDbType.VarChar).Value = RowSerialNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowSerialNumbers()
                MsgBox("Serial # removed.", MsgBoxStyle.OkOnly)

                If cboDivisionID.Text = "TWE" Then
                    RequireSaveRoutine = "YES"
                    cboShipmentNumber.Enabled = False
                Else
                    RequireSaveRoutine = "NO"
                    cboShipmentNumber.Enabled = True
                End If
            Catch ex4 As System.Exception
                'Log error on update failure
                Dim TempShipNumber As Integer = 0
                Dim strShipNumber As String
                TempShipNumber = Val(cboShipmentNumber.Text)
                strShipNumber = CStr(TempShipNumber)

                ErrorDate = Today()
                ErrorComment = ex4.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "View/Edit Shipments --- Delete Serial Number Failure"
                ErrorReferenceNumber = "Shipment # " + strShipNumber + " - Serial # - " + txtSerialNumber.Text
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        End If
    End Sub

    Private Sub cmdAddSerialNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddSerialNumber.Click
        If cboSNShipmentLineNumber.Text = "" Or Val(cboSNShipmentLineNumber.Text) = 0 Then
            MsgBox("You must have a valid line number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If
        '****************************************************************************************************
        If lblSNPartNumber.Text = "" Then
            MsgBox("You must have a valid part number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If
        '****************************************************************************************************
        If txtSerialNumber.Text = "" Then
            MsgBox("You must have a valid serial number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If
        '****************************************************************************************************
        'Check to see if serial # matches the part number
        Dim CheckSerialNumber As Integer = 0

        Dim CheckSerialNumberStatement As String = "SELECT COUNT(AssemblyPartNumber) FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND Status = @Status"
        Dim CheckSerialNumberCommand As New SqlCommand(CheckSerialNumberStatement, con)
        CheckSerialNumberCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
        CheckSerialNumberCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = lblSNPartNumber.Text
        CheckSerialNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CheckSerialNumberCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckSerialNumber = CInt(CheckSerialNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            CheckSerialNumber = 0
        End Try
        con.Close()

        If CheckSerialNumber = 1 Then
            'Continue
        Else
            MsgBox("You must have a valid serial number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '****************************************************************************************************
        'Get serial data to insert into Shipment Line Serial Number table
        Dim GetSerialCost As Double = 0

        Dim GetSerialCostStatement As String = "SELECT TotalCost FROM AssemblySerialLog WHERE SerialNumber = @SerialNumber AND AssemblyPartNumber = @AssemblyPartNumber AND DivisionID = @DivisionID AND Status = @Status"
        Dim GetSerialCostCommand As New SqlCommand(GetSerialCostStatement, con)
        GetSerialCostCommand.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
        GetSerialCostCommand.Parameters.Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = lblSNPartNumber.Text
        GetSerialCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetSerialCostCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSerialCost = CDbl(GetSerialCostCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetSerialCost = 0
        End Try
        con.Close()
        '****************************************************************************************************
        'Get MAX Serial Line Number
        Dim LastSerialLineNumber, NextSerialLineNumber As Integer

        Dim MAXSerialLineNumberStatement As String = "SELECT MAX(SerialLineNumber) FROM ShipmentLineSerialNumbers WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
        Dim MAXSerialLineNumberCommand As New SqlCommand(MAXSerialLineNumberStatement, con)
        MAXSerialLineNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        MAXSerialLineNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboSNShipmentLineNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastSerialLineNumber = CInt(MAXSerialLineNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            LastSerialLineNumber = 0
        End Try
        con.Close()

        NextSerialLineNumber = LastSerialLineNumber + 1

        Try
            'Write to Invoice Lot Line Table
            cmd = New SqlCommand("Insert Into ShipmentLineSerialNumbers(ShipmentNumber, ShipmentLineNumber, SerialLineNumber, SerialNumber, SerialCost, SerialQuantity) Values (@ShipmentNumber, @ShipmentLineNumber, @SerialLineNumber, @SerialNumber, @SerialCost, @SerialQuantity)", con)

            With cmd.Parameters
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = Val(cboSNShipmentLineNumber.Text)
                .Add("@SerialLineNumber", SqlDbType.VarChar).Value = NextSerialLineNumber
                .Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                .Add("@SerialCost", SqlDbType.VarChar).Value = GetSerialCost
                .Add("@SerialQuantity", SqlDbType.VarChar).Value = 1
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Update Serial Assembly Log
            cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status, BatchNumber = @BatchNumber, CustomerID = @CustomerID, Comment = @Comment, ShipmentNumber = @ShipmentNumber, ShipmentDate = @ShipmentDate WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                .Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(cboSNShipmentLineNumber.Text)
                .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = lblSNPartNumber.Text
                .Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Comment", SqlDbType.VarChar).Value = "Serial # added in View/Edit"
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                .Add("@ShipmentDate", SqlDbType.VarChar).Value = lblShipDate.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Message popup
            MsgBox("Serial Number added.", MsgBoxStyle.OkOnly)

            If cboDivisionID.Text = "TWE" Or cboDivisionID.Text = "SLC" Then
                RequireSaveRoutine = "YES"
                cboShipmentNumber.Enabled = False
            Else
                RequireSaveRoutine = "NO"
                cboShipmentNumber.Enabled = True
            End If

            'Refresh Datagrid
            ShowSerialNumbers()
        Catch ex As System.Exception
            'Log error on update failure
            Dim TempShipNumber As Integer = 0
            Dim strShipNumber As String
            TempShipNumber = Val(cboShipmentNumber.Text)
            strShipNumber = CStr(TempShipNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "View/Edit Shipments --- Add Serial Number Failure"
            ErrorReferenceNumber = "Shipment # " + strShipNumber + " - Serial # - " + txtSerialNumber.Text
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Sub cmdUpdateInvoiceWithSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateInvoiceWithSN.Click
        Dim RowLineNumber As Integer = 0
        Dim SerialLineNumber As Integer = 0
        Dim ShipmentSerialNumber As String = ""
        Dim ShipmentSerialCost As Double = 0

        'Get Invoice Number for Shipment
        Dim GetInvoiceNumberStatement As String = "SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim GetInvoiceNumberCommand As New SqlCommand(GetInvoiceNumberStatement, con)
        GetInvoiceNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
        GetInvoiceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetInvoiceNumber = CInt(GetInvoiceNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetInvoiceNumber = 0
        End Try
        con.Close()

        If GetInvoiceNumber = 0 And Me.dgvShipmentLineSerialNumbers.RowCount > 0 Then
            MsgBox("No invoice exists for this shipment.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Delete any existing Lot Lines for Invoice
            cmd = New SqlCommand("DELETE FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = GetInvoiceNumber

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Get each row from shipment lot lines
            For Each row As DataGridViewRow In dgvShipmentLineSerialNumbers.Rows
                Try
                    RowLineNumber = row.Cells("ShipmentLineNumberColumn3").Value
                Catch ex As System.Exception
                    RowLineNumber = 0
                End Try
                Try
                    SerialLineNumber = row.Cells("SerialLineNumberColumn3").Value
                Catch ex As System.Exception
                    SerialLineNumber = 0
                End Try
                Try
                    ShipmentSerialNumber = row.Cells("SerialNumberColumn3").Value
                Catch ex As System.Exception
                    ShipmentSerialNumber = ""
                End Try
                Try
                    ShipmentSerialCost = row.Cells("SerialCostColumn3").Value
                Catch ex As System.Exception
                    ShipmentSerialCost = 0
                End Try

                Try
                    'Write to Invoice Lot Line Table
                    cmd = New SqlCommand("Insert Into InvoiceSerialLineTable(InvoiceNumber, InvoiceLineNumber, InvoiceSerialLineNumber, InvoiceSerialNumber, InvoiceShipmentNumber, SerialNumberCost, SerialNumberQuantity) Values (@InvoiceNumber, @InvoiceLineNumber, @InvoiceSerialLineNumber, @InvoiceSerialNumber, @InvoiceShipmentNumber, @SerialNumberCost, @SerialNumberQuantity)", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = GetInvoiceNumber
                        .Add("@InvoiceLineNumber", SqlDbType.VarChar).Value = RowLineNumber
                        .Add("@InvoiceSerialLineNumber", SqlDbType.VarChar).Value = SerialLineNumber
                        .Add("@InvoiceSerialNumber", SqlDbType.VarChar).Value = ShipmentSerialNumber
                        .Add("@InvoiceShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@SerialNumberCost", SqlDbType.VarChar).Value = ShipmentSerialCost
                        .Add("@SerialNumberQuantity", SqlDbType.VarChar).Value = 1
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Update Invoice Lot #'s (Line Table)"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                Try
                    'Update Serial Assembly Log
                    cmd = New SqlCommand("UPDATE AssemblySerialLog SET Status = @Status, BatchNumber = @BatchNumber, CustomerID = @CustomerID, Comment = @Comment, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate WHERE AssemblyPartNumber = @AssemblyPartNumber AND SerialNumber = @SerialNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                        .Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = RowLineNumber
                        .Add("@AssemblyPartNumber", SqlDbType.VarChar).Value = lblSNPartNumber.Text
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = txtSerialNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Comment", SqlDbType.VarChar).Value = "Serial # added in View/Edit"
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = GetInvoiceNumber
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = lblShipDate.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Update Invoice Lot #'s (Serial Log)"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Next

            MsgBox("Invoice has been updated with lot numbers.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdUploadPickTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadPickTicket.Click
        GlobalShipmentNumber = Val(cboShipmentNumber.Text)
    End Sub

    Private Sub cmdRePrintShippingLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRePrintShippingLabel.Click
        If canPrintLabel() Then
            InitializeBarcodeVariables()
            FillBarCodeVariables()
            Dim labels As Integer = 1
            If String.IsNullOrEmpty(txtNumberPallets.Text) = False Then
                labels = Convert.ToInt32(txtNumberPallets.Text)
            End If

            If labels > 1 Then
                Dim labelNumber As New ShipmentLabelNumber()
                labelNumber.setLabelNumber(labels)
                labelNumber.ShowDialog()
                If labelNumber.DialogResult = Windows.Forms.DialogResult.OK Then
                    labels = labelNumber.nbrNumberOfLabels.Value
                    AddressLabelSetup(labels)
                    PrintBarcodeLine(labels)
                End If
            Else
                AddressLabelSetup(labels)
                PrintBarcodeLine(labels)
            End If
        End If
    End Sub


    'Tool Menu Items

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        LoadShipmentData()
        ShowData()
        ShowLotNumbers()
    End Sub

    Private Sub PrintEmailConfirmationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintEmailConfirmationToolStripMenuItem.Click
        If canSave() Then
            If ShipmentStatus <> "INVOICED" Then
                'Validate Shipping Method
                ValidateShippingMethod()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                Dim ProductTotalStatement As String = "SELECT ProductTotal, TaxTotal FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
                ProductTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = ProductTotalCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
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
                Else
                    ProductTotal = 0
                    TaxTotal = 0
                End If
                reader.Close()
                con.Close()
                '***********************************************************************************
                If Val(txtFreight.Text) > 10000 Then
                    MsgBox("Freight Billed cannot be this high. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                FreightActualAmount = Val(txtFreight.Text)
                ShipmentTotal = ProductTotal + TaxTotal + FreightActualAmount
                lblFreight.Text = FormatCurrency(FreightActualAmount, 2)
                lblShipmentTotal.Text = FormatCurrency(ShipmentTotal, 2)

                'Create Add Ship To
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As System.Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do Nothing
                End If
                '***********************************************************************************
                Try
                    cmd = New SqlCommand("Update ShipmentHeaderTable SET Comment = @Comment, PRONumber = @PRONumber, FreightQuoteNumber = @FreightQuoteNumber, FreightQuoteAmount = @FreightQuoteAmount, FreightActualAmount = @FreightActualAmount, CustomerPO = @CustomerPO, ShipmentTotal = @ShipmentTotal, SpecialInstructions = @SpecialInstructions, ShippingWeight = @ShippingWeight, NumberOfPallets = @NumberOfPallets, ShipToID = @ShipToID, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZip = @ShipZip, ShipCountry = @ShipCountry, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Comment", SqlDbType.VarChar).Value = txtComments.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
                        .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtFreightQuoteAmount.Text)
                        .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipmentTotal", SqlDbType.VarChar).Value = ShipmentTotal
                        .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                        .Add("@ShippingWeight", SqlDbType.VarChar).Value = Val(txtShipWeight.Text)
                        .Add("@NumberOfPallets", SqlDbType.VarChar).Value = Val(txtNumberPallets.Text)
                        .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                        .Add("@ShipAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
                        .Add("@ShipAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
                        .Add("@ShipCity", SqlDbType.VarChar).Value = txtCity.Text
                        .Add("@ShipState", SqlDbType.VarChar).Value = cboState.Text
                        .Add("@ShipZip", SqlDbType.VarChar).Value = txtZip.Text
                        .Add("@ShipCountry", SqlDbType.VarChar).Value = txtCountry.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                        .Add("@ShipToName", SqlDbType.VarChar).Value = txtShipToName.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Shipment Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************
                Try
                    'UPDATE Invoice Table with PRO Number
                    cmd = New SqlCommand("Update InvoiceHeaderTable SET PRONumber = @PRONumber, CustomerPO = @CustomerPO, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Invoice Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Validate Shipping Method
                ValidateShippingMethod()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                If Val(txtFreight.Text) > 10000 Then
                    MsgBox("Freight Billed cannot be this high. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                'Create Add Ship To
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As System.Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do Nothing
                End If
                '***********************************************************************************
                Try
                    'Save data if shipment has been invoiced
                    cmd = New SqlCommand("Update ShipmentHeaderTable SET Comment = @Comment, PRONumber = @PRONumber, FreightQuoteNumber = @FreightQuoteNumber, FreightQuoteAmount = @FreightQuoteAmount, CustomerPO = @CustomerPO, SpecialInstructions = @SpecialInstructions, ShippingWeight = @ShippingWeight, NumberOfPallets = @NumberOfPallets, ShipToID = @ShipToID, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZip = @ShipZip, ShipCountry = @ShipCountry, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Comment", SqlDbType.VarChar).Value = txtComments.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
                        .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtFreightQuoteAmount.Text)
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                        .Add("@ShippingWeight", SqlDbType.VarChar).Value = Val(txtShipWeight.Text)
                        .Add("@NumberOfPallets", SqlDbType.VarChar).Value = Val(txtNumberPallets.Text)
                        .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                        .Add("@ShipAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
                        .Add("@ShipAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
                        .Add("@ShipCity", SqlDbType.VarChar).Value = txtCity.Text
                        .Add("@ShipState", SqlDbType.VarChar).Value = cboState.Text
                        .Add("@ShipZip", SqlDbType.VarChar).Value = txtZip.Text
                        .Add("@ShipCountry", SqlDbType.VarChar).Value = txtCountry.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                        .Add("@ShipToName", SqlDbType.VarChar).Value = txtShipToName.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Shipment Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************
                Try
                    'UPDATE Invoice Table with PRO Number
                    cmd = New SqlCommand("Update InvoiceHeaderTable SET PRONumber = @PRONumber, CustomerPO = @CustomerPO, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Invoice Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        End If

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
    End Sub

    Private Sub PrintBOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBOLToolStripMenuItem.Click
        cmdBOL_Click(sender, e)
    End Sub

    Private Sub PrintCertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCertToolStripMenuItem.Click
        cmdCert_Click(sender, e)
    End Sub

    Private Sub PrintPackingListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPackingListToolStripMenuItem.Click
        cmdPackList_Click(sender, e)
    End Sub

    Private Sub PrintShipmentDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintShipmentDataToolStripMenuItem.Click
        If canSave() Then
            If ShipmentStatus <> "INVOICED" Then
                'Validate Shipping Method
                ValidateShippingMethod()
                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                Dim ProductTotalStatement As String = "SELECT ProductTotal, TaxTotal FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
                ProductTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = ProductTotalCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
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
                Else
                    ProductTotal = 0
                    TaxTotal = 0
                End If
                reader.Close()
                con.Close()
                '***********************************************************************************
                If Val(txtFreight.Text) > 10000 Then
                    MsgBox("Freight Billed cannot be this high. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                FreightActualAmount = Val(txtFreight.Text)
                ShipmentTotal = ProductTotal + TaxTotal + FreightActualAmount
                lblFreight.Text = FormatCurrency(FreightActualAmount, 2)
                lblShipmentTotal.Text = FormatCurrency(ShipmentTotal, 2)

                'Create Add Ship To
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As System.Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do Nothing
                End If
                '***********************************************************************************
                Try
                    cmd = New SqlCommand("Update ShipmentHeaderTable SET Comment = @Comment, PRONumber = @PRONumber, FreightQuoteNumber = @FreightQuoteNumber, FreightQuoteAmount = @FreightQuoteAmount, FreightActualAmount = @FreightActualAmount, CustomerPO = @CustomerPO, ShipmentTotal = @ShipmentTotal, SpecialInstructions = @SpecialInstructions, ShippingWeight = @ShippingWeight, NumberOfPallets = @NumberOfPallets, ShipToID = @ShipToID, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZip = @ShipZip, ShipCountry = @ShipCountry, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Comment", SqlDbType.VarChar).Value = txtComments.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
                        .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtFreightQuoteAmount.Text)
                        .Add("@FreightActualAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipmentTotal", SqlDbType.VarChar).Value = ShipmentTotal
                        .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                        .Add("@ShippingWeight", SqlDbType.VarChar).Value = Val(txtShipWeight.Text)
                        .Add("@NumberOfPallets", SqlDbType.VarChar).Value = Val(txtNumberPallets.Text)
                        .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                        .Add("@ShipAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
                        .Add("@ShipAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
                        .Add("@ShipCity", SqlDbType.VarChar).Value = txtCity.Text
                        .Add("@ShipState", SqlDbType.VarChar).Value = cboState.Text
                        .Add("@ShipZip", SqlDbType.VarChar).Value = txtZip.Text
                        .Add("@ShipCountry", SqlDbType.VarChar).Value = txtCountry.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                        .Add("@ShipToName", SqlDbType.VarChar).Value = txtShipToName.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Shipment Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************
                Try
                    'UPDATE Invoice Table with PRO Number
                    cmd = New SqlCommand("Update InvoiceHeaderTable SET PRONumber = @PRONumber, CustomerPO = @CustomerPO, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Invoice Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Validate Shipping Method
                ValidateShippingMethod()

                If CheckShippingMethod = "EXIT SUB" Then
                    CheckShippingMethod = ""
                    MsgBox("Invalid Ship Method.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                If Val(txtFreight.Text) > 10000 Then
                    MsgBox("Freight Billed cannot be this high. Check number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '***********************************************************************************
                'Create Add Ship To
                If cboShipToID.Text <> "" Then
                    Try
                        SaveInsertAdditionalShipTo()
                    Catch ex As System.Exception
                        SaveUpdateAdditionalShipTo()
                    End Try
                Else
                    'Do Nothing
                End If
                '***********************************************************************************
                Try
                    'Save data if shipment has been invoiced
                    cmd = New SqlCommand("Update ShipmentHeaderTable SET Comment = @Comment, PRONumber = @PRONumber, FreightQuoteNumber = @FreightQuoteNumber, FreightQuoteAmount = @FreightQuoteAmount, CustomerPO = @CustomerPO, SpecialInstructions = @SpecialInstructions, ShippingWeight = @ShippingWeight, NumberOfPallets = @NumberOfPallets, ShipToID = @ShipToID, ShipAddress1 = @ShipAddress1, ShipAddress2 = @ShipAddress2, ShipCity = @ShipCity, ShipState = @ShipState, ShipZip = @ShipZip, ShipCountry = @ShipCountry, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Comment", SqlDbType.VarChar).Value = txtComments.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
                        .Add("@FreightQuoteAmount", SqlDbType.VarChar).Value = Val(txtFreightQuoteAmount.Text)
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                        .Add("@ShippingWeight", SqlDbType.VarChar).Value = Val(txtShipWeight.Text)
                        .Add("@NumberOfPallets", SqlDbType.VarChar).Value = Val(txtNumberPallets.Text)
                        .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                        .Add("@ShipAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
                        .Add("@ShipAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
                        .Add("@ShipCity", SqlDbType.VarChar).Value = txtCity.Text
                        .Add("@ShipState", SqlDbType.VarChar).Value = cboState.Text
                        .Add("@ShipZip", SqlDbType.VarChar).Value = txtZip.Text
                        .Add("@ShipCountry", SqlDbType.VarChar).Value = txtCountry.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                        .Add("@ShipToName", SqlDbType.VarChar).Value = txtShipToName.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Shipment Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************
                Try
                    'UPDATE Invoice Table with PRO Number
                    cmd = New SqlCommand("Update InvoiceHeaderTable SET PRONumber = @PRONumber, CustomerPO = @CustomerPO, ShipVia = @ShipVia, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONumber.Text
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Invoice Header Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        End If

        GlobalShipmentNumber = Val(cboShipmentNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintShipment As New PrintShipment
            Dim result = NewPrintShipment.ShowDialog()
        End Using
    End Sub

    Private Sub PrintProfitabilityReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintProfitabilityReportToolStripMenuItem.Click
        GlobalShipmentNumber = Val(cboShipmentNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintShipmentMargin As New PrintShipmentMargin
            Dim result = NewPrintShipmentMargin.ShowDialog()
        End Using
    End Sub

    Private Sub SetShipmentToShippedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetShipmentToShippedToolStripMenuItem.Click
        If cboShipmentNumber.Text <> "" Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to change this Shipment to Shipped so it can be Invoiced?", "CHANGE SHIPMENT STATUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Try
                    'Update Shipment Status
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "SHIPPED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    lblStatus.Text = "SHIPPED"
                Catch ex As System.Exception
                    'Skip
                End Try
            ElseIf button = DialogResult.No Then
                MsgBox("You must select a valid Shipment Number.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub SetShipmentToPendingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetShipmentToPendingToolStripMenuItem.Click
        If cboShipmentNumber.Text <> "" Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to change this Shipment to Pending so it can be processed?", "CHANGE SHIPMENT STATUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Try
                    'Update Shipment Status
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    lblStatus.Text = "PENDING"
                Catch ex As System.Exception
                    'Skip
                End Try
            ElseIf button = DialogResult.No Then
                MsgBox("You must select a valid Shipment Number.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub SetShipmentToClosedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetShipmentToClosedToolStripMenuItem.Click
        If cboShipmentNumber.Text <> "" Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to change this Shipment to Closed?", "CHANGE SHIPMENT STATUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Try
                    'Update Shipment Status
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShipmentStatus = @ShipmentStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ShipmentStatus", SqlDbType.VarChar).Value = "INVOICED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineStatus = @LineStatus WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    lblStatus.Text = "INVOICED"
                Catch ex As System.Exception
                    'Skip
                End Try
            ElseIf button = DialogResult.No Then
                MsgBox("You must select a valid Shipment Number.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Public Sub SaveInsertAdditionalShipTo()
        'Create new ship to from the text boxes
        cmd = New SqlCommand("Insert Into AdditionalShipTo(ShipToID, CustomerID, DivisionID, Address1, Address2, City, State, Zip, Country, Name) Values (@ShipToID, @CustomerID, @DivisionID, @Address1, @Address2, @City, @State, @Zip, @Country, @Name)", con)

        With cmd.Parameters
            .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
            .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
            .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
            .Add("@State", SqlDbType.VarChar).Value = cboState.Text
            .Add("@Zip", SqlDbType.VarChar).Value = txtZip.Text
            .Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text
            .Add("@Name", SqlDbType.VarChar).Value = txtShipToName.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub SaveUpdateAdditionalShipTo()
        'Command to save changes in the additional ship to from the text boxes
        cmd = New SqlCommand("UPDATE AdditionalShipTo SET Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country, Name = @Name WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
            .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
            .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
            .Add("@State", SqlDbType.VarChar).Value = cboState.Text
            .Add("@Zip", SqlDbType.VarChar).Value = txtZip.Text
            .Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text
            .Add("@Name", SqlDbType.VarChar).Value = txtShipToName.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub


    'Combo Box Events

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isLoaded Then
            LoadPickNumber()
            LoadShipmentNumber()
            LoadShipToCountry()
            ClearData()
            ClearVariables()
            ShowData()
            ShowLotNumbers()

            usefulFunctions.LoadSecurity(Me)
        End If
    End Sub

    Private Sub cboShipToID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipToID.SelectedIndexChanged
        If isLoaded Then
            LoadAdditionalShipTo()
        End If
    End Sub

    Private Sub cboShipmentNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipmentNumber.SelectedIndexChanged
        If isLoaded Then
            ClearVariables()
            ClearData()
            LoadShipmentData()
            LoadShipmentLineNumber()
            ShowData()
            ShowLotNumbers()
            ShowSerialNumbers()
            LoadStatusAndVerifyData()
            LoadUploadedPickTicket()
        End If

        'If cboShipmentNumber.SelectedIndex = -1 Then
        '    cmdUploadPickTicket.Enabled = False
        'Else
        '    cmdUploadPickTicket.Enabled = True
        'End If

        'If PTUpload IsNot Nothing Then PTUpload.CheckUploadPickTicket()

        GlobalShipmentNumber = Val(cboShipmentNumber.Text)
    End Sub

    Private Sub cboShipmentLineNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipmentLineNumber.SelectedIndexChanged
        If isLoaded Then
            LoadPartNumbers()
        End If
    End Sub

    Private Sub cboShipMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipMethod.SelectedIndexChanged
        If cboShipMethod.Text = "THIRD PARTY" Then
            txtThirdParty.Enabled = True
            GetThirdPartyBillingData()
        Else
            txtThirdParty.Enabled = False
            txtThirdParty.Text = ""
        End If
    End Sub

    Private Sub cboShipToCountryName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipToCountryName.SelectedIndexChanged
        LoadSTCountryCodeByCountry()
    End Sub

    Private Sub cboPickTicketNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPickTicketNumber.SelectedIndexChanged
        If cboPickTicketNumber.Text = "" Then
            'Do nothing
        Else
            LoadShipmentNumberFromPickNumber()
        End If
    End Sub

    Private Sub cboSNShipmentLineNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSNShipmentLineNumber.SelectedIndexChanged
        If isLoaded Then
            LoadPartNumbers()
        End If
    End Sub

    Private Sub txtCountry_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCountry.TextChanged
        LoadSTCountryByCountryCode()
    End Sub


    'Datagridview Events

    Private Sub dgvLotNumbers_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLotNumbers.CellClick
        Dim LineNumber As Integer
        Dim currentRow As Integer = dgvLotNumbers.CurrentCell.RowIndex
        Try
            LineNumber = dgvLotNumbers.Rows(currentRow).Cells("ShipmentLineNumberColumn2").Value
            cboShipmentLineNumber.Text = LineNumber
        Catch ex As System.Exception
            'Skip
        End Try
    End Sub

    Private Sub dgvLotNumbers_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLotNumbers.CellContentClick
        Dim LineNumber As Integer
        Dim currentRow As Integer = dgvLotNumbers.CurrentCell.RowIndex
        Try
            LineNumber = dgvLotNumbers.Rows(currentRow).Cells("ShipmentLineNumberColumn2").Value
            cboShipmentLineNumber.Text = LineNumber
        Catch ex As System.Exception
            'Skip
        End Try
    End Sub

    Private Sub dgvLotNumbers_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLotNumbers.CellDoubleClick
        Dim RowShipmentNumber As Integer = 0
        Dim RowShipmentLineNumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowLotNumber As String = ""
        Dim RowCustomer As String = ""
        Dim GetHeatNumber As String = ""
        Dim GetPartNumber As String = ""

        If Me.dgvLotNumbers.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvLotNumbers.CurrentCell.RowIndex

            RowDivision = cboDivisionID.Text
            RowShipmentNumber = Val(cboShipmentNumber.Text)
            RowCustomer = lblCustomerID.Text

            RowShipmentLineNumber = Me.dgvLotNumbers.Rows(RowIndex).Cells("ShipmentLineNumberColumn2").Value
            RowLotNumber = Me.dgvLotNumbers.Rows(RowIndex).Cells("LotNumberColumn2").Value

            'Get Part Number for line and heat number for lot
            Dim GetPartNumberStatement As String = "SELECT PartNumber FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber"
            Dim GetPartNumberCommand As New SqlCommand(GetPartNumberStatement, con)
            GetPartNumberCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
            GetPartNumberCommand.Parameters.Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = RowShipmentLineNumber

            Dim GetHeatNumberStatement As String = "SELECT HeatNumber FROM LotNumber WHERE LotNumber = @LotNumber"
            Dim GetHeatNumberCommand As New SqlCommand(GetHeatNumberStatement, con)
            GetHeatNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = RowLotNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPartNumber = CStr(GetPartNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetPartNumber = ""
            End Try
            Try
                GetHeatNumber = CStr(GetHeatNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetHeatNumber = ""
            End Try
            con.Close()
            '*******************************************************************************************************************************************
            'Check to make sure at least one cert will print otherwise do not open Print Form
            Dim CheckForCerts As Integer = 0

            'Get Pull Test Number for selected Lot Number Data
            Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
            Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
            CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = RowShipmentNumber
            CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

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
                CertShipmentNumber = RowShipmentNumber
                GlobalDivisionCode = RowDivision
                CertLotNumber = RowLotNumber
                CertHeatNumber = GetHeatNumber
                CertCustomerID = RowCustomer
                CertPartNumber = GetPartNumber

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
                    Using NewPrintTWCertSingleRemote As New PrintTWCertSingleRemote
                        Dim result = NewPrintTWCertSingleRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintTWCertBatch As New PrintTWCertSingle
                        Dim result = NewPrintTWCertBatch.ShowDialog()
                    End Using
                End If
            End If
        Else
            'Skip
        End If
    End Sub

    Private Sub dgvLotNumbers_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLotNumbers.CellValueChanged
        Dim LotNumber As String = ""
        Dim PullTestNumber As String = ""
        Dim ShipmentLineNumber As Integer = 0
        Dim LotLineNumber As Integer = 0
        Dim HeatQuantity As Double = 0

        If Me.dgvLotNumbers.RowCount <> 0 Then
            Dim currentRow As Integer = dgvLotNumbers.CurrentCell.RowIndex

            ShipmentLineNumber = dgvLotNumbers.Rows(currentRow).Cells("ShipmentLineNumberColumn2").Value
            LotLineNumber = dgvLotNumbers.Rows(currentRow).Cells("LotLineNumberColumn2").Value
            LotNumber = dgvLotNumbers.Rows(currentRow).Cells("LotNumberColumn2").Value
            PullTestNumber = dgvLotNumbers.Rows(currentRow).Cells("PullTestNumberColumn2").Value
            HeatQuantity = dgvLotNumbers.Rows(currentRow).Cells("HeatQuantityColumn2").Value

            'Validate that Heat Number of the Pull Test matches the Lot Number
            Dim GetHeatNumberFromLot As String = ""
            Dim GetHeatNumberFromPull As String = ""

            Dim GetHeatNumberFromLotStatement As String = "SELECT HeatNumber FROM LotNumber WHERE LotNumber = @LotNumber"
            Dim GetHeatNumberFromLotCommand As New SqlCommand(GetHeatNumberFromLotStatement, con)
            GetHeatNumberFromLotCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber

            Dim GetHeatNumberFromPullStatement As String = "SELECT HeatNumber FROM PullTestData WHERE TestNumber = @TestNumber"
            Dim GetHeatNumberFromPullCommand As New SqlCommand(GetHeatNumberFromPullStatement, con)
            GetHeatNumberFromPullCommand.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = PullTestNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetHeatNumberFromLot = CStr(GetHeatNumberFromLotCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetHeatNumberFromLot = ""
            End Try
            Try
                GetHeatNumberFromPull = CStr(GetHeatNumberFromPullCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetHeatNumberFromPull = ""
            End Try
            con.Close()

            If GetHeatNumberFromLot = GetHeatNumberFromPull And PullTestNumber <> "NO CERT" Then
                'Skip
            Else
                MsgBox("Heat # of this pull test does not match heat # of this lot. NO cert will print.", MsgBoxStyle.OkOnly)
            End If

            Try
                'UPDATE Shipment Line Table
                cmd = New SqlCommand("UPDATE ShipmentLineLotNumbers SET LotNumber = @LotNumber, PullTestNumber = @PullTestNumber, HeatQuantity = @HeatQuantity WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber AND LotLineNumber = @LotLineNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                    .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = ShipmentLineNumber
                    .Add("@LotLineNumber", SqlDbType.VarChar).Value = LotLineNumber
                    .Add("@LotNumber", SqlDbType.VarChar).Value = LotNumber
                    .Add("@PullTestNumber", SqlDbType.VarChar).Value = PullTestNumber
                    .Add("@HeatQuantity", SqlDbType.VarChar).Value = HeatQuantity
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As System.Exception
                'Do nothing
            End Try
        Else
            'Skip
        End If
    End Sub

    Private Sub dgvShipLines_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvShipLines.CellValueChanged
        If isLoaded Then

            If Me.dgvShipLines.RowCount <> 0 Then
                Dim LineComment, SerialNumber As String
                Dim LineNumber As Integer
                Dim currentRow As Integer = dgvShipLines.CurrentCell.RowIndex
                Dim LineWeight As Double = 0
                Dim LineBoxes As Double = 0
                Dim LineCertCode As String = ""

                ''UPDATE Line Table on changes in the datagrid
                LineComment = dgvShipLines.Rows(currentRow).Cells("LineCommentColumn").Value
                SerialNumber = dgvShipLines.Rows(currentRow).Cells("SerialNumberColumn").Value
                LineNumber = dgvShipLines.Rows(currentRow).Cells("ShipmentLineNumberColumn").Value
                LineBoxes = dgvShipLines.Rows(currentRow).Cells("LineBoxesColumn").Value
                LineWeight = dgvShipLines.Rows(currentRow).Cells("LineWeightColumn").Value
                LineCertCode = dgvShipLines.Rows(currentRow).Cells("CertificationTypeColumn").Value

                Try
                    'UPDATE Shipment Line Table
                    cmd = New SqlCommand("UPDATE ShipmentLineTable SET LineComment = @LineComment, SerialNumber = @SerialNumber, LineBoxes = @LineBoxes, LineWeight = @LineWeight, CertificationType = @CertificationType WHERE ShipmentNumber = @ShipmentNumber AND ShipmentLineNumber = @ShipmentLineNumber", con)
                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@ShipmentLineNumber", SqlDbType.VarChar).Value = LineNumber
                        .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                        .Add("@SerialNumber", SqlDbType.VarChar).Value = SerialNumber
                        .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxes
                        .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeight
                        .Add("@CertificationType", SqlDbType.VarChar).Value = LineCertCode
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Log error on update failure
                    Dim TempShipNumber As Integer = 0
                    Dim strShipNumber As String
                    TempShipNumber = Val(cboShipmentNumber.Text)
                    strShipNumber = CStr(TempShipNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "View/Edit Shipments --- Datagrid Update Failure"
                    ErrorReferenceNumber = "Shipment # " + strShipNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                'Update Shipping Weight
                Dim TotalShippingWeight As Double = 0

                Dim GetTotalWeightStatement As String = "SELECT SUM(LineWeight) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim GetTotalWeightCommand As New SqlCommand(GetTotalWeightStatement, con)
                GetTotalWeightCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                GetTotalWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalShippingWeight = CDbl(GetTotalWeightCommand.ExecuteScalar)
                Catch ex As System.Exception
                    TotalShippingWeight = 0
                End Try

                Try
                    'UPDATE Shipment Line Table
                    cmd = New SqlCommand("UPDATE ShipmentHeaderTable SET ShippingWeight = @ShippingWeight WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = Val(cboShipmentNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ShippingWeight", SqlDbType.VarChar).Value = TotalShippingWeight
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As System.Exception
                    'Do nothing
                End Try

                LoadShipmentData()
                ShowData()
                ShowLotNumbers()
            Else
                'No update
            End If
        End If
    End Sub

    Private Sub dgvShipmentLineSerialNumbers_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentLineSerialNumbers.CellClick
        Dim RowLineNumber As Integer

        If Me.dgvShipmentLineSerialNumbers.RowCount <> 0 Then

            Dim RowIndex As Integer = Me.dgvShipmentLineSerialNumbers.CurrentCell.RowIndex

            Try
                RowLineNumber = Me.dgvShipmentLineSerialNumbers.Rows(RowIndex).Cells("ShipmentLineNumberColumn3").Value
            Catch ex As System.Exception
                RowLineNumber = 1
            End Try

            cboSNShipmentLineNumber.Text = RowLineNumber
        End If
    End Sub

    Private Sub dgvShipmentLineSerialNumbers_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentLineSerialNumbers.CellContentClick
        Dim RowLineNumber As Integer

        If Me.dgvShipmentLineSerialNumbers.RowCount <> 0 Then

            Dim RowIndex As Integer = Me.dgvShipmentLineSerialNumbers.CurrentCell.RowIndex

            Try
                RowLineNumber = Me.dgvShipmentLineSerialNumbers.Rows(RowIndex).Cells("ShipmentLineNumberColumn3").Value
            Catch ex As System.Exception
                RowLineNumber = 1
            End Try

            cboSNShipmentLineNumber.Text = RowLineNumber
        End If
    End Sub


    'Validation and clear routines

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        ' The return value specifies the previous state of the menu item (it is either      
        ' MF_ENABLED or MF_GRAYED). 0xFFFFFFFF indicates   that the menu item does not exist.      
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)
            Case MF_ENABLED
            Case MF_GRAYED
            Case &HFFFFFFFF
                Throw New System.Exception("The Close menu item does not exist.")
            Case Else
        End Select
    End Sub

    Public Sub TFPErrorLogUpdate()
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        'Insert Data into error log
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

    Public Sub GetThirdPartyBillingData()
        Dim BillToNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToNameCommand As New SqlCommand(BillToNameStatement, con)
        BillToNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text
        BillToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress1Statement As String = "SELECT BillToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
        BillToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text
        BillToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress2Statement As String = "SELECT BillToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress2Command As New SqlCommand(BillToAddress2Statement, con)
        BillToAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text
        BillToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToCityStatement As String = "SELECT BillToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToCityCommand As New SqlCommand(BillToCityStatement, con)
        BillToCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text
        BillToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToStateStatement As String = "SELECT BillToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToStateCommand As New SqlCommand(BillToStateStatement, con)
        BillToStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text
        BillToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToZipStatement As String = "SELECT BillToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToZipCommand As New SqlCommand(BillToZipStatement, con)
        BillToZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = lblCustomerID.Text
        BillToZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BillToName = CStr(BillToNameCommand.ExecuteScalar)
        Catch ex As System.Exception
            BillToName = ""
        End Try
        Try
            BillToAddress1 = CStr(BillToAddress1Command.ExecuteScalar)
        Catch ex As System.Exception
            BillToAddress1 = ""
        End Try
        Try
            BillToAddress2 = CStr(BillToAddress2Command.ExecuteScalar)
        Catch ex As System.Exception
            BillToAddress2 = ""
        End Try
        Try
            BillToCity = CStr(BillToCityCommand.ExecuteScalar)
        Catch ex As System.Exception
            BillToCity = ""
        End Try
        Try
            BillToState = CStr(BillToStateCommand.ExecuteScalar)
        Catch ex As System.Exception
            BillToState = ""
        End Try
        Try
            BillToZip = CStr(BillToZipCommand.ExecuteScalar)
        Catch ex As System.Exception
            BillToZip = ""
        End Try
        con.Close()

        txtThirdParty.Text = BillToName + Environment.NewLine + BillToAddress1 + Environment.NewLine + BillToAddress2 + Environment.NewLine + BillToCity + ", " + BillToState + "  " + BillToZip
    End Sub

    Public Sub ValidateShippingMethod()
        ShipMethod = cboShipMethod.Text

        Select Case ShipMethod
            Case "COLLECT"
                If lblStatus.Text = "INVOICED" Then
                    'Do nothing
                Else
                    txtFreight.Text = 0
                End If

                CheckShippingMethod = ""
            Case "PREPAID"
                If lblStatus.Text = "INVOICED" Then
                    'Do nothing
                Else
                    txtFreight.Text = 0
                End If

                CheckShippingMethod = ""
            Case "PREPAID/ADD"
                If ShipmentStatus = "INVOICED" Then
                    'Do nothing
                Else
                    If Val(txtFreight.Text) = 0 Then
                        MsgBox("You must enter billed freight for this order.", MsgBoxStyle.OkOnly)
                        CheckShippingMethod = "EXIT SUB"
                        Exit Sub
                    End If
                End If
            Case "PREPAID/NOADD"
                If lblStatus.Text = "INVOICED" Then
                    'Do nothing
                Else
                    txtFreight.Text = 0
                End If

                CheckShippingMethod = ""
            Case "THIRD PARTY"
                If txtThirdParty.Text = "" Then
                    MsgBox("You must fill-in third party shipping info", MsgBoxStyle.OkOnly)
                    CheckShippingMethod = "EXIT SUB"
                    txtThirdParty.Focus()
                    Exit Sub
                End If
            Case "OTHER"
                If lblStatus.Text = "INVOICED" Then
                    'Do nothing
                Else
                    txtFreight.Text = 0
                End If

                CheckShippingMethod = ""
            Case Else
                MsgBox("You must select a valid Shipping Method", MsgBoxStyle.OkOnly)
                CheckShippingMethod = "EXIT SUB"
                cboShipMethod.Focus()
                Exit Sub
        End Select
    End Sub

    Public Sub ClearData()
        cboShipToID.Text = ""
        txtShipToName.Text = ""
        RequireSaveRoutine = "NO"
        cboShipmentNumber.Enabled = True

        txtLotNumber.Clear()
        txtComments.Clear()
        txtCustomerPO.Clear()
        txtNumberPallets.Clear()
        txtPRONumber.Clear()
        txtFreightQuoteAmount.Clear()
        txtFreightQuoteNumber.Clear()
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtCity.Clear()
        txtCountry.Clear()
        txtThirdParty.Clear()
        txtShipWeight.Clear()
        txtZip.Clear()
        txtSpecialInstructions.Clear()
        txtThirdParty.Clear()
        txtFreight.Clear()
        txtHeatQuantity.Clear()
        txtSerialNumber.Clear()
        txtShippingAccount.Clear()
        txtDoubleStackedPallets.Clear()

        cboShipVia.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboState.SelectedIndex = -1
        cboShipToID.SelectedIndex = -1
        cboShipmentLineNumber.SelectedIndex = -1
        'cboShipmentNumber.SelectedIndex = -1
        cboSNShipmentLineNumber.SelectedIndex = -1
        cboShipToCountryName.SelectedIndex = -1
        cboPickTicketNumber.SelectedIndex = -1

        lblNumberBoxes.Text = ""
        lblCustomerID.Text = ""
        lblCustomerName.Text = ""
        lblFreight.Text = ""
        lblSalesTax.Text = ""
        lblStatus.Text = ""
        lblShipDate.Text = ""
        lblShipmentTotal.Text = ""
        lblPartDescription.Text = ""
        lblPartNumber.Text = ""
        lblProductTotal.Text = ""
        lblSONumber.Text = ""
        lblSNPartDescription.Text = ""
        lblSNPartNumber.Text = ""
        lblShipEmail.Text = ""
        lblPalletsOnFloor.Text = ""

        If My.Computer.Name.StartsWith("TFP") Then
            cmdRemoteScan.Visible = True
            cmdUploadPickTicket.Visible = False
            cmdViewULPicks.Visible = True
            ReUploadPickTicketToolStripMenuItem.Enabled = False
            AppendUploadedPickTicketToolStripMenuItem.Enabled = False
        Else
            cmdRemoteScan.Visible = False
            cmdUploadPickTicket.Visible = True
            cmdViewULPicks.Enabled = False
        End If

        cboShipmentNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        BillToAddress1 = ""
        BillToAddress2 = ""
        BillToCity = ""
        BillToState = ""
        BillToZip = ""
        BillToName = ""
        ShipMethod = ""
        ThirdPartyShipper = ""
        ShipToName = ""
        CustomerName = ""
        PRONumber = ""
        ShipVia = ""
        SpecialInstructions = ""
        ShipDate = ""
        ShipAddress1 = ""
        ShipAddress2 = ""
        ShipCity = ""
        ShipCountry = ""
        ShipZip = ""
        ShipState = ""
        CustomerPO = ""
        Comment = ""
        FreightQuoteNumber = ""
        CustomerID = ""
        ShipToID = ""
        SalesOrderKey = 0
        PickTicketNumber = 0
        NumberOfBoxes = 0
        NumberOfPallets = 0
        NumberOfDoubleStackedPallets = 0
        NumberOfPalletsOnFloor = 0
        ProductTotal = 0
        TaxTotal = 0
        ShipmentTotal = 0
        FreightQuoteAmount = 0
        ShippingWeight = 0
        FreightActualAmount = 0
        PartHeatNumber = ""
        PartItemClass = ""
        PartNumber = ""
        PartDescription = ""
        LotNumber = ""
        LotPartNumber = ""
        PartNominalDiameter = 0
        PartNominalLength = 0
        PullTestNumber = 0
        LastLotLineNumber = 0
        NextLotLineNumber = 0
        ShipmentStatus = ""
        ADDAddress1 = ""
        ADDAddress2 = ""
        ADDCity = ""
        ADDZip = ""
        ADDState = ""
        ADDCountry = ""
        ADDToName = ""
        ShippingAccount = ""
        ShipEmail = ""

        RequireSaveRoutine = "NO"
        cboShipmentNumber.Enabled = True
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboShipmentNumber.Text) Then
            MessageBox.Show("You must select a shipment number", "Select a shipment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboShipmentNumber.Focus()
            Return False
        End If
        If cboShipmentNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid shipment number", "Enter a valid shipment number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboShipmentNumber.SelectAll()
            cboShipmentNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canPrintLabel() As Boolean
        If String.IsNullOrEmpty(txtShipToName.Text) Then
            MessageBox.Show("You must enter a company name", "Enter a company name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtShipToName.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("You must enter an address", "Enter an address", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress1.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCity.Text) Then

            MessageBox.Show("You must enter a city", "Enter a city", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCity.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboState.Text) Then
            MessageBox.Show("You must enter a state", "Enter a state", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboState.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtZip.Text) Then
            MessageBox.Show("You must enter a zip", "Enter a zip", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtZip.Focus()
            Return False
        End If
        Return True
    End Function

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
        NumberOfLables = 1
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
        V00 = txtShipToName.Text
        V01 = txtAddress1.Text
        V02 = txtCity.Text + ", " + cboState.Text + " " + txtZip.Text
        V03 = txtAddress2.Text
        V04 = txtCountry.Text

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

        If String.IsNullOrEmpty(txtCountry.Text) = False Then
            If V04.Length < 32 Then
                V18 = V04
            Else
                V18 = V04.Substring(0, 32)
            End If
        End If

        Select Case cboDivisionID.Text
            Case "TFP"
                V28 = "TFP CORP. MEDINA, OH. 44256 330-725-7741"
            Case "CGO"
                V28 = "TFP CORP. GRIFFITH, IN. 46319 219-513-9572"
            Case "CHT"
                V28 = "WELDING CERAMICS CHATTANOOGA, TN 423-752-5740"
            Case "ATL"
                V28 = "TFP CORP.  NORCROSS, GA. 678-728-0095"
            Case "TFF"
                V28 = "TFP CORP.  SURREY, BC.  V4N 3R7  778-298-1094"
            Case "CBS"
                V28 = "TFP CORP.  LAS VEGAS, NV.  702-737-7940"
            Case "SLC"
                V28 = "TFP CORP.  WEST JORDAN, UT.  801-280-6611"
            Case "TFT"
                V28 = "TFP CORP.  IRVING, TX.  972-986-6368"
            Case "HOU"
                V28 = "TFP CORP.  HOUSTON, TX.  281-598-2330"
            Case "DEN"
                V28 = "TFP CORP.  DENVER, CO.  303-945-2030"
            Case "TOR"
                V28 = "TFP CORP.  Stoney Creek, ONT. L8E557  905-643-0969"
            Case "ALB"
                V28 = "TFP CORP.  Calgary, Alberta, Canada"
            Case Else
                V28 = "TFP CORP. MEDINA, OH 44256 330-725-7741"
        End Select

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

    Private Sub AddressLabelSetup(ByVal labels As Integer)
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S2"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes

        LabelFormat(8) = "LO60,900,1,100"
        LabelFormat(9) = "LO60,950,1,100"

        'Fill in Verbiage

        LabelFormat(10) = "A35,10,1,3,1,1,N," & Chr(34) & V28 & Chr(34)
        LabelFormat(11) = "A662,40,1,5,2,1,N," & Chr(34) & V10 & Chr(34)
        LabelFormat(12) = "A554,40,1,5,2,1,N," & Chr(34) & V11 & Chr(34)
        LabelFormat(13) = "A432,40,1,5,2,1,N," & Chr(34) & V17 & Chr(34)
        LabelFormat(14) = "A323,40,1,5,2,1,N," & Chr(34) & V12 & Chr(34)
        LabelFormat(15) = "A223,40,1,5,2,1,N," & Chr(34) & V18 & Chr(34)
        LabelFormat(16) = "A100,700,1,4,2,1,N," & Chr(34) & "PALLET      OF " & Chr(34)

        'Print Label

        LabelFormat(17) = "P" + labels.ToString()
        LabelFormat(18) = vbFormFeed
        LabelLines = 17

    End Sub

    Private Sub PrintBarcodeLine(ByVal labels As Integer)
        ' Click event handler for a button - designed to show how to use the
        ' SendBytesToPrinter function to send a string to the printer.

        Dim s As String = ""
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

    Private Sub AppendUploadedPickTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppendUploadedPickTicketToolStripMenuItem.Click

    End Sub

    Private Sub ReUploadPickTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReUploadPickTicketToolStripMenuItem.Click

    End Sub

    Private Sub txtNumberPallets_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumberPallets.TextChanged
        NumberOfPallets = Val(txtNumberPallets.Text)
        NumberOfDoubleStackedPallets = Val(txtDoubleStackedPallets.Text)
        NumberOfPalletsOnFloor = NumberOfPallets - NumberOfDoubleStackedPallets

        lblPalletsOnFloor.Text = NumberOfPalletsOnFloor
    End Sub

    Private Sub txtDoubleStackedPallets_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDoubleStackedPallets.TextChanged
        NumberOfPallets = Val(txtNumberPallets.Text)
        NumberOfDoubleStackedPallets = Val(txtDoubleStackedPallets.Text)
        NumberOfPalletsOnFloor = NumberOfPallets - NumberOfDoubleStackedPallets

        lblPalletsOnFloor.Text = NumberOfPalletsOnFloor
    End Sub

    Private Sub cmdViewULPicks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewULPicks.Click
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

                'My_Process_Info.UseShellExecute = False
                'My_Process_Info.RedirectStandardOutput = True
                'My_Process_Info.RedirectStandardError = True
                'My_Process_Info.CreateNoWindow = True

                Try
                    My_Process.Start(ApplicationFileAndPath, "-o " & PickTicketFilenameAndPath)
                    'My_Process.WaitForExit()
                    My_Process.Close()

                    cboShipmentNumber.Refresh()
                    LoadUploadedPickTicket()
                    cboShipmentNumber.Text = PickTicketNumber
                    cmdRemoteScan.Visible = True
                    cmdUploadPickTicket.Visible = False
                    cmdViewULPicks.Visible = True
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
                    ErrorDescription = "View/Edit Shipment --- Scan"
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

            'My_Process_Info.UseShellExecute = False
            'My_Process_Info.RedirectStandardOutput = True
            'My_Process_Info.RedirectStandardError = True
            'My_Process_Info.CreateNoWindow = True

            Try
                My_Process.Start(ApplicationFileAndPath, "-o " & PickTicketFilenameAndPath)
                'My_Process.WaitForExit()
                My_Process.Close()

                cboShipmentNumber.Refresh()
                LoadUploadedPickTicket()
                cboShipmentNumber.Text = PickTicketNumber
                cmdRemoteScan.Visible = True
                cmdUploadPickTicket.Visible = False
                cmdViewULPicks.Visible = True
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
                ErrorDescription = "View/Edit Shipment --- Scan"
                ErrorReferenceNumber = "Pick Ticket # " + strPickTicketNumber1
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Scan failed", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub
End Class