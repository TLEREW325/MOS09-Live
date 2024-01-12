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
Public Class SelectInvoicesForPayment
    Inherits System.Windows.Forms.Form

    Dim VoucherNumber, PONumber As Integer
    Dim InvoiceDate, ReceiptDate, DueDate, DiscountDate As Date
    Dim InvoiceNumber, VendorID, Comment, PaymentTerms As String
    Dim LineInvoiceTotal, BatchTotal, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, DiscountAmount, PaymentAmount As Double

    Dim BatchDate, BatchDescription, BatchStatus As String
    Dim BatchAmount, SUMInvoiceTotal, UndistributedAmount As Double
    Dim CountLines, NextBatchNumber, LastBatchNumber, counter, LastTransactionNumber, NextTransactionNumber As Integer
    Dim CheckType As String = ""
    Dim WhitePaper As String = ""
    Dim Checked1099 As String = ""
    Dim SumVendorTotalPlus, SumVendorTotalMinus, SumVendorTotalNet As Double

    Dim CheckVoucherNumber As Integer = 0
    Dim CheckDiscountDays As Integer = 0
    Dim CheckDueDate As Date
    Dim CheckDiscountDate As Date
    Dim CheckRowIndex As Integer = 0

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Public Sub ShowVoucherLinesByDiscountDateAndDueDate()
        If GlobalCheckType = "STANDARD" Then
            cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VoucherStatus = @VoucherStatus AND OnHold <> @OnHold AND CheckType = @CheckType AND (DueDate <= @DueDate OR DiscountDate <= @DueDate)ORDER BY VendorID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
            cmd.Parameters.Add("@DueDate", SqlDbType.VarChar).Value = GlobalDueDate
            cmd.Parameters.Add("@OnHold", SqlDbType.VarChar).Value = "YES"
            cmd.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = GlobalCheckType
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
            dgvVoucherHeader.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")
            con.Close()
        Else
            cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VoucherStatus = @VoucherStatus AND OnHold <> @OnHold AND CheckType <> @CheckType AND (DueDate <= @DueDate OR DiscountDate <= @DueDate)ORDER BY VendorID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
            cmd.Parameters.Add("@DueDate", SqlDbType.VarChar).Value = GlobalDueDate
            cmd.Parameters.Add("@OnHold", SqlDbType.VarChar).Value = "YES"
            cmd.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
            dgvVoucherHeader.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")
            con.Close()
        End If

        'Routine to remove vouchers with zero discount and discount date that falls within the range
        For Each row As DataGridViewRow In dgvVoucherHeader.Rows
            CheckVoucherNumber = row.Cells("VoucherNumberColumn").Value
            CheckDueDate = row.Cells("DueDateColumn").Value
            CheckDiscountDate = row.Cells("DiscountDateColumn").Value

            If CheckDueDate <= GlobalDueDate Then
                'Skip
            Else
                If CheckDiscountDate <= GlobalDueDate Then
                    'Check to see if Discount Days is zero
                    Dim CheckDiscountDays As Integer = 0

                    Dim CheckDiscountDaysStatement As String = "SELECT DiscountDays FROM ReceiptOfInvoiceBatchLinePD WHERE VoucherNumber = @VoucherNumber"
                    Dim CheckDiscountDaysCommand As New SqlCommand(CheckDiscountDaysStatement, con)
                    CheckDiscountDaysCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = CheckVoucherNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckDiscountDays = CInt(CheckDiscountDaysCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckDiscountDays = 0
                    End Try
                    con.Close()

                    If CheckDiscountDays = 0 Then
                        dgvVoucherHeader.Rows.RemoveAt(CheckRowIndex)
                    Else
                        'Skip
                    End If
                Else
                    'Skip
                End If
            End If

            CheckRowIndex = CheckRowIndex + 1
        Next

        FormatWhitePaperChecks()
    End Sub

    Public Sub ShowVoucherLinesByDiscountDateAndDueDateAmerican()
        If GlobalCheckType = "STANDARD" Then
            cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VoucherStatus = @VoucherStatus AND OnHold <> @OnHold AND CheckType = @CheckType AND VendorClass = @VendorClass AND (DueDate <= @DueDate OR DiscountDate <= @DueDate) ORDER BY VendorID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
            cmd.Parameters.Add("@DueDate", SqlDbType.VarChar).Value = GlobalDueDate
            cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "American"
            cmd.Parameters.Add("@OnHold", SqlDbType.VarChar).Value = "YES"
            cmd.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = GlobalCheckType
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
            dgvVoucherHeader.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")
            con.Close()
        Else
            cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VoucherStatus = @VoucherStatus AND OnHold <> @OnHold AND CheckType <> @CheckType AND VendorClass = @VendorClass AND (DueDate <= @DueDate OR DiscountDate <= @DueDate) ORDER BY VendorID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
            cmd.Parameters.Add("@DueDate", SqlDbType.VarChar).Value = GlobalDueDate
            cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "American"
            cmd.Parameters.Add("@OnHold", SqlDbType.VarChar).Value = "YES"
            cmd.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
            dgvVoucherHeader.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")
            con.Close()
        End If

        'Routine to remove vouchers with zero discount and discount date that falls within the range
        For Each row As DataGridViewRow In dgvVoucherHeader.Rows
            CheckVoucherNumber = row.Cells("VoucherNumberColumn").Value
            CheckDueDate = row.Cells("DueDateColumn").Value
            CheckDiscountDate = row.Cells("DiscountDateColumn").Value

            If CheckDueDate <= GlobalDueDate Then
                'Skip
            Else
                If CheckDiscountDate <= GlobalDueDate Then
                    'Check to see if Discount Days is zero
                    Dim CheckDiscountDays As Integer = 0

                    Dim CheckDiscountDaysStatement As String = "SELECT DiscountDays FROM ReceiptOfInvoiceBatchLinePD WHERE VoucherNumber = @VoucherNumber"
                    Dim CheckDiscountDaysCommand As New SqlCommand(CheckDiscountDaysStatement, con)
                    CheckDiscountDaysCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = CheckVoucherNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckDiscountDays = CInt(CheckDiscountDaysCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckDiscountDays = 0
                    End Try
                    con.Close()

                    If CheckDiscountDays = 0 Then
                        dgvVoucherHeader.Rows.RemoveAt(CheckRowIndex)
                    Else
                        'Skip
                    End If
                Else
                    'Skip
                End If
            End If

            CheckRowIndex = CheckRowIndex + 1
        Next

        FormatWhitePaperChecks()
    End Sub

    Public Sub ShowVoucherLinesByDiscountDateAndDueDateCanadian()
        If GlobalCheckType = "STANDARD" Then
            cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VoucherStatus = @VoucherStatus AND OnHold <> @OnHold AND CheckType = @CheckType AND VendorClass = @VendorClass AND (DueDate <= @DueDate OR DiscountDate <= @DueDate OR InvoiceTotal < 0) ORDER BY VendorID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
            cmd.Parameters.Add("@DueDate", SqlDbType.VarChar).Value = GlobalDueDate
            cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "Canadian"
            cmd.Parameters.Add("@OnHold", SqlDbType.VarChar).Value = "YES"
            cmd.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = GlobalCheckType
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
            dgvVoucherHeader.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")
            con.Close()
        Else
            cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VoucherStatus = @VoucherStatus AND OnHold <> @OnHold AND CheckType <> @CheckType AND VendorClass = @VendorClass AND (DueDate <= @DueDate OR DiscountDate <= @DueDate OR InvoiceTotal < 0) ORDER BY VendorID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
            cmd.Parameters.Add("@DueDate", SqlDbType.VarChar).Value = GlobalDueDate
            cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "Canadian"
            cmd.Parameters.Add("@OnHold", SqlDbType.VarChar).Value = "YES"
            cmd.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
            dgvVoucherHeader.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")
            con.Close()
        End If

        'Routine to remove vouchers with zero discount and discount date that falls within the range
        For Each row As DataGridViewRow In dgvVoucherHeader.Rows
            CheckVoucherNumber = row.Cells("VoucherNumberColumn").Value
            CheckDueDate = row.Cells("DueDateColumn").Value
            CheckDiscountDate = row.Cells("DiscountDateColumn").Value

            If CheckDueDate <= GlobalDueDate Then
                'Skip
            Else
                If CheckDiscountDate <= GlobalDueDate Then
                    'Check to see if Discount Days is zero
                    Dim CheckDiscountDays As Integer = 0

                    Dim CheckDiscountDaysStatement As String = "SELECT DiscountDays FROM ReceiptOfInvoiceBatchLinePD WHERE VoucherNumber = @VoucherNumber"
                    Dim CheckDiscountDaysCommand As New SqlCommand(CheckDiscountDaysStatement, con)
                    CheckDiscountDaysCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = CheckVoucherNumber

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CheckDiscountDays = CInt(CheckDiscountDaysCommand.ExecuteScalar)
                    Catch ex As Exception
                        CheckDiscountDays = 0
                    End Try
                    con.Close()

                    If CheckDiscountDays = 0 Then
                        dgvVoucherHeader.Rows.RemoveAt(CheckRowIndex)
                    Else
                        'Skip
                    End If
                Else
                    'Skip
                End If
            End If

            CheckRowIndex = CheckRowIndex + 1
        Next

        FormatWhitePaperChecks()
    End Sub

    Public Sub FormatWhitePaperChecks()
        Dim GetCheckType As String = ""
        Dim IsWhitePaper As String = ""

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvVoucherHeader.Rows
            Try
                GetCheckType = row.Cells("CheckTypeColumn").Value
            Catch ex As System.Exception
                GetCheckType = ""
            End Try
            Try
                IsWhitePaper = row.Cells("WhitePaperColumn").Value
            Catch ex As System.Exception
                IsWhitePaper = "NO"
            End Try

            If GetCheckType <> "STANDARD" Then
                Me.dgvVoucherHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvVoucherHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            Else
                If IsWhitePaper = "YES" Then
                    Me.dgvVoucherHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                    Me.dgvVoucherHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
                Else
                    Me.dgvVoucherHeader.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                    Me.dgvVoucherHeader.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
                End If
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub SelectInvoicesForPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()
        GlobalVerifyCode = "FAILED"
        '-------------------------------------------------------------------------------------
        'Check #1 --- Select all line the meet the criteria
        If (GlobalDivisionCode = "TFF" Or GlobalDivisionCode = "TOR" Or GlobalDivisionCode = "ALB") And GlobalVendorClass = "American" Then
            ShowVoucherLinesByDiscountDateAndDueDateAmerican()
        ElseIf (GlobalDivisionCode = "TFF" Or GlobalDivisionCode = "TOR" Or GlobalDivisionCode = "ALB") And GlobalVendorClass = "Canadian" Then
            ShowVoucherLinesByDiscountDateAndDueDateCanadian()
        Else
            ShowVoucherLinesByDiscountDateAndDueDate()
        End If

        For Each row As DataGridViewRow In dgvVoucherHeader.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForPay")

            cell.Value = "SELECTED"
        Next
        '-------------------------------------------------------------------------------------
        'Check #2 --- Routine unselects credits that may be selected
        For Each row As DataGridViewRow In dgvVoucherHeader.Rows
            Dim cell2 As DataGridViewCheckBoxCell = row.Cells("SelectForPay")

            LineInvoiceTotal = row.Cells("InvoiceTotalColumn").Value

            If LineInvoiceTotal < 0 Then
                cell2.Value = "UNSELECTED"
            Else
                'Do nothing
            End If
        Next
        '-------------------------------------------------------------------------------------
        'Check #3 --- Unselect if credit exceeds the sum of the invoices for that vendor
        For Each row As DataGridViewRow In dgvVoucherHeader.Rows
            Dim cell3 As DataGridViewCheckBoxCell = row.Cells("SelectForPay")
            Try
                DueDate = row.Cells("DueDateColumn").Value
            Catch ex As Exception
                DueDate = GlobalDueDate
            End Try
            Try
                InvoiceTotal = row.Cells("InvoiceTotalColumn").Value
            Catch ex As Exception
                InvoiceTotal = 0
            End Try
            Try
                VendorID = row.Cells("VendorIDColumn").Value
            Catch ex As Exception
                VendorID = ""
            End Try
            Try
                DiscountDate = row.Cells("DiscountDateColumn").Value
            Catch ex As Exception
                DiscountDate = GlobalDueDate
            End Try

            If DueDate <= GlobalDueDate And InvoiceTotal >= 0 Then
                cell3.Value = "SELECTED"
            Else
                'Do nothing
            End If

            'Check to see of there is a credit that exceeds the sum of the invoices and un-select the invoices
            Dim SumVendorPlusStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND InvoiceTotal >= @InvoiceTotal AND VoucherStatus = @VoucherStatus AND (DueDate <= @DueDate OR DiscountDate <= @DiscountDate)"
            Dim SumVendorPlusCommand As New SqlCommand(SumVendorPlusStatement, con)
            SumVendorPlusCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
            SumVendorPlusCommand.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
            SumVendorPlusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            SumVendorPlusCommand.Parameters.Add("@DueDate", SqlDbType.VarChar).Value = GlobalDueDate
            SumVendorPlusCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
            SumVendorPlusCommand.Parameters.Add("@DiscountDate", SqlDbType.VarChar).Value = GlobalDueDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumVendorTotalPlus = CDbl(SumVendorPlusCommand.ExecuteScalar)
            Catch ex As Exception
                SumVendorTotalPlus = 0
            End Try
            con.Close()

            Dim SumVendorMinusStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND InvoiceTotal < @InvoiceTotal AND VoucherStatus = @VoucherStatus"
            Dim SumVendorMinusCommand As New SqlCommand(SumVendorMinusStatement, con)
            SumVendorMinusCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
            SumVendorMinusCommand.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
            SumVendorMinusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
            'SumVendorMinusCommand.Parameters.Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
            SumVendorMinusCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
            'SumVendorMinusCommand.Parameters.Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDueDate.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumVendorTotalMinus = CDbl(SumVendorMinusCommand.ExecuteScalar)
            Catch ex As Exception
                SumVendorTotalMinus = 0
            End Try
            con.Close()

            SumVendorTotalNet = SumVendorTotalPlus + SumVendorTotalMinus

            If SumVendorTotalNet <= 0 Then
                cell3.Value = "UNSELECTED"
            Else
                'Do nothing
            End If
        Next
        '-------------------------------------------------------------------------------------
        'Check #4 --- Unselect if payable is on hold
        For Each row As DataGridViewRow In dgvVoucherHeader.Rows
            Dim cell4 As DataGridViewCheckBoxCell = row.Cells("SelectForPay")
            Dim OnholdStatus As String = ""

            If cell4.Value = "SELECTED" Then
                Try
                    OnholdStatus = row.Cells("OnHoldColumn").Value
                Catch ex As Exception
                    OnholdStatus = "NO"
                End Try

                If OnholdStatus = "YES" Then
                    cell4.Value = "UNSELECTED"
                Else
                    'Skip
                End If
            End If
        Next
        '-------------------------------------------------------------------------------------
        'Check #5 --- Unselect if voucher is ACH/INTERCOMPANY and would be selected over the weekend from a Friday
        '             Friday - if the 2,3,4 or 17,18,19 fall on a Friday, wait until Monday to process intercompany checks

        'Check if today is Friday - if not, skip this whole routine
        Dim CheckFridayDate As Date = Today()
        Dim FridaysDayOfWeek As Integer = 0
        FridaysDayOfWeek = CheckFridayDate.Day

        If CheckFridayDate.DayOfWeek = DayOfWeek.Friday Then

            'If today is Friday - and today is the 2nd, 3rd, 4th, 17th, 18th, 19th - unselect Intercompany Vouchers
            If FridaysDayOfWeek = 2 Or FridaysDayOfWeek = 3 Or FridaysDayOfWeek = 4 Or FridaysDayOfWeek = 17 Or FridaysDayOfWeek = 18 Or FridaysDayOfWeek = 19 Then
                For Each row As DataGridViewRow In dgvVoucherHeader.Rows
                    Dim cell5 As DataGridViewCheckBoxCell = row.Cells("SelectForPay")

                    If cell5.Value = "SELECTED" Then
                        Dim RowCheckType As String = ""

                        Try
                            RowCheckType = row.Cells("CheckTypeColumn").Value
                        Catch ex As Exception
                            RowCheckType = ""
                        End Try

                        'Uncheck if Intercompany
                        If RowCheckType = "INTERCOMPANY" Then
                            cell5.Value = "UNSELECTED"
                        Else
                            'Skip
                        End If
                    End If
                Next
            Else
                'Skip routine if Friday isn't the 2, 3, 4, 17, 18, or 19
            End If
        Else
            'Skip - only run routine if today is a Friday
        End If
        '-------------------------------------------------------------------------------------




    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Dim NewAPProcessForPayment As New APProcessForPayment
        NewAPProcessForPayment.Show()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckAll.Click
        For Each row As DataGridViewRow In dgvVoucherHeader.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForPay")
            cell.Value = "SELECTED"
        Next
    End Sub

    Private Sub cmdUnCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnCheckAll.Click
        For Each row As DataGridViewRow In dgvVoucherHeader.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForPay")
            cell.Value = "UNSELECTED"
        Next
    End Sub

    Private Sub cmdProcessForPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcessForPayment.Click
        'Create new batch
        cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchStatus = @BatchStatus WHERE BatchNumber = @BatchNumber", con)

        With cmd.Parameters
            .Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalNewAPBatchNumber
            .Add("@BatchStatus", SqlDbType.VarChar).Value = "PENDING"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Retrieve line data from Receipt of Invoice and write to AP Voucher Table
        For Each row As DataGridViewRow In dgvVoucherHeader.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForPay")

            If cell.Value = "SELECTED" Then
                Try
                    VoucherNumber = row.Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    VoucherNumber = 0
                End Try
                Try
                    PONumber = row.Cells("PONumberColumn").Value
                Catch ex As Exception
                    PONumber = 0
                End Try
                Try
                    InvoiceNumber = row.Cells("InvoiceNumberColumn").Value
                Catch ex As Exception
                    InvoiceNumber = ""
                End Try
                Try
                    InvoiceDate = row.Cells("InvoiceDateColumn").Value
                Catch ex As Exception
                    InvoiceDate = ""
                End Try
                Try
                    ReceiptDate = row.Cells("ReceiptDateColumn").Value
                Catch ex As Exception
                    ReceiptDate = ""
                End Try
                Try
                    DueDate = row.Cells("DueDateColumn").Value
                Catch ex As Exception
                    DueDate = ""
                End Try
                Try
                    DiscountDate = row.Cells("DiscountDateColumn").Value
                Catch ex As Exception
                    DiscountDate = ""
                End Try
                Try
                    VendorID = row.Cells("VendorIDColumn").Value
                Catch ex As Exception
                    VendorID = ""
                End Try
                Try
                    ProductTotal = row.Cells("ProductTotalColumn").Value
                Catch ex As Exception
                    ProductTotal = 0
                End Try
                Try
                    InvoiceFreight = row.Cells("InvoiceFreightColumn").Value
                Catch ex As Exception
                    InvoiceFreight = 0
                End Try
                Try
                    InvoiceSalesTax = row.Cells("InvoiceSalesTaxColumn").Value
                Catch ex As Exception
                    InvoiceSalesTax = 0
                End Try
                Try
                    InvoiceTotal = row.Cells("InvoiceTotalColumn").Value
                Catch ex As Exception
                    InvoiceTotal = 0
                End Try
                Try
                    DiscountAmount = row.Cells("DiscountAmountColumn").Value
                Catch ex As Exception
                    DiscountAmount = 0
                End Try
                Try
                    Comment = row.Cells("CommentColumn").Value
                Catch ex As Exception
                    Comment = ""
                End Try
                Try
                    PaymentTerms = row.Cells("PaymentTermsColumn").Value
                Catch ex As Exception
                    PaymentTerms = "N30"
                End Try
                Try
                    CheckType = row.Cells("CheckTypeColumn").Value
                Catch ex As Exception
                    CheckType = GlobalCheckType
                End Try
                Try
                    WhitePaper = row.Cells("WhitePaperColumn").Value
                Catch ex As Exception
                    WhitePaper = "NO"
                End Try
                Try
                    Checked1099 = row.Cells("Checked1099Column").Value
                Catch ex As Exception
                    Checked1099 = "NO"
                End Try
                '**************************************************************************************************
                'Check Voucher Number to see if it exists on another check
                Dim CountVoucherCheck As Integer = 0

                Dim CountVoucherCheckStatement As String = "SELECT COUNT(VoucherNumber) FROM APVoucherTable WHERE VoucherNumber = @VoucherNumber"
                Dim CountVoucherCheckCommand As New SqlCommand(CountVoucherCheckStatement, con)
                CountVoucherCheckCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountVoucherCheck = CInt(CountVoucherCheckCommand.ExecuteScalar)
                Catch ex As Exception
                    CountVoucherCheck = 0
                End Try
                con.Close()

                If CountVoucherCheck <> 0 Then
                    MsgBox("One or more vouchers selected have already been paid. Contact Admin.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                '**************************************************************************************************
                'Calculate and apply Discount
                If Today() <= DiscountDate Then
                    PaymentAmount = InvoiceTotal - DiscountAmount
                Else
                    PaymentAmount = InvoiceTotal
                    DiscountAmount = 0
                End If

                'Round Dollar values to 2 digits
                ProductTotal = Math.Round(ProductTotal, 2)
                InvoiceFreight = Math.Round(InvoiceFreight, 2)
                InvoiceSalesTax = Math.Round(InvoiceSalesTax, 2)
                InvoiceTotal = Math.Round(InvoiceTotal, 2)
                DiscountAmount = Math.Round(DiscountAmount, 2)
                PaymentAmount = Math.Round(PaymentAmount, 2)

                'Write Data to Voucher Database Table
                cmd = New SqlCommand("Insert Into APVoucherTable(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, ReceiptDate, DueDate, DiscountDate, PaidDate, VendorID, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, DiscountAmount, Comment, PaymentTerms, VoucherStatus, PaymentAmount, DivisionID, CheckPositionNumber, CheckType, WhitePaper, Checked1099) Values (@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @DueDate, @DiscountDate, @PaidDate, @VendorID, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @DiscountAmount, @Comment, @PaymentTerms, @VoucherStatus, @PaymentAmount, @DivisionID, @CheckPositionNumber, @CheckType, @WhitePaper, @Checked1099)", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalNewAPBatchNumber
                    .Add("@PONumber", SqlDbType.VarChar).Value = PONumber
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                    .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                    .Add("@ReceiptDate", SqlDbType.VarChar).Value = ReceiptDate
                    .Add("@DueDate", SqlDbType.VarChar).Value = DueDate
                    .Add("@DiscountDate", SqlDbType.VarChar).Value = DiscountDate
                    .Add("@PaidDate", SqlDbType.VarChar).Value = Today()
                    .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                    .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@DiscountAmount", SqlDbType.VarChar).Value = DiscountAmount
                    .Add("@Comment", SqlDbType.VarChar).Value = Comment
                    .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
                    .Add("@VoucherStatus", SqlDbType.VarChar).Value = "PENDING"
                    .Add("@PaymentAmount", SqlDbType.VarChar).Value = PaymentAmount
                    .Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                    .Add("@CheckPositionNumber", SqlDbType.VarChar).Value = 0
                    .Add("@CheckType", SqlDbType.VarChar).Value = CheckType
                    .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaper
                    .Add("@Checked1099", SqlDbType.VarChar).Value = Checked1099
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Update Receipt Of Invoice Batch Line to Pending Status
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber", con)
                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "PENDING"

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next

        'Check to see if a negative check exists
        'Routine to validate if negative check exists
        For Each row As DataGridViewRow In dgvVoucherHeader.Rows
            Dim cell2 As DataGridViewCheckBoxCell = row.Cells("SelectForPay")

            If cell2.Value = "SELECTED" Then
                Dim VendorID As String = row.Cells("VendorIDColumn").Value
                Dim VendorTotal As Double = 0

                'Check and prompt if negative check exists
                Dim VendorTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND VendorID = @VendorID"
                Dim VendorTotalCommand As New SqlCommand(VendorTotalStatement, con)
                VendorTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalNewAPBatchNumber
                VendorTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode
                VendorTotalCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    VendorTotal = CDbl(VendorTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorTotal = 0
                End Try
                con.Close()

                VendorTotal = Math.Round(VendorTotal, 2)

                If VendorTotal < 0 Then
                    MsgBox("You have selected invoices that will create a negative check - Invoices from this Vendor will be removed from the batch.", MsgBoxStyle.OkOnly)

                    For Each row1 As DataGridViewRow In dgvVoucherHeader.Rows
                        Dim cell3 As DataGridViewCheckBoxCell = row1.Cells("SelectForPay")

                        If cell3.Value = "SELECTED" Then
                            Dim VendorID2 As String = row1.Cells("VendorIDColumn").Value

                            If VendorID2 = VendorID Then
                                Dim VoucherNumber2 As Integer = row1.Cells("VoucherNumberColumn").Value

                                'Update Receipt Of Invoice Batch Line to Pending Status
                                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber", con)
                                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber2
                                cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()

                                'Update Receipt Of Invoice Batch Line to Pending Status
                                cmd = New SqlCommand("DELETE FROM APVoucherTable WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                                cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber2
                                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GlobalDivisionCode

                                If con.State = ConnectionState.Closed Then con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            Else
                                'Skip and go to next voucher
                            End If
                        End If
                    Next
                Else
                    'Do nothing - continue routine
                End If
            End If
        Next

        'Load Voucher Total into Batch Total
        Dim BatchTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE BatchNumber = @BatchNumber"
        Dim BatchTotalCommand As New SqlCommand(BatchTotalStatement, con)
        BatchTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalNewAPBatchNumber

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BatchTotal = CDbl(BatchTotalCommand.ExecuteScalar)
        Catch ex As Exception
            BatchTotal = 0
        End Try
        con.Close()

        'Round Batch Total to two decimals
        BatchTotal = Math.Round(BatchTotal, 2)

        'Write Data to Batch Header Database Table
        cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = GlobalNewAPBatchNumber
        cmd.Parameters.Add("@BatchAmount", SqlDbType.VarChar).Value = BatchTotal

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Re-open main form and close this form
        Dim NewAPProcessForPayment As New APProcessForPayment
        NewAPProcessForPayment.Show()

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