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
Public Class SelectVendorReturnLines
    Inherits System.Windows.Forms.Form

    Dim GetLastLine, GetNextLine, VendorReturnLineNumber, VendorReturnCountLines As Integer
    Dim LineStatus As String
    Dim NextInventoryTransactionNumber, LastInventoryTransactionNumber As Integer
    Dim InvoiceTotal, ProductTotal, InvoiceSalesTax, InvoiceFreight As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Public Sub ShowVendorReturnLines()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM VendorReturnPurchaseClearing WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = GlobalVendorReturnNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "VendorReturnPurchaseClearing")
        dgvVendorReturnLines.DataSource = ds.Tables("VendorReturnPurchaseClearing")
        con.Close()
    End Sub

    Private Sub SelectVendorReturnLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Disable Close Button on form
        Call Disable(Me)
        Me.CenterToScreen()
        GlobalVerifyCode = "FAILED"
        ShowVendorReturnLines()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each row As DataGridViewRow In dgvVendorReturnLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoicing")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For Each row As DataGridViewRow In dgvVendorReturnLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoicing")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim NewAPProcessReturns As New APProcessReturns
        NewAPProcessReturns.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub LoadVoucherTotals()
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

        Dim SalesTaxTotalStatement As String = "SELECT InvoiceSalesTax FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim SalesTaxTotalCommand As New SqlCommand(SalesTaxTotalStatement, con)
        SalesTaxTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

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
            InvoiceSalesTax = CDbl(SalesTaxTotalCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceSalesTax = 0
        End Try
        Try
            InvoiceFreight = CDbl(FreightTotalCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceFreight = 0
        End Try
        con.Close()

        InvoiceTotal = ProductTotal + InvoiceSalesTax + InvoiceFreight
    End Sub

    Private Sub cmdSaveLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLines.Click
        'Retrieve line data from PO Table and write to Receipt Of Invoice Table
        Dim ExtendedCost As Double = 0
        Dim ReturnNumber As Integer = 0
        Dim ReturnLineNumber As Integer
        Dim PartNumber, PartDescription, CreditGLAccount, DebitGLAccount As String
        Dim Quantity As Double = 0
        Dim Cost As Double = 0

        For Each row As DataGridViewRow In dgvVendorReturnLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoicing")

            If cell.Value = "SELECTED" Then
                Try
                    ReturnNumber = row.Cells("ReturnNumberColumn").Value
                Catch ex As Exception
                    ReturnNumber = 0
                End Try
                Try
                    ReturnLineNumber = row.Cells("ReturnLineNumberColumn").Value
                Catch ex As Exception
                    ReturnLineNumber = 0
                End Try
                Try
                    PartNumber = row.Cells("PartNumberColumn").Value
                Catch ex As Exception
                    PartNumber = ""
                End Try
                Try
                    PartDescription = row.Cells("PartDescriptionColumn").Value
                Catch ex As Exception
                    PartDescription = ""
                End Try
                Try
                    Quantity = row.Cells("QuantityOpenColumn").Value
                Catch ex As Exception
                    Quantity = 0
                End Try
                Try
                    Cost = row.Cells("CostColumn").Value
                Catch ex As Exception
                    Cost = 0
                End Try
                Try
                    CreditGLAccount = row.Cells("CreditGLAccountColumn").Value
                Catch ex As Exception
                    CreditGLAccount = "20000"
                End Try
                Try
                    DebitGLAccount = row.Cells("DebitGLAccountColumn").Value
                Catch ex As Exception
                    DebitGLAccount = "20999"
                End Try

                'Assign Global Return Number
                GlobalReturnNumber = ReturnNumber
                Quantity = Quantity * -1 'Convert number to negative
                ExtendedCost = Quantity * Cost
                ExtendedCost = Math.Round(ExtendedCost, 2)

                'Verify GL Account
                If DebitGLAccount = "" Then
                    DebitGLAccount = "20999"
                Else
                    'Do nothing
                End If

                'Get next Line Number for Voucher
                Dim GetLastLineString As String = "SELECT MAX(VoucherLine) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                Dim GetLastLineCommand As New SqlCommand(GetLastLineString, con)
                GetLastLineCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLastLine = CInt(GetLastLineCommand.ExecuteScalar)
                Catch ex As Exception
                    GetLastLine = 0
                End Try
                con.Close()

                GetNextLine = GetLastLine + 1

                'Write Line data to new table
                cmd = New SqlCommand("Insert Into ReceiptOfInvoiceVoucherLines(VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice, ReceiverNumber, ReceiverLine, DivisionID)Values(@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, @SelectForInvoice, @ReceiverNumber, @ReceiverLine, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = GetNextLine
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = Quantity
                    .Add("@UnitCost", SqlDbType.VarChar).Value = Cost
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedCost
                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "20000"
                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = DebitGLAccount
                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@ReceiverNumber", SqlDbType.VarChar).Value = ReturnNumber
                    .Add("@ReceiverLine", SqlDbType.VarChar).Value = ReturnLineNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next

        'Update Header Table
        LoadVoucherTotals()

        'Write values to Batch Table
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal WHERE VoucherNumber = @VoucherNumber", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Recalculate Total for ROI Batch Line
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET InvoiceTotal = ProductTotal + InvoiceFreight + InvoiceSalesTax WHERE VoucherNumber = @VoucherNumber", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '*********************************************************************************************************
        'Run loop to get number of return lines
        Dim CountLinesString As String = "SELECT COUNT(ReturnNumber) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber"
        Dim CountLinesCommand As New SqlCommand(CountLinesString, con)
        CountLinesCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = GlobalReturnNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorReturnCountLines = CInt(CountLinesCommand.ExecuteScalar)
        Catch ex As Exception
            VendorReturnCountLines = 0
        End Try
        con.Close()
        '*********************************************************************************************************

        VendorReturnLineNumber = 1

        For i As Integer = 1 To VendorReturnCountLines
            Dim GetOpenLineQuantity As Double = 0

            Dim GetOpenLineQuantityString As String = "SELECT QuantityOpen FROM VendorReturnPurchaseClearing WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber"
            Dim GetOpenLineQuantityCommand As New SqlCommand(GetOpenLineQuantityString, con)
            GetOpenLineQuantityCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = GlobalReturnNumber
            GetOpenLineQuantityCommand.Parameters.Add("@ReturnLineNumber", SqlDbType.VarChar).Value = VendorReturnLineNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetOpenLineQuantity = CDbl(GetOpenLineQuantityCommand.ExecuteScalar)
            Catch ex As Exception
                GetOpenLineQuantity = 0
            End Try
            con.Close()

            If GetOpenLineQuantity = 0 Then
                cmd = New SqlCommand("UPDATE VendorReturnLine SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)

                With cmd.Parameters
                    .Add("@ReturnNumber", SqlDbType.VarChar).Value = GlobalReturnNumber
                    .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = VendorReturnLineNumber
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                cmd = New SqlCommand("UPDATE VendorReturnLine SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)

                With cmd.Parameters
                    .Add("@ReturnNumber", SqlDbType.VarChar).Value = GlobalReturnNumber
                    .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = VendorReturnLineNumber
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            VendorReturnLineNumber = VendorReturnLineNumber + 1
        Next i

        'Double-Check Status on Vendor Return
        Dim CountStatus As Integer = 0

        Dim CountStatusString As String = "SELECT COUNT(ReturnNumber) FROM VendorReturnLine WHERE ReturnNumber = @ReturnNumber AND LineStatus = @LineStatus"
        Dim CountStatusCommand As New SqlCommand(CountStatusString, con)
        CountStatusCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = GlobalReturnNumber
        CountStatusCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountStatus = CInt(CountStatusCommand.ExecuteScalar)
        Catch ex As Exception
            CountStatus = 0
        End Try
        con.Close()

        If CountStatus = 0 Then
            cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber", con)

            With cmd.Parameters
                .Add("@ReturnNumber", SqlDbType.VarChar).Value = GlobalReturnNumber
                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "CLOSED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Else
            cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber", con)

            With cmd.Parameters
                .Add("@ReturnNumber", SqlDbType.VarChar).Value = GlobalReturnNumber
                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If

        MsgBox("Lines have been selected", MsgBoxStyle.OkOnly)

        'Open the updated form
        Using NewAPProcessReturns As New APProcessReturns
            Dim result = NewAPProcessReturns.ShowDialog()
        End Using

        Me.Dispose()
        Me.Close()
    End Sub

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        ' The return value specifies the previous state of the menu item (it is either      
        ' MF_ENABLED or MF_GRAYED). 0xFFFFFFFF indicates   that the menu item does not exist.      
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)
            Case MF_ENABLED
            Case MF_GRAYED
            Case &HFFFFFFFF
                Throw New Exception("The Close menu item does not exist.")
            Case Else
        End Select
    End Sub

    Private Sub LoginPage_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub
End Class