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
Public Class ViewInvoiceLedgerPostings
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ViewInvoiceLedgerPostings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If
    End Sub

    Private Sub dgvInvoiceLines_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceLines.CellDoubleClick
        Dim RowInvoiceNumber, GetSONumber, GetShipmentNumber As Integer
        Dim RowDivision As String
        Dim RowIndex As Integer = Me.dgvInvoiceLines.CurrentCell.RowIndex

        RowInvoiceNumber = Me.dgvInvoiceLines.Rows(RowIndex).Cells(0).Value
        RowDivision = Me.dgvInvoiceLines.Rows(RowIndex).Cells(16).Value

        'Get Invoice Header Data from Invoice Table
        Dim SalesOrderNumberStatement As String = "SELECT SalesOrderNumber FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND InvoiceNumber = @InvoiceNumber"
        Dim SalesOrderNumberCommand As New SqlCommand(SalesOrderNumberStatement, con)
        SalesOrderNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SalesOrderNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber

        Dim ShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND InvoiceNumber = @InvoiceNumber"
        Dim ShipmentNumberCommand As New SqlCommand(ShipmentNumberStatement, con)
        ShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSONumber = CInt(SalesOrderNumberCommand.ExecuteScalar)
        Catch ex As Exception
            GetSONumber = 0
        End Try
        Try
            GetShipmentNumber = CInt(ShipmentNumberCommand.ExecuteScalar)
        Catch ex As Exception
            GetShipmentNumber = 0
        End Try
        con.Close()

        GlobalShipmentNumber = GetShipmentNumber
        GlobalSONumber = GetSONumber
        GlobalInvoiceNumber = RowInvoiceNumber
        GlobalDivisionCode = RowDivision

        If GlobalShipmentNumber = 0 Or GlobalSONumber = 0 Then
            Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                Dim result = NewPrintInvoiceBillOnly.ShowDialog()
            End Using
        Else
            Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                Dim result = NewPrintInvoiceSingle.ShowDialog()
            End Using
        End If
    End Sub

    Public Sub ShowAllData()
        cmd = New SqlCommand("SELECT * FROM InvoiceGeneralLedgerLines ORDER BY InvoiceHeaderKey DESC", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceGeneralLedgerLines")
        dgvInvoiceLines.DataSource = ds.Tables("InvoiceGeneralLedgerLines")
        con.Close()
    End Sub

    Public Sub ShowDataByDivision()
        cmd = New SqlCommand("SELECT * FROM InvoiceGeneralLedgerLines WHERE DivisionID = @DivisionID ORDER BY InvoiceHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceGeneralLedgerLines")
        dgvInvoiceLines.DataSource = ds.Tables("InvoiceGeneralLedgerLines")
        con.Close()
    End Sub

    Private Sub cmdViewByDivision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByDivision.Click
        ShowDataByDivision()
    End Sub

    Private Sub cmdViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAll.Click
        ShowAllData()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Using NewPrintUnpostedInvoiceLines As New PrintUnpostedInvoices
            Dim Result = NewPrintUnpostedInvoiceLines.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        Using NewPrintUnpostedInvoiceLines As New PrintUnpostedInvoices
            Dim Result = NewPrintUnpostedInvoiceLines.ShowDialog()
        End Using
    End Sub
End Class