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
Public Class ViewInvoicesToEmail
    Inherits System.Windows.Forms.Form

    Dim StatusFilter, DateFilter, CustomerFilter As String
    Dim BeginDate, EndDate As Date

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Configure Data Connection and declare variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As New DataTable


    Private Sub ViewInvoicesToEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearDatagrid()
        ClearVariables()
        ClearData()
        LoadCurrentDivision()
    End Sub

    Public Sub TFPErrorLogUpdate()
        If ErrorComment.Length > 400 Then
            ErrorComment = ErrorComment.Substring(0, 400)
        End If

        'Insert Data into error log
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

    Public Sub ShowDataByFilters()
        If cboDivisionID.Text = "ADM" Then
            If cboCustomerID.Text <> "" Then
                CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
            Else
                CustomerFilter = ""
            End If
            If cboStatus.Text <> "" Then
                If cboStatus.Text.StartsWith("OPEN") Then
                    StatusFilter = " AND EmailStatus = 'OPEN'"
                ElseIf cboStatus.Text.StartsWith("CLOSED") Then
                    StatusFilter = " AND EmailStatus = 'CLOSED'"
                Else
                    StatusFilter = ""
                End If
            Else
                StatusFilter = ""
            End If
            If chkDateRange.Checked = False Then

                DateFilter = ""
            Else
                BeginDate = dtpBeginDate.Text
                EndDate = dtpEndDate.Text

                DateFilter = " AND SentDate BETWEEN @BeginDate AND @EndDate"
            End If

            cmd = New SqlCommand("SELECT * FROM InvoiceEmailLog WHERE DivisionID <> @DivisionID" + CustomerFilter + StatusFilter + DateFilter + " ORDER BY SentDate DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceEmailLog")
            dgvInvoiceHeaders.DataSource = ds.Tables("InvoiceEmailLog")
            con.Close()

            LoadFormatting()
        Else
            If cboCustomerID.Text <> "" Then
                CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
            Else
                CustomerFilter = ""
            End If
            If cboStatus.Text <> "" Then
                If cboStatus.Text.StartsWith("OPEN") Then
                    StatusFilter = " AND EmailStatus = 'OPEN'"
                ElseIf cboStatus.Text.StartsWith("CLOSED") Then
                    StatusFilter = " AND EmailStatus = 'CLOSED'"
                Else
                    StatusFilter = ""
                End If
            Else
                StatusFilter = ""
            End If
            If chkDateRange.Checked = False Then

                DateFilter = ""
            Else
                BeginDate = dtpBeginDate.Text
                EndDate = dtpEndDate.Text

                DateFilter = " AND SentDate BETWEEN @BeginDate AND @EndDate"
            End If

            cmd = New SqlCommand("SELECT * FROM InvoiceEmailLog WHERE DivisionID = @DivisionID" + CustomerFilter + StatusFilter + DateFilter + " ORDER BY SentDate DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceEmailLog")
            dgvInvoiceHeaders.DataSource = ds.Tables("InvoiceEmailLog")
            con.Close()

            LoadFormatting()
        End If
    End Sub

    Public Sub ClearDatagrid()
        dgvInvoiceHeaders.DataSource = Nothing
    End Sub

    Public Sub LoadFormatting()
        Dim LineStatus As String = ""
        Dim RowIndex As Integer = 0

        If Me.dgvInvoiceHeaders.RowCount > 0 Then
            For Each LineRow As DataGridViewRow In dgvInvoiceHeaders.Rows
                Try
                    LineStatus = LineRow.Cells("EmailStatusColumn").Value
                Catch ex As System.Exception
                    LineStatus = ""
                End Try

                If LineStatus = "OPEN" Then
                    Me.dgvInvoiceHeaders.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                    Me.dgvInvoiceHeaders.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
                ElseIf LineStatus = "CLOSED" Then
                    Me.dgvInvoiceHeaders.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                    Me.dgvInvoiceHeaders.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
                Else
                    Me.dgvInvoiceHeaders.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                    Me.dgvInvoiceHeaders.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
                End If

                RowIndex = RowIndex + 1
            Next
        End If
    End Sub

    Public Sub LoadCustomer()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerID FROM CustomerList WHERE DivisionID <> @DivisionID ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CustomerList")
        cboCustomerID.DataSource = ds1.Tables("CustomerList")
        cboCustomerID.DisplayMember = "CustomerID"
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerName FROM CustomerList WHERE DivisionID <> @DivisionID ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerName.DataSource = ds2.Tables("CustomerList")
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

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub ClearVariables()
        StatusFilter = ""
        DateFilter = ""
        CustomerFilter = ""
    End Sub

    Public Sub ClearData()
        cboCustomerName.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboDay.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        cboTime.SelectedIndex = -1

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboCustomerID.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        ClearDatagrid()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomer()
        LoadCustomerName()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvInvoiceHeaders_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceHeaders.CellDoubleClick
        'Bring up Invoice
        Dim RowInvoiceNumber, RowSONumber, RowShipmentNumber As Integer
        Dim RowDivision, RowCustomer, CustomerEmail As String

        Dim RowIndex As Integer = Me.dgvInvoiceHeaders.CurrentCell.RowIndex

        RowInvoiceNumber = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
        RowShipmentNumber = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowDivision = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value
        RowCustomer = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("CustomerIDColumn").Value

        'Get SO Number from Invoice
        Dim SONumberStatement As String = "SELECT SalesOrderNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim SONumberCommand As New SqlCommand(SONumberStatement, con)
        SONumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
        SONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            RowSONumber = CInt(SONumberCommand.ExecuteScalar)
        Catch ex As Exception
            RowSONumber = 0
        End Try
        con.Close()

        Dim CustomerEmailStatement As String = "SELECT InvoiceEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
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
    End Sub

    Private Sub dgvInvoiceHeaders_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceHeaders.CellValueChanged
        If Me.dgvInvoiceHeaders.RowCount <> 0 Then
            Dim LineInvoiceNumber As Integer = 0
            Dim LineCustomerID As String = ""
            Dim LineEmailType As String = ""
            Dim LineEmailDay As String = ""
            Dim LineEmailTime As String = ""
            Dim LineInvoiceEmailAddress As String = ""
            Dim LineCertEmailAddress As String = ""
            Dim LineDivisionID As String = ""

            Dim RowIndex As Integer = Me.dgvInvoiceHeaders.CurrentCell.RowIndex

            LineInvoiceNumber = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            LineCustomerID = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("CustomerIDColumn").Value
            LineEmailDay = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("EmailDayColumn").Value
            LineEmailTime = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("EmailTimeColumn").Value
            LineInvoiceEmailAddress = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("InvoiceEmailAddressColumn").Value
            LineCertEmailAddress = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("CertEmailAddressColumn").Value
            LineDivisionID = Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("DivisionIDColumn").Value

            If LineInvoiceEmailAddress = "" And LineCertEmailAddress = "" Then
                LineEmailType = "NONE"
            ElseIf LineInvoiceEmailAddress <> "" And LineCertEmailAddress = "" Then
                LineEmailType = "INVOICE"
            ElseIf LineInvoiceEmailAddress = "" And LineCertEmailAddress <> "" Then
                LineEmailType = "CERTS"
            ElseIf LineInvoiceEmailAddress <> "" And LineCertEmailAddress <> "" Then
                LineEmailType = "BOTH"
            Else
                LineEmailType = "NONE"
            End If

            Me.dgvInvoiceHeaders.Rows(RowIndex).Cells("EmailTypeColumn").Value = LineEmailType

            Try
                'UPDATE Invoice Header Table
                cmd = New SqlCommand("UPDATE InvoiceEmailLog SET EmailDay = @EmailDay, EmailTime = @EmailTime, InvoiceEmailAddress = @InvoiceEmailAddress, CertEmailAddress = @CertEmailAddress, EmailType = @EmailType WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID AND CustomerID = @CustomerID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = LineInvoiceNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = LineDivisionID
                    .Add("@CustomerID", SqlDbType.VarChar).Value = LineCustomerID
                    .Add("@EmailDay", SqlDbType.VarChar).Value = LineEmailDay
                    .Add("@EmailTime", SqlDbType.VarChar).Value = LineEmailTime
                    .Add("@InvoiceEmailAddress", SqlDbType.VarChar).Value = LineInvoiceEmailAddress
                    .Add("@CertEmailAddress", SqlDbType.VarChar).Value = LineCertEmailAddress
                    .Add("@EmailType", SqlDbType.VarChar).Value = LineEmailType

                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try
        End If
    End Sub

    Private Sub dgvInvoiceHeaders_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvInvoiceHeaders.ColumnHeaderMouseClick
        LoadFormatting()
    End Sub

    Private Sub dgvInvoiceHeaders_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvInvoiceHeaders.CurrentCellDirtyStateChanged
        If dgvInvoiceHeaders.IsCurrentCellDirty Then
            dgvInvoiceHeaders.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvInvoiceHeaders_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvInvoiceHeaders.Sorted
        LoadFormatting()
    End Sub

    Private Sub cmdCloseInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseInvoice.Click
        Dim RowStatus, RowDivision, RowTime As String
        Dim RowInvoiceNumber As Integer = 0

        If Me.dgvInvoiceHeaders.RowCount > 0 Then
            For Each row As DataGridViewRow In Me.dgvInvoiceHeaders.SelectedRows
                Try
                    RowInvoiceNumber = row.Cells("InvoiceNumberColumn").Value
                Catch ex As Exception
                    RowInvoiceNumber = 0
                End Try
                Try
                    RowDivision = row.Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivision = ""
                End Try
                Try
                    RowStatus = row.Cells("EmailStatusColumn").Value
                Catch ex As Exception
                    RowStatus = ""
                End Try
                Try
                    RowTime = row.Cells("EmailTimeColumn").Value
                Catch ex As Exception
                    RowTime = ""
                End Try

                'Write Data to Invoice Header Database Table
                cmd = New SqlCommand("UPDATE InvoiceEmailLog SET EmailStatus = 'CLOSED' WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID AND EmailStatus = @EmailStatus AND EmailTime = @EmailTime", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@EmailStatus", SqlDbType.VarChar).Value = RowStatus
                    .Add("@EmailTime", SqlDbType.VarChar).Value = RowTime
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next

            ShowDataByFilters()
        End If
    End Sub

    Private Sub cmdReopenInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReopenInvoice.Click
        Dim RowStatus As String = ""
        Dim RowDivision As String = ""
        Dim RowInvoiceNumber As Integer = 0
        Dim RowTime As String = ""

        If cboTime.Text = "" Or cboDay.Text = "" Then
            MsgBox("You must enter a day and time.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Me.dgvInvoiceHeaders.RowCount > 0 Then
            For Each row As DataGridViewRow In Me.dgvInvoiceHeaders.SelectedRows
                Try
                    RowInvoiceNumber = row.Cells("InvoiceNumberColumn").Value
                Catch ex As Exception
                    RowInvoiceNumber = 0
                End Try
                Try
                    RowDivision = row.Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivision = ""
                End Try
                Try
                    RowStatus = row.Cells("EmailStatusColumn").Value
                Catch ex As Exception
                    RowStatus = ""
                End Try
                Try
                    RowTime = row.Cells("EmailTimeColumn").Value
                Catch ex As Exception
                    RowTime = ""
                End Try

                'Write Data to Invoice Header Database Table
                cmd = New SqlCommand("UPDATE InvoiceEmailLog SET EmailStatus = 'OPEN', EmailDay = @EmailDay, EmailTime = @EmailTime WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID AND EmailStatus = @EmailStatus AND EmailTime = @OldEmailTime", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                    .Add("@EmailStatus", SqlDbType.VarChar).Value = RowStatus
                    .Add("@EmailDay", SqlDbType.VarChar).Value = cboDay.Text
                    .Add("@EmailTime", SqlDbType.VarChar).Value = cboTime.Text
                    .Add("@OldEmailTime", SqlDbType.VarChar).Value = RowTime
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next

            ShowDataByFilters()
        End If
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearDatagrid()
        ClearVariables()
        ClearData()
    End Sub
End Class