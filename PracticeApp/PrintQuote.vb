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
Public Class PrintQuote
    Inherits System.Windows.Forms.Form

    Dim Customer, strSalesOrderNumber As String

    'Created Outlook Application object
    Dim OLApp As New Application

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalSONumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRQuoteViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRQuoteViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey", con)
        cmd2.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber

        cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd5 = New SqlCommand("SELECT * FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
        cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderHeaderTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "SalesOrderLineTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "DivisionTable")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "CustomerList")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "ItemList")

        myAdapter6.SelectCommand = cmd6
        myAdapter6.Fill(ds, "AdditionalShipTo")

        If GlobalDivisionCode = "TFF" Or GlobalDivisionCode = "TOR" Or GlobalDivisionCode = "ALB" Then
            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXTWQuoteTFF1
            MyReport.SetDataSource(ds)
            CRQuoteViewer.ReportSource = MyReport
            con.Close()
        Else
            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXTWQuote1
            MyReport.SetDataSource(ds)
            CRQuoteViewer.ReportSource = MyReport
            con.Close()
        End If

        'CreateAppointmentRecord()
    End Sub

    Public Sub CreateAppointmentRecord()
        Dim Appointment As AppointmentItem
        Dim Task As TaskItem

        Dim CustomerString As String = "SELECT CustomerID FROM SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey"
        Dim CustomerCommand As New SqlCommand(CustomerString, con)
        CustomerCommand.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber
        CustomerCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Customer = CStr(CustomerCommand.ExecuteScalar)
        con.Close()

        strSalesOrderNumber = CStr(GlobalSONumber)

        Appointment = OLApp.CreateItem(OlItemType.olAppointmentItem)
        Task = OLApp.CreateItem(OlItemType.olTaskItem)

        Task.Body = "Quote number " & strSalesOrderNumber & " sent to " & Customer
        Task.Subject = "TFP Quote - " & Customer
        Task.StartDate = Today()
        Task.DueDate = Today()
        Task.ReminderPlaySound = True
        Task.Importance = OlImportance.olImportanceHigh
        Task.Save()

        Appointment.Start = Today() & " 8:00AM"
        Appointment.End = Today() & " 5:00PM"
        Appointment.Location = "Quote Sent"
        Appointment.Body = "Quote # " & strSalesOrderNumber & " sent to " & Customer
        Appointment.Subject = Customer & " / " & strSalesOrderNumber
        Appointment.AllDayEvent = False

        Appointment.Save()
    End Sub

    Private Sub EmailQuoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailQuoteToolStripMenuItem.Click
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

        ConfirmName = strCompany + strMonth + strDay + strYear + strMinute

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldQuotes\TWQuote" & ConfirmName & ".pdf")

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
        mail.Subject = "Truweld / Trufit Quote"

        'adding body message information to the mail message
        mail.Body = "This is a Quote sent by Truweld / TFP Corporation."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldQuotes\TWQuote" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        Me.Close()
    End Sub

    Private Sub PrintQuote_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        GlobalSONumber = 0
    End Sub
End Class