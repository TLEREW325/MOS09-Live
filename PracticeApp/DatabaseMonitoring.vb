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
Public Class DatabaseMonitoring
    Inherits System.Windows.Forms.Form

    'Create variables for monitoring
    Dim UnpostedARCashReceipts, UnpostedAPVouchers, UnpostedCheckBatches, UnpostedCustomerReturns, UnpostedVendorReturns, UnpostedAdjustments, PendingInvoices, UnpostedInvoiceBatches, UnpostedReceivers, UninvoicedShipments As Integer
    Dim AllUnpostedARCashReceipts, AllUnpostedAPVouchers, AllUnpostedCheckBatches, AllUnpostedCustomerReturns, AllUnpostedVendorReturns, AllUnpostedAdjustments, AllPendingInvoices, AllUnpostedInvoiceBatches, AllUnpostedReceivers, AllUninvoicedShipments As Integer

    Dim DivisionFilter As String = ""
    Dim DivisionCounter As Integer = 1
    Dim DivisionIndex(16) As String

    Public Function FillDivisionArray()
        'Define Divisions by index
        DivisionIndex(1) = "ATL"
        DivisionIndex(2) = "CBS"
        DivisionIndex(3) = "CGO"
        DivisionIndex(4) = "CHT"
        DivisionIndex(5) = "DEN"
        DivisionIndex(6) = "HOU"
        DivisionIndex(7) = "SLC"
        DivisionIndex(8) = "TFF"
        DivisionIndex(9) = "TFT"
        DivisionIndex(10) = "TWD"
        DivisionIndex(11) = "TWE"
        DivisionIndex(12) = "TOR"
        DivisionIndex(13) = "TFP"
        DivisionIndex(14) = "ALB"
        DivisionIndex(15) = "TFJ"
        DivisionIndex(16) = "LLH"
    End Function

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
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10, myAdapter11, myAdapter12, myAdapter13, myAdapter14, myAdapter15, myAdapter16, myAdapter17, myAdapter18, myAdapter19, myAdapter20, myAdapter21, myAdapter22, myAdapter23, myAdapter24, myAdapter25, myAdapter26, myAdapter27, myAdapter28, myAdapter29, myAdapter30, myAdapter31, myadapter32 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10, ds11, ds12, ds13, ds14, ds15, ds16, ds17, ds18, ds19, ds20, ds21, ds22, ds23, ds24, ds25, ds26, ds27, ds28, ds29, ds30, ds31, ds32 As DataSet
    Dim dt As DataTable
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter

    Private Sub DatabaseMonitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCurrentDivision()

        cboDivisionID.Text = EmployeeCompanyCode
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

    Private Sub cmdViewAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewAll.Click
        'Make sure datagrid is empty
        Me.dgvDivisionData.DataSource = Nothing

        DivisionCounter = 1
        FillDivisionArray()

        'Start Loop to fill data
        For i As Integer = 1 To 16
            'Get Data from database
            LoadDataAllDivisions()

            'Add line to datagrid
            Me.dgvDivisionData.Rows.Add(DivisionIndex(DivisionCounter), AllUninvoicedShipments, AllPendingInvoices, AllUnpostedAPVouchers, AllUnpostedCheckBatches, AllUnpostedInvoiceBatches, AllUnpostedARCashReceipts, AllUnpostedReceivers, AllUnpostedAdjustments, AllUnpostedCustomerReturns, AllUnpostedVendorReturns)

            'Clear Data
            AllPendingInvoices = 0
            AllUninvoicedShipments = 0
            AllUnpostedAdjustments = 0
            AllUnpostedAPVouchers = 0
            AllUnpostedARCashReceipts = 0
            AllUnpostedCheckBatches = 0
            AllUnpostedCustomerReturns = 0
            AllUnpostedInvoiceBatches = 0
            AllUnpostedReceivers = 0
            AllUnpostedVendorReturns = 0

            'Advance counter
            DivisionCounter = DivisionCounter + 1
        Next i
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadMonitoringData()
    End Sub

    Public Sub LoadDataAllDivisions()
        Dim UnpostedCustomerReturnsStatement As String = "SELECT COUNT(ReturnNumber) FROM ReturnProductHeaderTable WHERE ReturnStatus = @ReturnStatus AND DivisionID = @DivisionID"
        Dim UnpostedCustomerReturnsCommand As New SqlCommand(UnpostedCustomerReturnsStatement, con)
        UnpostedCustomerReturnsCommand.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"
        UnpostedCustomerReturnsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)

        Dim UnpostedCheckBatchStatement As String = "SELECT COUNT(BatchNumber) FROM APProcessPaymentBatch WHERE BatchStatus = @BatchStatus AND DivisionID = @DivisionID"
        Dim UnpostedCheckBatchCommand As New SqlCommand(UnpostedCheckBatchStatement, con)
        UnpostedCheckBatchCommand.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        UnpostedCheckBatchCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)

        Dim UnpostedVendorReturnsStatement As String = "SELECT COUNT(ReturnNumber) FROM VendorReturn WHERE ReturnStatus = @ReturnStatus AND DivisionID = @DivisionID"
        Dim UnpostedVendorReturnsCommand As New SqlCommand(UnpostedVendorReturnsStatement, con)
        UnpostedVendorReturnsCommand.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"
        UnpostedVendorReturnsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)

        Dim UnpostedAdjustmentsStatement As String = "SELECT COUNT(AdjustmentNumber) FROM InventoryAdjustmentTable WHERE Status = @Status AND DivisionID = @DivisionID"
        Dim UnpostedAdjustmentsCommand As New SqlCommand(UnpostedAdjustmentsStatement, con)
        UnpostedAdjustmentsCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        UnpostedAdjustmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)

        Dim UnpostedReceiversStatement As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingHeaderTable WHERE Status = @Status AND DivisionID = @DivisionID"
        Dim UnpostedReceiversCommand As New SqlCommand(UnpostedReceiversStatement, con)
        UnpostedReceiversCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        UnpostedReceiversCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)

        Dim PendingInvoicesStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceHeaderTable WHERE InvoiceStatus = @InvoiceStatus AND DivisionID = @DivisionID"
        Dim PendingInvoicesCommand As New SqlCommand(PendingInvoicesStatement, con)
        PendingInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
        PendingInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)

        Dim OpenInvoiceBatchesStatement As String = "SELECT COUNT(BatchNumber) FROM InvoiceProcessingBatchHeader WHERE BatchStatus = @BatchStatus AND DivisionID = @DivisionID"
        Dim OpenInvoiceBatchesCommand As New SqlCommand(OpenInvoiceBatchesStatement, con)
        OpenInvoiceBatchesCommand.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        OpenInvoiceBatchesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)

        Dim UninvoicedShipmentsStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE ShipmentStatus = @ShipmentStatus AND DivisionID = @DivisionID"
        Dim UninvoicedShipmentsCommand As New SqlCommand(UninvoicedShipmentsStatement, con)
        UninvoicedShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
        UninvoicedShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)

        Dim UnpostedVouchersStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE VoucherStatus = @VoucherStatus AND DivisionID = @DivisionID"
        Dim UnpostedVouchersCommand As New SqlCommand(UnpostedVouchersStatement, con)
        UnpostedVouchersCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
        UnpostedVouchersCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)

        Dim UnpostedCashReceiptsStatement As String = "SELECT COUNT(BatchNumber) FROM ARProcessPaymentBatch WHERE BatchStatus = @BatchStatus AND DivisionID = @DivisionID"
        Dim UnpostedCashReceiptsCommand As New SqlCommand(UnpostedCashReceiptsStatement, con)
        UnpostedCashReceiptsCommand.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        UnpostedCashReceiptsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = DivisionIndex(DivisionCounter)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            AllUnpostedCustomerReturns = CInt(UnpostedCustomerReturnsCommand.ExecuteScalar)
        Catch ex As Exception
            AllUnpostedCustomerReturns = 0
        End Try
        Try
            AllUnpostedVendorReturns = CInt(UnpostedVendorReturnsCommand.ExecuteScalar)
        Catch ex As Exception
            AllUnpostedVendorReturns = 0
        End Try
        Try
            AllUnpostedAdjustments = CInt(UnpostedAdjustmentsCommand.ExecuteScalar)
        Catch ex As Exception
            AllUnpostedAdjustments = 0
        End Try
        Try
            AllUnpostedReceivers = CInt(UnpostedReceiversCommand.ExecuteScalar)
        Catch ex As Exception
            AllUnpostedReceivers = 0
        End Try
        Try
            AllPendingInvoices = CInt(PendingInvoicesCommand.ExecuteScalar)
        Catch ex As Exception
            AllPendingInvoices = 0
        End Try
        Try
            AllUnpostedInvoiceBatches = CInt(OpenInvoiceBatchesCommand.ExecuteScalar)
        Catch ex As Exception
            AllUnpostedInvoiceBatches = 0
        End Try
        Try
            AllUninvoicedShipments = CInt(UninvoicedShipmentsCommand.ExecuteScalar)
        Catch ex As Exception
            AllUninvoicedShipments = 0
        End Try
        Try
            AllUnpostedAPVouchers = CInt(UnpostedVouchersCommand.ExecuteScalar)
        Catch ex As Exception
            AllUnpostedAPVouchers = 0
        End Try
        Try
            AllUnpostedARCashReceipts = CInt(UnpostedCashReceiptsCommand.ExecuteScalar)
        Catch ex As Exception
            AllUnpostedARCashReceipts = 0
        End Try
        Try
            AllUnpostedCheckBatches = CInt(UnpostedCheckBatchCommand.ExecuteScalar)
        Catch ex As Exception
            AllUnpostedCheckBatches = 0
        End Try
        con.Close()
    End Sub

    Public Sub LoadMonitoringData()
        If cboDivisionID.Text = "ADM" Then
            DivisionFilter = ""
        Else
            DivisionFilter = " AND DivisionID = @DivisionID"
        End If

        Dim UnpostedCustomerReturnsStatement As String = "SELECT COUNT(ReturnNumber) FROM ReturnProductHeaderTable WHERE ReturnStatus = @ReturnStatus" + DivisionFilter
        Dim UnpostedCustomerReturnsCommand As New SqlCommand(UnpostedCustomerReturnsStatement, con)
        UnpostedCustomerReturnsCommand.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"
        UnpostedCustomerReturnsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UnpostedCustomerReturns = CInt(UnpostedCustomerReturnsCommand.ExecuteScalar)
        Catch ex As Exception
            UnpostedCustomerReturns = 0
        End Try
        con.Close()

        Dim UnpostedVendorReturnsStatement As String = "SELECT COUNT(ReturnNumber) FROM VendorReturn WHERE ReturnStatus = @ReturnStatus" + DivisionFilter
        Dim UnpostedVendorReturnsCommand As New SqlCommand(UnpostedVendorReturnsStatement, con)
        UnpostedVendorReturnsCommand.Parameters.Add("@ReturnStatus", SqlDbType.VarChar).Value = "OPEN"
        UnpostedVendorReturnsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UnpostedVendorReturns = CInt(UnpostedVendorReturnsCommand.ExecuteScalar)
        Catch ex As Exception
            UnpostedVendorReturns = 0
        End Try
        con.Close()

        Dim UnpostedAdjustmentsStatement As String = "SELECT COUNT(AdjustmentNumber) FROM InventoryAdjustmentTable WHERE Status = @Status" + DivisionFilter
        Dim UnpostedAdjustmentsCommand As New SqlCommand(UnpostedAdjustmentsStatement, con)
        UnpostedAdjustmentsCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        UnpostedAdjustmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UnpostedAdjustments = CInt(UnpostedAdjustmentsCommand.ExecuteScalar)
        Catch ex As Exception
            UnpostedAdjustments = 0
        End Try
        con.Close()

        Dim UnpostedReceiversStatement As String = "SELECT COUNT(ReceivingHeaderKey) FROM ReceivingHeaderTable WHERE Status = @Status" + DivisionFilter
        Dim UnpostedReceiversCommand As New SqlCommand(UnpostedReceiversStatement, con)
        UnpostedReceiversCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "OPEN"
        UnpostedReceiversCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UnpostedReceivers = CInt(UnpostedReceiversCommand.ExecuteScalar)
        Catch ex As Exception
            UnpostedReceivers = 0
        End Try
        con.Close()

        Dim PendingInvoicesStatement As String = "SELECT COUNT(InvoiceNumber) FROM InvoiceHeaderTable WHERE InvoiceStatus = @InvoiceStatus" + DivisionFilter
        Dim PendingInvoicesCommand As New SqlCommand(PendingInvoicesStatement, con)
        PendingInvoicesCommand.Parameters.Add("@InvoiceStatus", SqlDbType.VarChar).Value = "PENDING"
        PendingInvoicesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PendingInvoices = CInt(PendingInvoicesCommand.ExecuteScalar)
        Catch ex As Exception
            PendingInvoices = 0
        End Try
        con.Close()

        Dim OpenInvoiceBatchesStatement As String = "SELECT COUNT(BatchNumber) FROM InvoiceProcessingBatchHeader WHERE BatchStatus = @BatchStatus" + DivisionFilter
        Dim OpenInvoiceBatchesCommand As New SqlCommand(OpenInvoiceBatchesStatement, con)
        OpenInvoiceBatchesCommand.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        OpenInvoiceBatchesCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UnpostedInvoiceBatches = CInt(OpenInvoiceBatchesCommand.ExecuteScalar)
        Catch ex As Exception
            UnpostedInvoiceBatches = 0
        End Try
        con.Close()

        Dim UninvoicedShipmentsStatement As String = "SELECT COUNT(ShipmentNumber) FROM ShipmentHeaderTable WHERE ShipmentStatus = @ShipmentStatus" + DivisionFilter
        Dim UninvoicedShipmentsCommand As New SqlCommand(UninvoicedShipmentsStatement, con)
        UninvoicedShipmentsCommand.Parameters.Add("@ShipmentStatus", SqlDbType.VarChar).Value = "SHIPPED"
        UninvoicedShipmentsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UninvoicedShipments = CInt(UninvoicedShipmentsCommand.ExecuteScalar)
        Catch ex As Exception
            UninvoicedShipments = 0
        End Try
        con.Close()

        Dim UnpostedVouchersStatement As String = "SELECT COUNT(VoucherNumber) FROM ReceiptOfInvoiceBatchLine WHERE VoucherStatus = @VoucherStatus" + DivisionFilter
        Dim UnpostedVouchersCommand As New SqlCommand(UnpostedVouchersStatement, con)
        UnpostedVouchersCommand.Parameters.Add("@VoucherStatus", SqlDbType.VarChar).Value = "OPEN"
        UnpostedVouchersCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UnpostedAPVouchers = CInt(UnpostedVouchersCommand.ExecuteScalar)
        Catch ex As Exception
            UnpostedAPVouchers = 0
        End Try
        con.Close()

        Dim UnpostedCashReceiptsStatement As String = "SELECT COUNT(BatchNumber) FROM ARProcessPaymentBatch WHERE BatchStatus = @BatchStatus" + DivisionFilter
        Dim UnpostedCashReceiptsCommand As New SqlCommand(UnpostedCashReceiptsStatement, con)
        UnpostedCashReceiptsCommand.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        UnpostedCashReceiptsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UnpostedARCashReceipts = CInt(UnpostedCashReceiptsCommand.ExecuteScalar)
        Catch ex As Exception
            UnpostedARCashReceipts = 0
        End Try
        con.Close()

        Dim UnpostedCheckBatchStatement As String = "SELECT COUNT(BatchNumber) FROM APProcessPaymentBatch WHERE BatchStatus = @BatchStatus" + DivisionFilter
        Dim UnpostedCheckBatchCommand As New SqlCommand(UnpostedCheckBatchStatement, con)
        UnpostedCheckBatchCommand.Parameters.Add("@BatchStatus", SqlDbType.VarChar).Value = "OPEN"
        UnpostedCheckBatchCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            UnpostedCheckBatches = CInt(UnpostedCheckBatchCommand.ExecuteScalar)
        Catch ex As Exception
            UnpostedCheckBatches = 0
        End Try
        con.Close()

        txtUnpostedCheckBatches.Text = UnpostedCheckBatches
        txtUnpostedARReceipts.Text = UnpostedARCashReceipts
        txtUnpostedAPVouchers.Text = UnpostedAPVouchers
        txtShipmentsToBeInvoiced.Text = UninvoicedShipments
        txtUnpostedInvoiceBatches.Text = UnpostedInvoiceBatches
        txtPendingInvoices.Text = PendingInvoices
        txtUnpostedReceivers.Text = UnpostedReceivers
        txtUnpostedAdjustments.Text = UnpostedAdjustments
        txtUnpostedVendorReturns.Text = UnpostedVendorReturns
        txtUnpostedCustomerReturns.Text = UnpostedCustomerReturns
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class