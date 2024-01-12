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
Public Class PrintAssemblyBuildBOM
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

    Private Sub CRBuildViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRBuildViewer.Load
        'Loads data into dataset for viewing
        If GlobalAssemblyTransactionNumber = 0 Then
            cmd = New SqlCommand("SELECT * FROM AssemblyBuildHeaderTable WHERE BuildTransactionNumber = @BuildTransactionNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalAssemblyTransactionNumber

            cmd1 = New SqlCommand("SELECT * FROM AssemblyBuildLineTable", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "AssemblyBuildHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "AssemblyBuildLineTable")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXAssemblyBuildBOM1
            MyReport.SetDataSource(ds)
            CRBuildViewer.ReportSource = MyReport
            con.Close()
        Else
            cmd = New SqlCommand("SELECT * FROM AssemblyBuildHeaderTable WHERE BuildTransactionNumber = @BuildTransactionNumber", con)
            cmd.Parameters.Add("@BuildTransactionNumber", SqlDbType.VarChar).Value = GlobalAssemblyTransactionNumber

            cmd1 = New SqlCommand("SELECT * FROM AssemblyBuildLineTable", con)

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "AssemblyBuildHeaderTable")

            myAdapter1.SelectCommand = cmd1
            myAdapter1.Fill(ds, "AssemblyBuildLineTable")

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXAssemblyBuildBOM1
            MyReport.SetDataSource(ds)
            CRBuildViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub
End Class