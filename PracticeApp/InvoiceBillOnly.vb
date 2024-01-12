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
Public Class InvoiceBillOnly
    Inherits System.Windows.Forms.Form

    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer

    Dim FormName As String = "Invoice Bill Only"
    Dim ARGLAccount, FreightGLAccount, SalesTaxGLAccount, CustomerName, ItemClass, GLAdjustmentAccount, GLInventoryAccount, GLCOGSAccount, GLIssuesAccount, GLPurchasesAccount, GLReturnsAccount, GLSalesAccount, GLSalesOffsetAccount As String
    Dim BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, PaymentTerms As String
    Dim ThirdPartyInfo, FOB, ShippingMethod, SpecialInstructions, PurchProdLineID, VerifyItemID, CustomerID, CustomerPO, Comment, PRONumber, InvoiceStatus, ShipVia As String
    Dim HeaderExtendedCOS, FIFOExtendedAmount, FIFOCost, DiscountAmount, ExtendedAmount, LineSalesTax, Price, QuantityBilled, CustomerTaxRate, ProductTotal, BilledFreight, SalesTax, SalesTax2, SalesTax3, DiscountPercent, DiscountRate, InvoiceTotal As Double
    Dim MaxDate, LastLineNumber, NextLineNumber, InvoiceBatchNumber, LastBatchNumber, NextBatchNumber, NextTransactionNumber, LastTransactionNumber As Integer
    Dim BatchDate, InvoiceDate, ShipmentDate As Date
    Dim GSTRate, PSTRate, HSTRate, GSTTotal, PSTTotal, HSTTotal, HSTValue As Double
    Dim CheckPaymentTerms As Integer = 0

    'Variables used for the GL
    Dim COSGLAccount, RevenueGLAccount, DebitGLAccount, CreditGLAccount, PartDescription, PartNumber, CustomerClass As String
    Dim NextBillingNumber, ConsignmentBillingNumber, InvoiceLine, CountLineNumber As Integer
    Dim OldQuantityBilled, QuantityShipped, SUMCOS, InvoicePrice, LastPurchaseCost As Double

    'Variables used for line edits
    Dim GridLineNumber As Integer
    Dim LineQuantityBilled, LinePrice, LineSalesTax2, LineExtendedAmount As Double
    Dim LineComment2 As String

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
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Dim isloaded As Boolean = False
    Dim lastBatch As String = ""

    Private Sub InvoiceBillOnly_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Disable(Me)
        Me.CenterToScreen()

        'Form Login
        FormLoginRoutine()
        LoadCurrentDivision()

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ItemClass' table. You can move, or remove it, as needed.
        Me.ItemClassTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ItemClass)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)

        LoadCustomerClasses()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        'Convert date type to Canadian style for TFF
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LabelHST.Visible = True
            LabelPST.Visible = True
            LabelSalesTax.Text = "GST"
            txtSalesTax2.Visible = True
            txtSalesTax3.Visible = True
            chkTaxable.Visible = False
            txtLineSalesTax.Enabled = False
            txtLineSalesTax2.Enabled = False
            txtLineSalesTaxRate.Visible = False
            cboConsignmentWarehouse.Enabled = False
            chkAddHST.Visible = True
            chkAddPST.Visible = True
            txtHSTRate.Visible = False
            dgvInvoiceLines.Columns("SalesTaxColumn").Visible = False
        Else
            LabelHST.Visible = False
            LabelPST.Visible = False
            LabelSalesTax.Text = "Sales Tax"
            txtSalesTax2.Visible = False
            txtSalesTax3.Visible = False
            chkTaxable.Visible = True
            txtLineSalesTax.Enabled = False
            txtLineSalesTax2.Enabled = False
            txtLineSalesTaxRate.Visible = False
            chkAddHST.Visible = False
            chkAddPST.Visible = False
            txtHSTRate.Visible = False
            dgvInvoiceLines.Columns("SalesTaxColumn").Visible = True
        End If

        If cboDivisionID.Text.Equals("TWD") Then
            cboConsignmentWarehouse.Enabled = True
        Else
            cboConsignmentWarehouse.Enabled = False
        End If

        If EmployeeLoginName = "JBASSETTI" Then
            cboShipMethod.Text = "OTHER"
        End If

        txtExtendedAmount.Enabled = False

        ClearData()
        ClearDataInDatagrid()

        cmdGenerateNewInvoiceNumber.Focus()
        isLoaded = True
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

    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), &HF060, 1)
            Case &HFFFFFFFF
        End Select
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

    Public Sub FormLoginRoutine()
        'Define Variables
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()
        Dim strTodaysTime As String = ""
        strTodaysTime = Todaysdate.ToShortTimeString()

        'Update Database
        cmd = New SqlCommand("INSERT INTO UserFormLogin (UserID, FormName, DivisionID, LoginDate, LoginTime, LogoutDate, LogoutTime) values (@UserID, @FormName, @DivisionID, @LoginDate, @LoginTime, @LogoutDate, @LogoutTime)", con)

        With cmd.Parameters
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@FormName", SqlDbType.VarChar).Value = FormName
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@LoginDate", SqlDbType.VarChar).Value = strTodaysDate
            .Add("@LoginTime", SqlDbType.VarChar).Value = strTodaysTime
            .Add("@LogoutDate", SqlDbType.VarChar).Value = ""
            .Add("@LogoutTime", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub FormLogoutRoutine()
        'Define Variables
        Dim Todaysdate As Date = Now()
        Dim strTodaysDate As String = ""
        strTodaysDate = Todaysdate.ToShortDateString()
        Dim strTodaysTime As String = ""
        strTodaysTime = Todaysdate.ToShortTimeString()

        'Update Database
        cmd = New SqlCommand("INSERT INTO UserFormLogin (UserID, FormName, DivisionID, LoginDate, LoginTime, LogoutDate, LogoutTime) values (@UserID, @FormName, @DivisionID, @LoginDate, @LoginTime, @LogoutDate, @LogoutTime)", con)

        With cmd.Parameters
            .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
            .Add("@FormName", SqlDbType.VarChar).Value = FormName
            .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
            .Add("@LoginDate", SqlDbType.VarChar).Value = ""
            .Add("@LoginTime", SqlDbType.VarChar).Value = ""
            .Add("@LogoutDate", SqlDbType.VarChar).Value = strTodaysDate
            .Add("@LogoutTime", SqlDbType.VarChar).Value = strTodaysTime
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub ValidatePaymentTerms()
        If cboPaymentTerms.Text = "Prepaid" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "COD" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "NetDue" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "N30" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "CREDIT CARD" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "N60" And cboDivisionID.Text = "TFP" Then
            CheckPaymentTerms = 1
        ElseIf cboPaymentTerms.Text = "N60" And cboDivisionID.Text = "TWD" And cboCustomerID.Text = "DAVIDEISENMA" Then
            CheckPaymentTerms = 1
        Else
            CheckPaymentTerms = 0
        End If
    End Sub

    Private Sub CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvInvoiceLines.CellValueChanged
        If isLoaded Then
            If isSomeoneEditing() Then
                Exit Sub
            End If
            LockBatch()

            Dim LineQuantityBilled, PriceDifference, CurrentLineSalesTax, LineSalesTax, LineExtendedAmount, OldLineUnitPrice, LineUnitPrice, LineExtendedCOS, UnitCOS, NewLineExtendedCOS As Double
            Dim LineNumber As Integer
            Dim LineComment, LinePartNumber As String

            Dim currentRow As Integer = dgvInvoiceLines.CurrentCell.RowIndex
            Dim currentColumn As Integer = dgvInvoiceLines.CurrentCell.ColumnIndex

            'Retrieve line data from PO Table and write to Receipt Of Invoice Table
            If IsDBNull(dgvInvoiceLines.Rows(currentRow).Cells("PriceColumn").Value) Then
                LineUnitPrice = 0
            Else
                LineUnitPrice = dgvInvoiceLines.Rows(currentRow).Cells("PriceColumn").Value
            End If
            If IsDBNull(dgvInvoiceLines.Rows(currentRow).Cells("QuantityBilledColumn").Value) Then
                LineQuantityBilled = 0
            Else
                LineQuantityBilled = dgvInvoiceLines.Rows(currentRow).Cells("QuantityBilledColumn").Value
            End If
            If IsDBNull(dgvInvoiceLines.Rows(currentRow).Cells("InvoiceLineKeyColumn").Value) Then
                LineNumber = 1
            Else
                LineNumber = dgvInvoiceLines.Rows(currentRow).Cells("InvoiceLineKeyColumn").Value
            End If
            If IsDBNull(dgvInvoiceLines.Rows(currentRow).Cells("LineCommentColumn").Value) Then
                LineComment = ""
            Else
                LineComment = dgvInvoiceLines.Rows(currentRow).Cells("LineCommentColumn").Value
            End If
            If IsDBNull(dgvInvoiceLines.Rows(currentRow).Cells("ExtendedCOSColumn").Value) Then
                LineExtendedCOS = 0
            Else
                LineExtendedCOS = dgvInvoiceLines.Rows(currentRow).Cells("ExtendedCOSColumn").Value
            End If
            If IsDBNull(dgvInvoiceLines.Rows(currentRow).Cells("PartNumberColumn").Value) Then
                LinePartNumber = ""
            Else
                LinePartNumber = dgvInvoiceLines.Rows(currentRow).Cells("PartNumberColumn").Value
            End If
            If IsDBNull(dgvInvoiceLines.Rows(currentRow).Cells("SalesTaxColumn").Value) Then
                CurrentLineSalesTax = 0
            Else
                CurrentLineSalesTax = dgvInvoiceLines.Rows(currentRow).Cells("SalesTaxColumn").Value
            End If

            'Get Old quantity billed to determine new unit cost
            Dim OldQuantityBilledStatement As String = "SELECT QuantityBilled, Price FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
            Dim OldQuantityBilledCommand As New SqlCommand(OldQuantityBilledStatement, con)
            OldQuantityBilledCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            OldQuantityBilledCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = LineNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As SqlDataReader = OldQuantityBilledCommand.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                If IsDBNull(reader.GetValue(0)) Then
                    OldQuantityBilled = LineQuantityBilled
                Else
                    OldQuantityBilled = reader.GetValue(0)
                End If
                If IsDBNull(reader.GetValue(1)) Then
                    OldLineUnitPrice = 0
                Else
                    OldLineUnitPrice = reader.GetValue(1)
                End If
            Else
                OldQuantityBilled = LineQuantityBilled
                OldLineUnitPrice = 0
            End If

            reader.Close()
            con.Close()

            'Calculate line totals
            UnitCOS = LineExtendedCOS / OldQuantityBilled
            LineExtendedAmount = LineUnitPrice * LineQuantityBilled
            NewLineExtendedCOS = UnitCOS * LineQuantityBilled

            'Find difference in current and old price
            PriceDifference = LineUnitPrice - OldLineUnitPrice
            If PriceDifference < 0 Then PriceDifference = PriceDifference * -1

            'Command to update sales tax only if quantity or price is changed in the grid
            If PriceDifference < 0.01 And OldQuantityBilled = LineQuantityBilled Then
                LineSalesTax = CurrentLineSalesTax
            Else
                'Get sales tax rate to update sales tax in the datagrid
                If cboDivisionID.Text <> "TFF" And cboDivisionID.Text <> "TOR" And cboDivisionID.Text <> "ALB" Then
                    Dim CustomerTaxRateStatement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                    Dim CustomerTaxRateCommand As New SqlCommand(CustomerTaxRateStatement, con)
                    CustomerTaxRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                    CustomerTaxRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        CustomerTaxRate = CDbl(CustomerTaxRateCommand.ExecuteScalar)
                    Catch ex As Exception
                        CustomerTaxRate = 0
                    End Try
                    con.Close()

                    If CustomerTaxRate <> 0 Then
                        LineSalesTax = LineExtendedAmount * CustomerTaxRate
                    Else
                        LineSalesTax = 0
                    End If
                Else
                    LineSalesTax = 0
                End If
            End If

            'Round amounts
            LineExtendedAmount = Math.Round(LineExtendedAmount, 2)
            NewLineExtendedCOS = Math.Round(NewLineExtendedCOS, 2)
            ''will check to make sure the line comment is not larger than what the database can hold
            If LineComment.Length > 500 Then
                If MessageBox.Show("Line Comment is too large, truncation will occur. Do you wish to comtinue?", "Continue to Update Line", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                    Exit Sub
                End If
                LineComment = LineComment.Substring(0, 500)
            End If
            Try
                'UPDATE Invoice Extended Amount based on line changes
                cmd = New SqlCommand("UPDATE InvoiceLineTable SET Price = @Price, QuantityBilled = @QuantityBilled, SalesTax = @SalesTax, ExtendedAmount = @ExtendedAmount, LineComment = @LineComment, ExtendedCOS = @ExtendedCOS WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                With cmd.Parameters
                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = LineNumber
                    .Add("@Price", SqlDbType.VarChar).Value = LineUnitPrice
                    .Add("@QuantityBilled", SqlDbType.VarChar).Value = LineQuantityBilled
                    .Add("@SalesTax", SqlDbType.VarChar).Value = LineSalesTax
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                    .Add("@LineComment", SqlDbType.VarChar).Value = LineComment
                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = NewLineExtendedCOS
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Write to error log
                Dim TempInvoiceNumber As Integer = 0
                Dim strInvoiceNumber As String
                TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                strInvoiceNumber = CStr(TempInvoiceNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Invoice Bill Only --- Update Invoice Lines"
                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Calculate totals for Header Table
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                CalculateCanadianTotals()
            Else
                CalculateTotals()
            End If

            Try
                'Update Header Table
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET ProductTotal = @ProductTotal, BilledFreight = @BilledFreight, InvoiceTotal = @InvoiceTotal, SalesTax = @SalesTax, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3 WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@BilledFreight", SqlDbType.VarChar).Value = BilledFreight
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                    .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2
                    .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempInvoiceNumber As Integer = 0
                Dim strInvoiceNumber As String
                TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                strInvoiceNumber = CStr(TempInvoiceNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Bill Only --- UPDATE Header"
                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            isloaded = False
            Dim rw As Integer = dgvInvoiceLines.CurrentCell.RowIndex
            Dim cl As Integer = dgvInvoiceLines.CurrentCell.ColumnIndex

            ShowData()
            If dgvInvoiceLines.Rows.Count > rw Then
                dgvInvoiceLines.CurrentCell = dgvInvoiceLines.Rows(rw).Cells(cl)
            End If
            isloaded = True

            'Reload totals
            LoadInvoiceTotal()
        End If
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID ORDER BY InvoiceHeaderKey, InvoiceLineKey ASC", con)
        cmd.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "InvoiceLineTable")
        dgvInvoiceLines.DataSource = ds.Tables("InvoiceLineTable")
        cboLinePartDescription.DataSource = ds.Tables("InvoiceLineTable")
        cboLinePartNumber.DataSource = ds.Tables("InvoiceLineTable")
        cboInvoiceLineNumber.DataSource = ds.Tables("InvoiceLineTable")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvInvoiceLines.DataSource = Nothing
    End Sub

    Public Sub LoadCustomerID()
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass Order BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "CustomerList")
        cboCustomerID.DataSource = ds1.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerName()
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerName.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadPartNumber()
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND SalesProdLineID <> @SalesProdLineID AND ItemClass <> 'DEACTIVATED-PART' ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SUPPLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "ItemList")
        cboPartNumber.DataSource = ds3.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPartDescription()
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND SalesProdLineID <> @SalesProdLineID AND ItemClass <> 'DEACTIVATED-PART' ORDER BY ShortDescription", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@SalesProdLineID", SqlDbType.VarChar).Value = "SUPPLY"
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ItemList")
        cboPartDescription.DataSource = ds4.Tables("ItemList")
        con.Close()
        cboPartDescription.SelectedIndex = -1
    End Sub

    Private Sub LoadCustomerClasses()
        cmd = New SqlCommand("SELECT CustomerClassID FROM CustomerClass WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "CustomerClassID")
        cboCustomerClass.DataSource = ds4.Tables("CustomerClassID")
        con.Close()
        cboCustomerClass.SelectedIndex = -1
    End Sub

    Public Sub LoadInvoiceNumber()
        cmd = New SqlCommand("SELECT InvoiceNumber FROM InvoiceHeaderTable WHERE InvoiceStatus = @InvoiceStatus AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "BILL ONLY"
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "InvoiceHeaderTable")
        cboInvoiceNumber.DataSource = ds5.Tables("InvoiceHeaderTable")
        con.Close()
        cboInvoiceNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadFOB()
        cmd = New SqlCommand("SELECT FOBID FROM FOBTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "FOBTable")
        cboConsignmentWarehouse.DataSource = ds6.Tables("FOBTable")
        con.Close()
        cboConsignmentWarehouse.SelectedIndex = -1
    End Sub

    Public Sub LoadInvoiceTotal()
        Dim LoadInvoiceTotalsStatement As String = "SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim LoadInvoiceTotalsCommand As New SqlCommand(LoadInvoiceTotalsStatement, con)
        LoadInvoiceTotalsCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        LoadInvoiceTotalsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = LoadInvoiceTotalsCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ProductTotal")) Then
                ProductTotal = 0
            Else
                ProductTotal = reader.Item("ProductTotal")
            End If
            If IsDBNull(reader.Item("InvoiceTotal")) Then
                InvoiceTotal = 0
            Else
                InvoiceTotal = reader.Item("InvoiceTotal")
            End If
            If IsDBNull(reader.Item("BilledFreight")) Then
                BilledFreight = 0
            Else
                BilledFreight = reader.Item("BilledFreight")
            End If
            If IsDBNull(reader.Item("SalesTax")) Then
                SalesTax = 0
            Else
                SalesTax = reader.Item("SalesTax")
            End If
            If IsDBNull(reader.Item("SalesTax2")) Then
                SalesTax2 = 0
            Else
                SalesTax2 = reader.Item("SalesTax2")
            End If
            If IsDBNull(reader.Item("SalesTax3")) Then
                SalesTax3 = 0
            Else
                SalesTax3 = reader.Item("SalesTax3")
            End If
        Else
            ProductTotal = 0
            InvoiceTotal = 0
            BilledFreight = 0
            SalesTax = 0
            SalesTax2 = 0
            SalesTax3 = 0
        End If
        reader.Close()
        con.Close()

        If Val(txtSalesTax3.Text) <> 0 Then
            chkAddHST.Checked = True
        Else
            chkAddHST.Checked = False
        End If
        If Val(txtSalesTax2.Text) <> 0 Then
            chkAddPST.Checked = True
        Else
            chkAddPST.Checked = False
        End If

        txtBilledFreightEdit.Text = Math.Round(BilledFreight, 2)
        txtProductSales.Text = FormatCurrency(ProductTotal, 2)
        txtSalesTax.Text = FormatCurrency(SalesTax, 2)
        txtSalesTax2.Text = FormatCurrency(SalesTax2, 2)
        txtSalesTax3.Text = FormatCurrency(SalesTax3, 3)
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtFreightBilled.Text = FormatCurrency(BilledFreight, 2)
    End Sub

    Public Sub CalculateTotals()
        Dim SUMTotalsStatement As String = "SELECT SUM(SalesTax) as SumSalesTax, SUM(ExtendedAmount) as SumExtendedAmount, SUM(ExtendedCOS) as SumExtendedCOS FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
        Dim SUMTotalsCommand As New SqlCommand(SUMTotalsStatement, con)
        SUMTotalsCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SUMTotalsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = SUMTotalsCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("SumSalesTax")) Then
                SalesTax = 0
            Else
                SalesTax = reader.Item("SumSalesTax")
            End If
            If IsDBNull(reader.Item("SumExtendedAmount")) Then
                ProductTotal = 0
            Else
                ProductTotal = reader.Item("SumExtendedAmount")
            End If
            If IsDBNull(reader.Item("SumExtendedCOS")) Then
                HeaderExtendedCOS = 0
            Else
                HeaderExtendedCOS = reader.Item("SumExtendedCOS")
            End If
        Else
            SalesTax = 0
            ProductTotal = 0
            HeaderExtendedCOS = 0
        End If
        reader.Close()
        con.Close()

        SalesTax2 = 0
        SalesTax3 = 0

        BilledFreight = Val(txtBilledFreightEdit.Text)
        InvoiceTotal = SalesTax + ProductTotal + BilledFreight
        txtProductSales.Text = FormatCurrency(ProductTotal, 2)
        txtSalesTax.Text = FormatCurrency(SalesTax, 2)
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        txtFreightBilled.Text = FormatCurrency(BilledFreight, 2)
    End Sub

    Public Sub CalculateCanadianTotals()
        Dim SUMExtendedStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
        Dim SUMExtendedCommand As New SqlCommand(SUMExtendedStatement, con)
        SUMExtendedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        SUMExtendedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ProductTotal = CDbl(SUMExtendedCommand.ExecuteScalar)
        Catch ex As Exception
            ProductTotal = 0
        End Try
        con.Close()

        BilledFreight = Val(txtBilledFreightEdit.Text)

        GSTRate = 0.05
        PSTRate = 0.07

        HSTRate = Val(txtHSTRate.Text)

        If chkAddHST.Checked = True Then
            GSTTotal = 0
            PSTTotal = 0
            HSTTotal = HSTRate * (ProductTotal + BilledFreight)

            SalesTax = GSTTotal
            SalesTax2 = PSTTotal
            SalesTax3 = HSTTotal
        ElseIf chkAddPST.Checked = True Then
            GSTTotal = GSTRate * (ProductTotal + BilledFreight)
            PSTTotal = PSTRate * (ProductTotal + BilledFreight)
            HSTTotal = 0

            SalesTax = GSTTotal
            SalesTax2 = PSTTotal
            SalesTax3 = HSTTotal
        Else
            GSTTotal = GSTRate * (ProductTotal + BilledFreight)
            PSTTotal = 0
            HSTTotal = 0

            SalesTax = GSTTotal
            SalesTax2 = PSTTotal
            SalesTax3 = HSTTotal
        End If

        InvoiceTotal = BilledFreight + GSTTotal + PSTTotal + HSTTotal + ProductTotal

        txtSalesTax.Text = FormatCurrency(GSTTotal, 2)
        txtSalesTax2.Text = FormatCurrency(PSTTotal, 2)
        txtSalesTax3.Text = FormatCurrency(HSTTotal, 2)
        txtFreightBilled.Text = FormatCurrency(BilledFreight, 2)
        txtProductSales.Text = FormatCurrency(ProductTotal, 2)
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
    End Sub

    Public Sub LoadCanadianTaxRates()
        chkAddHST.Checked = False
        chkAddPST.Checked = False

        Dim GETTaxRatesStatement As String = "SELECT SalesTaxRate, SalesTaxRate2, SalesTaxRate3 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GETTaxRatesCommand As New SqlCommand(GETTaxRatesStatement, con)
        GETTaxRatesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        GETTaxRatesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GETTaxRatesCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("SalesTaxRate")) Then
                GSTRate = 0
            Else
                GSTRate = reader.Item("SalesTaxRate")
            End If
            If IsDBNull(reader.Item("SalesTaxRate2")) Then
                PSTRate = 0
            Else
                PSTRate = reader.Item("SalesTaxRate2")
            End If
            If IsDBNull(reader.Item("SalesTaxRate3")) Then
                HSTRate = 0
            Else
                HSTRate = reader.Item("SalesTaxRate3")
            End If
        Else
            GSTRate = 0
            PSTRate = 0
            HSTRate = 0
        End If
        reader.Close()
        con.Close()

        If PSTRate > 0 Then chkAddPST.Checked = True
        If HSTRate > 0 Then chkAddHST.Checked = True
    End Sub

    Private Sub cmdRemoveSalesTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveSalesTax.Click
        If isSomeoneEditing() Then
            Exit Sub
        End If

        Dim button As DialogResult = MessageBox.Show("Do you wish to remove Sales Tax from this invoice?", "REMOVE TAX", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            Dim SumInvoiceLines, SumFreight, SumInvoiceTotal As Double
            Try
                'Load Product Total and Freight to re-calc Quote Total
                Dim SUMStatement1 As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
                Dim SUMCommand1 As New SqlCommand(SUMStatement1, con)
                SUMCommand1.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                SUMCommand1.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                Dim SELStatement3 As String = "SELECT BilledFreight FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
                Dim SELCommand3 As New SqlCommand(SELStatement3, con)
                SELCommand3.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                SELCommand3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    SumInvoiceLines = CDbl(SUMCommand1.ExecuteScalar)
                Catch ex As Exception
                    SumInvoiceLines = 0
                End Try
                Try
                    SumFreight = CDbl(SELCommand3.ExecuteScalar)
                Catch ex As Exception
                    SumFreight = Val(txtBilledFreightEdit.Text)
                End Try
                con.Close()

                SumInvoiceTotal = SumInvoiceLines + SumFreight
                '************************************************************************************************
                'Write Data to Invoice Header Database Table (One Time)
                Try
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET SalesTax = @SalesTax, ProductTotal = @ProductTotal, InvoiceTotal = @InvoiceTotal, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3 WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = SumInvoiceLines
                        .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                        .Add("@SalesTax2", SqlDbType.VarChar).Value = 0
                        .Add("@SalesTax3", SqlDbType.VarChar).Value = 0
                        .Add("@InvoiceTotal", SqlDbType.VarChar).Value = SumInvoiceTotal
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Bill Only --- Remove Tax"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '************************************************************************************************
                'Write Data to Invoice Line Database Table 
                Try
                    cmd = New SqlCommand("UPDATE InvoiceLineTable SET SalesTax = @SalesTax WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Bill Only --- UPDATE Invoice Line Table"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '************************************************************************************************
                'Refresh datagrid
                ShowData()

                'Clear tax fields and update total
                chkTaxable.Checked = False
                chkAddHST.Checked = False
                chkAddPST.Checked = False
                chkRemoveAllTaxes.Checked = True

                txtSalesTax.Text = FormatCurrency(0, 2)
                txtSalesTax2.Text = FormatCurrency(0, 2)
                txtSalesTax3.Text = FormatCurrency(0, 2)

                txtInvoiceTotal.Text = FormatCurrency(SumInvoiceTotal, 2)

                txtHSTRate.Text = FormatCurrency(0, 2)
                txtHSTRate.Visible = False
                txtLineSalesTaxRate.Visible = False

                MsgBox("Sales Tax has been removed.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                MsgBox("There is an error - sales tax not removed.", MsgBoxStyle.OkOnly)
            End Try
        ElseIf button = DialogResult.No Then
            cmdRemoveSalesTax.Focus()
        End If
    End Sub

    Public Sub LoadLineDetails()
        Dim GETLineDetailsStatement As String = "SELECT * FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID AND InvoiceLineKey = @InvoiceLineKey"
        Dim GETLineDetailsCommand As New SqlCommand(GETLineDetailsStatement, con)
        GETLineDetailsCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        GETLineDetailsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GETLineDetailsCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = Val(cboInvoiceLineNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GETLineDetailsCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("QuantityBilled")) Then
                LineQuantityBilled = 0
            Else
                LineQuantityBilled = reader.Item("QuantityBilled")
            End If
            If IsDBNull(reader.Item("Price")) Then
                LinePrice = 0
            Else
                LinePrice = reader.Item("Price")
            End If
            If IsDBNull(reader.Item("SalesTax")) Then
                LineSalesTax = 0
            Else
                LineSalesTax = reader.Item("SalesTax")
            End If
            If IsDBNull(reader.Item("LineComment")) Then
                LineComment2 = ""
            Else
                LineComment2 = reader.Item("LineComment")
            End If
        Else
            LineQuantityBilled = 0
            LinePrice = 0
            LineSalesTax2 = 0
            LineComment2 = ""
        End If
        reader.Close()
        con.Close()

        isloaded = False
        txtLineComment2.Text = LineComment2
        txtLinePrice.Text = LinePrice
        txtLineQuantityBilled.Text = LineQuantityBilled
        LineExtendedAmount = Math.Round(LineQuantityBilled * LinePrice, 2)
        txtLineSalesTax2.Text = LineSalesTax2
        txtLineExtendedAmount.Text = LineExtendedAmount
        isLoaded = True
    End Sub

    Public Sub LoadStatus()
        Dim InvoiceStatusStatement As String = "SELECT InvoiceStatus FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber"
        Dim InvoiceStatusCommand As New SqlCommand(InvoiceStatusStatement, con)
        InvoiceStatusCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            InvoiceStatus = CStr(InvoiceStatusCommand.ExecuteScalar)
        Catch ex As Exception
            InvoiceStatus = "BILL ONLY"
        End Try
        con.Close()

        If InvoiceStatus = "CLOSED" Then
            cmdAddDiscount.Enabled = False
            cmdDelete.Enabled = False
            cmdDeleteDiscount.Enabled = False
            cmdSave.Enabled = False
            SaveInvoiceToolStripMenuItem.Enabled = False
            DeleteInvoiceToolStripMenuItem.Enabled = False
        Else
            cmdAddDiscount.Enabled = True
            cmdDelete.Enabled = True
            cmdDeleteDiscount.Enabled = True
            cmdSave.Enabled = True
            SaveInvoiceToolStripMenuItem.Enabled = True
            DeleteInvoiceToolStripMenuItem.Enabled = True
        End If
    End Sub

    Public Sub ClearData()
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboInvoiceNumber.Text = ""
        cboInvoiceLineNumber.Text = ""
        cboLinePartDescription.Text = ""
        cboLinePartNumber.Text = ""
        cboShipMethod.Text = ""
        cboConsignmentWarehouse.Text = ""
        cboCustomerClass.Text = ""

        cboBTState.Refresh()
        cboCustomerID.Refresh()
        cboCustomerName.Refresh()
        cboInvoiceNumber.Refresh()
        cboItemClass.Refresh()
        cboPartNumber.Refresh()
        cboPartDescription.Refresh()
        cboPaymentTerms.Refresh()
        cboShipVia.Refresh()
        cboConsignmentWarehouse.Refresh()
        cboLinePartDescription.Refresh()
        cboLinePartNumber.Refresh()
        cboInvoiceLineNumber.Refresh()
        cboCustomerClass.Refresh()

        txtBilledFreightEdit.Refresh()
        txtBTAddress1.Refresh()
        txtBTAddress2.Refresh()
        txtBTCity.Refresh()
        txtBTCountry.Refresh()
        txtBTZip.Refresh()
        txtComment.Refresh()
        txtCustomerPONumber.Refresh()
        txtDiscount.Refresh()
        txtDiscountAmount.Refresh()
        txtExtendedAmount.Refresh()
        txtFreightBilled.Refresh()
        txtGLAdjustmentAccount.Refresh()
        txtGLCOGSAccount.Refresh()
        txtGLInventoryAccount.Refresh()
        txtGLIssuesAccount.Refresh()
        txtGLPurchasesAccount.Refresh()
        txtGLReturnsAccount.Refresh()
        txtGLSalesAccount.Refresh()
        txtGLSalesOffsetAccount.Refresh()
        txtInvoiceTotal.Refresh()
        txtLineComment.Refresh()
        txtLineSalesTax.Refresh()
        txtPrice.Refresh()
        txtProductSales.Refresh()
        txtProNumber.Refresh()
        txtQuantityBilled.Refresh()
        txtSalesTax.Refresh()
        txtStatus.Refresh()
        txtBatchNumber.Refresh()
        txtLineComment2.Refresh()
        txtLineExtendedAmount.Refresh()
        txtLinePrice.Refresh()
        txtLineQuantityBilled.Refresh()
        txtLineSalesTax2.Refresh()
        txtHSTRate.Refresh()

        cboBTState.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboInvoiceNumber.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPaymentTerms.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboConsignmentWarehouse.SelectedIndex = -1
        cboLinePartDescription.SelectedIndex = -1
        cboLinePartNumber.SelectedIndex = -1
        cboInvoiceLineNumber.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1
        cboCustomerClass.SelectedIndex = -1

        dtpInvoiceDate.Text = ""
        dtpShipDate.Text = ""

        txtBilledFreightEdit.Clear()
        txtBTAddress1.Clear()
        txtBTAddress2.Clear()
        txtBTCity.Clear()
        txtBTCountry.Clear()
        txtBTZip.Clear()
        txtComment.Clear()
        txtCustomerPONumber.Clear()
        txtDiscount.Clear()
        txtDiscountAmount.Clear()
        txtExtendedAmount.Clear()
        txtFreightBilled.Clear()
        txtBilledFreightEdit.Clear()
        txtGLAdjustmentAccount.Clear()
        txtGLCOGSAccount.Clear()
        txtGLInventoryAccount.Clear()
        txtGLIssuesAccount.Clear()
        txtGLPurchasesAccount.Clear()
        txtGLReturnsAccount.Clear()
        txtGLSalesAccount.Clear()
        txtGLSalesOffsetAccount.Clear()
        txtInvoiceTotal.Clear()
        txtLineComment.Clear()
        txtLineSalesTax.Clear()
        txtPrice.Clear()
        txtProductSales.Clear()
        txtProNumber.Clear()
        txtQuantityBilled.Clear()
        txtSalesTax.Clear()
        txtStatus.Clear()
        txtBatchNumber.Clear()
        txtLineComment2.Clear()
        txtLineExtendedAmount.Clear()
        txtLinePrice.Clear()
        txtLineQuantityBilled.Clear()
        txtLineSalesTax2.Clear()
        txtHSTRate.Clear()
        txtSpecialInstructions.Clear()
        txtThirdParty.Clear()

        If EmployeeLoginName = "JBASSETTI" Then
            cboShipMethod.Text = "OTHER"
        End If

        chkAddHST.Checked = False
        chkAddPST.Checked = False
        chkTaxable.Checked = False
        txtHSTRate.Visible = False

        txtSalesTax2.Clear()
        txtSalesTax3.Clear()
        txtSalesTax.Clear()
        txtInvoiceTotal.Clear()

        cmdGenerateNewInvoiceNumber.Focus()
    End Sub

    Public Sub ClearLines()
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        txtLineComment.Clear()
        txtLineSalesTax.Clear()
        txtQuantityBilled.Clear()
        txtPrice.Clear()
        txtExtendedAmount.Clear()
        cboPartNumber.Focus()
    End Sub

    Public Sub ClearVariables()
        ShippingMethod = ""
        ThirdPartyInfo = ""
        SpecialInstructions = ""
        CheckPaymentTerms = 0
        CustomerName = ""
        CustomerID = ""
        ItemClass = ""
        GLAdjustmentAccount = ""
        GLInventoryAccount = ""
        GLCOGSAccount = ""
        GLIssuesAccount = ""
        GLPurchasesAccount = ""
        GLReturnsAccount = ""
        GLSalesAccount = ""
        GLSalesOffsetAccount = ""
        BTAddress1 = ""
        BTAddress2 = ""
        BTCity = ""
        BTState = ""
        BTZip = ""
        BTCountry = ""
        PaymentTerms = ""
        CustomerID = ""
        CustomerPO = ""
        Comment = ""
        PRONumber = ""
        InvoiceStatus = ""
        ShipVia = ""
        HeaderExtendedCOS = 0
        FIFOExtendedAmount = 0
        FIFOCost = 0
        DiscountAmount = 0
        ExtendedAmount = 0
        LineSalesTax = 0
        Price = 0
        QuantityBilled = 0
        CustomerTaxRate = 0
        ProductTotal = 0
        BilledFreight = 0
        SalesTax = 0
        DiscountPercent = 0
        DiscountRate = 0
        InvoiceTotal = 0
        LastLineNumber = 0
        NextLineNumber = 0
        InvoiceBatchNumber = 0
        LastBatchNumber = 0
        NextBatchNumber = 0
        NextTransactionNumber = 0
        LastTransactionNumber = 0
        COSGLAccount = ""
        RevenueGLAccount = ""
        DebitGLAccount = ""
        CreditGLAccount = ""
        PartDescription = ""
        PartNumber = ""
        CustomerClass = ""
        QuantityShipped = 0
        NextBillingNumber = 0
        ConsignmentBillingNumber = 0
        InvoiceLine = 0
        CountLineNumber = 0
        SUMCOS = 0
        InvoicePrice = 0
        OldQuantityBilled = 0
        PurchProdLineID = ""
        GSTRate = 0
        PSTRate = 0
        HSTRate = 0
        GSTTotal = 0
        PSTTotal = 0
        HSTTotal = 0
        SalesTax2 = 0
        SalesTax3 = 0
        FreightGLAccount = ""
        SalesTaxGLAccount = ""
        ARGLAccount = ""
        FOB = "Standard"
    End Sub

    Public Sub ClearLinesOnInvoiceNumberChange()
        cboCustomerID.Text = ""
        cboCustomerName.Text = ""
        cboInvoiceLineNumber.Text = ""
        cboLinePartDescription.Text = ""
        cboLinePartNumber.Text = ""

        cboBTState.Refresh()
        cboCustomerID.Refresh()
        cboCustomerName.Refresh()
        cboItemClass.Refresh()
        cboPartNumber.Refresh()
        cboPartDescription.Refresh()
        cboPaymentTerms.Refresh()
        cboShipVia.Refresh()
        cboConsignmentWarehouse.Refresh()
        cboLinePartDescription.Refresh()
        cboLinePartNumber.Refresh()
        cboInvoiceLineNumber.Refresh()

        txtBilledFreightEdit.Refresh()
        txtBTAddress1.Refresh()
        txtBTAddress2.Refresh()
        txtBTCity.Refresh()
        txtBTCountry.Refresh()
        txtBTZip.Refresh()
        txtComment.Refresh()
        txtCustomerPONumber.Refresh()
        txtDiscount.Refresh()
        txtDiscountAmount.Refresh()
        txtExtendedAmount.Refresh()
        txtFreightBilled.Refresh()
        txtGLAdjustmentAccount.Refresh()
        txtGLCOGSAccount.Refresh()
        txtGLInventoryAccount.Refresh()
        txtGLIssuesAccount.Refresh()
        txtGLPurchasesAccount.Refresh()
        txtGLReturnsAccount.Refresh()
        txtGLSalesAccount.Refresh()
        txtGLSalesOffsetAccount.Refresh()
        txtInvoiceTotal.Refresh()
        txtLineComment.Refresh()
        txtLineSalesTax.Refresh()
        txtPrice.Refresh()
        txtProductSales.Refresh()
        txtProNumber.Refresh()
        txtQuantityBilled.Refresh()
        txtSalesTax.Refresh()
        txtStatus.Refresh()
        txtBatchNumber.Refresh()
        txtLineComment2.Refresh()
        txtLineExtendedAmount.Refresh()
        txtLinePrice.Refresh()
        txtLineQuantityBilled.Refresh()
        txtLineSalesTax2.Refresh()
        txtHSTRate.Refresh()

        cboBTState.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboItemClass.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPaymentTerms.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboConsignmentWarehouse.SelectedIndex = -1
        cboLinePartDescription.SelectedIndex = -1
        cboLinePartNumber.SelectedIndex = -1
        cboInvoiceLineNumber.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1
        cboCustomerClass.SelectedIndex = -1

        dtpInvoiceDate.Text = ""
        dtpShipDate.Text = ""

        txtBilledFreightEdit.Clear()
        txtBTAddress1.Clear()
        txtBTAddress2.Clear()
        txtBTCity.Clear()
        txtBTCountry.Clear()
        txtBTZip.Clear()
        txtComment.Clear()
        txtCustomerPONumber.Clear()
        txtDiscount.Clear()
        txtDiscountAmount.Clear()
        txtExtendedAmount.Clear()
        txtFreightBilled.Clear()
        txtBilledFreightEdit.Clear()
        txtGLAdjustmentAccount.Clear()
        txtGLCOGSAccount.Clear()
        txtGLInventoryAccount.Clear()
        txtGLIssuesAccount.Clear()
        txtGLPurchasesAccount.Clear()
        txtGLReturnsAccount.Clear()
        txtGLSalesAccount.Clear()
        txtGLSalesOffsetAccount.Clear()
        txtInvoiceTotal.Clear()
        txtLineComment.Clear()
        txtLineSalesTax.Clear()
        txtPrice.Clear()
        txtProductSales.Clear()
        txtProNumber.Clear()
        txtQuantityBilled.Clear()
        txtSalesTax.Clear()
        txtStatus.Clear()
        txtBatchNumber.Clear()
        txtLineComment2.Clear()
        txtLineExtendedAmount.Clear()
        txtLinePrice.Clear()
        txtLineQuantityBilled.Clear()
        txtLineSalesTax2.Clear()
        txtHSTRate.Clear()
        txtThirdParty.Clear()

        chkAddHST.Checked = False
        chkAddPST.Checked = False
        chkTaxable.Checked = False

        txtSalesTax2.Clear()
        txtSalesTax3.Clear()
        txtSalesTax.Clear()
        txtInvoiceTotal.Clear()

        lastBatch = ""
    End Sub

    Public Sub LoadItemClassForPartNumber()
        Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
        ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ItemClass = CStr(ItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            ItemClass = ""
        End Try
        con.Close()

        cboItemClass.Text = ItemClass
    End Sub

    Public Sub LoadCustomerData()
        Dim GETBillToStatement As String = "SELECT * FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GETBillToCommand As New SqlCommand(GETBillToStatement, con)
        GETBillToCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        GETBillToCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GETBillToCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("BillToAddress1")) Then
                BTAddress1 = ""
            Else
                BTAddress1 = reader.Item("BillToAddress1")
            End If
            If IsDBNull(reader.Item("BillToAddress2")) Then
                BTAddress2 = ""
            Else
                BTAddress2 = reader.Item("BillToAddress2")
            End If
            If IsDBNull(reader.Item("BillToCity")) Then
                BTCity = ""
            Else
                BTCity = reader.Item("BillToCity")
            End If
            If IsDBNull(reader.Item("BillToState")) Then
                BTState = ""
            Else
                BTState = reader.Item("BillToState")
            End If
            If IsDBNull(reader.Item("BillToZip")) Then
                BTZip = ""
            Else
                BTZip = reader.Item("BillToZip")
            End If
            If IsDBNull(reader.Item("BillToCountry")) Then
                BTCountry = ""
            Else
                BTCountry = reader.Item("BillToCountry")
            End If
            If IsDBNull(reader.Item("PaymentTerms")) Then
                PaymentTerms = ""
            Else
                PaymentTerms = reader.Item("PaymentTerms")
            End If
            If IsDBNull(reader.Item("CustomerName")) Then
                CustomerName = ""
            Else
                CustomerName = reader.Item("CustomerName")
            End If
            If IsDBNull(reader.Item("CustomerClass")) Then
                CustomerClass = "STANDARD"
            Else
                CustomerClass = reader.Item("CustomerClass")
            End If
        Else
            BTAddress1 = ""
            BTAddress2 = ""
            BTCity = ""
            BTState = ""
            BTZip = ""
            BTCountry = ""
            PaymentTerms = ""
            CustomerName = ""
            CustomerClass = "STANDARD"
        End If
        reader.Close()
        con.Close()

        txtBTAddress1.Text = BTAddress1
        txtBTAddress2.Text = BTAddress2
        txtBTCity.Text = BTCity
        txtBTZip.Text = BTZip
        cboBTState.Text = BTState
        txtBTCountry.Text = BTCountry
        cboPaymentTerms.Text = PaymentTerms
        cboCustomerName.Text = CustomerName
        cboConsignmentWarehouse.Text = CustomerClass
    End Sub

    Public Sub GetThirdPartyBillingData()
        Dim SVBillToName As String = ""
        Dim SVBillToAddress1 As String = ""
        Dim SVBillToAddress2 As String = ""
        Dim SVBillToCity As String = ""
        Dim SVBillToState As String = ""
        Dim SVBillToZip As String = ""

        Dim BillToNameStatement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToNameCommand As New SqlCommand(BillToNameStatement, con)
        BillToNameCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress1Statement As String = "SELECT BillToAddress1 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress1Command As New SqlCommand(BillToAddress1Statement, con)
        BillToAddress1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToAddress1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToAddress2Statement As String = "SELECT BillToAddress2 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToAddress2Command As New SqlCommand(BillToAddress2Statement, con)
        BillToAddress2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToAddress2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToCityStatement As String = "SELECT BillToCity FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToCityCommand As New SqlCommand(BillToCityStatement, con)
        BillToCityCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToCityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToStateStatement As String = "SELECT BillToState FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToStateCommand As New SqlCommand(BillToStateStatement, con)
        BillToStateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToStateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim BillToZipStatement As String = "SELECT BillToZip FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim BillToZipCommand As New SqlCommand(BillToZipStatement, con)
        BillToZipCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        BillToZipCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SVBillToName = CStr(BillToNameCommand.ExecuteScalar)
        Catch ex As Exception
            SVBillToName = ""
        End Try
        Try
            SVBillToAddress1 = CStr(BillToAddress1Command.ExecuteScalar)
        Catch ex As Exception
            SVBillToAddress1 = ""
        End Try
        Try
            SVBillToAddress2 = CStr(BillToAddress2Command.ExecuteScalar)
        Catch ex As Exception
            SVBillToAddress2 = ""
        End Try
        Try
            SVBillToCity = CStr(BillToCityCommand.ExecuteScalar)
        Catch ex As Exception
            SVBillToCity = ""
        End Try
        Try
            SVBillToState = CStr(BillToStateCommand.ExecuteScalar)
        Catch ex As Exception
            SVBillToState = ""
        End Try
        Try
            SVBillToZip = CStr(BillToZipCommand.ExecuteScalar)
        Catch ex As Exception
            SVBillToZip = ""
        End Try
        con.Close()

        txtThirdParty.Text = SVBillToName + Environment.NewLine + SVBillToAddress1 + Environment.NewLine + SVBillToAddress2 + Environment.NewLine + SVBillToCity + ", " + SVBillToState + "  " + SVBillToZip
    End Sub

    Public Sub LoadCustomerTaxRate()
        Dim CustomerTaxRateStatement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerTaxRateCommand As New SqlCommand(CustomerTaxRateStatement, con)
        CustomerTaxRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerTaxRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerTaxRate = CDbl(CustomerTaxRateCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerTaxRate = 0
        End Try
        con.Close()

        txtLineSalesTaxRate.Text = CustomerTaxRate

        If CustomerTaxRate > 0 Then
            chkTaxable.Checked = True
        Else
            chkTaxable.Checked = False
        End If
    End Sub

    Public Sub LoadCustomerClassFromCustomer()
        Dim CustomerClassStatement As String = "SELECT CustomerClass FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerClassCommand As New SqlCommand(CustomerClassStatement, con)
        CustomerClassCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerClass = CStr(CustomerClassCommand.ExecuteScalar)
        Catch ex As Exception
            CustomerClass = ""
        End Try
        con.Close()

        cboCustomerClass.Text = CustomerClass
    End Sub

    Public Sub LoadInvoiceData()
        Dim T1, T2, T3 As Double
        Dim EditFreightBilled As Double = 0

        Dim InvoiceDataStatement As String = "SELECT * FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
        Dim InvoiceDataCommand As New SqlCommand(InvoiceDataStatement, con)
        InvoiceDataCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
        InvoiceDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = InvoiceDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("InvoiceDate")) Then
                InvoiceDate = dtpInvoiceDate.Value
            Else
                InvoiceDate = reader.Item("InvoiceDate")
            End If
            If IsDBNull(reader.Item("BatchNumber")) Then
                InvoiceBatchNumber = 0
            Else
                InvoiceBatchNumber = reader.Item("BatchNumber")
            End If
            If IsDBNull(reader.Item("CustomerID")) Then
                CustomerID = ""
            Else
                CustomerID = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("CustomerPO")) Then
                CustomerPO = ""
            Else
                CustomerPO = reader.Item("CustomerPO")
            End If
            If IsDBNull(reader.Item("PaymentTerms")) Then
                PaymentTerms = "N30"
            Else
                PaymentTerms = reader.Item("PaymentTerms")
            End If
            If IsDBNull(reader.Item("Comment")) Then
                Comment = ""
            Else
                Comment = reader.Item("Comment")
            End If
            If IsDBNull(reader.Item("ProductTotal")) Then
                ProductTotal = 0
            Else
                ProductTotal = reader.Item("ProductTotal")
            End If
            If IsDBNull(reader.Item("BilledFreight")) Then
                EditFreightBilled = 0
            Else
                EditFreightBilled = reader.Item("BilledFreight")
            End If
            If IsDBNull(reader.Item("SalesTax")) Then
                SalesTax = 0
                T1 = SalesTax
            Else
                SalesTax = reader.Item("SalesTax")
                T1 = SalesTax
            End If
            If IsDBNull(reader.Item("Discount")) Then
                DiscountAmount = 0
            Else
                DiscountAmount = reader.Item("Discount")
            End If
            If IsDBNull(reader.Item("InvoiceTotal")) Then
                InvoiceTotal = 0
            Else
                InvoiceTotal = reader.Item("InvoiceTotal")
            End If
            If IsDBNull(reader.Item("InvoiceStatus")) Then
                InvoiceStatus = "OPEN"
            Else
                InvoiceStatus = reader.Item("InvoiceStatus")
            End If
            If IsDBNull(reader.Item("ShipVia")) Then
                ShipVia = "DELIVERY"
            Else
                ShipVia = reader.Item("ShipVia")
            End If
            If IsDBNull(reader.Item("PRONumber")) Then
                PRONumber = ""
            Else
                PRONumber = reader.Item("PRONumber")
            End If
            If IsDBNull(reader.Item("SalesTax2")) Then
                SalesTax2 = 0
                T2 = SalesTax2
            Else
                SalesTax2 = reader.Item("SalesTax2")
                T2 = SalesTax2
            End If
            If IsDBNull(reader.Item("SalesTax3")) Then
                SalesTax3 = 0
                T3 = SalesTax3
            Else
                SalesTax3 = reader.Item("SalesTax3")
                T3 = SalesTax3
            End If
            If IsDBNull(reader.Item("SpecialInstructions")) Then
                SpecialInstructions = ""
            Else
                SpecialInstructions = reader.Item("SpecialInstructions")
            End If
            If IsDBNull(reader.Item("CustomerClass")) Then
                CustomerClass = "STANDARD"
            Else
                CustomerClass = reader.Item("CustomerClass")
            End If
            If IsDBNull(reader.Item("ShippingMethod")) Then
                ShippingMethod = "OTHER"
            Else
                ShippingMethod = reader.Item("ShippingMethod")
            End If
            If IsDBNull(reader.Item("FOB")) Then
                FOB = "STANDARD"
            Else
                FOB = reader.Item("FOB")
            End If
            If IsDBNull(reader.Item("ThirdPartyShipper")) Then
                ThirdPartyInfo = ""
            Else
                ThirdPartyInfo = reader.Item("ThirdPartyShipper")
            End If
        Else
            InvoiceDate = dtpInvoiceDate.Value
            ThirdPartyInfo = ""
            InvoiceBatchNumber = 0
            CustomerID = ""
            CustomerPO = ""
            PaymentTerms = "N30"
            Comment = ""
            ProductTotal = 0
            EditFreightBilled = 0
            SalesTax = 0
            T1 = SalesTax
            DiscountAmount = 0
            InvoiceTotal = 0
            InvoiceStatus = "OPEN"
            ShipVia = ""
            ShippingMethod = ""
            PRONumber = ""
            SalesTax2 = 0
            T2 = SalesTax2
            SalesTax3 = 0
            T3 = SalesTax3
            SpecialInstructions = ""
            FOB = "STANDARD"
            CustomerClass = "STANDARD"
        End If
        reader.Close()
        con.Close()

        dtpInvoiceDate.Text = InvoiceDate
        cboCustomerID.Text = CustomerID
        txtCustomerPONumber.Text = CustomerPO
        cboPaymentTerms.Text = PaymentTerms
        txtComment.Text = Comment
        txtProductSales.Text = FormatCurrency(ProductTotal, 2)
        txtFreightBilled.Text = FormatCurrency(EditFreightBilled, 2)
        txtDiscount.Text = FormatCurrency(DiscountAmount, 2)
        txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        cboShipVia.Text = ShipVia
        cboShipMethod.Text = ShippingMethod
        cboConsignmentWarehouse.Text = FOB
        cboCustomerClass.Text = CustomerClass
        txtProNumber.Text = PRONumber
        txtStatus.Text = InvoiceStatus
        txtBatchNumber.Text = InvoiceBatchNumber
        txtBilledFreightEdit.Text = Math.Round(EditFreightBilled, 2)
        txtSpecialInstructions.Text = SpecialInstructions
        txtThirdParty.Text = ThirdPartyInfo

        If InvoiceStatus = "CLOSED" Then
            cmdAddDiscount.Enabled = False
            cmdDelete.Enabled = False
            cmdDeleteDiscount.Enabled = False
            cmdSave.Enabled = False
            SaveInvoiceToolStripMenuItem.Enabled = False
            DeleteInvoiceToolStripMenuItem.Enabled = False
        Else
            cmdAddDiscount.Enabled = True
            cmdDelete.Enabled = True
            cmdDeleteDiscount.Enabled = True
            cmdSave.Enabled = True
            SaveInvoiceToolStripMenuItem.Enabled = True
            DeleteInvoiceToolStripMenuItem.Enabled = True
        End If

        If T2 > 0 Then
            chkAddPST.Checked = True
        Else
            chkAddPST.Checked = False
        End If

        If T3 > 0 Then
            chkAddHST.Checked = True
        Else
            chkAddHST.Checked = False
        End If

        txtSalesTax.Text = FormatCurrency(T1, 2)
        txtSalesTax2.Text = FormatCurrency(T2, 2)
        txtSalesTax3.Text = FormatCurrency(T3, 2)
    End Sub

    Public Sub LoadGLAccounts()
        Dim GETGLAccountsStatement As String = "SELECT * FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim GETGLAccountsCommand As New SqlCommand(GETGLAccountsStatement, con)
        GETGLAccountsCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = cboItemClass.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GETGLAccountsCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("GLSalesAccount")) Then
                GLSalesAccount = "41000"
            Else
                GLSalesAccount = reader.Item("GLSalesAccount")
            End If
            If IsDBNull(reader.Item("GLReturnsAccount")) Then
                GLReturnsAccount = "41000"
            Else
                GLReturnsAccount = reader.Item("GLReturnsAccount")
            End If
            If IsDBNull(reader.Item("GLInventoryAccount")) Then
                GLInventoryAccount = "12100"
            Else
                GLInventoryAccount = reader.Item("GLInventoryAccount")
            End If
            If IsDBNull(reader.Item("GLCOGSAccount")) Then
                GLCOGSAccount = "51000"
            Else
                GLCOGSAccount = reader.Item("GLCOGSAccount")
            End If
            If IsDBNull(reader.Item("GLPurchasesAccount")) Then
                GLPurchasesAccount = "20999"
            Else
                GLPurchasesAccount = reader.Item("GLPurchasesAccount")
            End If
            If IsDBNull(reader.Item("GLSalesOffsetAccount")) Then
                GLSalesOffsetAccount = "49999"
            Else
                GLSalesOffsetAccount = reader.Item("GLSalesOffsetAccount")
            End If
            If IsDBNull(reader.Item("GLAdjustmentAccount")) Then
                GLAdjustmentAccount = "59790"
            Else
                GLAdjustmentAccount = reader.Item("GLAdjustmentAccount")
            End If
            If IsDBNull(reader.Item("GLIssuesAccount")) Then
                GLIssuesAccount = "59790"
            Else
                GLIssuesAccount = reader.Item("GLIssuesAccount")
            End If
        Else
            GLSalesAccount = "41000"
            GLReturnsAccount = "41000"
            GLInventoryAccount = "12100"
            GLCOGSAccount = "51000"
            GLPurchasesAccount = "20999"
            GLSalesOffsetAccount = "49999"
            GLAdjustmentAccount = "59790"
            GLIssuesAccount = "59790"
        End If
        reader.Close()
        con.Close()

        txtGLAdjustmentAccount.Text = GLAdjustmentAccount
        txtGLInventoryAccount.Text = GLInventoryAccount
        txtGLIssuesAccount.Text = GLIssuesAccount
        txtGLPurchasesAccount.Text = GLPurchasesAccount
        txtGLReturnsAccount.Text = GLReturnsAccount
        txtGLSalesAccount.Text = GLSalesAccount
        txtGLSalesOffsetAccount.Text = GLSalesOffsetAccount
        txtGLCOGSAccount.Text = GLCOGSAccount
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub ExtractFIFOCost()
        'Determine FIFO Cost on Part Number to remove from Inventory
        QuantityBilled = Val(txtQuantityBilled.Text)

        'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
        Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityBilled BETWEEN LowerLimit AND UpperLimit"
        Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
        ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ItemCostCommand.Parameters.Add("@TotalQuantityBilled", SqlDbType.VarChar).Value = QuantityBilled

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            FIFOCost = CDbl(ItemCostCommand.ExecuteScalar)
        Catch ex As Exception
            FIFOCost = 0
        End Try
        con.Close()

        FIFOExtendedAmount = FIFOCost * QuantityBilled
    End Sub

    Private Sub chkAddPST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddPST.CheckedChanged
        BilledFreight = Val(txtBilledFreightEdit.Text)

        If chkAddPST.Checked = True And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
            'Get PST Rate
            PSTRate = 0.07
            GSTRate = 0.05

            chkAddHST.Checked = False
            txtHSTRate.Visible = False
            chkRemoveAllTaxes.Checked = False

            GSTTotal = GSTRate * (ProductTotal + BilledFreight)
            PSTTotal = (ProductTotal + BilledFreight) * PSTRate

            SalesTax = GSTTotal
            SalesTax2 = PSTTotal
            SalesTax3 = 0

            txtSalesTax3.Text = FormatCurrency(SalesTax3, 2)
            txtSalesTax2.Text = FormatCurrency(SalesTax2, 2)
            txtSalesTax.Text = FormatCurrency(SalesTax, 2)

            InvoiceTotal = SalesTax + SalesTax2 + SalesTax3 + BilledFreight + ProductTotal
            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        ElseIf chkAddPST.Checked = False And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
            SalesTax2 = 0
            txtSalesTax2.Text = FormatCurrency(SalesTax2, 2)

            PSTTotal = 0
            InvoiceTotal = SalesTax + SalesTax2 + SalesTax3 + BilledFreight + ProductTotal
            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        Else
            'Do nothing - Canadian only
        End If
    End Sub

    Private Sub chkAddHST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAddHST.CheckedChanged
        BilledFreight = Val(txtBilledFreightEdit.Text)

        If chkAddHST.Checked = True And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
            Dim HSTRateString As String = "SELECT SalesTaxRate3 FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim HSTRateCommand As New SqlCommand(HSTRateString, con)
            HSTRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            HSTRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim SUMProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
            Dim SUMProductTotalCommand As New SqlCommand(SUMProductTotalStatement, con)
            SUMProductTotalCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            SUMProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            Dim GetHSTValueStatement As String = "SELECT SalesTax3 FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID"
            Dim GetHSTValueCommand As New SqlCommand(GetHSTValueStatement, con)
            GetHSTValueCommand.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            GetHSTValueCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                HSTRate = CDbl(HSTRateCommand.ExecuteScalar)
            Catch ex As Exception
                HSTRate = 0
            End Try
            Try
                ProductTotal = CDbl(SUMProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            Try
                HSTValue = CDbl(GetHSTValueCommand.ExecuteScalar)
            Catch ex As Exception
                HSTValue = 0
            End Try
            con.Close()

            'Get HST Rate
            chkAddPST.Checked = False
            txtHSTRate.Visible = True
            chkRemoveAllTaxes.Checked = False

            If HSTValue = 0 Then
                txtHSTRate.Text = HSTRate
            Else
                HSTRate = HSTValue / ProductTotal
                txtHSTRate.Text = HSTRate
            End If

            HSTTotal = (ProductTotal + BilledFreight) * HSTRate

            SalesTax3 = HSTTotal
            SalesTax = 0
            SalesTax2 = 0

            txtSalesTax.Text = FormatCurrency(SalesTax, 2)
            txtSalesTax2.Text = FormatCurrency(SalesTax2, 2)
            txtSalesTax3.Text = FormatCurrency(SalesTax3, 2)

            InvoiceTotal = SalesTax + SalesTax2 + SalesTax3 + BilledFreight + ProductTotal
            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        ElseIf chkAddHST.Checked = False And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
            Dim SUMProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
            Dim SUMProductTotalCommand As New SqlCommand(SUMProductTotalStatement, con)
            SUMProductTotalCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            SUMProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ProductTotal = CDbl(SUMProductTotalCommand.ExecuteScalar)
            Catch ex As Exception
                ProductTotal = 0
            End Try
            con.Close()

            txtHSTRate.Visible = False

            SalesTax3 = 0
            SalesTax2 = 0

            'Reload GST if HST is unchecked
            GSTTotal = GSTRate * (ProductTotal + BilledFreight)
            SalesTax = GSTTotal

            txtSalesTax3.Text = FormatCurrency(SalesTax3, 2)
            txtSalesTax.Text = FormatCurrency(SalesTax, 2)
            txtSalesTax2.Text = FormatCurrency(SalesTax2, 2)

            InvoiceTotal = SalesTax + SalesTax2 + SalesTax3 + BilledFreight + ProductTotal
            txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
        Else
            'Do nothing - Canadian only
        End If
    End Sub

    Private Sub chkTaxable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTaxable.CheckedChanged
        If chkTaxable.Checked = True Then
            Dim CustomerTaxRateStatement As String = "SELECT SalesTaxRate FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerTaxRateCommand As New SqlCommand(CustomerTaxRateStatement, con)
            CustomerTaxRateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CustomerTaxRateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerTaxRate = CDbl(CustomerTaxRateCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerTaxRate = 0
            End Try
            con.Close()

            txtLineSalesTaxRate.Text = CustomerTaxRate
            txtLineSalesTaxRate.Visible = True
            QuantityBilled = Val(txtQuantityBilled.Text)
            Price = Val(txtPrice.Text)
            ExtendedAmount = QuantityBilled * Price
            LineSalesTax = CustomerTaxRate * ExtendedAmount
            txtLineSalesTax.Text = FormatCurrency(LineSalesTax, 2)
            txtExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)

            chkRemoveAllTaxes.Checked = False
        Else
            txtLineSalesTaxRate.Visible = False
            QuantityBilled = Val(txtQuantityBilled.Text)
            Price = Val(txtPrice.Text)
            ExtendedAmount = QuantityBilled * Price
            txtLineSalesTax.Clear()
            txtExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)
        End If
    End Sub

    Private Sub txtQuantityBilled_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantityBilled.TextChanged
        If isLoaded Then
            QuantityBilled = Val(txtQuantityBilled.Text)
            Price = Val(txtPrice.Text)
            ExtendedAmount = QuantityBilled * Price
            If chkTaxable.Checked = True Then
                LineSalesTax = CustomerTaxRate * ExtendedAmount
                txtLineSalesTax.Text = FormatCurrency(LineSalesTax, 2)
                txtExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)
            Else
                txtLineSalesTax.Clear()
                txtExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)
            End If
        End If
    End Sub

    Private Sub txtHSTRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHSTRate.TextChanged
        If isLoaded Then
            BilledFreight = Val(txtBilledFreightEdit.Text)

            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                Dim SUMExtendedStatement As String = "SELECT SUM(ExtendedAmount) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
                Dim SUMExtendedCommand As New SqlCommand(SUMExtendedStatement, con)
                SUMExtendedCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                SUMExtendedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ProductTotal = CDbl(SUMExtendedCommand.ExecuteScalar)
                Catch ex As Exception
                    ProductTotal = 0
                End Try
                con.Close()

                SalesTax = 0
                SalesTax2 = 0
                HSTRate = Val(txtHSTRate.Text)

                HSTTotal = HSTRate * (ProductTotal + BilledFreight)
                SalesTax3 = HSTTotal

                txtSalesTax.Text = FormatCurrency(SalesTax, 2)
                txtSalesTax2.Text = FormatCurrency(SalesTax2, 2)
                txtSalesTax3.Text = FormatCurrency(SalesTax3, 2)

                InvoiceTotal = SalesTax + SalesTax2 + SalesTax3 + BilledFreight + ProductTotal
                txtInvoiceTotal.Text = FormatCurrency(InvoiceTotal, 2)
            Else
                'Do nothing
            End If
        End If
    End Sub

    Private Sub txtPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice.TextChanged
        If isLoaded Then
            QuantityBilled = Val(txtQuantityBilled.Text)
            Price = Val(txtPrice.Text)
            ExtendedAmount = QuantityBilled * Price
            If chkTaxable.Checked = True Then
                LineSalesTax = CustomerTaxRate * ExtendedAmount
                txtLineSalesTax.Text = FormatCurrency(LineSalesTax, 2)
                txtExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)
            Else
                txtLineSalesTax.Clear()
                txtExtendedAmount.Text = FormatCurrency(ExtendedAmount, 2)
            End If
        End If
    End Sub

    Private Sub txtLineSalesTaxRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineSalesTaxRate.TextChanged
        If isLoaded Then
            CustomerTaxRate = Val(txtLineSalesTaxRate.Text)
            QuantityBilled = Val(txtLineQuantityBilled.Text)
            Price = Val(txtPrice.Text)
            ExtendedAmount = QuantityBilled * Price

            If CustomerTaxRate <> 0 Then
                LineSalesTax = CustomerTaxRate * ExtendedAmount
                txtLineSalesTax.Text = FormatCurrency(LineSalesTax, 2)
            End If
        End If
    End Sub

    Private Sub txtBilledFreightEdit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBilledFreightEdit.TextChanged
        If isloaded Then
            BilledFreight = Val(txtBilledFreightEdit.Text)
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If isloaded Then
            If Not String.IsNullOrEmpty(lastBatch) Then
                unlockBatch(lastBatch)
            End If
        End If

        'Convert date type to Canadian style for TFF
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LabelHST.Visible = True
            LabelPST.Visible = True
            LabelSalesTax.Text = "GST"
            txtSalesTax2.Visible = True
            txtSalesTax3.Visible = True
            chkTaxable.Visible = False
            txtLineSalesTax.Enabled = False
            txtLineSalesTax2.Enabled = False
            txtLineSalesTaxRate.Visible = False
            cboConsignmentWarehouse.Enabled = False
            cboCustomerClass.Enabled = True
            chkAddHST.Visible = True
            chkAddPST.Visible = True
            txtHSTRate.Visible = False
        Else
            LabelHST.Visible = False
            LabelPST.Visible = False
            LabelSalesTax.Text = "Sales Tax"
            txtSalesTax2.Visible = False
            txtSalesTax3.Visible = False
            chkTaxable.Visible = True
            txtLineSalesTax.Enabled = True
            txtLineSalesTax2.Enabled = True
            txtLineSalesTaxRate.Visible = False

            If cboDivisionID.Text.Equals("TWD") Then
                cboConsignmentWarehouse.Enabled = True
                cboCustomerClass.Enabled = True
            Else
                cboConsignmentWarehouse.Enabled = False
            End If

            chkAddHST.Visible = False
            chkAddPST.Visible = False
            txtHSTRate.Visible = False
        End If

        LoadPartNumber()
        LoadPartDescription()
        LoadInvoiceNumber()
        LoadCustomerID()
        LoadCustomerName()
        LoadCustomerClasses()
        LoadFOB()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub LoadCustomerIDByName()
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
    End Sub

    Public Sub LoadCustomerNameByID()
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
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        If isLoaded Then
            LoadItemClassForPartNumber()
            LoadDescriptionByPart()
        End If
    End Sub

    Private Sub cboInvoiceLineNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInvoiceLineNumber.SelectedIndexChanged
        If isLoaded Then
            LoadLineDetails()
        End If
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        If isLoaded Then
            LoadPartByDescription()
        End If
    End Sub

    Private Sub cboItemClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemClass.SelectedIndexChanged
        If isLoaded Then
            LoadGLAccounts()
        End If
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        If isloaded Then
            LoadCustomerData()
            LoadCustomerNameByID()
            LoadCustomerClassFromCustomer()

            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                LoadCanadianTaxRates()
            Else
                LoadCustomerTaxRate()
            End If
        End If
    End Sub

    Private Sub cboInvoiceNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInvoiceNumber.SelectedIndexChanged
        If isloaded Then
            unlockBatch(lastBatch)
            ClearLinesOnInvoiceNumberChange()
            LoadInvoiceData()
            ShowData()
            lastBatch = txtBatchNumber.Text
        End If
    End Sub

    Private Sub cmdClearLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLine.Click
        ClearLines()
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        unlockBatch()
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdGenerateNewInvoiceNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewInvoiceNumber.Click
        If Not String.IsNullOrEmpty(txtBatchNumber.Text) Then
            unlockBatch()
        End If

        ClearVariables()
        ClearData()
        ClearDataInDatagrid()

        If cboDivisionID.Text = "ADM" Then
            MsgBox("You must select a valid Division.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Find the next Invoice Number to use
        Dim MAXStatement As String = "SELECT MAX(InvoiceNumber) FROM InvoiceHeaderTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastTransactionNumber = 6200000
        End Try
        con.Close()

        NextTransactionNumber = LastTransactionNumber + 1
        cboInvoiceNumber.Text = NextTransactionNumber

        'Find the next Batch Number to use
        Dim MAXBatchStatement As String = "SELECT MAX(BatchNumber) FROM InvoiceProcessingBatchHeader"
        Dim MAXBatchCommand As New SqlCommand(MAXBatchStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastBatchNumber = CInt(MAXBatchCommand.ExecuteScalar)
        Catch ex As Exception
            LastBatchNumber = 2200000
        End Try
        con.Close()

        NextBatchNumber = LastBatchNumber + 1
        txtBatchNumber.Text = NextBatchNumber

        BatchDate = dtpInvoiceDate.Value
        InvoiceDate = dtpInvoiceDate.Value
        ShipmentDate = dtpShipDate.Value

        Try
            'Reserve Batch Number 
            cmd = New SqlCommand("INSERT INTO InvoiceProcessingBatchHeader (BatchNumber, BatchDate, BatchAmount, BatchDescription, DivisionID, BatchStatus, UserID, Locked, PrintDate) Values (@BatchNumber, @BatchDate, @BatchAmount, @BatchDescription, @DivisionID, @BatchStatus, @UserID, @UserID, @PrintDate)", con)

            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                .Add("@BatchDate", SqlDbType.VarChar).Value = BatchDate
                .Add("@BatchAmount", SqlDbType.VarChar).Value = 0
                .Add("@BatchDescription", SqlDbType.VarChar).Value = "BILL ONLY INVOICE"
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@PrintDate", SqlDbType.VarChar).Value = ""
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempBatchNumber As Integer = 0
            Dim strBatchNumber As String
            TempBatchNumber = Val(txtBatchNumber.Text)
            strBatchNumber = CStr(TempBatchNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Bill Only --- Insert Into batch header"
            ErrorReferenceNumber = "Batch # " + strBatchNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        Try
            'Reserve Invoice Number 
            cmd = New SqlCommand("INSERT INTO InvoiceHeaderTable (InvoiceNumber, DivisionID, SalesOrderNumber, ShipmentNumber, BatchNumber, InvoiceStatus, InvoiceDate) Values (@InvoiceNumber, @DivisionID, @SalesOrderNumber, @ShipmentNumber, @BatchNumber, @InvoiceStatus, @InvoiceDate)", con)

            With cmd.Parameters
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = NextTransactionNumber
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = 0
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "BILL ONLY"
                .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempInvoiceNumber As Integer = 0
            Dim strInvoiceNumber As String
            TempInvoiceNumber = Val(cboInvoiceNumber.Text)
            strInvoiceNumber = CStr(TempInvoiceNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Bill Only --- Insert Into Invoice Header"
            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try

        isloaded = False
        LoadInvoiceNumber()
        cboInvoiceNumber.Text = NextTransactionNumber
        isloaded = True
        InvoiceBatchNumber = NextBatchNumber
        cboInvoiceNumber.Focus()
    End Sub

    Private Sub cmdAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLine.Click
        If canAddLine() Then
            LockBatch()
            'Load Totals and date
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                CalculateCanadianTotals()
                BatchDate = dtpInvoiceDate.Value
                InvoiceDate = dtpInvoiceDate.Value
                ShipmentDate = dtpShipDate.Value
            Else
                'Load Invoice Totals
                CalculateTotals()
                BatchDate = dtpInvoiceDate.Value
                InvoiceDate = dtpInvoiceDate.Value
                ShipmentDate = dtpShipDate.Value
            End If
            '*************************************************************************************
            'Validate Shipping
            If cboShipVia.Text = "" Then
                ShipVia = "DELIVERY"
            Else
                ShipVia = cboShipVia.Text
            End If
            '*************************************************************************************
            ValidateFOBandCustomerClass()
            '*************************************************************************************
            'Save/Insert into Invoice Header Table
            SaveUpdateAndInsertCommand()
            '**************************************************************************************
            'Find next Line Number for Invoice
            Dim MAXLineStatement As String = "SELECT MAX(InvoiceLineKey) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey"
            Dim MAXLineCommand As New SqlCommand(MAXLineStatement, con)
            MAXLineCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastLineNumber = CInt(MAXLineCommand.ExecuteScalar)
            Catch ex As Exception
                LastLineNumber = 0
            End Try
            con.Close()

            NextLineNumber = LastLineNumber + 1

            'Extract cost for Part Number
            ExtractFIFOCost()

            'Get Line totals
            Price = Val(txtPrice.Text)
            QuantityBilled = Val(txtQuantityBilled.Text)
            ExtendedAmount = Price * QuantityBilled

            'If TFF, do not write line sales tax
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                LineSalesTax = 0
            Else
                LineSalesTax = ExtendedAmount * Val(txtLineSalesTaxRate.Text)
            End If

            If chkTaxable.Checked = False Then
                LineSalesTax = 0
            Else
                'Do nothing
            End If

            'Enter Line Items and save to database
            Try
                cmd = New SqlCommand("INSERT INTO InvoiceLineTable (InvoiceHeaderKey, InvoiceLineKey, PartNumber, PartDescription, QuantityBilled, Price, LineComment, LineWeight, LineBoxes, SalesTax, ExtendedAmount, LineStatus, DivisionID, DebitGLAccount, CreditGLAccount, ExtendedCOS) Values (@InvoiceHeaderKey, @InvoiceLineKey, @PartNumber, @PartDescription, @QuantityBilled, @Price, @LineComment, @LineWeight, @LineBoxes, @SalesTax, @ExtendedAmount, @LineStatus, @DivisionID, @DebitGLAccount, @CreditGLAccount, @ExtendedCOS)", con)

                With cmd.Parameters
                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = NextLineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                    .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                    .Add("@QuantityBilled", SqlDbType.VarChar).Value = Val(txtQuantityBilled.Text)
                    .Add("@Price", SqlDbType.VarChar).Value = Val(txtPrice.Text)
                    .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text
                    .Add("@LineWeight", SqlDbType.VarChar).Value = 0
                    .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                    .Add("@SalesTax", SqlDbType.VarChar).Value = LineSalesTax
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtQuantityBilled.Text) * Val(txtPrice.Text)
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = txtGLSalesAccount.Text
                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = txtGLSalesOffsetAccount.Text
                    .Add("@ExtendedCOS", SqlDbType.VarChar).Value = FIFOExtendedAmount
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                Try
                    cmd = New SqlCommand("UPDATE InvoiceLineTable SET PartNumber = @PartNumber, PartDescription = @PartDescription, QuantityBilled = @QuantityBilled, Price = @Price, LineComment = @LineComment, LineWeight = @LineWeight, LineBoxes = @LineBoxes, SalesTax = @SalesTax, ExtendedAmount = @ExtendedAmount, LineStatus = @LineStatus, DivisionID = @DivisionID, DebitGLAccount = @DebitGLAccount, CreditGLAccount = @CreditGLAccount, ExtendedCOS = @ExtendedCOS WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = NextLineNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
                        .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
                        .Add("@QuantityBilled", SqlDbType.VarChar).Value = Val(txtQuantityBilled.Text)
                        .Add("@Price", SqlDbType.VarChar).Value = Val(txtPrice.Text)
                        .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment.Text
                        .Add("@LineWeight", SqlDbType.VarChar).Value = 0
                        .Add("@LineBoxes", SqlDbType.VarChar).Value = 0
                        .Add("@SalesTax", SqlDbType.VarChar).Value = LineSalesTax
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtQuantityBilled.Text) * Val(txtPrice.Text)
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@DebitGLAccount", SqlDbType.VarChar).Value = txtGLSalesAccount.Text
                        .Add("@CreditGLAccount", SqlDbType.VarChar).Value = txtGLSalesOffsetAccount.Text
                        .Add("@ExtendedCOS", SqlDbType.VarChar).Value = FIFOExtendedAmount
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex1 As Exception
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex1.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Bill Only --- ADD Line - Insert Into Invoice Line"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            End Try

            'Reload totals to update after line entry
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                CalculateCanadianTotals()
            Else
                'Load Invoice Totals
                CalculateTotals()
            End If

            Try
                'UPDATE Invoice Header Table with line totals
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET ProductTotal = @ProductTotal, SalesTax = @SalesTax, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3, Discount = @Discount, InvoiceTotal = @InvoiceTotal, InvoiceCOS = @InvoiceCOS WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                    .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                    .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2
                    .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3
                    .Add("@Discount", SqlDbType.VarChar).Value = DiscountAmount
                    .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@InvoiceCOS", SqlDbType.VarChar).Value = HeaderExtendedCOS
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempInvoiceNumber As Integer = 0
                Dim strInvoiceNumber As String
                TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                strInvoiceNumber = CStr(TempInvoiceNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Bill Only --- UPDATE Invoice Header - ADD Line"
                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            Try
                'UPDATE Batch Number Table
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber", con)
                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = InvoiceTotal
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber As String
                TempBatchNumber = Val(txtBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Bill Only --- UPDATE Batch - ADD Line"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Reload datagrid
            ShowData()

            Try
                'Set focus to current line in the datagrid
                Me.dgvInvoiceLines.Rows(dgvInvoiceLines.Rows.Count - 1).Selected = True
                Me.dgvInvoiceLines.CurrentCell = Me.dgvInvoiceLines.Rows(Me.dgvInvoiceLines.Rows.Count - 1).Cells(1)
            Catch ex As Exception
                'Skip
            End Try

            ClearLines()

            cboPartNumber.Focus()
        End If
    End Sub

    Private Function canAddLine() As Boolean
        If String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
            MsgBox("You must have a valid Invoice Number selected.", MsgBoxStyle.OkOnly)
            cboInvoiceNumber.Focus()
            Return False
        End If
        If cboInvoiceNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid Invoice number", "Enter a valid invoice number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInvoiceNumber.SelectAll()
            cboInvoiceNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MessageBox.Show("You must select a customer ID", "Select a customerID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.Focus()
            Return False
        End If
        If cboCustomerID.SelectedIndex = -1 Then
            MessageBox.Show("You must select a valid customer ID", "Select a valid customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.SelectAll()
            cboCustomerID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboPartNumber.Text) Then
            MsgBox("You must have a valid Part Number selected.", MsgBoxStyle.OkOnly)
            cboPartNumber.Focus()
            Return False
        End If
        If cboPartNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid part number", "Enter a valid part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPartNumber.SelectAll()
            cboPartNumber.Focus()
            Return False
        End If
        If partExists() Then
            MsgBox("Part Number does not exist in the database. Verify that part is entered correctly.", MsgBoxStyle.OkOnly)
            cboPartNumber.SelectAll()
            cboPartNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtQuantityBilled.Text) Then
            MessageBox.Show("You must enter a quantity billed", "Enter a quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtQuantityBilled.Focus()
            Return False
        End If
        'Numeric Validation for text box fields
        If IsNumeric(txtQuantityBilled.Text) = False Then
            MsgBox("You must enter numeric data in Quantity Billed ", MsgBoxStyle.OkOnly)
            txtQuantityBilled.SelectAll()
            txtQuantityBilled.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtPrice.Text) Then
            MessageBox.Show("You must enter a price", "Enter a price", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.Focus()
            Return False
        End If
        If IsNumeric(txtPrice.Text) = False Then
            MessageBox.Show("Price must be numeric", "Enter a number for pirce", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPrice.SelectAll()
            txtPrice.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function partExists() As Boolean
        'Verify that Part Number is valid
        Dim VerifyItemIDStatement As String = "SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim VerifyItemIDCommand As New SqlCommand(VerifyItemIDStatement, con)
        VerifyItemIDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        VerifyItemIDCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VerifyItemID = CStr(VerifyItemIDCommand.ExecuteScalar)
        Catch ex As Exception
            VerifyItemID = "DOES NOT EXIST"
        End Try
        con.Close()

        If VerifyItemID = "DOES NOT EXIST" Or VerifyItemID = "" Then
            Return True
        End If
        Return False
    End Function

    Private Sub cmdSaveLineChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveLineChanges.Click
        If canSaveLineChanges() Then
            LockBatch()
            Try
                Try
                    'Update Invoice Line
                    cmd = New SqlCommand("UPDATE InvoiceLineTable SET PartNumber = @PartNumber, PartDescription = @PartDescription, QuantityBilled = @QuantityBilled, Price = @Price, LineComment = @LineComment, LineWeight = @LineWeight, LineBoxes = @LineBoxes, SalesTax = @SalesTax, ExtendedAmount = @ExtendedAmount, LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.Int).Value = Val(cboInvoiceNumber.Text)
                        .Add("@InvoiceLineKey", SqlDbType.Int).Value = Val(cboInvoiceLineNumber.Text)
                        .Add("@PartNumber", SqlDbType.VarChar).Value = cboLinePartNumber.Text
                        .Add("@PartDescription", SqlDbType.VarChar).Value = cboLinePartDescription.Text
                        .Add("@QuantityBilled", SqlDbType.Int).Value = Val(txtLineQuantityBilled.Text)
                        .Add("@Price", SqlDbType.Float).Value = Val(txtLinePrice.Text)
                        .Add("@LineComment", SqlDbType.VarChar).Value = txtLineComment2.Text
                        .Add("@LineWeight", SqlDbType.Float).Value = 0
                        .Add("@LineBoxes", SqlDbType.Float).Value = 0
                        .Add("@SalesTax", SqlDbType.Float).Value = Val(txtLineSalesTax2.Text)
                        .Add("@ExtendedAmount", SqlDbType.Float).Value = Val(txtLineExtendedAmount.Text)
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Bill Only --- Save Line - UPDATE Line Table"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '****************************************************************************************************
                'Refresh datagrid
                ShowData()

                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CalculateCanadianTotals()
                Else
                    CalculateTotals()
                End If
                '****************************************************************************************************
                'Update header table with line changes
                Try
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET ProductTotal = @ProductTotal, BilledFreight = @BilledFreight, InvoiceTotal = @InvoiceTotal, SalesTax = @SalesTax, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3 WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        .Add("@BilledFreight", SqlDbType.VarChar).Value = BilledFreight
                        .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                        .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                        .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2
                        .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Bill Only --- UPDATE Invoice Header - SAVE Line"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                'Reload totals
                LoadInvoiceTotal()
                ShowData()
            Catch ex As Exception
                MsgBox("You cannot save changes at this time, contact system admin", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Function canSaveLineChanges() As Boolean
        If String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
            MessageBox.Show("You must enter a invoice number", "Enter an invoice number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInvoiceNumber.Focus()
            Return False
        End If
        If cboInvoiceNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid invoice number", "Enter a valid invoice number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInvoiceNumber.SelectAll()
            cboInvoiceNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MessageBox.Show("You must enter a customer ID", "Enter a customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.Focus()
            Return False
        End If
        If cboCustomerID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid customer ID", "Enter a valid customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.SelectAll()
            cboCustomerID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboLinePartNumber.Text) Then
            MessageBox.Show("You must select a part number", "Select a part number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPartNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtLineQuantityBilled.Text) Then
            MessageBox.Show("You must enter a quantity billed", "Enter quantity billed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If IsNumeric(txtLineQuantityBilled.Text) = False Then
            MessageBox.Show("You must enter a number for the quantity", "Enter a numeric quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLineQuantityBilled.SelectAll()
            txtLineQuantityBilled.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtLinePrice.Text) Then
            MessageBox.Show("You must have a price entered", "Enter a price", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLinePrice.Focus()
            Return False
        End If
        If IsNumeric(txtLinePrice.Text) = False Then
            MessageBox.Show("You must enter a number for price", "Enter a numeric price", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLinePrice.SelectAll()
            txtLinePrice.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub cmdDeleteInvoiceLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteInvoiceLine.Click
        If cboInvoiceNumber.Text = "" Or cboCustomerID.Text = "" Then
            MsgBox("You must have a valid Invoice Number / Customer to delete.", MsgBoxStyle.OkOnly)
        Else
            If isSomeoneEditing() Then
                Exit Sub
            End If
            LockBatch()
            Try
                Try
                    'Delete Invoice Line
                    cmd = New SqlCommand("DELETE FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = Val(cboInvoiceLineNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Bill Only --- Delete Invoice Line - DELETE Line"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '****************************************************************************************************
                'Re-number lines
                ShowData()

                Dim TempLineNumber As Integer = 1000

                'Re-number Invoice Lines
                For Each row As DataGridViewRow In dgvInvoiceLines.Rows
                    Try
                        GridLineNumber = row.Cells("InvoiceLineKeyColumn").Value
                    Catch ex As Exception
                        GridLineNumber = 1
                    End Try

                    Try
                        cmd = New SqlCommand("UPDATE InvoiceLineTable SET InvoiceLineKey = @InvoiceLineKey WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey1 AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            .Add("@InvoiceLineKey1", SqlDbType.VarChar).Value = GridLineNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = TempLineNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String
                        TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Bill Only --- Delete Invoice Line - UPDATE Line"
                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    TempLineNumber = TempLineNumber + 1
                Next

                'Refresh datagrid
                ShowData()

                Dim FinalLineNumber As Integer = 1

                'Re-number Invoice Lines
                For Each row As DataGridViewRow In dgvInvoiceLines.Rows
                    Try
                        GridLineNumber = row.Cells("InvoiceLineKeyColumn").Value
                    Catch ex As Exception
                        GridLineNumber = 1000
                    End Try

                    Try
                        cmd = New SqlCommand("UPDATE InvoiceLineTable SET InvoiceLineKey = @InvoiceLineKey WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey1 AND DivisionID = @DivisionID", con)

                        With cmd.Parameters
                            .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            .Add("@InvoiceLineKey1", SqlDbType.VarChar).Value = GridLineNumber
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = FinalLineNumber
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Log error on update failure
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String
                        TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Bill Only --- UPDATE Invoice Line Table - DELETE Line"
                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try

                    FinalLineNumber = FinalLineNumber + 1
                Next

                'Show updated data
                ShowData()
                '****************************************************************************************************
                'Load totals
                If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                    CalculateCanadianTotals()
                Else
                    CalculateTotals()
                End If
                '****************************************************************************************************
                'Update header table with line changes
                Try
                    cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET ProductTotal = @ProductTotal, BilledFreight = @BilledFreight, InvoiceTotal = @InvoiceTotal, SalesTax = @SalesTax, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3 WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                        .Add("@BilledFreight", SqlDbType.VarChar).Value = BilledFreight
                        .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                        .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                        .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2
                        .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Bill Only --- Delete Line"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                'Reload totals
                LoadInvoiceTotal()
                ShowData()
            Catch ex As Exception
                MsgBox("Line cannot be deleted at this time, contact system admin", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Public Sub SaveUpdateAndInsertCommand()
        'Save data in Invoice Header Table
        Try
            cmd = New SqlCommand("INSERT INTO InvoiceHeaderTable (InvoiceNumber, BatchNumber, InvoiceDate, SalesOrderNumber, ShipmentNumber, DivisionID, CustomerID, CustomerPO, PaymentTerms, Comment, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, ProductTotal, BilledFreight, SalesTax, Discount, InvoiceTotal, InvoiceStatus, ShipVia, PaymentsApplied, InvoiceCOS, PRONumber, SpecialInstructions, DropShipPONumber, SalesTax2, SalesTax3, ReprintBatch, CustomerClass, FOB, ShippingMethod, ThirdPartyShipper) Values (@InvoiceNumber, @BatchNumber, @InvoiceDate, @SalesOrderNumber, @ShipmentNumber, @DivisionID, @CustomerID, @CustomerPO, @PaymentTerms, @Comment, @BTAddress1, @BTAddress2, @BTCity, @BTState, @BTZip, @BTCountry, @ProductTotal, @BilledFreight, @SalesTax, @Discount, @InvoiceTotal, @InvoiceStatus, @ShipVia, @PaymentsApplied, @InvoiceCOS, @PRONumber, @SpecialInstructions, @DropShipPONumber, @SalesTax2, @SalesTax3, @ReprintBatch, @CustomerClass, @FOB, @ShippingMethod, @ThirdPartyShipper)", con)

            With cmd.Parameters
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = 0
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
                .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@BTAddress1", SqlDbType.VarChar).Value = txtBTAddress1.Text
                .Add("@BTAddress2", SqlDbType.VarChar).Value = txtBTAddress2.Text
                .Add("@BTCity", SqlDbType.VarChar).Value = txtBTCity.Text
                .Add("@BTState", SqlDbType.VarChar).Value = cboBTState.Text
                .Add("@BTZip", SqlDbType.VarChar).Value = txtBTZip.Text
                .Add("@BTCountry", SqlDbType.VarChar).Value = txtBTCountry.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@BilledFreight", SqlDbType.VarChar).Value = BilledFreight
                .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                .Add("@Discount", SqlDbType.VarChar).Value = DiscountAmount
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "BILL ONLY"
                .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                .Add("@PaymentsApplied", SqlDbType.VarChar).Value = 0
                .Add("@InvoiceCOS", SqlDbType.VarChar).Value = HeaderExtendedCOS
                .Add("@PRONumber", SqlDbType.VarChar).Value = txtProNumber.Text
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2
                .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3
                .Add("@ReprintBatch", SqlDbType.VarChar).Value = ""
                .Add("@CustomerClass", SqlDbType.VarChar).Value = cboCustomerClass.Text
                .Add("@FOB", SqlDbType.VarChar).Value = cboConsignmentWarehouse.Text
                .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            cmd = New SqlCommand("Update InvoiceHeaderTable SET InvoiceDate = @InvoiceDate, SalesOrderNumber = @SalesOrderNumber, ShipmentNumber = @ShipmentNumber, CustomerID = @CustomerID, CustomerPO = @CustomerPO, PaymentTerms = @PaymentTerms, Comment = @Comment, BTAddress1 = @btAddress1, BTAddress2 = @BTAddress2, BTCity = @BTCity, BTState = @BTState, BTZip = @BTZip, BTCountry = @BTCountry, ProductTotal = @ProductTotal, BilledFreight = @BilledFreight, SalesTax = @SalesTax, Discount = @Discount, InvoiceTotal = @InvoiceTotal, InvoiceStatus = @InvoiceStatus, ShipVia = @ShipVia, PaymentsApplied = @PaymentsApplied, InvoiceCOS = @InvoiceCOS, PRONumber = @PRONumber, SpecialInstructions = @SpecialInstructions, DropShipPONumber = @DropShipPONumber, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3, ReprintBatch = @ReprintBatch, CustomerClass = @CustomerClass, FOB = @FOB, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper WHERE InvoiceNumber = @InvoiceNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = 0
                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
                .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                .Add("@BTAddress1", SqlDbType.VarChar).Value = txtBTAddress1.Text
                .Add("@BTAddress2", SqlDbType.VarChar).Value = txtBTAddress2.Text
                .Add("@BTCity", SqlDbType.VarChar).Value = txtBTCity.Text
                .Add("@BTState", SqlDbType.VarChar).Value = cboBTState.Text
                .Add("@BTZip", SqlDbType.VarChar).Value = txtBTZip.Text
                .Add("@BTCountry", SqlDbType.VarChar).Value = txtBTCountry.Text
                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                .Add("@BilledFreight", SqlDbType.VarChar).Value = BilledFreight
                .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                .Add("@Discount", SqlDbType.VarChar).Value = DiscountAmount
                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "BILL ONLY"
                .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                .Add("@PaymentsApplied", SqlDbType.VarChar).Value = 0
                .Add("@InvoiceCOS", SqlDbType.VarChar).Value = HeaderExtendedCOS
                .Add("@PRONumber", SqlDbType.VarChar).Value = txtProNumber.Text
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2
                .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3
                .Add("@ReprintBatch", SqlDbType.VarChar).Value = ""
                .Add("@CustomerClass", SqlDbType.VarChar).Value = cboCustomerClass.Text
                .Add("@FOB", SqlDbType.VarChar).Value = cboConsignmentWarehouse.Text
                .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdParty.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboInvoiceNumber.Text = "" Or Not IsNumeric(cboInvoiceNumber.Text) Then
            MsgBox("You must have a valid Invoice Number selected.", MsgBoxStyle.OkOnly)
        Else
            If isSomeoneEditing() Then
                Exit Sub
            End If

            LockBatch()

            'Prompt before Saving
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Invoice?", "SAVE INVOICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then

                'Validate Payment Terms
                ValidatePaymentTerms()

                If CheckPaymentTerms = 0 Then
                    MsgBox("Invalid payment terms.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '***********************************************************************************
                'Load Totals and date
                If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And chkRemoveAllTaxes.Checked = False Then
                    CalculateCanadianTotals()
                    BatchDate = dtpInvoiceDate.Value
                    InvoiceDate = dtpInvoiceDate.Value
                    ShipmentDate = dtpShipDate.Value
                ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And chkRemoveAllTaxes.Checked = True Then
                    BatchDate = dtpInvoiceDate.Value
                    InvoiceDate = dtpInvoiceDate.Value
                    ShipmentDate = dtpShipDate.Value
                    SalesTax = 0
                    SalesTax2 = 0
                    SalesTax3 = 0
                    InvoiceTotal = BilledFreight + ProductTotal
                Else
                    CalculateTotals()
                    BatchDate = dtpInvoiceDate.Value
                    InvoiceDate = dtpInvoiceDate.Value
                    ShipmentDate = dtpShipDate.Value
                End If
                '**************************************************************************************
                If cboShipVia.Text = "" Then
                    ShipVia = "DELIVERY"
                Else
                    ShipVia = cboShipVia.Text
                End If
                '**************************************************************************************
                'Validate FOB and Customer Class
                ValidateFOBandCustomerClass()
                '**************************************************************************************
                'Save data in Invoice Header Table
                SaveUpdateAndInsertCommand()

                updateBatchAmount("InvoiceBillOnly - cmdSave_Click --")

                MsgBox("Invoice has been saved.", MsgBoxStyle.OkOnly)

                ShowData()
                cboInvoiceNumber.Focus()
            ElseIf button = DialogResult.No Then
                cboInvoiceNumber.Focus()
            End If
        End If
    End Sub

    Public Sub ValidateFOBandCustomerClass()
        If cboCustomerClass.Text = "" Then
            LoadCustomerClassFromCustomer()
        End If

        If cboConsignmentWarehouse.Text = "" Then
            cboConsignmentWarehouse.Text = "Standard"
        End If
    End Sub

    Private Sub SaveInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveInvoiceToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub ClearInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearInvoiceToolStripMenuItem.Click
        cmdClearAll_Click(sender, e)
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If isSomeoneEditing() Then
            Exit Sub
        End If

        'Prompt before Deleting
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Invoice?", "DELETE INVOICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Write to Audit Trail Table
            Dim AuditComment As String = ""
            Dim AuditInvoiceNumber As Integer = 0
            Dim strInvoiceNumber As String = ""

            AuditInvoiceNumber = Val(cboInvoiceNumber.Text)
            strInvoiceNumber = CStr(AuditInvoiceNumber)
            AuditComment = "Invoice #" + strInvoiceNumber + " for customer " + cboCustomerName.Text + " was deleted on " + Today()

            Try
                cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "INVOICE BILL ONLY - DELETION"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strInvoiceNumber
                    .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try
         
            'Delete Invoice and Batch
            Try
                cmd = New SqlCommand("DELETE FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID AND BatchStatus <> @BatchStatus", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Write to error log
                Dim TempBatchNumber As Integer = 0
                Dim strBatchNumber As String
                TempBatchNumber = Val(txtBatchNumber.Text)
                strBatchNumber = CStr(TempBatchNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Invoice Bill Only --- Delete Batch Header"
                ErrorReferenceNumber = "Batch # " + strBatchNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            Try
                cmd = New SqlCommand("DELETE FROM InvoiceHeaderTable WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID AND InvoiceStatus = @InvoiceStatus", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "BILL ONLY"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Log error on update failure
                Dim TempInvoiceNumber As Integer = 0
                Dim strInvoiceNumber1 As String = ""
                TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                strInvoiceNumber1 = CStr(TempInvoiceNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Bill Only --- DELETE Header"
                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber1
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try

            'Reset form
            MsgBox("Invoice has been deleted.", MsgBoxStyle.OkOnly)
            cboInvoiceNumber.Text = ""
            ClearVariables()
            ClearData()
            LoadInvoiceNumber()
            ClearDataInDatagrid()
            cboInvoiceNumber.Focus()
        ElseIf button = DialogResult.No Then
            cboInvoiceNumber.Focus()
        End If
    End Sub

    Private Sub DeleteInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteInvoiceToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        'Save Invoice before printing
        If canPrint() Then
            'Load Totals and date
            If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And chkRemoveAllTaxes.Checked = False Then
                CalculateCanadianTotals()
                BatchDate = dtpInvoiceDate.Value
                InvoiceDate = dtpInvoiceDate.Value
                ShipmentDate = dtpShipDate.Value
            ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And chkRemoveAllTaxes.Checked = True Then
                BatchDate = dtpInvoiceDate.Value
                InvoiceDate = dtpInvoiceDate.Value
                ShipmentDate = dtpShipDate.Value
                SalesTax = 0
                SalesTax2 = 0
                SalesTax3 = 0
                InvoiceTotal = BilledFreight + ProductTotal
            Else
                CalculateTotals()
                BatchDate = dtpInvoiceDate.Value
                InvoiceDate = dtpInvoiceDate.Value
                ShipmentDate = dtpShipDate.Value
            End If
            '****************************************************************

            If cboShipVia.Text = "" Then
                ShipVia = "DELIVERY"
            Else
                ShipVia = cboShipVia.Text
            End If
            '****************************************************************
            If Not isSomeoneEditing() Then
                LockBatch()

                'Validate Payment Terms
                ValidatePaymentTerms()

                If CheckPaymentTerms = 0 Then
                    MsgBox("Invalid payment terms.", MsgBoxStyle.OkOnly)
                    Exit Sub
                Else
                    'Continue
                End If
                '***********************************************************************************
                ValidateFOBandCustomerClass()

                'Save data in Invoice Header Table
                SaveUpdateAndInsertCommand()
            End If

            Dim CustomerEmail As String = ""

            Dim CustomerEmailStatement As String = "SELECT APEmailAddress FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
            Dim CustomerEmailCommand As New SqlCommand(CustomerEmailStatement, con)
            CustomerEmailCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            CustomerEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CustomerEmail = CStr(CustomerEmailCommand.ExecuteScalar)
            Catch ex As Exception
                CustomerEmail = ""
            End Try
            con.Close()

            updateBatchAmount("InvoiceBillOnly - cmdPrint_Click --")

            ShowData()
            cboInvoiceNumber.Focus()

            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                GlobalInvoiceNumber = Val(cboInvoiceNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text
                'Get sring Customer/InvoiceNumber for emails
                EmailInvoiceCustomer = cboCustomerID.Text
                EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                EmailCustomerEmailAddress = CustomerEmail

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
                    Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                        Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                        Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                    End Using
                End If
            Else
                GlobalInvoiceNumber = Val(cboInvoiceNumber.Text)
                GlobalDivisionCode = cboDivisionID.Text
                'Get sring Customer/InvoiceNumber for emails
                EmailInvoiceCustomer = cboCustomerID.Text
                EmailStringInvoiceNumber = CStr(GlobalInvoiceNumber)
                EmailCustomerEmailAddress = CustomerEmail

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
                    Using NewPrintInvoiceBillOnlyRemote As New PrintInvoiceBillOnlyRemote
                        Dim result = NewPrintInvoiceBillOnlyRemote.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                        Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Private Function canPrint() As Boolean
        If String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
            MessageBox.Show("You must enter an invoice number", "Enter and invoice number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInvoiceNumber.Focus()
            Return False
        End If
        If cboInvoiceNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid invoice number", "Enter a valid invoice number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInvoiceNumber.SelectAll()
            cboInvoiceNumber.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MessageBox.Show("You must select a customer ID", "Select a customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.Focus()
            Return False
        End If
        If cboCustomerID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid customer ID", "Enter a valid customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.SelectAll()
            cboCustomerID.Focus()
            Return False
        End If
        If dgvInvoiceLines.Rows.Count = 0 Then
            MessageBox.Show("You must enter at least 1 line in the invoice to print", "Enter a line to print", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub PrintInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintInvoiceToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub cmdPostInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostInvoice.Click
        If canPost() Then
            '******************************************************************************************************
            'Validate Lines
            Dim CountInvoiceLines As Integer = 0

            Dim CountInvoiceLinesStatement As String = "SELECT COUNT(InvoiceHeaderKey) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND DivisionID = @DivisionID"
            Dim CountInvoiceLinesCommand As New SqlCommand(CountInvoiceLinesStatement, con)
            CountInvoiceLinesCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            CountInvoiceLinesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountInvoiceLines = CInt(CountInvoiceLinesCommand.ExecuteScalar)
            Catch ex As Exception
                CountInvoiceLines = 0
            End Try
            con.Close()

            If CountInvoiceLines = 0 Then
                MsgBox("This Invoice has no line data.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Do nothing
            End If
            '******************************************************************************************************
            'Validate Payment Terms
            ValidatePaymentTerms()

            If CheckPaymentTerms = 0 Then
                MsgBox("Invalid payment terms.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If
            '*******************************************************************************************************
            Dim SumInvoiceNumber As Integer = 0

            Dim SumInvoiceNumberStatement As String = "SELECT COUNT(GLTransactionKey) From GLTransactionMasterList WHERE GLReferenceNumber = @GLReferenceNumber AND DivisionID = @DivisionID"
            Dim SumInvoiceNumberCommand As New SqlCommand(SumInvoiceNumberStatement, con)
            SumInvoiceNumberCommand.Parameters.Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
            SumInvoiceNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumInvoiceNumber = CInt(SumInvoiceNumberCommand.ExecuteScalar)
            Catch ex As Exception
                SumInvoiceNumber = 0
            End Try
            con.Close()

            If SumInvoiceNumber = 0 Then
                'Skip and continue
            Else
                MsgBox("This invoice has already been posted to the G/L.", MsgBoxStyle.OkOnly)
                '***************************************************************************************************
                'Close Invoice and write to error log
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceStatus = @InvoiceStatus WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***************************************************************************************************
                'Update Batch Header Table
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchAmount = @BatchAmount, BatchStatus = @BatchStatus, UserID = @UserID WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                '***************************************************************************************************
                'Write to error log
                Dim TempInvoiceNumber As Integer = 0
                Dim strInvoiceNumber As String
                TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                strInvoiceNumber = CStr(TempInvoiceNumber)

                ErrorDate = Today()
                ErrorComment = "Invoice already posted to G/L"
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Invoice Bill Only --- Autoclose Invoice"
                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                ClearData()
                ClearVariables()
                ClearDataInDatagrid()

                Exit Sub
            End If
            '******************************************************************************************************
            If EmployeeSecurityCode = "1001" Or EmployeeSecurityCode = "1002" Then
                'Skip Date Validation
            Else
                'Validate Date
                Dim CurrentDate, TodaysDate As Date
                Dim MonthOfYear, YearOfYear, TodaysMonthOfYear, TodaysYearOfYear As Integer

                TodaysDate = Today()
                CurrentDate = dtpInvoiceDate.Value

                MonthOfYear = CurrentDate.Month
                YearOfYear = CurrentDate.Year
                TodaysMonthOfYear = TodaysDate.Month
                TodaysYearOfYear = TodaysDate.Year

                'If TodaysYearOfYear - YearOfYear > 1 Then
                '    MsgBox("You cannot post an Invoice to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear < 5 And (TodaysMonthOfYear >= 1 And TodaysMonthOfYear < 5) Then
                '    MsgBox("You cannot post an Invoice to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'ElseIf TodaysYearOfYear - YearOfYear = 1 And MonthOfYear > 5 And (TodaysMonthOfYear >= 5 And TodaysMonthOfYear <= 12) Then
                '    MsgBox("You cannot post an Invoice to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'ElseIf TodaysYearOfYear - YearOfYear = 0 And MonthOfYear < 5 And TodaysMonthOfYear >= 5 Then
                '    MsgBox("You cannot post an Invoice to a prior Fiscal Year.", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'ElseIf TodaysYearOfYear - YearOfYear < 0 Then
                '    MsgBox("You cannot post an Invoice to a future period.", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'ElseIf TodaysYearOfYear - YearOfYear = 0 And TodaysMonthOfYear < MonthOfYear Then
                '    MsgBox("You cannot post an Invoice to a future period.", MsgBoxStyle.OkOnly)
                '    Exit Sub
                'Else
                '    'Date is okay --- Continue
                'End If
            End If
            '***********************************************************************************************************
            'Load Totals and date
            If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And chkRemoveAllTaxes.Checked = False Then
                CalculateCanadianTotals()
                BatchDate = dtpInvoiceDate.Value
                InvoiceDate = dtpInvoiceDate.Value
                ShipmentDate = dtpShipDate.Value
            ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And chkRemoveAllTaxes.Checked = True Then
                BatchDate = dtpInvoiceDate.Value
                InvoiceDate = dtpInvoiceDate.Value
                ShipmentDate = dtpShipDate.Value
                SalesTax = 0
                SalesTax2 = 0
                SalesTax3 = 0
                InvoiceTotal = BilledFreight + ProductTotal
            Else
                CalculateTotals()
                BatchDate = dtpInvoiceDate.Value
                InvoiceDate = dtpInvoiceDate.Value
                ShipmentDate = dtpShipDate.Value
            End If
            '******************************************************************************************************
            If cboShipVia.Text = "" Then
                ShipVia = "DELIVERY"
            Else
                ShipVia = cboShipVia.Text
            End If
            '******************************************************************************************************
            'Validate FOB and Customer Class
            ValidateFOBandCustomerClass()
            '******************************************************************************************************
            'Save data in Invoice Header Table
            SaveUpdateAndInsertCommand()
            '******************************************************************************************************
            'UPDATE Batch Number Table
            Try
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchAmount = @BatchAmount, BatchStatus = @BatchStatus, UserID = @UserID, PrintDate = @PrintDate WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@BatchAmount", SqlDbType.VarChar).Value = InvoiceTotal
                    .Add("@BatchStatus", SqlDbType.VarChar).Value = "POSTED"
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Write to error log
                Dim TempInvoiceNumber As Integer = 0
                Dim strInvoiceNumber As String
                TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                strInvoiceNumber = CStr(TempInvoiceNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Invoice Bill Only --- Update Batch Status on post"
                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '******************************************************************************************************

            '**********************************
            'Write to General Ledger
            '**********************************
            'Load FOB for Consignment Warehouse purposes
            FOB = cboConsignmentWarehouse.Text
            InvoiceBatchNumber = Val(txtBatchNumber.Text)

            Dim PostDivision As String = ""

            If cboDivisionID.Text = "TFP" Then
                PostDivision = "TWD"
            Else
                PostDivision = cboDivisionID.Text
            End If

            CustomerClass = cboCustomerClass.Text
            '*******************************************************************************************************
            If BilledFreight > 0 Then
                'Select GL Account based on Customer Class
                If CustomerClass = "CANADIAN" And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
                    FreightGLAccount = "C$49500"
                    ARGLAccount = "C$11000"
                Else
                    FreightGLAccount = "49500"
                    ARGLAccount = "11000"
                End If
                '****************************************************************************************************
                Try
                    'Command to write Freight Charges to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = BilledFreight
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Invoice Bill Only - G/L Posting (Freight Credit)"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '****************************************************************************************************
                Try
                    'Command to write Freight Charges to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = BilledFreight
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Invoice Bill Only - G/L Posting (Freight Debit)"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            ElseIf BilledFreight < 0 Then
                'Select GL Account based on Customer Class
                If CustomerClass = "CANADIAN" And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
                    FreightGLAccount = "C$49500"
                    ARGLAccount = "C$11000"
                Else
                    FreightGLAccount = "49500"
                    ARGLAccount = "11000"
                End If
                '****************************************************************************************************
                Try
                    'Command to write Freight Charges to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = FreightGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = BilledFreight * -1
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed (Credit)"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Invoice Bill Only - G/L Posting (Freight Debit)"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '**************************************************************************************************
                Try
                    'Command to write Freight Charges to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = BilledFreight * -1
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Freight Charges Billed (Credit)"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Invoice Bill Only - G/L Posting (Freight Credit)"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'No freight written to GL
            End If
            '*********************************************************************************************************************
            'Write sales tax to GL - if Canadian, sales tax is GST
            If SalesTax > 0 Then
                'Select GL Account based on Customer Class
                If CustomerClass = "CANADIAN" And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
                    SalesTaxGLAccount = "C$23100"
                    ARGLAccount = "C$11000"
                ElseIf CustomerClass = "AMERICAN" And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
                    SalesTaxGLAccount = "23100"
                    ARGLAccount = "11000"
                Else
                    SalesTaxGLAccount = "25000"
                    ARGLAccount = "11000"
                End If
                '*******************************************************************************************************
                Try
                    'Command to write Sales Tax to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTax
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Invoice Bill Only - G/L Posting (Tax Credit)"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '********************************************************************************************************
                Try
                    'Command to write Sales Tax to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTax
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Invoice Bill Only - G/L Posting (Tax Debit)"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            ElseIf SalesTax < 0 Then
                'Select GL Account based on Customer Class
                If CustomerClass = "CANADIAN" And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
                    SalesTaxGLAccount = "C$23100"
                    ARGLAccount = "C$11000"
                ElseIf CustomerClass = "AMERICAN" And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
                    SalesTaxGLAccount = "23100"
                    ARGLAccount = "11000"
                Else
                    SalesTaxGLAccount = "25000"
                    ARGLAccount = "11000"
                End If
                '*******************************************************************************************************
                Try
                    'Command to write Sales Tax to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = SalesTax * -1
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected (Credit)"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Invoice Bill Only - G/L Posting (Tax Debit)"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '**************************************************************************************************************
                Try
                    'Command to write Sales Tax to GL
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = SalesTax * -1
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected (Credit)"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Invoice Bill Only - G/L Posting (Tax Credit)"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
            Else
                'Continue - no sales tax
            End If
            '*********************************************************************************************************************
            'Routine to write PST and HST to GL, if applicable
            If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
                If PSTTotal > 0 Then
                    'Select GL Account based on Customer Class
                    If CustomerClass = "CANADIAN" Then
                        SalesTaxGLAccount = "C$23150"
                        ARGLAccount = "C$11000"
                    Else
                        SalesTaxGLAccount = "23150"
                        ARGLAccount = "11000"
                    End If
                    '*************************************************************************************************************
                    Try
                        'Command to write Sales Tax to GL
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxGLAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = PSTTotal
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - PST"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String
                        TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Invoice Bill Only - G/L Posting (PST Credit)"
                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '*****************************************************************************************************************
                    Try
                        'Command to write Sales Tax to GL
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARGLAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = PSTTotal
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - PST"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String
                        TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Invoice Bill Only - G/L Posting (PST Debit)"
                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                ElseIf PSTTotal < 0 Then
                    'Select GL Account based on Customer Class
                    If CustomerClass = "CANADIAN" Then
                        SalesTaxGLAccount = "C$23150"
                        ARGLAccount = "C$11000"
                    Else
                        SalesTaxGLAccount = "23150"
                        ARGLAccount = "11000"
                    End If
                    '**********************************************************************************************
                    Try
                        'Command to write Sales Tax to GL
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxGLAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = PSTTotal * -1
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - PST (Credit)"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String
                        TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Invoice Bill Only - G/L Posting (PST Debit)"
                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '**********************************************************************************************
                    Try
                        'Command to write Sales Tax to GL
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARGLAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = PSTTotal * -1
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - PST (Credit)"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String
                        TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Invoice Bill Only - G/L Posting (PST Credit)"
                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                Else
                    'Continue - no PST
                End If
                '******************************************************************************************************
                If HSTTotal > 0 Then
                    'Select GL Account based on Customer Class
                    If CustomerClass = "CANADIAN" Then
                        SalesTaxGLAccount = "C$23120"
                        ARGLAccount = "C$11000"
                    Else
                        SalesTaxGLAccount = "23120"
                        ARGLAccount = "11000"
                    End If
                    '******************************************************************************************************
                    Try
                        'Command to write Sales Tax to GL
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxGLAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = HSTTotal
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - HST"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String
                        TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Invoice Bill Only - G/L Posting (HST Credit)"
                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '******************************************************************************************************
                    Try
                        'Command to write Sales Tax to GL
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARGLAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = HSTTotal
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - HST"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String
                        TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Invoice Bill Only - G/L Posting (HST Debit)"
                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                ElseIf HSTTotal < 0 Then
                    'Select GL Account based on Customer Class
                    If CustomerClass = "CANADIAN" Then
                        SalesTaxGLAccount = "C$23120"
                        ARGLAccount = "C$11000"
                    Else
                        SalesTaxGLAccount = "23120"
                        ARGLAccount = "11000"
                    End If
                    '******************************************************************************************************
                    Try
                        'Command to write Sales Tax to GL
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = SalesTaxGLAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = HSTTotal * -1
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - HST (Credit)"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String
                        TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Invoice Bill Only - G/L Posting (HST Debit)"
                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                    '******************************************************************************************************
                    Try
                        'Command to write Sales Tax to GL
                        cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                        With cmd.Parameters
                            '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                            .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARGLAccount
                            .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                            .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                            .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = HSTTotal * -1
                            .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Sales Tax Collected - HST (Credit)"
                            .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                            .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                            .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                            .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                            .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        'Write to error log
                        Dim TempInvoiceNumber As Integer = 0
                        Dim strInvoiceNumber As String
                        TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                        strInvoiceNumber = CStr(TempInvoiceNumber)

                        ErrorDate = Today()
                        ErrorComment = ex.ToString()
                        ErrorDivision = cboDivisionID.Text
                        ErrorDescription = "Invoice Bill Only - G/L Posting (HST Credit)"
                        ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()
                    End Try
                Else
                    'Continue - no HST
                End If
            Else
                'Skip routine - only for Canada
            End If
            '*********************************************************************************************************************
            'Invoice line item routine
            '*********************************************************************************************************************
            'Count the number of line items
            Dim CountLineStatement As String = "SELECT COUNT(InvoiceHeaderKey) FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey"
            Dim CountLineCommand As New SqlCommand(CountLineStatement, con)
            CountLineCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountLineNumber = CInt(CountLineCommand.ExecuteScalar)
            Catch ex As Exception
                CountLineNumber = 1
            End Try
            con.Close()

            'Initialize first line number
            InvoiceLine = 1

            'Writes Line GL Entries for each Invoice to the GL
            For i As Integer = 1 To CountLineNumber

                'Extract data from Invoice Line Table
                Dim ExtendedAmountStatement As String = "SELECT * FROM InvoiceLineTable WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey"
                Dim ExtendedAmountCommand As New SqlCommand(ExtendedAmountStatement, con)
                ExtendedAmountCommand.Parameters.Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                ExtendedAmountCommand.Parameters.Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = ExtendedAmountCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.Item("ExtendedAmount")) Then
                        ExtendedAmount = 0
                    Else
                        ExtendedAmount = reader.Item("ExtendedAmount")
                    End If
                    If IsDBNull(reader.Item("PartNumber")) Then
                        PartNumber = ""
                    Else
                        PartNumber = reader.Item("PartNumber")
                    End If
                    If IsDBNull(reader.Item("DebitGLAccount")) Then
                        DebitGLAccount = ""
                    Else
                        DebitGLAccount = reader.Item("DebitGLAccount")
                    End If
                    If IsDBNull(reader.Item("CreditGLAccount")) Then
                        CreditGLAccount = ""
                    Else
                        CreditGLAccount = reader.Item("CreditGLAccount")
                    End If
                    If IsDBNull(reader.Item("QuantityBilled")) Then
                        QuantityShipped = 0
                    Else
                        QuantityShipped = reader.Item("QuantityBilled")
                    End If
                    If IsDBNull(reader.Item("PartDescription")) Then
                        PartDescription = ""
                    Else
                        PartDescription = reader.Item("PartDescription")
                    End If
                    If IsDBNull(reader.Item("Price")) Then
                        Price = 0
                    Else
                        Price = reader.Item("Price")
                    End If
                Else
                    ExtendedAmount = 0
                    PartNumber = ""
                    DebitGLAccount = ""
                    CreditGLAccount = ""
                    QuantityShipped = 0
                    PartDescription = ""
                    Price = 0
                End If
                reader.Close()
                con.Close()
                '*******************************************************************************************************
                'Extract GL Account Numbers for Revenues and AR Accounts by Item Class
                Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
                ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber
                ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ItemClass = CStr(ItemClassCommand.ExecuteScalar)
                Catch ex As Exception
                    ItemClass = ""
                End Try
                con.Close()
                '*******************************************************************************************************
                Dim RevenueGLAccountStatement As String = "SELECT GLSalesAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
                Dim RevenueGLAccountCommand As New SqlCommand(RevenueGLAccountStatement, con)
                RevenueGLAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass
                RevenueGLAccountCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    RevenueGLAccount = CStr(RevenueGLAccountCommand.ExecuteScalar)
                Catch ex As Exception
                    RevenueGLAccount = "41000"
                End Try
                con.Close()
                '*******************************************************************************************************
                'Determine Clearing Account for specific location
                If cboDivisionID.Text = "TWD" Or cboDivisionID.Text = "TST" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TWE" Then
                    If CustomerClass = "STANDARD" Then
                        DebitGLAccount = "49999"
                    ElseIf CustomerClass = "HCW" Then
                        DebitGLAccount = "12600"
                        RevenueGLAccount = "42600"
                        COSGLAccount = "52600"
                    ElseIf CustomerClass = "BCW" Then
                        DebitGLAccount = "12610"
                        RevenueGLAccount = "42610"
                        COSGLAccount = "52610"
                    ElseIf CustomerClass = "YCW" Then
                        DebitGLAccount = "12620"
                        RevenueGLAccount = "42620"
                        COSGLAccount = "52620"
                    ElseIf CustomerClass = "DCW" Then
                        DebitGLAccount = "12630"
                        RevenueGLAccount = "42630"
                        COSGLAccount = "52630"
                    ElseIf CustomerClass = "SCW" Then
                        DebitGLAccount = "12640"
                        RevenueGLAccount = "42640"
                        COSGLAccount = "52640"
                    ElseIf CustomerClass = "WCW" Then
                        DebitGLAccount = "12650"
                        RevenueGLAccount = "42650"
                        COSGLAccount = "52650"
                    ElseIf CustomerClass = "PCW" Then
                        DebitGLAccount = "12660"
                        RevenueGLAccount = "42660"
                        COSGLAccount = "52660"
                    ElseIf CustomerClass = "SRL" Then
                        DebitGLAccount = "12670"
                        RevenueGLAccount = "42670"
                        COSGLAccount = "52670"
                    ElseIf CustomerClass = "REMOTE" Then
                        DebitGLAccount = "12700"
                        RevenueGLAccount = "42700"
                        COSGLAccount = "52700"
                    Else
                        DebitGLAccount = "49999"
                    End If
                End If
                '*******************************************************************************************************
                'Write Line entries to GL Transaction Table

                'If division is TFF, get appropriate GL Account based on Customer Class
                'Select GL Account based on Customer Class
                If CustomerClass = "CANADIAN" And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
                    RevenueGLAccount = "C$" & RevenueGLAccount
                    ARGLAccount = "C$11000"
                ElseIf CustomerClass = "AMERICAN" And (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") Then
                    'Revenue Account is correct
                    ARGLAccount = "11000"
                Else
                    'Revenue Account is correct
                    ARGLAccount = "11000"
                End If
                '*******************************************************************************************************
                'Command to write Line Amount to GL - Sales/AR
                Try
                    'Insert into GL Transaction  - Debit Amount
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = ARGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = ExtendedAmount
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "ARJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Invoice Bill Only - G/L Posting Line Data (Debit)"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '***********************************************************************************************************************
                Try
                    'Command to write LineAmount to GL - Sales/AR
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextLineGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = RevenueGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Invoice Processing"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = InvoiceDate
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = ExtendedAmount
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "Invoice Line Data"
                        .Add("@DivisionID", SqlDbType.VarChar).Value = PostDivision
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "SALESJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = InvoiceBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = InvoiceLine
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Invoice Bill Only - G/L Posting Line Data (Credit)"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*******************************************************************************************************
                'Update COS to Invoice Line Table
                Try
                    cmd = New SqlCommand("UPDATE InvoiceLineTable SET ExtendedCOS = @ExtendedCOS, LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey AND InvoiceLineKey = @InvoiceLineKey", con)

                    With cmd.Parameters
                        .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                        .Add("@InvoiceLineKey", SqlDbType.VarChar).Value = InvoiceLine
                        .Add("@ExtendedCOS", SqlDbType.VarChar).Value = 0
                        .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    'Write to error log
                    Dim TempInvoiceNumber As Integer = 0
                    Dim strInvoiceNumber As String
                    TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                    strInvoiceNumber = CStr(TempInvoiceNumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Invoice Bill Only - Update line COS on post"
                    ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try
                '*******************************************************************************************************
                InvoiceLine = InvoiceLine + 1
            Next i
            '*******************************************************************************************************

            'Update Invoice Header Status
            Try
                cmd = New SqlCommand("UPDATE InvoiceHeaderTable SET InvoiceStatus = @InvoiceStatus, InvoiceCOS = @InvoiceCOS WHERE InvoiceNumber = @InvoiceNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "OPEN"
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@InvoiceCOS", SqlDbType.VarChar).Value = 0
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Write to error log
                Dim TempInvoiceNumber As Integer = 0
                Dim strInvoiceNumber As String
                TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                strInvoiceNumber = CStr(TempInvoiceNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Invoice Bill Only - error Update Invoice Header to posted"
                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '*******************************************************************************************************
            'Update Invoice Line Status
            Try
                cmd = New SqlCommand("UPDATE InvoiceLineTable SET LineStatus = @LineStatus WHERE InvoiceHeaderKey = @InvoiceHeaderKey", con)

                With cmd.Parameters
                    .Add("@InvoiceHeaderKey", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Write to error log
                Dim TempInvoiceNumber As Integer = 0
                Dim strInvoiceNumber As String
                TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                strInvoiceNumber = CStr(TempInvoiceNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Invoice Bill Only - update Invoice lines to open on post"
                ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
            '**********************************
            'End of Ledger Entry
            '**********************************

            unlockBatch()

            'Clear and reset Form
            isloaded = False
            LoadInvoiceNumber()
            ClearVariables()
            ClearData()
            ClearDataInDatagrid()
            isloaded = True

            MsgBox("Invoice has been posted.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Function canPost() As Boolean
        If String.IsNullOrEmpty(cboInvoiceNumber.Text) Then
            MessageBox.Show("You must enter an invoice number", "Enter an invoice number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInvoiceNumber.Focus()
            Return False
        End If
        If cboInvoiceNumber.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid invoice number", "Enter valid invoice number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInvoiceNumber.SelectAll()
            cboInvoiceNumber.Focus()
            Return False
        End If
        If isSomeoneEditing() Then
            Return False
        End If
        If String.IsNullOrEmpty(cboCustomerID.Text) Then
            MessageBox.Show("You must have a customer selected", "Select a customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.Focus()
            Return False
        End If
        If cboCustomerID.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid customer ID", "Enter a valid customer ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCustomerID.SelectAll()
            cboCustomerID.Focus()
            Return False
        End If
        Dim button As DialogResult = MessageBox.Show("Do you wish to POST this Invoice?", "POST INVOICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'Form Logout
        FormLogoutRoutine()

        If cboInvoiceNumber.Text = "" Then
            ClearVariables()
            ClearData()
            ClearDataInDatagrid()
            Me.Dispose()
            Me.Close()
        Else
            If isSomeoneEditing() Then
                ClearVariables()
                ClearData()
                ClearDataInDatagrid()
                Me.Dispose()
                Me.Close()
            End If
            'Prompt before Saving
            Dim button As DialogResult = MessageBox.Show("Do you wish to save this Invoice?", "SAVE INVOICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                If cboCustomerID.Text = "" Or Not IsNumeric(cboInvoiceNumber.Text) Then
                    MsgBox("You must have a valid Invoice Number / Customer selected.", MsgBoxStyle.OkOnly)
                Else
                    '****************************************************************************************************
                    'Load Totals and date
                    If (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And chkRemoveAllTaxes.Checked = False Then
                        CalculateCanadianTotals()
                        BatchDate = dtpInvoiceDate.Value
                        InvoiceDate = dtpInvoiceDate.Value
                        ShipmentDate = dtpShipDate.Value
                    ElseIf (cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB") And chkRemoveAllTaxes.Checked = True Then
                        BatchDate = dtpInvoiceDate.Value
                        InvoiceDate = dtpInvoiceDate.Value
                        ShipmentDate = dtpShipDate.Value
                        SalesTax = 0
                        SalesTax2 = 0
                        SalesTax3 = 0
                        InvoiceTotal = BilledFreight + ProductTotal
                    Else
                        CalculateTotals()
                        BatchDate = dtpInvoiceDate.Value
                        InvoiceDate = dtpInvoiceDate.Value
                        ShipmentDate = dtpShipDate.Value
                    End If
                    '****************************************************************************************************
                    If cboShipVia.Text = "" Then
                        ShipVia = "DELIVERY"
                    Else
                        ShipVia = cboShipVia.Text
                    End If
                    '****************************************************************************************************
                    'Validate Payment Terms
                    ValidatePaymentTerms()

                    If CheckPaymentTerms = 0 Then
                        MsgBox("Invalid payment terms.", MsgBoxStyle.OkOnly)
                        Exit Sub
                    Else
                        'Continue
                    End If
                    '***********************************************************************************
                    'Save data in Invoice Header Table
                    Try
                        cmd = New SqlCommand("INSERT INTO InvoiceHeaderTable (InvoiceNumber, BatchNumber, InvoiceDate, SalesOrderNumber, ShipmentNumber, DivisionID, CustomerID, CustomerPO, PaymentTerms, Comment, BTAddress1, BTAddress2, BTCity, BTState, BTZip, BTCountry, ProductTotal, BilledFreight, SalesTax, Discount, InvoiceTotal, InvoiceStatus, ShipVia, PaymentsApplied, InvoiceCOS, PRONumber, SpecialInstructions, DropShipPONumber, SalesTax2, SalesTax3) Values (@InvoiceNumber, @BatchNumber, @InvoiceDate, @SalesOrderNumber, @ShipmentNumber, @DivisionID, @CustomerID, @CustomerPO, @PaymentTerms, @Comment, @BTAddress1, @BTAddress2, @BTCity, @BTState, @BTZip, @BTCountry, @ProductTotal, @BilledFreight, @SalesTax, @Discount, @InvoiceTotal, @InvoiceStatus, @ShipVia, @PaymentsApplied, @InvoiceCOS, @PRONumber, @SpecialInstructions, @DropShipPONumber, @SalesTax2, @SalesTax3)", con)

                        With cmd.Parameters
                            .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                            .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                            .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = 0
                            .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
                            .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                            .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                            .Add("@BTAddress1", SqlDbType.VarChar).Value = txtBTAddress1.Text
                            .Add("@BTAddress2", SqlDbType.VarChar).Value = txtBTAddress2.Text
                            .Add("@BTCity", SqlDbType.VarChar).Value = txtBTCity.Text
                            .Add("@BTState", SqlDbType.VarChar).Value = cboBTState.Text
                            .Add("@BTZip", SqlDbType.VarChar).Value = txtBTZip.Text
                            .Add("@BTCountry", SqlDbType.VarChar).Value = txtBTCountry.Text
                            .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                            .Add("@BilledFreight", SqlDbType.VarChar).Value = BilledFreight
                            .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                            .Add("@Discount", SqlDbType.VarChar).Value = DiscountAmount
                            .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                            .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "BILL ONLY"
                            .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                            .Add("@PaymentsApplied", SqlDbType.VarChar).Value = 0
                            .Add("@InvoiceCOS", SqlDbType.VarChar).Value = HeaderExtendedCOS
                            .Add("@PRONumber", SqlDbType.VarChar).Value = txtProNumber.Text
                            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                            .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                            .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2
                            .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3
                            .Add("@ReprintBatch", SqlDbType.VarChar).Value = ""
                            .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                            .Add("@FOB", SqlDbType.VarChar).Value = cboConsignmentWarehouse.Text
                            .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                            .Add("@ThirdPartShipper", SqlDbType.VarChar).Value = ""
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        Try
                            cmd = New SqlCommand("Update InvoiceHeaderTable SET InvoiceDate = @InvoiceDate, SalesOrderNumber = @SalesOrderNumber, ShipmentNumber = @ShipmentNumber, CustomerID = @CustomerID, CustomerPO = @CustomerPO, PaymentTerms = @PaymentTerms, Comment = @Comment, BTAddress1 = @btAddress1, BTAddress2 = @BTAddress2, BTCity = @BTCity, BTState = @BTState, BTZip = @BTZip, BTCountry = @BTCountry, ProductTotal = @ProductTotal, BilledFreight = @BilledFreight, SalesTax = @SalesTax, Discount = @Discount, InvoiceTotal = @InvoiceTotal, InvoiceStatus = @InvoiceStatus, ShipVia = @ShipVia, PaymentsApplied = @PaymentsApplied, InvoiceCOS = @InvoiceCOS, PRONumber = @PRONumber, SpecialInstructions = @SpecialInstructions, DropShipPONumber = @DropShipPONumber, SalesTax2 = @SalesTax2, SalesTax3 = @SalesTax3 WHERE InvoiceNumber = @InvoiceNumber AND BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)

                            With cmd.Parameters
                                .Add("@InvoiceNumber", SqlDbType.VarChar).Value = Val(cboInvoiceNumber.Text)
                                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                                .Add("@InvoiceDate", SqlDbType.VarChar).Value = InvoiceDate
                                .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = 0
                                .Add("@ShipmentNumber", SqlDbType.VarChar).Value = 0
                                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                                .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPONumber.Text
                                .Add("@PaymentTerms", SqlDbType.VarChar).Value = cboPaymentTerms.Text
                                .Add("@Comment", SqlDbType.VarChar).Value = txtComment.Text
                                .Add("@BTAddress1", SqlDbType.VarChar).Value = txtBTAddress1.Text
                                .Add("@BTAddress2", SqlDbType.VarChar).Value = txtBTAddress2.Text
                                .Add("@BTCity", SqlDbType.VarChar).Value = txtBTCity.Text
                                .Add("@BTState", SqlDbType.VarChar).Value = cboBTState.Text
                                .Add("@BTZip", SqlDbType.VarChar).Value = txtBTZip.Text
                                .Add("@BTCountry", SqlDbType.VarChar).Value = txtBTCountry.Text
                                .Add("@ProductTotal", SqlDbType.VarChar).Value = ProductTotal
                                .Add("@BilledFreight", SqlDbType.VarChar).Value = BilledFreight
                                .Add("@SalesTax", SqlDbType.VarChar).Value = SalesTax
                                .Add("@Discount", SqlDbType.VarChar).Value = DiscountAmount
                                .Add("@InvoiceTotal", SqlDbType.VarChar).Value = InvoiceTotal
                                .Add("@InvoiceStatus", SqlDbType.VarChar).Value = "BILL ONLY"
                                .Add("@ShipVia", SqlDbType.VarChar).Value = ShipVia
                                .Add("@PaymentsApplied", SqlDbType.VarChar).Value = 0
                                .Add("@InvoiceCOS", SqlDbType.VarChar).Value = HeaderExtendedCOS
                                .Add("@PRONumber", SqlDbType.VarChar).Value = txtProNumber.Text
                                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialInstructions.Text
                                .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                                .Add("@SalesTax2", SqlDbType.VarChar).Value = SalesTax2
                                .Add("@SalesTax3", SqlDbType.VarChar).Value = SalesTax3
                                .Add("@ReprintBatch", SqlDbType.VarChar).Value = ""
                                .Add("@CustomerClass", SqlDbType.VarChar).Value = CustomerClass
                                .Add("@FOB", SqlDbType.VarChar).Value = cboConsignmentWarehouse.Text
                                .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                                .Add("@ThirdPartShipper", SqlDbType.VarChar).Value = ""
                            End With

                            If con.State = ConnectionState.Closed Then con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        Catch ex1 As Exception
                            'Log error on update failure
                            Dim TempInvoiceNumber As Integer = 0
                            Dim strInvoiceNumber As String
                            TempInvoiceNumber = Val(cboInvoiceNumber.Text)
                            strInvoiceNumber = CStr(TempInvoiceNumber)

                            ErrorDate = Today()
                            ErrorComment = ex1.ToString()
                            ErrorDivision = cboDivisionID.Text
                            ErrorDescription = "Bill Only --- UPDATE Invoice Header - on Exit"
                            ErrorReferenceNumber = "Invoice # " + strInvoiceNumber
                            ErrorUser = EmployeeLoginName

                            TFPErrorLogUpdate()
                        End Try
                    End Try
                    '****************************************************************************************************
                    'UPDATE Batch Number Table
                    updateBatchAmount("InvoiceBillOnly - cmdExit_Click --")
                    '****************************************************************************************************
                    unlockBatch()
                    ClearVariables()
                    ClearData()
                    ClearDataInDatagrid()
                    Me.Dispose()
                    Me.Close()
                End If
            ElseIf button = DialogResult.No Then
                unlockBatch()
                ClearVariables()
                ClearData()
                ClearDataInDatagrid()
                Me.Dispose()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtLinePrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLinePrice.TextChanged
        If canTotal() Then
            txtLineExtendedAmount.Text = Val(txtLinePrice.Text) * Val(txtLineQuantityBilled.Text)
        End If
    End Sub

    Private Sub txtLineQuantityBilled_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLineQuantityBilled.TextChanged
        If canTotal() Then
            txtLineExtendedAmount.Text = Val(txtLinePrice.Text) * Val(txtLineQuantityBilled.Text)
        End If
    End Sub

    Private Function canTotal() As Boolean
        If String.IsNullOrEmpty(txtLineQuantityBilled.Text) Then
            Return False
        End If
        If String.IsNullOrEmpty(txtLinePrice.Text) Then
            Return False
        End If
        If IsNumeric(txtLineQuantityBilled.Text) = False Then
            Return False
        End If
        If IsNumeric(txtLinePrice.Text) = False Then
            Return False
        End If
        Return True
    End Function

    Private Sub updateBatchAmount(ByVal fromForm As String)
        Try
            cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET BatchAmount = @BatchAmount WHERE BatchNumber = @BatchNumber", con)
            With cmd.Parameters
                .Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
                .Add("@BatchAmount", SqlDbType.VarChar).Value = InvoiceTotal
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Log error on update failure
            Dim TempBatchNumber As Integer = 0
            Dim strBatchNumber As String
            TempBatchNumber = Val(txtBatchNumber.Text)
            strBatchNumber = CStr(TempBatchNumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Bill Only --- Update Batch Header"
            ErrorReferenceNumber = "Batch # " + strBatchNumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Private Function getFifoCost(ByVal part As String) As Double
        'Define Variables used in FIFO
        Dim GetMaxTransactionNumber As Integer
        Dim GetUpperLimit As Double = 0
        Dim UpperLimit As Double = 0
        Dim QuantityRemaining As Double = 0
        Dim NextUpperLimit As Double = 0
        Dim NextLowerLimit As Double = 0
        '******************************************************************************************************************************************
        'Determine FIFO Cost on Part Number to remove from Inventory
        Dim TotalQuantityShipped As Double = 0
        FIFOCost = 0
        FIFOExtendedAmount = 0
        '******************************************************************************************************************************************
        'Determine Total Quantity Shipped
        Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> @Dropship"
        Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
        TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
        TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalQuantityShippedCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = Today.Date.ToString()
        TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalQuantityShipped = 0
        End Try
        con.Close()
        '******************************************************************************************************************************************
        'Check to see if Total Quantity Shipped falls within the Cost Tiers

        Dim GetUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = (SELECT isnull(MAX(TransactionNumber), 0) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID) AND DivisionID = @DivisionID"
        Dim GetUpperLimitCommand As New SqlCommand(GetUpperLimitStatement, con)
        With GetUpperLimitCommand.Parameters
            .Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
        Catch ex As Exception
            GetUpperLimit = 0
        End Try
        con.Close()

        If TotalQuantityShipped > GetUpperLimit Then
            'Item is beyond the Cost Tier - skip FIFO
            FIFOCost = 0
            FIFOExtendedAmount = 0
        Else
            '******************************************************************************************************************************************
            'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
            'Get Max Transaction Number where 
            Dim GetMaxTransactionNumber1Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
            Dim GetMaxTransactionNumber1Command As New SqlCommand(GetMaxTransactionNumber1Statement, con)
            GetMaxTransactionNumber1Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            GetMaxTransactionNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            If TotalQuantityShipped = 0 Then
                GetMaxTransactionNumber1Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = 1
            Else
                GetMaxTransactionNumber1Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
            End If

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GetMaxTransactionNumber = CInt(GetMaxTransactionNumber1Command.ExecuteScalar)
            Catch ex As Exception
                GetMaxTransactionNumber = 0
            End Try
            con.Close()

            If GetMaxTransactionNumber = 0 Then
                Dim ItemCost2Statement As String = "SELECT ItemCost, UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                Dim ItemCost2Command As New SqlCommand(ItemCost2Statement, con)
                ItemCost2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                ItemCost2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                ItemCost2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = Today.Date.ToString()
                If TotalQuantityShipped = 0 Then
                    ItemCost2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = 1
                Else
                    ItemCost2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                End If

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = ItemCost2Command.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.GetValue(0)) Then
                        FIFOCost = 0
                    Else
                        FIFOCost = reader.GetValue(0)
                    End If
                    If IsDBNull(reader.GetValue(1)) Then
                        UpperLimit = 0
                    Else
                        UpperLimit = reader.GetValue(1)
                    End If
                Else
                    FIFOCost = 0
                    UpperLimit = 0
                End If
                reader.Close()
                con.Close()
            Else
                Dim ItemCost2Statement As String = "SELECT ItemCost, UpperLimit FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                Dim ItemCost2Command As New SqlCommand(ItemCost2Statement, con)
                ItemCost2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                ItemCost2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                ItemCost2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = Today.Date.ToString()
                ItemCost2Command.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber
                If TotalQuantityShipped = 0 Then
                    ItemCost2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = 1
                Else
                    ItemCost2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
                End If

                If con.State = ConnectionState.Closed Then con.Open()
                Dim reader As SqlDataReader = ItemCost2Command.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    If IsDBNull(reader.GetValue(0)) Then
                        FIFOCost = 0
                    Else
                        FIFOCost = reader.GetValue(0)
                    End If
                    If IsDBNull(reader.GetValue(1)) Then
                        UpperLimit = 0
                    Else
                        UpperLimit = reader.GetValue(1)
                    End If
                Else
                    FIFOCost = 0
                    UpperLimit = 0
                End If
                reader.Close()
                con.Close()
            End If

            If TotalQuantityShipped + QuantityShipped > UpperLimit Then
                'Quantity crosses a cost tier
                QuantityRemaining = (TotalQuantityShipped + QuantityShipped) - UpperLimit

                FIFOExtendedAmount = (UpperLimit - TotalQuantityShipped) * FIFOCost

                'Create loop to calculate remainder of quantity
                Do While QuantityRemaining > 0
                    Dim TempQuantity As Double = 0

                    'Get Max Transaction Number where 
                    Dim GetMaxTransactionNumber2Statement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                    Dim GetMaxTransactionNumber2Command As New SqlCommand(GetMaxTransactionNumber2Statement, con)
                    GetMaxTransactionNumber2Command.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                    GetMaxTransactionNumber2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    GetMaxTransactionNumber2Command.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                    GetMaxTransactionNumber2Command.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = Today.Date.ToString()

                    If con.State = ConnectionState.Closed Then con.Open()
                    Try
                        GetMaxTransactionNumber = CInt(GetMaxTransactionNumber2Command.ExecuteScalar)
                    Catch ex As Exception
                        GetMaxTransactionNumber = 0
                    End Try
                    con.Close()

                    If GetMaxTransactionNumber = 0 Then
                        'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                        Dim NextItemCostStatement As String = "SELECT ItemCost, UpperLimit, LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                        Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                        NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                        NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = Today.Date.ToString()

                        If con.State = ConnectionState.Closed Then con.Open()
                        Dim reader As SqlDataReader = NextItemCostCommand.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            If IsDBNull(reader.GetValue(0)) Then
                                FIFOCost = 0
                            Else
                                FIFOCost = reader.GetValue(0)
                            End If
                            If IsDBNull(reader.GetValue(1)) Then
                                NextUpperLimit = 0
                            Else
                                NextUpperLimit = reader.GetValue(1)
                            End If
                            If IsDBNull(reader.GetValue(2)) Then
                                NextLowerLimit = 0
                            Else
                                NextLowerLimit = reader.GetValue(2)
                            End If
                        Else
                            FIFOCost = 0
                            NextUpperLimit = 0
                            NextLowerLimit = 0
                        End If
                        reader.Close()
                        con.Close()
                    Else
                        'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
                        Dim NextItemCostStatement As String = "SELECT ItemCost, UpperLimit, LowerLimit FROM InventoryCosting WHERE CostingDate <= @CostingDate AND PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber = @TransactionNumber AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
                        Dim NextItemCostCommand As New SqlCommand(NextItemCostStatement, con)
                        NextItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
                        NextItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        NextItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = UpperLimit + 1
                        NextItemCostCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = Today.Date.ToString()
                        NextItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

                        If con.State = ConnectionState.Closed Then con.Open()
                        Dim reader As SqlDataReader = NextItemCostCommand.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            If IsDBNull(reader.GetValue(0)) Then
                                FIFOCost = 0
                            Else
                                FIFOCost = reader.GetValue(0)
                            End If
                            If IsDBNull(reader.GetValue(1)) Then
                                NextUpperLimit = 0
                            Else
                                NextUpperLimit = reader.GetValue(1)
                            End If
                            If IsDBNull(reader.GetValue(2)) Then
                                NextLowerLimit = 0
                            Else
                                NextLowerLimit = reader.GetValue(2)
                            End If
                        Else
                            FIFOCost = 0
                            NextUpperLimit = 0
                            NextLowerLimit = 0
                        End If
                        reader.Close()
                        con.Close()
                    End If

                    TempQuantity = (NextUpperLimit + 1) - NextLowerLimit

                    If QuantityRemaining > TempQuantity Then
                        'Add to existing FIFO Extended Amount
                        FIFOExtendedAmount = FIFOExtendedAmount + (TempQuantity * FIFOCost)

                        'Redefine Quantity Remaining after the next cost tier
                        QuantityRemaining = QuantityRemaining - TempQuantity
                        UpperLimit = NextUpperLimit
                    Else
                        FIFOExtendedAmount = FIFOExtendedAmount + (QuantityRemaining * FIFOCost)
                        QuantityRemaining = 0
                    End If
                Loop
            Else
                'Entire quantity falls into one cost tier
                FIFOExtendedAmount = FIFOCost * QuantityShipped
            End If
        End If

        'Run routine if no FIFO Cost is retrieved - Use LPC, TC, STD Cost
        '*****************************************************************************************************************************************
        If FIFOCost = 0 Then
            LastPurchaseCost = 0

            Dim MAXDateStatement As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT UnitCost FROM PurchaseOrderLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND PurchaseOrderHeaderKey = @PurchaseOrderHeaderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber
            LastPriceCommand.Parameters.Add("@PurchaseOrderHeaderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastPurchaseCost = 0
            End Try
            con.Close()

            FIFOCost = LastPurchaseCost
            FIFOExtendedAmount = FIFOCost * QuantityShipped
        End If
        '*****************************************************************************************************************************************
        If FIFOCost = 0 Then
            Dim TransactionCost As Double = 0

            Dim TransactionCostStatement As String = "SELECT MAX(ItemCost) FROM InventoryTransactionTable WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
            Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
            TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = PartNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
            Catch ex As Exception
                TransactionCost = 0
            End Try
            con.Close()

            FIFOCost = TransactionCost
            FIFOExtendedAmount = FIFOCost * QuantityShipped
        End If
        '*****************************************************************************************************************************************
        'If FIFO Cost = 0, pull Standard Cost from Item List
        If FIFOCost = 0 Then
            Dim StandardCost As Double = 0

            Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
            Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
            StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = PartNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
            Catch ex As Exception
                StandardCost = 0
            End Try
            con.Close()

            FIFOCost = StandardCost
            FIFOExtendedAmount = FIFOCost * QuantityShipped
        End If
        Return Math.Round(FIFOExtendedAmount, 2)
    End Function

    Private Function isSomeoneEditing() As Boolean
        cmd = New SqlCommand("SELECT Locked FROM InvoiceProcessingBatchHeader WHERE BatchNumber = @BatchNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        Dim personEditing As String = "NONE"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If Not IsDBNull(reader.GetValue(0)) Then
                personEditing = reader.GetValue(0)
            End If
        End If
        reader.Close()
        con.Close()

        If Not personEditing.Equals("NONE") And Not String.IsNullOrEmpty(personEditing) Then
            If Not personEditing.Equals(EmployeeLoginName) Then
                MessageBox.Show(personEditing + " is currently editing this batch. You are unable to make any changes.", "Unable to save/Post", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub LockBatch()
        cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET Locked = @Locked WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = txtBatchNumber.Text
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub unlockBatch(Optional ByVal batch As String = "none")
        cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET Locked = '' WHERE BatchNumber = @BatchNumber AND Locked = @Locked", con)
        If batch.Equals("none") Then
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)
        Else
            cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = batch
        End If
        cmd.Parameters.Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub UnLockInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnLockInvoiceToolStripMenuItem.Click
        If Not String.IsNullOrEmpty(txtBatchNumber.Text) Then
            If MessageBox.Show("Are you sure you wish to un-lock this batch?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New SqlCommand("UPDATE InvoiceProcessingBatchHeader SET Locked = '' WHERE BatchNumber = @BatchNumber", con)
                cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = Val(txtBatchNumber.Text)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Batch is now un-locked", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("You must enter an Invoice number to un-lock", "Enter a Invoice number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboInvoiceNumber.Focus()
        End If
    End Sub

    Private Sub InvoiceBillOnly_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not String.IsNullOrEmpty(txtBatchNumber.Text) Then
            unlockBatch(txtBatchNumber.Text)
        End If
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboShipMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipMethod.SelectedIndexChanged
        If cboShipMethod.Text = "THIRD PARTY" Then
            GetThirdPartyBillingData()
        Else
            txtThirdParty.Clear()
        End If
    End Sub

    Private Sub InvoiceBillOnly_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub

    'Key press events

    Private Sub cboPartDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPartDescription.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboPartNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPartNumber.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboShipMethod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboShipMethod.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboCustomerID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCustomerID.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboCustomerName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCustomerName.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboBTState_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBTState.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboConsignmentWarehouse_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboConsignmentWarehouse.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboCustomerClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCustomerClass.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboPaymentTerms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPaymentTerms.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboShipVia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboShipVia.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub
End Class