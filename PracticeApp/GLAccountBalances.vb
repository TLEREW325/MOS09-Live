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
Public Class GLAccountBalances
    Inherits System.Windows.Forms.Form

    Dim strYear, BeginDate, EndDate, ValuationMonth As String
    Dim YearOfDate, intFiscalYear As Integer
    Dim YearDate As Date
    Dim DebitREBalance, CreditREBalance, RetainedEarnings As Double
    Dim AccountType, FiscalBeginDate, FiscalBeginYear As String
    Dim LastTransactionNumber, NextTransactionNumber, NextBatchNumber, LastBatchNumber As Integer
    Dim GLDebitAmount, GLCreditAmount, DebitBegBalance, CreditBegBalance, DebitEndBalance, CreditEndBalance, DebitCurrentMonth, CreditCurrentMonth, BeginningBalance, EndingBalance As Double
    Dim CheckArchive As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub GLAccountBalances_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        End If

        LoadGLAccount()
        LoadMonth()
        cboYearField.Text = "2024"
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "LLH"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Private Sub dgvGLAccountTransactions_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvGLAccountTransactions.CellDoubleClick
        Dim RowDescription, TransactionType As String
        Dim RowGLReferenceNumber, RowReferenceBatchNumber, GetShipmentNumber As Integer
        Dim RowIndex As Integer = Me.dgvGLAccountTransactions.CurrentCell.RowIndex

        RowDescription = Me.dgvGLAccountTransactions.Rows(RowIndex).Cells("GLTransactionDescriptionColumn").Value.ToString
        RowGLReferenceNumber = Me.dgvGLAccountTransactions.Rows(RowIndex).Cells("GLReferenceNumberColumn").Value
        RowReferenceBatchNumber = Me.dgvGLAccountTransactions.Rows(RowIndex).Cells("GLBatchNumberColumn").Value

        TransactionType = RowDescription

        'Set up case statement to determine what print form to open
        Select Case TransactionType
            Case "Invoice Processing"
                GlobalInvoiceNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text

                'Determine if Bill Only or regular Invoice
                Dim GetShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                Dim GetShipmentNumberCommand As New SqlCommand(GetShipmentNumberStatement, con)
                GetShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowGLReferenceNumber
                GetShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetShipmentNumber = CInt(GetShipmentNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetShipmentNumber = 0
                End Try
                con.Close()

                'Choose the Invoice Print Form by division
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    If GetShipmentNumber = 0 Then
                        Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                            Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBatch As New PrintInvoiceSingle
                            Dim result = NewPrintInvoiceBatch.ShowDialog()
                        End Using
                    End If
                Else
                    If GetShipmentNumber = 0 Then
                        Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                            Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                            Dim result = NewPrintInvoiceSingle.ShowDialog()
                        End Using
                    End If
                End If
            Case "Shipment"
                GlobalShipmentNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintShipment As New PrintShipment
                    Dim Result = NewPrintShipment.ShowDialog()
                End Using
            Case "Customer Return"
                GlobalCustomerReturnNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintCustomerReturn As New PrintCustomerReturn
                    Dim Result = NewPrintCustomerReturn.ShowDialog()
                End Using
            Case "Receipt Of Goods"
                GlobalReceiverNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintReceiver As New PrintReceiver
                    Dim Result = NewPrintReceiver.ShowDialog()
                End Using
            Case "Vendor Return"
                GlobalVendorReturnNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVendorReturn As New PrintVendorReturn
                    Dim Result = NewPrintVendorReturn.ShowDialog()
                End Using
            Case "Receipt Of Invoice Posting"
                GlobalVoucherNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Case "Receipt Of Invoice Freight Charges"
                GlobalVoucherNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Case "Receipt Of Invoice Freight Post To Payables"
                GlobalVoucherNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Case "Receipt Of Invoice Sales Tax Paid"
                GlobalVoucherNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Case "Receipt Of Invoice Sales Tax Post To Payables"
                GlobalVoucherNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Case "Voucher Cost Adjustment"
                GlobalVoucherNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Case "Inventory Adjustment"
                GlobalInventoryAdjustmentBatchNumber = RowReferenceBatchNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintInventoryAdjustmentBatch As New PrintInventoryAdjustmentBatch
                    Dim Result = NewPrintInventoryAdjustmentBatch.ShowDialog()
                End Using
            Case "CASH RECEIPTS / CUSTOMER PAYMENTS"
                GlobalARBatchNumber = RowReferenceBatchNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintARCustomerPaymentBatch As New PrintARCustomerPaymentBatch
                    Dim Result = NewPrintARCustomerPaymentBatch.ShowDialog()
                End Using
            Case Else
                'Do nothing - no popup 
        End Select
    End Sub

    Private Sub dgvGLArchivedTransactions_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGLArchivedTransactions.CellDoubleClick
        Dim RowDescription, TransactionType As String
        Dim RowGLReferenceNumber, RowReferenceBatchNumber, GetShipmentNumber As Integer
        Dim RowIndex As Integer = Me.dgvGLArchivedTransactions.CurrentCell.RowIndex

        RowDescription = Me.dgvGLArchivedTransactions.Rows(RowIndex).Cells("GLTransactionDescriptionColumnArchive").Value.ToString
        RowGLReferenceNumber = Me.dgvGLArchivedTransactions.Rows(RowIndex).Cells("GLReferenceNumberColumnArchive").Value
        RowReferenceBatchNumber = Me.dgvGLArchivedTransactions.Rows(RowIndex).Cells("GLBatchNumberColumnArchive").Value

        TransactionType = RowDescription

        'Set up case statement to determine what print form to open
        Select Case TransactionType
            Case "Invoice Processing"
                GlobalInvoiceNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text

                'Determine if Bill Only or regular Invoice
                Dim GetShipmentNumberStatement As String = "SELECT ShipmentNumber FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                Dim GetShipmentNumberCommand As New SqlCommand(GetShipmentNumberStatement, con)
                GetShipmentNumberCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowGLReferenceNumber
                GetShipmentNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetShipmentNumber = CInt(GetShipmentNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    GetShipmentNumber = 0
                End Try
                con.Close()

                'Choose the Invoice Print Form by division
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    If GetShipmentNumber = 0 Then
                        Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                            Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceBatch As New PrintInvoiceSingle
                            Dim result = NewPrintInvoiceBatch.ShowDialog()
                        End Using
                    End If
                Else
                    If GetShipmentNumber = 0 Then
                        Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                            Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                        End Using
                    Else
                        Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                            Dim result = NewPrintInvoiceSingle.ShowDialog()
                        End Using
                    End If
                End If
            Case "Shipment"
                GlobalShipmentNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintShipment As New PrintShipment
                    Dim Result = NewPrintShipment.ShowDialog()
                End Using
            Case "Customer Return"
                GlobalCustomerReturnNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintCustomerReturn As New PrintCustomerReturn
                    Dim Result = NewPrintCustomerReturn.ShowDialog()
                End Using
            Case "Receipt Of Goods"
                GlobalReceiverNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintReceiver As New PrintReceiver
                    Dim Result = NewPrintReceiver.ShowDialog()
                End Using
            Case "Vendor Return"
                GlobalVendorReturnNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVendorReturn As New PrintVendorReturn
                    Dim Result = NewPrintVendorReturn.ShowDialog()
                End Using
            Case "Receipt Of Invoice Posting"
                GlobalVoucherNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Case "Receipt Of Invoice Freight Charges"
                GlobalVoucherNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Case "Receipt Of Invoice Freight Post To Payables"
                GlobalVoucherNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Case "Receipt Of Invoice Sales Tax Paid"
                GlobalVoucherNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Case "Receipt Of Invoice Sales Tax Post To Payables"
                GlobalVoucherNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Case "Voucher Cost Adjustment"
                GlobalVoucherNumber = RowGLReferenceNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintVoucher As New PrintVoucher
                    Dim Result = NewPrintVoucher.ShowDialog()
                End Using
            Case "Inventory Adjustment"
                GlobalInventoryAdjustmentBatchNumber = RowReferenceBatchNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintInventoryAdjustmentBatch As New PrintInventoryAdjustmentBatch
                    Dim Result = NewPrintInventoryAdjustmentBatch.ShowDialog()
                End Using
            Case "CASH RECEIPTS / CUSTOMER PAYMENTS"
                GlobalARBatchNumber = RowReferenceBatchNumber
                GlobalDivisionCode = cboDivisionID.Text
                Using NewPrintARCustomerPaymentBatch As New PrintARCustomerPaymentBatch
                    Dim Result = NewPrintARCustomerPaymentBatch.ShowDialog()
                End Using
            Case Else
                'Do nothing - no popup 
        End Select
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvGLAccountTransactions.DataSource = Nothing
        dgvGLArchivedTransactions.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilter()
        Dim DateFilter, ZeroFilter, AccountFilter As String

        If cboGLAccount.Text <> "" Then
            AccountFilter = " AND GLAccountNumber = '" + cboGLAccount.Text + "'"
        Else
            AccountFilter = ""
            MsgBox("You must select a G/L Account", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If chkSuppressZero.Checked = True Then
            ZeroFilter = " AND (GLTransactionCreditAmount <> 0 OR GLTransactionDebitAmount <> 0)"
        Else
            ZeroFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
            DateFilter = " AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Else
            GetDateRange()
            DateFilter = " AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterList WHERE DivisionID = @DivisionID" + AccountFilter + ZeroFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLTransactionMasterList")
        dgvGLAccountTransactions.DataSource = ds.Tables("GLTransactionMasterList")
        con.Close()
    End Sub

    Public Sub ShowDataByFilterArchive()
        Dim DateFilter, ZeroFilter, AccountFilter As String

        If cboGLAccount.Text <> "" Then
            AccountFilter = " AND GLAccountNumber = '" + cboGLAccount.Text + "'"
        Else
            AccountFilter = ""
            MsgBox("You must select a G/L Account", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If chkSuppressZero.Checked = True Then
            ZeroFilter = " AND (GLTransactionCreditAmount <> 0 OR GLTransactionDebitAmount <> 0)"
        Else
            ZeroFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text
            DateFilter = " AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Else
            GetDateRange()
            DateFilter = " AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListArchive WHERE DivisionID = @DivisionID" + AccountFilter + ZeroFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLTransactionMasterListArchive")
        dgvGLArchivedTransactions.DataSource = ds.Tables("GLTransactionMasterListArchive")
        con.Close()
    End Sub

    Public Sub LoadGLAccount()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "GLAccounts")
        cboGLAccount.DataSource = ds4.Tables("GLAccounts")
        cboGLAccountDescription.DataSource = ds4.Tables("GLAccounts")
        con.Close()
        cboGLAccount.SelectedIndex = -1
        cboGLAccountDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadMonth()
        cmd = New SqlCommand("SELECT * FROM MonthTable ORDER BY MonthNumber", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "MonthTable")
        cboMonth.DataSource = ds5.Tables("MonthTable")
        con.Close()
        cboMonth.SelectedIndex = -1
    End Sub

    Public Sub ClearData()
        cboGLAccount.Refresh()
        cboGLAccountDescription.Refresh()
        cboMonth.Refresh()

        cboGLAccount.SelectedIndex = -1
        cboGLAccountDescription.SelectedIndex = -1
        cboMonth.SelectedIndex = -1
        cboYearField.Text = "2024"

        txtBegBalance.Refresh()
        txtEndBalance.Refresh()
        txtGLCreditTotal.Refresh()
        txtGLDebitTotal.Refresh()

        txtBegBalance.Clear()
        txtEndBalance.Clear()
        txtGLCreditTotal.Clear()
        txtGLDebitTotal.Clear()
        txtLastArchiveDate.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkArchiveData.Checked = False
        dgvGLAccountTransactions.Visible = True
        dgvGLArchivedTransactions.Visible = False

        cboGLAccount.Focus()
    End Sub

    Public Sub ClearVariables()
        strYear = ""
        BeginDate = ""
        EndDate = ""
        ValuationMonth = ""
        YearOfDate = 0
        LastTransactionNumber = 0
        NextTransactionNumber = 0
        NextBatchNumber = 0
        LastBatchNumber = 0
        GLDebitAmount = 0
        GLCreditAmount = 0
        DebitBegBalance = 0
        CreditBegBalance = 0
        DebitEndBalance = 0
        CreditEndBalance = 0
        DebitCurrentMonth = 0
        CreditCurrentMonth = 0
        BeginningBalance = 0
        EndingBalance = 0
        CheckArchive = ""
    End Sub

    Public Sub LoadAccountBalances()
        'Get data from archives if checkbox is selected
        If chkArchiveData.Checked = True Then
            CheckArchive = "Archive"
        Else
            CheckArchive = ""
        End If

        'Get Beginning Balance for Date
        GetDateRange()

        'Get Account Type for GL Account to determine if Balance Sheet / Income Account Type
        Dim AccountTypeStatement As String = "SELECT GLAccountCashFlowCode FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim AccountTypeCommand As New SqlCommand(AccountTypeStatement, con)
        AccountTypeCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AccountType = CStr(AccountTypeCommand.ExecuteScalar)
        Catch ex As Exception
            AccountType = ""
        End Try
        con.Close()

        If cboGLAccount.Text = "39500" Then
            CalculateRetainedEarnings()
        Else
            If AccountType = "BalanceSheet" Then
                Dim DebitBegBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @GLTransactionDate AND DivisionID = @DivisionID"
                Dim DebitBegBalanceCommand As New SqlCommand(DebitBegBalanceStatement, con)
                DebitBegBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                DebitBegBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
                DebitBegBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim CreditBegBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @GLTransactionDate AND DivisionID = @DivisionID"
                Dim CreditBegBalanceCommand As New SqlCommand(CreditBegBalanceStatement, con)
                CreditBegBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                CreditBegBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
                CreditBegBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    DebitBegBalance = CDbl(DebitBegBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    DebitBegBalance = 0
                End Try
                Try
                    CreditBegBalance = CDbl(CreditBegBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    CreditBegBalance = 0
                End Try
                con.Close()

                BeginningBalance = DebitBegBalance - CreditBegBalance
                txtBegBalance.Text = FormatCurrency(BeginningBalance, 2)

                'Sum Debits for Month
                Dim DebitCurrentBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND (GLTransactionDate >= @BeginDate AND GLTransactionDate <= @EndDate)"
                Dim DebitCurrentBalanceCommand As New SqlCommand(DebitCurrentBalanceStatement, con)
                DebitCurrentBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                DebitCurrentBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                DebitCurrentBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                DebitCurrentBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    DebitCurrentMonth = CDbl(DebitCurrentBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    DebitCurrentMonth = 0
                End Try
                con.Close()

                txtGLDebitTotal.Text = FormatCurrency(DebitCurrentMonth, 2)

                'Sum Credits for Month
                Dim CreditCurrentBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND (GLTransactionDate >= @BeginDate AND GLTransactionDate <= @EndDate)"
                Dim CreditCurrentBalanceCommand As New SqlCommand(CreditCurrentBalanceStatement, con)
                CreditCurrentBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CreditCurrentBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                CreditCurrentBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                CreditCurrentBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CreditCurrentMonth = CDbl(CreditCurrentBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    CreditCurrentMonth = 0
                End Try
                con.Close()

                txtGLCreditTotal.Text = FormatCurrency(CreditCurrentMonth, 2)

                'Calculate Ending Balance
                EndingBalance = BeginningBalance + DebitCurrentMonth - CreditCurrentMonth

                txtEndBalance.Text = FormatCurrency(EndingBalance, 2)
            ElseIf AccountType = "IncomeStatement" Then
                'Get Date Range to beginning of the fiscal year only
                If cboMonth.Text = "January" Or cboMonth.Text = "February" Or cboMonth.Text = "March" Or cboMonth.Text = "April" Then
                    intFiscalYear = Val(cboYearField.Text) - 1
                    FiscalBeginYear = Str(intFiscalYear)
                    FiscalBeginDate = "05/01/" + FiscalBeginYear
                Else
                    intFiscalYear = Val(cboYearField.Text)
                    FiscalBeginYear = Str(intFiscalYear)
                    FiscalBeginDate = "05/01/" + FiscalBeginYear
                End If

                Dim DebitBegBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND (GLTransactionDate >= @FiscalBeginDate AND GLTransactionDate < @GLTransactionDate)"
                Dim DebitBegBalanceCommand As New SqlCommand(DebitBegBalanceStatement, con)
                DebitBegBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                DebitBegBalanceCommand.Parameters.Add("@FiscalBeginDate", SqlDbType.VarChar).Value = FiscalBeginDate
                DebitBegBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
                DebitBegBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim CreditBegBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND (GLTransactionDate >= @FiscalBeginDate AND GLTransactionDate < @GLTransactionDate)"
                Dim CreditBegBalanceCommand As New SqlCommand(CreditBegBalanceStatement, con)
                CreditBegBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                CreditBegBalanceCommand.Parameters.Add("@FiscalBeginDate", SqlDbType.VarChar).Value = FiscalBeginDate
                CreditBegBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
                CreditBegBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    DebitBegBalance = CDbl(DebitBegBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    DebitBegBalance = 0
                End Try
                Try
                    CreditBegBalance = CDbl(CreditBegBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    CreditBegBalance = 0
                End Try
                con.Close()

                If cboMonth.Text = "May" Then
                    DebitBegBalance = 0
                    CreditBegBalance = 0
                End If

                BeginningBalance = DebitBegBalance - CreditBegBalance
                txtBegBalance.Text = FormatCurrency(BeginningBalance, 2)

                'Sum Debits for Month
                Dim DebitCurrentBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND (GLTransactionDate >= @BeginDate AND GLTransactionDate <= @EndDate)"
                Dim DebitCurrentBalanceCommand As New SqlCommand(DebitCurrentBalanceStatement, con)
                DebitCurrentBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                DebitCurrentBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                DebitCurrentBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                DebitCurrentBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    DebitCurrentMonth = CDbl(DebitCurrentBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    DebitCurrentMonth = 0
                End Try
                con.Close()

                txtGLDebitTotal.Text = FormatCurrency(DebitCurrentMonth, 2)

                'Sum Credits for Month
                Dim CreditCurrentBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND (GLTransactionDate >= @BeginDate AND GLTransactionDate <= @EndDate)"
                Dim CreditCurrentBalanceCommand As New SqlCommand(CreditCurrentBalanceStatement, con)
                CreditCurrentBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CreditCurrentBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                CreditCurrentBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                CreditCurrentBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CreditCurrentMonth = CDbl(CreditCurrentBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    CreditCurrentMonth = 0
                End Try
                con.Close()

                txtGLCreditTotal.Text = FormatCurrency(CreditCurrentMonth, 2)

                'Calculate Ending Balance
                EndingBalance = BeginningBalance + DebitCurrentMonth - CreditCurrentMonth

                txtEndBalance.Text = FormatCurrency(EndingBalance, 2)
            Else
                MsgBox("Invalid Account Type", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Public Sub LoadAccountBalancesForDateRange()
        'Get data from archives if checkbox is selected
        If chkArchiveData.Checked = True Then
            CheckArchive = "Archive"
        Else
            CheckArchive = ""
        End If

        'Get Beginning Balance for Date
        BeginDate = dtpBeginDate.Text
        EndDate = dtpEndDate.Text

        'Get Account Type for GL Account to determine if Balance Sheet / Income Account Type
        Dim AccountTypeStatement As String = "SELECT GLAccountCashFlowCode FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim AccountTypeCommand As New SqlCommand(AccountTypeStatement, con)
        AccountTypeCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AccountType = CStr(AccountTypeCommand.ExecuteScalar)
        Catch ex As Exception
            AccountType = ""
        End Try
        con.Close()

        If cboGLAccount.Text = "39500" Then
            CalculateRetainedEarnings()
        Else

            If AccountType = "BalanceSheet" Then
                Dim DebitBegBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @GLTransactionDate AND DivisionID = @DivisionID"
                Dim DebitBegBalanceCommand As New SqlCommand(DebitBegBalanceStatement, con)
                DebitBegBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                DebitBegBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
                DebitBegBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim CreditBegBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @GLTransactionDate AND DivisionID = @DivisionID"
                Dim CreditBegBalanceCommand As New SqlCommand(CreditBegBalanceStatement, con)
                CreditBegBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                CreditBegBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
                CreditBegBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    DebitBegBalance = CDbl(DebitBegBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    DebitBegBalance = 0
                End Try
                Try
                    CreditBegBalance = CDbl(CreditBegBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    CreditBegBalance = 0
                End Try
                con.Close()

                BeginningBalance = DebitBegBalance - CreditBegBalance
                txtBegBalance.Text = FormatCurrency(BeginningBalance, 2)

                'Sum Debits for Month
                Dim DebitCurrentBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND (GLTransactionDate >= @BeginDate AND GLTransactionDate <= @EndDate)"
                Dim DebitCurrentBalanceCommand As New SqlCommand(DebitCurrentBalanceStatement, con)
                DebitCurrentBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                DebitCurrentBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                DebitCurrentBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                DebitCurrentBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    DebitCurrentMonth = CDbl(DebitCurrentBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    DebitCurrentMonth = 0
                End Try
                con.Close()

                txtGLDebitTotal.Text = FormatCurrency(DebitCurrentMonth, 2)

                'Sum Credits for Month
                Dim CreditCurrentBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND (GLTransactionDate >= @BeginDate AND GLTransactionDate <= @EndDate)"
                Dim CreditCurrentBalanceCommand As New SqlCommand(CreditCurrentBalanceStatement, con)
                CreditCurrentBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CreditCurrentBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                CreditCurrentBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                CreditCurrentBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CreditCurrentMonth = CDbl(CreditCurrentBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    CreditCurrentMonth = 0
                End Try
                con.Close()

                txtGLCreditTotal.Text = FormatCurrency(CreditCurrentMonth, 2)

                'Calculate Ending Balance
                EndingBalance = BeginningBalance + DebitCurrentMonth - CreditCurrentMonth

                txtEndBalance.Text = FormatCurrency(EndingBalance, 2)
            ElseIf AccountType = "IncomeStatement" Then
                'Get Date Range to beginning of the fiscal year only
                If cboMonth.Text = "January" Or cboMonth.Text = "February" Or cboMonth.Text = "March" Or cboMonth.Text = "April" Then
                    intFiscalYear = Val(cboYearField.Text) - 1
                    FiscalBeginYear = Str(intFiscalYear)
                    FiscalBeginDate = "05/01/" + FiscalBeginYear
                Else
                    intFiscalYear = Val(cboYearField.Text)
                    FiscalBeginYear = Str(intFiscalYear)
                    FiscalBeginDate = "05/01/" + FiscalBeginYear
                End If

                Dim DebitBegBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND (GLTransactionDate >= @FiscalBeginDate AND GLTransactionDate < @GLTransactionDate)"
                Dim DebitBegBalanceCommand As New SqlCommand(DebitBegBalanceStatement, con)
                DebitBegBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                DebitBegBalanceCommand.Parameters.Add("@FiscalBeginDate", SqlDbType.VarChar).Value = FiscalBeginDate
                DebitBegBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
                DebitBegBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim CreditBegBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE GLAccountNumber = @GLAccountNumber AND DivisionID = @DivisionID AND (GLTransactionDate >= @FiscalBeginDate AND GLTransactionDate < @GLTransactionDate)"
                Dim CreditBegBalanceCommand As New SqlCommand(CreditBegBalanceStatement, con)
                CreditBegBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                CreditBegBalanceCommand.Parameters.Add("@FiscalBeginDate", SqlDbType.VarChar).Value = FiscalBeginDate
                CreditBegBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
                CreditBegBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    DebitBegBalance = CDbl(DebitBegBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    DebitBegBalance = 0
                End Try
                Try
                    CreditBegBalance = CDbl(CreditBegBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    CreditBegBalance = 0
                End Try
                con.Close()

                If cboMonth.Text = "May" Then
                    DebitBegBalance = 0
                    CreditBegBalance = 0
                End If

                BeginningBalance = DebitBegBalance - CreditBegBalance
                txtBegBalance.Text = FormatCurrency(BeginningBalance, 2)

                'Sum Debits for Month
                Dim DebitCurrentBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND (GLTransactionDate >= @BeginDate AND GLTransactionDate <= @EndDate)"
                Dim DebitCurrentBalanceCommand As New SqlCommand(DebitCurrentBalanceStatement, con)
                DebitCurrentBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                DebitCurrentBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                DebitCurrentBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                DebitCurrentBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    DebitCurrentMonth = CDbl(DebitCurrentBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    DebitCurrentMonth = 0
                End Try
                con.Close()

                txtGLDebitTotal.Text = FormatCurrency(DebitCurrentMonth, 2)

                'Sum Credits for Month
                Dim CreditCurrentBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchive + " WHERE DivisionID = @DivisionID AND GLAccountNumber = @GLAccountNumber AND (GLTransactionDate >= @BeginDate AND GLTransactionDate <= @EndDate)"
                Dim CreditCurrentBalanceCommand As New SqlCommand(CreditCurrentBalanceStatement, con)
                CreditCurrentBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                CreditCurrentBalanceCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboGLAccount.Text
                CreditCurrentBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
                CreditCurrentBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CreditCurrentMonth = CDbl(CreditCurrentBalanceCommand.ExecuteScalar)
                Catch ex As Exception
                    CreditCurrentMonth = 0
                End Try
                con.Close()

                txtGLCreditTotal.Text = FormatCurrency(CreditCurrentMonth, 2)

                'Calculate Ending Balance
                EndingBalance = BeginningBalance + DebitCurrentMonth - CreditCurrentMonth

                txtEndBalance.Text = FormatCurrency(EndingBalance, 2)
            Else
                MsgBox("Invalid Account Type", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    Public Sub GetDateRange()
        ValuationMonth = cboMonth.Text

        'Find current year to calculate correct Begin, End Dates
        'YearDate = Today()
        'YearOfDate = YearDate.Year
        strYear = cboYearField.Text

        Select Case ValuationMonth
            Case "January"
                BeginDate = "01/01/" + strYear
                EndDate = "01/31/" + strYear
            Case "February"
                BeginDate = "02/01/" + strYear
                EndDate = "02/28/" + strYear
            Case "March"
                BeginDate = "03/01/" + strYear
                EndDate = "03/31/" + strYear
            Case "April"
                BeginDate = "04/01/" + strYear
                EndDate = "04/30/" + strYear
            Case "May"
                BeginDate = "05/01/" + strYear
                EndDate = "05/31/" + strYear
            Case "June"
                BeginDate = "06/01/" + strYear
                EndDate = "06/30/" + strYear
            Case "July"
                BeginDate = "07/01/" + strYear
                EndDate = "07/31/" + strYear
            Case "August"
                BeginDate = "08/01/" + strYear
                EndDate = "08/31/" + strYear
            Case "September"
                BeginDate = "09/01/" + strYear
                EndDate = "09/30/" + strYear
            Case "October"
                BeginDate = "10/01/" + strYear
                EndDate = "10/31/" + strYear
            Case "November"
                BeginDate = "11/01/" + strYear
                EndDate = "11/30/" + strYear
            Case "December"
                BeginDate = "12/01/" + strYear
                EndDate = "12/31/" + strYear
            Case Else
                BeginDate = dtpBeginDate.Value
                EndDate = dtpEndDate.Value
        End Select
    End Sub

    Public Sub CalculateRetainedEarnings()
        'Get data from archives if checkbox is selected
        If chkArchiveData.Checked = True Then
            CheckArchive = "Archive"
        Else
            CheckArchive = ""
        End If

        'Get Date Range to beginning of the fiscal year only
        If cboMonth.Text = "January" Or cboMonth.Text = "February" Or cboMonth.Text = "March" Or cboMonth.Text = "April" Then
            intFiscalYear = Val(cboYearField.Text) - 1
            FiscalBeginYear = Str(intFiscalYear)
            FiscalBeginDate = "05/01/" + FiscalBeginYear
        Else
            intFiscalYear = Val(cboYearField.Text)
            FiscalBeginYear = Str(intFiscalYear)
            FiscalBeginDate = "05/01/" + FiscalBeginYear
        End If

        Dim DebitREBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList" + CheckArchive + "Query WHERE GLAccountCashFlowCode = @GLAccountCashFlowCode AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim DebitREBalanceCommand As New SqlCommand(DebitREBalanceStatement, con)
        DebitREBalanceCommand.Parameters.Add("@GLAccountCashFlowCode", SqlDbType.VarChar).Value = "IncomeStatement"
        DebitREBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
        DebitREBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim CreditREBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList" + CheckArchive + "Query WHERE GLAccountCashFlowCode = @GLAccountCashFlowCode AND DivisionID = @DivisionID AND GLTransactionDate < @GLTransactionDate"
        Dim CreditREBalanceCommand As New SqlCommand(CreditREBalanceStatement, con)
        CreditREBalanceCommand.Parameters.Add("@GLAccountCashFlowCode", SqlDbType.VarChar).Value = "IncomeStatement"
        CreditREBalanceCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = BeginDate
        CreditREBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DebitREBalance = CDbl(DebitREBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            DebitREBalance = 0
        End Try
        Try
            CreditREBalance = CDbl(CreditREBalanceCommand.ExecuteScalar)
        Catch ex As Exception
            CreditREBalance = 0
        End Try
        con.Close()

        RetainedEarnings = DebitREBalance - CreditREBalance
        txtBegBalance.Text = FormatCurrency(RetainedEarnings, 2)

        'Sum Debits for Month
        'Dim DebitCurrentBalanceStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterListQuery WHERE DivisionID = @DivisionID AND GLAccountCashFlowCode = @GLAccountCashFlowCode AND (GLTransactionDate >= @BeginDate AND GLTransactionDate <= @EndDate)"
        'Dim DebitCurrentBalanceCommand As New SqlCommand(DebitCurrentBalanceStatement, con)
        'DebitCurrentBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        'DebitCurrentBalanceCommand.Parameters.Add("@GLAccountCashFlowCode", SqlDbType.VarChar).Value = "IncomeStatement"
        'DebitCurrentBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        'DebitCurrentBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        'If con.State = ConnectionState.Closed Then con.Open()
        'Try
        'DebitCurrentMonth = CDbl(DebitCurrentBalanceCommand.ExecuteScalar)
        'Catch ex As Exception
        DebitCurrentMonth = 0
        'End Try
        'con.Close()

        txtGLDebitTotal.Text = FormatCurrency(DebitCurrentMonth, 2)

        'Sum Credits for Month
        'Dim CreditCurrentBalanceStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID = @DivisionID AND GLAccountCashFlowCode = @GLAccountCashFlowCode AND (GLTransactionDate >= @BeginDate AND GLTransactionDate <= @EndDate)"
        'Dim CreditCurrentBalanceCommand As New SqlCommand(CreditCurrentBalanceStatement, con)
        'CreditCurrentBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        'CreditCurrentBalanceCommand.Parameters.Add("@GLAccountCashFlowCode", SqlDbType.VarChar).Value = "IncomeStatement"
        'CreditCurrentBalanceCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        'CreditCurrentBalanceCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        'If con.State = ConnectionState.Closed Then con.Open()
        'Try
        'CreditCurrentMonth = CDbl(CreditCurrentBalanceCommand.ExecuteScalar)
        'Catch ex As Exception
        CreditCurrentMonth = 0
        'End Try
        'con.Close()

        txtGLCreditTotal.Text = FormatCurrency(CreditCurrentMonth, 2)

        'Calculate Ending Balance
        EndingBalance = RetainedEarnings + DebitCurrentMonth - CreditCurrentMonth

        txtEndBalance.Text = FormatCurrency(EndingBalance, 2)
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadGLAccount()
        LoadMonth()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub viewByDateRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles viewByFilters.Click

        If chkArchiveData.Checked = True Then
            dgvGLAccountTransactions.Visible = False
            dgvGLArchivedTransactions.Visible = True

            If chkDateRange.Checked = True Then
                ShowDataByFilterArchive()
                LoadAccountBalancesForDateRange()
            Else
                ShowDataByFilterArchive()
                LoadAccountBalances()
            End If
        Else
            dgvGLAccountTransactions.Visible = True
            dgvGLArchivedTransactions.Visible = False

            If chkDateRange.Checked = True Then
                ShowDataByFilter()
                LoadAccountBalancesForDateRange()
            Else
                ShowDataByFilter()
                LoadAccountBalances()
            End If
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdViewGLListing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewGLListing.Click
        GlobalDivisionCode = cboDivisionID.Text
        Using NewViewGLTransactionListing As New ViewGLTransactionListing
            Dim Result = NewViewGLTransactionListing.ShowDialog
        End Using
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If chkArchiveData.Checked = True Then
            GlobalLedgerPrintForm = "ARCHIVE"
        Else
            GlobalLedgerPrintForm = "LIVE"
        End If

        GDS = ds

        Using NewPrintGLTransactionByAccount As New PrintGLTransactionByAccount
            Dim Result = NewPrintGLTransactionByAccount.ShowDialog
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintGLTransactionByAccount As New PrintGLTransactionByAccount
            Dim Result = NewPrintGLTransactionByAccount.ShowDialog
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        If chkDateRange.Checked = True Then
            cboYearField.SelectedIndex = -1
            cboMonth.SelectedIndex = -1
        Else
            dtpBeginDate.Text = ""
            dtpEndDate.Text = ""
        End If
    End Sub

    Private Sub chkArchiveData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkArchiveData.CheckedChanged
        If chkArchiveData.Checked = True Then
            'Get Last Archive Date
            Dim LastDate As Date

            Dim LastDateStatement As String = "SELECT MAX(GLTransactionDate) FROM GLTransactionMasterListArchive WHERE DivisionID = @DivisionID"
            Dim LastDateCommand As New SqlCommand(LastDateStatement, con)
            LastDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastDate = CDate(LastDateCommand.ExecuteScalar)
            Catch ex As Exception
                LastDate = "1/1/1900"
            End Try
            con.Close()

            txtLastArchiveDate.Text = LastDate
        Else
            'Do nothing
            txtLastArchiveDate.Clear()
        End If
    End Sub
End Class