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
Public Class PrintDropShipListing
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRPOViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRPOViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID AND Status = @Status", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "DROPSHIP"

        cmd1 = New SqlCommand("SELECT * FROM PurchaseOrderLineTable WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PurchaseOrderHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "PurchaseOrderLineTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXDropShipListing1
        MyReport.SetDataSource(ds)
        CRPOViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class