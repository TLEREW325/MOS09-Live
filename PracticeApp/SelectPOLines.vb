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
Public Class SelectPOLines
    Inherits System.Windows.Forms.Form

    Dim MAXLineTotal, NextLineNumber, ReceivingCountLines, ReceivingLineNumber, POLineCount As Integer
    Dim SelectForInvoice, PartNumber, PartDescription, DebitGLAccount, CreditGLAccount, InvoiceStatus As String
    Dim InvoiceTotal, InvoiceSalesTax, InvoiceFreight, ExtendedAmountTotal, UnitCost, ExtendedAmount, OrderQuantity As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Dim needsReopened As Boolean = True

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal inValue As Boolean)
        InitializeComponent()
        needsReopened = inValue
    End Sub

    Private Sub SelectPOLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()
        GlobalVerifyCode = "FAILED"
        ShowPOLines()
    End Sub

    Public Sub LoadTotals()
        Dim ExtendedAmountTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim ExtendedAmountTotalCommand As New SqlCommand(ExtendedAmountTotalStatement, con)
        ExtendedAmountTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

        Dim InvoiceFreightStatement As String = "SELECT InvoiceFreight FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim InvoiceFreightCommand As New SqlCommand(InvoiceFreightStatement, con)
        InvoiceFreightCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

        Dim InvoiceSalesTaxStatement As String = "SELECT InvoiceSalesTax FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim InvoiceSalesTaxCommand As New SqlCommand(InvoiceSalesTaxStatement, con)
        InvoiceSalesTaxCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ExtendedAmountTotal = CDbl(ExtendedAmountTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ExtendedAmountTotal = 0
        End Try
        Try
            InvoiceFreight = CDbl(InvoiceFreightCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceFreight = 0
        End Try
        Try
            InvoiceSalesTax = CDbl(InvoiceSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceSalesTax = 0
        End Try
        con.Close()

        InvoiceTotal = ExtendedAmountTotal + InvoiceSalesTax + InvoiceFreight
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Open the UPDATED Form
        If needsReopened Then
            Dim NewAPReceiptOfInvoice As New APReceiptOfInvoice
            NewAPReceiptOfInvoice.Show()
        End If

        Me.DialogResult = Windows.Forms.DialogResult.Cancel

        Me.Dispose()
        Me.Close()
    End Sub

    Public Sub ShowPOLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM ReceivingLineQuery WHERE PONumber = @PONumber AND DivisionID = @DivisionID AND VendorCode = @VendorCode AND LineStatus = @LineStatus AND QuantityOpen <> 0 AND (SelectForInvoice = @SelectForInvoice OR SelectForInvoice = @SelectForInvoice1 OR SelectForInvoice = @SelectForInvoice2)", con)
        cmd.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = GlobalAPPONumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalAPDivisionID
        cmd.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = GlobalAPVendorID
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
        cmd.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
        cmd.Parameters.Add("@SelectForInvoice1", SqlDbType.VarChar).Value = "RETURNED"
        cmd.Parameters.Add("@SelectForInvoice2", SqlDbType.VarChar).Value = "PENDING"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceivingLineQuery")
        dgvLineQuery.DataSource = ds.Tables("ReceivingLineQuery")
        con.Close()
    End Sub

    Private Sub cmdSaveLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLines.Click
        Dim ReceiverHeaderNumber, ReceivingLineNumber As Integer
        Dim ExtendedAmount, UnitCost, OrderQuantity As Double
        Dim PartNumber, PartDescription, DebitGLAccount As String

        'Retrieve line data from PO Table and write to Receipt Of Invoice Table
        For Each row As DataGridViewRow In dgvLineQuery.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForProcessing")

            If cell.Value = "SELECTED" Then
                Try
                    ReceiverHeaderNumber = row.Cells("ReceivingHeaderKeyColumn").Value
                Catch ex As Exception
                    ReceiverHeaderNumber = 0
                End Try
                Try
                    ReceivingLineNumber = row.Cells("ReceivingLineKeyColumn").Value
                Catch ex As Exception
                    ReceivingLineNumber = 0
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
                    OrderQuantity = row.Cells("QuantityOpenColumn").Value
                Catch ex As Exception
                    OrderQuantity = 0
                End Try
                Try
                    UnitCost = row.Cells("UnitCostColumn").Value
                Catch ex As Exception
                    UnitCost = 0
                End Try
                Try
                    ExtendedAmount = row.Cells("TotalAmountOpenColumn").Value
                Catch ex As Exception
                    ExtendedAmount = 0
                End Try
                Try
                    DebitGLAccount = row.Cells("DebitGLAccountColumn").Value
                Catch ex As Exception
                    DebitGLAccount = "20999"
                End Try

                'Assign Global Receiver Number in case of deletions
                GlobalReceiverNumber = ReceiverHeaderNumber

                'Get next Line Number
                Dim MAXLineStatement As String = "SELECT MAX(VoucherLine) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                Dim MAXLineCommand As New SqlCommand(MAXLineStatement, con)
                MAXLineCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    MAXLineTotal = CInt(MAXLineCommand.ExecuteScalar)
                Catch ex As Exception
                    MAXLineTotal = 0
                End Try
                con.Close()

                NextLineNumber = MAXLineTotal + 1

                'Round variables
                UnitCost = Math.Round(UnitCost, 6)
                ExtendedAmount = UnitCost * OrderQuantity
                ExtendedAmount = Math.Round(ExtendedAmount, 2)

                'Make sure Debit GL Account is filled
                If DebitGLAccount = "" Then
                    DebitGLAccount = "20999"
                Else
                    'Do nothing
                End If

                'Write Line data to new table
                cmd = New SqlCommand("Insert Into ReceiptOfInvoiceVoucherLines(VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice, ReceiverNumber, ReceiverLine, DivisionID)Values(@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, @SelectForInvoice, @ReceiverNumber, @ReceiverLine, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = NextLineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = OrderQuantity
                    .Add("@UnitCost", SqlDbType.VarChar).Value = UnitCost
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ExtendedAmount
                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = DebitGLAccount
                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "20000"
                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "RECEIVED"
                    .Add("@ReceiverNumber", SqlDbType.VarChar).Value = ReceiverHeaderNumber
                    .Add("@ReceiverLine", SqlDbType.VarChar).Value = ReceivingLineNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalAPDivisionID
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Update Receiving Line table to show line received
                cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey", con)

                With cmd.Parameters
                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverHeaderNumber
                    .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = ReceivingLineNumber
                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "PENDING"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next

        'Update Voucher Header Totals
        LoadTotals()
        ExtendedAmountTotal = Math.Round(ExtendedAmountTotal, 2)
        InvoiceTotal = Math.Round(InvoiceTotal, 2)

        'Update Voucher Header Table
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, DeleteReferenceNumber = @DeleteReferenceNumber WHERE VoucherNumber = @VoucherNumber", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ExtendedAmountTotal
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = GlobalReceiverNumber
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Update Receiver Header based on if all lines are closed
        Dim CountLinesString As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey"
        Dim CountLinesCommand As New SqlCommand(CountLinesString, con)
        CountLinesCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalReceiverNumber
    
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ReceivingCountLines = CInt(CountLinesCommand.ExecuteScalar)
        Catch ex As Exception
            ReceivingCountLines = 0
        End Try
        con.Close()

        ReceivingLineNumber = 1

        For i As Integer = 1 To ReceivingCountLines
            Dim SelectForInvoiceString As String = "SELECT SelectForInvoice FROM ReceivingLineTable WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey"
            Dim SelectForInvoiceCommand As New SqlCommand(SelectForInvoiceString, con)
            SelectForInvoiceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = GlobalReceiverNumber
            SelectForInvoiceCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = ReceivingLineNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SelectForInvoice = CStr(SelectForInvoiceCommand.ExecuteScalar)
            Catch ex As Exception
                SelectForInvoice = "OPEN"
            End Try
            con.Close()

            If SelectForInvoice = "OPEN" Or SelectForInvoice = "PENDING" Then
                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey", con)

                With cmd.Parameters
                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverHeaderNumber
                    .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Exit For  'Exit loop - if one line is open, then Receiver is still open
            Else
                cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey", con)

                With cmd.Parameters
                    .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverHeaderNumber
                    .Add("@Status", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            ReceivingLineNumber = ReceivingLineNumber + 1
        Next i

        MsgBox("Lines have been selected", MsgBoxStyle.OkOnly)

        'Open the updated form
        If needsReopened Then
            Dim NewAPReceiptOfInvoice As New APReceiptOfInvoice
            NewAPReceiptOfInvoice.Show()
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each row As DataGridViewRow In dgvLineQuery.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForProcessing")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For Each row As DataGridViewRow In dgvLineQuery.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForProcessing")
            cell.Value = "UNSELECTED"
        Next
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

    Private Sub SelectPOLines_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub
End Class