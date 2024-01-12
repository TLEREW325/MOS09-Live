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
Public Class SOManufacturedCostPopup
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Public Sub ShowCostLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT TOP 15 TransactionDate, TransactionType, PartNumber, Quantity, ItemCost, DivisionID FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND TransactionType = @TransactionType ORDER BY TransactionDate DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalPOPartNumber
        cmd.Parameters.Add("@TransactionType", SqlDbType.VarChar).Value = "Post Production"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InventoryTransactionTable")
        dgvInventoryTransactions.DataSource = ds.Tables("InventoryTransactionTable")
        con.Close()
    End Sub

    Private Sub SOManufacturedCostPopup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalPOPartNumber = ""
        GlobalDivisionCode = ""
    End Sub

    Private Sub SOManufacturedCostPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowCostLines()
    End Sub
End Class