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
Public Class EmailAllInvoiceDocsRemote
    Inherits System.Windows.Forms.Form

    Dim LastNoteNumber, NextNoteNumber As Integer
    Dim strDate As String = ""
    Dim FileDate As Date

    Dim MyReport1 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim MyReport2 = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub CRInvoiceViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles CRInvoiceViewer.Load
        'Choose the Invoice Print Form by division
        If GlobalDivisionCode = "TFF" Or GlobalDivisionCode = "TOR" Or GlobalDivisionCode = "ALB" Then
            If EmailShipmentNumber = 0 Or EmailSalesOrderNumber = 0 Then
                'Bill Only Invoice - Canadian
                cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = EmailInvoiceNumber
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID", con)
                cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd4 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
                cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()

                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "InvoiceHeaderTable")

                myAdapter1.SelectCommand = cmd1
                myAdapter1.Fill(ds, "InvoiceLineQuery")

                myAdapter2.SelectCommand = cmd2
                myAdapter2.Fill(ds, "DivisionTable")

                myAdapter3.SelectCommand = cmd3
                myAdapter3.Fill(ds, "CustomerList")

                myAdapter4.SelectCommand = cmd4
                myAdapter4.Fill(ds, "ARCustomerPayment")

                'Sets up viewer to display data from the loaded dataset
                MyReport1 = CRXInvoiceTFFBillOnly1
                MyReport1.SetDataSource(ds)
                con.Close()
            Else
                'Loads data into dataset for viewing
                cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = EmailInvoiceNumber
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND InvoiceHeaderKey = @InvoiceHeaderKey", con)
                cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                cmd1.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = EmailInvoiceNumber

                cmd2 = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
                cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd3 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey", con)
                cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd4 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                cmd4.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd5 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
                cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd7 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
                cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd8 = New SqlCommand("SELECT * FROM InvoiceLotLineTable", con)

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

                myAdapter7.SelectCommand = cmd7
                myAdapter7.Fill(ds, "ARCustomerPayment")

                myAdapter8.SelectCommand = cmd8
                myAdapter8.Fill(ds, "InvoiceLotLineTable")

                'Sets up viewer to display data from the loaded dataset
                MyReport1 = CRXInvoiceTFF1
                MyReport1.SetDataSource(ds)
                con.Close()
            End If
        ElseIf GlobalDivisionCode = "TFP" Then
            If EmailShipmentNumber = 0 Or EmailSalesOrderNumber = 0 Then
                cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = EmailInvoiceNumber
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd1 = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE DivisionID = @DivisionID", con)
                cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd4 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
                cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()

                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "InvoiceHeaderTable")

                myAdapter1.SelectCommand = cmd1
                myAdapter1.Fill(ds, "InvoiceLineTable")

                myAdapter2.SelectCommand = cmd2
                myAdapter2.Fill(ds, "DivisionTable")

                myAdapter3.SelectCommand = cmd3
                myAdapter3.Fill(ds, "CustomerList")

                myAdapter4.SelectCommand = cmd4
                myAdapter4.Fill(ds, "ARCustomerPayment")

                'Sets up viewer to display data from the loaded dataset
                MyReport1 = CRXInvoiceBillOnly1
                MyReport1.SetDataSource(ds)
                con.Close()
            Else
                'Loads data into dataset for viewing
                cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = EmailInvoiceNumber

                cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND InvoiceHeaderKey = @InvoiceHeaderKey", con)
                cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                cmd1.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = EmailInvoiceNumber

                cmd2 = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
                cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd4 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                cmd4.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd5 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
                cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd7 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
                cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd8 = New SqlCommand("SELECT * FROM InvoiceLotLineTable", con)

                cmd9 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable", con)

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

                myAdapter7.SelectCommand = cmd7
                myAdapter7.Fill(ds, "ARCustomerPayment")

                myAdapter8.SelectCommand = cmd8
                myAdapter8.Fill(ds, "InvoiceLotLineTable")

                myAdapter9.SelectCommand = cmd9
                myAdapter9.Fill(ds, "SalesOrderHeaderTable")

                'Sets up viewer to display data from the loaded dataset

                MyReport1 = CRXInvoice1
                MyReport1.SetDataSource(ds)
                con.Close()
            End If
        Else
            If EmailShipmentNumber = 0 Or EmailSalesOrderNumber = 0 Then
                cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = EmailInvoiceNumber
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd1 = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE DivisionID = @DivisionID", con)
                cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd4 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
                cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
                ds = New DataSet()

                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds, "InvoiceHeaderTable")

                myAdapter1.SelectCommand = cmd1
                myAdapter1.Fill(ds, "InvoiceLineTable")

                myAdapter2.SelectCommand = cmd2
                myAdapter2.Fill(ds, "DivisionTable")

                myAdapter3.SelectCommand = cmd3
                myAdapter3.Fill(ds, "CustomerList")

                myAdapter4.SelectCommand = cmd4
                myAdapter4.Fill(ds, "ARCustomerPayment")

                'Sets up viewer to display data from the loaded dataset
                MyReport1 = CRXInvoiceBillOnly1
                MyReport1.SetDataSource(ds)
                con.Close()
            Else
                'Loads data into dataset for viewing
                cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber", con)
                cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = EmailInvoiceNumber

                cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND InvoiceHeaderKey = @InvoiceHeaderKey", con)
                cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                cmd1.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = EmailInvoiceNumber

                cmd2 = New SqlCommand("SELECT * FROM ShipmentHeaderTable WHERE DivisionID = @DivisionID", con)
                cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd4 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
                cmd4.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd5 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
                cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd6 = New SqlCommand("SELECT * FROM AdditionalShipTo WHERE DivisionID = @DivisionID", con)
                cmd6.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd7 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
                cmd7.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                cmd8 = New SqlCommand("SELECT * FROM InvoiceLotLineTable", con)

                cmd9 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable", con)

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

                myAdapter7.SelectCommand = cmd7
                myAdapter7.Fill(ds, "ARCustomerPayment")

                myAdapter8.SelectCommand = cmd8
                myAdapter8.Fill(ds, "InvoiceLotLineTable")

                myAdapter9.SelectCommand = cmd9
                myAdapter9.Fill(ds, "SalesOrderHeaderTable")

                'Sets up viewer to display data from the loaded dataset

                MyReport1 = CRXInvoice1
                MyReport1.SetDataSource(ds)
                con.Close()
            End If
        End If
        '******************************************************************************************
        'Count Shipment Lot Lines to determine whether certs need attached
        Dim CertCount As Integer = 0

        Dim CertCountStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentLineLotNumbers WHERE ShipmentNumber = @ShipmentNumber"
        Dim CertCountCommand As New SqlCommand(CertCountStatement, con)
        CertCountCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = EmailShipmentNumber

        If con.State = ConnectionState.Closed Then con.Open()
        CertCount = CInt(CertCountCommand.ExecuteScalar)
        con.Close()
        '*******************************************************************************************************************************************
        'Check to make sure at least one cert will print otherwise do not open Print Form
        Dim CheckForCerts As Integer = 0

        'Get Pull Test Number for selected Lot Number Data
        Dim CheckForCertsStatement As String = "SELECT COUNT(ShipmentNumber) as CountShipmentNumber FROM TruweldCertData WHERE ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID"
        Dim CheckForCertsCommand As New SqlCommand(CheckForCertsStatement, con)
        CheckForCertsCommand.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = EmailShipmentNumber
        CheckForCertsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader2 As SqlDataReader = CheckForCertsCommand.ExecuteReader()
        If reader2.HasRows Then
            reader2.Read()
            If IsDBNull(reader2.Item("CountShipmentNumber")) Then
                CheckForCerts = 0
            Else
                CheckForCerts = reader2.Item("CountShipmentNumber")
            End If
        Else
            CheckForCerts = 0
        End If
        reader2.Close()
        con.Close()
        '******************************************************************************************
        'Create Cert Name
        Dim CertName As String = ""
        Dim strShipmentNumber As String = ""

        strShipmentNumber = CStr(EmailInvoiceNumber)

        CertName = "CERT-" + GlobalDivisionCode + strShipmentNumber
        '******************************************************************************************
        'Create Invoice Name
        Dim InvoiceName As String = ""
        Dim strInvoiceNumber As String = ""

        strInvoiceNumber = CStr(EmailInvoiceNumber)

        InvoiceName = GlobalDivisionCode + strInvoiceNumber

        'Export Document to Folder
        MyReport1.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & InvoiceName & ".pdf")
        '******************************************************************************************
        If EmailShipmentNumber = 0 Or CertCount = 0 Or CheckForCerts = 0 Then
            'Skip Certs
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * from TruweldCertData where ShipmentNumber = @ShipmentNumber", con)
            cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = EmailShipmentNumber

            cmd1 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable", con)

            cmd3 = New SqlCommand("SELECT * FROM PullTestLineTable WHERE PullTestLineNumber < 3", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "TruweldCertData")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "CustomerList")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "DivisionTable")

            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds, "PullTestLineTable")

            'Sets up viewer to display data from the loaded dataset
            MyReport2 = CRXTWCert011
            MyReport2.SetDataSource(ds)
            con.Close()

            'Export Document to Folder
            MyReport2.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & CertName & ".pdf")
        End If
        '******************************************************************************************
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

        MessageBodyText = EmployeeLoginName + " emailed this Invoice - #" + strInvoiceNumber + " and certs " + " to " + EmailCustomerEmailAddress

        'Write Data to Customer Note Table
        cmd = New SqlCommand("Insert Into CustomerNotes(CustomerID, DivisionID, NoteDate, NoteSubject, NoteBody, NoteID)Values(@CustomerID, @DivisionID, @NoteDate, @NoteSubject, @NoteBody, @NoteID)", con)

        With cmd.Parameters
            .Add("@CustomerID", SqlDbType.VarChar).Value = EmailInvoiceCustomer
            .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            .Add("@NoteDate", SqlDbType.VarChar).Value = Today()
            .Add("@NoteSubject", SqlDbType.VarChar).Value = "Email Invoices and Certs"
            .Add("@NoteBody", SqlDbType.VarChar).Value = MessageBodyText
            .Add("@NoteID", SqlDbType.VarChar).Value = NextNoteNumber
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        FileDate = Today()
        strDate = CStr(FileDate)

        'Write Data to Customer Note Table
        cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET EmailSent = @EmailSent WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = EmailInvoiceNumber
            .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            .Add("@EmailSent", SqlDbType.VarChar).Value = "Email sent - " + strDate
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        If EmailShipmentNumber = 0 Or CertCount = 0 Or CheckForCerts = 0 Then
            TFPMailFilename = ""
            TFPMailFilename2 = InvoiceName & ".pdf"
            TFPMailFilePath = ""
            TFPMailFilePath2 = "\\TFP-FS\TransferData\TruweldInvoices\" & InvoiceName & ".pdf"
            TFPMailTransactionType = "Email All Invoice Docs"
            TFPMailTransactionNumber = GlobalInvoiceNumber
            TFPMailCustomer = EmailInvoiceCustomer

            Using NewEmailPage As New EmailPage
                Dim Result = NewEmailPage.ShowDialog()
            End Using
        Else
            'Attach both files to email
            TFPMailFilename = CertName + ".pdf"
            TFPMailFilename2 = InvoiceName & ".pdf"
            TFPMailFilePath = "\\TFP-FS\TransferData\TruweldInvoices\" & CertName & ".pdf"
            TFPMailFilePath2 = "\\TFP-FS\TransferData\TruweldInvoices\" & InvoiceName & ".pdf"
            TFPMailTransactionType = "Email All Invoice Docs"
            TFPMailTransactionNumber = GlobalInvoiceNumber
            TFPMailCustomer = EmailInvoiceCustomer

            Using NewEmailPage As New EmailPage
                Dim Result = NewEmailPage.ShowDialog()
            End Using
        End If

        Me.Close()
    End Sub

End Class