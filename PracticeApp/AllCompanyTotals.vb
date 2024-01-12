Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class AllCompanyTotals
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL; Async = True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim con2 As SqlConnection = New SqlConnection("Data Source=TFP-SQL; Async = True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim con3 As SqlConnection = New SqlConnection("Data Source=TFP-SQL; Async = True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim con4 As SqlConnection = New SqlConnection("Data Source=TFP-SQL; Async = True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd2, cmd3, cmd4 As SqlCommand

    ''check for if the form has completed the loading. This is so that the functions don't get fired before the form is completely loaded
    Dim isLoaded = False
    ''saves the current date when the date time picker drop down is opened so that it cna be checked when the drop down is closed to see if the user changed the dates
    Dim currDate As Date
    ''this array of booleans is for seeing if the tab has already been loaded
    Dim dataLoaded As Boolean() = {True, False, False, False}
    ''Class to hold all the consignment ID, Name and Totals. Will also get all consignments from the table

    Private Class ConsignmentLine
        Public LineData As New Dictionary(Of String, ConsignmentData)
        Public Sub New(ByVal FOBs As List(Of String()))
            For Each fob As String() In FOBs
                LineData.Add(fob(0), New ConsignmentData(fob(1)))
            Next
        End Sub

        ''Clears the totals of all FOB
        Public Sub ClearTotals()
            For Each FOB As KeyValuePair(Of String, ConsignmentData) In LineData
                FOB.Value.Sales = 0
                FOB.Value.SalesTotals = 0
                FOB.Value.Shipments = 0
            Next
        End Sub
    End Class

    ''class to hold the name and totals of consignment.
    Public Class ConsignmentData
        Public FOBName As String
        Public Sales As Double
        Public Shipments As Double
        Public SalesTotals As Double
        Public Sub New(ByVal FName As String)
            FOBName = FName
        End Sub
    End Class

    ''variable that holds all consignment data
    Dim Consignments As New List(Of String())

    Public Sub New()
        InitializeComponent()

        Dim con5 As New SqlConnection("Data Source=TFP-SQL; Async = True;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
        Dim cmd5 As New SqlCommand("SELECT DISTINCT(FOBID), FOBName FROM FOBTable WHERE FOBID <> 'Medina' and FOBID <> 'Standard' ORDER BY FOBID", con5)

        If con5.State = ConnectionState.Closed Then con5.Open()
        Dim reader As SqlDataReader = cmd5.ExecuteReader()
        If reader.HasRows Then
            While reader.Read()
                Consignments.Add(New String() {reader.Item("FOBID"), reader.Item("FOBName")})
            End While
        End If
        reader.Close()
        con5.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub tabTotals_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabTotals.SelectedIndexChanged
        If isLoaded Then
            ''calls the function to load the visible data
            loadVisible()
        End If
    End Sub

    ''will load the visible tab, if the tab has been loaded already it iwll not load it again unless there was a date change in the date time picker or if the reload button is clicked
    Private Sub loadVisible()
        Select Case tabTotals.TabPages(tabTotals.SelectedIndex).Name
            Case "tabCompanyTotals"
                If dataLoaded(0) = False Then
                    clearCompanyTotals()
                    bgwkCompanyTotals.RunWorkerAsync(dtpDateSelection.Value)
                    ''sets to true to not load this tab again, unless new date picked or reload is clicked
                    dataLoaded(0) = True
                End If
            Case "tabMTDYTD"
                If dataLoaded(1) = False Then
                    clearMTDYTDTotals()
                    'MTD and YTD
                    bgwkLoadMTDYTD.RunWorkerAsync(dtpDateSelection.Value)
                    ''sets to true to not load this tab again, unless new date picked or reload is clicked
                    dataLoaded(1) = True
                End If
            Case "tabARAging"
                If dataLoaded(2) = False Then
                    clearAR()
                    'AR AGING Data
                    bgwkLoadARAging.RunWorkerAsync(dtpDateSelection.Value)
                    ''sets to true to not load this tab again, unless new date picked or reload is clicked
                    dataLoaded(2) = True
                End If
            Case "tabAPAging"
                If dataLoaded(3) = False Then
                    clearAP()
                    'AP AGING Data
                    bgwkAPAging.RunWorkerAsync(dtpDateSelection.Value)
                    ''sets to true to not load this tab again, unless new date picked or reload is clicked
                    dataLoaded(3) = True
                End If
            Case "tabConsignment"
                If dgvConsignmentTotals.Columns.Count = 0 Then
                    dgvConsignmentTotals.Columns.Add("Date", "Date")
                    For Each line As String() In Consignments
                        dgvConsignmentTotals.Columns.Add(line(0) + "Shipment", line(1) + " Shipment")
                        dgvConsignmentTotals.Columns.Add(line(0) + "Sales", line(1) + " Sales")
                    Next

                    LoadDivisionID()
                End If
        End Select
    End Sub

    Dim rs As New Resize

    Private Sub AllCompanyTotals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bgwkCompanyTotals.RunWorkerAsync(dtpDateSelection.Value)
        isLoaded = True
        'If EmployeeLoginName.Equals("REWORKMAN") Then
        'tabTotals.TabPages.RemoveByKey("tabARAging")
        'End If
        rs.FindAllControls(Me)
    End Sub

    Private Sub dtpDateSelection_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateSelection.DropDown
        currDate = dtpDateSelection.Value
    End Sub

    Private Sub dtpDateSelection_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateSelection.CloseUp
        If currDate <> dtpDateSelection.Value Then
            For i As Integer = 0 To 3
                dataLoaded(i) = False
            Next
            loadVisible()
            ''sets the current date variable to the new selected date
            currDate = dtpDateSelection.Value
        End If
    End Sub

    Private Sub bgwkAPAging_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkAPAging.DoWork
        Dim tempds As New DataSet()

        cmd4 = New SqlCommand("SELECT (DivisionTable.CompanyName + ' (' + DivisionTable.DivisionKey + ')') as Division, ROUND(ISNULL(Payments,0),2) as Payments, ROUND(ISNULL(Less30,0),2) as [Aging < 30], ROUND(ISNULL(Aging3145,0),2) as [Aging 31 - 45], ROUND(ISNULL(Aging4660,0),2) as [Aging 46 - 60], ROUND(ISNULL(Aging6190,0),2) as [Aging 61 - 90], ROUND(ISNULL(Aging90,0),2) as [Aging > 90], ROUND(ISNULL(Less30,0),2) + ROUND(ISNULL(Aging3145,0),2) + ROUND(ISNULL(Aging4660,0),2) + ROUND(ISNULL(Aging6190,0),2) + ROUND(ISNULL(Aging90,0),2) as [Company Aging Total], isnull(DaysSum,0) as DaysSum, isnull(DaysCount,0) as DaysCount, 0 as [Average Days To Pay] FROM (SELECT DivisionKey, CompanyName FROM DivisionTable WHERE DivisionTable.DivisionKey <> 'ADM' AND DivisionTable.DivisionKey <> 'TST') as DivisionTable LEFT OUTER JOIN (SELECT DivisionID, SUM(PaymentAmount) as Payments FROM APCheckQuery WHERE CheckDate = @PaymentDate GROUP BY DivisionID) as Payment ON DivisionTable.DivisionKey = Payment.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(AgingLessThan30) as Less30 FROM APAgingCategory GROUP BY DivisionID) as AgingLess30 ON DivisionTable.DivisionKey = AgingLess30.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(Aging31To45) as Aging3145 FROM APAgingCategory GROUP BY DivisionID) as Aging3145 ON DivisionTable.DivisionKey = Aging3145.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(Aging46To60) as Aging4660 FROM APAgingCategory GROUP BY DivisionID) as Aging4660 ON DivisionTable.DivisionKey = Aging4660.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(Aging61To90) as Aging6190 FROM APAgingCategory GROUP BY DivisionID) as Aging6190 ON DivisionTable.DivisionKey = Aging6190.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(AgingMoreThan90) as Aging90 FROM APAgingCategory GROUP BY DivisionID) as Aging90 ON DivisionTable.DivisionKey = Aging90.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(DaysElapsed) as DaysSum, COUNT(DaysElapsed) as DaysCount FROM VouchersDaysPaid GROUP BY DivisionID) as VouchersDaysPaid ON DivisionTable.DivisionKey = VouchersDaysPaid.DivisionID ORDER BY DivisionTable.DivisionKey", con4)
        cmd4.Parameters.Add("@CurrentDate", SqlDbType.Date).Value = Now
        cmd4.Parameters.Add("@PaymentDate", SqlDbType.Date).Value = dtpDateSelection.Value

        Dim adap As New SqlDataAdapter(cmd4)

        If con4.State = ConnectionState.Closed Then con4.Open()
        adap.Fill(tempds, "APAging")
        con.Close()

        Dim payments As Double = 0
        Dim less30 As Double = 0
        Dim aging31To45 As Double = 0
        Dim aging46To60 As Double = 0
        Dim aging61To90 As Double = 0
        Dim agingOver90 As Double = 0
        Dim averageDaysToPay As Double = 0
        Dim divisionCount As Integer = 0
        Dim TotalAgingTotal As Double = 0
        For i As Integer = 0 To tempds.Tables("APAging").Rows.Count - 1
            payments += tempds.Tables("APAging").Rows(i).Item("Payments")
            less30 += tempds.Tables("APAging").Rows(i).Item("Aging < 30")
            aging31To45 += tempds.Tables("APAging").Rows(i).Item("Aging 31 - 45")
            aging46To60 += tempds.Tables("APAging").Rows(i).Item("Aging 46 - 60")
            aging61To90 += tempds.Tables("APAging").Rows(i).Item("Aging 61 - 90")
            agingOver90 += tempds.Tables("APAging").Rows(i).Item("Aging > 90")
            If tempds.Tables("APAging").Rows(i).Item("DaysSum") <> 0 And tempds.Tables("APAging").Rows(i).Item("DaysCount") <> 0 Then
                tempds.Tables("APAging").Rows(i).Item("Average Days To Pay") = Math.Round(tempds.Tables("APAging").Rows(i).Item("DaysSum") / tempds.Tables("APAging").Rows(i).Item("DaysCount"), 0, MidpointRounding.AwayFromZero)
                averageDaysToPay += tempds.Tables("APAging").Rows(i).Item("DaysSum") / tempds.Tables("APAging").Rows(i).Item("DaysCount")
                divisionCount += 1
            End If
        Next
        TotalAgingTotal = less30 + aging31To45 + aging46To60 + aging61To90 + agingOver90
        tempds.Tables("APAging").Rows.Add("")
        tempds.Tables("APAging").Rows.Add("All Division Totals", payments, less30, aging31To45, aging46To60, aging61To90, agingOver90, TotalAgingTotal, 0, 0, Math.Round(averageDaysToPay / divisionCount, 0, MidpointRounding.AwayFromZero))

        e.Result = tempds
    End Sub

    Private Sub bgwkAPAging_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkAPAging.RunWorkerCompleted
        Dim tempds As DataSet = e.Result

        dgvAPAging.DataSource = tempds.Tables("APAging")
        dgvAPAging.Columns("Division").DefaultCellStyle.Font = New System.Drawing.Font(dgvCompanyTotals.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Bold, dgvCompanyTotals.DefaultCellStyle.Font.Unit)
        dgvAPAging.Columns("Payments").DefaultCellStyle.Format = "C2"
        dgvAPAging.Columns("Payments").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvAPAging.Columns("Payments").MinimumWidth = 50
        dgvAPAging.Columns("Aging < 30").DefaultCellStyle.Format = "C2"
        dgvAPAging.Columns("Aging < 30").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvAPAging.Columns("Aging < 30").MinimumWidth = 75
        dgvAPAging.Columns("Aging 31 - 45").DefaultCellStyle.Format = "C2"
        dgvAPAging.Columns("Aging 31 - 45").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvAPAging.Columns("Aging 46 - 60").DefaultCellStyle.Format = "C2"
        dgvAPAging.Columns("Aging 46 - 60").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvAPAging.Columns("Aging 61 - 90").DefaultCellStyle.Format = "C2"
        dgvAPAging.Columns("Aging 61 - 90").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvAPAging.Columns("Aging > 90").DefaultCellStyle.Format = "C2"
        dgvAPAging.Columns("Aging > 90").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvAPAging.Columns("Company Aging Total").DefaultCellStyle.Format = "C2"
        dgvAPAging.Columns("Company Aging Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvAPAging.Columns("DaysSum").Visible = False
        dgvAPAging.Columns("DaysCount").Visible = False
        dgvAPAging.Columns("Average Days To Pay").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub bgwkLoadARAging_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkLoadARAging.DoWork

        Dim tempds As New DataSet()

        Dim cmd3 As New SqlCommand("SELECT (DivisionTable.CompanyName + ' (' + DivisionTable.DivisionKey + ')') as Division, ROUND(ISNULL(PaymentsReceived,0),2) as [Payments Received], ROUND(ISNULL(AgingLessThan30,0),2) as [Aging < 30], ROUND(ISNULL(Aging31To45,0),2) as [Aging 31 - 45], ROUND(ISNULL(Aging46To60,0),2) as [Aging 46 - 60], ROUND(ISNULL(Aging61To90,0),2) as [Aging 61 - 90], ROUND(ISNULL(AgingMoreThan90,0),2) as [Aging > 90], ROUND(ISNULL(AgingLessThan30,0),2) + ROUND(ISNULL(Aging31To45,0),2) + ROUND(ISNULL(Aging46To60,0),2) + ROUND(ISNULL(Aging61To90,0),2) + ROUND(ISNULL(AgingMoreThan90,0),2) as [Company Aging Total], isnull(DaysSum,0) as DaysSum, isnull(DaysCount,0) as DaysCount, 0 as [Average Days Open] FROM(SELECT DivisionKey, CompanyName FROM DivisionTable WHERE DivisionTable.DivisionKey <> 'ADM' AND DivisionTable.DivisionKey <> 'TST') as DivisionTable LEFT OUTER JOIN (SELECT DivisionID,  SUM(PaymentAmount) as PaymentsReceived FROM ARCustomerPayment WHERE PaymentDate = @PaymentDate GROUP BY DivisionID) as Payments ON DivisionTable.DivisionKey = Payments.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(AgingLessThan30) as AgingLessThan30 FROM ARAgingCategory GROUP BY DivisionID) AS AgingLessThan30 ON DivisionTable.DivisionKey = AgingLessThan30.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(Aging31To45) as Aging31To45 FROM ARAgingCategory GROUP BY DivisionID) as Aging31To45 ON DivisionTable.DivisionKey = Aging31To45.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(Aging46To60) as Aging46To60 FROM ARAgingCategory GROUP BY DivisionID) as Aging46To60 ON DivisionTable.DivisionKey = Aging46To60.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(Aging61To90) as Aging61To90 FROM ARAgingCategory GROUP BY DivisionID) as Aging61To90 ON DivisionTable.DivisionKey = Aging61To90.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(AgingMoreThan90) as AgingMoreThan90 FROM ARAgingCategory GROUP BY DivisionID) as AgingMoreThan90 ON DivisionTable.DivisionKey = AgingMoreThan90.DivisionID  LEFT OUTER JOIN (SELECT DivisionID, SUM(DaysElapsed) as DaysSum, COUNT(DaysElapsed) as DaysCount FROM ReceivableDaysPaid GROUP BY DivisionID) as ReceivableDaysPaid ON DivisionTable.DivisionKey = ReceivableDaysPaid.DivisionID ORDER BY DivisionTable.DivisionKey", con3)
        cmd3.Parameters.Add("@CurrentDate", SqlDbType.Date).Value = Now
        cmd3.Parameters.Add("@PaymentDate", SqlDbType.Date).Value = dtpDateSelection.Value

        Dim adap As New SqlDataAdapter(cmd3)

        If con3.State = ConnectionState.Closed Then con3.Open()
        adap.Fill(tempds, "ARAging")
        con3.Close()

        Dim payments As Double = 0
        Dim less30 As Double = 0
        Dim aging31To45 As Double = 0
        Dim aging46To60 As Double = 0
        Dim aging61To90 As Double = 0
        Dim agingOver90 As Double = 0
        Dim averageDaysToPay As Double = 0
        Dim divisionCount As Integer = 0
        Dim TotalCompanyTotal As Double = 0

        For i As Integer = 0 To tempds.Tables("ARAging").Rows.Count - 1
            payments += tempds.Tables("ARAging").Rows(i).Item("Payments Received")
            less30 += tempds.Tables("ARAging").Rows(i).Item("Aging < 30")
            aging31To45 += tempds.Tables("ARAging").Rows(i).Item("Aging 31 - 45")
            aging46To60 += tempds.Tables("ARAging").Rows(i).Item("Aging 46 - 60")
            aging61To90 += tempds.Tables("ARAging").Rows(i).Item("Aging 61 - 90")
            agingOver90 += tempds.Tables("ARAging").Rows(i).Item("Aging > 90")
            If tempds.Tables("ARAging").Rows(i).Item("DaysSum") <> 0 And tempds.Tables("ARAging").Rows(i).Item("DaysCount") <> 0 Then
                tempds.Tables("ARAging").Rows(i).Item("Average Days Open") = Math.Round(tempds.Tables("ARAging").Rows(i).Item("DaysSum") / tempds.Tables("ARAging").Rows(i).Item("DaysCount"), 0, MidpointRounding.AwayFromZero)
                averageDaysToPay += tempds.Tables("ARAging").Rows(i).Item("DaysSum") / tempds.Tables("ARAging").Rows(i).Item("DaysCount")
                divisionCount += 1
            End If
        Next

        TotalCompanyTotal = less30 + aging31To45 + aging46To60 + aging61To90 + agingOver90
        tempds.Tables("ARAging").Rows.Add("")

        tempds.Tables("ARAging").Rows.Add("All Division Totals", payments, less30, aging31To45, aging46To60, aging61To90, agingOver90, TotalCompanyTotal, 0, 0, Math.Round(averageDaysToPay / divisionCount, 0, MidpointRounding.AwayFromZero))

        e.Result = tempds
    End Sub

    Private Sub bgwkLoadARAging_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkLoadARAging.RunWorkerCompleted
        Dim tempds As DataSet = e.Result

        dgvARAging.DataSource = tempds.Tables("ARAging")

        dgvARAging.Columns("Division").DefaultCellStyle.Font = New System.Drawing.Font(dgvCompanyTotals.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Bold, dgvCompanyTotals.DefaultCellStyle.Font.Unit)
        dgvARAging.Columns("Payments Received").DefaultCellStyle.Format = "C2"
        dgvARAging.Columns("Payments Received").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvARAging.Columns("Payments Received").MinimumWidth = 50
        dgvARAging.Columns("Aging < 30").DefaultCellStyle.Format = "C2"
        dgvARAging.Columns("Aging < 30").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvARAging.Columns("Aging < 30").MinimumWidth = 125
        dgvARAging.Columns("Aging 31 - 45").DefaultCellStyle.Format = "C2"
        dgvARAging.Columns("Aging 31 - 45").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvARAging.Columns("Aging 31 - 45").MinimumWidth = 125
        dgvARAging.Columns("Aging 46 - 60").DefaultCellStyle.Format = "C2"
        dgvARAging.Columns("Aging 46 - 60").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvARAging.Columns("Aging 46 - 60").MinimumWidth = 125
        dgvARAging.Columns("Aging 61 - 90").DefaultCellStyle.Format = "C2"
        dgvARAging.Columns("Aging 61 - 90").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvARAging.Columns("Aging 61 - 90").MinimumWidth = 125
        dgvARAging.Columns("Aging > 90").DefaultCellStyle.Format = "C2"
        dgvARAging.Columns("Aging > 90").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvARAging.Columns("Aging > 90").MinimumWidth = 125
        dgvARAging.Columns("Company Aging Total").DefaultCellStyle.Format = "C2"
        dgvARAging.Columns("Company Aging Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvARAging.Columns("DaysSum").Visible = False
        dgvARAging.Columns("DaysCount").Visible = False
        dgvARAging.Columns("Average Days Open").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        AddAverageDaysToPay()
    End Sub

    Public Sub AddAverageDaysToPay()
        Dim GetRowDivisionName As String = ""
        Dim GetRowDivision As String = ""
        Dim SumDaysElapsed As Double = 0
        Dim CountOfInvoices As Integer = 0
        Dim AverageDaysToPay As Double = 0
        Dim TotalDaysElapsed As Double = 0
        Dim CompanyDaysPaidAverage As Double = 0

        Try
            Me.dgvARAging.Columns.Remove("Average Days Paid")
        Catch ex As Exception
            'Skip()
        End Try

        Me.dgvARAging.Columns.Add("Average Days Paid", "Average Days Paid")

        Me.dgvARAging.Columns("Average Days Paid").Visible = True
        Me.dgvARAging.Columns("Average Days Paid").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        For Each LineRow As DataGridViewRow In dgvARAging.Rows
            Try
                GetRowDivisionName = LineRow.Cells("Division").Value
            Catch ex As System.Exception
                GetRowDivisionName = ""
            End Try

            'Define Division ID based on division name
            Select Case GetRowDivisionName
                Case "Tru-fit Products of Atlanta (ATL)"
                    GetRowDivision = "ATL"
                Case "Tru-fit Products of Nevada (CBS)"
                    GetRowDivision = "CBS"
                Case "Tru-fit Products of Indiana (CGO)"
                    GetRowDivision = "CGO"
                Case "Welding Ceramics LLC (CHT)"
                    GetRowDivision = "CHT"
                Case "Tru-fit Products of Denver (DEN)"
                    GetRowDivision = "DEN"
                Case "Tru-fit Products of Houston (HOU)"
                    GetRowDivision = "HOU"
                Case "Tru-fit Products of Utah (SLC)"
                    GetRowDivision = "SLC"
                Case "Tru-fit Products of Toronto (TOR)"
                    GetRowDivision = "TOR"
                Case "Tru-fit Fasteners & Supply, LTD (TFF)"
                    GetRowDivision = "TFF"
                Case "Tru-fit Products of Texas (TFT)"
                    GetRowDivision = "TFT"
                Case "Tru-fit Products of Medina (TFP)"
                    GetRowDivision = "TFP"
                Case "Tru-fit Products / Tru-Weld (TWD)"
                    GetRowDivision = "TWD"
                Case "Tru-Weld Equipment (TWE)"
                    GetRowDivision = "TWE"
                Case "Tru-fit Products of Alberta (ALB)"
                    GetRowDivision = "ALB"
                Case Else
                    GetRowDivision = ""
            End Select

            'Get Summation and count of table from query
            Dim GetDaysElapsedStatement As String = "SELECT SUM(DaysElapsed) FROM ARCustomerPaymentDaysElapsed WHERE DivisionID = @DivisionID"
            Dim GetDaysElapsedCommand As New SqlCommand(GetDaysElapsedStatement, con)
            GetDaysElapsedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetRowDivision

            Dim CountOfInvoicesStatement As String = "SELECT COUNT(InvoiceNumber) FROM ARCustomerPaymentDaysElapsed WHERE DivisionID = @DivisionID"
            Dim CountOfInvoicesCommand As New SqlCommand(CountOfInvoicesStatement, con)
            CountOfInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = GetRowDivision

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                SumDaysElapsed = CDbl(GetDaysElapsedCommand.ExecuteScalar)
            Catch ex As Exception
                SumDaysElapsed = 0
            End Try
            Try
                CountOfInvoices = CInt(CountOfInvoicesCommand.ExecuteScalar)
            Catch ex As Exception
                CountOfInvoices = 0
            End Try
            con.Close()

            AverageDaysToPay = SumDaysElapsed / CountOfInvoices
            AverageDaysToPay = Math.Round(AverageDaysToPay, 1)

            If GetRowDivision = "ATL" Or GetRowDivision = "CBS" Or GetRowDivision = "CGO" Or GetRowDivision = "CHT" Or GetRowDivision = "DEN" Or GetRowDivision = "HOU" Or GetRowDivision = "SLC" Or GetRowDivision = "TFF" Or GetRowDivision = "ALB" Or GetRowDivision = "TFT" Or GetRowDivision = "TWD" Or GetRowDivision = "TFP" Or GetRowDivision = "TOR" Or GetRowDivision = "TWE" Or GetRowDivision = "ALB" Then
                LineRow.Cells("Average Days Paid").Value = AverageDaysToPay
                TotalDaysElapsed = TotalDaysElapsed + AverageDaysToPay
            End If
        Next

        'Add cell value for company totals line
        CompanyDaysPaidAverage = TotalDaysElapsed / 13
        CompanyDaysPaidAverage = Math.Round(CompanyDaysPaidAverage, 1)
        Me.dgvARAging.Rows(14).Cells("Average Days Paid").Value = CompanyDaysPaidAverage
        CompanyDaysPaidAverage = 0
    End Sub

    Private Sub bgwkLoadMTDYTD_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkLoadMTDYTD.DoWork
        Dim currentDate As Date = dtpDateSelection.Value
        Dim YearStart As Date
        Dim YearEnd As Date
        Dim strMonthStart As String
        Dim MonthStart As Date
        Dim MonthEnd As Date = dtpDateSelection.Value
        Dim intMonth, intYear As Integer
        Dim strMonth, strYear As String

        intMonth = currentDate.Month
        intYear = currentDate.Year
        strMonth = CStr(intMonth)
        strYear = CStr(intYear)

        strMonthStart = strMonth + "/1/" + strYear
        MonthStart = CDate(strMonthStart)

        If currentDate.Month >= 5 Then
            YearStart = New Date(currentDate.Year, 5, 1)
            YearEnd = currentDate
        Else
            YearStart = New Date(currentDate.Year - 1, 5, 1)
            YearEnd = currentDate
        End If

        Dim tempds As New DataSet()
        Dim cmd2 As New SqlCommand("SELECT (DivisionTable.CompanyName + ' (' + DivisionTable.DivisionKey + ')') as Division, ROUND(ISNULL(MTDInvoiceTotal, 0), 2) as [MTD Invoices], ROUND(ISNULL(YTDInvoiceTotal, 0), 2) as [YTD Invoices], ROUND(ISNULL(MTDCashReceipts,0),2) as [MTD Cash Receipts], ROUND(ISNULL(YTDCashReceipts,0),2) as [YTD Cash Receipts], ROUND(ISNULL(MTDSales,0),2) as [MTD Orders], ROUND(ISNULL(YTDSales,0),2) as [YTD Orders], ROUND(ISNULL(MTDShipments,0),2) as [MTD Shipments], ROUND(ISNULL(YTDShipments,0),2) as [YTD Shipments], ROUND(ISNULL(MTDReturnTotal, 0),2) as [MTD Customer Returns], ROUND(ISNULL(YTDReturnTotal, 0),2) as [YTD Customer Returns] FROM (SELECT DivisionKey, CompanyName FROM DivisionTable WHERE DivisionTable.DivisionKey <> 'ADM' AND DivisionTable.DivisionKey <> 'TST') as DivisionTable LEFT OUTER JOIN (SELECT DivisionID, SUM(InvoiceTotal) as MTDInvoiceTotal FROM InvoiceHeaderTable WHERE InvoiceStatus <> 'BILL ONLY' AND InvoiceDate BETWEEN @MonthStart AND @MonthEnd GROUP BY DivisionID) as MTDInvoices ON DivisionTable.DivisionKey = MTDInvoices.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(InvoiceTotal) as YTDInvoiceTotal FROM InvoiceHeaderTable WHERE InvoiceStatus <> 'BILL ONLY' AND InvoiceDate BETWEEN @YearStart AND @YearEnd GROUP BY DivisionID) as YTDInvoices ON DivisionTable.DivisionKey = YTDInvoices.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(PaymentAmount) as MTDCashReceipts FROM ARCustomerPayment WHERE PaymentDate BETWEEN @MonthStart AND @MonthEnd GROUP BY DivisionID) as MTDCashReceipts ON DivisionTable.DivisionKey = MTDCashReceipts.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(PaymentAmount) as YTDCashReceipts FROM ARCustomerPayment WHERE PaymentDate BETWEEN @YearStart AND @YearEnd GROUP BY DivisionID) as YTDCashReceipts ON DivisionTable.DivisionKey = YTDCashReceipts.DivisionID LEFT OUTER JOIN (SELECT DivisionKey, SUM(SOTotal) as MTDSales FROM SalesOrderHeaderTable WHERE SOStatus <> 'QUOTE' AND SalesOrderDate BETWEEN @MonthStart AND @MonthEnd GROUP BY DivisionKey) as MTDSales ON DivisionTable.DivisionKey = MTDSales.DivisionKey LEFT OUTER JOIN (SELECT DivisionKey, SUM(SOTotal) as YTDSales FROM SalesOrderHeaderTable WHERE SOStatus <> 'QUOTE' AND SalesOrderDate BETWEEN @YearStart AND @YearEnd GROUP BY DivisionKey) AS YTDSales ON DivisionTable.DivisionKey = YTDSales.DivisionKey LEFT OUTER JOIN (SELECT DivisionID, SUM(ProductTotal) as MTDShipments FROM ShipmentHeaderTable WHERE ShipmentStatus <> 'PENDING' AND ShipDate BETWEEN @MonthStart AND @MonthEnd GROUP BY DivisionID) AS MTDShipment ON DivisionTable.DivisionKey = MTDShipment.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(ProductTotal) as YTDShipments FROM ShipmentHeaderTable WHERE ShipmentStatus <> 'PENDING' AND ShipDate BETWEEN @YearStart AND @YearEnd GROUP BY DivisionID) as YTDShipment ON DivisionTable.DivisionKey = YTDShipment.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(ReturnTotal) as MTDReturnTotal FROM ReturnProductHeaderTable WHERE ReturnDate BETWEEN @MonthStart AND @MonthEnd GROUP BY DivisionID) as MTDCustomerReturns On DivisionTable.DivisionKey = MTDCustomerReturns.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(ReturnTotal) as YTDReturnTotal FROM ReturnProductHeaderTable WHERE ReturnDate BETWEEN @YearStart AND @YearEnd GROUP BY DivisionID) as YTDCustomerReturns On DivisionTable.DivisionKey = YTDCustomerReturns.DivisionID ORDER BY DivisionTable.DivisionKey", con2)
        cmd2.Parameters.Add("@MonthStart", SqlDbType.Date).Value = MonthStart
        cmd2.Parameters.Add("@MonthEnd", SqlDbType.Date).Value = MonthEnd
        cmd2.Parameters.Add("@YearStart", SqlDbType.Date).Value = YearStart
        cmd2.Parameters.Add("@YearEnd", SqlDbType.Date).Value = YearEnd
        Dim adap As New SqlDataAdapter(cmd2)

        If con2.State = ConnectionState.Closed Then con2.Open()
        adap.Fill(tempds, "MTDYTDTotals")
        con.Close()

        Dim MTDInvoice As Double = 0
        Dim YTDInvoice As Double = 0
        Dim MTDCashReceipts As Double = 0
        Dim YTDCashReceipts As Double = 0
        Dim MTDSales As Double = 0
        Dim YTDSales As Double = 0
        Dim MTDShipments As Double = 0
        Dim YTDShipments As Double = 0
        Dim MTDReturns As Double = 0
        Dim YTDReturns As Double = 0

        For i As Integer = 0 To tempds.Tables("MTDYTDTotals").Rows.Count - 1
            MTDInvoice += tempds.Tables("MTDYTDTotals").Rows(i).Item("MTD Invoices")
            YTDInvoice += tempds.Tables("MTDYTDTotals").Rows(i).Item("YTD Invoices")
            MTDCashReceipts += tempds.Tables("MTDYTDTotals").Rows(i).Item("MTD Cash Receipts")
            YTDCashReceipts += tempds.Tables("MTDYTDTotals").Rows(i).Item("YTD Cash Receipts")
            MTDSales += tempds.Tables("MTDYTDTotals").Rows(i).Item("MTD Orders")
            YTDSales += tempds.Tables("MTDYTDTotals").Rows(i).Item("YTD Orders")
            MTDShipments += tempds.Tables("MTDYTDTotals").Rows(i).Item("MTD Shipments")
            YTDShipments += tempds.Tables("MTDYTDTotals").Rows(i).Item("YTD Shipments")
            MTDReturns += tempds.Tables("MTDYTDTotals").Rows(i).Item("MTD Customer Returns")
            YTDReturns += tempds.Tables("MTDYTDTotals").Rows(i).Item("YTD Customer Returns")
        Next

        tempds.Tables("MTDYTDTotals").Rows.Add("")
        tempds.Tables("MTDYTDTotals").Rows.Add("All Division Totals", MTDInvoice, YTDInvoice, MTDCashReceipts, YTDCashReceipts, MTDSales, YTDSales, MTDShipments, YTDShipments, MTDReturns, YTDReturns)

        e.Result = tempds
    End Sub

    Private Sub bgwkLoadMTDYTD_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkLoadMTDYTD.RunWorkerCompleted
        Dim tempds As DataSet = e.Result

        dgvMTDYTD.DataSource = tempds.Tables("MTDYTDTotals")
        dgvMTDYTD.Columns("Division").DefaultCellStyle.Font = New System.Drawing.Font(dgvCompanyTotals.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Bold, dgvCompanyTotals.DefaultCellStyle.Font.Unit)
        dgvMTDYTD.Columns("Division").Frozen = True
        dgvMTDYTD.Columns("MTD Invoices").DefaultCellStyle.Format = "C2"
        dgvMTDYTD.Columns("MTD Invoices").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgvMTDYTD.Columns("MTD Invoices").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMTDYTD.Columns("MTD Invoices").MinimumWidth = 90
        dgvMTDYTD.Columns("YTD Invoices").DefaultCellStyle.Format = "C2"
        dgvMTDYTD.Columns("YTD Invoices").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgvMTDYTD.Columns("YTD Invoices").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMTDYTD.Columns("YTD Invoices").MinimumWidth = 140
        dgvMTDYTD.Columns("MTD Orders").DefaultCellStyle.Format = "C2"
        dgvMTDYTD.Columns("MTD Orders").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMTDYTD.Columns("MTD Orders").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgvMTDYTD.Columns("MTD Orders").MinimumWidth = 115
        dgvMTDYTD.Columns("YTD Orders").DefaultCellStyle.Format = "C2"
        dgvMTDYTD.Columns("YTD Orders").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMTDYTD.Columns("YTD Orders").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgvMTDYTD.Columns("YTD Orders").MinimumWidth = 135
        dgvMTDYTD.Columns("MTD Shipments").DefaultCellStyle.Format = "C2"
        dgvMTDYTD.Columns("MTD Shipments").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMTDYTD.Columns("MTD Shipments").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgvMTDYTD.Columns("MTD Shipments").MinimumWidth = 120
        dgvMTDYTD.Columns("YTD Shipments").DefaultCellStyle.Format = "C2"
        dgvMTDYTD.Columns("YTD Shipments").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMTDYTD.Columns("YTD Shipments").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgvMTDYTD.Columns("YTD Shipments").MinimumWidth = 130
        dgvMTDYTD.Columns("MTD Customer Returns").DefaultCellStyle.Format = "C2"
        dgvMTDYTD.Columns("MTD Customer Returns").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMTDYTD.Columns("MTD Customer Returns").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgvMTDYTD.Columns("MTD Customer Returns").MinimumWidth = 100
        dgvMTDYTD.Columns("YTD Customer Returns").DefaultCellStyle.Format = "C2"
        dgvMTDYTD.Columns("YTD Customer Returns").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMTDYTD.Columns("YTD Customer Returns").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgvMTDYTD.Columns("YTD Customer Returns").MinimumWidth = 110
        dgvMTDYTD.Columns("MTD Cash Receipts").DefaultCellStyle.Format = "C2"
        dgvMTDYTD.Columns("MTD Cash Receipts").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMTDYTD.Columns("MTD Cash Receipts").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgvMTDYTD.Columns("MTD Cash Receipts").MinimumWidth = 120
        dgvMTDYTD.Columns("YTD Cash Receipts").DefaultCellStyle.Format = "C2"
        dgvMTDYTD.Columns("YTD Cash Receipts").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMTDYTD.Columns("YTD Cash Receipts").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        dgvMTDYTD.Columns("YTD Cash Receipts").MinimumWidth = 150
    End Sub

    Private Sub bgwkCompanyTotals_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwkCompanyTotals.DoWork
        Dim currentDate As Date = Convert.ToDateTime(e.Argument())
        Dim cmd = New SqlCommand("SELECT (DivisionTable.CompanyName + ' (' + DivisionTable.DivisionKey + ')') as Division, ROUND(ISNULL(SOTotal, 0),2) as [Sales Orders], ROUND(ISNULL(ShipmentTotal, 0), 2) as Shipments, ROUND(ISNULL(InvoiceTotal, 0), 2) as Invoices, ROUND(ISNULL(POTotal, 0), 2) as [Purch. Receipts] FROM DivisionTable LEFT OUTER JOIN (SELECT DivisionKey, SUM(SOTotal) as SOTotal FROM SalesOrderHeaderTable WHERE SalesOrderDate =  @CurrentDate AND SOStatus <> 'QUOTE' GROUP BY DivisionKey) as SalesOrderHeaderTable ON DivisionTable.DivisionKey = SalesOrderHeaderTable.DivisionKey LEFT OUTER JOIN (SELECT DivisionID, SUM(ProductTotal) as ShipmentTotal FROM ShipmentHeaderTable WHERE ShipmentStatus <> 'PENDING' AND ShipDate = @CurrentDate GROUP BY DivisionID) as ShipmentHeaderTable ON DivisionTable.DivisionKey = ShipmentHeaderTable.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(InvoiceTotal) as InvoiceTotal FROM InvoiceHeaderTable WHERE InvoiceStatus <> 'BILL ONLY' AND InvoiceDate = @CurrentDate GROUP BY DivisionID) as InvoiceHeaderTable ON DivisionTable.DivisionKey = InvoiceHeaderTable.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(POTotal) as POTotal FROM ReceivingHeaderTable WHERE ReceivingDate = @CurrentDate GROUP BY DivisionID) AS ReceivingHeaderTable ON DivisionTable.DivisionKey = ReceivingHeaderTable.DivisionID  WHERE DivisionTable.DivisionKey <> 'ADM' AND DivisionTable.DivisionKey <> 'TST' ORDER BY DivisionTable.DivisionKey", con)
        ''Dim cmd = New SqlCommand("SELECT (DivisionTable.CompanyName + ' (' + DivisionTable.DivisionKey + ')') as Division, ROUND(ISNULL(SOTotal, 0),2) as [Sales Orders], ROUND(ISNULL(ShipmentTotal, 0), 2) as Shipments, ROUND(ISNULL(InvoiceTotal, 0), 2) as Invoices, ROUND(ISNULL(POTotal, 0), 2) as [Purch. Receipts], ROUND(ISNULL(ExtendedCost, 0), 2) as [Inventory Value] FROM DivisionTable LEFT OUTER JOIN (SELECT DivisionKey, SUM(SOTotal) as SOTotal FROM SalesOrderHeaderTable WHERE SalesOrderDate =  @CurrentDate AND SOStatus <> 'QUOTE' GROUP BY DivisionKey) as SalesOrderHeaderTable ON DivisionTable.DivisionKey = SalesOrderHeaderTable.DivisionKey LEFT OUTER JOIN (SELECT DivisionID, SUM(ProductTotal) as ShipmentTotal FROM ShipmentHeaderTable WHERE ShipmentStatus <> 'PENDING' AND ShipDate = @CurrentDate GROUP BY DivisionID) as ShipmentHeaderTable ON DivisionTable.DivisionKey = ShipmentHeaderTable.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(InvoiceTotal) as InvoiceTotal FROM InvoiceHeaderTable WHERE InvoiceDate = @CurrentDate GROUP BY DivisionID) as InvoiceHeaderTable ON DivisionTable.DivisionKey = InvoiceHeaderTable.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(POTotal) as POTotal FROM ReceivingHeaderTable WHERE ReceivingDate = @CurrentDate GROUP BY DivisionID) AS ReceivingHeaderTable ON DivisionTable.DivisionKey = ReceivingHeaderTable.DivisionID LEFT OUTER JOIN (SELECT DivisionID, SUM(ExtendedCost) as ExtendedCost FROM (SELECT DivisionID, SUM(ExtendedCost) as ExtendedCost FROM InventoryTransactionTable WHERE TransactionDate <= @CurrentDate AND TransactionMath = 'ADD' AND DivisionID <> 'BCW' AND DivisionID <> 'DCW' AND DivisionID <> 'HCW' AND DivisionID <> 'LCW' AND DivisionID <> 'PCW' AND DivisionID <> 'SCW' AND DivisionID <> 'YCW' GROUP BY DivisionID UNION ALL SELECT DivisionID, SUM(-1 * ExtendedCost) FROM InventoryTransactionTable WHERE TransactionDate <= @CurrentDate AND TransactionMath = 'SUBTRACT' AND DivisionID <> 'BCW' AND DivisionID <> 'DCW' AND DivisionID <> 'HCW' AND DivisionID <> 'LCW' AND DivisionID <> 'PCW' AND DivisionID <> 'SCW' AND DivisionID <> 'YCW' GROUP BY DivisionID) as InventoryTotals GROUP BY DivisionID) AS InventoryTotals ON DivisionTable.DivisionKey = InventoryTotals.DivisionID WHERE DivisionTable.DivisionKey <> 'ADM' AND DivisionTable.DivisionKey <> 'TST' ORDER BY DivisionTable.DivisionKey", con)
        cmd.Parameters.Add("@CurrentDate", SqlDbType.Date).Value = currentDate

        Dim adap As New SqlDataAdapter(cmd)
        Dim tempds As New DataSet()
        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "DailyTotals")
        con.Close()

        Dim SOTotal As Double = 0
        Dim ShipmentTotal As Double = 0
        Dim InvoiceTotal As Double = 0
        Dim POTotal As Double = 0
        'Dim InvenTotal As Double = 0
        For i As Integer = 0 To tempds.Tables("DailyTotals").Rows.Count - 1
            SOTotal += tempds.Tables("DailyTotals").Rows(i).Item("Sales Orders")
            ShipmentTotal += tempds.Tables("DailyTotals").Rows(i).Item("Shipments")
            InvoiceTotal += tempds.Tables("DailyTotals").Rows(i).Item("Invoices")
            POTotal += tempds.Tables("DailyTotals").Rows(i).Item("Purch. Receipts")
            'InvenTotal += tempds.Tables("DailyTotals").Rows(i).Item("Inventory Value")
        Next
        tempds.Tables("DailyTotals").Rows.Add("")
        tempds.Tables("DailyTotals").Rows.Add("All Division Total", SOTotal, ShipmentTotal, InvoiceTotal, POTotal) ', InvenTotal)

        e.Result = tempds
    End Sub

    Private Sub bgwkCompanyTotals_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwkCompanyTotals.RunWorkerCompleted
        Dim tempds As DataSet = e.Result

        dgvCompanyTotals.DataSource = tempds.Tables("DailyTotals")
        dgvCompanyTotals.Columns("Division").DefaultCellStyle.Font = New System.Drawing.Font(dgvCompanyTotals.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Bold, dgvCompanyTotals.DefaultCellStyle.Font.Unit)
        dgvCompanyTotals.Columns("Sales Orders").DefaultCellStyle.Format = "C2"
        dgvCompanyTotals.Columns("Sales Orders").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompanyTotals.Columns("Shipments").DefaultCellStyle.Format = "C2"
        dgvCompanyTotals.Columns("Shipments").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompanyTotals.Columns("Invoices").DefaultCellStyle.Format = "C2"
        dgvCompanyTotals.Columns("Invoices").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompanyTotals.Columns("Purch. Receipts").DefaultCellStyle.Format = "C2"
        dgvCompanyTotals.Columns("Purch. Receipts").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'dgvCompanyTotals.Columns("Inventory Value").DefaultCellStyle.Format = "C2"
        'dgvCompanyTotals.Columns("Inventory Value").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub clearCompanyTotals()
        dgvCompanyTotals.DataSource = Nothing
    End Sub

    Private Sub clearMTDYTDTotals()
        dgvMTDYTD.DataSource = Nothing
    End Sub

    Private Sub clearAP()
        dgvAPAging.DataSource = Nothing
    End Sub

    Private Sub clearAR()
        dgvARAging.DataSource = Nothing
    End Sub

    Private Sub cmdReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReload.Click
        For i As Integer = 0 To 3
            dataLoaded(i) = False
        Next
        loadVisible()
    End Sub

    Private Sub cmdViewConsignment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewConsignment.Click
        dgvConsignmentTotals.Rows.Clear()

        Dim tempds As New DataSet()
        Dim adapter As New SqlDataAdapter()
        cmd = New SqlCommand("SELECT SUM(ExtendedCost) as TotalCost, ShipDate, CustomerClass FROM ConsignmentShippingTable WHERE ShipDate BETWEEN @StartDate AND @EndDate AND DivisionID = @DivisionID GROUP BY ShipDate, CustomerClass ORDER BY ShipDate", con)
        cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = dtpConsignmentStartDate.Value.Date
        cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpConsignmentEndDate.Value.Date
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        adapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        adapter.Fill(tempds, "ConsignmentShipments")

        cmd = New SqlCommand("SELECT SUM(ExtendedAmount) as TotalAmount, BillDate, CustomerClass FROM ConsignmentBillingTable WHERE BillDate BETWEEN @StartDate AND @EndDate AND DivisionID = @DivisionID GROUP BY BillDate, CustomerClass ORDER BY BillDate", con)
        cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = dtpConsignmentStartDate.Value.Date
        cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpConsignmentEndDate.Value.Date
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        adapter.SelectCommand = cmd

        adapter.Fill(tempds, "ConsignmentSales")
        con.Close()

        Dim SalesLine As Integer = 0
        Dim ShipLine As Integer = 0
        Dim currentDate As Date = dtpConsignmentStartDate.Value.Date
        Dim currentLine As New ConsignmentLine(Consignments)
        Dim ShipmentTotal As Double
        Dim SalesTotal As Double

        Dim totals As New ConsignmentLine(Consignments)
        While DateDiff(DateInterval.Day, currentDate, dtpConsignmentEndDate.Value.Date) >= 0
            Dim shipLineFound As Boolean = False
            Dim SalesLineFound As Boolean = False

            If ShipLine < tempds.Tables("ConsignmentShipments").Rows.Count Then
                While ShipLine < tempds.Tables("ConsignmentShipments").Rows.Count
                    If DateDiff(DateInterval.Day, tempds.Tables("ConsignmentShipments").Rows(ShipLine).Item("ShipDate"), currentDate) <> 0 Then
                        Exit While
                    End If

                    If currentLine.LineData.ContainsKey(tempds.Tables("ConsignmentShipments").Rows(ShipLine).Item("CustomerClass")) Then
                        currentLine.LineData(tempds.Tables("ConsignmentShipments").Rows(ShipLine).Item("CustomerClass")).Shipments += tempds.Tables("ConsignmentShipments").Rows(ShipLine).Item("TotalCost")
                        ShipmentTotal += tempds.Tables("ConsignmentShipments").Rows(ShipLine).Item("TotalCost")
                    End If

                    ShipLine += 1
                End While
            End If
            If SalesLine < tempds.Tables("ConsignmentSales").Rows.Count Then
                While SalesLine < tempds.Tables("ConsignmentSales").Rows.Count
                    If DateDiff(DateInterval.Day, tempds.Tables("ConsignmentSales").Rows(SalesLine).Item("BillDate"), currentDate) <> 0 Then
                        Exit While
                    End If

                    If currentLine.LineData.ContainsKey(tempds.Tables("ConsignmentSales").Rows(SalesLine).Item("CustomerClass")) Then
                        SalesTotal += tempds.Tables("ConsignmentSales").Rows(SalesLine).Item("TotalAmount")
                        currentLine.LineData(tempds.Tables("ConsignmentSales").Rows(SalesLine).Item("CustomerClass")).Sales += tempds.Tables("ConsignmentSales").Rows(SalesLine).Item("TotalAmount")
                        totals.LineData(tempds.Tables("ConsignmentSales").Rows(SalesLine).Item("CustomerClass")).SalesTotals += tempds.Tables("ConsignmentSales").Rows(SalesLine).Item("TotalAmount")
                    End If
                    SalesLine += 1
                End While
            End If

            Dim position As Integer = 1
            Dim parArray(Consignments.Count * 2 + 1) As Object
            parArray(0) = currentDate.ToShortDateString()
            For i As Integer = 0 To Consignments.Count - 1
                parArray(position) = currentLine.LineData(Consignments(i)(0)).Shipments
                parArray(position + 1) = currentLine.LineData(Consignments(i)(0)).Sales
                position += 2
            Next
            dgvConsignmentTotals.Rows.Add(parArray)
            currentLine = New ConsignmentLine(Consignments)
            currentDate = currentDate.AddDays(1)

        End While
        dgvConsignmentTotals.Rows.Add()
        Dim pos As Integer = 1
        Dim par(Consignments.Count * 2 + 1) As Object
        par(0) = "TOTALS"
        For i As Integer = 0 To Consignments.Count - 1
            par(pos) = ""
            par(pos + 1) = totals.LineData(Consignments(i)(0)).SalesTotals
            pos += 2
        Next
        dgvConsignmentTotals.Rows.Add(par)
        dgvConsignmentTotals.Columns(0).Frozen = True
        lblTotalConsignmentShipments.Text = FormatCurrency(ShipmentTotal)
        lblTotalConsignmentSales.Text = FormatCurrency(SalesTotal)

    End Sub

    Private Sub cmdClearConsignment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearConsignment.Click
        dgvConsignmentTotals.Rows.Clear()
        dtpConsignmentStartDate.Value = Today.Date
        dtpConsignmentEndDate.Value = Today.Date
        lblTotalConsignmentSales.Text = ""
        lblTotalConsignmentShipments.Text = ""
        cboDivisionID.Text = "TWD"
    End Sub

    Private Sub LoadDivisionID()
        cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey <> 'ADM'", con4)

        Dim tempds As New DataSet()
        Dim adap As New SqlDataAdapter(cmd)

        If con.State = ConnectionState.Closed Then con.Open()
        adap.Fill(tempds, "DivisionTable")
        con.Close()

        cboDivisionID.DisplayMember = "DivisionKey"
        cboDivisionID.DataSource = tempds.Tables("DivisionTable")
        cboDivisionID.Text = "TWD"
    End Sub

    Private Sub AllCompanyTotals_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub

    Private Sub dgvCompanyTotals_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompanyTotals.CellContentClick

    End Sub
End Class