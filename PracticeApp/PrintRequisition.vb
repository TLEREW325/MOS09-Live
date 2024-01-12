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
Public Class PrintRequisition
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRReqViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRReqViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * from RequisitionEntry where RequisitionNumber = @RequisitionNumber", con)
        cmd.Parameters.Add("@RequisitionNumber", SqlDbType.VarChar).Value = GlobalRequisitionNumber

        cmd1 = New SqlCommand("SELECT * from Vendor where DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * from DivisionTable where DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RequisitionEntry")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "Vendor")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXRequisition1
        MyReport.SetDataSource(ds)
        CRReqViewer.ReportSource = MyReport
        con.Close()

        'Create new Filename for Requisition
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
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPOs\REQ-" & ConfirmName & ".pdf")

    End Sub

    Private Sub EmailRequisitionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailRequisitionToolStripMenuItem.Click
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
        mail.Subject = "Truweld / Trufit Requisition"

        'adding body message information to the mail message
        mail.Body = "This is a Requisition from Truweld / TFP Corporation."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldPOs\REQ-" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()
    End Sub
End Class