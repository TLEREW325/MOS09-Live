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
Public Class SelectDropShipLines
    Inherits System.Windows.Forms.Form

    Dim DropShipLineCount As Integer
    Dim PartNumber, PartDescription, DebitGLAccount, CreditGLAccount, InvoiceStatus As String
    Dim OrderQuantity, UnitCost, ExtendedAmount As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds As DataSet
    Dim dt As DataTable

    Public Sub ShowPOLines()
        'Load PO LInes for Drop Ships for specific division
        cmd = New SqlCommand("SELECT * FROM PurchaseOrderLineTable WHERE PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey AND SelectForInvoice = @SelectForInvoice AND LineStatus = @LineStatus", con)
        cmd.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = GlobalPONumber
        cmd.Parameters.Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
        cmd.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "DROP SHIP"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "PurchaseOrderLineTable")
        dgvDropShipLines.DataSource = ds.Tables("PurchaseOrderLineTable")
        con.Close()
    End Sub

    Private Sub SelectReceiverLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Call Disable(Me)
        GlobalVerifyCode = "FAILED"
        ShowPOLines()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Open the UPDATED Form
        Using NewAPReceiptOfInvoice As New APReceiptOfInvoice
            Dim result = NewAPReceiptOfInvoice.ShowDialog()
        End Using
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSaveLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLines.Click
        'Retrieve line data from PO Table and write to Receipt Of Invoice Table
        For Each row As DataGridViewRow In dgvDropShipLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoiceDataGridViewTextBoxColumn")

            If cell.Value = "RECEIVED" Then
                Dim PurchadeOrderNumber As Integer = row.Cells("PurchaseOrderHeaderKeyDataGridViewTextBoxColumn").Value
                Dim DropShipLineNumber As Integer = row.Cells("PurchaseOrderLineNumberDataGridViewTextBoxColumn").Value
                Dim PartNumber As String = row.Cells("PartNumberDataGridViewTextBoxColumn").Value
                Dim PartDescription As String = row.Cells("PartDescriptionDataGridViewTextBoxColumn").Value
                Dim OrderQuantity As Double = row.Cells("OrderQuantityDataGridViewTextBoxColumn").Value
                Dim UnitCost As Double = row.Cells("UnitCostDataGridViewTextBoxColumn").Value

                'Write Line data to new table
                cmd = New SqlCommand("Insert Into ReceiptOfInvoiceVoucherLines(VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice)Values(@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, @SelectForInvoice)", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = GlobalVoucherNumber
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = DropShipLineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = PartDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = OrderQuantity
                    .Add("@UnitCost", SqlDbType.VarChar).Value = UnitCost
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = OrderQuantity * UnitCost
                    .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "20000"
                    .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "20999"
                    .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "RECEIVED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next

        MsgBox("Lines have been selected", MsgBoxStyle.OkOnly)

        'Open the updated form
        Using NewAPReceiptOfInvoice As New APReceiptOfInvoice
            Dim result = NewAPReceiptOfInvoice.ShowDialog()
        End Using

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each row As DataGridViewRow In dgvDropShipLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoiceDataGridViewTextBoxColumn")
            cell.Value = "RECEIVED"
        Next
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        For Each row As DataGridViewRow In dgvDropShipLines.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForInvoiceDataGridViewTextBoxColumn")
            cell.Value = "OPEN"
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

    Private Sub LoginPage_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub
End Class