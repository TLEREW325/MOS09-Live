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
Public Class PrintCustomerOrderHistory
    Inherits System.Windows.Forms.Form

    Dim BeginDate, EndDate As Date

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

    Public Sub LoadCustomerList()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomer.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomer.SelectedIndex = -1
    End Sub

    Private Sub PrintCustomerOrderHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCustomerList()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        CRHistoryViewer.ReportSource = Nothing

        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        chkDateRange.Checked = False

        cboCustomer.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboCustomer.Text) Then
            cboCustomer.Text = ""
        End If
    End Sub

    Private Sub cmdFilterByCustomerAndDateRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterByCustomerAndDateRange.Click
        BeginDate = dtpBeginDate.Value
        EndDate = dtpEndDate.Value

        cmd = New SqlCommand("SELECT * FROM SalesOrderLineQuery WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If Not String.IsNullOrEmpty(cboCustomer.Text) Then
            cmd.CommandText += " AND CustomerID = @CustomerID"
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text
        End If
        If chkDateRange.Checked Then
            If Not String.IsNullOrEmpty(BeginDate) And Not String.IsNullOrEmpty(EndDate) Then
                cmd.CommandText += " AND SalesOrderDate BETWEEN @BeginDate AND @EndDate"
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            End If
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderLineQuery")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "CustomerList")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCustomerOrderHistory1
        MyReport.SetDataSource(ds)
        CRHistoryViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class