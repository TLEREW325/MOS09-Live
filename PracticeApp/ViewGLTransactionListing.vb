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
Public Class ViewGLTransactionListing
    Inherits System.Windows.Forms.Form

    Dim DateFilter, JournalFilter, AccountFilter, ReferenceFilter, BatchFilter, TextFilter As String
    Dim GLBatchNumber, GLReferenceNumber As Integer
    Dim strGLBatchNumber, strGLReferenceNumber As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewSearchGLTransactions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        LoadCurrentDivision()

        If EmployeeSecurityCode = "1001" Then
            AdminToolStripMenuItem.Enabled = True
        Else
            AdminToolStripMenuItem.Enabled = False
        End If
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
            Case "TFJ"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFJ'", con)
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

    Public Sub ClearDataInDatagrid()
        dgvGLTransactions.DataSource = Nothing
        dgvArchivedTransactions.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboGLAccount.Text <> "" Then
            AccountFilter = " AND GLAccountNumber = '" + cboGLAccount.Text + "'"
        Else
            AccountFilter = ""
        End If
        If cboJournal.Text <> "" Then
            JournalFilter = " AND GLJournalID = '" + cboJournal.Text + "'"
        Else
            JournalFilter = ""
        End If
        If txtReferenceNumber.Text <> "" Then
            GLReferenceNumber = Val(txtReferenceNumber.Text)
            strGLReferenceNumber = CStr(GLReferenceNumber)
            ReferenceFilter = " AND GLReferenceNumber = '" + strGLReferenceNumber + "'"
        Else
            ReferenceFilter = ""
        End If
        If txtBatchNumber.Text <> "" Then
            GLBatchNumber = Val(txtBatchNumber.Text)
            strGLBatchNumber = CStr(GLBatchNumber)
            BatchFilter = " AND GLBatchNumber = '" + strGLBatchNumber + "'"
        Else
            BatchFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (GLTransactionDescription LIKE '%" + txtTextFilter.Text + "%' OR GLtransactionComment LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If

        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            DateFilter = " AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        End If

        If chkViewArchived.Checked = True Then
            cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListArchive WHERE DivisionID = @DivisionID" + JournalFilter + AccountFilter + BatchFilter + ReferenceFilter + TextFilter + DateFilter, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd
            myAdapter3.Fill(ds3, "GLTransactionMasterListArchive")
            dgvArchivedTransactions.DataSource = ds3.Tables("GLTransactionMasterListArchive")
            con.Close()

            dgvArchivedTransactions.Visible = True
            dgvGLTransactions.Visible = False
        Else
            cmd = New SqlCommand("SELECT * FROM GLTransactionMasterListQuery WHERE DivisionID = @DivisionID" + JournalFilter + AccountFilter + BatchFilter + ReferenceFilter + TextFilter + DateFilter, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "GLTransactionMasterListQuery")
            dgvGLTransactions.DataSource = ds.Tables("GLTransactionMasterListQuery")
            con.Close()

            dgvArchivedTransactions.Visible = False
            dgvGLTransactions.Visible = True
        End If
    End Sub

    Public Sub LoadAccount()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "GLAccounts")
        cboGLAccount.DataSource = ds1.Tables("GLAccounts")
        cboGLDescription.DataSource = ds1.Tables("GLAccounts")
        con.Close()
        cboGLAccount.SelectedIndex = -1
        cboGLDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadJournal()
        cmd = New SqlCommand("SELECT GLJournalID FROM GLJournals WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "GLJournals")
        cboJournal.DataSource = ds2.Tables("GLJournals")
        con.Close()
        cboJournal.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadAccount()
        LoadJournal()

        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub dgvArchivedTransactions_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArchivedTransactions.CellDoubleClick
        Dim RowDescription, TransactionType As String
        Dim RowGLReferenceNumber, RowReferenceBatchNumber, GetShipmentNumber As Integer
        Dim RowIndex As Integer = Me.dgvArchivedTransactions.CurrentCell.RowIndex

        RowDescription = Me.dgvArchivedTransactions.Rows(RowIndex).Cells("GLTransactionDescriptionColumnArchive").Value.ToString
        RowGLReferenceNumber = Me.dgvArchivedTransactions.Rows(RowIndex).Cells("GLReferenceNumberColumnArchive").Value
        RowReferenceBatchNumber = Me.dgvArchivedTransactions.Rows(RowIndex).Cells("GLBatchNumberColumnArchive").Value

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
                        'Choose the correct Print Form (REMOTE or LOCAL)

                        'Get Login Type
                        Dim GetLoginType As String = ""

                        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            GetLoginType = ""
                        End Try
                        con.Close()

                        If GetLoginType = "REMOTE" Then
                            Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnlyRemote
                                Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                            End Using
                        Else
                            Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                                Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                            End Using
                        End If
                    Else
                        'Choose the correct Print Form (REMOTE or LOCAL)

                        'Get Login Type
                        Dim GetLoginType As String = ""

                        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            GetLoginType = ""
                        End Try
                        con.Close()

                        If GetLoginType = "REMOTE" Then
                            Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                                Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                            End Using
                        Else
                            Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                                Dim result = NewPrintInvoiceSingle.ShowDialog()
                            End Using
                        End If
                    End If
                Else
                    If GetShipmentNumber = 0 Then
                        'Choose the correct Print Form (REMOTE or LOCAL)

                        'Get Login Type
                        Dim GetLoginType As String = ""

                        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            GetLoginType = ""
                        End Try
                        con.Close()

                        If GetLoginType = "REMOTE" Then
                            Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnlyRemote
                                Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                            End Using
                        Else
                            Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                                Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                            End Using
                        End If
                    Else
                        'Choose the correct Print Form (REMOTE or LOCAL)

                        'Get Login Type
                        Dim GetLoginType As String = ""

                        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            GetLoginType = ""
                        End Try
                        con.Close()

                        If GetLoginType = "REMOTE" Then
                            Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                                Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                            End Using
                        Else
                            Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                                Dim result = NewPrintInvoiceSingle.ShowDialog()
                            End Using
                        End If
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

                'Choose the correct Print Form (REMOTE or LOCAL)

                'Get Login Type
                Dim GetLoginType As String = ""

                Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetLoginType = ""
                End Try
                con.Close()

                If GetLoginType = "REMOTE" Then
                    Using NewPrintCustomerReturnRemote As New PrintCustomerReturnRemote
                        Dim Result = NewPrintCustomerReturnRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintCustomerReturn As New PrintCustomerReturn
                        Dim Result = NewPrintCustomerReturn.ShowDialog()
                    End Using
                End If
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

    Private Sub dgvGLTransactions_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGLTransactions.CellDoubleClick
        Dim RowDescription, TransactionType As String
        Dim RowGLReferenceNumber, RowReferenceBatchNumber, GetShipmentNumber As Integer
        Dim RowIndex As Integer = Me.dgvGLTransactions.CurrentCell.RowIndex

        RowDescription = Me.dgvGLTransactions.Rows(RowIndex).Cells("GLTransactionDescriptionColumn").Value.ToString
        RowGLReferenceNumber = Me.dgvGLTransactions.Rows(RowIndex).Cells("GLReferenceNumberColumn").Value
        RowReferenceBatchNumber = Me.dgvGLTransactions.Rows(RowIndex).Cells("GLBatchNumberColumn").Value

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
                        'Choose the correct Print Form (REMOTE or LOCAL)

                        'Get Login Type
                        Dim GetLoginType As String = ""

                        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            GetLoginType = ""
                        End Try
                        con.Close()

                        If GetLoginType = "REMOTE" Then
                            Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnlyRemote
                                Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                            End Using
                        Else
                            Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                                Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                            End Using
                        End If
                    Else
                        'Choose the correct Print Form (REMOTE or LOCAL)

                        'Get Login Type
                        Dim GetLoginType As String = ""

                        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            GetLoginType = ""
                        End Try
                        con.Close()

                        If GetLoginType = "REMOTE" Then
                            Using NewPrintInvoiceSingleRemote As New PrintInvoiceSingleRemote
                                Dim result = NewPrintInvoiceSingleRemote.ShowDialog()
                            End Using
                        Else
                            Using NewPrintInvoiceSingle As New PrintInvoiceSingle
                                Dim result = NewPrintInvoiceSingle.ShowDialog()
                            End Using
                        End If
                    End If
                Else
                    If GetShipmentNumber = 0 Then
                        'Choose the correct Print Form (REMOTE or LOCAL)

                        'Get Login Type
                        Dim GetLoginType As String = ""

                        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            GetLoginType = ""
                        End Try
                        con.Close()

                        If GetLoginType = "REMOTE" Then
                            Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnlyRemote
                                Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                            End Using
                        Else
                            Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                                Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                            End Using
                        End If
                    Else
                        'Choose the correct Print Form (REMOTE or LOCAL)

                        'Get Login Type
                        Dim GetLoginType As String = ""

                        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                        Catch ex As System.Exception
                            GetLoginType = ""
                        End Try
                        con.Close()

                        If GetLoginType = "REMOTE" Then
                            Using NewPrintInvoiceBatch As New PrintInvoiceSingleRemote
                                Dim result = NewPrintInvoiceBatch.ShowDialog()
                            End Using
                        Else
                            Using NewPrintInvoiceBatch As New PrintInvoiceSingle
                                Dim result = NewPrintInvoiceBatch.ShowDialog()
                            End Using
                        End If
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

                'Choose the correct Print Form (REMOTE or LOCAL)

                'Get Login Type
                Dim GetLoginType As String = ""

                Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetLoginType = ""
                End Try
                con.Close()

                If GetLoginType = "REMOTE" Then
                    Using NewPrintCustomerReturnRemote As New PrintCustomerReturnRemote
                        Dim Result = NewPrintCustomerReturnRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintCustomerReturn As New PrintCustomerReturn
                        Dim Result = NewPrintCustomerReturn.ShowDialog()
                    End Using
                End If
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

    Public Sub ClearData()
        cboGLAccount.SelectedIndex = -1
        cboGLDescription.SelectedIndex = -1
        cboJournal.SelectedIndex = -1

        txtTextFilter.Clear()
        txtBatchNumber.Clear()
        txtReferenceNumber.Clear()
        txtLastDate.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False
        chkViewArchived.Checked = False

        dgvArchivedTransactions.Visible = False
        dgvGLTransactions.Visible = True

        cboGLAccount.Focus()
    End Sub

    Public Sub ClearVariables()
        DateFilter = ""
        JournalFilter = ""
        AccountFilter = ""
        ReferenceFilter = ""
        BatchFilter = ""
        TextFilter = ""
        GLBatchNumber = 0
        GLReferenceNumber = 0
        strGLBatchNumber = ""
        strGLReferenceNumber = ""
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If chkViewArchived.Checked = True Then
            GDS = ds3
            GlobalLedgerPrintForm = "ARCHIVE"

            Using NewPrintGLTransactionsFiltered As New PrintGLTransactionsFiltered
                Dim result = NewPrintGLTransactionsFiltered.ShowDialog()
            End Using
        Else
            GDS = ds
            GlobalLedgerPrintForm = "LIVE"

            Using NewPrintGLTransactionsFiltered As New PrintGLTransactionsFiltered
                Dim result = NewPrintGLTransactionsFiltered.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintGLTransactionsFiltered As New PrintGLTransactionsFiltered
            Dim result = NewPrintGLTransactionsFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub chkViewArchived_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewArchived.CheckedChanged
        If chkViewArchived.Checked = True Then
            'Load last archive date
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

            txtLastDate.Text = LastDate
        Else
            txtLastDate.Clear()
        End If
    End Sub

End Class