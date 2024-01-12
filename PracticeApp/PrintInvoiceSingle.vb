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
Imports Microsoft.Office.Interop.Outlook
Public Class PrintInvoiceSingle
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Public Shared Function CoWaitForMultipleHandles(ByVal dwFlags As Int32, _
    'ByVal dwTimeout As Int32, ByVal cHandles As Int32, ByVal pHandles() As IntPtr, _
    'ByRef lpdwindex As Int32) As Int32
    'End Function

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
        strInvoiceNumber = CStr(GlobalInvoiceNumber)
        strMonth = CStr(monthofyear)
        strDay = CStr(dayofyear)
        strYear = CStr(yearofyear)
        strCompany = GlobalDivisionCode

        ConfirmName = strCompany + strInvoiceNumber + strMonth + strDay + strYear
    End Sub

    Private Sub EmailInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailInvoiceToolStripMenuItem.Click
        Dim strDate As String = ""
        FileDate = Now()
        strDate = CStr(FileDate)

        'Create Customer Note

        'Get Next Note Number
        Dim MaximumNoteString As String = "SELECT MAX(NoteID) as MAXNoteID FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
        MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = EmailInvoiceCustomer
        MaximumNoteCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = MaximumNoteCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("MAXNoteID")) Then
                LastNoteNumber = 0
            Else
                LastNoteNumber = reader.Item("MAXNoteID")
            End If
        Else
            LastNoteNumber = 0
        End If
        reader.Close()
        con.Close()

        NextNoteNumber = LastNoteNumber + 1

        Dim MessageBodyText As String = ""

        MessageBodyText = EmployeeLoginName + " emailed this Invoice - #" + strInvoiceNumber + " to " + EmailCustomerEmailAddress

        'Write Data to Customer Note Table
        cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

        With cmd.Parameters
            .Add("@CustomerID", SqlDbType.VarChar).Value = EmailInvoiceCustomer
            .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            .Add("@NoteDate", SqlDbType.VarChar).Value = Today()
            .Add("@NoteSubject", SqlDbType.VarChar).Value = "Email Invoices"
            .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
            .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Write Data to Customer Note Table
        cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET EmailSent = @EmailSent WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalInvoiceNumber
            .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            .Add("@EmailSent", SqlDbType.VarChar).Value = "Email sent - " + strDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\TWInvoice" & ConfirmName & ".pdf")

        'creating outlook mailitem
        Dim mail As MailItem

        'creating newblank mail message
        mail = OLApp.CreateItem(OlItemType.olMailItem)

        'adding subject information to the mail message
        mail.Subject = EmailInvoiceCustomer + " - #" + GlobalDivisionCode + EmailStringInvoiceNumber

        'adding body message information to the mail message
        mail.Body = "This is an Invoice for an order placed with Truweld / TFP Corporation. Email invoices to - " + EmailCustomerEmailAddress

        'adding to into the address field
        mail.To = EmailCustomerEmailAddress

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldInvoices\TWInvoice" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

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