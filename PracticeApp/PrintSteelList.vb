﻿Imports System
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
Public Class PrintSteelList
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalSteelListFromRM = ""
        ds = Nothing
        GDS = Nothing

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRSteelViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRSteelViewer.Load
        If GlobalSteelListFromRM = "RAW MATERIALS" Then
            'Loads data into dataset for viewing
            cmd = New SqlCommand("SELECT * FROM SteelInventoryTotals WHERE SteelStatus <> @SteelStatus", con)
            cmd.Parameters.Add("@SteelStatus", SqlDbType.VarChar).Value = "CLOSED"

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()

            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "SteelInventoryTotals")
        Else
            ds = GDS
        End If

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXSteelList1
        MyReport.SetDataSource(ds)
        CRSteelViewer.ReportSource = MyReport
    End Sub

    Private Sub PrintSteelList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalSteelListFromRM = ""
        ds = Nothing
        GDS = Nothing
    End Sub
End Class