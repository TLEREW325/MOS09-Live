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
Public Class ViewAPAging
    Inherits System.Windows.Forms.Form

    Dim VendorFilter, DateFilter, Less30Filter, A3045Filter, A4660Filter, A6190Filter, Over90Filter, InvoiceFilter, VendorClassFilter As String
    Dim SumPayableTotal As Double
    Dim VendorName As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewAPAging_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        LoadCurrentDivision()
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

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            LoadVendorClassCanadian()
        Else
            LoadVendorClassStandard()
        End If

        LoadVendorID()
        LoadInvoiceNumber()
        ClearVariables()
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvAPAging.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilters()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboInvoiceNumber.Text <> "" Then
            InvoiceFilter = " AND InvoiceNumber = '" + cboInvoiceNumber.Text + "'"
        Else
            InvoiceFilter = ""
        End If
        If cboVendorClass.Text <> "" Then
            VendorClassFilter = " AND VendorClass = '" + cboVendorClass.Text + "'"
        Else
            VendorClassFilter = ""
        End If
        If chkLessthan30.Checked Then
            Less30Filter = " AND AgingLessThan30 <> 0"
        Else
            Less30Filter = ""
        End If
        If chkLessthan45.Checked Then
            A3045Filter = " AND Aging31To45 <> 0"
        Else
            A3045Filter = ""
        End If
        If chkLessThan60.Checked Then
            A4660Filter = " AND Aging46To60 <> 0"
        Else
            A4660Filter = ""
        End If
        If chkLessThan90.Checked Then
            A6190Filter = " AND Aging61To90 <> 0"
        Else
            A6190Filter = ""
        End If
        If chkOver90.Checked Then
            Over90Filter = " AND AgingMoreThan90 <> 0"
        Else
            Over90Filter = ""
        End If
        If chkDateRange.Checked Then
            DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        cmd = New SqlCommand("SELECT * FROM APAgingCategory WHERE DivisionID = @DivisionID" + VendorFilter + VendorClassFilter + InvoiceFilter + A3045Filter + A4660Filter + A6190Filter + Less30Filter + Over90Filter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "APAgingCategory")
        dgvAPAging.DataSource = ds.Tables("APAgingCategory")
        con.Close()
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

    Public Sub LoadVendorClassCanadian()
        cmd = New SqlCommand("SELECT VendClassID FROM VendorClass WHERE ClassMode = @ClassMode", con)
        cmd.Parameters.Add("@ClassMode", SqlDbType.VarChar).Value = "CANADIAN"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "VendorClass")
        cboVendorClass.DataSource = ds3.Tables("VendorClass")
        con.Close()
        cboVendorClass.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorClassStandard()
        cmd = New SqlCommand("SELECT VendClassID FROM VendorClass WHERE ClassMode = @ClassMode", con)
        cmd.Parameters.Add("@ClassMode", SqlDbType.VarChar).Value = "STANDARD"
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "VendorClass")
        cboVendorClass.DataSource = ds3.Tables("VendorClass")
        con.Close()
        cboVendorClass.SelectedIndex = -1
    End Sub

    Public Sub LoadInvoiceNumber()
        cmd = New SqlCommand("SELECT InvoiceNumber FROM APVoucherTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "APVoucherTable")
        cboInvoiceNumber.DataSource = ds4.Tables("APVoucherTable")
        con.Close()
        cboInvoiceNumber.SelectedIndex = -1
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

    Private Sub cboVendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendorID.SelectedIndexChanged
        LoadVendorName()
    End Sub

    Public Sub ClearData()
        cboInvoiceNumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1
        cboVendorClass.SelectedIndex = -1

        txtVendorName.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False
        chkLessthan30.Checked = False
        chkLessthan45.Checked = False
        chkLessThan60.Checked = False
        chkLessThan90.Checked = False
        chkOver90.Checked = False

        cboVendorID.Focus()
    End Sub

    Public Sub ClearVariables()
        VendorFilter = ""
        DateFilter = ""
        Less30Filter = ""
        A3045Filter = ""
        A4660Filter = ""
        A6190Filter = ""
        Over90Filter = ""
        InvoiceFilter = ""
        VendorClassFilter = ""
        SumPayableTotal = 0
        VendorName = ""
    End Sub

    Public Sub LoadPayableTotalByFilters()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboInvoiceNumber.Text <> "" Then
            InvoiceFilter = " AND InvoiceNumber = '" + cboInvoiceNumber.Text + "'"
        Else
            InvoiceFilter = ""
        End If
        If cboVendorClass.Text <> "" Then
            VendorClassFilter = " AND VendorClass = '" + cboVendorClass.Text + "'"
        Else
            VendorClassFilter = ""
        End If
        If chkLessthan30.Checked Then
            Less30Filter = " AND AgingLessThan30 <> 0"
        Else
            Less30Filter = ""
        End If
        If chkLessthan45.Checked Then
            A3045Filter = " AND Aging31To45 <> 0"
        Else
            A3045Filter = ""
        End If
        If chkLessThan60.Checked Then
            A4660Filter = " AND Aging46To60 <> 0"
        Else
            A4660Filter = ""
        End If
        If chkLessThan90.Checked Then
            A6190Filter = " AND Aging61To90 <> 0"
        Else
            A6190Filter = ""
        End If
        If chkOver90.Checked Then
            Over90Filter = " AND AgingMoreThan90 <> 0"
        Else
            Over90Filter = ""
        End If
        If chkDateRange.Checked Then
            DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        Dim SumPayableTotalStatement As String = "SELECT SUM(InvoiceAmountOpen) FROM APAgingCategory WHERE DivisionID = @DivisionID" + VendorFilter + VendorClassFilter + InvoiceFilter + A3045Filter + A4660Filter + A6190Filter + Less30Filter + Over90Filter + DateFilter
        Dim SumPayableTotalCommand As New SqlCommand(SumPayableTotalStatement, con)
        SumPayableTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        SumPayableTotalCommand.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        SumPayableTotalCommand.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumPayableTotal = CDbl(SumPayableTotalCommand.ExecuteScalar)
        Catch ex As Exception
            SumPayableTotal = 0
        End Try
        con.Close()

        txtOpenPayableTotal.Text = FormatCurrency(SumPayableTotal, 2)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintAPAging As New PrintAPAging
            Dim result = NewPrintAPAging.ShowDialog()
        End Using
    End Sub

    Private Sub PrintAgingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintAgingToolStripMenuItem.Click
        GlobalDivisionCode = cboDivisionID.Text
        Using NewPrintAPAging As New PrintAPAging
            Dim result = NewPrintAPAging.ShowDialog()
        End Using
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        ShowDataByFilters()
        LoadPayableTotalByFilters()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagrid()
    End Sub
End Class