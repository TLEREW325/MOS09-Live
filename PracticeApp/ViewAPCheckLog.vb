Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.IO.TextReader
Imports System.IO.StreamReader
Imports System.Data
Imports System.Data.OleDb
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Net.Mail
Imports System.Web
Public Class ViewAPCheckLog
    Inherits System.Windows.Forms.Form

    Dim AutoprintBatchReport = New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim AutoprintCheckRemittance = New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Dim strCSVFileName As String = ""
    Dim strCSVFileNameATL, strCSVFileNameCBS, strCSVFileNameCGO, strCSVFileNameCHT, strCSVFileNameDEN, strCSVFileNameHOU, strCSVFileNameSLC, strCSVFileNameTFF, strCSVFileNameALB, strCSVFileNameTFT, strCSVFileNameTWD, strCSVFileNameTWE, strCSVFileNameTOR As String

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""
    Dim ExcelFileName As String = ""
    Dim PaidDateFilter, DivisionFilter, VendorFilter, BatchFilter, DateFilter, ClassFilter, CheckTypeFilter As String
    Dim BatchNumber As Int64
    Dim strBatchNumber As String
    Dim CheckTotal As Double
    Dim VendorName As String
    Dim PaidDate As Date
    Dim strPaidDate As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=45")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, APReportDataset As DataSet
    Dim dt As DataTable

    Private Sub ViewAPCheckLog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
        ClearVariables()
    End Sub

    Private Sub ViewAPCheckLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        If EmployeeLoginName = "HRYAN" Or EmployeeLoginName = "KPREST" Or EmployeeLoginName = "RMONTEVECCHIO" Or EmployeeSecurityCode = 1002 Or EmployeeSecurityCode = 1001 Then
            gpxReprint.Enabled = True
            gpxExport.Enabled = True
            cboDivisionID.Enabled = True
        Else
            gpxReprint.Enabled = False
            gpxExport.Enabled = False
        End If
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvAPCheckLog.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboAPBatchNumber.Text <> "" Then
            BatchNumber = Val(cboAPBatchNumber.Text)
            strBatchNumber = CStr(BatchNumber)
            BatchFilter = " AND APBatchNumber = '" + strBatchNumber + "'"
        Else
            BatchFilter = ""
        End If
        If cboVendorClass.Text <> "" Then
            ClassFilter = " AND VendorClass = '" + cboVendorClass.Text + "'"
        Else
            ClassFilter = ""
        End If
        If chkACH.Checked = True And chkStandard.Checked = True Then
            CheckTypeFilter = ""
        ElseIf chkACH.Checked = False And chkStandard.Checked = False Then
            CheckTypeFilter = ""
        ElseIf chkACH.Checked = True And chkStandard.Checked = False Then
            CheckTypeFilter = " AND CheckType <> 'STANDARD'"
        ElseIf chkACH.Checked = False And chkStandard.Checked = True Then
            CheckTypeFilter = " AND CheckType = 'STANDARD'"
        Else
            CheckTypeFilter = ""
        End If
        If cboDivisionID.Text = "ADM" Then
            DivisionFilter = " AND DivisionID <> 'ADM'"
        Else
            DivisionFilter = " AND DivisionID = '" + cboDivisionID.Text + "'"
        End If
        If chkDateRange.Checked = True Then
            DateFilter = " AND CheckDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM APCheckUpload WHERE CheckNumber <> 0" + DivisionFilter + VendorFilter + BatchFilter + ClassFilter + CheckTypeFilter + DateFilter + " ORDER BY VendorID", con)
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        'cmd.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "CANCELLED"

        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APCheckUpload")
        dgvAPCheckLog.DataSource = ds.Tables("APCheckUpload")
        con.Close()

        FormatDatagrid()
    End Sub

    Public Sub FormatDatagrid()
        Dim CheckType As String = ""

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvAPCheckLog.Rows
            Try
                CheckType = row.Cells("CheckTypeColumn").Value
            Catch ex As System.Exception
                CheckType = ""
            End Try

            If CheckType = "STANDARD" Then
                Me.dgvAPCheckLog.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Else
                Me.dgvAPCheckLog.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub LoadBatchNumber()
        cmd = New SqlCommand("SELECT DISTINCT APBatchNumber FROM APCheckUpload WHERE DivisionID = @DivisionID ORDER BY APBatchNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "APCheckUpload")
        cboAPBatchNumber.DataSource = ds1.Tables("APCheckUpload")
        con.Close()
        cboAPBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorID()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "Vendor")
        cboVendorID.DataSource = ds2.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorClass()
        Dim ClassMode As String

        If cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "ALB" Then
            ClassMode = "CANADIAN"
        Else
            ClassMode = "STANDARD"
        End If

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

    Public Sub LoadVendorName()
        Dim VendorNameString As String = "SELECT VendorName FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim VendorNameCommand As New SqlCommand(VendorNameString, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            VendorName = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            VendorName = ""
        End Try
        con.Close()

        txtVendorName.Text = VendorName
    End Sub

    Public Sub LoadCheckTotalByFilters()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboAPBatchNumber.Text <> "" Then
            BatchNumber = Val(cboAPBatchNumber.Text)
            strBatchNumber = CStr(BatchNumber)
            BatchFilter = " AND APBatchNumber = '" + strBatchNumber + "'"
        Else
            BatchFilter = ""
        End If
        If cboVendorClass.Text <> "" Then
            ClassFilter = " AND VendorClass = '" + cboVendorClass.Text + "'"
        Else
            ClassFilter = ""
        End If
        If chkACH.Checked = True And chkStandard.Checked = True Then
            CheckTypeFilter = ""
        ElseIf chkACH.Checked = False And chkStandard.Checked = False Then
            CheckTypeFilter = ""
        ElseIf chkACH.Checked = True And chkStandard.Checked = False Then
            CheckTypeFilter = " AND CheckType <> 'STANDARD'"
        ElseIf chkACH.Checked = False And chkStandard.Checked = True Then
            CheckTypeFilter = " AND CheckType = 'STANDARD'"
        Else
            CheckTypeFilter = ""
        End If
        If cboDivisionID.Text = "ADM" Then
            DivisionFilter = " AND DivisionID <> 'ADM'"
        Else
            DivisionFilter = " AND DivisionID = '" + cboDivisionID.Text + "'"
        End If
        If chkDateRange.Checked = True Then
            DateFilter = " AND CheckDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If


        Dim CheckTotalByFilterString As String = "SELECT SUM(CheckAmount) FROM APCheckUpload WHERE CheckStatus <> @CheckStatus" + DivisionFilter + VendorFilter + BatchFilter + ClassFilter + CheckTypeFilter + DateFilter
        Dim CheckTotalByFilterCommand As New SqlCommand(CheckTotalByFilterString, con)
        CheckTotalByFilterCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        CheckTotalByFilterCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        CheckTotalByFilterCommand.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "CANCELLED"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CheckTotal = CDbl(CheckTotalByFilterCommand.ExecuteScalar)
        Catch ex As Exception
            CheckTotal = 0
        End Try
        con.Close()

        txtCheckTotal.Text = FormatCurrency(CheckTotal, 2)
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadBatchNumber()
        LoadVendorID()
        LoadVendorClass()
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
        LoadCheckTotalByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Public Sub ClearData()
        cboVendorID.SelectedIndex = -1
        cboAPBatchNumber.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        txtCheckTotal.Clear()
        txtVendorName.Clear()

        chkACH.Checked = False
        chkStandard.Checked = False
        chkDateRange.Checked = False

        cboVendorID.Focus()
    End Sub

    Public Sub ClearVariables()
        VendorFilter = ""
        BatchFilter = ""
        DateFilter = ""
        ClassFilter = ""
        BatchNumber = 0
        strBatchNumber = ""
        CheckTotal = 0
        VendorName = ""
        GlobalAPBatchNumber = 0
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        GlobalAPBatchNumber = 0

        Using NewPrintAPCheckLog As New PrintAPCheckLog
            Dim Result = NewPrintAPCheckLog.ShowDialog()
        End Using
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        GDS = ds
        Using NewPrintAPCheckLog As New PrintAPCheckLog
            Dim Result = NewPrintAPCheckLog.ShowDialog()
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

    Private Sub cmdReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprint.Click
        Dim RowCheckNumber As Int64 = 0
        Dim RowDivision As String = ""
        Dim RowVendorClass As String = ""
        Dim RowStatus As String = ""
        Dim RowCheckAmount As Double = 0
        Dim RowCheckType As String = ""

        Dim RowIndex As Integer = Me.dgvAPCheckLog.CurrentCell.RowIndex
        RowCheckNumber = Me.dgvAPCheckLog.Rows(RowIndex).Cells("CheckNumberColumn").Value
        RowDivision = Me.dgvAPCheckLog.Rows(RowIndex).Cells("DivisionIDColumn").Value
        RowVendorClass = Me.dgvAPCheckLog.Rows(RowIndex).Cells("VendorClassColumn").Value
        RowStatus = Me.dgvAPCheckLog.Rows(RowIndex).Cells("CheckStatusColumn").Value
        RowCheckAmount = Me.dgvAPCheckLog.Rows(RowIndex).Cells("CheckAmountColumn").Value
        RowCheckType = Me.dgvAPCheckLog.Rows(RowIndex).Cells("CheckTypeColumn").Value

        'Ask the question
        Dim button As DialogResult = MessageBox.Show("Do you wish to reprint this check?", "TFP CORP CHECK PRINTING", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            If RowStatus <> "POSTED" Then
                MsgBox("You can only reprint a posted check.", MsgBoxStyle.OkOnly)
                Exit Sub
            Else
                'Continue
            End If

            'If RowCheckType <> "STANDARD" Then
            '    MsgBox("You cannot reprint an ACH as a check.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'Else
            '    'Continue
            'End If

            'Validate division and vendor class (for MICR Check)
            'If (RowDivision = "TFF" Or RowDivision = "TOR") And RowVendorClass = "CANADIAN" Then
            '    MsgBox("This is not a MICR Check. You cannot reprint.", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'Else
            '    'Continnue
            'End If

            'Write to Audit Trail Table
            Dim AuditComment As String = ""
            Dim AuditCheckNumber As Int64 = 0
            Dim strCheckNumber As String = ""

            AuditCheckNumber = RowCheckNumber
            strCheckNumber = CStr(AuditCheckNumber)
            AuditComment = "Check # " + strCheckNumber + " was reprinted by " + EmployeeLoginName

            Try
                cmd = New SqlCommand("INSERT INTO AuditTrail (AuditDate, UserID, AuditType, AuditAmount, AuditReferenceNumber, AuditComment, DivisionID) values (@AuditDate, @UserID, @AuditType, @AuditAmount, @AuditReferenceNumber, @AuditComment, @DivisionID)", con)

                With cmd.Parameters
                    .Add("@AuditDate", SqlDbType.VarChar).Value = Today()
                    .Add("@UserID", SqlDbType.VarChar).Value = EmployeeLoginName
                    .Add("@AuditType", SqlDbType.VarChar).Value = "REPRINT AP CHECK"
                    .Add("@AuditAmount", SqlDbType.VarChar).Value = RowCheckAmount
                    .Add("@AuditReferenceNumber", SqlDbType.VarChar).Value = strCheckNumber
                    .Add("@AuditComment", SqlDbType.VarChar).Value = AuditComment
                    .Add("@DivisionID", SqlDbType.VarChar).Value = EmployeeCompanyCode
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

            End Try

            GlobalAPCheckNumber = RowCheckNumber
            GlobalDivisionCode = cboDivisionID.Text
            GlobalAPCheckType = RowVendorClass

            Using NewReprintSingleAPCheck As New PrintSingleAPCheck
                Dim Result = NewReprintSingleAPCheck.ShowDialog()
            End Using
        ElseIf button = DialogResult.No Then
            Exit Sub
        End If
    End Sub

    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
        If Me.dgvAPCheckLog.RowCount > 0 Then
            WriteToCSVFile()
        Else
            MsgBox("There is no line data in grid.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Public Sub WriteToCSVFile()
        'Data has to exist in the datagrid
        If Me.dgvAPCheckLog.RowCount = 0 Then
            MsgBox("Data has to exist in the datagrid.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '*********************************************************************************
        If cboDivisionID.Text = "ADM" Then
            'Create upload file for each division
            Dim CheckNumber As Int64 = 0
            Dim CheckDate As Date
            Dim CheckPayee As String = ""
            Dim CheckAmount As Double = 0
            Dim CheckDivisionID As String = ""
            Dim CheckAccountNumber As String = ""
            Dim strCheckNumber, strCheckAmount, strCheckDate As String
            Dim CheckPayeeName As String = ""

            'Create Filename
            Dim MinuteDate As Date = Now()
            Dim TodaysDate As Date = Today()
            Dim strDay, strMonth, strYear, strMinute, strHour As String
            Dim intDay, intMonth, intYear, intMinute, intHour As Integer

            intDay = TodaysDate.Day
            intMonth = TodaysDate.Month
            intYear = TodaysDate.Year
            intMinute = MinuteDate.Minute
            intHour = MinuteDate.Hour

            strDay = CStr(intDay)
            strMonth = CStr(intMonth)
            strYear = CStr(intYear)
            strMinute = CStr(intMinute)
            strHour = CStr(intHour)

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

            'Check to see if any divisions have no checks
            Dim CountALB, CountATL, CountCBS, CountCGO, CountCHT, CountHOU, CountDEN, CountSLC, CountTFF, CountTFT, CountTWD, CountTWE, CountTOR As Integer

            Dim ATLsw As StreamWriter
            Dim CBSsw As StreamWriter
            Dim CGOsw As StreamWriter
            Dim CHTsw As StreamWriter
            Dim DENsw As StreamWriter
            Dim HOUsw As StreamWriter
            Dim SLCsw As StreamWriter
            Dim TFFsw As StreamWriter
            Dim TFTsw As StreamWriter
            Dim TWDsw As StreamWriter
            Dim TWEsw As StreamWriter
            Dim TORsw As StreamWriter
            Dim ALBsw As StreamWriter

            'Create File for ATL
            Dim CountATLString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountATLCommand As New SqlCommand(CountATLString, con)
            CountATLCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ATL"
            CountATLCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountATL = CInt(CountATLCommand.ExecuteScalar)
            Catch ex As Exception
                CountATL = 0
            End Try
            con.Close()

            If CountATL = 0 Then
                'Skip creating file
            Else
                strCSVFileNameATL = "ATL-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                ATLsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameATL)
                ATLsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Create File for CBS
            Dim CountCBSString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountCBSCommand As New SqlCommand(CountCBSString, con)
            CountCBSCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CBS"
            CountCBSCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountCBS = CInt(CountCBSCommand.ExecuteScalar)
            Catch ex As Exception
                CountCBS = 0
            End Try
            con.Close()

            If CountCBS = 0 Then
                'Skip creating file
            Else
                strCSVFileNameCBS = "CBS-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                CBSsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameCBS)
                CBSsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Create File for CGO
            Dim CountCGOString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountCGOCommand As New SqlCommand(CountCGOString, con)
            CountCGOCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CGO"
            CountCGOCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountCGO = CInt(CountCGOCommand.ExecuteScalar)
            Catch ex As Exception
                CountCGO = 0
            End Try
            con.Close()

            If CountCGO = 0 Then
                'Skip creating file
            Else
                strCSVFileNameCGO = "CGO-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                CGOsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameCGO)
                CGOsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Create File for CHT
            Dim CountCHTString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountCHTCommand As New SqlCommand(CountCHTString, con)
            CountCHTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "CHT"
            CountCHTCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountCHT = CInt(CountCHTCommand.ExecuteScalar)
            Catch ex As Exception
                CountCHT = 0
            End Try
            con.Close()

            If CountCHT = 0 Then
                'Skip creating file
            Else
                strCSVFileNameCHT = "CHT-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                CHTsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameCHT)
                CHTsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Create File for DEN
            Dim CountDENString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountDENCommand As New SqlCommand(CountDENString, con)
            CountDENCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "DEN"
            CountDENCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountDEN = CInt(CountDENCommand.ExecuteScalar)
            Catch ex As Exception
                CountDEN = 0
            End Try
            con.Close()

            If CountDEN = 0 Then
                'Skip creating file
            Else
                strCSVFileNameDEN = "DEN-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                DENsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameDEN)
                DENsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Create File for HOU
            Dim CountHOUString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountHOUCommand As New SqlCommand(CountHOUString, con)
            CountHOUCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "HOU"
            CountHOUCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountHOU = CInt(CountHOUCommand.ExecuteScalar)
            Catch ex As Exception
                CountHOU = 0
            End Try
            con.Close()

            If CountHOU = 0 Then
                'Skip creating file
            Else
                strCSVFileNameHOU = "HOU-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                HOUsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameHOU)
                HOUsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Create File for SLC
            Dim CountSLCString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountSLCCommand As New SqlCommand(CountSLCString, con)
            CountSLCCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "SLC"
            CountSLCCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountSLC = CInt(CountSLCCommand.ExecuteScalar)
            Catch ex As Exception
                CountSLC = 0
            End Try
            con.Close()

            If CountSLC = 0 Then
                'Skip creating file
            Else
                strCSVFileNameSLC = "SLC-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                SLCsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameSLC)
                SLCsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Create File for TFF
            Dim CountTFFString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountTFFCommand As New SqlCommand(CountTFFString, con)
            CountTFFCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFF"
            CountTFFCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountTFF = CInt(CountTFFCommand.ExecuteScalar)
            Catch ex As Exception
                CountTFF = 0
            End Try
            con.Close()

            If CountTFF = 0 Then
                'Skip creating file
            Else
                strCSVFileNameTFF = "TFF-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                TFFsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameTFF)
                TFFsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Create File for TFT
            Dim CountTFTString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountTFTCommand As New SqlCommand(CountTFTString, con)
            CountTFTCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TFT"
            CountTFTCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountTFT = CInt(CountTFTCommand.ExecuteScalar)
            Catch ex As Exception
                CountTFT = 0
            End Try
            con.Close()

            If CountTFT = 0 Then
                'Skip creating file
            Else
                strCSVFileNameTFT = "TFT-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                TFTsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameTFT)
                TFTsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Create File for TWD
            Dim CountTWDString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountTWDCommand As New SqlCommand(CountTWDString, con)
            CountTWDCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            CountTWDCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountTWD = CInt(CountTWDCommand.ExecuteScalar)
            Catch ex As Exception
                CountTWD = 0
            End Try
            con.Close()

            If CountTWD = 0 Then
                'Skip creating file
            Else
                strCSVFileNameTWD = "TWD-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                TWDsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameTWD)
                TWDsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Create File for TWE
            Dim CountTWEString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountTWECommand As New SqlCommand(CountTWEString, con)
            CountTWECommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWE"
            CountTWECommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountTWE = CInt(CountTWECommand.ExecuteScalar)
            Catch ex As Exception
                CountTWE = 0
            End Try
            con.Close()

            If CountTWE = 0 Then
                'Skip creating file
            Else
                strCSVFileNameTWE = "TWE-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                TWEsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameTWE)
                TWEsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Create File for TOR
            Dim CountTORString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountTORCommand As New SqlCommand(CountTORString, con)
            CountTORCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TOR"
            CountTORCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountTOR = CInt(CountTORCommand.ExecuteScalar)
            Catch ex As Exception
                CountTOR = 0
            End Try
            con.Close()

            If CountTOR = 0 Then
                'Skip creating file
            Else
                strCSVFileNameTOR = "TOR-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                TORsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameTOR)
                TORsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Create File for ALB
            Dim CountALBString As String = "SELECT COUNT(CheckNumber) FROM APCheckLog WHERE DivisionID = @DivisionID AND CheckDate = @CheckDate"
            Dim CountALBCommand As New SqlCommand(CountALBString, con)
            CountALBCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ALB"
            CountALBCommand.Parameters.Add("@CheckDate", SqlDbType.VarChar).Value = CheckDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountALB = CInt(CountALBCommand.ExecuteScalar)
            Catch ex As Exception
                CountALB = 0
            End Try
            con.Close()

            If CountALB = 0 Then
                'Skip creating file
            Else
                strCSVFileNameALB = "ALB-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
                ALBsw = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileNameALB)
                ALBsw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")
            End If

            'Run routine once for every division
            For Each LineRow As DataGridViewRow In dgvAPCheckLog.Rows
                Try
                    CheckNumber = LineRow.Cells("CheckNumberColumn").Value
                Catch ex As System.Exception
                    CheckNumber = 0
                End Try
                Try
                    CheckPayee = LineRow.Cells("VendorIDColumn").Value
                Catch ex As System.Exception
                    CheckPayee = ""
                End Try
                Try
                    CheckAmount = LineRow.Cells("CheckAmountColumn").Value
                Catch ex As System.Exception
                    CheckAmount = 0
                End Try
                Try
                    CheckDivisionID = LineRow.Cells("DivisionIDColumn").Value
                Catch ex As System.Exception
                    CheckDivisionID = ""
                End Try

                'Get Vendor Name
                Dim CheckPayeeNameString As String = "SELECT VendorName FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                Dim CheckPayeeNameCommand As New SqlCommand(CheckPayeeNameString, con)
                CheckPayeeNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CheckDivisionID
                CheckPayeeNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = CheckPayee

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckPayeeName = CStr(CheckPayeeNameCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckPayeeName = ""
                End Try
                con.Close()

                'Format Check Date
                CheckDate = Today()

                Dim strCheckDay, strCheckMonth, strCheckYear As String
                Dim intCheckDay, intCheckMonth, intCheckYear As Integer

                intCheckDay = CheckDate.Day
                intCheckMonth = CheckDate.Month
                intCheckYear = CheckDate.Year

                strCheckDay = CStr(intCheckDay)
                strCheckMonth = CStr(intCheckMonth)
                strCheckYear = CStr(intCheckYear)

                If intCheckDay < 10 Then
                    strCheckDay = "0" + strCheckDay
                End If

                If intCheckMonth < 10 Then
                    strCheckMonth = "0" + strCheckMonth
                End If

                strCheckDate = strCheckMonth + "/" + strCheckDay + "/" + strCheckYear

                strCheckAmount = CStr(CheckAmount)
                strCheckNumber = CStr(CheckNumber)

                'Get Account Number for division
                Select Case CheckDivisionID
                    Case "ATL"
                        CheckAccountNumber = "01663009036"
                        ATLsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case "CBS"
                        CheckAccountNumber = "01668390258"
                        CBSsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case "CGO"
                        CheckAccountNumber = "01663009065"
                        CGOsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case "CHT"
                        CheckAccountNumber = "01668391736"
                        CHTsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case "DEN"
                        CheckAccountNumber = "01663009104"
                        DENsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case "HOU"
                        CheckAccountNumber = "01663009078"
                        HOUsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case "SLC"
                        CheckAccountNumber = "01668390588"
                        SLCsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case "TFF"
                        CheckAccountNumber = "01668390892"
                        TFFsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case "TFT"
                        CheckAccountNumber = "01663009094"
                        TFTsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case "TWD"
                        CheckAccountNumber = "01668301519"
                        TWDsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case "TWE"
                        CheckAccountNumber = "01668390902"
                        TWEsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case "TOR"
                        CheckAccountNumber = "01668390892"
                        TORsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case "ALB"
                        CheckAccountNumber = "01668390892"
                        ALBsw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)
                    Case Else
                        CheckAccountNumber = "01668301519"
                End Select

                'Clear variables
                CheckNumber = 0
                CheckPayee = ""
                CheckAmount = 0
                CheckDivisionID = ""
                CheckAccountNumber = ""
                strCheckNumber = ""
                strCheckAmount = ""
                strCheckDate = ""
                CheckPayeeName = ""
            Next

            If CountATL = 0 Then
                'Skip
            Else
                ATLsw.Close()
            End If
            If CountCBS = 0 Then
                'Skip
            Else
                CBSsw.Close()
            End If
            If CountCGO = 0 Then
                'Skip
            Else
                CGOsw.Close()
            End If
            If CountCHT = 0 Then
                'Skip
            Else
                CHTsw.Close()
            End If
            If CountDEN = 0 Then
                'Skip
            Else
                DENsw.Close()
            End If
            If CountHOU = 0 Then
                'Skip
            Else
                HOUsw.Close()
            End If
            If CountSLC = 0 Then
                'Skip
            Else
                SLCsw.Close()
            End If
            If CountTFF = 0 Then
                'Skip
            Else
                TFFsw.Close()
            End If
            If CountTFT = 0 Then
                'Skip
            Else
                TFTsw.Close()
            End If
            If CountTWD = 0 Then
                'Skip
            Else
                TWDsw.Close()
            End If
            If CountTWE = 0 Then
                'Skip
            Else
                TWEsw.Close()
            End If
            If CountTOR = 0 Then
                'Skip
            Else
                TORsw.Close()
            End If
            If CountALB = 0 Then
                'Skip
            Else
                ALBsw.Close()
            End If

            MsgBox("CSV Files created.", MsgBoxStyle.OkOnly)
        Else
            'Create one upload file for current division
            Dim CheckNumber As Int64 = 0
            Dim CheckDate As Date
            Dim CheckPayee As String = ""
            Dim CheckAmount As Double = 0
            Dim CheckDivisionID As String = ""
            Dim CheckAccountNumber As String = ""
            Dim strCheckNumber, strCheckAmount, strCheckDate As String
            Dim CheckPayeeName As String = ""
            Dim MinuteDate As Date = Now()

            'Create Filename
            Dim TodaysDate As Date = Today()
            Dim strDay, strMonth, strYear, strMinute, strHour As String
            Dim intDay, intMonth, intYear, intMinute, intHour As Integer

            intDay = TodaysDate.Day
            intMonth = TodaysDate.Month
            intYear = TodaysDate.Year
            intMinute = MinuteDate.Minute
            intHour = MinuteDate.Hour

            strDay = CStr(intDay)
            strMonth = CStr(intMonth)
            strYear = CStr(intYear)
            strMinute = CStr(intMinute)
            strHour = CStr(intHour)

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

            If cboDivisionID.Text = "ADM" Then
                strCSVFileName = "CheckLog-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
            Else
                strCSVFileName = cboDivisionID.Text + "-(" + strMonth + strDay + strYear + strHour + strMinute + ").csv"
            End If

            'Write to Header Line
            Dim sw As StreamWriter = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileName)

            sw.WriteLine("Check Number, Check Date, Check Amount, Payee Name, Account Number")

            For Each LineRow As DataGridViewRow In dgvAPCheckLog.Rows
                Try
                    CheckNumber = LineRow.Cells("CheckNumberColumn").Value
                Catch ex As System.Exception
                    CheckNumber = 0
                End Try
                Try
                    CheckPayee = LineRow.Cells("VendorIDColumn").Value
                Catch ex As System.Exception
                    CheckPayee = ""
                End Try
                Try
                    CheckAmount = LineRow.Cells("CheckAmountColumn").Value
                Catch ex As System.Exception
                    CheckAmount = 0
                End Try
                Try
                    CheckDivisionID = LineRow.Cells("DivisionIDColumn").Value
                Catch ex As System.Exception
                    CheckDivisionID = ""
                End Try

                'Get Vendor Name
                Dim CheckPayeeNameString As String = "SELECT VendorName FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                Dim CheckPayeeNameCommand As New SqlCommand(CheckPayeeNameString, con)
                CheckPayeeNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CheckDivisionID
                CheckPayeeNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = CheckPayee

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    CheckPayeeName = CStr(CheckPayeeNameCommand.ExecuteScalar)
                Catch ex As Exception
                    CheckPayeeName = ""
                End Try
                con.Close()

                'Format Check Date
                CheckDate = Today()

                Dim strCheckDay, strCheckMonth, strCheckYear As String
                Dim intCheckDay, intCheckMonth, intCheckYear As Integer

                intCheckDay = CheckDate.Day
                intCheckMonth = CheckDate.Month
                intCheckYear = CheckDate.Year

                strCheckDay = CStr(intCheckDay)
                strCheckMonth = CStr(intCheckMonth)
                strCheckYear = CStr(intCheckYear)

                If intCheckDay < 10 Then
                    strCheckDay = "0" + strCheckDay
                End If

                If intCheckMonth < 10 Then
                    strCheckMonth = "0" + strCheckMonth
                End If

                strCheckDate = strCheckMonth + "/" + strCheckDay + "/" + strCheckYear

                strCheckAmount = CStr(CheckAmount)
                strCheckNumber = CStr(CheckNumber)

                'Get Account Number for division
                Select Case CheckDivisionID
                    Case "ATL"
                        CheckAccountNumber = "01663009036"
                    Case "CBS"
                        CheckAccountNumber = "01668390258"
                    Case "CGO"
                        CheckAccountNumber = "01663009065"
                    Case "CHT"
                        CheckAccountNumber = "01668391736"
                    Case "DEN"
                        CheckAccountNumber = "01663009104"
                    Case "HOU"
                        CheckAccountNumber = "01663009078"
                    Case "SLC"
                        CheckAccountNumber = "01668390588"
                    Case "TFF"
                        CheckAccountNumber = "01668390892"
                    Case "TFT"
                        CheckAccountNumber = "01663009094"
                    Case "TWD"
                        CheckAccountNumber = "01668301519"
                    Case "TWE"
                        CheckAccountNumber = "01668390902"
                    Case "TOR"
                        CheckAccountNumber = "01668390892"
                    Case "ALB"
                        CheckAccountNumber = "01668390892"
                    Case Else
                        CheckAccountNumber = "01668301519"
                End Select

                sw.WriteLine(strCheckNumber + "," + strCheckDate + "," + strCheckAmount + "," + CheckPayeeName + "," + CheckAccountNumber)

                'Clear variables
                CheckNumber = 0
                CheckPayee = ""
                CheckAmount = 0
                CheckDivisionID = ""
                CheckAccountNumber = ""
                strCheckNumber = ""
                strCheckAmount = ""
                strCheckDate = ""
                CheckPayeeName = ""
            Next

            sw.Close()

            MsgBox("CSV File created.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Public Shared Sub ReadFromFile()
        Try
            ' Create an instance of StreamReader to read from a file.
            Dim sr As StreamReader = New StreamReader("\\TFP-FS\TrufitBanking\Bank CSV Files\User_Log.txt")
            Dim line As String
            ' Read and display the lines from the file until the end 
            ' of the file is reached.
            Do
                line = sr.ReadLine()
                Console.WriteLine(line)
            Loop Until line Is Nothing
            sr.Close()
        Catch E As Exception
            ' Let the user know what went wrong.
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(E.Message)
        End Try
    End Sub

    Public Shared Sub WriteToFile()
        '' Create an instance of StreamWriter to write text to a file.
        'Dim sw As StreamWriter = New StreamWriter("\\TFP-FS\TrufitBanking\Bank CSV Files\" + strCSVFileName)
        '' Add some text to the file.
        'sw.WriteLine("TFP Corporation ")
        'sw.WriteLine("User Log File.")
        'sw.WriteLine("-------------------")
        '' Arbitrary objects can also be written to the file.
        'sw.Write("The date is: ")
        'sw.WriteLine(DateTime.Now)
        'sw.WriteLine("User " & EmployeeLoginName & " " & EmployeeCompanyCode & " Logged in")
        'sw.Close()
    End Sub

    Public Shared Sub Main()
        'If Not File.Exists(strCSVFileName) Then
        '    Console.WriteLine("{0} does not exist.", strCSVFileName)
        '    Return
        'End If
        'Dim sr As StreamReader = File.OpenText(strCSVFileName)
        'Dim input As String
        'input = sr.ReadLine()
        'While Not input Is Nothing
        '    Console.WriteLine(input)
        '    input = sr.ReadLine()
        'End While
        'Console.WriteLine("The end of the stream has been reached.")
        'sr.Close()
    End Sub

    Public Shared Sub Overwrite()
        Dim sw As StreamWriter = File.AppendText("\\TFP-FS\TransferData\MOS09 Updates\User_Log.txt")
        sw.WriteLine("-------------------")
        ' Arbitrary objects can also be written to the file.
        sw.Write("The date is: ")
        sw.WriteLine(DateTime.Now)
        sw.WriteLine("User " & EmployeeLoginName & " " & EmployeeCompanyCode & " Logged in")
        ' Close the writer and underlying file.
        sw.Close()
        ' Open and read the file.
        Dim r As StreamReader = File.OpenText("\\TFP-FS\TransferData\MOS09 Updates\User_Log.txt")
        DumpLog(r)
    End Sub

    Public Shared Sub Log(ByVal logMessage As String, ByVal w As TextWriter)
        w.Write(ControlChars.CrLf & "Log Entry : ")
        w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString())
        w.WriteLine("  :")
        w.WriteLine("  :{0}", logMessage)
        w.WriteLine("-------------------------------")
        ' Update the underlying file.
        w.Flush()
    End Sub

    Public Shared Sub DumpLog(ByVal r As StreamReader)
        ' While not at the end of the file, read and write lines.
        Dim line As String
        line = r.ReadLine()
        While Not line Is Nothing
            Console.WriteLine(line)
            line = r.ReadLine()
        End While
        r.Close()
    End Sub

    Private Sub WriteToCSVFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToExcelToolStripMenuItem.Click
        Dim ExcelObject As New Excel.Application
        Dim NewWB As Excel.Workbook

        Dim CheckNumber As Int64 = 0
        Dim CheckDate As String = ""
        Dim CheckPayee As String = ""
        Dim CheckAmount As Double = 0
        Dim CheckDivisionID As String = ""
        Dim CheckAccountNumber As String = ""

        'Create Excel Sheet with Headers

        NewWB = ExcelObject.Workbooks.Add()
        ExcelObject.Range("A1").Select()
        ExcelObject.ActiveCell.Value = "Check Number"
        ExcelObject.Range("B1").Select()
        ExcelObject.ActiveCell.Value = "Check Date"
        ExcelObject.Range("C1").Select()
        ExcelObject.ActiveCell.Value = "Check Amount"
        ExcelObject.Range("D1").Select()
        ExcelObject.ActiveCell.Value = "Payee Name"
        ExcelObject.Range("E1").Select()
        ExcelObject.ActiveCell.Value = "Account Number"
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

        For Each LineRow As DataGridViewRow In dgvAPCheckLog.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                CheckNumber = LineRow.Cells("CheckNumberColumn").Value
            Catch ex As System.Exception
                CheckNumber = 0
            End Try
            Try
                CheckDate = LineRow.Cells("CheckDateColumn").Value
            Catch ex As System.Exception
                CheckDate = ""
            End Try
            Try
                CheckPayee = LineRow.Cells("VendorIDColumn").Value
            Catch ex As System.Exception
                CheckPayee = ""
            End Try
            Try
                CheckAmount = LineRow.Cells("CheckAmountColumn").Value
            Catch ex As System.Exception
                CheckAmount = 0
            End Try
            Try
                CheckDivisionID = LineRow.Cells("DivisionIDColumn").Value
            Catch ex As System.Exception
                CheckDivisionID = ""
            End Try

            'Get Account Number for division
            Select Case CheckDivisionID
                Case "ATL"
                    CheckAccountNumber = "01668301519"
                Case "CBS"
                    CheckAccountNumber = "01668390258"
                Case "CGO"
                    CheckAccountNumber = "01668301519"
                Case "CHT"
                    CheckAccountNumber = "01668391736"
                Case "DEN"
                    CheckAccountNumber = "01668301519"
                Case "HOU"
                    CheckAccountNumber = "01668301519"
                Case "SLC"
                    CheckAccountNumber = "01668390588"
                Case "TFF"
                    CheckAccountNumber = "01668390892"
                Case "TFT"
                    CheckAccountNumber = "01668301519"
                Case "TWD"
                    CheckAccountNumber = "01668301519"
                Case "TWE"
                    CheckAccountNumber = "01668390902"
                Case "TOR"
                    CheckAccountNumber = "01668390892"
                Case "ALB"
                    CheckAccountNumber = "01668390892"
                Case Else
                    CheckAccountNumber = "01668301519"
            End Select

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = CheckNumber

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = CheckDate

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = CheckAmount

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = CheckPayee

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = CheckAccountNumber

            'ExcelObject.Range("F" + strRow).Select()
            'ExcelObject.ActiveCell.Value = DivisionName

            'ExcelObject.Range("G" + strRow).Select()
            'ExcelObject.ActiveCell.Value = VendorAccount
        Next


        ''Insert Total
        'ExcelObject.Range("C" + strMasterLineCount).Select()
        'ExcelObject.ActiveCell.Value = "Total Remittance - "
        'ExcelObject.Range("C" + strMasterLineCount).Font.Bold = True
        'ExcelObject.Range("C" + strMasterLineCount).Font.Size = 12
        'ExcelObject.Range("C" + strMasterLineCount).Font.Underline = True

        'ExcelObject.Range("D" + strMasterLineCount).Select()
        'ExcelObject.ActiveCell.Value = MasterLineTotal
        'ExcelObject.Range("D" + strMasterLineCount).Font.Bold = True
        'ExcelObject.Range("D" + strMasterLineCount).Font.Size = 12
        'ExcelObject.Range("D" + strMasterLineCount).Font.Underline = True

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

        Filename = "CheckLog-(" + strMonth + strDay + strYear + strMinute + ").xls"
        ExcelFileName = Filename

        NewWB.SaveAs("\\TFP-FS\TrufitBanking\Bank CSV Files\" + Filename)

        ExcelObject.Visible = True

    End Sub

    Public Sub TFPErrorLogUpdate()
        If ErrorComment.Length > 400 Then
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        'Insert Data into error log
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

    Private Sub cmdExportACH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportACH.Click
        'Check and make sure only one division and that datagrid is filled
        If Me.dgvAPCheckLog.RowCount > 0 Then
            'Continue
        Else
            MsgBox("You must populate datagrid before creating export file.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim RowDivision, CurrentDivision As String
        RowDivision = ""
        CurrentDivision = ""
        Dim RowCounter As Integer = 0

        For Each Row1 As DataGridViewRow In dgvAPCheckLog.Rows
            Try
                RowDivision = Row1.Cells("DivisionIDColumn").Value
            Catch ex As System.Exception
                RowDivision = ""
            End Try

            If RowCounter = 0 Then
                CurrentDivision = RowDivision
            End If

            If RowDivision = CurrentDivision Then
                'Continue
            Else
                MsgBox("All divisions do not match in datagrid. Cannot export at this time.", MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            RowDivision = ""
            RowCounter = RowCounter + 1
        Next

        'Define filename for manual upload
        Dim strACHFileName As String = ""

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

        strACHFileName = CurrentDivision + strMonth + strDay + strYear + strMinute + ".csv"

        'Create filename for ACH upload, if necessary
        Try
            Dim ACHPayee As String = ""
            Dim ACHAmount As Double = 0
            Dim ACHDivisionID As String = ""
            Dim ACHPayeeName As String = ""
            Dim ACHAccountNumber As String = ""
            Dim ACHRoutingNumber As String = ""
            Dim ACHAccountType As String = ""
            Dim strACHAmount As String = ""
            Dim ACHCheckNumber As Int64 = 0

            Dim sw2 As StreamWriter = New StreamWriter("\\TFP-FS\TrufitBanking\ACH File Uploads\" + strACHFileName)

            'Write to Header Line
            sw2.WriteLine("Beneficiary Name, Beneficiary ABA, Beneficiary Account Number, Beneficiary Account Type, Amount")

            For Each LineRow As DataGridViewRow In dgvAPCheckLog.Rows
                Try
                    ACHPayee = LineRow.Cells("VendorIDColumn").Value
                Catch ex As System.Exception
                    ACHPayee = ""
                End Try
                Try
                    ACHAmount = LineRow.Cells("CheckAmountColumn").Value
                Catch ex As System.Exception
                    ACHAmount = 0
                End Try
                Try
                    ACHDivisionID = LineRow.Cells("DivisionIDColumn").Value
                Catch ex As System.Exception
                    ACHDivisionID = ""
                End Try
                Try
                    ACHCheckNumber = LineRow.Cells("CheckNumberColumn").Value
                Catch ex As System.Exception
                    ACHCheckNumber = ""
                End Try

                'Check to see if check number is ACH or Standard
                Dim VerifyCheckType As String = ""

                Dim VerifyCheckTypeString As String = "SELECT MAX(CheckCode) FROM APCheckQuery WHERE DivisionID = @DivisionID AND CheckNumber = @CheckNumber"
                Dim VerifyCheckTypeCommand As New SqlCommand(VerifyCheckTypeString, con)
                VerifyCheckTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ACHDivisionID
                VerifyCheckTypeCommand.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = ACHCheckNumber

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    VerifyCheckType = CStr(VerifyCheckTypeCommand.ExecuteScalar)
                Catch ex As Exception
                    VerifyCheckType = ""
                End Try
                con.Close()

                strACHAmount = CStr(ACHAmount)

                'Get Vendor Name
                Dim ACHPayeeNameString As String = "SELECT VendorName FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                Dim ACHPayeeNameCommand As New SqlCommand(ACHPayeeNameString, con)
                ACHPayeeNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ACHDivisionID
                ACHPayeeNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = ACHPayee

                Dim ACHAccountNumberString As String = "SELECT VendorAccountNumber FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                Dim ACHAccountNumberCommand As New SqlCommand(ACHAccountNumberString, con)
                ACHAccountNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ACHDivisionID
                ACHAccountNumberCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = ACHPayee

                Dim ACHRoutingNumberString As String = "SELECT VendorRoutingNumber FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                Dim ACHRoutingNumberCommand As New SqlCommand(ACHRoutingNumberString, con)
                ACHRoutingNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ACHDivisionID
                ACHRoutingNumberCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = ACHPayee

                Dim ACHAccountTypeString As String = "SELECT VendorAccountType FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
                Dim ACHAccountTypeCommand As New SqlCommand(ACHAccountTypeString, con)
                ACHAccountTypeCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = ACHDivisionID
                ACHAccountTypeCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = ACHPayee

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    ACHPayeeName = CStr(ACHPayeeNameCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHPayeeName = ""
                End Try
                Try
                    ACHAccountNumber = CStr(ACHAccountNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHAccountNumber = ""
                End Try
                Try
                    ACHRoutingNumber = CStr(ACHRoutingNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHRoutingNumber = ""
                End Try
                Try
                    ACHAccountType = CStr(ACHAccountTypeCommand.ExecuteScalar)
                Catch ex As Exception
                    ACHAccountType = ""
                End Try
                con.Close()

                If ACHPayeeName.Length > 22 Then
                    ACHPayeeName = ACHPayeeName.Substring(0, 22)
                End If

                If VerifyCheckType = "STANDARD" Then
                    'Skip entry
                Else
                    'Write lines to file
                    sw2.WriteLine(ACHPayeeName + "," + ACHRoutingNumber + "," + ACHAccountNumber + "," + ACHAccountType + "," + strACHAmount)
                End If

                ACHPayee = ""
                ACHPayeeName = ""
                ACHDivisionID = ""
                ACHAmount = 0
                ACHAccountNumber = ""
                ACHRoutingNumber = ""
                ACHAccountType = ""
            Next

            sw2.Close()

            MsgBox("File Created.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'Log error on update failure

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Post AP Payment Batch --- Create ACH Upload File failed"
            ErrorReferenceNumber = "Filename " + strACHFileName
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Public Sub AutoprintCheckRemittanceRoutine()
        Dim CheckNumber As Int64 = 0
        Dim CheckDivision As String = ""
        Dim strCheckNumber As String = ""
        Dim strACHFileName As String = ""

        Dim RowIndex As Integer = Me.dgvAPCheckLog.CurrentCell.RowIndex

        CheckNumber = Me.dgvAPCheckLog.Rows(RowIndex).Cells("CheckNumberColumn").Value
        CheckDivision = Me.dgvAPCheckLog.Rows(RowIndex).Cells("DivisionIDColumn").Value

        strCheckNumber = CStr(CheckNumber)
        strACHFileName = CheckDivision + strCheckNumber + ".pdf"

        'Load dataset for one check
        Dim OneCheckDataset As DataSet
        Dim OneCheckAdapter As New SqlDataAdapter
        Dim OneCheckAdapter2 As New SqlDataAdapter

        cmd = New SqlCommand("SELECT * FROM APCheckQuery WHERE CheckNumber = @CheckNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@CheckNumber", SqlDbType.VarChar).Value = CheckNumber
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = CheckDivision

        'Add division table to dataset
        cmd2 = New SqlCommand("SELECT * FROM DivisionTable WHERE DivisionKey = @DivisionKey", con)
        cmd2.Parameters.Add("@DivisionKey", SqlDbType.VarChar).Value = CheckDivision

        If con.State = ConnectionState.Closed Then con.Open()
        OneCheckDataset = New DataSet()

        OneCheckAdapter.SelectCommand = cmd
        OneCheckAdapter.Fill(OneCheckDataset, "APCheckQuery")

        OneCheckAdapter2.SelectCommand = cmd2
        OneCheckAdapter2.Fill(OneCheckDataset, "DivisionTable")
        con.Close()

        'Create Remittance file from crystal report
        AutoprintCheckRemittance = crxptRemittance1
        AutoprintCheckRemittance.SetDataSource(OneCheckDataset)
        AutoprintCheckRemittance.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TrufitBanking\ACH Remit\" & strACHFileName)
        AutoprintCheckRemittance.PrintToPrinter(1, True, 1, 999)
        con.Close()
    End Sub

    Public Sub NoAutoprintCheckRemittance()
        Dim APCheckNumber As Int64 = 0
        Dim CheckDivision As String = ""
        Dim APCheckVendor As String = ""
        Dim APRemittanceEmail As String = ""

        Dim RowIndex As Integer = Me.dgvAPCheckLog.CurrentCell.RowIndex

        APCheckNumber = Me.dgvAPCheckLog.Rows(RowIndex).Cells("CheckNumberColumn").Value
        CheckDivision = Me.dgvAPCheckLog.Rows(RowIndex).Cells("DivisionIDColumn").Value
        APRemittanceEmail = Me.dgvAPCheckLog.Rows(RowIndex).Cells("RemittanceEmailColumn").Value

        GlobalAPCheckNumber = APCheckNumber
        GlobalDivisionCode = CheckDivision
        GlobalNoAutoPrintCheckRemittance = "NO AUTOPRINT"
        GlobalAPRemittanceEmail = APRemittanceEmail

        Using NewPrintAPCheckRemittance As New PrintAPCheckRemittance
            Dim result = NewPrintAPCheckRemittance.ShowDialog()
        End Using
    End Sub

    Public Sub AutoprintBatchReportRoutine()
        'Get Batch Number of selected Check
        'Create Filename
        Dim strBatchNumber As String = ""
        Dim BatchNumber As Int64 = 0
        Dim BatchFilename As String = ""
        Dim BatchDivision As String = ""

        Dim RowIndex As Integer = Me.dgvAPCheckLog.CurrentCell.RowIndex

        BatchNumber = Me.dgvAPCheckLog.Rows(RowIndex).Cells("APBatchNumberColumn").Value
        BatchDivision = Me.dgvAPCheckLog.Rows(RowIndex).Cells("DivisionIDColumn").Value

        strBatchNumber = CStr(BatchNumber)

        BatchFilename = cboDivisionID.Text + strBatchNumber + ".pdf"

        'Load data into Dataset
        cmd = New SqlCommand("SELECT * FROM APProcessPaymentBatch  WHERE BatchNumber = @BatchNumber", con)
        cmd.Parameters.Add("@BatchNumber", SqlDbType.VarChar).Value = BatchNumber

        cmd2 = New SqlCommand("SELECT * FROM APCheckLog WHERE APBatchNumber = @APBatchNumber", con)
        cmd2.Parameters.Add("@APBatchNumber", SqlDbType.VarChar).Value = BatchNumber

        If con.State = ConnectionState.Closed Then con.Open()
        APReportDataset = New DataSet()

        myAdapter.SelectCommand = cmd
        myAdapter.Fill(APReportDataset, "APProcessPaymentBatch")

        myAdapter2.SelectCommand = cmd2
        myAdapter2.Fill(APReportDataset, "APCheckLog")

        AutoprintBatchReport = crxapPaymentBatch1
        AutoprintBatchReport.SetDataSource(APReportDataset)
        AutoprintBatchReport.ExportToDisk(ExportFormatType.PortableDocFormat, "\\TFP-FS\TrufitBanking\APBatchReports\" & BatchFilename)
        AutoprintBatchReport.PrintToPrinter(1, True, 1, 999)
        con.Close()
    End Sub

    Public Sub NoAutoprintBatchRoutine()
        Dim APBatchNumber As Int64 = 0
        Dim CheckDivision As String = ""

        Dim RowIndex As Integer = Me.dgvAPCheckLog.CurrentCell.RowIndex

        APBatchNumber = Me.dgvAPCheckLog.Rows(RowIndex).Cells("APBatchNumberColumn").Value
        CheckDivision = Me.dgvAPCheckLog.Rows(RowIndex).Cells("DivisionIDColumn").Value

        GlobalAPBatchNumber = APBatchNumber
        GlobalDivisionCode = CheckDivision

        Using NewPrintAPCheckRemittance As New PrintAPPaymentBatch
            Dim result = NewPrintAPCheckRemittance.ShowDialog()
        End Using
    End Sub

    Private Sub cmdCheckRemittance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckRemittance.Click
        If Me.dgvAPCheckLog.RowCount > 0 Then
            NoAutoprintCheckRemittance()
            'AutoprintCheckRemittanceRoutine()
        Else
            MsgBox("You must select a row in the datagrid to print a Remittance.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmdBatchRemittance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBatchRemittance.Click
        If Me.dgvAPCheckLog.RowCount > 0 Then
            'AutoprintBatchReportRoutine()
            NoAutoprintBatchRoutine()
        Else
            MsgBox("You must select a row in the datagrid to print Batch Report.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub dgvAPCheckLog_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAPCheckLog.CellDoubleClick
        NoAutoprintCheckRemittance()
    End Sub

    Private Sub dgvAPCheckLog_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAPCheckLog.ColumnHeaderMouseClick
        FormatDatagrid()
    End Sub
End Class