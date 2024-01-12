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
Public Class PrintTWCert01
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim MyReport2 = New CrystalDecisions.CrystalReports.Engine.ReportDocument

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
        GlobalShipmentNumber = 0
        GlobalPrintNoCertPage = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRCertViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCertViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * from TruweldCertData where ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

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

        If GlobalDivisionCode = "TWD" And GlobalCompleteShipment = "COMPLETE SHIPMENT" Then
            If GlobalPrintNoCertPage = "YES" Then
                cmd = New SqlCommand("SELECT * from ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

                If con.State = ConnectionState.Closed Then con.Open()
                ds2 = New DataSet()

                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds2, "ShipmentHeaderTable")

                MyReport2 = CRXTruweldNOCERT1
                MyReport2.SetDataSource(ds2)
                MyReport2.PrintToPrinter(1, True, 1, 999)
                con.Close()
            Else
                'Skip
            End If

            MyReport = CRXTWCert011
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 1, 999)
            con.Close()

            Me.Close()

            GlobalCompleteShipment = ""
        Else
            If GlobalPrintNoCertPage = "YES" Then
                cmd = New SqlCommand("SELECT * from ShipmentHeaderTable WHERE ShipmentNumber = @ShipmentNumber", con)
                cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

                If con.State = ConnectionState.Closed Then con.Open()
                ds2 = New DataSet()

                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds2, "ShipmentHeaderTable")

                MyReport2 = CRXTruweldNOCERT1
                MyReport2.SetDataSource(ds2)
                MyReport2.PrintToPrinter(1, True, 1, 999)
                con.Close()
            Else
                'Skip
            End If

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXTWCert011
            MyReport.SetDataSource(ds)
            CRCertViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Public Sub CreateAppointmentRecord()
        Dim Appointment As AppointmentItem
        Dim Task As TaskItem
        Dim strShipmentNumber As String = ""

        strShipmentNumber = CStr(GlobalShipmentNumber)

        Appointment = OLApp.CreateItem(OlItemType.olAppointmentItem)
        Task = OLApp.CreateItem(OlItemType.olTaskItem)

        Task.Body = "TW Certs for Shipment # " & strShipmentNumber & " sent to " & GlobalCertCustomer
        Task.Subject = "TW Certs - " & GlobalCertCustomer
        Task.StartDate = Today()
        Task.DueDate = Today()
        Task.ReminderPlaySound = True
        Task.Importance = OlImportance.olImportanceHigh
        Task.Save()

        Appointment.Start = Today() & " 8:00AM"
        Appointment.End = Today() & " 5:00PM"
        Appointment.Location = "TW Certs Sent"
        Appointment.Body = "TW Certs for Shipment # " & strShipmentNumber & " sent to " & GlobalCertCustomer
        Appointment.Subject = GlobalCertCustomer & " / " & strShipmentNumber
        Appointment.AllDayEvent = False

        Appointment.Save()
    End Sub

    Private Sub AddToAppointmentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToAppointmentsToolStripMenuItem.Click
        CreateAppointmentRecord()
    End Sub

    Private Sub EmailCertToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailCertToolStripMenuItem1.Click
        'Create Subject line for invoice
        Dim strInvoiceNumber As String = ""
        strInvoiceNumber = CStr(GlobalInvoiceNumber)

        'Create new Filename for Cert
        Dim strShipmentNumber As String = ""
        strShipmentNumber = CStr(GlobalShipmentNumber)

        CertName = " Shipment #" + strShipmentNumber

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\ExportedCerts\" + GlobalDivisionCode + "\" + GlobalCertCustomer + CertName + ".pdf")

        If GlobalPrintNoCertPage = "YES" Then
            MyReport2.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\ExportedCerts\NO-CERT.pdf")
        Else
            'Skip
        End If

        'creating outlook mailitem
        Dim mail As MailItem

        'creating newblank mail message
        mail = OLApp.CreateItem(OlItemType.olMailItem)

        'Get invoice email address
        mail.To = EmailCustomerEmailAddress

        'adding subject information to the mail message
        mail.Subject = "Customer Cert -- " + GlobalCertCustomer + " Inv. #" + strInvoiceNumber

        'adding body message information to the mail message
        mail.Body = "Truweld Certs Attached for Shipment # " + strShipmentNumber

        'adding attachment
        If GlobalPrintNoCertPage = "YES" Then
            mail.Attachments.Add("\\TFP-FS\TransferData\ExportedCerts\NO-CERT.pdf")
        End If

        mail.Attachments.Add("\\TFP-FS\TransferData\ExportedCerts\" + GlobalDivisionCode + "\" + GlobalCertCustomer + CertName + ".pdf")

        'display mail
        mail.Display()

        Me.Close()
    End Sub

    Private Sub PrintTWCert01_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalShipmentNumber = 0
        GlobalCertCustomer = ""
        GlobalPrintNoCertPage = ""
    End Sub

    Private Sub PrintTWCert01_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPrintNoCertPage = "NO"
    End Sub
End Class