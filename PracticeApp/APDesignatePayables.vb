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
Public Class APDesignatePayables
    Inherits System.Windows.Forms.Form

    Dim CheckVoucherExists, SelectedVoucher, DiscountDays As Integer
    Dim LastBatchNumber, NextBatchNumber As Long
    Dim BatchTotal, DiscountPercentage As Double
    Dim PaymentTerms, DuplicateVoucherExists As String
    Dim SumVendorTotalPlus, SumVendorTotalMinus, SumVendorTotalNet As Double
    Dim TodaysDate As Date = Today.ToShortDateString()
    Dim DeleteSingleBatch As Long = 0

    'Declare variables for ACH Batches
    Dim ATLACHBatchNumber, CBSACHBatchNumber, CGOACHBatchNumber, CHTACHBatchNumber, DENACHBatchNumber, HOUACHBatchNumber, LLHACHBatchNumber, SLCACHBatchNumber, TFFACHBatchNumberAmerican, TFJACHBatchNumber, TFFACHBatchNumberCanadian, ALBACHBatchNumberAmerican, ALBACHBatchNumberCanadian, TFTACHBatchNumber, TORACHBatchNumberAmerican, TORACHBatchNumberCanadian, TWDACHBatchNumber, TWEACHBatchNumber As Long
    Dim NewBatchNumber, OldBatchNumber As Long
    Dim ACHBatchCount As Integer = 0
    Dim DivisionACHBatchNumber As Long = 0
    Dim GlobalBatchNumber As Long = 0

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4 As DataSet

    Private Sub APDesignatePayables_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearVariables()
        ClearData()

        If EmployeeCompanyCode = "ADM" Then
            Try
                'Update to unselected
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid", con)

                With cmd.Parameters
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
        Else
            Try
                'Update to unselected
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid WHERE DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub APDesignatePayables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        'Set Company Default
        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
            Me.dgvPayables.Columns("DivisionIDColumn").Visible = True
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
            Me.dgvPayables.Columns("DivisionIDColumn").Visible = False
        End If

        'For Each row As DataGridViewRow In dgvPayables.Rows
        '    Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")
        '    cell.Value = "UNSELECTED"
        'Next

        ClearVariables()
        ClearData()

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            cboVendorClass.Enabled = True
            cboVendorClass.Text = "Canadian"
            ShowPostedVouchersCanadian()
        ElseIf cboDivisionID.Text = "ADM" Then
            cboVendorClass.SelectedIndex = -1
            cboVendorClass.Enabled = False

            ShowPostedVouchersADM()
        Else
            cboVendorClass.SelectedIndex = -1
            cboVendorClass.Enabled = False

            ShowPostedVouchers()
        End If

        If EmployeeLoginName = "HSRYAN" Or EmployeeSecurityCode = "1001" Then
            gpxPostOff.Enabled = True
        Else
            gpxPostOff.Enabled = False
        End If

        'Loads totals for the whole company
        LoadDivisionTotals()
        LoadCompanyTotals()
    End Sub

    Public Sub ShowPostedVouchers()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherStatus = @VoucherStatus AND DivisionID = @DivisionID ORDER BY VendorID", con)
        cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
        con.Close()

        dgvPayables.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")

        FormatWhitePaperChecks()
    End Sub

    Public Sub FormatWhitePaperChecks()
        Dim CheckType As String = ""
        Dim IsWhitePaper As String = ""

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvPayables.Rows
            Try
                CheckType = row.Cells("CheckTypeColumn").Value
            Catch ex As System.Exception
                CheckType = ""
            End Try
            Try
                IsWhitePaper = row.Cells("WhitePaperColumn").Value
            Catch ex As System.Exception
                IsWhitePaper = "NO"
            End Try

            If CheckType = "STANDARD" And IsWhitePaper = "YES" Then
                Me.dgvPayables.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvPayables.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            ElseIf CheckType = "STANDARD" And IsWhitePaper <> "YES" Then
                Me.dgvPayables.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvPayables.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            ElseIf CheckType = "FEDEX" Then
                Me.dgvPayables.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvPayables.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            ElseIf CheckType = "INTERCOMPANY" Then
                Me.dgvPayables.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvPayables.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Red
            ElseIf CheckType = "ACH" Then
                Me.dgvPayables.Rows(RowIndex).DefaultCellStyle.BackColor = Color.LightGray
                Me.dgvPayables.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Purple
            Else
                Me.dgvPayables.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
                Me.dgvPayables.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub FormatADM()
        '*********************************************************************************************************************
        Dim CountIndex As Integer = 0
        Dim LineDivision As String = ""

        'Format
        For Each row As DataGridViewRow In dgvPayables.Rows
            Try
                LineDivision = dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                LineDivision = ""
            End Try

            Select Case LineDivision
                Case "ATL"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightBlue
                    Catch ex As Exception
                        'skip
                    End Try
                Case "CBS"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightCoral
                    Catch ex As Exception
                        'skip
                    End Try
                Case "CGO"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightSeaGreen
                    Catch ex As Exception
                        'skip
                    End Try
                Case "CHT"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightYellow
                    Catch ex As Exception
                        'skip
                    End Try
                Case "DEN"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightSalmon
                    Catch ex As Exception
                        'skip
                    End Try
                Case "HOU"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightSlateGray
                    Catch ex As Exception
                        'skip
                    End Try
                Case "LLH"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightCyan
                    Catch ex As Exception
                        'skip
                    End Try
                Case "SLC"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightPink
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TFF"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightCoral
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TFJ"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LemonChiffon
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TFT"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightGoldenrodYellow
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TWD"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightSteelBlue
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TFP"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightGray
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TOR"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightCyan
                    Catch ex As Exception
                        'skip
                    End Try
                Case "TWE"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.LightGreen
                    Catch ex As Exception
                        'skip
                    End Try
                Case "ALB"
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.Wheat
                    Catch ex As Exception
                        'skip
                    End Try
                Case Else
                    Try
                        dgvPayables.Rows(CountIndex).Cells("DivisionIDColumn").Style.BackColor = Color.White
                    Catch ex As Exception
                        'skip
                    End Try
            End Select

            CountIndex = CountIndex + 1
        Next
    End Sub

    Public Sub ShowPostedVouchersADM()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherStatus = @VoucherStatus AND DivisionID <> @DivisionID AND DivisionID <> @DivisionID2 ORDER BY DivisionID, VendorID", con)
        cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
        cmd.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TST"
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
        con.Close()

        dgvPayables.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")

        FormatWhitePaperChecks()
        FormatADM()
    End Sub

    Public Sub ShowPostedVouchersAmerican()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherStatus = @VoucherStatus AND DivisionID = @DivisionID AND VendorClass = @VendorClass ORDER BY VendorID", con)
        cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
        con.Close()

        dgvPayables.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")

        FormatWhitePaperChecks()
    End Sub

    Public Sub ShowPostedVouchersCanadian()
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE VoucherStatus = @VoucherStatus AND DivisionID = @DivisionID AND VendorClass = @VendorClass ORDER BY VendorID", con)
        cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
        con.Close()

        dgvPayables.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")

        FormatWhitePaperChecks()
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
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            cboVendorClass.Enabled = True
            cboVendorClass.Text = "Canadian"
            nbrDaysOutACH.Value = 1
        Else
            cboVendorClass.SelectedIndex = -1
            cboVendorClass.Enabled = False
            nbrDaysOutACH.Value = 1
        End If
    End Sub

    Public Sub ClearVariables()
        LastBatchNumber = 0
        NextBatchNumber = 0
        SelectedVoucher = 0
        DiscountDays = 0
        BatchTotal = 0
        DiscountPercentage = 0
        PaymentTerms = ""
        CheckVoucherExists = 0
        DuplicateVoucherExists = "NO"
        SumVendorTotalPlus = 0
        SumVendorTotalMinus = 0
        SumVendorTotalNet = 0
    End Sub

    Private Sub LoadCompanyTotals()
        Dim TotalOpenPayables, TotalPendingPayables, TotalPayablesRemaining As Double

        'Check APVoucherTable
        Dim TotalPendingPayablesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID <> 'TST' AND VoucherStatus = @VoucherStatus"
        Dim TotalPendingPayablesCommand As New SqlCommand(TotalPendingPayablesStatement, con)
        TotalPendingPayablesCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "PENDING"

        Dim TotalPayablesRemainingStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID <> 'TST' AND VoucherStatus = @VoucherStatus"
        Dim TotalPayablesRemainingCommand As New SqlCommand(TotalPayablesRemainingStatement, con)
        TotalPayablesRemainingCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalPendingPayables = CDbl(TotalPendingPayablesCommand.ExecuteScalar)
        Catch ex As Exception
            TotalPendingPayables = 0
        End Try
        Try
            TotalPayablesRemaining = CDbl(TotalPayablesRemainingCommand.ExecuteScalar)
        Catch ex As Exception
            TotalPendingPayables = 0
        End Try
        con.Close()

        TotalOpenPayables = TotalPendingPayables + TotalPayablesRemaining

        lblCompanyOpenPayables.Text = FormatCurrency(TotalOpenPayables, 2)
        lblCompanyTotalRemaining.Text = FormatCurrency(TotalPayablesRemaining, 2)
        lblCompanyTotalPending.Text = FormatCurrency(TotalPendingPayables, 2)
    End Sub

    Public Sub LoadDivisionTotals()
        Dim DivisionOpenPayables, DivisionPendingPayables, DivisionRemainingPayables As Double

        'Retrieve Discount Days for selected Payment Term
        Dim SumOpenPayablesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE VoucherStatus = @VoucherStatus AND DivisionID = @DivisionID"
        Dim SumOpenPayablesCommand As New SqlCommand(SumOpenPayablesStatement, con)
        SumOpenPayablesCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
        SumOpenPayablesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SumPendingPayablesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE VoucherStatus = @VoucherStatus AND DivisionID = @DivisionID"
        Dim SumPendingPayablesCommand As New SqlCommand(SumPendingPayablesStatement, con)
        SumPendingPayablesCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "PENDING"
        SumPendingPayablesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DivisionRemainingPayables = CDbl(SumOpenPayablesCommand.ExecuteScalar)
        Catch ex As Exception
            DivisionRemainingPayables = 0
        End Try
        Try
            DivisionPendingPayables = CDbl(SumPendingPayablesCommand.ExecuteScalar)
        Catch ex As Exception
            DivisionPendingPayables = 0
        End Try
        con.Close()

        DivisionOpenPayables = DivisionRemainingPayables + DivisionPendingPayables

        lblTotalOpenPayables.Text = FormatCurrency(DivisionRemainingPayables, 2)
        lblTotalPending.Text = FormatCurrency(DivisionPendingPayables, 2)
        lblGrandTotal.Text = FormatCurrency(DivisionOpenPayables, 2)
    End Sub

    Private Sub cboVendorClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorClass.SelectedIndexChanged
        If cboVendorClass.Text = "Canadian" And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
            ShowPostedVouchersCanadian()
        ElseIf cboVendorClass.Text = "American" And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
            ShowPostedVouchersAmerican()
        ElseIf cboDivisionID.Text <> "TFF" And cboDivisionID.Text <> "TOR" And cboDivisionID.Text <> "ALB" Then
            ShowPostedVouchers()
        End If
    End Sub

    Private Sub cmdSelectLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectLines.Click
        Dim InvoiceTotal, VendorTotal As Double
        Dim VendorID, RowDivision As String
        Dim DueDate, DiscountDate As Date
        '********************************************************
        'Update to get rid of Nulls
        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET OnHold = @OnHold WHERE OnHold IS NULL", con)

        With cmd.Parameters
            .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '-------------------------------------------------------------------------------------
        'Check #1 --- Check for due date
        For Each row As DataGridViewRow In dgvPayables.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")
            Try
                DueDate = row.Cells("DueDateColumn").Value
            Catch ex As Exception
                DueDate = dtpDueDate.Value
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
                DiscountDate = dtpDueDate.Value
            End Try
            Try
                RowDivision = row.Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivision = ""
            End Try

            If DueDate <= dtpDueDate.Value And InvoiceTotal >= 0 Then
                cell.Value = "SELECTED"
            Else
                'Do nothing
            End If

            'Check to see if any credit can be taken
            Dim SumVendorStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND InvoiceTotal >= @InvoiceTotal AND VoucherStatus = @VoucherStatus AND (DueDate <= @DueDate OR DiscountDate <= @DiscountDate)"
            Dim SumVendorCommand As New SqlCommand(SumVendorStatement, con)
            SumVendorCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
            SumVendorCommand.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
            SumVendorCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
            SumVendorCommand.Parameters.Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
            SumVendorCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
            SumVendorCommand.Parameters.Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDueDate.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VendorTotal = CDbl(SumVendorCommand.ExecuteScalar)
            Catch ex As Exception
                VendorTotal = 0
            End Try
            con.Close()

            If InvoiceTotal < 0 And (VendorTotal - (InvoiceTotal * -1) > 0) Then
                cell.Value = "SELECTED"
            Else
                'Do nothing
            End If
        Next

        '-------------------------------------------------------------------------------------
        'Check #2 --- Check for discount date
        For Each row As DataGridViewRow In dgvPayables.Rows
            Dim cell1 As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")
            Try
                DiscountDate = row.Cells("DiscountDateColumn").Value
            Catch ex As Exception
                DiscountDate = dtpDueDate.Value
            End Try
            Try
                PaymentTerms = row.Cells("PaymentTermsColumn").Value
            Catch ex As Exception
                PaymentTerms = "N30"
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

            'Verifies that the line selected offers a discount
            SelectDiscountDays()

            If DiscountDays = 0 Then
                'Do nothing - no discount
            Else
                If DiscountDate <= dtpDueDate.Value And InvoiceTotal >= 0 Then
                    cell1.Value = "SELECTED"
                Else
                    'Do nothing
                End If
            End If
        Next

        '-------------------------------------------------------------------------------------
        'Check #3 --- Unselect if credit exceeds the sum of the invoices for that vendor
        For Each row As DataGridViewRow In dgvPayables.Rows
            Dim cell2 As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")

            If cell2.Value = "SELECTED" Then
                Try
                    DueDate = row.Cells("DueDateColumn").Value
                Catch ex As Exception
                    DueDate = dtpDueDate.Value
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
                    RowDivision = row.Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivision = ""
                End Try
                Try
                    DiscountDate = row.Cells("DiscountDateColumn").Value
                Catch ex As Exception
                    DiscountDate = dtpDueDate.Value
                End Try

                If DueDate <= dtpDueDate.Value And InvoiceTotal >= 0 Then
                    cell2.Value = "SELECTED"
                Else
                    'Do nothing
                End If

                'Check to see of there is a credit that exceeds the sum of the invoices and un-select the invoices
                Dim SumVendorPlusStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND InvoiceTotal >= @InvoiceTotal AND VoucherStatus = @VoucherStatus AND (DueDate <= @DueDate OR DiscountDate <= @DiscountDate)"
                Dim SumVendorPlusCommand As New SqlCommand(SumVendorPlusStatement, con)
                SumVendorPlusCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                SumVendorPlusCommand.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
                SumVendorPlusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                SumVendorPlusCommand.Parameters.Add("@DueDate", SqlDbType.VarChar).Value = dtpDueDate.Text
                SumVendorPlusCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                SumVendorPlusCommand.Parameters.Add("@DiscountDate", SqlDbType.VarChar).Value = dtpDueDate.Text

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
                SumVendorMinusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
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
                    cell2.Value = "UNSELECTED"
                Else
                    'Do nothing
                End If
            End If
        Next
        '-------------------------------------------------------------------------------------
        'Check #4 --- Unselect if voucher is on hold
        For Each row As DataGridViewRow In dgvPayables.Rows
            Dim cell3 As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")
            Dim OnholdStatus As String = ""

            If cell3.Value = "SELECTED" Then
                Try
                    OnholdStatus = row.Cells("OnHoldColumn").Value
                Catch ex As Exception
                    OnholdStatus = "NO"
                End Try

                If OnholdStatus = "YES" Then
                    cell3.Value = "UNSELECTED"
                Else
                    'Skip
                End If
            End If
        Next
        '-------------------------------------------------------------------------------------
        'Check #5 --- Unselect if voucher is ACH and more than one day out
        For Each row As DataGridViewRow In dgvPayables.Rows
            Dim cell4 As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")

            If cell4.Value = "SELECTED" Then
                Dim CheckType As String = ""
                Dim ACHDueDate As Date = Today()
                Dim CheckDayOfWeek As Integer = 0
                Dim NewACHDueDate As Date
                Dim NumberOfDaysToAdd As Integer = 1

                NumberOfDaysToAdd = nbrDaysOutACH.Value

                CheckDayOfWeek = ACHDueDate.DayOfWeek

                If CheckDayOfWeek = 5 And nbrDaysOutACH.Value = 1 Then
                    NewACHDueDate = ACHDueDate.AddDays(3)
                Else
                    NewACHDueDate = ACHDueDate.AddDays(NumberOfDaysToAdd)
                End If

                Try
                    CheckType = row.Cells("CheckTypeColumn").Value
                Catch ex As Exception
                    CheckType = "STANDARD"
                End Try
                Try
                    DiscountDate = row.Cells("DiscountDateColumn").Value
                Catch ex As Exception
                    DiscountDate = dtpDueDate.Value
                End Try
                Try
                    DueDate = row.Cells("DueDateColumn").Value
                Catch ex As Exception
                    DueDate = dtpDueDate.Value
                End Try

                If CheckType <> "STANDARD" And (DueDate > NewACHDueDate And DiscountDate > NewACHDueDate) Then
                    cell4.Value = "UNSELECTED"
                Else
                    'Skip
                End If
            End If
        Next
        '-------------------------------------------------------------------------------------
        'Update Database to show selected invoices in datagrid
        For Each row As DataGridViewRow In dgvPayables.Rows
            Dim cell6 As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")
            Dim RowVoucherNumber As Integer = 0
            Dim RowDivisionID As String = ""

            If cell6.Value = "SELECTED" Then
                Try
                    RowVoucherNumber = row.Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    RowVoucherNumber = 0
                End Try
                Try
                    RowDivisionID = row.Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivisionID = ""
                End Try

                'Update to selected
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = RowVoucherNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "YES"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                Try
                    RowVoucherNumber = row.Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    RowVoucherNumber = 0
                End Try
                Try
                    RowDivisionID = row.Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivisionID = ""
                End Try

                'Update to unselected
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = RowVoucherNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        '-------------------------------------------------------------------------------------
        'Check #6 --- Unselect if voucher is ACH and would produce a negative check for items selected
        For Each row As DataGridViewRow In dgvPayables.Rows
            Dim cell5 As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")

            If cell5.Value = "SELECTED" Then
                Dim RowVendor As String = ""
                Dim RowDivisionID As String = ""
                Dim SumVendorTotalPlus As Double = 0
                Dim SumVendorTotalMinus As Double = 0

                Try
                    RowVendor = row.Cells("VendorIDColumn").Value
                Catch ex As Exception
                    RowVendor = ""
                End Try
                Try
                    RowDivisionID = row.Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivisionID = ""
                End Try

                'Check to see of there is a credit that exceeds the sum of the invoices and un-select the invoices
                Dim SumVendorPlusStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND InvoiceTotal >= @InvoiceTotal AND SelectedInDatagrid = @SelectedInDatagrid AND VoucherStatus = @VoucherStatus"
                Dim SumVendorPlusCommand As New SqlCommand(SumVendorPlusStatement, con)
                SumVendorPlusCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = RowVendor
                SumVendorPlusCommand.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
                SumVendorPlusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                SumVendorPlusCommand.Parameters.Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "YES"
                SumVendorPlusCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
    
                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumVendorTotalPlus = CDbl(SumVendorPlusCommand.ExecuteScalar)
                Catch ex As Exception
                    SumVendorTotalPlus = 0
                End Try
                con.Close()

                Dim SumVendorMinusStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE VendorID = @VendorID AND DivisionID = @DivisionID AND InvoiceTotal < @InvoiceTotal AND SelectedInDatagrid = @SelectedInDatagrid AND VoucherStatus = @VoucherStatus"
                Dim SumVendorMinusCommand As New SqlCommand(SumVendorMinusStatement, con)
                SumVendorMinusCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = RowVendor
                SumVendorMinusCommand.Parameters.Add("@InvoiceTotal", SqlDbType.VarChar).Value = 0
                SumVendorMinusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                SumVendorMinusCommand.Parameters.Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "YES"
                SumVendorMinusCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
              
                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumVendorTotalMinus = CDbl(SumVendorMinusCommand.ExecuteScalar)
                Catch ex As Exception
                    SumVendorTotalMinus = 0
                End Try
                con.Close()

                If SumVendorTotalPlus <= (SumVendorTotalMinus * -1) Then
                    cell5.Value = "UNSELECTED"
                Else
                    'Skip
                End If
            End If
        Next
        '-------------------------------------------------------------------------------------
        'Update Database to show selected invoices in datagrid
        For Each row As DataGridViewRow In dgvPayables.Rows
            Dim cell7 As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")
            Dim RowVoucherNumber As Integer = 0
            Dim RowDivisionID As String = ""

            If cell7.Value = "SELECTED" Then
                Try
                    RowVoucherNumber = row.Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    RowVoucherNumber = 0
                End Try
                Try
                    RowDivisionID = row.Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivisionID = ""
                End Try

                'Update to selected
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = RowVoucherNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "YES"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                Try
                    RowVoucherNumber = row.Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    RowVoucherNumber = 0
                End Try
                Try
                    RowDivisionID = row.Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivisionID = ""
                End Try

                'Update to unselected
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = RowVoucherNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        '-------------------------------------------------------------------------------------
        'Check #7 --- Unselect if voucher is ACH/INTERCOMPANY and would be selected over the weekend from a Friday
        '             Friday - if the 2,3,4 or 17,18,19 fall on a Friday, wait until Monday to process intercompany checks

        '-------------------------------------------------------------------------------------
        'Check if today is Friday - if not, skip this whole routine
        Dim CheckFridayDate As Date = Today()
        Dim FridaysDayOfWeek As Integer = 0
        FridaysDayOfWeek = CheckFridayDate.Day

        If CheckFridayDate.DayOfWeek = DayOfWeek.Friday Then

            'If today is Friday - and today is the 2nd, 3rd, 4th, 17th, 18th, 19th - unselect Intercompany Vouchers
            If FridaysDayOfWeek = 2 Or FridaysDayOfWeek = 3 Or FridaysDayOfWeek = 4 Or FridaysDayOfWeek = 17 Or FridaysDayOfWeek = 18 Or FridaysDayOfWeek = 19 Then
                For Each row As DataGridViewRow In dgvPayables.Rows
                    Dim cell7 As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")

                    If cell7.Value = "SELECTED" Then
                        Dim RowCheckType As String = ""

                        Try
                            RowCheckType = row.Cells("CheckTypeColumn").Value
                        Catch ex As Exception
                            RowCheckType = ""
                        End Try

                        'Uncheck if Intercompany
                        If RowCheckType = "INTERCOMPANY" Then
                            cell7.Value = "UNSELECTED"
                        Else
                            'Skip
                        End If
                    End If
                Next
                '-------------------------------------------------------------------------------------
                'Update Database to show selected invoices in datagrid
                For Each row As DataGridViewRow In dgvPayables.Rows
                    Dim cell8 As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")
                    Dim RowVoucherNumber As Integer = 0
                    Dim RowDivisionID As String = ""

                    If cell8.Value = "SELECTED" Then
                        Try
                            RowVoucherNumber = row.Cells("VoucherNumberColumn").Value
                        Catch ex As Exception
                            RowVoucherNumber = 0
                        End Try
                        Try
                            RowDivisionID = row.Cells("DivisionIDColumn").Value
                        Catch ex As Exception
                            RowDivisionID = ""
                        End Try

                        'Update to selected
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = RowVoucherNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                            .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "YES"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        Try
                            RowVoucherNumber = row.Cells("VoucherNumberColumn").Value
                        Catch ex As Exception
                            RowVoucherNumber = 0
                        End Try
                        Try
                            RowDivisionID = row.Cells("DivisionIDColumn").Value
                        Catch ex As Exception
                            RowDivisionID = ""
                        End Try

                        'Update to unselected
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = RowVoucherNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                            .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                Next
            Else
                'Skip routine if Friday isn't the 2, 3, 4, 17, 18, or 19
            End If
        Else
            'Skip - only run routine if today is a Friday
        End If
        '-------------------------------------------------------------------------------------

        MsgBox("Selections have been made.", MsgBoxStyle.OkOnly)
    End Sub

    Public Sub SelectDiscountDays()
        'Retrieve Discount Days for selected Payment Term
        Dim DiscountDaysStatement As String = "SELECT DiscountDays FROM PaymentTerms WHERE PmtTermsID = @PmtTermsID"
        Dim DiscountDaysCommand As New SqlCommand(DiscountDaysStatement, con)
        DiscountDaysCommand.Parameters.Add("@PmtTermsID", SqlDbType.VarChar).Value = PaymentTerms

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DiscountDays = CInt(DiscountDaysCommand.ExecuteScalar)
        Catch ex As Exception
            DiscountDays = 0
        End Try
        con.Close()
    End Sub

    Private Sub cmdClearGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearGrid.Click
        For Each row As DataGridViewRow In dgvPayables.Rows
            Dim RowVoucherNumber As Integer = 0
            Dim RowDivisionID As String = ""

            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")
            cell.Value = "UNSELECTED"

            Try
                RowVoucherNumber = row.Cells("VoucherNumberColumn").Value
            Catch ex As Exception
                RowVoucherNumber = 0
            End Try
            Try
                RowDivisionID = row.Cells("DivisionIDColumn").Value
            Catch ex As Exception
                RowDivisionID = ""
            End Try

            'Update to selected
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = RowVoucherNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            nbrDaysOutACH.Value = 1
        Next
    End Sub

    Private Sub cmdPostPayables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostPayables.Click
        'Check to see if any selected vouchers already belong to an AP Payment Batch

        'Initialize Variables used to check if voucher already exists
        CheckVoucherExists = 0
        DuplicateVoucherExists = "NO"

        'Retrieve line data from Receipt of Invoice and write to AP Voucher Table
        For Each row As DataGridViewRow In dgvPayables.Rows
            Dim cell5 As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")
            Dim cell6 As DataGridViewCheckBoxCell = row.Cells("OnHoldColumn")

            If IsDBNull(row.Cells("OnHoldColumn").Value) Then
                cell6.Value = "NO"
            Else
                cell6.Value = row.Cells("OnHoldColumn").Value
            End If

            If cell6.Value = "YES" Then
                cell5.Value = "UNSELECTED"
            End If

            If cell5.Value = "SELECTED" Then
                Dim CheckVoucherNumber As Integer = row.Cells("VoucherNumberColumn").Value
                Dim CheckVendorID As String = row.Cells("VendorIDColumn").Value
                Dim CheckDivisionID As String = row.Cells("DivisionIDColumn").Value

                'Check APVoucherTable
                Dim CheckVoucherExistsStatement As String = "SELECT VoucherNumber FROM APVoucherTable WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID AND VendorID = @VendorID"
                Dim CheckVoucherExistsCommand As New SqlCommand(CheckVoucherExistsStatement, con)
                CheckVoucherExistsCommand.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = CheckVoucherNumber
                CheckVoucherExistsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CheckDivisionID
                CheckVoucherExistsCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = CheckVendorID

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckVoucherExists = CInt(CheckVoucherExistsCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckVoucherExists = 0
                End Try
                con.Close()
            End If

            If CheckVoucherExists > 0 Then
                DuplicateVoucherExists = "YES"

                'Log error on update failure
                Dim TempVoucherNumber As Integer = 0
                Dim strVoucherNumber As String
                TempVoucherNumber = CheckVoucherExists
                strVoucherNumber = CStr(TempVoucherNumber)

                ErrorDate = Today()
                ErrorComment = "Duplicate Voucher in Designate Batch"
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Designate Payables --- Duplicate Voucher"
                ErrorReferenceNumber = "Voucher # " + strVoucherNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                Exit For
            Else
                'Continue to next voucher
            End If

            DuplicateVoucherExists = "NO"
        Next

        If DuplicateVoucherExists = "YES" Then
            MsgBox("A batch has already been created that contains one or more payables that you have selected. This form will refresh to show what payables remain and your selections will be lost", MsgBoxStyle.OkOnly)

            'Refresh form data
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                cboVendorClass.Enabled = True
                cboVendorClass.Text = "Canadian"
                ShowPostedVouchersCanadian()
            ElseIf cboDivisionID.Text = "ADM" Then
                cboVendorClass.SelectedIndex = -1
                cboVendorClass.Enabled = False

                ShowPostedVouchersADM()
            Else
                cboVendorClass.SelectedIndex = -1
                cboVendorClass.Enabled = False

                ShowPostedVouchers()
            End If
        Else
            If cboDivisionID.Text = "ADM" Then
                'If Division = ADM, create a separate batch for each division
                Dim ATLBatchNumber, CGOBatchNumber, CHTBatchNumber, CBSBatchNumber, HOUBatchNumber, LLHBatchNumber, DENBatchNumber, SLCBatchNumber, TFFBatchNumberCanadian, TFFBatchNumberAmerican, ALBBatchNumberCanadian, ALBBatchNumberAmerican, TFTBatchNumber, TWDBatchNumber, TFJBatchNumber, TWEBatchNumber, TORBatchNumberCanadian, TorBatchNumberAmerican As Long
                Dim Counter As Integer = 1
                Dim TempDivision As String = ""

                'Create a batch for each division
                For i As Integer = 1 To 15
                    'Get new Batch Number
                    Dim MaxBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim MaxBatchCommand As New SqlCommand(MaxBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        LastBatchNumber = CLng(MaxBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        LastBatchNumber = 997000000
                    End Try
                    con.Close()

                    NextBatchNumber = LastBatchNumber + 1

                    Select Case Counter
                        Case 1
                            ATLBatchNumber = NextBatchNumber

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = ATLBatchNumber
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 2
                            CBSBatchNumber = NextBatchNumber

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = CBSBatchNumber
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 3
                            CGOBatchNumber = NextBatchNumber

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = CGOBatchNumber
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 4
                            CHTBatchNumber = NextBatchNumber

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = CHTBatchNumber
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 5
                            DENBatchNumber = NextBatchNumber

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = DENBatchNumber
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 6
                            HOUBatchNumber = NextBatchNumber

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = HOUBatchNumber
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 7
                            SLCBatchNumber = NextBatchNumber
                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = SLCBatchNumber
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 8
                            TFFBatchNumberCanadian = NextBatchNumber

                            'Create Canadian Batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = TFFBatchNumberCanadian
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = "Canadian"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            TFFBatchNumberAmerican = NextBatchNumber + 1

                            'Create Anerican Batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = TFFBatchNumberAmerican
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = "American"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 9
                            TFTBatchNumber = NextBatchNumber

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = TFTBatchNumber
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 10
                            TWDBatchNumber = NextBatchNumber

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = TWDBatchNumber
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 11
                            TWEBatchNumber = NextBatchNumber

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = TWEBatchNumber
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 12
                            TORBatchNumberCanadian = NextBatchNumber

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = TORBatchNumberCanadian
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = "Canadian"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            TorBatchNumberAmerican = NextBatchNumber + 1

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = TorBatchNumberAmerican
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = "American"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 13
                            ALBBatchNumberCanadian = NextBatchNumber

                            'Create Canadian Batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = ALBBatchNumberCanadian
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = "Canadian"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()

                            ALBBatchNumberAmerican = NextBatchNumber + 1

                            'Create Anerican Batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = ALBBatchNumberAmerican
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = "American"
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 14
                            TFJBatchNumber = NextBatchNumber

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = TFJBatchNumber
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case 15
                            LLHBatchNumber = NextBatchNumber

                            'Create new batch
                            cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType, VendorClass) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType, @VendorClass)", con)

                            With cmd.Parameters
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = LLHBatchNumber
                                .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                                .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - STANDARD"
                                .Add("@DivisionID", SqlDbType.VarChar).Value = "LLH"
                                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                                .Add("@Locked", SqlDbType.VarChar).Value = ""
                                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                                .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                                .Add("@VendorClass", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Case Else
                            'Do nothing ... yet
                    End Select

                    Counter = Counter + 1
                Next i
                '*********************************************************************
                'Clear variables to be used again
                NextBatchNumber = 0
                '*********************************************************************
                'Save selection into temp field in voucher table
                Dim TempVoucherNumber As Integer = 0
                Dim TempDivisionID As String = ""

                For Each TempRow As DataGridViewRow In dgvPayables.Rows
                    Dim TempCell As DataGridViewCheckBoxCell = TempRow.Cells("SelectForPayment")

                    If TempCell.Value = "SELECTED" Then
                        Try
                            TempVoucherNumber = TempRow.Cells("VoucherNumberColumn").Value
                        Catch ex As Exception
                            TempVoucherNumber = 0
                        End Try
                        Try
                            TempDivisionID = TempRow.Cells("DivisionIDColumn").Value
                        Catch ex As Exception
                            TempDivisionID = ""
                        End Try

                        'Update temp selected status
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET TempSelected = @TempSelected WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = TempVoucherNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = TempDivisionID
                            .Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                Next

                '**********************************************************************
                'After all regular check batches are created, 
                'check to see if ACH batches are needed, and create if necessary
                '**********************************************************************

                '**********************************************************************
                'Create ATL Batch for ACH, if necessary
                Dim ATLACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                Dim ATLACHBatchCountCommand As New SqlCommand(ATLACHBatchCountStatement, con)
                ATLACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                ATLACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                ATLACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                ATLACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(ATLACHBatchCountCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    ATLACHBatchNumber = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = ATLACHBatchNumber
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    ATLACHBatchNumber = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create CBS Batch for ACH, if necessary
                Dim CBSACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                Dim CBSACHBatchCountCommand As New SqlCommand(CBSACHBatchCountStatement, con)
                CBSACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                CBSACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                CBSACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                CBSACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(CBSACHBatchCountCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    CBSACHBatchNumber = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = CBSACHBatchNumber
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    CBSACHBatchNumber = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create CGO Batch for ACH, if necessary
                Dim CGOACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                Dim CGOACHBatchCountCommand As New SqlCommand(CGOACHBatchCountStatement, con)
                CGOACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                CGOACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                CGOACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                CGOACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(CGOACHBatchCountCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    CGOACHBatchNumber = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = CGOACHBatchNumber
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    CGOACHBatchNumber = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create CHT Batch for ACH, if necessary
                Dim CHTACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                Dim CHTACHBatchCountCommand As New SqlCommand(CHTACHBatchCountStatement, con)
                CHTACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                CHTACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                CHTACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                CHTACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(CHTACHBatchCountCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    CHTACHBatchNumber = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = CHTACHBatchNumber
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    CHTACHBatchNumber = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create DEN Batch for ACH, if necessary
                Dim DENACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                Dim DENACHBatchCountCommand As New SqlCommand(DENACHBatchCountStatement, con)
                DENACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                DENACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                DENACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                DENACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(DENACHBatchCountCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    DENACHBatchNumber = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = DENACHBatchNumber
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    DENACHBatchNumber = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create HOU Batch for ACH, if necessary
                Dim HOUACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                Dim HOUACHBatchCountCommand As New SqlCommand(HOUACHBatchCountStatement, con)
                HOUACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                HOUACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                HOUACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                HOUACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(HOUACHBatchCountCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    HOUACHBatchNumber = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = HOUACHBatchNumber
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    HOUACHBatchNumber = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create LLH Batch for ACH, if necessary
                Dim LLHACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                Dim LLHACHBatchCountCommand As New SqlCommand(LLHACHBatchCountStatement, con)
                LLHACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "LLH"
                LLHACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                LLHACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                LLHACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(LLHACHBatchCountCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    LLHACHBatchNumber = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = LLHACHBatchNumber
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "LLH"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    LLHACHBatchNumber = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create SLC Batch for ACH, if necessary
                Dim SLCACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                Dim SLCACHBatchCountCommand As New SqlCommand(SLCACHBatchCountStatement, con)
                SLCACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                SLCACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                SLCACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                SLCACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(SLCACHBatchCountCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    SLCACHBatchNumber = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = SLCACHBatchNumber
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    SLCACHBatchNumber = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create TFF Batch for ACH, if necessary
                Dim TFFACHBatchCountCanadianStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus AND VendorClass = @VendorClass"
                Dim TFFACHBatchCountCanadianCommand As New SqlCommand(TFFACHBatchCountCanadianStatement, con)
                TFFACHBatchCountCanadianCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                TFFACHBatchCountCanadianCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                TFFACHBatchCountCanadianCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                TFFACHBatchCountCanadianCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                TFFACHBatchCountCanadianCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "CANADIAN"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(TFFACHBatchCountCanadianCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    TFFACHBatchNumberCanadian = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = TFFACHBatchNumberCanadian
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    TFFACHBatchNumberCanadian = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '****************************************************************************************************************
                'Create TFF Batch for ACH, if necessary
                Dim TFFACHBatchCountAmericanStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus AND VendorClass = @VendorClass"
                Dim TFFACHBatchCountAmericanCommand As New SqlCommand(TFFACHBatchCountAmericanStatement, con)
                TFFACHBatchCountAmericanCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                TFFACHBatchCountAmericanCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                TFFACHBatchCountAmericanCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                TFFACHBatchCountAmericanCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                TFFACHBatchCountAmericanCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "American"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(TFFACHBatchCountAmericanCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    TFFACHBatchNumberAmerican = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = TFFACHBatchNumberAmerican
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    TFFACHBatchNumberAmerican = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '*************************************************************************************************************
                'Create ALB Batch for ACH Canadian if necessary
                Dim ALBACHBatchCountCanadianStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus AND VendorClass = @VendorClass"
                Dim ALBACHBatchCountCanadianCommand As New SqlCommand(ALBACHBatchCountCanadianStatement, con)
                ALBACHBatchCountCanadianCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                ALBACHBatchCountCanadianCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                ALBACHBatchCountCanadianCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                ALBACHBatchCountCanadianCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                ALBACHBatchCountCanadianCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "CANADIAN"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(ALBACHBatchCountCanadianCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    ALBACHBatchNumberCanadian = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = ALBACHBatchNumberCanadian
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    ALBACHBatchNumberCanadian = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '****************************************************************************************************************
                'Create ALB Batch for ACH American, if necessary
                Dim ALBACHBatchCountAmericanStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus AND VendorClass = @VendorClass"
                Dim ALBACHBatchCountAmericanCommand As New SqlCommand(ALBACHBatchCountAmericanStatement, con)
                ALBACHBatchCountAmericanCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                ALBACHBatchCountAmericanCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                ALBACHBatchCountAmericanCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                ALBACHBatchCountAmericanCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                ALBACHBatchCountAmericanCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "American"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(ALBACHBatchCountAmericanCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    ALBACHBatchNumberAmerican = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = ALBACHBatchNumberAmerican
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    ALBACHBatchNumberAmerican = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create ATL Batch for ACH, if necessary
                Dim TFJACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                Dim TFJACHBatchCountCommand As New SqlCommand(TFJACHBatchCountStatement, con)
                TFJACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                TFJACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                TFJACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                TFJACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(TFJACHBatchCountCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    TFJACHBatchNumber = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = TFJACHBatchNumber
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "TFJ"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    TFJACHBatchNumber = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create TFT Batch for ACH, if necessary
                Dim TFTACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                Dim TFTACHBatchCountCommand As New SqlCommand(TFTACHBatchCountStatement, con)
                TFTACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                TFTACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                TFTACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                TFTACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(TFTACHBatchCountCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    TFTACHBatchNumber = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = TFTACHBatchNumber
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    TFTACHBatchNumber = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create TWD Batch for white paper, if necessary
                Dim TWDACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                Dim TWDACHBatchCountCommand As New SqlCommand(TWDACHBatchCountStatement, con)
                TWDACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                TWDACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                TWDACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                TWDACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(TWDACHBatchCountCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    TWDACHBatchNumber = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = TWDACHBatchNumber
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    TWDACHBatchNumber = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create TWE Batch for white paper, if necessary
                Dim TWEACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                Dim TWEACHBatchCountCommand As New SqlCommand(TWEACHBatchCountStatement, con)
                TWEACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                TWEACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                TWEACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                TWEACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(TWEACHBatchCountCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    TWEACHBatchNumber = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = TWEACHBatchNumber
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    TWEACHBatchNumber = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create TOR Batch for white paper, if necessary
                Dim TORACHBatchCountCanadianStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus AND VendorClass = @VendorClass"
                Dim TORACHBatchCountCanadianCommand As New SqlCommand(TORACHBatchCountCanadianStatement, con)
                TORACHBatchCountCanadianCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                TORACHBatchCountCanadianCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                TORACHBatchCountCanadianCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                TORACHBatchCountCanadianCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                TORACHBatchCountCanadianCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "CANADIAN"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(TORACHBatchCountCanadianCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    TORACHBatchNumberCanadian = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = TORACHBatchNumberCanadian
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    TORACHBatchNumberCanadian = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************
                'Create TOR Batch for white paper, if necessary
                Dim TORACHBatchCountAmericanStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus AND VendorClass = @VendorClass"
                Dim TORACHBatchCountAmericanCommand As New SqlCommand(TORACHBatchCountAmericanStatement, con)
                TORACHBatchCountAmericanCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                TORACHBatchCountAmericanCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                TORACHBatchCountAmericanCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                TORACHBatchCountAmericanCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                TORACHBatchCountAmericanCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "American"

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHBatchCount = CInt(TORACHBatchCountAmericanCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHBatchCount = 0
                End Try
                con.Close()

                If ACHBatchCount > 0 Then
                    'Get new Batch Number
                    Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                    Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        OldBatchNumber = 997000000
                    End Try
                    con.Close()

                    NewBatchNumber = OldBatchNumber + 1
                    TORACHBatchNumberAmerican = NewBatchNumber

                    'Create new batch
                    cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                    With cmd.Parameters
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = TORACHBatchNumberAmerican
                        .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                        .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                        .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                        .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@Locked", SqlDbType.VarChar).Value = ""
                        .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    NewBatchNumber = 0
                    OldBatchNumber = 0
                Else
                    TORACHBatchNumberAmerican = 0
                End If

                'Clear variables used
                ACHBatchCount = 0
                '**********************************************************************

            

                '**********************************************************************
                'All batches are created, separate vouchers into correct batches

                'Retrieve line data from Receipt of Invoice and write to AP Voucher Table
                For Each row As DataGridViewRow In dgvPayables.Rows
                    Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")

                    If cell.Value = "SELECTED" Then
                        Dim VoucherNumber, PONumber As Integer
                        Dim InvoiceNumber, InvoiceDate, ReceiptDate, DueDate, DiscountDate, VendorID, Comment, PaymentTerms As String
                        Dim ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, DiscountAmount As Double
                        Dim RowDivision As String = ""
                        Dim VendorClass As String = ""
                        Dim CheckType As String = ""
                        Dim WhitePaper As String = ""
                        Dim Checked1099 As String = "NO"

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
                            RowDivision = row.Cells("DivisionIDColumn").Value
                        Catch ex As Exception
                            RowDivision = ""
                        End Try
                        Try
                            VendorClass = row.Cells("VendorClassColumn").Value
                        Catch ex As Exception
                            VendorClass = ""
                        End Try
                        Try
                            CheckType = row.Cells("CheckTypeColumn").Value
                        Catch ex As Exception
                            CheckType = ""
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
                        If InvoiceTotal < 0 Then
                            PaymentTerms = "N30"
                            DiscountAmount = 0
                        End If

                        'Update Receipt Of Invoice Batch Line to Pending Status
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber", con)
                        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "PENDING"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Round Dollar values to 2 decimals
                        ProductTotal = Math.Round(ProductTotal, 2)
                        InvoiceFreight = Math.Round(InvoiceFreight, 2)
                        InvoiceSalesTax = Math.Round(InvoiceSalesTax, 2)
                        InvoiceTotal = Math.Round(InvoiceTotal, 2)
                        DiscountAmount = Math.Round(DiscountAmount, 2)

                        'Determine correct division and batch number
                        Select Case RowDivision
                            Case "ATL"
                                If CheckType = "STANDARD" Then
                                    NextBatchNumber = ATLBatchNumber
                                    TempDivision = "ATL"
                                Else
                                    NextBatchNumber = ATLACHBatchNumber
                                    TempDivision = "ATL"
                                End If
                            Case "CBS"
                                If CheckType = "STANDARD" Then
                                    NextBatchNumber = CBSBatchNumber
                                    TempDivision = "CBS"
                                Else
                                    NextBatchNumber = CBSACHBatchNumber
                                    TempDivision = "CBS"
                                End If
                            Case "CGO"
                                If CheckType = "STANDARD" Then
                                    NextBatchNumber = CGOBatchNumber
                                    TempDivision = "CGO"
                                Else
                                    NextBatchNumber = CGOACHBatchNumber
                                    TempDivision = "CGO"
                                End If
                            Case "CHT"
                                If CheckType = "STANDARD" Then
                                    NextBatchNumber = CHTBatchNumber
                                    TempDivision = "CHT"
                                Else
                                    NextBatchNumber = CHTACHBatchNumber
                                    TempDivision = "CHT"
                                End If
                            Case "DEN"
                                If CheckType = "STANDARD" Then
                                    NextBatchNumber = DENBatchNumber
                                    TempDivision = "DEN"
                                Else
                                    NextBatchNumber = DENACHBatchNumber
                                    TempDivision = "DEN"
                                End If
                            Case "HOU"
                                If CheckType = "STANDARD" Then
                                    NextBatchNumber = HOUBatchNumber
                                    TempDivision = "HOU"
                                Else
                                    NextBatchNumber = HOUACHBatchNumber
                                    TempDivision = "HOU"
                                End If
                            Case "LLH"
                                If CheckType = "STANDARD" Then
                                    NextBatchNumber = LLHBatchNumber
                                    TempDivision = "LLH"
                                Else
                                    NextBatchNumber = LLHACHBatchNumber
                                    TempDivision = "LLH"
                                End If
                            Case "SLC"
                                If CheckType = "STANDARD" Then
                                    NextBatchNumber = SLCBatchNumber
                                    TempDivision = "SLC"
                                Else
                                    NextBatchNumber = SLCACHBatchNumber
                                    TempDivision = "SLC"
                                End If
                            Case "TFF"
                                If CheckType = "STANDARD" And VendorClass = "CANADIAN" Then
                                    NextBatchNumber = TFFBatchNumberCanadian
                                    TempDivision = "TFF"
                                ElseIf CheckType = "STANDARD" And VendorClass = "AMERICAN" Then
                                    NextBatchNumber = TFFBatchNumberAmerican
                                    TempDivision = "TFF"
                                ElseIf CheckType <> "STANDARD" And VendorClass = "CANADIAN" Then
                                    NextBatchNumber = TFFACHBatchNumberCanadian
                                    TempDivision = "TFF"
                                ElseIf CheckType <> "STANDARD" And VendorClass = "AMERICAN" Then
                                    NextBatchNumber = TFFACHBatchNumberAmerican
                                    TempDivision = "TFF"
                                End If
                            Case "TFT"
                                If CheckType = "STANDARD" Then
                                    NextBatchNumber = TFTBatchNumber
                                    TempDivision = "TFT"
                                Else
                                    NextBatchNumber = TFTACHBatchNumber
                                    TempDivision = "TFT"
                                End If
                            Case "TWD"
                                If CheckType = "STANDARD" Then
                                    NextBatchNumber = TWDBatchNumber
                                    TempDivision = "TWD"
                                Else
                                    NextBatchNumber = TWDACHBatchNumber
                                    TempDivision = "TWD"
                                End If
                            Case "TWE"
                                If CheckType = "STANDARD" Then
                                    NextBatchNumber = TWEBatchNumber
                                    TempDivision = "TWE"
                                Else
                                    NextBatchNumber = TWEACHBatchNumber
                                    TempDivision = "TWE"
                                End If
                            Case "TOR"
                                If CheckType = "STANDARD" And VendorClass = "CANADIAN" Then
                                    NextBatchNumber = TORBatchNumberCanadian
                                    TempDivision = "TOR"
                                ElseIf CheckType = "STANDARD" And VendorClass = "AMERICAN" Then
                                    NextBatchNumber = TorBatchNumberAmerican
                                    TempDivision = "TOR"
                                ElseIf CheckType <> "STANDARD" And VendorClass = "CANADIAN" Then
                                    NextBatchNumber = TORACHBatchNumberCanadian
                                    TempDivision = "TOR"
                                ElseIf CheckType <> "STANDARD" And VendorClass = "AMERICAN" Then
                                    NextBatchNumber = TORACHBatchNumberAmerican
                                    TempDivision = "TOR"
                                End If
                            Case "ALB"
                                If CheckType = "STANDARD" And VendorClass = "CANADIAN" Then
                                    NextBatchNumber = ALBBatchNumberCanadian
                                    TempDivision = "ALB"
                                ElseIf CheckType = "STANDARD" And VendorClass = "AMERICAN" Then
                                    NextBatchNumber = ALBBatchNumberAmerican
                                    TempDivision = "ALB"
                                ElseIf CheckType <> "STANDARD" And VendorClass = "CANADIAN" Then
                                    NextBatchNumber = ALBACHBatchNumberCanadian
                                    TempDivision = "ALB"
                                ElseIf CheckType <> "STANDARD" And VendorClass = "AMERICAN" Then
                                    NextBatchNumber = ALBACHBatchNumberAmerican
                                    TempDivision = "ALB"
                                End If
                            Case "TFJ"
                                If CheckType = "STANDARD" Then
                                    NextBatchNumber = TFJBatchNumber
                                    TempDivision = "TFJ"
                                Else
                                    NextBatchNumber = TFJACHBatchNumber
                                    TempDivision = "TFJ"
                                End If
                        End Select

                        'Write Data to Voucher Database Table
                        cmd = New SqlCommand("Insert Into APVoucherTable(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, ReceiptDate, DueDate, DiscountDate, PaidDate, VendorID, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, DiscountAmount, Comment, PaymentTerms, VoucherStatus, PaymentAmount, DivisionID, CheckPositionNumber, CheckType, WhitePaper, Checked1099) Values (@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @DueDate, @DiscountDate, @PaidDate, @VendorID, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @DiscountAmount, @Comment, @PaymentTerms, @VoucherStatus, @PaymentAmount, @DivisionID, @CheckPositionNumber, @CheckType, @WhitePaper, @Checked1099)", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                            .Add("@PONumber", SqlDbType.VarChar).Value = PONumber
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@ReceiptDate", SqlDbType.VarChar).Value = ReceiptDate
                            .Add("@DueDate", SqlDbType.VarChar).Value = DueDate
                            .Add("@DiscountDate", SqlDbType.VarChar).Value = DiscountDate
                            .Add("@PaidDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                            .Add("@DiscountAmount", SqlDbType.VarChar).Value = DiscountAmount
                            .Add("@Comment", SqlDbType.VarChar).Value = Comment
                            .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
                            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "PENDING"
                            .Add("@PaymentAmount", SqlDbType.VarChar).Value = InvoiceTotal - DiscountAmount
                            .Add("@DivisionID", SqlDbType.VarChar).Value = TempDivision
                            .Add("@CheckPositionNumber", SqlDbType.VarChar).Value = 0
                            .Add("@CheckType", SqlDbType.VarChar).Value = CheckType
                            .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaper
                            .Add("@Checked1099", SqlDbType.VarChar).Value = Checked1099
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        TempDivision = ""
                        NextBatchNumber = 0
                    End If
                Next
                '***************************************************************************************************************
                'Routine to validate if negative check exists
                For Each row As DataGridViewRow In dgvPayables.Rows
                    Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")
                    Dim CurrentBatchNumber As Long = 0

                    If cell.Value = "SELECTED" Then
                        Dim VendorID As String = row.Cells("VendorIDColumn").Value
                        Dim VendorClass As String = row.Cells("VendorClassColumn").Value
                        Dim DivisionID As String = row.Cells("DivisionIDColumn").Value
                        Dim CheckType As String = row.Cells("CheckTypeColumn").Value
                        Dim VendorTotal As Double = 0

                        Select Case DivisionID
                            Case "ATL"
                                If CheckType = "STANDARD" Then
                                    CurrentBatchNumber = ATLBatchNumber
                                Else
                                    CurrentBatchNumber = ATLACHBatchNumber
                                End If
                            Case "CBS"
                                If CheckType = "STANDARD" Then
                                    CurrentBatchNumber = CBSBatchNumber
                                Else
                                    CurrentBatchNumber = CBSACHBatchNumber
                                End If
                            Case "CGO"
                                If CheckType = "STANDARD" Then
                                    CurrentBatchNumber = CGOBatchNumber
                                Else
                                    CurrentBatchNumber = CGOACHBatchNumber
                                End If
                            Case "CHT"
                                If CheckType = "STANDARD" Then
                                    CurrentBatchNumber = CHTBatchNumber
                                Else
                                    CurrentBatchNumber = CHTACHBatchNumber
                                End If
                            Case "DEN"
                                If CheckType = "STANDARD" Then
                                    CurrentBatchNumber = DENBatchNumber
                                Else
                                    CurrentBatchNumber = DENACHBatchNumber
                                End If
                            Case "HOU"
                                If CheckType = "STANDARD" Then
                                    CurrentBatchNumber = HOUBatchNumber
                                Else
                                    CurrentBatchNumber = HOUACHBatchNumber
                                End If
                            Case "SLC"
                                If CheckType = "STANDARD" Then
                                    CurrentBatchNumber = SLCBatchNumber
                                Else
                                    CurrentBatchNumber = SLCACHBatchNumber
                                End If
                            Case "TFF"
                                If VendorClass = "CANADIAN" And CheckType = "STANDARD" Then
                                    CurrentBatchNumber = TFFBatchNumberCanadian
                                ElseIf VendorClass = "AMERICAN" And CheckType = "STANDARD" Then
                                    CurrentBatchNumber = TFFBatchNumberAmerican
                                ElseIf VendorClass = "CANADIAN" And CheckType <> "STANDARD" Then
                                    CurrentBatchNumber = TFFACHBatchNumberCanadian
                                ElseIf VendorClass = "AMERICAN" And CheckType <> "STANDARD" Then
                                    CurrentBatchNumber = TFFACHBatchNumberAmerican
                                End If
                            Case "TFT"
                                If CheckType = "STANDARD" Then
                                    CurrentBatchNumber = TFTBatchNumber
                                Else
                                    CurrentBatchNumber = TFTACHBatchNumber
                                End If
                            Case "TWD"
                                If CheckType = "STANDARD" Then
                                    CurrentBatchNumber = TWDBatchNumber
                                Else
                                    CurrentBatchNumber = TWDACHBatchNumber
                                End If
                            Case "TWE"
                                If CheckType = "STANDARD" Then
                                    CurrentBatchNumber = TWEBatchNumber
                                Else
                                    CurrentBatchNumber = TWEACHBatchNumber
                                End If
                            Case "TOR"
                                If VendorClass = "CANADIAN" And CheckType = "STANDARD" Then
                                    CurrentBatchNumber = TORBatchNumberCanadian
                                ElseIf VendorClass = "AMERICAN" And CheckType = "STANDARD" Then
                                    CurrentBatchNumber = TorBatchNumberAmerican
                                ElseIf VendorClass = "CANADIAN" And CheckType <> "STANDARD" Then
                                    CurrentBatchNumber = TORACHBatchNumberCanadian
                                ElseIf VendorClass = "AMERICAN" And CheckType <> "STANDARD" Then
                                    CurrentBatchNumber = TORACHBatchNumberAmerican
                                End If
                            Case "ALB"
                                If VendorClass = "CANADIAN" And CheckType = "STANDARD" Then
                                    CurrentBatchNumber = ALBBatchNumberCanadian
                                ElseIf VendorClass = "AMERICAN" And CheckType = "STANDARD" Then
                                    CurrentBatchNumber = ALBBatchNumberAmerican
                                ElseIf VendorClass = "CANADIAN" And CheckType <> "STANDARD" Then
                                    CurrentBatchNumber = ALBACHBatchNumberCanadian
                                ElseIf VendorClass = "AMERICAN" And CheckType <> "STANDARD" Then
                                    CurrentBatchNumber = ALBACHBatchNumberAmerican
                                End If
                            Case "TFJ"
                                If CheckType = "STANDARD" Then
                                    CurrentBatchNumber = TFJBatchNumber
                                Else
                                    CurrentBatchNumber = TFJACHBatchNumber
                                End If
                        End Select

                        Dim DiscountTotal As Double = 0

                        'Check and prompt if negative check exists
                        Dim VendorTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND VendorID = @VendorID"
                        Dim VendorTotalCommand As New SqlCommand(VendorTotalStatement, con)
                        VendorTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = CurrentBatchNumber
                        VendorTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                        VendorTotalCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID

                        Dim DiscountTotalStatement As String = "SELECT SUM(DiscountAmount) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND VendorID = @VendorID"
                        Dim DiscountTotalCommand As New SqlCommand(DiscountTotalStatement, con)
                        DiscountTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = CurrentBatchNumber
                        DiscountTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID
                        DiscountTotalCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            VendorTotal = CDbl(VendorTotalCommand.ExecuteScalar)
                        Catch ex As Exception
                            VendorTotal = 0
                        End Try
                        Try
                            DiscountTotal = CDbl(DiscountTotalCommand.ExecuteScalar)
                        Catch ex As Exception
                            DiscountTotal = 0
                        End Try
                        con.Close()

                        VendorTotal = VendorTotal - DiscountTotal
                        VendorTotal = Math.Round(VendorTotal, 2)

                        If VendorTotal < 0 Then
                            MsgBox("You have selected invoices that will create a negative check - Invoices from this Vendor will be removed from the batch.", MsgBoxStyle.OkOnly)

                            For Each row1 As DataGridViewRow In dgvPayables.Rows
                                Dim cell1 As DataGridViewCheckBoxCell = row1.Cells("SelectForPayment")

                                If cell1.Value = "SELECTED" Then
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
                                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionID

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
                '*************************************************************************************************
                'For check batches only - no ACH batches
                'Sum Voucher totals and update each batch and delete the empty batches
                Dim Counter2 As Integer = 1

                For i As Integer = 1 To 18
                    'Determine correct division and batch number
                    Select Case Counter2
                        Case 1
                            NextBatchNumber = ATLBatchNumber
                            TempDivision = "ATL"
                        Case 2
                            NextBatchNumber = CBSBatchNumber
                            TempDivision = "CBS"
                        Case 3
                            NextBatchNumber = CGOBatchNumber
                            TempDivision = "CGO"
                        Case 4
                            NextBatchNumber = CHTBatchNumber
                            TempDivision = "CHT"
                        Case 5
                            NextBatchNumber = DENBatchNumber
                            TempDivision = "DEN"
                        Case 6
                            NextBatchNumber = HOUBatchNumber
                            TempDivision = "HOU"
                        Case 7
                            NextBatchNumber = SLCBatchNumber
                            TempDivision = "SLC"
                        Case 8
                            NextBatchNumber = TFFBatchNumberCanadian
                            TempDivision = "TFF"
                        Case 9
                            NextBatchNumber = TFTBatchNumber
                            TempDivision = "TFT"
                        Case 10
                            NextBatchNumber = TWDBatchNumber
                            TempDivision = "TWD"
                        Case 11
                            NextBatchNumber = TWEBatchNumber
                            TempDivision = "TWE"
                        Case 12
                            NextBatchNumber = TORBatchNumberCanadian
                            TempDivision = "TOR"
                        Case 13
                            NextBatchNumber = TFFBatchNumberAmerican
                            TempDivision = "TFF"
                        Case 14
                            NextBatchNumber = TorBatchNumberAmerican
                            TempDivision = "TOR"
                        Case 15
                            NextBatchNumber = ALBBatchNumberAmerican
                            TempDivision = "ALB"
                        Case 16
                            NextBatchNumber = ALBBatchNumberCanadian
                            TempDivision = "ALB"
                        Case 17
                            NextBatchNumber = TFJBatchNumber
                            TempDivision = "TFJ"
                        Case 18
                            NextBatchNumber = LLHBatchNumber
                            TempDivision = "LLH"
                    End Select
                    '**************************************************************************************************
                    'Load Voucher Total into Batch Total
                    Dim BatchTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
                    Dim BatchTotalCommand As New SqlCommand(BatchTotalStatement, con)
                    BatchTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                    BatchTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = TempDivision

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        BatchTotal = CDbl(BatchTotalCommand.ExecuteScalar)
                    Catch ex As Exception
                        BatchTotal = 0
                    End Try
                    con.Close()

                    'Round Batch Total
                    BatchTotal = Math.Round(BatchTotal, 2)

                    'Check to see if lines in Batch exist
                    Dim CountLinesInBatch As Integer = 0

                    Dim CountLinesInBatchStatement As String = "SELECT COUNT(VoucherNumber) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
                    Dim CountLinesInBatchCommand As New SqlCommand(CountLinesInBatchStatement, con)
                    CountLinesInBatchCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                    CountLinesInBatchCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = TempDivision

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CountLinesInBatch = CInt(CountLinesInBatchCommand.ExecuteScalar)
                    Catch ex As Exception
                        CountLinesInBatch = 0
                    End Try
                    con.Close()

                    If CountLinesInBatch = 0 Then
                        'Delete data from Batch Header Database Table
                        cmd = New SqlCommand("DELETE FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = TempDivision

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Else
                        'Write Data to Batch Header Database Table
                        cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                        cmd.Parameters.Add("@BatchAmount", SqlDbType.VarChar).Value = BatchTotal
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = TempDivision

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If

                    Counter2 = Counter2 + 1
                Next i
                '*******************************************************************************************************
                'Change payable status to pending so they cannot be selected again
                Dim SelectedDivisionID As String = ""
                Dim SelectedVoucherNumber As Integer = 0
   
                For Each SelectedRow As DataGridViewRow In dgvPayables.Rows
                    Dim SelectedCell As DataGridViewCheckBoxCell = SelectedRow.Cells("SelectForPayment")

                    If SelectedCell.Value = "SELECTED" Then
                        SelectedVoucherNumber = SelectedRow.Cells("VoucherNumberColumn").Value
                        SelectedDivisionID = SelectedRow.Cells("DivisionIDColumn").Value

                        'Update payable status
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)
                        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = SelectedVoucherNumber
                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = SelectedDivisionID
                        cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "PENDING"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        SelectedVoucherNumber = 0
                        SelectedDivisionID = ""
                    End If
                Next
                '*******************************************************************************************************
                'Load Datagrid after designation
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    cboVendorClass.Enabled = True
                    cboVendorClass.Text = "Canadian"
                    ShowPostedVouchersCanadian()
                ElseIf cboDivisionID.Text = "ADM" Then
                    cboVendorClass.SelectedIndex = -1
                    cboVendorClass.Enabled = False

                    ShowPostedVouchersADM()
                Else
                    cboVendorClass.SelectedIndex = -1
                    cboVendorClass.Enabled = False

                    ShowPostedVouchers()
                End If

                LoadDivisionTotals()
                LoadCompanyTotals()

                'Clear temp field
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET TempSelected = @TempSelected", con)
                cmd.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = ""

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Payables have been designated for payment.", MsgBoxStyle.OkOnly)

                '**********************************************************************************************






            Else ' Process for a single division





                'Check to see if any ACH transactions

                '*********************************************************************
                'Save selection into temp field in voucher table
                Dim TempVoucherNumber As Integer = 0
                Dim TempDivisionID As String = ""

                For Each TempRow As DataGridViewRow In dgvPayables.Rows
                    Dim TempCell As DataGridViewCheckBoxCell = TempRow.Cells("SelectForPayment")

                    If TempCell.Value = "SELECTED" Then
                        Try
                            TempVoucherNumber = TempRow.Cells("VoucherNumberColumn").Value
                        Catch ex As Exception
                            TempVoucherNumber = 0
                        End Try
                        Try
                            TempDivisionID = TempRow.Cells("DivisionIDColumn").Value
                        Catch ex As Exception
                            TempDivisionID = ""
                        End Try

                        'Update temp field
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET TempSelected = @TempSelected WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = TempVoucherNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = TempDivisionID
                            .Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                Next
                '**************************************************************************************************
                'Get new Batch Number
                Dim MaxBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                Dim MaxBatchCommand As New SqlCommand(MaxBatchStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastBatchNumber = CLng(MaxBatchCommand.ExecuteScalar)
                Catch ex As Exception
                    LastBatchNumber = 997000000
                End Try
                con.Close()

                NextBatchNumber = LastBatchNumber + 1
                GlobalBatchNumber = NextBatchNumber
                DeleteSingleBatch = NextBatchNumber

                'Create new batch
                cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                    .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                    .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@Locked", SqlDbType.VarChar).Value = ""
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***********************************************************************************************************************
                'Check if ACH Invoices selected

                If cboDivisionID.Text = "TOR" Then
                    'Create TOR Batch for white paper, if necessary
                    Dim TORACHBatchCountAmericanStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus AND VendorClass = @VendorClass"
                    Dim TORACHBatchCountAmericanCommand As New SqlCommand(TORACHBatchCountAmericanStatement, con)
                    TORACHBatchCountAmericanCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                    TORACHBatchCountAmericanCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                    TORACHBatchCountAmericanCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                    TORACHBatchCountAmericanCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                    TORACHBatchCountAmericanCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "American"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ACHBatchCount = CInt(TORACHBatchCountAmericanCommand.ExecuteScalar)
                    Catch ex As Exception
                        ACHBatchCount = 0
                    End Try
                    con.Close()

                    If ACHBatchCount > 0 Then
                        'Get new Batch Number
                        Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                        Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                        Catch ex As Exception
                            OldBatchNumber = 997000000
                        End Try
                        con.Close()

                        NewBatchNumber = OldBatchNumber + 1
                        TORACHBatchNumberAmerican = NewBatchNumber

                        'Create new batch
                        cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = TORACHBatchNumberAmerican
                            .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@Locked", SqlDbType.VarChar).Value = ""
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        NewBatchNumber = 0
                        OldBatchNumber = 0
                    Else
                        TORACHBatchNumberAmerican = 0
                    End If

                    'Clear variables used
                    ACHBatchCount = 0

                    'Create TOR Batch for white paper, if necessary
                    Dim TORACHBatchCountCanadianStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus AND VendorClass = @VendorClass"
                    Dim TORACHBatchCountCanadianCommand As New SqlCommand(TORACHBatchCountCanadianStatement, con)
                    TORACHBatchCountCanadianCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                    TORACHBatchCountCanadianCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                    TORACHBatchCountCanadianCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                    TORACHBatchCountCanadianCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                    TORACHBatchCountCanadianCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "Canadian"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ACHBatchCount = CInt(TORACHBatchCountCanadianCommand.ExecuteScalar)
                    Catch ex As Exception
                        ACHBatchCount = 0
                    End Try
                    con.Close()

                    If ACHBatchCount > 0 Then
                        'Get new Batch Number
                        Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                        Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                        Catch ex As Exception
                            OldBatchNumber = 997000000
                        End Try
                        con.Close()

                        NewBatchNumber = OldBatchNumber + 1
                        TORACHBatchNumberCanadian = NewBatchNumber

                        'Create new batch
                        cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = TORACHBatchNumberCanadian
                            .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@Locked", SqlDbType.VarChar).Value = ""
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        NewBatchNumber = 0
                        OldBatchNumber = 0
                    Else
                        TORACHBatchNumberCanadian = 0
                    End If

                    'Clear variables used
                    ACHBatchCount = 0

                ElseIf cboDivisionID.Text = "TFF" Then
                    'Create TFF Batch for white paper, if necessary
                    Dim TFFACHBatchCountAmericanStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus AND VendorClass = @VendorClass"
                    Dim TFFACHBatchCountAmericanCommand As New SqlCommand(TFFACHBatchCountAmericanStatement, con)
                    TFFACHBatchCountAmericanCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                    TFFACHBatchCountAmericanCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                    TFFACHBatchCountAmericanCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                    TFFACHBatchCountAmericanCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                    TFFACHBatchCountAmericanCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "American"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ACHBatchCount = CInt(TFFACHBatchCountAmericanCommand.ExecuteScalar)
                    Catch ex As Exception
                        ACHBatchCount = 0
                    End Try
                    con.Close()

                    If ACHBatchCount > 0 Then
                        'Get new Batch Number
                        Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                        Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                        Catch ex As Exception
                            OldBatchNumber = 997000000
                        End Try
                        con.Close()

                        NewBatchNumber = OldBatchNumber + 1
                        TFFACHBatchNumberAmerican = NewBatchNumber

                        'Create new batch
                        cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = TFFACHBatchNumberAmerican
                            .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@Locked", SqlDbType.VarChar).Value = ""
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        NewBatchNumber = 0
                        OldBatchNumber = 0
                    Else
                        TFFACHBatchNumberAmerican = 0
                    End If

                    'Clear variables used
                    ACHBatchCount = 0

                    'Create TFF Batch for white paper, if necessary
                    Dim TFFACHBatchCountCanadianStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus AND VendorClass = @VendorClass"
                    Dim TFFACHBatchCountCanadianCommand As New SqlCommand(TFFACHBatchCountCanadianStatement, con)
                    TFFACHBatchCountCanadianCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                    TFFACHBatchCountCanadianCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                    TFFACHBatchCountCanadianCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                    TFFACHBatchCountCanadianCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                    TFFACHBatchCountCanadianCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "Canadian"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ACHBatchCount = CInt(TFFACHBatchCountCanadianCommand.ExecuteScalar)
                    Catch ex As Exception
                        ACHBatchCount = 0
                    End Try
                    con.Close()

                    If ACHBatchCount > 0 Then
                        'Get new Batch Number
                        Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                        Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                        Catch ex As Exception
                            OldBatchNumber = 997000000
                        End Try
                        con.Close()

                        NewBatchNumber = OldBatchNumber + 1
                        TFFACHBatchNumberCanadian = NewBatchNumber

                        'Create new batch
                        cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = TFFACHBatchNumberCanadian
                            .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@Locked", SqlDbType.VarChar).Value = ""
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        NewBatchNumber = 0
                        OldBatchNumber = 0
                    Else
                        TFFACHBatchNumberCanadian = 0
                    End If

                    'Clear variables used
                    ACHBatchCount = 0
                ElseIf cboDivisionID.Text = "ALB" Then
                    'Create ALB Batch for ACH
                    Dim ALBACHBatchCountAmericanStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus AND VendorClass = @VendorClass"
                    Dim ALBACHBatchCountAmericanCommand As New SqlCommand(ALBACHBatchCountAmericanStatement, con)
                    ALBACHBatchCountAmericanCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                    ALBACHBatchCountAmericanCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                    ALBACHBatchCountAmericanCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                    ALBACHBatchCountAmericanCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                    ALBACHBatchCountAmericanCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "American"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ACHBatchCount = CInt(ALBACHBatchCountAmericanCommand.ExecuteScalar)
                    Catch ex As Exception
                        ACHBatchCount = 0
                    End Try
                    con.Close()

                    If ACHBatchCount > 0 Then
                        'Get new Batch Number
                        Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                        Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                        Catch ex As Exception
                            OldBatchNumber = 997000000
                        End Try
                        con.Close()

                        NewBatchNumber = OldBatchNumber + 1
                        ALBACHBatchNumberAmerican = NewBatchNumber

                        'Create new batch
                        cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = ALBACHBatchNumberAmerican
                            .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@Locked", SqlDbType.VarChar).Value = ""
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        NewBatchNumber = 0
                        OldBatchNumber = 0
                    Else
                        ALBACHBatchNumberAmerican = 0
                    End If

                    'Clear variables used
                    ACHBatchCount = 0

                    'Create ALB Batch for white paper, if necessary
                    Dim ALBACHBatchCountCanadianStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus AND VendorClass = @VendorClass"
                    Dim ALBACHBatchCountCanadianCommand As New SqlCommand(ALBACHBatchCountCanadianStatement, con)
                    ALBACHBatchCountCanadianCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                    ALBACHBatchCountCanadianCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                    ALBACHBatchCountCanadianCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                    ALBACHBatchCountCanadianCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"
                    ALBACHBatchCountCanadianCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "Canadian"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ACHBatchCount = CInt(ALBACHBatchCountCanadianCommand.ExecuteScalar)
                    Catch ex As Exception
                        ACHBatchCount = 0
                    End Try
                    con.Close()

                    If ACHBatchCount > 0 Then
                        'Get new Batch Number
                        Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                        Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                        Catch ex As Exception
                            OldBatchNumber = 997000000
                        End Try
                        con.Close()

                        NewBatchNumber = OldBatchNumber + 1
                        ALBACHBatchNumberCanadian = NewBatchNumber

                        'Create new batch
                        cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = ALBACHBatchNumberCanadian
                            .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@Locked", SqlDbType.VarChar).Value = ""
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        NewBatchNumber = 0
                        OldBatchNumber = 0
                    Else
                        ALBACHBatchNumberCanadian = 0
                    End If

                    'Clear variables used
                    ACHBatchCount = 0
                Else
                    'Create CHT Batch for white paper, if necessary
                    Dim DivisionACHBatchCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND CheckType <> @CheckType AND TempSelected = @TempSelected AND VoucherStatus = @VoucherStatus"
                    Dim DivisionACHBatchCountCommand As New SqlCommand(DivisionACHBatchCountStatement, con)
                    DivisionACHBatchCountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    DivisionACHBatchCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = "STANDARD"
                    DivisionACHBatchCountCommand.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = "YES"
                    DivisionACHBatchCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        ACHBatchCount = CInt(DivisionACHBatchCountCommand.ExecuteScalar)
                    Catch ex As Exception
                        ACHBatchCount = 0
                    End Try
                    con.Close()

                    If ACHBatchCount > 0 Then
                        'Get new Batch Number
                        Dim NewBatchStatement As String = "SELECT MAX(BatchNumber) FROM APProcessPaymentBatch"
                        Dim NewBatchCommand As New SqlCommand(NewBatchStatement, con)

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            OldBatchNumber = CLng(NewBatchCommand.ExecuteScalar)
                        Catch ex As Exception
                            OldBatchNumber = 997000000
                        End Try
                        con.Close()

                        NewBatchNumber = OldBatchNumber + 1
                        DivisionACHBatchNumber = NewBatchNumber

                        'Create new batch
                        cmd = New SqlCommand("INSERT INTO APProcessPaymentBatch (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, Locked, UserID, CheckType) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @Locked, @UserID, @CheckType)", con)

                        With cmd.Parameters
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = DivisionACHBatchNumber
                            .Add("@BatchDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                            .Add("@BatchDescription", SqlDbType.VarChar).Value = "DESIGNATE PAYABLES - ACH"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                            .Add("@Locked", SqlDbType.VarChar).Value = ""
                            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                            .Add("@CheckType", SqlDbType.VarChar).Value = "ACH"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        NewBatchNumber = 0
                        OldBatchNumber = 0
                    Else
                        DivisionACHBatchNumber = 0
                    End If

                    'Clear variables used
                    ACHBatchCount = 0
                End If
                '***********************************************************************************************************************
                'Retrieve line data from Receipt of Invoice and write to AP Voucher Table
                For Each row As DataGridViewRow In dgvPayables.Rows
                    Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")

                    If cell.Value = "SELECTED" Then
                        Dim VoucherNumber, PONumber As Integer
                        Dim InvoiceNumber, InvoiceDate, ReceiptDate, DueDate, DiscountDate, VendorID, Comment, PaymentTerms As String
                        Dim ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, DiscountAmount As Double
                        Dim CheckType As String = ""
                        Dim WhitePaper As String = ""
                        Dim Checked1099 As String = "NO"

                        Dim DivisionVendorClass As String = ""

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
                            CheckType = ""
                        End Try
                        Try
                            WhitePaper = row.Cells("WhitePaperColumn").Value
                        Catch ex As Exception
                            WhitePaper = "NO"
                        End Try
                        Try
                            DivisionVendorClass = row.Cells("VendorClassColumn").Value
                        Catch ex As Exception
                            DivisionVendorClass = cboVendorClass.Text
                        End Try
                        Try
                            Checked1099 = row.Cells("Checked1099Column").Value
                        Catch ex As Exception
                            Checked1099 = "NO"
                        End Try

                        If InvoiceTotal < 0 Then
                            PaymentTerms = "N30"
                            DiscountAmount = 0
                        End If

                        'Update Receipt Of Invoice Batch Line to Pending Status
                        cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET VoucherStatus = @VoucherStatus WHERE VoucherNumber = @VoucherNumber", con)
                        cmd.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                        cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "PENDING"

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'Round Dollar values to 2 decimals
                        ProductTotal = Math.Round(ProductTotal, 2)
                        InvoiceFreight = Math.Round(InvoiceFreight, 2)
                        InvoiceSalesTax = Math.Round(InvoiceSalesTax, 2)
                        InvoiceTotal = Math.Round(InvoiceTotal, 2)
                        DiscountAmount = Math.Round(DiscountAmount, 2)

                        'Choose the correct batch number
                        If CheckType = "STANDARD" Then
                            NextBatchNumber = GlobalBatchNumber
                        Else
                            If cboDivisionID.Text = "TOR" Then
                                If DivisionVendorClass = "AMERICAN" Then
                                    NextBatchNumber = TORACHBatchNumberAmerican
                                Else
                                    NextBatchNumber = TORACHBatchNumberCanadian
                                End If
                            ElseIf cboDivisionID.Text = "TFF" Then
                                If DivisionVendorClass = "AMERICAN" Then
                                    NextBatchNumber = TFFACHBatchNumberAmerican
                                Else
                                    NextBatchNumber = TFFACHBatchNumberCanadian
                                End If
                            ElseIf cboDivisionID.Text = "ALB" Then
                                If DivisionVendorClass = "AMERICAN" Then
                                    NextBatchNumber = ALBACHBatchNumberAmerican
                                Else
                                    NextBatchNumber = ALBACHBatchNumberCanadian
                                End If
                            Else
                                NextBatchNumber = DivisionACHBatchNumber
                            End If
                        End If

                        'Write Data to Voucher Database Table
                        cmd = New SqlCommand("Insert Into APVoucherTable(VoucherNumber, BatchNumber, PONumber, InvoiceNumber, InvoiceDate, ReceiptDate, DueDate, DiscountDate, PaidDate, VendorID, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, DiscountAmount, Comment, PaymentTerms, VoucherStatus, PaymentAmount, DivisionID, CheckPositionNumber, CheckType, WhitePaper, Checked1099) Values (@VoucherNumber, @BatchNumber, @PONumber, @InvoiceNumber, @InvoiceDate, @ReceiptDate, @DueDate, @DiscountDate, @PaidDate, @VendorID, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @DiscountAmount, @Comment, @PaymentTerms, @VoucherStatus, @PaymentAmount, @DivisionID, @CheckPositionNumber, @CheckType, @WhitePaper, @Checked1099)", con)

                        With cmd.Parameters
                            .Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                            .Add("@PONumber", SqlDbType.VarChar).Value = PONumber
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@ReceiptDate", SqlDbType.VarChar).Value = ReceiptDate
                            .Add("@DueDate", SqlDbType.VarChar).Value = DueDate
                            .Add("@DiscountDate", SqlDbType.VarChar).Value = DiscountDate
                            .Add("@PaidDate", SqlDbType.VarChar).Value = TodaysDate
                            .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                            .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                            .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                            .Add("@DiscountAmount", SqlDbType.VarChar).Value = DiscountAmount
                            .Add("@Comment", SqlDbType.VarChar).Value = Comment
                            .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
                            .Add("@VoucherStatus", SqlDbType.VarChar).Value = "PENDING"
                            .Add("@PaymentAmount", SqlDbType.VarChar).Value = InvoiceTotal - DiscountAmount
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@CheckPositionNumber", SqlDbType.VarChar).Value = 0
                            .Add("@CheckType", SqlDbType.VarChar).Value = CheckType
                            .Add("@WhitePaper", SqlDbType.VarChar).Value = WhitePaper
                            .Add("@Checked1099", SqlDbType.VarChar).Value = Checked1099
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                Next

                'Routine to validate if negative check exists
                For Each row As DataGridViewRow In dgvPayables.Rows
                    Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")

                    If cell.Value = "SELECTED" Then
                        Dim VendorID As String = row.Cells("VendorIDColumn").Value
                        Dim VendorTotal As Double = 0
                        Dim DiscountTotal As Double = 0

                        'Check and prompt if negative check exists
                        Dim VendorTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND VendorID = @VendorID"
                        Dim VendorTotalCommand As New SqlCommand(VendorTotalStatement, con)
                        VendorTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                        VendorTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        VendorTotalCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID

                        Dim DiscountTotalStatement As String = "SELECT SUM(DiscountAmount) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND VendorID = @VendorID"
                        Dim DiscountTotalCommand As New SqlCommand(DiscountTotalStatement, con)
                        DiscountTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                        DiscountTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        DiscountTotalCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = VendorID

                        If con.State = ConnectionState.Closed Then con.Open()
                        Try
                            VendorTotal = CDbl(VendorTotalCommand.ExecuteScalar)
                        Catch ex As Exception
                            VendorTotal = 0
                        End Try
                        Try
                            DiscountTotal = CDbl(DiscountTotalCommand.ExecuteScalar)
                        Catch ex As Exception
                            DiscountTotal = 0
                        End Try
                        con.Close()

                        VendorTotal = VendorTotal - DiscountTotal
                        VendorTotal = Math.Round(VendorTotal, 2)

                        If VendorTotal < 0 Then
                            MsgBox("You have selected invoices that will create a negative check - Invoices from this Vendor will be removed from the batch.", MsgBoxStyle.OkOnly)

                            For Each row1 As DataGridViewRow In dgvPayables.Rows
                                Dim cell1 As DataGridViewCheckBoxCell = row1.Cells("SelectForPayment")

                                If cell1.Value = "SELECTED" Then
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
                                        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

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
                Dim BatchTotalStatement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
                Dim BatchTotalCommand As New SqlCommand(BatchTotalStatement, con)
                BatchTotalCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = DeleteSingleBatch
                BatchTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    BatchTotal = CDbl(BatchTotalCommand.ExecuteScalar)
                Catch ex As Exception
                    BatchTotal = 0
                End Try
                con.Close()

                'Round Batch Total
                BatchTotal = Math.Round(BatchTotal, 2)

                'Check to see if lines in Batch exist
                Dim CountLinesInBatch As Integer = 0

                Dim CountLinesInBatchStatement As String = "SELECT COUNT(VoucherNumber) FROM APVoucherTable WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID"
                Dim CountLinesInBatchCommand As New SqlCommand(CountLinesInBatchStatement, con)
                CountLinesInBatchCommand.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = DeleteSingleBatch
                CountLinesInBatchCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CountLinesInBatch = CInt(CountLinesInBatchCommand.ExecuteScalar)
                Catch ex As Exception
                    CountLinesInBatch = 0
                End Try
                con.Close()

                If CountLinesInBatch = 0 Then
                    'Delete data from Batch Header Database Table
                    cmd = New SqlCommand("DELETE FROM APProcessPaymentBatch WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = DeleteSingleBatch
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Else
                    'Write Data to Batch Header Database Table
                    cmd = New SqlCommand("UPDATE APProcessPaymentBatch SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
                    cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = DeleteSingleBatch
                    cmd.Parameters.Add("@BatchAmount", SqlDbType.VarChar).Value = BatchTotal
                    cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If

                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    cboVendorClass.Enabled = True
                    cboVendorClass.Text = "Canadian"
                    ShowPostedVouchersCanadian()
                Else
                    cboVendorClass.SelectedIndex = -1
                    cboVendorClass.Enabled = False

                    ShowPostedVouchers()
                End If


                LoadDivisionTotals()
                LoadCompanyTotals()

                'Clear temp field
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET TempSelected = @TempSelected", con)
                cmd.Parameters.Add("@TempSelected", SqlDbType.VarChar).Value = ""

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Payables have been designated for payment.", MsgBoxStyle.OkOnly)
                cmdSelectLines.Focus()
            End If
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintOpenPayables As New PrintOpenPayables
            Dim Result = NewPrintOpenPayables.ShowDialog()
        End Using
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        For Each row As DataGridViewRow In dgvPayables.Rows
            Dim cell As DataGridViewCheckBoxCell = row.Cells("SelectForPayment")
            cell.Value = "UNSELECTED"
        Next

        ClearVariables()
        ClearData()

        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            cboVendorClass.Enabled = True
            cboVendorClass.Text = "Canadian"
            ShowPostedVouchersCanadian()
        ElseIf cboDivisionID.Text = "ADM" Then
            cboVendorClass.SelectedIndex = -1
            cboVendorClass.Enabled = False

            ShowPostedVouchersADM()
        Else
            cboVendorClass.SelectedIndex = -1
            cboVendorClass.Enabled = False

            ShowPostedVouchers()
        End If

        'Loads totals for the whole company
        LoadDivisionTotals()
        LoadCompanyTotals()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.dgvPayables.DataSource = Nothing

        If EmployeeCompanyCode = "ADM" Then
            Try
                'Update to unselected
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid", con)

                With cmd.Parameters
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
        Else
            Try
                'Update to unselected
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid WHERE DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
        End If

        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.dgvPayables.DataSource = Nothing

        If EmployeeCompanyCode = "ADM" Then
            Try
                'Update to unselected
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid", con)

                With cmd.Parameters
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
        Else
            Try
                'Update to unselected
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid WHERE DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
        End If

        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvPayables_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPayables.CellContentClick
        dgvPayables.Focus()
    End Sub

    Private Sub cmdPostOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostOff.Click


















    End Sub

    Private Sub dgvPayables_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPayables.CurrentCellDirtyStateChanged
        If dgvPayables.IsCurrentCellDirty Then
            dgvPayables.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvPayables_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPayables.CellValueChanged
        Dim RowVoucherNumber As Integer = 0
        Dim RowDivisionID As String = ""

        If Me.dgvPayables.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPayables.CurrentCell.RowIndex

            'Update to get rid of Nulls
            cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET OnHold = @OnHold WHERE OnHold IS NULL", con)

            With cmd.Parameters
                .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Update to denote selected status in database (YES/NO)
            If Me.dgvPayables.Rows(RowIndex).Cells("SelectForPayment").Value = "SELECTED" Then
                Try
                    RowVoucherNumber = Me.dgvPayables.Rows(RowIndex).Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    RowVoucherNumber = 0
                End Try
                Try
                    RowDivisionID = Me.dgvPayables.Rows(RowIndex).Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivisionID = ""
                End Try

                'Update to selected
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = RowVoucherNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "YES"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else
                Try
                    RowVoucherNumber = Me.dgvPayables.Rows(RowIndex).Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    RowVoucherNumber = 0
                End Try
                Try
                    RowDivisionID = Me.dgvPayables.Rows(RowIndex).Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivisionID = ""
                End Try

                'Update to selected
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET SelectedInDatagrid = @SelectedInDatagrid WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = RowVoucherNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                    .Add("@SelectedInDatagrid", SqlDbType.VarChar).Value = "NO"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If

            If Me.dgvPayables.Rows(RowIndex).Cells("OnHoldColumn").Value = "YES" Then
                Try
                    RowVoucherNumber = Me.dgvPayables.Rows(RowIndex).Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    RowVoucherNumber = 0
                End Try
                Try
                    RowDivisionID = Me.dgvPayables.Rows(RowIndex).Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivisionID = ""
                End Try

                'Update Voucher Table
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET OnHold = @OnHold WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@OnHold", SqlDbType.VarChar).Value = "YES"
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = RowVoucherNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                Me.dgvPayables.Rows(RowIndex).Cells("SelectForPayment").Value = "UNSELECTED"
            Else
                Try
                    RowVoucherNumber = Me.dgvPayables.Rows(RowIndex).Cells("VoucherNumberColumn").Value
                Catch ex As Exception
                    RowVoucherNumber = 0
                End Try
                Try
                    RowDivisionID = Me.dgvPayables.Rows(RowIndex).Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    RowDivisionID = ""
                End Try

                'Update Voucher Table
                cmd = New SqlCommand("UPDATE ReceiptOfInvoiceBatchLine SET OnHold = @OnHold WHERE VoucherNumber = @VoucherNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@OnHold", SqlDbType.VarChar).Value = "NO"
                    .Add("@VoucherNumber", SqlDbType.VarChar).Value = RowVoucherNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivisionID
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Else
            'Skip Update
        End If

            FormatWhitePaperChecks()
    End Sub

    Private Sub dgvPayables_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPayables.ColumnHeaderMouseClick
        FormatWhitePaperChecks()

        If cboDivisionID.Text = "ADM" Then
            FormatADM()
        End If
    End Sub

    Private Sub dgvPayables_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPayables.CellDoubleClick
        If Me.dgvPayables.RowCount <> 0 Then
            Dim RowIndex As Integer = Me.dgvPayables.CurrentCell.RowIndex

            Dim RowPONumber As Integer = 0
            Dim RowDivision As String = ""

            RowPONumber = Me.dgvPayables.Rows(RowIndex).Cells("PONumberColumn").Value
            RowDivision = Me.dgvPayables.Rows(RowIndex).Cells("DivisionIDColumn").Value

            GlobalPONumber = RowPONumber
            GlobalDivisionCode = RowDivision
            '******************************************************************************
            If RowPONumber = 0 Then
                MsgBox("There is no PO associated with this payable.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '******************************************************************************
            If RowPONumber < 100000 Then
                'It is a steel PO 
                GlobalSteelPONumber = RowPONumber
                GlobalDivisionCode = "TWD"

                Using NewPrintSteelPO As New PrintSteelPurchaseOrder
                    Dim Result = NewPrintSteelPO.ShowDialog
                End Using
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
                    Using NewPrintPurchaseOrderRemote As New PrintPurchaseOrderRemote
                        Dim Result = NewPrintPurchaseOrderRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintPurchaseOrder As New PrintPurchaseOrder
                        Dim Result = NewPrintPurchaseOrder.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub
End Class