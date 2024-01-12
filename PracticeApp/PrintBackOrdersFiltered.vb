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
Public Class PrintBackOrdersFiltered
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        BackorderReportFilter = ""
        GDS = Nothing
        GDS = New DataSet()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRBackorderViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRBackorderViewer.Load
        If BackorderReportFilter = "CUSTOMER" Then
            cmd = New SqlCommand("SELECT * FROM BackOrderTest WHERE DivisionKey = @DivisionKey AND CustomerID = @CustomerID", con)
            cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = BackorderCustomer

            ds = New DataSet()
            myAdapter.SelectCommand = cmd

            If con.State = ConnectionState.Closed Then con.Open()
            myAdapter.Fill(ds, "BackOrderTest")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXBackOrders1
            MyReport.SetDataSource(ds)
            CRBackorderViewer.ReportSource = MyReport
        Else
            'Loads data into dataset for viewing
            ds = GDS

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXBackOrders1
            MyReport.SetDataSource(ds)
            CRBackorderViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Private Sub EmailBackorderListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailBackorderListingToolStripMenuItem.Click
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
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\BO-" & ConfirmName & ".pdf")

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
        mail.Subject = "Backorder Report"

        'adding body message information to the mail message
        mail.Body = "This is a Backorder Report from Truweld / TFP Corporation."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldPackList\BO-" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        Me.Close()
    End Sub

    Private Sub PrintBackOrdersFiltered_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GDS = Nothing
        GDS = New DataSet()
    End Sub
End Class