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
Public Class PrintRackingFromPopup
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

    Private Sub CRRackingViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRRackingViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From RackingTransactionTable WHERE (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND PartNumber = @PartNumber ORDER BY BinNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        cmd.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalPartNumberLookup

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "RackingTransactionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXRackingFilter1
        MyReport.SetDataSource(ds)
        MyReport.PrintToPrinter(1, True, 1, 999)
        con.Close()

        Me.Close()
    End Sub
End Class