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
Public Class POQuantityOnHand
    Inherits System.Windows.Forms.Form

    Dim QuantityOnHand, QuantityCommitted As Double
    Dim PartNumber, PartDecription As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet
    Dim dt As DataTable

    Private Sub POQuantityOnHand_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lblPartDescription.Text = ""
        lblPartNumber.Text = ""
        lblQOH.Text = ""
        lblQuantityCommitted.Text = ""
        QuantityOnHand = 0
        QuantityCommitted = 0
    End Sub

    Private Sub POQuantityOnHand_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblPartNumber.Text = GlobalPOPartNumber
        lblPartDescription.Text = GlobalPOPartDescription

        LoadQuantityOnHand()
    End Sub

    Public Sub LoadQuantityOnHand()
        Dim QOHString As String = "SELECT QuantityOnHand FROM ADMInventoryTotal WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim QOHCommand As New SqlCommand(QOHString, con)
        QOHCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GlobalPOPartNumber
        QOHCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        QuantityOnHand = CDbl(QOHCommand.ExecuteScalar)
        con.Close()

        lblQOH.Text = FormatNumber(QuantityOnHand, 2)

        'Load quantity pending (pending shipment lines)
        Dim QuantityPendingString As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND LineStatus = @LineStatus"
        Dim QuantityPendingCommand As New SqlCommand(QuantityPendingString, con)
        QuantityPendingCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalPOPartNumber
        QuantityPendingCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        QuantityPendingCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            QuantityCommitted = CDbl(QuantityPendingCommand.ExecuteScalar)
        Catch ex As Exception
            QuantityCommitted = 0
        End Try
        con.Close()

        lblQuantityCommitted.Text = FormatNumber(QuantityCommitted, 2)
    End Sub
End Class