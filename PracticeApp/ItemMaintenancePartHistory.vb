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
Public Class ItemMaintenancePartHistory
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ItemMaintenancePartHistory_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ds = New DataSet()
        GDS = New DataSet()
        GlobalMaintenancePartNumber = ""
    End Sub

    Private Sub ItemMaintenancePartHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowData()
        LoadTotalSales()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND InvoiceStatus <> @InvoiceStatus AND QuantityBilled > 0 ORDER BY InvoiceHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        cmd.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalMaintenancePartNumber
        cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceLineQuery")
        dgvInvoiceLineQuery.DataSource = ds.Tables("InvoiceLineQuery")
        con.Close()
    End Sub

    Public Sub LoadTotalSales()
        'Get Rack Totals
        Dim TotalSales As Double = 0
        Dim strTotalSales As String = ""

        Dim TotalSalesStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
        Dim TotalSalesCommand As New SqlCommand(TotalSalesStatement, con)
        TotalSalesCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = GlobalMaintenancePartNumber
        TotalSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalSales = CDbl(TotalSalesCommand.ExecuteScalar)
            TotalSales = Math.Round(TotalSales, 2)
        Catch ex As System.Exception
            TotalSales = 0
        End Try
        con.Close()

        strTotalSales = CStr(TotalSales)

        lblTotalPartDollars.Text = strTotalSales + " total sales for this part."
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintCustomerSalesList As New PrintCustomerSalesList
            Dim result = NewPrintCustomerSalesList.ShowDialog()
        End Using
    End Sub

    Private Sub dgvInvoiceLineQuery_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceLineQuery.CellDoubleClick
        Dim RowInvoiceNumber, RowShipmentNumber, RowSONumber As Integer

        Dim RowIndex As Integer = Me.dgvInvoiceLineQuery.CurrentCell.RowIndex

        RowInvoiceNumber = Me.dgvInvoiceLineQuery.Rows(RowIndex).Cells("InvoiceHeaderKeyColumn").Value
        RowShipmentNumber = Me.dgvInvoiceLineQuery.Rows(RowIndex).Cells("ShipmentNumberColumn").Value
        RowSONumber = Me.dgvInvoiceLineQuery.Rows(RowIndex).Cells("SalesOrderNumberColumn").Value

        GlobalShipmentNumber = RowShipmentNumber

        'Choose the Invoice Print Form by division
        If GlobalDivisionCode = "TFF" Or GlobalDivisionCode = "TOR" Or GlobalDivisionCode = "ALB" Then
            If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                GlobalInvoiceNumber = RowInvoiceNumber
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
                    Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                        Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                        Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                    End Using
                End If
            Else
                GlobalInvoiceNumber = RowInvoiceNumber

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
                    Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                        Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                        Dim result = NewPrintInvoiceSingle.ShowDialog()
                    End Using
                End If
            End If
        Else
            If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                GlobalInvoiceNumber = RowInvoiceNumber
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
                    Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                        Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                        Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                    End Using
                End If
            Else
                GlobalInvoiceNumber = RowInvoiceNumber

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
                    Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                        Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                        Dim result = NewPrintInvoiceSingle.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ds = New DataSet()
        GDS = New DataSet()
        GlobalMaintenancePartNumber = ""
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ds = New DataSet()
        GDS = New DataSet()
        GlobalMaintenancePartNumber = ""
        Me.Dispose()
        Me.Close()
    End Sub
End Class