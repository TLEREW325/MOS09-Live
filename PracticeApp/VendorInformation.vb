Imports System.Data.SqlClient
Imports System.IO
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
Imports System
Imports System.Math
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class VendorInformation
    Inherits System.Windows.Forms.Form

    Dim Checked1099, Name1099, ValidateVendorForBadCharacters, ACHContactName, ACHContactNumber, ACHContactEmail, ACHVerifyDate, VendorAccountType, VendorRoutingNumber, VendorAccountNumber, CheckCode, RemittanceEmail, WhitePaperCheck, Prop65Compliant, LastActivity, VendorClassMode, ISOCompliant, ApprovedBy, ApprovalCriteria, ItemGLAccount, ItemDescription, DefaultItem, VendorName, ContactName, VendorAddress1, VendorAddress2, VendorCity, VendorState, VendorZip, VendorCountry, VendorPhone, VendorFax, VendorEmail, PaymentTerms, VendorClass, VendorComment, VendorTaxID, VendorPreferredShipper, DefaultGLAccount As String
    Dim CreditLimit, CurrentBalance As Double
    Dim CheckPaymentTerms, CheckItem, CheckPurchaseOrder, CheckVoucher, CheckDeleteValidation As Integer
    Dim LastSteelActivity, LastPurchaseActivity As Date
    Dim AuditComment As String = ""
    Dim AuditVendor As String = ""

    'Variables to calculate MTD and YTD Production
    Dim YearDate, MonthDate, BeginDate, EndDate, VendorDate, ApprovalDate As Date
    Dim YearOfYear, MonthOfYear, Year As Integer
    Dim strMonthOfYear, strYear As String
    Dim MTDPurchasesTotal, MTDPurchases, MTDPurchasesSteel, YTDPurchasesTotal, YTDPurchases, YTDPurchasesSteel, MTDVouchers, YTDVouchers As Double

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cnd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7 As New SqlDataAdapter
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As DataSet


    Dim fileData As List(Of usefulFunctions.PDFFileData)
    Dim position As Integer = 0
    Dim tempfolder As String = My.Computer.FileSystem.SpecialDirectories.Temp.Replace("\", "\\") + "\\TrufitBanking\\Uploaded W-9"
    Dim W9UploadDirectory As String = "\\\\TFP-SQL\\TransferData\\TrufitBanking\\Uploaded W-9"
    Dim DeleteFile As Boolean = False
    Dim DeleteAll As Boolean = False
    Dim UploadFiles As Boolean = False

    'Form events

    Private Sub VendorInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.StateTable' table. You can move, or remove it, as needed.
        Me.StateTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.StateTable)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.ShipMethod' table. You can move, or remove it, as needed.
        Me.ShipMethodTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.ShipMethod)
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.PaymentTerms' table. You can move, or remove it, as needed.
        Me.PaymentTermsTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.PaymentTerms)

        LoadCurrentDivision()

        If GlobalVendorID <> "" Then
            cboVendorID.Text = GlobalVendorID
        End If

        If EmployeeSecurityCode = 1002 Or EmployeeSecurityCode = 1001 Then
            lblTaxIDLabel.Visible = True
            txtVendorTaxID.Visible = True
            rdoCheckCodeIntercompany.Enabled = True
            rdoCheckCodeStandard.Enabled = True
            rdoFedexCheck.Enabled = True
            rdoOtherACH.Enabled = True
            rdoSavings.Enabled = True
            rdoChecking.Enabled = True

            tabVendorControl.TabPages(1).Enabled = True
            txtVendorAccount.Visible = True
            txtRoutingNumber.Visible = True
            txtACHContactEmail.Enabled = True
            txtACHContactName.Enabled = True
            txtACHContactPhone.Enabled = True
            txtACHVerifyDate.Enabled = True
        Else
            lblTaxIDLabel.Visible = False
            txtVendorTaxID.Visible = False
            rdoCheckCodeIntercompany.Enabled = False
            rdoCheckCodeStandard.Enabled = False
            rdoFedexCheck.Enabled = False
            rdoOtherACH.Enabled = False
            rdoSavings.Enabled = False
            rdoChecking.Enabled = False
            txtACHContactEmail.Enabled = False
            txtACHContactName.Enabled = False
            txtACHContactPhone.Enabled = False
            txtACHVerifyDate.Enabled = False

            tabVendorControl.TabPages(1).Enabled = False
            txtVendorAccount.Visible = False
            txtRoutingNumber.Visible = False
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

    Private Sub VendorInformation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearAllDataFields()
        ClearVariables()
    End Sub

    'Load datasets into controls

    Public Sub LoadVendor()
        'Loads only Vendor for the correct division
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

    Public Sub LoadNonInventoryPartNumber()
        'Loads part #
        cmd = New SqlCommand("SELECT ItemID FROM NonInventoryItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "NonInventoryItemList")
        cboDefaultItem.DataSource = ds3.Tables("NonInventoryItemList")
        con.Close()
        cboDefaultItem.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorClass()
        'Load Vendor Class mode based on division
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            VendorClassMode = "CANADIAN"
        Else
            VendorClassMode = "STANDARD"
        End If

        'Loads vendor class for correct mode
        cmd = New SqlCommand("SELECT VendClassID FROM VendorClass WHERE ClassMode = @ClassMode", con)
        cmd.Parameters.Add("@ClassMode", SqlDbType.VarChar).Value = VendorClassMode
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "VendorClass")
        cboVendorClass.DataSource = ds4.Tables("VendorClass")
        con.Close()
        cboVendorClass.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccountNumber()
        'Loads only Vendor for the correct division
        cmd = New SqlCommand("SELECT GLAccountNumber FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd
        myAdapter5.Fill(ds5, "GLAccounts")
        cboDefaultGLAccount.DataSource = ds5.Tables("GLAccounts")
        con.Close()
        cboDefaultGLAccount.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccountDescription()
        'Loads only Vendor for the correct division
        cmd = New SqlCommand("SELECT GLAccountShortDescription FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "GLAccounts")
        cboAccountDescription.DataSource = ds6.Tables("GLAccounts")
        con.Close()
        cboAccountDescription.SelectedIndex = -1
    End Sub

    'Load data routines

    Public Sub LoadGLDescriptionByAccount()
        Dim LoadGLAccountDescription As String = ""

        Dim LoadGLAccountDescriptionStatement As String = "SELECT GLAccountShortDescription FROM GLAccounts WHERE GLAccountNumber = @GLAccountNumber"
        Dim LoadGLAccountDescriptionCommand As New SqlCommand(LoadGLAccountDescriptionStatement, con)
        LoadGLAccountDescriptionCommand.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = cboDefaultGLAccount.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadGLAccountDescription = CStr(LoadGLAccountDescriptionCommand.ExecuteScalar)
        Catch ex As System.Exception
            LoadGLAccountDescription = ""
        End Try
        con.Close()

        cboAccountDescription.Text = LoadGLAccountDescription
    End Sub

    Public Sub LoadGLAccountByDescription()
        Dim LoadGLAccountNumber As String = ""

        Dim LoadGLAccountNumberStatement As String = "SELECT GLAccountNumber FROM GLAccounts WHERE GLAccountShortDescription = @GLAccountShortDescription"
        Dim LoadGLAccountNumberCommand As New SqlCommand(LoadGLAccountNumberStatement, con)
        LoadGLAccountNumberCommand.Parameters.Add("@GLAccountShortDescription", SqlDbType.VarChar).Value = cboAccountDescription.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LoadGLAccountNumber = CStr(LoadGLAccountNumberCommand.ExecuteScalar)
        Catch ex As System.Exception
            LoadGLAccountNumber = ""
        End Try
        con.Close()

        cboDefaultGLAccount.Text = LoadGLAccountNumber
    End Sub

    Public Sub LoadMTDPurchases()
        MonthDate = Today()
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = MonthDate

        Dim MTDPurchasesStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDPurchasesCommand As New SqlCommand(MTDPurchasesStatement, con)
        MTDPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDPurchasesCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        MTDPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDPurchases = CDbl(MTDPurchasesCommand.ExecuteScalar)
        Catch ex As System.Exception
            MTDPurchases = 0
        End Try
        con.Close()

        Dim MTDPurchasesSteelStatement As String = "SELECT SUM(SteelExtendedAmount) FROM SteelReceivingLineQuery WHERE DivisionID = @DivisionID AND SteelVendor = @SteelVendor AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDPurchasesSteelCommand As New SqlCommand(MTDPurchasesSteelStatement, con)
        MTDPurchasesSteelCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDPurchasesSteelCommand.Parameters.Add("@SteelVendor", SqlDbType.VarChar).Value = cboVendorID.Text
        MTDPurchasesSteelCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDPurchasesSteelCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDPurchasesSteel = CDbl(MTDPurchasesSteelCommand.ExecuteScalar)
        Catch ex As System.Exception
            MTDPurchasesSteel = 0
        End Try
        con.Close()

        txtMTDPurchases.Text = FormatCurrency(MTDPurchases, 2)
        txtMTDSteel.Text = FormatCurrency(MTDPurchasesSteel, 2)

        MTDPurchasesTotal = MTDPurchases + MTDPurchasesSteel
        txtTotalMTD.Text = FormatCurrency(MTDPurchasesTotal, 2)
    End Sub

    Public Sub LoadMTDVouchers()
        MonthDate = Today()
        MonthOfYear = MonthDate.Month
        Year = MonthDate.Year
        strMonthOfYear = CStr(MonthOfYear)
        strYear = CStr(Year)
        BeginDate = strMonthOfYear + "/01/" + strYear
        EndDate = MonthDate

        Dim MTDVouchersStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim MTDVouchersCommand As New SqlCommand(MTDVouchersStatement, con)
        MTDVouchersCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        MTDVouchersCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
        MTDVouchersCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        MTDVouchersCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            MTDVouchers = CDbl(MTDVouchersCommand.ExecuteScalar)
        Catch ex As System.Exception
            MTDVouchers = 0
        End Try
        con.Close()
        txtMTDVouchers.Text = FormatCurrency(MTDVouchers, 2)
    End Sub

    Public Sub LoadYTDPurchases()
        YearDate = Today()
        YearOfYear = YearDate.Year
        MonthOfYear = YearDate.Month
        If MonthOfYear < 5 Then
            YearOfYear = YearOfYear - 1
        Else
            'Do nothing
        End If
        strYear = CStr(YearOfYear)
        BeginDate = "05/01/" + strYear
        EndDate = YearDate

        Dim YTDPurchasesStatement As String = "SELECT SUM(ExtendedAmount) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDPurchasesCommand As New SqlCommand(YTDPurchasesStatement, con)
        YTDPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDPurchasesCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        YTDPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDPurchases = CDbl(YTDPurchasesCommand.ExecuteScalar)
        Catch ex As System.Exception
            YTDPurchases = 0
        End Try
        con.Close()

        Dim YTDPurchasesSteelStatement As String = "SELECT SUM(SteelExtendedAmount) FROM SteelReceivingLineQuery WHERE DivisionID = @DivisionID AND SteelVendor = @SteelVendor AND ReceivingDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDPurchasesSteelCommand As New SqlCommand(YTDPurchasesSteelStatement, con)
        YTDPurchasesSteelCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDPurchasesSteelCommand.Parameters.Add("@SteelVendor", SqlDbType.VarChar).Value = cboVendorID.Text
        YTDPurchasesSteelCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDPurchasesSteelCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDPurchasesSteel = CDbl(YTDPurchasesSteelCommand.ExecuteScalar)
        Catch ex As System.Exception
            YTDPurchasesSteel = 0
        End Try
        con.Close()

        txtYTDPurchases.Text = FormatCurrency(YTDPurchases, 2)
        txtYTDSteel.Text = FormatCurrency(YTDPurchasesSteel, 2)
        YTDPurchasesTotal = YTDPurchases + YTDPurchasesSteel
        txtTotalYTD.Text = FormatCurrency(YTDPurchasesTotal, 2)
    End Sub

    Public Sub LoadYTDVouchers()
        YearDate = Today()
        YearOfYear = YearDate.Year
        MonthOfYear = YearDate.Month
        If MonthOfYear < 5 Then
            YearOfYear = YearOfYear - 1
        Else
            'Do nothing
        End If
        strYear = CStr(YearOfYear)
        BeginDate = "05/01/" + strYear
        EndDate = YearDate

        Dim YTDVouchersStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim YTDVouchersCommand As New SqlCommand(YTDVouchersStatement, con)
        YTDVouchersCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        YTDVouchersCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
        YTDVouchersCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        YTDVouchersCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            YTDVouchers = CDbl(YTDVouchersCommand.ExecuteScalar)
        Catch ex As System.Exception
            YTDVouchers = 0
        End Try
        con.Close()

        txtYTDVouchers.Text = FormatCurrency(YTDVouchers, 2)
    End Sub

    Public Sub LoadLastActivity()
        Dim LastActivityStatement As String = "SELECT MAX(ReceivingDate) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
        Dim LastActivityCommand As New SqlCommand(LastActivityStatement, con)
        LastActivityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LastActivityCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastPurchaseActivity = CDate(LastActivityCommand.ExecuteScalar)
        Catch ex As System.Exception
            LastPurchaseActivity = "01/01/2000"
        End Try
        con.Close()

        Dim LastSteelActivityStatement As String = "SELECT MAX(ReceivingDate) FROM SteelReceivingLineQuery WHERE DivisionID = @DivisionID AND SteelVendor = @SteelVendor"
        Dim LastSteelActivityCommand As New SqlCommand(LastSteelActivityStatement, con)
        LastSteelActivityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        LastSteelActivityCommand.Parameters.Add("@SteelVendor", SqlDbType.VarChar).Value = cboVendorID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastSteelActivity = CDate(LastSteelActivityCommand.ExecuteScalar)
        Catch ex As System.Exception
            LastSteelActivity = "01/01/2000"
        End Try
        con.Close()

        If LastPurchaseActivity = "01/01/2000" And LastSteelActivity = "01/01/2000" Then
            LastActivity = "NONE"
        Else
            If LastPurchaseActivity > LastSteelActivity Then
                LastActivity = LastPurchaseActivity.ToString
            Else
                LastActivity = LastSteelActivity.ToString
            End If
        End If

        txtLastActivityDate.Text = LastActivity
    End Sub

    Public Sub LoadNoninventoryDescription()
        Dim ItemDescriptionStatement As String = "SELECT ShortDescription FROM NonInventoryItemList WHERE DivisionID = @DivisionID AND ItemID = @ItemID"
        Dim ItemDescriptionCommand As New SqlCommand(ItemDescriptionStatement, con)
        ItemDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ItemDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboDefaultItem.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = ItemDescriptionCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ShortDescription")) Then
                ItemDescription = ""
            Else
                ItemDescription = reader.Item("ShortDescription")
            End If
        Else
            ItemDescription = ""
        End If
        reader.Close()
        con.Close()

        txtItemDescription.Text = ItemDescription
    End Sub

    Public Sub LoadOutStandingBalance()
        Dim CurrentBalanceStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND VoucherStatus = @VoucherStatus"
        Dim CurrentBalanceCommand As New SqlCommand(CurrentBalanceStatement, con)
        CurrentBalanceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        CurrentBalanceCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
        CurrentBalanceCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "POSTED"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CurrentBalance = CDbl(CurrentBalanceCommand.ExecuteScalar)
        Catch ex As System.Exception
            CurrentBalance = 0
        End Try
        con.Close()

        txtCurrentBalance.Text = FormatCurrency(CurrentBalance, 2)
    End Sub

    Public Sub LoadVendorInfo()
        Dim GetVendorInfoStatement As String = "SELECT * FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim GetVendorInfoCommand As New SqlCommand(GetVendorInfoStatement, con)
        GetVendorInfoCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        GetVendorInfoCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetVendorInfoCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("VendorName")) Then
                VendorName = ""
            Else
                VendorName = reader.Item("VendorName")
            End If
            If IsDBNull(reader.Item("ContactName")) Then
                ContactName = ""
            Else
                ContactName = reader.Item("ContactName")
            End If
            If IsDBNull(reader.Item("VendorAddress1")) Then
                VendorAddress1 = ""
            Else
                VendorAddress1 = reader.Item("VendorAddress1")
            End If
            If IsDBNull(reader.Item("VendorAddress2")) Then
                VendorAddress2 = ""
            Else
                VendorAddress2 = reader.Item("VendorAddress2")
            End If
            If IsDBNull(reader.Item("VendorCity")) Then
                VendorCity = ""
            Else
                VendorCity = reader.Item("VendorCity")
            End If
            If IsDBNull(reader.Item("VendorState")) Then
                VendorState = ""
            Else
                VendorState = reader.Item("VendorState")
            End If
            If IsDBNull(reader.Item("VendorZip")) Then
                VendorZip = ""
            Else
                VendorZip = reader.Item("VendorZip")
            End If
            If IsDBNull(reader.Item("VendorCountry")) Then
                VendorCountry = ""
            Else
                VendorCountry = reader.Item("VendorCountry")
            End If
            If IsDBNull(reader.Item("VendorPhone")) Then
                VendorPhone = ""
            Else
                VendorPhone = reader.Item("VendorPhone")
            End If
            If IsDBNull(reader.Item("VendorFax")) Then
                VendorFax = ""
            Else
                VendorFax = reader.Item("VendorFax")
            End If
            If IsDBNull(reader.Item("VendorEmail")) Then
                VendorEmail = ""
            Else
                VendorEmail = reader.Item("VendorEmail")
            End If
            If IsDBNull(reader.Item("PaymentTerms")) Then
                PaymentTerms = "N60"
            Else
                PaymentTerms = reader.Item("PaymentTerms")
            End If
            If IsDBNull(reader.Item("VendorClass")) Then
                VendorClass = ""
            Else
                VendorClass = reader.Item("VendorClass")
            End If
            If IsDBNull(reader.Item("VendorDate")) Then
                VendorDate = dtpVendorDate.Text
            Else
                VendorDate = reader.Item("VendorDate")
            End If
            If IsDBNull(reader.Item("VendorComment")) Then
                VendorComment = ""
            Else
                VendorComment = reader.Item("VendorComment")
            End If
            If IsDBNull(reader.Item("VendorTaxID")) Then
                VendorTaxID = ""
            Else
                VendorTaxID = reader.Item("VendorTaxID")
            End If
            If IsDBNull(reader.Item("VendorPreferredShipping")) Then
                VendorPreferredShipper = "Delivery"
            Else
                VendorPreferredShipper = reader.Item("VendorPreferredShipping")
            End If
            If IsDBNull(reader.Item("CreditLimit")) Then
                CreditLimit = 0
            Else
                CreditLimit = reader.Item("CreditLimit")
            End If
            If IsDBNull(reader.Item("DefaultGLAccount")) Then
                DefaultGLAccount = ""
            Else
                DefaultGLAccount = reader.Item("DefaultGLAccount")
            End If
            If IsDBNull(reader.Item("DefaultItem")) Then
                DefaultItem = ""
            Else
                DefaultItem = reader.Item("DefaultItem")
            End If
            If IsDBNull(reader.Item("ApprovedBy")) Then
                ApprovedBy = ""
            Else
                ApprovedBy = reader.Item("ApprovedBy")
            End If
            If IsDBNull(reader.Item("ApprovalCriteria")) Then
                ApprovalCriteria = ""
            Else
                ApprovalCriteria = reader.Item("ApprovalCriteria")
            End If
            If IsDBNull(reader.Item("ApprovalDate")) Then
                ApprovalDate = dtpApprovalDate.Value
            Else
                If Not String.IsNullOrEmpty(reader.Item("ApprovalDate")) Then
                    ApprovalDate = reader.Item("ApprovalDate")
                Else
                    ApprovalDate = dtpApprovalDate.Value
                End If
            End If
            If IsDBNull(reader.Item("ISOCompliant")) Then
                ISOCompliant = "NO"
            Else
                ISOCompliant = reader.Item("ISOCompliant")
            End If
            If IsDBNull(reader.Item("Prop65Compliant")) Then
                Prop65Compliant = "NO"
            Else
                Prop65Compliant = reader.Item("Prop65Compliant")
            End If
            If IsDBNull(reader.Item("WhitePaperCheck")) Then
                WhitePaperCheck = "NO"
            Else
                WhitePaperCheck = reader.Item("WhitePaperCheck")
            End If
            If IsDBNull(reader.Item("RemittanceEmail")) Then
                RemittanceEmail = ""
            Else
                RemittanceEmail = reader.Item("RemittanceEmail")
            End If
            If IsDBNull(reader.Item("CheckCode")) Then
                CheckCode = "STANDARD"
            Else
                CheckCode = reader.Item("CheckCode")
            End If
            If IsDBNull(reader.Item("VendorAccountNumber")) Then
                VendorAccountNumber = ""
            Else
                VendorAccountNumber = reader.Item("VendorAccountNumber")
            End If
            If IsDBNull(reader.Item("VendorRoutingNumber")) Then
                VendorRoutingNumber = ""
            Else
                VendorRoutingNumber = reader.Item("VendorRoutingNumber")
            End If
            If IsDBNull(reader.Item("VendorAccountType")) Then
                VendorAccountType = "C"
            Else
                VendorAccountType = reader.Item("VendorAccountType")
            End If
            If IsDBNull(reader.Item("ACHContactName")) Then
                ACHContactName = ""
            Else
                ACHContactName = reader.Item("ACHContactName")
            End If
            If IsDBNull(reader.Item("ACHContactNumber")) Then
                ACHContactNumber = ""
            Else
                ACHContactNumber = reader.Item("ACHContactNumber")
            End If
            If IsDBNull(reader.Item("ACHContactEmail")) Then
                ACHContactEmail = ""
            Else
                ACHContactEmail = reader.Item("ACHContactEmail")
            End If
            If IsDBNull(reader.Item("ACHVerifyDate")) Then
                ACHVerifyDate = ""
            Else
                ACHVerifyDate = reader.Item("ACHVerifyDate")
            End If
            If IsDBNull(reader.Item("Checked1099")) Then
                Checked1099 = "NO"
            Else
                Checked1099 = reader.Item("Checked1099")
            End If
            If IsDBNull(reader.Item("Name1099")) Then
                Name1099 = ""
            Else
                Name1099 = reader.Item("Name1099")
            End If
        Else
            VendorName = ""
            ContactName = ""
            VendorAddress1 = ""
            VendorAddress2 = ""
            VendorCity = ""
            VendorState = ""
            VendorZip = ""
            VendorCountry = ""
            VendorPhone = ""
            VendorFax = ""
            VendorEmail = ""
            PaymentTerms = "N30"
            VendorClass = ""
            VendorDate = Today.Date
            VendorComment = ""
            VendorTaxID = ""
            VendorPreferredShipper = "Delivery"
            CreditLimit = 0
            DefaultGLAccount = ""
            DefaultItem = ""
            ApprovedBy = ""
            ApprovalCriteria = ""
            ApprovalDate = Today.Date
            ISOCompliant = "NO"
            Prop65Compliant = "NO"
            WhitePaperCheck = "NO"
            RemittanceEmail = ""
            CheckCode = "STANDARD"
            VendorAccountNumber = ""
            VendorRoutingNumber = ""
            VendorAccountType = "C"
            ACHContactName = ""
            ACHContactNumber = ""
            ACHContactEmail = ""
            ACHVerifyDate = ""
            Checked1099 = "NO"
            Name1099 = ""
        End If
        reader.Close()
        con.Close()

        txtVendorName.Text = VendorName
        txtContactName.Text = ContactName
        txtAddress1.Text = VendorAddress1
        txtAddress2.Text = VendorAddress2
        txtCity.Text = VendorCity
        cboState.Text = VendorState
        txtZipCode.Text = VendorZip
        txtCountry.Text = VendorCountry
        txtPhoneNumber.Text = VendorPhone
        txtFAXNumber.Text = VendorFax
        txtVendorEmail.Text = VendorEmail
        cboPaymentTerms.Text = PaymentTerms
        cboVendorClass.Text = VendorClass
        dtpVendorDate.Text = VendorDate
        txtVendorComment.Text = VendorComment
        txtVendorTaxID.Text = VendorTaxID
        cboPreferredShipper.Text = VendorPreferredShipper
        txtCreditLimit.Text = CreditLimit
        txtRemittanceEmail.Text = RemittanceEmail
        cboApprovalCriteria.Text = ApprovalCriteria
        dtpApprovalDate.Text = ApprovalDate
        txtApprovedBy.Text = ApprovedBy
        txtVendorAccount.Text = VendorAccountNumber
        txtRoutingNumber.Text = VendorRoutingNumber
        txtACHContactEmail.Text = ACHContactEmail
        txtACHContactName.Text = ACHContactName
        txtACHContactPhone.Text = ACHContactNumber
        txtACHVerifyDate.Text = ACHVerifyDate
        txt1099Name.Text = Name1099

        cboDefaultItem.Text = DefaultItem
        cboDefaultGLAccount.Text = DefaultGLAccount

        If ISOCompliant = "YES" Then
            chkIsoCompliant.Checked = True
        Else
            chkIsoCompliant.Checked = False
        End If
        If Prop65Compliant = "YES" Then
            chkProp65.Checked = True
        Else
            chkProp65.Checked = False
        End If
        If VendorAccountType = "C" Then
            rdoChecking.Checked = True
        ElseIf VendorAccountType = "S" Then
            rdoSavings.Checked = True
        Else
            rdoChecking.Checked = True
        End If
        If Checked1099 = "YES" Then
            chkVendor1099.Checked = True
        Else
            chkVendor1099.Checked = False
        End If
        If CheckCode = "INTERCOMPANY" Then
            rdoFedexCheck.Checked = False
            rdoCheckCodeIntercompany.Checked = True
            rdoCheckCodeStandard.Checked = False
            rdoOtherACH.Checked = False
            chkWhitePaperCheck.Checked = False
            chkWhitePaperCheck.Enabled = False
        ElseIf CheckCode = "FEDEX" Then
            rdoFedexCheck.Checked = True
            rdoCheckCodeIntercompany.Checked = False
            rdoCheckCodeStandard.Checked = False
            rdoOtherACH.Checked = False
            chkWhitePaperCheck.Checked = False
            chkWhitePaperCheck.Enabled = False
        ElseIf CheckCode = "ACH" Then
            rdoFedexCheck.Checked = False
            rdoCheckCodeIntercompany.Checked = False
            rdoCheckCodeStandard.Checked = False
            rdoOtherACH.Checked = True
            chkWhitePaperCheck.Checked = False
            chkWhitePaperCheck.Enabled = False
        Else
            rdoFedexCheck.Checked = False
            rdoCheckCodeIntercompany.Checked = False
            rdoCheckCodeStandard.Checked = True
            rdoOtherACH.Checked = False
            chkWhitePaperCheck.Enabled = True
        End If
        If WhitePaperCheck = "YES" Then
            chkWhitePaperCheck.Checked = True
        Else
            chkWhitePaperCheck.Checked = False
        End If
    End Sub

    'Validation, updating, error checking, and logging

    Public Sub ValidateVendor()
        If cboVendorClass.Text = "" Then
            cboVendorClass.Text = "OTHER"
        End If
    End Sub

    Public Sub ValidateVendorNameAndID()
        Dim badChars As String = "!@$%^*()+=[]{},<>?:;"
        If cboVendorID.Text.Count(Function(c) badChars.Contains(c)) > 0 Then
            MsgBox("You cannot use one of these characters in a Vendor ID.", MsgBoxStyle.OkOnly)
            ValidateVendorForBadCharacters = "YES"
        Else
            ValidateVendorForBadCharacters = "NO"
        End If
        If txtVendorName.Text.Count(Function(c) badChars.Contains(c)) > 0 Then
            MsgBox("You cannot use one of these characters in a Vendor Name.", MsgBoxStyle.OkOnly)
            ValidateVendorForBadCharacters = "YES"
        Else
            ValidateVendorForBadCharacters = "NO"
        End If
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
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

    Private Function canSave() As Boolean
        If String.IsNullOrEmpty(cboVendorID.Text) Then
            MessageBox.Show("You must enter a Vendor ID", "Enter a Vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorID.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtVendorName.Text) Then
            MessageBox.Show("You must enter a vendor name", "Enter a vendor name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtVendorName.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboVendorClass.Text) And (cboDivisionID.Text.Equals("TFF") Or cboDivisionID.Text.Equals("TOR") Or cboDivisionID.Text = "ALB") Then
            MessageBox.Show("You must select a Vendor Class", "Select a Vendor Class", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorClass.Focus()
            Return False
        End If
        If cboVendorClass.SelectedIndex = -1 And (cboDivisionID.Text.Equals("TFF") Or cboDivisionID.Text.Equals("TOR") Or cboDivisionID.Text = "ALB") Then
            MessageBox.Show("You must select a valid Vendor Class", "Select a valid Vendor Class", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorClass.SelectAll()
            cboVendorClass.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboPaymentTerms.Text) Then
            MessageBox.Show("You must select a payment term", "Select a payment term", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPaymentTerms.Focus()
            Return False
        End If
        If cboPaymentTerms.SelectedIndex = -1 Then
            MessageBox.Show("You must enter a valid payment term", "Enter a valid payment term", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPaymentTerms.SelectAll()
            cboPaymentTerms.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("You must enter an address", "Enter an address", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress1.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtCity.Text) Then
            MessageBox.Show("You must enter a city", "Enter a city", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCity.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(cboState.Text) Then
            MessageBox.Show("You must enter a state", "Enter a state", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboState.Focus()
            Return False
        End If
        If String.IsNullOrEmpty(txtZipCode.Text) Then
            MessageBox.Show("You must entere a zip code", "Enbter a zip code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtZipCode.Focus()
            Return False
        End If
        '***********************************************************************
        Dim badChars As String = "!@$%^*+=[]{},<>?:;"
        If cboVendorID.Text.Count(Function(c) badChars.Contains(c)) > 0 Then
            MsgBox("You cannot use one of these characters in a Vendor ID.", MsgBoxStyle.OkOnly)
            Return False
        End If
        If txtVendorName.Text.Count(Function(c) badChars.Contains(c)) > 0 Then
            MsgBox("You cannot use one of these characters in a Vendor Name.", MsgBoxStyle.OkOnly)
            Return False
        End If
        
        Return True
    End Function

    Private Function canDelete() As Boolean
        If String.IsNullOrEmpty(cboVendorID.Text) Then
            MessageBox.Show("You must enter a vendor ID to delete", "Enter a vendor ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVendorID.Focus()
            Return False
        End If
        If cboVendorID.SelectedIndex = -1 Then
            ClearVariables()
            ClearAllDataFields()
            Return False
        End If
        checkActivity()
        If CheckDeleteValidation > 0 Then
            MsgBox("You cannot delete this Vendor because it has activity.", MsgBoxStyle.OkOnly)
            Return False
        End If
        Dim button As DialogResult = MessageBox.Show("Do you wish to delete this Vendor?", "DELETE VENDOR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button <> DialogResult.Yes Then
            Return False
        End If
        Return True
    End Function

    Private Sub checkActivity()
        'Check to see if Vendor has purchase orders
        Dim CheckPurchaseOrderStatement As String = "SELECT MAX(PurchaseOrderHeaderKey) FROM PurchaseOrderHeaderTable WHERE VendorID = @VendorID AND DivisionID = @DivisionID"
        Dim CheckPurchaseOrderCommand As New SqlCommand(CheckPurchaseOrderStatement, con)
        CheckPurchaseOrderCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
        CheckPurchaseOrderCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckPurchaseOrder = CInt(CheckPurchaseOrderCommand.ExecuteScalar)
        Catch ex As System.Exception
            CheckPurchaseOrder = 0
        End Try
        con.Close()

        'Check to see if Vendor has vouchers
        Dim CheckVoucherStatement As String = "SELECT MAX(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE VendorID = @VendorID AND DivisionID = @DivisionID"
        Dim CheckVoucherCommand As New SqlCommand(CheckVoucherStatement, con)
        CheckVoucherCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = cboVendorID.Text
        CheckVoucherCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckVoucher = CInt(CheckVoucherCommand.ExecuteScalar)
        Catch ex As System.Exception
            CheckVoucher = 0
        End Try
        con.Close()

        CheckDeleteValidation = CheckPurchaseOrder + CheckVoucher
    End Sub

    Public Sub UpdateAuditTrail()
        'Write To Audit Trail
        AuditVendor = cboVendorID.Text

        Try
            'Create Entry
            cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

            With cmd.Parameters
                .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@AuditType", SqlDbType.VarChar).Value = "VENDOR FORM - Log changes on account data"
                .Add("@AuditAmount", SqlDbType.VarChar).Value = 0
                .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = AuditVendor
                .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            AuditComment = ""
            AuditVendor = ""
        Catch ex As Exception
            'Skip
        End Try
    End Sub

    Public Sub ValidateVendorBankInfo()
        Dim OldACHContactName, OldACHContactNumber, OldACHContactEmail, OldACHVerifyDate, OldVendorAccountNumber, OldVendorRoutingNumber As String
        Dim NewACHContactName, NewACHContactNumber, NewACHContactEmail, NewACHVerifyDate, NewVendorAccountNumber, NewVendorRoutingNumber As String
        Dim NewCheckType, NewBankAccountType, NewWhitePaperCheck As String
        Dim OldCheckType, OldBankAccountType, OldWhitePaperCheck As String

        'Get previous vendor bank info
        Dim GetACHDataStatement As String = "SELECT * FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
        Dim GetACHDataCommand As New SqlCommand(GetACHDataStatement, con)
        GetACHDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetACHDataCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetACHDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ACHContactName")) Then
                OldACHContactName = ""
            Else
                OldACHContactName = reader.Item("ACHContactName")
            End If
            If IsDBNull(reader.Item("ACHContactNumber")) Then
                OldACHContactNumber = ""
            Else
                OldACHContactNumber = reader.Item("ACHContactNumber")
            End If
            If IsDBNull(reader.Item("ACHContactEmail")) Then
                OldACHContactEmail = ""
            Else
                OldACHContactEmail = reader.Item("ACHContactEmail")
            End If
            If IsDBNull(reader.Item("ACHVerifyDate")) Then
                OldACHVerifyDate = ""
            Else
                OldACHVerifyDate = reader.Item("ACHVerifyDate")
            End If
            If IsDBNull(reader.Item("VendorAccountNumber")) Then
                OldVendorAccountNumber = ""
            Else
                OldVendorAccountNumber = reader.Item("VendorAccountNumber")
            End If
            If IsDBNull(reader.Item("VendorRoutingNumber")) Then
                OldVendorRoutingNumber = ""
            Else
                OldVendorRoutingNumber = reader.Item("VendorRoutingNumber")
            End If
            If IsDBNull(reader.Item("CheckCode")) Then
                OldCheckType = "STANDARD"
            Else
                OldCheckType = reader.Item("CheckCode")
            End If
            If IsDBNull(reader.Item("WhitePaperCheck")) Then
                OldWhitePaperCheck = "NO"
            Else
                OldWhitePaperCheck = reader.Item("WhitePaperCheck")
            End If
            If IsDBNull(reader.Item("VendorAccountType")) Then
                OldBankAccountType = ""
            Else
                OldBankAccountType = reader.Item("VendorAccountType")
            End If
        Else
            OldACHContactEmail = ""
            OldACHContactName = ""
            OldACHContactNumber = ""
            OldACHVerifyDate = ""
            OldVendorAccountNumber = ""
            OldVendorRoutingNumber = ""
            OldBankAccountType = ""
            OldWhitePaperCheck = "NO"
            OldCheckType = "STANDARD"
        End If
        reader.Close()
        con.Close()

        NewACHContactEmail = txtACHContactEmail.Text
        NewACHContactName = txtACHContactName.Text
        NewACHContactNumber = txtACHContactPhone.Text
        NewACHVerifyDate = txtACHVerifyDate.Text
        NewVendorAccountNumber = txtVendorAccount.Text
        NewVendorRoutingNumber = txtRoutingNumber.Text
        If rdoChecking.Checked = True Then
            NewBankAccountType = "C"
        Else
            NewBankAccountType = "S"
        End If

        If chkWhitePaperCheck.Checked = True Then
            NewWhitePaperCheck = "YES"
        Else
            NewWhitePaperCheck = "NO"
        End If

        If rdoCheckCodeStandard.Checked = True Then
            NewCheckType = "STANDARD"
        ElseIf rdoFedexCheck.Checked = True Then
            NewCheckType = "FEDEX"
        ElseIf rdoOtherACH.Checked = True Then
            NewCheckType = "ACH"
        ElseIf rdoCheckCodeIntercompany.Checked = True Then
            NewCheckType = "INTERCOMPANY"
        Else
            NewCheckType = "STANDARD"
        End If

        'Compare New Values to Old and mark changes in the Audit Trail Table
        If NewACHContactEmail = OldACHContactEmail Then
            'Skip
        Else
            AuditComment = "Contact Email changed to " + NewACHContactEmail + " from " + OldACHContactEmail

            UpdateAuditTrail()
        End If
        If NewACHContactName = OldACHContactName Then
            'Skip
        Else
            AuditComment = "Contact Name changed to " + NewACHContactName + " from " + OldACHContactName

            UpdateAuditTrail()
        End If
        If NewACHContactNumber = OldACHContactNumber Then
            'Skip
        Else
            AuditComment = "Contact Number changed to " + NewACHContactNumber + " from " + OldACHContactNumber

            UpdateAuditTrail()
        End If
        If NewACHVerifyDate = OldACHVerifyDate Then
            'Skip
        Else
            AuditComment = "Verified Date changed to " + NewACHVerifyDate + " from " + OldACHVerifyDate

            UpdateAuditTrail()
        End If
        If NewVendorAccountNumber = OldVendorAccountNumber Then
            'Skip
        Else
            AuditComment = "Vendor Account # changed to " + NewVendorAccountNumber + " from " + OldVendorAccountNumber

            UpdateAuditTrail()
        End If
        If NewVendorRoutingNumber = OldVendorRoutingNumber Then
            'Skip
        Else
            AuditComment = "Vendor Routing # changed to " + NewVendorRoutingNumber + " from " + OldVendorRoutingNumber

            UpdateAuditTrail()
        End If
        If NewCheckType = OldCheckType Then
            'Skip
        Else
            AuditComment = "Check Type changed to " + NewCheckType + " from " + OldCheckType

            UpdateAuditTrail()
        End If
        If NewWhitePaperCheck = OldWhitePaperCheck Then
            'Skip
        Else
            AuditComment = "White Paper Check changed to " + NewWhitePaperCheck + " from " + OldWhitePaperCheck

            UpdateAuditTrail()
        End If
        If NewBankAccountType = OldBankAccountType Then
            'Skip
        Else
            AuditComment = "Bank Account Type changed to " + NewBankAccountType + " from " + OldBankAccountType

            UpdateAuditTrail()
        End If

        'Clear Variables
        NewACHContactEmail = ""
        NewACHContactName = ""
        NewACHContactNumber = ""
        NewACHVerifyDate = ""
        NewVendorAccountNumber = ""
        NewVendorRoutingNumber = ""
        NewCheckType = "STANDARD"
        NewWhitePaperCheck = "NO"
        NewBankAccountType = ""
        OldACHContactEmail = ""
        OldACHContactName = ""
        OldACHContactNumber = ""
        OldACHVerifyDate = ""
        OldVendorAccountNumber = ""
        OldVendorRoutingNumber = ""
        OldCheckType = "STANDARD"
        OldWhitePaperCheck = "NO"
        OldBankAccountType = ""
        AuditComment = ""
        AuditVendor = ""
    End Sub

    Public Sub UpdateVendorTable()
        '*****************************************************************
        'ISO Details
        '*****************************************************************
        If chkIsoCompliant.Checked = True Then
            ISOCompliant = "YES"
        Else
            ISOCompliant = "NO"
        End If
        If chkProp65.Checked = True Then
            Prop65Compliant = "YES"
        Else
            Prop65Compliant = "NO"
        End If
        '*****************************************************************
        'ACH/White Paper Details
        '*****************************************************************
        If rdoChecking.Checked = True Then
            VendorAccountType = "C"
        Else
            VendorAccountType = "S"
        End If
        If chkWhitePaperCheck.Checked = True Then
            WhitePaperCheck = "YES"
        Else
            WhitePaperCheck = "NO"
        End If
        If rdoCheckCodeIntercompany.Checked = True Then
            CheckCode = "INTERCOMPANY"
        ElseIf rdoFedexCheck.Checked = True Then
            CheckCode = "FEDEX"
        ElseIf rdoOtherACH.Checked = True Then
            CheckCode = "ACH"
        Else
            CheckCode = "STANDARD"
        End If
        '*****************************************************************
        '1099 Information
        '*****************************************************************
        If chkVendor1099.Checked Then
            If txt1099Name.Text = "" Then
                Name1099 = ""
            Else
                Name1099 = txt1099Name.Text
            End If
        Else
            Name1099 = ""
        End If
        If chkVendor1099.Checked = True Then
            Checked1099 = "YES"
        Else
            Checked1099 = "NO"
        End If
        '****************************************************************
        'Validate Vendor Name and remiitance email
        '****************************************************************
        Dim CheckVendorNameField As String = ""
        Dim CheckRemittanceEmail As String = ""

        If txtVendorName.Text.Contains(",") Then
            CheckVendorNameField = txtVendorName.Text.Replace(",", "")
        Else
            CheckVendorNameField = txtVendorName.Text
        End If
        If CheckVendorNameField.Contains(vbCrLf) Then
            CheckVendorNameField = CheckVendorNameField.Replace(vbCrLf, "")
        Else
            'Do nothing
        End If
        If txtRemittanceEmail.Text.Contains(",") Then
            CheckRemittanceEmail = txtRemittanceEmail.Text.Replace(",", ";")
        Else
            CheckRemittanceEmail = txtRemittanceEmail.Text
        End If
        If CheckRemittanceEmail.Contains(vbCrLf) Then
            CheckRemittanceEmail = CheckRemittanceEmail.Replace(vbCrLf, "")
        Else
            'Do nothing
        End If

        txtVendorName.Text = CheckVendorNameField
        txtRemittanceEmail.Text = CheckRemittanceEmail
        '****************************************************************
        'Update existing vendor with changes
        cmd = New SqlCommand("UPDATE Vendor SET VendorName = @VendorName, ContactName = @ContactName, VendorAddress1 = @VendorAddress1, VendorAddress2 = @VendorAddress2, VendorCity = @VendorCity, VendorState = @VendorState, VendorZip = @VendorZip, VendorCountry = @VendorCountry, VendorPhone = @VendorPhone, VendorFax = @VendorFax, VendorEmail = @VendorEmail, PaymentTerms = @PaymentTerms, VendorClass = @VendorClass, VendorDate = @VendorDate, VendorComment = @VendorComment, VendorTaxID = @VendorTaxID, VendorPreferredShipping = @VendorPreferredShipping, CreditLimit = @CreditLimit, DefaultGLAccount = @DefaultGLAccount, DefaultItem = @DefaultItem, ApprovedBy = @ApprovedBy, ApprovalCriteria = @ApprovalCriteria, ApprovalDate = @ApprovalDate, ISOCompliant = @ISOCompliant, Prop65Compliant = @Prop65Compliant, WhitePaperCheck = @WhitePaperCheck, RemittanceEmail = @RemittanceEmail, CheckCode = @CheckCode, VendorAccountNumber = @VendorAccountNumber, VendorRoutingNumber = @VendorRoutingNumber, VendorAccountType = @VendorAccountType, ACHContactName = @ACHContactName, ACHContactNumber = @ACHContactNumber, ACHContactEmail = @ACHContactEmail, ACHVerifyDate = @ACHVerifyDate, Checked1099 = @Checked1099, Name1099 = @Name1099 WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@VendorName", SqlDbType.VarChar).Value = txtVendorName.Text
            .Add("@ContactName", SqlDbType.VarChar).Value = txtContactName.Text
            .Add("@VendorAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
            .Add("@VendorAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
            .Add("@VendorCity", SqlDbType.VarChar).Value = txtCity.Text
            .Add("@VendorState", SqlDbType.VarChar).Value = cboState.Text
            .Add("@VendorZip", SqlDbType.VarChar).Value = txtZipCode.Text
            .Add("@VendorCountry", SqlDbType.VarChar).Value = txtCountry.Text
            .Add("@VendorPhone", SqlDbType.VarChar).Value = txtPhoneNumber.Text
            .Add("@VendorFax", SqlDbType.VarChar).Value = txtFAXNumber.Text
            .Add("@VendorEmail", SqlDbType.VarChar).Value = txtVendorEmail.Text
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
            .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
            .Add("@VendorDate", SqlDbType.VarChar).Value = VendorDate
            .Add("@VendorComment", SqlDbType.VarChar).Value = txtVendorComment.Text
            .Add("@VendorTaxID", SqlDbType.VarChar).Value = txtVendorTaxID.Text
            .Add("@VendorPreferredShipping", SqlDbType.VarChar).Value = cboPreferredShipper.Text
            .Add("@CreditLimit", SqlDbType.VarChar).Value = Val(txtCreditLimit.Text)
            .Add("@DefaultGLAccount", SqlDbType.VarChar).Value = cboDefaultGLAccount.Text
            .Add("@DefaultItem", SqlDbType.VarChar).Value = cboDefaultItem.Text
            .Add("@ApprovedBy", SqlDbType.VarChar).Value = txtApprovedBy.Text
            .Add("@ApprovalCriteria", SqlDbType.VarChar).Value = cboApprovalCriteria.Text
            .Add("@ApprovalDate", SqlDbType.VarChar).Value = ApprovalDate
            .Add("@ISOCompliant", SqlDbType.VarChar).Value = ISOCompliant
            .Add("@Prop65Compliant", SqlDbType.VarChar).Value = Prop65Compliant
            .Add("@WhitePaperCheck", SqlDbType.VarChar).Value = WhitePaperCheck
            .Add("@RemittanceEmail", SqlDbType.VarChar).Value = txtRemittanceEmail.Text
            .Add("@CheckCode", SqlDbType.VarChar).Value = CheckCode
            .Add("@VendorAccountNumber", SqlDbType.VarChar).Value = txtVendorAccount.Text
            .Add("@VendorRoutingNumber", SqlDbType.VarChar).Value = txtRoutingNumber.Text
            .Add("@VendorAccountType", SqlDbType.VarChar).Value = VendorAccountType
            .Add("@ACHContactName", SqlDbType.VarChar).Value = txtACHContactName.Text
            .Add("@ACHContactNumber", SqlDbType.VarChar).Value = txtACHContactPhone.Text
            .Add("@ACHContactEmail", SqlDbType.VarChar).Value = txtACHContactEmail.Text
            .Add("@ACHVerifyDate", SqlDbType.VarChar).Value = txtACHVerifyDate.Text
            .Add("@Checked1099", SqlDbType.VarChar).Value = Checked1099
            .Add("@Name1099", SqlDbType.VarChar).Value = Name1099
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear Variables
        ISOCompliant = ""
        Prop65Compliant = ""
        WhitePaperCheck = ""
        CheckCode = ""
        PaymentTerms = ""
        VendorClass = ""
        Checked1099 = ""
        Name1099 = ""
    End Sub

    Public Sub InsertIntoVendorTable()
        '*****************************************************************
        'ISO Details
        '*****************************************************************
        If chkIsoCompliant.Checked = True Then
            ISOCompliant = "YES"
        Else
            ISOCompliant = "NO"
        End If
        If chkProp65.Checked = True Then
            Prop65Compliant = "YES"
        Else
            Prop65Compliant = "NO"
        End If
        '*****************************************************************
        'ACH/White Paper Details
        '*****************************************************************
        If rdoChecking.Checked = True Then
            VendorAccountType = "C"
        Else
            VendorAccountType = "S"
        End If
        If rdoCheckCodeIntercompany.Checked = True Then
            CheckCode = "INTERCOMPANY"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        ElseIf rdoFedexCheck.Checked = True Then
            CheckCode = "FEDEX"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        ElseIf rdoOtherACH.Checked = True Then
            CheckCode = "ACH"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        Else
            CheckCode = "STANDARD"
            chkWhitePaperCheck.Enabled = True
        End If
        If chkWhitePaperCheck.Checked = True Then
            WhitePaperCheck = "YES"
        Else
            WhitePaperCheck = "NO"
        End If
        '*****************************************************************
        '1099 Information
        '*****************************************************************
        If chkVendor1099.Checked Then
            If txt1099Name.Text = "" Then
                Name1099 = ""
            Else
                Name1099 = txt1099Name.Text
            End If
        Else
            Name1099 = ""
        End If
        If chkVendor1099.Checked = True Then
            Checked1099 = "YES"
        Else
            Checked1099 = "NO"
        End If
        'Insert Into Database
        cmd = New SqlCommand("INSERT INTO Vendor (VendorCode, DivisionID, VendorName, ContactName, VendorAddress1, VendorAddress2, VendorCity, VendorState, VendorZip, VendorCountry, VendorPhone, VendorFax, VendorEmail, PaymentTerms, VendorClass, VendorDate, VendorComment, VendorTaxID, VendorPreferredShipping, CreditLimit, DefaultGLAccount, DefaultItem, ApprovedBy, ApprovalCriteria, ApprovalDate, ISOCompliant, Prop65Compliant, WhitePaperCheck, RemittanceEmail, CheckCode, VendorAccountNumber, VendorRoutingNumber, VendorAccountType, ACHContactName, ACHContactNumber, ACHContactEmail, ACHVerifyDate, Checked1099, Name1099) Values (@VendorCode, @DivisionID, @VendorName, @ContactName, @VendorAddress1, @VendorAddress2, @VendorCity, @VendorState, @VendorZip, @VendorCountry, @VendorPhone, @VendorFax, @VendorEmail, @PaymentTerms, @VendorClass, @VendorDate, @VendorComment, @VendorTaxID, @VendorPreferredShipping, @CreditLimit, @DefaultGLAccount, @DefaultItem, @ApprovedBy, @ApprovalCriteria, @ApprovalDate, @ISOCompliant, @Prop65Compliant, @WhitePaperCheck, @RemittanceEmail, @CheckCode, @VendorAccountNumber, @VendorRoutingNumber, @VendorAccountType, @ACHContactName, @ACHContactNumber, @ACHContactEmail, @ACHVerifyDate, @Checked1099, @Name1099)", con)

        With cmd.Parameters
            .Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@VendorName", SqlDbType.VarChar).Value = txtVendorName.Text
            .Add("@ContactName", SqlDbType.VarChar).Value = txtContactName.Text
            .Add("@VendorAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
            .Add("@VendorAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
            .Add("@VendorCity", SqlDbType.VarChar).Value = txtCity.Text
            .Add("@VendorState", SqlDbType.VarChar).Value = cboState.Text
            .Add("@VendorZip", SqlDbType.VarChar).Value = txtZipCode.Text
            .Add("@VendorCountry", SqlDbType.VarChar).Value = txtCountry.Text
            .Add("@VendorPhone", SqlDbType.VarChar).Value = txtPhoneNumber.Text
            .Add("@VendorFax", SqlDbType.VarChar).Value = txtFAXNumber.Text
            .Add("@VendorEmail", SqlDbType.VarChar).Value = txtVendorEmail.Text
            .Add("@PaymentTerms", SqlDbType.VarChar).Value = PaymentTerms
            .Add("@VendorClass", SqlDbType.VarChar).Value = VendorClass
            .Add("@VendorDate", SqlDbType.VarChar).Value = VendorDate
            .Add("@VendorComment", SqlDbType.VarChar).Value = txtVendorComment.Text
            .Add("@VendorTaxID", SqlDbType.VarChar).Value = txtVendorTaxID.Text
            .Add("@VendorPreferredShipping", SqlDbType.VarChar).Value = cboPreferredShipper.Text
            .Add("@CreditLimit", SqlDbType.VarChar).Value = Val(txtCreditLimit.Text)
            .Add("@DefaultGLAccount", SqlDbType.VarChar).Value = cboDefaultGLAccount.Text
            .Add("@DefaultItem", SqlDbType.VarChar).Value = cboDefaultItem.Text
            .Add("@ApprovedBy", SqlDbType.VarChar).Value = txtApprovedBy.Text
            .Add("@ApprovalCriteria", SqlDbType.VarChar).Value = cboApprovalCriteria.Text
            .Add("@ApprovalDate", SqlDbType.VarChar).Value = ApprovalDate
            .Add("@ISOCompliant", SqlDbType.VarChar).Value = ISOCompliant
            .Add("@Prop65Compliant", SqlDbType.VarChar).Value = Prop65Compliant
            .Add("@WhitePaperCheck", SqlDbType.VarChar).Value = WhitePaperCheck
            .Add("@RemittanceEmail", SqlDbType.VarChar).Value = txtRemittanceEmail.Text
            .Add("@CheckCode", SqlDbType.VarChar).Value = CheckCode
            .Add("@VendorAccountNumber", SqlDbType.VarChar).Value = txtVendorAccount.Text
            .Add("@VendorRoutingNumber", SqlDbType.VarChar).Value = txtRoutingNumber.Text
            .Add("@VendorAccountType", SqlDbType.VarChar).Value = VendorAccountType
            .Add("@ACHContactName", SqlDbType.VarChar).Value = txtACHContactName.Text
            .Add("@ACHContactNumber", SqlDbType.VarChar).Value = txtACHContactPhone.Text
            .Add("@ACHContactEmail", SqlDbType.VarChar).Value = txtACHContactEmail.Text
            .Add("@ACHVerifyDate", SqlDbType.VarChar).Value = txtACHVerifyDate.Text
            .Add("@Checked1099", SqlDbType.VarChar).Value = Checked1099
            .Add("@Name1099", SqlDbType.VarChar).Value = Name1099
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Insert into Audit Trail Table
        AuditComment = "New Vendor Created"
        UpdateAuditTrail()

        'Clear Variables
        ISOCompliant = ""
        Prop65Compliant = ""
        WhitePaperCheck = ""
        CheckCode = ""
        PaymentTerms = ""
        VendorClass = ""
        Checked1099 = ""
        Name1099 = ""
    End Sub

    'Command button events

    Private Sub cmdOpenViewPurchasesForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenViewPurchasesForm.Click
        If cboVendorID.Text <> "" Then
            cmdSave_Click(sender, e)
        End If

        GlobalVendorID = cboVendorID.Text
        GlobalDivisionCode = cboDivisionID.Text

        If cboVendorClass.Text = "SteelVendor" Then
            GlobalVendorType = "STEEL VENDOR"
        Else
            GlobalVendorType = "REGULAR VENDOR"
        End If

        Using NewVendorPurchasePopup As New VendorPurchasePopup
            Dim result = NewVendorPurchasePopup.ShowDialog()
        End Using
    End Sub

    Private Sub cmdOpenVendorReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenVendorReturns.Click
        If cboVendorID.Text <> "" Then
            cmdSave_Click(sender, e)
        End If

        GlobalVendorID = cboVendorID.Text

        Using NewVendorReturnForm As New VendorReturnForm
            Dim result = NewVendorReturnForm.ShowDialog()
        End Using
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Create command to update database and fill with text box enties
        If canSave() Then
            If Not String.IsNullOrEmpty(cboDefaultItem.Text) Then
                'Check to see if Item already exists
                Dim CheckItemStatement As String = "SELECT COUNT(ItemID) FROM NonInventoryItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
                Dim CheckItemCommand As New SqlCommand(CheckItemStatement, con)
                CheckItemCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboDefaultItem.Text
                CheckItemCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckItem = CInt(CheckItemCommand.ExecuteScalar)
                Catch ex As System.Exception
                    CheckItem = 0
                End Try
                con.Close()

                If CheckItem = 0 And cboDefaultGLAccount.Text <> "" Then 'Item does not exist - create new
                    'Insert new Item into Non Inventory Item List
                    cmd = New SqlCommand("INSERT INTO NonInventoryItemList (ItemID, ShortDescription, LongDescription, ItemClass, PurchaseProductLine, SalesProductLine, StandardCost, StandardOrderQuantity, DivisionID, CreationDate, PreferredVendor, Comment, GLDebitAccount, GLCreditAccount) Values (@ItemID, @ShortDescription, @LongDescription, @ItemClass, @PurchaseProductLine, @SalesProductLine, @StandardCost, @StandardOrderQuantity, @DivisionID, @CreationDate, @PreferredVendor, @Comment, @GLDebitAccount, @GLCreditAccount)", con)

                    With cmd.Parameters
                        .Add("@ItemID", SqlDbType.VarChar).Value = cboDefaultItem.Text
                        .Add("@ShortDescription", SqlDbType.VarChar).Value = txtItemDescription.Text
                        .Add("@LongDescription", SqlDbType.VarChar).Value = txtItemDescription.Text
                        .Add("@ItemClass", SqlDbType.VarChar).Value = "EXPENSES"
                        .Add("@PurchaseProductLine", SqlDbType.VarChar).Value = "EXPENSES"
                        .Add("@SalesProductLine", SqlDbType.VarChar).Value = "SUPPLY"
                        .Add("@StandardCost", SqlDbType.VarChar).Value = 0
                        .Add("@StandardOrderQuantity", SqlDbType.VarChar).Value = 0
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@CreationDate", SqlDbType.VarChar).Value = Today()
                        .Add("@PreferredVendor", SqlDbType.VarChar).Value = ""
                        .Add("@Comment", SqlDbType.VarChar).Value = ""
                        .Add("@GLDebitAccount", SqlDbType.VarChar).Value = cboDefaultGLAccount.Text
                        .Add("@GLCreditAccount", SqlDbType.VarChar).Value = "20000"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf CheckItem = 0 And cboDefaultGLAccount.Text = "" Then
                    MsgBox("Cannot create new Non Inventory Item - no default GL Account.", MsgBoxStyle.OkOnly)
                Else
                    'Item already exists - do nothing
                End If
            End If

            'Fill Defaults
            ApprovalDate = dtpApprovalDate.Value
            VendorDate = dtpVendorDate.Value

            If String.IsNullOrEmpty(cboVendorClass.Text) Then
                ValidateVendor()
                cboVendorClass.Text = "OTHER"
            End If

            VendorClass = cboVendorClass.Text
            PaymentTerms = cboPaymentTerms.Text

            'Add to database
            Try
                InsertIntoVendorTable()
            Catch ex As System.Exception
                ValidateVendorBankInfo()
                UpdateVendorTable()
            End Try

            MsgBox("Vendor data has been saved.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        LoadVendor()
        ClearVariables()
        ClearAllDataFields()
    End Sub

    Private Sub cmdPurchaseAnalysisReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPurchaseAnalysisReport.Click
        If cboVendorID.Text <> "" Then
            cmdSave_Click(sender, e)
        End If

        GlobalVendorID = cboVendorID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintVendorPurchaseHistory As New PrintVendorPurchaseHistory
            Dim Result = NewPrintVendorPurchaseHistory.ShowDialog()
        End Using
    End Sub

    Private Sub cmdVendorListingReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVendorListingReport.Click
        If cboVendorID.Text <> "" Then
            cmdSave_Click(sender, e)
        End If

        GlobalVendorID = cboVendorID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintVendorList As New PrintVendorList
            Dim Result = NewPrintVendorList.ShowDialog()
        End Using
    End Sub

    Private Sub cmdVendorReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVendorReturns.Click
        If cboVendorID.Text <> "" Then
            cmdSave_Click(sender, e)
        End If

        GlobalVendorID = cboVendorID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Dim NewPrintVendorReturnListing As New PrintVendorReturnListing
        NewPrintVendorReturnListing.Show()
    End Sub

    Private Sub cmdOpenPOForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenPOForm.Click
        If cboVendorID.Text <> "" Then
            cmdSave_Click(sender, e)
        End If

        GlobalVendorID = cboVendorID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Dim NewPOForm As New POForm
        NewPOForm.Show()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboVendorID.Text <> "" Then
            cmdSave_Click(sender, e)
        End If

        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintVendorList As New PrintVendorList
            Dim result = NewPrintVendorList.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        If cboVendorID.Text = "" Then
            ClearVariables()
            ClearAllDataFields()

            Me.Dispose()
            Me.Close()
        Else
            ClearVariables()
            ClearAllDataFields()

            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If canDelete() Then
            cmd = New SqlCommand("Delete FROM Vendor WHERE VendorCode = @VendorCode and DivisionID = @DivisionID", con)
            cmd.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            MsgBox("Vendor has been deleted.", MsgBoxStyle.OkOnly)

            'Clear all text boxes after entry
            ClearVariables()
            ClearAllDataFields()
            LoadVendor()
        End If
    End Sub

    Private Sub cmdPurchaseActivityReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPurchaseActivityReport.Click
        If cboVendorID.Text <> "" Then
            cmdSave_Click(sender, e)
        End If

        GlobalVendorID = cboVendorID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintVendorPurchaseHistory As New PrintVendorPurchaseHistory
            Dim Result = PrintVendorPurchaseHistory.ShowDialog()
        End Using
    End Sub

    Private Sub cmdAgedPayablesReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgedPayablesReport.Click
        If cboVendorID.Text <> "" Then
            cmdSave_Click(sender, e)
        End If

        GlobalVendorID = cboVendorID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintAPAging As New PrintAPAging
            Dim Result = NewPrintAPAging.ShowDialog()
        End Using
    End Sub

    Private Sub cmdPaymentActivityReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPaymentActivityReport.Click
        If cboVendorID.Text <> "" Then
            cmdSave_Click(sender, e)
        End If

        GlobalVendorID = cboVendorID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintVendorPaymentHistory As New PrintVendorPaymentHistory
            Dim Result = NewPrintVendorPaymentHistory.ShowDialog()
        End Using
    End Sub

    'Menustrip events

    Private Sub SaveVendorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveVendorToolStripMenuItem.Click
        cmdSave_Click(sender, e)
    End Sub

    Private Sub DeleteVendorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteVendorToolStripMenuItem.Click
        cmdDelete_Click(sender, e)
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        cmdExit_Click(sender, e)
    End Sub

    Private Sub PrintVendorPaymentHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintVendorPaymentHistoryToolStripMenuItem.Click
        cmdPaymentActivityReport_Click(sender, e)
    End Sub

    Private Sub PrintVendorPurchaseHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintVendorPurchaseHistoryToolStripMenuItem.Click
        cmdPurchaseActivityReport_Click(sender, e)
    End Sub

    Private Sub PrintVendorListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintVendorListingToolStripMenuItem.Click
        cmdVendorListingReport_Click(sender, e)
    End Sub

    Private Sub PrintAPAgingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintAPAgingToolStripMenuItem.Click
        cmdAgedPayablesReport_Click(sender, e)
    End Sub

    Private Sub PrintPaymentActivityReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPaymentActivityReportToolStripMenuItem.Click
        cmdPaymentActivityReport_Click(sender, e)
    End Sub

    Private Sub PrintPurchaseAnalysisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPurchaseAnalysisToolStripMenuItem.Click
        If cboVendorID.Text <> "" Then
            cmdSave_Click(sender, e)
        End If

        GlobalVendorID = cboVendorID.Text
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintVendorPurchaseHistory As New PrintVendorPurchaseHistory
            Dim Result = NewPrintVendorPurchaseHistory.ShowDialog()
        End Using
    End Sub

    Private Sub PrintVendorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintVendorToolStripMenuItem.Click
        cmdPrint_Click(sender, e)
    End Sub

    Private Sub PrintPurchaseActivityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPurchaseActivityToolStripMenuItem.Click
        cmdPurchaseActivityReport_Click(sender, e)
    End Sub

    Private Sub ClearDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDataToolStripMenuItem.Click
        cmdClear_Click(sender, e)
    End Sub

    'Combox events

    Private Sub cboAccountDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountDescription.SelectedIndexChanged
        If cboAccountDescription.Text = "" Then
            'do nothing
        Else
            LoadGLAccountByDescription()
        End If
    End Sub

    Private Sub cboDefaultGLAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDefaultGLAccount.SelectedIndexChanged
        If cboDefaultGLAccount.Text = "" Then
            'do nothing
        Else
            LoadGLDescriptionByAccount()
        End If
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadVendorClass()
        LoadGLAccountNumber()
        LoadGLAccountDescription()
        LoadNonInventoryPartNumber()
        LoadVendor()

        'ClearAllDataFields()

        If GlobalVendorID = "" Then
            cboVendorID.SelectedIndex = -1
        Else
            cboVendorID.Text = GlobalVendorID
        End If
    End Sub

    Private Sub cboVendorID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVendorID.TextChanged
        'Clear vendor fields once they start typing until the load event
        ClearOnVendorChange()
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        ClearOnVendorChange()

        LoadVendorClass()
        LoadVendorInfo()
        LoadMTDPurchases()
        LoadYTDPurchases()
        LoadMTDVouchers()
        LoadYTDVouchers()
        LoadLastActivity()
        LoadOutStandingBalance()

        Dim W9Exists As String = "\\TFP-FS\TrufitBanking\Uploaded W-9\" + cboVendorID.Text + "-W9" + ".pdf"
        If File.Exists(W9Exists) Then
            cmdScanW9.Enabled = False
            cmdUploadOpenW9.Text = "Open W9"
        Else
            cmdScanW9.Enabled = True
            cmdUploadOpenW9.Text = "Upload W9"
        End If
    End Sub

    Private Sub cboDefaultItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDefaultItem.SelectedIndexChanged
        LoadNoninventoryDescription()
    End Sub

    Private Sub cboVendorID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVendorID.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboVendorClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVendorClass.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboDefaultItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDefaultItem.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboPreferredShipper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPreferredShipper.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboDefaultGLAccount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDefaultGLAccount.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub cboAccountDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAccountDescription.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    'Textbox events


    'Clear Routines

    Public Sub ClearVariables()
        LastActivity = ""
        DefaultItem = ""
        VendorName = ""
        ContactName = ""
        VendorAddress1 = ""
        VendorAddress2 = ""
        VendorCity = ""
        VendorState = ""
        VendorZip = ""
        VendorCountry = ""
        VendorPhone = ""
        VendorFax = ""
        VendorEmail = ""
        PaymentTerms = ""
        VendorClass = ""
        VendorComment = ""
        VendorTaxID = ""
        VendorPreferredShipper = ""
        DefaultGLAccount = ""
        CreditLimit = 0
        YearOfYear = 0
        MonthOfYear = 0
        Year = 0
        strMonthOfYear = ""
        strYear = ""
        MTDPurchases = 0
        YTDPurchases = 0
        MTDVouchers = 0
        YTDVouchers = 0
        GlobalVendorID = ""
        GlobalVendorName = ""
        CurrentBalance = 0
        ItemDescription = ""
        ItemGLAccount = ""
        ApprovedBy = ""
        ApprovalCriteria = ""
        ISOCompliant = ""
        CheckPurchaseOrder = 0
        CheckVoucher = 0
        CheckDeleteValidation = 0
        Prop65Compliant = "NO"
        WhitePaperCheck = "NO"
        RemittanceEmail = ""
        CheckCode = ""
        VendorAccountNumber = ""
        VendorAccountType = ""
        VendorRoutingNumber = ""
        ACHContactName = ""
        ACHContactNumber = ""
        ACHContactEmail = ""
        ACHVerifyDate = ""
        Checked1099 = ""
    End Sub

    Public Sub ClearOnVendorChange()
        cboPaymentTerms.Refresh()
        cboVendorClass.Refresh()
        cboPreferredShipper.Refresh()
        cboState.Refresh()
        cboDefaultGLAccount.Refresh()
        cboAccountDescription.Refresh()
        cboDefaultItem.Refresh()

        cboPaymentTerms.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboVendorClass.Text) Then
            cboVendorClass.Text = ""
        End If

        cboPreferredShipper.SelectedIndex = -1
        cboState.SelectedIndex = -1
        cboDefaultGLAccount.SelectedIndex = -1
        cboDefaultItem.SelectedIndex = -1
        cboAccountDescription.SelectedIndex = -1
        cboApprovalCriteria.SelectedIndex = -1

        txtAddress1.Refresh()
        txtAddress2.Refresh()
        txtCity.Refresh()
        txtVendorComment.Refresh()
        txtContactName.Refresh()
        txtCountry.Refresh()
        txtVendorEmail.Refresh()
        txtFAXNumber.Refresh()
        txtPhoneNumber.Refresh()
        txtVendorTaxID.Refresh()
        txtZipCode.Refresh()
        txtCreditLimit.Refresh()
        txtCurrentBalance.Refresh()
        txtVendorName.Refresh()
        txtItemDescription.Refresh()
        txtApprovedBy.Refresh()
        txtMTDVouchers.Refresh()
        txtMTDPurchases.Refresh()
        txtYTDPurchases.Refresh()
        txtYTDVouchers.Refresh()
        txtMTDSteel.Refresh()
        txtTotalMTD.Refresh()
        txtYTDSteel.Refresh()
        txtTotalYTD.Refresh()
        txtRemittanceEmail.Refresh()
        txtRoutingNumber.Refresh()
        txtVendorAccount.Refresh()
        txtACHContactEmail.Refresh()
        txtACHContactName.Refresh()
        txtACHContactPhone.Refresh()
        txtACHVerifyDate.Refresh()

        txtAddress1.Clear()
        txtAddress2.Clear()
        txtCity.Clear()
        txtVendorComment.Clear()
        txtContactName.Clear()
        txtCountry.Clear()
        txtVendorEmail.Clear()
        txtFAXNumber.Clear()
        txtPhoneNumber.Clear()
        txtVendorTaxID.Clear()
        txtZipCode.Clear()
        txtCreditLimit.Clear()
        txtCurrentBalance.Clear()
        txtVendorName.Clear()
        txtItemDescription.Clear()
        txtApprovedBy.Clear()
        txtMTDVouchers.Clear()
        txtMTDPurchases.Clear()
        txtYTDPurchases.Clear()
        txtYTDVouchers.Clear()
        txtMTDSteel.Clear()
        txtTotalMTD.Clear()
        txtYTDSteel.Clear()
        txtTotalYTD.Clear()
        txtRemittanceEmail.Clear()
        txtRoutingNumber.Clear()
        txtVendorAccount.Clear()
        txtACHContactEmail.Clear()
        txtACHContactName.Clear()
        txtACHContactPhone.Clear()
        txtACHVerifyDate.Clear()

        dtpApprovalDate.Text = ""
        dtpVendorDate.Text = ""

        chkProp65.Checked = False
        chkIsoCompliant.Checked = False
        chkWhitePaperCheck.Checked = False
        chkVendor1099.Checked = False

        rdoCheckCodeIntercompany.Checked = False
        rdoCheckCodeStandard.Checked = True

        'cboVendorID.Focus()
    End Sub

    Public Sub ClearAllDataFields()
        cboVendorID.Text = ""

        cboPaymentTerms.Refresh()
        cboVendorClass.Refresh()
        cboPreferredShipper.Refresh()
        cboState.Refresh()
        cboVendorID.Refresh()
        cboDefaultGLAccount.Refresh()
        cboAccountDescription.Refresh()
        cboDefaultItem.Refresh()

        cboPaymentTerms.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1

        If Not String.IsNullOrEmpty(cboVendorClass.Text) Then
            cboVendorClass.Text = ""
        End If

        cboPreferredShipper.SelectedIndex = -1
        cboState.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboDefaultGLAccount.SelectedIndex = -1
        cboDefaultItem.SelectedIndex = -1
        cboAccountDescription.SelectedIndex = -1
        cboApprovalCriteria.SelectedIndex = -1

        txtAddress1.Refresh()
        txtAddress2.Refresh()
        txtCity.Refresh()
        txtVendorComment.Refresh()
        txtContactName.Refresh()
        txtCountry.Refresh()
        txtVendorEmail.Refresh()
        txtFAXNumber.Refresh()
        txtPhoneNumber.Refresh()
        txtVendorTaxID.Refresh()
        txtZipCode.Refresh()
        txtCreditLimit.Refresh()
        txtCurrentBalance.Refresh()
        txtVendorName.Refresh()
        txtItemDescription.Refresh()
        txtApprovedBy.Refresh()
        txtMTDVouchers.Refresh()
        txtMTDPurchases.Refresh()
        txtYTDPurchases.Refresh()
        txtYTDVouchers.Refresh()
        txtMTDSteel.Refresh()
        txtTotalMTD.Refresh()
        txtYTDSteel.Refresh()
        txtTotalYTD.Refresh()
        txtRemittanceEmail.Refresh()
        txtVendorAccount.Refresh()
        txtRoutingNumber.Refresh()
        txtACHContactEmail.Refresh()
        txtACHContactName.Refresh()
        txtACHContactPhone.Refresh()
        txtACHVerifyDate.Refresh()
        txt1099Name.Refresh()

        txtAddress1.Clear()
        txtAddress2.Clear()
        txtCity.Clear()
        txtVendorComment.Clear()
        txtContactName.Clear()
        txtCountry.Clear()
        txtVendorEmail.Clear()
        txtFAXNumber.Clear()
        txtPhoneNumber.Clear()
        txtVendorTaxID.Clear()
        txtZipCode.Clear()
        txtCreditLimit.Clear()
        txtCurrentBalance.Clear()
        txtVendorName.Clear()
        txtItemDescription.Clear()
        txtApprovedBy.Clear()
        txtMTDVouchers.Clear()
        txtMTDPurchases.Clear()
        txtYTDPurchases.Clear()
        txtYTDVouchers.Clear()
        txtMTDSteel.Clear()
        txtTotalMTD.Clear()
        txtYTDSteel.Clear()
        txtTotalYTD.Clear()
        txtRemittanceEmail.Clear()
        txtRoutingNumber.Clear()
        txtVendorAccount.Clear()
        txtRoutingNumber.Clear()
        txtACHContactEmail.Clear()
        txtACHContactName.Clear()
        txtACHContactPhone.Clear()
        txtACHVerifyDate.Clear()
        txt1099Name.Clear()

        dtpApprovalDate.Text = ""
        dtpVendorDate.Text = ""

        chkIsoCompliant.Checked = False
        chkProp65.Checked = False
        chkWhitePaperCheck.Checked = False
        chkVendor1099.Checked = False
        rdoCheckCodeIntercompany.Checked = False
        rdoCheckCodeStandard.Checked = True
        rdoChecking.Checked = True

        cboVendorID.Focus()
    End Sub

    Private Sub rdoCheckCodeIntercompany_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCheckCodeIntercompany.CheckedChanged
        If rdoCheckCodeIntercompany.Checked = True Then
            CheckCode = "INTERCOMPANY"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        ElseIf rdoFedexCheck.Checked = True Then
            CheckCode = "FEDEX"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        ElseIf rdoOtherACH.Checked = True Then
            CheckCode = "ACH"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        Else
            CheckCode = "STANDARD"
            chkWhitePaperCheck.Enabled = True
        End If
    End Sub

    Private Sub rdoCheckCodeStandard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoCheckCodeStandard.CheckedChanged
        If rdoCheckCodeIntercompany.Checked = True Then
            CheckCode = "INTERCOMPANY"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        ElseIf rdoFedexCheck.Checked = True Then
            CheckCode = "FEDEX"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        ElseIf rdoOtherACH.Checked = True Then
            CheckCode = "ACH"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        Else
            CheckCode = "STANDARD"
            chkWhitePaperCheck.Enabled = True
        End If
    End Sub

    Private Sub rdoFedexCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoFedexCheck.CheckedChanged
        If rdoCheckCodeIntercompany.Checked = True Then
            CheckCode = "INTERCOMPANY"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        ElseIf rdoFedexCheck.Checked = True Then
            CheckCode = "FEDEX"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        ElseIf rdoOtherACH.Checked = True Then
            CheckCode = "ACH"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        Else
            CheckCode = "STANDARD"
            chkWhitePaperCheck.Enabled = True
        End If
    End Sub

    Private Sub rdoOtherACH_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoOtherACH.CheckedChanged
        If rdoCheckCodeIntercompany.Checked = True Then
            CheckCode = "INTERCOMPANY"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        ElseIf rdoFedexCheck.Checked = True Then
            CheckCode = "FEDEX"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        ElseIf rdoOtherACH.Checked = True Then
            CheckCode = "ACH"
            chkWhitePaperCheck.Enabled = False
            chkWhitePaperCheck.Checked = False
        Else
            CheckCode = "STANDARD"
            chkWhitePaperCheck.Enabled = True
        End If
    End Sub

    Private Sub cmdUploadOpenW9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadOpenW9.Click
        If canSave() Then

            Dim W9Exist As String = "\\TFP-FS\TrufitBanking\Uploaded W-9\" + cboVendorID.Text + "-W9" + ".pdf"
            If File.Exists(W9Exist) Then
                System.Diagnostics.Process.Start(W9Exist)
            Else
                Try
                    Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                    If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                    If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
                Catch ex As System.Exception
                End Try

                Dim MoveLocation As String = "\\TFP-FS\TrufitBanking\Uploaded W-9\"
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
                    Dim rename As String = cboVendorID.Text + "-W9" + ".pdf"
                    My.Computer.FileSystem.RenameFile(destinationPath, rename)
                    MsgBox("File Moved")
                    Dim W9Exists As String = "\\TFP-FS\TrufitBanking\Uploaded W-9\" + cboVendorID.Text + "-W9" + ".pdf"
                    If File.Exists(W9Exists) Then
                        cmdScanW9.Enabled = False
                        cmdUploadOpenW9.Text = "Open W9"
                    Else
                        cmdScanW9.Enabled = True
                        cmdUploadOpenW9.Text = "Upload W9"
                    End If

                Else
                    MsgBox("File Not move")
                End If
            End If
        End If
    End Sub

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

    Private Sub cmdScanW9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScanW9.Click
        ScanW9()
    End Sub

    Public Sub UploadW9()
        'Variables Declared
        Dim comboboxSelection As String = cboVendorID.Text

        Dim strDir As String = "\\TFP-FS\TrufitBanking\Uploaded W-9\"
        If Not System.IO.Directory.Exists(strDir) Then System.IO.Directory.CreateDirectory(strDir)

        'Name of file
        'Blueprint+Revision " " fox number " " month-day-year " " seconds
        Dim strFilename As String = cboVendorID.Text + "-W9.pdf"
        'path to bmp
        Dim strPathname = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\" & GlobalVariables.NextPrevious & ".bmp"
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
        MessageBox.Show("Save Confirmation", "Saved W9 PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        'declares list of bmp files to be counted
        Dim extensions As New List(Of String)
        extensions.Add("*.bmp")
        Dim pathname2 As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\WIA Testing\"

        GlobalVariables.previousScan = True
    End Sub

    Public Sub ScanW9()
        Dim W9Exists2 As String = "\\TFP-FS\TrufitBanking\Uploaded W-9\" + cboVendorID.Text + "-W9" + ".pdf"
        If File.Exists(W9Exists2) Then
            Dim result As DialogResult = MessageBox.Show("File Exists Already. Overwrite Current W9?", "W9 Form", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                Exit Sub
            ElseIf result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                My.Computer.FileSystem.DeleteFile(W9Exists2)
            End If
        End If
        If canSave() Then
            ' Deletes the WIA testing temp file
            Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
            If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
            ' Creates the folder if the temp folder is not currently created
            If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
            'txtBlueprintNumber.Text = Nothing
            'txtFOXNumber.Text = Nothing
            'txtRevisionLevel.Text = Nothing
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
                    Using fs As New System.IO.FileStream(pathname, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    End Using
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

            Try
                UploadW9()
                Dim W9Exists As String = "\\TFP-FS\TrufitBanking\Uploaded W-9\" + cboVendorID.Text + "-W9" + ".pdf"
                If File.Exists(W9Exists) Then
                    cmdScanW9.Enabled = False
                    cmdUploadOpenW9.Text = "Open W9"
                Else
                    cmdScanW9.Enabled = True
                    cmdUploadOpenW9.Text = "Upload W9"
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub UploadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadToolStripMenuItem.Click
        If canSave() Then

            Dim W9Exist As String = "\\TFP-FS\TrufitBanking\Uploaded W-9\" + cboVendorID.Text + "-W9" + ".pdf"
            If File.Exists(W9Exist) Then
                File.Delete(W9Exist)
            End If


            Try
                Dim path As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing\"
                If System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then DeleteDirectory(path)
                If Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing") Then System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "\WIA Testing")
            Catch ex As System.Exception
            End Try

            Dim MoveLocation As String = "\\TFP-FS\TrufitBanking\Uploaded W-9\"
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
                Dim rename As String = cboVendorID.Text + "-W9" + ".pdf"
                My.Computer.FileSystem.RenameFile(destinationPath, rename)
                MsgBox("File Moved")
                Dim W9Exists As String = "\\TFP-FS\TrufitBanking\Uploaded W-9\" + cboVendorID.Text + "-W9" + ".pdf"
                If File.Exists(W9Exists) Then
                    cmdScanW9.Enabled = False
                    cmdUploadOpenW9.Text = "Open W9"
                Else
                    cmdScanW9.Enabled = True
                    cmdUploadOpenW9.Text = "Upload W9"
                End If

            Else
                MsgBox("File Not move")
            End If
        End If

    End Sub

    Private Sub ScanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanToolStripMenuItem.Click
        ScanW9()
    End Sub

 
End Class