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
Public Class PrintVendorReturnListing
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub PrintVendorReturnListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadReturnNumbers()
        LoadVendorIDs()
        LoadPONumbers()
    End Sub

    Public Sub LoadReturnNumbers()
        cmd = New SqlCommand("SELECT ReturnNumber FROM VendorReturn WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "VendorReturn")
        cboReturnNumber.DisplayMember = "ReturnNumber"
        cboReturnNumber.DataSource = ds1.Tables("VendorReturn")
        con.Close()
        cboReturnNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorIDs()
        cmd = New SqlCommand("SELECT VendorID FROM VendorReturn WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "VendorReturn")
        cboVendorName.DisplayMember = "VendorID"
        cboVendorName.DataSource = ds1.Tables("VendorReturn")
        con.Close()
        cboVendorName.SelectedIndex = -1
    End Sub

    Public Sub LoadPONumbers()
        cmd = New SqlCommand("SELECT PONumber FROM VendorReturn WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "VendorReturn")
        cboPONumber.DisplayMember = "PONumber"
        cboPONumber.DataSource = ds1.Tables("VendorReturn")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        cmd = New SqlCommand("SELECT * FROM VendorReturn WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If Not String.IsNullOrEmpty(cboPONumber.Text) Then
            cmd.CommandText += " AND PONumber = @PONumber"
            cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = cboPONumber.Text
        End If
        If Not String.IsNullOrEmpty(cboReturnNumber.Text) Then
            cmd.CommandText += " AND ReturnNumber = @ReturnNumber"
            cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = cboReturnNumber.Text
        End If
        If Not String.IsNullOrEmpty(cboVendorName.Text) Then
            cmd.CommandText += " AND VendorID = @VendorID"
            cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorName.Text
        End If
      
        If chkDateRange.Checked Then
            cmd.CommandText += " AND ReturnDate BETWEEN @BeginDate AND @EndDate"
            cmd.Parameters.Add("@BeginDate", SqlDbType.Date).Value = dtpBeginDate.Value
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value
        End If

        ds = New DataSet()
        If con.State = ConnectionState.Closed Then con.Open()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "VendorReturn")
        con.Close()

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CRXVendorReturnListing()
        MyReport.SetDataSource(ds)
        CRReturnViewer.ReportSource = MyReport
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        CRReturnViewer.ReportSource = Nothing

        cboPONumber.SelectedIndex = -1
        cboReturnNumber.SelectedIndex = -1
        cboVendorName.SelectedIndex = -1
        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        chkDateRange.Checked = False

        If Not String.IsNullOrEmpty(cboPONumber.Text) Then
            cboPONumber.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboReturnNumber.Text) Then
            cboReturnNumber.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboVendorName.Text) Then
            cboVendorName.Text = ""
        End If
    End Sub
End Class