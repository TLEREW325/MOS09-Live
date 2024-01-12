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
Public Class PrintARCustomerStatementSingle
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim OLApp As New Application

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim LastNoteNumber, NextNoteNumber As Integer

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalCustomerID = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRStatementViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRStatementViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ARAgingQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID

        cmd1 = New SqlCommand("SELECT * FROM ARAgingCategory WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd2.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID

        cmd4 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd4.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd5 = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ARAgingQuery")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ARAgingCategory")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "DivisionTable")

        myAdapter5.SelectCommand = cmd5
        myAdapter5.Fill(ds, "InvoiceHeaderTable")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXCustStatement1
        MyReport.SetDataSource(ds)
        CRStatementViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub EmailStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailStatementToolStripMenuItem.Click
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

        MessageBodyText = EmployeeLoginName + " emailed a Customer Statement to this customer " + EmailInvoiceCustomer + " to " + EmailCustomerEmailAddress

        'Write Data to Customer Note Table
        cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

        With cmd.Parameters
            .Add("@CustomerID", SqlDbType.VarChar).Value = EmailInvoiceCustomer
            .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            .Add("@NoteDate", SqlDbType.VarChar).Value = Today()
            .Add("@NoteSubject", SqlDbType.VarChar).Value = "Email Customer Statement"
            .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
            .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldCustomerStatements\TWCustomerStatement" & ConfirmName & ".pdf")

        'creating outlook mail item
        Dim mail As MailItem

        'creating newblank mail message
        mail = OLApp.CreateItem(OlItemType.olMailItem)

        'adding subject information to the mail message
        mail.Subject = EmailInvoiceCustomer + " " + GlobalDivisionCode + " Customer Statement " + Today.Date.ToShortDateString()

        mail.To = EmailCustomerEmailAddress

        'adding body message information to the mail message
        mail.Body = "This is a Customer Statement for TFP / Truweld - " + EmailInvoiceCustomer

        'adding attachment
        mail.Attachments.Add("\\TFP-FS\TransferData\TruweldCustomerStatements\TWCustomerStatement" & ConfirmName & ".pdf")

        'display mail
        mail.Display()

        Me.Close()
    End Sub

    Private Sub PrintARCustomerStatementSingle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalCustomerID = ""
        EmailInvoiceCustomer = ""
        EmailCustomerEmailAddress = ""
    End Sub
End Class