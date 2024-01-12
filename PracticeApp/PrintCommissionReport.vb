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
Public Class PrintCommissionReport
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Public Sub LoadCustomerTerritory()
        cmd = New SqlCommand("SELECT DISTINCT SalesTerritory FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboTerritory.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboTerritory.SelectedIndex = -1
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRCommissionViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCommissionViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "ARCustomerPayment")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCommissionReportbyTerritory1
        MyReport.SetDataSource(ds)
        CRCommissionViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintCommisionReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCustomerTerritory()
    End Sub

    Public Sub ShowDataByFiltersUnGrouped()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID and SalesTerritory = @SalesTerritory", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd3.Parameters.Add("@SalesTerritory", SqlDbType.VarChar).Value = cboTerritory.Text

        cmd4 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "ARCustomerPayment")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCommissionReportbyTerritory1
        MyReport.SetDataSource(ds)
        CRCommissionViewer.ReportSource = MyReport
        con.Close()
    End Sub
    Public Sub ShowDataByFiltersGroupByInvoiceDate()
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID and SalesTerritory = @SalesTerritory", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd3.Parameters.Add("@SalesTerritory", SqlDbType.VarChar).Value = cboTerritory.Text

        cmd4 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "ARCustomerPayment")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCommissionReportbyTerritory1
        MyReport.SetDataSource(ds)
        CRCommissionViewer.ReportSource = MyReport
        con.Close()
    End Sub
    Public Sub ShowDataByFiltersGroupByPaymentDate()
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID and SalesTerritory = @SalesTerritory", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd3.Parameters.Add("@SalesTerritory", SqlDbType.VarChar).Value = cboTerritory.Text

        cmd4 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "ARCustomerPayment")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCommissionReportbyTerritoryPaymentDate1
        MyReport.SetDataSource(ds)
        CRCommissionViewer.ReportSource = MyReport
        con.Close()
    End Sub
    Public Sub ShowDataByFiltersGroupByPaymentDateNoTerritory()
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode


        cmd4 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "ARCustomerPayment")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCommissionReportbyTerritoryPaymentDate1
        MyReport.SetDataSource(ds)
        CRCommissionViewer.ReportSource = MyReport
        con.Close()
    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "CustomerList")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "ARCustomerPayment")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCommissionReportbyTerritory1
        MyReport.SetDataSource(ds)
        CRCommissionViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub chkInvoiceDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInvoiceDate.CheckedChanged
        If chkInvoiceDate.Checked = True Then chkPaymentDate.Checked = False
    End Sub

    Private Sub chkPaymentDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPaymentDate.CheckedChanged
        If chkPaymentDate.Checked = True Then chkInvoiceDate.Checked = False
    End Sub

    Private Sub cmdViewByFilters_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        If chkInvoiceDate.Checked = True Then
            ShowDataByFiltersGroupByInvoiceDate()
        ElseIf chkPaymentDate.Checked = True And cboTerritory.Text <> "" Then
            ShowDataByFiltersGroupByPaymentDate()
        ElseIf chkPaymentDate.Checked = True And cboTerritory.Text = "" Then
            ShowDataByFiltersGroupByPaymentDateNoTerritory()

        Else
            ShowDataByFiltersUnGrouped()
        End If

    End Sub
End Class