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
Public Class SOBrokenBoxForm
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub SOBrokenBoxForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        lblHigher.Text = GlobalSalesOrderHigher
        lblLower.Text = GlobalSalesOrderLower
        cmdExit.Focus()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If rdoBrokenBoxCharge.Checked = True Then
            GlobalSalesOrderQuantity = GlobalSalesOrderQuantity
            GlobalBrokenBoxCharge = "YES"
        ElseIf rdoGoUpOneBox.Checked = True Then
            GlobalSalesOrderQuantity = GlobalSalesOrderHigher
            GlobalBrokenBoxCharge = "NO"
        ElseIf rdoGoDownOneBox.Checked = True Then
            GlobalSalesOrderQuantity = GlobalSalesOrderLower
            GlobalBrokenBoxCharge = "NO"
        ElseIf rdoNoCharge.Checked = True Then
            GlobalBrokenBoxCharge = "NO"
        End If
        Me.Dispose()
        Me.Close()
    End Sub
End Class