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
Public Class PrintCustomerPaymentActivity
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadCustomerList()
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboCustomer.DataSource = ds4.Tables("CustomerList")
        cboCustomerName.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboCustomer.SelectedIndex = -1 'Sets control to blank
        cboCustomerName.SelectedIndex = -1 'Sets control to blank
    End Sub

  
    Private Sub PrintCustomerPaymentActivity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCustomerList()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboCustomer.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        dtpPaymentDate.Value = Now
        dtpEndDate.Value = Now

        If Not String.IsNullOrEmpty(cboCustomer.Text) Then
            cboCustomer.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboCustomerName.Text) Then
            cboCustomerName.Text = ""
        End If

        CRPaymentViewer.ReportSource = Nothing

    End Sub

    Private Sub cmdFilterByCustomerAndDateRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterByCustomerAndDateRange.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode



        cmd1 = New SqlCommand("SELECT * FROM ARCustomerPaymentQuery WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM ARPaymentLog", con)

        cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode



        If Not String.IsNullOrEmpty(cboCustomer.Text) Then
            cmd.CommandText += " and CustomerID = @CustomerID"
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text
        End If

        If chkDateRange.Checked = True Then
            cmd.CommandText += " and PaymentDate Between @PaymentDate and @EndDate"
            cmd.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpPaymentDate.Text
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ARCustomerPayment")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ARCustomerPaymentQuery")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "ARPaymentLog")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCustPaymentActivity1
        MyReport.SetDataSource(ds)
        CRPaymentViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class