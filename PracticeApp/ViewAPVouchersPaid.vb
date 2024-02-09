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
Public Class ViewAPVouchersPaid
    Inherits System.Windows.Forms.Form

    Dim Checked1099Filter, CheckTypeFilter, VendorFilter, POFilter, InvoiceFilter, CheckFilter, BatchFilter, DateFilter As String
    Dim BatchNumber, CheckNumber, PONumber As Integer
    Dim strBatchNumber, strCheckNumber, strPONumber As String
    Dim VendorName As String
    Dim TotalPaidByFilter As Double
    Dim Checked1099 As String = "NO"

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=45")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable
    Dim tenTotal As Decimal = 0
    Dim vendor1099 As String

    Private Sub ViewAPVouchersPaid_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClearData()
        ClearVariables()
    End Sub

    Private Sub ViewAPVouchersPaid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilter

        LoadCurrentDivision()

        If EmployeeSecurityCode = 1001 Or EmployeeSecurityCode = 1002 Then
            gpxPrint1099s.Enabled = True
        Else
            gpxPrint1099s.Enabled = False
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

    Private Sub dgvAPVouchers_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvAPVouchers.CellDoubleClick
        Dim RowVoucherNumber As Integer

        Dim RowIndex As Integer = Me.dgvAPVouchers.CurrentCell.RowIndex

        RowVoucherNumber = Me.dgvAPVouchers.Rows(RowIndex).Cells("VoucherNumberColumn").Value

        GlobalVoucherNumber = RowVoucherNumber
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintVoucher As New PrintVoucher
            Dim Result = NewPrintVoucher.ShowDialog
        End Using
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvAPVouchers.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboCheckType.Text = "ACH" Then
            CheckTypeFilter = " AND CheckType <> 'STANDARD'"
        ElseIf cboCheckType.Text = "CHECK" Then
            CheckTypeFilter = " AND CheckType = 'STANDARD'"
        Else
            CheckTypeFilter = ""
        End If
        If txtInvoiceNumber.Text <> "" Then
            InvoiceFilter = " AND InvoiceNumber LIKE '%" + txtInvoiceNumber.Text + "%'"
        Else
            InvoiceFilter = ""
        End If
        If cboPONumber.Text <> "" Then
            PONumber = Val(cboPONumber.Text)
            strPONumber = CStr(PONumber)
            POFilter = " AND PONumber = '" + strPONumber + "'"
        Else
            POFilter = ""
        End If
        If cboBatchNumber.Text <> "" Then
            BatchNumber = Val(cboBatchNumber.Text)
            strBatchNumber = CStr(BatchNumber)
            BatchFilter = " AND APBatchNumber = '" + strBatchNumber + "'"
        Else
            BatchFilter = ""
        End If
        If txtCheckNumber.Text <> "" Then
            CheckNumber = Val(txtCheckNumber.Text)
            strCheckNumber = CStr(CheckNumber)
            CheckFilter = " AND CheckNumber = '" + strCheckNumber + "'"
        Else
            CheckFilter = ""
        End If
        If chkChecked1099.Checked = True Then
            Checked1099Filter = " AND Checked1099 = 'YES'"
        Else
            Checked1099Filter = ""
        End If
        If chkDateRange.Checked = True Then
            If rdoInvoiceDate.Checked = True Then
                DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            ElseIf rdoPaymentDate.Checked = True Then
                DateFilter = " AND PaidDate BETWEEN @BeginDate AND @EndDate"
            End If
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM APCheckQuery WHERE DivisionID = @DivisionID AND CheckStatus = @CheckStatus" + VendorFilter + CheckTypeFilter + InvoiceFilter + CheckFilter + POFilter + BatchFilter + Checked1099Filter + DateFilter + " ORDER BY VendorID, InvoiceDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        cmd.Parameters.Add("@CheckStatus", SqlDbType.VarChar).Value = "POSTED"
        cmd.CommandTimeout = 0
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APCheckQuery")
        dgvAPVouchers.DataSource = ds.Tables("APCheckQuery")
        con.Close()

        FormatDatagrid()
    End Sub

    Public Sub ShowDataByFilters1099()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboCheckType.Text = "ACH" Then
            CheckTypeFilter = " AND CheckType <> 'STANDARD'"
        ElseIf cboCheckType.Text = "CHECK" Then
            CheckTypeFilter = " AND CheckType = 'STANDARD'"
        Else
            CheckTypeFilter = ""
        End If
        If txtInvoiceNumber.Text <> "" Then
            InvoiceFilter = " AND InvoiceNumber LIKE '%" + txtInvoiceNumber.Text + "%'"
        Else
            InvoiceFilter = ""
        End If
        If cboPONumber.Text <> "" Then
            PONumber = Val(cboPONumber.Text)
            strPONumber = CStr(PONumber)
            POFilter = " AND PONumber = '" + strPONumber + "'"
        Else
            POFilter = ""
        End If
        If cboBatchNumber.Text <> "" Then
            BatchNumber = Val(cboBatchNumber.Text)
            strBatchNumber = CStr(BatchNumber)
            BatchFilter = " AND APBatchNumber = '" + strBatchNumber + "'"
        Else
            BatchFilter = ""
        End If
        If txtCheckNumber.Text <> "" Then
            CheckNumber = Val(txtCheckNumber.Text)
            strCheckNumber = CStr(CheckNumber)
            CheckFilter = " AND CheckNumber = '" + strCheckNumber + "'"
        Else
            CheckFilter = ""
        End If
        If chkDateRange.Checked = True Then
            If rdoInvoiceDate.Checked = True Then
                DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            ElseIf rdoPaymentDate.Checked = True Then
                DateFilter = " AND PaidDate BETWEEN @BeginDate AND @EndDate"
            End If
        Else
            DateFilter = ""
        End If

        Dim TotalPaidByFilterString As String = "SELECT SUM(PaymentAmount) FROM APCheckQuery WHERE DivisionID = @DivisionID AND (VendorID = @VendorID1 OR VendorID = @VendorID2 OR VendorID = @VendorID3 OR VendorID = @VendorID4)" + POFilter + VendorFilter + CheckTypeFilter + BatchFilter + CheckFilter + InvoiceFilter + Checked1099Filter + DateFilter
        Dim TotalPaidByFilterCommand As New SqlCommand(TotalPaidByFilterString, con)
        TotalPaidByFilterCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalPaidByFilterCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TotalPaidByFilterCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        TotalPaidByFilterCommand.Parameters.Add("@VendorID1", SqlDbType.VarChar).Value = "REUSCHKEDIV"
        TotalPaidByFilterCommand.Parameters.Add("@VendorID2", SqlDbType.VarChar).Value = "WORKMANREDIV"
        TotalPaidByFilterCommand.Parameters.Add("@VendorID3", SqlDbType.VarChar).Value = "WORKMANPETERDIV"
        TotalPaidByFilterCommand.Parameters.Add("@VendorID4", SqlDbType.VarChar).Value = "WORKMANPATRICIADIV"
        TotalPaidByFilterCommand.Parameters.Add("@Checked1099", SqlDbType.VarChar).Value = "YES"
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            Dim total As Double
            Dim stringthrow As String = ""
            stringthrow = TotalPaidByFilterCommand.ExecuteScalar.ToString
            total = CDbl(stringthrow)

            'total = CDbl(Val(txtPaymentTotal.Text))
            GlobalVariables.dblVar3 = GlobalVariables.dblVar3 - total
        Catch ex As Exception

        End Try
        con.Close()

        cmd = New SqlCommand("SELECT * FROM APCheckQuery WHERE Checked1099 = @Checked1099 AND DivisionID = @DivisionID AND (VendorID <> @VendorID1 OR VendorID <> @VendorID2 OR VendorID <> @VendorID3 OR VendorID <> @VendorID4)" + DateFilter + " ORDER BY VendorID, InvoiceDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        cmd.Parameters.Add("@VendorID1", SqlDbType.VarChar).Value = "REUSCHKEDIV"
        cmd.Parameters.Add("@VendorID2", SqlDbType.VarChar).Value = "WORKMANREDIV"
        cmd.Parameters.Add("@VendorID3", SqlDbType.VarChar).Value = "WORKMANPETERDIV"
        cmd.Parameters.Add("@VendorID4", SqlDbType.VarChar).Value = "WORKMANPATRICIADIV"
        cmd.Parameters.Add("@Checked1099", SqlDbType.VarChar).Value = "YES"
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APCheckQuery")
        dgvAPVouchers.DataSource = ds.Tables("APCheckQuery")

        cmd = New SqlCommand("SELECT * FROM APCheckQuery WHERE Checked1099 = @Checked1099 AND DivisionID = @DivisionID AND (VendorID <> @VendorID1 OR VendorID <> @VendorID2 OR VendorID <> @VendorID3 OR VendorID <> @VendorID4)" + DateFilter + " ORDER BY VendorID, InvoiceDate", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        cmd.Parameters.Add("@VendorID1", SqlDbType.VarChar).Value = "REUSCHKEDIV"
        cmd.Parameters.Add("@VendorID2", SqlDbType.VarChar).Value = "WORKMANREDIV"
        cmd.Parameters.Add("@VendorID3", SqlDbType.VarChar).Value = "WORKMANPETERDIV"
        cmd.Parameters.Add("@VendorID4", SqlDbType.VarChar).Value = "WORKMANPATRICIADIV"
        cmd.Parameters.Add("@Checked1099", SqlDbType.VarChar).Value = "YES"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds2, "APCheckQuery")
        dgvAPVouchers.DataSource = ds2.Tables("APCheckQuery")
        con.Close()

        cmd2 = New SqlCommand("SELECT COUNT(DISTINCT VendorName) FROM APCheckQuery WHERE Checked1099 = @Checked1099 AND DivisionID = @DivisionID AND (VendorID <> @VendorID1 OR VendorID <> @VendorID2 OR VendorID <> @VendorID3 OR VendorID <> @VendorID4)" + DateFilter, con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd2.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd2.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        cmd2.Parameters.Add("@VendorID1", SqlDbType.VarChar).Value = "REUSCHKEDIV"
        cmd2.Parameters.Add("@VendorID2", SqlDbType.VarChar).Value = "WORKMANREDIV"
        cmd2.Parameters.Add("@VendorID3", SqlDbType.VarChar).Value = "WORKMANPETERDIV"
        cmd2.Parameters.Add("@VendorID4", SqlDbType.VarChar).Value = "WORKMANPATRICIADIV"
        cmd2.Parameters.Add("@Checked1099", SqlDbType.VarChar).Value = "YES"
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GlobalVariables.stringVar = cmd2.ExecuteScalar.ToString

        Catch ex As Exception

        End Try
        con.Close()

        If cboDivisionID.Text = "TWD" Then
            cmd3 = New SqlCommand("SELECT * FROM APCheckQuery WHERE Checked1099 = @Checked1099 AND DivisionID = @DivisionID AND (VendorID = @VendorID1 or VendorID = @VendorID2 or VendorID = @VendorID3 or VendorID = @VendorID4)" + DateFilter + " ORDER BY VendorID, InvoiceDate", con)
            cmd3.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd3.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            cmd3.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
            cmd3.Parameters.Add("@VendorID1", SqlDbType.VarChar).Value = "REUSCHKEDIV"
            cmd3.Parameters.Add("@VendorID2", SqlDbType.VarChar).Value = "WORKMANREDIV"
            cmd3.Parameters.Add("@VendorID3", SqlDbType.VarChar).Value = "WORKMANPETERDIV"
            cmd3.Parameters.Add("@VendorID4", SqlDbType.VarChar).Value = "WORKMANPATRICIADIV"
            cmd3.Parameters.Add("@Checked1099", SqlDbType.VarChar).Value = "YES"
            '
            If con.State = ConnectionState.Closed Then con.Open()
            ds3 = New DataSet()
            myAdapter.SelectCommand = cmd3
            myAdapter.Fill(ds3, "APCheckQuery")
            con.Close()

            cmd2 = New SqlCommand("SELECT COUNT(DISTINCT VendorName) FROM APCheckQuery WHERE Checked1099 = @Checked1099 AND DivisionID = @DivisionID AND (VendorID = @VendorID1 or VendorID = @VendorID2 or VendorID = @VendorID3 or VendorID = @VendorID4)" + DateFilter, con)
            cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "TWD"
            cmd2.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
            cmd2.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
            cmd2.Parameters.Add("@Checked1099", SqlDbType.VarChar).Value = "YES"
            cmd2.Parameters.Add("@VendorID1", SqlDbType.VarChar).Value = "REUSCHKEDIV"
            cmd2.Parameters.Add("@VendorID2", SqlDbType.VarChar).Value = "WORKMANREDIV"
            cmd2.Parameters.Add("@VendorID3", SqlDbType.VarChar).Value = "WORKMANPETERDIV"
            cmd2.Parameters.Add("@VendorID4", SqlDbType.VarChar).Value = "WORKMANPATRICIADIV"
            '
            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GlobalVariables.stringVar2 = cmd2.ExecuteScalar.ToString

            Catch ex As Exception

            End Try
            con.Close()
        End If

        GDS = ds
        GDS1 = ds2
        GDS2 = ds3
        FormatDatagrid()
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

    Public Sub LoadBatchNumber()
        cmd = New SqlCommand("SELECT DISTINCT APBatchNumber FROM APCheckQuery WHERE DivisionID = @DivisionID ORDER BY APBatchNumber DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "APCheckQuery")
        cboBatchNumber.DataSource = ds3.Tables("APCheckQuery")
        con.Close()
        cboBatchNumber.SelectedIndex = -1
    End Sub

    Public Sub LoadPONumber()
        cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable WHERE DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "PurchaseOrderHeaderTable")
        cboPONumber.DataSource = ds4.Tables("PurchaseOrderHeaderTable")
        con.Close()
        cboPONumber.SelectedIndex = -1
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

        Dim Vendor1099String As String = "SELECT Checked1099 FROM Vendor WHERE VendorCode = @VendorCode AND DivisionID = @DivisionID"
        Dim Vendor1099Command As New SqlCommand(Vendor1099String, con)
        VendorNameCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text
        VendorNameCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            vendor1099 = CStr(VendorNameCommand.ExecuteScalar)
        Catch ex As Exception
            vendor1099 = ""
        End Try
        con.Close()

        txtVendorName.Text = VendorName
        txtPaymentTotal.Text = vendor1099
        'If vendor1099 = "YES" Then
        'cmdVendor1099.Enabled = True
        'Else
        'cmdVendor1099.Enabled = False

        'End If
    End Sub

    Public Sub FormatDatagrid()
        Dim CheckType As String = ""

        Dim RowIndex As Integer = 0

        For Each row As DataGridViewRow In dgvAPVouchers.Rows
            Try
                CheckType = row.Cells("CheckTypeColumn").Value
            Catch ex As System.Exception
                CheckType = ""
            End Try

            If CheckType = "STANDARD" Then
                Me.dgvAPVouchers.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Black
            Else
                Me.dgvAPVouchers.Rows(RowIndex).DefaultCellStyle.ForeColor = Color.Blue
            End If

            RowIndex = RowIndex + 1
        Next
    End Sub

    Public Sub LoadTotalPaidByFilter()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboCheckType.Text = "ACH" Then
            CheckTypeFilter = " AND CheckType <> 'STANDARD'"
        ElseIf cboCheckType.Text = "CHECK" Then
            CheckTypeFilter = " AND CheckType = 'STANDARD'"
        Else
            CheckTypeFilter = ""
        End If
        If txtInvoiceNumber.Text <> "" Then
            InvoiceFilter = " AND InvoiceNumber LIKE '%" + txtInvoiceNumber.Text + "%'"
        Else
            InvoiceFilter = ""
        End If
        If cboPONumber.Text <> "" Then
            PONumber = Val(cboPONumber.Text)
            strPONumber = CStr(PONumber)
            POFilter = " AND PONumber = '" + strPONumber + "'"
        Else
            POFilter = ""
        End If
        If cboBatchNumber.Text <> "" Then
            BatchNumber = Val(cboBatchNumber.Text)
            strBatchNumber = CStr(BatchNumber)
            BatchFilter = " AND APBatchNumber = '" + strBatchNumber + "'"
        Else
            BatchFilter = ""
        End If
        If txtCheckNumber.Text <> "" Then
            CheckNumber = Val(txtCheckNumber.Text)
            strCheckNumber = CStr(CheckNumber)
            CheckFilter = " AND CheckNumber = '" + strCheckNumber + "'"
        Else
            CheckFilter = ""
        End If
        If chkChecked1099.Checked = True Then
            Checked1099Filter = " AND Checked1099 = 'YES'"
            gpxPrint1099s.Enabled = True
        Else
            Checked1099Filter = ""
            gpxPrint1099s.Enabled = False
        End If
        If chkDateRange.Checked = True Then
            If rdoInvoiceDate.Checked = True Then
                DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            ElseIf rdoPaymentDate.Checked = True Then
                DateFilter = " AND PaidDate BETWEEN @BeginDate AND @EndDate"
            End If
        Else
            DateFilter = ""
        End If

        Dim TotalPaidByFilterString As String = "SELECT SUM(PaymentAmount) FROM APCheckQuery WHERE DivisionID = @DivisionID " + POFilter + VendorFilter + CheckTypeFilter + BatchFilter + CheckFilter + InvoiceFilter + Checked1099Filter + DateFilter
        Dim TotalPaidByFilterCommand As New SqlCommand(TotalPaidByFilterString, con)
        TotalPaidByFilterCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalPaidByFilterCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TotalPaidByFilterCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalPaidByFilter = CDbl(TotalPaidByFilterCommand.ExecuteScalar)
            GlobalVariables.dblVar3 = TotalPaidByFilter
        Catch ex As Exception
            TotalPaidByFilter = 0
            GlobalVariables.dblVar3 = 0
        End Try
        con.Close()

        txtPaymentTotal.Text = FormatCurrency(TotalPaidByFilter, 2)
    End Sub

    Public Sub LoadTotalPaidByFilter1099()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboCheckType.Text = "ACH" Then
            CheckTypeFilter = " AND CheckType <> 'STANDARD'"
        ElseIf cboCheckType.Text = "CHECK" Then
            CheckTypeFilter = " AND CheckType = 'STANDARD'"
        Else
            CheckTypeFilter = ""
        End If
        If txtInvoiceNumber.Text <> "" Then
            InvoiceFilter = " AND InvoiceNumber LIKE '%" + txtInvoiceNumber.Text + "%'"
        Else
            InvoiceFilter = ""
        End If
        If cboPONumber.Text <> "" Then
            PONumber = Val(cboPONumber.Text)
            strPONumber = CStr(PONumber)
            POFilter = " AND PONumber = '" + strPONumber + "'"
        Else
            POFilter = ""
        End If
        If cboBatchNumber.Text <> "" Then
            BatchNumber = Val(cboBatchNumber.Text)
            strBatchNumber = CStr(BatchNumber)
            BatchFilter = " AND BatchNumber = '" + strBatchNumber + "'"
        Else
            BatchFilter = ""
        End If
        
        If chkDateRange.Checked = True Then
            If rdoInvoiceDate.Checked = True Then
                DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
            ElseIf rdoPaymentDate.Checked = True Then
                DateFilter = " AND PaidDate BETWEEN @BeginDate AND @EndDate"
            End If
        Else
            DateFilter = ""
        End If

        Dim TotalPaidByFilterString As String = "SELECT SUM(PaymentAmount) FROM APVoucherTable WHERE DivisionID = @DivisionID AND Checked1099 = 'YES'" + POFilter + VendorFilter + CheckTypeFilter + BatchFilter + CheckFilter + InvoiceFilter + DateFilter
        Dim TotalPaidByFilterCommand As New SqlCommand(TotalPaidByFilterString, con)
        TotalPaidByFilterCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalPaidByFilterCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        TotalPaidByFilterCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        TotalPaidByFilterCommand.Parameters.Add("@Checked1099", SqlDbType.VarChar).Value = "YES"

        gpxPrint1099s.Enabled = True

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalPaidByFilter = CDbl(TotalPaidByFilterCommand.ExecuteScalar)
        Catch ex As Exception
            TotalPaidByFilter = 0
        End Try
        con.Close()
    End Sub

    Public Sub VendorCheckedShow()
        ClearDataInDatagrid()
        cmd2 = New SqlCommand("SELECT VendorCode from Vendor WHERE DivisionID = @DivisionID AND Checked1099 = 'YES'", con)
        cmd2.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        Dim vendorName As New List(Of String)
        ds2 = New DataSet

        Using reader As SqlDataReader = cmd2.ExecuteReader
            While reader.Read()
                vendorName.Add(reader.GetString(reader.GetOrdinal("VendorCode")))
            End While
        End Using

        Dim counter = vendorName.Count
        Dim i As Integer = 0
        While i < counter
            Try
                If cboCheckType.Text = "ACH" Then
                    CheckTypeFilter = " AND CheckType <> 'STANDARD'"
                ElseIf cboCheckType.Text = "CHECK" Then
                    CheckTypeFilter = " AND CheckType = 'STANDARD'"
                Else
                    CheckTypeFilter = ""
                End If
                If chkDateRange.Checked = True Then
                    If rdoInvoiceDate.Checked = True Then
                        DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
                    ElseIf rdoPaymentDate.Checked = True Then
                        DateFilter = " AND PaidDate BETWEEN @BeginDate AND @EndDate"
                    End If
                Else
                    DateFilter = ""
                End If

                cmd = New SqlCommand("SELECT * FROM APCheckQuery WHERE DivisionID = @DivisionID AND VendorID = @VendorID" + CheckTypeFilter + DateFilter + " ORDER BY VendorID, InvoiceDate", con)
                cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
                cmd.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = vendorName(i)
                cmd.CommandTimeout = 0
                If con.State = ConnectionState.Closed Then con.Open()
                ds3 = New DataSet()
                myAdapter.SelectCommand = cmd
                myAdapter.Fill(ds3, "APCheckQuery")
                con.Close()
                ds2.Merge(ds3, False, MissingSchemaAction.Add)
            Catch ex As Exception

            End Try
            i = i + 1

        End While

        dgvAPVouchers.DataSource = ds2.Tables("APCheckQuery")
        FormatDatagrid()
    End Sub

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Private Sub cmdViewByFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilter.Click
        ShowDataByFilters()
        LoadTotalPaidByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadPONumber()
        LoadVendorID()
        LoadBatchNumber()
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearData()
        cboVendorID.Text = ""
        cboBatchNumber.Text = ""
        cboPONumber.Text = ""

        cboVendorID.SelectedIndex = -1
        cboBatchNumber.SelectedIndex = -1
        cboPONumber.SelectedIndex = -1
        cboCheckType.SelectedIndex = -1

        txtVendorName.Clear()
        txtCheckNumber.Clear()
        txtInvoiceNumber.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False
        chkChecked1099.Checked = False

        cboVendorID.Focus()
    End Sub

    Public Sub ClearVariables()
        VendorFilter = ""
        POFilter = ""
        InvoiceFilter = ""
        CheckFilter = ""
        BatchFilter = ""
        DateFilter = ""
        CheckTypeFilter = ""
        BatchNumber = 0
        CheckNumber = 0
        PONumber = 0
        strBatchNumber = ""
        strCheckNumber = ""
        strPONumber = ""
        VendorName = ""
        TotalPaidByFilter = 0
        Checked1099 = "NO"
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        If cboVendorID.Text <> "" Then
            'Get Vendor Email
            Dim GetVendorEmailString As String = "SELECT RemittanceEmail FROM Vendor WHERE DivisionID = @DivisionID AND VendorCode = @VendorCode"
            Dim GetVendorEmailCommand As New SqlCommand(GetVendorEmailString, con)
            GetVendorEmailCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            GetVendorEmailCommand.Parameters.Add("@VendorCode", SqlDbType.VarChar).Value = cboVendorID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                GlobalVendorRemittanceEmail = CStr(GetVendorEmailCommand.ExecuteScalar)
            Catch ex As Exception
                GlobalVendorRemittanceEmail = ""
            End Try
            con.Close()
            If GlobalVendorRemittanceEmail <> "" Then
                GlobalVendorIsLoaded = "TRUE"
            Else
                GlobalVendorIsLoaded = "FALSE"
            End If
        Else
            'Skip
            GlobalVendorIsLoaded = "FALSE"
        End If

        GDS = ds
        GDS1 = ds
        Using NewPrintAPVoucherPaidList As New PrintAPVoucherPaidList
            Dim Result = NewPrintAPVoucherPaidList.ShowDialog
        End Using
    End Sub

    Private Sub PrintVoucherListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintVoucherListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintAPVoucherPaidList As New PrintAPVoucherPaidList
            Dim Result = NewPrintAPVoucherPaidList.ShowDialog
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        ClearVariables()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub dgvAPVouchers_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAPVouchers.CellValueChanged
        Dim check As String
        Dim checkCounter As Integer
        tenTotal = 0
        checkCounter = 0
      
        Try
            For i As Integer = 0 To dgvAPVouchers.Rows.Count - 1

                If Not IsDBNull(dgvAPVouchers.Rows(i).Cells("Checked1099Column").Value) Then
                    check = dgvAPVouchers.Rows(i).Cells("Checked1099Column").Value 'checkbox being the name of the column
                Else
                    check = "NO"
                End If

                Dim voucherNumber As String = dgvAPVouchers.Rows(i).Cells("VoucherNumberColumn").Value
                Dim vendorID As String = dgvAPVouchers.Rows(i).Cells("VendorIDColumn").Value
                Dim invoiceNumber As String = dgvAPVouchers.Rows(i).Cells("InvoiceNumberColumn").Value
                Dim POnumber As String = dgvAPVouchers.Rows(i).Cells("PONumberDataGridViewTextBoxColumn").Value

                If check = "YES" Then

                    Dim I099Statement As String = "Update APCheckQuery SET Checked1099 = @Checked1099 WHERE VoucherNumber = @VoucherNumber AND VendorID = @VendorID AND InvoiceNumber = @InvoiceNumber AND PONumber = @PONumber"
                    Dim I099Command As New SqlCommand(I099Statement, con)
                    I099Command.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = voucherNumber
                    I099Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = vendorID
                    I099Command.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = invoiceNumber
                    I099Command.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = POnumber
                    I099Command.Parameters.Add("@Checked1099", SqlDbType.VarChar).Value = "YES"

                    If con.State = ConnectionState.Closed Then con.Open()
                    I099Command.ExecuteNonQuery()
                    con.Close()
                    checkCounter = checkCounter + 1

                End If

                If check = "NO" Then
                    Dim I099Statement As String = "Update APVoucherTable SET Checked1099 = @Checked1099 WHERE VoucherNumber = @VoucherNumber AND VendorID = @VendorID AND InvoiceNumber = @InvoiceNumber AND PONumber = @PONumber"
                    Dim I099Command As New SqlCommand(I099Statement, con)
                    I099Command.Parameters.Add("@VoucherNumber", SqlDbType.VarChar).Value = voucherNumber
                    I099Command.Parameters.Add("@VendorID", SqlDbType.VarChar).Value = vendorID
                    I099Command.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = invoiceNumber
                    I099Command.Parameters.Add("@PONumber", SqlDbType.VarChar).Value = POnumber
                    I099Command.Parameters.Add("@Checked1099", SqlDbType.VarChar).Value = "NO"

                    If con.State = ConnectionState.Closed Then con.Open()
                    I099Command.ExecuteNonQuery()
                    con.Close()
                End If
            Next

            If checkCounter > 0 Then
                gpxPrint1099s.Enabled = True
            End If
        Catch ex As SqlException
            ' Do some logging or something. 
            MessageBox.Show("There was an error accessing your data. DETAIL: " & ex.ToString())
        End Try

        
    End Sub

    Private Sub dgvAPVouchers_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAPVouchers.ColumnHeaderMouseClick
        FormatDatagrid()
    End Sub

    Private Sub cmdPrint1099s_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Validation
        ShowDataByFilters1099()

        If dgvAPVouchers.RowCount = 0 Then
            MsgBox("You must load data into the datagrid.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            Dim I099 As New Print1099Form
            I099.Show()
        End If
    End Sub

    Private Sub cmd1099_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1099.Click
        ShowDataByFilters1099()
        Dim I099 As New Print1099Form
        I099.Show()
        Dim I096 As New Print1096Form
        I096.Show()
        If cboDivisionID.Text = "TWD" Then
            Dim I096DIV As New Print1096DivForm
            I096DIV.Show()
            Dim I099DIV As New Print1099DIVForm
            I099DIV.Show()
        End If


    End Sub

    Private Sub cmdVendor1099_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVendor1099.Click
        VendorCheckedShow()
    End Sub

    Private Sub chkChecked1099_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkChecked1099.CheckedChanged
        If chkChecked1099.Enabled Then
            cmdVendor1099.Enabled = True
        Else
            cmdVendor1099.Enabled = False
        End If
    End Sub

    Private Sub dgvAPVouchers_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAPVouchers.CellContentClick

    End Sub

    Private Sub gpxAPVoucherData_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gpxAPVoucherData.Enter

    End Sub

    Private Sub cmdPrint1099Misc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint1099Misc.Click
        Dim newPrint1099Misc As New View1099Misc
        newPrint1099Misc.Show()
    End Sub
End Class

Public Class GlobalVoucher
    Public Shared stringVar As String = ""
End Class