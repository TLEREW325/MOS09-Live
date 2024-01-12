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
Public Class PrintSOWorkOrder
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRWorkOrderViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRWorkOrderViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * From SalesOrderHeaderTable WHERE DivisionKey = @DivisionKey AND SalesOrderKey = @SalesOrderKey", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber

        cmd1 = New SqlCommand("SELECT * From SalesOrderLineQueryQOH WHERE DivisionKey = @DivisionKey AND SalesOrderKey = @SalesOrderKey", con)
        cmd1.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd1.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber

        cmd2 = New SqlCommand("SELECT * From CustomerList WHERE DivisionID = @DivisionID", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "SalesOrderLineQueryQOH")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(ds, "CustomerList")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXSOWorkOrder1
        MyReport.SetDataSource(ds)
        CRWorkOrderViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintSOWorkOrder_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalDivisionCode = ""
        GlobalSONumber = 0
    End Sub
End Class