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
Public Class ARPaymentReversal
    Inherits System.Windows.Forms.Form

    Dim PaymentLineNumber, NextGLNumber, LastGLNumber, LineARInvoiceNumber As Integer
    Dim LinePaymentAmount, InvoiceAppliedAmount, NewAppliedAmount, TotalPaymentAmount As Double
    Dim LineDivision, GetBankAccountType, BankAccount, LineCustomerID, CustomerClass, ARAccount As String
    Dim strInvoiceNumber As String = ""

    Dim TodaysDate As Date

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim isloaded = False

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

    Private Sub ARPaymentReversal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isloaded = True
        LoadCurrentDivision()

        TodaysDate = Today.ToShortDateString()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
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

    Public Sub ClearDataInDatagrid()
        dgvARPaymentLog.DataSource = Nothing
    End Sub

    Public Sub ShowPaymentLogByCustomer()
        cmd = New SqlCommand("SELECT * FROM ARPaymentLog WHERE CustomerID = @CustomerID AND PaymentStatus = @PaymentStatus", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = "POSTED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ARPaymentLog")
        dgvARPaymentLog.DataSource = ds.Tables("ARPaymentLog")
        con.Close()
    End Sub

    Public Sub ShowPaymentLines()
        cmd = New SqlCommand("SELECT * FROM ARPaymentLines WHERE PaymentID = @PaymentID", con)
        cmd.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ARPaymentLines")
        dgvPaymentLines.DataSource = ds1.Tables("ARPaymentLines")
        con.Close()
    End Sub

    Public Sub LoadCustomer()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerID FROM CustomerList WHERE DivisionID <> @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        Else
            cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerID.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerName FROM CustomerList WHERE DivisionID <> @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        Else
            cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        cboCustomerName.DataSource = ds3.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadPaymentNumber()
        cmd = New SqlCommand("SELECT PaymentID FROM ARPaymentLog WHERE CustomerID = @CustomerID AND PaymentStatus = @PaymentStatus ORDER BY PaymentID DESC", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = "POSTED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ARPaymentLog")
        cboPaymentID.DataSource = ds3.Tables("ARPaymentLog")
        con.Close()
        cboPaymentID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        If cboDivisionID.Text = "ADM" Then
            Dim CustomerID1Statement As String = "SELECT MIN (CustomerID) FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID <> @DivisionID"
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
            Dim CustomerName1Statement As String = "SELECT MIN(CustomerName) FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID <> @DivisionID"
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

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isloaded Then
            LoadCustomer()
            LoadCustomerName()
            ClearDataInDatagrid()
        End If
    End Sub

    Private Sub cmdViewByCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByCustomer.Click
        ShowPaymentLogByCustomer()
    End Sub

    Private Sub cboPaymentID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentID.SelectedIndexChanged
        If isloaded Then
            ShowPaymentLines()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If canPrint() Then
            GDS = ds
            Using NewPrintARPaymentLogFiltered As New PrintARPaymentLogFiltered
                Dim Result = NewPrintARPaymentLogFiltered.ShowDialog()
            End Using
        End If
    End Sub

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboPaymentID.Text) Then
            MessageBox.Show("You must select a payment ID", "Select a payment ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPaymentID.Focus()
            Return False
        End If
        If cboPaymentID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid payment ID", "Enter a valid paymeny ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPaymentID.SelectAll()
            cboPaymentID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdReverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReverse.Click
        If canReverse() Then
            'Reverse AP Check and reset voucher
            Dim ARPaymentLogStatus As String = ""
            Dim PaymentCustomerID As String = ""

            'Check to see if AR Customer Payment and AR Payment Log is POSTED
            Dim ARCustomerPayStatusStatement As String = "SELECT PaymentStatus FROM ARPaymentLog WHERE PaymentID = @PaymentID"
            Dim ARCustomerPayStatusCommand As New SqlCommand(ARCustomerPayStatusStatement, con)
            ARCustomerPayStatusCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)

            Dim PaymentCustomerIDStatement As String = "SELECT CustomerID FROM ARPaymentLog WHERE PaymentID = @PaymentID"
            Dim PaymentCustomerIDCommand As New SqlCommand(PaymentCustomerIDStatement, con)
            PaymentCustomerIDCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ARPaymentLogStatus = CStr(ARCustomerPayStatusCommand.ExecuteScalar)
            Catch ex As Exception
                ARPaymentLogStatus = "OPEN"
            End Try
            Try
                PaymentCustomerID = CStr(PaymentCustomerIDCommand.ExecuteScalar)
            Catch ex As Exception
                PaymentCustomerID = ""
            End Try
            con.Close()
            '*************************************************************************************
            If ARPaymentLogStatus = "POSTED" Then
                'Continue - you can reverse a payment that is posted
            Else
                MsgBox("This payment has not be posted yet. It must be posted first before reversing.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*************************************************************************************
            'Print Payment Record before deleting
            GlobalARPaymentID = Val(cboPaymentID.Text)
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintARPaymentReversal As New PrintARPaymentReversal
                Dim result = NewPrintARPaymentReversal.ShowDialog()
            End Using
            '*************************************************************************************
            For Each row As DataGridViewRow In dgvPaymentLines.Rows
                Try
                    LineARInvoiceNumber = row.Cells("LineARInvoiceNumberColumn").Value
                Catch ex As Exception
                    LineARInvoiceNumber = 0
                End Try
                Try
                    LinePaymentAmount = row.Cells("LinePaymentAmountColumn").Value
                Catch ex As Exception
                    LinePaymentAmount = 0
                End Try
                Try
                    LineDivision = row.Cells("DivisionIDColumn2").Value
                Catch ex As Exception
                    LineDivision = cboDivisionID.Text
                End Try
                Try
                    PaymentLineNumber = row.Cells("LineNumberColumn").Value
                Catch ex As Exception
                    PaymentLineNumber = 0
                End Try
                '*************************************************************************************
                'Get Invoice Payments Applied from Invoice Header Table
                Dim InvoiceAppliedAmountStatement As String = "SELECT PaymentsApplied FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                Dim InvoiceAppliedAmountCommand As New SqlCommand(InvoiceAppliedAmountStatement, con)
                InvoiceAppliedAmountCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = LineARInvoiceNumber
                InvoiceAppliedAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = LineDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    InvoiceAppliedAmount = CDbl(InvoiceAppliedAmountCommand.ExecuteScalar)
                Catch ex As Exception
                    InvoiceAppliedAmount = 0
                End Try
                con.Close()

                NewAppliedAmount = InvoiceAppliedAmount - LinePaymentAmount
                '************************************************************************************************************************
                'Reset Invoice so it can be selected again.
                Try
                    'UPDATE Invoice Header so it can be selected
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET PaymentsApplied = @PaymentsApplied, InvoiceStatus = @InvoiceStatus  WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = LineARInvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = LineDivision
                        .Add("@PaymentsApplied", SqlDbType.VarChar).Value = NewAppliedAmount
                        .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    '******************************************************************************************************************************************
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = LineARInvoiceNumber
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString
                    ErrorDivision = LineDivision
                    ErrorDescription = "Reverse AR Payment --- Invoice Header Update"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                strInvoiceNumber = CStr(LineARInvoiceNumber)
                '************************************************************************************************************************
                'Reset Invoice so it can be selected again.
                Try
                    'UPDATE Invoice Lines so it can be selected
                    cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineStatus = @LineStatus  WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = LineARInvoiceNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = LineDivision
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    '******************************************************************************************************************************************
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = LineARInvoiceNumber
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString
                    ErrorDivision = LineDivision
                    ErrorDescription = "Reverse AR Payment --- Invoice Line Update"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '************************************************************************************************************************
                'Get Bank Account for specific Payment ID
                Dim GetBankAccountStatement As String = "SELECT BankAccount FROM ARCustomerPayment WHERE PaymentID = @PaymentID AND PaymentLineNumber = @PaymentLineNumber AND DivisionID = @DivisionID"
                Dim GetBankAccountCommand As New SqlCommand(GetBankAccountStatement, con)
                GetBankAccountCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                GetBankAccountCommand.Parameters.Add("@PaymentLineNumber", SqlDbType.VarChar).Value = PaymentLineNumber
                GetBankAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = LineDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetBankAccountType = CStr(GetBankAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    GetBankAccountType = "Cash Receipts"
                End Try
                con.Close()

                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    'Get Customer Class for specific Customer
                    Dim GetCustomerClassStatement As String = "SELECT CustomerClass FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                    Dim GetCustomerClassCommand As New SqlCommand(GetCustomerClassStatement, con)
                    GetCustomerClassCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = PaymentCustomerID
                    GetCustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = LineDivision

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CustomerClass = CStr(GetCustomerClassCommand.ExecuteScalar)
                    Catch ex As Exception
                        CustomerClass = "CANADIAN"
                    End Try
                    con.Close()
                Else
                    CustomerClass = "STANDARD"
                End If
                '************************************************************************************************************************
                'Write to Audit Trail Table
                Dim AuditComment As String = ""
                Dim AuditPaymentNumber As Integer = 0
                Dim strPaymentNumber As String = ""
                Dim AuditInvoiceNumber As String = ""

                AuditInvoiceNumber = CStr(LineARInvoiceNumber)
                AuditComment = "AR Payment #" + strPaymentNumber + " for Invoice # " + AuditInvoiceNumber + "was deleted on " + TodaysDate

                Try
                    cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@AuditDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@AuditType", SqlDbType.VarChar).Value = "AR Reversal - DELETION"
                        .Add("@AuditAmount", SqlDbType.VarChar).Value = TotalPaymentAmount
                        .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = AuditInvoiceNumber
                        .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    '******************************************************************************************************************************************
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = LineARInvoiceNumber
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Reverse AR Payment --- Audit Trail failure"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*************************************************************************************************************************
                'Post to GL one transaction (invoice) at a time
                '************************************************************************************************************************
                If GetBankAccountType = "Cash Receipts" Then
                    BankAccount = "10400"
                ElseIf GetBankAccountType = "Canadian Checking" Then
                    BankAccount = "C$10200"
                ElseIf GetBankAccountType = "Checking" Then
                    BankAccount = "10200"
                ElseIf GetBankAccountType = "Other" Then
                    BankAccount = "10500"
                Else
                    BankAccount = "10400"
                End If

                If CustomerClass = "CANADIAN" Then
                    ARAccount = "C$11000"
                Else
                    ARAccount = "11000"
                End If
                '*************************************************************************************
                'Define Post Division
                Dim PostDivision As String = ""

                If LineDivision = "TFP" Then
                    PostDivision = "TWD"
                Else
                    PostDivision = LineDivision
                End If
                '*************************************************************************************
                'Reverse GL Check Posting
                Try
                    'Command to write to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount, GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount, @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = BankAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AR Cash Receipts - Reversal"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpPostDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LinePaymentAmount
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "AR Payment Reversal - Customer " + PaymentCustomerID
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = PaymentLineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    '******************************************************************************************************************************************
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = LineARInvoiceNumber
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Reverse AR Payment --- G/L Posting failure (Credit)"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*******************************************************************************************************
                Try
                    'Command to write LineAmount to Receivables
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AR Cash Receipts - Reversal"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpPostDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LinePaymentAmount
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "AR Payment Reversal - Customer " + PaymentCustomerID
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = PaymentLineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = LineARInvoiceNumber
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Reverse AR Payment --- G/L Posting failure (Debit)"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*************************************************************************************************************************
                Try
                    'Delete AR Customer Payment Record
                    cmd = New SqlCommand("DELETE FROM ARCustomerPayment WHERE PaymentID = @PaymentID AND PaymentLineNumber = @PaymentLineNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@PaymentLineNumber", SqlDbType.VarChar).Value = PaymentLineNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = LineDivision
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    '******************************************************************************************************************************************
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = LineARInvoiceNumber
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString
                    ErrorDivision = LineDivision
                    ErrorDescription = "Reverse AR Payment --- Delete A/R Payment"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Next

            '**********************************
            'End of Ledger Entry
            '**********************************

            'Update AR Payment Log Entry
            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE ARPaymentLog SET PaymentStatus = @PaymentStatus WHERE PaymentID = @PaymentID", con)

                With cmd.Parameters
                    .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                    .Add("@PaymentStatus", SqlDbType.VarChar).Value = "REVERSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempInvoiceNumber As Integer = 0
                Dim strInvoiceNumber As String
                TempInvoiceNumber = Val(cboPaymentID.Text)
                strInvoiceNumber = CStr(TempInvoiceNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Reverse AR Payment --- G/L Posting failure"
                ErrorReferenceNumber = "Payment # " + strInvoiceNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            MsgBox("Payment has been reversed.", MsgBoxStyle.OkOnly)

            cboPaymentID.SelectedIndex = -1
            cboCustomerID.SelectedIndex = -1
            cboCustomerName.SelectedIndex = -1

            ShowPaymentLogByCustomer()
            ShowPaymentLines()
        End If
    End Sub

    Private Function canReverse() As Boolean
        If String.IsNullOrEmpty(cboPaymentID.Text) Then
            MsgBox("You must have a valid Payment ID selected.", MsgBoxStyle.OkOnly)
            cboPaymentID.Focus()
            Return False
        End If
        If cboPaymentID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid payment ID", "Enter a valid payment ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPaymentID.SelectAll()
            cboPaymentID.Focus()
            Return False
        End If
        'Prompt before Saving
        Dim button As DialogResult = MessageBox.Show("Do you wish to Reverse this payment?", "REVERSE CHECK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboPaymentID.Text = ""
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""

        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboPaymentID.SelectedIndex = -1

        ClearDataInDatagrid()
        ShowPaymentLines()
    End Sub

    ''sends the error message to the database given it the description of the failure, reference ID and comment
    Private Sub sendErrorToDataBase(ByVal errorDescription As String, ByVal errorReferenceNumber As String, ByVal errorMessage As String)
        If errorMessage.Length > 300 Then
            errorMessage = errorMessage.Substring(0, 300)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division)", con)

        With cmd.Parameters
            .Add("@Date", SqlDbType.Date).Value = TodaysDate
            .Add("@Description", SqlDbType.VarChar).Value = errorDescription
            .Add("@ErrorReference", SqlDbType.VarChar).Value = errorReferenceNumber
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@Comment", SqlDbType.VarChar).Value = errorMessage
            .Add("@Division", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
        LoadPaymentNumber()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub dgvARPaymentLog_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvARPaymentLog.CellClick
        If Me.dgvARPaymentLog.RowCount <> 0 Then
            Dim RowPaymentNumber As Integer
            Dim RowIndex As Integer = Me.dgvARPaymentLog.CurrentCell.RowIndex

            RowPaymentNumber = Me.dgvARPaymentLog.Rows(RowIndex).Cells("PaymentIDColumn").Value

            cboPaymentID.Text = RowPaymentNumber
        End If
    End Sub
End Class