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
Public Class CreateVendorBOL
    Inherits System.Windows.Forms.Form

    Dim ShipToName, CustomerName, ShipZip, ShipState, ShipCity, ShipCountry, ShipAddress1, ShipAddress2, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToZip, ShipToCountry, ShipToState As String
    Dim BoxTotal, SUMTotalWeight As Double
    Dim LastBOLNumber, NextBOLNumber, PalletTotal As Integer
    Dim ShipDate, BeginDate, EndDate As Date
    Dim CheckShippingMethod As String = ""
    Dim ShipMethod As String = ""
    Dim CheckShipmentAddress As String = ""
    Dim CheckThirdPartyShipper As String = ""

    'Variable for third party billing
    Dim BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToName As String

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

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

    Private Sub CreateVendorBOL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)

        LoadCurrentDivision()
        LoadBOLNumber()
        LoadCustomerID()
        LoadVendorID()
        ClearData()

        chkDefaultAsDivision.Checked = True

        If cboDivisionID.Text <> "" Then
            LoadDivisionData()
        End If
    End Sub

    Private Sub cmdGenerateNewBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewBOL.Click
        'Generate new number and save in database.
        'Get New BOLNumber
        Dim MAXBOLStatement As String = "SELECT MAX(VendorBOLNumber) FROM VendorBOLTable"
        Dim MAXBOLCommand As New SqlCommand(MAXBOLStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBOLNumber = CInt(MAXBOLCommand.ExecuteScalar)
        Catch ex As Exception
            LastBOLNumber = 3750000
        End Try
        con.Close()

        NextBOLNumber = LastBOLNumber + 1
        cboBOLNumber.Text = NextBOLNumber

        'Insert new record into database
        Try
            cmd = New SqlCommand("INSERT INTO VendorBOLTable (VendorBOLNumber, ShipmentDate, ShipmentNumber, CustomerPO, FreightQuoteNumber, PRONumber, ShippingAccountNumber, MinorShippingUnit, MajorShippingUnit, ClassRate, CommodityType, TotalMinorUnits, TotalMajorUnits, TotalWeight, DoubleStackedUnits, TotalUnitsOnFloor, FromCompanyName, FromAddress1, FromAddress2, FromCity, FromState, FromZipCode, FromPhoneNumber, FromCountry, ToCompanyName, ToAddress1, ToAddress2, ToCity, ToState, ToZipCode, ToPhoneNumber, ToCountry, ShipVia, ShipMethod, ThirdPartyBilling, SpecialInstructions, FOB, DivisionID)values (@VendorBOLNumber, @ShipmentDate, @ShipmentNumber, @CustomerPO, @FreightQuoteNumber, @PRONumber, @ShippingAccountNumber, @MinorShippingUnit, @MajorShippingUnit, @ClassRate, @CommodityType, @TotalMinorUnits, @TotalMajorUnits, @TotalWeight, @DoubleStackedUnits, @TotalUnitsOnFloor, @FromCompanyName, @FromAddress1, @FromAddress2, @FromCity, @FromState, @FromZipCode, @FromPhoneNumber, @FromCountry, @ToCompanyName, @ToAddress1, @ToAddress2, @ToCity, @ToState, @ToZipCode, @ToPhoneNumber, @ToCountry, @ShipVia, @ShipMethod, @ThirdPartyBilling, @SpecialInstructions, @FOB, @DivisionID)", con)

            With cmd.Parameters
                .Add("@VendorBOLNumber", SqlDbType.VarChar).Value = NextBOLNumber
                .Add("@ShipmentDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = txtShipmentNumber.Text
                .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
                .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONUmber.Text
                .Add("@ShippingAccountNumber", SqlDbType.VarChar).Value = txtFreightAccountNumber.Text
                .Add("@MinorShippingUnit", SqlDbType.VarChar).Value = cboMinorUnits.Text
                .Add("@MajorShippingUnit", SqlDbType.VarChar).Value = cboMajorUnits.Text
                .Add("@ClassRate", SqlDbType.VarChar).Value = txtClassRate.Text
                .Add("@CommodityType", SqlDbType.VarChar).Value = cboCommodity.Text
                .Add("@TotalMinorUnits", SqlDbType.VarChar).Value = Val(txtMinorUnits.Text)
                .Add("@TotalMajorUnits", SqlDbType.VarChar).Value = Val(txtMajorUnits.Text)
                .Add("@TotalWeight", SqlDbType.VarChar).Value = Val(txtTotalWeight.Text)
                .Add("@DoubleStackedUnits", SqlDbType.VarChar).Value = Val(txtDoubleStacks.Text)
                .Add("@TotalUnitsOnFloor", SqlDbType.VarChar).Value = Val(txtTotalOnFloor.Text)
                .Add("@FromCompanyName", SqlDbType.VarChar).Value = txtFromCompanyName.Text
                .Add("@FromAddress1", SqlDbType.VarChar).Value = txtFromAddress1.Text
                .Add("@FromAddress2", SqlDbType.VarChar).Value = txtFromAddress2.Text
                .Add("@FromCity", SqlDbType.VarChar).Value = txtFromCity.Text
                .Add("@FromState", SqlDbType.VarChar).Value = txtFromState.Text
                .Add("@FromZipCode", SqlDbType.VarChar).Value = txtFromZipCode.Text
                .Add("@FromPhoneNumber", SqlDbType.VarChar).Value = txtFromPhoneNumber.Text
                .Add("@FromCountry", SqlDbType.VarChar).Value = txtFromCountry.Text
                .Add("@ToCompanyName", SqlDbType.VarChar).Value = txtToCompanyName.Text
                .Add("@ToAddress1", SqlDbType.VarChar).Value = txtToAddress1.Text
                .Add("@ToAddress2", SqlDbType.VarChar).Value = txtToAddress2.Text
                .Add("@ToCity", SqlDbType.VarChar).Value = txtToCity.Text
                .Add("@ToState", SqlDbType.VarChar).Value = txtToState.Text
                .Add("@ToZipCode", SqlDbType.VarChar).Value = txtToZipCode.Text
                .Add("@ToPhoneNumber", SqlDbType.VarChar).Value = txtToPhoneNumber.Text
                .Add("@ToCountry", SqlDbType.VarChar).Value = txtToCountry.Text
                .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@ShipMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                .Add("@ThirdPartyBilling", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                .Add("@FOB", SqlDbType.VarChar).Value = txtFOB.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Check

        End Try














    End Sub

    Public Sub LoadCustomerID()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CustomerList")
        cboCustomerID.DataSource = ds1.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorID()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass ORDER BY VendorCode", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "Vendor")
        cboVendorID.DataSource = ds2.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadBOLNumber()
        cmd = New SqlCommand("SELECT VendorBOLNumber FROM VendorBOLTable WHERE DivisionID = @DivisionID ORDER BY VendorBOLNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "VendorBOLTable")
        cboBOLNumber.DataSource = ds3.Tables("VendorBOLTable")
        con.Close()
        cboBOLNumber.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboBOLNumber.SelectedIndex = -1
        cboCommodity.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboMajorUnits.SelectedIndex = -1
        cboMinorUnits.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1

        txtClassRate.Clear()
        txtCustomerPO.Clear()
        txtDoubleStacks.Clear()
        txtFOB.Clear()
        txtFreightAccountNumber.Clear()
        txtFreightQuoteNumber.Clear()
        txtFromAddress1.Clear()
        txtFromAddress2.Clear()
        txtFromCity.Clear()
        txtFromCompanyName.Clear()
        txtFromCountry.Clear()
        txtFromPhoneNumber.Clear()
        txtFromState.Clear()
        txtFromZipCode.Clear()
        txtMajorUnits.Clear()
        txtMinorUnits.Clear()
        txtPRONUmber.Clear()
        txtShipmentNumber.Clear()
        txtSpecialInstructions.Clear()
        txtThirdParty.Clear()
        txtToAddress1.Clear()
        txtToAddress2.Clear()
        txtToCity.Clear()
        txtToCompanyName.Clear()
        txtToCountry.Clear()
        txtToPhoneNumber.Clear()
        txtToState.Clear()
        txtTotalOnFloor.Clear()
        txtTotalWeight.Clear()
        txtToZipCode.Clear()
        txtClassRate.Text = "50"

        dtpShipDate.Value = Today()

        chkDefaultAsDivision.Checked = True
        chkLoadFromCustomer.Checked = False
        chkLoadFromVendor.Checked = False

        cboBOLNumber.Focus()
    End Sub

    Public Sub LoadDivisionData()
        Dim DivisionName As String = ""
        Dim DivisionAddress1 As String = ""
        Dim DivisionAddress2 As String = ""
        Dim DivisionCity As String = ""
        Dim DivisionState As String = ""
        Dim DivisionZipCode As String = ""
        Dim DivisionCountry As String = ""
        Dim DivisionPhone As String = ""
        Dim DivisionClass As String = ""
  
        Dim LoadDivisionDataString As String = "SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim LoadDivisionDataCommand As New SqlCommand(LoadDivisionDataString, con)
        LoadDivisionDataCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LoadDivisionDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CompanyName")) Then
                DivisionName = ""
            Else
                DivisionName = reader.Item("CompanyName")
            End If
            If IsDBNull(reader.Item("Address1")) Then
                DivisionAddress1 = ""
            Else
                DivisionAddress1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                DivisionAddress2 = ""
            Else
                DivisionAddress2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                DivisionCity = ""
            Else
                DivisionCity = reader.Item("City")
            End If
            If IsDBNull(reader.Item("ZipCode")) Then
                DivisionZipCode = ""
            Else
                DivisionZipCode = reader.Item("ZipCode")
            End If
            If IsDBNull(reader.Item("State")) Then
                DivisionState = ""
            Else
                DivisionState = reader.Item("State")
            End If
            If IsDBNull(reader.Item("Country")) Then
                DivisionCountry = ""
            Else
                DivisionCountry = reader.Item("Country")
            End If
            If IsDBNull(reader.Item("Phone")) Then
                DivisionPhone = ""
            Else
                DivisionPhone = reader.Item("Phone")
            End If
            If IsDBNull(reader.Item("DivisionClass")) Then
                DivisionClass = ""
            Else
                DivisionClass = reader.Item("DivisionClass")
            End If
        Else
            DivisionAddress1 = ""
            DivisionAddress2 = ""
            DivisionCity = ""
            DivisionClass = ""
            DivisionCountry = ""
            DivisionName = ""
            DivisionPhone = ""
            DivisionState = ""
            DivisionZipCode = ""
        End If
        reader.Close()
        con.Close()

        txtFromAddress1.Text = DivisionAddress1
        txtFromAddress2.Text = DivisionAddress2
        txtFromCity.Text = DivisionCity
        txtFromCompanyName.Text = DivisionName
        txtFromCountry.Text = DivisionCountry
        txtFromPhoneNumber.Text = DivisionPhone
        txtFromState.Text = DivisionState
        txtFromZipCode.Text = DivisionZipCode
        txtFOB.Text = DivisionCity
    End Sub

    Public Sub LoadCustomerData()
        Dim CustomerName As String = ""
        Dim CustomerAddress1 As String = ""
        Dim CustomerAddress2 As String = ""
        Dim CustomerCity As String = ""
        Dim CustomerState As String = ""
        Dim CustomerZipCode As String = ""
        Dim CustomerCountry As String = ""
        Dim CustomerPhone As String = ""
        Dim CustomerClass As String = ""

        Dim LoadCustomerDataString As String = "SELECT * FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
        Dim LoadCustomerDataCommand As New SqlCommand(LoadCustomerDataString, con)
        LoadCustomerDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LoadCustomerDataCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LoadCustomerDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CustomerName")) Then
                CustomerName = ""
            Else
                CustomerName = reader.Item("CustomerName")
            End If
            If IsDBNull(reader.Item("ShipToAddress1")) Then
                CustomerAddress1 = ""
            Else
                CustomerAddress1 = reader.Item("ShipToAddress1")
            End If
            If IsDBNull(reader.Item("ShipToAddress2")) Then
                CustomerAddress2 = ""
            Else
                CustomerAddress2 = reader.Item("ShipToAddress2")
            End If
            If IsDBNull(reader.Item("ShipToCity")) Then
                CustomerCity = ""
            Else
                CustomerCity = reader.Item("ShipToCity")
            End If
            If IsDBNull(reader.Item("ShipToZip")) Then
                CustomerZipCode = ""
            Else
                CustomerZipCode = reader.Item("ShipToZip")
            End If
            If IsDBNull(reader.Item("ShipToState")) Then
                CustomerState = ""
            Else
                CustomerState = reader.Item("ShipToState")
            End If
            If IsDBNull(reader.Item("ShipToCountry")) Then
                CustomerCountry = ""
            Else
                CustomerCountry = reader.Item("ShipToCountry")
            End If
            If IsDBNull(reader.Item("APPhoneNumber")) Then
                CustomerPhone = ""
            Else
                CustomerPhone = reader.Item("APPhoneNumber")
            End If
        Else
            CustomerAddress1 = ""
            CustomerAddress2 = ""
            CustomerCity = ""
            CustomerClass = ""
            CustomerCountry = ""
            CustomerName = ""
            CustomerPhone = ""
            CustomerState = ""
            CustomerZipCode = ""
        End If
        reader.Close()
        con.Close()

        txtToAddress1.Text = CustomerAddress1
        txtToAddress2.Text = CustomerAddress2
        txtToCity.Text = CustomerCity
        txtToCompanyName.Text = CustomerName
        txtToCountry.Text = CustomerCountry
        txtToPhoneNumber.Text = CustomerPhone
        txtToState.Text = CustomerState
        txtToZipCode.Text = CustomerZipCode
    End Sub

    Public Sub LoadVendorData()
        Dim VendorName As String = ""
        Dim VendorAddress1 As String = ""
        Dim VendorAddress2 As String = ""
        Dim VendorCity As String = ""
        Dim VendorState As String = ""
        Dim VendorZipCode As String = ""
        Dim VendorCountry As String = ""
        Dim VendorPhone As String = ""
        Dim VendorClass As String = ""

        Dim LoadVendorDataString As String = "SELECT * FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
        Dim LoadVendorDataCommand As New SqlCommand(LoadVendorDataString, con)
        LoadVendorDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LoadVendorDataCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LoadVendorDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("VendorName")) Then
                VendorName = ""
            Else
                VendorName = reader.Item("VendorName")
            End If
            If IsDBNull(reader.Item("VendorAddress1")) Then
                VendorAddress1 = ""
            Else
                VendorAddress1 = reader.Item("VendorAddress1")
            End If
            If IsDBNull(reader.Item("VendorAddress2")) Then
                VendorAddress2 = ""
            Else
                VendorAddress2 = reader.Item("VendorAddress2")
            End If
            If IsDBNull(reader.Item("VendorCity")) Then
                VendorCity = ""
            Else
                VendorCity = reader.Item("VendorCity")
            End If
            If IsDBNull(reader.Item("VendorZip")) Then
                VendorZipCode = ""
            Else
                VendorZipCode = reader.Item("VendorZip")
            End If
            If IsDBNull(reader.Item("VendorState")) Then
                VendorState = ""
            Else
                VendorState = reader.Item("VendorState")
            End If
            If IsDBNull(reader.Item("VendorCountry")) Then
                VendorCountry = ""
            Else
                VendorCountry = reader.Item("VendorCountry")
            End If
            If IsDBNull(reader.Item("VendorPhone")) Then
                VendorPhone = ""
            Else
                VendorPhone = reader.Item("VendorPhone")
            End If
        Else
            VendorAddress1 = ""
            VendorAddress2 = ""
            VendorCity = ""
            VendorClass = ""
            VendorCountry = ""
            VendorName = ""
            VendorPhone = ""
            VendorState = ""
            VendorZipCode = ""
        End If
        reader.Close()
        con.Close()

        txtToAddress1.Text = VendorAddress1
        txtToAddress2.Text = VendorAddress2
        txtToCity.Text = VendorCity
        txtToCompanyName.Text = VendorName
        txtToCountry.Text = VendorCountry
        txtToPhoneNumber.Text = VendorPhone
        txtToState.Text = VendorState
        txtToZipCode.Text = VendorZipCode
    End Sub

    Public Sub LoadBOLData()
        Dim ShipmentDate As String = ""
        Dim ShipmentNumber As String = ""
        Dim CustomerPO As String = ""
        Dim FreightQuoteNumber As String = ""
        Dim PRONumber As String = ""
        Dim ShippingAccountNumber As String = ""
        Dim MinorShippingUnit As String = ""
        Dim MajorShippingUnit As String = ""
        Dim ClassRate As String = ""
        Dim CommodityType As String = ""
        Dim TotalMinorUnits As Double = 0
        Dim TotalWeight As Double = 0
        Dim TotalMajorUnits As Double = 0
        Dim DoubleStackedUnits As Double = 0
        Dim TotalUnitsOnFloor As Double = 0
        Dim FromCompanyName As String = ""
        Dim FromAddress1 As String = ""
        Dim FromAddress2 As String = ""
        Dim FromCity As String = ""
        Dim FromState As String = ""
        Dim FromZipCode As String = ""
        Dim FromPhoneNumber As String = ""
        Dim FromCountry As String = ""
        Dim ToCompanyName As String = ""
        Dim ToAddress1 As String = ""
        Dim ToAddress2 As String = ""
        Dim ToCity As String = ""
        Dim ToState As String = ""
        Dim ToZipCode As String = ""
        Dim ToPhoneNumber As String = ""
        Dim ToCountry As String = ""
        Dim ShipVia As String = ""
        Dim ShipMethod As String = ""
        Dim ThirdPartyBilling As String = ""
        Dim SpecialInstructions As String = ""
        Dim FOB As String = ""

        Dim LoadBOLDataString As String = "SELECT * FROM VendorBOLTable WHERE DivisionID = @DivisionID AND VendorBOLNumber = @VendorBOLNumber"
        Dim LoadBOLDataCommand As New SqlCommand(LoadBOLDataString, con)
        LoadBOLDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LoadBOLDataCommand.Parameters.Add("@VendorBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LoadBOLDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ShipmentDate")) Then
                ShipmentDate = ""
            Else
                ShipmentDate = reader.Item("ShipmentDate")
            End If
            If IsDBNull(reader.Item("ShipmentNumber")) Then
                ShipmentNumber = ""
            Else
                ShipmentNumber = reader.Item("ShipmentNumber")
            End If
            If IsDBNull(reader.Item("CustomerPO")) Then
                CustomerPO = ""
            Else
                CustomerPO = reader.Item("CustomerPO")
            End If
            If IsDBNull(reader.Item("FreightQuoteNumber")) Then
                FreightQuoteNumber = ""
            Else
                FreightQuoteNumber = reader.Item("FreightQuoteNumber")
            End If
            If IsDBNull(reader.Item("PRONumber")) Then
                PRONumber = ""
            Else
                PRONumber = reader.Item("PRONumber")
            End If
            If IsDBNull(reader.Item("ShippingAccountNumber")) Then
                ShippingAccountNumber = ""
            Else
                ShippingAccountNumber = reader.Item("ShippingAccountNumber")
            End If
            If IsDBNull(reader.Item("MinorShippingUnit")) Then
                MinorShippingUnit = ""
            Else
                MinorShippingUnit = reader.Item("MinorShippingUnit")
            End If
            If IsDBNull(reader.Item("MajorShippingUnit")) Then
                MajorShippingUnit = ""
            Else
                MajorShippingUnit = reader.Item("MajorShippingUnit")
            End If
            If IsDBNull(reader.Item("ClassRate")) Then
                ClassRate = ""
            Else
                ClassRate = reader.Item("ClassRate")
            End If
            If IsDBNull(reader.Item("CommodityType")) Then
                CommodityType = ""
            Else
                CommodityType = reader.Item("CommodityType")
            End If
            If IsDBNull(reader.Item("TotalMinorUnits")) Then
                TotalMinorUnits = 0
            Else
                TotalMinorUnits = reader.Item("TotalMinorUnits")
            End If
            If IsDBNull(reader.Item("TotalWeight")) Then
                TotalWeight = 0
            Else
                TotalWeight = reader.Item("TotalWeight")
            End If
            If IsDBNull(reader.Item("TotalMajorUnits")) Then
                TotalMajorUnits = 0
            Else
                TotalMajorUnits = reader.Item("TotalMajorUnits")
            End If
            If IsDBNull(reader.Item("DoubleStackedUnits")) Then
                DoubleStackedUnits = 0
            Else
                DoubleStackedUnits = reader.Item("DoubleStackedUnits")
            End If
            If IsDBNull(reader.Item("TotalUnitsOnFloor")) Then
                TotalUnitsOnFloor = 0
            Else
                TotalUnitsOnFloor = reader.Item("TotalUnitsOnFloor")
            End If
            If IsDBNull(reader.Item("FromCompanyName")) Then
                FromCompanyName = ""
            Else
                FromCompanyName = reader.Item("FromCompanyName")
            End If
            If IsDBNull(reader.Item("FromAddress1")) Then
                FromAddress1 = ""
            Else
                FromAddress1 = reader.Item("FromAddress1")
            End If
            If IsDBNull(reader.Item("FromAddress2")) Then
                FromAddress2 = ""
            Else
                FromAddress2 = reader.Item("FromAddress2")
            End If
            If IsDBNull(reader.Item("FromCity")) Then
                FromCity = ""
            Else
                FromCity = reader.Item("FromCity")
            End If
            If IsDBNull(reader.Item("FromState")) Then
                FromState = ""
            Else
                FromState = reader.Item("FromState")
            End If
            If IsDBNull(reader.Item("FromZipCode")) Then
                FromZipCode = ""
            Else
                FromZipCode = reader.Item("FromZipCode")
            End If
            If IsDBNull(reader.Item("FromCountry")) Then
                FromCountry = ""
            Else
                FromCountry = reader.Item("FromCountry")
            End If
            If IsDBNull(reader.Item("FromPhoneNumber")) Then
                FromPhoneNumber = ""
            Else
                FromPhoneNumber = reader.Item("FromPhoneNumber")
            End If
            If IsDBNull(reader.Item("ToCompanyName")) Then
                ToCompanyName = ""
            Else
                ToCompanyName = reader.Item("ToCompanyName")
            End If
            If IsDBNull(reader.Item("ToAddress1")) Then
                ToAddress1 = ""
            Else
                ToAddress1 = reader.Item("ToAddress1")
            End If
            If IsDBNull(reader.Item("ToAddress2")) Then
                ToAddress2 = ""
            Else
                ToAddress2 = reader.Item("ToAddress2")
            End If
            If IsDBNull(reader.Item("ToCity")) Then
                ToCity = ""
            Else
                ToCity = reader.Item("ToCity")
            End If
            If IsDBNull(reader.Item("ToState")) Then
                ToState = ""
            Else
                ToState = reader.Item("ToState")
            End If
            If IsDBNull(reader.Item("ToZipCode")) Then
                ToZipCode = ""
            Else
                ToZipCode = reader.Item("ToZipCode")
            End If
            If IsDBNull(reader.Item("ToPhoneNumber")) Then
                ToPhoneNumber = ""
            Else
                ToPhoneNumber = reader.Item("ToPhoneNumber")
            End If
            If IsDBNull(reader.Item("ToCountry")) Then
                ToCountry = ""
            Else
                ToCountry = reader.Item("ToCountry")
            End If
            If IsDBNull(reader.Item("ShipVia")) Then
                ShipVia = ""
            Else
                ShipVia = reader.Item("ShipVia")
            End If
            If IsDBNull(reader.Item("ShipMethod")) Then
                ShipMethod = ""
            Else
                ShipMethod = reader.Item("ShipMethod")
            End If
            If IsDBNull(reader.Item("ThirdPartyBilling")) Then
                ThirdPartyBilling = ""
            Else
                ThirdPartyBilling = reader.Item("ThirdPartyBilling")
            End If
            If IsDBNull(reader.Item("SpecialInstructions")) Then
                SpecialInstructions = ""
            Else
                SpecialInstructions = reader.Item("SpecialInstructions")
            End If
            If IsDBNull(reader.Item("FOB")) Then
                FOB = ""
            Else
                FOB = reader.Item("FOB")
            End If
        Else
            ShipmentDate = ""
            ShipmentNumber = ""
            CustomerPO = ""
            FreightQuoteNumber = ""
            PRONumber = ""
            ShippingAccountNumber = ""
            MinorShippingUnit = ""
            MajorShippingUnit = ""
            ClassRate = ""
            CommodityType = ""
            TotalMinorUnits = 0
            TotalWeight = 0
            TotalMajorUnits = 0
            DoubleStackedUnits = 0
            TotalUnitsOnFloor = 0
            FromCompanyName = ""
            FromAddress1 = ""
            FromAddress2 = ""
            FromCity = ""
            FromState = ""
            FromZipCode = ""
            FromPhoneNumber = ""
            FromCountry = ""
            ToCompanyName = ""
            ToAddress1 = ""
            ToAddress2 = ""
            ToCity = ""
            ToState = ""
            ToZipCode = ""
            ToPhoneNumber = ""
            ToCountry = 0
            ShipVia = 0
            ShipMethod = 0
            ThirdPartyBilling = 0
            SpecialInstructions = ""
            FOB = ""
        End If
        reader.Close()
        con.Close()

        dtpShipDate.Text = ShipmentDate
        txtShipmentNumber.Text = ShipmentNumber
        txtCustomerPO.Text = CustomerPO
        txtFreightQuoteNumber.Text = FreightQuoteNumber
        txtPRONUmber.Text = PRONumber
        txtFreightAccountNumber.Text = ShippingAccountNumber
        cboMinorUnits.Text = MinorShippingUnit
        cboMajorUnits.Text = MajorShippingUnit
        txtClassRate.Text = ClassRate
        cboCommodity.Text = CommodityType
        txtMinorUnits.Text = TotalMinorUnits
        txtTotalWeight.Text = TotalWeight
        txtMajorUnits.Text = TotalMajorUnits
        txtDoubleStacks.Text = DoubleStackedUnits
        txtTotalOnFloor.Text = TotalUnitsOnFloor
        txtFromCompanyName.Text = FromCompanyName
        txtFromAddress1.Text = FromAddress1
        txtFromAddress2.Text = FromAddress2
        txtFromCity.Text = FromCity
        txtFromState.Text = FromState
        txtFromZipCode.Text = FromZipCode
        txtFromPhoneNumber.Text = FromPhoneNumber
        txtFromCountry.Text = FromCountry
        txtToCompanyName.Text = ToCompanyName
        txtToAddress1.Text = ToAddress1
        txtToAddress2.Text = ToAddress2
        txtToCity.Text = ToCity
        txtToState.Text = ToState
        txtToZipCode.Text = ToZipCode
        txtToPhoneNumber.Text = ToPhoneNumber
        txtToCountry.Text = ToCountry
        cboShipVia.Text = ShipVia
        cboShipMethod.Text = ShipMethod
        txtThirdParty.Text = ThirdPartyBilling
        txtSpecialInstructions.Text = SpecialInstructions
        txtFOB.Text = FOB
    End Sub

    Private Sub cboMajorUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMajorUnits.SelectedIndexChanged
        Dim strMajorUnits As String = cboMajorUnits.Text

        Select Case strMajorUnits
            Case "PALLETS"
                lblMajorUnits.Text = "Number of Pallets"
                lblDoubleStack.Text = "Number of Double-Stacked Pallets"
                lblTotalOnFloor.Text = "Total Pallets on Floor"
            Case "METAL TUBS"
                lblMajorUnits.Text = "Number of Metal Tubs"
                lblDoubleStack.Text = "Number of Double-Stacked Metal Tubs"
                lblTotalOnFloor.Text = "Total Metal Tubs on Floor"
            Case Else
                lblMajorUnits.Text = "Number of Pallets"
                lblDoubleStack.Text = "Number of Double-Stacked Pallets"
                lblTotalOnFloor.Text = "Total Pallets on Floor"
        End Select
    End Sub

    Public Sub ValidateShippingMethod()
        ShipMethod = cboShipMethod.Text

        Select Case ShipMethod
            Case "COLLECT"
                CheckShippingMethod = ""
            Case "PREPAID"
                CheckShippingMethod = ""
            Case "PREPAID/ADD"
                CheckShippingMethod = ""
            Case "THIRD PARTY"
             
            Case "OTHER"
                CheckShippingMethod = ""
            Case Else
                MsgBox("You must select a valid Shipping Method", MsgBoxStyle.OkOnly)
                CheckShippingMethod = "EXIT SUB"
                cboShipMethod.Focus()
                Exit Sub
        End Select
    End Sub

    Public Sub GetThirdPartyBillingDataFromCustomer()
        Dim BillToNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToNameCommand As New SqlCommand(BillToNameStatement, con)
        BillToNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress1Statement As String = "SELECT BillToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
        BillToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress2Statement As String = "SELECT BillToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress2Command As New SqlCommand(BillToAddress2Statement, con)
        BillToAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToCityStatement As String = "SELECT BillToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToCityCommand As New SqlCommand(BillToCityStatement, con)
        BillToCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToStateStatement As String = "SELECT BillToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToStateCommand As New SqlCommand(BillToStateStatement, con)
        BillToStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToZipStatement As String = "SELECT BillToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToZipCommand As New SqlCommand(BillToZipStatement, con)
        BillToZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
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

        txtThirdParty.Text = BillToName + Environment.NewLine + BillToAddress1 + Environment.NewLine + BillToAddress2 + Environment.NewLine + BillToCity + ", " + BillToState + "  " + BillToZip
    End Sub

    Public Sub GetThirdPartyBillingDataFromVendor()
        Dim BillToNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim BillToNameCommand As New SqlCommand(BillToNameStatement, con)
        BillToNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        BillToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress1Statement As String = "SELECT VendorAddress1 FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
        BillToAddress1Command.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        BillToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress2Statement As String = "SELECT VendorAddress2 FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim BillToAddress2Command As New SqlCommand(BillToAddress2Statement, con)
        BillToAddress2Command.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        BillToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToCityStatement As String = "SELECT VendorCity FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim BillToCityCommand As New SqlCommand(BillToCityStatement, con)
        BillToCityCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        BillToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToStateStatement As String = "SELECT VendorState FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim BillToStateCommand As New SqlCommand(BillToStateStatement, con)
        BillToStateCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        BillToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToZipStatement As String = "SELECT VendorZip FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim BillToZipCommand As New SqlCommand(BillToZipStatement, con)
        BillToZipCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
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

        txtThirdParty.Text = BillToName + Environment.NewLine + BillToAddress1 + Environment.NewLine + BillToAddress2 + Environment.NewLine + BillToCity + ", " + BillToState + "  " + BillToZip
    End Sub

    Private Sub cboMinorUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMinorUnits.SelectedIndexChanged
        Dim strMinorUnits As String = cboMinorUnits.Text

        Select Case strMinorUnits
            Case "UNITS"
                lblMinorUnits.Text = "Number of minor units"
            Case "BOXES"
                lblMinorUnits.Text = "Number of Boxes"
            Case "BAGS"
                lblMinorUnits.Text = "Number of Bags"
            Case "CANS"
                lblMinorUnits.Text = "Number of Cans"
            Case Else
                lblMinorUnits.Text = "Number of minor units"
        End Select
    End Sub

    Private Sub chkLoadFromCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLoadFromCustomer.CheckedChanged
        If chkLoadFromCustomer.Checked = True Then
            chkLoadFromVendor.Checked = False
            cboVendorID.SelectedIndex = -1
            cboCustomerID.Enabled = True
        Else
            cboCustomerID.Enabled = False
            cboCustomerID.SelectedIndex = -1
        End If
    End Sub

    Private Sub chkLoadFromVendor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLoadFromVendor.CheckedChanged
        If chkLoadFromVendor.Checked = True Then
            chkLoadFromCustomer.Checked = False
            cboCustomerID.SelectedIndex = -1
            cboVendorID.Enabled = True
        Else
            cboVendorID.Enabled = False
            cboVendorID.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadBOLNumber()

        If chkDefaultAsDivision.Checked = True Then
            LoadDivisionData()
        End If
    End Sub

    Private Sub chkDefaultAsDivision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDefaultAsDivision.CheckedChanged
        If chkDefaultAsDivision.Checked = True Then
            LoadDivisionData()
        Else
            txtFromAddress1.Clear()
            txtFromAddress2.Clear()
            txtFromCity.Clear()
            txtFromCompanyName.Clear()
            txtFromCountry.Clear()
            txtFromPhoneNumber.Clear()
            txtFromState.Clear()
            txtFromZipCode.Clear()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerData()

        If cboShipMethod.Text = "THIRD PARTY" Then
            If cboCustomerID.Text <> "" Then
                GetThirdPartyBillingDataFromCustomer()
            ElseIf cboVendorID.Text <> "" Then
                GetThirdPartyBillingDataFromVendor()
            Else
                'Do not load third party billing data
            End If
        Else
            txtThirdParty.Clear()
        End If
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorData()
    End Sub

    Private Sub txtMajorUnits_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMajorUnits.TextChanged
        Dim MajorUnits As Integer = 0
        Dim DoubleStacks As Integer = 0
        Dim TotalUnitsOnFloor As Integer = 0

        MajorUnits = Val(txtMajorUnits.Text)
        DoubleStacks = Val(txtDoubleStacks.Text)
        TotalUnitsOnFloor = MajorUnits - DoubleStacks
        txtTotalOnFloor.Text = TotalUnitsOnFloor
    End Sub

    Private Sub txtDoubleStacks_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDoubleStacks.TextChanged
        Dim MajorUnits As Integer = 0
        Dim DoubleStacks As Integer = 0
        Dim TotalUnitsOnFloor As Integer = 0

        MajorUnits = Val(txtMajorUnits.Text)
        DoubleStacks = Val(txtDoubleStacks.Text)
        TotalUnitsOnFloor = MajorUnits - DoubleStacks
        txtTotalOnFloor.Text = TotalUnitsOnFloor
    End Sub

    Public Sub UpdateBOL()
        'Update Existing record in database
        cmd = New SqlCommand("UPDATE VendorBOLTable SET ShipmentDate = @ShipmentDate, ShipmentNumber = @ShipmentNumber, CustomerPO = @CustomerPO, FreightQuoteNumber = @FreightQuoteNumber, PRONumber = @PRONumber, ShippingAccountNumber = @ShippingAccountNumber, MinorShippingUnit = @MinorShippingUnit, MajorShippingUnit = @MajorShippingUnit, ClassRate = @ClassRate, CommodityType = @CommodityType, TotalMinorUnits = @TotalMinorUnits, TotalMajorUnits = @TotalMajorUnits, TotalWeight = @TotalWeight, DoubleStackedUnits = @DoubleStackedUnits, TotalUnitsOnFloor = @TotalUnitsOnFloor, FromCompanyName = @FromCompanyName, FromAddress1 = @FromAddress1, FromAddress2 = @FromAddress2, FromCity = @FromCity, FromState = @FromState, FromZipCode = @FromZipCode, FromPhoneNumber = @FromPhoneNumber, FromCountry = @FromCountry, ToCompanyName = @ToCompanyName, ToAddress1 = @ToAddress1, ToAddress2 = @ToAddress2, ToCity = @ToCity, ToState = @ToState, ToZipCode = @ToZipCode, ToPhoneNumber = @ToPhoneNumber, ToCountry = @ToCountry, ShipVia = @ShipVia, ShipMethod = @ShipMethod, ThirdPartyBilling = @ThirdPartyBilling, SpecialInstructions = @SpecialInstructions, FOB = @FOB WHERE DivisionID = @DivisionID AND VendorBOLNumber = @VendorBOLNumber", con)

        With cmd.Parameters
            .Add("@VendorBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
            .Add("@ShipmentDate", SqlDbType.VarChar).Value = dtpShipDate.Text
            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = txtShipmentNumber.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
            .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
            .Add("@PRONumber", SqlDbType.VarChar).Value = txtPRONUmber.Text
            .Add("@ShippingAccountNumber", SqlDbType.VarChar).Value = txtFreightAccountNumber.Text
            .Add("@MinorShippingUnit", SqlDbType.VarChar).Value = cboMinorUnits.Text
            .Add("@MajorShippingUnit", SqlDbType.VarChar).Value = cboMajorUnits.Text
            .Add("@ClassRate", SqlDbType.VarChar).Value = txtClassRate.Text
            .Add("@CommodityType", SqlDbType.VarChar).Value = cboCommodity.Text
            .Add("@TotalMinorUnits", SqlDbType.VarChar).Value = Val(txtMinorUnits.Text)
            .Add("@TotalMajorUnits", SqlDbType.VarChar).Value = Val(txtMajorUnits.Text)
            .Add("@TotalWeight", SqlDbType.VarChar).Value = Val(txtTotalWeight.Text)
            .Add("@DoubleStackedUnits", SqlDbType.VarChar).Value = Val(txtDoubleStacks.Text)
            .Add("@TotalUnitsOnFloor", SqlDbType.VarChar).Value = Val(txtTotalOnFloor.Text)
            .Add("@FromCompanyName", SqlDbType.VarChar).Value = txtFromCompanyName.Text
            .Add("@FromAddress1", SqlDbType.VarChar).Value = txtFromAddress1.Text
            .Add("@FromAddress2", SqlDbType.VarChar).Value = txtFromAddress2.Text
            .Add("@FromCity", SqlDbType.VarChar).Value = txtFromCity.Text
            .Add("@FromState", SqlDbType.VarChar).Value = txtFromState.Text
            .Add("@FromZipCode", SqlDbType.VarChar).Value = txtFromZipCode.Text
            .Add("@FromPhoneNumber", SqlDbType.VarChar).Value = txtFromPhoneNumber.Text
            .Add("@FromCountry", SqlDbType.VarChar).Value = txtFromCountry.Text
            .Add("@ToCompanyName", SqlDbType.VarChar).Value = txtToCompanyName.Text
            .Add("@ToAddress1", SqlDbType.VarChar).Value = txtToAddress1.Text
            .Add("@ToAddress2", SqlDbType.VarChar).Value = txtToAddress2.Text
            .Add("@ToCity", SqlDbType.VarChar).Value = txtToCity.Text
            .Add("@ToState", SqlDbType.VarChar).Value = txtToState.Text
            .Add("@ToZipCode", SqlDbType.VarChar).Value = txtToZipCode.Text
            .Add("@ToPhoneNumber", SqlDbType.VarChar).Value = txtToPhoneNumber.Text
            .Add("@ToCountry", SqlDbType.VarChar).Value = txtToCountry.Text
            .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
            .Add("@ShipMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            .Add("@ThirdPartyBilling", SqlDbType.VarChar).Value = txtThirdParty.Text
            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
            .Add("@FOB", SqlDbType.VarChar).Value = txtFOB.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdSaveBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveBOL.Click
        If cboBOLNumber.Text = "" Or Val(cboBOLNumber.Text) = 0 Then
            MsgBox("You must have a valid BOL # selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Update existing record in database
        Try
            UpdateBOL()

            MsgBox("BOL has been saved.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'Error Check

        End Try
    End Sub

    Private Sub cboBOLNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBOLNumber.SelectedIndexChanged
        LoadBOLData()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
    End Sub

    Private Sub cmdPrintBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintBOL.Click
        UpdateBOL()

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
            GlobalVendorBOLNumber = Val(cboBOLNumber.Text)

            Using NewVendorBOLForm As New PrintVendorBOLRemote
                Dim Result = NewVendorBOLForm.ShowDialog()
            End Using
        Else
            GlobalVendorBOLNumber = Val(cboBOLNumber.Text)

            Using NewVendorBOLForm As New PrintVendorBOL
                Dim Result = NewVendorBOLForm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub SaveBOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBOLToolStripMenuItem.Click
        cmdSaveBOL_Click(sender, e)
    End Sub

    Private Sub PrintBOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBOLToolStripMenuItem.Click
        cmdPrintBOL_Click(sender, e)
    End Sub

    Private Sub cboShipMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipMethod.SelectedIndexChanged
        If cboShipMethod.Text = "THIRD PARTY" Then
            If cboCustomerID.Text <> "" Then
                GetThirdPartyBillingDataFromCustomer()
            ElseIf cboVendorID.Text <> "" Then
                GetThirdPartyBillingDataFromVendor()
            Else
                'Do not load third party billing data
            End If
        Else
            txtThirdParty.Clear()
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboBOLNumber.Text <> "" Then
            'Delete from the database
            cmd = New SqlCommand("DELETE FROM VendorBOLTable WHERE VendorBOLNumber = @VendorBOLNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VendorBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Bill of Lading deleted.", MsgBoxStyle.OkOnly)

            LoadBOLNumber()
            ClearData()
        Else
            MsgBox("You must select a valid BOL #.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    Private Sub DeleteBOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBOLToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        cmdClear_Click(sender, e)
    End Sub
End Class