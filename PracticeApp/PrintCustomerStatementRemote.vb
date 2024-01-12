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
Public Class PrintCustomerStatementRemote
    Inherits System.Windows.Forms.Form

    'Variables for Date/Filename Creation
    Dim ConfirmName, strMinute, strMonth, strYear, strDay, strCompany As String
    Dim LastNoteNumber, NextNoteNumber As Integer

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRStatementViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRStatementViewer.Load
        'Loads data into dataset for viewing

        ds = GDS

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXCustStatement1
        MyReport.SetDataSource(ds)
        CRStatementViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub EmailStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailStatementToolStripMenuItem.Click
        'Create new Filename for Customer Statement

        ConfirmName = strCompany + EmailInvoiceCustomer

        Try
            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldCustomerStatements\" & ConfirmName & ".pdf")
        Catch ex As Exception
            'Create new Filename for Customer Statement

            ConfirmName = strCompany + EmailInvoiceCustomer

            'Export Document to Folder
            MyReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TransferData\TruweldCustomerStatements\" & ConfirmName & ".pdf")
        End Try

        TFPMailFilename = ConfirmName + ".pdf"
        TFPMailFilename2 = ""
        TFPMailFilename3 = ""
        TFPMailFilePath = "\\TFP-FS\TransferData\TruweldCustomerStatements\" & ConfirmName & ".pdf"
        TFPMailFilePath2 = ""
        TFPMailFilePath3 = ""
        TFPMailTransactionType = "Print Customer Statement"
        TFPMailTransactionNumber = 0
        TFPMailCustomer = EmailInvoiceCustomer

        Using NewEmailPage As New EmailPage
            Dim Result = NewEmailPage.ShowDialog()
        End Using

        Me.Dispose()
        Me.Close()
    End Sub
End Class