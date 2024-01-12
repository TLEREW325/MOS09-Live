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

Public Class PrintInvoiceTotalNoFerrules
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim LastNoteNumber, NextNoteNumber As Integer

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Created Outlook Application object
    Dim OLApp As New Microsoft.Office.Interop.Outlook.Application

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRDailyViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles CRDailyViewer.Load
        Dim DateFilter As String = ""

        If NoFerrulesInvoiceDivision.DateCheck = False Then
            DateFilter = ""
        Else
            DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        End If


        If NoFerrulesInvoiceDivision.Division = "ADM" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE Price = @Total AND ItemClass != @FERRULE" + DateFilter, con)
            cmd.Parameters.Add("@Total", SqlDbType.VarChar).Value = 0
            cmd.Parameters.Add("@FERRULE", SqlDbType.VarChar).Value = "FERRULE"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = NoFerrulesInvoiceDivision.BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = NoFerrulesInvoiceDivision.EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceLineQuery")

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXInvoiceListingNoFerrule1
            MyReport.SetDataSource(ds)
            CRDailyViewer.ReportSource = MyReport
            con.Close()
        Else

            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND Price = @Total AND ItemClass != @FERRULE" + DateFilter, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = NoFerrulesInvoiceDivision.Division
            cmd.Parameters.Add("@Total", SqlDbType.VarChar).Value = 0
            cmd.Parameters.Add("@FERRULE", SqlDbType.VarChar).Value = "FERRULE"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = NoFerrulesInvoiceDivision.BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = NoFerrulesInvoiceDivision.EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceLineQuery")

            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXInvoiceListingNoFerrule1
            MyReport.SetDataSource(ds)
            CRDailyViewer.ReportSource = MyReport
            con.Close()
        End If

    End Sub

    Private Sub EmailInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailInvoiceToolStripMenuItem.Click
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

        strCompany = NoFerrulesInvoiceDivision.Division
        'DeleteDirectory("\\TFP-FS\TransferData\Customer Credit Report\")

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

            ConfirmName = strCompany + strMonth + strDay + strYear + strMinute

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TEST\" & ConfirmName & ".pdf")

            TFPMailFilename = ConfirmName + ".pdf"
            TFPMailFilename2 = ""
            TFPMailFilename3 = ""
            TFPMailFilePath = "\\TFP-FS\TransferData\TEST\" & ConfirmName & ".pdf"
            TFPMailFilePath2 = ""
            TFPMailFilePath3 = ""
            TFPMailTransactionType = "Print No Ferrules"
            TFPMailTransactionNumber = 0
            TFPMailCustomer = ""

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
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TEST\" & ConfirmName & ".pdf")

            'creating outlook mailitem
            Dim mail As MailItem

            'creating newblank mail message
            mail = OLApp.CreateItem(OlItemType.olMailItem)

            'adding subject information to the mail message
            mail.Subject = ""

            'Address Email To
            mail.To = ""

            'adding body message information to the mail message
            mail.Body = ""

            'adding attachment
            Try
                mail.Attachments.Add("\\TFP-FS\TransferData\TEST\" & ConfirmName & ".pdf")
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
Public Class NoFerrulesInvoiceDivision
    Public Shared Division As String = ""
    Public Shared BeginDate As Date
    Public Shared EndDate As Date
    Public Shared DateCheck As Boolean
End Class

