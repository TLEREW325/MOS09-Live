Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class ViewVendorListing
    Inherits System.Windows.Forms.Form

    Dim BeginsWithFilter, VendorFilter, StateFilter, TextFilter, ContactFilter, ClassFilter As String
    Dim Checked1099 As String = ""
    Dim VendorName As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewVendorListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)

        LoadCurrentDivision()

        LoadVendor()
        LoadVendorClass()
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        'Load Security for AP Check/ACH data
        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Or EmployeeSecurityCode = 1003 Then
            Me.dgvVendorList.Columns("VendorAccountNumberColumn").Visible = True
            Me.dgvVendorList.Columns("VendorRoutingNumberColumn").Visible = True
            Me.dgvVendorList.Columns("VendorAccountTypeColumn").Visible = True
        Else
            Me.dgvVendorList.Columns("VendorAccountNumberColumn").Visible = False
            Me.dgvVendorList.Columns("VendorRoutingNumberColumn").Visible = False
            Me.dgvVendorList.Columns("VendorAccountTypeColumn").Visible = False
        End If

        AutoScaleMode = Windows.Forms.AutoScaleMode.Font
        Dim CTRL As Control
        For Each CTRL In Me.Controls
            AutoSize = True
            AutoSizeMode = Windows.Forms.AutoSizeMode.GrowOnly
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

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadVendor()
        LoadVendorClass()
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvVendorList.DataSource = Nothing
    End Sub

    Public Sub ShowAllVendorsByAllDivisions()
        cmd = New SqlCommand("SELECT * FROM Vendor WHERE DivisionID <> @DivisionID ORDER BY DivisionID, VendorCode", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "Vendor")
        dgvVendorList.DataSource = ds.Tables("Vendor")
        con.Close()
    End Sub

    Public Sub LoadVendor()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT VendorCode FROM Vendor WHERE DivisionID <> @DivisionID ORDER BY VendorCode", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmd
            myAdapter1.Fill(ds1, "Vendor")
            cboVendorID.DataSource = ds1.Tables("Vendor")
            con.Close()
            cboVendorID.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID ORDER BY VendorCode", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmd
            myAdapter1.Fill(ds1, "Vendor")
            cboVendorID.DataSource = ds1.Tables("Vendor")
            con.Close()
            cboVendorID.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadVendorClass()
        Dim ClassMode As String

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            ClassMode = "CANADIAN"
        Else
            ClassMode = "STANDARD"
        End If

        cmd = New SqlCommand("SELECT VendClassID FROM VendorClass WHERE ClassMode = @ClassMode", con)
        cmd.Parameters.Add("@ClassMode", SqlDbType.VarChar).Value = ClassMode
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "VendorClass")
        cboVendorClass.DataSource = ds2.Tables("VendorClass")
        con.Close()
        cboVendorClass.SelectedIndex = -1
    End Sub

    Public Sub ShowByVendorByFilters()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorCode = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If txtContactName.Text <> "" Then
            ContactFilter = " AND ContactName LIKE '%" + txtContactName.Text + "%'"
        Else
            ContactFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (VendorCode LIKE '%" + txtTextFilter.Text + "%' OR VendorName LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If cboVendorClass.Text <> "" Then
            ClassFilter = " AND VendorClass = '" + cboVendorClass.Text + "'"
        Else
            ClassFilter = ""
        End If
        If cboVendorState.Text <> "" Then
            StateFilter = " AND VendorState = '" + cboVendorState.Text + "'"
        Else
            StateFilter = ""
        End If
        If txtBeginsWith.Text <> "" Then
            BeginsWithFilter = " AND VendorCode LIKE '" + txtBeginsWith.Text + "%'"
        Else
            BeginsWithFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM Vendor WHERE DivisionID <> @DivisionID" + TextFilter + VendorFilter + ClassFilter + StateFilter + ContactFilter + BeginsWithFilter + " ORDER BY VendorCode", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "Vendor")
            dgvVendorList.DataSource = ds.Tables("Vendor")
            con.Close()

            Me.dgvVendorList.Columns("DivisionIDColumn").Visible = True
            Me.dgvVendorList.Columns("VendorCodeColumn").Frozen = True
        Else
            cmd = New SqlCommand("SELECT * FROM Vendor WHERE DivisionID = @DivisionID" + TextFilter + VendorFilter + ClassFilter + StateFilter + ContactFilter + BeginsWithFilter + " ORDER BY VendorCode", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "Vendor")
            dgvVendorList.DataSource = ds.Tables("Vendor")
            con.Close()

            Me.dgvVendorList.Columns("DivisionIDColumn").Visible = False
            Me.dgvVendorList.Columns("VendorCodeColumn").Frozen = True
        End If
    End Sub

    Public Sub LoadVendorName()
        Dim VendorNameString As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameString, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorName = ""
        End Try
        con.Close()

        txtVendorName.Text = VendorName
    End Sub

    Public Sub ClearData()
        cboVendorClass.Text = ""
        cboVendorID.Text = ""
        cboVendorState.Text = ""

        cboVendorClass.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboVendorState.SelectedIndex = -1

        txtContactName.Clear()
        txtTextFilter.Clear()
        txtVendorName.Clear()
        txtBeginsWith.Clear()

        dgvVendorList.Columns("DivisionIDColumn").Visible = False

        cboVendorID.Focus()
    End Sub

    Public Sub ClearVariables()
        VendorFilter = ""
        StateFilter = ""
        TextFilter = ""
        ContactFilter = ""
        ClassFilter = ""
        VendorName = ""
        BeginsWithFilter = ""
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Private Sub cmdOpenVendorForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenVendorForm.Click
        Dim RowVendorID As String = ""
        Dim RowVendorName As String = ""

        If Me.dgvVendorList.RowCount > 0 Then
            Dim RowIndex As Integer = Me.dgvVendorList.CurrentCell.RowIndex

            Try
                RowVendorID = Me.dgvVendorList.Rows(RowIndex).Cells("VendorCodeColumn").Value
            Catch ex As Exception
                RowVendorID = ""
            End Try
            Try
                RowVendorName = Me.dgvVendorList.Rows(RowIndex).Cells("VendorNameColumn").Value
            Catch ex As Exception
                RowVendorName = ""
            End Try
        End If

        GlobalVendorID = RowVendorID
        GlobalVendorName = RowVendorName

        Dim NewVendorInformation As New VendorInformation
        NewVendorInformation.Show()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        dgvVendorList.Columns("DivisionIDColumn").Visible = False
        ShowByVendorByFilters()
    End Sub

    Private Sub cmdViewAllVendors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAllVendors.Click
        dgvVendorList.Columns("DivisionIDColumn").Visible = True
        ShowAllVendorsByAllDivisions()
    End Sub

    Private Sub cmdCreateVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateVendor.Click
        Dim ApprovalCriteria, ApprovedBy, DefaultGLAccount, DefaultItem, ApprovalDate, ISOCompliant, VendorEmail, VendorClass, VendorPreferredShipper, VendorComment, VendorTaxID, ContactName, PaymentTerms, VendorName, VendorAddress1, VendorAddress2, VendorCity, VendorState, VendorZip, VendorCountry, VendorPhone, VendorFax As String
        Dim CreditLimit As Double
        Dim VendorRoutingNumber, VendorAccountType, Prop65Compliant, WhitePaperCheck, RemittanceEmail, CheckCode, VendorAccountNumber As String
        Dim ACHContactName, ACHContactNumber, ACHContactEmail, ACHVerifyDate As String

        Dim RowVendorID As String
        Dim RowDivision As String

        Dim button As DialogResult = MessageBox.Show("Do you wish to create a new Vendor?", "CREATE VENDOR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            Dim RowIndex As Integer = Me.dgvVendorList.CurrentCell.RowIndex

            Try
                RowVendorID = Me.dgvVendorList.Rows(RowIndex).Cells("VendorCodeColumn").Value
            Catch ex As Exception
                RowVendorID = ""
            End Try
            Try
                RowDivision = Me.dgvVendorList.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try

            If RowVendorID = "" Or RowDivision = "" Then
                MsgBox("New Vendor could not be created. It may already exist in the database.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
                VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim ContactNameStatement As String = "SELECT ContactName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim ContactNameCommand As New SqlCommand(ContactNameStatement, con)
                ContactNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                ContactNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorAddress1Statement As String = "SELECT VendorAddress1 FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorAddress1Command As New SqlCommand(VendorAddress1Statement, con)
                VendorAddress1Command.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorAddress2Statement As String = "SELECT VendorAddress2 FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorAddress2Command As New SqlCommand(VendorAddress2Statement, con)
                VendorAddress2Command.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorCityStatement As String = "SELECT VendorCity FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorCityCommand As New SqlCommand(VendorCityStatement, con)
                VendorCityCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorStateStatement As String = "SELECT VendorState FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorStateCommand As New SqlCommand(VendorStateStatement, con)
                VendorStateCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorZipStatement As String = "SELECT VendorZip FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorZipCommand As New SqlCommand(VendorZipStatement, con)
                VendorZipCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorCountryStatement As String = "SELECT VendorCountry FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorCountryCommand As New SqlCommand(VendorCountryStatement, con)
                VendorCountryCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorCountryCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorPhoneStatement As String = "SELECT VendorPhone FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorPhoneCommand As New SqlCommand(VendorPhoneStatement, con)
                VendorPhoneCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorPhoneCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorFaxStatement As String = "SELECT VendorFax FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorFaxCommand As New SqlCommand(VendorFaxStatement, con)
                VendorFaxCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorFaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorEmailStatement As String = "SELECT VendorEmail FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorEmailCommand As New SqlCommand(VendorEmailStatement, con)
                VendorEmailCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
                PaymentTermsCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
                VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorCommentStatement As String = "SELECT VendorComment FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorCommentCommand As New SqlCommand(VendorCommentStatement, con)
                VendorCommentCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorCommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorTaxIDStatement As String = "SELECT VendorTaxID FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorTaxIDCommand As New SqlCommand(VendorTaxIDStatement, con)
                VendorTaxIDCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorTaxIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorPreferredShipperStatement As String = "SELECT VendorPreferredShipping FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorPreferredShipperCommand As New SqlCommand(VendorPreferredShipperStatement, con)
                VendorPreferredShipperCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorPreferredShipperCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim CreditLimitStatement As String = "SELECT CreditLimit FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CreditLimitCommand As New SqlCommand(CreditLimitStatement, con)
                CreditLimitCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                CreditLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim DefaultGLAccountStatement As String = "SELECT DefaultGLAccount FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim DefaultGLAccountCommand As New SqlCommand(DefaultGLAccountStatement, con)
                DefaultGLAccountCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                DefaultGLAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim DefaultItemStatement As String = "SELECT DefaultItem FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim DefaultItemCommand As New SqlCommand(DefaultItemStatement, con)
                DefaultItemCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                DefaultItemCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim ApprovedByStatement As String = "SELECT ApprovedBy FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim ApprovedByCommand As New SqlCommand(ApprovedByStatement, con)
                ApprovedByCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                ApprovedByCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim ApprovalCriteriaStatement As String = "SELECT ApprovalCriteria FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim ApprovalCriteriaCommand As New SqlCommand(ApprovalCriteriaStatement, con)
                ApprovalCriteriaCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                ApprovalCriteriaCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim ApprovalDateStatement As String = "SELECT ApprovalDate FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim ApprovalDateCommand As New SqlCommand(ApprovalDateStatement, con)
                ApprovalDateCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                ApprovalDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim ISOCompliantStatement As String = "SELECT ISOCompliant FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim ISOCompliantCommand As New SqlCommand(ISOCompliantStatement, con)
                ISOCompliantCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                ISOCompliantCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim Prop65CompliantStatement As String = "SELECT Prop65Compliant FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim Prop65CompliantCommand As New SqlCommand(Prop65CompliantStatement, con)
                Prop65CompliantCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                Prop65CompliantCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim WhitePaperCheckStatement As String = "SELECT WhitePaperCheck FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim WhitePaperCheckCommand As New SqlCommand(WhitePaperCheckStatement, con)
                WhitePaperCheckCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                WhitePaperCheckCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim RemittanceEmailStatement As String = "SELECT RemittanceEmail FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim RemittanceEmailCommand As New SqlCommand(RemittanceEmailStatement, con)
                RemittanceEmailCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                RemittanceEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim CheckCodeStatement As String = "SELECT CheckCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim CheckCodeCommand As New SqlCommand(CheckCodeStatement, con)
                CheckCodeCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                CheckCodeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorAccountNumberStatement As String = "SELECT VendorAccountNumber FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorAccountNumberCommand As New SqlCommand(VendorAccountNumberStatement, con)
                VendorAccountNumberCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorAccountNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorRoutingNumberStatement As String = "SELECT VendorRoutingNumber FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorRoutingNumberCommand As New SqlCommand(VendorRoutingNumberStatement, con)
                VendorRoutingNumberCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorRoutingNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim VendorAccountTypeStatement As String = "SELECT VendorAccountType FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorAccountTypeCommand As New SqlCommand(VendorAccountTypeStatement, con)
                VendorAccountTypeCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                VendorAccountTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim ACHContactNameStatement As String = "SELECT ACHContactName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim ACHContactNameCommand As New SqlCommand(ACHContactNameStatement, con)
                ACHContactNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                ACHContactNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim ACHContactNumberStatement As String = "SELECT ACHContactNumber FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim ACHContactNumberCommand As New SqlCommand(ACHContactNumberStatement, con)
                ACHContactNumberCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                ACHContactNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim ACHContactEmailStatement As String = "SELECT ACHContactEmail FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim ACHContactEmailCommand As New SqlCommand(ACHContactEmailStatement, con)
                ACHContactEmailCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                ACHContactEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                Dim ACHVerifyDateStatement As String = "SELECT ACHVerifyDate FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim ACHVerifyDateCommand As New SqlCommand(ACHVerifyDateStatement, con)
                ACHVerifyDateCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                ACHVerifyDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    VendorName = CStr(VendorNameCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorName = ""
                End Try
                Try
                    ContactName = CStr(ContactNameCommand.ExecuteScalar)
                Catch ex As Exception
                    ContactName = ""
                End Try
                Try
                    VendorAddress1 = CStr(VendorAddress1Command.ExecuteScalar)
                Catch ex As Exception
                    VendorAddress1 = ""
                End Try
                Try
                    VendorAddress2 = CStr(VendorAddress2Command.ExecuteScalar)
                Catch ex As Exception
                    VendorAddress2 = ""
                End Try
                Try
                    VendorCity = CStr(VendorCityCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorCity = ""
                End Try
                Try
                    VendorState = CStr(VendorStateCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorState = ""
                End Try
                Try
                    VendorZip = CStr(VendorZipCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorZip = ""
                End Try
                Try
                    VendorCountry = CStr(VendorCountryCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorCountry = ""
                End Try
                Try
                    VendorPhone = CStr(VendorPhoneCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorPhone = ""
                End Try
                Try
                    VendorFax = CStr(VendorFaxCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorFax = ""
                End Try
                Try
                    VendorEmail = CStr(VendorEmailCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorEmail = ""
                End Try
                Try
                    PaymentTerms = CStr(PaymentTermsCommand.ExecuteScalar)
                Catch ex As Exception
                    PaymentTerms = "N60"
                End Try
                Try
                    VendorClass = CStr(VendorClassCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorClass = ""
                End Try
                Try
                    VendorComment = CStr(VendorCommentCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorComment = ""
                End Try
                Try
                    VendorTaxID = CStr(VendorTaxIDCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorTaxID = ""
                End Try
                Try
                    VendorPreferredShipper = CStr(VendorPreferredShipperCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorPreferredShipper = "Delivery"
                End Try
                Try
                    CreditLimit = CDbl(CreditLimitCommand.ExecuteScalar)
                Catch ex As Exception
                    CreditLimit = 0
                End Try
                Try
                    DefaultGLAccount = CStr(DefaultGLAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    DefaultGLAccount = ""
                End Try
                Try
                    DefaultItem = CStr(DefaultItemCommand.ExecuteScalar)
                Catch ex As Exception
                    DefaultItem = ""
                End Try
                Try
                    ApprovedBy = CStr(ApprovedByCommand.ExecuteScalar)
                Catch ex As Exception
                    ApprovedBy = ""
                End Try
                Try
                    ApprovalCriteria = CStr(ApprovalCriteriaCommand.ExecuteScalar)
                Catch ex As Exception
                    ApprovalCriteria = ""
                End Try
                Try
                    ApprovalDate = CDate(ApprovalDateCommand.ExecuteScalar)
                Catch ex As Exception
                    ApprovalDate = ""
                End Try
                Try
                    ISOCompliant = CStr(ISOCompliantCommand.ExecuteScalar)
                Catch ex As Exception
                    ISOCompliant = "NO"
                End Try
                Try
                    Prop65Compliant = CStr(Prop65CompliantCommand.ExecuteScalar)
                Catch ex As Exception
                    Prop65Compliant = "NO"
                End Try
                Try
                    WhitePaperCheck = CStr(WhitePaperCheckCommand.ExecuteScalar)
                Catch ex As Exception
                    WhitePaperCheck = "NO"
                End Try
                Try
                    RemittanceEmail = CStr(RemittanceEmailCommand.ExecuteScalar)
                Catch ex As Exception
                    RemittanceEmail = ""
                End Try
                Try
                    CheckCode = CStr(CheckCodeCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckCode = "STANDARD"
                End Try
                Try
                    VendorAccountNumber = CStr(VendorAccountNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorAccountNumber = ""
                End Try
                Try
                    VendorRoutingNumber = CStr(VendorRoutingNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorRoutingNumber = ""
                End Try
                Try
                    VendorAccountType = CStr(VendorAccountTypeCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorAccountType = ""
                End Try
                Try
                    ACHContactName = CStr(ACHContactNameCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHContactName = ""
                End Try
                Try
                    ACHContactNumber = CStr(ACHContactNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHContactNumber = ""
                End Try
                Try
                    ACHContactEmail = CStr(ACHContactEmailCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHContactEmail = ""
                End Try
                Try
                    ACHVerifyDate = CStr(ACHVerifyDateCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHVerifyDate = ""
                End Try
                con.Close()

                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    Dim button1 As DialogResult = MessageBox.Show("Is the Vendor Canadian?", "VENDOR TYPE", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    If button1 = DialogResult.Yes Then
                        VendorClass = "CANADIAN"
                    ElseIf button1 = DialogResult.No Then
                        VendorClass = "AMERICAN"
                    End If
                Else
                    'Do nothing - Vendor Class is correct
                End If

                'Add to database
                Try
                    cmd = New SqlCommand("INSERT INTO Vendor (VendorCode, DivisionID, VendorName, ContactName, VendorAddress1, VendorAddress2, VendorCity, VendorState, VendorZip, VendorCountry, VendorPhone, VendorFax, VendorEmail, PaymentTerms, VendorClass, VendorDate, VendorComment, VendorTaxID, VendorPreferredShipping, CreditLimit, DefaultGLAccount, DefaultItem, ApprovedBy, ApprovalCriteria, ApprovalDate, ISOCompliant, Prop65Compliant, WhitePaperCheck, RemittanceEmail, CheckCode, VendorAccountNumber, VendorRoutingNumber, VendorAccountType, ACHContactName, ACHContactNumber, ACHContactEmail, ACHVerifyDate) Values (@VendorCode, @DivisionID, @VendorName, @ContactName, @VendorAddress1, @VendorAddress2, @VendorCity, @VendorState, @VendorZip, @VendorCountry, @VendorPhone, @VendorFax, @VendorEmail, @PaymentTerms, @VendorClass, @VendorDate, @VendorComment, @VendorTaxID, @VendorPreferredShipping, @CreditLimit, @DefaultGLAccount, @DefaultItem, @ApprovedBy, @ApprovalCriteria, @ApprovalDate, @ISOCompliant, @Prop65Compliant, @WhitePaperCheck, @RemittanceEmail, @CheckCode, @VendorAccountNumber, @VendorRoutingNumber, @VendorAccountType, @ACHContactName, @ACHContactNumber, @ACHContactEmail, @ACHVerifyDate)", con)

                    With cmd.Parameters
                        .Add("@VendorCode", SqlDbType.VarChar).Value = RowVendorID
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@VendorName", SqlDbType.VarChar).Value = VendorName
                        .Add("@ContactName", SqlDbType.VarChar).Value = ContactName
                        .Add("@VendorAddress1", SqlDbType.VarChar).Value = VendorAddress1
                        .Add("@VendorAddress2", SqlDbType.VarChar).Value = VendorAddress2
                        .Add("@VendorCity", SqlDbType.VarChar).Value = VendorCity
                        .Add("@VendorState", SqlDbType.VarChar).Value = VendorState
                        .Add("@VendorZip", SqlDbType.VarChar).Value = VendorZip
                        .Add("@VendorCountry", SqlDbType.VarChar).Value = VendorCountry
                        .Add("@VendorPhone", SqlDbType.VarChar).Value = VendorPhone
                        .Add("@VendorFax", SqlDbType.VarChar).Value = VendorFax
                        .Add("@VendorEmail", SqlDbType.VarChar).Value = VendorEmail
                        .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
                        .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
                        .Add("@VendorDate", SqlDbType.VarChar).Value = Today()
                        .Add("@VendorComment", SqlDbType.VarChar).Value = VendorComment
                        .Add("@VendorTaxID", SqlDbType.VarChar).Value = VendorTaxID
                        .Add("@VendorPreferredShipping", SqlDbType.VarChar).Value = VendorPreferredShipper
                        .Add("@CreditLimit", SqlDbType.VarChar).Value = CreditLimit
                        .Add("@DefaultGLAccount", SqlDbType.VarChar).Value = DefaultGLAccount
                        .Add("@DefaultItem", SqlDbType.VarChar).Value = DefaultItem
                        .Add("@ApprovedBy", SqlDbType.VarChar).Value = ApprovedBy
                        .Add("@ApprovalCriteria", SqlDbType.VarChar).Value = ApprovalCriteria
                        .Add("@ApprovalDate", SqlDbType.VarChar).Value = ApprovalDate
                        .Add("@ISOCompliant", SqlDbType.VarChar).Value = ISOCompliant
                        .Add("@Prop65Compliant", SqlDbType.VarChar).Value = Prop65Compliant
                        .Add("@WhitePaperCheck", SqlDbType.VarChar).Value = WhitePaperCheck
                        .Add("@RemittanceEmail", SqlDbType.VarChar).Value = RemittanceEmail
                        .Add("@CheckCode", SqlDbType.VarChar).Value = CheckCode
                        .Add("@VendorAccountNumber", SqlDbType.VarChar).Value = VendorAccountNumber
                        .Add("@VendorRoutingNumber", SqlDbType.VarChar).Value = VendorRoutingNumber
                        .Add("@VendorAccountType", SqlDbType.VarChar).Value = VendorAccountType
                        .Add("@ACHContactName", SqlDbType.VarChar).Value = ACHContactName
                        .Add("@ACHContactNumber", SqlDbType.VarChar).Value = ACHContactNumber
                        .Add("@ACHContactEmail", SqlDbType.VarChar).Value = ACHContactEmail
                        .Add("@ACHVerifyDate", SqlDbType.VarChar).Value = ACHVerifyDate
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    MsgBox("Vendor created.", MsgBoxStyle.OkOnly)
                Catch ex As Exception
                    MsgBox("New Vendor could not be created. It may already exist in the database.", MsgBoxStyle.OkOnly)
                End Try
            End If
        ElseIf button = DialogResult.No Then
            'Do nothing
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdClearAllVendors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAllVendors.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintVendorList As New PrintVendorList
            Dim result = NewPrintVendorList.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintVendorList As New PrintVendorList
            Dim result = NewPrintVendorList.ShowDialog()
        End Using
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

    Private Sub dgvVendorList_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVendorList.CellValueChanged
        If dgvVendorList.RowCount = 0 Then
            'Skip
        Else
            Dim RemittanceEmail, Prop65Compliant, VendorID, VendorName, ContactName, Address1, Address2, City, State, Zip, Country, Phone, Fax, Email, PaymentTerms, Comment, Shipper As String
            Dim CreditLimit As Double

            Dim RowIndex As Integer = Me.dgvVendorList.CurrentCell.RowIndex

            Try
                VendorID = Me.dgvVendorList.Rows(RowIndex).Cells("VendorCodeColumn").Value
            Catch ex As Exception
                VendorID = ""
            End Try
            Try
                VendorName = Me.dgvVendorList.Rows(RowIndex).Cells("VendorNameColumn").Value
            Catch ex As Exception
                VendorName = ""
            End Try
            Try
                ContactName = Me.dgvVendorList.Rows(RowIndex).Cells("ContactNameColumn").Value
            Catch ex As Exception
                ContactName = ""
            End Try
            Try
                Address1 = Me.dgvVendorList.Rows(RowIndex).Cells("VendorAddress1Column").Value
            Catch ex As Exception
                Address1 = ""
            End Try
            Try
                Address2 = Me.dgvVendorList.Rows(RowIndex).Cells("VendorAddress2Column").Value
            Catch ex As Exception
                Address2 = ""
            End Try
            Try
                City = Me.dgvVendorList.Rows(RowIndex).Cells("VendorCityColumn").Value
            Catch ex As Exception
                City = ""
            End Try
            Try
                State = Me.dgvVendorList.Rows(RowIndex).Cells("VendorStateColumn").Value
            Catch ex As Exception
                State = ""
            End Try
            Try
                Zip = Me.dgvVendorList.Rows(RowIndex).Cells("VendorZipColumn").Value
            Catch ex As Exception
                Zip = ""
            End Try
            Try
                Country = Me.dgvVendorList.Rows(RowIndex).Cells("VendorCountryColumn").Value
            Catch ex As Exception
                Country = ""
            End Try
            Try
                Phone = Me.dgvVendorList.Rows(RowIndex).Cells("VendorPhoneColumn").Value
            Catch ex As Exception
                Phone = ""
            End Try
            Try
                Fax = Me.dgvVendorList.Rows(RowIndex).Cells("VendorFaxColumn").Value
            Catch ex As Exception
                Fax = ""
            End Try
            Try
                Email = Me.dgvVendorList.Rows(RowIndex).Cells("VendorEmailColumn").Value
            Catch ex As Exception
                Email = ""
            End Try
            Try
                RemittanceEmail = Me.dgvVendorList.Rows(RowIndex).Cells("RemittanceEmailColumn").Value
            Catch ex As Exception
                RemittanceEmail = ""
            End Try
            Try
                PaymentTerms = Me.dgvVendorList.Rows(RowIndex).Cells("PaymentTermsColumn").Value
            Catch ex As Exception
                PaymentTerms = "N30"
            End Try
            Try
                Comment = Me.dgvVendorList.Rows(RowIndex).Cells("VendorCommentColumn").Value
            Catch ex As Exception
                Comment = ""
            End Try
            Try
                Shipper = Me.dgvVendorList.Rows(RowIndex).Cells("VendorPreferredShippingColumn").Value
            Catch ex As Exception
                Shipper = ""
            End Try
            Try
                CreditLimit = Me.dgvVendorList.Rows(RowIndex).Cells("CreditLimitColumn").Value
            Catch ex As Exception
                CreditLimit = 0
            End Try
            Try
                Prop65Compliant = Me.dgvVendorList.Rows(RowIndex).Cells("Prop65CompliantColumn").Value
            Catch ex As Exception
                Prop65Compliant = "NO"
            End Try
            Try
                Checked1099 = Me.dgvVendorList.Rows(RowIndex).Cells("Checked1099Column").Value
            Catch ex As Exception
                Checked1099 = "NO"
            End Try

            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE Vendor SET VendorName = @VendorName, ContactName = @ContactName, VendorAddress1 = @VendorAddress1, VendorAddress2 = @VendorAddress2, VendorCity = @VendorCity, VendorState = @VendorState, VendorZip = @VendorZip, VendorCountry = @VendorCountry, VendorPhone = @VendorPhone, VendorFax = @VendorFax, VendorEmail = @VendorEmail, PaymentTerms = @PaymentTerms, VendorComment = @VendorComment, VendorPreferredShipping = @VendorPreferredShipping, CreditLimit = @CreditLimit, Prop65Compliant = @Prop65Compliant, RemittanceEmail = @RemittanceEmail, Checked1099 = @Checked1099 WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VendorCode", SqlDbType.VarChar).Value = VendorID
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@VendorName", SqlDbType.VarChar).Value = VendorName
                    .Add("@ContactName", SqlDbType.VarChar).Value = ContactName
                    .Add("@VendorAddress1", SqlDbType.VarChar).Value = Address1
                    .Add("@VendorAddress2", SqlDbType.VarChar).Value = Address2
                    .Add("@VendorCity", SqlDbType.VarChar).Value = City
                    .Add("@VendorState", SqlDbType.VarChar).Value = State
                    .Add("@VendorZip", SqlDbType.VarChar).Value = Zip
                    .Add("@VendorCountry", SqlDbType.VarChar).Value = Country
                    .Add("@VendorPhone", SqlDbType.VarChar).Value = Phone
                    .Add("@VendorFax", SqlDbType.VarChar).Value = Fax
                    .Add("@VendorEmail", SqlDbType.VarChar).Value = Email
                    .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
                    .Add("@VendorComment", SqlDbType.VarChar).Value = Comment
                    .Add("@VendorPreferredShipping", SqlDbType.VarChar).Value = Shipper
                    .Add("@CreditLimit", SqlDbType.VarChar).Value = CreditLimit
                    .Add("@Prop65Compliant", SqlDbType.VarChar).Value = Prop65Compliant
                    .Add("@RemittanceEmail", SqlDbType.VarChar).Value = RemittanceEmail
                    .Add("@Checked1099", SqlDbType.VarChar).Value = Checked1099
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log

            End Try
        End If
    End Sub
End Class