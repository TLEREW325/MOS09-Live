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
Public Class PrintTWCertSingle
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim CertName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim ConfirmName As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        CertShipmentNumber = 0
        CertHeatNumber = ""
        CertLotNumber = ""
        CertPartNumber = ""
        CertCustomerID = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRCertViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCertViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * from TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = CertShipmentNumber
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = CertLotNumber

        cmd1 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable", con)

        cmd3 = New SqlCommand("SELECT * FROM PullTestLineTable WHERE PullTestLineNumber < 3", con)

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "TruweldCertData")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "CustomerList")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "PullTestLineTable")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXTWCert011
        MyReport.SetDataSource(ds)
        CRCertViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub EmailCertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailCertToolStripMenuItem.Click
        'Create new Filename for Cert
        Dim strShipmentNumber As String = ""
        strShipmentNumber = CStr(CertShipmentNumber)

        CertName = strShipmentNumber + " " + CertHeatNumber + " " + CertPartNumber

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldCerts\" + CertName + ".pdf")

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
        mail.Subject = "Customer Cert -- " + CertCustomerID

        'adding body message information to the mail message
        mail.Body = "Truweld Cert Attached for Shipment # " + strShipmentNumber + "  Part # -- " + CertPartNumber + "  Heat # -- " + CertHeatNumber

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldCerts\" + CertName + ".pdf")

        'display mail
        mail.Display()

        Me.Close()
    End Sub

    Private Sub PrintTWCertSingle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CertShipmentNumber = 0
        CertHeatNumber = ""
        CertLotNumber = ""
        CertPartNumber = ""
        CertCustomerID = ""
    End Sub
End Class