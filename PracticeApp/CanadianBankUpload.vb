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
Imports System.Drawing
Imports System.Drawing.Printing
Public Class CanadianBankUpload
    Inherits System.Windows.Forms.Form

    Dim DateFilter, CompanyFilter As String
    Dim CountNumberOfChecks As Integer = 0
    Dim SumTotalAmountOfChecks As Double = 0

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub CanadianBankUpload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtVendorClass.Text = "CANADIAN"
        cboDivisionID.Text = "ALL"

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            gpxCreateFile.Enabled = True
            gpxFilterDatagrid.Enabled = True
            gpxReset.Enabled = True
            gpxTotals.Enabled = True
        Else
            gpxCreateFile.Enabled = False
            gpxFilterDatagrid.Enabled = False
            gpxReset.Enabled = False
            gpxTotals.Enabled = False
        End If
    End Sub

    Public Sub ShowDataByFilters()
        'Remove NULLS
        cmd = New SqlCommand("UPDATE APCheckLog SET UploadStatus = '' WHERE UploadStatus IS NULL", con)

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        If cboDivisionID.Text = "ALL" Then
            CompanyFilter = " AND (DivisionID = 'TFF' OR DivisionID = 'TOR' OR DivisionID = 'ALB')"
        ElseIf cboDivisionID.Text = "TOR" Then
            CompanyFilter = " AND DivisionID = 'TOR'"
        ElseIf cboDivisionID.Text = "TFF" Then
            CompanyFilter = " AND DivisionID = 'TFF'"
        ElseIf cboDivisionID.Text = "ALB" Then
            CompanyFilter = " AND DivisionID = 'ALB'"
        Else
            CompanyFilter = " AND DivisionID = 'ADM'"
        End If
        If chkDateRange.Checked = True Then
            DateFilter = " AND CheckDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        'Load by filters
        cmd = New SqlCommand("SELECT * FROM APCheckUpload WHERE VendorClass = @VendorClass AND UploadStatus <> 'UPLOADED' AND CheckType <> '' AND CheckType <> 'WHITE PAPER CHECK' AND CheckType <> 'STANDARD'" + CompanyFilter + DateFilter + " ORDER BY APBatchNumber", con)
        cmd.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "CANADIAN"
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Value
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Value
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APCheckUpload")
        dgvAPChecks.DataSource = ds.Tables("APCheckUpload")
        con.Close()

        LoadTotals()
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvAPChecks.DataSource = Nothing
    End Sub

    Public Sub LoadTotals()
        Dim RowCheckAmount As Double = 0
        Dim RowCounter As Integer = 0
        Dim RunningTotal As Double = 0
        Dim DatagridTotal As Double = 0
        Dim DatagridSelectedTotal As Double = 0
        Dim DatagridUnselectedTotal As Double = 0

        If cboDivisionID.Text = "ALL" Then
            CompanyFilter = " AND (DivisionID = 'TFF' OR DivisionID = 'TOR' OR DivisionID = 'ALB')"
        ElseIf cboDivisionID.Text = "TOR" Then
            CompanyFilter = " AND DivisionID = 'TOR'"
        ElseIf cboDivisionID.Text = "TFF" Then
            CompanyFilter = " AND DivisionID = 'TFF'"
        ElseIf cboDivisionID.Text = "ALB" Then
            CompanyFilter = " AND DivisionID = 'ALB'"
        Else
            CompanyFilter = " AND DivisionID = 'ADM'"
        End If
        If chkDateRange.Checked = True Then
            DateFilter = " AND CheckDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        'Get Grand Total of the datagrid
        Dim GetGrandTotalStatement As String = "SELECT SUM(CheckAmount) FROM APCheckUpload WHERE VendorClass = @VendorClass AND UploadStatus <> 'UPLOADED' AND CheckType <> '' AND CheckType <> 'WHITE PAPER CHECK' AND CheckType <> 'STANDARD'" + CompanyFilter + DateFilter
        Dim GetGrandTotalCommand As New SqlCommand(GetGrandTotalStatement, con)
        GetGrandTotalCommand.Parameters.Add("@VendorClass", SqlDbType.VarChar).Value = "CANADIAN"
        GetGrandTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Value
        GetGrandTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Value

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DatagridTotal = CDbl(GetGrandTotalCommand.ExecuteScalar)
        Catch ex As Exception
            DatagridTotal = 0
        End Try
        con.Close()

        If Me.dgvAPChecks.RowCount > 0 Then
            For Each LineRow As DataGridViewRow In Me.dgvAPChecks.Rows
                Dim LineCell As DataGridViewCheckBoxCell = LineRow.Cells("SelectedColumn")

                If LineCell.Value = "SELECTED" Then
                    Try
                        RowCheckAmount = LineRow.Cells("CheckAmountColumn").Value
                    Catch ex As Exception
                        RowCheckAmount = 0
                    End Try

                    RowCounter = RowCounter + 1
                    RunningTotal = RunningTotal + RowCheckAmount
                End If
            Next

            DatagridSelectedTotal = RunningTotal
            DatagridUnselectedTotal = DatagridTotal - DatagridSelectedTotal

            txtDatagridTotal.Text = FormatCurrency(DatagridTotal, 2)
            txtSelectedTotal.Text = FormatCurrency(DatagridSelectedTotal, 2)
            txtUnSelectedTotal.Text = FormatCurrency(DatagridUnselectedTotal, 2)

            SumTotalAmountOfChecks = DatagridSelectedTotal
            CountNumberOfChecks = RowCounter

            RowCounter = 0
            DatagridSelectedTotal = 0
            DatagridUnselectedTotal = 0
            DatagridTotal = 0
            RunningTotal = 0
        Else
            'Skip Update
            txtDatagridTotal.Text = FormatCurrency(0, 2)
            txtSelectedTotal.Text = FormatCurrency(0, 2)
            txtUnSelectedTotal.Text = FormatCurrency(0, 2)
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilters()
    End Sub

    Private Sub cmdClearFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearFilter.Click
        ClearDataInDatagrid()

        cboDivisionID.Text = "ALL"

        txtDatagridTotal.Clear()
        txtSelectedTotal.Clear()
        txtUnSelectedTotal.Clear()
        txtVendorClass.Text = "CANADIAN"

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False

        cboDivisionID.Focus()
    End Sub

    Private Sub cmdCreateFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateFile.Click
        'Carriage Return and Line Feed must be at the end of every record

        'Declare Constants
        Dim OriginatorID As String = "TPTFF90320"
        Dim CPACode As String = "460"
        Dim DueDate As Date = dtpUploadDate.Value
        Dim OriginatorShortName = "TFP CORPORATION"
        Dim FIIDTransitNumber As String = "000490320"
        Dim BankReturnAccount As String = "00005249260 "
        Dim FileCounter As String = ""

        'Create File Name
        Dim UploadDay, UploadYear, UploadMonth As Integer
        Dim strUploadDay, strUploadYear, strUploadMonth As String
        Dim strFileDate As String = ""

        UploadDay = DueDate.Day
        UploadMonth = DueDate.Month
        UploadYear = DueDate.Year

        If UploadDay < 10 Then
            strUploadDay = "0" + CStr(UploadDay)
        Else
            strUploadDay = CStr(UploadDay)
        End If
        If UploadMonth < 10 Then
            strUploadMonth = "0" + CStr(UploadMonth)
        Else
            strUploadMonth = CStr(UploadMonth)
        End If

        strUploadYear = CStr(UploadYear)

        strFileDate = strUploadMonth + strUploadDay + strUploadYear

        Dim strFileName As String = "CanadianUpload-" + strFileDate + ".csv"

        'Create Header Record
        Dim HeaderC01, HeaderC02, HeaderC03, HeaderC04, HeaderC05, HeaderC06, HeaderC07, HeaderC08, HeaderC09, HeaderC10, TotalHeaderLine As String

        '10 Columns
        '#1 - Record Type (1 Character)
        '#2 - Originator ID Number (10 Characters)-- Hardcoded from bank
        '#3 - Payment Type (1 Character)
        '#4 - CPA Code (3 Characters)
        '#5 - Due Date (6 Characters DDMMYY)
        '#6 - Originator Short Name (15 Characters)
        '#7 - FI ID / Transit # (9 Characters)
        '#8 - Account Number (12 Characters - 11 plus one space)
        '#9 - File Creation Number (4 Characters starting with 0001)
        '#10 - Filler (19 spaces)

        'Column One
        HeaderC01 = "H"

        'Column Two
        HeaderC02 = OriginatorID

        'Column Three
        HeaderC03 = "C"

        'Column Four
        HeaderC04 = CPACode

        'Column Five
        Dim DayOfDate, MonthOfDate, YearOfDate As Integer
        Dim strDayOfDate, strMonthOfDate, strYearOfDate As String
        Dim FormattedDueDate As String = ""

        DayOfDate = DueDate.Day
        MonthOfDate = DueDate.Month
        YearOfDate = DueDate.Year
        If DayOfDate < 10 Then
            strDayOfDate = "0" + CStr(DayOfDate)
        Else
            strDayOfDate = CStr(DayOfDate)
        End If
        If MonthOfDate < 10 Then
            strMonthOfDate = "0" + CStr(MonthOfDate)
        Else
            strMonthOfDate = CStr(MonthOfDate)
        End If
        strYearOfDate = CStr(YearOfDate)
        strYearOfDate = strYearOfDate.Substring(2, 2)

        FormattedDueDate = strDayOfDate + strMonthOfDate + strYearOfDate

        HeaderC05 = FormattedDueDate

        'Column Six
        HeaderC06 = OriginatorShortName

        'Column Seven
        HeaderC07 = FIIDTransitNumber

        'Column Eight
        HeaderC08 = BankReturnAccount

        'Column Nine
        'Get Next Number
        Dim NextFileNumber, LastFileNumber As Integer

        Dim MAXStatement As String = "SELECT MAX(ACHFileNumber) FROM ACHFileCounterTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastFileNumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As Exception
            LastFileNumber = 0
        End Try
        con.Close()

        NextFileNumber = LastFileNumber + 1

        FileCounter = CStr(NextFileNumber)

        If FileCounter.Length.Equals(4) Then
            'Do nothing
        ElseIf FileCounter.Length.Equals(3) Then
            FileCounter = "0" + FileCounter
        ElseIf FileCounter.Length.Equals(2) Then
            FileCounter = "00" + FileCounter
        ElseIf FileCounter.Length.Equals(1) Then
            FileCounter = "000" + FileCounter
        End If

        'Write to file number table to record used number
        cmd = New SqlCommand("INSERT INTO ACHFileCounterTable (ACHFileNumber, DivisionID) Values (@ACHFileNumber, @DivisionID)", con)

        With cmd.Parameters
            .Add("@ACHFileNumber", SqlDbType.VarChar).Value = NextFileNumber
            .Add("@DivisionID", SqlDbType.VarChar).Value = "TFF/TOR"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        HeaderC09 = FileCounter

        'Column Ten
        HeaderC10 = "                   "

        TotalHeaderLine = HeaderC01 + HeaderC02 + HeaderC03 + HeaderC04 + HeaderC05 + HeaderC06 + HeaderC07 + HeaderC08 + HeaderC09 + HeaderC10

        'Write Header Line to text file
        Dim sw As StreamWriter = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strFileName)

        sw.WriteLine(TotalHeaderLine)
        'sw.Close()
        '*************************************************************************************************************






        '*************************************************************************************************************
        Dim DetailC01, DetailC02, DetailC03, DetailC04, DetailC05, DetailC06, DetailC07 As String
        Dim TotalDetailLine As String = ""
        Dim InternalRecordID As String = ""
        Dim CheckNumber As Int64 = 0
        Dim strCheckNumber As String = ""
        Dim VendorID As String = ""
        Dim VendorName As String = ""
        Dim CheckDivision As String = ""
        Dim VendorAccountNumber As String = ""
        Dim CheckAmount As Double = 0
        Dim strCheckAmount As String = ""
        Dim PayeeName As String = ""
        Dim VendorNameCharacterCount As Integer = 0
        Dim BlankSpaceFiller As String = "                                     "
        Dim VendorTransitNumber As String = ""
        Dim VendorAccountCharacterCount As Integer = 0
        Dim VendorCheckAmountCharacterCount As Integer = 0
        Dim CountCharacters As Integer = 0
        Dim ZeroSpaceFiller As String = "00000000000000000000000000000000000000"

        'Create Detail Records
        '7 Columns
        '#1 - Record Type (1 Character - D for Detail)
        '#2 - Payee Name (Vendor) (23 Characters)
        '#3 - Payment Due Date (6 Characters DDMMYY)
        '#4 - Originator Reference # (19 Characters) -- TFP Check Number
        '#5 - FI ID / Transit Number (9 Characters)
        '#6 - Payee Account # (12 Characters)
        '#7 - Payment Amount (no ., no $, etc. - all numbers with leading zeros)(10 Characters)

        For Each LineRow As DataGridViewRow In Me.dgvAPChecks.Rows
            Dim LineCell As DataGridViewCheckBoxCell = LineRow.Cells("SelectedColumn")

            If LineCell.Value = "SELECTED" Then
                Try
                    CheckNumber = LineRow.Cells("CheckNumberColumn").Value
                Catch ex As Exception
                    CheckNumber = 1
                End Try
                Try
                    VendorID = LineRow.Cells("VendorIDColumn").Value
                Catch ex As Exception
                    VendorID = ""
                End Try
                Try
                    CheckAmount = LineRow.Cells("CheckAmountColumn").Value
                Catch ex As Exception
                    CheckAmount = 0
                End Try
                Try
                    CheckDivision = LineRow.Cells("DivisionIDColumn").Value
                Catch ex As Exception
                    CheckDivision = 0
                End Try
                '*******************************************************************
                'Get Vendor Name, Account Number
                Dim VendorNameStatement As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorNameCommand As New SqlCommand(VendorNameStatement, con)
                VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = VendorID
                VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CheckDivision

                Dim VendorAccountNumberStatement As String = "SELECT VendorAccountNumber FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorAccountNumberCommand As New SqlCommand(VendorAccountNumberStatement, con)
                VendorAccountNumberCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = VendorID
                VendorAccountNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CheckDivision

                Dim VendorTransitNumberStatement As String = "SELECT VendorRoutingNumber FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
                Dim VendorTransitNumberCommand As New SqlCommand(VendorTransitNumberStatement, con)
                VendorTransitNumberCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = VendorID
                VendorTransitNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CheckDivision

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    VendorName = CStr(VendorNameCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorName = ""
                End Try
                Try
                    VendorAccountNumber = CStr(VendorAccountNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorAccountNumber = ""
                End Try
                Try
                    VendorTransitNumber = CStr(VendorTransitNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    VendorTransitNumber = ""
                End Try
                con.Close()
                '***************************************************************
                'Column One
                DetailC01 = "D"
                '***************************************************************
                'Column Two
                VendorNameCharacterCount = VendorName.Length

                If VendorNameCharacterCount > 23 Then
                    PayeeName = VendorName.Substring(0, 23)
                ElseIf VendorNameCharacterCount = 23 Then
                    PayeeName = VendorName
                Else
                    PayeeName = VendorName + BlankSpaceFiller.Substring(0, 23 - VendorNameCharacterCount)
                End If

                DetailC02 = PayeeName
                '***************************************************************
                'Column Three
                DetailC03 = FormattedDueDate
                '***************************************************************
                'Column Four
                Dim CountCheckCharacters As Integer = 0
                strCheckNumber = CStr(CheckNumber)
                CountCheckCharacters = strCheckNumber.Length
                strCheckNumber = ZeroSpaceFiller.Substring(0, 19 - CountCheckCharacters) + strCheckNumber

                DetailC04 = strCheckNumber
                '***************************************************************
                'Column Five
                DetailC05 = VendorTransitNumber
                '***************************************************************
                'Column Six
                VendorAccountCharacterCount = VendorAccountNumber.Length

                DetailC06 = VendorAccountNumber + BlankSpaceFiller.Substring(0, 12 - VendorAccountCharacterCount)
                '***************************************************************
                'Column Seven
                strCheckAmount = CheckAmount.ToString("0.00")
                strCheckAmount = strCheckAmount.Replace(".", "")
                CountCharacters = strCheckAmount.Length
                strCheckAmount = ZeroSpaceFiller.Substring(0, 10 - CountCharacters) + strCheckAmount

                DetailC07 = strCheckAmount
                '***************************************************************
                TotalDetailLine = DetailC01 + DetailC02 + DetailC03 + DetailC04 + DetailC05 + DetailC06 + DetailC07

                sw.WriteLine(TotalDetailLine)
                '***************************************************************
                'Update Check Status to UPLOADED
                cmd = New SqlCommand("UPDATE APCheckLog SET UploadStatus = @UploadStatus WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@CheckNumber", SqlDbType.VarChar).Value = CheckNumber
                    .Add("@DivisionID", SqlDbType.VarChar).Value = CheckDivision
                    .Add("@UploadStatus", SqlDbType.VarChar).Value = "UPLOADED"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        '*************************************************************************************************************
        Dim TrailerC01, TrailerC02, TrailerC03, TrailerC04 As String
        Dim TotalTrailerLine As String = ""
        Dim CountPayments As Integer = 0
        Dim strCountPayment As String = ""
        Dim SumPayments As Double = 0
        Dim strSumPayments As String = ""

        'Create Trailer Record
        '4 Columns
        '#1 - Record Type (T for Trailer)
        '#2 - Total Number of payments (8 characters with leading zeros)
        '#3 - Total Value of payments (14 characters with leading zeros)
        '#4 - Filler (57 Spaces)
        '*********************************************************************
        LoadTotals()
        '*********************************************************************
        'Column One
        TrailerC01 = "T"
        '*********************************************************************
        'Column Two
        Dim CountNumberOfCharacters As Integer = 0
        strCountPayment = CStr(CountNumberOfChecks)

        CountNumberOfCharacters = strCountPayment.Length
        strCountPayment = ZeroSpaceFiller.Substring(0, 8 - CountNumberOfCharacters) + strCountPayment

        TrailerC02 = strCountPayment
        '*********************************************************************
        'Column Three
        Dim CountNumberOfCharacters2 As Integer = 0
        strSumPayments = SumTotalAmountOfChecks.ToString("0.00")
        strSumPayments = strSumPayments.Replace(".", "")
        CountNumberOfCharacters2 = strSumPayments.Length
        strSumPayments = ZeroSpaceFiller.Substring(0, 14 - CountNumberOfCharacters2) + strSumPayments

        TrailerC03 = strSumPayments
        '*********************************************************************
        'Column Four
        TrailerC04 = "                                                         "
        '*********************************************************************
        TotalTrailerLine = TrailerC01 + TrailerC02 + TrailerC03 + TrailerC04

        sw.WriteLine(TotalTrailerLine)
        sw.Close()
        '*********************************************************************
        MsgBox("File has been created.", MsgBoxStyle.OkOnly)

        cmdClearFilter_Click(sender, e)
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Dim PrintSetting As New PageSettings
        Dim PrinterFont As New Font("Arial", 10)

        With PrintSetting
            .Margins.Left = 50
            .Margins.Right = 50
            .Margins.Top = 50
            .Margins.Bottom = 50
        End With










    End Sub

    Private Sub dgvAPChecks_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAPChecks.CellValueChanged
        LoadTotals()
    End Sub

    Private Sub dgvAPChecks_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAPChecks.CurrentCellDirtyStateChanged
        If dgvAPChecks.IsCurrentCellDirty Then
            dgvAPChecks.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        If txtCheckNumber.Text <> "" Then
            Dim ValidateCheckNumber As Int64 = 0

            'Check if check exists and is set as uploaded
            Dim ValidateCheckNumberStatement As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE CheckNumber = @CheckNumber AND UploadStatus = @UploadStatus"
            Dim ValidateCheckNumberCommand As New SqlCommand(ValidateCheckNumberStatement, con)
            ValidateCheckNumberCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = Val(txtCheckNumber.Text)
            ValidateCheckNumberCommand.Parameters.Add("@UploadStatus", SqlDbType.VarChar).Value = "UPLOADED"

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                ValidateCheckNumber = CInt(ValidateCheckNumberCommand.ExecuteScalar)
            Catch ex As Exception
                ValidateCheckNumber = 0
            End Try
            con.Close()

            If ValidateCheckNumber = 1 Then
                'Continue
                Dim button As DialogResult = MessageBox.Show("Do you wish to reset this check to be uploaded?", "RESET CHECK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If button = DialogResult.Yes Then
                    'Update Check Status to UPLOADED
                    cmd = New SqlCommand("UPDATE APCheckLog SET UploadStatus = @UploadStatus WHERE CheckNumber = @CheckNumber", con)

                    With cmd.Parameters
                        .Add("@CheckNumber", SqlDbType.VarChar).Value = Val(txtCheckNumber.Text)
                        .Add("@UploadStatus", SqlDbType.VarChar).Value = ""
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                ElseIf button = DialogResult.No Then
                    Exit Sub
                End If
            Else
                MsgBox("Check # does not exist or is not uploaded.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
    End Sub
End Class