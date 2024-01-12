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
Public Class ViewSalesLines
    Inherits System.Windows.Forms.Form

    Dim BeginDate, EndDate As Date
    Dim ProductTotal, COGS, ProfitMargin, QtyOrdered, QtyShipped, QtyOpen As Double
    Dim ClosedFilter, TextFilter, CustomerFilter, PartFilter, StatusFilter, DateFilter, POFilter, SOFilter, SalespersonFilter As String
    Dim SONumber As Integer = 0
    Dim strSONumber As String = ""
    Dim SONumberFilter As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewSalesLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        LoadCurrentDivision()
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

    Public Sub LoadSecurity()
        Select Case EmployeeCompanyCode
            Case "TWD"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtMargin.Visible = True
                    txtCOGS.Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtMargin.Visible = False
                    txtCOGS.Visible = False
                End If
            Case "TWE"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtMargin.Visible = True
                    txtCOGS.Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtMargin.Visible = False
                    txtCOGS.Visible = False
                End If
            Case "TFP"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtMargin.Visible = True
                    txtCOGS.Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtMargin.Visible = False
                    txtCOGS.Visible = False
                End If
            Case "ADM"
                If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                    lblCOGS.Visible = True
                    lblMargin.Visible = True
                    txtMargin.Visible = True
                    txtCOGS.Visible = True
                Else
                    lblCOGS.Visible = False
                    lblMargin.Visible = False
                    txtMargin.Visible = False
                    txtCOGS.Visible = False
                End If
            Case Else
                lblCOGS.Visible = True
                lblMargin.Visible = True
                txtMargin.Visible = True
                txtCOGS.Visible = True
        End Select
    End Sub

    Private Sub dgvOpenOrders_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvSalesOrderLines.CellDoubleClick
        Dim RowSONumber As Integer = 0
        Dim RowDivision As String = ""
        Dim RowCustomer As String = ""
        Dim RowIndex As Integer = Me.dgvSalesOrderLines.CurrentCell.RowIndex

        RowSONumber = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value
        RowDivision = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("DivisionKeyColumn").Value
        RowCustomer = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("CustomerIDColumn").Value
        '************************************************************************************************
        'Get Email address for confirmationsr
        Dim GetConfirmationEmail As String = ""

        Dim GetConfirmationEmailString As String = "SELECT ConfirmationEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetConfirmationEmailCommand As New SqlCommand(GetConfirmationEmailString, con)
        GetConfirmationEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
        GetConfirmationEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetConfirmationEmail = CStr(GetConfirmationEmailCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetConfirmationEmail = ""
        End Try
        con.Close()

        EmailCustomerConfirmations = GetConfirmationEmail

        'Choose correct print form
        If cboDivisionID.Text = "TFP" Then
            'Get FOX Number
            Dim GetFOXNumber As Integer = 0

            Dim GetFOXNumberString As String = "SELECT FOXNumber FROM FOXTable WHERE OrderReferenceNumber = @OrderReferenceNumber AND DivisionID = @DivisionID"
            Dim GetFOXNumberCommand As New SqlCommand(GetFOXNumberString, con)
            GetFOXNumberCommand.Parameters.Add("@OrderReferenceNumber", SqlDbType.VarChar).Value = RowSONumber
            GetFOXNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetFOXNumber = CInt(GetFOXNumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetFOXNumber = 0
            End Try
            con.Close()

            GlobalSONumber = RowSONumber
            GlobalDivisionCode = cboDivisionID.Text
            GlobalTFPSOPrintForm = "TFP Acknowledgement"
            GlobalFOXNumber = GetFOXNumber

            Using NewPrintTFAcknowledgement As New PrintTFAcknowledgement
                Dim result = NewPrintTFAcknowledgement.ShowDialog()
            End Using
        ElseIf cboDivisionID.Text = "ADM" Then
            GlobalSONumber = RowSONumber
            GlobalDivisionCode = RowDivision

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
                Using NewPrintSalesOrderRemote As New PrintSalesOrderRemote
                    Dim result = NewPrintSalesOrderRemote.ShowDialog()
                End Using
            Else
                Using NewPrintSalesOrder As New PrintSalesOrder
                    Dim result = NewPrintSalesOrder.ShowDialog()
                End Using
            End If
        Else
            GlobalSONumber = RowSONumber
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
                Using NewPrintSalesOrderRemote As New PrintSalesOrderRemote
                    Dim result = NewPrintSalesOrderRemote.ShowDialog()
                End Using
            Else
                Using NewPrintSalesOrder As New PrintSalesOrder
                    Dim result = NewPrintSalesOrder.ShowDialog()
                End Using
            End If
        End If
    End Sub

    Public Sub ShowDataByFilter()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSOStatus.Text <> "" Then
            StatusFilter = " AND LineStatus = '" + cboSOStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            POFilter = " AND CustomerPO LIKE '%" + txtCustomerPO.Text + "%'"
        Else
            POFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND ItemID = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboSalesPerson.Text <> "" Then
            SalespersonFilter = " AND Salesperson = '" + cboSalesPerson.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%' OR Description LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%')"
        Else
            TextFilter = ""
        End If
        If chkDateRange.Checked = False Then
            If ViewAllLinesToolStripMenuItem.Checked = True Then
                DateFilter = ""
            ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
                DateFilter = " AND SalesOrderDate >= '1/1/2020'"
            Else
                DateFilter = ""
            End If
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        End If
        If chkViewClosedWithOpen.Checked = False Then
            ClosedFilter = ""
        Else
            ClosedFilter = " AND LineStatus = 'CLOSED' AND QuantityShipped < QuantityOrdered"
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM SalesOrderQuantityStatus WHERE DivisionKey <> @DivisionKey AND SOStatus <> 'QUOTE'" + CustomerFilter + StatusFilter + PartFilter + SOFilter + POFilter + SalespersonFilter + TextFilter + ClosedFilter + DateFilter + " ORDER BY DivisionKey, SalesOrderKey", con)
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "SalesOrderQuantityStatus")
            dgvSalesOrderLines.DataSource = ds.Tables("SalesOrderQuantityStatus")
            con.Close()

            Me.dgvSalesOrderLines.Columns("DivisionKeyColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM SalesOrderQuantityStatus WHERE DivisionKey = @DivisionKey AND SOStatus <> 'QUOTE'" + CustomerFilter + StatusFilter + PartFilter + SOFilter + POFilter + SalespersonFilter + TextFilter + ClosedFilter + DateFilter + " ORDER BY SalesOrderKey DESC", con)
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "SalesOrderQuantityStatus")
            dgvSalesOrderLines.DataSource = ds.Tables("SalesOrderQuantityStatus")
            con.Close()

            Me.dgvSalesOrderLines.Columns("DivisionKeyColumn").Visible = False
        End If
        '*******************************************************************************************
        Dim CountIndex As Integer = 0
        Dim LineStatus As String = ""
        Dim LineQuantity As Double = 0

        For Each row As DataGridViewRow In dgvSalesOrderLines.Rows
            Try
                LineStatus = dgvSalesOrderLines.Rows(CountIndex).Cells("LineStatusColumn").Value
            Catch ex As Exception

            End Try
            Try
                LineQuantity = dgvSalesOrderLines.Rows(CountIndex).Cells("QuantityOpenColumn").Value
            Catch ex As Exception

            End Try
            If LineStatus = "CLOSED" Then
                Try
                    dgvSalesOrderLines.Rows(CountIndex).Cells("QuantityOpenColumn").Style.ForeColor = Color.Red
                Catch ex As Exception
                    'skip
                End Try
            Else
                Try
                    dgvSalesOrderLines.Rows(CountIndex).Cells("QuantityOpenColumn").Style.ForeColor = Color.Black
                Catch ex As Exception
                    'skip
                End Try
            End If

            CountIndex = CountIndex + 1
        Next
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvSalesOrderLines.DataSource = Nothing
        Me.dgvSalesOrderLines.Columns("DivisionKeyColumn").Visible = False
    End Sub

    Public Sub LoadCustomer()
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

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ItemList")
        cboPartNumber.DataSource = ds2.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesOrder()
        If ViewAllLinesToolStripMenuItem.Checked = True Then
            SONumberFilter = ""
        ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
            SONumberFilter = " AND SalesOrderDate >= '1/1/2020'"
        Else
            SONumberFilter = ""
        End If

        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey" + SONumberFilter + " ORDER BY SalesOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "SalesOrderHeaderTable")
        cboSalesOrderNumber.DataSource = ds3.Tables("SalesOrderHeaderTable")
        con.Close()
        cboSalesOrderNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadSalesperson()
        cmd = New SqlCommand("SELECT SalesPersonID FROM EmployeeData WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "EmployeeData")
        cboSalesPerson.DataSource = ds4.Tables("EmployeeData")
        con.Close()
        cboSalesPerson.SelectedIndex = -1
    End Sub

    Public Sub LoadSalespersonTWD()
        cmd = New SqlCommand("SELECT SalesPersonID FROM EmployeeData WHERE DivisionKey = @DivisionKey OR DivisionKey = @DivisionKey2 OR DivisionKey = @DivisionKey3", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@DivisionKey2", SqlDbType.VarChar).Value = "TFP"
        cmd.Parameters.Add("@DivisionKey3", SqlDbType.VarChar).Value = "ADM"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "EmployeeData")
        cboSalesPerson.DataSource = ds4.Tables("EmployeeData")
        con.Close()
        cboSalesPerson.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "ItemList")
        cboPartDescription.DataSource = ds5.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "CustomerList")
        cboCustomerName.DataSource = ds6.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadTotalsByFilter()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboSOStatus.Text <> "" Then
            StatusFilter = " AND LineStatus = '" + cboSOStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If txtCustomerPO.Text <> "" Then
            POFilter = " AND CustomerPO LIKE '%" + txtCustomerPO.Text + "%'"
        Else
            POFilter = ""
        End If
        If cboSalesOrderNumber.Text <> "" Then
            SONumber = Val(cboSalesOrderNumber.Text)
            strSONumber = CStr(SONumber)
            SOFilter = " AND SalesOrderKey = '" + strSONumber + "'"
        Else
            SOFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND ItemID = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboSalesPerson.Text <> "" Then
            SalespersonFilter = " AND Salesperson = '" + cboSalesPerson.Text + "'"
        Else
            SalespersonFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (ItemID LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%' OR Description LIKE '%" + usefulFunctions.checkQuote(txtTextFilter.Text) + "%')"
        Else
            TextFilter = ""
        End If
        If chkDateRange.Checked = False Then
            If ViewAllLinesToolStripMenuItem.Checked = True Then
                DateFilter = ""
            ElseIf ViewLast3YearsToolStripMenuItem.Checked = True Then
                DateFilter = " AND SalesOrderDate >= '1/1/2020'"
            Else
                DateFilter = ""
            End If
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            DateFilter = " AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
        End If

        If cboDivisionID.Text = "ADM" Then
            Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineQuery WHERE DivisionKey <> @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + StatusFilter + PartFilter + SOFilter + POFilter + SalespersonFilter + TextFilter + DateFilter
            Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
            ProductTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "ADM"
            ProductTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ProductTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            ProductTotalCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

            Dim COGSStatement As String = "SELECT SUM(EstExtendedCOS) FROM SalesOrderLineQuery WHERE DivisionKey <> @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + StatusFilter + PartFilter + SOFilter + POFilter + SalespersonFilter + TextFilter + DateFilter
            Dim COGSCommand As New SqlCommand(COGSStatement, con)
            COGSCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "ADM"
            COGSCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            COGSCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            COGSCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

            Dim QuantityOrderedStatement As String = "SELECT SUM(Quantity) FROM SalesOrderLineQueryQOH WHERE DivisionKey <> @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + StatusFilter + PartFilter + SOFilter + POFilter + SalespersonFilter + TextFilter + DateFilter
            Dim QuantityOrderedCommand As New SqlCommand(QuantityOrderedStatement, con)
            QuantityOrderedCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "ADM"
            QuantityOrderedCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            QuantityOrderedCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            QuantityOrderedCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

            Dim QuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM SalesOrderLineQueryQOH WHERE DivisionKey <> @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + StatusFilter + PartFilter + SOFilter + POFilter + SalespersonFilter + TextFilter + DateFilter
            Dim QuantityShippedCommand As New SqlCommand(QuantityShippedStatement, con)
            QuantityShippedCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "ADM"
            QuantityShippedCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            QuantityShippedCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            QuantityShippedCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

            Dim QuantityOpenStatement As String = "SELECT SUM(OpenSOQuantity) FROM SalesOrderLineQueryQOH WHERE DivisionKey <> @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + StatusFilter + PartFilter + SOFilter + POFilter + SalespersonFilter + TextFilter + DateFilter
            Dim QuantityOpenCommand As New SqlCommand(QuantityOpenStatement, con)
            QuantityOpenCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = "ADM"
            QuantityOpenCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            QuantityOpenCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            QuantityOpenCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

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
            Try
                QtyOrdered = CDbl(QuantityOrderedCommand.ExecuteScalar)
            Catch ex As Exception
                QtyOrdered = 0
            End Try
            Try
                QtyShipped = CDbl(QuantityShippedCommand.ExecuteScalar)
            Catch ex As Exception
                QtyShipped = 0
            End Try
            Try
                QtyOpen = CDbl(QuantityOpenCommand.ExecuteScalar)
            Catch ex As Exception
                QtyOpen = 0
            End Try
            con.Close()

            If ProductTotal <> 0 Then
                ProfitMargin = 1 - (COGS / ProductTotal)
            Else
                ProfitMargin = 0.0
            End If

        Else
            Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + StatusFilter + PartFilter + SOFilter + POFilter + SalespersonFilter + TextFilter + DateFilter
            Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
            ProductTotalCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            ProductTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            ProductTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            ProductTotalCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

            Dim COGSStatement As String = "SELECT SUM(EstExtendedCOS) FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + StatusFilter + PartFilter + SOFilter + POFilter + SalespersonFilter + TextFilter + DateFilter
            Dim COGSCommand As New SqlCommand(COGSStatement, con)
            COGSCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            COGSCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            COGSCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            COGSCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

            Dim QuantityOrderedStatement As String = "SELECT SUM(Quantity) FROM SalesOrderLineQueryQOH WHERE DivisionKey = @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + StatusFilter + PartFilter + SOFilter + POFilter + SalespersonFilter + TextFilter + DateFilter
            Dim QuantityOrderedCommand As New SqlCommand(QuantityOrderedStatement, con)
            QuantityOrderedCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            QuantityOrderedCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            QuantityOrderedCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            QuantityOrderedCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

            Dim QuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM SalesOrderLineQueryQOH WHERE DivisionKey = @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + StatusFilter + PartFilter + SOFilter + POFilter + SalespersonFilter + TextFilter + DateFilter
            Dim QuantityShippedCommand As New SqlCommand(QuantityShippedStatement, con)
            QuantityShippedCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            QuantityShippedCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            QuantityShippedCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            QuantityShippedCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

            Dim QuantityOpenStatement As String = "SELECT SUM(OpenSOQuantity) FROM SalesOrderLineQueryQOH WHERE DivisionKey = @DivisionKey AND SOStatus <> @SOStatus" + CustomerFilter + StatusFilter + PartFilter + SOFilter + POFilter + SalespersonFilter + TextFilter + DateFilter
            Dim QuantityOpenCommand As New SqlCommand(QuantityOpenStatement, con)
            QuantityOpenCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
            QuantityOpenCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            QuantityOpenCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            QuantityOpenCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"

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
            Try
                QtyOrdered = CDbl(QuantityOrderedCommand.ExecuteScalar)
            Catch ex As Exception
                QtyOrdered = 0
            End Try
            Try
                QtyShipped = CDbl(QuantityShippedCommand.ExecuteScalar)
            Catch ex As Exception
                QtyShipped = 0
            End Try
            Try
                QtyOpen = CDbl(QuantityOpenCommand.ExecuteScalar)
            Catch ex As Exception
                QtyOpen = 0
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
        txtQtyOpen.Text = FormatNumber(QtyOpen, 0)
        txtQtyOrdered.Text = FormatNumber(QtyOrdered, 0)
        txtQtyShipped.Text = FormatNumber(QtyShipped, 0)
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "ADM" Or cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TFP" Then
            LoadSalespersonTWD()
        Else
            LoadSalesperson()
        End If

        LoadCustomer()
        LoadCustomerName()
        LoadSalesperson()
        LoadPartNumber()
        LoadPartDescription()
        LoadSalesOrder()
        ClearData()
        ClearDataInDatagrid()
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

    Public Sub ClearData()
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboPartNumber.Text = ""
        cboPartDescription.Text = ""
        cboSalesPerson.Text = ""
        cboSOStatus.Text = ""

        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboSalesPerson.SelectedIndex = -1
        cboSOStatus.SelectedIndex = -1

        txtCOGS.Clear()
        txtMargin.Clear()
        txtProductTotal.Clear()
        txtCustomerPO.Clear()
        txtTextFilter.Clear()
        txtQtyOrdered.Clear()
        txtQtyOpen.Clear()
        txtQtyShipped.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        ProductTotal = 0
        COGS = 0
        ProfitMargin = 0
        GlobalSONumber = 0

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        ProductTotal = 0
        COGS = 0
        ProfitMargin = 0
        CustomerFilter = ""
        PartFilter = ""
        StatusFilter = ""
        DateFilter = ""
        POFilter = ""
        SOFilter = ""
        SalespersonFilter = ""
        SONumber = 0
        strSONumber = ""
        QtyOpen = 0
        QtyOrdered = 0
        QtyShipped = 0
        SONumberFilter = ""
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilter()
        LoadTotalsByFilter()
    End Sub

    Private Sub cmdOpenSalesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenSalesOrder.Click
        Dim RowSONumber As Integer
        Dim RowIndex As Integer = Me.dgvSalesOrderLines.CurrentCell.RowIndex

        RowSONumber = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value

        GlobalSONumber = RowSONumber
        GlobalDivisionCode = cboDivisionID.Text

        Dim NewSOForm As New SOForm
        NewSOForm.Show()
    End Sub

    Private Sub dgvSalesOrderLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSalesOrderLines.CellValueChanged
        Dim LineWeight, LineBoxes As Double
        Dim LineComment, LineDivision As String
        Dim RowSONumber, RowLineNumber As Integer

        If Me.dgvSalesOrderLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvSalesOrderLines.CurrentCell.RowIndex

            Try
                RowSONumber = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value
            Catch ex As Exception
                RowSONumber = 0
            End Try
            Try
                RowLineNumber = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("SalesOrderLineKeyColumn").Value
            Catch ex As Exception
                RowLineNumber = 0
            End Try
            Try
                LineWeight = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("LineWeightColumn").Value
            Catch ex As Exception
                LineWeight = 0
            End Try
            Try
                LineBoxes = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("LineBoxesColumn").Value
            Catch ex As Exception
                LineBoxes = 0
            End Try
            Try
                LineComment = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("LineCommentColumn").Value
            Catch ex As Exception
                LineComment = ""
            End Try
            Try
                LineDivision = Me.dgvSalesOrderLines.Rows(RowIndex).Cells("DivisionKeyColumn").Value
            Catch ex As Exception
                LineDivision = ""
            End Try

            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineWeight = @LineWeight, LineBoxes = @LineBoxes, LineComment = @LineComment WHERE SalesOrderKey = @SalesOrderKey AND SalesOrderLineKey = @SalesOrderLineKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@SalesOrderKey", SqlDbType.VarChar).Value = RowSONumber
                    .Add("@SalesOrderLineKey", SqlDbType.VarChar).Value = RowLineNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = LineDivision
                    .Add("@LineWeight", SqlDbType.VarChar).Value = LineWeight
                    .Add("@LineBoxes", SqlDbType.VarChar).Value = LineBoxes
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        Else
            'Skip update
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintSalesLinesFiltered As New PrintSalesLinesFiltered
            Dim Result = NewPrintSalesLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingwQuantityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingwQuantityToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        GDS = ds

        Using NewPrintSalesLinesFiltered As New PrintSalesLinesFiltered
            Dim Result = NewPrintSalesLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingwPricingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingwPricingToolStripMenuItem.Click
        GlobalDivisionCode = "SLC"
        GDS = ds

        Using NewPrintSalesLinesFiltered As New PrintSalesLinesFiltered
            Dim Result = NewPrintSalesLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem3.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ViewLast3YearsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLast3YearsToolStripMenuItem.Click
        ViewLast3YearsToolStripMenuItem.Checked = True
        ViewAllLinesToolStripMenuItem.Checked = False
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        LoadSalesOrder()
    End Sub

    Private Sub ViewAllLinesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAllLinesToolStripMenuItem.Click
        ViewLast3YearsToolStripMenuItem.Checked = False
        ViewAllLinesToolStripMenuItem.Checked = True
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        LoadSalesOrder()
    End Sub
End Class