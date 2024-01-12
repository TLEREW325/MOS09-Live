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
Public Class PickTicketDeleted
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub LoadPickTicketNumber()
        'Create commands to load Pick Ticket
        cmd = New SqlCommand("SELECT PickListHeaderKey FROM PickListHeaderTable WHERE DivisionID = @DivisionID AND PLStatus = @PLStatus AND SalesOrderHeaderKey = @SalesOrderHeaderKey", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@SalesOrderHeaderKey", SqlDbType.VarChar).Value = GlobalSONumber
        cmd.Parameters.Add("@PLStatus", SqlDbType.VarChar).Value = "PICKED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PickListHeaderTable")
        cboPickTicket.DataSource = ds.Tables("PickListHeaderTable")
        con.Close()
        cboPickTicket.SelectedIndex = -1
    End Sub

    Private Sub PickTicketDeleted_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPickTicketNumber()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'Delete Pick Ticket
        cmd = New SqlCommand("DELETE FROM PickListHeaderTable WHERE PickListHeaderKey = @PickListHeaderKey AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@PickListHeaderKey", SqlDbType.VarChar).Value = Val(cboPickTicket.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Delete Pending Shipments if any
        cmd = New SqlCommand("DELETE FROM ShipmentHeaderTable WHERE PickTicketNumber = @PickTicketNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@PickTicketNumber", SqlDbType.VarChar).Value = Val(cboPickTicket.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Re-Open Sales Order Header
        cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET SOStatus = @SOStatus WHERE SalesOrderKey = @SalesOrderKey", con)
        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Re-Open Sales Order Lines
        cmd = New SqlCommand("UPDATE SalesOrderLineTable SET LineStatus = @LineStatus WHERE SalesOrderKey = @SalesOrderKey And LineStatus = @LineStatus1", con)
        cmd.Parameters.Add("@SalesOrderKey", SqlDbType.VarChar).Value = GlobalSONumber
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
        cmd.Parameters.Add("@LineStatus1", SqlDbType.VarChar).Value = "COMMITTED"

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        MsgBox("Pick Ticket has been deleted and Sales is re-opened.", MsgBoxStyle.OkOnly)
    End Sub
End Class