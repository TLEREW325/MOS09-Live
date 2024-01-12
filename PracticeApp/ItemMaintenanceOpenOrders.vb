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
Public Class ItemMaintenanceOpenOrders
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ItemMaintenanceOpenOrders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowOpenSOLines()
        LoadTotalQuantity()
    End Sub

    Public Sub ShowOpenSOLines()
        cmd = New SqlCommand("SELECT * FROM SalesOrderQuantityStatus WHERE DivisionKey = @DivisionKey AND QuantityOpen > 0 AND SOStatus <> @SOStatus AND LineStatus <> @LineStatus AND ItemID = @ItemID ORDER BY CustomerID, SalesOrderDate", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GlobalMaintenancePartNumber

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderQuantityStatus")
        dgvOpenLines.DataSource = ds.Tables("SalesOrderQuantityStatus")
        con.Close()

        FormatDataGrid()
    End Sub

    Public Sub FormatDataGrid()
        Dim RowIndex As Integer = 0
        Dim LineLineStatus As String = ""

        For Each row As DataGridViewRow In dgvOpenLines.Rows
            Try
                LineLineStatus = row.Cells("LineStatusColumn").Value
            Catch ex As System.Exception
                LineLineStatus = ""
            End Try

            If LineLineStatus = "DROPSHIP" Then
                Me.dgvOpenLines.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            Else
                Me.dgvOpenLines.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub LoadTotalQuantity()
        'Get Rack Totals
        Dim TotalQuantity As Double = 0
        Dim strTotalQuantity As String = ""

        Dim TotalQuantityStatement As String = "SELECT SUM(QuantityOpen) FROM SalesOrderQuantityStatus WHERE DivisionKey = @DivisionKey AND QuantityOpen > 0 AND SOStatus <> @SOStatus AND LineStatus <> @LineStatus AND ItemID = @ItemID"
        Dim TotalQuantityCommand As New SqlCommand(TotalQuantityStatement, con)
        TotalQuantityCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        TotalQuantityCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        TotalQuantityCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
        TotalQuantityCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = GlobalMaintenancePartNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantity = CDbl(TotalQuantityCommand.ExecuteScalar)
            TotalQuantity = Math.Round(TotalQuantity, 0)
        Catch ex As System.Exception
            TotalQuantity = 0
        End Try
        con.Close()

        strTotalQuantity = CStr(TotalQuantity)

        lblTotalPartQuantity.Text = strTotalQuantity + " total quantity open for this part."
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalMaintenancePartNumber = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalMaintenancePartNumber = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvOpenLines_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOpenLines.CellDoubleClick
        Dim RowSONumber As Integer

        If Me.dgvOpenLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvOpenLines.CurrentCell.RowIndex

            RowSONumber = Me.dgvOpenLines.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value

            GlobalSONumber = RowSONumber

            'Choose the correct Print Form (REMOTE or LOCAL)

            'Get Login Type
            Dim GetLoginType As String = ""

            Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
            Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
            GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
            Catch ex As System.Exception
                GetLoginType = ""
            End Try
            con.Close()

            If GetLoginType = "REMOTE" Then
                Using NewPrintSalesOrderRemote As New PrintSalesOrderRemote
                    Dim result = NewPrintSalesOrderRemote.ShowDialog()
                End Using
            Else
                Using NewPrintSalesOrder As New PrintSalesOrder
                    Dim result = NewPrintSalesOrder.ShowDialog()
                End Using
            End If
        End If
    End Sub
End Class