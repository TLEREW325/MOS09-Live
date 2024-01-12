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

Public Class PrintCanamSales
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
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRCanamSalesViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CanamSalesViewer1.Load
        If GlobalDivisionCode = "ADM" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderQuery", con)

            cmd2 = New SqlCommand("SELECT * FROM ShipmentHeaderTable", con)

            cmd3 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE QuantityBilled <> '0'", con)


            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceHeaderQuery")


            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "ShipmentHeaderTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "InvoiceLineQuery")


            'Sets up viewer to display data from the loaded dataset

            MyReport = CRXCanamSales1
            MyReport.SetDataSource(ds)
            CanamSalesViewer1.ReportSource = MyReport
            con.Close()
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode



            cmd2 = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND QuantityBilled <> '0'", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode



            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceHeaderQuery")


            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "ShipmentHeaderTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "InvoiceLineQuery")


            'Sets up viewer to display data from the loaded dataset

            MyReport = CRXCanamSales1
            MyReport.SetDataSource(ds)
            CanamSalesViewer1.ReportSource = MyReport
            con.Close()
        End If

    End Sub



    Private Sub CanamSalesViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CanamSalesViewer1.Load

    End Sub

    Private Sub EmailReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailReturnToolStripMenuItem.Click
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
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldBOL\CanamSales" & ConfirmName & ".pdf")

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
        mail.Subject = "Canam Sales"

        'adding body message information to the mail message
        'mail.Body = "This is a BOL for a Shipment from Truweld / TFP Corporation."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldBOL\CanamSales" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()

        Me.Close()
    End Sub
End Class