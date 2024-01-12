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
Public Class MonthEndReports
    Inherits System.Windows.Forms.Form

    Dim CurrentMonth As String = ""
    Dim BeginDate, EndDate As String
    Dim ValidMonth As String = ""
    Dim YearString As String = ""
    Dim BeginFiscalYear, EndFiscalYear As String
    Dim BeginFiscalDate, EndFiscalDate As String

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As DataSet
    Dim dt As DataTable

    Private Sub MonthEndReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        cboYear.SelectedIndex = -1
        cboMonth.SelectedIndex = -1

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = True
        Else
            cboDivisionID.Text = EmployeeCompanyCode
            cboDivisionID.Enabled = False
        End If
    End Sub

    Public Sub LoadCustomerList()
        'Loads Customer List for the specific division
        cmd = New SqlCommand("SELECT * FROM CustomerList WHERE CustomerClass <> @CustomerClass AND AccountingHold <> 'YES' AND OnHoldStatus <> 'YES' AND DivisionID <> 'TST' AND PaymentTerms <> 'COD' and PaymentTerms <> 'CREDIT CARD' AND PaymentTerms <> 'Prepaid'", con)
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "CustomerList")
        dgvCustomerList.DataSource = ds3.Tables("CustomerList")
        con.Close()
    End Sub

    Public Sub LoadCustomerHoldList()
        'Loads Customer List for the specific division
        cmd = New SqlCommand("SELECT * FROM CustomerHoldList", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd
        myAdapter6.Fill(ds6, "CustomerHoldList")
        con.Close()
    End Sub

    Public Sub TFPErrorLogUpdate()
        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment.Substring(0, 200)
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub DefineMonth()
        CurrentMonth = cboMonth.Text
        YearString = cboYear.Text

        Select Case CurrentMonth
            Case "January"
                BeginDate = "01/01/" + YearString
                EndDate = "01/31/" + YearString
                ValidMonth = "YES"
            Case "February"
                BeginDate = "02/01/" + YearString
                EndDate = "02/28/" + YearString
                ValidMonth = "YES"
            Case "March"
                BeginDate = "03/01/" + YearString
                EndDate = "03/31/" + YearString
                ValidMonth = "YES"
            Case "April"
                BeginDate = "04/01/" + YearString
                EndDate = "04/30/" + YearString
                ValidMonth = "YES"
            Case "May"
                BeginDate = "05/01/" + YearString
                EndDate = "05/31/" + YearString
                ValidMonth = "YES"
            Case "June"
                BeginDate = "06/01/" + YearString
                EndDate = "06/30/" + YearString
                ValidMonth = "YES"
            Case "July"
                BeginDate = "07/01/" + YearString
                EndDate = "07/31/" + YearString
                ValidMonth = "YES"
            Case "August"
                BeginDate = "08/01/" + YearString
                EndDate = "08/31/" + YearString
                ValidMonth = "YES"
            Case "September"
                BeginDate = "09/01/" + YearString
                EndDate = "09/30/" + YearString
                ValidMonth = "YES"
            Case "October"
                BeginDate = "10/01/" + YearString
                EndDate = "10/31/" + YearString
                ValidMonth = "YES"
            Case "November"
                BeginDate = "11/01/" + YearString
                EndDate = "11/30/" + YearString
                ValidMonth = "YES"
            Case "December"
                BeginDate = "12/01/" + YearString
                EndDate = "12/31/" + YearString
                ValidMonth = "YES"
            Case Else
                ValidMonth = "NO"
        End Select
    End Sub

    Private Sub cmdPrintReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintReports.Click
        'Validate that the fields are selected
        If cboDivisionID.Text = "" Or cboMonth.Text = "" Or cboYear.Text = "" Then
            MsgBox("You must select a month, year, and division.", MsgBoxStyle.OkOnly)
        Else
            lblPrinting.Text = "Printing Reports --- Please Wait."

            'Define month selected
            DefineMonth()

            'Filter Dataset
            cmd = New SqlCommand("SELECT * FROM ConsignmentBillingTable WHERE DivisionID = @DivisionID AND BillDate BETWEEN @BeginDate AND @EndDate", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ConsignmentBillingTable")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport = CRXConsignmentBillingMonth1
            MyReport.SetDataSource(ds)
            MyReport.PrintToPrinter(1, True, 1, 999)
            con.Close()

            'Filter Dataset
            cmd2 = New SqlCommand("SELECT * FROM InvoiceHeaderTable WHERE (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceStatus <> 'BILL ONLY' AND InvoiceDate BETWEEN @BeginDate AND @EndDate", con)
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd2.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            cmd2.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd2.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate

            If con.State = ConnectionState.Closed Then con.Open()
            ds2 = New DataSet()
            myAdapter2.SelectCommand = cmd2
            myAdapter2.Fill(ds2, "InvoiceHeaderTable")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport2 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport2 = CRXInvoiceDailyTotalsMonth1
            MyReport2.SetDataSource(ds2)
            MyReport2.PrintToPrinter(1, True, 1, 999)
            con.Close()

            ''Define Fiscal Year
            DefineFiscalYear()

            'Filter Dataset
            cmd3 = New SqlCommand("SELECT * FROM InvoiceLineQuery WHERE (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceStatus <> 'BILL ONLY' AND InvoiceDate BETWEEN @BeginDate AND @EndDate", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd3.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            cmd3.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginFiscalDate
            cmd3.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndFiscalDate

            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter3.SelectCommand = cmd3
            myAdapter3.Fill(ds3, "InvoiceLineQuery")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport3 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport3 = CRXSalesByItemClass_TWDMonth1
            MyReport3.SetDataSource(ds3)
            MyReport3.PrintToPrinter(1, True, 1, 999) '
            con.Close()

            'Filter Dataset
            cmd4 = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE DivisionID <> @DivisionID AND InvoiceStatus <> 'BILL ONLY' AND InvoiceDate BETWEEN @BeginDate AND @EndDate", con)
            cmd4.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TST"
            cmd4.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginFiscalDate
            cmd4.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndFiscalDate

            If con.State = ConnectionState.Closed Then con.Open()
            ds4 = New DataSet()
            myAdapter4.SelectCommand = cmd4
            myAdapter4.Fill(ds4, "InvoiceHeaderQuery")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport4 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport4 = CRXCustMTD_YTDInvoicesbyStateMonth1
            MyReport4.SetDataSource(ds4)
            MyReport4.PrintToPrinter(1, True, 1, 999) '
            con.Close()

            'Filter Dataset
            cmd5 = New SqlCommand("SELECT * FROM InvoiceHeaderQuery WHERE (DivisionID = @DivisionID OR DivisionID = @DivisionID2) AND InvoiceStatus <> 'BILL ONLY' AND InvoiceDate BETWEEN @BeginDate AND @EndDate", con)
            cmd5.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd5.Parameters.Add("@DivisionID2", SqlDbType.VarChar).Value = "TFP"
            cmd5.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginFiscalDate
            cmd5.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndFiscalDate

            If con.State = ConnectionState.Closed Then con.Open()
            ds5 = New DataSet()
            myAdapter5.SelectCommand = cmd5
            myAdapter5.Fill(ds5, "InvoiceHeaderQuery")
            con.Close()

            'Sets up viewer to display data from the loaded dataset
            Dim MyReport5 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport5 = CRXCustMTD_YTDInvoicesbyTerritoryMonth1
            MyReport5.SetDataSource(ds5)
            MyReport5.PrintToPrinter(1, True, 1, 999) '
            con.Close()

            'Update customer list - set hold for amy non-activity customers
            LoadCustomerList()

            'Delete Current Customer Hold Table
            cmd = New SqlCommand("DELETE FROM CustomerHoldList", con)

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Dim RowCustomer, RowDivision, RowCustomerName As String
            Dim TodaysDate As Date = Today()
            Dim strRevisedTodaysDate As String
            Dim RevisedTodaysDate As Date
            Dim GetSODate As Date
            Dim GetInvoiceDate As Date
            Dim DayOfDate, MonthOfDate, YearOfDate As Integer
            Dim strDayOfDate, strMonthOfDate, strYearOfDate As String

            DayOfDate = TodaysDate.Day
            MonthOfDate = TodaysDate.Month
            YearOfDate = (TodaysDate.Year - 1)
            strDayOfDate = CStr(DayOfDate)
            strMonthOfDate = CStr(MonthOfDate)
            strYearOfDate = CStr(YearOfDate)
            strRevisedTodaysDate = strMonthOfDate + "/" + strDayOfDate + "/" + strYearOfDate
            RevisedTodaysDate = CDate(strRevisedTodaysDate)

            For Each row As DataGridViewRow In dgvCustomerList.Rows
                Try
                    RowCustomer = row.Cells("CustomerIDColumn").Value
                Catch ex As System.Exception
                    RowCustomer = ""
                End Try
                Try
                    RowDivision = row.Cells("DivisionIDColumn").Value
                Catch ex As System.Exception
                    RowDivision = ""
                End Try
                Try
                    RowCustomerName = row.Cells("CustomerNameColumn").Value
                Catch ex As System.Exception
                    RowCustomerName = ""
                End Try

                'Get Last Activity Date
                Dim GetSODateString As String = "SELECT MAX(SalesOrderDate) FROM SalesOrderHeaderTable WHERE CustomerID = @CustomerID AND DivisionKey = @DivisionKey"
                Dim GetSODateCommand As New SqlCommand(GetSODateString, con)
                GetSODateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                GetSODateCommand.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = RowDivision

                Dim GetInvoiceDateString As String = "SELECT MAX(InvoiceDate) FROM InvoiceHeaderTable WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
                Dim GetInvoiceDateCommand As New SqlCommand(GetInvoiceDateString, con)
                GetInvoiceDateCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                GetInvoiceDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetSODate = CDate(GetSODateCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetSODate = "1/1/2009"
                End Try
                Try
                    GetInvoiceDate = CDate(GetInvoiceDateCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetInvoiceDate = "1/1/2009"
                End Try
                con.Close()

                If GetSODate < RevisedTodaysDate And GetInvoiceDate < RevisedTodaysDate Then
                    Dim MaxActivityDate As String = ""

                    If GetSODate > GetInvoiceDate Then
                        MaxActivityDate = GetSODate
                    Else
                        MaxActivityDate = GetInvoiceDate
                    End If

                    Try
                        'Put Customer on accounting hold
                        cmd = New SqlCommand("INSERT INTO CustomerHoldList (CustomerID, CustomerName, DivisionID, ActivityDate, PrintDate) Values (@CustomerID, @CustomerName, @DivisionID, @ActivityDate, @PrintDate)", con)

                        With cmd.Parameters
                            .Add("@CustomerID", SqlDbType.VarChar).Value = RowCustomer
                            .Add("@CustomerName", SqlDbType.VarChar).Value = RowCustomerName
                            .Add("@DivisionID", SqlDbType.VarChar).Value = RowDivision
                            .Add("@ActivityDate", SqlDbType.VarChar).Value = MaxActivityDate
                            .Add("@PrintDate", SqlDbType.VarChar).Value = Today()
                        End With

                        If con.State = ConnectionState.Closed Then con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        'After customer hold, post how many customers were placed on hold
                        ErrorDate = Today()
                        ErrorComment = "Customers placed on hold - " + RowCustomer
                        ErrorDivision = RowDivision
                        ErrorDescription = "Month End Reports - Customer Hold Routine"
                        ErrorReferenceNumber = "NONE"
                        ErrorUser = EmployeeLoginName

                        TFPErrorLogUpdate()

                        RowCustomer = ""
                        RowDivision = ""
                        RowCustomerName = ""
                    Catch ex As Exception
                        'Skip, for now
                    End Try
                Else
                    'Skip
                End If
            Next

            'Load Dataset
            LoadCustomerHoldList()

            Dim MyReport6 = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            MyReport6 = CRXMonthEndCustomerReport1
            MyReport6.SetDataSource(ds6)
            MyReport6.PrintToPrinter(1, True, 1, 999) '
            con.Close()

            lblPrinting.Text = ""
            cboMonth.SelectedIndex = -1
            cboYear.SelectedIndex = -1
        End If
    End Sub

    Public Sub DefineFiscalYear()
        Dim strFiscalYear As String = ""
        Dim FiscalYear As Integer = 0
        Dim CurrentYear As Integer = 0
        Dim StrCurrentMonth As String = ""
        Dim StrLastDayofMonth As String = ""
        Dim intCurrentMonth As Integer = 0

        CurrentMonth = cboMonth.Text
        CurrentYear = Val(cboYear.Text)

        Select Case CurrentMonth
            Case "January"
                intCurrentMonth = 1
                StrLastDayofMonth = "/31/"
            Case "February"
                intCurrentMonth = 2
                StrLastDayofMonth = "/28/"
            Case "March"
                intCurrentMonth = 3
                StrLastDayofMonth = "/31/"
            Case "April"
                intCurrentMonth = 4
                StrLastDayofMonth = "/30/"
            Case "May"
                intCurrentMonth = 5
                StrLastDayofMonth = "/31/"
            Case "June"
                intCurrentMonth = 6
                StrLastDayofMonth = "/30/"
            Case "July"
                intCurrentMonth = 7
                StrLastDayofMonth = "/31/"
            Case "August"
                intCurrentMonth = 8
                StrLastDayofMonth = "/31/"
            Case "September"
                intCurrentMonth = 9
                StrLastDayofMonth = "/30/"
            Case "October"
                intCurrentMonth = 10
                StrLastDayofMonth = "/31/"
            Case "November"
                intCurrentMonth = 11
                StrLastDayofMonth = "/30/"
            Case "December"
                intCurrentMonth = 12
                StrLastDayofMonth = "/31/"
            Case Else
                ValidMonth = "NO"
        End Select

        StrCurrentMonth = CStr(intCurrentMonth)

        If intCurrentMonth < 5 Then
            'Define Begin
            FiscalYear = CurrentYear - 1
            strFiscalYear = CStr(FiscalYear)

            BeginFiscalYear = strFiscalYear

            'Define End
            FiscalYear = CurrentYear
            strFiscalYear = CStr(FiscalYear)

            EndFiscalYear = strFiscalYear

            BeginFiscalDate = "05/01/" + BeginFiscalYear
            EndFiscalDate = StrCurrentMonth + StrLastDayofMonth + EndFiscalYear
        Else
            'Define Begin
            FiscalYear = CurrentYear
            strFiscalYear = CStr(FiscalYear)

            BeginFiscalYear = strFiscalYear

            'Define End
            FiscalYear = CurrentYear
            strFiscalYear = CStr(FiscalYear)

            EndFiscalYear = strFiscalYear

            BeginFiscalDate = "05/01/" + BeginFiscalYear
            EndFiscalDate = StrCurrentMonth + StrLastDayofMonth + EndFiscalYear
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class