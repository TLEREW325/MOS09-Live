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
Public Class EmailSpecial
    Inherits System.Windows.Forms.Form

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

    Private Sub EmailSpecial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If EmployeeLoginName = "LEREW" Then
            cmdSendEmail.Enabled = True
        Else
            'Diable buttons
            cmdSendEmail.Enabled = False
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtEmailSubject.Clear()
        txtEmailAddress.Clear()
        txtEmailBody.Clear()
        txtNumberOfEmails.Clear()
        txtReturnAddress.Clear()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSendEmail.Click

        Dim SenderEmail As String = ""
        Dim RecipientEmail As String = ""
        Dim LoopCounter As Integer = 0
        Dim EmailSubject As String = ""
        Dim EmailBody As String = ""

        SenderEmail = txtReturnAddress.Text
        RecipientEmail = txtEmailAddress.Text
        LoopCounter = Val(txtNumberOfEmails.Text)
        EmailSubject = txtEmailSubject.Text
        EmailBody = txtEmailBody.Text

        For i As Integer = 1 To LoopCounter
            'Set up email to be sent
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress(SenderEmail)
            MyMailMessage.To.Add(RecipientEmail)
            MyMailMessage.Subject = EmailSubject
            MyMailMessage.ReplyTo = New MailAddress(SenderEmail)
            MyMailMessage.Body = EmailBody
            Dim SMPT As New SmtpClient("Mail.macsbaitstore.com")
            SMPT.Port = 587
            'SMPT.Timeout = 1500
            SMPT.EnableSsl = False
            SMPT.Credentials = New System.Net.NetworkCredential("spam@macsbaitstore.com", "1422325B@gie")
            SMPT.Send(MyMailMessage)

            EmailBody = EmailBody + txtEmailBody.Text
        Next

        MsgBox("All emails sent.", MsgBoxStyle.OkOnly)

    End Sub
End Class