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
Public Class PrintShotScreening
    Inherits System.Windows.Forms.Form


    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim NextNoteNumber, LastNoteNumber As Integer
    Dim strInvoiceNumber As String = ""

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument


    'Created Outlook Application object
    Dim OLApp As New Microsoft.Office.Interop.Outlook.Application

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub PrintShotScreening_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalGroupByPartNumber = ""
        GlobalGroupByItemClass = ""
        GlobalGroupByMonth = ""
        GlobalGroupByCustomer = ""
        GlobalGroupBySubtotal = ""
        GlobalGroupByAll = ""
        GlobalSteelOrderPartNumber = ""
        GlobalSteelOrderRMID = ""
        GlobalSteelOrderCarbon = ""
        GlobalSteelOrderSteelSize = ""
        GlobalSteelOrderSteelDescription = ""
        GlobalShipmentPrintType = ""
        GlobalAutoPrintPackingList = ""
        GlobalSteelReturnCarbon = ""
        GlobalSteelReturnSize = ""
        GlobalNoAutoPrintCheckRemittance = ""
        GlobalAPRemittanceEmail = ""
        GlobalCustomerCreditAPP = ""
        GlobalAPPFPCheckBox = ""
        GlobalTraineeCompany = ""
        GlobalNaftaDate = ""
        GlobalNaftaCustomerID = ""
        GlobalNaftaPrintType = ""
        GlobalNAFTAShipDate = ""
        GlobalTraineeName = ""
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        MyReport = CRXShotScreen2
        MyReport.SetDataSource(GDS)
        CRXShotScreen2.SetParameterValue("North104P", GlobalSteelOrderCarbon)
        CRXShotScreen2.SetParameterValue("North96P", GlobalSteelReturnSize)
        CRXShotScreen2.SetParameterValue("North95P", GlobalAutoPrintPackingList)
        CRXShotScreen2.SetParameterValue("North100P", GlobalSteelOrderPartNumber)
        CRXShotScreen2.SetParameterValue("North94P", GlobalSteelOrderSteelDescription)
        CRXShotScreen2.SetParameterValue("South104P", GlobalSteelOrderSteelSize)
        CRXShotScreen2.SetParameterValue("South96P", GlobalNoAutoPrintCheckRemittance)
        CRXShotScreen2.SetParameterValue("South95P", GlobalSteelReturnCarbon)
        CRXShotScreen2.SetParameterValue("South100P", GlobalSteelOrderRMID)
        CRXShotScreen2.SetParameterValue("South94P", GlobalShipmentPrintType)
        CRXShotScreen2.SetParameterValue("Wheel1P", GlobalGroupByPartNumber)
        CRXShotScreen2.SetParameterValue("Wheel2P", GlobalGroupByItemClass)
        CRXShotScreen2.SetParameterValue("Wheel3P", GlobalGroupByMonth)
        CRXShotScreen2.SetParameterValue("Wheel4P", GlobalGroupByCustomer)
        CRXShotScreen2.SetParameterValue("Wheel5P", GlobalGroupBySubtotal)
        CRXShotScreen2.SetParameterValue("Wheel6P", GlobalGroupByAll)
        CRXShotScreen2.SetParameterValue("avgNorthP", GlobalCustomerCreditAPP)
        CRXShotScreen2.SetParameterValue("avgSouthP", GlobalAPPFPCheckBox)
        CRXShotScreen2.SetParameterValue("avgWheelP", GlobalAPRemittanceEmail)
        CRXShotScreen2.SetParameterValue("Wheel1d", GlobalTraineeCompany)
        CRXShotScreen2.SetParameterValue("Wheel2d", GlobalNaftaDate)
        CRXShotScreen2.SetParameterValue("Wheel3d", GlobalNaftaCustomerID)
        CRXShotScreen2.SetParameterValue("Wheel4d", GlobalNaftaPrintType)
        CRXShotScreen2.SetParameterValue("Wheel5d", GlobalNAFTAShipDate)
        CRXShotScreen2.SetParameterValue("Wheel6d", GlobalTraineeName)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub DeleteDirectory(ByVal path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
        End If
    End Sub

    Private Sub EmailAuthorizationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailAuthorizationToolStripMenuItem.Click
        'Get Login Type
        'viewer()
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

        DeleteDirectory("\\TFP-FS\TransferData\Test")
        If Not System.IO.Directory.Exists("\\TFP-FS\TransferData\Test") Then System.IO.Directory.CreateDirectory("\\TFP-FS\TransferData\Test")
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

            ConfirmName = monthofyear.ToString + strMinute.ToString + strCompany.ToString + "SHOTReport"

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf")

            TFPMailFilename = ConfirmName + ".pdf"
            TFPMailFilename2 = ""
            TFPMailFilename3 = ""
            TFPMailFilePath = "\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf"
            TFPMailFilePath2 = ""
            TFPMailFilePath3 = ""
            TFPMailTransactionType = "Return Goods Authorization Form"
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

            ConfirmName = monthofyear.ToString + strMinute.ToString + strCompany.ToString + "SHOTReport"

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf")

            'creating outlook mailitem
            Dim mail As MailItem

            'creating newblank mail message
            mail = OLApp.CreateItem(OlItemType.olMailItem)

            'adding subject information to the mail message
            mail.Subject = "Shot Report"

            'Address Email To
            mail.To = ""

            'adding body message information to the mail message
            mail.Body = ""

            'adding attachment
            Try
                mail.Attachments.Add("\\TFP-FS\TransferData\Test\" & ConfirmName & ".pdf")
            Catch ex As System.Exception

            End Try

            'display mail
            mail.Display()

            Me.Close()
        End If
    End Sub

End Class