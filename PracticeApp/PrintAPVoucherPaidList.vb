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
Public Class PrintAPVoucherPaidList
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRVoucherViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVoucherViewer.Load
        'Loads data into dataset for viewing
        ds = GDS

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXAPPaidVouchers1
        MyReport.SetDataSource(ds)
        CRVoucherViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub EmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailToolStripMenuItem.Click
        'Create new Filename for Pack List
        FileDate = Today()
        monthofyear = FileDate.Month
        dayofyear = FileDate.DayOfYear
        yearofyear = FileDate.Year
        minuteofyear = FileDate.Minute
        strMonth = CStr(monthofyear)
        strDay = CStr(dayofyear)
        strYear = CStr(yearofyear)
        strMinute = CStr(minuteofyear)
        strCompany = GlobalDivisionCode

        ConfirmName = strCompany + strMonth + strDay + strYear + strMinute

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldBOL\APVoucher" & ConfirmName & ".pdf")

        'creating outlook mailitem
        Dim mail As MailItem

        'creating newblank mail message
        mail = OLApp.CreateItem(OlItemType.olMailItem)

        'Dim recipient As Recipient
        If GlobalVendorIsLoaded = "TRUE" Then
            'adding to into the address field
            mail.To = GlobalVendorRemittanceEmail
        End If

        'adding subject information to the mail message
        mail.Subject = "Truweld / Trufit Remittance Advice"

        'adding body message information to the mail message
        mail.Body = "This is a Remittance Advice from Truweld / Trufit."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldBOL\APVoucher" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()

        Me.Close()
    End Sub

    Private Sub PrintAPVoucherPaidList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalVendorRemittanceEmail = ""
        GlobalVendorIsLoaded = ""
    End Sub
End Class