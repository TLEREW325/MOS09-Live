Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook

Public Class PrintARCustomerPaymentListing
    Inherits System.Windows.Forms.Form
    'Created Outlook Application object
    Dim OLApp As New Application

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRPaymentViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRPaymentViewer.Load
        'Loads data into dataset for viewing
        ds = GDS

        'Sets up viewer to display data from the loaded dataset
        MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXARCustomerPaymentListing1
        MyReport.SetDataSource(ds)
        CRPaymentViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub EmailPaymentListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailPaymentListingToolStripMenuItem.Click
        'Create new Filename for Quote
        Dim FileDate As DateTime = Today()
        Dim monthofyear As String = FileDate.Month.ToString()
        Dim dayofyear As String = FileDate.DayOfYear.ToString()
        Dim yearofyear As String = FileDate.Year.ToString()
        Dim minutesofyear As String = FileDate.Minute.ToString()

        Dim strCompany As String = GlobalDivisionCode

        Dim ConfirmName As String = strCompany + monthofyear + dayofyear + yearofyear + minutesofyear

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldARBatch\TW-ARBatch" & ConfirmName & ".pdf")

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
        mail.Subject = "Truweld / Trufit AR Batch"

        'adding body message information to the mail message
        mail.Body = "This is an AR Customer Payment Listing."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldARBatch\TW-ARBatch" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()
    End Sub
End Class