Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Outlook

Public Class PrintNafta
    Inherits System.Windows.Forms.Form

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

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

    Dim MyReportEmail = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Created Outlook Application object
    Dim OLApp As New Microsoft.Office.Interop.Outlook.Application


    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub CRNafta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRNafta.Load
        If GlobalNaftaPrintType = "INVOICE" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM ShipmentNaftaTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd2 = New SqlCommand("SELECT * FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey", con)
            cmd2.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey

            cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentNaftaTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "ShipmentNaftaLineTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "DivisionTable")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "CustomerList")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport2 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport2 = CRXNafta1
            MyReport2.SetDataSource(ds)
            CRNafta.ReportSource = MyReport2
            MyReportEmail = MyReport2
            con.Close()
        ElseIf GlobalNaftaPrintType = "NAFTA" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM ShipmentNaftaTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd2 = New SqlCommand("SELECT * FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey", con)
            cmd2.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey

            cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentNaftaTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "ShipmentNaftaLineTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "DivisionTable")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "CustomerList")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport3 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport3 = CRXNafta_20201
            MyReport3.SetDataSource(ds)
            CRNafta.ReportSource = MyReport3
            MyReportEmail = MyReport3
            con.Close()
        ElseIf GlobalNaftaPrintType = "AUTOPRINT" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM ShipmentNaftaTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd2 = New SqlCommand("SELECT * FROM ShipmentNaftaLineTable WHERE ShipmentNaftaKey = @ShipmentNaftaKey", con)
            cmd2.Parameters.Add("@ShipmentNaftaKey", SqlDbType.VarChar).Value = GlobalNaftaKey

            cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ShipmentNaftaTable")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "ShipmentNaftaLineTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "DivisionTable")

            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds, "CustomerList")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXNafta1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 1, 999)

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport1 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport1 = CRXNafta_20201
            MyReport1.SetDataSource(ds)
            MyReport1.PrintToPrinter(1, True, 1, 999)
            con.Close()

            Try
                Dim psi As New ProcessStartInfo

                psi.UseShellExecute = True
                psi.Verb = "print"
                psi.WindowStyle = ProcessWindowStyle.Hidden
                psi.CreateNoWindow = True
                'psi.Arguments = PrintDialog1.PrinterSettings.PrinterName.ToString()
                psi.FileName = "\\TFP-FS\TransferData\ExportedCerts\ELF.pdf"  ' Here specify a document to be printed
                Process.Start(psi)
            Catch ex As System.Exception
                'Error Check
                Dim TempNaftaKey As Integer = 0
                Dim strNaftaKey As String
                TempNaftaKey = GlobalNaftaKey
                strNaftaKey = CStr(TempNaftaKey)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = GlobalDivisionCode
                ErrorDescription = "Print Customs Ferrule Letter"
                ErrorReferenceNumber = "Shipment Nafta # " + strNaftaKey
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Ferrule Letter did not print.", MsgBoxStyle.OkOnly)
            End Try


            Me.Dispose()
            Me.Close()
        Else
            'Skip
        End If
    End Sub

    Private Sub PrintNafta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalNaftaPrintType = ""
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub EmailStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailStatementToolStripMenuItem.Click

        DeleteDirectory("\\TFP-FS\TransferData\Customer Credit Report\")

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

            ConfirmName = strCompany + EmailInvoiceCustomer

            'Export Document to Folder
            MyReportEmail.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\Customer Credit Report\" & ConfirmName & ".pdf")

            TFPMailFilename = ConfirmName + ".pdf"
            TFPMailFilename2 = ""
            TFPMailFilename3 = ""
            TFPMailFilePath = "\\TFP-FS\TransferData\Customer Credit Report\" & ConfirmName & ".pdf"
            TFPMailFilePath2 = ""
            TFPMailFilePath3 = ""
            TFPMailTransactionType = "Print Customer Statement"
            TFPMailTransactionNumber = 0
            TFPMailCustomer = ""

            Using NewEmailPage As New EmailPage
                Dim Result = NewEmailPage.ShowDialog()
            End Using
        Else

            'Create new Filename for Statement
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
            MyReportEmail.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\Customer Credit Report\" & ConfirmName & ".pdf")

            'creating outlook mailitem
            Dim mail As MailItem

            'creating newblank mail message
            mail = OLApp.CreateItem(OlItemType.olMailItem)

            'adding subject information to the mail message
            mail.Subject = "NAFTA/Customs Form"

            'Address Email To
            mail.To = "" 'CreditVariables.emailID

            'adding body message information to the mail message
            mail.Body = ""

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

    Private Sub ExitToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub OpenELFFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenELFFormToolStripMenuItem.Click
        Dim CashReceiptExists As String = "\\TFP-FS\TransferData\ExportedCerts\ELF.pdf"
        If File.Exists(CashReceiptExists) Then
            System.Diagnostics.Process.Start(CashReceiptExists)
        End If
    End Sub
End Class