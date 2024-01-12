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
Public Class PrintCustomerSalesReport
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myadapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click



        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode


        If Not String.IsNullOrEmpty(cboCustomer.Text) Then
            cmd1.CommandText += " AND CustomerID = @CustomerID"
            cmd1.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text
        End If


        If chkDateRange.Checked Then
            cmd1.CommandText += " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            cmd1.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
            cmd1.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
        End If

        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CustomerList")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "InvoiceHeaderTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCustSalesReport1
        MyReport.SetDataSource(ds)
        CRCustomerViewer.ReportSource = MyReport
        con.Close()
    End Sub


    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click

        dtpBeginDate.Value = Now()
        dtpBeginDate.Value = Now()
        chkDateRange.Checked = False

        CRCustomerViewer.ReportSource = Nothing

        cboCustomerName.SelectedIndex = -1
        cboCustomer.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboCustomerName.Text) Then
            cboCustomerName.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboCustomer.Text) Then
            cboCustomer.Text = ""
        End If

    End Sub

    Public Sub LoadCustomerList()
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "CustomerList")
        cboCustomer.DataSource = ds6.Tables("CustomerList")
        cboCustomerName.DataSource = ds6.Tables("CustomerList")
        con.Close()
        cboCustomer.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
    End Sub

    Private Sub PrintCustomerSalesReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCustomerList()
    End Sub

End Class