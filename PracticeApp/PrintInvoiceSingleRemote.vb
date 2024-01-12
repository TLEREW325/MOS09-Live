Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Threading
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintInvoiceSingleRemote
    Inherits System.Windows.Forms.Form

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim monthofyear, dayofyear, yearofyear, minuteofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany, strInvoiceNumber As String
    Dim LastNoteNumber, NextNoteNumber As Integer

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=45")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10, cmd11 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalInvoiceNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRInvoiceViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRInvoiceViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
        cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalInvoiceNumber

        cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND InvoiceHeaderKey = @InvoiceHeaderKey", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd1.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = GlobalInvoiceNumber

        cmd2 = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd4.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd5 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
        cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd8 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
        cmd8.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd9 = New SqlCommand("SELECT * FROM InvoiceLotLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
        cmd9.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalInvoiceNumber

        cmd10 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable WHERE InvoiceNumber = @InvoiceNumber", con)
        cmd10.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalInvoiceNumber

        cmd11 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionID", con)
        cmd11.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceLineQuery")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "ShipmentHeaderTable")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "DivisionTable")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "CustomerList")

        myAdapter6.SelectCommand = cmd6
        myAdapter6.Fill(ds, "AdditionalShipTo")

        myAdapter8.SelectCommand = cmd8
        myAdapter8.Fill(ds, "ARCustomerPayment")

        myAdapter9.SelectCommand = cmd9
        myAdapter9.Fill(ds, "InvoiceLotLineTable")

        myAdapter10.SelectCommand = cmd10
        myAdapter10.Fill(ds, "InvoiceSerialLineTable")

        myAdapter11.SelectCommand = cmd11
        myAdapter11.Fill(ds, "SalesOrderHeaderTable")

        'Sets up viewer to display data from the loaded dataset
        If GlobalDivisionCode = "TWD" Then
            MyReport = CRXInvoice1
            MyReport.SetDataSource(ds)
            CRInvoiceViewer.ReportSource = MyReport
            con.Close()
        ElseIf GlobalDivisionCode = "TFF" Then
            MyReport = CRXInvoiceTFF1
            MyReport.SetDataSource(ds)
            CRInvoiceViewer.ReportSource = MyReport
            con.Close()
        ElseIf GlobalDivisionCode = "TOR" Then
            MyReport = CRXInvoiceTFF1
            MyReport.SetDataSource(ds)
            CRInvoiceViewer.ReportSource = MyReport
            con.Close()
        ElseIf GlobalDivisionCode = "ALB" Then
            MyReport = CRXInvoiceTFF1
            MyReport.SetDataSource(ds)
            CRInvoiceViewer.ReportSource = MyReport
            con.Close()
        Else
            MyReport = CRXInvoice1
            MyReport.SetDataSource(ds)
            CRInvoiceViewer.ReportSource = MyReport
            con.Close()
        End If

        strInvoiceNumber = CStr(GlobalInvoiceNumber)
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & GlobalDivisionCode & strInvoiceNumber & ".pdf")

        'Create new Filename for Invoice
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

        ConfirmName = strCompany + strInvoiceNumber + strMonth + strDay + strYear
    End Sub

    Private Sub EmailInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailInvoiceToolStripMenuItem.Click
        'Create new Filename for Invoice
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

        Try
            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & ConfirmName & ".pdf")
        Catch ex As Exception
            'Create new Filename for Invoice
            FileDate = Now()
            monthofyear = FileDate.Month
            dayofyear = FileDate.DayOfYear
            yearofyear = FileDate.Year
            minuteofyear = FileDate.Minute + 1
            strMonth = CStr(monthofyear)
            strDay = CStr(dayofyear)
            strYear = CStr(yearofyear)
            strMinute = CStr(minuteofyear)
            strCompany = GlobalDivisionCode

            ConfirmName = strCompany + strMonth + strDay + strYear + strMinute

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & ConfirmName & ".pdf")
        End Try

        TFPMailFilename = ConfirmName + ".pdf"
        TFPMailFilename2 = ""
        TFPMailFilename3 = ""
        TFPMailFilePath = "\\TFP-FS\TransferData\TruweldInvoices\" & ConfirmName & ".pdf"
        TFPMailFilePath2 = ""
        TFPMailFilePath3 = ""
        TFPMailTransactionType = "Print Invoice Single"
        TFPMailTransactionNumber = GlobalInvoiceNumber
        TFPMailCustomer = EmailInvoiceCustomer

        Using NewEmailPage As New EmailPage
            Dim Result = NewEmailPage.ShowDialog()
        End Using

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintInvoiceSingle_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        EmailInvoiceNumber = 0
        EmailSalesOrderNumber = 0
        EmailShipmentNumber = 0
        EmailInvoiceCustomer = ""
        EmailCustomerEmailAddress = ""
        EmailStringInvoiceNumber = ""
        GlobalInvoiceNumber = 0
    End Sub
End Class