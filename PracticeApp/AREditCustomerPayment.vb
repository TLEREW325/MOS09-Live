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
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Public Class AREditCustomerPayment
    Inherits System.Windows.Forms.Form

    Dim PaymentDate, PaymentType, CustomerID, InvoiceDate, CheckNumber, CardNumber, CardDate, AuthorizationNumber, ReferenceNumber, CheckComment, CreditComment, Status, TenderType, CardType, BankAccount As String
    Dim PaymentAmount, DiscountAmount, InvoiceAmount As Double
    Dim InvoiceNumber, ARTransactionKey, BatchNumber, PaymentID, PaymentLineNumber As Integer
    Dim DebitDescription, CreditDescription, GLTransactionDate, GLCreditAccount, GLDebitAccount As String
    Dim GLCreditAmount, GLDebitAmount As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim dt As DataTable

    Private Sub AREditCustomerPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        ClearData()
        ClearVariables()
        LoadCustomer()
    End Sub

    Public Sub LoadCustomer()
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CustomerList")
        cboCustomerID.DataSource = ds1.Tables("CustomerList")
        cboCustomerName.DataSource = ds1.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadTransactionsByCustomer()
        cmd = New SqlCommand("SELECT ARTransactionKey FROM ARCustomerPayment WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ARCustomerPayment")
        cboARTransactionNumber.DataSource = ds2.Tables("ARCustomerPayment")
        con.Close()
        cboARTransactionNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadTransactionsByCustomerAndDate()
        cmd = New SqlCommand("SELECT ARTransactionKey FROM ARCustomerPayment WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID AND PaymentDate = @PaymentDate", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpSelectDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ARCustomerPayment")
        cboARTransactionNumber.DataSource = ds2.Tables("ARCustomerPayment")
        con.Close()
        cboARTransactionNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerPaymentDetails()
        Dim ARPaymentDateString As String = "SELECT PaymentDate FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim ARPaymentDateCommand As New SqlCommand(ARPaymentDateString, con)
        ARPaymentDateCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        ARPaymentDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ARPaymentTypeString As String = "SELECT PaymentType FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim ARPaymentTypeCommand As New SqlCommand(ARPaymentTypeString, con)
        ARPaymentTypeCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        ARPaymentTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceNumberString As String = "SELECT InvoiceNumber FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim InvoiceNumberCommand As New SqlCommand(InvoiceNumberString, con)
        InvoiceNumberCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        InvoiceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceDateString As String = "SELECT InvoiceDate FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim InvoiceDateCommand As New SqlCommand(InvoiceDateString, con)
        InvoiceDateCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        InvoiceDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim InvoiceAmountString As String = "SELECT InvoiceAmount FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim InvoiceAmountCommand As New SqlCommand(InvoiceAmountString, con)
        InvoiceAmountCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        InvoiceAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim DiscountAmountString As String = "SELECT DiscountAmount FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim DiscountAmountCommand As New SqlCommand(DiscountAmountString, con)
        DiscountAmountCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        DiscountAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PaymentAmountString As String = "SELECT PaymentAmount FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim PaymentAmountCommand As New SqlCommand(PaymentAmountString, con)
        PaymentAmountCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        PaymentAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CheckNumberString As String = "SELECT CheckNumber FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim CheckNumberCommand As New SqlCommand(CheckNumberString, con)
        CheckNumberCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        CheckNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CardNumberString As String = "SELECT CardNumber FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim CardNumberCommand As New SqlCommand(CardNumberString, con)
        CardNumberCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        CardNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CardDateString As String = "SELECT CardDate FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim CardDateCommand As New SqlCommand(CardDateString, con)
        CardDateCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        CardDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim AuthorizationNumberString As String = "SELECT AuthorizationNumber FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim AuthorizationNumberCommand As New SqlCommand(AuthorizationNumberString, con)
        AuthorizationNumberCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        AuthorizationNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim ReferenceNumberString As String = "SELECT ReferenceNumber FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim ReferenceNumberCommand As New SqlCommand(ReferenceNumberString, con)
        ReferenceNumberCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        ReferenceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CheckCommentString As String = "SELECT CheckComment FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim CheckCommentCommand As New SqlCommand(CheckCommentString, con)
        CheckCommentCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        CheckCommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreditCommentString As String = "SELECT CreditComment FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim CreditCommentCommand As New SqlCommand(CreditCommentString, con)
        CreditCommentCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        CreditCommentCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim StatusString As String = "SELECT Status FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim StatusCommand As New SqlCommand(StatusString, con)
        StatusCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        StatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim TenderTypeString As String = "SELECT TenderType FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim TenderTypeCommand As New SqlCommand(TenderTypeString, con)
        TenderTypeCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        TenderTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CardTypeString As String = "SELECT CardType FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim CardTypeCommand As New SqlCommand(CardTypeString, con)
        CardTypeCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        CardTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BankAccountString As String = "SELECT BankAccount FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim BankAccountCommand As New SqlCommand(BankAccountString, con)
        BankAccountCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        BankAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BatchNumberString As String = "SELECT BatchNumber FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim BatchNumberCommand As New SqlCommand(BatchNumberString, con)
        BatchNumberCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        BatchNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PaymentIDString As String = "SELECT PaymentID FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim PaymentIDCommand As New SqlCommand(PaymentIDString, con)
        PaymentIDCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        PaymentIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim PaymentLineNumberString As String = "SELECT PaymentLineNumber FROM ARCustomerPayment WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID"
        Dim PaymentLineNumberCommand As New SqlCommand(PaymentLineNumberString, con)
        PaymentLineNumberCommand.Parameters.Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        PaymentLineNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PaymentDate = CStr(ARPaymentDateCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentDate = ""
        End Try
        Try
            PaymentType = CStr(ARPaymentTypeCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentType = ""
        End Try
        Try
            InvoiceNumber = CInt(InvoiceNumberCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceNumber = 0
        End Try
        Try
            InvoiceDate = CStr(InvoiceDateCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceDate = ""
        End Try
        Try
            InvoiceAmount = CDbl(InvoiceAmountCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceAmount = 0
        End Try
        Try
            DiscountAmount = CDbl(DiscountAmountCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountAmount = 0
        End Try
        Try
            PaymentAmount = CDbl(PaymentAmountCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentAmount = 0
        End Try
        Try
            CheckNumber = CStr(CheckNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CheckNumber = ""
        End Try
        Try
            CardNumber = CStr(CardNumberCommand.ExecuteScalar)
        Catch ex As Exception
            CardNumber = ""
        End Try
        Try
            CardDate = CStr(CardDateCommand.ExecuteScalar)
        Catch ex As Exception
            CardDate = ""
        End Try
        Try
            AuthorizationNumber = CStr(AuthorizationNumberCommand.ExecuteScalar)
        Catch ex As Exception
            AuthorizationNumber = ""
        End Try
        Try
            ReferenceNumber = CStr(ReferenceNumberCommand.ExecuteScalar)
        Catch ex As Exception
            ReferenceNumber = ""
        End Try
        Try
            CheckComment = CStr(CheckCommentCommand.ExecuteScalar)
        Catch ex As Exception
            CheckComment = ""
        End Try
        Try
            CreditComment = CStr(CreditCommentCommand.ExecuteScalar)
        Catch ex As Exception
            CreditComment = ""
        End Try
        Try
            Status = CStr(StatusCommand.ExecuteScalar)
        Catch ex As Exception
            Status = ""
        End Try
        Try
            TenderType = CStr(TenderTypeCommand.ExecuteScalar)
        Catch ex As Exception
            TenderType = ""
        End Try
        Try
            CardType = CStr(CardTypeCommand.ExecuteScalar)
        Catch ex As Exception
            CardType = 0
        End Try
        Try
            BankAccount = CStr(BankAccountCommand.ExecuteScalar)
        Catch ex As Exception
            BankAccount = 0
        End Try
        Try
            BatchNumber = CInt(BatchNumberCommand.ExecuteScalar)
        Catch ex As Exception
            BatchNumber = 0
        End Try
        Try
            PaymentID = CInt(PaymentIDCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentID = 0
        End Try
        Try
            PaymentLineNumber = CInt(PaymentLineNumberCommand.ExecuteScalar)
        Catch ex As Exception
            PaymentLineNumber = 0
        End Try
        con.Close()

        txtBatchNumber.Text = BatchNumber
        txtPaymentDate.Text = PaymentDate
        txtAuthorizationNumber.Text = AuthorizationNumber
        txtBankAccount.Text = BankAccount
        txtCardDate.Text = CardDate
        txtCardNumber.Text = CardNumber
        txtCardType.Text = CardType
        txtCheckComment.Text = CheckComment
        txtCheckNumber.Text = CheckNumber
        txtCreditComment.Text = CreditComment
        txtDiscountAmount.Text = FormatCurrency(DiscountAmount, 2)
        txtInvoiceAmount.Text = FormatCurrency(InvoiceAmount, 2)
        txtInvoiceNumber.Text = InvoiceNumber
        txtPaymentAmount.Text = FormatCurrency(PaymentAmount, 2)
        txtPaymentDate.Text = PaymentDate
        txtPaymentID.Text = PaymentID
        txtPaymentLine.Text = PaymentLineNumber
        txtPaymentType.Text = PaymentType
        txtReferenceNumber.Text = ReferenceNumber
        txtStatus.Text = Status
        txtTenderType.Text = TenderType
    End Sub

    Public Sub LoadGLPosting()
        Dim GLTransactionDateString As String = "SELECT MIN(GLTransactionDate) FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID AND GLBatchNumber = @GLBatchNumber"
        Dim GLTransactionDateCommand As New SqlCommand(GLTransactionDateString, con)
        GLTransactionDateCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        GLTransactionDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GLTransactionDateCommand.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

        Dim GLTransactionDebitAmountString As String = "SELECT GLTransactionDebitAmount FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID AND GLBatchNumber = @GLBatchNumber AND GLTransactionDebitAmount <> 0 AND GLTransactionCreditAmount = 0"
        Dim GLTransactionDebitAmountCommand As New SqlCommand(GLTransactionDebitAmountString, con)
        GLTransactionDebitAmountCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        GLTransactionDebitAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GLTransactionDebitAmountCommand.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

        Dim GLTransactionCreditAmountString As String = "SELECT GLTransactionCreditAmount FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID AND GLBatchNumber = @GLBatchNumber AND GLTransactionCreditAmount <> 0 AND GLTransactionDebitAmount = 0"
        Dim GLTransactionCreditAmountCommand As New SqlCommand(GLTransactionCreditAmountString, con)
        GLTransactionCreditAmountCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        GLTransactionCreditAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GLTransactionCreditAmountCommand.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

        Dim GLDebitAccountNumberString As String = "SELECT GLAccountNumber FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID AND GLBatchNumber = @GLBatchNumber AND GLTransactionDebitAmount <> 0 AND GLTransactionCreditAmount = 0"
        Dim GLDebitAccountNumberCommand As New SqlCommand(GLDebitAccountNumberString, con)
        GLDebitAccountNumberCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        GLDebitAccountNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GLDebitAccountNumberCommand.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

        Dim GLCreditAccountNumberString As String = "SELECT GLAccountNumber FROM GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID AND GLBatchNumber = @GLBatchNumber AND GLTransactionCreditAmount <> 0 AND GLTransactionDebitAmount = 0"
        Dim GLCreditAccountNumberCommand As New SqlCommand(GLCreditAccountNumberString, con)
        GLCreditAccountNumberCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
        GLCreditAccountNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GLCreditAccountNumberCommand.Parameters.Add("@GLBatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GLTransactionDate = CStr(GLTransactionDateCommand.ExecuteScalar)
        Catch ex As Exception
            GLTransactionDate = ""
        End Try
        Try
            GLDebitAmount = CDbl(GLTransactionDebitAmountCommand.ExecuteScalar)
        Catch ex As Exception
            GLDebitAmount = 0
        End Try
        Try
            GLCreditAmount = CDbl(GLTransactionCreditAmountCommand.ExecuteScalar)
        Catch ex As Exception
            GLCreditAmount = 0
        End Try
        Try
            GLDebitAccount = CStr(GLDebitAccountNumberCommand.ExecuteScalar)
        Catch ex As Exception
            GLDebitAccount = ""
        End Try
        Try
            GLCreditAccount = CStr(GLCreditAccountNumberCommand.ExecuteScalar)
        Catch ex As Exception
            GLCreditAccount = ""
        End Try
        con.Close()

        txtPostDate.Text = GLTransactionDate
        txtDebitAccount.Text = GLDebitAccount
        txtCreditAccount.Text = GLCreditAccount
        txtDebitAmount.Text = FormatCurrency(GLDebitAmount, 2)
        txtCreditAmount.Text = FormatCurrency(GLCreditAmount, 2)
    End Sub

    Public Sub ClearData()
        cboARTransactionNumber.SelectedIndex = -1

        txtAuthorizationNumber.Clear()
        txtBankAccount.Clear()
        txtBatchNumber.Clear()
        txtCardDate.Clear()
        txtCardNumber.Clear()
        txtCardType.Clear()
        txtCheckComment.Clear()
        txtCheckNumber.Clear()
        txtCreditAccount.Clear()
        txtCreditAmount.Clear()
        txtCreditComment.Clear()
        txtDebitAccount.Clear()
        txtDebitAmount.Clear()
        txtDiscountAmount.Clear()
        txtInvoiceAmount.Clear()
        txtPaymentAmount.Clear()
        txtInvoiceNumber.Clear()
        txtPaymentDate.Clear()
        txtPaymentID.Clear()
        txtPaymentLine.Clear()
        txtPaymentType.Clear()
        txtPostDate.Clear()
        txtReferenceNumber.Clear()
        txtStatus.Clear()
        txtTenderType.Clear()
        txtCreditDescription.Clear()
        txtDebitDescription.Clear()

        dtpSelectDate.Text = ""

        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboARTransactionNumber.SelectedIndex = -1

        cboCustomerID.Focus()
    End Sub

    Public Sub LoadDebitDescription()
        If txtDebitAccount.Text = "" Then
            txtDebitDescription.Clear()
        Else
            Dim DebitDescriptionString As String = "SELECT GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
            Dim DebitDescriptionCommand As New SqlCommand(DebitDescriptionString, con)
            DebitDescriptionCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = txtDebitAccount.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                DebitDescription = CStr(DebitDescriptionCommand.ExecuteScalar)
            Catch ex As Exception
                DebitDescription = ""
            End Try

            txtDebitDescription.Text = DebitDescription
        End If
    End Sub

    Public Sub LoadCreditDescription()
        If txtCreditAccount.Text = "" Then
            txtCreditDescription.Clear()
        Else
            Dim CreditDescriptionString As String = "SELECT GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
            Dim CreditDescriptionCommand As New SqlCommand(CreditDescriptionString, con)
            CreditDescriptionCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = txtCreditAccount.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CreditDescription = CStr(CreditDescriptionCommand.ExecuteScalar)
            Catch ex As Exception
                CreditDescription = ""
            End Try

            txtCreditDescription.Text = CreditDescription
        End If
    End Sub

    Public Sub ClearVariables()
        PaymentDate = ""
        PaymentType = ""
        CustomerID = ""
        InvoiceDate = ""
        CheckNumber = ""
        CardNumber = ""
        CardDate = ""
        AuthorizationNumber = ""
        ReferenceNumber = ""
        CheckComment = ""
        CreditComment = ""
        Status = ""
        TenderType = ""
        CardType = ""
        BankAccount = ""
        PaymentAmount = 0
        DiscountAmount = 0
        InvoiceAmount = 0
        InvoiceNumber = 0
        ARTransactionKey = 0
        BatchNumber = 0
        PaymentID = 0
        PaymentLineNumber = 0
        DebitDescription = ""
        CreditDescription = ""
        GLTransactionDate = ""
        GLCreditAccount = ""
        GLDebitAccount = ""
        GLCreditAmount = 0
        GLDebitAmount = 0
    End Sub

    Private Sub txtDebitAccount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDebitAccount.TextChanged
        LoadDebitDescription()
    End Sub

    Private Sub txtCreditAccount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditAccount.TextChanged
        LoadCreditDescription()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        If chkCustomerOnly.Checked = True Then
            LoadTransactionsByCustomer()
        Else
            LoadTransactionsByCustomerAndDate()
        End If
    End Sub

    Private Sub dtpSelectDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSelectDate.ValueChanged
        If chkCustomerOnly.Checked = True Then
            LoadTransactionsByCustomer()
        Else
            LoadTransactionsByCustomerAndDate()
        End If
    End Sub

    Private Sub chkCustomerOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustomerOnly.CheckedChanged
        If chkCustomerOnly.Checked = True Then
            LoadTransactionsByCustomer()
        Else
            LoadTransactionsByCustomerAndDate()
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        ClearData()
        ClearVariables()
        LoadCustomer()
    End Sub

    Private Sub cboARTransactionNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboARTransactionNumber.SelectedIndexChanged
        'Dim TempTransactionNumber As Integer = Val(cboARTransactionNumber.Text)
        'ClearData()
        'cboARTransactionNumber.Text = TempTransactionNumber
        LoadCustomerPaymentDetails()
        LoadGLPosting()
    End Sub

    Private Sub cmdClearForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearForm.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub ClearAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearAllToolStripMenuItem.Click
        ClearVariables()
        ClearData()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalARTransactionNumber = Val(cboARTransactionNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintCustomerPaymentRecord As New PrintCustomerPaymentRecord
            Dim Result = NewPrintCustomerPaymentRecord.ShowDialog()
        End Using
    End Sub

    Private Sub PrintPaymentRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPaymentRecordToolStripMenuItem.Click
        GlobalARTransactionNumber = Val(cboARTransactionNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintCustomerPaymentRecord As New PrintCustomerPaymentRecord
            Dim Result = NewPrintCustomerPaymentRecord.ShowDialog()
        End Using
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboARTransactionNumber.Text = "" Or cboCustomerID.Text = "" Then
            MsgBox("You must have a valid customer and transaction # selected.", MsgBoxStyle.OkOnly)
        Else
            Try
                'Save Data to AR Customer Payment Database Table
                cmd = New SqlCommand("UPDATE ARCustomerPayment SET PaymentDate = @PaymentDate, PaymentType = @PaymentType, CheckNumber = @CheckNumber, CardNumber = @CardNumber, CardDate = @CardDate, AuthorizationNumber = @AuthorizationNumber, ReferenceNumber = @ReferenceNumber, CheckComment = @CheckComment, CreditComment = @CreditComment, TenderType = @TenderType, CardType = @CardType  WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PaymentDate", SqlDbType.VarChar).Value = txtPaymentDate.Text
                    .Add("@PaymentType", SqlDbType.VarChar).Value = txtPaymentType.Text
                    .Add("@CheckNumber", SqlDbType.VarChar).Value = txtCheckNumber.Text
                    .Add("@CardNumber", SqlDbType.VarChar).Value = txtCardNumber.Text
                    .Add("@CardDate", SqlDbType.VarChar).Value = txtCardDate.Text
                    .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = txtAuthorizationNumber.Text
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = txtReferenceNumber.Text
                    .Add("@CheckComment", SqlDbType.VarChar).Value = txtCheckComment.Text
                    .Add("@CreditComment", SqlDbType.VarChar).Value = txtCheckComment.Text
                    .Add("@TenderType", SqlDbType.VarChar).Value = txtTenderType.Text
                    .Add("@CardType", SqlDbType.VarChar).Value = txtCardType.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                MsgBox("Data could not be saved at this time.", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If cboARTransactionNumber.Text = "" Or cboCustomerID.Text = "" Then
            MsgBox("You must have a valid customer and transaction # selected.", MsgBoxStyle.OkOnly)
        Else
            Try
                'Save Data to AR Customer Payment Database Table
                cmd = New SqlCommand("UPDATE ARCustomerPayment SET PaymentDate = @PaymentDate, PaymentType = @PaymentType, CheckNumber = @CheckNumber, CardNumber = @CardNumber, CardDate = @CardDate, AuthorizationNumber = @AuthorizationNumber, ReferenceNumber = @ReferenceNumber, CheckComment = @CheckComment, CreditComment = @CreditComment, TenderType = @TenderType, CardType = @CardType  WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ARTransactionKey", SqlDbType.VarChar).Value = Val(cboARTransactionNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@PaymentDate", SqlDbType.VarChar).Value = txtPaymentDate.Text
                    .Add("@PaymentType", SqlDbType.VarChar).Value = txtPaymentType.Text
                    .Add("@CheckNumber", SqlDbType.VarChar).Value = txtCheckNumber.Text
                    .Add("@CardNumber", SqlDbType.VarChar).Value = txtCardNumber.Text
                    .Add("@CardDate", SqlDbType.VarChar).Value = txtCardDate.Text
                    .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = txtAuthorizationNumber.Text
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = txtReferenceNumber.Text
                    .Add("@CheckComment", SqlDbType.VarChar).Value = txtCheckComment.Text
                    .Add("@CreditComment", SqlDbType.VarChar).Value = txtCheckComment.Text
                    .Add("@TenderType", SqlDbType.VarChar).Value = txtTenderType.Text
                    .Add("@CardType", SqlDbType.VarChar).Value = txtCardType.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Changes have been saved.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                MsgBox("Data could not be saved at this time.", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

End Class