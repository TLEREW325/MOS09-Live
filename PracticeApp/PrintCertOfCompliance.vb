Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class PrintCertOfCompliance
    Inherits System.Windows.Forms.Form

    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    'Dim dt As DataTable

    Dim Filepath As String = ""

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim LastNoteNumber, NextNoteNumber As Integer

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Created Outlook Application object
    Dim OLApp As New Microsoft.Office.Interop.Outlook.Application

    Private Sub CRXViewerCert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRXViewerCert.Load
        Try


            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXCertOfCompliance1
            MyReport.SetDataSource(GDS1)
            CRXCertOfCompliance1 = MyReport

            con.Close()

        Catch ex As System.Exception

        End Try
    End Sub

    Private Sub PrintCertOfCompliance_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If My.Computer.FileSystem.FileExists(Filepath) Then

            My.Computer.FileSystem.DeleteFile(Filepath)

        End If

    End Sub

    Private Sub EmailCertToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailCertToolStripMenuItem1.Click
        FileDate = Now()
        monthofyear = FileDate.Month
        dayofyear = FileDate.DayOfYear
        yearofyear = FileDate.Year
        minuteofyear = FileDate.Minute
        strMonth = CStr(monthofyear)
        strDay = CStr(dayofyear)
        strYear = CStr(yearofyear)
        strMinute = CStr(minuteofyear)
        strCompany = GlobalDivisionCode

        Dim CertName As String

        'Create Subject line for invoice
        Dim strInvoiceNumber As String = ""
        strInvoiceNumber = strCompany + strMinute + strMonth + strDay + strYear

        'Create new Filename for Cert
        Dim strShipmentNumber As String = ""
        strShipmentNumber = strCompany + strMinute + strMonth + strDay + strYear

        CertName = " CoC #" + strShipmentNumber

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\ExportedCerts\" + GlobalDivisionCode + "\" + CertName + ".pdf")
        Filepath = "\\TFP-FS\TransferData\ExportedCerts\" + GlobalDivisionCode + "\" + CertName + ".pdf"

        'creating outlook mailitem
        Dim mail As MailItem

        'creating newblank mail message
        mail = OLApp.CreateItem(OlItemType.olMailItem)

        'Get invoice email address
        mail.To = EmailCustomerEmailAddress

        'adding subject information to the mail message
        mail.Subject = "Cert of Compliance -- " + " CoC. #" + strShipmentNumber

        'adding body message information to the mail message
        mail.Body = "CoC Attached " + strShipmentNumber


        mail.Attachments.Add("\\TFP-FS\TransferData\ExportedCerts\" + GlobalDivisionCode + "\" + CertName + ".pdf")

        'display mail
        mail.Display()

        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub
End Class