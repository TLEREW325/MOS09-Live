Imports System
Imports System.Math
Imports System.Net.Mail
Imports System.Web
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Public Class AutoEmailer
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Async=True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmdNoCert As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapterNoCert As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, CertDataset, NoCertDataset As DataSet
    Dim dt As DataTable


    Public Sub AutoEmail()
        '***********************************************************************************************************************
        ''Auto email packing slip to customers who require it
        'Dim PackingListEmail As String = ""
        'Dim PackingListFileName As String = ""
        'Dim EmailShipmentNumber As Integer = 0
        'Dim strShipmentNumber As String = ""


        'If PackingListEmail = "" Then
        '    'Skip
        'Else
        '    'Attach and send email
        '    Try
        '        'Set up email to be sent
        '        Dim MyMailMessage As New MailMessage()
        '        MyMailMessage.From = New MailAddress("packinglist@tfpcorp.com")

        '        'Add array of email addresses if necessay
        '        'Parse email field to determine how many addresses 
        '        If PackingListEmail.Contains(";") Then
        '            Dim EmailArray As Array
        '            Dim ArrayCount As Integer = 0
        '            Dim CurrentEmail As String = ""

        '            EmailArray = Split(PackingListEmail, ";")
        '            ArrayCount = UBound(EmailArray) + 1
        '            Dim Counter As Integer = 1

        '            For i As Integer = 0 To UBound(EmailArray)
        '                CurrentEmail = EmailArray(ArrayCount - Counter)
        '                MyMailMessage.To.Add(CurrentEmail)
        '                Counter = Counter + 1
        '            Next
        '        Else
        '            MyMailMessage.To.Add(PackingListEmail)
        '        End If

        '        MyMailMessage.Attachments.Add(New Attachment("\\TFP-FS\TransferData\TruweldPackList\" + PackingListFileName))
        '        MyMailMessage.Subject = "Packing List / TFP Corporation"
        '        MyMailMessage.ReplyTo = New MailAddress("truweld@tfpcorp.com")
        '        MyMailMessage.Body = "Auto-sent Packing List for customer. Do not reply to this email address. Contact truweld@tfpcorp.com"
        '        Dim SMPT As New SmtpClient("Mail.tfpcorp.com")
        '        SMPT.Port = "587"
        '        SMPT.EnableSsl = False
        '        SMPT.Credentials = New System.Net.NetworkCredential("packinglist@tfpcorp.com", "1422325bogie")
        '        SMPT.Send(MyMailMessage)
        '    Catch ex As Exception
        '        'ErrorDate = Today()
        '        'ErrorComment = ex.ToString()
        '        'If ErrorComment.Length > 400 Then
        '        '    ErrorComment = ErrorComment.Substring(0, 399)
        '        'End If
        '        'ErrorDivision = cboDivisionID.Text
        '        'ErrorDescription = "ShipmentCompletion - Packing List not emailed. L7134"
        '        'ErrorReferenceNumber = "Shipment # " + cboShipmentNumber.Text
        '        'ErrorUser = EmployeeLoginName

        '        'TFPErrorLogUpdate()
        '    End Try
        '    Else
        '    'Skip
        'End If
        'End If

        'PackingListEmail = ""
        'PackingListFileName = ""
        'EmailShipmentNumber = 0
        'strShipmentNumber = ""
        '***********************************************************************************************************************

    End Sub

    Private Sub AutoEmailer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load














    End Sub

End Class