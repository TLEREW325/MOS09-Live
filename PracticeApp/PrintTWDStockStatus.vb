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
Public Class PrintTWDStockStatus
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
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub CRStockViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRStockViewer.Load
        If GlobalItemClass = "" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT ItemClass, ItemID, ShortDescription, DivisionID, QuantityOnHand, OpenSOQuantity FROM ADMInventoryTotal WHERE DivisionID = @DivisionID AND ItemClass LIKE 'TW%' AND (QuantityOnHand <> 0 OR OpenSOQuantity <> 0) ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT ItemClass, ItemID, ShortDescription, DivisionID, QuantityOnHand, OpenSOQuantity FROM ADMInventoryTotal WHERE DivisionID = @DivisionID AND ItemClass = @ItemClass AND (QuantityOnHand <> 0 OR OpenSOQuantity <> 0) ORDER BY ItemID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = GlobalItemClass
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ADMInventoryTotal")

        If GlobalPrintWithoutCommitted = "YES" Then
            MyReport = CRXTWDStockStatusWOC1
        Else
            MyReport = CRXTWDStockStatus1
        End If

        MyReport.SetDataSource(ds)
        CRStockViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintTWDStockStatus_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalItemClass = ""
        GlobalPrintWithoutCommitted = ""
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalItemClass = ""
        GlobalPrintWithoutCommitted = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub EmailReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailReportToolStripMenuItem.Click
        'Create new Filename for Inventory Report
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

        'Create new Filename for Report
        ConfirmName = GlobalDivisionCode + "INV" + strDay + strMonth + strYear + strMinute

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\InventoryReport\" & ConfirmName & ".pdf")

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
        mail.Subject = "TWD Inventory Report"

        'adding body message information to the mail message
        mail.Body = "This is a stock status report for TWD Inventory"

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\InventoryReport\" + ConfirmName + ".pdf")

        'display mail
        mail.Display()

        Me.Close()
    End Sub
End Class