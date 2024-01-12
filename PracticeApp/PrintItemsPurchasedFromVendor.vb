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
Public Class PrintItemsPurchasedFromVendor
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub PrintItemsPurchasedFromVendor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadVendorList()
        LoadPartNumber()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadVendorList()
        cmd = New SqlCommand("SELECT VendorCode, VendorName FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "Vendor")
        cboVendor.DataSource = ds2.Tables("Vendor")
        cboVendorName.DataSource = ds2.Tables("Vendor")
        con.Close()
        cboVendor.SelectedIndex = -1
        cboVendorName.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboPartNumber.DataSource = ds3.Tables("ItemList")
        cboPartDescription.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

  

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ReceivingHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode


        cmd1 = New SqlCommand("SELECT * FROM ReceivingLineTable WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If Not String.IsNullOrEmpty(cboVendor.Text) Then
            cmd.CommandText += " and VendorCode = @VendorCode"
            cmd.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendor.Text
        End If

        If chkDateRange.Checked Then
            cmd.CommandText += " and ReceivingDate between @BeginDate and @EndDate"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        End If

        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cmd1.CommandText += " and PartNumber = @PartNumber"
            cmd1.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        End If



        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceivingHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ReceivingLineTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXItemsPurVendor1
        MyReport.SetDataSource(ds)
        CRItemViewer.ReportSource = MyReport
        con.Close()
    End Sub

    
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        CRItemViewer.ReportSource = Nothing
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboVendor.SelectedIndex = -1
        cboVendorName.SelectedIndex = -1
        dtpBeginDate.Value = Now
        dtpEndDate.Value = Now
        chkDateRange.Checked = False
        If Not String.IsNullOrEmpty(cboVendor.Text) Then
            cboVendor.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboVendorName.Text) Then
            cboVendorName.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboPartDescription.Text) Then
            cboPartDescription.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboPartNumber.Text) Then
            cboPartNumber.Text = ""
        End If
    End Sub
End Class