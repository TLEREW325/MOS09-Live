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
Public Class PrintStudweldingCerticate
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim CertName As String = ""
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim FileDate As Date

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalStudweldingBatchNumber = 0
        GlobalStudweldingBatchPrinting = ""
        GlobalTraineeCompany = ""
        GlobalTraineeName = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRCertificateViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCertificateViewer.Load
        If GlobalStudweldingBatchPrinting = "YES" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM StudweldingCertification WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalStudweldingBatchNumber
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM StudweldingCertification WHERE DivisionID = @DivisionID AND IndividualName = @IndividualName AND CompanyName = @CompanyName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@IndividualName", SqlDbType.VarChar).Value = GlobalTraineeName
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = GlobalTraineeCompany
        End If

        cmd1 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd1.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "StudweldingCertification")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXStudWeldingCertificate1
        MyReport.SetDataSource(ds)
        CRCertificateViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub EmailCertificateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailCertificateToolStripMenuItem.Click
        'Create new Filename for Cert
        If GlobalStudweldingBatchPrinting = "YES" Then
            CertName = "Studwelding Certificate Batch"
        Else
            CertName = "TruweldCertification (" + GlobalTraineeName + ")"
        End If

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\StudweldingCerts\" + CertName + ".pdf")

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
        mail.Subject = "Truweld Studwelding Certificate"

        'adding body message information to the mail message
        mail.Body = "Truweld Studwelding Certificate"

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\StudweldingCerts\" + CertName + ".pdf")

        'display mail
        mail.Display()

        Me.Close()
    End Sub

    Private Sub PrintStudweldingCerticate_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalStudweldingBatchNumber = 0
        GlobalStudweldingBatchPrinting = ""
        GlobalTraineeCompany = ""
        GlobalTraineeName = ""
    End Sub
End Class