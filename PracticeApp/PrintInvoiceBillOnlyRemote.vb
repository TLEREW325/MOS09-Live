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
Public Class PrintInvoiceBillOnlyRemote
    Inherits System.Windows.Forms.Form

    'Variables for Date/Filename Creation
    Dim FileDate As Date
    Dim minuteofyear, monthofyear, dayofyear, yearofyear As Integer
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim NextNoteNumber, LastNoteNumber As Integer
    Dim strInvoiceNumber As String = ""

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalInvoiceNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRInvoiceViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRInvoiceViewer.Load
        If GlobalDivisionCode = "TFP" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalInvoiceNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE DivisionID = @DivisionID", con)
            cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable", con)

            cmd5 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd6 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable", con)

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
            myAdapter4.Fill(ds, "InvoiceSerialLineTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "ARCustomerPayment")

            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "SalesOrderHeaderTable")
            'Sets up viewer to display data from the loaded dataset
            MyReport = CRXInvoiceBillOnly1
            MyReport.SetDataSource(ds)
            CRInvoiceViewer.ReportSource = MyReport
            con.Close()

            strInvoiceNumber = CStr(GlobalInvoiceNumber)
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & GlobalDivisionCode & strInvoiceNumber & ".pdf")
        ElseIf GlobalDivisionCode = "TOR" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalInvoiceNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID", con)
            cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable", con)

            cmd5 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

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
            myAdapter4.Fill(ds, "InvoiceSerialLineTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "ARCustomerPayment")

            cmd6 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable", con)
            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "SalesOrderHeaderTable")

            MyReport = CRXInvoiceTFFBillOnly1
            MyReport.SetDataSource(ds)
            CRInvoiceViewer.ReportSource = MyReport
            con.Close()

            strInvoiceNumber = CStr(GlobalInvoiceNumber)
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & GlobalDivisionCode & strInvoiceNumber & ".pdf")
        ElseIf GlobalDivisionCode = "ALB" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalInvoiceNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID", con)
            cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable", con)

            cmd5 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

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
            myAdapter4.Fill(ds, "InvoiceSerialLineTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "ARCustomerPayment")

            MyReport = CRXInvoiceTFFBillOnly1
            MyReport.SetDataSource(ds)
            CRInvoiceViewer.ReportSource = MyReport
            con.Close()

            strInvoiceNumber = CStr(GlobalInvoiceNumber)
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & GlobalDivisionCode & strInvoiceNumber & ".pdf")
        ElseIf GlobalDivisionCode = "TFF" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalInvoiceNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID", con)
            cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable", con)

            cmd5 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

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
            myAdapter4.Fill(ds, "InvoiceSerialLineTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "ARCustomerPayment")

            cmd6 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable", con)
            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "SalesOrderHeaderTable")

            MyReport = CRXInvoiceTFFBillOnly1
            MyReport.SetDataSource(ds)
            CRInvoiceViewer.ReportSource = MyReport
            con.Close()

            strInvoiceNumber = CStr(GlobalInvoiceNumber)
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & GlobalDivisionCode & strInvoiceNumber & ".pdf")
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = GlobalInvoiceNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE DivisionID = @DivisionID", con)
            cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
            cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd4 = New SqlCommand("SELECT * FROM InvoiceSerialLineTable", con)

            cmd5 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

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
            myAdapter4.Fill(ds, "InvoiceSerialLineTable")

            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds, "ARCustomerPayment")

            cmd6 = New SqlCommand("SELECT * FROM SalesOrderHeaderTable", con)
            myAdapter6.SelectCommand = cmd6
            myAdapter6.Fill(ds, "SalesOrderHeaderTable")

            MyReport = CRXInvoiceBillOnly1
            MyReport.SetDataSource(ds)
            CRInvoiceViewer.ReportSource = MyReport
            con.Close()

            strInvoiceNumber = CStr(GlobalInvoiceNumber)
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & GlobalDivisionCode & strInvoiceNumber & ".pdf")
        End If
    End Sub

    Private Sub EmailInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailInvoiceToolStripMenuItem.Click
        'Create new Filename for Bill Only Invoice

        ConfirmName = GlobalDivisionCode + EmailStringInvoiceNumber

        Try
            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & ConfirmName & ".pdf")
        Catch ex As Exception
            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldInvoices\" & ConfirmName & ".pdf")
        End Try

        TFPMailFilename = ConfirmName + ".pdf"
        TFPMailFilePath = "\\TFP-FS\TransferData\TruweldInvoices\" & ConfirmName & ".pdf"
        TFPMailTransactionType = "Print Invoice"
        TFPMailTransactionNumber = GlobalInvoiceNumber

        Using NewEmailPage As New EmailPage
            Dim Result = NewEmailPage.ShowDialog()
        End Using

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintInvoiceBillOnly_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        EmailInvoiceNumber = 0
        EmailSalesOrderNumber = 0
        EmailShipmentNumber = 0
        EmailInvoiceCustomer = ""
        GlobalDivisionCode = ""
        EmailCustomerEmailAddress = ""
        EmailStringInvoiceNumber = ""
        GlobalInvoiceNumber = 0
    End Sub
End Class