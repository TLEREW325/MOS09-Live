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
Public Class PrintARCustomerStatementSingleRemote
    Inherits System.Windows.Forms.Form

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
        'Create new Filename for Customer Statement

        ConfirmName = GlobalDivisionCode + EmailInvoiceCustomer

        Try
            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldCustomerStatements\" & ConfirmName & ".pdf")
        Catch ex As Exception
            'Create new Filename for Customer Statement

            ConfirmName = GlobalDivisionCode + EmailInvoiceCustomer

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldCustomerStatements\" & ConfirmName & ".pdf")
        End Try

        TFPMailFilename = ConfirmName + ".pdf"
        TFPMailFilePath = "\\TFP-FS\TransferData\TruweldCustomerStatements\" & ConfirmName & ".pdf"
        TFPMailTransactionType = "Print Customer Statement"
        TFPMailTransactionNumber = 0
        TFPMailCustomer = EmailInvoiceCustomer

        Using NewEmailPage As New EmailPage
            Dim Result = NewEmailPage.ShowDialog()
        End Using

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintARCustomerStatementSingle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalCustomerID = ""
        EmailInvoiceCustomer = ""
        EmailCustomerEmailAddress = ""
    End Sub
End Class