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
Public Class PrintAPPaymentBatch
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application

    'Variables for Date/Filename Creation
    Dim ConfirmName, strBatchNumber, strCompany As String

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cm5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalAPBatchNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRAPPaymentViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRAPPaymentViewer.Load
        'Load data into Dataset
        cmd = New SqlCommand("SELECT * FROM APProcessPaymentBatch  WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber

        'cmd1 = New SqlCommand("SELECT * FROM APVoucherTable WHERE BatchNumber = @BatchNumber", con)
        'cmd1.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber

        cmd2 = New SqlCommand("SELECT * FROM APCheckLog WHERE APBatchNumber = @APBatchNumber", con)
        cmd2.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APProcessPaymentBatch")

        'myAdapter1.SelectCommand = cmd1
        'myAdapter1.Fill(ds, "APVoucherTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "APCheckLog")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXAPPaymentBatch1
        MyReport.SetDataSource(ds)
        CRAPPaymentViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintAPPaymentBatch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalAPBatchNumber = 0
    End Sub

    Private Sub EmailPaymentBatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailPaymentBatchToolStripMenuItem.Click
        'Create new Filename for Pack List
        strBatchNumber = CStr(GlobalAPBatchNumber)
        strCompany = GlobalDivisionCode

        ConfirmName = strCompany + strBatchNumber

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldCustomerStatements\APBatch-" & ConfirmName & ".pdf")

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
        mail.Subject = "Truweld / Trufit AP Payment Batch"

        'adding body message information to the mail message
        mail.Body = "This is a Payment Batch from Truweld / TFP Corporation."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldCustomerStatements\APBatch-" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()

        Me.Close()
    End Sub
End Class