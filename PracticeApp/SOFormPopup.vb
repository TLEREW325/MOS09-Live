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
Public Class SOFormPopup
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    Private Sub cmdSalesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalesOrder.Click
        GlobalGoToSalesOrder = "YES"
        GlobalGoToShipment = "NO"
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdShipmentForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShipmentForm.Click
        GlobalGoToSalesOrder = "NO"
        GlobalGoToShipment = "YES"
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub SOFormPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GlobalGoToSalesOrder = "YES"
        GlobalGoToShipment = "NO"
        cmdSalesOrder.Focus()
    End Sub
End Class