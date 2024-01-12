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
Public Class PrintPOShipper
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub CRPurchaseViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRPurchaseViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderHeaderTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalPONumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd1 = New SqlCommand("SELECT * FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalPONumber
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd2 = New SqlCommand("SELECT * FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        cmd3 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd3.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PurchaseOrderHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "PurchaseOrderLineTable")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "Vendor")

        myAdapter3.SelectCommand = cmd3
        myAdapter3.Fill(ds, "DivisionTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXPOShipper1
        MyReport.SetDataSource(ds)
        CRPurchaseViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalPONumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintPOShipper_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        GlobalPONumber = 0
    End Sub
End Class