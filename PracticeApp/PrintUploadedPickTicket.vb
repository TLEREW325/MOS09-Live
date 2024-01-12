Imports System
Imports System.Math
Imports System.IO
Imports System.Data
'Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook
Public Class PrintUploadedPickTicket
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim MyReport2 = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim CertName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim ConfirmName As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Public Sub New(ByVal fileName As String)
        InitializeComponent()
        bsrPickTicket.Navigate(fileName)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalUploadedPickTicket = ""
        GlobalShipmentNumber = 0
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub EmailPickTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailPickTicketToolStripMenuItem.Click
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
            'Create new Filename for Pick Ticket
            Dim strShipmentNumber As String = ""
            strShipmentNumber = CStr(GlobalShipmentNumber)

            ConfirmName = strShipmentNumber

            TFPMailFilename = ConfirmName + ".pdf"
            TFPMailFilename2 = ""
            TFPMailFilename3 = ""
            TFPMailFilePath = "\\TFP-FS\TransferData\UploadedPickTickets\" + strShipmentNumber + ".pdf"
            TFPMailFilePath2 = ""
            TFPMailFilePath3 = ""
            TFPMailTransactionType = "Print Uploaded Pick Ticket"
            TFPMailTransactionNumber = GlobalShipmentNumber
            TFPMailCustomer = GlobalCertCustomer

            Using NewEmailPage As New EmailPage
                Dim Result = NewEmailPage.ShowDialog()
            End Using
        Else
            'Create new Filename for Cert
            Dim strShipmentNumber As String = ""
            strShipmentNumber = CStr(GlobalShipmentNumber)

            'CertName = " Shipment #" + strShipmentNumber

            ''Export Document to Folder
            'MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-SQL\TransferData\ExportedCerts\" + GlobalDivisionCode + "\" + GlobalCertCustomer + CertName + ".pdf")

            'If GlobalPrintNoCertPage = "YES" Then
            '    MyReport2.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-SQL\TransferData\ExportedCerts\NO-CERT.pdf")
            'Else
            '    'Skip
            'End If

            'creating outlook mailitem
            Dim mail As MailItem

            'creating newblank mail message
            mail = OLApp.CreateItem(OlItemType.olMailItem)

            'Dim recipient As Recipient
            'Adding recipeints to the mail message
            'recipient = mail.Recipients.Add("name@hotmail.com")
            'Do Check Name here
            'recipient.Resolve()

            'adding subject information to the mail message
            mail.Subject = "Pick Ticket"

            'adding body message information to the mail message
            mail.Body = "Trufit Pick Ticket attached"

            'adding attachment
            mail.Attachments.Add("\\TFP-FS\TransferData\UploadedPickTickets\" + strShipmentNumber + ".pdf")

            'display mail
            mail.Display()

            'sending mail
            'mail.Send()

            'CreateAppointmentRecord()

            Me.Close()
        End If
    End Sub

    Private Sub PrintUploadedPickTicket_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalUploadedPickTicket = ""
        GlobalShipmentNumber = 0
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class