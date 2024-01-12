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
Public Class VendorPurchasePopup
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub VendorPurchasePopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GlobalVendorType = "STEEL VENDOR" Then
            ShowSteelPurchaseLines()
            dgvSteelPOQuery.Visible = True
            dgvPOLineQuery.Visible = False
        Else
            ShowPurchaseLines()
            dgvSteelPOQuery.Visible = False
            dgvPOLineQuery.Visible = True
        End If
    End Sub

    Public Sub ShowPurchaseLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND VendorID = @VendorID ORDER BY PODate DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = GlobalVendorID
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PurchaseOrderLineQuery")
        dgvPOLineQuery.DataSource = ds.Tables("PurchaseOrderLineQuery")
        con.Close()
    End Sub

    Public Sub ShowSteelPurchaseLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM SteelPurchaseLineQuery WHERE DivisionID = @DivisionID AND SteelVendorID = @SteelVendorID ORDER BY SteelPurchaseOrderDate DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@SteelVendorID", SqlDbType.VarChar).Value = GlobalVendorID
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "SteelPurchaseLineQuery")
        dgvSteelPOQuery.DataSource = ds2.Tables("SteelPurchaseLineQuery")
        con.Close()
    End Sub
End Class