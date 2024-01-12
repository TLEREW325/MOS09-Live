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
Public Class SOSalesPricePopup
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub SOSalesPricePopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalDivisionCode = ""
        GlobalSOCustomerID = ""
        GlobalSOPartNumber = ""
    End Sub

    Private Sub SOSalesPricePopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowSalesLines()
        ShowInvoiceLines()
        Me.dgvInvoicePricing.Visible = False
    End Sub

    Public Sub ShowSalesLines()
        'Load changes to datagrid
        Me.dgvSalesOrderLines.Columns("CustomerPOColumn").Visible = True
        Me.dgvSalesOrderLines.Columns("CustomerIDColumn").Visible = False

        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND CustomerID = @CustomerID AND ItemID = @ItemID AND LineStatus <> 'QUOTE' ORDER BY SalesOrderDate DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GlobalSOPartNumber
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalSOCustomerID
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderLineQuery")
        dgvSalesOrderLines.DataSource = ds.Tables("SalesOrderLineQuery")
        con.Close()
    End Sub

    Public Sub ShowSalesLinesForAllCustomers()
        'Load changes to datagrid
        Me.dgvSalesOrderLines.Columns("CustomerPOColumn").Visible = False
        Me.dgvSalesOrderLines.Columns("CustomerIDColumn").Visible = True

        cmd = New SqlCommand("SELECT * FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey AND ItemID = @ItemID AND LineStatus <> 'QUOTE' ORDER BY SalesOrderDate DESC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GlobalSOPartNumber
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "SalesOrderLineQuery")
        dgvSalesOrderLines.DataSource = ds1.Tables("SalesOrderLineQuery")
        con.Close()
    End Sub

    Public Sub ShowInvoiceLines()
        'Load changes to datagrid
        Me.dgvInvoicePricing.Columns("CustomerPOColumn1").Visible = True
        Me.dgvInvoicePricing.Columns("CustomerIDColumn1").Visible = False

        'Load changes to datagrid
        cmd = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PartNumber = @PartNumber ORDER BY InvoiceDate DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalSOPartNumber
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalSOCustomerID
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "InvoiceLineQuery")
        dgvInvoicePricing.DataSource = ds2.Tables("InvoiceLineQuery")
        con.Close()
    End Sub

    Public Sub ShowInvoiceLinesForAllCustomers()
        'Load changes to datagrid
        Me.dgvInvoicePricing.Columns("CustomerPOColumn1").Visible = False
        Me.dgvInvoicePricing.Columns("CustomerIDColumn1").Visible = True

        'Load changes to datagrid
        cmd = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber ORDER BY InvoiceDate DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalSOPartNumber
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "InvoiceLineQuery")
        dgvInvoicePricing.DataSource = ds3.Tables("InvoiceLineQuery")
        con.Close()
    End Sub

    Private Sub chkShowAllParts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowAllParts.CheckedChanged
        If chkShowAllParts.Checked = False Then
            ShowSalesLines()
            ShowInvoiceLines()
        Else
            ShowSalesLinesForAllCustomers()
            ShowInvoiceLinesForAllCustomers()
        End If
    End Sub

    Private Sub chkInvoicePricing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInvoicePricing.CheckedChanged
        If chkInvoicePricing.Checked = True Then
            Me.dgvInvoicePricing.Visible = True
            Me.dgvSalesOrderLines.Visible = False
            lblPriceLabel.Text = "*** Prices from Invoices ***"
            Me.Text = "Prices entered on Invoices"
        Else
            Me.dgvInvoicePricing.Visible = False
            Me.dgvSalesOrderLines.Visible = True
            lblPriceLabel.Text = "*** Prices from Sales Orders ***"
            Me.Text = "Prices entered on Sales Orders"
        End If
    End Sub
End Class