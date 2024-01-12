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
Public Class SelectOpenPayables
    Inherits System.Windows.Forms.Form


    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub SelectOpenPayables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()
        GlobalVerifyCode = "FAILED"

        ShowPayables()
    End Sub

    Public Sub ShowPayables()
        'Load PO LInes for Drop Ships for specific division
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VendorID = @VendorID AND VoucherStatus = @VoucherStatus AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = GlobalVendorID
        cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
        dgvOpenPayables.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")
        cboVoucherNumber.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")
        con.Close()
    End Sub

    Private Sub cmdSaveLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLines.Click

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim NewAPProcessReturns As New APProcessReturns
        NewAPProcessReturns.Show()

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

    Private Sub SelectOpenPayables_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

End Class