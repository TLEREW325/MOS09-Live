﻿Imports System
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
Public Class PrintProductionSchedulingList2
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        'Clear Temp Table First
        cmd = New SqlCommand("DELETE FROM FOXTempBlanksTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRProductionViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRProductionViewer.Load
        'Loads data into dataset for viewing
        ds = GDS

        cmd = New SqlCommand("SELECT * FROM FOXTempBlanksTable WHERE FOXNumber <> 0", con)

        cmd1 = New SqlCommand("SELECT * FROM SalesOrderMinLeadTime", con)

        If con.State = ConnectionState.Closed Then con.Open()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "FOXTempBlanksTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "SalesOrderMinLeadTime")

        'Sets up viewer to display data from the loaded dataset
        MyReport = CRXProductionListing21
        MyReport.SetDataSource(ds)
        CRProductionViewer.ReportSource = MyReport
        con.Close()
    End Sub

    Private Sub PrintProductionSchedulingList2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Clear Temp Table First
        cmd = New SqlCommand("DELETE FROM FOXTempBlanksTable", con)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class