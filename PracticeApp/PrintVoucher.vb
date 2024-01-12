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
Public Class PrintVoucher
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalVoucherNumber = 0
        GlobalVoucherType = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRVoucherViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRVoucherViewer.Load
        If GlobalVoucherType = "POSTED" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber", con)
            cmd1.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "ReceiptOfInvoiceVoucherLines")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXVoucher1
            MyReport.SetDataSource(ds)
            CRVoucherViewer.ReportSource = MyReport
            con.Close()
        ElseIf GlobalVoucherType = "DELETED" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM DeleteVoucherHeaderTable WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * FROM DeleteVoucherLineTable WHERE VoucherNumber = @VoucherNumber", con)
            cmd1.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "DeleteVoucherHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "DeleteVoucherLineTable")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXDeletedVoucher1
            MyReport.SetDataSource(ds)
            CRVoucherViewer.ReportSource = MyReport
            con.Close()
        Else
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

            cmd1 = New SqlCommand("SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber", con)
            cmd1.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "ReceiptOfInvoiceVoucherLines")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXVoucher1
            MyReport.SetDataSource(ds)
            CRVoucherViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Private Sub PrintVoucher_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        GlobalVoucherNumber = 0
        GlobalVoucherType = ""
    End Sub
End Class