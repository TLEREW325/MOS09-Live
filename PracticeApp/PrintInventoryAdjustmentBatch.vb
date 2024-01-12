﻿Imports System
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class PrintInventoryAdjustmentBatch
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalInventoryAdjustmentBatchNumber = 0
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRAdjustmentViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRAdjustmentViewer.Load
        'Loads data into dataset for viewing
        cmd = New SqlCommand("SELECT * FROM InventoryAdjustmentTable WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalInventoryAdjustmentBatchNumber

        cmd1 = New SqlCommand("SELECT * FROM AssemblySerialTempTable WHERE DivisionID = @DivisionID", con)
        cmd1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryAdjustmentTable")

        myAdapter1.SelectCommand = cmd1
        myAdapter1.Fill(ds, "AssemblySerialTempTable")

        'Sets up viewer to display data from the loaded dataset
        Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        MyReport = CRXInventoryBatch1
        MyReport.SetDataSource(ds)
        CRAdjustmentViewer.ReportSource = MyReport
        con.Close()
    End Sub
End Class