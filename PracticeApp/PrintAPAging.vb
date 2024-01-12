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
Public Class PrintAPAging
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Public Sub LoadVendorList()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "Vendor")
        cboVendor.DisplayMember = "VendorCode"
        cboVendor.DataSource = ds5.Tables("Vendor")
        con.Close()
        cboVendor.SelectedIndex = -1
    End Sub

    Private Sub PrintAPAging_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadVendorList()
    End Sub

    Private Sub cmdVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM APVoucherTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM APAgingCategory WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If Not String.IsNullOrEmpty(cboVendor.Text) Then
            cmd2.CommandText += " and VendorID = @VendorID"
            cmd2.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendor.Text
        End If

        If chkDateRange.Checked Then
            If rdoInvoice.Checked Then
                cmd2.CommandText += " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
                cmd2.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
                cmd2.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
            ElseIf rdoDue.Checked Then
                cmd2.CommandText += " AND DueDate BETWEEN @BeginDate AND @EndDate"
                cmd2.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
                cmd2.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
            End If
        End If
      

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APVoucherTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "APAgingCategory")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "DivisionTable")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "Vendor")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXAPAging1
        MyReport.SetDataSource(ds)
        CRAPViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboVendor.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboVendor.Text) Then
            cboVendor.Text = ""
        End If

        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        rdoDue.Checked = False
        rdoInvoice.Checked = False
        chkDateRange.Checked = False

        CRAPViewer.ReportSource = Nothing
    End Sub


    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

   
    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        If chkDateRange.Checked AndAlso Not rdoInvoice.Checked AndAlso Not rdoDue.Checked Then
            rdoInvoice.Checked = True
        End If
    End Sub
End Class