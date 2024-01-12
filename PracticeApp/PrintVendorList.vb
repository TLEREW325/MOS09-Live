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
Public Class PrintVendorList
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
        cboVendorID.DataSource = ds1.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorClass()
        cmd = New SqlCommand("SELECT VendClassID FROM VendorClass ", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "VendorClass")
        cboVendorClass.DataSource = ds2.Tables("VendorClass")
        con.Close()
        cboVendorClass.SelectedIndex = -1
    End Sub


    Private Sub PrintVendorList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadVendor()
        LoadVendorClass()
        cboVendorClass.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
    End Sub

    Private Sub cmdFilterByVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilterByVendor.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode


        If Not String.IsNullOrEmpty(cboVendorID.Text) Then
            cmd.CommandText += " And VendorCode = @VendorCode"
            cmd.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        End If
        If Not String.IsNullOrEmpty(cboVendorClass.Text) Then
            cmd.CommandText += " AND VendorClass = @VendorClass"
            cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
        End If


        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "Vendor")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXVendorList1
        MyReport.SetDataSource(ds)
        CRVendorViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboVendorClass.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1


        If Not String.IsNullOrEmpty(cboVendorClass.Text) Then
            cboVendorClass.Text = ""
        End If
        If Not String.IsNullOrEmpty(cboVendorClass.Text) Then
            cboVendorID.Text = ""
        End If
        CRVendorViewer.ReportSource = Nothing


    End Sub

End Class