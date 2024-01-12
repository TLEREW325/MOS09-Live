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
Public Class PrintItemsSoldToCustomer
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Public Sub LoadCustomerData()
        cmd = New SqlCommand("Select Distinct CustomerID, CustomerName from InvoiceLineQuery Where DivisionId = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "InvoiceLineQuery")
        cboCustomer.DataSource = ds1.Tables("InvoiceLineQuery")
        cboCustomerName.DataSource = ds1.Tables("InvoiceLineQuery")
        con.Close()
        cboCustomer.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1

    End Sub
    Public Sub LoadInvoice()
        cmd = New SqlCommand("Select Distinct InvoiceHeaderKey from InvoiceLineQuery Where DivisionId = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "InvoiceLineQuery")
        cboInvoice.DataSource = ds2.Tables("InvoiceLineQuery")
        con.Close()
        cboInvoice.SelectedIndex = -1
    End Sub


    Public Sub LoadPartData()
        cmd = New SqlCommand("Select Distinct PartNumber from InvoiceLineQuery Where DivisionId = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "InvoiceLineQuery")
        cboPartNumber.DataSource = ds3.Tables("InvoiceLineQuery")
        con.Close()
        cboPartNumber.SelectedIndex = -1

    End Sub
    Public Sub LoadPartDesc()

        cmd = New SqlCommand("Select Distinct PartDescription from InvoiceLineQuery Where DivisionId = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "InvoiceLineQuery")
        cboPartDesc.DataSource = ds4.Tables("InvoiceLineQuery")
        con.Close()
        cboPartDesc.SelectedIndex = -1

    End Sub
    Public Sub ShowDataByFilter()
       

        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode


        cmd1 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd1.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM ItemClass", con)


        If chkDateFilter.Checked Then
            cmd.CommandText += " and InvoiceDate Between @BeginDate and @EndDate"
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
        End If
        If Not String.IsNullOrEmpty(cboInvoice.Text) Then
            cmd.CommandText += " and InvoiceHeaderKey = @InvoiceHeaderKey"
            cmd.Parameters.Add("@InvoiceHeaderKey", SqlDbType.Int).Value = Val(cboInvoice.Text)
        End If
        If Not String.IsNullOrEmpty(cboCustomer.Text) Then
            cmd.CommandText += " and CustomerID = @CustomerId"
            cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text
        End If
        If Not String.IsNullOrEmpty(cboCustomerName.Text) Then
            cmd.CommandText += " and CustomerName = @CustomerName"
            cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        End If
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cmd.CommandText += " and PartNumber = @PartNumber"
            cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboPartDesc.Text) Then
            cmd.CommandText += " and PartDescription = @PartDescription"
            cmd.Parameters.Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDesc.Text
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceLineQuery")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "DivisionTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "ItemClass")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXItemsSoldtoCust1
        MyReport.SetDataSource(ds)
        CRItemsSoldViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
   
     
        CRItemsSoldViewer.ReportSource = Nothing

        cboInvoice.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboCustomer.SelectedIndex = -1
        cboPartDesc.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        chkDateFilter.Checked = False

        If Not String.IsNullOrEmpty(cboCustomer.Text) Then
            cboCustomer.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboCustomerName.Text) Then
            cboCustomerName.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboPartDesc.Text) Then
            cboPartDesc.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboInvoice.Text) Then
            cboInvoice.Text = ""
        End If
    End Sub


    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintItemsSoldToCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInvoice()
        LoadPartData()
        LoadCustomerData()
        LoadPartDesc()
    End Sub



    Private Sub cmdShowByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowByFilters.Click
        ShowDataByFilter()
    End Sub

    Private Sub CRItemsSoldViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRItemsSoldViewer.Load

    End Sub
End Class