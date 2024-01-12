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
Public Class PrintInvoiceDiscrepancyReport
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRInvoiceViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRInvoiceViewer.Load
        If GlobalInvoiceReports = "INVOICE DISCREPANCY" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE InvoiceStatus = @InvoiceStatus AND DivisionID = @DivisionID AND PaymentsApplied <> @PaymentsApplied AND (InvoiceTotal - PaymentsApplied <  @Difference)", con)
            cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"
            cmd.Parameters.Add("@PaymentsApplied", SqlDbType.VarChar).Value = 0
            cmd.Parameters.Add("@Difference", SqlDbType.VarChar).Value = 0.1
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoiceHeaderTable")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXInvoiceDiscrepancy1
            MyReport.SetDataSource(ds)
            CRInvoiceViewer.ReportSource = MyReport
            con.Close()
        ElseIf GlobalInvoiceReports = "COMPARE INVOICE PAYMENTS" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM InvoicePaymentRecord WHERE InvoiceStatus = @InvoiceStatus AND PaymentsApplied <> SumPaymentAmount AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "InvoicePaymentRecord")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXInvoicePaymentReport1
            MyReport.SetDataSource(ds)
            CRInvoiceViewer.ReportSource = MyReport
            con.Close()
        Else

        End If
    End Sub

    Private Sub PrintInvoiceDiscrepancyReport_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalInvoiceReports = ""
    End Sub
End Class