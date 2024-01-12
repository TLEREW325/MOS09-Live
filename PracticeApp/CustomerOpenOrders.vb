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
Public Class CustomerOpenOrders
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Public Sub ShowOpenSOLines()
        cmd = New SqlCommand("SELECT * FROM SalesOrderLineQueryQOH WHERE DivisionKey = @DivisionKey AND CustomerID = @CustomerID AND OpenSOQuantity > 0 AND SOStatus <> @SOStatus AND LineStatus <> @LineStatus ORDER BY SalesOrderKey ASC", con)
        cmd.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SalesOrderLineQueryQOH")
        dgvCustomerOpenOrders.DataSource = ds.Tables("SalesOrderLineQueryQOH")
        con.Close()
    End Sub

    Public Sub LoadTotalSales()
        'Get Rack Totals
        Dim TotalOpenOrders As Double = 0
        Dim strTotalOpenOrders As String = ""

        Dim TotalOpenOrdersStatement As String = "SELECT SUM(OpenExtendedAmount) FROM SalesOrderQuantityStatus WHERE CustomerID = @CustomerID AND QuantityOpen > 0 AND SOStatus <> @SOStatus AND LineStatus <> @LineStatus AND DivisionKey = @DivisionKey"
        Dim TotalOpenOrdersCommand As New SqlCommand(TotalOpenOrdersStatement, con)
        TotalOpenOrdersCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = GlobalCustomerID
        TotalOpenOrdersCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = GlobalDivisionCode
        TotalOpenOrdersCommand.Parameters.Add("@SOStatus", SqlDbType.VarChar).Value = "QUOTE"
        TotalOpenOrdersCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalOpenOrders = CDbl(TotalOpenOrdersCommand.ExecuteScalar)
            TotalOpenOrders = Math.Round(TotalOpenOrders, 2)
        Catch ex As System.Exception
            TotalOpenOrders = 0
        End Try
        con.Close()

        strTotalOpenOrders = CStr(TotalOpenOrders)

        lblTotalOpenOrders.Text = strTotalOpenOrders + " total open sales for this customer."
    End Sub

    Private Sub CustomerOpenOrders_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GDS = New DataSet()
        ds = New DataSet()
        GlobalCustomerID = ""
    End Sub

    Private Sub CustomerOpenOrders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowOpenSOLines()
        LoadTotalSales()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintOpenSalesOrderLineReport As New PrintOpenSalesOrderLineReport
            Dim Result = NewPrintOpenSalesOrderLineReport.ShowDialog
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GDS = New DataSet()
        ds = New DataSet()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GDS = New DataSet()
        ds = New DataSet()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvCustomerOpenOrders_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCustomerOpenOrders.CellDoubleClick
        Dim RowSONumber As Integer

        Dim RowIndex As Integer = Me.dgvCustomerOpenOrders.CurrentCell.RowIndex

        RowSONumber = Me.dgvCustomerOpenOrders.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value

        GlobalSONumber = RowSONumber

        'Choose correct print form
        If GlobalDivisionCode = "TFP" Then
            Using NewPrintTFAcknowledgement As New PrintTFAcknowledgement
                Dim result = NewPrintTFAcknowledgement.ShowDialog()
            End Using
        Else
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

    Private Sub cmdSOForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSOForm.Click
        Dim RowSONumber As Integer
        Dim RowIndex As Integer = Me.dgvCustomerOpenOrders.CurrentCell.RowIndex

        RowSONumber = Me.dgvCustomerOpenOrders.Rows(RowIndex).Cells("SalesOrderKeyColumn").Value

        GlobalSONumber = RowSONumber
        GlobalDivisionCode = EmployeeCompanyCode

        Dim NewSOForm As New SOForm
        NewSOForm.Show()

        Me.Dispose()
        Me.Close()
    End Sub

End Class