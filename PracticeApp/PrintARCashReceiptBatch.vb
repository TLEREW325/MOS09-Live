Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintARCashReceiptBatch
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalARBatchNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRBatchViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRBatchViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ARPaymentLog WHERE ARBatchNumber = @ARBatchNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ARBatchNumber", SqlDbType.VarChar).Value = GlobalARBatchNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalARBatchNumber
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM ARPaymentLines", con)

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ARPaymentLog")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ARCustomerPayment")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "ARPaymentLines")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXARCashReceiptBatchSummary1
        MyReport.SetDataSource(ds)
        CRBatchViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintARCashReceiptBatch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalARBatchNumber = 0
    End Sub
End Class