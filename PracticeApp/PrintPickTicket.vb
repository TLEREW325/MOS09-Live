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
Imports System.Runtime.InteropServices
Public Class PrintPickTicket
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
    Dim con2 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")

    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    'Public Sub New()
    '    InitializeComponent()

    'End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalPickBatchNumber = 0
        GlobalPickTicketType = ""
        GlobalPickListNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRPickViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRPickViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM PickListHeaderTable WHERE DivisionID = @DivisionID AND PickListHeaderKey = @PickListHeaderKey", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = GlobalPickListNumber

        cmd1 = New SqlCommand("SELECT * FROM PickListLineTable WHERE DivisionID = @DivisionID ORDER BY PickListHeaderKey, PickListLineKey", con2)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd5 = New SqlCommand("SELECT * FROM CountryCodes", con)

        cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo", con)

        If con.State = ConnectionState.Closed Then con.Open()
        If con2.State = ConnectionState.Closed Then con2.Open()

        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PickListHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "PickListLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "FoxTable")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "CountryCodes")

        myAdapter6.SelectCommand = cmd6
        myAdapter6.Fill(ds, "AdditionalShipTo")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXPickTicket1
        MyReport.SetDataSource(ds)
        CRPickViewer.ReportSource = MyReport
        con.Close()
        con2.Close()
    End Sub

    Private Sub EmailPickTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailPickTicketToolStripMenuItem.Click
        'Create new Filename for Pick Ticket
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
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\Pick" & ConfirmName & ".pdf")

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
        mail.Subject = "TW Pick Ticket"

        'adding body message information to the mail message
        mail.Body = "This is a Pick Ticket for Truweld / TFP Corporation."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldPackList\Pick" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()
    End Sub

    Private Sub PrintPickTicket_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        GlobalPickBatchNumber = 0
        GlobalPickTicketType = ""
        GlobalPickListNumber = 0
    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class