Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.Net.Mail
Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class EmailPage
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Dim EmailFileNameAndPath, EmailSubjectLine, EmailBody, EmailAddresses As String
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim StatementFileName As String = ""
    Dim DefaultSignature As String
    Dim MessageFileNameAndPath As String = ""
    Dim LastAnnouncementNumber, NextAnnouncementNumber As Integer
    Dim LastLineNumber, NextLineNumber As Integer
    Dim badChars As String = ":,/!#$%^&*()[]+=<>?"
    Dim ValidateEmailAddress As String = ""
    Dim AdditionalFileName As String = ""
    Dim AdditionalFileNameAndPath As String = ""
    Dim LastNoteNumber, NextNoteNumber As Integer
    Dim strInvoiceNumber As String = ""
    Dim UserSignature As String = ""

    Dim MyMailMessage As New MailMessage()

    'Configure Data Connection and declare variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As New DataTable

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearGlobalVariables()

        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        'Add to Error Log
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

    Public Sub ClearGlobalVariables()
        TFPMailCustomer = ""
        TFPMailFilename = ""
        TFPMailFilename2 = ""
        TFPMailFilename3 = ""
        TFPMailFilePath = ""
        TFPMailFilePath2 = ""
        TFPMailFilePath3 = ""
        TFPMailReplyAddress = ""
        TFPMailSendAddress = ""
        TFPMailToAddress = ""
        TFPMailTransactionNumber = 0
        TFPMailTransactionType = ""
        EmailCustomerEmailAddress = ""
        EmailInvoiceCustomer = ""
        EmailCustomerCerts = ""
        EmailInvoiceCustomer = ""
        EmailInvoiceNumber = 0
        EmailShipmentNumber = 0
        EmailSalesOrderNumber = 0
        EmailStringInvoiceNumber = ""
        EmailFileNameAndPath = ""
    End Sub

    Public Sub ClearAllFields()
        txtEmailBcc.Clear()
        txtEmailBody.Clear()
        txtEmailCc.Clear()
        txtEmailSubject.Clear()
        txtEmailTo.Clear()
        txtReceiverNumber.Clear()
        txtShipmentNumber.Clear()

        listToAddressBook.Visible = False
        listCCAddressBook.Visible = False
        listBCCAddressBook.Visible = False

        lblEmailAttachments.Text = ""
    End Sub

    Public Sub LoadAddressBook()
        If GlobalDivisionCode = "" Then GlobalDivisionCode = EmployeeCompanyCode

        'Loads Customer List for the specific division
        cmd = New SqlCommand("SELECT DISTINCT (EmailAddress) FROM TFPMailAddressBook WHERE DivisionID = @DivisionID ORDER BY EmailAddress ASC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "TFPMailAddressBook")
        listToAddressBook.DataSource = ds1.Tables("TFPMailAddressBook")
        listCCAddressBook.DataSource = ds1.Tables("TFPMailAddressBook")
        listBCCAddressBook.DataSource = ds1.Tables("TFPMailAddressBook")
        con.Close()
    End Sub

    Public Sub LoadEmailSignature()
        'Load Email Signature into body of email
        Dim UserSignatureStatement As String = "SELECT Signature FROM EmployeeData WHERE LoginName = @LoginName"
        Dim UserSignatureCommand As New SqlCommand(UserSignatureStatement, con)
        UserSignatureCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UserSignature = CStr(UserSignatureCommand.ExecuteScalar)
        Catch ex As System.Exception
            UserSignature = ""
        End Try
        con.Close()

        If UserSignature = "" Then
            'Do nothing - no signature
        Else
            txtEmailBody.Text = Environment.NewLine + Environment.NewLine + Environment.NewLine + UserSignature
        End If
    End Sub

    Private Sub EmailPage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearGlobalVariables()
    End Sub

    Private Sub EmailPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If TFPMailTransactionType = "Print Sales Order" Then
            LoadAddressBook()

            'Load Defaults
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress

            'Get Customer's Email Address
            Dim EmailCustomer, EmailCustomerAddress As String

            Dim EmailCustomerStatement As String = "SELECT CustomerID FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
            Dim EmailCustomerCommand As New SqlCommand(EmailCustomerStatement, con)
            EmailCustomerCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomer = CStr(EmailCustomerCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomer = ""
            End Try
            con.Close()

            TFPMailCustomer = EmailCustomer
            LoadAddressBook()

            Dim EmailCustomerAddressStatement As String = "SELECT SalesContactEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailCustomerAddressCommand As New SqlCommand(EmailCustomerAddressStatement, con)
            EmailCustomerAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailCustomer
            EmailCustomerAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerAddress = CStr(EmailCustomerAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerAddress = ""
            End Try
            con.Close()

            'Get Customer's PO #
            Dim EmailCustomerPONumber As String = ""

            Dim EmailCustomerPONumberStatement As String = "SELECT CustomerPO FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
            Dim EmailCustomerPONumberCommand As New SqlCommand(EmailCustomerPONumberStatement, con)
            EmailCustomerPONumberCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerPONumber = CStr(EmailCustomerPONumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerPONumber = ""
            End Try
            con.Close()

            If EmailCustomerPONumber = "" Then
                txtEmailSubject.Text = "TFP Sales Order # " + CStr(TFPMailTransactionNumber)
            Else
                txtEmailSubject.Text = "TFP Sales Order # " + CStr(TFPMailTransactionNumber) + ", Cust. PO# - " + EmailCustomerPONumber
            End If

            txtEmailTo.Text = EmailCustomerAddress
        ElseIf TFPMailTransactionType = "Print Sales Confirmation" Then
            LoadAddressBook()

            'Load Defaults
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress

            'Get Customer's Email Address
            Dim EmailCustomer, EmailCustomerAddress As String

            Dim EmailCustomerStatement As String = "SELECT CustomerID FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
            Dim EmailCustomerCommand As New SqlCommand(EmailCustomerStatement, con)
            EmailCustomerCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomer = CStr(EmailCustomerCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomer = ""
            End Try
            con.Close()

            'Get Customer's PO#
            Dim EmailCustomerPONumber As String = ""

            Dim EmailCustomerPONumberStatement As String = "SELECT CustomerPO FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
            Dim EmailCustomerPONumberCommand As New SqlCommand(EmailCustomerPONumberStatement, con)
            EmailCustomerPONumberCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerPONumber = CStr(EmailCustomerPONumberCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerPONumber = ""
            End Try
            con.Close()

            TFPMailCustomer = EmailCustomer
            LoadAddressBook()

            Dim EmailCustomerAddressStatement As String = "SELECT SalesContactEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailCustomerAddressCommand As New SqlCommand(EmailCustomerAddressStatement, con)
            EmailCustomerAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailCustomer
            EmailCustomerAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerAddress = CStr(EmailCustomerAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerAddress = ""
            End Try
            con.Close()

            If EmailCustomerPONumber = "" Then
                txtEmailSubject.Text = "TFP Sales Confirmation # " + CStr(TFPMailTransactionNumber)
            Else
                txtEmailSubject.Text = "TFP Sales Confirmation # " + CStr(TFPMailTransactionNumber) + ", Cust. PO# - " + EmailCustomerPONumber
            End If

            txtEmailTo.Text = EmailCustomerAddress
        ElseIf TFPMailTransactionType = "Print Quote" Then
            LoadAddressBook()

            'Load Defaults
            txtEmailSubject.Text = "Trufit / Truweld Quote # " + CStr(TFPMailTransactionNumber)
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress

            'Get Customer's Email Address
            Dim EmailCustomer, EmailCustomerAddress As String

            Dim EmailCustomerStatement As String = "SELECT CustomerID FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
            Dim EmailCustomerCommand As New SqlCommand(EmailCustomerStatement, con)
            EmailCustomerCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomer = CStr(EmailCustomerCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomer = ""
            End Try
            con.Close()

            TFPMailCustomer = EmailCustomer
            LoadAddressBook()

            Dim EmailCustomerAddressStatement As String = "SELECT SalesContactEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailCustomerAddressCommand As New SqlCommand(EmailCustomerAddressStatement, con)
            EmailCustomerAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailCustomer
            EmailCustomerAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerAddress = CStr(EmailCustomerAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerAddress = ""
            End Try
            con.Close()

            txtEmailTo.Text = EmailCustomerAddress
        ElseIf TFPMailTransactionType = "Print Packing List" Then
            LoadAddressBook()

            'Load defaults
            txtEmailSubject.Text = "Trufit / Truweld Pack List # " + CStr(TFPMailTransactionNumber)
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress

            'Get Customer's Email Address
            Dim EmailCustomer, EmailCustomerAddress As String

            Dim EmailCustomerStatement As String = "SELECT CustomerID FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
            Dim EmailCustomerCommand As New SqlCommand(EmailCustomerStatement, con)
            EmailCustomerCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomer = CStr(EmailCustomerCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomer = ""
            End Try
            con.Close()

            TFPMailCustomer = EmailCustomer
            LoadAddressBook()

            Dim EmailCustomerAddressStatement As String = "SELECT PackingListEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailCustomerAddressCommand As New SqlCommand(EmailCustomerAddressStatement, con)
            EmailCustomerAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailCustomer
            EmailCustomerAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerAddress = CStr(EmailCustomerAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerAddress = ""
            End Try
            con.Close()

            txtEmailTo.Text = EmailCustomerAddress
        ElseIf TFPMailTransactionType = "Print Pick Ticket" Then
            LoadAddressBook()

            'Load defaults
            txtEmailSubject.Text = "Trufit / Truweld Pick Ticket # " + CStr(TFPMailTransactionNumber)
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress

            'Get Customer's Email Address
            Dim EmailCustomer, EmailCustomerAddress As String

            Dim EmailCustomerStatement As String = "SELECT CustomerID FROM PickListHeaderTable WHERE PickListHeaderKey = @PickListHeaderKey"
            Dim EmailCustomerCommand As New SqlCommand(EmailCustomerStatement, con)
            EmailCustomerCommand.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomer = CStr(EmailCustomerCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomer = ""
            End Try
            con.Close()

            TFPMailCustomer = EmailCustomer
            LoadAddressBook()

            Dim EmailCustomerAddressStatement As String = "SELECT PackingListEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailCustomerAddressCommand As New SqlCommand(EmailCustomerAddressStatement, con)
            EmailCustomerAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailCustomer
            EmailCustomerAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerAddress = CStr(EmailCustomerAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerAddress = ""
            End Try
            con.Close()

            txtEmailTo.Text = EmailCustomerAddress
        ElseIf TFPMailTransactionType = "Print Uploaded Pick Ticket" Then
            LoadAddressBook()

            'Load defaults
            txtEmailSubject.Text = "Trufit / Truweld Pick Ticket # " + CStr(TFPMailTransactionNumber)
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress

            'Get Customer's Email Address
            Dim EmailCustomer, EmailCustomerAddress As String

            Dim EmailCustomerStatement As String = "SELECT CustomerID FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
            Dim EmailCustomerCommand As New SqlCommand(EmailCustomerStatement, con)
            EmailCustomerCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomer = CStr(EmailCustomerCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomer = ""
            End Try
            con.Close()

            TFPMailCustomer = EmailCustomer
            LoadAddressBook()

            Dim EmailCustomerAddressStatement As String = "SELECT PackingListEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailCustomerAddressCommand As New SqlCommand(EmailCustomerAddressStatement, con)
            EmailCustomerAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailCustomer
            EmailCustomerAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerAddress = CStr(EmailCustomerAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerAddress = ""
            End Try
            con.Close()

            txtEmailTo.Text = EmailCustomerAddress
        ElseIf TFPMailTransactionType = "Print BOL" Then
            LoadAddressBook()

            'Load defaults
            txtEmailSubject.Text = "Trufit / Truweld BOL # " + CStr(TFPMailTransactionNumber)
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress

            'Get Customer's Email Address
            Dim EmailCustomer, EmailCustomerAddress As String

            Dim EmailCustomerStatement As String = "SELECT CustomerID FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
            Dim EmailCustomerCommand As New SqlCommand(EmailCustomerStatement, con)
            EmailCustomerCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomer = CStr(EmailCustomerCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomer = ""
            End Try
            con.Close()

            TFPMailCustomer = EmailCustomer
            LoadAddressBook()

            Dim EmailCustomerAddressStatement As String = "SELECT PackingListEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailCustomerAddressCommand As New SqlCommand(EmailCustomerAddressStatement, con)
            EmailCustomerAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailCustomer
            EmailCustomerAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerAddress = CStr(EmailCustomerAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerAddress = ""
            End Try
            con.Close()

            txtEmailTo.Text = EmailCustomerAddress
        ElseIf TFPMailTransactionType = "Print Purchase Order" Then
            LoadAddressBook()

            'Load defaults
            txtEmailSubject.Text = "Trufit / Truweld PO # " + CStr(TFPMailTransactionNumber)
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress

            'Get Vendor's Email Address
            Dim EmailVendor, EmailVendorAddress As String

            Dim EmailVendorStatement As String = "SELECT VendorID FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
            Dim EmailVendorCommand As New SqlCommand(EmailVendorStatement, con)
            EmailVendorCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailVendor = CStr(EmailVendorCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailVendor = ""
            End Try
            con.Close()

            Dim EmailVendorAddressStatement As String = "SELECT VendorEmail FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim EmailVendorAddressCommand As New SqlCommand(EmailVendorAddressStatement, con)
            EmailVendorAddressCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = EmailVendor
            EmailVendorAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailVendorAddress = CStr(EmailVendorAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailVendorAddress = ""
            End Try
            con.Close()

            txtEmailTo.Text = EmailVendorAddress
        ElseIf TFPMailTransactionType = "Print Invoice Batch" Then
            LoadAddressBook()

            'Load defaults
            txtEmailSubject.Text = "Trufit / Truweld Invoice Batch # " + CStr(TFPMailTransactionNumber)
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
        ElseIf TFPMailTransactionType = "Reprint Invoice Batch" Then
            LoadAddressBook()

            'Load defaults
            txtEmailSubject.Text = "Trufit / Truweld Invoice Batch # " + CStr(TFPMailTransactionNumber)
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
        ElseIf TFPMailTransactionType = "Print Invoice" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Invoice # " + CStr(TFPMailTransactionNumber)
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress

            'Create Customer Note

            'Get Next Note Number
            Dim MaximumNoteString As String = "SELECT MAX(NoteID) as MAXNoteID FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
            MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailInvoiceCustomer
            MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = MaximumNoteCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("MAXNoteID")) Then
                    LastNoteNumber = 0
                Else
                    LastNoteNumber = reader.Item("MAXNoteID")
                End If
            Else
                LastNoteNumber = 0
            End If
            reader.Close()
            con.Close()

            NextNoteNumber = LastNoteNumber + 1

            Dim MessageBodyText As String = ""

            MessageBodyText = EmployeeLoginName + " emailed this Invoice - #" + EmailStringInvoiceNumber + " to " + EmailCustomerEmailAddress

            'Write Data to Customer Note Table
            cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

            With cmd.Parameters
                .Add("@CustomerID", SqlDbType.VarChar).Value = EmailInvoiceCustomer
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                .Add("@NoteDate", SqlDbType.VarChar).Value = Today()
                .Add("@NoteSubject", SqlDbType.VarChar).Value = "Email Invoices"
                .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
                .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Write Data to Customer Note Table
            cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET EmailSent = @EmailSent WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = EmailInvoiceNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                .Add("@EmailSent", SqlDbType.VarChar).Value = "Email sent - " + strDate
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            txtEmailTo.Text = EmailCustomerEmailAddress
        ElseIf TFPMailTransactionType = "Print Customer Statement" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Customer Statement " + TFPMailCustomer
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress

            'Create Customer Note

            'Get Next Note Number
            Dim MaximumNoteString As String = "SELECT MAX(NoteID) as MAXNoteID FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
            MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailInvoiceCustomer
            MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = MaximumNoteCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("MAXNoteID")) Then
                    LastNoteNumber = 0
                Else
                    LastNoteNumber = reader.Item("MAXNoteID")
                End If
            Else
                LastNoteNumber = 0
            End If
            reader.Close()
            con.Close()

            NextNoteNumber = LastNoteNumber + 1

            Dim MessageBodyText As String = ""

            MessageBodyText = EmployeeLoginName + " emailed a Customer Statement to this customer " + EmailInvoiceCustomer + " to " + EmailCustomerEmailAddress

            'Write Data to Customer Note Table
            cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

            With cmd.Parameters
                .Add("@CustomerID", SqlDbType.VarChar).Value = EmailInvoiceCustomer
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                .Add("@NoteDate", SqlDbType.VarChar).Value = Today()
                .Add("@NoteSubject", SqlDbType.VarChar).Value = "Email Customer Statement"
                .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
                .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            txtEmailTo.Text = EmailCustomerEmailAddress
        ElseIf TFPMailTransactionType = "Print Backorder Report" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Backorder Report "
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""
        ElseIf TFPMailTransactionType = "Print Cert" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Cert"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""
        ElseIf TFPMailTransactionType = "Print Shipment Confirmation" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Shipment Confirmation"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""

            'Get Customer's Email Address
            Dim EmailCustomer, EmailCustomerAddress As String

            Dim EmailCustomerStatement As String = "SELECT CustomerID FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
            Dim EmailCustomerCommand As New SqlCommand(EmailCustomerStatement, con)
            EmailCustomerCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomer = CStr(EmailCustomerCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomer = ""
            End Try
            con.Close()

            TFPMailCustomer = EmailCustomer
            LoadAddressBook()

            Dim EmailCustomerAddressStatement As String = "SELECT ConfirmationEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailCustomerAddressCommand As New SqlCommand(EmailCustomerAddressStatement, con)
            EmailCustomerAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailCustomer
            EmailCustomerAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerAddress = CStr(EmailCustomerAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerAddress = ""
            End Try
            con.Close()

            txtEmailTo.Text = EmailCustomerAddress
        ElseIf TFPMailTransactionType = "Print Customer Return" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Customer Return"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""
        ElseIf TFPMailTransactionType = "Print Drop Ship Packing List" Then
            LoadAddressBook()

            'Get Vendor Email from PO Number
            Dim GetVendor As String = ""
            Dim GetVendorEmail As String = ""

            Dim GetVendorStatement As String = "SELECT VendorID FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
            Dim GetVendorCommand As New SqlCommand(GetVendorStatement, con)
            GetVendorCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalDropShipPONumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetVendor = CStr(GetVendorCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetVendor = ""
            End Try
            con.Close()

            Dim GetVendorEmailStatement As String = "SELECT VendorEmail FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim GetVendorEmailCommand As New SqlCommand(GetVendorEmailStatement, con)
            GetVendorEmailCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GetVendor
            GetVendorEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetVendorEmail = CStr(GetVendorEmailCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetVendorEmail = ""
            End Try
            con.Close()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Packing List"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""
        ElseIf TFPMailTransactionType = "Print Drop Ship PO" Then
            LoadAddressBook()

            'Get Vendor Email from PO Number
            Dim GetVendor As String = ""
            Dim GetVendorEmail As String = ""

            Dim GetVendorStatement As String = "SELECT VendorID FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
            Dim GetVendorCommand As New SqlCommand(GetVendorStatement, con)
            GetVendorCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalDropShipPONumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetVendor = CStr(GetVendorCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetVendor = ""
            End Try
            con.Close()

            Dim GetVendorEmailStatement As String = "SELECT VendorEmail FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim GetVendorEmailCommand As New SqlCommand(GetVendorEmailStatement, con)
            GetVendorEmailCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GetVendor
            GetVendorEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetVendorEmail = CStr(GetVendorEmailCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetVendorEmail = ""
            End Try
            con.Close()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Packing List" + "  (" + TFPMailFilename2 + ")"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename + "," + TFPMailFilename2

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            txtEmailTo.Text = GetVendorEmail
            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
        ElseIf TFPMailTransactionType = "Print Packing List From SO" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Packing List"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""

            'Get Customer's Email Address
            Dim EmailCustomer, EmailCustomerAddress As String

            Dim EmailCustomerStatement As String = "SELECT CustomerID FROM ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber"
            Dim EmailCustomerCommand As New SqlCommand(EmailCustomerStatement, con)
            EmailCustomerCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomer = CStr(EmailCustomerCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomer = ""
            End Try
            con.Close()

            TFPMailCustomer = EmailCustomer
            LoadAddressBook()

            Dim EmailCustomerAddressStatement As String = "SELECT ConfirmationEmail FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailCustomerAddressCommand As New SqlCommand(EmailCustomerAddressStatement, con)
            EmailCustomerAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailCustomer
            EmailCustomerAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerAddress = CStr(EmailCustomerAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerAddress = ""
            End Try
            con.Close()

            txtEmailTo.Text = EmailCustomerAddress
        ElseIf TFPMailTransactionType = "Print Pick Ticket From SO" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Pick Ticket"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twdtfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""
        ElseIf TFPMailTransactionType = "Print Studwelding Cert" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Studwelding Certification"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""
        ElseIf TFPMailTransactionType = "Print Invoice From SO" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Invoice"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""

            'Get Customer's Email Address
            Dim EmailCustomer, EmailCustomerAddress As String

            Dim EmailCustomerStatement As String = "SELECT CustomerID FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey"
            Dim EmailCustomerCommand As New SqlCommand(EmailCustomerStatement, con)
            EmailCustomerCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = TFPMailTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomer = CStr(EmailCustomerCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomer = ""
            End Try
            con.Close()

            TFPMailCustomer = EmailCustomer
            LoadAddressBook()

            Dim EmailCustomerAddressStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailCustomerAddressCommand As New SqlCommand(EmailCustomerAddressStatement, con)
            EmailCustomerAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailCustomer
            EmailCustomerAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerAddress = CStr(EmailCustomerAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerAddress = ""
            End Try
            con.Close()

            txtEmailTo.Text = EmailCustomerAddress
        ElseIf TFPMailTransactionType = "Print Invoice Single" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Invoice"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""

            'Create Customer Note
            strInvoiceNumber = CStr(TFPMailTransactionNumber)

            'Get Next Note Number
            Dim MaximumNoteString As String = "SELECT MAX(NoteID) as MAXNoteID FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
            MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailInvoiceCustomer
            MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = MaximumNoteCommand.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.Item("MAXNoteID")) Then
                    LastNoteNumber = 0
                Else
                    LastNoteNumber = reader.Item("MAXNoteID")
                End If
            Else
                LastNoteNumber = 0
            End If
            reader.Close()
            con.Close()

            NextNoteNumber = LastNoteNumber + 1

            Dim MessageBodyText As String = ""

            MessageBodyText = EmployeeLoginName + " emailed this Invoice - #" + strInvoiceNumber + " to " + EmailCustomerEmailAddress

            'Write Data to Customer Note Table
            cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

            With cmd.Parameters
                .Add("@CustomerID", SqlDbType.VarChar).Value = TFPMailCustomer
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                .Add("@NoteDate", SqlDbType.VarChar).Value = Today()
                .Add("@NoteSubject", SqlDbType.VarChar).Value = "Email Invoices"
                .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
                .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Write Data to Customer Note Table
            cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET EmailSent = @EmailSent WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalInvoiceNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                .Add("@EmailSent", SqlDbType.VarChar).Value = "Email sent - " + strDate
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            txtEmailTo.Text = EmailCustomerEmailAddress
        ElseIf TFPMailTransactionType = "Print Cert From Lot" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Invoice"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""
        ElseIf TFPMailTransactionType = "***********************" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Trufit / Truweld Invoice"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""
        ElseIf TFPMailTransactionType = "Email All Invoice Docs" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            Dim EmailCustomerAddress As String = ""
            LoadEmailSignature()
            txtEmailSubject.Text = "Trufit / Truweld Invoice and Certs"

            If TFPMailFilename = "" Then
                lblEmailAttachments.Text = TFPMailFilename2
            Else
                lblEmailAttachments.Text = TFPMailFilename2 + ", " + TFPMailFilename
            End If

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            LoadAddressBook()

            Dim EmailCustomerAddressStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim EmailCustomerAddressCommand As New SqlCommand(EmailCustomerAddressStatement, con)
            EmailCustomerAddressCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = TFPMailCustomer
            EmailCustomerAddressCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                EmailCustomerAddress = CStr(EmailCustomerAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                EmailCustomerAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = EmailCustomerAddress
        ElseIf TFPMailTransactionType = "Email All Shipping Docs" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            LoadEmailSignature()
            txtEmailSubject.Text = "Packing list, BOL, and Certs for shipment # " + TFPMailTransactionNumber

            If TFPMailFilename = "" And TFPMailFilename2 = "" And TFPMailFilename3 = "" Then
                lblEmailAttachments.Text = ""
            ElseIf TFPMailFilename <> "" And TFPMailFilename2 = "" And TFPMailFilename3 = "" Then
                lblEmailAttachments.Text = TFPMailFilename
            ElseIf TFPMailFilename <> "" And TFPMailFilename2 <> "" And TFPMailFilename3 = "" Then
                lblEmailAttachments.Text = TFPMailFilename + ", " + TFPMailFilename2
            ElseIf TFPMailFilename <> "" And TFPMailFilename2 <> "" And TFPMailFilename3 <> "" Then
                lblEmailAttachments.Text = TFPMailFilename + ", " + TFPMailFilename2 + ", " + TFPMailFilename3
            ElseIf TFPMailFilename <> "" And TFPMailFilename2 = "" And TFPMailFilename3 <> "" Then
                lblEmailAttachments.Text = TFPMailFilename + ", " + TFPMailFilename3
            ElseIf TFPMailFilename = "" And TFPMailFilename2 <> "" And TFPMailFilename3 <> "" Then
                lblEmailAttachments.Text = TFPMailFilename2 + ", " + TFPMailFilename3
            Else
                lblEmailAttachments.Text = TFPMailFilename
            End If

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""
        ElseIf TFPMailTransactionType = "EMPTY" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Clear()
            txtEmailBcc.Clear()
            txtEmailBody.Clear()
            txtEmailTo.Clear()
            txtEmailCc.Clear()

            lblEmailAttachments.Text = ""
            LoadEmailSignature()
            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
        ElseIf TFPMailTransactionType = "OPEN NEW" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Clear()
            txtEmailBcc.Clear()
            txtEmailBody.Clear()
            txtEmailTo.Clear()
            txtEmailCc.Clear()

            lblEmailAttachments.Text = ""
            LoadEmailSignature()
            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
        ElseIf TFPMailTransactionType = "Print A/R Payment Batch" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Clear()
            txtEmailBcc.Clear()
            txtEmailBody.Clear()
            txtEmailTo.Clear()
            txtEmailCc.Clear()

            lblEmailAttachments.Text = TFPMailFilename
            txtEmailSubject.Text = "A/R Cash Payment Batch"
            LoadEmailSignature()

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
        ElseIf TFPMailTransactionType = "Print Inventory Report" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Clear()
            txtEmailBcc.Clear()
            txtEmailBody.Clear()
            txtEmailTo.Clear()
            txtEmailCc.Clear()

            lblEmailAttachments.Text = TFPMailFilename
            txtEmailSubject.Text = "TWD Inventory Report"
            LoadEmailSignature()

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
        ElseIf TFPMailTransactionType = "Print Shipment Status Report" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Clear()
            txtEmailBcc.Clear()
            txtEmailBody.Clear()
            txtEmailTo.Clear()
            txtEmailCc.Clear()

            lblEmailAttachments.Text = TFPMailFilename
            txtEmailSubject.Text = "TWD Inventory Report"
            LoadEmailSignature()

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress

        ElseIf TFPMailTransactionType = "Email Structural Certification" Then
            LoadAddressBook()

            Dim strDate As String = ""
            strDate = CStr(Today.ToShortDateString)

            txtEmailSubject.Text = "Structural Cert"
            LoadEmailSignature()
            lblEmailAttachments.Text = TFPMailFilename

            Dim GetCopyAddress As String = ""

            Dim GetCopyAddressStatement As String = "SELECT EmailAddress FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetCopyAddressCommand As New SqlCommand(GetCopyAddressStatement, con)
            GetCopyAddressCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetCopyAddress = CStr(GetCopyAddressCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetCopyAddress = ""
            End Try
            con.Close()

            lblEmailCopyTo.Text = GetCopyAddress
            lblEmailSentFrom.Text = "twd@tfpcorp.com"
            TFPMailReplyAddress = GetCopyAddress
            txtEmailTo.Text = ""
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cmdSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendEmail.Click
        'Validate Email Fields
        If TFPMailTransactionType = "" Then
            MsgBox("Email failed - contact Admin.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '**************************************************************************************************
        'Validate email (Remove enter, tab, commas, and extra spaces from email line.)
        Dim CheckAddressString As String = ""

        CheckAddressString = txtEmailTo.Text

        'Validation for carriage return
        If CheckAddressString.Contains(vbCr) Then
            CheckAddressString = CheckAddressString.Replace(vbCr, "")
        End If
        'Validation for carriage returm / line feed (ENTER)
        If CheckAddressString.Contains(vbCrLf) Then
            CheckAddressString = CheckAddressString.Replace(vbCrLf, "")
        End If
        'Validation for line feed
        If CheckAddressString.Contains(vbLf) Then
            CheckAddressString = CheckAddressString.Replace(vbLf, "")
        End If
        'Validation for commas
        If CheckAddressString.Contains(",") Then
            CheckAddressString = CheckAddressString.Replace(",", ";")
        End If
        'Validation for colons
        If CheckAddressString.Contains(":") Then
            CheckAddressString = CheckAddressString.Replace(":", ";")
        End If
        'Validation for spaces
        If CheckAddressString.Contains("  ") Then
            CheckAddressString = CheckAddressString.Replace("  ", " ")
        End If

        txtEmailTo.Text = CheckAddressString
        '**************************************************************************************************
        'Check if attached file is in use by another process.
        'Dim TempFileCopy1 As String = ""
        'Dim TempFileCopy2 As String = ""
        'Dim TempFileCopy3 As String = ""

        Dim TestMessageFileNameAndPath As String = ""
        Dim TestMessageFileNameAndPath2 As String = ""
        Dim TestMessageFileNameAndPath3 As String = ""
        '***************************************************************************************************
        ''Create new temp files
        'If TFPMailFilePath <> "" Then
        '    TempFileCopy1 = "\\TFP-FS\TransferData\Temp Folder\TempFile1.pdf"
        '    If File.Exists(TempFileCopy1) Then
        '        System.IO.File.Delete(TempFileCopy1)
        '    End If
        'End If
        'If File.Exists(TFPMailFilePath) Then
        '    System.IO.File.Copy(TFPMailFilePath, TempFileCopy1)
        'End If

        'If TFPMailFilePath2 <> "" Then
        '    TempFileCopy2 = "\\TFP-FS\TransferData\Temp Folder\TempFile2.pdf"
        '    If File.Exists(TempFileCopy2) Then
        '        System.IO.File.Delete(TempFileCopy2)
        '    End If
        'End If
        'If File.Exists(TFPMailFilePath2) Then
        '    System.IO.File.Copy(TFPMailFilePath2, TempFileCopy2)
        'End If

        'If TFPMailFilePath3 <> "" Then
        '    TempFileCopy3 = "\\TFP-FS\TransferData\Temp Folder\TempFile3.pdf"
        '    If File.Exists(TempFileCopy3) Then
        '        System.IO.File.Delete(TempFileCopy3)
        '    End If
        'End If
        'If File.Exists(TFPMailFilePath3) Then
        '    System.IO.File.Copy(TFPMailFilePath3, TempFileCopy3)
        'End If

        TestMessageFileNameAndPath = TFPMailFilePath
        TestMessageFileNameAndPath2 = TFPMailFilePath2
        TestMessageFileNameAndPath3 = TFPMailFilePath3
        '**************************************************************************************************
        Try
            '**********************************************************************************************
            'Variables to be used in all three routines (TO:, CC, BCC)
            Dim TestEmail As String = txtEmailTo.Text
            Dim TestBody As String = ""
            Dim TestSubject As String = ""
            Dim TestSignatureAndBody As String = ""

            'Add TO: Line meail address and add to address book

            If txtEmailTo.Text <> "" Then
                'Variables for TO: Line Email Addresses
                Dim ToEmailLine As String = ""
                Dim LineCounter As Integer = 1

                ToEmailLine = txtEmailTo.Text

                If ToEmailLine.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(ToEmailLine, ";")
                    ArrayCount = UBound(EmailArray) + 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - LineCounter)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            MsgBox("Illegal character in one of the email addresses.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        Else
                            'Check if it exists
                            Dim CountAddresses As Integer = 0

                            Dim CountAddressesStatement As String = "SELECT COUNT (EmailAddress) FROM TFPMailAddressBook WHERE DivisionID = @DivisionID AND EmailAddress = @EmailAddress"
                            Dim CountAddressesCommand As New SqlCommand(CountAddressesStatement, con)
                            CountAddressesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                            CountAddressesCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                CountAddresses = CInt(CountAddressesCommand.ExecuteScalar)
                            Catch ex As System.Exception
                                CountAddresses = 0
                            End Try
                            con.Close()

                            If CountAddresses = 0 Then
                                Try
                                    cmd = New SqlCommand("Insert Into TFPMailAddressBook(CustomerID, DivisionID, UserID, EmailAddress) Values (@CustomerID, @DivisionID, @UserID, @EmailAddress)", con)

                                    With cmd.Parameters
                                        .Add("@CustomerID", SqlDbType.VarChar).Value = TFPMailCustomer
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                        .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Skip
                                End Try
                            Else
                                'Skip Address Book
                            End If

                            'Add Email addresses
                            MyMailMessage.To.Add(CurrentEmail)
                        End If

                        LineCounter = LineCounter + 1
                    Next
                Else
                    'Check if it exists
                    Dim CountAddresses As Integer = 0

                    Dim CountAddressesStatement As String = "SELECT COUNT (EmailAddress) FROM TFPMailAddressBook WHERE DivisionID = @DivisionID AND EmailAddress = @EmailAddress"
                    Dim CountAddressesCommand As New SqlCommand(CountAddressesStatement, con)
                    CountAddressesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    CountAddressesCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = ToEmailLine

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CountAddresses = CInt(CountAddressesCommand.ExecuteScalar)
                    Catch ex As System.Exception
                        CountAddresses = 0
                    End Try
                    con.Close()

                    If CountAddresses = 0 Then
                        Try
                            cmd = New SqlCommand("Insert Into TFPMailAddressBook(CustomerID, DivisionID, UserID, EmailAddress) Values (@CustomerID, @DivisionID, @UserID, @EmailAddress)", con)

                            With cmd.Parameters
                                .Add("@CustomerID", SqlDbType.VarChar).Value = TFPMailCustomer
                                .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@EmailAddress", SqlDbType.VarChar).Value = ToEmailLine
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Skip
                        End Try
                    Else
                        'Skip Address Book
                    End If

                    MyMailMessage.To.Add(ToEmailLine)
                End If

                '**********************************************************************************************
                'Add CC: Line meail address and add to address book

                If txtEmailCc.Text <> "" Then
                    'Variables for CC: Line Email Addresses
                    Dim CCEmailLine As String = ""
                    Dim LineCounter2 As Integer = 1

                    CCEmailLine = txtEmailCc.Text

                    If CCEmailLine.Contains(";") Then
                        Dim EmailArray As Array
                        Dim ArrayCount As Integer = 0
                        Dim CurrentEmail As String = ""

                        EmailArray = Split(CCEmailLine, ";")
                        ArrayCount = UBound(EmailArray) + 1

                        For i As Integer = 0 To UBound(EmailArray)
                            CurrentEmail = EmailArray(ArrayCount - LineCounter2)

                            If CurrentEmail.Contains(" ") Then
                                CurrentEmail = CurrentEmail.Replace(" ", "")
                            End If

                            If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                                MsgBox("Illegal character in one of the email addresses.", MsgBoxStyle.OkOnly)
                                Exit Sub
                            Else
                                'Check if it exists
                                Dim CountAddresses As Integer = 0

                                Dim CountAddressesStatement As String = "SELECT COUNT (EmailAddress) FROM TFPMailAddressBook WHERE DivisionID = @DivisionID AND EmailAddress = @EmailAddress"
                                Dim CountAddressesCommand As New SqlCommand(CountAddressesStatement, con)
                                CountAddressesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                                CountAddressesCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    CountAddresses = CInt(CountAddressesCommand.ExecuteScalar)
                                Catch ex As System.Exception
                                    CountAddresses = 0
                                End Try
                                con.Close()

                                If CountAddresses = 0 Then
                                    Try
                                        cmd = New SqlCommand("Insert Into TFPMailAddressBook(CustomerID, DivisionID, UserID, EmailAddress) Values (@CustomerID, @DivisionID, @UserID, @EmailAddress)", con)

                                        With cmd.Parameters
                                            .Add("@CustomerID", SqlDbType.VarChar).Value = TFPMailCustomer
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Skip
                                    End Try
                                Else
                                    'Skip Address Book
                                End If

                                'Add Email addresses
                                MyMailMessage.CC.Add(CurrentEmail)
                            End If

                            LineCounter2 = LineCounter2 + 1
                        Next
                    Else
                        'Check if it exists
                        Dim CountAddresses As Integer = 0

                        Dim CountAddressesStatement As String = "SELECT COUNT (EmailAddress) FROM TFPMailAddressBook WHERE DivisionID = @DivisionID AND EmailAddress = @EmailAddress"
                        Dim CountAddressesCommand As New SqlCommand(CountAddressesStatement, con)
                        CountAddressesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        CountAddressesCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = CCEmailLine

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountAddresses = CInt(CountAddressesCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            CountAddresses = 0
                        End Try
                        con.Close()

                        If CountAddresses = 0 Then
                            Try
                                cmd = New SqlCommand("Insert Into TFPMailAddressBook(CustomerID, DivisionID, UserID, EmailAddress) Values (@CustomerID, @DivisionID, @UserID, @EmailAddress)", con)

                                With cmd.Parameters
                                    .Add("@CustomerID", SqlDbType.VarChar).Value = TFPMailCustomer
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                    .Add("@EmailAddress", SqlDbType.VarChar).Value = CCEmailLine
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Skip
                            End Try
                        Else
                            'Skip Address Book
                        End If

                        MyMailMessage.CC.Add(CCEmailLine)
                    End If
                End If
                '**********************************************************************************************
                'Add CC: Line meail address and add to address book

                If txtEmailBcc.Text <> "" Then
                    'Variables for BCC: Line Email Addresses
                    Dim BCCEmailLine As String = ""
                    Dim LineCounter3 As Integer = 1

                    BCCEmailLine = txtEmailBcc.Text

                    If BCCEmailLine.Contains(";") Then
                        Dim EmailArray As Array
                        Dim ArrayCount As Integer = 0
                        Dim CurrentEmail As String = ""

                        EmailArray = Split(BCCEmailLine, ";")
                        ArrayCount = UBound(EmailArray) + 1

                        For i As Integer = 0 To UBound(EmailArray)
                            CurrentEmail = EmailArray(ArrayCount - LineCounter3)

                            If CurrentEmail.Contains(" ") Then
                                CurrentEmail = CurrentEmail.Replace(" ", "")
                            End If

                            If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                                MsgBox("Illegal character in one of the email addresses.", MsgBoxStyle.OkOnly)
                                Exit Sub
                            Else
                                'Check if it exists
                                Dim CountAddresses As Integer = 0

                                Dim CountAddressesStatement As String = "SELECT COUNT (EmailAddress) FROM TFPMailAddressBook WHERE DivisionID = @DivisionID AND EmailAddress = @EmailAddress"
                                Dim CountAddressesCommand As New SqlCommand(CountAddressesStatement, con)
                                CountAddressesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                                CountAddressesCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    CountAddresses = CInt(CountAddressesCommand.ExecuteScalar)
                                Catch ex As System.Exception
                                    CountAddresses = 0
                                End Try
                                con.Close()

                                If CountAddresses = 0 Then
                                    Try
                                        cmd = New SqlCommand("Insert Into TFPMailAddressBook(CustomerID, DivisionID, UserID, EmailAddress) Values (@CustomerID, @DivisionID, @UserID, @EmailAddress)", con)

                                        With cmd.Parameters
                                            .Add("@CustomerID", SqlDbType.VarChar).Value = TFPMailCustomer
                                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                                        End With

                                        If con.State = ConnectionState.Closed Then con.Open()
                                        cmd.ExecuteNonQuery()
                                        con.Close()
                                    Catch ex As Exception
                                        'Skip
                                    End Try
                                Else
                                    'Skip Address Book
                                End If

                                'Add Email addresses
                                MyMailMessage.Bcc.Add(CurrentEmail)
                            End If

                            LineCounter3 = LineCounter3 + 1
                        Next
                    Else
                        'Check if it exists
                        Dim CountAddresses As Integer = 0

                        Dim CountAddressesStatement As String = "SELECT COUNT (EmailAddress) FROM TFPMailAddressBook WHERE DivisionID = @DivisionID AND EmailAddress = @EmailAddress"
                        Dim CountAddressesCommand As New SqlCommand(CountAddressesStatement, con)
                        CountAddressesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        CountAddressesCommand.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = BCCEmailLine

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            CountAddresses = CInt(CountAddressesCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            CountAddresses = 0
                        End Try
                        con.Close()

                        If CountAddresses = 0 Then
                            Try
                                cmd = New SqlCommand("Insert Into TFPMailAddressBook(CustomerID, DivisionID, UserID, EmailAddress) Values (@CustomerID, @DivisionID, @UserID, @EmailAddress)", con)

                                With cmd.Parameters
                                    .Add("@CustomerID", SqlDbType.VarChar).Value = TFPMailCustomer
                                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                    .Add("@EmailAddress", SqlDbType.VarChar).Value = BCCEmailLine
                                End With

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                'Skip
                            End Try
                        Else
                            'Skip Address Book
                        End If

                        MyMailMessage.Bcc.Add(BCCEmailLine)
                    End If
                End If
                '**************************************************************************************************************************************
                'Fill remaining Variables and send email
                TestBody = txtEmailBody.Text + Environment.NewLine + Environment.NewLine + "***** PLEASE DO NOT REPLY TO THIS EMAIL ADDRESS (TWD@TFPCORP.COM) - IT IS NOT MONITORED REGULARLY *****"
                TestSubject = txtEmailSubject.Text

                If TestEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                    MsgBox("One or more bad characters in the email address line.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    MyMailMessage.From = New MailAddress("twd@tfpcorp.com")
                    MyMailMessage.Bcc.Add(TFPMailReplyAddress)
                    MyMailMessage.Subject = TestSubject
                    MyMailMessage.ReplyTo = New MailAddress(TFPMailReplyAddress)
                    MyMailMessage.Body = TestBody

                    Try
                        If TestMessageFileNameAndPath = "" Then
                            'No attached file
                        Else
                            MyMailMessage.Attachments.Add(New Attachment(TestMessageFileNameAndPath))
                        End If
                        If TestMessageFileNameAndPath2 = "" Then
                            'No attached file
                        Else
                            MyMailMessage.Attachments.Add(New Attachment(TestMessageFileNameAndPath2))
                        End If
                        If TestMessageFileNameAndPath3 = "" Then
                            'No attached file
                        Else
                            MyMailMessage.Attachments.Add(New Attachment(TestMessageFileNameAndPath3))
                        End If
                    Catch ex As Exception
                        MsgBox("The file you are trying to attach is in use by another process. Close the print form and try again.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End Try

                    Dim TestSMPT As New SmtpClient("Mail.tfpcorp.com")
                    TestSMPT.Port = 587
                    'SMPT.Timeout = 1500
                    TestSMPT.EnableSsl = False
                    TestSMPT.Credentials = New System.Net.NetworkCredential("twd@tfpcorp.com", "1422325bogie")
                    TestSMPT.Send(MyMailMessage)

                    MsgBox("Email has been sent.", MsgBoxStyle.OkOnly)

                    ClearGlobalVariables()

                    Me.Dispose()
                    Me.Close()
                End If
            Else
                'Clear Variables
                ClearGlobalVariables()

                MsgBox("The TO Line cannot be blank.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("There is a problem with this email. Close this window and try again.", MsgBoxStyle.OkOnly)
            ClearGlobalVariables()
            Exit Sub
        End Try
    End Sub

    Private Sub cmdAddTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddTo.Click
        Dim TempSelected As String = ""
        Dim CurrentToAddress As String = txtEmailTo.Text
        listCCAddressBook.Visible = False
        listBCCAddressBook.Visible = False



        If listToAddressBook.Visible = True Then
            listToAddressBook.Visible = False

            TempSelected = listToAddressBook.Text

            If CurrentToAddress = "" Then
                txtEmailTo.Text = TempSelected
            Else
                txtEmailTo.Text = CurrentToAddress + "; " + TempSelected
            End If
        Else
            listToAddressBook.Visible = True
        End If
    End Sub

    Private Sub cmdAddCc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddCc.Click
        Dim TempSelected As String = ""
        Dim CurrentCCAddress As String = txtEmailCc.Text
        listBCCAddressBook.Visible = False
        listToAddressBook.Visible = False

        If listCCAddressBook.Visible = True Then
            listCCAddressBook.Visible = False

            TempSelected = listCCAddressBook.Text

            If CurrentCCAddress = "" Then
                txtEmailCc.Text = TempSelected
            Else
                txtEmailCc.Text = CurrentCCAddress + "; " + TempSelected
            End If
        Else
            listCCAddressBook.Visible = True
        End If
    End Sub

    Private Sub cmdAddBcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddBcc.Click
        Dim TempSelected As String = ""
        Dim CurrentBCCAddress As String = txtEmailBcc.Text
        listToAddressBook.Visible = False
        listCCAddressBook.Visible = False

        If listBCCAddressBook.Visible = True Then
            listBCCAddressBook.Visible = False

            TempSelected = listBCCAddressBook.Text

            If CurrentBCCAddress = "" Then
                txtEmailBcc.Text = TempSelected
            Else
                txtEmailBcc.Text = CurrentBCCAddress + "; " + TempSelected
            End If
        Else
            listBCCAddressBook.Visible = True
        End If
    End Sub

    Private Sub cmdAddAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddAttachment.Click
        'Open File Dialog Box
        If ofdAddAttachments.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        AdditionalFileNameAndPath = ofdAddAttachments.FileName

        If AdditionalFileNameAndPath = "" Then
            Exit Sub
        End If

        If AdditionalFileNameAndPath = "" Then
            'No attached file
        Else
            MyMailMessage.Attachments.Add(New Attachment(AdditionalFileNameAndPath))
        End If

        'Get Filename ONLY from Filename and Path
        Dim OverallLength As Integer = 0
        Dim CurrentCharacter As String = ""
        Dim Counter As Integer = 0
        Dim SlashCount As Integer = 0

        OverallLength = AdditionalFileNameAndPath.Length - 1

        For i As Integer = 1 To OverallLength
            CurrentCharacter = AdditionalFileNameAndPath.Substring(OverallLength - Counter, 1)

            If CurrentCharacter = "\" Then
                SlashCount = OverallLength - Counter
                Exit For
            Else
                'Continue
            End If

            Counter = Counter + 1
        Next

        AdditionalFileName = AdditionalFileNameAndPath.Substring(SlashCount + 1, OverallLength - SlashCount)

        If lblEmailAttachments.Text = "" Then
            lblEmailAttachments.Text = AdditionalFileName
        Else
            lblEmailAttachments.Text = lblEmailAttachments.Text + ", " + AdditionalFileName
        End If
    End Sub

    Private Sub cmdClearAllFields_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAllFields.Click
        ClearAllFields()
        TFPMailTransactionType = "EMPTY"

        'Cllear Email
        MyMailMessage = New MailMessage()
    End Sub

    Private Sub cmdAddShipmentDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddShipmentDoc.Click
        'Set Path For Shipping Doc (Shipment Number)
        AdditionalFileNameAndPath = "\\TFP-FS\TransferData\UploadedPickTickets\" + txtShipmentNumber.Text + ".pdf"

        If AdditionalFileNameAndPath = "" Then
            'No attached file
            Exit Sub
        Else
            If File.Exists(AdditionalFileNameAndPath) Then
                MyMailMessage.Attachments.Add(New Attachment(AdditionalFileNameAndPath))
            Else
                MsgBox("File not found.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If

        'Get Filename ONLY from Filename and Path
        Dim OverallLength As Integer = 0
        Dim CurrentCharacter As String = ""
        Dim Counter As Integer = 0
        Dim SlashCount As Integer = 0

        OverallLength = AdditionalFileNameAndPath.Length - 1

        For i As Integer = 1 To OverallLength
            CurrentCharacter = AdditionalFileNameAndPath.Substring(OverallLength - Counter, 1)

            If CurrentCharacter = "\" Then
                SlashCount = OverallLength - Counter
                Exit For
            Else
                'Continue
            End If

            Counter = Counter + 1
        Next

        AdditionalFileName = AdditionalFileNameAndPath.Substring(SlashCount + 1, OverallLength - SlashCount)

        If lblEmailAttachments.Text = "" Then
            lblEmailAttachments.Text = AdditionalFileName
        Else
            lblEmailAttachments.Text = lblEmailAttachments.Text + ", " + AdditionalFileName
        End If

        txtShipmentNumber.Clear()
    End Sub

    Private Sub cmdAddReceiverDocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddReceiverDocs.Click
        'Set Path For Receiving Doc (Receiver Number)
        AdditionalFileNameAndPath = "\\TFP-FS\TransferData\UploadedPackingSlips\" + txtReceiverNumber.Text + ".pdf"

        If AdditionalFileNameAndPath = "" Then
            'No attached file
            Exit Sub
        Else
            If File.Exists(AdditionalFileNameAndPath) Then
                MyMailMessage.Attachments.Add(New Attachment(AdditionalFileNameAndPath))
            Else
                MsgBox("File not found.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If

        'Get Filename ONLY from Filename and Path
        Dim OverallLength As Integer = 0
        Dim CurrentCharacter As String = ""
        Dim Counter As Integer = 0
        Dim SlashCount As Integer = 0

        OverallLength = AdditionalFileNameAndPath.Length - 1

        For i As Integer = 1 To OverallLength
            CurrentCharacter = AdditionalFileNameAndPath.Substring(OverallLength - Counter, 1)

            If CurrentCharacter = "\" Then
                SlashCount = OverallLength - Counter
                Exit For
            Else
                'Continue
            End If

            Counter = Counter + 1
        Next

        AdditionalFileName = AdditionalFileNameAndPath.Substring(SlashCount + 1, OverallLength - SlashCount)

        If lblEmailAttachments.Text = "" Then
            lblEmailAttachments.Text = AdditionalFileName
        Else
            lblEmailAttachments.Text = lblEmailAttachments.Text + ", " + AdditionalFileName
        End If

        txtReceiverNumber.Clear()
    End Sub

End Class