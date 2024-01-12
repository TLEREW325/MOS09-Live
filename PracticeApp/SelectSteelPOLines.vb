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
Public Class SelectSteelPOLines
    Inherits System.Windows.Forms.Form

    Dim LastGLNumber, NextGLNumber, LastLineNumber, NextLineNumber As Integer
    Dim Description, DebitGLAccount, CreditGLAccount As String
    Dim ExtendedAmount, InvoiceFreight, InvoiceSalesTax, ProductTotal, InvoiceTotal As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Public Sub ShowSteelPOLines()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT * FROM SteelReceivingLineQuery2 WHERE SteelBOLNumber = @SteelBOLNumber AND LineStatus = @LineStatus", con)
        cmd.Parameters.Add("@SteelBOLNumber", SqlDbType.VarChar).Value = GlobalAPSteelBOLNumber
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "SteelReceivingLineQuery2")
        dgvSteelReceivingLines.DataSource = ds.Tables("SteelReceivingLineQuery2")
        con.Close()
    End Sub

    Private Sub SelectSteelPOLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Disable Close Button on form
        Call Disable(Me)
        Me.CenterToScreen()
        GlobalVerifyCode = "FAILED"
        ShowSteelPOLines()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each row As DataGridViewRow In dgvSteelReceivingLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoicing")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For Each row As DataGridViewRow In dgvSteelReceivingLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoicing")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Sub cmdSaveLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLines.Click
        'Retrieve line data from Receiving Line Table 
        For Each row As DataGridViewRow In dgvSteelReceivingLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoicing")

            If cell.Value = "SELECTED" Then
                Dim RMID As String = row.Cells("RMIDColumn").Value
                Dim ReceiveWeight As Integer = row.Cells("ReceiveWeightColumn").Value
                Dim SteelCostPerPound As Double = row.Cells("SteelUnitCostColumn").Value
                Dim SteelExtendedCost As Double = row.Cells("SteelExtendedCostColumn").Value
                Dim Carbon As String = row.Cells("CarbonColumn").Value
                Dim SteelSize As String = row.Cells("SteelSizeColumn").Value
                Dim ReceiverNumber As Integer = row.Cells("SteelReceivingHeaderKeyColumn").Value
                Dim ReceiverLine As Integer = row.Cells("SteelReceivingLineKeyColumn").Value

                'Create Description in Voucher Line Table
                Description = Carbon & " - " & SteelSize

                'Round Numbers
                SteelCostPerPound = Math.Round(SteelCostPerPound, 5)
                SteelExtendedCost = Math.Round(SteelExtendedCost, 2)


                'Find next Line Number for Voucher
                Dim MAXStatement As String = "SELECT MAX(VoucherLine) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                Dim MAXCommand As New SqlCommand(MAXStatement, con)
                MAXCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastLineNumber = CInt(MAXCommand.ExecuteScalar)
                Catch ex As Exception
                    LastLineNumber = 0
                End Try
                con.Close()

                NextLineNumber = LastLineNumber + 1

                'Create command to update database and fill with text box enties
                cmd = New SqlCommand("Insert Into ReceiptOfInvoiceVoucherLines(VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice, ReceiverNumber, ReceiverLine, DivisionID)Values(@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, @SelectForInvoice, @ReceiverNumber, @ReceiverLine, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = NextLineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = RMID
                    .Add("@PartDescription", SqlDbType.VarChar).Value = Description
                    .Add("@Quantity", SqlDbType.VarChar).Value = ReceiveWeight
                    .Add("@UnitCost", SqlDbType.VarChar).Value = SteelCostPerPound
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = SteelExtendedCost
                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "20995"
                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "20000"
                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@ReceiverNumber", SqlDbType.VarChar).Value = ReceiverNumber
                    .Add("@ReceiverLine", SqlDbType.VarChar).Value = ReceiverLine
                    .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next

        'Update Totals in Batch Line Table 
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

        Dim InvoiceSalesTaxStatement As String = "SELECT InvoiceSalesTax FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim InvoiceSalesTaxCommand As New SqlCommand(InvoiceSalesTaxStatement, con)
        InvoiceSalesTaxCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

        Dim InvoiceFreightStatement As String = "SELECT InvoiceFreight FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber"
        Dim InvoiceFreightCommand As New SqlCommand(InvoiceFreightStatement, con)
        InvoiceFreightCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            InvoiceSalesTax = CDbl(InvoiceSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceSalesTax = 0
        End Try
        Try
            InvoiceFreight = CDbl(InvoiceFreightCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceFreight = 0
        End Try
        con.Close()

        ProductTotal = Math.Round(ProductTotal, 2)
        InvoiceTotal = ProductTotal + InvoiceSalesTax + InvoiceFreight

        'Create command to update database
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal WHERE VoucherNumber = @VoucherNumber", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        Dim NewAPProcessSteelReceipts As New APProcessSteelReceipts
        NewAPProcessSteelReceipts.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim NewAPProcessSteelReceipts As New APProcessSteelReceipts
        NewAPProcessSteelReceipts.Show()
   
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