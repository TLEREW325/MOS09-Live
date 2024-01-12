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
Public Class PrintCustomerReturn
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

    Private Sub CRReturnViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRReturnViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ReturnProductHeaderTable WHERE DivisionID = @DivisionID AND ReturnNumber = @ReturnNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = GlobalCustomerReturnNumber

        cmd1 = New SqlCommand("SELECT * FROM ReturnProductLineTable WHERE ReturnNumber = @ReturnNumber", con)
        cmd1.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = GlobalCustomerReturnNumber

        cmd2 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM AssemblySerialTempTable WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReturnProductHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ReturnProductLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "CustomerList")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "AssemblySerialTempTable")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXCustomerReturn1
        MyReport.SetDataSource(ds)
        CRReturnViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub EmailReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailReturnToolStripMenuItem.Click
        'Create new Filename for Cert
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
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldARBatch\TWReturn" & ConfirmName & ".pdf")

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
        mail.Subject = "TW Customer Return"

        'adding body message information to the mail message
        mail.Body = "This is an Return for an order placed with Truweld / TFP Corporation."

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldARBatch\TWReturn" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        Me.Close()
    End Sub
End Class