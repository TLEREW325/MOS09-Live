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
Public Class ViewVendorSummary
    Inherits System.Windows.Forms.Form

    Dim VendorName, DateFilter, POFilter, ReceiverFilter, VendorFilter, InvoiceFilter As String
    Dim BeginDate, EndDate As Date
    Dim PONumber, ReceiverNumber As Integer
    Dim strPONumber, strReceiverNumber As String

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Private Sub ViewVendorSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcceptButton = cmdView

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

    Private Sub dgvROIBatchLines_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvROIBatchLines.CellDoubleClick
        If Me.dgvROIBatchLines.RowCount = 0 Then
            'Do nothing
        Else
            Dim RowVendor As String
            Dim RowIndex As Integer = Me.dgvROIBatchLines.CurrentCell.RowIndex

            RowVendor = Me.dgvROIBatchLines.Rows(RowIndex).Cells("VendorIDColumn").Value.ToString

            GlobalVendorID = RowVendor
            GlobalDivisionCode = cboDivisionID.Text

            Using NewPrintVendorPurchases As New PrintVendorPurchases
                Dim Result = NewPrintVendorPurchases.ShowDialog()
            End Using
        End If
    End Sub

    Public Sub ClearDataInDatagrid()
        dgvROIBatchLines.DataSource = Nothing
    End Sub

    Public Sub ShowDataByFilter()
        If cboVendorID.Text <> "" Then
            VendorFilter = " AND VendorID = '" + usefulFunctions.checkQuote(cboVendorID.Text) + "'"
        Else
            VendorFilter = ""
        End If
        If cboPONumber.Text <> "" Then
            PONumber = Val(cboPONumber.Text)
            strPONumber = CStr(PONumber)
            POFilter = " AND PONumber = '" + strPONumber + "'"
        Else
            POFilter = ""
        End If
        If cboReceiverNumber.Text <> "" Then
            ReceiverNumber = Val(cboReceiverNumber.Text)
            strReceiverNumber = CStr(ReceiverNumber)
            ReceiverFilter = " AND DeleteReferenceNumber = '" + strReceiverNumber + "'"
        Else
            ReceiverFilter = ""
        End If
        If txtInvoiceNumber.Text <> "" Then
            InvoiceFilter = " AND InvoiceNumber = '" + txtInvoiceNumber.Text + "'"
        Else
            InvoiceFilter = ""
        End If
        If chkDateRange.Checked = True Then
            BeginDate = dtpBeginDate.Value
            EndDate = dtpEndDate.Value

            DateFilter = " AND InvoiceDate BETWEEN @BeginDate AND @EndDate"
        Else
            DateFilter = ""
        End If

        If cboDivisionID.Text = "ADM" Then
            cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE DivisionID <> @DivisionID" + POFilter + ReceiverFilter + VendorFilter + InvoiceFilter + DateFilter + " ORDER BY DivisionID, VoucherNumber", con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = "ADM"
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
            dgvROIBatchLines.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")
            con.Close()
            Me.dgvROIBatchLines.Columns("DivisionIDColumn").Visible = True
        Else
            cmd = New SqlCommand("SELECT * FROM ReceiptOfInvoiceBatchLine WHERE DivisionID = @DivisionID" + POFilter + ReceiverFilter + VendorFilter + InvoiceFilter + DateFilter, con)
            cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            cmd.Parameters.Add("@BeginDate", SqlDbType.VarChar).Value = BeginDate
            cmd.Parameters.Add("@EndDate", SqlDbType.VarChar).Value = EndDate
            If con.State = ConnectionState.Closed Then con.Open()
            ds = New DataSet()
            myAdapter.SelectCommand = cmd
            myAdapter.Fill(ds, "ReceiptOfInvoiceBatchLine")
            dgvROIBatchLines.DataSource = ds.Tables("ReceiptOfInvoiceBatchLine")
            con.Close()
            Me.dgvROIBatchLines.Columns("DivisionIDColumn").Visible = False
        End If
    End Sub

    Public Sub LoadVendor()
        'Create commands to load Vendor List for each division
        cmd = New SqlCommand("SELECT VendorCode FROM Vendor Where DivisionID = @DivisionID ORDER BY VendorCode", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd
        myAdapter2.Fill(ds2, "Vendor")
        cboVendorID.DataSource = ds2.Tables("Vendor")
        con.Close()
        cboVendorID.SelectedIndex = -1
    End Sub

    Public Sub LoadPONumber()
        cmd = New SqlCommand("SELECT PurchaseOrderHeaderKey FROM PurchaseOrderHeaderTable Where DivisionID = @DivisionID ORDER BY PurchaseOrderHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd
        myAdapter3.Fill(ds3, "PurchaseOrderHeaderTable")
        cboPONumber.DataSource = ds3.Tables("PurchaseOrderHeaderTable")
        con.Close()
        cboPONumber.SelectedIndex = -1
    End Sub

    Public Sub LoadReceiverNumber()
        cmd = New SqlCommand("SELECT ReceivingHeaderKey FROM ReceivingHeaderTable Where DivisionID = @DivisionID ORDER BY ReceivingHeaderKey DESC", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        If con.State = ConnectionState.Closed Then con.Open()
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd
        myAdapter4.Fill(ds4, "ReceivingHeaderTable")
        cboReceiverNumber.DataSource = ds4.Tables("ReceivingHeaderTable")
        con.Close()
        cboReceiverNumber.SelectedIndex = -1
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        ClearData()
        LoadVendor()
        LoadPONumber()
        LoadReceiverNumber()
        ClearDataInDatagrid()
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
        cboVendorID.Text = ""
        cboPONumber.Text = ""
        cboReceiverNumber.Text = ""

        cboVendorID.SelectedIndex = -1
        cboPONumber.SelectedIndex = -1
        cboReceiverNumber.SelectedIndex = -1

        txtVendorName.Clear()
        txtInvoiceNumber.Clear()

        dtpBeginDate.Text = ""
        dtpEndDate.Text = ""

        cboVendorID.Focus()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        ShowDataByFilter()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearData()
        ClearDataInDatagrid()
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GDS = ds
        Using NewPrintVendorSummary As New PrintVendorPurchaseSummaryFiltered
            Dim result = NewPrintVendorSummary.ShowDialog()
        End Using
    End Sub

    Private Sub PrintListingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintListingToolStripMenuItem.Click
        GDS = ds
        Using NewPrintVendorSummary As New PrintVendorPurchaseSummaryFiltered
            Dim result = NewPrintVendorSummary.ShowDialog()
        End Using
    End Sub

    Private Sub ExiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExiToolStripMenuItem.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        ClearData()
        Me.Dispose()
        Me.Close()
    End Sub
End Class