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
Public Class FerruleProductionScheduling
    Inherits System.Windows.Forms.Form


    'Set up variables and database connection
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=60")

    Dim cmd, cmd1 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable
    Dim TWDDataset As DataSet
    Dim TWDAdapter As New SqlDataAdapter

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadFerruleStockStatus()
        'Load Datagrid
        cmd = New SqlCommand("SELECT * FROM ADMInventoryTotal WHERE DivisionID = 'TWD' AND ItemClass = 'FERRULE'", con)
        If con.State = ConnectionState.Closed Then con.Open()
        TWDDataset = New DataSet()
        TWDAdapter.SelectCommand = cmd
        TWDAdapter.Fill(TWDDataset, "ADMInventoryTotal")
        dgvFerruleStatus.DataSource = TWDDataset.Tables("ADMInventoryTotal")
        con.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdLoadProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadProduction.Click
        LoadFerruleStockStatus()
        LoadSuggestedProduction()
    End Sub

    Public Sub LoadSuggestedProduction()
        Dim RowPartNumber As String = ""
        Dim RowQOH, RowMaxStock, RowMinStock, RowOpenQuantity, RowPieceWeight As Double
        Dim ProductionQuantity As Double = 0
        Dim ProductionWeight As Double = 0

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvFerruleStatus.Rows
            Try
                RowPartNumber = row.Cells("ItemIDColumn").Value
            Catch ex As System.Exception
                RowPartNumber = ""
            End Try
            Try
                RowQOH = row.Cells("QuantityOnHandColumn").Value
            Catch ex As System.Exception
                RowQOH = 0
            End Try
            Try
                RowMaxStock = row.Cells("MaximumStockColumn").Value
            Catch ex As System.Exception
                RowMaxStock = 0
            End Try
            Try
                RowMinStock = row.Cells("MinimumStockColumn").Value
            Catch ex As System.Exception
                RowMinStock = 0
            End Try
            Try
                RowOpenQuantity = row.Cells("OpenSOQuantityColumn").Value
            Catch ex As System.Exception
                RowOpenQuantity = 0
            End Try
            Try
                RowPieceWeight = row.Cells("PieceWeightColumn").Value
            Catch ex As System.Exception
                RowPieceWeight = 0
            End Try

            If RowQOH > RowMinStock + RowOpenQuantity Then
                ProductionQuantity = 0
            Else
                ProductionQuantity = (RowMaxStock + RowOpenQuantity) - RowQOH
            End If

            ProductionWeight = ProductionQuantity * RowPieceWeight
            ProductionWeight = Math.Round(ProductionWeight, 0)

            Me.dgvFerruleStatus.Rows(RowIndex).Cells("SuggestedProductionColumn").Value = ProductionQuantity
            Me.dgvFerruleStatus.Rows(RowIndex).Cells("SuggestedProductionWeightColumn").Value = ProductionWeight

            If ProductionQuantity > 0 Then
                Me.dgvFerruleStatus.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightSkyBlue
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub LoadFormatting()
        '    Dim InvoiceStatus As String = ""
        '    Dim RowIndex As Integer = 0

        '    For Each row As DataGridViewRow In dgvFerruleStatus.Rows
        '        Try
        '            InvoiceStatus = row.Cells("InvoiceStatusColumn").Value
        '        Catch ex As System.Exception
        '            InvoiceStatus = ""
        '        End Try

        '        If InvoiceStatus = "OPEN" Then
        '            Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
        '            Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
        '        ElseIf InvoiceStatus = "CLOSED" Then
        '            Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
        '            Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.DarkBlue
        '        ElseIf InvoiceStatus = "PENDING" Then
        '            Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
        '            Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Red
        '        ElseIf InvoiceStatus = "BILL ONLY" Then
        '            Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
        '            Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Green
        '        Else
        '            Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
        '            Me.dgvInvoiceHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
        '        End If

        '        RowIndex = RowIndex + 1
        '    Next
    End Sub

    Private Sub cmdClearProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearProduction.Click
        Me.dgvFerruleStatus.DataSource = Nothing
    End Sub

    Private Sub FerruleProductionScheduling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvFerruleStatus_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvFerruleStatus.ColumnHeaderMouseClick
        Dim RowPartNumber As String = ""
        Dim RowQOH, RowMaxStock, RowMinStock, RowOpenQuantity, RowPieceWeight As Double
        Dim ProductionQuantity As Double = 0
        Dim ProductionWeight As Double = 0

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvFerruleStatus.Rows
            Try
                RowPartNumber = row.Cells("ItemIDColumn").Value
            Catch ex As System.Exception
                RowPartNumber = ""
            End Try
            Try
                RowQOH = row.Cells("QuantityOnHandColumn").Value
            Catch ex As System.Exception
                RowQOH = 0
            End Try
            Try
                RowMaxStock = row.Cells("MaximumStockColumn").Value
            Catch ex As System.Exception
                RowMaxStock = 0
            End Try
            Try
                RowMinStock = row.Cells("MinimumStockColumn").Value
            Catch ex As System.Exception
                RowMinStock = 0
            End Try
            Try
                RowOpenQuantity = row.Cells("OpenSOQuantityColumn").Value
            Catch ex As System.Exception
                RowOpenQuantity = 0
            End Try
            Try
                RowPieceWeight = row.Cells("PieceWeightColumn").Value
            Catch ex As System.Exception
                RowPieceWeight = 0
            End Try

            If RowQOH > RowMinStock + RowOpenQuantity Then
                ProductionQuantity = 0
            Else
                ProductionQuantity = (RowMaxStock + RowOpenQuantity) - RowQOH
            End If

            ProductionWeight = ProductionQuantity * RowPieceWeight
            ProductionWeight = Math.Round(ProductionWeight, 0)

            Me.dgvFerruleStatus.Rows(RowIndex).Cells("SuggestedProductionColumn").Value = ProductionQuantity
            Me.dgvFerruleStatus.Rows(RowIndex).Cells("SuggestedProductionWeightColumn").Value = ProductionWeight

            If ProductionQuantity > 0 Then
                Me.dgvFerruleStatus.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightSkyBlue
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub dgvFerruleStatus_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFerruleStatus.Sorted
        Dim RowPartNumber As String = ""
        Dim RowQOH, RowMaxStock, RowMinStock, RowOpenQuantity, RowPieceWeight As Double
        Dim ProductionQuantity As Double = 0
        Dim ProductionWeight As Double = 0

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvFerruleStatus.Rows
            Try
                RowPartNumber = row.Cells("ItemIDColumn").Value
            Catch ex As System.Exception
                RowPartNumber = ""
            End Try
            Try
                RowQOH = row.Cells("QuantityOnHandColumn").Value
            Catch ex As System.Exception
                RowQOH = 0
            End Try
            Try
                RowMaxStock = row.Cells("MaximumStockColumn").Value
            Catch ex As System.Exception
                RowMaxStock = 0
            End Try
            Try
                RowMinStock = row.Cells("MinimumStockColumn").Value
            Catch ex As System.Exception
                RowMinStock = 0
            End Try
            Try
                RowOpenQuantity = row.Cells("OpenSOQuantityColumn").Value
            Catch ex As System.Exception
                RowOpenQuantity = 0
            End Try
            Try
                RowPieceWeight = row.Cells("PieceWeightColumn").Value
            Catch ex As System.Exception
                RowPieceWeight = 0
            End Try

            If RowQOH > RowMinStock + RowOpenQuantity Then
                ProductionQuantity = 0
            Else
                ProductionQuantity = (RowMaxStock + RowOpenQuantity) - RowQOH
            End If

            ProductionWeight = ProductionQuantity * RowPieceWeight
            ProductionWeight = Math.Round(ProductionWeight, 0)

            Me.dgvFerruleStatus.Rows(RowIndex).Cells("SuggestedProductionColumn").Value = ProductionQuantity
            Me.dgvFerruleStatus.Rows(RowIndex).Cells("SuggestedProductionWeightColumn").Value = ProductionWeight

            If ProductionQuantity > 0 Then
                Me.dgvFerruleStatus.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightSkyBlue
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub cmdPrintproduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintproduction.Click
        Using NewPrintFerruleProduction As New PrintFerruleProductionScheduling
            Dim Result = NewPrintFerruleProduction.ShowDialog()
        End Using
    End Sub

    Private Sub dgvFerruleStatus_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFerruleStatus.CellContentClick

    End Sub
End Class