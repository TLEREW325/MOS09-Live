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
Public Class ReprintCert
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim CertName, ReprintPartNumber, strCompany As String

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub EmailCertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailCertToolStripMenuItem.Click
        'Get Login Type
        Dim GetLoginType As String = ""

        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetLoginType = ""
        End Try
        con.Close()

        If GetLoginType = "REMOTE" Then
            'Create new Filename for Sales Confirmation
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

            ConfirmName = strCompany + CertName

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldPackList\" & ConfirmName & ".pdf")

            TFPMailFilename = ConfirmName + ".pdf"
            TFPMailFilename2 = ""
            TFPMailFilename3 = ""
            TFPMailFilePath = "\\TFP-FS\TransferData\TruweldPackList\" & ConfirmName & ".pdf"
            TFPMailFilePath2 = ""
            TFPMailFilename3 = ""
            TFPMailCustomer = ""
            TFPMailTransactionType = "Print Cert From Lot"
            TFPMailTransactionNumber = 0

            Using NewEmailPage As New EmailPage
                Dim Result = NewEmailPage.ShowDialog()
            End Using
        Else

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldCerts\" & CertName & ".pdf")

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
            mail.Subject = "TW Cert"

            'adding body message information to the mail message
            mail.Body = "This is an Certification for part manufactured by Truweld / TFP Corporation."

            'adding attachment
            mail.Attachments.Add("\\TFP-FS\TransferData\TruweldCerts\" & CertName & ".pdf")

            'display mail
            mail.Display()

            'sending mail
            'mail.Send()
        End If
    End Sub

    Private Sub CRCertViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCertViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM CertificationData WHERE HeatNumber = @HeatNumber AND TestNumber = @TestNumber AND LotNumber = @LotNumber", con)
        cmd.Parameters.Add("@HeatNumber", SqlDbType.VarChar).Value = GlobalReprintHeatNumber
        cmd.Parameters.Add("@TestNumber", SqlDbType.VarChar).Value = GlobalReprintPullTestNumber
        cmd.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = GlobalReprintLotNumber

        ''cmd1 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        ''cmd1.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd1 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = 'TWD'", con)

        cmd2 = New SqlCommand("SELECT * FROM CertificationType", con)

        cmd3 = New SqlCommand("SELECT * FROM PullTestLineTable WHERE PullTestNumber = @PullTestNumber", con)
        cmd3.Parameters.Add("@PullTestNumber", SqlDbType.VarChar).Value = GlobalReprintPullTestNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CertificationData")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "DivisionTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "CertificationType")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "PullTestLineTable")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXTWCertReprint1
        MyReport.SetDataSource(ds)
        CRCertViewer.ReportSource = MyReport
        con.Close()

        'Create new Filename for Cert

        'Get Part number based on Lot Number
        Dim GetPartNumberString As String = "SELECT PartNumber FROM LotNumber WHERE LotNumber = @LotNumber"
        Dim GetPartNumberCommand As New SqlCommand(GetPartNumberString, con)
        GetPartNumberCommand.Parameters.Add("@LotNumber", SqlDbType.VarChar).Value = GlobalReprintLotNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ReprintPartNumber = CStr(GetPartNumberCommand.ExecuteScalar)
        con.Close()

        strCompany = GlobalDivisionCode

        CertName = strCompany + " " + GlobalReprintHeatNumber + " " + ReprintPartNumber
    End Sub

    Private Sub ReprintCert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class