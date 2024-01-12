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
Public Class PrintShipmentBarCodes
    Inherits System.Windows.Forms.Form

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

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

    Private Sub CRShipmentViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRShipmentViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM ShipmentLotLineQuery WHERE ShipmentNumber = @ShipmentNumber", con)
        cmd.Parameters.Add("@ShipmentNumber", SqlDbType.VarChar).Value = GlobalShipmentNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentLotLineQuery")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXShipmentLotsScanning1
        MyReport.SetDataSource(ds)
        CRShipmentViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class