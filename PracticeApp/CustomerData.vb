Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.Net.Mail
Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Public Class CustomerData
    Inherits System.Windows.Forms.Form

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer

    Dim FormName As String = "Customer Maintenance"
    Dim SalesTaxStatus, ValidateCustomerForBadCharacters, CustomerBankAccount, BillingType, AccountingHold, SalesTaxID, CustomerClassType, SalesTerritory, CustomerClass, CustomerName, Comments, PaymentTerms, PreferredShipper, OldCustomerNumber As String
    Dim ShippingAccountNumber, ShippingInstructions, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, ShipEmail As String
    Dim BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry, InvoiceEmail, InvoiceCertEmail, APContactName As String
    Dim SalesTaxRate, SalesTaxRate2, SalesTaxRate3, CreditLimit, SalesTotal, AverageTotal As Double
    Dim CheckAddShipTo, ShippingDetails, PricingLevel, OnHoldStatus, AddName, ContactName, ContactEmail, ContactPhone, ContactFax, Address1, Address2, City, State, Zip, Country As String
    Dim AROutstanding, ARLessThan30, AR31To45, AR46To60, AR61To90, AROver91 As Double
    Dim LastActivityDate As Date
    Dim CheckDeleteSalesOrder As Integer = 0
    Dim CheckPaymentTerms As Integer = 0
    Dim CustomerActivitySummation As Integer = 0
    Dim SalesContactEmail, ConfirmationEmail, CertEmail, StatementEmail, PackingListEmail As String

    'Variables to calculate MTD and YTD Sales
    Dim YearDate, MonthDate, BeginDate, EndDate, CustomerDate As Date
    Dim YearOfYear, MonthOfYear, Year As Integer
    Dim strMonthOfYear, strYear As String
    Dim MTDSales, YTDSales As Double
    Dim APPhoneNumber, APFAXNumber, APEmailAddress As String
    Dim GetSalesTerritory As String = ""

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    'Setup for barcode
    Dim LabelFormat(70), V00, V01, V02, V03, V04, V05, V06, V07, V08, V09, V10, V11, V12, V13, V14, V15, V16, V17, V18, V19, V20, V21, V22, V23, V24, V25, V26, V27, V28, VDATA, VDATA1, VBAR, VBAR1 As String
    Dim LabelLines, BarCodeType, NumberOfLables As Integer

    Dim shouldSave As Boolean = False
    Dim shouldSaveAddress As Boolean = False
    Dim shouldSaveContact As Boolean = False
    Dim SaveButtonPressed As String = "NO"

    'Form Operations

    Private Sub CustomerData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()

        'Form Login
        FormLoginRoutine()

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.SalesTerritoryQuery' table. You can move, or remove it, as needed.
        Me.SalesTerritoryQueryTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.SalesTerritoryQuery)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)

        LoadBillToCountry()
        LoadShipToCountry()
        LoadAddShipToCountry()
        LoadCurrentDivision()

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Or EmployeeSecurityCode = 1003 Or EmployeeLoginName = "DPANEK" Then
            chkCreditHold.Enabled = True
            chkAccountingHold.Enabled = True
        ElseIf EmployeeSecurityCode = 1014 Then
            chkCreditHold.Enabled = True
            chkAccountingHold.Enabled = False
        Else
            chkCreditHold.Enabled = False
            chkAccountingHold.Enabled = False
        End If

        'Select Security Settings
        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Or EmployeeLoginName = "JBASSETTI" Or EmployeeLoginName = "KPREST" Then
            cboBankAccount.Enabled = True
            CustomerHoldReportAutoprintToolStripMenuItem.Enabled = True
        Else
            cboBankAccount.Enabled = False
            CustomerHoldReportAutoprintToolStripMenuItem.Enabled = False
        End If

        If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
            cboCustomerClass.Text = "CANADIAN"
        Else
            cboCustomerClass.Text = "STANDARD"
        End If

        If GlobalCustomerID = "" Then
            cboCustomerID.SelectedIndex = -1
        Else
            cboCustomerID.Text = GlobalCustomerID
        End If
    End Sub

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), &HF060, 1)
            Case &HFFFFFFFF
        End Select
    End Sub

    Private Sub CustomerData_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    Private Sub CustomerData_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalCustomerID = ""
        GlobalCustomerName = ""
        GlobalCustomerID2 = ""
        ClearVariables()
        ClearData()
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

    'Load Datasets into controls

    Public Sub ShowAdditionalShipTo()
        cmd = New SqlCommand("SELECT ShipToID FROM AdditionalShipTo WHERE CustomerID = @CustomerID And DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "AdditionalShipTo")
        cboShipToID.DataSource = ds1.Tables("AdditionalShipTo")
        con.Close()
        cboShipToID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerContacts()
        cmd = New SqlCommand("SELECT ContactDepartment FROM CustomerContacts WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerContacts")
        cboContactDepartment.DataSource = ds2.Tables("CustomerContacts")
        con.Close()
        cboContactDepartment.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerList()
        'Loads Customer List for the specific division
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerID ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        cboCustomerID.DataSource = ds3.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        'Loads Customer List for the specific division
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerName ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "CustomerList")
        cboCustomerName.DataSource = ds6.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerClass()
        'Loads Customer List for the specific division
        cmd = New SqlCommand("SELECT CustomerClassID FROM CustomerClass WHERE DivisionID = @DivisionID AND Status = @Status", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerClass")
        cboCustomerClass.DataSource = ds4.Tables("CustomerClass")
        con.Close()
        cboCustomerClass.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerContactList()
        cmd = New SqlCommand("SELECT * FROM CustomerContacts WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "CustomerContacts")
        dgvCustomerContacts.DataSource = ds5.Tables("CustomerContacts")
        con.Close()
    End Sub

    Public Sub LoadBillToCountry()
        cmd = New SqlCommand("SELECT Country FROM CountryCodes", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "CountryCodes")
        cboCountryList.DataSource = ds6.Tables("CountryCodes")
        con.Close()
        cboCountryList.SelectedIndex = -1
    End Sub

    Public Sub LoadShipToCountry()
        cmd = New SqlCommand("SELECT Country FROM CountryCodes", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "CountryCodes")
        cboShipToCountry.DataSource = ds7.Tables("CountryCodes")
        con.Close()
        cboShipToCountry.SelectedIndex = -1
    End Sub

    Public Sub LoadAddShipToCountry()
        cmd = New SqlCommand("SELECT Country FROM CountryCodes", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd
        myAdapter8.Fill(ds8, "CountryCodes")
        cboAddShipToCountry.DataSource = ds8.Tables("CountryCodes")
        con.Close()
        cboAddShipToCountry.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerHoldList()
        'Loads Customer List for the specific division
        cmd = New SqlCommand("SELECT * FROM CustomerHoldList", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds9 = New DataSet()
        myAdapter9.SelectCommand = cmd
        myAdapter9.Fill(ds9, "CustomerHoldList")
        con.Close()
    End Sub

    'Load Statements to fill fields

    Public Sub LoadBTCountryByCountryCode()
        Dim LoadBTCountry As String = ""

        Dim LoadCountryStatement As String = "SELECT Country FROM CountryCodes WHERE CountryCode = @CountryCode"
        Dim LoadCountryCommand As New SqlCommand(LoadCountryStatement, con)
        LoadCountryCommand.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = txtBTCountry.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadBTCountry = CStr(LoadCountryCommand.ExecuteScalar)
        Catch ex As Exception
            LoadBTCountry = ""
        End Try
        con.Close()

        cboCountryList.Text = LoadBTCountry
    End Sub

    Public Sub LoadBTCountryCodeByCountry()
        Dim LoadBTCountryCode As String = ""

        Dim LoadCountryCodeStatement As String = "SELECT CountryCode FROM CountryCodes WHERE Country = @Country"
        Dim LoadCountryCodeCommand As New SqlCommand(LoadCountryCodeStatement, con)
        LoadCountryCodeCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = cboCountryList.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadBTCountryCode = CStr(LoadCountryCodeCommand.ExecuteScalar)
        Catch ex As Exception
            LoadBTCountryCode = ""
        End Try
        con.Close()

        txtBTCountry.Text = LoadBTCountryCode
    End Sub

    Public Sub LoadSTCountryByCountryCode()
        Dim LoadSTCountry As String = ""

        Dim LoadCountryStatement As String = "SELECT Country FROM CountryCodes WHERE CountryCode = @CountryCode"
        Dim LoadCountryCommand As New SqlCommand(LoadCountryStatement, con)
        LoadCountryCommand.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = txtSTCountry.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadSTCountry = CStr(LoadCountryCommand.ExecuteScalar)
        Catch ex As Exception
            LoadSTCountry = ""
        End Try
        con.Close()

        cboShipToCountry.Text = LoadSTCountry
    End Sub

    Public Sub LoadSTCountryCodeByCountry()
        Dim LoadSTCountryCode As String = ""

        Dim LoadCountryCodeStatement As String = "SELECT CountryCode FROM CountryCodes WHERE Country = @Country"
        Dim LoadCountryCodeCommand As New SqlCommand(LoadCountryCodeStatement, con)
        LoadCountryCodeCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = cboShipToCountry.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadSTCountryCode = CStr(LoadCountryCodeCommand.ExecuteScalar)
        Catch ex As Exception
            LoadSTCountryCode = ""
        End Try
        con.Close()

        txtSTCountry.Text = LoadSTCountryCode
    End Sub

    Public Sub LoadAddSTCountryByCountryCode()
        Dim LoadAddSTCountry As String = ""

        Dim LoadAddCountryStatement As String = "SELECT Country FROM CountryCodes WHERE CountryCode = @CountryCode"
        Dim LoadAddCountryCommand As New SqlCommand(LoadAddCountryStatement, con)
        LoadAddCountryCommand.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = txtAddCountry.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadAddSTCountry = CStr(LoadAddCountryCommand.ExecuteScalar)
        Catch ex As Exception
            LoadAddSTCountry = ""
        End Try
        con.Close()

        cboAddShipToCountry.Text = LoadAddSTCountry
    End Sub

    Public Sub LoadAddSTCountryCodeByCountry()
        Dim LoadAddSTCountryCode As String = ""

        Dim LoadAddCountryCodeStatement As String = "SELECT CountryCode FROM CountryCodes WHERE Country = @Country"
        Dim LoadAddCountryCodeCommand As New SqlCommand(LoadAddCountryCodeStatement, con)
        LoadAddCountryCodeCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = cboAddShipToCountry.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadAddSTCountryCode = CStr(LoadAddCountryCodeCommand.ExecuteScalar)
        Catch ex As Exception
            LoadAddSTCountryCode = ""
        End Try
        con.Close()

        txtAddCountry.Text = LoadAddSTCountryCode
    End Sub

    Public Sub LoadSalesTaxDefaults()
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LabelTax1.Text = "Canadian GST"
            LabelTax2.Text = "Canadian PST"
            LabelTax3.Text = "Canadian HST"

            chkAddGST.Visible = True
            chkAddHST.Visible = True
            chkAddPST.Visible = True

            LabelTax1.Visible = True
            LabelTax2.Visible = True
            LabelTax2.Visible = True

            txtSalesTaxRate.Visible = True
            txtSalesTaxRate2.Visible = True
            txtSalesTaxRate3.Visible = True

            txtSalesTaxRate.Enabled = False
            txtSalesTaxRate2.Enabled = False
            txtSalesTaxRate3.Enabled = True
            LabelTax4.Text = "Select appropriate check boxes to add taxes to Canadian Customers."
        Else
            LabelTax1.Text = "Sales Tax Rate"
            chkAddGST.Visible = False
            chkAddHST.Visible = False
            chkAddPST.Visible = False

            LabelTax1.Visible = True
            LabelTax2.Visible = False
            LabelTax3.Visible = False

            txtSalesTaxRate.Visible = True
            txtSalesTaxRate2.Visible = False
            txtSalesTaxRate3.Visible = False

            txtSalesTaxRate.Enabled = True
            txtSalesTaxRate2.Enabled = False
            txtSalesTaxRate3.Enabled = False
            LabelTax4.Text = "Add sales tax rate into textbox. Leave blank or add 0 for non-taxable customers."
        End If
    End Sub

    Public Sub LoadCustomerAPData()
        Dim APContactNameStatement As String = "SELECT APContactName, APPhoneNumber, APFAXNumber, APEmailAddress, InvoiceEmail, InvoiceCertEmail FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
        Dim APContactNameCommand As New SqlCommand(APContactNameStatement, con)
        APContactNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        APContactNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = APContactNameCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("APContactName")) Then
                APContactName = ""
            Else
                APContactName = reader.Item("APContactName")
            End If
            If IsDBNull(reader.Item("APPhoneNumber")) Then
                APPhoneNumber = ""
            Else
                APPhoneNumber = reader.Item("APPhoneNumber")
            End If
            If IsDBNull(reader.Item("APFAXNumber")) Then
                APFAXNumber = ""
            Else
                APFAXNumber = reader.Item("APFAXNumber")
            End If
            If IsDBNull(reader.Item("APEmailAddress")) Then
                APEmailAddress = ""
            Else
                APEmailAddress = reader.Item("APEmailAddress")
            End If
            If IsDBNull(reader.Item("InvoiceEmail")) Then
                InvoiceEmail = ""
            Else
                InvoiceEmail = reader.Item("InvoiceEmail")
            End If
            If IsDBNull(reader.Item("InvoiceCertEmail")) Then
                InvoiceCertEmail = ""
            Else
                InvoiceCertEmail = reader.Item("InvoiceCertEmail")
            End If
        Else
            APContactName = ""
            APPhoneNumber = ""
            APFAXNumber = ""
            APEmailAddress = ""
            InvoiceEmail = ""
            InvoiceCertEmail = ""
        End If
        reader.Close()
        con.Close()

        txtAPContactName.Text = APContactName
        txtAPPhoneNumber.Text = APPhoneNumber
        txtAPFaxNumber.Text = APFAXNumber
        txtAPEmailAddress.Text = APEmailAddress
        txtInvoiceEmail.Text = InvoiceEmail
        txtInvoiceCertEmail.Text = InvoiceCertEmail
    End Sub

    Private Sub LoadAVGDaysToPay()
        cmd = New SqlCommand("SELECT InvoiceDate, PaymentDate FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        Dim inv As New DateTime
        Dim pd As New DateTime
        Dim count As Integer = 0
        Dim totDays As Double = 0

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                inv = reader.GetValue(0)
                pd = reader.GetValue(1)
                totDays += pd.Date.Subtract(inv.Date).TotalDays()
                count += 1
            End While
        End If
        reader.Close()
        con.Close()

        totDays = Math.Round(totDays / count, 0)
        If count > 0 Then
            lblAVGDaysToPay.Text = totDays.ToString()
        Else
            lblAVGDaysToPay.Text = "No Payment History"
        End If
    End Sub

    Public Sub LoadContactDetails()
        'Extract data from source table
        Dim ContactNameString As String = "SELECT ContactName, ContactEmail, ContactPhone, ContactFax FROM CustomerContacts WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID And ContactDepartment = @ContactDepartment"
        Dim ContactNameCommand As New SqlCommand(ContactNameString, con)
        ContactNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ContactNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ContactNameCommand.Parameters.Add("@ContactDepartment", SqlDbType.VarChar).Value = cboContactDepartment.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = ContactNameCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ContactName")) Then
                ContactName = ""
            Else
                ContactName = reader.Item("ContactName")
            End If
            If IsDBNull(reader.Item("ContactEmail")) Then
                ContactEmail = ""
            Else
                ContactEmail = reader.Item("ContactEmail")
            End If
            If IsDBNull(reader.Item("ContactPhone")) Then
                ContactPhone = ""
            Else
                ContactPhone = reader.Item("ContactPhone")
            End If
            If IsDBNull(reader.Item("ContactFax")) Then
                ContactFax = ""
            Else
                ContactFax = reader.Item("ContactFax")
            End If
        Else
            ContactName = ""
            ContactEmail = ""
            ContactPhone = ""
            ContactFax = ""
        End If
        reader.Close()
        con.Close()

        txtContactEmail.Text = ContactEmail
        txtContactFax.Text = ContactFax
        txtContactName.Text = ContactName
        txtContactPhone.Text = ContactPhone
    End Sub

    Public Sub LoadCustomerData()
        'Extract data from source table
        Dim GetCustomerDataString As String = "SELECT * FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetCustomerDataCommand As New SqlCommand(GetCustomerDataString, con)
        GetCustomerDataCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        GetCustomerDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetCustomerDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CustomerName")) Then
                CustomerName = ""
            Else
                CustomerName = reader.Item("CustomerName")
            End If
            If IsDBNull(reader.Item("CustomerDate")) Then
                CustomerDate = dtpCustomerSince.Value
            Else
                CustomerDate = reader.Item("CustomerDate")
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
            If IsDBNull(reader.Item("BillToAddress1")) Then
                BillToAddress1 = ""
            Else
                BillToAddress1 = reader.Item("BillToAddress1")
            End If
            If IsDBNull(reader.Item("BillToAddress2")) Then
                BillToAddress2 = ""
            Else
                BillToAddress2 = reader.Item("BillToAddress2")
            End If
            If IsDBNull(reader.Item("BillToCity")) Then
                BillToCity = ""
            Else
                BillToCity = reader.Item("BillToCity")
            End If
            If IsDBNull(reader.Item("BillToState")) Then
                BillToState = ""
            Else
                BillToState = reader.Item("BillToState")
            End If
            If IsDBNull(reader.Item("BillToZip")) Then
                BillToZip = ""
            Else
                BillToZip = reader.Item("BillToZip")
            End If
            If IsDBNull(reader.Item("BillToCountry")) Then
                BillToCountry = ""
            Else
                BillToCountry = reader.Item("BillToCountry")
            End If
            If IsDBNull(reader.Item("Comments")) Then
                Comments = ""
            Else
                Comments = reader.Item("Comments")
            End If
            If IsDBNull(reader.Item("PaymentTerms")) Then
                PaymentTerms = ""
            Else
                PaymentTerms = reader.Item("PaymentTerms")
            End If
            If IsDBNull(reader.Item("CreditLimit")) Then
                CreditLimit = 0
            Else
                CreditLimit = reader.Item("CreditLimit")
            End If
            If IsDBNull(reader.Item("SalesTaxRate")) Then
                SalesTaxRate = 0
            Else
                SalesTaxRate = reader.Item("SalesTaxRate")
            End If
            If IsDBNull(reader.Item("SalesTaxRate2")) Then
                SalesTaxRate2 = 0
            Else
                SalesTaxRate2 = reader.Item("SalesTaxRate2")
            End If
            If IsDBNull(reader.Item("SalesTaxRate3")) Then
                SalesTaxRate3 = 0
            Else
                SalesTaxRate3 = reader.Item("SalesTaxRate3")
            End If
            If IsDBNull(reader.Item("SalesTaxID")) Then
                SalesTaxID = ""
            Else
                SalesTaxID = reader.Item("SalesTaxID")
            End If
            If IsDBNull(reader.Item("PreferredShipper")) Then
                PreferredShipper = "DELIVERY"
            Else
                PreferredShipper = reader.Item("PreferredShipper")
            End If
            If IsDBNull(reader.Item("OldCustomerNumber")) Then
                OldCustomerNumber = ""
            Else
                OldCustomerNumber = reader.Item("OldCustomerNumber")
            End If
            If IsDBNull(reader.Item("CustomerClass")) Then
                CustomerClass = ""
            Else
                CustomerClass = reader.Item("CustomerClass")
            End If
            If IsDBNull(reader.Item("SalesTerritory")) Then
                SalesTerritory = ""
            Else
                SalesTerritory = reader.Item("SalesTerritory")
            End If
            If IsDBNull(reader.Item("OnHoldStatus")) Then
                OnHoldStatus = "NO"
            Else
                OnHoldStatus = reader.Item("OnHoldStatus")
            End If
            If IsDBNull(reader.Item("ShippingDetails")) Then
                ShippingDetails = ""
            Else
                ShippingDetails = reader.Item("ShippingDetails")
            End If
            If IsDBNull(reader.Item("AccountingHold")) Then
                AccountingHold = "NO"
            Else
                AccountingHold = reader.Item("AccountingHold")
            End If
            If IsDBNull(reader.Item("PricingLevel")) Then
                PricingLevel = ""
            Else
                PricingLevel = reader.Item("PricingLevel")
            End If
            If IsDBNull(reader.Item("BillingType")) Then
                BillingType = ""
            Else
                BillingType = reader.Item("BillingType")
            End If
            If IsDBNull(reader.Item("ShipEmail")) Then
                ShipEmail = ""
            Else
                ShipEmail = reader.Item("ShipEmail")
            End If
            If IsDBNull(reader.Item("ShippingAccount")) Then
                ShippingAccountNumber = ""
            Else
                ShippingAccountNumber = reader.Item("ShippingAccount")
            End If
            If IsDBNull(reader.Item("BankAccount")) Then
                CustomerBankAccount = ""
            Else
                CustomerBankAccount = reader.Item("BankAccount")
            End If
            If IsDBNull(reader.Item("ConfirmationEmail")) Then
                ConfirmationEmail = ""
            Else
                ConfirmationEmail = reader.Item("ConfirmationEmail")
            End If
            If IsDBNull(reader.Item("StatementEmail")) Then
                StatementEmail = ""
            Else
                StatementEmail = reader.Item("StatementEmail")
            End If
            If IsDBNull(reader.Item("PackingListEmail")) Then
                PackingListEmail = ""
            Else
                PackingListEmail = reader.Item("PackingListEmail")
            End If
            If IsDBNull(reader.Item("CertEmail")) Then
                CertEmail = ""
            Else
                CertEmail = reader.Item("CertEmail")
            End If
            If IsDBNull(reader.Item("SalesContactEmail")) Then
                SalesContactEmail = ""
            Else
                SalesContactEmail = reader.Item("SalesContactEmail")
            End If
            If IsDBNull(reader.Item("SalesTaxStatus")) Then
                SalesTaxStatus = ""
            Else
                SalesTaxStatus = reader.Item("SalesTaxStatus")
            End If
        Else
            CustomerName = ""
            CustomerDate = dtpCustomerSince.Value
            ShipToAddress1 = ""
            ShipToAddress2 = ""
            ShipToCity = ""
            ShipToState = ""
            ShipToZip = ""
            ShipToCountry = ""
            BillToAddress1 = ""
            BillToAddress2 = ""
            BillToCity = ""
            BillToState = ""
            BillToZip = ""
            BillToCountry = ""
            Comments = ""
            PaymentTerms = ""
            CreditLimit = 0
            SalesTaxRate = 0
            PreferredShipper = "DELIVERY"
            OldCustomerNumber = ""
            CustomerClass = ""
            SalesTerritory = ""
            OnHoldStatus = "NO"
            ShippingDetails = ""
            SalesTaxRate2 = 0
            SalesTaxRate3 = 0
            SalesTaxID = ""
            AccountingHold = "NO"
            PricingLevel = ""
            BillingType = "STANDARD"
            ShipEmail = ""
            ShippingAccountNumber = ""
            CustomerBankAccount = ""
            ConfirmationEmail = ""
            StatementEmail = ""
            CertEmail = ""
            PackingListEmail = ""
            SalesContactEmail = ""
            SalesTaxStatus = "TAXABLE"
        End If
        reader.Close()
        con.Close()

        CustomerDate = CustomerDate.ToShortDateString

        cboCustomerName.Text = CustomerName
        dtpCustomerSince.Text = CustomerDate
        txtSTAddress1.Text = ShipToAddress1
        txtSTAddress2.Text = ShipToAddress2
        txtSTCity.Text = ShipToCity
        txtSTZip.Text = ShipToZip
        txtSTCountry.Text = ShipToCountry
        cboSTState.Text = ShipToState
        txtShipEmail.Text = ShipEmail
        txtBTAddress1.Text = BillToAddress1
        txtBTAddress2.Text = BillToAddress2
        txtBTCity.Text = BillToCity
        txtBTCountry.Text = BillToCountry
        txtBTZip.Text = BillToZip
        cboBTState.Text = BillToState
        txtCustomerComment.Text = Comments
        txtCreditLimit.Text = CreditLimit
        lblCreditLimit.Text = FormatCurrency(CreditLimit, 2)
        txtSalesTaxRate.Text = SalesTaxRate
        cboShipper.Text = PreferredShipper
        txtOldCustomerNumber.Text = OldCustomerNumber
        cboCustomerClass.Text = CustomerClass
        txtSalesTerritory.Text = SalesTerritory
        txtShippingInstructions.Text = ShippingDetails
        txtPricingReview.Text = PricingLevel
        cboBillingType.Text = BillingType
        txtShippingAccount.Text = ShippingAccountNumber
        txtEmailStatements.Text = StatementEmail
        txtEmailConfirmations.Text = ConfirmationEmail
        txtEmailCerts.Text = CertEmail
        txtEmailPackingLists.Text = PackingListEmail
        txtSalesContactEmail.Text = SalesContactEmail
        cboSalesTaxStatus.Text = SalesTaxStatus
        cboPaymentTerms.Text = PaymentTerms

        'Lock Payments terms
        If cboCustomerID.Text <> "" Then
            If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Or EmployeeSecurityCode = 1003 Or EmployeeSecurityCode = 1014 Or EmployeeLoginName = "DPANEK" Then
                cboPaymentTerms.Enabled = True
            Else
                cboPaymentTerms.Enabled = False
            End If
        Else
            cboPaymentTerms.Enabled = True
        End If

        If PaymentTerms = "CREDIT CARD" Or PaymentTerms = "COD" Or PaymentTerms = "Prepaid" Or PaymentTerms = "NetDue" Then
            cboPaymentTerms.Enabled = True
        End If

        'Load Tax Exempt cert message
        If cboSalesTaxStatus.Text = "EXEMPT" Then
            LoadTaxExemptCert()
        Else
            lblTaxExempt.Visible = False
        End If

        If CustomerBankAccount = "" Then
            If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
                CustomerBankAccount = "Checking"
            ElseIf cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                CustomerBankAccount = "Canadian Checking"
            Else
                CustomerBankAccount = "Cash Receipts"
            End If
        End If

        cboBankAccount.Text = CustomerBankAccount

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            If SalesTerritory = "" Then
                cboSalesTerritory.Text = ""
            Else
                Dim GetSalesTerritoryStatement As String = "SELECT TerritoryDescription FROM SalesTerritoryQuery WHERE TerritoryID = @TerritoryID"
                Dim GetSalesTerritoryCommand As New SqlCommand(GetSalesTerritoryStatement, con)
                GetSalesTerritoryCommand.Parameters.Add("@TerritoryID", SqlDbType.VarChar).Value = SalesTerritory
                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSalesTerritory = CStr(GetSalesTerritoryCommand.ExecuteScalar)
                Catch ex As Exception
                    GetSalesTerritory = ""
                End Try
                con.Close()

                cboSalesTerritory.Text = GetSalesTerritory
            End If
        End If

        txtSalesTaxRate3.Text = SalesTaxRate3
        txtTaxID.Text = SalesTaxID

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            If SalesTaxRate > 0 Then
                chkAddGST.Checked = True
                txtSalesTaxRate.Text = SalesTaxRate
            Else
                chkAddGST.Checked = False
                txtSalesTaxRate.Text = 0
            End If
            If SalesTaxRate2 > 0 Then
                chkAddPST.Checked = True
                txtSalesTaxRate2.Text = SalesTaxRate2
            Else
                chkAddPST.Checked = False
                txtSalesTaxRate2.Text = 0
            End If
            If SalesTaxRate3 > 0 Then
                chkAddHST.Checked = True
                txtSalesTaxRate3.Text = SalesTaxRate3
            Else
                chkAddHST.Checked = False
                txtSalesTaxRate3.Text = 0
            End If
        End If

        If cboBillingType.Text = "" Then
            cboBillingType.Text = "STANDARD"
        Else
            'Do nothing
        End If

        If OnHoldStatus = "YES" Then
            chkCreditHold.Checked = True
            lblHoldBanner.Text = "Customer is on Credit Hold"
        Else
            chkCreditHold.Checked = False
            lblHoldBanner.Text = ""
        End If

        If AccountingHold = "YES" Then
            chkAccountingHold.Checked = True
            lblHoldBanner.Text = "Customer is on Accounting Hold"
        Else
            chkAccountingHold.Checked = False
            lblHoldBanner.Text = ""
        End If
    End Sub

    Public Sub LoadAdditionalShiptoDetails()
        'Extract data from source table
        Dim Address1String As String = "SELECT * FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID And ShipToID = @ShipToID"
        Dim Address1Command As New SqlCommand(Address1String, con)
        Address1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        Address1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Address1Command.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = Address1Command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Address1")) Then
                Address1 = ""
            Else
                Address1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                Address2 = ""
            Else
                Address2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                City = ""
            Else
                City = reader.Item("City")
            End If
            If IsDBNull(reader.Item("State")) Then
                State = ""
            Else
                State = reader.Item("State")
            End If
            If IsDBNull(reader.Item("Zip")) Then
                Zip = ""
            Else
                Zip = reader.Item("Zip")
            End If
            If IsDBNull(reader.Item("Country")) Then
                Country = ""
            Else
                Country = reader.Item("Country")
            End If
            If IsDBNull(reader.Item("Name")) Then
                AddName = ""
            Else
                AddName = reader.Item("Name")
            End If
        Else
            Address1 = ""
            Address2 = ""
            City = ""
            State = ""
            Zip = ""
            Country = ""
            AddName = ""
        End If
        reader.Close()
        con.Close()

        'Load data into text boxes
        txtAddAddress1.Text = Address1
        txtAddAddress2.Text = Address2
        txtAddCity.Text = City
        txtAddCountry.Text = Country
        txtAddZip.Text = Zip
        cboAddState.Text = State
        txtAddShipToName.Text = AddName
        cmdSaveAdditionalShipTo.Focus()
    End Sub

    Public Sub LoadCustomerARAging()
        Dim AgingLessThan30String As String = "SELECT SUM(AgingLessThan30), SUM(Aging31To45), SUM(Aging46To60), SUM(Aging61To90), SUM(AgingMoreThan90) FROM ARAgingCategory WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim AgingLessThan30Command As New SqlCommand(AgingLessThan30String, con)
        AgingLessThan30Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        AgingLessThan30Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = AgingLessThan30Command.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.GetValue(0)) Then
                ARLessThan30 = 0
            Else
                ARLessThan30 = reader.GetValue(0)
            End If
            If IsDBNull(reader.GetValue(1)) Then
                AR31To45 = 0
            Else
                AR31To45 = reader.GetValue(1)
            End If
            If IsDBNull(reader.GetValue(2)) Then
                AR46To60 = 0
            Else
                AR46To60 = reader.GetValue(2)
            End If
            If IsDBNull(reader.GetValue(3)) Then
                AR61To90 = 0
            Else
                AR61To90 = reader.GetValue(3)
            End If
            If IsDBNull(reader.GetValue(4)) Then
                AROver91 = 0
            Else
                AROver91 = reader.GetValue(4)
            End If
        Else
            ARLessThan30 = 0
            AR31To45 = 0
            AR46To60 = 0
            AR61To90 = 0
        End If
        reader.Close()
        con.Close()

        AROutstanding = AR31To45 + AR46To60 + AR61To90 + ARLessThan30 + AROver91

        lblCreditLT30.Text = FormatCurrency(ARLessThan30, 2)
        lblCreditLT45.Text = FormatCurrency(AR31To45, 2)
        lblCreditLT60.Text = FormatCurrency(AR46To60, 2)
        lblCreditLT90.Text = FormatCurrency(AR61To90, 2)
        lblCreditMT90.Text = FormatCurrency(AROver91, 2)
        lblCreditBalance.Text = FormatCurrency(AROutstanding, 2)
    End Sub

    Public Sub LoadCustomerHistory()
        'Calculate MTD Totals
        MonthDate = Today()
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = MonthDate

        Dim MTDSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDSalesCommand As New SqlCommand(MTDSalesStatement, con)
        MTDSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        MTDSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDSales = CDbl(MTDSalesCommand.ExecuteScalar)
        Catch ex As Exception
            MTDSales = 0
        End Try
        con.Close()

        lblMTDSales.Text = FormatCurrency(MTDSales, 2)
        '*******************************************************************************************************************
        'Calculate YTD Totals
        YearDate = Today()
        YearOfYear = YearDate.Year
        MonthOfYear = YearDate.Month

        If MonthOfYear < 5 Then
            YearOfYear = YearOfYear - 1
        End If

        strYear = CStr(YearOfYear)
        BeginDate = "05/01/" + strYear
        EndDate = YearDate

        Dim YTDSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDSalesCommand As New SqlCommand(YTDSalesStatement, con)
        YTDSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        YTDSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDSales = CDbl(YTDSalesCommand.ExecuteScalar)
        Catch ex As Exception
            YTDSales = 0
        End Try
        con.Close()

        lblYTDSales.Text = FormatCurrency(YTDSales, 2)

        'Populates calculated Customer stats in labels
        Dim AverageStatement As String = "SELECT AVG(InvoiceTotal), MAX(InvoiceDate) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
        Dim AverageCommand As New SqlCommand(AverageStatement, con)
        AverageCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        AverageCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = AverageCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.GetValue(0)) Then
                AverageTotal = 0
            Else
                AverageTotal = reader.GetValue(0)
            End If
            If IsDBNull(reader.GetValue(1)) Then
                LastActivityDate = Today()
            Else
                LastActivityDate = reader.GetValue(1)
            End If
        Else
            AverageTotal = 0
            LastActivityDate = Today()
        End If
        reader.Close()
        con.Close()

        lblAverageOrder.Text = FormatCurrency(AverageTotal, 2)
        lblLastActivityDate.Text = FormatDateTime(LastActivityDate, DateFormat.ShortDate)
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID As String = ""

        Dim LoadCustomerIDStatement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim LoadCustomerIDCommand As New SqlCommand(LoadCustomerIDStatement, con)
        LoadCustomerIDCommand.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        LoadCustomerIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID = CStr(LoadCustomerIDCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerID = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID
    End Sub

    Public Sub ValidateCustomerActivity()
        Dim SalesOrderCount As Integer = 0
        Dim InvoiceCount As Integer = 0
        Dim ShipmentCount As Integer = 0
        Dim CustomerReturnCount As Integer = 0

        Dim SalesOrderCountStatement As String = "SELECT COUNT(SalesOrderKey) FROM SalesOrderHeaderTable WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND SOStatus <> 'CLOSED'"
        Dim SalesOrderCountCommand As New SqlCommand(SalesOrderCountStatement, con)
        SalesOrderCountCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        SalesOrderCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceCountStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceHeaderTable WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND InvoiceStatus <> 'CLOSED'"
        Dim InvoiceCountCommand As New SqlCommand(InvoiceCountStatement, con)
        InvoiceCountCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        InvoiceCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipmentCountStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipmentStatus <> 'INVOICED'"
        Dim ShipmentCountCommand As New SqlCommand(ShipmentCountStatement, con)
        ShipmentCountCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipmentCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CustomerReturnCountStatement As String = "SELECT COUNT(ReturnNumber) FROM ReturnProductHeaderTable WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ReturnStatus <> 'CLOSED'"
        Dim CustomerReturnCountCommand As New SqlCommand(CustomerReturnCountStatement, con)
        CustomerReturnCountCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerReturnCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SalesOrderCount = CInt(SalesOrderCountCommand.ExecuteScalar)
        Catch ex As Exception
            SalesOrderCount = 0
        End Try
        Try
            InvoiceCount = CInt(InvoiceCountCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceCount = 0
        End Try
        Try
            ShipmentCount = CInt(ShipmentCountCommand.ExecuteScalar)
        Catch ex As Exception
            ShipmentCount = 0
        End Try
        Try
            CustomerReturnCount = CInt(CustomerReturnCountCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerReturnCount = 0
        End Try
        con.Close()

        CustomerActivitySummation = SalesOrderCount + InvoiceCount + ShipmentCount + CustomerReturnCount
    End Sub



    Public Sub LoadSalesTerritory()
        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            If cboSalesTerritory.Text = "" Then
                GetSalesTerritory = ""
            Else
                Dim GetSalesTerritoryStatement As String = "SELECT TerritoryID FROM SalesTerritoryQuery WHERE TerritoryDescription = @TerritoryDescription"
                Dim GetSalesTerritoryCommand As New SqlCommand(GetSalesTerritoryStatement, con)
                GetSalesTerritoryCommand.Parameters.Add("@TerritoryDescription", SqlDbType.VarChar).Value = cboSalesTerritory.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSalesTerritory = CStr(GetSalesTerritoryCommand.ExecuteScalar)
                Catch ex As Exception
                    GetSalesTerritory = ""
                End Try
                con.Close()
            End If
        Else
            GetSalesTerritory = txtSalesTerritory.Text
        End If
    End Sub

    Public Sub LoadTaxExemptCert()
        If cboSalesTaxStatus.Text = "EXEMPT" Then
            Dim TaxCertDivision As String = ""
            Dim TaxCertCustomerID As String = ""
            Dim TaxCertFileName As String = ""
            Dim TaxCertFilenameAndPath As String = ""

            TaxCertDivision = cboDivisionID.Text
            TaxCertCustomerID = cboCustomerID.Text
            TaxCertFileName = TaxCertCustomerID + ".pdf"
            TaxCertFilenameAndPath = "\\TFP-FS\TrufitCustomerDataPublic\Customer Sales Tax Exemption Cert" + "\" + TaxCertDivision + "\" + TaxCertFileName
            GlobalTaxExemptCert = TaxCertFilenameAndPath

            If File.Exists(TaxCertFilenameAndPath) Then
                lblTaxExempt.Text = "Customer has a tax exempt certificate on file."
                lblTaxExempt.Visible = True
                cmdViewTaxExemptForm.Enabled = True
            Else
                lblTaxExempt.Text = "No tax exempt certificate on file"
                lblTaxExempt.Visible = True
                cmdViewTaxExemptForm.Enabled = False
            End If
        Else
            lblTaxExempt.Visible = False
        End If
    End Sub

    Public Sub LoadCustomerCreditApp()
        If cboCustomerID.Text <> "" Then
            Dim CreditAppDivision As String = ""
            Dim CreditAppCustomerID As String = ""
            Dim CreditAppFileName As String = ""
            Dim CreditAppFilenameAndPath As String = ""
            Dim CurrentDivision As String = cboDivisionID.Text

            Select Case CurrentDivision
                Case "ALB"
                    CreditAppDivision = "TFP OF ALBERTA (ALB)"
                Case "ATL"
                    CreditAppDivision = "TFP OF ATLANTA (ATL)"
                Case "CGO"
                    CreditAppDivision = "TFP OF INDIANA (CGO)"
                Case "CHT"
                    CreditAppDivision = "WELDING CERAMIC (CHT)"
                Case "CBS"
                    CreditAppDivision = "TFP OF NEVADA (CBS)"
                Case "DEN"
                    CreditAppDivision = "TFP OF DENVER (DEN)"
                Case "HOU"
                    CreditAppDivision = "TFP OF HOUSTON (HOU)"
                Case "SLC"
                    CreditAppDivision = "TFP OF UTAH (SLC)"
                Case "TFF"
                    CreditAppDivision = "TRUFIT FASTENER & SUPPLY (TFF)"
                Case "TFJ"
                    CreditAppDivision = "TFP NEW JERSEY (TFJ)"
                Case "TFP"
                    CreditAppDivision = "TRUFIT (TFP)"
                Case "TOR"
                    CreditAppDivision = "TFP OF TORONTO (TOR)"
                Case "TWD"
                    CreditAppDivision = "TRUWELD (TWD)"
                Case "TWE"
                    CreditAppDivision = "TRUWELD EQUIPMENT (TWE)"
                Case "TFT"
                    CreditAppDivision = "TFP OF TEXAS (TFT)"
            End Select

            CreditAppCustomerID = cboCustomerID.Text
            CreditAppFileName = CreditAppCustomerID + ".pdf"
            CreditAppFilenameAndPath = "\\TFP-FS\TrufitCustomerDataPublic\Customer Credit Applications" + "\" + CreditAppDivision + "\" + CreditAppFileName
            GlobalCustomerCreditAPP = CreditAppFilenameAndPath

            If File.Exists(CreditAppFilenameAndPath) Then
                cmdCreditApp.Enabled = True
            Else
                cmdCreditApp.Enabled = False
            End If
        Else
            cmdCreditApp.Enabled = False
        End If
    End Sub

    'Clear Sub-Routines

    Public Sub ClearData()
        dtpCustomerSince.Text = ""
        cboShipToID.Text = ""
        cboShipper.Text = ""

        cboShipToID.Refresh()
        cboCustomerName.Refresh()
        cboCustomerID.Refresh()
        cboPaymentTerms.Refresh()
        cboSTState.Refresh()
        cboContactDepartment.Refresh()
        cboBTState.Refresh()
        cboCustomerClass.Refresh()
        cboAddState.Refresh()
        cboCustomerClass.Refresh()
        cboShipper.Refresh()
        cboSalesTerritory.Refresh()
        cboCountryList.Refresh()
        cboAddShipToCountry.Refresh()
        cboShipToCountry.Refresh()
        cboBankAccount.Refresh()

        txtBTAddress1.Refresh()
        txtBTAddress2.Refresh()
        txtBTCity.Refresh()
        txtBTCountry.Refresh()
        txtBTZip.Refresh()
        txtSTAddress1.Refresh()
        txtSTAddress2.Refresh()
        txtSTCity.Refresh()
        txtSTCountry.Refresh()
        txtSTZip.Refresh()
        txtShipEmail.Refresh()
        txtCreditLimit.Refresh()
        txtCustomerComment.Refresh()
        txtContactPhone.Refresh()
        txtContactName.Refresh()
        txtContactFax.Refresh()
        txtContactEmail.Refresh()
        txtAddAddress1.Refresh()
        txtAddAddress2.Refresh()
        txtAddCity.Refresh()
        txtAddCountry.Refresh()
        txtAddShipToName.Refresh()
        txtAddZip.Refresh()
        txtTaxID.Refresh()
        txtSalesTaxRate2.Refresh()
        txtSalesTaxRate3.Refresh()
        txtAPContactName.Refresh()
        txtAPEmailAddress.Refresh()
        txtAPFaxNumber.Refresh()
        txtAPPhoneNumber.Refresh()
        txtOldCustomerNumber.Refresh()
        txtShippingInstructions.Refresh()
        txtSalesTerritory.Refresh()
        txtShippingAccount.Refresh()
        txtSalesContactEmail.Refresh()
        txtInvoiceEmail.Refresh()
        txtInvoiceCertEmail.Refresh()

        cboShipToID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboPaymentTerms.SelectedIndex = -1
        cboSTState.SelectedIndex = -1
        cboContactDepartment.SelectedIndex = -1
        cboBTState.SelectedIndex = -1
        cboCustomerClass.SelectedIndex = -1
        cboAddState.SelectedIndex = -1
        cboCustomerClass.SelectedIndex = -1
        cboShipper.SelectedIndex = -1
        cboSalesTerritory.SelectedIndex = -1
        cboBillingType.SelectedIndex = -1
        cboCountryList.SelectedIndex = -1
        cboAddShipToCountry.SelectedIndex = -1
        cboShipToCountry.SelectedIndex = -1
        cboBankAccount.SelectedIndex = -1
        cboSalesTaxStatus.SelectedIndex = -1

        txtBTAddress1.Clear()
        txtBTAddress2.Clear()
        txtBTCity.Clear()
        txtBTCountry.Clear()
        txtBTZip.Clear()
        txtSTAddress1.Clear()
        txtSTAddress2.Clear()
        txtSTCity.Clear()
        txtSTCountry.Clear()
        txtSTZip.Clear()
        txtShipEmail.Clear()
        txtCreditLimit.Clear()
        txtCustomerComment.Clear()
        txtContactPhone.Clear()
        txtContactName.Clear()
        txtContactFax.Clear()
        txtContactEmail.Clear()
        txtAddAddress1.Clear()
        txtAddAddress2.Clear()
        txtAddCity.Clear()
        txtAddCountry.Clear()
        txtAddShipToName.Clear()
        txtAddZip.Clear()
        txtTaxID.Clear()
        txtSalesTaxRate2.Clear()
        txtSalesTaxRate3.Clear()
        txtAPContactName.Clear()
        txtAPEmailAddress.Clear()
        txtAPFaxNumber.Clear()
        txtAPPhoneNumber.Clear()
        txtOldCustomerNumber.Clear()
        txtShippingInstructions.Clear()
        txtSalesTaxRate.Clear()
        txtSalesTaxRate2.Clear()
        txtSalesTaxRate3.Clear()
        txtSalesTerritory.Clear()
        txtShippingAccount.Clear()
        txtEmailCerts.Clear()
        txtEmailConfirmations.Clear()
        txtEmailStatements.Clear()
        txtEmailPackingLists.Clear()
        txtSalesContactEmail.Clear()
        txtInvoiceEmail.Clear()
        txtInvoiceCertEmail.Clear()

        lblCreditLimit.Text = ""
        lblAverageOrder.Text = ""
        lblCreditLT30.Text = ""
        lblCreditLT60.Text = ""
        lblCreditLT90.Text = ""
        lblLastActivityDate.Text = ""
        lblMTDSales.Text = ""
        lblYTDSales.Text = ""
        lblCreditBalance.Text = ""
        lblCreditMT90.Text = ""
        lblHoldBanner.Text = ""

        lblTaxExempt.Visible = False
        cmdViewTaxExemptForm.Enabled = False

        'Set Defaults
        cboBillingType.Text = "STANDARD"

        chkCreditHold.Checked = False
        chkAccountingHold.Checked = False
        chkAddGST.Checked = False
        chkAddHST.Checked = False
        chkAddPST.Checked = False

        cboPaymentTerms.Enabled = True

        If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
            cboCustomerClass.Text = "CANADIAN"
        Else
            cboCustomerClass.Text = "STANDARD"
        End If

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearSalesLabels()
        lblCreditLimit.Text = ""
        lblCreditLT45.Text = ""
        lblAverageOrder.Text = ""
        lblCreditLT30.Text = ""
        lblCreditLT60.Text = ""
        lblCreditLT90.Text = ""
        lblLastActivityDate.Text = ""
        lblMTDSales.Text = ""
        lblYTDSales.Text = ""
        lblCreditBalance.Text = ""
        lblCreditMT90.Text = ""
    End Sub

    Public Sub ClearVariables()
        CheckPaymentTerms = 0
        PricingLevel = ""
        Name = ""
        SalesTerritory = ""
        CustomerClass = ""
        CustomerName = ""
        Comments = ""
        PaymentTerms = ""
        PreferredShipper = ""
        OldCustomerNumber = ""
        ShipToAddress1 = ""
        ShipToAddress2 = ""
        ShipToCity = ""
        ShipToState = ""
        ShipToZip = ""
        ShipToCountry = ""
        ShipEmail = ""
        BillToAddress1 = ""
        BillToAddress2 = ""
        BillToCity = ""
        BillToState = ""
        BillToZip = ""
        BillToCountry = ""
        SalesTaxRate = 0
        CreditLimit = 0
        SalesTotal = 0
        AverageTotal = 0
        ContactName = ""
        ContactEmail = ""
        ContactPhone = ""
        ContactFax = ""
        Address1 = ""
        Address2 = ""
        City = ""
        State = ""
        Zip = ""
        Country = ""
        ShippingInstructions = ""
        AROutstanding = 0
        ARLessThan30 = 0
        AR31To45 = 0
        AR46To60 = 0
        AR61To90 = 0
        AROver91 = 0
        'GlobalCustomerID = ""
        'GlobalCustomerName = ""
        'GlobalCustomerID2 = ""
        OnHoldStatus = ""
        ShippingDetails = ""
        CheckAddShipTo = ""
        CustomerClassType = ""
        SalesTaxRate2 = 0
        SalesTaxRate3 = 0
        SalesTaxID = ""
        CheckDeleteSalesOrder = 0
        AccountingHold = ""
        BillingType = ""
        ShippingAccountNumber = ""
        SaveButtonPressed = "NO"
        CustomerBankAccount = ""
        CustomerActivitySummation = 0
        ConfirmationEmail = ""
        CertEmail = ""
        StatementEmail = ""
        PackingListEmail = ""
        SalesContactEmail = ""
        ValidateCustomerForBadCharacters = ""
        SalesTaxStatus = ""
        InvoiceEmail = ""
        InvoiceCertEmail = ""
    End Sub

    Public Sub RefreshContactList()
        cboContactDepartment.Refresh()
        txtContactEmail.Refresh()
        txtContactFax.Refresh()
        txtContactName.Refresh()
        txtContactPhone.Refresh()
    End Sub

    'Datagrid events

    Private Sub dgvCustomerContacts_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCustomerContacts.CellValueChanged
        Dim RowCustomer, RowEmail, RowPhone, RowFax, RowDepartment, RowName As String
        If Me.dgvCustomerContacts.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvCustomerContacts.CurrentCell.RowIndex

            RowCustomer = Me.dgvCustomerContacts.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowEmail = Me.dgvCustomerContacts.Rows(RowIndex).Cells("ContactEmailColumn").Value
            RowPhone = Me.dgvCustomerContacts.Rows(RowIndex).Cells("ContactPhoneColumn").Value
            RowFax = Me.dgvCustomerContacts.Rows(RowIndex).Cells("ContactFaxColumn").Value
            RowDepartment = Me.dgvCustomerContacts.Rows(RowIndex).Cells("ContactDepartmentColumn").Value
            RowName = Me.dgvCustomerContacts.Rows(RowIndex).Cells("ContactNameColumn").Value

            Try
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("UPDATE CustomerContacts SET ContactName = @ContactName, ContactEmail = @ContactEmail, ContactPhone = @ContactPhone, ContactFax = @ContactFax WHERE  CustomerID = @CustomerID AND ContactDepartment = @ContactDepartment AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ContactName", SqlDbType.VarChar).Value = RowName
                    .Add("@ContactEmail", SqlDbType.VarChar).Value = RowEmail
                    .Add("@ContactPhone", SqlDbType.VarChar).Value = RowPhone
                    .Add("@ContactFax", SqlDbType.VarChar).Value = RowFax
                    .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                    .Add("@ContactDepartment", SqlDbType.VarChar).Value = RowDepartment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'No updates
            End Try
        Else
            'Skip update
        End If
    End Sub

    'Text Box Text Changed Events

    Private Sub txtSTAddress1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShipToAddress1 = txtSTAddress1.Text
    End Sub

    Private Sub txtSTAddress2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShipToAddress2 = txtSTAddress2.Text
    End Sub

    Private Sub txtSTCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShipToCity = txtSTCity.Text
    End Sub

    Private Sub txtSTZip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShipToZip = txtSTZip.Text
    End Sub

    Private Sub txtSTCountry_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSTCountry.TextChanged
        ShipToCountry = txtSTCountry.Text
        LoadSTCountryByCountryCode()
    End Sub

    Private Sub txtBTAddress1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBTAddress1.TextChanged
        BillToAddress1 = txtBTAddress1.Text
    End Sub

    Private Sub txtBTAddress2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBTAddress2.TextChanged
        BillToAddress2 = txtBTAddress2.Text
    End Sub

    Private Sub txtBTCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBTCity.TextChanged
        BillToCity = txtBTCity.Text
    End Sub

    Private Sub txtBTZip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBTZip.TextChanged
        BillToZip = txtBTZip.Text
    End Sub

    Private Sub txtBTCountry_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBTCountry.TextChanged
        BillToCountry = txtBTCountry.Text
        LoadBTCountryByCountryCode()
    End Sub

    Private Sub txtAddCountry_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddCountry.TextChanged
        LoadAddSTCountryByCountryCode()
    End Sub

    'Combo Box Text Changed Events

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        usefulFunctions.LoadSecurity(Me, cboDivisionID.Text)

        'Clear Fields before load
        ClearData()

        'Set date format
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            CustomerClassType = "CANADIAN"
            LoadCustomerClass()
        Else
            CustomerClassType = "AMERICAN"
            LoadCustomerClass()
        End If

        If cboDivisionID.Text = "TFP" Then
            lblContactDepartment.Visible = True
        Else
            lblContactDepartment.Visible = False
        End If

        'Clear text boxes on load and set defaults if any
        LoadCustomerList()
        LoadCustomerName()
        LoadSalesTaxDefaults()

        If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            cboSalesTerritory.Visible = True
            txtSalesTerritory.Visible = False
        Else
            cboSalesTerritory.Visible = False
            txtSalesTerritory.Visible = True
        End If

        cboCustomerID.Focus()
    End Sub

    Private Sub cboSTState_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ShipToState = cboSTState.Text
    End Sub

    Private Sub cboBTState_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBTState.SelectedIndexChanged
        BillToState = cboBTState.Text
    End Sub

    Private Sub cboShipToCountry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipToCountry.SelectedIndexChanged
        LoadSTCountryCodeByCountry()
    End Sub

    Private Sub cboContactDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContactDepartment.SelectedIndexChanged
        LoadContactDetails()
    End Sub

    Private Sub cboShipToID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipToID.SelectedIndexChanged
        LoadAdditionalShiptoDetails()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        'Clear Add Ship To fields
        cboShipToID.SelectedIndex = -1
        cboAddState.SelectedIndex = -1
        txtAddAddress1.Clear()
        txtAddAddress2.Clear()
        txtAddCity.Clear()
        txtAddCountry.Clear()
        txtAddShipToName.Clear()
        txtAddZip.Clear()
        SaveButtonPressed = "NO"

        If cboCustomerID.Text <> "" Then
            LoadCustomerAPData()
            ShowAdditionalShipTo()
            LoadCustomerContacts()
            LoadCustomerContactList()
            LoadContactDetails()
            LoadCustomerARAging()
            LoadCustomerHistory()
            LoadAVGDaysToPay()
            LoadCustomerCreditApp()
            LoadCustomerData()
        Else
            ClearVariables()
            ClearData()
            ClearSalesLabels()
        End If

        DisablePaymentIfLoaded()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboCountryList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCountryList.SelectedIndexChanged
        LoadBTCountryCodeByCountry()
    End Sub

    Private Sub cboAddShipToCountry_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAddShipToCountry.SelectedIndexChanged
        LoadAddSTCountryCodeByCountry()
    End Sub

    Private Sub cboSalesTaxStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalesTaxStatus.SelectedIndexChanged
        If cboSalesTaxStatus.Text = "EXEMPT" Then
            LoadTaxExemptCert()
        Else
            cmdViewTaxExemptForm.Enabled = False
            lblTaxExempt.Visible = False
        End If
    End Sub

    'Command Buttons

    Private Sub cmdCopyToShippingAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyToShippingAddress.Click
        'Copies Billing address over to shipping address
        txtSTAddress1.Text = BillToAddress1
        txtSTAddress2.Text = BillToAddress2
        txtSTCity.Text = BillToCity
        txtSTCountry.Text = BillToCountry
        cboSTState.Text = BillToState
        txtSTZip.Text = BillToZip
        tcAddress.SelectedIndex = 1
    End Sub

    Private Sub cmdClearAdditionalShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAdditionalShipTo.Click
        'Clear Add Ship To fields
        cboShipToID.Text = ""
        cboShipToID.SelectedIndex = -1
        cboAddState.SelectedIndex = -1
        cboAddShipToCountry.SelectedIndex = -1

        txtAddAddress1.Clear()
        txtAddAddress2.Clear()
        txtAddCity.Clear()
        txtAddCountry.Clear()
        txtAddShipToName.Clear()
        txtAddZip.Clear()

        ShowAdditionalShipTo()
        cboShipToID.Focus()
    End Sub

    Private Sub cmdClearShipping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Clear Shipping Address
        txtSTAddress1.Clear()
        txtSTAddress2.Clear()
        txtSTCity.Clear()
        txtSTZip.Clear()
        txtSTCountry.Clear()
        txtAddAddress1.Clear()
        txtAddAddress2.Clear()
        txtAddCity.Clear()
        txtAddZip.Clear()
        txtAddCountry.Clear()

        cboSTState.SelectedIndex = -1
        cboShipToID.SelectedIndex = -1
        cboAddState.SelectedIndex = -1

        txtSTAddress1.Focus()
    End Sub

    Private Sub cmdClearBilling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearBilling.Click
        'Clear Billing Address
        txtBTAddress1.Clear()
        txtBTAddress2.Clear()
        txtBTCity.Clear()

        cboBTState.SelectedIndex = -1
        cboCountryList.SelectedIndex = -1

        txtBTZip.Clear()
        txtBTCountry.Clear()
        txtBTAddress1.Focus()
    End Sub

    Private Sub cmdClearContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearContact.Click
        cboContactDepartment.SelectedIndex = -1
        txtContactEmail.Clear()
        txtContactFax.Clear()
        txtContactName.Clear()
        txtContactPhone.Clear()
        cboContactDepartment.Focus()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        'Clear text boxes
        ClearSalesLabels()
        ClearVariables()
        ClearData()
        LoadCustomerList()
        SaveButtonPressed = "NO"
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Prompt before Saving
        If canSave() Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Customer's data?", "SAVE DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Validate specific fields
                Validation()
                ValidateAccountingHold()
                ValidatePaymentTerms()

                If CheckPaymentTerms = 0 Then
                    MsgBox("Invalid payment terms.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '*****************************************************************************************************
                If cboCustomerClass.Text = "DE-ACTIVATED" Then
                    'Check activity and de-activate Customer (activity = Outstanding A/R Balance)
                    LoadCustomerARAging()
                    If AROutstanding > -0.1 And AROutstanding < 0.1 Then
                        'Continue with Save Process
                    Else
                        MsgBox("Customer has A/R Balance - it cannot be de-activated.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                    If CustomerActivitySummation = 0 Then
                        'Continue
                    Else
                        MsgBox("This customer has an open order, shipment, invoice, or return. It cannot be de-ativated.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                Else
                    'Continue with Save Process
                End If
                '*****************************************************************************************************
                'Convert date if necessary
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CustomerDate = dtpCustomerSince.Value
                Else
                    CustomerDate = dtpCustomerSince.Value
                    txtSalesTaxRate2.Text = 0
                    txtSalesTaxRate3.Text = 0
                End If
                '*****************************************************************************************************
                ValidatePaymentTermsChange()

                'Determine Hold Status
                If chkCreditHold.Checked = True Then
                    OnHoldStatus = "YES"
                Else
                    OnHoldStatus = "NO"
                End If
                '*****************************************************************************************************
                'Determine Accounting Hold Status
                If chkAccountingHold.Checked = True Then
                    AccountingHold = "YES"
                Else
                    AccountingHold = "NO"
                End If
                '*****************************************************************************************************
                'Check to see if any customers have the exact same name - do not save
                Dim CountNames As Integer = 0
                Dim CountIDS As Integer = 0

                Dim CountCustomerNamesStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
                Dim CountCustomerNamesCommand As New SqlCommand(CountCustomerNamesStatement, con)
                CountCustomerNamesCommand.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
                CountCustomerNamesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim CountCustomerIDSStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountCustomerIDSCommand As New SqlCommand(CountCustomerIDSStatement, con)
                CountCustomerIDSCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                CountCustomerIDSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountNames = CInt(CountCustomerNamesCommand.ExecuteScalar)
                Catch ex As Exception
                    CountNames = 0
                End Try
                Try
                    CountIDS = CInt(CountCustomerIDSCommand.ExecuteScalar)
                Catch ex As Exception
                    CountIDS = 0
                End Try
                con.Close()
                '*****************************************************************************************************
                'Saves the customer data
                If CountNames = 0 And CountIDS = 0 Then 'Customer ID and Name does not exist for this division - INSERT
                    'Try to inser customer in database
                    Try
                        InsertIntoCustomerList()
                    Catch ex As Exception
                        'Log error on update failure

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Save Button - INSERT INTO CUSTOMER Failure - " + cboCustomerID.Text
                        ErrorReferenceNumber = cboCustomerID.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        MsgBox("New Customer has not been created.", MsgBoxStyle.OkOnly)
                    End Try
                ElseIf CountNames = 1 And CountIDS = 0 Then 'Customer ID does not exist, but name does. Fail with message.
                    MsgBox("A Customer exists with this name - cannot create a new customer.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Save Customer data to existing record
                    Try
                        UpdateCustomerList()
                    Catch ex As Exception
                        'Log error on update failure

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Save Button - UPDATE Customer Failure - " + cboCustomerID.Text
                        ErrorReferenceNumber = cboCustomerID.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
                '*******************************************************************************************************************
                'Save Additional Ship To Data if necessary
                If String.IsNullOrEmpty(cboShipToID.Text) = False Then
                    If canSaveAddShipTo() Then
                        Try
                            InsertIntoAdditionShipTo()
                        Catch ex As Exception
                            Try
                                UpdateAdditionalShipTo()
                            Catch ex4 As Exception
                                'Log error on update failure

                                ErrorDate = Today()
                                ErrorComment = ex4.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Save Button - Update Additional Ship To Failure - " + cboShipToID.Text
                                ErrorReferenceNumber = cboCustomerID.Text
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                    Else
                        Exit Sub
                    End If
                End If

                ''checks to see if saving contacts is required
                If String.IsNullOrEmpty(cboContactDepartment.Text) = False Then
                    If canSaveContact() Then
                        Try
                            InsertIntoCustomerContacts()
                        Catch ex As Exception
                            Try
                                UpdateCustomerContacts()
                            Catch ex5 As Exception
                                'Log error on update failure

                                ErrorDate = Today()
                                ErrorComment = ex5.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Save Button - Update Customer Contacts Failure - " + cboContactDepartment.Text
                                ErrorReferenceNumber = cboCustomerID.Text
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                    Else
                        Exit Sub
                    End If
                End If

                shouldSave = False
                shouldSaveAddress = False
                shouldSaveContact = False
                SaveButtonPressed = "YES"

                MsgBox("Customer Data has been saved.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdAddContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddContact.Click
        If canSaveContact() Then
            If canSave() Then
                'Validate specific fields
                Validation()
                ValidateAccountingHold()
                ValidatePaymentTerms()

                'Convert date if necessary
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CustomerDate = dtpCustomerSince.Value
                Else
                    CustomerDate = dtpCustomerSince.Value
                    txtSalesTaxRate2.Text = 0
                    txtSalesTaxRate3.Text = 0
                End If

                If cboCustomerClass.Text = "DE-ACTIVATED" Then
                    MsgBox("You cannot save data to a de-activated customer.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue with Save Process
                End If
                '*****************************************************************************************************
                ValidatePaymentTermsChange()

                'Determine Hold Status
                If chkCreditHold.Checked = True Then
                    OnHoldStatus = "YES"
                Else
                    OnHoldStatus = "NO"
                End If

                'Determine Accounting Hold Status
                If chkAccountingHold.Checked = True Then
                    AccountingHold = "YES"
                Else
                    AccountingHold = "NO"
                End If

                'Saves the customer data
                Try
                    InsertIntoCustomerList()
                Catch ex As Exception
                    Try
                        UpdateCustomerList()
                    Catch ex2 As Exception
                        'Log error on update failure

                        ErrorDate = Today()
                        ErrorComment = ex2.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Update Customer Failure - " + cboCustomerID.Text
                        ErrorReferenceNumber = cboCustomerID.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End Try

                ''checks to see if saving contacts is required
                If String.IsNullOrEmpty(cboContactDepartment.Text) = False Then
                    If canSaveContact() Then
                        Try
                            InsertIntoCustomerContacts()
                        Catch ex As Exception
                            Try
                                UpdateCustomerContacts()
                            Catch ex5 As Exception
                                'Log error on update failure

                                ErrorDate = Today()
                                ErrorComment = ex5.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Update Customer Contacts Failure - " + cboContactDepartment.Text
                                ErrorReferenceNumber = cboCustomerID.Text
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                    Else
                        Exit Sub
                    End If
                End If

                shouldSaveContact = False

                LoadCustomerContactList()
                LoadCustomerContacts()
                SaveButtonPressed = "YES"
                MsgBox("Customer contact has been added to the database", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdCustomerStatement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomerStatement.Click
        GlobalDivisionCode = cboDivisionID.Text
        GlobalCustomerID = cboCustomerID.Text
        EmailCustomerEmailAddress = txtAPEmailAddress.Text
        EmailInvoiceCustomer = cboCustomerID.Text

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
            Using NewPrintARCustomerStatementSingleRemote As New PrintARCustomerStatementSingleRemote
                Dim result = NewPrintARCustomerStatementSingleRemote.ShowDialog()
            End Using
        Else
            Using NewPrintARCustomerStatement As New PrintARCustomerStatementSingle
                Dim result = NewPrintARCustomerStatement.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub cmdOpenOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenOrders.Click
        GlobalCustomerID = cboCustomerID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewCustomerOpenOrders As New CustomerOpenOrders
            Dim result = NewCustomerOpenOrders.ShowDialog()
        End Using
    End Sub

    Private Sub cmdSalesHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalesHistory.Click
        GlobalCustomerID = cboCustomerID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewCustomerSalesHistory As New CustomerSalesHistory
            Dim result = NewCustomerSalesHistory.ShowDialog()
        End Using
    End Sub

    Private Sub cmdSaveAdditionalShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveAdditionalShipTo.Click
        If canSaveAddShipTo() Then
            'Validate specific fields
            Validation()
            ValidateAccountingHold()
            ValidatePaymentTerms()

            'Convert date if necessary
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                CustomerDate = dtpCustomerSince.Value
            Else
                CustomerDate = dtpCustomerSince.Value
                txtSalesTaxRate2.Text = 0
                txtSalesTaxRate3.Text = 0
            End If

            If cboCustomerClass.Text = "DE-ACTIVATED" Then
                MsgBox("You cannot save data to a de-activated customer.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue with Save Process
            End If
            '*****************************************************************************************************
            ValidatePaymentTermsChange()

            'Determine Hold Status
            If chkCreditHold.Checked = True Then
                OnHoldStatus = "YES"
            Else
                OnHoldStatus = "NO"
            End If

            'Determine Accounting Hold Status
            If chkAccountingHold.Checked = True Then
                AccountingHold = "YES"
            Else
                AccountingHold = "NO"
            End If

            'Saves the customer data
            Try
                InsertIntoCustomerList()
            Catch ex As Exception
                Try
                    UpdateCustomerList()
                Catch ex2 As Exception
                    'Log error on update failure

                    ErrorDate = Today()
                    ErrorComment = ex2.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Save ShipTo Button - Update Customer Failure - " + cboCustomerID.Text
                    ErrorReferenceNumber = cboCustomerID.Text
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End Try

            'Save Additional Ship To Data if necessary
            If String.IsNullOrEmpty(cboShipToID.Text) = False Then
                If canSaveAddShipTo() Then
                    Try
                        InsertIntoAdditionShipTo()
                    Catch ex As Exception
                        Try
                            UpdateAdditionalShipTo()
                        Catch ex4 As Exception
                            'Log error on update failure

                            ErrorDate = Today()
                            ErrorComment = ex4.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Save ShipTo Button - Update Additional Ship To Failure - " + cboShipToID.Text
                            ErrorReferenceNumber = cboCustomerID.Text
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    End Try
                Else
                    Exit Sub
                End If
            End If

            shouldSaveAddress = False
            SaveButtonPressed = "YES"

            MsgBox("Customer Data has been saved.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdDeleteAddShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteAddShipTo.Click
        If canDeleteAddShipTo() Then
            Try
                'Delete Additional Ship To
                cmd = New SqlCommand("DELETE FROM AdditionalShipTo WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                    .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowAdditionalShipTo()

                'Clear Add Ship To fields
                cboShipToID.SelectedIndex = -1
                cboAddState.SelectedIndex = -1
                txtAddAddress1.Clear()
                txtAddAddress2.Clear()
                txtAddCity.Clear()
                txtAddCountry.Clear()
                txtAddShipToName.Clear()
                txtAddZip.Clear()
                cboShipToID.Focus()
                MessageBox.Show("Ship to ID has been deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Unable to delete additional ship to address, contact system admin", "Unable to delete additional ship to", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

    Private Sub cmdDeleteContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteContact.Click
        If canDeleteContact() Then
            cmd = New SqlCommand("Delete FROM CustomerContacts WHERE CustomerID = @CustomerID AND ContactDepartment = @ContactDepartment AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@ContactDepartment", SqlDbType.VarChar).Value = cboContactDepartment.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("This Department contact has been deleted", MsgBoxStyle.OkOnly)

            LoadCustomerContactList()
            LoadCustomerContacts()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If canPrint() Then
            'Validate specific fields
            Validation()
            ValidateAccountingHold()
            ValidatePaymentTerms()

            'Convert date if necessary
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                CustomerDate = dtpCustomerSince.Value
            Else
                CustomerDate = dtpCustomerSince.Value
                txtSalesTaxRate2.Text = 0
                txtSalesTaxRate3.Text = 0
            End If

            If cboCustomerClass.Text = "DE-ACTIVATED" Then
                MsgBox("You cannot save data to a de-activated customer.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue with Save Process
            End If
            '*****************************************************************************************************
            ValidatePaymentTermsChange()

            'Determine Hold Status
            If chkCreditHold.Checked = True Then
                OnHoldStatus = "YES"
            Else
                OnHoldStatus = "NO"
            End If

            'Determine Accounting Hold Status
            If chkAccountingHold.Checked = True Then
                AccountingHold = "YES"
            Else
                AccountingHold = "NO"
            End If
            '***********************************************************************************************************
            ''checks to see if saving contacts is required
            If String.IsNullOrEmpty(cboContactDepartment.Text) = False Then
                If canSaveContact() Then
                    Try
                        InsertIntoCustomerContacts()
                    Catch ex As Exception
                        Try
                            UpdateCustomerContacts()
                        Catch ex5 As Exception
                            'Log error on update failure

                            ErrorDate = Today()
                            ErrorComment = ex5.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Print Button - Update Customer Contacts Failure - " + cboContactDepartment.Text
                            ErrorReferenceNumber = cboCustomerID.Text
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    End Try
                Else
                    Exit Sub
                End If
            End If
            '**********************************************************************************************************
            'Save Additional Ship To Data if necessary
            If String.IsNullOrEmpty(cboShipToID.Text) = False Then
                If canSaveAddShipTo() Then
                    Try
                        InsertIntoAdditionShipTo()
                    Catch ex As Exception
                        Try
                            UpdateAdditionalShipTo()
                        Catch ex4 As Exception
                            'Log error on update failure

                            ErrorDate = Today()
                            ErrorComment = ex4.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Print Button - Update Additional Ship To Failure - " + cboShipToID.Text
                            ErrorReferenceNumber = cboCustomerID.Text
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    End Try
                Else
                    Exit Sub
                End If
            End If

            If canSave() Then
                '*****************************************************************************************************
                'Check to see if any customers have the exact same name - do not save
                Dim CountNames As Integer = 0
                Dim CountIDS As Integer = 0

                Dim CountCustomerNamesStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
                Dim CountCustomerNamesCommand As New SqlCommand(CountCustomerNamesStatement, con)
                CountCustomerNamesCommand.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
                CountCustomerNamesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim CountCustomerIDSStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountCustomerIDSCommand As New SqlCommand(CountCustomerIDSStatement, con)
                CountCustomerIDSCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                CountCustomerIDSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountNames = CInt(CountCustomerNamesCommand.ExecuteScalar)
                Catch ex As Exception
                    CountNames = 0
                End Try
                Try
                    CountIDS = CInt(CountCustomerIDSCommand.ExecuteScalar)
                Catch ex As Exception
                    CountIDS = 0
                End Try
                con.Close()
                '*****************************************************************************************************
                'Saves the customer data
                If CountNames = 0 And CountIDS = 0 Then 'Customer ID and Name does not exist for this division - INSERT
                    'Try to inser customer in database
                    Try
                        InsertIntoCustomerList()
                    Catch ex As Exception
                        'Log error on update failure

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Save Button - INSERT INTO CUSTOMER Failure - " + cboCustomerID.Text
                        ErrorReferenceNumber = cboCustomerID.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        MsgBox("New Customer has not been created.", MsgBoxStyle.OkOnly)
                    End Try
                ElseIf CountNames = 1 And CountIDS = 0 Then 'Customer ID does not exist, but name does. Fail with message.
                    MsgBox("A Customer exists with this name - cannot create a new customer.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Save Customer data to existing record
                    Try
                        UpdateCustomerList()
                    Catch ex As Exception
                        'Log error on update failure

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Save Button - UPDATE Customer Failure - " + cboCustomerID.Text
                        ErrorReferenceNumber = cboCustomerID.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
                '*******************************************************************************************************************
                '*******************************************************************************************************************
            Else
                'Do not save data if CanSave fails, but bring up print form
            End If

            GlobalDivisionCode = EmployeeCompanyCode
            GlobalCustomerID = cboCustomerID.Text

            Using NewPrintCustomer As New PrintCustomer
                Dim result = NewPrintCustomer.ShowDialog()
            End Using

        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If canDeleteCustomer() Then
            Try
                cmd = New SqlCommand("DELETE FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                MessageBox.Show("Unable to delete customer, contact system admin", "Unable to comeplete deletion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            Try
                cmd = New SqlCommand("DELETE FROM CustomerContacts WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                MessageBox.Show("Unable to delete customer, contact system admin", "Unable to comeplete deletion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            Try
                cmd = New SqlCommand("DELETE FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                MessageBox.Show("Unable to delete customer, contact system admin", "Unable to comeplete deletion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            MsgBox("This Customer has been deleted", MsgBoxStyle.OkOnly)

            'Clear text boxes on delete
            ClearVariables()
            ClearSalesLabels()
            ClearData()
            LoadCustomerList()
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Form Logout
        FormLogoutRoutine()

        If SaveButtonPressed = "YES" Then
            GlobalCustomerID = ""
            GlobalCustomerName = ""
            GlobalCustomerID2 = ""
            ClearVariables()
            ClearData()
            Me.Dispose()
            Me.Close()
            Exit Sub
        End If

        If cboCustomerID.Text = "" Then
            GlobalCustomerID = ""
            GlobalCustomerName = ""
            GlobalCustomerID2 = ""
            ClearVariables()
            ClearData()
            Me.Dispose()
            Me.Close()
            Exit Sub
        End If
        '************************************************************************************************
        'Prompt before saving
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this Customer's data?", "SAVE DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Prompt before Saving
            If canSave() Then
                'Validate specific fields
                Validation()
                ValidateAccountingHold()
                ValidatePaymentTerms()

                If CheckPaymentTerms = 0 Then
                    MsgBox("Invalid payment terms.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If

                'Convert date if necessary
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CustomerDate = dtpCustomerSince.Value
                Else
                    CustomerDate = dtpCustomerSince.Value
                    txtSalesTaxRate2.Text = 0
                    txtSalesTaxRate3.Text = 0
                End If

                If cboCustomerClass.Text = "DE-ACTIVATED" Then
                    'Check activity and de-activate Customer (activity = Outstanding A/R Balance)
                    LoadCustomerARAging()
                    If AROutstanding > -0.1 And AROutstanding < 0.1 Then
                        'Continue with Save Process
                    Else
                        MsgBox("Customer has A/R Balance - it cannot be de-activated.", MsgBoxStyle.OkOnly)
                        GlobalCustomerID = ""
                        GlobalCustomerName = ""
                        GlobalCustomerID2 = ""
                        ClearVariables()
                        ClearData()
                        Me.Dispose()
                        Me.Close()
                    End If
                    If CustomerActivitySummation = 0 Then
                        'Continue
                    Else
                        MsgBox("This customer has an open order, shipment, invoice, or return. It cannot be de-ativated.", MsgBoxStyle.OkOnly)
                        GlobalCustomerID = ""
                        GlobalCustomerName = ""
                        GlobalCustomerID2 = ""
                        ClearVariables()
                        ClearData()
                        Me.Dispose()
                        Me.Close()
                    End If
                Else
                    'Continue with Save Process
                End If
                '*****************************************************************************************************
                ValidatePaymentTermsChange()

                'Determine Hold Status
                If chkCreditHold.Checked = True Then
                    OnHoldStatus = "YES"
                Else
                    OnHoldStatus = "NO"
                End If
                '*****************************************************************************************************
                'Determine Accounting Hold Status
                If chkAccountingHold.Checked = True Then
                    AccountingHold = "YES"
                Else
                    AccountingHold = "NO"
                End If
                '*****************************************************************************************************
                'Check to see if any customers have the exact same name - do not save
                Dim CountNames As Integer = 0
                Dim CountIDS As Integer = 0

                Dim CountCustomerNamesStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
                Dim CountCustomerNamesCommand As New SqlCommand(CountCustomerNamesStatement, con)
                CountCustomerNamesCommand.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
                CountCustomerNamesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim CountCustomerIDSStatement As String = "SELECT COUNT(CustomerID) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim CountCustomerIDSCommand As New SqlCommand(CountCustomerIDSStatement, con)
                CountCustomerIDSCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                CountCustomerIDSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountNames = CInt(CountCustomerNamesCommand.ExecuteScalar)
                Catch ex As Exception
                    CountNames = 0
                End Try
                Try
                    CountIDS = CInt(CountCustomerIDSCommand.ExecuteScalar)
                Catch ex As Exception
                    CountIDS = 0
                End Try
                con.Close()
                '*****************************************************************************************************
                'Saves the customer data
                If CountNames = 0 And CountIDS = 0 Then 'Customer ID and Name does not exist for this division - INSERT
                    'Try to inser customer in database
                    Try
                        InsertIntoCustomerList()
                    Catch ex As Exception
                        'Log error on update failure

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Save Button - INSERT INTO CUSTOMER Failure - " + cboCustomerID.Text
                        ErrorReferenceNumber = cboCustomerID.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        MsgBox("New Customer has not been created.", MsgBoxStyle.OkOnly)
                    End Try
                ElseIf CountNames = 1 And CountIDS = 0 Then 'Customer ID does not exist, but name does. Fail with message.
                    MsgBox("A Customer exists with this name - cannot create a new customer.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Save Customer data to existing record
                    Try
                        UpdateCustomerList()
                    Catch ex As Exception
                        'Log error on update failure

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Save Button - UPDATE Customer Failure - " + cboCustomerID.Text
                        ErrorReferenceNumber = cboCustomerID.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
                '*******************************************************************************************************************
                ''checks to see if saving contacts is required
                If String.IsNullOrEmpty(cboContactDepartment.Text) = False Then
                    If canSaveContact() Then
                        Try
                            InsertIntoCustomerContacts()
                        Catch ex As Exception
                            Try
                                UpdateCustomerContacts()
                            Catch ex5 As Exception
                                'Log error on update failure

                                ErrorDate = Today()
                                ErrorComment = ex5.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Exit Button - Update Customer Contacts Failure - " + cboContactDepartment.Text
                                ErrorReferenceNumber = cboCustomerID.Text
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                    Else
                        Exit Sub
                    End If
                End If

                'Save Additional Ship To Data if necessary
                If String.IsNullOrEmpty(cboShipToID.Text) = False Then
                    If canSaveAddShipTo() Then
                        Try
                            InsertIntoAdditionShipTo()
                        Catch ex As Exception
                            Try
                                UpdateAdditionalShipTo()
                            Catch ex4 As Exception
                                'Log error on update failure

                                ErrorDate = Today()
                                ErrorComment = ex4.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "Exit Button - Update Additional Ship To Failure - " + cboShipToID.Text
                                ErrorReferenceNumber = cboCustomerID.Text
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End Try
                    Else
                        'Exit Routione without saving any data
                        Exit Sub
                    End If
                End If

                'Close Routine
                GlobalCustomerID = ""
                GlobalCustomerName = ""
                GlobalCustomerID2 = ""
                ClearVariables()
                ClearData()
                Me.Dispose()
                Me.Close()
            Else
                'Exit routine without saving any data
                Exit Sub
            End If
        Else
            GlobalCustomerID = ""
            GlobalCustomerName = ""
            GlobalCustomerID2 = ""
            ClearVariables()
            ClearData()
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub cmdClearDefaultShipping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearDefaultShipping.Click
        txtSTAddress1.Text = ""
        txtSTAddress2.Text = ""
        txtSTCity.Text = ""
        cboSTState.SelectedIndex = -1
        txtSTCountry.Text = ""
        txtSTZip.Text = ""
    End Sub

    Private Sub cmdViewSalesTotals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewSalesTotals.Click
        Using newCustomerDataViewSalesTotals As New CustomerDataViewSalesTotals(cboCustomerID.Text, cboDivisionID.Text)
            newCustomerDataViewSalesTotals.ShowDialog()
        End Using
    End Sub

    Private Sub cmdViewFoxes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewFoxes.Click
        GlobalCustomerID = cboCustomerID.Text

        Using NewCustomerFoxes As New CustomerFoxes
            Dim result = NewCustomerFoxes.ShowDialog()
        End Using
    End Sub

    Private Sub cmdCreditApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreditApp.Click
        If cboCustomerID.Text <> "" Then
            If File.Exists(GlobalCustomerCreditAPP) Then
                System.Diagnostics.Process.Start(GlobalCustomerCreditAPP)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdCCDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCCDelete.Click
        Dim RowCustomer, RowDepartment As String
        If Me.dgvCustomerContacts.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvCustomerContacts.CurrentCell.RowIndex

            RowCustomer = Me.dgvCustomerContacts.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowDepartment = Me.dgvCustomerContacts.Rows(RowIndex).Cells("ContactDepartmentColumn").Value

            Try
                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("DELETE FROM CustomerContacts WHERE CustomerID = @CustomerID AND ContactDepartment = @ContactDepartment AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                    .Add("@ContactDepartment", SqlDbType.VarChar).Value = RowDepartment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'No updates
            End Try
        Else

        End If
    End Sub

    Private Sub cmdViewTaxExemptForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewTaxExemptForm.Click
        If cboSalesTaxStatus.Text = "EXEMPT" Then
            LoadTaxExemptCert()

            If File.Exists(GlobalTaxExemptCert) Then
                System.Diagnostics.Process.Start(GlobalTaxExemptCert)
            Else
                MsgBox("File can not be found", MsgBoxStyle.OkOnly)
            End If
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdUploadPriceSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadPriceSheet.Click
        If cboCustomerID.Text = "" Then
            MsgBox("You must select a valid Customer.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            Dim CustomerDivision As String = ""
            Dim CustomerName As String = ""
            Dim CustomerPriceSheetFileName As String = ""
            Dim CustomerPriceSheetFilenameAndPath As String = ""
            Dim TempFilename As String = ""

            CustomerDivision = cboDivisionID.Text
            CustomerName = cboCustomerID.Text

            CustomerPriceSheetFileName = CustomerDivision + CustomerName + ".pdf"
            CustomerPriceSheetFilenameAndPath = "\\TFP-FS\TransferData\Customer Price Sheet\" + CustomerPriceSheetFileName

            'Open Dialog Box
            Dim myDocumentsFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            ofdPriceSheet.InitialDirectory = myDocumentsFolder + "\" + "My Paperport Documents\Samples"

            'Open File Dialog Box
            If ofdPriceSheet.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            'Get filename from dialog box
            TempFilename = ofdPriceSheet.FileName

            If TempFilename = "" Then
                Exit Sub
            End If

            'If Filename exists, delete the old file and copy over a new file
            If File.Exists(CustomerPriceSheetFilenameAndPath) Then
                File.Delete(CustomerPriceSheetFilenameAndPath)
            Else
                'Continue
            End If

            Try
                'Rename file
                File.Copy(TempFilename, CustomerPriceSheetFilenameAndPath)
                MsgBox("Customer Price Sheet Uploaded", MsgBoxStyle.OkOnly)

                CustomerDivision = ""
                CustomerName = ""
                CustomerPriceSheetFileName = ""
                CustomerPriceSheetFilenameAndPath = ""
                TempFilename = ""

            Catch ex As Exception
                'Rename(File)
                MsgBox("Filename already exists.", MsgBoxStyle.OkCancel)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub cmdCustomerPriceSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomerPriceSheet.Click
        Dim CustomerDivision As String = ""
        Dim CustomerName As String = ""
        Dim CustomerPriceSheetFileName As String = ""
        Dim CustomerPriceSheetFilenameAndPath As String = ""
        Dim TempFilename As String = ""

        CustomerDivision = cboDivisionID.Text
        CustomerName = cboCustomerID.Text

        CustomerPriceSheetFileName = CustomerDivision + CustomerName + ".pdf"
        CustomerPriceSheetFilenameAndPath = "\\TFP-FS\TransferData\Customer Price Sheet\" + CustomerPriceSheetFileName

        If File.Exists(CustomerPriceSheetFilenameAndPath) Then
            System.Diagnostics.Process.Start(CustomerPriceSheetFilenameAndPath)
        Else
            MsgBox("File can not be found", MsgBoxStyle.OkOnly)
        End If
    End Sub

    'Label and Bar Code Data

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
        V00 = cboCustomerName.Text
        V01 = txtSTAddress1.Text
        V02 = txtSTCity.Text & ", " & cboSTState.Text & " " & txtSTZip.Text
        V03 = txtSTAddress2.Text
        V04 = txtSTCountry.Text

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

        If V04.Length < 32 Then
            V18 = V04
        Else
            V18 = V04.Substring(0, 32)
        End If
        If cboDivisionID.Text = "CHT" Then
            V28 = "WELDING CERAMICS "
        Else
            V28 = "TFP CORP. "
        End If
        cmd = New SqlCommand("SELECT City, State, ZipCode, Phone FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            V28 += reader.GetValue(0) + ", " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3)
        Else

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

    Private Sub AddressLabelSetup()
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
        LabelFormat(16) = "A100,700,1,4,2,1,N," & Chr(34) & "PALLET        OF" & Chr(34)

        'Print Label

        LabelFormat(18) = vbFormFeed
        LabelLines = 17
    End Sub

    Private Sub cmdPrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintLabel.Click
        InitializeBarcodeVariables()
        FillBarCodeVariables()
        AddressLabelSetup()
        LabelFormat(LabelLines) = "P1"
        PrintBarcodeLine()
        InitializeBarcodeVariables()
    End Sub

    'Menu Items

    Private Sub ClearCustomerDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearCustomerDataToolStripMenuItem.Click
        ClearSalesLabels()
        ClearVariables()
        ClearData()
    End Sub

    Private Sub CustomerNotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerNotesToolStripMenuItem.Click
        GlobalCustomerID = cboCustomerID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Dim NewCustomerNotes As New CustomerNotes
        NewCustomerNotes.Show()
    End Sub

    Private Sub CustomerAccountDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerAccountDataToolStripMenuItem.Click
        GlobalCustomerID = cboCustomerID.Text
        GlobalDivisionCode = cboDivisionID.Text
        GlobalCustomerName = cboCustomerName.Text

        Using NewARCustomerAccounts As New ARCustomerAccounts
            Dim result = NewARCustomerAccounts.ShowDialog()
        End Using
    End Sub

    Private Sub CustomerOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerOrdersToolStripMenuItem.Click
        GlobalCustomerID = cboCustomerID.Text
        GlobalDivisionCode = cboDivisionID.Text
        GlobalCustomerName = cboCustomerName.Text

        Using NewViewCustomerOrders As New ViewCustomerOrders
            Dim result = NewViewCustomerOrders.ShowDialog()
        End Using
    End Sub

    Private Sub AgedReceivablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgedReceivablesToolStripMenuItem.Click
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewPrintARAging As New PrintARAging
            Dim result = NewPrintARAging.ShowDialog()
        End Using
    End Sub

    Private Sub CustomerSalesAnalysisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerSalesAnalysisToolStripMenuItem.Click
        GlobalDivisionCode = EmployeeCompanyCode

        Using NewPrintCustomerSalesReport As New PrintCustomerSalesReport
            Dim result = NewPrintCustomerSalesReport.ShowDialog()
        End Using
    End Sub

    Private Sub CustomerAccountDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerAccountDetailsToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintCustomerMTDYTDTotals As New PrintCustomerMTDYTDTotals
            Dim result = NewPrintCustomerMTDYTDTotals.ShowDialog()
        End Using
    End Sub

    Private Sub SaveCustomerDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveCustomerDataToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub PrintCustomerDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintCustomerDataToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub DeleteCustomerDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCustomerDataToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub CustomerOrderHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerOrderHistoryToolStripMenuItem.Click
        GlobalCustomerID = cboCustomerID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewCustomerSalesHistory As New CustomerSalesHistory
            Dim result = NewCustomerSalesHistory.ShowDialog()
        End Using
    End Sub

    Private Sub BackorderReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackorderReportToolStripMenuItem.Click
        BackorderCustomer = cboCustomerID.Text
        GlobalDivisionCode = cboDivisionID.Text

        BackorderReportFilter = "CUSTOMER"

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
            Using NewPrintBackOrdersFilteredRemote As New PrintBackOrdersFilteredRemote
                Dim Result = NewPrintBackOrdersFilteredRemote.ShowDialog()
            End Using
        Else
            Using NewPrintBackorderReport As New PrintBackOrdersFiltered
                Dim Result = NewPrintBackorderReport.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub CustomerHoldReportAutoprintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerHoldReportAutoprintToolStripMenuItem.Click
        'Load Dataset
        LoadCustomerHoldList()

        Dim MyReport9 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport9 = CRXMonthEndCustomerReport1
        MyReport9.SetDataSource(ds9)
        MyReport9.PrintToPrinter(1, True, 1, 999) '
        con.Close()
    End Sub

    Private Sub CustomerStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerStatementToolStripMenuItem.Click
        cmdCustomerStatement_Click(sender, e)
    End Sub

    'Validation 

    Public Sub ValidateAccountingHold()
        Dim OldAccountingHold, NewAccountingHold, AuditComment As String

        Dim GetAccountingHoldStatement As String = "SELECT AccountingHold FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
        Dim GetAccountingHoldCommand As New SqlCommand(GetAccountingHoldStatement, con)
        GetAccountingHoldCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetAccountingHoldCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            OldAccountingHold = CStr(GetAccountingHoldCommand.ExecuteScalar)
        Catch ex As Exception
            OldAccountingHold = "NO"
        End Try
        con.Close()

        If chkAccountingHold.Checked = True Then
            NewAccountingHold = "YES"
        Else
            NewAccountingHold = "NO"
        End If

        If OldAccountingHold = NewAccountingHold Then
            'Do nothing
        Else
            Try
                'Construct Audit Comment
                AuditComment = "Accounting Hold was changed from " + OldAccountingHold + " to " + NewAccountingHold

                '[Write to Audit Table
                cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "CUSTOMER MAINTENANCE - Accounting Hold Change"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = cboCustomerID.Text
                    .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub ValidateTaxChanges()
        Dim GetTaxRate1, GetTaxRate2, GetTaxRate3 As Double
        Dim TaxRate1Changed, TaxRate2Changed, TaxRate3Changed As String

        'Get Old Tax Rates for Customer
        Dim GetTaxRatesStatement As String = "SELECT SalesTaxRate, SalesTaxRate2, SalesTaxRate3 FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID"
        Dim GetTaxRatesCommand As New SqlCommand(GetTaxRatesStatement, con)
        GetTaxRatesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetTaxRatesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetTaxRatesCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("SalesTaxRate")) Then
                GetTaxRate1 = 0
            Else
                GetTaxRate1 = reader.Item("SalesTaxRate")
            End If
            If IsDBNull(reader.Item("SalesTaxRate2")) Then
                GetTaxRate2 = 0
            Else
                GetTaxRate2 = reader.Item("SalesTaxRate2")
            End If
            If IsDBNull(reader.Item("SalesTaxRate3")) Then
                GetTaxRate3 = 0
            Else
                GetTaxRate3 = reader.Item("SalesTaxRate3")
            End If
        Else
            GetTaxRate1 = 0
            GetTaxRate2 = 0
            GetTaxRate3 = 0
        End If
        reader.Close()
        con.Close()

        'Compare to new tax rates
        If GetTaxRate1 <> Val(txtSalesTaxRate.Text) Then
            TaxRate1Changed = "TRUE"
        Else
            TaxRate1Changed = "FALSE"
        End If

        If GetTaxRate2 <> Val(txtSalesTaxRate2.Text) Then
            TaxRate2Changed = "TRUE"
        Else
            TaxRate2Changed = "FALSE"
        End If

        If GetTaxRate3 <> Val(txtSalesTaxRate3.Text) Then
            TaxRate3Changed = "TRUE"
        Else
            TaxRate3Changed = "FALSE"
        End If

        If TaxRate1Changed = "TRUE" Or TaxRate2Changed = "TRUE" Or TaxRate3Changed = "TRUE" Then
            'Log into audit trail if they are not the same
            Dim AuditComment As String = ""
            Dim OldTax1Rate, OldTax2Rate, OldTax3Rate As Double
            Dim NewTax1Rate, NewTax2Rate, NewTax3Rate As Double
            Dim strOldTax1Rate, strOldTax2Rate, strOldTax3Rate As String
            Dim strNewTax1Rate, strNewTax2Rate, strNewTax3Rate As String
            Dim CommentP1, CommentP2, CommentP3 As String

            OldTax1Rate = GetTaxRate1
            OldTax2Rate = GetTaxRate2
            OldTax3Rate = GetTaxRate3
            NewTax1Rate = Val(txtSalesTaxRate.Text)
            NewTax2Rate = Val(txtSalesTaxRate2.Text)
            NewTax3Rate = Val(txtSalesTaxRate3.Text)

            strOldTax1Rate = CStr(OldTax1Rate)
            strOldTax2Rate = CStr(OldTax2Rate)
            strOldTax3Rate = CStr(OldTax3Rate)
            strNewTax1Rate = CStr(NewTax1Rate)
            strNewTax2Rate = CStr(NewTax2Rate)
            strNewTax3Rate = CStr(NewTax3Rate)

            If TaxRate1Changed = "TRUE" Then
                CommentP1 = "Tax Rate 1 - " + strOldTax1Rate + "/" + strNewTax1Rate + " "
            Else
                CommentP1 = ""
            End If
            If TaxRate2Changed = "TRUE" Then
                CommentP2 = "Tax Rate 2 - " + strOldTax2Rate + "/" + strNewTax2Rate + " "
            Else
                CommentP2 = ""
            End If
            If TaxRate3Changed = "TRUE" Then
                CommentP3 = "Tax Rate 3 - " + strOldTax3Rate + "/" + strNewTax3Rate
            Else
                CommentP3 = ""
            End If

            AuditComment = CommentP1 + CommentP2 + CommentP3

            Try
                cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "CUSTOMER MAINTENANCE - Tax Change"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = cboCustomerID.Text
                    .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try

            'Clear Variables
            OldTax1Rate = 0
            OldTax2Rate = 0
            OldTax3Rate = 0
            NewTax1Rate = 0
            NewTax2Rate = 0
            NewTax3Rate = 0
            strOldTax1Rate = ""
            strOldTax2Rate = ""
            strOldTax3Rate = ""
            strNewTax1Rate = ""
            strNewTax2Rate = ""
            strNewTax3Rate = ""
            CommentP1 = ""
            CommentP2 = ""
            CommentP3 = ""
        End If

        'Clear all variables used
        TaxRate1Changed = ""
        TaxRate2Changed = ""
        TaxRate3Changed = ""
    End Sub

    Private Sub Validation()
        If cboCustomerClass.Text = "" And cboDivisionID.Text = "TFF" Then
            cboCustomerClass.Text = "CANADIAN"
            CustomerClass = "CANADIAN"
        ElseIf cboCustomerClass.Text = "" And cboDivisionID.Text = "TOR" Then
            cboCustomerClass.Text = "CANADIAN"
            CustomerClass = "CANADIAN"
        ElseIf cboCustomerClass.Text = "" And (cboDivisionID.Text <> "TOR" And cboDivisionID.Text <> "TFF") Then
            cboCustomerClass.Text = "STANDARD"
            CustomerClass = "STANDARD"
        Else
            CustomerClass = cboCustomerClass.Text
        End If

        If cboPaymentTerms.Text = "" Then
            MsgBox("You must select a valid payment term.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    Public Sub ValidatePaymentTerms()
        If cboPaymentTerms.Text = "Prepaid" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "NetDue" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "COD" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "N30" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "CREDIT CARD" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "N60" And (cboDivisionID.Text = "TFP" Or cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TWE") Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "LOC" And (cboDivisionID.Text = "TFP" Or cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TWE") Then
            CheckPaymentTerms = 1
        Else
            CheckPaymentTerms = 0
        End If
    End Sub

    Public Sub ValidatePaymentTermsChange()
        'Get Current Payment Term saved in the database
        Dim SavedPaymentTerms As String = ""
        Dim CurrentPaymentTerms As String = ""

        Dim GetSavedPaymentTermsStatement As String = "SELECT PaymentTerms FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetSavedPaymentTermsCommand As New SqlCommand(GetSavedPaymentTermsStatement, con)
        GetSavedPaymentTermsCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        GetSavedPaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SavedPaymentTerms = CStr(GetSavedPaymentTermsCommand.ExecuteScalar)
        Catch ex As System.Exception
            SavedPaymentTerms = "NEW CUSTOMER"
        End Try
        con.Close()

        CurrentPaymentTerms = cboPaymentTerms.Text

        'Determine which action to take based on a new customer
        If (CurrentPaymentTerms = "CREDIT CARD" Or CurrentPaymentTerms = "NetDue" Or CurrentPaymentTerms = "Prepaid" Or CurrentPaymentTerms = "COD") And SavedPaymentTerms = "NEW CUSTOMER" Then
            chkAccountingHold.Checked = False
            chkCreditHold.Checked = False
        ElseIf (CurrentPaymentTerms = "N30" Or CurrentPaymentTerms = "N60") And SavedPaymentTerms = "NEW CUSTOMER" Then
            chkAccountingHold.Checked = False
            chkCreditHold.Checked = True
        ElseIf (CurrentPaymentTerms = "N30" Or CurrentPaymentTerms = "N60") And (SavedPaymentTerms = "CREDIT CARD" Or SavedPaymentTerms = "NetDue" Or SavedPaymentTerms = "COD" Or SavedPaymentTerms = "Prepaid") Then
            chkAccountingHold.Checked = False
            chkCreditHold.Checked = True
        Else
            'Skip until next validation
        End If
    End Sub

    Public Sub DisablePaymentIfLoaded()
        If cboCustomerID.Text = "" Then
            cboPaymentTerms.Enabled = True
            Exit Sub
        Else
            'Continue
        End If

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Or EmployeeSecurityCode = 1003 Or EmployeeSecurityCode = 1014 Then
            cboPaymentTerms.Enabled = True
            Exit Sub
        End If
    End Sub

    Public Sub ValidateEmailFields()
        If txtEmailStatements.Text.Contains(",") Then
            txtEmailStatements.Text.Replace(",", ";")

        End If

















    End Sub

    Private Function canSaveAddShipTo() As Boolean
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MsgBox("You must have a valid Customer ID selected.", MsgBoxStyle.OkOnly)
            cboCustomerID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboShipToID.Text) Then
            MessageBox.Show("You must enter a Ship to ID", "Enter a Ship to ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboShipToID.Focus()
            Return False
        End If
        If Not canSave() Then
            Return False
        End If
        If String.IsNullOrEmpty(txtAddAddress1.Text) Then
            MessageBox.Show("You must enter a shipping address", "Enter shipping address", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddAddress1.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAddCity.Text) Then
            MessageBox.Show("You must enter a city", "Enter a city", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddCity.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAddZip.Text) Then
            MessageBox.Show("You must enter a zipcode", "Enter a zipcode", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddZip.Focus()
            Return False
        End If
        If cboShipToID.SelectedIndex <> -1 Then
            Dim rslt As DialogResult = MessageBox.Show("Are you sure you want to overwrite " + cboShipToID.Text + "?", "Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If rslt <> Windows.Forms.DialogResult.Yes Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Function canDeleteAddShipTo() As Boolean
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MessageBox.Show("You must enter a customer ID", "Enter a customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.Focus()
            Return False
        End If
        If cboCustomerID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid customer ID", "Enter a valid customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.SelectAll()
            cboCustomerID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboShipToID.Text) Then
            MessageBox.Show("You must enter a ship to ID", "Enter a ship to ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboShipToID.Focus()
            Return False
        End If
        If cboShipToID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid ship to ID", "Enter a valid ship to ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboShipToID.SelectAll()
            cboShipToID.Focus()
            Return False
        End If
        If checkShipToActivity() Then
            MsgBox("This Ship To ID has activity and cannot be deleted.", MsgBoxStyle.OkOnly)
            cboShipToID.SelectAll()
            cboShipToID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function checkShipToActivity() As Boolean
        'Check to see if Additional Ship To has activity
        Dim CheckAddShipToString As String = "SELECT * FROM SalesOrderHeaderTable WHERE CustomerID = @CustomerID AND DivisionKey = @DivisionID AND AdditionalShipTo = @AdditionalShipTo"
        Dim CheckAddShipToCommand As New SqlCommand(CheckAddShipToString, con)
        CheckAddShipToCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CheckAddShipToCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CheckAddShipToCommand.Parameters.Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = CheckAddShipToCommand.ExecuteReader()
        Dim activity As Boolean = False
        If reader.HasRows Then
            reader.Close()
            con.Close()
            Return True
        End If
        reader.Close()
        con.Close()
        Return False
    End Function

    Private Function canSaveContact() As Boolean
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MsgBox("You must have a Customer ID selected.", MsgBoxStyle.OkOnly)
            cboCustomerID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboContactDepartment.Text) Then
            MessageBox.Show("You must enter a unique contact department", "Enter an unique contact department", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboContactDepartment.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtContactName.Text) Then
            MessageBox.Show("You must enter a contact name", "Enter a contact name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactName.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canDeleteContact() As Boolean
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MessageBox.Show("You must select a customer ID", "Select a customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.Focus()
            Return False
        End If
        If cboCustomerID.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid customer ID", "Select a valid customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.SelectAll()
            cboCustomerID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboContactDepartment.Text) Then
            MessageBox.Show("You must select a contact department", "Select a contact department", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboContactDepartment.Focus()
            Return False
        End If
        If cboContactDepartment.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid contact department", "Select a valid contact department", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboContactDepartment.SelectAll()
            cboContactDepartment.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MsgBox("You must have a Customer ID selected.", MsgBoxStyle.OkOnly)
            cboCustomerID.Focus()
            Return False
        End If
        If cboCustomerID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid customer ID", "Enter a valid customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.SelectAll()
            cboCustomerID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function canDeleteCustomer() As Boolean
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MsgBox("You must have a Customer ID selected.", MsgBoxStyle.OkOnly)
            cboCustomerID.Focus()
        End If
        If cboCustomerID.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid customer ID", "Select a valid customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.SelectAll()
            cboCustomerID.Focus()
            Return False
        End If
        If customerActive() Then
            MsgBox("You cannot delete this Customer because it has activity.", MsgBoxStyle.OkOnly)
            Return False
        End If
        'Prompt before Deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Customer's Data?", "DELETE DATA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Function customerActive() As Boolean
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Close()
            con.Close()
            Return True
        End If
        reader.Close()
        con.Close()

        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        reader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Close()
            con.Close()
            Return True
        End If
        reader.Close()
        con.Close()
        Return False
    End Function

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MsgBox("You must have a valid Customer ID selected.", MsgBoxStyle.OkOnly)
            cboCustomerID.Focus()
            Return False
        End If
        If cboCustomerID.Text = " " Then
            MsgBox("You must have a valid Customer ID selected.", MsgBoxStyle.OkOnly)
            cboCustomerID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboCustomerName.Text) Then
            MsgBox("You must have a valid Customer Name entered.", MsgBoxStyle.OkOnly)
            cboCustomerName.Focus()
            Return False
        End If
        If cboCustomerName.Text = " " Then
            MsgBox("You must have a valid Customer Name selected.", MsgBoxStyle.OkOnly)
            cboCustomerID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboCustomerClass.Text) Then
            MessageBox.Show("You must select a customer class", "Select a customer class", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerClass.Focus()
            Return False
        End If
        If cboCustomerClass.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid customer class", "select a valid customer class", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerClass.SelectAll()
            cboCustomerClass.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboPaymentTerms.Text) Then
            MessageBox.Show("You must enter a payment term.", "Enter Payment Terms", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPaymentTerms.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtBTAddress1.Text) Then
            MessageBox.Show("You must enter a Bill To Address", "Enter a billing address", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBTAddress1.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtBTCity.Text) Then
            MessageBox.Show("You must enter a Bill To City", "Enter a billing city", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBTCity.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtBTZip.Text) Then
            MessageBox.Show("You must enter a billing zip code", "Enter a billing Zip Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBTZip.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboBTState.Text) Then
            MessageBox.Show("You must enter a billing state or province", "Enter a billing state/province", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboBTState.Focus()
            Return False
        End If
        '********************************************************************************
        Dim badChars As String = ":,/!#$%^&*()[]+=<>?"

        If txtEmailCerts.Text.Count(Function(c) badChars.Contains(c)) > 0 Then
            MsgBox("This is not a valid cert email address.", MsgBoxStyle.OkOnly)
            Return False
        End If
        If txtEmailPackingLists.Text.Count(Function(c) badChars.Contains(c)) > 0 Then
            MsgBox("This is not a valid packing list email address.", MsgBoxStyle.OkOnly)
            Return False
        End If
        If txtEmailStatements.Text.Count(Function(c) badChars.Contains(c)) > 0 Then
            MsgBox("This is not a valid statement email address.", MsgBoxStyle.OkOnly)
            Return False
        End If
        If txtEmailConfirmations.Text.Count(Function(c) badChars.Contains(c)) > 0 Then
            MsgBox("This is not a valid confirmation email address.", MsgBoxStyle.OkOnly)
            Return False
        End If
        '********************************************************************************
        'Validate Email Fields
        If txtEmailStatements.Text.EndsWith(" ") Then
            txtEmailStatements.Text = txtEmailStatements.Text.TrimEnd(" ")
        End If
        If txtEmailStatements.Text.EndsWith(";") Then
            txtEmailStatements.Text = txtEmailStatements.Text.TrimEnd(";")
        End If
        If txtEmailCerts.Text.EndsWith(" ") Then
            txtEmailCerts.Text = txtEmailCerts.Text.TrimEnd(" ")
        End If
        If txtEmailCerts.Text.EndsWith(";") Then
            txtEmailCerts.Text = txtEmailCerts.Text.TrimEnd(";")
        End If
        If txtEmailPackingLists.Text.EndsWith(" ") Then
            txtEmailPackingLists.Text = txtEmailPackingLists.Text.TrimEnd(" ")
        End If
        If txtEmailPackingLists.Text.EndsWith(";") Then
            txtEmailPackingLists.Text = txtEmailPackingLists.Text.TrimEnd(";")
        End If
        If txtEmailConfirmations.Text.EndsWith(" ") Then
            txtEmailConfirmations.Text = txtEmailConfirmations.Text.TrimEnd(" ")
        End If
        If txtEmailCerts.Text.EndsWith(";") Then
            txtEmailConfirmations.Text = txtEmailConfirmations.Text.TrimEnd(";")
        End If
        '**********************************************************************************
        Dim badChars2 As String = "!@$%^*+=[]{},<>?:;"
        If cboCustomerID.Text.Count(Function(c) badChars2.Contains(c)) > 0 Then
            MsgBox("You cannot use one of these characters in a Customer ID.", MsgBoxStyle.OkOnly)
            Return False
        End If
        '**********************************************************************************
        If cboDivisionID.Text.Equals("TWD") Then
            If String.IsNullOrEmpty(cboSalesTerritory.Text) Then
                MessageBox.Show("You must enter a Sales Territory", "Enter a sales territory", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboSalesTerritory.Focus()
                Return False
            End If
            If cboSalesTerritory.SelectedIndex = -1 Then
                MessageBox.Show("You must select a valid sales territory", "Select a valid sales territory", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboSalesTerritory.SelectAll()
                cboSalesTerritory.Focus()
                Return False
            End If
        End If
        '**********************************************************************************
        'Validate Sales Tax for American Companies ONLY
        Dim VerifyTaxStatus As String = ""

        If cboSalesTaxStatus.Text = "EXEMPT" Then
            VerifyTaxStatus = "OK"
        ElseIf cboSalesTaxStatus.Text = "TAXABLE" Then
            VerifyTaxStatus = "OK"
        ElseIf cboSalesTaxStatus.Text = "OUT-OF-STATE" Then
            VerifyTaxStatus = "OK"
        Else
            VerifyTaxStatus = "NOT OK"
        End If

        If cboDivisionID.Text = "TFF" Then
            'Skip Routine
        ElseIf cboDivisionID.Text = "TOR" Then
            'Skip Routine
        ElseIf cboDivisionID.Text = "ALB" Then
            'Skip Routine
        Else
            If cboSalesTaxStatus.Text = "EXEMPT" And Val(txtSalesTaxRate.Text) <> 0 Then
                MsgBox("EXEMPT Customers cannot have a tax rate saved.", MsgBoxStyle.OkOnly)
                Return False
            ElseIf cboSalesTaxStatus.Text = "OUT-OF-STATE" And Val(txtSalesTaxRate.Text) <> 0 Then
                MsgBox("OUT-OF-STATE Customers cannot have a tax rate saved.", MsgBoxStyle.OkOnly)
                Return False
            ElseIf cboSalesTaxStatus.Text = "TAXABLE" And Val(txtSalesTaxRate.Text) = 0 Then
                MsgBox("TAXABLE Customers must have a tax rate saved.", MsgBoxStyle.OkOnly)
                Return False
            ElseIf VerifyTaxStatus = "NOT OK" Then
                MsgBox("You must select a valid tax status before saving.", MsgBoxStyle.OkOnly)
                Return False
            End If
        End If
        Return True
    End Function

    Private Function canExit() As Boolean
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            Return False
        End If
        If shouldSave = False And shouldSaveAddress = False And shouldSaveContact = False Then
            Return False
        End If
        Return True
    End Function

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

    Public Sub ValidateEmailAddresses()
        Dim badChars As String = ":,/!#$%^&*()[]+=<>?"
        If txtEmailCerts.Text.Count(Function(c) badChars.Contains(c)) > 0 Then
            MsgBox("This is not a valid email address.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Public Sub ValidateCustomerID()
        Dim badChars As String = "!@$%^*+=[]{},<>?:;"
        If cboCustomerID.Text.Count(Function(c) badChars.Contains(c)) > 0 Then
            MsgBox("You cannot use one of these characters in a Customer ID.", MsgBoxStyle.OkOnly)
            ValidateCustomerForBadCharacters = "YES"
        Else
            ValidateCustomerForBadCharacters = "NO"
        End If
    End Sub

    'Check Box Changed Event

    Private Sub chkAddGST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddGST.CheckedChanged
        If chkAddGST.Checked = True Then
            txtSalesTaxRate.Text = 0.05
            chkAddHST.Checked = False
        Else
            txtSalesTaxRate.Text = 0
        End If
    End Sub

    Private Sub chkAddPST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddPST.CheckedChanged
        If chkAddPST.Checked = True Then
            txtSalesTaxRate2.Text = 0.07
            chkAddHST.Checked = False
        Else
            txtSalesTaxRate2.Text = 0
        End If
    End Sub

    Private Sub chkAddHST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddHST.CheckedChanged
        If chkAddHST.Checked = True Then
            chkAddGST.Checked = False
            chkAddPST.Checked = False
            txtSalesTaxRate.Text = 0.0
            txtSalesTaxRate2.Text = 0.0
            txtSalesTaxRate3.Text = 0.0
        Else
            txtSalesTaxRate3.Text = 0
        End If
    End Sub

    Private Sub chkCreditHold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCreditHold.CheckedChanged
        If chkCreditHold.Checked = True Then
            OnHoldStatus = "YES"
            lblHoldBanner.Text = "Customer is on Credit Hold"
        Else
            OnHoldStatus = "NO"
            lblHoldBanner.Text = ""
        End If
    End Sub

    Private Sub chkAccountingHold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAccountingHold.CheckedChanged
        If chkAccountingHold.Checked = True Then
            AccountingHold = "YES"
            lblHoldBanner.Text = "Customer is on Accounting Hold"
        Else
            AccountingHold = "NO"
            lblHoldBanner.Text = ""
        End If
    End Sub

    'Update or Insert Sub-routines

    Private Sub UpdateCustomerList()
        'Create command to update database and fill with text box enties
        LoadSalesTerritory()
        ValidateTaxChanges()

        If cboBankAccount.Text = "" Then
            If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
                cboBankAccount.Text = "Checking"
            ElseIf cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                cboBankAccount.Text = "Canadian Checking"
            Else
                cboBankAccount.Text = "Cash Receipts"
            End If
        End If

        'Validate Email Addresses
        Dim TempStatementEmail As String = ""
        Dim TempConfirmationEmail As String = ""
        Dim TempPackingListEmail As String = ""
        Dim TempCertEmail As String = ""
        Dim TempSalesContactEmail As String = ""
        Dim TempInvoiceCertEmail As String = ""
        Dim TempInvoiceEmail As String = ""

        Dim FieldLength1 As Integer = 0
        Dim FieldLength2 As Integer = 0
        Dim FieldLength3 As Integer = 0
        Dim FieldLength4 As Integer = 0
        Dim FieldLength5 As Integer = 0
        Dim FieldLength6 As Integer = 0
        Dim FieldLength7 As Integer = 0

        TempStatementEmail = txtEmailStatements.Text
        TempConfirmationEmail = txtEmailConfirmations.Text
        TempPackingListEmail = txtEmailPackingLists.Text
        TempCertEmail = txtEmailCerts.Text
        TempSalesContactEmail = txtSalesContactEmail.Text
        TempInvoiceCertEmail = txtInvoiceCertEmail.Text
        TempInvoiceEmail = txtInvoiceEmail.Text

        FieldLength1 = TempStatementEmail.Length
        FieldLength2 = TempConfirmationEmail.Length
        FieldLength3 = TempPackingListEmail.Length
        FieldLength4 = TempCertEmail.Length
        FieldLength5 = TempSalesContactEmail.Length
        FieldLength6 = TempInvoiceCertEmail.Length
        FieldLength7 = TempInvoiceEmail.Length

        If TempStatementEmail.EndsWith(";") Then '
            TempStatementEmail = TempStatementEmail.Substring(0, FieldLength1 - 1)
        End If
        If TempConfirmationEmail.EndsWith(";") Then '
            TempConfirmationEmail = TempConfirmationEmail.Substring(0, FieldLength2 - 1)
        End If
        If TempPackingListEmail.EndsWith(";") Then '
            TempPackingListEmail = TempPackingListEmail.Substring(0, FieldLength3 - 1)
        End If
        If TempCertEmail.EndsWith(";") Then '
            TempCertEmail = TempCertEmail.Substring(0, FieldLength4 - 1)
        End If
        If TempSalesContactEmail.EndsWith(";") Then '
            TempSalesContactEmail = TempSalesContactEmail.Substring(0, FieldLength5 - 1)
        End If
        If TempInvoiceCertEmail.EndsWith(";") Then '
            TempInvoiceCertEmail = TempInvoiceCertEmail.Substring(0, FieldLength6 - 1)
        End If
        If TempInvoiceEmail.EndsWith(";") Then '
            TempInvoiceEmail = TempInvoiceEmail.Substring(0, FieldLength7 - 1)
        End If

        txtEmailStatements.Text = TempStatementEmail
        txtEmailConfirmations.Text = TempConfirmationEmail
        txtEmailPackingLists.Text = TempPackingListEmail
        txtEmailCerts.Text = TempCertEmail
        txtSalesContactEmail.Text = TempSalesContactEmail
        txtInvoiceCertEmail.Text = TempInvoiceCertEmail
        txtInvoiceEmail.Text = TempInvoiceEmail
        '****************************************************************
        'Validate Vendor Name and remittance email
        '****************************************************************
        Dim CheckCustomerNameField As String = ""
        Dim CheckStatementEmail As String = ""

        If cboCustomerName.Text.Contains(",") Then
            CheckCustomerNameField = cboCustomerName.Text.Replace(",", "")
        Else
            CheckCustomerNameField = cboCustomerName.Text
        End If
        If CheckCustomerNameField.Contains(vbCrLf) Then
            CheckCustomerNameField = CheckCustomerNameField.Replace(vbCrLf, "")
        Else
            'Do nothing
        End If
        If txtEmailStatements.Text.Contains(",") Then
            CheckStatementEmail = txtEmailStatements.Text.Replace(",", ";")
        Else
            CheckStatementEmail = txtEmailStatements.Text
        End If
        If CheckStatementEmail.Contains(vbCrLf) Then
            CheckStatementEmail = CheckStatementEmail.Replace(vbCrLf, "")
        Else
            'Do nothing
        End If

        cboCustomerName.Text = CheckCustomerNameField
        txtEmailStatements.Text = CheckStatementEmail
        '**********************************************************
        ValidateCustomerID()

        If ValidateCustomerForBadCharacters = "YES" Then
            Exit Sub
        Else
            'Do nothing and continue
            ValidateCustomerForBadCharacters = ""
        End If
        '**********************************************************
        'Update Customer Table
        cmd = New SqlCommand("UPDATE CustomerList SET CustomerName = @CustomerName, CustomerDate = @CustomerDate, ShipToAddress1 = @ShipToAddress1, ShipToAddress2 = @ShipToAddress2, ShipToCity = @ShipToCity, ShipToState = @ShipToState, ShipToZip = @ShipToZip, ShipToCountry = @ShipToCountry, BillToAddress1 = @BillToAddress1, BillToAddress2 = @BillToAddress2, BillToCity = @BillToCity, BillToState = @BillToState, BillToZip = @BillToZip, BillToCountry = @BillToCountry, Comments = @Comments, PaymentTerms = @PaymentTerms, CreditLimit = @CreditLimit, SalesTaxRate = @SalesTaxRate, PreferredShipper = @PreferredShipper, OldCustomerNumber = @OldCustomerNumber, CustomerClass = @CustomerClass, SalesTerritory = @SalesTerritory, ShippingDetails = @ShippingDetails, OnHoldStatus = @OnHoldStatus, APContactName = @APContactName, APPhoneNumber = @APPhoneNumber, APFAXNumber = @APFAXNumber, APEmailAddress = @APEmailAddress, InvoiceEmail = @InvoiceEmail, InvoiceCertEmail = @InvoiceCertEmail, SalesTaxRate2 = @SalesTaxRate2, SalesTaxRate3 = @SalesTaxRate3, SalesTaxID = @SalesTaxID, AccountingHold = @AccountingHold, PricingLevel = @PricingLevel, BillingType = @BillingType, ShipEmail = @ShipEmail, ShippingAccount = @ShippingAccount, BankAccount = @BankAccount, ConfirmationEmail = @ConfirmationEmail, StatementEmail = @StatementEmail, CertEmail = @CertEmail, PackingListEmail = @PackingListEmail, SalesContactEmail = @SalesContactEmail, SalesTaxStatus = @SalesTaxStatus WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text.ToUpper
            .Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text.ToUpper
            .Add("@CustomerDate", SqlDbType.VarChar).Value = CustomerDate.ToShortDateString
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtSTAddress1.Text.ToUpper
            .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtSTAddress2.Text.ToUpper
            .Add("@ShipToCity", SqlDbType.VarChar).Value = txtSTCity.Text.ToUpper
            .Add("@ShipToState", SqlDbType.VarChar).Value = cboSTState.Text.ToUpper
            .Add("@ShipToZip", SqlDbType.VarChar).Value = txtSTZip.Text
            .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtSTCountry.Text.ToUpper
            .Add("@BillToAddress1", SqlDbType.VarChar).Value = txtBTAddress1.Text.ToUpper
            .Add("@BillToAddress2", SqlDbType.VarChar).Value = txtBTAddress2.Text.ToUpper
            .Add("@BillToCity", SqlDbType.VarChar).Value = txtBTCity.Text.ToUpper
            .Add("@BillToState", SqlDbType.VarChar).Value = cboBTState.Text.ToUpper
            .Add("@BillToZip", SqlDbType.VarChar).Value = txtBTZip.Text
            .Add("@BillToCountry", SqlDbType.VarChar).Value = txtBTCountry.Text.ToUpper
            .Add("@Comments", SqlDbType.VarChar).Value = txtCustomerComment.Text
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
            .Add("@CreditLimit", SqlDbType.VarChar).Value = Val(txtCreditLimit.Text)
            .Add("@SalesTaxRate", SqlDbType.VarChar).Value = Val(txtSalesTaxRate.Text)
            .Add("@PreferredShipper", SqlDbType.VarChar).Value = cboShipper.Text
            .Add("@OldCustomerNumber", SqlDbType.VarChar).Value = txtOldCustomerNumber.Text
            .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
            .Add("@SalesTerritory", SqlDbType.VarChar).Value = GetSalesTerritory
            .Add("@ShippingDetails", SqlDbType.VarChar).Value = txtShippingInstructions.Text
            .Add("@OnHoldStatus", SqlDbType.VarChar).Value = OnHoldStatus
            .Add("@APContactName", SqlDbType.VarChar).Value = txtAPContactName.Text
            .Add("@APPhoneNumber", SqlDbType.VarChar).Value = txtAPPhoneNumber.Text
            .Add("@APFAXNumber", SqlDbType.VarChar).Value = txtAPFaxNumber.Text
            .Add("@APEmailAddress", SqlDbType.VarChar).Value = txtAPEmailAddress.Text
            .Add("@InvoiceEmail", SqlDbType.VarChar).Value = txtInvoiceEmail.Text
            .Add("@InvoiceCertEmail", SqlDbType.VarChar).Value = txtInvoiceCertEmail.Text
            .Add("@SalesTaxRate2", SqlDbType.VarChar).Value = Val(txtSalesTaxRate2.Text)
            .Add("@SalesTaxRate3", SqlDbType.VarChar).Value = Val(txtSalesTaxRate3.Text)
            .Add("@SalesTaxID", SqlDbType.VarChar).Value = txtTaxID.Text
            .Add("@AccountingHold", SqlDbType.VarChar).Value = AccountingHold
            .Add("@PricingLevel", SqlDbType.VarChar).Value = txtPricingReview.Text
            .Add("@BillingType", SqlDbType.VarChar).Value = cboBillingType.Text
            .Add("@ShipEmail", SqlDbType.VarChar).Value = txtShipEmail.Text
            .Add("@ShippingAccount", SqlDbType.VarChar).Value = txtShippingAccount.Text
            .Add("@BankAccount", SqlDbType.VarChar).Value = cboBankAccount.Text
            .Add("@ConfirmationEmail", SqlDbType.VarChar).Value = TempConfirmationEmail
            .Add("@StatementEmail", SqlDbType.VarChar).Value = TempStatementEmail
            .Add("@CertEmail", SqlDbType.VarChar).Value = TempCertEmail
            .Add("@PackingListEmail", SqlDbType.VarChar).Value = TempPackingListEmail
            .Add("@SalesContactEmail", SqlDbType.VarChar).Value = TempSalesContactEmail
            .Add("@SalesTaxStatus", SqlDbType.VarChar).Value = cboSalesTaxStatus.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub InsertIntoCustomerList()
        'Create command to insert new record into database
        LoadSalesTerritory()
        '**********************************************************
        If cboBankAccount.Text = "" Then
            If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
                cboBankAccount.Text = "Checking"
            ElseIf cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                cboBankAccount.Text = "Canadian Checking"
            Else
                cboBankAccount.Text = "Cash Receipts"
            End If
        End If
        '**********************************************************
        ValidateCustomerID()

        If ValidateCustomerForBadCharacters = "YES" Then
            Exit Sub
        Else
            'Do nothing and continue
            ValidateCustomerForBadCharacters = ""
        End If
        '**********************************************************
        'Create new customer
        cmd = New SqlCommand("INSERT INTO CustomerList (CustomerID, CustomerName, CustomerDate, DivisionID, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, BillToCountry, Comments, PaymentTerms, CreditLimit, SalesTaxRate, PreferredShipper, OldCustomerNumber, CustomerClass, SalesTerritory, ShippingDetails, OnHoldStatus, APContactName, APPhoneNumber, APFAXNumber, APEmailAddress, InvoiceEmail, InvoiceCertEmail, SalesTaxRate2, SalesTaxRate3, SalesTaxID, AccountingHold, PricingLevel, BillingType, ShipEmail, ShippingAccount, BankAccount, ConfirmationEmail, StatementEmail, CertEmail, PackingListEmail, SalesContactEmail, SalesTaxStatus)Values(@CustomerID, @CustomerName, @CustomerDate, @DivisionID, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @BillToAddress1, @BillToAddress2, @BillToCity, @BillToState, @BillToZip, @BillToCountry, @Comments, @PaymentTerms, @CreditLimit, @SalesTaxRate, @PreferredShipper, @OldCustomerNumber, @CustomerClass, @SalesTerritory, @ShippingDetails, @OnHoldStatus, @APContactName, @APPhoneNumber, @APFAXNumber, @APEmailAddress, @InvoiceEmail, @InvoiceCertEmail, @SalesTaxRate2, @SalesTaxRate3, @SalesTaxID, @AccountingHold, @PricingLevel, @BillingType, @ShipEmail, @ShippingAccount, @BankAccount, @ConfirmationEmail, @StatementEmail, @CertEmail, @PackingListEmail, @SalesContactEmail, @SalesTaxStatus)", con)

        With cmd.Parameters
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text.ToUpper
            .Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text.ToUpper
            .Add("@CustomerDate", SqlDbType.VarChar).Value = CustomerDate
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtSTAddress1.Text.ToUpper
            .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtSTAddress2.Text.ToUpper
            .Add("@ShipToCity", SqlDbType.VarChar).Value = txtSTCity.Text.ToUpper
            .Add("@ShipToState", SqlDbType.VarChar).Value = cboSTState.Text.ToUpper
            .Add("@ShipToZip", SqlDbType.VarChar).Value = txtSTZip.Text
            .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtSTCountry.Text.ToUpper
            .Add("@BillToAddress1", SqlDbType.VarChar).Value = txtBTAddress1.Text.ToUpper
            .Add("@BillToAddress2", SqlDbType.VarChar).Value = txtBTAddress2.Text.ToUpper
            .Add("@BillToCity", SqlDbType.VarChar).Value = txtBTCity.Text.ToUpper
            .Add("@BillToState", SqlDbType.VarChar).Value = cboBTState.Text.ToUpper
            .Add("@BillToZip", SqlDbType.VarChar).Value = txtBTZip.Text
            .Add("@BillToCountry", SqlDbType.VarChar).Value = txtBTCountry.Text.ToUpper
            .Add("@Comments", SqlDbType.VarChar).Value = txtCustomerComment.Text
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
            .Add("@CreditLimit", SqlDbType.VarChar).Value = Val(txtCreditLimit.Text)
            .Add("@SalesTaxRate", SqlDbType.VarChar).Value = Val(txtSalesTaxRate.Text)
            .Add("@PreferredShipper", SqlDbType.VarChar).Value = cboShipper.Text
            .Add("@OldCustomerNumber", SqlDbType.VarChar).Value = txtOldCustomerNumber.Text
            .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
            .Add("@SalesTerritory", SqlDbType.VarChar).Value = GetSalesTerritory
            .Add("@ShippingDetails", SqlDbType.VarChar).Value = txtShippingInstructions.Text
            .Add("@OnHoldStatus", SqlDbType.VarChar).Value = OnHoldStatus
            .Add("@APContactName", SqlDbType.VarChar).Value = txtAPContactName.Text
            .Add("@APPhoneNumber", SqlDbType.VarChar).Value = txtAPPhoneNumber.Text
            .Add("@APFAXNumber", SqlDbType.VarChar).Value = txtAPFaxNumber.Text
            .Add("@APEmailAddress", SqlDbType.VarChar).Value = txtAPEmailAddress.Text
            .Add("@InvoiceEmail", SqlDbType.VarChar).Value = txtInvoiceEmail.Text
            .Add("@InvoiceCertEmail", SqlDbType.VarChar).Value = txtInvoiceCertEmail.Text
            .Add("@SalesTaxRate2", SqlDbType.VarChar).Value = Val(txtSalesTaxRate2.Text)
            .Add("@SalesTaxRate3", SqlDbType.VarChar).Value = Val(txtSalesTaxRate3.Text)
            .Add("@SalesTaxID", SqlDbType.VarChar).Value = txtTaxID.Text
            .Add("@AccountingHold", SqlDbType.VarChar).Value = AccountingHold
            .Add("@PricingLevel", SqlDbType.VarChar).Value = txtPricingReview.Text
            .Add("@BillingType", SqlDbType.VarChar).Value = cboBillingType.Text
            .Add("@ShipEmail", SqlDbType.VarChar).Value = txtShipEmail.Text
            .Add("@ShippingAccount", SqlDbType.VarChar).Value = txtShippingAccount.Text
            .Add("@BankAccount", SqlDbType.VarChar).Value = cboBankAccount.Text
            .Add("@ConfirmationEmail", SqlDbType.VarChar).Value = txtEmailConfirmations.Text
            .Add("@StatementEmail", SqlDbType.VarChar).Value = txtEmailStatements.Text
            .Add("@CertEmail", SqlDbType.VarChar).Value = txtEmailCerts.Text
            .Add("@PackingListEmail", SqlDbType.VarChar).Value = txtEmailPackingLists.Text
            .Add("@SalesContactEmail", SqlDbType.VarChar).Value = txtSalesContactEmail.Text
            .Add("@SalesTaxStatus", SqlDbType.VarChar).Value = "TAXABLE"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Put customer on hold
        chkCreditHold.Checked = True

        Dim temp As String = cboCustomerID.Text
        LoadCustomerList()
        cboCustomerID.Text = temp
    End Sub

    Private Sub UpdateAdditionalShipTo()
        cmd = New SqlCommand("UPDATE AdditionalShipTo SET Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country, Name = @Name WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text.ToUpper
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text.ToUpper
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Address1", SqlDbType.VarChar).Value = txtAddAddress1.Text.ToUpper
            .Add("@Address2", SqlDbType.VarChar).Value = txtAddAddress2.Text.ToUpper
            .Add("@City", SqlDbType.VarChar).Value = txtAddCity.Text.ToUpper
            .Add("@State", SqlDbType.VarChar).Value = cboAddState.Text.ToUpper
            .Add("@Zip", SqlDbType.VarChar).Value = txtAddZip.Text
            .Add("@Country", SqlDbType.VarChar).Value = txtAddCountry.Text.ToUpper
            .Add("@Name", SqlDbType.VarChar).Value = txtAddShipToName.Text.ToUpper
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub InsertIntoAdditionShipTo()
        cmd = New SqlCommand("Insert Into AdditionalShipTo(ShipToID, CustomerID, DivisionID, Address1, Address2, City, State, Zip, Country, Name) Values (@ShipToID, @CustomerID, @DivisionID, @Address1, @Address2, @City, @State, @Zip, @Country, @Name)", con)

        With cmd.Parameters
            .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text.ToUpper
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text.ToUpper
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@Address1", SqlDbType.VarChar).Value = txtAddAddress1.Text.ToUpper
            .Add("@Address2", SqlDbType.VarChar).Value = txtAddAddress2.Text.ToUpper
            .Add("@City", SqlDbType.VarChar).Value = txtAddCity.Text.ToUpper
            .Add("@State", SqlDbType.VarChar).Value = cboAddState.Text.ToUpper
            .Add("@Zip", SqlDbType.VarChar).Value = txtAddZip.Text
            .Add("@Country", SqlDbType.VarChar).Value = txtAddCountry.Text.ToUpper
            .Add("@Name", SqlDbType.VarChar).Value = txtAddShipToName.Text.ToUpper
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        ShowAdditionalShipTo()
    End Sub

    Private Sub UpdateCustomerContacts()
        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("UPDATE CustomerContacts SET ContactName = @ContactName, ContactEmail = @ContactEmail, ContactPhone = @ContactPhone, ContactFax = @ContactFax WHERE  CustomerID = @CustomerID AND ContactDepartment = @ContactDepartment AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@ContactName", SqlDbType.VarChar).Value = txtContactName.Text
            .Add("@ContactEmail", SqlDbType.VarChar).Value = txtContactEmail.Text
            .Add("@ContactPhone", SqlDbType.VarChar).Value = txtContactPhone.Text
            .Add("@ContactFax", SqlDbType.VarChar).Value = txtContactFax.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@ContactDepartment", SqlDbType.VarChar).Value = cboContactDepartment.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub InsertIntoCustomerContacts()
        'Create command to update database and fill with text box enties
        cmd = New SqlCommand("Insert Into CustomerContacts(ContactName, ContactEmail, ContactPhone, ContactFax, CustomerID, ContactDepartment, DivisionID) Values (@ContactName, @ContactEmail, @ContactPhone, @ContactFax, @CustomerID, @ContactDepartment, @DivisionID)", con)

        With cmd.Parameters
            .Add("@ContactName", SqlDbType.VarChar).Value = txtContactName.Text
            .Add("@ContactEmail", SqlDbType.VarChar).Value = txtContactEmail.Text
            .Add("@ContactPhone", SqlDbType.VarChar).Value = txtContactPhone.Text
            .Add("@ContactFax", SqlDbType.VarChar).Value = txtContactFax.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@ContactDepartment", SqlDbType.VarChar).Value = cboContactDepartment.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        LoadCustomerContacts()
    End Sub

    'Misc Sub-Routines, Events, or Methods

    Private Sub CustomerData_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If shouldChangeState(e) Then
            shouldSave = True
        End If
    End Sub

    Private Function shouldChangeState(ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean
        If e.KeyCode = Keys.Tab Then
            Return False
        End If
        If e.KeyCode = Keys.Enter Then
            Return False
        End If
        If cboCustomerID.Focused Then
            Return False
        End If
        If cboContactDepartment.Focused Then
            Return False
        End If
        If cboShipToID.Focused Then
            Return False
        End If
        If cboDivisionID.Focused Then
            Return False
        End If
        If cmdClear.Focused Then
            Return False
        End If
        If cmdClearAdditionalShipTo.Focused Then
            Return False
        End If
        If cmdClearContact.Focused Then
            Return False
        End If
        If cmdSave.Focused Then
            Return False
        End If
        If cmdPrint.Focused Then
            Return False
        End If
        If cmdCustomerStatement.Focused Then
            Return False
        End If
        If cmdSalesHistory.Focused Then
            Return False
        End If
        If cmdOpenOrders.Focused Then
            Return False
        End If
        Return True
    End Function

    Private Sub TabControl2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tabContactTabControl.KeyUp
        If tabContactTabControl.SelectedIndex = 0 Then
            If shouldChangeState(e) Then
                shouldSaveContact = True
            End If
        Else
            CustomerData_KeyUp(sender, e)
        End If
    End Sub

    Private Sub tcAddress_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tcAddress.KeyUp
        If tcAddress.SelectedIndex = 2 Then
            If shouldChangeState(e) Then
                shouldSaveAddress = True
            End If
        Else
            CustomerData_KeyUp(sender, e)
        End If
    End Sub

    Private Sub tabMiscCustomerData_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tabMiscCustomerData.KeyUp
        CustomerData_KeyUp(sender, e)
    End Sub

    Private Sub cboCustomerID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.Leave
        If cboCustomerID.SelectedIndex = -1 Then
            shouldSave = True
        End If
    End Sub

    Private Sub cboShipToID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipToID.Leave
        If cboShipToID.SelectedIndex = -1 Then
            shouldSave = True
        End If
    End Sub

    Private Sub cboContactDepartment_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContactDepartment.Leave
        If cboContactDepartment.SelectedIndex = -1 Then
            shouldSave = True
        End If
    End Sub

    Private Sub cmdCustomerCreditForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomerCreditForm.Click
        Try
            ds2.Clear()
            GDS3.Clear()
        Catch exc As System.Exception

        End Try

        CreditVariables.CustomerID = cboCustomerID.Text
        CreditVariables.DivisionID = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            cmd4 = New SqlCommand("SELECT CustomerName, CustomerDate, BillToAddress1, BillToAddress2, BillToCity, BillToState, BillToZip, CustomerID, DivisionID, BillToCountry FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd4.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            myAdapter1.SelectCommand = cmd4
            myAdapter1.Fill(ds2, "CustomerList")

            cmd3 = New SqlCommand("SELECT EmployeeLast, EmployeeFirst FROM EmployeeData WHERE LoginName = @LoginName", con)
            cmd3.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName
            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds2, "EmployeeData")

            cmd1 = New SqlCommand("SELECT CustomerID, DivisionID, PaymentDate, InvoiceDate FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
            cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CreditVariables.DivisionID
            cmd1.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CreditVariables.CustomerID
            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds2, "ARCustomerPayment")

            cmd2 = New SqlCommand("SELECT CustomerID, AgingLessThan30, Aging31To45, Aging46To60, Aging61To90, AgingMoreThan90, DivisionID FROM ARAgingCategory WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CreditVariables.DivisionID
            cmd2.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CreditVariables.CustomerID
            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds2, "ARAgingCategory")

            cmd5 = New SqlCommand("SELECT InvoiceDate, CustomerID, DivisionID FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CreditVariables.DivisionID
            cmd5.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CreditVariables.CustomerID
            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds2, "InvoiceHeaderTable")

        Catch ex As System.Exception
        End Try
        GlobalVariables.Counter = lblAVGDaysToPay.Text
        con.Close()
        GDS3 = ds2
        Dim NewPrintCustomerCredit As New PrintCustomerCredit
        NewPrintCustomerCredit.Show()
    End Sub

    Private Sub cboPaymentTerms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentTerms.SelectedIndexChanged
        ValidatePaymentTermsChange()
    End Sub

    'Key press events

    Private Sub cboAddState_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAddState.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboBillingType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBillingType.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboBTState_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBTState.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboContactDepartment_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboContactDepartment.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboCustomerClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCustomerClass.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboCustomerID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCustomerID.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboCustomerName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCustomerName.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboPaymentTerms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPaymentTerms.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboSalesTerritory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSalesTerritory.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboShipper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboShipper.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboShipToID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboShipToID.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboSTState_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSTState.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub
End Class