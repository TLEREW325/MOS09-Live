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
Public Class CustomerAnnouncements
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


    'Configure Data Connection and declare variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As New DataTable

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

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClearForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearForm.Click
        txtEmailBody.Clear()
        txtSubjectLine.Clear()
        txtTestEmailAddress.Clear()
        txtFilename.Clear()
        txtFileNamePath.Clear()
    End Sub

    Private Sub cmdSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendEmail.Click
        'Declare Variables
        Dim ATLCustomerEmails As String = ""
        Dim ATLCustomerID As String = ""
        Dim ATLEmailCounter As Integer = 1

        Dim ALBCustomerEmails As String = ""
        Dim ALBCustomerID As String = ""
        Dim ALBEmailCounter As Integer = 1

        Dim CBSCustomerEmails As String = ""
        Dim CBSCustomerID As String = ""
        Dim CBSEmailCounter As Integer = 1

        Dim CGOCustomerEmails As String = ""
        Dim CGOCustomerID As String = ""
        Dim CGOEmailCounter As Integer = 1

        Dim CHTCustomerEmails As String = ""
        Dim CHTCustomerID As String = ""
        Dim CHTEmailCounter As Integer = 1

        Dim DENCustomerEmails As String = ""
        Dim DENCustomerID As String = ""
        Dim DENEmailCounter As Integer = 1

        Dim HOUCustomerEmails As String = ""
        Dim HOUCustomerID As String = ""
        Dim HOUEmailCounter As Integer = 1

        Dim SLCCustomerEmails As String = ""
        Dim SLCCustomerID As String = ""
        Dim SLCEmailCounter As Integer = 1

        Dim TFFCustomerEmails As String = ""
        Dim TFFCustomerID As String = ""
        Dim TFFEmailCounter As Integer = 1

        Dim TFJCustomerEmails As String = ""
        Dim TFJCustomerID As String = ""
        Dim TFJEmailCounter As Integer = 1

        Dim TFTCustomerEmails As String = ""
        Dim TFTCustomerID As String = ""
        Dim TFTEmailCounter As Integer = 1

        Dim TFPCustomerEmails As String = ""
        Dim TFPCustomerID As String = ""
        Dim TFPEmailCounter As Integer = 1

        Dim TORCustomerEmails As String = ""
        Dim TORCustomerID As String = ""
        Dim TOREmailCounter As Integer = 1

        Dim TWDCustomerEmails As String = ""
        Dim TWDCustomerID As String = ""
        Dim TWDEmailCounter As Integer = 1

        Dim TWECustomerEmails As String = ""
        Dim TWECustomerID As String = ""
        Dim TWEEmailCounter As Integer = 1

        Dim TSTCustomerEmails As String = ""
        Dim TSTCustomerID As String = ""
        Dim TSTEmailCounter As Integer = 1

        Dim Counter As Integer = 0
        Dim MessageBodyAndSignature As String = ""
        '**********************************************************************************************************
        'Check if test email field is used - send test email but not others
        If txtTestEmailAddress.Text <> "" Then
            Dim TestEmail As String = ""
            Dim TestBody As String = ""
            Dim TestSubject As String = ""
            Dim TestSignatureAndBody As String = ""
            Dim TestMessageFileNameAndPath As String = ""
            Dim MyTestMailMessage As New MailMessage()

            TestEmail = txtTestEmailAddress.Text
            TestBody = txtEmailBody.Text
            TestSubject = txtSubjectLine.Text
            TestSignatureAndBody = TestBody + Environment.NewLine + txtSignature.Text
            TestMessageFileNameAndPath = txtFileNamePath.Text

            'If TestEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
            'Set up test email to be sent
            MyTestMailMessage.From = New MailAddress("truweld@tfpcorp.com")
            MyTestMailMessage.Bcc.Add(TestEmail)
            MyTestMailMessage.Subject = TestSubject
            MyTestMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyTestMailMessage.Body = TestSignatureAndBody
            If TestMessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyTestMailMessage.Attachments.Add(New Attachment(TestMessageFileNameAndPath))
            End If

            Dim TestSMPT As New SmtpClient("Mail.tfpcorp.com")
            TestSMPT.Port = 587
            'SMPT.Timeout = 1500
            TestSMPT.EnableSsl = False
            TestSMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            TestSMPT.Send(MyTestMailMessage)

            MsgBox("Test email has been sent.", MsgBoxStyle.OkOnly)
            Exit Sub
            'Else
            '    MsgBox("Not a valid email address.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'End If
        Else
            'Continue as usual
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkATL.Checked = True Then
            'Load Data Table for ATL
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim ATLDataSet As New DataSet
            Dim ATLDataTable As New DataTable
            Dim ATLAdapter As New SqlDataAdapter
            ATLAdapter.SelectCommand = cmd
            'ATLAdapter.Fill(ATLDataSet, "CustomerList")
            ATLAdapter.Fill(ATLDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each ATLDataRow As DataRow In ATLDataTable.Rows
                ATLCustomerEmails = ATLDataTable.Rows(Counter).Item("SalesContactEmail")
                ATLCustomerID = ATLDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If ATLCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(ATLCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = ATLEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = ATLCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = ATLCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        ATLEmailCounter = ATLEmailCounter + 1
                    Next

                    ATLEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = ATLCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = ATLCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If ATLCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = ATLCustomerEmails
                        ErrorReferenceNumber = ATLCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(ATLCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("ATL Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            ATLCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkALB.Checked = True Then
            'Load Data Table for ALB
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim ALBDataSet As New DataSet
            Dim ALBDataTable As New DataTable
            Dim ALBAdapter As New SqlDataAdapter
            ALBAdapter.SelectCommand = cmd
            'ALBAdapter.Fill(ALBDataSet, "CustomerList")
            ALBAdapter.Fill(ALBDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each ALBDataRow As DataRow In ALBDataTable.Rows
                ALBCustomerEmails = ALBDataTable.Rows(Counter).Item("SalesContactEmail")
                ALBCustomerID = ALBDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If ALBCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(ALBCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = ALBEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = ALBCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = ALBCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        ALBEmailCounter = ALBEmailCounter + 1
                    Next

                    ALBEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = ALBCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = ALBCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If ALBCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = ALBCustomerEmails
                        ErrorReferenceNumber = ALBCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(ALBCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("ALB Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            ALBCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkCBS.Checked = True Then
            'Load Data Table for CBS
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim CBSDataSet As New DataSet
            Dim CBSDataTable As New DataTable
            Dim CBSAdapter As New SqlDataAdapter
            CBSAdapter.SelectCommand = cmd
            'CBSAdapter.Fill(CBSDataSet, "CustomerList")
            CBSAdapter.Fill(CBSDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each CBSDataRow As DataRow In CBSDataTable.Rows
                CBSCustomerEmails = CBSDataTable.Rows(Counter).Item("SalesContactEmail")
                CBSCustomerID = CBSDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If CBSCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(CBSCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = CBSEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = CBSCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()


                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = CBSCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        CBSEmailCounter = CBSEmailCounter + 1
                    Next

                    CBSEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = CBSCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = CBSCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If CBSCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = CBSCustomerEmails
                        ErrorReferenceNumber = CBSCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(CBSCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("CBS Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            CBSCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkCGO.Checked = True Then
            'Load Data Table for CGO
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim CGODataSet As New DataSet
            Dim CGODataTable As New DataTable
            Dim CGOAdapter As New SqlDataAdapter
            CGOAdapter.SelectCommand = cmd
            'CGOAdapter.Fill(CGODataSet, "CustomerList")
            CGOAdapter.Fill(CGODataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each CGODataRow As DataRow In CGODataTable.Rows
                CGOCustomerEmails = CGODataTable.Rows(Counter).Item("SalesContactEmail")
                CGOCustomerID = CGODataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If CGOCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(CGOCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = CGOEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = CGOCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = CGOCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        CGOEmailCounter = CGOEmailCounter + 1
                    Next

                    CGOEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = CGOCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = CGOCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If CGOCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = CGOCustomerEmails
                        ErrorReferenceNumber = CGOCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(CGOCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("CGO Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            CGOCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkCHT.Checked = True Then
            'Load Data Table for CHT
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim CHTDataSet As New DataSet
            Dim CHTDataTable As New DataTable
            Dim CHTAdapter As New SqlDataAdapter
            CHTAdapter.SelectCommand = cmd
            'CHTAdapter.Fill(CHTDataSet, "CustomerList")
            CHTAdapter.Fill(CHTDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each CHTDataRow As DataRow In CHTDataTable.Rows
                CHTCustomerEmails = CHTDataTable.Rows(Counter).Item("SalesContactEmail")
                CHTCustomerID = CHTDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If CHTCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(CHTCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = CHTEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = CHTCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = CHTCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        CHTEmailCounter = CHTEmailCounter + 1
                    Next

                    CHTEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = CHTCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = CHTCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If CHTCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = CHTCustomerEmails
                        ErrorReferenceNumber = CHTCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(CHTCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("CHT Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            CHTCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkDEN.Checked = True Then
            'Load Data Table for DEN
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim DENDataSet As New DataSet
            Dim DENDataTable As New DataTable
            Dim DENAdapter As New SqlDataAdapter
            DENAdapter.SelectCommand = cmd
            'DENAdapter.Fill(DENDataSet, "CustomerList")
            DENAdapter.Fill(DENDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each DENDataRow As DataRow In DENDataTable.Rows
                DENCustomerEmails = DENDataTable.Rows(Counter).Item("SalesContactEmail")
                DENCustomerID = DENDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If DENCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(DENCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = DENEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = DENCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = DENCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        DENEmailCounter = DENEmailCounter + 1
                    Next

                    DENEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = DENCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = DENCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If DENCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = DENCustomerEmails
                        ErrorReferenceNumber = DENCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(DENCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("DEN Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            DENCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkHOU.Checked = True Then
            'Load Data Table for HOU
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim HOUDataSet As New DataSet
            Dim HOUDataTable As New DataTable
            Dim HOUAdapter As New SqlDataAdapter
            HOUAdapter.SelectCommand = cmd
            'HOUAdapter.Fill(HOUDataSet, "CustomerList")
            HOUAdapter.Fill(HOUDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each HOUDataRow As DataRow In HOUDataTable.Rows
                HOUCustomerEmails = HOUDataTable.Rows(Counter).Item("SalesContactEmail")
                HOUCustomerID = HOUDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If HOUCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(HOUCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = HOUEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = HOUCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()


                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = HOUCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        HOUEmailCounter = HOUEmailCounter + 1
                    Next

                    HOUEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = HOUCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = HOUCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If HOUCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = HOUCustomerEmails
                        ErrorReferenceNumber = HOUCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(HOUCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("HOU Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            HOUCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkSLC.Checked = True Then
            'Load Data Table for SLC
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim SLCDataSet As New DataSet
            Dim SLCDataTable As New DataTable
            Dim SLCAdapter As New SqlDataAdapter
            SLCAdapter.SelectCommand = cmd
            'SLCAdapter.Fill(SLCDataSet, "CustomerList")
            SLCAdapter.Fill(SLCDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each SLCDataRow As DataRow In SLCDataTable.Rows
                SLCCustomerEmails = SLCDataTable.Rows(Counter).Item("SalesContactEmail")
                SLCCustomerID = SLCDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If SLCCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(SLCCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = SLCEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = SLCCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = SLCCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        SLCEmailCounter = SLCEmailCounter + 1
                    Next

                    SLCEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = SLCCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = SLCCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If SLCCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = SLCCustomerEmails
                        ErrorReferenceNumber = SLCCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(SLCCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("SLC Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            SLCCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkTFF.Checked = True Then
            'Load Data Table for TFF
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim TFFDataSet As New DataSet
            Dim TFFDataTable As New DataTable
            Dim TFFAdapter As New SqlDataAdapter
            TFFAdapter.SelectCommand = cmd
            'TFFAdapter.Fill(TFFDataSet, "CustomerList")
            TFFAdapter.Fill(TFFDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each TFFDataRow As DataRow In TFFDataTable.Rows
                TFFCustomerEmails = TFFDataTable.Rows(Counter).Item("SalesContactEmail")
                TFFCustomerID = TFFDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If TFFCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(TFFCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = TFFEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = TFFCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = TFFCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        TFFEmailCounter = TFFEmailCounter + 1
                    Next

                    TFFEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = TFFCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = TFFCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If TFFCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = TFFCustomerEmails
                        ErrorReferenceNumber = TFFCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(TFFCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("TFF Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            TFFCustomerEmails = ""
        End If
        '***********************************************************************************************************************************************************
        'Get Email Addresses
        If chkTFJ.Checked = True Then
            'Load Data Table for TFJ
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim TFJDataSet As New DataSet
            Dim TFJDataTable As New DataTable
            Dim TFJAdapter As New SqlDataAdapter
            TFJAdapter.SelectCommand = cmd
            'TFJAdapter.Fill(TFJDataSet, "CustomerList")
            TFJAdapter.Fill(TFJDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each TFJDataRow As DataRow In TFJDataTable.Rows
                TFJCustomerEmails = TFJDataTable.Rows(Counter).Item("SalesContactEmail")
                TFJCustomerID = TFJDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If TFJCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(TFJCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = TFJEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = TFJCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = TFJCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        TFJEmailCounter = TFJEmailCounter + 1
                    Next

                    TFJEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = TFJCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = TFJCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If TFJCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = TFJCustomerEmails
                        ErrorReferenceNumber = TFJCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(TFJCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("TFJ Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            TFJCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkTFP.Checked = True Then
            'Load Data Table for TFP
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim TFPDataSet As New DataSet
            Dim TFPDataTable As New DataTable
            Dim TFPAdapter As New SqlDataAdapter
            TFPAdapter.SelectCommand = cmd
            'TFPAdapter.Fill(TFPDataSet, "CustomerList")
            TFPAdapter.Fill(TFPDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each TFPDataRow As DataRow In TFPDataTable.Rows
                TFPCustomerEmails = TFPDataTable.Rows(Counter).Item("SalesContactEmail")
                TFPCustomerID = TFPDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If TFPCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(TFPCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = TFPEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = TFPCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = TFPCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        TFPEmailCounter = TFPEmailCounter + 1
                    Next

                    TFPEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = TFPCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = TFPCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If TFPCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = TFPCustomerEmails
                        ErrorReferenceNumber = TFPCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(TFPCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("TFP Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            TFPCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkTFT.Checked = True Then
            'Load Data Table for TFT
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim TFTDataSet As New DataSet
            Dim TFTDataTable As New DataTable
            Dim TFTAdapter As New SqlDataAdapter
            TFTAdapter.SelectCommand = cmd
            'TFTAdapter.Fill(TFTDataSet, "CustomerList")
            TFTAdapter.Fill(TFTDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each TFTDataRow As DataRow In TFTDataTable.Rows
                TFTCustomerEmails = TFTDataTable.Rows(Counter).Item("SalesContactEmail")
                TFTCustomerID = TFTDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If TFTCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(TFTCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = TFTEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = TFTCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()


                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = TFTCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        TFTEmailCounter = TFTEmailCounter + 1
                    Next

                    TFTEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = TFTCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = TFTCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If TFTCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = TFTCustomerEmails
                        ErrorReferenceNumber = TFTCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(TFTCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("TFT Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            TFTCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkTOR.Checked = True Then
            'Load Data Table for TOR
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim TORDataSet As New DataSet
            Dim TORDataTable As New DataTable
            Dim TORAdapter As New SqlDataAdapter
            TORAdapter.SelectCommand = cmd
            'TORAdapter.Fill(TORDataSet, "CustomerList")
            TORAdapter.Fill(TORDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each TORDataRow As DataRow In TORDataTable.Rows
                TORCustomerEmails = TORDataTable.Rows(Counter).Item("SalesContactEmail")
                TORCustomerID = TORDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If TORCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(TORCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = TOREmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = TORCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = TORCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        TOREmailCounter = TOREmailCounter + 1
                    Next

                    TOREmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = TORCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = TORCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If TORCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = TORCustomerEmails
                        ErrorReferenceNumber = TORCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(TORCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("TOR Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            TORCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkTWD.Checked = True Then
            'Load Data Table for TWD
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID LIKE 'TFP %' AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim TWDDataSet As New DataSet
            Dim TWDDataTable As New DataTable
            Dim TWDAdapter As New SqlDataAdapter
            TWDAdapter.SelectCommand = cmd
            TWDAdapter.Fill(TWDDataTable)
            con.Close()

            Counter = 0

            'Go thru every row in the database that has an email address
            For Each TWDDataRow As DataRow In TWDDataTable.Rows
                TWDCustomerEmails = TWDDataTable.Rows(Counter).Item("SalesContactEmail")
                TWDCustomerID = TWDDataTable.Rows(Counter).Item("CustomerID")

                'Set up email to be sent
                Dim MyMailMessage As New MailMessage()
                MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If TWDCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(TWDCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = TWDEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = TWDCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = TWDCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        'Clear Variables
                        CurrentEmail = ""

                        Counter2 = Counter2 + 1
                        TWDEmailCounter = TWDEmailCounter + 1
                    Next
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = TWDCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = TWDCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If TWDCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = TWDCustomerEmails
                        ErrorReferenceNumber = TWDCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(TWDCustomerEmails)
                    End If
                End If

                'Send the Email and then clear variables
                If MessageFileNameAndPath = "" Then
                    'No attached file
                Else
                    MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
                End If

                Try
                    MyMailMessage.Subject = txtSubjectLine.Text
                    MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
                    MyMailMessage.Body = MessageBodyAndSignature
                    Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
                    SMPT.Port = 587
                    'SMPT.Timeout = 1500
                    SMPT.EnableSsl = False
                    SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
                    SMPT.Send(MyMailMessage)
                Catch ex As Exception
                    'Bad Email Address - write to error log
                    ErrorDate = Today()
                    ErrorComment = "Customer Announcement - Emails not sent"
                    ErrorDivision = EmployeeCompanyCode
                    ErrorDescription = "No emails were sent"
                    ErrorReferenceNumber = "NONE"
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                'Clear Variables
                TWDCustomerEmails = ""
                TWDCustomerID = ""
                MessageBodyAndSignature = ""
                MessageFileNameAndPath = ""
                NextAnnouncementNumber = 0
                LastAnnouncementNumber = 0

                'Advance the counter
                Counter = Counter + 1
            Next

            'Confirm that the emails were sent
            MsgBox("TWD Emails sent", MsgBoxStyle.OkOnly)
        Else
            TWDCustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkTWE.Checked = True Then
            'Load Data Table for TWE
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim TWEDataSet As New DataSet
            Dim TWEDataTable As New DataTable
            Dim TWEAdapter As New SqlDataAdapter
            TWEAdapter.SelectCommand = cmd
            'TWEAdapter.Fill(TWEDataSet, "CustomerList")
            TWEAdapter.Fill(TWEDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each TWEDataRow As DataRow In TWEDataTable.Rows
                TWECustomerEmails = TWEDataTable.Rows(Counter).Item("SalesContactEmail")
                TWECustomerID = TWEDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If TWECustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(TWECustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = TWEEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = TWECustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = TWECustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        TWEEmailCounter = TWEEmailCounter + 1
                    Next

                    TWEEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = TWECustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = TWECustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If TWECustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = TWECustomerEmails
                        ErrorReferenceNumber = TWECustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(TWECustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweldtfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("TWE Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            TWECustomerEmails = ""
        End If
        '**********************************************************************************************************
        'Get Email Addresses
        If chkTST.Checked = True Then
            'Load Data Table for TST
            cmd = New SqlCommand("SELECT SalesContactEmail, CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND SalesContactEmail <> '' ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            If con.State = ConnectionState.Closed Then con.Open()
            Dim TSTDataSet As New DataSet
            Dim TSTDataTable As New DataTable
            Dim TSTAdapter As New SqlDataAdapter
            TSTAdapter.SelectCommand = cmd
            'TSTAdapter.Fill(TSTDataSet, "CustomerList")
            TSTAdapter.Fill(TSTDataTable)
            con.Close()

            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress("truweld@tfpcorp.com")

            'Go thru every row in the database that has an email address
            For Each TSTDataRow As DataRow In TSTDataTable.Rows
                TSTCustomerEmails = TSTDataTable.Rows(Counter).Item("SalesContactEmail")
                TSTCustomerID = TSTDataTable.Rows(Counter).Item("CustomerID")

                'Email Variables
                MessageBodyAndSignature = txtEmailBody.Text + Environment.NewLine + txtSignature.Text
                MessageFileNameAndPath = txtFileNamePath.Text

                'Check if file exists
                If File.Exists(MessageFileNameAndPath) Then
                    'Continue
                Else
                    MessageFileNameAndPath = ""
                End If

                'Get New Announcement ID
                Dim MAXStatement As String = "SELECT MAX(AnnouncementID) FROM AnnouncementTable"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAnnouncementNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As System.Exception
                    LastAnnouncementNumber = 33300
                End Try
                con.Close()

                NextAnnouncementNumber = LastAnnouncementNumber + 1

                'Write Values to Header table
                cmd = New SqlCommand("Insert Into AnnouncementTable(AnnouncementID, DivisionID, AnnouncementDate, AnnouncementSubject, AnnouncementEmail, Sender, AnnouncementFileName) Values (@AnnouncementID, @DivisionID, @AnnouncementDate, @AnnouncementSubject, @AnnouncementEmail, @Sender, @AnnouncementFileName)", con)

                With cmd.Parameters
                    .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                    .Add("@AnnouncementDate", SqlDbType.VarChar).Value = Today()
                    .Add("@AnnouncementSubject", SqlDbType.VarChar).Value = txtSubjectLine.Text
                    .Add("@AnnouncementEmail", SqlDbType.VarChar).Value = MessageBodyAndSignature
                    .Add("@Sender", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AnnouncementFileName", SqlDbType.VarChar).Value = txtFilename.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Add array of email addresses if necessay
                'Parse email field to determine how many addresses 
                If TSTCustomerEmails.Contains(";") Then
                    Dim EmailArray As Array
                    Dim ArrayCount As Integer = 0
                    Dim CurrentEmail As String = ""

                    EmailArray = Split(TSTCustomerEmails, ";")
                    ArrayCount = UBound(EmailArray) + 1
                    Dim Counter2 As Integer = 1

                    For i As Integer = 0 To UBound(EmailArray)
                        CurrentEmail = EmailArray(ArrayCount - Counter2)

                        If CurrentEmail.Contains(" ") Then
                            CurrentEmail = CurrentEmail.Replace(" ", "")
                        End If

                        'Write email address and customer to Announcement Line Table
                        cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                        With cmd.Parameters
                            .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                            .Add("@LineNumber", SqlDbType.VarChar).Value = TSTEmailCounter
                            .Add("@CustomerID", SqlDbType.VarChar).Value = TSTCustomerID
                            .Add("@EmailAddress", SqlDbType.VarChar).Value = CurrentEmail
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        If CurrentEmail.Count(Function(c) badChars.Contains(c)) > 0 Then
                            'Bad Email Address - write to error log
                            ErrorDate = Today()
                            ErrorComment = "Customer Announcement - Bad Email Address"
                            ErrorDivision = EmployeeCompanyCode
                            ErrorDescription = CurrentEmail
                            ErrorReferenceNumber = TSTCustomerID
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        Else
                            'Add Email addresses
                            MyMailMessage.Bcc.Add(CurrentEmail)
                        End If

                        Counter2 = Counter2 + 1
                        TSTEmailCounter = TSTEmailCounter + 1
                    Next

                    TSTEmailCounter = 1
                Else
                    'Write email address and customer to Announcement Line Table
                    cmd = New SqlCommand("Insert Into AnnouncementLineTable(AnnouncementID, LineNumber, CustomerID, EmailAddress) Values (@AnnouncementID, @LineNumber, @CustomerID, @EmailAddress)", con)

                    With cmd.Parameters
                        .Add("@AnnouncementID", SqlDbType.VarChar).Value = NextAnnouncementNumber
                        .Add("@LineNumber", SqlDbType.VarChar).Value = 1
                        .Add("@CustomerID", SqlDbType.VarChar).Value = TSTCustomerID
                        .Add("@EmailAddress", SqlDbType.VarChar).Value = TSTCustomerEmails
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Add Email addresses
                    If TSTCustomerEmails.Count(Function(c) badChars.Contains(c)) > 0 Then
                        'Bad Email Address - write to error log
                        ErrorDate = Today()
                        ErrorComment = "Customer Announcement - Bad Email Address"
                        ErrorDivision = EmployeeCompanyCode
                        ErrorDescription = TSTCustomerEmails
                        ErrorReferenceNumber = TSTCustomerID
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    Else
                        'Add Email addresses
                        MyMailMessage.Bcc.Add(TSTCustomerEmails)
                    End If
                End If

                Counter = Counter + 1
            Next

            If MessageFileNameAndPath = "" Then
                'No attached file
            Else
                MyMailMessage.Attachments.Add(New Attachment(MessageFileNameAndPath))
            End If

            MyMailMessage.To.Add("truweld@tfpcorp.com")
            MyMailMessage.Subject = txtSubjectLine.Text
            MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
            MyMailMessage.Body = MessageBodyAndSignature
            Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("truweld@tfpcorp.com", "Thnbhu8")
            SMPT.Send(MyMailMessage)

            MsgBox("TST Emails sent", MsgBoxStyle.OkOnly)

            Counter = 0
        Else
            TSTCustomerEmails = ""
        End If
        '**********************************************************************************************************

    End Sub

    Private Sub cmdSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectFile.Click
        Dim AttachmentFile As String = ""
        Dim AttachmentPath As String = ""

        OpenAttachment.InitialDirectory = "C:\"
        OpenAttachment.Filter = "pdf files (*.pdf)|*.pdf"
        OpenAttachment.FilterIndex = 1
        OpenAttachment.RestoreDirectory = True
        OpenAttachment.ShowDialog()

        AttachmentPath = OpenAttachment.FileName.ToString
        AttachmentFile = OpenAttachment.SafeFileName.ToString

        txtFilename.Text = AttachmentFile
        txtFileNamePath.Text = AttachmentPath
    End Sub

    Private Sub CustomerAnnouncements_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load Security for Power Users and Regular Users

        If EmployeeSecurityCode = "1001" Or EmployeeCompanyCode = "1002" Then
            gpxDivisionSelection.Enabled = True

            If EmployeeCompanyCode = "ADM" Then
                'Do nothing
            Else
                Select Case EmployeeCompanyCode
                    Case "ATL"
                        chkATL.Checked = True
                    Case "ALB"
                        chkALB.Checked = True
                    Case "CBS"
                        chkCBS.Checked = True
                    Case "CGO"
                        chkCGO.Checked = True
                    Case "CHT"
                        chkCHT.Checked = True
                    Case "DEN"
                        chkDEN.Checked = True
                    Case "HOU"
                        chkHOU.Checked = True
                    Case "SLC"
                        chkSLC.Checked = True
                    Case "TFF"
                        chkTFF.Checked = True
                    Case "TFJ"
                        chkTFJ.Checked = True
                    Case "TFP"
                        chkTFP.Checked = True
                    Case "TFT"
                        chkTFT.Checked = True
                    Case "TOR"
                        chkTOR.Checked = True
                    Case "TWD"
                        chkTWD.Checked = True
                    Case "TWE"
                        chkTWE.Checked = True
                    Case Else
                        'Do nothing
                End Select
            End If
        Else
            gpxDivisionSelection.Enabled = False

            Select Case EmployeeCompanyCode
                Case "ATL"
                    chkATL.Checked = True
                Case "ALB"
                    chkALB.Checked = True
                Case "CBS"
                    chkCBS.Checked = True
                Case "CGO"
                    chkCGO.Checked = True
                Case "CHT"
                    chkCHT.Checked = True
                Case "DEN"
                    chkDEN.Checked = True
                Case "HOU"
                    chkHOU.Checked = True
                Case "SLC"
                    chkSLC.Checked = True
                Case "TFF"
                    chkTFF.Checked = True
                Case "TFJ"
                    chkTFJ.Checked = True
                Case "TFP"
                    chkTFP.Checked = True
                Case "TFT"
                    chkTFT.Checked = True
                Case "TOR"
                    chkTOR.Checked = True
                Case "TWD"
                    chkTWD.Checked = True
                Case "TWE"
                    chkTWE.Checked = True
                Case Else
                    'Do nothing
            End Select
        End If
    End Sub

    Public Function ValidateEmailAddresses() As Boolean

        'Test One - Simple Format
        If ValidateEmailAddress.Contains("@") Then
            'Pass
        Else
            Return False
        End If

        'Remove blanks on the Beginning of the field
        If ValidateEmailAddress.StartsWith(" ") Then
            ValidateEmailAddress = ValidateEmailAddress.Replace(" ", "")
        End If

        'Remove blanks on the end of the field
        If ValidateEmailAddress.EndsWith(" ") Then
            ValidateEmailAddress = ValidateEmailAddress.Replace(" ", "")
        End If

        'Test Two - Simple Format
        If ValidateEmailAddress.Contains(" ") Then
            Return False
        Else
            'Pass
        End If









        Return True
    End Function

    Private Sub cmdCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckAll.Click
        chkALB.Checked = True
        chkATL.Checked = True
        chkCBS.Checked = True
        chkCGO.Checked = True
        chkCHT.Checked = True
        chkDEN.Checked = True
        chkHOU.Checked = True
        chkSLC.Checked = True
        chkTFF.Checked = True
        chkTFP.Checked = True
        chkTFT.Checked = True
        chkTOR.Checked = True
        chkTWD.Checked = True
        chkTWE.Checked = True
    End Sub

    Private Sub cmdUncheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUncheckAll.Click
        chkALB.Checked = False
        chkATL.Checked = False
        chkCBS.Checked = False
        chkCGO.Checked = False
        chkCHT.Checked = False
        chkDEN.Checked = False
        chkHOU.Checked = False
        chkSLC.Checked = False
        chkTFF.Checked = False
        chkTFP.Checked = False
        chkTFT.Checked = False
        chkTOR.Checked = False
        chkTWD.Checked = False
        chkTWE.Checked = False
    End Sub

    Private Sub cmdLoadDefaultSignature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadDefaultSignature.Click
        DefaultSignature = "" + Environment.NewLine + "" + Environment.NewLine + "Truweld Studwelding" + Environment.NewLine + "460 Lake Road" + Environment.NewLine + "Medina, Ohio 44256" + Environment.NewLine + "(330) 725-7741" + Environment.NewLine + "(330) 725-0161 Fax" + Environment.NewLine + "www.truweldstudwelding.com"

        txtSignature.Text = DefaultSignature
    End Sub

    Private Sub cmdClearSignature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearSignature.Click
        txtSignature.Clear()
    End Sub

    Private Sub cmdRemoveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFile.Click
        txtFilename.Clear()
        txtFileNamePath.Clear()
    End Sub

    Private Sub cmdValidateEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidateEmail.Click
        ValidateEmailAddress = txtTestEmailAddress.Text

        If ValidateEmailAddresses() Then
            MsgBox("Valid Email Address", MsgBoxStyle.OkOnly)
        Else
            MsgBox("Invalid Email Address", MsgBoxStyle.OkOnly)
        End If
    End Sub
End Class