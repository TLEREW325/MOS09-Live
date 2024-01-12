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
Imports System.Printing
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Drawing.Text
Public Class ElectronicSchedulingBoard
    Inherits System.Windows.Forms.Form

    'Setup for barcode
    Dim LabelFormat(70), V00, V01, V02, V03, V04, V05, V06, V07, V08, V09, V10, V11, V12, V13, V14, V15, V16, V17, V18, V19, V20, V21, V22, V23, V24, V25, V26, V27, V28, VDATA, VDATA1, VBAR, VBAR1 As String
    Dim LabelLines, BarCodeType, NumberOfLables, AnnealType As Integer
    Dim NumberOfLabels As Integer = 0

    ''used for printing labels (ZPL)
    Dim ZLabelFormat(70) As String
    Dim ZLabelLines As Integer
    Dim printerName As String = ""

    Dim printer2x4 As String
    
    Dim bool2x4 As Boolean = 0

    'Variable For Radio Button Position for labels
    Dim LabelPrintPosition As Integer = 0
    Dim LotNumberStatus As String = ""
    Dim LotNumberInspected As String = ""
    Dim LotNumberCaPrintLabel As String = ""
    Dim CurrentLotNumber As String = ""
    Dim SpecialLabelLine1 As String = ""
    Dim SpecialLabelLine2 As String = ""
    Dim SpecialLabelLine3 As String = ""
    Dim LabelDoesSpecialLabelExist As String = ""
    Dim LabelSalesOrderNumber As String = ""
    Dim LabelPickTicketNumber As String = ""
    Dim LabelUsername As String = EmployeeLoginName
    Dim LabelDivisionID As String = EmployeeSecurityCode

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim dt As DataTable

    Private Sub ElectronicSchedulingBoard2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GlobalDivisionCode = EmployeeCompanyCode

        LoadInspectionProcess()
        LoadSpecialPartNumber()
        LoadSpecialPartDescription()
        LoadPartNumber2x4()
        LoadPartDescription2x4()

        If EmployeeCompanyCode = "CHT" Then
            LoadFerrulePartNumber()
        Else
            LoadFerrulePartNumberOther()
        End If
        If EmployeeCompanyCode = "TWE" Then

            printer2x4 = "Zebra2X4TWE"

        ElseIf EmployeeCompanyCode = "SLC" Then
            printer2x4 = "Zebra2x4SLC"
        End If
        ClearAllGroupBoxesAndMakeInvisible()
    End Sub

    Public Sub ClearAllGroupBoxesAndMakeInvisible()
        gpxRackingBarcodeLabel.Visible = False
        gpxFactoryOrderLabel.Visible = False
        gpxMixedHeatLabel.Visible = False
        gpxMixedLoadLabel.Visible = False
        gpxShippingAddressLabel.Visible = False
        gpxShipAddressFromShipment.Visible = False
        gpxTubTag.Visible = False
        gpxBinLabel.Visible = False
        gpxPalletBinLabel.Visible = False
        gpxFryer.Visible = False
        gpxOptimasLabel.Visible = False
        gpxCoilYardLabel.Visible = False
        gpxUniversalWasteLabel.Visible = False
        gpxFourBlankLineLabel.Visible = False
        gpxThreeBlankLineLabel.Visible = False
        gpxAnnealSample.Visible = False
        gpxZincPlatedLabel.Visible = False
        gpxNickelPlatedLabel.Visible = False
        gpxStainlessSteelLabel.Visible = False
        gpxPartialPalletLabel.Visible = False
        gpxCustomLabel.Visible = False
        gpxSLCPartLabel.Visible = False
        gpxBranamFacilLabel.Visible = False
    End Sub

    Public Sub ClearAllVariables()
        LabelPrintPosition = 0
        LotNumberStatus = ""
        LotNumberInspected = ""
        LotNumberCaPrintLabel = ""
        CurrentLotNumber = ""
        SpecialLabelLine1 = ""
        SpecialLabelLine2 = ""
        SpecialLabelLine3 = ""
        LabelDoesSpecialLabelExist = ""
        LabelSalesOrderNumber = ""
        LabelPickTicketNumber = ""
        LabelUsername = EmployeeLoginName
        LabelDivisionID = EmployeeSecurityCode
    End Sub

    Public Sub ClearAllLabelArray()
        LabelFormat(0) = ""
        LabelFormat(1) = ""
        LabelFormat(2) = ""
        LabelFormat(3) = ""
        LabelFormat(4) = ""
        LabelFormat(5) = ""
        LabelFormat(6) = ""
        LabelFormat(7) = ""
        LabelFormat(8) = ""
        LabelFormat(9) = ""
        LabelFormat(10) = ""
        LabelFormat(11) = ""
        LabelFormat(12) = ""
        LabelFormat(13) = ""
        LabelFormat(14) = ""
        LabelFormat(15) = ""
        LabelFormat(16) = ""
        LabelFormat(17) = ""
        LabelFormat(18) = ""
        LabelFormat(19) = ""
        LabelFormat(20) = ""
        LabelFormat(21) = ""
        LabelFormat(22) = ""
        LabelFormat(23) = ""
        LabelFormat(24) = ""
        LabelFormat(25) = ""
        LabelFormat(26) = ""
        LabelFormat(27) = ""
        LabelFormat(28) = ""
        LabelFormat(29) = ""
        LabelFormat(30) = ""
        LabelFormat(31) = ""
        LabelFormat(32) = ""
        LabelFormat(33) = ""
        LabelFormat(34) = ""
        LabelFormat(35) = ""
        LabelFormat(36) = ""
        LabelFormat(37) = ""
        LabelFormat(38) = ""
        LabelFormat(39) = ""
        LabelFormat(40) = ""
        LabelFormat(41) = ""
        LabelFormat(42) = ""
        LabelFormat(43) = ""
        LabelFormat(44) = ""
        LabelFormat(45) = ""
        LabelFormat(46) = ""
        LabelFormat(47) = ""
        LabelFormat(48) = ""
        LabelFormat(49) = ""
        LabelFormat(50) = ""
        LabelFormat(51) = ""
        LabelFormat(52) = ""
        LabelFormat(53) = ""
        LabelFormat(54) = ""
        LabelFormat(55) = ""
        LabelFormat(56) = ""
        LabelFormat(57) = ""
        LabelFormat(58) = ""
        LabelFormat(59) = ""
        LabelFormat(60) = ""
        LabelFormat(61) = ""
        LabelFormat(62) = ""
        LabelFormat(63) = ""
        LabelFormat(64) = ""
        LabelFormat(65) = ""
        LabelFormat(66) = ""
        LabelFormat(67) = ""
        LabelFormat(68) = ""
        LabelFormat(69) = ""
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

        LotNumberStatus = ""
        LotNumberInspected = ""
        LotNumberCaPrintLabel = ""
        CurrentLotNumber = ""
    End Sub

    Public Sub LoadInspectionProcess()
        cmd = New SqlCommand("SELECT InspectionKey FROM QCInspectionHeaderTable ORDER BY InspectionKey", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "QCInspectionHeaderTable")
        cboInspectionHeader.DataSource = ds1.Tables("QCInspectionHeaderTable")
        con.Close()
        cboInspectionHeader.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerID()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerID", con)
        cmd.Parameters.Add("DivisionID", SqlDbType.VarChar).Value = cboDivisionID05.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerID05.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerID05.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerName", con)
        cmd.Parameters.Add("DivisionID", SqlDbType.VarChar).Value = cboDivisionID05.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        cboCustomerName05.DataSource = ds3.Tables("CustomerList")
        con.Close()
        cboCustomerName05.SelectedIndex = -1
    End Sub

    Public Sub LoadPickTicketNumber()
        If cboDivisionID06.Text = "TWD" Or cboDivisionID06.Text = "TFP" Then
            cmd = New SqlCommand("SELECT PickListHeaderKey FROM PickListHeaderTable WHERE DivisionID = 'TWD' OR DivisionID = 'TFP'", con)
            If con.State = ConnectionState.Closed Then con.Open()
            ds4 = New DataSet()
            myAdapter4.SelectCommand = cmd
            myAdapter4.Fill(ds4, "PickListHeaderTable")
            cboPickTicket06.DataSource = ds4.Tables("PickListHeaderTable")
            con.Close()
            cboPickTicket06.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT PickListHeaderKey FROM PickListHeaderTable WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("DivisionID", SqlDbType.VarChar).Value = cboDivisionID06.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds4 = New DataSet()
            myAdapter4.SelectCommand = cmd
            myAdapter4.Fill(ds4, "PickListHeaderTable")
            cboPickTicket06.DataSource = ds4.Tables("PickListHeaderTable")
            con.Close()
            cboPickTicket06.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadCoilIDS()
        cmd = New SqlCommand("SELECT CoilID FROM CharterSteelCoilIdentification", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "CharterSteelCoilIdentification")
        cboScanEntry12.DataSource = ds5.Tables("CharterSteelCoilIdentification")
        con.Close()
        cboScanEntry12.SelectedIndex = -1
    End Sub

    Public Sub LoadFerrulePartNumber()
        cmd = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID = 'CHT' AND (ItemClass = 'WC FERRULES' OR ItemClass = 'WC WELD TILES')", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "ItemList")
        cboFerrulePartNumber23.DataSource = ds6.Tables("ItemList")
        con.Close()
        cboFerrulePartNumber23.SelectedIndex = -1
    End Sub

    Public Sub LoadFerrulePartNumberOther()
        cmd = New SqlCommand("SELECT Itemid FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass = 'FERRULE'", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "ItemList")
        cboFerrulePartNumber23.DataSource = ds6.Tables("ItemList")
        con.Close()
        cboFerrulePartNumber23.SelectedIndex = -1
    End Sub

    Public Sub LoadSpecialPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "ItemList")
        cboPartNumber24.DataSource = ds7.Tables("ItemList")
        con.Close()
        cboPartNumber24.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber2x4()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd
        myAdapter9.Fill(ds9, "ItemList")
        cboPartNumber2x4.DataSource = ds9.Tables("ItemList")
        con.Close()
        cboPartNumber2x4.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription2x4()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds10 = New DataSet()
        myAdapter10.SelectCommand = cmd
        myAdapter10.Fill(ds10, "ItemList")
        cboPartDescription2x4.DataSource = ds10.Tables("ItemList")
        con.Close()
        cboPartDescription2x4.SelectedIndex = -1
    End Sub

    Public Sub LoadSpecialPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> 'DEACTIVATED-PART'", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "ItemList")
        cboDescription24.DataSource = ds8.Tables("ItemList")
        con.Close()
        cboDescription24.SelectedIndex = -1
    End Sub

    Public Sub LoadLotNumberStatusAndIfInspected()
        Dim LotNumberStatusStatement As String = "SELECT Status FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim LotNumberStatusCommand As New SqlCommand(LotNumberStatusStatement, con)
        LotNumberStatusCommand.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = CurrentLotNumber

        Dim IsInspectedStatement As String = "SELECT QCInspected FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim IsInspectedCommand As New SqlCommand(IsInspectedStatement, con)
        IsInspectedCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = CurrentLotNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LotNumberStatus = CStr(LotNumberStatusCommand.ExecuteScalar)
        Catch ex As Exception
            LotNumberStatus = ""
        End Try
        Try
            LotNumberInspected = CStr(IsInspectedCommand.ExecuteScalar)
        Catch ex As Exception
            LotNumberInspected = ""
        End Try
        con.Close()

        If LotNumberStatus = "OPEN" Or LotNumberInspected = "NO" Then
            LotNumberCaPrintLabel = "NO"
        Else
            LotNumberCaPrintLabel = "YES"
        End If
    End Sub

    Public Sub LoadSpecialPartNumberByDescription()
        Dim SpecialPartNumber1 As String = ""

        Dim SpecialPartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim SpecialPartNumber1Command As New SqlCommand(SpecialPartNumber1Statement, con)
        SpecialPartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboDescription24.Text
        SpecialPartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SpecialPartNumber1 = CStr(SpecialPartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            SpecialPartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber24.Text = SpecialPartNumber1
    End Sub

    Public Sub LoadSpecialDescriptionByPartNumber()
        Dim SpecialPartDescription1 As String = ""

        Dim SpecialPartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE Itemid = @Itemid AND DivisionID = @DivisionID"
        Dim SpecialPartDescription1Command As New SqlCommand(SpecialPartDescription1Statement, con)
        SpecialPartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber24.Text
        SpecialPartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SpecialPartDescription1 = CStr(SpecialPartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            SpecialPartDescription1 = ""
        End Try
        con.Close()

        cboDescription24.Text = SpecialPartDescription1
    End Sub

    Private Sub CheckIfSpecialLabelExists()
        Dim CheckForLabelStatement As String = "SELECT * FROM PickListHeaderTable WHERE PickListHeaderKey = @PickListHeaderKey"
        Dim CheckForLabelCommand As New SqlCommand(CheckForLabelStatement, con)
        CheckForLabelCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = cboPickTicket06.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = CheckForLabelCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
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
            If IsDBNull(reader.Item("SalesOrderHeaderKey")) Then
                LabelSalesOrderNumber = ""
            Else
                LabelSalesOrderNumber = reader.Item("SalesOrderHeaderKey")
            End If
        Else
            SpecialLabelLine1 = ""
            SpecialLabelLine2 = ""
            SpecialLabelLine3 = ""
            LabelSalesOrderNumber = ""
        End If
        reader.Close()
        con.Close()

        If SpecialLabelLine1 = "" And SpecialLabelLine2 = "" And SpecialLabelLine3 = "" Then
            LabelDoesSpecialLabelExist = "NO"
        Else
            LabelDoesSpecialLabelExist = "YES"
        End If
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName05.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID05.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerID1 = ""
        End Try
        con.Close()

        cboCustomerID05.Text = CustomerID1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID05.Text
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID05.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName05.Text = CustomerName1
    End Sub

    Public Sub LoadCustomerShippingAddress()
        Dim ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry As String
        'Extract data from source table
        Dim GetCustomerDataString As String = "SELECT * FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetCustomerDataCommand As New SqlCommand(GetCustomerDataString, con)
        GetCustomerDataCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID05.Text
        GetCustomerDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID05.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetCustomerDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
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
        End If
        reader.Close()
        con.Close()

        txtAddress105.Text = ShipToAddress1
        txtAddress205.Text = ShipToAddress2
        txtCity05.Text = ShipToCity
        txtZipCode05.Text = ShipToZip
        txtState05.Text = ShipToState
        txtShipToCountry05.Text = ShipToCountry
    End Sub

    Public Sub LoadShippingAddressFromShipment()
        Dim CustomerID, CustomerName, ShipToCountry, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip As String
        'Extract data from source table
        Dim GetShipmentDataString As String = "SELECT * FROM ShipmentHeaderTable WHERE PickTicketNumber = @PickTicketNumber"
        Dim GetShipmentDataCommand As New SqlCommand(GetShipmentDataString, con)
        GetShipmentDataCommand.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(cboPickTicket06.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetShipmentDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CustomerID")) Then
                CustomerID = ""
            Else
                CustomerID = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("ShipToName")) Then
                CustomerName = ""
            Else
                CustomerName = reader.Item("ShipToName")
            End If
            If IsDBNull(reader.Item("ShipAddress1")) Then
                ShipToAddress1 = ""
            Else
                ShipToAddress1 = reader.Item("ShipAddress1")
            End If
            If IsDBNull(reader.Item("ShipAddress2")) Then
                ShipToAddress2 = ""
            Else
                ShipToAddress2 = reader.Item("ShipAddress2")
            End If
            If IsDBNull(reader.Item("ShipCity")) Then
                ShipToCity = ""
            Else
                ShipToCity = reader.Item("ShipCity")
            End If
            If IsDBNull(reader.Item("ShipState")) Then
                ShipToState = ""
            Else
                ShipToState = reader.Item("ShipState")
            End If
            If IsDBNull(reader.Item("ShipZip")) Then
                ShipToZip = ""
            Else
                ShipToZip = reader.Item("ShipZip")
            End If
            If IsDBNull(reader.Item("ShipCountry")) Then
                ShipToCountry = ""
            Else
                ShipToCountry = reader.Item("ShipCountry")
            End If
        Else
            CustomerID = ""
            CustomerName = ""
            ShipToAddress1 = ""
            ShipToAddress2 = ""
            ShipToCity = ""
            ShipToState = ""
            ShipToZip = ""
            ShipToCountry = ""
        End If
        reader.Close()
        con.Close()

        txtCustomerID06.Text = CustomerID
        txtCustomerName06.Text = CustomerName
        txtAddress106.Text = ShipToAddress1
        txtAddress206.Text = ShipToAddress2
        txtCity06.Text = ShipToCity
        txtZipCode06.Text = ShipToZip
        txtState06.Text = ShipToState
        txtShipToCountry06.Text = ShipToCountry
    End Sub

    Public Sub LoadDataForTubTag()
        'Declare Variables from Lot Number
        Dim FOXNumber, FinishedWeight As Integer
        Dim BlueprintNumber, PartNumber, ShortDescription, SteelCarbon, SteelSize, HeatNumber, AnnealedHeatNumber As String
        Dim PieceWeight As Double = 0

        'Declare Variables from FOX
        Dim FoxPromiseDate, FoxCustomerID As String
        Dim ProductionQuantity, TotalWeight, FoxFinishedWeight As Double

        'Extract data from source table
        Dim GetLotDataString As String = "SELECT * FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetLotDataCommand As New SqlCommand(GetLotDataString, con)
        GetLotDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtScanEntry07.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetLotDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("FOXNumber")) Then
                FOXNumber = 0
            Else
                FOXNumber = reader.Item("FOXNumber")
            End If
            If IsDBNull(reader.Item("FinishedWeight")) Then
                FinishedWeight = 0
            Else
                FinishedWeight = reader.Item("FinishedWeight")
            End If
            If IsDBNull(reader.Item("BlueprintNumber")) Then
                BlueprintNumber = ""
            Else
                BlueprintNumber = reader.Item("BlueprintNumber")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                ShortDescription = ""
            Else
                ShortDescription = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("SteelType")) Then
                SteelCarbon = ""
            Else
                SteelCarbon = reader.Item("SteelType")
            End If
            If IsDBNull(reader.Item("SteelSize")) Then
                SteelSize = ""
            Else
                SteelSize = reader.Item("SteelSize")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                HeatNumber = ""
            Else
                HeatNumber = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("AnnealedHeatNumber")) Then
                AnnealedHeatNumber = ""
            Else
                AnnealedHeatNumber = reader.Item("AnnealedHeatNumber")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                PieceWeight = 0
            Else
                PieceWeight = reader.Item("PieceWeight")
            End If
        Else
            FOXNumber = 0
            FinishedWeight = 0
            BlueprintNumber = ""
            PartNumber = ""
            ShortDescription = ""
            SteelCarbon = ""
            SteelSize = ""
            HeatNumber = ""
            AnnealedHeatNumber = ""
            PieceWeight = 0
        End If
        reader.Close()
        con.Close()

        'Extract data from source table
        Dim GetFOXDataString As String = "SELECT * FROM FOXTable WHERE FOXNumber = @FOXNumber"
        Dim GetFOXDataCommand As New SqlCommand(GetFOXDataString, con)
        GetFOXDataCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = FOXNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader1 As SqlDataReader = GetFOXDataCommand.ExecuteReader()
        If reader1.HasRows Then
            reader1.Read()
            If IsDBNull(reader1.Item("ProductionQuantity")) Then
                ProductionQuantity = 0
            Else
                ProductionQuantity = reader1.Item("ProductionQuantity")
            End If
            If IsDBNull(reader1.Item("PromiseDate")) Then
                FoxPromiseDate = ""
            Else
                FoxPromiseDate = reader1.Item("PromiseDate")
            End If
            If IsDBNull(reader1.Item("CustomerID")) Then
                FoxCustomerID = ""
            Else
                FoxCustomerID = reader1.Item("CustomerID")
            End If
            If IsDBNull(reader1.Item("FinishedWeight")) Then
                FoxFinishedWeight = 0
            Else
                FoxFinishedWeight = reader1.Item("FinishedWeight")
            End If
        Else
            FoxPromiseDate = ""
            FoxCustomerID = ""
            ProductionQuantity = 0
            FoxFinishedWeight = 0
        End If
        reader1.Close()
        con.Close()

        If FinishedWeight = 0 Then
            If FoxFinishedWeight = 0 Then
                TotalWeight = PieceWeight * ProductionQuantity
                TotalWeight = Math.Round(TotalWeight, 0)
            Else
                TotalWeight = (FoxFinishedWeight / 1000) * ProductionQuantity
                TotalWeight = Math.Round(TotalWeight, 0)
            End If
        Else
            TotalWeight = (FinishedWeight / 1000) * ProductionQuantity
            TotalWeight = Math.Round(TotalWeight, 0)
        End If

        txtLotNumber07.Text = txtScanEntry07.Text
        txtCustomerID07.Text = FoxCustomerID
        txtFOXNumber07.Text = FOXNumber
        txtBlueprint07.Text = BlueprintNumber
        txtPartNumber07.Text = PartNumber
        txtShortDescription07.Text = ShortDescription
        txtPromiseDate07.Text = FoxPromiseDate
        txtProductionQuantity07.Text = ProductionQuantity
        txtFinishWeight07.Text = FinishedWeight
        txtTotalWeight07.Text = TotalWeight
        txtSteelCarbon07.Text = SteelCarbon
        txtSteelSize07.Text = SteelSize
        txtHeatNumber07.Text = HeatNumber
        txtAnnealingLotNumber07.Text = AnnealedHeatNumber
    End Sub

    Public Sub LoadFryerData()
        Dim PartNumber, ShortDescription, RevisionLevel As String
        Dim BoxQuantity As Integer = 0

        'Extract data from source table
        Dim GetFryerDataString As String = "SELECT * FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetFryerDataCommand As New SqlCommand(GetFryerDataString, con)
        GetFryerDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtScanEntry10.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader1 As SqlDataReader = GetFryerDataCommand.ExecuteReader()
        If reader1.HasRows Then
            reader1.Read()
            If IsDBNull(reader1.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader1.Item("PartNumber")
            End If
            If IsDBNull(reader1.Item("ShortDescription")) Then
                ShortDescription = ""
            Else
                ShortDescription = reader1.Item("ShortDescription")
            End If
            If IsDBNull(reader1.Item("BlueprintRevision")) Then
                RevisionLevel = ""
            Else
                RevisionLevel = reader1.Item("BlueprintRevision")
            End If
            If IsDBNull(reader1.Item("BoxCount")) Then
                BoxQuantity = 0
            Else
                BoxQuantity = reader1.Item("BoxCount")
            End If
        Else
            PartNumber = ""
            ShortDescription = ""
            RevisionLevel = ""
            BoxQuantity = 0
        End If
        reader1.Close()
        con.Close()

        txtPartNumber10.Text = PartNumber
        txtShortDescription10.Text = ShortDescription
        txtRevisionLevel10.Text = RevisionLevel
        txtQuantity10.Text = BoxQuantity
    End Sub

    Public Sub LoadBranamData()
        Dim PartNumber, ShortDescription, RevisionLevel As String
        Dim BoxQuantity As Integer = 0

        'Extract data from source table
        Dim GetFryerDataString As String = "SELECT * FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetFryerDataCommand As New SqlCommand(GetFryerDataString, con)
        GetFryerDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtScanEntry25.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader1 As SqlDataReader = GetFryerDataCommand.ExecuteReader()
        If reader1.HasRows Then
            reader1.Read()
            If IsDBNull(reader1.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader1.Item("PartNumber")
            End If
            If IsDBNull(reader1.Item("ShortDescription")) Then
                ShortDescription = ""
            Else
                ShortDescription = reader1.Item("ShortDescription")
            End If
            If IsDBNull(reader1.Item("BlueprintRevision")) Then
                RevisionLevel = ""
            Else
                RevisionLevel = reader1.Item("BlueprintRevision")
            End If
            If IsDBNull(reader1.Item("BoxCount")) Then
                BoxQuantity = 0
            Else
                BoxQuantity = reader1.Item("BoxCount")
            End If
        Else
            PartNumber = ""
            ShortDescription = ""
            RevisionLevel = ""
            BoxQuantity = 0
        End If
        reader1.Close()
        con.Close()

        txtPartNumber25.Text = PartNumber
        txtPartDescription25.Text = ShortDescription
        txtSupplierNumber25.Text = "100254"
        txtQuantity25.Text = BoxQuantity
        txtCountry25.Text = "USA"
        txtHarmCode25.Text = "7318.15.9000"
    End Sub

    Public Sub LoadOptimasData()
        Dim PartNumber, ShortDescription, CountryOfOrigin As String
        Dim BoxQuantity As Integer = 0

        'Extract data from source table
        Dim GetFryerDataString As String = "SELECT * FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetFryerDataCommand As New SqlCommand(GetFryerDataString, con)
        GetFryerDataCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtScanEntry11.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader1 As SqlDataReader = GetFryerDataCommand.ExecuteReader()
        If reader1.HasRows Then
            reader1.Read()
            If IsDBNull(reader1.Item("PartNumber")) Then
                PartNumber = ""
            Else
                PartNumber = reader1.Item("PartNumber")
            End If
            If IsDBNull(reader1.Item("ShortDescription")) Then
                ShortDescription = ""
            Else
                ShortDescription = reader1.Item("ShortDescription")
            End If
            If IsDBNull(reader1.Item("MaterialOrigin")) Then
                CountryOfOrigin = ""
            Else
                CountryOfOrigin = reader1.Item("MaterialOrigin")
            End If
            If IsDBNull(reader1.Item("BoxCount")) Then
                BoxQuantity = 0
            Else
                BoxQuantity = reader1.Item("BoxCount")
            End If
        Else
            PartNumber = ""
            ShortDescription = ""
            CountryOfOrigin = ""
            BoxQuantity = 0
        End If
        reader1.Close()
        con.Close()

        If CountryOfOrigin = "DOMESTIC" Then
            CountryOfOrigin = "US"
        Else
            CountryOfOrigin = ""
        End If

        txtPartNumber11.Text = PartNumber
        txtShortDescription11.Text = ShortDescription
        txtCOO11.Text = CountryOfOrigin
        txtQuantity11.Text = BoxQuantity
    End Sub

    Public Sub LoadCoilData()
        Dim CoilHeatNumber, CoilCarbon, CoilSteelSize, CoilAnnealedLotNumber As String
        Dim CoilWeight As Integer

        'Extract data from source table
        Dim GetCoilDataString As String = "SELECT * FROM CharterSteelCoilIdentification WHERE CoilID = @CoilID"
        Dim GetCoilDataCommand As New SqlCommand(GetCoilDataString, con)
        GetCoilDataCommand.Parameters.Add("@CoilID", SqlDbType.VarChar).Value = cboScanEntry12.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader1 As SqlDataReader = GetCoilDataCommand.ExecuteReader()
        If reader1.HasRows Then
            reader1.Read()
            If IsDBNull(reader1.Item("HeatNumber")) Then
                CoilHeatNumber = ""
            Else
                CoilHeatNumber = reader1.Item("HeatNumber")
            End If
            If IsDBNull(reader1.Item("Carbon")) Then
                CoilCarbon = ""
            Else
                CoilCarbon = reader1.Item("Carbon")
            End If
            If IsDBNull(reader1.Item("SteelSize")) Then
                CoilSteelSize = ""
            Else
                CoilSteelSize = reader1.Item("SteelSize")
            End If
            If IsDBNull(reader1.Item("Weight")) Then
                CoilWeight = 0
            Else
                CoilWeight = reader1.Item("Weight")
            End If
            If IsDBNull(reader1.Item("Weight")) Then
                CoilWeight = 0
            Else
                CoilWeight = reader1.Item("Weight")
            End If
            If IsDBNull(reader1.Item("AnnealLot")) Then
                CoilAnnealedLotNumber = ""
            Else
                CoilAnnealedLotNumber = reader1.Item("AnnealLot")
            End If
        Else
            CoilHeatNumber = ""
            CoilCarbon = ""
            CoilSteelSize = ""
            CoilWeight = 0
            CoilAnnealedLotNumber = ""
        End If
        reader1.Close()
        con.Close()

        txtSteelCarbon12.Text = CoilCarbon
        txtSteelSize12.Text = CoilSteelSize
        txtHeatNumber12.Text = CoilHeatNumber
        txtWeight12.Text = CoilWeight
        txtAnnealedLotNumber12.Text = CoilAnnealedLotNumber
    End Sub

    Public Sub LoadAnnealingLotData()
        Dim SteelCarbon, SteelSize, HeatNumber, Base, Program, strDateIn, strDateOut As String
        Dim TotalWeight As Integer

        'Extract data from source table
        Dim GetCoilDataString As String = "SELECT * FROM AnnealingLog WHERE AnnealLotNumber = @AnnealLotNumber"
        Dim GetCoilDataCommand As New SqlCommand(GetCoilDataString, con)
        GetCoilDataCommand.Parameters.Add("@AnnealLotNumber", SqlDbType.VarChar).Value = txtAnnealedLotNumber16.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader1 As SqlDataReader = GetCoilDataCommand.ExecuteReader()
        If reader1.HasRows Then
            reader1.Read()
            If IsDBNull(reader1.Item("AnnealedCarbon")) Then
                SteelCarbon = ""
            Else
                SteelCarbon = reader1.Item("AnnealedCarbon")
            End If
            If IsDBNull(reader1.Item("AnnealedSteelSize")) Then
                SteelSize = ""
            Else
                SteelSize = reader1.Item("AnnealedSteelSize")
            End If
            If IsDBNull(reader1.Item("HeatNumber")) Then
                HeatNumber = ""
            Else
                HeatNumber = reader1.Item("HeatNumber")
            End If
            If IsDBNull(reader1.Item("Base")) Then
                Base = ""
            Else
                Base = reader1.Item("Base")
            End If
            If IsDBNull(reader1.Item("Program")) Then
                Program = 0
            Else
                Program = reader1.Item("Program")
            End If
            If IsDBNull(reader1.Item("DateIn")) Then
                strDateIn = ""
            Else
                strDateIn = reader1.Item("DateIn")
            End If
            If IsDBNull(reader1.Item("DateIn")) Then
                strDateOut = ""
            Else
                strDateOut = reader1.Item("DateIn")
            End If
            If IsDBNull(reader1.Item("TotalPoundsAnnealed")) Then
                TotalWeight = 0
            Else
                TotalWeight = reader1.Item("TotalPoundsAnnealed")
            End If
        Else
            SteelCarbon = ""
            SteelSize = ""
            HeatNumber = ""
            Base = ""
            Program = ""
            strDateIn = ""
            strDateOut = ""
            TotalWeight = 0
        End If
        reader1.Close()
        con.Close()

        txtSteelCarbon16.Text = SteelCarbon
        txtSteelSize16.Text = SteelSize
        txtHeatNumber16.Text = HeatNumber
        txtDateIn16.Text = strDateIn
        txtDateOut16.Text = strDateOut
        txtTotalWeight16.Text = TotalWeight
    End Sub

    Private Sub InsertIntoShippingLabelTable()
        LabelPickTicketNumber = cboPickTicket06.Text
 
        'Insert into table
        cmd = New SqlCommand("INSERT INTO ShippingAddressLabels (SalesOrderNumber, PickTicketNumber, LabelsPrinted, Username, DivisionID) values (@SalesOrderNumber, @PickTicketNumber, @LabelsPrinted, @Username, @DivisionID)", con)

        With cmd.Parameters
            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = LabelSalesOrderNumber
            .Add("@PickTicketNumber", SqlDbType.VarChar).Value = LabelPickTicketNumber
            .Add("@LabelsPrinted", SqlDbType.VarChar).Value = LabelDoesSpecialLabelExist
            .Add("@Username", SqlDbType.VarChar).Value = LabelUsername
            .Add("@DivisionID", SqlDbType.VarChar).Value = LabelDivisionID
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPrintBlueprintOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintBlueprintOnly.Click
        'Check to see if there is multiple B/P's with the same number















        If txtBlueprintFoxNumber.Text = "" And txtBlueprintBlueprintNumber.Text = "" Then
            MsgBox("You must select a FOX # or B/P # above to print.", MsgBoxStyle.OkOnly)
            Exit Sub
        ElseIf txtBlueprintBlueprintNumber.Text <> "" Then
            'Get Blueprint Number
            Dim obj As Object = txtBlueprintBlueprintNumber.Text

            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                Dim blueprint As New BlueprintSelection(obj.ToString)
                If blueprint.cmdHeader.Enabled Or blueprint.cmdMachining.Enabled Or blueprint.cmdFinished.Enabled Or blueprint.cmdTooling.Enabled Or blueprint.cmdTWEAccessories.Enabled Then
                    If blueprint.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        Dim startInfo As New ProcessStartInfo
                        Select Case blueprint.SelectedPrint
                            Case "HEADER"
                                startInfo.FileName = blueprint.HeaderFile
                            Case "MACHINING"
                                startInfo.FileName = blueprint.MachiningFile
                            Case "FINISHED"
                                startInfo.FileName = blueprint.FinishedFile
                            Case "TOOLING"
                                startInfo.FileName = blueprint.ToolingFile
                            Case "TWE Accessories"
                                startInfo.FileName = blueprint.AccessoriesFile
                        End Select

                        Dim pd As New PrintDialog
                        pd.UseEXDialog = True
                        Dim isLandscape As Boolean = pd.PrinterSettings.DefaultPageSettings.Landscape
                        pd.PrinterSettings.DefaultPageSettings.Landscape = True
                        'startInfo.WindowStyle = ProcessWindowStyle.Hidden
                        startInfo.Verb = "print"
                        startInfo.Arguments = ""
                        startInfo.UseShellExecute = True
                        startInfo.CreateNoWindow = True
                        Dim report As Process = New Process
                        report.StartInfo = startInfo
                        report.Start()
                        report.WaitForInputIdle()
                        report.CloseMainWindow()
                        pd.PrinterSettings.DefaultPageSettings.Landscape = isLandscape
                    End If
                Else
                    If Not String.IsNullOrEmpty(obj.ToString()) Then
                        MessageBox.Show("Unable to print blueprint, no blueprints found for blueprint " + obj.ToString() + ".", "Unable to print blueprint", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Unable to locate blueprint number.", "Unable to print blueprint", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                MessageBox.Show("Unable to print blueprint, no blueprint number found in the FOX.", "Unable to print blueprint", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf txtBlueprintFoxNumber.Text <> "" Then
            'Get Blueprint # from FOX and print B/P
            cmd = New SqlCommand("Select BlueprintNumber FROM FOXTable WHERE FOXNumber = @FOXNumber", con)
            cmd.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = Val(txtBlueprintFoxNumber.Text)
            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            con.Close()
            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                Dim blueprint As New BlueprintSelection(obj.ToString)
                If blueprint.cmdHeader.Enabled Or blueprint.cmdMachining.Enabled Or blueprint.cmdFinished.Enabled Or blueprint.cmdTooling.Enabled Or blueprint.cmdTWEAccessories.Enabled Then
                    If blueprint.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        Dim startInfo As New ProcessStartInfo
                        Select Case blueprint.SelectedPrint
                            Case "HEADER"
                                startInfo.FileName = blueprint.HeaderFile
                            Case "MACHINING"
                                startInfo.FileName = blueprint.MachiningFile
                            Case "FINISHED"
                                startInfo.FileName = blueprint.FinishedFile
                            Case "TOOLING"
                                startInfo.FileName = blueprint.ToolingFile
                            Case "TWE Accessories"
                                startInfo.FileName = blueprint.AccessoriesFile
                        End Select

                        Dim pd As New PrintDialog
                        pd.UseEXDialog = True
                        Dim isLandscape As Boolean = pd.PrinterSettings.DefaultPageSettings.Landscape
                        pd.PrinterSettings.DefaultPageSettings.Landscape = True
                        'startInfo.WindowStyle = ProcessWindowStyle.Hidden
                        startInfo.Verb = "print"
                        startInfo.Arguments = ""
                        startInfo.UseShellExecute = True
                        startInfo.CreateNoWindow = True
                        Dim report As Process = New Process
                        report.StartInfo = startInfo
                        report.Start()
                        report.WaitForInputIdle()
                        report.CloseMainWindow()
                        pd.PrinterSettings.DefaultPageSettings.Landscape = isLandscape
                    End If
                Else
                    If Not String.IsNullOrEmpty(obj.ToString()) Then
                        MessageBox.Show("Unable to print blueprint, no blueprints found for blueprint " + obj.ToString() + ".", "Unable to print blueprint", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Unable to locate blueprint number.", "Unable to print blueprint", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                MessageBox.Show("Unable to print blueprint, no blueprint number found in the FOX.", "Unable to print blueprint", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        'Clear Fields
        txtBlueprintBlueprintNumber.Clear()
        txtBlueprintFoxNumber.Clear()
        txtBlueprintFoxNumber.Focus()
    End Sub

    Private Sub cmdPrintWorkOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintWorkOrder.Click
        If txtProductionFoxNumber.Text = "" Then
            MsgBox("You must enter a FOX #.", MsgBoxStyle.OkOnly)
            txtProductionFoxNumber.Focus()
        Else
            Try
                'Get Division from FOX
                Dim GetDivisionFromFOX As String = ""

                Dim GetDivisionFromFOXStatement As String = "SELECT DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber"
                Dim GetDivisionFromFOXCommand As New SqlCommand(GetDivisionFromFOXStatement, con)
                GetDivisionFromFOXCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(txtProductionFoxNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetDivisionFromFOX = CStr(GetDivisionFromFOXCommand.ExecuteScalar)
                Catch ex As Exception
                    GetDivisionFromFOX = ""
                End Try
                con.Close()

                GlobalDivisionCode = GetDivisionFromFOX
                GlobalFOXNumber = Val(txtProductionFoxNumber.Text)
                GlobalProductionWorkOrder = "Work Order"
                GlobalProductionOrderAutoprint = "YES"

                Using NewPrintProductionOrder As New PrintProductionOrderNew
                    Dim Result = NewPrintProductionOrder.ShowDialog()
                End Using

                txtProductionFoxNumber.Clear()
                txtProductionFoxNumber.Focus()
            Catch ex As Exception
                MsgBox("Not a valid FOX #.", MsgBoxStyle.OkOnly)
                txtProductionFoxNumber.Clear()
                txtProductionFoxNumber.Focus()
            End Try
        End If
    End Sub

    Private Sub cmdPrintProductionOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintProductionOrder.Click
        If txtProductionFoxNumber.Text = "" Then
            MsgBox("You must enter a FOX #.", MsgBoxStyle.OkOnly)
            txtProductionFoxNumber.Focus()
        Else
            Try
                'Get Division from FOX
                Dim GetDivisionFromFOX As String = ""

                Dim GetDivisionFromFOXStatement As String = "SELECT DivisionID FROM FOXTable WHERE FOXNumber = @FOXNumber"
                Dim GetDivisionFromFOXCommand As New SqlCommand(GetDivisionFromFOXStatement, con)
                GetDivisionFromFOXCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = Val(txtProductionFoxNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetDivisionFromFOX = CStr(GetDivisionFromFOXCommand.ExecuteScalar)
                Catch ex As Exception
                    GetDivisionFromFOX = ""
                End Try
                con.Close()

                GlobalDivisionCode = GetDivisionFromFOX
                GlobalFOXNumber = Val(txtProductionFoxNumber.Text)
                GlobalProductionWorkOrder = "Production Order"
                GlobalProductionOrderAutoprint = "YES"

                Using NewPrintProductionOrder As New PrintProductionOrderNew
                    Dim Result = NewPrintProductionOrder.ShowDialog()
                End Using

                txtProductionFoxNumber.Clear()
                txtProductionFoxNumber.Focus()
            Catch ex As Exception
                MsgBox("Not a valid FOX #.", MsgBoxStyle.OkOnly)
                txtProductionFoxNumber.Clear()
                txtProductionFoxNumber.Focus()
            End Try
        End If
    End Sub

    Private Sub cmdInspectionReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdInspectionReport.Click
        Dim NewPrintQCInspectionReport As New PrintQCInspectionReport(cboInspectionHeader.Text)
        NewPrintQCInspectionReport.ShowDialog()

        cboInspectionHeader.SelectedIndex = -1
        cboInspectionHeader.Focus()
    End Sub

    Private Sub cmdTubPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTubPage.Click
        If txtLotNumber.Text = "" Then
            MsgBox("You must select a lo9t number.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Get FOX # for the specific Lot #
            Dim GetFOXNumber As String = ""
            Dim GetLotNumber As String = txtLotNumber.Text

            Dim GetFOXNumberStatement As String = "SELECT FOXNumber FROM LotNumber WHERE LotNumber = @LotNumber"
            Dim GetFOXNumberCommand As New SqlCommand(GetFOXNumberStatement, con)
            GetFOXNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetFOXNumber = CStr(GetFOXNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetFOXNumber = ""
            End Try
            con.Close()

            If txtLotNumber.Text <> "" Then
                Dim newViewTubPage As New ViewTubPage(GetFOXNumber, GetLotNumber)
                newViewTubPage.ShowDialog()
            End If

            txtLotNumber.Clear()
            GetFOXNumber = ""
            GetLotNumber = ""
            txtLotNumber.Focus()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearLabelFields()
        ClearAllGroupBoxesAndMakeInvisible()

        LabelPrintPosition = 0
    End Sub

    Private Sub cmdPrintOKProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintOKProcess.Click
        Dim newPrintOkToProcess As New PrintOkToProcess
        newPrintOkToProcess.ShowDialog()
    End Sub

    Private Sub cmdPrintOKShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintOKShip.Click
        Dim newPrintOkToShip As New PrintOkToShip
        newPrintOkToShip.ShowDialog()
    End Sub

    Private Sub cmdPrintGaugeChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintGaugeChart.Click
        Dim newPrintBlankGaugeSignout As New PrintBlankGaugeSignout
        newPrintBlankGaugeSignout.ShowDialog()
    End Sub

    '======================================================================================================================
    'LABEL PROGRAM CONTROLS
    '======================================================================================================================

    'Label Number One (Racking Label)

    Private Sub txtScanEntry01_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanEntry01.TextChanged
        If txtScanEntry01.Text.Length > 0 Then
            Select Case txtScanEntry01.Text.Substring(0, 1).ToUpper
                Case "S"
                    If txtScanEntry01.Text.Length = 1 Then
                        txtLotNumber01.Text = ""
                    Else
                        txtLotNumber01.Text = txtScanEntry01.Text.Substring(1)
                    End If

                Case Else
                    txtLotNumber01.Text = txtScanEntry01.Text
            End Select
        End If

        'Load Data by Lot Number
        Dim GetLotNumber01 As String = ""
        Dim GetHeatNumber01 As String = ""
        Dim GetPartNumber01 As String = ""
        Dim GetShortDescription01 As String = ""
        Dim GetLongDescription01 As String = ""
        Dim GetBoxWeight01 As Double = 0
        Dim GetPalletWeight01 As Double = 0
        Dim GetBoxCount01 As Double = 0
        Dim GetPalletCount01 As Double = 0
        Dim GetPieceWeight01 As Double = 0
        Dim GetPalletPieces01 As Double = 0
        Dim GetLotNumberDivision01 As String = ""

        Dim GetLotData01String As String = "SELECT * FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetLotData01Command As New SqlCommand(GetLotData01String, con)
        GetLotData01Command.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber01.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetLotData01Command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LotNumber")) Then
                GetLotNumber01 = ""
            Else
                GetLotNumber01 = reader.Item("LotNumber")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                GetHeatNumber01 = ""
            Else
                GetHeatNumber01 = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                GetPartNumber01 = ""
            Else
                GetPartNumber01 = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                GetShortDescription01 = ""
            Else
                GetShortDescription01 = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("LongDescription")) Then
                GetLongDescription01 = ""
            Else
                GetLongDescription01 = reader.Item("LongDescription")
            End If
            If IsDBNull(reader.Item("BoxWeight")) Then
                GetBoxWeight01 = 0
            Else
                GetBoxWeight01 = reader.Item("BoxWeight")
            End If
            If IsDBNull(reader.Item("PalletWeight")) Then
                GetPalletWeight01 = 0
            Else
                GetPalletWeight01 = reader.Item("PalletWeight")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                GetBoxCount01 = 0
            Else
                GetBoxCount01 = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                GetPalletCount01 = 0
            Else
                GetPalletCount01 = reader.Item("PalletCount")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                GetPieceWeight01 = 0
            Else
                GetPieceWeight01 = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("PalletPieces")) Then
                GetPalletPieces01 = 0
            Else
                GetPalletPieces01 = reader.Item("PalletPieces")
            End If
            If IsDBNull(reader.Item("DivisionID")) Then
                GetLotNumberDivision01 = ""
            Else
                GetLotNumberDivision01 = reader.Item("DivisionID")
            End If
        Else
            GetLotNumber01 = ""
            GetHeatNumber01 = ""
            GetPartNumber01 = ""
            GetShortDescription01 = ""
            GetLongDescription01 = ""
            GetBoxWeight01 = 0
            GetPalletWeight01 = 0
            GetBoxCount01 = 0
            GetPalletCount01 = 0
            GetPieceWeight01 = 0
            GetPalletPieces01 = 0
            GetLotNumberDivision01 = ""
        End If
        reader.Close()
        con.Close()
        '******************************************************************************
        'Load Part Number from LOT Number first
        txtPartNumber01.Text = GetPartNumber01
        '*******************************************************************************
        Dim ILGetBoxCount01 As Double = 0
        Dim ILGetPalletCount01 As Double = 0
        Dim ILGetBoxWeight01 As Double = 0

        'If certain fields are blank from Lot Number - Load from Part Number
        Dim ILBoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim ILBoxCountCommand As New SqlCommand(ILBoxCountStatement, con)
        ILBoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision01
        ILBoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GetPartNumber01

        Dim ILBoxWeightStatement As String = "SELECT BoxWeight FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim ILBoxWeightCommand As New SqlCommand(ILBoxWeightStatement, con)
        ILBoxWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision01
        ILBoxWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GetPartNumber01

        Dim ILPalletCountStatement As String = "SELECT PalletCount FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim ILPalletCountCommand As New SqlCommand(ILPalletCountStatement, con)
        ILPalletCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision01
        ILPalletCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GetPartNumber01

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ILGetBoxCount01 = CDbl(ILBoxCountCommand.ExecuteScalar)
        Catch ex As Exception
            ILGetBoxCount01 = 0
        End Try
        Try
            ILGetBoxWeight01 = CDbl(ILBoxWeightCommand.ExecuteScalar)
        Catch ex As Exception
            ILGetBoxWeight01 = 0
        End Try
        Try
            ILGetPalletCount01 = CDbl(ILPalletCountCommand.ExecuteScalar)
        Catch ex As Exception
            ILGetPalletCount01 = 0
        End Try
        con.Close()
        '***********************************************************************************
        If GetBoxCount01 = 0 Then
            txtBoxCount01.Text = ILGetBoxCount01
        Else
            txtBoxCount01.Text = GetBoxCount01
        End If
        If GetBoxWeight01 = 0 Then
            txtBoxWeight01.Text = ILGetBoxWeight01
        Else
            txtBoxWeight01.Text = GetBoxWeight01
        End If
        If GetPalletWeight01 = 0 Then
            txtPalletWeight01.Text = ILGetBoxWeight01 * ILGetPalletCount01
        Else
            txtPalletWeight01.Text = GetPalletWeight01
        End If
        If GetPalletPieces01 = 0 Then
            txtPalletPieces01.Text = ILGetBoxCount01 * ILGetPalletCount01
        Else
            txtPalletPieces01.Text = GetPalletPieces01
        End If
        '***********************************************************************************
        'Load the rest of the fields
        txtHeatNumber01.Text = GetHeatNumber01
        txtLongDescription01.Text = GetLongDescription01
        txtLotNumber01.Text = GetLotNumber01
        txtShortDescription01.Text = GetShortDescription01
    End Sub

    Private Sub txtBoxWeight01_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxWeight01.TextChanged
        Dim NewBoxWeight01 As Double = Val(txtBoxWeight01.Text)
        Dim NewPalletCount01 As Double = 0
        Dim GetLotNumberDivision01 As String = ""

        'Get Pallet Count (Number of Boxes on a pallet)
        Dim DivisionStatement As String = "SELECT DivisionID FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim DivisionCommand As New SqlCommand(DivisionStatement, con)
        DivisionCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber01.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLotNumberDivision01 = CStr(DivisionCommand.ExecuteScalar)
        Catch ex As Exception
            GetLotNumberDivision01 = ""
        End Try
        con.Close()

        Dim ILPalletCountStatement As String = "SELECT PalletCount FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim ILPalletCountCommand As New SqlCommand(ILPalletCountStatement, con)
        ILPalletCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision01
        ILPalletCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber01.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            NewPalletCount01 = CDbl(ILPalletCountCommand.ExecuteScalar)
        Catch ex As Exception
            NewPalletCount01 = 0
        End Try
        con.Close()

        txtPalletWeight01.Text = NewBoxWeight01 * NewPalletCount01
    End Sub

    Private Sub txtBoxCount01_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxCount01.TextChanged
        Dim NewBoxCount As Double = Val(txtBoxCount01.Text)
        Dim NewPalletCount01 As Double = 0
        Dim GetLotNumberDivision01 As String = ""

        'Get Pallet Count (Number of Boxes on a pallet)
        Dim DivisionStatement As String = "SELECT DivisionID FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim DivisionCommand As New SqlCommand(DivisionStatement, con)
        DivisionCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber01.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLotNumberDivision01 = CStr(DivisionCommand.ExecuteScalar)
        Catch ex As Exception
            GetLotNumberDivision01 = ""
        End Try
        con.Close()

        Dim ILPalletCountStatement As String = "SELECT PalletCount FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim ILPalletCountCommand As New SqlCommand(ILPalletCountStatement, con)
        ILPalletCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision01
        ILPalletCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber01.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            NewPalletCount01 = CDbl(ILPalletCountCommand.ExecuteScalar)
        Catch ex As Exception
            NewPalletCount01 = 0
        End Try
        con.Close()

        txtPalletPieces01.Text = NewBoxCount * NewPalletCount01
    End Sub

    'Label Number Two (FOX Label)

    Private Sub txtScanEntry02_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanEntry02.TextChanged
        If txtScanEntry02.Text.Length > 0 Then
            Select Case txtScanEntry02.Text.Substring(0, 1).ToUpper
                Case "S"
                    If txtScanEntry02.Text.Length = 1 Then
                        txtLotNumber02.Text = ""
                    Else
                        txtLotNumber02.Text = txtScanEntry02.Text.Substring(1)
                    End If

                Case Else
                    txtLotNumber02.Text = txtScanEntry02.Text
            End Select
        End If

        'Load Data by Lot Number
        Dim GetLotNumber02 As String = ""
        Dim GetHeatNumber02 As String = ""
        Dim GetPartNumber02 As String = ""
        Dim GetShortDescription02 As String = ""
        Dim GetBoxWeight02 As Double = 0
        Dim GetBoxCount02 As Double = 0
        Dim GetPalletCount02 As Double = 0
        Dim GetPieceWeight02 As Double = 0
        Dim GetPalletPieces02 As Double = 0
        Dim GetLotNumberDivision02 As String = ""
        Dim GetMaterialOrigin02 As String = ""
        Dim GetESRCode02 As String = ""

        Dim GetLotData02String As String = "SELECT * FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetLotData02Command As New SqlCommand(GetLotData02String, con)
        GetLotData02Command.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber02.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetLotData02Command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LotNumber")) Then
                GetLotNumber02 = ""
            Else
                GetLotNumber02 = reader.Item("LotNumber")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                GetHeatNumber02 = ""
            Else
                GetHeatNumber02 = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                GetPartNumber02 = ""
            Else
                GetPartNumber02 = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                GetShortDescription02 = ""
            Else
                GetShortDescription02 = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("BoxWeight")) Then
                GetBoxWeight02 = 0
            Else
                GetBoxWeight02 = reader.Item("BoxWeight")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                GetBoxCount02 = 0
            Else
                GetBoxCount02 = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                GetPalletCount02 = 0
            Else
                GetPalletCount02 = reader.Item("PalletCount")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                GetPieceWeight02 = 0
            Else
                GetPieceWeight02 = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("PalletPieces")) Then
                GetPalletPieces02 = 0
            Else
                GetPalletPieces02 = reader.Item("PalletPieces")
            End If
            If IsDBNull(reader.Item("DivisionID")) Then
                GetLotNumberDivision02 = ""
            Else
                GetLotNumberDivision02 = reader.Item("DivisionID")
            End If
            If IsDBNull(reader.Item("MaterialOrigin")) Then
                GetMaterialOrigin02 = ""
            Else
                GetMaterialOrigin02 = reader.Item("MaterialOrigin")
            End If
        Else
            GetLotNumber02 = ""
            GetHeatNumber02 = ""
            GetPartNumber02 = ""
            GetShortDescription02 = ""
            GetBoxWeight02 = 0
            GetBoxCount02 = 0
            GetPalletCount02 = 0
            GetPieceWeight02 = 0
            GetPalletPieces02 = 0
            GetLotNumberDivision02 = ""
            GetMaterialOrigin02 = ""
        End If
        reader.Close()
        con.Close()
        '******************************************************************************
        'Load Part Number from LOT Number first
        txtPartNumber02.Text = GetPartNumber02
        '*******************************************************************************
        Dim ILGetBoxCount02 As Double = 0
        Dim ILGetPalletCount02 As Double = 0
        Dim ILGetBoxWeight02 As Double = 0

        'If certain fields are blank from Lot Number - Load from Part Number
        Dim ILBoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim ILBoxCountCommand As New SqlCommand(ILBoxCountStatement, con)
        ILBoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision02
        ILBoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GetPartNumber02

        Dim ILBoxWeightStatement As String = "SELECT BoxWeight FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim ILBoxWeightCommand As New SqlCommand(ILBoxWeightStatement, con)
        ILBoxWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision02
        ILBoxWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GetPartNumber02

        Dim ILPalletCountStatement As String = "SELECT PalletCount FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim ILPalletCountCommand As New SqlCommand(ILPalletCountStatement, con)
        ILPalletCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision02
        ILPalletCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GetPartNumber02

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ILGetBoxCount02 = CDbl(ILBoxCountCommand.ExecuteScalar)
        Catch ex As Exception
            ILGetBoxCount02 = 0
        End Try
        Try
            ILGetBoxWeight02 = CDbl(ILBoxWeightCommand.ExecuteScalar)
        Catch ex As Exception
            ILGetBoxWeight02 = 0
        End Try
        Try
            ILGetPalletCount02 = CDbl(ILPalletCountCommand.ExecuteScalar)
        Catch ex As Exception
            ILGetPalletCount02 = 0
        End Try
        con.Close()
        '***********************************************************************************
        If GetBoxCount02 = 0 Then
            txtBoxCount02.Text = ILGetBoxCount02
        Else
            txtBoxCount02.Text = GetBoxCount02
        End If
        If GetBoxWeight02 = 0 Then
            txtBoxWeight02.Text = ILGetBoxWeight02
        Else
            txtBoxWeight02.Text = GetBoxWeight02
        End If
        If GetPalletPieces02 = 0 Then
            txtPalletPieces02.Text = ILGetBoxCount02 * ILGetPalletCount02
        Else
            txtPalletPieces02.Text = GetPalletPieces02
        End If
        '***********************************************************************************
        'Get ESR CODE
        txtESRNumber02.Clear()

        If GetLotNumberDivision02 = "TWD" Then
            If txtPartNumber02.Text.StartsWith("DBA") Then
                GetESRCode02 = "ESR 2823"
            ElseIf txtPartNumber02.Text.StartsWith("PSR") Then
                GetESRCode02 = "ESR 2822"
            ElseIf txtPartNumber02.Text.StartsWith("CA") Or txtPartNumber02.Text.StartsWith("SC") Or txtPartNumber02.Text.StartsWith("DSC") Then
                GetESRCode02 = "ESR 2577"
            Else
                GetESRCode02 = ""
            End If
        Else
            GetESRCode02 = ""
        End If

        If GetMaterialOrigin02 = "DOMESTIC" Then
            GetMaterialOrigin02 = "USA"
        Else
            GetMaterialOrigin02 = ""
        End If
        '***********************************************************************************
        'Load the rest of the fields
        txtHeatNumber02.Text = GetHeatNumber02
        txtLotNumber02.Text = GetLotNumber02
        txtShortDescription02.Text = GetShortDescription02
        txtCOO02.Text = GetMaterialOrigin02
        txtESRNumber02.Text = GetESRCode02
    End Sub

    Private Sub txtBoxCount02_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxCount02.TextChanged
        'Change the weight of the box when the pice weight changes
        Dim GetILPieceWeight02 As Double = 0
        Dim GetLotDivisionID02 As String = ""
        Dim NewBoxWeight02 As Double = 0
        Dim NewBoxCount02 As Double = Val(txtBoxCount02.Text)

        Dim GetLotDivisionIDStatement As String = "SELECT DivisionID FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetLotDivisionIDCommand As New SqlCommand(GetLotDivisionIDStatement, con)
        GetLotDivisionIDCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber02.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLotDivisionID02 = CStr(GetLotDivisionIDCommand.ExecuteScalar)
        Catch ex As Exception
            GetLotDivisionID02 = ""
        End Try
        con.Close()

        Dim GetILPieceWeight02Statement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GetILPieceWeight02Command As New SqlCommand(GetILPieceWeight02Statement, con)
        GetILPieceWeight02Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber02.Text
        GetILPieceWeight02Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotDivisionID02

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetILPieceWeight02 = CStr(GetILPieceWeight02Command.ExecuteScalar)
        Catch ex As Exception
            GetILPieceWeight02 = 0
        End Try
        con.Close()

        NewBoxWeight02 = GetILPieceWeight02 * NewBoxCount02
        NewBoxWeight02 = Math.Round(NewBoxWeight02, 0)

        txtBoxWeight02.Text = NewBoxWeight02
    End Sub

    'Label Number Three (Mixed Load Label)

    'Label Number Four (Mixed Heat Label)

    'Label Number Five (Shipping Label by Customer)

    Private Sub cboDivisionID05_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID05.SelectedIndexChanged
        LoadCustomerID()
        LoadCustomerName()
    End Sub

    Private Sub cboCustomerID05_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID05.SelectedIndexChanged
        LoadCustomerNameByID()
        LoadCustomerShippingAddress()
    End Sub

    Private Sub cboCustomerName05_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName05.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    'Label Number Six (Shipping Label by Shipment/Pick Ticket)

    Private Sub cboDivisionID06_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID06.SelectedIndexChanged
        LoadPickTicketNumber()
    End Sub

    Private Sub cboPickTicket06_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPickTicket06.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCustomerID06.Focus()
        End If
    End Sub

    Private Sub cboPickTicket06_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPickTicket06.Leave
        If cboPickTicket06.Text.Length > 0 Then
            Select Case cboPickTicket06.Text.Substring(0, 1).ToUpper
                Case "S"
                    If cboPickTicket06.Text.Length = 1 Then
                        cboPickTicket06.Text = ""
                    Else
                        cboPickTicket06.Text = cboPickTicket06.Text.Substring(1)
                    End If

                Case Else
                    cboPickTicket06.Text = cboPickTicket06.Text
            End Select
        End If

        LoadShippingAddressFromShipment()
        CheckIfSpecialLabelExists()
    End Sub

    Private Sub cboPickTicket06_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPickTicket06.LostFocus
        If cboPickTicket06.Text.Length > 0 Then
            Select Case cboPickTicket06.Text.Substring(0, 1).ToUpper
                Case "S"
                    If cboPickTicket06.Text.Length = 1 Then
                        cboPickTicket06.Text = ""
                    Else
                        cboPickTicket06.Text = cboPickTicket06.Text.Substring(1)
                    End If

                Case Else
                    cboPickTicket06.Text = cboPickTicket06.Text
            End Select
        End If

        LoadShippingAddressFromShipment()
        CheckIfSpecialLabelExists()
    End Sub

    'Label Number Seven (Tub Tag)

    Private Sub txtScanEntry07_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanEntry07.TextChanged
        If txtScanEntry07.Text.Length > 0 Then
            Select Case txtScanEntry07.Text.Substring(0, 1).ToUpper
                Case "S"
                    If txtScanEntry07.Text.Length = 1 Then
                        txtLotNumber07.Text = ""
                    Else
                        txtLotNumber07.Text = txtScanEntry07.Text.Substring(1)
                    End If

                Case Else
                    txtLotNumber07.Text = txtScanEntry07.Text
            End Select
        End If

        LoadDataForTubTag()
    End Sub

    Private Sub txtProductionQuantity07_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductionQuantity07.TextChanged
        Dim TempTotalWeight, TempPieceWeight, TempProductionQuantity As Double

        TempProductionQuantity = Val(txtProductionQuantity07.Text)

        'Get Piece weight from Lot Number
        Dim PieceWeight1Statement As String = "SELECT PieceWeight FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim PieceWeight1Command As New SqlCommand(PieceWeight1Statement, con)
        PieceWeight1Command.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber07.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TempPieceWeight = CDbl(PieceWeight1Command.ExecuteScalar)
        Catch ex As Exception
            TempPieceWeight = 0
        End Try
        con.Close()

        TempTotalWeight = TempPieceWeight * TempProductionQuantity
        TempTotalWeight = Math.Round(TempTotalWeight, 0)

        txtTotalWeight07.Text = TempTotalWeight
    End Sub

    'Label Number Eight (Bin Label)

    'Label Number Nine (Pallet Bin Label)

    'Label Number Ten (Fryer Label)

    Private Sub txtScanEntry10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanEntry10.TextChanged
        If txtScanEntry10.Text.Length > 0 Then
            Select Case txtScanEntry10.Text.Substring(0, 1).ToUpper
                Case "S"
                    If txtScanEntry10.Text.Length = 1 Then
                        txtLotNumber10.Text = ""
                    Else
                        txtLotNumber10.Text = txtScanEntry10.Text.Substring(1)
                    End If

                Case Else
                    txtLotNumber10.Text = txtScanEntry10.Text
            End Select
        End If

        LoadFryerData()
    End Sub

    'Label Number Eleven (Optimas Label)

    Private Sub txtScanEntry11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanEntry11.TextChanged
        If txtScanEntry11.Text.Length > 0 Then
            Select Case txtScanEntry11.Text.Substring(0, 1).ToUpper
                Case "S"
                    If txtScanEntry11.Text.Length = 1 Then
                        txtLotNumber11.Text = ""
                    Else
                        txtLotNumber11.Text = txtScanEntry11.Text.Substring(1)
                    End If

                Case Else
                    txtLotNumber11.Text = txtScanEntry11.Text
            End Select
        End If

        LoadOptimasData()
    End Sub

    'Label Number Twelve (Coil Yard Label)

    Private Sub cboScanEntry12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboScanEntry12.SelectedIndexChanged
        If cboScanEntry12.Text.Length > 0 Then
            Select Case cboScanEntry12.Text.Substring(0, 1).ToUpper
                Case "S"
                    If cboScanEntry12.Text.Length = 1 Then
                        cboScanEntry12.Text = ""
                    Else
                        cboScanEntry12.Text = cboScanEntry12.Text.Substring(1)
                    End If

                Case Else
                    cboScanEntry12.Text = cboScanEntry12.Text
            End Select
        End If

        LoadCoilData()
    End Sub

    'Label Number Thirteen (Universal Waste Label)

    'Label Number Fourteen (4 Line Label)

    'Label Number Fifteen (3 Line Label)

    'Label Number Sixteen (Anneal Sample Label)

    Private Sub txtAnnealedLotNumber16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAnnealedLotNumber16.TextChanged
        LoadAnnealingLotData()
    End Sub

    'Label Number Seventeen (Zinc Plated Label)

    'Label Number Eighteen (Nickel Plated Label)

    'Label Number Nineteen (Stainless Steel Label)

    'Label Number Twenty (Partial Pallet Label)

    'Label Number Twenty One (Custom Label)

    'Label Number Twenty Two - ATL/ATOP Label

    Private Sub txtScanEntry22_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanEntry22.TextChanged
        If txtScanEntry22.Text.Length > 0 Then
            Select Case txtScanEntry22.Text.Substring(0, 1).ToUpper
                Case "S"
                    If txtScanEntry22.Text.Length = 1 Then
                        txtLotNumber22.Text = ""
                    Else
                        txtLotNumber22.Text = txtScanEntry22.Text.Substring(1)
                    End If

                Case Else
                    txtLotNumber22.Text = txtScanEntry22.Text
            End Select
        End If

        'Load Data by Lot Number
        Dim GetLotNumber22 As String = ""
        Dim GetHeatNumber22 As String = ""
        Dim GetPartNumber22 As String = ""
        Dim GetShortDescription22 As String = ""
        Dim GetBoxWeight22 As Double = 0
        Dim GetBoxCount22 As Double = 0
        Dim GetPalletCount22 As Double = 0
        Dim GetPieceWeight22 As Double = 0
        Dim GetPalletPieces22 As Double = 0
        Dim GetLotNumberDivision22 As String = ""
        Dim GetATLPartNumber22 As String = ""
        Dim GetCustomerPartNumber22 As String = ""
        Dim GetFOXNumber22 As Integer = 0
        Dim GetCustomerPO22 As String = ""

        Dim GetLotData02String As String = "SELECT * FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetLotData02Command As New SqlCommand(GetLotData02String, con)
        GetLotData02Command.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber22.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetLotData02Command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("LotNumber")) Then
                GetLotNumber22 = ""
            Else
                GetLotNumber22 = reader.Item("LotNumber")
            End If
            If IsDBNull(reader.Item("HeatNumber")) Then
                GetHeatNumber22 = ""
            Else
                GetHeatNumber22 = reader.Item("HeatNumber")
            End If
            If IsDBNull(reader.Item("PartNumber")) Then
                GetPartNumber22 = ""
            Else
                GetPartNumber22 = reader.Item("PartNumber")
            End If
            If IsDBNull(reader.Item("ShortDescription")) Then
                GetShortDescription22 = ""
            Else
                GetShortDescription22 = reader.Item("ShortDescription")
            End If
            If IsDBNull(reader.Item("BoxWeight")) Then
                GetBoxWeight22 = 0
            Else
                GetBoxWeight22 = reader.Item("BoxWeight")
            End If
            If IsDBNull(reader.Item("BoxCount")) Then
                GetBoxCount22 = 0
            Else
                GetBoxCount22 = reader.Item("BoxCount")
            End If
            If IsDBNull(reader.Item("PalletCount")) Then
                GetPalletCount22 = 0
            Else
                GetPalletCount22 = reader.Item("PalletCount")
            End If
            If IsDBNull(reader.Item("PieceWeight")) Then
                GetPieceWeight22 = 0
            Else
                GetPieceWeight22 = reader.Item("PieceWeight")
            End If
            If IsDBNull(reader.Item("PalletPieces")) Then
                GetPalletPieces22 = 0
            Else
                GetPalletPieces22 = reader.Item("PalletPieces")
            End If
            If IsDBNull(reader.Item("DivisionID")) Then
                GetLotNumberDivision22 = ""
            Else
                GetLotNumberDivision22 = reader.Item("DivisionID")
            End If
            If IsDBNull(reader.Item("FOXNumber")) Then
                GetFOXNumber22 = 0
            Else
                GetFOXNumber22 = reader.Item("FOXNumber")
            End If
        Else
            GetLotNumber22 = ""
            GetHeatNumber22 = ""
            GetPartNumber22 = ""
            GetShortDescription22 = ""
            GetBoxWeight22 = 0
            GetBoxCount22 = 0
            GetPalletCount22 = 0
            GetPieceWeight22 = 0
            GetPalletPieces22 = 0
            GetLotNumberDivision22 = ""
            GetFOXNumber22 = 0
        End If
        reader.Close()
        con.Close()
        '******************************************************************************
        'Load Part Number from LOT Number first
        txtPartNumber22.Text = GetPartNumber22
        '*******************************************************************************
        Dim ILGetBoxCount22 As Double = 0
        Dim ILGetPalletCount22 As Double = 0
        Dim ILGetBoxWeight22 As Double = 0

        'If certain fields are blank from Lot Number - Load from Part Number
        Dim ILBoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim ILBoxCountCommand As New SqlCommand(ILBoxCountStatement, con)
        ILBoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision22
        ILBoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GetPartNumber22

        Dim ILBoxWeightStatement As String = "SELECT BoxWeight FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim ILBoxWeightCommand As New SqlCommand(ILBoxWeightStatement, con)
        ILBoxWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision22
        ILBoxWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GetPartNumber22

        Dim ILPalletCountStatement As String = "SELECT PalletCount FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim ILPalletCountCommand As New SqlCommand(ILPalletCountStatement, con)
        ILPalletCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision22
        ILPalletCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GetPartNumber22

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ILGetBoxCount22 = CDbl(ILBoxCountCommand.ExecuteScalar)
        Catch ex As Exception
            ILGetBoxCount22 = 0
        End Try
        Try
            ILGetBoxWeight22 = CDbl(ILBoxWeightCommand.ExecuteScalar)
        Catch ex As Exception
            ILGetBoxWeight22 = 0
        End Try
        Try
            ILGetPalletCount22 = CDbl(ILPalletCountCommand.ExecuteScalar)
        Catch ex As Exception
            ILGetPalletCount22 = 0
        End Try
        con.Close()
        '***********************************************************************************
        If GetBoxCount22 = 0 Then
            txtBoxQuantity22.Text = ILGetBoxCount22
        Else
            txtBoxQuantity22.Text = GetBoxCount22
        End If
        If GetBoxWeight22 = 0 Then
            txtBoxWeight22.Text = ILGetBoxWeight22
        Else
            txtBoxWeight22.Text = GetBoxWeight22
        End If
        If GetPalletPieces22 = 0 Then
            txtPalletPieces22.Text = ILGetBoxCount22 * ILGetPalletCount22
        Else
            txtPalletPieces22.Text = GetPalletPieces22
        End If
        '***********************************************************************************
        'Get Special FOX Fields

        'If certain fields are blank from Lot Number - Load from FOX
        Dim GetPartNumber2Statement As String = "SELECT PartNumber2 FROM FOXTable WHERE DivisionID = @DivisionID AND FOXNumber = @FOXNumber"
        Dim GetPartNumber2Command As New SqlCommand(GetPartNumber2Statement, con)
        GetPartNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision22
        GetPartNumber2Command.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = GetFOXNumber22

        Dim GetPartNumber3Statement As String = "SELECT PartNumber3 FROM FOXTable WHERE DivisionID = @DivisionID AND FOXNumber = @FOXNumber"
        Dim GetPartNumber3Command As New SqlCommand(GetPartNumber3Statement, con)
        GetPartNumber3Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision22
        GetPartNumber3Command.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = GetFOXNumber22

        Dim GetCustomerPOStatement As String = "SELECT CustomerPO FROM FOXTable WHERE DivisionID = @DivisionID AND FOXNumber = @FOXNumber"
        Dim GetCustomerPOCommand As New SqlCommand(GetCustomerPOStatement, con)
        GetCustomerPOCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotNumberDivision22
        GetCustomerPOCommand.Parameters.Add("@FOXNumber", SqlDbType.VarChar).Value = GetFOXNumber22

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetATLPartNumber22 = CStr(GetPartNumber2Command.ExecuteScalar)
        Catch ex As Exception
            GetATLPartNumber22 = ""
        End Try
        Try
            GetCustomerPartNumber22 = CStr(GetPartNumber3Command.ExecuteScalar)
        Catch ex As Exception
            GetCustomerPartNumber22 = ""
        End Try
        Try
            GetCustomerPO22 = CStr(GetCustomerPOCommand.ExecuteScalar)
        Catch ex As Exception
            GetCustomerPO22 = ""
        End Try
        con.Close()
        '***********************************************************************************
        'Load the rest of the fields
        txtHeatNumber22.Text = GetHeatNumber22
        txtLotNumber22.Text = GetLotNumber22
        txtPartDescription22.Text = GetShortDescription22
        txtATLPartNumber22.Text = GetATLPartNumber22
        txtCustomerPartNumber22.Text = GetCustomerPartNumber22
        txtCustomerPO22.Text = GetCustomerPO22
    End Sub

    Private Sub txtBoxQuantity22_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBoxQuantity22.TextChanged
        'Change the weight of the box when the pice weight changes
        Dim GetILPieceWeight22 As Double = 0
        Dim GetLotDivisionID22 As String = ""
        Dim NewBoxWeight22 As Double = 0
        Dim NewBoxCount22 As Double = Val(txtBoxQuantity22.Text)

        Dim GetLotDivisionIDStatement As String = "SELECT DivisionID FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetLotDivisionIDCommand As New SqlCommand(GetLotDivisionIDStatement, con)
        GetLotDivisionIDCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber22.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLotDivisionID22 = CStr(GetLotDivisionIDCommand.ExecuteScalar)
        Catch ex As Exception
            GetLotDivisionID22 = ""
        End Try
        con.Close()

        Dim GetILPieceWeight22Statement As String = "SELECT PieceWeight FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GetILPieceWeight22Command As New SqlCommand(GetILPieceWeight22Statement, con)
        GetILPieceWeight22Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = txtPartNumber22.Text
        GetILPieceWeight22Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetLotDivisionID22

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetILPieceWeight22 = CStr(GetILPieceWeight22Command.ExecuteScalar)
        Catch ex As Exception
            GetILPieceWeight22 = 0
        End Try
        con.Close()

        NewBoxWeight22 = GetILPieceWeight22 * NewBoxCount22
        NewBoxWeight22 = Math.Round(NewBoxWeight22, 0)

        txtBoxWeight22.Text = NewBoxWeight22
    End Sub

    'Label Twenty Three (Ferrule Box Label)

    Private Sub cboFerrulePartNumber23_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFerrulePartNumber23.SelectedIndexChanged
        Dim FerruleBoxCount23 As Double = 0
        Dim FerruleBoxWeight23 As Double = 0
        Dim FerruleDescription23 As String = ""

        If EmployeeCompanyCode = "CHT" Then
            'If certain fields are blank from Lot Number - Load from Part Number
            Dim FerruleBoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
            Dim FerruleBoxCountCommand As New SqlCommand(FerruleBoxCountStatement, con)
            FerruleBoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
            FerruleBoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboFerrulePartNumber23.Text

            Dim FerruleBoxWeightStatement As String = "SELECT BoxWeight FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
            Dim FerruleBoxWeightCommand As New SqlCommand(FerruleBoxWeightStatement, con)
            FerruleBoxWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
            FerruleBoxWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboFerrulePartNumber23.Text

            Dim FerruleDescriptionStatement As String = "SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
            Dim FerruleDescriptionCommand As New SqlCommand(FerruleDescriptionStatement, con)
            FerruleDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
            FerruleDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboFerrulePartNumber23.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FerruleBoxCount23 = CDbl(FerruleBoxCountCommand.ExecuteScalar)
            Catch ex As Exception
                FerruleBoxCount23 = 0
            End Try
            Try
                FerruleBoxWeight23 = CDbl(FerruleBoxWeightCommand.ExecuteScalar)
            Catch ex As Exception
                FerruleBoxWeight23 = 0
            End Try
            Try
                FerruleDescription23 = CStr(FerruleDescriptionCommand.ExecuteScalar)
            Catch ex As Exception
                FerruleDescription23 = ""
            End Try
            con.Close()

            txtBoxCount23.Text = FerruleBoxCount23
            txtDescription23.Text = FerruleDescription23

            If cboFerrulePartNumber23.Text.StartsWith("FER") Then
                txtBoxWeight23.Text = FerruleBoxWeight23
                lblBoxWeight23.Text = "BOX WEIGHT (Lbs.)"
            Else
                lblBoxWeight23.Text = "CUST. PO #"
                txtBoxWeight23.Clear()
            End If
        Else
            'If certain fields are blank from Lot Number - Load from Part Number
            Dim FerruleBoxCountStatement As String = "SELECT BoxCount FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
            Dim FerruleBoxCountCommand As New SqlCommand(FerruleBoxCountStatement, con)
            FerruleBoxCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            FerruleBoxCountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboFerrulePartNumber23.Text

            Dim FerruleBoxWeightStatement As String = "SELECT BoxWeight FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
            Dim FerruleBoxWeightCommand As New SqlCommand(FerruleBoxWeightStatement, con)
            FerruleBoxWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            FerruleBoxWeightCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboFerrulePartNumber23.Text

            Dim FerruleDescriptionStatement As String = "SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
            Dim FerruleDescriptionCommand As New SqlCommand(FerruleDescriptionStatement, con)
            FerruleDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            FerruleDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboFerrulePartNumber23.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FerruleBoxCount23 = CDbl(FerruleBoxCountCommand.ExecuteScalar)
            Catch ex As Exception
                FerruleBoxCount23 = 0
            End Try
            Try
                FerruleBoxWeight23 = CDbl(FerruleBoxWeightCommand.ExecuteScalar)
            Catch ex As Exception
                FerruleBoxWeight23 = 0
            End Try
            Try
                FerruleDescription23 = CStr(FerruleDescriptionCommand.ExecuteScalar)
            Catch ex As Exception
                FerruleDescription23 = ""
            End Try
            con.Close()

            txtBoxCount23.Text = FerruleBoxCount23
            txtDescription23.Text = FerruleDescription23

            If cboFerrulePartNumber23.Text.StartsWith("FER") Then
                txtBoxWeight23.Text = FerruleBoxWeight23
                lblBoxWeight23.Text = "BOX WEIGHT (Lbs.)"
            Else
                lblBoxWeight23.Text = "CUST. PO #"
                txtBoxWeight23.Clear()
            End If
        End If
    End Sub

    'Label Twenty Four (Special Part Label)

    Private Sub cboPartNumber24_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber24.SelectedIndexChanged
        LoadSpecialDescriptionByPartNumber()
    End Sub

    Private Sub cboDescription24_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDescription24.SelectedIndexChanged
        LoadSpecialPartNumberByDescription()
    End Sub

    Private Sub cmdClearData24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearData24.Click
        cboPartNumber24.SelectedIndex = -1
        cboDescription24.SelectedIndex = -1

        txtField1.Clear()
        txtField2.Clear()
        txtField3.Clear()
        txtField4.Clear()

        cboPartNumber24.Focus()
    End Sub

    Private Sub cmdClearAll24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll24.Click
        cboPartNumber24.SelectedIndex = -1
        cboDescription24.SelectedIndex = -1

        txtLabel1.Clear()
        txtLabel2.Clear()
        txtLabel3.Clear()
        txtLabel4.Clear()
        txtField1.Clear()
        txtField2.Clear()
        txtField3.Clear()
        txtField4.Clear()

        cboPartNumber24.Focus()
    End Sub

    'Label Twenty Five (Branam Label)

    Private Sub txtScanEntry25_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanEntry25.TextChanged
        'Load data by Lot Number
        If txtScanEntry25.Text.Length > 0 Then
            Select Case txtScanEntry25.Text.Substring(0, 1).ToUpper
                Case "S"
                    If txtScanEntry25.Text.Length = 1 Then
                        txtLotNumber25.Text = ""
                    Else
                        txtLotNumber25.Text = txtScanEntry25.Text.Substring(1)
                    End If

                Case Else
                    txtLotNumber25.Text = txtScanEntry25.Text
            End Select
        End If

        LoadBranamData()
    End Sub

    'Radio Button Controls

    Private Sub rdoStandardBarcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoStandardBarcode.CheckedChanged
        If rdoStandardBarcode.Checked = True Then
            gpxRackingBarcodeLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            txtScanEntry01.Focus()
            LabelPrintPosition = 1
        Else
            gpxRackingBarcodeLabel.Visible = False
        End If
    End Sub

    Private Sub rdoMasterBarcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMasterBarcode.CheckedChanged
        If rdoMasterBarcode.Checked = True Then
            gpxFactoryOrderLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            txtScanEntry02.Focus()
            LabelPrintPosition = 2
        Else
            gpxFactoryOrderLabel.Visible = False
        End If
    End Sub

    Private Sub rdoMixedLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMixedLabel.CheckedChanged
        If rdoMixedLabel.Checked = True Then
            gpxMixedLoadLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cmdPrintLabels.Focus()
            LabelPrintPosition = 3
        Else
            gpxMixedLoadLabel.Visible = False
        End If
    End Sub

    Private Sub rdoMixedHeat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoMixedHeat.CheckedChanged
        If rdoMixedHeat.Checked = True Then
            gpxMixedHeatLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cmdPrintLabels.Focus()
            LabelPrintPosition = 4
        Else
            gpxMixedHeatLabel.Visible = False
        End If
    End Sub

    Private Sub rdoShippingLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoShippingLabel.CheckedChanged
        If rdoShippingLabel.Checked = True Then
            gpxShippingAddressLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cboDivisionID05.Text = EmployeeCompanyCode
            cboCustomerID05.Focus()
            LabelPrintPosition = 5
        Else
            gpxShippingAddressLabel.Visible = False
            cboDivisionID05.Text = ""
        End If
    End Sub

    Private Sub rdoShippingLabelByPickTicket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoShippingLabelByPickTicket.CheckedChanged
        If rdoShippingLabelByPickTicket.Checked = True Then
            gpxShipAddressFromShipment.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cboDivisionID06.Text = EmployeeCompanyCode
            cboPickTicket06.Focus()
            LabelPrintPosition = 6
        Else
            gpxShipAddressFromShipment.Visible = False
            cboDivisionID06.Text = ""
        End If
    End Sub

    Private Sub rdoTubTag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTubTag.CheckedChanged
        If rdoTubTag.Checked = True Then
            gpxTubTag.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            txtScanEntry07.Focus()
            LabelPrintPosition = 7
        Else
            gpxTubTag.Visible = False
        End If
    End Sub

    Private Sub rdoBinLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBinLabel.CheckedChanged
        If rdoBinLabel.Checked = True Then
            gpxBinLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            txtRackNumber108.Focus()
            LabelPrintPosition = 8
        Else
            gpxBinLabel.Visible = False
        End If
    End Sub

    Private Sub rdoPalletBinLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPalletBinLabel.CheckedChanged
        If rdoPalletBinLabel.Checked = True Then
            gpxPalletBinLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            txtRackNumber09.Focus()
            LabelPrintPosition = 9
        Else
            gpxPalletBinLabel.Visible = False
        End If
    End Sub

    Private Sub rdoFryerLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoFryerLabel.CheckedChanged
        If rdoFryerLabel.Checked = True Then
            gpxFryer.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            txtScanEntry10.Focus()
            LabelPrintPosition = 10
        Else
            gpxFryer.Visible = False
        End If
    End Sub

    Private Sub rdoOptimasLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoOptimasLabel.CheckedChanged
        If rdoOptimasLabel.Checked = True Then
            gpxOptimasLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            txtScanEntry11.Focus()
            LabelPrintPosition = 11
        Else
            gpxOptimasLabel.Visible = False
        End If
    End Sub

    Private Sub rdoCoilYardLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCoilYardLabel.CheckedChanged
        If rdoCoilYardLabel.Checked = True Then
            gpxCoilYardLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            LoadCoilIDS()
            cboScanEntry12.Focus()
            LabelPrintPosition = 12
        Else
            gpxCoilYardLabel.Visible = False
        End If
    End Sub

    Private Sub rdoUniversalWaste_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoUniversalWaste.CheckedChanged
        If rdoUniversalWaste.Checked = True Then
            gpxUniversalWasteLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cmdPrintLabels.Focus()
            LabelPrintPosition = 13
        Else
            gpxUniversalWasteLabel.Visible = False
        End If
    End Sub

    Private Sub rdoBlank4Line_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBlank4Line.CheckedChanged
        If rdoBlank4Line.Checked = True Then
            gpxFourBlankLineLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            txtBlank114.Focus()
            LabelPrintPosition = 14
        Else
            gpxFourBlankLineLabel.Visible = False
        End If
    End Sub

    Private Sub rdoThreeLineBlank_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoThreeLineBlank.CheckedChanged
        If rdoThreeLineBlank.Checked = True Then
            gpxThreeBlankLineLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            txtBlankLineOne15.Focus()
            LabelPrintPosition = 15
        Else
            gpxThreeBlankLineLabel.Visible = False
        End If
    End Sub

    Private Sub rdoAnnealSample_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAnnealSample.CheckedChanged
        If rdoAnnealSample.Checked = True Then
            gpxAnnealSample.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            txtAnnealedLotNumber16.Focus()
            LabelPrintPosition = 16
        Else
            gpxAnnealSample.Visible = False
        End If
    End Sub

    Private Sub rdoZincPlatedLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoZincPlatedLabel.CheckedChanged
        If rdoZincPlatedLabel.Checked = True Then
            gpxZincPlatedLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cmdPrintLabels.Focus()
            LabelPrintPosition = 17
        Else
            gpxZincPlatedLabel.Visible = False
        End If
    End Sub

    Private Sub rdoNickelPlatedLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNickelPlatedLabel.CheckedChanged
        If rdoNickelPlatedLabel.Checked = True Then
            gpxNickelPlatedLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cmdPrintLabels.Focus()
            LabelPrintPosition = 18
        Else
            gpxNickelPlatedLabel.Visible = False
        End If
    End Sub

    Private Sub rdoStainlessSteelLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoStainlessSteelLabel.CheckedChanged
        If rdoStainlessSteelLabel.Checked = True Then
            gpxStainlessSteelLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cmdPrintLabels.Focus()
            LabelPrintPosition = 19
        Else
            gpxStainlessSteelLabel.Visible = False
        End If
    End Sub

    Private Sub rdoPartialPallet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPartialPallet.CheckedChanged
        If rdoPartialPallet.Checked = True Then
            gpxPartialPalletLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cmdPrintLabels.Focus()
            LabelPrintPosition = 20
        Else
            gpxPartialPalletLabel.Visible = False
        End If
    End Sub

    Private Sub rdoCustomLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCustomLabel.CheckedChanged
        If rdoCustomLabel.Checked = True Then
            gpxCustomLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cmdPrintLabels.Focus()
            LabelPrintPosition = 21
        Else
            gpxCustomLabel.Visible = False
        End If
    End Sub

    Private Sub rdoATopLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoATopLabel.CheckedChanged
        If rdoATopLabel.Checked = True Then
            gpxATopLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cmdPrintLabels.Focus()
            LabelPrintPosition = 22
        Else
            gpxATopLabel.Visible = False
        End If
    End Sub

    Private Sub rdoFerruleLabel23_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoFerruleLabel23.CheckedChanged
        If rdoFerruleLabel23.Checked = True Then
            gpxFerruleLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cboFerrulePartNumber23.Focus()
            LabelPrintPosition = 23
        Else
            gpxFerruleLabel.Visible = False
        End If
    End Sub

    Private Sub rdoSpecialPartLabel24_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSpecialPartLabel24.CheckedChanged
        If rdoSpecialPartLabel24.Checked = True Then
            gpxSLCPartLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            cboPartNumber24.Focus()
            LabelPrintPosition = 24
        Else
            gpxSLCPartLabel.Visible = False
        End If
    End Sub

    Private Sub rdoBranamLabel25_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBranamLabel25.CheckedChanged
        If rdoBranamLabel25.Checked = True Then
            gpxBranamFacilLabel.Visible = True
            ClearAllLabelArray()
            ClearLabelFields()
            ClearAllVariables()
            txtScanEntry25.Focus()
            LabelPrintPosition = 25
        Else
            gpxBranamFacilLabel.Visible = False
        End If
    End Sub

    'Clear Fields in Label Program Only

    Public Sub ClearLabelFields()
        'LabelPrintPosition = 0

        txtAddress105.Clear()
        txtAddress106.Clear()
        txtAddress205.Clear()
        txtAddress206.Clear()
        txtAnnealedLotNumber12.Clear()
        txtAnnealedLotNumber16.Clear()
        txtAnnealingLotNumber07.Clear()
        txtBase16.Clear()
        txtBlank114.Clear()
        txtBlank214.Clear()
        txtBlank314.Clear()
        txtBlank414.Clear()
        txtBlank514.Clear()
        txtBlank614.Clear()
        txtBlank714.Clear()
        txtBlank814.Clear()
        txtBlankLineOne15.Clear()
        txtBlankLineThree15.Clear()
        txtBlankLineTwo15.Clear()
        txtBlueprint07.Clear()
        txtBlueprintBlueprintNumber.Clear()
        txtBlueprintFoxNumber.Clear()
        txtBoxCount01.Clear()
        txtBoxCount02.Clear()
        txtBoxWeight01.Clear()
        txtBoxWeight02.Clear()
        txtCity05.Clear()
        txtCity06.Clear()
        txtCOO02.Clear()
        txtCOO11.Clear()
        txtCustomerID06.Clear()
        txtCustomerID07.Clear()
        txtCustomerName06.Clear()
        txtCustomerPO02.Clear()
        txtCustomerPO10.Clear()
        txtCustomerPO11.Clear()
        txtDateIn16.Clear()
        txtDateOut16.Clear()
        txtESRNumber02.Clear()
        txtFinishWeight07.Clear()
        txtFOXNumber07.Clear()
        txtHeatNumber01.Clear()
        txtHeatNumber02.Clear()
        txtHeatNumber07.Clear()
        txtHeatNumber12.Clear()
        txtHeatNumber16.Clear()
        txtLongDescription01.Clear()
        txtLotNumber.Clear()
        txtLotNumber01.Clear()
        txtLotNumber02.Clear()
        txtLotNumber07.Clear()
        txtLotNumber10.Clear()
        txtLotNumber11.Clear()
        txtPalletPieces01.Clear()
        txtPalletPieces02.Clear()
        txtPalletWeight01.Clear()
        txtPartNumber01.Clear()
        txtPartNumber02.Clear()
        txtPartNumber07.Clear()
        txtPartNumber10.Clear()
        txtPartNumber11.Clear()
        txtPOLineNumber11.Clear()
        txtProductionFoxNumber.Clear()
        txtProductionQuantity07.Clear()
        txtProgram16.Clear()
        txtPromiseDate07.Clear()
        txtQuantity10.Clear()
        txtQuantity11.Clear()
        txtRackNumber01.Clear()
        txtRackNumber09.Clear()
        txtRackNumber108.Clear()
        txtRackNumber208.Clear()
        txtRevisionLevel10.Clear()
        txtScanEntry01.Clear()
        txtScanEntry02.Clear()
        txtScanEntry07.Clear()
        txtScanEntry10.Clear()
        txtScanEntry11.Clear()
        txtShipToCountry05.Clear()
        txtShipToCountry06.Clear()
        txtShortDescription01.Clear()
        txtShortDescription02.Clear()
        txtShortDescription07.Clear()
        txtShortDescription10.Clear()
        txtShortDescription11.Clear()
        txtState05.Clear()
        txtState06.Clear()
        txtSteelCarbon07.Clear()
        txtSteelCarbon12.Clear()
        txtSteelCarbon16.Clear()
        txtSteelSize07.Clear()
        txtSteelSize12.Clear()
        txtSteelSize16.Clear()
        txtSupplierNumber10.Clear()
        txtTotalWeight07.Clear()
        txtTotalWeight16.Clear()
        txtWeight12.Clear()
        txtZipCode05.Clear()
        txtZipCode06.Clear()
        txtScanEntry22.Clear()
        txtLotNumber22.Clear()
        txtPalletPieces22.Clear()
        txtPartNumber22.Clear()
        txtHeatNumber22.Clear()
        txtBoxQuantity22.Clear()
        txtBoxWeight22.Clear()
        txtCustomerPO22.Clear()
        txtATLPartNumber22.Clear()
        txtCustomerPartNumber22.Clear()
        txtPartDescription22.Clear()
        txtBoxCount23.Clear()
        txtDescription23.Clear()
        txtBoxCount23.Clear()
        txtScanEntry25.Clear()
        txtLotNumber25.Clear()
        txtPartNumber25.Clear()
        txtPartDescription25.Clear()
        txtQuantity25.Clear()
        txtHarmCode25.Text = "7318.15.9000"
        txtReference25.Clear()
        txtCustomerPO25.Clear()
        txtSupplierNumber25.Text = "100254"
        txtCountry25.Text = "USA"
        txtEngChangeLevel25.Clear()
        txtLabel1.Clear()
        txtLabel2.Clear()
        txtLabel3.Clear()
        txtLabel4.Clear()
        txtField1.Clear()
        txtField2.Clear()
        txtField3.Clear()
        txtField4.Clear()
        txtNoteNumberOne.Clear()
        txtNoteNumberTwo.Clear()

        lblBoxWeight23.Text = "Box Weight (Lbs.)"
        chkRemoveAddress.Checked = False

        dtpFerruleDate23.Text = ""
        dtpDate01.Text = ""
        dtpDate02.Text = ""
        dtpShipDate11.Text = ""
        dtpATopLabel22.Text = ""

        cboCustomerID05.Text = ""
        cboCustomerName05.Text = ""
        cboDirection09.Text = ""
        cboInspectionHeader.Text = ""
        cboPickTicket06.Text = ""
        cboScanEntry12.Text = ""
        cboShift02.Text = ""
        cboFerrulePartNumber23.Text = ""
        cboPartNumber24.Text = ""
        cboDescription24.Text = ""

        cboCustomerID05.SelectedIndex = -1
        cboCustomerName05.SelectedIndex = -1
        cboDirection09.SelectedIndex = -1
        cboInspectionHeader.SelectedIndex = -1
        cboPickTicket06.SelectedIndex = -1
        cboScanEntry12.SelectedIndex = -1
        cboShift02.SelectedIndex = -1
        cboFerrulePartNumber23.SelectedIndex = -1
        cboPartNumber24.SelectedIndex = -1
        cboDescription24.SelectedIndex = -1

        nbrLabelCount.Value = 1
    End Sub

    'Setup and Create Labels

    Public Sub SetupAndCreateRackingBarcodeLabel(ByVal labels As Integer)
        Dim strTodaysDate, LotNumber, PartNumber, HeatNumber, ShortDescription, ShortDescription1, ShortDescription2, ShortDescription3, RackingLocation, strBoxWeight, strPalletWeight, strBoxQuantity, strPalletPieces As String
        Dim BoxWeight, PalletWeight, BoxCount, PalletPieces As Double
        Dim TodaysDate As Date = dtpDate01.Value
        Dim cutLength As Integer = 27
        Dim LotDivision As String = ""
        Dim TFPBlueprintRevision As String = ""

        'Fill Variables with test fields
        strTodaysDate = TodaysDate.ToShortDateString()
        LotNumber = txtLotNumber01.Text
        HeatNumber = txtHeatNumber01.Text
        PartNumber = txtPartNumber01.Text
        ShortDescription = txtShortDescription01.Text
        BoxWeight = Val(txtBoxWeight01.Text)
        BoxCount = Val(txtBoxCount01.Text)
        PalletWeight = Val(txtPalletWeight01.Text)
        PalletPieces = Val(txtPalletPieces01.Text)
        RackingLocation = txtRackNumber01.Text

        BoxWeight = Math.Round(BoxWeight, 0)
        PalletWeight = Math.Round(PalletWeight, 0)
        BoxCount = Math.Round(BoxCount, 0)
        PalletPieces = Math.Round(PalletPieces, 0)

        strBoxQuantity = CStr(BoxCount)
        strBoxWeight = CStr(BoxWeight)
        strPalletPieces = CStr(PalletPieces)
        strPalletWeight = CStr(PalletWeight)

        strPalletPieces = "Q" + strPalletPieces
        strPalletWeight = "W" + strPalletWeight
        PartNumber = "P" + PartNumber
        LotNumber = "S" + LotNumber
        HeatNumber = "EH" + HeatNumber
        '*************************************************************************************************************************
        'Get Division from the Lot Number
        Dim GetDivisionFromLotStatement As String = "SELECT DivisionID FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetDivisionFromLotCommand As New SqlCommand(GetDivisionFromLotStatement, con)
        GetDivisionFromLotCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber01.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LotDivision = CStr(GetDivisionFromLotCommand.ExecuteScalar)
        Catch ex As Exception
            LotDivision = ""
        End Try
        con.Close()

        'Get Blueprint Revision if part is from TFP
        If LotDivision = "TFP" Then
            Dim GetRevisionStatement As String = "SELECT BlueprintRevision FROM LotNumber WHERE LotNumber = @LotNumber"
            Dim GetRevisionCommand As New SqlCommand(GetRevisionStatement, con)
            GetRevisionCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber01.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TFPBlueprintRevision = CStr(GetRevisionCommand.ExecuteScalar)
            Catch ex As Exception
                TFPBlueprintRevision = ""
            End Try
            con.Close()
        Else
            TFPBlueprintRevision = ""
        End If
        '*************************************************************************************************************************
        'Create Short Description
        ShortDescription1 = ""
        ShortDescription2 = ""
        ShortDescription3 = ""

        Dim TotalCharactersInDescription As Integer = 0

        ShortDescription1 = "FULL PALLET"

        ShortDescription = txtShortDescription01.Text
        TotalCharactersInDescription = ShortDescription.Length

        If ShortDescription.Length > 27 Then
            If TotalCharactersInDescription > 54 Then
                ShortDescription2 = ShortDescription.Substring(0, 27)
                ShortDescription3 = ShortDescription.Substring(27, 27)
            Else
                ShortDescription2 = ShortDescription.Substring(0, 27)
                ShortDescription3 = ShortDescription.Substring(27, TotalCharactersInDescription - 27)
            End If
        Else
            ShortDescription3 = ""
        End If

        ShortDescription1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")
        ShortDescription2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")
        ShortDescription3.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Format Lines on Label
        LabelFormat(8) = "LO609,8,1,1196"
        LabelFormat(9) = "LO406,8,1,1196"
        LabelFormat(10) = "LO213,8,1,1196"
        LabelFormat(11) = "LO213,479,193,1"
        LabelFormat(12) = "LO213,863,193,1"
        LabelFormat(13) = "LO2,753,211,1"
        LabelFormat(14) = "LO406,650,204,1"

        'Format Label
        LabelFormat(15) = "A800,35,1,3,2,1,N," + Chr(34) + "DESCRIPTION" + Chr(34)
        LabelFormat(16) = "A786,552,1,4,2,2,N," + Chr(34) + ShortDescription1 + Chr(34)
        LabelFormat(17) = "A727,75,1,4,2,2,N," + Chr(34) + ShortDescription2 + Chr(34)
        LabelFormat(18) = "A668,75,1,4,2,2,N," + Chr(34) + ShortDescription3 + Chr(34)
        LabelFormat(19) = "A603,35,1,3,2,1,N," + Chr(34) + "(P) PART NUMBER" + Chr(34)

        If LotDivision = "TFP" Then
            If Not PartNumber.ToUpper.Contains("REV. ") And Not PartNumber.ToUpper.Contains("REV ") Then
                LabelFormat(20) = "B560,35,1,3,2,4,102,B," + Chr(34) + PartNumber + " Rev. " + TFPBlueprintRevision + Chr(34)
            Else
                LabelFormat(20) = "B560,35,1,3,2,4,102,B," + Chr(34) + PartNumber + Chr(34)
            End If
        Else
            LabelFormat(20) = "B560,35,1,3,2,4,102,B," + Chr(34) + PartNumber + Chr(34)
        End If

        LabelFormat(21) = "A398,35,1,3,2,1,N," + Chr(34) + "(Q) QUANTITY" + Chr(34)
        LabelFormat(22) = "B355,35,1,3,2,4,102,B," + Chr(34) + strPalletPieces + Chr(34)
        LabelFormat(23) = "A207,35,1,3,2,1,N," + Chr(34) + "(EH) HEAT NUMBER" + Chr(34)
        LabelFormat(24) = "B165,35,1,3,2,4,102,B," + Chr(34) + HeatNumber + Chr(34)
        LabelFormat(25) = "A398,508,1,3,2,1,N," + Chr(34) + "(W) WEIGHT" + Chr(34)
        LabelFormat(26) = "B355,508,1,3,2,4,102,B," + Chr(34) + strPalletWeight + Chr(34)
        LabelFormat(27) = "A398,871,1,3,2,1,N," + Chr(34) + "DATE" + Chr(34)
        LabelFormat(28) = "A335,871,1,4,2,2,N," + Chr(34) + strTodaysDate + Chr(34)
        LabelFormat(29) = "A207,772,1,3,2,1,N," + Chr(34) + "BIN" + Chr(34)
        LabelFormat(30) = "B165,772,1,3,2,4,102,B," + Chr(34) + RackingLocation + Chr(34)
        LabelFormat(31) = "A597,665,1,3,2,1,N," + Chr(34) + "(S) SERIAL(LOT) NUMBER" + Chr(34)
        LabelFormat(32) = "B550,665,1,3,2,4,102,B," + Chr(34) + LotNumber + Chr(34)
        LabelFormat(33) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(34) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)

        LabelFormat(35) = "P" + labels.ToString()
        LabelFormat(36) = vbFormFeed
        LabelLines = 35
    End Sub

    Public Sub SetupAndCreateFOXLabel(ByVal labels As Integer)
        'Define Variables from text boxes
        Dim LotNumber As String = ""
        Dim PartNumber As String = ""
        Dim HeatNumber As String = ""
        Dim strBoxWeight As String = ""
        Dim strBoxCount As String = ""
        Dim strPalletPieces As String = ""
        Dim ShortDescription As String = ""
        Dim CustomerPO As String = ""
        Dim ESRNumber As String = ""
        Dim CountryOfOrigin As String = ""
        Dim BoxWeight, BoxCount, PalletPieces As Double
        Dim LotDivision As String = ""
        Dim TodaysDate As Date
        Dim strTodaysDate As String = ""
        Dim ShortDescription1, ShortDescription2, ShortDescription3 As String
        Dim TFPBlueprintRevision As String = ""
        Dim TFPShift As String = ""

        Dim SupplierAddress As String = ""

        LotNumber = txtLotNumber02.Text
        PartNumber = txtPartNumber02.Text
        HeatNumber = txtHeatNumber02.Text
        BoxWeight = Val(txtBoxWeight02.Text)
        BoxCount = Val(txtBoxCount02.Text)
        PalletPieces = Val(txtPalletPieces02.Text)
        ShortDescription = txtShortDescription02.Text
        CustomerPO = txtCustomerPO02.Text
        ESRNumber = txtESRNumber02.Text
        CountryOfOrigin = txtCOO02.Text
        TFPShift = cboShift02.Text

        'Set Supplier Address
        If chkRemoveAddress.Checked = True Then
            SupplierAddress = ""
        Else
            SupplierAddress = "TFP CORP. MEDINA, OH 44256 330-725-7741"
        End If

        BoxCount = Math.Round(BoxCount, 0)
        BoxWeight = Math.Round(BoxWeight, 0)
        PalletPieces = Math.Round(PalletPieces, 0)

        strBoxCount = CStr(BoxCount)
        strBoxWeight = CStr(BoxWeight)
        strPalletPieces = CStr(PalletPieces)

        'Convert Date to string
        TodaysDate = dtpDate02.Value
        strTodaysDate = TodaysDate.ToShortDateString()

        'Get Division from the Lot Number
        Dim GetDivisionFromLotStatement As String = "SELECT DivisionID FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetDivisionFromLotCommand As New SqlCommand(GetDivisionFromLotStatement, con)
        GetDivisionFromLotCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber02.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LotDivision = CStr(GetDivisionFromLotCommand.ExecuteScalar)
        Catch ex As Exception
            LotDivision = ""
        End Try
        con.Close()

        'Get Blueprint Revision if part is from TFP
        If LotDivision = "TFP" Then
            Dim GetRevisionStatement As String = "SELECT BlueprintRevision FROM LotNumber WHERE LotNumber = @LotNumber"
            Dim GetRevisionCommand As New SqlCommand(GetRevisionStatement, con)
            GetRevisionCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber02.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TFPBlueprintRevision = CStr(GetRevisionCommand.ExecuteScalar)
            Catch ex As Exception
                TFPBlueprintRevision = ""
            End Try
            con.Close()
        Else
            TFPBlueprintRevision = ""
        End If

        'Get Description - split into three fields by character count
        'Create Short Description
        Dim TotalCharactersInDescription As Integer = 0

        ShortDescription1 = ""
        ShortDescription2 = ""
        ShortDescription3 = ""

        ShortDescription = txtShortDescription02.Text
        TotalCharactersInDescription = ShortDescription.Length

        If ShortDescription.Length > 27 Then
            If TotalCharactersInDescription > 54 Then
                If TotalCharactersInDescription > 81 Then
                    ShortDescription1 = ShortDescription.Substring(0, 27)
                    ShortDescription2 = ShortDescription.Substring(27, 27)
                    ShortDescription3 = ShortDescription.Substring(54, 27)
                Else
                    ShortDescription1 = ShortDescription.Substring(0, 27)
                    ShortDescription2 = ShortDescription.Substring(27, 27)
                    ShortDescription3 = ShortDescription.Substring(54, TotalCharactersInDescription - 54)
                End If
            Else
                ShortDescription1 = ShortDescription.Substring(0, 27)
                ShortDescription2 = ShortDescription.Substring(27, TotalCharactersInDescription - 27)
                ShortDescription3 = ""
            End If
        Else
            ShortDescription1 = ShortDescription
            ShortDescription2 = ""
            ShortDescription3 = ""
        End If

        ShortDescription1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")
        ShortDescription2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")
        ShortDescription3.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes
        LabelFormat(8) = "LO609,8,1,1196"
        LabelFormat(9) = "LO406,8,1,1196"
        LabelFormat(10) = "LO203,8,1,1196"
        LabelFormat(11) = "LO406,438,204,1"
        LabelFormat(12) = "LO14,812,393,1"
        LabelFormat(13) = "LO203,340,204,1"
        LabelFormat(14) = "LO102,812,1,398"

        'Fill in Verbiage
        LabelFormat(15) = "A35,10,1,3,1,1,N," + Chr(34) + SupplierAddress + Chr(34)
        LabelFormat(16) = "A794,12,1,3,1,1,N," + Chr(34) + "PRODUCT IDENTIFICATION" + Chr(34)
        LabelFormat(17) = "A774,12,1,3,1,1,N," + Chr(34) + "(P)" + Chr(34)
        LabelFormat(18) = "A601,12,1,3,1,1,N," + Chr(34) + "QUANTITY" + Chr(34)
        LabelFormat(19) = "A581,12,1,3,1,1,N," + Chr(34) + "(Q)" + Chr(34)
        LabelFormat(20) = "A601,475,1,3,1,1,N," + Chr(34) + "DESCRIPTION" + Chr(34)
        LabelFormat(21) = "A398,12,1,3,1,1,N," + Chr(34) + "WEIGHT" + Chr(34)
        LabelFormat(22) = "A378,12,1,3,1,1,N," + Chr(34) + "(W)" + Chr(34)
        LabelFormat(23) = "A398,350,1,3,1,1,N," + Chr(34) + "HT.NO." + Chr(34)
        LabelFormat(24) = "A378,350,1,3,1,1,N," + Chr(34) + "(EH)" + Chr(34)

        If Not String.IsNullOrEmpty(PartNumber) Then
            LabelFormat(25) = "A392,816,1,3,1,1,N," + Chr(34) + "P.O. NUMBER" + Chr(34)
            LabelFormat(26) = "A372,816,1,3,1,1,N," + Chr(34) + "(A)" + Chr(34)
            If PartNumber.StartsWith("DBA") Or PartNumber.StartsWith("CA") Or PartNumber.StartsWith("SC") Or PartNumber.StartsWith("DSC") Or PartNumber.StartsWith("PSR") Then
                LabelFormat(30) = "A191,1050,1,3,1,1,N," + Chr(34) + "SHIFT" + Chr(34)
            ElseIf PartNumber.StartsWith("TT") Or PartNumber.StartsWith("NT") Or PartNumber.StartsWith("TP") Then
                LabelFormat(30) = "A191,1050,1,3,1,1,N," + Chr(34) + "Operator" + Chr(34)
            Else
                LabelFormat(30) = "A191,1050,1,3,1,1,N," + Chr(34) + " " + Chr(34)
            End If
        Else
            LabelFormat(25) = "A392,816,1,3,1,1,N," + Chr(34) + "P.O. NUMBER" + Chr(34)
            LabelFormat(26) = "A372,816,1,3,1,1,N," + Chr(34) + "(A)" + Chr(34)
            LabelFormat(30) = "A191,1050,1,3,1,1,N," + Chr(34) + " " + Chr(34)
        End If

        LabelFormat(27) = "A191,12,1,3,1,1,N," + Chr(34) + "SERIAL NO." + Chr(34)
        LabelFormat(28) = "A171,12,1,3,1,1,N," + Chr(34) + "(S)" + Chr(34)
        LabelFormat(29) = "A191,816,1,3,1,1,N," + Chr(34) + "DATE" + Chr(34)
        LabelFormat(31) = "A89,816,1,3,1,1,N," + Chr(34) + "COUNTRY OF ORIGIN" + Chr(34)


        LabelFormat(33) = "A601,136,1,4,3,2,N," + Chr(34) + strBoxCount + Chr(34)
        LabelFormat(34) = "A386,108,1,4,3,2,N," + Chr(34) + strBoxWeight + Chr(34)

        LabelFormat(35) = "A200,210,1,4,3,2,N," + Chr(34) + LotNumber + Chr(34)
        LabelFormat(36) = "A575,452,1,3,3,2,N," + Chr(34) + ShortDescription1 + Chr(34)
        LabelFormat(37) = "A525,452,1,3,3,2,N," + Chr(34) + ShortDescription2 + Chr(34)
        LabelFormat(38) = "A475,452,1,3,3,2,N," + Chr(34) + ShortDescription3 + Chr(34)

        If HeatNumber.Length >= 10 Then
            If HeatNumber.Length >= 14 Then
                LabelFormat(39) = "A380,420,1,2,3,2,N," + Chr(34) + HeatNumber + Chr(34)
                LabelFormat(47) = "B313,360,1,3,1,2,102,N," + Chr(34) + "EH" + HeatNumber + Chr(34)
            Else
                LabelFormat(39) = "A380,420,1,3,3,2,N," + Chr(34) + HeatNumber + Chr(34)
                LabelFormat(47) = "B313,360,1,3,1,2,102,N," + Chr(34) + "EH" + HeatNumber + Chr(34)
            End If
        Else
            LabelFormat(39) = "A380,420,1,4,3,2,N," + Chr(34) + HeatNumber + Chr(34)
            LabelFormat(47) = "B313,360,1,3,2,4,102,N," + Chr(34) + "EH" + HeatNumber + Chr(34)
        End If

        If CustomerPO.Length < 12 Then
            LabelFormat(40) = "A345,825,1,3,3,2,N," + Chr(34) + CustomerPO.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        ElseIf CustomerPO.Length >= 12 And CustomerPO.Length < 14 Then
            LabelFormat(40) = "A345,825,1,3,3,2,N," + Chr(34) + CustomerPO.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        ElseIf CustomerPO.Length >= 14 And CustomerPO.Length < 16 Then
            LabelFormat(40) = "A345,825,1,2,3,2,N," + Chr(34) + CustomerPO.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        Else
            LabelFormat(40) = "A345,825,1,1,3,2,N," + Chr(34) + CustomerPO.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        End If

        LabelFormat(41) = "A170,816,1,4,2,1,N," + Chr(34) + strTodaysDate + Chr(34)
        LabelFormat(42) = "A63,822,1,4,2,1,N," + Chr(34) + CountryOfOrigin + Chr(34)

        ''check to see if the part number is going to go off label, if os will re-adjust it
        If LotDivision = "TFP" Then
            If Not PartNumber.ToUpper.Contains("REV. ") And Not PartNumber.ToUpper.Contains("REV ") Then
                If (PartNumber.Length + TFPBlueprintRevision.Length) >= 20 Then
                    LabelFormat(32) = "A790,320,1,3,3,2,N," + Chr(34) + PartNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + " REV. " + TFPBlueprintRevision + Chr(34)
                    LabelFormat(43) = "B717,100,1,3,2,4,102,N," + Chr(34) + "P" + PartNumber + " REV. " + TFPBlueprintRevision + Chr(34)
                Else
                    LabelFormat(32) = "A790,320,1,3,3,2,N," + Chr(34) + PartNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + " REV. " + TFPBlueprintRevision + Chr(34)
                    LabelFormat(43) = "B717,320,1,3,2,4,102,N," + Chr(34) + "P" + PartNumber + " REV. " + TFPBlueprintRevision + Chr(34)
                End If
            Else
                If PartNumber.Length >= 20 Then
                    LabelFormat(32) = "A790,320,1,3,3,2,N," + Chr(34) + PartNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
                    LabelFormat(43) = "B717,100,1,3,2,4,102,N," + Chr(34) + "P" + PartNumber + Chr(34)
                Else
                    LabelFormat(32) = "A790,320,1,4,3,2,N," + Chr(34) + PartNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
                    LabelFormat(43) = "B717,320,1,3,2,4,102,N," + Chr(34) + "P" + PartNumber + Chr(34)
                End If
            End If
        Else
            If PartNumber.Length >= 20 Then
                LabelFormat(32) = "A790,320,1,3,3,2,N," + Chr(34) + PartNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
                LabelFormat(43) = "B717,100,1,3,2,4,102,N," + Chr(34) + "P" + PartNumber + Chr(34)
            Else
                LabelFormat(32) = "A790,320,1,4,3,2,N," + Chr(34) + PartNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
                LabelFormat(43) = "B717,320,1,3,2,4,102,N," + Chr(34) + "P" + PartNumber + Chr(34)
            End If
        End If

        LabelFormat(44) = "B520,81,1,3,2,4,102,N," + Chr(34) + "Q" + strBoxCount + Chr(34)
        LabelFormat(45) = "B319,50,1,3,2,4,102,N," + Chr(34) + "W" + strBoxWeight + Chr(34)
        LabelFormat(46) = "B140,231,1,3,2,4,102,N," + Chr(34) + "S" + LotNumber + Chr(34)

        If Not String.IsNullOrEmpty(PartNumber) Then
            If LotDivision = "TFP" Then
                LabelFormat(48) = "A282,816,1,3,1,1,N," + Chr(34) + "ESR REPORT" + Chr(34)
                LabelFormat(49) = "A170,1050,1,4,2,1,N," + Chr(34) + TFPShift + Chr(34)
                LabelFormat(50) = "A255,825,1,4,2,2,N," + Chr(34) + "" + Chr(34)
            Else
                If PartNumber.StartsWith("DBA") Or PartNumber.StartsWith("CA") Or PartNumber.StartsWith("SC") Or PartNumber.StartsWith("DSC") Or PartNumber.StartsWith("PSR") Then
                    LabelFormat(48) = "A282,816,1,3,1,1,N," + Chr(34) + "ESR REPORT" + Chr(34)
                    LabelFormat(49) = "A170,1050,1,4,2,1,N," + Chr(34) + TFPShift + Chr(34)
                    LabelFormat(50) = "A255,825,1,4,2,2,N," + Chr(34) + ESRNumber + Chr(34)
                End If
            End If
        End If

        'Print Label
        LabelFormat(51) = "P" + labels.ToString()
        LabelFormat(52) = vbFormFeed
        LabelLines = 51

        'Clear Variables after label prints
        LotNumber = ""
        PartNumber = ""
        HeatNumber = ""
        BoxWeight = 0
        BoxCount = 0
        PalletPieces = 0
        ShortDescription = ""
        CustomerPO = ""
        ESRNumber = ""
        CountryOfOrigin = ""
        TFPShift = ""
    End Sub

    Public Sub SetupAndCreateMixedLoadLabel(ByVal labels As Integer)
        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill in Verbiage

        LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(14) = "A641,195,1,5,4,3,N," + Chr(34) + "MIXED" + Chr(34)
        LabelFormat(15) = "A374,540,1,5,4,3,N," + Chr(34) + "LOAD" + Chr(34)

        'Print Label

        LabelFormat(16) = "P" + labels.ToString()
        LabelFormat(17) = vbFormFeed
        LabelLines = 16
    End Sub

    Public Sub SetupAndCreateMixedHeatLabel(ByVal labels As Integer)
        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill In Verbiage

        LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(14) = "A641,150,1,5,4,3,N," + Chr(34) + "MIXED" + Chr(34)
        LabelFormat(15) = "A374,150,1,5,4,3,N," + Chr(34) + "HEAT" + Chr(34)
        LabelFormat(16) = "A375,600,1,1,4,3,N," + Chr(34) + "QUANTITY" + Chr(34)
        LabelFormat(17) = "LO325,850,5,250"
        LabelFormat(18) = "A275,600,1,1,4,3,N," + Chr(34) + "LOT #" + Chr(34)
        LabelFormat(19) = "LO225,850,5,250"
        LabelFormat(20) = "A175,600,1,1,4,3,N," + Chr(34) + "HEAT #" + Chr(34)
        LabelFormat(21) = "LO125,850,5,250"

        'Print Label
        LabelFormat(22) = "P" + labels.ToString()
        LabelFormat(23) = vbFormFeed
        LabelLines = 22
    End Sub

    Public Sub SetupAndCreateShippingAddressLabel(ByVal labels As Integer)
        Dim ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZipCode, ShipToCustomerName As String
        Dim ShipToAddressBar As String = ""
        Dim ShipToCountry As String = ""
        Dim DefaultReturnAddress As String = ""

        ShipToCustomerName = cboCustomerName05.Text
        ShipToAddress1 = txtAddress105.Text
        ShipToAddress2 = txtAddress205.Text
        ShipToCity = txtCity05.Text
        ShipToState = txtState05.Text
        ShipToZipCode = txtZipCode05.Text
        ShipToCountry = txtShipToCountry05.Text

        If cboDivisionID05.Text = "ATL" Then
            DefaultReturnAddress = "TFP OF ATLANTA, ATLANTA, GA (1-800-727-7883)"
        ElseIf cboDivisionID05.Text = "CBS" Then
            DefaultReturnAddress = "TFP OF NEVADA, LAS VEGAS, NV (702-737-7940)"
        ElseIf cboDivisionID05.Text = "CGO" Then
            DefaultReturnAddress = "TFP OF INDIANA, GRFFITH, IN (219-513-9572)"
        ElseIf cboDivisionID05.Text = "CHT" Then
            DefaultReturnAddress = "WELDING CERAMICS, CHARTTANOOGA, TN (423-752-57450)"
        ElseIf cboDivisionID05.Text = "DEN" Then
            DefaultReturnAddress = "TFP OF DENVER, DENVER, CO (303-945-2030)"
        ElseIf cboDivisionID05.Text = "HOU" Then
            DefaultReturnAddress = "TFP OF HOUSTON, HOUSTON, TX (281-598-2330)"
        ElseIf cboDivisionID05.Text = "SLC" Then
            DefaultReturnAddress = "TFP OF UTAH, WEST JORDAN, UT (801-280-6611)"
        ElseIf cboDivisionID05.Text = "TFF" Then
            DefaultReturnAddress = "TRUFIT FASTENERS, SURREY, BC (778-298-1094)"
        ElseIf cboDivisionID05.Text = "TFT" Then
            DefaultReturnAddress = "TFP OF TEXAS, IRVING, TX (972-986-6368)"
        ElseIf cboDivisionID05.Text = "TOR" Then
            DefaultReturnAddress = "TFP OF TORONTO, HAMILTON, ONT (905-547-4076)"
        ElseIf cboDivisionID05.Text = "TWE" Then
            DefaultReturnAddress = "TRUWELD EQUIPMENT, SMITHVILLE OHIO (330-725-7744)"
        Else
            DefaultReturnAddress = "TFP CORPORATION, MEDINA OHIO (330-725-7741)"
        End If

        If ShipToCountry = "US" Then
            ShipToCountry = "UNITED STATES"
        ElseIf ShipToCountry = "CA" Then
            ShipToCountry = "CANADA"
        Else
            'Skip
        End If

        ShipToAddressBar = ShipToCity + ", " + ShipToState + " " + ShipToZipCode

        'Validate for illegal characters
        ShipToCustomerName.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper()
        ShipToAddress1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper()
        ShipToAddress2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper()
        ShipToCity.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper()
        ShipToZipCode.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper()

        'Validate for string length
        If ShipToCustomerName.Length > 32 Then
            ShipToCustomerName = ShipToCustomerName.Substring(0, 32)
        End If
        If ShipToAddress1.Length > 32 Then
            ShipToAddress1 = ShipToAddress1.Substring(0, 32)
        End If
        If ShipToAddress2.Length > 32 Then
            ShipToAddress2 = ShipToAddress2.Substring(0, 32)
        End If
        If ShipToAddressBar.Length > 32 Then
            ShipToAddressBar = ShipToAddressBar.Substring(0, 32)
        End If

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes
        LabelFormat(8) = "LO60,900,1,100"
        LabelFormat(9) = "LO60,950,1,100"

        'Fill in Verbiage
        LabelFormat(10) = "A35,10,1,3,1,1,N," + Chr(34) + DefaultReturnAddress + Chr(34)
        LabelFormat(11) = "A662,40,1,5,2,1,N," + Chr(34) + ShipToCustomerName + Chr(34)
        LabelFormat(12) = "A554,40,1,5,2,1,N," + Chr(34) + ShipToAddress1 + Chr(34)
        LabelFormat(13) = "A432,40,1,5,2,1,N," + Chr(34) + ShipToAddress2 + Chr(34)
        LabelFormat(14) = "A323,40,1,5,2,1,N," + Chr(34) + ShipToAddressBar + Chr(34)
        LabelFormat(15) = "A223,40,1,5,2,1,N," + Chr(34) + ShipToCountry + Chr(34)
        LabelFormat(16) = "A100,700,1,4,2,1,N," + Chr(34) + "PALLET        OF" + Chr(34)

        'Print Label
        LabelFormat(17) = "P" + labels.ToString()
        LabelFormat(18) = vbFormFeed
        LabelLines = 17
    End Sub

    Public Sub SetupAndCreateShippingByPickTicketLabel(ByVal labels As Integer)
        Dim ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZipCode, ShipToCustomerName As String
        Dim ShipToAddressBar As String = ""
        Dim ShipToCountry As String = ""
        Dim DefaultReturnAddress As String = ""

        ShipToCustomerName = txtCustomerName06.Text
        ShipToAddress1 = txtAddress106.Text
        ShipToAddress2 = txtAddress206.Text
        ShipToCity = txtCity06.Text
        ShipToState = txtState06.Text
        ShipToZipCode = txtZipCode06.Text
        ShipToCountry = txtShipToCountry06.Text

        If cboDivisionID06.Text = "ATL" Then
            DefaultReturnAddress = "TFP OF ATLANTA, ATLANTA, GA (1-800-727-7883)"
        ElseIf cboDivisionID06.Text = "CBS" Then
            DefaultReturnAddress = "TFP OF NEVADA, LAS VEGAS, NV (702-737-7940)"
        ElseIf cboDivisionID06.Text = "CGO" Then
            DefaultReturnAddress = "TFP OF INDIANA, GRFFITH, IN (219-513-9572)"
        ElseIf cboDivisionID06.Text = "CHT" Then
            DefaultReturnAddress = "WELDING CERAMICS, CHARTTANOOGA, TN (423-752-57450)"
        ElseIf cboDivisionID06.Text = "DEN" Then
            DefaultReturnAddress = "TFP OF DENVER, DENVER, CO (303-945-2030)"
        ElseIf cboDivisionID06.Text = "HOU" Then
            DefaultReturnAddress = "TFP OF HOUSTON, HOUSTON, TX (281-598-2330)"
        ElseIf cboDivisionID06.Text = "SLC" Then
            DefaultReturnAddress = "TFP OF UTAH, WEST JORDAN, UT (801-280-6611)"
        ElseIf cboDivisionID06.Text = "TFF" Then
            DefaultReturnAddress = "TRUFIT FASTENERS, SURREY, BC (778-298-1094)"
        ElseIf cboDivisionID06.Text = "TFT" Then
            DefaultReturnAddress = "TFP OF TEXAS, IRVING, TX (972-986-6368)"
        ElseIf cboDivisionID06.Text = "TOR" Then
            DefaultReturnAddress = "TFP OF TORONTO, HAMILTON, ONT (905-547-4076)"
        ElseIf cboDivisionID06.Text = "TWE" Then
            DefaultReturnAddress = "TRUWELD EQUIPMENT, SMITHVILLE OHIO (330-725-7744)"
        Else
            DefaultReturnAddress = "TFP CORPORATION, MEDINA OHIO (330-725-7741)"
        End If

        If ShipToCountry = "US" Then
            ShipToCountry = "UNITED STATES"
        ElseIf ShipToCountry = "CA" Then
            ShipToCountry = "CANADA"
        Else
            'Skip
        End If

        ShipToAddressBar = ShipToCity + ", " + ShipToState + " " + ShipToZipCode

        'Validate for illegal characters
        ShipToCustomerName.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper()
        ShipToAddress1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper()
        ShipToAddress2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper()
        ShipToCity.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper()
        ShipToZipCode.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'").ToUpper()

        'Validate for string length
        If ShipToCustomerName.Length > 32 Then
            ShipToCustomerName = ShipToCustomerName.Substring(0, 32)
        End If
        If ShipToAddress1.Length > 32 Then
            ShipToAddress1 = ShipToAddress1.Substring(0, 32)
        End If
        If ShipToAddress2.Length > 32 Then
            ShipToAddress2 = ShipToAddress2.Substring(0, 32)
        End If
        If ShipToAddressBar.Length > 32 Then
            ShipToAddressBar = ShipToAddressBar.Substring(0, 32)
        End If

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes
        LabelFormat(8) = "LO60,900,1,100"
        LabelFormat(9) = "LO60,950,1,100"

        'Fill in Verbiage
        LabelFormat(10) = "A35,10,1,3,1,1,N," + Chr(34) + DefaultReturnAddress + Chr(34)
        LabelFormat(11) = "A662,40,1,5,2,1,N," + Chr(34) + ShipToCustomerName + Chr(34)
        LabelFormat(12) = "A554,40,1,5,2,1,N," + Chr(34) + ShipToAddress1 + Chr(34)
        LabelFormat(13) = "A432,40,1,5,2,1,N," + Chr(34) + ShipToAddress2 + Chr(34)
        LabelFormat(14) = "A323,40,1,5,2,1,N," + Chr(34) + ShipToAddressBar + Chr(34)
        LabelFormat(15) = "A223,40,1,5,2,1,N," + Chr(34) + ShipToCountry + Chr(34)
        LabelFormat(16) = "A100,700,1,4,2,1,N," + Chr(34) + "PALLET        OF" + Chr(34)

        'Print Label
        LabelFormat(17) = "P" + Labels.ToString()
        LabelFormat(18) = vbFormFeed
        LabelLines = 17
    End Sub

    Public Sub SetupAndCreateTubTag(ByVal labels As Integer)
        Dim LotNumber, CustomerID, FOXNumber, BlueprintNumber, PartNumber, ShortDescription, PromiseDate, SteelCarbon, SteelSize, HeatNumber, AnnealedHeatNumber As String
        Dim ProductionQuantity, FinishedWeight, TotalWeight As String
        Dim cutLength As Integer = 27

        LotNumber = txtLotNumber07.Text
        CustomerID = txtCustomerID07.Text
        FOXNumber = txtFOXNumber07.Text
        BlueprintNumber = txtBlueprint07.Text
        PartNumber = txtPartNumber07.Text
        ShortDescription = txtShortDescription07.Text
        PromiseDate = txtPromiseDate07.Text
        ProductionQuantity = txtProductionQuantity07.Text
        FinishedWeight = txtFinishWeight07.Text
        TotalWeight = txtTotalWeight07.Text
        SteelCarbon = txtSteelCarbon07.Text
        SteelSize = txtSteelSize07.Text
        HeatNumber = txtHeatNumber07.Text
        AnnealedHeatNumber = txtAnnealingLotNumber07.Text

        'Split short description into two lines if necessay
        If ShortDescription.Length > cutLength Then
            V04 = ShortDescription.Substring(0, cutLength)
            If ShortDescription.Length > cutLength * 2 Then
                If ShortDescription.Length > cutLength * 3 Then
                    V06 = ShortDescription.Substring(cutLength * 3, cutLength)
                Else
                    V06 = ShortDescription.Substring(cutLength * 2, ShortDescription.Length - cutLength)
                End If
                V05 = ShortDescription.Substring(cutLength, cutLength)
            Else
                V05 = ShortDescription.Substring(cutLength, ShortDescription.Length - cutLength)
                V06 = ""
            End If
        Else
            V04 = ShortDescription
            V05 = ""
            V06 = ""
        End If

        'Setup Label
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q800"
        LabelFormat(2) = "Q1200,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D10"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"
        LabelFormat(8) = "A275,10,0,5,1,1,N," + Chr(34) + "TUB TAG" + Chr(34)
        LabelFormat(9) = "B235,65,0,3,2,4,102,B," + Chr(34) + "S" + LotNumber + Chr(34)
        LabelFormat(10) = "LO10,195,790,3"
        LabelFormat(11) = "LO400,198,3,990"
        LabelFormat(12) = "A15,198,0,2,1,1,N," + Chr(34) + "Customer" + Chr(34)
        LabelFormat(13) = "A15,225,0,2,1,2,N," + Chr(34) + CustomerID + Chr(34)
        LabelFormat(14) = "A410,198,0,2,1,1,N," + Chr(34) + "Sign-off" + Chr(34)
        LabelFormat(15) = "A605,198,0,2,1,1,N," + Chr(34) + "Routing" + Chr(34)
        LabelFormat(16) = "A15,0275,0,3,1,1,N," + Chr(34) + "Fox" + Chr(34)
        LabelFormat(17) = "A15,300,0,3,2,2,N," + Chr(34) + FOXNumber + Chr(34)
        LabelFormat(18) = "A195,275,0,3,1,1,N," + Chr(34) + "Blueprint No." + Chr(34)
        LabelFormat(19) = "A195,300,0,3,2,2,N," + Chr(34) + BlueprintNumber + Chr(34)
        LabelFormat(20) = "A15,350,0,3,1,1,N," + Chr(34) + "Part Number" + Chr(34)
        LabelFormat(21) = "A15,375,0,3,1,2,N," + Chr(34) + PartNumber + Chr(34)
        LabelFormat(22) = "A15,410,0,3,1,2,N," + Chr(34) + V04 + Chr(34)
        LabelFormat(23) = "A15,445,0,3,1,2,N," + Chr(34) + V05 + Chr(34)
        LabelFormat(24) = "A15,530,0,3,1,1,N," + Chr(34) + "Promised" + Chr(34)
        LabelFormat(25) = "A185,520,0,3,1,2,N," + Chr(34) + PromiseDate + Chr(34)
        LabelFormat(26) = "A15,590,0,3,1,1,N," + Chr(34) + "Quantity" + Chr(34)
        LabelFormat(27) = "A185,580,0,3,1,2,N," + Chr(34) + ProductionQuantity + Chr(34)
        LabelFormat(28) = "A15,650,0,3,1,1,N," + Chr(34) + "Fin Wt./M" + Chr(34)
        LabelFormat(29) = "A185,640,0,3,1,2,N," + Chr(34) + FinishedWeight + Chr(34)
        LabelFormat(30) = "A15,710,0,3,1,1,N," + Chr(34) + "Total Wt." + Chr(34)
        LabelFormat(31) = "A185,700,0,3,1,2,N," + Chr(34) + TotalWeight + Chr(34)
        LabelFormat(32) = "A15,750,0,3,1,1,N," + Chr(34) + "Raw Carbon" + Chr(34)
        LabelFormat(33) = "A15,775,0,3,2,3,N," + Chr(34) + SteelCarbon + Chr(34)
        LabelFormat(34) = "A245,750,0,3,1,1,N," + Chr(34) + "Raw Size" + Chr(34)
        LabelFormat(35) = "A235,775,0,3,2,3,N," + Chr(34) + SteelSize + Chr(34)
        LabelFormat(36) = "A15,850,0,3,1,1,N," + Chr(34) + "Heat Number" + Chr(34)
        LabelFormat(37) = "A185,850,0,3,1,2,N," + Chr(34) + HeatNumber + Chr(34)
        LabelFormat(38) = "A15,925,0,3,1,1,N," + Chr(34) + "Ann. Lot No." + Chr(34)
        LabelFormat(39) = "A185,925,0,3,1,2,N," + Chr(34) + AnnealedHeatNumber + Chr(34)
        LabelFormat(40) = "A155,1000,0,4,1,2,N," + Chr(34) + "DATE" + Chr(34)
        LabelFormat(41) = "A141,1050,0,4,1,2,N," + Chr(34) + "SHIFT" + Chr(34)
        LabelFormat(42) = "A45,1100,0,4,1,2,N," + Chr(34) + "Pcs. in Tub" + Chr(34)
        LabelFormat(43) = "LO255,1035,100,2"
        LabelFormat(44) = "LO255,1085,100,2"
        LabelFormat(45) = "LO255,1135,100,2"
        LabelFormat(46) = "A75,1170,0,3,1,2,N," + Chr(34) + "Keep this tag with the parts through shipping" + Chr(34)

        'Print Label
        LabelFormat(47) = "P" + labels.ToString()
        LabelFormat(48) = vbFormFeed
        LabelLines = 47
    End Sub

    Public Sub SetupAndCreateBinLabel(ByVal labels As Integer)
        'Standard 4x6 AIAG Label setup
        Dim Location1 As String = ""
        Dim Location2 As String = ""

        Location1 = txtRackNumber108.Text
        Location2 = txtRackNumber208.Text

        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q800"
        LabelFormat(2) = "Q1200,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Fill in Verbiage
        LabelFormat(8) = "A300,10,1,4,9,4,N," + Chr(34) + Location1 + Chr(34)
        LabelFormat(9) = "A700,10,1,4,9,4,N," + Chr(34) + Location2 + Chr(34)

        'Print Barcodes
        LabelFormat(10) = "B300,600,1,3,5,10,200,N," + Chr(34) + Location1 + Chr(34)
        LabelFormat(11) = "B700,600,1,3,5,10,200,N," + Chr(34) + Location2 + Chr(34)

        'Print Label
        LabelFormat(12) = "P" + labels.ToString()
        LabelFormat(13) = vbFormFeed
        LabelLines = 12
    End Sub

    Public Sub SetupAndCreatePalletBinLabel(ByVal labels As Integer)
        'Standard 4x6 AIAG Label setup
        Dim Location1 As String = ""
        Location1 = txtRackNumber09.Text

        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q800"
        LabelFormat(2) = "Q1200,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Fill in Verbiage
        LabelFormat(8) = "A750,150,1,5,5,5,N," + Chr(34) + Location1 + Chr(34)

        'Print Barcodes
        LabelFormat(9) = "B450,200,1,3,5,20,400,N," + Chr(34) + Location1 + Chr(34)

        'Print Label
        LabelFormat(10) = "P" + labels.ToString()
        LabelFormat(11) = vbFormFeed
        LabelLines = 10
    End Sub

    Public Sub SetupAndCreateFryerLabel(ByVal labels As Integer)
        Dim LotNumber, PartNumber, ShortDescription, RevisionLevel, CustomerPO, SupplierNumber, strQuantity As String
        Dim Quantity As Double = 0
        Dim LotDivision As String = ""

        LotNumber = txtLotNumber10.Text
        PartNumber = txtPartNumber10.Text
        ShortDescription = txtShortDescription10.Text
        RevisionLevel = txtRevisionLevel10.Text
        CustomerPO = txtCustomerPO10.Text
        SupplierNumber = txtSupplierNumber10.Text
        Quantity = Val(txtQuantity10.Text)
        Quantity = Math.Round(Quantity, 0)
        strQuantity = CStr(Quantity)

        'Get Division from the Lot Number
        Dim GetDivisionFromLotStatement As String = "SELECT DivisionID FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetDivisionFromLotCommand As New SqlCommand(GetDivisionFromLotStatement, con)
        GetDivisionFromLotCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber02.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LotDivision = CStr(GetDivisionFromLotCommand.ExecuteScalar)
        Catch ex As Exception
            LotDivision = ""
        End Try
        con.Close()

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        LabelFormat(25) = "A790,750,1,1,1,1,N," + Chr(34) + "PURCHASE ORDER NO." + Chr(34)
        LabelFormat(16) = "A780,24,1,1,1,1,N," + Chr(34) + "FROM:" + Chr(34)
        LabelFormat(21) = "A780,350,1,1,1,1,N," + Chr(34) + "TO:" + Chr(34)
        LabelFormat(26) = "A770,750,1,1,1,1,N," + Chr(34) + "(K)" + Chr(34)
        LabelFormat(46) = "A770,810,1,4,2,1,N," + Chr(34) + CustomerPO + Chr(34)
        LabelFormat(17) = "A760,24,1,1,1,1,N," + Chr(34) + "SPECTRA PREMIUM MOBILITY" + Chr(34)
        LabelFormat(22) = "A760,350,1,1,1,1,N," + Chr(34) + "SPECTRA PREMIUM MOBILITY SOLUTION" + Chr(34)
        LabelFormat(18) = "A740,24,1,1,1,1,N," + Chr(34) + "1421 AMPERE STREET" + Chr(34)
        LabelFormat(23) = "A740,350,1,1,1,1,N," + Chr(34) + "1431 AMPERE STREET" + Chr(34)
        LabelFormat(19) = "A720,24,1,1,1,1,N," + Chr(34) + "BOUCHERVILLE, QC  J4B 5Z5" + Chr(34)
        LabelFormat(24) = "A720,350,1,1,1,1,N," + Chr(34) + "BOUCHERVILLE, QC J4B 5Z5" + Chr(34)
        LabelFormat(54) = "B720,790,1,3,2,4,60,N," + Chr(34) + "K" + CustomerPO + Chr(34)
        LabelFormat(20) = "A700,24,1,1,1,1,N," + Chr(34) + "TEL:(514)-210-5207" + Chr(34)
        LabelFormat(11) = "LO650,20,1,1190"
        LabelFormat(12) = "LO650,334,148,1"
        LabelFormat(13) = "LO650,737,148,1"
        LabelFormat(27) = "A640,20,1,1,1,1,N," + Chr(34) + "PART NO." + Chr(34)

        If LotDivision = "TFP" Then
            If Not PartNumber.ToUpper.Contains("REV. ") And Not PartNumber.ToUpper.Contains("REV ") Then
                LabelFormat(41) = "A640,180,1,4,2,1,N," + Chr(34) + PartNumber + " REV. " + RevisionLevel + Chr(34)
                LabelFormat(50) = "B580,100,1,3,2,4,60,N," + Chr(34) + "P" + PartNumber + " REV. " + RevisionLevel + Chr(34)
            Else
                LabelFormat(41) = "A640,180,1,4,2,1,N," + Chr(34) + PartNumber + Chr(34)
                LabelFormat(50) = "B580,100,1,3,2,4,60,N," + Chr(34) + "P" + PartNumber + Chr(34)
            End If
        Else
            LabelFormat(41) = "A640,180,1,4,2,1,N," + Chr(34) + PartNumber + Chr(34)
            LabelFormat(50) = "B580,100,1,3,2,4,60,N," + Chr(34) + "P" + PartNumber + Chr(34)
        End If

        LabelFormat(28) = "A620,20,1,1,1,1,N," + Chr(34) + "(P)" + Chr(34)

        LabelFormat(31) = "A510,20,1,1,1,1,N," + Chr(34) + "PART DESCRIPTION:" + Chr(34)
        LabelFormat(40) = "A510,1000,1,1,1,1,N," + Chr(34) + "PART REV LEVEL" + Chr(34)
        LabelFormat(42) = "A490,180,1,4,2,1,N," + Chr(34) + ShortDescription + Chr(34)
        LabelFormat(49) = "A490,1050,1,4,2,1,N," + Chr(34) + RevisionLevel + Chr(34)
        LabelFormat(10) = "LO440,20,1,1190"
        LabelFormat(29) = "A430,20,1,1,1,1,N," + Chr(34) + "MFG LOT NO." + Chr(34)
        LabelFormat(43) = "A435,180,1,4,2,1,N," + Chr(34) + LotNumber + Chr(34)
        LabelFormat(47) = "A435,800,1,4,2,1,N," + Chr(34) + SupplierNumber + Chr(34)
        LabelFormat(36) = "A430,660,1,1,1,1,N," + Chr(34) + "SUPPLIER CODE" + Chr(34)
        LabelFormat(30) = "A410,20,1,1,1,1,N," + Chr(34) + "(T)" + Chr(34)
        LabelFormat(37) = "A410,660,1,1,1,1,N," + Chr(34) + "(V)" + Chr(34)
        LabelFormat(51) = "B390,100,1,3,2,4,80,N," + Chr(34) + "T" + LotNumber + Chr(34)
        LabelFormat(55) = "B385,700,1,3,2,4,60,N," + Chr(34) + "V" + SupplierNumber + Chr(34)
        LabelFormat(15) = "LO320,650,1,560"
        LabelFormat(38) = "A310,660,1,1,1,1,N," + Chr(34) + "SERIAL NO." + Chr(34)
        LabelFormat(9) = "LO300,20,1,630"
        LabelFormat(32) = "A290,20,1,1,1,1,N," + Chr(34) + "QTY" + Chr(34)
        LabelFormat(44) = "A290,180,1,4,2,1,N," + Chr(34) + strQuantity + Chr(34)
        LabelFormat(39) = "A290,660,1,1,1,1,N," + Chr(34) + "(S)" + Chr(34)
        LabelFormat(48) = "A290,800,1,4,2,1,N," + Chr(34) + LotNumber + Chr(34)
        LabelFormat(33) = "A270,20,1,1,1,1,N," + Chr(34) + "(Q)" + Chr(34)
        LabelFormat(52) = "B240,100,1,3,2,4,80,N," + Chr(34) + "Q" + strQuantity + Chr(34)
        LabelFormat(56) = "B240,700,1,3,2,4,80,N," + Chr(34) + "S" + LotNumber + Chr(34)
        LabelFormat(8) = "LO150,20,1,1190"
        LabelFormat(14) = "LO150,650,290,1"
        LabelFormat(34) = "A145,20,1,1,1,1,N," + Chr(34) + "SUPPLIER CODE/SERIAL NO." + Chr(34)
        LabelFormat(35) = "A120,20,1,1,1,1,N," + Chr(34) + "(3S)" + Chr(34)
        LabelFormat(45) = "A130,180,1,4,2,1,N," + Chr(34) + LotNumber + Chr(34)
        LabelFormat(53) = "B80,100,1,3,2,4,60,N," + Chr(34) + "3S" + LotNumber + Chr(34)

        'Print Label
        LabelFormat(57) = "P" + labels.ToString()
        LabelFormat(58) = vbFormFeed
        LabelLines = 57
    End Sub

    Private Sub SetupAndCreateSpecialLabel()
        txtBlankLineOne15.Text = SpecialLabelLine1
        txtBlankLineTwo15.Text = SpecialLabelLine2
        txtBlankLineThree15.Text = SpecialLabelLine3

        'blank3LineLabelPrint()
    End Sub

    Public Sub SetupAndCreateOptimasLabel(ByVal labels As Integer)
        Dim LotNumber, PartNumber, ShortDescription, CustomerPO, POLineNumber, CountryOfOrigin As String
        Dim Quantity As Double = 0
        Dim strQuantity As String = ""
        Dim ShipDate As Date
        Dim strShipDate As String = ""

        LotNumber = txtLotNumber11.Text
        PartNumber = txtPartNumber11.Text
        ShortDescription = txtShortDescription11.Text
        CustomerPO = txtCustomerPO11.Text
        POLineNumber = txtPOLineNumber11.Text
        CountryOfOrigin = txtCOO11.Text
        ShipDate = dtpShipDate11.Value
        strShipDate = ShipDate.ToShortDateString()
        Quantity = Val(txtQuantity11.Text)
        Quantity = Math.Round(Quantity, 0)
        strQuantity = CStr(Quantity)

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Boxes (Horizontal Lines)
        LabelFormat(8) = "LO640,0,5,1210"
        LabelFormat(9) = "LO480,0,5,1210"
        LabelFormat(10) = "LO320,0,5,1210"
        LabelFormat(11) = "LO160,0,5,1210"

        'Print Boxes - vertical lines
        LabelFormat(12) = "LO000,900,160,5"
        LabelFormat(13) = "LO160,900,160,5"
        LabelFormat(14) = "LO320,800,160,5"

        'Fill in stationary fields
        LabelFormat(15) = "A780,10,1,3,2,1,N," & Chr(34) & "PART" & Chr(34)
        LabelFormat(16) = "A620,10,1,3,2,1,N," & Chr(34) & "LOT" & Chr(34)
        LabelFormat(17) = "A460,10,1,3,1,1,N," & Chr(34) & "DESC" & Chr(34)
        LabelFormat(18) = "A380,10,1,3,1,1,N," & Chr(34) & "SUPPLIER" & Chr(34)
        LabelFormat(19) = "A460,810,1,3,1,1,N," & Chr(34) & "QTY" & Chr(34)
        LabelFormat(20) = "A310,10,1,3,1,1,N," & Chr(34) & "PO" & Chr(34)
        LabelFormat(21) = "A310,910,1,3,1,1,N," & Chr(34) & "PO LINE" & Chr(34)
        LabelFormat(22) = "A220,910,1,3,1,1,N," & Chr(34) & "SHIP DATE" & Chr(34)
        LabelFormat(23) = "A140,910,1,3,1,1,N," & Chr(34) & "COO" & Chr(34)

        'Fill in variable fields
        LabelFormat(24) = "A780,160,1,2,5,2,N," & Chr(34) & PartNumber & Chr(34)
        LabelFormat(25) = "A620,160,1,2,5,2,N," & Chr(34) & LotNumber & Chr(34)
        LabelFormat(26) = "A460,160,1,3,2,1,N," & Chr(34) & ShortDescription & Chr(34)
        LabelFormat(27) = "A380,160,1,3,2,1,N," & Chr(34) & "TRUFIT PRODUCTS DIVISION" & Chr(34)
        LabelFormat(28) = "A460,920,1,3,2,2,N," & Chr(34) & strQuantity & Chr(34)
        LabelFormat(29) = "A310,160,1,3,2,2,N," & Chr(34) & CustomerPO & Chr(34)
        LabelFormat(30) = "A310,1060,1,3,2,1,N," & Chr(34) & POLineNumber & Chr(34)
        LabelFormat(31) = "A220,1060,1,3,2,1,N," & Chr(34) & strShipDate & Chr(34)
        LabelFormat(32) = "A140,1060,1,3,2,2,N," & Chr(34) & CountryOfOrigin & Chr(34)

        'Fill in barcode fields
        LabelFormat(33) = "B700,160,1,3,2,4,40,N," & Chr(34) & PartNumber & Chr(34)
        LabelFormat(34) = "B540,160,1,3,2,4,40,N," & Chr(34) & LotNumber & Chr(34)
        LabelFormat(35) = "B230,160,1,3,2,4,40,N," & Chr(34) & CustomerPO & Chr(34)
        LabelFormat(36) = "B380,920,1,3,2,4,40,N," & Chr(34) & strQuantity & Chr(34)
        LabelFormat(37) = "B060,1000,1,3,2,4,40,N," & Chr(34) & CountryOfOrigin & Chr(34)
        'LabelFormat(38) = "b80,100,P,400,300,p40,440,20,f1,x3,y10,r60,15" & Chr(34) & "Optimas Label" & Chr(34)

        'Print Label
        LabelFormat(38) = "P" + labels.ToString()
        LabelFormat(39) = vbFormFeed
        LabelLines = 39
    End Sub

    Public Sub SetupAndCreateCoilLabel(ByVal labels As Integer)
        Dim CoilID As String = cboScanEntry12.Text
        Dim CoilSteelCarbon As String = txtSteelCarbon12.Text
        Dim CoilSteelSize As String = txtSteelSize12.Text
        Dim CoilWeight As String = txtWeight12.Text
        Dim CoilHeatNumber As String = txtHeatNumber12.Text
        Dim CoilAnnealedLotNumber As String = txtAnnealedLotNumber12.Text
        Dim TodaysDate As Date = Now

        TodaysDate = TodaysDate.ToShortDateString

        NumberOfLabels = nbrLabelCount.Value

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q800"
        LabelFormat(2) = "Q1200,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        LabelFormat(8) = "A250,40,0,3,2,3,N," + Chr(34) + CoilID + Chr(34)
        LabelFormat(9) = "A800,175,1,3,4,3,N," + Chr(34) + CoilID + Chr(34)
        LabelFormat(10) = "B720,300,1,3,2,4,102,N," + Chr(34) + CoilID + Chr(34)
        LabelFormat(11) = "A590,175,1,2,4,3,N," + Chr(34) + "Carbon - " + CoilSteelCarbon + Chr(34)
        LabelFormat(12) = "A520,175,1,2,4,3,N," + Chr(34) + "Steel Size - " + CoilSteelSize + Chr(34)
        LabelFormat(13) = "A450,175,1,2,4,3,N," + Chr(34) + "Heat - " + CoilHeatNumber + Chr(34)
        LabelFormat(14) = "A380,175,1,2,4,3,N," + Chr(34) + "Weight - " + CoilWeight + Chr(34)
        LabelFormat(15) = "A310,175,1,2,4,3,N," + Chr(34) + "Lot - " + CoilAnnealedLotNumber + Chr(34)
        LabelFormat(16) = "A240,75,1,2,3,3,N," + Chr(34) + "Date Created - " + TodaysDate + Chr(34)
        LabelFormat(17) = "A25,100,1,2,1,1,N," + Chr(34) + "TFP CORP. MEDINA, OH. 44256 (330) 725-7741" + Chr(34)
        LabelFormat(18) = "A250,1130,0,3,2,3,N," + Chr(34) + CoilID + Chr(34)
        LabelFormat(19) = "B250,1030,0,3,2,3,75,N," + Chr(34) + CoilID + Chr(34)

        'Print Label
        LabelFormat(20) = "P" + labels.ToString()
        LabelFormat(21) = vbFormFeed
        LabelLines = 20
    End Sub

    Public Sub SetupAndCreateUniversalWasteLabel(ByVal labels As Integer)
        'Standard 4x6 AIAG Label setup

        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Fill in Verbiage

        LabelFormat(8) = "A35,10,1,3,1,1,N," + Chr(34) + "TFP CORP. MEDINA, OH 44256 330-725-7741" + Chr(34)
        LabelFormat(9) = "A662,40,1,5,2,1,N," + Chr(34) + "UNIVERSAL WASTE -- LAMPS/BULBS" + Chr(34)
        LabelFormat(10) = "A450,40,1,4,2,1,N," + Chr(34) + "ACCUMULATION START DATE:" + Chr(34)
        LabelFormat(11) = "A300,40,1,4,2,1,N," + Chr(34) + "TYPE OF LAMP:" + Chr(34)
        LabelFormat(12) = "A150,40,1,4,2,1,N," + Chr(34) + "FINAL QUANTITY:" + Chr(34)

        'Print Label

        LabelFormat(13) = "P" + labels.ToString()
        LabelFormat(14) = vbFormFeed
        LabelLines = 13
    End Sub

    Public Sub SetupAndCreateFourBlankLineLabel(ByVal labels As Integer)
        Dim Line1, Line2, Line3, Line4, Line5, Line6, Line7, Line8 As String

        Line1 = txtBlank114.Text
        Line2 = txtBlank214.Text
        Line3 = txtBlank314.Text
        Line4 = txtBlank414.Text
        Line5 = txtBlank514.Text
        Line6 = txtBlank614.Text
        Line7 = txtBlank714.Text
        Line8 = txtBlank814.Text

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        LabelFormat(8) = "A800,10,1,2,4,4,N," + Chr(34) + Line1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(9) = "A700,10,1,2,4,4,N," + Chr(34) + Line2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(10) = "A600,10,1,2,4,4,N," + Chr(34) + Line3.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(11) = "A500,10,1,2,4,4,N," + Chr(34) + Line4.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(12) = "A400,10,1,2,4,4,N," + Chr(34) + Line5.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(13) = "A300,10,1,2,4,4,N," + Chr(34) + Line6.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(14) = "A200,10,1,2,4,4,N," + Chr(34) + Line7.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        LabelFormat(15) = "A100,10,1,2,4,4,N," + Chr(34) + Line8.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)

        LabelFormat(16) = "P" + labels.ToString()
        LabelFormat(17) = vbFormFeed
        LabelLines = 16
    End Sub

    Public Sub SetupAndCreateThreeBlankLineLabel(ByVal labels As Integer)
        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Dim lst As List(Of String)
        Dim lst As New List(Of String)
        lst.Add(txtBlankLineOne15.Text)
        lst.Add(txtBlankLineTwo15.Text)
        lst.Add(txtBlankLineThree15.Text)

        Dim lineCnt As Integer = 0
        Dim HorDrawPos As Integer = 775

        While lineCnt < lst.Count And HorDrawPos > 0
            lst(lineCnt) = lst(lineCnt).Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")
            Dim position As Integer = 0

            Select Case lst(lineCnt).Length
                Case Is <= 8
                    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + "," + Math.Round((1210 - (135 * lst(lineCnt).Length)) / 2, 0).ToString() + ",1,4,9,9,N," + Chr(34) + lst(lineCnt) + Chr(34)
                Case Is <= 12
                    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + "," + Math.Round((1210 - (95 * lst(lineCnt).Length)) / 2, 0).ToString() + ",1,4,9,6,N," + Chr(34) + lst(lineCnt) + Chr(34)
                Case Is <= 14
                    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + "," + Math.Round((1210 - (77 * lst(lineCnt).Length)) / 2, 0).ToString() + ",1,4,9,5,N," + Chr(34) + lst(lineCnt) + Chr(34)
                Case Is <= 18
                    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + "," + Math.Round((1210 - (61 * lst(lineCnt).Length)) / 2, 0).ToString() + ",1,4,9,4,N," + Chr(34) + lst(lineCnt) + Chr(34)
                Case Is <= 24
                    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + "," + Math.Round((1210 - (47 * lst(lineCnt).Length)) / 2, 0).ToString() + ",1,4,9,3,N," + Chr(34) + lst(lineCnt) + Chr(34)
                    'Case Is <= 21
                    '    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + ",10,1,5,4,1,N," + Chr(34) + lst(lineCnt) + Chr(34)
                    'Case Is <= 24
                    '    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + ",10,1,4,5,3,N," + Chr(34) + lst(lineCnt) + Chr(34)
                    'Case Is <= 27
                    '    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + ",10,1,4,5,2,N," + Chr(34) + lst(lineCnt) + Chr(34)
                    'Case Is <= 30
                    '    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + ",10,1,3,5,6,N," + Chr(34) + lst(lineCnt) + Chr(34)
                Case Else
                    LabelFormat(8 + lineCnt) = "A" + HorDrawPos.ToString() + ",10,1,3,5,1,N," + Chr(34) + lst(lineCnt) + Chr(34)
            End Select

            lineCnt += 1
            HorDrawPos -= 250
        End While

        LabelFormat(8 + lineCnt) = "P" + labels.ToString()
        LabelFormat(lineCnt + 9) = vbFormFeed
        LabelLines = 8 + lineCnt
    End Sub

    Public Sub SetupAndCreateAnnealingLabel(ByVal labels As Integer)
        Dim AnnealingLotNumber As String = txtAnnealedLotNumber16.Text
        Dim SteelCarbon, SteelSize, HeatNumber, TotalWeight, Base, Program, DateIn, DateOut As String
        Dim strTotalWeight As String = ""

        SteelCarbon = txtSteelCarbon16.Text
        SteelSize = txtSteelSize16.Text
        HeatNumber = txtHeatNumber16.Text
        TotalWeight = txtTotalWeight16.Text
        Base = txtBase16.Text
        Program = txtProgram16.Text
        DateIn = txtDateIn16.Text
        DateOut = txtDateOut16.Text

        strTotalWeight = CStr(TotalWeight)

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q800"
        LabelFormat(2) = "Q1200,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Fill in Verbiage

        LabelFormat(8) = "A800,175,1,3,4,3,N," + Chr(34) + "Anneal Sample Piece" + Chr(34)
        LabelFormat(9) = "A700,75,1,2,4,3,N," + Chr(34) + "Carbon - " + SteelCarbon + Chr(34)
        LabelFormat(10) = "A630,75,1,2,4,3,N," + Chr(34) + "Steel Size - " + SteelSize + Chr(34)
        LabelFormat(11) = "A560,75,1,2,4,3,N," + Chr(34) + "Heat - " + HeatNumber + Chr(34)
        LabelFormat(12) = "A490,75,1,2,4,3,N," + Chr(34) + "Total Weight Annealed - " + strTotalWeight + Chr(34)
        LabelFormat(13) = "A420,75,1,2,4,3,N," + Chr(34) + "Anneal Lot - " + AnnealingLotNumber + Chr(34)
        LabelFormat(14) = "A350,75,1,2,4,3,N," + Chr(34) + "Base - " + Base + Chr(34)
        LabelFormat(15) = "A280,75,1,2,4,3,N," + Chr(34) + "Program - " + Program + Chr(34)
        LabelFormat(16) = "A210,75,1,2,3,3,N," + Chr(34) + "Date In - " + DateIn + Chr(34)
        LabelFormat(17) = "A160,75,1,2,3,3,N," + Chr(34) + "Date Out - " + DateOut + Chr(34)
        LabelFormat(18) = "A25,100,1,2,1,1,N," + Chr(34) + "TFP CORP. MEDINA, OH. 44256 (330) 725-7741" + Chr(34)

        'Print Label
        LabelFormat(19) = "P" + labels.ToString()
        LabelFormat(20) = vbFormFeed
        LabelLines = 19
    End Sub

    Public Sub SetupAndCreateZincLabel(ByVal labels As Integer)
        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill in Verbiage

        LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(14) = "A641,195,1,5,4,3,N," + Chr(34) + "ZINC" + Chr(34)
        LabelFormat(15) = "A374,440,1,5,4,3,N," + Chr(34) + "PLATED" + Chr(34)

        'Print Label

        LabelFormat(16) = "P" + labels.ToString()
        LabelFormat(17) = vbFormFeed
        LabelLines = 16
    End Sub

    Public Sub SetupAndCreateNickelLabel(ByVal labels As Integer)
        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill in Verbiage

        LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(14) = "A641,195,1,5,4,3,N," + Chr(34) + "NICKEL" + Chr(34)
        LabelFormat(15) = "A374,440,1,5,4,3,N," + Chr(34) + "PLATED" + Chr(34)

        'Print Label

        LabelFormat(16) = "P" + labels.ToString()
        LabelFormat(17) = vbFormFeed
        LabelLines = 16
    End Sub

    Public Sub SetupAndCreateStainlessSteelLabel(ByVal labels As Integer)
        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill in Verbiage

        LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(14) = "A641,145,1,5,4,3,N," + Chr(34) + "STAINLESS" + Chr(34)
        LabelFormat(15) = "A374,540,1,5,4,3,N," + Chr(34) + "STEEL" + Chr(34)

        'Print Label

        LabelFormat(16) = "P" + labels.ToString()
        LabelFormat(17) = vbFormFeed
        LabelLines = 16
    End Sub

    Public Sub SetupAndCreatePartialPalletLabel(ByVal labels As Integer)
        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill in Verbiage

        LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(14) = "A641,195,1,5,4,3,N," + Chr(34) + "PARTIAL" + Chr(34)
        LabelFormat(15) = "A374,440,1,5,4,3,N," + Chr(34) + "PALLET" + Chr(34)

        'Print Label

        LabelFormat(16) = "P" + labels.ToString()
        LabelFormat(17) = vbFormFeed
        LabelLines = 16
    End Sub

    Public Sub SetupAndCreateCustomLabel(ByVal labels As Integer)

        'standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border

        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill in Verbiage

        'LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        'LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        'LabelFormat(14) = "A641,195,1,5,4,3,N," + Chr(34) + "NICKEL" + Chr(34)
        LabelFormat(12) = "b80,200,P,400,300,f1,x3,y10,r60,15," + Chr(34) + "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890" + Chr(34)

        'Print Label

        LabelFormat(13) = "P" + labels.ToString()
        LabelFormat(14) = vbFormFeed
        LabelLines = 30
    End Sub

    Public Sub SetupAndCreateBoxLabel()








    End Sub

    Public Sub SetupAndCreateATOPLabel(ByVal labels As Integer)
        'Define Variables from text boxes
        Dim LotNumber, PartNumber, HeatNumber, strBoxWeight, strBoxCount, strPalletPieces, ShortDescription, CustomerPO, ATLPartNumber, CustomerPartNumber As String
        Dim BoxWeight, BoxCount, PalletPieces As Double
        Dim LotDivision As String = ""
        Dim TodaysDate As Date
        Dim strTodaysDate As String = ""
        Dim ShortDescription1, ShortDescription2, ShortDescription3 As String
        Dim TFPBlueprintRevision As String = ""
        Dim TFPShift As String = ""

        LotNumber = txtLotNumber22.Text
        PartNumber = txtPartNumber22.Text
        HeatNumber = txtHeatNumber22.Text
        BoxWeight = Val(txtBoxWeight22.Text)
        BoxCount = Val(txtBoxQuantity22.Text)
        PalletPieces = Val(txtPalletPieces22.Text)
        ShortDescription = txtPartDescription22.Text
        CustomerPO = txtCustomerPO22.Text
        ATLPartNumber = txtATLPartNumber22.Text
        CustomerPartNumber = txtCustomerPartNumber22.Text

        BoxCount = Math.Round(BoxCount, 0)
        BoxWeight = Math.Round(BoxWeight, 0)
        PalletPieces = Math.Round(PalletPieces, 0)

        strBoxCount = CStr(BoxCount)
        strBoxWeight = CStr(BoxWeight)
        strPalletPieces = CStr(PalletPieces)

        'Convert Date to string
        TodaysDate = dtpATopLabel22.Value
        strTodaysDate = TodaysDate.ToShortDateString()

        'Get Division from the Lot Number
        Dim GetDivisionFromLotStatement As String = "SELECT DivisionID FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetDivisionFromLotCommand As New SqlCommand(GetDivisionFromLotStatement, con)
        GetDivisionFromLotCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = txtLotNumber22.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LotDivision = CStr(GetDivisionFromLotCommand.ExecuteScalar)
        Catch ex As Exception
            LotDivision = ""
        End Try
        con.Close()

        'Get Description - split into three fields by character count
        'Create Short Description
        Dim TotalCharactersInDescription As Integer = 0

        ShortDescription1 = ""
        ShortDescription2 = ""
        ShortDescription3 = ""

        ShortDescription = txtPartDescription22.Text
        TotalCharactersInDescription = ShortDescription.Length

        If ShortDescription.Length > 30 Then
            If TotalCharactersInDescription > 60 Then
                If TotalCharactersInDescription > 90 Then
                    ShortDescription1 = ShortDescription.Substring(0, 30)
                    ShortDescription2 = ShortDescription.Substring(30, 30)
                    ShortDescription3 = ShortDescription.Substring(60, 30)
                Else
                    ShortDescription1 = ShortDescription.Substring(0, 30)
                    ShortDescription2 = ShortDescription.Substring(30, 30)
                    ShortDescription3 = ShortDescription.Substring(60, TotalCharactersInDescription - 60)
                End If
            Else
                ShortDescription1 = ShortDescription.Substring(0, 30)
                ShortDescription2 = ShortDescription.Substring(30, TotalCharactersInDescription - 30)
                ShortDescription3 = ""
            End If
        Else
            ShortDescription1 = ShortDescription
            ShortDescription2 = ""
            ShortDescription3 = ""
        End If

        ShortDescription1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")
        ShortDescription2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")
        ShortDescription3.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        ' Print Boxes
        LabelFormat(8) = "LO609,8,1,1196"
        LabelFormat(9) = "LO406,8,1,1196"
        LabelFormat(10) = "LO203,8,1,1196"
        LabelFormat(11) = "LO406,380,204,1"
        LabelFormat(12) = "LO14,770,393,1"
        LabelFormat(13) = "LO203,340,204,1"
        LabelFormat(14) = "LO102,770,1,398"

        'Fill in Verbiage
        LabelFormat(15) = "A35,10,1,3,1,1,N," + Chr(34) + "TFP CORP. MEDINA, OH 44256 330-725-7741" + Chr(34)
        LabelFormat(16) = "A794,12,1,3,1,1,N," + Chr(34) + "PRODUCT IDENTIFICATION" + Chr(34)
        LabelFormat(17) = "A774,12,1,3,1,1,N," + Chr(34) + "(P)" + Chr(34)
        LabelFormat(18) = "A601,12,1,3,1,1,N," + Chr(34) + "QUANTITY" + Chr(34)
        LabelFormat(19) = "A581,12,1,3,1,1,N," + Chr(34) + "(Q)" + Chr(34)
        LabelFormat(20) = "A601,400,1,3,1,1,N," + Chr(34) + "DESCRIPTION" + Chr(34)
        LabelFormat(21) = "A398,12,1,3,1,1,N," + Chr(34) + "WEIGHT" + Chr(34)
        LabelFormat(22) = "A378,12,1,3,1,1,N," + Chr(34) + "(W)" + Chr(34)
        LabelFormat(23) = "A398,350,1,3,1,1,N," + Chr(34) + "HT.NO." + Chr(34)
        LabelFormat(24) = "A378,350,1,3,1,1,N," + Chr(34) + "(EH)" + Chr(34)
        LabelFormat(25) = "A392,770,1,3,1,1,N," + Chr(34) + "P.O. NUMBER" + Chr(34)
        LabelFormat(26) = "A372,770,1,3,1,1,N," + Chr(34) + "(A)" + Chr(34)
        LabelFormat(30) = "A191,1050,1,3,1,1,N," + Chr(34) + " " + Chr(34)
        LabelFormat(27) = "A191,12,1,3,1,1,N," + Chr(34) + "SERIAL NO." + Chr(34)
        LabelFormat(28) = "A171,12,1,3,1,1,N," + Chr(34) + "(S)" + Chr(34)
        LabelFormat(29) = "A191,770,1,3,1,1,N," + Chr(34) + "ATL PART #" + Chr(34)
        LabelFormat(31) = "A89,770,1,3,1,1,N," + Chr(34) + "CUSTOMER PART #" + Chr(34)

        LabelFormat(33) = "A601,136,1,4,3,2,N," + Chr(34) + strBoxCount + Chr(34)
        LabelFormat(34) = "A386,108,1,4,3,2,N," + Chr(34) + strBoxWeight + Chr(34)

        LabelFormat(35) = "A200,210,1,4,3,2,N," + Chr(34) + LotNumber + Chr(34)
        LabelFormat(36) = "A575,390,1,3,3,2,N," + Chr(34) + ShortDescription1 + Chr(34)
        LabelFormat(37) = "A525,390,1,3,3,2,N," + Chr(34) + ShortDescription2 + Chr(34)
        LabelFormat(38) = "A475,390,1,3,3,2,N," + Chr(34) + ShortDescription3 + Chr(34)

        If HeatNumber.Length >= 10 Then
            If HeatNumber.Length >= 14 Then
                LabelFormat(39) = "A380,420,1,2,3,2,N," + Chr(34) + HeatNumber + Chr(34)
                LabelFormat(47) = "B313,360,1,3,1,2,102,N," + Chr(34) + "EH" + HeatNumber + Chr(34)
            Else
                LabelFormat(39) = "A380,420,1,3,3,2,N," + Chr(34) + HeatNumber + Chr(34)
                LabelFormat(47) = "B313,360,1,3,1,2,102,N," + Chr(34) + "EH" + HeatNumber + Chr(34)
            End If
        Else
            LabelFormat(39) = "A380,420,1,4,3,2,N," + Chr(34) + HeatNumber + Chr(34)
            LabelFormat(47) = "B313,360,1,3,2,4,102,N," + Chr(34) + "EH" + HeatNumber + Chr(34)
        End If

        If CustomerPO.Length < 12 Then
            LabelFormat(40) = "A345,780,1,3,3,2,N," + Chr(34) + CustomerPO.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        ElseIf CustomerPO.Length >= 12 And CustomerPO.Length < 14 Then
            LabelFormat(40) = "A345,780,1,3,3,2,N," + Chr(34) + CustomerPO.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        ElseIf CustomerPO.Length >= 14 And CustomerPO.Length < 16 Then
            LabelFormat(40) = "A345,780,1,2,3,2,N," + Chr(34) + CustomerPO.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        Else
            LabelFormat(40) = "A345,780,1,1,3,2,N," + Chr(34) + CustomerPO.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
        End If

        LabelFormat(41) = "A170,780,1,4,2,1,N," + Chr(34) + ATLPartNumber + Chr(34)
        LabelFormat(42) = "A63,780,1,4,2,1,N," + Chr(34) + CustomerPartNumber + Chr(34)

        ''check to see if the part number is going to go off label, if os will re-adjust it

        If PartNumber.Length >= 20 Then
            LabelFormat(32) = "A790,320,1,3,3,2,N," + Chr(34) + PartNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
            LabelFormat(43) = "B717,100,1,3,2,4,102,N," + Chr(34) + "P" + PartNumber + Chr(34)
        Else
            LabelFormat(32) = "A790,320,1,4,3,2,N," + Chr(34) + PartNumber.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'") + Chr(34)
            LabelFormat(43) = "B717,320,1,3,2,4,102,N," + Chr(34) + "P" + PartNumber + Chr(34)
        End If

        LabelFormat(44) = "B520,81,1,3,2,4,102,N," + Chr(34) + "Q" + strBoxCount + Chr(34)
        LabelFormat(45) = "B319,50,1,3,2,4,102,N," + Chr(34) + "W" + strBoxWeight + Chr(34)
        LabelFormat(46) = "B140,205,1,3,2,4,102,N," + Chr(34) + "S" + LotNumber + Chr(34)

        LabelFormat(48) = "A282,770,1,3,1,1,N," + Chr(34) + "DATE" + Chr(34)
        'LabelFormat(49) = "A170,1050,1,4,2,1,N," + Chr(34) + TFPShift + Chr(34)
        LabelFormat(50) = "A255,780,1,4,2,2,N," + Chr(34) + strTodaysDate + Chr(34)
             
        'Print Label
        LabelFormat(51) = "P" + labels.ToString()
        LabelFormat(52) = vbFormFeed
        LabelLines = 51
    End Sub

    Public Sub SetupAndCreateFerruleBoxLabel(ByVal labels As Integer)
        Dim ShortTitle, PartNumber, ShortDescription As String
        Dim BoxWeight As Double = 0
        Dim strBoxWeight As String = ""
        Dim BoxCount As Double = 0
        Dim strBoxCount As String = ""
        Dim ShipDate As Date
        Dim strShipDate As String = ""
        Dim AddressBar As String = ""
        Dim BoxWeightLabel As String = ""

        PartNumber = cboFerrulePartNumber23.Text
        ShortDescription = txtDescription23.Text
        ShipDate = dtpFerruleDate23.Value
        strShipDate = ShipDate.ToShortDateString()
        BoxCount = Val(txtBoxCount23.Text)
        BoxCount = Math.Round(BoxCount, 0)
        strBoxCount = CStr(BoxCount)

        If PartNumber.StartsWith("FER") Then
            lblBoxWeight23.Text = "BOX WEIGHT (Lbs.)"
            BoxWeightLabel = "BOX WEIGHT (Lbs.)"
            BoxWeight = Val(txtBoxWeight23.Text)
            BoxCount = Math.Round(BoxWeight, 0)
            strBoxWeight = CStr(BoxWeight)
            ShortTitle = "FERRULE"
            AddressBar = "TRUWELD/TRUFIT PRODUCTS CORPORATION"
        Else
            lblBoxWeight23.Text = "CUST. PO #"
            BoxWeightLabel = "CUST. PO #"
            strBoxWeight = txtBoxWeight23.Text
            ShortTitle = "CERAMIC WELD BACKING"
            AddressBar = "WELDING CERAMICS - CHATTANOOGA, TENNESSEE - 1-423-752-5740"
        End If

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Boxes (Horizontal Lines)
        LabelFormat(8) = "LO640,0,5,1210"
        LabelFormat(9) = "LO480,0,5,1210"
        LabelFormat(10) = "LO320,0,5,1210"
        LabelFormat(11) = "LO160,0,5,1210"

        'Print Boxes - vertical lines
        LabelFormat(12) = "LO160,400,160,5"
        LabelFormat(13) = "LO160,850,160,5"

        'Fill in stationary fields
        LabelFormat(14) = "A780,10,1,3,2,1,N," & Chr(34) & "PART TYPE" & Chr(34)
        LabelFormat(15) = "A620,10,1,3,2,1,N," & Chr(34) & "PART #" & Chr(34)
        LabelFormat(16) = "A460,10,1,3,2,1,N," & Chr(34) & "DESC" & Chr(34)
        LabelFormat(17) = "A310,10,1,3,2,1,N," & Chr(34) & "BOX QUANTITY" & Chr(34)
        LabelFormat(18) = "A310,420,1,3,2,1,N," & Chr(34) & BoxWeightLabel & Chr(34)
        LabelFormat(19) = "A310,870,1,3,2,1,N," & Chr(34) & "DATE" & Chr(34)
        LabelFormat(20) = "A120,10,1,3,2,1,N," & Chr(34) & "MADE IN THE USA BY" & Chr(34)

        'Fill in variable fields
        LabelFormat(21) = "A780,160,1,3,5,2,N," & Chr(34) & ShortTitle & Chr(34)
        LabelFormat(22) = "A620,160,1,3,5,2,N," & Chr(34) & PartNumber & Chr(34)

        'Use smaller lettering for description in weld tiles
        If PartNumber.StartsWith("FER") Then
            LabelFormat(23) = "A460,160,1,3,5,2,N," & Chr(34) & ShortDescription & Chr(34)
        Else
            LabelFormat(23) = "A460,160,1,3,3,2,N," & Chr(34) & ShortDescription & Chr(34)
        End If

        LabelFormat(24) = "A250,20,1,3,3,2,N," & Chr(34) & strBoxCount & Chr(34)
        LabelFormat(25) = "A250,430,1,3,3,2,N," & Chr(34) & strBoxWeight & Chr(34)
        LabelFormat(26) = "A250,880,1,3,2,2,N," & Chr(34) & strShipDate & Chr(34)
        LabelFormat(27) = "A80,10,1,3,2,1,N," & Chr(34) & AddressBar & Chr(34)

        'Fill in barcode fields
        LabelFormat(28) = "B620,600,1,3,2,5,80,B," & Chr(34) & PartNumber & Chr(34)


        'Print Label
        LabelFormat(29) = "P" + labels.ToString()
        LabelFormat(30) = vbFormFeed
        LabelLines = 30
    End Sub

    Public Sub SetupAndCreateSpecialPartLabel(ByVal labels As Integer)
        Dim PartNumber, ShortDescription As String
        Dim Label1 As String = ""
        Dim Label2 As String = ""
        Dim Label3 As String = ""
        Dim Label4 As String = ""
        Dim Field1 As String = ""
        Dim Field2 As String = ""
        Dim Field3 As String = ""
        Dim Field4 As String = ""
        Dim CompanyName As String = ""

        Select Case EmployeeCompanyCode
            Case "CHT"
                CompanyName = "WELDING CERAMICS LLC - CHATTANOOGA, TENNESSEE - 1-423-752-5740"
            Case "SLC"
                CompanyName = "TFP OF UTAH - WEST JORDAN, UTAH - 1-801-280-6611"
            Case Else
                CompanyName = ""
        End Select

        PartNumber = cboPartNumber24.Text
        ShortDescription = cboDescription24.Text
        Label1 = txtLabel1.Text
        Label2 = txtLabel2.Text
        Label3 = txtLabel3.Text
        Label4 = txtLabel4.Text
        Field1 = txtField1.Text
        Field2 = txtField2.Text
        Field3 = txtField3.Text
        Field4 = txtField4.Text

        'COUNT # NUMBER OF CHARACTERS IN DESCRIPTION AND DROP TP SECOND LINE IF NECESSARY
        Dim ShortDescriptionP1 As String = ""
        Dim ShortDescriptionP2 As String = ""
        Dim CountCharacters As Integer = 0
        Dim CutPoint As Integer = 0
        Dim strCutPoint As String = "CUT POINT"
        Dim Counter As Integer = 0

        CountCharacters = ShortDescription.Length

        'Cut description off at 70 characters
        If CountCharacters > 70 Then
            ShortDescription = ShortDescription.Substring(0, 70)
        End If

        If ShortDescription.Length > 35 Then
            'Find first blank, before #35 to cut string
            Do Until strCutPoint = " "
                strCutPoint = ShortDescription.Substring(35 - Counter, 1)
                CutPoint = 35 - Counter

                Counter = Counter + 1
            Loop

            ShortDescriptionP1 = ShortDescription.Substring(0, CutPoint)
            ShortDescriptionP2 = ShortDescription.Substring(CutPoint, CountCharacters - CutPoint)
        Else
            ShortDescriptionP1 = ShortDescription
            ShortDescriptionP2 = ""
        End If

        'Standard 4x6 AIAG Label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Boxes (Horizontal Lines)
        LabelFormat(8) = "LO640,0,5,1210"
        LabelFormat(9) = "LO480,0,5,1210"
        LabelFormat(10) = "LO360,0,5,1210"
        LabelFormat(11) = "LO240,0,5,1210"
        LabelFormat(12) = "LO120,0,5,1210"

        'Fill in stationary fields
        LabelFormat(13) = "A780,10,1,3,2,1,N," & Chr(34) & "PART #" & Chr(34)
        LabelFormat(14) = "A620,10,1,3,2,1,N," & Chr(34) & "DESCRIPTION" & Chr(34)
        LabelFormat(15) = "A460,10,1,3,2,1,N," & Chr(34) & Label1 & Chr(34)
        LabelFormat(16) = "A340,10,1,3,2,1,N," & Chr(34) & Label2 & Chr(34)
        LabelFormat(17) = "A220,10,1,3,2,1,N," & Chr(34) & Label3 & Chr(34)
        LabelFormat(18) = "A100,10,1,3,2,1,N," & Chr(34) & Label4 & Chr(34)

        'Fill in variable fields
        LabelFormat(19) = "A780,200,1,3,2,2,N," & Chr(34) & PartNumber & Chr(34)
        LabelFormat(20) = "A620,200,1,3,2,2,N," & Chr(34) & ShortDescriptionP1 & Chr(34)
        LabelFormat(21) = "A540,200,1,3,2,2,N," & Chr(34) & ShortDescriptionP2 & Chr(34)
        LabelFormat(22) = "A460,220,1,3,2,2,N," & Chr(34) & Field1 & Chr(34)
        LabelFormat(23) = "A340,220,1,3,2,2,N," & Chr(34) & Field2 & Chr(34)
        LabelFormat(24) = "A220,220,1,3,2,2,N," & Chr(34) & Field3 & Chr(34)
        LabelFormat(25) = "A100,220,1,3,2,2,N," & Chr(34) & Field4 & Chr(34)
        LabelFormat(26) = "A030,150,1,3,1,1,N," & Chr(34) & CompanyName & Chr(34)

        'Fill in barcode fields
        LabelFormat(27) = "B780,600,1,3,2,5,80,B," & Chr(34) & PartNumber & Chr(34)


        'Print Label
        LabelFormat(28) = "P" + labels.ToString()
        LabelFormat(29) = vbFormFeed
        LabelLines = 29
    End Sub

    Public Sub SetupAndCreateMixedPalletLabelWithNotes(ByVal labels As Integer)
        Dim NoteOne, NoteTwo As String
        NoteOne = txtNoteNumberOne.Text
        NoteTwo = txtNoteNumberTwo.Text

        ''standard 4x6 aiag label setup
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Border
        LabelFormat(8) = "LO75,70,667,10" ''left
        LabelFormat(9) = "LO75,1127,677,10" ''right
        LabelFormat(10) = "LO75,70,10,1058" ''bottom
        LabelFormat(11) = "LO741,70,10,1058" ''top

        'Fill In Verbiage
        LabelFormat(12) = "A35,10,1,2,1,1,N," + Chr(34) + "TRU-WELD DIVISION TFP CORP. MEDINA, OH." + Chr(34)
        LabelFormat(13) = "A35,476,1,2,1,1,N," + Chr(34) + "44256 (330) 725-7741" + Chr(34)
        LabelFormat(14) = "A641,300,1,4,4,3,N," + Chr(34) + "MIXED PALLET" + Chr(34)
        LabelFormat(16) = "A375,120,1,1,4,3,N," + Chr(34) + NoteOne + Chr(34)
        LabelFormat(18) = "A275,120,1,1,4,3,N," + Chr(34) + NoteTwo + Chr(34)

        'Print Label
        LabelFormat(22) = "P" + labels.ToString()
        LabelFormat(23) = vbFormFeed
        LabelLines = 22
    End Sub

    Public Sub SetupAndCreatePartLabel2X4(ByVal labels As Integer)
        Dim NoteOne, NoteThree As String
        NoteOne = cboPartNumber2x4.Text
        NoteThree = txtQuantity2x4.Text

        'Get Description - split into two fields by character count
        'Create Short Description
        Dim TotalCharactersInDescription As Integer = 0

        Dim ShortDescription1 As String = ""
        Dim ShortDescription2 As String = ""

        Dim ShortDescription As String = cboPartDescription2x4.Text
        TotalCharactersInDescription = ShortDescription.Length

        Dim split As String() = ShortDescription.Split(New String() {" "}, StringSplitOptions.None)
        Dim counter As Integer = 0
        For Each s As String In split
            counter = counter + 1
        Next
        Dim counter1 As Integer = counter / 2
        Dim counter2 As Integer = counter1
        Dim counter3 As Integer = 0
        Dim counterSave1, counterSave2 As Integer
        counterSave1 = counter1
        counterSave2 = counter2

        While counter3 < counter1
            ShortDescription1 = ShortDescription1 + " " + split(counter3)
            counter3 = counter3 + 1
        End While


        While counter2 < counter
            ShortDescription2 = ShortDescription2 + " " + split(counter2)
            counter2 = counter2 + 1
        End While


        
        If EmployeeCompanyCode = "TWE" Then
            While ShortDescription1.Length > 15
                counterSave1 = counterSave1 - 1
                counterSave2 = counterSave1 + 1
                counter1 = counterSave1
                counter2 = counterSave2
                counter3 = 0
                ShortDescription1 = ""
                ShortDescription2 = ""

                While counter3 < counter1
                    ShortDescription1 = ShortDescription1 + " " + split(counter3)
                    counter3 = counter3 + 1
                End While
                ShortDescription2 = split(counter2 - 1)
                While counter2 < counter
                    ShortDescription2 = ShortDescription2 + " " + split(counter2)
                    counter2 = counter2 + 1
                End While

            End While

            ShortDescription1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")
            ShortDescription2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")

            ''standard 4x6 aiag label setup
            LabelFormat(0) = vbLf + "N"
            LabelFormat(1) = "q816"
            LabelFormat(2) = "Q1218,20+0"
            LabelFormat(3) = "S4"
            LabelFormat(4) = "D8"
            LabelFormat(5) = "ZT"
            LabelFormat(6) = "TTh:m"
            LabelFormat(7) = "TDy2mn.dd"



            'Fill In Verbiage

            LabelFormat(12) = "A300,10,4,5,1,1,N," + Chr(34) + "TRU-WELD" + Chr(34)


            LabelFormat(13) = "A25,90,4,5,1,1,N," + Chr(34) + "-PART:" + NoteOne + Chr(34)
            LabelFormat(14) = "A25,170,4,5,1,1,N," + Chr(34) + "-DESC:" + ShortDescription1 + Chr(34)
            LabelFormat(15) = "A25,250,4,5,1,1,N," + Chr(34) + ShortDescription2 + Chr(34)
            LabelFormat(16) = "A25,330,4,5,1,1,N," + Chr(34) + "-QUANTITY:" + NoteThree + Chr(34)

            'Print Label
            LabelFormat(22) = "P" + labels.ToString()
            LabelFormat(23) = vbFormFeed
            LabelLines = 22
        ElseIf EmployeeCompanyCode = "SLC" Then

            While ShortDescription1.Length > 21
                counterSave1 = counterSave1 - 1
                counterSave2 = counterSave1 + 1
                counter1 = counterSave1
                counter2 = counterSave2
                counter3 = 0
                ShortDescription1 = ""
                ShortDescription2 = ""

                While counter3 < counter1
                    ShortDescription1 = ShortDescription1 + " " + split(counter3)
                    counter3 = counter3 + 1
                End While
                ShortDescription2 = split(counter2 - 1)
                While counter2 < counter
                    ShortDescription2 = ShortDescription2 + " " + split(counter2)
                    counter2 = counter2 + 1
                End While

            End While

            ShortDescription1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")
            ShortDescription2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")

            ''standard 4x6 aiag label setup
            LabelFormat(0) = vbLf + "N"
            LabelFormat(1) = "q816"
            LabelFormat(2) = "Q1218,20+0"
            LabelFormat(3) = "S4"
            LabelFormat(4) = "D8"
            LabelFormat(5) = "ZT"
            LabelFormat(6) = "TTh:m"
            LabelFormat(7) = "TDy2mn.dd"



            'Fill In Verbiage
           

            LabelFormat(12) = "A0,10,4,5,1,1,N," + Chr(34) + "TRU-FIT PROD. TRU-WELD" + Chr(34)
       

            LabelFormat(13) = "A25,90,4,5,1,1,N," + Chr(34) + "-PART:" + NoteOne + Chr(34)
            LabelFormat(14) = "A25,170,4,5,1,1,N," + Chr(34) + ShortDescription1 + Chr(34)
            LabelFormat(15) = "A25,250,4,5,1,1,N," + Chr(34) + ShortDescription2 + Chr(34)
            LabelFormat(16) = "A25,330,4,5,1,1,N," + Chr(34) + "-QUANTITY:" + NoteThree + Chr(34)

            'Print Label
            LabelFormat(22) = "P" + labels.ToString()
            LabelFormat(23) = vbFormFeed
            LabelLines = 22
        Else

            While ShortDescription1.Length > 15
                counterSave1 = counterSave1 - 1
                counterSave2 = counterSave1 + 1
                counter1 = counterSave1
                counter2 = counterSave2
                counter3 = 0
                ShortDescription1 = ""
                ShortDescription2 = ""

                While counter3 < counter1
                    ShortDescription1 = ShortDescription1 + " " + split(counter3)
                    counter3 = counter3 + 1
                End While
                ShortDescription2 = split(counter2 - 1)
                While counter2 < counter
                    ShortDescription2 = ShortDescription2 + " " + split(counter2)
                    counter2 = counter2 + 1
                End While

            End While

            ShortDescription1.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")
            ShortDescription2.Replace(ControlChars.Quote, "\" + ControlChars.Quote).Replace("'", "\'")

            ''standard 4x6 aiag label setup
            LabelFormat(0) = vbLf + "N"
            LabelFormat(1) = "q816"
            LabelFormat(2) = "Q1218,20+0"
            LabelFormat(3) = "S4"
            LabelFormat(4) = "D8"
            LabelFormat(5) = "ZT"
            LabelFormat(6) = "TTh:m"
            LabelFormat(7) = "TDy2mn.dd"



            'Fill In Verbiage
            
            LabelFormat(12) = "A300,10,4,5,1,1,N," + Chr(34) + "TRU-FIT" + Chr(34)


            LabelFormat(13) = "A25,90,4,5,1,1,N," + Chr(34) + "-PART:" + NoteOne + Chr(34)
            LabelFormat(14) = "A25,170,4,5,1,1,N," + Chr(34) + "-DESC:" + ShortDescription1 + Chr(34)
            LabelFormat(15) = "A25,250,4,5,1,1,N," + Chr(34) + ShortDescription2 + Chr(34)
            LabelFormat(16) = "A25,330,4,5,1,1,N," + Chr(34) + "-QUANTITY:" + NoteThree + Chr(34)

            'Print Label
            LabelFormat(22) = "P" + labels.ToString()
            LabelFormat(23) = vbFormFeed
            LabelLines = 22
        End If

    End Sub

    Public Sub SetupAndCreateBranamLabel(ByVal labels As Integer)
        'Fill variables from text boxes
        Dim BranPartNumber As String = ""
        Dim BranCustPONumber As String = ""
        Dim BranReferenceNumber As String = ""
        Dim BranPartDescription As String = ""
        Dim BranSupplierCode As String = ""
        Dim BranHarmonizedCode As String = ""
        Dim BranQuantity As String = ""
        Dim BranLotNumber As String = ""
        Dim BranCountry As String = ""
        Dim BranEngineeringLevel As String = ""

        BranPartNumber = txtPartNumber25.Text
        BranPartDescription = txtPartDescription25.Text
        BranLotNumber = txtLotNumber25.Text
        BranCustPONumber = txtCustomerPO25.Text
        BranEngineeringLevel = txtEngChangeLevel25.Text
        BranReferenceNumber = txtReference25.Text
        BranSupplierCode = txtSupplierNumber25.Text
        BranQuantity = txtQuantity25.Text
        BranCountry = txtCountry25.Text
        BranHarmonizedCode = txtHarmCode25.Text

        Dim cmd As New SqlCommand("SELECT DivisionID, BlueprintRevision FROM LotNumber WHERE LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = BranLotNumber
        Dim revLevel As String = ""
        Dim division As String = "TWD"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.Item("DivisionID")) Then
                If reader.Item("DivisionID").ToString.Equals("TFP") Then
                    division = "TFP"
                    If Not IsDBNull(reader.Item("BlueprintRevision")) Then
                        revLevel = reader.Item("BlueprintRevision")
                    End If
                End If
            End If
        End If
        reader.Close()
        con.Close()

        'Branam BC_6156 from Wang
        LabelFormat(0) = vbLf + "N"
        LabelFormat(1) = "q816"
        LabelFormat(2) = "Q1218,20+0"
        LabelFormat(3) = "S4"
        LabelFormat(4) = "D8"
        LabelFormat(5) = "ZT"
        LabelFormat(6) = "TTh:m"
        LabelFormat(7) = "TDy2mn.dd"

        'Print Boxes (Horizontal Lines)
        LabelFormat(8) = "LO670,0,1,1210"
        LabelFormat(9) = "LO528,0,1,1210"
        LabelFormat(10) = "LO386,0,1,1210"
        LabelFormat(11) = "LO244,0,1,1210"
        LabelFormat(12) = "LO102,0,1,1210"

        'Print Boxes - vertical lines
        LabelFormat(13) = "LO812,609,1,1"
        LabelFormat(14) = "LO670,609,141,1"
        LabelFormat(15) = "LO528,711,141,1"
        LabelFormat(16) = "LO244,508,141,1"
        LabelFormat(17) = "LO102,508,141,1"

        LabelFormat(18) = "A800,20,1,1,1,1,N," + Chr(34) + "P.O. (K)" + Chr(34)
        LabelFormat(19) = "A798,219,1,3,2,1,N," + Chr(34) + BranCustPONumber + Chr(34)
        LabelFormat(20) = "B753,164,1,3,2,4,81,N," + Chr(34) + "K" + BranCustPONumber + Chr(34)
        LabelFormat(21) = "A800,613,1,1,1,1,N," + Chr(34) + "EC# (2P)" + Chr(34)
        LabelFormat(22) = "A800,869,1,3,2,1,N," + Chr(34) + BranEngineeringLevel + Chr(34)
        LabelFormat(23) = "B753,784,1,3,2,4,81,N," + Chr(34) + "2P" + BranEngineeringLevel + Chr(34)
        LabelFormat(24) = "A656,20,1,1,1,1,N," + Chr(34) + "PART NO. (P)" + Chr(34)

        If division.Equals("TFP") Then
            If Not BranPartNumber.ToUpper.Contains("REV. ") And Not BranPartNumber.ToUpper.Contains("REV ") Then
                LabelFormat(25) = "A658,223,1,3,2,1,N," + Chr(34) + BranPartNumber + " REV. " + revLevel + Chr(34)
                LabelFormat(26) = "B611,156,1,3,2,4,81,N," + Chr(34) + "P" + BranPartNumber + " REV. " + revLevel + Chr(34)
            Else
                LabelFormat(25) = "A658,223,1,3,2,1,N," + Chr(34) + BranPartNumber + Chr(34)
                LabelFormat(26) = "B611,156,1,3,2,4,81,N," + Chr(34) + "P" + BranPartNumber + Chr(34)
            End If
        Else
            LabelFormat(25) = "A658,223,1,3,2,1,N," + Chr(34) + BranPartNumber + Chr(34)
            LabelFormat(26) = "B611,156,1,3,2,4,81,N," + Chr(34) + "P" + BranPartNumber + Chr(34)
        End If

        LabelFormat(27) = "A656,715,1,1,1,1,N," + Chr(34) + "COUNTRY OF" + Chr(34)
        LabelFormat(28) = "A633,715,1,1,1,1,N," + Chr(34) + "ORIGIN (4L)" + Chr(34)
        LabelFormat(29) = "A656,946,1,3,2,1,N," + Chr(34) + BranCountry + Chr(34)
        LabelFormat(30) = "B611,903,1,3,2,4,81,N," + Chr(34) + "4L" + BranCountry + Chr(34)
        LabelFormat(31) = "A520,20,1,1,1,1,N," + Chr(34) + "REF (Z)" + Chr(34)
        LabelFormat(32) = "A514,244,1,3,2,1,N," + Chr(34) + BranReferenceNumber + Chr(34)
        LabelFormat(33) = "B469,154,1,3,2,4,81,N," + Chr(34) + "Z" + BranReferenceNumber + Chr(34)
        LabelFormat(34) = "A374,20,1,1,1,1,N," + Chr(34) + "QUANTITY U/M (7Q)" + Chr(34)
        LabelFormat(35) = "A367,213,1,3,2,1,N," + Chr(34) + BranQuantity + Chr(34)
        LabelFormat(36) = "B323,150,1,3,2,4,81,N," + Chr(34) + "7Q" + BranQuantity + Chr(34)
        LabelFormat(37) = "A231,20,1,1,1,1,N," + Chr(34) + "SUPPLIER (V)" + Chr(34)
        LabelFormat(38) = "A229,209,1,3,2,1,N," + Chr(34) + BranSupplierCode + Chr(34)
        LabelFormat(39) = "B183,142,1,3,2,4,81,N," + Chr(34) + "V" + BranSupplierCode + Chr(34)
        LabelFormat(40) = "A93,20,1,1,1,1,N," + Chr(34) + "DESCRIPTION" + Chr(34)
        LabelFormat(41) = "A83,156,1,4,2,1,N," + Chr(34) + BranPartDescription + Chr(34)
        LabelFormat(42) = "A374,509,1,1,1,1,N," + Chr(34) + "LOT# SPLR (1T)" + Chr(34)
        LabelFormat(43) = "A374,774,1,3,2,1,N," + Chr(34) + BranLotNumber + Chr(34)
        LabelFormat(44) = "B327,662,1,3,2,4,81,N," + Chr(34) + "1T" + BranLotNumber + Chr(34)
        LabelFormat(45) = "A231,509,1,1,1,1,N," + Chr(34) + "HARMONIZED CODE (HC)" + Chr(34)
        LabelFormat(46) = "A231,836,1,3,2,1,N," + Chr(34) + BranHarmonizedCode + Chr(34)
        LabelFormat(47) = "B185,622,1,3,2,4,81,N," + Chr(34) + "HC" + BranHarmonizedCode + Chr(34)

        'Print Label

        LabelFormat(48) = "P" + labels.ToString
        LabelFormat(49) = vbFormFeed
        LabelLines = 48
    End Sub

    'Print Labels


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
        If bool2x4 Then

            While i < printers.Count() - 1
                If String.IsNullOrEmpty(printers(i)) = False And printers(i).Contains("Zebra2X4TWE") Then
                    pd.PrinterSettings.PrinterName = printers(i)
                End If
                If String.IsNullOrEmpty(printers(i)) = False And printers(i).Contains("Zebra2X4SLC") Then
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

        Else
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

    Private Sub cmdPrintLabels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintLabels.Click
        'Validation for each Group Box
        Dim TempLabelPrintPosition As Integer = LabelPrintPosition

        Select Case TempLabelPrintPosition
            Case 0
                MsgBox("You must select a Label Type to print.", MsgBoxStyle.OkOnly)
                Exit Sub
            Case 1
                'Validate Group box
                If txtLotNumber01.Text = "" Or txtPartNumber01.Text = "" Or txtHeatNumber01.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                'Validate that label can be printed
                CurrentLotNumber = txtLotNumber01.Text
                LoadLotNumberStatusAndIfInspected()

                If LotNumberCaPrintLabel = "YES" Then
                    'Skip
                Else
                    MsgBox("QC Needs to sign off before printing label.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 2
                'Validate Group box
                If txtLotNumber02.Text = "" Or txtPartNumber02.Text = "" Or txtHeatNumber02.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                'Validate that label can be printed
                CurrentLotNumber = txtLotNumber02.Text
                LoadLotNumberStatusAndIfInspected()

                If LotNumberCaPrintLabel = "YES" Then
                    'Skip
                Else
                    MsgBox("QC Needs to sign off before printing label.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 3
                'Skip - no validation needed
            Case 4
                'Skip - no validation needed
            Case 5
                'Validate Group box
                If cboCustomerID05.Text = "" Or cboCustomerName05.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 6
                'Validate Group box
                If txtCustomerID06.Text = "" Or txtCustomerName06.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                'Write to database that label was printed
                InsertIntoShippingLabelTable()

                'Print Special Pallet Label if necessary
                If LabelDoesSpecialLabelExist = "YES" Then
                    'Print
                    SetupAndCreateSpecialLabel()
                Else
                    'Don't print
                End If
            Case 7
                'Validate Group box
                If txtLotNumber07.Text = "" Or txtPartNumber07.Text = "" Or txtFOXNumber07.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                'Validate that label can be printed
                CurrentLotNumber = txtLotNumber07.Text
                LoadLotNumberStatusAndIfInspected()

                If LotNumberCaPrintLabel = "YES" Then
                    'Skip
                Else
                    MsgBox("QC Needs to sign off before printing label.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 8
                'Validate Group box
                If txtRackNumber108.Text = "" And txtRackNumber208.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 9
                'Validate Group box
                If txtRackNumber09.Text = "" And cboDirection09.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 10
                'Validate Group box
                If txtLotNumber10.Text = "" Or txtPartNumber10.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                'Validate that label can be printed
                CurrentLotNumber = txtLotNumber10.Text
                LoadLotNumberStatusAndIfInspected()

                If LotNumberCaPrintLabel = "YES" Then
                    'Skip
                Else
                    MsgBox("QC Needs to sign off before printing label.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 11
                'Validate Group box
                If txtLotNumber11.Text = "" Or txtPartNumber11.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                'Validate that label can be printed
                CurrentLotNumber = txtLotNumber11.Text
                LoadLotNumberStatusAndIfInspected()

                If LotNumberCaPrintLabel = "YES" Then
                    'Skip
                Else
                    MsgBox("QC Needs to sign off before printing label.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 12
                'Validate Group box
                If cboScanEntry12.Text = "" Or txtSteelCarbon12.Text = "" Or txtSteelSize12.Text Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 13
                'Skip - no validation needed
            Case 14
                'Validate Group box
                If txtBlank114.Text = "" And txtBlank214.Text = "" And txtBlank314.Text = "" And txtBlank414.Text = "" And txtBlank514.Text = "" And txtBlank614.Text = "" And txtBlank714.Text = "" And txtBlank814.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 15
                'Validate Group box
                If txtBlankLineOne15.Text = "" And txtBlankLineTwo15.Text = "" And txtBlankLineThree15.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 16
                'Validate Group box
                If txtAnnealedLotNumber16.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 17
                'Skip - no validation needed
            Case 18
                'Skip - no validation needed
            Case 19
                'Skip - no validation needed
            Case 20
                'Skip - no validation needed
            Case 21
                'PrintBarcodeLine(NumberOfLabels)
            Case 22
                'Validate Group box
                If txtLotNumber22.Text = "" Or txtPartNumber22.Text = "" Or txtHeatNumber22.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                'Validate that label can be printed
                CurrentLotNumber = txtLotNumber22.Text
                LoadLotNumberStatusAndIfInspected()

                If LotNumberCaPrintLabel = "YES" Then
                    'Skip
                Else
                    MsgBox("QC Needs to sign off before printing label.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 23
                'Validate Group box
                If cboFerrulePartNumber23.Text = "" Or txtDescription23.Text = "" Or txtBoxCount23.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 24
                'Validate Group box
                If cboPartNumber24.Text = "" Or cboDescription24.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            Case 25
                'Validate Group box
                If txtPartNumber25.Text = "" Or txtPartDescription25.Text = "" Then
                    MsgBox("One or more fields are missing.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
        End Select

        NumberOfLabels = nbrLabelCount.Value

        Select Case LabelPrintPosition
            Case 0
                MsgBox("You must select a Label Type to print.", MsgBoxStyle.OkOnly)
                Exit Sub
            Case 1
                SetupAndCreateRackingBarcodeLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 2
                SetupAndCreateFOXLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 3
                SetupAndCreateMixedLoadLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 4
                SetupAndCreateMixedHeatLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 5
                SetupAndCreateShippingAddressLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 6
                SetupAndCreateShippingByPickTicketLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)

                If LabelDoesSpecialLabelExist = "YES" Then
                    SetupAndCreateThreeBlankLineLabel(NumberOfLabels)
                    PrintBarcodeLine(NumberOfLabels)
                End If
            Case 7
                SetupAndCreateTubTag(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 8
                SetupAndCreateBinLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 9
                SetupAndCreatePalletBinLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 10
                SetupAndCreateFryerLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 11
                SetupAndCreateOptimasLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 12
                SetupAndCreateCoilLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 13
                SetupAndCreateUniversalWasteLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 14
                SetupAndCreateFourBlankLineLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 15
                SetupAndCreateThreeBlankLineLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 16
                SetupAndCreateAnnealingLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 17
                SetupAndCreateZincLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 18
                SetupAndCreateNickelLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 19
                SetupAndCreateStainlessSteelLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 20
                SetupAndCreatePartialPalletLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 21
                SetupAndCreateCustomLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 22
                SetupAndCreateATOPLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 23
                SetupAndCreateFerruleBoxLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 24
                SetupAndCreateSpecialPartLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
            Case 25
                SetupAndCreateBranamLabel(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
        End Select

        'Clear Label Fields
        ClearAllLabelArray()
 
        cmdPrintLabels.Focus()
    End Sub

    '======================================================================================================================
    'END OF LABEL PROGRAM CONTROL
    '======================================================================================================================

    Private Sub cmdClearFields_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearFields.Click
        ClearLabelFields()
        ClearAllVariables()
        ClearAllLabelArray()
    End Sub

    'Set Button on the Enter Key

    Private Sub txtProductionFoxNumber_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProductionFoxNumber.Enter
        If txtProductionFoxNumber.Text = "" Then
            'do nothing
        Else
            Me.AcceptButton = cmdPrintProductionOrder
        End If
    End Sub

    Private Sub cboInspectionHeader_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboInspectionHeader.Enter
        If cboInspectionHeader.Text = "" Then
            'do nothing
        Else
            Me.AcceptButton = cmdInspectionReport
        End If
    End Sub

    Private Sub txtLotNumber_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLotNumber.Enter
        If txtLotNumber.Text = "" Then
            'do nothing
        Else
            Me.AcceptButton = cmdTubPage
        End If
    End Sub

    Private Sub txtBlueprintBlueprintNumber_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBlueprintBlueprintNumber.Enter
        If txtBlueprintBlueprintNumber.Text = "" Then
            'do nothing
        Else
            Me.AcceptButton = cmdPrintBlueprintOnly
        End If
    End Sub

    Private Sub txtBlueprintFoxNumber_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBlueprintFoxNumber.Enter
        If txtBlueprintFoxNumber.Text = "" Then
            'do nothing
        Else
            Me.AcceptButton = cmdPrintBlueprintOnly
        End If
    End Sub

    Private Sub cmdPrintMixedPalletWithNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintMixedPalletWithNotes.Click
        SetupAndCreateMixedPalletLabelWithNotes(NumberOfLabels)
        PrintBarcodeLine(NumberOfLabels)
    End Sub

    Private Sub cmdReloadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReloadData.Click
        ClearLabelFields()
        LoadInspectionProcess()

        If EmployeeCompanyCode = "CHT" Then
            LoadFerrulePartNumber()
        Else
            LoadFerrulePartNumberOther()
        End If

        ClearAllGroupBoxesAndMakeInvisible()
    End Sub

    Private Sub cmdPrintPartLabel2x4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPartLabel2x4.Click
        If String.IsNullOrEmpty(txtQuantity2x4.Text) And String.IsNullOrEmpty(cboPartNumber2x4.Text) And String.IsNullOrEmpty(cboPartDescription2x4.Text) Then
        Else
            Dim m As Integer = 0
            While m < nbr2X4Label.Value
                bool2x4 = True
                SetupAndCreatePartLabel2X4(NumberOfLabels)
                PrintBarcodeLine(NumberOfLabels)
                m = m + 1
            End While

            bool2x4 = False
        End If
    End Sub

  
    Private Sub cboPartNumber2x4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber2x4.SelectedIndexChanged
        Dim description As String = ""

        Dim itemStatement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"

        Dim itemCommand As New SqlCommand(itemStatement, con)
        itemCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber2x4.Text
        itemCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            description = CStr(itemCommand.ExecuteScalar)
        Catch ex As Exception
            description = ""
        End Try
        con.Close()

        cboPartDescription2x4.Text = description
    End Sub

    Private Sub cboPartDescription2x4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription2x4.SelectedIndexChanged

        Dim Item As String = ""

        Dim itemStatement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"

        Dim itemCommand As New SqlCommand(itemStatement, con)
        itemCommand.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription2x4.Text
        itemCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            Item = CStr(itemCommand.ExecuteScalar)
        Catch ex As Exception
            Item = ""
        End Try
        con.Close()

        cboPartNumber2x4.Text = Item
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub cmdTWEProductionScheduling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTWEProductionScheduling.Click
        Dim NewTWEProductionScheduling As New EquipmentProductionScheduling
        NewTWEProductionScheduling.Show()
    End Sub

    Private Sub cboPartNumber2x4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPartNumber2x4.TextChanged
        Try

            Dim description As String = ""

            Dim itemStatement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"

            Dim itemCommand As New SqlCommand(itemStatement, con)
            itemCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber2x4.Text
            itemCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                description = CStr(itemCommand.ExecuteScalar)
            Catch ex As Exception
                description = ""
            End Try
            con.Close()

            cboPartDescription2x4.Text = description

            SendKeys.Send("{End}")
        Catch ex As Exception

        End Try
    End Sub

End Class