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
Public Class PrintGLJournalAuto
    Inherits System.Windows.Forms.Form

    Dim FindLotNumber, PrintCerts As String
    Dim CountLines, ShipmentLineNumber As Integer

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    Private Sub CRJournalViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRJournalViewer.Load
        cmd = New SqlCommand("SELECT * FROM GLJournalHeaderTable WHERE GLJournalBatchNumber = @GLJournalBatchNumber", con)
        cmd.Parameters.Add("@GLJournalBatchNumber", SqlDbType.VarChar).Value = GlobalGLBatchNumber

        cmd1 = New SqlCommand("SELECT * FROM GLJournalLineTable WHERE GLBatchNumber = @GLBatchNumber", con)
        cmd1.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = GlobalGLBatchNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLJournalHeaderTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "GLJournalLineTable")

        con.Close()

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXGLJournalFiltered1
        MyReport.SetDataSource(ds)
        MyReport.PrintToPrinter(1, True, 1, 999)
        con.Close()

        'Close form
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PrintGLJournalAuto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class