Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class ReprintInvoiceBatchRemote
    Inherits System.Windows.Forms.Form

    'Created Outlook Application object
    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany, strInvoiceNumber As String
    Dim LastNoteNumber, NextNoteNumber As Integer

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10, cmd11 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadInvoiceHeaderDataset()
        cmd11 = New SqlCommand("SELECT InvoiceNumber, DivisionID, CustomerID FROM InvoiceHeaderTable WHERE ReprintBatch = @ReprintBatch AND DivisionID = @DivisionID", con)
        cmd11.Parameters.Add("@ReprintBatch", SqlDbType.VarChar).Value = GlobalReprintInvoiceBatch
        cmd11.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd11
        myAdapter2.Fill(ds2, "InvoiceHeaderTable")
        dgvInvoiceHeader.DataSource = ds2.Tables("InvoiceHeaderTable")
        con.Close()
    End Sub

    Private Sub CRInvoiceViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRInvoiceViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE ReprintBatch = @ReprintBatch ORDER BY CustomerID", con)
        cmd.Parameters.Add("@ReprintBatch", SqlDbType.VarChar).Value = GlobalReprintInvoiceBatch

        cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

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

        cmd9 = New SqlCommand("SELECT * FROM InvoiceLotLineTable", con)

        cmd10 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable", con)

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
    End Sub

    Private Sub EmailInvoicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailInvoicesToolStripMenuItem.Click
        LoadInvoiceHeaderDataset()

        Dim CustomerID As String = ""
        Dim InvoiceNumber As Integer = 0
        Dim strInvoiceNumber As String = ""

        'Run loop to create customer notes for all invoices
        For Each Row As DataGridViewRow In dgvInvoiceHeader.Rows
            Try
                CustomerID = Row.Cells("CustomerIDColumn").Value
            Catch ex As System.Exception
                CustomerID = ""
            End Try
            Try
                InvoiceNumber = Row.Cells("InvoiceNumberColumn").Value
            Catch ex As System.Exception
                InvoiceNumber = 0
            End Try

            strInvoiceNumber = CStr(InvoiceNumber)

            'Create Customer Note

            'Get Next Note Number
            Dim MaximumNoteString As String = "SELECT MAX(NoteID) as MAXNoteID FROM CustomerNotes WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim MaximumNoteCommand As New SqlCommand(MaximumNoteString, con)
            MaximumNoteCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
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

            MessageBodyText = EmployeeLoginName + " emailed this Invoice - #" + strInvoiceNumber

            'Write Data to Customer Note Table
            cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

            With cmd.Parameters
                .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                .Add("@NoteDate", SqlDbType.VarChar).Value = Today()
                .Add("@NoteSubject", SqlDbType.VarChar).Value = "Email Invoices"
                .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
                .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            CustomerID = ""
            InvoiceNumber = 0
            strInvoiceNumber = ""
        Next

        'Export Document to Folder
        MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\Invoice-" & ConfirmName & ".pdf")

        TFPMailFilename = ConfirmName + ".pdf"
        TFPMailFilePath = "\\TFP-FS\TransferData\TruweldInvoices\Invoice-" & ConfirmName & ".pdf"
        TFPMailTransactionType = "Reprint Invoice Batch"
        TFPMailTransactionNumber = 0

        Using NewEmailPage As New EmailPage
            Dim Result = NewEmailPage.ShowDialog()
        End Using
    End Sub
End Class