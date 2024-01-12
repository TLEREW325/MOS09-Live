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
Public Class APProcessReturns
    Inherits System.Windows.Forms.Form

    Dim LineReturnNumber, LineReturnLine, LineQuantity, LastInventoryTransactionNumber, NextInventoryTransactionNumber, PONumber, LastVoucherNumber, NextVoucherNumber As Integer
    Dim Checked1099, LongDescription, LinePartDescription, VendorName, InvoiceNumber, InvoiceDate, VendorID, Comment As String
    Dim LineExtendedAmount, LineCost, LineExtendedCost, SUMInvoiceTotal, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal As Double
    Dim WhitePaper, CheckType, VendorClass, CheckStatus, VerifyVendor, UniqueInvoice, VoucherDate, VoucherStatus, PartNumber, PartDescription, LineComment, DebitGLAccount, CreditGLAccount As String
    Dim DeleteReferenceNumber, GetReturnNumber, ReturnLineNumber As Integer
    Dim DiscountAmount, SUMExtendedAmount, Cost, ExtendedAmount, InvoiceAmount, Quantity As Double
    Dim ReturnDate As String
    Dim DeleteDescription, DeletePartNumber, CheckVoucherStatus As String
    Dim ReturnDueDate, ReturnDiscountDate As Date
    Dim ValidateCheckType As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    'Form Operations

    Private Sub APProcessReturns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Call Disable(Me)

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.VendorClass' table. You can move, or remove it, as needed.
        Me.VendorClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.VendorClass)

        'Load default from Batch Form
        txtDivisionID.Text = GlobalAPDivisionID
        txtBatchNumber.Text = GlobalAPBatchNumber

        LoadVendor()
        LoadVoucher()
        LoadPartNumber()
        ClearData()

        If GlobalVoucherNumber > 0 Then
            cboVoucherNumber.Text = GlobalVoucherNumber
        Else
            cboVoucherNumber.SelectedIndex = -1
            cboReturnNumber.SelectedIndex = -1
            cboPONumber.SelectedIndex = -1
        End If
    End Sub

    'Load datasets into controls

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

    Public Sub ClearDataInDatagrid()
        Me.dgvVoucherLines.DataSource = Nothing
    End Sub

    Public Sub LoadVendor()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
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
        cmd.Parameters.Add("@VoucherSource", SqlDbType.VarChar).Value = "VENDOR RETURN"
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
        cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "PurchaseOrderHeaderTable")
        cboPONumber.DataSource = ds3.Tables("PurchaseOrderHeaderTable")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadReturnNumber()
        'Load Voucher Number for specific division
        cmd = New SqlCommand("SELECT ReturnNumber FROM VendorReturn WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND ReturnStatus = @ReturnStatus", con)
        cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        cmd.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "VendorReturn")
        cboReturnNumber.DataSource = ds4.Tables("VendorReturn")
        con.Close()
        cboReturnNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        'Load Vendor table for specific division
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM NonInventoryItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "NonInventoryItemList")
        cboPartnumber.DataSource = ds5.Tables("NonInventoryItemList")
        cboPartDescription.DataSource = ds5.Tables("NonInventoryItemList")
        con.Close()
        cboPartnumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    'Load data

    Public Sub LoadVendorData()
        Dim VendorVendorName, VendorVendorClass, VendorCheckType, VendorWhitePaper As String

        Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
        VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim CheckTypeStatement As String = "SELECT CheckCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim CheckTypeCommand As New SqlCommand(CheckTypeStatement, con)
        CheckTypeCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        CheckTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim WhitePaperCheckStatement As String = "SELECT WhitePaperCheck FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim WhitePaperCheckCommand As New SqlCommand(WhitePaperCheckStatement, con)
        WhitePaperCheckCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        WhitePaperCheckCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim Checked1099Statement As String = "SELECT Checked1099 FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim Checked1099Command As New SqlCommand(Checked1099Statement, con)
        Checked1099Command.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        Checked1099Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorVendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorVendorName = ""
        End Try
        Try
            VendorVendorClass = CStr(VendorClassCommand.ExecuteScalar)
        Catch ex As Exception
            VendorVendorClass = ""
        End Try
        Try
            VendorCheckType = CStr(CheckTypeCommand.ExecuteScalar)
        Catch ex As Exception
            VendorCheckType = "STANDARD"
        End Try
        Try
            VendorWhitePaper = CStr(WhitePaperCheckCommand.ExecuteScalar)
        Catch ex As Exception
            VendorWhitePaper = "NO"
        End Try
        Try
            Checked1099 = CStr(Checked1099Command.ExecuteScalar)
        Catch ex As Exception
            Checked1099 = "NO"
        End Try
        con.Close()

        txtVendorName.Text = VendorVendorName
        cboVendorClass.Text = VendorVendorClass
        cboCheckType.Text = VendorCheckType

        If VendorWhitePaper = "NO" Then
            chkWhitePaper.Checked = False
        Else
            chkWhitePaper.Checked = True
        End If
    End Sub

    Public Sub LoadLongDescription()
        Dim LongDescriptionStatement As String = "SELECT LongDescription FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim LongDescriptionCommand As New SqlCommand(LongDescriptionStatement, con)
        LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartnumber.Text
        LongDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LongDescription = CStr(LongDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            LongDescription = ""
        End Try
        con.Close()

        txtLongDescription.Text = LongDescription
    End Sub

    Public Sub LoadDeletePartData()
        Dim DeleteDescriptionStatement As String = "SELECT PartDescription FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
        Dim DeleteDescriptionCommand As New SqlCommand(DeleteDescriptionStatement, con)
        DeleteDescriptionCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = cboPartnumber.Text
        DeleteDescriptionCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim DeletePartNumberStatement As String = "SELECT LongDescription FROM ItemList WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
        Dim DeletePartNumberCommand As New SqlCommand(DeletePartNumberStatement, con)
        DeletePartNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = cboPartnumber.Text
        DeletePartNumberCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DeleteDescription = CStr(DeleteDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            DeleteDescription = ""
        End Try
        Try
            DeletePartNumber = CStr(DeletePartNumberCommand.ExecuteScalar)
        Catch ex As Exception
            DeletePartNumber = ""
        End Try
        con.Close()

        txtDeleteDescription.Text = DeleteDescription
        txtDeleteDescription.Text = DeletePartNumber
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

        Dim WhitePaperStatement As String = "SELECT WhitePaper FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim WhitePaperCommand As New SqlCommand(WhitePaperStatement, con)
        WhitePaperCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        WhitePaperCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        WhitePaperCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        Dim Checked1099Statement As String = "SELECT Checked1099 FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
        Dim Checked1099Command As New SqlCommand(Checked1099Statement, con)
        Checked1099Command.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        Checked1099Command.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        Checked1099Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

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
            InvoiceSalesTax = CDbl(InvoiceSalesTaxCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceSalesTax = 0
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
        Try
            WhitePaper = CStr(WhitePaperCommand.ExecuteScalar)
        Catch ex As Exception
            WhitePaper = "NO"
        End Try
        Try
            Checked1099 = CStr(Checked1099Command.ExecuteScalar)
        Catch ex As Exception
            Checked1099 = "NO"
        End Try
        con.Close()

        cboVendorID.Text = VendorID
        cboPONumber.Text = PONumber
        txtInvoiceNumber.Text = InvoiceNumber
        dtpReturnDateDD.Text = InvoiceDate
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtFreightTotal.Text = InvoiceFreight
        txtSalesTaxTotal.Text = InvoiceSalesTax
        txtReturnTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtComment.Text = Comment
        dtpReturnVoucherDateDD.Text = VoucherDate
        cboReturnNumber.Text = DeleteReferenceNumber
        txtReturnAmount.Text = InvoiceAmount
        cboCheckType.Text = CheckType

        If WhitePaper = "NO" Then
            chkWhitePaper.Checked = False
        Else
            chkWhitePaper.Checked = True
        End If

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

    Public Sub LoadReturnDate()
        Dim ReturnDateStatement As String = "SELECT ReturnDate FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
        Dim ReturnDateCommand As New SqlCommand(ReturnDateStatement, con)
        ReturnDateCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        ReturnDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ReturnDate = CStr(ReturnDateCommand.ExecuteScalar)
        Catch ex As Exception
            ReturnDate = ""
        End Try
        con.Close()

        dtpReturnDateDD.Text = ReturnDate
    End Sub

    Public Sub LoadVoucherTotals()
        Dim ProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        Dim SalesTaxTotalStatement As String = "SELECT InvoiceSalesTax FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim SalesTaxTotalCommand As New SqlCommand(SalesTaxTotalStatement, con)
        SalesTaxTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        SalesTaxTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

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
            InvoiceSalesTax = CDbl(SalesTaxTotalCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceSalesTax = 0
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
        txtSalesTaxTotal.Text = InvoiceSalesTax
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
        InvoiceSalesTax = Val(txtSalesTaxTotal.Text)

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

    Public Sub LoadIntercompanyDueDate()
        Dim DissectInvoiceDate As Date
        Dim intDay, intMonth, intYear As Integer
        Dim intNewDay, intNewMonth, intNewYear As Integer
        Dim strNewDay, strNewMonth, strNewYear As String
        Dim strInterCompanyDueDate As String = ""
        DissectInvoiceDate = dtpReturnVoucherDateDD.Value

        intDay = DissectInvoiceDate.Day
        intMonth = DissectInvoiceDate.Month
        intYear = DissectInvoiceDate.Year

        If intDay <= 15 Then
            intNewDay = 5
            If intMonth < 12 Then
                intNewMonth = intMonth + 1
            Else
                intNewMonth = 1
            End If
        Else
            intNewDay = 20
            If intMonth < 12 Then
                intNewMonth = intMonth + 1
            Else
                intNewMonth = 1
            End If
        End If

        If intMonth = 12 Then
            intNewYear = intYear + 1
        Else
            intNewYear = intYear
        End If

        strNewDay = CStr(intNewDay)
        strNewMonth = CStr(intNewMonth)
        strNewYear = CStr(intNewYear)

        strInterCompanyDueDate = strNewMonth + "/" + strNewDay + "/" + strNewYear

        ReturnDiscountDate = strInterCompanyDueDate
        ReturnDueDate = strInterCompanyDueDate
    End Sub

    'Datagrid operations

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvVoucherLines.CellValueChanged
        Dim LineOrderQuantity, LineExtendedAmount, LineUnitCost As Double
        Dim LineNumber As Integer
        Dim LinePartNumber, LinePartDescription, LineGLDebitAccount, LineGLCreditAccount As String

        If Me.dgvVoucherLines.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvVoucherLines.CurrentCell.RowIndex

            Try
                LineUnitCost = Me.dgvVoucherLines.Rows(RowIndex).Cells("UnitCostColumn").Value
            Catch ex As Exception
                LineUnitCost = 0
            End Try
            Try
                LineOrderQuantity = Me.dgvVoucherLines.Rows(RowIndex).Cells("QuantityColumn").Value
            Catch ex As Exception
                LineOrderQuantity = 0
            End Try
            Try
                LinePartNumber = Me.dgvVoucherLines.Rows(RowIndex).Cells("PartNumberColumn").Value
            Catch ex As Exception
                LinePartNumber = ""
            End Try
            Try
                LinePartDescription = Me.dgvVoucherLines.Rows(RowIndex).Cells("PartDescriptionColumn").Value
            Catch ex As Exception
                LinePartDescription = ""
            End Try
            Try
                LineGLDebitAccount = Me.dgvVoucherLines.Rows(RowIndex).Cells("GLDebitAccountColumn").Value
            Catch ex As Exception
                LineGLDebitAccount = ""
            End Try
            Try
                LineGLCreditAccount = Me.dgvVoucherLines.Rows(RowIndex).Cells("GLCreditAccountColumn").Value
            Catch ex As Exception
                LineGLCreditAccount = ""
            End Try
            Try
                LineNumber = Me.dgvVoucherLines.Rows(RowIndex).Cells("VoucherLineColumn").Value
            Catch ex As Exception
                LineNumber = 0
            End Try

            If LineUnitCost < 0 Then
                MsgBox("Unit Cost must be a positive number. For a negative value, set quantity to a negative.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            LineExtendedAmount = LineUnitCost * LineOrderQuantity

            'Round Variables
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)
            LineUnitCost = Math.Round(LineUnitCost, 4)

            'UPDATE Vendor Return Lines on cell value changes
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET PartNumber = @PartNumber, PartDescription = @PartDescription, UnitCost = @UnitCost, Quantity = @Quantity, ExtendedAmount = @ExtendedAmount, GLDebitAccount = @GLDebitAccount, GLCreditAccount = @GLCreditAccount WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@VoucherLine", SqlDbType.VarChar).Value = LineNumber
                .Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                .Add("@PartDescription", SqlDbType.VarChar).Value = LinePartDescription
                .Add("@UnitCost", SqlDbType.VarChar).Value = LineUnitCost
                .Add("@Quantity", SqlDbType.VarChar).Value = LineOrderQuantity
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                .Add("@GLDebitAccount", SqlDbType.VarChar).Value = LineGLDebitAccount
                .Add("@GLCreditAccount", SqlDbType.VarChar).Value = LineGLCreditAccount
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

    'Validation and clear functions

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
        txtSalesTaxTotal.Refresh()
        txtVendorName.Refresh()
        txtInvoiceNumber.Refresh()

        cboPONumber.SelectedIndex = -1
        cboReturnNumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboVoucherNumber.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1
        cboPartnumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboCheckType.SelectedIndex = -1

        txtComment.Clear()
        txtFreightTotal.Clear()
        txtProductTotal.Clear()
        txtReturnTotal.Clear()
        txtSalesTaxTotal.Clear()
        txtVendorName.Clear()
        txtInvoiceNumber.Clear()
        txtLineCost.Clear()
        txtLineQuantity.Clear()
        txtLongDescription.Clear()
        txtLineExtendedCost.Clear()

        dtpReturnDateDD.Text = ""
        dtpReturnVoucherDateDD.Text = ""

        chkWhitePaper.Checked = False

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
        ReturnDiscountDate = dtpReturnVoucherDateDD.Value
        ReturnDueDate = dtpReturnVoucherDateDD.Value
        ValidateCheckType = ""
        WhitePaper = "NO"
        Checked1099 = "NO"

        cmdDelete.Enabled = True
        cmdSave.Enabled = True
        SaveReturnVoucherToolStripMenuItem.Enabled = True
        DeleteReturnVoucherToolStripMenuItem.Enabled = True
        dgvVoucherLines.Enabled = True
    End Sub

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboVoucherNumber.Text) Then
            MessageBox.Show("You must enter a Voucher Nunber", "Enter a Voucher Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVoucherNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboReturnNumber.Text) Then
            MessageBox.Show("You must enter a Return Number", "Enter a Return Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboReturnNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtReturnAmount.Text) Then
            MessageBox.Show("You must enter a value for Return Amount", "Enter a value", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReturnAmount.Focus()
            Return False
        End If
        If IsNumeric(txtReturnAmount.Text) = False Then
            MessageBox.Show("You must enter a number for Return Amount", "Enter a number for Return Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReturnAmount.SelectAll()
            txtReturnAmount.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub checkReturnAmount()
        If Val(txtReturnAmount.Text) = 0 And InvoiceTotal <> 0 Then
            MsgBox("You cannot round to zero.", MsgBoxStyle.OkOnly)
            Exit Sub
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
            ElseIf button = DialogResult.No Then
                cmdClearForm.Focus()
            End If
        End If
    End Sub

    Public Sub VerifyCheckType()
        If cboCheckType.Text = "" Then
            cboCheckType.Focus()
            ValidateCheckType = "INVALID"
        Else
            If cboCheckType.Text = "STANDARD" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "ACH" Then
                ValidateCheckType = "VALID"
            Else
                cboCheckType.Focus()
                ValidateCheckType = "INVALID"
            End If
        End If
    End Sub

    'Command buttons

    Private Sub cmdGenerateVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateVoucher.Click
        'Clear Data on next number
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

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
        cmd = New SqlCommand("Insert Into ReceiptOfInvoiceBatchLine(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, VendorClass, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, InvoiceAmount, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, DeleteReferenceNumber, OnHold, CheckType, TempSelected, SelectedInDatagrid, WhitePaper, ManualDiscountSelected, Checked1099) Values (@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @VendorID, @VendorClass, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @InvoiceAmount, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @DeleteReferenceNumber, @OnHold, @CheckType, @TempSelected, @SelectedInDatagrid, @WhitePaper, @ManualDiscountSelected, @Checked1099)", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = NextVoucherNumber
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
            .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpReturnVoucherDateDD.Text
            .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReturnDateDD.Text
            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = 0
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
            .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpReturnVoucherDateDD.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@DueDate", SqlDbType.VarChar).Value = dtpReturnVoucherDateDD.Text
            .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@VoucherSource", SqlDbType.VarChar).Value = "VENDOR RETURN"
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
            .Add("@TempSelected", SqlDbType.VarChar).Value = "NO"
            .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
            .Add("@WhitePaper", SqlDbType.VarChar).Value = "NO"
            .Add("@ManualDiscountSelected", SqlDbType.VarChar).Value = "NO"
            .Add("@Checked1099", SqlDbType.VarChar).Value = "NO"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        LoadVoucher()
        cboVoucherNumber.Text = NextVoucherNumber
    End Sub

    Public Sub InsertIntoROITable()
        'Get white peper details based on checkbox
        If chkWhitePaper.Checked = True Then
            WhitePaper = "YES"
        Else
            WhitePaper = "NO"
        End If
        If Checked1099 = "" Then
            Checked1099 = "NO"
        End If

        'Write values to Voucher Table
        cmd = New SqlCommand("Insert Into ReceiptOfInvoiceBatchLine(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, VendorClass, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, InvoiceAmount, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, DeleteReferenceNumber, OnHold, CheckType, TempSelected, SelectedInDatagrid, WhitePaper, ManualDiscountSelected, Checked1099) Values (@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @VendorID, @VendorClass, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @InvoiceAmount, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @DeleteReferenceNumber, @OnHold, @CheckType, @TempSelected, @SelectedInDatagrid, @WhitePaper, @ManualDiscountSelected, @Checked1099)", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
            .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpReturnVoucherDateDD.Text
            .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReturnDateDD.Text
            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = Val(txtReturnAmount.Text)
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
            .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpReturnVoucherDateDD.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@DueDate", SqlDbType.VarChar).Value = dtpReturnVoucherDateDD.Text
            .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@VoucherSource", SqlDbType.VarChar).Value = "VENDOR RETURN"
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
            .Add("@TempSelected", SqlDbType.VarChar).Value = "NO"
            .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
            .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaper
            .Add("@ManualDiscountSelected", SqlDbType.VarChar).Value = "NO"
            .Add("@Checked1099", SqlDbType.VarChar).Value = Checked1099
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub UpdateROITable()
        'Get white peper details based on checkbox
        If chkWhitePaper.Checked = True Then
            WhitePaper = "YES"
        Else
            WhitePaper = "NO"
        End If

        'Write values to Voucher Table
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET BatchNumber = @BatchNumber, PONumber = @PONumber, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, DeleteReferenceNumber = @DeleteReferenceNumber, InvoiceAmount = @InvoiceAmount, VendorClass = @VendorClass, OnHold = @OnHold, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper, ManualDiscountSelected = @ManualDiscountSelected, Checked1099 = @Checked1099 WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
            .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
            .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpReturnVoucherDateDD.Text
            .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReturnDateDD.Text
            .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = Val(txtReturnAmount.Text)
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
            .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpReturnVoucherDateDD.Text
            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
            .Add("@DueDate", SqlDbType.VarChar).Value = dtpReturnVoucherDateDD.Text
            .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@VoucherSource", SqlDbType.VarChar).Value = "VENDOR RETURN"
            .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
            .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
            .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
            .Add("@TempSelected", SqlDbType.VarChar).Value = ""
            .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = ""
            .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaper
            .Add("@ManualDiscountSelected", SqlDbType.VarChar).Value = "NO"
            .Add("@Checked1099", SqlDbType.VarChar).Value = Checked1099
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub cmdSelectByReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectByReturn.Click
        'Write to Header Table (ReceiptOfInvoiceBatchLine)
        Try
            'Write values to Voucher Table
            InsertIntoROITable()
        Catch ex As Exception
            'Write values to Voucher Table
            UpdateROITable()
        End Try

        'Open Select Lines Form and close present form
        GlobalVoucherNumber = Val(cboVoucherNumber.Text)
        GlobalVendorReturnNumber = Val(cboReturnNumber.Text)
        GlobalAPBatchNumber = Val(txtBatchNumber.Text)
        GlobalDivisionCode = txtDivisionID.Text

        Dim NewSelectVendorReturnLines As New SelectVendorReturnLines
        NewSelectVendorReturnLines.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If canSave() Then
            'Prompt before Saving
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Vendor Return?", "SAVE VENDOR RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                '*************************************************************************************************************
                VerifyUniqueInvoiceNumber()

                If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" Then
                    'Continue
                Else
                    MsgBox("You must have a unique Invoice Number.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*************************************************************************************************************
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
                Else
                    'Continue
                End If
                '****************************************************************************************************************
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
                Else
                    'Continue
                End If
                '****************************************************************************************************************
                VerifyCheckType()

                If ValidateCheckType = "VALID" Then
                    'Do nothing
                Else
                    MsgBox("You must have a valid check type..", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '****************************************************************************************************************
                'Re-calculate lines
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = Quantity * UnitCost WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Reload Totals
                ReloadVoucherTotals()
                '****************************************************************************************************************
                If CheckType = "INTERCOMPANY" Then
                    LoadIntercompanyDueDate()
                Else
                    ReturnDiscountDate = dtpReturnVoucherDateDD.Value
                    ReturnDueDate = dtpReturnVoucherDateDD.Value
                End If
                '****************************************************************************************************************
                'Verify that voucher product total is not negative
                If ProductTotal > 0 Or InvoiceTotal > 0 Then
                    MsgBox("A voucher from a return cannot be greater than zero.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '****************************************************************************************************************
                'Write to Header Table (ReceiptOfInvoiceBatchLine)
                Try
                    'Write values to Voucher Table
                    InsertIntoROITable()
                Catch ex As Exception
                    'Write values to Voucher Table
                    UpdateROITable()
                End Try
                '*****************************************************************************************************
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
                '*****************************************************************************************************
                ''checks the return amount and return total and will prompt if rounding is needed
                checkReturnAmount()

                MsgBox("This Return has been saved.", MsgBoxStyle.OkOnly)
            ElseIf button = DialogResult.No Then
                cboVoucherNumber.Focus()
            End If
        End If
    End Sub

    Private Sub cmdClearForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearForm.Click
        ClearVariables()
        ClearData()
        ShowVoucherLines()
    End Sub

    Private Sub cmdAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLine.Click
        If cboVoucherNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If
        '*******************************************************************************************
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
            MsgBox("Lines cannot be added to this voucher.", MsgBoxStyle.OkOnly)
        Else

        End If
        '************************************************************************************************
        If Val(txtLineCost.Text) < 0 Then
            MsgBox("Unit Cost must be a positive number. For a negative value, set quantity to a negative.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '****************************************************************************************************************
        VerifyCheckType()

        If ValidateCheckType = "VALID" Then
            'Do nothing
        Else
            MsgBox("You must have a valid check type..", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '****************************************************************************************************************
        Try
            Dim GetLastLine, NextLineNumber As Integer
            Dim GetDebitAccount As String

            'Get Item Class
            Dim GetDebitAccountStatement As String = "SELECT GLDebitAccount FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim GetDebitAccountCommand As New SqlCommand(GetDebitAccountStatement, con)
            GetDebitAccountCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartnumber.Text
            GetDebitAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetDebitAccount = CStr(GetDebitAccountCommand.ExecuteScalar)
            Catch ex As Exception
                GetDebitAccount = "20999"
            End Try
            con.Close()

            'Get last line number
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
                .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartnumber.Text
                .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtLineQuantity.Text)
                .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtLineCost.Text)
                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedCost
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

            'Refresh datagrid
            ShowVoucherLines()
            tabLineControl.SelectedIndex = 0

            'Load totals
            ReloadVoucherTotals()
        Catch ex As Exception
            MsgBox("Line entry failed - check data and try again.", MsgBoxStyle.OkOnly)
        End Try
    End Sub

    Private Sub cmdClearLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLines.Click
        cboPartDescription.SelectedIndex = -1
        cboPartnumber.SelectedIndex = -1
        txtLineCost.Clear()
        txtLongDescription.Clear()
        txtLineExtendedCost.Clear()
        txtLineQuantity.Clear()
        cboPartnumber.Focus()
    End Sub

    Private Sub cmdEnterNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnterNew.Click
        If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Then
            cmdGenerateVoucher_Click(sender, e)
        Else
            '****************************************************************************************************
            VerifyUniqueInvoiceNumber()

            If UniqueInvoice = "YES" Then
                'Continue
            Else
                MsgBox("This Invoice Number has already been used.", MsgBoxStyle.OkOnly)
                txtInvoiceNumber.Focus()
                Exit Sub
            End If
            '****************************************************************************************************
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
                MsgBox("Current voucher cannot be saved.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '****************************************************************************************************************
            VerifyCheckType()

            If ValidateCheckType = "VALID" Then
                'Do nothing
            Else
                MsgBox("You must have a valid check type..", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '****************************************************************************************************************
            'Re-calculate lines
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = Quantity * UnitCost WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Reload Totals
            ReloadVoucherTotals()
            '******************************************************************************************************************
            If CheckType = "INTERCOMPANY2" Then
                LoadIntercompanyDueDate()
            Else
                ReturnDiscountDate = dtpReturnVoucherDateDD.Value
                ReturnDueDate = dtpReturnVoucherDateDD.Value
            End If
            '******************************************************************************************************************
            'Verify that voucher product total is not negative
            If ProductTotal > 0 Or InvoiceTotal > 0 Then
                MsgBox("A voucher from a return cannot be greater than zero.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            ''checks the return amount and return total and will prompt if rounding is needed
            checkReturnAmount()
            '******************************************************************************************************************
            Try
                'Write values to Voucher Table
                InsertIntoROITable()
            Catch ex As Exception
                'Write values to Voucher Table
                UpdateROITable()
            End Try
            '******************************************************************************************************************
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
            InvoiceTotal = ProductTotal + Val(txtSalesTaxTotal.Text) + Val(txtFreightTotal.Text)

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
            txtSalesTaxTotal.Text = InvoiceSalesTax
            '******************************************************************************************************************
            'Clear text fields for next entry
            ClearVariables()
            ClearData()
            ClearDataInDatagrid()

            'Write to database
            cmd = New SqlCommand("DECLARE @Key as int = (SELECT isnull(MAX(VoucherNumber)+1, 33000001) FROM ReceiptOfInvoiceBatchLine); Insert Into ReceiptOfInvoiceBatchLine(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, DeleteReferenceNumber, InvoiceAmount, VendorClass, OnHold, CheckType) Values (@Key, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @VendorID, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @DeleteReferenceNumber, @InvoiceAmount, @VendorClass, @OnHold, @CheckType); SELECT @Key;", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                .Add("@PONumber", SqlDbType.VarChar).Value = Val(cboPONumber.Text)
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpReturnVoucherDateDD.Text
                .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReturnDateDD.Text
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                .Add("@InvoiceFreight", SqlDbType.VarChar).Value = 0
                .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = 0
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
                .Add("@PaymentTerms", SqlDbType.VarChar).Value = "N30"
                .Add("@DiscountDate", SqlDbType.VarChar).Value = ReturnDiscountDate
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@DueDate", SqlDbType.VarChar).Value = ReturnDueDate
                .Add("@DiscountAmount", SqlDbType.VarChar).Value = 0
                .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@VoucherSource", SqlDbType.VarChar).Value = "VENDOR RETURN"
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
                .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
                .Add("@InvoiceAmount", SqlDbType.VarChar).Value = 0
                .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                .Add("@TempSelected", SqlDbType.VarChar).Value = ""
                .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = ""
                .Add("@WhitePaper", SqlDbType.VarChar).Value = ""
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            Dim key As Integer = cmd.ExecuteScalar()
            con.Close()

            LoadVendor()
            LoadVoucher()
            ShowVoucherLines()
            cboVoucherNumber.Text = key.ToString()
            cboVoucherNumber.Focus()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If canSave() Then
            '*******************************************************************************************
            VerifyUniqueInvoiceNumber()

            If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" Then
            Else
                MsgBox("You must have a unique Invoice Number.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*******************************************************************************************
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
            Else
                'Continue
            End If
            '*********************************************************************************************************
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
                MsgBox("This voucher is not open.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '****************************************************************************************************************
            VerifyCheckType()

            If ValidateCheckType = "VALID" Then
                'Do nothing
            Else
                MsgBox("You must have a valid check type..", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '****************************************************************************************************************
            If CheckType = "INTERCOMPANY2" Then
                LoadIntercompanyDueDate()
            Else
                ReturnDiscountDate = dtpReturnVoucherDateDD.Value
                ReturnDueDate = dtpReturnVoucherDateDD.Value
            End If
            '****************************************************************************************************************
            'Re-calculate lines
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = Quantity * UnitCost WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Reload Totals
            ReloadVoucherTotals()

            'Verify that voucher product total is not negative
            If ProductTotal > 0 Or InvoiceTotal > 0 Then
                MsgBox("A voucher from a return cannot be greater than zero.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*****************************************************************************************************************
            Try
                'Write values to Voucher Table
                InsertIntoROITable()
            Catch ex As Exception
                'Write values to Voucher Table
                UpdateROITable()
            End Try
            '*************************************************************************************************************
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
            '*************************************************************************************************************
            ''checks the return amount and return total and will prompt if rounding is needed
            checkReturnAmount()

            'Open Vendor Return Print Form
            GlobalVendorReturnNumber = Val(cboReturnNumber.Text)
            GlobalDivisionCode = txtDivisionID.Text
            Dim NewPrintVendorReturn As New PrintVendorReturn
            NewPrintVendorReturn.Show()
        End If
    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        If cboVoucherNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number selected.", MsgBoxStyle.OkOnly)
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
                MsgBox("Lines cannot be deleted from this voucher.", MsgBoxStyle.OkOnly)
            Else
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

                'Reload datagrid
                ShowVoucherLines()
                tabLineControl.SelectedIndex = 0

                ReloadVoucherTotals()

                MsgBox("This line has been deleted.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdSelectOpenPayables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectOpenPayables.Click
        GlobalVendorID = cboVendorID.Text
        GlobalDivisionCode = txtDivisionID.Text

        Dim NewSelectOpenPayables As New SelectOpenPayables
        NewSelectOpenPayables.Show()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If cboVoucherNumber.Text = "" Or Val(cboVoucherNumber.Text) = 0 Then
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
            Exit Sub
        Else
            'Continue
        End If
        '****************************************************************************************************************************
        'Prompt before Saving
        Dim button As DialogResult = MessageBox.Show("Do you wish to save this Vendor Return before exiting? (If NO, Voucher will be deleted)", "SAVE VENDOR RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            '*********************************************************************************************************
            VerifyUniqueInvoiceNumber()

            If UniqueInvoice = "YES" And txtInvoiceNumber.Text <> "" Then
            Else
                MsgBox("You must have a unique Invoice Number.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*********************************************************************************************************
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
                Exit Sub
            Else
                'Continue
            End If
            '****************************************************************************************************************
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
            Else
                'Continue
            End If
            '****************************************************************************************************************
            VerifyCheckType()

            If ValidateCheckType = "VALID" Then
                'Do nothing
            Else
                MsgBox("You must have a valid check type..", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '****************************************************************************************************************
            If CheckType = "INTERCOMPANY2" Then
                LoadIntercompanyDueDate()
            Else
                ReturnDiscountDate = dtpReturnVoucherDateDD.Value
                ReturnDueDate = dtpReturnVoucherDateDD.Value
            End If
            '****************************************************************************************************************
            'Re-calculate lines
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET ExtendedAmount = Quantity * UnitCost WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Reload Totals
            ReloadVoucherTotals()

            'Verify that voucher product total is not negative
            If ProductTotal > 0 Or InvoiceTotal > 0 Then
                MsgBox("A voucher from a return cannot be greater than zero.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '***************************************************************************************************************
            Try
                'Write values to Voucher Table
                InsertIntoROITable()
            Catch ex As Exception
                'Write values to Voucher Table
                UpdateROITable()
            End Try
            '***************************************************************************************************
            'Write values to Batch Line Table
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET InvoiceTotal = ProductTotal + InvoiceFreight + InvoiceSalesTax WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '***************************************************************************************************
            ''checks the return amount and return total and will prompt if rounding is needed
            If String.IsNullOrEmpty(txtReturnAmount.Text) = False Then
                If IsNumeric(txtReturnAmount.Text) Then
                    checkReturnAmount()
                Else
                    MessageBox.Show("You must enter a number for Return Amount", "Enter a number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtReturnAmount.SelectAll()
                    txtReturnAmount.Focus()
                    Exit Sub
                End If
            End If
            '***************************************************************************************************
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
                        cmd = New SqlCommand("UPDATE VendorReturnLine SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber", con)

                        With cmd.Parameters
                            .Add("@ReturnNumber", SqlDbType.VarChar).Value = GetReturnNumber
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Re-open Return to be vouched again
                        cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber", con)

                        With cmd.Parameters
                            .Add("@ReturnNumber", SqlDbType.VarChar).Value = GetReturnNumber
                            .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        'Re-open Vendor Return Lines
                        cmd = New SqlCommand("UPDATE VendorReturnLine SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)

                        With cmd.Parameters
                            .Add("@ReturnNumber", SqlDbType.VarChar).Value = LineReturnNumber
                            .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = LineReturnLine
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Re-open Return to be vouched again
                        cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber", con)

                        With cmd.Parameters
                            .Add("@ReturnNumber", SqlDbType.VarChar).Value = LineReturnNumber
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
                            cmd = New SqlCommand("UPDATE VendorReturnLine SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber", con)

                            With cmd.Parameters
                                .Add("@ReturnNumber", SqlDbType.VarChar).Value = GetReturnNumber
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Re-open Return to be vouched again
                            cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber", con)

                            With cmd.Parameters
                                .Add("@ReturnNumber", SqlDbType.VarChar).Value = GetReturnNumber
                                .Add("@ReturnStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Else
                            'Re-open Vendor Return Lines
                            cmd = New SqlCommand("UPDATE VendorReturnLine SET LineStatus = @LineStatus WHERE ReturnNumber = @ReturnNumber AND ReturnLineNumber = @ReturnLineNumber", con)

                            With cmd.Parameters
                                .Add("@ReturnNumber", SqlDbType.VarChar).Value = LineReturnNumber
                                .Add("@ReturnLineNumber", SqlDbType.VarChar).Value = LineReturnLine
                                .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            'Re-open Return to be vouched again
                            cmd = New SqlCommand("UPDATE VendorReturn SET ReturnStatus = @ReturnStatus WHERE ReturnNumber = @ReturnNumber", con)

                            With cmd.Parameters
                                .Add("@ReturnNumber", SqlDbType.VarChar).Value = LineReturnNumber
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

    'Menu strip functions

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        ClearVariables()
        ClearData()
        ShowVoucherLines()
    End Sub

    Private Sub PrintReturnVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintReturnVoucherToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub DeleteReturnVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteReturnVoucherToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub SaveReturnVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveReturnVoucherToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    'Combo box functions

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorData()
        LoadPONumber()
        LoadReturnNumber()
    End Sub

    Private Sub cboPartnumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartnumber.SelectedIndexChanged
        LoadLongDescription()
    End Sub

    Private Sub cboDeleteLine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDeleteLine.SelectedIndexChanged
        LoadDeletePartData()
    End Sub

    Private Sub cboVoucherNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVoucherNumber.SelectedIndexChanged
        LoadReturnVoucherData()
        ShowVoucherLines()
    End Sub

    Private Sub cboReturnNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReturnNumber.SelectedIndexChanged
        'Get PO Number
        'Dim PONumberStatement As String = "SELECT PONumber FROM VendorReturn WHERE ReturnNumber = @ReturnNumber AND DivisionID = @DivisionID"
        'Dim PONumberCommand As New SqlCommand(PONumberStatement, con)
        'PONumberCommand.Parameters.Add("@ReturnNumber", SqlDbType.VarChar).Value = Val(cboReturnNumber.Text)
        'PONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = txtDivisionID.Text

        'If con.State = ConnectionState.Closed Then con.Open()
        'Try
        'PONumber = CInt(PONumberCommand.ExecuteScalar)
        'Catch ex As Exception
        'PONumber = 0
        'End Try
        'con.Close()

        'cboPONumber.Text = PONumber

        LoadReturnDate()
    End Sub

    'Text box functions

    Private Sub txtFreightTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreightTotal.TextChanged
        InvoiceFreight = Val(txtFreightTotal.Text)
        InvoiceTotal = InvoiceFreight + InvoiceSalesTax + ProductTotal
        txtReturnTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Private Sub txtSalesTaxTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesTaxTotal.TextChanged
        InvoiceFreight = Val(txtFreightTotal.Text)
        InvoiceTotal = InvoiceFreight + InvoiceSalesTax + ProductTotal
        txtReturnTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Private Sub txtLineQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineQuantity.TextChanged
        LineQuantity = Val(txtLineQuantity.Text)
        LineCost = Val(txtLineCost.Text)
        LineExtendedCost = LineQuantity * LineCost
        txtLineExtendedCost.Text = FormatCurrency(LineExtendedCost, 2)
    End Sub

    Private Sub txtLineCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineCost.TextChanged
        LineQuantity = Val(txtLineQuantity.Text)
        LineCost = Val(txtLineCost.Text)
        LineExtendedCost = LineQuantity * LineCost
        txtLineExtendedCost.Text = FormatCurrency(LineExtendedCost, 2)
    End Sub

    'Miscellaneous functions (Date time picker, check boxes, etc.)

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

    Private Sub APProcessReturns_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    Private Sub dtpReturnVoucherDateDD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReturnVoucherDateDD.ValueChanged
        dtpReturnVoucherDate.Text = dtpReturnVoucherDateDD.Value.Date.ToShortDateString()
        LoadIntercompanyDueDate()
    End Sub

    Private Sub dtpReturnVoucherDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpReturnVoucherDate.KeyDown
        If e.KeyCode = Keys.Tab Then
            usefulFunctions.keyDownCheckCase(dtpReturnVoucherDate, cboVendorID)
        End If
    End Sub

    Private Sub dtpReturnVoucherDate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReturnVoucherDate.Leave
        dtpReturnVoucherDate.Text = usefulFunctions.formatDate(dtpReturnVoucherDate.Text)
        dtpReturnVoucherDateDD.Text = dtpReturnVoucherDate.Text
    End Sub

    Private Sub dtpReturnVoucherDate_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dtpReturnVoucherDate.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.Tab
                e.IsInputKey = True
        End Select
    End Sub

    Private Sub dtpReturnVoucherDate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReturnVoucherDate.Enter
        dtpReturnVoucherDate.Text = usefulFunctions.formatDate(dtpReturnVoucherDate.Text)
        dtpReturnVoucherDate.Select(0, 2)
    End Sub

    Private Sub dtpReturnVoucherDate_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtpReturnVoucherDate.MouseClick
        selectDTPLocation(dtpReturnVoucherDate)
    End Sub

    Private Sub dtpReturnVoucherDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReturnVoucherDate.TextChanged
        autoMoveInDateString(dtpReturnVoucherDate)
    End Sub

    Private Sub dtpReturnDateDD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReturnDateDD.ValueChanged
        dtpReturnDate.Text = dtpReturnDateDD.Value.Date.ToShortDateString()
    End Sub

    Private Sub dtpReturnDate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpReturnDate.KeyDown
        If e.KeyCode = Keys.Tab Then
            usefulFunctions.keyDownCheckCase(dtpReturnDate, cboReturnNumber)
        End If
    End Sub

    Private Sub dtpReturnDate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReturnDate.Leave
        dtpReturnDate.Text = usefulFunctions.formatDate(dtpReturnDate.Text)
        dtpReturnDateDD.Text = dtpReturnDate.Text
    End Sub

    Private Sub dtpReturnDate_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles dtpReturnDate.PreviewKeyDown
        Select Case e.KeyCode
            Case Keys.Tab
                e.IsInputKey = True
        End Select
    End Sub

    Private Sub dtpReturnDate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReturnDate.Enter
        dtpReturnDate.Text = usefulFunctions.formatDate(dtpReturnDate.Text)
        dtpReturnDate.Select(0, 2)
    End Sub

    Private Sub dtpReturnDate_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtpReturnDate.MouseClick
        selectDTPLocation(dtpReturnDate)
    End Sub

    Private Sub dtpReturnDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpReturnDate.TextChanged
        autoMoveInDateString(dtpReturnDate)
    End Sub

    Private Sub txtInvoiceNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInvoiceNumber.LostFocus
        If txtInvoiceNumber.Text.EndsWith(" ") Then
            txtInvoiceNumber.Text = txtInvoiceNumber.Text.TrimEnd(" ")
        End If
    End Sub

    Private Sub txtInvoiceNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoiceNumber.TextChanged
        'If txtInvoiceNumber.Text.EndsWith(" ") Then
        '    txtInvoiceNumber.Text = txtInvoiceNumber.Text.Replace(" ", "")
        'End If
    End Sub

    Private Sub cboCheckType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCheckType.SelectedIndexChanged
        If cboCheckType.Text = "STANDARD" Then
            chkWhitePaper.Enabled = True
        Else
            chkWhitePaper.Checked = False
            chkWhitePaper.Enabled = False
        End If
    End Sub
End Class