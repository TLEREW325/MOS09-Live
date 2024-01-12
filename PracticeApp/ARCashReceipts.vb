Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
'Imports CrystalDecisions.Windows.Forms
'Imports CrystalDecisions.ReportSource
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports WIA
Imports PdfSharp.Pdf
Imports System.Threading
Imports iTextSharp.text.Image
Imports PdfSharp
Imports document = iTextSharp.text.Document
Imports System.Drawing
Imports System.ComponentModel
Imports iTextSharp
Imports System.Reflection

Public Class ARCashReceipts
    Inherits System.Windows.Forms.Form

    'Remote
    Dim isLoaded As Boolean = False
    Dim dir As New System.IO.DirectoryInfo("\\TFP-FS\CashReceipts\UploadedCashReceipts\")
    Dim FilesToDelete As List(Of String)
    Dim bgPDF As BackgroundWorker
    Dim bgAppendPDF As BackgroundWorker
    Dim LoadingScreen As New Loading
    Dim ShipmentNumber As Integer = 0

    ''Remote WIA variables
    Dim remoteWIA As MOSRemoteWIA
    Dim bgwkRemoteWIA As BackgroundWorker
    Dim frm As System.Windows.Forms.Form
    Dim remoteCheck As Boolean = False
    Dim TodaysDate As Date = Now()

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim LastBatchNumber, NextBatchNumber, ARPaymentLineNumber, CountPaymentLines, InvoiceNumber, LastLineNumber, NextLineNumber, NextTransactionNumber, LastTransactionNumber, ARTransactionKey As Integer
    Dim InvoicePaymentsApplied, DeletePaymentAmount, NewTotalPayments, PaymentAmount, TotalPaymentAmount, ReturnTotal, TotalPayments, OpenBalance, TotalDiscountApplied, TotalPaymentsApplied As Double
    Dim BankAccount, CustomerName, PaymentDate, PaymentType, PaymentStatus, CustomerID, PaymentNumber, InvoiceStatus, CardDate, CheckComment, CreditComment, ReferenceNumber, CardNumber, CheckNumber, AuthorizationNumber As String
    Dim AdjustmentAmount, InvoiceTotalPayments, BatchTotal, InvoiceTotal, InvoiceAmountOpen, TotalAmountDistributed, LineAmountOpen As Double
    Dim InvoiceDate, TenderType, CardType As String
    Dim PaymentDivision As String = ""
    Dim LineBankAccount As String = ""
    Dim CustomerHold As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ARCashReceipts_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalARDivisionCode = cboDivisionID.Text
        GlobalNewARBatchNumber = Val(txtBatchNumber.Text)
    End Sub

    Private Sub ARCashReceipts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If GlobalARDivisionCode = "ADM" Then
            cboDivisionID.Text = GlobalARDivisionCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = GlobalARDivisionCode
            cboDivisionID.Enabled = False
        End If

        If My.Computer.Name.StartsWith("TFP") Then
            cmdRemoteScan.Visible = True
            cmdScan.Visible = False
            AppendCashReceiptToolStripMenuItem.Enabled = False
            ReUploadReceiptToolStripMenuItem.Enabled = False
        Else
            cmdRemoteScan.Visible = False
            cmdScan.Visible = True
            AppendCashReceiptToolStripMenuItem.Enabled = True
            ReUploadReceiptToolStripMenuItem.Enabled = True
        End If

        LoadCustomerList()
        LoadCustomerName()
        LoadBankAccountTypeAll()
        LoadPaymentID()
        ShowData()
        ClearData()
        ClearVariables()

        cmdScan.Enabled = False
        cmdUploadReceipt.Enabled = False
        cmdViewReceipt.Enabled = False
        ReUploadReceiptToolStripMenuItem.Enabled = False

        If GlobalNewARBatchNumber > 0 Then
            txtBatchNumber.Text = GlobalNewARBatchNumber
            dtpPaymentDate.Text = GlobalARBatchDate
        Else
            txtBatchNumber.Clear()
            cboBankAccount.SelectedIndex = -1
        End If

        If cboPaymentID.Text = "" Or cboPaymentID.SelectedIndex = -1 Then
            cmdViewReceipt.Enabled = False
            cmdPrint.Enabled = False
            cmdScan.Enabled = False
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

    Public Sub TFPErrorLogUpdate()
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

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE CustomerID = @CustomerID AND InvoiceTotal <> PaymentsApplied AND InvoiceStatus = @InvoiceStatus ORDER BY DivisionID, InvoiceDate", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        'cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderQuery")
        dgvInvoiceHeaderQuery.DataSource = ds.Tables("InvoiceHeaderQuery")
        cboInvoiceNumber.DataSource = ds.Tables("InvoiceHeaderQuery")
        con.Close()

        Me.dgvInvoiceHeaderQuery.Columns("DivisionIDColumn").DefaultCellStyle.ForeColor = Color.Blue

        LoadLineBankAccount()
    End Sub

    Public Sub LoadCustomerList()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID <> @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        Else
            cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CustomerList")
        cboCustomerID.DataSource = ds1.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadReturnNumber()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT ReturnNumber FROM ReturnProductHeaderTable WHERE DivisionID <> @DivisionID AND ReturnStatus = @ReturnStatus AND CustomerID = @CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        Else
            cmd = New SqlCommand("SELECT ReturnNumber FROM ReturnProductHeaderTable WHERE DivisionID = @DivisionID AND ReturnStatus = @ReturnStatus AND CustomerID = @CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        End If
 
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ReturnProductHeaderTable")
        cboCreditMemo.DataSource = ds2.Tables("ReturnProductHeaderTable")
        con.Close()
        cboCreditMemo.SelectedIndex = -1
    End Sub

    Public Sub LoadPaymentID()
        cmd = New SqlCommand("SELECT PaymentID FROM ARPaymentLog WHERE ARBatchNumber = @ARBatchNumber", con)
        cmd.Parameters.Add("@ARBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        'cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ARPaymentLog")
        cboPaymentID.DataSource = ds3.Tables("ARPaymentLog")
        con.Close()
        cboPaymentID.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccounts()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber NOT LIKE 'C$%'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "GLAccounts")
        cboGLAccountNumber.DataSource = ds4.Tables("GLAccounts")
        cboGLAccountDescription.DataSource = ds4.Tables("GLAccounts")
        con.Close()
        cboGLAccountNumber.SelectedIndex = -1
        cboGLAccountDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadAdjustmentInvoiceNumber()
        cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE CustomerID = @CustomerID AND InvoiceStatus = @InvoiceStatus", con)
        'cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "InvoiceHeaderTable")
        cboInvoiceAdjustmentNumber.DataSource = ds5.Tables("InvoiceHeaderTable")
        con.Close()
        cboInvoiceAdjustmentNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadBankAccountTypeAll()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT BAID FROM BankAccountTypes", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "BankAccountTypes")
        cboBankAccount.DataSource = ds6.Tables("BankAccountTypes")
        con.Close()
        cboBankAccount.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID <> @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        Else
            cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd
        myAdapter7.Fill(ds7, "CustomerList")
        cboCustomerName.DataSource = ds7.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
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

    Public Sub LoadOnHoldStatus()
        If cboDivisionID.Text = "ADM" Then
            'Do nothing
            lblOnHoldStatus.Visible = False
        Else
            Dim CustomerHoldStatement As String = "SELECT OnHoldStatus FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerHoldCommand As New SqlCommand(CustomerHoldStatement, con)
            CustomerHoldCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CustomerHoldCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerHold = CStr(CustomerHoldCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerHold = ""
            End Try
            con.Close()

            If CustomerHold = "YES" Then
                lblOnHoldStatus.Visible = True
            Else
                lblOnHoldStatus.Visible = False
            End If
        End If
    End Sub

    Public Sub LoadLineBankAccount()
        If Me.dgvInvoiceHeaderQuery.RowCount <> 0 Then
            Dim TempDivisionID As String = ""
            Dim TempBankAccount As String = ""
            Dim GetBankAccount As String = ""
            Dim EmailSentField As String = ""

            Dim RowIndex As Integer = 0
            Dim RowCount As Integer = Me.dgvInvoiceHeaderQuery.RowCount

            For i As Integer = 1 To RowCount
                TempDivisionID = Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("DivisionIDColumn").Value
                Try
                    EmailSentField = Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("EmailSentColumn").Value
                Catch ex As Exception
                    EmailSentField = ""
                End Try

                If EmailSentField = "" Then
                    'Skip
                Else
                    Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("InvoiceNumberColumn").Style.ForeColor = Color.Blue
                End If

                'Get bank account from customer
                Dim GetBankAccountStatement As String = "SELECT BankAccount FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim GetBankAccountCommand As New SqlCommand(GetBankAccountStatement, con)
                GetBankAccountCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                GetBankAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = TempDivisionID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetBankAccount = CStr(GetBankAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    GetBankAccount = ""
                End Try
                con.Close()

                If GetBankAccount = "" Then
                    If TempDivisionID = "TFF" Or TempDivisionID = "TOR" Or TempDivisionID = "ALB" Then
                        Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("BankAccountColumn").Value = "Canadian Checking"
                    ElseIf TempDivisionID = "TWD" Or TempDivisionID = "TFP" Then
                        Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("BankAccountColumn").Value = "Checking"
                    Else
                        Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("BankAccountColumn").Value = "Cash Receipts"
                    End If
                Else
                    Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("BankAccountColumn").Value = GetBankAccount
                End If

                RowIndex = RowIndex + 1
            Next i
        End If
    End Sub

    Private Sub dgvInvoiceHeaderQuery_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceHeaderQuery.CellDoubleClick
        Dim RowInvoiceNumber As Integer = 0
        Dim RowDivisionID As String = ""
        Dim RowSONumber As Integer = 0
        Dim RowShipmentNumber As Integer = 0
        Dim RowCustomerEmail As String = ""

        If Me.dgvInvoiceHeaderQuery.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvInvoiceHeaderQuery.CurrentCell.RowIndex

            RowInvoiceNumber = Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            RowDivisionID = Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("DivisionIDColumn").Value
            RowSONumber = Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value

            'Get Shipment Number
            Dim GetShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim GetShipmentNumberCommand As New SqlCommand(GetShipmentNumberStatement, con)
            GetShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
            GetShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID

            Dim GetCustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim GetCustomerEmailCommand As New SqlCommand(GetCustomerEmailStatement, con)
            GetCustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            GetCustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                RowShipmentNumber = CInt(GetShipmentNumberCommand.ExecuteScalar)
            Catch ex As Exception
                RowShipmentNumber = 0
            End Try
            Try
                RowCustomerEmail = CStr(GetCustomerEmailCommand.ExecuteScalar)
            Catch ex As Exception
                RowCustomerEmail = ""
            End Try
            con.Close()

            GlobalInvoiceNumber = RowInvoiceNumber
            GlobalDivisionCode = RowDivisionID
            EmailInvoiceCustomer = cboCustomerID.Text
            EmailSalesOrderNumber = RowSONumber
            EmailShipmentNumber = RowShipmentNumber
            EmailCustomerEmailAddress = RowCustomerEmail
            EmailStringInvoiceNumber = CStr(RowInvoiceNumber)

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
                    Dim Result = NewPrintInvoiceSingleRemote.ShowDialog()
                End Using
            Else
                Using NewPrintInvoicesingle As New PrintInvoiceSingle
                    Dim Result = NewPrintInvoicesingle.ShowDialog()
                End Using
            End If
        Else
            'Skip Update
        End If
    End Sub

    Private Sub dgvInvoiceHeaderQuery_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceHeaderQuery.CellValueChanged
        Dim RowOpenAmount As Double = 0

        If Me.dgvInvoiceHeaderQuery.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvInvoiceHeaderQuery.CurrentCell.RowIndex

            If Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("chkCheckPayment").Value = "CHECKED" Then
                Try
                    RowOpenAmount = Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("InvoiceAmountOpenColumn").Value
                Catch ex As Exception
                    RowOpenAmount = 0
                End Try

                RowOpenAmount = Math.Round(RowOpenAmount, 2)

                Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("PaymentEntryColumn").Value = RowOpenAmount
            Else
                'Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("PaymentEntryColumn").Value = 0
            End If
        Else
            'Skip Update
        End If
    End Sub

    Private Sub dgvInvoiceHeaderQuery_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvInvoiceHeaderQuery.ColumnHeaderMouseClick
        LoadLineBankAccount()
    End Sub

    Private Sub dgvInvoiceHeaderQuery_ColumnSortModeChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgvInvoiceHeaderQuery.ColumnSortModeChanged
        LoadLineBankAccount()
    End Sub

    Private Sub dgvInvoiceHeaderQuery_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvInvoiceHeaderQuery.CurrentCellDirtyStateChanged
        If dgvInvoiceHeaderQuery.IsCurrentCellDirty Then
            dgvInvoiceHeaderQuery.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Public Sub LoadTotals()
        TotalPaymentAmount = Val(txtPaymentAmount.Text)

        Dim TotalPaymentsAppliedStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE PaymentID = @PaymentID AND BatchNumber = @BatchNumber"
        Dim TotalPaymentsAppliedCommand As New SqlCommand(TotalPaymentsAppliedStatement, con)
        TotalPaymentsAppliedCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
        TotalPaymentsAppliedCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

        Dim TotalDiscountAppliedStatement As String = "SELECT SUM(DiscountAmount) FROM ARCustomerPayment WHERE PaymentID = @PaymentID AND BatchNumber = @BatchNumber"
        Dim TotalDiscountAppliedCommand As New SqlCommand(TotalDiscountAppliedStatement, con)
        TotalDiscountAppliedCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
        TotalDiscountAppliedCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalPaymentsApplied = CDbl(TotalPaymentsAppliedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalPaymentsApplied = 0
        End Try
        Try
            TotalDiscountApplied = CDbl(TotalDiscountAppliedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalDiscountApplied = 0
        End Try
        con.Close()

        TotalPaymentsApplied = Math.Round(TotalPaymentsApplied, 2)
        TotalPaymentAmount = Math.Round(TotalPaymentAmount, 2)
        TotalDiscountApplied = Math.Round(TotalDiscountApplied, 2)

        OpenBalance = TotalPaymentAmount - TotalPaymentsApplied - TotalDiscountApplied

        txtDiscountApplied.Text = FormatCurrency(TotalDiscountApplied, 2)
        txtPaymentApplied.Text = FormatCurrency(TotalPaymentsApplied, 2)
        txtDistributableAmount.Text = FormatCurrency(TotalPaymentAmount, 2)
        txtOpenBalance.Text = FormatCurrency(OpenBalance, 2)
    End Sub

    Public Sub LoadInvoiceData()
        'Get Invoice Division
        Dim GetInvoiceDivisionStatement As String = "SELECT DivisionID FROM InvoiceHeaderQuery WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim GetInvoiceDivisionCommand As New SqlCommand(GetInvoiceDivisionStatement, con)
        GetInvoiceDivisionCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PaymentDivision = CStr(GetInvoiceDivisionCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentDivision = cboDivisionID.Text
        End Try
        con.Close()

        Dim InvoiceTotalStatement As String = "SELECT InvoiceTotal FROM InvoiceHeaderQuery WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceTotalCommand As New SqlCommand(InvoiceTotalStatement, con)
        InvoiceTotalCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = PaymentDivision

        Dim InvoiceDateStatement As String = "SELECT InvoiceDate FROM InvoiceHeaderQuery WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceDateCommand As New SqlCommand(InvoiceDateStatement, con)
        InvoiceDateCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = PaymentDivision

        Dim InvoiceAmountOpenStatement As String = "SELECT InvoiceAmountOpen FROM InvoiceHeaderQuery WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceAmountOpenCommand As New SqlCommand(InvoiceAmountOpenStatement, con)
        InvoiceAmountOpenCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceAmountOpenCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = PaymentDivision

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            InvoiceTotal = CDbl(InvoiceTotalCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceTotal = 0
        End Try
        Try
            InvoiceDate = CStr(InvoiceDateCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceDate = ""
        End Try
        Try
            InvoiceAmountOpen = CDbl(InvoiceAmountOpenCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceAmountOpen = 0
        End Try
        con.Close()

        InvoiceTotal = Math.Round(InvoiceTotal, 2)
        InvoiceAmountOpen = Math.Round(InvoiceAmountOpen, 2)

        txtInvoiceDate.Text = InvoiceDate
        txtInvoiceAmountOpen.Text = FormatCurrency(InvoiceAmountOpen, 2)
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Public Sub ClearData()
        txtCheckComment.Refresh()
        txtCheckNumber.Refresh()
        txtPaymentAmount.Refresh()
        txtCreditCardComment.Refresh()
        txtDiscountApplied.Refresh()
        txtOpenBalance.Refresh()
        txtPaymentApplied.Refresh()
        txtReferenceNumber.Refresh()
        txtDistributableAmount.Refresh()
        txtInvoiceAmountOpen.Refresh()
        txtAuthorization.Refresh()
        txtCardDate.Refresh()
        txtCardNumber.Refresh()
        txtDiscountApplied.Refresh()
        txtInvoiceDate.Refresh()
        txtInvoiceDiscountApplied.Refresh()
        txtInvoicePaymentApplied.Refresh()
        txtInvoiceTotal.Refresh()
        txtOpenBalance.Refresh()
        txtPaymentAmount.Refresh()

        cboCardType.Text = ""
        cboCreditMemo.Text = ""
        cboInvoiceNumber.Text = ""
        cboPaymentID.Text = ""
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""

        cboCardType.Refresh()
        cboCustomerID.Refresh()
        cboCustomerName.Refresh()
        cboTenderType.Refresh()
        cboInvoiceNumber.Refresh()
        cboPaymentID.Refresh()
        cboCreditMemo.Refresh()
        cboBankAccount.Refresh()

        cboCardType.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboTenderType.SelectedIndex = -1
        cboInvoiceNumber.SelectedIndex = -1
        cboPaymentID.SelectedIndex = -1
        cboCreditMemo.SelectedIndex = -1
        cboGLAccountNumber.SelectedIndex = -1
        cboGLAccountDescription.SelectedIndex = -1
        cboBankAccount.SelectedIndex = -1

        txtCheckComment.Clear()
        txtCheckNumber.Clear()
        txtPaymentAmount.Clear()
        txtCreditCardComment.Clear()
        txtDiscountApplied.Clear()
        txtOpenBalance.Clear()
        txtPaymentApplied.Clear()
        txtReferenceNumber.Clear()
        txtDistributableAmount.Clear()
        txtInvoiceAmountOpen.Clear()
        txtAuthorization.Clear()
        txtCardDate.Clear()
        txtCardNumber.Clear()
        txtDiscountApplied.Clear()
        txtInvoiceDate.Clear()
        txtInvoiceDiscountApplied.Clear()
        txtInvoicePaymentApplied.Clear()
        txtInvoiceTotal.Clear()
        txtOpenBalance.Clear()
        txtPaymentAmount.Clear()
        txtAdjustmentAmount.Clear()

        chkAdjustment.Checked = False

        lblOnHoldStatus.Visible = False

        cboPaymentID.Focus()

        dtpPaymentDate.Text = GlobalARBatchDate
        cboTenderType.Text = "Check"

        cmdApplyPayment.Enabled = False
    End Sub

    Public Sub ClearVariables()
        LastLineNumber = 0
        NextLineNumber = 0
        NextTransactionNumber = 0
        LastTransactionNumber = 0
        PaymentAmount = 0
        TotalPaymentAmount = 0
        ReturnTotal = 0
        TotalPayments = 0
        OpenBalance = 0
        TotalDiscountApplied = 0
        TotalPaymentsApplied = 0
        PaymentDate = ""
        PaymentType = ""
        PaymentStatus = ""
        CustomerID = ""
        PaymentNumber = ""
        InvoiceStatus = ""
        InvoiceTotal = 0
        InvoiceAmountOpen = 0
        TotalAmountDistributed = 0
        LineAmountOpen = 0
        InvoiceDate = ""
        CountPaymentLines = 0
        InvoiceNumber = 0
        InvoiceTotalPayments = 0
        ARPaymentLineNumber = 0
        DeletePaymentAmount = 0
        InvoicePaymentsApplied = 0
        AdjustmentAmount = 0
        NextBatchNumber = 0
        LastBatchNumber = 0
        BankAccount = ""
        LineBankAccount = ""
        PaymentDivision = ""
        CustomerHold = ""
    End Sub

    Public Sub LoadPaymentData()
        Dim CustomerIDStatement As String = "SELECT CustomerID FROM ARPaymentLog WHERE PaymentID = @PaymentID"
        Dim CustomerIDCommand As New SqlCommand(CustomerIDStatement, con)
        CustomerIDCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
        CustomerIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PaymentAmountStatement As String = "SELECT PaymentAmount FROM ARPaymentLog WHERE PaymentID = @PaymentID"
        Dim PaymentAmountCommand As New SqlCommand(PaymentAmountStatement, con)
        PaymentAmountCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
        PaymentAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PaymentDateStatement As String = "SELECT PaymentDate FROM ARPaymentLog WHERE PaymentID = @PaymentID"
        Dim PaymentDateCommand As New SqlCommand(PaymentDateStatement, con)
        PaymentDateCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
        PaymentDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PaymentTypeStatement As String = "SELECT PaymentType FROM ARPaymentLog WHERE PaymentID = @PaymentID"
        Dim PaymentTypeCommand As New SqlCommand(PaymentTypeStatement, con)
        PaymentTypeCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
        PaymentTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PaymentStatusStatement As String = "SELECT PaymentStatus FROM ARPaymentLog WHERE PaymentID = @PaymentID"
        Dim PaymentStatusCommand As New SqlCommand(PaymentStatusStatement, con)
        PaymentStatusCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
        PaymentStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID = CStr(CustomerIDCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerID = ""
        End Try
        Try
            PaymentAmount = CDbl(PaymentAmountCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentAmount = 0
        End Try
        Try
            PaymentDate = CStr(PaymentDateCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentDate = Today()
        End Try
        Try
            PaymentType = CStr(PaymentTypeCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentType = "Payment"
        End Try
        Try
            PaymentStatus = CStr(PaymentStatusCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentStatus = ""
        End Try
        con.Close()
        '***************************************************************************************
        Dim GetPaymentDataStatement As String = "SELECT * FROM ARCustomerPayment WHERE PaymentID = @PaymentID AND BatchNumber = @BatchNumber"
        Dim GetPaymentDataCommand As New SqlCommand(GetPaymentDataStatement, con)
        GetPaymentDataCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
        GetPaymentDataCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetPaymentDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("TenderType")) Then
                TenderType = ""
            Else
                TenderType = reader.Item("TenderType")
            End If
            If IsDBNull(reader.Item("CheckNumber")) Then
                CheckNumber = ""
            Else
                CheckNumber = reader.Item("CheckNumber")
            End If
            If IsDBNull(reader.Item("ReferenceNumber")) Then
                ReferenceNumber = ""
            Else
                ReferenceNumber = reader.Item("ReferenceNumber")
            End If
            If IsDBNull(reader.Item("CheckComment")) Then
                CheckComment = ""
            Else
                CheckComment = reader.Item("CheckComment")
            End If
            If IsDBNull(reader.Item("CardType")) Then
                CardType = ""
            Else
                CardType = reader.Item("CardType")
            End If
            If IsDBNull(reader.Item("CardNumber")) Then
                CardNumber = ""
            Else
                CardNumber = reader.Item("CardNumber")
            End If
            If IsDBNull(reader.Item("CardDate")) Then
                CardDate = ""
            Else
                CardDate = reader.Item("CardDate")
            End If
            If IsDBNull(reader.Item("AuthorizationNumber")) Then
                AuthorizationNumber = ""
            Else
                AuthorizationNumber = reader.Item("AuthorizationNumber")
            End If
            If IsDBNull(reader.Item("CreditComment")) Then
                CreditComment = ""
            Else
                CreditComment = reader.Item("CreditComment")
            End If
            If IsDBNull(reader.Item("BankAccount")) Then
                BankAccount = ""
            Else
                BankAccount = reader.Item("BankAccount")
            End If
        Else
            TenderType = "Check"
            CheckNumber = ""
            ReferenceNumber = ""
            CheckComment = ""
            CardType = ""
            CardNumber = ""
            CardDate = ""
            AuthorizationNumber = ""
            CreditComment = ""
            BankAccount = "CASH RECEIPTS"
        End If
        reader.Close()
        con.Close()

        txtPaymentAmount.Text = PaymentAmount
        cboCustomerID.Text = CustomerID
        dtpPaymentDate.Text = PaymentDate
        cboTenderType.Text = TenderType
        txtCheckNumber.Text = CheckNumber
        txtReferenceNumber.Text = ReferenceNumber
        txtCheckComment.Text = CheckComment
        cboCardType.Text = CardType
        txtCardNumber.Text = CardNumber
        txtCardDate.Text = CardDate
        txtAuthorization.Text = AuthorizationNumber
        txtCreditCardComment.Text = CreditComment
        cboBankAccount.Text = BankAccount

        If PaymentType = "Payment" Then
            rdoPayment.Checked = True
        Else
            rdoCreditMemo.Checked = False
        End If

        If cboTenderType.Text = "" And cboCardType.Text = "" Then
            cboTenderType.Text = "Check"
        Else
            'Do nothing
        End If
    End Sub

    Public Sub LoadReturnAmount()
        Dim ReturnTotalStatement As String = "SELECT ReturnTotal FROM ReturnProductHeaderTable WHERE ReturnNumber = @ReturnNumber"
        Dim ReturnTotalCommand As New SqlCommand(ReturnTotalStatement, con)
        ReturnTotalCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboCreditMemo.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ReturnTotal = CDbl(ReturnTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ReturnTotal = 0
        End Try
        con.Close()

        ReturnTotal = Math.Round(ReturnTotal, 2)

        txtPaymentAmount.Text = ReturnTotal
    End Sub

    Private Sub cmdGeneratePaymentID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGeneratePaymentID.Click
        ClearData()
        ClearVariables()
        ShowData()

        If txtBatchNumber.Text = "" Then
            'Create new Batch
            'Find the next Batch Number to use
            Dim MAX1Statement As String = "SELECT MAX(BatchNumber) FROM ARProcessPaymentBatch"
            Dim MAX1Command As New SqlCommand(MAX1Statement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastBatchNumber = CInt(MAX1Command.ExecuteScalar)
            Catch ex As Exception
                LastBatchNumber = 22000000
            End Try
            con.Close()

            NextBatchNumber = LastBatchNumber + 1
            txtBatchNumber.Text = NextBatchNumber
            cboBankAccount.Text = "Cash Receipts"
            GlobalARBatchNumber = NextBatchNumber

            Try
                'Write Data to Batch Header Database Table
                cmd = New SqlCommand("Insert Into ARProcessPaymentBatch(BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, BankAccount)Values(@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @BankAccount)", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                    .Add("@BatchDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = "CASH RECEIPTS / CUSTOMER PAYMENT"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@BankAccount", SqlDbType.VarChar).Value = "Cash Receipts"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Write Data to Batch Header Database Table
                cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET BatchDate = @BatchDate, BatchAmount = @BatchAmount, BatchDescription = @BatchDescription, DivisionID = @DivisionID, BatchStatus = @BatchStatus, BankAccount = @BankAccount WHERE BatchNumber = @BatchNumber", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                    .Add("@BatchDate", SqlDbType.VarChar).Value = dtpPaymentDate
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = "CASH RECEIPTS / CUSTOMER PAYMENT"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@BankAccount", SqlDbType.VarChar).Value = "Cash Receipts"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Try
        Else
            'Do nothing
        End If

        'Find the next Payment ID to use
        Dim MAXStatement As String = "SELECT MAX(PaymentID) FROM ARPaymentLog"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastTransactionNumber = 88540000
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1
        cboPaymentID.Text = NextTransactionNumber

        'Write Data to AR Payment Log
        cmd = New SqlCommand("Insert Into ARPaymentLog(PaymentID, ARPaymentNumber, CustomerID, PaymentAmount, PaymentDate, DivisionID, PaymentType, ARBatchNumber, PaymentStatus) Values (@PaymentID, @ARPaymentNumber, @CustomerID, @PaymentAmount, @PaymentDate, @DivisionID, @PaymentType, @ARBatchNumber, @PaymentStatus)", con)

        With cmd.Parameters
            .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
            .Add("@ARPaymentNumber", SqlDbType.VarChar).Value = PaymentNumber
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtPaymentAmount.Text)
            .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@PaymentType", SqlDbType.VarChar).Value = ""
            .Add("@ARBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
            .Add("@PaymentStatus", SqlDbType.VarChar).Value = "OPEN"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        cmdScan.Enabled = True
        cmdUploadReceipt.Enabled = True
        cmdViewReceipt.Enabled = False
    End Sub

    Private Sub txtPaymentAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaymentAmount.TextChanged
        LoadTotals()
    End Sub

    Private Sub cboCreditMemo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCreditMemo.SelectedIndexChanged
        LoadReturnAmount()
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearAllToolStripMenuItem.Click
        ClearVariables()
        ClearData()
        ShowData()
    End Sub

    Private Sub txtBatchNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBatchNumber.TextChanged
        LoadPaymentID()
    End Sub

    Private Sub cboPaymentID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentID.SelectedIndexChanged
        LoadPaymentData()
        Dim text As String = cboPaymentID.Text
        Dim emptyBool As Boolean = String.IsNullOrEmpty(text)
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
        If cboPaymentID.Text = "" Or cboPaymentID.SelectedIndex = -1 Or emptyBool = True Then
            cmdViewReceipt.Enabled = False
            cmdPrint.Enabled = False
            cmdScan.Enabled = False
        End If
        If File.Exists(CashReceiptExists) Then
            cmdViewReceipt.Enabled = True
            ReUploadReceiptToolStripMenuItem.Enabled = True
            AppendCashReceiptToolStripMenuItem.Enabled = True
            cmdUploadReceipt.Enabled = False
            cmdScan.Enabled = False
        Else
            cmdViewReceipt.Enabled = False
            ReUploadReceiptToolStripMenuItem.Enabled = False
            AppendCashReceiptToolStripMenuItem.Enabled = False
            cmdUploadReceipt.Enabled = True
            cmdScan.Enabled = True
        End If

        If cboPaymentID.Text = "" Or cboPaymentID.SelectedIndex = -1 Then
            cmdViewReceipt.Enabled = False
            cmdPrint.Enabled = False
            cmdScan.Enabled = False
        End If
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
        LoadOnHoldStatus()
        ShowData()
    End Sub

    Private Sub cmdClearPaymentDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearPaymentDetails.Click
        ClearVariables()

        If Me.dgvInvoiceHeaderQuery.RowCount <> 0 Then
            For Each row As DataGridViewRow In dgvInvoiceHeaderQuery.Rows
                row.Cells("PaymentEntryColumn").Value = 0
                row.Cells("chkCheckPayment").Value = "UNCHECKED"
            Next

            Dim RowIndex As Integer = Me.dgvInvoiceHeaderQuery.CurrentCell.RowIndex

            Me.dgvInvoiceHeaderQuery.Rows(RowIndex).Cells("PaymentEntryColumn").Value = 0
        Else
            'Do nothing
        End If

        TotalPaymentAmount = Val(txtPaymentAmount.Text)
        TotalPayments = 0
        TotalDiscountApplied = 0
        OpenBalance = TotalPaymentAmount - TotalPayments - TotalDiscountApplied

        txtDiscountApplied.Text = FormatCurrency(TotalDiscountApplied, 2)
        txtPaymentApplied.Text = FormatCurrency(TotalPayments, 2)
        txtDistributableAmount.Text = FormatCurrency(TotalPaymentAmount, 2)
        txtOpenBalance.Text = FormatCurrency(OpenBalance, 2)
    End Sub

    Private Sub cmdApplyPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplyPayment.Click
        If canApplyPayment() Then
            'Validate Customer
            Dim ValidateCustomer As String = ""

            Dim ValidateCustomerStatement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerID = @CustomerID"
            Dim ValidateCustomerCommand As New SqlCommand(ValidateCustomerStatement, con)
            ValidateCustomerCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            'ValidateCustomerCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ValidateCustomer = CStr(ValidateCustomerCommand.ExecuteScalar)
            Catch ex As Exception
                ValidateCustomer = "INVALID Customer"
            End Try
            con.Close()

            If ValidateCustomer = "" Or ValidateCustomer = "INVALID Customer" Then
                MsgBox("Select a Valid Customer.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'All Customers are Valid Customers
            End If
            '***********************************************************************************************************
            Try
                'Determine Payment Type
                If rdoPayment.Checked = True Then
                    PaymentType = "PAYMENT"
                ElseIf rdoCreditMemo.Checked = True Then
                    PaymentType = "CREDIT MEMO"
                Else
                    PaymentType = "OTHER"
                End If
                '***********************************************************************************************************
                'Determine AR Payment Number for Payment LOG
                If txtCheckNumber.Text <> "" And cboCreditMemo.Text = "" Then
                    PaymentNumber = txtCheckNumber.Text
                ElseIf txtCheckNumber.Text = "" And cboCreditMemo.Text <> "" Then
                    PaymentNumber = Val(cboCreditMemo.Text)
                Else
                    PaymentNumber = txtCardNumber.Text
                End If
                '***********************************************************************************************************
                Try
                    'Write Data to AR Payment Log
                    cmd = New SqlCommand("Insert Into ARPaymentLog(PaymentID, ARPaymentNumber, CustomerID, PaymentAmount, PaymentDate, DivisionID, PaymentType, ARBatchNumber, PaymentStatus) Values (@PaymentID, @ARPaymentNumber, @CustomerID, @PaymentAmount, @PaymentDate, @DivisionID, @PaymentType, @ARBatchNumber, @PaymentStatus)", con)

                    With cmd.Parameters
                        .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@ARPaymentNumber", SqlDbType.VarChar).Value = PaymentNumber
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtPaymentAmount.Text)
                        .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PaymentType", SqlDbType.VarChar).Value = PaymentType
                        .Add("@ARBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@PaymentStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write Data to AR Payment Log
                    cmd = New SqlCommand("UPDATE ARPaymentLog SET ARPaymentNumber = @ARPaymentNumber, CustomerID = @CustomerID, PaymentAmount = @PaymentAmount, PaymentDate = @PaymentDate, PaymentType = @PaymentType, ARBatchNumber = @ARBatchNumber, PaymentStatus = @PaymentStatus WHERE PaymentID = @PaymentID AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@ARPaymentNumber", SqlDbType.VarChar).Value = PaymentNumber
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtPaymentAmount.Text)
                        .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PaymentType", SqlDbType.VarChar).Value = PaymentType
                        .Add("@ARBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@PaymentStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Try
                '***********************************************************************************************************
                If chkAdjustment.Checked = True And Val(txtAdjustmentAmount.Text) <> 0 And Val(cboInvoiceAdjustmentNumber.Text) <> 0 Then
                    AdjustmentAmount = Val(txtAdjustmentAmount.Text)
                    Dim AdjustmentDivision As String = ""
                    Dim AdjustmentBankAccount As String = ""

                    'Get Division ID from Invoice Number
                    Dim GetInvoiceDivisionStatement As String = "SELECT DivisionID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                    Dim GetInvoiceDivisionCommand As New SqlCommand(GetInvoiceDivisionStatement, con)
                    GetInvoiceDivisionCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceAdjustmentNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        AdjustmentDivision = CStr(GetInvoiceDivisionCommand.ExecuteScalar)
                    Catch ex As Exception
                        AdjustmentDivision = ""
                    End Try
                    con.Close()

                    If AdjustmentDivision = "TFF" Or AdjustmentDivision = "TOR" Or AdjustmentDivision = "ALB" Then
                        AdjustmentBankAccount = "Canadian Checking"
                    ElseIf AdjustmentDivision = "TWD" Or AdjustmentDivision = "TFP" Then
                        AdjustmentBankAccount = "Checking"
                    Else
                        AdjustmentBankAccount = "Cash Receipts"
                    End If
                    '************************************************************************************************
                    'Write Data to AR Payment Lines
                    'Find the next Line Number to use
                    Dim MaxLineStatement As String = "SELECT MAX(LineNumber) FROM ARPaymentLines WHERE PaymentID = @PaymentID"
                    Dim MAXLineCommand As New SqlCommand(MaxLineStatement, con)
                    MAXLineCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastLineNumber = CInt(MAXLineCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastLineNumber = 0
                    End Try
                    con.Close()

                    NextLineNumber = LastLineNumber + 1

                    cmd = New SqlCommand("INSERT INTO ARPaymentLines(PaymentID, LineNumber, ARInvoiceNumber, PaymentAmount, PaymentDate, DivisionID) Values (@PaymentID, @LineNumber, @ARInvoiceNumber, @PaymentAmount, @PaymentDate, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@LineNumber", SqlDbType.VarChar).Value = NextLineNumber
                        .Add("@ARInvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceAdjustmentNumber.Text)
                        .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtAdjustmentAmount.Text)
                        .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = AdjustmentDivision
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '***********************************************************************************************************                'Find the next Transaction Number to use to write to AR Customer Payment Table
                    Dim MAXStatement As String = "SELECT MAX(ARTransactionKey) FROM ARCustomerPayment"
                    Dim MAXCommand As New SqlCommand(MAXStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastTransactionNumber = 6200000
                    End Try
                    con.Close()

                    NextTransactionNumber = LastTransactionNumber + 1

                    Try
                        'Write Data to AR Customer Payment Database Table
                        cmd = New SqlCommand("Insert Into ARCustomerPayment(ARTransactionKey, DivisionID, CustomerID, PaymentDate, PaymentType, PaymentAmount, CheckNumber, CardNumber, CardDate, AuthorizationNumber, ReferenceNumber, InvoiceNumber, CheckComment, CreditComment, Status, InvoiceDate, InvoiceAmount, DiscountAmount, TenderType, CardType, BankAccount, BatchNumber, PaymentID, PaymentLineNumber) Values (@ARTransactionKey, @DivisionID, @CustomerID, @PaymentDate, @PaymentType, @PaymentAmount, @CheckNumber, @CardNumber, @CardDate, @AuthorizationNumber, @ReferenceNumber, @InvoiceNumber, @CheckComment, @CreditComment, @Status, @InvoiceDate, @InvoiceAmount, @DiscountAmount, @TenderType, @CardType, @BankAccount, @BatchNumber, @PaymentID, @PaymentLineNumber)", con)

                        With cmd.Parameters
                            .Add("@ARTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = AdjustmentDivision
                            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                            .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                            .Add("@PaymentType", SqlDbType.VarChar).Value = "ADJUSTMENT / WRITE-OFF"
                            .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtAdjustmentAmount.Text)
                            .Add("@CheckNumber", SqlDbType.VarChar).Value = "WRITE-OFF ACCOUNT - " & cboGLAccountNumber.Text
                            .Add("@CardNumber", SqlDbType.VarChar).Value = ""
                            .Add("@CardDate", SqlDbType.VarChar).Value = ""
                            .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = ""
                            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceAdjustmentNumber.Text)
                            .Add("@CheckComment", SqlDbType.VarChar).Value = "Write-Off Amount for selected Invoice"
                            .Add("@CreditComment", SqlDbType.VarChar).Value = ""
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = AdjustmentAmount
                            .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
                            .Add("@TenderType", SqlDbType.VarChar).Value = ""
                            .Add("@CardType", SqlDbType.VarChar).Value = ""
                            .Add("@BankAccount", SqlDbType.VarChar).Value = AdjustmentBankAccount
                            .Add("BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                            .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                            .Add("@PaymentLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write Data to AR Customer Payment Database Table
                        cmd = New SqlCommand("UPDATE ARCustomerPayment SET CustomerID = @CustomerID, PaymentDate = @PaymentDate, PaymentType = @PaymentType, PaymentAmount = @PaymentAmount, CheckNumber = @CheckNumber, CardNumber = @CardNumber, CardDate = @CardDate, AuthorizationNumber = @AuthorizationNumber, ReferenceNumber = @ReferenceNumber, InvoiceNumber = @InvoiceNumber, CheckComment = @CheckComment, CreditComment = @CreditComment, Status = @Status, InvoiceDate = @InvoiceDate, InvoiceAmount = @InvoiceAmount, DiscountAmount = @DiscountAmount, TenderType = @TenderType, CardType = @CardType, BankAccount = @BankAccount, BatchNumber = @BatchNumber, PaymentID = @PaymentID, PaymentLineNumber = @PaymentLineNumber WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@ARTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = AdjustmentDivision
                            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                            .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                            .Add("@PaymentType", SqlDbType.VarChar).Value = "ADJUSTMENT / WRITE-OFF"
                            .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtAdjustmentAmount.Text)
                            .Add("@CheckNumber", SqlDbType.VarChar).Value = "WRITE-OFF ACCOUNT - " & cboGLAccountNumber.Text
                            .Add("@CardNumber", SqlDbType.VarChar).Value = ""
                            .Add("@CardDate", SqlDbType.VarChar).Value = ""
                            .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = ""
                            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = cboGLAccountNumber.Text
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceAdjustmentNumber.Text)
                            .Add("@CheckComment", SqlDbType.VarChar).Value = "Write-Off Amount for selected Invoice"
                            .Add("@CreditComment", SqlDbType.VarChar).Value = ""
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = AdjustmentAmount
                            .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
                            .Add("@TenderType", SqlDbType.VarChar).Value = ""
                            .Add("@CardType", SqlDbType.VarChar).Value = ""
                            .Add("@BankAccount", SqlDbType.VarChar).Value = AdjustmentBankAccount
                            .Add("BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                            .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                            .Add("@PaymentLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Try
                    '***********************************************************************************************************
                    'Update Invoice Header Table with Total Payments Applied
                    Dim TotalPaymentsStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE InvoiceNumber = @InvoiceNumber"
                    Dim TotalPaymentsCommand As New SqlCommand(TotalPaymentsStatement, con)
                    TotalPaymentsCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceAdjustmentNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        TotalPayments = CDbl(TotalPaymentsCommand.ExecuteScalar)
                    Catch ex As Exception
                        TotalPayments = 0
                    End Try
                    con.Close()

                    TotalPayments = Math.Round(TotalPayments, 2)
                    '***********************************************************************************************************
                    'Add current payment to existing payments to write new total to the Invoice Header Table
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET PaymentsApplied = @PaymentsApplied WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceAdjustmentNumber.Text)
                    cmd.Parameters.Add("@PaymentsApplied", SqlDbType.VarChar).Value = TotalPayments

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Do nothing - no write-off/adjustment amount
                End If
                '***********************************************************************************************************
                'Retrieve line data from Datagrid and write to AR Payment Table
                For Each row As DataGridViewRow In dgvInvoiceHeaderQuery.Rows
                    Dim cell As DataGridViewTextBoxCell = row.Cells("PaymentEntryColumn")
                    Dim InvoiceNumber As Integer
                    Dim Invoicedate As String
                    Dim InvoiceTotal, EnterPayment As Double
                    Dim LineDivision As String = ""

                    If cell.Value <> 0 Then
                        Try
                            InvoiceNumber = row.Cells("InvoiceNumberColumn").Value
                        Catch ex As Exception
                            InvoiceNumber = 0
                        End Try
                        Try
                            Invoicedate = row.Cells("InvoiceDateColumn").Value
                        Catch ex As Exception
                            Invoicedate = ""
                        End Try
                        Try
                            InvoiceTotal = row.Cells("InvoiceTotalColumn").Value
                        Catch ex As Exception
                            InvoiceTotal = 0
                        End Try
                        Try
                            EnterPayment = row.Cells("PaymentEntryColumn").Value
                        Catch ex As Exception
                            EnterPayment = 0
                        End Try
                        Try
                            LineDivision = row.Cells("DivisionIDColumn").Value
                        Catch ex As Exception
                            LineDivision = ""
                        End Try
                        Try
                            LineBankAccount = row.Cells("BankAccountColumn").Value
                        Catch ex As Exception
                            LineBankAccount = ""
                        End Try
                        '***************************************************************************
                        If LineBankAccount = "" Then
                            'Determine bank account by division
                            If LineDivision = "TFF" Then
                                LineBankAccount = "Checking Canadian"
                            ElseIf LineDivision = "TOR" Then
                                LineBankAccount = "Checking Canadian"
                            ElseIf LineDivision = "ALB" Then
                                LineBankAccount = "Checking Canadian"
                            ElseIf LineDivision = "TWD" Then
                                LineBankAccount = "Checking"
                            ElseIf LineDivision = "TFP" Then
                                LineBankAccount = "Checking"
                            Else
                                LineBankAccount = "Cash Receipts"
                            End If
                        End If
                        '***************************************************************************
                        InvoiceTotal = Math.Round(InvoiceTotal, 2)
                        EnterPayment = Math.Round(EnterPayment, 2)

                        'Write Data to AR Payment Lines
                        'Find the next Line Number to use
                        Dim MaxLineStatement As String = "SELECT MAX(LineNumber) FROM ARPaymentLines WHERE PaymentID = @PaymentID"
                        Dim MAXLineCommand As New SqlCommand(MaxLineStatement, con)
                        MAXLineCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastLineNumber = CInt(MAXLineCommand.ExecuteScalar)
                        Catch ex As Exception
                            LastLineNumber = 0
                        End Try
                        con.Close()

                        NextLineNumber = LastLineNumber + 1

                        'Insert record into payment line table
                        cmd = New SqlCommand("Insert Into ARPaymentLines(PaymentID, LineNumber, ARInvoiceNumber, PaymentAmount, PaymentDate, DivisionID) Values (@PaymentID, @LineNumber, @ARInvoiceNumber, @PaymentAmount, @PaymentDate, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                            .Add("@LineNumber", SqlDbType.VarChar).Value = NextLineNumber
                            .Add("@ARInvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                            .Add("@PaymentAmount", SqlDbType.VarChar).Value = EnterPayment
                            .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = LineDivision
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '***********************************************************************************************************
                        'Find the next Transaction Number to use to write to AR Customer Payment Table
                        Dim MAXStatement As String = "SELECT MAX(ARTransactionKey) FROM ARCustomerPayment"
                        Dim MAXCommand As New SqlCommand(MAXStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
                        Catch ex As Exception
                            LastTransactionNumber = 6200000
                        End Try
                        con.Close()

                        NextTransactionNumber = LastTransactionNumber + 1
                        ARTransactionKey = NextTransactionNumber
                        '***********************************************************************************************************
                        'Write Data to AR Customer Payment Database Table
                        cmd = New SqlCommand("Insert Into ARCustomerPayment(ARTransactionKey, DivisionID, CustomerID, PaymentDate, PaymentType, PaymentAmount, CheckNumber, CardNumber, CardDate, AuthorizationNumber, ReferenceNumber, InvoiceNumber, CheckComment, CreditComment, Status, InvoiceDate, InvoiceAmount, DiscountAmount, TenderType, CardType, BankAccount, BatchNumber, PaymentID, PaymentLineNumber) Values ((SELECT isnull(MAX(ARTransactionKey) + 1, 6200000) FROM ARCustomerPayment), @DivisionID, @CustomerID, @PaymentDate, @PaymentType, @PaymentAmount, @CheckNumber, @CardNumber, @CardDate, @AuthorizationNumber, @ReferenceNumber, @InvoiceNumber, @CheckComment, @CreditComment, @Status, @InvoiceDate, @InvoiceAmount, @DiscountAmount, @TenderType, @CardType, @BankAccount, @BatchNumber, @PaymentID, @PaymentLineNumber)", con)

                        With cmd.Parameters
                            '.Add("@ARTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = LineDivision
                            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                            .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                            .Add("@PaymentType", SqlDbType.VarChar).Value = PaymentType
                            .Add("@PaymentAmount", SqlDbType.VarChar).Value = EnterPayment
                            .Add("@CheckNumber", SqlDbType.VarChar).Value = txtCheckNumber.Text
                            .Add("@CardNumber", SqlDbType.VarChar).Value = txtCardNumber.Text
                            .Add("@CardDate", SqlDbType.VarChar).Value = txtCardDate.Text
                            .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = txtAuthorization.Text
                            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = txtReferenceNumber.Text
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                            .Add("@CheckComment", SqlDbType.VarChar).Value = txtCheckComment.Text
                            .Add("@CreditComment", SqlDbType.VarChar).Value = txtCheckComment.Text
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = Invoicedate
                            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = InvoiceTotal
                            .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
                            .Add("@TenderType", SqlDbType.VarChar).Value = cboTenderType.Text
                            .Add("@CardType", SqlDbType.VarChar).Value = cboCardType.Text
                            .Add("@BankAccount", SqlDbType.VarChar).Value = LineBankAccount
                            .Add("BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                            .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                            .Add("@PaymentLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '***********************************************************************************************************
                        'Update Invoice Header Table with Total Payments Applied
                        Dim TotalPaymentsStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE InvoiceNumber = @InvoiceNumber"
                        Dim TotalPaymentsCommand As New SqlCommand(TotalPaymentsStatement, con)
                        TotalPaymentsCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            TotalPayments = CDbl(TotalPaymentsCommand.ExecuteScalar)
                        Catch ex As Exception
                            TotalPayments = 0
                        End Try
                        con.Close()

                        TotalPayments = Math.Round(TotalPayments, 2)
                        InvoiceTotal = Math.Round(InvoiceTotal, 2)
                        '***********************************************************************************************************
                        'Add current payment to existing payments to write new total to the Invoice Header Table
                        cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET PaymentsApplied = @PaymentsApplied WHERE InvoiceNumber = @InvoiceNumber", con)
                        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                        cmd.Parameters.Add("@PaymentsApplied", SqlDbType.VarChar).Value = TotalPayments

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '***********************************************************************************************************
                        'Retotal Invoice to ensure no rounding of invoice amount
                        cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceTotal = @InvoiceTotal WHERE InvoiceNumber = @InvoiceNumber", con)
                        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                        cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '***********************************************************************************************************
                        'Update Status of Invoice Header Table
                        cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceStatus = @InvoiceStatus WHERE PaymentsApplied = InvoiceTotal AND InvoiceNumber = @InvoiceNumber", con)
                        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                        cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "CLOSED"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '***********************************************************************************************************
                        'Update Invoice Line Table with Status if closed
                        Dim InvoiceStatusStatement As String = "SELECT InvoiceStatus FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                        Dim InvoiceStatusCommand As New SqlCommand(InvoiceStatusStatement, con)
                        InvoiceStatusCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            InvoiceStatus = CStr(InvoiceStatusCommand.ExecuteScalar)
                        Catch ex As Exception
                            InvoiceStatus = "CLOSED"
                        End Try
                        con.Close()
                        '***********************************************************************************************************
                        'Update Status of Invoice Line Table
                        cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey", con)
                        cmd.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = InvoiceNumber
                        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = InvoiceStatus

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '***********************************************************************************************************
                        'Zero out variables before next loop iteration
                        TotalPayments = 0
                        NewTotalPayments = 0
                    End If
                Next
                '***********************************************************************************************************
                MsgBox("Payments have been applied", MsgBoxStyle.OkOnly)

                ClearVariables()
                ClearData()
                LoadCustomerList()
                ClearData()
                ShowData()
            Catch ex As Exception
                MsgBox("There is a problem with this payment - check data and try again.", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Function canApplyPayment() As Boolean
        If cboPaymentID.Text.Equals("") Then
            MessageBox.Show("You must have a valid Payment ID", "Invalid Payment ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPaymentID.Focus()
            Return False
        End If
        If cboCustomerID.Text.Equals("") Then
            MessageBox.Show("You must have a valid Customer", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.Focus()
            Return False
        End If
        If cboCustomerID.SelectedIndex = -1 Then
            MessageBox.Show("You must have a valid Customer", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.SelectAll()
            cboCustomerID.Focus()
            Return False
        End If
        If txtBatchNumber.Text.Equals("") Or Val(txtBatchNumber.Text) = 0 Then
            MessageBox.Show("You must have a valid Batch Number", "Invalid Batch Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If chkAdjustment.Checked Then
            If String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
                MessageBox.Show("You must select an Invoice Number", "Select an Invoice Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboInvoiceNumber.Focus()
                Return False
            End If
            If String.IsNullOrEmpty(txtAdjustmentAmount.Text) Then
                MessageBox.Show("You must enter an adjustment amount", "Enter an adjustment Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAdjustmentAmount.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub rdoPayment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPayment.CheckedChanged
        If rdoPayment.Checked = True Then
            PaymentType = "Payment"
            cboCreditMemo.Visible = False
            lblPaymentType.Text = "Payment Amount"
            cboCreditMemo.SelectedIndex = -1
            txtPaymentAmount.Clear()
        ElseIf rdoCreditMemo.Checked = True Then
            PaymentType = "Credit Memo"
            cboCreditMemo.Visible = True
            lblPaymentType.Text = "Credit Amount"
            'Loads Return Number into combo box
            LoadReturnNumber()
        End If
    End Sub

    Private Sub rdoCreditMemo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCreditMemo.CheckedChanged
        If rdoPayment.Checked = True Then
            PaymentType = "Payment"
            cboCreditMemo.Visible = False
            lblPaymentType.Text = "Payment Amount"
            cboCreditMemo.SelectedIndex = -1
            txtPaymentAmount.Clear()
        ElseIf rdoCreditMemo.Checked = True Then
            PaymentType = "Credit Memo"
            cboCreditMemo.Visible = True
            lblPaymentType.Text = "Credit Amount"
            'Loads Return Number into combo box
            LoadReturnNumber()
        End If
    End Sub

    Private Sub cmdDistributePayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDistributePayments.Click
        ClearVariables()

        For Each row As DataGridViewRow In dgvInvoiceHeaderQuery.Rows
            Dim cell As DataGridViewTextBoxCell = row.Cells("PaymentEntryColumn")

            If cell.Value <> 0 Then
                Dim EnterPayment As Double = row.Cells("PaymentEntryColumn").Value

                TotalPayments = TotalPayments + EnterPayment
            End If
        Next

        TotalPayments = Math.Round(TotalPayments, 2)

        'If Adjustment/write-off is checked, add that to the total
        If chkAdjustment.Checked = True Then
            AdjustmentAmount = Val(txtAdjustmentAmount.Text)

            TotalPayments = TotalPayments + AdjustmentAmount
        Else
            'Do nothing
        End If

        TotalPaymentAmount = Val(txtPaymentAmount.Text)
        OpenBalance = TotalPaymentAmount - TotalPayments - TotalDiscountApplied

        txtDiscountApplied.Text = FormatCurrency(TotalDiscountApplied, 2)
        txtPaymentApplied.Text = FormatCurrency(TotalPayments, 2)
        txtDistributableAmount.Text = FormatCurrency(TotalPaymentAmount, 2)
        txtOpenBalance.Text = FormatCurrency(OpenBalance, 2)

        If TotalPayments = TotalPaymentAmount Then
            cmdApplyPayment.Enabled = True
        Else
            cmdApplyPayment.Enabled = False
        End If
    End Sub

    Private Sub SaveDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDataToolStripMenuItem.Click
        'Determine Payment Type
        If rdoPayment.Checked = True Then
            PaymentType = "PAYMENT"
        ElseIf rdoCreditMemo.Checked = True Then
            PaymentType = "CREDIT MEMO"
        Else
            PaymentType = "OTHER"
        End If

        'Determine AR Payment Number for Payment LOG
        If txtCheckNumber.Text <> "" And cboCreditMemo.Text = "" Then
            PaymentNumber = txtCheckNumber.Text
        ElseIf txtCheckNumber.Text = "" And cboCreditMemo.Text <> "" Then
            PaymentNumber = Val(cboCreditMemo.Text)
        Else
            PaymentNumber = txtCardNumber.Text
        End If

        Try
            'Write Data to AR Payment Log
            cmd = New SqlCommand("Insert Into ARPaymentLog(PaymentID, ARPaymentNumber, CustomerID, PaymentAmount, PaymentDate, DivisionID, PaymentType, ARBatchNumber, PaymentStatus) Values (@PaymentID, @ARPaymentNumber, @CustomerID, @PaymentAmount, @PaymentDate, @DivisionID, @PaymentType, @ARBatchNumber, @PaymentStatus)", con)

            With cmd.Parameters
                .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                .Add("@ARPaymentNumber", SqlDbType.VarChar).Value = PaymentNumber
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtPaymentAmount.Text)
                .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@PaymentType", SqlDbType.VarChar).Value = PaymentType
                .Add("@ARBatchNumber", SqlDbType.VarChar).Value = GlobalNewARBatchNumber
                .Add("@PaymentStatus", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Write Data to AR Payment Log
            cmd = New SqlCommand("UPDATE ARPaymentLog SET ARPaymentNumber = @ARPaymentNumber, CustomerID = @CustomerID, PaymentAmount = @PaymentAmount, PaymentDate = @PaymentDate, DivisionID = @DivisionID, PaymentType = @PaymentType, ARBatchNumber = @ARBatchNumber, PaymentStatus = @PaymentStatus WHERE PaymentID = @PaymentID", con)

            With cmd.Parameters
                .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                .Add("@ARPaymentNumber", SqlDbType.VarChar).Value = PaymentNumber
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtPaymentAmount.Text)
                .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@PaymentType", SqlDbType.VarChar).Value = PaymentType
                .Add("@ARBatchNumber", SqlDbType.VarChar).Value = GlobalNewARBatchNumber
                .Add("@PaymentStatus", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Try

        MsgBox("Data has been saved.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cboInvoiceNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInvoiceNumber.SelectedIndexChanged
        LoadInvoiceData()
    End Sub

    Private Sub cmdApplySinglePayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApplySinglePayment.Click
        If cboPaymentID.Text = "" Or cboCustomerID.Text = "" Then
            MsgBox("You must have a valid Payment ID and Customer selected.", MsgBoxStyle.OkOnly)
        Else
            '***********************************************************************************************************
            'Determine Payment Type
            If rdoPayment.Checked = True Then
                PaymentType = "PAYMENT"
            ElseIf rdoCreditMemo.Checked = True Then
                PaymentType = "CREDIT MEMO"
            Else
                PaymentType = "OTHER"
            End If
            '***********************************************************************************************************
            'Determine AR Payment Number for Payment LOG
            If txtCheckNumber.Text <> "" And cboCreditMemo.Text = "" Then
                PaymentNumber = txtCheckNumber.Text
            ElseIf txtCheckNumber.Text = "" And cboCreditMemo.Text <> "" Then
                PaymentNumber = Val(cboCreditMemo.Text)
            Else
                PaymentNumber = txtCardNumber.Text
            End If
            '***********************************************************************************************************
            'Verify that all data has been entered for manual payment
            If cboInvoiceNumber.Text = "" Or txtInvoicePaymentApplied.Text = "" Then
                MsgBox("You must select an Invoice and payment amount.", MsgBoxStyle.OkOnly)
            Else
                Try
                    'Write Data to AR Payment Log
                    cmd = New SqlCommand("Insert Into ARPaymentLog(PaymentID, ARPaymentNumber, CustomerID, PaymentAmount, PaymentDate, DivisionID, PaymentType, ARBatchNumber, PaymentStatus) Values (@PaymentID, @ARPaymentNumber, @CustomerID, @PaymentAmount, @PaymentDate, @DivisionID, @PaymentType, @ARBatchNumber, @PaymentStatus)", con)

                    With cmd.Parameters
                        .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@ARPaymentNumber", SqlDbType.VarChar).Value = PaymentNumber
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtPaymentAmount.Text)
                        .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PaymentType", SqlDbType.VarChar).Value = PaymentType
                        .Add("@ARBatchNumber", SqlDbType.VarChar).Value = GlobalNewARBatchNumber
                        .Add("@PaymentStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write Data to AR Payment Log
                    cmd = New SqlCommand("UPDATE ARPaymentLog SET ARPaymentNumber = @ARPaymentNumber, CustomerID = @CustomerID, PaymentAmount = @PaymentAmount, PaymentDate = @PaymentDate, DivisionID = @DivisionID, PaymentType = @PaymentType, ARBatchNumber = @ARBatchNumber, PaymentStatus = @PaymentStatus WHERE PaymentID = @PaymentID", con)

                    With cmd.Parameters
                        .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@ARPaymentNumber", SqlDbType.VarChar).Value = PaymentNumber
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtPaymentAmount.Text)
                        .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PaymentType", SqlDbType.VarChar).Value = PaymentType
                        .Add("@ARBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@PaymentStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Try
                '***********************************************************************************************************
                'Get Division ID for selected Invoice
                Dim GetInvoiceDivisionStatement As String = "SELECT DivisionID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                Dim GetInvoiceDivisionCommand As New SqlCommand(GetInvoiceDivisionStatement, con)
                GetInvoiceDivisionCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    PaymentDivision = CStr(GetInvoiceDivisionCommand.ExecuteScalar)
                Catch ex As Exception
                    PaymentDivision = ""
                End Try
                con.Close()
                '***********************************************************************************************************
                'Write Data to AR Payment Lines
                'Find the next Line Number to use
                Dim MaxLineStatement As String = "SELECT MAX(LineNumber) FROM ARPaymentLines WHERE PaymentID = @PaymentID"
                Dim MAXLineCommand As New SqlCommand(MaxLineStatement, con)
                MAXLineCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastLineNumber = CInt(MAXLineCommand.ExecuteScalar)
                Catch ex As Exception
                    LastLineNumber = 0
                End Try
                con.Close()

                NextLineNumber = LastLineNumber + 1
                '***********************************************************************************************************
                'Add payment to Line Table
                cmd = New SqlCommand("Insert Into ARPaymentLines(PaymentID, LineNumber, ARInvoiceNumber, PaymentAmount, PaymentDate, DivisionID) Values (@PaymentID, @LineNumber, @ARInvoiceNumber, @PaymentAmount, @PaymentDate, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                    .Add("@LineNumber", SqlDbType.VarChar).Value = NextLineNumber
                    .Add("@ARInvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtInvoicePaymentApplied.Text)
                    .Add("@PaymentDate", SqlDbType.VarChar).Value = txtInvoiceDate.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = PaymentDivision
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***********************************************************************************************************
                'Write Payment Record to database if there is an Adjustment / Write-off
                If chkAdjustment.Checked = True And Val(txtAdjustmentAmount.Text) > 0 And Val(cboInvoiceAdjustmentNumber.Text) > 0 Then
                    AdjustmentAmount = Val(txtAdjustmentAmount.Text)
                    Dim AdjustmentDivision As String = ""

                    'Get Division ID from Invoice Number
                    Dim GetAdjustmentDivisionStatement As String = "SELECT DivisionID FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                    Dim GetAdjustmentDivisionCommand As New SqlCommand(GetAdjustmentDivisionStatement, con)
                    GetAdjustmentDivisionCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceAdjustmentNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        AdjustmentDivision = CStr(GetAdjustmentDivisionCommand.ExecuteScalar)
                    Catch ex As Exception
                        AdjustmentDivision = ""
                    End Try
                    con.Close()
                    '*******************************************************************************
                    'Write Data to AR Payment Lines
                    'Find the next Line Number to use
                    Dim MaxLine1Statement As String = "SELECT MAX(LineNumber) FROM ARPaymentLines WHERE PaymentID = @PaymentID"
                    Dim MAXLine1Command As New SqlCommand(MaxLine1Statement, con)
                    MAXLine1Command.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastLineNumber = CInt(MAXLine1Command.ExecuteScalar)
                    Catch ex As Exception
                        LastLineNumber = 0
                    End Try
                    con.Close()

                    NextLineNumber = LastLineNumber + 1

                    cmd = New SqlCommand("Insert Into ARPaymentLines(PaymentID, LineNumber, ARInvoiceNumber, PaymentAmount, PaymentDate, DivisionID) Values (@PaymentID, @LineNumber, @ARInvoiceNumber, @PaymentAmount, @PaymentDate, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@LineNumber", SqlDbType.VarChar).Value = NextLineNumber
                        .Add("@ARInvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceAdjustmentNumber.Text)
                        .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtAdjustmentAmount.Text)
                        .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = AdjustmentDivision
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Do nothing
                End If
                '***********************************************************************************************************
                'Find the next Transaction Number to use to write to AR Customer Payment Table
                Dim MAXStatement As String = "SELECT MAX(ARTransactionKey) FROM ARCustomerPayment"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As Exception
                    LastTransactionNumber = 6200000
                End Try
                con.Close()

                NextTransactionNumber = LastTransactionNumber + 1
                ARTransactionKey = NextTransactionNumber
                '***********************************************************************************************************
                Try
                    'Write Data to AR Customer Payment Database Table
                    cmd = New SqlCommand("Insert Into ARCustomerPayment(ARTransactionKey, DivisionID, CustomerID, PaymentDate, PaymentType, PaymentAmount, CheckNumber, CardNumber, CardDate, AuthorizationNumber, ReferenceNumber, InvoiceNumber, CheckComment, CreditComment, Status, InvoiceDate, InvoiceAmount, DiscountAmount, TenderType, CardType, BankAccount, BatchNumber, PaymentID, PaymentLineNumber) Values (@ARTransactionKey, @DivisionID, @CustomerID, @PaymentDate, @PaymentType, @PaymentAmount, @CheckNumber, @CardNumber, @CardDate, @AuthorizationNumber, @ReferenceNumber, @InvoiceNumber, @CheckComment, @CreditComment, @Status, @InvoiceDate, @InvoiceAmount, @DiscountAmount, @TenderType, @CardType, @BankAccount, @BatchNumber, @PaymentID, @PaymentLineNumber)", con)

                    With cmd.Parameters
                        .Add("@ARTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PaymentDivision
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                        .Add("@PaymentType", SqlDbType.VarChar).Value = PaymentType
                        .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtInvoicePaymentApplied.Text)
                        .Add("@CheckNumber", SqlDbType.VarChar).Value = txtCheckNumber.Text
                        .Add("@CardNumber", SqlDbType.VarChar).Value = txtCardNumber.Text
                        .Add("@CardDate", SqlDbType.VarChar).Value = txtCardDate.Text
                        .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = txtAuthorization.Text
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = txtReferenceNumber.Text
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@CheckComment", SqlDbType.VarChar).Value = txtCheckComment.Text
                        .Add("@CreditComment", SqlDbType.VarChar).Value = txtCheckComment.Text
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = txtInvoiceDate.Text
                        .Add("@InvoiceAmount", SqlDbType.VarChar).Value = Val(txtInvoiceTotal.Text)
                        .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtInvoiceDiscountApplied.Text)
                        .Add("@TenderType", SqlDbType.VarChar).Value = cboTenderType.Text
                        .Add("@CardType", SqlDbType.VarChar).Value = cboCardType.Text
                        .Add("@BankAccount", SqlDbType.VarChar).Value = cboBankAccount.Text
                        .Add("BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@PaymentLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write Data to AR Customer Payment Database Table
                    cmd = New SqlCommand("UPDATE ARCustomerPayment SET DivisionID = @DivisionID, CustomerID = @CustomerID, PaymentDate = @PaymentDate, PaymentType = @PaymentType, PaymentAmount = @PaymentAmount, CheckNumber = @CheckNumber, CardNumber = @CardNumber, CardDate = @CardDate, AuthorizationNumber = @AuthorizationNumber, ReferenceNumber = @ReferenceNumber, InvoiceNumber = @InvoiceNumber, CheckComment = @CheckComment, CreditComment = @CreditComment, Status = @Status, InvoiceDate = @InvoiceDate, InvoiceAmount = @InvoiceAmount, DiscountAmount = @DiscountAmount, TenderType = @TenderType, CardType = @CardType, BankAccount = @BankAccount, BatchNumber = @BatchNumber, PaymentID = @PaymentID, PaymentLineNumber = @PaymentLineNumber WHERE ARTransactionKey = @ARTransactionKey", con)

                    With cmd.Parameters
                        .Add("@ARTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PaymentDivision
                        .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                        .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                        .Add("@PaymentType", SqlDbType.VarChar).Value = PaymentType
                        .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtInvoicePaymentApplied.Text)
                        .Add("@CheckNumber", SqlDbType.VarChar).Value = txtCheckNumber.Text
                        .Add("@CardNumber", SqlDbType.VarChar).Value = txtCardNumber.Text
                        .Add("@CardDate", SqlDbType.VarChar).Value = txtCardDate.Text
                        .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = txtAuthorization.Text
                        .Add("@ReferenceNumber", SqlDbType.VarChar).Value = txtReferenceNumber.Text
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@CheckComment", SqlDbType.VarChar).Value = txtCheckComment.Text
                        .Add("@CreditComment", SqlDbType.VarChar).Value = txtCheckComment.Text
                        .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = txtInvoiceDate.Text
                        .Add("@InvoiceAmount", SqlDbType.VarChar).Value = Val(txtInvoiceTotal.Text)
                        .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtInvoiceDiscountApplied.Text)
                        .Add("@TenderType", SqlDbType.VarChar).Value = cboTenderType.Text
                        .Add("@CardType", SqlDbType.VarChar).Value = cboCardType.Text
                        .Add("@BankAccount", SqlDbType.VarChar).Value = cboBankAccount.Text
                        .Add("BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                        .Add("@PaymentLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Try
                '***********************************************************************************************************
                'Update Invoice Header Table with Total Payments Applied
                Dim TotalPaymentsStatement As String = "SELECT PaymentsApplied FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                Dim TotalPaymentsCommand As New SqlCommand(TotalPaymentsStatement, con)
                TotalPaymentsCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    TotalPayments = CDbl(TotalPaymentsCommand.ExecuteScalar)
                Catch ex As Exception
                    TotalPayments = 0
                End Try
                con.Close()
                '***********************************************************************************************************
                'Add current payment to existing payments to write new total to the Invoice Header Table
                NewTotalPayments = TotalPayments + Val(txtInvoicePaymentApplied.Text)

                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET PaymentsApplied = @PaymentsApplied WHERE InvoiceNumber = @InvoiceNumber", con)
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                cmd.Parameters.Add("@PaymentsApplied", SqlDbType.VarChar).Value = NewTotalPayments

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***********************************************************************************************************
                'Determine if there is an adjustment or write-off amount
                If chkAdjustment.Checked = True And Val(txtAdjustmentAmount.Text) > 0 And Val(cboInvoiceAdjustmentNumber.Text) > 0 Then
                    AdjustmentAmount = Val(txtAdjustmentAmount.Text)

                    'If Adjustment is checked, create payment record in Database

                    'Find the next Transaction Number to use to write to AR Customer Payment Table
                    Dim MAX2Statement As String = "SELECT MAX(ARTransactionKey) FROM ARCustomerPayment"
                    Dim MAX2Command As New SqlCommand(MAX2Statement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastTransactionNumber = CInt(MAX2Command.ExecuteScalar)
                    Catch ex As Exception
                        LastTransactionNumber = 6200000
                    End Try
                    con.Close()

                    NextTransactionNumber = LastTransactionNumber + 1
                    ARTransactionKey = NextTransactionNumber
                    Try
                        'Write Data to AR Customer Payment Database Table
                        cmd = New SqlCommand("Insert Into ARCustomerPayment(ARTransactionKey, DivisionID, CustomerID, PaymentDate, PaymentType, PaymentAmount, CheckNumber, CardNumber, CardDate, AuthorizationNumber, ReferenceNumber, InvoiceNumber, CheckComment, CreditComment, Status, InvoiceDate, InvoiceAmount, DiscountAmount, TenderType, CardType, BankAccount, BatchNumber, PaymentID, PaymentLineNumber) Values (@ARTransactionKey, @DivisionID, @CustomerID, @PaymentDate, @PaymentType, @PaymentAmount, @CheckNumber, @CardNumber, @CardDate, @AuthorizationNumber, @ReferenceNumber, @InvoiceNumber, @CheckComment, @CreditComment, @Status, @InvoiceDate, @InvoiceAmount, @DiscountAmount, @TenderType, @CardType, @BankAccount, @BatchNumber, @PaymentID, @PaymentLineNumber)", con)

                        With cmd.Parameters
                            .Add("@ARTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = PaymentDivision
                            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                            .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                            .Add("@PaymentType", SqlDbType.VarChar).Value = "ADJUSTMENT / WRITE-OFF"
                            .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtAdjustmentAmount.Text)
                            .Add("@CheckNumber", SqlDbType.VarChar).Value = "ADJUSTMENT"
                            .Add("@CardNumber", SqlDbType.VarChar).Value = ""
                            .Add("@CardDate", SqlDbType.VarChar).Value = ""
                            .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = ""
                            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = ""
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceAdjustmentNumber.Text)
                            .Add("@CheckComment", SqlDbType.VarChar).Value = "Write-Off Amount for selected Invoice"
                            .Add("@CreditComment", SqlDbType.VarChar).Value = ""
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = Val(txtAdjustmentAmount.Text)
                            .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
                            .Add("@TenderType", SqlDbType.VarChar).Value = ""
                            .Add("@CardType", SqlDbType.VarChar).Value = ""
                            .Add("@BankAccount", SqlDbType.VarChar).Value = cboBankAccount.Text
                            .Add("BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                            .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                            .Add("@PaymentLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write Data to AR Customer Payment Database Table
                        cmd = New SqlCommand("UPDATE ARCustomerPayment SET DivisionID = @DivisionID, CustomerID = @CustomerID, PaymentDate = @PaymentDate, PaymentType = @PaymentType, PaymentAmount = @PaymentAmount, CheckNumber = @CheckNumber, CardNumber = @CardNumber, CardDate = @CardDate, AuthorizationNumber = @AuthorizationNumber, ReferenceNumber = @ReferenceNumber, InvoiceNumber = @InvoiceNumber, CheckComment = @CheckComment, CreditComment = @CreditComment, Status = @Status, InvoiceDate = @InvoiceDate, InvoiceAmount = @InvoiceAmount, DiscountAmount = @DiscountAmount, TenderType = @TenderType, CardType = @CardType, BankAccount = @BankAccount, BatchNumber = @BatchNumber, PaymentID = @PaymentID, PaymentLineNumber = @PaymentLineNumber WHERE ARTransactionKey = @ARTransactionKey", con)

                        With cmd.Parameters
                            .Add("@ARTransactionKey", SqlDbType.VarChar).Value = NextTransactionNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = PaymentDivision
                            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                            .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                            .Add("@PaymentType", SqlDbType.VarChar).Value = "ADJUSTMENT / WRITE-OFF"
                            .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtAdjustmentAmount.Text)
                            .Add("@CheckNumber", SqlDbType.VarChar).Value = "ADJUSTMENT"
                            .Add("@CardNumber", SqlDbType.VarChar).Value = ""
                            .Add("@CardDate", SqlDbType.VarChar).Value = ""
                            .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = ""
                            .Add("@ReferenceNumber", SqlDbType.VarChar).Value = ""
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceAdjustmentNumber.Text)
                            .Add("@CheckComment", SqlDbType.VarChar).Value = "Write-Off Amount for selected Invoice"
                            .Add("@CreditComment", SqlDbType.VarChar).Value = ""
                            .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = Val(txtAdjustmentAmount.Text)
                            .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
                            .Add("@TenderType", SqlDbType.VarChar).Value = ""
                            .Add("@CardType", SqlDbType.VarChar).Value = ""
                            .Add("@BankAccount", SqlDbType.VarChar).Value = cboBankAccount.Text
                            .Add("BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                            .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                            .Add("@PaymentLineNumber", SqlDbType.VarChar).Value = NextLineNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Try
                    '***********************************************************************************************************
                    'Update Invoice Header Table with Total Payments Applied
                    Dim TotalPayments2Statement As String = "SELECT PaymentsApplied FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                    Dim TotalPayments2Command As New SqlCommand(TotalPayments2Statement, con)
                    TotalPayments2Command.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceAdjustmentNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        TotalPayments = CDbl(TotalPayments2Command.ExecuteScalar)
                    Catch ex As Exception
                        TotalPayments = 0
                    End Try
                    con.Close()
                    '***********************************************************************************************************
                    'Add current payment to existing payments to write new total to the Invoice Header Table
                    NewTotalPayments = TotalPayments + Val(txtAdjustmentAmount.Text)

                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET PaymentsApplied = @PaymentsApplied WHERE InvoiceNumber = @InvoiceNumber", con)
                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceAdjustmentNumber.Text)
                    cmd.Parameters.Add("@PaymentsApplied", SqlDbType.VarChar).Value = NewTotalPayments

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '***********************************************************************************************************
                Else
                    AdjustmentAmount = 0
                End If
                '***********************************************************************************************************
                'Update Status of Invoice Header Table
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceStatus = @InvoiceStatus WHERE PaymentsApplied >= InvoiceTotal AND InvoiceNumber = @InvoiceNumber", con)
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "CLOSED"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***********************************************************************************************************
                'Update Invoice Line Table with Status if closed
                Dim InvoiceStatusStatement As String = "SELECT InvoiceStatus FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
                Dim InvoiceStatusCommand As New SqlCommand(InvoiceStatusStatement, con)
                InvoiceStatusCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    InvoiceStatus = CStr(InvoiceStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    InvoiceStatus = "CLOSED"
                End Try
                con.Close()
                '***********************************************************************************************************
                'Update Status of Invoice Line Table
                cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey", con)
                cmd.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = InvoiceStatus

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***********************************************************************************************************
                'Update Batch Total
                Dim BatchTotalStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE ARBatchNumber = @ARBatchNumber"
                Dim BatchTotalCommand As New SqlCommand(BatchTotalStatement, con)
                BatchTotalCommand.Parameters.Add("@ARBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    BatchTotal = CDbl(BatchTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    BatchTotal = 0
                End Try

                cmd = New SqlCommand("UPDATE ARProcessPaymentBatch SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber", con)
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***********************************************************************************************************
                MsgBox("Payments have been applied", MsgBoxStyle.OkOnly)

                ClearVariables()
                ClearData()
                LoadPaymentID()
                cboInvoiceNumber.Text = ""
                cboInvoiceNumber.SelectedIndex = -1
                ShowData()
            End If
        End If
    End Sub

    Private Sub cmdClearSinglePayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub chkAdjustment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdjustment.CheckedChanged
        If chkAdjustment.Checked = True Then
            cboGLAccountNumber.Enabled = True
            cboGLAccountDescription.Enabled = True
            cboInvoiceAdjustmentNumber.Enabled = True
            txtAdjustmentAmount.Enabled = True
            LoadAdjustmentInvoiceNumber()
            LoadGLAccounts()
            cboGLAccountNumber.Text = "97000"
        Else
            cboGLAccountNumber.SelectedIndex = -1
            cboGLAccountDescription.SelectedIndex = -1
            cboInvoiceAdjustmentNumber.SelectedIndex = -1
            txtAdjustmentAmount.Clear()
            cboGLAccountNumber.Enabled = False
            cboGLAccountDescription.Enabled = False
            cboInvoiceAdjustmentNumber.Enabled = False
            txtAdjustmentAmount.Enabled = False
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            'Determine Payment Type
            If rdoPayment.Checked = True Then
                PaymentType = "PAYMENT"
            ElseIf rdoCreditMemo.Checked = True Then
                PaymentType = "CREDIT MEMO"
            Else
                PaymentType = "OTHER"
            End If

            'Determine AR Payment Number for Payment LOG
            If txtCheckNumber.Text <> "" And cboCreditMemo.Text = "" Then
                PaymentNumber = txtCheckNumber.Text
            ElseIf txtCheckNumber.Text = "" And cboCreditMemo.Text <> "" Then
                PaymentNumber = Val(cboCreditMemo.Text)
            Else
                PaymentNumber = txtCardNumber.Text
            End If
            '***************************************************************************************************************************************
            'Write Data to AR Payment Log
            cmd = New SqlCommand("UPDATE ARPaymentLog SET ARPaymentNumber = @ARPaymentNumber, CustomerID = @CustomerID, PaymentAmount = @PaymentAmount, PaymentDate = @PaymentDate, DivisionID = @DivisionID, PaymentType = @PaymentType, ARBatchNumber = @ARBatchNumber, PaymentStatus = @PaymentStatus WHERE PaymentID = @PaymentID", con)

            With cmd.Parameters
                .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                .Add("@ARPaymentNumber", SqlDbType.VarChar).Value = PaymentNumber
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@PaymentAmount", SqlDbType.VarChar).Value = Val(txtPaymentAmount.Text)
                .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@PaymentType", SqlDbType.VarChar).Value = PaymentType
                .Add("@ARBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                .Add("@PaymentStatus", SqlDbType.VarChar).Value = "OPEN"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '***************************************************************************************************************************************
            'Write Data to AR Customer Payment Database Table
            cmd = New SqlCommand("UPDATE ARCustomerPayment SET CustomerID = @CustomerID, PaymentDate = @PaymentDate, PaymentType = @PaymentType, CheckNumber = @CheckNumber, CardNumber = @CardNumber, CardDate = @CardDate, AuthorizationNumber = @AuthorizationNumber, ReferenceNumber = @ReferenceNumber, CheckComment = @CheckComment, CreditComment = @CreditComment, Status = @Status, TenderType = @TenderType, CardType = @CardType WHERE PaymentID = @PaymentID AND BatchNumber = @BatchNumber", con)

            With cmd.Parameters
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
                .Add("@PaymentType", SqlDbType.VarChar).Value = PaymentType
                .Add("@CheckNumber", SqlDbType.VarChar).Value = txtCheckNumber.Text
                .Add("@CardNumber", SqlDbType.VarChar).Value = txtCardNumber.Text
                .Add("@CardDate", SqlDbType.VarChar).Value = txtCardDate.Text
                .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = txtAuthorization.Text
                .Add("@ReferenceNumber", SqlDbType.VarChar).Value = txtReferenceNumber.Text
                .Add("@CheckComment", SqlDbType.VarChar).Value = txtCheckComment.Text
                .Add("@CreditComment", SqlDbType.VarChar).Value = txtCheckComment.Text
                .Add("@Status", SqlDbType.VarChar).Value = "OPEN"
                .Add("@TenderType", SqlDbType.VarChar).Value = cboTenderType.Text
                .Add("@CardType", SqlDbType.VarChar).Value = cboCardType.Text
                .Add("BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                .Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************************************************************************************************

            MsgBox("Data has been saved.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'Error Log

        End Try
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalARTransactionNumber = Val(cboPaymentID.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintCustomerPaymentRecord As New PrintCustomerPaymentRecord
            Dim Result = NewPrintCustomerPaymentRecord.ShowDialog()
        End Using
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        GlobalARTransactionNumber = Val(cboPaymentID.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintCustomerPaymentRecord As New PrintCustomerPaymentRecord
            Dim Result = NewPrintCustomerPaymentRecord.ShowDialog()
        End Using
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboPaymentID.Text = "" Then
            MsgBox("You must have a valid Payment ID selected.", MsgBoxStyle.OkOnly)
        Else
            'Deletes Saved Receipt
            Dim destinationPath As String = ""
            Dim MoveLocation As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\"
            Dim filename As String = cboPaymentID.Text + ".pdf"
            destinationPath = System.IO.Path.Combine(MoveLocation, filename)
            If File.Exists(destinationPath) Then
                File.Delete(destinationPath)
                cmdViewReceipt.Enabled = False
                cmdScan.Enabled = False
                cmdUploadReceipt.Enabled = False
            End If

            'Delete Amount in the Invoice Header Table
            Dim CountPaymentLinesStatement As String = "SELECT COUNT(PaymentID) FROM ARPaymentLines WHERE PaymentID = @PaymentID"
            Dim CountPaymentLinesCommand As New SqlCommand(CountPaymentLinesStatement, con)
            CountPaymentLinesCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountPaymentLines = CInt(CountPaymentLinesCommand.ExecuteScalar)
            Catch ex As Exception
                CountPaymentLines = 0
            End Try
            con.Close()

            'Reset paid amount in Invoice Table first
            ARPaymentLineNumber = 1

            For i As Integer = 1 To CountPaymentLines
                Dim InvoiceNumberStatement As String = "SELECT ARInvoiceNumber FROM ARPaymentLines WHERE PaymentID = @PaymentID AND LineNumber = @LineNumber"
                Dim InvoiceNumberCommand As New SqlCommand(InvoiceNumberStatement, con)
                InvoiceNumberCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                InvoiceNumberCommand.Parameters.Add("@LineNumber", SqlDbType.VarChar).Value = ARPaymentLineNumber

                Dim PaymentAmountStatement As String = "SELECT PaymentAmount FROM ARPaymentLines WHERE PaymentID = @PaymentID AND LineNumber = @LineNumber"
                Dim PaymentAmountCommand As New SqlCommand(PaymentAmountStatement, con)
                PaymentAmountCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                PaymentAmountCommand.Parameters.Add("@LineNumber", SqlDbType.VarChar).Value = ARPaymentLineNumber

                Dim PaymentDivisionStatement As String = "SELECT DivisionID FROM ARPaymentLines WHERE PaymentID = @PaymentID AND LineNumber = @LineNumber"
                Dim PaymentDivisionCommand As New SqlCommand(PaymentDivisionStatement, con)
                PaymentDivisionCommand.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
                PaymentDivisionCommand.Parameters.Add("@LineNumber", SqlDbType.VarChar).Value = ARPaymentLineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    InvoiceNumber = CInt(InvoiceNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    InvoiceNumber = 0
                End Try
                Try
                    DeletePaymentAmount = CDbl(PaymentAmountCommand.ExecuteScalar)
                Catch ex As Exception
                    DeletePaymentAmount = 0
                End Try
                Try
                    PaymentDivision = CStr(PaymentDivisionCommand.ExecuteScalar)
                Catch ex As Exception
                    PaymentDivision = cboDivisionID.Text
                End Try
                con.Close()

                Dim InvoicePaymentsAppliedStatement As String = "SELECT PaymentsApplied FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                Dim InvoicePaymentsAppliedCommand As New SqlCommand(InvoicePaymentsAppliedStatement, con)
                InvoicePaymentsAppliedCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                InvoicePaymentsAppliedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = PaymentDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    InvoicePaymentsApplied = CDbl(InvoicePaymentsAppliedCommand.ExecuteScalar)
                Catch ex As Exception
                    InvoicePaymentsApplied = 0
                End Try
                con.Close()

                'UPDATE Invoice Table with original amount before payment
                NewTotalPayments = InvoicePaymentsApplied - DeletePaymentAmount

                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET PaymentsApplied = @PaymentsApplied, InvoiceStatus = @InvoiceStatus WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = PaymentDivision
                cmd.Parameters.Add("@PaymentsApplied", SqlDbType.VarChar).Value = NewTotalPayments
                cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ARPaymentLineNumber = ARPaymentLineNumber + 1
            Next i

            'Delete Data in the PaymentLog
            cmd = New SqlCommand("DELETE FROM ARPaymentLog WHERE PaymentID = @PaymentID AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Delete Data in the AR Payment Table
            cmd = New SqlCommand("DELETE FROM ARCustomerPayment WHERE PaymentID = @PaymentID", con)
            cmd.Parameters.Add("@PaymentID", SqlDbType.VarChar).Value = Val(cboPaymentID.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadPaymentID()
            LoadCustomerList()
            ClearData()
            ClearVariables()
            ShowData()

            MsgBox("PaymentID has been deleted.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub DeleteDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteDataToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalDivisionCode = cboDivisionID.Text
        GlobalNewARBatchNumber = Val(txtBatchNumber.Text)

        Dim NewARProcessPaymentBatch As New ARProcessPaymentBatch
        NewARProcessPaymentBatch.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalARDivisionCode = cboDivisionID.Text
        GlobalNewARBatchNumber = Val(txtBatchNumber.Text)

        Dim NewARProcessPaymentBatch As New ARProcessPaymentBatch
        NewARProcessPaymentBatch.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub EnableApplyPaymentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableApplyPaymentsToolStripMenuItem.Click
        cmdApplyPayment.Enabled = True
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cmdViewReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
        If File.Exists(CashReceiptExists) Then
            System.Diagnostics.Process.Start(CashReceiptExists)
        End If
    End Sub

    Private Sub cmdScanReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ScanCashReceipt()
    End Sub

    Public Function canSave() As Boolean
        If String.IsNullOrEmpty(cboPaymentID.Text) Then
            MessageBox.Show("You must enter a Payment ID", "Enter a Payment ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPaymentID.Focus()
            Return False
        ElseIf cboPaymentID.Text = "" Then
            MessageBox.Show("You must enter a Payment ID", "Enter a Payment ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPaymentID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If canSave() Then
            Try
                Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
            Catch ex As System.Exception
            End Try

            Dim MoveLocation As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\"
            Dim destinationPath As String = ""

            Dim fd As OpenFileDialog = New OpenFileDialog()
            Dim strFileName As String = ""

            fd.Title = "Open File Dialog"
            fd.InitialDirectory = "C:\"
            fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
            fd.FilterIndex = 2
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                strFileName = fd.FileName
            End If

            If File.Exists(strFileName) Then
                Dim filename As String = System.IO.Path.GetFileName(strFileName)
                destinationPath = System.IO.Path.Combine(MoveLocation, filename)
                If File.Exists(destinationPath) Then
                    File.Delete(destinationPath)
                End If
                File.Move(strFileName, destinationPath)
                Dim rename As String = cboPaymentID.Text + ".pdf"
                My.Computer.FileSystem.RenameFile(destinationPath, rename)
                MsgBox("File Moved")
                Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
                'Sets buttons to see if pdf is viewable
                If File.Exists(CashReceiptExists) Then
                    cmdViewReceipt.Enabled = True
                    ScanToolStripMenuItem.Enabled = True
                    UploadToolStripMenuItem.Enabled = True
                Else
                    cmdViewReceipt.Enabled = False
                    ScanToolStripMenuItem.Enabled = False
                    UploadToolStripMenuItem.Enabled = False
                End If
            Else
                MsgBox("File Not Moved")
            End If
        End If
    End Sub

    Private Sub bgwk_Run(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Try
            Dim images As List(Of System.Drawing.Image) = CType(e.Argument, List(Of System.Drawing.Image))
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New System.IO.FileStream(dir.FullName + "\" + ShipmentNumber.ToString + ".pdf", System.IO.FileMode.Create)).SetFullCompression()

            doc.Open()
            ''Adds images to the pdf
            For Each img As System.Drawing.Image In images
                Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
                iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
                doc.Add(iImage)
                doc.Add(New iTextSharp.text.Paragraph())
            Next
            doc.Close()

            e.Result = images
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwkAppendPDF_Run(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Try
            Dim images As List(Of System.Drawing.Image) = CType(e.Argument, List(Of System.Drawing.Image))
            ''Creates a memory stream for the document
            Using tempStream As New System.IO.MemoryStream()
                Dim copyDoc As New iTextSharp.text.Document()
                Dim copy As New iTextSharp.text.pdf.PdfCopy(copyDoc, tempStream)
                copyDoc.Open()
                Dim pageCounter As Integer = 0
                Dim reader As New iTextSharp.text.pdf.PdfReader(dir.FullName + "\" + ShipmentNumber.ToString + ".pdf")

                ''Gets pages for the pdf document
                Dim numberOfPages As Integer = reader.NumberOfPages
                For currentPage As Integer = 1 To numberOfPages
                    pageCounter += 1
                    Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                    copy.AddPage(importedPage)
                Next
                copy.FreeReader(reader)
                reader.Close()

                System.IO.File.Delete(dir.FullName + "\" + ShipmentNumber.ToString + ".pdf")
                ''Creates a document in memory of the newly scanned pages
                Dim imageStream As New System.IO.MemoryStream()
                Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, imageStream).SetFullCompression()
                doc.Open()

                ''Adds the image to the pdf page
                For Each img As System.Drawing.Image In images
                    Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
                    iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
                    doc.Add(iImage)
                    doc.Add(New iTextSharp.text.Paragraph())
                Next
                doc.Close()

                ''Merges the newly scanned image document into the current document
                reader = New iTextSharp.text.pdf.PdfReader(imageStream.GetBuffer())
                numberOfPages = reader.NumberOfPages

                For currentPage As Integer = 1 To numberOfPages
                    pageCounter += 1
                    Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                    copy.AddPage(importedPage)
                Next

                copy.FreeReader(reader)
                reader.Close()
                copyDoc.Close()
                imageStream.Close()
                imageStream.Dispose()

                Using fs As New System.IO.FileStream(dir.FullName + "\" + cboPaymentID.Text + ".pdf", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                    fs.Write(tempStream.GetBuffer(), 0, tempStream.GetBuffer().Length)
                End Using
            End Using


            e.Result = images
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwk_Completed(ByVal sender As System.Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim images As List(Of System.Drawing.Image) = CType(e.Result, List(Of System.Drawing.Image))
        Dim TotalPages As Integer = images.Count

        While images.Count > 0
            images(0).Dispose()
            images.RemoveAt(0)
        End While

        If FilesToDelete IsNot Nothing AndAlso FilesToDelete.Count > 0 Then
            For Each filename As String In FilesToDelete
                System.IO.File.Delete(filename)
            Next
        End If

        frm.Enabled = True
        LoadingScreen.Hide()

        MessageBox.Show("Cash Batch Uploaded With " + TotalPages.ToString + " pages.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub bgwkRemoteWIA_run(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Try
            remoteWIA.StartClient()
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwkRemoteWIA_Progress(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        Select Case e.ProgressPercentage
            Case 0
                LoadingScreen.Label1.Text = "Connecting to local system, please wait."
            Case 1
                LoadingScreen.Label1.Text = "Connected to local system, initializing scan."
            Case 2
                LoadingScreen.Label1.Text = "Attempting to scan, please wait."
            Case 3
                LoadingScreen.Label1.Text = "Waiting on file from local system."
            Case 4
                LoadingScreen.Label1.Text = "File received and being saved."
        End Select
    End Sub

    Private Sub bgwkRemoteWIA_Completed(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            LoadingScreen.Hide()

            If remoteWIA.SaveFile(dir.FullName + "\" + cboPaymentID.Text + ".pdf") Then
                MessageBox.Show("Cash receipt uploaded with " + remoteWIA.PageCount() + " pages successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ErrorDescription = "Scan Error"
                ErrorReferenceNumber = ""

                'Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

                'With cmd.Parameters
                '.Add("@Date", SqlDbType.Date).Value = Today()
                '.Add("@Description", SqlDbType.VarChar).Value = ErrorDescription
                '.Add("@ErrorReference", SqlDbType.VarChar).Value = ErrorReferenceNumber
                '.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                '.Add("@Comment", SqlDbType.VarChar).Value = dir.FullName + "\" + ShipmentNumber.ToString() + ".pdf"
                '.Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
                'End With

                'If con.State = ConnectionState.Closed Then con.Open()
                'cmd.ExecuteNonQuery()
                'con.Close()
            End If

            frm.Enabled = True
            frm.TopMost = True
            frm.TopMost = False
        Catch exception As System.Exception
        End Try

        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
        'Sets buttons to see if pdf is viewable
        If File.Exists(CashReceiptExists) Then
            cmdViewReceipt.Enabled = True
            ScanToolStripMenuItem.Enabled = True
            UploadToolStripMenuItem.Enabled = True
        Else
            cmdViewReceipt.Enabled = False
            ScanToolStripMenuItem.Enabled = False
            UploadToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub bgwkRemoteWIA_CompletedAppend(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            LoadingScreen.Hide()
            Dim name1, name2, final1 As String
            If remoteWIA.SaveFile(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf") Then
                MessageBox.Show("Cash receipt uploaded with " + remoteWIA.PageCount() + " pages successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                ErrorDescription = "Scan Error"
                ErrorReferenceNumber = ""

                'Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

                'With cmd.Parameters
                '.Add("@Date", SqlDbType.Date).Value = Today()
                '.Add("@Description", SqlDbType.VarChar).Value = ErrorDescription
                '.Add("@ErrorReference", SqlDbType.VarChar).Value = ErrorReferenceNumber
                '.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                '.Add("@Comment", SqlDbType.VarChar).Value = dir.FullName + "\" + ShipmentNumber.ToString() + ".pdf"
                '.Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
                'End With

                'If con.State = ConnectionState.Closed Then con.Open()
                'cmd.ExecuteNonQuery()
                'con.Close()
            End If
            Dim initial As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
            Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
            My.Computer.FileSystem.MoveFile(initial, final)

            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf") And File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf") Then

                final1 = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
                name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"
                Dim pathArray = New String() {name1, name2}

                MergePdfFiles(pathArray, final1)
            End If

            frm.Enabled = True
            frm.TopMost = True
            frm.TopMost = False
        Catch exception As System.Exception
        End Try

    End Sub

    Private Sub cboPaymentID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPaymentID.TextChanged
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
        'Sets buttons to see if pdf is viewable
        If File.Exists(CashReceiptExists) Then
            cmdViewReceipt.Enabled = True
            ScanToolStripMenuItem.Enabled = True
            UploadToolStripMenuItem.Enabled = True
        Else
            cmdViewReceipt.Enabled = False
            ScanToolStripMenuItem.Enabled = False
            UploadToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub DeleteDirectory(ByVal path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
            'Delete all child Directories
            For Each dir As String In Directory.GetDirectories(path)
                DeleteDirectory(dir)
            Next
            'Delete a Directory
            Directory.Delete(path)
        End If
    End Sub

    Private Sub cmdUploadReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadReceipt.Click
        If canSave() Then
            Try
                Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
            Catch ex As System.Exception
            End Try

            Dim MoveLocation As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\"
            Dim destinationPath As String = ""

            Dim fd As OpenFileDialog = New OpenFileDialog()
            Dim strFileName As String = ""

            fd.Title = "Open File Dialog"
            fd.InitialDirectory = "C:\"
            fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
            fd.FilterIndex = 2
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                strFileName = fd.FileName
            End If

            If File.Exists(strFileName) Then
                Dim filename As String = System.IO.Path.GetFileName(strFileName)
                destinationPath = System.IO.Path.Combine(MoveLocation, filename)
                If File.Exists(destinationPath) Then
                    File.Delete(destinationPath)
                End If
                File.Move(strFileName, destinationPath)
                Dim rename As String = cboPaymentID.Text + ".pdf"
                My.Computer.FileSystem.RenameFile(destinationPath, rename)
                MsgBox("File Moved")
                Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
                'Sets buttons to see if pdf is viewable
                If File.Exists(CashReceiptExists) Then
                    cmdViewReceipt.Enabled = True
                    ScanToolStripMenuItem.Enabled = True
                    UploadToolStripMenuItem.Enabled = True
                    cmdUploadReceipt.Enabled = False
                    cmdScan.Enabled = False
                Else
                    cmdViewReceipt.Enabled = False
                    ScanToolStripMenuItem.Enabled = False
                    UploadToolStripMenuItem.Enabled = False
                    cmdUploadReceipt.Enabled = True
                    cmdScan.Enabled = True
                End If

            Else
                MsgBox("File Not Moved")
            End If
        End If
    End Sub

    Public Sub ScanCashReceipt(Optional ByVal newPDF As Boolean = True)
        remoteCheck = False
        If canSave() Then

            ' Deletes the WIA testing temp file
            Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
            ' Creates the folder if the temp folder is not currently created
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
            Try
                If File.Exists("\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf") Then My.Computer.FileSystem.DeleteFile("\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf")
            Catch ex As System.Exception
            End Try
            path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            'If there had been a previous scan then delete the picture from the picturebox
            GlobalVariables.Counter = 0
            Dim mgr As New WIA.DeviceManagerClass
            Dim Scanner As WIA.Device = Nothing
            If mgr.DeviceInfos.Count > 1 Then
                ''More than 1 scanner was detected
                Dim lst As New List(Of Integer)
                ''Finds all the USB scanners
                For i As Integer = 1 To mgr.DeviceInfos.Count()
                    If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                        lst.Add(i)
                    End If
                Next
                ''Check to see how many usb scanners were found
                If lst.Count > 1 Or lst.Count = 0 Then
                    Dim selectScanner As New WIA.CommonDialog
                    Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
                Else
                    Scanner = mgr.DeviceInfos(lst(0)).Connect()
                End If
            ElseIf mgr.DeviceInfos.Count = 0 Then
                ''No scanners were detected
                If My.Computer.Name.ToString.StartsWith("TFP") Then
                    Dim loadingScreen As New Loading


                    bgwkRemoteWIA = New BackgroundWorker()
                    bgwkRemoteWIA.WorkerReportsProgress = True
                    AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_run
                    AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_Completed
                    AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_Progress
                    remoteCheck = True

                    remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, ShipmentNumber)
                    bgwkRemoteWIA.RunWorkerAsync()
                Else
                    ''No scanners were detected
                    MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                ''Only 1 scanner is connected
                Scanner = mgr.DeviceInfos(1).Connect()
            End If
            If Scanner IsNot Nothing Then
                Dim item As WIA.Item = Scanner.Items(1)
                Dim obj As Object
                Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
                ''Specific scanning properties
                For Each prop As WIA.Property In Scanner.Items(1).Properties
                    Dim x As WIA.IProperty = prop
                    Select Case prop.PropertyID
                        Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                            obj = 0
                            x.let_Value(obj)
                        Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                            obj = 2
                            x.let_Value(obj)
                        Case "6147" ''(DPI) Horizontal Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6148" ''(DPI) Vertical Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6151" ''horizontal extent (width)
                            obj = 1700
                            x.let_Value(obj)
                        Case "6152" ''vertical extent (height)
                            obj = 2338
                            x.let_Value(obj)
                    End Select
                Next

                Dim dial As New WIA.CommonDialog
                Dim hasMorePages As Boolean = True
                Dim ScannedAtleastOnePage As Boolean = False
                Dim pages As Integer = 0
                Dim ScannedImages As New List(Of iTextSharp.text.Image)

                ''Loops until all pages are scanned.
                While hasMorePages
                    GlobalVariables.Counter = GlobalVariables.Counter + 1
                    pages += 1
                    Try
                        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                        Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                        Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                        Img.SaveFile(tmp)
                        'ScannedImages.Add(Img.fromfile(tmp))
                        ScannedAtleastOnePage = True


                    Catch ex As System.Exception
                        ''Looks for paper empty error to break the loop and/or to show error message
                        If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                            If Not ScannedAtleastOnePage Then
                                MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                GlobalVariables.paperscan = False
                            Else
                                GlobalVariables.paperscan = True
                            End If
                            hasMorePages = False
                        End If
                    End Try
                End While

                'Displays the first saved scan into the picturebox
                If GlobalVariables.paperscan Then
                    GlobalVariables.StartCounter = 1
                    Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                    GlobalVariables.NextPrevious = GlobalVariables.StartCounter

                End If
            End If
            'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
            GlobalVariables.previousScan = True
            GlobalVariables.NextPrevious = 1


            Dim extensions As New List(Of String)
            extensions.Add("*.bmp")
            Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

            'counts the files in the folder
            Dim fileCount As Integer
            For i As Integer = 0 To extensions.Count - 1
                fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
            Next
            GlobalVariables.totalfiles = fileCount

        End If
    End Sub

    Public Sub ReScanCashReceipt(Optional ByVal newPDF As Boolean = True)
        remoteCheck = False
        If canSave() Then

            ' Deletes the WIA testing temp file
            Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
            ' Creates the folder if the temp folder is not currently created
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")

            If File.Exists("\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf") Then My.Computer.FileSystem.DeleteFile("\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf")

            path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            'If there had been a previous scan then delete the picture from the picturebox
            GlobalVariables.Counter = 0

            Dim mgr As New WIA.DeviceManagerClass
            Dim Scanner As WIA.Device = Nothing
            If mgr.DeviceInfos.Count > 1 Then
                ''More than 1 scanner was detected
                Dim lst As New List(Of Integer)
                ''Finds all the USB scanners
                For i As Integer = 1 To mgr.DeviceInfos.Count()
                    If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                        lst.Add(i)
                    End If
                Next
                ''Check to see how many usb scanners were found
                If lst.Count > 1 Or lst.Count = 0 Then
                    Dim selectScanner As New WIA.CommonDialog
                    Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
                Else
                    Scanner = mgr.DeviceInfos(lst(0)).Connect()
                End If
            ElseIf mgr.DeviceInfos.Count = 0 Then
                ''No scanners were detected
                If My.Computer.Name.ToString.StartsWith("TFP") Then
                    Dim loadingScreen As New Loading


                    bgwkRemoteWIA = New BackgroundWorker()
                    bgwkRemoteWIA.WorkerReportsProgress = True
                    AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_run
                    AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_Completed
                    AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_Progress
                    remoteCheck = True

                    remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, ShipmentNumber)
                    bgwkRemoteWIA.RunWorkerAsync()
                Else
                    ''No scanners were detected
                    MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                ''Only 1 scanner is connected
                Scanner = mgr.DeviceInfos(1).Connect()
            End If
            If Scanner IsNot Nothing Then
                Dim item As WIA.Item = Scanner.Items(1)
                Dim obj As Object
                Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
                ''Specific scanning properties
                For Each prop As WIA.Property In Scanner.Items(1).Properties
                    Dim x As WIA.IProperty = prop
                    Select Case prop.PropertyID
                        Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                            obj = 0
                            x.let_Value(obj)
                        Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                            obj = 2
                            x.let_Value(obj)
                        Case "6147" ''(DPI) Horizontal Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6148" ''(DPI) Vertical Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6151" ''horizontal extent (width)
                            obj = 1700
                            x.let_Value(obj)
                        Case "6152" ''vertical extent (height)
                            obj = 2338
                            x.let_Value(obj)
                    End Select
                Next

                Dim dial As New WIA.CommonDialog
                Dim hasMorePages As Boolean = True
                Dim ScannedAtleastOnePage As Boolean = False
                Dim pages As Integer = 0
                Dim ScannedImages As New List(Of iTextSharp.text.Image)

                ''Loops until all pages are scanned.
                While hasMorePages
                    GlobalVariables.Counter = GlobalVariables.Counter + 1
                    pages += 1
                    Try
                        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                        Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                        Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                        Img.SaveFile(tmp)
                        'ScannedImages.Add(Img.fromfile(tmp))
                        ScannedAtleastOnePage = True


                    Catch ex As System.Exception
                        ''Looks for paper empty error to break the loop and/or to show error message
                        If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                            If Not ScannedAtleastOnePage Then
                                MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                GlobalVariables.paperscan = False
                            Else
                                GlobalVariables.paperscan = True
                            End If
                            hasMorePages = False
                        End If
                    End Try
                End While

                'Displays the first saved scan into the picturebox
                If GlobalVariables.paperscan Then
                    GlobalVariables.StartCounter = 1
                    Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                    GlobalVariables.NextPrevious = GlobalVariables.StartCounter

                End If
            End If
            'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
            GlobalVariables.previousScan = True
            GlobalVariables.NextPrevious = 1


            Dim extensions As New List(Of String)
            extensions.Add("*.bmp")
            Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

            'counts the files in the folder
            Dim fileCount As Integer
            For i As Integer = 0 To extensions.Count - 1
                fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
            Next
            GlobalVariables.totalfiles = fileCount
        End If
    End Sub

    Public Shared Function MergePdfFiles(ByVal pdfFiles() As String, ByVal outputPath As String) As Boolean
        Dim result As Boolean = False
        Dim pdfCount As Integer = 0     'total input pdf file count
        Dim f As Integer = 0    'pointer to current input pdf file
        Dim fileName As String
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim pageCount As Integer = 0
        Dim pdfDoc As iTextSharp.text.Document = Nothing    'the output pdf document
        Dim writer As PdfWriter = Nothing
        Dim cb As PdfContentByte = Nothing

        Dim page As PdfImportedPage = Nothing
        Dim rotation As Integer = 0

        'Try
        pdfCount = pdfFiles.Length
        If pdfCount > 1 Then
            'Open the 1st item in the array PDFFiles
            fileName = pdfFiles(f)
            reader = New iTextSharp.text.pdf.PdfReader(fileName)
            'Get page count
            pageCount = reader.NumberOfPages

            pdfDoc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1), 18, 18, 18, 18)

            writer = PdfWriter.GetInstance(pdfDoc, New FileStream(outputPath, FileMode.OpenOrCreate))


            With pdfDoc
                .Open()
            End With
            'Instantiate a PdfContentByte object
            cb = writer.DirectContent
            'Now loop thru the input pdfs
            While f < pdfCount
                'Declare a page counter variable
                Dim i As Integer = 0
                'Loop thru the current input pdf's pages starting at page 1
                While i < pageCount
                    i += 1
                    'Get the input page size
                    pdfDoc.SetPageSize(reader.GetPageSizeWithRotation(i))
                    'Create a new page on the output document
                    pdfDoc.NewPage()
                    'If it is the 1st page, we add bookmarks to the page
                    'Now we get the imported page
                    page = writer.GetImportedPage(reader, i)
                    'Read the imported page's rotation
                    rotation = reader.GetPageRotation(i)
                    'Then add the imported page to the PdfContentByte object as a template based on the page's rotation
                    If rotation = 90 Then
                        cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(i).Height)
                    ElseIf rotation = 270 Then
                        cb.AddTemplate(page, 0, 1.0F, -1.0F, 0, reader.GetPageSizeWithRotation(i).Width + 60, -30)
                    Else
                        cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0)
                    End If
                End While
                'Increment f and read the next input pdf file
                f += 1
                If f < pdfCount Then
                    fileName = pdfFiles(f)
                    reader = New iTextSharp.text.pdf.PdfReader(fileName)
                    pageCount = reader.NumberOfPages
                End If
            End While
            'When all done, we close the document so that the pdfwriter object can write it to the output file
            pdfDoc.Close()
            result = True
        End If
        'Catch ex As Exception
        Return False
        'End Try
        Return result
    End Function

    Public Sub FinalUploadCashReceipt()
        'Tries to upload the file from the temp file and then saves it to correct folder
        Try
            UploadCashReceipt()
            
            Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
            'Sets buttons to see if pdf is viewable
            If File.Exists(CashReceiptExists) Then
                cmdViewReceipt.Enabled = True
                ScanToolStripMenuItem.Enabled = True
                UploadToolStripMenuItem.Enabled = True
                cmdScan.Enabled = False
                cmdUploadReceipt.Enabled = False
            Else
                cmdViewReceipt.Enabled = False
                ScanToolStripMenuItem.Enabled = False
                UploadToolStripMenuItem.Enabled = False
                cmdScan.Enabled = True
                cmdUploadReceipt.Enabled = True
            End If
        Catch ex As TargetInvocationException
            'We only catch this one, so you can catch other exception later on
            'We get the inner exception because ex is not helpfull
            Dim iEX = ex.InnerException

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ReFinalUploadCashReceipt()
        'Tries to upload the file from the temp file and then saves it to correct folder
        Try
            ReUploadCashReceipt()

            Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
            'Sets buttons to see if pdf is viewable
            If File.Exists(CashReceiptExists) Then
                cmdViewReceipt.Enabled = True
                ScanToolStripMenuItem.Enabled = True
                UploadToolStripMenuItem.Enabled = True
                cmdScan.Enabled = False
                cmdUploadReceipt.Enabled = False
            Else
                cmdViewReceipt.Enabled = False
                ScanToolStripMenuItem.Enabled = False
                UploadToolStripMenuItem.Enabled = False
                cmdScan.Enabled = True
                cmdUploadReceipt.Enabled = True
            End If
        Catch ex As TargetInvocationException
            'We only catch this one, so you can catch other exception later on
            'We get the inner exception because ex is not helpfull
            Dim iEX = ex.InnerException
        Catch ex As Exception

        End Try

        Dim bytecount As Integer = 0
        bytecount = FileLen("\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf")
        If bytecount < 1000 Then
            My.Computer.FileSystem.DeleteFile("\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf")
            MsgBox("Scanning Error, Please Re-Upload File")
        End If
    End Sub

    Public Sub ReUploadCashReceipt()
        Dim boolCheck As Boolean = True
        Dim FilesInFolder As Integer
        Dim FullName As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"
        FilesInFolder = Directory.GetFiles(FullName, "*.bmp").Count

        'Variables Declared
        Dim comboboxSelection As String = cboPaymentID.Text

        Dim strDir As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\"

        'Dim pdfDoc As New document()

        'Name of file
        Dim strFilename As String = cboPaymentID.Text + ".pdf"
        Dim pdfDoc As New document()
        Dim i As Integer = 1
        Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
        'path to bmp
        Dim strCompletePath As String = strDir & strFilename
        Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
        pdfDoc.Open()
        'Grabs the bmp image seen on screen
        Dim img As iTextSharp.text.Image = GetInstance(strPathname)
        'structures it to fit on pdf file
        img.ScalePercent(72.0F / img.DpiX * 100)
        img.SetAbsolutePosition(0, 0)
        'adds image to the document
        pdfDoc.Add(img)

        i += 1
        While i <= FilesInFolder
            pdfDoc.NewPage()
            strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
            'path to bmp
            strCompletePath = strDir & strFilename
            'Grabs the bmp image seen on screen
            img = GetInstance(strPathname)
            'structures it to fit on pdf file
            img.ScalePercent(72.0F / img.DpiX * 100)
            img.SetAbsolutePosition(0, 0)
            'adds image to the document
            pdfDoc.Add(img)
            i += 1
        End While
        pdfDoc.Close()

    End Sub

    Public Sub UploadCashReceipt()
        Dim boolCheck As Boolean = True
        Dim FilesInFolder As Integer
        Dim FullName As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"
        FilesInFolder = Directory.GetFiles(FullName, "*.bmp").Count


        'Variables Declared
        Dim comboboxSelection As String = cboPaymentID.Text

        Dim strDir As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\"

        'Dim pdfDoc As New document()

        'Name of file
        Dim strFilename As String = cboPaymentID.Text + ".pdf"
        Dim pdfDoc As New document()
        Dim i As Integer = 1
        Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
        'path to bmp
        Dim strCompletePath As String = strDir & strFilename
        Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
        pdfDoc.Open()
        'Grabs the bmp image seen on screen
        Dim img As iTextSharp.text.Image = GetInstance(strPathname)
        'structures it to fit on pdf file
        img.ScalePercent(72.0F / img.DpiX * 100)
        img.SetAbsolutePosition(0, 0)
        'adds image to the document
        pdfDoc.Add(img)

        i += 1
        While i <= FilesInFolder
            pdfDoc.NewPage()
            strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
            'path to bmp
            strCompletePath = strDir & strFilename
            'Grabs the bmp image seen on screen
            img = GetInstance(strPathname)
            'structures it to fit on pdf file
            img.ScalePercent(72.0F / img.DpiX * 100)
            img.SetAbsolutePosition(0, 0)
            'adds image to the document
            pdfDoc.Add(img)
            i += 1
        End While
        pdfDoc.Close()

    End Sub

    Private Sub cmdScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScan.Click
        Dim paymentID As String = cboPaymentID.Text

        ScanCashReceipt()

        If remoteCheck = False Then
            FinalUploadCashReceipt()
        End If


        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + paymentID + ".pdf"

        'Sets buttons to see if pdf is viewable
        If File.Exists(CashReceiptExists) Then
            cmdViewReceipt.Enabled = True
            ScanToolStripMenuItem.Enabled = True
            UploadToolStripMenuItem.Enabled = True
            ReUploadReceiptToolStripMenuItem.Enabled = True
        Else
            cmdViewReceipt.Enabled = False
            ScanToolStripMenuItem.Enabled = False
            UploadToolStripMenuItem.Enabled = False
            ReUploadReceiptToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub ScanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanToolStripMenuItem.Click
        Dim name1, name2, final1 As String
        Dim remoteScan As Boolean = False
        Dim W9Exists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
        If File.Exists(W9Exists) Then
            If canSave() Then

                ' Deletes the WIA testing temp file
                Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                ' Creates the folder if the temp folder is not currently created
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")

                path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                'If there had been a previous scan then delete the picture from the picturebox
                GlobalVariables.Counter = 0
                Dim mgr As New WIA.DeviceManagerClass
                Dim Scanner As WIA.Device = Nothing
                If mgr.DeviceInfos.Count > 1 Then
                    ''More than 1 scanner was detected
                    Dim lst As New List(Of Integer)
                    ''Finds all the USB scanners
                    For i As Integer = 1 To mgr.DeviceInfos.Count()
                        If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                            lst.Add(i)
                        End If
                    Next
                    ''Check to see how many usb scanners were found
                    If lst.Count > 1 Or lst.Count = 0 Then
                        Dim selectScanner As New WIA.CommonDialog
                        Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
                    Else
                        Scanner = mgr.DeviceInfos(lst(0)).Connect()
                    End If
                ElseIf mgr.DeviceInfos.Count = 0 Then
                    ''No scanners were detected
                    If My.Computer.Name.ToString.StartsWith("TFP") Then
                        Dim loadingScreen As New Loading

                        bgwkRemoteWIA = New BackgroundWorker()
                        bgwkRemoteWIA.WorkerReportsProgress = True
                        AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_run
                        AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_CompletedAppend
                        AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_Progress
                        remoteScan = True

                        remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, ShipmentNumber)
                        bgwkRemoteWIA.RunWorkerAsync()

                        loadingScreen.Close()
                    Else
                        ''No scanners were detected
                        MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    ''Only 1 scanner is connected
                    Scanner = mgr.DeviceInfos(1).Connect()
                End If

                If Scanner IsNot Nothing Then
                    Dim item As WIA.Item = Scanner.Items(1)
                    Dim obj As Object
                    Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
                    ''Specific scanning properties
                    For Each prop As WIA.Property In Scanner.Items(1).Properties
                        Dim x As WIA.IProperty = prop
                        Select Case prop.PropertyID
                            Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                                obj = 0
                                x.let_Value(obj)
                            Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                                obj = 2
                                x.let_Value(obj)
                            Case "6147" ''(DPI) Horizontal Resolution
                                obj = 200
                                x.let_Value(obj)
                            Case "6148" ''(DPI) Vertical Resolution
                                obj = 200
                                x.let_Value(obj)
                            Case "6151" ''horizontal extent (width)
                                obj = 1700
                                x.let_Value(obj)
                            Case "6152" ''vertical extent (height)
                                obj = 2338
                                x.let_Value(obj)
                        End Select
                    Next

                    Dim dial As New WIA.CommonDialog
                    Dim hasMorePages As Boolean = True
                    Dim ScannedAtleastOnePage As Boolean = False
                    Dim pages As Integer = 0
                    Dim ScannedImages As New List(Of iTextSharp.text.Image)
                    If remoteScan = False Then
                        ''Loops until all pages are scanned.
                        While hasMorePages
                            GlobalVariables.Counter = GlobalVariables.Counter + 1
                            pages += 1
                            Try
                                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                                Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                                Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                                Img.SaveFile(tmp)
                                'ScannedImages.Add(Img.fromfile(tmp))
                                ScannedAtleastOnePage = True


                            Catch ex As System.Exception
                                ''Looks for paper empty error to break the loop and/or to show error message
                                If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                                    If Not ScannedAtleastOnePage Then
                                        MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        GlobalVariables.paperscan = False
                                    Else
                                        GlobalVariables.paperscan = True
                                    End If
                                    hasMorePages = False
                                End If
                            End Try
                        End While
                    End If
                    'Displays the first saved scan into the picturebox
                    If GlobalVariables.paperscan Then
                        GlobalVariables.StartCounter = 1
                        Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                        GlobalVariables.NextPrevious = GlobalVariables.StartCounter

                    End If
                End If

                'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
                GlobalVariables.previousScan = True
                GlobalVariables.NextPrevious = 1

                Dim extensions As New List(Of String)
                extensions.Add("*.bmp")
                Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

                'counts the files in the folder
                Dim fileCount As Integer
                For i As Integer = 0 To extensions.Count - 1
                    fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
                Next
                GlobalVariables.totalfiles = fileCount
            End If

            If remoteScan = False Then
                Try
                    'Variables Declared
                    Dim comboboxSelection As String = cboPaymentID.Text

                    Dim strDir As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\"
                    If Not System.IO.Directory.Exists(strDir) Then System.IO.Directory.CreateDirectory(strDir)

                    'Name of file

                    Dim strFilename As String = "Appended2.pdf"
                    'path to bmp
                    Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                    Dim strCompletePath As String = strDir & strFilename
                    Dim pdfDoc As New document()
                    Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
                    pdfDoc.Open()
                    'Grabs the bmp image seen on screen
                    Dim img As iTextSharp.text.Image = GetInstance(strPathname)
                    'structures it to fit on pdf file
                    img.ScalePercent(72.0F / img.DpiX * 100)
                    img.SetAbsolutePosition(0, 0)
                    'adds image to the document
                    pdfDoc.Add(img)
                    'closes the pdf and saves it
                    pdfDoc.Close()

                    'messagebox confirmation on saving
                    MessageBox.Show("Save Confirmation", "Saved Cash Receipt PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    'declares list of bmp files to be counted
                    Dim extensions As New List(Of String)
                    extensions.Add("*.bmp")
                    Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

                    GlobalVariables.previousScan = True

                    Dim initial As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
                    Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                    My.Computer.FileSystem.MoveFile(initial, final)
                    final1 = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
                    name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                    name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"

                    Dim bytecount3 As Integer = 0
                    bytecount3 = FileLen(name1)
                    If bytecount3 < 1001 Then
                        My.Computer.FileSystem.DeleteFile(name1)
                        MsgBox("Scanning Error, Initial File Not Valid, Please Re-Upload File")
                        Exit Sub
                    End If

                    Dim bytecount2 As Integer = 0
                    bytecount2 = FileLen(name2)
                    If bytecount2 < 1001 Then
                        My.Computer.FileSystem.DeleteFile(name2)
                        MsgBox("Scanning Error, Appended File Not Valid, Please Re-Upload File")
                        My.Computer.FileSystem.MoveFile(final, initial)
                        Exit Sub
                    End If

                    Dim pathArray = New String() {name1, name2}
                    Try
                        MergePdfFiles(pathArray, final1)
                        MsgBox("File Appended")
                    Catch ex As Exception
                        MsgBox("File Not Appended")
                    End Try

                Catch ex As TargetInvocationException
                    'We only catch this one, so you can catch other exception later on
                    'We get the inner exception because ex is not helpfull
                    Dim iEX = ex.InnerException
                Catch ex As Exception

                End Try
            End If
        Else
            MsgBox("No Initial Upload")
        End If

        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
        'Sets buttons to see if pdf is viewable
        If File.Exists(CashReceiptExists) Then
            cmdViewReceipt.Enabled = True
        Else
            cmdViewReceipt.Enabled = False
        End If
        Dim bytecount As Integer = 0
        bytecount = FileLen("\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf")
        If bytecount < 1001 Then
            My.Computer.FileSystem.DeleteFile("\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf")
            MsgBox("Scanning Error, Please ReUpload File")
        End If
    End Sub

    Private Sub UploadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadToolStripMenuItem.Click
        If canSave() Then

            Dim W9Exists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
            If File.Exists(W9Exists) Then
                Try
                    Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")

                Catch ex As System.Exception
                End Try

                Dim MoveLocation As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND"
                Dim destinationPath As String = ""

                Dim fd As OpenFileDialog = New OpenFileDialog()
                Dim strFileName As String = ""

                fd.Title = "Open File Dialog"
                fd.InitialDirectory = "C:\"
                fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
                fd.FilterIndex = 2
                fd.RestoreDirectory = True

                If fd.ShowDialog() = DialogResult.OK Then
                    strFileName = fd.FileName
                End If

                If File.Exists(strFileName) Then
                    Dim filename As String = System.IO.Path.GetFileName(strFileName)
                    destinationPath = System.IO.Path.Combine(MoveLocation, filename)
                    If File.Exists(destinationPath) Then
                        File.Delete(destinationPath)
                    End If
                    File.Move(strFileName, destinationPath)
                    Dim rename As String = "Appended2" + ".pdf"
                    My.Computer.FileSystem.RenameFile(destinationPath, rename)
                    Dim name1, name2, final1 As String
                    Dim initial As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
                    Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                    My.Computer.FileSystem.MoveFile(initial, final)
                    final1 = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
                    name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                    name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"

                    Dim pathArray = New String() {name1, name2}
                    Try
                        MergePdfFiles(pathArray, final1)
                        MsgBox("File Appended")
                    Catch ex As Exception
                        MsgBox("File Not Appended")
                    End Try
                Else
                    MsgBox("File Not Appended")
                End If

                Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
                'Sets buttons to see if pdf is viewable
                If File.Exists(CashReceiptExists) Then
                    cmdViewReceipt.Enabled = True
                    ScanToolStripMenuItem.Enabled = True
                    UploadToolStripMenuItem.Enabled = True
                    cmdUploadReceipt.Enabled = False
                    cmdScan.Enabled = False
                Else
                    cmdViewReceipt.Enabled = False
                    ScanToolStripMenuItem.Enabled = False
                    UploadToolStripMenuItem.Enabled = False
                    cmdUploadReceipt.Enabled = True
                    cmdScan.Enabled = True
                End If
            Else
                MsgBox("File Not move")
            End If

        End If
    End Sub

    Private Sub cmdViewReceipt_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewReceipt.Click
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
        If File.Exists(CashReceiptExists) Then
            System.Diagnostics.Process.Start(CashReceiptExists)
        End If
    End Sub

    Private Sub ScanToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanToolStripMenuItem1.Click
        ReScanCashReceipt()
        ReFinalUploadCashReceipt()
    End Sub

    Private Sub UploadToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadToolStripMenuItem1.Click
        If canSave() Then
            Dim MoveLocation As String = "\\TFP-FS\CashReceipts\UploadedCashReceipst\"
            Dim destinationPath As String = ""

            Try
                Dim filename As String = cboPaymentID.Text + ".pdf"
                destinationPath = System.IO.Path.Combine(MoveLocation, filename)
                If File.Exists(destinationPath) Then
                    File.Delete(destinationPath)
                End If

                Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
            Catch ex As System.Exception
            End Try

            Dim fd As OpenFileDialog = New OpenFileDialog()
            Dim strFileName As String = ""

            fd.Title = "Open File Dialog"
            fd.InitialDirectory = "C:\"
            fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
            fd.FilterIndex = 2
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                strFileName = fd.FileName
            End If

            If File.Exists(strFileName) Then
                Dim filename As String = System.IO.Path.GetFileName(strFileName)
                destinationPath = System.IO.Path.Combine(MoveLocation, filename)
                If File.Exists(destinationPath) Then
                    File.Delete(destinationPath)
                End If
                File.Move(strFileName, destinationPath)
                Dim rename As String = cboPaymentID.Text + ".pdf"
                My.Computer.FileSystem.RenameFile(destinationPath, rename)
                MsgBox("File Moved")

            Else
                MsgBox("File Not Moved")
            End If
        End If
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboPaymentID.Text + ".pdf"
        'Sets buttons to see if pdf is viewable
        If File.Exists(CashReceiptExists) Then
            cmdViewReceipt.Enabled = True
            ScanToolStripMenuItem.Enabled = True
            UploadToolStripMenuItem.Enabled = True
            cmdUploadReceipt.Enabled = False
            cmdScan.Enabled = False
        Else
            cmdViewReceipt.Enabled = False
            ScanToolStripMenuItem.Enabled = False
            UploadToolStripMenuItem.Enabled = False
            cmdUploadReceipt.Enabled = True
            cmdScan.Enabled = True
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboPaymentID.Text = "" Or cboPaymentID.SelectedIndex = -1 Then
            cmdViewReceipt.Enabled = False
            cmdPrint.Enabled = False
            cmdScan.Enabled = False
        End If
    End Sub

    Private Sub cmdRemoteScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoteScan.Click
        Dim ReceiptFilename As String = ""
        Dim ReceiptFilenameAndPath As String = ""
        Dim strReceiptNumber As String = ""

        'Verify that they have a Receipt selected
        If cboPaymentID.Text = "" Then
            MsgBox("You must select a valid Receipt.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            strReceiptNumber = cboPaymentID.Text
        End If

        Dim UploadedReceiptNumber As String = cboPaymentID.Text

        ReceiptFilename = strReceiptNumber + ".pdf"
        ReceiptFilenameAndPath = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + ReceiptFilename

        If File.Exists(ReceiptFilenameAndPath) Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to overwrite this scanned Receipt?", "OVERWRITE EXISTING RECEIPT?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Delete existing Receipt before upload
                File.Delete(ReceiptFilenameAndPath)

                Dim My_Process As New Process()
                'Dim My_Process_Info As New ProcessStartInfo

                Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
                strReceiptNumber = CStr(cboPaymentID.Text)

                ReceiptFilename = strReceiptNumber + ".pdf"
                ReceiptFilenameAndPath = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + ReceiptFilename

                'My_Process_Info.UseShellExecute = False
                'My_Process_Info.RedirectStandardOutput = True
                'My_Process_Info.RedirectStandardError = True
                'My_Process_Info.CreateNoWindow = True

                Try
                    My_Process.Start(ApplicationFileAndPath, "-o " & ReceiptFilenameAndPath)
                    'My_Process.WaitForExit()
                    My_Process.Close()
                Catch ex As Exception
                    '    'Log error on update failure
                    Dim TempReceiptNumber As Integer = 0
                    Dim strReceiptNumber1 As String = ""
                    TempReceiptNumber = Val(cboPaymentID.Text)
                    strReceiptNumber1 = CStr(TempReceiptNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ApplicationFileAndPath & "" & ReceiptFilenameAndPath
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "A/R Cash Receipt --- Scan"
                    ErrorReferenceNumber = "Receipt # " + strReceiptNumber1
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MsgBox("Scan failed", MsgBoxStyle.OkOnly)
                End Try
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        Else
            Dim My_Process As New Process()
            'Dim My_Process_Info As New ProcessStartInfo

            Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"
            strReceiptNumber = CStr(cboPaymentID.Text)

            ReceiptFilename = strReceiptNumber + ".pdf"
            ReceiptFilenameAndPath = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + ReceiptFilename

            'My_Process_Info.UseShellExecute = False
            'My_Process_Info.RedirectStandardOutput = True
            'My_Process_Info.RedirectStandardError = True
            'My_Process_Info.CreateNoWindow = True

            Try
                My_Process.Start(ApplicationFileAndPath, "-o " & ReceiptFilenameAndPath)
                'My_Process.WaitForExit()
                My_Process.Close()
            Catch ex As Exception
                '    'Log error on update failure
                Dim TempReceiptNumber As Integer = 0
                Dim strReceiptNumber1 As String = ""
                TempReceiptNumber = Val(cboPaymentID.Text)
                strReceiptNumber1 = CStr(TempReceiptNumber)

                ErrorDate = TodaysDate
                ErrorComment = ApplicationFileAndPath & "" & ReceiptFilenameAndPath
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "A/R Cash Receipt --- Scan"
                ErrorReferenceNumber = "Receipt # " + strReceiptNumber1
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Scan failed", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub
End Class