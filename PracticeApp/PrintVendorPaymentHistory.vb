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
Public Class PrintVendorPaymentHistory
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

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "Vendor")
        cboVendor.DataSource = ds1.Tables("Vendor")
        con.Close()
        cboVendor.SelectedIndex = -1
    End Sub

    Private Sub PrintVendorPaymentHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadVendor()
    End Sub

    Private Sub cmdVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVendor.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM APCheckLog WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM APCheckLines", con)

        cmd3 = New SqlCommand("SELECT * FROM APCheckQuery WHERE DivisionID = @DivisionID", con)
        cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd4 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd4.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If Not String.IsNullOrEmpty(cboVendor.Text) Then
            cmd.CommandText += " and VendorID = @VendorID"
            cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendor.Text
        End If

        If chkDateRange.Checked Then
            cmd.CommandText += " and CheckDate between @BeginDate and @EndDate"
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
        End If

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APCheckLog")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "APCheckLines")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "APCheckQuery")

        myAdapter4.SelectCommand = cmd4
        myAdapter4.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXVendorPaymentHistory1
        MyReport.SetDataSource(ds)
        CRVendorViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
      
        CRVendorViewer.ReportSource = Nothing
        cboVendor.SelectedIndex = -1
        If Not String.IsNullOrEmpty(cboVendor.Text) Then
            cboVendor.Text = ""
        End If
        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        chkDateRange.Checked = False

    End Sub
End Class