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
Public Class PrintTFAcknowledgement
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalSONumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRTrufitViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRTrufitViewer.Load
        If GlobalTFPSOPrintForm = "TFP Acknowledgement" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * from SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey", con)
            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber

            cmd1 = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey", con)
            cmd1.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID AND FOXNumber = @FOXNumber", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd4.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = GlobalFOXNumber

            cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd6 = New SqlCommand("SELECT * FROM FoxReleaseSchedule WHERE FOXNumber = @FOXNumber", con)
            cmd6.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = GlobalFOXNumber

            cmd7 = New SqlCommand("SELECT * FROM SalesOrderQuantityStatus WHERE DivisionKey = @DivisionKey", con)
            cmd7.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd8 = New SqlCommand("SELECT * FROM CustomerContacts", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "SalesOrderHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "SalesOrderLineTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "DivisionTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "CustomerList")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "FoxTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "AdditionalShipTo")

            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "FoxReleaseSchedule")

            myAdapter7.SelectCommand = cmd7
            myAdapter7.Fill(ds, "SalesOrderQuantityStatus")

            myAdapter8.SelectCommand = cmd8
            myAdapter8.Fill(ds, "CustomerContacts")

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXTFAcknowledgement1
            MyReport.SetDataSource(ds)
            CRTrufitViewer.ReportSource = MyReport
            con.Close()
        ElseIf GlobalTFPSOPrintForm = "TFP NOR Letter" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * from SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey", con)
            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber

            cmd1 = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey", con)
            cmd1.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID AND FOXNumber = @FOXNumber", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd4.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = GlobalFOXNumber

            cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd6 = New SqlCommand("SELECT * FROM FoxReleaseSchedule WHERE FOXNumber = @FOXNumber", con)
            cmd6.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = GlobalFOXNumber

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "SalesOrderHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "SalesOrderLineTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "DivisionTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "CustomerList")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "FoxTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "AdditionalShipTo")

            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "FoxReleaseSchedule")

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXTFNORletter1
            MyReport.SetDataSource(ds)
            CRTrufitViewer.ReportSource = MyReport
            con.Close()
        ElseIf GlobalTFPSOPrintForm = "TFP FOX FORM" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * from SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey", con)
            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID AND FOXNumber = @FOXNumber", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd4.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = GlobalFOXNumber

            cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd6 = New SqlCommand("SELECT * FROM FoxReleaseSchedule WHERE FOXNumber = @FOXNumber", con)
            cmd6.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = GlobalFOXNumber

            cmd7 = New SqlCommand("SELECT * FROM SalesOrderQuantityStatus WHERE DivisionKey = @DivisionKey", con)
            cmd7.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd8 = New SqlCommand("SELECT * FROM CustomerContacts WHERE ContactDepartment = 'PURCHASING'", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "SalesOrderHeaderTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "DivisionTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "CustomerList")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "FoxTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "AdditionalShipTo")

            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "FoxReleaseSchedule")

            myAdapter7.SelectCommand = cmd7
            myAdapter7.Fill(ds, "SalesOrderQuantityStatus")

            myAdapter8.SelectCommand = cmd8
            myAdapter8.Fill(ds, "CustomerContacts")

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXTFPFOX1
            MyReport.SetDataSource(ds)
            CRTrufitViewer.ReportSource = MyReport
            con.Close()
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * from SalesOrderHeaderTable WHERE SalesOrderKey = @SalesOrderKey", con)
            cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber

            cmd1 = New SqlCommand("SELECT * FROM SalesOrderLineTable WHERE SalesOrderKey = @SalesOrderKey", con)
            cmd1.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM FoxTable WHERE DivisionID = @DivisionID AND FOXNumber = @FOXNumber", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd4.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = GlobalFOXNumber

            cmd5 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd6 = New SqlCommand("SELECT * FROM FoxReleaseSchedule WHERE FOXNumber = @FOXNumber", con)
            cmd6.Parameters.Add("@FOXNumber", SqlDbType.Int).Value = GlobalFOXNumber

            cmd7 = New SqlCommand("SELECT * FROM SalesOrderQuantityStatus WHERE DivisionKey = @DivisionKey", con)
            cmd7.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "SalesOrderHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "SalesOrderLineTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "DivisionTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "CustomerList")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "FoxTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "AdditionalShipTo")

            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "FoxReleaseSchedule")

            myAdapter7.SelectCommand = cmd7
            myAdapter7.Fill(ds, "SalesOrderQuantityStatus")

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXTFAcknowledgement1
            MyReport.SetDataSource(ds)
            CRTrufitViewer.ReportSource = MyReport
            con.Close()
        End If

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
    End Sub

    Private Sub EmailAcknowledgementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailAcknowledgementToolStripMenuItem.Click
        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\SalesConfirmations\SA-" & ConfirmName & ".pdf")

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
        mail.Subject = "Sales Acknowledgement"

        'adding body message information to the mail message
        mail.Body = "This is a Sales Acknowledgement from Truweld / TFP Corporation."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\SalesConfirmations\SA-" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        'sending mail
        'mail.Send()
    End Sub

    Private Sub PrintTFAcknowledgement_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalTFPSOPrintForm = ""
        GlobalSONumber = 0
    End Sub
End Class