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
Imports Microsoft.Office.Interop
Imports System.Net.Mail
Imports System.Web
Public Class ViewEFTRemittance
    Inherits System.Windows.Forms.Form

    Dim ExcelFileName As String = ""

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable

    Private Sub ViewEFTRemmittance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        'TODO: This line of code loads data into the 'SQLTFPOperationsDatabaseDataSet.DivisionTable' table. You can move, or remove it, as needed.
        Me.DivisionTableTableAdapter.Fill(Me.SQLTFPOperationsDatabaseDataSet.DivisionTable)

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
        End If

        ValidateFields()
    End Sub

    Public Sub LoadVouchers()
        If cboCheckType.Text = "" Then
            MsgBox("You must select a check type.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLineQuery WHERE VoucherStatus = @VoucherStatus AND CheckCode = @CheckCode AND CheckType = @CheckType AND PaidDate BETWEEN @BeginDate AND @EndDate ORDER BY DivisionID, VendorID", con)
        cmd.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "CLOSED"
        cmd.Parameters.Add("@CheckCode", SqlDbType.VarChar).Value = cboCheckType.Text
        cmd.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLineQuery")
        dgvVouchers.DataSource = ds.Tables("ReceiptOfInvoiceBatchLineQuery")
        con.Close()
    End Sub

    Public Sub ValidateFields()
        If Me.dgvVouchers.RowCount = 0 Then
            cmdExportExcel.Enabled = False
            cmdEmailRemittance.Enabled = False
            cmdRemmittance.Enabled = False
        Else
            cmdExportExcel.Enabled = True
            cmdEmailRemittance.Enabled = True
            cmdRemmittance.Enabled = True
        End If
    End Sub

    Public Sub LoadTotals()
        Dim DatagridTotal As Double = 0
        Dim DatagridCount As Integer = 0

        Dim DatagridTotalStatement As String = "SELECT SUM(InvoiceAmount) FROM ReceiptOfInvoiceBatchLineQuery WHERE VoucherStatus = @VoucherStatus AND CheckCode = @CheckCode AND CheckType = @CheckType AND PaidDate BETWEEN @BeginDate AND @EndDate"
        Dim DatagridTotalCommand As New SqlCommand(DatagridTotalStatement, con)
        DatagridTotalCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "CLOSED"
        DatagridTotalCommand.Parameters.Add("@CheckCode", SqlDbType.VarChar).Value = cboCheckType.Text
        DatagridTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        DatagridTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        DatagridTotalCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text

        Dim DatagridCountStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLineQuery WHERE VoucherStatus = @VoucherStatus AND CheckCode = @CheckCode AND CheckType = @CheckType AND PaidDate BETWEEN @BeginDate AND @EndDate"
        Dim DatagridCountCommand As New SqlCommand(DatagridCountStatement, con)
        DatagridCountCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "CLOSED"
        DatagridCountCommand.Parameters.Add("@CheckCode", SqlDbType.VarChar).Value = cboCheckType.Text
        DatagridCountCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        DatagridCountCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        DatagridCountCommand.Parameters.Add("@CheckType", SqlDbType.VarChar).Value = cboCheckType.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            DatagridTotal = CDbl(DatagridTotalCommand.ExecuteScalar)
        Catch ex As Exception
            DatagridTotal = 0
        End Try
        Try
            DatagridCount = CInt(DatagridCountCommand.ExecuteScalar)
        Catch ex As Exception
            DatagridCount = 0
        End Try
        con.Close()

        txtInvoiceTotal.Text = DatagridTotal
        txtNumberOfInvoices.Text = DatagridCount
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        LoadVouchers()
        LoadTotals()
        ValidateFields()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        dgvVouchers.DataSource = Nothing
        txtInvoiceTotal.Clear()
        txtNumberOfInvoices.Clear()
        cboCheckType.SelectedIndex = -1

        ExcelFileName = ""

        ValidateFields()
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Dim ExcelObject As New Excel.Application
        Dim NewWB As Excel.Workbook

        Dim MasterLineTotal As Double = 0
        Dim MasterLineCount As Integer = 0
        Dim strMasterLineCount As String = ""

        Dim InvoiceNumber As String = ""
        Dim InvoiceDate As String = ""
        Dim VendorID As String = ""
        Dim InvoiceAmount As Double = 0
        Dim DivisionID As String = ""
        Dim DivisionName As String = ""
        Dim VendorAccount As String = ""

        'Create Excel Sheet with Headers

        NewWB = ExcelObject.Workbooks.Add()
        ExcelObject.Range("A1").Select()
        ExcelObject.ActiveCell.Value = "Invoice #"
        ExcelObject.Range("B1").Select()
        ExcelObject.ActiveCell.Value = "Invoice Date"
        ExcelObject.Range("C1").Select()
        ExcelObject.ActiveCell.Value = "Vendor ID"
        ExcelObject.Range("D1").Select()
        ExcelObject.ActiveCell.Value = "Invoice Amount"
        ExcelObject.Range("E1").Select()
        ExcelObject.ActiveCell.Value = "Division ID"
        ExcelObject.Range("F1").Select()
        ExcelObject.ActiveCell.Value = "Division Name"
        ExcelObject.Range("G1").Select()
        ExcelObject.ActiveCell.Value = "Account #"

        'Format the table
        ExcelObject.Range("A1:G1").Font.Size = 12
        ExcelObject.Range("A1:G1").Font.Bold = True
        ExcelObject.Range("A1:G1").RowHeight = 20

        ExcelObject.Range("A1").ColumnWidth = 15
        ExcelObject.Range("B1").ColumnWidth = 15
        ExcelObject.Range("C1").ColumnWidth = 20
        ExcelObject.Range("D1").ColumnWidth = 20
        ExcelObject.Range("E1").ColumnWidth = 15
        ExcelObject.Range("F1").ColumnWidth = 30
        ExcelObject.Range("G1").ColumnWidth = 20

        Dim RowCounter As Integer = 1
        Dim strRow As String = ""

        For Each LineRow As DataGridViewRow In dgvVouchers.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                InvoiceNumber = LineRow.Cells("InvoiceNumberColumn").Value
            Catch ex As System.Exception
                InvoiceNumber = ""
            End Try
            Try
                InvoiceDate = LineRow.Cells("InvoiceDateColumn").Value
            Catch ex As System.Exception
                InvoiceDate = ""
            End Try
            Try
                VendorID = LineRow.Cells("VendorIDColumn").Value
            Catch ex As System.Exception
                VendorID = ""
            End Try
            Try
                InvoiceAmount = LineRow.Cells("InvoiceAmountColumn").Value
            Catch ex As System.Exception
                InvoiceAmount = 0
            End Try
            Try
                DivisionID = LineRow.Cells("DivisionIDColumn").Value
            Catch ex As System.Exception
                DivisionID = ""
            End Try
            Try
                DivisionName = LineRow.Cells("CompanyNameColumn").Value
            Catch ex As System.Exception
                DivisionName = ""
            End Try
            Try
                VendorAccount = LineRow.Cells("VendorAccountNumberColumn").Value
            Catch ex As System.Exception
                VendorAccount = ""
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = InvoiceNumber

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = InvoiceDate

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = VendorID

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = InvoiceAmount

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = DivisionID

            ExcelObject.Range("F" + strRow).Select()
            ExcelObject.ActiveCell.Value = DivisionName

            ExcelObject.Range("G" + strRow).Select()
            ExcelObject.ActiveCell.Value = VendorAccount

            MasterLineTotal = MasterLineTotal + InvoiceAmount
        Next

        MasterLineCount = Me.dgvVouchers.RowCount + 2
        strMasterLineCount = CStr(MasterLineCount)

        'Insert Total
        ExcelObject.Range("C" + strMasterLineCount).Select()
        ExcelObject.ActiveCell.Value = "Total Remittance - "
        ExcelObject.Range("C" + strMasterLineCount).Font.Bold = True
        ExcelObject.Range("C" + strMasterLineCount).Font.Size = 12
        ExcelObject.Range("C" + strMasterLineCount).Font.Underline = True

        ExcelObject.Range("D" + strMasterLineCount).Select()
        ExcelObject.ActiveCell.Value = MasterLineTotal
        ExcelObject.Range("D" + strMasterLineCount).Font.Bold = True
        ExcelObject.Range("D" + strMasterLineCount).Font.Size = 12
        ExcelObject.Range("D" + strMasterLineCount).Font.Underline = True

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

        Filename = "FEDEX-(" + strMonth + strDay + strYear + strMinute + ").xls"
        ExcelFileName = Filename

        NewWB.SaveAs("\\TFP-FS\TrufitBanking\EFT Remittance\" + Filename)

        ExcelObject.Visible = True
    End Sub

    Private Sub cmdEmailRemittance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmailRemittance.Click
        Dim ExcelObject As New Excel.Application
        Dim NewWB As Excel.Workbook

        Dim MasterLineTotal As Double = 0
        Dim MasterLineCount As Integer = 0
        Dim strMasterLineCount As String = ""
        Dim strMasterLineTotal As String = ""

        Dim InvoiceNumber As String = ""
        Dim InvoiceDate As String = ""
        Dim VendorID As String = ""
        Dim InvoiceAmount As Double = 0
        Dim DivisionID As String = ""
        Dim DivisionName As String = ""
        Dim VendorAccount As String = ""

        'Create Excel Sheet with Headers

        NewWB = ExcelObject.Workbooks.Add()
        ExcelObject.Range("A1").Select()
        ExcelObject.ActiveCell.Value = "Invoice #"
        ExcelObject.Range("B1").Select()
        ExcelObject.ActiveCell.Value = "Invoice Date"
        ExcelObject.Range("C1").Select()
        ExcelObject.ActiveCell.Value = "Vendor ID"
        ExcelObject.Range("D1").Select()
        ExcelObject.ActiveCell.Value = "Invoice Amount"
        ExcelObject.Range("E1").Select()
        ExcelObject.ActiveCell.Value = "Division ID"
        ExcelObject.Range("F1").Select()
        ExcelObject.ActiveCell.Value = "Division Name"
        ExcelObject.Range("G1").Select()
        ExcelObject.ActiveCell.Value = "Account #"

        'Format the table
        ExcelObject.Range("A1:G1").Font.Size = 12
        ExcelObject.Range("A1:G1").Font.Bold = True
        ExcelObject.Range("A1:G1").RowHeight = 20

        ExcelObject.Range("A1").ColumnWidth = 15
        ExcelObject.Range("B1").ColumnWidth = 15
        ExcelObject.Range("C1").ColumnWidth = 20
        ExcelObject.Range("D1").ColumnWidth = 20
        ExcelObject.Range("E1").ColumnWidth = 15
        ExcelObject.Range("F1").ColumnWidth = 30
        ExcelObject.Range("G1").ColumnWidth = 20

        Dim RowCounter As Integer = 1
        Dim strRow As String = ""

        For Each LineRow As DataGridViewRow In dgvVouchers.Rows
            RowCounter = RowCounter + 1
            strRow = CStr(RowCounter)

            Try
                InvoiceNumber = LineRow.Cells("InvoiceNumberColumn").Value
            Catch ex As System.Exception
                InvoiceNumber = ""
            End Try
            Try
                InvoiceDate = LineRow.Cells("InvoiceDateColumn").Value
            Catch ex As System.Exception
                InvoiceDate = ""
            End Try
            Try
                VendorID = LineRow.Cells("VendorIDColumn").Value
            Catch ex As System.Exception
                VendorID = ""
            End Try
            Try
                InvoiceAmount = LineRow.Cells("InvoiceAmountColumn").Value
            Catch ex As System.Exception
                InvoiceAmount = 0
            End Try
            Try
                DivisionID = LineRow.Cells("DivisionIDColumn").Value
            Catch ex As System.Exception
                DivisionID = ""
            End Try
            Try
                DivisionName = LineRow.Cells("CompanyNameColumn").Value
            Catch ex As System.Exception
                DivisionName = ""
            End Try
            Try
                VendorAccount = LineRow.Cells("VendorAccountNumberColumn").Value
            Catch ex As System.Exception
                VendorAccount = ""
            End Try

            ExcelObject.Range("A" + strRow).Select()
            ExcelObject.ActiveCell.Value = InvoiceNumber

            ExcelObject.Range("B" + strRow).Select()
            ExcelObject.ActiveCell.Value = InvoiceDate

            ExcelObject.Range("C" + strRow).Select()
            ExcelObject.ActiveCell.Value = VendorID

            ExcelObject.Range("D" + strRow).Select()
            ExcelObject.ActiveCell.Value = InvoiceAmount

            ExcelObject.Range("E" + strRow).Select()
            ExcelObject.ActiveCell.Value = DivisionID

            ExcelObject.Range("F" + strRow).Select()
            ExcelObject.ActiveCell.Value = DivisionName

            ExcelObject.Range("G" + strRow).Select()
            ExcelObject.ActiveCell.Value = VendorAccount

            MasterLineTotal = MasterLineTotal + InvoiceAmount
        Next

        MasterLineCount = Me.dgvVouchers.RowCount + 2
        strMasterLineCount = CStr(MasterLineCount)
        strMasterLineTotal = CStr(MasterLineTotal)

        'Insert Total
        ExcelObject.Range("C" + strMasterLineCount).Select()
        ExcelObject.ActiveCell.Value = "Total Remittance - "
        ExcelObject.Range("C" + strMasterLineCount).Font.Bold = True
        ExcelObject.Range("C" + strMasterLineCount).Font.Size = 12
        ExcelObject.Range("C" + strMasterLineCount).Font.Underline = True

        ExcelObject.Range("D" + strMasterLineCount).Select()
        ExcelObject.ActiveCell.Value = MasterLineTotal
        ExcelObject.Range("D" + strMasterLineCount).Font.Bold = True
        ExcelObject.Range("D" + strMasterLineCount).Font.Size = 12
        ExcelObject.Range("D" + strMasterLineCount).Font.Underline = True

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

        Filename = "FEDEX-EFT(" + strMonth + strDay + strYear + strMinute + ").xls"
        ExcelFileName = Filename

        NewWB.SaveAs("\\TFP-FS\TrufitBanking\EFT Remittance\" + Filename)
        NewWB.Close()

        'ExcelObject.Visible = True
        'MsgBox("File exported.", MsgBoxStyle.OkOnly)

        Dim MyMailMessage As New MailMessage()
        MyMailMessage.From = New MailAddress("remittance@tfpcorp.com")
        MyMailMessage.To.Add("CASH.POST@FEDEX.COM")
        MyMailMessage.Subject = "Tru-Fit EFT - $" + strMasterLineTotal
        MyMailMessage.Body = "EFT Remittance"
        MyMailMessage.Attachments.Add(New System.Net.Mail.Attachment("\\TFP-FS\TrufitBanking\EFT Remittance\" + Filename))
        Dim SMPT As New SmtpClient("mail.tfpcorp.com")
        SMPT.Port = "587"
        SMPT.EnableSsl = False
        SMPT.Credentials = New System.Net.NetworkCredential("remittance@tfpcorp.com", "Qazxsw2")
        SMPT.Send(MyMailMessage)

        MsgBox("Email sent.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdRemmittance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemmittance.Click
        GDS = ds

        Using NewPrintRemittanceReport As New PrintRemiitanceReport
            Dim Result = NewPrintRemittanceReport.ShowDialog()
        End Using
    End Sub

    Private Sub txtInvoiceTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoiceTotal.TextChanged

    End Sub
End Class