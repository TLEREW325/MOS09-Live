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
Public Class APProcessSteelReturns
    Inherits System.Windows.Forms.Form

    Dim LineReturnNumber, LineReturnLine, LineQuantity, LastInventoryTransactionNumber, NextInventoryTransactionNumber, PONumber, LastVoucherNumber, NextVoucherNumber As Integer
    Dim LongDescription, LinePartDescription, VendorName, InvoiceNumber, InvoiceDate, VendorID, Comment As String
    Dim LineExtendedAmount, LineCost, LineExtendedCost, SUMInvoiceTotal, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal As Double
    Dim VendorClass, CheckStatus, VerifyVendor, UniqueInvoice, VoucherDate, VoucherStatus, PartNumber, PartDescription, LineComment, DebitGLAccount, CreditGLAccount As String
    Dim DeleteReferenceNumber, GetReturnNumber, ReturnLineNumber As Integer
    Dim DiscountAmount, SUMExtendedAmount, Cost, ExtendedAmount, InvoiceAmount, Quantity As Double
    Dim ReturnDate As String
    Dim DeleteDescription, DeletePartNumber, CheckVoucherStatus As String
    Dim CheckType As String = ""
    Dim VendorCheckType As String = ""
    Dim ValidateCheckType As String = ""

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    'Form operations

    Private Sub APProcessSteelReturns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Call Disable(Me)

        'Load default from Batch Form
        txtDivisionID.Text = GlobalAPDivisionID
        txtBatchNumber.Text = GlobalAPBatchNumber

        LoadVendor()
        LoadVoucher()
        LoadPartNumber()
        LoadGLAccount()
        ClearData()

        If GlobalVoucherNumber > 0 Then
            cboVoucherNumber.Text = GlobalVoucherNumber
        Else
            cboVoucherNumber.SelectedIndex = -1
            cboReturnNumber.SelectedIndex = -1
            cboPONumber.SelectedIndex = -1
        End If
    End Sub

    Private Sub APProcessReturns_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    'Load Datasets into controls

    Public Sub ShowVoucherLines()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber", con)
        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceiptOfInvoiceVoucherLines")
        dgvVoucherLines.DataSource = ds.Tables("ReceiptOfInvoiceVoucherLines")
        cboDeleteLine.DataSource = ds.Tables("ReceiptOfInvoiceVoucherLines")
        con.Close()
    End Sub

    Public Sub ClearDatagrid()
        dgvVoucherLines.DataSource = Nothing
    End Sub

    Public Sub LoadVendor()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass = @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "Vendor")
        cboVendorID.DataSource = ds1.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadVoucher()
        'Load Voucher Number for specific division
        cmd = New SqlCommand("SELECT VoucherNumber FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber AND VoucherSource = @VoucherSource AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = txtBatchNumber.Text
        cmd.Parameters.Add("@VoucherSource", SqlDbType.VarChar).Value = "STEEL VENDOR RETURN"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ReceiptOfInvoiceBatchLine")
        cboVoucherNumber.DataSource = ds2.Tables("ReceiptOfInvoiceBatchLine")
        con.Close()
        cboVoucherNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPONumber()
        'Load Voucher Number for specific division
        cmd = New SqlCommand("SELECT SteelPurchaseOrderKey FROM SteelPurchaseOrderHeader WHERE DivisionID = @DivisionID AND SteelVendorID = @SteelVendorID ORDER BY SteelPurchaseOrderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@SteelVendorID", SqlDbType.VarChar).Value = cboVendorID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "SteelPurchaseOrderHeader")
        cboPONumber.DataSource = ds3.Tables("SteelPurchaseOrderHeader")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadReturnNumber()
        'Load Voucher Number for specific division
        cmd = New SqlCommand("SELECT SteelReturnNumber FROM SteelReturnHeaderTable WHERE SteelVendor = @SteelVendor AND DivisionID = @DivisionID AND ReturnStatus = @ReturnStatus", con)
        cmd.Parameters.Add("@SteelVendor", SqlDbType.VarChar).Value = cboVendorID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "SteelReturnHeaderTable")
        cboReturnNumber.DataSource = ds4.Tables("SteelReturnHeaderTable")
        con.Close()
        cboReturnNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT ItemID FROM NonInventoryItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "NonInventoryItemList")
        cboLinePartNumber.DataSource = ds5.Tables("NonInventoryItemList")
        con.Close()
        cboLinePartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccount()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "GLAccounts")
        cboDebitAccount.DataSource = ds6.Tables("GLAccounts")
        cboDebitDescription.DataSource = ds6.Tables("GLAccounts")
        con.Close()
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1
    End Sub

    'Load Data Commands

    Public Sub LoadVendorData()
        Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim CheckTypeStatement As String = "SELECT CheckCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim CheckTypeCommand As New SqlCommand(CheckTypeStatement, con)
        CheckTypeCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        CheckTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorName = ""
        End Try
        Try
            VendorCheckType = CStr(CheckTypeCommand.ExecuteScalar)
        Catch ex As Exception
            VendorCheckType = ""
        End Try
        con.Close()

        txtVendorName.Text = VendorName
        cboCheckType.Text = VendorCheckType
    End Sub

    Private Sub CheckReturnAmount()
        If Val(txtReturnAmount.Text) = 0 And InvoiceTotal <> 0 Then
            MsgBox("You cannot round to zero.", MsgBoxStyle.OkOnly)
            GlobalSteelReturnRounding = "EXIT SUB"
            Exit Sub
        Else
            GlobalSteelReturnRounding = "CONTINUE"
        End If

        If Val(txtReturnAmount.Text) <> InvoiceTotal Then
            Dim button As DialogResult = MessageBox.Show("The Calculated Total does not match the Invoice Amount. Do you wish to round the difference?", "ROUND DIFFERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                Dim SUMNewExtendedAmount, NewExtendedAmount, GetExtendedAmount As Double
                Dim RoundingAmount As Double = 0

                RoundingAmount = Val(txtReturnAmount.Text) - InvoiceTotal

                Dim GetExtendedAmountStatement As String = "SELECT ExtendedAmount FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                Dim GetExtendedAmountCommand As New SqlCommand(GetExtendedAmountStatement, con)
                GetExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                GetExtendedAmountCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = 1

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetExtendedAmount = CDbl(GetExtendedAmountCommand.ExecuteScalar)
                Catch ex1 As Exception
                    GetExtendedAmount = 0
                End Try
                con.Close()

                NewExtendedAmount = GetExtendedAmount + RoundingAmount
                NewExtendedAmount = Math.Round(NewExtendedAmount, 2)

                'Update Line Database Table
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = @ExtendedAmount WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                cmd.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = 1
                cmd.Parameters.Add("@ExtendedAmount", SqlDbType.VarChar).Value = NewExtendedAmount

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Dim SUMNewExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                Dim SUMNewExtendedAmountCommand As New SqlCommand(SUMNewExtendedAmountStatement, con)
                SUMNewExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SUMNewExtendedAmount = CDbl(SUMNewExtendedAmountCommand.ExecuteScalar)
                Catch ex1 As Exception
                    SUMNewExtendedAmount = 0
                End Try
                con.Close()

                SUMNewExtendedAmount = Math.Round(SUMNewExtendedAmount, 2)

                'Update Header Database Table
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = SUMNewExtendedAmount
                cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = Val(txtReturnAmount.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                ShowVoucherLines()
                LoadVoucherTotals()
                GlobalSteelReturnRounding = "CONTINUE"
            ElseIf button = DialogResult.No Then
                GlobalSteelReturnRounding = "EXIT SUB"
            End If
        End If
    End Sub

    Public Sub LoadPartDescription()
        Dim PartDescriptionStatement As String = "SELECT ShortDescription FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescriptionCommand As New SqlCommand(PartDescriptionStatement, con)
        PartDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboLinePartNumber.Text
        PartDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim DebitGLAccountStatement As String = "SELECT GLDebitAccount FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim DebitGLAccountCommand As New SqlCommand(DebitGLAccountStatement, con)
        DebitGLAccountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboLinePartNumber.Text
        DebitGLAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription = CStr(PartDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            PartDescription = ""
        End Try
        Try
            DebitGLAccount = CStr(DebitGLAccountCommand.ExecuteScalar)
        Catch ex As Exception
            DebitGLAccount = ""
        End Try
        con.Close()

        txtLineDescription.Text = PartDescription
        cboDebitAccount.Text = DebitGLAccount
    End Sub

    Public Sub LoadVoucherTotals()
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        Dim FreightTotalStatement As String = "SELECT InvoiceFreight FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim FreightTotalCommand As New SqlCommand(FreightTotalStatement, con)
        FreightTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        FreightTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim ReturnTotalStatement As String = "SELECT InvoiceTotal FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim ReturnTotalCommand As New SqlCommand(ReturnTotalStatement, con)
        ReturnTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        ReturnTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

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
        Try
            InvoiceTotal = CDbl(ReturnTotalCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceTotal = 0
        End Try
        con.Close()

        'Round Variables
        InvoiceFreight = Math.Round(InvoiceFreight, 2)
        ProductTotal = Math.Round(ProductTotal, 2)
        InvoiceTotal = Math.Round(InvoiceTotal, 2)
        InvoiceSalesTax = Math.Round(InvoiceSalesTax, 2)

        txtFreightTotal.Text = InvoiceFreight
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtReturnTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Public Sub ReloadVoucherTotals()
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        con.Close()

        InvoiceFreight = Val(txtFreightTotal.Text)
        InvoiceTotal = Math.Round(ProductTotal + InvoiceFreight + InvoiceSalesTax, 2)

        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtReturnTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Public Sub UpdateBatchTotal()
        Dim SUMInvoiceTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim SUMInvoiceTotalCommand As New SqlCommand(SUMInvoiceTotalStatement, con)
        SUMInvoiceTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        SUMInvoiceTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SUMInvoiceTotal = CDbl(SUMInvoiceTotalCommand.ExecuteScalar)
        Catch ex As Exception
            SUMInvoiceTotal = 0
        End Try
        con.Close()

        SUMInvoiceTotal = Math.Round(SUMInvoiceTotal, 2)

        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        cmd.Parameters.Add("@BatchAmount", SqlDbType.VarChar).Value = SUMInvoiceTotal
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub LoadReturnVoucherData()
        Dim PONumberStatement As String = "SELECT PONumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim PONumberCommand As New SqlCommand(PONumberStatement, con)
        PONumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        PONumberCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        PONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceNumberStatement As String = "SELECT InvoiceNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim InvoiceNumberCommand As New SqlCommand(InvoiceNumberStatement, con)
        InvoiceNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceNumberCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        InvoiceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceDateStatement As String = "SELECT InvoiceDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim InvoiceDateCommand As New SqlCommand(InvoiceDateStatement, con)
        InvoiceDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceDateCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        InvoiceDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VendorIDStatement As String = "SELECT VendorID FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim VendorIDCommand As New SqlCommand(VendorIDStatement, con)
        VendorIDCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        VendorIDCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        VendorIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim ProductTotalStatement As String = "SELECT ProductTotal FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        ProductTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceFreightStatement As String = "SELECT InvoiceFreight FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim InvoiceFreightCommand As New SqlCommand(InvoiceFreightStatement, con)
        InvoiceFreightCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceFreightCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        InvoiceFreightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceSalesTaxStatement As String = "SELECT InvoiceSalesTax FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim InvoiceSalesTaxCommand As New SqlCommand(InvoiceSalesTaxStatement, con)
        InvoiceSalesTaxCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceSalesTaxCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        InvoiceSalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceTotalStatement As String = "SELECT InvoiceTotal FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim InvoiceTotalCommand As New SqlCommand(InvoiceTotalStatement, con)
        InvoiceTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        InvoiceTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim CommentStatement As String = "SELECT Comment FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim CommentCommand As New SqlCommand(CommentStatement, con)
        CommentCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        CommentCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        CommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim VoucherStatusCommand As New SqlCommand(VoucherStatusStatement, con)
        VoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        VoucherStatusCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        VoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim InvoiceAmountStatement As String = "SELECT InvoiceAmount FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim InvoiceAmountCommand As New SqlCommand(InvoiceAmountStatement, con)
        InvoiceAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceAmountCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        InvoiceAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VoucherDateStatement As String = "SELECT InvoiceDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim VoucherDateCommand As New SqlCommand(VoucherDateStatement, con)
        VoucherDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        VoucherDateCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        VoucherDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim DeleteReferenceNumberStatement As String = "SELECT DeleteReferenceNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim DeleteReferenceNumberCommand As New SqlCommand(DeleteReferenceNumberStatement, con)
        DeleteReferenceNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        DeleteReferenceNumberCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        DeleteReferenceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim CheckTypeStatement As String = "SELECT CheckType FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim CheckTypeCommand As New SqlCommand(CheckTypeStatement, con)
        CheckTypeCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        CheckTypeCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        CheckTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PONumber = CInt(PONumberCommand.ExecuteScalar)
        Catch ex As Exception
            PONumber = 0
        End Try
        Try
            InvoiceNumber = CStr(InvoiceNumberCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceNumber = ""
        End Try
        Try
            InvoiceDate = CStr(InvoiceDateCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceDate = ""
        End Try
        Try
            VendorID = CStr(VendorIDCommand.ExecuteScalar)
        Catch ex As Exception
            VendorID = ""
        End Try
        Try
            ProductTotal = CDbl(ProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        Try
            InvoiceFreight = CDbl(InvoiceFreightCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceFreight = 0
        End Try
        Try
            InvoiceTotal = CDbl(InvoiceTotalCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceTotal = 0
        End Try
        Try
            Comment = CStr(CommentCommand.ExecuteScalar)
        Catch ex As Exception
            Comment = ""
        End Try
        Try
            VoucherStatus = CStr(VoucherStatusCommand.ExecuteScalar)
        Catch ex As Exception
            VoucherStatus = ""
        End Try
        Try
            InvoiceAmount = CDbl(InvoiceAmountCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceAmount = 0
        End Try
        Try
            VoucherDate = CStr(VoucherDateCommand.ExecuteScalar)
        Catch ex As Exception
            VoucherDate = ""
        End Try
        Try
            DeleteReferenceNumber = CInt(DeleteReferenceNumberCommand.ExecuteScalar)
        Catch ex As Exception
            DeleteReferenceNumber = 0
        End Try
        Try
            CheckType = CStr(CheckTypeCommand.ExecuteScalar)
        Catch ex As Exception
            CheckType = "STANDARD"
        End Try
        con.Close()

        cboVendorID.Text = VendorID

        If PONumber = 0 Then
            cboPONumber.SelectedIndex = -1
        Else
            cboPONumber.Text = PONumber
        End If

        txtInvoiceNumber.Text = InvoiceNumber
        dtpReturnDate.Text = InvoiceDate
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtFreightTotal.Text = InvoiceFreight
        txtReturnTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtComment.Text = Comment
        dtpReturnDate.Text = VoucherDate
        cboReturnNumber.Text = DeleteReferenceNumber
        txtReturnAmount.Text = InvoiceAmount
        cboCheckType.Text = CheckType

        If VoucherStatus = "POSTED" Or VoucherStatus = "CLOSED" Then
            cmdDelete.Enabled = False
            cmdSave.Enabled = False
            SaveReturnVoucherToolStripMenuItem.Enabled = False
            DeleteReturnVoucherToolStripMenuItem.Enabled = False
            dgvVoucherLines.Enabled = False
        Else
            cmdDelete.Enabled = True
            cmdSave.Enabled = True
            SaveReturnVoucherToolStripMenuItem.Enabled = True
            DeleteReturnVoucherToolStripMenuItem.Enabled = True
            dgvVoucherLines.Enabled = True
        End If
    End Sub

    Public Sub CheckAndUpdateSteelVendorLines()
        Dim CheckLineReturnNumber As Integer = 0
        Dim CheckLineReturnLineNumber As Integer = 0
        Dim CheckQuantityVouched As Double = 0
        Dim CheckQuantityReturned As Double = 0

        If Me.dgvVoucherLines.RowCount > 0 Then
            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Try
                    CheckLineReturnNumber = row.Cells("ReceiverNumberColumn").Value
                Catch ex As Exception
                    CheckLineReturnNumber = 0
                End Try
                Try
                    CheckLineReturnLineNumber = row.Cells("ReceiverLineColumn").Value
                Catch ex As Exception
                    CheckLineReturnLineNumber = 0
                End Try

                'Get Total Quantity Vouched
                Dim CheckQuantityVouchedStatement As String = "SELECT SUM(Quantity) FROM ReceiptOfInvoiceVoucherLines WHERE ReceiverNumber = @ReceiverNumber AND ReceiverLine = @ReceiverLine"
                Dim CheckQuantityVouchedCommand As New SqlCommand(CheckQuantityVouchedStatement, con)
                CheckQuantityVouchedCommand.Parameters.Add("@ReceiverNumber", SqlDbType.VarChar).Value = CheckLineReturnNumber
                CheckQuantityVouchedCommand.Parameters.Add("@ReceiverLine", SqlDbType.VarChar).Value = CheckLineReturnLineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckQuantityVouched = CDbl(CheckQuantityVouchedCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckQuantityVouched = 0
                End Try
                con.Close()

                'Get Total Quantity Returned
                Dim CheckQuantityReturnedStatement As String = "SELECT SUM(ReturnQuantity) FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine"
                Dim CheckQuantityReturnedCommand As New SqlCommand(CheckQuantityReturnedStatement, con)
                CheckQuantityReturnedCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = CheckLineReturnNumber
                CheckQuantityReturnedCommand.Parameters.Add("@SteelReturnLine", SqlDbType.VarChar).Value = CheckLineReturnLineNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckQuantityReturned = CInt(CheckQuantityReturnedCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckQuantityReturned = 0
                End Try
                con.Close()

                If CheckQuantityVouched >= CheckQuantityReturned Then
                    'Close Vendor Return Lines
                    cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineStatus = @LineStatus WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine", con)

                    With cmd.Parameters
                        .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = CheckLineReturnNumber
                        .Add("@SteelReturnLine", SqlDbType.VarChar).Value = CheckLineReturnLineNumber
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "CLOSED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Re-open Vendor Return Lines
                    cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineStatus = @LineStatus WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine", con)

                    With cmd.Parameters
                        .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = CheckLineReturnNumber
                        .Add("@SteelReturnLine", SqlDbType.VarChar).Value = CheckLineReturnLineNumber
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                'Clear Variables
                CheckLineReturnNumber = 0
                CheckLineReturnLineNumber = 0
                CheckQuantityVouched = 0
                CheckQuantityReturned = 0
            Next

            'Close Return Header if necessary
            Dim CountOpenLines As Integer = 0

            Dim CountOpenLinesStatement As String = "SELECT COUNT(SteelReturnNumber) FROM SteelReturnLineTable WHERE SteelReturnNumber = @SteelReturnNumber AND LineStatus = @LineStatus"
            Dim CountOpenLinesCommand As New SqlCommand(CountOpenLinesStatement, con)
            CountOpenLinesCommand.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = CheckLineReturnNumber
            CountOpenLinesCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = CheckLineReturnLineNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountOpenLines = CInt(CountOpenLinesCommand.ExecuteScalar)
            Catch ex As Exception
                CountOpenLines = 0
            End Try
            con.Close()

            If CountOpenLines > 0 Then
                'Re-open Return to be vouched again
                cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET ReturnStatus = @ReturnStatus WHERE SteelReturnNumber = @SteelReturnNumber", con)

                With cmd.Parameters
                    .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                'Re-open Return to be vouched again
                cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET ReturnStatus = @ReturnStatus WHERE SteelReturnNumber = @SteelReturnNumber", con)

                With cmd.Parameters
                    .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@ReturnStatus", SqlDbType.VarChar).Value = "CLOSED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        End If
    End Sub

    'Datagrid Operations

    Private Sub dgvVoucherLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVoucherLines.CellValueChanged
        Dim LineReturnQuantity, LineExtendedAmount, LineUnitCost As Double
        Dim LineNumber As Integer = 0
        Dim LinePartDescription As String = ""
        Dim LineReturnNumber, LineReturnLine As Integer

        If Me.dgvVoucherLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvVoucherLines.CurrentCell.RowIndex

            Try
                LineNumber = Me.dgvVoucherLines.Rows(RowIndex).Cells("VoucherLineColumn").Value
            Catch ex As Exception
                LineNumber = 0
            End Try
            Try
                LineUnitCost = Me.dgvVoucherLines.Rows(RowIndex).Cells("UnitCostColumn").Value
            Catch ex As Exception
                LineUnitCost = 0
            End Try
            Try
                LineReturnQuantity = Me.dgvVoucherLines.Rows(RowIndex).Cells("QuantityColumn").Value
            Catch ex As Exception
                LineReturnQuantity = 0
            End Try
            Try
                LinePartDescription = Me.dgvVoucherLines.Rows(RowIndex).Cells("PartDescriptionColumn").Value
            Catch ex As Exception
                LinePartDescription = ""
            End Try
            Try
                LineReturnNumber = Me.dgvVoucherLines.Rows(RowIndex).Cells("ReceiverNumberColumn").Value
            Catch ex As Exception
                LineReturnNumber = 0
            End Try
            Try
                LineReturnLine = Me.dgvVoucherLines.Rows(RowIndex).Cells("ReceiverLineColumn").Value
            Catch ex As Exception
                LineReturnLine = 0
            End Try

            If LineUnitCost < 0 Then
                MsgBox("Unit Cost must be a positive number. For a negative value, set quantity to a negative.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            LineExtendedAmount = LineUnitCost * LineReturnQuantity

            'Round Variables
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)
            LineUnitCost = Math.Round(LineUnitCost, 4)

            'UPDATE Vendor Return Lines on cell value changes
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET PartDescription = @PartDescription, UnitCost = @UnitCost, Quantity = @Quantity, ExtendedAmount = @ExtendedAmount WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@VoucherLine", SqlDbType.VarChar).Value = LineNumber
                .Add("@PartDescription", SqlDbType.VarChar).Value = LinePartDescription
                .Add("@UnitCost", SqlDbType.VarChar).Value = LineUnitCost
                .Add("@Quantity", SqlDbType.VarChar).Value = LineReturnQuantity
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If

        'Load Totals and Update Header Table
        LoadVoucherTotals()

        'UPDATE Purchase Order Extended Amount based on line changes
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Re-calculate lines
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = Quantity * UnitCost WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        ShowVoucherLines()

        ''reloads totals for the lines after a change was made
        ReloadVoucherTotals()
    End Sub

    'Validate, clear, and error checking

    Public Sub ClearData()
        cboVoucherNumber.Text = ""

        cboPONumber.Refresh()
        cboReturnNumber.Refresh()
        cboVendorID.Refresh()
        cboVoucherNumber.Refresh()
        cboCheckType.Refresh()

        txtComment.Refresh()
        txtFreightTotal.Refresh()
        txtProductTotal.Refresh()
        txtReturnTotal.Refresh()
        txtVendorName.Refresh()
        txtInvoiceNumber.Refresh()

        cboPONumber.SelectedIndex = -1
        cboReturnNumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboVoucherNumber.SelectedIndex = -1
        cboLinePartNumber.SelectedIndex = -1
        cboCheckType.SelectedIndex = -1

        txtComment.Clear()
        txtFreightTotal.Clear()
        txtProductTotal.Clear()
        txtReturnTotal.Clear()
        txtVendorName.Clear()
        txtInvoiceNumber.Clear()
        txtLineUnitCost.Clear()
        txtLineQuantity.Clear()
        txtLineDescription.Clear()
        txtLineExtendedAmount.Clear()

        dtpReturnDate.Text = ""
        dtpVoucherDate.Text = ""

        cmdGenerateVoucher.Focus()

        cmdDelete.Enabled = True
        cmdSave.Enabled = True
        SaveReturnVoucherToolStripMenuItem.Enabled = True
        DeleteReturnVoucherToolStripMenuItem.Enabled = True
        dgvVoucherLines.Enabled = True
    End Sub

    Public Sub ClearVariables()
        LastInventoryTransactionNumber = 0
        NextInventoryTransactionNumber = 0
        PONumber = 0
        LastVoucherNumber = 0
        NextVoucherNumber = 0
        VendorName = ""
        InvoiceNumber = ""
        InvoiceDate = ""
        VendorID = ""
        Comment = ""
        VoucherStatus = ""
        SUMInvoiceTotal = 0
        ProductTotal = 0
        InvoiceFreight = 0
        InvoiceSalesTax = 0
        InvoiceTotal = 0
        PartNumber = ""
        PartDescription = ""
        LineComment = ""
        DebitGLAccount = ""
        CreditGLAccount = ""
        ReturnLineNumber = 0
        Quantity = 0
        Cost = 0
        ExtendedAmount = 0
        LineCost = 0
        LineExtendedAmount = 0
        LineQuantity = 0
        LinePartDescription = ""
        LineExtendedCost = 0
        InvoiceAmount = 0
        GlobalVoucherNumber = 0
        VerifyVendor = ""
        UniqueInvoice = ""
        CheckStatus = ""
        DeleteReferenceNumber = 0
        LineReturnLine = 0
        LineReturnNumber = 0
        SUMExtendedAmount = 0
        DiscountAmount = 0
        VendorClass = ""
        CheckType = ""
        VendorCheckType = ""
        ValidateCheckType = ""

        cmdDelete.Enabled = True
        cmdSave.Enabled = True
        SaveReturnVoucherToolStripMenuItem.Enabled = True
        DeleteReturnVoucherToolStripMenuItem.Enabled = True
        dgvVoucherLines.Enabled = True
    End Sub

    Public Sub VerifyUniqueInvoiceNumber()
        Dim UniqueInvoiceStatement As String = "SELECT InvoiceNumber FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VoucherNumber <> @VoucherNumber AND InvoiceNumber = @InvoiceNumber AND VendorID = @VendorID"
        Dim UniqueInvoiceCommand As New SqlCommand(UniqueInvoiceStatement, con)
        UniqueInvoiceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        UniqueInvoiceCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        UniqueInvoiceCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
        UniqueInvoiceCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UniqueInvoice = CStr(UniqueInvoiceCommand.ExecuteScalar)
        Catch ex As Exception
            UniqueInvoice = "YES"
        End Try
        con.Close()

        If UniqueInvoice = "" Then
            UniqueInvoice = "YES"
        End If
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    'Command Buttons

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Validation
        If cboVoucherNumber.Text <> "" And Val(cboVoucherNumber.Text) <> 0 Then
            'Prompt before Saving
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Vendor Return before exiting? (If NO, Voucher will be deleted)", "SAVE VENDOR RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                VerifyUniqueInvoiceNumber()

                If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" Then
                    'Validate Vendor
                    Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                    Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
                    VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
                    VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
                    Catch ex As Exception
                        VerifyVendor = ""
                    End Try
                    con.Close()

                    If VerifyVendor = "" Then
                        MsgBox("You must have a valid Vendor to process the return.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                    '***************************************************************************************************
                    'Check to see if Voucher is already posted
                    Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                    Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
                    CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckVoucherStatus = "POSTED"
                    End Try
                    con.Close()

                    If CheckVoucherStatus <> "OPEN" Then
                        MsgBox("Voucher is not open - changes cannot be saved.", MsgBoxStyle.OkOnly)
                    Else
                        'Re-calculate lines
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = Quantity * UnitCost WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'ReloadTotals
                        ReloadVoucherTotals()
                        '************************************************************************************************************************************************
                        'Determine check type
                        If cboCheckType.Text = "" Then
                            MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        Else
                            If cboCheckType.Text = "ACH" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "STANDARD" Then
                                ValidateCheckType = "OKAY"
                            Else
                                ValidateCheckType = "NOT OKAY"
                            End If
                        End If

                        If ValidateCheckType = "NOT OKAY" Then
                            MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
                            Exit Sub
                        Else
                            'Continue
                        End If
                        '************************************************************************************************************************************************
                        'Write to Header Table (ReceiptOfInvoiceBatchLine)
                        Try
                            'Write values to Batch Table
                            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET BatchNumber = @BatchNumber, PONumber = @PONumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, VendorClass = @VendorClass, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, DeleteReferenceNumber = @DeleteReferenceNumber, OnHold = @OnHold, CheckType = @CheckType WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                                .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                                .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                                .Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
                                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                                .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                                .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                                .Add("@InvoiceAmount", SqlDbType.VarChar).Value = txtReturnAmount.Text
                                .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
                                .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                                .Add("@DueDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                                .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
                                .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@VoucherSource", SqlDbType.VarChar).Value = "STEEL VENDOR RETURN"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                                .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                                .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
                                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = Today()
                            ErrorComment = ex.ToString
                            ErrorDivision = txtDivisionID.Text
                            ErrorDescription = "AP Steel Return --- Exit Button"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '*********************************************************************************************************
                        'Write values to Batch Line Table
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET InvoiceTotal = ProductTotal + InvoiceFreight + InvoiceSalesTax WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        '*********************************************************************************************************
                        'Check if net total is negative
                        If ProductTotal > 0 Or InvoiceTotal > 0 Then
                            MsgBox("The net total of this return must be negative (Credit).", MsgBoxStyle.OkOnly)
                            Exit Sub
                        End If
                        '*********************************************************************************************************
                        ''checks the return amount and return total and will prompt if rounding is needed
                        If String.IsNullOrEmpty(txtReturnAmount.Text) = False Then
                            If IsNumeric(txtReturnAmount.Text) Then
                                CheckReturnAmount()

                                If GlobalSteelReturnRounding = "EXIT SUB" Then
                                    Exit Sub
                                Else
                                    'Continue
                                End If
                            Else
                                MessageBox.Show("You must enter a value for Return Amount", "Enter a value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                txtReturnAmount.SelectAll()
                                txtReturnAmount.Focus()
                                Exit Sub
                            End If
                        End If
                        '*********************************************************************************************************
                        CheckAndUpdateSteelVendorLines()
                        '*********************************************************************************************************
                        'Update Batch Totals
                        UpdateBatchTotal()

                        GlobalAPDivisionID = txtDivisionID.Text
                        GlobalAPBatchNumber = txtBatchNumber.Text

                        'Clear Form
                        ClearData()
                        ClearVariables()

                        Dim NewAPProcessBatch As New APProcessBatch
                        NewAPProcessBatch.Show()

                        Me.Dispose()
                        Me.Close()
                        Exit Sub
                    End If
                Else
                    MsgBox("You must have a unique Invoice Number.", MsgBoxStyle.OkOnly)
                End If
            ElseIf button = DialogResult.No Then
                'Check to see if Voucher is already posted
                Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
                CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckVoucherStatus = "POSTED"
                End Try
                con.Close()

                If CheckVoucherStatus <> "OPEN" Then
                    MsgBox("Voucher cannot be deleted.", MsgBoxStyle.OkOnly)
                Else
                    'Reset Return to be selected again
                    For Each row As DataGridViewRow In dgvVoucherLines.Rows
                        Try
                            LineReturnNumber = row.Cells("ReceiverNumberColumn").Value
                        Catch ex As Exception
                            LineReturnNumber = 0
                        End Try
                        Try
                            LineReturnLine = row.Cells("ReceiverLineColumn").Value
                        Catch ex As Exception
                            LineReturnLine = 0
                        End Try

                        If LineReturnNumber = 0 Then
                            'Get Return Number
                            Dim GetReturnNumberStatement As String = "SELECT DeleteReferenceNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                            Dim GetReturnNumberCommand As New SqlCommand(GetReturnNumberStatement, con)
                            GetReturnNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            GetReturnNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetReturnNumber = CInt(GetReturnNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetReturnNumber = 0
                            End Try
                            con.Close()

                            'Re-open Vendor Return Lines
                            cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineStatus = @LineStatus WHERE SteelReturnNumber = @SteelReturnNumber", con)

                            With cmd.Parameters
                                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GetReturnNumber
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Re-open Return to be vouched again
                            cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET ReturnStatus = @ReturnStatus WHERE SteelReturnNumber = @SteelReturnNumber", con)

                            With cmd.Parameters
                                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GetReturnNumber
                                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            'Re-open Vendor Return Lines
                            cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineStatus = @LineStatus WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine", con)

                            With cmd.Parameters
                                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = LineReturnNumber
                                .Add("@SteelReturnLine", SqlDbType.VarChar).Value = LineReturnLine
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Re-open Return to be vouched again
                            cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET ReturnStatus = @ReturnStatus WHERE SteelReturnNumber = @SteelReturnNumber", con)

                            With cmd.Parameters
                                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = LineReturnNumber
                                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Next

                    'Create command to delete data
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    GlobalAPDivisionID = txtDivisionID.Text
                    GlobalAPBatchNumber = txtBatchNumber.Text

                    'Update Batch Totals
                    UpdateBatchTotal()
                    ClearData()
                    ClearVariables()

                    Dim NewAPProcessBatch As New APProcessBatch
                    NewAPProcessBatch.Show()

                    Me.Dispose()
                    Me.Close()
                    Exit Sub
                End If
            End If
        Else
            'Update Batch Total
            UpdateBatchTotal()

            GlobalAPDivisionID = txtDivisionID.Text
            GlobalAPBatchNumber = txtBatchNumber.Text

            'Clear Form
            ClearData()
            ClearVariables()

            Dim NewAPProcessBatch As New APProcessBatch
            NewAPProcessBatch.Show()

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub cmdGenerateVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateVoucher.Click
        'Clear Data on next number
        ClearVariables()
        ClearData()

        'Find the next Voucher Number to use
        Dim MAXStatement As String = "SELECT MAX(VoucherNumber) FROM ReceiptOfInvoiceBatchLine"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastVoucherNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastVoucherNumber = 3300000
        End Try
        con.Close()

        NextVoucherNumber = LastVoucherNumber + 1

        'Write values to Batch Table
        cmd = New SqlCommand("Insert Into ReceiptOfInvoiceBatchLine(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, DeleteReferenceNumber, InvoiceAmount, VendorClass, OnHold, CheckType) Values (@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @VendorID, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @DeleteReferenceNumber, @InvoiceAmount, @VendorClass, @OnHold, @CheckType)", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = NextVoucherNumber
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
            .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
            .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
            .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@DueDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
            .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@VoucherSource", SqlDbType.VarChar).Value = "STEEL VENDOR RETURN"
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = 0
            .Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
            .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        LoadVoucher()
        cboVoucherNumber.Text = NextVoucherNumber
    End Sub

    Private Sub cmdClearForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearForm.Click
        ClearData()
        ClearVariables()
        ClearDatagrid()
    End Sub

    Private Sub cmdAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLine.Click
        If cboLinePartNumber.Text = "" Or txtLineDescription.Text = "" Then
            MsgBox("You must have a part # and description.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Validate Fields
        If Val(txtLineUnitCost.Text) < 0 Then
            MsgBox("Unit Cost must be a positive number. For a negative value, set quantity to a negative.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Validate Part
        Dim CountPartNumber As Integer = 0

        Dim CountPartNumberStatement As String = "SELECT COUNT(ItemID) FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim CountPartNumberCommand As New SqlCommand(CountPartNumberStatement, con)
        CountPartNumberCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboLinePartNumber.Text
        CountPartNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountPartNumber = CInt(CountPartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CountPartNumber = 0
        End Try
        con.Close()

        If CountPartNumber = 0 Then
            MsgBox("You must select a valid part number.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Verify if real part #
        Dim GetDebitAccount As String = ""

        'Get Item Class
        Dim GetDebitAccountStatement As String = "SELECT GLDebitAccount FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim GetDebitAccountCommand As New SqlCommand(GetDebitAccountStatement, con)
        GetDebitAccountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboLinePartNumber.Text
        GetDebitAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetDebitAccount = CStr(GetDebitAccountCommand.ExecuteScalar)
        Catch ex As Exception
            GetDebitAccount = "20999"
        End Try
        con.Close()

        'Add line
        Dim GetLastLine, NextLineNumber As Integer

        Dim GetLastLineStatement As String = "SELECT MAX(VoucherLine) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim GetLastLineCommand As New SqlCommand(GetLastLineStatement, con)
        GetLastLineCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLastLine = CInt(GetLastLineCommand.ExecuteScalar)
        Catch ex As Exception
            GetLastLine = 0
        End Try
        con.Close()

        NextLineNumber = GetLastLine + 1

        'Add line
        cmd = New SqlCommand("Insert Into ReceiptOfInvoiceVoucherLines(VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice, ReceiverNumber, ReceiverLine, DivisionID)Values(@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, @SelectForInvoice, @ReceiverNumber, @ReceiverLine, @DivisionID)", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            .Add("@VoucherLine", SqlDbType.VarChar).Value = NextLineNumber
            .Add("@PartNumber", SqlDbType.VarChar).Value = cboLinePartNumber.Text
            .Add("@PartDescription", SqlDbType.VarChar).Value = txtLineDescription.Text
            .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtLineQuantity.Text)
            .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtLineUnitCost.Text)
            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtLineExtendedAmount.Text)
            .Add("@GLDebitAccount", SqlDbType.VarChar).Value = "20000"
            .Add("@GLCreditAccount", SqlDbType.VarChar).Value = GetDebitAccount
            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "RECEIVED"
            .Add("@ReceiverNumber", SqlDbType.VarChar).Value = 0
            .Add("@ReceiverLine", SqlDbType.VarChar).Value = 0
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Load Totals
        ReloadVoucherTotals()

        'Refresh datagrid
        ShowVoucherLines()

        'Clear fields
        cmdClearLines_Click(sender, e)
    End Sub

    Private Sub cmdClearLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLines.Click
        cboLinePartNumber.SelectedIndex = -1
        cboDebitAccount.SelectedIndex = -1
        cboDebitDescription.SelectedIndex = -1

        txtLineDescription.Clear()
        txtLineExtendedAmount.Clear()
        txtLineQuantity.Clear()
        txtLineUnitCost.Clear()

        cboLinePartNumber.Focus()
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If Val(cboVoucherNumber.Text) = 0 Or cboVoucherNumber.Text = "" Then
            MsgBox("You must have a voucher # selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If

        'Validate
        If dgvVoucherLines.RowCount > 0 Then
            'Check Line number
            If Val(cboDeleteLine.Text) > Me.dgvVoucherLines.RowCount Then
                MsgBox("You must select a valid line to delete.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            'Update Steel Return Line back to POSTED
            Dim GetReturnNumber, GetReturnLine As Integer

            Dim GetReturnNumberStatement As String = "SELECT ReceiverNumber FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
            Dim GetReturnNumberCommand As New SqlCommand(GetReturnNumberStatement, con)
            GetReturnNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            GetReturnNumberCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)

            Dim GetReturnLineStatement As String = "SELECT ReceiverLine FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
            Dim GetReturnLineCommand As New SqlCommand(GetReturnLineStatement, con)
            GetReturnLineCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            GetReturnLineCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetReturnNumber = CInt(GetReturnNumberCommand.ExecuteScalar)
            Catch ex As Exception
                GetReturnNumber = 0
            End Try
            Try
                GetReturnLine = CInt(GetReturnLineCommand.ExecuteScalar)
            Catch ex As Exception
                GetReturnLine = 0
            End Try
            con.Close()

            If GetReturnNumber <> 0 Then
                'Update Steel Return to Posted
                cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineStatus = 'POSTED' WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine", con)
                cmd.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GetReturnNumber
                cmd.Parameters.Add("@SteelReturnLine", SqlDbType.VarChar).Value = GetReturnLine

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET ReturnStatus = 'POSTED' WHERE SteelReturnNumber = @SteelReturnNumber", con)
                cmd.Parameters.Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GetReturnNumber

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            'Delete line
            cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)
            cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            cmd.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Refresh datagrid
            ShowVoucherLines()

            'Renumber Lines in datagrid
            Dim TempLineNumber As Integer = 1000
            Dim LineNumber As Integer

            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Try
                    LineNumber = row.Cells("VoucherLineColumn").Value
                Catch ex As Exception
                    LineNumber = 0
                End Try

                'UPDATE Voucher Lines
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine2", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = TempLineNumber
                    .Add("@VoucherLine2", SqlDbType.VarChar).Value = LineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                TempLineNumber = TempLineNumber + 1
            Next

            'Reload datagrid
            ShowVoucherLines()

            'Renumber lines
            Dim TempLineNumber2 As Integer = 1

            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Try
                    LineNumber = row.Cells("VoucherLineColumn").Value
                Catch ex As Exception
                    LineNumber = 0
                End Try

                'UPDATE Voucher Lines
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET VoucherLine = @VoucherLine WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine2", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@VoucherLine", SqlDbType.VarChar).Value = TempLineNumber2
                    .Add("@VoucherLine2", SqlDbType.VarChar).Value = LineNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                TempLineNumber2 = TempLineNumber2 + 1
            Next

            'Load datagrid
            ShowVoucherLines()

            'Clear Fields
            cboDeleteLine.SelectedIndex = -1
            txtDeletePartNumber.Clear()
            txtDeleteDescription.Clear()

            'Update Totals
            ReloadVoucherTotals()

            MsgBox("Line has been deleted.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        VerifyUniqueInvoiceNumber()

        If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" Then

            'Validate Vendor
            Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
            Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
            VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
            VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
            Catch ex As Exception
                VerifyVendor = ""
            End Try
            con.Close()

            If VerifyVendor = "" Then
                MsgBox("You must have a valid Vendor to process the return.", MsgBoxStyle.OkOnly)
            Else
                'Check to see if Voucher is already posted
                Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
                CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckVoucherStatus = "POSTED"
                End Try
                con.Close()

                If CheckVoucherStatus <> "OPEN" Then
                    'Open Vendor Return Print Form
                    GlobalVendorReturnNumber = Val(cboReturnNumber.Text)
                    GlobalDivisionCode = txtDivisionID.Text
                    Dim NewPrintVendorReturn As New PrintVendorReturn
                    NewPrintVendorReturn.Show()
                Else
                    'Re-calculate lines
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = Quantity * UnitCost WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'ReloadTotals
                    ReloadVoucherTotals()

                    'Write to Header Table (ReceiptOfInvoiceBatchLine)
                    Try
                        'Write values to Batch Table
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET BatchNumber = @BatchNumber, PONumber = @PONumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, VendorClass = @VendorClass, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, DeleteReferenceNumber = @DeleteReferenceNumber, OnHold = @OnHold, CheckType = @CheckType WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                            .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                            .Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = txtReturnAmount.Text
                            .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
                            .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                            .Add("@DueDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                            .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
                            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@VoucherSource", SqlDbType.VarChar).Value = "STEEL VENDOR RETURN"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                            .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
                            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempVoucherNumber As Integer = 0
                        Dim strVoucherNumber As String
                        TempVoucherNumber = Val(cboVoucherNumber.Text)
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString
                        ErrorDivision = txtDivisionID.Text
                        ErrorDescription = "AP Steel Return --- Print Button"
                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    ShowVoucherLines()
                    LoadVoucherTotals()
                    CheckAndUpdateSteelVendorLines()

                    'Write values to Batch Line Table
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET InvoiceTotal = ProductTotal + InvoiceFreight + InvoiceSalesTax WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Open Vendor Return Print Form
                    GlobalVendorReturnNumber = Val(cboReturnNumber.Text)
                    GlobalDivisionCode = txtDivisionID.Text

                    Dim NewPrintVendorReturn As New PrintVendorReturn
                    NewPrintVendorReturn.Show()
                End If
            End If
        Else
            MsgBox("You must have a unique Invoice Number.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'Prompt before deleting
        If cboVoucherNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number selected.", MsgBoxStyle.OkOnly)
        Else
            Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Return?", "DELETE VENDOR RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Validate Open only
                Dim CheckStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim CheckStatusCommand As New SqlCommand(CheckStatusStatement, con)
                CheckStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                CheckStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckStatus = CStr(CheckStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckStatus = ""
                End Try
                con.Close()

                If CheckStatus = "POSTED" Or CheckStatus = "CLOSED" Or CheckStatus = "" Then
                    'MsgBox("You cannot delete this Return Voucher.", MsgBoxStyle.OkOnly)
                Else
                    ''UPDATE Line Table on changes in the datagrid
                    For Each row As DataGridViewRow In dgvVoucherLines.Rows
                        Try
                            LineReturnNumber = row.Cells("ReceiverNumberColumn").Value
                        Catch ex As Exception
                            LineReturnNumber = 0
                        End Try
                        Try
                            LineReturnLine = row.Cells("ReceiverLineColumn").Value
                        Catch ex As Exception
                            LineReturnLine = 0
                        End Try

                        If LineReturnNumber = 0 Then
                            'Get Return Number
                            Dim GetReturnNumberStatement As String = "SELECT DeleteReferenceNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                            Dim GetReturnNumberCommand As New SqlCommand(GetReturnNumberStatement, con)
                            GetReturnNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            GetReturnNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                            If con.State = ConnectionState.Closed Then con.Open()
                            Try
                                GetReturnNumber = CInt(GetReturnNumberCommand.ExecuteScalar)
                            Catch ex As Exception
                                GetReturnNumber = 0
                            End Try
                            con.Close()

                            'Re-open Vendor Return Lines
                            cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineStatus = @LineStatus WHERE SteelReturnNumber = @SteelReturnNumber", con)

                            With cmd.Parameters
                                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GetReturnNumber
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Re-open Return to be vouched again
                            cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET ReturnStatus = @ReturnStatus WHERE SteelReturnNumber = @SteelReturnNumber", con)

                            With cmd.Parameters
                                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = GetReturnNumber
                                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            'Re-open Vendor Return Lines
                            cmd = New SqlCommand("UPDATE SteelReturnLineTable SET LineStatus = @LineStatus WHERE SteelReturnNumber = @SteelReturnNumber AND SteelReturnLine = @SteelReturnLine", con)

                            With cmd.Parameters
                                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = LineReturnNumber
                                .Add("@SteelReturnLine", SqlDbType.VarChar).Value = LineReturnLine
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Re-open Return to be vouched again
                            cmd = New SqlCommand("UPDATE SteelReturnHeaderTable SET ReturnStatus = @ReturnStatus WHERE SteelReturnNumber = @SteelReturnNumber", con)

                            With cmd.Parameters
                                .Add("@SteelReturnNumber", SqlDbType.VarChar).Value = LineReturnNumber
                                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End If
                    Next

                    'Delete Voucher
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Clear Form
                    ClearData()
                    ClearVariables()
                    ShowVoucherLines()
                    LoadVendor()
                    LoadVoucher()
                    LoadPONumber()
                End If
            ElseIf button = DialogResult.No Then
                cmdDelete.Focus()
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Validation - Voucher Number
        If cboVoucherNumber.Text = "" Or Val(cboVoucherNumber.Text) = 0 Then
            MsgBox("You must have a valid voucher number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '************************************************************************************************
        'Validation - Invoice Number
        VerifyUniqueInvoiceNumber()

        If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" Then
            'Continue
        Else
            MsgBox("You must have a valid Invoice number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '************************************************************************************************
        'Validation - Voucher Status
        'Check to see if Voucher is already posted
        Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
        CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
        Catch ex As Exception
            CheckVoucherStatus = "POSTED"
        End Try
        con.Close()

        If CheckVoucherStatus <> "OPEN" Then
            MsgBox("Voucher cannot be saved at this time.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '************************************************************************************************
        'Validation - Vendor
        Dim VerifyVendorStatement As String = "SELECT VendorCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VerifyVendorCommand As New SqlCommand(VerifyVendorStatement, con)
        VerifyVendorCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VerifyVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VerifyVendor = CStr(VerifyVendorCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyVendor = ""
        End Try
        con.Close()

        If VerifyVendor = "" Then
            MsgBox("You must have a valid Vendor to process the return.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '************************************************************************************************************************************************
        'Determine check type
        If cboCheckType.Text = "" Then
            MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            If cboCheckType.Text = "ACH" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "STANDARD" Then
                ValidateCheckType = "OKAY"
            Else
                ValidateCheckType = "NOT OKAY"
            End If
        End If

        If ValidateCheckType = "NOT OKAY" Then
            MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If
        '************************************************************************************************************************************************
        'Prompt before Saving
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this Vendor Return?", "SAVE VENDOR RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Re-calculate lines
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = Quantity * UnitCost WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'ReloadTotals
            ReloadVoucherTotals()

            'Write to Header Table (ReceiptOfInvoiceBatchLine)
            Try
                'Write values to Batch Table
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET BatchNumber = @BatchNumber, PONumber = @PONumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, VendorClass = @VendorClass, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, DeleteReferenceNumber = @DeleteReferenceNumber, OnHold = @OnHold, CheckType = @CheckType WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                    .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                    .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                    .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                    .Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                    .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@InvoiceAmount", SqlDbType.VarChar).Value = txtReturnAmount.Text
                    .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
                    .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@DueDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                    .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
                    .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@VoucherSource", SqlDbType.VarChar).Value = "STEEL VENDOR RETURN"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                    .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                    .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
                    .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempVoucherNumber As Integer = 0
                Dim strVoucherNumber As String
                TempVoucherNumber = Val(cboVoucherNumber.Text)
                strVoucherNumber = CStr(TempVoucherNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString
                ErrorDivision = txtDivisionID.Text
                ErrorDescription = "AP Steel Return --- Save Button"
                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            ShowVoucherLines()
            LoadVoucherTotals()

            'Write values to Batch Line Table
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET InvoiceTotal = ProductTotal + InvoiceFreight + InvoiceSalesTax WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            CheckAndUpdateSteelVendorLines()

            MsgBox("This Return Voucher has been saved.", MsgBoxStyle.OkOnly)
        ElseIf button = DialogResult.No Then
            cboVoucherNumber.Focus()
        End If
    End Sub

    Private Sub cmdEnterNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterNew.Click
        VerifyUniqueInvoiceNumber()

        If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number and Invoice Number.", MsgBoxStyle.OkOnly)
            cboVoucherNumber.Focus()
        Else
            If UniqueInvoice = "YES" Then
                'Check to see if Voucher is already posted
                Dim CheckVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim CheckVoucherStatusCommand As New SqlCommand(CheckVoucherStatusStatement, con)
                CheckVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                CheckVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckVoucherStatus = CStr(CheckVoucherStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckVoucherStatus = "POSTED"
                End Try
                con.Close()

                If CheckVoucherStatus <> "OPEN" Then
                    'Don't save changes
                Else
                    '************************************************************************************************************************************************
                    'Determine check type
                    If cboCheckType.Text = "" Then
                        MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    Else
                        If cboCheckType.Text = "ACH" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "STANDARD" Then
                            ValidateCheckType = "OKAY"
                        Else
                            ValidateCheckType = "NOT OKAY"
                        End If
                    End If

                    If ValidateCheckType = "NOT OKAY" Then
                        MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    Else
                        'Continue
                    End If
                    '************************************************************************************************************************************************
                    'Re-calculate lines
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = Quantity * UnitCost WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Check for rounding
                    CheckReturnAmount()
                    '************************************************************************************************************************************************
                    'Write to Header Table (ReceiptOfInvoiceBatchLine)
                    Try
                        'Write values to Batch Table
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET BatchNumber = @BatchNumber, PONumber = @PONumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, VendorClass = @VendorClass, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, DeleteReferenceNumber = @DeleteReferenceNumber, OnHold = @OnHold, CheckType = @CheckType WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                            .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                            .Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = txtReturnAmount.Text
                            .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
                            .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                            .Add("@DueDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                            .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
                            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@VoucherSource", SqlDbType.VarChar).Value = "STEEL VENDOR RETURN"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                            .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
                            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempVoucherNumber As Integer = 0
                        Dim strVoucherNumber As String
                        TempVoucherNumber = Val(cboVoucherNumber.Text)
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString
                        ErrorDivision = txtDivisionID.Text
                        ErrorDescription = "AP Steel Return --- Add New Voucher Button"
                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    'Update Totals from the line items
                    Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                    Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
                    SUMExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SUMExtendedAmount = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
                    Catch ex1 As Exception
                        SUMExtendedAmount = 0
                    End Try
                    con.Close()

                    ProductTotal = SUMExtendedAmount
                    InvoiceTotal = ProductTotal + Val(txtFreightTotal.Text)

                    ProductTotal = Math.Round(ProductTotal, 2)
                    InvoiceTotal = Math.Round(InvoiceTotal, 2)

                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                    cmd.Parameters.Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    cmd.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    txtFreightTotal.Text = InvoiceFreight
                    txtReturnTotal.Text = FormatCurrency(InvoiceTotal, 2)
                    txtProductTotal.Text = FormatCurrency(ProductTotal, 2)

                    'Check if net total is negative
                    If ProductTotal > 0 Or InvoiceTotal > 0 Then
                        MsgBox("The net total of this return must be negative (Credit).", MsgBoxStyle.OkOnly)
                        Exit Sub
                    End If
                    '******************************************************************************************
                    'Clear text fields for next entry
                    ClearVariables()
                    ClearData()
                    ClearDatagrid()

                    'Get New Voucher Number
                    Dim LastVoucherNumber, NextVoucherNumber As Integer

                    Dim LastVoucherNumberStatement As String = "SELECT MAX(VoucherNumber) FROM ReceiptOfInvoiceBatchLine"
                    Dim LastVoucherNumberCommand As New SqlCommand(LastVoucherNumberStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastVoucherNumber = CInt(LastVoucherNumberCommand.ExecuteScalar)
                    Catch ex1 As Exception
                        LastVoucherNumber = 0
                    End Try
                    con.Close()

                    NextVoucherNumber = LastVoucherNumber + 1

                    'Write values to Batch Table
                    cmd = New SqlCommand("Insert Into ReceiptOfInvoiceBatchLine(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, DeleteReferenceNumber, InvoiceAmount, VendorClass, OnHold, CheckType) Values (@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @VendorID, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @DeleteReferenceNumber, @InvoiceAmount, @VendorClass, @OnHold, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = NextVoucherNumber
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpVoucherDate.Text
                        .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                        .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                        .Add("@InvoiceFreight", SqlDbType.VarChar).Value = 0
                        .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = 0
                        .Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
                        .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
                        .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                        .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                        .Add("@DueDate", SqlDbType.VarChar).Value = dtpReturnDate.Text
                        .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
                        .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@VoucherSource", SqlDbType.VarChar).Value = "STEEL VENDOR RETURN"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                        .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                        .Add("@InvoiceAmount", SqlDbType.VarChar).Value = 0
                        .Add("@VendorClass", SqlDbType.VarChar).Value = "SteelVendor"
                        .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
                        .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    CheckAndUpdateSteelVendorLines()

                    LoadVendor()
                    LoadVoucher()
                    ShowVoucherLines()
                    cboVoucherNumber.Text = NextVoucherNumber
                    cboVoucherNumber.Focus()
                End If
            Else
                MsgBox("This Invoice Number has already been used.", MsgBoxStyle.OkOnly)
                txtInvoiceNumber.Focus()
            End If
        End If
    End Sub

    Private Sub cmdSelectByReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectByReturn.Click
        GlobalDivisionCode = txtDivisionID.Text
        GlobalVoucherNumber = Val(cboVoucherNumber.Text)
        GlobalSteelReturnNumber = Val(cboReturnNumber.Text)

        Using NewSelectSteelVendorReturnLines As New SelectSteelVendorReturnLines
            Dim Result = NewSelectSteelVendorReturnLines.ShowDialog
        End Using

        ReloadVoucherTotals()
        ShowVoucherLines()
    End Sub

    'Menu strip Functions

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub SaveReturnVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveReturnVoucherToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub PrintReturnVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintReturnVoucherToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub DeleteReturnVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteReturnVoucherToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        cmdClearForm_Click(sender, e)
    End Sub

    'Combo Box Functions

    Private Sub cboVoucherNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVoucherNumber.SelectedIndexChanged
        LoadReturnVoucherData()
        ShowVoucherLines()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLinePartNumber.SelectedIndexChanged
        LoadPartDescription()
    End Sub

    Private Sub cboDeleteLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDeleteLine.SelectedIndexChanged
        'Load Part Number / Description upon change
        Dim DeletePartNumber, DeletePartDescription As String

        Dim DeletePartNumberStatement As String = "SELECT PartNumber FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
        Dim DeletePartNumberCommand As New SqlCommand(DeletePartNumberStatement, con)
        DeletePartNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        DeletePartNumberCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)

        Dim DeletePartDescriptionStatement As String = "SELECT PartDescription FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
        Dim DeletePartDescriptionCommand As New SqlCommand(DeletePartDescriptionStatement, con)
        DeletePartDescriptionCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        DeletePartDescriptionCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = Val(cboDeleteLine.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DeletePartNumber = CStr(DeletePartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            DeletePartNumber = ""
        End Try
        Try
            DeletePartDescription = CStr(DeletePartDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            DeletePartDescription = ""
        End Try
        con.Close()

        If cboDeleteLine.Text = "" Then
            txtDeleteDescription.Clear()
            txtDeletePartNumber.Clear()
        Else
            txtDeleteDescription.Text = DeletePartDescription
            txtDeletePartNumber.Text = DeletePartNumber
        End If
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorData()
        LoadPONumber()
        LoadReturnNumber()
    End Sub

    'Text Box Functions

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineQuantity.TextChanged
        If Val(txtLineQuantity.Text) <> 0 And Val(txtLineUnitCost.Text) <> 0 Then
            LineQuantity = Val(txtLineQuantity.Text)
            LineCost = Val(txtLineUnitCost.Text)

            LineExtendedAmount = LineQuantity * LineCost
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)
            txtLineExtendedAmount.Text = LineExtendedAmount
        End If
    End Sub

    Private Sub txtUnitCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineUnitCost.TextChanged
        If Val(txtLineQuantity.Text) <> 0 And Val(txtLineUnitCost.Text) <> 0 Then
            LineQuantity = Val(txtLineQuantity.Text)
            LineCost = Val(txtLineUnitCost.Text)

            LineExtendedAmount = LineQuantity * LineCost
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)
            txtLineExtendedAmount.Text = LineExtendedAmount
        End If
    End Sub

    Private Sub txtFreightTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightTotal.TextChanged
        ReloadVoucherTotals()
    End Sub

    Private Sub txtOtherTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtherTotal.TextChanged
        ReloadVoucherTotals()
    End Sub

    'Miscellaneous Functions (Link Label, Date Time Picker, etc.)

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

End Class