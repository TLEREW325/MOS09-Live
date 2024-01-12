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
Public Class SelectSteelVendorReturnLines
    Inherits System.Windows.Forms.Form

    Dim MaxLineNumber, NextLineNumber As Integer
    Dim ProductTotal, InvoiceFreight, InvoiceTotal As Double


    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub SelectSteelVendorReturnLines_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GlobalDivisionCode = ""
        GlobalVoucherNumber = 0
        GlobalSteelReturnNumber = 0
    End Sub

    Private Sub SelectSteelVendorReturnLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load Posted Return Lines on Load
        ShowReturnLines()
    End Sub

    Public Sub ShowReturnLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM SteelReturnLineQuery2 WHERE SteelReturnNumber = @SteelReturnNumber AND LineStatus = @LineStatus", con)
        cmd.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelReturnNumber
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "POSTED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelReturnLineQuery2")
        dgvSteelReturnLines.DataSource = ds.Tables("SteelReturnLineQuery2")
        con.Close()
    End Sub

    Public Sub LoadVoucherTotals()
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

        Dim FreightTotalStatement As String = "SELECT InvoiceFreight FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim FreightTotalCommand As New SqlCommand(FreightTotalStatement, con)
        FreightTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            InvoiceFreight = CDbl(FreightTotalCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceFreight = 0
        End Try
        con.Close()

        InvoiceTotal = ProductTotal + InvoiceFreight
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each row As DataGridViewRow In dgvSteelReturnLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectedColumn")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For Each row As DataGridViewRow In dgvSteelReturnLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectedColumn")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Sub cmdAddLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLines.Click
        'Retrieve line data from Steel Return Table
        Dim ReturnLineNumber As Integer
        Dim RMID, LineComment, DebitGLAccount As String
        Dim ReturnQuantity, UnitCost, ExtendedCost As Double
        Dim SteelDescription As String = ""

        For Each row As DataGridViewRow In dgvSteelReturnLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectedColumn")

            If cell.Value = "SELECTED" Then
                Try
                    ReturnLineNumber = row.Cells("SteelReturnLineColumn").Value
                Catch ex As Exception
                    ReturnLineNumber = 0
                End Try
                Try
                    RMID = row.Cells("RMIDColumn").Value
                Catch ex As Exception
                    RMID = ""
                End Try
                Try
                    ReturnQuantity = row.Cells("ReturnQuantityColumn").Value
                Catch ex As Exception
                    ReturnQuantity = 0
                End Try
                Try
                    UnitCost = row.Cells("UnitCostColumn").Value
                Catch ex As Exception
                    UnitCost = 0
                End Try
                Try
                    DebitGLAccount = row.Cells("GLDebitAccountColumn").Value
                Catch ex As Exception
                    DebitGLAccount = "20995"
                End Try
                Try
                    LineComment = row.Cells("LineCommentColumn").Value
                Catch ex As Exception
                    LineComment = ""
                End Try

                ReturnQuantity = ReturnQuantity * -1

                ExtendedCost = ReturnQuantity * UnitCost
                ExtendedCost = Math.Round(ExtendedCost, 2)
                UnitCost = Math.Round(UnitCost, 5)
                '**************************************************************************************************
                'Get Steel Description for RMID
                Dim SteelDescriptionStatement As String = "SELECT Description FROM RawMaterialsTable WHERE RMID = @RMID AND DivisionID = @DivisionID"
                Dim SteelDescriptionCommand As New SqlCommand(SteelDescriptionStatement, con)
                SteelDescriptionCommand.Parameters.Add("@RMID", SqlDbType.VarChar).Value = RMID
                SteelDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SteelDescription = CStr(SteelDescriptionCommand.ExecuteScalar)
                Catch ex As Exception
                    SteelDescription = ""
                End Try
                con.Close()
                '**************************************************************************************************
                'Get Steel Return Comment and write to Voucher Header






                '**************************************************************************************************
                'Verify GL Account
                If DebitGLAccount = "" Then
                    DebitGLAccount = "20995"
                Else
                    'Do nothing
                End If
                '**************************************************************************************************
                'Get Max Line
                Dim MAXLineNumberStatement As String = "SELECT MAX(VoucherLine) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                Dim MAXLineNumberCommand As New SqlCommand(MAXLineNumberStatement, con)
                MAXLineNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXLineNumber = CInt(MAXLineNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    MAXLineNumber = 0
                End Try
                con.Close()

                NextLineNumber = MAXLineNumber + 1
                '**************************************************************************************************
                Try
                    'Write Data to Receiving Line Database Table
                    cmd = New SqlCommand("Insert Into ReceiptOfInvoiceVoucherLines(VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice, ReceiverNumber, ReceiverLine, DivisionID) Values (@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, @SelectForInvoice, @ReceiverNumber, @ReceiverLine, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
                        .Add("@VoucherLine", SqlDbType.VarChar).Value = NextLineNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = RMID
                        .Add("@PartDescription", SqlDbType.VarChar).Value = SteelDescription
                        .Add("@Quantity", SqlDbType.VarChar).Value = ReturnQuantity
                        .Add("@UnitCost", SqlDbType.VarChar).Value = UnitCost
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedCost
                        .Add("@GLDebitAccount", SqlDbType.VarChar).Value = DebitGLAccount
                        .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "20000"
                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@ReceiverNumber", SqlDbType.VarChar).Value = GlobalSteelReturnNumber
                        .Add("@ReceiverLine", SqlDbType.VarChar).Value = ReturnLineNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error Log
                End Try
                '**************************************************************************************************







                '************************************************************************************************
                'Close Steel Vendor Return Line
                cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineStatus = @LineStatus WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine", con)

                With cmd.Parameters
                    .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelReturnNumber
                    .Add("@SteelReturnLine", SqlDbType.VarChar).Value = ReturnLineNumber
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next

        'Update Voucher Totals
        LoadVoucherTotals()

        Try
            'Write values to Batch Table
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal WHERE VoucherNumber = @VoucherNumber", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = 0
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
        End Try

        'Check and close return 
        Dim CheckReturnIsClosed As Integer = 0

        Dim CheckReturnIsClosedStatement As String = "SELECT COUNT(SteelReturnNumber) FROM SteelReturnLine WHERE SteelReturnNumber = @SteelReturnNumber AND LineStatus = @LineStatus"
        Dim CheckReturnIsClosedCommand As New SqlCommand(CheckReturnIsClosedStatement, con)
        CheckReturnIsClosedCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelReturnNumber
        CheckReturnIsClosedCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "POSTED"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckReturnIsClosed = CInt(CheckReturnIsClosedCommand.ExecuteScalar)
        Catch ex As Exception
            CheckReturnIsClosed = 0
        End Try
        con.Close()

        If CheckReturnIsClosed = 0 Then 'Steel Return is CLOSED if no lines are open
            Try
                'Write values to Batch Table
                cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET ReturnStatus = @ReturnStatus WHERE SteelReturnNumber = @SteelReturnNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelReturnNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    .Add("@ReturnStatus", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
            End Try
        Else 'Steel Return is open if at least one line is open
            Try
                'Write values to Batch Table
                cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET ReturnStatus = @ReturnStatus WHERE SteelReturnNumber = @SteelReturnNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GlobalSteelReturnNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Error Log
            End Try
        End If

        'Leave form and refresh main form
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class