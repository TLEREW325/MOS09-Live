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
Public Class ARAgedReceivablesDated
    Inherits System.Windows.Forms.Form

    Dim TotalOpenAmount, SUMPaymentAmount As Double
    Dim VerifyInvoiceStatus, TFFCustomerClass, TORCustomerClass, ALBCustomerClass As String
    Dim VerifyInvoice As Integer
    Dim CustomerFilter, DateFilter, CustomerClassFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ClearDataset As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ARAgedReceivablesDated_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
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

    Public Sub ShowDataByFilters()
        If cboCustomerID.Text = "" Then
            CustomerFilter = ""
        Else
            CustomerFilter = " AND CustomerID = '" + cboCustomerID.Text + "'"
        End If
        If cboDivisionID.Text = "" Or cboDivisionID.Text = "" Then
            If rdoAmerican.Checked = True Then
                CustomerClassFilter = " AND CustomerClass = 'AMERICAN'"
            ElseIf rdoCanadian.Checked = True Then
                CustomerClassFilter = " AND CustomerClass = 'CANADIAN'"
            Else
                CustomerClassFilter = ""
            End If
        Else
            CustomerClassFilter = ""
        End If

        'Load data grid
        cmd = New SqlCommand("SELECT * FROM ARAgingCalculationsFinal WHERE DivisionID = @DivisionID AND InvoiceDate <= @SelectDate" + CustomerFilter + CustomerClassFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = dtpSelectDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ARAgingCalculationsFinal")
        dgvARInvoiceLines.DataSource = ds.Tables("ARAgingCalculationsFinal")
        con.Close()
    End Sub

    Public Sub ShowBlankData()
        dgvARInvoiceLines.DataSource = Nothing
    End Sub

    Public Sub ShowTempTable()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM ARAgingTempDate WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ARAgingTempDate")
        dgvFilteredTemp.DataSource = ds1.Tables("ARAgingTempDate")
        con.Close()
    End Sub

    Public Sub ShowBlankTempTable()
        dgvFilteredTemp.DataSource = Nothing
    End Sub

    Public Sub ShowARAgingDated()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM ARAgingCategoryDated WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ARAgingCategoryDated")
        dgvARAgingDated.DataSource = ds2.Tables("ARAgingCategoryDated")
        con.Close()
    End Sub

    Public Sub ShowARAgingDatedTFF()
        If rdoAmerican.Checked = True Then
            TFFCustomerClass = "AMERICAN"
        Else
            TFFCustomerClass = "CANADIAN"
        End If

        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM ARAgingCategoryDated WHERE DivisionID = @DivisionID AND CustomerClass = @CustomerClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = TFFCustomerClass
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ARAgingCategoryDated")
        dgvARAgingDated.DataSource = ds2.Tables("ARAgingCategoryDated")
        con.Close()
    End Sub

    Public Sub ShowARAgingDatedALB()
        If rdoAmerican.Checked = True Then
            ALBCustomerClass = "AMERICAN"
        Else
            ALBCustomerClass = "CANADIAN"
        End If

        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT * FROM ARAgingCategoryDated WHERE DivisionID = @DivisionID AND CustomerClass = @CustomerClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = ALBCustomerClass
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ARAgingCategoryDated")
        dgvARAgingDated.DataSource = ds2.Tables("ARAgingCategoryDated")
        con.Close()
    End Sub

    Public Sub ShowARAgingDatedTOR()
        If rdoAmerican.Checked = True Then
            TORCustomerClass = "AMERICAN"
        Else
            TORCustomerClass = "CANADIAN"
        End If

        'Load Aging Data
        cmd = New SqlCommand("SELECT * FROM ARAgingCategoryDated WHERE DivisionID = @DivisionID AND CustomerClass = @CustomerClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = TORCustomerClass
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "ARAgingCategoryDated")
        dgvARAgingDated.DataSource = ds2.Tables("ARAgingCategoryDated")
        con.Close()
    End Sub

    Public Sub ShowBlankARAgingDated()
        dgvARAgingDated.DataSource = Nothing
    End Sub

    Public Sub LoadCustomer()
        'Load Batch Number table for specific division
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        cboCustomerID.DataSource = ds3.Tables("CustomerList")
        cboCustomerName.DataSource = ds3.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        'Filter Existing Invoice Table with Payments
        '**********************************************************************************************************************
        'Clear Temp Table before writing
        cmd = New SqlCommand("DELETE FROM ARAgingTempDate WHERE DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        '**********************************************************************************************************************
        ShowDataByFilters()
        '**********************************************************************************************************************
        'Extract Data one record at a time, and write to a new temp table
        Dim InvoiceNumber, SalesOrderNumber, ShipmentNumber, ARTransactionKey As Integer
        Dim InvoiceDate, PaymentDate As Date
        Dim CustomerID, CustomerPO, PaymentTerms, Comment As String
        Dim BilledFreight, SalesTax, ProductTotal, Discount, InvoiceTotal, PaymentAmount, InvoiceAmountOpen As Double

        For Each row As DataGridViewRow In dgvARInvoiceLines.Rows
            Try
                InvoiceNumber = row.Cells("InvoiceNumberColumn").Value
            Catch ex As Exception
                InvoiceNumber = 0
            End Try
            Try
                InvoiceDate = row.Cells("InvoiceDateColumn").Value
            Catch ex As Exception
                InvoiceDate = Today()
            End Try
            Try
                SalesOrderNumber = row.Cells("SalesOrderNumberColumn").Value
            Catch ex As Exception
                SalesOrderNumber = 0
            End Try
            Try
                ShipmentNumber = row.Cells("ShipmentNumberColumn").Value
            Catch ex As Exception
                ShipmentNumber = 0
            End Try
            Try
                CustomerID = row.Cells("CustomerIDColumn").Value
            Catch ex As Exception
                CustomerID = ""
            End Try
            Try
                CustomerPO = row.Cells("CustomerPOColumn").Value
            Catch ex As Exception
                CustomerPO = ""
            End Try
            Try
                PaymentTerms = row.Cells("PaymentTermsColumn").Value
            Catch ex As Exception
                PaymentTerms = "N30"
            End Try
            Try
                Comment = row.Cells("CommentColumn").Value
            Catch ex As Exception
                Comment = ""
            End Try
            Try
                BilledFreight = row.Cells("BilledFreightColumn").Value
            Catch ex As Exception
                BilledFreight = 0
            End Try
            Try
                SalesTax = row.Cells("SalesTaxColumn").Value
            Catch ex As Exception
                SalesTax = 0
            End Try
            Try
                ProductTotal = row.Cells("ProductTotalColumn").Value
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                Discount = row.Cells("DiscountColumn").Value
            Catch ex As Exception
                Discount = 0
            End Try
            Try
                InvoiceTotal = row.Cells("InvoiceTotalColumn").Value
            Catch ex As Exception
                InvoiceTotal = 0
            End Try
            Try
                PaymentAmount = row.Cells("PaymentAmountColumn").Value
            Catch ex As Exception
                PaymentAmount = 0
            End Try
            Try
                ARTransactionKey = row.Cells("ARTransactionKeyColumn").Value
            Catch ex As Exception
                ARTransactionKey = 0
            End Try
            Try
                PaymentDate = row.Cells("PaymentDateColumn").Value
            Catch ex As Exception
                PaymentDate = Today()
            End Try
            Try
                InvoiceAmountOpen = row.Cells("InvoiceAmountOpenColumn").Value
            Catch ex As Exception
                InvoiceAmountOpen = 0
            End Try

            'Before writing to temp table, check payment to see if it was made before the specific date
            If PaymentDate <= dtpSelectDate.Value Then
                'Values from the grid are correct
            Else
                PaymentAmount = 0
                InvoiceAmountOpen = InvoiceTotal
            End If
            '**********************************************************************************************************************
            'Verify that only one Invoice is written to the temp table, but the Sum of payments is correct
            Dim SUMPaymentAmountStatement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND InvoiceNumber = @InvoiceNumber AND PaymentDate <= @SelectDate"
            Dim SUMPaymentAmountCommand As New SqlCommand(SUMPaymentAmountStatement, con)
            SUMPaymentAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            SUMPaymentAmountCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
            SUMPaymentAmountCommand.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = dtpSelectDate.Value

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SUMPaymentAmount = CDbl(SUMPaymentAmountCommand.ExecuteScalar)
            Catch ex As Exception
                SUMPaymentAmount = 0
            End Try
            con.Close()

            InvoiceAmountOpen = InvoiceTotal - SUMPaymentAmount
            '**********************************************************************************************************************
            'Query database temp table to write to table or skip if Invoice Number exists
            Dim VerifyInvoiceStatement As String = "SELECT COUNT(InvoiceNumber) FROM ARAgingTempDate WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim VerifyInvoiceCommand As New SqlCommand(VerifyInvoiceStatement, con)
            VerifyInvoiceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            VerifyInvoiceCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                VerifyInvoice = CInt(VerifyInvoiceCommand.ExecuteScalar)
            Catch ex As Exception
                VerifyInvoice = 0
            End Try
            con.Close()
            '**********************************************************************************************************************
            If VerifyInvoice > 0 Then
                'Do not write to temp table
            Else
                If InvoiceAmountOpen = 0 Then
                    'Skip
                Else
                    'Write values to temp table
                    cmd = New SqlCommand("Insert Into ARAgingTempDate(InvoiceNumber, InvoiceDate, SalesOrderNumber, ShipmentNumber, DivisionID, CustomerID, CustomerPO, PaymentsTerms, Comment, BilledFreight, SalesTax, ProductTotal, InvoiceTotal, InvoiceAmountOpen, Discount, PaymentAmount, PaymentDate, ARTransactionKey, SelectDate) Values (@InvoiceNumber, @InvoiceDate, @SalesOrderNumber, @ShipmentNumber, @DivisionID, @CustomerID, @CustomerPO, @PaymentsTerms, @Comment, @BilledFreight, @SalesTax, @ProductTotal, @InvoiceTotal, @InvoiceAmountOpen, @Discount, @PaymentAmount, @PaymentDate, @ARTransactionKey, @SelectDate)", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = InvoiceNumber
                        .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                        .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = SalesOrderNumber
                        .Add("@ShipmentNumber", SqlDbType.VarChar).Value = ShipmentNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@CustomerID", SqlDbType.VarChar).Value = CustomerID
                        .Add("@CustomerPO", SqlDbType.VarChar).Value = CustomerPO
                        .Add("@PaymentsTerms", SqlDbType.VarChar).Value = PaymentTerms
                        .Add("@Comment", SqlDbType.VarChar).Value = Comment
                        .Add("@BilledFreight", SqlDbType.VarChar).Value = BilledFreight
                        .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                        .Add("@InvoiceAmountOpen", SqlDbType.VarChar).Value = InvoiceAmountOpen
                        .Add("@Discount", SqlDbType.VarChar).Value = Discount
                        .Add("@PaymentAmount", SqlDbType.VarChar).Value = SUMPaymentAmount
                        .Add("@PaymentDate", SqlDbType.VarChar).Value = PaymentDate
                        .Add("@ARTransactionKey", SqlDbType.VarChar).Value = ARTransactionKey
                        .Add("@SelectDate", SqlDbType.VarChar).Value = dtpSelectDate.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            End If
        Next
        '**********************************************************************************************************************
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            '**********************************************************************************************************************
            'Get Total Receivables as of the selected date
            If rdoAmerican.Checked = True Then
                TFFCustomerClass = "AMERICAN"
            Else
                TFFCustomerClass = "CANADIAN"
            End If

            Dim TotalOpenAmountStatement As String = "SELECT SUM(InvoiceAmountOpen) FROM ARAgingCategoryDated WHERE DivisionID = @DivisionID AND CustomerClass = @CustomerClass"
            Dim TotalOpenAmountCommand As New SqlCommand(TotalOpenAmountStatement, con)
            TotalOpenAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalOpenAmountCommand.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = TFFCustomerClass

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalOpenAmount = CDbl(TotalOpenAmountCommand.ExecuteScalar)
            Catch ex As Exception
                TotalOpenAmount = 0
            End Try
            con.Close()

            txtTotalReceivables.Text = FormatCurrency(TotalOpenAmount, 2)
            '**********************************************************************************************************************
            ShowTempTable()
            ShowARAgingDatedTFF()
        Else
            '**********************************************************************************************************************
            'Get Total Receivables as of the selected date
            Dim TotalOpenAmountStatement As String = "SELECT SUM(InvoiceAmountOpen) FROM ARAgingCategoryDated WHERE DivisionID = @DivisionID"
            Dim TotalOpenAmountCommand As New SqlCommand(TotalOpenAmountStatement, con)
            TotalOpenAmountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalOpenAmount = CDbl(TotalOpenAmountCommand.ExecuteScalar)
            Catch ex As Exception
                TotalOpenAmount = 0
            End Try
            con.Close()

            txtTotalReceivables.Text = FormatCurrency(TotalOpenAmount, 2)
            '**********************************************************************************************************************
            ShowTempTable()
            ShowARAgingDated()
        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = New DataSet()
        GDS = Nothing

        GDS = ds2
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintARAgingDated As New PrintARAgingDated
            Dim Result = NewPrintARAgingDated.ShowDialog()
        End Using
    End Sub

    Private Sub cmdViewDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewDetails.Click
        dgvFilteredTemp.Visible = True
        dgvARAgingDated.Visible = False
        dgvARInvoiceLines.Visible = False
    End Sub

    Private Sub cmdARAging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdARAging.Click
        dgvFilteredTemp.Visible = False
        dgvARAgingDated.Visible = True
        dgvARInvoiceLines.Visible = False
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        dtpSelectDate.Text = ""

        'Clear Temp Table before writing
        cmd = New SqlCommand("DELETE FROM ARAgingTempDate WHERE DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        ShowBlankData()
        ShowBlankTempTable()
        ShowBlankARAgingDated()

        txtTotalReceivables.Clear()
        dtpSelectDate.Focus()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        'Load canadian defaluts
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            rdoAmerican.Enabled = True
            rdoCanadian.Enabled = True
        Else
            rdoAmerican.Enabled = False
            rdoCanadian.Enabled = False
        End If

        LoadCustomer()
    End Sub

    Private Sub cmdPrintStatements_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintStatements.Click
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintCustomerStatementDated As New PrintCustomerStatementDated
            Dim Result = NewPrintCustomerStatementDated.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class