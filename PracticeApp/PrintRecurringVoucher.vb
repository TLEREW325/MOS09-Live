Imports System.Data.SqlClient

Public Class PrintRecurringVoucher
    Dim batchNumber As Integer = 0
    Dim ds As DataSet
    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Public Sub setBatch(ByVal batch As Integer)
        batchNumber = batch
        ds = New DataSet()
        Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
        Dim cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.Int).Value = batchNumber
        Dim adapt As New SqlDataAdapter
        adapt.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        adapt.Fill(ds, "ReceiptOfInvoiceBatchHeader")
        con.Close()

        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.Int).Value = batchNumber
        adapt.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        adapt.Fill(ds, "ReceiptOfInvoiceBatchLine")
        con.Close()

        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber", con)
        cmd.Parameters.Add("@VoucherNumber", SqlDbType.Int).Value = ds.Tables("ReceiptOfInvoiceBatchLine").Rows(0).Item("VoucherNumber")
        adapt.SelectCommand = cmd
        If con.State = ConnectionState.Closed Then con.Open()
        adapt.Fill(ds, "ReceiptOfInvoiceVoucherLines")
        con.Close()
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = crxPrintCreateRecurringVoucher1
        MyReport.SetDataSource(ds)
        CRRecurringVoucher.ReportSource = MyReport
        con.Close()
    End Sub
End Class