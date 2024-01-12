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
Public Class ViewGLLinePostings
    Inherits System.Windows.Forms.Form

    Dim CustomerFilter, PartFilter, DateFilter, AccountFilter, VendorFilter As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5 As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub ViewGLLinePostings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdViewByFilters

        LoadCurrentDivision()

        If EmployeeCompanyCode = "ADM" Then
            cboDivisionID.Enabled = True
            cboDivisionID.Text = EmployeeCompanyCode
        Else
            cboDivisionID.Enabled = False
            cboDivisionID.Text = EmployeeCompanyCode
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

    Public Sub ClearDataInDatagridInvoice()
        dgvGLInvoiceLines.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilterInvoice()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboAccountNumber.Text <> "" Then
            AccountFilter = " AND GLAccountNumber = '" + cboAccountNumber.Text + "'"
        Else
            AccountFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            DateFilter = " AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM GLInvoiceLineData WHERE DivisionID = @DivisionID" + CustomerFilter + PartFilter + AccountFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLInvoiceLineData")
        dgvGLInvoiceLines.DataSource = ds.Tables("GLInvoiceLineData")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagridReceiver()
        dgvReceivingLines.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilterReceiver()
        If cboCustomerID.Text <> "" Then
            VendorFilter = " AND VendorCode = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboAccountNumber.Text <> "" Then
            AccountFilter = " AND GLAccountNumber = '" + cboAccountNumber.Text + "'"
        Else
            AccountFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            DateFilter = " AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM GLReceivingLineData WHERE DivisionID = @DivisionID" + VendorFilter + PartFilter + AccountFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLReceivingLineData")
        dgvReceivingLines.DataSource = ds.Tables("GLReceivingLineData")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagridShipment()
        dgvShipmentLines.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilterShipment()
        If cboCustomerID.Text <> "" Then
            CustomerFilter = " AND CustomerID = '" + usefulFunctions.checkQuote(cboCustomerID.Text) + "'"
        Else
            CustomerFilter = ""
        End If
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboAccountNumber.Text <> "" Then
            AccountFilter = " AND GLAccountNumber = '" + cboAccountNumber.Text + "'"
        Else
            AccountFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            DateFilter = " AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM GLShipmentLineData WHERE DivisionID = @DivisionID" + CustomerFilter + PartFilter + AccountFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLShipmentLineData")
        dgvShipmentLines.DataSource = ds.Tables("GLShipmentLineData")
        con.Close()
    End Sub

    Public Sub ClearDataInDatagridProduction()
        dgvWCLines.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilterProduction()
        If cboPartNumber.Text <> "" Then
            PartFilter = " AND PartNumber = '" + usefulFunctions.checkQuote(cboPartNumber.Text) + "'"
        Else
            PartFilter = ""
        End If
        If cboAccountNumber.Text <> "" Then
            AccountFilter = " AND GLAccountNumber = '" + cboAccountNumber.Text + "'"
        Else
            AccountFilter = ""
        End If
        If chkDateRange.Checked = False Then
            DateFilter = ""
        Else
            DateFilter = " AND GLTransactionDate BETWEEN @BeginDate AND @EndDate"
        End If

        cmd = New SqlCommand("SELECT * FROM GLWCProductionLineData WHERE DivisionID = @DivisionID" + PartFilter + AccountFilter + DateFilter, con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = dtpBeginDate.Text
        cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = dtpEndDate.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds = New DataSet()
        myAdapter.SelectCommand = cmd
        myAdapter.Fill(ds, "GLWCProductionLineData")
        dgvWCLines.DataSource = ds.Tables("GLWCProductionLineData")
        con.Close()
    End Sub

    Public Sub LoadItemID()
        cmd = New SqlCommand("SELECT ItemID, ShortDescription FROM ItemList WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd
        myAdapter1.Fill(ds1, "ItemList")
        cboPartNumber.DataSource = ds1.Tables("ItemList")
        cboPartDescription.DataSource = ds1.Tables("ItemList")
        con.Close()
        cboPartNumber.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadCustomerID()
        cmd = New SqlCommand("SELECT CustomerID, CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "CustomerList")
        cboCustomerName.DataSource = ds2.Tables("CustomerList")
        cboCustomerID.DataSource = ds2.Tables("CustomerList")
        con.Close()
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadGLAccounts()
        cmd = New SqlCommand("SELECT GLAccountNumber, GLAccountShortDescription FROM GLAccounts", con)
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "GLAccounts")
        cboAccountNumber.DataSource = ds3.Tables("GLAccounts")
        cboAccountDescription.DataSource = ds3.Tables("GLAccounts")
        con.Close()
        cboAccountNumber.SelectedIndex = -1
        cboAccountDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadVendorID()
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "Vendor")
        cboVendorID.DataSource = ds4.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomerID()
        LoadGLAccounts()
        LoadItemID()
        LoadVendorID()
        ClearVariables()
        ClearData()
    End Sub

    Public Sub ClearVariables()
        CustomerFilter = ""
        PartFilter = ""
        DateFilter = ""
        AccountFilter = ""
        VendorFilter = ""
    End Sub

    Public Sub ClearData()
        cboAccountDescription.SelectedIndex = -1
        cboAccountNumber.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboVendorID.SelectedIndex = -1

        txtVendorName.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        chkDateRange.Checked = False

        rdoInvoice.Checked = True
        rdoInvoice.Focus()
    End Sub

    Private Sub cmdPrintReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintReport.Click
        GDS = ds
        Using NewPrintGLInvoiceLinesFiltered As New PrintGLInvoiceLinesFiltered
            Dim Result = NewPrintGLInvoiceLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintGLInvoiceLinesFiltered As New PrintGLInvoiceLinesFiltered
            Dim Result = NewPrintGLInvoiceLinesFiltered.ShowDialog()
        End Using
    End Sub

    Private Sub rdoInvoice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoInvoice.CheckedChanged
        If rdoInvoice.Checked = True Then
            cboVendorID.Enabled = False
            txtVendorName.Enabled = False
            cboCustomerID.Enabled = True
            cboCustomerName.Enabled = True
            ClearDataInDatagridInvoice()
            dgvGLInvoiceLines.Visible = True
            dgvReceivingLines.Visible = False
            dgvShipmentLines.Visible = False
            dgvWCLines.Visible = False
        End If
    End Sub

    Private Sub rdoReceiver_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoReceiver.CheckedChanged
        If rdoReceiver.Checked = True Then
            cboCustomerID.Enabled = False
            cboCustomerName.Enabled = False
            cboVendorID.Enabled = True
            txtVendorName.Enabled = True
            ClearDataInDatagridReceiver()
            dgvGLInvoiceLines.Visible = False
            dgvReceivingLines.Visible = True
            dgvShipmentLines.Visible = False
            dgvWCLines.Visible = False
        End If
    End Sub

    Private Sub rdoShipment_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoShipment.CheckedChanged
        If rdoShipment.Checked = True Then
            cboVendorID.Enabled = False
            txtVendorName.Enabled = False
            cboCustomerID.Enabled = True
            cboCustomerName.Enabled = True
            ClearDataInDatagridShipment()
            dgvGLInvoiceLines.Visible = False
            dgvReceivingLines.Visible = False
            dgvShipmentLines.Visible = True
            dgvWCLines.Visible = False
        End If
    End Sub

    Private Sub rdoWCProduction_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoWCProduction.CheckedChanged
        If rdoWCProduction.Checked = True Then
            cboVendorID.Enabled = False
            txtVendorName.Enabled = False
            cboCustomerID.Enabled = False
            cboCustomerName.Enabled = False
            ClearDataInDatagridProduction()
            dgvGLInvoiceLines.Visible = False
            dgvReceivingLines.Visible = False
            dgvShipmentLines.Visible = False
            dgvWCLines.Visible = True
        End If
    End Sub

    Private Sub dgvShipmentLines_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvShipmentLines.CellDoubleClick
        Dim RowShipmentNumber As Integer = 0

        Dim RowIndex As Integer = Me.dgvShipmentLines.CurrentCell.RowIndex

        RowShipmentNumber = Me.dgvShipmentLines.Rows(RowIndex).Cells("SHGLReferenceNumberColumn").Value

        GlobalShipmentNumber = RowShipmentNumber
        GlobalDivisionCode = cboDivisionID.Text

        'Choose the correct Print Form (REMOTE or LOCAL)

        'Get Login Type
        Dim GetLoginType As String = ""

        Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
        Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
        GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
        Catch ex As System.Exception
            GetLoginType = ""
        End Try
        con.Close()

        If GetLoginType = "REMOTE" Then
            Using NewPrintPackingListRemote As New PrintPackingListRemote
                Dim Result = NewPrintPackingListRemote.ShowDialog()
            End Using
        Else
            Using NewPrintPackingList As New PrintPackingList
                Dim Result = NewPrintPackingList.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub dgvReceivingLines_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceivingLines.CellDoubleClick
        Dim RowReceiverNumber As Integer = 0

        Dim RowIndex As Integer = Me.dgvReceivingLines.CurrentCell.RowIndex

        RowReceiverNumber = Me.dgvReceivingLines.Rows(RowIndex).Cells("RCGLReferenceNumberColumn").Value

        GlobalReceiverNumber = RowReceiverNumber
        GlobalDivisionCode = cboDivisionID.Text

        Using NewPrintReceiver As New PrintReceiver
            Dim Result = NewPrintReceiver.ShowDialog()
        End Using
    End Sub

    Private Sub dgvGLInvoiceLines_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGLInvoiceLines.CellDoubleClick
        Dim RowInvoiceNumber, RowSONumber, RowShipmentNumber As Integer

        Dim RowIndex As Integer = Me.dgvGLInvoiceLines.CurrentCell.RowIndex

        RowInvoiceNumber = Me.dgvGLInvoiceLines.Rows(RowIndex).Cells("IVGLReferenceNumberColumn").Value
        RowSONumber = Me.dgvGLInvoiceLines.Rows(RowIndex).Cells("IVSalesOrderNumberColumn").Value
        RowShipmentNumber = Me.dgvGLInvoiceLines.Rows(RowIndex).Cells("IVShipmentNumberColumn").Value

        'Choose the Invoice Print Form by division
        If cboDivisionID.Text = "TFF" Or cboDivisionID.Text = "TOR" Or cboDivisionID.Text = "ALB" Then
            If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = cboDivisionID.Text

                'Choose the correct Print Form (REMOTE or LOCAL)

                'Get Login Type
                Dim GetLoginType As String = ""

                Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetLoginType = ""
                End Try
                con.Close()

                If GetLoginType = "REMOTE" Then
                    Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnlyRemote
                        Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                        Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                    End Using
                End If
            Else
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = cboDivisionID.Text

                'Choose the correct Print Form (REMOTE or LOCAL)

                'Get Login Type
                Dim GetLoginType As String = ""

                Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetLoginType = ""
                End Try
                con.Close()

                If GetLoginType = "REMOTE" Then
                    Using NewPrintInvoiceBatch As New PrintInvoiceSingleRemote
                        Dim result = NewPrintInvoiceBatch.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBatch As New PrintInvoiceSingle
                        Dim result = NewPrintInvoiceBatch.ShowDialog()
                    End Using
                End If
            End If
        Else
            If RowShipmentNumber = 0 Or RowSONumber = 0 Then
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = cboDivisionID.Text

                'Choose the correct Print Form (REMOTE or LOCAL)

                'Get Login Type
                Dim GetLoginType As String = ""

                Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetLoginType = ""
                End Try
                con.Close()

                If GetLoginType = "REMOTE" Then
                    Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnlyRemote
                        Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBillOnly As New PrintInvoiceBillOnly
                        Dim result = NewPrintInvoiceBillOnly.ShowDialog()
                    End Using
                End If
            Else
                GlobalInvoiceNumber = RowInvoiceNumber
                GlobalDivisionCode = cboDivisionID.Text

                'Choose the correct Print Form (REMOTE or LOCAL)

                'Get Login Type
                Dim GetLoginType As String = ""

                Dim GetLoginTypeStatement As String = "SELECT MOSLoginType FROM EmployeeData WHERE LoginName = @LoginName"
                Dim GetLoginTypeCommand As New SqlCommand(GetLoginTypeStatement, con)
                GetLoginTypeCommand.Parameters.Add("@LoginName", SqlDbType.VarChar).Value = EmployeeLoginName

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    GetLoginType = CStr(GetLoginTypeCommand.ExecuteScalar)
                Catch ex As System.Exception
                    GetLoginType = ""
                End Try
                con.Close()

                If GetLoginType = "REMOTE" Then
                    Using NewPrintInvoiceBatch As New PrintInvoiceSingleRemote
                        Dim result = NewPrintInvoiceBatch.ShowDialog()
                    End Using
                Else
                    Using NewPrintInvoiceBatch As New PrintInvoiceSingle
                        Dim result = NewPrintInvoiceBatch.ShowDialog()
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub cmdViewByFilters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewByFilters.Click
        If rdoInvoice.Checked = True Then
            ShowDataByFilterInvoice()
        ElseIf rdoReceiver.Checked = True Then
            ShowDataByFilterReceiver()
        ElseIf rdoShipment.Checked = True Then
            ShowDataByFilterShipment()
        ElseIf rdoWCProduction.Checked = True Then
            ShowDataByFilterProduction()
        Else
            ClearData()
            ClearVariables()
            ClearDataInDatagridInvoice()
            ClearDataInDatagridProduction()
            ClearDataInDatagridReceiver()
            ClearDataInDatagridShipment()
        End If
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearVariables()
        ClearDataInDatagridInvoice()
        ClearDataInDatagridProduction()
        ClearDataInDatagridReceiver()
        ClearDataInDatagridShipment()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearVariables()
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub
End Class