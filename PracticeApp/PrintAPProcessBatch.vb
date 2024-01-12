Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintAPProcessBatch
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cm5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalAPBatchNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRAPBatchViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRAPBatchViewer.Load
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchHeader  WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber

        cmd1 = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber", con)
        cmd1.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber

        cmd2 = New SqlCommand("SELECT * FROM ReceiptOfInvoiceVoucherLines", con)

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceiptOfInvoiceBatchHeader")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ReceiptOfInvoiceBatchLine")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "ReceiptOfInvoiceVoucherLines")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXAPProcessBatch1
        MyReport.SetDataSource(ds)
        CRAPBatchViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintAPProcessBatch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalAPBatchNumber = 0
    End Sub
End Class