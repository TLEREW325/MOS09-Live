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
Public Class EditCompanyInfo
    Inherits System.Windows.Forms.Form

    Dim EIN, DivisionClass, DivisionName, CompanyDescription, Address1, Address2, City, State, ZipCode, Country, Phone, Fax, TollFree, Email, AccountNumber, RoutingNumber, MicrHeader As String
    Dim AccountNumberPrefix, AccountNumberCanadian, TransitNumber, Institution As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub EditCompanyInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)

        LoadCurrentDivision()

        cboDivisionID.Text = EmployeeCompanyCode
        usefulFunctions.LoadSecurity(Me)

        LoadCompanyData()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCompanyData()

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            gpxCanadianData.Enabled = True
        Else
            gpxCanadianData.Enabled = False
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

    Private Sub LoadCompanyData()
        Dim DivisionDescriptionStatement As String = "SELECT DivisionDescription FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim DivisionDescriptionCommand As New SqlCommand(DivisionDescriptionStatement, con)
        DivisionDescriptionCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CompanyNameStatement As String = "SELECT CompanyName FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim CompanyNameCommand As New SqlCommand(CompanyNameStatement, con)
        CompanyNameCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Address1Statement As String = "SELECT Address1 FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim Address1Command As New SqlCommand(Address1Statement, con)
        Address1Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim Address2Statement As String = "SELECT Address2 FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim Address2Command As New SqlCommand(Address2Statement, con)
        Address2Command.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CityStatement As String = "SELECT City FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim CityCommand As New SqlCommand(CityStatement, con)
        CityCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim StateStatement As String = "SELECT State FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim StateCommand As New SqlCommand(StateStatement, con)
        StateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ZipCodeStatement As String = "SELECT ZipCode FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim ZipCodeCommand As New SqlCommand(ZipCodeStatement, con)
        ZipCodeCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CountryStatement As String = "SELECT Country FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim CountryCommand As New SqlCommand(CountryStatement, con)
        CountryCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PhoneStatement As String = "SELECT Phone FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim PhoneCommand As New SqlCommand(PhoneStatement, con)
        PhoneCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TollFreeStatement As String = "SELECT TollFree FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim TollFreeCommand As New SqlCommand(TollFreeStatement, con)
        TollFreeCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim FaxStatement As String = "SELECT Fax FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim FaxCommand As New SqlCommand(FaxStatement, con)
        FaxCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim EmailStatement As String = "SELECT Email FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim EmailCommand As New SqlCommand(EmailStatement, con)
        EmailCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim AccountNumberStatement As String = "SELECT AccountNumber FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim AccountNumberCommand As New SqlCommand(AccountNumberStatement, con)
        AccountNumberCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim RoutingNumberStatement As String = "SELECT RoutingNumber FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim RoutingNumberCommand As New SqlCommand(RoutingNumberStatement, con)
        RoutingNumberCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim AccountNumberCanadianStatement As String = "SELECT AccountNumberCanadian FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim AccountNumberCanadianCommand As New SqlCommand(AccountNumberCanadianStatement, con)
        AccountNumberCanadianCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InstitutionStatement As String = "SELECT Institution FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim InstitutionCommand As New SqlCommand(InstitutionStatement, con)
        InstitutionCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TransitNumberStatement As String = "SELECT TransitNumber FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim TransitNumberCommand As New SqlCommand(TransitNumberStatement, con)
        TransitNumberCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim AccountNumberPrefixStatement As String = "SELECT AccountNumberPrefix FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim AccountNumberPrefixCommand As New SqlCommand(AccountNumberPrefixStatement, con)
        AccountNumberPrefixCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim DivisionClassStatement As String = "SELECT DivisionClass FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim DivisionClassCommand As New SqlCommand(DivisionClassStatement, con)
        DivisionClassCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim EINStatement As String = "SELECT EIN FROM DivisionTable WHERE DivisionKey = @DivisionKey"
        Dim EINCommand As New SqlCommand(EINStatement, con)
        EINCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CompanyDescription = CStr(DivisionDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            CompanyDescription = ""
        End Try
        Try
            DivisionName = CStr(CompanyNameCommand.ExecuteScalar)
        Catch ex As Exception
            DivisionName = ""
        End Try
        Try
            Address1 = CStr(Address1Command.ExecuteScalar)
        Catch ex As Exception
            Address1 = ""
        End Try
        Try
            Address2 = CStr(Address2Command.ExecuteScalar)
        Catch ex As Exception
            Address2 = ""
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
            State = CStr(StateCommand.ExecuteScalar)
        Catch ex As Exception
            State = ""
        End Try
        Try
            Country = CStr(CountryCommand.ExecuteScalar)
        Catch ex As Exception
            Country = ""
        End Try
        Try
            Phone = CStr(PhoneCommand.ExecuteScalar)
        Catch ex As Exception
            Phone = ""
        End Try
        Try
            Fax = CStr(FaxCommand.ExecuteScalar)
        Catch ex As Exception
            Fax = ""
        End Try
        Try
            TollFree = CStr(TollFreeCommand.ExecuteScalar)
        Catch ex As Exception
            TollFree = ""
        End Try
        Try
            Email = CStr(EmailCommand.ExecuteScalar)
        Catch ex As Exception
            Email = ""
        End Try
        Try
            AccountNumber = CStr(AccountNumberCommand.ExecuteScalar)
        Catch ex As Exception
            AccountNumber = ""
        End Try
        Try
            RoutingNumber = CStr(RoutingNumberCommand.ExecuteScalar)
        Catch ex As Exception
            RoutingNumber = ""
        End Try
        Try
            AccountNumberCanadian = CStr(AccountNumberCanadianCommand.ExecuteScalar)
        Catch ex As Exception
            AccountNumberCanadian = ""
        End Try
        Try
            Institution = CStr(InstitutionCommand.ExecuteScalar)
        Catch ex As Exception
            Institution = ""
        End Try
        Try
            TransitNumber = CStr(TransitNumberCommand.ExecuteScalar)
        Catch ex As Exception
            TransitNumber = ""
        End Try
        Try
            AccountNumberPrefix = CStr(AccountNumberPrefixCommand.ExecuteScalar)
        Catch ex As Exception
            AccountNumberPrefix = ""
        End Try
        Try
            DivisionClass = CStr(DivisionClassCommand.ExecuteScalar)
        Catch ex As Exception
            DivisionClass = ""
        End Try
        Try
            EIN = CStr(EINCommand.ExecuteScalar)
        Catch ex As Exception
            EIN = ""
        End Try
        con.Close()

        txtCompanyDescription.Text = CompanyDescription
        txtCompanyName.Text = DivisionName
        txtAddress1.Text = Address1
        txtAddress2.Text = Address2
        txtCity.Text = City
        cboState.Text = State
        txtZip.Text = ZipCode
        txtCountry.Text = Country
        txtPhone.Text = Phone
        txtTollFree.Text = TollFree
        txtFax.Text = Fax
        txtEmail.Text = Email
        txtAccountNumber.Text = AccountNumber
        txtRoutingNumber.Text = RoutingNumber
        txtCanadianAccount.Text = AccountNumberCanadian
        txtInstitution.Text = Institution
        txtTransitNumber.Text = TransitNumber
        txtPrefix.Text = AccountNumberPrefix
        cboDivisionClass.Text = DivisionClass
        txtEIN.Text = EIN
    End Sub

    Private Sub ClearData()
        txtCompanyName.Clear()
        txtCompanyDescription.Clear()
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtCity.Clear()

        cboState.SelectedIndex = -1
        cboDivisionClass.SelectedIndex = -1

        txtZip.Clear()
        txtCountry.Clear()
        txtPhone.Clear()
        txtTollFree.Clear()
        txtFax.Clear()
        txtEmail.Clear()
        txtAccountNumber.Clear()
        txtRoutingNumber.Clear()
        txtCanadianAccount.Clear()
        txtInstitution.Clear()
        txtTransitNumber.Clear()
        txtPrefix.Clear()
        txtEIN.Clear()
        cboDivisionID.Focus()
    End Sub

    Public Sub ClearVariables()
        DivisionName = ""
        CompanyDescription = ""
        Address1 = ""
        Address2 = ""
        City = ""
        State = ""
        ZipCode = ""
        Country = ""
        Phone = ""
        Fax = ""
        TollFree = ""
        Email = ""
        AccountNumber = ""
        RoutingNumber = ""
        MicrHeader = ""
        AccountNumberCanadian = ""
        AccountNumberPrefix = ""
        Institution = ""
        TransitNumber = ""
        DivisionClass = ""
        EIN = ""
    End Sub

    Private Sub SaveCompanyData()
        If cboDivisionID.Text = "" Then
            MsgBox("You must have a valid Company Division selected.", MsgBoxStyle.OkOnly)
        Else
            Dim CheckDivisionClass As String = cboDivisionClass.Text

            If CheckDivisionClass = "AMERICAN" Or CheckDivisionClass = "CANADIAN" Then
                'Do nothing
            Else
                MsgBox("You must select AMERICAN or CANADIAN.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            Try
                cmd = New SqlCommand("Insert Into DivisionTable (DivisionKey, DivisionDescription, CompanyName, DivisionClass, Address1, Address2, City, State,  ZipCode, Country, Phone, Fax, TollFree, Email, AccountNumber, RoutingNumber, MicrHeader, AccountNumberPrefix, AccountNumberCanadian, TransitNumber, Institution, EIN)values(@DivisionKey, @DivisionDescription, @CompanyName, @DivisionClass, @Address1, @Address2, @City, @State, @ZipCode, @Country, @Phone, @Fax, @TollFree, @Email, @AccountNumber, @RoutingNumber, @MicrHeader, @AccountNumberPrefix, @AccountNumberCanadian, @TransitNumber, @Institution, @EIN)", con)

                With cmd.Parameters
                    .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@DivisionDescription", SqlDbType.VarChar).Value = txtCompanyDescription.Text
                    .Add("@CompanyName", SqlDbType.VarChar).Value = txtCompanyName.Text
                    .Add("@DivisionClass", SqlDbType.VarChar).Value = cboDivisionClass.Text
                    .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
                    .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
                    .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
                    .Add("@State", SqlDbType.VarChar).Value = cboState.Text
                    .Add("@ZipCode", SqlDbType.VarChar).Value = txtZip.Text
                    .Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text
                    .Add("@Phone", SqlDbType.VarChar).Value = txtPhone.Text
                    .Add("@Fax", SqlDbType.VarChar).Value = txtFax.Text
                    .Add("@TollFree", SqlDbType.VarChar).Value = txtTollFree.Text
                    .Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text
                    .Add("@AccountNumber", SqlDbType.VarChar).Value = txtAccountNumber.Text
                    .Add("@RoutingNumber", SqlDbType.VarChar).Value = txtRoutingNumber.Text
                    .Add("@MicrHeader", SqlDbType.VarChar).Value = ""
                    .Add("@AccountNumberPrefix", SqlDbType.VarChar).Value = txtPrefix.Text
                    .Add("@AccountNumberCanadian", SqlDbType.VarChar).Value = txtCanadianAccount.Text
                    .Add("@TransitNumber", SqlDbType.VarChar).Value = txtTransitNumber.Text
                    .Add("@Institution", SqlDbType.VarChar).Value = txtInstitution.Text
                    .Add("@EIN", SqlDbType.VarChar).Value = txtEIN.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Company data has been added.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                cmd = New SqlCommand("UPDATE DivisionTable SET DivisionDescription = @DivisionDescription, CompanyName = @CompanyName, DivisionClass = @DivisionClass, Address1 = @Address1, Address2 = @Address2, City = @City,  State = @State, ZipCode = @ZipCode, Country = @Country, Phone = @Phone, Fax = @Fax, TollFree = @TollFree, Email = @Email, AccountNumber = @AccountNumber, RoutingNumber = @RoutingNumber, MicrHeader = @MicrHeader, AccountNumberPrefix = @AccountNumberPrefix, AccountNumberCanadian = @AccountNumberCanadian, TransitNumber = @TransitNumber, Institution = @Institution, EIN = @EIN WHERE DivisionKey = @DivisionKey", con)

                With cmd.Parameters
                    .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@DivisionDescription", SqlDbType.VarChar).Value = txtCompanyDescription.Text
                    .Add("@CompanyName", SqlDbType.VarChar).Value = txtCompanyName.Text
                    .Add("@DivisionClass", SqlDbType.VarChar).Value = cboDivisionClass.Text
                    .Add("@Address1", SqlDbType.VarChar).Value = txtAddress1.Text
                    .Add("@Address2", SqlDbType.VarChar).Value = txtAddress2.Text
                    .Add("@City", SqlDbType.VarChar).Value = txtCity.Text
                    .Add("@State", SqlDbType.VarChar).Value = cboState.Text
                    .Add("@ZipCode", SqlDbType.VarChar).Value = txtZip.Text
                    .Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text
                    .Add("@Phone", SqlDbType.VarChar).Value = txtPhone.Text
                    .Add("@Fax", SqlDbType.VarChar).Value = txtFax.Text
                    .Add("@TollFree", SqlDbType.VarChar).Value = txtTollFree.Text
                    .Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text
                    .Add("@AccountNumber", SqlDbType.VarChar).Value = txtAccountNumber.Text
                    .Add("@RoutingNumber", SqlDbType.VarChar).Value = txtRoutingNumber.Text
                    .Add("@MicrHeader", SqlDbType.VarChar).Value = ""
                    .Add("@AccountNumberPrefix", SqlDbType.VarChar).Value = txtPrefix.Text
                    .Add("@AccountNumberCanadian", SqlDbType.VarChar).Value = txtCanadianAccount.Text
                    .Add("@TransitNumber", SqlDbType.VarChar).Value = txtTransitNumber.Text
                    .Add("@Institution", SqlDbType.VarChar).Value = txtInstitution.Text
                    .Add("@EIN", SqlDbType.VarChar).Value = txtEIN.Text
                End With
                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Company data has been saved.", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveCompanyData()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveCompanyData()
    End Sub

    Private Sub cmdOpenDatabaseUtilities_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenDatabaseUtilities.Click
        Dim NewDatabaseUtilities As New DatabaseUtilities
        NewDatabaseUtilities.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSecurityManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSecurityManagement.Click
        Dim newSecurityManagement As New SecurityManagement
        newSecurityManagement.Show()
    End Sub
End Class