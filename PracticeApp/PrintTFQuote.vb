'Imports System.Windows.Forms
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook
Imports System.ComponentModel
Public Class PrintTFQuote
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1 As New SqlDataAdapter
    Dim ds As DataSet

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation    
    Dim ConfirmName As String = ""

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalTFPQuoteNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub EmailQuoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailQuoteToolStripMenuItem.Click
        'Created Outlook Application object
        Dim OLApp As New Application
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
        mail.Subject = "Trufit Quote"

        'adding body message information to the mail message
        mail.Body = "This is a Quote from Truweld / TFP Corporation."


        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\SalesConfirmations\TFQuote-" & ConfirmName)

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()
    End Sub

    Private Sub CRQuoteViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRQuoteViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM Quotation WHERE QuoteID = @QuoteID", con)
        cmd.Parameters.Add("@QuoteID", SqlDbType.Int).Value = GlobalTFPQuoteNumber

        cmd1 = New SqlCommand("SELECT * FROM QuoteMarkup WHERE QuoteID = @QuoteID ORDER BY QuoteNumber ASC", con)
        cmd1.Parameters.Add("@QuoteID", SqlDbType.VarChar).Value = GlobalTFPQuoteNumber
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter1.SelectCommand = cmd1

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "Quotation")
        myAdapter1.Fill(ds, "QuoteMarkup")
        con.Close()

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXTFQuote1
        MyReport.SetDataSource(ds)
        CRQuoteViewer.ReportSource = MyReport

        'Save quote as file
        Dim FileDate As Date
        Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
        Dim strMinute, strMonth, strYear, strDay, strCompany As String

        'Create new Filename for Quote
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

        ConfirmName = strCompany + strMonth + strDay + strYear + strMinute + ".pdf"

        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\SalesConfirmations\TFQuote-" & ConfirmName)
    End Sub
End Class