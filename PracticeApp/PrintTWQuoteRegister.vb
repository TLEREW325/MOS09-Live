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
Public Class PrintTWQuoteRegister
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadCustomer()
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        cboCustomer.DataSource = ds3.Tables("CustomerList")
        cboCustomerName.DataSource = ds3.Tables("CustomerList")
        con.Close()
        cboCustomer.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadQuoteNumber()
        cmd = New SqlCommand("SELECT SalesOrderKey FROM SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SOStatus = @SOStatus", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "SalesOrderHeaderTable")
        cboQuoteNumber.DataSource = ds4.Tables("SalesOrderHeaderTable")
        con.Close()
        cboQuoteNumber.SelectedIndex = -1
    End Sub

    Private Sub CRQuoteViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRQuoteViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE SOStatus = @SOStatus AND DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderHeaderTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXTWQuoteRegister1
        MyReport.SetDataSource(ds)
        CRQuoteViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintTWQuoteRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCustomer()
        LoadQuoteNumber()
    End Sub

    Private Sub cmdCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomer.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE SOStatus = @SOStatus AND DivisionKey = @DivisionKey and CustomerID = @CustomerID", con)
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderHeaderTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXTWQuoteRegister1
        MyReport.SetDataSource(ds)
        CRQuoteViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDate.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE SOStatus = @SOStatus AND DivisionKey = @DivisionKey and SalesOrderDate = @SalesOrderDate", con)
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@SalesOrderDate", SqlDbType.VarChar).Value = dtpSalesOrderDate.Text

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderHeaderTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXTWQuoteRegister1
        MyReport.SetDataSource(ds)
        CRQuoteViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdQuoteNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuoteNumber.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE SOStatus = @SOStatus AND DivisionKey = @DivisionKey and SalesOrderKey = @SalesOrderKey", con)
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = cboQuoteNumber.Text

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderHeaderTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXTWQuoteRegister1
        MyReport.SetDataSource(ds)
        CRQuoteViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        cboCustomer.SelectedIndex = -1
        cboQuoteNumber.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1

        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM SalesOrderHeaderTable WHERE SOStatus = @SOStatus AND DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        
        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderHeaderTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXTWQuoteRegister1
        MyReport.SetDataSource(ds)
        CRQuoteViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class