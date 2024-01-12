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
Public Class SOPurchaseCostPopup
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub SOPurchaseCostPopup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowPurchaseLines()
    End Sub

    Public Sub ShowPurchaseLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT TOP 15 ReceivingDate, PartNumber, QuantityReceived, UnitCost, VendorCode, PONumber, POLineNumber FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber ORDER BY ReceivingDate DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalPOPartNumber
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceivingLineQuery")
        dgvLastPurchaseCost.DataSource = ds.Tables("ReceivingLineQuery")
        con.Close()

        LoadPOCost()
    End Sub

    Public Sub LoadPOCost()
        If Me.dgvLastPurchaseCost.RowCount <> 0 Then
            Dim PONumber As Integer = 0
            Dim POLineNumber As Integer = 0
            Dim POUnitCost As Double = 0

            Dim RowIndex As Integer = 0
            Dim RowCount As Integer = Me.dgvLastPurchaseCost.RowCount

            For i As Integer = 1 To RowCount
                PONumber = Me.dgvLastPurchaseCost.Rows(RowIndex).Cells("PONumberColumn").Value
                POLineNumber = Me.dgvLastPurchaseCost.Rows(RowIndex).Cells("POLineNumberColumn").Value

                'Get PO Cost
                Dim GetPOCostStatement As String = "SELECT UnitCost FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND PurchaseOrderLineNumber = @PurchaseOrderLineNumber"
                Dim GetPOCostCommand As New SqlCommand(GetPOCostStatement, con)
                GetPOCostCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = PONumber
                GetPOCostCommand.Parameters.Add("@PurchaseOrderLineNumber", SqlDbType.VarChar).Value = POLineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    POUnitCost = CDbl(GetPOCostCommand.ExecuteScalar)
                Catch ex As Exception
                    POUnitCost = 0
                End Try
                con.Close()

                Me.dgvLastPurchaseCost.Rows(RowIndex).Cells("POCostColumn").Value = POUnitCost
      
                RowIndex = RowIndex + 1
            Next i
        End If
    End Sub

    Private Sub dgvLastPurchaseCost_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLastPurchaseCost.Sorted
        LoadPOCost()
    End Sub
End Class