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
Public Class ViewCustomerSalesHistory
    Inherits System.Windows.Forms.Form

    Dim TextFilter, CustomerTextFilter, SOFilter, ShipmentFilter, CustomerPOFilter, DateFilter, CustomerFilter, PartFilter As String
    Dim BeginDate, EndDate As Date
    Dim SONumber, ShipmentNumber As Integer
    Dim strSONumber, strShipmentNumber As String
    Dim ProductTotal, COGS, ProfitMargin As Double

    'Configure Data Connection and declare variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As New DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub CustomerSalesHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
        End If

        LoadSecurity()
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

    Public Sub LoadSecurity()
        Select Case EmployeeCompanyCode
            Case "TWD"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtMargin.Visible = True
                    txtCOGS.Visible = True
                    dgvCustomerSalesHistory.Columns("ExtendedCOSColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtMargin.Visible = False
                    txtCOGS.Visible = False
                    dgvCustomerSalesHistory.Columns("ExtendedCOSColumn").Visible = False
                End If
            Case "TFP"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtMargin.Visible = True
                    txtCOGS.Visible = True
                    dgvCustomerSalesHistory.Columns("ExtendedCOSColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtMargin.Visible = False
                    txtCOGS.Visible = False
                    dgvCustomerSalesHistory.Columns("ExtendedCOSColumn").Visible = False
                End If
            Case "ADM"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtMargin.Visible = True
                    txtCOGS.Visible = True
                    dgvCustomerSalesHistory.Columns("ExtendedCOSColumn").Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtMargin.Visible = False
                    txtCOGS.Visible = False
                    dgvCustomerSalesHistory.Columns("ExtendedCOSColumn").Visible = False
                End If
            Case Else
                lblCOGS.Visible = True
                lblMargin.Visible = True
                txtMargin.Visible = True
                txtCOGS.Visible = True
                dgvCustomerSalesHistory.Columns("ExtendedCOSColumn").Visible = True
        End Select
    End Sub

    Private Sub dgvCustomerSalesHistory_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvCustomerSalesHistory.CellDoubleClick
        Dim RowInvoiceNumber, RowSONumber, RowShipmentNumber As Integer
        Dim RowDivision, RowCustomer, CustomerEmail As String

        Dim RowIndex As Integer = Me.dgvCustomerSalesHistory.CurrentCell.RowIndex

        RowInvoiceNumber = Me.dgvCustomerSalesHistory.Rows(RowIndex).Cells("InvoiceHeaderKeyColumn").Value
        RowSONumber = Me.dgvCustomerSalesHistory.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value
        RowShipmentNumber = Me.dgvCustomerSalesHistory.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowDivision = Me.dgvCustomerSalesHistory.Rows(RowIndex).Cells("DivisionIDColumn").Value
        RowCustomer = Me.dgvCustomerSalesHistory.Rows(RowIndex).Cells("CustomerIDColumn").Value

        Dim CustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerEmailCommand As New SqlCommand(CustomerEmailStatement, con)
        CustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
        CustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerEmail = CStr(CustomerEmailCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerEmail = ""
        End Try
        con.Close()

        'Choose the Invoice Print Form by division
        If RowDivision = "TFF" Or RowDivision = "TOR" Or cboDivisionID.Text = "ALB" Then
            If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = RowDivision

                'Get string Customer/InvoiceNumber for emails
                EmailInvoiceCustomer = RowCustomer
                EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                EmailCustomerEmailAddress = CustomerEmail

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
                    Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                        Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                        Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                    End Using
                End If
            Else
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = RowDivision

                'Get string Customer/InvoiceNumber for emails
                EmailInvoiceCustomer = RowCustomer
                EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                EmailCustomerEmailAddress = CustomerEmail

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
                    Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                        Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBatch As New PrintInvoiceSingle
                        Dim result = NewPrintInvoiceBatch.ShowDialog()
                    End Using
                End If
            End If
        Else
            If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = RowDivision

                'Get string Customer/InvoiceNumber for emails
                EmailInvoiceCustomer = RowCustomer
                EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                EmailCustomerEmailAddress = CustomerEmail

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
                    Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                        Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                        Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                    End Using
                End If
            Else
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = RowDivision

                'Get string Customer/InvoiceNumber for emails
                EmailInvoiceCustomer = RowCustomer
                EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                EmailCustomerEmailAddress = CustomerEmail

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
                    Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                        Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                        Dim result = NewPrintInvoiceSingle.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvCustomerSalesHistory.DataSource = Nothing
        Me.dgvCustomerSalesHistory.Columns("DivisionIDColumn").Visible = False
    End Sub

    Public Sub ShowDataByFilter()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustomerPOFilter = " AND CustomerPO = '" + txtCustomerPO.Text + "'"
        Else
            CustomerPOFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderNumber = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%' OR PartDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%')"
        Else
            TextFilter = ""
        End If
        If txtCustomerTextSearch.Text <> "" Then
            CustomerTextFilter = " AND (CustomerID LIKE '%" + usefulFunctions.checkQuote(txtCustomerTextSearch.Text) + "%' OR CustomerName LIKE '%" + usefulFunctions.checkQuote(txtCustomerTextSearch.Text) + "%')"
        Else
            CustomerTextFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID <> @DivisionID" + CustomerFilter + PartFilter + CustomerPOFilter + SOFilter + ShipmentFilter + TextFilter + CustomerTextFilter + DateFilter + " ORDER BY DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceLineQuery")
            dgvCustomerSalesHistory.DataSource = ds.Tables("InvoiceLineQuery")
            con.Close()
            Me.dgvCustomerSalesHistory.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID" + CustomerFilter + PartFilter + CustomerPOFilter + SOFilter + ShipmentFilter + TextFilter + CustomerTextFilter + DateFilter, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceLineQuery")
            dgvCustomerSalesHistory.DataSource = ds.Tables("InvoiceLineQuery")
            con.Close()
            Me.dgvCustomerSalesHistory.Columns("DivisionIDColumn").Visible = False
        End If
    End Sub

    Public Sub LoadPartNumber()
        'Create commands to load Item List for each division
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        cboPartDescription.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerList()
        'Create commands to load Customer List for each division
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
    End Sub

    Public Sub LoadSalesOrderNumber()
        'Create commands to load Customer List for each division
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds3.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadShipmentNumber()
        'Create commands to load Customer List for each division
        cmd = New SqlCommand("SELECT ShipmentNumber FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID ORDER BY ShipmentNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ShipmentHeaderTable")
        cboSalesOrderNumber.DataSource = ds3.Tables("ShipmentHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        'Create commands to load Item List for each division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboPartDescription.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        'Create commands to load Customer List for each division
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "CustomerList")
        cboCustomerName.DataSource = ds5.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
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

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomerList()
        LoadCustomerName()
        LoadPartNumber()
        LoadPartDescription()
        LoadSalesOrderNumber()
        LoadShipmentNumber()

        'Clear text boxes on load
        ClearVariables()
        ClearData()

        'Set form defaults
        If GlobalCustomerID <> "" Then
            cboCustomerID.Text = GlobalCustomerID
            cboCustomerName.Text = GlobalCustomerName
        Else
            cboCustomerID.SelectedIndex = -1
            cboCustomerName.SelectedIndex = -1
        End If

        If GlobalMaintenancePartNumber <> "" Then
            cboPartNumber.Text = GlobalMaintenancePartNumber
            cboPartDescription.Text = GlobalMaintenancePartDescription
        Else
            cboPartNumber.SelectedIndex = -1
            cboPartDescription.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadTotalsByFilter()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            CustomerPOFilter = " AND CustomerPO = '" + txtCustomerPO.Text + "'"
        Else
            CustomerPOFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderNumber = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboShipmentNumber.Text <> "" Then
            ShipmentNumber = Val(cboShipmentNumber.Text)
            strShipmentNumber = CStr(ShipmentNumber)
            ShipmentFilter = " AND ShipmentNumber = '" + strShipmentNumber + "'"
        Else
            ShipmentFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (PartNumber LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%' OR PartDescription LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%')"
        Else
            TextFilter = ""
        End If
        If txtCustomerTextSearch.Text <> "" Then
            CustomerTextFilter = " AND (CustomerID LIKE '%" + usefulFunctions.checkQuote(txtCustomerTextSearch.Text) + "%' OR CustomerName LIKE '%" + usefulFunctions.checkQuote(txtCustomerTextSearch.Text) + "%')"
        Else
            CustomerTextFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
       
            DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        End If

        If cboDivisionID.Text = "ADM" Then
            Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID <> @DivisionID" + CustomerFilter + PartFilter + CustomerPOFilter + SOFilter + ShipmentFilter + TextFilter + CustomerTextFilter + DateFilter
            Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
            ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            ProductTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ProductTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim COGSStatement As String = "SELECT SUM(ExtendedCOS) FROM InvoiceLineQuery WHERE DivisionID <> @DivisionID" + CustomerFilter + PartFilter + CustomerPOFilter + SOFilter + ShipmentFilter + TextFilter + CustomerTextFilter + DateFilter
            Dim COGSCommand As New SqlCommand(COGSStatement, con)
            COGSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            COGSCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            COGSCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                COGS = CDbl(COGSCommand.ExecuteScalar)
            Catch ex As Exception
                COGS = 0
            End Try
            con.Close()

            If ProductTotal <> 0 Then
                ProfitMargin = 1 - (COGS / ProductTotal)
            Else
                ProfitMargin = 0.0
            End If
        Else
            Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID" + CustomerFilter + PartFilter + CustomerPOFilter + SOFilter + ShipmentFilter + TextFilter + CustomerTextFilter + DateFilter
            Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
            ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ProductTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ProductTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            Dim COGSStatement As String = "SELECT SUM(ExtendedCOS) FROM InvoiceLineQuery WHERE DivisionID = @DivisionID" + CustomerFilter + PartFilter + CustomerPOFilter + SOFilter + ShipmentFilter + TextFilter + CustomerTextFilter + DateFilter
            Dim COGSCommand As New SqlCommand(COGSStatement, con)
            COGSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            COGSCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            COGSCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                COGS = CDbl(COGSCommand.ExecuteScalar)
            Catch ex As Exception
                COGS = 0
            End Try
            con.Close()

            If ProductTotal <> 0 Then
                ProfitMargin = 1 - (COGS / ProductTotal)
            Else
                ProfitMargin = 0.0
            End If
        End If

        txtCOGS.Text = FormatCurrency(COGS, 2)
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtMargin.Text = FormatPercent(ProfitMargin, 2)
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilter()
        LoadTotalsByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearData()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboShipmentNumber.SelectedIndex = -1

        txtCustomerPO.Clear()
        txtCOGS.Clear()
        txtMargin.Clear()
        txtProductTotal.Clear()
        txtTextFilter.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""
        chkDateRange.Checked = False
        GlobalShipmentNumber = 0
        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        TextFilter = ""
        SOFilter = ""
        ShipmentFilter = ""
        CustomerPOFilter = ""
        DateFilter = ""
        CustomerFilter = ""
        PartFilter = ""
        SONumber = 0
        ShipmentNumber = 0
        strSONumber = ""
        strShipmentNumber = ""
        ProductTotal = 0
        COGS = 0
        ProfitMargin = 0
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds
        Using NewPrintCustomerSalesFiltered As New PrintCustomerSalesFiltered
            Dim Result = NewPrintCustomerSalesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem1.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds
        Using NewPrintCustomerSalesFiltered As New PrintCustomerSalesFiltered
            Dim Result = NewPrintCustomerSalesFiltered.ShowDialog()
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
End Class