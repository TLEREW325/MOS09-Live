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
Public Class APViewVoucherLines
    Inherits System.Windows.Forms.Form

    Dim LastGLNumber, NextGLNumber, BatchNumber, PONumber, DueDays, DiscountDays As Integer
    Dim WhitePaperCheck, GLTaxAccount, GLPayableAccount, GLFreightAccount, VendorClass, GLDate, VoucherSource, VendorName, VoucherStatus, InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, PaymentTerms, DiscountDate, Comment, UniqueInvoice As String
    Dim SUMExtendedAmount, InvoiceAmount, DiscountPercent, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, DiscountAmount As Double
    Dim InvoiceDate1, DueDate, DiscountDate1 As Date
    Dim TodaysDate As Date = Now()
    Dim CheckDiscountDate As Date = Now()
    Dim CheckType As String = ""
    Dim CheckCode As String = ""
    Dim CheckAndValidateDates As String = ""

    Dim IsLoaded As Boolean

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
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub APViewVoucherLines_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PaymentTerms' table. You can move, or remove it, as needed.
        Me.PaymentTermsTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PaymentTerms)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = GlobalDivisionCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = GlobalDivisionCode
        End If

        TodaysDate = Today.ToShortDateString()

        If GlobalVoucherNumber2 > 0 Then
            cboVoucherNumber.Text = GlobalVoucherNumber2
            ShowAllData()
        Else
            cboVoucherNumber.SelectedIndex = -1
            cboPaymentTerms.SelectedIndex = -1
            cmdReverse.Enabled = False
            cmdPost.Enabled = False
            cmdDelete.Enabled = False
        End If
    End Sub

    Public Sub ShowAllData()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber", con)
        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceiptOfInvoiceVoucherLines")
        dgvVoucherLines.DataSource = ds.Tables("ReceiptOfInvoiceVoucherLines")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvVoucherLines.DataSource = Nothing
    End Sub

    Public Sub LoadVoucherNumber()
        cmd = New SqlCommand("SELECT VoucherNumber FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VoucherStatus <> 'RECURRING' ORDER BY VoucherNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ReceiptOfInvoiceBatchLine")
        cboVoucherNumber.DataSource = ds1.Tables("ReceiptOfInvoiceBatchLine")
        con.Close()
        cboVoucherNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadVendor()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "Vendor")
        cboVendorID.DataSource = ds2.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorClass()
        cmd = New SqlCommand("SELECT VendClassID FROM VendorClass", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "VendorClass")
        cboVendorClass.DataSource = ds3.Tables("VendorClass")
        con.Close()
        cboVendorClass.SelectedIndex = -1
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

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

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvVoucherLines.CellValueChanged
        Dim LineQuantity, LineExtendedAmount, LineUnitCost As Double
        Dim LineNumber As Integer
        Dim GLWarning, CheckDebitAccount, CheckCreditAccount, LinePartDescription, LineDebitAccount, LineCreditAccount As String

        GLWarning = ""

        If VoucherStatus = "OPEN" Then
            'UPDATE Line Table on changes in the datagrid and ensure no NULL values
            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Try
                    LineUnitCost = row.Cells("UnitCostColumn").Value
                Catch ex As Exception
                    LineUnitCost = 0
                End Try
                Try
                    LineQuantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    LineQuantity = 0
                End Try
                Try
                    LineNumber = row.Cells("VoucherLineColumn").Value
                Catch ex As Exception
                    LineNumber = 0
                End Try
                Try
                    LineDebitAccount = row.Cells("GLDebitAccountColumn").Value
                Catch ex As Exception
                    LineDebitAccount = ""
                End Try
                Try
                    LineCreditAccount = row.Cells("GLCreditAccountColumn").Value
                Catch ex As Exception
                    LineCreditAccount = "20000"
                End Try
                Try
                    LinePartDescription = row.Cells("PartDescriptionColumn").Value
                Catch ex As Exception
                    LinePartDescription = ""
                End Try

                LineExtendedAmount = LineUnitCost * LineQuantity
                LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

                'Verify GL Accounts
                Dim CheckDebitAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
                Dim CheckDebitAccountCommand As New SqlCommand(CheckDebitAccountStatement, con)
                CheckDebitAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineDebitAccount

                Dim CheckCreditAccountStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
                Dim CheckCreditAccountCommand As New SqlCommand(CheckCreditAccountStatement, con)
                CheckCreditAccountCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineCreditAccount

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckDebitAccount = CStr(CheckDebitAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckDebitAccount = "NO"
                End Try
                Try
                    CheckCreditAccount = CStr(CheckCreditAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckCreditAccount = "NO"
                End Try
                con.Close()

                'If there is an invalid GL Account, exit the loop - no updates
                If CheckCreditAccount = "NO" Or CheckDebitAccount = "NO" Then
                    GLWarning = "NOT VALID"
                    Exit For
                Else
                    GLWarning = "VALID"
                End If

                'Update Voucher Line Table with changes
                Try
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceVoucherLines SET PartDescription = @PartDescription, UnitCost = @UnitCost, Quantity = @Quantity, ExtendedAmount = @ExtendedAmount, GLDebitAccount = @GLDebitAccount, GLCreditAccount = @GLCreditAccount WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@VoucherLine", SqlDbType.VarChar).Value = LineNumber
                        .Add("@PartDescription", SqlDbType.VarChar).Value = LinePartDescription
                        .Add("@UnitCost", SqlDbType.VarChar).Value = LineUnitCost
                        .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@GLDebitAccount", SqlDbType.VarChar).Value = LineDebitAccount
                        .Add("@GLCreditAccount", SqlDbType.VarChar).Value = LineCreditAccount
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Do nothing
                End Try
            Next

            'Reload totals and update header table
            ReloadTotals()
            'CalculateDiscount()

            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                .Add("@InvoiceAmount", SqlDbType.VarChar).Value = InvoiceTotal
                .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            If GLWarning = "NOT VALID" Then
                MsgBox("One or more lines could not be updated because there is an invalid GL Account", MsgBoxStyle.OkOnly)
            End If

            ShowAllData()
        Else
            'Do nothing - no changes will be saved
        End If
    End Sub

    Public Sub LoadPaymentTermDetails()
        Dim DiscountPercentStatement As String = "SELECT DiscountPercent FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DiscountPercentCommand As New SqlCommand(DiscountPercentStatement, con)
        DiscountPercentCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

        Dim DiscountDaysStatement As String = "SELECT DiscountDays FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DiscountDaysCommand As New SqlCommand(DiscountDaysStatement, con)
        DiscountDaysCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

        Dim DueDaysStatement As String = "SELECT DueDays FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DueDaysCommand As New SqlCommand(DueDaysStatement, con)
        DueDaysCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = cboPaymentTerms.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DueDays = CInt(DueDaysCommand.ExecuteScalar)
        Catch ex As Exception
            DueDays = 0
        End Try
        Try
            DiscountDays = CInt(DiscountDaysCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountDays = 0
        End Try
        Try
            DiscountPercent = CDbl(DiscountPercentCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountPercent = 0
        End Try
        con.Close()

        'Commands to determine Discount and Due Dates
        InvoiceDate1 = dtpInvoiceDate.Value
        DueDate = InvoiceDate1.AddDays(DueDays)
        dtpDueDate.Text = DueDate

        If DiscountPercent = 0 Then
            dtpDiscountDate.Text = DueDate
        Else
            DiscountDate1 = InvoiceDate1.AddDays(DiscountDays)
            dtpDiscountDate.Text = DiscountDate1
        End If
    End Sub

    Public Sub CalculateDiscount()
        DiscountAmount = DiscountPercent * ProductTotal
        txtDiscountAmount.Text = DiscountAmount
    End Sub

    Public Sub LoadVendorName()
        Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim VendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
        VendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CheckCodeStatement As String = "SELECT CheckCode FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim CheckCodeCommand As New SqlCommand(CheckCodeStatement, con)
        CheckCodeCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        CheckCodeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim WhitePaperCheckStatement As String = "SELECT WhitePaperCheck FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim WhitePaperCheckCommand As New SqlCommand(WhitePaperCheckStatement, con)
        WhitePaperCheckCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        WhitePaperCheckCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorName = ""
        End Try
        Try
            VendorClass = CStr(VendorClassCommand.ExecuteScalar)
        Catch ex As Exception
            VendorClass = ""
        End Try
        Try
            CheckCode = CStr(CheckCodeCommand.ExecuteScalar)
        Catch ex As Exception
            CheckCode = "STANDARD"
        End Try
        Try
            WhitePaperCheck = CStr(WhitePaperCheckCommand.ExecuteScalar)
        Catch ex As Exception
            WhitePaperCheck = "NO"
        End Try
        con.Close()

        txtVendorName.Text = VendorName
        cboVendorClass.Text = VendorClass
        cboCheckType.Text = CheckCode

        If WhitePaperCheck = "YES" Then
            chkWhitePaper.Checked = True
        Else
            chkWhitePaper.Checked = False
        End If
    End Sub

    Public Sub LoadPostingDateForReversal()
        Dim GetGLDateStatement As String = "SELECT MAX(GLTransactionDate) FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID"
        Dim GetGLDateCommand As New SqlCommand(GetGLDateStatement, con)
        GetGLDateCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        GetGLDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GLDate = CStr(GetGLDateCommand.ExecuteScalar)
        Catch ex As Exception
            GLDate = dtpInvoiceDate.Text
        End Try
        con.Close()
    End Sub

    Public Sub LoadIntercompanyDueDate()
        Dim DissectInvoiceDate As Date
        Dim intDay, intMonth, intYear As Integer
        Dim intNewDay, intNewMonth, intNewYear As Integer
        Dim strNewDay, strNewMonth, strNewYear As String
        Dim strInterCompanyDueDate As String = ""
        DissectInvoiceDate = dtpInvoiceDate.Value

        intDay = DissectInvoiceDate.Day
        intMonth = DissectInvoiceDate.Month
        intYear = DissectInvoiceDate.Year

        If intDay <= 15 Then
            intNewDay = 1
            If intMonth < 12 Then
                intNewMonth = intMonth + 1
            Else
                intNewMonth = 1
            End If
        Else
            intNewDay = 15
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

        dtpDiscountDate.Text = strInterCompanyDueDate
        dtpDueDate.Text = strInterCompanyDueDate
    End Sub

    Public Sub LoadFEDEXDueDate()
        Dim DissectInvoiceDate As Date
        Dim intDay, intMonth, intYear As Integer
        Dim intNewDay, intNewMonth, intNewYear As Integer
        Dim strNewDay, strNewMonth, strNewYear As String
        Dim strFedexDueDate As String = ""
        DissectInvoiceDate = dtpInvoiceDate.Value

        intDay = DissectInvoiceDate.Day
        intMonth = DissectInvoiceDate.Month
        intYear = DissectInvoiceDate.Year

        If intDay <= 10 Then
            intNewDay = 15
            intNewMonth = intMonth
        ElseIf intDay > 10 And intDay <= 20 Then
            intNewDay = 25
            intNewMonth = intMonth
        ElseIf intDay > 20 And intDay <= 31 Then
            intNewDay = 5
            If intMonth < 12 Then
                intNewMonth = intMonth + 1
            Else
                intNewMonth = 1
            End If
        Else
            'Do nothing
        End If

        If intMonth = 12 And intNewDay = 5 Then
            intNewYear = intYear + 1
        Else
            intNewYear = intYear
        End If

        strNewDay = CStr(intNewDay)
        strNewMonth = CStr(intNewMonth)
        strNewYear = CStr(intNewYear)

        strFedexDueDate = strNewMonth + "/" + strNewDay + "/" + strNewYear

        dtpDiscountDate.Text = strFedexDueDate
        dtpDueDate.Text = strFedexDueDate
    End Sub

    Public Sub ValidateDates()
        'Check to see if Invoice Date, Due Date, or Discount Date is more than 60 days different from today
        Dim CheckInvoiceDate, CheckDueDate, CheckDiscountDate As Date
        Dim DateDifference1 As Integer = 0
        Dim DateDifference2 As Integer = 0
        Dim DateDifference3 As Integer = 0

        TodaysDate = Today()
        CheckInvoiceDate = dtpInvoiceDate.Value
        CheckDueDate = dtpDueDate.Value
        CheckDiscountDate = dtpDiscountDate.Value

        'Invoice Date
        If CheckInvoiceDate > TodaysDate Then
            DateDifference1 = DateDiff(DateInterval.Day, TodaysDate, CheckInvoiceDate)
        Else
            DateDifference1 = DateDiff(DateInterval.Day, CheckInvoiceDate, TodaysDate)
        End If

        'Due Date
        If CheckDueDate > TodaysDate Then
            DateDifference2 = DateDiff(DateInterval.Day, TodaysDate, CheckDueDate)
        Else
            DateDifference2 = DateDiff(DateInterval.Day, CheckDueDate, TodaysDate)
        End If

        'Discount Date
        If CheckDiscountDate > TodaysDate Then
            DateDifference3 = DateDiff(DateInterval.Day, TodaysDate, CheckDiscountDate)
        Else
            DateDifference3 = DateDiff(DateInterval.Day, CheckDiscountDate, TodaysDate)
        End If

        If DateDifference1 < 90 And DateDifference2 < 90 And DateDifference3 < 90 Then
            CheckAndValidateDates = "OKAY"
        Else
            CheckAndValidateDates = "NOT OKAY"
        End If
    End Sub

    Public Sub ClearData()
        cboVoucherNumber.Refresh()
        cboVendorID.Refresh()
        cboPaymentTerms.Refresh()
        cboVendorClass.Refresh()
        cboCheckType.Refresh()

        cboVoucherNumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboPaymentTerms.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1
        cboCheckType.SelectedIndex = -1

        txtComment.Clear()
        txtInvoiceNumber.Clear()
        txtBatchNumber.Clear()
        txtDiscountAmount.Clear()
        txtFreight.Clear()
        txtSalesTax.Clear()
        txtPONumber.Clear()
        txtInvoiceTotal.Clear()
        txtProductTotal.Clear()
        txtVendorName.Clear()

        lblVoucherSource.Text = ""
        lblVoucherStatus.Text = ""

        dtpDiscountDate.Text = ""
        dtpDueDate.Text = ""
        dtpInvoiceDate.Text = ""
        dtpReceiptDate.Text = ""

        chkChangePostDate.Checked = False
        chkWhitePaper.Checked = False
        chkWhitePaper.Enabled = True

        cboVoucherNumber.Text = ""
    End Sub

    Public Sub ClearVariables()
        LastGLNumber = 0
        NextGLNumber = 0
        BatchNumber = 0
        PONumber = 0
        DueDays = 0
        DiscountDays = 0
        GLDate = ""
        VoucherSource = ""
        VendorName = ""
        VoucherStatus = ""
        InvoiceNumber = ""
        InvoiceDate = ""
        ReceiptDate = ""
        VendorID = ""
        PaymentTerms = ""
        DiscountDate = ""
        Comment = ""
        UniqueInvoice = ""
        SUMExtendedAmount = 0
        InvoiceAmount = 0
        DiscountPercent = 0
        ProductTotal = 0
        InvoiceFreight = 0
        InvoiceSalesTax = 0
        InvoiceTotal = 0
        DiscountAmount = 0
        GlobalVoucherNumber = 0
        VendorClass = ""
        CheckType = ""
        CheckCode = "STANDARD"
        WhitePaperCheck = "NO"
    End Sub

    Private Sub LoadVoucherData()
        Dim BatchNumberStatement As String = "SELECT BatchNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim BatchNumberCommand As New SqlCommand(BatchNumberStatement, con)
        BatchNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        BatchNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PONumberStatement As String = "SELECT PONumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim PONumberCommand As New SqlCommand(PONumberStatement, con)
        PONumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        PONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceNumberStatement As String = "SELECT InvoiceNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceNumberCommand As New SqlCommand(InvoiceNumberStatement, con)
        InvoiceNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceDateStatement As String = "SELECT InvoiceDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceDateCommand As New SqlCommand(InvoiceDateStatement, con)
        InvoiceDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ReceiptDateStatement As String = "SELECT ReceiptDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim ReceiptDateCommand As New SqlCommand(ReceiptDateStatement, con)
        ReceiptDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        ReceiptDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim VendorIDStatement As String = "SELECT VendorID FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim VendorIDCommand As New SqlCommand(VendorIDStatement, con)
        VendorIDCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        VendorIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ProductTotalStatement As String = "SELECT ProductTotal FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim ProductTotalCommand As New SqlCommand(ProductTotalStatement, con)
        ProductTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        ProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceFreightStatement As String = "SELECT InvoiceFreight FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceFreightCommand As New SqlCommand(InvoiceFreightStatement, con)
        InvoiceFreightCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceFreightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceSalesTaxStatement As String = "SELECT InvoiceSalesTax FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceSalesTaxCommand As New SqlCommand(InvoiceSalesTaxStatement, con)
        InvoiceSalesTaxCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceSalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceTotalStatement As String = "SELECT InvoiceTotal FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceTotalCommand As New SqlCommand(InvoiceTotalStatement, con)
        InvoiceTotalCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PaymentTermsStatement As String = "SELECT PaymentTerms FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim PaymentTermsCommand As New SqlCommand(PaymentTermsStatement, con)
        PaymentTermsCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        PaymentTermsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim DiscountDateStatement As String = "SELECT DiscountDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim DiscountDateCommand As New SqlCommand(DiscountDateStatement, con)
        DiscountDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        DiscountDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CommentStatement As String = "SELECT Comment FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim CommentCommand As New SqlCommand(CommentStatement, con)
        CommentCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        CommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim DueDateStatement As String = "SELECT DueDate FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim DueDateCommand As New SqlCommand(DueDateStatement, con)
        DueDateCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        DueDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim DiscountAmountStatement As String = "SELECT DiscountAmount FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim DiscountAmountCommand As New SqlCommand(DiscountAmountStatement, con)
        DiscountAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        DiscountAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceAmountStatement As String = "SELECT InvoiceAmount FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim InvoiceAmountCommand As New SqlCommand(InvoiceAmountStatement, con)
        InvoiceAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        InvoiceAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim VoucherSourceStatement As String = "SELECT VoucherSource FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim VoucherSourceCommand As New SqlCommand(VoucherSourceStatement, con)
        VoucherSourceCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        VoucherSourceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim VendorClassStatement As String = "SELECT VendorClass FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim VendorClassCommand As New SqlCommand(VendorClassStatement, con)
        VendorClassCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        VendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CheckTypeStatement As String = "SELECT CheckType FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim CheckTypeCommand As New SqlCommand(CheckTypeStatement, con)
        CheckTypeCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        CheckTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim WhitePaperCheckStatement As String = "SELECT WhitePaper FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
        Dim WhitePaperCheckCommand As New SqlCommand(WhitePaperCheckStatement, con)
        WhitePaperCheckCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        WhitePaperCheckCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchNumber = CInt(BatchNumberCommand.ExecuteScalar)
        Catch ex As Exception
            BatchNumber = 0
        End Try
        Try
            PONumber = CInt(PONumberCommand.ExecuteScalar)
        Catch ex As Exception
            PONumber = 0
        End Try
        Try
            InvoiceNumber = CStr(InvoiceNumberCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceNumber = 0
        End Try
        Try
            InvoiceDate = CStr(InvoiceDateCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceDate = ""
        End Try
        Try
            ReceiptDate = CStr(ReceiptDateCommand.ExecuteScalar)
        Catch ex As Exception
            ReceiptDate = ""
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
            PaymentTerms = CStr(PaymentTermsCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentTerms = ""
        End Try
        Try
            DiscountDate = CStr(DiscountDateCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountDate = ""
        End Try
        Try
            Comment = CStr(CommentCommand.ExecuteScalar)
        Catch ex As Exception
            Comment = ""
        End Try
        Try
            DueDate = CDate(DueDateCommand.ExecuteScalar)
        Catch ex As Exception
            DueDate = ""
        End Try
        Try
            DiscountAmount = CDbl(DiscountAmountCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountAmount = 0
        End Try
        Try
            InvoiceAmount = CDbl(InvoiceAmountCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceAmount = 0
        End Try
        Try
            VoucherSource = CStr(VoucherSourceCommand.ExecuteScalar)
        Catch ex As Exception
            VoucherSource = ""
        End Try
        Try
            VendorClass = CStr(VendorClassCommand.ExecuteScalar)
        Catch ex As Exception
            VendorClass = "CANADIAN"
        End Try
        Try
            CheckType = CStr(CheckTypeCommand.ExecuteScalar)
        Catch ex As Exception
            CheckType = "STANDARD"
        End Try
        Try
            WhitePaperCheck = CStr(WhitePaperCheckCommand.ExecuteScalar)
        Catch ex As Exception
            WhitePaperCheck = "NO"
        End Try
        con.Close()

        cboVendorID.Text = VendorID
        txtBatchNumber.Text = BatchNumber

        IsLoaded = True
        cboPaymentTerms.Text = PaymentTerms
        IsLoaded = False

        txtPONumber.Text = PONumber
        txtInvoiceNumber.Text = InvoiceNumber
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
        txtFreight.Text = InvoiceFreight
        txtSalesTax.Text = InvoiceSalesTax
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtDiscountAmount.Text = DiscountAmount
        txtComment.Text = Comment
        cboCheckType.Text = CheckType

        If WhitePaperCheck = "YES" Then
            chkWhitePaper.Checked = True
        Else
            chkWhitePaper.Checked = False
        End If

        IsLoaded = True
        dtpInvoiceDate.Text = InvoiceDate
        IsLoaded = False

        dtpReceiptDate.Text = ReceiptDate
        dtpDiscountDate.Text = DiscountDate
        dtpDueDate.Text = DueDate

        If CheckCode = "INTERCOMPANY" Then
            chkWhitePaper.Enabled = False
        ElseIf CheckCode = "FEDEX" Then
            chkWhitePaper.Enabled = False
        ElseIf CheckCode = "ACH" Then
            chkWhitePaper.Enabled = False
        Else
            chkWhitePaper.Enabled = True
        End If

        lblVoucherSource.Text = VoucherSource

        LoadStatus()
    End Sub

    Public Sub VerifyUniqueInvoiceNumber()
        Dim CountInvoiceNumber As Integer = 0

        Dim UniqueInvoiceStatement As String = "SELECT COUNT(InvoiceNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VoucherNumber <> @VoucherNumber AND InvoiceNumber = @InvoiceNumber AND VendorID = @VendorID"
        Dim UniqueInvoiceCommand As New SqlCommand(UniqueInvoiceStatement, con)
        UniqueInvoiceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        UniqueInvoiceCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
        UniqueInvoiceCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
        UniqueInvoiceCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountInvoiceNumber = CInt(UniqueInvoiceCommand.ExecuteScalar)
        Catch ex As Exception
            CountInvoiceNumber = 0
        End Try
        con.Close()

        If CountInvoiceNumber = 0 Then
            UniqueInvoice = "YES"
        Else
            UniqueInvoice = "NO"
        End If
    End Sub

    Public Sub LockCertainControls()
        cboVendorID.Enabled = False
        cboVendorClass.Enabled = False
        txtPONumber.Enabled = False
        txtBatchNumber.Enabled = False
        txtVendorName.Enabled = False
    End Sub

    Public Sub UnLockCertainControls()
        cboVendorID.Enabled = True
        cboVendorClass.Enabled = True
        txtVendorName.Enabled = True
    End Sub

    Public Sub LoadStatus()
        Dim VoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VoucherNumber = @VoucherNumber"
        Dim VoucherStatusCommand As New SqlCommand(VoucherStatusStatement, con)
        VoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        VoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VoucherStatus = CStr(VoucherStatusCommand.ExecuteScalar)
        Catch ex As Exception
            VoucherStatus = "POSTED"
        End Try
        con.Close()

        lblVoucherStatus.Text = VoucherStatus

        If VoucherStatus = "CLOSED" Then
            cmdDelete.Enabled = False
            cmdPost.Enabled = False
            cmdReverse.Enabled = False
            cmdSave.Enabled = False
            LockCertainControls()
        ElseIf VoucherStatus = "POSTED" And VoucherSource = "VOUCHER RECEIPT" Then
            cmdDelete.Enabled = False
            cmdPost.Enabled = False
            cmdReverse.Enabled = True
            cmdSave.Enabled = True
            LockCertainControls()
        ElseIf VoucherStatus = "OPEN" And VoucherSource = "VOUCHER RECEIPT" Then
            cmdDelete.Enabled = True
            cmdPost.Enabled = True
            cmdReverse.Enabled = False
            cmdSave.Enabled = True
            UnLockCertainControls()
        ElseIf VoucherStatus = "PENDING" And VoucherSource = "VOUCHER RECEIPT" Then
            cmdDelete.Enabled = True
            cmdPost.Enabled = True
            cmdReverse.Enabled = False
            cmdSave.Enabled = True
            UnLockCertainControls()
        ElseIf VoucherStatus = "POSTED" And VoucherSource = "PO RECEIPT" Then
            cmdDelete.Enabled = False
            cmdPost.Enabled = False
            cmdReverse.Enabled = True
            cmdSave.Enabled = True
            LockCertainControls()
        ElseIf VoucherStatus = "POSTED" And VoucherSource = "RECURRING VOUCHER" Then
            cmdDelete.Enabled = False
            cmdReverse.Enabled = True
            cmdPost.Enabled = False
            cmdSave.Enabled = True
            LockCertainControls()
        ElseIf VoucherStatus = "OPEN" And VoucherSource = "PO RECEIPT" Then
            cmdDelete.Enabled = True
            cmdPost.Enabled = True
            cmdReverse.Enabled = False
            cmdSave.Enabled = True
            UnLockCertainControls()
        ElseIf VoucherStatus = "PENDING" And VoucherSource = "PO RECEIPT" Then
            cmdDelete.Enabled = True
            cmdPost.Enabled = True
            cmdReverse.Enabled = False
            cmdSave.Enabled = True
            UnLockCertainControls()
        ElseIf VoucherStatus = "OPEN" And VoucherSource = "VENDOR RETURN" Then
            cmdDelete.Enabled = True
            cmdPost.Enabled = True
            cmdReverse.Enabled = False
            cmdSave.Enabled = True
            UnLockCertainControls()
        ElseIf VoucherStatus = "PENDING" And VoucherSource = "VENDOR RETURN" Then
            cmdDelete.Enabled = True
            cmdPost.Enabled = True
            cmdReverse.Enabled = False
            cmdSave.Enabled = True
            UnLockCertainControls()
        ElseIf VoucherStatus = "POSTED" And VoucherSource = "VENDOR RETURN" Then
            cmdDelete.Enabled = False
            cmdPost.Enabled = False
            cmdReverse.Enabled = True
            cmdSave.Enabled = True
            LockCertainControls()
        ElseIf VoucherStatus = "POSTED" And VoucherSource = "STEEL RECEIPT" Then
            cmdDelete.Enabled = False
            cmdPost.Enabled = False
            cmdReverse.Enabled = True
            cmdSave.Enabled = True
            LockCertainControls()
        ElseIf VoucherStatus = "OPEN" And VoucherSource = "STEEL RECEIPT" Then
            cmdDelete.Enabled = True
            cmdPost.Enabled = True
            cmdReverse.Enabled = False
            cmdSave.Enabled = True
            UnLockCertainControls()
        ElseIf VoucherStatus = "PENDING" And VoucherSource = "STEEL RECEIPT" Then
            cmdDelete.Enabled = True
            cmdPost.Enabled = True
            cmdReverse.Enabled = False
            cmdSave.Enabled = True
            UnLockCertainControls()
        Else
            cmdDelete.Enabled = False
            cmdPost.Enabled = False
            cmdReverse.Enabled = False
            cmdSave.Enabled = False
            UnLockCertainControls()
        End If
    End Sub

    Public Sub ReloadTotals()
        Dim SUMExtendedAmountStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
        Dim SUMExtendedAmountCommand As New SqlCommand(SUMExtendedAmountStatement, con)
        SUMExtendedAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SUMExtendedAmount = CDbl(SUMExtendedAmountCommand.ExecuteScalar)
        Catch ex As Exception
            SUMExtendedAmount = 0
        End Try
        con.Close()

        SUMExtendedAmount = Round(SUMExtendedAmount, 2)

        ProductTotal = SUMExtendedAmount
        InvoiceFreight = Val(txtFreight.Text)
        InvoiceSalesTax = Val(txtSalesTax.Text)
        InvoiceTotal = ProductTotal + InvoiceFreight + InvoiceSalesTax

        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtProductTotal.Text = FormatCurrency(ProductTotal, 2)
    End Sub

    Private Sub cmdReverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReverse.Click
        If cboVoucherNumber.Text = "" Or Val(cboVoucherNumber.Text) = 0 Then
            MsgBox("You must have a valid Voucher Number selected.", MsgBoxStyle.OkOnly)
        Else
            'Prompt before reversing
            Dim button As DialogResult = MessageBox.Show("Do you wish to reverse this Voucher?", "REVERSE VOUCHER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Get Voucher Source and Voucher Status
                Dim GetVoucherStatus As String = ""
                Dim GetVoucherSource As String = ""

                Dim GetVoucherStatusStatement As String = "SELECT VoucherStatus FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim GetVoucherStatusCommand As New SqlCommand(GetVoucherStatusStatement, con)
                GetVoucherStatusCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                GetVoucherStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim GetVoucherSourceStatement As String = "SELECT VoucherSource FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim GetVoucherSourceCommand As New SqlCommand(GetVoucherSourceStatement, con)
                GetVoucherSourceCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                GetVoucherSourceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetVoucherStatus = CStr(GetVoucherStatusCommand.ExecuteScalar)
                Catch ex As Exception
                    GetVoucherStatus = ""
                End Try
                Try
                    GetVoucherSource = CStr(GetVoucherSourceCommand.ExecuteScalar)
                Catch ex As Exception
                    GetVoucherSource = ""
                End Try
                con.Close()

                If GetVoucherSource = "" Or GetVoucherStatus = "" Then
                    MsgBox("Select a valid Voucher #.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*******************************************************************************************************************
                'Declare variables for line data
                Dim LineExtendedAmount As Double = 0
                Dim LineNumber As Integer = 0
                Dim LineDebitAccount, LineCreditAccount As String
                Dim LineReceiverNumber, LineReceiverLine As Integer

                'Check Voucher Status and source
                If VoucherStatus = "POSTED" And VoucherSource = "VOUCHER RECEIPT" Then
                    LoadPostingDateForReversal()

                    'Get Line Items from the datagrid
                    For Each row As DataGridViewRow In dgvVoucherLines.Rows
                        Try
                            LineNumber = row.Cells("VoucherLineColumn").Value
                        Catch ex As Exception
                            LineNumber = 0
                        End Try
                        Try
                            LineDebitAccount = row.Cells("GLDebitAccountColumn").Value
                        Catch ex As Exception
                            LineDebitAccount = ""
                        End Try
                        Try
                            LineCreditAccount = row.Cells("GLCreditAccountColumn").Value
                        Catch ex As Exception
                            LineCreditAccount = "20000"
                        End Try
                        Try
                            LineExtendedAmount = row.Cells("ExtendedAmountColumn").Value
                        Catch ex As Exception
                            LineExtendedAmount = 0
                        End Try

                        LineExtendedAmount = Round(LineExtendedAmount, 2)

                        VendorClass = cboVendorClass.Text

                        'Change GL Accounts to Canadian if nessary
                        If cboDivisionID.Text = "TFF" And VendorClass = "CANADIAN" Then
                            LineDebitAccount = "C$" & LineDebitAccount
                            LineCreditAccount = "C$" & LineCreditAccount
                            GLFreightAccount = "C$62000"
                            GLTaxAccount = "C$14500"
                            GLPayableAccount = "C$20000"
                        ElseIf cboDivisionID.Text = "TOR" And VendorClass = "CANADIAN" Then
                            LineDebitAccount = "C$" & LineDebitAccount
                            LineCreditAccount = "C$" & LineCreditAccount
                            GLFreightAccount = "C$62000"
                            GLTaxAccount = "C$14500"
                            GLPayableAccount = "C$20000"
                        ElseIf cboDivisionID.Text = "ALB" And VendorClass = "CANADIAN" Then
                            LineDebitAccount = "C$" & LineDebitAccount
                            LineCreditAccount = "C$" & LineCreditAccount
                            GLFreightAccount = "C$62000"
                            GLTaxAccount = "C$14500"
                            GLPayableAccount = "C$20000"
                        Else
                            GLFreightAccount = "62000"
                            GLTaxAccount = "78000"
                            GLPayableAccount = "20000"
                        End If
                        '*********************************************************************************************************
                        'Write to GL Table
                        Try
                            'Writes first value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineCreditAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure (Debit)"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '*********************************************************************************************************
                        Try
                            'Writes second value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure (Credit)"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    Next
                    '*********************************************************************************************************
                    'Check for Voucher Sales Tax
                    If Val(txtSalesTax.Text) <> 0 Then
                        'Write to GL Table
                        Try
                            'Writes first value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLTaxAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Sales Tax Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Tax) --- GL Insert Failure (Credit)"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '*********************************************************************************************************
                        Try
                            'Writes second value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayableAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Sales Tax Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Tax) --- GL Insert Failure (Debit)"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    Else
                        'Skip - no sales tax
                    End If
                    '*********************************************************************************************************
                    'Check for Voucher Freight
                    If Val(txtFreight.Text) <> 0 Then
                        'Write to GL Table
                        Try
                            'Writes first value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLFreightAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Freight Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Freight) --- GL Insert Failure (Credit)"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '*********************************************************************************************************
                        Try
                            'Writes second value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayableAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Freight Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Freight) --- GL Insert Failure (Debit)"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    Else
                        'Skip - no freight
                    End If
                    '*********************************************************************************************************
                    'Save data to Header Table (reopen)
                    cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '**********************************************************************************************************************
                    'Save data to Line Table (reopen)
                    cmd = New SqlCommand("Update ReceiptOfInvoiceVoucherLines SET SelectForInvoice = @SelectForInvoice WHERE VoucherNumber = @VoucherNumber", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "RECEIVED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '***********************************************************************************************************************
                    'Write To Audit Trail on a reversal
                    Dim AuditComment As String = ""
                    Dim AuditVoucherNumber As Integer = 0
                    Dim strAuditVoucherNumber As String = ""

                    AuditVoucherNumber = Val(cboVoucherNumber.Text)
                    strAuditVoucherNumber = CStr(AuditVoucherNumber)
                    AuditComment = "Voucher #" + strAuditVoucherNumber + " was reversed on " + TodaysDate

                    Try
                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "AP Voucher - REVERSAL"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = Val(txtInvoiceTotal.Text)
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strAuditVoucherNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try
                    '***********************************************************************************************************************
                    LoadStatus()

                    MsgBox("Voucher posting has been reversed and is open for editing.", MsgBoxStyle.OkOnly)
                    '-----------------------------------------------------------------------------------------------------------------------------------------
                ElseIf VoucherStatus = "POSTED" And VoucherSource = "PO RECEIPT" Then
                    '-----------------------------------------------------------------------------------------------------------------------------------------
                    LoadPostingDateForReversal()

                    Dim VoucherUnitCost As Double = 0
                    Dim GetReceiverCost As Double = 0
                    Dim VoucherQuantity As Double = 0
                    Dim VoucherCostAdjustment As Double = 0

                    'Get Line Items from the datagrid
                    For Each row As DataGridViewRow In dgvVoucherLines.Rows
                        Try
                            LineNumber = row.Cells("VoucherLineColumn").Value
                        Catch ex As Exception
                            LineNumber = 0
                        End Try
                        Try
                            LineDebitAccount = row.Cells("GLDebitAccountColumn").Value
                        Catch ex As Exception
                            LineDebitAccount = "20999"
                        End Try
                        Try
                            LineCreditAccount = row.Cells("GLCreditAccountColumn").Value
                        Catch ex As Exception
                            LineCreditAccount = "20000"
                        End Try
                        Try
                            LineExtendedAmount = row.Cells("ExtendedAmountColumn").Value
                        Catch ex As Exception
                            LineExtendedAmount = 0
                        End Try
                        Try
                            LineReceiverNumber = row.Cells("ReceiverNumberColumn").Value
                        Catch ex As Exception
                            LineReceiverNumber = 0
                        End Try
                        Try
                            LineReceiverLine = row.Cells("ReceiverLineColumn").Value
                        Catch ex As Exception
                            LineReceiverLine = 0
                        End Try
                        Try
                            VoucherUnitCost = row.Cells("UnitCostColumn").Value
                        Catch ex As Exception
                            VoucherUnitCost = 0
                        End Try
                        Try
                            VoucherQuantity = row.Cells("QuantityColumn").Value
                        Catch ex As Exception
                            VoucherQuantity = 0
                        End Try

                        LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

                        VendorClass = cboVendorClass.Text

                        'Change GL Accounts to Canadian if nessary
                        If cboDivisionID.Text = "TFF" And VendorClass = "CANADIAN" Then
                            LineDebitAccount = "C$" & LineDebitAccount
                            LineCreditAccount = "C$" & LineCreditAccount
                            GLFreightAccount = "C$62000"
                            GLTaxAccount = "C$14500"
                            GLPayableAccount = "C$20000"
                        ElseIf cboDivisionID.Text = "TOR" And VendorClass = "CANADIAN" Then
                            LineDebitAccount = "C$" & LineDebitAccount
                            LineCreditAccount = "C$" & LineCreditAccount
                            GLFreightAccount = "C$62000"
                            GLTaxAccount = "C$14500"
                            GLPayableAccount = "C$20000"
                        ElseIf cboDivisionID.Text = "ALB" And VendorClass = "CANADIAN" Then
                            LineDebitAccount = "C$" & LineDebitAccount
                            LineCreditAccount = "C$" & LineCreditAccount
                            GLFreightAccount = "C$62000"
                            GLTaxAccount = "C$14500"
                            GLPayableAccount = "C$20000"
                        Else
                            GLFreightAccount = "62000"
                            GLTaxAccount = "78000"
                            GLPayableAccount = "20000"
                        End If

                        'Write to GL Table
                        Try
                            'Writes first value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineCreditAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try

                        Try
                            'Writes second value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '***********************************************************************************************************************
                        'Check and undo Voucher Cost Adjustments for voucher when reversing

                        VoucherUnitCost = Math.Round(VoucherUnitCost, 5)

                        'Get Unit Cost for receiver
                        Dim GetReceiverCostStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey"
                        Dim GetReceiverCostCommand As New SqlCommand(GetReceiverCostStatement, con)
                        GetReceiverCostCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                        GetReceiverCostCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLine

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetReceiverCost = CDbl(GetReceiverCostCommand.ExecuteScalar)
                        Catch ex As Exception
                            GetReceiverCost = 0
                        End Try
                        con.Close()

                        GetReceiverCost = Math.Round(GetReceiverCost, 5)

                        If ((GetReceiverCost > VoucherUnitCost) And (GetReceiverCost - VoucherUnitCost < 0.01)) Or ((VoucherUnitCost > GetReceiverCost) And (VoucherUnitCost - GetReceiverCost < 0.01)) Then
                            'Skip
                        Else
                            If GetReceiverCost = VoucherUnitCost Then
                                'Do nothing - there is no adjustment
                            ElseIf GetReceiverCost < VoucherUnitCost Then
                                'Get Receiver GL Accounts
                                Dim ReceiverCreditAccount As String = ""
                                Dim ReceiverDebitAccount As String = ""

                                'Default GL Accounts on receiver
                                'Debit = 20999
                                'Credit = 12100

                                Dim GetReceiverCreditAccountStatement As String = "SELECT CreditGLAccount FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey"
                                Dim GetReceiverCreditAccountCommand As New SqlCommand(GetReceiverCreditAccountStatement, con)
                                GetReceiverCreditAccountCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                                GetReceiverCreditAccountCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLine

                                Dim GetReceiverDebitAccountStatement As String = "SELECT DebitGlaccount FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey"
                                Dim GetReceiverDebitAccountCommand As New SqlCommand(GetReceiverDebitAccountStatement, con)
                                GetReceiverDebitAccountCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                                GetReceiverDebitAccountCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLine

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    ReceiverCreditAccount = CStr(GetReceiverCreditAccountCommand.ExecuteScalar)
                                Catch ex As Exception
                                    ReceiverCreditAccount = "20999"
                                End Try
                                Try
                                    ReceiverDebitAccount = CStr(GetReceiverDebitAccountCommand.ExecuteScalar)
                                Catch ex As Exception
                                    ReceiverDebitAccount = "12100"
                                End Try
                                con.Close()

                                'Calculate Adjustment
                                VoucherCostAdjustment = (VoucherUnitCost - GetReceiverCost) * VoucherQuantity
                                VoucherCostAdjustment = Math.Round(VoucherCostAdjustment, 2)

                                Try
                                    'Writes second value to the General Ledger
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Reversal (Voucher Cost Adjustment)"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = VoucherCostAdjustment
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Error checking
                                    'Log error on update failure
                                    Dim TempVoucherNumber As Integer = 0
                                    Dim strVoucherNumber As String
                                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                                    strVoucherNumber = CStr(TempVoucherNumber)

                                    ErrorDate = TodaysDate
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure"
                                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try

                                Try
                                    'Writes second value to the General Ledger
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Reversal (Voucher Cost Adjustment)"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = VoucherCostAdjustment
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Error checking
                                    'Log error on update failure
                                    Dim TempVoucherNumber As Integer = 0
                                    Dim strVoucherNumber As String
                                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                                    strVoucherNumber = CStr(TempVoucherNumber)

                                    ErrorDate = TodaysDate
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure"
                                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                            ElseIf GetReceiverCost > VoucherUnitCost Then
                                'Get Receiver GL Accounts
                                Dim ReceiverCreditAccount As String = ""
                                Dim ReceiverDebitAccount As String = ""

                                'Default GL Accounts on receiver
                                'Debit = 20999
                                'Credit = 12100

                                Dim GetReceiverCreditAccountStatement As String = "SELECT CreditGLAccount FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey"
                                Dim GetReceiverCreditAccountCommand As New SqlCommand(GetReceiverCreditAccountStatement, con)
                                GetReceiverCreditAccountCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                                GetReceiverCreditAccountCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLine

                                Dim GetReceiverDebitAccountStatement As String = "SELECT DebitGlaccount FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey"
                                Dim GetReceiverDebitAccountCommand As New SqlCommand(GetReceiverDebitAccountStatement, con)
                                GetReceiverDebitAccountCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                                GetReceiverDebitAccountCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLine

                                If con.State = ConnectionState.Closed Then con.Open()
                                Try
                                    ReceiverCreditAccount = CStr(GetReceiverCreditAccountCommand.ExecuteScalar)
                                Catch ex As Exception
                                    ReceiverCreditAccount = "12100"
                                End Try
                                Try
                                    ReceiverDebitAccount = CStr(GetReceiverDebitAccountCommand.ExecuteScalar)
                                Catch ex As Exception
                                    ReceiverDebitAccount = "20999"
                                End Try
                                con.Close()

                                'Calculate adjustment
                                VoucherCostAdjustment = (GetReceiverCost - VoucherUnitCost) * VoucherQuantity
                                VoucherCostAdjustment = Math.Round(VoucherCostAdjustment, 2)

                                Try
                                    'Writes second value to the General Ledger
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Reversal (Voucher Cost Adjustment)"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = VoucherCostAdjustment
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Error checking
                                    'Log error on update failure
                                    Dim TempVoucherNumber As Integer = 0
                                    Dim strVoucherNumber As String
                                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                                    strVoucherNumber = CStr(TempVoucherNumber)

                                    ErrorDate = TodaysDate
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure"
                                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try

                                Try
                                    'Writes second value to the General Ledger
                                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                                    With cmd.Parameters
                                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Reversal (Voucher Cost Adjustment)"
                                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = VoucherCostAdjustment
                                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                                    End With

                                    If con.State = ConnectionState.Closed Then con.Open()
                                    cmd.ExecuteNonQuery()
                                    con.Close()
                                Catch ex As Exception
                                    'Error checking
                                    'Log error on update failure
                                    Dim TempVoucherNumber As Integer = 0
                                    Dim strVoucherNumber As String
                                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                                    strVoucherNumber = CStr(TempVoucherNumber)

                                    ErrorDate = TodaysDate
                                    ErrorComment = ex.ToString()
                                    ErrorDivision = cboDivisionID.Text
                                    ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure"
                                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                                    ErrorUser = EmployeeLoginName

                                    TFPErrorLogUpdate()
                                End Try
                            Else
                                'Do nothing
                            End If
                        End If
                    Next

                    'Check for Voucher Sales Tax
                    If Val(txtSalesTax.Text) <> 0 Then
                        'Write to GL Table
                        Try
                            'Writes first value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLTaxAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Sales Tax Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Tax) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try

                        Try
                            'Writes second value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayableAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Sales Tax Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Tax) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    Else
                        'Skip - no sales tax
                    End If

                    'Check for Voucher Freight
                    If Val(txtFreight.Text) <> 0 Then
                        'Write to GL Table
                        Try
                            'Writes first value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLFreightAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Freight Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Freight) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '**********************************************************************************************************************
                        Try
                            'Writes second value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayableAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Freight Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Freight) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    Else
                        'Skip - no freight
                    End If
                    '**********************************************************************************************************************
                    'Save data to Header Table (reopen)
                    cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '**********************************************************************************************************************
                    'Save data to Line Table (reopen)
                    cmd = New SqlCommand("Update ReceiptOfInvoiceVoucherLines SET SelectForInvoice = @SelectForInvoice WHERE VoucherNumber = @VoucherNumber", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "RECEIVED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '***********************************************************************************
                    'Write To Audit Trail on a reversal
                    Dim AuditComment As String = ""
                    Dim AuditVoucherNumber As Integer = 0
                    Dim strAuditVoucherNumber As String = ""

                    AuditVoucherNumber = Val(cboVoucherNumber.Text)
                    strAuditVoucherNumber = CStr(AuditVoucherNumber)
                    AuditComment = "Voucher #" + strAuditVoucherNumber + " was reversed on " + TodaysDate

                    Try
                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "AP Voucher - REVERSAL"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = Val(txtInvoiceTotal.Text)
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strAuditVoucherNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try
                    '***********************************************************************************************************************
                    LoadStatus()

                    MsgBox("Voucher posting has been reversed and is open for editing.", MsgBoxStyle.OkOnly)
                ElseIf VoucherStatus = "POSTED" And VoucherSource = "VENDOR RETURN" Then
                    MsgBox("A voucher posting for a vendor return cannot be reversed at this time.", MsgBoxStyle.OkOnly)
                    Exit Sub
                ElseIf VoucherStatus = "POSTED" And VoucherSource = "STEEL VENDOR RETURN" Then
                    MsgBox("A voucher posting for a steel vendor return cannot be reversed at this time.", MsgBoxStyle.OkOnly)
                    Exit Sub








                ElseIf VoucherStatus = "POSTED" And VoucherSource = "STEEL RECEIPT" Then
                    LoadPostingDateForReversal()

                    'Get Line Items from the datagrid
                    For Each row As DataGridViewRow In dgvVoucherLines.Rows
                        Try
                            LineNumber = row.Cells("VoucherLineColumn").Value
                        Catch ex As Exception
                            LineNumber = 0
                        End Try
                        Try
                            LineDebitAccount = row.Cells("GLDebitAccountColumn").Value
                        Catch ex As Exception
                            LineDebitAccount = "20999"
                        End Try
                        Try
                            'LineCreditAccount = row.Cells("GLCreditAccountColumn").Value
                            LineCreditAccount = "20000"
                        Catch ex As Exception
                            LineCreditAccount = "20000"
                        End Try
                        Try
                            LineExtendedAmount = row.Cells("ExtendedAmountColumn").Value
                        Catch ex As Exception
                            LineExtendedAmount = 0
                        End Try

                        LineExtendedAmount = Math.Round(LineExtendedAmount, 2, MidpointRounding.AwayFromZero)

                        VendorClass = cboVendorClass.Text
                        '**************************************************************************************************************************
                        ''WRITE REVERSAL ENTRIES TO GL
                        cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey)+1, 22000001) FROM GLTransactionMasterList); Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) VALUES (@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus), (@Key + 1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus); COMMIT TRAN;", con)

                        With cmd.Parameters
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineCreditAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Reversal"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            ''CREDIT Posting FOR GL
                            .Add("@GLAccountNumber1", SqlDbType.VarChar).Value = LineDebitAccount
                            .Add("@GLTransactionDebitAmount1", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount1", SqlDbType.VarChar).Value = LineExtendedAmount
                        End With

                        Try
                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                        '*****************************************************************************************************************************
                        cmd = New SqlCommand("SELECT SteelExtendedCost FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND RMID = @RMID", con)
                        cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = row.Cells("ReceiverNumberColumn").Value
                        cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = row.Cells("PartNumberColumn").Value
                        Dim receivingExtendedCost As Double = 0.0
                        If con.State = ConnectionState.Closed Then con.Open()
                        receivingExtendedCost = Math.Round(cmd.ExecuteScalar(), 2)
                        con.Close()
                        Dim VoucherExtendedAmount As Double = row.Cells("ExtendedAmountColumn").Value

                        If receivingExtendedCost <> VoucherExtendedAmount AndAlso row.Cells("ReceiverNumberColumn").Value <> 0 Then
                            'Write to Debit Side of a Voucher Cost Adjustment
                            Dim CostAdjustmentAmount As Double = Math.Round(VoucherExtendedAmount - receivingExtendedCost, 2, MidpointRounding.AwayFromZero)
                            ''checks to see if the amount is negative, if so will switch the debit, credit accounts and abs the difference
                            Dim GLCreditAccount As String = row.Cells("GLDebitAccountColumn").Value
                            Dim GLDebitAccount As String = "12000"
                            If CostAdjustmentAmount < 0 Then
                                CostAdjustmentAmount = Math.Abs(CostAdjustmentAmount)
                                Dim tmp As String = GLCreditAccount
                                GLCreditAccount = GLDebitAccount
                                GLDebitAccount = tmp
                            End If

                            cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList);" _
                                                 + " SET xact_abort on;" _
                                                 + " Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values", con)
                            cmd.CommandText += "(@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"

                            With cmd.Parameters
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment(STEEL) - Reversal"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Receiver Number " & row.Cells("ReceiverNumberColumn").Value
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If cboDivisionID.Text.Equals("TST") Then
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                            Else
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                            End If

                            cmd.CommandText += ", (@Key + 1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"
                            With cmd.Parameters
                                .Add("@GLAccountNumber1", SqlDbType.VarChar).Value = GLCreditAccount
                                .Add("@GLTransactionDebitAmount1", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount1", SqlDbType.VarChar).Value = CostAdjustmentAmount
                            End With
                            cmd.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
                            Try
                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Catch ex As Exception
                                con.Close()

                                ErrorDate = TodaysDate
                                ErrorComment = ex.ToString()
                                ErrorDivision = cboDivisionID.Text
                                ErrorDescription = "APViewVoucherLines - cmdRevers_Click --Error Inserting GL DEBIT & CREDIT transaction for Steel Cost adjustment Reversal"
                                ErrorReferenceNumber = "Batch # " + txtBatchNumber.Text
                                ErrorUser = EmployeeLoginName

                                TFPErrorLogUpdate()
                            End Try
                        End If
                    Next
                    '**********************************************************************************************************************
                    'Check for Voucher Sales Tax
                    If Val(txtSalesTax.Text) <> 0 Then
                        'Write to GL
                        cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey)+1, 22000001) FROM GLTransactionMasterList);" _
                                             + " Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)" _
                                            + " VALUES (@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)" _
                                            + " , (@Key + 1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus);" _
                                            + " COMMIT TRAN;", con)

                        With cmd.Parameters
                            .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLTaxAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Sales Tax Reversal"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            ''DEBIT Posting FOR GL
                            .Add("@GLAccountNumber1", SqlDbType.VarChar).Value = GLPayableAccount
                            .Add("@GLTransactionDebitAmount1", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                            .Add("@GLTransactionCreditAmount1", SqlDbType.VarChar).Value = 0
                        End With

                        Try
                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Tax) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    Else
                        'Skip - no sales tax
                    End If
                    '**********************************************************************************************************************
                    'Check for Voucher Freight
                    If Val(txtFreight.Text) <> 0 Then
                        'Write to GL
                        cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey)+1, 22000001) FROM GLTransactionMasterList); Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) VALUES (@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus), (@Key + 1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus); COMMIT TRAN;", con)

                        With cmd.Parameters
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLFreightAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Freight Reversal"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            ''DEBIT Posting FOR GL
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayableAccount
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        End With

                        Try
                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Freight) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    Else
                        'Skip - no freight
                    End If
                    '**********************************************************************************************************************
                    'Save data to Header Table (reopen)
                    cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '**********************************************************************************************************************
                    'Save data to Line Table (reopen)
                    cmd = New SqlCommand("Update ReceiptOfInvoiceVoucherLines SET SelectForInvoice = @SelectForInvoice WHERE VoucherNumber = @VoucherNumber", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "RECEIVED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '***********************************************************************************************************************
                    'Write To Audit Trail on a reversal
                    Dim AuditComment As String = ""
                    Dim AuditVoucherNumber As Integer = 0
                    Dim strAuditVoucherNumber As String = ""

                    AuditVoucherNumber = Val(cboVoucherNumber.Text)
                    strAuditVoucherNumber = CStr(AuditVoucherNumber)
                    AuditComment = "Voucher #" + strAuditVoucherNumber + " was reversed on " + TodaysDate

                    Try
                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "AP Voucher - REVERSAL"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = Val(txtInvoiceTotal.Text)
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strAuditVoucherNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try
                    '***********************************************************************************************************************
                    LoadStatus()

                    MsgBox("Voucher posting has been reversed and is open for editing.", MsgBoxStyle.OkOnly)
                ElseIf VoucherStatus = "POSTED" And VoucherSource = "STEEL VENDOR RETURN" Then
                    MsgBox("A voucher posting for a steel vendor return cannot be reversed at this time.", MsgBoxStyle.OkOnly)
                    Exit Sub


                Else
                    MsgBox("You cannot reverse this voucher at this time.", MsgBoxStyle.OkOnly)
                End If
            ElseIf button = DialogResult.No Then
                cmdReverse.Focus()
            End If
        End If
    End Sub

    Private Sub cmdPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPost.Click
        '*************************************************************************************
        'Validate required fields
        If cboVoucherNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Do nothing and continue
        End If
        '*************************************************************************************
        Dim button As DialogResult = MessageBox.Show("Do you wish to post this Voucher?", "POST VOUCHER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Do nothing and continue

        ElseIf button = DialogResult.No Then
            cmdPost.Focus()
            Exit Sub
        End If
        '**************************************************************************************
        'Validate dates
        ValidateDates()

        If CheckAndValidateDates = "NOT OKAY" Then
            Dim button2 As DialogResult = MessageBox.Show("One of your dates is more than 90 days out. Do you wish to continue?", "DATE 90 DAYS OR OVER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If button2 = DialogResult.Yes Then
                'Do nothing and continue
            ElseIf button2 = DialogResult.No Then
                Exit Sub
            End If
        Else
            'Do nothing
        End If
        '**************************************************************************************        'Check to see if Voucher is already posted
        Dim LineExtendedAmount As Double = 0
        Dim LineNumber As Integer = 0
        Dim LineDebitAccount, LineCreditAccount As String
        Dim LineReceiverNumber, LineReceiverLine As Integer

        'Check Voucher Status and source
        If VoucherStatus = "OPEN" And VoucherSource = "VOUCHER RECEIPT" Then
            LoadPostingDateForReversal()

            'Get Line Items from the datagrid
            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Try
                    LineNumber = row.Cells("VoucherLineColumn").Value
                Catch ex As Exception
                    LineNumber = 0
                End Try
                Try
                    LineDebitAccount = row.Cells("GLDebitAccountColumn").Value
                Catch ex As Exception
                    LineDebitAccount = "20999"
                End Try
                Try
                    LineCreditAccount = row.Cells("GLCreditAccountColumn").Value
                Catch ex As Exception
                    LineCreditAccount = "20000"
                End Try
                Try
                    LineExtendedAmount = row.Cells("ExtendedAmountColumn").Value
                Catch ex As Exception
                    LineExtendedAmount = ""
                End Try

                LineExtendedAmount = Round(LineExtendedAmount, 2)

                'Retotal Voucher
                ReloadTotals()
                '************************************************************************************************
                'Determine Check Type
                If cboCheckType.Text = "STANDARD" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "ACH" Then
                    'Do nothing - check type is filled
                Else
                    MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************
                If chkWhitePaper.Checked = True Then
                    WhitePaperCheck = "YES"
                Else
                    WhitePaperCheck = "NO"
                End If
                '*****************************************************************************
                'Save data to Table
                cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, VendorClass = @VendorClass, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@PONumber", SqlDbType.VarChar).Value = Val(txtPONumber.Text)
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                    .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDate.Text
                    .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDate.Text
                    .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                    .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@InvoiceAmount", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                    .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDiscountDate.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Value
                    .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
                    .Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                    .Add("@VoucherSource", SqlDbType.VarChar).Value = "VOUCHER RECEIPT"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                    .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                    .Add("@TempSelected", SqlDbType.VarChar).Value = ""
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = ""
                    .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaperCheck
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '********************************************************************************************************
                'Determine GL Accounts
                VendorClass = cboVendorClass.Text

                'Change GL Accounts to Canadian if nessary
                If cboDivisionID.Text = "TFF" And VendorClass = "CANADIAN" Then
                    LineDebitAccount = "C$" & LineDebitAccount
                    LineCreditAccount = "C$" & LineCreditAccount
                    GLFreightAccount = "C$62000"
                    GLTaxAccount = "C$14500"
                    GLPayableAccount = "C$20000"
                ElseIf cboDivisionID.Text = "TOR" And VendorClass = "CANADIAN" Then
                    LineDebitAccount = "C$" & LineDebitAccount
                    LineCreditAccount = "C$" & LineCreditAccount
                    GLFreightAccount = "C$62000"
                    GLTaxAccount = "C$14500"
                    GLPayableAccount = "C$20000"
                Else
                    GLFreightAccount = "62000"
                    GLTaxAccount = "78000"
                    GLPayableAccount = "20000"
                End If
                '********************************************************************************************************
                'Write to GL Table
                Try
                    'Writes first value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineDebitAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Lines) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '********************************************************************************************************
                Try
                    'Writes second value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineCreditAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Lines) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Next
            '********************************************************************************************************
            'Check for Voucher Sales Tax
            If Val(txtSalesTax.Text) <> 0 Then
                'Write to GL Table
                Try
                    'Writes first value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayableAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Sales Tax"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Tax) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                Try
                    'Writes second value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLTaxAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Sales Tax"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Tax) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Skip - no sales tax
            End If
            '********************************************************************************************************
            'Check for Voucher Freight
            If Val(txtFreight.Text) <> 0 Then
                'Write to GL Table
                Try
                    'Writes first value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayableAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Freight"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Freight) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                Try
                    'Writes second value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLFreightAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Freight"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Freight) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Skip - no freight
            End If
            '********************************************************************************************************
            'Save data to Header Table (reopen)
            cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '********************************************************************************************************
            'Save data to Line Table (reopen)
            cmd = New SqlCommand("Update ReceiptOfInvoiceVoucherLines SET SelectForInvoice = @SelectForInvoice WHERE VoucherNumber = @VoucherNumber", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "POSTED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadStatus()

            MsgBox("Voucher has been re-posted.", MsgBoxStyle.OkOnly)
        ElseIf VoucherStatus = "OPEN" And VoucherSource = "PO RECEIPT" Then
            LoadPostingDateForReversal()

            Dim VoucherUnitCost As Double = 0
            Dim GetReceiverCost As Double = 0
            Dim VoucherQuantity As Double = 0
            Dim VoucherCostAdjustment As Double = 0

            'Get Line Items from the datagrid
            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Try
                    LineNumber = row.Cells("VoucherLineColumn").Value
                Catch ex As Exception
                    LineNumber = 0
                End Try
                Try
                    LineDebitAccount = row.Cells("GLDebitAccountColumn").Value
                Catch ex As Exception
                    LineDebitAccount = "20999"
                End Try
                Try
                    LineCreditAccount = row.Cells("GLCreditAccountColumn").Value
                Catch ex As Exception
                    LineCreditAccount = "20000"
                End Try
                Try
                    LineExtendedAmount = row.Cells("ExtendedAmountColumn").Value
                Catch ex As Exception
                    LineExtendedAmount = 0
                End Try
                Try
                    LineReceiverNumber = row.Cells("ReceiverNumberColumn").Value
                Catch ex As Exception
                    LineReceiverNumber = 0
                End Try
                Try
                    LineReceiverLine = row.Cells("ReceiverLineColumn").Value
                Catch ex As Exception
                    LineReceiverLine = 0
                End Try
                Try
                    VoucherUnitCost = row.Cells("UnitCostColumn").Value
                Catch ex As Exception
                    VoucherUnitCost = 0
                End Try
                Try
                    VoucherQuantity = row.Cells("QuantityColumn").Value
                Catch ex As Exception
                    VoucherQuantity = 0
                End Try

                LineExtendedAmount = Round(LineExtendedAmount, 2)

                'Retotal Voucher
                ReloadTotals()
                '************************************************************************************************
                'Determine Check Type
                If cboCheckType.Text = "STANDARD" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "ACH" Then
                    'Do nothing - check type is filled
                Else
                    MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************
                If chkWhitePaper.Checked = True Then
                    WhitePaperCheck = "YES"
                Else
                    WhitePaperCheck = "NO"
                End If
                '*****************************************************************************
                'Save data to Table
                cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, VendorClass = @VendorClass, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@PONumber", SqlDbType.VarChar).Value = Val(txtPONumber.Text)
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                    .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDate.Text
                    .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDate.Text
                    .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                    .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@InvoiceAmount", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                    .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDiscountDate.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
                    .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
                    .Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                    .Add("@VoucherSource", SqlDbType.VarChar).Value = "PO RECEIPT"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                    .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                    .Add("@TempSelected", SqlDbType.VarChar).Value = ""
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = ""
                    .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaperCheck
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                VendorClass = cboVendorClass.Text

                'Change GL Accounts to Canadian if nessary
                If cboDivisionID.Text = "TFF" And VendorClass = "CANADIAN" Then
                    LineDebitAccount = "C$" & LineDebitAccount
                    LineCreditAccount = "C$" & LineCreditAccount
                    GLFreightAccount = "C$62000"
                    GLTaxAccount = "C$14500"
                    GLPayableAccount = "C$20000"
                ElseIf cboDivisionID.Text = "TOR" And VendorClass = "CANADIAN" Then
                    LineDebitAccount = "C$" & LineDebitAccount
                    LineCreditAccount = "C$" & LineCreditAccount
                    GLFreightAccount = "C$62000"
                    GLTaxAccount = "C$14500"
                    GLPayableAccount = "C$20000"
                Else
                    GLFreightAccount = "62000"
                    GLTaxAccount = "78000"
                    GLPayableAccount = "20000"
                End If

                'Write to GL Table
                Try
                    'Writes first value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineDebitAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Lines) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                Try
                    'Writes second value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineCreditAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Lines) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************************************************
                'Check and undo Voucher Cost Adjustments for voucher when reversing

                VoucherUnitCost = Math.Round(VoucherUnitCost, 5)

                'Get Unit Cost for receiver
                Dim GetReceiverCostStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey"
                Dim GetReceiverCostCommand As New SqlCommand(GetReceiverCostStatement, con)
                GetReceiverCostCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                GetReceiverCostCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLine

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetReceiverCost = CDbl(GetReceiverCostCommand.ExecuteScalar)
                Catch ex As Exception
                    GetReceiverCost = 0
                End Try
                con.Close()

                GetReceiverCost = Math.Round(GetReceiverCost, 5)

                If ((GetReceiverCost > VoucherUnitCost) And (GetReceiverCost - VoucherUnitCost < 0.01)) Or ((VoucherUnitCost > GetReceiverCost) And (VoucherUnitCost - GetReceiverCost < 0.01)) Then
                    'Skip
                Else
                    If GetReceiverCost = VoucherUnitCost Then
                        'Do nothing - there is no adjustment
                    ElseIf GetReceiverCost < VoucherUnitCost Then
                        'Get Receiver GL Accounts
                        Dim ReceiverCreditAccount As String = ""
                        Dim ReceiverDebitAccount As String = ""

                        'Default GL Accounts on receiver
                        'Debit = 12100
                        'Credit = 20999

                        Dim GetReceiverCreditAccountStatement As String = "SELECT DebitGlAccount FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey"
                        Dim GetReceiverCreditAccountCommand As New SqlCommand(GetReceiverCreditAccountStatement, con)
                        GetReceiverCreditAccountCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                        GetReceiverCreditAccountCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLine

                        Dim GetReceiverDebitAccountStatement As String = "SELECT CreditGLAccount FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey"
                        Dim GetReceiverDebitAccountCommand As New SqlCommand(GetReceiverDebitAccountStatement, con)
                        GetReceiverDebitAccountCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                        GetReceiverDebitAccountCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLine

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ReceiverCreditAccount = CStr(GetReceiverCreditAccountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ReceiverCreditAccount = "12100"
                        End Try
                        Try
                            ReceiverDebitAccount = CStr(GetReceiverDebitAccountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ReceiverDebitAccount = "20999"
                        End Try
                        con.Close()

                        'Calculate Adjustment
                        VoucherCostAdjustment = (VoucherUnitCost - GetReceiverCost) * VoucherQuantity
                        VoucherCostAdjustment = Math.Round(VoucherCostAdjustment, 2)

                        Try
                            'Writes second value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - REPOST (Voucher Cost Adjustment)"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = VoucherCostAdjustment
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try

                        Try
                            'Writes second value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - REPOST (Voucher Cost Adjustment)"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = VoucherCostAdjustment
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    ElseIf GetReceiverCost > VoucherUnitCost Then
                        'Get Receiver GL Accounts
                        Dim ReceiverCreditAccount As String = ""
                        Dim ReceiverDebitAccount As String = ""

                        'Default GL Accounts on receiver
                        'Debit = 12100
                        'Credit = 20999

                        Dim GetReceiverCreditAccountStatement As String = "SELECT CreditGLAccount FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey"
                        Dim GetReceiverCreditAccountCommand As New SqlCommand(GetReceiverCreditAccountStatement, con)
                        GetReceiverCreditAccountCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                        GetReceiverCreditAccountCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLine

                        Dim GetReceiverDebitAccountStatement As String = "SELECT DebitGlaccount FROM ReceivingLineQuery WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey"
                        Dim GetReceiverDebitAccountCommand As New SqlCommand(GetReceiverDebitAccountStatement, con)
                        GetReceiverDebitAccountCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                        GetReceiverDebitAccountCommand.Parameters.Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLine

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            ReceiverCreditAccount = CStr(GetReceiverCreditAccountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ReceiverCreditAccount = "12100"
                        End Try
                        Try
                            ReceiverDebitAccount = CStr(GetReceiverDebitAccountCommand.ExecuteScalar)
                        Catch ex As Exception
                            ReceiverDebitAccount = "20999"
                        End Try
                        con.Close()

                        'Calculate adjustment
                        VoucherCostAdjustment = (GetReceiverCost - VoucherUnitCost) * VoucherQuantity
                        VoucherCostAdjustment = Math.Round(VoucherCostAdjustment, 2)

                        Try
                            'Writes second value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverCreditAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - REPOST (Voucher Cost Adjustment)"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = VoucherCostAdjustment
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try

                        Try
                            'Writes second value to the General Ledger
                            cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                            With cmd.Parameters
                                '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                                .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ReceiverDebitAccount
                                .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - REPOST (Voucher Cost Adjustment)"
                                .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                                .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = VoucherCostAdjustment
                                .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                                .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                                .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                                .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Error checking
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "AP Voucher Reversal (Lines) --- GL Insert Failure"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    Else
                        'Do nothing
                    End If
                End If
            Next

            'Check for Voucher Sales Tax
            If Val(txtSalesTax.Text) <> 0 Then
                'Write to GL Table
                Try
                    'Writes first value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayableAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Sales Tax"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Tax) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                Try
                    'Writes second value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLTaxAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Sales Tax"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Tax) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Skip - no sales tax
            End If

            'Check for Voucher Freight
            If Val(txtFreight.Text) <> 0 Then
                'Write to GL Table
                Try
                    'Writes first value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayableAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Freight"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Freight) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                Try
                    'Writes second value to the General Ledger
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLFreightAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Freight"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Freight) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Skip - no freight
            End If

            'Save data to Header Table (reopen)
            cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Save data to Line Table (reopen)
            cmd = New SqlCommand("Update ReceiptOfInvoiceVoucherLines SET SelectForInvoice = @SelectForInvoice WHERE VoucherNumber = @VoucherNumber", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "POSTED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadStatus()

            MsgBox("Voucher has been re-posted.", MsgBoxStyle.OkOnly)
        ElseIf VoucherStatus = "OPEN" And VoucherSource = "STEEL RECEIPT" Then
            LoadPostingDateForReversal()

            'Get Line Items from the datagrid
            For Each row As DataGridViewRow In dgvVoucherLines.Rows
                Try
                    LineNumber = row.Cells("VoucherLineColumn").Value
                Catch ex As Exception
                    LineNumber = 0
                End Try
                Try
                    LineDebitAccount = row.Cells("GLDebitAccountColumn").Value
                Catch ex As Exception
                    LineDebitAccount = ""
                End Try
                Try
                    'LineCreditAccount = row.Cells("GLCreditAccountColumn").Value
                    LineCreditAccount = "20000"
                Catch ex As Exception
                    LineCreditAccount = "20000"
                End Try
                Try
                    LineExtendedAmount = row.Cells("ExtendedAmountColumn").Value
                Catch ex As Exception
                    LineExtendedAmount = ""
                End Try

                LineExtendedAmount = Round(LineExtendedAmount, 2)

                'Retotal Voucher
                ReloadTotals()
                '************************************************************************************************
                'Determine Check Type
                If cboCheckType.Text = "STANDARD" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "ACH" Then
                    'Do nothing - check type is filled
                Else
                    MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '*****************************************************************************
                If chkWhitePaper.Checked = True Then
                    WhitePaperCheck = "YES"
                Else
                    WhitePaperCheck = "NO"
                End If
                '*****************************************************************************
                'Save data to Table
                cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, VendorClass = @VendorClass, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@PONumber", SqlDbType.VarChar).Value = Val(txtPONumber.Text)
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                    .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDate.Text
                    .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDate.Text
                    .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                    .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@InvoiceAmount", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                    .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDiscountDate.Text
                    .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                    .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
                    .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
                    .Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                    .Add("@VoucherSource", SqlDbType.VarChar).Value = "STEEL RECEIPT"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                    .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                    .Add("@TempSelected", SqlDbType.VarChar).Value = ""
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = ""
                    .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaperCheck
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                VendorClass = cboVendorClass.Text

                cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey)+1, 22000001) FROM GLTransactionMasterList);" _
                                     + " Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)" _
                                     + " VALUES (@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)" _
                                     + " , (@Key+1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus); COMMIT TRAN;", con)

                With cmd.Parameters
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineDebitAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    ''CREDIT POSTING FOR GL
                    .Add("@GLAccountNumber1", SqlDbType.VarChar).Value = LineCreditAccount
                    .Add("@GLTransactionDebitAmount1", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount1", SqlDbType.VarChar).Value = LineExtendedAmount
                End With

                Try
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Lines) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                cmd = New SqlCommand("SELECT SteelExtendedCost FROM SteelReceivingLineTable WHERE SteelReceivingHeaderKey = @SteelReceivingHeaderKey AND RMID = @RMID", con)
                cmd.Parameters.Add("@SteelReceivingHeaderKey", SqlDbType.VarChar).Value = row.Cells("ReceiverNumberColumn").Value
                cmd.Parameters.Add("@RMID", SqlDbType.VarChar).Value = row.Cells("PartNumberColumn").Value
                Dim receivingExtendedCost As Double = 0.0
                If con.State = ConnectionState.Closed Then con.Open()
                receivingExtendedCost = Math.Round(cmd.ExecuteScalar(), 2)
                con.Close()
                Dim VoucherExtendedAmount As Double = row.Cells("ExtendedAmountColumn").Value

                If receivingExtendedCost <> VoucherExtendedAmount AndAlso row.Cells("ReceiverNumberColumn").Value <> 0 Then
                    'Write to Debit Side of a Voucher Cost Adjustment
                    Dim CostAdjustmentAmount As Double = Math.Round(VoucherExtendedAmount - receivingExtendedCost, 2, MidpointRounding.AwayFromZero)
                    ''checks to see if the amount is negative, if so will switch the debit, credit accounts and abs the difference
                    Dim GLCreditAccount As String = "12000"
                    Dim GLDebitAccount As String = row.Cells("GLDebitAccountColumn").Value

                    If CostAdjustmentAmount < 0 Then
                        CostAdjustmentAmount = Math.Abs(CostAdjustmentAmount)
                    Else
                        Dim tmp As String = GLCreditAccount
                        GLCreditAccount = GLDebitAccount
                        GLDebitAccount = tmp
                    End If

                    cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey) + 1, 220001) FROM GLTransactionMasterList); SET xact_abort on; Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) values", con)
                    cmd.CommandText += "(@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"

                    With cmd.Parameters
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLDebitAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Voucher Cost Adjustment(STEEL)"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = CostAdjustmentAmount
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Receiver Number " & row.Cells("ReceiverNumberColumn").Value
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = LineNumber
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If cboDivisionID.Text.Equals("TST") Then
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
                    Else
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                    End If

                    cmd.CommandText += ", (@Key + 1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)"
                    With cmd.Parameters
                        .Add("@GLAccountNumber1", SqlDbType.VarChar).Value = GLCreditAccount
                        .Add("@GLTransactionDebitAmount1", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount1", SqlDbType.VarChar).Value = CostAdjustmentAmount
                    End With
                    cmd.CommandText += "; COMMIT TRAN; SET xact_abort OFF;"
                    Try
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "APViewVoucherLines - cmdRevers_Click --Error Inserting GL DEBIT & CREDIT transaction for Steel Cost adjustment Reversal"
                        ErrorReferenceNumber = "Batch # " + txtBatchNumber.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    ''updates the cost tier for the given steel
                    cmd = New SqlCommand("UPDATE SteelCostingTable SET SteelCostPerPound = @CostPerPound WHERE ReferenceNumber = @SteelReceivingKey AND ReferenceLine = @SteelReceivingLineKey;", con)
                    cmd.Parameters.Add("@CostPerPound", SqlDbType.VarChar).Value = row.Cells("UnitCostColumn").Value
                    cmd.Parameters.Add("@SteelReceivingKey", SqlDbType.VarChar).Value = row.Cells("ReceiverNumberColumn").Value
                    cmd.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = row.Cells("ReceiverLineColumn").Value

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "APProcessBatch - updateSteelCostTier --Error updating Cost Tier"
                        ErrorReferenceNumber = "Batch # " + txtBatchNumber.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    ''updates the Steel PO Line
                    cmd = New SqlCommand("UPDATE SteelPurchaseLine SET PurchasePricePerPound = @PurchasePricePerPound, ExtendedAmount = @PurchasePricePerPound * PurchaseQuantity WHERE SteelPurchaseOrderHeaderKey = (SELECT TOP 1 PONumber FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingKey AND SteelReceivingLineKey = @SteelReceivingLineKey) AND SteelPurchaseLineNumber = (SELECT TOP 1 POLineNumber FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingKey AND SteelReceivingLineKey = @SteelReceivingLineKey);", con)
                    cmd.Parameters.Add("@PurchasePricePerPound", SqlDbType.VarChar).Value = row.Cells("UnitCostColumn").Value
                    cmd.Parameters.Add("@SteelReceivingKey", SqlDbType.VarChar).Value = row.Cells("ReceiverNumberColumn").Value
                    cmd.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = row.Cells("ReceiverLineColumn").Value

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    Dim SteelTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM SteelPurchaseLine WHERE SteelPurchaseOrderHeaderKey = (SELECT TOP 1 PONumber FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingKey AND SteelReceivingLineKey = @SteelReceivingLineKey);"
                    Dim SteelTotalCommand As New SqlCommand(SteelTotalStatement, con)
                    SteelTotalCommand.Parameters.Add("@SteelReceivingKey", SqlDbType.VarChar).Value = row.Cells("ReceiverNumberColumn").Value
                    SteelTotalCommand.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = row.Cells("ReceiverLineColumn").Value
                    Dim SteelTotal As Double = 0

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        SteelTotal = CDbl(SteelTotalCommand.ExecuteScalar)
                    Catch ex As Exception
                        SteelTotal = 0
                    End Try
                    con.Close()
                    '*******************************************************************************************
                    cmd = New SqlCommand("UPDATE SteelPurchaseOrderHeader SET SteelTotal = @SteelTotal, SteelPurchaseTotal = (FreightTotal + OtherTotal + @SteelTotal) WHERE SteelPurchaseOrderKey = (SELECT TOP 1 PONumber FROM SteelReceivingCoilLines WHERE SteelReceivingHeaderKey = @SteelReceivingKey AND SteelReceivingLineKey = @SteelReceivingLineKey);", con)

                    With cmd.Parameters
                        .Add("@SteelTotal", SqlDbType.VarChar).Value = SteelTotal
                        cmd.Parameters.Add("@SteelReceivingKey", SqlDbType.VarChar).Value = row.Cells("ReceiverNumberColumn").Value
                        cmd.Parameters.Add("@SteelReceivingLineKey", SqlDbType.VarChar).Value = row.Cells("ReceiverLineColumn").Value
                    End With

                    Try
                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        con.Close()

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "APProcessBatch - updatePOHeaderTable --Error updating Steel PO Cost Per Pound"
                        ErrorReferenceNumber = "Batch # " + txtBatchNumber.Text
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                End If
            Next

            'Check for Voucher Sales Tax
            If Val(txtSalesTax.Text) <> 0 Then
                cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey)+1, 22000001) FROM GLTransactionMasterList); Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) VALUES (@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus), (@Key+1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus);", con)
                With cmd.Parameters
                    .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayableAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Sales Tax"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    ''DEBIT POSTING FOR GL
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLTaxAccount
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtSalesTax.Text)
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                End With

                Try
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Tax) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Skip - no sales tax
            End If

            'Check for Voucher Freight
            If Val(txtFreight.Text) <> 0 Then
                cmd = New SqlCommand("BEGIN TRAN DECLARE @Key as int = (SELECT isnull(MAX(GLTransactionKey)+1, 22000001) FROM GLTransactionMasterList); Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus) VALUES (@Key, @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus), (@Key+1, @GLAccountNumber1, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount1, @GLTransactionCreditAmount1,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus);", con)
                With cmd.Parameters
                    .Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayableAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Receipt Of Invoice Posting - Freight"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = GLDate
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Number " & txtInvoiceNumber.Text
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    ''DEBIT POSTING FOR GL
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLFreightAccount
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = Val(txtFreight.Text)
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                End With

                Try
                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Error checking
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Voucher Re-Post (Freight) --- GL Insert Failure"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Skip - no freight
            End If

            'Save data to Header Table (reopen)
            cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Save data to Line Table (reopen)
            cmd = New SqlCommand("Update ReceiptOfInvoiceVoucherLines SET SelectForInvoice = @SelectForInvoice WHERE VoucherNumber = @VoucherNumber", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "POSTED"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            LoadStatus()

            MsgBox("Voucher has been re-posted.", MsgBoxStyle.OkOnly)
        Else
            MsgBox("You cannot post this voucher at this time.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub txtFreight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreight.TextChanged
        InvoiceFreight = Val(txtFreight.Text)
        InvoiceTotal = InvoiceFreight + InvoiceSalesTax + ProductTotal
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Private Sub txtSalesTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesTax.TextChanged
        InvoiceSalesTax = Val(txtSalesTax.Text)
        InvoiceTotal = InvoiceFreight + InvoiceSalesTax + ProductTotal
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Private Sub cboPaymentTerms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentTerms.SelectedIndexChanged
        If IsLoaded = True Then
            'Do nothing
        Else
            LoadPaymentTermDetails()
            CalculateDiscount()
        End If
    End Sub

    Private Sub dtpInvoiceDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpInvoiceDate.ValueChanged
        If IsLoaded = True Then
            'Do nothing
        Else
            LoadPaymentTermDetails()
            CalculateDiscount()
        End If
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Private Sub cboVoucherNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVoucherNumber.SelectedIndexChanged
        LoadStatus()
        ShowAllData()
        LoadVoucherData()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        LoadVoucherNumber()
        LoadVendor()
        LoadVendorClass()
    End Sub

    Private Sub cmdClearForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearForm.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        UnLockCertainControls()
    End Sub

    Private Sub ClearFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFormToolStripMenuItem.Click
        cmdClearForm_Click(sender, e)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number and Invoice Number.", MsgBoxStyle.OkOnly)
            Exit Sub
            cboVoucherNumber.Focus()
        End If
        '**************************************************************************************************
        'Verify Unique Invoice Number
        VerifyUniqueInvoiceNumber()

        If UniqueInvoice = "NO" Then

            MsgBox("This Invoice Number has already been used.", MsgBoxStyle.OkOnly)
            Exit Sub
            txtInvoiceNumber.Focus()
        End If
        '**************************************************************************************
        'Validate dates
        ValidateDates()

        If CheckAndValidateDates = "NOT OKAY" Then
            Dim button As DialogResult = MessageBox.Show("One of your dates is more than 90 days out. Do you wish to continue?", "DATE 90 DAYS OR OVER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Do nothing and continue
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        Else
            'Do nothing
        End If
        '**************************************************************************************        'Check to see if Voucher is already posted
        VoucherStatus = lblVoucherStatus.Text

        If VoucherStatus = "POSTED" Then
            Dim GetPostDate As Date

            'Check if Receipt Date is the sames as the Post Date
            Dim GetPostDateStatement As String = "SELECT MIN(GLTransactionDate) FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID"
            Dim GetPostDateCommand As New SqlCommand(GetPostDateStatement, con)
            GetPostDateCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
            GetPostDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetPostDate = CDate(GetPostDateCommand.ExecuteScalar)
            Catch ex As Exception
                GetPostDate = Today.ToShortDateString()
            End Try
            con.Close()

            If GetPostDate <> dtpReceiptDate.Value And chkChangePostDate.Checked = True Then
                Dim button As DialogResult = MessageBox.Show("Do you wish to update the voucher and post date to the receipt date?", "UPDATE DATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then

                    cmd = New SqlCommand("Update GLTransactionMasterList SET GLTransactionDate = @GLTransactionDate WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpReceiptDate.Value
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf button = DialogResult.Yes Then
                    'Post Date will not change
                End If
            Else
                'Do nothing
            End If
            '************************************************************************************************
            'Determine Check Type
            If cboCheckType.Text = "STANDARD" Or cboCheckType.Text = "FEDEX" Or cboCheckType.Text = "INTERCOMPANY" Or cboCheckType.Text = "ACH" Then
                'Do nothing - check type is filled
            Else
                MsgBox("You must select a valid check type.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '*****************************************************************************
            If chkWhitePaper.Checked = True Then
                WhitePaperCheck = "YES"
            Else
                WhitePaperCheck = "NO"
            End If
            '*****************************************************************************
            'Save data to Table
            cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET DueDate = @DueDate, DiscountDate = @DiscountDate, Comment = @Comment, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, PaymentTerms = @PaymentTerms, DiscountAmount = @DiscountAmount, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDate.Text
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDate.Text
                .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
                .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDiscountDate.Text
                .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                .Add("@TempSelected", SqlDbType.VarChar).Value = ""
                .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = ""
                .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaperCheck
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)
        ElseIf VoucherStatus = "OPEN" And VoucherSource = "VOUCHER RECEIPT" Then
            ReloadTotals()
            '*****************************************************************************
            'Determine Check Type
            If chkWhitePaper.Checked = True Then
                WhitePaperCheck = "YES"
            Else
                WhitePaperCheck = "NO"
            End If
            '*****************************************************************************
            'Save data to Table
            cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, VendorClass = @VendorClass, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                .Add("@PONumber", SqlDbType.VarChar).Value = Val(txtPONumber.Text)
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDate.Text
                .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDate.Text
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                .Add("@InvoiceAmount", SqlDbType.VarChar).Value = InvoiceTotal
                .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDiscountDate.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
                .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
                .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@VoucherSource", SqlDbType.VarChar).Value = "VOUCHER RECEIPT"
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                .Add("@TempSelected", SqlDbType.VarChar).Value = ""
                .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = ""
                .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaperCheck
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)
        ElseIf VoucherStatus = "OPEN" And VoucherSource = "PO RECEIPT" Then
            ReloadTotals()
            '*****************************************************************************
            'Determine Check Type
            If chkWhitePaper.Checked = True Then
                WhitePaperCheck = "YES"
            Else
                WhitePaperCheck = "NO"
            End If
            '*****************************************************************************
            'Save data to Table
            cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, VendorClass = @VendorClass, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                .Add("@PONumber", SqlDbType.VarChar).Value = Val(txtPONumber.Text)
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDate.Text
                .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDate.Text
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                .Add("@InvoiceAmount", SqlDbType.VarChar).Value = InvoiceTotal
                .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                .Add("@DiscountDate", SqlDbType.VarChar).Value = CheckDiscountDate
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
                .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
                .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@VoucherSource", SqlDbType.VarChar).Value = "PO RECEIPT"
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                .Add("@TempSelected", SqlDbType.VarChar).Value = ""
                .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = ""
                .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaperCheck
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)
        ElseIf VoucherStatus = "OPEN" And VoucherSource = "STEEL RECEIPT" Then
            ReloadTotals()
            '*****************************************************************************
            'Determine Check Type
            If chkWhitePaper.Checked = True Then
                WhitePaperCheck = "YES"
            Else
                WhitePaperCheck = "NO"
            End If
            '*****************************************************************************
            'Save data to Table
            cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, VendorClass = @VendorClass, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                .Add("@PONumber", SqlDbType.VarChar).Value = Val(txtPONumber.Text)
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDate.Text
                .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDate.Text
                .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                .Add("@InvoiceAmount", SqlDbType.VarChar).Value = InvoiceTotal
                .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDiscountDate.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
                .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
                .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@VoucherSource", SqlDbType.VarChar).Value = "STEEL RECEIPT"
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                .Add("@TempSelected", SqlDbType.VarChar).Value = ""
                .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = ""
                .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaperCheck
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)
        Else
            'No changes can be made
            MsgBox("This Voucher is closed for editing.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub SaveVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveVoucherToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboVoucherNumber.Text = "" Or txtInvoiceNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number and Invoice Number.", MsgBoxStyle.OkOnly)
            cboVoucherNumber.Focus()
        Else
            'Verify Unique Invoice Number
            VerifyUniqueInvoiceNumber()

            If UniqueInvoice = "YES" Then
                If VoucherStatus = "POSTED" Then
                    '*****************************************************************************
                    'Determine Check Type
                    If chkWhitePaper.Checked = True Then
                        WhitePaperCheck = "YES"
                    Else
                        WhitePaperCheck = "NO"
                    End If
                    '*****************************************************************************
                    'Save data to Table
                    cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET DueDate = @DueDate, DiscountDate = @DiscountDate, Comment = @Comment, InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, PaymentTerms = @PaymentTerms, VendorClass = @VendorClass, DiscountAmount = @DiscountAmount, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDate.Text
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                        .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDate.Text
                        .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                        .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
                        .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDiscountDate.Text
                        .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                        .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
                        .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                        .Add("@TempSelected", SqlDbType.VarChar).Value = ""
                        .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = ""
                        .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaperCheck
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)
                ElseIf VoucherStatus = "OPEN" And VoucherSource = "VOUCHER RECEIPT" Then
                    ReloadTotals()
                    '*****************************************************************************
                    'Determine Check Type
                    If chkWhitePaper.Checked = True Then
                        WhitePaperCheck = "YES"
                    Else
                        WhitePaperCheck = "NO"
                    End If
                    '*****************************************************************************
                    'Save data to Table
                    cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, VendorClass = @VendorClass, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@PONumber", SqlDbType.VarChar).Value = Val(txtPONumber.Text)
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDate.Text
                        .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDate.Text
                        .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                        .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                        .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                        .Add("@InvoiceAmount", SqlDbType.VarChar).Value = InvoiceTotal
                        .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                        .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDiscountDate.Text
                        .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                        .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
                        .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
                        .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@VoucherSource", SqlDbType.VarChar).Value = "PO RECEIPT"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                        .Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
                        .Add("@TempSelected", SqlDbType.VarChar).Value = ""
                        .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = ""
                        .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaperCheck
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)

                    GlobalVoucherNumber = Val(cboVoucherNumber.Text)
                    Using NewPrintVoucher As New PrintVoucher
                        Dim result = NewPrintVoucher.ShowDialog()
                    End Using
                ElseIf VoucherStatus = "OPEN" And VoucherSource = "PO RECEIPT" Then
                    ReloadTotals()
                    '*****************************************************************************
                    'Determine Check Type
                    If chkWhitePaper.Checked = True Then
                        CheckType = "WHITE PAPER CHECK"
                    Else
                        CheckType = ""
                    End If
                    '*****************************************************************************
                    'Save data to Table
                    cmd = New SqlCommand("Update ReceiptOfInvoiceBatchLine SET InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, VendorID = @VendorID, ProductTotal = @ProductTotal, InvoiceFreight = @InvoiceFreight, InvoiceSalesTax = @InvoiceSalesTax, InvoiceTotal = @InvoiceTotal, InvoiceAmount = @InvoiceAmount, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount, VoucherStatus = @VoucherStatus, VoucherSource = @VoucherSource, VendorClass = @VendorClass, CheckType = @CheckType, TempSelected = @TempSelected, SelectedInDatagrid = @SelectedInDatagrid, WhitePaper = @WhitePaper WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                        .Add("@PONumber", SqlDbType.VarChar).Value = Val(txtPONumber.Text)
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = txtInvoiceNumber.Text
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = dtpInvoiceDate.Text
                        .Add("@ReceiptDate", SqlDbType.VarChar).Value = dtpReceiptDate.Text
                        .Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                        .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                        .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                        .Add("@InvoiceAmount", SqlDbType.VarChar).Value = InvoiceTotal
                        .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                        .Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDiscountDate.Text
                        .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                        .Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
                        .Add("@DiscountAmount", SqlDbType.VarChar).Value = Val(txtDiscountAmount.Text)
                        .Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@VoucherSource", SqlDbType.VarChar).Value = "PO RECEIPT"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
                        .Add("@CheckType", SqlDbType.VarChar).Value = CheckType
                        .Add("@TempSelected", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = cboVendorClass.Text
                        .Add("@WhitePaper", SqlDbType.VarChar).Value = CheckType
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)

                    GlobalVoucherNumber = Val(cboVoucherNumber.Text)
                    Using NewPrintVoucher As New PrintVoucher
                        Dim result = NewPrintVoucher.ShowDialog()
                    End Using
                Else
                    GlobalVoucherNumber = Val(cboVoucherNumber.Text)
                    Using NewPrintVoucher As New PrintVoucher
                        Dim result = NewPrintVoucher.ShowDialog()
                    End Using
                End If
            Else
                MsgBox("This Invoice Number has already been used.", MsgBoxStyle.OkOnly)
                txtInvoiceNumber.Focus()
            End If
        End If
    End Sub

    Private Sub PrintVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintVoucherToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If cboVoucherNumber.Text = "" Then
            MsgBox("You must have a valid Voucher Number selected.", MsgBoxStyle.OkOnly)
        Else
            If (VoucherStatus = "OPEN" Or VoucherStatus = "PENDING") And VoucherSource = "VOUCHER RECEIPT" Then
                'Prompt before reversing
                Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Voucher?", "DELETE VOUCHER", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    '***********************************************************************************************************************
                    'Write To Audit Trail on a reversal
                    Dim AuditComment As String = ""
                    Dim AuditVoucherNumber As Integer = 0
                    Dim strAuditVoucherNumber As String = ""

                    AuditVoucherNumber = Val(cboVoucherNumber.Text)
                    strAuditVoucherNumber = CStr(AuditVoucherNumber)
                    AuditComment = "Voucher #" + strAuditVoucherNumber + " was deleted on " + TodaysDate

                    Try
                        cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@AuditDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@AuditType", SqlDbType.VarChar).Value = "Edit Voucher - DELETION"
                            .Add("@AuditAmount", SqlDbType.VarChar).Value = Val(txtInvoiceTotal.Text)
                            .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strAuditVoucherNumber
                            .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception

                    End Try
                    '********************************************************************************************************************
                    'Write to Voucher Deletion Table before deleting the voucher
                    '*******************************************************************************************************
                    'Get Voucher Header Data to copy to delete table
                    Dim ROIPONumber, ROIBatchNumber, ROIDeleteReferenceNumber As Integer
                    Dim ROIProductTotal, ROIInvoiceTotal, ROIInvoiceFreight, ROIInvoiceSalesTax, ROIInvoiceAmount, ROIDiscountAmount As Double
                    Dim ROIInvoiceNumber, ROIInvoiceDate, ROIReceiptDate, ROIVendorID, ROIVendorClass, ROIPaymentTerms, ROIDiscountDate, ROIComment, ROIDueDate, ROIVoucherStatus, ROIVoucherSource As String

                    Dim DeleteHeaderDataString As String = "SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                    Dim DeleteHeaderDataCommand As New SqlCommand(DeleteHeaderDataString, con)
                    DeleteHeaderDataCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    DeleteHeaderDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim reader As SqlDataReader = DeleteHeaderDataCommand.ExecuteReader()
                    If reader.HasRows Then
                        reader.Read()
                        If IsDBNull(reader.Item("BatchNumber")) Then
                            ROIBatchNumber = 0
                        Else
                            ROIBatchNumber = reader.Item("BatchNumber")
                        End If
                        If IsDBNull(reader.Item("PONumber")) Then
                            ROIPONumber = 0
                        Else
                            ROIPONumber = reader.Item("PONumber")
                        End If
                        If IsDBNull(reader.Item("InvoiceNumber")) Then
                            ROIInvoiceNumber = ""
                        Else
                            ROIInvoiceNumber = reader.Item("InvoiceNumber")
                        End If
                        If IsDBNull(reader.Item("InvoiceDate")) Then
                            ROIInvoiceDate = ""
                        Else
                            ROIInvoiceDate = reader.Item("InvoiceDate")
                        End If
                        If IsDBNull(reader.Item("ReceiptDate")) Then
                            ROIReceiptDate = ""
                        Else
                            ROIReceiptDate = reader.Item("ReceiptDate")
                        End If
                        If IsDBNull(reader.Item("VendorID")) Then
                            ROIVendorID = ""
                        Else
                            ROIVendorID = reader.Item("VendorID")
                        End If
                        If IsDBNull(reader.Item("VendorClass")) Then
                            ROIVendorClass = 0
                        Else
                            ROIVendorClass = reader.Item("VendorClass")
                        End If
                        If IsDBNull(reader.Item("ProductTotal")) Then
                            ROIProductTotal = 0
                        Else
                            ROIProductTotal = reader.Item("ProductTotal")
                        End If
                        If IsDBNull(reader.Item("InvoiceFreight")) Then
                            ROIInvoiceFreight = 0
                        Else
                            ROIInvoiceFreight = reader.Item("InvoiceFreight")
                        End If
                        If IsDBNull(reader.Item("InvoiceSalesTax")) Then
                            ROIInvoiceSalesTax = 0
                        Else
                            ROIInvoiceSalesTax = reader.Item("InvoiceSalesTax")
                        End If
                        If IsDBNull(reader.Item("InvoiceTotal")) Then
                            ROIInvoiceTotal = 0
                        Else
                            ROIInvoiceTotal = reader.Item("InvoiceTotal")
                        End If
                        If IsDBNull(reader.Item("InvoiceAmount")) Then
                            ROIInvoiceAmount = 0
                        Else
                            ROIInvoiceAmount = reader.Item("InvoiceAmount")
                        End If
                        If IsDBNull(reader.Item("PaymentTerms")) Then
                            ROIPaymentTerms = "N30"
                        Else
                            ROIPaymentTerms = reader.Item("PaymentTerms")
                        End If
                        If IsDBNull(reader.Item("DiscountDate")) Then
                            ROIDiscountDate = ""
                        Else
                            ROIDiscountDate = reader.Item("DiscountDate")
                        End If
                        If IsDBNull(reader.Item("Comment")) Then
                            ROIComment = ""
                        Else
                            ROIComment = reader.Item("Comment")
                        End If
                        If IsDBNull(reader.Item("DueDate")) Then
                            ROIDueDate = ""
                        Else
                            ROIDueDate = reader.Item("DueDate")
                        End If
                        If IsDBNull(reader.Item("DiscountAmount")) Then
                            ROIDiscountAmount = 0
                        Else
                            ROIDiscountAmount = reader.Item("DiscountAmount")
                        End If
                        If IsDBNull(reader.Item("VoucherStatus")) Then
                            ROIVoucherStatus = "POSTED"
                        Else
                            ROIVoucherStatus = reader.Item("VoucherStatus")
                        End If
                        If IsDBNull(reader.Item("VoucherSource")) Then
                            ROIVoucherSource = ""
                        Else
                            ROIVoucherSource = reader.Item("VoucherSource")
                        End If
                        If IsDBNull(reader.Item("DeleteReferenceNumber")) Then
                            ROIDeleteReferenceNumber = 0
                        Else
                            ROIDeleteReferenceNumber = reader.Item("DeleteReferenceNumber")
                        End If
                    Else
                        ROIBatchNumber = 0
                        ROIComment = ""
                        ROIDeleteReferenceNumber = 0
                        ROIDiscountAmount = 0
                        ROIDiscountDate = ""
                        ROIDueDate = ""
                        ROIInvoiceAmount = 0
                        ROIInvoiceDate = ""
                        ROIInvoiceFreight = 0
                        ROIInvoiceNumber = ""
                        ROIInvoiceSalesTax = 0
                        ROIInvoiceTotal = 0
                        ROIPaymentTerms = "N30"
                        ROIPONumber = 0
                        ROIProductTotal = 0
                        ROIReceiptDate = ""
                        ROIVendorClass = ""
                        ROIVendorID = ""
                        ROIVoucherSource = ""
                        ROIVoucherStatus = ""
                    End If
                    reader.Close()
                    con.Close()
                    '******************************************************************************************************
                    Try
                        'Insert into Delete Header Table
                        cmd = New SqlCommand("Insert Into DeleteVoucherHeaderTable(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, VendorClass, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, InvoiceAmount, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, DeleteReferenceNumber)Values(@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @VendorID, @VendorClass, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @InvoiceAmount, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @DeleteReferenceNumber)", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = ROIBatchNumber
                            .Add("@PONumber", SqlDbType.VarChar).Value = ROIPONumber
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = ROIInvoiceNumber
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = ROIInvoiceDate
                            .Add("@ReceiptDate", SqlDbType.VarChar).Value = ROIReceiptDate
                            .Add("@VendorID", SqlDbType.VarChar).Value = ROIVendorID
                            .Add("@VendorClass", SqlDbType.VarChar).Value = ROIVendorClass
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = ROIProductTotal
                            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = ROIInvoiceFreight
                            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = ROIInvoiceSalesTax
                            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = ROIInvoiceTotal
                            .Add("@InvoiceAmount", SqlDbType.VarChar).Value = ROIInvoiceAmount
                            .Add("@PaymentTerms", SqlDbType.VarChar).Value = ROIPaymentTerms
                            .Add("@DiscountDate", SqlDbType.VarChar).Value = ROIDiscountDate
                            .Add("@Comment", SqlDbType.VarChar).Value = ROIComment
                            .Add("@DueDate", SqlDbType.VarChar).Value = ROIDueDate
                            .Add("@DiscountAmount", SqlDbType.VarChar).Value = ROIDiscountAmount
                            .Add("@VoucherStatus", SqlDbType.VarChar).Value = ROIVoucherStatus
                            .Add("@VoucherSource", SqlDbType.VarChar).Value = ROIVoucherSource
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = ROIDeleteReferenceNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempVoucherNumber As Integer = 0
                        Dim strVoucherNumber As String = ""
                        TempVoucherNumber = Val(cboVoucherNumber.Text)
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Edit Voucher --- Error creating Deleted Voucher Header"
                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '*************************************************************************************************
                    'Count Voucher Lines
                    Dim CountVoucherLines As Integer = 0

                    Dim CountVoucherLinesStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                    Dim CountVoucherLinesCommand As New SqlCommand(CountVoucherLinesStatement, con)
                    CountVoucherLinesCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    CountVoucherLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CountVoucherLines = CInt(CountVoucherLinesCommand.ExecuteScalar)
                    Catch ex As Exception
                        CountVoucherLines = 0
                    End Try
                    con.Close()

                    'Insert Lines into Delete Table
                    Dim ROIPartNumber, ROIPartDescription, ROIGLDebitAccount, ROIGLCreditAccount, ROISelectForInvoice As String
                    Dim ROIQuantity, ROIUnitCost, ROIExtendedAmount As Double
                    Dim ROIReceiverNumber, ROIReceiverLine, ROIVoucherLine As Integer

                    ROIVoucherLine = 1

                    For i As Integer = 1 To CountVoucherLines
                        Dim GetLineDataString As String = "SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                        Dim GetLineDataCommand As New SqlCommand(GetLineDataString, con)
                        GetLineDataCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        GetLineDataCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = ROIVoucherLine

                        If con.State = ConnectionState.Closed Then con.Open()
                        Dim LineReader As SqlDataReader = GetLineDataCommand.ExecuteReader()
                        If LineReader.HasRows Then
                            LineReader.Read()
                            If IsDBNull(LineReader.Item("PartNumber")) Then
                                ROIPartNumber = ""
                            Else
                                ROIPartNumber = LineReader.Item("PartNumber")
                            End If
                            If IsDBNull(LineReader.Item("PartDescription")) Then
                                ROIPartDescription = ""
                            Else
                                ROIPartDescription = LineReader.Item("PartDescription")
                            End If
                            If IsDBNull(LineReader.Item("Quantity")) Then
                                ROIQuantity = 0
                            Else
                                ROIQuantity = LineReader.Item("Quantity")
                            End If
                            If IsDBNull(LineReader.Item("UnitCost")) Then
                                ROIUnitCost = 0
                            Else
                                ROIUnitCost = LineReader.Item("UnitCost")
                            End If
                            If IsDBNull(LineReader.Item("ExtendedAmount")) Then
                                ROIExtendedAmount = 0
                            Else
                                ROIExtendedAmount = LineReader.Item("ExtendedAmount")
                            End If
                            If IsDBNull(LineReader.Item("GLDebitAccount")) Then
                                ROIGLDebitAccount = ""
                            Else
                                ROIGLDebitAccount = LineReader.Item("GLDebitAccount")
                            End If
                            If IsDBNull(LineReader.Item("GLCreditAccount")) Then
                                ROIGLCreditAccount = ""
                            Else
                                ROIGLCreditAccount = LineReader.Item("GLCreditAccount")
                            End If
                            If IsDBNull(LineReader.Item("SelectForInvoice")) Then
                                ROISelectForInvoice = ""
                            Else
                                ROISelectForInvoice = LineReader.Item("SelectForInvoice")
                            End If
                            If IsDBNull(LineReader.Item("ReceiverNumber")) Then
                                ROIReceiverNumber = 0
                            Else
                                ROIReceiverNumber = LineReader.Item("ReceiverNumber")
                            End If
                            If IsDBNull(LineReader.Item("ReceiverLine")) Then
                                ROIReceiverLine = 0
                            Else
                                ROIReceiverLine = LineReader.Item("ReceiverLine")
                            End If
                        Else
                            ROIPartNumber = ""
                            ROIPartDescription = ""
                            ROIQuantity = 0
                            ROIUnitCost = 0
                            ROIExtendedAmount = 0
                            ROIGLDebitAccount = ""
                            ROIGLCreditAccount = ""
                            ROISelectForInvoice = ""
                            ROIReceiverNumber = 0
                            ROIReceiverLine = 0
                        End If
                        LineReader.Close()
                        con.Close()
                        '******************************************************************************************************************
                        Try
                            'Insert into Delete Header Table
                            cmd = New SqlCommand("Insert Into DeleteVoucherLineTable(VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice, ReceiverNumber, ReceiverLine, DivisionID)Values(@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, @SelectForInvoice, @ReceiverNumber, @ReceiverLine, @DivisionID)", con)

                            With cmd.Parameters
                                .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                                .Add("@VoucherLine", SqlDbType.VarChar).Value = ROIVoucherLine
                                .Add("@PartNumber", SqlDbType.VarChar).Value = ROIPartNumber
                                .Add("@PartDescription", SqlDbType.VarChar).Value = ROIPartDescription
                                .Add("@Quantity", SqlDbType.VarChar).Value = ROIQuantity
                                .Add("@UnitCost", SqlDbType.VarChar).Value = ROIUnitCost
                                .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ROIExtendedAmount
                                .Add("@GLDebitAccount", SqlDbType.VarChar).Value = ROIGLDebitAccount
                                .Add("@GLCreditAccount", SqlDbType.VarChar).Value = ROIGLCreditAccount
                                .Add("@SelectForInvoice", SqlDbType.VarChar).Value = ROISelectForInvoice
                                .Add("@ReceiverNumber", SqlDbType.VarChar).Value = ROIReceiverNumber
                                .Add("@ReceiverLine", SqlDbType.VarChar).Value = ROIReceiverLine
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex As Exception
                            'Log error on update failure
                            Dim TempVoucherNumber As Integer = 0
                            Dim strVoucherNumber As String = ""
                            TempVoucherNumber = Val(cboVoucherNumber.Text)
                            strVoucherNumber = CStr(TempVoucherNumber)

                            ErrorDate = TodaysDate
                            ErrorComment = ex.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Edit Voucher --- Error creating Deleted Voucher Line"
                            ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try

                        'Clear Variable before next loop
                        ROIPartNumber = ""
                        ROIPartDescription = ""
                        ROIQuantity = 0
                        ROIUnitCost = 0
                        ROIExtendedAmount = 0
                        ROIGLDebitAccount = ""
                        ROIGLCreditAccount = ""
                        ROISelectForInvoice = ""
                        ROIReceiverNumber = 0
                        ROIReceiverLine = 0

                        ROIVoucherLine = ROIVoucherLine + 1
                    Next i
                    '***********************************************************************************************************************
                    'Delete voucher
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    LoadVoucherNumber()
                    ClearVariables()
                    ClearData()
                    ShowAllData()
                    MsgBox("Voucher has been deleted.", MsgBoxStyle.OkOnly)
                ElseIf button = DialogResult.No Then
                    cmdDelete.Focus()
                End If
            ElseIf (VoucherStatus = "OPEN" Or VoucherStatus = "PENDING") And VoucherSource = "PO RECEIPT" Then
                'Reset Receiver to be selected again for processing
                Dim VoucherBatchNumber As Integer = Val(txtBatchNumber.Text)
                Dim SUMVouchersInBatch As Double = 0
                Dim LineReceiverNumber, LineReceiverLine As Integer

                For Each row As DataGridViewRow In dgvVoucherLines.Rows
                    Try
                        LineReceiverNumber = row.Cells("ReceiverNumberColumn").Value
                    Catch ex As Exception
                        LineReceiverNumber = 0
                    End Try
                    Try
                        LineReceiverLine = row.Cells("ReceiverLineColumn").Value
                    Catch ex As Exception
                        LineReceiverLine = 0
                    End Try

                    If LineReceiverLine = 0 Or LineReceiverNumber = 0 Then
                        'Skip
                    Else
                        'Update Receiver Line Table
                        cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND ReceivingLineKey = @ReceivingLineKey AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLine
                            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Update Receiver Header Table
                        cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                    End If
                Next
                '***********************************************************************************************************************
                'Write To Audit Trail on a reversal
                Dim AuditComment As String = ""
                Dim AuditVoucherNumber As Integer = 0
                Dim strAuditVoucherNumber As String = ""

                AuditVoucherNumber = Val(cboVoucherNumber.Text)
                strAuditVoucherNumber = CStr(AuditVoucherNumber)
                AuditComment = "Voucher #" + strAuditVoucherNumber + " was deleted on " + TodaysDate

                Try
                    cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@AuditDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@AuditType", SqlDbType.VarChar).Value = "Edit Voucher - DELETION"
                        .Add("@AuditAmount", SqlDbType.VarChar).Value = Val(txtInvoiceTotal.Text)
                        .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strAuditVoucherNumber
                        .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception

                End Try
                '********************************************************************************************************************
                'Write to Voucher Deletion Table before deleting the voucher
                '*******************************************************************************************************
                'Get Voucher Header Data to copy to delete table
                Dim ROIPONumber, ROIBatchNumber, ROIDeleteReferenceNumber As Integer
                Dim ROIProductTotal, ROIInvoiceTotal, ROIInvoiceFreight, ROIInvoiceSalesTax, ROIInvoiceAmount, ROIDiscountAmount As Double
                Dim ROIInvoiceNumber, ROIInvoiceDate, ROIReceiptDate, ROIVendorID, ROIVendorClass, ROIPaymentTerms, ROIDiscountDate, ROIComment, ROIDueDate, ROIVoucherStatus, ROIVoucherSource As String

                Dim DeleteHeaderDataString As String = "SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim DeleteHeaderDataCommand As New SqlCommand(DeleteHeaderDataString, con)
                DeleteHeaderDataCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                DeleteHeaderDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = DeleteHeaderDataCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("BatchNumber")) Then
                        ROIBatchNumber = 0
                    Else
                        ROIBatchNumber = reader.Item("BatchNumber")
                    End If
                    If IsDBNull(reader.Item("PONumber")) Then
                        ROIPONumber = 0
                    Else
                        ROIPONumber = reader.Item("PONumber")
                    End If
                    If IsDBNull(reader.Item("InvoiceNumber")) Then
                        ROIInvoiceNumber = ""
                    Else
                        ROIInvoiceNumber = reader.Item("InvoiceNumber")
                    End If
                    If IsDBNull(reader.Item("InvoiceDate")) Then
                        ROIInvoiceDate = ""
                    Else
                        ROIInvoiceDate = reader.Item("InvoiceDate")
                    End If
                    If IsDBNull(reader.Item("ReceiptDate")) Then
                        ROIReceiptDate = ""
                    Else
                        ROIReceiptDate = reader.Item("ReceiptDate")
                    End If
                    If IsDBNull(reader.Item("VendorID")) Then
                        ROIVendorID = ""
                    Else
                        ROIVendorID = reader.Item("VendorID")
                    End If
                    If IsDBNull(reader.Item("VendorClass")) Then
                        ROIVendorClass = 0
                    Else
                        ROIVendorClass = reader.Item("VendorClass")
                    End If
                    If IsDBNull(reader.Item("ProductTotal")) Then
                        ROIProductTotal = 0
                    Else
                        ROIProductTotal = reader.Item("ProductTotal")
                    End If
                    If IsDBNull(reader.Item("InvoiceFreight")) Then
                        ROIInvoiceFreight = 0
                    Else
                        ROIInvoiceFreight = reader.Item("InvoiceFreight")
                    End If
                    If IsDBNull(reader.Item("InvoiceSalesTax")) Then
                        ROIInvoiceSalesTax = 0
                    Else
                        ROIInvoiceSalesTax = reader.Item("InvoiceSalesTax")
                    End If
                    If IsDBNull(reader.Item("InvoiceTotal")) Then
                        ROIInvoiceTotal = 0
                    Else
                        ROIInvoiceTotal = reader.Item("InvoiceTotal")
                    End If
                    If IsDBNull(reader.Item("InvoiceAmount")) Then
                        ROIInvoiceAmount = 0
                    Else
                        ROIInvoiceAmount = reader.Item("InvoiceAmount")
                    End If
                    If IsDBNull(reader.Item("PaymentTerms")) Then
                        ROIPaymentTerms = "N30"
                    Else
                        ROIPaymentTerms = reader.Item("PaymentTerms")
                    End If
                    If IsDBNull(reader.Item("DiscountDate")) Then
                        ROIDiscountDate = ""
                    Else
                        ROIDiscountDate = reader.Item("DiscountDate")
                    End If
                    If IsDBNull(reader.Item("Comment")) Then
                        ROIComment = ""
                    Else
                        ROIComment = reader.Item("Comment")
                    End If
                    If IsDBNull(reader.Item("DueDate")) Then
                        ROIDueDate = ""
                    Else
                        ROIDueDate = reader.Item("DueDate")
                    End If
                    If IsDBNull(reader.Item("DiscountAmount")) Then
                        ROIDiscountAmount = 0
                    Else
                        ROIDiscountAmount = reader.Item("DiscountAmount")
                    End If
                    If IsDBNull(reader.Item("VoucherStatus")) Then
                        ROIVoucherStatus = "POSTED"
                    Else
                        ROIVoucherStatus = reader.Item("VoucherStatus")
                    End If
                    If IsDBNull(reader.Item("VoucherSource")) Then
                        ROIVoucherSource = ""
                    Else
                        ROIVoucherSource = reader.Item("VoucherSource")
                    End If
                    If IsDBNull(reader.Item("DeleteReferenceNumber")) Then
                        ROIDeleteReferenceNumber = 0
                    Else
                        ROIDeleteReferenceNumber = reader.Item("DeleteReferenceNumber")
                    End If
                Else
                    ROIBatchNumber = 0
                    ROIComment = ""
                    ROIDeleteReferenceNumber = 0
                    ROIDiscountAmount = 0
                    ROIDiscountDate = ""
                    ROIDueDate = ""
                    ROIInvoiceAmount = 0
                    ROIInvoiceDate = ""
                    ROIInvoiceFreight = 0
                    ROIInvoiceNumber = ""
                    ROIInvoiceSalesTax = 0
                    ROIInvoiceTotal = 0
                    ROIPaymentTerms = "N30"
                    ROIPONumber = 0
                    ROIProductTotal = 0
                    ROIReceiptDate = ""
                    ROIVendorClass = ""
                    ROIVendorID = ""
                    ROIVoucherSource = ""
                    ROIVoucherStatus = ""
                End If
                reader.Close()
                con.Close()
                '******************************************************************************************************
                Try
                    'Insert into Delete Header Table
                    cmd = New SqlCommand("Insert Into DeleteVoucherHeaderTable(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, VendorClass, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, InvoiceAmount, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, DeleteReferenceNumber)Values(@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @VendorID, @VendorClass, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @InvoiceAmount, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @DeleteReferenceNumber)", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = ROIBatchNumber
                        .Add("@PONumber", SqlDbType.VarChar).Value = ROIPONumber
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = ROIInvoiceNumber
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = ROIInvoiceDate
                        .Add("@ReceiptDate", SqlDbType.VarChar).Value = ROIReceiptDate
                        .Add("@VendorID", SqlDbType.VarChar).Value = ROIVendorID
                        .Add("@VendorClass", SqlDbType.VarChar).Value = ROIVendorClass
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ROIProductTotal
                        .Add("@InvoiceFreight", SqlDbType.VarChar).Value = ROIInvoiceFreight
                        .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = ROIInvoiceSalesTax
                        .Add("@InvoiceTotal", SqlDbType.VarChar).Value = ROIInvoiceTotal
                        .Add("@InvoiceAmount", SqlDbType.VarChar).Value = ROIInvoiceAmount
                        .Add("@PaymentTerms", SqlDbType.VarChar).Value = ROIPaymentTerms
                        .Add("@DiscountDate", SqlDbType.VarChar).Value = ROIDiscountDate
                        .Add("@Comment", SqlDbType.VarChar).Value = ROIComment
                        .Add("@DueDate", SqlDbType.VarChar).Value = ROIDueDate
                        .Add("@DiscountAmount", SqlDbType.VarChar).Value = ROIDiscountAmount
                        .Add("@VoucherStatus", SqlDbType.VarChar).Value = ROIVoucherStatus
                        .Add("@VoucherSource", SqlDbType.VarChar).Value = ROIVoucherSource
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = ROIDeleteReferenceNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                Catch ex As Exception
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String = ""
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Edit Voucher --- Error creating Deleted Voucher Header"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*************************************************************************************************
                'Count Voucher Lines
                Dim CountVoucherLines As Integer = 0

                Dim CountVoucherLinesStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim CountVoucherLinesCommand As New SqlCommand(CountVoucherLinesStatement, con)
                CountVoucherLinesCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                CountVoucherLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountVoucherLines = CInt(CountVoucherLinesCommand.ExecuteScalar)
                Catch ex As Exception
                    CountVoucherLines = 0
                End Try
                con.Close()

                'Insert Lines into Delete Table
                Dim ROIPartNumber, ROIPartDescription, ROIGLDebitAccount, ROIGLCreditAccount, ROISelectForInvoice As String
                Dim ROIQuantity, ROIUnitCost, ROIExtendedAmount As Double
                Dim ROIReceiverNumber, ROIReceiverLine, ROIVoucherLine As Integer

                ROIVoucherLine = 1

                For i As Integer = 1 To CountVoucherLines
                    Dim GetLineDataString As String = "SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                    Dim GetLineDataCommand As New SqlCommand(GetLineDataString, con)
                    GetLineDataCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    GetLineDataCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = ROIVoucherLine

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim LineReader As SqlDataReader = GetLineDataCommand.ExecuteReader()
                    If LineReader.HasRows Then
                        LineReader.Read()
                        If IsDBNull(LineReader.Item("PartNumber")) Then
                            ROIPartNumber = ""
                        Else
                            ROIPartNumber = LineReader.Item("PartNumber")
                        End If
                        If IsDBNull(LineReader.Item("PartDescription")) Then
                            ROIPartDescription = ""
                        Else
                            ROIPartDescription = LineReader.Item("PartDescription")
                        End If
                        If IsDBNull(LineReader.Item("Quantity")) Then
                            ROIQuantity = 0
                        Else
                            ROIQuantity = LineReader.Item("Quantity")
                        End If
                        If IsDBNull(LineReader.Item("UnitCost")) Then
                            ROIUnitCost = 0
                        Else
                            ROIUnitCost = LineReader.Item("UnitCost")
                        End If
                        If IsDBNull(LineReader.Item("ExtendedAmount")) Then
                            ROIExtendedAmount = 0
                        Else
                            ROIExtendedAmount = LineReader.Item("ExtendedAmount")
                        End If
                        If IsDBNull(LineReader.Item("GLDebitAccount")) Then
                            ROIGLDebitAccount = ""
                        Else
                            ROIGLDebitAccount = LineReader.Item("GLDebitAccount")
                        End If
                        If IsDBNull(LineReader.Item("GLCreditAccount")) Then
                            ROIGLCreditAccount = ""
                        Else
                            ROIGLCreditAccount = LineReader.Item("GLCreditAccount")
                        End If
                        If IsDBNull(LineReader.Item("SelectForInvoice")) Then
                            ROISelectForInvoice = ""
                        Else
                            ROISelectForInvoice = LineReader.Item("SelectForInvoice")
                        End If
                        If IsDBNull(LineReader.Item("ReceiverNumber")) Then
                            ROIReceiverNumber = 0
                        Else
                            ROIReceiverNumber = LineReader.Item("ReceiverNumber")
                        End If
                        If IsDBNull(LineReader.Item("ReceiverLine")) Then
                            ROIReceiverLine = 0
                        Else
                            ROIReceiverLine = LineReader.Item("ReceiverLine")
                        End If
                    Else
                        ROIPartNumber = ""
                        ROIPartDescription = ""
                        ROIQuantity = 0
                        ROIUnitCost = 0
                        ROIExtendedAmount = 0
                        ROIGLDebitAccount = ""
                        ROIGLCreditAccount = ""
                        ROISelectForInvoice = ""
                        ROIReceiverNumber = 0
                        ROIReceiverLine = 0
                    End If
                    LineReader.Close()
                    con.Close()
                    '******************************************************************************************************************
                    Try
                        'Insert into Delete Header Table
                        cmd = New SqlCommand("Insert Into DeleteVoucherLineTable(VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice, ReceiverNumber, ReceiverLine, DivisionID)Values(@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, @SelectForInvoice, @ReceiverNumber, @ReceiverLine, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            .Add("@VoucherLine", SqlDbType.VarChar).Value = ROIVoucherLine
                            .Add("@PartNumber", SqlDbType.VarChar).Value = ROIPartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = ROIPartDescription
                            .Add("@Quantity", SqlDbType.VarChar).Value = ROIQuantity
                            .Add("@UnitCost", SqlDbType.VarChar).Value = ROIUnitCost
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ROIExtendedAmount
                            .Add("@GLDebitAccount", SqlDbType.VarChar).Value = ROIGLDebitAccount
                            .Add("@GLCreditAccount", SqlDbType.VarChar).Value = ROIGLCreditAccount
                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = ROISelectForInvoice
                            .Add("@ReceiverNumber", SqlDbType.VarChar).Value = ROIReceiverNumber
                            .Add("@ReceiverLine", SqlDbType.VarChar).Value = ROIReceiverLine
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempVoucherNumber As Integer = 0
                        Dim strVoucherNumber As String = ""
                        TempVoucherNumber = Val(cboVoucherNumber.Text)
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Edit Voucher --- Error creating Deleted Voucher Line"
                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    'Clear Variable before next loop
                    ROIPartNumber = ""
                    ROIPartDescription = ""
                    ROIQuantity = 0
                    ROIUnitCost = 0
                    ROIExtendedAmount = 0
                    ROIGLDebitAccount = ""
                    ROIGLCreditAccount = ""
                    ROISelectForInvoice = ""
                    ROIReceiverNumber = 0
                    ROIReceiverLine = 0

                    ROIVoucherLine = ROIVoucherLine + 1
                Next i
                '***********************************************************************************************************************
                'Delete voucher
                cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***********************************************************************************************************************
                'Retotal Batch without deleted Voucher

                'Sum Voucher Headers
                Dim SUMVouchersInBatchStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
                Dim SUMVouchersInBatchCommand As New SqlCommand(SUMVouchersInBatchStatement, con)
                SUMVouchersInBatchCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                SUMVouchersInBatchCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SUMVouchersInBatch = CDbl(SUMVouchersInBatchCommand.ExecuteScalar)
                Catch ex As Exception
                    SUMVouchersInBatch = 0
                End Try
                con.Close()
                '***********************************************************************************************************************
                'Update Batch
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = SUMVouchersInBatch
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                LoadVoucherNumber()
                ClearVariables()
                ClearData()
                ShowAllData()
                MsgBox("Voucher has been deleted and Receivers reset.", MsgBoxStyle.OkOnly)
            ElseIf (VoucherStatus = "OPEN" Or VoucherStatus = "PENDING") And VoucherSource = "STEEL RECEIPT" Then
                'Reset Receiver to be selected again for processing
                Dim VoucherBatchNumber As Integer = Val(txtBatchNumber.Text)
                Dim SUMVouchersInBatch As Double = 0
                Dim LineReceiverNumber, LineReceiverLine As Integer

                For Each row As DataGridViewRow In dgvVoucherLines.Rows
                    Try
                        LineReceiverNumber = row.Cells("ReceiverNumberColumn").Value
                    Catch ex As Exception
                        LineReceiverNumber = 0
                    End Try
                    Try
                        LineReceiverLine = row.Cells("ReceiverLineColumn").Value
                    Catch ex As Exception
                        LineReceiverLine = 0
                    End Try

                    If LineReceiverLine = 0 Or LineReceiverNumber = 0 Then
                        MsgBox("Unable to reset receiver and delete voucher. Contact system administrator.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    Else
                        'Update Receiver Line Table
                        cmd = New SqlCommand("UPDATE SteelReceivingLineTable SET SelectForInvoice = @SelectForInvoice, LineStatus = @LineStatus WHERE SteelReceivingHeaderKey = @ReceivingHeaderKey AND SteelReceivingLineKey = @ReceivingLineKey", con)

                        With cmd.Parameters
                            .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = LineReceiverLine
                            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@LineStatus", SqlDbType.VarChar).Value = "RECEIVED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Update Receiver Header Table
                        cmd = New SqlCommand("UPDATE SteelReceivingHeaderTable SET ReceivingStatus = @Status WHERE SteelReceivingHeaderKey = @ReceivingHeaderKey AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = LineReceiverNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                    End If
                Next
                '***********************************************************************************************************************
                'Write To Audit Trail on a reversal
                Dim AuditComment As String = ""
                Dim AuditVoucherNumber As Integer = 0
                Dim strAuditVoucherNumber As String = ""

                AuditVoucherNumber = Val(cboVoucherNumber.Text)
                strAuditVoucherNumber = CStr(AuditVoucherNumber)
                AuditComment = "Voucher #" + strAuditVoucherNumber + " was deleted on " + TodaysDate

                Try
                    cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@AuditDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@AuditType", SqlDbType.VarChar).Value = "Edit Voucher - DELETION"
                        .Add("@AuditAmount", SqlDbType.VarChar).Value = Val(txtInvoiceTotal.Text)
                        .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strAuditVoucherNumber
                        .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception

                End Try
                '********************************************************************************************************************
                'Write to Voucher Deletion Table before deleting the voucher
                '*******************************************************************************************************
                'Get Voucher Header Data to copy to delete table
                Dim ROIPONumber, ROIBatchNumber, ROIDeleteReferenceNumber As Integer
                Dim ROIProductTotal, ROIInvoiceTotal, ROIInvoiceFreight, ROIInvoiceSalesTax, ROIInvoiceAmount, ROIDiscountAmount As Double
                Dim ROIInvoiceNumber, ROIInvoiceDate, ROIReceiptDate, ROIVendorID, ROIVendorClass, ROIPaymentTerms, ROIDiscountDate, ROIComment, ROIDueDate, ROIVoucherStatus, ROIVoucherSource As String

                Dim DeleteHeaderDataString As String = "SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim DeleteHeaderDataCommand As New SqlCommand(DeleteHeaderDataString, con)
                DeleteHeaderDataCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                DeleteHeaderDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = DeleteHeaderDataCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("BatchNumber")) Then
                        ROIBatchNumber = 0
                    Else
                        ROIBatchNumber = reader.Item("BatchNumber")
                    End If
                    If IsDBNull(reader.Item("PONumber")) Then
                        ROIPONumber = 0
                    Else
                        ROIPONumber = reader.Item("PONumber")
                    End If
                    If IsDBNull(reader.Item("InvoiceNumber")) Then
                        ROIInvoiceNumber = ""
                    Else
                        ROIInvoiceNumber = reader.Item("InvoiceNumber")
                    End If
                    If IsDBNull(reader.Item("InvoiceDate")) Then
                        ROIInvoiceDate = ""
                    Else
                        ROIInvoiceDate = reader.Item("InvoiceDate")
                    End If
                    If IsDBNull(reader.Item("ReceiptDate")) Then
                        ROIReceiptDate = ""
                    Else
                        ROIReceiptDate = reader.Item("ReceiptDate")
                    End If
                    If IsDBNull(reader.Item("VendorID")) Then
                        ROIVendorID = ""
                    Else
                        ROIVendorID = reader.Item("VendorID")
                    End If
                    If IsDBNull(reader.Item("VendorClass")) Then
                        ROIVendorClass = 0
                    Else
                        ROIVendorClass = reader.Item("VendorClass")
                    End If
                    If IsDBNull(reader.Item("ProductTotal")) Then
                        ROIProductTotal = 0
                    Else
                        ROIProductTotal = reader.Item("ProductTotal")
                    End If
                    If IsDBNull(reader.Item("InvoiceFreight")) Then
                        ROIInvoiceFreight = 0
                    Else
                        ROIInvoiceFreight = reader.Item("InvoiceFreight")
                    End If
                    If IsDBNull(reader.Item("InvoiceSalesTax")) Then
                        ROIInvoiceSalesTax = 0
                    Else
                        ROIInvoiceSalesTax = reader.Item("InvoiceSalesTax")
                    End If
                    If IsDBNull(reader.Item("InvoiceTotal")) Then
                        ROIInvoiceTotal = 0
                    Else
                        ROIInvoiceTotal = reader.Item("InvoiceTotal")
                    End If
                    If IsDBNull(reader.Item("InvoiceAmount")) Then
                        ROIInvoiceAmount = 0
                    Else
                        ROIInvoiceAmount = reader.Item("InvoiceAmount")
                    End If
                    If IsDBNull(reader.Item("PaymentTerms")) Then
                        ROIPaymentTerms = "N30"
                    Else
                        ROIPaymentTerms = reader.Item("PaymentTerms")
                    End If
                    If IsDBNull(reader.Item("DiscountDate")) Then
                        ROIDiscountDate = ""
                    Else
                        ROIDiscountDate = reader.Item("DiscountDate")
                    End If
                    If IsDBNull(reader.Item("Comment")) Then
                        ROIComment = ""
                    Else
                        ROIComment = reader.Item("Comment")
                    End If
                    If IsDBNull(reader.Item("DueDate")) Then
                        ROIDueDate = ""
                    Else
                        ROIDueDate = reader.Item("DueDate")
                    End If
                    If IsDBNull(reader.Item("DiscountAmount")) Then
                        ROIDiscountAmount = 0
                    Else
                        ROIDiscountAmount = reader.Item("DiscountAmount")
                    End If
                    If IsDBNull(reader.Item("VoucherStatus")) Then
                        ROIVoucherStatus = "POSTED"
                    Else
                        ROIVoucherStatus = reader.Item("VoucherStatus")
                    End If
                    If IsDBNull(reader.Item("VoucherSource")) Then
                        ROIVoucherSource = ""
                    Else
                        ROIVoucherSource = reader.Item("VoucherSource")
                    End If
                    If IsDBNull(reader.Item("DeleteReferenceNumber")) Then
                        ROIDeleteReferenceNumber = 0
                    Else
                        ROIDeleteReferenceNumber = reader.Item("DeleteReferenceNumber")
                    End If
                Else
                    ROIBatchNumber = 0
                    ROIComment = ""
                    ROIDeleteReferenceNumber = 0
                    ROIDiscountAmount = 0
                    ROIDiscountDate = ""
                    ROIDueDate = ""
                    ROIInvoiceAmount = 0
                    ROIInvoiceDate = ""
                    ROIInvoiceFreight = 0
                    ROIInvoiceNumber = ""
                    ROIInvoiceSalesTax = 0
                    ROIInvoiceTotal = 0
                    ROIPaymentTerms = "N30"
                    ROIPONumber = 0
                    ROIProductTotal = 0
                    ROIReceiptDate = ""
                    ROIVendorClass = ""
                    ROIVendorID = ""
                    ROIVoucherSource = ""
                    ROIVoucherStatus = ""
                End If
                reader.Close()
                con.Close()
                '******************************************************************************************************
                Try
                    'Insert into Delete Header Table
                    cmd = New SqlCommand("Insert Into DeleteVoucherHeaderTable(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, ReceiptDate, VendorID, VendorClass, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, InvoiceAmount, PaymentTerms, DiscountDate, Comment, DueDate, DiscountAmount, VoucherStatus, VoucherSource, DivisionID, DeleteReferenceNumber)Values(@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @VendorID, @VendorClass, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @InvoiceAmount, @PaymentTerms, @DiscountDate, @Comment, @DueDate, @DiscountAmount, @VoucherStatus, @VoucherSource, @DivisionID, @DeleteReferenceNumber)", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = ROIBatchNumber
                        .Add("@PONumber", SqlDbType.VarChar).Value = ROIPONumber
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = ROIInvoiceNumber
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = ROIInvoiceDate
                        .Add("@ReceiptDate", SqlDbType.VarChar).Value = ROIReceiptDate
                        .Add("@VendorID", SqlDbType.VarChar).Value = ROIVendorID
                        .Add("@VendorClass", SqlDbType.VarChar).Value = ROIVendorClass
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ROIProductTotal
                        .Add("@InvoiceFreight", SqlDbType.VarChar).Value = ROIInvoiceFreight
                        .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = ROIInvoiceSalesTax
                        .Add("@InvoiceTotal", SqlDbType.VarChar).Value = ROIInvoiceTotal
                        .Add("@InvoiceAmount", SqlDbType.VarChar).Value = ROIInvoiceAmount
                        .Add("@PaymentTerms", SqlDbType.VarChar).Value = ROIPaymentTerms
                        .Add("@DiscountDate", SqlDbType.VarChar).Value = ROIDiscountDate
                        .Add("@Comment", SqlDbType.VarChar).Value = ROIComment
                        .Add("@DueDate", SqlDbType.VarChar).Value = ROIDueDate
                        .Add("@DiscountAmount", SqlDbType.VarChar).Value = ROIDiscountAmount
                        .Add("@VoucherStatus", SqlDbType.VarChar).Value = ROIVoucherStatus
                        .Add("@VoucherSource", SqlDbType.VarChar).Value = ROIVoucherSource
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@DeleteReferenceNumber", SqlDbType.VarChar).Value = ROIDeleteReferenceNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                Catch ex As Exception
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String = ""
                    TempVoucherNumber = Val(cboVoucherNumber.Text)
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Edit Voucher --- Error creating Deleted Voucher Header"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*************************************************************************************************
                'Count Voucher Lines
                Dim CountVoucherLines As Integer = 0

                Dim CountVoucherLinesStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim CountVoucherLinesCommand As New SqlCommand(CountVoucherLinesStatement, con)
                CountVoucherLinesCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                CountVoucherLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountVoucherLines = CInt(CountVoucherLinesCommand.ExecuteScalar)
                Catch ex As Exception
                    CountVoucherLines = 0
                End Try
                con.Close()

                'Insert Lines into Delete Table
                Dim ROIPartNumber, ROIPartDescription, ROIGLDebitAccount, ROIGLCreditAccount, ROISelectForInvoice As String
                Dim ROIQuantity, ROIUnitCost, ROIExtendedAmount As Double
                Dim ROIReceiverNumber, ROIReceiverLine, ROIVoucherLine As Integer

                ROIVoucherLine = 1

                For i As Integer = 1 To CountVoucherLines
                    Dim GetLineDataString As String = "SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                    Dim GetLineDataCommand As New SqlCommand(GetLineDataString, con)
                    GetLineDataCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    GetLineDataCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = ROIVoucherLine

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim LineReader As SqlDataReader = GetLineDataCommand.ExecuteReader()
                    If LineReader.HasRows Then
                        LineReader.Read()
                        If IsDBNull(LineReader.Item("PartNumber")) Then
                            ROIPartNumber = ""
                        Else
                            ROIPartNumber = LineReader.Item("PartNumber")
                        End If
                        If IsDBNull(LineReader.Item("PartDescription")) Then
                            ROIPartDescription = ""
                        Else
                            ROIPartDescription = LineReader.Item("PartDescription")
                        End If
                        If IsDBNull(LineReader.Item("Quantity")) Then
                            ROIQuantity = 0
                        Else
                            ROIQuantity = LineReader.Item("Quantity")
                        End If
                        If IsDBNull(LineReader.Item("UnitCost")) Then
                            ROIUnitCost = 0
                        Else
                            ROIUnitCost = LineReader.Item("UnitCost")
                        End If
                        If IsDBNull(LineReader.Item("ExtendedAmount")) Then
                            ROIExtendedAmount = 0
                        Else
                            ROIExtendedAmount = LineReader.Item("ExtendedAmount")
                        End If
                        If IsDBNull(LineReader.Item("GLDebitAccount")) Then
                            ROIGLDebitAccount = ""
                        Else
                            ROIGLDebitAccount = LineReader.Item("GLDebitAccount")
                        End If
                        If IsDBNull(LineReader.Item("GLCreditAccount")) Then
                            ROIGLCreditAccount = ""
                        Else
                            ROIGLCreditAccount = LineReader.Item("GLCreditAccount")
                        End If
                        If IsDBNull(LineReader.Item("SelectForInvoice")) Then
                            ROISelectForInvoice = ""
                        Else
                            ROISelectForInvoice = LineReader.Item("SelectForInvoice")
                        End If
                        If IsDBNull(LineReader.Item("ReceiverNumber")) Then
                            ROIReceiverNumber = 0
                        Else
                            ROIReceiverNumber = LineReader.Item("ReceiverNumber")
                        End If
                        If IsDBNull(LineReader.Item("ReceiverLine")) Then
                            ROIReceiverLine = 0
                        Else
                            ROIReceiverLine = LineReader.Item("ReceiverLine")
                        End If
                    Else
                        ROIPartNumber = ""
                        ROIPartDescription = ""
                        ROIQuantity = 0
                        ROIUnitCost = 0
                        ROIExtendedAmount = 0
                        ROIGLDebitAccount = ""
                        ROIGLCreditAccount = ""
                        ROISelectForInvoice = ""
                        ROIReceiverNumber = 0
                        ROIReceiverLine = 0
                    End If
                    LineReader.Close()
                    con.Close()
                    '******************************************************************************************************************
                    Try
                        'Insert into Delete Header Table
                        cmd = New SqlCommand("Insert Into DeleteVoucherLineTable(VoucherNumber, VoucherLine, PartNumber, PartDescription, Quantity, UnitCost, ExtendedAmount, GLDebitAccount, GLCreditAccount, SelectForInvoice, ReceiverNumber, ReceiverLine, DivisionID)Values(@VoucherNumber, @VoucherLine, @PartNumber, @PartDescription, @Quantity, @UnitCost, @ExtendedAmount, @GLDebitAccount, @GLCreditAccount, @SelectForInvoice, @ReceiverNumber, @ReceiverLine, @DivisionID)", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                            .Add("@VoucherLine", SqlDbType.VarChar).Value = ROIVoucherLine
                            .Add("@PartNumber", SqlDbType.VarChar).Value = ROIPartNumber
                            .Add("@PartDescription", SqlDbType.VarChar).Value = ROIPartDescription
                            .Add("@Quantity", SqlDbType.VarChar).Value = ROIQuantity
                            .Add("@UnitCost", SqlDbType.VarChar).Value = ROIUnitCost
                            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = ROIExtendedAmount
                            .Add("@GLDebitAccount", SqlDbType.VarChar).Value = ROIGLDebitAccount
                            .Add("@GLCreditAccount", SqlDbType.VarChar).Value = ROIGLCreditAccount
                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = ROISelectForInvoice
                            .Add("@ReceiverNumber", SqlDbType.VarChar).Value = ROIReceiverNumber
                            .Add("@ReceiverLine", SqlDbType.VarChar).Value = ROIReceiverLine
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempVoucherNumber As Integer = 0
                        Dim strVoucherNumber As String = ""
                        TempVoucherNumber = Val(cboVoucherNumber.Text)
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Edit Voucher --- Error creating Deleted Voucher Line"
                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    'Clear Variable before next loop
                    ROIPartNumber = ""
                    ROIPartDescription = ""
                    ROIQuantity = 0
                    ROIUnitCost = 0
                    ROIExtendedAmount = 0
                    ROIGLDebitAccount = ""
                    ROIGLCreditAccount = ""
                    ROISelectForInvoice = ""
                    ROIReceiverNumber = 0
                    ROIReceiverLine = 0

                    ROIVoucherLine = ROIVoucherLine + 1
                Next i
                '***********************************************************************************************************************
                'Delete voucher
                cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = Val(cboVoucherNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***********************************************************************************************************************
                'Retotal Batch without deleted Voucher

                'Sum Voucher Headers
                Dim SUMVouchersInBatchStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND BatchNumber = @BatchNumber"
                Dim SUMVouchersInBatchCommand As New SqlCommand(SUMVouchersInBatchStatement, con)
                SUMVouchersInBatchCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                SUMVouchersInBatchCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SUMVouchersInBatch = CDbl(SUMVouchersInBatchCommand.ExecuteScalar)
                Catch ex As Exception
                    SUMVouchersInBatch = 0
                End Try
                con.Close()
                '***********************************************************************************************************************
                'Update Batch
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = SUMVouchersInBatch
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                LoadVoucherNumber()
                ClearVariables()
                ClearData()
                ShowAllData()
                MsgBox("Voucher has been deleted and Receivers reset.", MsgBoxStyle.OkOnly)
            Else
                MsgBox("You cannot delete this voucher.", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        GlobalVoucherNumber = 0
        GlobalVoucherNumber2 = 0
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        GlobalVoucherNumber = 0
        GlobalVoucherNumber2 = 0
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
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