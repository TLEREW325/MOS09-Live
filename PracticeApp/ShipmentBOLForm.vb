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
Public Class ShipmentBOLForm
    Inherits System.Windows.Forms.Form

    Dim ShipToName, CustomerName, ShipZip, ShipState, ShipCity, ShipCountry, ShipAddress1, ShipAddress2, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToZip, ShipToCountry, ShipToState As String
    Dim BoxTotal, SUMTotalWeight As Double
    Dim NumberOfPalletsOnFloor, NumberOfDoublePallets, NumberOfPallets, NumberOfShipments, SUMDoubleStackTotal, SUMPalletOnFloorTotal, SUMPalletTotal, SUMBoxTotal, SUMShipmentNumber, LastBOLNumber, NextBOLNumber, PalletTotal As Integer
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

    'Setup for barcode
    Dim bc As New BarcodeLabel
    Dim LabelFormat(70), V00, V01, V02, V03, V04, V05, V06, V07, V08, V09, V10, V11, V12, V13, V14, V15, V16, V17, V18, V19, V20, V21, V22, V23, V24, V25, V26, V27, V28, VDATA, VDATA1, VBAR, VBAR1 As String
    Dim LabelLines, BarCodeType, NumberOfLabels As Integer

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

    Private Sub ShipmentBOLForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)

        LoadCurrentDivision()

        If GlobalBOLNumber = 0 Then
            'Do nothing
        Else
            cboBOLNumber.Text = GlobalBOLNumber
        End If
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
                If txtThirdPartyShipper.Text = "" Then
                    MsgBox("You must fill-in third party shipping info", MsgBoxStyle.OkOnly)
                    CheckShippingMethod = "EXIT SUB"
                    txtThirdPartyShipper.Focus()
                    Exit Sub
                Else
                    CheckShippingMethod = ""
                End If
            Case "OTHER"
                CheckShippingMethod = ""
            Case Else
                MsgBox("You must select a valid Shipping Method", MsgBoxStyle.OkOnly)
                CheckShippingMethod = "EXIT SUB"
                cboShipMethod.Focus()
                Exit Sub
        End Select
    End Sub

    Public Sub GetThirdPartyBillingData()
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

        txtThirdPartyShipper.Text = BillToName + Environment.NewLine + BillToAddress1 + Environment.NewLine + BillToAddress2 + Environment.NewLine + BillToCity + ", " + BillToState + "  " + BillToZip
    End Sub

    Public Sub LoadDateFilter()
        Dim DayOfDate, MonthOfDate, YearOfDate As Integer
        Dim BeginDayOfDate, BeginMonthOfDate, BeginYearOfDate As Integer
        Dim strDayOfDate, strMonthOfDate, strYearOfDate As String

        ShipDate = Today()

        DayOfDate = ShipDate.Day
        MonthOfDate = ShipDate.Month
        YearOfDate = ShipDate.Year

        If DayOfDate > 5 Then
            BeginDayOfDate = DayOfDate - 5
            BeginMonthOfDate = MonthOfDate
            BeginYearOfDate = YearOfDate
        ElseIf DayOfDate <= 5 Then
            If MonthOfDate = 1 Then
                BeginMonthOfDate = 12
                BeginYearOfDate = YearOfDate - 1
                BeginDayOfDate = 31 - (5 - DayOfDate)
            ElseIf MonthOfDate = 3 Then
                BeginMonthOfDate = MonthOfDate - 1
                BeginYearOfDate = YearOfDate
                BeginDayOfDate = 28 - (5 - DayOfDate)
            Else
                BeginMonthOfDate = MonthOfDate - 1
                BeginYearOfDate = YearOfDate
                BeginDayOfDate = 30 - (5 - DayOfDate)
            End If
        End If

        strDayOfDate = CStr(BeginDayOfDate)
        strMonthOfDate = CStr(BeginMonthOfDate)
        strYearOfDate = CStr(BeginYearOfDate)

        BeginDate = strMonthOfDate + "/" + strDayOfDate + "/" + strYearOfDate
        EndDate = Today()
    End Sub

    Public Sub LoadDateFilter10()
        Dim DayOfDate, MonthOfDate, YearOfDate As Integer
        Dim BeginDayOfDate, BeginMonthOfDate, BeginYearOfDate As Integer
        Dim strDayOfDate, strMonthOfDate, strYearOfDate As String

        ShipDate = Today()

        DayOfDate = ShipDate.Day
        MonthOfDate = ShipDate.Month
        YearOfDate = ShipDate.Year

        If DayOfDate > 10 Then
            BeginDayOfDate = DayOfDate - 10
            BeginMonthOfDate = MonthOfDate
            BeginYearOfDate = YearOfDate
        ElseIf DayOfDate <= 10 Then
            If MonthOfDate = 1 Then
                BeginMonthOfDate = 12
                BeginYearOfDate = YearOfDate - 1
                BeginDayOfDate = 31 - (10 - DayOfDate)
            ElseIf MonthOfDate = 3 Then
                BeginMonthOfDate = MonthOfDate - 1
                BeginYearOfDate = YearOfDate
                BeginDayOfDate = 28 - (10 - DayOfDate)
            Else
                BeginMonthOfDate = MonthOfDate - 1
                BeginYearOfDate = YearOfDate
                BeginDayOfDate = 30 - (10 - DayOfDate)
            End If
        End If

        strDayOfDate = CStr(BeginDayOfDate)
        strMonthOfDate = CStr(BeginMonthOfDate)
        strYearOfDate = CStr(BeginYearOfDate)

        BeginDate = strMonthOfDate + "/" + strDayOfDate + "/" + strYearOfDate
        EndDate = Today()
    End Sub

    Public Sub LoadDateFilter20()
        Dim DayOfDate, MonthOfDate, YearOfDate As Integer
        Dim BeginDayOfDate, BeginMonthOfDate, BeginYearOfDate As Integer
        Dim strDayOfDate, strMonthOfDate, strYearOfDate As String

        ShipDate = Today()

        DayOfDate = ShipDate.Day
        MonthOfDate = ShipDate.Month
        YearOfDate = ShipDate.Year

        If DayOfDate > 20 Then
            BeginDayOfDate = DayOfDate - 20
            BeginMonthOfDate = MonthOfDate
            BeginYearOfDate = YearOfDate
        ElseIf DayOfDate <= 20 Then
            If MonthOfDate = 1 Then
                BeginMonthOfDate = 12
                BeginYearOfDate = YearOfDate - 1
                BeginDayOfDate = 31 - (20 - DayOfDate)
            ElseIf MonthOfDate = 3 Then
                BeginMonthOfDate = MonthOfDate - 1
                BeginYearOfDate = YearOfDate
                BeginDayOfDate = 28 - (20 - DayOfDate)
            Else
                BeginMonthOfDate = MonthOfDate - 1
                BeginYearOfDate = YearOfDate
                BeginDayOfDate = 30 - (20 - DayOfDate)
            End If
        End If

        strDayOfDate = CStr(BeginDayOfDate)
        strMonthOfDate = CStr(BeginMonthOfDate)
        strYearOfDate = CStr(BeginYearOfDate)

        BeginDate = strMonthOfDate + "/" + strDayOfDate + "/" + strYearOfDate
        EndDate = Today()
    End Sub

    Public Sub LoadDateFilter30()
        Dim DayOfDate, MonthOfDate, YearOfDate As Integer
        Dim BeginDayOfDate, BeginMonthOfDate, BeginYearOfDate As Integer
        Dim strDayOfDate, strMonthOfDate, strYearOfDate As String

        ShipDate = Today()

        DayOfDate = ShipDate.Day
        MonthOfDate = ShipDate.Month
        YearOfDate = ShipDate.Year

        If DayOfDate > 30 Then
            BeginDayOfDate = DayOfDate - 30
            BeginMonthOfDate = MonthOfDate
            BeginYearOfDate = YearOfDate
        ElseIf DayOfDate <= 30 Then
            If MonthOfDate = 1 Then
                BeginMonthOfDate = 12
                BeginYearOfDate = YearOfDate - 1
                BeginDayOfDate = 31 - (30 - DayOfDate)
            ElseIf MonthOfDate = 3 Then
                BeginMonthOfDate = MonthOfDate - 1
                BeginYearOfDate = YearOfDate
                BeginDayOfDate = 28 - (30 - DayOfDate)
            Else
                BeginMonthOfDate = MonthOfDate - 1
                BeginYearOfDate = YearOfDate
                BeginDayOfDate = 30 - (30 - DayOfDate)
            End If
        End If

        strDayOfDate = CStr(BeginDayOfDate)
        strMonthOfDate = CStr(BeginMonthOfDate)
        strYearOfDate = CStr(BeginYearOfDate)

        BeginDate = strMonthOfDate + "/" + strDayOfDate + "/" + strYearOfDate
        EndDate = Today()
    End Sub

    Public Sub ShowShipments()
        LoadDateFilter()

        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipDate BETWEEN @BeginDate AND @EndDate AND ShipmentStatus <> @ShipmentStatus ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")
        dgvShipmentHeaders.DataSource = ds.Tables("ShipmentHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowShipments10()
        LoadDateFilter10()

        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipDate BETWEEN @BeginDate AND @EndDate AND ShipmentStatus <> @ShipmentStatus ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")
        dgvShipmentHeaders.DataSource = ds.Tables("ShipmentHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowShipments20()
        LoadDateFilter20()

        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipDate BETWEEN @BeginDate AND @EndDate AND ShipmentStatus <> @ShipmentStatus ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")
        dgvShipmentHeaders.DataSource = ds.Tables("ShipmentHeaderTable")
        con.Close()
    End Sub

    Public Sub ShowShipments30()
        LoadDateFilter30()

        cmd = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND ShipDate BETWEEN @BeginDate AND @EndDate AND ShipmentStatus <> @ShipmentStatus ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        cmd.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "PENDING"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")
        dgvShipmentHeaders.DataSource = ds.Tables("ShipmentHeaderTable")
        con.Close()
    End Sub

    Private Sub SelectLast10DaysToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectLast10DaysToolStripMenuItem.Click
        If cboCustomerID.Text <> "" Then
            ShowShipments10()
        End If
    End Sub

    Private Sub SelectLast20DaysToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectLast20DaysToolStripMenuItem.Click
        If cboCustomerID.Text <> "" Then
            ShowShipments20()
        End If
    End Sub

    Private Sub SelectLast30DaysToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectLast30DaysToolStripMenuItem.Click
        If cboCustomerID.Text <> "" Then
            ShowShipments30()
        End If
    End Sub

    Public Sub ClearShipments()
        dgvShipmentHeaders.DataSource = Nothing
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

    Public Sub LoadAdditionalShipTo()
        cmd = New SqlCommand("SELECT ShipToID FROM AdditionalShipTo WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "AdditionalShipTo")
        cboShipToID.DataSource = ds2.Tables("AdditionalShipTo")
        con.Close()
        cboShipToID.SelectedIndex = -1
    End Sub

    Public Sub ShowShipmentsOnBOL()
        cmd = New SqlCommand("SELECT * FROM ShipmentBOLLineTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber", con)
        cmd.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ShipmentBOLLineTable")
        dgvShipmentLineBOL.DataSource = ds3.Tables("ShipmentBOLLineTable")
        con.Close()
    End Sub

    Public Sub ClearShipmentsOnBOL()
        dgvShipmentLineBOL.DataSource = Nothing
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboCustomerName.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadBOLNumber()
        cmd = New SqlCommand("SELECT ShipmentBOLNumber FROM ShipmentBOLTable WHERE DivisionID = @DivisionID ORDER BY ShipmentBOLNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ShipmentBOLTable")
        cboBOLNumber.DataSource = ds5.Tables("ShipmentBOLTable")
        con.Close()
        cboBOLNumber.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboShipToID.Text = ""
        cboShipVia.Text = ""
        cboState.Text = ""
        cboShipMethod.Text = ""
        cboBOLNumber.Text = ""
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""

        cboBOLNumber.SelectedIndex = -1
        cboShipToID.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboState.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1

        txtActualWeight.Clear()
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtCity.Clear()
        txtCountry.Clear()
        txtCustomerName.Clear()
        txtEstimatedWeight.Clear()
        txtFreightQuoteNumber.Clear()
        txtNumberOfShipments.Clear()
        txtSpecialInstructions.Clear()
        txtTotalBoxes.Clear()
        txtTotalPallets.Clear()
        txtNumberOfPalletsOnFloor.Clear()
        txtNumberOfDoublePallets.Clear()
        txtZip.Clear()
        txtThirdPartyShipper.Clear()

        dtpShipDate.Text = ""
        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        ShipToName = ""
        CustomerName = ""
        ShipZip = ""
        ShipState = ""
        ShipCity = ""
        ShipCountry = ""
        ShipAddress1 = ""
        ShipAddress2 = ""
        BoxTotal = 0
        SUMTotalWeight = 0
        NumberOfShipments = 0
        CheckShippingMethod = ""
        CheckThirdPartyShipper = ""
        CheckShipmentAddress = ""
        ShipMethod = ""
        SUMPalletTotal = 0
        SUMBoxTotal = 0
        SUMDoubleStackTotal = 0
        SUMPalletOnFloorTotal = 0
        LastBOLNumber = 0
        NextBOLNumber = 0
        PalletTotal = 0
        GlobalShipmentNumber = 0
        GlobalBOLNumber = 0
    End Sub

    Public Sub LoadCustomerData()
        Dim ShipAddress1Statement As String = "SELECT ShipToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipAddress1Command As New SqlCommand(ShipAddress1Statement, con)
        ShipAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipAddress2Statement As String = "SELECT ShipToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipAddress2Command As New SqlCommand(ShipAddress2Statement, con)
        ShipAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipCityStatement As String = "SELECT ShipToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipCityCommand As New SqlCommand(ShipCityStatement, con)
        ShipCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipStateStatement As String = "SELECT ShipToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipStateCommand As New SqlCommand(ShipStateStatement, con)
        ShipStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipZipStatement As String = "SELECT ShipToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipZipCommand As New SqlCommand(ShipZipStatement, con)
        ShipZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipCountryStatement As String = "SELECT ShipToCountry FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipCountryCommand As New SqlCommand(ShipCountryStatement, con)
        ShipCountryCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ShipNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim ShipNameCommand As New SqlCommand(ShipNameStatement, con)
        ShipNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        ShipNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ShipAddress1 = CStr(ShipAddress1Command.ExecuteScalar)
        Catch ex As Exception
            ShipAddress1 = ""
        End Try
        Try
            ShipAddress2 = CStr(ShipAddress2Command.ExecuteScalar)
        Catch ex As Exception
            ShipAddress2 = ""
        End Try
        Try
            ShipCity = CStr(ShipCityCommand.ExecuteScalar)
        Catch ex As Exception
            ShipCity = ""
        End Try
        Try
            ShipState = CStr(ShipStateCommand.ExecuteScalar)
        Catch ex As Exception
            ShipState = ""
        End Try
        Try
            ShipZip = CStr(ShipZipCommand.ExecuteScalar)
        Catch ex As Exception
            ShipZip = ""
        End Try
        Try
            ShipCountry = CStr(ShipCountryCommand.ExecuteScalar)
        Catch ex As Exception
            ShipCountry = ""
        End Try
        Try
            CustomerName = CStr(ShipNameCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerName = ""
        End Try
        con.Close()

        txtAddress1.Text = ShipAddress1
        txtAddress2.Text = ShipAddress2
        txtCity.Text = ShipCity
        txtCountry.Text = ShipCountry
        txtZip.Text = ShipZip
        cboState.Text = ShipState
        txtCustomerName.Text = CustomerName
    End Sub

    Public Sub LoadBOLTotals()
        Dim GetDoubleStackedPallets, GetTotalPalletsOnFloor, GetPalletTotal, GetTotalWeight, GetBoxTotal, GetNumberOfShipments As Integer

        Dim PalletTotalStatement As String = "SELECT TotalPallets FROM ShipmentBOLTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID"
        Dim PalletTotalCommand As New SqlCommand(PalletTotalStatement, con)
        PalletTotalCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        PalletTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim DoubleStackedPalletsStatement As String = "SELECT TotalDoubleStackedPallets FROM ShipmentBOLTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID"
        Dim DoubleStackedPalletsCommand As New SqlCommand(DoubleStackedPalletsStatement, con)
        DoubleStackedPalletsCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        DoubleStackedPalletsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PalletsOnFloorStatement As String = "SELECT TotalPalletsOnFloor FROM ShipmentBOLTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID"
        Dim PalletsOnFloorCommand As New SqlCommand(PalletsOnFloorStatement, con)
        PalletsOnFloorCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        PalletsOnFloorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalWeightStatement As String = "SELECT ActualWeight FROM ShipmentBOLTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID"
        Dim TotalWeightCommand As New SqlCommand(TotalWeightStatement, con)
        TotalWeightCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        TotalWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BoxTotalStatement As String = "SELECT TotalBoxes FROM ShipmentBOLTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID"
        Dim BoxTotalCommand As New SqlCommand(BoxTotalStatement, con)
        BoxTotalCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        BoxTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim NumberOfShipmentsStatement As String = "SELECT COUNT(ShipmentBOLNumber) FROM ShipmentBOLLineTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID"
        Dim NumberOfShipmentsCommand As New SqlCommand(NumberOfShipmentsStatement, con)
        NumberOfShipmentsCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        NumberOfShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetPalletTotal = CInt(PalletTotalCommand.ExecuteScalar)
        Catch ex As Exception
            GetPalletTotal = 0
        End Try
        Try
            GetDoubleStackedPallets = CInt(DoubleStackedPalletsCommand.ExecuteScalar)
        Catch ex As Exception
            GetDoubleStackedPallets = 0
        End Try
        Try
            GetTotalPalletsOnFloor = CInt(PalletsOnFloorCommand.ExecuteScalar)
        Catch ex As Exception
            GetTotalPalletsOnFloor = 0
        End Try
        Try
            GetTotalWeight = CInt(TotalWeightCommand.ExecuteScalar)
        Catch ex As Exception
            GetTotalWeight = 0
        End Try
        Try
            GetBoxTotal = CInt(BoxTotalCommand.ExecuteScalar)
        Catch ex As Exception
            GetBoxTotal = 0
        End Try
        Try
            GetNumberOfShipments = CInt(NumberOfShipmentsCommand.ExecuteScalar)
        Catch ex As Exception
            GetNumberOfShipments = 0
        End Try
        con.Close()

        txtActualWeight.Text = GetTotalWeight
        txtTotalBoxes.Text = GetBoxTotal
        txtTotalPallets.Text = GetPalletTotal
        txtNumberOfDoublePallets.Text = GetDoubleStackedPallets
        txtNumberOfPalletsOnFloor.Text = GetTotalPalletsOnFloor
        txtEstimatedWeight.Text = GetTotalWeight
        txtNumberOfShipments.Text = GetNumberOfShipments
    End Sub

    Public Sub CalculateBOLTotals()
        Dim PalletTotalStatement As String = "SELECT SUM(NumberOfPallets) FROM ShipmentBOLLineTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID"
        Dim PalletTotalCommand As New SqlCommand(PalletTotalStatement, con)
        PalletTotalCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        PalletTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim DoubleStackedPalletsStatement As String = "SELECT SUM(NumberOfDoubleStackedPallets) FROM ShipmentBOLLineTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID"
        Dim DoubleStackedPalletsCommand As New SqlCommand(DoubleStackedPalletsStatement, con)
        DoubleStackedPalletsCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        DoubleStackedPalletsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalPalletsOnFloorStatement As String = "SELECT SUM(NumberOfPalletsOnFloor) FROM ShipmentBOLLineTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID"
        Dim TotalPalletsOnFloorCommand As New SqlCommand(TotalPalletsOnFloorStatement, con)
        TotalPalletsOnFloorCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        TotalPalletsOnFloorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TotalWeightStatement As String = "SELECT SUM(TotalWeight) FROM ShipmentBOLLineTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID"
        Dim TotalWeightCommand As New SqlCommand(TotalWeightStatement, con)
        TotalWeightCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        TotalWeightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BoxTotalStatement As String = "SELECT SUM(NumberOfBoxes) FROM ShipmentBOLLineTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID"
        Dim BoxTotalCommand As New SqlCommand(BoxTotalStatement, con)
        BoxTotalCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        BoxTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SUMPalletTotal = CInt(PalletTotalCommand.ExecuteScalar)
        Catch ex As Exception
            SUMPalletTotal = 0
        End Try
        Try
            SUMDoubleStackTotal = CInt(DoubleStackedPalletsCommand.ExecuteScalar)
        Catch ex As Exception
            SUMDoubleStackTotal = 0
        End Try
        Try
            SUMPalletOnFloorTotal = CInt(TotalPalletsOnFloorCommand.ExecuteScalar)
        Catch ex As Exception
            SUMPalletOnFloorTotal = 0
        End Try
        Try
            SUMTotalWeight = CDbl(TotalWeightCommand.ExecuteScalar)
        Catch ex As Exception
            SUMTotalWeight = 0
        End Try
        Try
            SUMBoxTotal = CInt(BoxTotalCommand.ExecuteScalar)
        Catch ex As Exception
            SUMBoxTotal = 0
        End Try
        con.Close()

        txtTotalBoxes.Text = SUMBoxTotal
        txtTotalPallets.Text = SUMPalletTotal
        txtNumberOfDoublePallets.Text = SUMDoubleStackTotal
        txtNumberOfPalletsOnFloor.Text = SUMPalletOnFloorTotal
        txtEstimatedWeight.Text = SUMTotalWeight
        txtActualWeight.Text = SUMTotalWeight
    End Sub

    Public Sub LoadBOLData()
        Dim BOLShipDate As String = ""
        Dim BOLCustomerID As String = ""
        Dim BOLShipToID As String = ""
        Dim BOLAddress1 As String = ""
        Dim BOLAddress2 As String = ""
        Dim BOLCity As String = ""
        Dim BOLState As String = ""
        Dim BOLZip As String = ""
        Dim BOLCountry As String = ""
        Dim BOLShipVia As String = ""
        Dim BOLShipMethod As String = ""
        Dim BOLFreightQuoteNumber As String = ""
        Dim BOLSpecialInstructions As String = ""
        Dim BOLShipToName As String = ""
        Dim BOLThirdPartyShipper As String = ""

        Dim LoadBOLDataString As String = "SELECT * FROM ShipmentBOLTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID"
        Dim LoadBOLDataCommand As New SqlCommand(LoadBOLDataString, con)
        LoadBOLDataCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
        LoadBOLDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LoadBOLDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ShipDate")) Then
                BOLShipDate = ""
            Else
                BOLShipDate = reader.Item("ShipDate")
            End If
            If IsDBNull(reader.Item("CustomerID")) Then
                BOLCustomerID = ""
            Else
                BOLCustomerID = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("ShipToID")) Then
                BOLShipToID = ""
            Else
                BOLShipToID = reader.Item("ShipToID")
            End If
            If IsDBNull(reader.Item("Address1")) Then
                BOLAddress1 = ""
            Else
                BOLAddress1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                BOLAddress2 = ""
            Else
                BOLAddress2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                BOLCity = ""
            Else
                BOLCity = reader.Item("City")
            End If
            If IsDBNull(reader.Item("State")) Then
                BOLState = ""
            Else
                BOLState = reader.Item("State")
            End If
            If IsDBNull(reader.Item("Zip")) Then
                BOLZip = ""
            Else
                BOLZip = reader.Item("Zip")
            End If
            If IsDBNull(reader.Item("Country")) Then
                BOLCountry = ""
            Else
                BOLCountry = reader.Item("Country")
            End If
            If IsDBNull(reader.Item("ShipVia")) Then
                BOLShipVia = ""
            Else
                BOLShipVia = reader.Item("ShipVia")
            End If
            If IsDBNull(reader.Item("ShippingMethod")) Then
                BOLShipMethod = ""
            Else
                BOLShipMethod = reader.Item("ShippingMethod")
            End If
            If IsDBNull(reader.Item("FreightQuoteNumber")) Then
                BOLFreightQuoteNumber = ""
            Else
                BOLFreightQuoteNumber = reader.Item("FreightQuoteNumber")
            End If
            If IsDBNull(reader.Item("SpecialInstructions")) Then
                BOLSpecialInstructions = ""
            Else
                BOLSpecialInstructions = reader.Item("SpecialInstructions")
            End If
            If IsDBNull(reader.Item("ShipToName")) Then
                BOLShipToName = ""
            Else
                BOLShipToName = reader.Item("ShipToName")
            End If
            If IsDBNull(reader.Item("ThirdPartyShipper")) Then
                BOLThirdPartyShipper = ""
            Else
                BOLThirdPartyShipper = reader.Item("ThirdPartyShipper")
            End If
        Else
            BOLShipDate = ""
            BOLCustomerID = ""
            BOLShipToID = ""
            BOLAddress1 = ""
            BOLAddress2 = ""
            BOLCity = ""
            BOLState = ""
            BOLZip = ""
            BOLCountry = ""
            BOLShipVia = ""
            BOLShipMethod = ""
            BOLFreightQuoteNumber = ""
            BOLSpecialInstructions = ""
            BOLShipToName = ""
            BOLThirdPartyShipper = ""
        End If
        reader.Close()
        con.Close()

        dtpShipDate.Text = BOLShipDate

        cboCustomerID.Text = BOLCustomerID
        cboShipToID.Text = BOLShipToID
        cboShipVia.Text = BOLShipVia
        cboShipMethod.Text = BOLShipMethod
        cboState.Text = BOLState

        txtAddress1.Text = BOLAddress1
        txtAddress2.Text = BOLAddress2
        txtCity.Text = BOLCity
        txtCountry.Text = BOLCountry
        txtZip.Text = BOLZip
        txtCustomerName.Text = BOLShipToName
        txtFreightQuoteNumber.Text = BOLFreightQuoteNumber
        txtSpecialInstructions.Text = BOLSpecialInstructions
        txtThirdPartyShipper.Text = BOLThirdPartyShipper
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

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
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomerID()
        LoadCustomerName()
        LoadAdditionalShipTo()
        LoadBOLNumber()
        ClearData()
        ClearShipments()
        ClearShipmentsOnBOL()
    End Sub

    Private Sub cboShipToID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipToID.SelectedIndexChanged
        If cboShipToID.Text = "" Then
            'skip
        Else
            Dim AddNameStatement As String = "SELECT Name FROM AdditionalShipTo WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim AddNameCommand As New SqlCommand(AddNameStatement, con)
            AddNameCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            AddNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            AddNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim AddAddress1Statement As String = "SELECT Address1 FROM AdditionalShipTo WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim AddAddress1Command As New SqlCommand(AddAddress1Statement, con)
            AddAddress1Command.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            AddAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            AddAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim AddAddress2Statement As String = "SELECT Address2 FROM AdditionalShipTo WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim AddAddress2Command As New SqlCommand(AddAddress2Statement, con)
            AddAddress2Command.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            AddAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            AddAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim AddCityStatement As String = "SELECT City FROM AdditionalShipTo WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim AddCityCommand As New SqlCommand(AddCityStatement, con)
            AddCityCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            AddCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            AddCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim AddStateStatement As String = "SELECT State FROM AdditionalShipTo WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim AddStateCommand As New SqlCommand(AddStateStatement, con)
            AddStateCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            AddStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            AddStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim AddZipStatement As String = "SELECT Zip FROM AdditionalShipTo WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim AddZipCommand As New SqlCommand(AddZipStatement, con)
            AddZipCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            AddZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            AddZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim AddCountryStatement As String = "SELECT Country FROM AdditionalShipTo WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim AddCountryCommand As New SqlCommand(AddCountryStatement, con)
            AddCountryCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            AddCountryCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            AddCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ShipToName = CStr(AddNameCommand.ExecuteScalar)
            Catch ex As Exception
                ShipToName = ""
            End Try
            Try
                ShipToAddress1 = CStr(AddAddress1Command.ExecuteScalar)
            Catch ex As Exception
                ShipToAddress1 = ""
            End Try
            Try
                ShipToAddress2 = CStr(AddAddress2Command.ExecuteScalar)
            Catch ex As Exception
                ShipToAddress2 = ""
            End Try
            Try
                ShipToCity = CStr(AddCityCommand.ExecuteScalar)
            Catch ex As Exception
                ShipToCity = ""
            End Try
            Try
                ShipToState = CStr(AddStateCommand.ExecuteScalar)
            Catch ex As Exception
                ShipToState = ""
            End Try
            Try
                ShipToZip = CStr(AddZipCommand.ExecuteScalar)
            Catch ex As Exception
                ShipToZip = ""
            End Try
            Try
                ShipToCountry = CStr(AddCountryCommand.ExecuteScalar)
            Catch ex As Exception
                ShipToCountry = ""
            End Try
            con.Close()

            If cboShipToID.Text = "" Then
                txtCustomerName.Text = ShipToName
                txtAddress1.Text = ShipAddress1
                txtAddress2.Text = ShipAddress2
                txtCity.Text = ShipCity
                txtCountry.Text = ShipCountry
                cboState.Text = ShipState
                txtZip.Text = ShipZip
            Else
                txtCustomerName.Text = ShipToName
                txtAddress1.Text = ShipToAddress1
                txtAddress2.Text = ShipToAddress2
                txtCity.Text = ShipToCity
                txtCountry.Text = ShipToCountry
                cboState.Text = ShipToState
                txtZip.Text = ShipToZip
            End If
        End If
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        cboShipToID.SelectedIndex = -1
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtCountry.Clear()
        txtCity.Clear()
        txtCustomerName.Clear()
        cboState.SelectedIndex = -1

        ShowShipments()
        LoadCustomerNameByID()
        LoadAdditionalShipTo()
        LoadCustomerData()

        txtThirdPartyShipper.Clear()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cmdAddLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLines.Click
        'Check to see if there is a ship via
        If cboShipVia.Text = "" Then
            MsgBox("You must select a shipper before creating a BOL.", MsgBoxStyle.OkOnly)
            cboShipVia.Focus()
            Exit Sub
        End If
        '*******************************************
        'Validate shipping
        ValidateShippingMethod()
        If CheckShippingMethod = "EXIT SUB" Then
            Exit Sub
        End If
        '********************************************
        If cboBOLNumber.Text = "" Then
            MsgBox("You must have a valid BOL Number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*************************************************************************************************************************
        'Check all shipments selected and see if any of the ship to addresses are different
        'If they are all the same, load shipping address into text boxes
        For Each row As DataGridViewRow In dgvShipmentHeaders.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectShipments")
            Dim ShipAddress1 As String = ""
            Dim ShipAddress2 As String = ""
            Dim ShipCity As String = ""
            Dim ShipState As String = ""
            Dim ShipZip As String = ""
            Dim ShipToID As String = ""
            Dim ShipToName As String = ""
            Dim ShipToCountry As String = ""
            Dim ThirdPartyShipper As String = ""

            If cell.Value = "SELECTED" Then
                Dim ShipmentNumber As Integer = row.Cells("ShipmentNumberColumn").Value

                ShipAddress1 = row.Cells("ShipAddress1Column").Value
                ShipAddress2 = row.Cells("ShipAddress2Column").Value
                ShipCity = row.Cells("ShipCityColumn").Value
                ShipState = row.Cells("ShipStateColumn").Value
                ShipZip = row.Cells("ShipZipColumn").Value
                ShipToID = row.Cells("ShipToIDColumn").Value
                ShipToName = row.Cells("ShipToNameColumn").Value
                ShipToCountry = row.Cells("ShipCountryColumn").Value
                ThirdPartyShipper = row.Cells("ThirdPartyShipperColumn").Value

                cboShipToID.Text = ShipToID
                txtAddress1.Text = ShipAddress1
                txtAddress2.Text = ShipAddress2
                txtCity.Text = ShipCity
                txtCountry.Text = ShipCountry
                txtZip.Text = ShipZip
                txtCustomerName.Text = ShipToName
                cboState.Text = ShipState
                txtThirdPartyShipper.Text = ThirdPartyShipper

                Exit For
            End If
        Next
        '***************************************************************************************************************************
        'Retrieve line data from Shipment Table and write to Shipment BOL Table
        For Each row As DataGridViewRow In dgvShipmentHeaders.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectShipments")
            Dim ShipAddress1 As String = ""
            Dim ShipCity As String = ""
            Dim ShipState As String = ""
            Dim ShipZip As String = ""
            Dim ThirdPartyShipper As String = ""

            If cell.Value = "SELECTED" Then
                Dim ShipmentNumber As Integer = row.Cells("ShipmentNumberColumn").Value
                Dim FreightQuoteNumber As String = row.Cells("FreightQuoteNumberColumn").Value
                Dim ShippingWeight As Double = row.Cells("ShippingWeightColumn").Value
                Dim NumberOfPallets As Integer = row.Cells("NumberOfPalletsColumn").Value
                Dim NumberOfDoublePallets As Integer = row.Cells("DoubleStackedPalletsColumn").Value
                Dim NumberOfPalletsOnFloor As Integer = row.Cells("PalletsOnFloorColumn").Value

                txtFreightQuoteNumber.Text = FreightQuoteNumber

                ShipAddress1 = row.Cells("ShipAddress1Column").Value
                ShipCity = row.Cells("ShipCityColumn").Value
                ShipState = row.Cells("ShipStateColumn").Value
                ShipZip = row.Cells("ShipZipColumn").Value
                ThirdPartyShipper = row.Cells("ThirdPartyShipperColumn").Value

                'Check Shipment Addresses against current address
                If ShipAddress1 = txtAddress1.Text Then
                    'Skip
                Else
                    CheckShipmentAddress = "DOES NOT MATCH"
                End If
                If ShipCity = txtCity.Text Then
                    'Skip
                Else
                    CheckShipmentAddress = "DOES NOT MATCH"
                End If
                If ShipState = cboState.Text Then
                    'Skip
                Else
                    CheckShipmentAddress = "DOES NOT MATCH"
                End If
                If ShipZip = txtZip.Text Then
                    'Skip
                Else
                    CheckShipmentAddress = "DOES NOT MATCH"
                End If
                If ThirdPartyShipper = txtThirdPartyShipper.Text Then
                    'Skip
                Else
                    CheckThirdPartyShipper = "DOES NOT MATCH"
                End If
                '************************************************************************************************
                'Get Number of Boxes for shipment by summing shipment lines
                Dim BoxTotalStatement As String = "SELECT SUM(LineBoxes) FROM ShipmentLineTable WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
                Dim BoxTotalCommand As New SqlCommand(BoxTotalStatement, con)
                BoxTotalCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                BoxTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    BoxTotal = CDbl(BoxTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    BoxTotal = 0
                End Try
                con.Close()

                BoxTotal = Math.Round(BoxTotal, 0)

                'Create or Update Shipment BOL Header Table entry
                Try
                    cmd = New SqlCommand("UPDATE ShipmentBOLTable SET DivisionID = @DivisionID, CustomerID = @CustomerID, ShipToID = @ShipToID, Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country, TotalBoxes = @TotalBoxes, TotalPallets = @TotalPallets, ActualWeight = @ActualWeight, ShipVia = @ShipVia, FreightQuoteNumber = @FreightQuoteNumber, SpecialInstructions = @SpecialInstructions, ShipDate = @ShipDate, ShipToName = @ShipToName, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentBOLNumber = @ShipmentBOLNumber", con)

                    With cmd.Parameters
                        .Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                        .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
                        .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
                        .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
                        .Add("@State", SqlDbType.VarChar).Value = cboState.Text
                        .Add("@Zip", SqlDbType.VarChar).Value = txtZip.Text
                        .Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text
                        .Add("@TotalBoxes", SqlDbType.VarChar).Value = Val(txtTotalBoxes.Text)
                        .Add("@TotalPallets", SqlDbType.VarChar).Value = Val(txtTotalPallets.Text)
                        .Add("@ActualWeight", SqlDbType.VarChar).Value = Val(txtActualWeight.Text)
                        .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                        .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
                        .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                        .Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                        .Add("@ShipToName", SqlDbType.VarChar).Value = txtCustomerName.Text
                        .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                        .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    Dim intBOLNUmber As Integer = 0
                    Dim strBOLNumber As String = ""
                    intBOLNUmber = Val(cboBOLNumber.Text)
                    strBOLNumber = CStr(intBOLNUmber)

                    'Error Check
                    ErrorDate = Today()
                    ErrorComment = ex.ToString
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Shipment BOL Form --- Add Lines"
                    ErrorReferenceNumber = "BOL# " + strBOLNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                Try
                    'Add Lines to ShipmentBOLLineTable
                    cmd = New SqlCommand("INSERT INTO ShipmentBOLLineTable (ShipmentBOLNumber, ShipmentNumber, DivisionID, TotalWeight, NumberOfPallets, NumberOfBoxes, NumberOfDoubleStackedPallets, NumberOfPalletsOnFloor)values(@ShipmentBOLNumber, @ShipmentNumber, @DivisionID, @TotalWeight, @NumberOfPallets, @NumberOfBoxes, @NumberOfDoubleStackedPallets, @NumberOfPalletsOnFloor)", con)

                    With cmd.Parameters
                        .Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@TotalWeight", SqlDbType.VarChar).Value = ShippingWeight
                        .Add("@NumberOfPallets", SqlDbType.VarChar).Value = NumberOfPallets
                        .Add("@NumberOfBoxes", SqlDbType.VarChar).Value = BoxTotal
                        .Add("@NumberOfDoubleStackedPallets", SqlDbType.VarChar).Value = NumberOfDoublePallets
                        .Add("@NumberOfPalletsOnFloor", SqlDbType.VarChar).Value = NumberOfPalletsOnFloor
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Check
                    Dim intBOLNUmber As Integer = 0
                    Dim strBOLNumber As String = ""
                    intBOLNUmber = Val(cboBOLNumber.Text)
                    strBOLNumber = CStr(intBOLNUmber)

                    'Error Check
                    ErrorDate = Today()
                    ErrorComment = ex.ToString
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Shipment BOL Form --- Add Lines"
                    ErrorReferenceNumber = "BOL# " + strBOLNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End If
        Next

        'Get Number of Shipments on BOL
        Dim MAXShipmentsStatement As String = "SELECT COUNT(ShipmentBOLNumber) FROM ShipmentBOLLineTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber"
        Dim MAXShipmentsCommand As New SqlCommand(MAXShipmentsStatement, con)
        MAXShipmentsCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = NextBOLNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            NumberOfShipments = CInt(MAXShipmentsCommand.ExecuteScalar)
        Catch ex As Exception
            NumberOfShipments = 0
        End Try
        con.Close()

        txtNumberOfShipments.Text = NumberOfShipments

        'Update Totals
        CalculateBOLTotals()

        'Update Shipment BOL Header with line totals
        cmd = New SqlCommand("UPDATE ShipmentBOLTable SET DivisionID = @DivisionID, CustomerID = @CustomerID, ShipToID = @ShipToID, Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country, TotalBoxes = @TotalBoxes, TotalPallets = @TotalPallets, TotalDoubleStackedPallets = @TotalDoubleStackedPallets, TotalPalletsOnFloor = @TotalPalletsOnFloor, ActualWeight = @ActualWeight, ShipVia = @ShipVia, FreightQuoteNumber = @FreightQuoteNumber, SpecialInstructions = @SpecialInstructions, ShipDate = @ShipDate, ShipToName = @ShipToName, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentBOLNumber = @ShipmentBOLNumber", con)

        With cmd.Parameters
            .Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
            .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
            .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
            .Add("@State", SqlDbType.VarChar).Value = cboState.Text
            .Add("@Zip", SqlDbType.VarChar).Value = txtZip.Text
            .Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text
            .Add("@TotalBoxes", SqlDbType.VarChar).Value = Val(txtTotalBoxes.Text)
            .Add("@TotalPallets", SqlDbType.VarChar).Value = Val(txtTotalPallets.Text)
            .Add("@TotalDoubleStackedPallets", SqlDbType.VarChar).Value = Val(txtNumberOfDoublePallets.Text)
            .Add("@TotalPalletsOnFloor", SqlDbType.VarChar).Value = Val(txtNumberOfPalletsOnFloor.Text)
            .Add("@ActualWeight", SqlDbType.VarChar).Value = Val(txtActualWeight.Text)
            .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
            .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
            .Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipDate.Text
            .Add("@ShipToName", SqlDbType.VarChar).Value = txtCustomerName.Text
            .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Uncheck boxes
        For Each row As DataGridViewRow In dgvShipmentHeaders.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectShipments")
            cell.Value = "UNSELECTED"
        Next

        If CheckShipmentAddress = "DOES NOT MATCH" Then
            MsgBox("One or more shipping address fields do not match the current ship to address.", MsgBoxStyle.OkOnly)
            'Clear Fields
            cboShipToID.SelectedIndex = -1
            txtAddress1.Clear()
            txtAddress2.Clear()
            txtCountry.Clear()
            txtCity.Clear()
            cboState.SelectedIndex = -1
        End If

        If CheckThirdPartyShipper = "DOES NOT MATCH" Then
            MsgBox("Third Party Shipper does not match on all shipments.", MsgBoxStyle.OkOnly)
            txtThirdPartyShipper.Clear()
        End If

        MsgBox("Shipments have been added.", MsgBoxStyle.OkOnly)

        ShowShipmentsOnBOL()
        CheckShipmentAddress = ""
        tabShipmentControl.TabIndex = 1
    End Sub

    Private Sub cmdRemoveShipments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveShipments.Click

        For Each row As DataGridViewRow In dgvShipmentLineBOL.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectToRemove")

            If cell.Value = "SELECTED" Then
                Dim ShipmentNumber As Integer = row.Cells("BOShipmentNumberColumn").Value

                cmd = New SqlCommand("DELETE FROM ShipmentBOLLineTable WHERE ShipmentNumber = @ShipmentNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next

        'Load Totals
        LoadBOLTotals()

        'Update Totals
        cmd = New SqlCommand("UPDATE ShipmentBOLTable SET DivisionID = @DivisionID, TotalBoxes = @TotalBoxes, TotalPallets = @TotalPallets, ActualWeight = @ActualWeight, TotalDoubleStackedPallets = @TotalDoubleStackedPallets, TotalPalletsOnFloor = @TotalPalletsOnFloor WHERE ShipmentBOLNumber = @ShipmentBOLNumber", con)

        With cmd.Parameters
            .Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = NextBOLNumber
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@TotalBoxes", SqlDbType.VarChar).Value = Val(txtTotalBoxes.Text)
            .Add("@TotalPallets", SqlDbType.VarChar).Value = Val(txtTotalPallets.Text)
            .Add("@ActualWeight", SqlDbType.VarChar).Value = Val(txtActualWeight.Text)
            .Add("@TotalDoubleStackedPallets", SqlDbType.VarChar).Value = Val(txtNumberOfDoublePallets.Text)
            .Add("@TotalPalletsOnFloor", SqlDbType.VarChar).Value = Val(txtNumberOfPalletsOnFloor.Text)
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Get Number of Shipments on BOL
        Dim MAXShipmentsStatement As String = "SELECT COUNT(ShipmentBOLNumber) FROM ShipmentBOLLineTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber"
        Dim MAXShipmentsCommand As New SqlCommand(MAXShipmentsStatement, con)
        MAXShipmentsCommand.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = NextBOLNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            NumberOfShipments = CInt(MAXShipmentsCommand.ExecuteScalar)
        Catch ex As Exception
            NumberOfShipments = 0
        End Try
        con.Close()

        txtNumberOfShipments.Text = NumberOfShipments

        'Uncheck boxes
        For Each row As DataGridViewRow In dgvShipmentLineBOL.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectToRemove")
            cell.Value = "UNSELECTED"
        Next

        ShowShipmentsOnBOL()

        MsgBox("Shipments have been removed.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Validate shipping
        ValidateShippingMethod()

        If CheckShippingMethod = "EXIT SUB" Then
            Exit Sub
        End If

        If txtAddress1.Text = "" And txtAddress2.Text = "" Then
            MsgBox("Address 1 and Address 2 fields are blank - shipping address requires one.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboBOLNumber.Text = "" Or Val(cboBOLNumber.Text) = 0 Then
            MsgBox("You must have a valid BOL Number.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Create or Update Shipment BOL Header Table entry
            Try
                cmd = New SqlCommand("UPDATE ShipmentBOLTable SET DivisionID = @DivisionID, CustomerID = @CustomerID, ShipToID = @ShipToID, Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country, TotalBoxes = @TotalBoxes, TotalPallets = @TotalPallets, TotalDoubleStackedPallets = @TotalDoubleStackedPallets, TotalPalletsOnFloor = @TotalPalletsOnFloor, ActualWeight = @ActualWeight, ShipVia = @ShipVia, FreightQuoteNumber = @FreightQuoteNumber, SpecialInstructions = @SpecialInstructions, ShipDate = @ShipDate, ShipToName = @ShipToName, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentBOLNumber = @ShipmentBOLNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                    .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                    .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
                    .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
                    .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
                    .Add("@State", SqlDbType.VarChar).Value = cboState.Text
                    .Add("@Zip", SqlDbType.VarChar).Value = txtZip.Text
                    .Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text
                    .Add("@TotalBoxes", SqlDbType.VarChar).Value = Val(txtTotalBoxes.Text)
                    .Add("@TotalPallets", SqlDbType.VarChar).Value = Val(txtTotalPallets.Text)
                    .Add("@TotalDoubleStackedPallets", SqlDbType.VarChar).Value = Val(txtNumberOfDoublePallets.Text)
                    .Add("@TotalPalletsOnFloor", SqlDbType.VarChar).Value = Val(txtNumberOfPalletsOnFloor.Text)
                    .Add("@ActualWeight", SqlDbType.VarChar).Value = Val(txtActualWeight.Text)
                    .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                    .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
                    .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                    .Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                    .Add("@ShipToName", SqlDbType.VarChar).Value = txtCustomerName.Text
                    .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                    .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Check
                Dim intBOLNUmber As Integer = 0
                Dim strBOLNumber As String = ""
                intBOLNUmber = Val(cboBOLNumber.Text)
                strBOLNumber = CStr(intBOLNUmber)

                'Error Check
                ErrorDate = Today()
                ErrorComment = ex.ToString
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Shipment BOL Form --- Save Button"
                ErrorReferenceNumber = "BOL# " + strBOLNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            ShowShipmentsOnBOL()
            MsgBox("BOL has been saved.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub SaveBOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBOLToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub DeleteBOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteBOLToolStripMenuItem.Click
        If cboBOLNumber.Text = "" Then
            MsgBox("You must have a valid BOL Number selected.", MsgBoxStyle.OkOnly)
        Else
            cmd = New SqlCommand("DELETE FROM ShipmentBOLTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber", con)

            With cmd.Parameters
                .Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            ClearVariables()
            ClearData()
            ShowShipments()
            ShowShipmentsOnBOL()
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboBOLNumber.Text = "" Then
            MsgBox("You must have a valid BOL Number selected.", MsgBoxStyle.OkOnly)
        Else
            cmd = New SqlCommand("DELETE FROM ShipmentBOLTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber", con)

            With cmd.Parameters
                .Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadBOLNumber()
            ClearShipments()
            ClearShipmentsOnBOL()
            ClearVariables()
            ClearData()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        'Validate shipping
        ValidateShippingMethod()

        If CheckShippingMethod = "EXIT SUB" Then
            Exit Sub
        End If

        If txtAddress1.Text = "" And txtAddress2.Text = "" Then
            MsgBox("Address 1 and Address 2 fields are blank - shipping address requires one.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboBOLNumber.Text = "" Then
            MsgBox("You must have a valid BOL Number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Create or Update Shipment BOL Header Table entry
            Try
                cmd = New SqlCommand("UPDATE ShipmentBOLTable SET DivisionID = @DivisionID, CustomerID = @CustomerID, ShipToID = @ShipToID, Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, Country = @Country, TotalBoxes = @TotalBoxes, TotalPallets = @TotalPallets, TotalDoubleStackedPallets = @TotalDoubleStackedPallets, TotalPalletsOnFloor = @TotalPalletsOnFloor, ActualWeight = @ActualWeight, ShipVia = @ShipVia, FreightQuoteNumber = @FreightQuoteNumber, SpecialInstructions = @SpecialInstructions, ShipDate = @ShipDate, ShipToName = @ShipToName, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE ShipmentBOLNumber = @ShipmentBOLNumber", con)

                With cmd.Parameters
                    .Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = Val(cboBOLNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                    .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                    .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
                    .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
                    .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
                    .Add("@State", SqlDbType.VarChar).Value = cboState.Text
                    .Add("@Zip", SqlDbType.VarChar).Value = txtZip.Text
                    .Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text
                    .Add("@TotalBoxes", SqlDbType.VarChar).Value = Val(txtTotalBoxes.Text)
                    .Add("@TotalPallets", SqlDbType.VarChar).Value = Val(txtTotalPallets.Text)
                    .Add("@TotalDoubleStackedPallets", SqlDbType.VarChar).Value = Val(txtNumberOfDoublePallets.Text)
                    .Add("@TotalPalletsOnFloor", SqlDbType.VarChar).Value = Val(txtNumberOfPalletsOnFloor.Text)
                    .Add("@ActualWeight", SqlDbType.VarChar).Value = Val(txtActualWeight.Text)
                    .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                    .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
                    .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                    .Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                    .Add("@ShipToName", SqlDbType.VarChar).Value = txtCustomerName.Text
                    .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                    .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Check

            End Try
        End If

        GlobalBOLNumber = Val(cboBOLNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintShippingBOLMultiple As New PrintShippingBOLMultiple
            Dim Result = NewPrintShippingBOLMultiple.ShowDialog
        End Using
    End Sub

    Private Sub PrintBOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBOLToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdClearForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearForm.Click
        ClearVariables()
        ClearData()
        ClearShipments()
        ClearShipmentsOnBOL()
    End Sub

    Private Sub ClearBOLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearBOLToolStripMenuItem.Click
        ClearVariables()
        ClearData()
        ClearShipments()
        ClearShipmentsOnBOL()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        GlobalBOLNumber = 0

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        GlobalBOLNumber = 0

        Me.Dispose()
        Me.Close()
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

    Private Sub cmdRemoveCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveCheckAll.Click
        For Each row As DataGridViewRow In dgvShipmentLineBOL.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectToRemove")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdRemoveUncheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveUncheckAll.Click
        For Each row As DataGridViewRow In dgvShipmentLineBOL.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectToRemove")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Sub cmdGenerateNewBOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewBOL.Click
        'Clear All Fields
        ClearData()
        ClearVariables()
        ClearShipments()
        ClearShipmentsOnBOL()

        'Get New BOLNumber
        Dim MAXBOLStatement As String = "SELECT MAX(ShipmentBOLNumber) FROM ShipmentBOLTable"
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
            cmd = New SqlCommand("INSERT INTO ShipmentBOLTable (ShipmentBOLNumber, DivisionID, CustomerID, ShipToID, Address1, Address2, City, State, Zip, Country, TotalBoxes, TotalPallets, TotalDoubleStackedPallets, TotalPalletsOnFloor, ActualWeight, ShipVia, FreightQuoteNumber, SpecialInstructions, ShipDate, ShipToName, ShippingMethod, ThirdPartyShipper)values(@ShipmentBOLNumber, @DivisionID, @CustomerID, @ShipToID, @Address1, @Address2, @City, @State, @Zip, @Country, @TotalBoxes, @TotalPallets, @TotalDoubleStackedPallets, @TotalPalletsOnFloor, @ActualWeight, @ShipVia, @FreightQuoteNumber, @SpecialInstructions, @ShipDate, @ShipToName, @ShippingMethod, @ThirdPartyShipper)", con)

            With cmd.Parameters
                .Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = NextBOLNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
                .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
                .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
                .Add("@State", SqlDbType.VarChar).Value = cboState.Text
                .Add("@Zip", SqlDbType.VarChar).Value = txtZip.Text
                .Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text
                .Add("@TotalBoxes", SqlDbType.VarChar).Value = Val(txtTotalBoxes.Text)
                .Add("@TotalPallets", SqlDbType.VarChar).Value = Val(txtTotalPallets.Text)
                .Add("@TotalDoubleStackedPallets", SqlDbType.VarChar).Value = Val(txtNumberOfDoublePallets.Text)
                .Add("@TotalPalletsOnFloor", SqlDbType.VarChar).Value = Val(txtNumberOfPalletsOnFloor.Text)
                .Add("@ActualWeight", SqlDbType.VarChar).Value = Val(txtActualWeight.Text)
                .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@FreightQuoteNumber", SqlDbType.VarChar).Value = txtFreightQuoteNumber.Text
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                .Add("@ShipDate", SqlDbType.VarChar).Value = dtpShipDate.Text
                .Add("@ShipToName", SqlDbType.VarChar).Value = txtCustomerName.Text
                .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyShipper.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Check

        End Try
    End Sub

    Private Sub cboBOLNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBOLNumber.SelectedIndexChanged
        LoadBOLTotals()
        LoadBOLData()
        ShowShipmentsOnBOL()
    End Sub

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
        If String.IsNullOrEmpty(txtCustomerName.Text) Then
            V00 = getCustomerName()
        Else
            V00 = txtCustomerName.Text
        End If

        V01 = txtAddress1.Text
        V02 = txtCity.Text & ", " & cboState.Text & " " & txtZip.Text
        V03 = txtAddress2.Text
        cmd = New SqlCommand("SELECT Country FROM CountryCodes WHERE CountryCode = @CountryCode", con)
        cmd.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = txtCountry.Text

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim obj As Object = cmd.ExecuteScalar()
            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                V04 = obj.ToString()
            End If
        Catch ex As Exception
            V04 = txtCountry.Text
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

    Private Function getCustomerName() As String
        cmd = New SqlCommand("Select CustomerName FROM CustomerList WHERE CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'", con)
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
        If String.IsNullOrEmpty(txtTotalPallets.Text) = False Then
            pallets = Convert.ToInt32(txtTotalPallets.Text)
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

    Private Sub txtTotalPallets_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPallets.TextChanged
        NumberOfPallets = Val(txtTotalPallets.Text)
        NumberOfDoublePallets = Val(txtNumberOfDoublePallets.Text)
        NumberOfPalletsOnFloor = NumberOfPallets - NumberOfDoublePallets

        txtNumberOfPalletsOnFloor.Text = NumberOfPalletsOnFloor
    End Sub

    Private Sub txtNumberOfDoublePallets_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumberOfDoublePallets.TextChanged
        NumberOfPallets = Val(txtTotalPallets.Text)
        NumberOfDoublePallets = Val(txtNumberOfDoublePallets.Text)
        NumberOfPalletsOnFloor = NumberOfPallets - NumberOfDoublePallets

        txtNumberOfPalletsOnFloor.Text = NumberOfPalletsOnFloor
    End Sub

    Private Sub txtNumberOfPalletsOnFloor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumberOfPalletsOnFloor.TextChanged
        If txtNumberOfPalletsOnFloor.Text = "" Then
            txtNumberOfPalletsOnFloor.Clear()
        End If
    End Sub

    Private Sub llAddPresetComments_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llAddPresetComments.LinkClicked
        Dim LineOne, LineTwo, LineThree, LineFour As String
        LineOne = "SEAL # - "
        LineTwo = "CONTAINER # - "
        LineThree = "TIME IN: - "
        LineFour = "TIME OUT: - "

        txtSpecialInstructions.Text = Environment.NewLine + LineOne + Environment.NewLine + LineTwo + Environment.NewLine + LineThree + Environment.NewLine + LineFour
    End Sub
End Class