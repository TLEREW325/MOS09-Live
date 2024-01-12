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
Imports System.Drawing.Printing
Public Class CashSheet
    Inherits System.Windows.Forms.Form

    Dim BankDate As Date
    Dim BeginDate, EndDate As String

    'Variables for Bank Transaction Page
    Dim ATLAP, ATLAR, ATLBT, ATLGJ, ATLBTGJ, ATLTotal As Double
    Dim CBSAP, CBSAR, CBSBT, CBSGJ, CBSBTGJ, CBSTotal As Double
    Dim CHTAP, CHTAR, CHTBT, CHTGJ, CHTBTGJ, CHTTotal As Double
    Dim CGOAP, CGOAR, CGOBT, CGOGJ, CGOBTGJ, CGOTotal As Double
    Dim HOUAP, HOUAR, HOUBT, HOUGJ, HOUBTGJ, HOUTotal As Double
    Dim DENAP, DENAR, DENBT, DENGJ, DENBTGJ, DENTotal As Double
    Dim TFTAP, TFTAR, TFTBT, TFTGJ, TFTBTGJ, TFTTotal As Double
    Dim TFFAP, TFFAR, TFFBT, TFFGJ, TFFBTGJ, TFFTotal As Double
    Dim TWEAP, TWEAR, TWEBT, TWEGJ, TWEBTGJ, TWETotal As Double
    Dim SLCAP, SLCAR, SLCBT, SLCGJ, SLCBTGJ, SLCTotal As Double
    Dim TWDAP, TWDAR, TWDBT, TWDGJ, TWDBTGJ, TWDTotal As Double
    Dim TORAP, TORAR, TORBT, TORGJ, TORBTGJ, TORTotal As Double
    Dim ALBAP, ALBAR, ALBBT, ALBGJ, ALBBTGJ, ALBTotal As Double
    Dim TotalAP, TotalAR, TotalBT, TotalGJ, TotalBTGJ, GrandTotal As Double

    'Variables for Totals Page
    Dim TotalBeginningBalance, TotalEndingBalance As Double
    Dim CRUSBeginningBalance, CRUSDebits, CRUSCredits, CRUSNetChange, CRUSEndingBalance As Double
    Dim CKUSBeginningBalance, CKUSDebits, CKUSCredits, CKUSNetChange, CKUSEndingBalance As Double
    Dim PRBeginningBalance, PRDebits, PRCredits, PRNetChange, PREndingBalance As Double
    Dim CRCANBeginningBalance, CRCANDebits, CRCANCredits, CRCANNetChange, CRCANEndingBalance As Double
    Dim CKCANBeginningBalance, CKCANDebits, CKCANCredits, CKCANNetChange, CKCANEndingBalance As Double
    Dim BBCRUSDebits, BBCKUSDebits, BBPRDebits, BBCRCANDebits, BBCKCANDebits, BBMMDebits, BBIADebits, BBCRUSCredits, BBCKUSCredits, BBPRCredits, BBCRCANCredits, BBCKCANCredits, BBMMCredits, BBIACredits As Double
    Dim MMBeginningBalance, MMDebits, MMCredits, MMNetChange, MMEndingBalance As Double
    Dim IABeginningBalance, IADebits, IACredits, IANetChange, IAEndingBalance As Double

    Dim NetCashPosition, DebitPayables, CreditPayables, CurrentPayables As Double

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim con1 As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")

    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9 As DataSet
    Dim dt As DataTable

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CashSheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearData()
        ClearVariables()

        DefineMonth()
        'LoadDebitSummaryTotals()
        'LoadCreditSummaryTotals()
        'CalculateNetChange()
        'LoadBeginningSummaryTotals()
        'CalculateEndingBalance()
        'LoadCurrentPayablesAndNetCash()
        LoadDailyTotals()
    End Sub

    Public Sub ClearVariables()
        BeginDate = ""
        EndDate = ""
        ATLAP = 0
        ATLAR = 0
        ATLBT = 0
        ATLGJ = 0
        ATLTotal = 0
        CBSAP = 0
        CBSAR = 0
        CBSBT = 0
        CBSGJ = 0
        CBSBTGJ = 0
        CBSTotal = 0
        CHTAP = 0
        CHTAR = 0
        CHTBT = 0
        CHTGJ = 0
        CHTBTGJ = 0
        CHTTotal = 0
        CGOAP = 0
        CGOAR = 0
        CGOBT = 0
        CGOGJ = 0
        CGOBTGJ = 0
        CGOTotal = 0
        HOUAP = 0
        HOUAR = 0
        HOUBT = 0
        HOUGJ = 0
        HOUBTGJ = 0
        HOUTotal = 0
        DENAP = 0
        DENAR = 0
        DENBT = 0
        DENGJ = 0
        DENBTGJ = 0
        DENTotal = 0
        TFTAP = 0
        TFTAR = 0
        TFTBT = 0
        TFTGJ = 0
        TFTBTGJ = 0
        TFTTotal = 0
        TFFAP = 0
        TFFAR = 0
        TFFBT = 0
        TFFGJ = 0
        TFFBTGJ = 0
        TFFTotal = 0
        TWEAP = 0
        TWEAR = 0
        TWEBT = 0
        TWEGJ = 0
        TWEBTGJ = 0
        TWETotal = 0
        SLCAP = 0
        SLCAR = 0
        SLCBT = 0
        SLCGJ = 0
        SLCTotal = 0
        TWDAP = 0
        TWDAR = 0
        TWDBT = 0
        TWDGJ = 0
        TWDBTGJ = 0
        TWDTotal = 0
        TORAP = 0
        TORAR = 0
        TORBT = 0
        TORGJ = 0
        TORBTGJ = 0
        TORTotal = 0
        TotalAP = 0
        TotalAR = 0
        TotalBT = 0
        TotalGJ = 0
        TotalBTGJ = 0
        GrandTotal = 0
        TotalBeginningBalance = 0
        TotalEndingBalance = 0
        CRUSBeginningBalance = 0
        CRUSDebits = 0
        CRUSCredits = 0
        CRUSNetChange = 0
        CRUSEndingBalance = 0
        CKUSBeginningBalance = 0
        CKUSDebits = 0
        CKUSCredits = 0
        CKUSNetChange = 0
        CKUSEndingBalance = 0
        PRBeginningBalance = 0
        PRDebits = 0
        PRCredits = 0
        PRNetChange = 0
        PREndingBalance = 0
        CRCANBeginningBalance = 0
        CRCANDebits = 0
        CRCANCredits = 0
        CRCANNetChange = 0
        CRCANEndingBalance = 0
        CKCANBeginningBalance = 0
        CKCANDebits = 0
        CKCANCredits = 0
        CKCANNetChange = 0
        CKCANEndingBalance = 0
        BBCRUSDebits = 0
        BBCKUSDebits = 0
        BBPRDebits = 0
        BBCRCANDebits = 0
        BBCKCANDebits = 0
        BBCRUSCredits = 0
        BBCKUSCredits = 0
        BBPRCredits = 0
        BBCRCANCredits = 0
        BBCKCANCredits = 0
        BBMMCredits = 0
        BBIACredits = 0
        BBMMDebits = 0
        BBIADebits = 0
        MMBeginningBalance = 0
        MMDebits = 0
        MMCredits = 0
        MMNetChange = 0
        MMEndingBalance = 0
        IABeginningBalance = 0
        IADebits = 0
        IACredits = 0
        IANetChange = 0
        IAEndingBalance = 0
        NetCashPosition = 0
        CurrentPayables = 0
    End Sub

    Public Sub ClearData()
        txtATLAP.Clear()
        txtATLAR.Clear()
        txtATLBT.Clear()
        txtATLTotal.Clear()
        txtALBAP.Clear()
        txtALBAR.Clear()
        txtALBBT.Clear()
        txtALBTotal.Clear()
        txtBeginningBalance.Clear()
        txtCBSAP.Clear()
        txtCBSAR.Clear()
        txtCBSBT.Clear()
        txtCGOAP.Clear()
        txtCGOAR.Clear()
        txtCGOBT.Clear()
        txtCGOTotal.Clear()
        txtCHTAP.Clear()
        txtCHTAR.Clear()
        txtCHTBT.Clear()
        txtCHTTotal.Clear()
        txtDENAP.Clear()
        txtDENAR.Clear()
        txtDENBT.Clear()
        txtDENTotal.Clear()
        txtCKCANBeginningBalance.Clear()
        txtCKCANCredits.Clear()
        txtCKCANDebits.Clear()
        txtCKCANEndingBalance.Clear()
        txtCKCANNetChange.Clear()
        txtCKUSBeginningBalance.Clear()
        txtCKUSCredits.Clear()
        txtCKUSDebits.Clear()
        txtCKUSEndingBalance.Clear()
        txtCKUSNetChange.Clear()
        txtCRCANBeginningBalance.Clear()
        txtCRCANCredits.Clear()
        txtCRCANDebits.Clear()
        txtCRCANEndingBalance.Clear()
        txtCRCANNetChange.Clear()
        txtCRUSBeginningBalance.Clear()
        txtCRUSCredits.Clear()
        txtCRUSDebits.Clear()
        txtCRUSEndingBalance.Clear()
        txtCRUSNetChange.Clear()
        txtPRBeginningBalance.Clear()
        txtPRCredits.Clear()
        txtPRDebits.Clear()
        txtPREndingBalance.Clear()
        txtPRNetChange.Clear()
        txtEndingBalanceForMonth.Clear()
        txtHOUAP.Clear()
        txtHOUAR.Clear()
        txtHOUBT.Clear()
        txtHOUTotal.Clear()
        txtSLCAP.Clear()
        txtSLCAR.Clear()
        txtSLCBT.Clear()
        txtSLCTotal.Clear()
        txtTFFAP.Clear()
        txtTFFAR.Clear()
        txtTFFBT.Clear()
        txtTFFTotal.Clear()
        txtTFTAP.Clear()
        txtTFTAR.Clear()
        txtTFTBT.Clear()
        txtTFTTotal.Clear()
        txtTORAP.Clear()
        txtTORAR.Clear()
        txtTORBT.Clear()
        txtTORTotal.Clear()
        txtTotalAP.Clear()
        txtTotalAR.Clear()
        txtTotalBalance.Clear()
        txtTotalBT.Clear()
        txtTWDAP.Clear()
        txtTWDAR.Clear()
        txtTWDBT.Clear()
        txtTWDTotal.Clear()
        txtTWEAP.Clear()
        txtTWEAR.Clear()
        txtTWEBT.Clear()
        txtTWETotal.Clear()
        txtMMBeginningBalance.Clear()
        txtMMCredits.Clear()
        txtMMDebits.Clear()
        txtMMEndingBalance.Clear()
        txtMMNetChange.Clear()
        txtIABeginningBalance.Clear()
        txtIACredits.Clear()
        txtIADebits.Clear()
        txtIAEndingBalance.Clear()
        txtIANetChange.Clear()
        txtNetCashPosition.Clear()
        txtCurrentPayables.Clear()
    End Sub

    Public Sub DefineMonth()
        BankDate = dtpBankDate.Value

        Dim DayOfDate, MonthOfDate, YearOfDate As Integer
        Dim strDayOfDate, strMonthOfDate, strYearOfDate As String

        DayOfDate = BankDate.Day
        MonthOfDate = BankDate.Month
        YearOfDate = BankDate.Year

        strDayOfDate = CStr(DayOfDate)
        strMonthOfDate = CStr(MonthOfDate)
        strYearOfDate = CStr(YearOfDate)

        Select Case MonthOfDate
            Case 1
                BeginDate = "01/01/" + strYearOfDate
                EndDate = "01/" + strDayOfDate + "/" + strYearOfDate
            Case 2
                BeginDate = "02/01/" + strYearOfDate
                EndDate = "02/" + strDayOfDate + "/" + strYearOfDate
            Case 3
                BeginDate = "03/01/" + strYearOfDate
                EndDate = "03/" + strDayOfDate + "/" + strYearOfDate
            Case 4
                BeginDate = "04/01/" + strYearOfDate
                EndDate = "04/" + strDayOfDate + "/" + strYearOfDate
            Case 5
                BeginDate = "05/01/" + strYearOfDate
                EndDate = "05/" + strDayOfDate + "/" + strYearOfDate
            Case 6
                BeginDate = "06/01/" + strYearOfDate
                EndDate = "06/" + strDayOfDate + "/" + strYearOfDate
            Case 7
                BeginDate = "07/01/" + strYearOfDate
                EndDate = "07/" + strDayOfDate + "/" + strYearOfDate
            Case 8
                BeginDate = "08/01/" + strYearOfDate
                EndDate = "08/" + strDayOfDate + "/" + strYearOfDate
            Case 9
                BeginDate = "09/01/" + strYearOfDate
                EndDate = "09/" + strDayOfDate + "/" + strYearOfDate
            Case 10
                BeginDate = "10/01/" + strYearOfDate
                EndDate = "10/" + strDayOfDate + "/" + strYearOfDate
            Case 11
                BeginDate = "11/01/" + strYearOfDate
                EndDate = "11/" + strDayOfDate + "/" + strYearOfDate
            Case 12
                BeginDate = "12/01/" + strYearOfDate
                EndDate = "12/" + strDayOfDate + "/" + strYearOfDate
        End Select
    End Sub

    Public Sub LoadDebitSummaryTotals()
        'Get Current Values for 10200
        Dim SumDebits10200Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumDebits10200Command As New SqlCommand(SumDebits10200Statement, con)
        SumDebits10200Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumDebits10200Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumDebits10200Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumDebits10200Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10200"

        Dim SumDebits10300Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumDebits10300Command As New SqlCommand(SumDebits10300Statement, con)
        SumDebits10300Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumDebits10300Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumDebits10300Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumDebits10300Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10300"

        Dim SumDebits10400Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumDebits10400Command As New SqlCommand(SumDebits10400Statement, con)
        SumDebits10400Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumDebits10400Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumDebits10400Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumDebits10400Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10400"

        Dim SumDebitsCAN10200Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumDebitsCAN10200Command As New SqlCommand(SumDebitsCAN10200Statement, con)
        SumDebitsCAN10200Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumDebitsCAN10200Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumDebitsCAN10200Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumDebitsCAN10200Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$10200"

        Dim SumDebitsCAN10400Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumDebitsCAN10400Command As New SqlCommand(SumDebitsCAN10400Statement, con)
        SumDebitsCAN10400Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumDebitsCAN10400Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumDebitsCAN10400Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumDebitsCAN10400Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$10400"

        Dim SumDebitsMM10600Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumDebitsMM10600Command As New SqlCommand(SumDebitsMM10600Statement, con)
        SumDebitsMM10600Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumDebitsMM10600Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumDebitsMM10600Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumDebitsMM10600Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10600"

        Dim SumDebitsIA10800Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumDebitsIA10800Command As New SqlCommand(SumDebitsIA10800Statement, con)
        SumDebitsIA10800Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumDebitsIA10800Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumDebitsIA10800Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumDebitsIA10800Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10800"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CKUSDebits = CDbl(SumDebits10200Command.ExecuteScalar)
        Catch ex As Exception
            CKUSDebits = 0
        End Try
        Try
            CRUSDebits = CDbl(SumDebits10400Command.ExecuteScalar)
        Catch ex As Exception
            CRUSDebits = 0
        End Try
        Try
            PRDebits = CDbl(SumDebits10300Command.ExecuteScalar)
        Catch ex As Exception
            PRDebits = 0
        End Try
        Try
            CKCANDebits = CDbl(SumDebitsCAN10200Command.ExecuteScalar)
        Catch ex As Exception
            CKCANDebits = 0
        End Try
        Try
            CRCANDebits = CDbl(SumDebitsCAN10400Command.ExecuteScalar)
        Catch ex As Exception
            CRCANDebits = 0
        End Try
        Try
            MMDebits = CDbl(SumDebitsMM10600Command.ExecuteScalar)
        Catch ex As Exception
            MMDebits = 0
        End Try
        Try
            IADebits = CDbl(SumDebitsIA10800Command.ExecuteScalar)
        Catch ex As Exception
            IADebits = 0
        End Try
        con.Close()

        txtCRUSDebits.Text = FormatNumber(CRUSDebits, 2)
        txtCKUSDebits.Text = FormatNumber(CKUSDebits, 2)
        txtPRDebits.Text = FormatNumber(PRDebits, 2)
        txtCRCANDebits.Text = FormatNumber(CRCANDebits, 2)
        txtCKCANDebits.Text = FormatNumber(CKCANDebits, 2)
        txtMMDebits.Text = FormatNumber(MMDebits, 2)
        txtIADebits.Text = FormatNumber(IADebits, 2)
    End Sub

    Public Sub LoadCreditSummaryTotals()
        'Get Current Values for Credits
        Dim SumCredits10200Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumCredits10200Command As New SqlCommand(SumCredits10200Statement, con)
        SumCredits10200Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumCredits10200Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumCredits10200Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumCredits10200Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10200"

        Dim SumCredits10300Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumCredits10300Command As New SqlCommand(SumCredits10300Statement, con)
        SumCredits10300Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumCredits10300Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumCredits10300Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumCredits10300Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10300"

        Dim SumCredits10400Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumCredits10400Command As New SqlCommand(SumCredits10400Statement, con)
        SumCredits10400Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumCredits10400Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumCredits10400Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumCredits10400Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10400"

        Dim SumCreditsCAN10200Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumCreditsCAN10200Command As New SqlCommand(SumCreditsCAN10200Statement, con)
        SumCreditsCAN10200Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumCreditsCAN10200Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumCreditsCAN10200Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumCreditsCAN10200Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$10200"

        Dim SumCreditsCAN10400Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumCreditsCAN10400Command As New SqlCommand(SumCreditsCAN10400Statement, con)
        SumCreditsCAN10400Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumCreditsCAN10400Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumCreditsCAN10400Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumCreditsCAN10400Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$10400"

        Dim SumCreditsMM10600Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumCreditsMM10600Command As New SqlCommand(SumCreditsMM10600Statement, con)
        SumCreditsMM10600Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumCreditsMM10600Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumCreditsMM10600Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumCreditsMM10600Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10600"

        Dim SumCreditsIA10800Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        Dim SumCreditsIA10800Command As New SqlCommand(SumCreditsIA10800Statement, con)
        SumCreditsIA10800Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        SumCreditsIA10800Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        SumCreditsIA10800Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        SumCreditsIA10800Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10800"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CKUSCredits = CDbl(SumCredits10200Command.ExecuteScalar)
        Catch ex As Exception
            CKUSCredits = 0
        End Try
        Try
            CRUSCredits = CDbl(SumCredits10400Command.ExecuteScalar)
        Catch ex As Exception
            CRUSCredits = 0
        End Try
        Try
            PRCredits = CDbl(SumCredits10300Command.ExecuteScalar)
        Catch ex As Exception
            PRCredits = 0
        End Try
        Try
            CKCANCredits = CDbl(SumCreditsCAN10200Command.ExecuteScalar)
        Catch ex As Exception
            CKCANCredits = 0
        End Try
        Try
            CRCANCredits = CDbl(SumCreditsCAN10400Command.ExecuteScalar)
        Catch ex As Exception
            CRCANCredits = 0
        End Try
        Try
            MMCredits = CDbl(SumCreditsMM10600Command.ExecuteScalar)
        Catch ex As Exception
            MMCredits = 0
        End Try
        Try
            IACredits = CDbl(SumCreditsIA10800Command.ExecuteScalar)
        Catch ex As Exception
            IACredits = 0
        End Try
        con.Close()

        txtCRUSCredits.Text = FormatNumber(CRUSCredits, 2)
        txtCKUSCredits.Text = FormatNumber(CKUSCredits, 2)
        txtPRCredits.Text = FormatNumber(PRCredits, 2)
        txtCRCANCredits.Text = FormatNumber(CRCANCredits, 2)
        txtCKCANCredits.Text = FormatNumber(CKCANCredits, 2)
        txtMMCredits.Text = FormatNumber(MMCredits, 2)
        txtIACredits.Text = FormatNumber(IACredits, 2)
    End Sub

    Public Sub LoadBeginningSummaryTotals()
        'Get Beg Balances
        Dim BBDebits10200Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBDebits10200Command As New SqlCommand(BBDebits10200Statement, con)
        BBDebits10200Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBDebits10200Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBDebits10200Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBDebits10200Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10200"

        Dim BBDebits10300Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBDebits10300Command As New SqlCommand(BBDebits10300Statement, con)
        BBDebits10300Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBDebits10300Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBDebits10300Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBDebits10300Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10300"

        Dim BBDebits10400Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBDebits10400Command As New SqlCommand(BBDebits10400Statement, con)
        BBDebits10400Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBDebits10400Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBDebits10400Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBDebits10400Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10400"

        Dim BBDebitsCAN10200Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBDebitsCAN10200Command As New SqlCommand(BBDebitsCAN10200Statement, con)
        BBDebitsCAN10200Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBDebitsCAN10200Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBDebitsCAN10200Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBDebitsCAN10200Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$10200"

        Dim BBDebitsCAN10400Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBDebitsCAN10400Command As New SqlCommand(BBDebitsCAN10400Statement, con)
        BBDebitsCAN10400Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBDebitsCAN10400Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBDebitsCAN10400Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBDebitsCAN10400Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$10400"

        Dim BBDebitsMM10600Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBDebitsMM10600Command As New SqlCommand(BBDebitsMM10600Statement, con)
        BBDebitsMM10600Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBDebitsMM10600Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBDebitsMM10600Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBDebitsMM10600Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10600"

        Dim BBDebitsIA10800Statement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBDebitsIA10800Command As New SqlCommand(BBDebitsIA10800Statement, con)
        BBDebitsIA10800Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBDebitsIA10800Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBDebitsIA10800Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBDebitsIA10800Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10800"

        Dim BBCredits10200Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBCredits10200Command As New SqlCommand(BBCredits10200Statement, con)
        BBCredits10200Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBCredits10200Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBCredits10200Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBCredits10200Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10200"

        Dim BBCredits10300Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBCredits10300Command As New SqlCommand(BBCredits10300Statement, con)
        BBCredits10300Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBCredits10300Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBCredits10300Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBCredits10300Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10300"

        Dim BBCredits10400Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBCredits10400Command As New SqlCommand(BBCredits10400Statement, con)
        BBCredits10400Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBCredits10400Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBCredits10400Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBCredits10400Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10400"

        Dim BBCreditsCAN10200Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBCreditsCAN10200Command As New SqlCommand(BBCreditsCAN10200Statement, con)
        BBCreditsCAN10200Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBCreditsCAN10200Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBCreditsCAN10200Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBCreditsCAN10200Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$10200"

        Dim BBCreditsCAN10400Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBCreditsCAN10400Command As New SqlCommand(BBCreditsCAN10400Statement, con)
        BBCreditsCAN10400Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBCreditsCAN10400Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBCreditsCAN10400Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBCreditsCAN10400Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "C$10400"

        Dim BBCreditsMM10600Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBCreditsMM10600Command As New SqlCommand(BBCreditsMM10600Statement, con)
        BBCreditsMM10600Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBCreditsMM10600Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBCreditsMM10600Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBCreditsMM10600Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10600"

        Dim BBCreditsIA10800Statement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE DivisionID <> @DivisionID AND GLAccountNumber = @GLAccountNumber AND GLTransactionDate < @BeginDate"
        Dim BBCreditsIA10800Command As New SqlCommand(BBCreditsIA10800Statement, con)
        BBCreditsIA10800Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
        BBCreditsIA10800Command.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
        BBCreditsIA10800Command.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
        BBCreditsIA10800Command.Parameters.Add("@GLAccountNumber", SqlDbType.VarChar).Value = "10800"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            BBCKUSDebits = CDbl(BBDebits10200Command.ExecuteScalar)
        Catch ex As Exception
            BBCKUSDebits = 0
        End Try
        Try
            BBCRUSDebits = CDbl(BBDebits10400Command.ExecuteScalar)
        Catch ex As Exception
            BBCRUSDebits = 0
        End Try
        Try
            BBPRDebits = CDbl(BBDebits10300Command.ExecuteScalar)
        Catch ex As Exception
            BBPRDebits = 0
        End Try
        Try
            BBCKCANDebits = CDbl(BBDebitsCAN10200Command.ExecuteScalar)
        Catch ex As Exception
            BBCKCANDebits = 0
        End Try
        Try
            BBCRCANDebits = CDbl(BBDebitsCAN10400Command.ExecuteScalar)
        Catch ex As Exception
            CRCANDebits = 0
        End Try
        Try
            BBMMDebits = CDbl(BBDebitsMM10600Command.ExecuteScalar)
        Catch ex As Exception
            BBMMDebits = 0
        End Try
        Try
            BBIADebits = CDbl(BBDebitsIA10800Command.ExecuteScalar)
        Catch ex As Exception
            BBIADebits = 0
        End Try
        Try
            BBCKUSCredits = CDbl(BBCredits10200Command.ExecuteScalar)
        Catch ex As Exception
            BBCKUSCredits = 0
        End Try
        Try
            BBCRUSCredits = CDbl(BBCredits10400Command.ExecuteScalar)
        Catch ex As Exception
            CRUSCredits = 0
        End Try
        Try
            BBPRCredits = CDbl(BBCredits10300Command.ExecuteScalar)
        Catch ex As Exception
            BBPRCredits = 0
        End Try
        Try
            BBCKCANCredits = CDbl(BBCreditsCAN10200Command.ExecuteScalar)
        Catch ex As Exception
            BBCKCANCredits = 0
        End Try
        Try
            BBCRCANCredits = CDbl(BBCreditsCAN10400Command.ExecuteScalar)
        Catch ex As Exception
            BBCRCANCredits = 0
        End Try
        Try
            BBMMCredits = CDbl(BBCreditsMM10600Command.ExecuteScalar)
        Catch ex As Exception
            BBMMCredits = 0
        End Try
        Try
            BBIACredits = CDbl(BBCreditsIA10800Command.ExecuteScalar)
        Catch ex As Exception
            BBIACredits = 0
        End Try
        con.Close()

        CRUSBeginningBalance = BBCRUSDebits - BBCRUSCredits
        CKUSBeginningBalance = BBCKUSDebits - BBCKUSCredits
        PRBeginningBalance = BBPRDebits - BBPRCredits
        CRCANBeginningBalance = BBCRCANDebits - BBCRCANCredits
        CKCANBeginningBalance = BBCKCANDebits - BBCKCANCredits
        MMBeginningBalance = BBMMDebits - BBMMCredits
        IABeginningBalance = BBIADebits - BBIACredits

        TotalBeginningBalance = CRUSBeginningBalance + CKUSBeginningBalance + PRBeginningBalance + CRCANBeginningBalance + CKCANBeginningBalance + MMBeginningBalance + IABeginningBalance

        txtCRUSBeginningBalance.Text = FormatNumber(CRUSBeginningBalance, 2)
        txtCKUSBeginningBalance.Text = FormatNumber(CKUSBeginningBalance, 2)
        txtPRBeginningBalance.Text = FormatNumber(PRBeginningBalance, 2)
        txtCRCANBeginningBalance.Text = FormatNumber(CRCANBeginningBalance, 2)
        txtCKCANBeginningBalance.Text = FormatNumber(CKCANBeginningBalance, 2)
        txtMMBeginningBalance.Text = FormatNumber(MMBeginningBalance, 2)
        txtIABeginningBalance.Text = FormatNumber(IABeginningBalance, 2)
        txtBeginningBalance.Text = FormatNumber(TotalBeginningBalance, 2)
    End Sub

    Public Sub LoadCurrentPayablesAndNetCash()
        Dim DebitPayablesStatement As String = "SELECT SUM(GLTransactionDebitAmount) FROM GLTransactionMasterList WHERE GLTransactionDate < @GLTransactionDate AND DivisionID <> @DivisionID AND GLAccountNumber LIKE '%20000'"
        Dim DebitPayablesCommand As New SqlCommand(DebitPayablesStatement, con)
        DebitPayablesCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        DebitPayablesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        Dim CreditPayablesStatement As String = "SELECT SUM(GLTransactionCreditAmount) FROM GLTransactionMasterList WHERE GLTransactionDate < @GLTransactionDate AND DivisionID <> @DivisionID AND GLAccountNumber LIKE '%20000'"
        Dim CreditPayablesCommand As New SqlCommand(CreditPayablesStatement, con)
        CreditPayablesCommand.Parameters.Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CreditPayablesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DebitPayables = CDbl(DebitPayablesCommand.ExecuteScalar)
        Catch ex As Exception
            DebitPayables = 0
        End Try
        Try
            CreditPayables = CDbl(CreditPayablesCommand.ExecuteScalar)
        Catch ex As Exception
            CreditPayables = 0
        End Try
        con.Close()

        CurrentPayables = DebitPayables - CreditPayables
        CurrentPayables = Math.Round(CurrentPayables, 2)
        NetCashPosition = TotalEndingBalance + CurrentPayables

        txtCurrentPayables.Text = FormatNumber(CurrentPayables, 2)
        txtNetCashPosition.Text = FormatNumber(NetCashPosition, 2)
    End Sub

    Public Sub CalculateNetChange()
        CRUSNetChange = CRUSDebits - CRUSCredits
        CKUSNetChange = CKUSDebits - CKUSCredits
        PRNetChange = PRDebits - PRCredits
        CRCANNetChange = CRCANDebits - CRCANCredits
        CKCANNetChange = CKCANDebits - CKCANCredits
        MMNetChange = MMDebits - MMCredits
        IANetChange = IADebits - IACredits

        txtCRUSNetChange.Text = FormatNumber(CRUSNetChange, 2)
        txtCKUSNetChange.Text = FormatNumber(CKUSNetChange, 2)
        txtPRNetChange.Text = FormatNumber(PRNetChange, 2)
        txtCRCANNetChange.Text = FormatNumber(CRCANNetChange, 2)
        txtCKCANNetChange.Text = FormatNumber(CKCANNetChange, 2)
        txtMMNetChange.Text = FormatNumber(MMNetChange, 2)
        txtIANetChange.Text = FormatNumber(IANetChange, 2)
    End Sub

    Public Sub CalculateEndingBalance()
        CRUSEndingBalance = CRUSBeginningBalance + CRUSNetChange
        CKUSEndingBalance = CKUSBeginningBalance + CKUSNetChange
        PREndingBalance = PRBeginningBalance + PRNetChange
        CRCANEndingBalance = CRCANBeginningBalance + CRCANNetChange
        CKCANEndingBalance = CKCANBeginningBalance + CKCANNetChange
        MMEndingBalance = MMBeginningBalance + MMNetChange
        IAEndingBalance = IABeginningBalance + IANetChange

        TotalEndingBalance = CRUSEndingBalance + CKUSEndingBalance + PREndingBalance + CRCANEndingBalance + CKCANEndingBalance + MMEndingBalance + IAEndingBalance

        txtCRUSEndingBalance.Text = FormatNumber(CRUSEndingBalance, 2)
        txtCKUSEndingBalance.Text = FormatNumber(CKUSEndingBalance, 2)
        txtPREndingBalance.Text = FormatNumber(PREndingBalance, 2)
        txtCRCANEndingBalance.Text = FormatNumber(CRCANEndingBalance, 2)
        txtCKCANEndingBalance.Text = FormatNumber(CKCANEndingBalance, 2)
        txtMMEndingBalance.Text = FormatNumber(MMEndingBalance, 2)
        txtIAEndingBalance.Text = FormatNumber(IAEndingBalance, 2)

        txtEndingBalanceForMonth.Text = FormatNumber(TotalEndingBalance, 2)
    End Sub

    Public Sub LoadDailyTotals()
        Dim TWDARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2)"
        Dim TWDARCommand As New SqlCommand(TWDARStatement, con)
        TWDARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TWDARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        TWDARCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"

        Dim ATLARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND DivisionID = @DivisionID"
        Dim ATLARCommand As New SqlCommand(ATLARStatement, con)
        ATLARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        ATLARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"

        Dim CBSARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND DivisionID = @DivisionID"
        Dim CBSARCommand As New SqlCommand(CBSARStatement, con)
        CBSARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CBSARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"

        Dim CGOARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND DivisionID = @DivisionID"
        Dim CGOARCommand As New SqlCommand(CGOARStatement, con)
        CGOARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CGOARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"

        Dim CHTARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND DivisionID = @DivisionID"
        Dim CHTARCommand As New SqlCommand(CHTARStatement, con)
        CHTARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CHTARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"

        Dim DENARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND DivisionID = @DivisionID"
        Dim DENARCommand As New SqlCommand(DENARStatement, con)
        DENARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        DENARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"

        Dim HOUARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND DivisionID = @DivisionID"
        Dim HOUARCommand As New SqlCommand(HOUARStatement, con)
        HOUARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        HOUARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"

        Dim TFTARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND DivisionID = @DivisionID"
        Dim TFTARCommand As New SqlCommand(TFTARStatement, con)
        TFTARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TFTARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"

        Dim TFFARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND DivisionID = @DivisionID"
        Dim TFFARCommand As New SqlCommand(TFFARStatement, con)
        TFFARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TFFARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"

        Dim TORARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND DivisionID = @DivisionID"
        Dim TORARCommand As New SqlCommand(TORARStatement, con)
        TORARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TORARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"

        Dim SLCARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND DivisionID = @DivisionID"
        Dim SLCARCommand As New SqlCommand(SLCARStatement, con)
        SLCARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        SLCARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

        Dim TWEARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND DivisionID = @DivisionID"
        Dim TWEARCommand As New SqlCommand(TWEARStatement, con)
        TWEARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TWEARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        Dim ALBARStatement As String = "SELECT SUM(PaymentAmount) FROM ARPaymentLog WHERE PaymentDate = @PaymentDate AND DivisionID = @DivisionID"
        Dim ALBARCommand As New SqlCommand(ALBARStatement, con)
        ALBARCommand.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        ALBARCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TWDAR = CDbl(TWDARCommand.ExecuteScalar)
        Catch ex As Exception
            TWDAR = 0
        End Try
        Try
            ATLAR = CDbl(ATLARCommand.ExecuteScalar)
        Catch ex As Exception
            ATLAR = 0
        End Try
        Try
            CBSAR = CDbl(CBSARCommand.ExecuteScalar)
        Catch ex As Exception
            CBSAR = 0
        End Try
        Try
            CGOAR = CDbl(CGOARCommand.ExecuteScalar)
        Catch ex As Exception
            CGOAR = 0
        End Try
        Try
            CHTAR = CDbl(CHTARCommand.ExecuteScalar)
        Catch ex As Exception
            CHTAR = 0
        End Try
        Try
            DENAR = CDbl(DENARCommand.ExecuteScalar)
        Catch ex As Exception
            DENAR = 0
        End Try
        Try
            HOUAR = CDbl(HOUARCommand.ExecuteScalar)
        Catch ex As Exception
            HOUAR = 0
        End Try
        Try
            TFTAR = CDbl(TFTARCommand.ExecuteScalar)
        Catch ex As Exception
            TFTAR = 0
        End Try
        Try
            TFFAR = CDbl(TFFARCommand.ExecuteScalar)
        Catch ex As Exception
            TFFAR = 0
        End Try
        Try
            TORAR = CDbl(TORARCommand.ExecuteScalar)
        Catch ex As Exception
            TORAR = 0
        End Try
        Try
            SLCAR = CDbl(SLCARCommand.ExecuteScalar)
        Catch ex As Exception
            SLCAR = 0
        End Try
        Try
            TWEAR = CDbl(TWEARCommand.ExecuteScalar)
        Catch ex As Exception
            TWEAR = 0
        End Try
        Try
            ALBAR = CDbl(ALBARCommand.ExecuteScalar)
        Catch ex As Exception
            ALBAR = 0
        End Try
        con.Close()

        txtATLAR.Text = FormatNumber(ATLAR, 2)
        txtCBSAR.Text = FormatNumber(CBSAR, 2)
        txtCGOAR.Text = FormatNumber(CGOAR, 2)
        txtCHTAR.Text = FormatNumber(CHTAR, 2)
        txtDENAR.Text = FormatNumber(DENAR, 2)
        txtHOUAR.Text = FormatNumber(HOUAR, 2)
        txtTFTAR.Text = FormatNumber(TFTAR, 2)
        txtTFFAR.Text = FormatNumber(TFFAR, 2)
        txtTWDAR.Text = FormatNumber(TWDAR, 2)
        txtTWEAR.Text = FormatNumber(TWEAR, 2)
        txtTORAR.Text = FormatNumber(TORAR, 2)
        txtSLCAR.Text = FormatNumber(SLCAR, 2)
        txtALBAR.Text = FormatNumber(ALBAR, 2)

        TotalAR = ATLAR + CBSAR + CHTAR + CGOAR + DENAR + HOUAR + TFTAR + TFFAR + TORAR + TWDAR + TWEAR + SLCAR + ALBAR
        txtTotalAR.Text = FormatNumber(TotalAR, 2)
        '***************************************************************************************************************************************
        Dim TWDAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2)"
        Dim TWDAPCommand As New SqlCommand(TWDAPStatement, con)
        TWDAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TWDAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        TWDAPCommand.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"

        Dim ATLAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND DivisionID = @DivisionID"
        Dim ATLAPCommand As New SqlCommand(ATLAPStatement, con)
        ATLAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        ATLAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"

        Dim CBSAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND DivisionID = @DivisionID"
        Dim CBSAPCommand As New SqlCommand(CBSAPStatement, con)
        CBSAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CBSAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"

        Dim CGOAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND DivisionID = @DivisionID"
        Dim CGOAPCommand As New SqlCommand(CGOAPStatement, con)
        CGOAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CGOAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"

        Dim CHTAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND DivisionID = @DivisionID"
        Dim CHTAPCommand As New SqlCommand(CHTAPStatement, con)
        CHTAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CHTAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"

        Dim DENAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND DivisionID = @DivisionID"
        Dim DENAPCommand As New SqlCommand(DENAPStatement, con)
        DENAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        DENAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"

        Dim HOUAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND DivisionID = @DivisionID"
        Dim HOUAPCommand As New SqlCommand(HOUAPStatement, con)
        HOUAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        HOUAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"

        Dim TFTAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND DivisionID = @DivisionID"
        Dim TFTAPCommand As New SqlCommand(TFTAPStatement, con)
        TFTAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TFTAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"

        Dim TFFAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND DivisionID = @DivisionID"
        Dim TFFAPCommand As New SqlCommand(TFFAPStatement, con)
        TFFAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TFFAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"

        Dim TORAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND DivisionID = @DivisionID"
        Dim TORAPCommand As New SqlCommand(TORAPStatement, con)
        TORAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TORAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"

        Dim SLCAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND DivisionID = @DivisionID"
        Dim SLCAPCommand As New SqlCommand(SLCAPStatement, con)
        SLCAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        SLCAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

        Dim TWEAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND DivisionID = @DivisionID"
        Dim TWEAPCommand As New SqlCommand(TWEAPStatement, con)
        TWEAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TWEAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        Dim ALBAPStatement As String = "SELECT SUM(CheckAmount) FROM APCheckLog WHERE CheckDate = @CheckDate AND DivisionID = @DivisionID"
        Dim ALBAPCommand As New SqlCommand(ALBAPStatement, con)
        ALBAPCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        ALBAPCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TWDAP = CDbl(TWDAPCommand.ExecuteScalar)
        Catch ex As Exception
            TWDAP = 0
        End Try
        Try
            ATLAP = CDbl(ATLAPCommand.ExecuteScalar)
        Catch ex As Exception
            ATLAP = 0
        End Try
        Try
            CBSAP = CDbl(CBSAPCommand.ExecuteScalar)
        Catch ex As Exception
            CBSAP = 0
        End Try
        Try
            CGOAP = CDbl(CGOAPCommand.ExecuteScalar)
        Catch ex As Exception
            CGOAP = 0
        End Try
        Try
            CHTAP = CDbl(CHTAPCommand.ExecuteScalar)
        Catch ex As Exception
            CHTAP = 0
        End Try
        Try
            DENAP = CDbl(DENAPCommand.ExecuteScalar)
        Catch ex As Exception
            DENAP = 0
        End Try
        Try
            HOUAP = CDbl(HOUAPCommand.ExecuteScalar)
        Catch ex As Exception
            HOUAP = 0
        End Try
        Try
            TFTAP = CDbl(TFTAPCommand.ExecuteScalar)
        Catch ex As Exception
            TFTAP = 0
        End Try
        Try
            TFFAP = CDbl(TFFAPCommand.ExecuteScalar)
        Catch ex As Exception
            TFFAP = 0
        End Try
        Try
            TORAP = CDbl(TORAPCommand.ExecuteScalar)
        Catch ex As Exception
            TORAP = 0
        End Try
        Try
            SLCAP = CDbl(SLCAPCommand.ExecuteScalar)
        Catch ex As Exception
            SLCAP = 0
        End Try
        Try
            TWEAP = CDbl(TWEAPCommand.ExecuteScalar)
        Catch ex As Exception
            TWEAP = 0
        End Try
        Try
            ALBAP = CDbl(ALBAPCommand.ExecuteScalar)
        Catch ex As Exception
            ALBAP = 0
        End Try
        con.Close()

        txtATLAP.Text = FormatNumber(ATLAP, 2)
        txtCBSAP.Text = FormatNumber(CBSAP, 2)
        txtCGOAP.Text = FormatNumber(CGOAP, 2)
        txtCHTAP.Text = FormatNumber(CHTAP, 2)
        txtDENAP.Text = FormatNumber(DENAP, 2)
        txtHOUAP.Text = FormatNumber(HOUAP, 2)
        txtTFTAP.Text = FormatNumber(TFTAP, 2)
        txtTFFAP.Text = FormatNumber(TFFAP, 2)
        txtTWDAP.Text = FormatNumber(TWDAP, 2)
        txtTWEAP.Text = FormatNumber(TWEAP, 2)
        txtTORAP.Text = FormatNumber(TORAP, 2)
        txtSLCAP.Text = FormatNumber(SLCAP, 2)
        txtALBAP.Text = FormatNumber(ALBAP, 2)

        TotalAP = ATLAP + CBSAP + CHTAP + CGOAP + DENAP + HOUAP + TFTAP + TFFAP + TORAP + TWDAP + TWEAP + SLCAP + ALBAP
        txtTotalAP.Text = FormatNumber(TotalAP, 2)
        '***************************************************************************************************************************************
        Dim TWDBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2)"
        Dim TWDBTCommand As New SqlCommand(TWDBTStatement, con)
        TWDBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TWDBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        TWDBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        Dim ATLBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND DivisionID = @DivisionID"
        Dim ATLBTCommand As New SqlCommand(ATLBTStatement, con)
        ATLBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        ATLBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"

        Dim CBSBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND DivisionID = @DivisionID"
        Dim CBSBTCommand As New SqlCommand(CBSBTStatement, con)
        CBSBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CBSBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"

        Dim CGOBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND DivisionID = @DivisionID"
        Dim CGOBTCommand As New SqlCommand(CGOBTStatement, con)
        CGOBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CGOBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"

        Dim CHTBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND DivisionID = @DivisionID"
        Dim CHTBTCommand As New SqlCommand(CHTBTStatement, con)
        CHTBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CHTBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"

        Dim DENBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND DivisionID = @DivisionID"
        Dim DENBTCommand As New SqlCommand(DENBTStatement, con)
        DENBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        DENBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"

        Dim HOUBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND DivisionID = @DivisionID"
        Dim HOUBTCommand As New SqlCommand(HOUBTStatement, con)
        HOUBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        HOUBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"

        Dim TFTBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND DivisionID = @DivisionID"
        Dim TFTBTCommand As New SqlCommand(TFTBTStatement, con)
        TFTBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TFTBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"

        Dim TFFBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND DivisionID = @DivisionID"
        Dim TFFBTCommand As New SqlCommand(TFFBTStatement, con)
        TFFBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TFFBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"

        Dim TORBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND DivisionID = @DivisionID"
        Dim TORBTCommand As New SqlCommand(TORBTStatement, con)
        TORBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TORBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"

        Dim SLCBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND DivisionID = @DivisionID"
        Dim SLCBTCommand As New SqlCommand(SLCBTStatement, con)
        SLCBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        SLCBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

        Dim TWEBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND DivisionID = @DivisionID"
        Dim TWEBTCommand As New SqlCommand(TWEBTStatement, con)
        TWEBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TWEBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        Dim ALBBTStatement As String = "SELECT SUM(NetAmount) FROM BankTransactionsQuery WHERE TransactionDate = @TransactionDate AND DivisionID = @DivisionID"
        Dim ALBBTCommand As New SqlCommand(ALBBTStatement, con)
        ALBBTCommand.Parameters.Add("@TransactionDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        ALBBTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TWDBT = CDbl(TWDBTCommand.ExecuteScalar)
        Catch ex As Exception
            TWDBT = 0
        End Try
        Try
            ATLBT = CDbl(ATLBTCommand.ExecuteScalar)
        Catch ex As Exception
            ATLBT = 0
        End Try
        Try
            CBSBT = CDbl(CBSBTCommand.ExecuteScalar)
        Catch ex As Exception
            CBSBT = 0
        End Try
        Try
            CGOBT = CDbl(CGOBTCommand.ExecuteScalar)
        Catch ex As Exception
            CGOBT = 0
        End Try
        Try
            CHTBT = CDbl(CHTBTCommand.ExecuteScalar)
        Catch ex As Exception
            CHTBT = 0
        End Try
        Try
            DENBT = CDbl(DENBTCommand.ExecuteScalar)
        Catch ex As Exception
            DENBT = 0
        End Try
        Try
            HOUBT = CDbl(HOUBTCommand.ExecuteScalar)
        Catch ex As Exception
            HOUBT = 0
        End Try
        Try
            TFTBT = CDbl(TFTBTCommand.ExecuteScalar)
        Catch ex As Exception
            TFTBT = 0
        End Try
        Try
            TFFBT = CDbl(TFFBTCommand.ExecuteScalar)
        Catch ex As Exception
            TFFBT = 0
        End Try
        Try
            TORBT = CDbl(TORBTCommand.ExecuteScalar)
        Catch ex As Exception
            TORBT = 0
        End Try
        Try
            SLCBT = CDbl(SLCBTCommand.ExecuteScalar)
        Catch ex As Exception
            SLCBT = 0
        End Try
        Try
            TWEBT = CDbl(TWEBTCommand.ExecuteScalar)
        Catch ex As Exception
            TWEBT = 0
        End Try
        Try
            ALBBT = CDbl(ALBBTCommand.ExecuteScalar)
        Catch ex As Exception
            ALBBT = 0
        End Try
        con.Close()
        '***************************************************************************************************************************************
        Dim TWDGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournalTransactionQuery WHERE JournalDate = @JournalDate AND (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND GLAccountNumber BETWEEN '10200' AND '10800'"
        Dim TWDGJCommand As New SqlCommand(TWDGJStatement, con)
        TWDGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TWDGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
        TWDGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFP"

        Dim ATLGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournalTransactionQuery WHERE JournalDate = @JournalDate AND DivisionID = @DivisionID AND GLAccountNumber BETWEEN '10200' AND '10800'"
        Dim ATLGJCommand As New SqlCommand(ATLGJStatement, con)
        ATLGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        ATLGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"

        Dim CBSGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournalTransactionQuery WHERE JournalDate = @JournalDate AND DivisionID = @DivisionID AND GLAccountNumber BETWEEN '10200' AND '10800'"
        Dim CBSGJCommand As New SqlCommand(CBSGJStatement, con)
        CBSGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CBSGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"

        Dim CGOGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournalTransactionQuery WHERE JournalDate = @JournalDate AND DivisionID = @DivisionID AND GLAccountNumber BETWEEN '10200' AND '10800'"
        Dim CGOGJCommand As New SqlCommand(CGOGJStatement, con)
        CGOGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CGOGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"

        Dim CHTGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournal WHERE JournalDate = @JournalDate AND DivisionID = @DivisionID AND GLAccountNumber BETWEEN '10200' AND '10800'"
        Dim CHTGJCommand As New SqlCommand(CHTGJStatement, con)
        CHTGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        CHTGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"

        Dim DENGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournalTransactionQuery WHERE JournalDate = @JournalDate AND DivisionID = @DivisionID AND GLAccountNumber BETWEEN '10200' AND '10800'"
        Dim DENGJCommand As New SqlCommand(DENGJStatement, con)
        DENGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        DENGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"

        Dim HOUGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournalTransactionQuery WHERE JournalDate = @JournalDate AND DivisionID = @DivisionID AND GLAccountNumber BETWEEN '10200' AND '10800'"
        Dim HOUGJCommand As New SqlCommand(HOUGJStatement, con)
        HOUGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        HOUGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"

        Dim TFTGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournalTransactionQuery WHERE JournalDate = @JournalDate AND DivisionID = @DivisionID AND GLAccountNumber BETWEEN '10200' AND '10800'"
        Dim TFTGJCommand As New SqlCommand(TFTGJStatement, con)
        TFTGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TFTGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"

        Dim TFFGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournalTransactionQuery WHERE JournalDate = @JournalDate AND DivisionID = @DivisionID AND GLAccountNumber BETWEEN '10200' AND '10800'"
        Dim TFFGJCommand As New SqlCommand(TFFGJStatement, con)
        TFFGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TFFGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"

        Dim TORGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournalTransactionQuery WHERE JournalDate = @JournalDate AND DivisionID = @DivisionID AND GLAccountNumber BETWEEN '10200' AND '10800'"
        Dim TORGJCommand As New SqlCommand(TORGJStatement, con)
        TORGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TORGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"

        Dim SLCGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournalTransactionQuery WHERE JournalDate = @JournalDate AND DivisionID = @DivisionID AND GLAccountNumber BETWEEN '10200' AND '10800'"
        Dim SLCGJCommand As New SqlCommand(SLCGJStatement, con)
        SLCGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        SLCGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"

        Dim TWEGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournalTransactionQuery WHERE JournalDate = @JournalDate AND DivisionID = @DivisionID AND GLAccountNumber BETWEEN '10200' AND '10800'"
        Dim TWEGJCommand As New SqlCommand(TWEGJStatement, con)
        TWEGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        TWEGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"

        Dim ALBGJStatement As String = "SELECT SUM(NetAmount) FROM GLJournalTransactionQuery WHERE JournalDate = @JournalDate AND DivisionID = @DivisionID AND GLAccountNumber BEALBEN '10200' AND '10800'"
        Dim ALBGJCommand As New SqlCommand(ALBGJStatement, con)
        ALBGJCommand.Parameters.Add("@JournalDate", SqlDbType.VarChar).Value = dtpBankDate.Value
        ALBGJCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TWDGJ = CDbl(TWDGJCommand.ExecuteScalar)
        Catch ex As Exception
            TWDGJ = 0
        End Try
        Try
            ATLGJ = CDbl(ATLGJCommand.ExecuteScalar)
        Catch ex As Exception
            ATLGJ = 0
        End Try
        Try
            CBSGJ = CDbl(CBSGJCommand.ExecuteScalar)
        Catch ex As Exception
            CBSGJ = 0
        End Try
        Try
            CGOGJ = CDbl(CGOGJCommand.ExecuteScalar)
        Catch ex As Exception
            CGOGJ = 0
        End Try
        Try
            CHTGJ = CDbl(CHTGJCommand.ExecuteScalar)
        Catch ex As Exception
            CHTGJ = 0
        End Try
        Try
            DENGJ = CDbl(DENGJCommand.ExecuteScalar)
        Catch ex As Exception
            DENGJ = 0
        End Try
        Try
            HOUGJ = CDbl(HOUGJCommand.ExecuteScalar)
        Catch ex As Exception
            HOUGJ = 0
        End Try
        Try
            TFTGJ = CDbl(TFTGJCommand.ExecuteScalar)
        Catch ex As Exception
            TFTGJ = 0
        End Try
        Try
            TFFGJ = CDbl(TFFGJCommand.ExecuteScalar)
        Catch ex As Exception
            TFFGJ = 0
        End Try
        Try
            TORGJ = CDbl(TORGJCommand.ExecuteScalar)
        Catch ex As Exception
            TORGJ = 0
        End Try
        Try
            SLCGJ = CDbl(SLCGJCommand.ExecuteScalar)
        Catch ex As Exception
            SLCGJ = 0
        End Try
        Try
            TWEGJ = CDbl(TWEGJCommand.ExecuteScalar)
        Catch ex As Exception
            TWEGJ = 0
        End Try
        Try
            ALBGJ = CDbl(ALBGJCommand.ExecuteScalar)
        Catch ex As Exception
            ALBGJ = 0
        End Try
        con.Close()
        '**************************************************************************************************************************************
        ATLBTGJ = ATLBT + ATLGJ
        CBSBTGJ = CBSBT + CBSGJ
        CGOBTGJ = CGOBT + CGOGJ
        CHTBTGJ = CHTBT + CHTGJ
        DENBTGJ = DENBT + DENGJ
        HOUBTGJ = HOUBT + HOUGJ
        TFFBTGJ = TFFBT + TFFGJ
        TFTBTGJ = TFTBT + TFTGJ
        TWDBTGJ = TWDBT + TWDGJ
        TWEBTGJ = TWEBT + TWEGJ
        SLCBTGJ = SLCBT + SLCGJ
        ALBBTGJ = ALBBT + ALBGJ
        '**************************************************************************************************************************************
        txtATLBT.Text = FormatNumber(ATLBTGJ, 2)
        txtCBSBT.Text = FormatNumber(CBSBTGJ, 2)
        txtCGOBT.Text = FormatNumber(CGOBTGJ, 2)
        txtCHTBT.Text = FormatNumber(CHTBTGJ, 2)
        txtDENBT.Text = FormatNumber(DENBTGJ, 2)
        txtHOUBT.Text = FormatNumber(HOUBTGJ, 2)
        txtTFTBT.Text = FormatNumber(TFTBTGJ, 2)
        txtTFFBT.Text = FormatNumber(TFFBTGJ, 2)
        txtTWDBT.Text = FormatNumber(TWDBTGJ, 2)
        txtTWEBT.Text = FormatNumber(TWEBTGJ, 2)
        txtTORBT.Text = FormatNumber(TORBTGJ, 2)
        txtSLCBT.Text = FormatNumber(SLCBTGJ, 2)
        txtALBBT.Text = FormatNumber(ALBBTGJ, 2)

        TotalBTGJ = ATLBTGJ + CBSBTGJ + CHTBTGJ + CGOBTGJ + DENBTGJ + HOUBTGJ + TFTBTGJ + TFFBTGJ + TORBTGJ + TWDBTGJ + TWEBTGJ + SLCBTGJ + ALBBTGJ
        txtTotalBT.Text = FormatNumber(TotalBTGJ, 2)
        '***************************************************************************************************************************************
        ATLTotal = ATLAR - ATLAP + ATLBTGJ
        CHTTotal = CHTAR - CHTAP + CHTBTGJ
        CGOTotal = CGOAR - CGOAP + CGOBTGJ
        CBSTotal = CBSAR - CBSAP + CBSBTGJ
        HOUTotal = HOUAR - HOUAP + HOUBTGJ
        TFFTotal = TFFAR - TFFAP + TFFBTGJ
        TFTTotal = TFTAR - TFTAP + TFTBTGJ
        TWDTotal = TWDAR - TWDAP + TWDBTGJ
        TWETotal = TWEAR - TWEAP + TWEBTGJ
        TORTotal = TORAR - TORAP + TORBTGJ
        DENTotal = DENAR - DENAP + DENBTGJ
        SLCTotal = SLCAR - SLCAP + SLCBTGJ
        ALBTotal = ALBAR - ALBAP + ALBBTGJ

        txtATLTotal.Text = FormatNumber(ATLTotal, 2)
        txtCHTTotal.Text = FormatNumber(CHTTotal, 2)
        txtCGOTotal.Text = FormatNumber(CGOTotal, 2)
        txtSLCTotal.Text = FormatNumber(SLCTotal, 2)
        txtCBSTotal.Text = FormatNumber(CBSTotal, 2)
        txtDENTotal.Text = FormatNumber(DENTotal, 2)
        txtHOUTotal.Text = FormatNumber(HOUTotal, 2)
        txtTFFTotal.Text = FormatNumber(TFFTotal, 2)
        txtTFTTotal.Text = FormatNumber(TFTTotal, 2)
        txtTORTotal.Text = FormatNumber(TORTotal, 2)
        txtTWETotal.Text = FormatNumber(TWETotal, 2)
        txtTWDTotal.Text = FormatNumber(TWDTotal, 2)
        txtALBTotal.Text = FormatNumber(ALBTotal, 2)

        GrandTotal = ATLTotal + CBSTotal + CGOTotal + CHTTotal + DENTotal + HOUTotal + TFFTotal + TFTTotal + TORTotal + TWDTotal + TWETotal + SLCTotal + ALBTotal
        txtTotalBalance.Text = FormatNumber(GrandTotal, 2)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dtpBankDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpBankDate.ValueChanged
        If tabCashReciptsMainControl.SelectedIndex = 0 Then
            ClearData()
            ClearVariables()
            DefineMonth()
            LoadDailyTotals()
        ElseIf tabCashReciptsMainControl.SelectedIndex = 1 Then
            'Skip
        ElseIf tabCashReciptsMainControl.SelectedIndex = 2 Then
            ClearData()
            ClearVariables()
            DefineMonth()
            LoadDebitSummaryTotals()
            LoadCreditSummaryTotals()
            CalculateNetChange()
            LoadBeginningSummaryTotals()
            CalculateEndingBalance()
            LoadCurrentPayablesAndNetCash()
        End If
    End Sub

    Private Sub tabCashReciptsMainControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabCashReciptsMainControl.SelectedIndexChanged
        If tabCashReciptsMainControl.SelectedIndex = 0 Then
            ClearData()
            ClearVariables()
            DefineMonth()
            LoadDailyTotals()
        ElseIf tabCashReciptsMainControl.SelectedIndex = 1 Then
            'Skip
        ElseIf tabCashReciptsMainControl.SelectedIndex = 2 Then
            ClearData()
            ClearVariables()
            DefineMonth()
            LoadDebitSummaryTotals()
            LoadCreditSummaryTotals()
            CalculateNetChange()
            LoadBeginningSummaryTotals()
            CalculateEndingBalance()
            LoadCurrentPayablesAndNetCash()
        End If
    End Sub

End Class