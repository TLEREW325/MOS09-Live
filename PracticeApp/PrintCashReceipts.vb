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
Public Class PrintCashReceipts
    Inherits System.Windows.Forms.Form

    Dim BeginDate, EndDate As Date

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
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomer.DataSource = ds2.Tables("CustomerList")
        cboCustomerName.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomer.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub loadinvoice()
        cmd = New SqlCommand("select DISTINCT(invoicenumber) from arcustomerpayment where divisionid = @divisionid", con)
        cmd.parameters.add("@divisionid", sqldbtype.varchar).value = globaldivisioncode
        If con.state = connectionstate.closed Then con.open()
        ds3 = New dataset()
        myadapter3.selectcommand = cmd
        myAdapter3.Fill(ds3, "arcustomerpayment")
        cboInvoiceNumber.DisplayMember = "invoicenumber"
        cboInvoiceNumber.DataSource = ds3.Tables("arcustomerpayment")
        con.close()
        cboInvoiceNumber.SelectedIndex = -1
    End Sub

    Public Sub loadcheck()
        cmd = New SqlCommand("select DISTINCT(checknumber) from arcustomerpayment where divisionid = @divisionid", con)
        cmd.parameters.add("@divisionid", sqldbtype.varchar).value = globaldivisioncode
        If con.state = connectionstate.closed Then con.open()
        ds4 = New dataset()
        myadapter4.selectcommand = cmd
        myAdapter4.Fill(ds4, "arcustomerpayment")
        cboCheckNumber.DisplayMember = "checknumber"
        cboCheckNumber.DataSource = ds4.Tables("arcustomerpayment")
        con.close()
        cboCheckNumber.SelectedIndex = -1
    End Sub

    Private Sub PrintCashReceipts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCustomerList()
        loadcheck()
        loadinvoice()
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click, cmdFilter.Click
        BeginDate = dtpBeginDate.Value
        EndDate = dtpEndDate.Value

        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM ARCustomerPayment WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If Not String.IsNullOrEmpty(cboCustomer.Text) Then
            cmd1.CommandText += " and CustomerId = @CustomerID"
            cmd1.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomer.Text
        End If
        If Not String.IsNullOrEmpty(cboCheckNumber.Text) Then
            cmd1.CommandText += " and CheckNumber = @CheckNumber"
            cmd1.Parameters.Add("@CheckNumber", SqlDbType.Int).Value = Val(cboCheckNumber.Text)
        End If
        If Not String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
            cmd1.CommandText += " and InvoiceNumber = @InvoiceNumber"
            cmd1.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = Val(cboInvoiceNumber.Text)
        End If
        If chkDateRange.Checked = True Then
            If rdoInvoiceDate.Checked = True Then
                cmd1.CommandText += " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
                cmd1.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
                cmd1.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value

            ElseIf rdoPaymentDate.Checked = True Then
                cmd1.CommandText += " and PaymentDate BETWEEN @BeginDate AND @EndDate"
                cmd1.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
                cmd1.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
            End If
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "DivisionTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ARCustomerPayment")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXCashReceipts1
        MyReport.SetDataSource(ds)
        CRCashReceiptsViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboCustomer.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboInvoiceNumber.SelectedIndex = -1
        cboCheckNumber.SelectedIndex = -1
        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        chkDateRange.Checked = False
        rdoInvoiceDate.Checked = False
        rdoPaymentDate.Checked = False
        If Not String.IsNullOrEmpty(cboCustomer.Text) Then
            cboCustomer.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboCustomerName.Text) Then
            cboCustomerName.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
            cboInvoiceNumber.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboCheckNumber.Text) Then
            cboCheckNumber.Text = ""
        End If
        CRCashReceiptsViewer.ReportSource = Nothing
    End Sub

   
    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        If chkDateRange.Checked AndAlso Not rdoInvoiceDate.Checked AndAlso Not rdoPaymentDate.Checked Then
            rdoInvoiceDate.Checked = True
        End If
    End Sub
End Class