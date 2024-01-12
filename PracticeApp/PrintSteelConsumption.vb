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
Public Class PrintSteelConsumption
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Public Sub LoadRawMaterials()
        cmd = New SqlCommand("SELECT RMID, SteelSize, Carbon FROM RawMaterialsTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "RawMaterialsTable")
        cboCarbon.DataSource = ds5.Tables("RawMaterialsTable")
        cboRMID.DataSource = ds5.Tables("RawMaterialsTable")
        cboSteelSize.DataSource = ds5.Tables("RawMaterialsTable")
        con.Close()
        cboCarbon.SelectedIndex = -1
        cboRMID.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRLineViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRLineViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * from SteelUsageQuery where DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelUsageQuery")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXSteelConsumptionLines1
        MyReport.SetDataSource(ds)
        CRLineViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintSteelConsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadRawMaterials()
    End Sub

    Private Sub cmdRMID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRMID.Click
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * from SteelUsageQuery where DivisionID = @DivisionID and RMID= @RMID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = cboRMID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelUsageQuery")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXSteelConsumptionLines1
        MyReport.SetDataSource(ds)
        CRLineViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        cboCarbon.SelectedIndex = -1
        cboRMID.SelectedIndex = -1
        cboSteelSize.SelectedIndex = -1

        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * from SteelUsageQuery where DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelUsageQuery")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXSteelConsumptionLines1
        MyReport.SetDataSource(ds)
        CRLineViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class