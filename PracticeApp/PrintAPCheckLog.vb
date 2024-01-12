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
Public Class PrintAPCheckLog
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

    Private Sub CRCheckViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRCheckViewer.Load
        If GlobalAPBatchNumber > 0 Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM APCheckLog WHERE DivisionID = @DivisionID AND APBatchNumber = @APBatchNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = GlobalAPBatchNumber

            cmd2 = New SqlCommand("SELECT * FROM APCheckLines", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "APCheckLog")

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "APCheckLines")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXAPCheckLog1
            MyReport.SetDataSource(ds)
            CRCheckViewer.ReportSource = MyReport
            con.Close()
        Else
            ds = GDS

            cmd2 = New SqlCommand("SELECT * FROM APCheckLines", con)

            If con.State = ConnectionState.Closed Then con.Open()

            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds, "APCheckLines")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXAPCheckLog1
            MyReport.SetDataSource(ds)
            CRCheckViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub
End Class