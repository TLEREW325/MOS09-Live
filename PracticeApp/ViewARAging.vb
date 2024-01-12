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
Public Class ViewARAging
    Inherits System.Windows.Forms.Form

    Dim CustomerClass As String
    Dim ALLStatement, Statement30, Statement45, Statement60, Statement90, SQLStatement As String
    Dim CustomerFilter, DateFilter, InvoiceFilter, ClassFilter, TerritoryFilter, PaymentTermsFilter As String
    Dim InvoiceNumber As Integer = 0
    Dim strInvoiceNumber As String = ""
    Dim BeginDate, EndDate As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewARAging_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

        LoadCurrentDivision()
        LoadPaymentTerms()
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
        'Load canadian defaults
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            rdoAmerican.Enabled = True
            rdoCanadian.Enabled = True
        Else
            rdoAmerican.Enabled = False
            rdoCanadian.Enabled = False
        End If

        LoadInvoiceNumber()
        LoadSalesTerritory()
        LoadCustomerID()
        LoadCustomerName()
        ClearData()
    End Sub

    Private Sub dgvARAging_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvARAging.CellDoubleClick
        If Me.dgvARAging.RowCount <> 0 Then
            Dim RowCustomer, GetEmailAddress As String
            Dim RowIndex As Integer = Me.dgvARAging.CurrentCell.RowIndex
            Dim RowDivision As String = ""

            RowCustomer = Me.dgvARAging.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowDivision = Me.dgvARAging.Rows(RowIndex).Cells("DivisionIDColumn").Value

            Dim GetEmailAddressStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim GetEmailAddressCommand As New SqlCommand(GetEmailAddressStatement, con)
            GetEmailAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
            GetEmailAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetEmailAddress = CStr(GetEmailAddressCommand.ExecuteScalar)
            Catch ex As Exception
                GetEmailAddress = ""
            End Try
            con.Close()

            GlobalCustomerID = RowCustomer
            GlobalDivisionCode = RowDivision
            EmailInvoiceCustomer = GlobalCustomerID
            EmailCustomerEmailAddress = GetEmailAddress

            Using NewPrintARCustomerStatementSingle As New PrintARCustomerStatementSingle
                Dim Result = NewPrintARCustomerStatementSingle.ShowDialog()
            End Using
        End If
    End Sub

    Public Sub LoadInvoiceNumber()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE DivisionID <> @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmd
            myAdapter1.Fill(ds1, "InvoiceHeaderTable")
            cboInvoiceNumber.DataSource = ds1.Tables("InvoiceHeaderTable")
            con.Close()
            cboInvoiceNumber.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds1 = New DataSet()
            myAdapter1.SelectCommand = cmd
            myAdapter1.Fill(ds1, "InvoiceHeaderTable")
            cboInvoiceNumber.DataSource = ds1.Tables("InvoiceHeaderTable")
            con.Close()
            cboInvoiceNumber.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadCustomerID()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerID FROM CustomerList WHERE DivisionID <> @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd
            myAdapter2.Fill(ds2, "CustomerList")
            cboCustomerID.DataSource = ds2.Tables("CustomerList")
            con.Close()
            cboCustomerID.SelectedIndex = -1
        Else
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
        End If
    End Sub

    Public Sub LoadCustomerName()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerName FROM CustomerList WHERE DivisionID <> @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd
            myAdapter3.Fill(ds3, "CustomerList")
            cboCustomerName.DataSource = ds3.Tables("CustomerList")
            con.Close()
            cboCustomerName.SelectedIndex = -1
        Else
            cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd
            myAdapter3.Fill(ds3, "CustomerList")
            cboCustomerName.DataSource = ds3.Tables("CustomerList")
            con.Close()
            cboCustomerName.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadSalesTerritory()
        cmd = New SqlCommand("SELECT TerritoryID FROM SalesTerritoryQuery", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "SalesTerritoryQuery")
        cboSalesTerritory.DataSource = ds4.Tables("SalesTerritoryQuery")
        con.Close()
        cboSalesTerritory.SelectedIndex = -1
    End Sub

    Public Sub LoadPaymentTerms()
        cmd = New SqlCommand("SELECT PmtTermsID FROM PaymentTerms", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "PaymentTerms")
        cboPaymentTerms.DataSource = ds5.Tables("PaymentTerms")
        con.Close()
        cboPaymentTerms.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        If cboDivisionID.Text = "ADM" Then
            Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID <> @DivisionID"
            Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
            CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
            CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
            Catch ex As Exception
                CustomerID1 = ""
            End Try
            con.Close()
        Else
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
        End If

        cboCustomerID.Text = CustomerID1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        If cboDivisionID.Text = "ADM" Then
            Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID <> @DivisionID"
            Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
            CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
            Catch ex As Exception
                CustomerName1 = ""
            End Try
            con.Close()
        Else
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
        End If

        cboCustomerName.Text = CustomerName1
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvARAging.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboDivisionID.Text = "ADM" Then
            If cboInvoiceNumber.Text <> "" Then
                InvoiceNumber = Val(cboInvoiceNumber.Text)
                strInvoiceNumber = CStr(InvoiceNumber)
                InvoiceFilter = " AND InvoiceNumber = '" + strInvoiceNumber + "'"
            Else
                InvoiceFilter = ""
            End If
            If cboSalesTerritory.Text <> "" Then
                TerritoryFilter = " AND SalesTerritory = '" + cboSalesTerritory.Text + "'"
            Else
                TerritoryFilter = ""
            End If
            If cboCustomerID.Text <> "" Then
                CustomerFilter = " AND CustomerID = '" + cboCustomerID.Text + "'"
            Else
                CustomerFilter = ""
            End If
            If cboPaymentTerms.Text <> "" Then
                PaymentTermsFilter = " AND PaymentTerms = '" + cboPaymentTerms.Text + "'"
            Else
                PaymentTermsFilter = ""
            End If
            If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
                If rdoAmerican.Checked = True Then
                    ClassFilter = " AND CustomerClass = 'AMERICAN'"
                ElseIf rdoCanadian.Checked = True Then
                    ClassFilter = " AND CustomerClass = 'CANADIAN'"
                End If
            Else
                ClassFilter = ""
            End If
            If chkDateRange.Checked = False Then
                DateFilter = ""
            Else
                DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            End If

            cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID <> @DivisionID" + CustomerFilter + ClassFilter + TerritoryFilter + InvoiceFilter + PaymentTermsFilter + DateFilter + " ORDER BY CustomerID, InvoiceDate", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARAgingCategory")
            dgvARAging.DataSource = ds.Tables("ARAgingCategory")
            con.Close()

            'Show division
            Me.dgvARAging.Columns("DivisionIDColumn").Visible = True
        Else
            If cboInvoiceNumber.Text <> "" Then
                InvoiceNumber = Val(cboInvoiceNumber.Text)
                strInvoiceNumber = CStr(InvoiceNumber)
                InvoiceFilter = " AND InvoiceNumber = '" + strInvoiceNumber + "'"
            Else
                InvoiceFilter = ""
            End If
            If cboSalesTerritory.Text <> "" Then
                TerritoryFilter = " AND SalesTerritory = '" + cboSalesTerritory.Text + "'"
            Else
                TerritoryFilter = ""
            End If
            If cboCustomerID.Text <> "" Then
                CustomerFilter = " AND CustomerID = '" + cboCustomerID.Text + "'"
            Else
                CustomerFilter = ""
            End If
            If cboPaymentTerms.Text <> "" Then
                PaymentTermsFilter = " AND PaymentTerms = '" + cboPaymentTerms.Text + "'"
            Else
                PaymentTermsFilter = ""
            End If
            If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
                If rdoAmerican.Checked = True Then
                    ClassFilter = " AND CustomerClass = 'AMERICAN'"
                ElseIf rdoCanadian.Checked = True Then
                    ClassFilter = " AND CustomerClass = 'CANADIAN'"
                End If
            Else
                ClassFilter = ""
            End If
            If chkDateRange.Checked = False Then
                DateFilter = ""
            Else
                DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            End If

            cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID = @DivisionID" + CustomerFilter + ClassFilter + TerritoryFilter + InvoiceFilter + PaymentTermsFilter + DateFilter + " ORDER BY CustomerID, InvoiceDate", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARAgingCategory")
            dgvARAging.DataSource = ds.Tables("ARAgingCategory")
            con.Close()

            'Show division
            Me.dgvARAging.Columns("DivisionIDColumn").Visible = False
        End If
    End Sub

    Public Sub ShowAllData()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID <> @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARAgingCategory")
            dgvARAging.DataSource = ds.Tables("ARAgingCategory")
            con.Close()
            ALLStatement = "SELECT CustomerID FROM ARAgingCategory WHERE DivisionID <> 'ADM'"

            'Show division
            Me.dgvARAging.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARAgingCategory")
            dgvARAging.DataSource = ds.Tables("ARAgingCategory")
            con.Close()
            ALLStatement = "SELECT CustomerID FROM ARAgingCategory WHERE DivisionID = @DivisionID"

            'Show division
            Me.dgvARAging.Columns("DivisionIDColumn").Visible = False
        End If
    End Sub

    Public Sub ShowDataByCategoryGreater31()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID <> @DivisionID And (Aging31to45 <> 0 or Aging46to60 <> 0 or Aging61to90 <> 0 or AgingMoreThan90 <> 0)", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARAgingCategory")
            dgvARAging.DataSource = ds.Tables("ARAgingCategory")
            con.Close()
            Statement30 = "SELECT CustomerID FROM ARAgingCategory WHERE DivisionID <> 'ADM' And (Aging31to45 <> 0 or Aging46to60 <> 0 or Aging61to90 <> 0 or AgingMoreThan90 <> 0)"
        Else
            cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID = @DivisionID And (Aging31to45 <> 0 or Aging46to60 <> 0 or Aging61to90 <> 0 or AgingMoreThan90 <> 0)", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARAgingCategory")
            dgvARAging.DataSource = ds.Tables("ARAgingCategory")
            con.Close()
            Statement30 = "SELECT CustomerID FROM ARAgingCategory WHERE DivisionID = @DivisionID And (Aging31to45 <> 0 or Aging46to60 <> 0 or Aging61to90 <> 0 or AgingMoreThan90 <> 0)"
        End If
    End Sub

    Public Sub ShowDataByCategoryGreater46()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID <> @DivisionID And (Aging46to60 <> 0 or Aging61to90 <> 0 or AgingMoreThan90 <> 0)", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARAgingCategory")
            dgvARAging.DataSource = ds.Tables("ARAgingCategory")
            con.Close()
            Statement45 = "SELECT CustomerID FROM ARAgingCategory WHERE DivisionID <> 'ADM' And (Aging46to60 <> 0 or Aging61to90 <> 0 or AgingMoreThan90 <> 0)"
        Else
            cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID = @DivisionID And (Aging46to60 <> 0 or Aging61to90 <> 0 or AgingMoreThan90 <> 0)", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARAgingCategory")
            dgvARAging.DataSource = ds.Tables("ARAgingCategory")
            con.Close()
            Statement45 = "SELECT CustomerID FROM ARAgingCategory WHERE DivisionID = @DivisionID And (Aging46to60 <> 0 or Aging61to90 <> 0 or AgingMoreThan90 <> 0)"
        End If
    End Sub

    Public Sub ShowDataByCategoryGreater61()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID <> @DivisionID And (Aging61to90 <> 0 or AgingMoreThan90 <> 0)", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARAgingCategory")
            dgvARAging.DataSource = ds.Tables("ARAgingCategory")
            con.Close()
            Statement60 = "SELECT CustomerID FROM ARAgingCategory WHERE DivisionID <> 'ADM' And (Aging61to90 <> 0 or AgingMoreThan90 <> 0)"
        Else
            cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID = @DivisionID And (Aging61to90 <> 0 or AgingMoreThan90 <> 0)", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARAgingCategory")
            dgvARAging.DataSource = ds.Tables("ARAgingCategory")
            con.Close()
            Statement60 = "SELECT CustomerID FROM ARAgingCategory WHERE DivisionID = @DivisionID And (Aging61to90 <> 0 or AgingMoreThan90 <> 0)"
        End If
     End Sub

    Public Sub ShowDataByCategoryGreater90()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID <> @DivisionID And AgingMoreThan90 <> 0", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARAgingCategory")
            dgvARAging.DataSource = ds.Tables("ARAgingCategory")
            con.Close()
            Statement90 = "SELECT CustomerID FROM ARAgingCategory WHERE DivisionID <> 'ADM' And AgingMoreThan90 <> 0"

        Else
            cmd = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID = @DivisionID And AgingMoreThan90 <> 0", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARAgingCategory")
            dgvARAging.DataSource = ds.Tables("ARAgingCategory")
            con.Close()
            Statement90 = "SELECT CustomerID FROM ARAgingCategory WHERE DivisionID = @DivisionID And AgingMoreThan90 <> 0"
        End If
    End Sub

    Public Sub ClearData()
        cboInvoiceNumber.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboAgingCategory.SelectedIndex = -1
        cboSalesTerritory.SelectedIndex = -1
        cboPaymentTerms.SelectedIndex = -1

        txtAgingTotals.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        CustomerClass = ""
        ALLStatement = ""
        Statement30 = ""
        Statement45 = ""
        Statement60 = ""
        Statement90 = ""
        SQLStatement = ""
        CustomerFilter = ""
        DateFilter = ""
        InvoiceFilter = ""
        ClassFilter = ""
        TerritoryFilter = ""
        PaymentTermsFilter = ""
        InvoiceNumber = 0
        strInvoiceNumber = ""
        BeginDate = ""
        EndDate = ""
    End Sub

    Private Sub cmdCustomerAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomerAccounts.Click
        Dim RowCustomer As String = ""
        Dim RowDivision As String = ""

        If Me.dgvARAging.RowCount <> 0 Then

            Dim RowIndex As Integer = Me.dgvARAging.CurrentCell.RowIndex

            RowCustomer = Me.dgvARAging.Rows(RowIndex).Cells("CustomerIDColumn").Value
            RowDivision = Me.dgvARAging.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalCustomerID = RowCustomer
        Else
            GlobalCustomerID = cboCustomerID.Text
        End If

        GlobalDivisionCode = RowDivision

        Dim NewARCustomerAccounts As New ARCustomerAccounts
        NewARCustomerAccounts.Show()
    End Sub

    Private Sub cmdViewByCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByCategory.Click
        'Filter current aging table by category and sace Customer ID into a temp dataset
        Dim AgingCategory As String = ""
        AgingCategory = cboAgingCategory.Text

        Select Case AgingCategory
            Case "Less than 30"
                ShowAllData()
                SQLStatement = ALLStatement
            Case "31 - 45"
                ShowDataByCategoryGreater31()
                SQLStatement = Statement30
            Case "46 - 60"
                ShowDataByCategoryGreater46()
                SQLStatement = Statement45
            Case "61 - 90"
                ShowDataByCategoryGreater61()
                SQLStatement = Statement60
            Case "Over 90"
                ShowDataByCategoryGreater90()
                SQLStatement = Statement90
            Case Else
                ShowAllData()
                SQLStatement = ALLStatement
        End Select
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds
        Using NewPrintARAgingFiltered As New PrintARAgingFiltered
            Dim result = NewPrintARAgingFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds
        Using NewPrintARAgingFiltered As New PrintARAgingFiltered
            Dim result = NewPrintARAgingFiltered.ShowDialog()
        End Using
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

    Private Sub cmdPrintStatements_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintStatements.Click
        'Create Dataset for specific Customers that fall into Aging Selection
        cmd = New SqlCommand("SELECT * FROM ARAgingQuery WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        cmd1 = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        cmd2 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID IN (" + SQLStatement + ")", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        cmd3 = New SqlCommand("SELECT * FROM CustomerContacts WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        cmd4 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd4.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text

        cmd5 = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()

        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ARAgingQuery")

        myAdapter4.SelectCommand = cmd1
        myAdapter4.Fill(ds3, "ARAgingCategory")

        myAdapter5.SelectCommand = cmd2
        myAdapter5.Fill(ds3, "CustomerList")

        myAdapter6.SelectCommand = cmd3
        myAdapter6.Fill(ds3, "CustomerContacts")

        myAdapter7.SelectCommand = cmd4
        myAdapter7.Fill(ds3, "DivisionTable")

        myAdapter8.SelectCommand = cmd5
        myAdapter8.Fill(ds3, "InvoiceHeaderTable")

        GDS = ds3

        Using NewPrintCustomerStatement As New PrintCustomerStatement
            Dim result = NewPrintCustomerStatement.ShowDialog()
        End Using
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdClear3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear3.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub
End Class