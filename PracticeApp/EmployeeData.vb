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
Public Class EmployeeData
    Inherits System.Windows.Forms.Form

    Dim MOSLoginType, DepartmentName, EmployeeDivision, DivisionConnect, LastConnect, FirstConnect, SalesID, FullName As String
    Dim EmployeeStatus, EmployeeLast, EmployeeFirst, DepartmentID, EmailAddress, Address, City, State, ZipCode, PhoneNumber, SecurityGroupID, EmergencyContact, HireDate, LoginName, LoginPassword, SalesPersonID As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub EmployeeData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.SecurityGroup' table. You can move, or remove it, as needed.
        Me.SecurityGroupTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.SecurityGroup)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.Departments' table. You can move, or remove it, as needed.
        Me.DepartmentsTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.Departments)

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionKey.Enabled = True
            cboDivisionKey.Text = EmployeeCompanyCode
        Else
            cboDivisionKey.Enabled = False
            cboDivisionKey.Text = EmployeeCompanyCode
        End If

        If EmployeeSecurityCode = "1001" Then
            gpxTFPEmployeeData.Enabled = True
            gpxEmpPersonalData.Enabled = True
            Me.dgvEmployeeData.Enabled = True
        Else
            gpxTFPEmployeeData.Enabled = False
            gpxEmpPersonalData.Enabled = False
            Me.dgvEmployeeData.Enabled = False
        End If

        'Clear text boxes on load
        LoadEmployeeID()
        ClearData()
        ShowData()
    End Sub

    Public Sub LoadFormatting()
        Dim EmployeeStatus As String = ""
        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvEmployeeData.Rows
            Try
                EmployeeStatus = row.Cells("StatusColumn").Value
            Catch ex As System.Exception
                EmployeeStatus = ""
            End Try

            If EmployeeStatus = "OPEN" Then
                Me.dgvEmployeeData.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvEmployeeData.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            ElseIf EmployeeStatus = "CLOSED" Then
                Me.dgvEmployeeData.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvEmployeeData.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
            Else
                Me.dgvEmployeeData.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvEmployeeData.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
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
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = True
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionKey.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionKey.Text = EmployeeCompanyCode
                cboDivisionKey.Enabled = False
        End Select
    End Sub

    Public Sub LoadEmployeeID()
        cmd = New SqlCommand("SELECT EmployeeID FROM EmployeeData", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "EmployeeData")
        cboEmployeeNumber.DataSource = ds1.Tables("EmployeeData")
        con.Close()
        cboEmployeeNumber.SelectedIndex = -1
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvEmployeeData.CellValueChanged
        Dim LineSecurityGroup, LineShift As Integer
        Dim LineMOSLoginType, LineEmployeeID, LineEmployeeLast, LineEmployeeFirst, LineDepartment, LineEmailAddress, LineAddress, LineCity, LineState, LineZip, LinePhone, LineDivision, LineEmergency, LineLoginName, LineLoginPassword, LineSalesID As String
        Dim LineHireDate As Date

        If Me.dgvEmployeeData.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvEmployeeData.CurrentCell.RowIndex

            Try
                LineEmployeeID = Me.dgvEmployeeData.Rows(RowIndex).Cells("EmployeeIDColumn").Value
            Catch ex As Exception
                LineEmployeeID = ""
            End Try
            Try
                LineEmployeeLast = Me.dgvEmployeeData.Rows(RowIndex).Cells("EmployeeLastColumn").Value
            Catch ex As Exception
                LineEmployeeLast = ""
            End Try
            Try
                LineEmployeeFirst = Me.dgvEmployeeData.Rows(RowIndex).Cells("EmployeeFirstColumn").Value
            Catch ex As Exception
                LineEmployeeFirst = ""
            End Try
            Try
                LineDepartment = Me.dgvEmployeeData.Rows(RowIndex).Cells("DepartmentColumn").Value
            Catch ex As Exception
                LineDepartment = ""
            End Try
            Try
                LineEmailAddress = Me.dgvEmployeeData.Rows(RowIndex).Cells("EmailAddressColumn").Value
            Catch ex As Exception
                LineEmailAddress = ""
            End Try
            Try
                LineAddress = Me.dgvEmployeeData.Rows(RowIndex).Cells("AddressColumn").Value
            Catch ex As Exception
                LineAddress = ""
            End Try
            Try
                LineCity = Me.dgvEmployeeData.Rows(RowIndex).Cells("CityColumn").Value
            Catch ex As Exception
                LineCity = ""
            End Try
            Try
                LineState = Me.dgvEmployeeData.Rows(RowIndex).Cells("StateColumn").Value
            Catch ex As Exception
                LineState = ""
            End Try
            Try
                LineZip = Me.dgvEmployeeData.Rows(RowIndex).Cells("ZipCodeColumn").Value
            Catch ex As Exception
                LineZip = ""
            End Try
            Try
                LinePhone = Me.dgvEmployeeData.Rows(RowIndex).Cells("PhoneNumberColumn").Value
            Catch ex As Exception
                LinePhone = ""
            End Try
            Try
                LineSecurityGroup = Me.dgvEmployeeData.Rows(RowIndex).Cells("SecurityGroupIDColumn").Value
            Catch ex As Exception
                LineSecurityGroup = ""
            End Try
            Try
                LineDivision = Me.dgvEmployeeData.Rows(RowIndex).Cells("DivisionKeyColumn").Value
            Catch ex As Exception
                LineDivision = ""
            End Try
            Try
                LineEmergency = Me.dgvEmployeeData.Rows(RowIndex).Cells("EmergencyContactColumn").Value
            Catch ex As Exception
                LineEmergency = ""
            End Try
            Try
                LineHireDate = Me.dgvEmployeeData.Rows(RowIndex).Cells("HireDateColumn").Value
            Catch ex As Exception
                LineHireDate = ""
            End Try
            Try
                LineLoginName = Me.dgvEmployeeData.Rows(RowIndex).Cells("LoginNameColumn").Value
            Catch ex As Exception
                LineLoginName = ""
            End Try
            Try
                LineLoginPassword = Me.dgvEmployeeData.Rows(RowIndex).Cells("LoginPasswordColumn").Value
            Catch ex As Exception
                LineLoginPassword = ""
            End Try
            Try
                LineSalesID = Me.dgvEmployeeData.Rows(RowIndex).Cells("SalesPersonIDColumn").Value
            Catch ex As Exception
                LineSalesID = ""
            End Try
            Try
                LineShift = Me.dgvEmployeeData.Rows(RowIndex).Cells("ShiftColumn").Value
            Catch ex As Exception
                LineShift = 0
            End Try
            Try
                LineMOSLoginType = Me.dgvEmployeeData.Rows(RowIndex).Cells("MOSLoginTypeColumn").Value
            Catch ex As Exception
                LineMOSLoginType = 0
            End Try

            Try
                'Update employee information in table
                cmd = New SqlCommand("UPDATE EmployeeData SET EmployeeID = @EmployeeID, EmployeeLast = @EmployeeLast, EmployeeFirst = @EmployeeFirst, Department = @Department, EmailAddress = @EmailAddress, Address = @Address, City = @City, State = @State, ZipCode = @ZipCode, PhoneNumber = @PhoneNumber, SecurityGroupID = @SecurityGroupID, DivisionKey = @DivisionKey, EmergencyContact = @EmergencyContact, HireDate = @HireDate, LoginName = @LoginName, LoginPassword = @LoginPassword, SalesPersonID = @SalesPersonID, Shift = @Shift, EmployeeStatus = @EmployeeStatus, MOSLoginType = @MOSLoginType WHERE EmployeeID = @EmployeeID", con)

                With cmd.Parameters
                    .Add("@EmployeeID", SqlDbType.VarChar).Value = LineEmployeeID
                    .Add("@EmployeeLast", SqlDbType.VarChar).Value = LineEmployeeLast
                    .Add("@EmployeeFirst", SqlDbType.VarChar).Value = LineEmployeeFirst
                    .Add("@Department", SqlDbType.VarChar).Value = LineDepartment
                    .Add("@EmailAddress", SqlDbType.VarChar).Value = LineEmailAddress
                    .Add("@Address", SqlDbType.VarChar).Value = LineAddress
                    .Add("@City", SqlDbType.VarChar).Value = LineCity
                    .Add("@State", SqlDbType.VarChar).Value = LineState
                    .Add("@ZipCode", SqlDbType.VarChar).Value = LineZip
                    .Add("@PhoneNumber", SqlDbType.VarChar).Value = LinePhone
                    .Add("@SecurityGroupID", SqlDbType.VarChar).Value = LineSecurityGroup
                    .Add("@DivisionKey", SqlDbType.VarChar).Value = LineDivision
                    .Add("@EmergencyContact", SqlDbType.VarChar).Value = LineEmergency
                    .Add("@HireDate", SqlDbType.VarChar).Value = LineHireDate
                    .Add("@LoginName", SqlDbType.VarChar).Value = LineLoginName
                    .Add("@LoginPassword", SqlDbType.VarChar).Value = LineLoginPassword
                    .Add("@SalesPersonID", SqlDbType.VarChar).Value = LineSalesID
                    .Add("@Shift", SqlDbType.VarChar).Value = LineShift
                    '.Add("@CustomCode", SqlDbType.VarChar).Value = ""
                    .Add("@EmployeeStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@MOSLoginType", SqlDbType.VarChar).Value = LineMOSLoginType
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        End If
    End Sub

    Public Sub ClearData()
        cboDepartmentName.SelectedIndex = -1
        cboEmployeeNumber.SelectedIndex = -1
        cboSecurityGroup.SelectedIndex = -1
        cboDivisionKey.Text = EmployeeCompanyCode
        cboLoginType.Text = ""
        cboLoginType.SelectedIndex = -1

        txtSalesPersonID.Clear()
        txtEmpAddress.Clear()
        txtEmpCity.Clear()
        txtEmpEmail.Clear()
        txtEmpEmergencyContact.Clear()
        txtEmpFirstName.Clear()
        txtEmpLastName.Clear()
        txtEmpPhone.Clear()
        txtEmpState.Clear()
        txtEmpZipCode.Clear()
        txtLoginName.Clear()
        txtLoginPassword.Clear()
        txtStatus.Clear()
        txtDepartmentID.Clear()

        dtpHireDate.Text = ""

        chkSalesPerson.Checked = False

        cboEmployeeNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        DivisionConnect = ""
        LastConnect = ""
        FirstConnect = ""
        SalesID = ""
        FullName = ""
        EmployeeLast = ""
        EmployeeFirst = ""
        DepartmentID = ""
        EmailAddress = ""
        Address = ""
        City = ""
        State = ""
        ZipCode = ""
        PhoneNumber = ""
        SecurityGroupID = ""
        EmergencyContact = ""
        HireDate = ""
        LoginName = ""
        LoginPassword = ""
        SalesPersonID = ""
        EmployeeDivision = ""
        EmployeeStatus = ""
        DepartmentName = ""
        MOSLoginType = ""
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM EmployeeData", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "EmployeeData")
        dgvEmployeeData.DataSource = ds.Tables("EmployeeData")
        con.Close()
        If EmployeeSecurityCode = "1001" Then
            dgvEmployeeData.Columns("LoginPasswordColumn").Visible = True
            dgvEmployeeData.Columns("LoginNameColumn").Visible = True
        Else
            dgvEmployeeData.Columns("LoginPasswordColumn").Visible = False
            dgvEmployeeData.Columns("LoginNameColumn").Visible = False
        End If

        LoadFormatting()
    End Sub

    Public Sub LoadEmployeeData()
        Dim EmployeeFirstStatement As String = "SELECT EmployeeFirst FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim EmployeeFirstCommand As New SqlCommand(EmployeeFirstStatement, con)
        EmployeeFirstCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim EmployeeDivisionStatement As String = "SELECT DivisionKey FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim EmployeeDivisionCommand As New SqlCommand(EmployeeDivisionStatement, con)
        EmployeeDivisionCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim EmployeeLastStatement As String = "SELECT EmployeeLast FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim EmployeeLastCommand As New SqlCommand(EmployeeLastStatement, con)
        EmployeeLastCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim DepartmentStatement As String = "SELECT Department FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim DepartmentCommand As New SqlCommand(DepartmentStatement, con)
        DepartmentCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim EmailAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim EmailAddressCommand As New SqlCommand(EmailAddressStatement, con)
        EmailAddressCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim AddressStatement As String = "SELECT Address FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim AddressCommand As New SqlCommand(AddressStatement, con)
        AddressCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim CityStatement As String = "SELECT City FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim CityCommand As New SqlCommand(CityStatement, con)
        CityCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim StateStatement As String = "SELECT State FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim StateCommand As New SqlCommand(StateStatement, con)
        StateCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim ZipCodeStatement As String = "SELECT ZipCode FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim ZipCodeCommand As New SqlCommand(ZipCodeStatement, con)
        ZipCodeCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim PhoneNumberStatement As String = "SELECT PhoneNumber FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim PhoneNumberCommand As New SqlCommand(PhoneNumberStatement, con)
        PhoneNumberCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim SecurityGroupIDStatement As String = "SELECT SecurityGroupID FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim SecurityGroupIDCommand As New SqlCommand(SecurityGroupIDStatement, con)
        SecurityGroupIDCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim EmergencyContactStatement As String = "SELECT EmergencyContact FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim EmergencyContactCommand As New SqlCommand(EmergencyContactStatement, con)
        EmergencyContactCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim HireDateStatement As String = "SELECT HireDate FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim HireDateCommand As New SqlCommand(HireDateStatement, con)
        HireDateCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim LoginNameStatement As String = "SELECT LoginName FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim LoginNameCommand As New SqlCommand(LoginNameStatement, con)
        LoginNameCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim LoginPasswordStatement As String = "SELECT LoginPassword FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim LoginPasswordCommand As New SqlCommand(LoginPasswordStatement, con)
        LoginPasswordCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim SalesPersonIDStatement As String = "SELECT SalesPersonID FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim SalesPersonIDCommand As New SqlCommand(SalesPersonIDStatement, con)
        SalesPersonIDCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim EmployeeStatusStatement As String = "SELECT EmployeeStatus FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim EmployeeStatusCommand As New SqlCommand(EmployeeStatusStatement, con)
        EmployeeStatusCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        Dim MOSLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim MOSLoginTypeCommand As New SqlCommand(MOSLoginTypeStatement, con)
        MOSLoginTypeCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            EmployeeFirst = CStr(EmployeeFirstCommand.ExecuteScalar)
        Catch ex As Exception
            EmployeeFirst = ""
        End Try
        Try
            EmployeeLast = CStr(EmployeeLastCommand.ExecuteScalar)
        Catch ex As Exception
            EmployeeLast = ""
        End Try
        Try
            DepartmentID = CStr(DepartmentCommand.ExecuteScalar)
        Catch ex As Exception
            DepartmentID = ""
        End Try
        Try
            EmailAddress = CStr(EmailAddressCommand.ExecuteScalar)
        Catch ex As Exception
            EmailAddress = ""
        End Try
        Try
            Address = CStr(AddressCommand.ExecuteScalar)
        Catch ex As Exception
            Address = ""
        End Try
        Try
            City = CStr(CityCommand.ExecuteScalar)
        Catch ex As Exception
            City = ""
        End Try
        Try
            State = CStr(StateCommand.ExecuteScalar)
        Catch ex As Exception
            State = ""
        End Try
        Try
            ZipCode = CStr(ZipCodeCommand.ExecuteScalar)
        Catch ex As Exception
            ZipCode = ""
        End Try
        Try
            PhoneNumber = CStr(PhoneNumberCommand.ExecuteScalar)
        Catch ex As Exception
            PhoneNumber = ""
        End Try
        Try
            SecurityGroupID = CStr(SecurityGroupIDCommand.ExecuteScalar)
        Catch ex As Exception
            SecurityGroupID = ""
        End Try
        Try
            EmergencyContact = CStr(EmergencyContactCommand.ExecuteScalar)
        Catch ex As Exception
            EmergencyContact = ""
        End Try
        Try
            HireDate = CStr(HireDateCommand.ExecuteScalar)
        Catch ex As Exception
            HireDate = ""
        End Try
        Try
            LoginName = CStr(LoginNameCommand.ExecuteScalar)
        Catch ex As Exception
            LoginName = ""
        End Try
        Try
            LoginPassword = CStr(LoginPasswordCommand.ExecuteScalar)
        Catch ex As Exception
            LoginPassword = ""
        End Try
        Try
            SalesPersonID = CStr(SalesPersonIDCommand.ExecuteScalar)
        Catch ex As Exception
            SalesPersonID = ""
        End Try
        Try
            EmployeeStatus = CStr(EmployeeStatusCommand.ExecuteScalar)
        Catch ex As Exception
            EmployeeStatus = "OPEN"
        End Try
        Try
            EmployeeDivision = CStr(EmployeeDivisionCommand.ExecuteScalar)
        Catch ex As Exception
            EmployeeDivision = ""
        End Try
        Try
            MOSLoginType = CStr(MOSLoginTypeCommand.ExecuteScalar)
        Catch ex As Exception
            MOSLoginType = "LOCAL"
        End Try
        con.Close()

        txtDepartmentID.Text = DepartmentID
        LoadDepartmentNameFromID()

        cboSecurityGroup.Text = SecurityGroupID
        txtEmpAddress.Text = Address
        txtEmpCity.Text = City
        txtEmpEmail.Text = EmailAddress
        txtEmpEmergencyContact.Text = EmergencyContact
        txtEmpFirstName.Text = EmployeeFirst
        txtEmpLastName.Text = EmployeeLast
        txtEmpPhone.Text = PhoneNumber
        txtEmpState.Text = State
        txtEmpZipCode.Text = ZipCode
        txtLoginName.Text = LoginName
        txtLoginPassword.Text = LoginPassword
        txtSalesPersonID.Text = SalesPersonID
        txtStatus.Text = EmployeeStatus
        cboDivisionKey.Text = EmployeeDivision
        cboLoginType.Text = MOSLoginType
    End Sub

    Public Sub LoadDepartmentID()
        Dim DepartmentNameStatement As String = "SELECT DepartmentID FROM Departments WHERE DepartmentName = @DepartmentName"
        Dim DepartmentNameCommand As New SqlCommand(DepartmentNameStatement, con)
        DepartmentNameCommand.Parameters.Add("@DepartmentName", SqlDbType.VarChar).Value = cboDepartmentName.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DepartmentID = CStr(DepartmentNameCommand.ExecuteScalar)
        Catch ex As Exception
            DepartmentID = ""
        End Try
        con.Close()

        txtDepartmentID.Text = DepartmentID
    End Sub

    Public Sub LoadDepartmentNameFromID()
        Dim DepartmentNameStatement As String = "SELECT DepartmentName FROM Departments WHERE DepartmentID = @DepartmentID"
        Dim DepartmentNameCommand As New SqlCommand(DepartmentNameStatement, con)
        DepartmentNameCommand.Parameters.Add("@DepartmentID", SqlDbType.VarChar).Value = txtDepartmentID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DepartmentName = CStr(DepartmentNameCommand.ExecuteScalar)
        Catch ex As Exception
            DepartmentName = ""
        End Try
        con.Close()

        cboDepartmentName.Text = DepartmentName
    End Sub

    Public Sub LoadEmployeeStatus()
        Dim GetEmployeeStatus As String = ""

        Dim GetEmployeeStatusStatement As String = "SELECT EmployeeStatus FROM EmployeeData WHERE EmployeeID = @EmployeeID"
        Dim GetEmployeeStatusCommand As New SqlCommand(GetEmployeeStatusStatement, con)
        GetEmployeeStatusCommand.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetEmployeeStatus = CStr(GetEmployeeStatusCommand.ExecuteScalar)
        Catch ex As Exception
            GetEmployeeStatus = ""
        End Try
        con.Close()

        txtStatus.Text = GetEmployeeStatus

        If GetEmployeeStatus = "CLOSED" Then
            txtDepartmentID.Enabled = False
            txtEmpAddress.Enabled = False
            txtEmpCity.Enabled = False
            txtEmpEmail.Enabled = False
            txtEmpEmergencyContact.Enabled = False
            txtEmpFirstName.Enabled = False
            txtEmpLastName.Enabled = False
            txtEmpPhone.Enabled = False
            txtEmpState.Enabled = False
            txtEmpZipCode.Enabled = False
            txtLoginName.Enabled = False
            txtLoginPassword.Enabled = False
            txtSalesPersonID.Enabled = False

            cboDepartmentName.Enabled = False
            cboSecurityGroup.Enabled = False

            dtpHireDate.Enabled = False

            chkSalesPerson.Enabled = False

            cmdEnter.Enabled = False

            cmdDeactivateEmployee.Text = "Open"
        ElseIf GetEmployeeStatus = "OPEN" Then
            txtDepartmentID.Enabled = True
            txtEmpAddress.Enabled = True
            txtEmpCity.Enabled = True
            txtEmpEmail.Enabled = True
            txtEmpEmergencyContact.Enabled = True
            txtEmpFirstName.Enabled = True
            txtEmpLastName.Enabled = True
            txtEmpPhone.Enabled = True
            txtEmpState.Enabled = True
            txtEmpZipCode.Enabled = True
            txtLoginName.Enabled = True
            txtLoginPassword.Enabled = True
            txtSalesPersonID.Enabled = True

            cboDepartmentName.Enabled = True
            cboSecurityGroup.Enabled = True

            dtpHireDate.Enabled = True

            chkSalesPerson.Enabled = True

            cmdEnter.Enabled = True

            cmdDeactivateEmployee.Text = "Close"
        Else
            txtDepartmentID.Enabled = True
            txtEmpAddress.Enabled = True
            txtEmpCity.Enabled = True
            txtEmpEmail.Enabled = True
            txtEmpEmergencyContact.Enabled = True
            txtEmpFirstName.Enabled = True
            txtEmpLastName.Enabled = True
            txtEmpPhone.Enabled = True
            txtEmpState.Enabled = True
            txtEmpZipCode.Enabled = True
            txtLoginName.Enabled = True
            txtLoginPassword.Enabled = True
            txtSalesPersonID.Enabled = True

            cboDepartmentName.Enabled = True
            cboSecurityGroup.Enabled = True

            dtpHireDate.Enabled = True

            chkSalesPerson.Enabled = True

            cmdEnter.Enabled = True

            cmdDeactivateEmployee.Text = "Close"
        End If
    End Sub

    Private Sub cboDivisionKey_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionKey.SelectedIndexChanged
        DivisionConnect = cboDivisionKey.Text
    End Sub

    Private Sub txtEmpLastName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpLastName.TextChanged
        LastConnect = txtEmpLastName.Text
    End Sub

    Private Sub txtEmpFirstName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpFirstName.TextChanged
        FirstConnect = txtEmpFirstName.Text
    End Sub

    Private Sub chkSalesPerson_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSalesPerson.CheckedChanged
        FirstConnect = txtEmpFirstName.Text
        LastConnect = txtEmpLastName.Text
        DivisionConnect = cboDivisionKey.Text

        SalesID = DivisionConnect + "-" + FirstConnect + LastConnect

        If chkSalesPerson.Checked = False Then
            txtSalesPersonID.Text = ""
        Else
            txtSalesPersonID.Text = SalesID
            FullName = FirstConnect + " " + LastConnect
        End If
    End Sub

    Private Sub cmdPrintPhoneList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintPhoneList.Click
        Using NewPrintPhoneList As New PrintPhoneList
            Dim result = NewPrintPhoneList.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrintEmailList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintEmailList.Click
        Using NewPrintEmailList As New PrintEmailList
            Dim result = NewPrintEmailList.ShowDialog()
        End Using
    End Sub

    Private Sub cboEmployeeNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmployeeNumber.SelectedIndexChanged
        LoadEmployeeData()
        LoadEmployeeStatus()
    End Sub

    Private Sub cmdLogonRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogonRecord.Click
        Dim NewViewEmployeeLogonTable As New ViewEmployeeLogonTable
        NewViewEmployeeLogonTable.Show()
    End Sub

    Private Sub cmdEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnter.Click
        'Add new employee to database
        If cboEmployeeNumber.Text = "" Then
            MsgBox("You must select a valid Employee Number.", MsgBoxStyle.OkOnly)
        Else
            Try
                cmd = New SqlCommand("Insert Into EmployeeData(EmployeeID, EmployeeLast, EmployeeFirst, Department, EmailAddress, Address, City, State, ZipCode, PhoneNumber, DivisionKey, SecurityGroupID, EmergencyContact, HireDate, LoginName, LoginPassword, SalesPersonID, Shift, CustomCode, EmployeeStatus, MOSLoginType) Values (@EmployeeID, @EmployeeLast, @EmployeeFirst, @Department, @EmailAddress,@Address, @City, @State, @ZipCode, @PhoneNumber, @DivisionKey, @SecurityGroupID, @EmergencyContact, @HireDate, @LoginName, @LoginPassword, @SalesPersonID, @Shift, @CustomCode, @EmployeeStatus, @MOSLoginType)", con)

                With cmd.Parameters
                    .Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text
                    .Add("@EmployeeLast", SqlDbType.VarChar).Value = txtEmpLastName.Text
                    .Add("@EmployeeFirst", SqlDbType.VarChar).Value = txtEmpFirstName.Text
                    .Add("@Department", SqlDbType.VarChar).Value = txtDepartmentID.Text
                    .Add("@EmailAddress", SqlDbType.VarChar).Value = txtEmpEmail.Text
                    .Add("@Address", SqlDbType.VarChar).Value = txtEmpAddress.Text
                    .Add("@City", SqlDbType.VarChar).Value = txtEmpCity.Text
                    .Add("@State", SqlDbType.VarChar).Value = txtEmpState.Text
                    .Add("@ZipCode", SqlDbType.VarChar).Value = txtEmpZipCode.Text
                    .Add("@PhoneNumber", SqlDbType.VarChar).Value = txtEmpPhone.Text
                    .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionKey.Text
                    .Add("@SecurityGroupID", SqlDbType.VarChar).Value = Val(cboSecurityGroup.Text)
                    .Add("@EmergencyContact", SqlDbType.VarChar).Value = txtEmpEmergencyContact.Text
                    .Add("@HireDate", SqlDbType.VarChar).Value = dtpHireDate.Text
                    .Add("@LoginName", SqlDbType.VarChar).Value = txtLoginName.Text
                    .Add("@LoginPassword", SqlDbType.VarChar).Value = txtLoginPassword.Text
                    .Add("@SalesPersonID", SqlDbType.VarChar).Value = txtSalesPersonID.Text
                    .Add("@Shift", SqlDbType.VarChar).Value = 1
                    .Add("@CustomCode", SqlDbType.VarChar).Value = "11111111111111111"
                    .Add("@EmployeeStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@MOSLoginType", SqlDbType.VarChar).Value = cboLoginType.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Clear text boxes after adding 
                LoadEmployeeID()
                ClearData()
                ShowData()
            Catch ex As Exception
                cmd = New SqlCommand("UPDATE EmployeeData SET EmployeeLast = @EmployeeLast, EmployeeFirst = @EmployeeFirst, Department = @Department, EmailAddress = @EmailAddress, Address = @Address, City = @City, State = @State, ZipCode = @ZipCode, PhoneNumber = @PhoneNumber, DivisionKey = @DivisionKey, SecurityGroupID = @SecurityGroupID, EmergencyContact = @EmergencyContact, HireDate = @HireDate, LoginName = @LoginName, LoginPassword = @LoginPassword, SalesPersonID = @SalesPersonID, Shift = @Shift, EmployeeStatus = @EmployeeStatus, MOSLoginType = @MOSLoginType WHERE EmployeeID = @EmployeeID", con)

                With cmd.Parameters
                    .Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text
                    .Add("@EmployeeLast", SqlDbType.VarChar).Value = txtEmpLastName.Text
                    .Add("@EmployeeFirst", SqlDbType.VarChar).Value = txtEmpFirstName.Text
                    .Add("@Department", SqlDbType.VarChar).Value = txtDepartmentID.Text
                    .Add("@EmailAddress", SqlDbType.VarChar).Value = txtEmpEmail.Text
                    .Add("@Address", SqlDbType.VarChar).Value = txtEmpAddress.Text
                    .Add("@City", SqlDbType.VarChar).Value = txtEmpCity.Text
                    .Add("@State", SqlDbType.VarChar).Value = txtEmpState.Text
                    .Add("@ZipCode", SqlDbType.VarChar).Value = txtEmpZipCode.Text
                    .Add("@PhoneNumber", SqlDbType.VarChar).Value = txtEmpPhone.Text
                    .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionKey.Text
                    .Add("@SecurityGroupID", SqlDbType.VarChar).Value = Val(cboSecurityGroup.Text)
                    .Add("@EmergencyContact", SqlDbType.VarChar).Value = txtEmpEmergencyContact.Text
                    .Add("@HireDate", SqlDbType.VarChar).Value = dtpHireDate.Text
                    .Add("@LoginName", SqlDbType.VarChar).Value = txtLoginName.Text
                    .Add("@LoginPassword", SqlDbType.VarChar).Value = txtLoginPassword.Text
                    .Add("@SalesPersonID", SqlDbType.VarChar).Value = txtSalesPersonID.Text
                    .Add("@Shift", SqlDbType.VarChar).Value = 1
                    '.Add("@CustomCode", SqlDbType.VarChar).Value = "111111111111111"
                    .Add("@EmployeeStatus", SqlDbType.VarChar).Value = txtStatus.Text
                    .Add("@MOSLoginType", SqlDbType.VarChar).Value = cboLoginType.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Clear text boxes after adding 
                LoadEmployeeID()
                ClearData()
                ShowData()
            End Try
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        'Clear text boxes
        LoadEmployeeID()
        ClearVariables()
        ClearData()
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        'Clear text boxes
        LoadEmployeeID()
        ClearVariables()
        ClearData()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cboDepartmentName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartmentName.SelectedIndexChanged
        If cboDepartmentName.Text <> "" Then
            LoadDepartmentID()
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdDeactivateEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeactivateEmployee.Click
        If txtStatus.Text = "OPEN" Then
            cmd = New SqlCommand("UPDATE EmployeeData SET EmployeeStatus = @EmployeeStatus WHERE EmployeeID = @EmployeeID", con)

            With cmd.Parameters
                .Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text
                .Add("@EmployeeStatus", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadEmployeeStatus()
            ShowData()
        ElseIf txtStatus.Text = "CLOSED" Then
            cmd = New SqlCommand("UPDATE EmployeeData SET EmployeeStatus = @EmployeeStatus WHERE EmployeeID = @EmployeeID", con)

            With cmd.Parameters
                .Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text
                .Add("@EmployeeStatus", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadEmployeeStatus()
            ShowData()
        Else
            cmd = New SqlCommand("UPDATE EmployeeData SET EmployeeStatus = @EmployeeStatus WHERE EmployeeID = @EmployeeID", con)

            With cmd.Parameters
                .Add("@EmployeeID", SqlDbType.VarChar).Value = cboEmployeeNumber.Text
                .Add("@EmployeeStatus", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadEmployeeStatus()
            ShowData()
        End If
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        ClearVariables()
        ClearData()

        ShowData()
    End Sub
End Class