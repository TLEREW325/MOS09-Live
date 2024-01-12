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

Public Class PrintCustomerCredit
    Inherits System.Windows.Forms.Form

    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim divisionid As String = CreditVariables.DivisionID
    Dim customerid As String = CreditVariables.customerID
    'Dim dt As DataTable

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim LastNoteNumber, NextNoteNumber As Integer

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Created Outlook Application object
    Dim OLApp As New Microsoft.Office.Interop.Outlook.Application

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXCustomerCredit1
            MyReport.SetDataSource(GDS3)
            CRXCustomerCredit1 = MyReport
            CRXCustomerCredit1.SetParameterValue("AvgDays", GlobalVariables.Counter.ToString)

            GlobalVariables.Counter = 0

            con.Close()


            
        Catch ex As System.Exception

        End Try
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub EmailStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailStatementToolStripMenuItem.Click
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

        DeleteDirectory("\\TFP-FS\TransferData\Customer Credit Report\")

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

            ConfirmName = strCompany + EmailInvoiceCustomer

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\Customer Credit Report\" & ConfirmName & ".pdf")

            TFPMailFilename = ConfirmName + ".pdf"
            TFPMailFilename2 = ""
            TFPMailFilename3 = ""
            TFPMailFilePath = "\\TFP-FS\TransferData\Customer Credit Report\" & ConfirmName & ".pdf"
            TFPMailFilePath2 = ""
            TFPMailFilePath3 = ""
            TFPMailTransactionType = "Print Customer Statement"
            TFPMailTransactionNumber = 0
            TFPMailCustomer = CreditVariables.emailID

            Using NewEmailPage As New EmailPage
                Dim Result = NewEmailPage.ShowDialog()
            End Using
        Else

            'Create new Filename for Statement
            FileDate = Now()
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
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\Customer Credit Report\" & ConfirmName & ".pdf")

            'creating outlook mailitem
            Dim mail As MailItem

            'creating newblank mail message
            mail = OLApp.CreateItem(OlItemType.olMailItem)

            'adding subject information to the mail message
            mail.Subject = "Customer Credit Statement For " + CreditVariables.emailName

            'Address Email To
            mail.To = CreditVariables.emailID

            'adding body message information to the mail message
            mail.Body = "This is a Credit Customer Report for " & CreditVariables.emailName & "."

            'adding attachment
            Try
                mail.Attachments.Add("\\TFP-FS\TransferData\Customer Credit Report\" & ConfirmName & ".pdf")
            Catch ex As System.Exception

            End Try

            'display mail
            mail.Display()

            Me.Close()
        End If
    End Sub

    Private Sub DeleteDirectory(ByVal path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
        End If
    End Sub
End Class

Public Class CreditVariables
    Public Shared CustomerID As String = ""
    Public Shared DivisionID As String = ""
    Public Shared emailID As String = ""
    Public Shared emailName As String = ""
End Class