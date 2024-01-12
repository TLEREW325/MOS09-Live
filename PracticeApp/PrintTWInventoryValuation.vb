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
Public Class PrintTWInventoryValuation
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

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        cboPartDesc.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboPartDesc.SelectedIndex = -1
    End Sub

    Private Sub CRTWInventoryViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRTWInventoryViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM CurrentInventoryValuation WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CurrentInventoryValuation")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXTWInventoryValuation1
        MyReport.SetDataSource(ds)
        CRTWInventoryViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintTWInventoryValuation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPartNumber()
    End Sub

    Private Sub cmdPartNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPartNumber.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM CurrentInventoryValuation WHERE DivisionID = @DivisionID and PartNumber = @PartNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CurrentInventoryValuation")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXTWInventoryValuation1
        MyReport.SetDataSource(ds)
        CRTWInventoryViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cboPartDesc.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1

        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM CurrentInventoryValuation WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "CurrentInventoryValuation")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXTWInventoryValuation1
        MyReport.SetDataSource(ds)
        CRTWInventoryViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class