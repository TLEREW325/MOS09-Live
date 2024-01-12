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
Public Class PrintGLTransactionByAccount
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalLedgerPrintForm = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CRAccountViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CRAccountViewer.Load
        'Loads data into dataset for viewing
        ds = GDS

        If GlobalLedgerPrintForm = "ARCHIVE" Then
            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXGLTransactionsByAccountArchived1
            MyReport.SetDataSource(ds)
            CRAccountViewer.ReportSource = MyReport
            con.Close()
        ElseIf GlobalLedgerPrintForm = "LIVE" Then
            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXGLTransactionsByAccount1
            MyReport.SetDataSource(ds)
            CRAccountViewer.ReportSource = MyReport
            con.Close()
        Else
            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXGLTransactionsByAccount1
            MyReport.SetDataSource(ds)
            CRAccountViewer.ReportSource = MyReport
            con.Close()
        End If
    End Sub

    Private Sub PrintGLTransactionByAccount_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalLedgerPrintForm = ""
    End Sub
End Class