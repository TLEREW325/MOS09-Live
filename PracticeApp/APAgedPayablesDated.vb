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
Public Class APAgedPayablesDated
    Inherits System.Windows.Forms.Form

    Dim PaymentDate, AgedDate As Date
    Dim VoucherAmountOpen, TotalOpenAmount As Double
    Dim ClassMode As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub APAgedPayablesDated_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        LoadVendorClass()
        ShowData()
    End Sub

    Public Sub ShowData()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM APAgingQueryDatedStep1 WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APAgingQueryDatedStep1")
        dgvAgedPayablesStep1.DataSource = ds.Tables("APAgingQueryDatedStep1")
        con.Close()
    End Sub

    Public Sub ShowBlankData()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM APAgingQueryDatedStep1 WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ZZZ"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APAgingQueryDatedStep1")
        dgvAgedPayablesStep1.DataSource = ds.Tables("APAgingQueryDatedStep1")
        con.Close()
    End Sub

    Public Sub ShowDataByInvoiceDate()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM APAgingQueryDatedStep1 WHERE DivisionID = @DivisionID AND InvoiceDate <= @SelectDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = dtpSelectDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APAgingQueryDatedStep1")
        dgvAgedPayablesStep1.DataSource = ds.Tables("APAgingQueryDatedStep1")
        con.Close()
    End Sub

    Public Sub ShowDataByPostDate()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM APAgingQueryDatedStep1 WHERE DivisionID = @DivisionID AND PostingDate <= @SelectDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = dtpSelectDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APAgingQueryDatedStep1")
        dgvAgedPayablesStep1.DataSource = ds.Tables("APAgingQueryDatedStep1")
        con.Close()
    End Sub

    Public Sub ShowTempTable()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM APAgingTempDate WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "APAgingTempDate")
        dgvAPAgingTempDated.DataSource = ds1.Tables("APAgingTempDate")
        con.Close()
    End Sub

    Public Sub ShowBlankTempTable()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM APAgingTempDate WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ZZZ"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "APAgingTempDate")
        dgvAPAgingTempDated.DataSource = ds1.Tables("APAgingTempDate")
        con.Close()
    End Sub

    Public Sub ShowAPAgingDated()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM APAgingCategoryDated WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "APAgingCategoryDated")
        dgvAPAgingCategoryDated.DataSource = ds2.Tables("APAgingCategoryDated")
        con.Close()
    End Sub

    Public Sub ShowAPAgingDatedByVendorClass()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM APAgingCategoryDated WHERE DivisionID = @DivisionID AND VendorClass = @VendorClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "APAgingCategoryDated")
        dgvAPAgingCategoryDated.DataSource = ds2.Tables("APAgingCategoryDated")
        con.Close()
    End Sub

    Public Sub ShowBlankAPAgingDated()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM APAgingCategoryDated WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ZZZ"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "APAgingCategoryDated")
        dgvAPAgingCategoryDated.DataSource = ds2.Tables("APAgingCategoryDated")
        con.Close()
    End Sub

    Public Sub LoadVendorClass()
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            ClassMode = "CANADIAN"
        Else
            ClassMode = "STANDARD"
        End If
        'Load vendor class for specific division
        cmd = New SqlCommand("SELECT VendClassID FROM VendorClass WHERE ClassMode = @ClassMode", con)
        cmd.Parameters.Add("@ClassMode", SqlDbType.VarChar).Value = ClassMode
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "VendorClass")
        cboVendorClass.DataSource = ds3.Tables("VendorClass")
        con.Close()
        cboVendorClass.SelectedIndex = -1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        'Filter Existing Invoice Table with Payments

        'Clear Temp Table before writing
        cmd = New SqlCommand("DELETE FROM APAgingTempDate WHERE DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        If rdoAgeByInvoice.Checked = True Then
            ShowDataByInvoiceDate()
        Else
            ShowDataByPostDate()
        End If

        'Extract Data one record at a time, and write to a new temp table
        For Each row As DataGridViewRow In dgvAgedPayablesStep1.Rows
            Dim VoucherNumber As Integer = row.Cells("VoucherNumberColumn").Value
            Dim PONumber As Integer = row.Cells("PONumberColumn").Value
            Dim InvoiceNumber As String = row.Cells("InvoiceNumberColumn").Value
            Dim InvoiceDate As Date = row.Cells("InvoiceDateColumn").Value
            Dim VendorID As String = row.Cells("VendorIDColumn").Value
            Dim ProductTotal As Double = row.Cells("ProductTotalColumn").Value
            Dim InvoiceFreight As Double = row.Cells("InvoiceFreightColumn").Value
            Dim InvoiceSalesTax As Double = row.Cells("InvoiceSalesTaxColumn").Value
            Dim InvoiceTotal As Double = row.Cells("InvoiceTotalColumn").Value
            Dim PaymentTerms As String = row.Cells("PaymentTermsColumn").Value
            Dim DueDate As Date = row.Cells("DueDateColumn").Value
            Dim PaidDate As Date = row.Cells("PaidDateColumn").Value
            Dim PaymentAmount As Double = row.Cells("PaymentAmountColumn").Value
            Dim DiscountDate As Date = row.Cells("DiscountDateColumn").Value
            Dim VoucherStatus As String = row.Cells("VoucherStatusColumn").Value
            Dim DiscountAmount As Double = row.Cells("DiscountAmountColumn").Value
            Dim PostingDate As Date = row.Cells("PostingDateColumn").Value

            'Before writing to temp table, check payment to see if it was made before the specific date
            If PaidDate <= dtpSelectDate.Value Then
                'Values from the grid are correct
            Else
                PaymentAmount = 0
                DiscountAmount = 0
                VoucherAmountOpen = InvoiceTotal
            End If

            'Determine which date to age payables by (Invoice or Post Date)
            If rdoAgeByInvoice.Checked = True Then
                AgedDate = InvoiceDate
            Else
                AgedDate = PostingDate
            End If

            'Write values to temp table
            cmd = New SqlCommand("Insert Into APAgingTempDate(VoucherNumber, InvoiceNumber, PONumber, InvoiceDate, VendorID, ProductTotal, InvoiceFreight, InvoiceSalesTax, InvoiceTotal, VoucherAmountOpen, PaymentTerms, DueDate, PaidDate, PaymentAmount, SelectDate, DivisionID, DiscountDate, VoucherStatus, DiscountAmount) Values (@VoucherNumber, @InvoiceNumber, @PONumber, @InvoiceDate, @VendorID, @ProductTotal, @InvoiceFreight, @InvoiceSalesTax, @InvoiceTotal, @VoucherAmountOpen, @PaymentTerms, @DueDate, @PaidDate, @PaymentAmount, @SelectDate, @DivisionID, @DiscountDate, @VoucherStatus, @DiscountAmount)", con)

            With cmd.Parameters
                .Add("@VoucherNumber", SqlDbType.VarChar).Value = VoucherNumber
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                .Add("@PONumber", SqlDbType.VarChar).Value = PONumber
                .Add("@InvoiceDate", SqlDbType.VarChar).Value = AgedDate
                .Add("@VendorID", SqlDbType.VarChar).Value = VendorID
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@InvoiceFreight", SqlDbType.VarChar).Value = InvoiceFreight
                .Add("@InvoiceSalesTax", SqlDbType.VarChar).Value = InvoiceSalesTax
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                .Add("@VoucherAmountOpen", SqlDbType.VarChar).Value = VoucherAmountOpen
                .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
                .Add("@DueDate", SqlDbType.VarChar).Value = DueDate
                .Add("@PaidDate", SqlDbType.VarChar).Value = PaidDate
                .Add("@PaymentAmount", SqlDbType.VarChar).Value = PaymentAmount
                .Add("@SelectDate", SqlDbType.VarChar).Value = dtpSelectDate.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@DiscountDate", SqlDbType.VarChar).Value = DiscountDate
                .Add("@VoucherStatus", SqlDbType.VarChar).Value = VoucherStatus
                .Add("@DiscountAmount", SqlDbType.VarChar).Value = DiscountAmount
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            VoucherAmountOpen = 0
        Next

        ShowTempTable()

        If cboVendorClass.Text = "" Then
            ShowAPAgingDated()

            'Get Total Payables as of the selected date
            Dim TotalOpenAmountStatement As String = "SELECT SUM(InvoiceAmountOpen) FROM APAgingCategoryDated WHERE DivisionID = @DivisionID"
            Dim TotalOpenAmountCommand As New SqlCommand(TotalOpenAmountStatement, con)
            TotalOpenAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalOpenAmount = CDbl(TotalOpenAmountCommand.ExecuteScalar)
            Catch ex As Exception
                TotalOpenAmount = 0
            End Try
            con.Close()

            txtTotalPayables.Text = FormatCurrency(TotalOpenAmount, 2)
        Else
            ShowAPAgingDatedByVendorClass()

            'Get Total Receivables as of the selected date
            Dim TotalOpenAmountStatement As String = "SELECT SUM(InvoiceAmountOpen) FROM APAgingCategoryDated WHERE DivisionID = @DivisionID AND VendorClass = @VendorClass"
            Dim TotalOpenAmountCommand As New SqlCommand(TotalOpenAmountStatement, con)
            TotalOpenAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalOpenAmountCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = cboVendorClass.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalOpenAmount = CDbl(TotalOpenAmountCommand.ExecuteScalar)
            Catch ex As Exception
                TotalOpenAmount = 0
            End Try
            con.Close()

            txtTotalPayables.Text = FormatCurrency(TotalOpenAmount, 2)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        dtpSelectDate.Text = ""
        cboVendorClass.SelectedIndex = -1

        'Clear Temp Table before writing
        cmd = New SqlCommand("DELETE FROM APAgingTempDate WHERE DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        ShowBlankData()
        ShowBlankTempTable()
        ShowBlankAPAgingDated()

        txtTotalPayables.Clear()
        dtpSelectDate.Focus()
    End Sub

    Private Sub cmdViewDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewDetails.Click
        dgvAgedPayablesStep1.Visible = False
        dgvAPAgingCategoryDated.Visible = False
        dgvAPAgingTempDated.Visible = True
    End Sub

    Private Sub cmdARAging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdARAging.Click
        dgvAgedPayablesStep1.Visible = False
        dgvAPAgingCategoryDated.Visible = True
        dgvAPAgingTempDated.Visible = False
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds2
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintAPAgingDated As New PrintAPAgingDated
            Dim Result = NewPrintAPAgingDated.ShowDialog()
        End Using
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadVendorClass()
        ShowData()
    End Sub
End Class