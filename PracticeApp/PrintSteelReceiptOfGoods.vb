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
Public Class PrintSteelReceiptOfGoods
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub CRReceiptViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRReceiptViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM SteelReceivingHeaderTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)
        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceivingNumber

        cmd1 = New SqlCommand("SELECT * FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey", con)
        cmd1.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalSteelReceivingNumber

        cmd2 = New SqlCommand("SELECT * FROM RawMaterialsTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelReceivingHeaderTable")

        myAdapter.SelectCommand = cmd1
        myAdapter.Fill(ds, "SteelReceivingLineTable")

        myAdapter.SelectCommand = cmd2
        myAdapter.Fill(ds, "RawMaterialsTable")
        con.Close()
        Dim cnt As Integer = ds.Tables("SteelReceivingHeaderTable").Rows.Count
        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXSteelReceipt1
        MyReport.SetDataSource(ds)
        CRReceiptViewer.ReportSource = MyReport

    End Sub
End Class