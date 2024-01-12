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
Public Class PrintShippingBOLMultiple
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub CRBOLViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRBOLViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From ShipmentBOLTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = GlobalBOLNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * From ShipmentBOLLineTable WHERE ShipmentBOLNumber = @ShipmentBOLNumber AND DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@ShipmentBOLNumber", SqlDbType.VarChar).Value = GlobalBOLNumber
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * From DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ShipmentBOLTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "ShipmentBOLLineTable")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXBOL_Multiple1
        MyReport.SetDataSource(ds)
        CRBOLViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class