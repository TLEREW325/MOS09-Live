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
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.parser
Imports WIA
Imports PdfSharp.Pdf
Imports System.Threading
Imports iTextSharp.text.Image
Imports PdfSharp
Imports document = iTextSharp.text.Document
Imports System.Drawing
Imports System.ComponentModel
Imports iTextSharp
Imports System.Reflection

Public Class ViewCashReceipts
    Inherits System.Windows.Forms.Form

    Dim TextFilter, CustomerFilter, DateFilter, CheckFilter, BatchFilter, InvoiceFilter As String
    Dim InvoiceNumber, BatchNumber As Integer
    Dim strInvoiceNumber, strBatchNumber As String
    Dim BeginDate, EndDate As Date
    Dim TotalReceipts As Double = 0
    Dim payment As String = ""
    Dim batch As String = ""

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Remote
    Dim isLoaded As Boolean = False
    Dim dir3 As New System.IO.DirectoryInfo("\\TFP-FS\CashReceipts\UploadedCashReceipts\")
    Dim dir2 As New System.IO.DirectoryInfo("\\TFP-FS\CashReceipts\UploadedCashBatch\")
    Dim FilesToDelete As List(Of String)
    Dim bgPDF As BackgroundWorker
    Dim bgAppendPDF As BackgroundWorker
    Dim LoadingScreen As New Loading
    Dim ShipmentNumber As Integer = 0
    ''Remote WIA variables
    Dim remoteWIA As MOSRemoteWIA
    Dim bgwkRemoteWIA As BackgroundWorker
    Dim frm As System.Windows.Forms.Form
    Dim remoteCheck As Boolean = False

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewCashReceipts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        LoadCurrentDivision()

        If My.Computer.Name.StartsWith("TFP") Then
            AppendCashBatchToolStripMenuItem.Enabled = False
            AppendCashReceiptToolStripMenuItem.Enabled = False
        Else
            AppendCashBatchToolStripMenuItem.Enabled = True
            AppendCashReceiptToolStripMenuItem.Enabled = True
        End If

        If chkDateRange.Checked = False Then
            chkInvoiceDate.Enabled = False
            chkInvoiceDate.Checked = False
            chkPaymentDate.Enabled = False
            chkPaymentDate.Checked = False
        Else
            chkInvoiceDate.Enabled = True
            chkPaymentDate.Enabled = True
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

    Private Sub dgvCustomerPayment_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCustomerPayment.CellClick
        If (e.RowIndex >= 0) Then
            Dim RowIndex As Integer = Me.dgvCustomerPayment.CurrentCell.RowIndex
            PaymentBatchNumber.batchNumber = Me.dgvCustomerPayment.Rows(RowIndex).Cells("BatchNumberColumn").Value
            PaymentBatchNumber.PaymentID = Me.dgvCustomerPayment.Rows(RowIndex).Cells("PaymentIDColumn").Value
            Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
            If File.Exists(CashReceiptExists) Then
                cmdViewReceipts.Enabled = True
            Else
                cmdViewReceipts.Enabled = False

            End If
            CashReceiptExists = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + PaymentBatchNumber.batchNumber + ".pdf"
            If File.Exists(CashReceiptExists) Then
                cmdViewBatch.Enabled = True
            Else
                cmdViewBatch.Enabled = False
            End If
        End If
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvCustomerPayment.CellValueChanged
        Dim LineDivision, CheckNumber, PaymentType, CardNumber, CardDate, AuthorizationNumber, ReferenceNumber, CheckComment, CreditComment As String
        Dim ARTransactionKey As Integer

        If Me.dgvCustomerPayment.RowCount = 0 Then
            'Skip if datagrid is blank
        Else
            Dim RowIndex As Integer = Me.dgvCustomerPayment.CurrentCell.RowIndex

            Try
                ARTransactionKey = Me.dgvCustomerPayment.Rows(RowIndex).Cells("ARTransactionKeyColumn").Value
            Catch ex As Exception
                ARTransactionKey = 0
            End Try
            Try
                PaymentType = Me.dgvCustomerPayment.Rows(RowIndex).Cells("PaymentTypeColumn").Value
            Catch ex As Exception
                PaymentType = ""
            End Try
            Try
                CheckNumber = Me.dgvCustomerPayment.Rows(RowIndex).Cells("CheckNumberColumn").Value
            Catch ex As Exception
                CheckNumber = ""
            End Try
            Try
                CardNumber = Me.dgvCustomerPayment.Rows(RowIndex).Cells("CardNumberColumn").Value
            Catch ex As Exception
                CardNumber = ""
            End Try
            Try
                CardDate = Me.dgvCustomerPayment.Rows(RowIndex).Cells("CardDateColumn").Value
            Catch ex As Exception
                CardDate = ""
            End Try
            Try
                AuthorizationNumber = Me.dgvCustomerPayment.Rows(RowIndex).Cells("AuthorizationNumberColumn").Value
            Catch ex As Exception
                AuthorizationNumber = ""
            End Try
            Try
                ReferenceNumber = Me.dgvCustomerPayment.Rows(RowIndex).Cells("ReferenceNumberColumn").Value
            Catch ex As Exception
                ReferenceNumber = ""
            End Try
            Try
                CheckComment = Me.dgvCustomerPayment.Rows(RowIndex).Cells("CheckCommentColumn").Value
            Catch ex As Exception
                CheckComment = ""
            End Try
            Try
                CreditComment = Me.dgvCustomerPayment.Rows(RowIndex).Cells("CreditCommentColumn").Value
            Catch ex As Exception
                CreditComment = ""
            End Try
            Try
                LineDivision = Me.dgvCustomerPayment.Rows(RowIndex).Cells("DivisionIDColumn").Value
            Catch ex As Exception
                LineDivision = ""
            End Try

            If ARTransactionKey = 0 Or LineDivision = "" Then
                'Skip save routine
            Else
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE ARCustomerPayment SET CheckNumber = @CheckNumber, CardNumber = @CardNumber, CheckComment = @CheckComment, CreditComment = @CreditComment, PaymentType = @PaymentType, CardDate = @CardDate, AuthorizationNumber = @AuthorizationNumber, ReferenceNumber = @ReferenceNumber WHERE ARTransactionKey = @ARTransactionKey AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@ARTransactionKey", SqlDbType.VarChar).Value = ARTransactionKey
                    .Add("@DivisionID", SqlDbType.VarChar).Value = LineDivision
                    .Add("@CheckNumber", SqlDbType.VarChar).Value = CheckNumber
                    .Add("@CardNumber", SqlDbType.VarChar).Value = CardNumber
                    .Add("@CheckComment", SqlDbType.VarChar).Value = CheckComment
                    .Add("@CreditComment", SqlDbType.VarChar).Value = CreditComment
                    .Add("@PaymentType", SqlDbType.VarChar).Value = PaymentType
                    .Add("@CardDate", SqlDbType.VarChar).Value = CardDate
                    .Add("@AuthorizationNumber", SqlDbType.VarChar).Value = AuthorizationNumber
                    .Add("@ReferenceNumber", SqlDbType.VarChar).Value = ReferenceNumber
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        End If
    End Sub

    Private Sub dgvCustomerPayment_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvCustomerPayment.CellDoubleClick
        Dim RowCustomer As String
        Dim RowIndex As Integer = Me.dgvCustomerPayment.CurrentCell.RowIndex

        RowCustomer = Me.dgvCustomerPayment.Rows(RowIndex).Cells("CustomerIDColumn").Value

        GlobalCustomerID = RowCustomer
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintARCustomerStatementSingle As New PrintARCustomerStatementSingle
            Dim Result = NewPrintARCustomerStatementSingle.ShowDialog()
        End Using
    End Sub

    Public Sub CleardataInDatagrid()
        dgvCustomerPayment.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If chkDateRange.Checked = True And (chkInvoiceDate.Checked = False And chkPaymentDate.Checked = False) Then
            MsgBox("To filter by date range, you must select Invoice Date or Payment Date.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboBatchNumber.Text <> "" Then
            BatchNumber = Val(cboBatchNumber.Text)
            strBatchNumber = CStr(BatchNumber)
            BatchFilter = " AND BatchNumber = '" + strBatchNumber + "'"
        Else
            BatchFilter = ""
        End If
        If cboInvoiceNumber.Text <> "" Then
            InvoiceNumber = Val(cboInvoiceNumber.Text)
            strInvoiceNumber = CStr(InvoiceNumber)
            InvoiceFilter = " AND InvoiceNumber = '" + strInvoiceNumber + "'"
        Else
            InvoiceFilter = ""
        End If
        If txtCheckNumber.Text <> "" Then
            CheckFilter = " AND CheckNumber LIKE '%" + txtCheckNumber.Text + "%'"
        Else
            CheckFilter = ""
        End If
        If txtTextSearch.Text <> "" Then
            TextFilter = " AND (CheckNumber LIKE '%" + txtTextSearch.Text + "%' OR CustomerID LIKE '%" + txtTextSearch.Text + "%')"
        Else
            TextFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            BeginDate = dtpBeginDate.Text
            EndDate = dtpEndDate.Text

            If chkInvoiceDate.Checked = True Then
                DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            ElseIf chkPaymentDate.Checked = True Then
                DateFilter = " AND PaymentDate BETWEEN @BeginDate AND @EndDate"
            Else
                DateFilter = ""
            End If
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ARCustomerPaymentQuery WHERE DivisionID <> @DivisionID" + CustomerFilter + InvoiceFilter + CheckFilter + TextFilter + BatchFilter + DateFilter + " ORDER BY DivisionID, CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARCustomerPaymentQuery")
            dgvCustomerPayment.DataSource = ds.Tables("ARCustomerPaymentQuery")
            con.Close()
            Me.dgvCustomerPayment.Columns("DivisionIDColumn").Visible = True

            'Load Totals
            Dim TotalReceiptsString As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPaymentQuery WHERE DivisionID <> @DivisionID" + CustomerFilter + InvoiceFilter + BatchFilter + CheckFilter + TextFilter + DateFilter
            Dim TotalReceiptsCommand As New SqlCommand(TotalReceiptsString, con)
            TotalReceiptsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            TotalReceiptsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalReceiptsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalReceipts = CDbl(TotalReceiptsCommand.ExecuteScalar)
            Catch ex As Exception
                TotalReceipts = 0
            End Try
            con.Close()
        Else
            cmd = New SqlCommand("SELECT * FROM ARCustomerPaymentQuery WHERE DivisionID = @DivisionID" + CustomerFilter + InvoiceFilter + CheckFilter + TextFilter + BatchFilter + DateFilter + " ORDER BY CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ARCustomerPaymentQuery")
            dgvCustomerPayment.DataSource = ds.Tables("ARCustomerPaymentQuery")
            con.Close()
            Me.dgvCustomerPayment.Columns("DivisionIDColumn").Visible = False

            'Load Totals
            Dim TotalReceiptsString As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPaymentQuery WHERE DivisionID = @DivisionID" + CustomerFilter + InvoiceFilter + BatchFilter + CheckFilter + TextFilter + DateFilter
            Dim TotalReceiptsCommand As New SqlCommand(TotalReceiptsString, con)
            TotalReceiptsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TotalReceiptsCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            TotalReceiptsCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TotalReceipts = CDbl(TotalReceiptsCommand.ExecuteScalar)
            Catch ex As Exception
                TotalReceipts = 0
            End Try
            con.Close()
        End If

        txtTotalCashReceipts.Text = FormatCurrency(TotalReceipts, 2)
    End Sub

    Public Sub LoadCustomerList()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerID FROM CustomerList WHERE DivisionID <> @DivisionID AND CustomerClass <> @CustomerClass Order By CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        Else
            cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass Order By CustomerID", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CustomerList")
        cboCustomerID.DataSource = ds1.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadInvoiceNumber()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE DivisionID <> @DivisionID ORDER BY InvoiceNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID ORDER BY InvoiceNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "InvoiceHeaderTable")
        cboInvoiceNumber.DataSource = ds2.Tables("InvoiceHeaderTable")
        con.Close()
        cboInvoiceNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadBatchNumber()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT BatchNumber FROM ARCustomerPaymentQuery WHERE DivisionID <> @DivisionID ORDER BY BatchNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Else
            cmd = New SqlCommand("SELECT DISTINCT BatchNumber FROM ARCustomerPaymentQuery WHERE DivisionID = @DivisionID ORDER BY BatchNumber DESC", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ARCustomerPaymentQuery")
        cboBatchNumber.DataSource = ds3.Tables("ARCustomerPaymentQuery")
        con.Close()
        cboBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT DISTINCT CustomerName FROM CustomerList WHERE DivisionID <> @DivisionID AND CustomerClass <> @CustomerClass ORDER By CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        Else
            cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER By CustomerName", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        End If
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerList")
        cboCustomerName.DataSource = ds4.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerIDByName()
        If cboDivisionID.Text = "ADM" Then
            Dim CustomerID1 As String = ""

            Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID <> @DivisionID"
            Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
            CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
            CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
            Catch ex As Exception
                CustomerID1 = ""
            End Try
            con.Close()

            cboCustomerID.Text = CustomerID1
        Else
            Dim CustomerID1 As String = ""

            Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
            Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
            CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
            CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
            Catch ex As Exception
                CustomerID1 = ""
            End Try
            con.Close()

            cboCustomerID.Text = CustomerID1
        End If
    End Sub

    Public Sub LoadCustomerNameByID()
        If cboDivisionID.Text = "ADM" Then
            Dim CustomerName1 As String = ""

            Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID <> @DivisionID"
            Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
            CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
            Catch ex As Exception
                CustomerName1 = ""
            End Try
            con.Close()

            cboCustomerName.Text = CustomerName1
        Else
            Dim CustomerName1 As String = ""

            Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
            CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
            Catch ex As Exception
                CustomerName1 = ""
            End Try
            con.Close()

            cboCustomerName.Text = CustomerName1
        End If
    End Sub

    Public Sub ClearData()
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboInvoiceNumber.Text = ""
        cboBatchNumber.Text = ""

        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboInvoiceNumber.SelectedIndex = -1
        cboBatchNumber.SelectedIndex = -1

        txtCheckNumber.Clear()
        txtTotalCashReceipts.Clear()
        txtTextSearch.Clear()

        chkInvoiceDate.Checked = False
        chkDateRange.Checked = False
        chkPaymentDate.Checked = False

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboCustomerID.Focus()
    End Sub

    Public Sub ClearVariables()
        CustomerFilter = ""
        DateFilter = ""
        CheckFilter = ""
        BatchFilter = ""
        InvoiceFilter = ""
        InvoiceNumber = 0
        BatchNumber = 0
        strInvoiceNumber = ""
        strBatchNumber = ""
        TotalReceipts = 0
        TextFilter = ""
    End Sub

    Private Sub chkPaymentDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPaymentDate.CheckedChanged
        If chkPaymentDate.Checked = True Then
            chkInvoiceDate.Checked = False
        Else
            'Do nothing
        End If
    End Sub

    Private Sub chkInvoiceDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInvoiceDate.CheckedChanged
        If chkInvoiceDate.Checked = True Then
            chkPaymentDate.Checked = False
        Else
            'Do nothing
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomerList()
        LoadCustomerName()
        LoadInvoiceNumber()
        LoadBatchNumber()
        ClearVariables()
        ClearData()
        CleardataInDatagrid()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        CleardataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds

        Using NewPrintARCustomerPaymentListing As New PrintARCustomerPaymentListing
            Dim result = NewPrintARCustomerPaymentListing.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem1.Click
        GDS = ds

        Using NewPrintARCustomerPaymentListing As New PrintARCustomerPaymentListing
            Dim result = NewPrintARCustomerPaymentListing.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()

        Try
            For Each row As DataGridViewRow In dgvCustomerPayment.Rows

                Dim pdfname As String = row.Cells("PaymentIDColumn").Value.ToString
                Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname + ".pdf"
                Dim batchName As String = row.Cells("BatchNumberColumn").Value.ToString
                Dim CashBatchExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + batchName + ".pdf"

                If File.Exists(CashReceiptExists) Then
                    row.Cells("PaymentIDColumn").Style.BackColor = Color.LightGreen
                Else
                    row.Cells("PaymentIDColumn").Style.BackColor = Color.LightCoral
                End If

                If File.Exists(CashBatchExists) Then
                    row.Cells("BatchNumberColumn").Style.BackColor = Color.LightGreen
                Else
                    row.Cells("BatchNumberColumn").Style.BackColor = Color.LightCoral
                End If
            Next
        Catch ex As System.Exception
            'Error Log
        End Try
    End Sub

    Private Sub chkDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateRange.CheckedChanged
        If chkDateRange.Checked = False Then
            chkInvoiceDate.Enabled = False
            chkInvoiceDate.Checked = False
            chkPaymentDate.Enabled = False
            chkPaymentDate.Checked = False
        Else
            chkInvoiceDate.Enabled = True
            chkPaymentDate.Enabled = True
        End If
    End Sub

    Private Sub cmdViewBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewBatch.Click
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + PaymentBatchNumber.batchNumber + ".pdf"
        If File.Exists(CashReceiptExists) Then
            System.Diagnostics.Process.Start(CashReceiptExists)
        End If
    End Sub

    Private Sub cmdViewReceipts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewReceipts.Click
        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
        If File.Exists(CashReceiptExists) Then
            System.Diagnostics.Process.Start(CashReceiptExists)
        End If
    End Sub

    Private Sub ScanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanToolStripMenuItem.Click
        Dim name1, name2, final1 As String
        Dim remoteScan As Boolean = False
        Dim W9Exists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
        If File.Exists(W9Exists) Then

            Dim loadingScreen As New Loading
            loadingScreen.Text = "Payment Batch Loading"
            loadingScreen.Label1.Text = "Loading Payment Batch Data, Please Wait...."
            loadingScreen.Show()
            loadingScreen.BringToFront()
            ' Deletes the WIA testing temp file
            Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
            ' Creates the folder if the temp folder is not currently created
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")

            path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            'If there had been a previous scan then delete the picture from the picturebox
            GlobalVariables.Counter = 0
            Dim mgr As New WIA.DeviceManagerClass
            Dim Scanner As WIA.Device = Nothing
            If mgr.DeviceInfos.Count > 1 Then
                ''More than 1 scanner was detected
                Dim lst As New List(Of Integer)
                ''Finds all the USB scanners
                For i As Integer = 1 To mgr.DeviceInfos.Count()
                    If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                        lst.Add(i)
                    End If
                Next
                ''Check to see how many usb scanners were found
                If lst.Count > 1 Or lst.Count = 0 Then
                    Dim selectScanner As New WIA.CommonDialog
                    Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
                Else
                    Scanner = mgr.DeviceInfos(lst(0)).Connect()
                End If
            ElseIf mgr.DeviceInfos.Count = 0 Then
                ''No scanners were detected
                If My.Computer.Name.ToString.StartsWith("TFP") Then

                    bgwkRemoteWIA = New BackgroundWorker()
                    bgwkRemoteWIA.WorkerReportsProgress = True
                    AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_runReceipt
                    AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_CompletedAppendReceipt
                    AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_ProgressReceipt
                    remoteScan = True

                    remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, ShipmentNumber)
                    bgwkRemoteWIA.RunWorkerAsync()
                Else
                    ''No scanners were detected
                    MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                ''Only 1 scanner is connected
                Scanner = mgr.DeviceInfos(1).Connect()
            End If
            If Scanner IsNot Nothing Then
                Dim item As WIA.Item = Scanner.Items(1)
                Dim obj As Object
                Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
                ''Specific scanning properties
                For Each prop As WIA.Property In Scanner.Items(1).Properties
                    Dim x As WIA.IProperty = prop
                    Select Case prop.PropertyID
                        Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                            obj = 0
                            x.let_Value(obj)
                        Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                            obj = 2
                            x.let_Value(obj)
                        Case "6147" ''(DPI) Horizontal Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6148" ''(DPI) Vertical Resolution
                            obj = 200
                            x.let_Value(obj)
                        Case "6151" ''horizontal extent (width)
                            obj = 1700
                            x.let_Value(obj)
                        Case "6152" ''vertical extent (height)
                            obj = 2338
                            x.let_Value(obj)
                    End Select
                Next

                Dim dial As New WIA.CommonDialog
                Dim hasMorePages As Boolean = True
                Dim ScannedAtleastOnePage As Boolean = False
                Dim pages As Integer = 0
                Dim ScannedImages As New List(Of iTextSharp.text.Image)
                If remoteScan = False Then
                    ''Loops until all pages are scanned.
                    While hasMorePages
                        GlobalVariables.Counter = GlobalVariables.Counter + 1
                        pages += 1
                        Try
                            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                            Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                            Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                            Img.SaveFile(tmp)
                            'ScannedImages.Add(Img.fromfile(tmp))
                            ScannedAtleastOnePage = True
                        Catch ex As System.Exception
                            ''Looks for paper empty error to break the loop and/or to show error message
                            If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                                If Not ScannedAtleastOnePage Then
                                    MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    GlobalVariables.paperscan = False
                                Else
                                    GlobalVariables.paperscan = True
                                End If
                                hasMorePages = False
                            End If
                        End Try
                    End While
                End If

                'Displays the first saved scan into the picturebox
                If GlobalVariables.paperscan Then
                    GlobalVariables.StartCounter = 1
                    Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                    GlobalVariables.NextPrevious = GlobalVariables.StartCounter
                End If
            End If

            'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
            GlobalVariables.previousScan = True
            GlobalVariables.NextPrevious = 1

            Dim extensions As New List(Of String)
            extensions.Add("*.bmp")
            Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

            'counts the files in the folder
            Dim fileCount As Integer
            For i As Integer = 0 To extensions.Count - 1
                fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
            Next
            GlobalVariables.totalfiles = fileCount
        End If

        If File.Exists(W9Exists) Then
            If remoteScan = False Then
                Try
                    'Variables Declared
                    Dim comboboxSelection As String = PaymentBatchNumber.PaymentID

                    Dim strDir As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\"
                    If Not System.IO.Directory.Exists(strDir) Then System.IO.Directory.CreateDirectory(strDir)

                    'Name of file

                    Dim strFilename As String = "Appended2.pdf"
                    'path to bmp
                    Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                    Dim strCompletePath As String = strDir & strFilename
                    Dim pdfDoc As New document()
                    Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
                    pdfDoc.Open()
                    'Grabs the bmp image seen on screen
                    Dim img As iTextSharp.text.Image = GetInstance(strPathname)
                    'structures it to fit on pdf file
                    img.ScalePercent(72.0F / img.DpiX * 100)
                    img.SetAbsolutePosition(0, 0)
                    'adds image to the document
                    pdfDoc.Add(img)
                    'closes the pdf and saves it
                    pdfDoc.Close()

                    'messagebox confirmation on saving
                    MessageBox.Show("Save Confirmation", "Saved Cash Receipt PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    'declares list of bmp files to be counted
                    Dim extensions As New List(Of String)
                    extensions.Add("*.bmp")
                    Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

                    GlobalVariables.previousScan = True

                    LoadingScreen.Close()
                    Dim initial As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
                    Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                    My.Computer.FileSystem.MoveFile(initial, final)
                    final1 = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
                    name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                    name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"
                    Dim pathArray = New String() {name1, name2}
                    Try
                        MergePdfFiles(pathArray, final1)
                        MsgBox("File Appended")
                    Catch ex As Exception
                        MsgBox("File Not Appended")
                    End Try

                Catch ex As TargetInvocationException
                    'We only catch this one, so you can catch other exception later on
                    'We get the inner exception because ex is not helpfull
                    Dim iEX = ex.InnerException
                Catch ex As Exception
                    'Error Log
                End Try
            End If

            For Each row As DataGridViewRow In dgvCustomerPayment.Rows
                Dim pdfname2 As String = row.Cells("PaymentIDColumn").Value.ToString
                Dim CashReceiptExistsx As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname2 + ".pdf"
                Dim batchName As String = row.Cells("BatchNumberColumn").Value.ToString
                Dim CashBatchExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + batchName + ".pdf"

                If File.Exists(CashReceiptExistsx) Then
                    row.Cells("PaymentIDColumn").Style.BackColor = Color.LightGreen
                Else
                    row.Cells("PaymentIDColumn").Style.BackColor = Color.LightCoral
                End If
                If File.Exists(CashBatchExists) Then
                    row.Cells("BatchNumberColumn").Style.BackColor = Color.LightGreen
                Else
                    row.Cells("BatchNumberColumn").Style.BackColor = Color.LightCoral
                End If
            Next
        Else
            MsgBox("Please use the Re-Upload function before using append. No initial file.")
        End If

        Dim pdfname As String = PaymentBatchNumber.PaymentID
        Dim CashReceiptExists2 As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname + ".pdf"
        If File.Exists(CashReceiptExists2) Then
            System.Diagnostics.Process.Start(CashReceiptExists2)
        Else
            MsgBox("File Upload Error, Please Try Again")
        End If
    End Sub

    Public Shared Function MergePdfFiles(ByVal pdfFiles() As String, ByVal outputPath As String) As Boolean
        Dim result As Boolean = False
        Dim pdfCount As Integer = 0     'total input pdf file count
        Dim f As Integer = 0    'pointer to current input pdf file
        Dim fileName As String
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim pageCount As Integer = 0
        Dim pdfDoc As iTextSharp.text.Document = Nothing    'the output pdf document
        Dim writer As PdfWriter = Nothing
        Dim cb As PdfContentByte = Nothing

        Dim page As PdfImportedPage = Nothing
        Dim rotation As Integer = 0

        Try
            pdfCount = pdfFiles.Length
            If pdfCount > 1 Then
                'Open the 1st item in the array PDFFiles
                fileName = pdfFiles(f)
                reader = New iTextSharp.text.pdf.PdfReader(fileName)
                'Get page count
                pageCount = reader.NumberOfPages

                pdfDoc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1), 18, 18, 18, 18)

                writer = PdfWriter.GetInstance(pdfDoc, New FileStream(outputPath, FileMode.OpenOrCreate))

                With pdfDoc
                    .Open()
                End With
                'Instantiate a PdfContentByte object
                cb = writer.DirectContent
                'Now loop thru the input pdfs
                While f < pdfCount
                    'Declare a page counter variable
                    Dim i As Integer = 0
                    'Loop thru the current input pdf's pages starting at page 1
                    While i < pageCount
                        i += 1
                        'Get the input page size
                        pdfDoc.SetPageSize(reader.GetPageSizeWithRotation(i))
                        'Create a new page on the output document
                        pdfDoc.NewPage()
                        'If it is the 1st page, we add bookmarks to the page
                        'Now we get the imported page
                        page = writer.GetImportedPage(reader, i)
                        'Read the imported page's rotation
                        rotation = reader.GetPageRotation(i)
                        'Then add the imported page to the PdfContentByte object as a template based on the page's rotation
                        If rotation = 90 Then
                            cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(i).Height)
                        ElseIf rotation = 270 Then
                            cb.AddTemplate(page, 0, 1.0F, -1.0F, 0, reader.GetPageSizeWithRotation(i).Width + 60, -30)
                        Else
                            cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0)
                        End If
                    End While
                    'Increment f and read the next input pdf file
                    f += 1
                    If f < pdfCount Then
                        fileName = pdfFiles(f)
                        reader = New iTextSharp.text.pdf.PdfReader(fileName)
                        pageCount = reader.NumberOfPages
                    End If
                End While
                'When all done, we close the document so that the pdfwriter object can write it to the output file
                pdfDoc.Close()
                result = True
            End If
            pdfDoc.Close()
        Catch ex As Exception
            pdfDoc.Close()
            Return False
        End Try
        pdfDoc.Close()
        Return result
    End Function

    Private Sub DeleteDirectory(ByVal path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
            'Delete all child Directories
            For Each dir As String In Directory.GetDirectories(path)
                DeleteDirectory(dir)
            Next
            'Delete a Directory
            Directory.Delete(path)
        End If
    End Sub

    Private Sub bgwk_RunReceipt(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Try
            Dim images As List(Of System.Drawing.Image) = CType(e.Argument, List(Of System.Drawing.Image))
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New System.IO.FileStream(dir3.FullName + "\" + ShipmentNumber.ToString + ".pdf", System.IO.FileMode.Create)).SetFullCompression()

            doc.Open()
            ''Adds images to the pdf
            For Each img As System.Drawing.Image In images
                Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
                iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
                doc.Add(iImage)
                doc.Add(New iTextSharp.text.Paragraph())
            Next
            doc.Close()

            e.Result = images
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwkAppendPDF_RunReceipt(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Try
            Dim images As List(Of System.Drawing.Image) = CType(e.Argument, List(Of System.Drawing.Image))
            ''Creates a memory stream for the document
            Using tempStream As New System.IO.MemoryStream()
                Dim copyDoc As New iTextSharp.text.Document()
                Dim copy As New iTextSharp.text.pdf.PdfCopy(copyDoc, tempStream)
                copyDoc.Open()
                Dim pageCounter As Integer = 0
                Dim reader As New iTextSharp.text.pdf.PdfReader(dir3.FullName + "\" + ShipmentNumber.ToString + ".pdf")

                ''Gets pages for the pdf document
                Dim numberOfPages As Integer = reader.NumberOfPages
                For currentPage As Integer = 1 To numberOfPages
                    pageCounter += 1
                    Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                    copy.AddPage(importedPage)
                Next
                copy.FreeReader(reader)
                reader.Close()

                System.IO.File.Delete(dir3.FullName + "\" + ShipmentNumber.ToString + ".pdf")
                ''Creates a document in memory of the newly scanned pages
                Dim imageStream As New System.IO.MemoryStream()
                Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, imageStream).SetFullCompression()
                doc.Open()

                ''Adds the image to the pdf page
                For Each img As System.Drawing.Image In images
                    Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
                    iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
                    doc.Add(iImage)
                    doc.Add(New iTextSharp.text.Paragraph())
                Next
                doc.Close()

                ''Merges the newly scanned image document into the current document
                reader = New iTextSharp.text.pdf.PdfReader(imageStream.GetBuffer())
                numberOfPages = reader.NumberOfPages

                For currentPage As Integer = 1 To numberOfPages
                    pageCounter += 1
                    Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                    copy.AddPage(importedPage)
                Next

                copy.FreeReader(reader)
                reader.Close()
                copyDoc.Close()
                imageStream.Close()
                imageStream.Dispose()

                Using fs As New System.IO.FileStream(dir3.FullName + "\" + PaymentBatchNumber.PaymentID + ".pdf", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                    fs.Write(tempStream.GetBuffer(), 0, tempStream.GetBuffer().Length)
                End Using
            End Using

            e.Result = images
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwk_CompletedReceipt(ByVal sender As System.Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim images As List(Of System.Drawing.Image) = CType(e.Result, List(Of System.Drawing.Image))
        Dim TotalPages As Integer = images.Count

        While images.Count > 0
            images(0).Dispose()
            images.RemoveAt(0)
        End While

        If FilesToDelete IsNot Nothing AndAlso FilesToDelete.Count > 0 Then
            For Each filename As String In FilesToDelete
                System.IO.File.Delete(filename)
            Next
        End If

        frm.Enabled = True
        LoadingScreen.Hide()

        MessageBox.Show("Cash Batch Uploaded With " + TotalPages.ToString + " pages.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub bgwkRemoteWIA_runReceipt(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Try
            remoteWIA.StartClient()
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwkRemoteWIA_ProgressReceipt(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        LoadingScreen.Show()
        Select Case e.ProgressPercentage
            Case 0
                LoadingScreen.Label1.Text = "Connecting to local system, please wait."
            Case 1
                LoadingScreen.Label1.Text = "Connected to local system, initializing scan."
            Case 2
                LoadingScreen.Label1.Text = "Attempting to scan, please wait."
            Case 3
                LoadingScreen.Label1.Text = "Waiting on file from local system."
            Case 4
                LoadingScreen.Label1.Text = "File received and being saved."
        End Select
    End Sub

    Private Sub bgwkRemoteWIA_CompletedReceipt(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        LoadingScreen.Close()
        Try
            If remoteWIA.SaveFile(dir3.FullName + "\" + PaymentBatchNumber.PaymentID + ".pdf") Then
                MessageBox.Show("Cash receipt uploaded with " + remoteWIA.PageCount() + " pages successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ErrorDescription = "Scan Error"
                ErrorReferenceNumber = ""

                'Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

                'With cmd.Parameters
                '.Add("@Date", SqlDbType.Date).Value = Today()
                '.Add("@Description", SqlDbType.VarChar).Value = ErrorDescription
                '.Add("@ErrorReference", SqlDbType.VarChar).Value = ErrorReferenceNumber
                '.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                '.Add("@Comment", SqlDbType.VarChar).Value = dir.FullName + "\" + ShipmentNumber.ToString() + ".pdf"
                '.Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
                'End With

                'If con.State = ConnectionState.Closed Then con.Open()
                'cmd.ExecuteNonQuery()
                'con.Close()
            End If

            frm.Enabled = True
            frm.TopMost = True
            frm.TopMost = False
        Catch exception As System.Exception
        End Try

        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
        'Sets buttons to see if pdf is viewable
    End Sub

    Private Sub bgwkRemoteWIA_CompletedAppendReceipt(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            LoadingScreen.Close()
            Dim name1, name2, final1 As String
            If remoteWIA.SaveFile(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf") Then
                MessageBox.Show("Cash receipt uploaded with " + remoteWIA.PageCount() + " pages successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                ErrorDescription = "Scan Error"
                ErrorReferenceNumber = ""

                'Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

                'With cmd.Parameters
                '.Add("@Date", SqlDbType.Date).Value = Today()
                '.Add("@Description", SqlDbType.VarChar).Value = ErrorDescription
                '.Add("@ErrorReference", SqlDbType.VarChar).Value = ErrorReferenceNumber
                '.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                '.Add("@Comment", SqlDbType.VarChar).Value = dir.FullName + "\" + ShipmentNumber.ToString() + ".pdf"
                '.Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
                'End With

                'If con.State = ConnectionState.Closed Then con.Open()
                'cmd.ExecuteNonQuery()
                'con.Close()
            End If
            Dim initial As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
            Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
            My.Computer.FileSystem.MoveFile(initial, final)

            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf") And File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf") Then

                final1 = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
                name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"
                Dim pathArray = New String() {name1, name2}

                MergePdfFiles(pathArray, final1)
            End If
            frm.Enabled = True
            frm.TopMost = True
            frm.TopMost = False
        Catch exception As System.Exception

        End Try
    End Sub

    Private Sub UploadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadToolStripMenuItem.Click
        Dim W9Exists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
        If File.Exists(W9Exists) Then
            Try
                Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")

            Catch ex As System.Exception
            End Try

            Dim MoveLocation As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND"
            Dim destinationPath As String = ""

            Dim fd As OpenFileDialog = New OpenFileDialog()
            Dim strFileName As String = ""

            fd.Title = "Open File Dialog"
            fd.InitialDirectory = "C:\"
            fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
            fd.FilterIndex = 2
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                strFileName = fd.FileName
            End If

            If File.Exists(strFileName) Then
                Dim filename As String = System.IO.Path.GetFileName(strFileName)
                destinationPath = System.IO.Path.Combine(MoveLocation, filename)
                If File.Exists(destinationPath) Then
                    File.Delete(destinationPath)
                End If
                File.Move(strFileName, destinationPath)
                Dim rename As String = "Appended2" + ".pdf"
                My.Computer.FileSystem.RenameFile(destinationPath, rename)
                Dim name1, name2, final1 As String
                Dim initial As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
                Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                My.Computer.FileSystem.MoveFile(initial, final)
                final1 = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
                name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"

                Dim pathArray = New String() {name1, name2}
                Try
                    MergePdfFiles(pathArray, final1)
                    MsgBox("File Appended")
                Catch ex As Exception
                    MsgBox("File Not Appended")
                End Try

                Try
                    For Each row As DataGridViewRow In dgvCustomerPayment.Rows
                        Dim pdfname2 As String = row.Cells("PaymentIDColumn").Value.ToString
                        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname2 + ".pdf"
                        Dim batchName As String = row.Cells("BatchNumberColumn").Value.ToString
                        Dim CashBatchExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + batchName + ".pdf"

                        If File.Exists(CashReceiptExists) Then
                            row.Cells("PaymentIDColumn").Style.BackColor = Color.LightGreen
                        Else
                            row.Cells("PaymentIDColumn").Style.BackColor = Color.LightCoral
                        End If
                        If File.Exists(CashBatchExists) Then
                            row.Cells("BatchNumberColumn").Style.BackColor = Color.LightGreen
                        Else
                            row.Cells("BatchNumberColumn").Style.BackColor = Color.LightCoral
                        End If
                    Next
                Catch ex As System.Exception
                End Try
            Else
                MsgBox("File Not Appended")
            End If
        Else
            MsgBox("Please use the Re-Upload function before using append. No initial file.")
        End If

        Dim pdfname As String = PaymentBatchNumber.PaymentID
        Dim CashReceiptExists2 As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname + ".pdf"
        If File.Exists(CashReceiptExists2) Then
            System.Diagnostics.Process.Start(CashReceiptExists2)
        Else
            MsgBox("File Upload Error, Please Try Again")
        End If
    End Sub

    Private Sub ScanToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanToolStripMenuItem1.Click
        ScanCashReceipt()
        Dim pdfname As String = PaymentBatchNumber.PaymentID
        Dim CashReceiptExists2 As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname + ".pdf"
        If File.Exists(CashReceiptExists2) Then
            System.Diagnostics.Process.Start(CashReceiptExists2)
        Else
            MsgBox("File Upload Error, Please Try Again")
        End If
        Dim paymentID As String = PaymentBatchNumber.PaymentID

        Dim bytecount As Integer = 0
        bytecount = FileLen("\\TFP-FS\CashReceipts\UploadedCashReceipts\" + paymentID + ".pdf")
        If bytecount = 15 Then
            My.Computer.FileSystem.DeleteFile("\\TFP-FS\CashReceipts\UploadedCashReceipts\" + paymentID + ".pdf")
            MsgBox("Scanning Error, Please Re-Upload File")
        End If
    End Sub

    Public Sub ScanCashReceipt(Optional ByVal newPDF As Boolean = True)
        remoteCheck = False

        Dim loadingScreen As New Loading
        loadingScreen.Text = "Cash Receipt Loading"
        loadingScreen.Label1.Text = "Loading Cash Receipt Data, Please Wait...."
        loadingScreen.Show()
        loadingScreen.BringToFront()
        ' Deletes the WIA testing temp file
        Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
        If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
        ' Creates the folder if the temp folder is not currently created
        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")

        path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
        'If there had been a previous scan then delete the picture from the picturebox
        GlobalVariables.Counter = 0
        Dim mgr As New WIA.DeviceManagerClass
        Dim Scanner As WIA.Device = Nothing
        If mgr.DeviceInfos.Count > 1 Then
            ''More than 1 scanner was detected
            Dim lst As New List(Of Integer)
            ''Finds all the USB scanners
            For i As Integer = 1 To mgr.DeviceInfos.Count()
                If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                    lst.Add(i)
                End If
            Next
            ''Check to see how many usb scanners were found
            If lst.Count > 1 Or lst.Count = 0 Then
                Dim selectScanner As New WIA.CommonDialog
                Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
            Else
                Scanner = mgr.DeviceInfos(lst(0)).Connect()
            End If
        ElseIf mgr.DeviceInfos.Count = 0 Then
            ''No scanners were detected
            If My.Computer.Name.ToString.StartsWith("TFP") Then

                bgwkRemoteWIA = New BackgroundWorker()
                bgwkRemoteWIA.WorkerReportsProgress = True
                AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_runReceipt
                AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_CompletedReceipt
                AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_ProgressReceipt
                remoteCheck = True

                remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, ShipmentNumber)
                bgwkRemoteWIA.RunWorkerAsync()
            Else
                ''No scanners were detected
                MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            ''Only 1 scanner is connected
            Scanner = mgr.DeviceInfos(1).Connect()
        End If
        If Scanner IsNot Nothing Then
            Dim item As WIA.Item = Scanner.Items(1)
            Dim obj As Object
            Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
            ''Specific scanning properties
            For Each prop As WIA.Property In Scanner.Items(1).Properties
                Dim x As WIA.IProperty = prop
                Select Case prop.PropertyID
                    Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                        obj = 0
                        x.let_Value(obj)
                    Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                        obj = 2
                        x.let_Value(obj)
                    Case "6147" ''(DPI) Horizontal Resolution
                        obj = 200
                        x.let_Value(obj)
                    Case "6148" ''(DPI) Vertical Resolution
                        obj = 200
                        x.let_Value(obj)
                    Case "6151" ''horizontal extent (width)
                        obj = 1700
                        x.let_Value(obj)
                    Case "6152" ''vertical extent (height)
                        obj = 2338
                        x.let_Value(obj)
                End Select
            Next

            Dim dial As New WIA.CommonDialog
            Dim hasMorePages As Boolean = True
            Dim ScannedAtleastOnePage As Boolean = False
            Dim pages As Integer = 0
            Dim ScannedImages As New List(Of iTextSharp.text.Image)

            ''Loops until all pages are scanned.
            While hasMorePages
                GlobalVariables.Counter = GlobalVariables.Counter + 1
                pages += 1
                Try
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                    Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                    Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                    Img.SaveFile(tmp)
                    'ScannedImages.Add(Img.fromfile(tmp))
                    ScannedAtleastOnePage = True


                Catch ex As System.Exception
                    ''Looks for paper empty error to break the loop and/or to show error message
                    If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                        If Not ScannedAtleastOnePage Then
                            MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            GlobalVariables.paperscan = False
                        Else
                            GlobalVariables.paperscan = True
                        End If
                        hasMorePages = False
                    End If
                End Try
            End While

            'Displays the first saved scan into the picturebox
            If GlobalVariables.paperscan Then
                GlobalVariables.StartCounter = 1
                Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                GlobalVariables.NextPrevious = GlobalVariables.StartCounter

            End If
        End If
        'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
        GlobalVariables.previousScan = True
        GlobalVariables.NextPrevious = 1


        Dim extensions As New List(Of String)
        extensions.Add("*.bmp")
        Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

        'counts the files in the folder
        Dim fileCount As Integer
        For i As Integer = 0 To extensions.Count - 1
            fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
        Next
        GlobalVariables.totalfiles = fileCount
        If remoteCheck = False Then
            Dim boolCheck As Boolean = True
            Dim FilesInFolder As Integer
            Dim FullName As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"
            FilesInFolder = Directory.GetFiles(FullName, "*.bmp").Count


            'Variables Declared
            Dim comboboxSelection As String = PaymentBatchNumber.PaymentID

            Dim strDir As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\"

            'Dim pdfDoc As New document()

            'Name of file
            Dim strFilename As String = PaymentBatchNumber.PaymentID + ".pdf"
            Dim pdfDoc As New document()
            Dim i As Integer = 1
            Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
            'path to bmp
            Dim strCompletePath As String = strDir & strFilename
            Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
            pdfDoc.Open()
            'Grabs the bmp image seen on screen
            Dim img As iTextSharp.text.Image = GetInstance(strPathname)
            'structures it to fit on pdf file
            img.ScalePercent(72.0F / img.DpiX * 100)
            img.SetAbsolutePosition(0, 0)
            'adds image to the document
            pdfDoc.Add(img)

            i += 1
            While i <= FilesInFolder
                pdfDoc.NewPage()
                strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
                'path to bmp
                strCompletePath = strDir & strFilename
                'Grabs the bmp image seen on screen
                img = GetInstance(strPathname)
                'structures it to fit on pdf file
                img.ScalePercent(72.0F / img.DpiX * 100)
                img.SetAbsolutePosition(0, 0)
                'adds image to the document
                pdfDoc.Add(img)
                i += 1
            End While
            pdfDoc.Close()
            loadingScreen.Close()
            For Each row As DataGridViewRow In dgvCustomerPayment.Rows

                Dim pdfname As String = row.Cells("PaymentIDColumn").Value.ToString
                Dim CashReceiptExistsx As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname + ".pdf"
                Dim batchName As String = row.Cells("BatchNumberColumn").Value.ToString
                Dim CashBatchExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + batchName + ".pdf"

                If File.Exists(CashReceiptExistsx) Then

                    row.Cells("PaymentIDColumn").Style.BackColor = Color.LightGreen

                Else
                    row.Cells("PaymentIDColumn").Style.BackColor = Color.LightCoral
                End If

                If File.Exists(CashBatchExists) Then

                    row.Cells("BatchNumberColumn").Style.BackColor = Color.LightGreen

                Else
                    row.Cells("BatchNumberColumn").Style.BackColor = Color.LightCoral
                End If
            Next
        End If
    End Sub

    Private Sub UploadToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadToolStripMenuItem1.Click
        Try
            Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
        Catch ex As System.Exception
        End Try

        Dim MoveLocation As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\"
        Dim destinationPath As String = ""

        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String = ""

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
        End If

        If File.Exists(strFileName) Then
            Dim filename As String = System.IO.Path.GetFileName(strFileName)
            destinationPath = System.IO.Path.Combine(MoveLocation, filename)
            If File.Exists(destinationPath) Then
                File.Delete(destinationPath)
            End If
            File.Move(strFileName, destinationPath)
            Dim rename As String = PaymentBatchNumber.PaymentID + ".pdf"
            My.Computer.FileSystem.RenameFile(destinationPath, rename)
            MsgBox("File Moved")
            Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + PaymentBatchNumber.PaymentID + ".pdf"
            'Sets buttons to see if pdf is viewable
            Try
                For Each row As DataGridViewRow In dgvCustomerPayment.Rows
                    Dim pdfname2 As String = row.Cells("PaymentIDColumn").Value.ToString
                    Dim CashReceiptExistsx As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname2 + ".pdf"
                    Dim batchName As String = row.Cells("BatchNumberColumn").Value.ToString
                    Dim CashBatchExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + batchName + ".pdf"

                    If File.Exists(CashReceiptExistsx) Then
                        row.Cells("PaymentIDColumn").Style.BackColor = Color.LightGreen
                    Else
                        row.Cells("PaymentIDColumn").Style.BackColor = Color.LightCoral
                    End If
                    If File.Exists(CashBatchExists) Then
                        row.Cells("BatchNumberColumn").Style.BackColor = Color.LightGreen
                    Else
                        row.Cells("BatchNumberColumn").Style.BackColor = Color.LightCoral
                    End If
                Next
            Catch ex As System.Exception
            End Try
        Else
            MsgBox("File Not move")
        End If

        Dim pdfname As String = PaymentBatchNumber.PaymentID
        Dim CashReceiptExists2 As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname + ".pdf"
        If File.Exists(CashReceiptExists2) Then
            System.Diagnostics.Process.Start(CashReceiptExists2)
        Else
            MsgBox("File Upload Error, Please Try Again")
        End If
    End Sub

    Private Sub AppendToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppendToolStripMenuItem2.Click
        Dim W9Exists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + PaymentBatchNumber.batchNumber + ".pdf"
        If File.Exists(W9Exists) Then
            Try
                Dim name1, name2, final1 As String
                Dim remoteScan As Boolean = False
                If File.Exists(W9Exists) Then

                    Dim loadingScreen As New Loading
                    loadingScreen.Text = "Payment Batch Loading"
                    loadingScreen.Label1.Text = "Loading Payment Batch Data, Please Wait...."
                    loadingScreen.Show()
                    loadingScreen.BringToFront()
                    ' Deletes the WIA testing temp file
                    Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing"
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                    ' Creates the folder if the temp folder is not currently created
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")


                    path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                    'If there had been a previous scan then delete the picture from the picturebox
                    GlobalVariables.Counter = 0
                    Dim mgr As New WIA.DeviceManagerClass
                    Dim Scanner As WIA.Device = Nothing
                    If mgr.DeviceInfos.Count > 1 Then
                        ''More than 1 scanner was detected
                        Dim lst As New List(Of Integer)
                        ''Finds all the USB scanners
                        For i As Integer = 1 To mgr.DeviceInfos.Count()
                            If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                                lst.Add(i)
                            End If
                        Next
                        ''Check to see how many usb scanners were found
                        If lst.Count > 1 Or lst.Count = 0 Then
                            Dim selectScanner As New WIA.CommonDialog
                            Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
                        Else
                            Scanner = mgr.DeviceInfos(lst(0)).Connect()
                        End If
                    ElseIf mgr.DeviceInfos.Count = 0 Then
                        ''No scanners were detected
                        If My.Computer.Name.ToString.StartsWith("TFP") Then


                            bgwkRemoteWIA = New BackgroundWorker()
                            bgwkRemoteWIA.WorkerReportsProgress = True
                            AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_run
                            AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_CompletedAppend
                            AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_Progress
                            remoteScan = True

                            remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, ShipmentNumber)
                            bgwkRemoteWIA.RunWorkerAsync()
                        Else
                            ''No scanners were detected
                            MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        ''Only 1 scanner is connected
                        Scanner = mgr.DeviceInfos(1).Connect()
                    End If

                    If Scanner IsNot Nothing Then
                        Dim item As WIA.Item = Scanner.Items(1)
                        Dim obj As Object
                        Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
                        ''Specific scanning properties
                        For Each prop As WIA.Property In Scanner.Items(1).Properties
                            Dim x As WIA.IProperty = prop
                            Select Case prop.PropertyID
                                Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                                    obj = 0
                                    x.let_Value(obj)
                                Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                                    obj = 2
                                    x.let_Value(obj)
                                Case "6147" ''(DPI) Horizontal Resolution
                                    obj = 200
                                    x.let_Value(obj)
                                Case "6148" ''(DPI) Vertical Resolution
                                    obj = 200
                                    x.let_Value(obj)
                                Case "6151" ''horizontal extent (width)
                                    obj = 1700
                                    x.let_Value(obj)
                                Case "6152" ''vertical extent (height)
                                    obj = 2338
                                    x.let_Value(obj)
                            End Select
                        Next

                        Dim dial As New WIA.CommonDialog
                        Dim hasMorePages As Boolean = True
                        Dim ScannedAtleastOnePage As Boolean = False
                        Dim pages As Integer = 0
                        Dim ScannedImages As New List(Of iTextSharp.text.Image)
                        If remoteScan = False Then
                            ''Loops until all pages are scanned.
                            While hasMorePages
                                GlobalVariables.Counter = GlobalVariables.Counter + 1
                                pages += 1
                                Try
                                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                                    Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                                    Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                                    Img.SaveFile(tmp)
                                    'ScannedImages.Add(Img.fromfile(tmp))
                                    ScannedAtleastOnePage = True
                                Catch ex As System.Exception
                                    ''Looks for paper empty error to break the loop and/or to show error message
                                    If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                                        If Not ScannedAtleastOnePage Then
                                            MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            GlobalVariables.paperscan = False
                                        Else
                                            GlobalVariables.paperscan = True
                                        End If
                                        hasMorePages = False
                                    End If
                                End Try
                            End While

                            'Displays the first saved scan into the picturebox
                            If GlobalVariables.paperscan Then
                                GlobalVariables.StartCounter = 1
                                Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                                GlobalVariables.NextPrevious = GlobalVariables.StartCounter
                            End If
                        End If

                        'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
                        GlobalVariables.previousScan = True
                        GlobalVariables.NextPrevious = 1
                    End If
                    Dim extensions As New List(Of String)
                    extensions.Add("*.bmp")
                    Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

                    'counts the files in the folder
                    Dim fileCount As Integer
                    For i As Integer = 0 To extensions.Count - 1
                        fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
                    Next
                    GlobalVariables.totalfiles = fileCount
                End If
                If remoteScan = False Then
                    Try
                        Dim strDir As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\"
                        If Not System.IO.Directory.Exists(strDir) Then System.IO.Directory.CreateDirectory(strDir)

                        'Name of file

                        Dim strFilename As String = "Appended2.pdf"
                        'path to bmp
                        Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                        Dim strCompletePath As String = strDir & strFilename
                        Dim pdfDoc As New document()
                        Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
                        pdfDoc.Open()
                        'Grabs the bmp image seen on screen
                        Dim img As iTextSharp.text.Image = GetInstance(strPathname)
                        'structures it to fit on pdf file
                        img.ScalePercent(72.0F / img.DpiX * 100)
                        img.SetAbsolutePosition(0, 0)
                        'adds image to the document
                        pdfDoc.Add(img)
                        'closes the pdf and saves it
                        pdfDoc.Close()

                        'messagebox confirmation on saving
                        MessageBox.Show("Save Confirmation", "Saved Cash Receipt PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        'declares list of bmp files to be counted
                        Dim extensions As New List(Of String)
                        extensions.Add("*.bmp")
                        Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

                        GlobalVariables.previousScan = True

                        LoadingScreen.Close()
                        Dim initial As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + PaymentBatchNumber.batchNumber + ".pdf"
                        Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                        My.Computer.FileSystem.MoveFile(initial, final)
                        final1 = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + PaymentBatchNumber.batchNumber + ".pdf"
                        name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                        name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"
                        Dim pathArray = New String() {name1, name2}
                        Try
                            MergePdfFiles(pathArray, final1)
                            MsgBox("File Appended")
                        Catch ex As Exception
                            MsgBox("File Not Appended")
                        End Try
                    Catch ex As TargetInvocationException
                        'We only catch this one, so you can catch other exception later on
                        'We get the inner exception because ex is not helpfull
                        Dim iEX = ex.InnerException
                    Catch ex As Exception

                    End Try

                    For Each row As DataGridViewRow In dgvCustomerPayment.Rows
                        Dim pdfname2 As String = row.Cells("PaymentIDColumn").Value.ToString
                        Dim CashReceiptExistsx As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname2 + ".pdf"
                        Dim batchName As String = row.Cells("BatchNumberColumn").Value.ToString
                        Dim CashBatchExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + batchName + ".pdf"

                        If File.Exists(CashReceiptExistsx) Then
                            row.Cells("PaymentIDColumn").Style.BackColor = Color.LightGreen
                        Else
                            row.Cells("PaymentIDColumn").Style.BackColor = Color.LightCoral
                        End If
                        If File.Exists(CashBatchExists) Then
                            row.Cells("BatchNumberColumn").Style.BackColor = Color.LightGreen
                        Else
                            row.Cells("BatchNumberColumn").Style.BackColor = Color.LightCoral
                        End If
                    Next
                Else
                    MsgBox("Please Use The Re-Upload Function First")
                End If
            Catch ex As System.Exception
            End Try
        Else
            MsgBox("Please use the Re-Upload function before using append. No initial file.")
        End If

        Dim pdfname As String = PaymentBatchNumber.batchNumber
        Dim CashReceiptExists2 As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + pdfname + ".pdf"
        If File.Exists(CashReceiptExists2) Then
            System.Diagnostics.Process.Start(CashReceiptExists2)
        Else
            MsgBox("File Upload Error, Please Try Again")
        End If
    End Sub

    Private Sub bgwkPDF_Completed(ByVal sender As System.Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim images As List(Of System.Drawing.Image) = CType(e.Result, List(Of System.Drawing.Image))
        Dim TotalPages As Integer = images.Count
        While images.Count > 0
            images(0).Dispose()
            images.RemoveAt(0)
        End While
        If FilesToDelete IsNot Nothing AndAlso FilesToDelete.Count > 0 Then
            For Each filename As String In FilesToDelete
                System.IO.File.Delete(filename)
            Next
        End If
        frm.Enabled = True
        LoadingScreen.Hide()

        MessageBox.Show(TotalPages.ToString + " pages have been scanned.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        frm.TopMost = True
        frm.TopMost = False
    End Sub

    Private Sub bgwk_Run(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Try
            Dim images As List(Of System.Drawing.Image) = CType(e.Argument, List(Of System.Drawing.Image))
            Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New System.IO.FileStream(dir2.FullName + "\" + ShipmentNumber.ToString + ".pdf", System.IO.FileMode.Create)).SetFullCompression()

            doc.Open()
            ''Adds images to the pdf
            For Each img As System.Drawing.Image In images
                Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
                iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
                doc.Add(iImage)
                doc.Add(New iTextSharp.text.Paragraph())
            Next
            doc.Close()

            e.Result = images
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwkAppendPDF_Run(ByVal sender As System.Object, ByVal e As DoWorkEventArgs)
        Try
            Dim images As List(Of System.Drawing.Image) = CType(e.Argument, List(Of System.Drawing.Image))
            ''Creates a memory stream for the document
            Using tempStream As New System.IO.MemoryStream()
                Dim copyDoc As New iTextSharp.text.Document()
                Dim copy As New iTextSharp.text.pdf.PdfCopy(copyDoc, tempStream)
                copyDoc.Open()
                Dim pageCounter As Integer = 0
                Dim reader As New iTextSharp.text.pdf.PdfReader(dir2.FullName + "\" + ShipmentNumber.ToString + ".pdf")

                ''Gets pages for the pdf document
                Dim numberOfPages As Integer = reader.NumberOfPages
                For currentPage As Integer = 1 To numberOfPages
                    pageCounter += 1
                    Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                    copy.AddPage(importedPage)
                Next
                copy.FreeReader(reader)
                reader.Close()

                System.IO.File.Delete(dir2.FullName + "\" + ShipmentNumber.ToString + ".pdf")
                ''Creates a document in memory of the newly scanned pages
                Dim imageStream As New System.IO.MemoryStream()
                Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER)
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, imageStream).SetFullCompression()
                doc.Open()

                ''Adds the image to the pdf page
                For Each img As System.Drawing.Image In images
                    Dim iImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(img, Imaging.ImageFormat.Jpeg)
                    iImage.ScaleToFit(iTextSharp.text.PageSize.LETTER)
                    doc.Add(iImage)
                    doc.Add(New iTextSharp.text.Paragraph())
                Next
                doc.Close()

                ''Merges the newly scanned image document into the current document
                reader = New iTextSharp.text.pdf.PdfReader(imageStream.GetBuffer())
                numberOfPages = reader.NumberOfPages

                For currentPage As Integer = 1 To numberOfPages
                    pageCounter += 1
                    Dim importedPage As iTextSharp.text.pdf.PdfImportedPage = copy.GetImportedPage(reader, currentPage)
                    copy.AddPage(importedPage)
                Next

                copy.FreeReader(reader)
                reader.Close()
                copyDoc.Close()
                imageStream.Close()
                imageStream.Dispose()

                Using fs As New System.IO.FileStream(dir2.FullName + "\" + PaymentBatchNumber.batchNumber + ".pdf", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                    fs.Write(tempStream.GetBuffer(), 0, tempStream.GetBuffer().Length)
                End Using
            End Using

            e.Result = images
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwk_Completed(ByVal sender As System.Object, ByVal e As RunWorkerCompletedEventArgs)
        Dim images As List(Of System.Drawing.Image) = CType(e.Result, List(Of System.Drawing.Image))
        Dim TotalPages As Integer = images.Count

        While images.Count > 0
            images(0).Dispose()
            images.RemoveAt(0)
        End While

        If FilesToDelete IsNot Nothing AndAlso FilesToDelete.Count > 0 Then
            For Each filename As String In FilesToDelete
                System.IO.File.Delete(filename)
            Next
        End If

        frm.Enabled = True
        LoadingScreen.Hide()

        MessageBox.Show("Cash Batch Uploaded With " + TotalPages.ToString + " pages.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub bgwkRemoteWIA_run(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Try
            remoteWIA.StartClient()

        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub bgwkRemoteWIA_Progress(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        LoadingScreen.Show()
        Select Case e.ProgressPercentage
            Case 0
                LoadingScreen.Label1.Text = "Connecting to local system, please wait."
            Case 1
                LoadingScreen.Label1.Text = "Connected to local system, initializing scan."
            Case 2
                LoadingScreen.Label1.Text = "Attempting to scan, please wait."
            Case 3
                LoadingScreen.Label1.Text = "Waiting on file from local system."
            Case 4
                LoadingScreen.Label1.Text = "File received and being saved."
        End Select
    End Sub

    Private Sub bgwkRemoteWIA_Completed(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            LoadingScreen.Close()
            If remoteWIA.SaveFile(dir2.FullName + "\" + PaymentBatchNumber.batchNumber + ".pdf") Then
                MessageBox.Show("Cash batch uploaded with " + remoteWIA.PageCount() + " pages successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ErrorDescription = "Scan Error"
                ErrorReferenceNumber = ""

                'Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

                'With cmd.Parameters
                '.Add("@Date", SqlDbType.Date).Value = Today()
                '.Add("@Description", SqlDbType.VarChar).Value = ErrorDescription
                '.Add("@ErrorReference", SqlDbType.VarChar).Value = ErrorReferenceNumber
                '.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                '.Add("@Comment", SqlDbType.VarChar).Value = dir.FullName + "\" + ShipmentNumber.ToString() + ".pdf"
                '.Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
                'End With

                'If con.State = ConnectionState.Closed Then con.Open()
                'cmd.ExecuteNonQuery()
                'con.Close()
            End If

            frm.Enabled = True
            frm.TopMost = True
            frm.TopMost = False
        Catch exception As System.Exception
            'Error Log
        End Try

        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + cboBatchNumber.Text + ".pdf"
    End Sub

    Private Sub bgwkRemoteWIA_CompletedAppend(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Try
            LoadingScreen.Close()
            Dim final1, name1, name2 As String
            If remoteWIA.SaveFile(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf") Then
                MessageBox.Show("Cash batch uploaded with " + remoteWIA.PageCount() + " pages successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                ErrorDescription = "Scan Error"
                ErrorReferenceNumber = ""

                'Dim cmd As New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision)VALUES(@Date, @Description, @ErrorReference, @UserID, @Comment, @Division);", con)

                'With cmd.Parameters
                '.Add("@Date", SqlDbType.Date).Value = Today()
                '.Add("@Description", SqlDbType.VarChar).Value = ErrorDescription
                '.Add("@ErrorReference", SqlDbType.VarChar).Value = ErrorReferenceNumber
                '.Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                '.Add("@Comment", SqlDbType.VarChar).Value = dir.FullName + "\" + ShipmentNumber.ToString() + ".pdf"
                '.Add("@Division", SqlDbType.VarChar).Value = EmployeeCompanyCode
                'End With

                'If con.State = ConnectionState.Closed Then con.Open()
                'cmd.ExecuteNonQuery()
                'con.Close()
            End If
            Dim initial As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + PaymentBatchNumber.batchNumber + ".pdf"
            Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
            My.Computer.FileSystem.MoveFile(initial, final)

            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf") And File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf") Then

                final1 = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + PaymentBatchNumber.batchNumber + ".pdf"
                name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"
                Dim pathArray = New String() {name1, name2}

                MergePdfFiles(pathArray, final1)
            End If
            frm.Enabled = True
            frm.TopMost = True
            frm.TopMost = False
        Catch exception As System.Exception

        End Try
    End Sub

    Private Sub ScanToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanToolStripMenuItem2.Click
        Dim W9Exists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + PaymentBatchNumber.batchNumber + ".pdf"
        If File.Exists(W9Exists) Then
            Dim name1, name2, final1 As String
            Try
                Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND")

            Catch ex As System.Exception
            End Try

            Dim MoveLocation As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND"
            Dim destinationPath As String = ""

            Dim fd As OpenFileDialog = New OpenFileDialog()
            Dim strFileName As String = ""

            fd.Title = "Open File Dialog"
            fd.InitialDirectory = "C:\"
            fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
            fd.FilterIndex = 2
            fd.RestoreDirectory = True

            If fd.ShowDialog() = DialogResult.OK Then
                strFileName = fd.FileName
            End If

            If File.Exists(strFileName) Then
                Dim filename As String = System.IO.Path.GetFileName(strFileName)
                destinationPath = System.IO.Path.Combine(MoveLocation, filename)
                If File.Exists(destinationPath) Then
                    File.Delete(destinationPath)
                End If
                File.Move(strFileName, destinationPath)
                Dim rename As String = "Appended2" + ".pdf"
                My.Computer.FileSystem.RenameFile(destinationPath, rename)
                Dim initial As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + PaymentBatchNumber.batchNumber + ".pdf"
                Dim final As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                My.Computer.FileSystem.MoveFile(initial, final)
                final1 = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + PaymentBatchNumber.batchNumber + ".pdf"
                name1 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended1.pdf"
                name2 = My.Computer.FileSystem.SpecialDirectories.Temp + "\APPEND\Appended2.pdf"
                Dim pathArray = New String() {name1, name2}

                Try
                    MergePdfFiles(pathArray, final1)
                    MsgBox("File Appended")

                    For Each row As DataGridViewRow In dgvCustomerPayment.Rows
                        Dim pdfname2 As String = row.Cells("PaymentIDColumn").Value.ToString
                        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname2 + ".pdf"
                        Dim batchName As String = row.Cells("BatchNumberColumn").Value.ToString
                        Dim CashBatchExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + batchName + ".pdf"

                        If File.Exists(CashReceiptExists) Then
                            row.Cells("PaymentIDColumn").Style.BackColor = Color.LightGreen
                        Else
                            row.Cells("PaymentIDColumn").Style.BackColor = Color.LightCoral
                        End If
                        If File.Exists(CashBatchExists) Then
                            row.Cells("BatchNumberColumn").Style.BackColor = Color.LightGreen
                        Else
                            row.Cells("BatchNumberColumn").Style.BackColor = Color.LightCoral
                        End If
                    Next
                Catch ex As Exception
                    MsgBox("File Not Appended")
                End Try
            Else
                MsgBox("File Not Appended")
            End If
        Else
            MsgBox("Please use the Re-Upload function before using append. No initial file.")
        End If

        Dim pdfname As String = PaymentBatchNumber.batchNumber
        Dim CashReceiptExists2 As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + pdfname + ".pdf"
        If File.Exists(CashReceiptExists2) Then
            System.Diagnostics.Process.Start(CashReceiptExists2)
        Else
            MsgBox("File Upload Error, Please Try Again")
        End If
    End Sub

    Private Sub ScanToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanToolStripMenuItem3.Click
        Dim remoteScan As Boolean = False

        Dim loadingScreen As New Loading
        loadingScreen.Text = "Payment Batch Loading"
        loadingScreen.Label1.Text = "Loading Payment Batch Data, Please Wait...."
        loadingScreen.Show()
        loadingScreen.BringToFront()
        ' Deletes the WIA testing temp file
        Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
        If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
        ' Creates the folder if the temp folder is not currently created
        If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")

        path = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
        'If there had been a previous scan then delete the picture from the picturebox
        GlobalVariables.Counter = 0
        Dim mgr As New WIA.DeviceManagerClass
        Dim Scanner As WIA.Device = Nothing
        If mgr.DeviceInfos.Count > 1 Then
            ''More than 1 scanner was detected
            Dim lst As New List(Of Integer)
            ''Finds all the USB scanners
            For i As Integer = 1 To mgr.DeviceInfos.Count()
                If mgr.DeviceInfos(i).Properties("6").Value.ToString.ToLower.Contains("usb") Then
                    lst.Add(i)
                End If
            Next
            ''Check to see how many usb scanners were found
            If lst.Count > 1 Or lst.Count = 0 Then
                Dim selectScanner As New WIA.CommonDialog
                Scanner = selectScanner.ShowSelectDevice(WIA.WiaDeviceType.ScannerDeviceType, True, False)
            Else
                Scanner = mgr.DeviceInfos(lst(0)).Connect()
            End If
        ElseIf mgr.DeviceInfos.Count = 0 Then
            ''No scanners were detected
            If My.Computer.Name.ToString.StartsWith("TFP") Then

                bgwkRemoteWIA = New BackgroundWorker()
                bgwkRemoteWIA.WorkerReportsProgress = True
                AddHandler bgwkRemoteWIA.DoWork, AddressOf bgwkRemoteWIA_run
                AddHandler bgwkRemoteWIA.RunWorkerCompleted, AddressOf bgwkRemoteWIA_Completed
                AddHandler bgwkRemoteWIA.ProgressChanged, AddressOf bgwkRemoteWIA_Progress
                remoteScan = True

                remoteWIA = New MOSRemoteWIA(bgwkRemoteWIA, ShipmentNumber)
                bgwkRemoteWIA.RunWorkerAsync()

            Else
                ''No scanners were detected
                MessageBox.Show("No scanners were detected.", "No scanners", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            ''Only 1 scanner is connected
            Scanner = mgr.DeviceInfos(1).Connect()
        End If

        If Scanner IsNot Nothing Then
            Dim item As WIA.Item = Scanner.Items(1)
            Dim obj As Object
            Scanner.Properties("3088").Value = 1 ''Document Handling Select: 0 = Flatbed, 1 = ADF, 2 = Flatbed
            ''Specific scanning properties
            For Each prop As WIA.Property In Scanner.Items(1).Properties
                Dim x As WIA.IProperty = prop
                Select Case prop.PropertyID
                    Case "6146" ''Current Intent No clue what this does, but it needs to be 0
                        obj = 0
                        x.let_Value(obj)
                    Case "4103" ''Data Type: 0 = Black and white, 2 = Grayscale,  3 = Color
                        obj = 2
                        x.let_Value(obj)
                    Case "6147" ''(DPI) Horizontal Resolution
                        obj = 200
                        x.let_Value(obj)
                    Case "6148" ''(DPI) Vertical Resolution
                        obj = 200
                        x.let_Value(obj)
                    Case "6151" ''horizontal extent (width)
                        obj = 1700
                        x.let_Value(obj)
                    Case "6152" ''vertical extent (height)
                        obj = 2338
                        x.let_Value(obj)
                End Select
            Next

            Dim dial As New WIA.CommonDialog
            Dim hasMorePages As Boolean = True
            Dim ScannedAtleastOnePage As Boolean = False
            Dim pages As Integer = 0
            Dim ScannedImages As New List(Of iTextSharp.text.Image)

            ''Loops until all pages are scanned.
            While hasMorePages
                GlobalVariables.Counter = GlobalVariables.Counter + 1
                pages += 1
                Try
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                    Dim tmp As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\" + pages.ToString + ".bmp"
                    Dim Img As WIA.ImageFile = dial.ShowTransfer(item, WIA.FormatID.wiaFormatBMP, False)
                    Img.SaveFile(tmp)
                    'ScannedImages.Add(Img.fromfile(tmp))
                    ScannedAtleastOnePage = True
                Catch ex As System.Exception
                    ''Looks for paper empty error to break the loop and/or to show error message
                    If ex.ToString.Contains(WIA_ERRORS.WIA_ERROR_PAPER_EMPTY.ToString) Then
                        If Not ScannedAtleastOnePage Then
                            MessageBox.Show("Load paper into the ADF", "Load ADF", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            GlobalVariables.paperscan = False
                        Else
                            GlobalVariables.paperscan = True
                        End If
                        hasMorePages = False
                    End If
                End Try
            End While
            If remoteScan = False Then
                'Displays the first saved scan into the picturebox
                If GlobalVariables.paperscan Then
                    GlobalVariables.StartCounter = 1
                    Dim pathname As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.StartCounter & ".bmp"
                    GlobalVariables.NextPrevious = GlobalVariables.StartCounter
                End If
            End If
        End If
        If remoteScan = False Then
            'If the scanning button has been used previously within the same session then the program has to go into the folder and delete it.
            GlobalVariables.previousScan = True
            GlobalVariables.NextPrevious = 1

            Dim extensions As New List(Of String)
            extensions.Add("*.bmp")
            Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

            'counts the files in the folder
            Dim fileCount As Integer
            For i As Integer = 0 To extensions.Count - 1
                fileCount += Directory.GetFiles(pathname2, extensions(i), SearchOption.AllDirectories).Length
            Next
            GlobalVariables.totalfiles = fileCount
        End If

        Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + PaymentBatchNumber.batchNumber + ".pdf"
        If remoteScan = False Then
            Try

                Dim boolCheck As Boolean = True
                Dim FilesInFolder As Integer
                Dim FullName As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"
                FilesInFolder = Directory.GetFiles(FullName, "*.bmp").Count

                'Variables Declared
                Dim comboboxSelection As String = PaymentBatchNumber.batchNumber

                Dim strDir As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\"

                'Dim pdfDoc As New document()

                'Name of file
                Dim strFilename As String = PaymentBatchNumber.batchNumber + ".pdf"
                Dim pdfDoc As New document()
                Dim i As Integer = 1
                Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
                'path to bmp
                Dim strCompletePath As String = strDir & strFilename
                Dim pdfwrite As PdfWriter = PdfWriter.GetInstance(pdfDoc, New FileStream(strCompletePath, FileMode.Create))
                pdfDoc.Open()
                'Grabs the bmp image seen on screen
                Dim img As iTextSharp.text.Image = GetInstance(strPathname)
                'structures it to fit on pdf file
                img.ScalePercent(72.0F / img.DpiX * 100)
                img.SetAbsolutePosition(0, 0)
                'adds image to the document
                pdfDoc.Add(img)

                i += 1
                While i <= FilesInFolder
                    pdfDoc.NewPage()
                    strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & i & ".bmp"
                    'path to bmp
                    strCompletePath = strDir & strFilename
                    'Grabs the bmp image seen on screen
                    img = GetInstance(strPathname)
                    'structures it to fit on pdf file
                    img.ScalePercent(72.0F / img.DpiX * 100)
                    img.SetAbsolutePosition(0, 0)
                    'adds image to the document
                    pdfDoc.Add(img)
                    i += 1
                End While
                pdfDoc.Close()
            Catch ex As TargetInvocationException
                'We only catch this one, so you can catch other exception later on
                'We get the inner exception because ex is not helpfull
                Dim iEX = ex.InnerException
            Catch ex As Exception

            End Try
        End If
        loadingScreen.Close()

        For Each row As DataGridViewRow In dgvCustomerPayment.Rows

            Dim pdfname2 As String = row.Cells("PaymentIDColumn").Value.ToString
            Dim CashReceiptExistsx As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname2 + ".pdf"
            Dim batchName As String = row.Cells("BatchNumberColumn").Value.ToString
            Dim CashBatchExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + batchName + ".pdf"

            If File.Exists(CashReceiptExistsx) Then
                row.Cells("PaymentIDColumn").Style.BackColor = Color.LightGreen
            Else
                row.Cells("PaymentIDColumn").Style.BackColor = Color.LightCoral
            End If
            If File.Exists(CashBatchExists) Then
                row.Cells("BatchNumberColumn").Style.BackColor = Color.LightGreen
            Else
                row.Cells("BatchNumberColumn").Style.BackColor = Color.LightCoral
            End If
        Next

        Dim pdfname As String = PaymentBatchNumber.batchNumber
        Dim CashReceiptExists2 As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + pdfname + ".pdf"
        If File.Exists(CashReceiptExists2) Then
            System.Diagnostics.Process.Start(CashReceiptExists2)
        Else
            MsgBox("File Upload Error, Please Try Again")
        End If

        Dim paymentID As String = PaymentBatchNumber.batchNumber

        Dim bytecount As Integer = 0
        bytecount = FileLen("\\TFP-FS\CashReceipts\UploadedCashReceipts\" + paymentID + ".pdf")
        If bytecount = 15 Then
            My.Computer.FileSystem.DeleteFile("\\TFP-FS\CashReceipts\UploadedCashReceipts\" + paymentID + ".pdf")
            MsgBox("Scanning Error, Please Re-Upload File")
        End If
    End Sub

    Private Sub UploadToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadToolStripMenuItem2.Click
        Try
            Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
        Catch ex As System.Exception
            'Error Log
        End Try

        Dim MoveLocation As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\"
        Dim destinationPath As String = ""

        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String = ""

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
        End If

        If File.Exists(strFileName) Then
            Dim filename As String = System.IO.Path.GetFileName(strFileName)
            destinationPath = System.IO.Path.Combine(MoveLocation, filename)
            If File.Exists(destinationPath) Then
                File.Delete(destinationPath)
            End If
            File.Move(strFileName, destinationPath)
            Dim rename As String = PaymentBatchNumber.batchNumber + ".pdf"
            My.Computer.FileSystem.RenameFile(destinationPath, rename)

            MsgBox("File Moved")

            Try
                For Each row As DataGridViewRow In dgvCustomerPayment.Rows
                    Dim pdfname2 As String = row.Cells("PaymentIDColumn").Value.ToString
                    Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname2 + ".pdf"
                    Dim batchName As String = row.Cells("BatchNumberColumn").Value.ToString
                    Dim CashBatchExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + batchName + ".pdf"

                    If File.Exists(CashReceiptExists) Then
                        row.Cells("PaymentIDColumn").Style.BackColor = Color.LightGreen
                    Else
                        row.Cells("PaymentIDColumn").Style.BackColor = Color.LightCoral
                    End If
                    If File.Exists(CashBatchExists) Then
                        row.Cells("BatchNumberColumn").Style.BackColor = Color.LightGreen
                    Else
                        row.Cells("BatchNumberColumn").Style.BackColor = Color.LightCoral
                    End If
                Next
            Catch ex As System.Exception

            End Try
        Else
            MsgBox("File Not moved")
        End If

        Dim pdfname As String = PaymentBatchNumber.batchNumber
        Dim CashReceiptExists2 As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + pdfname + ".pdf"
        If File.Exists(CashReceiptExists2) Then
            System.Diagnostics.Process.Start(CashReceiptExists2)
        Else
            MsgBox("File Upload Error, Please Try Again")
        End If
    End Sub

    Private Sub dgvCustomerPayment_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCustomerPayment.Sorted
        For Each row As DataGridViewRow In dgvCustomerPayment.Rows

            Dim pdfname As String = row.Cells("PaymentIDColumn").Value.ToString
            Dim CashReceiptExists As String = "\\TFP-FS\CashReceipts\UploadedCashReceipts\" + pdfname + ".pdf"
            Dim batchName As String = row.Cells("BatchNumberColumn").Value.ToString
            Dim CashBatchExists As String = "\\TFP-FS\CashReceipts\UploadedCashBatch\" + batchName + ".pdf"

            If File.Exists(CashReceiptExists) Then
                row.Cells("PaymentIDColumn").Style.BackColor = Color.LightGreen
            Else
                row.Cells("PaymentIDColumn").Style.BackColor = Color.LightCoral
            End If

            If File.Exists(CashBatchExists) Then
                row.Cells("BatchNumberColumn").Style.BackColor = Color.LightGreen
            Else
                row.Cells("BatchNumberColumn").Style.BackColor = Color.LightCoral
            End If
        Next
    End Sub
End Class

Public Class PaymentBatchNumber
    Public Shared batchNumber As String = ""
    Public Shared PaymentID As String = ""
End Class