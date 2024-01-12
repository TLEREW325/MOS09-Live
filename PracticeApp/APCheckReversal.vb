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
Public Class APCheckReversal
    Inherits System.Windows.Forms.Form

    Dim TodaysDate As Date
    Dim ReceiverLineNumber, ReceiverNumber, CountVoucherLines, APBatchNumber, NextGLNumber, LastGLNumber, APVoucherNumber As Integer
    Dim CheckDate, VendorID, APPostDate, APVoucherDate, BatchDate As String
    Dim InvoiceFreight, InvoiceSalesTax, CheckAmount, ReverseCheckAmount, DiscountAmount As Double
    Dim CheckItemsCount As Integer = 0

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

    Dim isloaded = False

    Private Sub APCheckReversal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        TodaysDate = Today.ToShortDateString()

        ClearData()
        ShowCheckLog()
        LoadCheckData()
        isloaded = True
    End Sub

    Public Sub ShowCheckLog()
        cmd = New SqlCommand("SELECT * FROM APCheckLog WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APCheckLog")
        dgvAPCheckLog.DataSource = ds.Tables("APCheckLog")
        cboCheckNumber.DataSource = ds.Tables("APCheckLog")
        con.Close()
    End Sub

    Public Sub ShowCheckLines()
        cmd = New SqlCommand("SELECT * FROM APCheckLines WHERE APCheckNumber = @APCheckNumber", con)
        cmd.Parameters.Add("@APCheckNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "APCheckLines")
        dgvCheckLines.DataSource = ds1.Tables("APCheckLines")
        con.Close()
    End Sub

    Public Sub LoadCheckData()
        Dim CheckAmountStatement As String = "SELECT * FROM APCheckLog WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID"
        Dim CheckAmountCommand As New SqlCommand(CheckAmountStatement, con)
        CheckAmountCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
        CheckAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = CheckAmountCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("CheckAmount")) Then
                CheckAmount = 0
            Else
                CheckAmount = reader.Item("CheckAmount")
            End If
            If IsDBNull(reader.Item("CheckDate")) Then
                CheckDate = ""
            Else
                CheckDate = reader.Item("CheckDate")
            End If
            If IsDBNull(reader.Item("VendorID")) Then
                VendorID = ""
            Else
                VendorID = reader.Item("VendorID")
            End If
            If IsDBNull(reader.Item("APBatchNumber")) Then
                APBatchNumber = 0
            Else
                APBatchNumber = reader.Item("APBatchNumber")
            End If
        Else
            CheckAmount = 0
            CheckDate = ""
            VendorID = ""
            APBatchNumber = 0
        End If
        reader.Close()
        con.Close()

        txtBatchNumber.Text = APBatchNumber
        txtCheckAmount.Text = FormatCurrency(CheckAmount, 2)
        txtCheckDate.Text = CheckDate
        txtVendor.Text = VendorID
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length > 399 Then
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

    Public Sub ClearData()
        cboCheckNumber.Text = ""
        cboCheckNumber.SelectedIndex = -1

        txtBatchNumber.Clear()
        txtCheckAmount.Clear()
        txtCheckDate.Clear()
        txtVendor.Clear()

        dtpCancelPostDate.Text = ""
        dtpPostDate.Text = ""
        cboCheckNumber.Focus()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isloaded Then
            ClearData()
            ShowCheckLog()
            LoadCheckData()
        End If
    End Sub

    Private Sub cboCheckNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCheckNumber.SelectedIndexChanged
        If isloaded Then
            ShowCheckLines()
            LoadCheckData()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintAPCheckLog As New PrintAPCheckLog
            Dim Result = NewPrintAPCheckLog.ShowDialog()
        End Using
    End Sub

    Private Sub PrintAPCheckLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintAPCheckLogToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        If canCancel() Then
            '******************************************************************************************************
            'Validate Date
            Dim CurrentDate As Date
            Dim MonthOfYear, YearOfYear, TodaysMonthOfYear, TodaysYearOfYear As Integer

            CurrentDate = dtpCancelPostDate.Value

            MonthOfYear = CurrentDate.Month
            YearOfYear = CurrentDate.Year
            TodaysMonthOfYear = TodaysDate.Month
            TodaysYearOfYear = TodaysDate.Year

            If TodaysYearOfYear - YearOfYear > 1 Then
                MsgBox("You cannot post a Reversal to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                Exit Sub
            ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear < 5 And (TodaysMonthOfYear >= 1 And TodaysMonthOfYear < 5) Then
                MsgBox("You cannot post a Reversal to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                Exit Sub
            ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear > 5 And (TodaysMonthOfYear >= 5 And TodaysMonthOfYear <= 12) Then
                MsgBox("You cannot post a Reversal to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                Exit Sub
                'ElseIf TodaysYearOfYear - YearOfYear = 0 And MonthOfYear < 5 And TodaysMonthOfYear >= 5 Then
                'MsgBox("You cannot post a Reversal to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                'Exit Sub
            ElseIf TodaysYearOfYear - YearOfYear < 0 Then
                MsgBox("You cannot post a Reversal to a future period.", MsgBoxStyle.OkOnly)
                Exit Sub
            ElseIf TodaysYearOfYear - YearOfYear = 0 And TodaysMonthOfYear < MonthOfYear Then
                MsgBox("You cannot post a Reversal to a future period.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Date is okay --- Continue
            End If
            '******************************************************************************************************
            Dim VendorClass, CheckVendorID, GLFreightAccount, GLTaxAccount, GLPayablesAccount, GLDiscountAccount, GLBankAccount As String

            'Reset number of vouchers in check batch to zero
            CheckItemsCount = 0

            'Reverse AP Check and reset voucher
            For Each row As DataGridViewRow In dgvCheckLines.Rows
                APVoucherNumber = row.Cells("APVoucherNumberColumn").Value
                APVoucherDate = row.Cells("VoucherDateColumn").Value

                'Get Vendor ID
                Dim VendorIDStatement As String = "SELECT VendorID FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckNumber = @CheckNumber"
                Dim VendorIDCommand As New SqlCommand(VendorIDStatement, con)
                VendorIDCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
                VendorIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckVendorID = CStr(VendorIDCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckVendorID = ""
                End Try
                con.Close()

                'Reverse entries made by payable before deletion

                'Get AP Batch Number
                Dim APBatchNumberStatement As String = "SELECT BatchNumber FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim APBatchNumberCommand As New SqlCommand(APBatchNumberStatement, con)
                APBatchNumberCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                APBatchNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    APBatchNumber = CInt(APBatchNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    APBatchNumber = 0
                End Try
                con.Close()

                'Get batch date (Posting date)
                Dim BatchDateStatement As String = "SELECT BatchDate FROM ReceiptOfInvoiceBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
                Dim BatchDateCommand As New SqlCommand(BatchDateStatement, con)
                BatchDateCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = APBatchNumber
                BatchDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    BatchDate = CStr(BatchDateCommand.ExecuteScalar)
                Catch ex As Exception
                    BatchDate = APVoucherDate
                End Try
                con.Close()

                'Get Discount if any to reverse...
                Dim DiscountAmountStatement As String = "SELECT DiscountAmount FROM APVoucherTable WHERE DivisionID = @DivisionID AND VoucherNumber = @VoucherNumber"
                Dim DiscountAmountCommand As New SqlCommand(DiscountAmountStatement, con)
                DiscountAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                DiscountAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    DiscountAmount = CDbl(DiscountAmountCommand.ExecuteScalar)
                Catch ex As Exception
                    DiscountAmount = 0
                End Try
                con.Close()

                'Get Vendor Class if Canadian, to determine correct GL
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    'Get Vendor Class
                    Dim CheckVendorIDStatement As String = "SELECT VendorClass FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                    Dim CheckVendorIDCommand As New SqlCommand(CheckVendorIDStatement, con)
                    CheckVendorIDCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = CheckVendorID
                    CheckVendorIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        VendorClass = CStr(CheckVendorIDCommand.ExecuteScalar)
                    Catch ex As Exception
                        VendorClass = "CANADIAN"
                    End Try
                    con.Close()

                    If VendorClass = "AMERICAN" Then
                        GLPayablesAccount = "20000"
                        GLDiscountAccount = "69900"
                        GLBankAccount = "10200"
                        GLTaxAccount = "78000"
                        GLFreightAccount = "62000"
                    Else
                        GLPayablesAccount = "C$20000"
                        GLDiscountAccount = "C$69900"
                        GLBankAccount = "C$10200"
                        GLTaxAccount = "C$78000"
                        GLFreightAccount = "C$62000"
                    End If
                Else
                    GLPayablesAccount = "20000"
                    GLDiscountAccount = "69900"
                    GLBankAccount = "10200"
                    GLTaxAccount = "78000"
                    GLFreightAccount = "62000"
                End If
                '***************************************************************************************************
                If DiscountAmount > 0 Then
                    Try
                        'Writes first value to the General Ledger
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayablesAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Cancellation - Discount Amount"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = BatchDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = DiscountAmount
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Check Number " & cboCheckNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = APBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = APVoucherNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Writes the second value to GL Transactions
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLDiscountAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Cancellation - Discount Amount"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = BatchDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = DiscountAmount
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Check Number " & cboCheckNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = APBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = APVoucherNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBatchNumber As Integer = 0
                        Dim TempVoucherNumber As Integer = 0
                        Dim strBatchNumber As String = ""
                        Dim strVoucherNumber As String = ""
                        TempBatchNumber = APBatchNumber
                        strBatchNumber = CStr(TempBatchNumber)
                        TempVoucherNumber = APVoucherNumber
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "AP Check Cancel --- Error posting discount to GL"
                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                Else
                    'Do nothing - no discount
                End If
                '***************************************************************************************************
                'Get Freight and sales tax to reverse
                Dim InvoiceFreightStatement As String = "SELECT InvoiceFreight FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim InvoiceFreightCommand As New SqlCommand(InvoiceFreightStatement, con)
                InvoiceFreightCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                InvoiceFreightCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim InvoiceSalesTaxStatement As String = "SELECT InvoiceSalesTax FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim InvoiceSalesTaxCommand As New SqlCommand(InvoiceSalesTaxStatement, con)
                InvoiceSalesTaxCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                InvoiceSalesTaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
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
                '***************************************************************************************************
                If InvoiceFreight <> 0 Then
                    Try
                        'Writes first value to the General Ledger
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLFreightAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Cancellation - Freight"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = BatchDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = InvoiceFreight
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Check Number " & cboCheckNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = APBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = APVoucherNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Writes the second value to GL Transactions
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayablesAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Cancellation - Freight"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = BatchDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = InvoiceFreight
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Check Number " & cboCheckNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = APBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = APVoucherNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBatchNumber As Integer = 0
                        Dim TempVoucherNumber As Integer = 0
                        Dim strBatchNumber As String = ""
                        Dim strVoucherNumber As String = ""
                        TempBatchNumber = APBatchNumber
                        strBatchNumber = CStr(TempBatchNumber)
                        TempVoucherNumber = APVoucherNumber
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "AP Check Cancel --- Error posting invoice freight to GL"
                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                Else
                    'Do nothing - no freight
                End If
                '***************************************************************************************************
                If InvoiceSalesTax <> 0 Then
                    Try
                        'Writes first value to the General Ledger
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLTaxAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Cancellation - Sales Tax"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = BatchDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = InvoiceSalesTax
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Check Number " & cboCheckNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = APBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = APVoucherNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Writes the second value to GL Transactions
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayablesAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Cancellation - Sales Tax"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = BatchDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = InvoiceSalesTax
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Check Number " & cboCheckNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = APBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = APVoucherNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempBatchNumber As Integer = 0
                        Dim TempVoucherNumber As Integer = 0
                        Dim strBatchNumber As String = ""
                        Dim strVoucherNumber As String = ""
                        TempBatchNumber = APBatchNumber
                        strBatchNumber = CStr(TempBatchNumber)
                        TempVoucherNumber = APVoucherNumber
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "AP Check Cancel --- Error posting invoice sales tax to GL"
                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                Else
                    'Do nothing - no sales tax
                End If
                '***************************************************************************************************
                'Count Voucher Lines to run reversal routine
                Dim CountVoucherLinesStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber"
                Dim CountVoucherLinesCommand As New SqlCommand(CountVoucherLinesStatement, con)
                CountVoucherLinesCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountVoucherLines = CInt(CountVoucherLinesCommand.ExecuteScalar)
                Catch ex As Exception
                    CountVoucherLines = 0
                End Try
                con.Close()

                Dim VoucherLine As Integer = 1
                Dim LineDebitAccount, LineCreditAccount As String
                Dim LineExtendedAmount As Double = 0

                'Run FOR/NEXT Loop to undo Voucher Lines
                For i As Integer = 1 To CountVoucherLines
                    Dim GetLineDataString As String = "SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                    Dim GetLineDataCommand As New SqlCommand(GetLineDataString, con)
                    GetLineDataCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                    GetLineDataCommand.Parameters.Add("@VoucherLine", SqlDbType.VarChar).Value = VoucherLine

                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim LineReader As SqlDataReader = GetLineDataCommand.ExecuteReader()
                    If LineReader.HasRows Then
                        LineReader.Read()
                        If IsDBNull(LineReader.Item("ExtendedAmount")) Then
                            LineExtendedAmount = 0
                        Else
                            LineExtendedAmount = LineReader.Item("ExtendedAmount")
                        End If
                        If IsDBNull(LineReader.Item("GLDebitAccount")) Then
                            LineDebitAccount = "20999"
                        Else
                            LineDebitAccount = LineReader.Item("GLDebitAccount")
                        End If
                        If IsDBNull(LineReader.Item("GLCreditAccount")) Then
                            LineCreditAccount = "20000"
                        Else
                            LineCreditAccount = LineReader.Item("GLCreditAccount")
                        End If
                        If IsDBNull(LineReader.Item("ReceiverNumber")) Then
                            ReceiverNumber = 0
                        Else
                            ReceiverNumber = LineReader.Item("ReceiverNumber")
                        End If
                        If IsDBNull(LineReader.Item("ReceiverLine")) Then
                            ReceiverLineNumber = 0
                        Else
                            ReceiverLineNumber = LineReader.Item("ReceiverLine")
                        End If
                    Else
                        LineExtendedAmount = 0
                        LineDebitAccount = "20999"
                        LineCreditAccount = "20000"
                        ReceiverNumber = 0
                        ReceiverLineNumber = 0
                    End If
                    LineReader.Close()
                    con.Close()
                    '***********************************************************************************
                    'Get posting date
                    Dim PostingDateString As String = "SELECT MAX(GLTransactionDate) FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND GLReferenceLine = @GLReferenceLine AND DivisionID = @DivisionID"
                    Dim PostingDateCommand As New SqlCommand(PostingDateString, con)
                    PostingDateCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = APVoucherNumber
                    PostingDateCommand.Parameters.Add("@GLReferenceLine", SqlDbType.VarChar).Value = VoucherLine
                    PostingDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        APPostDate = CStr(PostingDateCommand.ExecuteScalar)
                    Catch ex As Exception
                        APPostDate = APVoucherDate
                    End Try
                    con.Close()
                    '***********************************************************************************
                    'Reset Receiver
                    Try
                        cmd = New SqlCommand("UPDATE ReceivingLineTable SET SelectForInvoice = @SelectForInvoice WHERE ReceivingHeaderKey = @ReceivingHeaderKey and ReceivingLineKey = @ReceivingLineKey", con)

                        With cmd.Parameters
                            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                            .Add("@ReceivingLineKey", SqlDbType.VarChar).Value = ReceiverLineNumber
                            .Add("@SelectForInvoice", SqlDbType.VarChar).Value = "OPEN"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempReceiverNumber As Integer = 0
                        Dim strReceiverNumber As String = ""
                        TempReceiverNumber = ReceiverNumber
                        strReceiverNumber = CStr(TempReceiverNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "AP Check Cancel --- Error resetting receiver lines to OPEN"
                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '***********************************************************************************
                    Try
                        cmd = New SqlCommand("UPDATE ReceivingHeaderTable SET Status = @Status WHERE ReceivingHeaderKey = @ReceivingHeaderKey and DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = ReceiverNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@Status", SqlDbType.VarChar).Value = "RECEIVED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempReceiverNumber As Integer = 0
                        Dim strReceiverNumber As String = ""
                        TempReceiverNumber = ReceiverNumber
                        strReceiverNumber = CStr(TempReceiverNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "AP Check Cancel --- Error resetting receiver header to RECEIVED"
                        ErrorReferenceNumber = "Receiver # " + strReceiverNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '***********************************************************************************
                    'Reverse entries in the GL

                    'Get Vendor Class if ALB/TFF/TOR to determine American or Canadian GLs
                    If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                        'Get Vendor Class from Voucher
                        Dim VoucherVendorClass As String = ""

                        Dim GetVoucherVendorClassStatement As String = "SELECT VendorClass FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VoucherNumber = @VoucherNumber"
                        Dim GetVoucherVendorClassCommand As New SqlCommand(GetVoucherVendorClassStatement, con)
                        GetVoucherVendorClassCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                        GetVoucherVendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            VoucherVendorClass = CStr(GetVoucherVendorClassCommand.ExecuteScalar)
                        Catch ex As Exception
                            VoucherVendorClass = "CANADIAN"
                        End Try
                        con.Close()

                        If VoucherVendorClass = "CANADIAN" Then
                            LineCreditAccount = "C$" & LineCreditAccount
                            LineDebitAccount = "C$" & LineDebitAccount
                        Else
                            'Do nothing - GL Accounts are correct
                        End If
                    Else
                        'Do nothing -- GL Accounts are correct
                    End If
                    '***********************************************************************************
                    Try
                        'Writes first value to the General Ledger
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineDebitAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Cancellation - Undo Voucher Posting"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = APPostDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Check Number " & cboCheckNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = APBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = APVoucherNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = VoucherLine
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempVoucherNumber As Integer = 0
                        Dim strVoucherNumber As String = ""
                        TempVoucherNumber = APVoucherNumber
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "AP Check Cancel --- Error posting credit to GL"
                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '******************************************************************************************************
                    Try
                        'Writes second value to the General Ledger
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber + 1
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineCreditAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Cancellation - Undo Voucher Posting"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = APPostDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Check Number " & cboCheckNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = APBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = APVoucherNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = VoucherLine
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempVoucherNumber As Integer = 0
                        Dim strVoucherNumber As String = ""
                        TempVoucherNumber = APVoucherNumber
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "AP Check Cancel --- Error posting debit to GL"
                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    VoucherLine = VoucherLine + 1
                Next i
                '***************************************************************************************************************
                'Get Voucher Header Data to copy to delete table
                Dim ROIPONumber, ROIBatchNumber, ROIDeleteReferenceNumber As Integer
                Dim ROIProductTotal, ROIInvoiceTotal, ROIInvoiceFreight, ROIInvoiceSalesTax, ROIInvoiceAmount, ROIDiscountAmount As Double
                Dim ROIInvoiceNumber, ROIInvoiceDate, ROIReceiptDate, ROIVendorID, ROIVendorClass, ROIPaymentTerms, ROIDiscountDate, ROIComment, ROIDueDate, ROIVoucherStatus, ROIVoucherSource As String

                Dim DeleteHeaderDataString As String = "SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID"
                Dim DeleteHeaderDataCommand As New SqlCommand(DeleteHeaderDataString, con)
                DeleteHeaderDataCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
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
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = ROIBatchNumber
                        .Add("@PONumber", SqlDbType.VarChar).Value = ROIPONumber
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = ROIInvoiceNumber
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = ROIReceiptDate
                        .Add("@ReceiptDate", SqlDbType.VarChar).Value = ROIVendorID
                        .Add("@VendorID", SqlDbType.VarChar).Value = ROIVendorID
                        .Add("@VendorClass", SqlDbType.VarChar).Value = ROIVendorID
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
                    TempVoucherNumber = APVoucherNumber
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Check Cancel --- Error creating Deleted Voucher Header"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                'Insert Lines into Delete Table
                Dim ROIPartNumber, ROIPartDescription, ROIGLDebitAccount, ROIGLCreditAccount, ROISelectForInvoice As String
                Dim ROIQuantity, ROIUnitCost, ROIExtendedAmount As Double
                Dim ROIReceiverNumber, ROIReceiverLine, ROIVoucherLine As Integer

                ROIVoucherLine = 1

                For i As Integer = 1 To CountVoucherLines
                    Dim GetLineDataString As String = "SELECT * FROM ReceiptOfInvoiceVoucherLines WHERE VoucherNumber = @VoucherNumber AND VoucherLine = @VoucherLine"
                    Dim GetLineDataCommand As New SqlCommand(GetLineDataString, con)
                    GetLineDataCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
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
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
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
                        TempVoucherNumber = APVoucherNumber
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "AP Check Cancel --- Error creating Deleted Voucher Line"
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
                '************************************************************************************************************
                'If check item count is zero, run routine

                If CheckItemsCount = 0 Then
                    'Get check amount for selected check
                    Dim ReverseCheckAmountStatement As String = "SELECT CheckAmount FROM APCheckLog WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID"
                    Dim ReverseCheckAmountCommand As New SqlCommand(ReverseCheckAmountStatement, con)
                    ReverseCheckAmountCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
                    ReverseCheckAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ReverseCheckAmount = CDbl(ReverseCheckAmountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ReverseCheckAmount = 0
                    End Try
                    con.Close()

                    Try
                        'Command to write Line Amount to Payables (to undo check)
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayablesAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Processing"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpCancelPostDate.Text
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ReverseCheckAmount
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "AP Check Batch Cancellation"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = APBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempCheckNumber As Int64 = 0
                        Dim strCheckNumber2 As String = ""
                        TempCheckNumber = Val(cboCheckNumber.Text)
                        strCheckNumber2 = CStr(TempCheckNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "AP Check Cancel --- Error posting credit check amount to GL"
                        ErrorReferenceNumber = "Check # " + strCheckNumber2
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    Try
                        'Command to write LineAmount to Bank Account
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLBankAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Processing"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpCancelPostDate.Text
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ReverseCheckAmount
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "AP Check Batch Cancellation"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = APBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempCheckNumber As Int64 = 0
                        Dim strCheckNumber2 As String = ""
                        TempCheckNumber = Val(cboCheckNumber.Text)
                        strCheckNumber2 = CStr(TempCheckNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "AP Check Cancel --- Error posting debit check amount to GL"
                        ErrorReferenceNumber = "Check # " + strCheckNumber2
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '*******************************************************************************************************
                    'Write to Audit Trail Table
                    Dim AuditComment As String = ""
                    Dim AuditCheckNumber As Int64 = 0
                    Dim strCheckNumber As String = ""

                    AuditCheckNumber = Val(cboCheckNumber.Text)
                    strCheckNumber = CStr(AuditCheckNumber)
                    AuditComment = "Check #" + strCheckNumber + " for vendor " + CheckVendorID + " was cancelled on " + Today()

                    cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                    With cmd.Parameters
                        .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@AuditType", SqlDbType.VarChar).Value = "CHECK CANCELLATION - DELETION"
                        .Add("@AuditAmount", SqlDbType.VarChar).Value = ReverseCheckAmount
                        .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strCheckNumber
                        .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                        .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                'Update CheckItemsCount
                CheckItemsCount = CheckItemsCount + 1

                '**********************************
                'End of Ledger Entry
                '**********************************

                '*******************************************************************************************************
                'Delete Payable
                Try
                    cmd = New SqlCommand("DELETE FROM ReceiptOfInvoiceBatchLine WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String = ""
                    TempVoucherNumber = APVoucherNumber
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Check Cancel --- Delete voucher"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*********************************************************************************************************
                'Delete payment voucher from APVoucherTable
                Try
                    'UPDATE Purchase Order Extended Amount based on line changes
                    cmd = New SqlCommand("DELETE FROM APVoucherTable WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String = ""
                    TempVoucherNumber = APVoucherNumber
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Check Cancel --- Delete payable"
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Next
            '***************************************************************************************************************************************
            'Update APCheck Log to show cancelled check
            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE APCheckLog SET CheckStatus = @CheckStatus  WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@CheckNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CheckStatus", SqlDbType.VarChar).Value = "CANCELLED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempCheckNumber As Int64 = 0
                Dim strCheckNumber2 As String = ""
                TempCheckNumber = Val(cboCheckNumber.Text)
                strCheckNumber2 = CStr(TempCheckNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "AP Check Cancel --- SET AP Check Record to CANCELLED"
                ErrorReferenceNumber = "Check # " + strCheckNumber2
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            MsgBox("Check has been Cancelled.", MsgBoxStyle.OkOnly)

            ClearData()
            ShowCheckLog()
            LoadCheckData()
        End If
    End Sub

    Private Function canCancel() As Boolean
        'Prompt before Saving
        Dim button As DialogResult = MessageBox.Show("Do you wish to Cancel this check?", "CANCEL CHECK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        If String.IsNullOrEmpty(cboCheckNumber.Text) Then
            MsgBox("You must have a valid Check Number selected.", MsgBoxStyle.OkOnly)
            cboCheckNumber.Focus()
            Return False
        End If
        If cboCheckNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid check number", "Enter a valid check number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCheckNumber.SelectAll()
            cboCheckNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub DeleteCheckPayableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteCheckPayableToolStripMenuItem.Click
        cmdCancel_Click(sender, e)
    End Sub

    Private Sub ReverseCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReverseCheckToolStripMenuItem.Click
        cmdReverse_Click(sender, e)
    End Sub

    Private Sub cmdReverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReverse.Click
        If canReverse() Then
            '******************************************************************************************************
            'Validate Date
            Dim CurrentDate As Date
            Dim MonthOfYear, YearOfYear, TodaysMonthOfYear, TodaysYearOfYear As Integer

            CurrentDate = dtpPostDate.Value

            MonthOfYear = CurrentDate.Month
            YearOfYear = CurrentDate.Year
            TodaysMonthOfYear = TodaysDate.Month
            TodaysYearOfYear = TodaysDate.Year

            If TodaysYearOfYear - YearOfYear > 1 Then
                MsgBox("You cannot post a Reversal to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                Exit Sub
            ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear < 5 And (TodaysMonthOfYear >= 1 And TodaysMonthOfYear < 5) Then
                MsgBox("You cannot post a Reversal to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                Exit Sub
            ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear > 5 And (TodaysMonthOfYear >= 5 And TodaysMonthOfYear <= 12) Then
                MsgBox("You cannot post a Reversal to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                Exit Sub
                'ElseIf TodaysYearOfYear - YearOfYear = 0 And MonthOfYear < 5 And TodaysMonthOfYear >= 5 Then
                'MsgBox("You cannot post a Reversal to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                'Exit Sub
            ElseIf TodaysYearOfYear - YearOfYear < 0 Then
                MsgBox("You cannot post a Reversal to a future period.", MsgBoxStyle.OkOnly)
                Exit Sub
            ElseIf TodaysYearOfYear - YearOfYear = 0 And TodaysMonthOfYear < MonthOfYear Then
                MsgBox("You cannot post a Reversal to a future period.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Date is okay --- Continue
            End If
            '******************************************************************************************************
            Dim VendorClass, CheckVendorID, GLPayablesAccount, GLDiscountAccount, GLBankAccount As String
            'Reverse AP Check and reset voucher
            For Each row As DataGridViewRow In dgvCheckLines.Rows
                APVoucherNumber = row.Cells("APVoucherNumberColumn").Value

                'Get Vendor ID
                Dim VendorIDStatement As String = "SELECT VendorID FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckNumber = @CheckNumber"
                Dim VendorIDCommand As New SqlCommand(VendorIDStatement, con)
                VendorIDCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
                VendorIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckVendorID = CStr(VendorIDCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckVendorID = ""
                End Try
                con.Close()

                'Validate Voucher Number
                If APVoucherNumber = 0 Then
                    MsgBox("Unable to reset selected voucher. Select and try again.", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                'Rest Voucher so it can be selected again.
                Try
                    'UPDATE Receipt Of Invoice so it can be selected
                    cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String = ""
                    TempVoucherNumber = APVoucherNumber
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Check Reverse - Error setting voucher to posted."
                    ErrorReferenceNumber = "Check # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                'Get Vendor Class if TFF/TOR/ALB, to determine correct GL
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    'Get Vendor Class
                    Dim GetVendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                    Dim GetVendorClassCommand As New SqlCommand(GetVendorClassStatement, con)
                    GetVendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = CheckVendorID
                    GetVendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        VendorClass = CStr(GetVendorClassCommand.ExecuteScalar)
                    Catch ex As Exception
                        VendorClass = "CANADIAN"
                    End Try
                    con.Close()

                    If VendorClass = "AMERICAN" Then
                        GLPayablesAccount = "20000"
                        GLDiscountAccount = "69900"
                        GLBankAccount = "10200"
                    Else
                        GLPayablesAccount = "C$20000"
                        GLDiscountAccount = "C$69900"
                        GLBankAccount = "C$10200"
                    End If
                Else
                    GLPayablesAccount = "20000"
                    GLDiscountAccount = "69900"
                    GLBankAccount = "10200"
                End If

                'Get Discount if any to reverse...
                Dim DiscountAmountStatement As String = "SELECT DiscountAmount FROM APVoucherTable WHERE DivisionID = @DivisionID AND VoucherNumber = @VoucherNumber"
                Dim DiscountAmountCommand As New SqlCommand(DiscountAmountStatement, con)
                DiscountAmountCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                DiscountAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    DiscountAmount = CDbl(DiscountAmountCommand.ExecuteScalar)
                Catch ex As Exception
                    DiscountAmount = 0
                End Try
                con.Close()

                If DiscountAmount > 0 Then
                    Try
                        'Writes first value to the General Ledger
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount, @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayablesAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Cancellation - Discount Amount"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpPostDate.Text
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = DiscountAmount
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Check Number " & cboCheckNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = APVoucherNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Writes the second value to GL Transactions
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLDiscountAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Cancellation - Discount Amount"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpPostDate.Text
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = DiscountAmount
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Check Number " & cboCheckNumber.Text
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = APVoucherNumber
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempVoucherNumber As Integer = 0
                        Dim strVoucherNumber As String = ""
                        TempVoucherNumber = APVoucherNumber
                        strVoucherNumber = CStr(TempVoucherNumber)

                        ErrorDate = TodaysDate
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "AP Check Reversal - Error G/L Posting."
                        ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                Else
                    'Do nothing - no discount
                End If

                'Change Status of APVoucherTable
                Try
                    'UPDATE AP Voucher Table to show cancelled status
                    cmd = New SqlCommand("DELETE FROM APVoucherTable WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@VoucherNumber", SqlDbType.VarChar).Value = APVoucherNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempVoucherNumber As Integer = 0
                    Dim strVoucherNumber As String = ""
                    TempVoucherNumber = APVoucherNumber
                    strVoucherNumber = CStr(TempVoucherNumber)

                    ErrorDate = TodaysDate
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "AP Check Reversal - Error deleting AP Voucher."
                    ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Next

            'Change Status of APCheck Log to show canceled
            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE APCheckLog SET CheckStatus = @CheckStatus WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@CheckNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@CheckStatus", SqlDbType.VarChar).Value = "CANCELLED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempCheckNumber As Int64 = 0
                Dim strCheckNumber2 As String = ""
                TempCheckNumber = Val(cboCheckNumber.Text)
                strCheckNumber2 = CStr(TempCheckNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "AP Check Reversal - Error setting check log to cancelled."
                ErrorReferenceNumber = "Check # " + strCheckNumber2
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Get Check Amount for selected check
            Dim ReverseCheckAmountStatement As String = "SELECT CheckAmount FROM APCheckLog WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID"
            Dim ReverseCheckAmountCommand As New SqlCommand(ReverseCheckAmountStatement, con)
            ReverseCheckAmountCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
            ReverseCheckAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim ReverseCheckVendorStatement As String = "SELECT VendorID FROM APCheckLog WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID"
            Dim ReverseCheckVendorCommand As New SqlCommand(ReverseCheckVendorStatement, con)
            ReverseCheckVendorCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
            ReverseCheckVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ReverseCheckAmount = CDbl(ReverseCheckAmountCommand.ExecuteScalar)
            Catch ex As Exception
                ReverseCheckAmount = 0
            End Try
            Try
                CheckVendorID = CStr(ReverseCheckVendorCommand.ExecuteScalar)
            Catch ex As Exception
                CheckVendorID = ""
            End Try
            con.Close()

            'Get Vendor Class if TFF/ALB/TOR, to determine correct GL
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                'Get Vendor Class
                Dim GetVendorClassStatement As String = "SELECT VendorClass FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                Dim GetVendorClassCommand As New SqlCommand(GetVendorClassStatement, con)
                GetVendorClassCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = CheckVendorID
                GetVendorClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    VendorClass = CStr(GetVendorClassCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorClass = "CANADIAN"
                End Try
                con.Close()

                If VendorClass = "AMERICAN" Then
                    GLPayablesAccount = "20000"
                    GLDiscountAccount = "69900"
                    GLBankAccount = "10200"
                Else
                    GLPayablesAccount = "C$20000"
                    GLDiscountAccount = "C$69900"
                    GLBankAccount = "C$10200"
                End If
            Else
                GLPayablesAccount = "20000"
                GLDiscountAccount = "69900"
                GLBankAccount = "10200"
            End If
            '***********************************************************************************
            Try
                'Command to write Line Amount to Payables
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount, GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount, @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLPayablesAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Processing"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpPostDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ReverseCheckAmount
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "AP Check Batch Reversal"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempCheckNumber As Int64 = 0
                Dim strCheckNumber2 As String = ""
                TempCheckNumber = Val(cboCheckNumber.Text)
                strCheckNumber2 = CStr(TempCheckNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "AP Check Reversal - Error posting to G/L"
                ErrorReferenceNumber = "Check # " + strCheckNumber2
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            Try
                'Command to write LineAmount to Bank Account
                cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                With cmd.Parameters
                    '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber + 1
                    .Add("@GLAccountNumber", SqlDbType.VarChar).Value = GLBankAccount
                    .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "AP Check Processing"
                    .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpPostDate.Text
                    .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ReverseCheckAmount
                    .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "AP Check Batch Reversal"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@GLJournalID", SqlDbType.VarChar).Value = "APJOURNAL"
                    .Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboCheckNumber.Text)
                    .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 0
                    .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempCheckNumber As Int64 = 0
                Dim strCheckNumber2 As String = ""
                TempCheckNumber = Val(cboCheckNumber.Text)
                strCheckNumber2 = CStr(TempCheckNumber)

                ErrorDate = TodaysDate
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "AP Check Reversal - Error posting to G/L"
                ErrorReferenceNumber = "Check # " + strCheckNumber2
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**********************************
            'End of Ledger Entry
            '**********************************

            '*******************************************************************************************************
            'Write to Audit Trail Table
            Dim AuditComment As String = ""
            Dim AuditCheckNumber As Int64 = 0
            Dim strCheckNumber As String = ""

            AuditCheckNumber = Val(cboCheckNumber.Text)
            strCheckNumber = CStr(AuditCheckNumber)
            AuditComment = "Check #" + strCheckNumber + " for vendor " + CheckVendorID + " was reversed on " + Today()

            cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

            With cmd.Parameters
                .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@AuditType", SqlDbType.VarChar).Value = "CHECK REVERSAL - DELETION"
                .Add("@AuditAmount", SqlDbType.VarChar).Value = ReverseCheckAmount
                .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strCheckNumber
                .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            '*******************************************************************************************************
            MsgBox("Check has been reversed.", MsgBoxStyle.OkOnly)

            ClearData()
            ShowCheckLog()
            LoadCheckData()
        Else
            MessageBox.Show("Check was not reversed", "Check not reversed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Function canReverse() As Boolean
        'Prompt before Saving
        Dim button As DialogResult = MessageBox.Show("Do you wish to Reverse this check?", "REVERSE CHECK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        If String.IsNullOrEmpty(cboCheckNumber.Text) Then
            MsgBox("You must have a valid Check Number selected.", MsgBoxStyle.OkOnly)
            cboCheckNumber.Focus()
            Return False
        End If
        If cboCheckNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid check number", "Enter a valid check number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCheckNumber.SelectAll()
            cboCheckNumber.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class