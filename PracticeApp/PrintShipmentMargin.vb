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
Public Class PrintShipmentMargin
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

    Private Sub CRShipViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRShipViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * from ShipmentHeaderTable where ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ShipmentNUmber", SqlDbType.VarChar).Value = GlobalShipmentNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * from ShipmentLineTable where ShipmentNumber = @ShipmentNumber AND DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@ShipmentNUmber", SqlDbType.VarChar).Value = GlobalShipmentNumber
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ShipmentLineTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXShipmentMarginReport1
        MyReport.SetDataSource(ds)
        CRShipViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class