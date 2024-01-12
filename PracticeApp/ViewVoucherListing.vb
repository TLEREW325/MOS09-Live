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
Public Class ViewVoucherListing
    Inherits System.Windows.Forms.Form

    Dim StatusFilter, TextFilter, VoucherFilter, POFilter, VendorFilter, DateFilter, VendorClassFilter, InvoiceFilter As String
    Dim strPONumber, strVoucherNumber As String
    Dim PONumber, VoucherNumber As Integer
    Dim VendorName As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewVoucherListing_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearVariables()
        ClearData()
    End Sub

    Private Sub ViewVoucherListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.VendorClass' table. You can move, or remove it, as needed.
        Me.VendorClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.VendorClass)

        LoadCurrentDivision()
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

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadVendorID()
        LoadPONumber()
        LoadVoucherNumber()
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
        ClearDeletedDataInDatagrid()
    End Sub

    Private Sub dgvBatchLinePostDate_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvBatchLinePostDate.CellDoubleClick
        Dim RowVoucher As Integer
        Dim RowIndex As Integer = Me.dgvBatchLinePostDate.CurrentCell.RowIndex

        RowVoucher = Me.dgvBatchLinePostDate.Rows(RowIndex).Cells("VoucherNumberColumn").Value

        GlobalVoucherNumber = RowVoucher
        GlobalDivisionCode = cboDivisionID.Text
        GlobalVoucherType = "POSTED"

        Using NewPrintVoucher As New PrintVoucher
            Dim Result = NewPrintVoucher.ShowDialog()
        End Using
    End Sub

    Public Sub FormatDatagrid()
        Dim CheckType As String = ""

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvBatchLinePostDate.Rows
            Try
                CheckType = row.Cells("CheckTypeColumn").Value
            Catch ex As System.Exception
                CheckType = ""
            End Try

            If CheckType = "STANDARD" Then
                Me.dgvBatchLinePostDate.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            ElseIf CheckType = "" Then
                Me.dgvBatchLinePostDate.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Else
                Me.dgvBatchLinePostDate.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Private Sub dgvBatchLinePostDate_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBatchLinePostDate.CellValueChanged
        If dgvBatchLinePostDate.RowCount = 0 Then
            'Skip
        Else
            Dim RowInvoiceNumber, RowInvoiceDate, RowReceiptDate, RowDueDate, RowDiscountDate, RowComment, RowPaymentTerms As String
            Dim RowVoucher As Integer
            Dim RowDiscountAmount As Double

            Dim RowIndex As Integer = Me.dgvBatchLinePostDate.CurrentCell.RowIndex

            Try
                RowVoucher = Me.dgvBatchLinePostDate.Rows(RowIndex).Cells("VoucherNumberColumn").Value
            Catch ex As Exception
                RowVoucher = 0
            End Try
            Try
                RowInvoiceDate = Me.dgvBatchLinePostDate.Rows(RowIndex).Cells("InvoiceDateColumn").Value
            Catch ex As Exception
                RowInvoiceDate = ""
            End Try
            Try
                RowReceiptDate = Me.dgvBatchLinePostDate.Rows(RowIndex).Cells("ReceiptDateColumn").Value
            Catch ex As Exception
                RowReceiptDate = ""
            End Try
            Try
                RowDueDate = Me.dgvBatchLinePostDate.Rows(RowIndex).Cells("DueDateColumn").Value
            Catch ex As Exception
                RowDueDate = ""
            End Try
            Try
                RowDiscountDate = Me.dgvBatchLinePostDate.Rows(RowIndex).Cells("DiscountDateColumn").Value
            Catch ex As Exception
                RowDiscountDate = ""
            End Try
            Try
                RowPaymentTerms = Me.dgvBatchLinePostDate.Rows(RowIndex).Cells("PaymentTermsColumn").Value
            Catch ex As Exception
                RowPaymentTerms = "N30"
            End Try
            Try
                RowInvoiceNumber = Me.dgvBatchLinePostDate.Rows(RowIndex).Cells("InvoiceNumberColumn").Value
            Catch ex As Exception
                RowInvoiceNumber = ""
            End Try
            Try
                RowComment = Me.dgvBatchLinePostDate.Rows(RowIndex).Cells("CommentColumn").Value
            Catch ex As Exception
                RowComment = ""
            End Try
            Try
                RowDiscountAmount = Me.dgvBatchLinePostDate.Rows(RowIndex).Cells("DiscountAmountColumn").Value
            Catch ex As Exception
                RowDiscountAmount = 0
            End Try

            If RowVoucher = 0 Then
                'Skip
            Else
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET InvoiceNumber = @InvoiceNumber, InvoiceDate = @InvoiceDate, ReceiptDate = @ReceiptDate, PaymentTerms = @PaymentTerms, DiscountDate = @DiscountDate, Comment = @Comment, DueDate = @DueDate, DiscountAmount = @DiscountAmount WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = RowVoucher
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = RowInvoiceNumber
                    .Add("@InvoiceDate", SqlDbType.VarChar).Value = RowInvoiceDate
                    .Add("@ReceiptDate", SqlDbType.VarChar).Value = RowReceiptDate
                    .Add("@PaymentTerms", SqlDbType.VarChar).Value = RowPaymentTerms
                    .Add("@DiscountDate", SqlDbType.VarChar).Value = RowDiscountDate
                    .Add("@Comment", SqlDbType.VarChar).Value = RowComment
                    .Add("@DueDate", SqlDbType.VarChar).Value = RowDueDate
                    .Add("@DiscountAmount", SqlDbType.VarChar).Value = RowDiscountAmount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        End If
    End Sub

    Private Sub dgvDeletedVouchers_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDeletedVouchers.CellDoubleClick
        Dim RowVoucher As Integer
        Dim RowIndex As Integer = Me.dgvDeletedVouchers.CurrentCell.RowIndex

        RowVoucher = Me.dgvDeletedVouchers.Rows(RowIndex).Cells("VoucherNumberColumn").Value

        GlobalVoucherNumber = RowVoucher
        GlobalDivisionCode = cboDivisionID.Text
        GlobalVoucherType = "DELETED"

        Using NewPrintVoucher As New PrintVoucher
            Dim Result = NewPrintVoucher.ShowDialog()
        End Using
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvBatchLinePostDate.DataSource = Nothing
    End Sub

    Public Sub ClearDeletedDataInDatagrid()
        dgvDeletedVouchers.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilter()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If txtInvoiceNumber.Text <> "" Then
            InvoiceFilter = " AND InvoiceNumber LIKE '%" + txtInvoiceNumber.Text + "%'"
        Else
            InvoiceFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (InvoiceNumber LIKE '%" + txtTextFilter.Text + "%' OR VendorID LIKE '%" + txtTextFilter.Text + "%' OR InvoiceTotal LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If cboPONumber.Text <> "" Then
            PONumber = Val(cboPONumber.Text)
            strPONumber = CStr(PONumber)
            POFilter = " AND PONumber = '" + strPONumber + "'"
        Else
            POFilter = ""
        End If
        If cboVoucherNumber2.Text <> "" Then
            VoucherNumber = Val(cboVoucherNumber2.Text)
            strVoucherNumber = CStr(VoucherNumber)
            VoucherFilter = " AND VoucherNumber = '" + strVoucherNumber + "'"
        Else
            VoucherFilter = ""
        End If
        If cboVendorClass.Text <> "" Then
            VendorClassFilter = " AND VendorClass = '" + cboVendorClass.Text + "'"
        Else
            VendorClassFilter = ""
        End If
        If cboStatus.Text <> "" Then
            StatusFilter = " AND VoucherStatus = '" + cboStatus.Text + "'"
        Else
            StatusFilter = ""
        End If
        If chkDateRange.Checked = True Then
            If rdoInvoiceDate.Checked = True Then
                DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            ElseIf rdoPostDate.Checked = True Then
                DateFilter = " AND PostingDate BETWEEN @BeginDate AND @EndDate"
            ElseIf rdoReceiptDate.Checked = True Then
                DateFilter = " AND ReceiptDate BETWEEN @BeginDate AND @EndDate"
            Else
                DateFilter = ""
            End If
        Else
            DateFilter = ""
        End If
  
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLinePD WHERE DivisionID = @DivisionID" + POFilter + VoucherFilter + VendorFilter + VendorClassFilter + InvoiceFilter + TextFilter + StatusFilter + DateFilter + " ORDER BY VendorID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLinePD")
        dgvBatchLinePostDate.DataSource = ds.Tables("ReceiptOfInvoiceBatchLinePD")
        cboVoucherNumber.DataSource = ds.Tables("ReceiptOfInvoiceBatchLinePD")
        con.Close()

        dgvBatchLinePostDate.Visible = True
        dgvDeletedVouchers.Visible = False

        FormatDatagrid()
    End Sub

    Public Sub ShowDeletedDataByFilter()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If txtInvoiceNumber.Text <> "" Then
            InvoiceFilter = " AND InvoiceNumber LIKE '%" + txtInvoiceNumber.Text + "%'"
        Else
            InvoiceFilter = ""
        End If
        If txtTextFilter.Text <> "" Then
            TextFilter = " AND (InvoiceNumber LIKE '%" + txtTextFilter.Text + "%' OR VendorID LIKE '%" + txtTextFilter.Text + "%' OR InvoiceTotal LIKE '%" + txtTextFilter.Text + "%')"
        Else
            TextFilter = ""
        End If
        If cboPONumber.Text <> "" Then
            PONumber = Val(cboPONumber.Text)
            strPONumber = CStr(PONumber)
            POFilter = " AND PONumber = '" + strPONumber + "'"
        Else
            POFilter = ""
        End If
        If cboVoucherNumber2.Text <> "" Then
            VoucherNumber = Val(cboVoucherNumber2.Text)
            strVoucherNumber = CStr(VoucherNumber)
            VoucherFilter = " AND VoucherNumber = '" + strVoucherNumber + "'"
        Else
            VoucherFilter = ""
        End If
        If cboVendorClass.Text <> "" Then
            VendorClassFilter = " AND VendorClass = '" + cboVendorClass.Text + "'"
        Else
            VendorClassFilter = ""
        End If
        If chkDateRange.Checked = True Then
            If rdoInvoiceDate.Checked = True Then
                DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            ElseIf rdoPostDate.Checked = True Then
                DateFilter = " AND PostingDate BETWEEN @BeginDate AND @EndDate"
            ElseIf rdoReceiptDate.Checked = True Then
                DateFilter = " AND ReceiptDate BETWEEN @BeginDate AND @EndDate"
            Else
                DateFilter = ""
            End If
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM DeleteVoucherHeaderTable WHERE DivisionID = @DivisionID" + POFilter + VoucherFilter + VendorFilter + VendorClassFilter + InvoiceFilter + TextFilter + DateFilter + " ORDER BY VendorID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "DeleteVoucherHeaderTable")
        dgvDeletedVouchers.DataSource = ds4.Tables("DeleteVoucherHeaderTable")
        con.Close()

        dgvDeletedVouchers.Visible = True
        dgvBatchLinePostDate.Visible = False
    End Sub

    Public Sub LoadPONumber()
        cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "PurchaseOrderHeaderTable")
        cboPONumber.DataSource = ds1.Tables("PurchaseOrderHeaderTable")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorID()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID AND VendorClass <> @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "Vendor")
        cboVendorID.DataSource = ds2.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadVoucherNumber()
        cmd = New SqlCommand("SELECT VoucherNumber FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID ORDER BY VoucherNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ReceiptOfInvoiceBatchLine")
        cboVoucherNumber2.DataSource = ds3.Tables("ReceiptOfInvoiceBatchLine")
        con.Close()
        cboVoucherNumber2.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorName()
        Dim VendorNameString As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameString, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = usefulFunctions.checkQuote(cboVendorID.Text)
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorName = ""
        End Try
        con.Close()

        txtVendorName.Text = VendorName
    End Sub

    Public Sub ClearData()
        cboPONumber.Text = ""
        cboVendorID.Text = ""
        cboVendorClass.Text = ""
        cboVoucherNumber2.Text = ""
        cboStatus.Text = ""

        cboPONumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1
        cboVoucherNumber2.SelectedIndex = -1
        cboStatus.SelectedIndex = -1

        txtVendorName.Clear()
        txtInvoiceNumber.Clear()
        txtTextFilter.Clear()

        rdoInvoiceDate.Checked = True
        chkDateRange.Checked = False
        chkViewDeleted.Checked = False

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        dgvBatchLinePostDate.Visible = True
        dgvDeletedVouchers.Visible = False

        cboPONumber.Focus()
    End Sub

    Public Sub ClearVariables()
        POFilter = ""
        VoucherFilter = ""
        VendorFilter = ""
        DateFilter = ""
        StatusFilter = ""
        VendorClassFilter = ""
        InvoiceFilter = ""
        TextFilter = ""
        strPONumber = ""
        PONumber = 0
        VoucherNumber = 0
        strVoucherNumber = ""
        VendorName = ""
        GlobalVoucherNumber = 0
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Private Sub VoucherLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoucherLines.Click
        GlobalVoucherNumber2 = Val(cboVoucherNumber.Text)
        GlobalDivisionCode = cboDivisionID.Text

        Dim NewAPViewVoucherLines As New APViewVoucherLines
        NewAPViewVoucherLines.Show()
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        If chkViewDeleted.Checked = False Then
            ShowDataByFilter()
        Else
            ShowDeletedDataByFilter()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
        ClearDeletedDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If chkViewDeleted.Checked = True Then
            GDS = ds4
            GlobalVoucherType = "DELETED"

            Using NewPrintVoucherListingPD As New PrintVoucherListingPD
                Dim result = NewPrintVoucherListingPD.ShowDialog()
            End Using
        Else
            GDS = ds
            GlobalVoucherType = "POSTED"

            Using NewPrintVoucherListingPD As New PrintVoucherListingPD
                Dim result = NewPrintVoucherListingPD.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintVoucherListingPD As New PrintVoucherListingPD
            Dim result = NewPrintVoucherListingPD.ShowDialog()
        End Using
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

    Private Sub chkViewDeleted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewDeleted.CheckedChanged
        If chkViewDeleted.Checked = True Then
            dgvBatchLinePostDate.Visible = False
            dgvDeletedVouchers.Visible = True
        Else
            dgvBatchLinePostDate.Visible = True
            dgvDeletedVouchers.Visible = False
        End If
    End Sub

    Private Sub dgvBatchLinePostDate_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvBatchLinePostDate.ColumnHeaderMouseClick
        FormatDatagrid()
    End Sub
End Class