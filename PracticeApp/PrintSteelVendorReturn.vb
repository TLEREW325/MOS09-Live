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
Public Class PrintSteelVendorReturn
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub CRSteelVendorReturnViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRSteelVendorReturnViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM SteelReturnHeaderTable WHERE SteelReturnNumber = @SteelReturnNumber", con)
        cmd.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelVendorReturnNumber

        cmd1 = New SqlCommand("SELECT * FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber", con)
        cmd1.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelVendorReturnNumber

        cmd2 = New SqlCommand("SELECT * FROM SteelReturnCoilLines WHERE SteelReturnNumber = @SteelReturnNumber", con)
        cmd2.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelVendorReturnNumber

        cmd3 = New SqlCommand("SELECT * FROM RawMaterialsTable", con)
   
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelReturnHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "SteelReturnLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "SteelReturnCoilLines")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "RawMaterialsTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = crxSteelVendorReturn1
        MyReport.SetDataSource(ds)
        CRSteelVendorReturnViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class