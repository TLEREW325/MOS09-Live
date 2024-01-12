Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Public Class IntercompanyEliminations
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myadapter8 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim IntercompanySales, IntercompanyAR, IntercompanyAP As Double
    Dim ATLSalesTotal, ATLPurchaseTotal, ATLARTotal, ATLAPTotal As Double
    Dim CBSSalesTotal, CBSPurchaseTotal, CBSARTotal, CBSAPTotal As Double
    Dim CGOSalesTotal, CGOPurchaseTotal, CGOARTotal, CGOAPTotal As Double
    Dim CHTSalesTotal, CHTPurchaseTotal, CHTARTotal, CHTAPTotal As Double
    Dim DENSalesTotal, DENPurchaseTotal, DENARTotal, DENAPTotal As Double
    Dim HOUSalesTotal, HOUPurchaseTotal, HOUARTotal, HOUAPTotal As Double
    Dim SLCSalesTotal, SLCPurchaseTotal, SLCARTotal, SLCAPTotal As Double
    Dim TFFSalesTotal, TFFPurchaseTotal, TFFARTotal, TFFAPTotal As Double
    Dim TFPSalesTotal, TFPPurchaseTotal, TFPARTotal, TFPAPTotal As Double
    Dim TFTSalesTotal, TFTPurchaseTotal, TFTARTotal, TFTAPTotal As Double
    Dim TORSalesTotal, TORPurchaseTotal, TORARTotal, TORAPTotal As Double
    Dim TWDSalesTotal, TWDPurchaseTotal, TWDARTotal, TWDAPTotal As Double
    Dim TWESalesTotal, TWEPurchaseTotal, TWEARTotal, TWEAPTotal As Double
    Dim ALBSalesTotal, ALBPurchaseTotal, ALBARTotal, ALBAPTotal As Double
    Dim TFJSalesTotal, TFJPurchaseTotal, TFJARTotal, TFJAPTotal As Double

    Dim DivisionFilter As String = ""
    Dim DivisionCounter As Integer = 1
    Dim DivisionIndex(15) As String

    Public Function FillDivisionArray()
        'Define Divisions by index
        DivisionIndex(1) = "ATL"
        DivisionIndex(2) = "CBS"
        DivisionIndex(3) = "CGO"
        DivisionIndex(4) = "CHT"
        DivisionIndex(5) = "DEN"
        DivisionIndex(6) = "HOU"
        DivisionIndex(7) = "SLC"
        DivisionIndex(8) = "TFF"
        DivisionIndex(9) = "TFP"
        DivisionIndex(10) = "TFT"
        DivisionIndex(11) = "TOR"
        DivisionIndex(12) = "TWD"
        DivisionIndex(13) = "TWE"
        DivisionIndex(14) = "ALB"
        DivisionIndex(15) = "TFJ"
    End Function

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

    Private Sub IntercompanyEliminations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub LoadDataForOneDivision()

    End Sub

    Public Sub LoadDataForAllDivisions()
        Dim TempAR1, TempAR2, TempAP1, TempAP2 As Double

        '******************************************************************************
        Dim ATLSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim ATLSalesCommand As New SqlCommand(ATLSalesStatement, con)
        ATLSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP ATLANTA"
        ATLSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        ATLSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        ATLSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim ATLPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim ATLPurchasesCommand As New SqlCommand(ATLPurchasesStatement, con)
        ATLPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP ATLANTA"
        ATLPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        ATLPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        ATLPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim ATLAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim ATLAP1Command As New SqlCommand(ATLAP1Statement, con)
        ATLAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP ATLANTA"
        ATLAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        ATLAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim ATLAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim ATLAP2Command As New SqlCommand(ATLAP2Statement, con)
        ATLAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP ATLANTA"
        ATLAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        ATLAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim ATLAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim ATLAR1Command As New SqlCommand(ATLAR1Statement, con)
        ATLAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP ATLANTA"
        ATLAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        ATLAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim ATLAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim ATLAR2Command As New SqlCommand(ATLAR2Statement, con)
        ATLAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP ATLANTA"
        ATLAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        ATLAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ATLSalesTotal = CDbl(ATLSalesCommand.ExecuteScalar)
        Catch ex As Exception
            ATLSalesTotal = 0
        End Try
        Try
            ATLPurchaseTotal = CDbl(ATLPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            ATLPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(ATLAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(ATLAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(ATLAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(ATLAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        ATLAPTotal = TempAP1 - TempAP2
        ATLARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim CBSSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim CBSSalesCommand As New SqlCommand(CBSSalesStatement, con)
        CBSSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP NEVADA"
        CBSSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CBSSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        CBSSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CBSPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim CBSPurchasesCommand As New SqlCommand(CBSPurchasesStatement, con)
        CBSPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP NEVADA"
        CBSPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CBSPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        CBSPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CBSAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim CBSAP1Command As New SqlCommand(CBSAP1Statement, con)
        CBSAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP NEVADA"
        CBSAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CBSAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CBSAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim CBSAP2Command As New SqlCommand(CBSAP2Statement, con)
        CBSAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP NEVADA"
        CBSAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CBSAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CBSAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim CBSAR1Command As New SqlCommand(CBSAR1Statement, con)
        CBSAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP NEVADA"
        CBSAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CBSAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CBSAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim CBSAR2Command As New SqlCommand(CBSAR2Statement, con)
        CBSAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP NEVADA"
        CBSAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CBSAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CBSSalesTotal = CDbl(CBSSalesCommand.ExecuteScalar)
        Catch ex As Exception
            CBSSalesTotal = 0
        End Try
        Try
            CBSPurchaseTotal = CDbl(CBSPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            CBSPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(CBSAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(CBSAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(CBSAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(CBSAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        CBSAPTotal = TempAP1 - TempAP2
        CBSARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim CGOSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim CGOSalesCommand As New SqlCommand(CGOSalesStatement, con)
        CGOSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP INDIANA"
        CGOSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CGOSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        CGOSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CGOPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim CGOPurchasesCommand As New SqlCommand(CGOPurchasesStatement, con)
        CGOPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP INDIANA"
        CGOPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CGOPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        CGOPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CGOAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim CGOAP1Command As New SqlCommand(CGOAP1Statement, con)
        CGOAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP INDIANA"
        CGOAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CGOAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CGOAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim CGOAP2Command As New SqlCommand(CGOAP2Statement, con)
        CGOAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP INDIANA"
        CGOAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CGOAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CGOAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim CGOAR1Command As New SqlCommand(CGOAR1Statement, con)
        CGOAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP INDIANA"
        CGOAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CGOAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CGOAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim CGOAR2Command As New SqlCommand(CGOAR2Statement, con)
        CGOAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP INDIANA"
        CGOAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CGOAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CGOSalesTotal = CDbl(CGOSalesCommand.ExecuteScalar)
        Catch ex As Exception
            CGOSalesTotal = 0
        End Try
        Try
            CGOPurchaseTotal = CDbl(CGOPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            CGOPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(CGOAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(CGOAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(CGOAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(CGOAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        CGOAPTotal = TempAP1 - TempAP2
        CGOARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim CHTSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim CHTSalesCommand As New SqlCommand(CHTSalesStatement, con)
        CHTSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "WELDING CERAMICS"
        CHTSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CHTSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        CHTSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CHTPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim CHTPurchasesCommand As New SqlCommand(CHTPurchasesStatement, con)
        CHTPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "WELDING CERAMICS"
        CHTPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CHTPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        CHTPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CHTAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim CHTAP1Command As New SqlCommand(CHTAP1Statement, con)
        CHTAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "WELDING CERAMICS"
        CHTAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CHTAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CHTAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim CHTAP2Command As New SqlCommand(CHTAP2Statement, con)
        CHTAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "WELDING CERAMICS"
        CHTAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CHTAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CHTAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim CHTAR1Command As New SqlCommand(CHTAR1Statement, con)
        CHTAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "WELDING CERAMICS"
        CHTAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CHTAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim CHTAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim CHTAR2Command As New SqlCommand(CHTAR2Statement, con)
        CHTAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "WELDING CERAMICS"
        CHTAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        CHTAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CHTSalesTotal = CDbl(CHTSalesCommand.ExecuteScalar)
        Catch ex As Exception
            CHTSalesTotal = 0
        End Try
        Try
            CHTPurchaseTotal = CDbl(CHTPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            CHTPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(CHTAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(CHTAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(CHTAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(CHTAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        CHTAPTotal = TempAP1 - TempAP2
        CHTARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim DENSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim DENSalesCommand As New SqlCommand(DENSalesStatement, con)
        DENSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP DENVER"
        DENSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        DENSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        DENSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim DENPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim DENPurchasesCommand As New SqlCommand(DENPurchasesStatement, con)
        DENPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP DENVER"
        DENPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        DENPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        DENPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim DENAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim DENAP1Command As New SqlCommand(DENAP1Statement, con)
        DENAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP DENVER"
        DENAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        DENAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim DENAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim DENAP2Command As New SqlCommand(DENAP2Statement, con)
        DENAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP DENVER"
        DENAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        DENAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim DENAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim DENAR1Command As New SqlCommand(DENAR1Statement, con)
        DENAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP DENVER"
        DENAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        DENAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim DENAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim DENAR2Command As New SqlCommand(DENAR2Statement, con)
        DENAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP DENVER"
        DENAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        DENAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DENSalesTotal = CDbl(DENSalesCommand.ExecuteScalar)
        Catch ex As Exception
            DENSalesTotal = 0
        End Try
        Try
            DENPurchaseTotal = CDbl(DENPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            DENPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(DENAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(DENAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(DENAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(DENAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        DENAPTotal = TempAP1 - TempAP2
        DENARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim HOUSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim HOUSalesCommand As New SqlCommand(HOUSalesStatement, con)
        HOUSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP HOUSTON"
        HOUSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        HOUSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        HOUSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim HOUPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim HOUPurchasesCommand As New SqlCommand(HOUPurchasesStatement, con)
        HOUPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP HOUSTON"
        HOUPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        HOUPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        HOUPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim HOUAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim HOUAP1Command As New SqlCommand(HOUAP1Statement, con)
        HOUAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP HOUSTON"
        HOUAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        HOUAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim HOUAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim HOUAP2Command As New SqlCommand(HOUAP2Statement, con)
        HOUAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP HOUSTON"
        HOUAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        HOUAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim HOUAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim HOUAR1Command As New SqlCommand(HOUAR1Statement, con)
        HOUAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP HOUSTON"
        HOUAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        HOUAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim HOUAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim HOUAR2Command As New SqlCommand(HOUAR2Statement, con)
        HOUAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP HOUSTON"
        HOUAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        HOUAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            HOUSalesTotal = CDbl(HOUSalesCommand.ExecuteScalar)
        Catch ex As Exception
            HOUSalesTotal = 0
        End Try
        Try
            HOUPurchaseTotal = CDbl(HOUPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            HOUPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(HOUAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(HOUAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(HOUAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(HOUAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        HOUAPTotal = TempAP1 - TempAP2
        HOUARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim SLCSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim SLCSalesCommand As New SqlCommand(SLCSalesStatement, con)
        SLCSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP UTAH"
        SLCSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        SLCSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        SLCSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim SLCPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim SLCPurchasesCommand As New SqlCommand(SLCPurchasesStatement, con)
        SLCPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP UTAH"
        SLCPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        SLCPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        SLCPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim SLCAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim SLCAP1Command As New SqlCommand(SLCAP1Statement, con)
        SLCAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP UTAH"
        SLCAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        SLCAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim SLCAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim SLCAP2Command As New SqlCommand(SLCAP2Statement, con)
        SLCAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP UTAH"
        SLCAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        SLCAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim SLCAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim SLCAR1Command As New SqlCommand(SLCAR1Statement, con)
        SLCAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP UTAH"
        SLCAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        SLCAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim SLCAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim SLCAR2Command As New SqlCommand(SLCAR2Statement, con)
        SLCAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP UTAH"
        SLCAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        SLCAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SLCSalesTotal = CDbl(SLCSalesCommand.ExecuteScalar)
        Catch ex As Exception
            SLCSalesTotal = 0
        End Try
        Try
            SLCPurchaseTotal = CDbl(SLCPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            SLCPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(SLCAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(SLCAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(SLCAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(SLCAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        SLCAPTotal = TempAP1 - TempAP2
        SLCARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim TFFSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TFFSalesCommand As New SqlCommand(TFFSalesStatement, con)
        TFFSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP VANCOUVER"
        TFFSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFFSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TFFSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFFPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TFFPurchasesCommand As New SqlCommand(TFFPurchasesStatement, con)
        TFFPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP VANCOUVER"
        TFFPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFFPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TFFPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFFAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim TFFAP1Command As New SqlCommand(TFFAP1Statement, con)
        TFFAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP VANCOUVER"
        TFFAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFFAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFFAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim TFFAP2Command As New SqlCommand(TFFAP2Statement, con)
        TFFAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP VANCOUVER"
        TFFAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFFAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFFAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim TFFAR1Command As New SqlCommand(TFFAR1Statement, con)
        TFFAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP VANCOUVER"
        TFFAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFFAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFFAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim TFFAR2Command As New SqlCommand(TFFAR2Statement, con)
        TFFAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP VANCOUVER"
        TFFAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFFAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TFFSalesTotal = CDbl(TFFSalesCommand.ExecuteScalar)
        Catch ex As Exception
            TFFSalesTotal = 0
        End Try
        Try
            TFFPurchaseTotal = CDbl(TFFPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            TFFPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(TFFAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(TFFAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(TFFAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(TFFAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        TFFAPTotal = TempAP1 - TempAP2
        TFFARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim TFPSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TFPSalesCommand As New SqlCommand(TFPSalesStatement, con)
        TFPSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TRUFIT"
        TFPSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFPSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TFPSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFPPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TFPPurchasesCommand As New SqlCommand(TFPPurchasesStatement, con)
        TFPPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TRUFIT"
        TFPPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFPPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TFPPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFPAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim TFPAP1Command As New SqlCommand(TFPAP1Statement, con)
        TFPAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TRUFIT"
        TFPAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFPAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFPAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim TFPAP2Command As New SqlCommand(TFPAP2Statement, con)
        TFPAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TRUFIT"
        TFPAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFPAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFPAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim TFPAR1Command As New SqlCommand(TFPAR1Statement, con)
        TFPAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TRUFIT"
        TFPAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFPAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFPAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim TFPAR2Command As New SqlCommand(TFPAR2Statement, con)
        TFPAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TRUFIT"
        TFPAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFPAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TFPSalesTotal = CDbl(TFPSalesCommand.ExecuteScalar)
        Catch ex As Exception
            TFPSalesTotal = 0
        End Try
        Try
            TFPPurchaseTotal = CDbl(TFPPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            TFPPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(TFPAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(TFPAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(TFPAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(TFPAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        TFPAPTotal = TempAP1 - TempAP2
        TFPARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim TFTSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TFTSalesCommand As New SqlCommand(TFTSalesStatement, con)
        TFTSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP IRVING"
        TFTSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFTSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TFTSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFTPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TFTPurchasesCommand As New SqlCommand(TFTPurchasesStatement, con)
        TFTPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP IRVING"
        TFTPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFTPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TFTPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFTAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim TFTAP1Command As New SqlCommand(TFTAP1Statement, con)
        TFTAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP IRVING"
        TFTAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFTAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFTAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim TFTAP2Command As New SqlCommand(TFTAP2Statement, con)
        TFTAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP IRVING"
        TFTAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFTAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFTAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim TFTAR1Command As New SqlCommand(TFTAR1Statement, con)
        TFTAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP IRVING"
        TFTAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFTAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFTAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim TFTAR2Command As New SqlCommand(TFTAR2Statement, con)
        TFTAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP IRVING"
        TFTAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFTAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TFTSalesTotal = CDbl(TFTSalesCommand.ExecuteScalar)
        Catch ex As Exception
            TFTSalesTotal = 0
        End Try
        Try
            TFTPurchaseTotal = CDbl(TFTPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            TFTPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(TFTAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(TFTAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(TFTAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(TFTAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        TFTAPTotal = TempAP1 - TempAP2
        TFTARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim TORSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TORSalesCommand As New SqlCommand(TORSalesStatement, con)
        TORSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP TORONTO"
        TORSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TORSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TORSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TORPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TORPurchasesCommand As New SqlCommand(TORPurchasesStatement, con)
        TORPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP TORONTO"
        TORPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TORPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TORPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TORAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim TORAP1Command As New SqlCommand(TORAP1Statement, con)
        TORAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP TORONTO"
        TORAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TORAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TORAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim TORAP2Command As New SqlCommand(TORAP2Statement, con)
        TORAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP TORONTO"
        TORAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TORAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TORAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim TORAR1Command As New SqlCommand(TORAR1Statement, con)
        TORAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP TORONTO"
        TORAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TORAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TORAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim TORAR2Command As New SqlCommand(TORAR2Statement, con)
        TORAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP TORONTO"
        TORAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TORAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TORSalesTotal = CDbl(TORSalesCommand.ExecuteScalar)
        Catch ex As Exception
            TORSalesTotal = 0
        End Try
        Try
            TORPurchaseTotal = CDbl(TORPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            TORPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(TORAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(TORAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(TORAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(TORAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        TORAPTotal = TempAP1 - TempAP2
        TORARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim TWDSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TWDSalesCommand As New SqlCommand(TWDSalesStatement, con)
        TWDSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP CORP"
        TWDSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TWDSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TWDSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TWDPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TWDPurchasesCommand As New SqlCommand(TWDPurchasesStatement, con)
        TWDPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP CORP"
        TWDPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TWDPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TWDPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TWDAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim TWDAP1Command As New SqlCommand(TWDAP1Statement, con)
        TWDAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP CORP"
        TWDAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TWDAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TWDAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim TWDAP2Command As New SqlCommand(TWDAP2Statement, con)
        TWDAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP CORP"
        TWDAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TWDAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TWDAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim TWDAR1Command As New SqlCommand(TWDAR1Statement, con)
        TWDAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP CORP"
        TWDAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TWDAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TWDAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim TWDAR2Command As New SqlCommand(TWDAR2Statement, con)
        TWDAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP CORP"
        TWDAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TWDAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TWDSalesTotal = CDbl(TWDSalesCommand.ExecuteScalar)
        Catch ex As Exception
            TWDSalesTotal = 0
        End Try
        Try
            TWDPurchaseTotal = CDbl(TWDPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            TWDPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(TWDAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(TWDAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(TWDAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(TWDAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        TWDAPTotal = TempAP1 - TempAP2
        TWDARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim TWESalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TWESalesCommand As New SqlCommand(TWESalesStatement, con)
        TWESalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TWE"
        TWESalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TWESalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TWESalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TWEPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TWEPurchasesCommand As New SqlCommand(TWEPurchasesStatement, con)
        TWEPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TWE"
        TWEPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TWEPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TWEPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TWEAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim TWEAP1Command As New SqlCommand(TWEAP1Statement, con)
        TWEAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TWE"
        TWEAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TWEAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TWEAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim TWEAP2Command As New SqlCommand(TWEAP2Statement, con)
        TWEAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TWE"
        TWEAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TWEAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TWEAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim TWEAR1Command As New SqlCommand(TWEAR1Statement, con)
        TWEAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TWE"
        TWEAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TWEAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TWEAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim TWEAR2Command As New SqlCommand(TWEAR2Statement, con)
        TWEAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TWE"
        TWEAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TWEAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TWESalesTotal = CDbl(TWESalesCommand.ExecuteScalar)
        Catch ex As Exception
            TWESalesTotal = 0
        End Try
        Try
            TWEPurchaseTotal = CDbl(TWEPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            TWEPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(TWEAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(TWEAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(TWEAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(TWEAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        TWEAPTotal = TempAP1 - TempAP2
        TWEARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0

        '****************************************************************************
        Dim ALBSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim ALBSalesCommand As New SqlCommand(ALBSalesStatement, con)
        ALBSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP ALBERTA"
        ALBSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        ALBSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        ALBSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim ALBPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim ALBPurchasesCommand As New SqlCommand(ALBPurchasesStatement, con)
        ALBPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP ALBERTA"
        ALBPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        ALBPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        ALBPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim ALBAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim ALBAP1Command As New SqlCommand(ALBAP1Statement, con)
        ALBAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP ALBERTA"
        ALBAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        ALBAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim ALBAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim ALBAP2Command As New SqlCommand(ALBAP2Statement, con)
        ALBAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP ALBERTA"
        ALBAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        ALBAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim ALBAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim ALBAR1Command As New SqlCommand(ALBAR1Statement, con)
        ALBAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP ALBERTA"
        ALBAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        ALBAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim ALBAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim ALBAR2Command As New SqlCommand(ALBAR2Statement, con)
        ALBAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP ALBERTA"
        ALBAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        ALBAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ALBSalesTotal = CDbl(ALBSalesCommand.ExecuteScalar)
        Catch ex As Exception
            ALBSalesTotal = 0
        End Try
        Try
            ALBPurchaseTotal = CDbl(ALBPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            ALBPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(ALBAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(ALBAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(ALBAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(ALBAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        ALBAPTotal = TempAP1 - TempAP2
        ALBARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
        Dim TFJSalesStatement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TFJSalesCommand As New SqlCommand(TFJSalesStatement, con)
        TFJSalesCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP NEW JERSEY"
        TFJSalesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFJSalesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TFJSalesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFJPurchasesStatement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Dim TFJPurchasesCommand As New SqlCommand(TFJPurchasesStatement, con)
        TFJPurchasesCommand.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP NEW JERSEY"
        TFJPurchasesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFJPurchasesCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TFJPurchasesCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFJAP1Statement As String = "SELECT SUM(InvoiceTotal) FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND InvoiceDate <= @EndDate"
        Dim TFJAP1Command As New SqlCommand(TFJAP1Statement, con)
        TFJAP1Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP NEW JERSEY"
        TFJAP1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFJAP1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFJAP2Statement As String = "SELECT SUM(InvoiceTotal) FROM APVoucherTable WHERE DivisionID = @DivisionID AND VendorID = @VendorID AND PaidDate <= @EndDate"
        Dim TFJAP2Command As New SqlCommand(TFJAP2Statement, con)
        TFJAP2Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = "TFP NEW JERSEY"
        TFJAP2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFJAP2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFJAR1Statement As String = "SELECT SUM(InvoiceTotal) FROM InvoiceHeaderTable WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND InvoiceDate <= @EndDate"
        Dim TFJAR1Command As New SqlCommand(TFJAR1Statement, con)
        TFJAR1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP NEW JERSEY"
        TFJAR1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFJAR1Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        Dim TFJAR2Statement As String = "SELECT SUM(PaymentAmount) FROM ARCustomerPayment WHERE DivisionID = @DivisionID AND CustomerID = @CustomerID AND PaymentDate <= @EndDate"
        Dim TFJAR2Command As New SqlCommand(TFJAR2Statement, con)
        TFJAR2Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "TFP NEW JERSEY"
        TFJAR2Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)
        TFJAR2Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TFJSalesTotal = CDbl(TFJSalesCommand.ExecuteScalar)
        Catch ex As Exception
            TFJSalesTotal = 0
        End Try
        Try
            TFJPurchaseTotal = CDbl(TFJPurchasesCommand.ExecuteScalar)
        Catch ex As Exception
            TFJPurchaseTotal = 0
        End Try
        Try
            TempAR1 = CDbl(TFJAR1Command.ExecuteScalar)
        Catch ex As Exception
            TempAR1 = 0
        End Try
        Try
            TempAR2 = CDbl(TFJAR2Command.ExecuteScalar)
        Catch ex As Exception
            TempAR2 = 0
        End Try
        Try
            TempAP1 = CDbl(TFJAP1Command.ExecuteScalar)
        Catch ex As Exception
            TempAP1 = 0
        End Try
        Try
            TempAP2 = CDbl(TFJAP2Command.ExecuteScalar)
        Catch ex As Exception
            TempAP2 = 0
        End Try
        con.Close()

        TFJAPTotal = TempAP1 - TempAP2
        TFJARTotal = TempAR1 - TempAR2

        TempAP1 = 0
        TempAP2 = 0
        TempAR1 = 0
        TempAR2 = 0
        '****************************************************************************
    End Sub

    Public Sub ClearData()
        dtpBeginDate.Text = ""
        dtpBeginDate.Text = ""

        chkAllDivisions.Checked = True
    End Sub

    Public Sub ClearVariables()

    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvIntercompany.RowCount = 0
    End Sub

    Private Sub cmdFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFilter.Click
        'Make sure datagrid is empty
        Me.dgvIntercompany.DataSource = Nothing

        DivisionCounter = 1
        FillDivisionArray()

        'Start Loop to fill data
        For i As Integer = 1 To 15
            'Get Data from database
            LoadDataForAllDivisions()

            'Add line to datagrid
            Me.dgvIntercompany.Rows.Add(DivisionIndex(DivisionCounter), ATLSalesTotal, ATLARTotal, ATLPurchaseTotal, ATLAPTotal, CBSSalesTotal, CBSARTotal, CBSPurchaseTotal, CBSAPTotal, CGOSalesTotal, CGOARTotal, CGOPurchaseTotal, CGOAPTotal, CHTSalesTotal, CHTARTotal, CHTPurchaseTotal, CHTAPTotal, DENSalesTotal, DENARTotal, DENPurchaseTotal, DENAPTotal, HOUSalesTotal, HOUARTotal, HOUPurchaseTotal, HOUAPTotal, SLCSalesTotal, SLCARTotal, SLCPurchaseTotal, SLCAPTotal, TFFSalesTotal, TFFARTotal, TFFPurchaseTotal, TFFAPTotal, TFPSalesTotal, TFPPurchaseTotal, TFPAPTotal, TFPARTotal, TFTSalesTotal, TFTARTotal, TFTPurchaseTotal, TFTAPTotal, TORSalesTotal, TORARTotal, TORPurchaseTotal, TORAPTotal, TWDSalesTotal, TWDARTotal, TWDPurchaseTotal, TWDAPTotal, TWESalesTotal, TWEARTotal, TWEPurchaseTotal, TWEAPTotal, ALBSalesTotal, ALBARTotal, ALBPurchaseTotal, ALBAPTotal, TFJSalesTotal, TFJARTotal, TFJPurchaseTotal, TFJAPTotal)

            'Clear Data
            ATLSalesTotal = 0
            ATLPurchaseTotal = 0
            ATLARTotal = 0
            ATLAPTotal = 0

            CBSSalesTotal = 0
            CBSPurchaseTotal = 0
            CBSARTotal = 0
            CBSAPTotal = 0

            CGOSalesTotal = 0
            CGOPurchaseTotal = 0
            CGOARTotal = 0
            CGOAPTotal = 0

            CHTSalesTotal = 0
            CHTPurchaseTotal = 0
            CHTARTotal = 0
            CHTAPTotal = 0

            DENSalesTotal = 0
            DENPurchaseTotal = 0
            DENARTotal = 0
            DENAPTotal = 0

            HOUSalesTotal = 0
            HOUPurchaseTotal = 0
            HOUARTotal = 0
            HOUAPTotal = 0

            SLCSalesTotal = 0
            SLCPurchaseTotal = 0
            SLCARTotal = 0
            SLCAPTotal = 0

            TFFSalesTotal = 0
            TFFPurchaseTotal = 0
            TFFARTotal = 0
            TFFAPTotal = 0

            TFPSalesTotal = 0
            TFPPurchaseTotal = 0
            TFPARTotal = 0
            TFPAPTotal = 0

            TFTSalesTotal = 0
            TFTPurchaseTotal = 0
            TFTARTotal = 0
            TFTAPTotal = 0

            TORSalesTotal = 0
            TORPurchaseTotal = 0
            TORARTotal = 0
            TORAPTotal = 0

            TWDSalesTotal = 0
            TWDPurchaseTotal = 0
            TWDARTotal = 0
            TWDAPTotal = 0

            TWESalesTotal = 0
            TWEPurchaseTotal = 0
            TWEARTotal = 0
            TWEAPTotal = 0

            ALBSalesTotal = 0
            ALBPurchaseTotal = 0
            ALBARTotal = 0
            ALBAPTotal = 0

            TFJSalesTotal = 0
            TFJPurchaseTotal = 0
            TFJARTotal = 0
            TFJAPTotal = 0

            'Advance counter
            DivisionCounter = DivisionCounter + 1
        Next i
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExportIntoExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportIntoExcel.Click
        Dim ExcelObject As New Excel.Application
        Dim NewWB As Excel.Workbook

        Dim ExcelFileName As String = ""

        Dim LineDivision As String = ""
        Dim LineATLSales As Double = 0
        Dim LineATLAR As Double = 0
        Dim LineATLAP As Double = 0
        Dim LineATLPurchases As Double = 0
        Dim LineCBSSales As Double = 0
        Dim LineCBSAR As Double = 0
        Dim LineCBSAP As Double = 0
        Dim LineCBSPurchases As Double = 0
        Dim LineCGOSales As Double = 0
        Dim LineCGOAR As Double = 0
        Dim LineCGOAP As Double = 0
        Dim LineCGOPurchases As Double = 0
        Dim LineCHTSales As Double = 0
        Dim LineCHTAR As Double = 0
        Dim LineCHTAP As Double = 0
        Dim LineCHTPurchases As Double = 0
        Dim LineDENSales As Double = 0
        Dim LineDENAR As Double = 0
        Dim LineDENAP As Double = 0
        Dim LineDENPurchases As Double = 0
        Dim LineHOUSales As Double = 0
        Dim LineHOUAR As Double = 0
        Dim LineHOUAP As Double = 0
        Dim LineHOUPurchases As Double = 0
        Dim LineSLCSales As Double = 0
        Dim LineSLCAR As Double = 0
        Dim LineSLCAP As Double = 0
        Dim LineSLCPurchases As Double = 0
        Dim LineTFFSales As Double = 0
        Dim LineTFFAR As Double = 0
        Dim LineTFFAP As Double = 0
        Dim LineTFFPurchases As Double = 0
        Dim LineTFPSales As Double = 0
        Dim LineTFPAR As Double = 0
        Dim LineTFPAP As Double = 0
        Dim LineTFPPurchases As Double = 0
        Dim LineTFTSales As Double = 0
        Dim LineTFTAR As Double = 0
        Dim LineTFTAP As Double = 0
        Dim LineTFTPurchases As Double = 0
        Dim LineTORSales As Double = 0
        Dim LineTORAR As Double = 0
        Dim LineTORAP As Double = 0
        Dim LineTORPurchases As Double = 0
        Dim LineTWDSales As Double = 0
        Dim LineTWDAR As Double = 0
        Dim LineTWDAP As Double = 0
        Dim LineTWDPurchases As Double = 0
        Dim LineTWESales As Double = 0
        Dim LineTWEAR As Double = 0
        Dim LineTWEAP As Double = 0
        Dim LineTWEPurchases As Double = 0
        Dim LineALBSales As Double = 0
        Dim LineALBAR As Double = 0
        Dim LineALBAP As Double = 0
        Dim LineALBPurchases As Double = 0
        Dim LineTFJSales As Double = 0
        Dim LineTFJAR As Double = 0
        Dim LineTFJAP As Double = 0
        Dim LineTFJPurchases As Double = 0

        'Create Excel Sheet with Headers
        NewWB = ExcelObject.Workbooks.Add()

        ExcelObject.Range("A1").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B1").Select()
        ExcelObject.ActiveCell.Value = "ATL Sales"
        ExcelObject.Range("C1").Select()
        ExcelObject.ActiveCell.Value = "ATL A/R Balance"
        ExcelObject.Range("D1").Select()
        ExcelObject.ActiveCell.Value = "ATL Purchases"
        ExcelObject.Range("E1").Select()
        ExcelObject.ActiveCell.Value = "ATL A/P Balance"
        'ExcelObject.Range("F1").Select()
        'ExcelObject.ActiveCell.Value = "Division Name"
        'ExcelObject.Range("G1").Select()
        'ExcelObject.ActiveCell.Value = "Account #"

        'Format the table
        ExcelObject.Range("A1:E1").Font.Size = 12
        ExcelObject.Range("A1:E1").Font.Bold = True
        ExcelObject.Range("A1:E1").RowHeight = 20

        ExcelObject.Range("A1").ColumnWidth = 15
        ExcelObject.Range("B1").ColumnWidth = 15
        ExcelObject.Range("C1").ColumnWidth = 20
        ExcelObject.Range("D1").ColumnWidth = 20
        ExcelObject.Range("E1").ColumnWidth = 15
        'ExcelObject.Range("F1").ColumnWidth = 30
        'ExcelObject.Range("G1").ColumnWidth = 20

        Dim RowCounter As Integer = 1
        Dim strRow As String = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineATLSales = LineRow.Cells("ATLSales").Value
            Catch ex As System.Exception
                LineATLSales = 0
            End Try
            Try
                LineATLAR = LineRow.Cells("ATLAR").Value
            Catch ex As System.Exception
                LineATLAR = 0
            End Try
            Try
                LineATLPurchases = LineRow.Cells("ATLPurchases").Value
            Catch ex As System.Exception
                LineATLPurchases = 0
            End Try
            Try
                LineATLAP = LineRow.Cells("ATLAP").Value
            Catch ex As System.Exception
                LineATLAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineATLSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineATLAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineATLPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineATLAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A17").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B17").Select()
        ExcelObject.ActiveCell.Value = "CBS Sales"
        ExcelObject.Range("C17").Select()
        ExcelObject.ActiveCell.Value = "CBS A/R Balance"
        ExcelObject.Range("D17").Select()
        ExcelObject.ActiveCell.Value = "CBS Purchases"
        ExcelObject.Range("E17").Select()
        ExcelObject.ActiveCell.Value = "CBS A/P Balance"

        'Format the table
        ExcelObject.Range("A17:E17").Font.Size = 12
        ExcelObject.Range("A17:E17").Font.Bold = True
        ExcelObject.Range("A17:E17").RowHeight = 20

        RowCounter = 17
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineCBSSales = LineRow.Cells("CBSSales").Value
            Catch ex As System.Exception
                LineCBSSales = 0
            End Try
            Try
                LineCBSAR = LineRow.Cells("CBSAR").Value
            Catch ex As System.Exception
                LineCBSAR = 0
            End Try
            Try
                LineCBSPurchases = LineRow.Cells("CBSPurchases").Value
            Catch ex As System.Exception
                LineCBSPurchases = 0
            End Try
            Try
                LineCBSAP = LineRow.Cells("CBSAP").Value
            Catch ex As System.Exception
                LineCBSAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineCBSSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineCBSAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineCBSPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineCBSAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A33").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B33").Select()
        ExcelObject.ActiveCell.Value = "CGO Sales"
        ExcelObject.Range("C33").Select()
        ExcelObject.ActiveCell.Value = "CGO A/R Balance"
        ExcelObject.Range("D33").Select()
        ExcelObject.ActiveCell.Value = "CGO Purchases"
        ExcelObject.Range("E33").Select()
        ExcelObject.ActiveCell.Value = "CGO A/P Balance"

        'Format the table
        ExcelObject.Range("A33:E33").Font.Size = 12
        ExcelObject.Range("A33:E33").Font.Bold = True
        ExcelObject.Range("A33:E33").RowHeight = 20

        RowCounter = 33
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineCGOSales = LineRow.Cells("CGOSales").Value
            Catch ex As System.Exception
                LineCGOSales = 0
            End Try
            Try
                LineCGOAR = LineRow.Cells("CGOAR").Value
            Catch ex As System.Exception
                LineCGOAR = 0
            End Try
            Try
                LineCGOPurchases = LineRow.Cells("CGOPurchases").Value
            Catch ex As System.Exception
                LineCGOPurchases = 0
            End Try
            Try
                LineCGOAP = LineRow.Cells("CGOAP").Value
            Catch ex As System.Exception
                LineCGOAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineCGOSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineCGOAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineCGOPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineCGOAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A49").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B49").Select()
        ExcelObject.ActiveCell.Value = "CHT Sales"
        ExcelObject.Range("C49").Select()
        ExcelObject.ActiveCell.Value = "CHT A/R Balance"
        ExcelObject.Range("D49").Select()
        ExcelObject.ActiveCell.Value = "CHT Purchases"
        ExcelObject.Range("E49").Select()
        ExcelObject.ActiveCell.Value = "CHT A/P Balance"

        'Format the table
        ExcelObject.Range("A49:E49").Font.Size = 12
        ExcelObject.Range("A49:E49").Font.Bold = True
        ExcelObject.Range("A49:E49").RowHeight = 20

        RowCounter = 49
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineCHTSales = LineRow.Cells("CHTSales").Value
            Catch ex As System.Exception
                LineCHTSales = 0
            End Try
            Try
                LineCHTAR = LineRow.Cells("CHTAR").Value
            Catch ex As System.Exception
                LineCHTAR = 0
            End Try
            Try
                LineCHTPurchases = LineRow.Cells("CHTPurchases").Value
            Catch ex As System.Exception
                LineCHTPurchases = 0
            End Try
            Try
                LineCHTAP = LineRow.Cells("CHTAP").Value
            Catch ex As System.Exception
                LineCHTAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineCHTSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineCHTAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineCHTPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineCHTAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A65").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B65").Select()
        ExcelObject.ActiveCell.Value = "DEN Sales"
        ExcelObject.Range("C65").Select()
        ExcelObject.ActiveCell.Value = "DEN A/R Balance"
        ExcelObject.Range("D65").Select()
        ExcelObject.ActiveCell.Value = "DEN Purchases"
        ExcelObject.Range("E65").Select()
        ExcelObject.ActiveCell.Value = "DEN A/P Balance"

        'Format the table
        ExcelObject.Range("A65:E65").Font.Size = 12
        ExcelObject.Range("A65:E65").Font.Bold = True
        ExcelObject.Range("A65:E65").RowHeight = 20

        RowCounter = 65
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineDENSales = LineRow.Cells("DENSales").Value
            Catch ex As System.Exception
                LineDENSales = 0
            End Try
            Try
                LineDENAR = LineRow.Cells("DENAR").Value
            Catch ex As System.Exception
                LineDENAR = 0
            End Try
            Try
                LineDENPurchases = LineRow.Cells("DENPurchases").Value
            Catch ex As System.Exception
                LineDENPurchases = 0
            End Try
            Try
                LineDENAP = LineRow.Cells("DENAP").Value
            Catch ex As System.Exception
                LineDENAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDENSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDENAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDENPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDENAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A81").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B81").Select()
        ExcelObject.ActiveCell.Value = "HOU Sales"
        ExcelObject.Range("C81").Select()
        ExcelObject.ActiveCell.Value = "HOU A/R Balance"
        ExcelObject.Range("D81").Select()
        ExcelObject.ActiveCell.Value = "HOU Purchases"
        ExcelObject.Range("E81").Select()
        ExcelObject.ActiveCell.Value = "HOU A/P Balance"

        'Format the table
        ExcelObject.Range("A81:E81").Font.Size = 12
        ExcelObject.Range("A81:E81").Font.Bold = True
        ExcelObject.Range("A81:E81").RowHeight = 20

        RowCounter = 81
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineHOUSales = LineRow.Cells("HOUSales").Value
            Catch ex As System.Exception
                LineHOUSales = 0
            End Try
            Try
                LineHOUAR = LineRow.Cells("HOUAR").Value
            Catch ex As System.Exception
                LineHOUAR = 0
            End Try
            Try
                LineHOUPurchases = LineRow.Cells("HOUPurchases").Value
            Catch ex As System.Exception
                LineHOUPurchases = 0
            End Try
            Try
                LineHOUAP = LineRow.Cells("HOUAP").Value
            Catch ex As System.Exception
                LineHOUAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineHOUSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineHOUAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineHOUPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineHOUAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A97").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B97").Select()
        ExcelObject.ActiveCell.Value = "SLC Sales"
        ExcelObject.Range("C97").Select()
        ExcelObject.ActiveCell.Value = "SLC A/R Balance"
        ExcelObject.Range("D97").Select()
        ExcelObject.ActiveCell.Value = "SLC Purchases"
        ExcelObject.Range("E97").Select()
        ExcelObject.ActiveCell.Value = "SLC A/P Balance"

        'Format the table
        ExcelObject.Range("A97:E97").Font.Size = 12
        ExcelObject.Range("A97:E97").Font.Bold = True
        ExcelObject.Range("A97:E97").RowHeight = 20

        RowCounter = 97
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineSLCSales = LineRow.Cells("SLCSales").Value
            Catch ex As System.Exception
                LineSLCSales = 0
            End Try
            Try
                LineSLCAR = LineRow.Cells("SLCAR").Value
            Catch ex As System.Exception
                LineSLCAR = 0
            End Try
            Try
                LineSLCPurchases = LineRow.Cells("SLCPurchases").Value
            Catch ex As System.Exception
                LineSLCPurchases = 0
            End Try
            Try
                LineSLCAP = LineRow.Cells("SLCAP").Value
            Catch ex As System.Exception
                LineSLCAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineSLCSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineSLCAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineSLCPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineSLCAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A113").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B113").Select()
        ExcelObject.ActiveCell.Value = "TFF Sales"
        ExcelObject.Range("C113").Select()
        ExcelObject.ActiveCell.Value = "TFF A/R Balance"
        ExcelObject.Range("D113").Select()
        ExcelObject.ActiveCell.Value = "TFF Purchases"
        ExcelObject.Range("E113").Select()
        ExcelObject.ActiveCell.Value = "TFF A/P Balance"

        'Format the table
        ExcelObject.Range("A113:E113").Font.Size = 12
        ExcelObject.Range("A113:E113").Font.Bold = True
        ExcelObject.Range("A113:E113").RowHeight = 20

        RowCounter = 113
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineTFFSales = LineRow.Cells("TFFSales").Value
            Catch ex As System.Exception
                LineTFFSales = 0
            End Try
            Try
                LineTFFAR = LineRow.Cells("TFFAR").Value
            Catch ex As System.Exception
                LineTFFAR = 0
            End Try
            Try
                LineTFFPurchases = LineRow.Cells("TFFPurchases").Value
            Catch ex As System.Exception
                LineTFFPurchases = 0
            End Try
            Try
                LineTFFAP = LineRow.Cells("TFFAP").Value
            Catch ex As System.Exception
                LineTFFAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFFSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFFAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFFPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFFAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A129").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B129").Select()
        ExcelObject.ActiveCell.Value = "TFP Sales"
        ExcelObject.Range("C129").Select()
        ExcelObject.ActiveCell.Value = "TFP A/R Balance"
        ExcelObject.Range("D129").Select()
        ExcelObject.ActiveCell.Value = "TFP Purchases"
        ExcelObject.Range("E129").Select()
        ExcelObject.ActiveCell.Value = "TFP A/P Balance"

        'Format the table
        ExcelObject.Range("A129:E129").Font.Size = 12
        ExcelObject.Range("A129:E129").Font.Bold = True
        ExcelObject.Range("A129:E129").RowHeight = 20

        RowCounter = 129
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineTFPSales = LineRow.Cells("TFPSales").Value
            Catch ex As System.Exception
                LineTFPSales = 0
            End Try
            Try
                LineTFPAR = LineRow.Cells("TFPAR").Value
            Catch ex As System.Exception
                LineTFPAR = 0
            End Try
            Try
                LineTFPPurchases = LineRow.Cells("TFPPurchases").Value
            Catch ex As System.Exception
                LineTFPPurchases = 0
            End Try
            Try
                LineTFPAP = LineRow.Cells("TFPAP").Value
            Catch ex As System.Exception
                LineTFPAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFPSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFPAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFPPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFPAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A145").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B145").Select()
        ExcelObject.ActiveCell.Value = "TFT Sales"
        ExcelObject.Range("C145").Select()
        ExcelObject.ActiveCell.Value = "TFT A/R Balance"
        ExcelObject.Range("D145").Select()
        ExcelObject.ActiveCell.Value = "TFT Purchases"
        ExcelObject.Range("E145").Select()
        ExcelObject.ActiveCell.Value = "TFT A/P Balance"

        'Format the table
        ExcelObject.Range("A145:E145").Font.Size = 12
        ExcelObject.Range("A145:E145").Font.Bold = True
        ExcelObject.Range("A145:E145").RowHeight = 20

        RowCounter = 145
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineTFTSales = LineRow.Cells("TFTSales").Value
            Catch ex As System.Exception
                LineTFTSales = 0
            End Try
            Try
                LineTFTAR = LineRow.Cells("TFTAR").Value
            Catch ex As System.Exception
                LineTFTAR = 0
            End Try
            Try
                LineTFTPurchases = LineRow.Cells("TFTPurchases").Value
            Catch ex As System.Exception
                LineTFTPurchases = 0
            End Try
            Try
                LineTFTAP = LineRow.Cells("TFTAP").Value
            Catch ex As System.Exception
                LineTFTAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFTSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFTAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFTPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFTAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A161").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B161").Select()
        ExcelObject.ActiveCell.Value = "TOR Sales"
        ExcelObject.Range("C161").Select()
        ExcelObject.ActiveCell.Value = "TOR A/R Balance"
        ExcelObject.Range("D161").Select()
        ExcelObject.ActiveCell.Value = "TOR Purchases"
        ExcelObject.Range("E161").Select()
        ExcelObject.ActiveCell.Value = "TOR A/P Balance"

        'Format the table
        ExcelObject.Range("A161:E161").Font.Size = 12
        ExcelObject.Range("A161:E161").Font.Bold = True
        ExcelObject.Range("A161:E161").RowHeight = 20

        RowCounter = 161
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineTORSales = LineRow.Cells("TORSales").Value
            Catch ex As System.Exception
                LineTORSales = 0
            End Try
            Try
                LineTORAR = LineRow.Cells("TORAR").Value
            Catch ex As System.Exception
                LineTORAR = 0
            End Try
            Try
                LineTORPurchases = LineRow.Cells("TORPurchases").Value
            Catch ex As System.Exception
                LineTORPurchases = 0
            End Try
            Try
                LineTORAP = LineRow.Cells("TORAP").Value
            Catch ex As System.Exception
                LineTORAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTORSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTORAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTORPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTORAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A177").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B177").Select()
        ExcelObject.ActiveCell.Value = "TWD Sales"
        ExcelObject.Range("C177").Select()
        ExcelObject.ActiveCell.Value = "TWD A/R Balance"
        ExcelObject.Range("D177").Select()
        ExcelObject.ActiveCell.Value = "TWD Purchases"
        ExcelObject.Range("E177").Select()
        ExcelObject.ActiveCell.Value = "TWD A/P Balance"

        'Format the table
        ExcelObject.Range("A177:E177").Font.Size = 12
        ExcelObject.Range("A177:E177").Font.Bold = True
        ExcelObject.Range("A177:E177").RowHeight = 20

        RowCounter = 177
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineTWDSales = LineRow.Cells("TWDSales").Value
            Catch ex As System.Exception
                LineTWDSales = 0
            End Try
            Try
                LineTWDAR = LineRow.Cells("TWDAR").Value
            Catch ex As System.Exception
                LineTWDAR = 0
            End Try
            Try
                LineTWDPurchases = LineRow.Cells("TWDPurchases").Value
            Catch ex As System.Exception
                LineTWDPurchases = 0
            End Try
            Try
                LineTWDAP = LineRow.Cells("TWDAP").Value
            Catch ex As System.Exception
                LineTWDAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTWDSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTWDAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTWDPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTWDAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A193").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B193").Select()
        ExcelObject.ActiveCell.Value = "TWE Sales"
        ExcelObject.Range("C193").Select()
        ExcelObject.ActiveCell.Value = "TWE A/R Balance"
        ExcelObject.Range("D193").Select()
        ExcelObject.ActiveCell.Value = "TWE Purchases"
        ExcelObject.Range("E193").Select()
        ExcelObject.ActiveCell.Value = "TWE A/P Balance"

        'Format the table
        ExcelObject.Range("A193:E193").Font.Size = 12
        ExcelObject.Range("A193:E193").Font.Bold = True
        ExcelObject.Range("A193:E193").RowHeight = 20

        RowCounter = 193
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineTWESales = LineRow.Cells("TWESales").Value
            Catch ex As System.Exception
                LineTWESales = 0
            End Try
            Try
                LineTWEAR = LineRow.Cells("TWEAR").Value
            Catch ex As System.Exception
                LineTWEAR = 0
            End Try
            Try
                LineTWEPurchases = LineRow.Cells("TWEPurchases").Value
            Catch ex As System.Exception
                LineTWEPurchases = 0
            End Try
            Try
                LineTWEAP = LineRow.Cells("TWEAP").Value
            Catch ex As System.Exception
                LineTWEAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTWESales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTWEAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTWEPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTWEAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A209").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B209").Select()
        ExcelObject.ActiveCell.Value = "ALB Sales"
        ExcelObject.Range("C209").Select()
        ExcelObject.ActiveCell.Value = "ALB A/R Balance"
        ExcelObject.Range("D209").Select()
        ExcelObject.ActiveCell.Value = "ALB Purchases"
        ExcelObject.Range("E209").Select()
        ExcelObject.ActiveCell.Value = "ALB A/P Balance"

        'Format the table
        ExcelObject.Range("A209:E209").Font.Size = 12
        ExcelObject.Range("A209:E209").Font.Bold = True
        ExcelObject.Range("A209:E209").RowHeight = 20

        RowCounter = 209
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineALBSales = LineRow.Cells("ALBSales").Value
            Catch ex As System.Exception
                LineALBSales = 0
            End Try
            Try
                LineALBAR = LineRow.Cells("ALBAR").Value
            Catch ex As System.Exception
                LineALBAR = 0
            End Try
            Try
                LineALBPurchases = LineRow.Cells("ALBPurchases").Value
            Catch ex As System.Exception
                LineALBPurchases = 0
            End Try
            Try
                LineALBAP = LineRow.Cells("ALBAP").Value
            Catch ex As System.Exception
                LineALBAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineALBSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineALBAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineALBPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineALBAP
        Next
        '**************************************************************************************
        ExcelObject.Range("A225").Select()
        ExcelObject.ActiveCell.Value = "Division"
        ExcelObject.Range("B225").Select()
        ExcelObject.ActiveCell.Value = "TFJ Sales"
        ExcelObject.Range("C225").Select()
        ExcelObject.ActiveCell.Value = "TFJ A/R Balance"
        ExcelObject.Range("D225").Select()
        ExcelObject.ActiveCell.Value = "TFJ Purchases"
        ExcelObject.Range("E225").Select()
        ExcelObject.ActiveCell.Value = "TFJ A/P Balance"

        'Format the table
        ExcelObject.Range("A225:E225").Font.Size = 12
        ExcelObject.Range("A225:E225").Font.Bold = True
        ExcelObject.Range("A225:E225").RowHeight = 20

        RowCounter = 225
        strRow = ""

        For Each LineRow As DataGridViewRow In dgvIntercompany.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                LineDivision = LineRow.Cells("DivisionColumn").Value
            Catch ex As System.Exception
                LineDivision = ""
            End Try
            Try
                LineTFJSales = LineRow.Cells("TFJSales").Value
            Catch ex As System.Exception
                LineTFJSales = 0
            End Try
            Try
                LineTFJAR = LineRow.Cells("TFJAR").Value
            Catch ex As System.Exception
                LineTFJAR = 0
            End Try
            Try
                LineTFJPurchases = LineRow.Cells("TFJPurchases").Value
            Catch ex As System.Exception
                LineTFJPurchases = 0
            End Try
            Try
                LineTFJAP = LineRow.Cells("TFJAP").Value
            Catch ex As System.Exception
                LineTFJAP = 0
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineDivision

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFJSales

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFJAR

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFJPurchases

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = LineTFJAP
        Next
        '**************************************************************************************

        'Create new filename and save file
        Dim TodaysDate As Date = Now()
        Dim strDay, strMonth, strYear, strMinute As String
        Dim intDay, intMonth, intYear, intMinute As Integer

        intDay = TodaysDate.Day
        intMonth = TodaysDate.Month
        intYear = TodaysDate.Year
        intMinute = TodaysDate.Minute

        strDay = CStr(intDay)
        strMonth = CStr(intMonth)
        strYear = CStr(intYear)
        strMinute = CStr(intMinute)

        If intDay < 10 Then
            strDay = "0" + strDay
        Else
            'Do nothing
        End If
        If intMonth < 10 Then
            strMonth = "0" + strMonth
        Else
            'Do nothing
        End If

        Dim Filename As String = ""

        Filename = "Intercompany(" + strMonth + strDay + strYear + strMinute + ").xls"
        ExcelFileName = Filename

        NewWB.SaveAs("\\TFP-FS\TransferData\TruweldAudits\" + Filename)

        ExcelObject.Visible = True

    End Sub
End Class